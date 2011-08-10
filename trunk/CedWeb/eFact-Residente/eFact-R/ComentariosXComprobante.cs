using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace eFact_R
{
    public partial class ComentariosXComprobante : Form
    {
        private string comentario;
        public ComentariosXComprobante(string Comentario)
        {
            InitializeComponent();
            comentario = Comentario;
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Comentarios_Load(object sender, EventArgs e)
        {
            //Determino si el comentario es XML
            if (comentario.Substring(0, 1) != "<")
            {
                ComentariosTextBox.Text = comentario;
                XMLWebBrowser.Visible = false;
            }
            else
            {
                this.XMLWebBrowser.Navigate("about:blank");
                try
                {
                    if (comentario != "")
                    {
                        StreamWriter fileWriter;
                        fileWriter = File.CreateText(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XML-Comprobante.xml");
                        string c = comentario.Replace("iso-8859-1", "UTF-8");
                        fileWriter.Write(c);
                        fileWriter.Close();
                        XMLWebBrowser.Navigate(System.IO.Path.GetTempPath() + Aplicacion.Sesion.Usuario.IdUsuario + "-XML-Comprobante.xml");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Solapa XML Origen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}