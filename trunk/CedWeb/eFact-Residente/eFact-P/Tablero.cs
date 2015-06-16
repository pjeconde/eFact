using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using eFact_R;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace eFact_P
{
    public partial class Tablero : Form
    {
        public List<FeaEntidades.InterFacturas.comprobante_listado> dtBandejaEntrada = new List<FeaEntidades.InterFacturas.comprobante_listado>();
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
            CuitCompradorTextBox.Text = Aplicacion.Vendedores[2].CuitVendedor;

            TipoComprobanteComboBox.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();
            TipoComprobanteComboBox.DisplayMember = "Descr";
            TipoComprobanteComboBox.ValueMember = "Codigo";
            TipoComprobanteComboBox.SelectedIndex = -1;

            VerificarServicio();
        }

        private void Tablero_Load(object sender, EventArgs e)
        {
            FechaProcesoPanel.Enabled = false;

            ActualizarBandejaE();
            BandejaEDataGridView.Refresh();
        }

        private void VerificarServicio()
        {
        }

        private void ActualizarBandejaEButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ActualizarBandejaEButton.Enabled = false;
                ActualizarBandejaE();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                ActualizarBandejaEButton.Enabled = true;
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ActualizarBandejaE()
        {
            VerificarServicio();
            eFact_RN.IBKP.error[] respErroresListadoComprobantes = new eFact_RN.IBKP.error[0];
            List<FeaEntidades.InterFacturas.comprobante_listado> lcIBK = new List<FeaEntidades.InterFacturas.comprobante_listado>();
            eFact_RN.IBKP.consulta_listado_comprobante clc = new eFact_RN.IBKP.consulta_listado_comprobante();
            try
            {
                clc.cod_interno_canal = "";
                clc.cuit_canal = Convert.ToInt64(@System.Configuration.ConfigurationManager.AppSettings["CuitCanal"]);
                clc.cuit_vendedor = Convert.ToInt64("20225018805");
                clc.cuit_vendedorSpecified = true;
                if (PuntoVentaTextBox.Text != "")
                {
                    clc.punto_de_venta = Convert.ToInt32(PuntoVentaTextBox.Text);
                }
                if (NumeroComprobanteTextBox.Text != "")
                {
                    clc.numero_comprobante_desde = Convert.ToInt32(NumeroComprobanteTextBox.Text);
                    clc.numero_comprobante_hasta = Convert.ToInt32(NumeroComprobanteTextBox.Text);
                }
                if (TipoComprobanteComboBox.SelectedValue != null && TipoComprobanteComboBox.SelectedValue.ToString() != "-1")
                {
                    clc.tipo_de_comprobante = Convert.ToInt32(TipoComprobanteComboBox.SelectedValue);
                }
                clc.tipo_doc_comprador = Convert.ToInt32("80");
                clc.doc_comprador = Convert.ToInt64(CuitCompradorTextBox.Text);
                eFact_RN.Comprobante cc = new eFact_RN.Comprobante();
                lcIBK = cc.ConsultarListadoIBKP(clc, "012f0775357c");
                BandejaEDataGridView.DataSource = lcIBK;
                BandejaEDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                //RespErroresLote = respErroresLote;
                //RespErroresComprobantes = respErroresComprobantes;
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }

        private void ActualizarBandejaS()
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            DateTime FechaDsd;
            DateTime FechaHst;
            VerificarServicio();
            
            List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
            InicializarEventosComboBox(out eventosXLote);

            ExportarItfComboBox.Items.Clear();
            ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
            ExportarItfComboBox.SelectedIndex = 0;
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
        //private eFact_RN.IBK.lote_response ArmarLoteResponse(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        //{
        //    string texto = "";
        //    eFact_RN.IBK.lote_response lrCompleto = new eFact_RN.IBK.lote_response();
        //    eFact_RN.IBK.error[] errores = new eFact_RN.IBK.error[1];
        //    lrCompleto.cantidad_reg = Lc.cabecera_lote.cantidad_reg;
        //    lrCompleto.cuit_canal = Lc.cabecera_lote.cuit_canal;
        //    lrCompleto.cuit_vendedor = Lc.cabecera_lote.cuit_vendedor;
        //    lrCompleto.estado = Lc.cabecera_lote.resultado;
        //    lrCompleto.fecha_envio_lote = Lc.cabecera_lote.fecha_envio_lote;
        //    lrCompleto.id_lote = Lc.cabecera_lote.id_lote;
        //    lrCompleto.presta_serv = Lc.cabecera_lote.presta_serv;
        //    lrCompleto.presta_servSpecified = Lc.cabecera_lote.presta_servSpecified;
        //    lrCompleto.punto_de_venta = Lc.cabecera_lote.punto_de_venta;
        //    if (Lc.cabecera_lote.motivo != null && Lc.cabecera_lote.motivo.Trim() != "00" && Lc.cabecera_lote.motivo.Trim() != "")
        //    {
        //        errores[0] = new eFact_RN.IBK.error();
        //        errores[0].codigo_error = 0;
        //        errores[0].descripcion_error = Lc.cabecera_lote.motivo.Trim();
        //        lrCompleto.errores_lote = errores;
        //    }
        //    int CantMotivoError = 0;
        //    for (int i = 0; i < Lc.comprobante.Length; i++)
        //    {
        //        if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
        //        {
        //            CantMotivoError++;
        //        }
        //    }
        //    int NroMotivo = 0;
        //    for (int i = 0; i < Lc.comprobante.Length; i++)
        //    {
        //        eFact_RN.IBK.error[] erroresComprobante = new eFact_RN.IBK.error[1];
        //        if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "00" && Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() != "")
        //        {
        //            if (lrCompleto.comprobante_response == null)
        //            {
        //                lrCompleto.comprobante_response = new eFact_RN.IBK.comprobante_response[CantMotivoError];
        //            }
        //            erroresComprobante[NroMotivo] = new eFact_RN.IBK.error();
        //            erroresComprobante[NroMotivo].codigo_error = 0;
        //            erroresComprobante[NroMotivo].descripcion_error = Lc.comprobante[i].cabecera.informacion_comprobante.motivo;
        //            lrCompleto.comprobante_response[NroMotivo] = new eFact_RN.IBK.comprobante_response();
        //            lrCompleto.comprobante_response[NroMotivo].numero_comprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
        //            lrCompleto.comprobante_response[NroMotivo].punto_de_venta = Lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
        //            lrCompleto.comprobante_response[NroMotivo].tipo_de_comprobante = Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
        //            lrCompleto.comprobante_response[NroMotivo].estado = Lc.comprobante[i].cabecera.informacion_comprobante.resultado;
        //            lrCompleto.comprobante_response[NroMotivo].errores_comprobante = erroresComprobante;
        //            NroMotivo++;
        //        }
        //    }
        //    return lrCompleto;
        //}
        
        private void DescartarBandejaEButton_Click(object sender, EventArgs e)
        {
        }
        
        private void LimpiarBandejaEntrada()
        {
            dtBandejaEntrada = new List<FeaEntidades.InterFacturas.comprobante_listado>();
            BandejaEDataGridView.DataSource = new List<FeaEntidades.InterFacturas.comprobante_listado>();
            BandejaEDataGridView.Refresh();
        }

        private void RefreshBandejaSalida()
        {
        }

        private void EnviarABandejaSButton_Click(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            VerificarServicio();
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
        }

        private void EventosWF(string Evento)
        {
            try
            {
                //Cursor = System.Windows.Forms.Cursors.WaitCursor;
                //EventosComboBox.Enabled = false;
                //if (BandejaSDataGridView.SelectedRows.Count != 0)
                //{
                //    for (int i = 0; i < BandejaSDataGridView.SelectedRows.Count; i++)
                //    {
                //        eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                //        int renglon = BandejaSDataGridView.SelectedRows[i].Index;
                //        lote = dtBandejaSalida[renglon];
                //        EjecutarEventoBandejaS(Evento, "", lote);
                //    }
                //}
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
            //CedEntidades.Evento evento = new CedEntidades.Evento();
            //evento.Id = IdEvento;
            //evento.Flow.IdFlow = "eFact";
            //evento.Flow.DescrFlow = "Facturación Electrónica";
            //evento.Comentario = Comentario;
            //Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion);
            //eFact_RN.Lote.VerificarEnviosPosteriores(false, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, eFact_R.Aplicacion.Sesion);
            //eFact_RN.Lote.Ejecutar(lote, evento, "", Aplicacion.Aplic, Aplicacion.Sesion);
            //RefreshBandejaSalida();
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
                ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.OK;
            }
            else
            {
                ArchivosOtrosFiltros = eFact_Entidades.Archivo.OtrosFiltros.SinAplicar;
            }
        }

        private void ArchivosAProcesar_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && ((RadioButton)sender).Name == "ComprobantesEnLineaRadioButton")
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
                    Cursor = System.Windows.Forms.Cursors.Default;
                }
                FechaProcesoPanel.Enabled = false;
            }
            else
            {
                LimpiarBandejaEntrada();
                FechaProcesoPanel.Enabled = true;
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

        //private void ConfigBotonesEventosXLote()
        //{
        //    ExportarItfComboBox.Items.Clear();
        //    ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
        //    ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML");
        //    // Determinacion de eventos (XLote) comunes a todas las 
        //    // operaciones seleccionadas
        //    List<CedEntidades.Evento> eventosXLoteAux = new List<CedEntidades.Evento>();
        //    List<CedEntidades.Evento> eventosXLote = new List<CedEntidades.Evento>();
        //    InicializarEventosComboBox(out eventosXLote);
        //    for (int i = 0; i < BandejaEDataGridView.SelectedRows.Count; i++)
        //    {
        //        //string a = BandejaSDataGridView.SelectedRows[i].Cells["Repositorio"].Value.ToString();
        //        //Mep mep = new Mep(a, Convert.ToInt32(BandejaSDataGridView.SelectedRows[i].Cells["IdOp"].Value), Aplicacion.Sesion);
        //        int renglon = BandejaEDataGridView.SelectedRows[i].Index;
        //        if (i == 0)
        //        {
        //            eventosXLoteAux = dtBandejaSalida[renglon].WF.EventosXLotePosibles;
        //            eventosXLote.AddRange(eventosXLoteAux);
        //        }
        //        else
        //        {
        //            List<CedEntidades.Evento> eventosXLoteCHK = new List<CedEntidades.Evento>();
        //            eventosXLoteCHK = dtBandejaEntrada[renglon].WF.EventosXLotePosibles;
        //            bool ExportarRespAFIPXLote = true;
        //            for (int k = 0; k < eventosXLoteAux.Count; k++)
        //            {
        //                if (eventosXLoteCHK.FindAll((delegate(CedEntidades.Evento e1) { return e1.Id == eventosXLoteAux[k].Id; })).Count == 0)
        //                {
        //                    eventosXLote.Remove(eventosXLoteAux[k]);
        //                }
        //                if (dtBandejaEntrada[renglon].WF.IdEstado != "AceptadoAFIP")
        //                {
        //                    ExportarRespAFIPXLote = false;
        //                }
        //            }
        //            if (ExportarRespAFIPXLote)
        //            {
        //                ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato TXT");
        //                ExportarItfComboBox.Items.Add("Exportar archivo con respuesta AFIP en formato XML");
        //            }
        //        }
        //    }
        //    ExportarItfComboBox.SelectedIndex = 0;
        //    EventosComboBox.DataSource = eventosXLote;
        //}

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
                //if (((ComboBox)sender).SelectedIndex != 0)
                //{
                //    Cursor = System.Windows.Forms.Cursors.WaitCursor;
                //    ExportarItfComboBox.Enabled = false;
                //    if (BandejaEDataGridView.SelectedRows.Count != 0)
                //    {
                //        for (int i = 0; i < BandejaEDataGridView.SelectedRows.Count; i++)
                //        {
                //            int renglon = BandejaEDataGridView.SelectedRows[i].Index;
                //            eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                //            lote = dtBandejaEntrada[renglon];
                //            string archivoProcesado = "";
                //            bool IF = false;
                //            if (((ComboBox)sender).SelectedIndex == 4 || ((ComboBox)sender).SelectedIndex == 5)
                //            {
                //                IF = true;
                //            }
                //            // 1 y 4 archivos TXT 
                //            // 2, 3 y 5 archivos XML  
                //            if (((ComboBox)sender).SelectedIndex == 1 || ((ComboBox)sender).SelectedIndex == 4)
                //            {
                //                eFact_RN.Lote.GuardarItfTXT(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF);
                //            }
                //            else
                //            {
                //                if (((ComboBox)sender).SelectedIndex == 3)
                //                {
                //                    eFact_RN.Lote.GuardarItfXML(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF, true);
                //                }
                //                else
                //                {
                //                    eFact_RN.Lote.GuardarItfXML(out archivoProcesado, lote, "ITF", Aplicacion.Aplic.ArchPathItf, IF, false);
                //                }
                //            }
                //            MessageBox.Show("Interface generada satisfactoriamente con el nombre: " + archivoProcesado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        }
                //    }
                //}
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
                if (BandejaEDataGridView.SelectedRows.Count != 0)
                {
                    FeaEntidades.InterFacturas.comprobante_listado lote = new FeaEntidades.InterFacturas.comprobante_listado();
                    int renglon = BandejaEDataGridView.SelectedRows[0].Index;
                    //lote = dtBandejaEntrada[renglon];
                    //ConsultaLote cl = new ConsultaLote(lote, ConsultaLote.Modo.Consulta);
                    //cl.ShowDialog();
                    //cl.Dispose();
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
                        eFact_R.BarraEstado c = new eFact_R.BarraEstado();
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

        private void menuItem5_Click(object sender, EventArgs e)
        {

        }

        private void BandejaEDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EventosComboBox.Enabled = false;
                switch (BandejaEDataGridView.SelectedRows.Count)
                {
                    case 0:
                        break;
                    case 1:
                        //int renglon = BandejaEDataGridView.SelectedRows[0].Index;
                        //List<CedEntidades.Evento> leventos = new List<CedEntidades.Evento>();
                        //CedEntidades.Evento evento = new CedEntidades.Evento();
                        //evento.Id = "(ElegirAccion)";
                        //evento.Descr = "( Eligir una acción )";
                        //leventos.Add(evento);
                        //List<CedEntidades.Evento> leventosAux = dtBandejaEntrada[renglon].WF.EventosPosibles.FindAll((delegate(CedEntidades.Evento e1) { return e1.Automatico == false; }));
                        //leventos.AddRange(leventosAux);
                        //EventosComboBox.DataSource = leventos;
                        //EventosComboBox.DisplayMember = "Descr";
                        //EventosComboBox.ValueMember = "Id";
                        ////Armado de ComboBox con las opciones de exportar con respuesta IF.
                        //ExportarItfComboBox.Items.Clear();
                        //ExportarItfComboBox.Items.Add("( Elegir una opción para Exportar )");
                        //ExportarItfComboBox.Items.Add("Exportar archivo original en formato XML");
                        //ExportarItfComboBox.SelectedIndex = 0;
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

        private void NumeroLoteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FechaAltaHstBandejaEDTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BandejaEDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (BandejaEDataGridView.SelectedRows.Count != 0)
            {
                eFact_RN.IBKP.error[] respErroresComprobantes = new eFact_RN.IBKP.error[0];
                FeaEntidades.InterFacturas.comprobante cIBK = new FeaEntidades.InterFacturas.comprobante();
                eFact_RN.IBKP.consulta_detalle_comprobante cdc = new eFact_RN.IBKP.consulta_detalle_comprobante();
                try
                {
                    cdc.cod_interno_canal = "";
                    cdc.cuit_canal = Convert.ToInt64(@System.Configuration.ConfigurationManager.AppSettings["CuitCanal"]);
                    cdc.cuit_vendedor = Convert.ToInt64(BandejaEDataGridView.Rows[BandejaEDataGridView.SelectedRows[0].Index].Cells["cuit_vendedor"].Value.ToString());
                    cdc.punto_de_venta = Convert.ToInt32(BandejaEDataGridView.Rows[BandejaEDataGridView.SelectedRows[0].Index].Cells["punto_de_venta"].Value.ToString());
                    cdc.numero_comprobante = Convert.ToInt32(BandejaEDataGridView.Rows[BandejaEDataGridView.SelectedRows[0].Index].Cells["numero_comprobante"].Value.ToString());
                    cdc.tipo_de_comprobante = Convert.ToInt32(BandejaEDataGridView.Rows[BandejaEDataGridView.SelectedRows[0].Index].Cells["tipo_de_comprobante"].Value.ToString());
                    cdc.tipo_doc_comprador = Convert.ToInt32("80");
                    cdc.doc_comprador = Convert.ToInt64(CuitCompradorTextBox.Text);
                    cdc.usuario_consulta = Aplicacion.Sesion.Usuario.IdUsuario;
                    eFact_RN.Comprobante cc = new eFact_RN.Comprobante();
                    cIBK = cc.ConsultarIBKP(cdc, "012f0775357c");
                    //lcIBK = eFact_RNComprobante.ConsultarIBK(out respErroresLote, out respErroresComprobantes, clc, WSCertificado);
                    //RespErroresLote = respErroresLote;
                    //RespErroresComprobantes = respErroresComprobantes;
                }
                catch (Exception ex)
                {
                    //RespErroresLote = respErroresLote;
                    //RespErroresComprobantes = respErroresComprobantes;
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                }
            }
        }
    }
}