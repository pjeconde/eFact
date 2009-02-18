using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.VisualBasic;

namespace FEArn
{
	/// <summary> 
	/// Clase para crear objetos Login Tickets 
	/// </summary> 
	class LoginTicket
	{
		// Entero de 32 bits sin signo que identifica el requerimiento 
		public UInt32 UniqueId;
		// Momento en que fue generado el requerimiento 
		public DateTime GenerationTime;
		// Momento en el que exoira la solicitud 
		public DateTime ExpirationTime;
		// Identificacion del WSN para el cual se solicita el TA 
		public string Service;
		// Firma de seguridad recibida en la respuesta 
		public string Sign;
		// Token de seguridad recibido en la respuesta 
		public string Token;

		public XmlDocument XmlLoginTicketRequest = null;
		public XmlDocument XmlLoginTicketResponse = null;
		public string RutaDelCertificadoFirmante;
		public string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";

		private bool _verboseMode = true;

		// OJO! NO ES THREAD-SAFE 
		private static UInt32 _globalUniqueID = 0;

		/// <summary> 
		/// Construye un Login Ticket obtenido del WSAA 
		/// </summary> 
		/// <param name="argServicio">Servicio al que se desea acceder</param> 
		/// <param name="argUrlWsaa">URL del WSAA</param> 
		/// <param name="argRutaCertX509Firmante">Ruta del certificado X509 (con clave privada) usado para firmar</param> 
		/// <param name="argVerbose">Nivel detallado de descripcion? true/false</param> 
		/// <remarks></remarks> 
		public string ObtenerLoginTicketResponse(string argServicio, string argUrlWsaa, string argRutaCertX509Firmante, bool argVerbose, WebProxy Wp)
		{

			this.RutaDelCertificadoFirmante = argRutaCertX509Firmante;
			this._verboseMode = argVerbose;
			CertificadosX509Lib.VerboseMode = argVerbose;

			string cmsFirmadoBase64;
			string loginTicketResponse;

			XmlNode xmlNodoUniqueId;
			XmlNode xmlNodoGenerationTime;
			XmlNode xmlNodoExpirationTime;
			XmlNode xmlNodoService;

			// PASO 1: Genero el Login Ticket Request 
			try
			{
				XmlLoginTicketRequest = new XmlDocument();
				XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

				xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
				xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
				xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
				xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");

				// Las horas son UTC formato yyyy-MM-ddTHH:mm:ssZ
				xmlNodoGenerationTime.InnerText = DateTime.UtcNow.AddMinutes(-10).ToString("s") + "Z";
				xmlNodoExpirationTime.InnerText = DateTime.UtcNow.AddMinutes(+10).ToString("s") + "Z";
				xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
				xmlNodoService.InnerText = argServicio;
				this.Service = argServicio;

				_globalUniqueID += 1;

				if (this._verboseMode)
				{
					Console.WriteLine(XmlLoginTicketRequest.OuterXml);
				}
			}

			catch (Exception excepcionAlGenerarLoginTicketRequest)
			{
				throw new Exception("***Error generando el LoginTicketRequest: ObtenerLoginTicketResponse: " + excepcionAlGenerarLoginTicketRequest.Message);
			}

			// PASO 2: Firmo el Login Ticket Request 
			try
			{
				if (this._verboseMode)
				{
					Console.WriteLine("***Leyendo certificado: {0}", RutaDelCertificadoFirmante);
				}

				X509Certificate2 certFirmante = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante);

				if (this._verboseMode)
				{
					Console.WriteLine("***Firmando: ");
					Console.WriteLine(XmlLoginTicketRequest.OuterXml);
				}

				// Convierto el login ticket request a bytes, para firmar 
				Encoding EncodedMsg = Encoding.UTF8;
				byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);

