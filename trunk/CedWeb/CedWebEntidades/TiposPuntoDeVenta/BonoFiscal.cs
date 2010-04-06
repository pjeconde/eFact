using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades.TiposPuntoDeVenta
{
    [Serializable]
    public class BonoFiscal : TipoPuntoDeVenta
    {
        public BonoFiscal()
        {
            Id = "BFiscal";
            Descr = "Bono Fiscal";
        }
    }
}