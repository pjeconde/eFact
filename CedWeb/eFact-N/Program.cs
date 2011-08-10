using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace eFact_N
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            // Se puede ejecutar más de un servicio de usuario dentro del mismo proceso. Para agregar
            // otro servicio a este proceso, cambie la siguiente línea para
            // crear un segundo objeto de servicio. Por ejemplo,
            //
            //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
            //
            ServicesToRun = new ServiceBase[] { new Service1() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}