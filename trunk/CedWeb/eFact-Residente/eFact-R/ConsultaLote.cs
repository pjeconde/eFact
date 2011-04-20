using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using eFact_R.Facturacion.Electronica.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Xml;

namespace eFact_R
{
    public partial class ConsultaLote : Form
    {
        private eFact_R.Entidades.Lote lote;
        CrystalDecisions.CrystalReports.Engine.ReportDocument facturaRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument imagenRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument codigobarrasRpt;
        Modo modoActual;
        DataSet dsImages = new DataSet();
        
        public enum Modo
        {
            Consulta,
            Contingencia
        }
        public ConsultaLote(eFact_R.Entidades.Lote Lote, Modo modo)
        {
            InitializeComponent();
            lote = Lote;
            modoActual = modo;
        }
        public ConsultaLote(Modo modo)
        {
            InitializeComponent();
            lote = null;
            modoActual = modo;
        }
        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaLote_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataGridViewComboBoxColumn colIdTipoComprobante = (DataGridViewComboBoxColumn)DetalleLoteDataGridView.Columns["IdTipoComprobante"];
                colIdTipoComprobante.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();
                colIdTipoComprobante.DisplayMember = "Descr";
                colIdTipoComprobante.ValueMember = "Codigo";
                colIdTipoComprobante.DataPropertyName = "IdTipoComprobante";
                colIdTipoComprobante.HeaderText = "Tipo de Comprobante";

                DataGridViewComboBoxColumn colTipoDocComprador = (DataGridViewComboBoxColumn)DetalleLoteDataGridView.Columns["TipoDocComprador"];
                colTipoDocComprador.DataSource = FeaEntidades.Documentos.Documento.Lista();
                colTipoDocComprador.DisplayMember = "Descr";
                colTipoDocComprador.ValueMember = "Codigo";
                colTipoDocComprador.DataPropertyName = "TipoDocComprador";
                colTipoDocComprador.HeaderText = "Tipo Doc. Comprador";

                DataGridViewComboBoxColumn colIdMoneda = (DataGridViewComboBoxColumn)DetalleLoteDataGridView.Columns["IdMoneda"];
                colIdMoneda.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
                colIdMoneda.DisplayMember = "Descr";
                colIdMoneda.ValueMember = "Codigo";
                colIdMoneda.DataPropertyName = "IdMoneda";
                colIdMoneda.HeaderText = "Mon.";

