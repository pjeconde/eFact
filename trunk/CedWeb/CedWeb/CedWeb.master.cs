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


namespace CedWeb
{
	public partial class CedWeb : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            HtmlGenericControl myJs = new HtmlGenericControl();
            myJs.TagName = "script";
            myJs.Attributes.Add("type", "text/javascript");
            myJs.Attributes.Add("language", "javascript"); //don't need it usually but for cross browser.
            myJs.Attributes.Add("src", ResolveUrl("/Autenticado/stmenu.js"));
            this.Page.Header.Controls.Add(myJs);
		}
	}
}	
