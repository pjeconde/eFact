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
using System.Net;
using System.Net.Mail;

public partial class PruebasPol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("facturaelectronica@cedeira.com.ar");
        mail.CC.Add(new MailAddress("facturaelectronica@cedeira.com.ar"));
        mail.To.Add(new MailAddress(EMailTextBox.Text)); //Contacto.Email
        mail.Subject = AsuntoTextBox.Text + " (Facturación Electrónica - Bienvenida a productos)"; //Contacto.Referencia
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        WebClient carta = new WebClient();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        string a = carta.DownloadString(System.Web.HttpContext.Current.Server.MapPath("EmailTemplates/FacturaElectronicaMailEstudiosContables.htm"));
        mail.Body = a.Substring(a.IndexOf("<"));
        mail.Body = mail.Body.Replace("%usuario%", "Sr.Contador"); //Contacto.Empresa + Contacto.Nombre
        smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
        smtpClient.Send(mail);
        
    }
}
