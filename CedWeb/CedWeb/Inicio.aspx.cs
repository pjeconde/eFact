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
    public partial class Iniciar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			if (UsuarioTextBox.Text == String.Empty)
			{
				MsgErrorLabel.Text = "Usuario no informado";
			}
			else if (PasswordTextBox.Text == String.Empty)
			{
				MsgErrorLabel.Text = "Contraseña no informada";
			}
			else
			{
				MsgErrorLabel.Text = "Usuario inexistente";
			}
		}
		protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
		}
		protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
		}
	}
}