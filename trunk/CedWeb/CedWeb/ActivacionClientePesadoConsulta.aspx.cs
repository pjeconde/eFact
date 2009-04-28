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
    public partial class ActivacionClientePesadoConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!this.IsPostBack)
			{
				if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
				{
                    CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloParte1Label.Text + TituloParte2Label.Text, "~/SoloDispPUsuariosRegistrados.aspx");
				}
				else
				{
                    if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.NroSerieDisco==String.Empty)
                    {
                        MsgErrorLabel.Text = "No se registra que se haya generado la clave de activación";
                    }
                    else
                    {
                        ClaveActivCPTextBox.Text = CedWebRN.Cuenta.ObtenerClaveActivCP(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.NroSerieDisco, (CedEntidades.Sesion)Session["Sesion"]);
                    }
                }
			}
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}