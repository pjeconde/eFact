using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_R.RN
{
    class Comprobante
    {
        public static void Leer(eFact_R.Entidades.Comprobante Comprobante, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Comprobante c = new eFact_R.DB.Comprobante(Sesion);
            c.Leer(Comprobante);
        }
    }
}
