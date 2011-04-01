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
                System.Console.WriteLine(psi.FileName);
                psi.Arguments = " /LogFile= \"" + @args[0] + "\\eFact-S.exe" + "\"";
                System.Console.WriteLine(psi.Arguments);
                
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                System.Console.WriteLine("Asignar ProcessStartInfo");
                pro.StartInfo = psi;
                System.Console.WriteLine("Ejecutar el Start Process");
                pro.Start();
                System.Console.WriteLine("Start Process listo");
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
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
        }
    }
}
