using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace eFact_Tester
{
    public partial class Tester : Form
    {
        private eFact_Tester.Entidades.Certificado certificado;
        private eFact_Tester.Entidades.Proxy proxy;
        private System.Net.WebProxy wpDefault;

        public Tester()
        {
            InitializeComponent();

            ProxyDireccionTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["Proxy"];
            ProxyUsuarioTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
            ProxyClaveTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
            ProxyDominioTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

            CuitTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["CuitVendedor"];
            PuntoVentaTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["PuntoVenta"];
            NumeroLoteTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["NumeroLote"];

            CuitCanalTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["CuitCanal"];
            URLTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"];
            
            //Crear entidad Certificado
            certificado = new eFact_Tester.Entidades.Certificado();
            CertificadoNroSerieTextBox.Text = @System.Configuration.ConfigurationManager.AppSettings["CertificadoNroSerie"]; 
            
            //crear entidad Proxy
            proxy = new eFact_Tester.Entidades.Proxy();
            ProxyAutoPanel.Enabled = false;
            
            //seteo cultura thread
            Thread.CurrentThread.CurrentCulture = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
        }

        private void ConsultarURLButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                WebBrowser.Navigate(URLTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

            }
        }
        private void CrearCertificadoYProxy()
        {
            //Datos del Certificado
            //Número de serie del certificado instalado en la PC para el usuario actual ( CurrentUser ).
            certificado.Numero = CertificadoNroSerieTextBox.Text;
            certificado.LugarDeAlmacenamiento = eFact_Tester.Entidades.Certificado.Almacenamiento.CurrentUser;

            //Datos del proxy
            if (ProxyDireccionTextBox.Text.Trim() != "")
            {
                proxy.Servidor = ProxyDireccionTextBox.Text;    //"proxy.com.ar:80"; //ejemplo
                proxy.Usuario = ProxyUsuarioTextBox.Text;       //"pepe";
                proxy.Clave = ProxyClaveTextBox.Text;           //"123456";
                proxy.Dominio = ProxyDominioTextBox.Text;       //"empresa1"
            }
            else
            {
                proxy = null;
            }
        }

        private void ConsultarLoteButton_Click(object sender, EventArgs e)
        {
            try
            {
                CrearCertificadoYProxy();
                string url = URLTextBox.Text;
                //Constructor del Lote
                eFact_Tester.Lote l = new eFact_Tester.Lote(url, certificado, proxy);

                //Crear entidad "consulta_lote_comprobantes" utilizada como primer parametro en la Consulta de Lote
                FeaEntidades.InterFacturas.consulta_lote_comprobantes consultalotecomprobantes = new FeaEntidades.InterFacturas.consulta_lote_comprobantes();
                //Es fijo, es el Cuit de Interfacturas
                consultalotecomprobantes.cuit_canal = Convert.ToInt64(CuitCanalTextBox.Text);
                //Cuit de la empresa
                consultalotecomprobantes.cuit_vendedor = Convert.ToInt64(CuitTextBox.Text);
                //Número de Punto de Venta
                consultalotecomprobantes.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
                //Número de lote a consultar
                consultalotecomprobantes.id_lote = Convert.ToInt64(NumeroLoteTextBox.Text);

                //Crear objeto Lote de Comprobantes para recibir los datos.
                FeaEntidades.InterFacturas.lote_comprobantes Lc;
                //Crear objeto Notificaciones para recibir la lista de notificaciones a nivel de lote y/o comprobante.
                List<FeaEntidades.InterFacturas.error> listaNotificacionesLote;
                List<FeaEntidades.InterFacturas.error> listaNotificacionesComprobantes;

                //Metodo de Consulta de Lote
                Lc = l.Consultar(consultalotecomprobantes, out listaNotificacionesLote, out listaNotificacionesComprobantes);
                MessageBox.Show("Lote encontrado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ValidarComunicacionButton_Click(object sender, EventArgs e)
        {
            try
            {
                CrearCertificadoYProxy();
                string url = URLTextBox.Text;
                //Constructor del Lote
                if (wpDefault != null)
                {
                    eFact_Tester.Lote l = new eFact_Tester.Lote(url, certificado, wpDefault);
                }
                else
                {
                    eFact_Tester.Lote l = new eFact_Tester.Lote(url, certificado, proxy);
                }
                MessageBox.Show("Validación satisfactoria", "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GoogleButton_Click(object sender, EventArgs e)
        {
            try
            {
                WebBrowser.Navigate("http://www.google.com.ar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LeerProxyButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.WebProxy wpDefault = new System.Net.WebProxy();
                wpDefault = System.Net.WebProxy.GetDefaultProxy();
                if (wpDefault.Address == null)
                {
                    throw new Exception("Direccion del Proxy no encontrada.");
                }
                else
                {
                    wpDefaultTextBox.Text = "URI: " + wpDefault.Address.AbsoluteUri + "\r\nPuerto: " + wpDefault.Address.Port;
                    //wp.Credentials = System.Net.WebProxy.GetDefaultProxy().Credentials;
                    //wp.Address = System.Net.WebProxy.GetDefaultProxy().Address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true && ((RadioButton)sender).Name == "ProxyManualRadioButton")
            {
                wpDefault = null;
                wpDefaultTextBox.Text = "";
                ProxyAutoPanel.Enabled = false;
                ProxyManualPanel.Enabled = true;
            }
            else
            {
                ProxyAutoPanel.Enabled = true;
                ProxyManualPanel.Enabled = false;
            }
        }
    }
}