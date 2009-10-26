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

namespace CedeiraAJAX.Facturacion.Electronica.Reportes
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
                    AsignarCamposOpcionales(lc);
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

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(lc.cabecera_lote.cuit_vendedor);
                    sb.Append("-");
                    sb.Append(lc.cabecera_lote.punto_de_venta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                    sb.Append("-");
                    sb.Append(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));

                    CrystalDecisions.Shared.ExportOptions exportOpts = new CrystalDecisions.Shared.ExportOptions();
                    CrystalDecisions.Shared.PdfRtfWordFormatOptions pdfOpts = CrystalDecisions.Shared.ExportOptions.CreatePdfRtfWordFormatOptions();
                    exportOpts.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                    exportOpts.ExportFormatOptions = pdfOpts;
                    facturaRpt.ExportToHttpResponse(exportOpts, Response, true, sb.ToString());


                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepciones/Excepcion.aspx");
                }
            }
        }

        private void AsignarCamposOpcionales(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            lc.comprobante[0].resumen.cant_alicuotas_ivaSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified=true;
            lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified = true;
            for (int i = 0; i < lc.comprobante[0].detalle.linea.Length;i++)
            {
                if (lc.comprobante[0].detalle.linea[i]!=null)
                {
                    lc.comprobante[0].detalle.linea[i].precio_unitarioSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importe_ivaSpecified = true;
                }
                else
                {
                    break;
                }
            }
        }

        private void GenerarCodigoBarras(string code)
        {
            if (code != null)
            {
                Reportes.Code39 c39 = new Reportes.Code39();
                MemoryStream ms = new MemoryStream();
                c39.FontFamilyName = "Free 3 of 9";
                c39.FontFileName = Server.MapPath("FREE3OF9.TTF");
                c39.FontSize = 30;
                c39.ShowCodeString = true;
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
        }

        private void IncrustarLogo()
        {
            try
            {
                FileStream FilStr = new FileStream(Server.MapPath("~/Imagenes/Logos/" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor.CUIT + ".bmp"), FileMode.Open);
                CrearTabla();
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
            catch (Exception ex)
            {

            }
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
