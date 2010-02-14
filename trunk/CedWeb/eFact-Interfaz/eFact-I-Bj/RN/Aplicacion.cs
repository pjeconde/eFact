using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.RN
{
	public static class Aplicacion
	{
        public static eFact_I_Bj.Entidades.Aplicacion Crear()
		{
            eFact_I_Bj.Entidades.Aplicacion aplic = new eFact_I_Bj.Entidades.Aplicacion();
			aplic.Nombre = System.Configuration.ConfigurationManager.AppSettings["NombreAplic"].ToString(); ;
			aplic.Codigo = System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"].ToString();
			aplic.Propietario = System.Configuration.ConfigurationManager.AppSettings["Propietario"].ToString(); ;
			aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
			aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
			return aplic;
		}
	}
}
