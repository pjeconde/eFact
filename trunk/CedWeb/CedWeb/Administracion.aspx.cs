using System;
using System.Data;
using System.Collections.Generic;
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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                        List<CedWebEntidades.Estadistica> registros = CedWebRN.Estadistica.DeterminarCantidadRegistros((CedEntidades.Sesion)Session["Sesion"]);
                        for (int i = 0; i < registros.Count; i++)
                        {
                            switch (registros[i].Concepto)
                            {
                                case "Vendedores":
                                    VendedoresLabel.Text = "(" + registros[i].Cantidad.ToString() + ")";
                                    break;
                                case "Compradores":
                                    CompradoresLabel.Text = "(" + registros[i].Cantidad.ToString() + ")";
                                    break;
                                default:
                                    CuentasLabel.Text = "(" + registros[i].Cantidad.ToString() + ")";
                                    break;
                            }
                        }
                        GenerarGrafico();
                        MedioImageMap.ImageUrl = "~/Imagenes/temp.bmp";
                        MedioImageMap.DataBind();
                        RecibeAvisoAltaCuentaCheckBox.Checked = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.RecibeAvisoAltaCuenta;

                        UltimasAltasPagingGridView.PageSize = 6;
                        System.Collections.Generic.List<CedWebEntidades.Cuenta> listaUltimasAltas;
                        listaUltimasAltas = CedWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, "FechaAlta DESC", (CedEntidades.Sesion)Session["Sesion"]);
                        UltimasAltasPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                        UltimasAltasPagingGridView.DataSource = listaUltimasAltas;
                        UltimasAltasPagingGridView.DataBind();

                        UltimosComprobantesPagingGridView.PageSize = 6;
                        System.Collections.Generic.List<CedWebEntidades.Cuenta> listaUltimosComprobantes;
                        listaUltimosComprobantes = CedWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, "FechaUltimoComprobante DESC", (CedEntidades.Sesion)Session["Sesion"]);
                        UltimosComprobantesPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                        UltimosComprobantesPagingGridView.DataSource = listaUltimosComprobantes;
                        UltimosComprobantesPagingGridView.DataBind();
                    }
                }
            }
        }
        private void GenerarGrafico()
        {
            List<CedWebEntidades.Estadistica> lista = CedWebRN.Cuenta.EstadisticaMedio((CedEntidades.Sesion)Session["Sesion"]);
            decimal[] valores = new decimal[lista.Count];
            string[] textos = new string[lista.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                textos[i] = lista[i].Concepto;
                valores[i] = lista[i].Cantidad;
            }
            CedBPrn.Grafico.Generar(140, 315, valores, textos);
        }
        protected void RecibeAvisoAltaCuentaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.RecibeAvisoAltaCuenta = RecibeAvisoAltaCuentaCheckBox.Checked;
            CedWebRN.Cuenta.SetearRecibeAvisoAltaCuenta((CedWebEntidades.Cuenta)((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
        }
        protected void UltimasAltasPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                UltimasAltasPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, UltimasAltasPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                UltimasAltasPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UltimasAltasPagingGridView.DataSource = lista;
                UltimasAltasPagingGridView.DataBind();
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
        protected void UltimasAltasPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, UltimasAltasPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UltimasAltasPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                UltimasAltasPagingGridView.DataBind();
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
        protected void UltimosComprobantesPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                UltimosComprobantesPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, UltimosComprobantesPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                UltimosComprobantesPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UltimosComprobantesPagingGridView.DataSource = lista;
                UltimosComprobantesPagingGridView.DataBind();
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
        protected void UltimosComprobantesPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, UltimosComprobantesPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UltimosComprobantesPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
                UltimosComprobantesPagingGridView.DataBind();
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
}