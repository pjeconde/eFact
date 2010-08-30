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

namespace CedeiraAJAX.Facturacion.Electronica
{
	public partial class Impuestos : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ResetearGrillas();
			}
		}
		public void BindearDropDownLists()
		{
			if (impuestosGridView.FooterRow != null)
			{
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataValueField = "Codigo";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataTextField = "Descr";
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
				((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).DataBind();
			}
		}
		public void ResetearGrillas()
		{
			impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
			FeaEntidades.InterFacturas.resumenImpuestos impuesto = new FeaEntidades.InterFacturas.resumenImpuestos();
			impuestos.Add(impuesto);
			impuestosGridView.DataSource = impuestos;
			ViewState["impuestos"] = impuestos;
			DataBind();

			BindearDropDownLists();

		}

		public void Completar(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
			if (lc.comprobante[0].resumen.impuestos != null)
			{
				foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lc.comprobante[0].resumen.impuestos)
				{
					if (imp.importe_impuesto_moneda_origenSpecified)
					{
						imp.importe_impuesto = imp.importe_impuesto_moneda_origen;
					}
					impuestos.Add(imp);
				}
			}
			if (impuestos.Count.Equals(0))
			{
				impuestos.Add(new FeaEntidades.InterFacturas.resumenImpuestos());
			}
			impuestosGridView.DataSource = impuestos;
			impuestosGridView.DataBind();
			ViewState["impuestos"] = impuestos;


		}
		public void CompletarWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
			if (lc.comprobante[0].resumen.impuestos != null)
			{
				impuestos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>();
				foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteResumenImpuestos imp in lc.comprobante[0].resumen.impuestos)
				{
					if (imp.importe_impuesto_moneda_origenSpecified)
					{
						imp.importe_impuesto = imp.importe_impuesto_moneda_origen;
					}
					FeaEntidades.InterFacturas.resumenImpuestos ri = new FeaEntidades.InterFacturas.resumenImpuestos();
					ri.codigo_impuesto = imp.codigo_impuesto;
					ri.codigo_jurisdiccion = imp.codigo_jurisdiccion;
					ri.codigo_jurisdiccionSpecified = imp.codigo_jurisdiccionSpecified;
					ri.descripcion = imp.descripcion;
					ri.importe_impuesto = imp.importe_impuesto;
					ri.importe_impuesto_moneda_origen = imp.importe_impuesto_moneda_origen;
					ri.importe_impuesto_moneda_origenSpecified = imp.importe_impuesto_moneda_origenSpecified;
					ri.jurisdiccion_municipal = imp.jurisdiccion_municipal;
					ri.porcentaje_impuesto = imp.porcentaje_impuesto;
					ri.porcentaje_impuestoSpecified = imp.porcentaje_impuestoSpecified;
					impuestos.Add(ri);
				}
				if (impuestos.Count.Equals(0))
				{
					impuestos.Add(new FeaEntidades.InterFacturas.resumenImpuestos());
				}
				impuestosGridView.DataSource = impuestos;
				impuestosGridView.DataBind();
				ViewState["impuestos"] = impuestos;
			}
		}
		public System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> Lista
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				return refs;
			}
		}
		protected void impuestosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			impuestosGridView.EditIndex = -1;
			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();
		}
		protected void impuestosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("AddImpuestoGlobal"))
			{
				try
				{
					FeaEntidades.InterFacturas.resumenImpuestos r = new FeaEntidades.InterFacturas.resumenImpuestos();
					int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedValue);
					r.codigo_impuesto = auxcodigo_impuesto;
					r.descripcion = ((DropDownList)impuestosGridView.FooterRow.FindControl("ddlcodigo_impuesto")).SelectedItem.Text;

					string auxTotal = ((TextBox)impuestosGridView.FooterRow.FindControl("txtimporte_impuesto")).Text;
					if (!auxTotal.Contains(","))
					{
						r.importe_impuesto = Convert.ToDouble(auxTotal);
					}
					else
					{
						throw new Exception("Impuesto global no agregado porque el separador de decimales debe ser el punto");
					}

					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Add(r);


					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
					FeaEntidades.InterFacturas.resumenImpuestos impuestoInicial = impuestos[0];
					if (impuestoInicial.codigo_impuesto == 0)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]).Remove(impuestoInicial);
					}

					impuestosGridView.DataSource = ViewState["impuestos"];
					impuestosGridView.DataBind();
					BindearDropDownLists();

				}
				catch (Exception ex)
				{
					ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				}
			}
		}
		protected void impuestosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				e.ExceptionHandled = true;
			}
		}
		protected void impuestosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
				FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
				impuestos.Remove(r);

				if (impuestos.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.resumenImpuestos nueva = new FeaEntidades.InterFacturas.resumenImpuestos();
					impuestos.Add(nueva);
				}
				impuestosGridView.EditIndex = -1;
				impuestosGridView.DataSource = ViewState["impuestos"];
				impuestosGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}
		protected void impuestosGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			impuestosGridView.EditIndex = e.NewEditIndex;

			impuestosGridView.DataSource = ViewState["impuestos"];
			impuestosGridView.DataBind();
			BindearDropDownLists();

			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataValueField = "Codigo";
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataTextField = "Descr";
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataSource = FeaEntidades.CodigosImpuesto.CodigoImpuesto.Lista();
			((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).DataBind();
			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_impuestoEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"])[e.NewEditIndex].codigo_impuesto.ToString());
				li.Selected = true;
			}
			catch
			{
			}
		}
		protected void impuestosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
				e.ExceptionHandled = true;
			}
		}
		protected void impuestosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);

				FeaEntidades.InterFacturas.resumenImpuestos r = impuestos[e.RowIndex];
				int auxcodigo_impuesto = Convert.ToInt32(((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedValue);
				r.codigo_impuesto = auxcodigo_impuesto;

				string auxdescr_impuesto = ((DropDownList)impuestosGridView.Rows[e.RowIndex].FindControl("ddlcodigo_impuestoEdit")).SelectedItem.Text;
				r.descripcion = auxdescr_impuesto;

				string auxTotal = ((TextBox)impuestosGridView.Rows[e.RowIndex].FindControl("txtimporte_impuesto")).Text;
				if (!auxTotal.Contains(","))
				{
					r.importe_impuesto = Convert.ToDouble(auxTotal);
				}
				else
				{
					throw new Exception("Impuesto global no actualizado porque el separador de decimales debe ser el punto");
				}

				impuestosGridView.EditIndex = -1;
				impuestosGridView.DataSource = ViewState["impuestos"];
				impuestosGridView.DataBind();
				BindearDropDownLists();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
			}
		}
		public bool HayImpuestos
		{
			get
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> impuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);

				if (impuestos[0].importe_impuesto.Equals(0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
		public void GenerarImpuestos(FeaEntidades.InterFacturas.comprobante comp, string monedaComprobante, string tipoDeCambio)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos>)ViewState["impuestos"]);
			comp.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[listadeimpuestos.Count];
			for (int i = 0; i < listadeimpuestos.Count; i++)
			{
				if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
				{
					comp.resumen.impuestos[i] = new FeaEntidades.InterFacturas.resumenImpuestos();
					comp.resumen.impuestos[i].codigo_impuesto = listadeimpuestos[i].codigo_impuesto;
					comp.resumen.impuestos[i].codigo_jurisdiccion = listadeimpuestos[i].codigo_jurisdiccion;
					comp.resumen.impuestos[i].codigo_jurisdiccionSpecified = listadeimpuestos[i].codigo_jurisdiccionSpecified;
					comp.resumen.impuestos[i].descripcion = listadeimpuestos[i].descripcion;
					comp.resumen.impuestos[i].porcentaje_impuesto = listadeimpuestos[i].porcentaje_impuesto;
					comp.resumen.impuestos[i].porcentaje_impuestoSpecified = listadeimpuestos[i].porcentaje_impuestoSpecified;
					if (monedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
					{
						comp.resumen.impuestos[i].importe_impuesto = listadeimpuestos[i].importe_impuesto;
					}
					else
					{
						comp.resumen.impuestos[i].importe_impuesto = Math.Round(listadeimpuestos[i].importe_impuesto * Convert.ToDouble(tipoDeCambio), 2);
						comp.resumen.impuestos[i].importe_impuesto_moneda_origen = listadeimpuestos[i].importe_impuesto;
						comp.resumen.impuestos[i].importe_impuesto_moneda_origenSpecified = true;
					}
				}
			}
		}
	}
}