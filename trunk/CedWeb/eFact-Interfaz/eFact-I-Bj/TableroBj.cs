using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace eFact_I_Bj
{
    public partial class TableroBj : Form
    {
        private List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes;
        private eFact_I_Bj.RN.TableroBj.TipoConsulta TipoConsulta;
        public TableroBj()
        {
            InitializeComponent();

            TipoConsulta = eFact_I_Bj.RN.TableroBj.TipoConsulta.Todos;
            StatusBar.Panels["UsuarioSBP"].Text = "Usuario: " + Aplicacion.Sesion.Usuario.Nombre;
            StatusBar.Panels["UsuarioSBP"].ToolTipText = "Información del usuario\r\nNombre:" + Aplicacion.Sesion.Usuario.Nombre;
            StatusBar.Panels["CXOSBP"].Text = "CXO: " + Aplicacion.Sesion.CXO;
            StatusBar.Panels["CXOSBP"].ToolTipText = "Control por oposición: " + Aplicacion.Sesion.CXO;
            StatusBar.Panels["OrigenDatosSBP"].ToolTipText = "Directorio de Datos: " + Aplicacion.ArchPath + "\r\n";
            Comprobantes = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            TipoConsulta = eFact_I_Bj.RN.TableroBj.TipoConsulta.ComprobantesAProcesar;
            ConsultaComprobantesDataGridView.AutoGenerateColumns = false;
            ConsultaComprobantesDataGridView.DataSource = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            if (Aplicacion.Testing)
            {
                TestingPanel.Visible = true;
            }
            //Cabecera
            IdTipoComprobanteComboBox.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaSinInf();
            IdTipoComprobanteComboBox.DisplayMember = "Descr";
            IdTipoComprobanteComboBox.ValueMember = "Codigo";

            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).DisplayMember = "Descr";
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).ValueMember = "Codigo";

            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdMoneda"]).DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdMoneda"]).DisplayMember = "Descr";
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdMoneda"]).ValueMember = "Codigo";
            
            DataGridViewComboBoxColumn colCompradorTipoDoc = new DataGridViewComboBoxColumn();
            colCompradorTipoDoc.DataSource = FeaEntidades.Documentos.Documento.Lista(); ;
            colCompradorTipoDoc.DisplayMember = "Descr";
            colCompradorTipoDoc.ValueMember = "Codigo";
            colCompradorTipoDoc.DataPropertyName = "CompradorTipoDoc";
            colCompradorTipoDoc.Name = "CompradorTipoDoc";
            colCompradorTipoDoc.FlatStyle = FlatStyle.Flat;
            colCompradorTipoDoc.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colCompradorTipoDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
            colCompradorTipoDoc.HeaderText = "Comprador Tipo Doc.";
            colCompradorTipoDoc.Width = 70;
            ConsultaComprobantesDataGridView.Columns.Add(colCompradorTipoDoc);
            DataGridViewTextBoxColumn colCompradorNroDoc = new DataGridViewTextBoxColumn();
            colCompradorNroDoc.DataPropertyName = "CompradorNroDoc";
            colCompradorNroDoc.Name = "CompradorNroDoc";
            colCompradorNroDoc.HeaderText = "Comprador Nro. Doc.";
            colCompradorNroDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCompradorNroDoc.Width = 100;
            ConsultaComprobantesDataGridView.Columns.Add(colCompradorNroDoc);
            DataGridViewTextBoxColumn colCompradorNombre = new DataGridViewTextBoxColumn();
            colCompradorNombre.DataPropertyName = "CompradorNombre";
            colCompradorNombre.Name = "CompradorNombre";
            colCompradorNombre.HeaderText = "Comprador Nombre";
            colCompradorNombre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCompradorNombre.Width = 400;
            ConsultaComprobantesDataGridView.Columns.Add(colCompradorNombre);
        }

        private void TableroBj_Load(object sender, EventArgs e)
        {
            DirectoryInfo di;
            if (!Directory.Exists(Aplicacion.ArchPath))
            {
                di = Directory.CreateDirectory(Aplicacion.ArchPath);
                MessageBox.Show("Se ha creado el repositorio para generar los archivos de interfaz, en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este directorio se generarán los archivos de interfaz con los comprobantes de Bejerman seleccionados, para que posteriormente puedan ser procesados y enviados a Interfacturas con el módulo eFact-R.");
            }
        }

        private void ActualizarConsultaCButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                eFact_I_Bj.RN.TableroBj.ConsultarComprobantes(out Comprobantes, TipoConsulta, FechaComprobantesDsdDTP.Value, FechaComprobantesHstDTP.Value, IdTipoComprobanteComboBox.SelectedValue.ToString(), PuntoVentaTextBox.Text, NumeroComprobanteTextBox.Text, TestingVerificarExistenciaCAECheckBox.Checked, Aplicacion.Sesion);
                ConsultaComprobantesDataGridView.DataSource = Comprobantes;
                if (Comprobantes.Count == 0)
                {
                    MessageBox.Show("No hay datos para la selección realizada.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        private void SalirButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LimpiarConsultaCButton_Click(object sender, EventArgs e)
        {
            Comprobantes = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            ConsultaComprobantesDataGridView.DataSource = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            ConsultaComprobantesDataGridView.Refresh();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\eFact-I-Bj-Ayuda.doc");
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            string sistema = ((System.Reflection.AssemblyDescriptionAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute), false)[0]).Description;
            string codigoSistema = ((System.Reflection.AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false)[0]).Title;
            Cedeira.UI.Mostrar.Acerca(sistema, codigoSistema, "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor, 0);
        }

        private void ConsultaComprobantesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ConsultaComprobantesDataGridView.SelectedRows.Count != 0)
                {
                    int renglon = ConsultaComprobantesDataGridView.SelectedRows[0].Index;
                    ConsultaComprobanteBj c = new ConsultaComprobanteBj(Comprobantes[renglon]);
                    c.ShowDialog();
                    c = null;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }

        private void GenerarArchivoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConsultaComprobantesDataGridView.SelectedRows.Count != 0)
                {


                    ////Actualizar lote
                    //ms = new MemoryStream();
                    //XmlizedString = null;
                    //writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                    //x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
                    //x.Serialize(writer, Lc);
                    //ms = (MemoryStream)writer.BaseStream;
                    //XmlizedString = RN.Tablero.ByteArrayToString(ms.ToArray());
                    //ms.Close();
                    //Lote.LoteXmlIF = XmlizedString;


                    int renglon = ConsultaComprobantesDataGridView.SelectedRows[0].Index;
                    string nombreProcesado = "";
                    eFact_I_Bj.DB.ComprobanteBj c = new eFact_I_Bj.DB.ComprobanteBj(Aplicacion.Sesion);
                    DateTime fechaYHora = c.FechaDB;
                    GenerarNombreArch(out nombreProcesado, Aplicacion.ArchPath, "Itf", fechaYHora, Comprobantes[renglon], "txt");
                    FileStream fs = File.Create(nombreProcesado);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<cabecera_lote>|" + fechaYHora.ToString("yyyyMMddhhmmss") + "|30690783521||" + Comprobantes[0].VendedorCuit + "|" + ConsultaComprobantesDataGridView.SelectedRows.Count);
                    //Presta servicios / Presta servicios especificado
                    sb.Append("|1|1");
                    sb.Append("|" + DateTime.Now.ToString("yyyyMMdd hhmmss"));
                    sb.AppendLine("|" + Comprobantes[0].PuntoVenta + "||");
                    for (int i = 0; i < ConsultaComprobantesDataGridView.SelectedRows.Count; i++)
                    {
                        sb.Append("<informacion_comprador>");
                        sb.Append("||0|");
                        string TipoDoc = "";
                        TipoDoc = Comprobantes[i].CompradorTipoDoc.ToString();
                        sb.Append("|" + TipoDoc + "|" + Comprobantes[i].CompradorNroDoc + "|" + Comprobantes[i].CompradorNombre);
                        //condicion de IVA + especificado + condicion IB + especificado
                        sb.Append("|" + Comprobantes[i].Comprador.CondicionIVA + "|1||0|||||||||||");
                        //Cod.Provincia
                        sb.Append("|" + Comprobantes[i].Comprador.Provincia);
                        sb.AppendLine("|||");
                        sb.Append("<informacion_comprobante>");
                        sb.Append("|" + Comprobantes[i].IdTipoComprobante.ToString() + "|" + Comprobantes[i].NumeroComprobante);
                        sb.Append("|" + Comprobantes[i].PuntoVenta + "|" + Comprobantes[i].Fecha.ToString("yyyyMMdd"));
                        sb.Append("|" + Comprobantes[i].FechaVto.ToString("yyyyMMdd"));
                        //Fecha de Servicios
                        sb.Append("|" + Comprobantes[i].Fecha.ToString("yyyyMMdd") + "|" + Comprobantes[i].Fecha.ToString("yyyyMMdd"));
                        //Condicion de pago
                        sb.Append("|0|0");
                        //IVA computable
                        sb.Append("|N");
                        //Cod.Operacion
                        sb.Append("|");
                        //CAE
                        sb.Append("|");
                        if (Comprobantes[i].NumeroCAE != "" && Comprobantes[i].NumeroCAE != "0")
                        {
                            sb.Append(Comprobantes[i].NumeroCAE);
                        }
                        //Fecha Vto. CAE
                        sb.Append("|");
                        if (Comprobantes[i].NumeroCAE != "" && Comprobantes[i].NumeroCAE != "0")
                        {
                            sb.Append(Comprobantes[i].FechaVtoCAE.ToString("yyyyMMdd"));
                        }
                        //Fecha Obtención CAE
                        sb.Append("|");
                        sb.AppendLine("|||N");
                        sb.Append("<informacion_vendedor>");
                        sb.Append("||0|");
                        sb.Append("|" + Comprobantes[i].Vendedor.Nombre + "|" + Comprobantes[i].VendedorCuit);
                        //condicion de IVA + especificado
                        sb.Append("|" + Comprobantes[i].Vendedor.CondicionIVA + "|1");
                        //condicion de IB + especificado + Nro. IB
                        sb.Append("|" + Comprobantes[i].Vendedor.CondicionIB + "|1" + "|" + Comprobantes[i].Vendedor.NroIB);
                        //fecha inicio de actividades + contacto
                        sb.Append("|" + Comprobantes[i].Vendedor.InicioActividades.ToString("yyyyMMdd") + "|" + Comprobantes[i].Vendedor.Contacto);
                        //datos de la empresa ( domicilio, mail, etc. )
                        sb.Append("|" + Comprobantes[i].Vendedor.DomicilioCalle + "|" + Comprobantes[i].Vendedor.DomicilioNumero);
                        sb.Append("|" + Comprobantes[i].Vendedor.DomicilioPiso + "|" + Comprobantes[i].Vendedor.DomicilioDepto + "|" + Comprobantes[i].Vendedor.DomicilioSector);
                        sb.Append("|" + Comprobantes[i].Vendedor.DomicilioTorre + "|" + Comprobantes[i].Vendedor.DomicilioManzana + "|" + Comprobantes[i].Vendedor.Localidad + "|" + Comprobantes[i].Vendedor.Provincia);
                        sb.AppendLine("|" + Comprobantes[i].Vendedor.CP + "|" + Comprobantes[i].Vendedor.EMail + "|" + Comprobantes[i].Vendedor.Telefono);
                        sb.AppendLine("<detalle>|");
                        //Lineas
                        for (int j = 0; j < Comprobantes[i].Lineas.Count; j++)
                        {
                            sb.Append("<linea>");
                            sb.Append("|0|0||");
                            sb.Append("|" + Comprobantes[i].Lineas[j].Descripcion + "|" + Comprobantes[i].Lineas[j].Cantidad + "|1");
                            //Unidad de medida
                            sb.Append("|" );
                            sb.Append("|" + Comprobantes[i].Lineas[j].Precio_unitario + "|1|" + Comprobantes[i].Lineas[j].Importe_total_articulo);
                            sb.Append("|" + Comprobantes[i].Lineas[j].Alicuota_iva + "|1|" + Comprobantes[i].Lineas[j].Importe_iva + "|1");
                            sb.Append("|" + Comprobantes[i].Lineas[j].Indicacion_exento_gravado);
                            sb.Append("|" + Comprobantes[i].Lineas[j].Importe_total_descuentos + "|1|" + Comprobantes[i].Lineas[j].Importe_total_impuestos + "|1");
                            sb.AppendLine("|" + Comprobantes[i].Lineas[j].Renglon);
                        }
                        sb.Append("<resumen>");
                        sb.Append("|" + Comprobantes[i].ImporteNetoGravado + "|" + Comprobantes[i].ImporteNetoNoGravado + "|" + Comprobantes[i].ImporteOpsExentas);
                        sb.Append("|" + Comprobantes[i].ImpuestoLiq + "|" + Comprobantes[i].ImpuestoRNI + "|" + Comprobantes[i].ImpuestosNacionales + "|1");
                        //Importe total IB
                        sb.Append("|0|0");
                        //Impuestos municipales
                        sb.Append("|0|0");
                        //Impuestos internos
                        sb.Append("|0|0");
                        //Importe total comprobante + tipo de cambio + moneda ( 'PES' va fijo )
                        sb.Append("|" + Comprobantes[i].Importe + "|1|" + Comprobantes[i].IdMoneda);
                        sb.Append("|");
                        sb.AppendLine("|" + Comprobantes[i].CantAlicuotasIVA + "|0");
                    }
                    System.Text.ASCIIEncoding oEncoder = new ASCIIEncoding();
                    Byte[] b = oEncoder.GetBytes(sb.ToString());
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    MessageBox.Show("Interfaz generada satisfactoriamente.\r\n\r\nNombre del archivo: " + nombreProcesado, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }

        private static void GenerarNombreArch(out string NombreArch, string Ruta, string Prefijo, DateTime FechayHora, eFact_I_Bj.Entidades.ComprobanteBj Comprobante, string Extension)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(Ruta);
            sb.Append(Prefijo);
            sb.Append("-");
            sb.Append(Comprobante.VendedorCuit);
            sb.Append("-");
            sb.Append(Comprobante.PuntoVenta);
            sb.Append("-");
            sb.Append(FechayHora.ToString("yyyyMMdd-hhmmss"));
            sb.Append("." + Extension);
            NombreArch = sb.ToString();
        }

        private void ConsultaComprobantesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string a = e.Exception.Message;
        }
    }
}