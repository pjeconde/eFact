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
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
            mail.IsBodyHtml = false;
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress("claudio.cedeira@gmail.com"));
            mail.Subject = "Objetos serializados";
            StringBuilder a = new StringBuilder();
            a.Append("Mail de prueba<br />");
            CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
            cuenta.Id = "claudio.cedeira";
            CedWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);

            //System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(cuenta.GetType());
            //System.IO.MemoryStream m = new System.IO.MemoryStream();
            //System.IO.StreamWriter sw = new System.IO.StreamWriter(m);
            //sw.Flush(); 
            //System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            //xml.Serialize(writer, cuenta);
            //XmlSerializer mySerializer = new XmlSerializer(Objeto.GetType());
            //a.Append(writer.ToString());

            XmlSerializer mySerializer = new XmlSerializer(cuenta.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, cuenta);
            ms.Seek(0, SeekOrigin.Begin);
            XmlDocument output = new XmlDocument();
            output.Load(ms);
            a.Append(output.InnerXml);

            mail.Body = a.ToString();
            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
        }
    }
}
