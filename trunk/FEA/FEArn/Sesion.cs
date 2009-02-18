using System;
using Cedeira.Ex;
using System.Data;
using System.Runtime.Serialization;
using Cedeira.SV;
using FEAdb;


namespace FEArn
{
	public class Sesion : Cedeira.SV.IWF_Sesion,
					  Cedeira.SV.IUsuario_Sesion,
					  Cedeira.SV.Idb_Sesion
	{
		private string m_CnnStr;
		private string m_AppPath;
		private Cedeira.SV.Usuario m_Usuario;
		private bool m_CXO;
		private bool m_RevalyCalcCPsinSyRsPermitido;
		private string m_IdAcceso;
		private string m_AssemblyVersion;
		private bool m_FeriadosHOST;
		private string m_Ambiente;
		private DataTable m_Opcion;
		private DataTable m_InfoCampos;
		private string m_IdMonedaLocal;
		private int m_puertoMultiCast;

		/// <summary>
		/// Constructor para acceso al front-end de la aplicacion
		/// </summary>
		public Sesion(string IdUsuario, string Password, string AppPath, string CnnStr, string IdAcceso, string AssemblyVersion)
		{
			m_IdAcceso = IdAcceso;
			// Establezco el AppPath
			m_AppPath = AppPath;
			// Leo el CnnStr de la base de datos CedFCI
			m_CnnStr = CnnStr;
			db db = new db(this);
			if (System.Configuration.ConfigurationManager.AppSettings["Autenticacion"].ToUpper() != "CICS")
			{
				//Si no hay autenticación contra CICS no vamos a HOST a buscar los feriados
				m_FeriadosHOST = false;
			}
			else
			{
				if (System.Configuration.ConfigurationManager.AppSettings["FeriadosHOST"] != "SI" && System.Configuration.ConfigurationManager.AppSettings["FeriadosHOST"] != "NO")
				{
					throw new Cedeira.Ex.Sesion.ParametroInexistente("FeriadosHOST");
				}
				m_FeriadosHOST = System.Configuration.ConfigurationManager.AppSettings["FeriadosHOST"] == "SI";
			}
			m_Ambiente = System.Configuration.ConfigurationManager.AppSettings["Ambiente"];
			try
			{
				// Verifico que el usuario tenga acceso a la base de datos 
				db.TesteoConexion(m_CnnStr);
				m_Usuario = new Cedeira.SV.Usuario(IdUsuario, Password, this, db);
				// Chequeo si esta activo
				if (!m_Usuario.Activo)
				{
					throw new Cedeira.Ex.Sesion.Usuario.NoActivo();
				}
				// Chequeo si no esta dado de baja
				if (m_Usuario.FecBaja.Date < DateTime.Now.Date)
				{
					throw new Cedeira.Ex.Sesion.Usuario.DeBaja();
				}
			}
			catch (Exception ex)
			{
				throw new Cedeira.Ex.Sesion.Crear(ex);
			}
		}
		public string CnnStr { get { return m_CnnStr; } }
		public string Path { get { return m_AppPath; } }
		public bool CXO { get { return m_CXO; } }
		public bool RevalyCalcCPsinSyRsPermitido { get { return m_RevalyCalcCPsinSyRsPermitido; } }
		public string IdAcceso { get { return m_IdAcceso; } }
		public string ServidoryDB { get { return new db(this).SevidoryDB(); } }
		public string IdMonedaLocal { get { return m_IdMonedaLocal; } }
		public int PuertoMultiCast { get { return m_puertoMultiCast; } }

		public DateTime FechaDB
		{
			get
			{
				db db = new db(this);
				return db.FechaDB;
			}
		}
		public DateTime CalcularFechaHabilSiguiente(DateTime Fecha)
		{
			return FechaHab(Fecha, 1);
		}
		public Cedeira.SV.Usuario Usuario { get { return m_Usuario; } set { m_Usuario = value; } }
		public DataTable Opcion
		{
			get
			{
				return m_Opcion;
			}
			set
			{
				m_Opcion = value;
			}
		}
		public DataTable InfoCampos
		{
			get
			{
				return m_InfoCampos;
			}
			set
			{
				m_InfoCampos = value;
			}
		}
		private DateTime FechaHabil(DateTime Fecha, int Dias, string IdUN)
		{
			bool seEvaluaFeriadoXUN = IdUN != String.Empty;
			DateTime fechaAux = Fecha;
			int dias = Dias;
			int otroDia; if (Dias >= 0) { otroDia = 1; } else { otroDia = -1; }
			bool esFeriado;
			do
			{
				if (m_FeriadosHOST)
				{
					//Cedeira.SV.Host host = new Cedeira.SV.Host(System.Configuration.ConfigurationManager.AppSettings["Servidor"], System.Configuration.ConfigurationManager.AppSettings["Puerto"], Usuario.IdUsuario, Usuario.Password);
					//fechaAux = host.FechaHab(fechaAux, dias);
					esFeriado = false;
				}
				else
				{
					esFeriado = false;
					fechaAux = fechaAux.AddDays(Convert.ToDouble(dias));
					if (fechaAux.DayOfWeek == DayOfWeek.Saturday || fechaAux.DayOfWeek == DayOfWeek.Sunday)
					{
						esFeriado = true;
					}
				}
				dias = otroDia;
				if (!esFeriado)
				{
					//Si la fecha calculada resulta feriado, según la tabla local, para todas
					//las UNs (IdUN is null), entonces, lo dejo registrado
					dbFeriado dbFeriado = new dbFeriado(this);
					esFeriado = dbFeriado.EsFeriado(fechaAux);
					if (!esFeriado && seEvaluaFeriadoXUN)
					{
						//Si la fecha calculada resulta feriado, según la tabla local, para esta
						//UN en particular, entonces, lo dejo registrado
						esFeriado = dbFeriado.EsFeriado(fechaAux, IdUN);
					}
				}
			} while (esFeriado);
			return fechaAux;
		}
		public DateTime FechaHab(DateTime Fecha, int Dias)
		{
			return FechaHabil(Fecha, Dias, String.Empty);
		}
		public DateTime FechaHab(DateTime Fecha, int Dias, string IdUN)
		{
			return FechaHabil(Fecha, Dias, IdUN);
		}
		public DateTime FechaVto(DateTime FechaDsd, int Plazo, PlazoEn TipoPlazo, string IdUN)
		{
			switch (TipoPlazo)
			{
				case PlazoEn.DiasHabiles:
					DateTime fechaVto = FechaDsd;
					for (int i = 0; i < Plazo; i++)
					{
						fechaVto = FechaHabil(fechaVto, 1, IdUN);
					}
					return fechaVto;
				default:	// PlazoEn.DiasTotales:
					return FechaHabil(FechaDsd, Plazo, IdUN);
			}
		}
		public int Plazo(DateTime FechaDsd, DateTime FechaHst)
		{
			TimeSpan ts = FechaHst - FechaDsd;
			return ts.Days;
		}
		public DateTime[] FechasHabiles(DateTime FechaDsd, DateTime FechaHst)
		{
			System.Collections.ArrayList a = new System.Collections.ArrayList();
			int comp;
			while ((comp = DateTime.Compare(FechaDsd.Date, FechaHst.Date)) <= 0)
			{
				DateTime auxDate = FechaHab(FechaDsd, 0);
				if (auxDate.Date.CompareTo(FechaDsd) == 0)
				{
					a.Add(auxDate);
					FechaDsd = FechaDsd.AddDays(1);
				}
				else
				{
					FechaDsd = auxDate;
				}
			}
			return (DateTime[])a.ToArray(Type.GetType("System.DateTime"));
		}
		public DateTime FechaHabilXCantDiasHabiles(DateTime FechaDsd, int DiasHabiles)
		{
			DateTime a = FechaDsd;
			for (int i = 0; i < DiasHabiles; i++)
			{
				DateTime auxDate = FechaHab(a, 0);
				if (auxDate.Date.CompareTo(a) == 0 && i != (DiasHabiles - 1))
				{
					a = a.AddDays(1);
				}
				else
				{
					a = auxDate;
				}
			}
			return a;
		}
		public bool ModoDebug
		{
			get
			{
				return m_Ambiente == "DESA";
			}
		}
	}

}
