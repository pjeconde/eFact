using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eFact_I_Bj
{
    public partial class TableroBj : Form
    {
        private List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes;
        private FeaEntidades.InterFacturas.lote_comprobantes Lc;
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
            Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            TipoConsulta = eFact_I_Bj.RN.TableroBj.TipoConsulta.ComprobantesAProcesar;
            ConsultaComprobantesDataGridView.AutoGenerateColumns = false;
            ConsultaComprobantesDataGridView.DataSource = new List<eFact_I_Bj.Entidades.ComprobanteBj>();
            if (Aplicacion.Testing)
            {
                TestingPanel.Visible = true;
            }
            //Cabecera
            IdTipoComprobanteComboBox.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
            IdTipoComprobanteComboBox.DisplayMember = "Descr";
            IdTipoComprobanteComboBox.ValueMember = "Codigo";

            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).DisplayMember = "Descr";
            ((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).ValueMember = "Codigo";
			((DataGridViewComboBoxColumn)ConsultaComprobantesDataGridView.Columns["IdTipoComprobante"]).DataPropertyName = "IdTipoComprobante";

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
			FechaComprobantesDsdDTP.Value = DateTime.Now;
			FechaComprobantesHstDTP.Value = DateTime.Now;
            TipoCambioLabel.Visible = true;
            ImporteDolaresLabel.Visible = true;
            TipoCambioTextBox.Visible = true;
            TipoCambioTextBox.Enabled = false;
            ImporteDolaresTextBox.Visible = true;
            ImporteDolaresTextBox.Enabled = false;
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
                eFact_I_Bj.RN.TableroBj.ConsultarComprobantes(out Comprobantes, out Lc, TipoConsulta, FechaComprobantesDsdDTP.Value, FechaComprobantesHstDTP.Value, IdTipoComprobanteComboBox.SelectedValue.ToString(), PuntoVentaTextBox.Text, NumeroComprobanteTextBox.Text, TestingVerificarExistenciaCAECheckBox.Checked, Aplicacion.Sesion);
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
            MessageBox.Show("No hay ayuda disponible.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\eFact-I-Bj-Ayuda.doc");
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
                    int renglon = ConsultaComprobantesDataGridView.SelectedRows[0].Index;
                    try
                    {
                        eFact_I_Bj.Entidades.Plantilla plantillaExpuesta = new eFact_I_Bj.Entidades.Plantilla();
                        Plantilla plantilla = new Plantilla(eFact_I_Bj.RN.Plantilla.Modo.Consulta, plantillaExpuesta);
                        plantilla.ShowDialog();
                        plantillaExpuesta = plantilla.plantillaExpuesta;
                        plantilla = null;
                        string observaciones = string.Empty;
                        if (plantillaExpuesta != null)
                        {
                            //foreach (eFact_I_Bj.Entidades.ComprobanteBj comprobante in Comprobantes)
                            //{
                                //if (Comprobantes[renglon].Leyendas[0].ToString() != string.Empty)
                                //{
                                //    string leyenda = Comprobantes[renglon].Leyendas[0].ToString();
                                //    observaciones = observaciones + plantillaExpuesta.Leyenda1 + " " + leyenda + " ";
                                //}
                                if (Comprobantes[renglon].Leyendas[1].ToString() != string.Empty)
                                {
                                    string leyenda = Comprobantes[renglon].Leyendas[1].ToString();
                                    observaciones = observaciones + plantillaExpuesta.Leyenda2 + " " + leyenda + " ";
                                }
                                if (Comprobantes[renglon].Leyendas[2].ToString() != string.Empty)
                                {
                                    string leyenda = Comprobantes[renglon].Leyendas[2].ToString();
                                    observaciones = observaciones + plantillaExpuesta.Leyenda3 + " " + leyenda + " ";
                                }
                                if (Comprobantes[renglon].Leyendas[3].ToString() != string.Empty)
                                {
                                    string leyenda = Comprobantes[renglon].Leyendas[3].ToString();
                                    observaciones = observaciones + plantillaExpuesta.Leyenda4 + " " + leyenda + " ";
                                }
                                if (Comprobantes[renglon].Leyendas[4].ToString() != string.Empty)
                                {
                                    string leyenda = Comprobantes[renglon].Leyendas[4].ToString();
                                    observaciones = observaciones + plantillaExpuesta.Leyenda5 + " " + leyenda + " ";
                                }
                                observaciones = observaciones + plantillaExpuesta.LeyendaMoneda + " " + " ";
                                Lc.comprobante[renglon].extensiones = new FeaEntidades.InterFacturas.extensiones();
                                Lc.comprobante[renglon].extensiones.extensiones_datos_comerciales = observaciones;
                                Lc.comprobante[renglon].extensionesSpecified = true;
                                Lc.comprobante[renglon].resumen.observaciones = plantillaExpuesta.LeyendaBanco;
                            //}
                        }
						if (FactServiciosCheckBox.Checked)
						{
							Lc.comprobante[renglon].cabecera.informacion_comprobante.fecha_serv_desde = FechaDsdServ.Value.ToString("yyyyMMdd");
							Lc.comprobante[renglon].cabecera.informacion_comprobante.fecha_serv_hasta = FechaHstServ.Value.ToString("yyyyMMdd");
							Lc.comprobante[renglon].cabecera.informacion_comprobante.codigo_conceptoSpecified = true;
							Lc.comprobante[renglon].cabecera.informacion_comprobante.codigo_concepto = 2;
						}
						if (FactDolarCheckBox.Checked)
						{
							string comentario = "Este documento se emite por el importe equivalente a USD "+ ImporteDolaresTextBox.Text +" al TC "+ TipoCambioTextBox.Text +" ARS/USD. De existir diferencia entre este tipo de cambio y el que corresponda al día anterior al pago efectivo, el pago se considerara hecho a cuenta y la diferencia generada deberá ser compensada mediante una ND/NC según corresponda a ser emitida por Gas Patagonia S.A.";
							Lc.comprobante[renglon].detalle.comentarios = comentario;
						}
                        
                        //Crear "lote_comprobantes"
                        string LoteXML;
                        //Metodo estático para el armado del Lote en formato XML, no necesita usar el constructor con la URL, proxy y certificados.
                        //Para Contingencias: El string LoteXML deberá guardarse en un archivo para se subido al Sitio Web de Interfacturas.
                        FeaEntidades.InterFacturas.lote_comprobantes lcComprobanteSelec = new FeaEntidades.InterFacturas.lote_comprobantes();
						lcComprobanteSelec.cabecera_lote = Lc.cabecera_lote;
						lcComprobanteSelec.cabecera_lote.cantidad_reg = 1;
                        lcComprobanteSelec.comprobante[0] = Lc.comprobante[renglon];
						if (plantillaExpuesta.DescrPlantilla.Equals("Diferencia de Cambio"))
						{
							for (int i = 1; i < lcComprobanteSelec.comprobante[0].detalle.linea.Length; i++)
							{
								if (lcComprobanteSelec.comprobante[0].detalle.linea[i] != null)
								{
									lcComprobanteSelec.comprobante[0].detalle.linea[i] = null;
								}
							}
							lcComprobanteSelec.comprobante[0].detalle.linea[0].cantidadSpecified = false;
							lcComprobanteSelec.comprobante[0].detalle.linea[0].precio_unitarioSpecified = false;
							lcComprobanteSelec.comprobante[0].detalle.linea[0].importe_ivaSpecified = false;
							lcComprobanteSelec.comprobante[0].detalle.linea[0].alicuota_ivaSpecified = false;
							lcComprobanteSelec.comprobante[0].detalle.linea[0].descripcion = string.Empty;
							if (lcComprobanteSelec.comprobante[0].resumen.codigo_moneda == "DOL")
							{
								lcComprobanteSelec.comprobante[0].detalle.linea[0].importe_total_articulo = lcComprobanteSelec.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado;
							}
							else
							{
								lcComprobanteSelec.comprobante[0].detalle.linea[0].importe_total_articulo = lcComprobanteSelec.comprobante[0].resumen.importe_total_neto_gravado;
							}

						}
						if (lcComprobanteSelec.comprobante[0].resumen.codigo_moneda == "DOL")
						{
							lcComprobanteSelec.comprobante[0].resumen.cant_alicuotas_ivaSpecified = false;
							lcComprobanteSelec.comprobante[0].resumen.importe_total_factura = 0;
							lcComprobanteSelec.comprobante[0].resumen.impuesto_liq = 0;
							lcComprobanteSelec.comprobante[0].resumen.importe_total_neto_gravado = 0;
							lcComprobanteSelec.comprobante[0].resumen.importe_total_concepto_no_gravado = 0;
							lcComprobanteSelec.comprobante[0].resumen.impuesto_liq_rni = 0;
							lcComprobanteSelec.comprobante[0].resumen.importe_operaciones_exentas = 0;

						}
						lcComprobanteSelec.cabecera_lote.id_lote = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
						lcComprobanteSelec.cabecera_lote.fecha_envio_lote = DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HHmmss");
                        LoteXML = ArmarLoteXML(lcComprobanteSelec);
                        //Definir ruta y nombre del archivo.
						string archPath = System.Configuration.ConfigurationManager.AppSettings["ArchPath"];
                        FileStream fs = File.Create(@archPath + "\\efact-c-contingencia.xml");
                        System.Text.Encoding codificador;
                        codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                        fs.Write(codificador.GetBytes(LoteXML), 0, LoteXML.Length);
                        fs.Close();
                        MessageBox.Show("Lote XML generado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
                        //Guardar el ex.InnerException si tiene contenido para tener mas detalle del problema.
                    }
                    //Actualizar lote
                    //ms = new MemoryStream();
                    //XmlizedString = null;
                    //writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                    //x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
                    //x.Serialize(writer, Lc);
                    //ms = (MemoryStream)writer.BaseStream;
                    //XmlizedString = RN.Tablero.ByteArrayToString(ms.ToArray());
                    //ms.Close();
                    //Lote.LoteXmlIF = XmlizedString;
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
        private string ArmarLoteXML(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            string LoteXML = ByteArrayToString(ms.ToArray());
            ms.Close();
            return LoteXML;
        }
        private string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Plantilla plantilla = new Plantilla(eFact_I_Bj.RN.Plantilla.Modo.Alta);
            plantilla.ShowDialog();
            plantilla = null;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Plantilla plantilla = new Plantilla(eFact_I_Bj.RN.Plantilla.Modo.Modificacion);
            plantilla.ShowDialog();
            plantilla = null;
        }

		private void FactServiciosCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (FactServiciosCheckBox.Checked)
			{
				FechaDsdServ.Enabled = true;
				FechaDsdServ.Visible = true;
				FechaHstServ.Enabled = true;
				FechaHstServ.Visible = true;
			}
			else
			{
				FechaDsdServ.Enabled = false;
				FechaDsdServ.Visible = true;
				FechaHstServ.Enabled = false;
				FechaHstServ.Visible = true;
			}
		}

		private void FactDolarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (FactDolarCheckBox.Checked)
			{
				TipoCambioTextBox.Enabled = true;
				TipoCambioTextBox.Visible = true;
				ImporteDolaresTextBox.Enabled = true;
				ImporteDolaresTextBox.Visible = true;
			}
			else
			{
				TipoCambioTextBox.Enabled = false;
				TipoCambioTextBox.Visible = true;
				ImporteDolaresTextBox.Enabled = false;
				ImporteDolaresTextBox.Visible = true;
			}
		}
    }
}