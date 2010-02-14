using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_I_Bj.DB
{
    public class Lote : db
    {
        public Lote(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Consultar(eFact_I_Bj.Entidades.ComprobanteBj ComprobanteBj)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select Lotes.IdLote, IdEstado from Lotes, wf_op where Lotes.IdOp = wf_Op.IdOp and Lotes.IdLote = (Select Max(Lotes.IdLote) as IdLote from Lotes, Comprobantes ");
            commandText.Append("where Lotes.IdLote = Comprobantes.IdLote and Lotes.PuntoVenta = '" + Convert.ToInt32(ComprobanteBj.PuntoVenta) + "' and Comprobantes.IdTipoComprobante = '" + ComprobanteBj.IdTipoComprobante + "' and Comprobantes.NumeroComprobante = '" + Convert.ToInt32(ComprobanteBj.NumeroComprobante) + "')");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            ComprobanteBj.IdEstado =  dt.Rows[0]["IdEstado"].ToString() + "  Lote (" + dt.Rows[0]["IdLote"].ToString() + ")";
        }
    }
}
