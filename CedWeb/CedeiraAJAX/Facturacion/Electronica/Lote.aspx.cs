using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace CedeiraAJAX.Facturacion.Electronica
{
	public partial class Lote : System.Web.UI.Page
	{
		#region Variables
		string gvUniqueID = String.Empty;
		System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				if (Session["AceptarTYC"] == null || Session["AceptarTYC"].Equals(false))
				{
					Server.Transfer("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
				}
				else
				{
					referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
					FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					referencias.Add(referencia);
					referenciasGridView.DataSource = referencias;
					ViewState["referencias"] = referencias;

					Condicion_IVA_VendedorDropDownList.DataValueField = "Codigo";
					Condicion_IVA_VendedorDropDownList.DataTextField = "Descr";
					Condicion_IVA_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();

					Condicion_Ingresos_Brutos_VendedorDropDownList.DataValueField = "Codigo";
					Condicion_Ingresos_Brutos_VendedorDropDownList.DataTextField = "Descr";
					Condicion_Ingresos_Brutos_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();

					Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();

					Condicion_IVA_CompradorDropDownList.DataValueField = "Codigo";
					Condicion_IVA_CompradorDropDownList.DataTextField = "Descr";
					Condicion_IVA_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();

					//Condicion_Ingresos_Brutos_CompradorDropDownList.DataValueField = "Codigo";
					//Condicion_Ingresos_Brutos_CompradorDropDownList.DataTextField = "Descr";
					//Condicion_Ingresos_Brutos_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();

					Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
					Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
					Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();

					CodigoOperacionDropDownList.DataValueField = "Codigo";
					CodigoOperacionDropDownList.DataTextField = "Descr";
					CodigoOperacionDropDownList.DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.Lista();

					Provincia_CompradorDropDownList.DataValueField = "Codigo";
					Provincia_CompradorDropDownList.DataTextField = "Descr";
					Provincia_CompradorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();

					Provincia_VendedorDropDownList.DataValueField = "Codigo";
					Provincia_VendedorDropDownList.DataTextField = "Descr";
					Provincia_VendedorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();

					IVAcomputableDropDownList.DataValueField = "Codigo";
					IVAcomputableDropDownList.DataTextField = "Descr";
					IVAcomputableDropDownList.DataSource = FeaEntidades.Dicotomicos.Dicotomico.Lista();

					MonedaComprobanteDropDownList.DataValueField = "Codigo";
					MonedaComprobanteDropDownList.DataTextField = "Descr";
					MonedaComprobanteDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.ListaNoExportacion();

					TipoExpDropDownList.DataValueField = "Codigo";
					TipoExpDropDownList.DataTextField = "Descr";
					TipoExpDropDownList.DataSource = FeaEntidades.TiposExportacion.TipoExportacion.ListaSinInformar();

					IdiomaDropDownList.DataValueField = "Codigo";
					IdiomaDropDownList.DataTextField = "Descr";
					IdiomaDropDownList.DataSource = FeaEntidades.Idiomas.Idioma.ListaSinInformar();

					PaisDestinoExpDropDownList.DataValueField = "Codigo";
					PaisDestinoExpDropDownList.DataTextField = "Descr";
					PaisDestinoExpDropDownList.DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();

					IncotermsDropDownList.DataValueField = "Codigo";
					IncotermsDropDownList.DataTextField = "Descr";
					IncotermsDropDownList.DataSource = FeaEntidades.Incoterms.Incoterm.ListaSinInformar();

					CodigoConceptoDropDownList.DataValueField = "Codigo";
					CodigoConceptoDropDownList.DataTextField = "Descr";
					CodigoConceptoDropDownList.DataSource = FeaEntidades.CodigosConcepto.CodigosConcepto.Lista();

					DataBind();

					BindearDropDownLists();

					CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
					if (sesion.Cuenta.Id != null)
					{
						CedWebRN.Cuenta.ReservarNroLote(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
						Id_LoteTextbox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.UltimoNroLote.ToString();
						Email_VendedorRequiredFieldValidator.Enabled = false;
						GenerarButton.Text = "Enviar archivo XML al e-mail de la cuenta eFact (" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email + ")";
						if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
						{
							MonedaComprobanteDropDownList.Enabled = true;
							MonedaComprobanteExclusivoPremiumLabel.Visible = false;
							CompradorDropDownList.Enabled = true;
						}
					}
					if (sesion.Cuenta.Vendedor.CUIT != 0)
					{
						CedWebEntidades.Vendedor v = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor;
						Razon_Social_VendedorTextBox.Text = v.RazonSocial;
                        CompletarDomicilioVendedor(v);
						Contacto_VendedorTextBox.Text = v.NombreContacto;
						Email_VendedorTextBox.Text = v.EmailContacto;
						Telefono_VendedorTextBox.Text = v.TelefonoContacto.ToString();
						Cuit_VendedorTextBox.Text = v.CUIT.ToString();
						Condicion_IVA_VendedorDropDownList.SelectedValue = v.IdCondIVA.ToString();
						NroIBVendedorTextBox.Text = v.NroIngBrutos.ToString();
						Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue = v.IdCondIngBrutos.ToString();
						if (!v.GLN.ToString().Equals("0"))
						{
							GLN_VendedorTextBox.Text = v.GLN.ToString();
						}
						Codigo_Interno_VendedorTextBox.Text = v.CodigoInterno;
						InicioDeActividadesVendedorDatePickerWebUserControl.CalendarDate = v.FechaInicioActividades;
					}
					System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores = CedWebRN.Comprador.Lista(sesion.Cuenta, sesion);
					if (listacompradores.Count > 0)
					{
						CompradorDropDownList.Visible = true;
						CompradorDropDownList.DataValueField = "RazonSocial";
						CompradorDropDownList.DataTextField = "RazonSocial";
						CompradorDropDownList.DataSource = listacompradores;
						CompradorDropDownList.DataBind();
					}
					else
					{
						CompradorDropDownList.Visible = false;
						CompradorDropDownList.DataSource = null;
					}
				}
			}
		}

        private void CompletarDomicilioVendedor(CedWebEntidades.Vendedor v)
        {
            Domicilio_Calle_VendedorTextBox.Text = v.Domicilio.Calle;
            Domicilio_Numero_VendedorTextBox.Text = v.Domicilio.Nro;
            Domicilio_Piso_VendedorTextBox.Text = v.Domicilio.Piso;
            Domicilio_Depto_VendedorTextBox.Text = v.Domicilio.Depto;
            Domicilio_Sector_VendedorTextBox.Text = v.Domicilio.Sector;
            Domicilio_Torre_VendedorTextBox.Text = v.Domicilio.Torre;
            Domicilio_Manzana_VendedorTextBox.Text = v.Domicilio.Manzana;
            Localidad_VendedorTextBox.Text = v.Domicilio.Localidad;
            Provincia_VendedorDropDownList.SelectedValue = v.Domicilio.Provincia.Id;
            Cp_VendedorTextBox.Text = v.Domicilio.CodPost;
        }

        private void CompletarDomicilioVendedor(CedWebEntidades.PuntoDeVenta pv, CedWebEntidades.Vendedor v)
        {
            if (!pv.Domicilio.Calle.Equals(string.Empty))
            {
                Domicilio_Calle_VendedorTextBox.Text = pv.Domicilio.Calle;
            }
            else
            {
                Domicilio_Calle_VendedorTextBox.Text = v.Domicilio.Calle;
            }
            if (!pv.Domicilio.Nro.Equals(string.Empty))
            {
                Domicilio_Numero_VendedorTextBox.Text = pv.Domicilio.Nro;
            }
            else
            {
                Domicilio_Numero_VendedorTextBox.Text = v.Domicilio.Nro;
            }
            if (!pv.Domicilio.Piso.Equals(string.Empty))
            {
                Domicilio_Piso_VendedorTextBox.Text = pv.Domicilio.Piso;
            }
            else
            {
                Domicilio_Piso_VendedorTextBox.Text = v.Domicilio.Piso;
            }
            if (!pv.Domicilio.Depto.Equals(string.Empty))
            {
                Domicilio_Depto_VendedorTextBox.Text = pv.Domicilio.Depto;
            }
            else
            {
                Domicilio_Depto_VendedorTextBox.Text = v.Domicilio.Depto;
            }
            if (!pv.Domicilio.Sector.Equals(string.Empty))
            {
                Domicilio_Sector_VendedorTextBox.Text = pv.Domicilio.Sector;
            }
            else
            {
                Domicilio_Sector_VendedorTextBox.Text = v.Domicilio.Sector;
            }
            if (!pv.Domicilio.Torre.Equals(string.Empty))
            {
                Domicilio_Torre_VendedorTextBox.Text = pv.Domicilio.Torre;
            }
            else
            {
                Domicilio_Torre_VendedorTextBox.Text = v.Domicilio.Torre;
            }
            if (!pv.Domicilio.Manzana.Equals(string.Empty))
            {
                Domicilio_Manzana_VendedorTextBox.Text = pv.Domicilio.Manzana;
            }
            else
            {
                Domicilio_Manzana_VendedorTextBox.Text = v.Domicilio.Manzana;
            }
            if (!pv.Domicilio.Localidad.Equals(string.Empty))
            {
                Localidad_VendedorTextBox.Text = pv.Domicilio.Localidad;
            }
            else
            {
                Localidad_VendedorTextBox.Text = v.Domicilio.Localidad;
            }
            if (!pv.Domicilio.Provincia.Id.Equals(string.Empty))
            {
                Provincia_VendedorDropDownList.SelectedValue = pv.Domicilio.Provincia.Id;
            }
            else
            {
                Provincia_VendedorDropDownList.SelectedValue = v.Domicilio.Provincia.Id;
            }
            if (!pv.Domicilio.CodPost.Equals(string.Empty))
            {
                Cp_VendedorTextBox.Text = pv.Domicilio.CodPost;
            }
            else
            {
                Cp_VendedorTextBox.Text = v.Domicilio.CodPost;
            }
        }

		private void BindearDropDownLists()
		{
			AjustarCodigosDeReferenciaEnFooter();
			ImpuestosGlobales.BindearDropDownLists();
			PermisosExpo.BindearDropDownLists();
			DetalleLinea.BindearDropDownLists();
		}

		private void AjustarCodigosDeReferenciaEnFooter()
		{
			((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataValueField = "Codigo";
			((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataTextField = "Descr";
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!Punto_VentaTextBox.Text.Equals(string.Empty))
				{
					int auxPV;
					try
					{
						auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						switch (idtipo)
						{
							case "Comun":
                            case "RG2904":
								((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
								((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
								((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
								break;
							case "BFiscal":
								((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
								((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
								((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
								break;
							case "Export":
								((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
								((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
								((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
								break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la l�gica de la aplicaci�n (" + idtipo + ")");
						}
					}
					catch
					{
						((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
						((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
						((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
					}
				}
				else
				{
					((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
					((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
					((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
				}
			}
			else
			{
				((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
				((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
				((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
			}
			((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataBind();
		}

		protected void GenerarButton_Click(object sender, EventArgs e)
		{
			if (((Button)sender).ID == "DescargarButton" && CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</script>");
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
				}
			}
			else
			{
				try
				{
					FeaEntidades.InterFacturas.lote_comprobantes lote = GenerarLote();

					System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					sb.Append(lote.cabecera_lote.cuit_vendedor);
					sb.Append("-");
					sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
					sb.Append("-");
					sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
					sb.Append("-");
					sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
					sb.Append(".xml");

					System.IO.MemoryStream m = new System.IO.MemoryStream();
					System.IO.StreamWriter sw = new System.IO.StreamWriter(m);
					sw.Flush();
					System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
					x.Serialize(writerdememoria, lote);
					m.Seek(0, System.IO.SeekOrigin.Begin);


					string smtpXAmb = System.Configuration.ConfigurationManager.AppSettings["Ambiente"].ToString();
					System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();

					try
					{
						RegistrarActividad(lote, sb, smtpClient, smtpXAmb, m);
					}
					catch
					{
					}

					if (((Button)sender).ID == "DescargarButton")
					{
						//Descarga directa del XML
						System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sb.ToString()), System.IO.FileMode.Create);
						m.WriteTo(fs);
						fs.Close();
						Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + sb.ToString(), false);
					}
					else
					{
						//Envio por mail del XML
						System.Net.Mail.MailMessage mail;
						if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
						{
							mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
								((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email,
								"Ced-eFact-Env�o autom�tico archivo XML:" + sb.ToString()
								, string.Empty);
						}
						else
						{
							mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
								Email_VendedorTextBox.Text,
								"Ced-eFact-Env�o autom�tico archivo XML:" + sb.ToString()
								, string.Empty);
						}
						System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
						contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
						contentType.Name = sb.ToString();
						System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m, contentType);
						mail.Attachments.Add(attachment);
						mail.BodyEncoding = System.Text.Encoding.UTF8;
						mail.Body = Mails.Body.AgregarBody();
						smtpClient.Host = "localhost";
						if (smtpXAmb.Equals("DESA"))
						{
							string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
							if (MailServidorSmtp != "")
							{
								string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
								string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
								smtpClient.Host = MailServidorSmtp;
								if (MailCredencialesUsr != "")
								{
									smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
								}
								smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
							}
						}
						smtpClient.Send(mail);
					}
					m.Close();

					if (!smtpXAmb.Equals("DESA"))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente');window.open('https://srv1.interfacturas.com.ar/cfeWeb/faces/login/identificacion.jsp/', '_blank');</script>");
					}
					else
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente');</script>");
					}
				}
				catch (Exception ex)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al generar el archivo.\\n " + ex.Message + "');</script>");
				}
			}
		}


		protected void referenciasGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			referenciasGridView.EditIndex = -1;
			referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();
		}
		
		protected void referenciasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Addreferencias"))
			{
				try
				{
					FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					string auxCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue.ToString();
					string auxDescrCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
					if (!auxCodRef.Equals(string.Empty))
					{
						r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
						r.descripcioncodigo_de_referencia = auxDescrCodRef;
					}
					else
					{
						throw new Exception("Referencia no agregada porque el c�digo de referencia no puede estar vac�o");
					}
					string auxDatoRef = ((TextBox)referenciasGridView.FooterRow.FindControl("txtdato_de_referencia")).Text;
					if (auxDatoRef.Contains("?"))
					{
						throw new Exception("Referencia no agregada porque el n�mero de referencia no respeta el formato para exportaci�n");
					}
					else
					{
						r.dato_de_referencia = auxDatoRef;
					}
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Add(r);
					//Me fijo si elimino la fila autom�tica
					System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
					if (refs[0].codigo_de_referencia == 0)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Remove(refs[0]);
					}

					//Saco de edici�n la fila que est�n modificando
					if (!referenciasGridView.EditIndex.Equals(-1))
					{
						referenciasGridView.EditIndex = -1;
					}

					referenciasGridView.DataSource = ViewState["referencias"];
					referenciasGridView.DataBind();
					BindearDropDownLists();
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
				}
			}
		}
		
		protected void referenciasGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				e.ExceptionHandled = true;
			}
		}
		
		protected void referenciasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				refs.Remove(r);
				if (refs.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.informacion_comprobanteReferencias nuevo = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					refs.Add(nuevo);
				}
				referenciasGridView.EditIndex = -1;
				referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}
		
		protected void referenciasGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			referenciasGridView.EditIndex = e.NewEditIndex;

			referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();

			AjustarCodigoReferenciaEnEdicion(sender, e);

			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].codigo_de_referencia.ToString());
				li.Selected = true;
			}
			catch
			{
			}
		}

		private void AjustarCodigoReferenciaEnEdicion(object sender, GridViewEditEventArgs e)
		{
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataValueField = "Codigo";
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataTextField = "Descr";
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!Punto_VentaTextBox.Text.Equals(string.Empty))
				{
					int auxPV;
					try
					{
						auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						switch (idtipo)
						{
							case "Comun":
                            case "RG2904":
								((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
								((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
								((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
								break;
							case "BFiscal":
								((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
								((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
								((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
								break;
							case "Export":
								((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
								((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
								((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
								break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la l�gica de la aplicaci�n (" + idtipo + ")");
						}
					}
					catch
					{
						((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
						((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
						((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
					}
				}
				else
				{
					((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
					((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
					((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
				}
			}
			else
			{
				((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
				((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
				((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
			}
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
		}
		
		protected void referenciasGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
				e.ExceptionHandled = true;
			}
		}
		
		protected void referenciasGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				string auxCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedValue.ToString();
				string auxDescrCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedItem.Text;
				if (!auxCodRef.Equals(string.Empty))
				{
					r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
					r.descripcioncodigo_de_referencia = auxDescrCodRef;
				}
				else
				{
					throw new Exception("Referencia no actualizada porque el c�digo de referencia no puede estar vac�o");
				}
				string auxDatoRef = ((TextBox)referenciasGridView.Rows[e.RowIndex].FindControl("txtdato_de_referencia")).Text;
				if (auxDatoRef.Contains("?"))
				{
					throw new Exception("Referencia no actualizada porque el n�mero de referencia no respeta el formato para exportaci�n");
				}
				else
				{
					r.dato_de_referencia = auxDatoRef;
				}

				referenciasGridView.EditIndex = -1;
				referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
			}
		}

		protected void FileUploadButton_Click(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</script>");
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
				}
			}
			else
			{
				FeaEntidades.InterFacturas.lote_comprobantes lc=new FeaEntidades.InterFacturas.lote_comprobantes();
				if (XMLFileUpload.HasFile)
				{
					try
					{
						System.IO.MemoryStream ms = new System.IO.MemoryStream(XMLFileUpload.FileBytes);
						ms.Seek(0, System.IO.SeekOrigin.Begin);

						try
						{
							System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
							lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
							CompletarUI(lc, e);
							ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo');</script>");
						}
						catch (InvalidOperationException)
						{
							try
							{
								LeerFormatoDetalleIBK(e, lc, ms);
							}
							catch (InvalidOperationException)
							{
								LeerFormatoLoteIBK(e, lc, ms);
							}
						}
					}
					catch
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('El archivo no cumple con el esquema de Interfacturas');</script>");
					}
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Debe seleccionar un archivo');</script>");
				}
			}
		}

		private void LeerFormatoDetalleIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
		{
			//Formato detalle_factura IBK
			ms.Seek(0, System.IO.SeekOrigin.Begin);
			FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
			c = (FeaEntidades.InterFacturas.comprobante)x.Deserialize(ms);
			FeaEntidades.InterFacturas.comprobante[] cArray = new FeaEntidades.InterFacturas.comprobante[1];
			cArray[0] = c;
			lc.comprobante = cArray;
			CompletarUI(lc, e);
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo de formato detalle_factura.xml');</script>");
		}

		private void LeerFormatoLoteIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
		{
			try
			{
				//Formato Lote IBK
				ms.Seek(0, System.IO.SeekOrigin.Begin);
				FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response clr = new FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response();
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(clr.GetType());
				clr = (FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response)x.Deserialize(ms);
				lc = clr.consulta_lote_response.lote_comprobantes;
				CompletarUI(lc, e);
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo de formato Lote IBK');</script>");
			}
			catch
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('El archivo no cumple con el esquema de Interfacturas');</script>");
			}
		}

		private void CompletarUI(FeaEntidades.InterFacturas.lote_comprobantes lc, EventArgs e)
		{
			//Cabecera
			CompletarCabecera(lc);

			//Comprobante
			CompletarComprobante(lc);

			//Exportacion
			CompletarExportacion(lc);

			//Referencias
			CompletarReferencias(lc);

			PermisosExpo.CompletarPermisos(lc);

			//Comprador
			CompletarComprador(lc);

			//Vendedor
			CompletarVendedor(lc);

			//Detalle
			DetalleLinea.CompletarDetalles(lc);

			//Descuentos globales
			DescuentosGlobales.Completar(lc);

			//impuestos globales
			ImpuestosGlobales.Completar(lc);

			ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;

			//Resumen
			CompletarResumen(lc);

			Observaciones_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.observaciones);
			if (!lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Tipo_de_cambioLabel.Visible = true;
				Tipo_de_cambioTextBox.Visible = true;
				Tipo_de_cambioRequiredFieldValidator.Enabled = true;
				Tipo_de_cambioRegularExpressionValidator.Enabled = true;
			}
			else
			{
				Tipo_de_cambioLabel.Visible = false;
				Tipo_de_cambioTextBox.Visible = false;
				Tipo_de_cambioTextBox.Text = null;
				Tipo_de_cambioRequiredFieldValidator.Enabled = false;
				Tipo_de_cambioRegularExpressionValidator.Enabled = false;
			}
			//CAE
			CompletarCAE(lc);

			BindearDropDownLists();
		}

		private void CompletarCAE(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			CAETextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.cae;
			FechaCAEObtencionDatePickerWebUserControl.CalendarDateString = lc.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae;
			FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString = lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae;
			ResultadoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.resultado;
			MotivoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.motivo;
		}

		private void CompletarComprobante(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
			FechaEmisionDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
			FechaVencimientoDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
			FechaServDesdeDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
			FechaServHastaDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
			Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
			IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
			CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));
			CodigoConceptoDropDownList.SelectedIndex = CodigoConceptoDropDownList.Items.IndexOf(CodigoConceptoDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_concepto)));
		}

		private void CompletarCabecera(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			try
			{
				Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
				Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
				Punto_VentaTextBox.Text = Convert.ToString(lc.cabecera_lote.punto_de_venta);
				int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
				ViewState["PuntoVenta"] = auxPV;
				DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
				AjustarCamposXPtaVentaChanged(Punto_VentaTextBox.Text);
				AjustarCamposXVersion(lc);
			}
			catch (NullReferenceException)//detalle_factura.xml
			{
				Punto_VentaTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
				int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
				ViewState["PuntoVenta"] = auxPV;
				DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
				AjustarCamposXPtaVentaChanged(Punto_VentaTextBox.Text);
				AjustarCamposXVersion(lc);
				Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
			}
		}

		private void CompletarExportacion(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion != null)
			{
				PaisDestinoExpDropDownList.SelectedIndex = PaisDestinoExpDropDownList.Items.IndexOf(PaisDestinoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante)));
				IncotermsDropDownList.SelectedIndex = IncotermsDropDownList.Items.IndexOf(IncotermsDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.incoterms)));
				TipoExpDropDownList.SelectedIndex = TipoExpDropDownList.Items.IndexOf(TipoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion)));
			}
			else
			{
				PaisDestinoExpDropDownList.SelectedIndex = -1;
				IncotermsDropDownList.SelectedIndex = -1;
				TipoExpDropDownList.SelectedIndex = -1;
			}
			if (lc.comprobante[0].extensiones != null)
			{
				if (lc.comprobante[0].extensiones.extensiones_camara_facturas != null)
				{
					IdiomaDropDownList.SelectedIndex = IdiomaDropDownList.Items.IndexOf(IdiomaDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].extensiones.extensiones_camara_facturas.id_idioma)));
				}
				else
				{
					IdiomaDropDownList.SelectedIndex = -1;
				}
				if (lc.comprobante[0].extensiones.extensiones_datos_comerciales != null && lc.comprobante[0].extensiones.extensiones_datos_comerciales != "")
				{
					//Compatibilidad con archivos xml viejos. Verificar si la descripcion est� en Hexa.
					if (lc.comprobante[0].extensiones.extensiones_datos_comerciales.Substring(0, 1) == "%")
					{
						CedWebRN.Comprobante cDC = new CedWebRN.Comprobante();
						DatosComerciales.Texto = cDC.HexToString(lc.comprobante[0].extensiones.extensiones_datos_comerciales).Replace("<br>", System.Environment.NewLine);
					}
					else
					{
						DatosComerciales.Texto = lc.comprobante[0].extensiones.extensiones_datos_comerciales.Replace("<br>", System.Environment.NewLine);
					}
				}
				else
				{
					DatosComerciales.Texto = string.Empty;
				}
			}
			else
			{
				IdiomaDropDownList.SelectedIndex = -1;
				DatosComerciales.Texto = string.Empty;
			}
		}

		private void CompletarReferencias(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
			if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
			{
				foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
					//Se busca la descripci�n a trav�s del c�digo.
					try
					{
						if (r != null)
						{
							string descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
							((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue = r.codigo_de_referencia.ToString();
							descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
							r.descripcioncodigo_de_referencia = descrcodigo;
							referencias.Add(r);
						}
					}
					catch
					//Referencia no valida
					{
					}
				}
			}
			if (referencias.Count.Equals(0))
			{
				referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
			}
			referenciasGridView.DataSource = referencias;
			referenciasGridView.DataBind();
			ViewState["referencias"] = referencias;
		}


		private void CompletarVendedor(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			if (lc.comprobante[0].cabecera.informacion_vendedor.razon_social != null)
			{
				Razon_Social_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.razon_social);
			}
			Localidad_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.localidad);
			if (lc.comprobante[0].cabecera.informacion_vendedor.GLN != 0)
			{
				GLN_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.GLN);
			}
			Email_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.email);
			Cuit_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cuit);
			Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.provincia)));
			Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVA)));
			Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutos)));
			Cp_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cp);
			Contacto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.contacto);
			Telefono_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.telefono);
			Codigo_Interno_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.codigo_interno);
			NroIBVendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.nro_ingresos_brutos);
			InicioDeActividadesVendedorDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.inicio_de_actividades);
			Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle);
			Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_numero);
			Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_piso);
			Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_depto);
			Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_sector);
			Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_torre);
			Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_manzana);
		}

		private void CompletarComprador(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			if (lc.comprobante[0].cabecera.informacion_comprador.GLN != 0)
			{
				GLN_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.GLN);
			}
			Codigo_Interno_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_interno);
			if (!lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.Equals(70))
			{
				Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
				Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
				Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio);
			}
			else
			{
				Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
				Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
				Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio)));
			}
			Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Codigo_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Codigo_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio)));
			Denominacion_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.denominacion);
			Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle);
			Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
			Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
			Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
			Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
			Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
			Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
			Localidad_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.localidad);
			Cp_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.cp);
			Contacto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.contacto);
			Email_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.email);
			Telefono_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.telefono);
			InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.inicio_de_actividades);
			Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.provincia)));
			Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.condicion_IVA)));
			if (lc.comprobante[0].extensiones != null)
			{
				if (lc.comprobante[0].extensiones.extensiones_destinatarios != null)
				{
					EmailAvisoVisualizacionTextBox.Text = lc.comprobante[0].extensiones.extensiones_destinatarios.email;
				}
			}
		}

		private void CompletarResumen(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].resumen.codigo_moneda)));
			Tipo_de_cambioTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.tipo_de_cambio);
			if (lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_factura);
				if (lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_nacionales);
				}
				else
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_municipales);
				}
				else
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_internos);
				}
				else
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified.Equals(true))
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_ingresos_brutos);
				}
				else
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
				}
			}
			else
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura);
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
				}
				else
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales);
				}
				else
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos);
				}
				else
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified.Equals(true))
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos);
				}
				else
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
				}
			}
		}

		private void CompletarUI(org.dyndns.cedweb.consulta.ConsultarResult lc, EventArgs e)
		{
			//Cabecera
			Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
			Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
			Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
			Punto_VentaTextBox.Text = Convert.ToString(lc.cabecera_lote.punto_de_venta);
			int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
			ViewState["PuntoVenta"] = auxPV;
			DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
			AjustarCamposXPtaVentaChanged(Punto_VentaTextBox.Text);
			AjustarCamposXVersion(lc);
			//Comprobante
			Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
			FechaEmisionDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
			FechaVencimientoDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
			FechaServDesdeDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
			FechaServHastaDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
			Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
			IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
			CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));
			
			//Exportacion
			if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion != null)
			{
				PaisDestinoExpDropDownList.SelectedIndex = PaisDestinoExpDropDownList.Items.IndexOf(PaisDestinoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante)));
				IncotermsDropDownList.SelectedIndex = IncotermsDropDownList.Items.IndexOf(IncotermsDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.incoterms)));
				TipoExpDropDownList.SelectedIndex = TipoExpDropDownList.Items.IndexOf(TipoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion)));
			}
			else
			{
				PaisDestinoExpDropDownList.SelectedIndex = -1;
				IncotermsDropDownList.SelectedIndex = -1;
				TipoExpDropDownList.SelectedIndex = -1;
			}
			if (lc.comprobante[0].extensiones != null)
			{
				if (lc.comprobante[0].extensiones.extensiones_camara_facturas != null)
				{
					IdiomaDropDownList.SelectedIndex = IdiomaDropDownList.Items.IndexOf(IdiomaDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].extensiones.extensiones_camara_facturas.id_idioma)));
				}
				else
				{
					IdiomaDropDownList.SelectedIndex = -1;
				}
				if (lc.comprobante[0].extensiones.extensiones_datos_comerciales != null && lc.comprobante[0].extensiones.extensiones_datos_comerciales != "")
				{
					//Compatibilidad con archivos xml viejos. Verificar si la descripcion est� en Hexa.
					if (lc.comprobante[0].extensiones.extensiones_datos_comerciales.Substring(0, 1) == "%")
					{
						CedWebRN.Comprobante cDC = new CedWebRN.Comprobante();
						DatosComerciales.Texto = cDC.HexToString(lc.comprobante[0].extensiones.extensiones_datos_comerciales).Replace("<br>", System.Environment.NewLine);
					}
					else
					{
						DatosComerciales.Texto = lc.comprobante[0].extensiones.extensiones_datos_comerciales.Replace("<br>", System.Environment.NewLine);
					}
				}
			}
			else
			{
				IdiomaDropDownList.SelectedIndex = -1;
			}

			//Referencias
			if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
			{
				referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
				foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteCabeceraInformacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
					//Se busca la descripci�n a trav�s del c�digo.
					if (r != null)
					{
						FeaEntidades.InterFacturas.informacion_comprobanteReferencias icr = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
						icr.codigo_de_referencia = r.codigo_de_referencia;
						icr.dato_de_referencia = Convert.ToString(r.dato_de_referencia);
						icr.descripcioncodigo_de_referencia = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista()
							.Find(
							delegate(FeaEntidades.CodigosReferencia.CodigoReferencia c)
							{
								return c.Codigo == Convert.ToString(icr.codigo_de_referencia);
							}
							).Descr;
						referencias.Add(icr);
					}
				}
				if (referencias.Count.Equals(0))
				{
					referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
				}
				referenciasGridView.DataSource = referencias;
				referenciasGridView.DataBind();
				ViewState["referencias"] = referencias;
			}
			//Comprador
			if (lc.comprobante[0].cabecera.informacion_comprador.GLN != 0)
			{
				GLN_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.GLN);
			}
			Codigo_Interno_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_interno);
			Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio);
			Denominacion_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.denominacion);
			Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle);
			Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
			Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
			Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
			Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
			Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
			Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
			Localidad_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.localidad);
			Cp_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.cp);
			Contacto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.contacto);
			Email_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.email);
			Telefono_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.telefono);
			InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.inicio_de_actividades);
			Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.provincia)));
			Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.condicion_IVA)));
			//Vendedor
			if (lc.comprobante[0].cabecera.informacion_vendedor.razon_social != null)
			{
				Razon_Social_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.razon_social);
			}
			Localidad_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.localidad);
			if (lc.comprobante[0].cabecera.informacion_vendedor.GLN != 0)
			{
				GLN_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.GLN);
			}
			Email_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.email);
			Cuit_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cuit);
			Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.provincia)));
			Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVA)));
			Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutos)));
			Cp_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cp);
			Contacto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.contacto);
			Telefono_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.telefono);
			Codigo_Interno_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.codigo_interno);
			NroIBVendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.nro_ingresos_brutos);
			InicioDeActividadesVendedorDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.inicio_de_actividades);
			Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle);
			Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_numero);
			Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_piso);
			Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_depto);
			Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_sector);
			Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_torre);
			Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_manzana);
			
			//Detalle
			DetalleLinea.CompletarDetallesWS(lc);
			
			//Descuentos globales
			DescuentosGlobales.CompletarDetallesWS(lc);

			//impuestos globales
			ImpuestosGlobales.CompletarWS(lc);

			ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;
			//Resumen
			MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].resumen.codigo_moneda)));
			Tipo_de_cambioTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.tipo_de_cambio);
			if (lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_factura);
				Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_nacionales);
				Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_municipales);
				Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_internos);
				Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_ingresos_brutos);
			}
			else
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura);
				Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
				Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales);
				Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos);
				Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos);
			}
			Observaciones_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.observaciones);
			if (!lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Tipo_de_cambioLabel.Visible = true;
				Tipo_de_cambioTextBox.Visible = true;
				Tipo_de_cambioRequiredFieldValidator.Enabled = true;
				Tipo_de_cambioRegularExpressionValidator.Enabled = true;
			}
			else
			{
				Tipo_de_cambioLabel.Visible = false;
				Tipo_de_cambioTextBox.Visible = false;
				Tipo_de_cambioTextBox.Text = null;
				Tipo_de_cambioRequiredFieldValidator.Enabled = false;
				Tipo_de_cambioRegularExpressionValidator.Enabled = false;
			}
			//CAE
			CAETextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.cae;
			FechaCAEObtencionDatePickerWebUserControl.CalendarDateString = lc.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae;
			FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString = lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae;
			ResultadoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.resultado;
			MotivoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.motivo;

			BindearDropDownLists();
		}
		
		protected void MonedaComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				Response.Redirect("~/Inicio.aspx");
			}
		}
		
		protected void CompradorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			AjustarComprador();
		}
		
		private void AjustarComprador()
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
			}
			else
			{
				CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
				comprador.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
				comprador.RazonSocial = Convert.ToString(CompradorDropDownList.SelectedValue);
				try
				{
					CedWebRN.Comprador.Leer(comprador, (CedWebEntidades.Sesion)Session["Sesion"]);
					Denominacion_CompradorTextBox.Text = comprador.RazonSocial;
					Domicilio_Calle_CompradorTextBox.Text = comprador.Domicilio.Calle;
					Domicilio_Numero_CompradorTextBox.Text = comprador.Domicilio.Nro;
					Domicilio_Piso_CompradorTextBox.Text = comprador.Domicilio.Piso;
					Domicilio_Depto_CompradorTextBox.Text = comprador.Domicilio.Depto;
					Domicilio_Sector_CompradorTextBox.Text = comprador.Domicilio.Sector;
					Domicilio_Torre_CompradorTextBox.Text = comprador.Domicilio.Torre;
					Domicilio_Manzana_CompradorTextBox.Text = comprador.Domicilio.Manzana;
					Localidad_CompradorTextBox.Text = comprador.Domicilio.Localidad;
					Provincia_CompradorDropDownList.SelectedValue = comprador.Domicilio.Provincia.Id;
					Cp_CompradorTextBox.Text = comprador.Domicilio.CodPost;
					Contacto_CompradorTextBox.Text = comprador.NombreContacto;
					Email_CompradorTextBox.Text = comprador.EmailContacto;
					Telefono_CompradorTextBox.Text = Convert.ToString(comprador.TelefonoContacto);

					Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
					if (!comprador.IdTipoDoc.Equals(70))
					{
						Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
						Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
						Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(comprador.NroDoc);
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
					}
					else
					{
						Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
						Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
						Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
						Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
						Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
						Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
						Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprador.NroDoc)));
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
					}
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
					Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.IdTipoDoc);

					Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIVA);
					//NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
					//CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
					string auxGLN = Convert.ToString(comprador.GLN);
					if (!auxGLN.Equals("0"))
					{
						GLN_CompradorTextBox.Text = auxGLN;
					}
					else
					{
						GLN_CompradorTextBox.Text = string.Empty;
					}
					Codigo_Interno_CompradorTextBox.Text = comprador.CodigoInterno;
					if (!comprador.FechaInicioActividades.Equals(new DateTime(9999, 12, 31)))
					{
						InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDate = comprador.FechaInicioActividades;
					}
					else
					{
						InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString = string.Empty;
					}
					EmailAvisoVisualizacionTextBox.Text = comprador.EmailAvisoVisualizacion;
					PasswordAvisoVisualizacionTextBox.Text = comprador.PasswordAvisoVisualizacion;
				}
				catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
				{
					try
					{
						int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
						if (!idtipo.Equals("Export"))
						{
							Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
							Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
							Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
							Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
						}
						else
						{
							Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
							Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
							Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
							Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
							Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
							Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
							Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
							Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
						}
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
						Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
					}
					catch
					{
						Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
						Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
						Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
					}
					ResetearComprador();
				}
			}
		}

		private void ResetearComprador()
		{
			Denominacion_CompradorTextBox.Text = string.Empty;
			Domicilio_Calle_CompradorTextBox.Text = string.Empty;
			Domicilio_Numero_CompradorTextBox.Text = string.Empty;
			Domicilio_Piso_CompradorTextBox.Text = string.Empty;
			Domicilio_Depto_CompradorTextBox.Text = string.Empty;
			Domicilio_Sector_CompradorTextBox.Text = string.Empty;
			Domicilio_Torre_CompradorTextBox.Text = string.Empty;
			Domicilio_Manzana_CompradorTextBox.Text = string.Empty;
			Localidad_CompradorTextBox.Text = string.Empty;
			Provincia_CompradorDropDownList.SelectedValue = Convert.ToString(0);
			Cp_CompradorTextBox.Text = string.Empty;
			Contacto_CompradorTextBox.Text = string.Empty;
			Email_CompradorTextBox.Text = string.Empty;
			Telefono_CompradorTextBox.Text = string.Empty;
			Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(0);
			//NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
			//CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
			GLN_CompradorTextBox.Text = string.Empty;
			Codigo_Interno_CompradorTextBox.Text = string.Empty;
			((TextBox)InicioDeActividadesCompradorDatePickerWebUserControl.FindControl("txt_Date")).Text = string.Empty;
			EmailAvisoVisualizacionTextBox.Text = string.Empty;
			PasswordAvisoVisualizacionTextBox.Text = string.Empty;
		}
		
		protected void CalcularTotalesButton_Click(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</SCRIPT>", false);
				}
				else
				{
					ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.');</SCRIPT>", false);			
				}
			}
			else
			{
				try
				{
					//Proceso DETALLE
					Importe_Total_Neto_Gravado_ResumenTextBox.Text = "0";
					Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = "0";
					Importe_Operaciones_Exentas_ResumenTextBox.Text = "0";
					Impuesto_Liq_ResumenTextBox.Text = "0";
					Impuesto_Liq_Rni_ResumenTextBox.Text = "0";
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = "0";
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = "0";
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = "0";
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = "0";
					Importe_Total_Factura_ResumenTextBox.Text = "0";
					double totalGravado = 0;
					double totalNoGravado = 0;
					double totalIVA = 0;
					double total_Operaciones_Exentas = 0;

					DetalleLinea.CalcularTotalesLineas(ref totalGravado, ref totalNoGravado, ref totalIVA, ref total_Operaciones_Exentas);
					//Proceso IMPUESTOS GLOBALES
					double total_Impuestos_Nacionales;
					double total_Impuestos_Internos;
					double total_Ingresos_Brutos;
					double total_Impuestos_Municipales;

                    ImpuestosGlobales.EliminarImpuestosIVA();
                    CalcularImpuestos(out total_Impuestos_Nacionales, out total_Impuestos_Internos, out total_Ingresos_Brutos, out total_Impuestos_Municipales);
					
					//Asigno totales
					if (!Punto_VentaTextBox.Text.Equals(string.Empty))
					{
						int auxPV;
						try
						{
							auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
							string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
							{
								return pv.Id == auxPV;
							}).IdTipo;
							double total;
							switch (idtipo)
							{
                                case "RG2904":
                                    CalcularTotalesExceptoExportacion(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas);
                                    ImpuestosGlobales.EliminarImpuestosIVA();
                                    ImpuestosGlobales.AgregarImpuestosIVA(DetalleLinea.Lineas);
                                    //Descontar descuentos a impuestos
                                    DescuentosGlobales.RestarDescuentosAImpuestosGlobales(ImpuestosGlobales.Lista);
                                    ImpuestosGlobales.Actualizar(ImpuestosGlobales.Lista);
                                    break;
                                case "Comun":
									CalcularTotalesExceptoExportacion(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas);
									if (CodigoConceptoDropDownList.Visible)
									{
										ImpuestosGlobales.EliminarImpuestosIVA();
										ImpuestosGlobales.AgregarImpuestosIVA(DetalleLinea.Lineas);
										//Descontar descuentos a impuestos
										DescuentosGlobales.RestarDescuentosAImpuestosGlobales(ImpuestosGlobales.Lista);
										ImpuestosGlobales.Actualizar(ImpuestosGlobales.Lista);
									}
									break;
								case "BFiscal":
									CalcularTotalesExceptoExportacion(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas);
									break;
								case "Export":
									total = totalGravado + totalNoGravado + totalIVA;
									Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
									break;
                                default:
                                    throw new Exception("Tipo de punto de venta no contemplado en la l�gica de la aplicaci�n (" + idtipo + ")");
							}
						}
						catch
						{
							throw new Exception("Para sugerir totales debe definir previamente el tipo del punto de venta(BF-Exp-Com�n) en la configuraci�n de datos del vendedor");
						}
					}
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al calcular los totales.\\n " + ex.Message + "');</SCRIPT>", false);
				}
				finally
				{
					//Restauro totales no informados
					if (Importe_Total_Impuestos_Municipales_ResumenTextBox.Text == "0")
						Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = String.Empty;
					if (Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text == "0")
						Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = String.Empty;
					if (Importe_Total_Ingresos_Brutos_ResumenTextBox.Text == "0")
						Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = String.Empty;
					if (Importe_Total_Impuestos_Internos_ResumenTextBox.Text == "0")
						Importe_Total_Impuestos_Internos_ResumenTextBox.Text = String.Empty;
				}
			}
		}

		private void CalcularTotalesExceptoExportacion(ref double totalGravado, ref double totalNoGravado, double totalIVA, double total_Impuestos_Nacionales, double total_Impuestos_Internos, double total_Ingresos_Brutos, double total_Impuestos_Municipales, double total_Operaciones_Exentas)
		{
			double total;
			DescuentosGlobales.AplicarDtosATotales(ref totalGravado, ref totalNoGravado, ref total_Operaciones_Exentas, ref totalIVA);
			Importe_Total_Neto_Gravado_ResumenTextBox.Text = totalGravado.ToString();
			Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = totalNoGravado.ToString();
			Importe_Operaciones_Exentas_ResumenTextBox.Text = total_Operaciones_Exentas.ToString();
			if (Condicion_IVA_CompradorDropDownList.SelectedValue == (new FeaEntidades.CondicionesIVA.ResponsableNoInscripto()).Codigo.ToString() || Condicion_IVA_CompradorDropDownList.SelectedValue == (new FeaEntidades.CondicionesIVA.SujetoNoCategorizado()).Codigo.ToString())
			{
				Impuesto_Liq_Rni_ResumenTextBox.Text = totalIVA.ToString();
			}
			else
			{
				Impuesto_Liq_ResumenTextBox.Text = totalIVA.ToString();
			}
			Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = total_Impuestos_Municipales.ToString();
			Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = total_Impuestos_Nacionales.ToString();
			Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = total_Ingresos_Brutos.ToString();
			Importe_Total_Impuestos_Internos_ResumenTextBox.Text = total_Impuestos_Internos.ToString();
            total = totalGravado + totalNoGravado + totalIVA + total_Impuestos_Nacionales + total_Impuestos_Internos + total_Ingresos_Brutos + total_Impuestos_Municipales + total_Operaciones_Exentas;
			Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
		}

		

		private void CalcularImpuestos(out double total_Impuestos_Nacionales, out double total_Impuestos_Internos, out double total_Ingresos_Brutos, out double total_Impuestos_Municipales)
		{
			total_Impuestos_Nacionales = 0;
			total_Impuestos_Internos = 0;
			total_Ingresos_Brutos = 0;
			total_Impuestos_Municipales = 0;
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ImpuestosGlobales.Lista;
			for (int i = 0; i < listadeimpuestos.Count; i++)
			{
				if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
				{
					switch (listadeimpuestos[i].codigo_impuesto)
					{
						case 1://IVA
							if (!CodigoConceptoDropDownList.Visible)
							{
								total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							}
							break;
						case 3://Otros
							total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							break;
						case 4://Nacionales
							total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							break;
						case 2://Internos
							total_Impuestos_Internos += listadeimpuestos[i].importe_impuesto;
							break;
						case 5://IB
							total_Ingresos_Brutos += listadeimpuestos[i].importe_impuesto;
							break;
						case 6://Municipales
							total_Impuestos_Municipales += listadeimpuestos[i].importe_impuesto;
							break;
						default:
							throw new Exception("C�digo del impuesto inv�lido");
					}
				}
			}
		}

		protected void Punto_VentaTextBox_TextChanged(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				try
				{
					AjustarCamposXPtaVentaChanged(((TextBox)sender).Text);
					int auxPV = Convert.ToInt32(((TextBox)sender).Text);
					if (ViewState["PuntoVenta"] != null)
					{
						int auxViewState = Convert.ToInt32(ViewState["PuntoVenta"]);
						try
						{
							string idtipoAnterior = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
							{
								return pv.Id == auxViewState;
							}).IdTipo;
							string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
							{
								return pv.Id == auxPV;
							}).IdTipo;
							if (!idtipo.Equals(idtipoAnterior))
							{
								ResetearGrillas();
							}
						}
						catch (System.NullReferenceException)
						{
							ResetearGrillas();
						}
					}
					ViewState["PuntoVenta"] = auxPV;
					DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
				}
				catch
				{
					ResetearGrillas();
				}
			}
			else
			{
				DetalleLinea.PuntoDeVenta = ((TextBox)sender).Text;
				try
				{
					ViewState["PuntoVenta"] = Convert.ToInt32(((TextBox)sender).Text);
				}
				catch
				{
				}
			}
		}
		
		private void ResetearGrillas()
		{
			DetalleLinea.ResetearGrillas();

			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
			FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
			referencias.Add(referencia);
			referenciasGridView.DataSource = referencias;
			ViewState["referencias"] = referencias;
			referenciasGridView.DataBind();

			BindearDropDownLists();

			PermisosExpo.ResetearGrillas();
			DetalleLinea.ResetearGrillas();

			ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Se han eliminado art�culos, referencias y permisos de exportaci�n por haber cambiado el tipo de punto de venta');</SCRIPT>", false);
		}

		
		private void AjustarCamposXPtaVentaChanged(string PuntoDeVenta)
		{
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!PuntoDeVenta.Equals(string.Empty))
				{
					int auxPV;
					AjustarCodigosDeReferenciaEnFooter();
					try
					{
						auxPV = Convert.ToInt32(PuntoDeVenta);
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
						Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
						Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
						Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
						System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores = new System.Collections.Generic.List<CedWebEntidades.Comprador>();
						switch (idtipo)
						{
							case "Comun":
                            	listacompradores = AjustarCamposXPtaVentaComun(listacompradores);
								break;
                            case "RG2904":
                                listacompradores = AjustarCamposXPtaVentaRG2904(listacompradores, Tipo_De_ComprobanteDropDownList.SelectedValue);
                                break;
							case "BFiscal":
								listacompradores = AjustarCamposXPtaVentaBonoFiscal(listacompradores);
								break;
							case "Export":
								listacompradores = AjustarCamposXPtaVentaExport(listacompradores);
								break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la l�gica de la aplicaci�n (" + idtipo + ")");
						}
						Tipo_De_ComprobanteDropDownList.DataBind();
						Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
						TipoPtoVentaLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).DescrTipo;
						if (listacompradores.Count > 0)
						{
							CompradorDropDownList.Visible = true;
							CompradorDropDownList.DataValueField = "RazonSocial";
							CompradorDropDownList.DataTextField = "RazonSocial";
							CompradorDropDownList.DataSource = listacompradores;
							CompradorDropDownList.DataBind();
							CompradorDropDownList.SelectedIndex = 0;
							AjustarComprador();
						}
						else
						{
							CompradorDropDownList.Visible = false;
							CompradorDropDownList.DataSource = null;
						}
                        CedWebEntidades.Vendedor v = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor;
                        CedWebEntidades.PuntoDeVenta ptoventa = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
                        {
                            return pv.Id == auxPV;
                        });
                        CompletarDomicilioVendedor(ptoventa, v);
					}
					catch
					{
						AjustarCamposXPtaVentaIndefinido();
					}
				}
				else
				{
					AjustarCamposXPtaVentaIndefinido();
					ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Debe definir el punto de venta');</SCRIPT>", false);
				}
			}
		}

		private System.Collections.Generic.List<CedWebEntidades.Comprador> AjustarCamposXPtaVentaExport(System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores)
		{
			Presta_ServCheckBox.Checked = false;
			Presta_ServCheckBox.Enabled = false;
			Presta_ServCheckBox.Visible = true;
			Presta_ServLabel.Visible = true;
			Version0RadioButton.Visible = false;
			Version1RadioButton.Visible = false;
			CodigoConceptoLabel.Visible = false;
			CodigoConceptoDropDownList.Visible = false;
			FechaServDesdeDatePickerWebUserControl.CalendarDateString = string.Empty;
			FechaServDesdeDatePickerWebUserControl.Visible = false;
			FechaInicioServLabel.Visible = false;
			FechaHstServLabel.Visible = false;
			FechaServHastaDatePickerWebUserControl.CalendarDateString = string.Empty;
			FechaServHastaDatePickerWebUserControl.Visible = false;
			Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaParaExportaciones();

			Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
			Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
			Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
			Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
			Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
			Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
			Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Nro_Doc_Identificatorio_CompradorTextBox.Text));
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
			docCompradorRequiredFieldValidator.Enabled = false;
			listaDocCompradorRequiredFieldValidator.Enabled = true;
			docCompradorRequiredFieldValidator.DataBind();
			listaDocCompradorRequiredFieldValidator.DataBind();

			((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
			listacompradores = CedWebRN.Comprador.ListaExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
			TipoExpDropDownList.Enabled = true;
			PaisDestinoExpDropDownList.Enabled = true;
			IdiomaDropDownList.Enabled = true;
			IncotermsDropDownList.Enabled = true;
            CodigoOperacionDropDownList.Visible = true;
            CodigoOperacionLabel.Visible = true;
			return listacompradores;
		}

		private System.Collections.Generic.List<CedWebEntidades.Comprador> AjustarCamposXPtaVentaBonoFiscal(System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores)
		{
			Presta_ServCheckBox.Checked = false;
			Presta_ServCheckBox.Enabled = false;
			Presta_ServCheckBox.Visible = true;
			Presta_ServLabel.Visible = true;
			Version0RadioButton.Visible = false;
			Version1RadioButton.Visible = false;
			CodigoConceptoLabel.Visible = false;
			CodigoConceptoDropDownList.Visible = false;
			FechaServDesdeDatePickerWebUserControl.CalendarDateString = string.Empty;
			FechaServDesdeDatePickerWebUserControl.Visible = false;
			FechaInicioServLabel.Visible = false;
			FechaHstServLabel.Visible = false;
			FechaServHastaDatePickerWebUserControl.CalendarDateString = string.Empty;
			FechaServHastaDatePickerWebUserControl.Visible = false;
			Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaParaBienesDeCapital();
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
			Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
			Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
			docCompradorRequiredFieldValidator.Enabled = true;
			listaDocCompradorRequiredFieldValidator.Enabled = false;
			docCompradorRequiredFieldValidator.DataBind();
			listaDocCompradorRequiredFieldValidator.DataBind();
			((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
			listacompradores = CedWebRN.Comprador.ListaSinExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
			TipoExpDropDownList.SelectedIndex = -1;
			TipoExpDropDownList.Enabled = false;
			PaisDestinoExpDropDownList.SelectedIndex = -1;
			PaisDestinoExpDropDownList.Enabled = false;
			IdiomaDropDownList.SelectedIndex = -1;
			IdiomaDropDownList.Enabled = false;
			IncotermsDropDownList.SelectedIndex = -1;
			IncotermsDropDownList.Enabled = false;
            CodigoOperacionDropDownList.Visible = true;
            CodigoOperacionLabel.Visible = true;
			return listacompradores;
		}

		private System.Collections.Generic.List<CedWebEntidades.Comprador> AjustarCamposXPtaVentaComun(System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores)
		{
			Presta_ServCheckBox.Enabled = true;
            HacerVisiblesV0V1();
            listacompradores = AjustarCamposXPtaVtaComunYRG2904(listacompradores);
			return listacompradores;
		}

        private System.Collections.Generic.List<CedWebEntidades.Comprador> AjustarCamposXPtaVentaRG2904(System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores, string tipoComprobante)
        {
            Presta_ServCheckBox.Enabled = false;
            Presta_ServCheckBox.Checked = false;
            Presta_ServCheckBox.Visible = false;
            Presta_ServLabel.Visible = false;
            Version0RadioButton.Visible = false;
            Version1RadioButton.Visible = false;
            listacompradores = AjustarCamposXPtaVtaComunYRG2904(listacompradores);
            AjustarCodigoOperacionEn2904(tipoComprobante);
            return listacompradores;
        }

        private void AjustarCodigoOperacionEn2904(string valor)
        {
            if (valor.Equals("2") || valor.Equals("3"))
            {
                CodigoOperacionDropDownList.Visible = false;
                CodigoOperacionLabel.Visible = false;
            }
            else
            {
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        private System.Collections.Generic.List<CedWebEntidades.Comprador> AjustarCamposXPtaVtaComunYRG2904(System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores)
        {
            AjustarPrestaServxVersiones();

            FechaServDesdeDatePickerWebUserControl.Visible = true;
            FechaInicioServLabel.Visible = true;
            FechaHstServLabel.Visible = true;
            FechaServHastaDatePickerWebUserControl.Visible = true;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
            docCompradorRequiredFieldValidator.Enabled = true;
            listaDocCompradorRequiredFieldValidator.Enabled = false;
            docCompradorRequiredFieldValidator.DataBind();
            listaDocCompradorRequiredFieldValidator.DataBind();
            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
            listacompradores = CedWebRN.Comprador.ListaSinExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
            TipoExpDropDownList.SelectedIndex = -1;
            TipoExpDropDownList.Enabled = false;
            PaisDestinoExpDropDownList.SelectedIndex = -1;
            PaisDestinoExpDropDownList.Enabled = false;
            IdiomaDropDownList.SelectedIndex = -1;
            IdiomaDropDownList.Enabled = false;
            IncotermsDropDownList.SelectedIndex = -1;
            IncotermsDropDownList.Enabled = false;
            CodigoOperacionDropDownList.Visible = true;
            CodigoOperacionLabel.Visible = true;
            return listacompradores;
        }

        private void HacerVisiblesV0V1()
        {
            Version0RadioButton.Visible = true;
            Version0RadioButton.Checked = false;
            Version1RadioButton.Visible = true;
            Version1RadioButton.Checked = true;
        }

		private void AjustarCamposXPtaVentaIndefinido()
		{
			TipoPtoVentaLabel.Text = "No definido";
			Presta_ServCheckBox.Enabled = true;
			Presta_ServCheckBox.Visible = true;
			Presta_ServLabel.Visible = true;
			Version0RadioButton.Visible = false;
			Version1RadioButton.Visible = false;
			CodigoConceptoLabel.Visible = false;
			CodigoConceptoDropDownList.Visible = false;
			FechaServDesdeDatePickerWebUserControl.Visible = true;
			FechaInicioServLabel.Visible = true;
			FechaHstServLabel.Visible = true;
			FechaServHastaDatePickerWebUserControl.Visible = true;
			Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();
			Tipo_De_ComprobanteDropDownList.DataBind();
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
			Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
			Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
			docCompradorRequiredFieldValidator.Enabled = true;
			listaDocCompradorRequiredFieldValidator.Enabled = false;
			docCompradorRequiredFieldValidator.DataBind();
			listaDocCompradorRequiredFieldValidator.DataBind();
			((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
			System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
			if (listacompradores.Count > 0)
			{
				CompradorDropDownList.Visible = true;
				CompradorDropDownList.DataValueField = "RazonSocial";
				CompradorDropDownList.DataTextField = "RazonSocial";
				CompradorDropDownList.DataSource = listacompradores;
				CompradorDropDownList.DataBind();
				CompradorDropDownList.SelectedIndex = 0;
				AjustarComprador();
			}
			else
			{
				CompradorDropDownList.Visible = false;
				CompradorDropDownList.DataSource = null;
			}
			TipoExpDropDownList.Enabled = true;
			PaisDestinoExpDropDownList.Enabled = true;
			IdiomaDropDownList.Enabled = true;
			IncotermsDropDownList.Enabled = true;
            CedWebEntidades.Vendedor v = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor;
			CompletarDomicilioVendedor(v);
            CodigoOperacionDropDownList.Visible = true;
            CodigoOperacionLabel.Visible = true;
		}
		
		protected void EnviarIBKButton_Click(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</script>");
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
				}
			}
			else
			{
				try
				{
					CedWebEntidades.Cuenta cta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta;
					if (cta.NroSerieCertificado.Equals(string.Empty))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('A�n no disponemos de su certificado digital.');</script>");
						return;
					}
					try
					{
						string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(cta.NroSerieCertificado, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();

						org.dyndns.cedweb.envio.EnvioIBK edyndns = new org.dyndns.cedweb.envio.EnvioIBK();

						org.dyndns.cedweb.envio.lc lcIBK = new org.dyndns.cedweb.envio.lc();

						FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote();
						lcIBK = Conversor.Entidad2IBK(lcFea);
						//CedWebRN.Comprobante cc = new CedWebRN.Comprobante();
						//cc.EnviarIBK(lcFea, certificado);
						string respuesta = edyndns.EnviarIBK(lcIBK, certificado);

						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + respuesta + "')</script>");
					}
					catch (System.Web.Services.Protocols.SoapException soapEx)
					{
						try
						{
							XmlDocument doc = new XmlDocument();
							doc.LoadXml(soapEx.Detail.OuterXml);
							XmlNamespaceManager nsManager = new
								XmlNamespaceManager(doc.NameTable);
							nsManager.AddNamespace("errorNS",
								"http://www.cedeira.com.ar/webservices");
							XmlNode Node =
								doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
							string errorNumber =
								Node.SelectSingleNode("errorNS:ErrorNumber",
								nsManager).InnerText;
							string errorMessage =
								Node.SelectSingleNode("errorNS:ErrorMessage",
								nsManager).InnerText;
							string errorSource =
								Node.SelectSingleNode("errorNS:ErrorSource",
								nsManager).InnerText;
							ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + " : " + errorMessage.Replace("\r", "").Replace("\n", "") + "');</script>");
						}
						catch (Exception)
						{
							throw soapEx;
						}
					}

				}
				catch (Exception ex)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a Interfacturas.\\n " + ex.Message + "');</script>");
				}
			}
		}

		private FeaEntidades.InterFacturas.lote_comprobantes GenerarLote()
		{
			FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
			FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
			FeaEntidades.InterFacturas.cabecera_lote cab = new FeaEntidades.InterFacturas.cabecera_lote();
			cab.cantidad_reg = 1;
			cab.cuit_canal = Convert.ToInt64(Cuit_CanalTextBox.Text);
			cab.cuit_vendedor = Convert.ToInt64(Cuit_VendedorTextBox.Text);
			cab.id_lote = Convert.ToInt64(Id_LoteTextbox.Text);

			GenerarPrestaServicio(cab);

			cab.punto_de_venta = Convert.ToInt32(Punto_VentaTextBox.Text);
			lote.cabecera_lote = cab;

			FeaEntidades.InterFacturas.cabecera compcab = new FeaEntidades.InterFacturas.cabecera();

			FeaEntidades.InterFacturas.informacion_comprador infcompra = new FeaEntidades.InterFacturas.informacion_comprador();

			if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Tipo_de_cambioLabel.Visible = true;
				Tipo_de_cambioTextBox.Visible = true;
				Tipo_de_cambioRequiredFieldValidator.Enabled = true;
				Tipo_de_cambioRegularExpressionValidator.Enabled = true;
			}
			else
			{
				Tipo_de_cambioLabel.Visible = false;
				Tipo_de_cambioTextBox.Visible = false;
				Tipo_de_cambioTextBox.Text = null;
				Tipo_de_cambioRequiredFieldValidator.Enabled = false;
				Tipo_de_cambioRegularExpressionValidator.Enabled = false;
			}

			GenerarInfoComprador(compcab, infcompra);

			FeaEntidades.InterFacturas.informacion_comprobante infcomprob = GenerarInfoComprobante();

			GenerarReferencias(infcomprob);

			GenerarInfoExportacion(comp, infcomprob);

			GenerarInfoExtensionesComerciales(comp);

			GenerarInfoExtensionesCamaraFacturas(comp);

			GenerarInfoExtensionesDestinatarios(comp);

			compcab.informacion_comprobante = infcomprob;

			GenerarInfoVendedor(compcab);

			comp.cabecera = compcab;

			int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
			string idtipo;
            try
            {
                idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
                        {
                            return pv.Id == auxPV;
                        }).IdTipo;
            }
            catch (NullReferenceException)
            {
                idtipo = "Comun";
            }
			FeaEntidades.InterFacturas.detalle det = DetalleLinea.GenerarDetalles(MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text, idtipo, Tipo_De_ComprobanteDropDownList.SelectedValue);

			det.comentarios = ComentariosTextBox.Text;

			comp.detalle = det;

			FeaEntidades.InterFacturas.resumen r = new FeaEntidades.InterFacturas.resumen();
			if (Tipo_de_cambioTextBox.Text != string.Empty)
			{
				r.tipo_de_cambio = Convert.ToDouble(Tipo_de_cambioTextBox.Text);
			}
			else
			{
				r.tipo_de_cambio = 1;
			}
			r.codigo_moneda = MonedaComprobanteDropDownList.SelectedValue;

			if (MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			//Moneda local
			{
				GenerarImportesMonedaLocal(r);
			}
			else
			//Moneda extranjera
			{
				GenerarImportesMonedaExtranjera(r);
			}

			r.observaciones = Observaciones_ResumenTextBox.Text;

			comp.resumen = r;

			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ImpuestosGlobales.Lista;
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
			    auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
			    try
			    {
			        idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
			        {
			            return pv.Id == auxPV;
			        }).IdTipo;
			        if (idtipo.Equals("Export"))
			        {
			            if (listadeimpuestos[0].importe_impuesto != 0 || listadeimpuestos.Count > 1)
			            {
			                ImpuestosGlobales.Focus();
			                throw new Exception("Los impuestos globales no se deben informar para exportaci�n");
			            }
			        }
			        else
			        {
			            ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text );
			        }
			    }
			    catch (System.NullReferenceException)
			    {
					ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
			    }
			}
			else
			{
				ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
			}

			DescuentosGlobales.GenerarResumen(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);

			lote.comprobante[0] = comp;
			return lote;
		}

		private void GenerarPrestaServicio(FeaEntidades.InterFacturas.cabecera_lote cab)
		{
			cab.presta_servSpecified = true;
			//para exportaci�n no se debe informar
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
                    if (idtipo.Equals("Export") || idtipo.Equals("RG2904"))
					{
						cab.presta_servSpecified = false;
					}
					else if (idtipo.Equals("Comun"))
					{
						GenerarV0oV1(cab);
					}
					else
					{
						cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
					}
				}
				catch (System.NullReferenceException)
				{
					cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
				}
			}
			else
			{
				cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
			}
		}

		private void GenerarV0oV1(FeaEntidades.InterFacturas.cabecera_lote cab)
		{
			if (Version0RadioButton.Checked)
			{
				cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
			}
			else
			{
				cab.presta_servSpecified = false;
				
			}
		}

		private void GenerarInfoExtensionesDestinatarios(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!EmailAvisoVisualizacionTextBox.Text.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				comp.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
				comp.extensiones.extensiones_destinatarios.email=EmailAvisoVisualizacionTextBox.Text;
			}
		}

		private void GenerarInfoExtensionesComerciales(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!DatosComerciales.Texto.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				CedWebRN.Comprobante c = new CedWebRN.Comprobante();
				string textoSinSaltoDeLinea = DatosComerciales.Texto.Replace(System.Environment.NewLine, "<br>");
				comp.extensiones.extensiones_datos_comerciales = c.ConvertToHex(textoSinSaltoDeLinea);
			}
		}

		private void GenerarInfoExtensionesCamaraFacturas(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!PasswordAvisoVisualizacionTextBox.Text.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				if (comp.extensiones.extensiones_camara_facturas == null)
				{
					comp.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
				}
				comp.extensiones.extensiones_camara_facturas.clave_de_vinculacion = Cedeira.SV.Fun.CreateMD5Hash(PasswordAvisoVisualizacionTextBox.Text);
				comp.extensiones.extensiones_camara_facturasSpecified = true;
			}
		}

		private FeaEntidades.InterFacturas.informacion_comprobante GenerarInfoComprobante()
		{
			FeaEntidades.InterFacturas.informacion_comprobante infcomprob = new FeaEntidades.InterFacturas.informacion_comprobante();
			infcomprob.tipo_de_comprobante = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue);
			infcomprob.numero_comprobante = Convert.ToInt64(Numero_ComprobanteTextBox.Text);
			infcomprob.punto_de_venta = Convert.ToInt32(Punto_VentaTextBox.Text);
			infcomprob.fecha_emision = FechaEmisionDatePickerWebUserControl.CalendarDateString;
			GenerarInfoFechaVto(infcomprob);
			infcomprob.fecha_serv_desde = FechaServDesdeDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_serv_hasta = FechaServHastaDatePickerWebUserControl.CalendarDateString;

			GenerarIVAComputable(infcomprob);

			if (!Condicion_De_PagoTextBox.Text.Equals(string.Empty))
			{
				infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
				infcomprob.condicion_de_pagoSpecified = true;
			}
			else
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							throw new Exception("La condici�n de pago es obligatoria para exportaci�n");
						}
						else
						{
							infcomprob.condicion_de_pago = string.Empty;
							infcomprob.condicion_de_pagoSpecified = false;
						}
					}
					catch (System.NullReferenceException)
					{
						infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
						infcomprob.condicion_de_pagoSpecified = false;
					}
				}
				else
				{
					infcomprob.condicion_de_pago = string.Empty;
					infcomprob.condicion_de_pagoSpecified = false;
				}
			}

			GenerarCodigoOperacion(infcomprob);
			GenerarCodigoConcepto(infcomprob);
			infcomprob.cae = CAETextBox.Text;
			if (!CAETextBox.Text.Equals(string.Empty))
			{
				infcomprob.caeSpecified = true;
			}
			infcomprob.fecha_obtencion_cae = FechaCAEObtencionDatePickerWebUserControl.CalendarDateString;
			if (!FechaCAEObtencionDatePickerWebUserControl.CalendarDateString.ToString().Equals(string.Empty))
			{
				infcomprob.fecha_obtencion_caeSpecified = true;
			}
			infcomprob.fecha_vencimiento_cae = FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString;
			if (!FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString.Equals(string.Empty))
			{
				infcomprob.fecha_vencimiento_caeSpecified = true;
			}
			if (!ResultadoTextBox.Text.Equals(string.Empty))
			{
				infcomprob.resultado = ResultadoTextBox.Text;
			}
			if (!MotivoTextBox.Text.Equals(string.Empty))
			{
				infcomprob.motivo = MotivoTextBox.Text;
			}
			return infcomprob;
		}

		private void GenerarInfoFechaVto(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			if (!FechaVencimientoDatePickerWebUserControl.CalendarDateString.Equals(string.Empty))
			{
				infcomprob.fecha_vencimiento = FechaVencimientoDatePickerWebUserControl.CalendarDateString;
			}
			else
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (!idtipo.Equals("Export"))
						{
							throw new Exception("La fecha de vencimiento es obligatoria");
						}
					}
					catch (System.NullReferenceException)
					{
						throw new Exception("La fecha de vencimiento es obligatoria");
					}
				}
				else
				{
					throw new Exception("La fecha de vencimiento es obligatoria");
				}
			}
		}

		private void GenerarIVAComputable(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			//No se tiene que informar para exportaci�n
			if (!IVAcomputableDropDownList.SelectedValue.Equals(string.Empty))
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							IVAcomputableDropDownList.Focus();
							throw new Exception("El IVA computable no se debe informar para exportaci�n");
						}
						else
						{
							infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
						}
					}
					catch (System.NullReferenceException)
					{
						infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
					}
				}
				else
				{
					infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
				}
			}
		}

		private void GenerarCodigoOperacion(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			//No se tiene que informar para exportaci�n
            //El nodo no se debe informar para RG2904 (solo NC A y ND A)
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (!CodigoOperacionDropDownList.SelectedValue.Equals(string.Empty))
					{
                        if (idtipo.Equals("Export"))
                        {
                            CodigoOperacionDropDownList.Focus();
                            throw new Exception("El c�digo de operaci�n no se debe informar para exportaci�n");
                        }
                        else if (idtipo.Equals("RG2904") && (Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("2") || Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("3")))
                        {
                            infcomprob.codigo_operacion = string.Empty;
                            infcomprob.codigo_operacionSpecified = false;
                        }
                        else
                        {
                            infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                            infcomprob.codigo_operacionSpecified = true;
                        }
					}
                    else
                    {
                        if (!idtipo.Equals("Export"))
                        {
                            if (idtipo.Equals("RG2904") && (Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("2") || Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("3")))
                            {
                                infcomprob.codigo_operacion = string.Empty;
                                infcomprob.codigo_operacionSpecified = false;
                            }
                            else
                            {
                                infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                                infcomprob.codigo_operacionSpecified = true;
                            }
                        }
                       
                    }
				}
				catch (System.NullReferenceException)
				{
					infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                    infcomprob.codigo_operacionSpecified = true;
				}
			}
			else
			{
				infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                infcomprob.codigo_operacionSpecified = true;
			}
		}

		private void GenerarCodigoConcepto(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			//Se tiene que informar para versi�n 1 de punto com�n
			if (CodigoConceptoDropDownList.Visible)
			{
				infcomprob.codigo_concepto = Convert.ToInt32(CodigoConceptoDropDownList.SelectedValue);
				infcomprob.codigo_conceptoSpecified = true;
			}
			else
			{
				infcomprob.codigo_conceptoSpecified = false;
			}
		}


		private void GenerarReferencias(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> listareferencias = (System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"];
			for (int i = 0; i < listareferencias.Count; i++)
			{
				if (listareferencias[i].descripcioncodigo_de_referencia != null)
				{
					if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
					{
						int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
						try
						{
							string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
							{
								return pv.Id == auxPV;
							}).IdTipo;
							string tipoComp = Tipo_De_ComprobanteDropDownList.SelectedValue;
							if (idtipo.Equals("Export") && tipoComp.Equals("19"))
							{
								throw new Exception("Las referencias no se deben informar para facturas de exportaci�n(19). S�lo para notas de d�bito y/o cr�dito (20 y 21).");
							}
							else
							{
								GenerarReferencia(infcomprob, listareferencias, i);
							}
						}
						catch (System.NullReferenceException)
						{
							GenerarReferencia(infcomprob, listareferencias, i);
						}
					}
					else
					{
						GenerarReferencia(infcomprob, listareferencias, i);
					}
				}
			}
		}

		private static void GenerarReferencia(FeaEntidades.InterFacturas.informacion_comprobante infcomprob, System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> listareferencias, int i)
		{
			infcomprob.referencias[i] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
			infcomprob.referencias[i].codigo_de_referencia = Convert.ToInt32(listareferencias[i].codigo_de_referencia);
			infcomprob.referencias[i].descripcioncodigo_de_referencia = listareferencias[i].descripcioncodigo_de_referencia;
			infcomprob.referencias[i].dato_de_referencia = listareferencias[i].dato_de_referencia;
		}

		private void GenerarInfoExportacion(FeaEntidades.InterFacturas.comprobante comp, FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			FeaEntidades.InterFacturas.informacion_exportacion ie = new FeaEntidades.InterFacturas.informacion_exportacion();
			bool exportacion = false;
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					string tipoComp = Tipo_De_ComprobanteDropDownList.SelectedValue;
					string tipoExp = TipoExpDropDownList.SelectedValue;
					if (idtipo.Equals("Export"))
					{
						if (tipoComp.Equals("19"))
						{
							if (PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
							{
								throw new Exception("El pa�s destino de exportaci�n es obligatorio");
							}
							if (IncotermsDropDownList.SelectedValue.Equals(string.Empty))
							{
								throw new Exception("Incoterms es obligatorio");
							}
							if (tipoExp.Equals("0"))
							{
								throw new Exception("El tipo de exportaci�n es obligatorio");
							}
							if (IdiomaDropDownList.SelectedValue.Equals("0"))
							{
								throw new Exception("El idioma es obligatorio");
							}
						}
						else //NC y ND
						{
							if (PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
							{
								throw new Exception("El pa�s destino de exportaci�n es obligatorio");
							}
							if (tipoExp.Equals("0"))
							{
								throw new Exception("El tipo de exportaci�n es obligatorio");
							}
							if (IdiomaDropDownList.SelectedValue.Equals("0"))
							{
								throw new Exception("El idioma es obligatorio");
							}
						}
					}
				}
				catch (System.NullReferenceException)
				{
				}
			}

			if (!PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
			{
				ie.destino_comprobante = Convert.ToInt32(PaisDestinoExpDropDownList.SelectedValue);
				exportacion = true;
			}
			if (!IncotermsDropDownList.SelectedValue.Equals(string.Empty))
			{
				ie.incoterms = IncotermsDropDownList.SelectedValue;
				exportacion = true;
			}
			if (!TipoExpDropDownList.SelectedValue.Equals("0"))
			{
				ie.tipo_exportacion = Convert.ToInt32(TipoExpDropDownList.SelectedValue);
				exportacion = true;
			}
			if (!IdiomaDropDownList.SelectedValue.Equals("0"))
			{
				comp.extensionesSpecified = true;
				comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				comp.extensiones.extensiones_camara_facturasSpecified = true;
				comp.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
				comp.extensiones.extensiones_camara_facturas.id_idioma = IdiomaDropDownList.SelectedValue;
				exportacion = true;
			}

			GenerarInfoPermisosExportacion(ie, infcomprob);

			if (exportacion)
			{
				infcomprob.informacion_exportacion = ie;
			}
		}

		private void GenerarInfoPermisosExportacion(FeaEntidades.InterFacturas.informacion_exportacion ie, FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			if (infcomprob.tipo_de_comprobante.Equals(19) && ie.tipo_exportacion.Equals(1))
			{
				if (this.PermisosExpo.HayPermisos)
				{
					ie.permiso_existente = "S";
					ie.permisos = new FeaEntidades.InterFacturas.permisos[5];
					for (int i = 0; i < this.PermisosExpo.PermisosExportacion.Count; i++)
					{
						ie.permisos[i] = new FeaEntidades.InterFacturas.permisos();
						ie.permisos[i].descripcion_destino_mercaderia = this.PermisosExpo.PermisosExportacion[i].descripcion_destino_mercaderia;
						ie.permisos[i].destino_mercaderia = this.PermisosExpo.PermisosExportacion[i].destino_mercaderia;
						ie.permisos[i].id_permiso = this.PermisosExpo.PermisosExportacion[i].id_permiso;
					}
				}
				else
				{
					ie.permiso_existente = "N";
				}
			}
			else
			{
				if (this.PermisosExpo.HayPermisos)
				{
					throw new Exception("No se deben informar permisos de exportaci�n para este tipo de comprobante");
				}
			}
		}


		private void GenerarInfoVendedor(FeaEntidades.InterFacturas.cabecera compcab)
		{
			FeaEntidades.InterFacturas.informacion_vendedor infovend = new FeaEntidades.InterFacturas.informacion_vendedor();
			if (!GLN_VendedorTextBox.Text.Equals(string.Empty))
			{
				infovend.GLN = Convert.ToInt64(GLN_VendedorTextBox.Text);
				infovend.GLNSpecified = true;
			}
			infovend.codigo_interno = Codigo_Interno_VendedorTextBox.Text;
			infovend.razon_social = Razon_Social_VendedorTextBox.Text;
			infovend.cuit = Convert.ToInt64(Cuit_VendedorTextBox.Text);
			int auxCondIVAVend = Convert.ToInt32(Condicion_IVA_VendedorDropDownList.SelectedValue);
			if (!auxCondIVAVend.Equals(0))
			{
				infovend.condicion_IVASpecified = true;
				infovend.condicion_IVA = auxCondIVAVend;
			}

			try
			{
				infovend.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue);
				infovend.nro_ingresos_brutos = NroIBVendedorTextBox.Text;
			}
			catch
			{

			}
			finally
			{
				if (infovend.condicion_ingresos_brutos != 0)
				{
					infovend.condicion_ingresos_brutosSpecified = true;
				}
				else
				{
					infovend.nro_ingresos_brutos = null;
				}
			}
			infovend.inicio_de_actividades = InicioDeActividadesVendedorDatePickerWebUserControl.CalendarDateString;
			infovend.contacto = Contacto_VendedorTextBox.Text;
			infovend.domicilio_calle = Domicilio_Calle_VendedorTextBox.Text;
			infovend.domicilio_numero = Domicilio_Numero_VendedorTextBox.Text;
			infovend.domicilio_piso = Domicilio_Piso_VendedorTextBox.Text;
			infovend.domicilio_depto = Domicilio_Depto_VendedorTextBox.Text;
			infovend.domicilio_sector = Domicilio_Sector_VendedorTextBox.Text;
			infovend.domicilio_torre = Domicilio_Torre_VendedorTextBox.Text;
			infovend.domicilio_manzana = Domicilio_Manzana_VendedorTextBox.Text;
			infovend.localidad = Localidad_VendedorTextBox.Text;
			string auxCodProvVend = Convert.ToString(Provincia_VendedorDropDownList.SelectedValue);
			if (!auxCodProvVend.Equals("0"))
			{
				infovend.provincia = auxCodProvVend;
			}
			infovend.cp = Cp_VendedorTextBox.Text;
			infovend.email = Email_VendedorTextBox.Text;
			infovend.telefono = Telefono_VendedorTextBox.Text;
			compcab.informacion_vendedor = infovend;
		}

		private void GenerarInfoComprador(FeaEntidades.InterFacturas.cabecera compcab, FeaEntidades.InterFacturas.informacion_comprador infcompra)
		{
			if (!GLN_CompradorTextBox.Text.Equals(string.Empty))
			{
				infcompra.GLN = Convert.ToInt64(GLN_CompradorTextBox.Text);
				infcompra.GLNSpecified = true;
			}
			infcompra.codigo_interno = Codigo_Interno_CompradorTextBox.Text;
			try
			{
				infcompra.codigo_doc_identificatorio = Convert.ToInt32(Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
			}
			catch (FormatException)
			{
				throw new Exception("Tipo de documento del comprador no informado");
			}
			
			if (Nro_Doc_Identificatorio_CompradorTextBox.Visible)
			{
				try
				{
					infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorTextBox.Text);
				}
				catch (FormatException)
				{
					throw new Exception("Nro documento del comprador no informado");
				}
			}
			else
			{
				try
				{
					infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
				}
				catch (FormatException)
				{
					throw new Exception("Nro documento del comprador para exportaci�n no informado");
				}
			}
			infcompra.denominacion = Denominacion_CompradorTextBox.Text;
			int auxCondIVACompra = Convert.ToInt32(Condicion_IVA_CompradorDropDownList.SelectedValue);
			if (!auxCondIVACompra.Equals(0))
			{
				infcompra.condicion_IVASpecified = true;
				infcompra.condicion_IVA = auxCondIVACompra;
			}
			//infcompra.condicion_ingresos_brutosSpecified = true;
			//infcompra.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_CompradorDropDownList.SelectedValue);
			//infcompra.nro_ingresos_brutos
			infcompra.inicio_de_actividades = InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString;
			infcompra.contacto = Contacto_CompradorTextBox.Text;

			//obligatorio para exportaci�n
			if (Domicilio_Calle_CompradorTextBox.Text.Equals(string.Empty))
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							Domicilio_Calle_CompradorTextBox.Focus();
							throw new Exception("La calle del domicilio del comprador es obligatoria para exportaci�n");
						}
						else
						{
							infcompra.domicilio_calle = string.Empty;
						}
					}
					catch (System.NullReferenceException)
					{
						infcompra.domicilio_calle = string.Empty;
					}
				}
				else
				{
					infcompra.domicilio_calle = string.Empty;
				}
			}
			else
			{
				infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
			}

			//obligatorio para exportaci�n
			if (Domicilio_Numero_CompradorTextBox.Text.Equals(string.Empty))
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							Domicilio_Numero_CompradorTextBox.Focus();
							throw new Exception("El n�mero de la calle del domicilio del comprador es obligatorio para exportaci�n");
						}
						else
						{
							infcompra.domicilio_numero = string.Empty;
						}
					}
					catch (System.NullReferenceException)
					{
						infcompra.domicilio_numero = string.Empty;
					}
				}
				else
				{
					infcompra.domicilio_numero = string.Empty;
				}
			}
			else
			{
				infcompra.domicilio_numero = Domicilio_Numero_CompradorTextBox.Text;
			}
			infcompra.domicilio_piso = Domicilio_Piso_CompradorTextBox.Text;
			infcompra.domicilio_depto = Domicilio_Depto_CompradorTextBox.Text;
			infcompra.domicilio_sector = Domicilio_Sector_CompradorTextBox.Text;
			infcompra.domicilio_torre = Domicilio_Torre_CompradorTextBox.Text;
			infcompra.domicilio_manzana = Domicilio_Manzana_CompradorTextBox.Text;
			infcompra.localidad = Localidad_CompradorTextBox.Text;
			string auxCodProvCompra = Convert.ToString(Provincia_CompradorDropDownList.SelectedValue);
			//No se tiene que informar para exportaci�n
			if (!auxCodProvCompra.Equals("0"))
			{
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							if (!PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
							{
								Provincia_CompradorDropDownList.Focus();
								throw new Exception("La provincia del domicilio del comprador no se debe informar para exportaci�n");
							}
							else
							{
								infcompra.provincia = auxCodProvCompra;
							}
						}
						else
						{
							infcompra.provincia = auxCodProvCompra;
						}
					}
					catch (System.NullReferenceException)
					{
						infcompra.provincia = auxCodProvCompra;
					}
				}
				else
				{
					infcompra.provincia = auxCodProvCompra;
				}
			}
			infcompra.cp = Cp_CompradorTextBox.Text;
			infcompra.email = Email_CompradorTextBox.Text;
			infcompra.telefono = Telefono_CompradorTextBox.Text;

			

			compcab.informacion_comprador = infcompra;
		}

		private void GenerarImportesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r)
		{
			double tipodecambio = Convert.ToDouble(Tipo_de_cambioTextBox.Text);

			FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();

			GenerarImporteTotalNetoGravadoExtranjera(r, tipodecambio, rimo);
			GenerarImporteTotalConceptoNoGravadoExtranjera(r, tipodecambio, rimo);
			GenerarImporteOperacionesExentasExtranjera(r, tipodecambio, rimo);
			GenerarImpuestoLiqExtranjera(r, tipodecambio, rimo);
			GenerarImpuestoLiqRNIExtranjera(r, tipodecambio, rimo);

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_nacionalesSpecified = false;
							rimo.importe_total_impuestos_nacionalesSpecified = false;
							throw new Exception("El importe total de impuestos nacionales en moneda extranjera no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
				}
			}
			catch (FormatException)
			{
			}

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_ingresos_brutosSpecified = false;
							rimo.importe_total_ingresos_brutosSpecified = false;
							throw new Exception("El importe total de ingresos brutos en moneda extranjera no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
					}
				}
				else
				{
					GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
				}
			}
			catch (FormatException)
			{
			}


			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_municipalesSpecified = false;
							rimo.importe_total_impuestos_municipalesSpecified = false;
							throw new Exception("El importe total de impuestos municipales en moneda extranjera no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
				}
			}
			catch (FormatException)
			{
			}

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_internosSpecified = false;
							rimo.importe_total_impuestos_internosSpecified = false;
							throw new Exception("El importe total de impuestos internos en moneda extranjera no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
				}
			}
			catch (FormatException)
			{
			}

			r.importe_total_factura = 0;
			rimo.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);

			r.importes_moneda_origen = rimo;
		}

		private void GenerarImpuestoLiqRNIExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Impuesto_Liq_Rni_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El Impuesto liquidado a RNI o percepci�n a no categorizados debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.impuesto_liq_rni = 0;
						rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
					rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
				}
			}
			else
			{
				r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
			}
		}

		private void GenerarImpuestoLiqExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Impuesto_Liq_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El IVA Responsable inscripto debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.impuesto_liq = 0;
						rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
					rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
				}
			}
			else
			{
				r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteOperacionesExentasExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe de operaciones exentas debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_operaciones_exentas = 0;
						rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
					rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalConceptoNoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe total de conceptos que no integren el precio neto gravado debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_total_concepto_no_gravado = 0;
						rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
					rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalNetoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe total neto gravado debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_total_neto_gravado = 0;
						rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
					rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalImpuestosInternosMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			r.importe_total_impuestos_internos = 0;
			rimo.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
			if (rimo.importe_total_impuestos_internos != 0)
			{
				r.importe_total_impuestos_internosSpecified = true;
				rimo.importe_total_impuestos_internosSpecified = true;
			}
		}

		private void GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			r.importe_total_impuestos_municipales = 0;
			rimo.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
			if (rimo.importe_total_impuestos_municipales != 0)
			{
				r.importe_total_impuestos_municipalesSpecified = true;
				rimo.importe_total_impuestos_municipalesSpecified = true;
			}
		}

		private void GenerarImporteTotalIngresosBrutosMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			r.importe_total_ingresos_brutos = 0;
			rimo.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
			if (rimo.importe_total_ingresos_brutos != 0)
			{
				r.importe_total_ingresos_brutosSpecified = true;
				rimo.importe_total_ingresos_brutosSpecified = true;
			}
		}

		private void GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			r.importe_total_impuestos_nacionales = 0;
			rimo.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
			if (rimo.importe_total_impuestos_nacionales != 0)
			{
				r.importe_total_impuestos_nacionalesSpecified = true;
				rimo.importe_total_impuestos_nacionalesSpecified = true;
			}
		}

		private void GenerarImportesMonedaLocal(FeaEntidades.InterFacturas.resumen r)
		{
			GenerarImporteTotalNetoGravado(r);
			GenerarImporteTotalConceptoNoGravado(r);
			GenerarImporteOperacionesExentas(r);
			GenerarImpuestoLiq(r);
			GenerarImpuestoLiqRNI(r);

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_nacionalesSpecified = false;
							throw new Exception("El importe total de impuestos nacionales no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);
				}
			}
			catch (FormatException)
			{
			}

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_ingresos_brutosSpecified = false;
							throw new Exception("El importe total de ingresos brutos no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalIngresosBrutos(r);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalIngresosBrutos(r);
					}
				}
				else
				{
					GenerarImporteTotalIngresosBrutos(r);
				}
			}
			catch (FormatException)
			{
			}

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_municipalesSpecified = false;
							throw new Exception("El importe total de impuestos municipales no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosMunicipales(r);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosMunicipales(r);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosMunicipales(r);
				}
			}
			catch (FormatException)
			{
			}

			//para exportaci�n no se debe informar
			try
			{
				double importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
				if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
				{
					int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
					try
					{
						string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
						{
							return pv.Id == auxPV;
						}).IdTipo;
						if (idtipo.Equals("Export"))
						{
							r.importe_total_impuestos_internosSpecified = false;
							throw new Exception("El importe total de impuestos internos no se debe informar para exportaci�n");
						}
						else
						{
							GenerarImporteTotalImpuestosInternos(r);
						}
					}
					catch (System.NullReferenceException)
					{
						GenerarImporteTotalImpuestosInternos(r);
					}
				}
				else
				{
					GenerarImporteTotalImpuestosInternos(r);
				}
			}
			catch (FormatException)
			{
			}

			r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
		}

		private void GenerarImpuestoLiqRNI(FeaEntidades.InterFacturas.resumen r)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Impuesto_Liq_Rni_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El Impuesto liquidado a RNI o percepci�n a no categorizados debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
				}
			}
			else
			{
				r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
			}
		}

		private void GenerarImpuestoLiq(FeaEntidades.InterFacturas.resumen r)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Impuesto_Liq_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El IVA Responsable inscripto debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
				}
			}
			else
			{
				r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
			}

		}

		private void GenerarImporteOperacionesExentas(FeaEntidades.InterFacturas.resumen r)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe de operaciones exentas debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalConceptoNoGravado(FeaEntidades.InterFacturas.resumen r)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe total de conceptos que no integren el precio neto gravado debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalNetoGravado(FeaEntidades.InterFacturas.resumen r)
		{
			//para exportaci�n se debe informar en 0
			if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
				try
				{
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					if (idtipo.Equals("Export") && !Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals("0"))
					{
						throw new Exception("El importe total neto gravado debe informarse en 0 para exportaci�n.");
					}
					else
					{
						r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
					}
				}
				catch (System.NullReferenceException)
				{
					r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
				}
			}
			else
			{
				r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalImpuestosInternos(FeaEntidades.InterFacturas.resumen r)
		{
			r.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
			if (r.importe_total_impuestos_internos != 0)
			{
				r.importe_total_impuestos_internosSpecified = true;
			}
		}

		private void GenerarImporteTotalImpuestosMunicipales(FeaEntidades.InterFacturas.resumen r)
		{
			r.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
			if (r.importe_total_impuestos_municipales != 0)
			{
				r.importe_total_impuestos_municipalesSpecified = true;
			}
		}

		private void GenerarImporteTotalIngresosBrutos(FeaEntidades.InterFacturas.resumen r)
		{
			r.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
			if (r.importe_total_ingresos_brutos != 0)
			{
				r.importe_total_ingresos_brutosSpecified = true;
			}
		}

		private static void GenerarImporteTotalImpuestosNacionales(FeaEntidades.InterFacturas.resumen r, double importe_total_impuestos_nacionales)
		{
			r.importe_total_impuestos_nacionales = importe_total_impuestos_nacionales;
			r.importe_total_impuestos_nacionalesSpecified = true;
		}

		protected void ConsultarLoteIBKButton_Click(object sender, EventArgs e)
		{
			using (FileStream fs = File.Open(Server.MapPath("~/Consultar.txt"), FileMode.Append, FileAccess.Write))
			{
				using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
				{
					sw.WriteLine("Consulta de:" + Cuit_VendedorTextBox.Text);
				}
			}
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</script>");
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
				}
			}
			else
			{
				try
				{
					if (Cuit_VendedorTextBox.Text.Equals(string.Empty))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el CUIT del vendedor');</script>");
						return;
					}
					if (Id_LoteTextbox.Text.Equals(string.Empty))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el nro de lote');</script>");
						return;
					}
					if (Punto_VentaTextBox.Text.Equals(string.Empty))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el punto de venta');</script>");
						return;
					}


					CedWebEntidades.Cuenta cta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta;

					if (cta.NroSerieCertificado.Equals(string.Empty))
					{
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('A�n no disponemos de su certificado digital.');</script>");
						return;
					}

					string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(cta.NroSerieCertificado, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();

					//Ir por WS
					org.dyndns.cedweb.consulta.ConsultaIBK clcdyndns = new org.dyndns.cedweb.consulta.ConsultaIBK();

					org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
					clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(Cuit_VendedorTextBox.Text), Convert.ToInt64(Id_LoteTextbox.Text), Convert.ToInt32(Punto_VentaTextBox.Text), certificado);

					CompletarUI(clcrdyndns, e);

				}
				catch (System.Web.Services.Protocols.SoapException soapEx)
				{
					try
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(soapEx.Detail.OuterXml);
						XmlNamespaceManager nsManager = new
							XmlNamespaceManager(doc.NameTable);
						nsManager.AddNamespace("errorNS",
							"http://www.cedeira.com.ar/webservices");
						XmlNode Node =
							doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
						string errorNumber =
							Node.SelectSingleNode("errorNS:ErrorNumber",
							nsManager).InnerText;
						string errorMessage =
							Node.SelectSingleNode("errorNS:ErrorMessage",
							nsManager).InnerText;
						string errorSource =
							Node.SelectSingleNode("errorNS:ErrorSource",
							nsManager).InnerText;
						ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + " : " + errorMessage.Replace("\r", "").Replace("\n", "") + "');</script>");
					}
					catch (Exception)
					{
						throw soapEx;
					}
				}
				catch (System.Security.Cryptography.CryptographicException ex)
				{
					using (FileStream fs = File.Open(Server.MapPath("~/ConsultarErrores.txt"), FileMode.Append, FileAccess.Write))
					{
						using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
						{
							sw.WriteLine("Consulta de:" + Cuit_VendedorTextBox.Text);
							sw.WriteLine(ex.Message);
							sw.WriteLine(ex.StackTrace);
							if (ex.InnerException != null)
							{
								sw.WriteLine(ex.InnerException.Message);
							}
						}
					}
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.Replace("\r", "").Replace("\n", "") + "');</script>");
				}
				catch (Exception ex)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al consultar a Interfacturas.\\n " + ex.Message.Replace("\n", "") + "');</script>");
				}
			}
		}

		protected void PDFButton_Click(object sender, EventArgs e)
		{
			if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
			{
				if (!MonedaComprobanteDropDownList.Enabled)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Cont�ctese con Cedeira Software Factory para acceder al servicio.');</script>");
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesi�n ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
				}
			}
			else
			{
				try
				{
					FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote();
					if (lcFea.comprobante[0].cabecera.informacion_comprobante.cae.Equals(string.Empty))
					{
						lcFea.comprobante[0].cabecera.informacion_comprobante.cae = " ";
					}
					lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
					lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
					CedWebRN.Comprobante cDC = new CedWebRN.Comprobante();
					foreach (FeaEntidades.InterFacturas.linea l in lcFea.comprobante[0].detalle.linea)
					{
						if (l != null)
						{
							l.descripcion = cDC.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
                            l.informacion_adicional = null;
						}
						else
						{
							break;
						}
					}
					if (lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == null)
					{
						lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = string.Empty;
					}
					if (lcFea.cabecera_lote.presta_servSpecified == false)
					{
						lcFea.cabecera_lote.presta_serv = 0;
						lcFea.cabecera_lote.presta_servSpecified = true;
					}
					if (lcFea.comprobante[0].extensiones != null && lcFea.comprobante[0].extensiones.extensiones_datos_comerciales != null && !lcFea.comprobante[0].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
					{
						string dc = cDC.HexToString(lcFea.comprobante[0].extensiones.extensiones_datos_comerciales);
						lcFea.comprobante[0].extensiones.extensiones_datos_comerciales = dc.Replace("<br>", System.Environment.NewLine);
					}
					else
					{
						lcFea.comprobante[0].extensiones = new FeaEntidades.InterFacturas.extensiones();
					}
					if (lcFea.comprobante[0].resumen.impuestos != null)
					{
						foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lcFea.comprobante[0].resumen.impuestos)
						{
							if (imp != null)
							{
								imp.codigo_jurisdiccionSpecified = true;
								imp.porcentaje_impuestoSpecified = true;
								imp.importe_impuesto_moneda_origenSpecified = true;
							}
						}
					}
                    
					Session["lote"] = lcFea;
					Response.Redirect("Reportes\\FacturaWebForm.aspx", true);

				}
				catch (Exception ex)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al generar el pdf.\\n " + ex.Message + "');</script>");
				}
			}
		}
		
		private void RegistrarActividad(FeaEntidades.InterFacturas.lote_comprobantes lote, System.Text.StringBuilder sb, System.Net.Mail.SmtpClient smtpClient, string smtpXAmb, System.IO.MemoryStream m)
		{
			//Registro cantidad de comprobantes
			if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
			{
				CedWebRN.Cuenta.RegistrarComprobante(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
			}

			if (((CedWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion)
			{
				//ModoDepuracion encendido
				System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sb.ToString()), System.IO.FileMode.Create);
				m.WriteTo(fs);
				fs.Close();
			}
		}

		private void ActualizarTipoDeCambio()
		{
			DetalleLinea.ActualizarTipoDeCambio(MonedaComprobanteDropDownList.SelectedValue);
			if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Tipo_de_cambioLabel.Visible = true;
				Tipo_de_cambioTextBox.Visible = true;
				Tipo_de_cambioRequiredFieldValidator.Enabled = true;
				Tipo_de_cambioRegularExpressionValidator.Enabled = true;
			}
			else
			{
				Tipo_de_cambioLabel.Visible = false;
				Tipo_de_cambioTextBox.Visible = false;
				Tipo_de_cambioTextBox.Text = null;
				Tipo_de_cambioRequiredFieldValidator.Enabled = false;
				Tipo_de_cambioRegularExpressionValidator.Enabled = false;
			}
		}

		protected void tipoCambioUpdatePanel_Load(object sender, EventArgs e)
		{
			ActualizarTipoDeCambio();
		}

		protected void Version0RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AjustarPrestaServxVersiones();
		}

		protected void Version1RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AjustarPrestaServxVersiones();
		}

		private void AjustarPrestaServxVersiones()
		{
			if (Version0RadioButton.Checked && Version0RadioButton.Visible)
			{
				Presta_ServCheckBox.Visible = true;
				Presta_ServLabel.Visible = true;
				CodigoConceptoLabel.Visible = false;
				CodigoConceptoDropDownList.Visible = false;
			}
			if (Version1RadioButton.Checked && Version1RadioButton.Visible)
			{
				Presta_ServCheckBox.Visible = false;
				Presta_ServLabel.Visible = false;
				CodigoConceptoLabel.Visible = true;
				CodigoConceptoDropDownList.Visible = true;
			}
		}

		private void AjustarCamposXVersion(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{

		}

		private void AjustarCamposXVersion(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			if (lc.cabecera_lote.presta_servSpecified)
			{
				Version0RadioButton.Checked = true;
				Version1RadioButton.Checked=false;
			}
			else
			{
				Version1RadioButton.Checked = true;
				Version0RadioButton.Checked=false;
			}
			AjustarPrestaServxVersiones();
		}

		protected void PaisDestinoExpDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!CompradorDropDownList.Visible)
			{
				return;
			}
			System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores;
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
			CompradorDropDownList.DataValueField = "RazonSocial";
			CompradorDropDownList.DataTextField = "RazonSocial";
			if (PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
			{
				listacompradores = CedWebRN.Comprador.ListaSinExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
				Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
				Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
				Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
				Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
			}
			else if (PaisDestinoExpDropDownList.SelectedItem.Text.Equals(string.Empty))
			{
				try
				{
					int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
					string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
					{
						return pv.Id == auxPV;
					}).IdTipo;
					listacompradores = CedWebRN.Comprador.ListaExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
					Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
					Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
					Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
					Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
					Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
					Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
					Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
				}
				catch
				{
					listacompradores = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
					Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
					Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
					Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
					Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
				}
			}
			else
			{
				listacompradores = CedWebRN.Comprador.ListaExportacion(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]), true);
				Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
				Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
				Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
				Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
				Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
				Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
				Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
				Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
			}
			CompradorDropDownList.DataSource = listacompradores;
			CompradorDropDownList.DataBind();
			CompradorDropDownList.SelectedIndex = 0;
			Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
			Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
			ResetearComprador();
		}
		public Detalle Articulos
		{
			get
			{
				return this.DetalleLinea;
			}
		}

        protected void Tipo_De_ComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int auxPV = Convert.ToInt32(Punto_VentaTextBox.Text);
                string idtipo = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.PuntosDeVenta.Find(delegate(CedWebEntidades.PuntoDeVenta pv)
                {
                    return pv.Id == auxPV;
                }).IdTipo;
                if (idtipo.Equals("RG2904"))
                {
                    AjustarCodigoOperacionEn2904(((DropDownList)sender).SelectedValue);
                }
            }
            catch
            {
            }
        }
	}
}