using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class Comprador
    {
        public static void Validar(CedWebEntidades.Comprador Comprador, CedEntidades.Sesion Sesion)
        {
            if (Comprador.IdTipoDoc == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Tipo Documento");
            }
            else
            {
                if (Comprador.NroDoc == 0)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nro.Documento");
                }
                else
                {
                    if (Comprador.IdCondIVA == 0)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Condición I.V.A.");
                    }
                }
            }
        }
        public static void Crear(CedWebEntidades.Comprador Comprador, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            comprador.Crear(Comprador);
        }
        public static void Modificar(CedWebEntidades.Comprador Comprador, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            comprador.Modificar(Comprador);
        }
        public static void Eliminar(CedWebEntidades.Comprador Comprador, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            comprador.Eliminar(Comprador);
        }
        public static void Leer(CedWebEntidades.Comprador Comprador, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            comprador.Leer(Comprador);
        }
        public static void Limpiar(CedWebEntidades.Comprador Comprador)
        {
            Comprador.IdCuenta = null;
            Comprador.NombreCuenta = null;
            Comprador.RazonSocial = null;
            Comprador.Calle = null;
            Comprador.Nro = null;
            Comprador.Piso = null;
            Comprador.Depto = null;
            Comprador.Sector = null;
            Comprador.Torre = null;
            Comprador.Manzana = null;
            Comprador.Localidad = null;
            Comprador.IdProvincia = null;
            Comprador.DescrProvincia = null;
            Comprador.CodPost = null;
            Comprador.NombreContacto = null;
            Comprador.EmailContacto = null;
            Comprador.TelefonoContacto = null;
            Comprador.IdTipoDoc = 0;
            Comprador.DescrTipoDoc = null;
            Comprador.NroDoc = 0;
            Comprador.IdCondIVA = 0;
            Comprador.DescrCondIVA = null;
            Comprador.NroIngBrutos = null;
            Comprador.IdCondIngBrutos = 0;
            Comprador.DescrCondIngBrutos = null;
            Comprador.GLN = 0;
            Comprador.CodigoInterno = null;
            Comprador.FechaInicioActividades = DateTime.MinValue;
        }
        public static void Copiar(CedWebEntidades.Comprador CompradorDsd, CedWebEntidades.Comprador CompradorHst)
        {
            CompradorHst.IdCuenta = CompradorDsd.IdCuenta;
            CompradorHst.NombreCuenta = CompradorDsd.NombreCuenta;
            CompradorHst.RazonSocial = CompradorDsd.RazonSocial;
            CompradorHst.Calle = CompradorDsd.Calle;
            CompradorHst.Nro = CompradorDsd.Nro;
            CompradorHst.Piso = CompradorDsd.Piso;
            CompradorHst.Depto = CompradorDsd.Depto;
            CompradorHst.Sector = CompradorDsd.Sector;
            CompradorHst.Torre = CompradorDsd.Torre;
            CompradorHst.Manzana = CompradorDsd.Manzana;
            CompradorHst.Localidad = CompradorDsd.Localidad;
            CompradorHst.IdProvincia = CompradorDsd.IdProvincia;
            CompradorHst.DescrProvincia = CompradorDsd.DescrProvincia;
            CompradorHst.CodPost = CompradorDsd.CodPost;
            CompradorHst.NombreContacto = CompradorDsd.NombreContacto;
            CompradorHst.EmailContacto = CompradorDsd.EmailContacto;
            CompradorHst.TelefonoContacto = CompradorDsd.TelefonoContacto;
            CompradorHst.IdTipoDoc = CompradorDsd.IdTipoDoc;
            CompradorHst.DescrTipoDoc = CompradorDsd.DescrTipoDoc;
            CompradorHst.NroDoc = CompradorDsd.NroDoc;
            CompradorHst.IdCondIVA = CompradorDsd.IdCondIVA;
            CompradorHst.DescrCondIVA = CompradorDsd.DescrCondIVA;
            CompradorHst.NroIngBrutos = CompradorDsd.NroIngBrutos;
            CompradorHst.IdCondIngBrutos = CompradorDsd.IdCondIngBrutos;
            CompradorHst.DescrCondIngBrutos = CompradorDsd.DescrCondIngBrutos;
            CompradorHst.GLN = CompradorDsd.GLN;
            CompradorHst.CodigoInterno = CompradorDsd.CodigoInterno;
            CompradorHst.FechaInicioActividades = CompradorDsd.FechaInicioActividades;
        }
        public static List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "RazonSocial";
            }
            return comprador.Lista(Cuenta, IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilas(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            return comprador.CantidadDeFilas(Cuenta);
        }
		public static List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
		{
			CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
			return comprador.Lista(Cuenta);
		}
    }
}