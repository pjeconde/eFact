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
    public partial class FacturaElectronicaPreguntasFrec : System.Web.UI.Page
    {
        protected void VolverLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/FacturaElectronicaSolucionDeConectividad.aspx");
        }
    }
}
