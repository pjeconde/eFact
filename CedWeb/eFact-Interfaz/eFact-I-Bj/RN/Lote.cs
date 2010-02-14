using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.RN
{
    class Lote
    {
        public static void Consultar(eFact_I_Bj.Entidades.ComprobanteBj ComprobanteBj, CedEntidades.Sesion Sesion)
        {
            eFact_I_Bj.DB.Lote l = new eFact_I_Bj.DB.Lote(Sesion);
            l.Consultar(ComprobanteBj);
        }
    }
}
