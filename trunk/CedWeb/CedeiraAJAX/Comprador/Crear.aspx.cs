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

namespace CedeiraAJAX.Comprador
{
    public partial class Crear : System.Web.UI.Page
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
                        ProvinciaDropDownList.SelectedValue = ((FeaEntidades.CodigosProvincia.CodigoProvincia)new FeaEntidades.CodigosProvincia.CapitalFederal()).Codigo.ToString();
                        CondIVADropDownList.DataValueField = "Codigo";
                        CondIVADropDownList.DataTextField = "Descr";
                        CondIVADropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaInf();
                        TipoDocDropDownList.DataValueField = "Codigo";
                        TipoDocDropDownList.DataTextField = "Descr";
                        TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
                        CondIngBrutosDropDownList.DataValueField = "Codigo";
                        CondIngBrutosDropDownList.DataTextField = "Descr";
                        CondIngBrutosDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                        DestinosCuitDropDownList.DataValueField = "Codigo";
                        DestinosCuitDropDownList.DataTextField = "Descr";
                        DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                        DataBind();
                        TipoDocDropDownList.SelectedValue = ((FeaEntidades.Documentos.Documento) new FeaEntidades.Documentos.CUIT()).Codigo.ToString();
                        RazonSocialTextBox.Focus();
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
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
                comprador.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                comprador.NombreCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                comprador.RazonSocial = RazonSocialTextBox.Text;
                comprador.Domicilio.Calle = CalleTextBox.Text;
                comprador.Domicilio.Nro = NroTextBox.Text;
                comprador.Domicilio.Piso = PisoTextBox.Text;
                comprador.Domicilio.Depto = DeptoTextBox.Text;
                comprador.Domicilio.Sector = SectorTextBox.Text;
                comprador.Domicilio.Torre = TorreTextBox.Text;
                comprador.Domicilio.Manzana = ManzanaTextBox.Text;
                comprador.Domicilio.Localidad = LocalidadTextBox.Text;
                comprador.Domicilio.Provincia.Id = ProvinciaDropDownList.SelectedValue;
                comprador.Domicilio.Provincia.Descr = ProvinciaDropDownList.SelectedItem.Text;
                comprador.Domicilio.CodPost = CodPostTextBox.Text;
                comprador.NombreContacto = NombreContactoTextBox.Text;
                comprador.EmailContacto = EmailContactoTextBox.Text;
                comprador.TelefonoContacto = TelefonoContactoTextBox.Text;
                comprador.IdTipoDoc = Convert.ToInt32(TipoDocDropDownList.SelectedValue);
                comprador.DescrTipoDoc = TipoDocDropDownList.SelectedItem.Text;
                if (CompradorDelExtranjeroCheckBox.Checked)
                {
                    try
                    {
                        comprador.NroDoc = Convert.ToInt64(DestinosCuitDropDownList.SelectedItem.Value);
                    }
                    catch
                    {
                        comprador.NroDoc = 0;
                    }
                }
                else
                {
                    try
                    {
                        comprador.NroDoc = Convert.ToInt64(NroDocTextBox.Text);
                    }
                    catch
                    {
                        comprador.NroDoc = 0;
                    }
                }
                comprador.IdCondIVA = Convert.ToInt32(CondIVADropDownList.SelectedValue);
                comprador.DescrCondIVA = CondIVADropDownList.SelectedItem.Text;
                comprador.NroIngBrutos = NroIngBrutosTextBox.Text;
                comprador.IdCondIngBrutos = Convert.ToInt32(CondIngBrutosDropDownList.SelectedValue);
                comprador.DescrCondIngBrutos = CondIngBrutosDropDownList.SelectedItem.Text;
                if (GLNTextBox.Text == String.Empty)
                {
                    comprador.GLN = 0;
                }
                else
                {
                    comprador.GLN = Convert.ToInt64(GLNTextBox.Text);
                }
                comprador.CodigoInterno = CodigoInternoTextBox.Text;
                comprador.FechaInicioActividades = FechaInicioActividadesDatePickerWebUserControl.CalendarDate;
                comprador.EmailAvisoVisualizacion = EmailAvisoVisualizacionTextBox.Text;
                comprador.PasswordAvisoVisualizacion = PasswordAvisoVisualizacionTextBox.Text;
                CedWebRN.Comprador.Validar(comprador, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Comprador.Crear(comprador, (CedEntidades.Sesion)Session["Sesion"]);
                Response.Redirect("~/Comprador/Explorador.aspx");
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Comprador/Explorador.aspx"); ;
        }
        protected void CompradorDelExtranjeroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            if (CompradorDelExtranjeroCheckBox.Checked)
            {
                HabilitarCompradorDelExtranjero();
            }
            else
            {
                InhabilitarCompradorDelExtranjero();
            }
        }
        protected void NroDocTextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            List<FeaEntidades.DestinosCuit.DestinoCuit> lista = FeaEntidades.DestinosCuit.DestinoCuit.Lista();
            for (int i=0; i<lista.Count; i++)
            {
                if (NroDocTextBox.Text==((FeaEntidades.DestinosCuit.DestinoCuit)lista[i]).Codigo)
                {
                    DestinosCuitDropDownList.SelectedValue = NroDocTextBox.Text;
                    NroDocTextBox.Text = String.Empty;
                    HabilitarCompradorDelExtranjero();
                    break;
                }
            }
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
