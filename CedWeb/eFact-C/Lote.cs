using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_C
{
    public class Lote
    {
        private string uRL;
        private eFact_C.Entidades.Certificado certificado;
        private eFact_C.Entidades.Proxy proxy;
        //Constructor
        public Lote(string URL, eFact_C.Entidades.Certificado Certificado, eFact_C.Entidades.Proxy Proxy)
        {
            uRL = URL;
            certificado = Certificado;
            proxy = Proxy;
        }
        //Funcion
        public FeaEntidades.InterFacturas.lote_comprobantes Consultar(eFact_C.Entidades.LoteConsulta LoteConsulta, out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes)
        {
            List<FeaEntidades.InterFacturas.error> respErroresLote;
            List<FeaEntidades.InterFacturas.error> respErroresComprobantes;
            try
            {
                eFact_C.Comprobante c = new eFact_C.Comprobante();
                eFact_C.IBK.consulta_lote_comprobantes clc = new eFact_C.IBK.consulta_lote_comprobantes();
                clc.cuit_canal = LoteConsulta.CuitCanal;
                clc.cuit_vendedor = LoteConsulta.CuitVendedor;
                clc.punto_de_venta = LoteConsulta.PuntoVenta;
                clc.punto_de_ventaSpecified = true;
                clc.id_lote = LoteConsulta.Numero;
                FeaEntidades.InterFacturas.lote_comprobantes lc;
                lc = c.ConsultarIBK(out respErroresLote, out respErroresComprobantes, clc, uRL, certificado, proxy);
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FeaEntidades.InterFacturas.lote_response Enviar(FeaEntidades.InterFacturas.lote_comprobantes Lc, out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes)
        {
            List<FeaEntidades.InterFacturas.error> respErroresLote;
            List<FeaEntidades.InterFacturas.error> respErroresComprobantes;
            try
            {
                eFact_C.Comprobante c = new eFact_C.Comprobante();
                FeaEntidades.InterFacturas.lote_response loteResponse;
                loteResponse = c.EnviarIBK(out respErroresLote, out respErroresComprobantes, Lc, uRL, certificado, proxy);
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                return loteResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
