using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebRN
{
    public static class Flag
    {
        public static void Leer(CedWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Flag flag = new CedWebDB.Flag(Sesion);
            flag.Leer(Flag);
        }
        public static void SetearModoDepuracion(CedWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Flag flag = new CedWebDB.Flag(Sesion);
            flag.SetearModoDepuracion(Flag);
        }
        public static void SetearPremiumSinCostoEnAltaCuenta(CedWebEntidades.Flag Flag, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Flag flag = new CedWebDB.Flag(Sesion);
            flag.SetearPremiumSinCostoEnAltaCuenta(Flag);
        }
    }
}