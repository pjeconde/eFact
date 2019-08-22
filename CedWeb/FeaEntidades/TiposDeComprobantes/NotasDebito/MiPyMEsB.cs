using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.TiposDeComprobantes.NotasDebito
{
    [Serializable]
    public class MiPyMEsB : NotaDebito
    {
        public MiPyMEsB()
        {
            codigo = 207;
            descr = "Nota de Débito MiPyMEs B";
        }
    }
}
