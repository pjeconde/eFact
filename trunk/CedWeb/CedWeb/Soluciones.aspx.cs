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
namespace CedWeb
{
    public partial class Soluciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ultimoNodoPpal;
                Arbol.Nodes.Add(new TreeNode("Otras soluciones relacionadas al área financiera"));
                ultimoNodoPpal = Arbol.Nodes.Count - 1;
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Administración y Presentación de Contenidos (implementación Capitales Mínimos) • Asambleas y Accionistas"));
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Libranzas y Pagos Judiciales • Autorización de Tasas de Sucursales • Administración de Carteras"));
                Arbol.Nodes[ultimoNodoPpal].ChildNodes.Add(new TreeNode("Plataforma Mesa de Dinero"));
				for (int i = 0; i < Arbol.Nodes.Count; i++)
				{
					Arbol.Nodes[i].SelectAction = TreeNodeSelectAction.None;
					for (int j = 0; j < Arbol.Nodes[i].ChildNodes.Count; j++)
					{
						Arbol.Nodes[i].ChildNodes[j].SelectAction = TreeNodeSelectAction.None;
					}
				}
                Arbol.RootNodeStyle.Font.Size = CedFCItituloLabel.Font.Size;
				Arbol.ShowExpandCollapse = true;
				Arbol.ShowLines = false;
				Arbol.ImageSet = TreeViewImageSet.Custom;
				Arbol.NoExpandImageUrl = "";
				Arbol.ExpandImageUrl = "Imagenes/CajaBrownPeruMas.ico";
				Arbol.CollapseImageUrl = "Imagenes/CajaBrownPeruMenos.ico";
				Arbol.RootNodeStyle.HorizontalPadding = 4;
                Arbol.NodeIndent = 0;
            }
        }
    }
}