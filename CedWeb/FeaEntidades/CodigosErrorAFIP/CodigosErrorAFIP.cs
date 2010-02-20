using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosErrorAFIP
{
	public class CodigosErrorAFIP
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

        public static List<CodigoImpuesto> Lista()
        {
            List<CodigoImpuesto> lista = new List<CodigoImpuesto>();
            lista.Add(new Cod01());
            lista.Add(new Cod02());
            lista.Add(new Cod03());
            lista.Add(new Cod04());
            lista.Add(new Cod06());
            lista.Add(new Cod08());
            lista.Add(new Cod09());
            lista.Add(new Cod10());
            lista.Add(new Cod11());
            lista.Add(new Cod13());
            return lista;
        }

		public static List<CodigoImpuesto> ListaANivelLote()
		{
			List<CodigoImpuesto> lista = new List<CodigoImpuesto>();
			lista.Add(new Cod01());
            lista.Add(new Cod02());
            lista.Add(new Cod03());
            lista.Add(new Cod04());
            lista.Add(new Cod06());
			return lista;
		}

        public static List<CodigoImpuesto> ListaANivelComprobante()
        {
            List<CodigoImpuesto> lista = new List<CodigoImpuesto>();
            lista.Add(new Cod08());
            lista.Add(new Cod09());
            lista.Add(new Cod10());
            lista.Add(new Cod11());
            lista.Add(new Cod13());
            return lista;
        }

	}
}