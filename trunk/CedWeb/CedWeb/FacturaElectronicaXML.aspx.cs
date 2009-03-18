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

public partial class FacturaElectronicaXML : System.Web.UI.Page
{
	#region Variables
	string gvUniqueID = String.Empty;
	int gvNewPageIndex = 0;
	int gvEditIndex = -1;
	System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas;
	System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos;
	System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> descuentos;
	#endregion
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			if (Session["AceptarTYC"] == null || Session["AceptarTYC"].Equals(false))
			{
				Response.Redirect("FacturaElectronicaTYC.aspx");
			}
			else
			{
				lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
				FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
				lineas.Add(linea);
				detalleGridView.DataSource = lineas;
				ViewState["lineas"] = lineas;

				impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
				FeaEntidades.InterFacturas.resumenImpuestos impuesto = new FeaEntidades.InterFacturas.resumenImpuestos();
				impuestos.Add(impuesto);
				impuestosGridView.DataSource = impuestos;
				ViewState["impuestos"] = impuestos;

				descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
				FeaEntidades.InterFacturas.resumenDescuentos descuento = new FeaEntidades.InterFacturas.resumenDescuentos();
				descuentos.Add(descuento);
				descuentosGridView.DataSource = descuentos;
				ViewState["descuentos"] = descuentos;

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
				Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();

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

				DataBind();

				BindearDropDownLists();

				if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
				{
					CedWebRN.Cuenta.ReservarNroLote(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
					Id_LoteTextbox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.UltimoNroLote.ToString();
					Email_VendedorRequiredFieldValidator.Enabled = false;
					GenerarButton.Text = "Enviar archivo XML al e-mail de la cuenta eFact (" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email + ")";
				}
				if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.CUIT != 0)
				{
					CedWebEntidades.Vendedor v = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor;
					Razon_Social_VendedorTextBox.Text = v.RazonSocial;
					Domicilio_Calle_VendedorTextBox.Text = v.Calle;
					Domicilio_Numero_VendedorTextBox.Text = v.Nro;
					Domicilio_Piso_VendedorTextBox.Text = v.Piso;
					Domicilio_Depto_VendedorTextBox.Text = v.Depto;
					Domicilio_Sector_VendedorTextBox.Text = v.Sector;
					Domicilio_Torre_VendedorTextBox.Text = v.Torre;
					Domicilio_Manzana_VendedorTextBox.Text = v.Manzana;
					Localidad_VendedorTextBox.Text = v.Localidad;
					Provincia_VendedorDropDownList.SelectedValue = v.IdProvincia;
					Cp_VendedorTextBox.Text = v.CodPost;
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
			}
		}
	}

	private void BindearDropDownLists()
	{
		((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataValueField = "Codigo";
		((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataTextField = "Descr";
		((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
		((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataBind();
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
		if (e.CommandName.Equals("AddDetalle"))
		{
			try
			{
				FeaEntidades.InterFacturas.linea l = new FeaEntidades.InterFacturas.linea();

				string auxDescr = ((TextBox)detalleGridView.FooterRow.FindControl("txtdescripcion")).Text;
				if (!auxDescr.Equals(string.Empty))
				{
					l.descripcion = auxDescr;
				}
				else
				{
					throw new Exception("Detalle no agregado porque la descripción no puede estar vacía");
				}
				string auxTotal = ((TextBox)detalleGridView.FooterRow.FindControl("txtimporte_total_articulo")).Text;
				if (!auxTotal.Contains(","))
				{
					l.importe_total_articulo = Convert.ToDouble(auxTotal);
				}
				else
				{
					throw new Exception("Detalle no agregado porque el separador de decimales debe ser el punto");
				}

				((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Add(l);


				//Me fijo si elimino la fila automática
				System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);
				FeaEntidades.InterFacturas.linea lineaInicial = lineas[0];
				if (lineaInicial.descripcion == null)
				{
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]).Remove(lineaInicial);
				}

				detalleGridView.DataSource = ViewState["lineas"];
				detalleGridView.DataBind();

			}
			catch (Exception ex)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
			}
		}
	}

	protected void detalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> lineas = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"]);

			FeaEntidades.InterFacturas.linea l = lineas[e.RowIndex];
			string auxDescr = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
			if (!auxDescr.Equals(string.Empty))
			{
				l.descripcion = auxDescr;
			}
			else
			{
				throw new Exception("Detalle no actualizado porque la descripción no puede estar vacía");
			}
			string auxTotal = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_total_articulo")).Text;
			if (!auxTotal.Contains(","))
			{
				l.importe_total_articulo = Convert.ToDouble(auxTotal);
			}
			else
			{
				throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
			}

			detalleGridView.EditIndex = -1;
			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();
		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
		}
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

			if (lineas.Count.Equals(0))
			{
				FeaEntidades.InterFacturas.linea nueva = new FeaEntidades.InterFacturas.linea();
				lineas.Add(nueva);
			}

			detalleGridView.EditIndex = -1;

			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();

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
		try
		{
			FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
			FeaEntidades.InterFacturas.cabecera_lote cab = new FeaEntidades.InterFacturas.cabecera_lote();
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
			if (!GLN_CompradorTextBox.Text.Equals(string.Empty))
			{
				infcompra.GLN = Convert.ToInt64(GLN_CompradorTextBox.Text);
			}
			infcompra.codigo_interno = Codigo_Interno_CompradorTextBox.Text;
			infcompra.codigo_doc_identificatorio = Convert.ToInt32(Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
			infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorTextBox.Text);
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
			infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
			infcompra.domicilio_numero = Domicilio_Numero_CompradorTextBox.Text;
			infcompra.domicilio_piso = Domicilio_Piso_CompradorTextBox.Text;
			infcompra.domicilio_depto = Domicilio_Depto_CompradorTextBox.Text;
			infcompra.domicilio_sector = Domicilio_Sector_CompradorTextBox.Text;
			infcompra.domicilio_torre = Domicilio_Torre_CompradorTextBox.Text;
			infcompra.domicilio_manzana = Domicilio_Manzana_CompradorTextBox.Text;
			infcompra.localidad = Localidad_CompradorTextBox.Text;
			string auxCodProvCompra = Convert.ToString(Provincia_CompradorDropDownList.SelectedValue);
			if (!auxCodProvCompra.Equals("0"))
			{
				infcompra.provincia = auxCodProvCompra;
			}
			infcompra.cp = Cp_CompradorTextBox.Text;
			infcompra.email = Email_CompradorTextBox.Text;
			infcompra.telefono = Telefono_CompradorTextBox.Text;

			compcab.informacion_comprador = infcompra;

			FeaEntidades.InterFacturas.informacion_comprobante infcomprob = new FeaEntidades.InterFacturas.informacion_comprobante();
			infcomprob.tipo_de_comprobante = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue);
			infcomprob.numero_comprobante = Convert.ToInt64(Numero_ComprobanteTextBox.Text);
			infcomprob.punto_de_venta = Convert.ToInt32(Punto_VentaTextBox.Text);
			infcomprob.fecha_emision = FechaEmisionDatePickerWebUserControl.CalendarDateString;
			if (!FechaVencimientoDatePickerWebUserControl.CalendarDateString.Equals(string.Empty))
			{
				infcomprob.fecha_vencimiento = FechaVencimientoDatePickerWebUserControl.CalendarDateString;
			}
			infcomprob.fecha_serv_desde = FechaServDesdeDatePickerWebUserControl.CalendarDateString;
			infcomprob.fecha_serv_hasta = FechaServHastaDatePickerWebUserControl.CalendarDateString;

			string auxIVAcompu = IVAcomputableDropDownList.SelectedValue;
			if (!auxIVAcompu.Equals(string.Empty))
			{
				infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
			}

			if (!Condicion_De_PagoTextBox.Text.Equals(string.Empty))
			{
				infcomprob.condicion_de_pago = Convert.ToInt32(Condicion_De_PagoTextBox.Text);
				infcomprob.condicion_de_pagoSpecified = true;
			}
			infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
			if (!CAETextBox.Text.Equals(string.Empty))
			{
				infcomprob.cae = CAETextBox.Text;
				infcomprob.fecha_obtencion_cae = FechaCAEObtencionDatePickerWebUserControl.CalendarDateString;
				infcomprob.fecha_vencimiento_cae = FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString;
			}
			compcab.informacion_comprobante = infcomprob;

			FeaEntidades.InterFacturas.informacion_vendedor infovend = new FeaEntidades.InterFacturas.informacion_vendedor();
			if (!GLN_VendedorTextBox.Text.Equals(string.Empty))
			{
				infovend.GLN = Convert.ToInt64(GLN_VendedorTextBox.Text);
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
				if (infovend.condicion_ingresos_brutos != 0 && infovend.nro_ingresos_brutos != string.Empty)
				{
					infovend.condicion_ingresos_brutosSpecified = true;
				}
				else
				{
					infovend.nro_ingresos_brutos = null;
				}
			}
			catch
			{

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

			FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
			comp.cabecera = compcab;

			FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();

			System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
			for (int i = 0; i < listadelineas.Count; i++)
			{
				det.linea[i] = new FeaEntidades.InterFacturas.linea();
				det.linea[i].numeroLinea = i + 1;
				if (listadelineas[i].descripcion == null)
				{
					throw new Exception("Debe informar al menos un artículo");
				}
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

			try
			{
				r.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
				if (r.importe_total_impuestos_nacionales != 0)
				{
					r.importe_total_impuestos_nacionalesSpecified = true;
				}
			}
			catch
			{
			}
			try
			{
				r.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
				if (r.importe_total_ingresos_brutos != 0)
				{
					r.importe_total_ingresos_brutosSpecified = true;
				}
			}
			catch
			{
			}
			try
			{
				r.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
				if (r.importe_total_impuestos_municipales != 0)
				{
					r.importe_total_impuestos_municipalesSpecified = true;
				}
			}
			catch
			{
			}
			try
			{
				r.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
				if (r.importe_total_impuestos_internos != 0)
				{
					r.importe_total_impuestos_internosSpecified = true;
				}
			}
			catch
			{
			}
			r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);

			r.observaciones = Observaciones_ResumenTextBox.Text;

			comp.resumen = r;

			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"];
			comp.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[listadeimpuestos.Count];

			for (int i = 0; i < listadeimpuestos.Count; i++)
			{
				if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
				{
					comp.resumen.impuestos[i] = new FeaEntidades.InterFacturas.resumenImpuestos();
					comp.resumen.impuestos[i].codigo_impuesto = listadeimpuestos[i].codigo_impuesto;
					comp.resumen.impuestos[i].codigo_jurisdiccion = listadeimpuestos[i].codigo_jurisdiccion;
					comp.resumen.impuestos[i].codigo_jurisdiccionSpecified = listadeimpuestos[i].codigo_jurisdiccionSpecified;
					comp.resumen.impuestos[i].descripcion = listadeimpuestos[i].descripcion;
					comp.resumen.impuestos[i].importe_impuesto = listadeimpuestos[i].importe_impuesto;
					comp.resumen.impuestos[i].porcentaje_impuesto = listadeimpuestos[i].porcentaje_impuesto;
					comp.resumen.impuestos[i].porcentaje_impuestoSpecified = listadeimpuestos[i].porcentaje_impuestoSpecified;
				}
			}


			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> listadedescuentos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"];
			comp.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[listadedescuentos.Count];

			for (int i = 0; i < listadedescuentos.Count; i++)
			{
				if (listadedescuentos[i].descripcion_descuento != null && !listadedescuentos[i].descripcion_descuento.Equals(string.Empty))
				{
					comp.resumen.descuentos[i] = new FeaEntidades.InterFacturas.resumenDescuentos();
					comp.resumen.descuentos[i].alicuota_iva_descuento = listadedescuentos[i].alicuota_iva_descuento;
					comp.resumen.descuentos[i].alicuota_iva_descuentoSpecified = listadedescuentos[i].alicuota_iva_descuentoSpecified;
					comp.resumen.descuentos[i].descripcion_descuento = listadedescuentos[i].descripcion_descuento;
					comp.resumen.descuentos[i].importe_descuento = listadedescuentos[i].importe_descuento;
					comp.resumen.descuentos[i].importe_descuento_moneda_origen = listadedescuentos[i].importe_descuento_moneda_origen;
					comp.resumen.descuentos[i].importe_descuento_moneda_origenSpecified = listadedescuentos[i].importe_descuento_moneda_origenSpecified;
					comp.resumen.descuentos[i].importe_iva_descuento = listadedescuentos[i].importe_iva_descuento;
					comp.resumen.descuentos[i].importe_iva_descuento_moneda_origen = listadedescuentos[i].importe_iva_descuento_moneda_origen;
					comp.resumen.descuentos[i].importe_iva_descuento_moneda_origenSpecified = listadedescuentos[i].importe_iva_descuento_moneda_origenSpecified;
					comp.resumen.descuentos[i].importe_iva_descuentoSpecified = listadedescuentos[i].importe_iva_descuentoSpecified;
					comp.resumen.descuentos[i].porcentaje_descuento = listadedescuentos[i].porcentaje_descuento;
					comp.resumen.descuentos[i].porcentaje_descuentoSpecified = listadedescuentos[i].porcentaje_descuentoSpecified;
				}
			}


			lote.comprobante[0] = comp;

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

			System.Net.Mail.MailMessage mail;
			if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
			{
				mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
					((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email,
					"Ced-eFact-Envío automático archivo XML:" + sb.ToString()
					, string.Empty);
			}
			else
			{
				mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
					Email_VendedorTextBox.Text,
					"Ced-eFact-Envío automático archivo XML:" + sb.ToString()
					, string.Empty);
			}
			m.Seek(0, System.IO.SeekOrigin.Begin);

			System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
			contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
			contentType.Name = sb.ToString();
			System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m, contentType);

			mail.Attachments.Add(attachment);
			mail.BodyEncoding = System.Text.Encoding.UTF8;
			mail.Body = AgregarBody();

			string smtpXAmb = System.Configuration.ConfigurationManager.AppSettings["Ambiente"].ToString();

			System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();

			if (smtpXAmb.Equals("DESA"))
			{
				smtpClient.Host = "vsmtpr.bancogalicia.com.ar";
			}
			else
			{
				smtpClient.Host = "localhost";
			}

			smtpClient.Send(mail);
			m.Close();

			//Envío de mail a nosotros

			if (!smtpXAmb.Equals("DESA"))
			{

				System.Net.Mail.MailMessage mailCedeira = new System.Net.Mail.MailMessage("facturaelectronicaxml@cedeira.com.ar",
					"facturaelectronicaxml@cedeira.com.ar", "XML_" + lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString() + "_" + System.DateTime.Now.ToLocalTime(), string.Empty);
				sb = new System.Text.StringBuilder();
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.email);
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.razon_social);
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.telefono);
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.localidad);
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.contacto);
				sb.AppendLine(lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString());

				mailCedeira.Body = sb.ToString();
				smtpClient = new System.Net.Mail.SmtpClient();
				smtpClient.Host = "localhost";
				smtpClient.Send(mailCedeira);
			}

			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente');window.open('https://srv1.interfacturas.com.ar/cfeWeb/faces/login/identificacion.jsp/', '_blank');</script>");
		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al generar el archivo. " + ex.Message + ". Ir a DETALLE.');</script>");
		}
	}

	private string AgregarBody()
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendLine("ESTE MENSAJE SE HA GENERADO AUTOMÁTICAMENTE.");
		sb.AppendLine("");
		sb.AppendLine("Alguien nos pidió que le enviáramos este archivo.");
		sb.AppendLine("Si no ha iniciado esta petición, por favor ignórela. Si necesita asistencia adicional, por favor visítenos en http://www.cedeira.com.ar o envíenos un correo electrónico a facturaelectronica@cedeira.com.ar");
		sb.AppendLine("");
		sb.AppendLine("");
		sb.AppendLine("");
		sb.AppendLine("");
		sb.AppendLine("Si es el archivo que está esperando, siga las siguientes instrucciones:");
		sb.AppendLine("");
		sb.AppendLine("El archivo adjunto se encuentra formateado para ser procesado por Interfacturas.");
		sb.AppendLine("");
		sb.AppendLine("Recomendamos guardarlo en su repositorio local de facturas.");
		sb.AppendLine("");
		sb.AppendLine("Se detalla el procedimiento para validarlo en el site de Interfacturas.");
		sb.AppendLine("");
		sb.AppendLine("1) Realizar un Login en Interfacturas");
		sb.AppendLine("2) Seleccionar \"Obtención CAE\"");
		sb.AppendLine("3) \"Validador Lote\"");
		sb.AppendLine("4) Con el botón \"Examinar...\" seleccione el archivo recibido en el respositorio local de archivos XML");
		sb.AppendLine("5) Una vez encontrado, pulsar el botón \"Abrir\"");
		sb.AppendLine("6) Luego el botón \"Enviar\"");
		sb.AppendLine("7) Como respuesta, el site muestra una ventana \"Desea abrir o guardar este archivo\"");
		sb.AppendLine("Seleccionar la opción \"Guardar\" y dejar el resultado en el mismo directorio donde se encuentra el XML.");
		sb.AppendLine("8) Abrir el archivo recibido (el zip y el XML y verificar que la respuesta sea satisfactoria, de la siguiente manera:");
		sb.AppendLine("");
		sb.AppendLine("Abrir el archivo y verificar que el resultado sea OK.");
		sb.AppendLine("Para dar por aceptado el archivo, debe verificar que en el archivo XML de respuesta, se encuentre el texto:<estado>OK</estado>");
		sb.AppendLine("");
		sb.AppendLine("Se adjunta a modo de ejemplo, un archivo XML de respuesta satisfactoria:");
		sb.AppendLine("");
		sb.AppendLine("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
		sb.AppendLine("<lote_comprobantes_response xmlns=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
		sb.AppendLine("  <lote_response>");
		sb.AppendLine("    <id_lote>2</id_lote>");
		sb.AppendLine("    <cuit_canal>30690783521</cuit_canal>");
		sb.AppendLine("    <cuit_vendedor>30710015062</cuit_vendedor>");
		sb.AppendLine("    <cantidad_reg>1</cantidad_reg>");
		sb.AppendLine("    <presta_serv>1</presta_serv>");
		sb.AppendLine("    <fecha_envio_lote xsi:nil=\"true\"/>");
		sb.AppendLine("    <punto_de_venta>2</punto_de_venta>");
		sb.AppendLine("    <estado>OK</estado>");
		sb.AppendLine("  </lote_response>");
		sb.AppendLine("</lote_comprobantes_response>");
		sb.AppendLine("");
		sb.AppendLine("");
		sb.AppendLine("En el caso que la respuesta no sea OK, debe analizar el motivo del error y realizar los ajustes necesarios.");
		sb.AppendLine("");
		sb.AppendLine("© 2009 Cedeira Sofware Factory S.R.L. Todos los derechos reservados.");
		sb.AppendLine("Buenos Aires, Argentina");
		return sb.ToString();
	}
	protected void impuestosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		impuestosGridView.EditIndex = -1;
		impuestosGridView.DataSource = ViewState["impuestos"];
		impuestosGridView.DataBind();
	}
	protected void impuestosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName.Equals("AddImpuestoGlobal"))
		{
			try
			{
				FeaEntidades.InterFacturas.resumenImpuestos r = new FeaEntidades.InterFacturas.resumenImpuestos();

				int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedValue);
				r.codigo_impuesto = auxcodigo_impuesto;
				r.descripcion = ((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedItem.Text;

				string auxTotal = ((TextBox)impuestosGridView.FooterRow.FindControl("txtimporte_impuesto")).Text;
				if (!auxTotal.Contains(","))
				{
					r.importe_impuesto = Convert.ToDouble(auxTotal);
				}
				else
				{
					throw new Exception("Impuesto global no agregado porque el separador de decimales debe ser el punto");
				}

				((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Add(r);


				//Me fijo si elimino la fila automática
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				FeaEntidades.InterFacturas.resumenImpuestos impuestoInicial = impuestos[0];
				if (impuestoInicial.codigo_impuesto == 0)
				{
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Remove(impuestoInicial);
				}

				impuestosGridView.DataSource = ViewState["impuestos"];
				impuestosGridView.DataBind();
				BindearDropDownLists();

			}
			catch (Exception ex)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
			}
		}
	}
	protected void impuestosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		if (e.Exception != null)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
			e.ExceptionHandled = true;
		}
	}
	protected void impuestosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
			FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
			impuestos.Remove(r);

			if (impuestos.Count.Equals(0))
			{
				FeaEntidades.InterFacturas.resumenImpuestos nueva = new FeaEntidades.InterFacturas.resumenImpuestos();
				impuestos.Add(nueva);
			}

			impuestosGridView.EditIndex = -1;

			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();
		}
		catch { }
	}
	protected void impuestosGridView_RowEditing(object sender, GridViewEditEventArgs e)
	{
		impuestosGridView.EditIndex = e.NewEditIndex;

		impuestosGridView.DataSource = ViewState["impuestos"];
		impuestosGridView.DataBind();
		BindearDropDownLists();

		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataValueField = "Codigo";
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataTextField = "Descr";
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataBind();
		try
		{
			ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"])[e.NewEditIndex].codigo_impuesto.ToString());
			li.Selected = true;
		}
		catch
		{
		}
	}
	protected void impuestosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		if (e.Exception != null)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
			e.ExceptionHandled = true;
		}
	}
	protected void impuestosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{

		try
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);

			FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
			int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedValue);
			r.codigo_impuesto = auxcodigo_impuesto;

			string auxdescr_impuesto = ((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedItem.Text;
			r.descripcion = auxdescr_impuesto;


			string auxTotal = ((TextBox)impuestosGridView.Rows[e.RowIndex].FindControl("txtimporte_impuesto")).Text;
			if (!auxTotal.Contains(","))
			{
				r.importe_impuesto = Convert.ToDouble(auxTotal);
			}
			else
			{
				throw new Exception("Impuesto global no actualizado porque el separador de decimales debe ser el punto");
			}

			impuestosGridView.EditIndex = -1;
			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();

		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
		}
	}
	protected void descuentosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		descuentosGridView.EditIndex = -1;
		descuentosGridView.DataSource = ViewState["descuentos"];
		descuentosGridView.DataBind();
	}
	protected void descuentosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName.Equals("Adddescuentos"))
		{
			try
			{
				FeaEntidades.InterFacturas.resumenDescuentos rd = new FeaEntidades.InterFacturas.resumenDescuentos();

				string auxDescr = ((TextBox)descuentosGridView.FooterRow.FindControl("txtdescripcion")).Text;
				if (!auxDescr.Equals(string.Empty))
				{
					rd.descripcion_descuento = auxDescr;
				}
				else
				{
					throw new Exception("Descuento no agregado porque la descripción no puede estar vacía");
				}
				string auxTotal = ((TextBox)descuentosGridView.FooterRow.FindControl("txtimporte_descuento")).Text;
				if (!auxTotal.Contains(","))
				{
					rd.importe_descuento = Convert.ToDouble(auxTotal);
				}
				else
				{
					throw new Exception("Descuento no agregado porque el separador de decimales debe ser el punto");
				}

				((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Add(rd);


				//Me fijo si elimino la fila automática
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
				if (rds[0].descripcion_descuento == null)
				{
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Remove(rds[0]);
				}

				descuentosGridView.DataSource = ViewState["descuentos"];
				descuentosGridView.DataBind();

			}
			catch (Exception ex)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
			}
		}
	}
	protected void descuentosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		if (e.Exception != null)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
			e.ExceptionHandled = true;
		}
	}
	protected void descuentosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
			FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
			rds.Remove(rd);

			if (rds.Count.Equals(0))
			{
				FeaEntidades.InterFacturas.resumenDescuentos nuevo = new FeaEntidades.InterFacturas.resumenDescuentos();
				rds.Add(nuevo);
			}

			descuentosGridView.EditIndex = -1;

			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
		}
		catch
		{
		}
	}
	protected void descuentosGridView_RowEditing(object sender, GridViewEditEventArgs e)
	{
		descuentosGridView.EditIndex = e.NewEditIndex;
		descuentosGridView.DataSource = ViewState["descuentos"];
		descuentosGridView.DataBind();
	}
	protected void descuentosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		if (e.Exception != null)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
			e.ExceptionHandled = true;
		}
	}
	protected void descuentosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);

			FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
			string auxDescr = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
			if (!auxDescr.Equals(string.Empty))
			{
				rd.descripcion_descuento = auxDescr;
			}
			else
			{
				throw new Exception("Descuento no actualizado porque la descripción no puede estar vacía");
			}
			string auxTotal = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtimporte_descuento")).Text;
			if (!auxTotal.Contains(","))
			{
				rd.importe_descuento = Convert.ToDouble(auxTotal);
			}
			else
			{
				throw new Exception("Descuento no actualizado porque el separador de decimales debe ser el punto");
			}

			descuentosGridView.EditIndex = -1;
			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
		}
		catch (Exception ex)
		{
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
		}
	}
	protected void FileUploadButton_Click(object sender, EventArgs e)
	{
		if (XMLFileUpload.HasFile)
		{
			try
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream(XMLFileUpload.FileBytes);
				ms.Seek(0, System.IO.SeekOrigin.Begin);

				try
				{
					FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
					System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
					lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
					//Cabecera
					Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
					Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
					Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
					Punto_VentaTextBox.Text = Convert.ToString(lc.cabecera_lote.punto_de_venta);
					//Comprobante
					Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
					FechaEmisionDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
					FechaVencimientoDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
					FechaServDesdeDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
					FechaServHastaDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
					Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
					IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
					CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));
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
					Razon_Social_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.razon_social);
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
					lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
					foreach (FeaEntidades.InterFacturas.linea l in lc.comprobante[0].detalle.linea)
					{
						FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
						linea.descripcion = l.descripcion;
						linea.importe_total_articulo = l.importe_total_articulo;
						lineas.Add(linea);
					}
					detalleGridView.DataSource = lineas;
					detalleGridView.DataBind();
					ViewState["lineas"] = lineas;
					//Descuentos globales
					if (lc.comprobante[0].resumen.descuentos != null)
					{
						descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
						foreach (FeaEntidades.InterFacturas.resumenDescuentos r in lc.comprobante[0].resumen.descuentos)
						{
							descuentos.Add(r);
						}
						descuentosGridView.DataSource = descuentos;
						descuentosGridView.DataBind();
						ViewState["descuentos"] = descuentos;
					}
					//impuestos globales
					if (lc.comprobante[0].resumen.impuestos != null)
					{
						impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
						foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lc.comprobante[0].resumen.impuestos)
						{
							impuestos.Add(imp);
						}
						impuestosGridView.DataSource = impuestos;
						impuestosGridView.DataBind();
						ViewState["impuestos"] = impuestos;
					}
					ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;
					//Resumen
					Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_neto_gravado);
					Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_concepto_no_gravado);
					Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_operaciones_exentas);
					Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq);
					Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq_rni);
					Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_factura);
					Observaciones_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.observaciones);

					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_nacionales);
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_municipales);
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_internos);
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_ingresos_brutos);

					ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo');</script>");

				}
				catch (Exception ex)
				{
					if (ex.Source.Equals("System.Xml"))
					{
						try
						{
							ms.Seek(0, System.IO.SeekOrigin.Begin);
							FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
							System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
							c = (FeaEntidades.InterFacturas.comprobante)x.Deserialize(ms);

							//TODO serializar un comprobante

							ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esquema de un solo comprobante no implementado');</script>");
						}
						catch
						{
							ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('El archivo no cumple con el esquema de Interfacturas');</script>");
						}
					}
					else
					{
						throw ex;
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
