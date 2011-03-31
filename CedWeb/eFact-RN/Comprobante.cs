using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_RN
{
    public class Comprobante
    {
        public static void Leer(eFact_Entidades.Comprobante Comprobante, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Comprobante c = new eFact_DB.Comprobante(Sesion);
            c.Leer(Comprobante);
        }
    }
}
