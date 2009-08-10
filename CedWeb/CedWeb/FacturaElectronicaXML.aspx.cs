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
    System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
    private System.Globalization.CultureInfo cedeiraCultura;
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

                MonedaComprobanteDropDownList.DataValueField = "Codigo";
                MonedaComprobanteDropDownList.DataTextField = "Descr";
                MonedaComprobanteDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();

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
                System.Collections.Generic.List<CedWebEntidades.Comprador> listacompradores = CedWebRN.Comprador.Lista(sesion.Cuenta, sesion);
                if (listacompradores.Count > 0)
                {
                    CompradorDropDownList.Visible = true;
                    if (!CompradorDropDownList.Enabled) CompradorExclusivoPremiumLabel.Visible = true;
                    CompradorDropDownList.DataValueField = "RazonSocial";
                    CompradorDropDownList.DataTextField = "RazonSocial";
                    CompradorDropDownList.DataSource = listacompradores;
                    CompradorDropDownList.DataBind();
                }
                else
                {
                    CompradorDropDownList.Visible = false;
                    CompradorExclusivoPremiumLabel.Visible = false;
                    CompradorDropDownList.DataSource = null;
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

		((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataValueField = "Codigo";
		((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataTextField = "Descr";
		((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataSource = FeaEntidades.IVA.IVA.Lista();
		((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).DataBind();

        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataValueField = "Codigo";
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataTextField = "Descr";
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).DataBind();

        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataValueField = "Codigo";
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataTextField = "Descr";
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
        ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).DataBind();
    
        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataValueField = "Codigo";
        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataTextField = "Descr";
        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataBind();
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
                if (Punto_VentaTextBox.Text.Equals(string.Empty))
                {
                    throw new Exception("Debe definir el punto de venta antes de ingresar un detalle");
                }

                cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["Cultura"]);				
                
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
					l.importe_total_articulo = Convert.ToDouble(auxTotal, cedeiraCultura);
				}
				else
				{
					throw new Exception("Detalle no agregado porque el separador de decimales debe ser el punto");
				}

				string auxNull = ((TextBox)detalleGridView.FooterRow.FindControl("txtimporte_alicuota_articulo")).Text;
				if (!auxNull.Equals(string.Empty) && !auxNull.Equals("0"))
				{
					double auxImporteIVA = Convert.ToDouble(auxNull, cedeiraCultura);
					l.importe_ivaSpecified = true;
					l.importe_iva = auxImporteIVA;
				}
				else
				{
					l.importe_ivaSpecified = false;
					l.importe_iva = 0;
				}
                double auxAliIVA = Convert.ToDouble(((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).SelectedValue);
                string auxDescAliIVA = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlalicuota_articulo")).SelectedItem.Text;
                if (!auxDescAliIVA.Equals(string.Empty))
				{
					l.alicuota_ivaSpecified = true;
					l.alicuota_iva = auxAliIVA;
				}
				else
				{
                    if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                        {
                            System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                            int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                            if (listaPV.Contains(auxPV))
                            {
                                throw new Exception("Detalle no agregado porque la alicuota iva es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.alicuota_ivaSpecified = false;
                                l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                            }
                        }
                        else
                        {
                            l.alicuota_ivaSpecified = false;
                            l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                        }
                    }
                    else
                    {
                        l.alicuota_ivaSpecified = false;
                        l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                    }					
				}

                string auxUnidad = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlunidad")).SelectedItem.Value;
                if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                        int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                        if (listaPV.Contains(auxPV))
                        {
                            if (auxUnidad.Equals(string.Empty) || auxUnidad.Equals("0"))
                            {
                                throw new Exception("Detalle no agregado porque la unidad es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.unidad = auxUnidad;
                            }
                        }
                        else
                        {
                            l.unidad = auxUnidad;
                        }
                    }
                    else
                    {
                        l.unidad = auxUnidad;
                    }
                }
                else
                {
                    l.unidad = auxUnidad;
                }
                
                string auxCantidad = ((TextBox)detalleGridView.FooterRow.FindControl("txtcantidad")).Text;
                if (!auxCantidad.Contains(","))
                {
                    if (!auxCantidad.Equals(string.Empty) && !auxCantidad.Equals("0"))
                    {
                        l.cantidad = Convert.ToDouble(auxCantidad, cedeiraCultura);
                        l.cantidadSpecified = true;
                    }
                    else
                    {
                        if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                        {
                            if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                            {
                                System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                                int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                                if (listaPV.Contains(auxPV))
                                {
                                    throw new Exception("Detalle no agregado porque la cantidad es obligatoria para bono fiscal");
                                }
                                else
                                {
                                    l.cantidadSpecified = false;
                                    l.cantidad = 0;
                                }
                            }
                            else
                            {
                                l.cantidadSpecified = false;
                                l.cantidad = 0;
                            }
                        }
                        else
                        {
                            l.cantidadSpecified = false;
                            l.cantidad = 0;
                        }
                    }
                }
                else
                {
                    throw new Exception("Detalle no agregado porque el separador de decimales debe ser el punto");
                }
                
                string auxcpcomprador = ((TextBox)detalleGridView.FooterRow.FindControl("txtcpcomprador")).Text;
                if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                        int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                        if (listaPV.Contains(auxPV))
                        {
                            if (auxcpcomprador.Equals(string.Empty))
                            {
                                throw new Exception("Detalle no agregado porque el codigo producto comprador es obligatorio para bono fiscal");
                            }
                            else
                            {
                                l.codigo_producto_comprador = auxcpcomprador;
                            }
                        }
                        else
                        {
                            l.codigo_producto_comprador = auxcpcomprador;
                        }
                    }
                    else
                    {
                        l.codigo_producto_comprador = auxcpcomprador;
                    }
                }
                else
                {
                    l.codigo_producto_comprador = auxcpcomprador;
                }

                string auxcpvendedor = ((TextBox)detalleGridView.FooterRow.FindControl("txtcpvendedor")).Text;
                l.codigo_producto_vendedor = auxcpvendedor;

                string auxindicacion_exento_gravado = ((DropDownList)detalleGridView.FooterRow.FindControl("ddlindicacion_exento_gravado")).SelectedItem.Value;
                if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                        int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                        if (listaPV.Contains(auxPV))
                        {
                            if (auxindicacion_exento_gravado.Equals(string.Empty))
                            {
                                throw new Exception("Detalle no agregado porque la indicacion exento gravado es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                            }
                        }
                        else
                        {
                            l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                        }
                    }
                    else
                    {
                        l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                    }
                }
                else
                {
                    l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                }

                string auxprecio_unitario = ((TextBox)detalleGridView.FooterRow.FindControl("txtprecio_unitario")).Text;
                if (!auxprecio_unitario.Equals(string.Empty) && !auxprecio_unitario.Equals("0"))
                {
                    double auxPU = Convert.ToDouble(auxprecio_unitario, cedeiraCultura);
                    l.precio_unitario = auxPU;
                    l.precio_unitarioSpecified = true;
                }
                else
                {
                    if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                        {
                            System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                            int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                            if (listaPV.Contains(auxPV))
                            {
                                throw new Exception("Detalle no agregado porque el precio unitario es obligatorio para bono fiscal");
                            }
                            else
                            {
                                l.precio_unitario = 0;
                                l.precio_unitarioSpecified = false;
                            }
                        }
                        else
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = false;
                        }
                    }
                    else
                    {
                        l.precio_unitario = 0;
                        l.precio_unitarioSpecified = false;
                    }
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
				BindearDropDownLists();
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
            if (Punto_VentaTextBox.Text.Equals(string.Empty))
            {
                throw new Exception("Debe definir el punto de venta antes de editar un detalle");
            }
            
            cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationSettings.AppSettings["Cultura"]);

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
				l.importe_total_articulo = Convert.ToDouble(auxTotal, cedeiraCultura);
			}
			else
			{
				throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
			}

			string auxNull = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtimporte_alicuota_articulo")).Text;
			if (!auxNull.Equals(string.Empty) && !auxNull.Equals("0"))
			{
				double auxImporteIVA = Convert.ToDouble(auxNull);
				l.importe_ivaSpecified = true;
				l.importe_iva = auxImporteIVA;
			}
			else
			{
				l.importe_ivaSpecified = false;
				l.importe_iva = 0;
			}

            double auxAliIVA = Convert.ToDouble(((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlalicuota_articuloEdit")).SelectedValue);
            string auxDescAliIVA = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlalicuota_articuloEdit")).SelectedItem.Text;
			if (!auxDescAliIVA.Equals(string.Empty))
			{
				l.alicuota_ivaSpecified = true;
				l.alicuota_iva = auxAliIVA;
			}
			else
			{
                if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                        int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                        if (listaPV.Contains(auxPV))
                        {
                            throw new Exception("Detalle no actualizado porque la alicuota iva es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.alicuota_ivaSpecified = false;
                            l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                        }
                    }
                    else
                    {
                        l.alicuota_ivaSpecified = false;
                        l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                    }
                }
                else
                {
                    l.alicuota_ivaSpecified = false;
                    l.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
                }
            }
            string auxUnidad=((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlunidadEdit")).SelectedItem.Value;
            if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                {
                    System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                    int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                    if (listaPV.Contains(auxPV))
                    {
                        if (auxUnidad.Equals(string.Empty) || auxUnidad.Equals("0"))
                        {
                            throw new Exception("Detalle no actualizado porque la unidad es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.unidad = auxUnidad;
                        }
                    }
                    else
                    {
                        l.unidad = auxUnidad;
                    }
                }
                else
                {
                    l.unidad = auxUnidad;
                }
            }
            else
            {
                l.unidad = auxUnidad;
            }

            string auxCantidad = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcantidad")).Text;
            if (!auxCantidad.Contains(","))
            {
                if (!auxCantidad.Equals(string.Empty) && !auxCantidad.Equals("0"))
                {
                    l.cantidad = Convert.ToDouble(auxCantidad, cedeiraCultura);
                    l.cantidadSpecified = true;
                }
                else
                {
                    if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                        {
                            System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                            int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                            if (listaPV.Contains(auxPV))
                            {
                                throw new Exception("Detalle no actualizado porque la cantidad es obligatoria para bono fiscal");
                            }
                            else
                            {
                                l.cantidadSpecified = false;
                                l.cantidad = 0;
                            }
                        }
                        else
                        {
                            l.cantidadSpecified = false;
                            l.cantidad = 0;
                        }
                    }
                    else
                    {
                        l.cantidadSpecified = false;
                        l.cantidad = 0;
                    }
                }
            }
            else
            {
                throw new Exception("Detalle no actualizado porque el separador de decimales debe ser el punto");
            }
            
            string auxcodigo_producto_comprador = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpcomprador")).Text;
            if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                {
                    System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                    int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                    if (listaPV.Contains(auxPV))
                    {
                        if (auxcodigo_producto_comprador.Equals(string.Empty))
                        {
                            throw new Exception("Detalle no actualizado porque el codigo producto comprador es obligatorio para bono fiscal");
                        }
                        else
                        {
                            l.codigo_producto_comprador = auxcodigo_producto_comprador;
                        }
                    }
                    else
                    {
                        l.codigo_producto_comprador = auxcodigo_producto_comprador;
                    }
                }
                else
                {
                    l.codigo_producto_comprador = auxcodigo_producto_comprador;                    
                }
            }
            else
            {
                l.codigo_producto_comprador = auxcodigo_producto_comprador;
            }
            
            string auxcodigo_producto_vendedor = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtcpvendedor")).Text;
            l.codigo_producto_vendedor = auxcodigo_producto_vendedor;

            string auxindicacion_exento_gravado = ((DropDownList)detalleGridView.Rows[e.RowIndex].FindControl("ddlindicacion_exento_gravadoEdit")).SelectedItem.Value;
            if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                {
                    System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                    int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                    if (listaPV.Contains(auxPV))
                    {
                        if (auxindicacion_exento_gravado.Equals(string.Empty))
                        {
                            throw new Exception("Detalle no actualizado porque la indicacion exento gravado es obligatoria para bono fiscal");
                        }
                        else
                        {
                            l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                        }
                    }
                    else
                    {
                        l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                    }
                }
                else
                {
                    l.indicacion_exento_gravado = auxindicacion_exento_gravado;
                }
            }
            else
            {
                l.indicacion_exento_gravado = auxindicacion_exento_gravado;
            }


            string auxprecio_unitario = ((TextBox)detalleGridView.Rows[e.RowIndex].FindControl("txtprecio_unitario")).Text;
            if (!auxprecio_unitario.Equals(string.Empty) && !auxprecio_unitario.Equals("0"))
            {
                double auxPU = Convert.ToDouble(auxprecio_unitario, cedeiraCultura);
                l.precio_unitario = auxPU;
                l.precio_unitarioSpecified = true;
            }
            else
            {
                if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    {
                        System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                        int auxPV = Convert.ToInt32(((TextBox)Punto_VentaTextBox).Text);
                        if (listaPV.Contains(auxPV))
                        {
                            throw new Exception("Detalle no actualizado porque el precio unitario es obligatorio para bono fiscal");
                        }
                        else
                        {
                            l.precio_unitario = 0;
                            l.precio_unitarioSpecified = false;
                        }
                    }
                    else
                    {
                        l.precio_unitario = 0;
                        l.precio_unitarioSpecified = false;
                    }
                }
                else
                {
                    l.precio_unitario = 0;
                    l.precio_unitarioSpecified = false;
                }
            }


			detalleGridView.EditIndex = -1;
			detalleGridView.DataSource = ViewState["lineas"];
			detalleGridView.DataBind();
			BindearDropDownLists();

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
		BindearDropDownLists();

		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataValueField = "Codigo";
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataTextField = "Descr";
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataSource = FeaEntidades.IVA.IVA.Lista();
		((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).DataBind();
		try
		{
			ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlalicuota_articuloEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].alicuota_iva.ToString());
			li.Selected = true;
		}
		catch
		{
		}

        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataValueField = "Codigo";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataTextField = "Descr";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).DataBind();
        try
        {
            ListItem liUnidad = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlunidadEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].unidad.ToString());
            liUnidad.Selected = true;
        }
        catch
        {
        }

        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataValueField = "Codigo";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataTextField = "Descr";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.ListaDetalle();
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).DataBind();
        try
        {
            ListItem liIndExento = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlindicacion_exento_gravadoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"])[e.NewEditIndex].indicacion_exento_gravado.ToString());
            liIndExento.Selected = true;
        }
        catch
        {
        }
	}
	protected void detalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		detalleGridView.EditIndex = -1;
		detalleGridView.DataSource = ViewState["lineas"];
		detalleGridView.DataBind();
		BindearDropDownLists();
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
			BindearDropDownLists();
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
        if (((Button)sender).ID == "DescargarButton" && CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!MonedaComprobanteDropDownList.Enabled)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
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
                if (((Button)sender).ID == "DescargarButton")
                {
                    //Descarga directa del XML
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"Temp/" + sb.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    Response.Redirect("~/DescargaTemporarios.aspx?archivo=" + sb.ToString(), false);
                }
                else
                {
                    if (((CedWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion)
                    {
                        //ModoDepuracion encendido
                        System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"Temp/" + sb.ToString()), System.IO.FileMode.Create);
                        m.WriteTo(fs);
                        fs.Close();
                    }
                    //Envio por mail del XML
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
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                    contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                    contentType.Name = sb.ToString();
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m, contentType);
                    mail.Attachments.Add(attachment);
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.Body = AgregarBody();
                    if (smtpXAmb.Equals("DESA"))
                    {
                        smtpClient.Host = "vsmtpr.bancogalicia.com.ar";
                    }
                    else
                    {
                        smtpClient.Host = "localhost";
                    }
                    smtpClient.Send(mail);
                }
                m.Close();


                //Registro cantidad de comprobantes
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
                {
                    CedWebRN.Cuenta.RegistrarComprobante(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                }


                //Envío de mail a nosotros
                if (!smtpXAmb.Equals("DESA"))
                {
                    System.Net.Mail.MailMessage mailCedeira = new System.Net.Mail.MailMessage("facturaelectronicaxml@cedeira.com.ar",
                        "facturaelectronicaxml@cedeira.com.ar", "XML_" + lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString() + "_" + System.DateTime.Now.ToLocalTime().ToString("yyyyMMdd hh:mm:ss"), string.Empty);
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

    protected void referenciasGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        referenciasGridView.EditIndex = -1;
        referenciasGridView.DataSource = ViewState["referencias"];
        referenciasGridView.DataBind();
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
                    throw new Exception("Referencia no agregada porque el codigo de referencia no puede estar vacío");
                }
                string auxDatoRef = ((TextBox)referenciasGridView.FooterRow.FindControl("txtdato_de_referencia")).Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(auxDatoRef, "^[0-9]+$"))
                {
                    r.dato_de_referencia = Convert.ToInt64(auxDatoRef);
                }
                else
                {
                    throw new Exception("Referencia no agregada porque el dato de referencia debe ser numérico y entero");
                }
                ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Add(r);
                //Me fijo si elimino la fila automática
                System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
                if (refs[0].codigo_de_referencia == 0)
                {
                    ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Remove(refs[0]);
                }
                referenciasGridView.DataSource = ViewState["referencias"];
                referenciasGridView.DataBind();
                BindearDropDownLists();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
            }
        }
    }
    protected void referenciasGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
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

        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataValueField = "Codigo";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataTextField = "Descr";
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
        ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
        try
        {
            ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].codigo_de_referencia.ToString());
            li.Selected = true;
        }
        catch
        {
        }
    }
    protected void referenciasGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</script>");
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
                throw new Exception("Referencia no actualizada porque el codigo de referencia no puede estar vacío");
            }
            string auxDatoRef = ((TextBox)referenciasGridView.Rows[e.RowIndex].FindControl("txtdato_de_referencia")).Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(auxDatoRef, "^[0-9]+$"))
            {
                r.dato_de_referencia = Convert.ToInt64(auxDatoRef);
            }
            else
            {
                throw new Exception("Referencia no agregada porque el dato de referencia debe ser numérico y entero");
            }
            referenciasGridView.EditIndex = -1;
            referenciasGridView.DataSource = ViewState["referencias"];
            referenciasGridView.DataBind();
            BindearDropDownLists();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</script>");
        }
    }

	protected void FileUploadButton_Click(object sender, EventArgs e)
	{
        if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!MonedaComprobanteDropDownList.Enabled)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
            }
        }
        else
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
                        CompletarUI(lc, e);
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

    private void CompletarUI(FeaEntidades.InterFacturas.lote_comprobantes lc, EventArgs e)
    {
        //Cabecera
        Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
        Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
        Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
        Punto_VentaTextBox.Text = Convert.ToString(lc.cabecera_lote.punto_de_venta);
        Punto_VentaTextBox_TextChanged(Punto_VentaTextBox, e);
        //Comprobante
        Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
        FechaEmisionDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
        FechaVencimientoDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
        FechaServDesdeDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
        FechaServHastaDatePickerWebUserControl.CalendarDateString = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
        Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
        IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
        CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));
        //Referencias
        if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
        {
            referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
            foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
            {
                //descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
                //Se busca la descripción a través del código.
                string descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue = r.codigo_de_referencia.ToString();
                descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
                r.descripcioncodigo_de_referencia = descrcodigo;
                referencias.Add(r);
            }
            if(referencias.Count.Equals(0))
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
        lineas = new System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>();
        foreach (FeaEntidades.InterFacturas.linea l in lc.comprobante[0].detalle.linea)
        {
            FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
            linea.descripcion = l.descripcion;
            if (l.alicuota_ivaSpecified)
            {
                linea.alicuota_iva = l.alicuota_iva;
            }
            else
            {
                linea.alicuota_iva = new FeaEntidades.IVA.SinInformar().Codigo;
            }
            linea.alicuota_ivaSpecified = l.alicuota_ivaSpecified;
            linea.importe_ivaSpecified = l.importe_ivaSpecified;
            if (l.unidad != null)
            {
                linea.unidad = l.unidad;
            }
            else
            {
                linea.unidad = Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo);
            }
            linea.cantidad = l.cantidad;
            linea.cantidadSpecified = l.cantidadSpecified;
            linea.codigo_producto_comprador = l.codigo_producto_comprador;
            linea.codigo_producto_vendedor = l.codigo_producto_vendedor;
            linea.indicacion_exento_gravado = l.indicacion_exento_gravado;

            if (l.importes_moneda_origen == null)
            {
                linea.importe_total_articulo = l.importe_total_articulo;
                linea.importe_iva = l.importe_iva;
                linea.precio_unitario = l.precio_unitario;
                linea.precio_unitarioSpecified = l.precio_unitarioSpecified;
            }
            else
            {
                linea.importe_total_articulo = l.importes_moneda_origen.importe_total_articulo;
                linea.importe_iva = l.importes_moneda_origen.importe_iva;
                linea.precio_unitario = l.importes_moneda_origen.precio_unitario;
                linea.precio_unitarioSpecified = l.importes_moneda_origen.precio_unitarioSpecified;
            }
            lineas.Add(linea);
        }
        detalleGridView.DataSource = lineas;
        detalleGridView.DataBind();
        BindearDropDownLists();
        ViewState["lineas"] = lineas;
        //Descuentos globales
        if (lc.comprobante[0].resumen.descuentos != null)
        {
            descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
            foreach (FeaEntidades.InterFacturas.resumenDescuentos r in lc.comprobante[0].resumen.descuentos)
            {
                if (r.importe_descuento_moneda_origenSpecified)
                {
                    r.importe_descuento = r.importe_descuento_moneda_origen;
                }
                descuentos.Add(r);
            }
            if (descuentos.Count.Equals(0))
            {
                descuentos.Add(new FeaEntidades.InterFacturas.resumenDescuentos());
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
                if (imp.importe_impuesto_moneda_origenSpecified)
                {
                    imp.importe_impuesto = imp.importe_impuesto_moneda_origen;
                }
                impuestos.Add(imp);
            }
            if (impuestos.Count.Equals(0))
            {
                impuestos.Add(new FeaEntidades.InterFacturas.resumenImpuestos());
            }
            impuestosGridView.DataSource = impuestos;
            impuestosGridView.DataBind();
            ViewState["impuestos"] = impuestos;
        }
        ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;
        //Resumen
        MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].resumen.codigo_moneda)));
        Tipo_de_cambioTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.tipo_de_cambio);
        if (lc.comprobante[0].resumen.codigo_moneda.Equals("PES"))
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
        if (!lc.comprobante[0].resumen.codigo_moneda.Equals("PES"))
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
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
        }
        else
        {
            System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
            if (!MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
            {
                Tipo_de_cambioLabel.Visible = true;
                Tipo_de_cambioTextBox.Visible = true;
                Tipo_de_cambioRequiredFieldValidator.Enabled = true;
                Tipo_de_cambioRegularExpressionValidator.Enabled = true;

                for (int i = 0; i < listadelineas.Count; i++)
                {
                    FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                    limo.importe_total_articuloSpecified = true;
                    limo.importe_total_articulo = listadelineas[i].importe_total_articulo;
                    limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
                    limo.importe_iva = listadelineas[i].importe_iva;
                    limo.precio_unitario = listadelineas[i].precio_unitario;
                    limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
                    listadelineas[i].importes_moneda_origen = limo;
                }
            }
            else
            {
                Tipo_de_cambioLabel.Visible = false;
                Tipo_de_cambioTextBox.Visible = false;
                Tipo_de_cambioTextBox.Text = null;
                Tipo_de_cambioRequiredFieldValidator.Enabled = false;
                Tipo_de_cambioRegularExpressionValidator.Enabled = false;

                for (int i = 0; i < listadelineas.Count; i++)
                {
                    if (listadelineas[i].importes_moneda_origen != null)
                    {
                        listadelineas[i].importe_total_articulo = listadelineas[i].importes_moneda_origen.importe_total_articulo;
                        listadelineas[i].importe_ivaSpecified = listadelineas[i].importes_moneda_origen.importe_ivaSpecified;
                        listadelineas[i].importe_iva = listadelineas[i].importes_moneda_origen.importe_iva;
                        listadelineas[i].precio_unitario = listadelineas[i].importes_moneda_origen.precio_unitario;
                        listadelineas[i].precio_unitarioSpecified = listadelineas[i].importes_moneda_origen.precio_unitarioSpecified;
                    }
                }
            }
        }
	}
	protected void CompradorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
	{
        if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
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
                Domicilio_Calle_CompradorTextBox.Text = comprador.Calle;
                Domicilio_Numero_CompradorTextBox.Text = comprador.Nro;
                Domicilio_Piso_CompradorTextBox.Text = comprador.Piso;
                Domicilio_Depto_CompradorTextBox.Text = comprador.Depto;
                Domicilio_Sector_CompradorTextBox.Text = comprador.Sector;
                Domicilio_Torre_CompradorTextBox.Text = comprador.Torre;
                Domicilio_Manzana_CompradorTextBox.Text = comprador.Manzana;
                Localidad_CompradorTextBox.Text = comprador.Localidad;
                Provincia_CompradorDropDownList.SelectedValue = comprador.IdProvincia;
                Cp_CompradorTextBox.Text = comprador.CodPost;
                Contacto_CompradorTextBox.Text = comprador.NombreContacto;
                Email_CompradorTextBox.Text = comprador.EmailContacto;
                Telefono_CompradorTextBox.Text = Convert.ToString(comprador.TelefonoContacto);
                Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.IdTipoDoc);
                Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(comprador.NroDoc);
                Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIVA);
                //NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
                //CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
                string auxGLN = Convert.ToString(comprador.GLN);
                if (!auxGLN.Equals("0"))
                {
                    GLN_CompradorTextBox.Text = auxGLN;
                }
                Codigo_Interno_CompradorTextBox.Text = comprador.CodigoInterno;
                if (!comprador.FechaInicioActividades.Equals(new DateTime(9999, 12, 31)))
                {
                    InicioDeActividadesCompradorDatePickerWebUserControl.CalendarDate = comprador.FechaInicioActividades;
                }
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
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
                Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = Convert.ToString(80);
                Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(0);
                //NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
                //CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
                GLN_CompradorTextBox.Text = string.Empty;
                Codigo_Interno_CompradorTextBox.Text = string.Empty;
                ((TextBox)InicioDeActividadesCompradorDatePickerWebUserControl.FindControl("txt_Date")).Text = string.Empty;
            }
		}
	}
    protected void CalcularTotalesButton_Click(object sender, EventArgs e)
    {
        if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!MonedaComprobanteDropDownList.Enabled)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
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
                System.Collections.Generic.List<FeaEntidades.InterFacturas.linea> listadelineas = (System.Collections.Generic.List<FeaEntidades.InterFacturas.linea>)ViewState["lineas"];
                double totalGravado = 0;
                double totalNoGravado = 0;
                double totalIVA = 0;
                for (int i = 0; i < listadelineas.Count; i++)
                {
                    if (listadelineas[i].descripcion == null)
                    {
                        throw new Exception("Debe informar al menos un artículo");
                    }
                    if (listadelineas[i].importe_iva != 0)
                    {
                        totalGravado += listadelineas[i].importe_total_articulo;
                    }
                    else
                    {
                        totalNoGravado += listadelineas[i].importe_total_articulo;
                    }
                    totalIVA += listadelineas[i].importe_iva;
                }
                //Proceso DESCUENTOS GLOBALES
                System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> listadedescuentos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"];
                for (int i = 0; i < listadedescuentos.Count; i++)
                {
                    if (listadedescuentos[i].descripcion_descuento != null && !listadedescuentos[i].descripcion_descuento.Equals(string.Empty))
                    {
                        totalNoGravado -= listadedescuentos[i].importe_descuento;
                    }
                }
                //Proceso IMPUESTOS GLOBALES
                double total_Impuestos_Nacionales = 0;
                double total_Impuestos_Internos = 0;
                double total_Ingresos_Brutos = 0;
                double total_Impuestos_Municipales = 0;
                System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"];
                for (int i = 0; i < listadeimpuestos.Count; i++)
                {
                    if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
                    {
                        if (listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.IVA().Codigo ||
                            listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.Otros().Codigo ||
                            listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.Nacionales().Codigo)
                        {
                            total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
                        }
                        else if (listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.Internos().Codigo)
                        {
                            total_Impuestos_Internos += listadeimpuestos[i].importe_impuesto;
                        }
                        else if (listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.IB().Codigo)
                        {
                            total_Ingresos_Brutos += listadeimpuestos[i].importe_impuesto;
                        }
                        else if (listadeimpuestos[i].codigo_impuesto == new FeaEntidades.CodigosImpuesto.Municipales().Codigo)
                        {
                            total_Impuestos_Municipales += listadeimpuestos[i].importe_impuesto;
                        }
                        else
                        {
                            throw new Exception("Código del impuesto inválido");
                        }
                    }
                }
                //Asigno totales
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = totalGravado.ToString();
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = totalNoGravado.ToString();
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
                double total = totalGravado + totalNoGravado + totalIVA + total_Impuestos_Nacionales + total_Impuestos_Internos + total_Ingresos_Brutos + total_Impuestos_Municipales;
                Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al calcular los totales.\\n " + ex.Message + "');</script>");
            }
            finally
            {
                //Restauro totales no informados
                if (Importe_Total_Impuestos_Municipales_ResumenTextBox.Text == "0") Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = String.Empty;
                if (Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text == "0") Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = String.Empty;
                if (Importe_Total_Ingresos_Brutos_ResumenTextBox.Text == "0") Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = String.Empty;
                if (Importe_Total_Impuestos_Internos_ResumenTextBox.Text == "0") Importe_Total_Impuestos_Internos_ResumenTextBox.Text = String.Empty;
            }
        }
    }
    protected void Punto_VentaTextBox_TextChanged(object sender, EventArgs e)
    {
        if (CedWebRN.Fun.EstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!((TextBox)sender).Text.Equals(string.Empty))
            {
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal != null)
                {
                    System.Collections.Generic.List<int> listaPV = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.BonoFiscal.PuntoDeVentaHabilitado;
                    int auxPV = Convert.ToInt32(((TextBox)sender).Text);
                    if (listaPV.Contains(auxPV))
                    {
                        Presta_ServCheckBox.Checked = false;
                        Presta_ServCheckBox.Enabled = false;
                        FechaServDesdeDatePickerWebUserControl.CalendarDateString = string.Empty;
                        FechaServDesdeDatePickerWebUserControl.Visible = false;
                        FechaInicioServLabel.Visible = false;
                        FechaHstServLabel.Visible = false;
                        FechaServHastaDatePickerWebUserControl.CalendarDateString = string.Empty;
                        FechaServHastaDatePickerWebUserControl.Visible = false;
                        Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
                        Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
                        Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaParaBienesDeCapital();
                    }
                    else
                    {
                        Presta_ServCheckBox.Checked = true;
                        Presta_ServCheckBox.Enabled = true;
                        FechaServDesdeDatePickerWebUserControl.Visible = true;
                        FechaInicioServLabel.Visible = true;
                        FechaHstServLabel.Visible = true;
                        FechaServHastaDatePickerWebUserControl.Visible = true;
                        Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
                        Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
                        Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
                    }
                    Tipo_De_ComprobanteDropDownList.DataBind();
                }
            }
        }
    }
    protected void EnviarIBKButton_Click(object sender, EventArgs e)
    {
        if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!MonedaComprobanteDropDownList.Enabled)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
            }
        }
        else
        {
            if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta != null && ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdTipoCuenta.Equals("Admin"))
            {
                try
                {
                    CedWebRN.Comprobante cRN = new CedWebRN.Comprobante();
                    FeaEntidades.InterFacturas.lote_comprobantes lc = GenerarLote();
                    CedWebRN.IBK.lote_comprobantes_response lcr = cRN.EnviarIBK(lc, Server.MapPath("~/Autenticado/Certificados/interfacturas-" + lc.cabecera_lote.cuit_vendedor + ".cer"));
                    if (!((CedWebRN.IBK.lote_response)lcr.Item).estado.Equals("OK"))
                    {
                        if (((CedWebRN.IBK.lote_response)lcr.Item).errores_lote!=null)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Interfacturas dice:" + ((CedWebRN.IBK.lote_response)lcr.Item).errores_lote[0].descripcion_error + "')</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Interfacturas dice:" + ((CedWebRN.IBK.lote_response)lcr.Item).comprobante_response[0].errores_comprobante[0].descripcion_error + "')</script>");
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Comprobante enviado satisfactoriamente a Interfacturas.')</script>");
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a Interfacturas.\\n " + ex.Message + "');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad está en etapa de prueba');</script>");
            }
        }
    }

    private FeaEntidades.InterFacturas.lote_comprobantes GenerarLote()
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

        if (!MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
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

        System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> listareferencias = (System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"];
        for (int i = 0; i < listareferencias.Count; i++)
        {
            if (listareferencias[i].descripcioncodigo_de_referencia != null)
            {
                infcomprob.referencias[i] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                infcomprob.referencias[i].codigo_de_referencia = Convert.ToInt32(listareferencias[i].codigo_de_referencia);
                infcomprob.referencias[i].descripcioncodigo_de_referencia = listareferencias[i].descripcioncodigo_de_referencia;
                infcomprob.referencias[i].dato_de_referencia = listareferencias[i].dato_de_referencia;
            }
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
            det.linea[i].alicuota_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
            if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
            {
                det.linea[i].alicuota_iva = listadelineas[i].alicuota_iva;
            }
            if (!listadelineas[i].unidad.Equals(Convert.ToString(new FeaEntidades.CodigosUnidad.SinInformar().Codigo)))
            {
                det.linea[i].unidad = listadelineas[i].unidad;
            }
            det.linea[i].cantidad = listadelineas[i].cantidad;
            det.linea[i].cantidadSpecified = listadelineas[i].cantidadSpecified;
            det.linea[i].codigo_producto_comprador = listadelineas[i].codigo_producto_comprador;
            det.linea[i].codigo_producto_vendedor = listadelineas[i].codigo_producto_vendedor;
            if (listadelineas[i].indicacion_exento_gravado != null)
            {
                if (!listadelineas[i].indicacion_exento_gravado.Equals(string.Empty))
                {
                    det.linea[i].indicacion_exento_gravado = listadelineas[i].indicacion_exento_gravado;
                }
            }
            if (MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
            {
                det.linea[i].importe_total_articulo = listadelineas[i].importe_total_articulo;
                det.linea[i].importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
                det.linea[i].importe_iva = listadelineas[i].importe_iva;
                det.linea[i].precio_unitario = listadelineas[i].precio_unitario;
                det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
            }
            else
            {
                det.linea[i].importe_total_articulo = Math.Round(listadelineas[i].importe_total_articulo * Convert.ToDouble(Tipo_de_cambioTextBox.Text), 2);
                det.linea[i].importe_iva = Math.Round(listadelineas[i].importe_iva * Convert.ToDouble(Tipo_de_cambioTextBox.Text), 2);
                det.linea[i].importe_ivaSpecified = listadelineas[i].alicuota_ivaSpecified;
                det.linea[i].precio_unitario = Math.Round(listadelineas[i].precio_unitario * Convert.ToDouble(Tipo_de_cambioTextBox.Text), 2);
                det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;

                FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                limo.importe_total_articuloSpecified = true;
                limo.importe_total_articulo = listadelineas[i].importe_total_articulo;
                limo.importe_ivaSpecified = listadelineas[i].importe_ivaSpecified;
                limo.importe_iva = listadelineas[i].importe_iva;
                limo.precio_unitario = listadelineas[i].precio_unitario;
                limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
                det.linea[i].importes_moneda_origen = limo;
            }
        }

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

        if (MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
        //Moneda local
        {
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
        }
        else
        //Moneda extranjera
        {
            double tipodecambio = Convert.ToDouble(Tipo_de_cambioTextBox.Text);

            FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();

            r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
            r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
            r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
            r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
            r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);

            try
            {
                r.importe_total_impuestos_nacionales = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
                if (r.importe_total_impuestos_nacionales != 0)
                {
                    r.importe_total_impuestos_nacionalesSpecified = true;
                    rimo.importe_total_impuestos_nacionalesSpecified = true;
                }
            }
            catch
            {
            }
            try
            {
                r.importe_total_ingresos_brutos = Math.Round(Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
                if (r.importe_total_ingresos_brutos != 0)
                {
                    r.importe_total_ingresos_brutosSpecified = true;
                    rimo.importe_total_ingresos_brutosSpecified = true;
                }
            }
            catch
            {
            }
            try
            {
                r.importe_total_impuestos_municipales = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
                if (r.importe_total_impuestos_municipales != 0)
                {
                    r.importe_total_impuestos_municipalesSpecified = true;
                    rimo.importe_total_impuestos_municipalesSpecified = true;
                }
            }
            catch
            {
            }
            try
            {
                r.importe_total_impuestos_internos = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
                if (r.importe_total_impuestos_internos != 0)
                {
                    r.importe_total_impuestos_internosSpecified = true;
                    rimo.importe_total_impuestos_internosSpecified = true;
                }
            }
            catch
            {
            }
            r.importe_total_factura = Math.Round(Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);

            r.importes_moneda_origen = rimo;
        }


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
                comp.resumen.impuestos[i].porcentaje_impuesto = listadeimpuestos[i].porcentaje_impuesto;
                comp.resumen.impuestos[i].porcentaje_impuestoSpecified = listadeimpuestos[i].porcentaje_impuestoSpecified;
                if (MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
                {
                    comp.resumen.impuestos[i].importe_impuesto = listadeimpuestos[i].importe_impuesto;
                }
                else
                {
                    comp.resumen.impuestos[i].importe_impuesto = Math.Round(listadeimpuestos[i].importe_impuesto * Convert.ToDouble(Tipo_de_cambioTextBox.Text), 2);
                    comp.resumen.impuestos[i].importe_impuesto_moneda_origen = listadeimpuestos[i].importe_impuesto;
                    comp.resumen.impuestos[i].importe_impuesto_moneda_origenSpecified = true;
                }
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
                comp.resumen.descuentos[i].importe_iva_descuento = listadedescuentos[i].importe_iva_descuento;
                comp.resumen.descuentos[i].importe_iva_descuento_moneda_origen = listadedescuentos[i].importe_iva_descuento_moneda_origen;
                comp.resumen.descuentos[i].importe_iva_descuento_moneda_origenSpecified = listadedescuentos[i].importe_iva_descuento_moneda_origenSpecified;
                comp.resumen.descuentos[i].importe_iva_descuentoSpecified = listadedescuentos[i].importe_iva_descuentoSpecified;
                comp.resumen.descuentos[i].porcentaje_descuento = listadedescuentos[i].porcentaje_descuento;
                comp.resumen.descuentos[i].porcentaje_descuentoSpecified = listadedescuentos[i].porcentaje_descuentoSpecified;

                if (MonedaComprobanteDropDownList.SelectedValue.Equals("PES"))
                {
                    comp.resumen.descuentos[i].importe_descuento = listadedescuentos[i].importe_descuento;
                }
                else
                {
                    comp.resumen.descuentos[i].importe_descuento = Math.Round(listadedescuentos[i].importe_descuento * Convert.ToDouble(Tipo_de_cambioTextBox.Text), 2);
                    comp.resumen.descuentos[i].importe_descuento_moneda_origen = listadedescuentos[i].importe_descuento;
                    comp.resumen.descuentos[i].importe_descuento_moneda_origenSpecified = true;
                }
            }
        }
        if (!CAETextBox.Text.Equals(string.Empty))
        {
            comp.cabecera.informacion_comprobante.cae = CAETextBox.Text;
            comp.cabecera.informacion_comprobante.fecha_obtencion_cae = FechaCAEObtencionDatePickerWebUserControl.CalendarDateString;
            comp.cabecera.informacion_comprobante.fecha_vencimiento_cae = FechaCAEVencimientoDatePickerWebUserControl.CalendarDateString;
            comp.cabecera.informacion_comprobante.resultado = ResultadoTextBox.Text;
            comp.cabecera.informacion_comprobante.motivo = MotivoTextBox.Text;
        }
        lote.comprobante[0] = comp;
        return lote;
    }
    protected void ConsultarLoteIBKButton_Click(object sender, EventArgs e)
    {
        if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
        {
            if (!MonedaComprobanteDropDownList.Enabled)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesion ha caducado por inactividad. Por favor vuelva a loguearse.')</script>");
            }
        }
        else
        {
            if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta!=null && ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.IdTipoCuenta.Equals("Admin"))
            {
                try
                {
                    CedWebRN.Comprobante cRN = new CedWebRN.Comprobante();
                    CedWebRN.IBK.consulta_lote_comprobantes clc = new CedWebRN.IBK.consulta_lote_comprobantes();
                    clc.cuit_canal = Convert.ToInt64(Cuit_CanalTextBox.Text);
                    if (!Cuit_VendedorTextBox.Text.Equals(string.Empty))
                    {
                        clc.cuit_vendedor = Convert.ToInt64(Cuit_VendedorTextBox.Text);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el CUIT del vendedor');</script>");
                        return;
                    }
                    if (!Id_LoteTextbox.Text.Equals(string.Empty))
                    {
                        clc.id_lote = Convert.ToInt64(Id_LoteTextbox.Text);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el nro de lote');</script>");
                        return;
                    }
                    CedWebRN.IBK.consulta_lote_comprobantes_response clcr = cRN.ConsultarIBK(clc, Server.MapPath("~/Autenticado/Certificados/interfacturas-" + clc.cuit_vendedor + ".cer"));
                    try
                    {
                        CedWebRN.IBK.lote_comprobantes lcIBK = ((CedWebRN.IBK.lote_comprobantes)(((CedWebRN.IBK.consulta_lote_response)(clcr.Item)).Item));
                        if (lcIBK.cabecera_lote.resultado.Equals("A"))
                        {
                            CompletarUI(cRN.Ibk2FEA(lcIBK), e);

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ((CedWebRN.IBK.lote_comprobantes)(((CedWebRN.IBK.consulta_lote_response)(clcr.Item)).Item)).cabecera_lote.resultado + ":" + ((CedWebRN.IBK.lote_comprobantes)(((CedWebRN.IBK.consulta_lote_response)(clcr.Item)).Item)).cabecera_lote.motivo + "');</script>");
                        }
                    }
                    catch (InvalidCastException ex)
                    {
                        string errorConsultaLote = ((CedWebRN.IBK.consulta_lote_responseErrores_consulta)(((CedWebRN.IBK.consulta_lote_response)(clcr.Item)).Item)).error[0].descripcion_error;
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + errorConsultaLote + "');</script>");
                    }
                }
                catch (System.Security.Cryptography.CryptographicException ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su certificado no se encuentra en nuestro repositorio');</script>");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al consultar a Interfacturas.\\n " + ex.Message + "');</script>");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad está en etapa de prueba');</script>");
            }
        }
    }
}
