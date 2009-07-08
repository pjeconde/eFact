using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class Publicacion
    {
        public static List<CedWebEntidades.Publicacion> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Publicacion publicacion = new CedWebDB.Publicacion(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdPublicacion desc";
            }
            return publicacion.Lista(IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilas(CedEntidades.Sesion Sesion)
        {
            CedWebDB.Publicacion publicacion = new CedWebDB.Publicacion(Sesion);
            return publicacion.CantidadDeFilas();
        }
    }
}
