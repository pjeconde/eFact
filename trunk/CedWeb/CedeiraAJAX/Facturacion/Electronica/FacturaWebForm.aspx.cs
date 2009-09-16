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
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace CedeiraAJAX.Facturacion.Electronica
{
    public partial class FacturaWebForm : System.Web.UI.Page
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument oRpt;
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (oRpt != null)
            {
                oRpt.Dispose();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["lote"] == null)
                {
                    Server.Transfer("~/Inicio.aspx");
                }
                else
                {
                    try
                    {
                        oRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        string reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/Factura.rpt");
                        oRpt.Load(reportPath);

                        FeaEntidades.InterFacturas.lote_comprobantes lc = (FeaEntidades.InterFacturas.lote_comprobantes)Session["lote"];
                        DataSet ds = new DataSet();

                        XmlSerializer objXS = new XmlSerializer(lc.GetType());
                        StringWriter objSW = new StringWriter();
                        objXS.Serialize(objSW, lc);
                        StringReader objSR = new StringReader(objSW.ToString());
                        ds.ReadXml(objSR);

                        oRpt.SetDataSource(ds);

                        oRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                        oRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        FacturaCrystalReportViewer.ReportSource = oRpt;
                        FacturaCrystalReportViewer.DataBind();
                        FacturaCrystalReportViewer.HasPrintButton = true;
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
        }
    }
}
