﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace eFact_R_XL
{
    public partial class Tablero : Form
    {
		string d;
		public Tablero()
        {
			InitializeComponent();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
			FolderBrowserDialog directorio = new FolderBrowserDialog();
			if (directorio.ShowDialog() == DialogResult.OK)
			{
				d = directorio.SelectedPath;
			}
        }

		private void ExcelButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog xlsOpenFileDialog = new OpenFileDialog();

			xlsOpenFileDialog.Filter = "Archivos Excel (*.xls)|*.xls|Todos los archivos (*.*)|*.*";
			xlsOpenFileDialog.Multiselect = false;
			xlsOpenFileDialog.FilterIndex = 1;
			xlsOpenFileDialog.RestoreDirectory = true;

			if (xlsOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string archivo = xlsOpenFileDialog.FileName;
					FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
					FeaEntidades.InterFacturas.cabecera compcab = new FeaEntidades.InterFacturas.cabecera();
					FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
					comp.cabecera = compcab;
					lote.comprobante[0] = comp;

					List<FeaEntidades.Excel.Ubicador> lista = FeaEntidades.Excel.Ubicador.Lista();
					foreach (FeaEntidades.Excel.Ubicador u in lista)
					{
						FileHelpers.DataLink.ExcelStorage provider = new FileHelpers.DataLink.ExcelStorage(u.GetType());
						provider.StartRow = u.X;
						provider.StartColumn = u.Y;
						provider.FileName = @archivo;
						provider.SheetName = "XML";
						Object[] oArray = (Object[])System.Array.CreateInstance(u.GetType(), 10);
						oArray = (Object[])provider.ExtractRecords();

						foreach (Object o in oArray)
						{
							FileHelpers.DataLink.ExcelStorage providerInterno = new FileHelpers.DataLink.ExcelStorage(System.Type.GetType("FeaEntidades.InterFacturas." + ((FeaEntidades.Excel.Ubicador)o).Tipo + ", FeaEntidades"));
							providerInterno.StartRow = ((FeaEntidades.Excel.Ubicador)o).Y;
							providerInterno.StartColumn = ((FeaEntidades.Excel.Ubicador)o).X;
							providerInterno.FileName = @archivo;
							providerInterno.SheetName = "XML";
							Object[] oArrayInterno = (Object[])System.Array.CreateInstance(System.Type.GetType("FeaEntidades.InterFacturas." + ((FeaEntidades.Excel.Ubicador)o).Tipo + ", FeaEntidades"), 10);
							oArrayInterno = (Object[])providerInterno.ExtractRecords();

							if (oArrayInterno.Length > 0)
							{
								switch (oArrayInterno.GetType().ToString())
								{
									case "FeaEntidades.InterFacturas.cabecera_lote[]":
										lote.cabecera_lote = (FeaEntidades.InterFacturas.cabecera_lote)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.informacion_comprador[]":
										compcab.informacion_comprador = (FeaEntidades.InterFacturas.informacion_comprador)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.informacion_comprobante[]":
										compcab.informacion_comprobante = (FeaEntidades.InterFacturas.informacion_comprobante)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.informacion_comprobanteReferencias[]":
										compcab.informacion_comprobante.referencias = (FeaEntidades.InterFacturas.informacion_comprobanteReferencias[])oArrayInterno;
										break;
									case "FeaEntidades.InterFacturas.informacion_vendedor[]":
										compcab.informacion_vendedor = (FeaEntidades.InterFacturas.informacion_vendedor)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.detalle[]":
										comp.detalle = (FeaEntidades.InterFacturas.detalle)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.linea[]":
										comp.detalle.linea = (FeaEntidades.InterFacturas.linea[])oArrayInterno;
										break;
									case "FeaEntidades.InterFacturas.lineaImportes_moneda_origen[]":
										break;
									case "FeaEntidades.InterFacturas.lineaImpuestos[]":
										break;
									case "FeaEntidades.InterFacturas.lineaDescuentos[]":
										break;
									case "FeaEntidades.InterFacturas.resumen[]":
										comp.resumen = (FeaEntidades.InterFacturas.resumen)oArrayInterno[0];
										break;
									case "FeaEntidades.InterFacturas.resumenDescuentos[]":
										comp.resumen.descuentos = (FeaEntidades.InterFacturas.resumenDescuentos[])oArrayInterno;
										break;
									case "FeaEntidades.InterFacturas.resumenImportes_moneda_origen[]":
										break;
									case "FeaEntidades.InterFacturas.resumenImpuestos[]":
                                        FeaEntidades.InterFacturas.resumenImpuestos[] impLista = ((FeaEntidades.InterFacturas.resumenImpuestos[])oArrayInterno);
                                        FeaEntidades.InterFacturas.resumenImpuestos[] impNewLista = new FeaEntidades.InterFacturas.resumenImpuestos[10];
                                        for (int im = 0; im < impLista.Length; im++)
                                        {
                                            if (impLista[im].importe_impuesto != 0)
                                            {
                                                impNewLista[im] = impLista[im];
                                            }
                                        }
                                        comp.resumen.impuestos = impNewLista;
        								break;
								}
							}
						}
					}

					System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					if (d != null)
					{
						sb.Append(@d);
						sb.Append(System.IO.Path.DirectorySeparatorChar);
					}
					else
					{
						throw new Exception("Debe elegir un directorio primero");
					}
					sb.Append(lote.cabecera_lote.cuit_vendedor);
					sb.Append("-");
					sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
					sb.Append("-");
					sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
					sb.Append("-");
					sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
					sb.Append(".xml");
					System.IO.Stream fs = new System.IO.FileStream(sb.ToString(), System.IO.FileMode.Create);
					System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(fs, System.Text.Encoding.GetEncoding("ISO-8859-1"));
					x.Serialize(writer, lote);
					fs.Close();
					System.Diagnostics.Process.Start(sb.ToString());
				}
				catch(NullReferenceException)
				{
					try
					{
						throw new Exception("El archivo seleccionado no está generado desde el template excel");
					}
					catch (Exception exc)
					{
						Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(exc);
					}
				}
				catch (Exception ex)
				{
					Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
				}
			}
		}

		private void XLTbutton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("Templates\\eFact-Serv-Pesos-SP-xls10-v1.0.xlt");
		}
    }
}