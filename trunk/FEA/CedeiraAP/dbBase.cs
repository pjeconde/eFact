using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;


namespace Cedeira.SV {
	public abstract class dbBase : IUsuario_db, IWF_db
	{
		private int commandTimeOut=90;
		private Idb_Sesion m_Sesion;
		public dbBase(Idb_Sesion Sesion)
		{
			this.m_Sesion=Sesion;
		}
		#region " Codigo de acceso a Base de datos "

		public enum TipoRetorno {None, CantReg, DV, DS, TB};
		public enum Transaccion {Acepta, NoAcepta, Usa};

		protected string[] Sqls;
		protected SqlConnection m_SqlConexion;
		
		protected MySql.Data.MySqlClient.MySqlConnection m_MySqlConnection;
		protected MySql.Data.MySqlClient.MySqlDataAdapter m_MySqlDataAdapter;
		protected MySql.Data.MySqlClient.MySqlCommand m_MySqlCommand;
		protected MySql.Data.MySqlClient.MySqlTransaction m_MySqlTransaction;

		protected SqlCommand m_SqlCommand;
		protected SqlDataAdapter m_SqlAdapter;
		protected SqlTransaction m_SqlTransaccion;
		protected bool UsaTransaccion = false;
		protected int i;
		protected int[] CantReg;
		protected DataSet DS;
		protected DataView[] DV;
		protected DataTable[] TB;

