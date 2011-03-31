using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace eFact_S_Registrador
{
    public class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            Process pro = new Process();
            string version = "v2.0.50727";
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = Environment.GetEnvironmentVariable("windir") + "\\Microsoft.Net\\Framework\\" + version + "\\" + "installutil.exe";
                psi.Arguments = "\"" + @args[0] + "\\eFact-S.exe" + "\"";
                System.Console.WriteLine(psi.Arguments);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                pro.StartInfo = psi;
                pro.Start();
                Console.WriteLine(pro.StandardOutput.ReadToEnd());
                pro.WaitForExit();

                while (true)
                {
                    if (pro.HasExited)
                    {
                        System.ServiceProcess.ServiceController myController = new System.ServiceProcess.ServiceController("Servicio-eFact");
                        myController.Start();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
    }
}
