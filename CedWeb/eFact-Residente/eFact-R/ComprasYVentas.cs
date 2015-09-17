using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Ionic.Zip;

namespace eFact_R
{
    public partial class ComprasYVentas : Form
    {
        private eFact_Entidades.Vendedor vendedor = new eFact_Entidades.Vendedor();
        public ComprasYVentas()
        {
            InitializeComponent();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                GenerarButton.Enabled = false;
                List<eFact_Entidades.Vendedor> vendedores = new List<eFact_Entidades.Vendedor>();
                eFact_RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
                CuitVendedorComboBox.Items.Clear();
                CuitVendedorComboBox.Items.Add("( Elegir un Vendedor )");
                if (vendedores.Count > 0)
                {
                    foreach(eFact_Entidades.Vendedor v in vendedores)
                    {
                        CuitVendedorComboBox.Items.Add(v.CuitVendedor);
                    }
                }
                CuitVendedorComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        private void CuitVendedorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vendedor = new eFact_Entidades.Vendedor();
            GenerarButton.Enabled = false;
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                string CuitVendedor = ((ComboBox)sender).SelectedItem.ToString().Trim();
                vendedor.CuitVendedor = CuitVendedor;
                eFact_RN.Vendedor.Leer(vendedor, Aplicacion.Sesion);
                GenerarButton.Enabled = true;
            }
        }

