using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Security.Cryptography;

namespace CedWeb.WS
{
    [WebService(Namespace = "http://cedeira.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ServApps : System.Web.Services.WebService
    {
        private CedEntidades.Sesion Sesion()
        {
            //string aux = System.IO.Directory.GetParent(Server.MapPath("")).ToString();
            System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
            string ambiente = System.Configuration.ConfigurationManager.AppSettings["Ambiente"].ToString();
            auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"].ToString());
            auxCnn.Append("User Id=");
            auxCnn.Append("");
            auxCnn.Append(";Password=");
            auxCnn.Append("");
            auxCnn.Append(";");
			CedWebEntidades.Aplicacion aplic = CedWebRN.Aplicacion.Crear();
			CedEntidades.Sesion sesion = new CedEntidades.Sesion();
			Cedeira.SV.Sesion.Crear("ServApps", String.Empty, "NONE", auxCnn.ToString(), "ServApps", aplic.Version, aplic.VersionParaControl, sesion);
			return sesion;
        }
		private void Desencriptar(string Verificador)
		{
			System.Text.StringBuilder clavePropia = new System.Text.StringBuilder(Server.MapPath(@"~\WS\"));
			clavePropia.Append(System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"]);
			System.Text.StringBuilder claveBPproxy = new System.Text.StringBuilder(Server.MapPath(@"~\WS\"));
			claveBPproxy.Append("CBPproxy");
			Cedeira.SV.Cripto cripto = new Cedeira.SV.Cripto();
			string verificador = cripto.DecryptData(Verificador, clavePropia.ToString());
		}
    }
}