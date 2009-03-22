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
    public partial class CompradorCrear : System.Web.UI.Page
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
                CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
                comprador.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                comprador.NombreCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                comprador.RazonSocial = RazonSocialTextBox.Text;
                comprador.Calle = CalleTextBox.Text;
                comprador.Nro = NroTextBox.Text;
                comprador.Piso = PisoTextBox.Text;
                comprador.Depto = DeptoTextBox.Text;
                comprador.Sector = SectorTextBox.Text;
                comprador.Torre = TorreTextBox.Text;
                comprador.Manzana = ManzanaTextBox.Text;
                comprador.Localidad = LocalidadTextBox.Text;
                comprador.IdProvincia = ProvinciaDropDownList.SelectedValue;
                comprador.DescrProvincia = ProvinciaDropDownList.SelectedItem.Text;
                comprador.CodPost = CodPostTextBox.Text;
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
                CedWebRN.Comprador.Crear(comprador, (CedEntidades.Sesion)Session["Sesion"]);
                Response.Redirect("~/CompradorExplorador.aspx", true);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["ref"]);
        }
    }
}