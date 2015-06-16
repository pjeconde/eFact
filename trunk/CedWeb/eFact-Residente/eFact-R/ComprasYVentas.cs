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
    public partial class ComprasYVentas : Form
    {
        private eFact_Entidades.Vendedor vendedor = new eFact_Entidades.Vendedor();
        public ComprasYVentas()
        {
            InitializeComponent();
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
                GenerarButton.Enabled = false;
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
            vendedor = new eFact_Entidades.Vendedor();
            GenerarButton.Enabled = false;
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                string CuitVendedor = ((ComboBox)sender).SelectedItem.ToString().Trim();
                vendedor.CuitVendedor = CuitVendedor;
                eFact_RN.Vendedor.Leer(vendedor, Aplicacion.Sesion);
                GenerarButton.Enabled = true;
            }
        }

        private void GenerarButton_Click(object sender, EventArgs e)
        {
            eFact_RN.Vendedor.Modificar(vendedor, Aplicacion.Sesion);
            
            List<eFact_Entidades.Vendedor> vendedores = new List<eFact_Entidades.Vendedor>();
            eFact_RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
            if (vendedores.Count > 0)
            {
                Aplicacion.Vendedores = vendedores;
            }
            MessageBox.Show("Modificación realizada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            CuitVendedorComboBox.SelectedIndex = 0;
        }
    }
}