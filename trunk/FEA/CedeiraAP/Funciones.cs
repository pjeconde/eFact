using System;
using System.Data;
using System.Runtime.Serialization; 
using Cedeira.SV;
namespace Cedeira.SV 
{
	public class Fun {
		public static void VerifCUIT (string CUIT) {
			if (CUIT.Length!=11 || !IsNumeric(CUIT) || CUIT=="00000000000") {
				throw new Cedeira.Ex.Validaciones.ValorInvalido("CUIT/CUIL");
			}
			int sum=0;
			for (int i=0; i<CUIT.Length;i++) {
				sum+=Convert.ToInt32(CUIT.Substring(i,1))*Convert.ToInt32("54327654321".Substring(i,1));
			}
			if ((sum % 11)!=0) {
				throw new Cedeira.Ex.Validaciones.ValorInvalido("CUIT/CUIL");
			}
		}
		public static void VerifCBU (string CBU) {
			//             Bloque1   Bloque2
			//Formato CBU: 7-1       13-1      (22 digitos totales)
			if (CBU.Length!=22 || !IsNumeric(CBU) || CBU=="0000000000000000000000") {
				throw new Cedeira.Ex.Validaciones.ValorInvalido("CBU");
			}
            string Bloque1="0"+CBU.Substring(0,7);
            int Digito1=Convert.ToInt32(CBU.Substring(7,1));
            string Bloque2="000"+CBU.Substring(8,13);
            int Digito2=Convert.ToInt32(CBU.Substring(21,1));
			int sum;
			string sumString;
			// Verifico Bloque 1
			sum=0;
			for (int i=0; i<Bloque1.Length;i++) {
				sum+=Convert.ToInt32(Bloque1.Substring(i,1))*Convert.ToInt32("97139713".Substring(i,1));
			}
			sumString=sum.ToString();
			sum=Convert.ToInt32(sumString.Substring(sumString.Length-1,1));
			sum=10-sum;
			sumString=sum.ToString();
			sum=Convert.ToInt32(sumString.Substring(sumString.Length-1,1));
			if (sum!=Digito1) {
				throw new Cedeira.Ex.Validaciones.ValorInvalido("CBU");
			}
			else {
				// Verifico Bloque 2
				sum=0;
				for (int i=0; i<Bloque2.Length;i++) {
					sum+=Convert.ToInt32(Bloque2.Substring(i,1))*Convert.ToInt32("9713971397139713".Substring(i,1));
				}
				sumString=sum.ToString();
				sum=Convert.ToInt32(sumString.Substring(sumString.Length-1,1));
				sum=10-sum;
				sumString=sum.ToString();
				sum=Convert.ToInt32(sumString.Substring(sumString.Length-1,1));
				if (sum!=Digito2) {
					throw new Cedeira.Ex.Validaciones.ValorInvalido("CBU");
				}
			}
		}
		public static bool IsNumeric(string value) {
			for (int i=0;i<value.Length;i++) {
				if (char.Parse(value.Substring(i,1))<char.Parse("0") || char.Parse(value.Substring(i,1))>char.Parse("9")) {
					return false;
				}
			}
			return true;
		}	
		public static void IsNumericCheck(string value) {
			for (int i=0;i<value.Length;i++) {
				if (char.Parse(value.Substring(i,1))<char.Parse("0") || char.Parse(value.Substring(i,1))>char.Parse("9")) {
					throw new Cedeira.Ex.Validaciones.ValorNegativo(value);
				}
			}
		}	
		public static DataTable Compl(DataTable dt) {
			try {
				DataRow dr=dt.NewRow();
				switch (dt.Columns[0].DataType.FullName) {
					case "System.Byte":
					case "System.Int32":
						dr[0]=0;
						break;
					case "System.String":
						dr[0]="";
						break;
					default:
						System.Diagnostics.Debugger.Break();
						dr[0]="";
						break;
				}
				dr[1]="(sin informar)";
				dt.Rows.InsertAt(dr,0);
				dt.AcceptChanges();
				dt.DefaultView.Sort=dt.Columns[1].ColumnName;
				dr=null;
				return dt;
			}
			catch {
				throw new Cedeira.Ex.Validaciones.ValorInvalido("CBU");
			}
		}

		public static DataTable NuevaFilaCombos(DataTable dt, int id, string descr) 
		{
			DataRow dr=dt.NewRow();
			dr["Id"]=id;
			dr["Descr"]=descr;
			dt.Rows.InsertAt(dr,0);
			dt.AcceptChanges();
			dr=null;
			return dt;
		}

