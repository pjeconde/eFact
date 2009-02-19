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
	public partial class Acerca : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if(!this.IsPostBack)
				{
					CedWebEntidades.Aplicacion aplic = new CedWebEntidades.Aplicacion();
					aplic = CedWebRN.Aplicacion.Crear();
					NombreAplicLabel.Text = aplic.Nombre;
					PropietarioLabel.Text = aplic.Propietario;
					CodigoAplicLabel.Text = "(" + aplic.Codigo + ")";
					VersionLabel.Text = "Versión: " + aplic.Version;
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
