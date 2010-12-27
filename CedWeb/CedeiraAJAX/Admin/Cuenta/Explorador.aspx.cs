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

namespace CedeiraAJAX.Admin.Cuenta
{
	public partial class Explorador : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				((LinkButton)Master.FindControl("AdministracionLinkButton")).ForeColor = System.Drawing.Color.Gold;
				if (!IsPostBack)
				{
					if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
					{
						CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
					}
					else
					{
						if (CedWebRN.Fun.NoEstaLogueadoUnAdministrador((CedWebEntidades.Sesion)Session["Sesion"]))
						{
							CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosAdministradores.aspx");
						}
						else
						{
							CuentaPagingGridView.PageSize = 2;
							BindPagingGrid();
						}
					}
				}
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		private void BindPagingGrid()
		{
			try
			{
				System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
				lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				CuentaPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
				CuentaPagingGridView.DataBind();
				ViewState["filtro"] = null;
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
		}
		protected void CuentaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				CuentaPagingGridView.PageIndex = e.NewPageIndex;
				System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
				if (ViewState["filtro"] != null && !ViewState["filtro"].Equals(string.Empty))
				{
					CedeiraUIWebForms.PagingGridView pgv = (CedeiraUIWebForms.PagingGridView)sender;
					int indice = pgv.PageIndex * CuentaPagingGridView.PageSize;
					try
					{
						lista = ((System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"]).GetRange(indice, CuentaPagingGridView.PageSize);
					}
					catch
					{
						int total = ((System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"]).Count;
						lista = ((System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"]).GetRange(indice, total - indice);
					}
					CuentaPagingGridView.DataSource = lista;
				}
				else
				{
					lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
					CuentaPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
					ViewState["lista"] = lista;
					CuentaPagingGridView.DataSource = lista;
				}
				CuentaPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch (Exception ex)
			{
				CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
			}
		}
		protected void CuentaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{
				DesSeleccionarFilas();
				System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
				lista = CedWebRN.Cuenta.Lista(CuentaPagingGridView.PageIndex, CuentaPagingGridView.PageSize, CuentaPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
				ViewState["lista"] = lista;
				ViewState["filtro"] = null;
				CuentaPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
				CuentaPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
				CuentaPagingGridView.DataBind();
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch (Exception ex)
			{
				CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
			}
		}
		protected void CuentaPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DeshabilitarAcciones();
				CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
				System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
				if (ViewState["filtro"] != null && !ViewState["filtro"].Equals(string.Empty))
				{
					lista = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
					CedWebEntidades.Cuenta[] ctaArray = lista.ToArray();
					CedeiraUIWebForms.PagingGridView pgv = (CedeiraUIWebForms.PagingGridView)sender;
					int indice = pgv.CurrentPageIndex * CuentaPagingGridView.PageSize + pgv.SelectedIndex;
					cuenta = ctaArray[indice];
				}
				else
				{
					lista = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
					cuenta = (CedWebEntidades.Cuenta)lista[((CedeiraUIWebForms.PagingGridView)sender).SelectedIndex];				
				}
				
				string auxCache = "Cuenta" + Session.SessionID;
				Cache.Remove(auxCache);
				Cache.Add(auxCache, cuenta, null, DateTime.UtcNow.AddSeconds(300), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
				HabilitarAcciones(cuenta);
			}
			catch (System.Threading.ThreadAbortException)
			{
				Trace.Warn("Thread abortado");
			}
			catch (Exception ex)
			{
				CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
			}
		}
		protected void CuentaPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
				e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

				e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.CuentaPagingGridView, "Select$" + e.Row.RowIndex);
			}
		}
		private void DesSeleccionarFilas()
		{
			DeshabilitarAcciones();
			CuentaPagingGridView.SelectedIndex = -1;
			string auxCache = "Cuenta" + Session.SessionID;
			Cache.Remove(auxCache);
		}
		private void HabilitarAcciones(CedWebEntidades.Cuenta Cuenta)
		{
			switch (Cuenta.EstadoCuenta.Id)
			{
				case "Vigente":
					BajaButton.Enabled = true;
					ActivCPButton.Enabled = true;
					break;
				case "Baja":
					AnularBajaButton.Enabled = true;
					break;
				case "PteConf":
					BajaButton.Enabled = true;
					ReenviarMailButton.Enabled = true;
					break;
				case "Suspend":
					ActivCPButton.Enabled = true;
					break;
			}
			switch (Cuenta.TipoCuenta.Id)
			{
				case "Prem":
					switch (Cuenta.EstadoCuenta.Id)
					{
						case "Vigente":
							SuspenderPremiumButton.Enabled = true;
							DesactivarPremiumButton.Enabled = true;
							ActivarPremiumButton.Enabled = true;
							break;
						case "Suspend":
							ActivarPremiumButton.Enabled = true;
							DesactivarPremiumButton.Enabled = true;
							break;
					}
					break;
				case "Free":
					switch (Cuenta.EstadoCuenta.Id)
					{
						case "Vigente":
							ActivarPremiumButton.Enabled = true;
							break;
					}
					break;
			}
		}
		private void DeshabilitarAcciones()
		{
			BajaButton.Enabled = false;
			AnularBajaButton.Enabled = false;
			ReenviarMailButton.Enabled = false;
			ActivCPButton.Enabled = false;
			SuspenderPremiumButton.Enabled = false;
			ActivarPremiumButton.Enabled = false;
			DesactivarPremiumButton.Enabled = false;
		}
		protected CedWebEntidades.Cuenta CuentaSeleccionada()
		{
			string auxCache = "Cuenta" + Session.SessionID;
			CedWebEntidades.Cuenta cta = (CedWebEntidades.Cuenta)Cache[auxCache];
			return cta;
		}
        protected void IdFilterButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            try
            {
				DesSeleccionarFilas();
				string filtro = ((TextBox)CuentaPagingGridView.HeaderRow.FindControl("IdFilterTextBox")).Text;
				System.Collections.Generic.List<CedWebEntidades.Cuenta> ctas=CedWebRN.Cuenta.Leer(filtro, (CedEntidades.Sesion)Session["Sesion"]);
				CuentaPagingGridView.DataSource = ctas;
				CuentaPagingGridView.VirtualItemCount = ctas.Count;
				CuentaPagingGridView.DataBind();
				ViewState["lista"] = ctas;
				ViewState["filtro"]=filtro;
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void BajaButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.DarDeBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void AnularBajaButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.AnularBaja(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void ReenviarMailButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.ReenviarMail(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void ActivCPButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.CambiarActivCP(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void SuspenderPremiumButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.SuspenderPremium(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void ActivarPremiumButton_Click(object sender, EventArgs e)
		{
			Session["CuentaPremiumActivar-Id"] = CuentaSeleccionada().Id;
			Response.Redirect("~/CuentaPremiumActivar.aspx", true);
		}
		protected void DesactivarPremiumButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.DesactivarPremium(CuentaSeleccionada(), (CedEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void DepurarButton_Click(object sender, EventArgs e)
		{
			MsgErrorLabel.Text = String.Empty;
			try
			{
				CedWebRN.Cuenta.Depurar((CedWebEntidades.Sesion)Session["Sesion"]);
				BindPagingGrid();
				DesSeleccionarFilas();
			}
			catch (Exception ex)
			{
				MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
			}
		}
		protected void SalirButton_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Admin/Default.aspx");
		}

		protected void CuentaPagingGridView_PreRender(object sender, EventArgs e)
		{
			((TextBox)CuentaPagingGridView.HeaderRow.FindControl("IdFilterTextBox")).Text = Convert.ToString(ViewState["filtro"]);
		}
	}
}
