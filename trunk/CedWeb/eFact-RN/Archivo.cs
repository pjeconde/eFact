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
            if (Archivo.Tipo.ToUpper() != ".TXT" && Archivo.Tipo.ToUpper() != ".XML" && Archivo.Tipo.ToUpper() != ".REC")
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
                            //StreamReader objReader = new StreamReader(Archivo.Path + "\\" + Archivo.Nombre, Encoding.GetEncoding("iso-8859-1"));
                            StreamReader objReader = new StreamReader(Archivo.Path + "\\" + Archivo.Nombre, Encoding.GetEncoding("utf-8"));
                            string cadena;
                            cadena = objReader.ReadToEnd();
                            objReader.Close();
                            byte[] a = new byte[cadena.Length];// esta es la declaracion de tu arreglo
                            System.Text.Encoding codificador;
                            //codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                            codificador = System.Text.Encoding.GetEncoding("utf-8");
                            cadena = cadena.Replace("&", "&amp;");
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
                            Engine.LeerMultiRegistro(out Lc, Archivo.Path + "\\" + Archivo.Nombre, Sesion);
                        }
                        else if (Archivo.Tipo.ToUpper() == ".REC")
                        {
                            eFact_RN.Engine Engine = new eFact_RN.Engine();
                            Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                            Engine.LeerRegistroRECE(out Lc, Archivo.Path + "\\" + Archivo.Nombre, Sesion);
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
            //Verificar bandeja de salida.-----------
            int numeroEnvioDisponible = 0;
            eFact_RN.Lote.ObtenerNumeroEnvioDisponible(out numeroEnvioDisponible, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, Sesion);
            lote.NumeroEnvio = numeroEnvioDisponible;
            //---------------------------------------
            lote.NombreArch = Archivo.Nombre;
            if (Lc.cabecera_lote.IdNaturalezaLoteFieldSpecified)
            {
                lote.IdNaturalezaLote = Lc.cabecera_lote.IdNaturalezaLoteField;
            }
            else
            {
                lote.IdNaturalezaLote = "";
            }
            int cantComprobantes = 0;
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                if (Lc.comprobante[i] != null)
                {
                    cantComprobantes += 1;
                }
                else
                {
                    break;
                }
            }
            if (Lc.comprobanteDespacho != null)
            {
                for (int i = 0; i < Lc.comprobanteDespacho.Length; i++)
                {
                    if (Lc.comprobanteDespacho[i] != null)
                    {
                        cantComprobantes += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (Lc.cabecera_lote.cantidad_reg != cantComprobantes)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo("Problemas con la cantidad de registros declarada.");
            }
            List<eFact_Entidades.ComprobanteC> cCListVigentes = new List<eFact_Entidades.ComprobanteC>();
            List<eFact_Entidades.ComprobanteD> cDListVigentes = new List<eFact_Entidades.ComprobanteD>();
            if (Lc.cabecera_lote.IdNaturalezaLoteField != null && Lc.cabecera_lote.IdNaturalezaLoteField == "Compra")
            {
                //----- Consultar comprobantes de compras 'Vigentes' -----.
                if (Lc.comprobante[0] != null)
                {
                    cCListVigentes = eFact_RN.Comprobante.ConsultarComprobantesCVigentes(Lc.cabecera_lote.cuit_vendedor.ToString(), Sesion);
                }    
                //----- Consultar despachos 'Vigentes' -----.
                if (Lc.comprobanteDespacho[0] != null)
                {
                    cDListVigentes = eFact_RN.Comprobante.ConsultarComprobantesDVigentes(Lc.cabecera_lote.cuit_vendedor.ToString(), Sesion);
                }
            }
            List<eFact_Entidades.Comprobante> cVListVigentes = new List<eFact_Entidades.Comprobante>();
            if (Lc.cabecera_lote.IdNaturalezaLoteField != null && Lc.cabecera_lote.IdNaturalezaLoteField == "Venta")
            {
                //----- Consultar comprobantes de ventas 'Vigentes' -----.
                cVListVigentes = eFact_RN.Comprobante.ConsultarComprobantesVigentes(Lc.cabecera_lote.cuit_vendedor.ToString(), Sesion);
            }
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                if (Lc.comprobante[i] != null)
                {
                    if (lote.IdNaturalezaLote != "Compra")
                    {
                        //Ventas
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
                        if (Lc.comprobante[i].extensiones != null)
                        {
                            if (Lc.comprobante[i].extensiones.extensiones_camara_facturas != null)
                            {
                                if (Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion != null)
                                {
                                    Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion = Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion.Trim();
                                    if (Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion.Length != 0 && Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion.Length != 32)
                                    {
                                        Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion = Cedeira.SV.Fun.CreateMD5Hash(Lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion);
                                    }
                                }
                            }
                        }
                        lote.Comprobantes.Add(c);
                        if (lote.IdNaturalezaLote == "Venta")
                        {
                            List<eFact_Entidades.Comprobante> listAux = cVListVigentes.FindAll((delegate(eFact_Entidades.Comprobante e1) { return e1.NroDocComprador == c.NroDocComprador && e1.PuntoVenta.ToString() == c.PuntoVenta && e1.IdTipoComprobante == c.IdTipoComprobante && e1.NumeroComprobante == c.NumeroComprobante; }));
                            if (listAux.Count != 0)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo("Comprobante existente. Cuit Comprador: " + c.NroDocComprador + " Punto Venta: " + c.PuntoVenta + " Tipo: " + c.IdTipoComprobante.ToString() + " Nro: " + c.NumeroComprobante);
                            }
                        }
                    }
                    else
                    {
                        //Compras
                        eFact_Entidades.ComprobanteC cC = new eFact_Entidades.ComprobanteC();
                        cC.PuntoVenta = Lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta.ToString();
                        cC.IdTipoComprobante = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString());
                        cC.NumeroComprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString();
                        cC.TipoDocVendedor = Convert.ToInt16("80");
                        cC.NroDocVendedor = Lc.comprobante[i].cabecera.informacion_vendedor.cuit.ToString();
                        cC.NombreVendedor = Lc.comprobante[i].cabecera.informacion_vendedor.razon_social;
                        cC.Fecha = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision.ToString());
                        cC.IdMoneda = Convert.ToString(Lc.comprobante[i].resumen.codigo_moneda);
                        cC.Importe = Convert.ToDecimal(Lc.comprobante[i].resumen.importe_total_factura);
                        if (Lc.comprobante[i].resumen.importes_moneda_origen != null)
                        {
                            cC.ImporteMonedaOrigen = Convert.ToDecimal(Lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura);
                        }
                        cC.TipoCambio = Convert.ToDecimal(Lc.comprobante[i].resumen.tipo_de_cambio);
                        lote.ComprobantesC.Add(cC);

                        List<eFact_Entidades.ComprobanteC> listAux = cCListVigentes.FindAll((delegate(eFact_Entidades.ComprobanteC e1) { return e1.NroDocVendedor == cC.NroDocVendedor && e1.PuntoVenta.ToString() == cC.PuntoVenta && e1.IdTipoComprobante == cC.IdTipoComprobante && e1.NumeroComprobante == cC.NumeroComprobante; }));
                        if (listAux.Count != 0)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo("Comprobante existente. Cuit Vendedor: " + cC.NroDocVendedor + " Punto Venta: " + cC.PuntoVenta + " Tipo: " + cC.IdTipoComprobante.ToString() + " Nro: " + cC.NumeroComprobante);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (Lc.comprobanteDespacho != null)
            {
                for (int i = 0; i < Lc.comprobanteDespacho.Length; i++)
                {
                    if (Lc.comprobanteDespacho[i] != null)
                    {
                        eFact_Entidades.ComprobanteD cD = new eFact_Entidades.ComprobanteD();
                        cD.IdTipoComprobante = Convert.ToInt16(Lc.comprobanteDespacho[i].DespachoCabecera.TipoComprobante.ToString());
                        cD.NumeroDespacho = Lc.comprobanteDespacho[i].DespachoCabecera.NumeroDespacho.ToString();
                        cD.TipoDocVendedor = Convert.ToInt16(Lc.comprobanteDespacho[i].DespachoCabecera.TipoDocVendedor);
                        cD.NroDocVendedor = Lc.comprobanteDespacho[i].DespachoCabecera.NroDocVendedor.ToString();
                        cD.NombreVendedor = Lc.comprobanteDespacho[i].DespachoCabecera.NombreVendedor;
                        cD.Fecha = ConvertirStringToDateTime(Lc.comprobanteDespacho[i].DespachoCabecera.Fecha.ToString());
                        cD.IdMoneda = Convert.ToString(Lc.comprobanteDespacho[i].DespachoResumen.Moneda);
                        cD.Importe = Convert.ToDecimal(Lc.comprobanteDespacho[i].DespachoResumen.ImporteTotal);
                        //cD.ImporteMonedaOrigen = Convert.ToDecimal(Lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura);
                        cD.TipoCambio = Convert.ToDecimal(Lc.comprobanteDespacho[i].DespachoResumen.TipoCambio);
                        lote.ComprobantesD.Add(cD);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            string loteXml = "";
            eFact_RN.Lote.SerializarLc(out loteXml, Lc);
            lote.LoteXml = loteXml;
            Lote = lote;
        }
        public static DateTime ConvertirStringToDateTime(String sFecha)
        {
            return Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
        }
    }
}
