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
	public partial class CedWeb : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                MensajeGeneralLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).MensajeGeneral;
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre != null)
                {
                    NombreCuentaLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                    SeparadorLabel.Visible = true;
                    SalirLinkButton.Visible = true;
                }
            }
		}
        public void SalirLinkButton_Click(object sender, EventArgs e)
        {
            CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
            CedWebRN.Cuenta.Limpiar(sesion.Cuenta); 
            NombreCuentaLabel.Text = String.Empty;
            SeparadorLabel.Visible = false;
            SalirLinkButton.Visible = false;
            Response.Redirect("~/Inicio.aspx", true);
        }
    }
}	
