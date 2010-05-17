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
                Type[] types = new Type[14];
                types[0] = typeof(FeaEntidades.InterFacturas.cabecera_lote);
                types[1] = typeof(FeaEntidades.InterFacturas.informacion_comprador);
                types[2] = typeof(FeaEntidades.InterFacturas.informacion_comprobante);
                types[3] = typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias);
                types[4] = typeof(FeaEntidades.InterFacturas.informacion_vendedor);
                types[5] = typeof(FeaEntidades.InterFacturas.detalle);
                types[6] = typeof(FeaEntidades.InterFacturas.linea);
                types[7] = typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen);
                types[8] = typeof(FeaEntidades.InterFacturas.informacion_exportacion);
                types[9] = typeof(FeaEntidades.InterFacturas.permisos);
                types[10] = typeof(FeaEntidades.InterFacturas.extensiones);
                types[11] = typeof(FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas);
                types[12] = typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
                types[13] = typeof(FeaEntidades.InterFacturas.resumen);

                engine = new MultiRecordEngine(types[0], types[1], types[2], types[3], types[4], types[5], types[6], types[7], types[8], types[9], types[10], types[11], types[12], types[13]);
                engine.RecordSelector = new FileHelpers.RecordTypeSelector(cs);
                object[] oC = engine.ReadFile(Archivo);

                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                int NroComprobante = 0;
                int NroLineaReferencias = 0;
                int NroLineaPermisos = 0;
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
                    if (typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen) == o.GetType())
                    {
                        importes_moneda_origen = (FeaEntidades.InterFacturas.resumenImportes_moneda_origen)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.resumen) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].resumen = (FeaEntidades.InterFacturas.resumen)o;
                        if (importes_moneda_origen != null)
                        {
                            lc.comprobante[NroComprobante].resumen.importes_moneda_origen = importes_moneda_origen;
                        }
                        ++NroComprobante;
                        NroLineaReferencias = 0;
                        NroLineaPermisos = 0;
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
            string hex = "";
            foreach (char c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
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
                case "<permisos>":
                    {
                        return typeof(FeaEntidades.InterFacturas.permisos);
                    }
                case "<resumenImportes_moneda_origen>":
                    {
                        return typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen);
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
