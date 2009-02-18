using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FEA
{
	public partial class ComprobanteForm : Form
	{
		FEArn.Comprobante c;
		FeaEntidades.Comprobante ce=new FeaEntidades.Comprobante();
		public ComprobanteForm()
		{
			InitializeComponent();
		}

		private void EnviarButton_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			caeTextBox.Text = string.Empty;
			resultadoTextBox.Text = string.Empty;
			motivoTextBox.Text = string.Empty;
			caeTextBox.Text = string.Empty;
			estadoTextBox.Text = string.Empty;
			this.Refresh();
			c.Enviar(ce);
			this.Cursor = Cursors.Default;
		}

		private void ComprobanteForm_Load(object sender, EventArgs e)
		{
			string auxCnn = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ToString();

			System.Net.WebProxy wp=null;
			if (!System.Configuration.ConfigurationManager.AppSettings["Proxy"].ToUpper().Equals("NO"))
			{
				wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
				string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
				string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
				string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];
				
				System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
				wp.Credentials = networkCredential;

				//System.Net.CredentialCache credentialCache = new System.Net.CredentialCache();
				//string wsaaurl = System.Configuration.ConfigurationManager.AppSettings["FEA_ar_gov_afip_wsaa_LoginCMSService"];
				//credentialCache.Add(new Uri(wsaaurl), "NTLM", networkCredential);
				//string wsfeurl = System.Configuration.ConfigurationManager.AppSettings["FEA_ar_gov_afip_wsw_Service"];
				//credentialCache.Add(new Uri(wsfeurl), "NTLM", networkCredential);

				//wp.Credentials = credentialCache;
			}

			c = new FEArn.Comprobante(System.Configuration.ConfigurationManager.AppSettings["FEA_ar_gov_afip_wsaa_LoginCMSService"], System.Configuration.ConfigurationManager.AppSettings["FEA_ar_gov_afip_wsw_Service"], System.Configuration.ConfigurationManager.AppSettings["rutaCertificado"], Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["CUIT"]), Aplicacion.Sesion, wp);


			ptoVentaTextBox.DataBindings.Add(new Binding("Text", ce, "PuntoVenta"));
			prestaServicioCheckBox.DataBindings.Add(new Binding("Checked", ce, "Presta_serv"));
			tipoComprobanteComboBox.DataSource = FEArn.TiposDeComprobantes.TipoComprobante.Lista();
			tipoComprobanteComboBox.DisplayMember = "Descr";
			tipoComprobanteComboBox.ValueMember = "Codigo";
			tipoComprobanteComboBox.DataBindings.Add(new Binding("SelectedItem", ce, "TipoComp"));
			fecha_cbteDateTimePicker.DataBindings.Add(new Binding("Value", ce, "Fecha_cbte"));
			fecha_serv_desdeDateTimePicker.DataBindings.Add(new Binding("Value", ce, "Fecha_serv_desde"));
			fecha_serv_hastaDateTimePicker.DataBindings.Add(new Binding("Value", ce, "Fecha_serv_hasta"));
			fecha_venc_pagoDateTimePicker.DataBindings.Add(new Binding("Value", ce, "Fecha_venc_pago"));
			imp_netoTextBox.DataBindings.Add(new Binding("Text", ce, "Imp_neto"));
			imp_op_exTextBox.DataBindings.Add(new Binding("Text", ce, "Imp_op_ex"));
			imp_tot_concTextBox.DataBindings.Add(new Binding("Text", ce, "Imp_tot_conc"));
			imp_totalTextBox.DataBindings.Add(new Binding("Text", ce, "Imp_total"));
			impto_liqTextBox.DataBindings.Add(new Binding("Text", ce, "Impto_liq"));
			impto_liq_rniTextBox.DataBindings.Add(new Binding("Text", ce, "Impto_liq_rni"));
			tipo_docComboBox.DataSource = FEArn.Documentos.Documento.Lista();
			tipo_docComboBox.DisplayMember = "Descr";
			tipo_docComboBox.ValueMember = "Codigo";
			tipo_docComboBox.DataBindings.Add(new Binding("SelectedItem", ce, "Tipo_doc"));
			nro_docTextBox.DataBindings.Add(new Binding("Text", ce, "Nro_doc"));
			estadoTextBox.DataBindings.Add(new Binding("Text", ce, "MensajeError"));
			motivoTextBox.DataBindings.Add(new Binding("Text", ce, "Motivo"));
			resultadoTextBox.DataBindings.Add(new Binding("Text", ce, "Resultado"));
			caeTextBox.DataBindings.Add(new Binding("Text", ce, "Cae"));
		}
	}
}