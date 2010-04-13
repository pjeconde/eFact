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
    public partial class CompradorEliminar : System.Web.UI.Page
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
                        ProvinciaDropDownList.SelectedValue = Comprador.Domicilio.Provincia.Id;
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
                        AceptarButton.Focus();
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
                comprador.NroDoc = Convert.ToInt64(NroDocTextBox.Text);
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
                CedWebRN.Comprador.Validar(comprador, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Comprador.Eliminar(comprador, (CedEntidades.Sesion)Session["Sesion"]);
                Server.Transfer("~/CompradorExplorador.aspx", true);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/CompradorExplorador.aspx"); ;
        }
    }
}
