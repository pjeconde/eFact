using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_R.RN
{
    class Vendedor
    {
        public static void Leer(eFact_R.Entidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Vendedor v = new eFact_R.DB.Vendedor(Sesion);
            v.Leer(Vendedor);
        }
        public static void Consultar(List<eFact_R.Entidades.Vendedor> Vendedores, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Vendedor v = new eFact_R.DB.Vendedor(Sesion);
            v.Consultar(Vendedores);
        }
        public static void Modificar(eFact_R.Entidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Vendedor v = new eFact_R.DB.Vendedor(Sesion);
            v.Modificar(Vendedor);
        }
    }
}
