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
using System.Xml;
using System.Collections.Generic;

namespace CedeiraAJAX
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BackupVendedorLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
                }
                else
                {
                    CedWebEntidades.Vendedor vendedor = new CedWebEntidades.Vendedor();
                    vendedor.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                    CedWebRN.Vendedor.Leer(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(vendedor.GetType());
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                    x.Serialize(writerdememoria, vendedor);
                    m.Seek(0, System.IO.SeekOrigin.Begin);
                    string nombreArchivo = "eFact-Vendedor-" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Replace(".", String.Empty).ToUpper() + ".xml";
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + nombreArchivo), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + nombreArchivo, false);
                }
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No hay datos del Vendedor para descargar.');</script>");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString() + "');</script>");
            }
        }
        protected void BackupCompradoresLinkButton_Click(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                List<CedWebEntidades.Comprador> compradores = CedWebRN.Comprador.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"], false);
                if (compradores.Count == 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No hay datos de Compradores para descargar.');</script>");
                }
                else
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(compradores.GetType());
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                    x.Serialize(writerdememoria, compradores);
                    m.Seek(0, System.IO.SeekOrigin.Begin);
                    string nombreArchivo = "eFact-Compradores-" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Replace(".", String.Empty).ToUpper() + ".xml";
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + nombreArchivo), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + nombreArchivo, false);
                }

            }
        }
    }
}
