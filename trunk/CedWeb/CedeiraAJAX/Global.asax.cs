using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CedeiraAJAX
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            CedWebEntidades.Sesion s = new CedWebEntidades.Sesion();
            s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
            s.MensajeGeneral = System.Configuration.ConfigurationManager.AppSettings["MensajeGeneral"];
            s.CantidadDiasPremiumSinCostoEnAltaCuenta = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CantidadDiasPremiumSinCostoEnAltaCuenta"]);
            CedWebRN.Flag.Leer(s.Flag, s);
            Session["Sesion"] = s;
        }
    }
}