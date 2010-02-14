using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_R.DB
{
    public class Comprobante : db
    {
        public Comprobante(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(eFact_R.Entidades.Comprobante Comprobante)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Comprobantes");
            commandText.Append(" where IdLote=" + Comprobante.IdLote + " and IdTipoComprobante = '" + Comprobante.IdTipoComprobante + "' and NumeroComprobante='" + Comprobante.NumeroComprobante + "'");
            //if (Comprobante.NumeroDeEnvio != 0) 
            //{
            //    commandText.Append(+ "' and NumeroDeEnvio=" + Comprobante.NumeroDeEnvio);
            //}
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            Comprobante.IdLote = Convert.ToInt32(dt.Rows[0]["IdLote"].ToString());
            Comprobante.TipoDocComprador = dt.Rows[0]["TipoDocComprador"].ToString();
            Comprobante.NroDocComprador = dt.Rows[0]["NroDocComprador"].ToString();
            Comprobante.NombreComprador = dt.Rows[0]["NombreComprador"].ToString();
            Comprobante.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
            Comprobante.IdMoneda = dt.Rows[0]["IdMoneda"].ToString();
            Comprobante.Importe = Convert.ToDecimal(dt.Rows[0]["Importe"]);
        }
    }
}
