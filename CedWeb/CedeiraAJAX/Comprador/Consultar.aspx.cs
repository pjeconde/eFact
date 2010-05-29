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

namespace CedeiraAJAX.Comprador
{
    public partial class Consultar : System.Web.UI.Page
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
                        ProvinciaDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                        CondIVADropDownList.DataValueField = "Codigo";
                        CondIVADropDownList.DataTextField = "Descr";
                        CondIVADropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaInf();
                        CondIngBrutosDropDownList.DataValueField = "Codigo";
                        CondIngBrutosDropDownList.DataTextField = "Descr";
                        CondIngBrutosDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.ListaInf();
                        DestinosCuitDropDownList.DataValueField = "Codigo";
                        DestinosCuitDropDownList.DataTextField = "Descr";
                        DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.Lista(); 
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
                        ProvinciaDropDownList.SelectedValue = Comprador.Domicilio.Provincia.Id;
                        CodPostTextBox.Text = Comprador.Domicilio.CodPost;
                        NombreContactoTextBox.Text = Comprador.NombreContacto;
                        EmailContactoTextBox.Text = Comprador.EmailContacto;
                        TelefonoContactoTextBox.Text = Convert.ToString(Comprador.TelefonoContacto);
                        if (Comprador.IdTipoDoc != ((FeaEntidades.Documentos.Documento)new FeaEntidades.Documentos.CUITPais()).Codigo)
                        {
                            InhabilitarCompradorDelExtranjero();
                        }
                        else
                        {
                            HabilitarCompradorDelExtranjero();
                        } 
                        TipoDocDropDownList.SelectedValue = Convert.ToString(Comprador.IdTipoDoc);
                        if (!CompradorDelExtranjeroCheckBox.Checked)
                        {
                            NroDocTextBox.Text = Convert.ToString(Comprador.NroDoc);
                        }
                        else
                        {
                            DestinosCuitDropDownList.SelectedValue = Convert.ToString(Comprador.NroDoc);
                        }
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
                        CompradorDelExtranjeroCheckBox.Checked = Comprador.IdTipoDoc == ((FeaEntidades.Documentos.Documento)new FeaEntidades.Documentos.CUITPais()).Codigo;
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
            Server.Transfer("~/Comprador/Explorador.aspx"); ;
        }
        private void HabilitarCompradorDelExtranjero()
        {
            MsgErrorLabel.Text = String.Empty;
            TipoDocDropDownList.DataValueField = "Codigo";
            TipoDocDropDownList.DataTextField = "Descr";
            TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
            DataBind();
            ProvinciaDropDownList.SelectedValue = ((FeaEntidades.CodigosProvincia.CodigoProvincia)new FeaEntidades.CodigosProvincia.SinInformar()).Codigo.ToString();
            CompradorDelExtranjeroCheckBox.Checked = true;
            TipoDocDropDownList.SelectedValue = ((FeaEntidades.Documentos.Documento)new FeaEntidades.Documentos.CUITPais()).Codigo.ToString();
            DestinosCuitLabel.Visible = true;
            NroDocLabel.Visible = false;
            DestinosCuitDropDownList.Visible = true;
            NroDocTextBox.Visible = false;
        }
        private void InhabilitarCompradorDelExtranjero()
        {
            MsgErrorLabel.Text = String.Empty;
            TipoDocDropDownList.DataValueField = "Codigo";
            TipoDocDropDownList.DataTextField = "Descr";
            TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
            DataBind();
            ProvinciaDropDownList.SelectedValue = ((FeaEntidades.CodigosProvincia.CodigoProvincia)new FeaEntidades.CodigosProvincia.CapitalFederal()).Codigo.ToString();
            CompradorDelExtranjeroCheckBox.Checked = false;
            TipoDocDropDownList.SelectedValue = ((FeaEntidades.Documentos.Documento)new FeaEntidades.Documentos.CUIT()).Codigo.ToString();
            DestinosCuitLabel.Visible = false;
            NroDocLabel.Visible = true;
            DestinosCuitDropDownList.Visible = false;
            NroDocTextBox.Visible = true;
        }
    }
}
