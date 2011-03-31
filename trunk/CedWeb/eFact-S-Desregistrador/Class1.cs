using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace eFact_S_Desregistrador
{
    public class Class1
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Process pro = new Process();
            string version = "v2.0.50727";
            System.Console.WriteLine(args[0]);
            try
            {
                try
                {
                    System.ServiceProcess.ServiceController myController = new System.ServiceProcess.ServiceController("Servicio-eFact");
                    myController.Stop();
                }
                catch
                {
                }

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = Environment.GetEnvironmentVariable("windir") + "\\Microsoft.Net\\Framework\\" + version + "\\" + "installutil.exe";
                string aux = " /u \"" + @args[0] + "\\eFact-S.exe" + "\"";
                psi.Arguments = aux;

                System.Console.WriteLine(psi.Arguments);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                pro.StartInfo = psi;
                pro.Start();
                Console.WriteLine(pro.StandardOutput.ReadToEnd());
                pro.WaitForExit();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
    }
}
