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

namespace CedeiraAJAX.Facturacion.Electronica.Extensiones
{
	public partial class Comerciales : System.Web.UI.UserControl
	{
		public string Texto
		{
			get
			{
				return DatosComericalesTextBox.Text;
			}
			set
			{
				DatosComericalesTextBox.Text = value;
			}
		}
	}
}