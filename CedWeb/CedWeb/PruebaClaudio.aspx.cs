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
using System.Net.Mail;
using System.Text;

public partial class PruebaClaudio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Mail para confirmación
            SmtpClient smtpClient = new SmtpClient("localhost");
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress("claudio.cedeira@gmail.com"));
            mail.Subject = "Mail de prueba";
            StringBuilder a = new StringBuilder();
            a.Append("Mail de prueba"); a.AppendLine();
            char c = (char) 34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + "http://co1piltwb.partners.extranet.microsoft.com/mcoeredir/mcoeredirect.aspx?linkId=11517299&s1=fd36d2a3-fc01-f048-a591-6f9159ec6c5a" + c + ">click here</a>");
            mail.Body = a.ToString();
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
        }
    }
}
