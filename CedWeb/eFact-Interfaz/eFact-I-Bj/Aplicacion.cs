using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_I_Bj;
using Microsoft.Win32;
using CaptchaDotNet2.Security.Cryptography;
using System.Globalization;
using System.Threading;

namespace eFact_I_Bj
{
    static class Aplicacion
    {
        public static string ClaveSolicitud;
        public static CedEntidades.Sesion Sesion;
        public static string ArchDb;
        public static string ArchPath;
        public static string CodigoAplic;
        public static string Modalidad;
        public static DateTime FechaMin;
        public static DateTime FechaMax;
        public static bool Testing;
        
        public const string RegistroNombreClave = @"Software\Cedeira\eFact-I-Bj";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                ArchDb = @System.Configuration.ConfigurationManager.AppSettings["ArchDb"];
                ArchPath = @System.Configuration.ConfigurationManager.AppSettings["ArchPath"];
                CodigoAplic = @System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"];
                Modalidad = @System.Configuration.ConfigurationManager.AppSettings["Modalidad"];
                Testing = Convert.ToBoolean(@System.Configuration.ConfigurationManager.AppSettings["Testing"]);
                FechaMin = Convert.ToDateTime("01/01/2001");
                FechaMax = Convert.ToDateTime("31/12/9998");

                //seteo cultura thread
                Thread.CurrentThread.CurrentCulture = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                //object changüí;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //if (!RN.Registro.Existe(Registry.LocalMachine, RegistroNombreClave))
                //{
                //    //Registracion
                //    changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                //    RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                //    RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
                //}
                ////Verificar changüí
                //RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "q", out changüí);
                //int i = Convert.ToInt32(Encryptor.Decrypt(changüí.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")));
                //if (i > 0)
                //{
                //    i--;
                //    changüí = Encryptor.Encrypt(i.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                //    RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                //    Application.Run(new TableroBj());
                //}
                //else
                //{
                //    //Verificar activacion
                //    ClaveSolicitud = RN.Disco.ClaveSolicitud();
                //    string claveSolicitud = Encryptor.Encrypt(ClaveSolicitud, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                //    object claveActivacion;
                //    RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "k", out claveActivacion);
                //    if (claveSolicitud == claveActivacion.ToString())
                //    {
                        System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
                        auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"]);
                        
                        System.Text.StringBuilder auxCnnAplicExterna = new System.Text.StringBuilder();
                        auxCnnAplicExterna.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStrAplicExterna"]);
                        
                        eFact_I_Bj.Entidades.Aplicacion aplic = eFact_I_Bj.RN.Aplicacion.Crear();
                        Sesion = new CedEntidades.Sesion();
                        eFact_I_Bj.RN.Sesion.Crear("Usr_eFact", "", "NONE", auxCnn.ToString(), auxCnnAplicExterna.ToString(), "FrontEndBj", aplic.Version, aplic.VersionParaControl, Sesion);
                        if (Sesion != null)
                        {
                            Application.Run(new TableroBj());
                        }
                        else
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException("Problemas para crear la sesion de trabajo");
                        }
                //    }
                //    else
                //    {
                //        Application.Run(new Activacion());
                //    }
                //}
            }
			catch (Exception ex) 
            {
			    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
			}
			finally {
				Cursor.Current=System.Windows.Forms.Cursors.Default;
			}

        }
    }
}