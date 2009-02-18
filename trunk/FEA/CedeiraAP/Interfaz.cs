using System;
using System.Data;
namespace Cedeira.SV {
	public interface IWF_db
	{
		DataView WF_Op_get(int IdOp, Alcance Particion);
		DataView WF_LogXOp_qry(int IdOp, Alcance Particion);
		DataView WF_EventosIniciales_qry(string IdFlow);
		DataView WF_EventosIniciales_qry();
		DataView WF_EventosPosibles_qry(string IdFlow, string IdEstadoDsd, string IdCircuito);
		DataView WF_EventosXLotePosibles_qry(string IdFlow, string IdEstadoDsd, string IdCircuito);
		DataView WF_EsquemaSegEventosPosibles_qry(string IdFlow, string IdCircuito, int IdNivSeg, string[] Eventos);
		DataView WF_Flow_get(string IdFlow);
		DataView WF_Circuito_get(string IdCircuito);
		DataView WF_NivSeg_get(int IdOp);
		DataView WF_Flow_lst();
		DataView WF_Circuito_lst();
		DataView WF_NivSeg_lst();
		DataView WF_Estado_lst();
		DataView WF_Acceso_lst();
		DataView WF_Estado_qry();
		DataView WF_Estado_qry(string IdFlow);
		DataView WF_OpsEnTramite_lst(Alcance Particion);
		DataView WF_Op_ins(string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel);
		void WF_Op_upd(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz);
		void WF_Log_ins(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel);
		string WF_Op_insHandler(string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel);
		string WF_Op_updHandler(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz);
		string WF_Log_insHandler(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel);
		void WF_EjecutarHandler(string Handler);
		void WF_EjecutarHandlerEventoInicial(string Handler);
		DataView WF_GruposXAcceso_qry (string IdAcceso);
		DataView WF_Acceso_get (string IdGrupo, string IdAcceso);
		}
	public interface IdbUsuario
	{
		DataView Usuario_get(string IdUsuario);
		DataView Usuario_qry();
		DataView GruposXUsuario_get(string IdUsuario, bool Pertenece);
	}
	public interface IUsuario_db
	{
		DataView US_Usuario_qry();
		DataView US_Usuario_get (string IdUsuario);
		DataView US_GruposXUsuario_get(string IdUsuario, bool Pertenece);
	}
	public interface IUsuario_Sesion
	{
		bool CXO{get;}
	}
	public interface IWF_Sesion
	{
		bool CXO{get;}
		string IdAcceso{get;}
		Cedeira.SV.Usuario Usuario {get; set;}
	}
	public interface Idb_Sesion
	{
		string CnnStr {get;}
		string IdAcceso{get;}
		DataTable Opcion {get; set;}
		DataTable InfoCampos {get; set;}
	}
}
