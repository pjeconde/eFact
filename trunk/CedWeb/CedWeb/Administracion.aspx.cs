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
                        List<CedWebEntidades.Estadistica> lista = CedWebRN.Cuenta.EstadisticaMedio((CedEntidades.Sesion)Session["Sesion"]);
                        GenerarGrafico(lista, "Temp\\AdministracionGraficoMedio-" + Session.SessionID + ".bmp");
                        MedioImageMap.ImageUrl = "~/Temp/AdministracionGraficoMedio-" + Session.SessionID + ".bmp";
                        MedioImageMap.DataBind();

                        lista = CedWebRN.Cuenta.EstadisticaProvincia((CedEntidades.Sesion)Session["Sesion"]);
                        GenerarGrafico(lista, "Temp\\AdministracionGraficoProvincia-" + Session.SessionID + ".bmp");
                        ProvinciaImageMap.ImageUrl = "~/Temp/AdministracionGraficoProvincia-" + Session.SessionID + ".bmp";
                        ProvinciaImageMap.DataBind();

                        ModoDepuracionCheckBox.Checked = ((CedWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion;
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
        protected void Page_Disposed(object sender, EventArgs e)
        {
            string archivoTemporario = Server.MapPath(MedioImageMap.ImageUrl.Replace("~/", String.Empty).Replace("/", "\\"));
            if (System.IO.File.Exists(archivoTemporario))
            {
                System.IO.File.Delete(archivoTemporario);
            }
            archivoTemporario = Server.MapPath(ProvinciaImageMap.ImageUrl.Replace("~/", String.Empty).Replace("/", "\\"));
            if (System.IO.File.Exists(archivoTemporario))
            {
                System.IO.File.Delete(archivoTemporario);
            }
        }
        private void GenerarGrafico(List<CedWebEntidades.Estadistica> Lista, string Path)
        {
            decimal[] valores = new decimal[Lista.Count];
            string[] textos = new string[Lista.Count];
            for (int i = 0; i < Lista.Count; i++)
            {
                textos[i] = Lista[i].Concepto;
                valores[i] = Lista[i].Cantidad;
            }
            CedBPrn.Grafico.Generar(155, 155, 0, valores, textos, Path, System.Drawing.Color.Navy);
        }
        protected void RecibeAvisoAltaCuentaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.RecibeAvisoAltaCuenta = RecibeAvisoAltaCuentaCheckBox.Checked;
            CedWebRN.Flag.SetearModoDepuracion((CedWebEntidades.Flag)((CedWebEntidades.Sesion)Session["Sesion"]).Flag, (CedEntidades.Sesion)Session["Sesion"]);
        }
        protected void ModoDepuracionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((CedWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion = ModoDepuracionCheckBox.Checked;
            CedWebRN.Flag.SetearModoDepuracion((CedWebEntidades.Flag)((CedWebEntidades.Sesion)Session["Sesion"]).Flag, (CedEntidades.Sesion)Session["Sesion"]);
        }
        protected void UltimasAltasPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                UltimasAltasPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimasAltasPagingGridView.PageIndex, UltimasAltasPagingGridView.PageSize, UltimasAltasPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                UltimasAltasPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
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
        protected void UltimosComprobantesPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                UltimosComprobantesPagingGridView.PageIndex = e.NewPageIndex;
                System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
                lista = CedWebRN.Cuenta.Lista(UltimosComprobantesPagingGridView.PageIndex, UltimosComprobantesPagingGridView.PageSize, UltimosComprobantesPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
                UltimosComprobantesPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                cuenta.Id = "claudio.cedeira";
                CedWebRN.Cuenta.Leer(cuenta, (CedWebEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Cuenta.EnviarMailBienvenidaPremium(cuenta, (CedWebEntidades.Sesion)Session["Sesion"]);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = ex.Message;
            }
        }
    }
}