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
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((LinkButton)Master.FindControl("InicioLinkButton")).ForeColor = System.Drawing.Color.Gold;
            CuentaCrearHyperLink.Enabled = ((CedWebEntidades.Sesion)Session["Sesion"]).Flag.CreacionCuentaHabilitada;
            if (!CuentaCrearHyperLink.Enabled)
            {
                CuentaCrearHyperLink.ForeColor = System.Drawing.Color.Red;
                CuentaCrearHyperLink.Text = "Crear una nueva cuenta<br />(moment�neamente inhabilitado)";
            }
            if (!IsPostBack)
            {
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
                {
                    LoginPanel.Enabled = false;
                }
                else
                {
                    LoginPanel.Enabled = true;
                }
                UsuarioTextBox.Focus();
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
                sesion.Cuenta.Id = UsuarioTextBox.Text;
                sesion.Cuenta.Password = PasswordTextBox.Text;
                CedWebRN.Cuenta.Login(sesion.Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
				Application.Lock();
				Application["Registrados"] = (int)Application["Registrados"] + 1;
				Application.UnLock();                
				if (sesion.Cuenta.TipoCuenta.Id == "Admin")
                {
                    CedWebRN.Cuenta.Depurar(sesion);
                }
                if (sesion.Cuenta.ActivCP)
                {
                    Server.Transfer("~/ActivacionClientePesado.aspx", true);
                }
                else
                {
                    Response.Redirect("~/" + sesion.Cuenta.PaginaDefault.URL + ".aspx");
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente ex)
            {
                ((CedeiraAJAX)this.Master).CaducarIdentificacion();
                
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.LoginRechazadoXPasswordInvalida ex)
            {
                ((CedeiraAJAX)this.Master).CaducarIdentificacion();
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
                PasswordTextBox.Focus();
            }
            catch (Exception ex)
            {
                ((CedeiraAJAX)this.Master).CaducarIdentificacion();
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
    }
}