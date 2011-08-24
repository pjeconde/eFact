using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace eFact_R
{
    public partial class ConsultaVendedor : Form
    {
        private eFact_Entidades.Vendedor vendedor = new eFact_Entidades.Vendedor();
        private StatusBar statusBar;
        public ConsultaVendedor(StatusBar SBar)
        {
            InitializeComponent();
            statusBar = SBar;
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                BuscarImagenButton.Enabled = false;
                ModificarButton.Enabled = false;
                BorrarImagenButton.Enabled = false;
                List<eFact_Entidades.Vendedor> vendedores = new List<eFact_Entidades.Vendedor>();
                eFact_RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
                CuitVendedorComboBox.Items.Clear();
                CuitVendedorComboBox.Items.Add("( Elegir un Vendedor )");
                if (vendedores.Count > 0)
                {
                    foreach(eFact_Entidades.Vendedor v in vendedores)
                    {
                        CuitVendedorComboBox.Items.Add(v.CuitVendedor);
                    }
                }
                VendedorCondicionIVAComboBox.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                VendedorCondicionIVAComboBox.DisplayMember = "Descr";
                VendedorCondicionIVAComboBox.ValueMember = "Codigo";
                VendedorCondicionIBComboBox.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                VendedorCondicionIBComboBox.DisplayMember = "Descr";
                VendedorCondicionIBComboBox.ValueMember = "Codigo";
                VendedorProvinciaComboBox.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                VendedorProvinciaComboBox.DisplayMember = "Descr";
                VendedorProvinciaComboBox.ValueMember = "Codigo";
                CuitVendedorComboBox.SelectedIndex = 0;
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

        private void CuitVendedorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                string CuitVendedor = ((ComboBox)sender).SelectedItem.ToString().Trim();
                vendedor.CuitVendedor = CuitVendedor;
                eFact_RN.Vendedor.Leer(vendedor, Aplicacion.Sesion);
                VendedorNombreTextBox.Text = vendedor.Nombre;
                VendedorNroSerieCertificadoTextBox.Text = vendedor.NumeroSerieCertificado;
                VendedorCodigoTextBox.Text = vendedor.Codigo;
                short IVA = Convert.ToInt16(vendedor.CondicionIVA);
                VendedorCondicionIVAComboBox.SelectedValue = IVA;
                short IB = Convert.ToInt16(vendedor.CondicionIB);
                VendedorCondicionIBComboBox.SelectedValue = IB;
                VendedorNroIBTextBox.Text = vendedor.NroIB;
                VendedorInicioActividadesDTP.Value = vendedor.InicioActividades;
                VendedorContactoTextBox.Text = vendedor.Contacto;
                VendedorDomicilioCalleTextBox.Text = vendedor.DomicilioCalle;
                VendedorDomicilioNroTextBox.Text = vendedor.DomicilioNumero;
                VendedorDomicilioPisoTextBox.Text = vendedor.DomicilioPiso;
                VendedorDomicilioDptoTextBox.Text = vendedor.DomicilioDepto;
                VendedorDomicilioSectorTextBox.Text = vendedor.DomicilioSector;
                VendedorDomicilioTorreTextBox.Text = vendedor.DomicilioTorre;
                VendedorDomicilioManzanaTextBox.Text = vendedor.DomicilioManzana;
                VendedorLocalidadTextBox.Text = vendedor.Localidad;
                short provincia = Convert.ToInt16(vendedor.Provincia);
                VendedorProvinciaComboBox.SelectedValue = provincia;
                VendedorCPTextBox.Text = vendedor.CP;
                VendedorEMailTextBox.Text = vendedor.EMail;
                VendedorTelefonosTextBox.Text = vendedor.Telefono;
                VerLogo(vendedor.Logo);
                BuscarImagenButton.Enabled = true;
                ModificarButton.Enabled = true;
                BorrarImagenButton.Enabled = true;
            }
            else 
            {
                vendedor = new eFact_Entidades.Vendedor();
                VendedorNombreTextBox.Text = "";
                VendedorNroSerieCertificadoTextBox.Text = "";
                VendedorCodigoTextBox.Text = "";
                VendedorCondicionIVAComboBox.Text = "";
                VendedorCondicionIBComboBox.Text = "";
                VendedorNroIBTextBox.Text = "";
                VendedorInicioActividadesDTP.Value = Aplicacion.FechaMax;
                VendedorInicioActividadesDTP.Checked = false;
                VendedorContactoTextBox.Text = "";
                VendedorDomicilioCalleTextBox.Text = "";
                VendedorDomicilioNroTextBox.Text = "";
                VendedorDomicilioPisoTextBox.Text = "";
                VendedorDomicilioDptoTextBox.Text = "";
                VendedorDomicilioSectorTextBox.Text = "";
                VendedorDomicilioTorreTextBox.Text = "";
                VendedorDomicilioManzanaTextBox.Text = "";
                VendedorLocalidadTextBox.Text = "";
                VendedorProvinciaComboBox.Text = "";
                VendedorCPTextBox.Text = "";
                VendedorEMailTextBox.Text = "";
                VendedorTelefonosTextBox.Text = "";
                VendedorLogoPictureBox.Image = null;
                BuscarImagenButton.Enabled = false;
                ModificarButton.Enabled = false;
                BorrarImagenButton.Enabled = false;
            }
        }

        private void BuscarImagenButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFileDialog.ShowDialog();
            if (dr.ToString() == "OK")
            {
                string archivo = OpenFileDialog.FileName;

                //Cargamos la imagen en un objeto tipo Image
                Image dibujo = new Bitmap(archivo);

                //Creamos un stream en memoria para guardar la imagen
                MemoryStream memStream = new MemoryStream();

                //Guardamos la imagen en nuestro stream especificando el formato.
                dibujo.Save(memStream, System.Drawing.Imaging.ImageFormat.Bmp);

                //Guardamos el stream en un array de bytes
                Byte[] logo = memStream.GetBuffer();

                //Visualizar la imagen en el PictoreBox
                VerLogo(logo);
                vendedor.Logo = logo;
            }
            OpenFileDialog.Dispose();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            vendedor.Nombre = VendedorNombreTextBox.Text;
            vendedor.NumeroSerieCertificado = VendedorNroSerieCertificadoTextBox.Text;
            vendedor.Codigo = VendedorCodigoTextBox.Text;
            vendedor.CondicionIVA = Convert.ToInt32(VendedorCondicionIVAComboBox.SelectedValue);
            vendedor.CondicionIB = Convert.ToInt32(VendedorCondicionIBComboBox.SelectedValue);
            vendedor.NroIB = VendedorNroIBTextBox.Text;
            if (VendedorInicioActividadesDTP.Checked == true)
            {
                vendedor.InicioActividades = VendedorInicioActividadesDTP.Value;
            }
            else
            {
                vendedor.InicioActividades = Aplicacion.FechaMax;
            }
            vendedor.Contacto = VendedorContactoTextBox.Text;
            vendedor.DomicilioCalle = VendedorDomicilioCalleTextBox.Text;
            vendedor.DomicilioNumero = VendedorDomicilioNroTextBox.Text;
            vendedor.DomicilioPiso = VendedorDomicilioPisoTextBox.Text;
            vendedor.DomicilioDepto = VendedorDomicilioDptoTextBox.Text;
            vendedor.DomicilioSector = VendedorDomicilioSectorTextBox.Text;
            vendedor.DomicilioTorre = VendedorDomicilioTorreTextBox.Text;
            vendedor.DomicilioManzana = VendedorDomicilioManzanaTextBox.Text;
            vendedor.Localidad = VendedorLocalidadTextBox.Text;
            vendedor.Provincia = VendedorProvinciaComboBox.SelectedValue.ToString();
            vendedor.CP = VendedorCPTextBox.Text;
            vendedor.EMail = VendedorEMailTextBox.Text;
            vendedor.Telefono = VendedorTelefonosTextBox.Text;
            eFact_RN.Vendedor.Modificar(vendedor, Aplicacion.Sesion);
            List<eFact_Entidades.Vendedor> vendedores = new List<eFact_Entidades.Vendedor>();

            eFact_RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
            if (vendedores.Count > 0)
            {
                statusBar.Panels["CertificadosSBP"].Text = "Certificados: OK";
                statusBar.Panels["CertificadosSBP"].ToolTipText = "";
                bool AllCertifOK = true;
                foreach (eFact_Entidades.Vendedor v in vendedores)
                {
                    string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
                    X509Store store;
                    if (storeLocation == "CurrentUser")
                    {
                        store = new X509Store(StoreLocation.CurrentUser);
                    }
                    else
                    {
                        store = new X509Store(StoreLocation.LocalMachine);
                    }
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, v.NumeroSerieCertificado, true);
                    if (col.Count == 0)
                    {
                        MessageBox.Show("Problemas con el certificado número: " + v.NumeroSerieCertificado + "\r\n\r\nSin un certificado válido no se podrá establecer la comunicación con Interfacturas.", "Certificados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        statusBar.Panels["CertificadosSBP"].ToolTipText += "Información del certificado número: " + v.NumeroSerieCertificado + "\r\nProblemas para validar el certificado." + "\r\n\r\n";
                        AllCertifOK = false;
                    }
                    else
                    {
                        statusBar.Panels["CertificadosSBP"].ToolTipText += "Información del certificado número: " + v.NumeroSerieCertificado + "\r\nEntidad emisora: " + col[0].IssuerName.Name + "\r\nSujeto: " + col[0].Subject + "\r\n\r\n";
                    }
                }
                if (!AllCertifOK)
                {
                    statusBar.Panels["CertificadosSBP"].Text = "Certificados: ERROR ";
                }
                Aplicacion.Vendedores = vendedores;
            }
            MessageBox.Show("Modificación realizada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            CuitVendedorComboBox.SelectedIndex = 0;
        }

        private void VerLogo(Byte[] Logo)
        {
            if (Logo != null && Logo.Length != 0)
            {
                MemoryStream memorybits = new MemoryStream(Logo);
                Bitmap bitmap = new Bitmap(memorybits);
                VendedorLogoPictureBox.Image = bitmap;
            }
        }

        private void BorrarImagenButton_Click(object sender, EventArgs e)
        {
            vendedor.Logo = null;
            VendedorLogoPictureBox.Image = null;
        }
    }
}