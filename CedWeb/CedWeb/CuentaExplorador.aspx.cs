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
    public partial class CuentaExplorador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ((LinkButton)Master.FindControl("CuentasLinkButton")).ForeColor = System.Drawing.Color.Gold;
                if (!this.IsPostBack)
                {
                    if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id == null)
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                    }
                    if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id != "Admin" || ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.EstadoCuenta.Id!="Vigente")
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
                    }
                    CuentaPagingGridView.PageSize = 20;
                    BindPagingGrid();
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
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                CuentaPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                CuentaPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
        }
        protected void CuentaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                CuentaPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                CuentaPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CuentaPagingGridView.DataSource = lista;
                CuentaPagingGridView.DataBind();
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
        protected void CuentaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                CuentaPagingGridView.DataBind();
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
        protected void CuentaPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BajaButton.Enabled = false;
                AnularBajaButton.Enabled = false;
                SuspenderPremiumButton.Enabled = false;
                RestablecerPremiumButton.Enabled = false;

                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                cuenta = (CedWebEntidades.Cuenta)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
                string auxCache = "Cuenta" + Session.SessionID;
                Cache.Remove(auxCache);
                Cache.Add(auxCache, cuenta, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);

                if (cuenta.EstadoCuenta.Id == "Vigente")
                {
                    BajaButton.Enabled = true;
                }
                else
                {
                    if (cuenta.EstadoCuenta.Id == "Baja")
                    {
                        AnularBajaButton.Enabled = true;
                    }
                }

                if (cuenta.TipoCuenta.Id == "Prem")
                {
                    switch (cuenta.EstadoCuenta.Id)
                    {
                        case "Vigente":
                            SuspenderPremiumButton.Enabled = true;
                            break;
                        case "Suspend":
                            RestablecerPremiumButton.Enabled = true;
                            break;
                    }
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
        protected void CuentaPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.CuentaPagingGridView, "Select$" + e.Row.RowIndex);
            }
        }
        private void DesSeleccionarFilas()
        {
            CuentaPagingGridView.SelectedIndex = -1;
        }
        protected void BajaButton_Click(object sender, EventArgs e)
        {

        }
        protected void AnularBajaButton_Click(object sender, EventArgs e)
        {

        }
        protected void SuspenderPremiumButton_Click(object sender, EventArgs e)
        {

        }
        protected void RestablecerPremiumButton_Click(object sender, EventArgs e)
        {

        }
    }
}