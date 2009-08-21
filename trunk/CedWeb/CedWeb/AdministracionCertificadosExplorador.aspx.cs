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

public partial class AdministracionCertificadosExplorador : System.Web.UI.Page
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
						CertPagingGridView.PageSize = 15;
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
			lista = CedWebRN.Certificado.Lista(CertPagingGridView.PageIndex, CertPagingGridView.PageSize, CertPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
			CertPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
			ViewState["lista"] = lista;
			CertPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
			CertPagingGridView.DataBind();
		}
		catch (System.Threading.ThreadAbortException)
		{
			Trace.Warn("Thread abortado");
		}
	}
	protected void CertPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
	{
		try
		{
			System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
			lista = CedWebRN.Certificado.Lista(CertPagingGridView.PageIndex, CertPagingGridView.PageSize, CertPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
			ViewState["lista"] = lista;
			CertPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
			CertPagingGridView.DataBind();
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
}
