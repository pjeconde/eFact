using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosUnidad
{
    public class CodigoUnidad
    {
        private short codigo;
        private string descr;

        public short Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<CodigoUnidad> Lista()
        {
            List<CodigoUnidad> lista = new List<CodigoUnidad>();
            lista.Add(new SinInformar());
            lista.Add(new Kilogramo());
            lista.Add(new Metros());
            lista.Add(new MetroCuadrado());
            lista.Add(new MetroCubico());
            lista.Add(new Litros());
            lista.Add(new KilowattHora());
            lista.Add(new Unidad());
            lista.Add(new Par());
            lista.Add(new Docena());
            lista.Add(new Quilate());
            return lista;
        }

    }
}
