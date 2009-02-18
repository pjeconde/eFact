using System;
using System.Data;
using System.Security.Principal;
using System.DirectoryServices;
using System.Runtime.Serialization; 

namespace Cedeira.SV {
	public class Usuario {
		private IUsuario_Sesion m_Sesion;
		private IUsuario_db m_db;
		private string m_IdUsuario = "";
		private string m_Password = "";
		private string  m_Nombre = "";
		private bool m_Activo = true;
		private string  m_Alias = "";
		private DateTime m_FecAlta = System.DateTime.Now;
		private System.DateTime m_FecBaja = new DateTime(2064, 12, 31);
		private string m_Email = "";
		private DataView m_PerteneceA;
		private DataView m_NoPerteneceA;
		public Usuario(string IdUsuario, string Password, IUsuario_Sesion Sesion, IUsuario_db db) {
			m_Password=Password;
			m_db=db;
			m_Sesion = Sesion;
			//Leer(IdUsuario);
		}
		public Usuario(string IdUsuario, IUsuario_Sesion Sesion, IUsuario_db db) : this(IdUsuario, "", Sesion, db) {
		}
		public Usuario(IUsuario_Sesion Sesion, IUsuario_db db) {
			m_Sesion = Sesion;
		}
		public string IdUsuario {
			get {return m_IdUsuario;}
		}
		public string Password {
			get {return m_Password;}
		}
		public string Nombre {
			get {return m_Nombre;}
		}
		public bool Activo {
			get {return m_Activo;}
		}
		public string Alias {
			get {return m_Alias;}
		}
		public System.DateTime FecAlta {
			get {return m_FecAlta;}
		}
		public System.DateTime FecBaja {
			get {return m_FecBaja;}
		}
		public string Email {
			get {return m_Email;}
		}
		public DataView PerteneceA {
			get {return m_PerteneceA;}
		}
		public DataView NoPerteneceA {
			get {return m_NoPerteneceA;}
		}
		public DataView Lista() {
			return m_db.US_Usuario_qry();
		}
		public void Leer(string IdUsuario) {
			DataView dv=m_db.US_Usuario_get(IdUsuario);
			if (dv.Table.Rows.Count != 0) {
				m_IdUsuario = Convert.ToString(dv.Table.Rows[0]["IdUsuario"]);
				m_Nombre = Convert.ToString(dv.Table.Rows[0]["Nombre"]);
				m_Activo = Convert.ToBoolean(dv.Table.Rows[0]["Activo"]);
				if (dv.Table.Rows[0]["Alias"] != System.DBNull.Value) {
					m_Alias = Convert.ToString(dv.Table.Rows[0]["Alias"]);
				}
				else {
					m_Alias = "";
				}
				m_FecAlta = Convert.ToDateTime(dv.Table.Rows[0]["FecAlta"]);
				m_FecBaja = Convert.ToDateTime(dv.Table.Rows[0]["FecBaja"]);
				if (dv.Table.Rows[0]["Email"] != System.DBNull.Value) {
					m_Email = Convert.ToString(dv.Table.Rows[0]["Email"]);
				}
				else {
					m_Email = "";
				}
				dv = null;
				// Grupos a los que pertenece
				DataColumn[] Claves;
				m_PerteneceA = m_db.US_GruposXUsuario_get(m_IdUsuario, true);
				Claves = new DataColumn[] {m_PerteneceA.Table.Columns["IdGrupo"]};
				m_PerteneceA.Table.PrimaryKey = Claves;

				m_NoPerteneceA = m_db.US_GruposXUsuario_get(m_IdUsuario, false);
				Claves= new DataColumn[] {m_NoPerteneceA.Table.Columns["IdGrupo"]};
				m_NoPerteneceA.Table.PrimaryKey = Claves;
			}
			else {
				throw new Cedeira.Ex.Usuario.Inexistente();
			}
		}
	}
	public class AutenticacionLDAP {
		string domainData="";
		string setValue="";
		public string ldapDomain {
			get {return setValue;}
			set {
				try {
					string[] a;
					setValue=value;
					a=setValue.Split(Convert.ToChar("."));
					domainData="LDAP://CN=<full user name>, CN=<Users>,DC="+a[a.GetUpperBound(0)];
					for (int i=a.GetLowerBound(0)+1;i<a.GetUpperBound(0);i++) {
						domainData = domainData+",DC="+a[i];
					}
				}
				catch (System.Exception ex) {
	                throw new System.Exception("Datos para ldapDomain incorrectos: "+ex.Message);
				}
			}
		}
		public void Chequear(string SamAccount, string password) {
			string sPath = domainData;
			DirectoryEntry myDirectory=new DirectoryEntry("LDAP://DC=bgcmz.bancogalicia.com.ar,DC=bancogalicia.com.ar,DC=com,DC=ar",SamAccount,password,System.DirectoryServices.AuthenticationTypes.Secure);
			DirectorySearcher mySearcher=new DirectorySearcher(myDirectory);
			SearchResult mySearchResult;
			try{
				mySearchResult=mySearcher.FindOne();
			}
			catch(System.Runtime.InteropServices.COMException ex){
				System.Diagnostics.Debug.WriteLine(ex.GetType().ToString());
				if(ex.ErrorCode==-2147023570){
					throw ex;
				}
			}
		}
	}
}
