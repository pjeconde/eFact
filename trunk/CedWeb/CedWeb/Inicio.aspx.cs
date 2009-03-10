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
    public partial class Iniciar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("InicioLinkButton")).ForeColor = System.Drawing.Color.Gold;
            if (!IsPostBack)
            {
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
                {
                    LoginPanel.Enabled = false;
                }
            }
        }
		protected void LoginButton_Click(object sender, EventArgs e)
		{
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
                sesion.Cuenta.Id = UsuarioTextBox.Text;
                sesion.Cuenta.Password = PasswordTextBox.Text;
                CedWebRN.Cuenta.Login(sesion.Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                Response.Redirect("~/FacturaElectronica.aspx", true);
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
                CedWebRN.Cuenta.Limpiar(sesion.Cuenta);
                ((Label)Master.FindControl("NombreCuentaLabel")).Text = String.Empty;
                ((Label)Master.FindControl("SeparadorLabel")).Visible = false;
                ((LinkButton)Master.FindControl("SalirLinkButton")).Visible = false;
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
		}
		protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
		}
		protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
		}
	}
}