				// Firmo el msg y paso a Base64 
				byte[] encodedSignedCms = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
				cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);
			}

			catch (Exception excepcionAlFirmar)
			{
				throw new Exception("***Error firmando el LoginTicketRequest: ObtenerLoginTicketResponse: " + excepcionAlFirmar.Message);
			}

			// PASO 3: Invoco al WSAA para obtener el Login Ticket Response 
			FEArn.ar.gov.afip.wsaa.LoginCMSService servicioWsaa = new FEArn.ar.gov.afip.wsaa.LoginCMSService(); 
			try
			{
				if (this._verboseMode)
				{
					Console.WriteLine("***Llamando al WSAA en URL: {0}", argUrlWsaa);
					Console.WriteLine("***Argumento en el request:");
					Console.WriteLine(cmsFirmadoBase64);
				}

				if (Wp != null)
				{
					servicioWsaa.Proxy = Wp;
				}

				servicioWsaa.Url = argUrlWsaa;

				loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);

				if (this._verboseMode)
				{
					Console.WriteLine("***LoginTicketResponse: ");
					Console.WriteLine(loginTicketResponse);
				}
			}

			catch (Exception excepcionAlInvocarWsaa)
			{
				throw new Exception("***Error invocando al servicio WSAA: ObtenerLoginTicketResponse: " + excepcionAlInvocarWsaa.Message);
			}

			// PASO 4: Analizo el Login Ticket Response recibido del WSAA 
			try
			{
				XmlLoginTicketResponse = new XmlDocument();
				XmlLoginTicketResponse.LoadXml(loginTicketResponse);

				this.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
				this.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
				this.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
				this.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
				this.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
			}
			catch (Exception excepcionAlAnalizarLoginTicketResponse)
			{
				throw new Exception("***Error analizando respuesta del WSAA: ObtenerLoginTicketResponse: " + excepcionAlAnalizarLoginTicketResponse.Message);
			}
			return loginTicketResponse;

		}


	}

	/// <summary> 
	/// Libreria de utilidades para manejo de certificados 
	/// </summary> 
	/// <remarks></remarks> 
	class CertificadosX509Lib
	{

		public static bool VerboseMode = false;

		/// <summary> 
		/// Firma mensaje 
		/// </summary> 
		/// <param name="argBytesMsg">Bytes del mensaje</param> 
		/// <param name="argCertFirmante">Certificado usado para firmar</param> 
		/// <returns>Bytes del mensaje firmado</returns> 
		/// <remarks></remarks> 
		public static byte[] FirmaBytesMensaje(byte[] argBytesMsg, X509Certificate2 argCertFirmante)
		{
			try
			{
				// Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms) 
				ContentInfo infoContenido = new ContentInfo(argBytesMsg);
				SignedCms cmsFirmado = new SignedCms(infoContenido);

				// Creo objeto CmsSigner que tiene las caracteristicas del firmante 
				CmsSigner cmsFirmante = new CmsSigner(argCertFirmante);
				cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

				if (VerboseMode)
				{
					Console.WriteLine("***Firmando bytes del mensaje...");
				}
				// Firmo el mensaje PKCS #7 
				cmsFirmado.ComputeSignature(cmsFirmante);

				if (VerboseMode)
				{
					Console.WriteLine("***OK mensaje firmado");
				}

				// Encodeo el mensaje PKCS #7. 
				return cmsFirmado.Encode();
			}
			catch (Exception excepcionAlFirmar)
			{
				throw new Exception("***Error al firmar: FirmaBytesMensaje: " + excepcionAlFirmar.Message);
			}
		}

		/// <summary> 
		/// Lee certificado de disco 
		/// </summary> 
		/// <param name="argArchivo">Ruta del certificado a leer.</param> 
		/// <returns>Un objeto certificado X509</returns> 
		/// <remarks></remarks> 
		public static X509Certificate2 ObtieneCertificadoDesdeArchivo(string argArchivo)
		{
			X509Certificate2 objCert = new X509Certificate2();

			try
			{
				objCert.Import(Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes(argArchivo));
				return objCert;
			}
			catch (Exception excepcionAlImportarCertificado)
			{
				throw new Exception("***Error al obtener certificado: ObtieneCertificadoDesdeArchivo(" + argArchivo + "): " + excepcionAlImportarCertificado.Message + " " + excepcionAlImportarCertificado.StackTrace);

			}
		}

	}
}