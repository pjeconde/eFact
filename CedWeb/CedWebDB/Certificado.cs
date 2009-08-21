using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace CedWebDB
{
	public class Certificado : db
	{
		public Certificado(CedEntidades.Sesion Sesion)
			: base(Sesion)
        {
        }
		public int CantidadDeFilas()
		{
			string commandText;
			commandText = "select count(*) from cuenta where NroSerieCertificado<>'' ";
			DataTable dt = new DataTable();
			dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
			return Convert.ToInt32(dt.Rows[0][0]);
		}
		public List<CedWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy)
		{
			System.Text.StringBuilder a = new StringBuilder();
			a.Append("select * ");
			a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
			a.Append("Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.NroSerieCertificado ");
			a.Append("from Cuenta ");
			a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
			string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
			DataTable dt = new DataTable();
			dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
			List<CedWebEntidades.Cuenta> lista = new List<CedWebEntidades.Cuenta>();
			if (dt.Rows.Count != 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					CedWebEntidades.Cuenta c = new CedWebEntidades.Cuenta();
					Copiar(dt.Rows[i], c);
					lista.Add(c);
				}
			}
			return lista;
		}
		private void Copiar(DataRow Desde, CedWebEntidades.Cuenta Hasta)
		{
			Hasta.Id = Convert.ToString(Desde["IdCuenta"]);
			Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
			Hasta.NroSerieCertificado = Convert.ToString(Desde["NroSerieCertificado"]);
		}
	}
}
