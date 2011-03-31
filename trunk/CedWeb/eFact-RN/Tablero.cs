using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using FileHelpers;
using FileHelpers.RunTime;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eFact_RN
{
    public class Tablero
    {
        public static void ActualizarBandejaEntrada(out List<eFact_Entidades.Archivo> Archivos, List<eFact_Entidades.Archivo> ArchivosBandejaEntrada, FileInfo ArchFileInfo, CedEntidades.Sesion Sesion)
        {
            List<eFact_Entidades.Archivo> archivos = new List<eFact_Entidades.Archivo>();
            eFact_Entidades.Archivo archivo = new eFact_Entidades.Archivo();
            archivos.AddRange(ArchivosBandejaEntrada);
            eFact_RN.Archivo.ActualizarBandejaEntrada(archivo, ArchFileInfo, Sesion);
            archivos.Add(archivo);
            Archivos = archivos;
        }
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
        public static void ActualizarBandejaSalida(out List<eFact_Entidades.Lote> Lotes, eFact_Entidades.Lote.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, String CuitVendedor, String NumeroLote, String PuntoVenta, bool VerPendientes, CedEntidades.Sesion Sesion)
        {
            List<eFact_Entidades.Lote> lotes = new List<eFact_Entidades.Lote>();
            eFact_RN.Lote.Consultar(out lotes, TipoConsulta, FechaDsd, FechaHst, CuitVendedor, NumeroLote, PuntoVenta, VerPendientes, Sesion);
            Lotes = lotes;
        }
    }
}
