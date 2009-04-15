using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class Medio
    {
        public static List<CedWebEntidades.Medio> Lista(CedEntidades.Sesion Sesion)
        {
            CedWebDB.Medio medio = new CedWebDB.Medio(Sesion);
            return medio.Lista();
        }
    }
}