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
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"]);
            nds[1].Nodes[3].Nodes.Add(ndNuevo);
            
            ndNuevo = new TreeNode("DominioProxy");
            nds[1].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["DominioProxy"]);
            nds[1].Nodes[4].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Visualizar Archivos en la Bandeja de Entrada");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            ndNuevo = new TreeNode(@System.Configuration.ConfigurationManager.AppSettings["VisualizarArchivos"]);
            nds[2].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Fijar valores de Otros Filtros de la Bandeja de Salida");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosArchivos);
            nds[3].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Cuit");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosCuit);
            nds[3].Nodes[1].Nodes.Add(ndNuevo);

            ndNuevo = new TreeNode("Punto de venta");
            nds[3].Nodes.Add(ndNuevo);
            ndNuevo = new TreeNode(Aplicacion.OtrosFiltrosPuntoVta);
            nds[3].Nodes[2].Nodes.Add(ndNuevo);

            treeView1.ExpandAll();
        }
    }
}