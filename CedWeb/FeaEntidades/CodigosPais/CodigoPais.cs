using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosPais
{
	public class CodigoPais
	{
		private int codigo;
		private string descr;

		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}

		public string Descr
		{
			get { return descr; }
			set { descr = value; }
		}

		public static List<CodigoPais> Lista()
		{
            List<CodigoPais> lista = new List<CodigoPais>();
			lista.Add(new BurkinaFaso());
			lista.Add(new Argelia());
            lista.Add(new Botswana());
			return lista;
		}
	}
}
