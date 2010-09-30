using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_C_Tester
{
    public partial class Tester : Form
    {
        private string url;
        private eFact_C.Entidades.Certificado certificado;
        private eFact_C.Entidades.Proxy proxy;

        public Tester()
        {
            InitializeComponent();
            CuitTextBox.Text = "30710015062";
            PuntoVentaTextBox.Text = "11";
            NumeroLoteTextBox.Text = "20110928154900";

            //URL del servicio web utilizado
            //DESARROLLO = "https://wsqacfe.interfacturas.com.ar/ws/FacturaWebServiceConSchema" o PRODUCCION = "https://srv1.interfacturas.com.ar/ws/FacturaWebServiceConSchema"
            url = "https://wsqacfe.interfacturas.com.ar/ws/FacturaWebServiceConSchema";
            
            //Datos del Certificado
            certificado = new eFact_C.Entidades.Certificado();
            //Número de serie del certificado instalado en la PC para el usuario actual ( CurrentUser ).
            certificado.Numero = "0126d1bfa455";
            certificado.LugarDeAlmacenamiento = eFact_C.Entidades.Certificado.Almacenamiento.CurrentUser;
            
            //Datos del proxy
            proxy = new eFact_C.Entidades.Proxy();
            proxy = null;
            //proxy.Servidor = "proxy.com.ar:80"; //ejemplo
            //proxy.Usuario = "";
            //proxy.Clave = "";
            //proxy.Dominio = "";
        }
        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            try 
            {
                //Constructor del Lote
                eFact_C.Lote l = new eFact_C.Lote(url, certificado, proxy);
                //Metodo de Consulta de Lote
                eFact_C.Entidades.LoteConsulta loteconsulta = new eFact_C.Entidades.LoteConsulta();
                //Es fijo, es el Cuit de Interfacturas
                loteconsulta.CuitCanal = Convert.ToInt64("30690783521");
                //Cuit de la empresa
                loteconsulta.CuitVendedor = Convert.ToInt64(CuitTextBox.Text);
                //Número de Punto de Venta
                loteconsulta.PuntoVenta = Convert.ToInt32(PuntoVentaTextBox.Text);
                //Número de lote a consultar
                loteconsulta.Numero = Convert.ToInt64(NumeroLoteTextBox.Text);

                FeaEntidades.InterFacturas.consulta_lote_comprobantes consultalotecomprobantes = new FeaEntidades.InterFacturas.consulta_lote_comprobantes();
                consultalotecomprobantes.cuit_canal = Convert.ToInt64("30690783521");
                consultalotecomprobantes.cuit_vendedor = Convert.ToInt64(CuitTextBox.Text);
                consultalotecomprobantes.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
                consultalotecomprobantes.id_lote = Convert.ToInt64(NumeroLoteTextBox.Text);
                
                //Crear objeto Lote de Comprobantes para recibir los datos.
                FeaEntidades.InterFacturas.lote_comprobantes Lc;
                //Crear objeto Notificaciones para recibir la lista de notificaciones a nivel de lote y/o comprobante.
                List<FeaEntidades.InterFacturas.error> listaNotificacionesLote;
                List<FeaEntidades.InterFacturas.error> listaNotificacionesComprobantes;
                Lc = l.Consultar(loteconsulta, out listaNotificacionesLote, out listaNotificacionesComprobantes);
                MessageBox.Show("Lote encontrado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
            }
        }

        private void EnviarButton_Click(object sender, EventArgs e)
        {
            try
            {
                eFact_C.Lote l = new eFact_C.Lote(url, certificado, proxy);
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                lc.cabecera_lote.cuit_canal = Convert.ToInt64("30690783521");
                lc.cabecera_lote.cuit_vendedor = Convert.ToInt64(CuitTextBox.Text);
                lc.cabecera_lote.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
                lc.cabecera_lote.id_lote = Convert.ToInt64(NumeroLoteTextBox.Text);
                //lc.cabecera_lote.presta_serv = 0;
                lc.cabecera_lote.presta_servSpecified = false;

                FeaEntidades.InterFacturas.lote_response Lr;
                List<FeaEntidades.InterFacturas.error> listaNotificacionesLote;
                List<FeaEntidades.InterFacturas.error> listaNotificacionesComprobantes;
                Lr = l.Enviar(lc, out listaNotificacionesLote, out listaNotificacionesComprobantes);
                MessageBox.Show("Lote enviado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
            }
        }
    }
}