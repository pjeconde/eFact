using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;

namespace CedWebRN
{
    public class Estadistica
    {
        public static List<CedWebEntidades.Estadistica> DeterminarCantidadRegistros(CedEntidades.Sesion Sesion)
        {
            List<CedWebEntidades.Estadistica> lista=new List<CedWebEntidades.Estadistica>();
            CedWebEntidades.Estadistica elemento;
            //Cuentas eFact
            elemento = new CedWebEntidades.Estadistica();
            elemento.Concepto = "Cuentas eFact";
            elemento.Cantidad = CedWebRN.Cuenta.CantidadDeFilas(false, Sesion);
            lista.Add(elemento);
            //Vendedores
            elemento = new CedWebEntidades.Estadistica();
            elemento.Concepto = "Vendedores";
            elemento.Cantidad = CedWebRN.Vendedor.CantidadDeFilasAdministracion(Sesion);
            lista.Add(elemento);
            //Compradores
            elemento = new CedWebEntidades.Estadistica();
            elemento.Concepto = "Compradores";
            elemento.Cantidad = CedWebRN.Comprador.CantidadDeFilasAdministracion(Sesion);
            lista.Add(elemento);
            return lista;
        }
    }
}
