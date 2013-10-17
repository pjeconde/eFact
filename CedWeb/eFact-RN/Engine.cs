using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FileHelpers;
using FileHelpers.RunTime;
using System.IO;
using System.Reflection;

namespace eFact_RN
{
    public class Engine
    {
        private MultiRecordEngine engine;
        
        public void LeerMultiRegistro(out FeaEntidades.InterFacturas.lote_comprobantes Lc, string Archivo)
        {
            try
            {
                Type[] types = new Type[20];
                types[0] = typeof(FeaEntidades.InterFacturas.cabecera_lote);
                types[1] = typeof(FeaEntidades.InterFacturas.informacion_comprador);
                types[2] = typeof(FeaEntidades.InterFacturas.informacion_comprobante);
                types[3] = typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias);
                types[4] = typeof(FeaEntidades.InterFacturas.informacion_vendedor);
                types[5] = typeof(FeaEntidades.InterFacturas.detalle);
                types[6] = typeof(FeaEntidades.InterFacturas.linea);
                types[7] = typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen);
                types[8] = typeof(FeaEntidades.InterFacturas.lineaDescuentos);
                types[9] = typeof(FeaEntidades.InterFacturas.lineaInformacion_adicional);
                types[10] = typeof(FeaEntidades.InterFacturas.informacion_exportacion);
                types[11] = typeof(FeaEntidades.InterFacturas.permisos);
                types[12] = typeof(FeaEntidades.InterFacturas.extensiones);
                types[13] = typeof(FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas);
                types[14] = typeof(FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios);
                types[15] = typeof(FeaEntidades.InterFacturas.resumenDescuentos);
                types[16] = typeof(FeaEntidades.InterFacturas.resumenImpuestos);
                types[17] = typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
                types[18] = typeof(FeaEntidades.InterFacturas.resumen);
                types[19] = typeof(FeaEntidades.InterFacturas.informacion_adicional_comprobante);

