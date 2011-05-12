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
	public partial class Descuentos : System.Web.UI.UserControl
	{
		System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> descuentos;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				ResetearGrillas();
			}
		}
		protected void descuentosGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			descuentosGridView.EditIndex = -1;
			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
		}

		protected void descuentosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Adddescuentos"))
			{
				try
				{
					FeaEntidades.InterFacturas.resumenDescuentos rd = new FeaEntidades.InterFacturas.resumenDescuentos();

					string auxDescr = ((TextBox)descuentosGridView.FooterRow.FindControl("txtdescripcion")).Text;
					if (!auxDescr.Equals(string.Empty))
					{
						rd.descripcion_descuento = auxDescr;
					}
					else
					{
						throw new Exception("Descuento no agregado porque la descripción no puede estar vacía");
					}
					string auxTotal = ((TextBox)descuentosGridView.FooterRow.FindControl("txtimporte_descuento")).Text;
					if (!auxTotal.Contains(","))
					{
						rd.importe_descuento = Convert.ToDouble(auxTotal);
					}
					else
					{
						throw new Exception("Descuento no agregado porque el separador de decimales debe ser el punto");
					}

					((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Add(rd);


					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
					if (rds[0].descripcion_descuento == null)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]).Remove(rds[0]);
					}

					//Saco de edición la fila que estén modificando
					if (!descuentosGridView.EditIndex.Equals(-1))
					{
						descuentosGridView.EditIndex = -1;
					}

					descuentosGridView.DataSource = ViewState["descuentos"];
					descuentosGridView.DataBind();

				}
				catch (Exception ex)
				{
					ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
				}
			}
		}

		protected void descuentosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				e.ExceptionHandled = true;
			}
		}

		protected void descuentosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);
				FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
				rds.Remove(rd);

				if (rds.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.resumenDescuentos nuevo = new FeaEntidades.InterFacturas.resumenDescuentos();
					rds.Add(nuevo);
				}

				descuentosGridView.EditIndex = -1;

				descuentosGridView.DataSource = ViewState["descuentos"];
				descuentosGridView.DataBind();
			}
			catch
			{
			}
		}

		protected void descuentosGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			descuentosGridView.EditIndex = e.NewEditIndex;
			descuentosGridView.DataSource = ViewState["descuentos"];
			descuentosGridView.DataBind();
		}

		protected void descuentosGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this.Parent.Page, GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
				e.ExceptionHandled = true;
			}
		}

		protected void descuentosGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> rds = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"]);

				FeaEntidades.InterFacturas.resumenDescuentos rd = rds[e.RowIndex];
				string auxDescr = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtdescripcion")).Text;
				if (!auxDescr.Equals(string.Empty))
				{
					rd.descripcion_descuento = auxDescr;
				}
				else
				{
					throw new Exception("Descuento no actualizado porque la descripción no puede estar vacía");
				}
				string auxTotal = ((TextBox)descuentosGridView.Rows[e.RowIndex].FindControl("txtimporte_descuento")).Text;
				if (!auxTotal.Contains(","))
				{
					rd.importe_descuento = Convert.ToDouble(auxTotal);
				}
				else
				{
					throw new Exception("Descuento no actualizado porque el separador de decimales debe ser el punto");
				}

				descuentosGridView.EditIndex = -1;
				descuentosGridView.DataSource = ViewState["descuentos"];
				descuentosGridView.DataBind();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Parent.Page, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
			}
		}

		public void Completar(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
			if (lc.comprobante[0].resumen.descuentos != null)
			{
				foreach (FeaEntidades.InterFacturas.resumenDescuentos r in lc.comprobante[0].resumen.descuentos)
				{
					if (r.importe_descuento_moneda_origenSpecified)
					{
						r.importe_descuento = r.importe_descuento_moneda_origen;
					}
					descuentos.Add(r);
				}
			}
			if (descuentos.Count.Equals(0))
			{
				descuentos.Add(new FeaEntidades.InterFacturas.resumenDescuentos());
			}
			descuentosGridView.DataSource = descuentos;
			descuentosGridView.DataBind();
			ViewState["descuentos"] = descuentos;
		}
		public void ResetearGrillas()
		{
			descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
			FeaEntidades.InterFacturas.resumenDescuentos descuento = new FeaEntidades.InterFacturas.resumenDescuentos();
			descuentos.Add(descuento);
			descuentosGridView.DataSource = descuentos;
			ViewState["descuentos"] = descuentos;
			DataBind();
			BindearDropDownLists();
		}
		public void CompletarDetallesWS(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
			if (lc.comprobante[0].resumen.descuentos != null)
			{
				descuentos = new System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>();
				foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteResumenDescuentos r in lc.comprobante[0].resumen.descuentos)
				{
					if (r.importe_descuento_moneda_origenSpecified)
					{
						r.importe_descuento = r.importe_descuento_moneda_origen;
					}
					FeaEntidades.InterFacturas.resumenDescuentos rd = new FeaEntidades.InterFacturas.resumenDescuentos();
					rd.alicuota_iva_descuento = r.alicuota_iva_descuento;
					rd.alicuota_iva_descuentoSpecified = r.alicuota_iva_descuentoSpecified;
					rd.descripcion_descuento = r.descripcion_descuento;
					rd.importe_descuento = r.importe_descuento;
					rd.importe_descuento_moneda_origen = r.importe_descuento_moneda_origen;
					rd.importe_descuento_moneda_origenSpecified = r.importe_descuento_moneda_origenSpecified;
					rd.importe_iva_descuento = r.importe_iva_descuento;
					rd.importe_iva_descuento_moneda_origen = r.importe_iva_descuento_moneda_origen;
					rd.importe_iva_descuento_moneda_origenSpecified = r.importe_iva_descuento_moneda_origenSpecified;
					rd.importe_iva_descuentoSpecified = r.importe_iva_descuentoSpecified;
					rd.porcentaje_descuento = r.porcentaje_descuento;
					rd.porcentaje_descuentoSpecified = r.porcentaje_descuentoSpecified;
					descuentos.Add(rd);
				}
				if (descuentos.Count.Equals(0))
				{
					descuentos.Add(new FeaEntidades.InterFacturas.resumenDescuentos());
				}
				descuentosGridView.DataSource = descuentos;
				descuentosGridView.DataBind();
				ViewState["descuentos"] = descuentos;
			}

		}
		public void BindearDropDownLists()
		{
			if (descuentosGridView.FooterRow != null)
			{
				//((DropDownList)descuentosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataValueField = "Codigo";
				//((DropDownList)descuentosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataTextField = "Descr";
				//((DropDownList)descuentosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();
				//((DropDownList)descuentosGridView.FooterRow.FindControl("ddlcodigo_de_permiso")).DataBind();
			}
		}

		public void GenerarResumen(FeaEntidades.InterFacturas.comprobante comp, string monedaComprobante, string tipoDeCambio)
		{
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos> listadedescuentos = (System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenDescuentos>)ViewState["descuentos"];
			comp.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[listadedescuentos.Count];
			for (int i = 0; i < listadedescuentos.Count; i++)
			{
				if (listadedescuentos[i].descripcion_descuento != null && !listadedescuentos[i].descripcion_descuento.Equals(string.Empty))
				{
					comp.resumen.descuentos[i] = new FeaEntidades.InterFacturas.resumenDescuentos();
					comp.resumen.descuentos[i].alicuota_iva_descuento = listadedescuentos[i].alicuota_iva_descuento;
					comp.resumen.descuentos[i].alicuota_iva_descuentoSpecified = listadedescuentos[i].alicuota_iva_descuentoSpecified;
					comp.resumen.descuentos[i].descripcion_descuento = listadedescuentos[i].descripcion_descuento;
					comp.resumen.descuentos[i].importe_iva_descuento = listadedescuentos[i].importe_iva_descuento;
					comp.resumen.descuentos[i].importe_iva_descuento_moneda_origen = listadedescuentos[i].importe_iva_descuento_moneda_origen;
					comp.resumen.descuentos[i].importe_iva_descuento_moneda_origenSpecified = listadedescuentos[i].importe_iva_descuento_moneda_origenSpecified;
					comp.resumen.descuentos[i].importe_iva_descuentoSpecified = listadedescuentos[i].importe_iva_descuentoSpecified;
					comp.resumen.descuentos[i].porcentaje_descuento = listadedescuentos[i].porcentaje_descuento;
					comp.resumen.descuentos[i].porcentaje_descuentoSpecified = listadedescuentos[i].porcentaje_descuentoSpecified;

					if (monedaComprobante.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
					{
						comp.resumen.descuentos[i].importe_descuento = listadedescuentos[i].importe_descuento;
					}
					else
					{
						comp.resumen.descuentos[i].importe_descuento = Math.Round(listadedescuentos[i].importe_descuento * Convert.ToDouble(tipoDeCambio), 2);
						comp.resumen.descuentos[i].importe_descuento_moneda_origen = listadedescuentos[i].importe_descuento;
						comp.resumen.descuentos[i].importe_descuento_moneda_origenSpecified = true;
					}
				}
			}
		}

	}
}