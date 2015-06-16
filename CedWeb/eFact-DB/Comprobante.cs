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
            Comprobante.ImporteMonedaOrigen = Convert.ToDecimal(dt.Rows[0]["ImporteMonedaOrigen"]);
            Comprobante.TipoCambio = Convert.ToDecimal(dt.Rows[0]["TipoCambio"]);
        }
        public List<eFact_Entidades.Comprobante> ConsutarComprobantesVigentes()
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Comprobantes, Lotes, WF_Op where Comprobantes.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente')");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText, TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
            List<eFact_Entidades.Comprobante> Comprobantes = new List<eFact_Entidades.Comprobante>();
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eFact_Entidades.Comprobante Comprobante = new eFact_Entidades.Comprobante();
                    Copiar(ds, i, Comprobante);
                    Comprobantes.Add(Comprobante);
                }
            }
            return Comprobantes;
        }
        private void Copiar(DataSet ds, int NroRowPpal, eFact_Entidades.Comprobante Hasta)
        {
            DataRow Desde;
            Desde = ds.Tables[0].Rows[NroRowPpal];
            Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            Hasta.PuntoVenta = Convert.ToString(Desde["PuntoVenta"]);
            Hasta.IdTipoComprobante = Convert.ToInt16(Desde["IdTipoComprobante"]);
            Hasta.NumeroComprobante = Convert.ToString(Desde["NumeroComprobante"]);
            Hasta.TipoDocComprador = Convert.ToInt16(Desde["TipoDocComprador"]);
            Hasta.NroDocComprador = Desde["NroDocComprador"].ToString();
            Hasta.NombreComprador = Desde["NombreComprador"].ToString();
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.IdMoneda = Convert.ToString(Desde["IdMoneda"]);
            Hasta.Importe = Convert.ToDecimal(Desde["Importe"]);
            Hasta.ImporteMonedaOrigen = Convert.ToDecimal(Desde["ImporteMonedaOrigen"]);
            Hasta.TipoCambio = Convert.ToDecimal(Desde["TipoCambio"]);
        }
        public List<eFact_Entidades.ComprobanteC> ConsutarComprobantesCVigentes()
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from ComprobantesC, Lotes, WF_Op where ComprobantesC.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente')");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText, TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
            List<eFact_Entidades.ComprobanteC> ComprobantesC = new List<eFact_Entidades.ComprobanteC>();
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eFact_Entidades.ComprobanteC ComprobanteC = new eFact_Entidades.ComprobanteC();
                    Copiar(ds, i, ComprobanteC);
                    ComprobantesC.Add(ComprobanteC);
                }
            }
            return ComprobantesC;
        }
        private void Copiar(DataSet ds, int NroRowPpal, eFact_Entidades.ComprobanteC Hasta)
        {
            DataRow Desde;
            Desde = ds.Tables[0].Rows[NroRowPpal];
            Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            Hasta.PuntoVenta = Convert.ToString(Desde["PuntoVenta"]);
            Hasta.IdTipoComprobante = Convert.ToInt16(Desde["IdTipoComprobante"]);
            Hasta.NumeroComprobante = Convert.ToString(Desde["NumeroComprobante"]);
            Hasta.TipoDocVendedor = Convert.ToInt16(Desde["TipoDocVendedor"]);
            Hasta.NroDocVendedor = Desde["NroDocVendedor"].ToString();
            Hasta.NombreVendedor = Desde["NombreVendedor"].ToString();
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.IdMoneda =Convert.ToString(Desde["IdMoneda"]);
            Hasta.Importe = Convert.ToDecimal(Desde["Importe"]);
            Hasta.ImporteMonedaOrigen = Convert.ToDecimal(Desde["ImporteMonedaOrigen"]);
            Hasta.TipoCambio = Convert.ToDecimal(Desde["TipoCambio"]);
        }
    }
}
