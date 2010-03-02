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
        public List<eFact_R.Entidades.Archivo> dtBandejaEntrada = new List<eFact_R.Entidades.Archivo>();
        public List<eFact_R.Entidades.Lote> dtBandejaSalida = new List<eFact_R.Entidades.Lote>();
        eFact_R.RN.Tablero.TipoConsulta TipoConsulta;
        eFact_R.RN.Tablero.TipoConsultaArchivos TipoConsultaArchivos;
        eFact_R.RN.Archivo.OtrosFiltros ArchivosOtrosFiltros;

        public Tablero()
        {
            InitializeComponent();
            TipoConsulta = eFact_R.RN.Tablero.TipoConsulta.FechaAlta;
            TipoConsultaArchivos = eFact_R.RN.Tablero.TipoConsultaArchivos.FechaProceso;
            ArchivosOtrosFiltros = eFact_R.RN.Archivo.OtrosFiltros.SinAplicar;

            StatusBar.Panels["UsuarioSBP"].Text = "Usuario: " + Aplicacion.Sesion.Usuario.Nombre;
            StatusBar.Panels["UsuarioSBP"].ToolTipText = "Información del usuario\r\nNombre:" + Aplicacion.Sesion.Usuario.Nombre;

            //<add key="Certificado" value="012425509e59" />
            List<eFact_R.Entidades.Vendedor> vendedores = new List<eFact_R.Entidades.Vendedor>();
            eFact_R.RN.Vendedor.Consultar(vendedores, Aplicacion.Sesion);
            if (vendedores.Count > 0)
            {
                StatusBar.Panels["CertificadosSBP"].Text = "Certificados: OK";
                StatusBar.Panels["CertificadosSBP"].ToolTipText = "";
                bool AllCertifOK = true;
                foreach (eFact_R.Entidades.Vendedor v in vendedores)
                {
                    X509Store store = new X509Store(StoreLocation.LocalMachine);
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
            StatusBar.Panels["OrigenDatosSBP"].ToolTipText = "Directorio de Datos: " + Aplicacion.ArchPath + "\r\n" + "Hitoricos: " + Aplicacion.ArchPathHis + "\r\n" + "Interfaz manual: " + Aplicacion.ArchPathItf + "\r\n" + "Interfaz aut.: " + Aplicacion.ArchPathItfAut + "\r\n" + "PDFs: " + Aplicacion.ArchPathPDF;
            StatusBar.Panels["CXOSBP"].Text = "CXO: " + Aplicacion.Sesion.CXO;
            StatusBar.Panels["CXOSBP"].ToolTipText = "Control por oposición: " + Aplicacion.Sesion.CXO;
            eFact_R.RN.Vendedor.Consultar(Aplicacion.Vendedores, Aplicacion.Sesion);
            VerificarCaptServicio();
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
                if (!Directory.Exists(Aplicacion.ArchPath))
                {
                    di = Directory.CreateDirectory(Aplicacion.ArchPath);
                    MessageBox.Show("Se ha creado el repositorio para el procesamiento de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio deberán ser copiados todos los archivos a procesar.");
                }
                if (!Directory.Exists(Aplicacion.ArchPathHis))
                {
                    di = Directory.CreateDirectory(Aplicacion.ArchPathHis);
                    MessageBox.Show("Se ha creado el repositorio histórico de archivos procesados en el directorio: \r\n" + di.FullName + "\r\n\r\nA este repositorio se moverán automáticamente todos los archivos, los procesados satisfactoriamente y también los que no pudieran ser procesados por cualquier problema.");
                }
                if (!Directory.Exists(Aplicacion.ArchPathItf))
                {
                    di = Directory.CreateDirectory(Aplicacion.ArchPathItf);
                    MessageBox.Show("Se ha creado el repositorio de salida de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio se guardarán a pedido del usuario, los archivos de interfaz de salida que genere el usuario sobre lotes ya procesados.");
                }
                if (!Directory.Exists(Aplicacion.ArchPathItfAut))
                {
                    di = Directory.CreateDirectory(Aplicacion.ArchPathItfAut);
                    MessageBox.Show("Se ha creado el repositorio de salida automática de archivos en el directorio: \r\n" + di.FullName + "\r\n\r\nEn este repositorio se guardarán automáticamente, los archivos de interfaz de salida con las respuestas obtenidas desde la AFIP sobre los lotes de comprobantes procesados satisfactoriamente.");
                }
                if (!Directory.Exists(Aplicacion.ArchPathPDF))
                {
                    di = Directory.CreateDirectory(Aplicacion.ArchPathPDF);
                    MessageBox.Show("Se ha creado el repositorio para exportar comprobantes en formato PDF en el directorio: \r\n" + di.FullName + "");
                }
            }
            ActualizarBandejaE();
            BandejaEDataGridView.DataSource = new List<eFact_R.Entidades.Archivo>();
            BandejaEDataGridView.DataSource = dtBandejaEntrada;
            BandejaEDataGridView.Refresh();
            ActualizarBandejaS();
            BandejaSDataGridView.DataSource = new List<eFact_R.Entidades.Lote>();
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            BandejaSDataGridView.Refresh();
        }

        private void VerificarCaptServicio()
        {
            try
            {
                string machineName = @System.Configuration.ConfigurationManager.AppSettings["MachineName"];
                string serviceName = @System.Configuration.ConfigurationManager.AppSettings["ServiceName"];
                this.serviceController1.MachineName = machineName;
                this.serviceController1.ServiceName = serviceName;
                this.serviceController1.Refresh();
                string status = this.serviceController1.Status.ToString();
                StatusBar.Panels["ModalidadSBP"].Text = "Modalidad: " + Aplicacion.Modalidad + "  Servicio: " + status;
                StatusBar.Panels["ModalidadSBP"].ToolTipText = "Modalidad = " + Aplicacion.Modalidad + "\r\nServicio: " + status + "\r\nNombre de la PC: " + machineName + "\r\nNombre del servicio: " + serviceName;
            }
            catch (Exception ex)
            {
                string atencion = "";
                if (Aplicacion.Modalidad != "Manual")
                {
                    Aplicacion.Modalidad = "Manual";
                    atencion = " (!)";
                }
                StatusBar.Panels["ModalidadSBP"].Text = "Modalidad = Manual" + atencion + "  Servicio: Desactivado";
                if (atencion != "")
                {
                    StatusBar.Panels["ModalidadSBP"].ToolTipText = "(!) El servicio no está disponible, por lo tanto se habilitará la opción de procesamiento de archivos manual.\r\n\r\n" + "Mensaje: " + ex.Message;
                }
            }
        }

        private void ActualizarBandejaEButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ActualizarBandejaEButton.Enabled = false;
                //System.Threading.Thread.Sleep(1000);
                LimpiarBandejaEntrada();
                if (ArchivosHistoricosRadioButton.Checked)
                {
                    List<eFact_R.Entidades.Archivo> archivos = new List<eFact_R.Entidades.Archivo>();
                    if (TipoConsultaArchivos == eFact_R.RN.Tablero.TipoConsultaArchivos.FechaCreacion)
                    {
                        eFact_R.RN.Archivo.Consultar(out archivos, TipoConsultaArchivos, ArchivosOtrosFiltros, FechaAltaDsdBandejaEDTP.Value, FechaAltaHstBandejaEDTP.Value, Aplicacion.Sesion);
                    }
                    else
                    {
                        eFact_R.RN.Archivo.Consultar(out archivos, TipoConsultaArchivos, ArchivosOtrosFiltros, FechaProcesoDsdBandejaEDTP.Value, FechaProcesoHstBandejaEDTP.Value, Aplicacion.Sesion);
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
                BandejaEDataGridView.DataSource = new List<eFact_R.Entidades.Archivo>();
                BandejaEDataGridView.DataSource = dtBandejaEntrada;
                BandejaEDataGridView.Refresh();
                ActualizarBandejaEButton.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ActualizarBandejaE()
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            switch (eFact_R.Aplicacion.CodigoAplic.ToString())
            {
                case "eFactInterface":
                {
                    BandejaEDataGridView.AutoGenerateColumns = false;
                    string[] files = Directory.GetFiles(eFact_R.Aplicacion.ArchPath, "*.*");
                    BandejaEDataGridView.DataSource = new List<eFact_R.Entidades.Archivo>();
                    BandejaEDataGridView.DataSource = dtBandejaEntrada;
                    BandejaEDataGridView.Refresh();
                    foreach (string d in files)
                    {
                        FileInfo ArchFileInfo = new FileInfo(d);
                        try
                        {
                            bool incorporarALista = true;
                            //Si esta activado el filtro de archivos con "SI", los archivos deben respetar los primeros 16 digitos con el formato: CUIT + "-" + Punto de Venta + "-yyyyMMddhhmmss.TXT" 
                            //ej.: 30221234568-0004-20100228103500.TXT
                            if (Aplicacion.OtrosFiltrosArchivos == "SI")
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
                            else if (Aplicacion.OtrosFiltrosArchivos != "NO")
                            {
                                incorporarALista = false;
                            }
                            if (incorporarALista)
                            {
                                List<eFact_R.Entidades.Archivo> Archivos = new List<eFact_R.Entidades.Archivo>();
                                eFact_R.RN.Tablero.ActualizarBandejaEntrada(out Archivos, dtBandejaEntrada, ArchFileInfo, Aplicacion.Sesion);
                                dtBandejaEntrada = Archivos;
                                BandejaEDataGridView.DataSource = new List<eFact_R.Entidades.Archivo>();
                                BandejaEDataGridView.DataSource = dtBandejaEntrada;
                                BandejaEDataGridView.Refresh();
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
                //System.Threading.Thread.Sleep(1000);
                ActualizarBandejaS();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                BandejaSDataGridView.DataSource = new List<eFact_R.Entidades.Lote>();
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
            if (TipoConsulta == eFact_R.RN.Tablero.TipoConsulta.FechaAlta)
            {
                FechaDsd = FechaDsdLoteFecAltaDTP.Value;
                FechaHst = FechaHstLoteFecAltaDTP.Value;
            }
            else
            {
                FechaDsd = FechaDsdLoteFecEnvioDTP.Value;
                FechaHst = FechaHstLoteFecEnvioDTP.Value;
            }
            VerificarOtrosFiltrosFijos();
            string otrosFiltrosCuitvendedor = "";
            string otrosFiltrosPuntoVenta = "";
            string otrosFiltrosNumeroLote = "";
            if (OtrosFiltrosBandejaSCheckBox.Checked)
            {
                otrosFiltrosCuitvendedor = CuitVendedorTextBox.Text;
                otrosFiltrosNumeroLote = NumeroLoteTextBox.Text;
                otrosFiltrosPuntoVenta = PuntoVentaTextBox.Text;
            }
            BandejaSDataGridView.AutoGenerateColumns = false;
            eFact_R.RN.Tablero.ActualizarBandejaSalida(out dtBandejaSalida, TipoConsulta, FechaDsd, FechaHst, otrosFiltrosCuitvendedor, otrosFiltrosNumeroLote, otrosFiltrosPuntoVenta, PtesDiasAntCheckBox.Checked, eFact_R.Aplicacion.Sesion);
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            //Verificar Ptes.Respuesta AFIP.
            List<eFact_R.Entidades.Lote> dtBandejaSalidaFind = dtBandejaSalida.FindAll((delegate(eFact_R.Entidades.Lote e1) { return e1.WF.IdEstado == "PteRespAFIP"; }));
            foreach (eFact_R.Entidades.Lote l in dtBandejaSalidaFind)
            {
                FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                CedWebRN.IBK.error[] respErroresLote = new CedWebRN.IBK.error[0];
                CedWebRN.IBK.error[] respErroresComprobantes = new CedWebRN.IBK.error[0];
                try
                {
                    //Consultar si exite el lote en Interfacturas
                    eFact_R.RN.Lote.ConsultarLoteIF(out Lc, out respErroresLote, out respErroresComprobantes, l, Aplicacion.Vendedores.Find(delegate(eFact_R.Entidades.Vendedor e1) { return e1.CuitVendedor == l.CuitVendedor; }).NumeroSerieCertificado);
                    //Ejecutar evento ( cambia el estado )
                    if (Lc.cabecera_lote.resultado == "A")
                    {
                        eFact_R.RN.Lote.ActualizarDatosCAE(l, Lc);
                        string comentario = ArmarTextoMotivo(Lc);
                        EjecutarEventoBandejaS("RegAceptAFIP", comentario, l);
                    }
                    else if (Lc.cabecera_lote.resultado == "R")
                    {
                        string comentario = ArmarTextoMotivo(Lc);
                        EjecutarEventoBandejaS("RegRechAFIP", comentario, l);
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
            eFact_R.RN.Tablero.ActualizarBandejaSalida(out dtBandejaSalida, TipoConsulta, FechaDsd, FechaHst, otrosFiltrosCuitvendedor, otrosFiltrosNumeroLote, otrosFiltrosPuntoVenta, PtesDiasAntCheckBox.Checked, eFact_R.Aplicacion.Sesion);
            BandejaSDataGridView.DataSource = new List<eFact_R.Entidades.Lote>();
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            BandejaSDataGridView.Refresh();
            Cursor = System.Windows.Forms.Cursors.Default;
        }
        private string ArmarTextoMotivo(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            string texto = "";
            if (Lc.cabecera_lote.resultado == "A" || Lc.cabecera_lote.resultado == "R")
            {
                if (Lc.cabecera_lote.motivo.Trim() != "00" && Lc.cabecera_lote.motivo.Trim() != "")
                {
                    FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP codigosErrorAFIPLote = FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP.Lista().Find((delegate(FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP e1) { return e1.Codigo == Lc.cabecera_lote.motivo.Trim(); }));
                    string descrCodigosErrorAFIPLote = "";
                    if (codigosErrorAFIPLote != null)
                    {
                        descrCodigosErrorAFIPLote = codigosErrorAFIPLote.Descr;
                    }
                    texto += "Código de problema a nivel lote: " + Lc.cabecera_lote.motivo.Trim() + " " + descrCodigosErrorAFIPLote + "\r\n\r\n";
                }
                for (int i = 0; i < Lc.comprobante.Length; i++)
                {
                    if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
                    {
                        FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP codigosErrorAFIPComprobante = FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP.Lista().Find((delegate(FeaEntidades.CodigosErrorAFIP.CodigoErrorAFIP e1) { return e1.Codigo == Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim(); }));
                        string descrCodigosErrorAFIPComprobante = "";
                        if (codigosErrorAFIPComprobante != null)
                        {
                            descrCodigosErrorAFIPComprobante = codigosErrorAFIPComprobante.Descr;
                        }
                        texto += "Código de problema a nivel comprobante ( renglon " + i.ToString() + "): " + Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() + " " + descrCodigosErrorAFIPComprobante + "\r\n";
                    }
                }
            }
            return texto;
        }
        private void VerificarOtrosFiltrosFijos()
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
        private void DescartarBandejaEButton_Click(object sender, EventArgs e)
        {
            DescartarBandejaE();
        }

        private void DescartarBandejaE()
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            EnviarABandejaSButton.Enabled = false;
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
                            eFact_R.RN.Engine.GenerarNombreArch(out ArchGuardarComoNombre, "DES", NombreArchivo);
                            //Remover archivo ( descartar ) --------
                            Directory.Move(Aplicacion.ArchPath + "\\" + NombreArchivo, Aplicacion.ArchPathHis + ArchGuardarComoNombre);
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
                ActualizarBandejaE();
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        private void LimpiarBandejaEntrada()
        {
            dtBandejaEntrada = new List<eFact_R.Entidades.Archivo>();
            BandejaEDataGridView.DataSource = new List<eFact_R.Entidades.Archivo>();
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
            VerificarOtrosFiltrosFijos();
            NumeroLoteTextBox.Text = "";
        }

        private void RefreshBandejaSalida()
        {
            eFact_R.RN.Tablero.TipoConsulta tipoConsulta;
            DateTime fechaDsd;
            DateTime fechaHst;
            if (FechaAltaLoteRadioButton.Checked)
            {
                tipoConsulta = eFact_R.RN.Tablero.TipoConsulta.FechaAlta;
                fechaDsd = FechaDsdLoteFecAltaDTP.Value;
                fechaHst = FechaHstLoteFecAltaDTP.Value;
            }
            else
            {
                tipoConsulta = eFact_R.RN.Tablero.TipoConsulta.FechaEnvio;
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
            eFact_R.RN.Lote.Consultar(out dtBandejaSalida, tipoConsulta, fechaDsd, fechaHst, cuitVendedor, numeroLote, puntoVenta, PtesDiasAntCheckBox.Checked, Aplicacion.Sesion);
            BandejaSDataGridView.DataSource = new List<eFact_R.Entidades.Lote>();
            BandejaSDataGridView.DataSource = dtBandejaSalida;
            BandejaSDataGridView.Refresh();
        }

        private void EnviarABandejaSButton_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
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
                        eFact_R.RN.Engine.GenerarNombreArch(out ArchGuardarComoNombre, "", NombreArchivo);
                        //--------------------------------------
                        //Procesar el archivo seleccionado.
                        try
                        {
                            eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
                            eFact_R.RN.Archivo.Procesar(out lote, dtBandejaEntrada[renglon], Aplicacion.Sesion);
                            //Agregar datos del proceso a la entidad Archivo
                            ArchGuardarComoNombre = "BAK-" + ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].NombreProcesado = ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].FechaProceso = DateTime.Now;
                            string handler = eFact_R.RN.Archivo.Insertar(dtBandejaEntrada[renglon], true, Aplicacion.Sesion);
                            //Ejecutar el insert local del "Lote".
                            CedEntidades.Evento evento = new CedEntidades.Evento();
                            evento.Id = "EnvBandSalida";
                            evento.Flow.IdFlow = "eFact";
                            evento.Flow.DescrFlow = "Facturación Electrónica";
                            Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion);
                            lote.WF = Cedeira.SV.WF.Nueva("eFact", "Fact", 0, "Facturacion Electrónica", Aplicacion.Sesion);
                            eFact_R.RN.Lote.VerificarEnviosPosteriores(true, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, eFact_R.Aplicacion.Sesion);
                            //Generar nombre de archivo procesado para ser enviado al histórico.
                            eFact_R.RN.Lote.Ejecutar(lote, evento, handler, Aplicacion.Sesion);
                        }
                        catch (Exception ex)
                        {
                            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                            dtBandejaEntrada[renglon].Comentario = ex.Message;
                            //Agregar datos del proceso a la entidad Archivo
                            ArchGuardarComoNombre = "ERR-" + ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].NombreProcesado = ArchGuardarComoNombre;
                            dtBandejaEntrada[renglon].FechaProceso = DateTime.Now;
                            eFact_R.RN.Archivo.Insertar(dtBandejaEntrada[renglon], false, Aplicacion.Sesion);
                        }
                        //Remover archivo ----------------------
                        //Directory.Move(Aplicacion.ArchPath + "\\" + NombreArchivo, Aplicacion.ArchPathHis + ArchGuardarComoNombre);
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
        private static int Comparer(eFact_R.Entidades.Lote x, eFact_R.Entidades.Lote y)
        {
            return x.IdLote.CompareTo(y.IdLote);
        }

        public List<eFact_R.Entidades.Lote> SortListaLotes(List<eFact_R.Entidades.Lote> lLotes)
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
                    eFact_R.Entidades.Lote l = new eFact_R.Entidades.Lote();
                    List<eFact_R.Entidades.Lote> llotes = new List<eFact_R.Entidades.Lote>();
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
                        eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
                        lote = llotes[i];
                        List<CedEntidades.Evento> eventosposibles = new List<CedEntidades.Evento>();
                        eventosposibles = lote.WF.EventosPosibles.FindAll((delegate(CedEntidades.Evento e1) { return e1.IdEstadoDsd.IdEstado.ToString() == "PteEnvio"; }));
                        if (eventosposibles.Count == 0)
                        {
                            MessageBox.Show("Imposible enviar el lote: " + lote.NumeroLote + " en el estado actual.", "Envio de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            break;
                        }
                        FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                        eFact_R.RN.Lote.DeserializarLc(out lc, lote, false);

                        //Antes de ejecutar el envio a Interfacturas, cambiar el estado.
                        EjecutarEventoBandejaS("EnviarAIF", "", lote);
                        //Actualizar el WF del lote.
                        eFact_R.RN.Lote.Leer(lote, Aplicacion.Sesion);

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
                            eFact_R.Entidades.Vendedor v = Aplicacion.Vendedores.Find(delegate(eFact_R.Entidades.Vendedor e1) { return e1.CuitVendedor == lc.cabecera_lote.cuit_vendedor.ToString(); });
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
                            EjecutarEventoBandejaS("RegRechIF", ex2.Message.Replace(Convert.ToChar("'"),Convert.ToChar(" ")).ToString(), lote);
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
                        eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
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

        private void EjecutarEventoBandejaS(string IdEvento, string Comentario, eFact_R.Entidades.Lote lote)
        {
            CedEntidades.Evento evento = new CedEntidades.Evento();
            evento.Id = IdEvento;
            evento.Flow.IdFlow = "eFact";
            evento.Flow.DescrFlow = "Facturación Electrónica";
            evento.Comentario = Comentario;
            Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion);
            eFact_R.RN.Lote.VerificarEnviosPosteriores(false, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, eFact_R.Aplicacion.Sesion);
            eFact_R.RN.Lote.Ejecutar(lote, evento, "", Aplicacion.Sesion);
            RefreshBandejaSalida();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (BandejaSDataGridView.SelectedRows.Count != 0)
                {
                    eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
                    int renglon = BandejaSDataGridView.SelectedRows[0].Index;
                    lote = dtBandejaSalida[renglon];
                    ConsultaLote cl = new ConsultaLote(lote);
                    cl.ShowDialog();
                    cl = null;
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
            TipoConsulta = eFact_R.RN.Tablero.TipoConsulta.FechaEnvio;
        }

        private void FechaAltaLoteRadioButton_Click(object sender, EventArgs e)
        {
            TipoConsulta = eFact_R.RN.Tablero.TipoConsulta.FechaAlta;
        }

        private void ArchivoOKRadioButton_Click(object sender, EventArgs e)
        {
            ArchivosOtrosFiltros = eFact_R.RN.Archivo.OtrosFiltros.OK;
        }

        private void ArchivosNotOKRadioButton_Click(object sender, EventArgs e)
        {
            ArchivosOtrosFiltros = eFact_R.RN.Archivo.OtrosFiltros.NotOk;
        }

        private void OtrosFiltrosBandejaECheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                OtrosFiltrosBandejaEPanel.Enabled = true;
                ArchivosOtrosFiltros = eFact_R.RN.Archivo.OtrosFiltros.OK;
            }
            else
            {
                OtrosFiltrosBandejaEPanel.Enabled = false;
                ArchivosOtrosFiltros = eFact_R.RN.Archivo.OtrosFiltros.SinAplicar;
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
                        c = null;
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
                TipoConsultaArchivos = eFact_R.RN.Tablero.TipoConsultaArchivos.FechaCreacion;
            }
            else
            {
                TipoConsultaArchivos = eFact_R.RN.Tablero.TipoConsultaArchivos.FechaProceso;
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
                        ExportarItfOrigComboBox.Items.Clear();
                        ExportarItfOrigComboBox.Items.Add("( Elegir una opción para exportar itf Orig. )");
                        ExportarItfOrigComboBox.Items.Add("Exportar en formato TXT");
                        ExportarItfOrigComboBox.Items.Add("Exportar en formato XML");
                        ExportarItfOrigComboBox.SelectedIndex = 0;
                        ExportarItfRespIFComboBox.Items.Clear();
                        ExportarItfRespIFComboBox.Items.Add("( Elegir una opción para exportar itf c/Resp. AFIP )");
                        if (dtBandejaSalida[renglon].WF.IdEstado == "AceptadoAFIP")
                        {
                            ExportarItfRespIFComboBox.Items.Add("Exportar en formato TXT con respuesta AFIP");
                            ExportarItfRespIFComboBox.Items.Add("Exportar en formato XML con respuesta AFIP");
                        }
                        ExportarItfRespIFComboBox.SelectedIndex = 0;
                        EventosComboBox.Select();
                        break;
                    default:
                        ExportarItfOrigComboBox.Items.Clear();
                        ExportarItfOrigComboBox.Items.Add("( Elegir una opción para exportar itf Orig. )");
                        ExportarItfOrigComboBox.Items.Add("Exportar en formato TXT");
                        ExportarItfOrigComboBox.Items.Add("Exportar en formato XML");
                        ExportarItfOrigComboBox.SelectedIndex = 0;
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

            ExportarItfRespIFComboBox.Items.Clear();
            ExportarItfRespIFComboBox.Items.Add("( Elegir una opción para exportar itf c/Resp.AFIP )");
            // Determinacion de eventos (XLote) comunes a todas las 
            // operaciones seleccionadas
            List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
            List<CedEntidades.Evento> eventosXLoteAux = new List<CedEntidades.Evento>();
            CedEntidades.Evento evento = new CedEntidades.Evento();
            evento.Id = "(ElegirAccion)";
            evento.Descr = "( Eligir una acción )";
            eventosXLote.Add(evento);
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
                        ExportarItfRespIFComboBox.Items.Add("Exportar en formato TXT con respuesta AFIP");
                        ExportarItfRespIFComboBox.Items.Add("Exportar en formato XML con respuesta AFIP");
                    }
                }
            }
            ExportarItfRespIFComboBox.SelectedIndex = 0;
            // Botones X Lote
            EventosComboBox.DataSource = eventosXLote;
            EventosComboBox.DisplayMember = "Descr"; //TextoAccion + " todas las seleccionadas"
            EventosComboBox.ValueMember = "Id";
        }

        private void EventosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
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
                    ExportarItfOrigComboBox.Enabled = false;
                    ExportarItfRespIFComboBox.Enabled = false;
                    if (BandejaSDataGridView.SelectedRows.Count != 0)
                    {
                        for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
                        {
                            int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                            eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
                            lote = dtBandejaSalida[renglon];
                            string archivoProcesado = "";
                            bool IF = false;
                            if (((ComboBox)sender).Text.IndexOf("AFIP") != -1)
                            {
                                IF = true;
                            }
                            if (((ComboBox)sender).Text.IndexOf("TXT") != -1)
                            {
                                eFact_R.RN.Lote.GuardarItfTXT(out archivoProcesado, lote, "ITF", Aplicacion.ArchPathItf, IF);
                            }
                            else
                            {
                                eFact_R.RN.Lote.GuardarItfXML(out archivoProcesado, lote, "ITF", Aplicacion.ArchPathItf, IF);
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
                ExportarItfOrigComboBox.Enabled = true;
                ExportarItfRespIFComboBox.Enabled = true;
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
            Cedeira.UI.Mostrar.Acerca(sistema, codigoSistema, "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor, 0);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            string NombreArchAyuda = @System.Configuration.ConfigurationManager.AppSettings["NombreArchAyuda"];
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\" + NombreArchAyuda);
        }
    }
}