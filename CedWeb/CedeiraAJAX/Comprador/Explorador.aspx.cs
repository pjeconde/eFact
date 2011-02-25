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
using System.Collections.Generic;

namespace CedeiraAJAX.Comprador
{
    public partial class Explorador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
                    else
                    {
                        CompradorPagingGridView.PageSize = 20;
                        BindPagingGrid();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        private void BindPagingGrid()
        {
            try
            {
                System.Collections.Generic.List<CedWebEntidades.Comprador> lista;
                lista = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, CompradorPagingGridView.PageIndex, CompradorPagingGridView.PageSize, CompradorPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                CompradorPagingGridView.VirtualItemCount = CedWebRN.Comprador.CantidadDeFilas(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CompradorPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Comprador>)ViewState["lista"];
                CompradorPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
        }
        protected void CompradorPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                CompradorPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Comprador> lista;
                lista = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, CompradorPagingGridView.PageIndex, CompradorPagingGridView.PageSize, CompradorPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                CompradorPagingGridView.VirtualItemCount = CedWebRN.Comprador.CantidadDeFilas(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CompradorPagingGridView.DataSource = lista;
                CompradorPagingGridView.DataBind();
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
        protected void CompradorPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                System.Collections.Generic.List<CedWebEntidades.Comprador> lista;
                lista = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, CompradorPagingGridView.PageIndex, CompradorPagingGridView.PageSize, CompradorPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CompradorPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Comprador>)ViewState["lista"];
                CompradorPagingGridView.DataBind();
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
        protected void CompradorPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarAcciones();
                System.Collections.Generic.List<CedWebEntidades.Comprador> lista = (System.Collections.Generic.List<CedWebEntidades.Comprador>)ViewState["lista"];
                CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
                comprador = (CedWebEntidades.Comprador)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
                string auxCache = "Comprador" + Session.SessionID;
                Cache.Remove(auxCache);
                Cache.Add(auxCache, comprador, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                HabilitarAcciones();
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
        protected void CompradorPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.CompradorPagingGridView, "Select$" + e.Row.RowIndex);
            }
        }
        private void DesSeleccionarFilas()
        {
            DeshabilitarAcciones();
            CompradorPagingGridView.SelectedIndex = -1;
        }
        private void HabilitarAcciones()
        {
            EliminarButton.Enabled = true;
            ModificarButton.Enabled = true;
            ConsultarButton.Enabled = true;
        }
        private void DeshabilitarAcciones()
        {
            EliminarButton.Enabled = false;
            ModificarButton.Enabled = false;
            ConsultarButton.Enabled = false;
        }
        protected void CrearButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comprador/Crear.aspx", true);
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
            Response.Redirect("~/Comprador/Eliminar.aspx", true);
        }
        protected void ModificarButton_Click(object sender, EventArgs e)
        {
            Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
            Response.Redirect("~/Comprador/Modificar.aspx");
        }
        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
            Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
            Response.Redirect("~/Comprador/Consultar.aspx", true);
        }
        protected CedWebEntidades.Comprador CompradorSeleccionado()
        {
            System.Collections.Generic.List<CedWebEntidades.Comprador> lista = (System.Collections.Generic.List<CedWebEntidades.Comprador>)ViewState["lista"];
            return (CedWebEntidades.Comprador)lista[CompradorPagingGridView.SelectedIndex];
        }
        protected void BackupButton_Click(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                List<CedWebEntidades.Comprador> compradores = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"], false);
                if (compradores.Count == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No hay datos de Compradores para descargar.');</script>");
                }
                else
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(compradores.GetType());
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                    x.Serialize(writerdememoria, compradores);
                    m.Seek(0, System.IO.SeekOrigin.Begin);
                    string nombreArchivo = "eFact-Compradores-" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Replace(".", String.Empty).ToUpper() + ".xml";
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + nombreArchivo), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    Response.Redirect("~/DescargaTemporarios.aspx?archivo=" + nombreArchivo, false);
                }

            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FacturaElectronica.aspx", true);
        }
    }
}
