using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eFact_I_Bj.RN
{
    public class TableroBj
    {
        public enum TipoConsulta
        {
            /// <comentarios/>
            Todos,
            /// <comentarios/>
            ComprobantesAProcesar,
            /// <comentarios/>
            ComprobantesProcesados, 
        }
        public static void ConsultarComprobantes(out List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes, TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string IdTipoComprobante, string PuntoVenta, string NumeroComprobante, bool VerificarExistenciaCAE, CedEntidades.Sesion Sesion)
        {
            List<eFact_I_Bj.Entidades.ComprobanteBj> comprobantes = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            eFact_I_Bj.RN.ComprobanteBj.Consultar(comprobantes, TipoConsulta, FechaDsd, FechaHst, IdTipoComprobante, PuntoVenta, NumeroComprobante, VerificarExistenciaCAE, Sesion);
            Comprobantes = comprobantes;
        }
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
    }
}
