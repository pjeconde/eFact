using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosImpuesto
{
	public class IB : CodigoImpuesto
	{
		public IB()
		{
			Codigo = "02";
			Descr = "LA CUIT INFORMADA NO SE ENCUENTRA AUTORIZADA A EMITIR COMPROBANTES ELECTRONICOS ORIGINALES O EL PERIODO DE INICIO AUTORIZADO ES POSTERIOR AL DE LA GENERACION DE LA SOLICITUD";
		}
	}
}
