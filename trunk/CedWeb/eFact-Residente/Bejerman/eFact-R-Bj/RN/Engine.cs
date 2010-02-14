using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FileHelpers;
using FileHelpers.RunTime;
using System.IO;

namespace eFact_R.RN
{
    public class Engine
    {
        private MultiRecordEngine engine;
        
        public void LeerMultiRegistro(out FeaEntidades.InterFacturas.lote_comprobantes Lc, string Archivo)
        {
            try
            {
                Type[] types = new Type[8];
                types[0] = typeof(FeaEntidades.InterFacturas.cabecera_lote);
                types[1] = typeof(FeaEntidades.InterFacturas.informacion_comprador);
                types[2] = typeof(FeaEntidades.InterFacturas.informacion_comprobante);
                types[3] = typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias);
                types[4] = typeof(FeaEntidades.InterFacturas.informacion_vendedor);
                types[5] = typeof(FeaEntidades.InterFacturas.detalle);
                types[6] = typeof(FeaEntidades.InterFacturas.linea);
                types[7] = typeof(FeaEntidades.InterFacturas.resumen);

                engine = new MultiRecordEngine(types[0], types[1], types[2], types[3], types[4], types[5], types[6], types[7]);
                engine.RecordSelector = new FileHelpers.RecordTypeSelector(cs);
                object[] oC = engine.ReadFile(Archivo);

                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                int NroComprobante = 0;
                int NroReferencias = 0;
                int NroLinea = 0;
                foreach (Object o in oC)
                {

                    if (typeof(FeaEntidades.InterFacturas.cabecera_lote) == o.GetType())
                    {
                        lc.cabecera_lote = (FeaEntidades.InterFacturas.cabecera_lote)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprador) == o.GetType())
                    {
                        lc.comprobante[NroComprobante] = new FeaEntidades.InterFacturas.comprobante();
                        lc.comprobante[NroComprobante].cabecera = new FeaEntidades.InterFacturas.cabecera();
                        lc.comprobante[NroComprobante].cabecera.informacion_comprador = (FeaEntidades.InterFacturas.informacion_comprador)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprobante) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante = (FeaEntidades.InterFacturas.informacion_comprobante)o;
                    }
                    if (typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].cabecera.informacion_comprobante.referencias[NroReferencias] = (FeaEntidades.InterFacturas.informacion_comprobanteReferencias)o;
                        ++NroReferencias;
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
                        lc.comprobante[NroComprobante].detalle.linea[NroLinea] = (FeaEntidades.InterFacturas.linea)o;
                        ++NroLinea;
                    }

                    if (typeof(FeaEntidades.InterFacturas.resumen) == o.GetType())
                    {
                        lc.comprobante[NroComprobante].resumen = (FeaEntidades.InterFacturas.resumen)o;
                        ++NroComprobante;
                        NroReferencias = 0;
                        NroLinea = 0;
                    }
                }
                Lc = lc;
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Engine.BaseApplicationException("Problemas al procesar el archivo.\r\n\r\n" + ex.Message);
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
