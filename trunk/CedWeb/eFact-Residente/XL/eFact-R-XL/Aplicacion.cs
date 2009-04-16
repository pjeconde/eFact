using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R_XL;
using Microsoft.Win32;

namespace eFact_R_XL
{
    static class Aplicacion
    {
        public static string ClaveSolicitud;
        public const string RegistroNombreClave = @"Software\Cedeira\eFact-R-XL";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!RN.Registro.Existe(Registry.LocalMachine, RegistroNombreClave))
            {
                //Registracion
                RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", "10");
                RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
            }
            //Verificar activacion
            ClaveSolicitud = RN.Disco.ClaveSolicitud();
            object claveActivacion;
            RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "k", out claveActivacion);
            if (ClaveSolicitud == claveActivacion.ToString())
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