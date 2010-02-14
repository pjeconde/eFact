using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.RN
{
    class ComprobanteBj
    {
        public static void Consultar(List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes, eFact_I_Bj.RN.TableroBj.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string IdTipoComprobante, string PuntoVenta, string NumeroComprobante, bool VerificarExistenciaCAE, CedEntidades.Sesion Sesion)
        {
            //List<eFact_I_Bj.Entidades.ComprobanteBj> comprobantes = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            eFact_I_Bj.DB.ComprobanteBj c = new eFact_I_Bj.DB.ComprobanteBj(Sesion);
            c.Consultar(Comprobantes, TipoConsulta, FechaDsd, FechaHst, IdTipoComprobante, PuntoVenta, NumeroComprobante, VerificarExistenciaCAE);
        }
    }
}
