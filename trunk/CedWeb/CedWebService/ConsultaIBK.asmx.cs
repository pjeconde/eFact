using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace CedWebService
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://www.cedeira.com.ar/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ConsultaIBK : System.Web.Services.WebService
    {

        [WebMethod]
        public CedWebRN.IBK.consulta_lote_comprobantes_response Consultar(CedWebRN.IBK.consulta_lote_comprobantes clc, string pathCertificado)
        {
            CedWebRN.IBK.FacturaWebServiceConSchemaSoapBindingQSService objIBK;
            objIBK = new CedWebRN.IBK.FacturaWebServiceConSchemaSoapBindingQSService();
            System.Security.Cryptography.X509Certificates.X509Certificate cert = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(pathCertificado);
            objIBK.ClientCertificates.Add(cert);
            CedWebRN.IBK.consulta_lote_comprobantes_response clcr = objIBK.getLoteFacturasConSchema(clc);
            return clcr;
        }
    }
}
