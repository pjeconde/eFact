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
    public partial class AdministracionVendedorExplorador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.Gold;
                if (!IsPostBack)
                {
                    if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                    }
                    else
                    {
                        if (CedWebRN.Fun.NoEstaLogueadoUnAdministrador((CedWebEntidades.Sesion)Session["Sesion"]))
                        {
                            CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                        }
                        else
                        {
                            GrillaPagingGridView.PageSize = 20;
                            BindPagingGrid();
                        }
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
                System.Collections.Generic.List<CedWebEntidades.Vendedor> lista;
                lista = CedWebRN.Vendedor.ListaAdministracion(GrillaPagingGridView.PageIndex, GrillaPagingGridView.PageSize, GrillaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                GrillaPagingGridView.VirtualItemCount = CedWebRN.Vendedor.CantidadDeFilasAdministracion((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                GrillaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Vendedor>)ViewState["lista"];
                GrillaPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
        }
        protected void GrillaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GrillaPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Vendedor> lista;
                lista = CedWebRN.Vendedor.ListaAdministracion(GrillaPagingGridView.PageIndex, GrillaPagingGridView.PageSize, GrillaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                GrillaPagingGridView.VirtualItemCount = CedWebRN.Vendedor.CantidadDeFilasAdministracion((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                GrillaPagingGridView.DataSource = lista;
                GrillaPagingGridView.DataBind();
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
        protected void GrillaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                System.Collections.Generic.List<CedWebEntidades.Vendedor> lista;
                lista = CedWebRN.Vendedor.ListaAdministracion(GrillaPagingGridView.PageIndex, GrillaPagingGridView.PageSize, GrillaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                GrillaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Vendedor>)ViewState["lista"];
                GrillaPagingGridView.DataBind();
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
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}
