using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R;
using Microsoft.Win32;
using CaptchaDotNet2.Security.Cryptography;
using System.Globalization;
using System.Threading; 

namespace eFact_R
{
    static class Aplicacion
    {
        public static string ClaveSolicitud;
        public static CedEntidades.Sesion Sesion;
        public static string ArchDb;
        public static string ArchPath;
        public static string ArchPathHis;
        public static string ArchPathItf;
        public static string ArchPathItfAut;
        public static string VisualizarArchivos;
        public static string TipoItfAut;
        public static string ArchPathPDF;
        public static string CodigoAplic;
        public static string Modalidad;
        public static string OtrosFiltrosFiltrarBE;
        public static string OtrosFiltrosFiltrarBS;
        public static string OtrosFiltrosCuit;
        public static string OtrosFiltrosPuntoVta;
        public static DateTime FechaMin;
        public static DateTime FechaMax;
        public static string StoreLocationActivacion;
        public static List<eFact_R.Entidades.Vendedor> Vendedores = new List<eFact_R.Entidades.Vendedor>();
        public const string RegistroNombreClave = @"Software\Cedeira\eFact-R";

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
                ArchPathHis = @System.Configuration.ConfigurationManager.AppSettings["ArchPathHis"];
                ArchPathItf = @System.Configuration.ConfigurationManager.AppSettings["ArchPathItf"];
                ArchPathItfAut = @System.Configuration.ConfigurationManager.AppSettings["ArchPathItfAut"];
                VisualizarArchivos = @System.Configuration.ConfigurationManager.AppSettings["VisualizarArchivos"];
                TipoItfAut = @System.Configuration.ConfigurationManager.AppSettings["TipoItfAut"];
                ArchPathPDF = @System.Configuration.ConfigurationManager.AppSettings["ArchPathPDF"];
                CodigoAplic = @System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"];
                Modalidad = @System.Configuration.ConfigurationManager.AppSettings["Modalidad"];
                OtrosFiltrosFiltrarBE = @System.Configuration.ConfigurationManager.AppSettings["OtrosFiltrosFiltrarBE"];
                OtrosFiltrosFiltrarBS = @System.Configuration.ConfigurationManager.AppSettings["OtrosFiltrosFiltrarBS"];
                OtrosFiltrosCuit = @System.Configuration.ConfigurationManager.AppSettings["OtrosFiltrosCuit"];
                OtrosFiltrosPuntoVta = @System.Configuration.ConfigurationManager.AppSettings["OtrosFiltrosPuntoVta"];
                FechaMin = Convert.ToDateTime("01/01/2001");
                FechaMax = Convert.ToDateTime("31/12/9998");
                StoreLocationActivacion = @System.Configuration.ConfigurationManager.AppSettings["StoreLocationActivacion"];

                //seteo cultura thread
                Thread.CurrentThread.CurrentCulture = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);

                object changüí;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (StoreLocationActivacion == "CurrentUser")
                {
                    if (!RN.Registro.Existe(Registry.CurrentUser, RegistroNombreClave))
                    {
                        //Registracion
                        changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                        RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "k", "");
                    }
                    else
                    {
                        if (!RN.Registro.ExisteValor(Registry.CurrentUser, RegistroNombreClave, "q"))
                        {
                            changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                        }
                        if (!RN.Registro.ExisteValor(Registry.CurrentUser, RegistroNombreClave, "k"))
                        {
                            RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "k", "");
                        }
                    }
                }
                else
                {
                    if (!RN.Registro.Existe(Registry.LocalMachine, RegistroNombreClave))
                    {
                        //Registracion
                        changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                        RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
                    }
                    else
                    {
                        if (!RN.Registro.ExisteValor(Registry.LocalMachine, RegistroNombreClave, "q"))
                        {
                            changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                        }
                        if (!RN.Registro.ExisteValor(Registry.LocalMachine, RegistroNombreClave, "k"))
                        {
                            RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
                        }
                    }
                }
                //Verificar changüí
                if (StoreLocationActivacion == "CurrentUser")
                {
                    RN.Registro.Leer(Registry.CurrentUser, RegistroNombreClave, "q", out changüí);
                }
                else
                {
                    RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "q", out changüí);
                }
                int i = Convert.ToInt32(Encryptor.Decrypt(changüí.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")));
                if (i > 0)
                {
                    i--;
                    changüí = Encryptor.Encrypt(i.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    if (StoreLocationActivacion == "CurrentUser")
                    {
                        RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                    }
                    else
                    {
                        RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                    }
                    Application.Run(new Tablero());
                }
                else
                {
                    //Verificar activacion
                    ClaveSolicitud = RN.Disco.ClaveSolicitud();
                    string claveSolicitud = Encryptor.Encrypt(ClaveSolicitud, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    object claveActivacion;
                    if (StoreLocationActivacion == "CurrentUser")
                    {
                        RN.Registro.Leer(Registry.CurrentUser, RegistroNombreClave, "k", out claveActivacion);
                    }
                    else
                    {
                        RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "k", out claveActivacion);
                    }
                    if (claveSolicitud == claveActivacion.ToString())
                    {
                        System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
                        auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"]);
                        
                        System.Text.StringBuilder auxCnnAplicExterna = new System.Text.StringBuilder();
                        auxCnnAplicExterna.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStrAplicExterna"]);
                        auxCnnAplicExterna.Append(ArchPath);
                        auxCnnAplicExterna.Append(ArchDb);
                        
                        eFact_R.Entidades.Aplicacion aplic = eFact_R.RN.Aplicacion.Crear();
                        Sesion = new CedEntidades.Sesion();
                        string Usuario = System.Environment.UserName;
                        string Dominio = System.Environment.UserDomainName;
                        eFact_R.RN.Sesion.Crear(Usuario, "", Dominio, auxCnn.ToString(), auxCnnAplicExterna.ToString(), "FrontEnd", aplic.Version, aplic.VersionParaControl, Sesion);
                        if (Sesion != null)
                        {
                            Application.Run(new Tablero());
                        }
                        else
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException("Problemas para crear la sesion de trabajo");
                        }
                    }
                    else
                    {
                        Application.Run(new Activacion());
                    }
                }
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