using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_R
{
    public partial class ConsultaComprobante : Form
    {
        public ConsultaComprobante(CrystalDecisions.CrystalReports.Engine.ReportDocument FacturaRpt)
        {
            InitializeComponent();
            ConsultaComprobanteCRViewer.ReportSource = FacturaRpt;
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaComprobanteCRViewer_Load(object sender, EventArgs e)
        {

        }
    }
}