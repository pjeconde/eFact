using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades.TiposPuntoDeVenta
{
    [Serializable]
    public class SinInformar : TipoPuntoDeVenta
    {
        public SinInformar()
        {
            Id = string.Empty;
            Descr = string.Empty;
        }
    }
}