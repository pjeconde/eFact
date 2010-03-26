using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_R
{
    public partial class Comentarios : Form
    {
        public Comentarios(string Comentario)
        {
            InitializeComponent();
            ComentariosTextBox.Text = Comentario;
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}