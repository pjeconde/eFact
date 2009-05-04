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
    public partial class CuentaPremiumActivar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                cuenta.Id = Session["CuentaPremiumActivar-Id"].ToString();
                CedWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                IdUsuarioTextBox.Text = cuenta.Id;
                NombreTextBox.Text = cuenta.Nombre;
                EmailTextBox.Text = cuenta.Email;
                FechaVtoPremiumDatePickerWebUserControl.Focus();
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
                CedWebEntidades.Cuenta cuenta= new CedWebEntidades.Cuenta();
                cuenta.Id = IdUsuarioTextBox.Text;
                CedWebRN.Cuenta.Leer(cuenta, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Cuenta.ActivarPremium(cuenta, new DateTime(FechaVtoPremiumDatePickerWebUserControl.CalendarDate.Year, FechaVtoPremiumDatePickerWebUserControl.CalendarDate.Month, FechaVtoPremiumDatePickerWebUserControl.CalendarDate.Day, 23, 59, 59), (CedEntidades.Sesion)Session["Sesion"]);
                FechaVtoPremiumDatePickerWebUserControl.ReadOnly = true;
                GuardarButton.Visible = false;
                CancelarButton.Text = "Continuar";
                MsgErrorLabel.Text = "Se ha registrado satisfactoriamente la activación de esta cuenta en el Servicio Premium";
                CancelarButton.Focus();
            }
            catch (Exception ex)
            {
                string a = CedeiraUIWebForms.Excepciones.Detalle(ex);
                MsgErrorLabel.Text = a;
            }
        }
   }
}