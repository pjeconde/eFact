using System;
using System.Collections.Generic;
using System.Text;

namespace CedWebRN
{
	public static class Aplicacion
	{
		public static CedWebEntidades.Aplicacion Crear()
		{
			CedWebEntidades.Aplicacion aplic = new CedWebEntidades.Aplicacion();
			aplic.Nombre = System.Configuration.ConfigurationManager.AppSettings["NombreAplic"].ToString(); ;
			aplic.Codigo = System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"].ToString();
			aplic.Propietario = System.Configuration.ConfigurationManager.AppSettings["Propietario"].ToString(); ;
			aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
			aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
			return aplic;
		}
	}
}
