using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_I_Bj.DB
{
    public class ComprobanteBj : db
    {
        public ComprobanteBj(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void ConsultarN(List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes, FeaEntidades.InterFacturas.lote_comprobantes Lc, eFact_I_Bj.RN.TableroBj.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string IdTipoComprobante, string PuntoVenta, string NumeroComprobante, bool VerificarExistenciaCAE)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("DECLARE @FechaDsd as Datetime DECLARE @FechaHst as Datetime DECLARE @NroComp as Varchar(250) ");
            commandText.Append("SET @FechaDsd='" + FechaDsd + "' ");
            commandText.Append("SET @FechaHst='" + FechaHst + "' ");
            
			if (NumeroComprobante != string.Empty)
			{
				commandText.Append("SET @NroComp='" + NumeroComprobante + "' ");
			}
            commandText.Append("select gva12.id_gva12, gva12.cod_client, gva12.cat_iva, gva12.fecha_emis, gva12.n_comp, gva12.t_comp, gva12.cotiz, gva12.importe_iv, round(gva12.importe_iv * gva12.cotiz, 6) as importe_iv_pesos, gva12.unidades, gva12.importe, round((gva12.unidades - gva12.importe_iv) * gva12.cotiz, 6) as ImpTotalNetoGravado, gva12.pto_vta, gva12.leyenda_1, gva12.leyenda_2, gva12.leyenda_3, gva12.leyenda_4, gva12.leyenda_5, gva12.MON_CTE, ");
            commandText.Append("gva14.c_postal, gva14.cod_provin, gva14.cuit, gva14.dir_com, gva14.localidad, gva14.nom_com, gva14.tipo_doc ");
            commandText.Append("from GVA12 ");
            commandText.Append("inner join gva14 on gva12.cod_client=gva14.cod_client ");
            commandText.Append("where fecha_emis >= @FechaDsd and fecha_emis < Dateadd (Day, 1, @FechaHst) ");
			if (NumeroComprobante != string.Empty)
			{
				commandText.Append("and gva12.n_comp like '%'+@NroComp+'%' ");
			}

            commandText.Append("select gva12.id_gva12, gva12.cod_client, gva12.cat_iva, gva12.fecha_emis, gva12.n_comp, gva12.t_comp, gva12.cotiz, gva12.importe_iv, gva12.unidades, gva12.importe, ");
            commandText.Append("gva14.id_gva14, gva14.c_postal, gva14.cod_provin, gva14.cuit, gva14.dir_com, gva14.localidad, gva14.nom_com, gva14.tipo_doc, ");
            commandText.Append("gva53.cantidad, gva53.id_medida_ventas, GVA53.PRECIO_NET, round(GVA53.PRECIO_NET * gva12.cotiz, 7) as PRECIO_NET_pesos, gva53.IMP_NETO_P, round(GVA53.IMP_NETO_P * gva12.cotiz, 6) as IMP_NETO_P_pesos, GVA53.PORC_IVA, ");
            commandText.Append("sta11.descripcio, ");
            commandText.Append("medida.cod_medida ");
            commandText.Append("from GVA12 ");
            commandText.Append("inner join gva14 on gva12.cod_client=gva14.cod_client ");
            commandText.Append("inner join gva53 on gva53.N_comp=gva12.n_comp and gva53.t_comp=gva12.t_comp ");
            commandText.Append("inner join gva63 on gva63.N_comp=gva12.n_comp and gva63.t_comp=gva12.t_comp ");
            commandText.Append("inner join sta11 on gva53.COD_ARTICU=sta11.cod_articu ");
            commandText.Append("inner join medida on gva53.ID_MEDIDA_VENTAS=medida.id_medida ");
            commandText.Append("where fecha_emis >= @FechaDsd and fecha_emis < Dateadd (Day, 1, @FechaHst) ");
			if (NumeroComprobante != string.Empty)
			{
				commandText.Append("and gva12.n_comp like '%'+@NroComp+'%' ");
			}
      
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStrAplicExterna);

            commandText = commandText.Remove(0, commandText.Length);
            commandText.Append("select * from vendedores where cuitvendedor='33709728119' ");
            
            DataTable dsTable = new DataTable();
            dsTable = ((DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr)).Copy();
            dsTable.TableName = "Vendedor";
            ds.Tables.Add(dsTable);
            ds.AcceptChanges();

            commandText = commandText.Remove(0, commandText.Length);
            commandText.Append("select * from GVA15 ");
            DataTable dsTable1 = new DataTable();
            dsTable1 = ((DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStrAplicExterna)).Copy();
            dsTable1.TableName = "TComprobantes";
            ds.Tables.Add(dsTable1);
            ds.AcceptChanges();

            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
				try
				{
					DataTable dt = ds.Tables[0];
					DataTable dt2 = ds.Tables[2];
					DataTable dtTComprobantes = ds.Tables[3];
					//Crear "cabecera" del lote de comprobantes
					Lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
					Lc.cabecera_lote.cuit_canal = Convert.ToInt64(@System.Configuration.ConfigurationManager.AppSettings["CuitCanal"].ToString());
					Lc.cabecera_lote.cuit_vendedor = Convert.ToInt64(dt2.Rows[0]["CuitVendedor"]);
					Lc.cabecera_lote.cantidad_reg = dt.Rows.Count;
					Lc.cabecera_lote.id_lote = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
					Lc.cabecera_lote.fecha_envio_lote = DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HHmmss");
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						eFact_I_Bj.Entidades.ComprobanteBj Comprobante = new eFact_I_Bj.Entidades.ComprobanteBj();
						//Crear "lote_comprobantes"
						//FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
						//Crear "comprobante" del lote de comprobantes
						FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
						//Crear "cabecera" del comprobante
						c.cabecera = new FeaEntidades.InterFacturas.cabecera();
						//Crear "informacion_comprador" de la cabecera del comprobante
						c.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
						//Crear "informacion_vendedor" de la cabecera del comprobante
						c.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
						//Crear "informacion_comprobante" de la cabecera del comprobante
						c.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
						//Crear "detalle" del comprobante.
						c.detalle = new FeaEntidades.InterFacturas.detalle();
						//Crear "resumen" del comprobante.
						c.resumen = new FeaEntidades.InterFacturas.resumen();

						Comprobante.Clave = Convert.ToInt32(dt.Rows[i]["id_gva12"]);
						//Comprobante.Vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
						// Armar switch con cada tipo de comprobante de Tango a Cedeira
						string letraComprobante = dt.Rows[i]["n_comp"].ToString().Substring(0, 1);
						switch (dt.Rows[i]["t_comp"].ToString())
						{
							case "FAC":
								if (letraComprobante == "A")
								{
									FeaEntidades.TiposDeComprobantes.Facturas.A tc = new FeaEntidades.TiposDeComprobantes.Facturas.A();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								else
								{
									FeaEntidades.TiposDeComprobantes.Facturas.B tc = new FeaEntidades.TiposDeComprobantes.Facturas.B();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								break;
							case "N/D":
								if (letraComprobante == "A")
								{
									FeaEntidades.TiposDeComprobantes.NotasDebito.A tc = new FeaEntidades.TiposDeComprobantes.NotasDebito.A();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								else
								{
									FeaEntidades.TiposDeComprobantes.NotasDebito.B tc = new FeaEntidades.TiposDeComprobantes.NotasDebito.B();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								break;
							case "N/C":
								break;
							case "LIQ":
								if (letraComprobante == "A")
								{
									FeaEntidades.TiposDeComprobantes.Liquidacion.A tc = new FeaEntidades.TiposDeComprobantes.Liquidacion.A();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								else
								{
									FeaEntidades.TiposDeComprobantes.Liquidacion.B tc = new FeaEntidades.TiposDeComprobantes.Liquidacion.B();
									c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
									Comprobante.IdTipoComprobante = tc.Codigo.ToString();
								}
								break;
							case "NDI":
								break;
							case "NCI":
								break;

						}
						FeaEntidades.InterFacturas.informacion_comprador feaEntidadinfComprador = new FeaEntidades.InterFacturas.informacion_comprador();
						Comprobante.NumeroComprobante = dt.Rows[i]["n_comp"].ToString();
						c.cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt64(Comprobante.NumeroComprobante.Substring(5, Comprobante.NumeroComprobante.Length - 5));

						Comprobante.PuntoVenta = Convert.ToInt32(Comprobante.NumeroComprobante.Substring(1, 4));
						Lc.cabecera_lote.punto_de_venta = Comprobante.PuntoVenta;
						c.cabecera.informacion_comprobante.punto_de_venta = Comprobante.PuntoVenta;


						// Armar switch con cada tipo doc de Tango a Cedeira
						Comprobante.Comprador.TipoDoc = Convert.ToInt16(dt.Rows[i]["tipo_doc"]);
						feaEntidadinfComprador.codigo_doc_identificatorio = Comprobante.Comprador.TipoDoc;

						Comprobante.Comprador.NroDoc = dt.Rows[i]["cuit"].ToString();
						feaEntidadinfComprador.nro_doc_identificatorio = Convert.ToInt64(Comprobante.Comprador.NroDoc.Replace("-", string.Empty));

						Comprobante.Comprador.Nombre = dt.Rows[i]["nom_com"].ToString();
						feaEntidadinfComprador.denominacion = Comprobante.Comprador.Nombre;
						feaEntidadinfComprador.denominacion = Comprobante.Comprador.Nombre;
						Comprobante.Comprador.DomicilioCalle = dt.Rows[i]["dir_com"].ToString();
						feaEntidadinfComprador.domicilio_calle = Comprobante.Comprador.DomicilioCalle;
						Comprobante.Comprador.CondicionIVA = dt.Rows[i]["cat_iva"].ToString();
						FeaEntidades.CondicionesIVA.ResponsableInscripto condicionIVA = new FeaEntidades.CondicionesIVA.ResponsableInscripto();
						feaEntidadinfComprador.condicion_IVA = condicionIVA.Codigo;
						feaEntidadinfComprador.condicion_IVASpecified = true;
						Comprobante.Comprador.Localidad = dt.Rows[i]["localidad"].ToString();
						feaEntidadinfComprador.localidad = Comprobante.Comprador.Localidad;
						Comprobante.Comprador.Provincia = Convert.ToInt16(dt.Rows[i]["cod_provin"]);
						feaEntidadinfComprador.provincia = dt.Rows[i]["cod_provin"].ToString();
						Comprobante.Comprador.CP = dt.Rows[i]["c_postal"].ToString();
						feaEntidadinfComprador.cp = Comprobante.Comprador.CP;
						//Comprobante.Comprador.Telefono = dt.Rows[i]["Comprador_telefono"].ToString();
						//Comprobante.Comprador.EMail = dt.Rows[i]["Comprador_email"].ToString();
						Comprobante.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha_emis"]);
						c.cabecera.informacion_comprobante.fecha_emision = Comprobante.Fecha.ToString("yyyyMMdd");
						if (!dt.Rows[i]["leyenda_1"].ToString().Equals(string.Empty))
						{
							Comprobante.FechaVto = Convert.ToDateTime(dt.Rows[i]["leyenda_1"].ToString(), cedeiraCultura.DateTimeFormat);
							c.cabecera.informacion_comprobante.fecha_vencimiento = Comprobante.FechaVto.ToString("yyyyMMdd");
						}
						else
						{
							Comprobante.FechaVto = Convert.ToDateTime("2008/05/22", cedeiraCultura.DateTimeFormat);
							c.cabecera.informacion_comprobante.fecha_vencimiento = Comprobante.FechaVto.ToString("yyyyMMdd");
						}
						//Comprobante.Importe = Convert.ToDecimal(dt.Rows[i]["importe"]);
						//Comprobante.ImporteNetoGravado = Convert.ToDecimal(dt.Rows[i]["PRECIO_NET"]);
						//Comprobante.ImporteNetoNoGravado = Convert.ToDecimal(dt.Rows[i]["importe"]);
						//feaEntidadComprobante.Imp_neto = Comprobante.ImporteNetoNoGravado;
						//Comprobante.ImporteOpsExentas = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_operaciones_exentas"]);
						//Comprobante.ImpuestoLiq = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq"]);
						//Comprobante.ImpuestoRNI = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq_rni"]);
						//Comprobante.ImpuestosNacionales = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_impuestos_nacionales"]);
						//Comprobante.CantAlicuotasIVA = Convert.ToInt32(dt.Rows[i]["Resumen_cant_alicuotas_iva"]);
						//if (dt.Rows[i]["Comprobante_cae"] != System.DBNull.Value && dt.Rows[i]["Comprobante_cae"].ToString() != "")
						//{
						//    Comprobante.NumeroCAE = dt.Rows[i]["Comprobante_cae"].ToString();
						//    Comprobante.FechaVtoCAE = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_vencimiento_cae"]);
						//}
						Comprobante.Vendedor.CuitVendedor = dt2.Rows[0]["CuitVendedor"].ToString();
						FeaEntidades.InterFacturas.informacion_vendedor feaEntidadInfVendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
						feaEntidadInfVendedor.cuit = Convert.ToInt64(Comprobante.Vendedor.CuitVendedor.Replace("-", string.Empty));
						Comprobante.Vendedor.Nombre = dt2.Rows[0]["Nombre"].ToString();
						feaEntidadInfVendedor.razon_social = Comprobante.Vendedor.Nombre;
						Comprobante.Vendedor.NumeroSerieCertificado = dt2.Rows[0]["NumeroSerieCertificado"].ToString();
						//System.IO.MemoryStream memStream = new System.IO.MemoryStream(dt2.Rows[i]["Logo"]);
						//Byte[] logo = memStream.GetBuffer();
						//Comprobante.Vendedor.Logo = dt2.Rows[i]["Logo"];
						Comprobante.Vendedor.Codigo = dt2.Rows[0]["Codigo"].ToString();
						feaEntidadInfVendedor.codigo_interno = Comprobante.Vendedor.Codigo;
						Comprobante.Vendedor.InicioActividades = Convert.ToDateTime(dt2.Rows[0]["InicioActividades"]);
						feaEntidadInfVendedor.inicio_de_actividades = Comprobante.Vendedor.InicioActividades.ToString("yyyyMMdd");
						Comprobante.Vendedor.Contacto = dt2.Rows[0]["Contacto"].ToString();
						feaEntidadInfVendedor.contacto = Comprobante.Vendedor.Contacto;
						Comprobante.Vendedor.DomicilioCalle = dt2.Rows[0]["DomicilioCalle"].ToString();
						feaEntidadInfVendedor.domicilio_calle = Comprobante.Vendedor.DomicilioCalle;
						Comprobante.Vendedor.DomicilioNumero = dt2.Rows[0]["DomicilioNumero"].ToString();
						feaEntidadInfVendedor.domicilio_numero = Comprobante.Vendedor.DomicilioNumero;
						Comprobante.Vendedor.DomicilioPiso = dt2.Rows[0]["DomicilioPiso"].ToString();
						feaEntidadInfVendedor.domicilio_piso = Comprobante.Vendedor.DomicilioPiso;
						Comprobante.Vendedor.DomicilioDepto = dt2.Rows[0]["DomicilioDepto"].ToString();
						feaEntidadInfVendedor.domicilio_depto = Comprobante.Vendedor.DomicilioDepto;
						Comprobante.Vendedor.DomicilioSector = dt2.Rows[0]["DomicilioSector"].ToString();
						feaEntidadInfVendedor.domicilio_sector = Comprobante.Vendedor.DomicilioSector;
						Comprobante.Vendedor.DomicilioTorre = dt2.Rows[0]["DomicilioTorre"].ToString();
						feaEntidadInfVendedor.domicilio_torre = Comprobante.Vendedor.DomicilioTorre;
						Comprobante.Vendedor.DomicilioManzana = dt2.Rows[0]["DomicilioManzana"].ToString();
						feaEntidadInfVendedor.domicilio_manzana = Comprobante.Vendedor.DomicilioManzana;
						Comprobante.Vendedor.CondicionIVA = Convert.ToInt32(dt2.Rows[0]["CondicionIVA"]);
						feaEntidadInfVendedor.condicion_IVA = Comprobante.Vendedor.CondicionIVA;
						feaEntidadInfVendedor.condicion_IVASpecified = true;
						Comprobante.Vendedor.CondicionIB = Convert.ToInt32(dt2.Rows[0]["CondicionIB"]);
						feaEntidadInfVendedor.condicion_ingresos_brutos = Comprobante.Vendedor.CondicionIB;
						feaEntidadInfVendedor.condicion_ingresos_brutosSpecified = true;
						Comprobante.Vendedor.NroIB = dt2.Rows[0]["NroIB"].ToString();
						feaEntidadInfVendedor.nro_ingresos_brutos = Comprobante.Vendedor.NroIB;
						Comprobante.Vendedor.Localidad = dt2.Rows[0]["Localidad"].ToString();
						feaEntidadInfVendedor.localidad = Comprobante.Vendedor.Localidad;
						Comprobante.Vendedor.Provincia = dt2.Rows[0]["Provincia"].ToString();
						//feaEntidadInfVendedor.provincia = Comprobante.Vendedor.Provincia;
						Comprobante.Vendedor.CP = dt2.Rows[0]["CP"].ToString();
						feaEntidadInfVendedor.cp = Comprobante.Vendedor.CP;
						Comprobante.Vendedor.Telefono = dt2.Rows[0]["Telefono"].ToString();
						feaEntidadInfVendedor.telefono = Comprobante.Vendedor.Telefono;
						Comprobante.Vendedor.EMail = dt2.Rows[0]["EMail"].ToString();
						feaEntidadInfVendedor.email = Comprobante.Vendedor.EMail;
						c.cabecera.informacion_comprador = feaEntidadinfComprador;
						c.cabecera.informacion_vendedor = feaEntidadInfVendedor;

						c.resumen.tipo_de_cambio = Convert.ToDouble(dt.Rows[i]["cotiz"]);
						Comprobante.TipoDeCambio = Convert.ToDouble(dt.Rows[i]["cotiz"]);
						c.resumen.importe_total_factura = Math.Round(Convert.ToDouble(dt.Rows[i]["importe"]), 2);
						Comprobante.Importe = Convert.ToDecimal(dt.Rows[i]["importe"]);
						c.resumen.importe_total_neto_gravado = Math.Round(Convert.ToDouble(dt.Rows[i]["ImpTotalNetoGravado"]), 2);
						c.resumen.impuesto_liq = Math.Round(Convert.ToDouble(dt.Rows[i]["importe_iv_pesos"]), 2);

						//Guardar Leyendas
						List<string> leyendas = new List<string>();
						leyendas.Add(dt.Rows[i]["leyenda_1"].ToString());
						leyendas.Add(dt.Rows[i]["leyenda_2"].ToString());
						leyendas.Add(dt.Rows[i]["leyenda_3"].ToString());
						leyendas.Add(dt.Rows[i]["leyenda_4"].ToString());
						leyendas.Add(dt.Rows[i]["leyenda_5"].ToString());
						Comprobante.Leyendas = leyendas;

						//List<FeaEntidades.CodigosMoneda.CodigoMoneda> listaCodMoneda = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
						if (!Convert.ToBoolean(dt.Rows[i]["MON_CTE"]))
						{
							c.resumen.codigo_moneda = "DOL";
							Comprobante.IdMoneda = "DOL";
							c.resumen.importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
							c.resumen.importes_moneda_origen.impuesto_liq = Math.Round(Convert.ToDouble(dt.Rows[i]["importe_iv"]), 2);
							c.resumen.importes_moneda_origen.importe_total_factura = Math.Round(Convert.ToDouble(dt.Rows[i]["unidades"]), 2);
							c.resumen.importes_moneda_origen.importe_total_neto_gravado = Math.Round(c.resumen.importes_moneda_origen.importe_total_factura - c.resumen.importes_moneda_origen.impuesto_liq, 2);
						}
						else
						{
							c.resumen.codigo_moneda = "PES";
							Comprobante.IdMoneda = "PES";
						}
						FeaEntidades.InterFacturas.lineas feaEntidadLineas = new FeaEntidades.InterFacturas.lineas();
						DataRow[] drDetDesc = ds.Tables[1].Select("id_gva12 = " + Comprobante.Clave);
						double porcIVA = 0;
						for (int j = 0; j < drDetDesc.Length; j++)
						{
							eFact_I_Bj.Entidades.ComprobanteBjLinea linea = new eFact_I_Bj.Entidades.ComprobanteBjLinea();
							FeaEntidades.InterFacturas.linea lineaFEA = new FeaEntidades.InterFacturas.linea();
							DataRow dr = drDetDesc[j];
							linea.Clave = Convert.ToInt32(Comprobante.Clave);
							linea.Descripcion = dr["descripcio"].ToString();
							lineaFEA.numeroLinea = j + 1;
							lineaFEA.descripcion = linea.Descripcion;
							linea.Cantidad = Convert.ToDecimal(dr["cantidad"]);
							lineaFEA.cantidad = Convert.ToDouble(linea.Cantidad);
							lineaFEA.cantidadSpecified = true;
							linea.Precio_unitario = Convert.ToDecimal(dr["precio_net_pesos"]);
							lineaFEA.precio_unitario = Math.Round(Convert.ToDouble(dr["precio_net_pesos"]), 6);
							lineaFEA.precio_unitarioSpecified = true;
							linea.Alicuota_iva = Convert.ToDecimal(dr["porc_iva"]);
							lineaFEA.alicuota_iva = Convert.ToDouble(linea.Alicuota_iva);
							lineaFEA.alicuota_ivaSpecified = true;
							linea.Importe_total_articulo = Convert.ToDecimal(dr["IMP_NETO_P_pesos"]);
							lineaFEA.importe_total_articulo = Math.Round(Convert.ToDouble(dr["IMP_NETO_P_pesos"]), 3);
							lineaFEA.importe_iva = Math.Round(lineaFEA.importe_total_articulo * (lineaFEA.alicuota_iva / 100), 2);
							lineaFEA.importe_ivaSpecified = true;
							linea.Importe_iva = Convert.ToDecimal(lineaFEA.importe_iva);
							//linea.Indicacion_exento_gravado = dr[0]["Linea_indicacion_exento_gravado"].ToString();
							//linea.Importe_total_descuentos = Convert.ToDecimal(dr[0]["Linea_importe_total_descuentos"]);
							//linea.Importe_total_impuestos = Convert.ToDecimal(dr[0]["Linea_Importe_total_impuestos"]);
							if (lineaFEA.alicuota_iva != 0)
							{
								porcIVA = lineaFEA.alicuota_iva;
							}
							if (c.resumen.codigo_moneda == "DOL")
							{
								lineaFEA.importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
								lineaFEA.importes_moneda_origen.importe_total_articulo = Math.Round(Convert.ToDouble(dr["IMP_NETO_P"]), 3);
								lineaFEA.importes_moneda_origen.importe_total_articuloSpecified = true;
								lineaFEA.importes_moneda_origen.importe_iva = Math.Round(lineaFEA.importes_moneda_origen.importe_total_articulo * (lineaFEA.alicuota_iva / 100), 2);
								lineaFEA.importes_moneda_origen.importe_ivaSpecified = true;
								lineaFEA.importes_moneda_origen.precio_unitario = Math.Round(Convert.ToDouble(dr["PRECIO_NET"]), 6);
								lineaFEA.importes_moneda_origen.precio_unitarioSpecified = true;
							}

							FeaEntidades.InterFacturas.resumenImpuestos imp = new FeaEntidades.InterFacturas.resumenImpuestos();
							imp.codigo_impuesto = 1;
							imp.descripcion = "IVA";
							if (porcIVA != 0)
							{
								imp.porcentaje_impuesto = porcIVA;
								imp.porcentaje_impuestoSpecified = true;
							}
							if (c.resumen.codigo_moneda == "DOL")
							{
								imp.importe_impuesto = c.resumen.impuesto_liq;
								imp.importe_impuesto_moneda_origen = c.resumen.importes_moneda_origen.impuesto_liq;
								imp.importe_impuesto_moneda_origenSpecified = true;
							}
							c.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[10];
							c.resumen.impuestos[0] = imp;

							Comprobante.Lineas.Add(linea);
							c.detalle.linea[j] = lineaFEA;
						}
						Comprobantes.Add(Comprobante);
						Lc.comprobante[i] = c;
					}
				}
				catch
				{
				}
                    
                }
            }
        
        public void Consultar(List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes, eFact_I_Bj.RN.TableroBj.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string IdTipoComprobante, string PuntoVenta, string NumeroComprobante, bool VerificarExistenciaCAE)
        {
            ////Tabla IVA Bj
            ////1 - 'Responsable inscripto'
            ////2 - 'Responsable no inscripto'
            ////5 - 'exento'
            ////3 - 'consumidor final'
            ////4 - 'no responsable'
            ////6 - 'Monotributo'
            //StringBuilder commandText = new StringBuilder();
            //commandText.Append("select cve_ID as Clave, CASE clitdc_Cod WHEN 1 THEN '80' ELSE '' END as Comprador_tipo_doc, cvecli_CUIT as Comprador_nro_doc_identificatorio, cvecli_RazSoc as Comprador_denominacion, cvecli_NroIB as Comprador_nro_ingresos_brutos, ");
            //commandText.Append("CASE clisiv_Cod WHEN 1 THEN '1' WHEN 2 THEN '2' WHEN 3 THEN '5' WHEN 4 THEN '3' WHEN 5 THEN '4' WHEN 6 THEN '6' ELSE '' END as Comprador_condicion_IVA, cli_Direc as Comprador_domicilio_calle, ");
            //commandText.Append("cli_Loc as Comprador_localidad, convert(int, cliprv_Codigo) as Comprador_provincia, cli_CodPos as Comprador_cp, cli_EMail as Comprador_email, cli_Tel as Comprador_telefono, ");
            //commandText.Append("CASE cvetal_Cod WHEN 'FEA' THEN '1' WHEN 'DEA' THEN '2' WHEN 'CEA' THEN '3' WHEN 'FEB' THEN '6' WHEN 'DEB' THEN '7' WHEN 'CEB' THEN '8' ELSE '' END as Comprobante_tipo_de_comprobante, ");
            //commandText.Append("cvetco_Cod as Comprobante_AdicTipoComp, cve_Letra as Comprobante_AdicTipoCompLetra, cve_Nro as Comprobante_numero_comprobante, cvepvt_CodIN as Comprobante_punto_de_venta, ");
            //commandText.Append("cve_FEmision as Comprobante_fecha_emision, cve_FVto as Comprobante_fecha_vencimiento, cvecvt_Cod as Comprobante_condicion_de_pago, ");
            //commandText.Append("cve_NroCAITal as Comprobante_cae, cve_FVtoCAITal as Comprobante_fecha_vencimiento_cae, ");
            //commandText.Append("cveemp_Codigo as Codigo, ");
            //commandText.Append("'PES' as Resumen_moneda, ");
            //commandText.Append("cve_ImpMonLoc as Resumen_importe_total_factura, (select Sum(ive_IInscLoc +  ive_INoInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_importe_total_impuestos_nacionales, ");
            //commandText.Append("(select Sum(ive_IInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_impuesto_liq, ");
            //commandText.Append("(select Sum(ive_INoInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_impuesto_liq_rni, ");
            //commandText.Append("(select Sum(ive_NetoLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_importe_total_neto_gravado, ");
            //commandText.Append("0 as Resumen_importe_total_concepto_no_gravado, 0 as Resumen_importe_operaciones_exentas, ");
            //commandText.Append("(select Count(Distinct(ive_TInsc)) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID and ive_TInsc <> 0) + (select Count(Distinct(ive_TNoInsc)) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID and ive_TNoInsc <> 0) as Resumen_cant_alicuotas_iva, cvescv_ID as ClaveDetDesc ");
            //commandText.Append("INTO #CabVenta ");
            //commandText.Append("from CabVenta, Clientes, puntoVta ");
            //commandText.Append("where CabVenta.cve_CodCli *= Clientes.cli_cod and CabVenta.cvepvt_CodIN = puntoVta.pvt_cod and puntoVta.pvt_factelec = 'S' ");
            //commandText.Append("and (cve_FEmision >='" + FechaDsd.ToString("yyyyMMdd") + "' and cve_FEmision < Dateadd (Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "')) ");
            //if (IdTipoComprobante != "" && IdTipoComprobante != "0")
            //{
            //    string tipoComprobante = "";
            //    switch (IdTipoComprobante)
            //    {
            //        case "1":
            //            tipoComprobante = "FEA";
            //            break;
            //        case "2":
            //            tipoComprobante = "DEA";
            //            break;
            //        case "3":
            //            tipoComprobante = "CEA";
            //            break;
            //        case "6":
            //            tipoComprobante = "FEB";
            //            break;
            //        case "7":
            //            tipoComprobante = "DEB";
            //            break;
            //        case "8":
            //            tipoComprobante = "CEB";
            //            break;
            //        default:
            //            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Tipo de comprobantes no permitido.\r\n\r\nSolo pueden ser seleccionados los siguientes tipos de comprobantes:\r\nFactura A o B.\r\nNota de Débito A o B.\r\nNota de Crédito A o B.");
            //    }
            //    commandText.Append("and cvetal_Cod = '" + tipoComprobante + "' ");
            //}
            //if (PuntoVenta != "")
            //{
            //    commandText.Append("and (cvepvt_CodIN = '" + PuntoVenta + "' or convert(int, cvepvt_CodIN) = " + Convert.ToInt32(PuntoVenta) + ") ");
            //}
            //if (NumeroComprobante != "")
            //{
            //    commandText.Append("and (cve_Nro = '" + NumeroComprobante + "' or convert(int, cve_Nro) = " + Convert.ToInt32(NumeroComprobante) + ") ");
            //}
            //if (VerificarExistenciaCAE)
            //{
            //    commandText.Append("and (cve_NroCAITal <> null or cve_NroCAITal <> '') ");
            //}
            ////Select Cabeza del Comprobante
            //commandText.Append("Select * from #CabVenta ");
            ////Select Toteles por Item
            //commandText.Append("Select ivecve_ID as Clave, ive_NReng as Renglon, ive_Desc as Linea_descripcion, ive_CantUM1 as Linea_cantidad, ive_NetoLoc as Linea_precio_unitario, ive_TInsc + ive_TNoInsc as Linea_alicuota_iva, ive_IInscLoc + ive_INoInscLoc as Linea_importe_iva, ");
            //commandText.Append("CASE ive_tipoTasa WHEN 1 THEN 'G' ELSE 'E' END as Linea_indicacion_exento_gravado, ");
            //commandText.Append("0 as Linea_importe_total_descuentos, ive_IInscLoc + ive_INoInscLoc as Linea_importe_total_impuestos, ");
            //commandText.Append("ive_NetoLoc + ive_IInscLoc + ive_INoInscLoc as Linea_importe_total_articulo ");
            //commandText.Append("from #CabVenta, ItemVta ");
            //commandText.Append("where #CabVenta.Clave = ItemVta.ivecve_ID ");
            ////Select Detalle completo de la Descripcion del Item
            //commandText.Append("Select #CabVenta.Clave, #CabVenta.ClaveDetDesc, sdv_NReng as Renglon, sdv_TipoIt as TipoDetalle, sdv_Desc as Descripcion ");
            //commandText.Append("from #CabVenta, SegDetV ");
            //commandText.Append("where #CabVenta.ClaveDetDesc = SegDetV.sdvscv_ID ");
            //DataSet ds = new DataSet();
            //ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStrAplicExterna);

            //commandText = new StringBuilder();
            //commandText.Append("CREATE TABLE #ComprobantesBj( Clave int not null, ");
            //commandText.Append("Comprador_tipo_doc varchar(2) not null, ");
            //commandText.Append("Comprador_nro_doc_identificatorio varchar(11) not null, ");
            //commandText.Append("Comprador_denominacion varchar(40) not null, ");
            //commandText.Append("Comprador_nro_ingresos_brutos varchar(15) not null, "); 
            //commandText.Append("Comprador_condicion_IVA varchar(1) not null, ");
            //commandText.Append("Comprador_domicilio_calle varchar(30) null, ");								
            //commandText.Append("Comprador_localidad varchar(25) null, ");
            //commandText.Append("Comprador_provincia int null, "); 
            //commandText.Append("Comprador_cp varchar(8) null, "); 								
            //commandText.Append("Comprador_email varchar(50) null, "); 
            //commandText.Append("Comprador_telefono varchar(30) null, ");
            //commandText.Append("Comprobante_tipo_de_comprobante varchar(1) not null, "); 
            //commandText.Append("Comprobante_AdicTipoComp varchar(3) not null, "); 
            //commandText.Append("Comprobante_AdicTipoCompLetra varchar(1) not null, "); 
            //commandText.Append("Comprobante_numero_comprobante varchar(8) not null, "); 
            //commandText.Append("Comprobante_punto_de_venta varchar(4) not null, "); 
            //commandText.Append("Comprobante_fecha_emision datetime not null, "); 
            //commandText.Append("Comprobante_fecha_vencimiento datetime not null, "); 
            //commandText.Append("Comprobante_condicion_de_pago varchar(3) null, "); 
            //commandText.Append("Comprobante_cae	varchar(15) null, ");
            //commandText.Append("Comprobante_fecha_vencimiento_cae datetime not null, ");
            //commandText.Append("Codigo varchar(255) not null, ");
            //commandText.Append("Resumen_moneda	varchar(5) not null, ");
            //commandText.Append("Resumen_importe_total_factura decimal(18,2) not null, ");
            //commandText.Append("Resumen_importe_total_impuestos_nacionales decimal(18,2) not null, ");
            //commandText.Append("Resumen_impuesto_liq decimal(18,2) not null, ");
            //commandText.Append("Resumen_impuesto_liq_rni decimal(18,2) not null, ");
            //commandText.Append("Resumen_importe_total_neto_gravado decimal(18,2) not null, ");
            //commandText.Append("Resumen_importe_total_concepto_no_gravado decimal(18,2) not null, ");
            //commandText.Append("Resumen_importe_operaciones_exentas decimal(18,2) not null, ");
            //commandText.Append("Resumen_cant_alicuotas_iva decimal(18,2) not null, ");
            //commandText.Append("ClaveDetDesc int not null, ");
            //commandText.Append("CONSTRAINT [ComprobantesTemp_PK] PRIMARY KEY NONCLUSTERED ");
            //commandText.Append("( [clave] ASC ) ON [PRIMARY] ");
            //commandText.Append(") ON [PRIMARY] ");
            
            //commandText.Append("CREATE TABLE #ComprobantesDetBj( Clave int not null, ");
            //commandText.Append("Renglon int not null, ");
            //commandText.Append("Linea_descripcion varchar(255) not null, ");
            //commandText.Append("Linea_cantidad decimal(18,2) not null, ");
            //commandText.Append("Linea_precio_unitario decimal(18,2) not null, ");
            //commandText.Append("Linea_alicuota_iva decimal(18,2) not null, ");
            //commandText.Append("Linea_importe_iva decimal(18,2) null, ");
            //commandText.Append("Linea_indicacion_exento_gravado varchar(1) null, ");
            //commandText.Append("Linea_importe_total_descuentos decimal(18,2) null, ");
            //commandText.Append("Linea_importe_total_impuestos decimal(18,2) null, ");
            //commandText.Append("Linea_importe_total_articulo decimal(18,2) null, ");
            //commandText.Append("CONSTRAINT [ComprobantesDetTemp_PK] PRIMARY KEY NONCLUSTERED ");
            //commandText.Append("( [clave] ASC, [Renglon] ASC ) ON [PRIMARY] ");
            //commandText.Append(") ON [PRIMARY] ");

            //commandText.Append("CREATE TABLE #ComprobantesDetDescBj( Clave int not null, ");
            //commandText.Append("ClaveDetDesc int not null, ");
            //commandText.Append("Renglon int not null, ");
            //commandText.Append("TipoDetalle varchar(1) not null, ");
            //commandText.Append("Descripcion varchar(255) null, ");
            //commandText.Append("CONSTRAINT [ComprobantesDetDescTemp_PK] PRIMARY KEY NONCLUSTERED ");
            //commandText.Append("( [Clave] ASC, [ClaveDetDesc] ASC, [Renglon] ASC ) ON [PRIMARY] ");
            //commandText.Append(") ON [PRIMARY] ");

            ////commandText = new StringBuilder();
            //for (int t = 0; t < ds.Tables.Count; t++)
            //{
            //    for (int i = 0; i < ds.Tables[t].Rows.Count; i++)
            //    {
            //        if (t == 0)
            //        {
            //            commandText.Append("INSERT #ComprobantesBj values (");
            //        }
            //        else if (t == 1)
            //        {
            //            commandText.Append("INSERT #ComprobantesDetBj values (");
            //        }
            //        else 
            //        {
            //            commandText.Append("INSERT #ComprobantesDetDescBj values (");
            //        }
            //        for (int j = 0; j < ds.Tables[t].Columns.Count; j++)
            //        {
            //            commandText.Append("'" + ds.Tables[t].Rows[i][j].ToString() + "'");
            //            if (j + 1 != ds.Tables[t].Columns.Count)
            //            {
            //                commandText.Append(", ");
            //            }
            //            else
            //            {
            //                commandText.Append(") ");
            //            }
            //        }
            //    }
            //}
            //commandText.Append("select * from #ComprobantesBj, Vendedores where #ComprobantesBj.Codigo = Vendedores.Codigo ");
            //commandText.Append("select * from #ComprobantesDetBj ");
            //commandText.Append("select * from #ComprobantesDetDescBj order by Clave asc, ClaveDetDesc asc, Renglon asc ");
            //ds = new DataSet();
            //ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);

            //if (ds.Tables.Count == 0)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            //}
            //else
            //{
            //    DataTable dt = ds.Tables[0];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        eFact_I_Bj.Entidades.ComprobanteBj Comprobante = new eFact_I_Bj.Entidades.ComprobanteBj();
            //        Comprobante.Clave = Convert.ToInt32(dt.Rows[i]["Clave"]);
            //        Comprobante.Vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
            //        Comprobante.IdTipoComprobante = Convert.ToInt16(dt.Rows[i]["Comprobante_tipo_de_comprobante"]);
            //        Comprobante.PuntoVenta = dt.Rows[i]["Comprobante_punto_de_venta"].ToString();
            //        Comprobante.NumeroComprobante = dt.Rows[i]["Comprobante_numero_comprobante"].ToString();
            //        Comprobante.Comprador.TipoDoc = Convert.ToInt16(dt.Rows[i]["Comprador_tipo_doc"]);
            //        Comprobante.Comprador.NroDoc = dt.Rows[i]["Comprador_nro_doc_identificatorio"].ToString();
            //        Comprobante.Comprador.Nombre = dt.Rows[i]["Comprador_denominacion"].ToString();
            //        Comprobante.Comprador.DomicilioCalle = dt.Rows[i]["Comprador_domicilio_calle"].ToString();
            //        Comprobante.Comprador.CondicionIVA = Convert.ToInt16(dt.Rows[i]["Comprador_condicion_IVA"]);
            //        Comprobante.Comprador.Localidad = dt.Rows[i]["Comprador_localidad"].ToString();
            //        Comprobante.Comprador.Provincia = Convert.ToInt16(dt.Rows[i]["Comprador_provincia"]);
            //        Comprobante.Comprador.CP = dt.Rows[i]["Comprador_cp"].ToString();
            //        Comprobante.Comprador.Telefono = dt.Rows[i]["Comprador_telefono"].ToString();
            //        Comprobante.Comprador.EMail = dt.Rows[i]["Comprador_email"].ToString();
            //        Comprobante.Fecha = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_emision"]);
            //        Comprobante.FechaVto = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_vencimiento"]);
            //        Comprobante.IdMoneda = dt.Rows[i]["Resumen_moneda"].ToString();
            //        Comprobante.Importe = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_factura"]);
            //        Comprobante.ImporteNetoGravado = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_neto_gravado"]);
            //        Comprobante.ImporteNetoNoGravado = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_concepto_no_gravado"]);
            //        Comprobante.ImporteOpsExentas = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_operaciones_exentas"]);
            //        Comprobante.ImpuestoLiq = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq"]);
            //        Comprobante.ImpuestoRNI = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq_rni"]);
            //        Comprobante.ImpuestosNacionales = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_impuestos_nacionales"]);
            //        Comprobante.CantAlicuotasIVA = Convert.ToInt32(dt.Rows[i]["Resumen_cant_alicuotas_iva"]);
            //        if (dt.Rows[i]["Comprobante_cae"] != System.DBNull.Value && dt.Rows[i]["Comprobante_cae"].ToString() != "")
            //        {
            //            Comprobante.NumeroCAE = dt.Rows[i]["Comprobante_cae"].ToString();
            //            Comprobante.FechaVtoCAE = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_vencimiento_cae"]);
            //        }
            //        Comprobante.Vendedor.CuitVendedor = dt.Rows[i]["CuitVendedor"].ToString();
            //        Comprobante.Vendedor.Nombre = dt.Rows[i]["Nombre"].ToString();
            //        Comprobante.Vendedor.NumeroSerieCertificado = dt.Rows[i]["NumeroSerieCertificado"].ToString();
            //        //System.IO.MemoryStream memStream = new System.IO.MemoryStream(dt.Rows[i]["Logo"]);
            //        //Byte[] logo = memStream.GetBuffer();
            //        //Comprobante.Vendedor.Logo = dt.Rows[i]["Logo"];
            //        Comprobante.Vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
            //        Comprobante.Vendedor.InicioActividades = Convert.ToDateTime(dt.Rows[i]["InicioActividades"]);
            //        Comprobante.Vendedor.Contacto = dt.Rows[i]["Contacto"].ToString();
            //        Comprobante.Vendedor.DomicilioCalle = dt.Rows[i]["DomicilioCalle"].ToString();
            //        Comprobante.Vendedor.DomicilioNumero = dt.Rows[i]["DomicilioNumero"].ToString();
            //        Comprobante.Vendedor.DomicilioPiso = dt.Rows[i]["DomicilioPiso"].ToString();
            //        Comprobante.Vendedor.DomicilioDepto = dt.Rows[i]["DomicilioDepto"].ToString();
            //        Comprobante.Vendedor.DomicilioSector = dt.Rows[i]["DomicilioSector"].ToString();
            //        Comprobante.Vendedor.DomicilioTorre = dt.Rows[i]["DomicilioTorre"].ToString();
            //        Comprobante.Vendedor.DomicilioManzana = dt.Rows[i]["DomicilioManzana"].ToString();
            //        Comprobante.Vendedor.CondicionIVA = Convert.ToInt32(dt.Rows[i]["CondicionIVA"]);
            //        Comprobante.Vendedor.CondicionIB = Convert.ToInt32(dt.Rows[i]["CondicionIB"]);
            //        Comprobante.Vendedor.NroIB = dt.Rows[i]["NroIB"].ToString();
            //        Comprobante.Vendedor.Localidad = dt.Rows[i]["Localidad"].ToString();
            //        Comprobante.Vendedor.Provincia = dt.Rows[i]["Provincia"].ToString();
            //        Comprobante.Vendedor.CP = dt.Rows[i]["CP"].ToString();
            //        Comprobante.Vendedor.Telefono = dt.Rows[i]["Telefono"].ToString();
            //        Comprobante.Vendedor.EMail = dt.Rows[i]["EMail"].ToString();
            //        DataRow[] drDetDesc = ds.Tables[2].Select("Clave = " + Comprobante.Clave);
            //        for (int j = 0; j < drDetDesc.Length; j++)
            //        {
            //            eFact_I_Bj.Entidades.ComprobanteBjLinea linea = new eFact_I_Bj.Entidades.ComprobanteBjLinea();
            //            if (drDetDesc[j]["TipoDetalle"].ToString() == "C")
            //            {
            //                DataRow[] dr = ds.Tables[1].Select("Clave = " + Convert.ToInt32(drDetDesc[j]["Clave"].ToString()) + " and Renglon = " + Convert.ToInt32(drDetDesc[j]["Renglon"].ToString()));
            //                linea.Clave = Convert.ToInt32(Comprobante.Clave);
            //                linea.Renglon = Convert.ToInt32(drDetDesc[j]["Renglon"]);
            //                linea.Descripcion = dr[0]["Linea_descripcion"].ToString();
            //                linea.Cantidad = Convert.ToDecimal(dr[0]["Linea_cantidad"]);
            //                linea.Precio_unitario = Convert.ToDecimal(dr[0]["Linea_precio_unitario"]);
            //                linea.Alicuota_iva = Convert.ToDecimal(dr[0]["Linea_alicuota_iva"]);
            //                linea.Importe_iva = Convert.ToDecimal(dr[0]["Linea_importe_iva"]);
            //                linea.Indicacion_exento_gravado = dr[0]["Linea_indicacion_exento_gravado"].ToString();
            //                linea.Importe_total_descuentos = Convert.ToDecimal(dr[0]["Linea_importe_total_descuentos"]);
            //                linea.Importe_total_impuestos = Convert.ToDecimal(dr[0]["Linea_Importe_total_impuestos"]);
            //                linea.Importe_total_articulo = Convert.ToDecimal(dr[0]["Linea_Importe_total_articulo"]);
            //            }
            //            else
            //            {
            //                linea.Clave = Convert.ToInt32(drDetDesc[j]["Clave"]);
            //                linea.Renglon = Convert.ToInt32(drDetDesc[j]["Renglon"]);
            //                linea.Descripcion = drDetDesc[j]["Descripcion"].ToString();
            //                linea.Cantidad = Convert.ToDecimal(0);
            //                linea.Precio_unitario = Convert.ToDecimal(0);
            //                linea.Alicuota_iva = Convert.ToDecimal(0);
            //                linea.Importe_iva = Convert.ToDecimal(0);
            //                linea.Indicacion_exento_gravado = "N";
            //                linea.Importe_total_descuentos = Convert.ToDecimal(0);
            //                linea.Importe_total_impuestos = Convert.ToDecimal(0);
            //                linea.Importe_total_articulo = Convert.ToDecimal(0);
            //            }
            //            Comprobante.Lineas.Add(linea);
            //        }
            //        Comprobantes.Add(Comprobante);
            //    }
            //}

        }
    }
}
