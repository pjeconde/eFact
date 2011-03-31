using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_RN
{
	public static class Sesion
	{
        public static void Crear(string IdUsuario, string Password, string Dominio, string CnnStr, string CnnStrAplicExterna, string IdAcceso, string Version, string VersionParaControl, CedEntidades.Sesion Sesion)
		{
            Cedeira.SV.Sesion.Crear(IdUsuario, Password, Dominio, CnnStr, CnnStrAplicExterna, IdAcceso, Version, VersionParaControl, Sesion);
		}
	}
}
