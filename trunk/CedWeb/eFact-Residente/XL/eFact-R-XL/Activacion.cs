using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_R_XL
{
    public partial class Activacion : Form
    {
        public Activacion(string NroSerieDisco)
        {
            InitializeComponent();
            ClaveSolicitudTextBox.Text = NroSerieDisco;
        }
    }
}