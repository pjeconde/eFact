using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class Vendedor
    {
        public static void Validar(CedWebEntidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            if (Vendedor.CUIT == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("CUIT");
            }
            else
            {
                if (Vendedor.IdCondIVA == 0)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Condición I.V.A.");
                }
            }
        }
        public static void Guardar(CedWebEntidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            //Alta en la base de datos
            CedWebDB.Vendedor vendedor = new CedWebDB.Vendedor(Sesion);
            vendedor.Guardar(Vendedor);
        }
        public static void Leer(CedWebEntidades.Vendedor Vendedor, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Vendedor vendedor = new CedWebDB.Vendedor(Sesion);
            vendedor.Leer(Vendedor);
        }
    }
}