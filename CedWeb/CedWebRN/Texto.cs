using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebRN
{
    public static class Texto
    {
        public static void Leer(CedWebEntidades.Texto Texto, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Texto texto = new CedWebDB.Texto(Sesion);
            texto.Leer(Texto);
        }
    }
}