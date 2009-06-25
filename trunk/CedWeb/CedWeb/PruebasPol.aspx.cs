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
        SmtpClient smtpClient = new SmtpClient("localhost");
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("facturaelectronica@cedeira.com.ar");
        mail.CC.Add(new MailAddress("facturaelectronica@cedeira.com.ar"));
        mail.To.Add(new MailAddress("pjeconde@gmail.com")); //Cuenta.Email));
        mail.Subject = "Facturación Electrónica - Bienvenida a productos eFact (Ref. 1)"; //Cuenta.Id + ")";
        mail.IsBodyHtml = true;
        WebClient carta = new WebClient();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        string a = carta.DownloadString(System.Web.HttpContext.Current.Server.MapPath("EmailTemplates/FacturaElectronicaMailEstudiosContables.htm"));
        mail.Body = a.Substring(a.IndexOf("<"));
        mail.Body = mail.Body.Replace("%usuario%", "PEPE");
        mail.Body = mail.Body.Replace("%fechaVencimiento%", "30/11/2009");
        smtpClient.Send(mail);
    }
}
