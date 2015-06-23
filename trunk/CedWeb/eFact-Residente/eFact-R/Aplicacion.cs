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
                StoreLocationActivacion = @System.Configuration.ConfigurationManager.AppSettings["StoreLocationActivacion"];

                //seteo cultura thread
                CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                Thread.CurrentThread.CurrentCulture = cedeiraCultura;

                FechaMin = Convert.ToDateTime("01/01/2001");
                FechaMax = Convert.ToDateTime("31/12/9998");

                Aplic = eFact_RN.Aplicacion.Crear();
                Aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
                Aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

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