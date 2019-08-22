using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.Facturas
{
    [Serializable]
    public class MiPyMEsB : Factura
    {
        public MiPyMEsB()
        {
            codigo = 206;
            descr = "Factura de Crédito MiPyMEs B";
        }
    }
}
