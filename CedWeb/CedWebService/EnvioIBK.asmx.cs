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
            CedWebRN.Comprobante c = new CedWebRN.Comprobante();
            CedWebRN.IBK.lote_comprobantes_response lcr = c.EnviarIBK(lc, pathCertificado);
            return lcr;
        }
    }
}