        private void GenerarButton_Click(object sender, EventArgs e)
        {
            List<eFact_Entidades.Lote> loteComprobantes = new List<eFact_Entidades.Lote>();
            List<eFact_Entidades.Lote> loteComprobantesC = new List<eFact_Entidades.Lote>();
            List<eFact_Entidades.Lote> loteComprobantesD = new List<eFact_Entidades.Lote>();
            if (VentasRadioButton.Checked)
            {
                loteComprobantes = eFact_RN.Lote.ConsultarLotesDeComprobantesVigentesXFecha(FechaDsdDTP.Value.ToString("yyyyMMdd"), FechaHstDTP.Value.ToString("yyyyMMdd"), CuitVendedorComboBox.SelectedItem.ToString(), Aplicacion.Sesion);
            }
            else
            {
                loteComprobantesC = eFact_RN.Lote.ConsultarLotesDeComprobantesCVigentesXFecha(FechaDsdDTP.Value.ToString("yyyyMMdd"), FechaHstDTP.Value.ToString("yyyyMMdd"), CuitVendedorComboBox.SelectedItem.ToString(), Aplicacion.Sesion);
                loteComprobantesD = eFact_RN.Lote.ConsultarLotesDeComprobantesDVigentesXFecha(FechaDsdDTP.Value.ToString("yyyyMMdd"), FechaHstDTP.Value.ToString("yyyyMMdd"), CuitVendedorComboBox.SelectedItem.ToString(), Aplicacion.Sesion);
            }

            if (loteComprobantes.Count != 0 || loteComprobantesC.Count != 0 || loteComprobantesD.Count != 0)
            {
                System.Xml.Serialization.XmlSerializer x;
                byte[] bytes;
                System.IO.MemoryStream ms;
                string script;
                FeaEntidades.InterFacturas.lote_comprobantes lote;
                bool HayVentas = false;
                bool HayVentasAlic = false;
                bool HayCompras = false;
                bool HayComprasAlic = false;
                bool HayComprasImpAlic = false;

                //Crear nombre de archivo default sin extensión
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(CuitVendedorComboBox.SelectedItem.ToString());
                sb.Append("-");
                sb.Append(DateTime.Now.ToString("yyyyMMdd"));

                //Crear nombre de archivo ZIP
                System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                sbZIP.Append(sb.ToString() + ".zip");

                //Crear archivo VENTAS CABECERA
                System.Text.StringBuilder sbVENTASCab = new System.Text.StringBuilder();
                sbVENTASCab.Append("REGINFO_CV_VENTAS_CBTE.TXT");    //sb.ToString() + "-CABECERA_EMISOR.txt");
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.IO.FileStream fs = new System.IO.FileStream(Path.GetTempPath() + sbVENTASCab.ToString(), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo VENTAS ALICUOTAS
                System.Text.StringBuilder sbVENTASAlic = new System.Text.StringBuilder();
                sbVENTASAlic.Append("REGINFO_CV_VENTAS_ALICUOTAS.TXT");     //sb.ToString() + "-DETALLE.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Path.GetTempPath() + sbVENTASAlic.ToString(), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo COMPRAS CABECERA
                System.Text.StringBuilder sbCOMPRASCab = new System.Text.StringBuilder();
                sbCOMPRASCab.Append("REGINFO_CV_COMPRAS_CBTE.TXT");    //sb.ToString() + "-CABECERA_EMISOR.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Path.GetTempPath() + sbCOMPRASCab.ToString(), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo COMPRAS ALICUOTAS
                System.Text.StringBuilder sbCOMPRASAlic = new System.Text.StringBuilder();
                sbCOMPRASAlic.Append("REGINFO_CV_COMPRAS_ALICUOTAS.TXT");     //sb.ToString() + "-DETALLE.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Path.GetTempPath() + sbCOMPRASAlic.ToString(), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Crear archivo COMPRAS ALICUOTAS IMPORTACIONES
                System.Text.StringBuilder sbCOMPRASImpAlic = new System.Text.StringBuilder();
                sbCOMPRASImpAlic.Append("REGINFO_CV_COMPRAS_IMPORTACIONES.TXT");     //sb.ToString() + "-DETALLE.txt");
                m = new System.IO.MemoryStream();
                fs = new System.IO.FileStream(Path.GetTempPath() + sbCOMPRASImpAlic.ToString(), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                double TotalGral = 0; double TotalNetoGravado = 0; double TotalNetoNoGravado = 0;
                double TotalImporteExento = 0; double TotalIB = 0; double TotalIM = 0;
                double TotalII = 0; double TotalOtros = 0;

                double TotalIVA270 = 0; double TotalIVA210 = 0; double TotalIVA105 = 0;
                double TotalIVA050 = 0; double TotalIVA025 = 0;

                int CantComprobantes = 0;

                #region Ventas
                if (VentasRadioButton.Checked)
                {
                    if (loteComprobantes.Count > 0)
                    {
                        foreach (eFact_Entidades.Lote loteAProcesar in loteComprobantes)
                        {
                            HayVentas = true;
                            lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                            x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                            try
                            {
                                loteAProcesar.LoteXml = loteAProcesar.LoteXml.Replace("iso-8859-1", "utf-16");
                                bytes = new byte[loteAProcesar.LoteXml.Length * sizeof(char)];
                                System.Buffer.BlockCopy(loteAProcesar.LoteXml.ToCharArray(), 0, bytes, 0, bytes.Length);
                                ms = new System.IO.MemoryStream(bytes);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);
                                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                                //Procesar todos los comprobantes del lote.
                                for (int cl = 0; cl < lote.comprobante.Length; cl++)
                                {
                                    #region "Armar Interfaz Ventas"
                                    if (Convert.ToInt32(lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision) >= Convert.ToInt32(FechaDsdDTP.Value.ToString("yyyyMMdd")) && Convert.ToInt32(lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision) <= Convert.ToInt32(FechaHstDTP.Value.ToString("yyyyMMdd")))
                                    {
                                        CantComprobantes += 1;
                                        //Guardar info en archivo VENTAS CABECERA
                                        System.Text.StringBuilder sbDataVENTASCab = new System.Text.StringBuilder();
                                        //string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                                        string Campo1 = lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision;
                                        string Campo2 = lote.comprobante[cl].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                        string Campo3 = lote.comprobante[cl].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                        string Campo4 = lote.comprobante[cl].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo5 = lote.comprobante[cl].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo6 = lote.comprobante[cl].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString("00");
                                        string Campo7 = lote.comprobante[cl].cabecera.informacion_comprador.nro_doc_identificatorio.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo8 = Truncate(String.Format("{0,-30}", lote.comprobante[cl].cabecera.informacion_comprador.denominacion), 30);

                                        string Campo9 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalGral += lote.comprobante[cl].resumen.importe_total_factura;
                                        string Campo10 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalNetoNoGravado += lote.comprobante[cl].resumen.importe_total_concepto_no_gravado;
                                            
                                        //string CampoXX = String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        string Campo11 = new string(Convert.ToChar("0"), 15);   //Percepción a no categorizados
                                        string Campo12 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalImporteExento += lote.comprobante[cl].resumen.importe_operaciones_exentas;
                                        //Importe de percepciones o pagos a cuenta de impuestos nacionales
                                        string Campo13 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalOtros = lote.comprobante[cl].resumen.importe_total_impuestos_nacionales;
                                        string Campo14 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIB = lote.comprobante[cl].resumen.importe_total_ingresos_brutos;
                                        string Campo15 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIM = lote.comprobante[cl].resumen.importe_total_impuestos_municipales;
                                        string Campo16 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalII = lote.comprobante[cl].resumen.importe_total_impuestos_internos;
                                        string Campo17 = String.Format("{0,-3}", lote.comprobante[cl].resumen.codigo_moneda);
                                        string Campo18 = String.Format("{0,11}", lote.comprobante[cl].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(0, 4) + String.Format("{0,11}", lote.comprobante[cl].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(5, 6);
                                        int CantAlicuotas = 0;
                                        if (lote.comprobante[cl].resumen.cant_alicuotas_iva == 0)
                                        {
                                            if (lote.comprobante[cl].resumen.impuestos != null)
                                            {
                                                for (int z = 0; z < lote.comprobante[cl].resumen.impuestos.Length; z++)
                                                {
                                                    if (lote.comprobante[cl].resumen.impuestos[z].codigo_impuesto == 1)
                                                    {
                                                        CantAlicuotas += 1;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CantAlicuotas = lote.comprobante[cl].resumen.cant_alicuotas_iva;
                                        }
                                        string Campo19 = String.Format("{0,1}", CantAlicuotas);
                                        string Campo20 = String.Format("{0,1}", lote.comprobante[cl].cabecera.informacion_comprobante.codigo_operacion);
                                        string Campo21 = new string(Convert.ToChar("0"), 15);  //Otros Tributos
                                        string Campo22 = String.Format("{0,-8}", lote.comprobante[cl].cabecera.informacion_comprobante.fecha_vencimiento);

                                        sbDataVENTASCab.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22);
                                        using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbVENTASCab.ToString()))
                                        {
                                            outfile.Write(sbDataVENTASCab.ToString());
                                        }

                                        //Guardar info en archivo VENTAS ALICUOTAS
                                        System.Text.StringBuilder sbDataVENTASAlic = new System.Text.StringBuilder();
                                        if (CantAlicuotas != 0)
                                        {
                                            HayVentasAlic = true;
                                            for (int z = 0; z < lote.comprobante[cl].resumen.impuestos.Length; z++)
                                            {
                                                if (lote.comprobante[cl].resumen.impuestos[z].codigo_impuesto == 1)
                                                {
                                                    Campo1 = lote.comprobante[cl].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                                    Campo2 = lote.comprobante[cl].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                                    Campo3 = lote.comprobante[cl].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));

                                                    double baseImponible = lote.comprobante[cl].resumen.impuestos[z].base_imponible;
                                                    TotalNetoGravado += baseImponible;
                                                    if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 0)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            for (int k = 0; k < lote.comprobante[cl].detalle.linea.Length; k++)
                                                            {
                                                                if (lote.comprobante[cl].detalle.linea[k] == null) { break; }
                                                                if (lote.comprobante[cl].detalle.linea[k].indicacion_exento_gravado != null && lote.comprobante[cl].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lote.comprobante[cl].detalle.linea[k].alicuota_iva == 0)
                                                                {
                                                                    baseImponible += Math.Round(lote.comprobante[cl].detalle.linea[k].importe_total_articulo, 2);
                                                                }
                                                            }
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0003";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                    }
                                                    if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 10.5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0004";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA105 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 21)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0005";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA210 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 27)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0006";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA270 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0008";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA050 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 2.5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo4 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo5 = "0009";
                                                        Campo6 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA025 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                }
                                            }

                                            sbDataVENTASAlic.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6);
                                            using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbVENTASAlic.ToString()))
                                            {
                                                outfile.Write(sbDataVENTASAlic.ToString());
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar la interfaz de ventas.\\n" + ex.Message + "\\n" + ex.StackTrace;
                                MessageBox.Show(script, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                        }
                        ResultadosTextBox.Text = "VENTAS (" + CantComprobantes + ")  Total Gral: " + TotalGral + System.Environment.NewLine;
                        if (TotalNetoGravado != 0)
                        {
                            ResultadosTextBox.Text += "Total Neto Gravado: " + TotalNetoGravado + System.Environment.NewLine; 
                        }
                        if (TotalNetoNoGravado != 0)
                        {
                            ResultadosTextBox.Text += "Total Neto No Gravado: " + TotalNetoNoGravado + System.Environment.NewLine;
                        }
                        if (TotalImporteExento != 0)
                        {
                            ResultadosTextBox.Text += "Total Exento: " + TotalImporteExento + System.Environment.NewLine;
                        }
                        if (TotalIB != 0)
                        {
                            ResultadosTextBox.Text += "Total IB: " + TotalIB + System.Environment.NewLine;
                        }
                        if (TotalIM != 0)
                        {
                            ResultadosTextBox.Text += "Total IM: " + TotalIM + System.Environment.NewLine;
                        }
                        if (TotalII != 0)
                        {
                            ResultadosTextBox.Text += "Total II: " + TotalII + System.Environment.NewLine;
                        }
                        if (TotalOtros != 0)
                        {
                            ResultadosTextBox.Text += "Total Otros Imp.Nac.: " + TotalOtros + System.Environment.NewLine;
                        }
                        if (TotalIVA270 != 0)
                        {
                            ResultadosTextBox.Text += "Total IVA 27%: " + TotalIVA270 + System.Environment.NewLine;
                        }
                        if (TotalIVA270 != 0)
                        {
                            ResultadosTextBox.Text += "Total IVA 21%: " + TotalIVA210 + System.Environment.NewLine;
                        }
                        if (TotalIVA270 != 0)
                        {
                            ResultadosTextBox.Text += "Total IVA 10,5%: " + TotalIVA105 + System.Environment.NewLine;
                        }
                        if (TotalIVA270 != 0)
                        {
                            ResultadosTextBox.Text += "Total IVA 5%: " + TotalIVA050 + System.Environment.NewLine;
                        }
                        if (TotalIVA270 != 0)
                        {
                            ResultadosTextBox.Text += "Total IVA 2,5%: " + TotalIVA025 + System.Environment.NewLine;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay información de Ventas para procesar en el período seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                #endregion

                #region Compras
                if (ComprasRadioButton.Checked)
                {
                    if (loteComprobantesC.Count > 0 || loteComprobantesD.Count > 0)
                    {
                        foreach (eFact_Entidades.Lote loteAProcesar in loteComprobantesC)
                        {
                            HayCompras = true;
                            lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                            x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                            try
                            {
                                loteAProcesar.LoteXml = loteAProcesar.LoteXml.Replace("iso-8859-1", "utf-16");
                                bytes = new byte[loteAProcesar.LoteXml.Length * sizeof(char)];
                                System.Buffer.BlockCopy(loteAProcesar.LoteXml.ToCharArray(), 0, bytes, 0, bytes.Length);
                                ms = new System.IO.MemoryStream(bytes);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);
                                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                                //Procesar todos los comprobantes del lote.
                                for (int cl = 0; cl < lote.comprobante.Length; cl++)
                                {
                                    #region "Armar Interfaz Compras"
                                    if (Convert.ToInt32(lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision) >= Convert.ToInt32(FechaDsdDTP.Value.ToString("yyyyMMdd")) && Convert.ToInt32(lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision) <= Convert.ToInt32(FechaHstDTP.Value.ToString("yyyyMMdd")))
                                    {
                                        CantComprobantes += 1;
                                        //Guardar info en archivo COMPRAS CABECERA
                                        System.Text.StringBuilder sbDataCOMPRASCab = new System.Text.StringBuilder();
                                        //string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                                        string Campo1 = lote.comprobante[cl].cabecera.informacion_comprobante.fecha_emision;
                                        string Campo2 = lote.comprobante[cl].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                        string Campo3 = lote.comprobante[cl].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                        string Campo4 = lote.comprobante[cl].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo5 = new string(Convert.ToChar(" "), 16);  //Nro. de despacho de importación
                                        string Campo6 = "80";
                                        string Campo7 = lote.comprobante[cl].cabecera.informacion_vendedor.cuit.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo8 = Truncate(String.Format("{0,-30}", lote.comprobante[cl].cabecera.informacion_vendedor.razon_social), 30);

                                        string Campo9 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalGral += lote.comprobante[cl].resumen.importe_total_factura;
                                        string Campo10 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalNetoNoGravado += lote.comprobante[cl].resumen.importe_total_concepto_no_gravado;

                                        //string CampoXX = String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        string Campo11 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalImporteExento += lote.comprobante[cl].resumen.importe_operaciones_exentas;

                                        //Importe de percepciones o pagos a cuenta de impuestos nacionales (IVA)
                                        string Campo12 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalOtros += lote.comprobante[cl].resumen.importe_total_impuestos_nacionales;
                                        //Importe de percepciones o pagos a cuenta de impuestos nacionales (Otros impuestos)
                                        string Campo13 = new string(Convert.ToChar("0"), 15);
                                        string Campo14 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIB += lote.comprobante[cl].resumen.importe_total_ingresos_brutos;
                                        string Campo15 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIM += lote.comprobante[cl].resumen.importe_total_impuestos_municipales;
                                        string Campo16 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalII += lote.comprobante[cl].resumen.importe_total_impuestos_internos;
                                        string Campo17 = String.Format("{0,-3}", lote.comprobante[cl].resumen.codigo_moneda);
                                        string Campo18 = String.Format("{0,11}", lote.comprobante[cl].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(0, 4) + String.Format("{0,11}", lote.comprobante[cl].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(5, 6);
                                        int CantAlicuotas = 0;
                                        if (lote.comprobante[cl].resumen.cant_alicuotas_iva == 0)
                                        {
                                            if (lote.comprobante[cl].resumen.impuestos != null)
                                            {
                                                for (int z = 0; z < lote.comprobante[cl].resumen.impuestos.Length; z++)
                                                {
                                                    if (lote.comprobante[cl].resumen.impuestos[z].codigo_impuesto == 1)
                                                    {
                                                        CantAlicuotas += 1;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CantAlicuotas = lote.comprobante[cl].resumen.cant_alicuotas_iva;
                                        }
                                        string Campo19 = String.Format("{0,1}", CantAlicuotas);
                                        string Campo20 = String.Format("{0,1}", lote.comprobante[cl].cabecera.informacion_comprobante.codigo_operacion);
                                        string Campo21 = new string(Convert.ToChar("0"), 15);           //Crédito Fiscal Computable
                                        string Campo22 = new string(Convert.ToChar("0"), 15);           //Otros Tributos
                                        string Campo23 = new string(Convert.ToChar("0"), 11);           //CUIT emisor / corredor
                                        string Campo24 = Truncate(String.Format("{0,-30}", ""), 30);    //Denominación del emisor / corredor
                                        string Campo25 = new string(Convert.ToChar("0"), 15);           //IVA comisión

                                        //string Campo25 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        //string Campo26 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);

                                        sbDataCOMPRASCab.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22 + Campo23 + Campo24 + Campo25);
                                        using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbCOMPRASCab.ToString()))
                                        {
                                            outfile.Write(sbDataCOMPRASCab.ToString());
                                        }

                                        //Guardar info en archivo COMPRAS ALICUOTAS
                                        System.Text.StringBuilder sbDataCOMPRASAlic = new System.Text.StringBuilder();
                                        if (CantAlicuotas != 0)
                                        {
                                            HayComprasAlic = true;
                                            for (int z = 0; z < lote.comprobante[cl].resumen.impuestos.Length; z++)
                                            {
                                                if (lote.comprobante[cl].resumen.impuestos[z].codigo_impuesto == 1)
                                                {
                                                    Campo1 = lote.comprobante[cl].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("000");
                                                    Campo2 = lote.comprobante[cl].cabecera.informacion_comprobante.punto_de_venta.ToString("00000");
                                                    Campo3 = lote.comprobante[cl].cabecera.informacion_comprobante.numero_comprobante.ToString(new string(Convert.ToChar("0"), 20));
                                                    Campo4 = "80";
                                                    Campo5 = lote.comprobante[cl].cabecera.informacion_vendedor.cuit.ToString(new string(Convert.ToChar("0"), 20));

                                                    double baseImponible = lote.comprobante[cl].resumen.impuestos[z].base_imponible;
                                                    TotalNetoGravado += baseImponible;
                                                    if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 0)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            for (int k = 0; k < lote.comprobante[cl].detalle.linea.Length; k++)
                                                            {
                                                                if (lote.comprobante[cl].detalle.linea[k] == null) { break; }
                                                                if (lote.comprobante[cl].detalle.linea[k].indicacion_exento_gravado != null && lote.comprobante[cl].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lote.comprobante[cl].detalle.linea[k].alicuota_iva == 0)
                                                                {
                                                                    baseImponible += Math.Round(lote.comprobante[cl].detalle.linea[k].importe_total_articulo, 2);
                                                                }
                                                            }
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0003";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                    }
                                                    if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 10.5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0004";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA105 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 21)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0005";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA210 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 27)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0006";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA270 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0008";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA050 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                    else if (lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto == 2.5)
                                                    {
                                                        if (lote.comprobante[cl].resumen.impuestos[z].base_imponible == 0)
                                                        {
                                                            baseImponible += Math.Round((lote.comprobante[cl].resumen.impuestos[z].importe_impuesto * 100) / lote.comprobante[cl].resumen.impuestos[z].porcentaje_impuesto, 2);
                                                        }
                                                        Campo6 = String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", baseImponible.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        Campo7 = "0009";
                                                        Campo8 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuestos[z].importe_impuesto.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                        TotalIVA025 += lote.comprobante[cl].resumen.impuestos[z].importe_impuesto;
                                                    }
                                                }
                                            }

                                            sbDataCOMPRASAlic.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8);
                                            using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbCOMPRASAlic.ToString()))
                                            {
                                                outfile.Write(sbDataCOMPRASAlic.ToString());
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                ResultadosTextBox.Text = "COMPRAS (" + CantComprobantes + ")  Total Gral: " + TotalGral + System.Environment.NewLine;
                                if (TotalNetoGravado != 0)
                                {
                                    ResultadosTextBox.Text += "Total Neto Gravado: " + TotalNetoGravado + System.Environment.NewLine;
                                }
                                if (TotalNetoNoGravado != 0)
                                {
                                    ResultadosTextBox.Text += "Total Neto No Gravado: " + TotalNetoNoGravado + System.Environment.NewLine;
                                }
                                if (TotalImporteExento != 0)
                                {
                                    ResultadosTextBox.Text += "Total Exento: " + TotalImporteExento + System.Environment.NewLine;
                                }
                                if (TotalIB != 0)
                                {
                                    ResultadosTextBox.Text += "Total IB: " + TotalIB + System.Environment.NewLine;
                                }
                                if (TotalIM != 0)
                                {
                                    ResultadosTextBox.Text += "Total IM: " + TotalIM + System.Environment.NewLine;
                                }
                                if (TotalII != 0)
                                {
                                    ResultadosTextBox.Text += "Total II: " + TotalII + System.Environment.NewLine;
                                }
                                if (TotalOtros != 0)
                                {
                                    ResultadosTextBox.Text += "Total Otros Imp.Nac.: " + TotalOtros + System.Environment.NewLine;
                                }
                                if (TotalIVA270 != 0)
                                {
                                    ResultadosTextBox.Text += "Total IVA 27%: " + TotalIVA270 + System.Environment.NewLine;
                                }
                                if (TotalIVA210 != 0)
                                {
                                    ResultadosTextBox.Text += "Total IVA 21%: " + TotalIVA210 + System.Environment.NewLine;
                                }
                                if (TotalIVA105 != 0)
                                {
                                    ResultadosTextBox.Text += "Total IVA 10,5%: " + TotalIVA105 + System.Environment.NewLine;
                                }
                                if (TotalIVA050 != 0)
                                {
                                    ResultadosTextBox.Text += "Total IVA 5%: " + TotalIVA050 + System.Environment.NewLine;
                                }
                                if (TotalIVA025 != 0)
                                {
                                    ResultadosTextBox.Text += "Total IVA 2,5%: " + TotalIVA025 + System.Environment.NewLine;
                                }
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar la interfaz de compras.\\n" + ex.Message + "\\n" + ex.StackTrace;
                                MessageBox.Show(script, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                return;
                            }
                        }
                        
                        TotalGral = 0; TotalNetoNoGravado = 0;
                        TotalImporteExento = 0; TotalIB = 0; TotalIM = 0;
                        TotalII = 0; TotalOtros = 0;
                        CantComprobantes = 0;
                        double ImportePercepOPagoCtaIVA = 0;

                        double TotalNG270 = 0; double TotalNG210 = 0; double TotalNG105 = 0;
                        double TotalNG050 = 0; double TotalNG025 = 0; 

                        foreach (eFact_Entidades.Lote loteAProcesar in loteComprobantesD)
                        {
                            HayCompras = true;
                            lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                            x = new System.Xml.Serialization.XmlSerializer(lote.GetType());

                            try
                            {
                                loteAProcesar.LoteXml = loteAProcesar.LoteXml.Replace("iso-8859-1", "utf-16");
                                bytes = new byte[loteAProcesar.LoteXml.Length * sizeof(char)];
                                System.Buffer.BlockCopy(loteAProcesar.LoteXml.ToCharArray(), 0, bytes, 0, bytes.Length);
                                ms = new System.IO.MemoryStream(bytes);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);
                                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                                //Procesar todos los comprobantes de despacho del lote.
                                for (int cl = 0; cl < lote.comprobanteDespacho.Length; cl++)
                                {
                                    #region "Armar Interfaz Compras Importaciones"
                                    if (Convert.ToInt32(lote.comprobanteDespacho[cl].DespachoCabecera.Fecha) >= Convert.ToInt32(FechaDsdDTP.Value.ToString("yyyyMMdd")) && Convert.ToInt32(lote.comprobanteDespacho[cl].DespachoCabecera.Fecha) <= Convert.ToInt32(FechaHstDTP.Value.ToString("yyyyMMdd")))
                                    {
                                        CantComprobantes += 1;
                                        //Guardar info en archivo COMPRAS IMPORTACIONES CABECERA
                                        System.Text.StringBuilder sbDataCOMPRASCab = new System.Text.StringBuilder();
                                        //string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                                        string Campo1 = lote.comprobanteDespacho[cl].DespachoCabecera.Fecha;
                                        string Campo2 = lote.comprobanteDespacho[cl].DespachoCabecera.TipoComprobante.ToString("000");
                                        string Campo3 = "00000";
                                        string Campo4 = new string(Convert.ToChar("0"), 20);  //ceros
                                        string Campo5 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoCabecera.NumeroDespacho);  //Nro. de despacho de importación
                                        string Campo6 = "80";
                                        string Campo7 = lote.comprobanteDespacho[cl].DespachoCabecera.NroDocVendedor.ToString(new string(Convert.ToChar("0"), 20));
                                        string Campo8 = Truncate(String.Format("{0,-30}", lote.comprobanteDespacho[cl].DespachoCabecera.NombreVendedor), 30);

                                        string Campo9 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteTotal.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteTotal.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalGral += lote.comprobanteDespacho[cl].DespachoResumen.ImporteTotal;
                                        string Campo10 = "";
                                        if (lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado < 0)
                                        {
                                            Campo10 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado.ToString(new string(Convert.ToChar("0"), 12) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado.ToString(new string(Convert.ToChar("0"), 12) + ".00")).Substring(14, 2);
                                        }
                                        else
                                        {
                                            Campo10 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        }
                                        TotalNetoGravado += lote.comprobanteDespacho[cl].DespachoResumen.ImporteNetoNoGravado;
                                        string Campo11 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteExento.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImporteExento.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalImporteExento += lote.comprobanteDespacho[cl].DespachoResumen.ImporteExento;

                                        //Importe de percepciones o pagos a cuenta de impuestos nacionales (IVA)
                                        string Campo12 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaIVA.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaIVA.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        ImportePercepOPagoCtaIVA += lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaIVA;
                                        //Importe de percepciones o pagos a cuenta de impuestos nacionales (Otros impuestos)
                                        string Campo13 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaOtrosImpNac.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaOtrosImpNac.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalOtros += lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepOPagoCtaOtrosImpNac;
                                        string Campo14 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepIB.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepIB.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIB += lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepIB;
                                        string Campo15 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpMunicipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpMunicipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalIM += lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpMunicipales;
                                        string Campo16 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpInternos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpInternos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        TotalII += lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpInternos;
                                        string Campo17 = String.Format("{0,-3}", lote.comprobanteDespacho[cl].DespachoResumen.Moneda);
                                        string Campo18 = String.Format("{0,11}", lote.comprobanteDespacho[cl].DespachoResumen.TipoCambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(0, 4) + String.Format("{0,11}", lote.comprobanteDespacho[cl].DespachoResumen.TipoCambio.ToString(new string(Convert.ToChar("0"), 4) + ".000000")).Substring(5, 6);
                                        int CantAlicuotas = 0;
                                        if (lote.comprobanteDespacho[cl].DespachoImpuesto != null)
                                        {
                                            for (int z = 0; z < lote.comprobanteDespacho[cl].DespachoImpuesto.Length; z++)
                                            {
                                                if (lote.comprobanteDespacho[cl].DespachoImpuesto[z] != null)
                                                {
                                                    CantAlicuotas += 1;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        string Campo19 = String.Format("{0,1}", CantAlicuotas);
                                        string Campo20 = String.Format("{0,1}", lote.comprobanteDespacho[cl].DespachoResumen.CodigoOperacion);
                                        //Crédito Fiscal Computable
                                        string Campo21 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.CreditoFiscalComputable.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoResumen.ImportePercepImpInternos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        string Campo22 = new string(Convert.ToChar("0"), 15);           //Otros Tributos
                                        string Campo23 = new string(Convert.ToChar("0"), 11);           //CUIT emisor / corredor
                                        string Campo24 = Truncate(String.Format("{0,-30}", ""), 30);    //Denominación del emisor / corredor
                                        string Campo25 = new string(Convert.ToChar("0"), 15);           //IVA comisión

                                        //string Campo25 = String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                        //string Campo26 = String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[cl].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);

                                        sbDataCOMPRASCab.AppendLine(Campo1 + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22 + Campo23 + Campo24 + Campo25);
                                        using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbCOMPRASCab.ToString()))
                                        {
                                            outfile.Write(sbDataCOMPRASCab.ToString());
                                        }

                                        //Guardar info en archivo COMPRAS IMPORTACIONES ALICUOTAS
                                        System.Text.StringBuilder sbDataCOMPRASImpAlic = new System.Text.StringBuilder();
                                        if (CantAlicuotas != 0)
                                        {
                                            HayComprasImpAlic = true;
                                            for (int z = 0; z < lote.comprobanteDespacho[cl].DespachoImpuesto.Length; z++)
                                            {
                                                if (lote.comprobanteDespacho[cl].DespachoImpuesto[z] != null)
                                                {
                                                    Campo1 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoCabecera.NumeroDespacho);
                                                    Campo2 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                    if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 0)
                                                    {
                                                        Campo3 = "0003";
                                                    }
                                                    if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 10.5)
                                                    {
                                                        Campo3 = "0004";
                                                        TotalNG105 += lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado;
                                                    }
                                                    else if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 21)
                                                    {
                                                        Campo3 = "0005";
                                                        TotalNG210 += lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado;
                                                    }
                                                    else if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 27)
                                                    {
                                                        Campo3 = "0006";
                                                        TotalNG270 += lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado;
                                                    }
                                                    else if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 5)
                                                    {
                                                        Campo3 = "0008";
                                                        TotalNG050 += lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado;
                                                    }
                                                    else if (lote.comprobanteDespacho[cl].DespachoImpuesto[z].AlicIVA == 2.5)
                                                    {
                                                        Campo3 = "0009";
                                                        TotalNG025 += lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteNetoGravado;
                                                    }
                                                    Campo4 = String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteImpuestoLiq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobanteDespacho[cl].DespachoImpuesto[z].ImporteImpuestoLiq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                                                    sbDataCOMPRASImpAlic.AppendLine(Campo1 + Campo2 + Campo3 + Campo4);
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            using (StreamWriter outfile = new StreamWriter(Path.GetTempPath() + sbCOMPRASImpAlic.ToString()))
                                            {
                                                outfile.Write(sbDataCOMPRASImpAlic.ToString());
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar la interfaz de compras despachos.\\n" + ex.Message + "\\n" + ex.StackTrace;
                                MessageBox.Show(script, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                return;
                            }
                            if (ResultadosTextBox.Text != "")
                            {
                                ResultadosTextBox.Text += System.Environment.NewLine + System.Environment.NewLine;
                            }
                            ResultadosTextBox.Text += "DESPACHOS (" + CantComprobantes + ")  Total Gral: " + TotalGral + System.Environment.NewLine;
                            if (TotalNetoNoGravado != 0)
                            {
                                ResultadosTextBox.Text += "Total Neto No Gravado: " + TotalNetoNoGravado + System.Environment.NewLine;
                            }
                            if (TotalImporteExento != 0)
                            {
                                ResultadosTextBox.Text += "Total Exento: " + TotalImporteExento + System.Environment.NewLine;
                            }
                            if (TotalIB != 0)
                            {
                                ResultadosTextBox.Text += "Total IB: " + TotalIB + System.Environment.NewLine;
                            }
                            if (TotalIM != 0)
                            {
                                ResultadosTextBox.Text += "Total IM: " + TotalIM + System.Environment.NewLine;
                            }
                            if (TotalII != 0)
                            {
                                ResultadosTextBox.Text += "Total II: " + TotalII + System.Environment.NewLine;
                            }
                            if (ImportePercepOPagoCtaIVA != 0)
                            {
                                ResultadosTextBox.Text += "Total Pago Cta IVA: " + ImportePercepOPagoCtaIVA + System.Environment.NewLine;
                            }
                            if (TotalOtros != 0)
                            {
                                ResultadosTextBox.Text += "Total Otros Imp.Nac.: " + TotalOtros + System.Environment.NewLine;
                            }
                            if (TotalIVA270 != 0)
                            {
                                ResultadosTextBox.Text += "Total NG 27%: " + TotalIVA270 + System.Environment.NewLine;
                            }
                            if (TotalIVA210 != 0)
                            {
                                ResultadosTextBox.Text += "Total NG 21%: " + TotalIVA210 + System.Environment.NewLine;
                            }
                            if (TotalIVA105 != 0)
                            {
                                ResultadosTextBox.Text += "Total IVA 10,5%: " + TotalIVA105 + System.Environment.NewLine;
                            }
                            if (TotalIVA050 != 0)
                            {
                                ResultadosTextBox.Text += "Total IVA 5%: " + TotalIVA050 + System.Environment.NewLine;
                            }
                            if (TotalIVA025 != 0)
                            {
                                ResultadosTextBox.Text += "Total IVA 2,5%: " + TotalIVA025 + System.Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay información de Compras / Despachos para procesar en el período seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                #endregion

                //Descargar ZIP ( Ventas y Alicuotas )
                string filename = sbZIP.ToString();
                //String dlDir = @"~/Temp/";
                String pathZIP = Aplicacion.Aplic.ArchPathItf + filename;
                System.IO.FileInfo toZIP = new System.IO.FileInfo(pathZIP);
                System.IO.FileInfo toVENTASCab = new System.IO.FileInfo(Path.GetTempPath() + sbVENTASCab.ToString());
                System.IO.FileInfo toVENTASAlic = new System.IO.FileInfo(Path.GetTempPath() + sbVENTASAlic.ToString());
                System.IO.FileInfo toCOMPRASCab = new System.IO.FileInfo(Path.GetTempPath() + sbCOMPRASCab.ToString());
                System.IO.FileInfo toCOMPRASAlic = new System.IO.FileInfo(Path.GetTempPath() + sbCOMPRASAlic.ToString());

                using (ZipFile zip = new ZipFile())
                {
                    if (HayVentas)
                    {
                        zip.AddFile(Path.GetTempPath() + sbVENTASCab.ToString(), "");
                    }
                    if (HayVentasAlic)
                    {
                        zip.AddFile(Path.GetTempPath() + sbVENTASAlic.ToString(), "");
                    }

                    if (HayCompras)
                    {
                        zip.AddFile(Path.GetTempPath() + sbCOMPRASCab.ToString(), "");
                    }
                    if (HayComprasAlic)
                    {
                        zip.AddFile(Path.GetTempPath() + sbCOMPRASAlic.ToString(), "");
                    }
                    if (HayComprasImpAlic)
                    {
                        zip.AddFile(Path.GetTempPath() + sbCOMPRASImpAlic.ToString(), "");
                    }
                    if (HayVentas || HayCompras)
                    {
                        zip.Save(pathZIP);
                    }
                    else
                    {
                        //Borrar ZIP vacio.
                        toZIP.Delete();
                    }
                    //Borrar archivos ya incluidos en el ZIP
                    toVENTASCab.Delete();
                    toVENTASAlic.Delete();
                    toCOMPRASCab.Delete();
                    toCOMPRASAlic.Delete();
                }
                toZIP = new System.IO.FileInfo(pathZIP);
                if (toZIP.Exists)
                {
                    MessageBox.Show("Archivo de Interfaz ZIP generado satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Archivo de Interfaz ZIP inexistente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("No hay información para procesar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}