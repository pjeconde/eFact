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
namespace CedWeb
{
    public partial class CompradorExplorador : System.Web.UI.Page
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
            Response.Redirect("~/CompradorCrear.aspx", true);
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
			Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
			Response.Redirect("~/CompradorEliminar.aspx", true);
        }
        protected void ModificarButton_Click(object sender, EventArgs e)
        {
			Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
			Response.Redirect("~/CompradorModificar.aspx", true);
        }
        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
			Session["CompradorSeleccionado"] = CompradorSeleccionado().RazonSocial;
			Response.Redirect("~/CompradorConsultar.aspx", true);
        }
        protected CedWebEntidades.Comprador CompradorSeleccionado()
        {
            System.Collections.Generic.List<CedWebEntidades.Comprador> lista = (System.Collections.Generic.List<CedWebEntidades.Comprador>)ViewState["lista"];
            return (CedWebEntidades.Comprador)lista[CompradorPagingGridView.SelectedIndex];
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}