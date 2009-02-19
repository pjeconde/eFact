using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedWeb.Autenticado
{
	public partial class Bienvenida : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
			RangoTasasGridEX.BuiltInTexts[Janus.Web.GridEX.GridEXBuiltInText.EmptyGridInfo] = "Tasas vigentes no disponibles";
            if (!this.IsPostBack)
            {
                #region Completar rango Tasas
                try
                {
                    //if (Cache["RangoTasasVigentes"] == null)
                    //{
                    //    List<CedWebEntidades.TramosRangoTasas> listaTramos = CedWebrn.TramosRangoTasas.Leer((CedEntidades.Sesion)Session["Sesion"]);
                    //    if (listaTramos != null && listaTramos.Count > 0)
                    //    {
                    //        Cache.Add("RangoTasasVigentes", listaTramos, null, DateTime.UtcNow.AddMinutes(30), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                    //    }
                    //    RangoTasasGridEX.DataSource = listaTramos;
                    //}
                    //else
                    //{
                    //    RangoTasasGridEX.DataSource = (List<CedWebEntidades.TramosRangoTasas>)Cache["RangoTasasVigentes"];
                    //}
                    //RangoTasasGridEX.DataBind();
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Autenticado/Excepcion.aspx");
                }
                #endregion
                #region Completar Tasa badlar
                try
                {
                    //CedWebEntidades.TasaBadlar badlar = new CedWebEntidades.TasaBadlar();
                    //if (Cache["TasasBadlar"] == null)
                    //{
                    //    try
                    //    {
                    //        CedWebrn.TasasBadlar.Leer(badlar, (CedEntidades.Sesion)Session["Sesion"]);
                    //        Cache.Add("TasasBadlar", badlar, null, DateTime.UtcNow.AddMinutes(30), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                    //    }
                    //    catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.TasaBadlarSinCotizacion)
                    //    {
                    //        TasaBadlarLabel.Text = "?";
                    //    }
                    //}
                    //else
                    //{
                    //    badlar = (CedWebEntidades.TasaBadlar)Cache["TasasBadlar"];
                    //}
                    //TasaBadlarLabel.Text = badlar.Tasa.ToString("##0.0000");
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Autenticado/Excepcion.aspx");
                }
                #endregion
            }
        }
	}
}