		protected object Ejecutar(object Sql, TipoRetorno TipoRetorno, Transaccion Transaccion, string CnnStrDB, int CommandTimeOut)
		{
			commandTimeOut=CommandTimeOut;
			return Ejecutar(Sql, TipoRetorno, Transaccion, CnnStrDB);
		}
		protected object Ejecutar(object Sql, TipoRetorno TipoRetorno, Transaccion Transaccion, string CnnStrDB)
		{
			/*
			ESTE ES EL UNICO METODO QUE ACCEDE A LA BASE DE DATOS Y NO DEBE SER PUBLICO PARA QUE NO SEA INVOCADO NI
			DESDE LA CAPA DE REGLA DE NEGOCIO NI DE LA DE PRESENTACION
					Sql: 1) un string con una o mas instrucciones SQL.
						 2) un string array con uno o mas strings que contengan una o mas instrucciones SQL 
							cada uno. 
			TipoRetorno: 1) None: se ejecuta como un comando y no devuelve ningun resultado
						 2) CantReg: se ejecuta como un comando y devuelve un integer, o un integer array 
							(uno por cada Sql string array), indicando la cantidad registros se vieron afectados.
						 3) DV: devuelve un dataview o un dataview array (cada uno con una tabla), 
							segun los datos obtenidos de la DB.
						 4) DS: devuelve un dataset con una o mas tablas segun los datos obtenidos de la DB. 
			Transaccion: 1) Acepta: en el caso de recibir un Sql string array, activa la transaccion.
						 2) NoAcepta: no activa la trasaccion
						 3) Usa: activa la transaccion
			*/
			TesteoConexion(CnnStrDB);
			switch (Sql.GetType().FullName.ToString())
			{
				case "System.String[]":
					Sqls = (string[]) Sql;
					break;
				default:	//case "System.String":
					Sqls = new String[] {(string) Sql};
					break;
			}
			CantReg = new int [ Sqls.Length ];
			try
			{
				if (m_MySqlConnection != null)
				{
					m_MySqlConnection.Open();
				}
				else
				{
					m_SqlConexion = new SqlConnection(CnnStrDB);
					m_SqlConexion.Open();
				}
				switch (Transaccion)
				{
					case (Transaccion.Acepta):
						UsaTransaccion = (Sqls.Length > 1);
						break;
					case (Transaccion.NoAcepta):
						UsaTransaccion = false;
						break;
					default: //(Transaccion.Usa):
						UsaTransaccion = true;
						break;
				}
				if (UsaTransaccion)  m_SqlTransaccion = m_SqlConexion.BeginTransaction();
				switch (TipoRetorno)
				{
					case (TipoRetorno.None):
					case (TipoRetorno.CantReg):
						if (m_MySqlConnection != null)
						{
							m_MySqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
							m_MySqlCommand.Connection = m_MySqlConnection;
							m_MySqlCommand.CommandTimeout = commandTimeOut;
							if (UsaTransaccion) { m_MySqlCommand.Transaction = m_MySqlTransaction; }
							for (i = 0; i < Sqls.Length; i++)
							{
								m_MySqlCommand.CommandText = Sqls[i];
								System.Diagnostics.Debug.WriteLine(m_MySqlCommand.CommandText);
								CantReg[i] = m_MySqlCommand.ExecuteNonQuery();
							}
						}
						else
						{
							m_SqlCommand = new SqlCommand();
							m_SqlCommand.Connection = m_SqlConexion;
							m_SqlCommand.CommandTimeout = commandTimeOut;
							if (UsaTransaccion) { m_SqlCommand.Transaction = m_SqlTransaccion; }
							for (i = 0; i < Sqls.Length; i++)
							{
								m_SqlCommand.CommandText = Sqls[i];
								System.Diagnostics.Debug.WriteLine(m_SqlCommand.CommandText);
								CantReg[i] = m_SqlCommand.ExecuteNonQuery();
							}
						}
						break;
					case (TipoRetorno.DS):
					case (TipoRetorno.DV):
					case (TipoRetorno.TB):
						DS = new DataSet();
						for (i = 0; i<Sqls.Length; i++)
						{
							System.Diagnostics.Debug.WriteLine(Sqls[i]);

							if (m_MySqlConnection != null)
							{
								m_MySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(Sqls[i], m_MySqlConnection);
								if (UsaTransaccion) { m_MySqlDataAdapter.SelectCommand.Transaction = m_MySqlTransaction; }
								m_MySqlDataAdapter.SelectCommand.CommandTimeout = commandTimeOut;
								if (i == 0)
								{
									m_MySqlDataAdapter.Fill(DS);
								}
								else
								{
									DS.Tables.Add();
									m_MySqlDataAdapter.Fill(DS.Tables[DS.Tables.Count - 1]);
								}
							}
							else
							{
								m_SqlAdapter = new SqlDataAdapter(Sqls[i], m_SqlConexion);
								if (UsaTransaccion) { m_SqlAdapter.SelectCommand.Transaction = m_SqlTransaccion; }
								m_SqlAdapter.SelectCommand.CommandTimeout = commandTimeOut;
								if (i == 0)
								{
									m_SqlAdapter.Fill(DS);
								}
								else
								{
									DS.Tables.Add();
									m_SqlAdapter.Fill(DS.Tables[DS.Tables.Count - 1]);
								}
							}
						}
						switch (TipoRetorno)
						{
							case (TipoRetorno.DV):
								if (DS.Tables.Count > 0)
								{
									DV = new DataView[DS.Tables.Count];
									for (i = 0; i<DS.Tables.Count; i++)
									{
										DV[i] = DS.Tables[i].DefaultView;
									}
								}
								break;
							case (TipoRetorno.TB):
								if (DS.Tables.Count > 0)
								{
									TB = new DataTable[DS.Tables.Count];
									for (i = 0; i<DS.Tables.Count; i++)
									{
										TB[i] = DS.Tables[i];
									}
								}
								break;
							default:
								break;
						}
						break;
				}//end switch
				if (UsaTransaccion) {m_SqlTransaccion.Commit();}
				if (m_MySqlConnection != null)
				{
					m_MySqlConnection.Close();
				}
				else
				{
					m_SqlConexion.Close();
				}
				switch (TipoRetorno)
				{
					case TipoRetorno.None:
						return new System.Object();
					case TipoRetorno.CantReg:
						if (Sqls.Length > 1) 
						{
							return CantReg; 
						}
						else 
						{
							return CantReg[0];
						}
					case TipoRetorno.DS:
						return DS;
					case TipoRetorno.TB:
						switch (DS.Tables.Count)
						{
							case 0:
								return new DataTable();
							case 1:
								return TB[0];
							default:
								return TB;
						}
					default: //case TipoRetorno.DV:
						switch (DS.Tables.Count)
						{
							case 0:
								return new DataView();
							case 1:
								return DV[0];
							default:
								return DV;
						}
				}
			}
			catch (System.Data.SqlClient.SqlException ex1)
			{
				if (((System.Data.SqlClient.SqlException)(ex1)).Procedure=="ConnectionOpen (Connect()).")
				{
					throw new Cedeira.Ex.db.Conexion(ex1);
				}
				else
				{
					if (UsaTransaccion)
					{
						try
						{
							m_SqlTransaccion.Rollback();
							throw new Cedeira.Ex.db.EjecucionConRollback(ex1); 
						}
						catch (Cedeira.Ex.db.EjecucionConRollback)
						{
							throw new Cedeira.Ex.db.EjecucionConRollback(ex1);
						}
						catch
						{
							throw new Cedeira.Ex.db.Rollback(ex1);
						}
					}
					else
					{
						throw new Cedeira.Ex.db.Ejecucion(ex1) ; 
					}
				}
			}
		}
		public void TesteoConexion(string CnnStrDB)
		{
			try
			{
				m_MySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(CnnStrDB);
				m_MySqlConnection.Open();
				m_MySqlConnection.Close();				
			}
			catch(Exception)
			{
				try
				{
					m_SqlConexion = new SqlConnection(CnnStrDB);
					m_SqlConexion.Open();
					m_SqlConexion.Close();
				}
				catch (Exception ex)
				{
					throw new Cedeira.Ex.db.Conexion(ex) ; 
				}
			}
		}
		#endregion
		#region " Codigo implementa Interfaz IdbUsuario "

