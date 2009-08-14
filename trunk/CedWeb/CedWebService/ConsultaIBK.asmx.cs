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
            CedWebRN.IBK.consulta_lote_comprobantes_response clcr = new CedWebRN.IBK.consulta_lote_comprobantes_response();
            try
            {
                CedWebRN.Comprobante c = new CedWebRN.Comprobante();
                clcr = c.ConsultarIBK(clc, pathCertificado);
            }
            catch (Exception ex)
            {
                throw ExcepcionesSOAP.RaiseException("Consultar", "http://www.cedeira.com.ar/webservices", ex.Message,
                    "0", ex.Source, FaultCode.Server);

            }
            return clcr;
        }
    }
}
