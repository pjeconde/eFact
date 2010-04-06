using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedeiraAJAX.Vendedor
{
    public partial class Default : System.Web.UI.Page
    {
        List<CedWebEntidades.PuntoDeVenta> puntosDeVenta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RazonSocialTextBox.Focus();
                try
                {
                    if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
                    else
                    {
                        ProvinciaDropDownList.DataValueField = "Codigo";
                        ProvinciaDropDownList.DataTextField = "Descr";
                        ProvinciaDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.ListaInf();
                        CondIVADropDownList.DataValueField = "Codigo";
                        CondIVADropDownList.DataTextField = "Descr";
                        CondIVADropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaInf();
                        CondIngBrutosDropDownList.DataValueField = "Codigo";
                        CondIngBrutosDropDownList.DataTextField = "Descr";
                        CondIngBrutosDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.ListaInf();
                        //Leo datos actuales
                        CedWebEntidades.Vendedor vendedor = new CedWebEntidades.Vendedor();
                        vendedor.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;

                        puntosDeVenta = new List<CedWebEntidades.PuntoDeVenta>();
                        CedWebEntidades.PuntoDeVenta puntoDeVenta = new CedWebEntidades.PuntoDeVenta();
                        puntosDeVenta.Add(puntoDeVenta);
                        puntosDeVentaGridView.DataSource = puntosDeVenta;

                        try
                        {
                            CedWebRN.Vendedor.Leer(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                            RazonSocialTextBox.Text = vendedor.RazonSocial;
                            CalleTextBox.Text = vendedor.Domicilio.Calle;
                            NroTextBox.Text = vendedor.Domicilio.Nro;
                            PisoTextBox.Text = vendedor.Domicilio.Piso;
                            DeptoTextBox.Text = vendedor.Domicilio.Depto;
                            SectorTextBox.Text = vendedor.Domicilio.Sector;
                            TorreTextBox.Text = vendedor.Domicilio.Torre;
                            ManzanaTextBox.Text = vendedor.Domicilio.Manzana;
                            LocalidadTextBox.Text = vendedor.Domicilio.Localidad;
                            ProvinciaDropDownList.SelectedValue = vendedor.Domicilio.IdProvincia;
                            CodPostTextBox.Text = vendedor.Domicilio.CodPost;
                            NombreContactoTextBox.Text = vendedor.NombreContacto;
                            EmailContactoTextBox.Text = vendedor.EmailContacto;
                            TelefonoContactoTextBox.Text = Convert.ToString(vendedor.TelefonoContacto);
                            CUITTextBox.Text = Convert.ToString(vendedor.CUIT);
                            CondIVADropDownList.SelectedValue = Convert.ToString(vendedor.IdCondIVA);
                            NroIngBrutosTextBox.Text = vendedor.NroIngBrutos;
                            CondIngBrutosDropDownList.SelectedValue = Convert.ToString(vendedor.IdCondIngBrutos);
                            string auxGLN = Convert.ToString(vendedor.GLN);
                            if (!auxGLN.Equals("0"))
                            {
                                GLNTextBox.Text = auxGLN;
                            }
                            CodigoInternoTextBox.Text = vendedor.CodigoInterno;
                            FechaInicioActividadesDatePickerWebUserControl.CalendarDate = vendedor.FechaInicioActividades;
                            if (vendedor.PuntosDeVenta.Count > 0)
                            {
                                puntosDeVenta.Clear();
                                for (int i = 0; i < vendedor.PuntosDeVenta.Count; i++)
                                {
                                    puntosDeVenta.Add(vendedor.PuntosDeVenta[i]);
                                }
                            }
                        }
                        catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
                        {
                        }
                        ViewState["puntosDeVenta"] = puntosDeVenta;

                        DataBind();
                        BindearDropDownLists();
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                }
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebEntidades.Vendedor vendedor = DatosVendedor();
                CedWebRN.Vendedor.Validar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Guardar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Copiar(vendedor, ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor);
                Server.Transfer("~/FacturaElectronica.aspx", true);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected CedWebEntidades.Vendedor DatosVendedor()
        {
            CedWebEntidades.Vendedor vendedor = new CedWebEntidades.Vendedor();
            vendedor.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
            vendedor.NombreCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
            vendedor.RazonSocial = RazonSocialTextBox.Text;
            vendedor.Domicilio.Calle = CalleTextBox.Text;
            vendedor.Domicilio.Nro = NroTextBox.Text;
            vendedor.Domicilio.Piso = PisoTextBox.Text;
            vendedor.Domicilio.Depto = DeptoTextBox.Text;
            vendedor.Domicilio.Sector = SectorTextBox.Text;
            vendedor.Domicilio.Torre = TorreTextBox.Text;
            vendedor.Domicilio.Manzana = ManzanaTextBox.Text;
            vendedor.Domicilio.Localidad = LocalidadTextBox.Text;
            vendedor.Domicilio.IdProvincia = ProvinciaDropDownList.SelectedValue;
            vendedor.Domicilio.DescrProvincia = ProvinciaDropDownList.SelectedItem.Text;
            vendedor.Domicilio.CodPost = CodPostTextBox.Text;
            vendedor.NombreContacto = NombreContactoTextBox.Text;
            vendedor.EmailContacto = EmailContactoTextBox.Text;
            vendedor.TelefonoContacto = TelefonoContactoTextBox.Text;
            vendedor.CUIT = Convert.ToInt64(CUITTextBox.Text);
            vendedor.IdCondIVA = Convert.ToInt32(CondIVADropDownList.SelectedValue);
            vendedor.DescrCondIVA = CondIVADropDownList.SelectedItem.Text;
            vendedor.NroIngBrutos = NroIngBrutosTextBox.Text;
            vendedor.IdCondIngBrutos = Convert.ToInt32(CondIngBrutosDropDownList.SelectedValue);
            vendedor.DescrCondIngBrutos = CondIngBrutosDropDownList.SelectedItem.Text;
            if (GLNTextBox.Text == String.Empty)
            {
                vendedor.GLN = 0;
            }
            else
            {
                vendedor.GLN = Convert.ToInt64(GLNTextBox.Text);
            }
            vendedor.CodigoInterno = CodigoInternoTextBox.Text;
            vendedor.FechaInicioActividades = FechaInicioActividadesDatePickerWebUserControl.CalendarDate;

            List<CedWebEntidades.PuntoDeVenta> listaPuntosDeVenta = (List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"];
            vendedor.PuntosDeVenta.Clear();
            for (int i = 0; i < listaPuntosDeVenta.Count; i++)
            {
                if (listaPuntosDeVenta[i].Tipo.Id!=null)
                {
                    vendedor.PuntosDeVenta.Add(listaPuntosDeVenta[i]);
                }
            }
            return vendedor;
        }
        protected void BackupButton_Click(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                CedWebEntidades.Vendedor vendedor = DatosVendedor();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(vendedor.GetType());
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                x.Serialize(writerdememoria, vendedor);
                m.Seek(0, System.IO.SeekOrigin.Begin);
                string nombreArchivo = "eFact-Vendedor-" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Replace(".", String.Empty).ToUpper() + ".xml";
                System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + nombreArchivo), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();
                Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + nombreArchivo, false);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/FacturaElectronica.aspx");
        }
        private void BindearDropDownLists()
        {
            ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).DataValueField = "Id";
            ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).DataTextField = "Descr";
            ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).DataSource = CedWebEntidades.TiposPuntoDeVenta.TipoPuntoDeVenta.Lista();
            ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).DataBind();
        }
        protected void puntosDeVentaGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            puntosDeVentaGridView.EditIndex = -1;
            puntosDeVentaGridView.DataSource = ViewState["puntosDeVenta"];
            puntosDeVentaGridView.DataBind();
        }
        protected void puntosDeVentaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddpuntosDeVenta"))
            {
                try
                {
                    CedWebEntidades.PuntoDeVenta pv = new CedWebEntidades.PuntoDeVenta();
                    string auxIdTipoPuntoDeVenta = ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).SelectedValue.ToString();
                    string auxDescrTipoPuntoDeVenta = ((DropDownList)puntosDeVentaGridView.FooterRow.FindControl("ddltipo_de_punto_de_venta")).SelectedItem.Text;
                    if (!auxIdTipoPuntoDeVenta.Equals(string.Empty))
                    {
                        pv.IdTipo = auxIdTipoPuntoDeVenta;
                        pv.DescrTipo = auxDescrTipoPuntoDeVenta;
                    }
                    else
                    {
                        throw new Exception("Punto de Venta no agregado porque el Tipo de Punto de Venta no puede estar vacío");
                    }
                    string auxIdPuntoDeVenta = ((TextBox)puntosDeVentaGridView.FooterRow.FindControl("txtpunto_de_venta")).Text;
                    if (System.Text.RegularExpressions.Regex.IsMatch(auxIdPuntoDeVenta, "^[0-9]+$"))
                    {
                        pv.Id = Convert.ToInt32(auxIdPuntoDeVenta);
                    }
                    else
                    {
                        throw new Exception("Punto de Venta no agregado porque el Punto de Venta debe ser numérico y entero");
                    }
                    ((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"]).Add(pv);
                    //Me fijo si elimino la fila automática
                    List<CedWebEntidades.PuntoDeVenta> pvs = ((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"]);
                    if (pvs[0].IdTipo == null)
                    {
                        ((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"]).Remove(pvs[0]);
                    }
                    puntosDeVentaGridView.DataSource = ViewState["puntosDeVenta"];
                    puntosDeVentaGridView.DataBind();
                    BindearDropDownLists();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
                }
            }
        }
        protected void puntosDeVentaGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
                e.ExceptionHandled = true;
            }
        }
        protected void puntosDeVentaGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<CedWebEntidades.PuntoDeVenta> pvs = ((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"]);
                CedWebEntidades.PuntoDeVenta pv = pvs[e.RowIndex];
                pvs.Remove(pv);
                if (pvs.Count.Equals(0))
                {
                    CedWebEntidades.PuntoDeVenta nuevo = new CedWebEntidades.PuntoDeVenta();
                    pvs.Add(nuevo);
                }
                puntosDeVentaGridView.EditIndex = -1;
                puntosDeVentaGridView.DataSource = ViewState["puntosDeVenta"];
                puntosDeVentaGridView.DataBind();
                BindearDropDownLists();
            }
            catch
            {
            }
        }
        protected void puntosDeVentaGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            puntosDeVentaGridView.EditIndex = e.NewEditIndex;

            puntosDeVentaGridView.DataSource = ViewState["puntosDeVenta"];
            puntosDeVentaGridView.DataBind();
            BindearDropDownLists();

            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).DataValueField = "Id";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).DataTextField = "Descr";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).DataSource = CedWebEntidades.TiposPuntoDeVenta.TipoPuntoDeVenta.Lista();
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).DataBind();
            try
            {
                ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).Items.FindByValue(((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"])[e.NewEditIndex].IdTipo.ToString());
                li.Selected = true;
            }
            catch
            {
            }
        }
        protected void puntosDeVentaGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
                e.ExceptionHandled = true;
            }
        }
        protected void puntosDeVentaGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                List<CedWebEntidades.PuntoDeVenta> pvs = ((List<CedWebEntidades.PuntoDeVenta>)ViewState["puntosDeVenta"]);
                CedWebEntidades.PuntoDeVenta pv = pvs[e.RowIndex];
                string auxIdTipoPuntoDeVenta = ((DropDownList)puntosDeVentaGridView.Rows[e.RowIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).SelectedValue.ToString();
                string auxDescrTipoPuntoDeVenta = ((DropDownList)puntosDeVentaGridView.Rows[e.RowIndex].FindControl("ddltipo_de_punto_de_ventaEdit")).SelectedItem.Text;
                if (!auxIdTipoPuntoDeVenta.Equals(string.Empty))
                {
                    pv.IdTipo = auxIdTipoPuntoDeVenta;
                    pv.DescrTipo = auxDescrTipoPuntoDeVenta;
                }
                else
                {
                    throw new Exception("Punto de Venta no actualizado porque el Tipo de Punto de Venta no puede estar vacío");
                }
                string auxIdPuntoDeVenta = ((TextBox)puntosDeVentaGridView.Rows[e.RowIndex].FindControl("txtpunto_de_venta")).Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(auxIdPuntoDeVenta, "^[0-9]+$"))
                {
                    pv.Id = Convert.ToInt32(auxIdPuntoDeVenta);
                }
                else
                {
                    throw new Exception("Punto de Venta no agregado porque el Punto de Venta debe ser numérico y entero");
                }
                puntosDeVentaGridView.EditIndex = -1;
                puntosDeVentaGridView.DataSource = ViewState["puntosDeVenta"];
                puntosDeVentaGridView.DataBind();
                BindearDropDownLists();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
    }
}
