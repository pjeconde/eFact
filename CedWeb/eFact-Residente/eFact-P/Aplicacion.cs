﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eFact_R;
using eFact_P;
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
        public static string VisualizarArchivos;
        public static string Modalidad;
        public static string OtrosFiltrosFiltrarBE;
        public static string OtrosFiltrosFiltrarBS;
        public static string OtrosFiltrosCuit;
        public static string OtrosFiltrosPuntoVta;
        public static DateTime FechaMin;
        public static DateTime FechaMax;
        public static string StoreLocationActivacion;
        public static List<eFact_Entidades.Vendedor> Vendedores = new List<eFact_Entidades.Vendedor>();
        public const string RegistroNombreClave = @"Software\Cedeira\eFact-R";
        public static eFact_Entidades.Aplicacion Aplic;

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
                VisualizarArchivos = @System.Configuration.ConfigurationManager.AppSettings["VisualizarArchivos"];
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
                    if (!eFact_RN.Registro.Existe(Registry.CurrentUser, RegistroNombreClave))
                    {
                        //Registracion
                        changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        eFact_RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                        eFact_RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "k", "");
                    }
                    else
                    {
                        if (!eFact_RN.Registro.ExisteValor(Registry.CurrentUser, RegistroNombreClave, "q"))
                        {
                            changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            eFact_RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                        }
                        if (!eFact_RN.Registro.ExisteValor(Registry.CurrentUser, RegistroNombreClave, "k"))
                        {
                            eFact_RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "k", "");
                        }
                    }
                }
                else
                {
                    if (!eFact_RN.Registro.Existe(Registry.LocalMachine, RegistroNombreClave))
                    {
                        //Registracion
                        changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                        eFact_RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                        eFact_RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
                    }
                    else
                    {
                        if (!eFact_RN.Registro.ExisteValor(Registry.LocalMachine, RegistroNombreClave, "q"))
                        {
                            changüí = Encryptor.Encrypt("0", "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            eFact_RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                        }
                        if (!eFact_RN.Registro.ExisteValor(Registry.LocalMachine, RegistroNombreClave, "k"))
                        {
                            eFact_RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "k", "");
                        }
                    }
                }
                //Verificar changüí
                if (StoreLocationActivacion == "CurrentUser")
                {
                    eFact_RN.Registro.Leer(Registry.CurrentUser, RegistroNombreClave, "q", out changüí);
                }
                else
                {
                    eFact_RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "q", out changüí);
                }
                int i = Convert.ToInt32(Encryptor.Decrypt(changüí.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")));
                if (i > 0)
                {
                    i--;
                    changüí = Encryptor.Encrypt(i.ToString(), "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    if (StoreLocationActivacion == "CurrentUser")
                    {
                        eFact_RN.Registro.Guardar(Registry.CurrentUser, RegistroNombreClave, "q", changüí);
                    }
                    else
                    {
                        eFact_RN.Registro.Guardar(Registry.LocalMachine, RegistroNombreClave, "q", changüí);
                    }
                    Application.Run(new Tablero());
                }
                else
                {
                    //Verificar activacion
                    ClaveSolicitud = eFact_RN.Disco.ClaveSolicitud();
                    string claveSolicitud = Encryptor.Encrypt(ClaveSolicitud, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    object claveActivacion;
                    if (StoreLocationActivacion == "CurrentUser")
                    {
                        eFact_RN.Registro.Leer(Registry.CurrentUser, RegistroNombreClave, "k", out claveActivacion);
                    }
                    else
                    {
                        eFact_RN.Registro.Leer(Registry.LocalMachine, RegistroNombreClave, "k", out claveActivacion);
                    }
                    if (claveSolicitud == claveActivacion.ToString())
                    {
                        Aplic = eFact_RN.Aplicacion.Crear();

                        System.Text.StringBuilder auxCnn = new System.Text.StringBuilder();
                        auxCnn.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStr"]);
                        
                        System.Text.StringBuilder auxCnnAplicExterna = new System.Text.StringBuilder();
                        auxCnnAplicExterna.Append(System.Configuration.ConfigurationManager.AppSettings["CnnStrAplicExterna"]);
                        auxCnnAplicExterna.Append(Aplic.ArchPath);
                        auxCnnAplicExterna.Append(ArchDb);
 
                        Sesion = new CedEntidades.Sesion();
                        string Usuario = System.Environment.UserName;
                        string Dominio = System.Environment.UserDomainName;
                        eFact_RN.Sesion.Crear(Usuario, "", Dominio, auxCnn.ToString(), auxCnnAplicExterna.ToString(), "FrontEnd", Aplic.Version, Aplic.VersionParaControl, Sesion);
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
			finally 
            {
				Cursor.Current=System.Windows.Forms.Cursors.Default;
			}

        }
    }
}