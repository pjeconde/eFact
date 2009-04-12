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
    public partial class AdministracionCuentaExplorador : System.Web.UI.Page
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
                            CuentaPagingGridView.PageSize = 15;
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
                DeshabilitarAcciones();
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                cuenta = (CedWebEntidades.Cuenta)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];
                string auxCache = "Cuenta" + Session.SessionID;
                Cache.Remove(auxCache);
                Cache.Add(auxCache, cuenta, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                HabilitarAcciones(cuenta);
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
            DeshabilitarAcciones();
            CuentaPagingGridView.SelectedIndex = -1;
        }
        private void HabilitarAcciones(CedWebEntidades.Cuenta Cuenta)
        {
            switch (Cuenta.EstadoCuenta.Id)
            {
                case "Vigente":
                    BajaButton.Enabled = true;
                    break;
                case "Baja":
                    AnularBajaButton.Enabled = true;
                    break;
                case "PteConf":
                    BajaButton.Enabled = true;
                    ReenviarMailButton.Enabled = true;
                    break;
            }
            if (Cuenta.TipoCuenta.Id == "Prem")
            {
                switch (Cuenta.EstadoCuenta.Id)
                {
                    case "Vigente":
                        SuspenderPremiumButton.Enabled = true;
                        break;
                    case "Suspend":
                        RestablecerPremiumButton.Enabled = true;
                        break;
                }
            }
            if ((Cuenta.TipoCuenta.Id == "Prem" || Cuenta.TipoCuenta.Id == "Free") && 
                (Cuenta.EstadoCuenta.Id == "Vigente" || Cuenta.EstadoCuenta.Id == "Suspend"))
            {
                ActivCPButton.Enabled = true;
            }
        }
        private void DeshabilitarAcciones()
        {
            BajaButton.Enabled = false;
            AnularBajaButton.Enabled = false;
            ReenviarMailButton.Enabled = false;
            ActivCPButton.Enabled = false;
            SuspenderPremiumButton.Enabled = false;
            RestablecerPremiumButton.Enabled = false;
        }
        protected CedWebEntidades.Cuenta CuentaSeleccionada()
        {
            System.Collections.Generic.List<CedWebEntidades.Cuenta> lista = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
            return (CedWebEntidades.Cuenta)lista[CuentaPagingGridView.SelectedIndex];
        }
        protected void BajaButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.DarDeBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void AnularBajaButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.AnularBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void ReenviarMailButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.ReenviarMail(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void ActivCPButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.CambiarActivCP(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void SuspenderPremiumButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.SuspenderPremium(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void RestablecerPremiumButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.RestablecerPremium(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void DepurarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebRN.Cuenta.DepurarBajas((CedEntidades.Sesion)Session["Sesion"]);
                BindPagingGrid();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}