                if (lote != null)
                {
                    BindingControles();

                    LogLoteDataGridView.AutoGenerateColumns = false;
                    LogLoteDataGridView.DataSource = new List<CedEntidades.Evento>();
                    LogLoteDataGridView.DataSource = lote.WF.Log;
                    RN.Lote.MuestroEsquemaSegEventosPosibles(EsquemaSegEventosPosiblesTreeView, lote);
                    LogLoteDataGridView.Refresh();

                    DetalleLoteDataGridView.AutoGenerateColumns = false;
                    DetalleLoteDataGridView.DataSource = new List<eFact_R.Entidades.Comprobante>();
                    lote.Comprobantes.Sort(ordenarPorNroComprobante);
                    DetalleLoteDataGridView.DataSource = lote.Comprobantes;
                    DetalleLoteDataGridView.Refresh();
                }
                else
                {
                    //Contingencia
                    NumeroLoteTextBox.ReadOnly = false;
                    CuitVendedorTextBox.ReadOnly = false;
                    PuntoVentaTextBox.ReadOnly = false;
                }
                CancelarButton.Visible = false;
                if (IdEstadoTextBox.Text != "AceptadoAFIP" && IdEstadoTextBox.Text != "AceptadoAFIPO" && IdEstadoTextBox.Text != "AceptadoAFIPP")
                {
                    ExportarComprobanteButton.Enabled = false;
                    ConsultarComprobanteButton.Enabled = false;
                }
                //ConsultarComprobanteButton.Enabled = false;
                //ExportarComprobanteButton.Enabled = false;
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
        private static int ordenarPorNroComprobante(eFact_R.Entidades.Comprobante A1, eFact_R.Entidades.Comprobante A2)
        {

            return Convert.ToInt32(A1.IdTipoComprobante.ToString().Trim() + A1.NumeroComprobante.PadLeft(8, Convert.ToChar("0"))).CompareTo(Convert.ToInt32(A2.IdTipoComprobante + A2.NumeroComprobante.PadLeft(8, Convert.ToChar("0"))));
        }
        private void BindingControles()
        {
            //Cabecera del lote
            IdLoteTextBox.DataBindings.Clear();
            IdLoteTextBox.DataBindings.Add("Text", lote, "IdLote");
            CuitVendedorTextBox.DataBindings.Clear();
            CuitVendedorTextBox.DataBindings.Add("Text", lote, "CuitVendedor");
            NumeroLoteTextBox.DataBindings.Clear();
            NumeroLoteTextBox.DataBindings.Add("Text", lote, "NumeroLote");
            PuntoVentaTextBox.DataBindings.Clear();
            PuntoVentaTextBox.DataBindings.Add("Text", lote, "PuntoVenta");
            CantidadRegistrosTextBox.DataBindings.Clear();
            CantidadRegistrosTextBox.DataBindings.Add("Text", lote, "CantidadRegistros");
            NumeroEnvioTextBox.DataBindings.Clear();
            NumeroEnvioTextBox.DataBindings.Add("Text", lote, "NumeroEnvio");
            FechaAltaDTP.DataBindings.Clear();
            FechaAltaDTP.DataBindings.Add("Value", lote, "FechaAlta");
            FechaEnvioDTP.DataBindings.Clear();
            FechaEnvioDTP.DataBindings.Add("Value", lote, "FechaEnvio");
            NombreArchTextBox.DataBindings.Clear();
            NombreArchTextBox.DataBindings.Add("Text", lote, "NombreArch");
            IdEstadoTextBox.DataBindings.Clear();
            IdEstadoTextBox.DataBindings.Add("Text", lote, "IdEstado");
            //XML Origen
            this.XMLWebBrowser.Navigate("about:blank");
            try
            {
                if (lote.LoteXml != null && lote.LoteXml != "")
                {
                    StreamWriter fileWriter;
                    fileWriter = File.CreateText(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XML.xml");
                    string lotexml = lote.LoteXml.Replace("iso-8859-1", "UTF-8");
                    fileWriter.Write(lotexml);
                    fileWriter.Close();
                    XMLWebBrowser.Navigate(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XML.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Solapa XML Origen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            //XML Respuesta
            this.XMLIFWebBrowser.Navigate("about:blank");
            try
            {
                if (lote.LoteXmlIF != null && lote.LoteXmlIF != "")
                {
                    StreamWriter fileWriter;
                    fileWriter = File.CreateText(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XMLIF.xml");
                    string lotexml = lote.LoteXmlIF.Replace("iso-8859-1", "UTF-8");
                    fileWriter.Write(lotexml);
                    fileWriter.Close();
                    XMLIFWebBrowser.Navigate(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XMLIF.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Solapa XML Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void ConsultarLoteIFButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                CedWebRN.IBK.error[] respErroresLote = new CedWebRN.IBK.error[0];
                CedWebRN.IBK.error[] respErroresComprobantes = new CedWebRN.IBK.error[0];
                eFact_R.Entidades.Vendedor v = Aplicacion.Vendedores.Find(delegate(eFact_R.Entidades.Vendedor e1) { return e1.CuitVendedor == CuitVendedorTextBox.Text; });
                if (v == null)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Vendedor.Inexistente("CUIT " + CuitVendedorTextBox.Text);
                }
                if (modoActual == Modo.Contingencia)
                {
                    lote = new eFact_R.Entidades.Lote();
                    if (NumeroLoteTextBox.Text == "")
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Número de lote");
                    }
                    if (!(Cedeira.SV.Fun.IsNumeric(NumeroLoteTextBox.Text)))
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Número de lote");
                    }
                    lote.NumeroLote = NumeroLoteTextBox.Text;
                    if (CuitVendedorTextBox.Text == "")
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cuit vendedor");
                    }
                    if (!(Cedeira.SV.Fun.IsNumeric(CuitVendedorTextBox.Text)))
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Cuit vendedor");
                    }
                    lote.CuitVendedor = CuitVendedorTextBox.Text;
                    if (PuntoVentaTextBox.Text == "")
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Punto de Venta");
                    }
                    if (!(Cedeira.SV.Fun.IsNumeric(PuntoVentaTextBox.Text)))
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Punto de Venta");
                    }
                    lote.PuntoVenta = PuntoVentaTextBox.Text;
                    eFact_R.RN.Lote.ConsultarLoteIF(out Lc, out respErroresLote, out respErroresComprobantes, lote, v.NumeroSerieCertificado.ToString());
                    eFact_R.RN.Lote.Lc2Lote(out lote, Lc, Aplicacion.Sesion);
                    BindingControles();
                    DetalleLoteDataGridView.AutoGenerateColumns = false;
                    DetalleLoteDataGridView.DataSource = new List<eFact_R.Entidades.Comprobante>();
                    DetalleLoteDataGridView.DataSource = lote.Comprobantes;
                    CancelarButton.Visible = true;
                    ConsultarLoteIFButton.Enabled = false;
                }
                else
                {
                    eFact_R.RN.Lote.ConsultarLoteIF(out Lc, out respErroresLote, out respErroresComprobantes, lote, v.NumeroSerieCertificado.ToString());
                    MessageBox.Show("Lote de comprobantes número " + lote.NumeroLote + " encontrado satisfactoriamente en Interfacturas.", "Consulta de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (modoActual == Modo.Contingencia)
                {
                    Cancelar();
                }
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void LogLoteDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (LogLoteDataGridView.SelectedRows.Count != 0)
            {
                int renglon = LogLoteDataGridView.SelectedRows[0].Index;
                string comentario = lote.WF.Log[renglon].Comentario;
                Comentarios c = new Comentarios(comentario);
                c.ShowDialog();
                c = null;
            }
        }

        private void ProcesarComprobante(out CrystalDecisions.CrystalReports.Engine.ReportDocument ReporteDocumento, eFact_R.Entidades.Lote Lote, int Renglon)
        {
            facturaRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            facturaRpt.Load("Facturacion\\Electronica\\Reportes\\Factura.rpt");

            //Crear un lote de un solo comprobante, para la impresion o exportacion del pdf.
            eFact_R.Entidades.Lote LoteConUnSoloComprobante = new eFact_R.Entidades.Lote();
            LoteConUnSoloComprobante.CuitVendedor = Lote.CuitVendedor;
            LoteConUnSoloComprobante.FechaAlta = Lote.FechaAlta;
            LoteConUnSoloComprobante.FechaEnvio = Lote.FechaEnvio;
            LoteConUnSoloComprobante.IdLote = Lote.IdLote;
            LoteConUnSoloComprobante.IdOp = Lote.IdOp;
            LoteConUnSoloComprobante.LoteXml = Lote.LoteXml;
            LoteConUnSoloComprobante.LoteXmlIF = Lote.LoteXmlIF;
            LoteConUnSoloComprobante.NumeroEnvio = Lote.NumeroEnvio;
            LoteConUnSoloComprobante.NumeroLote = Lote.NumeroLote;
            LoteConUnSoloComprobante.PuntoVenta = Lote.PuntoVenta;
            LoteConUnSoloComprobante.CantidadRegistros = 1;
            LoteConUnSoloComprobante.Comprobantes.Add(Lote.Comprobantes[Renglon]);
            LoteConUnSoloComprobante.WF = Lote.WF;
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            eFact_R.RN.Lote.DeserializarLc(out lc, LoteConUnSoloComprobante, true);
            for (int i = 0; i < lc.comprobante.Length; i++)
            {
                if (i == 0)
                {
                    lc.comprobante[i] = lc.comprobante[Renglon];
                }
                else
                {
                    lc.comprobante[i] = null;
                }
            }
            AsignarCamposOpcionales(lc);
            ReemplarResumenImportesMonedaExtranjera(lc);
            DataSet ds = new DataSet();
            XmlSerializer objXS = new XmlSerializer(lc.GetType());
            StringWriter objSW = new StringWriter();
            objXS.Serialize(objSW, lc);
            StringReader objSR = new StringReader(objSW.ToString());
            ds.ReadXml(objSR);
            
            string pxsd = string.Format("{0}\\Facturacion\\Electronica\\Reportes\\lote_comprobantes.xsd",System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            System.IO.File.Copy(pxsd, @System.IO.Path.GetTempPath() + "lote_comprobantes.xsd", true);
            
            string imagen = string.Format("{0}\\Facturacion\\Electronica\\Reportes\\Imagen.xsd",System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            System.IO.File.Copy(imagen, @System.IO.Path.GetTempPath() + "Imagen.xsd", true);

            facturaRpt.SetDataSource(ds);

            facturaRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            facturaRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            IncrustarLogo();
            GenerarCodigoBarras(lc.cabecera_lote.cuit_vendedor + lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00") + lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("0000") + lc.comprobante[0].cabecera.informacion_comprobante.cae + System.DateTime.Now.ToString("yyyyMMdd"));
            AsignarParametros(lc.comprobante[0].resumen.importe_total_factura);

            ReporteDocumento = facturaRpt;
        }

        private static void ReemplarResumenImportesMonedaExtranjera(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (!lc.comprobante[0].resumen.codigo_moneda.Equals("PES"))
            {
                lc.comprobante[0].resumen.importe_total_neto_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado;

                lc.comprobante[0].resumen.importe_total_concepto_no_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                lc.comprobante[0].resumen.importe_operaciones_exentas = lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas;
                lc.comprobante[0].resumen.impuesto_liq = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq;
                lc.comprobante[0].resumen.impuesto_liq_rni = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni;
                lc.comprobante[0].resumen.importe_total_impuestos_municipales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                lc.comprobante[0].resumen.importe_total_impuestos_nacionales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                lc.comprobante[0].resumen.importe_total_ingresos_brutos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                lc.comprobante[0].resumen.importe_total_impuestos_internos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos;

                lc.comprobante[0].resumen.importe_total_factura = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;

                if (lc.comprobante[0].resumen.descuentos != null)
                {
                    for (int i = 0; i < lc.comprobante[0].resumen.descuentos.Length; i++)
                    {
                        if (lc.comprobante[0].resumen.descuentos[i] != null)
                        {
                            lc.comprobante[0].resumen.descuentos[i].importe_descuento = lc.comprobante[0].resumen.descuentos[i].importe_descuento_moneda_origen;
                        }
                    }
                }
            }
        }

        private void ConsultarComprobanteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DetalleLoteDataGridView.SelectedRows.Count > 0)
                {
                    if (DetalleLoteDataGridView.SelectedRows.Count > 1)
                    {
                        MessageBox.Show("Seleccione un solo comprobante a la vez, para la consulta.", "Consulta de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        int renglon = DetalleLoteDataGridView.SelectedRows[0].Index;
                        bool VisualizarComprobantePermitido = true;
                        if (IdEstadoTextBox.Text == "AceptadoAFIPP")
                        {
                            if (!(lote.Comprobantes[renglon].EstadoIFoAFIP == "A" || lote.Comprobantes[renglon].EstadoIFoAFIP == "O"))
                            {
                                VisualizarComprobantePermitido = false;
                            }
                        }
                        if (VisualizarComprobantePermitido)
                        {
                            ReportDocument ReporteDocumento = new ReportDocument();
                            ProcesarComprobante(out ReporteDocumento, lote, renglon);
                            ConsultaComprobante c = new ConsultaComprobante(facturaRpt);
                            c.ShowDialog();
                            c = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consulta de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void AsignarCamposOpcionales(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = string.Empty;
            }
            if (lc.cabecera_lote.presta_servSpecified == false)
            {
                lc.cabecera_lote.presta_serv = 0;
                lc.cabecera_lote.presta_servSpecified = true;
            }
            if (lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago = "";
                lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
            }
            lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = "";
            lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = "";
            lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
            lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = true;
            lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle == null)
            {
                lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_vendedor.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_vendedor.provincia = string.Empty;
            }
            lc.comprobante[0].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = true;
            lc.comprobante[0].cabecera.informacion_comprador.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.provincia = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.localidad == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.localidad = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.cp == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.cp = string.Empty;
            }
            for (int i = 0; i < lc.comprobante[0].resumen.impuestos.Length; i++)
            {
                lc.comprobante[0].resumen.impuestos[i].codigo_jurisdiccion = 0;
                lc.comprobante[0].resumen.impuestos[i].codigo_jurisdiccionSpecified = true;
            }
            lc.comprobante[0].resumen.cant_alicuotas_ivaSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified = true;
            if (lc.comprobante[0].resumen.descuentos == null)
            {
                lc.comprobante[0].resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[1];
                lc.comprobante[0].resumen.descuentos[0] = new FeaEntidades.InterFacturas.resumenDescuentos();
                lc.comprobante[0].resumen.descuentos[0].alicuota_iva_descuentoSpecified = true;
                lc.comprobante[0].resumen.descuentos[0].importe_iva_descuentoSpecified = true;
            }
            if (lc.comprobante[0].extensiones != null)
            {
                if (lc.comprobante[0].extensiones.extensiones_datos_comerciales == null)
                {
                    lc.comprobante[0].extensiones.extensiones_datos_comerciales = string.Empty;
                }
                else
                {
                    eFact_R.RN.Engine engine = new eFact_R.RN.Engine();
                    lc.comprobante[0].extensiones.extensiones_datos_comerciales = engine.HexToString(lc.comprobante[0].extensiones.extensiones_datos_comerciales.ToString());
                }
            }
            for (int i = 0; i < lc.comprobante[0].detalle.linea.Length; i++)
            {
                if (lc.comprobante[0].detalle.linea[i] != null)
                {
                    lc.comprobante[0].detalle.linea[i].importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                    lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_ivaSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_articuloSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importes_moneda_origen.precio_unitarioSpecified = true;

                    if (lc.comprobante[0].detalle.linea[i].importe_total_descuentos == null)
                    {
                        lc.comprobante[0].detalle.linea[i].importe_total_descuentos = 0;
                    }
                    lc.comprobante[0].detalle.linea[i].importe_total_descuentosSpecified = true;
                    
                    lc.comprobante[0].detalle.linea[i].precio_unitarioSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importe_ivaSpecified = true;
                    if (lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified.Equals(false))
                    {
                        lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified = true;
                        lc.comprobante[0].detalle.linea[i].alicuota_iva = 99;
                    }
                    lc.comprobante[0].detalle.linea[i].cantidadSpecified = true;

                    if (lc.comprobante[0].detalle.linea[i].unidad == null)
                    {
                        lc.comprobante[0].detalle.linea[i].unidad = string.Empty;
                    }
                    if (lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado == null)
                    {
                        lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado = string.Empty;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void AsignarParametros(double p)
        {
            CrystalDecisions.Shared.ParameterValues myVals = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscrete = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myDiscrete.Value = NumALet.ToCardinal(Convert.ToDecimal(p));
            myVals.Add(myDiscrete);
            facturaRpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(myVals);
        }

        private void GenerarCodigoBarras(string code)
        {
            if (code != null)
            {
                Code39 c39 = new Code39();
                MemoryStream ms = new MemoryStream();
                c39.FontFamilyName = "Free 3 of 9";
                c39.FontFileName = "Facturacion\\Electronica\\Reportes\\FREE3OF9.TTF";
                c39.FontSize = 30;
                c39.ShowCodeString = true;
                System.Drawing.Bitmap objBitmap = c39.GenerateBarcode(code);
                objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                codigobarrasRpt = facturaRpt.OpenSubreport("CodigoBarra.rpt");

                CrearTabla();

                DataRow dr = this.dsImages.Tables["images"].NewRow();
                dr["path"] = "ninguno";
                dr["image"] = ms.ToArray();
                this.dsImages.Tables["images"].Rows.Add(dr);

                codigobarrasRpt.SetDataSource(this.dsImages);
            }
        }

        private void IncrustarLogo()
        {
            eFact_R.Entidades.Vendedor vendedor = new eFact_R.Entidades.Vendedor();
            vendedor.CuitVendedor = lote.CuitVendedor;
            eFact_R.RN.Vendedor.Leer(vendedor, Aplicacion.Sesion);
            CrearTabla();
            DataRow dr = this.dsImages.Tables["images"].NewRow();
            dr["path"] = "";
            if (vendedor.Logo != null && vendedor.Logo.Length != 0)
            {
                MemoryStream memorybits = new MemoryStream(vendedor.Logo);
                byte[] bytesLogo = new byte[memorybits.Length - 1];
                memorybits.Read(bytesLogo, 0, Convert.ToInt32(memorybits.Length - 1));
                dr["image"] = bytesLogo;
            }
            this.dsImages.Tables["images"].Rows.Add(dr);
            imagenRpt = facturaRpt.OpenSubreport("Imagen.rpt");
            dsImages.WriteXmlSchema(@System.IO.Path.GetTempPath() + "Imagen.xsd");
            imagenRpt.SetDataSource(this.dsImages);
        }

        private void CrearTabla()
        {
            this.dsImages = new DataSet();
            DataTable imageTable = new DataTable("Images");
            imageTable.Columns.Add(new DataColumn("path", typeof(string)));
            imageTable.Columns.Add(new DataColumn("image", typeof(System.Byte[])));
            this.dsImages.Tables.Add(imageTable);
        }

        private void ExportarComprobanteButton_Click(object sender, EventArgs e)
        {
            if (DetalleLoteDataGridView.SelectedRows.Count != 0)
            {
                for (int i = 0; i < DetalleLoteDataGridView.SelectedRows.Count; i++)
                {
                    int renglon = DetalleLoteDataGridView.SelectedRows[i].Index;
                    ReportDocument ReporteDocumento = new ReportDocument();
                    ProcesarComprobante(out ReporteDocumento, lote, renglon);

                    //Nombre del comprobante ( pdf )
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(lote.CuitVendedor);
                    sb.Append("-");
                    sb.Append(Convert.ToInt32(lote.PuntoVenta).ToString("0000"));
                    sb.Append("-");
                    sb.Append(Convert.ToInt32(lote.Comprobantes[renglon].IdTipoComprobante).ToString("00"));
                    sb.Append("-");
                    sb.Append(Convert.ToInt32(lote.Comprobantes[renglon].NumeroComprobante).ToString("00000000"));
                    sb.Append(".pdf");

                    //ExportOptions
                    DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    crDiskFileDestinationOptions.DiskFileName = eFact_R.Aplicacion.ArchPathPDF + sb.ToString();
                    ReporteDocumento.ExportOptions.ExportDestinationOptions = crDiskFileDestinationOptions;
                    ReporteDocumento.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    ReporteDocumento.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    ReporteDocumento.ExportOptions.ExportFormatOptions = CrFormatTypeOptions;
                    ReporteDocumento.Export();
                }
                if (DetalleLoteDataGridView.SelectedRows.Count == 1)
                {
                    MessageBox.Show("El comprobante seleccionado se ha exportado satisfactoriamente.", "Exportar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Los comprobantes seleccionados se han exportado satisfactoriamente.", "Exportar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void DetalleLoteDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (((DataGridView)sender).Name.ToString() == "DetalleLoteDataGridView")
            {
            }
        }

        private void LogLoteDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (((DataGridView)sender).Name.ToString() == "LogLoteDataGridView")
            {
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        private void Cancelar()
        {
            lote = new eFact_R.Entidades.Lote();
            IdLoteTextBox.Text = "";
            //CuitVendedorTextBox.Text = "";
            //NumeroLoteTextBox.Text = "";
            //PuntoVentaTextBox.Text = "";
            CantidadRegistrosTextBox.Text = "";
            NumeroEnvioTextBox.Text = "";
            FechaAltaDTP.Text = "";
            FechaEnvioDTP.Text = "";
            NombreArchTextBox.Text = "";
            IdEstadoTextBox.Text = "";
            this.XMLWebBrowser.Navigate("about:blank");
            this.XMLIFWebBrowser.Navigate("about:blank");
            DetalleLoteDataGridView.DataSource = new List<eFact_R.Entidades.Comprobante>();
            CancelarButton.Visible = false;
            ConsultarLoteIFButton.Enabled = true;
        }
    }
}