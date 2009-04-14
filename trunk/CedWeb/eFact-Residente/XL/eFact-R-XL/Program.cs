using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R_XL;

namespace eFact_R_XL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Entidades.Disco disco = new eFact_R_XL.Entidades.Disco();
            RN.Disco.Leer(disco);
            Entidades.Registro registro = new eFact_R_XL.Entidades.Registro();
            RN.Registro.Leer(registro);
            if (disco.ClaveActivacion == registro.ClaveActivacion)
            {
                Application.Run(new Tablero());
            }
            else
            {
                Application.Run(new Activacion(disco.NroSerie));
            }
        }
    }
}