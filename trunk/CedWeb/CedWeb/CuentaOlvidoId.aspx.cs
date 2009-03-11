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
    public partial class CuentaOlvidoId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmailTextBox.Focus();
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
                CedWebRN.Cuenta.ReportarIdCuentas(EmailTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                EmailTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "Se ha enviado, por correo electrónico, el Id.Usuario de su(s) cuenta(s) eFact.  La recepción del email puede demorar unos minutos.";
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
    }
}