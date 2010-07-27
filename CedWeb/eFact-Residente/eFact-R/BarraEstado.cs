using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_R
{
    public partial class BarraEstado : Form
    {
        public BarraEstado()
        {
            InitializeComponent();

            TreeNodeCollection nds = treeView1.Nodes;
            TreeNode ndNuevo;
            nds.Clear();
            ndNuevo = new TreeNode("Origen de datos");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            //PDFs: " + Aplicacion.ArchPathPDF;
            //StatusBar.Panels["CXOSBP"].Text = "CXO: " + Aplicacion.Sesion.CXO;
            //StatusBar.Panels["CXOSBP"].ToolTipText = "Control por oposición: " + Aplicacion.Sesion.CXO;
            ndNuevo = new TreeNode("Directorio de Datos");
            nds[0].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.ArchPath);
            nds[0].Nodes[0].Nodes.Add(ndNuevo);
            
            ndNuevo = new TreeNode("Históricos");
            nds[0].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.ArchPathHis);
            nds[0].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Interfaz manual");
            nds[0].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.ArchPathItf);
            nds[0].Nodes[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Interfaz automática");
            nds[0].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.ArchPathItfAut);
            nds[0].Nodes[3].Nodes.Add(ndNuevo);
            
            ndNuevo = new TreeNode("Tipo de archivo ( Valores posibles: XML / TXT / NONE )");
            nds[0].Nodes[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["TipoItfAut"]);
            nds[0].Nodes[3].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("PDFs:");
            nds[0].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.ArchPathPDF);
            nds[0].Nodes[4].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("URL");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"]);
            nds[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Proxy");
            nds[1].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["Proxy"]);
            nds[1].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("UsuarioProxy");
            nds[1].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"]);
            nds[1].Nodes[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("ClaveProxy");
            nds[1].Nodes.Add(ndNuevo);
            string clave = @System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
            string claveNoVisible = "";
            for (int i = 0; i < clave.Length; i++)
            {
                claveNoVisible += "*"; 
            }
            ndNuevo = new TreeNode(claveNoVisible);
            nds[1].Nodes[3].Nodes.Add(ndNuevo);
            
            ndNuevo = new TreeNode("DominioProxy");
            nds[1].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["DominioProxy"]);
            nds[1].Nodes[4].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("StoreLocation");
            nds[1].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["StoreLocation"]);
            nds[1].Nodes[5].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Visualizar Archivos en la Bandeja de Entrada");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["VisualizarArchivos"]);
            nds[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Otros Filtros");
            nds.Add(ndNuevo);

            ndNuevo = new TreeNode("Filtrar la Bandeja de Entrada");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosFiltrarBE);
            nds[3].Nodes[0].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Filtrar la Bandeja de Salida");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosFiltrarBS);
            nds[3].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Cuit");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosCuit);
            nds[3].Nodes[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Punto de venta");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosPuntoVta);
            nds[3].Nodes[3].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Servicio de correo");
            nds.Add(ndNuevo);
            ndNuevo = new TreeNode("Servidor SMTP");
            nds[4].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"]);
            nds[4].Nodes[0].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Credenciales: Nombre de usuario");
            nds[4].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"]);
            nds[4].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Credenciales: Clave");
            nds[4].Nodes.Add(ndNuevo);
            clave = @System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
            claveNoVisible = "";
            for (int i = 0; i < clave.Length; i++)
            {
                claveNoVisible += "*";
            }
            ndNuevo = new TreeNode(claveNoVisible);
            nds[4].Nodes[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Testear servicio ( mail de prueba: " + System.Configuration.ConfigurationManager.AppSettings["MailTest"] + " )");
            nds[4].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode("Hacer doble clic sobre este nodo.");
            ndNuevo.Tag = "Clic";
            nds[4].Nodes[3].Nodes.Add(ndNuevo);
            nds[4].Nodes[3].Nodes[0].BackColor = Color.PeachPuff;

            ndNuevo = new TreeNode("DB CnnStr");
            nds.Add(ndNuevo);
            Char[] c = new char[1];
            c[0] = Convert.ToChar(";");
            string[] s = Aplicacion.Sesion.CnnStr.Split(c);
            string cnnstr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().Trim().IndexOf("Password=") == -1)
                {
                    cnnstr += s[i].ToString() + ";";
                }
                else
                {
                    cnnstr += "Password=";
                    for (int j = 0; j < s[i].Length - 9; j++)
                    {
                        cnnstr += "*";
                    }
                    cnnstr += ";";
                }
            }
            ndNuevo = new TreeNode(cnnstr);
            nds[5].Nodes.Add(ndNuevo);

            treeView1.ExpandAll();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (treeView1.SelectedNode.Tag == "Clic")
                {
                    string body = "Mail de Prueba";
                    string subject = "Notificación de excepción (Mail de Prueba)";
                    System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                    System.Net.Mail.MailMessage mail;
                    mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar", System.Configuration.ConfigurationManager.AppSettings["MailTest"], subject, body);
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
                    string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
                    string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
                    smtpClient.Host = MailServidorSmtp;
                    if (MailCredencialesUsr != "")
                    {
                        smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
                    }
                    smtpClient.Send(mail);
                }
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
    }
}