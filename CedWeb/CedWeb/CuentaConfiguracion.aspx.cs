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
using CaptchaDotNet2.Security.Cryptography;
namespace CedWeb
{
    public partial class CuentaConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CedWebRN.Cuenta.Leer(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                NombreTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                TelefonoTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Telefono;
                EmailTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Email;
                UltimoNroLoteTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.UltimoNroLote.ToString();
                CancelarButton.Focus();
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            //MsgErrorLabel.Text = String.Empty;
            //ResultadoComprobarDisponibilidadLabel.Text = String.Empty;
            //CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
            //cuenta.Nombre = NombreTextBox.Text;
            //cuenta.Telefono = TelefonoTextBox.Text;
            //cuenta.Email = EmailTextBox.Text;
            //cuenta.Id = IdUsuarioTextBox.Text;
            //cuenta.Password = PasswordTextBox.Text;
            //cuenta.ConfirmacionPassword = ConfirmacionPasswordTextBox.Text;
            //cuenta.Pregunta = PreguntaTextBox.Text;
            //cuenta.Respuesta = RespuestaTextBox.Text;
            //try
            //{
            //    CedWebRN.Cuenta.Validar(cuenta, Session["captcha"].ToString(), CaptchaTextBox.Text, (CedEntidades.Sesion)Session["Sesion"]);
            //    CedWebRN.Cuenta.Registrar(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
            //    ComprobarDisponibilidadButton.Visible = false;
            //    NuevaClaveCaptchaButton.Visible = false;
            //    CrearCuentaButton.Visible = false;
            //    CancelarButton.Visible = false;
            //    CrearCuentaLabel.Visible = false;
            //    CaptchaImage.Visible = false;
            //    ClaveLabel.Visible = false;
            //    CaptchaTextBox.Visible = false;
            //    CaseSensitiveLabel.Visible = false;
            //    NombreTextBox.Enabled = false;
            //    TelefonoTextBox.Enabled = false;
            //    EmailTextBox.Enabled = false;
            //    IdUsuarioTextBox.Enabled = false;
            //    PasswordTextBox.Enabled = false;
            //    ConfirmacionPasswordTextBox.Enabled = false;
            //    PreguntaTextBox.Enabled = false;
            //    RespuestaTextBox.Enabled = false;
            //    MsgErrorLabel.Text = "Gracias por crear su cuenta eFact.  Siga las instrucciones, que se enviaron por email, para confirmar la creación de su cuenta.  La recepción del email puede demorar unos minutos.";
            //}
            //catch (Exception ex)
            //{
            //    string a = CedeiraUIWebForms.Excepciones.Detalle(ex);
            //    MsgErrorLabel.Text = a;
            //}
        }
   }
}