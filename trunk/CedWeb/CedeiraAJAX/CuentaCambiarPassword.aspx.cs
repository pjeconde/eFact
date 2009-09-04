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
    public partial class CuentaCambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                PasswordTextBox.Focus();
                try
                {
                    if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
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
                CedWebRN.Cuenta.CambiarPassword(sesion.Cuenta, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                ((CedeiraAJAX)this.Master).CaducarIdentificacion();
                PasswordTextBox.Enabled = false;
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contrase�a fue modificada satisfactoriamente.  Si desea seguir trabajando, deber� volver a identificarse en la p�gina de inicio.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Login.PasswordNoMatch)
            {
                MsgErrorLabel.Text = "Contrase�a actual incorrecta";
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente)
            {
                MsgErrorLabel.Text = "La Contrase�a nueva no coincide con su Confirmaci�n";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}
