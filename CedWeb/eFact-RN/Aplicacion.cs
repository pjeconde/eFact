using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_RN
{
	public static class Aplicacion
	{
		public static eFact_Entidades.Aplicacion Crear()
		{
			eFact_Entidades.Aplicacion aplic = new eFact_Entidades.Aplicacion();
			aplic.Nombre = System.Configuration.ConfigurationManager.AppSettings["NombreAplic"].ToString();
			aplic.Codigo = System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"].ToString();
			aplic.Propietario = System.Configuration.ConfigurationManager.AppSettings["Propietario"].ToString();
			aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
			aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

            aplic.ArchPath = @System.Configuration.ConfigurationManager.AppSettings["ArchPath"];
            aplic.ArchPathHis = @System.Configuration.ConfigurationManager.AppSettings["ArchPathHis"];
            aplic.ArchPathItf = @System.Configuration.ConfigurationManager.AppSettings["ArchPathItf"];
            aplic.ArchPathItfAut = @System.Configuration.ConfigurationManager.AppSettings["ArchPathItfAut"];
            aplic.ArchPathPDF = @System.Configuration.ConfigurationManager.AppSettings["ArchPathPDF"];

            aplic.MailServidorSmtp = @System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
            aplic.MailCredencialesUsr = @System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
            aplic.MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
            aplic.MailTest = @System.Configuration.ConfigurationManager.AppSettings["MailTest"];

            aplic.CodigoAplic = @System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"];

            aplic.StoreLocation = @System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];

            aplic.OtrosFiltrosCuit = @System.Configuration.ConfigurationManager.AppSettings["OtrosFiltrosCuit"];
			return aplic;
		}
	}
}
