using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Globalization;
using System.Web.Mail;
using System.Threading; 

namespace eFact_S
{
    public partial class Service1 : ServiceBase
    {
        private string NombrePC;
        private eFact_Entidades.Aplicacion Aplicacion;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            NombrePC = "";
            try
            {
                NombrePC = System.Environment.MachineName;
            }
            catch
            {
            }
            string body = "Vacío";
            string subject = NombrePC + " Inicio del servicio eFact-S a las " + System.DateTime.Now.ToLongTimeString();
            subject = subject + " Versión:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailMessage mail;
            mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar", System.Configuration.ConfigurationManager.AppSettings["MailTest"], subject, body);
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
            string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
            string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
            smtpClient.Host = MailServidorSmtp;
            if (MailCredencialesUsr != "")
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
            }
            smtpClient.Send(mail);
        }

        protected override void OnStop()
        {
            string body = "Vacío";
            string subject = NombrePC + " Parada del servicio eFact-S a las " + System.DateTime.Now.ToLongTimeString();
            subject = subject + " Versión:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailMessage mail;
            mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar", System.Configuration.ConfigurationManager.AppSettings["MailTest"], subject, body);
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
            string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
            string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
            smtpClient.Host = MailServidorSmtp;
            if (MailCredencialesUsr != "")
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
            }
            smtpClient.Send(mail);
        }
        
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try 
            {
                timer1.Stop();
                NombrePC = System.Environment.MachineName;
                Inicializar();

                //Actualizar Estado AFIP de los Lotes Ptes de Respuesta.
                ActualizarEstadoAFIPLotes();

                //Enviar a Interfacturas Lotes Ptes de Envío.
                EnviarAIFLotesPtesDeEnvio();

                string[] files = Directory.GetFiles(Aplicacion.ArchPath, "*.*");
                List<eFact_Entidades.Archivo> Archivos = new List<eFact_Entidades.Archivo>();
                foreach (string d in files)
                {
                    FileInfo ArchFileInfo = new FileInfo(d);
                    try
                    {
                        eFact_Entidades.Archivo archivo = new eFact_Entidades.Archivo();
                        ActualizarBandejaEntrada(archivo, ArchFileInfo, Aplicacion.Sesion);
                        Archivos.Add(archivo);
                    }
                    catch (Exception ex)
                    {
                        Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                    }
                }
                Archivos.Sort(ordenarPorNombre);
                foreach (eFact_Entidades.Archivo elem in Archivos)
                {
                    string NombreArchivo = elem.Nombre;
                    string FechaTexto = DateTime.Now.ToString("yyyyMMdd-hhmmss");
                    string ArchGuardarComoNombre = "";
                    eFact_RN.Engine.GenerarNombreArch(out ArchGuardarComoNombre, "", NombreArchivo);
                    //--------------------------------------
                    //Procesar el archivo seleccionado.
                    try
                    {
                        eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                        eFact_RN.Archivo.Procesar(out lote, elem, Aplicacion, Aplicacion.Sesion);
                        //Agregar datos del proceso a la entidad Archivo
                        ArchGuardarComoNombre = "BAK-" + ArchGuardarComoNombre;
                        elem.NombreProcesado = ArchGuardarComoNombre;
                        elem.FechaProceso = DateTime.Now;
                        string handler = eFact_RN.Archivo.Insertar(elem, true, Aplicacion.Sesion);
                        //Ejecutar el insert local del "Lote".
                        CedEntidades.Evento evento = new CedEntidades.Evento();
                        evento.Id = "EnvBandSalida";
                        evento.Flow.IdFlow = "eFact";
                        evento.Flow.DescrFlow = "Facturación Electrónica";
                        Cedeira.SV.WF.LeerEvento(evento, Aplicacion.Sesion); 
                        lote.WF = Cedeira.SV.WF.Nueva("eFact", "FactServ", 0, "Facturacion Electrónica", Aplicacion.Sesion);
                        eFact_RN.Lote.VerificarEnviosPosteriores(true, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, Aplicacion.Sesion);
                        //Generar nombre de archivo procesado para ser enviado al histórico.
                        eFact_RN.Lote.Ejecutar(lote, evento, handler, Aplicacion, Aplicacion.Sesion);

                        //Leer el Lote procesado.
                        eFact_RN.Lote.Leer(lote, Aplicacion.Sesion);

                        //Enviar el Lote a IF.
                        EnviarAIF(lote);
                    }
                    catch (Exception ex)
                    {
                        Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                        elem.Comentario = ex.Message;
                        if (ex.InnerException != null)
                        {
                            elem.Comentario += "\r\n" + ex.InnerException.Message;
                        }
                        if (ex.StackTrace != null)
                        {
                            string st = ex.StackTrace;
                            if (st.Length > 2000)
                            {
                                st = st.Substring(0, 2000);
                            }
                            elem.Comentario += "\r\n\r\n" + st;
                        }
                        //Agregar datos del proceso a la entidad Archivo
                        ArchGuardarComoNombre = "ERR-" + ArchGuardarComoNombre;
                        elem.NombreProcesado = ArchGuardarComoNombre;
                        elem.FechaProceso = DateTime.Now;
                        eFact_RN.Archivo.Insertar(elem, false, Aplicacion.Sesion);
                    }
                    
                    //Remover archivo ----------------------
                    Directory.Move(Aplicacion.ArchPath + "\\" + NombreArchivo, Aplicacion.ArchPathHis + ArchGuardarComoNombre);
                    //--------------------------------------

                    //Solo procesa un archivo y sale, para poder recibir posteriormente la respuesta AFIP. 
                    //Cuando se vuelve a iniciar el timer de servicio se ejecuta la funcion "ActualizarEstadoAFIPLotes()".
                    break;
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                timer1.Start();
            }
        }
        private static int ordenarPorFecha(eFact_Entidades.Archivo A1, eFact_Entidades.Archivo A2)
        {
            return A1.FechaModificacion.CompareTo(A2.FechaModificacion);
        }
        private static int ordenarPorNombre(eFact_Entidades.Archivo A1, eFact_Entidades.Archivo A2)
        {
            return A1.Nombre.CompareTo(A2.Nombre);
        }
        private void EnviarAIFLotesPtesDeEnvio()
        {
            try
            {
                //Leer el Lote procesado.
                List<eFact_Entidades.Lote> lotesPtesDeEnvio = new List<eFact_Entidades.Lote>();
                eFact_RN.Lote.ConsultarXEstado(out lotesPtesDeEnvio, "'PteEnvio'", Aplicacion.Sesion);
                foreach (eFact_Entidades.Lote l in lotesPtesDeEnvio)
                {
                    //Enviar el Lote a IF.
                    EnviarAIF(l);
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void ActualizarEstadoAFIPLotes()
        {
            List<eFact_Entidades.Lote> lotes = new List<eFact_Entidades.Lote>();
            eFact_RN.Tablero.ActualizarBandejaSalida(out lotes, eFact_Entidades.Lote.TipoConsulta.SinAplicarFechas, Convert.ToDateTime("01/01/1980"), Convert.ToDateTime("31/12/2064"), "", "", "", false, Aplicacion.Sesion);
            //Verificar Ptes.Respuesta AFIP.
            List<eFact_Entidades.Lote> lotesFind = lotes.FindAll((delegate(eFact_Entidades.Lote e1) { return e1.WF.IdEstado == "PteRespAFIP"; }));
            foreach (eFact_Entidades.Lote l in lotesFind)
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
        }
        private string ArmarTextoMotivo(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            string texto = "";
            if (Lc.cabecera_lote.resultado == "A" || Lc.cabecera_lote.resultado == "R" || Lc.cabecera_lote.resultado == "O" || Lc.cabecera_lote.resultado == "P")
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
                        int renglon = i + 1;
                        string resultado = "";
                        if (Lc.comprobante[i].cabecera.informacion_comprobante != null)
                        {
                            resultado = Lc.comprobante[i].cabecera.informacion_comprobante.resultado + " ";
                        }
                        texto += "Código de problema a nivel comprobante ( renglon " + renglon.ToString() + "): " + resultado + Lc.comprobante[i].cabecera.informacion_comprobante.motivo.Trim() + " " + descrCodigosErrorAFIPComprobante + "\r\n";
                    }
                }
            }
            return texto;
        }
        private void Inicializar()
        {
            CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
            cedeiraCultura.DateTimeFormat = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
            Thread.CurrentThread.CurrentCulture = cedeiraCultura;

            System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
            auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"]);

            Aplicacion = eFact_RN.Aplicacion.Crear();

            string Usuario = System.Environment.UserName;
            string Dominio = System.Environment.UserDomainName;
            eFact_RN.Sesion.Crear(Usuario, "", Dominio, auxCnn.ToString(), "", "Servicio", Aplicacion.Version, Aplicacion.VersionParaControl, Aplicacion.Sesion);
            if (Aplicacion.Sesion == null)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException("Problemas para crear la sesion de trabajo");
            }
            
            eFact_RN.Vendedor.Consultar(Aplicacion.Vendedores, Aplicacion.Sesion);
        }
        private static void ActualizarBandejaEntrada(eFact_Entidades.Archivo Archivo, FileInfo ArchFileInfo, CedEntidades.Sesion Sesion)
        {
            Archivo.Nombre = ArchFileInfo.Name;
            Archivo.Path = ArchFileInfo.DirectoryName;
            Archivo.Tipo = ArchFileInfo.Extension;
            Archivo.FechaCreacion = ArchFileInfo.CreationTime;
            Archivo.FechaModificacion = ArchFileInfo.LastWriteTime;
            Archivo.Tamaño = ArchFileInfo.Length;
            Archivo.TamañoUMedida = "KB";
            Archivo.IdUsuario = Sesion.Usuario.IdUsuario;
        }
        private void EnviarAIF(eFact_Entidades.Lote Lote)
        {
            try
            {
                //Envio del lote a IF
                eFact_Entidades.Lote lote = new eFact_Entidades.Lote();
                lote = Lote;
                List<CedEntidades.Evento> eventosposibles = new List<CedEntidades.Evento>();
                eventosposibles = lote.WF.EventosPosibles.FindAll((delegate(CedEntidades.Evento e1) { return e1.IdEstadoDsd.IdEstado.ToString() == "PteEnvio"; }));
                if (eventosposibles.Count == 0)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.ProcesarArchivo("Imposible enviar el lote: " + lote.NumeroLote + " en el estado actual.");
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
                    }
                    eFact_RN.Lote.ActualizarDatosError(lote, Lr);
                    edescr = ex2.Message.Replace("'", "''");
                    EjecutarEventoBandejaS("RegRechIF", edescr, lote);
                    //Va a revertir el rechazo (si el error es "Timed Out" hasta 10 ocurrencias.
                    if (Lr.estado == "99" && Lr.errores_lote[0].descripcion_error.ToUpper().Trim() == "THE OPERATION HAS TIMED OUT")
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
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
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
            eFact_RN.Lote.VerificarEnviosPosteriores(false, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, lote.NumeroEnvio, Aplicacion.Sesion);
            eFact_RN.Lote.Ejecutar(lote, evento, "", Aplicacion, Aplicacion.Sesion);
        }
        private CedWebRN.IBK.lote_response ArmarLoteResponse(FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            string texto = "";
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
            if (Lc.cabecera_lote.motivo.Trim() != "00" && Lc.cabecera_lote.motivo.Trim() != "")
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
    }
}
