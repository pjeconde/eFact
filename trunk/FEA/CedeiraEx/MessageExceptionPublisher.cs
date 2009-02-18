using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Cedeira.Ex {
	public sealed class MessageExceptionPublisher : IExceptionPublisher {
		private string m_LogName = System.IO.Path.GetTempPath()  + "CedeiraErrorLog.txt";

        [DllImport("GDI32.dll")]
        public static extern bool BitBlt(int hdcDest,int nXDest,int nYDest,int nWidth,int nHeight,int hdcSrc,int nXSrc,int nYSrc,int dwRop);
        [DllImport("GDI32.dll")]
        public static extern int CreateCompatibleBitmap(int hdc,int nWidth, int nHeight);[DllImport("GDI32.dll")]
        public static extern int CreateCompatibleDC(int hdc);
        [DllImport("GDI32.dll")]
        public static extern bool DeleteDC(int hdc);
        [DllImport("GDI32.dll")]
        public static extern bool DeleteObject(int hObject);
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(int hdc,int nIndex);
        [DllImport("GDI32.dll")]
        public static extern int SelectObject(int hdc,int hgdiobj);
        [DllImport("User32.dll")]
        public static extern int GetDesktopWindow();
        [DllImport("User32.dll")]
        public static extern int GetWindowDC(int hWnd);
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(int hWnd,int hDC);

		public MessageExceptionPublisher() {
		}
		// Provide implementation of the IPublishException interface
		// This contains the single Publish method.
		void IExceptionPublisher.Publish(Exception exception, NameValueCollection AdditionalInfo, NameValueCollection ConfigSettings) {
			// Load Config values if they are provided.
			if (ConfigSettings != null) {
				if (ConfigSettings["fileName"] != null &&  
					ConfigSettings["fileName"].Length > 0) {  
					m_LogName = ConfigSettings["fileName"];
				}
			}
			// Create StringBuilder to maintain publishing information.
			StringBuilder strInfo = new StringBuilder();

			// Record the contents of the AdditionalInfo collection.
			if (AdditionalInfo != null) {
				// Record General information.
				strInfo.AppendFormat("{0}Información General {0}", Environment.NewLine);
				strInfo.AppendFormat("{0}Info adicional:", Environment.NewLine);
				foreach (string i in AdditionalInfo) {
					if(i!="ExceptionManager.AppDomainName") {
						strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, AdditionalInfo.Get(i));
					}
					else {
						//Agrego version
						try {
							string name=AdditionalInfo.Get(3);
							name=name.Replace(".exe","");
                            name = name.Replace(".vshost", "");
							name=name.Replace(".dll","");
							Assembly a = Assembly.Load(name);
							AssemblyName an = a.GetName();
							String v = an.Version.ToString();
							strInfo.AppendFormat("{0}{1}: {2}, Versión=" + v , Environment.NewLine,i, AdditionalInfo.Get(i));
						}
						catch (Exception ex) {
							System.Diagnostics.Debug.WriteLine(ex.Message);
							strInfo.AppendFormat("{0}{1}: {2}, Versión=sin informar", Environment.NewLine,i, AdditionalInfo.Get(i));
						}
					}
				}
			}
			// Append the exception text
			strInfo.AppendFormat("{0}{0}Información de la excepción:{0}{0}{1}", Environment.NewLine, exception.Message);
			if(exception.InnerException!=null) {
				strInfo.AppendFormat("{0}{1}", Environment.NewLine, exception.InnerException.Message);
			}
			strInfo.AppendFormat("{0}{0}StackTrace:", Environment.NewLine);
			strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.StackTrace.ToString());
			if(exception.InnerException!=null) {			
				strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.InnerException.StackTrace.ToString());
			}
			//Agrego el nombre del archivo y localización
			strInfo.AppendFormat("{0}{0}Archivo: " + m_LogName + "{0}", Environment.NewLine);
			// Write the entry to the log file.   
			using ( FileStream fs = File.Open(m_LogName,
						FileMode.Append,FileAccess.Write)) {
				using (StreamWriter sw = new StreamWriter(fs)) {
					sw.Write(strInfo.ToString());
				}
			}

            int hdcSrc = GetWindowDC(GetDesktopWindow()), hdcDest = CreateCompatibleDC(hdcSrc), 
            hBitmap = CreateCompatibleBitmap(hdcSrc,
            GetDeviceCaps(hdcSrc, 8), GetDeviceCaps(hdcSrc, 10)); SelectObject(hdcDest, hBitmap);
            BitBlt(hdcDest, 0, 0, GetDeviceCaps(hdcSrc, 8),
            GetDeviceCaps(hdcSrc, 10), hdcSrc, 0, 0, 0x00CC0020);
            SaveImageAs(hBitmap, @"C:\tmp\ex\ex.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Cleanup(hBitmap, hdcSrc, hdcDest);
            System.Threading.Thread.Sleep(200);
			// send notification email if operatorMail attribute was provided
			if(exception.InnerException!=null) {
				Cedeira.UI.Mostrar.Mensaje(exception.Message+"\r\n"+exception.InnerException.Message.ToString(),Microsoft.VisualBasic.MsgBoxStyle.Critical,"NOTIFICACION DE EXCEPCION",exception.StackTrace.ToString()+"\r\n"+exception.InnerException.StackTrace.ToString());
			}
			else {
				Cedeira.UI.Mostrar.Mensaje(exception.Message,Microsoft.VisualBasic.MsgBoxStyle.Critical,"NOTIFICACION DE EXCEPCION",exception.StackTrace.ToString());
			}
		}
        private void Cleanup(int hBitmap, int hdcSrc, int hdcDest)
        {
            ReleaseDC(GetDesktopWindow(), hdcSrc);
            DeleteDC(hdcDest);
            DeleteObject(hBitmap);
        }
        private void SaveImageAs(int hBitmap, string fileName, ImageFormat imageFormat)
        {
            if (!Directory.Exists(@"c:\tmp\ex"))
                Directory.CreateDirectory(@"c:\tmp\ex");
            else  // Si existe intento borrar todos los archivos del directorio, los que estén en uso los saltea.
            {
                DirectoryInfo di = new DirectoryInfo(@"c:\tmp\ex");
                FileInfo[] files = di.GetFiles("*.jpg");

                foreach (FileInfo file in files)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                    }
                }
                
            }
            Bitmap image =
            new Bitmap(Image.FromHbitmap(new IntPtr(hBitmap)),
            Image.FromHbitmap(new IntPtr(hBitmap)).Width,
            Image.FromHbitmap(new IntPtr(hBitmap)).Height);
            bool abierto;
            try
            {

                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Write, FileShare.None);
                fs.Close();
                abierto = false;
            }
            catch (FileNotFoundException )
            {
                abierto = false;
            }
            catch (UnauthorizedAccessException )
            {
                abierto = true;
            }
            if (!abierto)
                image.Save(fileName, imageFormat);  // Tener cuidado que si el ex.jpg está abierto, al tirar las excepciones no se ve el error.
            else
                image.Save(fileName.Replace(".jpg","") + DateTime.Today.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss")+".jpg", imageFormat);
        }
	}
}