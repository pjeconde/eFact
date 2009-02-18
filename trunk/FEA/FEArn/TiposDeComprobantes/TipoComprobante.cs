using System;
using System.Collections.Generic;
using System.Text;

namespace FEArn.TiposDeComprobantes
{
	public class TipoComprobante
	{
		public static List<FeaEntidades.TiposDeComprobantes.TipoComprobante> Lista()
		{
			List<FeaEntidades.TiposDeComprobantes.TipoComprobante> lista = new List<FeaEntidades.TiposDeComprobantes.TipoComprobante>();
			lista.Add(new FeaEntidades.TiposDeComprobantes.Facturas.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasDebito.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasCredito.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Recibos.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasDeVentaAlContado.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Facturas.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasDebito.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasCredito.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Recibos.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.NotasDeVentaAlContado.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Otros.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Otros.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.CuentaDeVentaYLiquido.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.CuentaDeVentaYLiquido.B());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Liquidacion.A());
			lista.Add(new FeaEntidades.TiposDeComprobantes.Liquidacion.B());
			return lista;
		}
	}
}
