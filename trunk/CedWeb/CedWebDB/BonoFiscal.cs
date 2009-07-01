using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class BonoFiscal : db
    {
        public BonoFiscal(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Vendedor Vendedor)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select BonoFiscal.PuntoDeVentaHabilitado from BonoFiscal ");
            a.Append("where BonoFiscal.CUIT=" + Convert.ToString(Vendedor.CUIT) + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count > 0)
            {
                Vendedor.BonoFiscal.PuntoDeVentaHabilitado.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vendedor.BonoFiscal.PuntoDeVentaHabilitado.Add(Convert.ToInt32(dt.Rows[i]["PuntoDeVentaHabilitado"]));
                }
            }
        }
    }
}