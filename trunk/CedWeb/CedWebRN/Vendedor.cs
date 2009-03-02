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
        public static void Limpiar(CedWebEntidades.Vendedor Vendedor)
        {
            Vendedor.IdCuenta = null;
            Vendedor.NombreCuenta = null;
            Vendedor.RazonSocial = null;
            Vendedor.Calle = null;
            Vendedor.Nro = null;
            Vendedor.Piso = null;
            Vendedor.Depto = null;
            Vendedor.Sector = null;
            Vendedor.Torre = null;
            Vendedor.Manzana = null;
            Vendedor.Localidad = null;
            Vendedor.IdProvincia = null;
            Vendedor.DescrProvincia = null;
            Vendedor.CodPost = null;
            Vendedor.NombreContacto = null;
            Vendedor.EmailContacto = null;
            Vendedor.TelefonoContacto = 0;
            Vendedor.CUIT = 0;
            Vendedor.IdCondIVA = 0;
            Vendedor.DescrCondIVA = null;
            Vendedor.NroIngBrutos = null;
            Vendedor.IdCondIngBrutos = 0;
            Vendedor.DescrCondIngBrutos = null;
            Vendedor.GLN = 0;
            Vendedor.CodigoInterno = null;
            Vendedor.FechaInicioActividades = DateTime.MinValue;
        }
        public static void Copiar(CedWebEntidades.Vendedor VendedorDsd, CedWebEntidades.Vendedor VendedorHst)
        {
            VendedorHst.IdCuenta = VendedorDsd.IdCuenta;
            VendedorHst.NombreCuenta = VendedorDsd.NombreCuenta;
            VendedorHst.RazonSocial = VendedorDsd.RazonSocial;
            VendedorHst.Calle = VendedorDsd.Calle;
            VendedorHst.Nro = VendedorDsd.Nro;
            VendedorHst.Piso = VendedorDsd.Piso;
            VendedorHst.Depto = VendedorDsd.Depto;
            VendedorHst.Sector = VendedorDsd.Sector;
            VendedorHst.Torre = VendedorDsd.Torre;
            VendedorHst.Manzana = VendedorDsd.Manzana;
            VendedorHst.Localidad = VendedorDsd.Localidad;
            VendedorHst.IdProvincia = VendedorDsd.IdProvincia;
            VendedorHst.DescrProvincia = VendedorDsd.DescrProvincia;
            VendedorHst.CodPost = VendedorDsd.CodPost;
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
        }
    }
}