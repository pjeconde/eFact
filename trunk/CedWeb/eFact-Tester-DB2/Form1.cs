using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Tester_DB2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = "Tester-DB2 v.3";
            textBox1.Text = @System.Configuration.ConfigurationManager.AppSettings["CnnStr1"];
            textBox2.Text = @System.Configuration.ConfigurationManager.AppSettings["CnnStr2"];
            textBox3.Text = @System.Configuration.ConfigurationManager.AppSettings["CnnStr3"];
            textBox4.Text = @System.Configuration.ConfigurationManager.AppSettings["CnnStr4"];
            textBox5.Text = @System.Configuration.ConfigurationManager.AppSettings["CnnStr5"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(textBox1.Text);
                cn.Open();
                MessageBox.Show(cn.State.ToString(), "INFORMACION", MessageBoxButtons.OK);
                cn.Close();
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
                OleDbConnection cn = new OleDbConnection(textBox2.Text);
                cn.Open();
                MessageBox.Show(cn.State.ToString(), "INFORMACION", MessageBoxButtons.OK);
                cn.Close();
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
                OleDbConnection cn = new OleDbConnection(textBox3.Text);
                cn.Open();
                MessageBox.Show(cn.State.ToString(), "INFORMACION", MessageBoxButtons.OK);

                DateTime fec = DateTime.Now;
                // Tabla: "BECCL" - Comprobante ER
                string myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                //Descrpcion del 1 a 30
                myInsertQueryER += "BEIDE1, ";
                //31 a 60
                myInsertQueryER += "BEIDE2, ";
                //61 a 90
                myInsertQueryER += "BEIDE3, ";
                //91 a 120
                myInsertQueryER += "BEIDE4, ";
                //121 a 150
                myInsertQueryER += "BEIDE5, ";
                myInsertQueryER += "BEIFPR, BEIHPR) ";
                myInsertQueryER += "values ('BI', 0, '" + fec.ToString("yyyyMMddhhmmss") + "', '', '', ";
                myInsertQueryER += "'01', '0011', '00000001', '231', 'DescrError1', 'DescrError2', 'DescrError3', 'DescrError4', 'DescrError5', '20110715', '142501') ";

                OleDbCommand myCommand = new OleDbCommand(myInsertQueryER);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 1 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                // Tabla: "BELLL" - Log
                string myInsertQueryER2 = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                myInsertQueryER2 += "values ('BL', '" + fec.ToString("yyyyMMddhhmmss") + "', 'ER', '20110715', '142501') ";
                //--------------------------------

                myCommand = new OleDbCommand(myInsertQueryER2);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 2 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                string fec2 = fec.ToString("yyMMddhhmmss") + "1";
                // Tabla: "BECCL" - Comprobante OK
                string myInsertQueryOK = "insert into BECCL (BCCID, BCCCOM, BCCIDL, BCCTCO, BCCCLA, ";
                myInsertQueryOK += "BCCTCA, BCCSUC, BCCNED, BCCCAE, BCCFVC, BCCFOC, BCCFPR, BCCHPR) ";
                myInsertQueryOK += "values ('BC', 0, '" + fec.ToString("yyyyMMddhhmmss") + "', '', '', ";
                myInsertQueryOK += "'01', '0011', '00000001', '20110715991111', '20110716', '20110715', '20110715', '142501') ";


                myCommand = new OleDbCommand(myInsertQueryOK);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 3 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                // Tabla: "BELLL" - Log
                string myInsertQueryOK2 = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                myInsertQueryOK2 += "values ('BL', '" + fec2 + "', 'OK', '20110715', '142501') ";
                //--------------------------------

                myCommand = new OleDbCommand(myInsertQueryOK2);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 4 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);
                
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(textBox4.Text);
                cn.Open();
                MessageBox.Show(cn.State.ToString(), "INFORMACION", MessageBoxButtons.OK);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //string myInsertQuery = "insert into [dbo].[Vendedores]([CuitVendedor],[Nombre],[NumeroSerieCertificado],[Codigo],[CondicionIVA],[CondicionIB],[NroIB],[InicioActividades],[Contacto],[DomicilioCalle],[DomicilioNumero],[DomicilioPiso],[DomicilioDepto],[DomicilioSector],[DomicilioTorre],[DomicilioManzana],[Localidad],[Provincia],[CP],[EMail],[Telefono]) values ('11223344556','','','',0,0,'','99981231','','','','','','','','','','0','','','')";

                OleDbConnection cn = new OleDbConnection(textBox5.Text);
                cn.Open();
                MessageBox.Show(cn.State.ToString(), "INFORMACION", MessageBoxButtons.OK);

                DateTime fec = DateTime.Now;
                // Tabla: "BECCL" - Comprobante ER
                string myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                //Descrpcion del 1 a 30
                myInsertQueryER += "BEIDE1, ";
                //31 a 60
                myInsertQueryER += "BEIDE2, ";
                //61 a 90
                myInsertQueryER += "BEIDE3, ";
                //91 a 120
                myInsertQueryER += "BEIDE4, ";
                //121 a 150
                myInsertQueryER += "BEIDE5, ";
                myInsertQueryER += "BEIFPR, BEIHPR) ";
                myInsertQueryER += "values ('BI', 0, '" + fec.ToString("yyyyMMddhhmmss") + "', '', '', ";
                myInsertQueryER += "'01', '0011', '00000001', '231', 'DescrError1', 'DescrError2', 'DescrError3', 'DescrError4', 'DescrError5', '20110715', '142501') ";

                OleDbCommand myCommand = new OleDbCommand(myInsertQueryER);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 1 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                // Tabla: "BELLL" - Log
                string myInsertQueryER2 = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                myInsertQueryER2 += "values ('BL', '" + fec.ToString("yyyyMMddhhmmss") + "', 'ER', '20110715', '142501') ";
                //--------------------------------

                myCommand = new OleDbCommand(myInsertQueryER2);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 2 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                string fec2 = fec.ToString("yyMMddhhmmss") + "1";
                // Tabla: "BECCL" - Comprobante OK
                string myInsertQueryOK = "insert into BECCL (BCCID, BCCCOM, BCCIDL, BCCTCO, BCCCLA, ";
                myInsertQueryOK += "BCCTCA, BCCSUC, BCCNED, BCCCAE, BCCFVC, BCCFOC, BCCFPR, BCCHPR) ";
                myInsertQueryOK += "values ('BC', 0, '" + fec.ToString("yyyyMMddhhmmss") + "', '', '', ";
                myInsertQueryOK += "'01', '0011', '00000001', '20110715991111', '20110716', '20110715', '20110715', '142501') ";
                

                myCommand = new OleDbCommand(myInsertQueryOK);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 3 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                // Tabla: "BELLL" - Log
                string myInsertQueryOK2 = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                myInsertQueryOK2 += "values ('BL', '" + fec2 + "', 'OK', '20110715', '142501') ";
                //--------------------------------

                myCommand = new OleDbCommand(myInsertQueryOK2);
                myCommand.Connection = cn;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Insert 4 realizado satisfactoriamente", "INFORMACION", MessageBoxButtons.OK);

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INFORMACION", MessageBoxButtons.OK);
            }
        }
    }
}