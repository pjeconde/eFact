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
	public partial class CedWebautenticado : System.Web.UI.MasterPage
	{
        protected string m_sScript = "stmenu.js";
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
                HtmlGenericControl myJs = new HtmlGenericControl();
                myJs.TagName = "script";
                myJs.Attributes.Add("type", "text/javascript");
                myJs.Attributes.Add("language", "javascript"); //don't need it usually but for cross browser.
                myJs.Attributes.Add("src", ResolveUrl("stmenu.js"));
                this.Page.Header.Controls.Add(myJs);
				Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
				Response.Expires = -1500;
				//Response.CacheControl = "no-cache";
				if(Session["Sesion"] == null)
				{
					Response.Redirect("~/Reingreso.aspx", true);
				}
				else
				{
					NombreUsuarioLinkButton.Text = ((CedEntidades.Sesion)Session["Sesion"]).Usuario.Nombre;
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
