using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_I_Bj
{
    public partial class ConsultaComprobanteBj : Form
    {
        private eFact_I_Bj.Entidades.ComprobanteBj comprobante;
        public ConsultaComprobanteBj(eFact_I_Bj.Entidades.ComprobanteBj Comprobante)
        {
            InitializeComponent();
            comprobante = Comprobante;
        }

        private void ConsultaComprobanteBj_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                PuntoVentaTextBox.DataBindings.Add("Text", comprobante, "PuntoVenta");
                NumeroComprobanteTextBox.DataBindings.Add("Text", comprobante, "NumeroComprobante");
                ImporteTextBox.DataBindings.Add("Text", comprobante, "Importe");
                CAEFechaVtoTextBox.DataBindings.Add("Text", comprobante, "FechaVtoCAEsinHora");
                CAENroTextBox.DataBindings.Add("Text", comprobante, "NumeroCAE");
                FechaEmisionDTP.DataBindings.Add("Value", comprobante, "Fecha");
                FechaVtoDTP.DataBindings.Add("Value", comprobante, "FechaVto");
                CompradorNombreTextBox.DataBindings.Add("Text", comprobante, "CompradorNombre");
                CompradorDomicilioCalleTextBox.DataBindings.Add("Text", comprobante, "CompradorDomicilioCalle");
                CompradorNroDocTextBox.DataBindings.Add("Text", comprobante, "CompradorNroDoc");
                CompradorLocalidadTextBox.DataBindings.Add("Text", comprobante, "CompradorLocalidad");
                CompradorCPTextBox.DataBindings.Add("Text", comprobante, "CompradorCP");
                CompradorTelefonoTextBox.DataBindings.Add("Text", comprobante, "CompradorTelefono");
                CompradorEMailTextBox.DataBindings.Add("Text", comprobante, "CompradorEMail");
                VendedorCuitTextBox.DataBindings.Add("Text", comprobante, "VendedorCuit");
                VendedorNombreTextBox.DataBindings.Add("Text", comprobante.Vendedor, "Nombre");
                VendedorCodigoTextBox.DataBindings.Add("Text", comprobante.Vendedor, "Codigo");
                VendedorNroIBTextBox.DataBindings.Add("Text", comprobante.Vendedor, "NroIB");
                VendedorInicioActividadesDTP.DataBindings.Add("Value", comprobante.Vendedor, "InicioActividades");
                VendedorContactoTextBox.DataBindings.Add("Text", comprobante.Vendedor, "Contacto");
                VendedorDomicilioCalleTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioCalle");
                VendedorDomicilioNroTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioNumero");
                VendedorDomicilioPisoTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioPiso");
                VendedorDomicilioDptoTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioDepto");
                VendedorDomicilioSectorTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioSector");
                VendedorDomicilioTorreTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioTorre");
                VendedorDomicilioManzanaTextBox.DataBindings.Add("Text", comprobante.Vendedor, "DomicilioManzana");
                VendedorLocalidadTextBox.DataBindings.Add("Text", comprobante.Vendedor, "Localidad");
                VendedorCPTextBox.DataBindings.Add("Text", comprobante.Vendedor, "CP");
                VendedorEMailTextBox.DataBindings.Add("Text", comprobante.Vendedor, "EMail");
                VendedorTelefonosTextBox.DataBindings.Add("Text", comprobante.Vendedor, "Telefono");
                ResumenNetoGravadoTextBox.DataBindings.Add("Text", comprobante, "ImporteNetoGravado");
                ResumenConceptoNoGravadoTextBox.DataBindings.Add("Text", comprobante, "ImporteNetoNoGravado");
                ResumenOperacionesExentasTextBox.DataBindings.Add("Text", comprobante, "ImporteOpsExentas");
                ResumenImpuestosLiqTextBox.DataBindings.Add("Text", comprobante, "ImpuestoLiq");
                ResumenImpuestosLiqRNITextBox.DataBindings.Add("Text", comprobante, "ImpuestoRNI");
                ResumenImpuestosNacionalesTextBox.DataBindings.Add("Text", comprobante, "ImpuestosNacionales");
                ResumenCantAlicuotasIVATextBox.DataBindings.Add("Text", comprobante, "CantAlicuotasIVA");


                //Cabecera
                IdTipoComprobanteComboBox.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
                IdTipoComprobanteComboBox.DisplayMember = "Descr";
                IdTipoComprobanteComboBox.ValueMember = "Codigo";
                IdTipoComprobanteComboBox.SelectedValue = Convert.ToInt16(comprobante.IdTipoComprobante);
                
                MonedaComboBox.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
                MonedaComboBox.DisplayMember = "Descr";
                MonedaComboBox.ValueMember = "Codigo";
                MonedaComboBox.SelectedValue = comprobante.IdMoneda;

                //Combos comprador
                CompradorTipoDocComboBox.DataSource = FeaEntidades.Documentos.Documento.Lista();
                CompradorTipoDocComboBox.DisplayMember = "Descr";
                CompradorTipoDocComboBox.ValueMember = "Codigo";
                CompradorTipoDocComboBox.SelectedValue = Convert.ToInt16(comprobante.Comprador.TipoDoc);
                CompradorCondIVAComboBox.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                CompradorCondIVAComboBox.DisplayMember = "Descr";
                CompradorCondIVAComboBox.ValueMember = "Codigo";
                CompradorCondIVAComboBox.SelectedValue = Convert.ToInt16(1);
                CompradorProvinciaComboBox.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                CompradorProvinciaComboBox.DisplayMember = "Descr";
                CompradorProvinciaComboBox.ValueMember = "Codigo";
                CompradorProvinciaComboBox.SelectedValue = Convert.ToInt16(comprobante.Comprador.Provincia);
                
                //Combos vendedor
                VendedorCondicionIVAComboBox.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                VendedorCondicionIVAComboBox.DisplayMember = "Descr";
                VendedorCondicionIVAComboBox.ValueMember = "Codigo";
                VendedorCondicionIVAComboBox.SelectedValue = Convert.ToInt16(comprobante.Vendedor.CondicionIVA);
                VendedorCondicionIBComboBox.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                VendedorCondicionIBComboBox.DisplayMember = "Descr";
                VendedorCondicionIBComboBox.ValueMember = "Codigo";
                VendedorCondicionIBComboBox.SelectedValue = Convert.ToInt16(comprobante.Vendedor.CondicionIB);
                VendedorProvinciaComboBox.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                VendedorProvinciaComboBox.DisplayMember = "Descr";
                VendedorProvinciaComboBox.ValueMember = "Codigo";
                VendedorProvinciaComboBox.SelectedValue = Convert.ToInt16(comprobante.Vendedor.Provincia);
                CantidadRenglonesTextBox.Text = comprobante.Lineas.Count.ToString();

                DetalleComprobanteDataGridView.AutoGenerateColumns = false;
                DetalleComprobanteDataGridView.DataSource = comprobante.Lineas;
                DetalleComprobanteDataGridView.Refresh();

                //eFact_I_Bj.RN.Lote.Consultar(comprobante, Aplicacion.Sesion);
                IdEstadoTextBox.Text = comprobante.IdEstado;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}