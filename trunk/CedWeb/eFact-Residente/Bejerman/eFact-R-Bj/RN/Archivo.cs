using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eFact_R.RN
{
    public class Archivo
    {
        public enum OtrosFiltros
        {
            /// <comentarios/>
            OK,
            /// <comentarios/>
            NotOk,
            /// <comentarios/>
            SinAplicar,
        }
        public static void Consultar(out List<eFact_R.Entidades.Archivo> Archivos, Tablero.TipoConsultaArchivos TipoConsultaArchivos, OtrosFiltros OtrosFiltros, DateTime FechaDsd, DateTime FechaHst, CedEntidades.Sesion Sesion)
        {
            List<eFact_R.Entidades.Archivo> archivos = new List<eFact_R.Entidades.Archivo>();
            eFact_R.DB.Archivo a = new eFact_R.DB.Archivo(Sesion);
            a.Consultar(archivos, TipoConsultaArchivos, OtrosFiltros, FechaDsd, FechaHst);
            Archivos = archivos;
        }
        public static void Leer(eFact_R.Entidades.Archivo Archivo, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Archivo db = new eFact_R.DB.Archivo(Sesion);
            db.Leer(Archivo);
        }
        public static string Insertar(eFact_R.Entidades.Archivo Archivo, bool Handler, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Archivo db = new eFact_R.DB.Archivo(Sesion);
            return db.Insertar(Archivo, Handler);
        }
        public static void ActualizarBandejaEntrada(eFact_R.Entidades.Archivo Archivo, FileInfo ArchFileInfo, CedEntidades.Sesion Sesion)
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
        public static void Procesar(out eFact_R.Entidades.Lote Lote, eFact_R.Entidades.Archivo Archivo, CedEntidades.Sesion Sesion)
        {
            //Antes de procesar el archivo grabamos los datos básicos del mismo.
            if (Archivo.Tipo.ToUpper() != ".TXT" && Archivo.Tipo.ToUpper() != ".XML")
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.TipoDeArchivoIncorrecto("Solo se aceptan archivo TXT o XML.");
            }
            FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            System.IO.MemoryStream ms;
            System.Xml.Serialization.XmlSerializer x;
            switch (eFact_R.Aplicacion.CodigoAplic.ToString())
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
                            eFact_R.RN.Engine Engine = new eFact_R.RN.Engine();
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
            if (Lc.cabecera_lote.cuit_vendedor.ToString().Trim() != eFact_R.Aplicacion.OtrosFiltrosCuit.Trim() && eFact_R.Aplicacion.OtrosFiltrosCuit.Trim() != "")
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.CUITNoHabilitadoParaElUsuario(Lc.cabecera_lote.cuit_vendedor.ToString());
            }
            eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
            lote.CuitVendedor = Lc.cabecera_lote.cuit_vendedor.ToString();
            lote.PuntoVenta = Lc.cabecera_lote.punto_de_venta.ToString();
            lote.NumeroLote = Lc.cabecera_lote.id_lote.ToString();
            lote.CantidadRegistros = Convert.ToInt32(Lc.cabecera_lote.cantidad_reg.ToString());
            //Verificar bandeja de salida.
            int numeroEnvioDisponible = 0;
            eFact_R.RN.Lote.ObtenerNumeroEnvioDisponible(out numeroEnvioDisponible, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, eFact_R.Aplicacion.Sesion);
            //Verificar bandeja de entrada.
            //List<eFact_R_Bj.Entidades.Archivo> la = new List<eFact_R_Bj.Entidades.Archivo>();
            //la = archivos.FindAll((delegate(eFact_R_Bj.Entidades.Archivo e) { return e.Lote.CuitVendedor == lote.CuitVendedor && e.Lote.PuntoVenta == lote.PuntoVenta && e.Lote.NumeroLote == lote.NumeroLote; }));
            //if (la.Count != 0)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Lote.Existente("Encontrado en la bandeja de entrada. Nombre del archivo: " + Archivo.Nombre);
            //}
            string loteXml = "";
            eFact_R.RN.Lote.SerializarLc(out loteXml, Lc);
            lote.NumeroEnvio = numeroEnvioDisponible;
            lote.NombreArch = Archivo.Nombre;
            lote.LoteXml = loteXml;
            for (int i = 0; i < Lc.cabecera_lote.cantidad_reg; i++)
            {
                eFact_R.Entidades.Comprobante c = new eFact_R.Entidades.Comprobante();
                c.IdTipoComprobante = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString());
                c.NumeroComprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString();
                c.TipoDocComprador = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString());
                c.NroDocComprador = Lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                c.NombreComprador = Lc.comprobante[i].cabecera.informacion_comprador.denominacion.ToString();
                c.Fecha = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision.ToString());
                c.NumeroCAE = Convert.ToString(Lc.comprobante[i].cabecera.informacion_comprobante.cae);
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString() != "")
                {
                    c.FechaCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString());
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString() != "")
                {
                    c.FechaVtoCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString());
                }
                c.IdMoneda = Convert.ToString(Lc.comprobante[i].resumen.codigo_moneda);
                c.Importe = Convert.ToDecimal(Lc.comprobante[i].resumen.importe_total_factura);
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
