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
        public static void Copiar(CedWebEntidades.Vendedor VendedorDsd, CedWebEntidades.Vendedor VendedorHst)
        {
            VendedorHst.IdCuenta = VendedorDsd.IdCuenta;
            VendedorHst.NombreCuenta = VendedorDsd.NombreCuenta;
            VendedorHst.RazonSocial = VendedorDsd.RazonSocial;
            VendedorHst.Domicilio.Calle = VendedorDsd.Domicilio.Calle;
            VendedorHst.Domicilio.Nro = VendedorDsd.Domicilio.Nro;
            VendedorHst.Domicilio.Piso = VendedorDsd.Domicilio.Piso;
            VendedorHst.Domicilio.Depto = VendedorDsd.Domicilio.Depto;
            VendedorHst.Domicilio.Sector = VendedorDsd.Domicilio.Sector;
            VendedorHst.Domicilio.Torre = VendedorDsd.Domicilio.Torre;
            VendedorHst.Domicilio.Manzana = VendedorDsd.Domicilio.Manzana;
            VendedorHst.Domicilio.Localidad = VendedorDsd.Domicilio.Localidad;
            VendedorHst.Domicilio.IdProvincia = VendedorDsd.Domicilio.IdProvincia;
            VendedorHst.Domicilio.DescrProvincia = VendedorDsd.Domicilio.DescrProvincia;
            VendedorHst.Domicilio.CodPost = VendedorDsd.Domicilio.CodPost;
            VendedorHst.NombreContacto = VendedorDsd.NombreContacto;
            VendedorHst.EmailContacto = VendedorDsd.EmailContacto;
            VendedorHst.TelefonoContacto = VendedorDsd.TelefonoContacto;
            VendedorHst.CUIT = VendedorDsd.CUIT;
            VendedorHst.IdCondIVA = VendedorDsd.IdCondIVA;
            VendedorHst.DescrCondIVA = VendedorDsd.DescrCondIVA;
            VendedorHst.NroIngBrutos = VendedorDsd.NroIngBrutos;
            VendedorHst.IdCondIngBrutos = VendedorDsd.IdCondIngBrutos;
            VendedorHst.DescrCondIngBrutos = VendedorDsd.DescrCondIngBrutos;
            VendedorHst.GLN = VendedorDsd.GLN;
            VendedorHst.CodigoInterno = VendedorDsd.CodigoInterno;
            VendedorHst.FechaInicioActividades = VendedorDsd.FechaInicioActividades;
            VendedorHst.BonoFiscal = VendedorDsd.BonoFiscal;
        }
        public static List<CedWebEntidades.Vendedor> ListaAdministracion(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Vendedor vendedor = new CedWebDB.Vendedor(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Nombre";
            }
            return vendedor.ListaAdministracion(IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilasAdministracion(CedEntidades.Sesion Sesion)
        {
            CedWebDB.Vendedor vendedor = new CedWebDB.Vendedor(Sesion);
            return vendedor.CantidadDeFilasAdministracion();
        }
    }
}