using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades.TiposPuntoDeVenta
{
    [Serializable]
    public class TipoPuntoDeVenta
    {
        private string id;
        private string descr;

        public TipoPuntoDeVenta()
        {
        }
        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
        public static List<TipoPuntoDeVenta> Lista()
        {
            List<TipoPuntoDeVenta> lista = new List<TipoPuntoDeVenta>();
            lista.Add(new SinInformar());
            lista.Add(new BonoFiscal());
            lista.Add(new Exportacion());
            lista.Add(new Comun());
            lista.Add(new RG2904());
            return lista;
        }
        public static List<TipoPuntoDeVenta> ListaInf()
        {
            List<TipoPuntoDeVenta> lista = new List<TipoPuntoDeVenta>();
            lista.Add(new BonoFiscal());
            lista.Add(new Exportacion());
            lista.Add(new Comun());
            lista.Add(new RG2904());
            return lista;
        }
    }
}