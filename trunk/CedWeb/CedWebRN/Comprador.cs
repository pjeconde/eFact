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
            Comprador.Domicilio.Calle = null;
            Comprador.Domicilio.Nro = null;
            Comprador.Domicilio.Piso = null;
            Comprador.Domicilio.Depto = null;
            Comprador.Domicilio.Sector = null;
            Comprador.Domicilio.Torre = null;
            Comprador.Domicilio.Manzana = null;
            Comprador.Domicilio.Localidad = null;
            Comprador.Domicilio.IdProvincia = null;
            Comprador.Domicilio.DescrProvincia = null;
            Comprador.Domicilio.CodPost = null;
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
            CompradorHst.Domicilio.Calle = CompradorDsd.Domicilio.Calle;
            CompradorHst.Domicilio.Nro = CompradorDsd.Domicilio.Nro;
            CompradorHst.Domicilio.Piso = CompradorDsd.Domicilio.Piso;
            CompradorHst.Domicilio.Depto = CompradorDsd.Domicilio.Depto;
            CompradorHst.Domicilio.Sector = CompradorDsd.Domicilio.Sector;
            CompradorHst.Domicilio.Torre = CompradorDsd.Domicilio.Torre;
            CompradorHst.Domicilio.Manzana = CompradorDsd.Domicilio.Manzana;
            CompradorHst.Domicilio.Localidad = CompradorDsd.Domicilio.Localidad;
            CompradorHst.Domicilio.IdProvincia = CompradorDsd.Domicilio.IdProvincia;
            CompradorHst.Domicilio.DescrProvincia = CompradorDsd.Domicilio.DescrProvincia;
            CompradorHst.Domicilio.CodPost = CompradorDsd.Domicilio.CodPost;
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
        public static List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            return Lista(Cuenta, Sesion, true);
        }
        public static List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion, bool ConSeleccionarComprador)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            return comprador.Lista(Cuenta, ConSeleccionarComprador);
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
        public static List<CedWebEntidades.Comprador> ListaAdministracion(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Nombre, RazonSocial";
            }
            return comprador.ListaAdministracion(IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilasAdministracion(CedEntidades.Sesion Sesion)
        {
            CedWebDB.Comprador comprador = new CedWebDB.Comprador(Sesion);
            return comprador.CantidadDeFilasAdministracion();
        }
    }
}