using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_RN
{
    public class Vendedor
    {
        public static void Leer(eFact_Entidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Vendedor v = new eFact_DB.Vendedor(Sesion);
            v.Leer(Vendedor);
        }
        public static void Consultar(List<eFact_Entidades.Vendedor> Vendedores, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Vendedor v = new eFact_DB.Vendedor(Sesion);
            v.Consultar(Vendedores);
        }
        public static void Modificar(eFact_Entidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Vendedor v = new eFact_DB.Vendedor(Sesion);
            v.Modificar(Vendedor);
        }
    }
}
