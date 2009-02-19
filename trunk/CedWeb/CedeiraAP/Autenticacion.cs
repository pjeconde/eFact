using System;

namespace Cedeira.SV
{
	/// <summary>
	/// Descripción breve de Autenticacion.
	/// </summary>
	public class Autenticacion
	{
		public Autenticacion()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
        public void Login(string Usuario, string Password, string Dominio, string CnnStr, string IdAcceso, string Version, string VersionParaControl, CedEntidades.Sesion sesion)
		{
			//System.Configuration.ConfigurationManager.AppSettings["Servidor"];
            Cedeira.SV.Sesion.Crear(Usuario, Password, Dominio, CnnStr, IdAcceso, Version, VersionParaControl, sesion);
		}
	}
}
