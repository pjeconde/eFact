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

namespace FeaWeb
{
	public partial class Default : System.Web.UI.Page
	{
		#region Variables
		string gvUniqueID = String.Empty;
		int gvNewPageIndex = 0;
		int gvEditIndex = -1;
		System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas;
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
				FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
				lineas.Add(linea);
				detalleGridView.DataSource = lineas;
				ViewState["lineas"] = lineas;

				Condicion_IVA_VendedorDropDownList.DataValueField = "Codigo";
				Condicion_IVA_VendedorDropDownList.DataTextField = "Descr";
				Condicion_IVA_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();

				//Condicion_Ingresos_Brutos_VendedorDropDownList.DataValueField = "Codigo";
				//Condicion_Ingresos_Brutos_VendedorDropDownList.DataTextField = "Descr";
				//Condicion_Ingresos_Brutos_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();

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
				Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();

				//Codigo_OperacionDropDownList.DataValueField = "Codigo";
				//Codigo_OperacionDropDownList.DataTextField = "Descr";
				//Codigo_OperacionDropDownList.DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.Lista();

				DataBind();

				//System.Collections.Generic.List<FeaEntidades.InterFacturas.lineaDescuentos> lineasDescuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.lineaDescuentos>();
				//FeaEntidades.InterFacturas.lineaDescuentos lineaDescuentos = new FeaEntidades.InterFacturas.lineaDescuentos();
				//lineaDescuentos.descripcion_descuento = "Cualquier cosa";
				//lineasDescuentos.Add(lineaDescuentos);
				//descuentosGridEX.DataSource = lineasDescuentos;

