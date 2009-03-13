﻿using System;
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
    public partial class FacturaElectronica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id == null)
                {
                    UsuarioLogueadoPanel.Visible = false;
                }
                else
                {
                    UsuarioNoLogueadoPanel.Visible = false;
                }
            }
        }
    }
}