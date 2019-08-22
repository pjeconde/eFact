using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasCredito
{
    [Serializable]
    public class MiPyMEsB : NotaCredito
    {
        public MiPyMEsB()
        {
            codigo = 208;
            descr = "Nota de Crédito MiPyMEs B";
        }
    }
}
