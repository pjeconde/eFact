using System;
using System.Collections.Generic;
using System.Text;

namespace CedWebRN
{
	public class Certificado
	{
		public static int CantidadDeFilas(CedEntidades.Sesion Sesion)
		{
			CedWebDB.Certificado certificado = new CedWebDB.Certificado(Sesion);
			return certificado.CantidadDeFilas();
		}
		public static List<CedWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
		{
			CedWebDB.Certificado certificado = new CedWebDB.Certificado(Sesion);
			if (OrderBy.Equals(String.Empty))
			{
				OrderBy = "NroSerieCertificado desc, IdCuenta";
			}
			return certificado.Lista(IndicePagina, TamañoPagina, OrderBy);
		}
	}
}
