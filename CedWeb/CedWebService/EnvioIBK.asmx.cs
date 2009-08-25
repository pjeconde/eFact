using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace CedWebService
{
    [WebService(Namespace = "http://www.cedeira.com.ar/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class EnvioIBK : System.Web.Services.WebService
    {
        [WebMethod]
        public CedWebRN.IBK.lote_comprobantes_response EnviarIBK(FeaEntidades.InterFacturas.lote_comprobantes lc, string pathCertificado)
        {
			CedWebRN.IBK.lote_comprobantes_response lcr = new CedWebRN.IBK.lote_comprobantes_response();
			try
			{
				Cripto cripto = new Cripto();
				string nroSerie = cripto.DecryptData(pathCertificado, Server.MapPath("~/CedWebWS.pubpriv.rsa"));

				CedWebRN.Comprobante c = new CedWebRN.Comprobante();
				lcr = c.EnviarIBK(lc, nroSerie);
			}
			catch (Exception ex)
			{
				throw ExcepcionesSOAP.RaiseException("Enviar", "http://www.cedeira.com.ar/webservices", ex.Message,
					"0", ex.Source, FaultCode.Server);

			}
            return lcr;
        }
    }
}
