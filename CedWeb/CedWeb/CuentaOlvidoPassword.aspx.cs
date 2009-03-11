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
    public partial class CuentaOlvidoPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                IdUsuarioTextBox.Focus();
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
                //CedWebRN.Cuenta.CambioPassword(sesion.Cuenta, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                ((CedWeb)this.Master).CaducarIdentificacion();
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contraseña fue modificada satisfactoriamente.  Si desea seguir trabajando, deberá volver a identificarse en la página de inicio.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Login.PasswordNoMatch)
            {
                MsgErrorLabel.Text = "Contraseña actual incorrecta";
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente)
            {
                MsgErrorLabel.Text = "La Contraseña nueva no coincide con su Confirmación";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}