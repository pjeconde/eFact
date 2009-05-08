using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class PaginaDefault
    {
        public static List<CedWebEntidades.PaginaDefault> Lista(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.PaginaDefault paginaDefault = new CedWebDB.PaginaDefault(Sesion);
            return paginaDefault.Lista(Cuenta);
        }
        public static CedWebEntidades.PaginaDefault Predeterminada(CedWebEntidades.TipoCuenta TipoCuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.PaginaDefault paginaDefault = new CedWebDB.PaginaDefault(Sesion);
            return paginaDefault.Predeterminada(TipoCuenta);
        }
    }
}