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
using System.Data;

namespace CedeiraAJAX.Facturacion.Electronica
{
    public partial class FacturaWebForm : System.Web.UI.Page
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument facturaRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument imagenRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument codigobarrasRpt;
        DataSet dsImages = new DataSet();
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (facturaRpt != null)
            {
                facturaRpt.Dispose();
            }
            if (imagenRpt != null)
            {
                imagenRpt.Dispose();
            }
            if (codigobarrasRpt != null)
            {
                codigobarrasRpt.Dispose();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["lote"] == null)
            {
                Server.Transfer("~/Inicio.aspx");
            }
            else
            {
                try
                {
                    facturaRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    string reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/Factura.rpt");
                    facturaRpt.Load(reportPath);

                    FeaEntidades.InterFacturas.lote_comprobantes lc = (FeaEntidades.InterFacturas.lote_comprobantes)Session["lote"];
                    DataSet ds = new DataSet();

                    XmlSerializer objXS = new XmlSerializer(lc.GetType());
                    StringWriter objSW = new StringWriter();
                    objXS.Serialize(objSW, lc);
                    StringReader objSR = new StringReader(objSW.ToString());
                    ds.ReadXml(objSR);

                    facturaRpt.SetDataSource(ds);
                    facturaRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    facturaRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    IncrustarLogo();

                    GenerarCodigoBarras(lc.comprobante[0].cabecera.informacion_comprobante.cae);

                    FacturaCrystalReportViewer.ReportSource = facturaRpt;
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

        private void GenerarCodigoBarras(string code)
        {
            Reportes.Code39 c39 = new Reportes.Code39();
            MemoryStream ms = new MemoryStream();
            c39.FontFamilyName = "Free 3 of 9";
            c39.FontFileName = Server.MapPath("Reportes/FREE3OF9.TTF");
            c39.FontSize = 100;
            c39.ShowCodeString = true;
            c39.Title = code;
            System.Drawing.Bitmap objBitmap = c39.GenerateBarcode(code);
            objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            codigobarrasRpt = facturaRpt.OpenSubreport("CodigoBarra.rpt");

            CrearTabla();

            DataRow dr = this.dsImages.Tables["images"].NewRow();
            dr["path"] = "ninguno";
            dr["image"] = ms.ToArray();
            this.dsImages.Tables["images"].Rows.Add(dr);
            
            codigobarrasRpt.SetDataSource(this.dsImages);

            
        }

        private void IncrustarLogo()
        {
            CrearTabla();
            FileStream FilStr = new FileStream(Server.MapPath("~/Imagenes/Logos.bmp"), FileMode.Open);
            BinaryReader BinRed = new BinaryReader(FilStr);
            DataRow dr = this.dsImages.Tables["images"].NewRow();
            dr["path"] = Server.MapPath("~/Imagenes/Logos.bmp");
            dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
            this.dsImages.Tables["images"].Rows.Add(dr);
            FilStr.Close();
            BinRed.Close();

            imagenRpt = facturaRpt.OpenSubreport("Imagen.rpt");
            imagenRpt.SetDataSource(this.dsImages);
        }

        private void CrearTabla()
        {
            this.dsImages = new DataSet();
            DataTable imageTable = new DataTable("Images");
            imageTable.Columns.Add(new DataColumn("path", typeof(string)));
            imageTable.Columns.Add(new DataColumn("image", typeof(System.Byte[])));
            this.dsImages.Tables.Add(imageTable);
        }
    }
}
