using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eFact_RN
{
    public class Archivo
    {
        public static void Consultar(out List<eFact_Entidades.Archivo> Archivos, eFact_Entidades.Archivo.TipoConsultaArchivos TipoConsultaArchivos, eFact_Entidades.Archivo.OtrosFiltros OtrosFiltros, DateTime FechaDsd, DateTime FechaHst, CedEntidades.Sesion Sesion)
        {
            List<eFact_Entidades.Archivo> archivos = new List<eFact_Entidades.Archivo>();
            eFact_DB.Archivo a = new eFact_DB.Archivo(Sesion);
            a.Consultar(archivos, TipoConsultaArchivos, OtrosFiltros, FechaDsd, FechaHst);
            Archivos = archivos;
        }
        public static void Leer(eFact_Entidades.Archivo Archivo, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Archivo db = new eFact_DB.Archivo(Sesion);
            db.Leer(Archivo);
        }
        public static string Insertar(eFact_Entidades.Archivo Archivo, bool Handler, CedEntidades.Sesion Sesion)
        {
            eFact_DB.Archivo db = new eFact_DB.Archivo(Sesion);
            return db.Insertar(Archivo, Handler);
        }
        public static void ActualizarBandejaEntrada(eFact_Entidades.Archivo Archivo, FileInfo ArchFileInfo, CedEntidades.Sesion Sesion)
        {
            Archivo.Nombre = ArchFileInfo.Name;
            Archivo.Path = ArchFileInfo.DirectoryName;
            Archivo.Tipo = ArchFileInfo.Extension;
            Archivo.FechaCreacion = ArchFileInfo.CreationTime;
            Archivo.FechaModificacion = ArchFileInfo.LastWriteTime;
            Archivo.Tamaño = ArchFileInfo.Length;
            Archivo.TamañoUMedida = "KB";
            Archivo.IdUsuario = Sesion.Usuario.IdUsuario;
            //archivo.FechaProcesado
            //archivo.IdLote
            //archivo.Comentario
        }
        public static void Procesar(out eFact_Entidades.Lote Lote, eFact_Entidades.Archivo Archivo, eFact_Entidades.Aplicacion Aplicacion, CedEntidades.Sesion Sesion)
        {
            //Antes de procesar el archivo grabamos los datos básicos del mismo.
            if (Archivo.Tipo.ToUpper() != ".TXT" && Archivo.Tipo.ToUpper() != ".XML")
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.TipoDeArchivoIncorrecto("Solo se aceptan archivo TXT o XML.");
            }
            FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            System.IO.MemoryStream ms;
            System.Xml.Serialization.XmlSerializer x;
            switch (Aplicacion.CodigoAplic.ToString())
            {
                case "eFactInterface":
                    {
                        if (Archivo.Tipo.ToUpper() == ".XML")
                        {
                            StreamReader objReader = new StreamReader(Archivo.Path + "\\" + Archivo.Nombre, Encoding.GetEncoding("iso-8859-1"));
                            string cadena;
                            cadena = objReader.ReadToEnd();
                            objReader.Close();
                            byte[] a = new byte[cadena.Length];// esta es la declaracion de tu arreglo
                            System.Text.Encoding codificador;
                            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                            a = codificador.GetBytes(cadena);
                            ms = new System.IO.MemoryStream(a);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                            x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
                            Lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                        }
                        else if (Archivo.Tipo.ToUpper() == ".TXT")
                        {
                            eFact_RN.Engine Engine = new eFact_RN.Engine();
                            Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                            Engine.LeerMultiRegistro(out Lc, Archivo.Path + "\\" + Archivo.Nombre);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (Lc.cabecera_lote.cuit_vendedor.ToString().Trim() != Aplicacion.OtrosFiltrosCuit.Trim() && Aplicacion.OtrosFiltrosCuit.Trim() != "")
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.CUITNoHabilitadoParaElUsuario(Lc.cabecera_lote.cuit_vendedor.ToString());
            }
            eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
            lote.CuitVendedor = Lc.cabecera_lote.cuit_vendedor.ToString();
            lote.PuntoVenta = Lc.cabecera_lote.punto_de_venta.ToString();
            lote.NumeroLote = Lc.cabecera_lote.id_lote.ToString();
            lote.CantidadRegistros = Convert.ToInt32(Lc.cabecera_lote.cantidad_reg.ToString());
            //Verificar bandeja de salida.
            int numeroEnvioDisponible = 0;
            eFact_RN.Lote.ObtenerNumeroEnvioDisponible(out numeroEnvioDisponible, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, Sesion);
            
            string loteXml = "";
            eFact_RN.Lote.SerializarLc(out loteXml, Lc);
            lote.NumeroEnvio = numeroEnvioDisponible;
            lote.NombreArch = Archivo.Nombre;
            lote.LoteXml = loteXml;
            for (int i = 0; i < Lc.cabecera_lote.cantidad_reg; i++)
            {
                eFact_Entidades.Comprobante c = new eFact_Entidades.Comprobante();
                c.IdTipoComprobante = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString());
                c.NumeroComprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString();
                c.TipoDocComprador = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString());
                c.NroDocComprador = Lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                c.NombreComprador = Lc.comprobante[i].cabecera.informacion_comprador.denominacion;
                c.Fecha = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision.ToString());
                c.NumeroCAE = Convert.ToString(Lc.comprobante[i].cabecera.informacion_comprobante.cae);
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae != null && Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString() != "")
                {
                    c.FechaCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString());
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae != null && Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString() != "")
                {
                    c.FechaVtoCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString());
                }
                c.IdMoneda = Convert.ToString(Lc.comprobante[i].resumen.codigo_moneda);
                c.Importe = Convert.ToDecimal(Lc.comprobante[i].resumen.importe_total_factura);
                if (Lc.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    c.ImporteMonedaOrigen = Convert.ToDecimal(Lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura);
                }
                c.TipoCambio = Convert.ToDecimal(Lc.comprobante[i].resumen.tipo_de_cambio);
                lote.Comprobantes.Add(c);
            }
            Lote = lote;
        }
        private static DateTime ConvertirStringToDateTime(String sFecha)
        {
            return Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
        }
    }
}
