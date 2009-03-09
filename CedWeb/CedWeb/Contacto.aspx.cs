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
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerarImagenCaptcha();
                ((LinkButton)Master.FindControl("ContactoLinkButton")).ForeColor = System.Drawing.Color.Gold;
            }
        }
        protected void BorrarDatosButton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = String.Empty;
            TelefonoTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            MensajeTextBox.Text = String.Empty;
            MsgErrorLabel.Text = String.Empty;
            GenerarImagenCaptcha();
        }
        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            CedWebEntidades.Contacto contacto = new CedWebEntidades.Contacto();
            if (FactElectronicaRadioButton.Checked)
            {
                contacto.Motivo = "FactElectronica";
            }
            else
            {
                contacto.Motivo = "Otro";
            }
            contacto.Nombre = NombreTextBox.Text;
            contacto.Telefono = TelefonoTextBox.Text;
            contacto.Email = EmailTextBox.Text;
            contacto.Mensaje = MensajeTextBox.Text;
            try
            {
                CedWebRN.Contacto.Validar(contacto, Session["captcha"].ToString(), CaptchaTextBox.Text);
                CedWebRN.Contacto.Registrar(contacto);
                EnviarButton.Visible = false;
                BorrarDatosButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                FactElectronicaRadioButton.Enabled = false;
                OtrosRadioButton.Enabled = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                MensajeTextBox.Enabled = false;
                MsgErrorLabel.Text = "Formulario enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            GenerarImagenCaptcha();
        }
        private void GenerarImagenCaptcha()
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
            CaptchaTextBox.Text = String.Empty;
        }
    }
}