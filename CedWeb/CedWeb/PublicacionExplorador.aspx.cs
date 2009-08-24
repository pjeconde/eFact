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
    public partial class PublicacionExplorador : System.Web.UI.Page
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
                            PublicacionPagingGridView.PageSize = 15;
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
                System.Collections.Generic.List<CedWebEntidades.Publicacion> lista;
                lista = CedWebRN.Publicacion.Lista(PublicacionPagingGridView.PageIndex, PublicacionPagingGridView.PageSize, PublicacionPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                PublicacionPagingGridView.VirtualItemCount = CedWebRN.Publicacion.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PublicacionPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Publicacion>)ViewState["lista"];
                PublicacionPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
        }
        protected void PublicacionPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                PublicacionPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Publicacion> lista;
                lista = CedWebRN.Publicacion.Lista(PublicacionPagingGridView.PageIndex, PublicacionPagingGridView.PageSize, PublicacionPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                PublicacionPagingGridView.VirtualItemCount = CedWebRN.Publicacion.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PublicacionPagingGridView.DataSource = lista;
                PublicacionPagingGridView.DataBind();
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
        protected void PublicacionPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                System.Collections.Generic.List<CedWebEntidades.Publicacion> lista;
                lista = CedWebRN.Publicacion.Lista(PublicacionPagingGridView.PageIndex, PublicacionPagingGridView.PageSize, PublicacionPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PublicacionPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Publicacion>)ViewState["lista"];
                PublicacionPagingGridView.DataBind();
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
        protected void PublicacionPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DeshabilitarAcciones();
                System.Collections.Generic.List<CedWebEntidades.Publicacion> lista = (System.Collections.Generic.List<CedWebEntidades.Publicacion>)ViewState["lista"];
                CedWebEntidades.Publicacion publicacion = new CedWebEntidades.Publicacion();
                publicacion = (CedWebEntidades.Publicacion)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
                string auxCache = "Publicacion" + Session.SessionID;
                Cache.Remove(auxCache);
                Cache.Add(auxCache, publicacion, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                HabilitarAcciones(publicacion);
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
        protected void PublicacionPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.PublicacionPagingGridView, "Select$" + e.Row.RowIndex);
            }
        }
        private void DesSeleccionarFilas()
        {
            DeshabilitarAcciones();
            PublicacionPagingGridView.SelectedIndex = -1;
        }
        private void HabilitarAcciones(CedWebEntidades.Publicacion Publicacion)
        {
            ClonarButton.Enabled = true;
            ModificarButton.Enabled = true;
            PublicarButton.Enabled = true;
            CancelarButton.Enabled = true;
        }
        private void DeshabilitarAcciones()
        {
            ClonarButton.Enabled = false;
            ModificarButton.Enabled = false;
            PublicarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }
        protected CedWebEntidades.Publicacion PublicacionSeleccionada()
        {
            System.Collections.Generic.List<CedWebEntidades.Publicacion> lista = (System.Collections.Generic.List<CedWebEntidades.Publicacion>)ViewState["lista"];
            return (CedWebEntidades.Publicacion)lista[PublicacionPagingGridView.SelectedIndex];
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                //CedWebRN.Publicacion.DarDeBaja(PublicacionSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                //BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void ClonarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                //CedWebRN.Publicacion.AnularBaja(PublicacionSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                //BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void ModificarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                //CedWebRN.Publicacion.ReenviarMail(PublicacionSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                //BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void PublicarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                //CedWebRN.Publicacion.CambiarActivCP(PublicacionSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                //BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                //CedWebRN.Publicacion.CambiarActivCP(PublicacionSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                //BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Administracion.aspx", true);
        }
    }
}