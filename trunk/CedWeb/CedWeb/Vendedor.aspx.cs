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
    public partial class Vendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id == null)
                    {
                        CedeiraUIWebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/NoHabilitadoParaUsuariosNoRegistrados.aspx");
                    }
                    else
                    {
                        ProvinciaDropDownList.DataValueField = "Codigo";
                        ProvinciaDropDownList.DataTextField = "Descr";
                        ProvinciaDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.ListaInf();
                        CondIVADropDownList.DataValueField = "Codigo";
                        CondIVADropDownList.DataTextField = "Descr";
                        CondIVADropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaInf();
                        CondIngBrutosDropDownList.DataValueField = "Codigo";
                        CondIngBrutosDropDownList.DataTextField = "Descr";
                        CondIngBrutosDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.ListaInf();
                        DataBind();
                        //Leo datos actuales
                        CedWebEntidades.Vendedor vendedor = new CedWebEntidades.Vendedor();
                        vendedor.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                        CedWebRN.Vendedor.Leer(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                        RazonSocialTextBox.Text = vendedor.RazonSocial;
                        CalleTextBox.Text = vendedor.Calle;
                        NroTextBox.Text = vendedor.Nro;
                        PisoTextBox.Text = vendedor.Piso;
                        DeptoTextBox.Text = vendedor.Depto;
                        SectorTextBox.Text = vendedor.Sector;
                        TorreTextBox.Text = vendedor.Torre;
                        ManzanaTextBox.Text = vendedor.Manzana;
                        LocalidadTextBox.Text = vendedor.Localidad;
                        ProvinciaDropDownList.SelectedValue = vendedor.IdProvincia;
                        CodPostTextBox.Text = vendedor.CodPost;
                        NombreContactoTextBox.Text = vendedor.NombreContacto;
                        EmailContactoTextBox.Text = vendedor.EmailContacto;
                        TelefonoContactoTextBox.Text = Convert.ToString(vendedor.TelefonoContacto);
                        CUITTextBox.Text = Convert.ToString(vendedor.CUIT);
                        CondIVADropDownList.SelectedValue = Convert.ToString(vendedor.IdCondIVA);
                        NroIngBrutosTextBox.Text = vendedor.NroIngBrutos;
                        CondIngBrutosDropDownList.SelectedValue = Convert.ToString(vendedor.IdCondIngBrutos);
						string auxGLN = Convert.ToString(vendedor.GLN);
						if (!auxGLN.Equals("0"))
						{
							GLNTextBox.Text = auxGLN;
						}
                        CodigoInternoTextBox.Text = vendedor.CodigoInterno;
                        FechaInicioActividadesDatePickerWebUserControl.CalendarDate = vendedor.FechaInicioActividades;
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
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebEntidades.Vendedor vendedor = new CedWebEntidades.Vendedor();
                vendedor.IdCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id;
                vendedor.NombreCuenta = ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Nombre;
                vendedor.RazonSocial = RazonSocialTextBox.Text;
                vendedor.Calle = CalleTextBox.Text;
                vendedor.Nro = NroTextBox.Text;
                vendedor.Piso = PisoTextBox.Text;
                vendedor.Depto = DeptoTextBox.Text;
                vendedor.Sector = SectorTextBox.Text;
                vendedor.Torre = TorreTextBox.Text;
                vendedor.Manzana = ManzanaTextBox.Text;
                vendedor.Localidad = LocalidadTextBox.Text;
                vendedor.IdProvincia = ProvinciaDropDownList.SelectedValue;
                vendedor.DescrProvincia = ProvinciaDropDownList.SelectedItem.Text;
                vendedor.CodPost = CodPostTextBox.Text;
                vendedor.NombreContacto = NombreContactoTextBox.Text;
                vendedor.EmailContacto = EmailContactoTextBox.Text;
                vendedor.TelefonoContacto = TelefonoContactoTextBox.Text;
                vendedor.CUIT = Convert.ToInt64(CUITTextBox.Text);
                vendedor.IdCondIVA = Convert.ToInt32(CondIVADropDownList.SelectedValue);
                vendedor.DescrCondIVA = CondIVADropDownList.SelectedItem.Text;
                vendedor.NroIngBrutos = NroIngBrutosTextBox.Text;
                vendedor.IdCondIngBrutos = Convert.ToInt32(CondIngBrutosDropDownList.SelectedValue);
                vendedor.DescrCondIngBrutos = CondIngBrutosDropDownList.SelectedItem.Text;
                if (GLNTextBox.Text == String.Empty)
                {
                    vendedor.GLN = 0;
                }
                else
                {
                    vendedor.GLN = Convert.ToInt64(GLNTextBox.Text);
                }
                vendedor.CodigoInterno = CodigoInternoTextBox.Text;
                vendedor.FechaInicioActividades = FechaInicioActividadesDatePickerWebUserControl.CalendarDate;
                CedWebRN.Vendedor.Validar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Guardar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Copiar(vendedor, ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor);
                Response.Redirect("~/FacturaElectronica.aspx", true);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
    }
}