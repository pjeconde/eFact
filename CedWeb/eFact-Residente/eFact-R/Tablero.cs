using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace eFact_R
{
    public partial class Tablero : Form
    {
        public List<eFact_Entidades.Archivo> dtBandejaEntrada = new List<eFact_Entidades.Archivo>();
        public List<eFact_Entidades.Lote> dtBandejaSalida = new List<eFact_Entidades.Lote>();
        eFact_Entidades.Lote.TipoConsulta TipoConsulta;
        eFact_Entidades.Archivo.TipoConsultaArchivos TipoConsultaArchivos;
        eFact_Entidades.Archivo.OtrosFiltros ArchivosOtrosFiltros;
        public bool ServicioOK;

        public Tablero()
        {
            InitializeComponent();
            TipoConsulta = eFact_Entidades.Lote.TipoConsulta.FechaAlta;
            TipoConsultaArchivos = eFact_Entidades.Archivo.TipoConsultaArchivos.FechaProceso;
            ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.SinAplicar;

            StatusBar.Panels["UsuarioSBP"].Text = "Usuario: " + Aplicacion.Sesion.Usuario.Nombre;
            StatusBar.Panels["UsuarioSBP"].ToolTipText = "Información del usuario\r\nNombre: " + Aplicacion.Sesion.Usuario.Nombre + "\r\nDominio: " + Aplicacion.Sesion.Dominio;

            //<add key="Certificado" value="012425509e59" />
            List<eFact_Entidades.Vendedor> vendedores = new List<eFact_Entidades.Vendedor>();
            eFact_RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
            if (vendedores.Count > 0)
            {
                StatusBar.Panels["CertificadosSBP"].Text = "Certificados: OK";
                StatusBar.Panels["CertificadosSBP"].ToolTipText = "";
                bool AllCertifOK = true;
                foreach (eFact_Entidades.Vendedor v in vendedores)
                {
                    string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
                    X509Store store;
                    if (storeLocation == "CurrentUser")
                    {
                        store = new X509Store(StoreLocation.CurrentUser);
                    }
                    else
                    {
                        store = new X509Store(StoreLocation.LocalMachine);
                    }
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, v.NumeroSerieCertificado, true);
                    if (col.Count == 0)
                    {
                        StatusBar.Panels["CertificadosSBP"].ToolTipText += "Información del certificado número: " + v.NumeroSerieCertificado + "\r\nProblemas para validar el certificado." + "\r\n\r\n";
                        AllCertifOK = false;
                    }
                    else
                    {
                        StatusBar.Panels["CertificadosSBP"].ToolTipText += "Información del certificado número: " + v.NumeroSerieCertificado + "\r\nEntidad emisora: " + col[0].IssuerName.Name + "\r\nSujeto: " + col[0].Subject + "\r\n\r\n";
                    }
                }
                if (!AllCertifOK)
                {
                    StatusBar.Panels["CertificadosSBP"].Text = "Certificados: ERROR ";
                }
            }
            StatusBar.Panels["OrigenDatosSBP"].ToolTipText = "Directorio de Datos: " + Aplicacion.Aplic.ArchPath + "\r\n" + "Hitoricos: " + Aplicacion.Aplic.ArchPathHis + "\r\n" + "Interfaz manual: " + Aplicacion.Aplic.ArchPathItf + "\r\n" + "Interfaz aut.: " + Aplicacion.Aplic.ArchPathItfAut + "\r\n" + "PDFs: " + Aplicacion.Aplic.ArchPathPDF;
            StatusBar.Panels["CXOSBP"].Text = "CXO: " + Aplicacion.Sesion.CXO;
            StatusBar.Panels["CXOSBP"].ToolTipText = "Control por oposición: " + Aplicacion.Sesion.CXO;
            eFact_RN.Vendedor.Consultar(Aplicacion.Vendedores, Aplicacion.Sesion);
            VerificarServicio();
        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            OtrosFiltrosBandejaSPanel.Enabled = false;
            OtrosFiltrosBandejaEPanel.Enabled = false;
            ArchivosHistoricosPanel.Enabled = false;

            string CrearDirectorios = @System.Configuration.ConfigurationManager.AppSettings["CrearDirectorios"];
            if (CrearDirectorios == "SI")
            {
                DirectoryInfo di;
                if (!Directory.Exists(Aplicacion.Aplic.ArchPath))
                {
                    di = Directory.CreateDirectory(Aplicacion.Aplic.ArchPath);
                    MessageBox.Show("Se ha creado el repositorio para el procesamiento de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio deberán ser copiados todos los archivos a procesar.");
                }
                if (!Directory.Exists(Aplicacion.Aplic.ArchPathHis))
                {
                    di = Directory.CreateDirectory(Aplicacion.Aplic.ArchPathHis);
                    MessageBox.Show("Se ha creado el repositorio histórico de archivos procesados en el directorio: \r\n" + di.FullName + "\r\n\r\nA este repositorio se moverán automáticamente todos los archivos, los procesados satisfactoriamente y también los que no pudieran ser procesados por cualquier problema.");
                }
                if (!Directory.Exists(Aplicacion.Aplic.ArchPathItf))
                {
                    di = Directory.CreateDirectory(Aplicacion.Aplic.ArchPathItf);
                    MessageBox.Show("Se ha creado el repositorio de salida de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio se guardarán a pedido del usuario, los archivos de interfaz de salida que genere el usuario sobre lotes ya procesados.");
                }
                if (!Directory.Exists(Aplicacion.Aplic.ArchPathItfAut))
                {
                    di = Directory.CreateDirectory(Aplicacion.Aplic.ArchPathItfAut);
                    MessageBox.Show("Se ha creado el repositorio de salida automática de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio se guardarán automáticamente, los archivos de interfaz de salida con las respuestas obtenidas desde la AFIP sobre los lotes de comprobantes procesados satisfactoriamente.");
                }
                if (!Directory.Exists(Aplicacion.Aplic.ArchPathPDF))
                {
                    di = Directory.CreateDirectory(Aplicacion.Aplic.ArchPathPDF);
                    MessageBox.Show("Se ha creado el repositorio para exportar comprobantes en formato PDF en el directorio: \r\n" + di.FullName + "");
                }
            }
            ActualizarBandejaE();
            BandejaEDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
            BandejaEDataGridView.DataSource = dtBandejaEntrada;
            BandejaEDataGridView.Refresh();
            ActualizarBandejaS();
            BandejaSDataGridView.DataSource = new List<eFact_Entidades.Lote>();
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            BandejaSDataGridView.Refresh();
        }

        private void VerificarServicio()
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ServicioOK = true;
                System.Threading.Thread.Sleep(100);
                //foreach (System.ServiceProcess.ServiceController service in System.ServiceProcess.ServiceController.GetServices("Pol-PC"))
                //{
                //    if (service.ServiceName == "Servicio-eFact")
                //    {
                //        Console.WriteLine(service.DisplayName);
                //    }
                //}
                string machineName = @System.Configuration.ConfigurationManager.AppSettings["MachineName"];
                string serviceName = @System.Configuration.ConfigurationManager.AppSettings["ServiceName"];
                this.serviceController1.MachineName = machineName;
                this.serviceController1.ServiceName = serviceName;
                this.serviceController1.Refresh();
                string status = this.serviceController1.Status.ToString();
                if (status.ToUpper() != "RUNNING")
                {
                    ServicioOK = false;
                }
                StatusBar.Panels["ModalidadSBP"].Text = "Modalidad: " + Aplicacion.Modalidad + "  Servicio: " + status;
                StatusBar.Panels["ModalidadSBP"].ToolTipText = "Modalidad = " + Aplicacion.Modalidad + "\r\nServicio: " + status + "\r\nNombre de la PC: " + machineName + "\r\nNombre del servicio: " + serviceName + "\r\n\r\n( Hacer clic para actualizar el estado )";
                if (Aplicacion.Modalidad != "Automatica" || ServicioOK == false)
                {
                    DescartarBandejaEButton.Enabled = true;
                    EnviarABandejaSButton.Enabled = true;
                }
                else
                {
                    DescartarBandejaEButton.Enabled = false;
                    EnviarABandejaSButton.Enabled = false;                    
                }
            }
            catch (Exception ex)
            {
                ServicioOK = false;
                DescartarBandejaEButton.Enabled = true;
                EnviarABandejaSButton.Enabled = true;
                StatusBar.Panels["ModalidadSBP"].Text = "Modalidad = " + Aplicacion.Modalidad + "  Servicio: (!)";
                if (Aplicacion.Modalidad != "Automatica")
                {
                    StatusBar.Panels["ModalidadSBP"].ToolTipText = "(!) El servicio no está disponible, por lo tanto se habilitará la opción de procesamiento de archivos manual.\r\n\r\n" + "Mensaje: " + ex.Message + "\r\n\r\n( Hacer clic para actualizar el estado )";
                }
                else
                {
                    StatusBar.Panels["ModalidadSBP"].ToolTipText = "(!) El servicio no está disponible.\r\n\r\n" + "Mensaje: " + ex.Message + "\r\n\r\n( Hacer clic para actualizar el estado )";
                }
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ActualizarBandejaEButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ActualizarBandejaEButton.Enabled = false;
                LimpiarBandejaEntrada();
                if (ArchivosHistoricosRadioButton.Checked)
                {
                    List<eFact_Entidades.Archivo> archivos = new List<eFact_Entidades.Archivo>();
                    if (TipoConsultaArchivos == eFact_Entidades.Archivo.TipoConsultaArchivos.FechaCreacion)
                    {
                        eFact_RN.Archivo.Consultar(out archivos, TipoConsultaArchivos, ArchivosOtrosFiltros, FechaAltaDsdBandejaEDTP.Value, FechaAltaHstBandejaEDTP.Value, Aplicacion.Sesion);
                    }
                    else
                    {
                        eFact_RN.Archivo.Consultar(out archivos, TipoConsultaArchivos, ArchivosOtrosFiltros, FechaProcesoDsdBandejaEDTP.Value, FechaProcesoHstBandejaEDTP.Value, Aplicacion.Sesion);
                    }
                    dtBandejaEntrada = archivos;
                }
                else
                {
                    ActualizarBandejaE();
                    ActualizarBandejaS();
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                BandejaEDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
                BandejaEDataGridView.DataSource = dtBandejaEntrada;
                BandejaEDataGridView.Refresh();
                ActualizarBandejaEButton.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ActualizarBandejaE()
        {
            if (@System.Configuration.ConfigurationManager.AppSettings["ClearMemory"] == "SI")
            {
                Memory.ClearMemory();
            }
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            VerificarServicio();
            switch (Aplicacion.Aplic.CodigoAplic.ToString())
            {
                case "eFactInterface":
                {
                    BandejaEDataGridView.AutoGenerateColumns = false;
                    string[] files = Directory.GetFiles(Aplicacion.Aplic.ArchPath, "*.*");
                    BandejaEDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
                    BandejaEDataGridView.DataSource = dtBandejaEntrada;
                    BandejaEDataGridView.Refresh();
                    foreach (string d in files)
                    {
                        FileInfo ArchFileInfo = new FileInfo(d);
                        try
                        {
                            if (Aplicacion.VisualizarArchivos == "SI")
                            {
                                Boolean incorporarALista = true;
                                //Si esta activado el filtro de archivos con "SI", los archivos deben respetar los primeros 16 digitos con el formato: CUIT + "-" + Punto de Venta + "-yyyyMMddhhmmss.TXT" 
                                //ej.: 30221234568-0004-20100228103500.TXT
                                if (Aplicacion.OtrosFiltrosFiltrarBE == "SI")
                                {
                                    if (ArchFileInfo.Name.Length >= 11 && Aplicacion.OtrosFiltrosCuit != "")
                                    {
                                        string cuit = ArchFileInfo.Name.Substring(0, 11);
                                        if (cuit != Aplicacion.OtrosFiltrosCuit)
                                        {
                                            incorporarALista = false;
                                        }
                                    }
                                    if (ArchFileInfo.Name.Length >= 16 && Aplicacion.OtrosFiltrosPuntoVta != "")
                                    {
                                        string puntoventa = ArchFileInfo.Name.Substring(12, 4);
                                        string otrosFiltrosPuntoVta = "";
                                        try
                                        {
                                            otrosFiltrosPuntoVta = Convert.ToInt32(Aplicacion.OtrosFiltrosPuntoVta).ToString("0000");
                                        }
                                        catch
                                        {
                                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoNumerico("Punto de Venta (filtro bandeja de salida)");
                                        }
                                        if (puntoventa != otrosFiltrosPuntoVta)
                                        {
                                            incorporarALista = false;
                                        }
                                    }
                                }
                                if (incorporarALista)
                                {
                                    List<eFact_Entidades.Archivo> Archivos = new List<eFact_Entidades.Archivo>();
                                    eFact_RN.Tablero.ActualizarBandejaEntrada(out Archivos, dtBandejaEntrada, ArchFileInfo, Aplicacion.Sesion);
                                    dtBandejaEntrada = Archivos;
                                    BandejaEDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
                                    BandejaEDataGridView.DataSource = dtBandejaEntrada;
                                    BandejaEDataGridView.Refresh();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                        }
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void ActualizarBandejaSButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ActualizarBandejaSButton.Enabled = false;
                ActualizarBandejaS();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                BandejaSDataGridView.DataSource = new List<eFact_Entidades.Lote>();
                BandejaSDataGridView.DataSource = dtBandejaSalida;
                BandejaSDataGridView.Refresh();
                ActualizarBandejaSButton.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ActualizarBandejaS()
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            DateTime FechaDsd;
            DateTime FechaHst;
            VerificarServicio();
            if (TipoConsulta == eFact_Entidades.Lote.TipoConsulta.FechaAlta)
            {
                FechaDsd = FechaDsdLoteFecAltaDTP.Value;
                FechaHst = FechaHstLoteFecAltaDTP.Value;
            }
            else
            {
                FechaDsd = FechaDsdLoteFecEnvioDTP.Value;
                FechaHst = FechaHstLoteFecEnvioDTP.Value;
            }
            OtrosFiltrosFiltrarBS();
            string otrosFiltrosCuitvendedor = "";
            string otrosFiltrosPuntoVenta = "";
            string otrosFiltrosNumeroLote = "";
            if (OtrosFiltrosBandejaSCheckBox.Checked)
            {
                otrosFiltrosCuitvendedor = CuitVendedorTextBox.Text;
                otrosFiltrosNumeroLote = NumeroLoteTextBox.Text;
                otrosFiltrosPuntoVenta = PuntoVentaTextBox.Text;
            }
            List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
            InicializarEventosComboBox(out eventosXLote);

            ExportarItfComboBox.Items.Clear();
            ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
            ExportarItfComboBox.SelectedIndex = 0;

            BandejaSDataGridView.AutoGenerateColumns = false;
            eFact_RN.Tablero.ActualizarBandejaSalida(out dtBandejaSalida, TipoConsulta, FechaDsd, FechaHst, otrosFiltrosCuitvendedor, otrosFiltrosNumeroLote, otrosFiltrosPuntoVenta, PtesDiasAntCheckBox.Checked, eFact_R.Aplicacion.Sesion);
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            if (Aplicacion.Modalidad != "Automatica" || ServicioOK == false)
            {
                //Verificar Ptes.Respuesta AFIP.
                List<eFact_Entidades.Lote> dtBandejaSalidaFind = dtBandejaSalida.FindAll((delegate(eFact_Entidades.Lote e1) { return e1.WF.IdEstado == "PteRespAFIP"; }));
                foreach (eFact_Entidades.Lote l in dtBandejaSalidaFind)
                {
                    FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                    CedWebRN.IBK.error[] respErroresLote = new CedWebRN.IBK.error[0];
                    CedWebRN.IBK.error[] respErroresComprobantes = new CedWebRN.IBK.error[0];
                    try
                    {
                        //Consultar si exite el lote en Interfacturas
                        eFact_RN.Lote.ConsultarLoteIF(out Lc, out respErroresLote, out respErroresComprobantes, l, Aplicacion.Vendedores.Find(delegate(eFact_Entidades.Vendedor e1) { return e1.CuitVendedor == l.CuitVendedor; }).NumeroSerieCertificado);
                        //Ejecutar evento ( cambia el estado )
                        if (Lc.cabecera_lote.resultado == "A")
                        {
                            eFact_RN.Lote.ActualizarDatosCAE(l, Lc);
                            string comentario = ArmarTextoMotivo(Lc);
                            EjecutarEventoBandejaS("RegAceptAFIP", comentario, l);
                        }
                        else if (Lc.cabecera_lote.resultado == "O")
                        {
                            eFact_RN.Lote.ActualizarDatosCAE(l, Lc);
                            string comentario = ArmarTextoMotivo(Lc);
                            EjecutarEventoBandejaS("RegAceptAFIPO", comentario, l);
                        }
                        else if (Lc.cabecera_lote.resultado == "P")
                        {
                            eFact_RN.Lote.ActualizarDatosCAE(l, Lc);
                            string comentario = ArmarTextoMotivo(Lc);
                            EjecutarEventoBandejaS("RegAceptAFIPP", comentario, l);
                        }
                        else if (Lc.cabecera_lote.resultado == "R")
                        {
                            CedWebRN.IBK.lote_response lr = ArmarLoteResponse(Lc);
                            eFact_RN.Lote.ActualizarDatosError(l, lr);
                            string comentario = ArmarTextoMotivo(Lc);
                            EjecutarEventoBandejaS("RegRechAFIP", comentario, l);
                        }
                        else
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Lote.ProblemasConsulta("Estado del lote [" + Lc.cabecera_lote.resultado + "] no definido.");
                        }
                    }
                    catch (Exception ex)
                    {
                        if (respErroresLote.Length != 0)
                        {
                            if (respErroresLote[0].codigo_error != Convert.ToInt32("401"))
                            {
                                EjecutarEventoBandejaS("RegRechAFIP", ex.Message, l);
                            }
                        }
                        else
                        {
                            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                        }
                    }
                }
                eFact_RN.Tablero.ActualizarBandejaSalida(out dtBandejaSalida, TipoConsulta, FechaDsd, FechaHst, otrosFiltrosCuitvendedor, otrosFiltrosNumeroLote, otrosFiltrosPuntoVenta, PtesDiasAntCheckBox.Checked, eFact_R.Aplicacion.Sesion);
                BandejaSDataGridView.DataSource = new List<eFact_Entidades.Lote>();
                BandejaSDataGridView.DataSource = dtBandejaSalida;
            }
            BandejaSDataGridView.Refresh();
            Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void InicializarEventosComboBox(out List<CedEntidades.Evento> EventosXLote)
        {
            List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
            CedEntidades.Evento evento = new CedEntidades.Evento();
            evento.Id = "(ElegirAccion)";
            evento.Descr = "( Eligir una acción )";
            eventosXLote.Add(evento);
            EventosComboBox.DisplayMember = "Descr"; //TextoAccion + " todas las seleccionadas"
            EventosComboBox.ValueMember = "Id";
            EventosComboBox.DataSource = eventosXLote;
            EventosComboBox.SelectedIndex = 0;
            EventosXLote = eventosXLote;
        }
        private string ArmarTextoMotivo(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            string texto = "";
            if (Lc.cabecera_lote.resultado == "A" || Lc.cabecera_lote.resultado == "R" || Lc.cabecera_lote.resultado == "O" || Lc.cabecera_lote.resultado == "P")
            {
                if (Lc.cabecera_lote.motivo != null && Lc.cabecera_lote.motivo.Trim() != "00" && Lc.cabecera_lote.motivo.Trim() != "")
                {
                    FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP codigosErrorAFIPLote = FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP.Lista().Find((delegate(FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP e1) { return e1.Codigo == Lc.cabecera_lote.motivo.Trim(); }));
                    string descrCodigosErrorAFIPLote = "";
                    if (codigosErrorAFIPLote != null)
                    {
                        descrCodigosErrorAFIPLote = codigosErrorAFIPLote.Descr;
                    }
                    texto += "Problema a nivel lote: " + Lc.cabecera_lote.motivo.Trim() + " " + descrCodigosErrorAFIPLote + "\r\n\r\n";
                }
                string TextoHeaderComprobante = "";
                for (int i = 0; i < Lc.comprobante.Length; i++)
                {
                    if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
                    {
                        if (TextoHeaderComprobante == "")
                        {
                            texto += "Problema a nivel comprobante.\r\n";
                            TextoHeaderComprobante = "Problema a nivel comprobante.\r\n";
                        }
                        FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP codigosErrorAFIPComprobante = FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP.Lista().Find((delegate(FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP e1) { return e1.Codigo == Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim(); }));
                        string descrCodigosErrorAFIPComprobante = "";
                        if (codigosErrorAFIPComprobante != null)
                        {
                            descrCodigosErrorAFIPComprobante = codigosErrorAFIPComprobante.Descr;
                        }
                        int renglon = i + 1;
                        string resultado = "";
                        if (Lc.comprobante[i].cabecera.informacion_comprobante != null)
                        {
                            resultado = Lc.comprobante[i].cabecera.informacion_comprobante.resultado + " ";
                        }
                        texto += "Punto de Venta: [" + Lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta + "]  Tipo de Comprobante: [" + Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante + "]  Nro. de Comprobante: [" + Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante + "]\r\n" + resultado + Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() + " " + descrCodigosErrorAFIPComprobante + "\r\n";
                    }
                }
            }
            return texto;
        }
        private CedWebRN.IBK.lote_response ArmarLoteResponse(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            CedWebRN.IBK.lote_response lrCompleto = new CedWebRN.IBK.lote_response();
            CedWebRN.IBK.error[] errores = new CedWebRN.IBK.error[1];
            lrCompleto.cantidad_reg = Lc.cabecera_lote.cantidad_reg;
            lrCompleto.cuit_canal = Lc.cabecera_lote.cuit_canal;
            lrCompleto.cuit_vendedor = Lc.cabecera_lote.cuit_vendedor;
            lrCompleto.estado = Lc.cabecera_lote.resultado;
            lrCompleto.fecha_envio_lote = Lc.cabecera_lote.fecha_envio_lote;
            lrCompleto.id_lote = Lc.cabecera_lote.id_lote;
            lrCompleto.presta_serv = Lc.cabecera_lote.presta_serv;
            lrCompleto.presta_servSpecified = Lc.cabecera_lote.presta_servSpecified;
            lrCompleto.punto_de_venta = Lc.cabecera_lote.punto_de_venta;
            if (Lc.cabecera_lote.motivo != null && Lc.cabecera_lote.motivo.Trim() != "00" && Lc.cabecera_lote.motivo.Trim() != "")
            {
                errores[0] = new CedWebRN.IBK.error();
                errores[0].codigo_error = 0;
                errores[0].descripcion_error = Lc.cabecera_lote.motivo.Trim();
                lrCompleto.errores_lote = errores;
            }
            int CantMotivoError = 0;
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
                {
                    CantMotivoError++;
                }
            }
            int NroMotivo = 0;
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                CedWebRN.IBK.error[] erroresComprobante = new CedWebRN.IBK.error[1];
                if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
                {
                    if (lrCompleto.comprobante_response == null)
                    {
                        lrCompleto.comprobante_response = new CedWebRN.IBK.comprobante_response[CantMotivoError];
                    }
                    erroresComprobante[NroMotivo] = new CedWebRN.IBK.error();
                    erroresComprobante[NroMotivo].codigo_error = 0;
                    erroresComprobante[NroMotivo].descripcion_error = Lc.comprobante[i].cabecera.informacion_comprobante.motivo;
                    lrCompleto.comprobante_response[NroMotivo] = new CedWebRN.IBK.comprobante_response();
                    lrCompleto.comprobante_response[NroMotivo].numero_comprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                    lrCompleto.comprobante_response[NroMotivo].punto_de_venta = Lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                    lrCompleto.comprobante_response[NroMotivo].tipo_de_comprobante = Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
                    lrCompleto.comprobante_response[NroMotivo].estado = Lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                    lrCompleto.comprobante_response[NroMotivo].errores_comprobante = erroresComprobante;
                    NroMotivo++;
                }
            }
            return lrCompleto;
        }
        private void OtrosFiltrosFiltrarBS()
        {
            if (Aplicacion.OtrosFiltrosFiltrarBS == "SI")
            {
                if (Aplicacion.OtrosFiltrosCuit != null && Aplicacion.OtrosFiltrosCuit != "")
                {
                    OtrosFiltrosBandejaSCheckBox.Checked = true;
                    OtrosFiltrosBandejaSCheckBox.Enabled = false;
                    OtrosFiltrosBandejaSPanel.Enabled = true;
                    CuitVendedorTextBox.Text = Aplicacion.OtrosFiltrosCuit;
                    CuitVendedorTextBox.ReadOnly = true;
                }
                if (Aplicacion.OtrosFiltrosPuntoVta != null && Aplicacion.OtrosFiltrosPuntoVta != "")
                {
                    OtrosFiltrosBandejaSCheckBox.Checked = true;
                    OtrosFiltrosBandejaSCheckBox.Enabled = false;
                    OtrosFiltrosBandejaSPanel.Enabled = true;
                    PuntoVentaTextBox.Text = Convert.ToInt32(Aplicacion.OtrosFiltrosPuntoVta).ToString();
                    PuntoVentaTextBox.ReadOnly = true;
                }
            }
        }
        private void DescartarBandejaEButton_Click(object sender, EventArgs e)
        {
            DescartarBandejaE();
        }

        private void DescartarBandejaE()
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            VerificarServicio();
            if (Aplicacion.Modalidad == "Automatica" && ServicioOK == true)
            {
                MessageBox.Show("No es posible descartar archivos, mientras el Servicio-eFact se encuentre activo.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EnviarABandejaSButton.Enabled = false;
            DescartarBandejaEButton.Enabled = false;
            try
            {
                if (BandejaEDataGridView.SelectedRows.Count != 0)
                {
                    DialogResult resp = MessageBox.Show("Desea descartar los archivos ?\r\n\r\nCantidad de archivos seleccionados (" + BandejaEDataGridView.SelectedRows.Count + ")\r\n\r\nLos mismos serán movidos al repositorio de archivos históricos.", "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resp == DialogResult.Yes)
                    {
                        for (int i = 0; i < BandejaEDataGridView.SelectedRows.Count; i++)
                        {
                            int renglon = BandejaEDataGridView.SelectedRows[i].Index;
                            //Definir el nombre del archivo a guardar en el histórico como procesado, con o sin error.
                            //Mas adelante se le agraga el prefijo ( BAK o ERR ).
                            string NombreArchivo = dtBandejaEntrada[renglon].Nombre;
                            string FechaTexto = DateTime.Now.ToString("yyyyMMdd-hhmmss");
                            string ArchGuardarComoNombre = "";
                            eFact_RN.Engine.GenerarNombreArch(out ArchGuardarComoNombre, "DES", NombreArchivo);
                            //Remover archivo ( descartar ) --------
                            Directory.Move(Aplicacion.Aplic.ArchPath + "\\" + NombreArchivo, Aplicacion.Aplic.ArchPathHis + ArchGuardarComoNombre);
                            //--------------------------------------
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione por lo menos un archivo a descartar.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                EnviarABandejaSButton.Enabled = true;
                DescartarBandejaEButton.Enabled = true;
                LimpiarBandejaEntrada();
                ActualizarBandejaE();
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        private void LimpiarBandejaEntrada()
        {
            dtBandejaEntrada = new List<eFact_Entidades.Archivo>();
            BandejaEDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
            BandejaEDataGridView.Refresh();
        }

        private void InicializarFiltrosTablero()
        {
            FechaAltaLoteRadioButton.Checked = true;
            OtrosFiltrosBandejaSCheckBox.Checked = false;
            FechaDsdLoteFecAltaDTP.Value = DateTime.Today;
            FechaHstLoteFecAltaDTP.Value = DateTime.Today;
            FechaDsdLoteFecEnvioDTP.Value = DateTime.Today;
            FechaHstLoteFecEnvioDTP.Value = DateTime.Today;
            //Verifica y inicializa ( CuitVendedorTextBox y PuntoVentaTextBox )
            OtrosFiltrosFiltrarBS();
            NumeroLoteTextBox.Text = "";
        }

        private void RefreshBandejaSalida()
        {
            eFact_Entidades.Lote.TipoConsulta tipoConsulta;
            DateTime fechaDsd;
            DateTime fechaHst;
            if (FechaAltaLoteRadioButton.Checked)
            {
                tipoConsulta = eFact_Entidades.Lote.TipoConsulta.FechaAlta;
                fechaDsd = FechaDsdLoteFecAltaDTP.Value;
                fechaHst = FechaHstLoteFecAltaDTP.Value;
            }
            else
            {
                tipoConsulta = eFact_Entidades.Lote.TipoConsulta.FechaEnvio;
                fechaDsd = FechaDsdLoteFecEnvioDTP.Value;
                fechaHst = FechaHstLoteFecEnvioDTP.Value;
            }
            string cuitVendedor = "";
            string numeroLote = "";
            string puntoVenta = "";
            if (OtrosFiltrosBandejaSCheckBox.Checked)
            {
                cuitVendedor = CuitVendedorTextBox.Text;
                numeroLote = NumeroLoteTextBox.Text;
                puntoVenta = PuntoVentaTextBox.Text;
            }
            eFact_RN.Lote.Consultar(out dtBandejaSalida, tipoConsulta, fechaDsd, fechaHst, cuitVendedor, numeroLote, puntoVenta, PtesDiasAntCheckBox.Checked, Aplicacion.Sesion);
            BandejaSDataGridView.DataSource = new List<eFact_Entidades.Lote>();
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            BandejaSDataGridView.Refresh();
        }

        private void EnviarABandejaSButton_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            VerificarServicio();
            if (Aplicacion.Modalidad == "Automatica" && ServicioOK == true)
            {
                MessageBox.Show("No es posible enviar archivos a la bandeja de salida, mientras el Servicio-eFact se encuentre activo.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EnviarABandejaSButton.Enabled = false;
            DescartarBandejaEButton.Enabled = false;
            try
            {
                if (BandejaEDataGridView.SelectedRows.Count != 0)
                {
                    //Inicializar filtros para visualizar los archivos procesados.
                    InicializarFiltrosTablero();
                    for (int i = 0; i < BandejaEDataGridView.SelectedRows.Count; i++)
                    {
                        int renglon = BandejaEDataGridView.SelectedRows[i].Index;
                        //Definir el nombre del archivo a guardar en el histórico como procesado, con o sin error.
                        //Mas adelante se le agraga el prefijo ( BAK o ERR ).
                        string NombreArchivo = dtBandejaEntrada[renglon].Nombre;
                        string FechaTexto = DateTime.Now.ToString("yyyyMMdd-hhmmss");
                        string ArchGuardarComoNombre = "";
                        eFact_RN.Engine.GenerarNombreArch(out ArchGuardarComoNombre, "", NombreArchivo);
                        //--------------------------------------
                        //Procesar el archivo seleccionado.
                        try
                        {
                            eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                            eFact_RN.Archivo.Procesar(out lote, dtBandejaEntrada[renglon], Aplicacion.Aplic, Aplicacion.Sesion);
                            //Agregar datos del proceso a la entidad Archivo
                            ArchGuardarComoNombre = "BAK-" + ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].NombreProcesado = ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].FechaProceso = DateTime.Now;
                            string handler = eFact_RN.Archivo.Insertar(dtBandejaEntrada[renglon], true, Aplicacion.Sesion);
                            //Ejecutar el insert local del "Lote".
                            CedEntidades.Evento evento = new CedEntidades.Evento();
                            evento.Id = "EnvBandSalida";
                            evento.Flow.IdFlow = "eFact";
                            evento.Flow.DescrFlow = "Facturación Electrónica";
                            Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion);
                            lote.WF = Cedeira.SV.WF.Nueva("eFact", "Fact", 0, "Facturacion Electrónica", Aplicacion.Sesion);
                            eFact_RN.Lote.VerificarEnviosPosteriores(true, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, eFact_R.Aplicacion.Sesion);
                            //Generar nombre de archivo procesado para ser enviado al histórico.
                            eFact_RN.Lote.Ejecutar(lote, evento, handler, Aplicacion.Aplic, Aplicacion.Sesion);
                        }
                        catch (Exception ex)
                        {
                            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                            dtBandejaEntrada[renglon].Comentario = ex.Message;
                            if (ex.InnerException != null)
                            {
                                dtBandejaEntrada[renglon].Comentario += "\r\n" + ex.InnerException.Message;
                            }
                            //Agregar datos del proceso a la entidad Archivo
                            ArchGuardarComoNombre = "ERR-" + ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].NombreProcesado = ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].FechaProceso = DateTime.Now;
                            eFact_RN.Archivo.Insertar(dtBandejaEntrada[renglon], false, Aplicacion.Sesion);
                        }
                        //Remover archivo ----------------------
                        Directory.Move(Aplicacion.Aplic.ArchPath + "\\" + NombreArchivo, Aplicacion.Aplic.ArchPathHis + ArchGuardarComoNombre);
                        //--------------------------------------
                    }
                }
            }
            catch (Exception ex2)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex2);
            }
            //Actualizar Bandeja de entrada.
            try
            {
                LimpiarBandejaEntrada();
                ActualizarBandejaE();
                RefreshBandejaSalida();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                EnviarABandejaSButton.Enabled = true;
                DescartarBandejaEButton.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        private static int Comparer(eFact_Entidades.Lote x, eFact_Entidades.Lote y)
        {
            return x.NumeroLote.CompareTo(y.NumeroLote);
        }

        public List<eFact_Entidades.Lote> SortListaLotes(List<eFact_Entidades.Lote> lLotes)
        {
            lLotes.Sort(Comparer);
            return lLotes;
        } 

        private void EnviarAIF()
        {
            try
            {
                Cursor=System.Windows.Forms.Cursors.WaitCursor;
                EventosComboBox.Enabled = false;
                if (BandejaSDataGridView.SelectedRows.Count != 0)
                {
                    eFact_Entidades.Lote l = new eFact_Entidades.Lote();
                    List<eFact_Entidades.Lote> llotes = new List<eFact_Entidades.Lote>();
                    for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
                    {
                        int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                        l = dtBandejaSalida[renglon];
                        llotes.Add(l);
                    }
                    llotes = SortListaLotes(llotes);
                    for (int i = 0; i < llotes.Count; i++)
                    {
                        //Envio del lote a IF
                        eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                        lote = llotes[i];
                        List<CedEntidades.Evento> eventosposibles = new List<CedEntidades.Evento>();
                        eventosposibles = lote.WF.EventosPosibles.FindAll((delegate(CedEntidades.Evento e1) { return e1.IdEstadoDsd.IdEstado.ToString() == "PteEnvio"; }));
                        if (eventosposibles.Count == 0)
                        {
                            MessageBox.Show("Imposible enviar el lote: " + lote.NumeroLote + " en el estado actual.", "Envio de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            break;
                        }
                        FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                        eFact_RN.Lote.DeserializarLc(out lc, lote, false);

                        //Antes de ejecutar el envio a Interfacturas, cambiar el estado.
                        EjecutarEventoBandejaS("EnviarAIF", "", lote);
                        //Actualizar el WF del lote.
                        eFact_RN.Lote.Leer(lote, Aplicacion.Sesion);

                        //Consultar si exite el lote en Interfacturas
                        FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                        CedWebRN.IBK.error[] respErroresLote = new CedWebRN.IBK.error[0];
                        CedWebRN.IBK.error[] respErroresComprobantes = new CedWebRN.IBK.error[0];
                        CedWebRN.IBK.consulta_lote_responseErrores_consulta RespErroresLote = new CedWebRN.IBK.consulta_lote_responseErrores_consulta();
                        CedWebRN.IBK.consulta_lote_comprobantes_responseErrores_response RespErroresComprobantes = new CedWebRN.IBK.consulta_lote_comprobantes_responseErrores_response();
                        //Enviar a Interfacturas si el lote no existe.
                        CedWebRN.Comprobante CedWebRNComprobante = new CedWebRN.Comprobante();
                        CedWebRN.IBK.lote_response Lr = new CedWebRN.IBK.lote_response();
                        try
                        {
                            eFact_Entidades.Vendedor v = Aplicacion.Vendedores.Find(delegate(eFact_Entidades.Vendedor e1) { return e1.CuitVendedor == lc.cabecera_lote.cuit_vendedor.ToString(); });
                            if (v == null)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Vendedor.Inexistente("CUIT " + lc.cabecera_lote.cuit_vendedor.ToString());
                            }
                            CedWebRNComprobante.EnviarIBK(out Lr, lc, v.NumeroSerieCertificado.ToString());
                            EjecutarEventoBandejaS("RegAceptIF", "", lote);
                        }
                        catch (Exception ex2)
                        {
                            //Si el lote tiene errores al ser enviado, grabar el rechazo.
                            string edescr = "";
                            if (Lr.estado == null && Lr.errores_lote == null && Lr.comprobante_response == null)
                            {
                                //Cuando el error es local, previo a la respuesta de IF se usa el código 99 (Cedeira) para mostrar el error.
                                //Ejemplo: cuando no está instalado el certificado.
                                Lr.estado = "99";
                                Lr.errores_lote = new CedWebRN.IBK.error[1];
                                Lr.errores_lote[0] = new CedWebRN.IBK.error();
                                Lr.errores_lote[0].codigo_error = 99;
                                edescr = ex2.Message.Replace("'", "''");
                                Lr.errores_lote[0].descripcion_error = edescr;
                                if (edescr.IndexOf("500 - error") != -1)
                                {
                                    Lr.errores_lote[0].codigo_error = 500;
                                }
                                if (edescr.IndexOf("600 - error") != -1)
                                {
                                    Lr.errores_lote[0].codigo_error = 600;
                                }
                            }
                            eFact_RN.Lote.ActualizarDatosError(lote, Lr);
                            edescr = ex2.Message.Replace("'", "''");
                            EjecutarEventoBandejaS("RegRechIF", edescr, lote);
                            //Va a revertir el rechazo (si el error es "Timed Out" hasta 10 ocurrencias.
                            if (Lr.estado == "99" && Lr.errores_lote != null && Lr.errores_lote[0].descripcion_error.ToUpper().Trim() == "THE OPERATION HAS TIMED OUT")
                            {
                                eFact_Entidades.Lote loteAux = new eFact_Entidades.Lote();
                                loteAux.IdLote = lote.IdLote;
                                eFact_RN.Lote.Leer(loteAux, Aplicacion.Sesion);
                                List<CedEntidades.Log> log = loteAux.WF.Log.FindAll(delegate(CedEntidades.Log e1) { return e1.Comentario.ToUpper().Trim() == "THE OPERATION HAS TIMED OUT"; });
                                if (log != null && log.Count > 0 && log.Count < 10)
                                {
                                    //Actualizar el WF del lote.
                                    eFact_RN.Lote.Leer(lote, Aplicacion.Sesion);
                                    EjecutarEventoBandejaS("RevertirRechIFA", "", lote);
                                }
                            }
                            throw new Exception(ex2.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                RefreshBandejaSalida();
                EventosComboBox.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void EventosWF(string Evento)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                EventosComboBox.Enabled = false;
                if (BandejaSDataGridView.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
                    {
                        eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                        int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                        lote = dtBandejaSalida[renglon];
                        EjecutarEventoBandejaS(Evento, "", lote);
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                EventosComboBox.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void EjecutarEventoBandejaS(string IdEvento, string Comentario, eFact_Entidades.Lote lote)
        {
            CedEntidades.Evento evento = new CedEntidades.Evento();
            evento.Id = IdEvento;
            evento.Flow.IdFlow = "eFact";
            evento.Flow.DescrFlow = "Facturación Electrónica";
            evento.Comentario = Comentario;
            Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion);
            eFact_RN.Lote.VerificarEnviosPosteriores(false, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, eFact_R.Aplicacion.Sesion);
            eFact_RN.Lote.Ejecutar(lote, evento, "", Aplicacion.Aplic, Aplicacion.Sesion);
            RefreshBandejaSalida();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            ConsultarLote();
        }

        private void OtrosFiltrosBandejaSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                OtrosFiltrosBandejaSPanel.Enabled = true;
            }
            else 
            {
                OtrosFiltrosBandejaSPanel.Enabled = false;
            }
        }

        private void FechaEnvioLoteRadioButton_Click(object sender, EventArgs e)
        {
            TipoConsulta = eFact_Entidades.Lote.TipoConsulta.FechaEnvio;
        }

        private void FechaAltaLoteRadioButton_Click(object sender, EventArgs e)
        {
            TipoConsulta = eFact_Entidades.Lote.TipoConsulta.FechaAlta;
        }

        private void ArchivoOKRadioButton_Click(object sender, EventArgs e)
        {
            ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.OK;
        }

        private void ArchivosNotOKRadioButton_Click(object sender, EventArgs e)
        {
            ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.NotOk;
        }

        private void OtrosFiltrosBandejaECheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                OtrosFiltrosBandejaEPanel.Enabled = true;
                ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.OK;
            }
            else
            {
                OtrosFiltrosBandejaEPanel.Enabled = false;
                ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.SinAplicar;
            }
        }

        private void BandejaEDataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (BandejaEDataGridView.SelectedRows.Count != 0)
                {
                    int renglon = BandejaEDataGridView.SelectedRows[0].Index;
                    string comentario = dtBandejaEntrada[renglon].Comentario;
                    if (comentario != "")
                    {
                        Comentarios c = new Comentarios(comentario);
                        c.ShowDialog();
                        c.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }

        private void ArchivosAProcesar_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && ((RadioButton)sender).Name == "ArchivosAProcesarRadioButton")
            {
                //Actualizar Bandeja de entrada.
                try
                {
                    LimpiarBandejaEntrada();
                    ActualizarBandejaE();
                }
                catch (Exception ex)
                {
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                }
                finally
                {
                    EnviarABandejaSButton.Enabled = true;
                    Cursor = System.Windows.Forms.Cursors.Default;
                }
                ArchivosHistoricosPanel.Enabled = false;
                EnviarABandejaSButton.Enabled = true;
            }
            else
            {
                LimpiarBandejaEntrada();
                ArchivosHistoricosPanel.Enabled = true;
                EnviarABandejaSButton.Enabled = false;
            }
        }

        private void FechasArchivosHistorios_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && ((RadioButton)sender).Name == "FechaCreacionRadioButton")
            {
                TipoConsultaArchivos = eFact_Entidades.Archivo.TipoConsultaArchivos.FechaCreacion;
            }
            else
            {
                TipoConsultaArchivos = eFact_Entidades.Archivo.TipoConsultaArchivos.FechaProceso;
            }
        }

        private void BandejaSDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EventosComboBox.Enabled = false;
                switch (BandejaSDataGridView.SelectedRows.Count)
                {
                    case 0:
                        break;
                    case 1:
                        int renglon = BandejaSDataGridView.SelectedRows[0].Index;
                        List<CedEntidades.Evento> leventos = new List<CedEntidades.Evento>();
                        CedEntidades.Evento evento = new CedEntidades.Evento();
                        evento.Id = "(ElegirAccion)";
                        evento.Descr = "( Eligir una acción )";
                        leventos.Add(evento);
                        List<CedEntidades.Evento> leventosAux = dtBandejaSalida[renglon].WF.EventosPosibles.FindAll((delegate(CedEntidades.Evento e1) { return e1.Automatico == false; }));
                        leventos.AddRange(leventosAux);
                        EventosComboBox.DataSource = leventos;
                        EventosComboBox.DisplayMember = "Descr";
                        EventosComboBox.ValueMember = "Id";
                        //Armado de ComboBox con las opciones de exportar con respuesta IF.
                        ExportarItfComboBox.Items.Clear();
                        ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato TXT");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML para subir a Interfacturas");
                        ExportarItfComboBox.SelectedIndex = 0;
                        if (dtBandejaSalida[renglon].WF.IdEstado == "AceptadoAFIP")
                        {
                            ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato TXT");
                            ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato XML");
                        }
                        break;
                    default:
                        ExportarItfComboBox.Items.Clear();
                        ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato TXT");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML");
                        ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML para subir a Interfacturas");
                        ExportarItfComboBox.SelectedIndex = 0;
                        ConfigBotonesEventosXLote();
                        break;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                EventosComboBox.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        private void ConfigBotonesEventosXLote()
        {

            ExportarItfComboBox.Items.Clear();
            ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
            ExportarItfComboBox.Items.Add("Exportar archivo original en formato TXT");
            ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML");
            ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML para subir a Interfacturas");
            // Determinacion de eventos (XLote) comunes a todas las 
            // operaciones seleccionadas
            List<CedEntidades.Evento> eventosXLoteAux = new List<CedEntidades.Evento>();
            List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
            InicializarEventosComboBox(out eventosXLote);
            for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
            {
                //string a = BandejaSDataGridView.SelectedRows[i].Cells["Repositorio"].Value.ToString();
                //Mep mep = new Mep(a, Convert.ToInt32(BandejaSDataGridView.SelectedRows[i].Cells["IdOp"].Value), Aplicacion.Sesion);
                int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                if (i == 0)
                {
                    eventosXLoteAux = dtBandejaSalida[renglon].WF.EventosXLotePosibles;
                    eventosXLote.AddRange(eventosXLoteAux);
                }
                else
                {
                    List<CedEntidades.Evento> eventosXLoteCHK = new List<CedEntidades.Evento>();
                    eventosXLoteCHK = dtBandejaSalida[renglon].WF.EventosXLotePosibles;
                    bool ExportarRespAFIPXLote = true;
                    for (int k = 0; k < eventosXLoteAux.Count; k++)
                    {
                        if (eventosXLoteCHK.FindAll((delegate(CedEntidades.Evento e1) { return e1.Id == eventosXLoteAux[k].Id; })).Count == 0)
                        {
                            eventosXLote.Remove(eventosXLoteAux[k]);
                        }
                        if (dtBandejaSalida[renglon].WF.IdEstado != "AceptadoAFIP")
                        {
                            ExportarRespAFIPXLote = false;
                        }
                    }
                    if (ExportarRespAFIPXLote)
                    {
                        ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato TXT");
                        ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato XML");
                    }
                }
            }
            ExportarItfComboBox.SelectedIndex = 0;
            EventosComboBox.DataSource = eventosXLote;
        }

        private void EventosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                VerificarServicio();
                if (Aplicacion.Modalidad == "Automatica" && ServicioOK == true)
                {
                    MessageBox.Show("No es posible ejecutar eventos manuales, mientras el Servicio-eFact se encuentre activo.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string evento = ((CedEntidades.Evento)(((ComboBox)sender).SelectedItem)).Id;
                switch (evento)
                {
                    case "EnviarAIF":
                        EnviarAIF();
                        break;
                    default:
                        EventosWF(evento);
                        break;
                }
            }
        }

        private void ExportarItf(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).SelectedIndex != 0)
                {
                    Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ExportarItfComboBox.Enabled = false;
                    if (BandejaSDataGridView.SelectedRows.Count != 0)
                    {
                        for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
                        {
                            int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                            eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                            lote = dtBandejaSalida[renglon];
                            string archivoProcesado = "";
                            bool IF = false;
                            if (((ComboBox)sender).SelectedIndex == 4 || ((ComboBox)sender).SelectedIndex == 5)
                            {
                                IF = true;
                            }
                            // 1 y 4 archivos TXT 
                            // 2, 3 y 5 archivos XML  
                            if (((ComboBox)sender).SelectedIndex == 1 || ((ComboBox)sender).SelectedIndex == 4)
                            {
                                eFact_RN.Lote.GuardarItfTXT(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF);
                            }
                            else
                            {
                                if (((ComboBox)sender).SelectedIndex == 3)
                                {
                                    eFact_RN.Lote.GuardarItfXML(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF, true);
                                }
                                else
                                {
                                    eFact_RN.Lote.GuardarItfXML(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF, false);
                                }
                            }
                            MessageBox.Show("Interface generada satisfactoriamente con el nombre: " + archivoProcesado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                ExportarItfComboBox.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ConsultaVendedor c = new ConsultaVendedor(StatusBar);
                c.ShowDialog();
                c.Dispose();
                c = null;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            string sistema = ((System.Reflection.AssemblyDescriptionAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute), false)[0]).Description;
            string codigoSistema = ((System.Reflection.AssemblyTitleAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false)[0]).Title;
            Cedeira.UI.Mostrar.Acerca(sistema, codigoSistema, "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build, 0);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            string NombreArchAyuda = @System.Configuration.ConfigurationManager.AppSettings["NombreArchAyuda"];
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\" + NombreArchAyuda);
        }

        private void BandejaSDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ConsultarLote();
        }
        private void ConsultarLote()
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (BandejaSDataGridView.SelectedRows.Count != 0)
                {
                    eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                    int renglon = BandejaSDataGridView.SelectedRows[0].Index;
                    lote = dtBandejaSalida[renglon];
                    ConsultaLote cl = new ConsultaLote(lote, ConsultaLote.Modo.Consulta);
                    cl.ShowDialog();
                    cl.Dispose();
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            try 
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ConsultaLote c = new ConsultaLote(ConsultaLote.Modo.Contingencia);
                c.ShowDialog();
                c.Dispose();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void StatusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                switch (e.StatusBarPanel.Name)
                {
                    case "OrigenDatosSBP":
                        BarraEstado c = new BarraEstado();
                        c.ShowDialog();
                        c.Dispose();
                        break;
                    case "ModalidadSBP":
                        VerificarServicio();
                        break;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}