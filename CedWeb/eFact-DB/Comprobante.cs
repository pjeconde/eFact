using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_DB
{
    public class Comprobante : db
    {
        public Comprobante(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(eFact_Entidades.Comprobante Comprobante)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Comprobantes");
            commandText.Append(" where IdLote=" + Comprobante.IdLote + " and IdTipoComprobante = '" + Comprobante.IdTipoComprobante + "' and NumeroComprobante='" + Comprobante.NumeroComprobante + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            Comprobante.IdLote = Convert.ToInt32(dt.Rows[0]["IdLote"].ToString());
            Comprobante.TipoDocComprador = Convert.ToInt16(dt.Rows[0]["TipoDocComprador"]);
            Comprobante.NroDocComprador = dt.Rows[0]["NroDocComprador"].ToString();
            Comprobante.NombreComprador = dt.Rows[0]["NombreComprador"].ToString();
            Comprobante.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
            Comprobante.IdMoneda = dt.Rows[0]["IdMoneda"].ToString();
            Comprobante.Importe = Convert.ToDecimal(dt.Rows[0]["Importe"]);
            Comprobante.Importe = Convert.ToDecimal(dt.Rows[0]["ImporteMonedaOrigen"]);
            Comprobante.Importe = Convert.ToDecimal(dt.Rows[0]["TipoCambio"]);
        }
        public bool ConsutarComprobanteVigente(eFact_Entidades.Comprobante Comprobante)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Comprobantes, Lotes, WF_Op where Comprobantes.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente')");
            commandText.Append("PuntoVenta=" + Comprobante.PuntoVenta + " and IdTipoComprobante = '" + Comprobante.IdTipoComprobante + "' and NumeroComprobante='" + Comprobante.NumeroComprobante + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ConsutarComprobanteCVigente(eFact_Entidades.ComprobanteC Comprobante)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from ComprobantesC, Lotes, WF_Op where Comprobantes.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente')");
            commandText.Append("PuntoVenta=" + Comprobante.PuntoVenta + " and IdTipoComprobante = '" + Comprobante.IdTipoComprobante + "' and NumeroComprobante='" + Comprobante.NumeroComprobante + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
