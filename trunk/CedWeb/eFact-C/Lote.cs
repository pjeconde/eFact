using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eFact_C
{
    public class Lote
    {
        private string uRL;
        private eFact_C.Entidades.Certificado certificado;
        private eFact_C.Entidades.Proxy proxy;
        //Constructor
        public Lote(string URL, eFact_C.Entidades.Certificado Certificado, eFact_C.Entidades.Proxy Proxy)
        {
            try
            {
                uRL = URL;
                certificado = Certificado;
                proxy = Proxy;
                ValidarUrl(uRL, certificado, proxy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private static void ValidarUrl(string Url, eFact_C.Entidades.Certificado Certificado, eFact_C.Entidades.Proxy Proxy)
        {
            IBK.FacturaWebServiceConSchema objIBK;
            objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = Url;
            if (Proxy != null)
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(Proxy.Servidor, false);
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(Proxy.Usuario, Proxy.Clave, Proxy.Dominio);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            X509Store store;
            if (Certificado.LugarDeAlmacenamiento == eFact_C.Entidades.Certificado.Almacenamiento.CurrentUser)
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, Certificado.Numero, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                object o = objIBK.getLoteFacturasConSchema(new eFact_C.IBK.consulta_lote_comprobantes());
            }
        }
        public FeaEntidades.InterFacturas.lote_comprobantes Consultar(FeaEntidades.InterFacturas.consulta_lote_comprobantes consultalotecomprobantes, out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes)
        {
            List<FeaEntidades.InterFacturas.error> respErroresLote;
            List<FeaEntidades.InterFacturas.error> respErroresComprobantes;
            try
            {
                eFact_C.Comprobante c = new eFact_C.Comprobante();
                eFact_C.IBK.consulta_lote_comprobantes clc = new eFact_C.IBK.consulta_lote_comprobantes();
                clc.cuit_canal = consultalotecomprobantes.cuit_canal;
                clc.cuit_vendedor = consultalotecomprobantes.cuit_vendedor;
                clc.punto_de_venta = consultalotecomprobantes.punto_de_venta;
                clc.punto_de_ventaSpecified = true;
                clc.id_lote = consultalotecomprobantes.id_lote;
                FeaEntidades.InterFacturas.lote_comprobantes lc;
                lc = c.ConsultarIBK(out respErroresLote, out respErroresComprobantes, clc, uRL, certificado, proxy);
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public FeaEntidades.InterFacturas.lote_response Enviar(FeaEntidades.InterFacturas.lote_comprobantes Lc, out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes)
        {
            List<FeaEntidades.InterFacturas.error> respErroresLote;
            List<FeaEntidades.InterFacturas.error> respErroresComprobantes;
            try
            {
                eFact_C.Comprobante c = new eFact_C.Comprobante();
                FeaEntidades.InterFacturas.lote_response loteResponse;
                loteResponse = c.EnviarIBK(out respErroresLote, out respErroresComprobantes, Lc, uRL, certificado, proxy);
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                return loteResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static string ArmarLoteXML(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            string LoteXML = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;
            return LoteXML;
        }
        private static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
    }
}
