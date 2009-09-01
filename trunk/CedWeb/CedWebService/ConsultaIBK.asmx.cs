using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace CedWebService
{
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
				Cripto cripto = new Cripto();
                string nroSerie = cripto.DecryptData(pathCertificado, Server.MapPath("~/CedWebWS.pubpriv.rsa"));
                CedWebRN.Comprobante c = new CedWebRN.Comprobante();

                using (FileStream fs = File.Open(Server.MapPath("~/Consultar.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("pathCertificado cifrado:" + pathCertificado);
                        sw.WriteLine("pathCertificado descifrado:" + nroSerie);
                    }
                }
                
                clcr = c.ConsultarIBK(clc, nroSerie);
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
