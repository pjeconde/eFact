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
            lista.Add(new Millar());
            lista.Add(new MegaU());
            lista.Add(new UnidadIntActInmung());
            lista.Add(new Gramo());
            lista.Add(new Milimetro());
            lista.Add(new MilimetroCubico());
            lista.Add(new Kilometro());
            lista.Add(new Hectolitro());
            lista.Add(new MegaUnidadIntActInmung());
            lista.Add(new Centimetro());
            return lista;
        }

    }
}
