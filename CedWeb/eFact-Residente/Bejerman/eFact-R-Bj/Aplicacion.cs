using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eFact_R_Bj
{
    static class Aplicacion
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tablero());
        }
    }
}