using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R_XL;
using Microsoft.Win32;
using CaptchaDotNet2.Security.Cryptography;

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
            object changüí;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!RN.Registro.Existe(Registry.LocalMachine, RegistroNombreClave))
            {
                //Registracion
                changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
            }
            //Verificar changüí
            RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "q", out changüí);
            int i = Convert.ToInt32(Encryptor.Decrypt(changüí.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")));
            if (i>0)
            {
                i--;
                changüí = Encryptor.Encrypt(i.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                Application.Run(new Tablero());
            }
            else
            {
                //Verificar activacion
                ClaveSolicitud = RN.Disco.ClaveSolicitud();
                string claveSolicitud = Encryptor.Encrypt(ClaveSolicitud, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                object claveActivacion;
                RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "k", out claveActivacion);
				if (claveSolicitud == claveActivacion.ToString())
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
}