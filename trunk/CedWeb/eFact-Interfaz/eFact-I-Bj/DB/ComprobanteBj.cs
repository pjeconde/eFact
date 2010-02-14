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
        public void Consultar(List<eFact_I_Bj.Entidades.ComprobanteBj> Comprobantes, eFact_I_Bj.RN.TableroBj.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string IdTipoComprobante, string PuntoVenta, string NumeroComprobante, bool VerificarExistenciaCAE)
        {
            //Tabla IVA Bj
            //1 - 'Responsable inscripto'
            //2 - 'Responsable no inscripto'
            //5 - 'exento'
            //3 - 'consumidor final'
            //4 - 'no responsable'
            //6 - 'Monotributo'
            StringBuilder commandText = new StringBuilder();
            commandText.Append("select cve_ID as Clave, CASE clitdc_Cod WHEN 1 THEN '80' ELSE '' END as Comprador_tipo_doc, cvecli_CUIT as Comprador_nro_doc_identificatorio, cvecli_RazSoc as Comprador_denominacion, cvecli_NroIB as Comprador_nro_ingresos_brutos, ");
            commandText.Append("CASE clisiv_Cod WHEN 1 THEN '1' WHEN 2 THEN '2' WHEN 3 THEN '5' WHEN 4 THEN '3' WHEN 5 THEN '4' WHEN 6 THEN '6' ELSE '' END as Comprador_condicion_IVA, cli_Direc as Comprador_domicilio_calle, ");
            commandText.Append("cli_Loc as Comprador_localidad, convert(int, cliprv_Codigo) as Comprador_provincia, cli_CodPos as Comprador_cp, cli_EMail as Comprador_email, cli_Tel as Comprador_telefono, ");
            commandText.Append("CASE cvetal_Cod WHEN 'FEA' THEN '1' WHEN 'DEA' THEN '2' WHEN 'CEA' THEN '3' WHEN 'FEB' THEN '6' WHEN 'DEB' THEN '7' WHEN 'CEB' THEN '8' ELSE '' END as Comprobante_tipo_de_comprobante, ");
            commandText.Append("cvetco_Cod as Comprobante_AdicTipoComp, cve_Letra as Comprobante_AdicTipoCompLetra, cve_Nro as Comprobante_numero_comprobante, cvepvt_CodIN as Comprobante_punto_de_venta, ");
            commandText.Append("cve_FEmision as Comprobante_fecha_emision, cve_FVto as Comprobante_fecha_vencimiento, cvecvt_Cod as Comprobante_condicion_de_pago, ");
            commandText.Append("cve_NroCAITal as Comprobante_cae, cve_FVtoCAITal as Comprobante_fecha_vencimiento_cae, ");
            commandText.Append("cveemp_Codigo as Codigo, ");
            commandText.Append("'PES' as Resumen_moneda, ");
            commandText.Append("cve_ImpMonLoc as Resumen_importe_total_factura, (select Sum(ive_IInscLoc +  ive_INoInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_importe_total_impuestos_nacionales, ");
            commandText.Append("(select Sum(ive_IInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_impuesto_liq, ");
            commandText.Append("(select Sum(ive_INoInscLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_impuesto_liq_rni, ");
            commandText.Append("(select Sum(ive_NetoLoc) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID) as Resumen_importe_total_neto_gravado, ");
            commandText.Append("0 as Resumen_importe_total_concepto_no_gravado, 0 as Resumen_importe_operaciones_exentas, ");
            commandText.Append("(select Count(Distinct(ive_TInsc)) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID and ive_TInsc <> 0) + (select Count(Distinct(ive_TNoInsc)) from ItemVta where ItemVta.ivecve_ID=CabVenta.cve_ID and ive_TNoInsc <> 0) as Resumen_cant_alicuotas_iva, cvescv_ID as ClaveDetDesc ");
            commandText.Append("INTO #CabVenta ");
            commandText.Append("from CabVenta, Clientes, puntoVta ");
            commandText.Append("where CabVenta.cve_CodCli *= Clientes.cli_cod and CabVenta.cvepvt_CodIN = puntoVta.pvt_cod and puntoVta.pvt_factelec = 'S' ");
            commandText.Append("and (cve_FEmision >='" + FechaDsd.ToString("yyyyMMdd") + "' and cve_FEmision < Dateadd (Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "')) ");
            if (IdTipoComprobante != "" && IdTipoComprobante != "0")
            {
                string tipoComprobante = "";
                switch (IdTipoComprobante)
                {
                    case "1":
                        tipoComprobante = "FEA";
                        break;
                    case "2":
                        tipoComprobante = "DEA";
                        break;
                    case "3":
                        tipoComprobante = "CEA";
                        break;
                    case "6":
                        tipoComprobante = "FEB";
                        break;
                    case "7":
                        tipoComprobante = "DEB";
                        break;
                    case "8":
                        tipoComprobante = "CEB";
                        break;
                    default:
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Tipo de comprobantes no permitido.\r\n\r\nSolo pueden ser seleccionados los siguientes tipos de comprobantes:\r\nFactura A o B.\r\nNota de Débito A o B.\r\nNota de Crédito A o B.");
                }
                commandText.Append("and cvetal_Cod = '" + tipoComprobante + "' ");
            }
            if (PuntoVenta != "")
            {
                commandText.Append("and (cvepvt_CodIN = '" + PuntoVenta + "' or convert(int, cvepvt_CodIN) = " + Convert.ToInt32(PuntoVenta) + ") ");
            }
            if (NumeroComprobante != "")
            {
                commandText.Append("and (cve_Nro = '" + NumeroComprobante + "' or convert(int, cve_Nro) = " + Convert.ToInt32(NumeroComprobante) + ") ");
            }
            if (VerificarExistenciaCAE)
            {
                commandText.Append("and (cve_NroCAITal <> null or cve_NroCAITal <> '') ");
            }
            //Select Cabeza del Comprobante
            commandText.Append("Select * from #CabVenta ");
            //Select Toteles por Item
            commandText.Append("Select ivecve_ID as Clave, ive_NReng as Renglon, ive_Desc as Linea_descripcion, ive_CantUM1 as Linea_cantidad, ive_NetoLoc as Linea_precio_unitario, ive_TInsc + ive_TNoInsc as Linea_alicuota_iva, ive_IInscLoc + ive_INoInscLoc as Linea_importe_iva, ");
            commandText.Append("CASE ive_tipoTasa WHEN 1 THEN 'G' ELSE 'E' END as Linea_indicacion_exento_gravado, ");
            commandText.Append("0 as Linea_importe_total_descuentos, ive_IInscLoc + ive_INoInscLoc as Linea_importe_total_impuestos, ");
            commandText.Append("ive_NetoLoc + ive_IInscLoc + ive_INoInscLoc as Linea_importe_total_articulo ");
            commandText.Append("from #CabVenta, ItemVta ");
            commandText.Append("where #CabVenta.Clave = ItemVta.ivecve_ID ");
            //Select Detalle completo de la Descripcion del Item
            commandText.Append("Select #CabVenta.Clave, #CabVenta.ClaveDetDesc, sdv_NReng as Renglon, sdv_TipoIt as TipoDetalle, sdv_Desc as Descripcion ");
            commandText.Append("from #CabVenta, SegDetV ");
            commandText.Append("where #CabVenta.ClaveDetDesc = SegDetV.sdvscv_ID ");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStrAplicExterna);

            commandText = new StringBuilder();
            commandText.Append("CREATE TABLE #ComprobantesBj( Clave int not null, ");
            commandText.Append("Comprador_tipo_doc varchar(2) not null, ");
            commandText.Append("Comprador_nro_doc_identificatorio varchar(11) not null, ");
            commandText.Append("Comprador_denominacion varchar(40) not null, ");
            commandText.Append("Comprador_nro_ingresos_brutos varchar(15) not null, "); 
            commandText.Append("Comprador_condicion_IVA varchar(1) not null, ");
            commandText.Append("Comprador_domicilio_calle varchar(30) null, ");								
            commandText.Append("Comprador_localidad varchar(25) null, ");
            commandText.Append("Comprador_provincia int null, "); 
            commandText.Append("Comprador_cp varchar(8) null, "); 								
            commandText.Append("Comprador_email varchar(50) null, "); 
            commandText.Append("Comprador_telefono varchar(30) null, ");
            commandText.Append("Comprobante_tipo_de_comprobante varchar(1) not null, "); 
            commandText.Append("Comprobante_AdicTipoComp varchar(3) not null, "); 
            commandText.Append("Comprobante_AdicTipoCompLetra varchar(1) not null, "); 
            commandText.Append("Comprobante_numero_comprobante varchar(8) not null, "); 
            commandText.Append("Comprobante_punto_de_venta varchar(4) not null, "); 
            commandText.Append("Comprobante_fecha_emision datetime not null, "); 
            commandText.Append("Comprobante_fecha_vencimiento datetime not null, "); 
            commandText.Append("Comprobante_condicion_de_pago varchar(3) null, "); 
            commandText.Append("Comprobante_cae	varchar(15) null, ");
            commandText.Append("Comprobante_fecha_vencimiento_cae datetime not null, ");
            commandText.Append("Codigo varchar(255) not null, ");
            commandText.Append("Resumen_moneda	varchar(5) not null, ");
            commandText.Append("Resumen_importe_total_factura decimal(18,2) not null, ");
            commandText.Append("Resumen_importe_total_impuestos_nacionales decimal(18,2) not null, ");
            commandText.Append("Resumen_impuesto_liq decimal(18,2) not null, ");
            commandText.Append("Resumen_impuesto_liq_rni decimal(18,2) not null, ");
            commandText.Append("Resumen_importe_total_neto_gravado decimal(18,2) not null, ");
            commandText.Append("Resumen_importe_total_concepto_no_gravado decimal(18,2) not null, ");
            commandText.Append("Resumen_importe_operaciones_exentas decimal(18,2) not null, ");
            commandText.Append("Resumen_cant_alicuotas_iva decimal(18,2) not null, ");
            commandText.Append("ClaveDetDesc int not null, ");
            commandText.Append("CONSTRAINT [ComprobantesTemp_PK] PRIMARY KEY NONCLUSTERED ");
            commandText.Append("( [clave] ASC ) ON [PRIMARY] ");
            commandText.Append(") ON [PRIMARY] ");
            
            commandText.Append("CREATE TABLE #ComprobantesDetBj( Clave int not null, ");
            commandText.Append("Renglon int not null, ");
            commandText.Append("Linea_descripcion varchar(255) not null, ");
            commandText.Append("Linea_cantidad decimal(18,2) not null, ");
            commandText.Append("Linea_precio_unitario decimal(18,2) not null, ");
            commandText.Append("Linea_alicuota_iva decimal(18,2) not null, ");
            commandText.Append("Linea_importe_iva decimal(18,2) null, ");
            commandText.Append("Linea_indicacion_exento_gravado varchar(1) null, ");
            commandText.Append("Linea_importe_total_descuentos decimal(18,2) null, ");
            commandText.Append("Linea_importe_total_impuestos decimal(18,2) null, ");
            commandText.Append("Linea_importe_total_articulo decimal(18,2) null, ");
            commandText.Append("CONSTRAINT [ComprobantesDetTemp_PK] PRIMARY KEY NONCLUSTERED ");
            commandText.Append("( [clave] ASC, [Renglon] ASC ) ON [PRIMARY] ");
            commandText.Append(") ON [PRIMARY] ");

            commandText.Append("CREATE TABLE #ComprobantesDetDescBj( Clave int not null, ");
            commandText.Append("ClaveDetDesc int not null, ");
            commandText.Append("Renglon int not null, ");
            commandText.Append("TipoDetalle varchar(1) not null, ");
            commandText.Append("Descripcion varchar(255) null, ");
            commandText.Append("CONSTRAINT [ComprobantesDetDescTemp_PK] PRIMARY KEY NONCLUSTERED ");
            commandText.Append("( [Clave] ASC, [ClaveDetDesc] ASC, [Renglon] ASC ) ON [PRIMARY] ");
            commandText.Append(") ON [PRIMARY] ");

            //commandText = new StringBuilder();
            for (int t = 0; t < ds.Tables.Count; t++)
            {
                for (int i = 0; i < ds.Tables[t].Rows.Count; i++)
                {
                    if (t == 0)
                    {
                        commandText.Append("INSERT #ComprobantesBj values (");
                    }
                    else if (t == 1)
                    {
                        commandText.Append("INSERT #ComprobantesDetBj values (");
                    }
                    else 
                    {
                        commandText.Append("INSERT #ComprobantesDetDescBj values (");
                    }
                    for (int j = 0; j < ds.Tables[t].Columns.Count; j++)
                    {
                        commandText.Append("'" + ds.Tables[t].Rows[i][j].ToString() + "'");
                        if (j + 1 != ds.Tables[t].Columns.Count)
                        {
                            commandText.Append(", ");
                        }
                        else
                        {
                            commandText.Append(") ");
                        }
                    }
                }
            }
            commandText.Append("select * from #ComprobantesBj, Vendedores where #ComprobantesBj.Codigo = Vendedores.Codigo ");
            commandText.Append("select * from #ComprobantesDetBj ");
            commandText.Append("select * from #ComprobantesDetDescBj order by Clave asc, ClaveDetDesc asc, Renglon asc ");
            ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Acepta, sesion.CnnStr);

            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eFact_I_Bj.Entidades.ComprobanteBj Comprobante = new eFact_I_Bj.Entidades.ComprobanteBj();
                    Comprobante.Clave = Convert.ToInt32(dt.Rows[i]["Clave"]);
                    Comprobante.Vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
                    Comprobante.IdTipoComprobante = Convert.ToInt16(dt.Rows[i]["Comprobante_tipo_de_comprobante"]);
                    Comprobante.PuntoVenta = dt.Rows[i]["Comprobante_punto_de_venta"].ToString();
                    Comprobante.NumeroComprobante = dt.Rows[i]["Comprobante_numero_comprobante"].ToString();
                    Comprobante.Comprador.TipoDoc = Convert.ToInt16(dt.Rows[i]["Comprador_tipo_doc"]);
                    Comprobante.Comprador.NroDoc = dt.Rows[i]["Comprador_nro_doc_identificatorio"].ToString();
                    Comprobante.Comprador.Nombre = dt.Rows[i]["Comprador_denominacion"].ToString();
                    Comprobante.Comprador.DomicilioCalle = dt.Rows[i]["Comprador_domicilio_calle"].ToString();
                    Comprobante.Comprador.CondicionIVA = Convert.ToInt16(dt.Rows[i]["Comprador_condicion_IVA"]);
                    Comprobante.Comprador.Localidad = dt.Rows[i]["Comprador_localidad"].ToString();
                    Comprobante.Comprador.Provincia = Convert.ToInt16(dt.Rows[i]["Comprador_provincia"]);
                    Comprobante.Comprador.CP = dt.Rows[i]["Comprador_cp"].ToString();
                    Comprobante.Comprador.Telefono = dt.Rows[i]["Comprador_telefono"].ToString();
                    Comprobante.Comprador.EMail = dt.Rows[i]["Comprador_email"].ToString();
                    Comprobante.Fecha = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_emision"]);
                    Comprobante.FechaVto = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_vencimiento"]);
                    Comprobante.IdMoneda = dt.Rows[i]["Resumen_moneda"].ToString();
                    Comprobante.Importe = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_factura"]);
                    Comprobante.ImporteNetoGravado = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_neto_gravado"]);
                    Comprobante.ImporteNetoNoGravado = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_concepto_no_gravado"]);
                    Comprobante.ImporteOpsExentas = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_operaciones_exentas"]);
                    Comprobante.ImpuestoLiq = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq"]);
                    Comprobante.ImpuestoRNI = Convert.ToDecimal(dt.Rows[i]["Resumen_impuesto_liq_rni"]);
                    Comprobante.ImpuestosNacionales = Convert.ToDecimal(dt.Rows[i]["Resumen_importe_total_impuestos_nacionales"]);
                    Comprobante.CantAlicuotasIVA = Convert.ToInt32(dt.Rows[i]["Resumen_cant_alicuotas_iva"]);
                    if (dt.Rows[i]["Comprobante_cae"] != System.DBNull.Value && dt.Rows[i]["Comprobante_cae"].ToString() != "")
                    {
                        Comprobante.NumeroCAE = dt.Rows[i]["Comprobante_cae"].ToString();
                        Comprobante.FechaVtoCAE = Convert.ToDateTime(dt.Rows[i]["Comprobante_fecha_vencimiento_cae"]);
                    }
                    Comprobante.Vendedor.CuitVendedor = dt.Rows[i]["CuitVendedor"].ToString();
                    Comprobante.Vendedor.Nombre = dt.Rows[i]["Nombre"].ToString();
                    Comprobante.Vendedor.NumeroSerieCertificado = dt.Rows[i]["NumeroSerieCertificado"].ToString();
                    //System.IO.MemoryStream memStream = new System.IO.MemoryStream(dt.Rows[i]["Logo"]);
                    //Byte[] logo = memStream.GetBuffer();
                    //Comprobante.Vendedor.Logo = dt.Rows[i]["Logo"];
                    Comprobante.Vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
                    Comprobante.Vendedor.InicioActividades = Convert.ToDateTime(dt.Rows[i]["InicioActividades"]);
                    Comprobante.Vendedor.Contacto = dt.Rows[i]["Contacto"].ToString();
                    Comprobante.Vendedor.DomicilioCalle = dt.Rows[i]["DomicilioCalle"].ToString();
                    Comprobante.Vendedor.DomicilioNumero = dt.Rows[i]["DomicilioNumero"].ToString();
                    Comprobante.Vendedor.DomicilioPiso = dt.Rows[i]["DomicilioPiso"].ToString();
                    Comprobante.Vendedor.DomicilioDepto = dt.Rows[i]["DomicilioDepto"].ToString();
                    Comprobante.Vendedor.DomicilioSector = dt.Rows[i]["DomicilioSector"].ToString();
                    Comprobante.Vendedor.DomicilioTorre = dt.Rows[i]["DomicilioTorre"].ToString();
                    Comprobante.Vendedor.DomicilioManzana = dt.Rows[i]["DomicilioManzana"].ToString();
                    Comprobante.Vendedor.CondicionIVA = Convert.ToInt32(dt.Rows[i]["CondicionIVA"]);
                    Comprobante.Vendedor.CondicionIB = Convert.ToInt32(dt.Rows[i]["CondicionIB"]);
                    Comprobante.Vendedor.NroIB = dt.Rows[i]["NroIB"].ToString();
                    Comprobante.Vendedor.Localidad = dt.Rows[i]["Localidad"].ToString();
                    Comprobante.Vendedor.Provincia = dt.Rows[i]["Provincia"].ToString();
                    Comprobante.Vendedor.CP = dt.Rows[i]["CP"].ToString();
                    Comprobante.Vendedor.Telefono = dt.Rows[i]["Telefono"].ToString();
                    Comprobante.Vendedor.EMail = dt.Rows[i]["EMail"].ToString();
                    DataRow[] drDetDesc = ds.Tables[2].Select("Clave = " + Comprobante.Clave);
                    for (int j = 0; j < drDetDesc.Length; j++)
                    {
                        eFact_I_Bj.Entidades.ComprobanteBjLinea linea = new eFact_I_Bj.Entidades.ComprobanteBjLinea();
                        if (drDetDesc[j]["TipoDetalle"].ToString() == "C")
                        {
                            DataRow[] dr = ds.Tables[1].Select("Clave = " + Convert.ToInt32(drDetDesc[j]["Clave"].ToString()) + " and Renglon = " + Convert.ToInt32(drDetDesc[j]["Renglon"].ToString()));
                            linea.Clave = Convert.ToInt32(Comprobante.Clave);
                            linea.Renglon = Convert.ToInt32(drDetDesc[j]["Renglon"]);
                            linea.Descripcion = dr[0]["Linea_descripcion"].ToString();
                            linea.Cantidad = Convert.ToDecimal(dr[0]["Linea_cantidad"]);
                            linea.Precio_unitario = Convert.ToDecimal(dr[0]["Linea_precio_unitario"]);
                            linea.Alicuota_iva = Convert.ToDecimal(dr[0]["Linea_alicuota_iva"]);
                            linea.Importe_iva = Convert.ToDecimal(dr[0]["Linea_importe_iva"]);
                            linea.Indicacion_exento_gravado = dr[0]["Linea_indicacion_exento_gravado"].ToString();
                            linea.Importe_total_descuentos = Convert.ToDecimal(dr[0]["Linea_importe_total_descuentos"]);
                            linea.Importe_total_impuestos = Convert.ToDecimal(dr[0]["Linea_Importe_total_impuestos"]);
                            linea.Importe_total_articulo = Convert.ToDecimal(dr[0]["Linea_Importe_total_articulo"]);
                        }
                        else
                        {
                            linea.Clave = Convert.ToInt32(drDetDesc[j]["Clave"]);
                            linea.Renglon = Convert.ToInt32(drDetDesc[j]["Renglon"]);
                            linea.Descripcion = drDetDesc[j]["Descripcion"].ToString();
                            linea.Cantidad = Convert.ToDecimal(0);
                            linea.Precio_unitario = Convert.ToDecimal(0);
                            linea.Alicuota_iva = Convert.ToDecimal(0);
                            linea.Importe_iva = Convert.ToDecimal(0);
                            linea.Indicacion_exento_gravado = "N";
                            linea.Importe_total_descuentos = Convert.ToDecimal(0);
                            linea.Importe_total_impuestos = Convert.ToDecimal(0);
                            linea.Importe_total_articulo = Convert.ToDecimal(0);
                        }
                        Comprobante.Lineas.Add(linea);
                    }
                    Comprobantes.Add(Comprobante);
                }
            }

        }
    }
}
