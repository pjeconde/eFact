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
    }
}