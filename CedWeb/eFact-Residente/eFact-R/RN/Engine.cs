using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FileHelpers;
using FileHelpers.RunTime;
using System.IO;
using System.Reflection;

namespace eFact_R.RN
{
    public class Engine
    {
        private MultiRecordEngine engine;
        
        public void LeerMultiRegistro(out FeaEntidades.InterFacturas.lote_comprobantes Lc, string Archivo)
        {
            try
            {
                Type[] types = new Type[18];
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
                types[16] = typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
                types[17] = typeof(FeaEntidades.InterFacturas.resumen);

                engine = new MultiRecordEngine(types[0], types[1], types[2], types[3], types[4], types[5], types[6], types[7], types[8], types[9], types[10], types[11], types[12], types[13], types[14], types[15], types[16], types[17]);
                engine.RecordSelector = new FileHelpers.RecordTypeSelector(cs);
                object[] oC = engine.ReadFile(Archivo);

                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                int NroComprobante = 0;
                int NroLineaReferencias = 0;
                int NroLineaPermisos = 0;
                int NroLineaDescuento = 0;
                int NroLineaDescuentos = 0;
                int NroLineaInfoAdicional = 0;
                int NroLinea = -1;
                FeaEntidades.InterFacturas.resumenImportes_moneda_origen importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
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
                    }
                    if (typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea].importes_moneda_origen = (FeaEntidades.InterFacturas.lineaImportes_moneda_origen)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.lineaDescuentos) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea].descuentos[NroLineaDescuento] = (FeaEntidades.InterFacturas.lineaDescuentos)o;
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
                            lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales.ToString();
                            string prueba = ConvertToHex(lc.comprobante[NroComprobante].extensiones.extensiones_datos_comerciales.ToString());
                            string pruebaResp = HexToString(prueba);
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
                        ++NroComprobante;
                        NroLineaReferencias = 0;
                        NroLineaPermisos = 0;
                        NroLineaDescuento = 0;
                        NroLineaDescuentos = 0;
                        NroLineaInfoAdicional = 0;
                    }
                }
                Lc = lc;
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.BaseApplicationException("Problemas al procesar el archivo.\r\n\r\n" + ex.Message);
            }
        }
        //public string ConvertToHex(string asciiString)
        //{
        //    string hex = "";
        //    foreach (char c in asciiString)
        //    {
        //        int tmp = c;
        //        hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        //    }
        //    return hex;
        //}
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
                            pi.SetValue(o, null, null);
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
                case "<resumenImportes_moneda_origen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
                    }
                case "<resumendescuentos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenDescuentos);
                    }
                case "<resumen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumen);
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
    }
}