				//System.Collections.Generic.List<FeaEntidades.InterFacturas.lineaImpuestos> lineasImpuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.lineaImpuestos>();
				//FeaEntidades.InterFacturas.lineaImpuestos lineaImpuestos = new FeaEntidades.InterFacturas.lineaImpuestos();
				//lineaImpuestos.descripcion_impuesto = "Cualquier cosa";
				//lineasImpuestos.Add(lineaImpuestos);
				//impuestosGridEX.DataSource = lineasImpuestos;
			}
		}

		protected void detalleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			GridViewRow row = e.Row;
			string strSort = string.Empty;

			// Make sure we aren't in header/footer rows
			if (row.DataItem == null)
			{
				return;
			}

			//Find Child GridView control
			GridView gv = new GridView();
			gv = (GridView)row.FindControl("impuestoGridView");

			//Check if any additional conditions (Paging, Sorting, Editing, etc) to be applied on child GridView
		    if (gv.UniqueID == gvUniqueID)
		    {
		        gv.PageIndex = gvNewPageIndex;
		        gv.EditIndex = gvEditIndex;
		        //Expand the Child grid
		        ClientScript.RegisterStartupScript(GetType(), "Expand", "<SCRIPT LANGUAGE='javascript'>expandcollapse('div" + ((DataRowView)e.Row.DataItem)["descripcion"].ToString() + "','one');</script>");
		    }

		    //Prepare the query for Child GridView by passing the Customer ID of the parent row
			//gv.DataSource = ChildDataSourceImpuesto((FeaEntidades.InterFacturas.linea)e.Row.DataItem);
			//gv.DataBind();

		    //Add delete confirmation message for Customer
		    LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteDetalle");
		    l.Attributes.Add("onclick", "javascript:return " +
		    "confirm('Está seguro que quiere borrar " +
		    DataBinder.Eval(e.Row.DataItem, "descripcion") + "')");
		}

		//private ObjectDataSource ChildDataSourceImpuesto(FeaEntidades.InterFacturas.linea l)
		//{
		//    ObjectDataSource impuestoODS = new ObjectDataSource();
		//    impuestoODS.DataObjectTypeName = "FeaEntidades.InterFacturas.lineaImpuestos";
		//    impuestoODS.TypeName = "FeaEntidades.InterFacturas.lineasImpuestos";
		//    impuestoODS.SelectMethod = "Listar";
		//    return impuestoODS;
		//}

		protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			//Check if Add button clicked
			if(e.CommandName.Equals("AddDetalle"))
			{
				try
				{
					FeaEntidades.InterFacturas.linea l = new FeaEntidades.InterFacturas.linea();

					l.descripcion = ((TextBox)detalleGridView.FooterRow.FindControl("txtdescripcion")).Text;
					l.importe_total_articulo = Convert.ToDouble(((TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo")).Text);

					((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Add(l);


					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
					FeaEntidades.InterFacturas.linea lineaInicial=lineas[0];
					if (lineaInicial.descripcion==null)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Remove(lineaInicial);
					}

					detalleGridView.DataSource = ViewState["lineas"];
					detalleGridView.DataBind();

					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Detalle agregado satisfactoriamente');</script>");

				}
				catch (Exception ex)
				{
					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
				}
			}
		}

		protected void detalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			//Get the values stored in the text boxes
			string descripcion = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
			double importe_total_articulo = Convert.ToDouble(((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_total_articulo")).Text);

			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);

				FeaEntidades.InterFacturas.linea l = lineas[e.RowIndex];
				l.descripcion = descripcion;
				l.importe_total_articulo = importe_total_articulo;

				detalleGridView.EditIndex = -1;
				detalleGridView.DataSource = ViewState["lineas"];
				detalleGridView.DataBind();

				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Detalle actualizado correctamente');</script>");
			}
			catch { }

		}

		protected void detalleGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
				e.ExceptionHandled = true;
			}
		}

		protected void detalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			detalleGridView.EditIndex = e.NewEditIndex;
			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();
		}

		protected void detalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			detalleGridView.EditIndex = -1;
			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();
		}

		protected void detalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
				FeaEntidades.InterFacturas.linea l = lineas[e.RowIndex];
				lineas.Remove(l);

				if(lineas.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.linea nueva = new FeaEntidades.InterFacturas.linea();					
					lineas.Add(nueva);
				}

				detalleGridView.EditIndex = -1;

				detalleGridView.DataSource = ViewState["lineas"];
				detalleGridView.DataBind();

				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Detalle eliminado correctamente');</script>");
			}
			catch { }

		}

		protected void detalleGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
				e.ExceptionHandled = true;
			}
		}

		protected void GenerarButton_Click(object sender, EventArgs e)
		{
			FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
			FeaEntidades.InterFacturas.cabecera_lote cab=new FeaEntidades.InterFacturas.cabecera_lote();
			cab.cantidad_reg = 1;
			cab.cuit_canal = Convert.ToInt64(Cuit_CanalTextBox.Text);
			cab.cuit_vendedor = Convert.ToInt64(Cuit_VendedorTextBox.Text);
			cab.id_lote = Convert.ToInt64(Id_LoteTextbox.Text);
			cab.presta_servSpecified = true;
			cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
			cab.punto_de_venta = Convert.ToInt32(Punto_VentaTextBox.Text);
			lote.cabecera_lote = cab;

			FeaEntidades.InterFacturas.cabecera compcab = new FeaEntidades.InterFacturas.cabecera();

			FeaEntidades.InterFacturas.informacion_comprador infcompra = new FeaEntidades.InterFacturas.informacion_comprador();
			infcompra.GLN = Convert.ToInt64(GLN_CompradorTextBox.Text);
			infcompra.codigo_interno = Codigo_Interno_CompradorTextBox.Text;
			infcompra.codigo_doc_identificatorio = Convert.ToInt32(Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
			infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorTextBox.Text);
			infcompra.denominacion = Denominacion_CompradorTextBox.Text;
			infcompra.condicion_IVASpecified = true;
			infcompra.condicion_IVA = Convert.ToInt32(Condicion_IVA_CompradorDropDownList.SelectedValue);
			//infcompra.condicion_ingresos_brutosSpecified = true;
			//infcompra.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_CompradorDropDownList.SelectedValue);
			//infcompra.nro_ingresos_brutos
			infcompra.inicio_de_actividades = InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString;
			infcompra.contacto = Contacto_CompradorTextBox.Text;
			infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
			infcompra.domicilio_numero = Domicilio_Numero_CompradorTextBox.Text;
			infcompra.domicilio_piso = Domicilio_Piso_CompradorTextBox.Text;
			infcompra.domicilio_depto = Domicilio_Depto_CompradorTextBox.Text;
			infcompra.domicilio_sector = Domicilio_Sector_CompradorTextBox.Text;
			infcompra.domicilio_torre = Domicilio_Torre_CompradorTextBox.Text;
			infcompra.domicilio_manzana = Domicilio_Manzana_CompradorTextBox.Text;
			infcompra.localidad = Localidad_CompradorTextBox.Text;
			infcompra.provincia = Provincia_CompradorTextBox.Text;
			infcompra.cp = Cp_CompradorTextBox.Text;
			infcompra.email = Email_CompradorTextBox.Text;
			infcompra.telefono = Telefono_CompradorTextBox.Text;

			compcab.informacion_comprador = infcompra;

			FeaEntidades.InterFacturas.informacion_comprobante infcomprob = new FeaEntidades.InterFacturas.informacion_comprobante();
			infcomprob.tipo_de_comprobante = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue);
			infcomprob.numero_comprobante = Convert.ToInt64(Numero_ComprobanteTextBox.Text);
			infcomprob.punto_de_venta = Convert.ToInt32(Punto_VentaTextBox.Text);
			infcomprob.fecha_emision = FechaEmisionDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_vencimiento = FechaVencimientoDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_serv_desde = FechaServDesdeDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_serv_hasta = FechaServHastaDatePickerWebUserControl.CalendarDateString;
			//infcomprob.condicion_de_pago = Convert.ToInt32(Condicion_De_PagoTextBox.Text);
			//infcomprob.iva_computable = Iva_ComputableDropDownList.SelectedValue;
			//infcomprob.codigo_operacion = Codigo_OperacionDropDownList.SelectedValue;
			infcomprob.cae = CAETextBox.Text;
			infcomprob.fecha_obtencion_cae = FechaCAEObtencionDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_vencimiento_cae = FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString;
			compcab.informacion_comprobante = infcomprob;

			FeaEntidades.InterFacturas.informacion_vendedor infovend = new FeaEntidades.InterFacturas.informacion_vendedor();
			infovend.GLN = Convert.ToInt64(GLN_VendedorTextBox.Text);
			infovend.codigo_interno = Codigo_Interno_VendedorTextBox.Text;
			infovend.razon_social = Razon_Social_VendedorTextBox.Text;
			infovend.cuit = Convert.ToInt64(Cuit_VendedorTextBox.Text);
			infovend.condicion_IVASpecified = true;
			infovend.condicion_IVA = Convert.ToInt32(Condicion_IVA_VendedorDropDownList.SelectedValue);
			//infovend.condicion_ingresos_brutosSpecified = true;
			//infovend.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue);
			//infovend.nro_ingresos_brutos = Nro_Ingresos_Brutos_VendedorTextBox.Text;
			infovend.inicio_de_actividades = InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDateString;
			infovend.contacto = Contacto_VendedorTextBox.Text;
			infovend.domicilio_calle = Domicilio_Calle_VendedorTextBox.Text;
			infovend.domicilio_numero = Domicilio_Numero_VendedorTextBox.Text;
			infovend.domicilio_piso = Domicilio_Piso_VendedorTextBox.Text;
			infovend.domicilio_depto = Domicilio_Depto_VendedorTextBox.Text;
			infovend.domicilio_sector = Domicilio_Sector_VendedorTextBox.Text;
			infovend.domicilio_torre = Domicilio_Torre_VendedorTextBox.Text;
			infovend.domicilio_manzana = Domicilio_Manzana_VendedorTextBox.Text;
			infovend.localidad = Localidad_VendedorTextBox.Text;
			infovend.provincia = Provincia_VendedorTextBox.Text;
			infovend.cp = Cp_VendedorTextBox.Text;
			infovend.email = Email_VendedorTextBox.Text;
			infovend.telefono = Telefono_VendedorTextBox.Text;
			compcab.informacion_vendedor = infovend;

			FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
			comp.cabecera = compcab;

			FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();

			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			for (int i = 0; i < listadelineas.Count;i++ )
			{
				det.linea[i] = new FeaEntidades.InterFacturas.linea();
				det.linea[i].numeroLinea = i+1;
				det.linea[i].descripcion = listadelineas[i].descripcion;
				det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
			}

			det.comentarios = ComentariosTextBox.Text;

			comp.detalle = det;

			FeaEntidades.InterFacturas.resumen r = new FeaEntidades.InterFacturas.resumen();
			r.tipo_de_cambio = 1;
			r.codigo_moneda = "PES";
			r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
			r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
			r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
			r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
			r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);

			//r.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
			//r.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
			//r.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
			//r.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);

			r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);

			r.observaciones = Observaciones_ResumenTextBox.Text;

			comp.resumen = r;

			lote.comprobante[0] = comp;

			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(lote.cabecera_lote.cuit_vendedor);
			sb.Append("-");
			sb.Append(lote.cabecera_lote.punto_de_venta);
			sb.Append("-");
			sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
			sb.Append("-");
			sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
			sb.Append(".xml");
			System.IO.Stream fs = new System.IO.FileStream(sb.ToString(), System.IO.FileMode.Create);
			System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(fs, System.Text.Encoding.GetEncoding("ISO-8859-1"));
			x.Serialize(writer, lote);
			fs.Close();

			System.IO.MemoryStream m = new System.IO.MemoryStream();
			System.IO.StreamWriter sw = new System.IO.StreamWriter(m);
			sw.Flush();
			System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
			x.Serialize(writerdememoria, lote);

			System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
				Email_VendedorTextBox.Text, "Nuevo comprobante", string.Empty);

			m.Seek(0, System.IO.SeekOrigin.Begin);

			System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
			contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
			contentType.Name = sb.ToString();
			System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m, contentType);

			mail.Attachments.Add(attachment);

			System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
			smtpClient.Host = "vsmtpr.bancogalicia.com.ar";

			smtpClient.Send(mail);
			m.Close();

			//Envío de mail a nosotros

			System.Net.Mail.MailMessage mailCedeira = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
				"facturaelectronica@cedeira.com.ar", "XML_" + lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString()+"_"+System.DateTime.Now.ToLocalTime(), string.Empty);
			sb = new System.Text.StringBuilder();
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.email);
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.razon_social);
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.telefono);
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.localidad);
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.contacto);
			sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString());

			mailCedeira.Body = sb.ToString();

			smtpClient = new System.Net.Mail.SmtpClient();
			smtpClient.Host = "vsmtpr.bancogalicia.com.ar";

			smtpClient.Send(mailCedeira);

			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente');</script>");
		}
	}
}
