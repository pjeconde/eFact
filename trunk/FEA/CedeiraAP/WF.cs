using System;
using System.Data;
using Cedeira.Ex;
using System.Runtime.Serialization; 

namespace Cedeira.SV {
	public class WF {
		protected bool m_CXO;
		protected int m_IdOp;
		protected string m_IdFlow="";
		protected string m_DescrFlow="";
		protected string m_IdCircuito="";
		protected string m_IdCircuitoOrig="";
		protected string m_DescrCircuito="";
		protected int m_IdNivSeg=0;
		protected string m_DescrNivSeg="";
		protected string m_IdEstado="";
		protected string m_DescrEstado="";
		protected string m_DescrOp="";
		protected string m_UltActualiz="";
		protected Alcance m_DatoActual;
		protected IWF_Sesion m_Sesion;
		protected IWF_db m_db;
		protected DataView m_Log;
		protected DataView m_EventosPosibles;
		protected DataView m_EventosXLotePosibles;
		
		// Operacion existente
		public WF(int IdOp, IWF_Sesion Sesion, IWF_db db, Alcance Particion) 
		{
			m_Sesion=Sesion;
			m_CXO=m_Sesion.CXO;
			m_db=db;
			Leer(IdOp, Particion);
		}
		// Otros servicios
		public WF(IWF_Sesion Sesion, IWF_db db) {
			m_Sesion=Sesion;
			m_CXO=m_Sesion.CXO;
			m_db=db;
		}
		public void Nueva (string IdFlow,  string IdCircuito, int IdNivSeg, string DescrOp) {
			DataView dv=m_db.WF_Flow_get(IdFlow);
			if (dv.Table.Rows.Count != 0) {
				m_IdFlow=IdFlow;
				m_DescrFlow=Convert.ToString(dv.Table.Rows[0]["DescrFlow"]);
			}
			else {
				throw new Cedeira.Ex.WF.FlowInvalido();
			}
			dv=m_db.WF_Circuito_get(IdCircuito);
			if (dv.Table.Rows.Count != 0) {
				m_IdCircuito=IdCircuito;
				m_IdCircuitoOrig=m_IdCircuito;
				m_DescrCircuito=Convert.ToString(dv.Table.Rows[0]["DescrCircuito"]);
			}
			else {
				throw new Cedeira.Ex.WF.CircuitoInvalido();
			}
			dv=m_db.WF_NivSeg_get(IdNivSeg);
			if (dv.Table.Rows.Count != 0) {
				m_IdNivSeg=IdNivSeg;
				m_DescrNivSeg=Convert.ToString(dv.Table.Rows[0]["DescrNivSeg"]);
			}
			else {
				throw new Cedeira.Ex.WF.NivSegInvalido();
			}
			m_DescrOp=DescrOp;
			m_IdOp=0;
			m_IdEstado="";
			m_UltActualiz="";
			m_DescrEstado="";
			m_DatoActual=Alcance.SoloDatosActuales;
			m_Log = LeerLog(0, m_DatoActual);
			m_EventosPosibles = LeerEventosPosiblesOpNueva(m_IdFlow, m_IdCircuito, m_IdNivSeg);
		}
		public void Leer (int IdOp, Alcance Particion) {
			DataView dv=m_db.WF_Op_get(IdOp, Particion);
			if (dv.Table.Rows.Count != 0) {
				// Info OpWF
				m_IdOp=IdOp;
				m_IdFlow=Convert.ToString(dv.Table.Rows[0]["IdFlow"]);
				m_DescrFlow=Convert.ToString(dv.Table.Rows[0]["DescrFlow"]);
				m_IdCircuito=Convert.ToString(dv.Table.Rows[0]["IdCircuito"]);
				m_IdCircuitoOrig=m_IdCircuito;
				m_DescrCircuito=Convert.ToString(dv.Table.Rows[0]["DescrCircuito"]);
				m_IdNivSeg=Convert.ToInt32(dv.Table.Rows[0]["IdNivSeg"]);
				m_DescrNivSeg=Convert.ToString(dv.Table.Rows[0]["DescrNivSeg"]);
				m_DescrOp=Convert.ToString(dv.Table.Rows[0]["DescrOp"]);
				m_IdEstado=Convert.ToString(dv.Table.Rows[0]["IdEstado"]);
				m_UltActualiz=Cedeira.SV.dbBase.ByteArray2TimeStamp((byte[]) dv.Table.Rows[0]["UltActualiz"]);
				m_DescrEstado=Convert.ToString(dv.Table.Rows[0]["DescrEstado"]);
				if (Convert.ToBoolean(dv.Table.Rows[0]["DatoActual"])==true)
				{
					m_DatoActual=Alcance.SoloDatosActuales;
				}
				else
				{
					m_DatoActual=Alcance.TodosLosDatos;
				}
				m_Log = LeerLog(m_IdOp, m_DatoActual);
				m_EventosPosibles = LeerEventosPosiblesOpExist(m_IdFlow, m_IdEstado, m_IdCircuito, m_IdNivSeg);
				m_EventosXLotePosibles = LeerEventosXLotePosiblesOpExist(m_IdFlow, m_IdEstado, m_IdCircuito, m_IdNivSeg);
				dv = null;
			}
			else {
				dv = null;
				throw new Cedeira.Ex.WF.OpInexistente();
			}
		}
		public bool CXO {get{return m_CXO;}}
		public int IdOp {get{return m_IdOp;}}
		public string IdFlow {get{return m_IdFlow;}}
		public string DescrFlow {get{return m_DescrFlow;}}
		public string IdCircuito{get{return m_IdCircuito;} set{m_IdCircuito=value;}}
		public string DescrCircuito{get{return m_DescrCircuito;}}
		public int IdNivSeg{get{return m_IdNivSeg;} set{m_IdNivSeg=value;}}
		public string DescrNivSeg{get{return m_DescrNivSeg;}}
		public string IdEstado{get{return m_IdEstado;}}
		public string DescrEstado{get{return m_DescrEstado;}}
		public string DescrOp{get{return m_DescrOp;}}
		public string UltActualiz{get{return m_UltActualiz;}}
		public DataView GruposXAcceso(string IdAcceso) {return m_db.WF_GruposXAcceso_qry(IdAcceso);}
		public DataView Log{get{return m_Log;}}
		public DataView EventosPosibles{get{return m_EventosPosibles;}}
		public DataView EventosXLotePosibles{get{return m_EventosXLotePosibles;}}
		public DataView EsquemaSegEventosPosibles{get{return LeerEsquemaSegEventosPosibles(m_IdFlow, m_IdCircuitoOrig, m_IdNivSeg, m_IdEstado, ref m_EventosPosibles, m_Log);}}
		public DataView OpsEnTramite{get{return m_db.WF_OpsEnTramite_lst(m_DatoActual);}}
		public DataView EventosIniciales {
			get {
				DataColumn[] Claves;
				DataView dv=m_db.WF_EventosIniciales_qry();
				Claves = new DataColumn[] {dv.Table.Columns["IdEventoInicial"]};
				dv.Table.PrimaryKey = Claves;
				return dv;
			}
		}
		public DataView IdFlowCombo {get{return m_db.WF_Flow_lst();}}
		public DataView IdCircuitoCombo{get{return m_db.WF_Circuito_lst();}}
		public DataView IdNivSegCombo{get{return m_db.WF_NivSeg_lst();}}
		public DataView IdEstadoCombo{get{return m_db.WF_Estado_qry();}}
		public DataView IdEstadoXFlowCombo(string IdFlow){return m_db.WF_Estado_qry(IdFlow);}
		public DataView IdAccesoCombo{get{return m_db.WF_Acceso_lst();}}

