using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedeiraAJAX
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ultimoNodoPpal;

				Arbol.Nodes.Add(new TreeNode("Agro"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("K+S Argentina S.R.L. � ADM ARGENTINA S.A."));

				Arbol.Nodes.Add(new TreeNode("Agroindustrial"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Asamach S.R.L. � EQUITEC S.A. � Metal�rgica Patria S.R.L. � Microservice S.T.I. S.R.L."));

                Arbol.Nodes.Add(new TreeNode("Bancos"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Banco Galicia � Banco de Liniers Sudamericano � Banco Medefin"));
                Arbol.Nodes.Add(new TreeNode("Centros Comerciales"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Alto Palermo Shopping � Abasto de Buenos Aires � Alto Avellaneda Shopping Mall � Buenos Aires Design (Emprendimiento Recoleta S.A.)"));
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Paseo Alcorta � Patio Bullrich � Nuevo Norte Shopping S.A. (Salta)"));
                Arbol.Nodes.Add(new TreeNode("Constructoras"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Boris Lend Lease S.A. � Alhena S.A. � Blasi y Vazquez Constructora S.A."));
                Arbol.Nodes[ultimoNodoPpal].CollapseAll();
                Arbol.Nodes.Add(new TreeNode("Fondos Comunes de Inversi�n (Administraci�n)"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Galicia Administradora de Fondos"));

				Arbol.Nodes.Add(new TreeNode("Frigor�ficos"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("AMANCAY SAICAFI"));

                Arbol.Nodes.Add(new TreeNode("Hiper-Super-Mini Mercados"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Disco S.A. � Supermercados La Gran Provisi�n � Casa T�a � Captar S.A. (Tarjeta de compra) � Supermercados Elefante (Mar del Plata)"));
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Carrefour Argentina S.A � Stop (minimercados en estaciones de servicio) � Provisi�n El Quijote"));

                Arbol.Nodes.Add(new TreeNode("Industria"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("CERAMICA ALBERDI S.A. � GRUPELEC S.A. � Integral Gr�fica S.A. � Premium Gr�fica � Grafo Stil S.R.L."));

				Arbol.Nodes.Add(new TreeNode("Inform�tica"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Extreme Connection S.A. � Ribox S.R.L."));

				Arbol.Nodes.Add(new TreeNode("Inmobiliarias"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Fibesa S.A."));
				Arbol.Nodes[ultimoNodoPpal].CollapseAll();

				Arbol.Nodes.Add(new TreeNode("Obra Social"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("OPDEA Obra Soc.Pers.Direc.Emp. de la Alimentaci�n"));

				Arbol.Nodes.Add(new TreeNode("Otras"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Rossi y Moscatelli S.A.(autopartes) � FreeHouse S.R.L. � El�as Walter Esquenazzi S.R.L.(R�o IV, Cba.) � Grisell S.A.(R�o IV, Cba.)"));
				Arbol.Nodes[ultimoNodoPpal].CollapseAll();

                Arbol.Nodes.Add(new TreeNode("Publicidad"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Delfino Magnus S.A. � Ing. Augusto Spinazzola S.C.A � Julius V�a P�blica S.A. � Meca Media Group � Caled V�a P�blica"));
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("y Divisi�n Aeropuertos � V�a P�blica Clan S.A. � Verdad Publicidad S.A. � Publipal S.R.L. � Ital-Art S.A. � Poster S.A.(Uruguay)"));

				Arbol.Nodes.Add(new TreeNode("Telemarketing"));
				ultimoNodoPpal = Arbol.Nodes.Count - 1;
				Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Compra Directa � TV Compras � Clasiclips (Hogar y Ventas S.R.L.) � Editorial Video Idiomas S.R.L."));
				Arbol.Nodes[ultimoNodoPpal].CollapseAll();

				Arbol.Nodes.Add(new TreeNode("Transporte"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Jos� Fiorentino y C�a. S.R.L"));
                Arbol.Nodes[ultimoNodoPpal].CollapseAll();


				for (int i = 0; i < Arbol.Nodes.Count; i++)
                {
                    Arbol.Nodes[i].SelectAction = TreeNodeSelectAction.None;
                    for (int j = 0; j < Arbol.Nodes[i].ChildNodes.Count; j++)
                    {
                        Arbol.Nodes[i].ChildNodes[j].SelectAction = TreeNodeSelectAction.None;
                    }
                }
                Arbol.ShowExpandCollapse = true;
                Arbol.ShowLines = false;
                Arbol.ImageSet = TreeViewImageSet.Custom;
                Arbol.NoExpandImageUrl = "";
                Arbol.ExpandImageUrl = "Imagenes/CajaBrownPeruMas.ico";
                Arbol.CollapseImageUrl = "Imagenes/CajaBrownPeruMenos.ico";
                Arbol.RootNodeStyle.HorizontalPadding = 4;
                Arbol.NodeIndent = 0;
                Arbol.LeafNodeStyle.Font.Italic = true;
                Arbol.RootNodeStyle.VerticalPadding = 2;
                ((LinkButton)Master.FindControl("ClientesLinkButton")).ForeColor = System.Drawing.Color.Gold;
            }
        }
    }

}