		public DataView US_Usuario_get (string IdUsuario) {
			return (DataView) Ejecutar("Select * from WCUsuarios where IdUsuario='" + IdUsuario + "'", 
				TipoRetorno.DV, 
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}

		public DataView US_Usuario_qry() {
			return (DataView) Ejecutar("Select * from WCUsuarios where IdUsuario<>'XNoDefine' order by Nombre", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}

		public DataView US_GruposXUsuario_get(string IdUsuario, bool Pertenece) {
			if (Pertenece) {
				return (DataView) Ejecutar("Select WCGrupos.IdGrupo, WCTbGrupos.Descr, Supervisor, SupervisorNivel, Descr+' '+'('+WCGrupos.IdGrupo+'): '+case Supervisor when 1 then 'SP, ' else 'no SP, ' end+'NV='+convert(varchar,SupervisorNivel) as DescrGrupoSPyNV, WCTbGrupos.IdTGrupo from WCGrupos, WCTbGrupos where IdUsuario='" + IdUsuario + "' and WCGrupos.IdGrupo=WCTbGrupos.IdGrupo order by WCTbGrupos.Descr", 
					TipoRetorno.DV, 
					Transaccion.NoAcepta, 
					m_Sesion.CnnStr);
			}
			else {
				return (DataView) Ejecutar("Select WCTbGrupos.IdGrupo, WCTbGrupos.Descr from WCTbGrupos where IdGrupo not in (Select IdGrupo from WCGrupos where IdUsuario='" + IdUsuario + "') order by WCTbGrupos.Descr", 
					TipoRetorno.DV,
					Transaccion.NoAcepta, 
					m_Sesion.CnnStr);
			}
		}

		#endregion
		#region " Codigo implementa Interfaz IdbWF "
		public DataView WF_Op_get (int IdOp, Alcance Particion) {
		string e="Select WF_Op.*, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado  "+
				"from WF_Op, WF_Flow, WF_Circuito, WF_NivSeg, WF_Estado "+
				"where IdOp="+IdOp+" and WF_Op.IdFlow=WF_Flow.IdFlow and WF_Op.IdCircuito=WF_Circuito.IdCircuito and WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg and WF_Op.IdEstado=WF_Estado.IdEstado ";
			if (Particion==Alcance.SoloDatosActuales)
			{
				e=e+("and WF_Op.DatoActual=1 ");
			}
			return (DataView) Ejecutar(
				e, 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_LogXOp_qry(int IdOp, Alcance Particion) {
			string e="Select "+
				"WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, "+
				"WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, "+
				"WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo "+
				"from WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos "+
				"where IdOp="+IdOp+" and WF_Log.IdUsuario=WCUsuarios.IdUsuario "+
				"and WF_Log.IdFlow=WF_Evento.IdFlow "+
				"and WF_Log.IdFlow=WF_Flow.IdFlow "+
				"and WF_Log.IdCircuito=WF_Circuito.IdCircuito "+
				"and WF_Log.IdGrupo=WCTbGrupos.IdGrupo "+
				"and WF_Log.IdEvento=WF_Evento.IdEvento and WF_Log.IdEstado=WF_Estado.IdEstado ";
			if (Particion==Alcance.SoloDatosActuales)
			{
				e=e+ "and WF_Log.DatoActual=1";
			}
			return (DataView) Ejecutar(
				e, 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_EventosIniciales_qry(string IdFlow) {
			string a="Select WF_Evento.*, WF_Flow.DescrFlow, EstadoHst.DescrEstado as DescrEstadoHst "+
					 "from WF_Evento, WF_Flow, WF_Estado EstadoHst "+
					 "where WF_Evento.IdFlow='"+IdFlow+"' and WF_Evento.IdEstadoDsd is null "+
					 "and WF_Evento.IdFlow=WF_Flow.IdFlow and EstadoHst.IdEstado=WF_Evento.IdEstadoHst";
			return (DataView) Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_EventosIniciales_qry() {
			return (DataView) Ejecutar(
				"select IdFlow+'-'+IdEvento as IdEventoInicial from WF_Evento where IdEstadoDsd is null", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_EventosPosibles_qry(string IdFlow, string IdEstadoDsd, string IdCircuito) {
			string a="Select WF_Evento.*, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst "+
				"from WF_Evento, WF_Flow, WF_Estado EstadoDsd, WF_Estado EstadoHst "+
				"where WF_Evento.IdFlow='"+IdFlow+"' and WF_Evento.IdEstadoDsd in ('"+IdEstadoDsd+"', '<Cualquiera>') "+
				"and WF_Evento.IdFlow=WF_Flow.IdFlow "+
				"and EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd and EstadoHst.IdEstado=WF_Evento.IdEstadoHst "+
				"and WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito='"+IdCircuito+"' and IdFlow='"+IdFlow+"') ";
			return (DataView) Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_EventosXLotePosibles_qry(string IdFlow, string IdEstadoDsd, string IdCircuito) 
		{
			string a="Select WF_Evento.*, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst "+
				"from WF_Evento, WF_Flow, WF_Estado EstadoDsd, WF_Estado EstadoHst "+
				"where WF_Evento.IdFlow='"+IdFlow+"' and WF_Evento.IdEstadoDsd in ('"+IdEstadoDsd+"', '<Cualquiera>') "+
				"and WF_Evento.IdFlow=WF_Flow.IdFlow "+
				"and EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd and EstadoHst.IdEstado=WF_Evento.IdEstadoHst "+
				"and WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito='"+IdCircuito+"' and IdFlow='"+IdFlow+"') "+
				"and WF_Evento.XLote=1 ";
			return (DataView) Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_EsquemaSegEventosPosibles_qry(string IdFlow, string IdCircuito, int IdNivSeg, string[] Eventos) 
		{
			string ListaEventos="";
			for (int i = 0; i<Eventos.Length; i++) {
				ListaEventos=ListaEventos+"'"+Eventos[i]+"'";
				if (i!=Eventos.Length-1) {
					ListaEventos=ListaEventos+", ";
				}
			}
			if (ListaEventos=="") ListaEventos="''";
			string a="select WF_EsquemaSeg.IdEvento, WF_EsquemaSeg.CantInterv, WF_EsquemaSeg.IdGrupo, WF_EsquemaSeg.DebeSerSP, WF_EsquemaSeg.SupervisorNivelDsd, WF_EsquemaSeg.SupervisorNivelHst, WCTbGrupos.Descr as DescrGrupo, WF_Evento.DescrEvento "+
				"from WF_EsquemaSeg, WCTbGrupos, WF_Evento "+
				"where WF_EsquemaSeg.IdFlow='"+IdFlow+"' and WF_EsquemaSeg.IdCircuito='"+IdCircuito+"' and (WF_EsquemaSeg.IdNivSeg="+IdNivSeg+" or WF_EsquemaSeg.IdNivSeg=0) and WF_EsquemaSeg.IdEvento in ("+ListaEventos+") "+
				"and WF_EsquemaSeg.IdGrupo=WCTbGrupos.IdGrupo "+
				"and WF_EsquemaSeg.IdFlow=WF_Evento.IdFlow and WF_EsquemaSeg.IdEvento=WF_Evento.IdEvento";
			return (DataView) Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Flow_get (string IdFlow) {
			return (DataView) Ejecutar("Select * from WF_Flow where IdFlow='" + IdFlow + "'", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Circuito_get (string IdCircuito) {
			return (DataView) Ejecutar("Select * from WF_Circuito where IdCircuito='" + IdCircuito + "'", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_NivSeg_get (int IdNivSeg) {
			return (DataView) Ejecutar("Select * from WF_NivSeg where IdNivSeg=" + IdNivSeg, 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Flow_lst () {
			return (DataView) Ejecutar("Select IdFlow as Id, DescrFlow as Descr from WF_Flow", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Circuito_lst () {
			return (DataView) Ejecutar("Select IdCircuito as Id, DescrCircuito as Descr from WF_Circuito", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_NivSeg_lst () {
			return (DataView) Ejecutar("Select IdNivSeg as Id, DescrNivSeg as Descr from WF_NivSeg", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Estado_lst () {
			return (DataView) Ejecutar("select WF_Estado.IdEstado as Id, DescrEstado as Descr, IdFlow, EstadoFinal from WF_Estado, WF_EstadoXFlow where WF_Estado.IdEstado=WF_EstadoXFlow.IdEstado and Virtual<>1 order by IdFlow, EstadoFinal", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Acceso_lst () {
			return (DataView) Ejecutar("Select IdAcceso as Id, DescrAcceso as Descr from WF_Acceso", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Estado_qry () 
		{
			return (DataView) Ejecutar("select IdEstado as Id, DescrEstado as Descr from WF_Estado where Virtual<>1 order by DescrEstado", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Estado_qry (string IdFlow) 
		{
			return (DataView) Ejecutar("select WF_Estado.IdEstado as Id, WF_Estado.DescrEstado as Descr from WF_Estado, WF_EstadoXFlow where WF_Estado.IdEstado=WF_EstadoXFlow.IdEstado and WF_EstadoXFlow.IdFlow='"+IdFlow+"' and WF_Estado.Virtual<>1 order by DescrEstado", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_OpsEnTramite_lst (Alcance Particion) 
		{
			string e="Select * from WF_Op ";
			if (Particion==Alcance.SoloDatosActuales)
			{
				e=e+"where DatoActual=1";
			}
			return (DataView) Ejecutar(e, 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public string WF_Op_insHandler (string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel) {
			string e="insert WF_Op values ('"+IdFlow+"', '"+IdCircuito+"', "+IdNivSeg+", '"+IdEstado+"', '"+DescrOp+"', null";
				e=e+", 1) ";
				e=e+"declare @IdOp int " +
				"select @IdOp=@@Identity "+
				"insert WF_Log values (@IdOp, '"+IdUsuario+"', '"+IdFlow+"', '"+IdCircuito+"', "+IdNivSeg+", '"+IdEvento+"', getdate(), '"+Comentario+"', '"+IdEstado+"', '"+IdGrupo+"', "+System.Math.Abs(Convert.ToSByte(Supervisor))+", "+SupervisorNivel;
				e=e+", 1) ";
			return e;
		}
		public DataView WF_Op_ins (string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel) {
			return (DataView) Ejecutar(
				WF_Op_insHandler (IdFlow, IdCircuito, IdNivSeg, IdEstado, DescrOp, IdEvento, IdUsuario, Comentario, IdGrupo, Supervisor, SupervisorNivel), 
				TipoRetorno.DV,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public string WF_Op_updHandler (int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz) {
			return
				"update WF_Op set IdEstado='"+IdEstado+"', IdCircuito='"+IdCircuito+"', IdNivSeg="+IdNivSeg+" where IdOp="+IdOp+" and UltActualiz="+UltActualiz+" "+
				"if @@rowcount=0 "+
				"   raiserror ('WorkFlow de la operacion inexistente o contenido modificado por otro usuario', 16, 1) "+
				"else "+
				"   begin "+
				"      insert WF_Log values ("+IdOp+", '"+IdUsuario+"', '"+IdFlow+"', '"+IdCircuito+"', "+IdNivSeg+", '"+IdEvento+"', getdate(), '"+Comentario+"', '"+IdEstado+"', '"+IdGrupo+"', "+System.Math.Abs(Convert.ToSByte(Supervisor))+", "+SupervisorNivel+", 1) ";
		}
		public void WF_Op_upd (int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz) 
		{
			Ejecutar(
				"update WF_Op set IdEstado='"+IdEstado+"', IdCircuito='"+IdCircuito+"', IdNivSeg="+IdNivSeg+" where IdOp="+IdOp+" and UltActualiz="+UltActualiz+" "+
				"insert WF_Log values ("+IdOp+", '"+IdUsuario+"', '"+IdFlow+"', '"+IdCircuito+"', "+IdNivSeg+", '"+IdEvento+"', getdate(), '"+Comentario+"', '"+IdEstado+"', '"+IdGrupo+"', "+System.Math.Abs(Convert.ToSByte(Supervisor))+", "+SupervisorNivel+", 1)",
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public string WF_Log_insHandler (int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel) 
		{
			string e="insert WF_Log values ("+IdOp+", '"+IdUsuario+"', '"+IdFlow+"', '"+IdCircuito+"', "+IdNivSeg+", '"+IdEvento+"', getdate(), '"+Comentario+"', '"+IdEstado+"', '"+IdGrupo+"', "+System.Math.Abs(Convert.ToSByte(Supervisor))+", "+SupervisorNivel;
				e=e+" , 1) ";
			return  e;
		}
		public void WF_Log_ins (int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel) {
			Ejecutar(
				WF_Log_insHandler (IdOp, IdFlow, IdCircuito, IdNivSeg, IdEstado, IdEvento, IdUsuario, Comentario, IdGrupo, Supervisor, SupervisorNivel),
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public void WF_EjecutarHandler (string Handler) {
			string a=Handler+" ";
			a=a+"   end";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public void WF_EjecutarHandlerEventoInicial (string Handler) 
		{
			string a=Handler+" ";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Parm_get (string IdParm) {
			return (DataView) Ejecutar(
				"select * from WF_Parm where IdParm='"+IdParm+"'", 
				TipoRetorno.DV, 
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public void WF_ParmValorInt_upd(string IdParm, int Valor)
		{
			string a="update WF_Parm set ValorInt="+Valor+" where IdParm='"+IdParm+"'"; 
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public void WF_ParmValorStr_upd(string IdParm, string Valor)
		{
			string a="update WF_Parm set ValorStr='"+Valor+"' where IdParm='"+IdParm+"'"; 
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa, 
				m_Sesion.CnnStr);
		}
		public DataView WF_GruposXAcceso_qry (string IdAcceso) 
		{
			return (DataView) Ejecutar("select * from WCTbGrupos where IdGrupo in (select IdGrupo from WF_PermisoGrupoXAcceso where IdAcceso='"+IdAcceso+"' and Permiso=1)", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataView WF_Acceso_get (string IdGrupo, string IdAcceso) {
			return (DataView) Ejecutar("select * from WF_PermisoGrupoXAcceso where IdGrupo='"+IdGrupo+"' and IdAcceso='"+IdAcceso+"'", 
				TipoRetorno.DV,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public string WF_GetAssemblyVersion_qry() 
		{
			return ((DataView) Ejecutar("select AssemblyVersion from WF_Acceso where IdAcceso='"+m_Sesion.IdAcceso+"'", 
				TipoRetorno.DV, Transaccion.NoAcepta, m_Sesion.CnnStr)).Table.Rows[0][0].ToString();
		}	
		public bool CXO () 
		{
			return Convert.ToInt32(WF_Parm_get("CXO").Table.Rows[0]["ValorInt"])==1;
		}
		#endregion

		public DateTime FechaDB
		{
			get {
				DataView dv=(DataView) Ejecutar("select getdate()", TipoRetorno.DV, Transaccion.NoAcepta, m_Sesion.CnnStr);
				return (DateTime) dv.Table.Rows[0][0];
			}
		}
		public static string ByteArray2TimeStamp(byte[] ts )
		{
			string a="0x";
			for (int i=0; i<ts.Length; i++)
			{
				if (ts[i].ToString("X").Length==1)
				{
					a+="0"+ts[i].ToString("X");
				}
				else
				{
					a+=ts[i].ToString("X");
				}
			}
			return a;
		}
		public static byte[] TimeStamp2ByteArray(string value)
		{
			byte[] b = new byte[8];
			for (int i=0; i<8; i++)
			{
				string a=value.Substring(i*2+2,2);
				b[i]=Convert.ToByte(a,16);
			}
			return b;
		}
		public DataTable CamposHabilitados_qry (string Tabla, string ListaCamposHabilitados) 
		{
			string a;
			if (ListaCamposHabilitados.Trim()!="")
			{
				a="select "+ListaCamposHabilitados+" from "+Tabla+" where 0=1";
			}
			else
			{
				a="select null from "+Tabla+" where 0=1";
			}
			return (DataTable) Ejecutar(
				a, 
				TipoRetorno.TB,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataTable CamposHabilitados_qry (string[] Tabla, string ListaCamposHabilitados) 
		{
			StringBuilder a=new StringBuilder();
				if (ListaCamposHabilitados.Trim()!="")
				{
					a.Append("select "+ListaCamposHabilitados+" from ");
					for(int i=0;i<Tabla.Length;i++)
					{
						a.Append(Tabla[i]);
						if(i!=Tabla.Length-1)
						{
							a.Append(",");
						}
					}
					a.Append(" where 0=1");
				}
				else
				{
					a.Append("select null from "+Tabla[0]+" where 0=1");
				}

			return (DataTable) Ejecutar(
				a.ToString(), 
				TipoRetorno.TB,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public DataTable InfoCamposHabilitados_qry (string Tabla, DataTable CamposHabilitados) 
		{
			string a="and Propiedad in (";
			for (int i=0;i<CamposHabilitados.Columns.Count;i++) 
			{
				a+="'"+CamposHabilitados.Columns[i].ColumnName+"', ";
			}
			a = a.Substring(0,a.Length-2)+")";
			DataTable dt = m_Sesion.InfoCampos.Clone();
			DataRow[] drs = m_Sesion.InfoCampos.Select("NombreTabla = '"+Tabla+"' "+a);
			Cedeira.SV.Fun fun = new Cedeira.SV.Fun();
			fun.AgregarFilas(dt, drs);
			return dt;
		}
		public DataTable InfoCamposHabilitados_qry (string[] Tabla, DataTable CamposHabilitados) 
		{
			string a="and Propiedad in (";
			for (int i=0;i<CamposHabilitados.Columns.Count;i++) 
			{
				a+="'"+CamposHabilitados.Columns[i].ColumnName+"', ";
			}
			a = a.Substring(0,a.Length-2)+")";
			DataTable dt = m_Sesion.InfoCampos.Clone();
			StringBuilder tablas=new StringBuilder();
			for(int i=0;i<Tabla.Length;i++)
			{
				tablas.Append("'");
				tablas.Append(Tabla[i]);
				if(i!=Tabla.Length-1)
				{
					tablas.Append("',");
				}
				else
				{
					tablas.Append("'");
				}
			}
			DataRow[] drs = m_Sesion.InfoCampos.Select("NombreTabla in ("+tablas.ToString()+") "+a);
			Cedeira.SV.Fun fun = new Cedeira.SV.Fun();
			fun.AgregarFilas(dt, drs);
			return dt;
		}
		public DataTable InfoCampos_qry (string NombreTabla) 
		{
			DataTable dt = m_Sesion.InfoCampos.Clone();
			DataRow[] drs = m_Sesion.InfoCampos.Select("NombreTabla = '"+NombreTabla+"'");
			Cedeira.SV.Fun fun = new Cedeira.SV.Fun();
			fun.AgregarFilas(dt, drs);
			return dt;
		}
		public DataTable InfoCampos_qry (string[] Tabla) 
		{
			StringBuilder tablas=new StringBuilder();
			for(int i=0;i<Tabla.Length;i++)
			{
				tablas.Append("'");
				tablas.Append(Tabla[i]);
				if(i!=Tabla.Length-1)
				{
					tablas.Append("',");
				}
				else
				{
					tablas.Append("'");
				}
			}			
			
			DataTable dt = m_Sesion.InfoCampos.Clone();
			DataRow[] drs = m_Sesion.InfoCampos.Select("NombreTabla in ("+tablas.ToString()+")");
			Cedeira.SV.Fun fun = new Cedeira.SV.Fun();
			fun.AgregarFilas(dt, drs);
			return dt;
		}
		public DataTable InfoCampos_qry ()
		{
			StringBuilder a = new StringBuilder(string.Empty);
			a.Append("select sysobjects.name NombreTabla, syscolumns.name Propiedad,systypes.name Tipo,syscolumns.length Long,syscolumns.xprec-syscolumns.xscale Enteros, syscolumns.xscale Decimales, isnull(sys.extended_properties.value, syscolumns.name) Descripcion ");
			a.Append("from syscolumns ");
			a.Append("inner join sysobjects on syscolumns.id=sysobjects.id ");
			a.Append("inner join systypes on systypes.xtype=syscolumns.xtype ");
			a.Append("left outer join sys.extended_properties on syscolumns.id=sys.extended_properties.major_id and syscolumns.colid=sys.extended_properties.minor_id ");
			return (DataTable) Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, m_Sesion.CnnStr);
		}
		public void DepurarFila(string NombreTabla, string Id)
		{
			string a="delete "+NombreTabla+" where Id"+NombreTabla+"='"+Id+"'";
			Ejecutar(
				a, 
				TipoRetorno.None,
				Transaccion.NoAcepta, 
				m_Sesion.CnnStr);
		}
		public string SevidoryDB()
		{
			return SevidoryDB(m_Sesion.CnnStr);
		}
		public string SevidoryDB(string CnnStrDB)
		{
			try
			{
				m_SqlConexion = new SqlConnection(CnnStrDB);
				return m_SqlConexion.DataSource+"."+m_SqlConexion.Database;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw new Cedeira.Ex.db.Conexion(ex) ; 
			}
		}
		public string ReemplazarApostrofos(string cadena)
		{
			string aux=cadena.Replace("'","''");
			return aux;
		}
	}
}
