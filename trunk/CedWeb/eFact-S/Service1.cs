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
            Inicializar();
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
                Archivos.Sort(ordenarPorFecha);
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
                        //Agregar datos del proceso a la entidad Archivo
                        ArchGuardarComoNombre = "ERR-" + ArchGuardarComoNombre;
                        elem.NombreProcesado = ArchGuardarComoNombre;
                        elem.FechaProceso = DateTime.Now;
                        eFact_RN.Archivo.Insertar(elem, false, Aplicacion.Sesion);
                    }
                    //Remover archivo ----------------------
                    Directory.Move(Aplicacion.ArchPath + "\\" + NombreArchivo, Aplicacion.ArchPathHis + ArchGuardarComoNombre);
                    //--------------------------------------
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
        private void Inicializar()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
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
    }
}
