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
    public partial class Vendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RazonSocialTextBox.Focus();
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
                        for (int i = 0; i < vendedor.BonoFiscal.PuntoDeVentaHabilitado.Count; i++)
                        {
                            PuntoDeVentaListBox.Items.Add(vendedor.BonoFiscal.PuntoDeVentaHabilitado[i].ToString());
                        }
                        if (vendedor.BonoFiscal.PuntoDeVentaHabilitado.Count > 0)
                        {
                            QuitarPuntoDeVentaButton.Enabled = true;
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
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                CedWebEntidades.Vendedor vendedor = DatosVendedor();
                CedWebRN.Vendedor.Validar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Guardar(vendedor, (CedEntidades.Sesion)Session["Sesion"]);
                CedWebRN.Vendedor.Copiar(vendedor, ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Vendedor);
                Server.Transfer("~/FacturaElectronica.aspx", true);
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = CedeiraUIWebForms.Excepciones.Detalle(ex);
            }
        }
        protected CedWebEntidades.Vendedor DatosVendedor()
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
            vendedor.BonoFiscal.PuntoDeVentaHabilitado.Clear();
            for (int i = 0; i < PuntoDeVentaListBox.Items.Count; i++)
            {
                vendedor.BonoFiscal.PuntoDeVentaHabilitado.Add(Convert.ToInt32(PuntoDeVentaListBox.Items[i].Value));
            }
            return vendedor;
        }
        protected void BackupButton_Click(object sender, EventArgs e)
        {
            if (CedWebRN.Fun.NoEstaLogueadoUnUsuarioPremium((CedWebEntidades.Sesion)Session["Sesion"]))
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Esta funcionalidad es exclusiva del SERVICIO PREMIUM.  Contáctese con Cedeira Software Factory para acceder al servicio.');</script>");
            }
            else
            {
                CedWebEntidades.Vendedor vendedor = DatosVendedor();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(vendedor.GetType());
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                x.Serialize(writerdememoria, vendedor);
                m.Seek(0, System.IO.SeekOrigin.Begin);
                string nombreArchivo = "eFact-Vendedor-" + ((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta.Id.Replace(".", String.Empty).ToUpper() + ".xml";
                System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + nombreArchivo), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();
                Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + nombreArchivo, false);
            }
        }
        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/FacturaElectronica.aspx");
        }
        protected void AgregarPuntoDeVentaButton_Click(object sender, EventArgs e)
        {
            int nuevoPuntoDeVenta = 0;
            if (Int32.TryParse(NuevoPuntoDeVentaTextBox.Text, out nuevoPuntoDeVenta))
            {
                if (nuevoPuntoDeVenta > 0)
                {
                    if (!PuntoDeVentaListBox.Items.Contains(new ListItem(nuevoPuntoDeVenta.ToString())))
                    {
                        PuntoDeVentaListBox.Items.Add(nuevoPuntoDeVenta.ToString());
                        QuitarPuntoDeVentaButton.Enabled = true;
                    }
                }
            }
            NuevoPuntoDeVentaTextBox.Text = String.Empty;
        }
        protected void QuitarPuntoDeVentaButton_Click(object sender, EventArgs e)
        {
            if (PuntoDeVentaListBox.SelectedIndex >= 0)
            {
                PuntoDeVentaListBox.Items.Remove(PuntoDeVentaListBox.Items[PuntoDeVentaListBox.SelectedIndex]);
                if (PuntoDeVentaListBox.Items.Count == 0)
                {
                    QuitarPuntoDeVentaButton.Enabled = false;
                }
            }
        }
    }
}
