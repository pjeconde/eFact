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

namespace Gas
{
    public partial class ProcesarArchivoExcel : Form
    {
        public ProcesarArchivoExcel()
        {
            InitializeComponent();
			ProcesarButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlanillaCONFRadioButton.Checked == true)
                {
                    ProcesarConf();
                }
                else if (PlanillaASIGRadioButton.Checked == true)
                {
                    ProcesarAsig();
                }
                else
                {
                    ProcesarLiq();
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }

        private void ProcesarConf()
        {
            try
            {
                if (DirectorioEXCELTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar la planilla EXCEL.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (DirectorioXMLTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar el directorio para guardar los archivos XML.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                FileHelpers.DataLink.ExcelStorage fh = new FileHelpers.DataLink.ExcelStorage(typeof(Planilla1));
                fh.FileName = DirectorioEXCELTextBox.Text;
                fh.SheetName = NombreHojaCONFTextBox.Text;
                fh.StartRow = 2;
                fh.StartColumn = 1;
                Planilla1[] conf = (Planilla1[])fh.ExtractRecords();
                List<Planilla1> lconf = new List<Planilla1>();
                lconf.AddRange(conf);

                				//Crear clase completa para Hoja1
                AsigConf.dias_operativos dops = new AsigConf.dias_operativos();
				AsigConf.dias_operativosDia_operativo[] item = new AsigConf.dias_operativosDia_operativo[1];
				item[0] = new AsigConf.dias_operativosDia_operativo();
                item[0].fecha = conf[0].Fecha.ToString("dd/MM/yyyy");
				dops.Items = new AsigConf.dias_operativosDia_operativo[1];
				dops.Items[0] = item[0];

				int countVG = 1;
				string ultVG = conf[0].megid_contrato_gas;
				for (int i = 0; i < conf.Length; i++)
				{
					if (ultVG != conf[i].megid_contrato_gas)
					{
						ultVG = conf[i].megid_contrato_gas;
						countVG += 1;
					}
				}
				dops.Items[0].volumenes_gas = new AsigConf.dias_operativosDia_operativoVolumen_gas[countVG];
                AsigConf.dias_operativosDia_operativoVolumen_gas[] vgas = new AsigConf.dias_operativosDia_operativoVolumen_gas[countVG];
                int contadorLineaConf = 0;
				for (int i = 0; i < dops.Items[0].volumenes_gas.Length; i++)
				{

					vgas[i] = new AsigConf.dias_operativosDia_operativoVolumen_gas();
                    vgas[i].megid_contrato_gas = conf[contadorLineaConf].megid_contrato_gas;
					vgas[i].megid_tipo_balance = "DI";
					vgas[i].mov = "A";
					//Lista de Punto

					List<Planilla1> lp = lconf.FindAll(delegate(Planilla1 e1)
					{
						return e1.megid_contrato_gas == vgas[i].megid_contrato_gas;
					});
					AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO[] punto = new AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO[lp.Count];
					for (int j = 0; j < lp.Count; j++)
					{
						punto[j] = new AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO();
						punto[j].megid_punto_medicion = lp[j].megid_punto_medicion;
						punto[j].volumen = lp[j].volumen;
						punto[j].megid_motivo = "";
						punto[j].observaciones_motivo = "";
					}
                    if (contadorLineaConf > 0)
                    {
                        contadorLineaConf += lp.Count - 1;
                    }
					vgas[i].PUNTOS = punto;
					dops.Items[0].volumenes_gas = vgas;
                    contadorLineaConf += 1;
				}

				//Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
				MemoryStream ms = new MemoryStream();
				XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(dops.GetType());
				x.Serialize(writer, dops);
				ms = (MemoryStream)writer.BaseStream;
				string resp = ByteArrayToString(ms.ToArray());
				ms.Close();
				ms = null;

                //Grabar archivo en disco
                System.Text.Encoding codificador;
                codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                byte[] a = new byte[resp.Length];
                a = codificador.GetBytes(resp);
                string NombreArchivo = DirectorioXMLTextBox.Text + "\\" + NombreHojaCONFTextBox.Text + "-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xml";
                FileStream fs = File.Create(NombreArchivo);
                fs.Write(a, 0, a.Length);
                fs.Close();
                
                MessageBox.Show("Archivo XML procesado satisfactoriamente." + "\r\n\r\n" + "Nombre del Archivo: " + NombreArchivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo(ex);
            }
            finally
            {

            }
        }

        private void ProcesarAsig()
        {
            try
            {
                if (DirectorioEXCELTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar la planilla EXCEL.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (DirectorioXMLTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar el directorio para guardar los archivos XML.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
				FileHelpers.DataLink.ExcelStorage fh = new FileHelpers.DataLink.ExcelStorage(typeof(Planilla1));
                fh.FileName = DirectorioEXCELTextBox.Text;
                fh.SheetName = NombreHojaASIGTextBox.Text;
				fh.StartRow = 2;
				fh.StartColumn = 1;
				Planilla1[] asig = (Planilla1[])fh.ExtractRecords();
				List<Planilla1> lasig = new List<Planilla1>();
				lasig.AddRange(asig);

                //Crear clase completa para Hoja2
                AsigConf.dias_operativos dops = new AsigConf.dias_operativos();
                AsigConf.dias_operativosDia_operativo[] item = new AsigConf.dias_operativosDia_operativo[1];
                item[0] = new AsigConf.dias_operativosDia_operativo();
                item[0].fecha = asig[0].Fecha.ToString("dd/MM/yyyy");
                dops.Items = new AsigConf.dias_operativosDia_operativo[1];
                dops.Items[0] = item[0];

                int countVG = 1;
                string ultVG = asig[0].megid_contrato_gas;
                for (int i = 0; i < asig.Length; i++)
                {
                    if (ultVG != asig[i].megid_contrato_gas)
                    {
                        ultVG = asig[i].megid_contrato_gas;
                        countVG += 1;
                    }
                }
                dops.Items[0].volumenes_gas = new AsigConf.dias_operativosDia_operativoVolumen_gas[countVG];
                AsigConf.dias_operativosDia_operativoVolumen_gas[] vgas = new AsigConf.dias_operativosDia_operativoVolumen_gas[countVG];
                int contadorLineaConf = 0;
                for (int i = 0; i < dops.Items[0].volumenes_gas.Length; i++)
                {
                    vgas[i] = new AsigConf.dias_operativosDia_operativoVolumen_gas();
                    vgas[i].megid_contrato_gas = asig[contadorLineaConf].megid_contrato_gas;
                    vgas[i].megid_tipo_balance = "DI";
                    vgas[i].mov = "A";
                    //Lista de Punto

                    List<Planilla1> lp = lasig.FindAll(delegate(Planilla1 e1)
                    {
                        return e1.megid_contrato_gas == vgas[i].megid_contrato_gas;
                    });
                    AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO[] punto = new AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO[lp.Count];
                    for (int j = 0; j < lp.Count; j++)
                    {
                        punto[j] = new AsigConf.dias_operativosDia_operativoVolumen_gasPUNTO();
                        punto[j].megid_punto_medicion = lp[j].megid_punto_medicion;
                        punto[j].volumen = lp[j].volumen;
                        punto[j].megid_motivo = "";
                        punto[j].observaciones_motivo = "";
                    }
                    if (contadorLineaConf > 0)
                    {
                        contadorLineaConf += lp.Count - 1;
                    }
                    vgas[i].PUNTOS = punto;
                    dops.Items[0].volumenes_gas = vgas;
                    contadorLineaConf += 1;
                }

                //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
                MemoryStream ms = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(dops.GetType());
                x.Serialize(writer, dops);
                ms = (MemoryStream)writer.BaseStream;
                string resp = ByteArrayToString(ms.ToArray());
                ms.Close();
                ms = null;

                //Grabar archivo en disco
                System.Text.Encoding codificador;
                codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                byte[] a = new byte[resp.Length];
                a = codificador.GetBytes(resp);
                string NombreArchivo = DirectorioXMLTextBox.Text + "\\" + NombreHojaASIGTextBox.Text + "-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xml";
                FileStream fs = File.Create(NombreArchivo);
                fs.Write(a, 0, a.Length);
                fs.Close();

                MessageBox.Show("Archivo XML procesado satisfactoriamente." + "\r\n\r\n" + "Nombre del Archivo: " + NombreArchivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			}
			catch (Exception ex)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo(ex);
			}
			finally
			{
				
			}
        }

        private void ProcesarLiq()
        {
            try
            {
                if (DirectorioEXCELTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar la planilla EXCEL.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (DirectorioXMLTextBox.Text == "")
                {
                    MessageBox.Show("Seleccionar el directorio para guardar los archivos XML.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
				FileHelpers.DataLink.ExcelStorage fh = new FileHelpers.DataLink.ExcelStorage(typeof(Planilla2));
                fh.FileName = DirectorioEXCELTextBox.Text;
				fh.SheetName = NombreHojaLIQTextBox.Text;
				fh.StartRow = 2;
				fh.StartColumn = 1;
				Planilla2[] liq = (Planilla2[])fh.ExtractRecords();
                List<Planilla2> lliq = new List<Planilla2>();
                lliq.AddRange(liq);

                Liq.periodos_facturacion periodosF = new Liq.periodos_facturacion();
                Liq.periodo_facturacion pf = new Liq.periodo_facturacion();
                pf.fecha_desde = lliq[0].fecha_desde.ToString("dd/MM/yyyy");
                pf.fecha_hasta = lliq[0].fecha_hasta.ToString("dd/MM/yyyy");
                Liq.contratos contratos = new Liq.contratos();
                for (int i = 0; i < lliq.Count; i++)
                {
                    Liq.contrato c = new Liq.contrato();
                    c.mov = "A";
                    c.megid_contrato = lliq[i].megid_contrato_gas;
                    c.megid_moneda = lliq[i].megid_moneda;
                    Liq.conceptos_facturacion conceptosF = new Liq.conceptos_facturacion();
                    Liq.concepto_facturacion cf = new Liq.concepto_facturacion();
                    cf.megid_concepto_facturacion = lliq[i].concepto_facturacion;
                    cf.volumen = lliq[i].volumen;
                    cf.monto = lliq[i].monto;
                    cf.megid_entidad_medidora = "";
                    cf.megid_ruta = "";
                    cf.megid_tipo_medicion = "";
                    conceptosF.Add(cf);
                    c.conceptos_facturacionCollection.Add(conceptosF);
                    contratos.Add(c);
                }
                pf.contratosCollection.Add(contratos);
                periodosF.periodo_facturacionCollection.Add(pf);

                //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
                MemoryStream ms = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(periodosF.GetType());
                x.Serialize(writer, periodosF);
                ms = (MemoryStream)writer.BaseStream;
                string resp = ByteArrayToString(ms.ToArray());
                ms.Close();
                ms = null;

                //Grabar archivo en disco
                System.Text.Encoding codificador;
                codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                byte[] a = new byte[resp.Length];
                a = codificador.GetBytes(resp);
                string NombreArchivo = DirectorioXMLTextBox.Text + "\\" + NombreHojaLIQTextBox.Text + "-" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xml";
                FileStream fs = File.Create(NombreArchivo);
                fs.Write(a, 0, a.Length);
                fs.Close();

                MessageBox.Show("Archivo XML procesado satisfactoriamente." + "\r\n\r\n" + "Nombre del Archivo: " + NombreArchivo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo(ex);
            }
            finally
            {
                
            }
        }

		private void BuscarArchivoButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog xlsOpenFileDialog = new OpenFileDialog();
			
			xlsOpenFileDialog.Filter = "Archivos Excel (*.xls)|*.xls|Todos los archivos (*.*)|*.*";
			xlsOpenFileDialog.Multiselect = false;
			xlsOpenFileDialog.FilterIndex = 1;
			xlsOpenFileDialog.RestoreDirectory = true;

            if (xlsOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                DirectorioEXCELTextBox.Text = xlsOpenFileDialog.FileName;
                if (DirectorioXMLTextBox.Text != "")
                {
                    ProcesarButton.Enabled = true;
                }
            }
        }

        private void SeleccionarDirectorioButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directorio = new FolderBrowserDialog();
            if (directorio.ShowDialog() == DialogResult.OK)
            {
                DirectorioXMLTextBox.Text = directorio.SelectedPath;
                if (DirectorioEXCELTextBox.Text != "")
                {
                    ProcesarButton.Enabled = true;
                }
            }
        }
    }
}