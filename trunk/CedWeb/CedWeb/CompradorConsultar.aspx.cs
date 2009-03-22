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
    public partial class CompradorConsultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (CedWebRN.Fun.NoHayNadieLogueado((CedWebEntidades.Sesion)Session["Sesion"]))
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
                    else
                    {
                        ProvinciaDropDownList.DataValueField = "Codigo";
                        ProvinciaDropDownList.DataTextField = "Descr";
                        ProvinciaDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.ListaInf();
                        CondIVADropDownList.DataValueField = "Codigo";
                        CondIVADropDownList.DataTextField = "Descr";
                        CondIVADropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaInf();
                        TipoDocDropDownList.DataValueField = "Codigo";
                        TipoDocDropDownList.DataTextField = "Descr";
                        TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                        CondIngBrutosDropDownList.DataValueField = "Codigo";
                        CondIngBrutosDropDownList.DataTextField = "Descr";
                        CondIngBrutosDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.ListaInf();
                        DataBind();
                        string a = HttpContext.Current.Request.Url.Query.ToString();
                        if (a == String.Empty)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfFormatoMsgErroneo();
                        }
                        else
                        {
                            if (a.Substring(0, 4) == "?Id=")
                            {
                                a = a.Substring(4);
                            }
                            string razonSocial = a;
                            CedWebEntidades.Comprador Comprador = new CedWebEntidades.Comprador();
                            Comprador.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                            Comprador.RazonSocial = razonSocial;
                            CedWebRN.Comprador.Leer(Comprador, (CedEntidades.Sesion)Session["Sesion"]);
                            RazonSocialTextBox.Text = Comprador.RazonSocial;
                            CalleTextBox.Text = Comprador.Calle;
                            NroTextBox.Text = Comprador.Nro;
                            PisoTextBox.Text = Comprador.Piso;
                            DeptoTextBox.Text = Comprador.Depto;
                            SectorTextBox.Text = Comprador.Sector;
                            TorreTextBox.Text = Comprador.Torre;
                            ManzanaTextBox.Text = Comprador.Manzana;
                            LocalidadTextBox.Text = Comprador.Localidad;
                            ProvinciaDropDownList.SelectedValue = Comprador.IdProvincia;
                            CodPostTextBox.Text = Comprador.CodPost;
                            NombreContactoTextBox.Text = Comprador.NombreContacto;
                            EmailContactoTextBox.Text = Comprador.EmailContacto;
                            TelefonoContactoTextBox.Text = Convert.ToString(Comprador.TelefonoContacto);
                            TipoDocDropDownList.SelectedValue = Convert.ToString(Comprador.IdTipoDoc);
                            NroDocTextBox.Text = Convert.ToString(Comprador.NroDoc);
                            CondIVADropDownList.SelectedValue = Convert.ToString(Comprador.IdCondIVA);
                            NroIngBrutosTextBox.Text = Comprador.NroIngBrutos;
                            CondIngBrutosDropDownList.SelectedValue = Convert.ToString(Comprador.IdCondIngBrutos);
                            string auxGLN = Convert.ToString(Comprador.GLN);
                            if (!auxGLN.Equals("0"))
                            {
                                GLNTextBox.Text = auxGLN;
                            }
                            CodigoInternoTextBox.Text = Comprador.CodigoInterno;
                            FechaInicioActividadesDatePickerWebUserControl.CalendarDate = Comprador.FechaInicioActividades;
                            CancelarButton.Focus();
                        }
                    }
                }
                catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
                {
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
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}