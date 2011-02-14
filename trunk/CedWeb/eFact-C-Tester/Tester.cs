using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            CuitCanalTextBox.Text = "30690783521";
            CuitTextBox.Text = "30710015062";
            PuntoVentaTextBox.Text = "12";
            NroComprobanteTextBox.Text = "1";
            NumeroLoteTextBox.Text = DateTime.Now.ToString("yyyyMMddHHmmss");

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
        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            try 
            {
                //Constructor del Lote
                eFact_C.Lote l = new eFact_C.Lote(url, certificado, proxy);
                
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
                MessageBox.Show("Lote encontrado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
            }
        }
        private void EnviarButton_Click(object sender, EventArgs e)
        {
            List<FeaEntidades.InterFacturas.error> listaNotificacionesLote;
            List<FeaEntidades.InterFacturas.error> listaNotificacionesComprobantes;
            try
            {
                //Constructor del Lote
                eFact_C.Lote l = new eFact_C.Lote(url, certificado, proxy);
                
                //Crear "lote_comprobantes"
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                Completar_lote_comprobantes(lc);

                FeaEntidades.InterFacturas.lote_response Lr;
                Lr = l.Enviar(lc, out listaNotificacionesLote, out listaNotificacionesComprobantes);
                MessageBox.Show("Lote enviado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
                //Guardar el ex.InnerException si tiene contenido para tener mas detalle del problema.
            }
        }
        private void Completar_lote_comprobantes(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            //Crear "cabecera" del lote de comprobantes
            lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lc.cabecera_lote.cuit_canal = Convert.ToInt64("30690783521");
            lc.cabecera_lote.cuit_vendedor = Convert.ToInt64(CuitTextBox.Text);
            lc.cabecera_lote.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
            lc.cabecera_lote.id_lote = Convert.ToInt64(NumeroLoteTextBox.Text);
            lc.cabecera_lote.presta_serv = 0;
            lc.cabecera_lote.presta_servSpecified = false;
            //Cantidad de comprobantes por lote.
            lc.cabecera_lote.cantidad_reg = 1;

            //Crear "comprobante" del lote de comprobantes
            FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
            //Crear "cabecera" del comprobante
            c.cabecera = new FeaEntidades.InterFacturas.cabecera();

            ////Crear "informacion_comprador" de la cabecera del comprobante
            c.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
            c.cabecera.informacion_comprador.codigo_doc_identificatorio = 80;
            c.cabecera.informacion_comprador.nro_doc_identificatorio = Convert.ToInt64("30561748140");
            c.cabecera.informacion_comprador.condicion_IVA = 1;
            c.cabecera.informacion_comprador.domicilio_calle = "Av.Corrientes";
            c.cabecera.informacion_comprador.domicilio_numero = "1ºA";
            c.cabecera.informacion_comprador.telefono = "2134-2323 / 29";

            ////Crear "informacion_vendedor" de la cabecera del comprobante
            c.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
            c.cabecera.informacion_vendedor.razon_social = "Syspro Consulting";
            c.cabecera.informacion_vendedor.cuit = Convert.ToInt64(CuitTextBox.Text);
            c.cabecera.informacion_vendedor.condicion_IVA = 1;
            c.cabecera.informacion_vendedor.domicilio_calle = "Av.Córdoba";
            c.cabecera.informacion_vendedor.domicilio_numero = "7ºG";
            c.cabecera.informacion_vendedor.telefono = "4235-2323";
            c.cabecera.informacion_vendedor.cp = "1425";

            ////Crear "informacion_comprobante" de la cabecera del comprobante
            c.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
            c.cabecera.informacion_comprobante.tipo_de_comprobante = 1;
            // --- Otra forma de asignar el codigo de tipo de comprobante utilizando la clase. ---
            FeaEntidades.TiposDeComprobantes.Facturas.A tc = new FeaEntidades.TiposDeComprobantes.Facturas.A();
            c.cabecera.informacion_comprobante.tipo_de_comprobante = tc.Codigo;
            // -----------------------------------------------------------------------------------
            c.cabecera.informacion_comprobante.numero_comprobante = Convert.ToInt32(NroComprobanteTextBox.Text); ;
            c.cabecera.informacion_comprobante.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
            c.cabecera.informacion_comprobante.fecha_emision = FechaEmisionDateTimePicker.Value.ToString("yyyyMMdd");          //Formato: yyyyMMdd
            c.cabecera.informacion_comprobante.fecha_vencimiento = FechaVtoDateTimePicker.Value.ToString("yyyyMMdd");          //Formato: yyyyMMdd
            //Si es un comprobante de servicios
            c.cabecera.informacion_comprobante.fecha_serv_desde = "";
            c.cabecera.informacion_comprobante.fecha_serv_hasta = "";

            //Crear "detalle" del comprobante.
            c.detalle = new FeaEntidades.InterFacturas.detalle();
            //Informar "comentarios" del comprobante. 
            //Es un texto libre que se imprime antes del detalle ( los renglones ) del comprobante.
            c.detalle.comentarios = "xxxxxxx xxxxx xxx xxxxxxxx.";
            //Crear "linea" del detalle del comprobante.
            FeaEntidades.InterFacturas.linea linea = new FeaEntidades.InterFacturas.linea();
            linea.numeroLinea = 1;
            linea.descripcion = "Nombre del producto";
            linea.precio_unitario = 100;
            linea.cantidad = 3;
            linea.alicuota_iva = 21;
            linea.importe_iva = 63;     // = 100 * 3 * .21 
            linea.importe_total_articulo = 363;
            // Otra forma de asignar el valor del IVA.;
            FeaEntidades.IVA.Veintiuno iva = new FeaEntidades.IVA.Veintiuno();
            linea.alicuota_iva = iva.Codigo;
            // -----------------------------------------------------
            linea.unidad = "5";         //5 = Litros
            // --- Otra forma de asignar la unidad. La clase FeaEntidades expone listas para el armado de combos de algunos campos.
            //No es necesario utilizarla.
            List<FeaEntidades.CodigosUnidad.CodigoUnidad> listaUnidades = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
            FeaEntidades.CodigosUnidad.CodigoUnidad codigoUnidad = listaUnidades[5];
            linea.unidad = codigoUnidad.Codigo.ToString();

            FeaEntidades.CodigosUnidad.Litros unidad = new FeaEntidades.CodigosUnidad.Litros();
            linea.unidad = unidad.Codigo.ToString();
            // -----------------------------------------------------------------------------------
            c.detalle.linea[0] = linea;

            //Crear "resumen" del comprobante.
            c.resumen = new FeaEntidades.InterFacturas.resumen();
            //Es un comentario en el area de resumen del comprobante impreso.
            c.resumen.observaciones = "xxxxxx xxxxx xxxx xxxx xxxx";
            c.resumen.importe_total_neto_gravado = 300;
            c.resumen.cant_alicuotas_iva = 1;
            c.resumen.impuesto_liq = 63;
            c.resumen.importe_total_factura = 363;

            // 1 para facturas en pesos.
            c.resumen.tipo_de_cambio = 1;
            FeaEntidades.CodigosMoneda.PesosArgentinos moneda = new FeaEntidades.CodigosMoneda.PesosArgentinos();
            c.resumen.codigo_moneda = moneda.Codigo;

            //Asignar objeto comprobante dentro del lote de camprobantes.
            lc.comprobante[0] = c; 
        }
        private void GenerarNroLoteButton_Click(object sender, EventArgs e)
        {
            NumeroLoteTextBox.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void ArmarLoteXMLButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Crear "lote_comprobantes"
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                Completar_lote_comprobantes(lc);

                string LoteXML;
                //Metodo estático para el armado del Lote en formato XML, no necesita usar el constructor con la URL, proxy y certificados.
                //Para Contingencias: El string LoteXML deberá guardarse en un archivo para se subido al Sitio Web de Interfacturas.
                LoteXML = eFact_C.Lote.ArmarLoteXML(lc);
                //Definir ruta y nombre del archivo.
                FileStream fs = File.Create(@"c:\\efact-r\\efact-c-contingencia.xml");
                System.Text.Encoding codificador;
                codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                fs.Write(codificador.GetBytes(LoteXML), 0, LoteXML.Length);
                fs.Close();
                MessageBox.Show("Lote XML generado satisfactoriamente", "NOTIFICACION", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NOTIFICACION", MessageBoxButtons.OK);
                //Guardar el ex.InnerException si tiene contenido para tener mas detalle del problema.
            }
        }
    }
}