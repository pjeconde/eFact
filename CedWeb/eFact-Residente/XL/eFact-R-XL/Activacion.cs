using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace eFact_R_XL
{
    public partial class Activacion : Form
    {
        public Activacion()
        {
            InitializeComponent();
            ClaveSolicitudTextBox.Text = Aplicacion.ClaveSolicitud;
        }
        private void RegistrarButton_Click(object sender, EventArgs e)
        {
            if (ClaveActivacionTextBox.Text == String.Empty)
            {
                MessageBox.Show("Debe ingresar la clave de activacion obtenida del sitio de Cedeira", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RN.Registro.Guardar(Registry.LocalMachine, Aplicacion.RegistroNombreClave, "k", ClaveActivacionTextBox.Text);
                MessageBox.Show("La aplicación fué activada satisfactoriamente.  Vuelva a ingresar para operar normalmente.", "IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
        }
        private void SalirButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}