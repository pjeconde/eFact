using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private string CnnStr1;
        private string CnnStr2;
        private string CnnStr3;

        public Form1()
        {
            InitializeComponent();
            CnnStr1 = @System.Configuration.ConfigurationManager.AppSettings["CnnStr1"];
            CnnStr2 = @System.Configuration.ConfigurationManager.AppSettings["CnnStr2"];
            CnnStr3 = @System.Configuration.ConfigurationManager.AppSettings["CnnStr3"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(CnnStr1);
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(CnnStr2);
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(CnnStr3);
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }
    }
}