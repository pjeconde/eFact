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
                EmailSMSTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.EmailSMS;
                UltimoNroLoteTextBox.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.UltimoNroLote.ToString();
                PaginaDefaultDropDownList.DataValueField = "Id";
                PaginaDefaultDropDownList.DataTextField = "Descr";
                PaginaDefaultDropDownList.DataSource = CedWebRN.PaginaDefault.Lista(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                PaginaDefaultDropDownList.SelectedValue = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.PaginaDefault.Id; ;
                DataBind();
                CancelarButton.Focus();
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
            cuenta.Id = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
            cuenta.Nombre = NombreTextBox.Text;
            cuenta.Telefono = TelefonoTextBox.Text;
            cuenta.EmailSMS = EmailSMSTextBox.Text;
            cuenta.UltimoNroLote = Convert.ToInt64(UltimoNroLoteTextBox.Text);
            cuenta.PaginaDefault.Id = Convert.ToString(PaginaDefaultDropDownList.SelectedValue);
            try
            {
                CedWebRN.Cuenta.Configurar(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                GuardarButton.Visible = false;
                CancelarButton.Visible = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                EmailSMSTextBox.Enabled = false;
                UltimoNroLoteTextBox.Enabled = false;
                PaginaDefaultDropDownList.Enabled = false;
                MsgErrorLabel.Text = "Se ha registrado la nueva configuración satisfactoriamente.";
            }
            catch (Exception ex)
            {
                string a = CedeiraUIWebForms.Excepciones.Detalle(ex);
                MsgErrorLabel.Text = a;
            }
        }
    }
}