		public static void VerifAladi(string cod)
		{
			if (cod.Trim().Length < 13 || cod.Trim().Length > 127)
			{
				throw new Cedeira.Ex.Validaciones.ValorInvalido("Codigo de reembolso Sicap-Aladi");
			}
			int suma = 0;
			System.String digitos = cod.Trim().Substring(0, (12) - (0));
			sbyte multi = 1;
			int resul = 0;
			for (int i = 0; i <= digitos.Length - 1; i++)
			{
				resul = System.Int32.Parse(digitos.Substring(i, (i + 1) - (i))) * multi;
				if (resul >= 10)
					resul = System.Int32.Parse(resul.ToString().Substring(0, (1) - (0))) + System.Int32.Parse(resul.ToString().Substring(1, (2) - (1)));
				suma += resul;
				if (multi == 1)
					multi = 2;
				else
					multi = 1;
			}
				
			resul = 10 - System.Int32.Parse(suma.ToString().Trim().Substring(suma.ToString().Trim().Length - 1, (suma.ToString().Trim().Length) - (suma.ToString().Trim().Length - 1)));

			if(!(resul.ToString().Equals(cod.Substring(12, (13) - (12))) || resul == 10))
			{
				throw new Cedeira.Ex.Validaciones.ValorInvalido("Codigo de reembolso Sicap-Aladi");
			}
		}
		public static bool Habilitado(string IdCampo, DataTable CamposHabilitados) 
		{
			try 
			{
				string a=CamposHabilitados.Columns[IdCampo].ColumnName;
				return true;
			}
			catch 
			{
				return false;
			}
		}
		public static void ImprimirGrilla(Cedeira.UI.frmBase Formulario, Janus.Windows.GridEX.GridEX Grilla, string TituloAplicacion, bool Apaisada)
		{
			ImprimirGrilla(Formulario, Grilla, TituloAplicacion, Apaisada, Janus.Windows.GridEX.FitColumnsMode.Zooming);
		}
		public static void ImprimirGrilla(Cedeira.UI.frmBase Formulario, Janus.Windows.GridEX.GridEX Grilla, string TituloAplicacion, bool Apaisada, Janus.Windows.GridEX.FitColumnsMode ModoAjusteColumnas)
		{
			try 
			{
				Formulario.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument=new Janus.Windows.GridEX.GridEXPrintDocument();
				foreach (System.Drawing.Printing.PaperSize ps in gridEXPrintDocument.PrinterSettings.PaperSizes)
				{
					if (ps.Kind == System.Drawing.Printing.PaperKind.Letter)
					{
						gridEXPrintDocument.DefaultPageSettings.PaperSize=ps;
						break;
					}
				}				
				gridEXPrintDocument.ExpandFarColumn=false;
				gridEXPrintDocument.DefaultPageSettings.Landscape=Apaisada;
				gridEXPrintDocument.DefaultPageSettings.Margins.Bottom=90;
				gridEXPrintDocument.DefaultPageSettings.Margins.Top=30;
				gridEXPrintDocument.DefaultPageSettings.Margins.Left=10;
				gridEXPrintDocument.DefaultPageSettings.Margins.Right=70;
				gridEXPrintDocument.HeaderDistance=15;
				gridEXPrintDocument.FitColumns=ModoAjusteColumnas;
				gridEXPrintDocument.PageHeaderFormatStyle.FontBold=Janus.Windows.GridEX.TriState.True;
				gridEXPrintDocument.PageHeaderLeft=TituloAplicacion;
				gridEXPrintDocument.PageHeaderCenter=Formulario.Titulo;
				gridEXPrintDocument.PageHeaderRight=System.DateTime.Now.ToString();
				gridEXPrintDocument.PrintCollapsedRows=true;
				gridEXPrintDocument.DocumentName=Formulario.Text;
				gridEXPrintDocument.GridEX=Grilla;
				gridEXPrintDocument.PrepareDocument();
				Fun f=new Fun();
				gridEXPrintDocument.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(f.PrepararNroPaginas);
				gridEXPrintDocument.Print();
			}
			catch (System.Exception ex) 
			{
				Cedeira.Ex.ExceptionManager.Publish(ex);
			}
			finally 
			{
				Formulario.Cursor=System.Windows.Forms.Cursors.Default;
			}
		}
		public void PrepararNroPaginas(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			((Janus.Windows.GridEX.GridEXPrintDocument)sender).PrinterSettings.FromPage=((Janus.Windows.GridEX.GridEXPrintDocument)sender).Page;
			((Janus.Windows.GridEX.GridEXPrintDocument)sender).PrinterSettings.ToPage=((Janus.Windows.GridEX.GridEXPrintDocument)sender).TotalPages;
			((Janus.Windows.GridEX.GridEXPrintDocument)sender).PageFooterCenter = "P�gina " + ((Janus.Windows.GridEX.GridEXPrintDocument)sender).Page + " de " + ((Janus.Windows.GridEX.GridEXPrintDocument)sender).TotalPages;
		}
		public static void ImprimirGrillaReporte(Cedeira.UI.frmBase Formulario, Janus.Windows.GridEX.GridEX Grilla, string TituloAplicacion, bool Apaisada, Janus.Windows.GridEX.FitColumnsMode ModoAjusteColumnas, DateTime Fecha)
		{
			try 
			{
				Formulario.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				Janus.Windows.GridEX.GridEXPrintDocument gridEXPrintDocument=new Janus.Windows.GridEX.GridEXPrintDocument();
				foreach (System.Drawing.Printing.PaperSize ps in gridEXPrintDocument.PrinterSettings.PaperSizes)
				{
					if (ps.Kind == System.Drawing.Printing.PaperKind.Letter)
					{
						gridEXPrintDocument.DefaultPageSettings.PaperSize=ps;
						break;
					}
				}				
				gridEXPrintDocument.ExpandFarColumn=false;
				gridEXPrintDocument.DefaultPageSettings.Landscape=Apaisada;
				gridEXPrintDocument.DefaultPageSettings.Margins.Bottom=60;
				gridEXPrintDocument.DefaultPageSettings.Margins.Top=30;
				gridEXPrintDocument.DefaultPageSettings.Margins.Left=10;
				gridEXPrintDocument.DefaultPageSettings.Margins.Right=70;
				gridEXPrintDocument.HeaderDistance=15;
				gridEXPrintDocument.FitColumns=ModoAjusteColumnas;
				gridEXPrintDocument.PageHeaderFormatStyle.FontBold=Janus.Windows.GridEX.TriState.True;
				gridEXPrintDocument.PageHeaderLeft=TituloAplicacion;
				gridEXPrintDocument.PageHeaderCenter=Formulario.Titulo;
				gridEXPrintDocument.PageHeaderRight=Fecha.ToString("d");
				gridEXPrintDocument.PrintCollapsedRows=true;
				gridEXPrintDocument.DocumentName=Formulario.Text;
				gridEXPrintDocument.GridEX=Grilla;
				gridEXPrintDocument.PrepareDocument();
				gridEXPrintDocument.Print();
			}
			catch (System.Exception ex) 
			{
				Cedeira.Ex.ExceptionManager.Publish(ex);
			}
			finally 
			{
				Formulario.Cursor=System.Windows.Forms.Cursors.Default;
			}
		}
		/// <summary>
		/// 	Devuelve un DataTable de un GridEx
		/// </summary>
		/// <param name="JanusGridEx"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static DataSet GetDataSetFromJanusGridEx(Janus.Windows.GridEX.GridEX JanusGridEx, string tableName)
		{
			DataSet JanusDataSet = new DataSet();
			DataTable JanusDataTable = new DataTable(tableName);
			DataRow JanusDataRow = null;		
			Janus.Windows.GridEX.GridEXRow[] JanusRows;
			JanusRows = JanusGridEx.GetRows();
			int columnas = JanusGridEx.RootTable.Columns.Count;
			if(JanusGridEx.GroupTotals==Janus.Windows.GridEX.GroupTotals.Never)
			{
				for(int q=0;q<columnas;q++)
				{
					if(JanusGridEx.RootTable.Columns[q].Visible==true)
					{
						Janus.Windows.GridEX.GridEXColumn gec=JanusGridEx.RootTable.Columns[q];
						System.Data.DataColumn dc=new DataColumn();
						dc.ColumnName=gec.Key;
						dc.Caption=gec.Caption;
						if(!JanusDataTable.Columns.Contains(gec.Key))
						{
							JanusDataTable.Columns.Add(dc);
						}
					}
				}	
				JanusDataTable.AcceptChanges();
				for(int registros=0;registros<JanusGridEx.RowCount;registros++)
				{						
					JanusDataRow = JanusDataTable.NewRow();
					for(int counter=0;counter<columnas;counter++)
					{
						string columna=Convert.ToString(JanusGridEx.RootTable.Columns[counter].Key);
						if(EsFilaDeAgrupamiento(JanusGridEx.GetRow(registros)))
						{
							string auxValor=Convert.ToString(JanusGridEx.GetRow(registros).GroupValue);
							auxValor+=Convert.ToString(JanusDataRow[0]);
                            if (JanusGridEx.GetRow(registros).GroupValue != null && JanusGridEx.GetRow(registros).GroupValue.GetType() == System.Type.GetType("System.DateTime"))
                            {
                                JanusDataRow[0] = ((DateTime)JanusGridEx.GetRow(registros).GroupValue).ToString("MM/dd/yyyy") + Convert.ToString(JanusDataRow[0]);
                            }
                            else
                            {
                                JanusDataRow[0] = auxValor;
                            }
							break;
						}
						else if(JanusGridEx.RootTable.Columns[columna].Visible==true)
						{
                            if (JanusGridEx.GetRow(registros).Cells[columna].Value != null && JanusGridEx.GetRow(registros).Cells[columna].Value.GetType() == System.Type.GetType("System.DateTime"))
                            {
                                JanusDataRow[columna] = ((DateTime)JanusGridEx.GetRow(registros).Cells[columna].Value).ToString("MM/dd/yyyy");
                            }
                            else
                            {
                                JanusDataRow[columna] = JanusGridEx.GetRow(registros).Cells[columna].Text;
                            }
						}
					}
					JanusDataTable.Rows.Add(JanusDataRow);
					JanusDataTable.AcceptChanges();
				}				
			}
			else
			{
				for(int q=0;q<columnas;q++)
				{
					if(JanusGridEx.RootTable.Columns[q].Visible==true)
					{
						Janus.Windows.GridEX.GridEXColumn gec=JanusGridEx.RootTable.Columns[q];
						System.Data.DataColumn dc=new DataColumn();
						dc.ColumnName=gec.Key;
						dc.Caption=gec.Caption;
						if(!JanusDataTable.Columns.Contains(gec.Key))
						{
							JanusDataTable.Columns.Add(dc);
						}
					}
				}	
				JanusDataTable.AcceptChanges();
				for(int registros=0;registros<JanusGridEx.RowCount;registros++)
				{						
					JanusDataRow = JanusDataTable.NewRow();
					for(int counter=0;counter<columnas;counter++)
					{
						string columna=Convert.ToString(JanusGridEx.RootTable.Columns[counter].Key);
						if(EsFilaDeAgrupamiento(JanusGridEx.GetRow(registros)))
						{
							string auxValor=Convert.ToString(JanusGridEx.GetRow(registros).GroupValue);
							auxValor+=Convert.ToString(JanusDataRow[0]);
                            if (JanusGridEx.GetRow(registros).GroupValue != null && JanusGridEx.GetRow(registros).GroupValue.GetType() == System.Type.GetType("System.DateTime"))
                            {
                                JanusDataRow[0] = ((DateTime)JanusGridEx.GetRow(registros).GroupValue).ToString("MM/dd/yyyy") + Convert.ToString(JanusDataRow[0]); 
                            }
                            else
                            {
                                JanusDataRow[0] = auxValor;
                            }
							break;
						}
						else if(JanusGridEx.RootTable.Columns[columna].Visible==true)
						{
                            if (JanusGridEx.GetRow(registros).Cells[columna].Value != null && JanusGridEx.GetRow(registros).Cells[columna].Value.GetType() == System.Type.GetType("System.DateTime"))
                            {
                                JanusDataRow[columna] = ((DateTime)JanusGridEx.GetRow(registros).Cells[columna].Value).ToString("MM/dd/yyyy");
                            }
                            else
                            {
                                JanusDataRow[columna] = JanusGridEx.GetRow(registros).Cells[columna].Text;
                            }
						}
					}
					JanusDataTable.Rows.Add(JanusDataRow);
					JanusDataTable.AcceptChanges();
				}				
			}
			JanusDataSet.Tables.Add(JanusDataTable);
			return JanusDataSet;
		}
		private static bool EsFilaDeAgrupamiento(Janus.Windows.GridEX.GridEXRow fila)
		{
			for(int i=0;i<fila.Cells.Count;i++)
			{
				string aux=Convert.ToString(fila.Cells[i].Text);
				if(!aux.Equals(string.Empty))
				{
					return false;
				}
			}
			return true;
		}
		public static void VerifLen(string NombrePropiedad, object Valor, DataTable InfoCamposHabilitados, object Clase)
		{
			VerifLen(NombrePropiedad, NombrePropiedad, Valor, InfoCamposHabilitados, Clase);
		}
		public static void VerifLen(string NombrePropiedad, string NombreColumna, object Valor, DataTable InfoCamposHabilitados, object Clase)
		{
			string propiedad;
			System.Globalization.CultureInfo cedeiraCultura=new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
			propiedad=Convert.ToString(Valor,cedeiraCultura);
			string Tipo=InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Tipo"].ToString();
			switch(Tipo)
			{
				case "int": 
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.Int32")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "numeric":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.Double" && Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.Int32" && Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.Decimal")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					string dec;
					string ent;
					if(propiedad.IndexOf(".")==-1)
					{
						ent=propiedad;
						dec="";
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Enteros"])<
							ent.Length) 
						{
							throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
						}
					}
					else
					{
						for (int i=propiedad.Length-1;i>propiedad.IndexOf(".");i--)
						{
							if (propiedad.Substring(i,1)=="0")
							{
								propiedad=propiedad.Substring(0,i);
							}
							else
							{
								break;
							}
						}
						ent=propiedad.Substring(0,propiedad.IndexOf("."));
						dec=propiedad.Substring(propiedad.IndexOf(".")+1);
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Enteros"])<
							ent.Length) 
						{
							throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
						}
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Decimales"])<
							dec.Length) 
						{
							throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
						}
					}
					break;
				case "timestamp":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.DateTime")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "tinyint":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.Byte")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "varchar":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.String")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Long"])<
						propiedad.Length) 
					{
						throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
					}
					break;
				case "datetime":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.DateTime")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "char":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName!="System.String")
					{
						throw new Cedeira.Ex.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='"+NombreColumna+"'")[0]["Long"])<
						propiedad.Length) 
					{
						throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
					}
					break;
				default:
					throw new Cedeira.Ex.Validaciones.LenInvalida(NombrePropiedad);
			}
		}
		public static decimal TruncarACiertosDecimales(decimal D, int I)
		{
			double aux;
			aux=Math.Pow((double)10,(double)I);
			return (decimal)(Math.Floor((double)(D*(decimal)aux))/aux);

		}
		public static void ExpandirYColapsarPrimerGrupo (Janus.Windows.GridEX.GridEX Gex)
		{
			if (Gex.RootTable.Groups.Count > 0)
			{
				Gex.RootTable.Groups[0].Collapse();
				Gex.RootTable.Groups[0].Expand();
			}
		}
		public static double CorregirPrecision(double Numero, int LongitudIncluyendoSeparador)
		{
			string aux=Numero.ToString();
			if(aux.Length>LongitudIncluyendoSeparador)
			{
				//Busco decimales
				int auxIndice=aux.IndexOf(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				if(auxIndice!=-1)
				{
					int decimales=aux.Length-auxIndice-1;
					int caracteresAQuitar=aux.Length-LongitudIncluyendoSeparador;

					if(decimales==caracteresAQuitar)
					{
						caracteresAQuitar++;
						aux=aux.Remove(aux.Length-caracteresAQuitar,caracteresAQuitar);
					}
					else if(decimales>caracteresAQuitar)
					{
						aux=aux.Remove(aux.Length-caracteresAQuitar,caracteresAQuitar);
					}
					else
					{
						throw new Cedeira.Ex.Validaciones.AjustePrecision(Numero, LongitudIncluyendoSeparador);
					}
					double auxRetorno=double.Parse(aux, System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat);
					return auxRetorno;
				}
			}
			return Numero;
		}
		public static string FechasParaColumnas(DateTime[] Fechas)
		{
			System.Text.StringBuilder a=new System.Text.StringBuilder();
			for(int i=0;i<=Fechas.GetUpperBound(0);i++)
			{
				a.Append("0.00 as '");
				a.Append(Fechas[i].ToString("dddd"));
				a.Append(" ");
				a.Append(Fechas[i].Day);
				a.Append("/");
				a.Append(Fechas[i].Month);
				a.Append("'");
				a.Append(",");
			}
			a.Remove(a.Length-1,1);
			return a.ToString();
		}
		public static string FechaParaCashFlow(DateTime Fecha)
		{
			System.Text.StringBuilder a=new System.Text.StringBuilder();
			a.Append(Fecha.ToString("dddd"));
			a.Append(" ");
			a.Append(Fecha.Day);
			a.Append("/");
			a.Append(Fecha.Month);
			return a.ToString();
		}
		public void AgregarFilas (DataTable dt, DataRow[] drs)
		{
			for (int i=0; i<drs.Length; i++)
			{
				dt.Rows.Add(drs[i].ItemArray);
			}
			dt.AcceptChanges();
		}
	}
}