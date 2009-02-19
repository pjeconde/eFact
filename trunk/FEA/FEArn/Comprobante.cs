using System;
using System.Collections.Generic;
using System.Text;

namespace Hola MundoFEArn
{
	public class Comprobante
	{
		const string DEFAULT_SERVICIO = "wsfe";
		string rutaCertificado;
		long cuit;
		FEArn.ar.gov.afip.wsw.FEAuthRequest objAutorizacion;
		FEArn.ar.gov.afip.wsw.Service objWSFE;
		System.Net.WebProxy wp;
		FEArn.ar.gov.afip.wsw.FEResponse objFEResponse;
		FEAdb.db db;
		static Sesion sesion;

		public Comprobante(string urlWsaa, string urlWsfe, string RutaCertificado, long Cuit, Sesion Sesion, System.Net.WebProxy Wp)
		{
			sesion = Sesion;
			cuit = Cuit;
			rutaCertificado = RutaCertificado;
			LoginTicket objTicketRespuesta;
			string strTicketRespuesta;
			objTicketRespuesta = new LoginTicket();
			strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(DEFAULT_SERVICIO, urlWsaa, RutaCertificado, false, Wp);
			objAutorizacion = new FEArn.ar.gov.afip.wsw.FEAuthRequest();
			objAutorizacion.Token = objTicketRespuesta.Token;
			objAutorizacion.Sign = objTicketRespuesta.Sign;
			objAutorizacion.cuit = cuit;
			objFEResponse = new FEArn.ar.gov.afip.wsw.FEResponse();
			objFEResponse.RError = new FEArn.ar.gov.afip.wsw.vError();
			db = new FEAdb.db(sesion);
			objWSFE = new FEArn.ar.gov.afip.wsw.Service();
			objWSFE.Url = urlWsfe;
			objWSFE.Proxy = Wp;
		}

		public FEArn.ar.gov.afip.wsw.FEAuthRequest ObjAutorizacion
		{
			get { return objAutorizacion; }
			set { objAutorizacion = value; }
		}

		public FEArn.ar.gov.afip.wsw.Service ObjWSFE
		{
			get { return objWSFE; }
			set { objWSFE = value; }
		}

		public System.Net.WebProxy Wp
		{
			get { return wp; }
			set { wp = value; }
		}

