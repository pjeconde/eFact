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
    public partial class FacturaElectronicaPreguntasFrec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.Request.UrlReferrer != null)
                {
                    HyperLinkVolverPagAnt.NavigateUrl = Page.Request.UrlReferrer.ToString();
                }
                if (CheckBoxAceptarTYC.Checked)
                {
                    if (Page.Request.QueryString.ToString() == "Link=VerTYC")
                    {
                        //PanelAceptaTYC.Visible = false;
                    }
                    else
                    {
                        if (Page.Request.UrlReferrer.LocalPath.ToString() == "/CedWeb/FacturaElectronica.aspx" || Page.Request.UrlReferrer.LocalPath.ToString() == "/Cedeira/FacturaElectronica.aspx")
                        {
                            Server.Transfer("FacturaElectronicaXML.aspx");
                        }
                    }
                }
            }
        }
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
			if (CheckBoxAceptarTYC.Checked)
			{
				Session["AceptarTYC"] = true;
				Server.Transfer("~/FacturaElectronicaXML.aspx");
			}
			else
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Debe marcar que acepta los términos y condiciones');</script>");				
			}
        }
    }
}