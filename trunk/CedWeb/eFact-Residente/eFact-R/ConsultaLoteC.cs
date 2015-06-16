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
    public partial class ConsultaLoteC : Form
    {
        private eFact_Entidades.Lote lote;

        public ConsultaLoteC(eFact_Entidades.Lote Lote)
        {
            InitializeComponent();
            lote = Lote;
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

                DataGridViewComboBoxColumn colTipoDocVendedor = (DataGridViewComboBoxColumn)DetalleLoteDataGridView.Columns["TipoDocVendedor"];
                colTipoDocVendedor.DataSource = FeaEntidades.Documentos.Documento.Lista();
                colTipoDocVendedor.DisplayMember = "Descr";
                colTipoDocVendedor.ValueMember = "Codigo";
                colTipoDocVendedor.DataPropertyName = "TipoDocVendedor";
                colTipoDocVendedor.HeaderText = "Tipo Doc. Vendedor";

                DataGridViewComboBoxColumn colIdMoneda = (DataGridViewComboBoxColumn)DetalleLoteDataGridView.Columns["IdMoneda"];
                colIdMoneda.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
                colIdMoneda.DisplayMember = "Descr";
                colIdMoneda.ValueMember = "Codigo";
                colIdMoneda.DataPropertyName = "IdMoneda";
                colIdMoneda.HeaderText = "Mon.";

                BindingControles();
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
        private static int ordenarPorNroComprobanteC(eFact_Entidades.ComprobanteC A1, eFact_Entidades.ComprobanteC A2)
        {
            return Convert.ToInt32(A1.NroDocVendedor.ToString().Trim() + A1.NumeroComprobante.PadLeft(8, Convert.ToChar("0"))).CompareTo(Convert.ToInt32(A2.NroDocVendedor.ToString().Trim() + A2.NumeroComprobante.PadLeft(8, Convert.ToChar("0"))));
        }
        private static int ordenarPorNroComprobanteD(eFact_Entidades.ComprobanteD A1, eFact_Entidades.ComprobanteD A2)
        {
            return Convert.ToInt32(A1.NroDocVendedor.ToString().Trim()).CompareTo(Convert.ToInt32(A2.NroDocVendedor.ToString().Trim()));
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
            CantidadRegistrosTextBox.DataBindings.Clear();
            CantidadRegistrosTextBox.DataBindings.Add("Text", lote, "CantidadRegistros");
            FechaAltaDTP.DataBindings.Clear();
            FechaAltaDTP.DataBindings.Add("Value", lote, "FechaAlta");
            NombreArchTextBox.DataBindings.Clear();
            NombreArchTextBox.DataBindings.Add("Text", lote, "NombreArch");
            IdEstadoTextBox.DataBindings.Clear();
            IdEstadoTextBox.DataBindings.Add("Text", lote, "IdEstado");

            LogLoteDataGridView.AutoGenerateColumns = false;
            LogLoteDataGridView.DataSource = new List<CedEntidades.Evento>();
            LogLoteDataGridView.DataSource = lote.WF.Log;
            eFact_RN.Lote.MuestroEsquemaSegEventosPosibles(EsquemaSegEventosPosiblesTreeView, lote);
            LogLoteDataGridView.Refresh();

            DetalleLoteDataGridView.AutoGenerateColumns = false;
            DetalleLoteDataGridView.DataSource = new List<eFact_Entidades.Comprobante>();
            lote.ComprobantesC.Sort(ordenarPorNroComprobanteC);
            DetalleLoteDataGridView.DataSource = lote.ComprobantesC;
            DetalleLoteDataGridView.Refresh();

            DespachosDataGridView.AutoGenerateColumns = false;
            DespachosDataGridView.DataSource = new List<eFact_Entidades.Comprobante>();
            lote.ComprobantesD.Sort(ordenarPorNroComprobanteD);
            DespachosDataGridView.DataSource = lote.ComprobantesD;
            DespachosDataGridView.Refresh();
            if (lote.ComprobantesD == null || lote.ComprobantesD.Count == 0)
            {
                TabControl.TabPages.Remove(TabControl.TabPages[1]);
            }

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
                    long t = fileWriter.BaseStream.Length;
                    fileWriter.Close();
                    if (t < 3000000)
                    {
                        XMLWebBrowser.Navigate(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XML.xml");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Solapa XML Origen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                c.Dispose();
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

        private void DetalleLoteDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ConsultarLote();
        }

        private void ConsultarLote()
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (DetalleLoteDataGridView.SelectedRows.Count != 0)
                {
                    eFact_Entidades.Comprobante c = new eFact_Entidades.Comprobante();
                    int renglon = DetalleLoteDataGridView.SelectedRows[0].Index;
                    ComentariosXComprobante cxc = new ComentariosXComprobante("Sin comentarios");
                    cxc.ShowDialog();
                    cxc.Dispose();
                }
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
    }
}