                engine = new MultiRecordEngine(types[0], types[1], types[2], types[3], types[4], types[5], types[6], types[7], types[8], types[9], types[10], types[11], types[12], types[13], types[14], types[15], types[16], types[17], types[18], types[19]);
                engine.RecordSelector = new FileHelpers.RecordTypeSelector(cs);
                object[] oC = engine.ReadFile(Archivo);

                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                int NroComprobante = 0;
                int NroLineaReferencias = 0;
                int NroLineaPermisos = 0;
                int NroLineaDescuento = 0;
                int NroLineaDescuentos = 0;
                int NroLineaInfoAdicional = 0;
                int NroLineaInformacionAdicionalComprobante = 0;
                int NroLinea = -1;
                FeaEntidades.InterFacturas.resumenImportes_moneda_origen importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                List<FeaEntidades.InterFacturas.resumenImpuestos> resumenImpuestos = new List<FeaEntidades.InterFacturas.resumenImpuestos>();
                foreach (Object o in oC)
                {
                    if (typeof(FeaEntidades.InterFacturas.cabecera_lote) == o.GetType())
                    {
                        importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                        lc.cabecera_lote = (FeaEntidades.InterFacturas.cabecera_lote)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprador) == o.GetType())
                    {
                        lc.comprobante[NroComprobante] = new FeaEntidades.InterFacturas.comprobante();
                        lc.comprobante[NroComprobante].cabecera = new FeaEntidades.InterFacturas.cabecera();
                        lc.comprobante[NroComprobante].cabecera.informacion_comprador = (FeaEntidades.InterFacturas.informacion_comprador)o;
                        GetPropiedades(o);
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprobante) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante = (FeaEntidades.InterFacturas.informacion_comprobante)o;
                        GetPropiedades(o);
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante.referencias[NroLineaReferencias] = (FeaEntidades.InterFacturas.informacion_comprobanteReferencias)o;
                        ++NroLineaReferencias;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_adicional_comprobante) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante.informacion_adicional_comprobante[NroLineaInformacionAdicionalComprobante] = (FeaEntidades.InterFacturas.informacion_adicional_comprobante)o;
                        ++NroLineaInformacionAdicionalComprobante;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_vendedor) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_vendedor = (FeaEntidades.InterFacturas.informacion_vendedor)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.detalle) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle = (FeaEntidades.InterFacturas.detalle)o;
                        lc.comprobante[NroComprobante].detalle.comentarios = lc.comprobante[NroComprobante].detalle.comentarios.Replace("<br>", " &#x0D; ");
                    }
                    if (typeof(FeaEntidades.InterFacturas.linea) == o.GetType())
                    {
                        NroLinea = ((FeaEntidades.InterFacturas.linea)o).numeroLinea - 1;
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea] = (FeaEntidades.InterFacturas.linea)o;
                        GetPropiedades(o);
                        NroLineaDescuento = 0;
                        NroLineaInfoAdicional = 0;
                    }
                    if (typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea].importes_moneda_origen = (FeaEntidades.InterFacturas.lineaImportes_moneda_origen)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.lineaDescuentos) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea].lineaDescuentos[NroLineaDescuento] = (FeaEntidades.InterFacturas.lineaDescuentos)o;
                        ++NroLineaDescuento;
                    }
                    if (typeof(FeaEntidades.InterFacturas.lineaInformacion_adicional) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea].informacion_adicional[NroLineaInfoAdicional] = (FeaEntidades.InterFacturas.lineaInformacion_adicional)o;
                        ++NroLineaInfoAdicional;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_exportacion) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante.informacion_exportacion = (FeaEntidades.InterFacturas.informacion_exportacion)o;
                        if (lc.comprobante[NroComprobante].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo == "")
                        {
                            lc.comprobante[NroComprobante].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = null;
                        }
                    }
                    if (typeof(FeaEntidades.InterFacturas.permisos) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante.informacion_exportacion.permisos[NroLineaPermisos] = (FeaEntidades.InterFacturas.permisos)o;
                        ++NroLineaPermisos;
                    }
                    if (typeof(FeaEntidades.InterFacturas.extensiones) == o.GetType())
                    {
                        if (((FeaEntidades.InterFacturas.extensiones)o).extensiones_datos_comerciales != "")
                        {
                            lc.comprobante[NroComprobante].extensiones = new FeaEntidades.InterFacturas.extensiones();
                            lc.comprobante[NroComprobante].extensionesSpecified = true;
                            lc.comprobante[NroComprobante].extensiones = (FeaEntidades.InterFacturas.extensiones)o;
                            if (lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales != null && lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales != "")
                            {
                                if (lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales.Substring(0, 1) == "%")
                                {
                                    lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales = HexToString(lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales.ToString());
                                }
                            }
                            if (lc.comprobante[NroComprobante].extensiones.extensiones_datos_marketing != null && lc.comprobante[NroComprobante].extensiones.extensiones_datos_marketing != "")
                            {
                                if (lc.comprobante[NroComprobante].extensiones.extensiones_datos_marketing.Substring(0, 1) == "%")
                                {
                                    lc.comprobante[NroComprobante].extensiones.extensiones_datos_marketing = HexToString(lc.comprobante[NroComprobante].extensiones.extensiones_datos_marketing.ToString());
                                }
                            }
                        }
                    }
                    if (typeof(FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas) == o.GetType())
                    {
                        if (lc.comprobante[NroComprobante].extensiones == null)
                        {
                            lc.comprobante[NroComprobante].extensiones = new FeaEntidades.InterFacturas.extensiones();
                            lc.comprobante[NroComprobante].extensionesSpecified = true;
                        }
                        lc.comprobante[NroComprobante].extensiones.extensiones_camara_facturas = (FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas)o;
                        lc.comprobante[NroComprobante].extensiones.extensiones_camara_facturasSpecified = true;
                        GetPropiedades(o);
                    }
                    if (typeof(FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios) == o.GetType())
                    {
                        if (((FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios)o).email != "")
                        {
                            lc.comprobante[NroComprobante].extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                            lc.comprobante[NroComprobante].extensiones.extensiones_destinatarios = (FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios)o;
                        }
                    }
                    if (typeof(FeaEntidades.InterFacturas.resumenDescuentos) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].resumen = new FeaEntidades.InterFacturas.resumen();
                        lc.comprobante[NroComprobante].resumen.descuentos[NroLineaDescuentos] = new FeaEntidades.InterFacturas.resumenDescuentos();
                        lc.comprobante[NroComprobante].resumen.descuentos[NroLineaDescuentos] = (FeaEntidades.InterFacturas.resumenDescuentos)o;
                        ++NroLineaDescuentos;
                    }
                    if (typeof(FeaEntidades.InterFacturas.resumenImpuestos) == o.GetType())
                    {
                        FeaEntidades.InterFacturas.resumenImpuestos resumenImpuesto = new FeaEntidades.InterFacturas.resumenImpuestos();
                        resumenImpuesto = (FeaEntidades.InterFacturas.resumenImpuestos)o;
                        resumenImpuestos.Add(resumenImpuesto);
                    }
                    if (typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen) == o.GetType())
                    {
                        importes_moneda_origen = (FeaEntidades.InterFacturas.resumenImportes_moneda_origen)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.resumen) == o.GetType())
                    {
                        Object oDescuentosAux = null;
                        if (lc.comprobante[NroComprobante].resumen != null && lc.comprobante[NroComprobante].resumen.descuentos != null)
                        {
                            oDescuentosAux = (Object)lc.comprobante[NroComprobante].resumen.descuentos;
                        }
                        lc.comprobante[NroComprobante].resumen = (FeaEntidades.InterFacturas.resumen)o;
                        if (oDescuentosAux != null)
                        {
                            lc.comprobante[NroComprobante].resumen.descuentos = (FeaEntidades.InterFacturas.resumenDescuentos[])oDescuentosAux;
                        }
                        if (importes_moneda_origen != null)
                        {
                            lc.comprobante[NroComprobante].resumen.importes_moneda_origen = importes_moneda_origen;
                        }
                        if (resumenImpuestos != null)
                        {
                            lc.comprobante[NroComprobante].resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[resumenImpuestos.Count];
                            for (int ri = 0; ri < lc.comprobante[NroComprobante].resumen.impuestos.Length; ri++)
                            {
                                lc.comprobante[NroComprobante].resumen.impuestos[ri] = resumenImpuestos[ri];
                            }
                        }
                        resumenImpuestos = new List<FeaEntidades.InterFacturas.resumenImpuestos>();
                        ++NroComprobante;
                        NroLineaReferencias = 0;
                        NroLineaPermisos = 0;
                        NroLineaDescuento = 0;
                        NroLineaDescuentos = 0;
                        NroLineaInfoAdicional = 0;
                        NroLineaInformacionAdicionalComprobante = 0;
                    }
                }
                Lc = lc;
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.BaseApplicationException("Problemas al procesar el archivo.\r\n\r\n" + ex.Message);
            }
        }
        public string ConvertToHex(string asciiString)
        {
            byte[] b = Encoding.ASCII.GetBytes(asciiString);
            string salida = "";
            for (int i = 0; i < b.Length; i++)
            {
                string ascii = b[i].ToString();
                int n = Convert.ToInt32(ascii);
                string r = n.ToString("x");
                salida += "%" + r;
            }
            return salida;
        }
        public string HexToString(string Hex)
        {
            byte[] Bytes;
            int ByteLength;
            string HexValue = "\x0\x1\x2\x3\x4\x5\x6\x7\x8\x9|||||||\xA\xB\xC\xD\xE\xF";
            Hex = Hex.Replace("%", ""); 
            ByteLength = Hex.Length / 2;
            Bytes = new byte[ByteLength];
            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4);
                Bytes[x] |= (byte)(HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(Bytes);
            return str;
        }
        private void GetPropiedades(object o)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (MemberInfo mi in o.GetType().GetMembers())
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    PropertyInfo pi = mi as PropertyInfo;
                    if (pi != null)
                    {
                        if (pi.PropertyType == typeof(System.String) && pi.GetValue(o, null).ToString() == "")
                        {
                            try
                            {
                                pi.SetValue(o, null, null);
                            }
                            //
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
        private Type cs(MultiRecordEngine engine, string record)
        {
            switch (record.Split(Convert.ToChar("|"))[0].ToString().Trim())
            {
                case "<cabecera_lote>":
                    {
                        return typeof(FeaEntidades.InterFacturas.cabecera_lote);
                    }
                case "<informacion_comprador>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_comprador);
                    }
                case "<informacion_comprobante>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_comprobante);
                    }
                case "<informacion_comprobanteReferencias>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias);
                    }
                case "<informacion_vendedor>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_vendedor);
                    }
                case "<detalle>":
                    {
                        return typeof(FeaEntidades.InterFacturas.detalle);
                    }
                case "<linea>":
                    {
                        return typeof(FeaEntidades.InterFacturas.linea);
                    }
                case "<lineaImportes_moneda_origen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen);
                    }
                case "<lineaDescuentos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.lineaDescuentos);
                    }
                 case "<lineaInformacion_adicional>":
                    {
                        return typeof(FeaEntidades.InterFacturas.lineaInformacion_adicional);
                    }
                case "<informacion_exportacion>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_exportacion);
                    }
                case "<extensiones>":
                    {
                        return typeof(FeaEntidades.InterFacturas.extensiones);
                    }
                case "<extensionesExtensiones_camara_facturas>":
                    {
                        return typeof(FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas);
                    }
                case "<extensionesExtensiones_destinatarios>":
                    {
                        return typeof(FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios);
                    }
                case "<permisos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.permisos);
                    }
                case "<resumenDescuentos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenDescuentos);
                    }
                case "<resumenImpuestos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenImpuestos);
                    }
                case "<resumenImportes_moneda_origen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
                    }
                case "<resumen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumen);
                    }
                case "<informacion_adicional_comprobante>":
                    {
                        return typeof(FeaEntidades.InterFacturas.informacion_adicional_comprobante);
                    }
                default:
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.EntidadInexistente();
                    }
            }
        }
        public static void GenerarNombreArch(out string NombreArch, string Prefijo, string Nombre)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(Prefijo);
            if (Prefijo != "")
            {
                sb.Append("-");
            }
            sb.Append(DateTime.Now.ToString("yyyyMMdd-hhmmss"));
            sb.Append("-");
            sb.Append(Nombre);
            NombreArch = sb.ToString();
        }

        public static void LeerRegistroRECE(out FeaEntidades.InterFacturas.lote_comprobantes Lc, string Archivo, CedEntidades.Sesion Sesion)
        {
            //Leer archivo RECE
            FixedFileEngine engine = new FixedFileEngine(typeof(FeaEntidades.RECE.ComprobanteRECE));
            FeaEntidades.RECE.ComprobanteRECE[] res = (FeaEntidades.RECE.ComprobanteRECE[])engine.ReadFile(Archivo);

            if (res.Length < 2)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.ProblemaProcesoArchRECE("\r\nEl archivo debe contener como mínimo dos registros.");
            }
            //Leer ultimo registro de control
            FixedFileEngine engineCtrl = new FixedFileEngine(typeof(FeaEntidades.RECE.ComprobanteRECEctrl));
            //res[res.Length-1];
            string textocontrol = res[res.Length - 1].TipoRegistro;
            textocontrol += res[res.Length - 1].FechaComprobante;
            textocontrol += res[res.Length - 1].TipoComprobante;
            textocontrol += res[res.Length - 1].ControladorFiscal;
            textocontrol += res[res.Length - 1].PuntoVenta;
            textocontrol += res[res.Length - 1].NroComprobanteDsd;
            textocontrol += res[res.Length - 1].NroComprobanteHst;
            textocontrol += res[res.Length - 1].CantidadHojas;
            textocontrol += res[res.Length - 1].CodDocComprador;
            textocontrol += res[res.Length - 1].NroDocComprador;
            textocontrol += res[res.Length - 1].ApellidoNombreComprador;
            textocontrol += res[res.Length - 1].ImporteTotalOpe;
            textocontrol += res[res.Length - 1].ImporteNoGravado;
            textocontrol += res[res.Length - 1].ImporteNetoGravado;
            textocontrol += res[res.Length - 1].ImporteLiq;
            textocontrol += res[res.Length - 1].ImporteLiqRNI;
            textocontrol += res[res.Length - 1].ImporteOpeExentas;
            textocontrol += res[res.Length - 1].ImportePercepOImpNacionales;
            textocontrol += res[res.Length - 1].ImportePercepIB;
            textocontrol += res[res.Length - 1].ImportePercepImpMunicipales;
            textocontrol += res[res.Length - 1].ImporteImpInternos;
            textocontrol += res[res.Length - 1].FechaServicioDsd;
            textocontrol += res[res.Length - 1].FechaServicioHst;
            textocontrol += res[res.Length - 1].FechaVtoPago;
            textocontrol += res[res.Length - 1].Relleno;
            textocontrol += res[res.Length - 1].CantidadAlicIVA;
            textocontrol += res[res.Length - 1].CodOpe;
            textocontrol += res[res.Length - 1].CAE;
            textocontrol += res[res.Length - 1].FechaVtoCAE;
            textocontrol += res[res.Length - 1].FechaAnulComprobante;
            object o = engineCtrl.ReadString(textocontrol);
            FeaEntidades.RECE.ComprobanteRECEctrl[] resCtrl = (FeaEntidades.RECE.ComprobanteRECEctrl[])o;
            
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            Lc = lc;
            //Armado de cabecera
            lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lc.cabecera_lote.cantidad_reg = res.Length - 1;
            lc.cabecera_lote.cuit_canal = Convert.ToInt64(@System.Configuration.ConfigurationManager.AppSettings["CuitCanal"]);
            lc.cabecera_lote.cuit_vendedor = Convert.ToInt64(resCtrl[0].CuitInformante);
            lc.cabecera_lote.gestionar_afip = "S";
            lc.cabecera_lote.gestionar_afipSpecified = true;
            lc.cabecera_lote.punto_de_venta = Convert.ToInt32(res[0].PuntoVenta);
            lc.cabecera_lote.fecha_envio_lote = DateTime.Now.ToString("yyyyMMdd hhmmss");

            if (Convert.ToInt32(res.Length - 1) != Convert.ToInt32(resCtrl[0].CantidadRegTipo1))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.ProblemaProcesoArchRECE("\r\nLa cantidad de registros informada, no coincide con la contenidad en el archivo.");
            }
            eFact_Entidades.Vendedor vendedor = new eFact_Entidades.Vendedor();
            vendedor.CuitVendedor = lc.cabecera_lote.cuit_vendedor.ToString();
            eFact_RN.Vendedor.Leer(vendedor, Sesion);
            for (int i = 0; i < res.Length - 1; i++) 
            {
                List<FeaEntidades.InterFacturas.resumenImpuestos> resumenImpuestos = new List<FeaEntidades.InterFacturas.resumenImpuestos>();
                lc.comprobante[i] = new FeaEntidades.InterFacturas.comprobante();
                lc.comprobante[i].cabecera = new FeaEntidades.InterFacturas.cabecera();
                lc.comprobante[i].cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
                lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio = Convert.ToInt32(res[i].CodDocComprador);
                lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio = Convert.ToInt64(res[i].NroDocComprador);
                lc.comprobante[i].cabecera.informacion_comprador.denominacion = res[i].ApellidoNombreComprador;

                lc.comprobante[i].cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                lc.comprobante[i].cabecera.informacion_comprobante.codigo_concepto = 2;
                lc.comprobante[i].cabecera.informacion_comprobante.codigo_conceptoSpecified = true;
                lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision = res[i].FechaComprobante;
                lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde = res[i].FechaServicioDsd;
                lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta = res[i].FechaServicioHst;
                lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento = res[i].FechaVtoPago;
                lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(res[i].PuntoVenta);
                lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt64(res[i].NroComprobanteDsd);

                lc.comprobante[i].cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                lc.comprobante[i].cabecera.informacion_vendedor.cuit = Convert.ToInt64(vendedor.CuitVendedor);
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle = vendedor.DomicilioCalle;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto = vendedor.DomicilioDepto;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero = vendedor.DomicilioNumero;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso = vendedor.DomicilioPiso;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana = vendedor.DomicilioManzana;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector = vendedor.DomicilioSector;
                lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre = vendedor.DomicilioTorre;
                lc.comprobante[i].cabecera.informacion_vendedor.cp = vendedor.CP;
                lc.comprobante[i].cabecera.informacion_vendedor.email = vendedor.EMail;
                if (vendedor.InicioActividades.ToString("yyyyMMdd") != "99981231")
                {
                    lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades = vendedor.InicioActividades.ToString("yyyyMMdd");
                }
                lc.comprobante[i].cabecera.informacion_vendedor.localidad = vendedor.Localidad;
                lc.comprobante[i].cabecera.informacion_vendedor.provincia = vendedor.Provincia;
                lc.comprobante[i].cabecera.informacion_vendedor.razon_social = vendedor.Nombre;
                lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos = vendedor.CondicionIB;
                if (lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos != 0)
                {
                    lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = true;
                }
                lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos = vendedor.NroIB;
                lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVA = vendedor.CondicionIVA;
                if (lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVA != 0)
                {
                    lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified = true;
                }
                lc.comprobante[i].cabecera.informacion_vendedor.contacto = vendedor.Contacto;

                lc.comprobante[i].detalle = new FeaEntidades.InterFacturas.detalle();
                lc.comprobante[i].detalle.comentarios = "";

                lc.comprobante[i].resumen = new FeaEntidades.InterFacturas.resumen();
                lc.comprobante[i].resumen.cant_alicuotas_iva = Convert.ToInt32(res[i].CantidadAlicIVA);
                double valor = ConvertirStringToDouble(15, 2, res[i].ImporteTotalOpe);
                lc.comprobante[i].resumen.importe_total_factura = valor;
                valor = ConvertirStringToDouble(15, 2, res[i].ImporteImpInternos);
                if (valor != 0)
                {
                    lc.comprobante[i].resumen.importe_total_impuestos_internos = valor;
                    lc.comprobante[i].resumen.importe_total_impuestos_internosSpecified = true;
                }
                valor = ConvertirStringToDouble(15, 2, res[i].ImportePercepImpMunicipales);
                if (valor != 0)
                {
                    lc.comprobante[i].resumen.importe_total_impuestos_municipales = valor;
                    lc.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified = true;
                }
                valor = ConvertirStringToDouble(15, 2, res[i].ImportePercepOImpNacionales);
                if (valor != 0)
                {
                    lc.comprobante[i].resumen.importe_total_impuestos_nacionales = valor;
                    lc.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified = true;
                }
                valor = ConvertirStringToDouble(15, 2, res[i].ImportePercepIB);
                if (valor != 0)
                {
                    lc.comprobante[i].resumen.importe_total_ingresos_brutos = valor;
                    lc.comprobante[i].resumen.importe_total_ingresos_brutosSpecified = true;
                }
                lc.comprobante[i].resumen.impuesto_liq = ConvertirStringToDouble(15, 2, res[i].ImporteLiq);
                lc.comprobante[i].resumen.impuesto_liq_rni = ConvertirStringToDouble(15, 2, res[i].ImporteLiqRNI);
                lc.comprobante[i].resumen.importe_total_concepto_no_gravado = ConvertirStringToDouble(15, 2, res[i].ImporteNoGravado);
                lc.comprobante[i].resumen.importe_total_neto_gravado = ConvertirStringToDouble(15, 2, res[i].ImporteNetoGravado);
                lc.comprobante[i].resumen.importe_operaciones_exentas = ConvertirStringToDouble(15, 2, res[i].ImporteOpeExentas);
                lc.comprobante[i].resumen.codigo_moneda = "PES";
                lc.comprobante[i].resumen.tipo_de_cambio = 1;

                //Lineas
                FeaEntidades.InterFacturas.resumenImpuestos resumenImpuesto;
                int linea = 0;
                if (lc.comprobante[i].resumen.impuesto_liq != 0)
                {
                    lc.comprobante[i].detalle.linea[linea] = new FeaEntidades.InterFacturas.linea();
                    lc.comprobante[i].detalle.linea[linea].cantidad = 1;
                    lc.comprobante[i].detalle.linea[linea].unidad = "7";
                    lc.comprobante[i].detalle.linea[linea].descripcion = "";
                    lc.comprobante[i].detalle.linea[linea].codigo_producto_comprador = "";
                    lc.comprobante[i].detalle.linea[linea].codigo_producto_vendedor = "";
                    lc.comprobante[i].detalle.linea[linea].numeroLinea = linea + 1;
                    lc.comprobante[i].detalle.linea[linea].alicuota_iva = Math.Round((lc.comprobante[i].resumen.impuesto_liq * 100) / lc.comprobante[i].resumen.importe_total_neto_gravado, 2);
                    lc.comprobante[i].detalle.linea[linea].importe_iva = lc.comprobante[i].resumen.impuesto_liq;
                    lc.comprobante[i].detalle.linea[linea].precio_unitario = lc.comprobante[i].resumen.importe_total_neto_gravado;
                    lc.comprobante[i].detalle.linea[linea].importe_total_articulo = lc.comprobante[i].resumen.importe_total_neto_gravado;
                    lc.comprobante[i].detalle.linea[linea].indicacion_exento_gravado = "G";
                    resumenImpuesto = new FeaEntidades.InterFacturas.resumenImpuestos();
                    resumenImpuesto.codigo_impuesto = 1;
                    resumenImpuesto.base_imponible = lc.comprobante[i].resumen.importe_total_neto_gravado;
                    resumenImpuesto.descripcion = "IVA";
                    resumenImpuesto.porcentaje_impuesto = lc.comprobante[i].detalle.linea[linea].alicuota_iva;
                    resumenImpuesto.porcentaje_impuestoSpecified = true; 
                    resumenImpuestos.Add(resumenImpuesto);
                    linea += 1;
                }
                if (lc.comprobante[i].resumen.importe_total_concepto_no_gravado != 0)
                {
                    lc.comprobante[i].detalle.linea[linea] = new FeaEntidades.InterFacturas.linea();
                    lc.comprobante[i].detalle.linea[linea].cantidad = 1;
                    lc.comprobante[i].detalle.linea[linea].unidad = "7";
                    lc.comprobante[i].detalle.linea[linea].descripcion = "";
                    lc.comprobante[i].detalle.linea[linea].codigo_producto_comprador = "";
                    lc.comprobante[i].detalle.linea[linea].codigo_producto_vendedor = "";
                    lc.comprobante[i].detalle.linea[linea].numeroLinea = linea + 1;
                    lc.comprobante[i].detalle.linea[linea].alicuota_iva = 0;
                    lc.comprobante[i].detalle.linea[linea].importe_iva = 0;
                    lc.comprobante[i].detalle.linea[linea].precio_unitario = lc.comprobante[i].resumen.importe_total_concepto_no_gravado;
                    lc.comprobante[i].detalle.linea[linea].importe_total_articulo = lc.comprobante[i].resumen.importe_total_concepto_no_gravado;
                    lc.comprobante[i].detalle.linea[linea].indicacion_exento_gravado = "N";
                    linea += 1;
                }

                //CODIGOS DE IMPUESTO
                //COD         DESCRIPCION
                //1           IVA
                //2           Impuestos internos
                //3           Otros impuestos
                //4           Percepciones o pagos a cuenta de impuestos nacionales
                //5           Percepción de Ingresos Brutos
                //6           Percepción por Impuestos Municipales

                lc.comprobante[i].resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[resumenImpuestos.Count];
                for (int ri = 0; ri < lc.comprobante[i].resumen.impuestos.Length; ri++)
                {
                    lc.comprobante[i].resumen.impuestos[ri] = resumenImpuestos[ri];
                }

                //Controles
                if (lc.cabecera_lote.punto_de_venta != lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.ProblemaProcesoArchRECE("\r\nNo se puede procesar distintos puntos de venta en el mismo lote. Verificar linea: [" + Convert.ToInt32(i+1) + "]");
                }
            }
        }
        private static double ConvertirStringToDouble(int LongitudString, int LongitudDecimales, string Valor)
        {
            return Convert.ToDouble(Valor.Substring(0, LongitudString - LongitudDecimales) + "." + Valor.Substring(LongitudString - LongitudDecimales, LongitudDecimales));
        }
    }
}
