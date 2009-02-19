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

namespace CedWeb.Autenticado
{
	public partial class UsuarioInfo : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if(!this.IsPostBack)
				{
                    TituloPaginaLabel.Text = ((CedEntidades.Sesion)Session["Sesion"]).Usuario.Nombre + " (info)";
					LegajoLabel.Text = ((CedEntidades.Sesion)Session["Sesion"]).Usuario.IdUsuario;
					PerteneceAGridView.PageSize = ((CedEntidades.Sesion)Session["Sesion"]).Usuario.PerteneceA.Count;
					PerteneceAGridView.DataSource = ((CedEntidades.Sesion)Session["Sesion"]).Usuario.PerteneceA;
					PerteneceAGridView.DataBind();
					LoginFechaUltimoAccesoLabel.Text = "Último acceso " + ((CedEntidades.Sesion)Session["Sesion"]).LoginFechaUltimoAcceso.ToString("dd/MM/yyyy");
					LoginDiasRestantesPasswordLabel.Text = "Faltan " + ((CedEntidades.Sesion)Session["Sesion"]).LoginDiasRestantesPassword.ToString() + " días para el cambio de password";
				}
			}
			catch(System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch(Exception ex)
			{
				CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Autenticado/Excepcion.aspx");
			}
		}
	}
}