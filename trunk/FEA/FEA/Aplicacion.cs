using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Reflection;
using Cedeira.SV;
using FEArn;

namespace FEA
{
	public class Aplicacion
	{
		public static Sesion Sesion;
		public static string Titulo = "";
		public static string Version = "";
		public static Color CampoHabilitadoBackColor;
		public static Color LabelCampoHabilitadoForeColor;
		public static Color CampoDesHabilitadoBackColor;
		public static Color LabelCampoDesHabilitadoForeColor;
		private static Cedeira.SV.Multicast mc;

		public static Cedeira.SV.Multicast Mc
		{
			get { return Aplicacion.mc; }
			set { Aplicacion.mc = value; }
		}
		[STAThread]
		static void Main()
		{
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				//seteo cultura thread
				CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
				cedeiraCultura.DateTimeFormat = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
				Thread.CurrentThread.CurrentCulture = cedeiraCultura;
				// Determino el path de la aplicacion
				string AppPath = @Application.StartupPath;
				AppPath = AppPath.ToLower().Replace(@"\bin\debug", "") + @"\";
				// Parametros varios
				CampoHabilitadoBackColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["CampoHabilitadoBackColor"]);
				LabelCampoHabilitadoForeColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["LabelCampoHabilitadoForeColor"]);
				CampoDesHabilitadoBackColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["CampoDesHabilitadoBackColor"]);
				LabelCampoDesHabilitadoForeColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["LabelCampoDesHabilitadoForeColor"]);
				// Creo una sesion de trabajo
				Titulo = ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
				Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
				Cedeira.UI.Mostrar.Acerca(Titulo, "(CedFea)", "Versión " + Version, 3);
				string idUsuarioWindows = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(@"\".ToCharArray())[1].ToString();
				string idUsuario = String.Empty;
				string password = String.Empty;
				idUsuario = idUsuarioWindows;
				Cursor.Current = System.Windows.Forms.Cursors.Default;
				System.Configuration.ConnectionStringSettingsCollection connections = System.Configuration.ConfigurationManager.ConnectionStrings;
				string auxCnnStr = connections["MySQL"].ConnectionString;

				Sesion = new Sesion(
					idUsuario,
					password,
					AppPath,
					auxCnnStr,
					"FrontEnd",
					System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString()
					);


				// Levanto el Front-End de la aplicacion
				Application.Run(new PrincipalForm());
				Cedeira.UI.Mostrar.Acerca(Aplicacion.Titulo, "Gracias", "por utilizar CedFEA", 2);
			}
			catch (Exception ex)
			{
				Cedeira.Ex.ExceptionManager.Publish(ex);
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
	}

}
