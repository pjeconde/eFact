using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R_XL;

namespace eFact_R_XL
{
    static class Aplicacion
    {
        public static List<Entidades.Disco> Discos;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Discos = RN.Disco.Lista();
            Entidades.Registro registro = new eFact_R_XL.Entidades.Registro();
            RN.Registro.Leer(registro);
            if (Discos[0].ClaveActivacion == registro.ClaveActivacion)
            {
                Application.Run(new Tablero());
            }
            else
            {
                Application.Run(new Activacion());
            }
        }
    }
}