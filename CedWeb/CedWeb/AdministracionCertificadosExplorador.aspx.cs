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
						CertPagingGridView.PageSize = 20;
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
	protected void CertPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
	{
		CertPagingGridView.EditIndex = e.NewEditIndex;
		CertPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
		CertPagingGridView.DataBind();

	}
	protected void CertPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		CertPagingGridView.EditIndex = -1;
		CertPagingGridView.DataSource = ViewState["lista"];
		CertPagingGridView.DataBind();

	}
	protected void CertPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		System.Collections.Generic.List<CedWebEntidades.Cuenta> lista = ((System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"]);
		CedWebEntidades.Cuenta c = lista[e.RowIndex];
		string nroCert = ((TextBox)CertPagingGridView.Rows[e.RowIndex].FindControl("txtNroSerieCertificado")).Text;
		c.NroSerieCertificado = nroCert;

		try
		{
			CedWebRN.Certificado.Confirmar(c, (CedWebEntidades.Sesion)Session["Sesion"]);
		}
		catch (Exception ex)
		{
			BindPagingGrid();
			ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.Replace("\r", "").Replace("\n", "") + "');</script>");
		}

		CertPagingGridView.EditIndex = -1;
		CertPagingGridView.DataSource = (System.Collections.Generic.List<CedWebEntidades.Cuenta>)ViewState["lista"];
		CertPagingGridView.DataBind();

	}
	protected void SalirButton_Click(object sender, EventArgs e)
	{
		Server.Transfer("~/Administracion.aspx");
	}
    protected void CertPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            CertPagingGridView.PageIndex = e.NewPageIndex;
            System.Collections.Generic.List<CedWebEntidades.Cuenta> lista;
            lista = CedWebRN.Cuenta.Lista(CertPagingGridView.PageIndex, CertPagingGridView.PageSize, CertPagingGridView.OrderBy, (CedEntidades.Sesion)Session["Sesion"]);
            CertPagingGridView.VirtualItemCount = CedWebRN.Cuenta.CantidadDeFilas((CedEntidades.Sesion)Session["Sesion"]);
            CertPagingGridView.DataSource = lista;
            CertPagingGridView.DataBind();
            ViewState["lista"] = lista;
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
