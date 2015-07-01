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
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Copiar(ds, 0, Comprobante);
                }
            }
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
        public List<eFact_Entidades.Comprobante> ConsutarComprobantesVigentes()
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select Comprobantes.*, Lotes.PuntoVenta as PuntoVenta, Lotes.LoteXML from Comprobantes, Lotes, WF_Op where Comprobantes.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente') ");
            commandText.Append("order by Comprobantes.IdLote");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
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
                    CopiarConLoteXML(ds, i, Comprobante);
                    Comprobantes.Add(Comprobante);
                }
            }
            return Comprobantes;
        }
        public List<eFact_Entidades.Comprobante> ConsutarComprobantesVigentesXFecha(string FechaDsd, string FechaHst)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select Comprobantes.*, Lotes.PuntoVenta as PuntoVenta, Lotes.LoteXML from Comprobantes, Lotes, WF_Op where Comprobantes.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente') ");
            commandText.Append("and convert(varchar(8), Comprobantes.Fecha, 112) >= '" + FechaDsd + "' and convert(varchar(8), Comprobantes.Fecha, 112) <= '" + FechaHst + "' ");
            commandText.Append("order by Comprobantes.IdLote");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
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
                    CopiarConLoteXML(ds, i, Comprobante);
                    Comprobantes.Add(Comprobante);
                }
            }
            return Comprobantes;
        }
        private void CopiarConLoteXML(DataSet ds, int NroRowPpal, eFact_Entidades.Comprobante Hasta)
        {
            DataRow Desde;
            Desde = ds.Tables[0].Rows[NroRowPpal];
            Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            Hasta.LoteXml = Convert.ToString(Desde["LoteXml"].ToString());
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
            commandText.Append("Select ComprobantesC.*, Lotes.LoteXML from ComprobantesC, Lotes, WF_Op where ComprobantesC.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente') ");
            commandText.Append("order by ComprobantesC.IdLote");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
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
                    CopiarConLoteXML(ds, i, ComprobanteC);
                    ComprobantesC.Add(ComprobanteC);
                }
            }
            return ComprobantesC;
        }
        public List<eFact_Entidades.ComprobanteC> ConsutarComprobantesCVigentesXFecha(string FechaDsd, string FechaHst)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select ComprobantesC.*, Lotes.LoteXML from ComprobantesC, Lotes, WF_Op where ComprobantesC.IdLote=Lotes.IdLote and Lotes.IdOp=WF_Op.IdOp and WF_Op.IdEstado in ('Vigente')");
            commandText.Append("and convert(varchar(8), ComprobantesC.Fecha, 112) >= '" + FechaDsd + "' and convert(varchar(8), ComprobantesC.Fecha, 112) <= '" + FechaHst + "' ");
            commandText.Append("order by ComprobantesC.IdLote");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);
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
                    CopiarConLoteXML(ds, i, ComprobanteC);
                    ComprobantesC.Add(ComprobanteC);
                }
            }
            return ComprobantesC;
        }
        private void CopiarConLoteXML(DataSet ds, int NroRowPpal, eFact_Entidades.ComprobanteC Hasta)
        {
            DataRow Desde;
            Desde = ds.Tables[0].Rows[NroRowPpal];
            Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            Hasta.LoteXml = Convert.ToString(Desde["LoteXml"].ToString());
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
