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

namespace CedeiraAJAX
{
    public partial class ActivacionClientePesado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloParte1Label.Text + TituloParte2Label.Text, "~/SoloDispPUsuariosActivCP.aspx");
                }
                else
                {
                    if (!CedWebRN.Fun.ActivacionCPhabilitada((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloParte1Label.Text + TituloParte2Label.Text, "~/SoloDispPUsuariosActivCP.aspx");
                    }
                    else
                    {
                    }
                }
            }
        }
        protected void VolverLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Inicio.aspx"); ;
        }
        protected void SolicitarActivCPButton_Click(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.ActivacionCPhabilitada((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                ClaveActivCPTextBox.Text = CedWebRN.Cuenta.ObtenerClaveActivCP(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ClaveSolicitudTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
            }
            else
            {
                ClaveActivCPTextBox.Text = String.Empty;
                MsgErrorLabel.Text = "Ya se han agotado todas las instancias de activación del programa eFact-Residente.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Inicio.aspx");
        }
    }
}
