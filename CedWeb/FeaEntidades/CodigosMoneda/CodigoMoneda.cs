using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosMoneda
{
	public class CodigoMoneda
	{
		private string codigo;
		private string descr;

		public string Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<CodigoMoneda> Lista()
		{
			List<CodigoMoneda> lista = new List<CodigoMoneda>();
			lista.Add(new Pesos());
			lista.Add(new DolarUSA());
			return lista;
		}
	}
}
