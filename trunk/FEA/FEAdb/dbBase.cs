using System;
using System.Collections.Generic;
using System.Text;
using Cedeira.SV;
using System.Globalization;

namespace FEAdb
{
	public abstract class dbBase : Cedeira.SV.dbBase
	{
		#region Atributos
		protected CultureInfo cedeiraCultura;
		protected Idb_Sesion m_Sesion;
		#endregion
		#region Constructor
		public dbBase(Idb_Sesion Sesion)
			: base(Sesion)
		{
			m_Sesion = Sesion;
			cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
		}
		#endregion
	}
}
