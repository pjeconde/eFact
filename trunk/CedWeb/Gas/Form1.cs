using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Gas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileHelpers.DataLink.ExcelStorage fh = new FileHelpers.DataLink.ExcelStorage(typeof(Planilla1));
            fh.FileName = @"C:\eFact-R-Docs\GAS\EXCEL-Macro\TablasExcel.xls";
            fh.SheetName = "CONF 2011-08-16";
            fh.StartRow = 2;
            fh.StartColumn = 1;
            Planilla1[] conf = (Planilla1[]) fh.ExtractRecords();

            fh.SheetName = "ASIG 2011-08-16";
            fh.StartRow = 2;
            fh.StartColumn = 1;
            Planilla1[] asig = (Planilla1[])fh.ExtractRecords();

            AsigConf.dias_operativos dops = new AsigConf.dias_operativos();
            AsigConf.dias_operativosDia_operativo[] item = new AsigConf.dias_operativosDia_operativo[1];
            item[0] = new AsigConf.dias_operativosDia_operativo();
            item[0].fecha = conf[0].Fecha.ToString("yyyyMMdd");
            dops.Items = new AsigConf.dias_operativosDia_operativo[1];
            dops.Items[0] = item[0];

            AsigConf.dias_operativosDia_operativoVolumen_gas[] vgas = new AsigConf.dias_operativosDia_operativoVolumen_gas[conf.Length];
            for (int i = 0; i < conf.Length; i++)
            {
                vgas[i] = new AsigConf.dias_operativosDia_operativoVolumen_gas();
                vgas[i].megid_contrato_gas = conf[i].megid_contrato_gas;
                vgas[i].megid_tipo_balance = "DI";
                vgas[i].mov = "A";
            }
            dops.Items[0].volumenes_gas = vgas;

            //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(dops.GetType());
            x.Serialize(writer, dops);
            ms = (MemoryStream)writer.BaseStream;
            string resp = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;
        }
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
    }
}