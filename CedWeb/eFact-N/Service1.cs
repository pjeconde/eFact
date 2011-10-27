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
using System.Data.OleDb;

namespace eFact_N
{
    public partial class Service1 : ServiceBase
    {
        private string NombrePC;
        private eFact_Entidades.Aplicacion Aplicacion;
        private List<eFact_Entidades.Lote> lotes;

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
                string body = "Vacío";
                string subject = NombrePC + " Inicio del servicio eFact-N a las " + System.DateTime.Now.ToLongTimeString();
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
            catch
            {
            }
        }

        protected override void OnStop()
        {
            NombrePC = "";
            try
            {
                NombrePC = System.Environment.MachineName;
                string body = "Vacío";
                string subject = NombrePC + " Parada del servicio eFact-N a las " + System.DateTime.Now.ToLongTimeString();
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
            catch
            {
            }
        }
        
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try 
            {
                timer1.Stop();
                NombrePC = System.Environment.MachineName;

                CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                Thread.CurrentThread.CurrentCulture = cedeiraCultura;

                //Solo la primera vez inicia la sesion
                if (Aplicacion == null)
                {
                    Inicializar();
                }

                //Buscar novedades en eFact-R.
                ConsultarNovedades(out lotes);
                //Actualizar DB2.
                ActualizarDB2(lotes);
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

        private void ConsultarNovedades(out List<eFact_Entidades.Lote> lotes)
        {
            eFact_RN.Lote.ConsultarNovedades(out lotes, Aplicacion.Sesion);
        }
        private void ActualizarDB2(List<eFact_Entidades.Lote> lotes)
        {
            foreach (eFact_Entidades.Lote lote in lotes)
            {
                string fecha = DateTime.Now.ToString("yyyyMMdd");
                string hora = DateTime.Now.ToString("HHmmss");
                OleDbCommand myCommand;
                OleDbConnection cn;
                string myInsertQueryOK;
                string myInsertQueryER;

                eFact_Entidades.Novedades novedad = new eFact_Entidades.Novedades();
                novedad.CuitVendedor = lote.CuitVendedor;
                novedad.IdLote = lote.IdLote;
                novedad.NumeroEnvio = lote.NumeroEnvio;
                novedad.PuntoVenta = lote.PuntoVenta;
                novedad.IdLog = lote.WF.Log[lote.WF.Log.Count - 1].IdLog;
                novedad.IdOp = lote.IdOp;
                novedad.NumeroLote = lote.NumeroLote;
                novedad.IdEstado = lote.IdEstado;
                novedad.Comentario = lote.WF.Log[lote.WF.Log.Count - 1].Comentario;
                novedad.FechaAlta = DateTime.Now;
                novedad.CantidadRegistros = lote.Comprobantes.Count;
                eFact_RN.Lote.GuardarNovedades(novedad, Aplicacion.Sesion);

                string errorSoloXMail = "";
                if (lote.WF.IdEstado == "AceptadoAFIP" || lote.WF.IdEstado == "AceptadoAFIPO" || lote.WF.IdEstado == "AceptadoAFIPP")
                {
                    cn = new OleDbConnection(Aplicacion.Sesion.CnnStrAplicExterna);
                    cn.Open();
                    //Aceptados por AFIP
                    foreach (eFact_Entidades.Comprobante c in lote.Comprobantes)
                    {
                        //Grabar CAEs
                        if (c.EstadoIFoAFIP == "A")
                        {
                            // Tabla: "BECCL" - Comprobante OK
                            myInsertQueryOK = "insert into BECCL (BCCID, BCCCOM, BCCIDL, BCCTCO, BCCCLA, ";
                            myInsertQueryOK += "BCCTCA, BCCSUC, BCCNED, BCCCAE, BCCFVC, BCCFOC, BCCFPR, BCCHPR) ";
                            myInsertQueryOK += "values ('BC', 0, " + lote.NumeroLote + ", '', '', ";
                            myInsertQueryOK += "'" + c.IdTipoComprobante + "', '" + lote.PuntoVenta + "', '" + c.NumeroComprobante + "', '" + c.NumeroCAE + "', '" + c.FechaVtoCAE.ToString("yyyyMMdd") + "', '" + c.FechaCAE.ToString("yyyyMMdd") + "', '" + fecha + "', '" + hora + "') ";
                            myCommand = new OleDbCommand(myInsertQueryOK);
                            myCommand.Connection = cn;
                            myCommand.ExecuteNonQuery();
                            // --------------------------------
                        }
                        else
                        {
                            // Tabla: "BECCL" - Comprobante ER
                            myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                            //Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                            myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                            myInsertQueryER += "BEIFPR, BEIHPR) ";
                            myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                            string codigoError = "99";
                            if (c.EstadoIFoAFIP != null && c.EstadoIFoAFIP != "")
                            {
                                codigoError = c.EstadoIFoAFIP;
                            }
                            myInsertQueryER += "'" + c.IdTipoComprobante + "', '" + lote.PuntoVenta + "', '" + c.NumeroComprobante + "', '" + codigoError + "'";
                            myInsertQueryER += Comentarios(c.ComentarioIFoAFIP); 
                            myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                            myCommand = new OleDbCommand(myInsertQueryER);
                            myCommand.Connection = cn;
                            myCommand.ExecuteNonQuery();
                            // --------------------------------
                        }
                    }
                    // Tabla: "BELLL" - Log
                    //LOG indicando OK
                    myInsertQueryER = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                    myInsertQueryER += "values ('BL', '" + lote.NumeroLote + "', 'OK', '" + fecha + "', '" + hora + "') ";
                    myCommand = new OleDbCommand(myInsertQueryER);
                    myCommand.Connection = cn;
                    myCommand.ExecuteNonQuery();
                    //LOG indicando ERROR
                    if (lote.WF.IdEstado == "AceptadoAFIPP")
                    {
                        myInsertQueryER = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                        myInsertQueryER += "values ('BL', '" + lote.NumeroLote + "', 'ER', '" + fecha + "', '" + hora + "') ";
                        myCommand = new OleDbCommand(myInsertQueryER);
                        myCommand.Connection = cn;
                        myCommand.ExecuteNonQuery();
                    }
                    // --------------------------------
                    cn.Close();
                }
                else
                {
                    cn = new OleDbConnection(Aplicacion.Sesion.CnnStrAplicExterna);
                    cn.Open();
                    // Rechazados por IF o AFIP
                    if (lote.WF.Log[lote.WF.Log.Count - 1].Comentario.Contains("Punto de Venta: [") && lote.WF.Log[lote.WF.Log.Count - 1].Comentario.Contains(" Comprobante: ["))
                    {
                        // Grabar errores a nivel de comprobante
                        foreach (eFact_Entidades.Comprobante c in lote.Comprobantes)
                        {
                            if (c.ComentarioIFoAFIP != null && c.ComentarioIFoAFIP != "" && c.ComentarioIFoAFIP.Substring(0, 2) == "<?")
                            {
                                try
                                {
                                    // Deserializar ( pasar de string XML a FeaEntidades.InterFacturas.lote_comprobantes )
                                    System.Text.Encoding codificador;
                                    codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                                    byte[] a = new byte[c.ComentarioIFoAFIP.Length];
                                    a = codificador.GetBytes(c.ComentarioIFoAFIP);
                                    MemoryStream ms = new MemoryStream(a);
                                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                                    FeaEntidades.InterFacturas.comprobante_response cr = new FeaEntidades.InterFacturas.comprobante_response();
                                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(cr.GetType());
                                    cr = (FeaEntidades.InterFacturas.comprobante_response)x.Deserialize(ms);
                                    foreach (FeaEntidades.InterFacturas.error ce in cr.errores_comprobante)
                                    {
                                        // Tabla: "BECCL" - Comprobante ER
                                        myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                                        //Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                                        myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                                        myInsertQueryER += "BEIFPR, BEIHPR) ";
                                        myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                                        myInsertQueryER += "'" + c.IdTipoComprobante + "', '" + lote.PuntoVenta + "', '" + c.NumeroComprobante + "', '" + ce.codigo_error + "'";
                                        myInsertQueryER += Comentarios(ce.descripcion_error);
                                        myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                                        myCommand = new OleDbCommand(myInsertQueryER);
                                        myCommand.Connection = cn;
                                        myCommand.ExecuteNonQuery();
                                        // --------------------------------
                                    }
                                }
                                catch
                                {
                                    // Tabla: "BECCL" - Comprobante ER
                                    myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                                    //Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                                    myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                                    myInsertQueryER += "BEIFPR, BEIHPR) ";
                                    myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                                    myInsertQueryER += "'" + c.IdTipoComprobante + "', '" + lote.PuntoVenta + "', '" + c.NumeroComprobante + "', '99'";
                                    myInsertQueryER += Comentarios(c.ComentarioIFoAFIP);
                                    myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                                    myCommand = new OleDbCommand(myInsertQueryER);
                                    myCommand.Connection = cn;
                                    myCommand.ExecuteNonQuery();
                                    // --------------------------------
                                }
                            }
                            else
                            {
                                // Tabla: "BECCL" - Comprobante ER
                                myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                                //Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                                myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                                myInsertQueryER += "BEIFPR, BEIHPR) ";
                                myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                                myInsertQueryER += "'" + c.IdTipoComprobante + "', '" + lote.PuntoVenta + "', '" + c.NumeroComprobante + "', '99'";
                                myInsertQueryER += Comentarios(c.ComentarioIFoAFIP);
                                myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                                myCommand = new OleDbCommand(myInsertQueryER);
                                myCommand.Connection = cn;
                                myCommand.ExecuteNonQuery();
                                // --------------------------------
                            }
                        }
                    }
                    else
                    {
                        // Grabar errores a nivel de lote
                        cn = new OleDbConnection(Aplicacion.Sesion.CnnStrAplicExterna);
                        cn.Open();
                        try
                        {
                            // Deserializar ( pasar de string XML a FeaEntidades.InterFacturas.lote_comprobantes )
                            System.Text.Encoding codificador;
                            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
                            byte[] a = new byte[lote.LoteXmlIF.Length];
                            a = codificador.GetBytes(lote.LoteXmlIF);
                            MemoryStream ms = new MemoryStream(a);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            FeaEntidades.InterFacturas.lote_response lr = new FeaEntidades.InterFacturas.lote_response();
                            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lr.GetType());
                            lr = (FeaEntidades.InterFacturas.lote_response)x.Deserialize(ms);
                            foreach (FeaEntidades.InterFacturas.error le in lr.errores_lote)
                            {
                                if (le.codigo_error == 500 || le.codigo_error == 600)
                                {
                                    errorSoloXMail = lote.LoteXmlIF;
                                    break;
                                }
                                // Tabla: "BECCL" - Comprobante ER
                                myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                                // Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                                myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                                myInsertQueryER += "BEIFPR, BEIHPR) ";
                                myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                                myInsertQueryER += "'0', '" + lote.PuntoVenta + "', '0', '" + le.codigo_error + "'";
                                myInsertQueryER += Comentarios(le.descripcion_error);
                                myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                                myCommand = new OleDbCommand(myInsertQueryER);
                                myCommand.Connection = cn;
                                myCommand.ExecuteNonQuery();
                            }
                        }
                        catch
                        {
                            // Tabla: "BECCL" - Comprobante ER
                            myInsertQueryER = "insert into BEEIL (BEIID, BEICOM, BEIIDL, BEITCO, BEICLA, BEITCA, BEISUC, BEINED, BEICOE, ";
                            // Descripcion del 1 a 30 / del 31 a 60 / 61 a 90 / 91 a 120 / 121 a 150
                            myInsertQueryER += "BEIDE1, BEIDE2, BEIDE3, BEIDE4, BEIDE5, ";
                            myInsertQueryER += "BEIFPR, BEIHPR) ";
                            myInsertQueryER += "values ('BI', '0', '" + lote.NumeroLote + "', '', '', ";
                            myInsertQueryER += "'0', '" + lote.PuntoVenta + "', '0', '99'";
                            myInsertQueryER += Comentarios(lote.WF.Log[lote.WF.Log.Count - 1].Comentario);
                            myInsertQueryER += ", '" + fecha + "', '" + hora + "') ";
                            myCommand = new OleDbCommand(myInsertQueryER);
                            myCommand.Connection = cn;
                            myCommand.ExecuteNonQuery();
                        }
                        // --------------------------------
                    }
                    if (errorSoloXMail != "")
                    {
                        Exception exSoloXMail = new Exception(errorSoloXMail);
                        Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(exSoloXMail);
                    }
                    else
                    {
                        // Tabla: "BELLL" - Log
                        myInsertQueryER = "insert into BELLL (BLLID, BLLIDL, BLLCOD, BLLFPR, BLLHPR) ";
                        myInsertQueryER += "values ('BL', '" + lote.NumeroLote + "', 'ER', '" + fecha + "', '" + hora + "') ";
                        myCommand = new OleDbCommand(myInsertQueryER);
                        myCommand.Connection = cn;
                        myCommand.ExecuteNonQuery();
                        // --------------------------------
                        cn.Close();
                    }

                }
            }
        }
        private string Comentarios(string comentario)
        {
            if (comentario == null)
            {
                comentario = "";
            }
            comentario = comentario.Replace("\r", "");
            //string[] s = comentario.Split(Convert.ToChar("\n"));
            comentario = comentario.Replace("\n", "");
            string myInsertQueryER = "";
            string comentarioAux = "";
            int cantidadPartes = 0;
            if (comentario.Length > 0)
            {
                for (int i = 0; i < comentario.Length; i++)
                {
                    comentarioAux += comentario.Substring(i, 1);
                    if (comentarioAux.Length == 30)
                    {
                        ++cantidadPartes;
                        myInsertQueryER += ", '" + comentarioAux + "'";
                        comentarioAux = "";
                        if (cantidadPartes == 5)
                        {
                            break;
                        }
                    }
                }
                if (comentarioAux.Length > 0 && cantidadPartes < 5)
                {
                    myInsertQueryER += ", '" + comentarioAux + "'";
                    ++cantidadPartes;
                }
            }
            for (int j = cantidadPartes; j < 5; j++)
            {
                myInsertQueryER += ", ''";
            }
            return myInsertQueryER;
        }
        private void Inicializar()
        {
            System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
            auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"]);

            System.Text.StringBuilder auxCnnStrAplicExterna = new System.Text.StringBuilder();
            auxCnnStrAplicExterna.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStrAplicExterna"]);

            Aplicacion = eFact_RN.Aplicacion.Crear();

            string Usuario = System.Environment.UserName;
            string Dominio = System.Environment.UserDomainName;
            eFact_RN.Sesion.Crear(Usuario, "", Dominio, auxCnn.ToString(), auxCnnStrAplicExterna.ToString(), "Servicio", Aplicacion.Version, Aplicacion.VersionParaControl, Aplicacion.Sesion);
            if (Aplicacion.Sesion == null)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException("Problemas para crear la sesion de trabajo");
            }
            eFact_RN.Vendedor.Consultar(Aplicacion.Vendedores, Aplicacion.Sesion);
        }
    }
}
