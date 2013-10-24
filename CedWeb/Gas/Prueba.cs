using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gas
{
    public partial class Prueba : Form
    {
        public Prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileHelpers.DataLink.ExcelStorage fh = new FileHelpers.DataLink.ExcelStorage(typeof(Planilla1));
            fh.FileName = @"C:\KS\PruebaXLS\Reporte de Cobranzas.xls";
            fh.SheetName = "PEPE";
            fh.StartRow = 2;
            fh.StartColumn = 1;
            fh.OverrideFile = false;
            

            Planilla1 p = new Planilla1();
            p.Fecha = Convert.ToDateTime("01/01/2011");
            p.megid_contrato_gas = "pepe";
            p.megid_punto_medicion = "hola";
            p.megid_tipo_balance = "hola2";
            p.volumen = "1000.53";
            Planilla1[] a = new Planilla1[2];
            a[0] = new Planilla1();
            a[0].Fecha = Convert.ToDateTime("01/01/2011");
            a[0].megid_contrato_gas = "pepe";
            a[0].megid_punto_medicion = "pepe2";
            a[0].megid_tipo_balance = "pepe3";
            a[0].volumen = "1000,56";
            a[1] = new Planilla1();
            a[1].Fecha = Convert.ToDateTime("01/01/2011");
            a[1].megid_contrato_gas = "pepe";
            a[1].megid_punto_medicion = "pepe2";
            a[1].megid_tipo_balance = "pepe3";
            a[1].volumen = "1000,57";
            fh.InsertRecords(a);
        }
    }
}