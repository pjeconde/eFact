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
using CedeiraUIWebForms;

namespace CedeiraAJAX.Excepciones
{
    public partial class Excepcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UrlParameterPasser urlWrapper = new UrlParameterPasser();
                string exString = urlWrapper["ex"];
                Exception ex = new Exception(exString);
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                ExLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
            catch
            {
                string auxEx = "Excepci�n tratando de mostrar o publicar la excepci�n original";
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(new Exception(auxEx));
                ExLabel.Text = auxEx;
            }
        }
    }
}
