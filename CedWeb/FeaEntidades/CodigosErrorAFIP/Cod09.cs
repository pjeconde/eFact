using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosImpuesto
{
	public class IB : CodigoImpuesto
	{
		public IB()
		{
			Codigo = "09";
			Descr = "LA CUIT INDICADA EN EL CAMPO NRO DE IDENTIFICACION DEL COMPRADOR NO EXISTE EN EL PADRON UNICO DE CONTRIBUYENTES";
		}
	}
}