		public void Enviar(FeaEntidades.Comprobante Comprobante)
		{
			try
			{

				/*Limpio resultados del comprobante anterior*/

				Comprobante.Resultado = string.Empty;
				Comprobante.Motivo = string.Empty;
				Comprobante.MensajeError = string.Empty;
				Comprobante.Cae = string.Empty;

				FEArn.ar.gov.afip.wsw.FERequest objFERequest = new FEArn.ar.gov.afip.wsw.FERequest();

				FEArn.ar.gov.afip.wsw.FECabeceraRequest objFECabeceraRequest = new FEArn.ar.gov.afip.wsw.FECabeceraRequest();
				objFECabeceraRequest.cantidadreg = 1;

				/*
				 Obtengo última transacción y sumo 1
				 */

				FEArn.ar.gov.afip.wsw.FEUltNroResponse objFEUltNroResponse = new FEArn.ar.gov.afip.wsw.FEUltNroResponse();
				objFEUltNroResponse = objWSFE.FEUltNroRequest(objAutorizacion);

				Comprobante.IdTransaccion = objFEUltNroResponse.nro.value + 1;
				objFECabeceraRequest.id = Comprobante.IdTransaccion;
				objFECabeceraRequest.presta_serv = Convert.ToInt32(Comprobante.Presta_serv);
				objFERequest.Fecr = objFECabeceraRequest;

				FEArn.ar.gov.afip.wsw.FEDetalleRequest[] arrayFEDetalleRequest = new FEArn.ar.gov.afip.wsw.FEDetalleRequest[1];
				FEArn.ar.gov.afip.wsw.FEDetalleRequest objFEDetalleRequest = new FEArn.ar.gov.afip.wsw.FEDetalleRequest();

				/*
				 Obtengo último comprobante y sumo 1
				 */

				FEArn.ar.gov.afip.wsw.FERecuperaLastCMPResponse objFERecuperaLastCMPResponse = new FEArn.ar.gov.afip.wsw.FERecuperaLastCMPResponse();
				FEArn.ar.gov.afip.wsw.FELastCMPtype tipoComprobante = new FEArn.ar.gov.afip.wsw.FELastCMPtype();
				tipoComprobante.PtoVta = Comprobante.PuntoVenta;
				tipoComprobante.TipoCbte = Comprobante.Codigo;

				objFERecuperaLastCMPResponse = objWSFE.FERecuperaLastCMPRequest(objAutorizacion, tipoComprobante);

				Comprobante.IdComprobante = objFERecuperaLastCMPResponse.cbte_nro + 1;

				objFEDetalleRequest.cbt_desde = Comprobante.IdComprobante;
				objFEDetalleRequest.cbt_hasta = Comprobante.IdComprobante;

				objFEDetalleRequest.fecha_cbte = Comprobante.Fecha_cbte.ToString("yyyyMMdd");
				objFEDetalleRequest.fecha_serv_desde = Comprobante.Fecha_serv_desde.ToString("yyyyMMdd");
				objFEDetalleRequest.fecha_serv_hasta = Comprobante.Fecha_serv_hasta.ToString("yyyyMMdd");
				objFEDetalleRequest.fecha_venc_pago = Comprobante.Fecha_venc_pago.ToString("yyyyMMdd");
				objFEDetalleRequest.imp_neto = Comprobante.Imp_neto;
				objFEDetalleRequest.imp_op_ex = Comprobante.Imp_op_ex;
				objFEDetalleRequest.imp_tot_conc = Comprobante.Imp_tot_conc;
				objFEDetalleRequest.imp_total = Comprobante.Imp_total;
				objFEDetalleRequest.impto_liq = Comprobante.Impto_liq;
				objFEDetalleRequest.impto_liq_rni = Comprobante.Impto_liq_rni;
				objFEDetalleRequest.nro_doc = Comprobante.Nro_doc;
				objFEDetalleRequest.punto_vta = Comprobante.PuntoVenta;
				objFEDetalleRequest.tipo_cbte = Comprobante.Codigo;
				objFEDetalleRequest.tipo_doc = Comprobante.TipoDoc;

				arrayFEDetalleRequest[0] = objFEDetalleRequest;
				objFERequest.Fedr = arrayFEDetalleRequest;

				objFEResponse = objWSFE.FEAutRequest(objAutorizacion, objFERequest);
				if (objFEResponse.FedResp != null)
				{
					Comprobante.Motivo = objFEResponse.FedResp[0].motivo;
					Comprobante.Resultado = objFEResponse.FedResp[0].resultado;
					Comprobante.Cae = objFEResponse.FedResp[0].cae;
				}
				else
				{
					Comprobante.IdComprobante = 0;
					Comprobante.IdTransaccion = 0;
				}
				Comprobante.MensajeError = objFEResponse.RError.perrmsg;

				FEAdb.dbComprobante db = new FEAdb.dbComprobante(sesion);
				try
				{
					db.Comprobante_ins(DateTime.Now, Comprobante.IdTransaccion, Comprobante.IdComprobante, Comprobante.PuntoVenta,
						Comprobante.Codigo, Comprobante.DescrCodigo, Comprobante.Nro_doc, Comprobante.TipoDoc,
						Comprobante.DescrTipoDoc, Comprobante.Fecha_cbte, Comprobante.Fecha_serv_desde, Comprobante.Fecha_serv_hasta,
						Comprobante.Fecha_venc_pago, Comprobante.Imp_neto, Comprobante.Imp_op_ex, Comprobante.Imp_tot_conc,
						Comprobante.Impto_liq, Comprobante.Impto_liq_rni, Comprobante.Imp_total, Comprobante.Cae, Comprobante.Motivo,
						Comprobante.Resultado, Comprobante.Presta_serv, Comprobante.MensajeError);
				}
				catch (MySql.Data.MySqlClient.MySqlException)
				{
					System.Threading.Thread.Sleep(1000);
					db.Comprobante_ins(DateTime.Now, Comprobante.IdTransaccion, Comprobante.IdComprobante, Comprobante.PuntoVenta,
						Comprobante.Codigo, Comprobante.DescrCodigo, Comprobante.Nro_doc, Comprobante.TipoDoc,
						Comprobante.DescrTipoDoc, Comprobante.Fecha_cbte, Comprobante.Fecha_serv_desde, Comprobante.Fecha_serv_hasta,
						Comprobante.Fecha_venc_pago, Comprobante.Imp_neto, Comprobante.Imp_op_ex, Comprobante.Imp_tot_conc,
						Comprobante.Impto_liq, Comprobante.Impto_liq_rni, Comprobante.Imp_total, Comprobante.Cae, Comprobante.Motivo,
						Comprobante.Resultado, Comprobante.Presta_serv, Comprobante.MensajeError);
				}
			}
			catch (Exception ex)
			{
				Cedeira.Ex.ExceptionManager.Publish(ex);
			}
		}
		public static List<FeaEntidades.Comprobante> Lista(Sesion Sesion)
		{
			List<FeaEntidades.Comprobante> comprobantesLista = new List<FeaEntidades.Comprobante>();
			FEAdb.dbComprobante db = new FEAdb.dbComprobante(Sesion);
			System.Data.DataTable dt = db.Comprobante_qry();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				FeaEntidades.Comprobante cdt = new FeaEntidades.Comprobante();
				cdt.FechaImpacto = Convert.ToDateTime(dt.Rows[i]["FechaImpacto"]);
				cdt.Cae = Convert.ToString(dt.Rows[i]["CAE"]);
				cdt.Fecha_cbte = Convert.ToDateTime(dt.Rows[i]["Fecha"]);
				cdt.Fecha_serv_desde = Convert.ToDateTime(dt.Rows[i]["FechaServicioDesde"]);
				cdt.Fecha_serv_hasta = Convert.ToDateTime(dt.Rows[i]["FechaServicioHasta"]);
				cdt.Fecha_venc_pago = Convert.ToDateTime(dt.Rows[i]["FechaVencPago"]);
				cdt.IdTransaccion = Convert.ToInt64(dt.Rows[i]["IdTransaccion"]);
				cdt.Imp_neto = Convert.ToDouble(dt.Rows[i]["Neto"]);
				cdt.Imp_op_ex = Convert.ToDouble(dt.Rows[i]["Exento"]);
				cdt.Imp_tot_conc = Convert.ToDouble(dt.Rows[i]["TotalConceptos"]);
				cdt.Imp_total = Convert.ToDouble(dt.Rows[i]["Total"]);
				cdt.Impto_liq = Convert.ToDouble(dt.Rows[i]["ImpuestoLiq"]);
				cdt.Impto_liq_rni = Convert.ToDouble(dt.Rows[i]["ImpuestoLiqRNI"]);
				cdt.Motivo = Convert.ToString(dt.Rows[i]["Motivo"]);
				cdt.Nro_doc = Convert.ToInt64(dt.Rows[i]["NroDoc"]);
				cdt.PuntoVenta = Convert.ToInt16(dt.Rows[i]["PuntoVenta"]);
				cdt.Resultado = Convert.ToString(dt.Rows[i]["Resultado"]);
				cdt.TipoDoc = Convert.ToInt16(dt.Rows[i]["TipoDoc"]);
				cdt.DescrTipoDoc = Convert.ToString(dt.Rows[i]["DescrTipoDoc"]);
				cdt.Codigo = Convert.ToInt16(dt.Rows[i]["Codigo"]);
				cdt.DescrCodigo = Convert.ToString(dt.Rows[i]["DescrCodigo"]);
				cdt.IdComprobante = Convert.ToInt32(dt.Rows[i]["IdComprobante"]);
				cdt.Presta_serv = Convert.ToBoolean(dt.Rows[i]["PrestaServicio"]);
				cdt.MensajeError = Convert.ToString(dt.Rows[i]["MensajeError"]);


				comprobantesLista.Add(cdt);
			}
			return comprobantesLista;
		}
	}
}
