using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mail;
using System.IO;
using System.Reflection;
using System.Configuration;


namespace Cedeira.Ex
{
    public sealed class MailWSExceptionPublisher : IExceptionPublisher
    {
        private string m_LogName = System.IO.Path.GetTempPath() + "CedeiraErrorLog.txt";
        private string m_OpMail = "";
        private string m_WSurl;
        public MailWSExceptionPublisher() // Esta clase se refiere a los objetos que enviaran las excepciones por mail incluyendo la captura de imagen.
        {
        }
        // Provide implementation of the IPublishException interface
        // This contains the single Publish method.
        void IExceptionPublisher.Publish(Exception exception, NameValueCollection AdditionalInfo, NameValueCollection ConfigSettings)
        {
            // Load Config values if they are provided.
            if (ConfigSettings != null)
            {
                if (ConfigSettings["fileName"] != null &&
                    ConfigSettings["fileName"].Length > 0)
                {
                    m_LogName = ConfigSettings["fileName"];
                }
                if (ConfigSettings["operatorMail"] != null &&
                    ConfigSettings["operatorMail"].Length > 0)
                {
                    m_OpMail = ConfigSettings["operatorMail"];
                }
                if (System.Configuration.ConfigurationSettings.AppSettings["WSmailURL"].ToString() != null && System.Configuration.ConfigurationSettings.AppSettings["WSmailURL"].ToString().Length > 0)
                    m_WSurl = System.Configuration.ConfigurationSettings.AppSettings["WSmailURL"].ToString();
            }
            // Create StringBuilder to maintain publishing information.
            StringBuilder strInfo = new StringBuilder();

            // Record the contents of the AdditionalInfo collection.
            if (AdditionalInfo != null)
            {
                // Record General information.
                strInfo.AppendFormat("{0}Información General {0}", Environment.NewLine);
                strInfo.AppendFormat("{0}Info adicional:", Environment.NewLine);
                foreach (string i in AdditionalInfo)
                {
                    if (i != "ExceptionManager.AppDomainName")
                    {
                        strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, AdditionalInfo.Get(i));
                    }
                    else
                    {
                        //Agrego version
                        try
                        {
                            string name = AdditionalInfo.Get(3);
                            name = name.Replace(".exe", "");
                            name = name.Replace(".vshost", "");
                            name = name.Replace(".dll", "");
                            Assembly a = Assembly.Load(name);
                            AssemblyName an = a.GetName();
                            String v = an.Version.ToString();
                            strInfo.AppendFormat("{0}{1}: {2}, Versión=" + v, Environment.NewLine, i, AdditionalInfo.Get(i));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            strInfo.AppendFormat("{0}{1}: {2}, Versión=sin informar", Environment.NewLine, i, AdditionalInfo.Get(i));
                        }
                    }
                }
            }
            // Append the exception text
            strInfo.AppendFormat("{0}{0}Información de la excepción:{0}{0}{1}{0}", Environment.NewLine, exception.Message);
            strInfo.AppendFormat("{0}{1}{0}", Environment.NewLine, exception.Source);
            if (exception.InnerException != null)
            {
                strInfo.AppendFormat("{0}{1}", Environment.NewLine, exception.InnerException.Message);
            }
            strInfo.AppendFormat("{0}{0}StackTrace:", Environment.NewLine);
            strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.StackTrace.ToString());
            if (exception.InnerException != null)
            {
                strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.InnerException.StackTrace.ToString());
            }
            //Agrego el nombre del archivo y localización
            strInfo.AppendFormat("{0}{0}Archivo: " + m_LogName + "{0}", Environment.NewLine);
            // Write the entry to the log file.   
            using (FileStream fs = File.Open(m_LogName,
                        FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(strInfo.ToString());
                }
            }
            // send notification email if operatorMail attribute was provided
            if (m_OpMail.Length > 0)
            {
                //original
                string subject = "Notificación de excepción";
                string body = strInfo.ToString();

                EmailWS.Email ews = new Cedeira.Ex.EmailWS.Email();
                ews.Url = m_WSurl;

                try
                {
                    // ----- Busco el archivo JPG más reciente dentro de nuestro directorio de excepciones (c:\tmp\ex\)
                    DirectoryInfo di = new DirectoryInfo(@"c:\tmp\ex");
                    FileInfo[] files = di.GetFiles("*.jpg");

                    FileInfo archivoExUlt;
                    if (files.Length > 0)
                    {
                        archivoExUlt = files[0];
                        int ij = 1;
                        while (ij < files.Length)
                        {
                            if (files[ij].LastWriteTime > archivoExUlt.LastWriteTime)
                                archivoExUlt = files[ij];
                            ij++;
                        }

                        String strFile = System.IO.Path.GetFileName(archivoExUlt.FullName);
                        long numBytes = archivoExUlt.Length;
                        FileStream fStream = new FileStream(archivoExUlt.FullName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fStream);
                        byte[] data = br.ReadBytes((int)numBytes);
                        br.Close();
                        ews.EnviarEmailConAdjunto(AdditionalInfo.Get("ExceptionManager.AppDomainName") + "@cedeira.com.ar", m_OpMail, "", "", subject, body + "\r\n", "vsmtpr", data, "pantalla.jpg");
                        fStream.Close();
                        fStream.Dispose();
                    }
                    else
                        throw new Exception();
                }
                catch
                {
                    ews.EnviarEmailSinAdjunto(AdditionalInfo.Get("ExceptionManager.AppDomainName") + "@cedeira.com.ar", m_OpMail, "", "", subject, body + "\r\n  (Falló envio de mail con adjunto) \r\n", "vsmtpr");
                }
            }
        }
    }
}