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
                List<CedWebEntidades.Estadistica> registros = CedWebRN.Estadistica.DeterminarCantidadRegistros((CedEntidades.Sesion)Session["Sesion"]);
                for (int i = 0; i < registros.Count; i++)
                {
                    switch (registros[i].Concepto)
                    {
                        case "Vendedores":
                            VendedoresLabel.Text="("+registros[i].Cantidad.ToString()+")";
                            break;
                        case "Compradores":
                            CompradoresLabel.Text="("+registros[i].Cantidad.ToString()+")";
                            break;
                        default:
                            CuentasLabel.Text = "(" + registros[i].Cantidad.ToString() + ")";
                            break;
                    }
                }
            }
        }
    }
}