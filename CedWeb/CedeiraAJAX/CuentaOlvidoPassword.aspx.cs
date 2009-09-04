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
        protected void SolicitarPreguntaButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdUsuarioTextBox.Text == String.Empty)
                {
                    MsgErrorLabel.Text = "Id.Usuario no informado.";
                }
                else
                {
                    if (EmailTextBox.Text == String.Empty)
                    {
                        MsgErrorLabel.Text = "Email no informado.";
                    }
                    else
                    {
                        CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                        cuenta.Id = IdUsuarioTextBox.Text;
                        CedWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                        if (cuenta.Email.ToLower() != EmailTextBox.Text.ToLower())
                        {
                            MsgErrorLabel.Text = "No hay ninguna cuenta en la que el Id.Usuario y el Email ingresados est�n relacionados.";
                        }
                        else
                        {
                            MsgErrorLabel.Text = "";
                            IdUsuarioTextBox.Enabled = false;
                            EmailTextBox.Enabled = false;
                            SolicitarPreguntaButton.Enabled = false;
                            PreguntaLabel.Text = "�" + cuenta.Pregunta + "?";
                            ViewState["respuesta"] = cuenta.Respuesta;
                            RespuestaTextBox.Enabled = true;
                            SolicitarNuevaPasswordButton.Enabled = true;
                            RespuestaTextBox.Focus();
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
            {
                MsgErrorLabel.Text = "No hay ninguna cuenta con el Id.Usuario solicitado.";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void SolicitarNuevaPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RespuestaTextBox.Text == String.Empty)
                {
                    MsgErrorLabel.Text = "Respuesta no informada.";
                }
                else
                {
                    if (RespuestaTextBox.Text.ToLower() != ViewState["respuesta"].ToString().ToLower())
                    {
                        MsgErrorLabel.Text = "Respuesta incorrecta.";
                    }
                    else
                    {
                        MsgErrorLabel.Text = "";
                        RespuestaTextBox.Enabled = false;
                        SolicitarNuevaPasswordButton.Enabled = false;
                        PasswordNuevaTextBox.Enabled = true;
                        ConfirmacionPasswordNuevaTextBox.Enabled = true;
                        AceptarButton.Enabled = true;
                        PasswordNuevaTextBox.Focus();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
            {
                MsgErrorLabel.Text = "No hay ninguna cuenta con el Id.Usuario solicitado.";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                cuenta.Id = IdUsuarioTextBox.Text;
                CedWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                cuenta.Password = PasswordNuevaTextBox.Text + "X";
                CedWebRN.Cuenta.CambiarPassword(cuenta, cuenta.Password, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contrase�a fue registrada satisfactoriamente.  Para iniciar una sesion de trabajo, deber� identificarse en la p�gina de inicio.";
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