		protected DataView LeerLog (int IdOp, Alcance Particion) {
			DataColumn[] Claves;
			DataView dv;
			dv=m_db.WF_LogXOp_qry(IdOp, Particion);
			Claves = new DataColumn[] {	dv.Table.Columns["IdEvento"], 
										  dv.Table.Columns["Fecha"], 
										  dv.Table.Columns["IdEstado"]};
			dv.Table.PrimaryKey = Claves;
			return dv;
		}
		protected DataView LeerEventosPosiblesOpNueva (string IdFlow, string IdCircuito, int IdNivSeg) {
			DataColumn[] Claves;
			DataView dv;
			dv=m_db.WF_EventosIniciales_qry(IdFlow);
			Claves = new DataColumn[] {dv.Table.Columns["IdEvento"]};
			dv.Table.PrimaryKey = Claves;
			return dv;
		}
		protected DataView LeerEventosPosiblesOpExist (string IdFlow, string IdEstado, string IdCircuito, int IdNivSeg) {
			DataColumn[] Claves;
			DataView dv;
			dv=m_db.WF_EventosPosibles_qry(IdFlow, IdEstado, IdCircuito);
			Claves = new DataColumn[] {dv.Table.Columns["IdEvento"]};
			dv.Table.PrimaryKey = Claves;
			return dv;
		}
		protected DataView LeerEventosXLotePosiblesOpExist (string IdFlow, string IdEstado, string IdCircuito, int IdNivSeg) 
		{
			DataColumn[] Claves;
			DataView dv;
			dv=m_db.WF_EventosXLotePosibles_qry(IdFlow, IdEstado, IdCircuito);
			Claves = new DataColumn[] {dv.Table.Columns["IdEvento"]};
			dv.Table.PrimaryKey = Claves;
			return dv;
		}
		protected DataView LeerEsquemaSegEventosPosibles (string IdFlow, string IdCircuito, int IdNivSeg, string IdEstadoActual,ref DataView dvEventosPosibles, DataView dvLog) 
		{
			DataColumn[] Claves;
			DataView dvEsquemaSegEventosPosibles;
			string[] Eventos = new string[dvEventosPosibles.Table.Rows.Count];
			for (int i = 0; i<dvEventosPosibles.Table.Rows.Count; i++) {
				Eventos[i]=dvEventosPosibles.Table.Rows[i]["IdEvento"].ToString();
			}
			dvEsquemaSegEventosPosibles=m_db.WF_EsquemaSegEventosPosibles_qry(IdFlow, IdCircuito, IdNivSeg, Eventos);
			Claves = new DataColumn[] {	dvEsquemaSegEventosPosibles.Table.Columns["IdEvento"], 
										  dvEsquemaSegEventosPosibles.Table.Columns["IdGrupo"],
										  dvEsquemaSegEventosPosibles.Table.Columns["DebeSerSP"],
										  dvEsquemaSegEventosPosibles.Table.Columns["SupervisorNivelDsd"],
										  dvEsquemaSegEventosPosibles.Table.Columns["SupervisorNivelHst"]};
			dvEsquemaSegEventosPosibles.Table.PrimaryKey = Claves;
			// "Restar" intervenciones registradas en el Log
			if (dvLog.Table.Rows.Count>0) {
				// Ubico el evento que seteo el estado actual
				int j=-1;	// primera intervencion posterior al seteo del estado actual
				for (int i=dvLog.Table.Rows.Count-1;i>=0;i--) {
					if (dvLog.Table.Rows[i]["IdEstado"].ToString()!=IdEstadoActual) {
						break;
					}
					else {
						j=i;
					}
				}
				if (j!=-1) {
					// Hay intervenciones posteriores al seteo del estado actual
					bool SeRestaronIntervenciones=false;
					for (int i=j+1;i<dvLog.Table.Rows.Count;i++) {
						// Encontrar el EsquemaSeg al que corresponde la intervencion
						DataRow[] drEsquemaSegEventosPosibles=dvEsquemaSegEventosPosibles.Table.Select("IdEvento='"+dvLog.Table.Rows[i]["IdEvento"]+"'");
						for (int h=0; h<drEsquemaSegEventosPosibles.Length;h++) {
							if (dvLog.Table.Rows[i]["IdGrupo"].ToString()==drEsquemaSegEventosPosibles[h]["IdGrupo"].ToString()) {
								bool CumpleDebeSerSP=false;
								switch (Convert.ToString(drEsquemaSegEventosPosibles[h]["DebeSerSP"])) {
									case "S":
										if (Convert.ToBoolean(dvLog.Table.Rows[i]["Supervisor"])) {CumpleDebeSerSP=true;}
										break;
									case "N":
										if (!Convert.ToBoolean(dvLog.Table.Rows[i]["Supervisor"])) {CumpleDebeSerSP=true;}
										break;
									case "NA":
										CumpleDebeSerSP=true;
										break;
								}
								if (CumpleDebeSerSP) {
									if (Convert.ToByte(dvLog.Table.Rows[i]["SupervisorNivel"])>=Convert.ToByte(drEsquemaSegEventosPosibles[h]["SupervisorNivelDsd"]) && 
										Convert.ToByte(dvLog.Table.Rows[i]["SupervisorNivel"])<=Convert.ToByte(drEsquemaSegEventosPosibles[h]["SupervisorNivelHst"])) {
										if (drEsquemaSegEventosPosibles[h].RowState!=DataRowState.Deleted) {
											// En eventos que no producen cambios de estado: CantInterv debe ser 0, 
											// en esos casos no se lleva control de intervenciones
											if (Convert.ToInt32(drEsquemaSegEventosPosibles[h]["CantInterv"])!=0) {
												// Restar intervencion
												drEsquemaSegEventosPosibles[h].BeginEdit();
												drEsquemaSegEventosPosibles[h]["CantInterv"]=Convert.ToInt32(drEsquemaSegEventosPosibles[h]["CantInterv"])-1;
												drEsquemaSegEventosPosibles[h].BeginEdit();
												SeRestaronIntervenciones=true;
												//Elimino registro
												if (Convert.ToInt32(drEsquemaSegEventosPosibles[h]["CantInterv"])==0) {
													drEsquemaSegEventosPosibles[h].Delete();
												}
											}
											break;
										}
									}
								}
							}
						}
					}
					if (SeRestaronIntervenciones) {
						dvEsquemaSegEventosPosibles.Table.AcceptChanges();
					}
				}
			}
			// Chequeo que a todos los eventos posibles les hayan quedado al menos
			// un EsquemaSeg, si no: lo elimino.
			return dvEsquemaSegEventosPosibles;
		}
		protected string intervencionPermitida(string IdEvento, ref DataRow[] drEvento, ref DataRow[] drEsquemaSeg, ref DataRow drEsquemaSegUsado, ref DataRow[] drUsuarioGrupoUsado) {
			// Verifico que el evento este entre los eventos posibles
			if (drEvento.Length==0) {
				return "EventoInvalido";
			}
				// Verifico que el evento tenga al menos un esquema de seguridad asociado
			else if (drEsquemaSeg.Length==0) {
				return "EventoSinSeg";
			}
			else {
				// Recorro todos los esquemas de seguridad del evento para determinar 
				// en nombre del cual interviene el usuario
				bool EncontreGrupo=false;
				for (int i=0; i<drEsquemaSeg.Length;i++) {
					drUsuarioGrupoUsado=m_Sesion.Usuario.PerteneceA.Table.Select("IdGrupo='"+drEsquemaSeg[i]["IdGrupo"]+"'","IdGrupo DESC");
					if (drUsuarioGrupoUsado.Length!=0 && GrupoHabilitadoParaAcceso(drUsuarioGrupoUsado[0]["IdGrupo"].ToString())) {
						bool CumpleDebeSerSP=false;
						switch (Convert.ToString(drEsquemaSeg[i]["DebeSerSP"])) {
							case "S":
								if (Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"])) {CumpleDebeSerSP=true;}
								break;
							case "N":
								if (!Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"])) {CumpleDebeSerSP=true;}
								break;
							case "NA":
								CumpleDebeSerSP=true;
								break;
						}
						if (CumpleDebeSerSP) {
							if (Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"])>=Convert.ToByte(drEsquemaSeg[i]["SupervisorNivelDsd"]) && 
								Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"])<=Convert.ToByte(drEsquemaSeg[i]["SupervisorNivelHst"])) {
								drEsquemaSegUsado=drEsquemaSeg[i];
								EncontreGrupo=true;
								break;
							}
						}
					}
				}
				if (EncontreGrupo) {
					// Verificacion CXO
					if (m_CXO && Convert.ToBoolean(drEvento[0]["CXO"])) {
						if (m_Log.Table.Rows.Count>0) {
							if (m_Log.Table.Rows[m_Log.Table.Rows.Count-1]["IdUsuario"].ToString()==m_Sesion.Usuario.IdUsuario.ToString()) {
								return "CXO";
							}
						}
					}
					return "SI";
				}
				else {
					return "UsuarioNoCumpleSeg";
				}
			}
		}
		public bool IntervencionPermitida(string IdEvento) 
		{
			DataRow[] drEvento=m_EventosPosibles.Table.Select("IdEvento='"+IdEvento+"'");
			DataRow[] drEsquemaSeg=LeerEsquemaSegEventosPosibles(m_IdFlow, m_IdCircuitoOrig, m_IdNivSeg, m_IdEstado, ref m_EventosPosibles, m_Log).Table.Select("IdEvento='"+IdEvento+"'");
			DataRow   drEsquemaSegUsado=null;
			DataRow[] drUsuarioGrupoUsado=null;
			return Convert.ToBoolean(intervencionPermitida(IdEvento, ref drEvento, ref drEsquemaSeg, ref drEsquemaSegUsado, ref drUsuarioGrupoUsado)=="SI");
		}
		public bool IntervencionPermitida(string IdEvento, out bool UltimaIntervencion) 
		{
			DataRow[] drEvento=m_EventosPosibles.Table.Select("IdEvento='"+IdEvento+"'");
			DataRow[] drEsquemaSeg=LeerEsquemaSegEventosPosibles(m_IdFlow, m_IdCircuitoOrig, m_IdNivSeg, m_IdEstado, ref m_EventosPosibles, m_Log).Table.Select("IdEvento='"+IdEvento+"'");
			DataRow   drEsquemaSegUsado=null;
			DataRow[] drUsuarioGrupoUsado=null;
			bool intervPermitida=Convert.ToBoolean(intervencionPermitida(IdEvento, ref drEvento, ref drEsquemaSeg, ref drEsquemaSegUsado, ref drUsuarioGrupoUsado)=="SI");
			UltimaIntervencion=false;
			if (intervPermitida && Convert.ToInt32(drEsquemaSegUsado["CantInterv"])==1)
			{
				UltimaIntervencion=true;
			}
			return intervPermitida;
		}
		protected bool GrupoHabilitadoParaAcceso(string IdGrupo) 
		{
			try {
				bool Resp=Convert.ToInt32(m_db.WF_Acceso_get(IdGrupo, m_Sesion.IdAcceso).Table.Rows[0]["Permiso"])==1;
				return Resp;
			}
			catch {
				return false;
			}
		}
		public virtual string EjecutarEvento (string IdEvento, string Comentario, bool DevolverHandler) {
			DataRow[] drEvento=m_EventosPosibles.Table.Select("IdEvento='"+IdEvento+"'");
			DataRow[] drEsquemaSeg=LeerEsquemaSegEventosPosibles(m_IdFlow, m_IdCircuitoOrig, m_IdNivSeg, m_IdEstado, ref m_EventosPosibles, m_Log).Table.Select("IdEvento='"+IdEvento+"'");
			DataRow   drEsquemaSegUsado=null;
			DataRow[] drUsuarioGrupoUsado=null;
			switch (intervencionPermitida(IdEvento, ref drEvento, ref drEsquemaSeg, ref drEsquemaSegUsado, ref drUsuarioGrupoUsado)) {
				case "EventoInvalido":
					throw new Cedeira.Ex.WF.EventoInvalido();
				case "EventoSinSeg":
					throw new Cedeira.Ex.WF.EventoSinSeg();
				case "UsuarioNoCumpleSeg":
					throw new Cedeira.Ex.WF.UsuarioNoCumpleSeg();
				case "CXO":
					throw new Cedeira.Ex.WF.CXO();
				default:
					break;
			}
			if (drEvento[0]["IdEstadoDsd"]==System.DBNull.Value) {
				// Evento inicial (alta de operacion)
				if (!(drEsquemaSeg.Length==1 && Convert.ToInt32(drEsquemaSegUsado["CantInterv"])==1)) {
					// (los eventos iniciales no pueden tener varias intervenciones)
					throw new Cedeira.Ex.WF.EventoIniMalConfigurado();
				}
				else {
					m_IdEstado=drEvento[0]["IdEstadoHst"].ToString();
					m_DescrEstado=drEvento[0]["DescrEstadoHst"].ToString();
					if (!DevolverHandler) {
						DataView dv=m_db.WF_Op_ins(m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, m_DescrOp, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]));
						m_IdOp=Convert.ToInt32(dv.Table.Rows[0]["IdOp"]);
						return "";
					}
					else {
						return m_db.WF_Op_insHandler(m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, m_DescrOp, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]));
					}
				}
			}
			else {
				// Chequeo si esta es la ultima intervencion (que posibilita el cambio de estado)
				if (drEsquemaSeg.Length==1 && Convert.ToInt32(drEsquemaSegUsado["CantInterv"])==1) {
					// Cambio el estado
					switch (drEvento[0]["IdEstadoHst"].ToString()) {
						case ("<EstadoAnt>"):
							// Estado virtual
							for (int i=m_Log.Table.Rows.Count-1; i>=0; i--) {
								if (m_Log.Table.Rows[i]["IdEstado"].ToString()!=m_IdEstado) {
									m_IdCircuito=m_Log.Table.Rows[i]["IdCircuito"].ToString();
									m_IdEstado=m_Log.Table.Rows[i]["IdEstado"].ToString();
									m_DescrEstado=m_Log.Table.Rows[i]["Estado"].ToString();
									if (!DevolverHandler) {
										m_db.WF_Op_upd(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
										return "";
									}
									else {
										return m_db.WF_Op_updHandler(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
									}
								}
							}
							throw new Cedeira.Ex.WF.EstadoVirtualMalConfigurado();
						default:
							// Estado determinado
							m_IdEstado=drEvento[0]["IdEstadoHst"].ToString();
							m_DescrEstado=drEvento[0]["DescrEstadoHst"].ToString();
							if (!DevolverHandler) {
								m_db.WF_Op_upd(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
								return "";
							}
							else {
								return m_db.WF_Op_updHandler(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
							}
					}
				}
				else {
					// Registro intervencion sin cambiar el estado, pero
					// actualizo WF_Op por si cambio el Circuito o el NivSeg
					if (!DevolverHandler) {
						m_db.WF_Op_upd(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
						return "";
					}
					else {
						return m_db.WF_Op_updHandler(m_IdOp, m_IdFlow, m_IdCircuito, m_IdNivSeg, m_IdEstado, IdEvento, m_Sesion.Usuario.IdUsuario.ToString(), Comentario, drUsuarioGrupoUsado[0]["IdGrupo"].ToString(), Convert.ToBoolean(drUsuarioGrupoUsado[0]["Supervisor"]), Convert.ToByte(drUsuarioGrupoUsado[0]["SupervisorNivel"]), m_UltActualiz);
					}
				}
			}
		}
		public void EjecutarHandler (string Handler) {
			m_db.WF_EjecutarHandler(Handler);
		}
		public void EjecutarHandlerEventoInicial (string Handler) 
		{
			m_db.WF_EjecutarHandlerEventoInicial(Handler);
		}
	}
}
