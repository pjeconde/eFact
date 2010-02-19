using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosImpuesto
{
	public class IB : CodigoImpuesto
	{
		public IB()
		{
			Codigo = "10";
			Descr = "LA CUIT INDICADA EN EL CAMPO NRO. DE IDENTIFICACION DEL COMPRADOR NO CORRESPONDE A UN RESPONSABLE INSCRIPTO EN EL IVA ACTIVO";
		}
	}
}
