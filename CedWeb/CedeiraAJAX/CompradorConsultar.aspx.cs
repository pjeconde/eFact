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

namespace CedeiraAJAX
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
                        CedWebEntidades.Comprador Comprador = new CedWebEntidades.Comprador();
                        Comprador.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                        Comprador.RazonSocial = Convert.ToString(Session["CompradorSeleccionado"]);
                        CedWebRN.Comprador.Leer(Comprador, (CedEntidades.Sesion)Session["Sesion"]);
                        RazonSocialTextBox.Text = Comprador.RazonSocial;
                        CalleTextBox.Text = Comprador.Domicilio.Calle;
                        NroTextBox.Text = Comprador.Domicilio.Nro;
                        PisoTextBox.Text = Comprador.Domicilio.Piso;
                        DeptoTextBox.Text = Comprador.Domicilio.Depto;
                        SectorTextBox.Text = Comprador.Domicilio.Sector;
                        TorreTextBox.Text = Comprador.Domicilio.Torre;
                        ManzanaTextBox.Text = Comprador.Domicilio.Manzana;
                        LocalidadTextBox.Text = Comprador.Domicilio.Localidad;
                        ProvinciaDropDownList.SelectedValue = Comprador.Domicilio.IdProvincia;
                        CodPostTextBox.Text = Comprador.Domicilio.CodPost;
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
            Server.Transfer("~/CompradorExplorador.aspx"); ;
        }
    }
}
