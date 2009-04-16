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
    public partial class ActivacionClientePesado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloParte1Label.Text + TituloParte2Label.Text, "~/SoloDispPUsuariosActivCP.aspx");
            }
            else
            {
                if (CedWebRN.Fun.NoActivCP((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloParte1Label.Text + TituloParte2Label.Text, "~/SoloDispPUsuariosActivCP.aspx");
                }
                else
                {
                }
            }
        }
        protected void VolverLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
        protected void SolicitarActivCPButton_Click(object sender, EventArgs e)
        {
            ClaveActivCPTextBox.Text = CedWebRN.Cuenta.ObtenerClaveActivCP(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ClaveSolicitudTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx", true);
        }
    }
}