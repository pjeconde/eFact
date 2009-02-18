using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FEA
{
	public partial class PrincipalForm : Form
	{
		public PrincipalForm()
		{
			InitializeComponent();
			ComprobantesDataGridView.DataSource = FEArn.Comprobante.Lista(Aplicacion.Sesion);
		}

		private void ticketButton_Click(object sender, EventArgs e)
		{
			//string strUrlWsaaWsdl = DEFAULT_URLWSAAWSDL;
			//string strIdServicioNegocio = DEFAULT_SERVICIO;
			//string strRutaCertSigner = DEFAULT_CERTSIGNER;
			//bool blnVerboseMode = DEFAULT_VERBOSE;

			//LoginTicket objTicketRespuesta;
			//string strTicketRespuesta;

			//try
			//{
			//    objTicketRespuesta = new LoginTicket();

			//    strTicketRespuesta = objTicketRespuesta.ObtenerLoginTicketResponse(strIdServicioNegocio, strUrlWsaaWsdl, strRutaCertSigner, blnVerboseMode, wp);

			//    objAutorizacion.Token = objTicketRespuesta.Token;
			//    objAutorizacion.Sign = objTicketRespuesta.Sign;
			//    objAutorizacion.cuit = CUIT;

			//    tokenTextBox.Text = objAutorizacion.Token;
			//    signTextBox.Text = objAutorizacion.Sign;
			//    cuitTextBox.Text = Convert.ToString(CUIT);
			//}
			//catch (Exception excepcionAlObtenerTicket)
			//{
			//    Console.WriteLine("***Excepcion al obtener ticket: Main: ");
			//    Console.WriteLine(excepcionAlObtenerTicket.Message);
			//    tokenTextBox.Text = excepcionAlObtenerTicket.Message;
			//}
		}

		private void ultNroButton_Click(object sender, EventArgs e)
		{
			//FEA.ar.gov.afip.wsw.FEUltNroResponse objFEUltNroResponse = new FEA.ar.gov.afip.wsw.FEUltNroResponse();
			//ultNroRqstTextBox.Text = string.Empty;
			//this.Refresh();

			//try
			//{
			//    objFEUltNroResponse = objWSFE.FEUltNroRequest(objAutorizacion);
			//    ultNroRqstTextBox.Text = Convert.ToString(objFEUltNroResponse.nro.value);
			//}
			//catch (Exception ex)
			//{
			//    ultNroRqstTextBox.Text=ex.Message;
			//}
		}

		private void cantMaxDetButton_Click(object sender, EventArgs e)
		{
			//FEA.ar.gov.afip.wsw.FERecuperaQTYResponse objFERecuperaQTYResponse = new FEA.ar.gov.afip.wsw.FERecuperaQTYResponse();
			//cantMaxDetTextBox.Text = string.Empty;
			//this.Refresh();
			
			//try
			//{
			//    objFERecuperaQTYResponse = objWSFE.FERecuperaQTYRequest(objAutorizacion);
			//    cantMaxDetTextBox.Text = Convert.ToString(objFERecuperaQTYResponse.qty.value);
			//}
			//catch (Exception ex)
			//{
			//    cantMaxDetTextBox.Text = ex.Message;
			//}
		}

		private void ultCompAutButton_Click(object sender, EventArgs e)
		{
			//FEA.ar.gov.afip.wsw.FERecuperaLastCMPResponse objFERecuperaLastCMPResponse = new FEA.ar.gov.afip.wsw.FERecuperaLastCMPResponse();
			//ultCompAutTextBox.Text = string.Empty;
			//this.Refresh();

			//try
			//{
			//    FEA.ar.gov.afip.wsw.FELastCMPtype tipoComp = new FEA.ar.gov.afip.wsw.FELastCMPtype();
			//    tipoComp.PtoVta = 1;
			//    tipoComp.TipoCbte = 1;
			//    objFERecuperaLastCMPResponse = objWSFE.FERecuperaLastCMPRequest(objAutorizacion, tipoComp);
			//    ultCompAutTextBox.Text = Convert.ToString(objFERecuperaLastCMPResponse.cbte_nro);
			//}
			//catch (Exception ex)
			//{
			//    ultCompAutTextBox.Text = ex.Message;
			//}

		}

		private void verificarCaeButton_Click(object sender, EventArgs e)
		{
			//FEA.ar.gov.afip.wsw.FEConsultaCAEResponse objFEConsultaCAEResponse = new FEA.ar.gov.afip.wsw.FEConsultaCAEResponse();
			//verificarCaeTextBox.Text = string.Empty;
			//this.Refresh();

			//try
			//{
			//    FEA.ar.gov.afip.wsw.FEConsultaCAEReq objFEConsultaCAEReq = new FEA.ar.gov.afip.wsw.FEConsultaCAEReq();
			//    objFEConsultaCAEReq.cae = caeTextBox.Text;
			//    objFEConsultaCAEReq.cbt_nro = 6;
			//    objFEConsultaCAEReq.cuit_emisor = 30710015062;
			//    objFEConsultaCAEReq.fecha_cbte = "20081205";
			//    objFEConsultaCAEReq.imp_total = 0;
			//    objFEConsultaCAEReq.punto_vta = 1;
			//    objFEConsultaCAEReq.tipo_cbte = 1;
			//    objFEConsultaCAEResponse = objWSFE.FEConsultaCAERequest(objAutorizacion, objFEConsultaCAEReq);
			//    verificarCaeTextBox.Text = Convert.ToString(objFEConsultaCAEResponse.Resultado + ":" + objFEConsultaCAEResponse.RError.perrmsg);
			//}
			//catch (Exception ex)
			//{
			//    verificarCaeTextBox.Text = ex.Message;
			//}

		}

		private void nuevoComprobanteButton_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			ComprobanteForm oFrm = new ComprobanteForm();
			this.Cursor = Cursors.Default;
			oFrm.ShowDialog();
			this.Cursor = Cursors.WaitCursor;
			ComprobantesDataGridView.DataSource = FEArn.Comprobante.Lista(Aplicacion.Sesion);
			this.Cursor = Cursors.Default;
		}

		private void PrincipalForm_Load(object sender, EventArgs e)
		{
		}

		private void xmlIBKButton_Click(object sender, EventArgs e)
		{
			FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
			
			FeaEntidades.InterFacturas.cabecera_lote cab= new FeaEntidades.InterFacturas.cabecera_lote();
			cab.cantidad_reg = 1;
			cab.cuit_canal = 30690783521;
			cab.cuit_vendedor = 30710015062;
			cab.id_lote = 1;
			cab.presta_servSpecified = true;
			cab.presta_serv = 1;
			cab.punto_de_venta = 2;
			lote.cabecera_lote=cab;
			
			FeaEntidades.InterFacturas.cabecera compcab = new FeaEntidades.InterFacturas.cabecera();
			
			FeaEntidades.InterFacturas.informacion_comprador infcompra = new FeaEntidades.InterFacturas.informacion_comprador();
			infcompra.codigo_doc_identificatorio = 80;
			infcompra.nro_doc_identificatorio = 30500001735;
			infcompra.domicilio_calle = "Tte. Gral. Perón";
			infcompra.domicilio_numero = "407";
			infcompra.cp = "1038";
			infcompra.localidad = "C.A.B.A.";
			infcompra.provincia = "Capital Federal";
			infcompra.denominacion = "BANCO DE GALICIA S.A.";
			infcompra.condicion_IVASpecified = true;
			infcompra.condicion_IVA = 1;

			compcab.informacion_comprador = infcompra;
			
			FeaEntidades.InterFacturas.informacion_comprobante infcomprob = new FeaEntidades.InterFacturas.informacion_comprobante();
			infcomprob.tipo_de_comprobante = 1;
			infcomprob.numero_comprobante = 1;
			infcomprob.punto_de_venta = 2;
			infcomprob.fecha_emision = System.DateTime.Today.ToString("yyyyMMdd");
			infcomprob.fecha_vencimiento = System.DateTime.Today.ToString("yyyyMMdd");
			infcomprob.fecha_serv_desde = "20090101";
			infcomprob.fecha_serv_hasta = "20090131";
			compcab.informacion_comprobante = infcomprob;

			FeaEntidades.InterFacturas.informacion_vendedor infovend = new FeaEntidades.InterFacturas.informacion_vendedor();
			infovend.cuit = 30710015062;
			infovend.condicion_IVA = 1;
			infovend.condicion_IVASpecified = true;
			infovend.razon_social = "CEDEIRA SOFTWARE FACTORY S.R.L.";
			infovend.domicilio_calle = "Arenales";
			infovend.domicilio_numero = "3457";
			infovend.domicilio_piso = "3";
			infovend.domicilio_depto = "A";
			infovend.cp = "1425";
			infovend.localidad = "C.A.B.A.";
			infovend.provincia = "Capital Federal";
			infovend.nro_ingresos_brutos = "1171649-05";
			infovend.inicio_de_actividades = "20070307";
			infovend.condicion_ingresos_brutosSpecified = true;
			infovend.condicion_ingresos_brutos = 1;
			infovend.email = "info@cedeira.com.ar";
			infovend.telefono = "15-5493-9857";
			compcab.informacion_vendedor = infovend;
			
			FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
			comp.cabecera = compcab;

			FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();

			FeaEntidades.InterFacturas.linea li = new FeaEntidades.InterFacturas.linea();
			li.numeroLinea = 1;
			li.descripcion = "Servicio de Software Factory de Enero de 2009. Cantidad de recursos: 4 (cuatro). Nuevos desarrollos.";
			li.importe_total_articulo = 43612.80;
			
			det.linea[0] = li;
			det.comentarios = "MesaD,BcaPrivada,Directorio,GAF,Transf.y PagosJud.";

			comp.detalle = det;

			FeaEntidades.InterFacturas.resumen r = new FeaEntidades.InterFacturas.resumen();
			r.importe_total_factura = 52771.49;
			r.tipo_de_cambio = 1;
			r.codigo_moneda = "PES";
			r.importe_total_neto_gravado = 43612.80;
			r.importe_total_concepto_no_gravado = 0;
			r.importe_operaciones_exentas = 0;
			r.impuesto_liq = 9158.69;
			r.impuesto_liq_rni = 0;
			r.observaciones = "Servicio Prestado en la Ciudad Autónoma de Bs.As.";

			comp.resumen = r;

			lote.comprobante[0] = comp;

			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(lote.cabecera_lote.cuit_vendedor);
			sb.Append("-");
			sb.Append(lote.cabecera_lote.punto_de_venta);
			sb.Append("-");
			sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
			sb.Append("-");
			sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
			sb.Append(".xml");
			System.IO.Stream fs = new System.IO.FileStream(sb.ToString(), System.IO.FileMode.Create);
			System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(fs, System.Text.Encoding.GetEncoding("ISO-8859-1"));
			x.Serialize(writer, lote);
			fs.Close();
		}
	}
}