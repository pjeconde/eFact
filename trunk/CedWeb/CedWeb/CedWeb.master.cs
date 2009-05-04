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
	public partial class CedWeb : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                MensajeGeneralLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).MensajeGeneral;
                if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre != null)
                {
                    NombreCuentaLabel.Text = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                    Separador1Label.Visible = true;
                    ConfiguracionLinkButton.Visible = true;
                    Separador2Label.Visible = true;
                    SalirLinkButton.Visible = true;
                    switch (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.TipoCuenta.Id)
                    {
                        case "Admin":
                            AdministracionLinkButton.Visible = true;
                            break;
                        case "Prem":
                            switch (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.EstadoCuenta.Id)
                            {
                                case "Vigente":
                                    ServicioPremiumEstadoLabel.Text = "Servicio Premium vigente";
                                    TimeSpan n = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.FechaVtoPremium.Subtract(DateTime.Today);
                                    if (n.Days == 0)
                                    {
                                        ServicioPremiumVtoLabel.Text = "(caduca hoy)";
                                    }
                                    else
                                    {
                                        if (n.Days == 1)
                                        {
                                            ServicioPremiumVtoLabel.Text = "(caduca mañana)";
                                        }
                                        else
                                        {
                                            if (n.Days > 1 && n.Days < 10)
                                            {
                                                ServicioPremiumVtoLabel.Text = "(caduca en " + n.Days.ToString() + " días)";
                                            }
                                        }
                                    }
                                    break;
                                case "Suspend":
                                    ServicioPremiumEstadoLabel.Text = "Servicio Premium suspendido";
                                    break;
                            }
                            break;
                        case "Free":
                            ServicioPremiumEstadoLabel.Text = "Servicio Premium no activado";
                            break;
                    }
                }
				if (Request.UrlReferrer!=null)
				{
					Session["ref"] = Request.UrlReferrer.AbsoluteUri;
				}
            }
		}
        public void SalirLinkButton_Click(object sender, EventArgs e)
        {
            CaducarIdentificacion();
            Response.Redirect("~/Inicio.aspx", true);
        }
        public void CaducarIdentificacion()
        {
            CedWebEntidades.Sesion sesion = (CedWebEntidades.Sesion)Session["Sesion"];
            CedWebRN.Cuenta.Limpiar(sesion.Cuenta);
            NombreCuentaLabel.Text = String.Empty;
            Separador1Label.Visible = false;
            ConfiguracionLinkButton.Visible = false;
            Separador2Label.Visible = false; 
            SalirLinkButton.Visible = false;
            AdministracionLinkButton.Visible = false;
            Session["AceptarTYC"] = null;
        }
    }
}	
