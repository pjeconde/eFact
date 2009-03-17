using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace CedWebRN
{
    public class Fun
    {
        public static bool NoHayNadieLogueado(CedWebEntidades.Sesion Sesion)
        {
            bool b = (Sesion.Cuenta.Id == null);
            return b;
        }
        public static bool NoEstaLogueadoUnAdministrador(CedWebEntidades.Sesion Sesion)
        {
            bool b = (Sesion.Cuenta.TipoCuenta.Id != "Admin" || Sesion.Cuenta.EstadoCuenta.Id != "Vigente");
            return b;
        }
        public static bool NoEstaLogueadoUnUsuarioPremium(CedWebEntidades.Sesion Sesion)
        {
            bool b = (Sesion.Cuenta.TipoCuenta.Id != "Prem" || Sesion.Cuenta.EstadoCuenta.Id != "Vigente");
            return b;
        }
    }
}
