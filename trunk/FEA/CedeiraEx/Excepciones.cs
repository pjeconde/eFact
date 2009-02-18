using System;
using System.Runtime.Serialization;

namespace Cedeira.Ex
{
	namespace Usuario {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Inexistente : Cedeira.Ex.Usuario.BaseApplicationException
		{
			static string TextoError = "Usuario inexistente";
			public Inexistente() : base(TextoError) {}
			public Inexistente(Exception inner) : base(TextoError, inner) {}
			public Inexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace WF {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OpInexistente : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Operacion inexistente (WF)";
			public OpInexistente() : base(TextoError) {}
			public OpInexistente(Exception inner) : base(TextoError, inner) {}
			public OpInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoInvalido : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Evento invalido (WF)";
			public EventoInvalido() : base(TextoError) {}
			public EventoInvalido(Exception inner) : base(TextoError, inner) {}
			public EventoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			public EventoInvalido(string IdEvento) : base("Evento " + IdEvento + " falta parametrizar"){}
		}
		[Serializable]
		public class FlowInvalido : Cedeira.Ex.WF.BaseApplicationException 
		{
			static string TextoError = "Flow invalido (WF)";
			public FlowInvalido() : base(TextoError) {}
			public FlowInvalido(Exception inner) : base(TextoError, inner) {}
			public FlowInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CircuitoInvalido : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Circuito invalido (WF)";
			public CircuitoInvalido() : base(TextoError) {}
			public CircuitoInvalido(Exception inner) : base(TextoError, inner) {}
			public CircuitoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class NivSegInvalido : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Nivel de seguridad invalido (WF)";
			public NivSegInvalido() : base(TextoError) {}
			public NivSegInvalido(Exception inner) : base(TextoError, inner) {}
			public NivSegInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoSinSeg : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Evento sin esquema de seguridad asociado (WF)";
			public EventoSinSeg() : base(TextoError) {}
			public EventoSinSeg(Exception inner) : base(TextoError, inner) {}
			public EventoSinSeg(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class UsuarioNoCumpleSeg : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de seguridad del evento (WF)";
			public UsuarioNoCumpleSeg() : base(TextoError) {}
			public UsuarioNoCumpleSeg(Exception inner) : base(TextoError, inner) {}
			public UsuarioNoCumpleSeg(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoIniMalConfigurado : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "El esquema de seguridad del evento inicial esta configurado de manera incorrecta.  Los eventos iniciales no deben requerir mas de una intervencion (WF)";
			public EventoIniMalConfigurado() : base(TextoError) {}
			public EventoIniMalConfigurado(Exception inner) : base(TextoError, inner) {}
			public EventoIniMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EstadoVirtualMalConfigurado : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "No es posible encontrar el valor del estado (virtual) de destino, definido en el evento (WF)";
			public EstadoVirtualMalConfigurado() : base(TextoError) {}
			public EstadoVirtualMalConfigurado(Exception inner) : base(TextoError, inner) {}
			public EstadoVirtualMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CXO : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de control por oposicion (WF)";
			public CXO() : base(TextoError) {}
			public CXO(Exception inner) : base(TextoError, inner) {}
			public CXO(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FechaProcesoNoMatch : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "La fecha de proceso no coincide con la fecha de la base de datos";
			public FechaProcesoNoMatch() : base(TextoError) {}
			public FechaProcesoNoMatch(Exception inner) : base(TextoError, inner) {}
			public FechaProcesoNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FechaNoMatch : Cedeira.Ex.WF.BaseApplicationException
		{
			static string TextoError = "La fecha no coincide con la fecha de proceso";
			public FechaNoMatch() : base(TextoError) {}
			public FechaNoMatch(Exception inner) : base(TextoError, inner) {}
			public FechaNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace db {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Conexion : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Problema de conexión a base de datos";
			public Conexion() : base(TextoError) {}
			public Conexion(Exception inner) : base(TextoError, inner) {}
			public Conexion(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Ejecucion : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL";
			public Ejecucion() : base(TextoError) {}
			public Ejecucion(Exception inner) : base(TextoError, inner) {}
			public Ejecucion(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EjecucionConRollback : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL ( Se deshizo la operacion )";
			public EjecucionConRollback() : base(TextoError) {}
			public EjecucionConRollback(Exception inner) : base(TextoError, inner) {}
			public EjecucionConRollback(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Rollback : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Problema al tratar de deshacer la ejecución de un script de SQL";
			public Rollback() : base(TextoError) {}
			public Rollback(Exception inner) : base(TextoError, inner) {}
			public Rollback(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FlowEventoInvalido : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Combinación Flow-Evento invalida";
			public FlowEventoInvalido() : base(TextoError) {}
			public FlowEventoInvalido(Exception inner) : base(TextoError, inner) {}
			public FlowEventoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TipoOpMepInexistente : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "Operatoria inexistente";
			public TipoOpMepInexistente() : base(TextoError) {}
			public TipoOpMepInexistente(Exception inner) : base(TextoError, inner) {}
			public TipoOpMepInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepTransaccionalInsError : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "No se pudo impactar la transferencia en el Sistema MepTransaccional.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  La operacion debera ingresarse al Sistema Mep Transaccional mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepTransaccionalInsError(int IdMep) : base(TextoError+IdMep+".") {}
			public MepTransaccionalInsError(int IdMep, Exception inner) : base(TextoError+IdMep+".", inner) {}
			public MepTransaccionalInsError(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepUpdPk_nro_movimientoError : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "No se pudo registrar el N° de Movimiento de MepTransaccional en esta Aplicacion.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  El dato mencionado debera registrarse mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepUpdPk_nro_movimientoError(int IdMep) : base(TextoError+IdMep+".") {}
			public MepUpdPk_nro_movimientoError(int IdMep, Exception inner) : base(TextoError+IdMep+".", inner) {}
			public MepUpdPk_nro_movimientoError(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepUpdPk_nro_movimientoError2 : Cedeira.Ex.db.BaseApplicationException
		{
			static string TextoError = "No se pudo registrar el N° de Movimiento de Mep Transaccional en esta Aplicacion porque el contenido de la transferencia ha sido modificado por otro usuario.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  El dato mencionado debera registrarse mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepUpdPk_nro_movimientoError2(int IdMep) : base(TextoError+IdMep) {}
			public MepUpdPk_nro_movimientoError2(Exception inner) : base(TextoError, inner) {}
			public MepUpdPk_nro_movimientoError2(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Mep {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepNoImplementado : Cedeira.Ex.Mep.BaseApplicationException
		{
			static string TextoError = "Front-End Mep especifico: no implementado";
			public MepNoImplementado() : base(TextoError) {}
			public MepNoImplementado(Exception inner) : base(TextoError, inner) {}
			public MepNoImplementado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ConstMepInvalido : Cedeira.Ex.Mep.BaseApplicationException
		{
			static string TextoError = "Constructor de Front-End Mep invalido";
			public ConstMepInvalido() : base(TextoError) {}
			public ConstMepInvalido(Exception inner) : base(TextoError, inner) {}
			public ConstMepInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepInexistente : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Transferencia Mep inexistente o inaccesible";
			public MepInexistente() : base(TextoError) {}
			public MepInexistente(Exception inner) : base(TextoError, inner) {}
			public MepInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepExistente : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Transferencia Mep existente";
			public MepExistente() : base(TextoError) {}
			public MepExistente(Exception inner) : base(TextoError, inner) {}
			public MepExistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ModoInvalido : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Modo invalido";
			public ModoInvalido() : base(TextoError) {}
			public ModoInvalido(Exception inner) : base(TextoError, inner) {}
			public ModoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OpInvalidaEnModo : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Operacion invalida en Modo actual";
			public OpInvalidaEnModo() : base(TextoError) {}
			public OpInvalidaEnModo(Exception inner) : base(TextoError, inner) {}
			public OpInvalidaEnModo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepInaccesible : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Operacion inhabilitada para el usuario actual\r\nConsulte el Esquema de Seguridad de la transferencia";
			public MepInaccesible() : base(TextoError) {}
			public MepInaccesible(Exception inner) : base(TextoError, inner) {}
			public MepInaccesible(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class MepEnEstadoFinal : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Operacion inhabilitada.  La transferencia se encuentra en un 'estado final'";
			public MepEnEstadoFinal() : base(TextoError) {}
			public MepEnEstadoFinal(Exception inner) : base(TextoError, inner) {}
			public MepEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		public class CircuitoIndetermEnDevol : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "No es posible determinar el Sector al que devolver la transferencia";
			public CircuitoIndetermEnDevol() : base(TextoError) {}
			public CircuitoIndetermEnDevol(Exception inner) : base(TextoError, inner) {}
			public CircuitoIndetermEnDevol(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TipoOpMepInexistente : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Operatoria inexistente";
			public TipoOpMepInexistente() : base(TextoError) {}
			public TipoOpMepInexistente(Exception inner) : base(TextoError, inner) {}
			public TipoOpMepInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FTipoOpMepInexistente : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Familia de operatorias inexistente, reporte el incidente al Administrador Mep";
			public FTipoOpMepInexistente() : base(TextoError) {}
			public FTipoOpMepInexistente(Exception inner) : base(TextoError, inner) {}
			public FTipoOpMepInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FamiliaInexistente : Cedeira.Ex.Mep.BaseApplicationException {
			static string TextoError = "Familia inexistente";
			public FamiliaInexistente() : base(TextoError) {}
			public FamiliaInexistente(string msg) : base(TextoError + ": " + msg){}
			public FamiliaInexistente(Exception inner) : base(TextoError, inner) {}
			public FamiliaInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		namespace Validaciones {
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Mep.BaseApplicationException {
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ImporteInvalido : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Importe invalido";
				public ImporteInvalido() : base(TextoError) {}
				public ImporteInvalido(Exception inner) : base(TextoError, inner) {}
				public ImporteInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SectorNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Sector no informado";
				public SectorNoInfo() : base(TextoError) {}
				public SectorNoInfo(Exception inner) : base(TextoError, inner) {}
				public SectorNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ContactoApyNomNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Contacto no informado";
				public ContactoApyNomNoInfo() : base(TextoError) {}
				public ContactoApyNomNoInfo(Exception inner) : base(TextoError, inner) {}
				public ContactoApyNomNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ContactoViaNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Contacto Via no informada";
				public ContactoViaNoInfo() : base(TextoError) {}
				public ContactoViaNoInfo(Exception inner) : base(TextoError, inner) {}
				public ContactoViaNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ReadOnly : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "modificacion inhabilitada";
				public ReadOnly(string Propiedad) : base(Propiedad+": "+TextoError) {}
				public ReadOnly(Exception inner) : base(TextoError, inner) {}
				public ReadOnly(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MonCtasOrdDestNoCoinc : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Monedas de cuentas Ordenante y Destino no coincidentes";
				public MonCtasOrdDestNoCoinc() : base(TextoError) {}
				public MonCtasOrdDestNoCoinc(Exception inner) : base(TextoError, inner) {}
				public MonCtasOrdDestNoCoinc(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ComentarioNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Comentario / motivo no informado";
				public ComentarioNoInfo() : base(TextoError) {}
				public ComentarioNoInfo(Exception inner) : base(TextoError, inner) {}
				public ComentarioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class InstruccionNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Instruccion no informada";
				public InstruccionNoInfo() : base(TextoError) {}
				public InstruccionNoInfo(Exception inner) : base(TextoError, inner) {}
				public InstruccionNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ConceptoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Detalle no informado";
				public ConceptoNoInfo() : base(TextoError) {}
				public ConceptoNoInfo(Exception inner) : base(TextoError, inner) {}
				public ConceptoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class IdMepMotivoRechNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Tipo de Rechazo no informado";
				public IdMepMotivoRechNoInfo() : base(TextoError) {}
				public IdMepMotivoRechNoInfo(Exception inner) : base(TextoError, inner) {}
				public IdMepMotivoRechNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteNroNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "N° Solicitud Billetes no informado";
				public SolBilleteNroNoInfo() : base(TextoError) {}
				public SolBilleteNroNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteNroNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteNombreToRNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nombre Transp. o Representante no informado";
				public SolBilleteNombreToRNoInfo() : base(TextoError) {}
				public SolBilleteNombreToRNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteNombreToRNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteNroDocRNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "N° Doc. Representante no informado";
				public SolBilleteNroDocRNoInfo() : base(TextoError) {}
				public SolBilleteNroDocRNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteNroDocRNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NombreOrdenanteNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nombre ordenante no informado";
				public NombreOrdenanteNoInfo() : base(TextoError) {}
				public NombreOrdenanteNoInfo(Exception inner) : base(TextoError, inner) {}
				public NombreOrdenanteNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TitularPrestamoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Titular del prestamo no informado";
				public TitularPrestamoNoInfo() : base(TextoError) {}
				public TitularPrestamoNoInfo(Exception inner) : base(TextoError, inner) {}
				public TitularPrestamoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroPrestamoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro prestamo no informado";
				public NroPrestamoNoInfo() : base(TextoError) {}
				public NroPrestamoNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroPrestamoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FecVtoPrestamoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Fecha vencimiento del prestamo no informada";
				public FecVtoPrestamoNoInfo() : base(TextoError) {}
				public FecVtoPrestamoNoInfo(Exception inner) : base(TextoError, inner) {}
				public FecVtoPrestamoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroCtaBIDNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro Cuenta BID no informado";
				public NroCtaBIDNoInfo() : base(TextoError) {}
				public NroCtaBIDNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroCtaBIDNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroBoletoConcertacionNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro de boleto de concertacion no informado";
				public NroBoletoConcertacionNoInfo() : base(TextoError) {}
				public NroBoletoConcertacionNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroBoletoConcertacionNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Especie no informada";
				public EspecieNoInfo() : base(TextoError) {}
				public EspecieNoInfo(Exception inner) : base(TextoError, inner) {}
				public EspecieNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CantidadAplicNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Cantidad Aplic no informada";
				public CantidadAplicNoInfo() : base(TextoError) {}
				public CantidadAplicNoInfo(Exception inner) : base(TextoError, inner) {}
				public CantidadAplicNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class IdentifFormulaNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Identificacion formula no informada";
				public IdentifFormulaNoInfo() : base(TextoError) {}
				public IdentifFormulaNoInfo(Exception inner) : base(TextoError, inner) {}
				public IdentifFormulaNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class IdentifFormulaNoMatch : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Identificacion formula no coincide, debe ser ";
				public IdentifFormulaNoMatch(string Correcta) : base(TextoError) {}
				public IdentifFormulaNoMatch(Exception inner) : base(TextoError, inner) {}
				public IdentifFormulaNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CodReembolsoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Codigo de reembolso no informado";
				public CodReembolsoNoInfo() : base(TextoError) {}
				public CodReembolsoNoInfo(Exception inner) : base(TextoError, inner) {}
				public CodReembolsoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CodReembolsoNoMatch : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Codigo de reembolso incorrecto,";
				public CodReembolsoNoMatch(string Descripcion) : base(TextoError+Descripcion) {}
				public CodReembolsoNoMatch(Exception inner) : base(TextoError, inner) {}
				public CodReembolsoNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SucursalNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Sucursal no informada";
				public SucursalNoInfo() : base(TextoError) {}
				public SucursalNoInfo(Exception inner) : base(TextoError, inner) {}
				public SucursalNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroExpedienteNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro Expediente no informado";
				public NroExpedienteNoInfo() : base(TextoError) {}
				public NroExpedienteNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroExpedienteNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class AnioNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Año no informado";
				public AnioNoInfo() : base(TextoError) {}
				public AnioNoInfo(Exception inner) : base(TextoError, inner) {}
				public AnioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class JuzgadoEmbargoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Juzgado Embargo no informado";
				public JuzgadoEmbargoNoInfo() : base(TextoError) {}
				public JuzgadoEmbargoNoInfo(Exception inner) : base(TextoError, inner) {}
				public JuzgadoEmbargoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroOficioEmbargoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro oficio embargo no informado";
				public NroOficioEmbargoNoInfo() : base(TextoError) {}
				public NroOficioEmbargoNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroOficioEmbargoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroDocNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro documento no informado";
				public NroDocNoInfo() : base(TextoError) {}
				public NroDocNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroDocNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class RazSocNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Razon social no informada";
				public RazSocNoInfo() : base(TextoError) {}
				public RazSocNoInfo(Exception inner) : base(TextoError, inner) {}
				public RazSocNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class DireccionSWIFTNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Direccion SWIFT no informada";
				public DireccionSWIFTNoInfo() : base(TextoError) {}
				public DireccionSWIFTNoInfo(Exception inner) : base(TextoError, inner) {}
				public DireccionSWIFTNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class DireccionSWIFTNoMatch : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Cadena 'US' no encontrada en la direccion SWIFT";
				public DireccionSWIFTNoMatch() : base(TextoError) {}
				public DireccionSWIFTNoMatch(Exception inner) : base(TextoError, inner) {}
				public DireccionSWIFTNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CantMonExtranjeraNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Cantidad moneda extranjera no informada";
				public CantMonExtranjeraNoInfo() : base(TextoError) {}
				public CantMonExtranjeraNoInfo(Exception inner) : base(TextoError, inner) {}
				public CantMonExtranjeraNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CantMonExtranjeraNoMatch : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "No coincide con el importe";
				public CantMonExtranjeraNoMatch() : base(TextoError) {}
				public CantMonExtranjeraNoMatch(Exception inner) : base(TextoError, inner) {}
				public CantMonExtranjeraNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TipoCambioNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Tipo de cambio no informado";
				public TipoCambioNoInfo() : base(TextoError) {}
				public TipoCambioNoInfo(Exception inner) : base(TextoError, inner) {}
				public TipoCambioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CBUHaberesNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "CBU Haberes no informado";
				public CBUHaberesNoInfo() : base(TextoError) {}
				public CBUHaberesNoInfo(Exception inner) : base(TextoError, inner) {}
				public CBUHaberesNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CUILHaberesNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "CUIL Haberes no informado";
				public CUILHaberesNoInfo() : base(TextoError) {}
				public CUILHaberesNoInfo(Exception inner) : base(TextoError, inner) {}
				public CUILHaberesNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroOficioPagoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro oficio pago no informado";
				public NroOficioPagoNoInfo() : base(TextoError) {}
				public NroOficioPagoNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroOficioPagoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class JuzgadoPagoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Juzgado de pago no informado";
				public JuzgadoPagoNoInfo() : base(TextoError) {}
				public JuzgadoPagoNoInfo(Exception inner) : base(TextoError, inner) {}
				public JuzgadoPagoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SecretariaNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Secretaria no informada";
				public SecretariaNoInfo() : base(TextoError) {}
				public SecretariaNoInfo(Exception inner) : base(TextoError, inner) {}
				public SecretariaNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FueroNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Fuero no informado";
				public FueroNoInfo() : base(TextoError) {}
				public FueroNoInfo(Exception inner) : base(TextoError, inner) {}
				public FueroNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class AutosNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Autos no informados";
				public AutosNoInfo() : base(TextoError) {}
				public AutosNoInfo(Exception inner) : base(TextoError, inner) {}
				public AutosNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ExpedienteNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Expediente no informado";
				public ExpedienteNoInfo() : base(TextoError) {}
				public ExpedienteNoInfo(Exception inner) : base(TextoError, inner) {}
				public ExpedienteNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SucDestinoNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Sucursal destino no informada";
				public SucDestinoNoInfo() : base(TextoError) {}
				public SucDestinoNoInfo(Exception inner) : base(TextoError, inner) {}
				public SucDestinoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NroSecHostSiopelVTLNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Nro Sec Host Siopel VTL no informado";
				public NroSecHostSiopelVTLNoInfo() : base(TextoError) {}
				public NroSecHostSiopelVTLNoInfo(Exception inner) : base(TextoError, inner) {}
				public NroSecHostSiopelVTLNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class LetraTituloDescrNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Letra titulo descr no informada";
				public LetraTituloDescrNoInfo() : base(TextoError) {}
				public LetraTituloDescrNoInfo(Exception inner) : base(TextoError, inner) {}
				public LetraTituloDescrNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CodTitCajValVTLNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "CodTitCajValVTL no informada";
				public CodTitCajValVTLNoInfo() : base(TextoError) {}
				public CodTitCajValVTLNoInfo(Exception inner) : base(TextoError, inner) {}
				public CodTitCajValVTLNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FecVtoVTLNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Fecha vencimiento VTL no informada";
				public FecVtoVTLNoInfo() : base(TextoError) {}
				public FecVtoVTLNoInfo(Exception inner) : base(TextoError, inner) {}
				public FecVtoVTLNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CantMonExtranjeraCCENoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Cantidad moneda extranjera CCE no informada";
				public CantMonExtranjeraCCENoInfo() : base(TextoError) {}
				public CantMonExtranjeraCCENoInfo(Exception inner) : base(TextoError, inner) {}
				public CantMonExtranjeraCCENoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CantMonExtranjeraCCENoMatch : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "No coincide con el importe";
				public CantMonExtranjeraCCENoMatch() : base(TextoError) {}
				public CantMonExtranjeraCCENoMatch(Exception inner) : base(TextoError, inner) {}
				public CantMonExtranjeraCCENoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TipoCambioCCENoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Tipo cambio CCE no informado";
				public TipoCambioCCENoInfo() : base(TextoError) {}
				public TipoCambioCCENoInfo(Exception inner) : base(TextoError, inner) {}
				public TipoCambioCCENoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CBUDestinoCCENoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "CBU destino CCE no informado";
				public CBUDestinoCCENoInfo() : base(TextoError) {}
				public CBUDestinoCCENoInfo(Exception inner) : base(TextoError, inner) {}
				public CBUDestinoCCENoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CUITBenefCCENoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "CUIT beneficiario CCE no informado";
				public CUITBenefCCENoInfo() : base(TextoError) {}
				public CUITBenefCCENoInfo(Exception inner) : base(TextoError, inner) {}
				public CUITBenefCCENoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteToRNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBilleteToR no informado";
				public SolBilleteToRNoInfo() : base(TextoError) {}
				public SolBilleteToRNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteToRNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteTipoDocRNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBilleteTipoDocR no informado";
				public SolBilleteTipoDocRNoInfo() : base(TextoError) {}
				public SolBilleteTipoDocRNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteTipoDocRNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteProvisionNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBilleteProvision no informado";
				public SolBilleteProvisionNoInfo() : base(TextoError) {}
				public SolBilleteProvisionNoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBilleteProvisionNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete1NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete1 no informado";
				public SolBillete1NoInfo() : base(TextoError) {}
				public SolBillete1NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete1NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete2NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete2 no informado";
				public SolBillete2NoInfo() : base(TextoError) {}
				public SolBillete2NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete2NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete3NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete3 no informado";
				public SolBillete3NoInfo() : base(TextoError) {}
				public SolBillete3NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete3NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete4NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete4 no informado";
				public SolBillete4NoInfo() : base(TextoError) {}
				public SolBillete4NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete4NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete5NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete5 no informado";
				public SolBillete5NoInfo() : base(TextoError) {}
				public SolBillete5NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete5NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete6NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete6 no informado";
				public SolBillete6NoInfo() : base(TextoError) {}
				public SolBillete6NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete6NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBillete7NoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "SolBillete7 no informado";
				public SolBillete7NoInfo() : base(TextoError) {}
				public SolBillete7NoInfo(Exception inner) : base(TextoError, inner) {}
				public SolBillete7NoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NumeroNegativo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "El numero debe ser mayor a cero en ";
				public NumeroNegativo(string Propiedad) : base(TextoError+Propiedad) {}
				public NumeroNegativo(Exception inner) : base(TextoError, inner) {}
				public NumeroNegativo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MotivoRechDescrNoInfo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Motivo de Rechazo no informado";
				public MotivoRechDescrNoInfo() : base(TextoError) {}
				public MotivoRechDescrNoInfo(Exception inner) : base(TextoError, inner) {}
				public MotivoRechDescrNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ValorNoCombo : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "opcion invalida";
				public ValorNoCombo(string Combo) : base(Combo+": "+TextoError) {}
				public ValorNoCombo(Exception inner) : base(TextoError, inner) {}
				public ValorNoCombo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FechaInvalida : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "Fecha invalida";
				public FechaInvalida() : base(TextoError) {}
				public FechaInvalida(Exception inner) : base(TextoError, inner) {}
				public FechaInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SolBilleteInvalido : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "cantidad de billetes invalida";
				public SolBilleteInvalido(string SolBillete) : base(SolBillete+": "+TextoError) {}
				public SolBilleteInvalido(Exception inner) : base(TextoError, inner) {}
				public SolBilleteInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class LenInvalida : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "longitud invalida";
				public LenInvalida(string Propiedad) : base(Propiedad+": "+TextoError) {}
				public LenInvalida(Exception inner) : base(TextoError, inner) {}
				public LenInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TipoNoCoincidente : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "el tipo de la base de datos no coincide con la propiedad";
				public TipoNoCoincidente(string Propiedad) : base(Propiedad+": "+TextoError) {}
				public TipoNoCoincidente(Exception inner) : base(TextoError, inner) {}
				public TipoNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CBUNoCoincidente : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "El CBU no coincide con la entidad ";
				public CBUNoCoincidente(string TipoCBU) : base(TextoError+TipoCBU) {}
				public CBUNoCoincidente(Exception inner) : base(TextoError, inner) {}
				public CBUNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CUITNoCoincidente : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "El CUIT no coincide con la entidad ";
				public CUITNoCoincidente(string TipoCBU) : base(TextoError+TipoCBU) {}
				public CUITNoCoincidente(Exception inner) : base(TextoError, inner) {}
				public CUITNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CUITCoincidente : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "El CUIT coincide con la entidad ";
				public CUITCoincidente(string TipoCBU) : base(TextoError+TipoCBU) {}
				public CUITCoincidente(Exception inner) : base(TextoError, inner) {}
				public CUITCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class IdTCtaNoCoincidente : Cedeira.Ex.Mep.Validaciones.BaseApplicationException {
				static string TextoError = "El CBU no coincide con el tipo de cuenta, ";
				public IdTCtaNoCoincidente(string TCta) : base(TextoError+TCta) {}
				public IdTCtaNoCoincidente(Exception inner) : base(TextoError, inner) {}
				public IdTCtaNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
	}
	namespace Validaciones 
	{ 
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CierreCambioNoEncontrado : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Cierre de Cambio no encontrado";
			public CierreCambioNoEncontrado(string IdMoneda, DateTime Fecha) : base(TextoError+".  Moneda: '"+IdMoneda+"', Dia: "+Fecha.ToString("dd/MM/yyyy")) {}
			public CierreCambioNoEncontrado(Exception inner) : base(TextoError, inner) {}
			public CierreCambioNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
        [Serializable]
        public class CambioCompradorYVendedorIncorrecto : Cedeira.Ex.Validaciones.BaseApplicationException
        {
            static string TextoError = "El precio de cambio correspondiente a la compra debe ser menor o igual al precio de cambio de venta. Modifique los precios para continuar.";
            public CambioCompradorYVendedorIncorrecto(): base (TextoError){}
            public CambioCompradorYVendedorIncorrecto(Exception inner) : base(TextoError, inner) { }
            public CambioCompradorYVendedorIncorrecto(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
		[Serializable]
		public class AjusteEnPrecancNoHabilitado : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Ajuste de tasa y/o plazo no habilitado en pfs precancelables";
			public AjusteEnPrecancNoHabilitado() : base(TextoError) {}
			public AjusteEnPrecancNoHabilitado(Exception inner) : base(TextoError, inner) {}
			public AjusteEnPrecancNoHabilitado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TramoPrecancFueraDeRango : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "La duración de algún tramo se superpone con el tramo siguiente";
			public TramoPrecancFueraDeRango() : base(TextoError) {}
			public TramoPrecancFueraDeRango(Exception inner) : base(TextoError, inner) {}
			public TramoPrecancFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TramoPrecancTasaFueraDeRango : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Las tasas deben ser mayores a 0 e iguales o mayores a la del tramo anterior";
			public TramoPrecancTasaFueraDeRango() : base(TextoError) {}
			public TramoPrecancTasaFueraDeRango(Exception inner) : base(TextoError, inner) {}
			public TramoPrecancTasaFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TramoPrecancNoEncontrado : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Definición de tramo no encontrada";
			public TramoPrecancNoEncontrado() : base(TextoError) {}
			public TramoPrecancNoEncontrado(Exception inner) : base(TextoError, inner) {}
			public TramoPrecancNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PrecioNoEncontrado : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Precio no encontrado";
			public PrecioNoEncontrado(string DescrEspecie, DateTime Fecha) : base(TextoError+".  Especie: '"+DescrEspecie+"', Dia: "+Fecha.ToString("dd/MM/yyyy")) {}
			public PrecioNoEncontrado(Exception inner) : base(TextoError, inner) {}
			public PrecioNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PrecioNoEncontradoEnExcel : Cedeira.Ex.Validaciones.BaseApplicationException
		{
			static string TextoError = "Precio no encontrado en planilla Excel: ";
			public PrecioNoEncontradoEnExcel(string DescrEspecie) : base(TextoError+DescrEspecie) {}
			public PrecioNoEncontradoEnExcel(Exception inner) : base(TextoError, inner) {}
			public PrecioNoEncontradoEnExcel(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
        [Serializable]
        public class PrecioPreExistente : Cedeira.Ex.Validaciones.BaseApplicationException
        {
            static string TextoError = "Ya existe un precio ingresado para la especie: ";
            public PrecioPreExistente(string DescrEspecie) : base(TextoError + DescrEspecie) { }
            public PrecioPreExistente(Exception inner) : base(TextoError, inner) { }
            public PrecioPreExistente(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
		[Serializable]
		public class ConexionInactiva : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "Conexión inactiva con ";
			public ConexionInactiva(string Sistema) : base(TextoError+Sistema) {}
			public ConexionInactiva(Exception inner) : base(TextoError, inner) {}
			public ConexionInactiva(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Despublicacion : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "No se puede despublicar en MCS cuando la fecha de proceso no es la fecha actual.";
			public Despublicacion() : base(TextoError) {}
			public Despublicacion(Exception inner) : base(TextoError, inner) {}
			public Despublicacion(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ElementoInexistente : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "inexistente";
			public ElementoInexistente(IDescrClase Elemento) : base(Elemento._Descripcion+" "+TextoError) {}
			public ElementoInexistente(IDescrClase Elemento, string Valor) : base(Elemento._Descripcion+" "+Valor+" "+TextoError) {}
			public ElementoInexistente(string Descripcion) : base(Descripcion+" "+TextoError) {}
			public ElementoInexistente(Exception inner) : base(TextoError, inner) {}
			public ElementoInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoNoImplementado : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = ": Evento no implementado";
			public EventoNoImplementado(string evento) : base(evento+TextoError) {}
			public EventoNoImplementado(Exception inner) : base(TextoError, inner) {}
			public EventoNoImplementado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class AjustePrecision : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "No se puede ajustar ";
			public AjustePrecision(double Numero, int LongitudIncluyendoSeparador) : base(TextoError+ Numero +" a "+LongitudIncluyendoSeparador+" posiciones") {}
			public AjustePrecision(Exception inner) : base(TextoError, inner) {}
			public AjustePrecision(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ValorInvalido : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "valor inválido";
			public ValorInvalido(string descrProp) : base(descrProp+": "+TextoError) {}
			public ValorInvalido(Exception inner) : base(TextoError, inner) {}
			public ValorInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ValorNoInfo : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "sin informar";
			public ValorNoInfo(string descrProp) : base(descrProp+" "+TextoError) {}
			public ValorNoInfo(Exception inner) : base(TextoError, inner) {}
			public ValorNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ReadOnly : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "modificación inhabilitada";
			public ReadOnly(string descrProp) : base(descrProp+": "+TextoError) {}
			public ReadOnly(Exception inner) : base(TextoError, inner) {}
			public ReadOnly(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ValorNoMatch : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "no coincide, debe ser";
			public ValorNoMatch(string descrProp, string descrPropMatch) : base(descrProp+" "+TextoError+" "+descrPropMatch) {}
			public ValorNoMatch(Exception inner) : base(TextoError, inner) {}
			public ValorNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ValorNegativo : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "debe ser mayor a cero";
			public ValorNegativo(string descrProp) : base(descrProp+": "+TextoError) {}
			public ValorNegativo(Exception inner) : base(TextoError, inner) {}
			public ValorNegativo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ValorNoCombo : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "opción inválida";
			public ValorNoCombo(string descrProp) : base(descrProp+": "+TextoError) {}
			public ValorNoCombo(Exception inner) : base(TextoError, inner) {}
			public ValorNoCombo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OpcionInvalida : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "Opción inválida";
			public OpcionInvalida() : base(TextoError) {}
			public OpcionInvalida(Exception inner) : base(TextoError, inner) {}
			public OpcionInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OpcionNoImplementada : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "Opción no implementada";
			public OpcionNoImplementada(string opcion) : base(opcion+": "+TextoError) {}
			public OpcionNoImplementada(Exception inner) : base(TextoError, inner) {}
			public OpcionNoImplementada(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class LenInvalida : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "longitud inválida";
			public LenInvalida(string descrProp) : base(descrProp+": "+TextoError) {}
			public LenInvalida(Exception inner) : base(TextoError, inner) {}
			public LenInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ProductoNoImplementado : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = ": Producto no implementado";
			public ProductoNoImplementado(string producto) : base(producto+TextoError) {}
			public ProductoNoImplementado(Exception inner) : base(TextoError, inner) {}
			public ProductoNoImplementado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TipoNoCoincidente : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "el tipo de la base de datos no coincide con la propiedad";
			public TipoNoCoincidente(string descrProp) : base(descrProp+": "+TextoError) {}
			public TipoNoCoincidente(Exception inner) : base(TextoError, inner) {}
			public TipoNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class NoEsMultiploDe24 : Cedeira.Ex.Validaciones.BaseApplicationException 
		{
			static string TextoError = "debe ser multiplo de 24";
			public NoEsMultiploDe24(string descrProp) : base(descrProp+": "+TextoError) {}
			public NoEsMultiploDe24(Exception inner) : base(TextoError, inner) {}
			public NoEsMultiploDe24(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		namespace AjuSaldos
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SaldosInexistentes : Cedeira.Ex.Validaciones.CashFlow.BaseApplicationException
			{
				static string TextoError = "No hay saldos pendientes de ajuste en la fecha solicitada";
				public SaldosInexistentes() : base(TextoError) {}
				public SaldosInexistentes(Exception inner) : base(TextoError, inner) {}
				public SaldosInexistentes(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace CashFlow
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CtasMonConceptos : Cedeira.Ex.Validaciones.CashFlow.BaseApplicationException
			{
				static string TextoError = "Se modificaron los conceptos de ingresos y/o egresos de cuentas monetarias. Actualize parámetros del sistema";
				public CtasMonConceptos() : base(TextoError) {}
				public CtasMonConceptos(Exception inner) : base(TextoError, inner) {}
				public CtasMonConceptos(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace Fechas
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FechaNoHabil : Cedeira.Ex.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Según host la fecha no es un día hábil.";
				public FechaNoHabil(string DescrProp) : base(DescrProp+":"+TextoError) {}
				public FechaNoHabil(Exception inner) : base(TextoError, inner) {}
				public FechaNoHabil(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FechaDsdCashFlow : Cedeira.Ex.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "La fecha desde debe ser siempre la del día hábil anterior.";
				public FechaDsdCashFlow(string DescrProp) : base(DescrProp+":"+TextoError) {}
				public FechaDsdCashFlow(Exception inner) : base(TextoError, inner) {}
				public FechaDsdCashFlow(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class AjustePlazoPFyCAU : Cedeira.Ex.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "La fecha de vencimiento calculada para dicho plazo debe ser mayor o igual a la de proceso.";
				public AjustePlazoPFyCAU() : base(TextoError) {}
				public AjustePlazoPFyCAU(Exception inner) : base(TextoError, inner) {}
				public AjustePlazoPFyCAU(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class FechaDsdMayorAHst : Cedeira.Ex.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "La fecha desde debe ser menor o igual a la fecha hasta.";
				public FechaDsdMayorAHst() : base(TextoError) {}
				public FechaDsdMayorAHst(Exception inner) : base(TextoError, inner) {}
				public FechaDsdMayorAHst(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace FCIs
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SociedadesIguales : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "La sociedad gerente y la depositaria no pueden ser la misma.";
				public SociedadesIguales() : base(TextoError) {}
				public SociedadesIguales(Exception inner) : base(TextoError, inner) {}
				public SociedadesIguales(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class Confirmacion : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se pudo confirmar porque falta calcular el valorCP de al menos un fondo";
				public Confirmacion() : base(TextoError) {}
				public Confirmacion(Exception inner) : base(TextoError, inner) {}
				public Confirmacion(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EtapaCalculoConFCIsAsoc : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja una Etapa de Calculo que tenga FCIs vinculados.  Desvincule los FCIs y vuelva a intentar la baja.";
				public EtapaCalculoConFCIsAsoc() : base(TextoError) {}
				public EtapaCalculoConFCIsAsoc(Exception inner) : base(TextoError, inner) {}
				public EtapaCalculoConFCIsAsoc(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class RevalyCalcCPsinSyRsPermitido : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No está permitido ejecutar el proceso de Revaluo de Cartera y calculo Valor CP sin informacion de Suscripciones y Rescates.";
				public RevalyCalcCPsinSyRsPermitido() : base(TextoError) {}
				public RevalyCalcCPsinSyRsPermitido(Exception inner) : base(TextoError, inner) {}
				public RevalyCalcCPsinSyRsPermitido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EtapaCapturaConSubTipoEspeciesAsoc : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja una Etapa de Captura que tenga Subtipos de especies vinculadas.  Desvincule los Subtipos de especies y vuelva a intentar la baja.";
				public EtapaCapturaConSubTipoEspeciesAsoc() : base(TextoError) {}
				public EtapaCapturaConSubTipoEspeciesAsoc(Exception inner) : base(TextoError, inner) {}
				public EtapaCapturaConSubTipoEspeciesAsoc(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCIxlsRegistro : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "CedFCIxls.dll no está correctamente registrada.";
				public CedFCIxlsRegistro() : base(TextoError) {}
				public CedFCIxlsRegistro(Exception inner) : base(TextoError, inner) {}
				public CedFCIxlsRegistro(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCIxlsProceso : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar planilla excel:";
				public CedFCIxlsProceso(string Errores) : base(TextoError+Errores) {}
				public CedFCIxlsProceso(Exception inner) : base(TextoError, inner) {}
				public CedFCIxlsProceso(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCIItfMensualNoFile : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar interfaz mensual:";
				public CedFCIItfMensualNoFile(string Errores) : base(TextoError+Errores+". Archivo inexistente.") {}
				public CedFCIItfMensualNoFile(Exception inner) : base(TextoError, inner) {}
				public CedFCIItfMensualNoFile(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCIItfSemanalCtaSinTag : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar interfaz semanal. La cuenta no está asociada a un tag:";
				public CedFCIItfSemanalCtaSinTag(string Errores) : base(TextoError+Errores+".") {}
				public CedFCIItfSemanalCtaSinTag(Exception inner) : base(TextoError, inner) {}
				public CedFCIItfSemanalCtaSinTag(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCINoSePuedeInformar : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede informar FCI Cartera en fondos que no sean de Clase";
				public CedFCINoSePuedeInformar(string Errores) : base(TextoError+Errores) {}
				public CedFCINoSePuedeInformar(Exception inner) : base(TextoError, inner) {}
				public CedFCINoSePuedeInformar(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCISinInformar : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "FCI Cartera sin informar";
				public CedFCISinInformar(string Errores) : base(TextoError+Errores) {}
				public CedFCISinInformar(Exception inner) : base(TextoError, inner) {}
				public CedFCISinInformar(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CedFCICtasAsocAFondosDeClase : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se admite que los fondos de Clase tengan cuentas asociadas. Primero elimine o reclasifique las cuentas y luego reintente la retipificación del fondo";
				public CedFCICtasAsocAFondosDeClase(string Errores) : base(TextoError+Errores) {}
				public CedFCICtasAsocAFondosDeClase(Exception inner) : base(TextoError, inner) {}
				public CedFCICtasAsocAFondosDeClase(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class UNTipoCarteraConDependencias : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja un Fondo de Cartera sin antes dar de baja sus Fondos de Clase";
				public UNTipoCarteraConDependencias() : base(TextoError) {}
				public UNTipoCarteraConDependencias(Exception inner) : base(TextoError, inner) {}
				public UNTipoCarteraConDependencias(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoInformado : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "El FCI no ha sido informado";
				public NoInformado() : base(TextoError) {}
				public NoInformado(Exception inner) : base(TextoError, inner) {}
				public NoInformado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ValorCPCalculado : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Existe un valor de cuotaparte calculado";
				public ValorCPCalculado() : base(TextoError) {}
				public ValorCPCalculado(Exception inner) : base(TextoError, inner) {}
				public ValorCPCalculado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MonedaExtranjeraParaDiaSiguiente : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Los fondos que publican precio para el día siguiente sólo pueden ser de moneda local.";
				public MonedaExtranjeraParaDiaSiguiente() : base(TextoError) {}
				public MonedaExtranjeraParaDiaSiguiente(Exception inner) : base(TextoError, inner) {}
				public MonedaExtranjeraParaDiaSiguiente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class ValorCPdiferente : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Diferencia en valor de cuota calculado para el día de proceso con respecto al calculado el día anterior. El precio correcto es ";
				public ValorCPdiferente(string IdUN, decimal PrecioCorrecto, decimal PrecioIncorrecto) : base("FCI "+IdUN+":"+TextoError+PrecioCorrecto+" y es distinto a "+PrecioIncorrecto) {}
				public ValorCPdiferente(Exception inner) : base(TextoError, inner) {}
				public ValorCPdiferente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			namespace Proceso
			{
				[Serializable]
				public class BaseApplicationException : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException 
				{
					public BaseApplicationException(string TextoError) : base(TextoError) {}
					public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
					public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class CapturaSyrDefinitivas : Cedeira.Ex.Validaciones.FCIs.Proceso.BaseApplicationException
				{
					static string TextoError = "No se pueden capturar suscripciones ni rescates cuando la fecha actual difiere en más de un día hábil con la de proceso.";
					public CapturaSyrDefinitivas() : base(TextoError) {}
					public CapturaSyrDefinitivas(Exception inner) : base(TextoError, inner) {}
					public CapturaSyrDefinitivas(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
			}
			namespace Revaluo
			{
				[Serializable]
				public class BaseApplicationException : Cedeira.Ex.Validaciones.FCIs.BaseApplicationException 
				{
					public BaseApplicationException(string TextoError) : base(TextoError) {}
					public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
					public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				public class EnProceso : Cedeira.Ex.Validaciones.FCIs.Revaluo.BaseApplicationException
				{
					static string TextoError = "Está siendo ejecutado el revalúo.";
					public EnProceso() : base(TextoError) {}
					public EnProceso(Exception inner) : base(TextoError, inner) {}
					public EnProceso(string EventoDescr, string EtapaDescr) : base("CANDADO DE PROCESO: no se puede ejecutar el evento '"+ EventoDescr.ToUpper() + "' porque se está revaluando la etapa '"+EtapaDescr.ToUpper()+"'") {}
				}
			}
		}
		namespace Mayor
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError) { }
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner) { }
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
			}
			[Serializable]
			public class FondoMonExtCuentaMonExt : Cedeira.Ex.Validaciones.Mayor.BaseApplicationException
			{
				static string TextoError = "El mayor en moneda FCI no se puede mostrar cuando la cuenta seleccionada y el FCI seleccionado son en distintas monedas extranjeras";
				public FondoMonExtCuentaMonExt() : base(TextoError) { }
				public FondoMonExtCuentaMonExt(Exception inner) : base(TextoError, inner) { }
				public FondoMonExtCuentaMonExt(SerializationInfo info, StreamingContext context) : base(info, context) { }
			}
		}
		namespace ModoEnum
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoImplementado : Cedeira.Ex.Validaciones.ModoEnum.BaseApplicationException
			{
				static string TextoError = "El modo: '";
				static string TextoError2 = "' no está implementado";
				public NoImplementado(string Modo) : base(TextoError+Modo+TextoError2) {}
				public NoImplementado(Exception inner) : base(TextoError, inner) {}
				public NoImplementado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace Operaciones
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoBalancea : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "La operación no balancea.  Verifique la Diferencia.";
				public NoBalancea() : base(TextoError) {}
				public NoBalancea(Exception inner) : base(TextoError, inner) {}
				public NoBalancea(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class DetalleNoIngresado : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "La operación debe contener, al menos, dos minutas";
				public DetalleNoIngresado() : base(TextoError) {}
				public DetalleNoIngresado(Exception inner) : base(TextoError, inner) {}
				public DetalleNoIngresado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MinutaAutomatica : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Opcion invalida en minuta automatica";
				public MinutaAutomatica() : base(TextoError) {}
				public MinutaAutomatica(Exception inner) : base(TextoError, inner) {}
				public MinutaAutomatica(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CierreCambioNoIngresado : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Cierre de Cambio no ingresado";
				public CierreCambioNoIngresado() : base(TextoError) {}
				public CierreCambioNoIngresado(Exception inner) : base(TextoError, inner) {}
				public CierreCambioNoIngresado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class UNincongruente : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Hay, al menos, una minuta que referencia a una cuenta de otra unidad de negocio";
				public UNincongruente() : base(TextoError) {}
				public UNincongruente(Exception inner) : base(TextoError, inner) {}
				public UNincongruente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class Fechaincongruente : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Hay, al menos, una minuta con un vencimiento establecido. Para modificar la fecha de la operación, dé de baja la minuta y depure.";
				public Fechaincongruente() : base(TextoError) {}
				public Fechaincongruente(Exception inner) : base(TextoError, inner) {}
				public Fechaincongruente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoEnEstadoFinal : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos una operación que no se encuentra en estado final.";
				public NoEnEstadoFinal() : base(TextoError) {}
				public NoEnEstadoFinal(Exception inner) : base(TextoError, inner) {}
				public NoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class PreciosNoEnEstadoFinal : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos un precio que no se encuentra en estado final.";
				public PreciosNoEnEstadoFinal() : base(TextoError) {}
				public PreciosNoEnEstadoFinal(Exception inner) : base(TextoError, inner) {}
				public PreciosNoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TasaCAyCCENoEnEstadoFinal : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos una tasa que no se encuentra en estado final.";
				public TasaCAyCCENoEnEstadoFinal() : base(TextoError) {}
				public TasaCAyCCENoEnEstadoFinal(Exception inner) : base(TextoError, inner) {}
				public TasaCAyCCENoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CierreDeCambioNoEnEstadoFinal : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos un cierre de cambio que no se encuentra en estado final.";
				public CierreDeCambioNoEnEstadoFinal() : base(TextoError) {}
				public CierreDeCambioNoEnEstadoFinal(Exception inner) : base(TextoError, inner) {}
				public CierreDeCambioNoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			namespace Minutas
			{
				[Serializable]
				public class BaseApplicationException : Cedeira.Ex.Validaciones.Operaciones.BaseApplicationException 
				{
					public BaseApplicationException(string TextoError) : base(TextoError) {}
					public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
					public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class UNincongruente : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Unidad de Negocio incongruente.  No se incorporará la minuta.";
					public UNincongruente() : base(TextoError) {}
					public UNincongruente(Exception inner) : base(TextoError, inner) {}
					public UNincongruente(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class IndiceFueraDeRango : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Unidad de Negocio incongruente.  No se incorporará la minuta.";
					public IndiceFueraDeRango() : base(TextoError) {}
					public IndiceFueraDeRango(Exception inner) : base(TextoError, inner) {}
					public IndiceFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class ConvinacionTipoMovProductoInvalido : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Tipo de movimiento, en Producto, inválido";
					public ConvinacionTipoMovProductoInvalido() : base(TextoError) {}
					public ConvinacionTipoMovProductoInvalido(Exception inner) : base(TextoError, inner) {}
					public ConvinacionTipoMovProductoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class CantidadCPResc : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "No se pueden rescatar mas cuotapartes de las suscriptas";
					public CantidadCPResc() : base(TextoError) {}
					public CantidadCPResc(Exception inner) : base(TextoError, inner) {}
					public CantidadCPResc(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class ImporteAPagarNegativo : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Las deducciones deben ser menor al capital más los intereses";
					public ImporteAPagarNegativo() : base(TextoError) {}
					public ImporteAPagarNegativo(Exception inner) : base(TextoError, inner) {}
					public ImporteAPagarNegativo(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class VentaTitulos : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "La cantidad(VN) disponible no es suficiente: ";
					public VentaTitulos(decimal Cantidad) : base(TextoError + Cantidad) {}
					public VentaTitulos(Exception inner) : base(TextoError, inner) {}
					public VentaTitulos(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class DifCamEnCtaPesos : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Los movimientos de diferencia de cambio no se pueden aplicar a rubros en pesos";
					public DifCamEnCtaPesos() : base(TextoError) {}
					public DifCamEnCtaPesos(Exception inner) : base(TextoError, inner) {}
					public DifCamEnCtaPesos(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
				[Serializable]
				public class DifCamTipoMovInvalido : Cedeira.Ex.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Tipo de movimiento invalido en operacion de Diferencia de Cambio";
					public DifCamTipoMovInvalido() : base(TextoError) {}
					public DifCamTipoMovInvalido(Exception inner) : base(TextoError, inner) {}
					public DifCamTipoMovInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
				}
			}
		}
		namespace TipoMov
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class Invalido : Cedeira.Ex.Validaciones.TipoMov.BaseApplicationException
			{
				static string TextoError = ": Tipo de movimiento inválido";
				public Invalido(string tipoMov) : base(tipoMov+TextoError) {}
				public Invalido(Exception inner) : base(TextoError, inner) {}
				public Invalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class InvalidoParaElProducto : Cedeira.Ex.Validaciones.TipoMov.BaseApplicationException
			{
				static string TextoError = ": Tipo de movimiento inválido para el producto: ";
				public InvalidoParaElProducto(string tipoMov, string producto) : base(tipoMov+TextoError+producto) {}
				public InvalidoParaElProducto(Exception inner) : base(TextoError, inner) {}
				public InvalidoParaElProducto(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace Cuentas
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class Duplicada : Cedeira.Ex.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "No se pudo dar de alta esa cuenta porque ya está cargada.";
				public Duplicada() : base(TextoError) {}
				public Duplicada(Exception inner) : base(TextoError, inner) {}
				public Duplicada(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			public class IdCuentaDuplicado : Cedeira.Ex.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "El nuevo Id. de cuenta generaría valores duplicados";
				public IdCuentaDuplicado() : base(TextoError) {}
				public IdCuentaDuplicado(Exception inner) : base(TextoError, inner) {}
				public IdCuentaDuplicado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TasaDuplicada : Cedeira.Ex.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "Esa tasa ya existe en el sistema.";
				public TasaDuplicada() : base(TextoError) {}
				public TasaDuplicada(Exception inner) : base(TextoError, inner) {}
				public TasaDuplicada(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace Especies
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CodigoCV : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El código de CV debe tener cinco dígitos";
				public CodigoCV() : base(TextoError) {}
				public CodigoCV(Exception inner) : base(TextoError, inner) {}
				public CodigoCV(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class CodBCRA : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El código de moneda de BCRA no está cargado en el sistema:";
				public CodBCRA(string CodBCRA) : base(TextoError+CodBCRA) {}
				public CodBCRA(Exception inner) : base(TextoError, inner) {}
				public CodBCRA(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieSinCotizacionFCI : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay precio ingresado/capturado para la especie de CódigoCV:";
				public EspecieSinCotizacionFCI(string CodigoCV) : base(TextoError+CodigoCV) {}
				public EspecieSinCotizacionFCI(Exception inner) : base(TextoError, inner) {}
				public EspecieSinCotizacionFCI(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieSinCotizacion : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay último precio negociado en catálogo para la especie de CódigoCV:";
				public EspecieSinCotizacion(string CodigoCV) : base(TextoError+CodigoCV) {}
				public EspecieSinCotizacion(Exception inner) : base(TextoError, inner) {}
				public EspecieSinCotizacion(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TasaBadlarSinCotizacion : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No existe la tasa badlar para esa fecha en CU";
				public TasaBadlarSinCotizacion() : base(TextoError) {}
				public TasaBadlarSinCotizacion(Exception inner) : base(TextoError, inner) {}
				public TasaBadlarSinCotizacion(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieSinCroFecha : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se puede consultar a CedPM con fecha mayor a la de proceso";
				public EspecieSinCroFecha() : base(TextoError) {}
				public EspecieSinCroFecha(Exception inner) : base(TextoError, inner) {}
				public EspecieSinCroFecha(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieFechaConsultaPrecio : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se puede consultar a CU un precio de especie con fecha distinta a la del día";
				public EspecieFechaConsultaPrecio() : base(TextoError) {}
				public EspecieFechaConsultaPrecio(Exception inner) : base(TextoError, inner) {}
				public EspecieFechaConsultaPrecio(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MonedaSinCotizacionBNA : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay cotización para la moneda ";
				public MonedaSinCotizacionBNA(string IdMoneda) : base(TextoError+IdMoneda) {}
				public MonedaSinCotizacionBNA(Exception inner) : base(TextoError, inner) {}
				public MonedaSinCotizacionBNA(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MonedaNoContemplada : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El sistema no puede consultar precios de la moneda ";
				public MonedaNoContemplada(string IdMoneda) : base(TextoError+IdMoneda) {}
				public MonedaNoContemplada(Exception inner) : base(TextoError, inner) {}
				public MonedaNoContemplada(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MercadoNoContemplado : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No existe el mercado en el sistema: ";
				public MercadoNoContemplado(string IdMercado) : base(TextoError+IdMercado) {}
				public MercadoNoContemplado(Exception inner) : base(TextoError, inner) {}
				public MercadoNoContemplado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieEnCartera : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Especie actualmente en cartera de al menos un fondo";
				public EspecieEnCartera() : base(TextoError) {}
				public EspecieEnCartera(Exception inner) : base(TextoError, inner) {}
				public EspecieEnCartera(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieEnCarteraFondoDelDiaSiguiente : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Especie con precio en moneda extranjera no admitida en un fondo que publica valor de cuotaparte del día siguiente";
				public EspecieEnCarteraFondoDelDiaSiguiente() : base(TextoError) {}
				public EspecieEnCarteraFondoDelDiaSiguiente(Exception inner) : base(TextoError, inner) {}
				public EspecieEnCarteraFondoDelDiaSiguiente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieYaExistente : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Esa especie ya existe en el sistema.";
				public EspecieYaExistente() : base(TextoError) {}
				public EspecieYaExistente(Exception inner) : base(TextoError, inner) {}
				public EspecieYaExistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieYaExistenteCAFCI : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se pudo dar de alta porque existe una especie con igual código CAFCI y tipo de código CAFCI.";
				public EspecieYaExistenteCAFCI() : base(TextoError) {}
				public EspecieYaExistenteCAFCI(Exception inner) : base(TextoError, inner) {}
				public EspecieYaExistenteCAFCI(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class EspecieSinFechaVtoInformada : Cedeira.Ex.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Hay al menos una especie sin fecha de vencimiento informada";
				public EspecieSinFechaVtoInformada(string IdEspecie) : base(TextoError+" "+IdEspecie) {}
				public EspecieSinFechaVtoInformada(Exception inner) : base(TextoError, inner) {}
				public EspecieSinFechaVtoInformada(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace TipoOperacion
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class Inexistente : Cedeira.Ex.Validaciones.TipoOperacion.BaseApplicationException
			{
				static string TextoError = "El tipo de producto '";
				static string TextoError2 = "' es nuevo y no puede ser tenido en cuenta en el cierre de ejercicio";
				public Inexistente(string IdTipoOp) : base(TextoError+IdTipoOp+TextoError2) {}
				public Inexistente(Exception inner) : base(TextoError+TextoError2, inner) {}
				public Inexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
		namespace UN
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Validaciones.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class TipoInvalido : Cedeira.Ex.Validaciones.TipoMov.BaseApplicationException
			{
				static string TextoError = ": Tipo de UN inválido";
				public TipoInvalido(string tipoUn) : base(tipoUn+TextoError) {}
				public TipoInvalido(Exception inner) : base(TextoError, inner) {}
				public TipoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
	}
	namespace Sesion {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Crear : Cedeira.Ex.Sesion.BaseApplicationException {
			static string TextoError = "No se puede crear una sesion de trabajo";
			public Crear() : base(TextoError) {}
			public Crear(Exception inner) : base(TextoError, inner) {}
			public Crear(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class AplicInvalida : Cedeira.Ex.Sesion.BaseApplicationException {
			static string TextoError = "Codigo de aplicación inválido";
			public AplicInvalida() : base(TextoError) {}
			public AplicInvalida(Exception inner) : base(TextoError, inner) {}
			public AplicInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ParametroInexistente : Cedeira.Ex.Sesion.BaseApplicationException 
		{
			static string TextoError = "Parámetro AppConfig inexistente: ";
			public ParametroInexistente(string NombreParametro) : base(TextoError+NombreParametro) {}
			public ParametroInexistente(Exception inner) : base(TextoError, inner) {}
			public ParametroInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		namespace Usuario 
		{
		[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Sesion.BaseApplicationException 
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoHabilitado : Cedeira.Ex.Sesion.Usuario.BaseApplicationException
			{
				static string TextoError = "Usuario no habilitado";
				public NoHabilitado() : base(TextoError) {}
				public NoHabilitado(Exception inner) : base(TextoError, inner) {}
				public NoHabilitado(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class NoActivo : Cedeira.Ex.Sesion.Usuario.BaseApplicationException
			{
				static string TextoError = "Usuario no activo";
				public NoActivo() : base(TextoError) {}
				public NoActivo(Exception inner) : base(TextoError, inner) {}
				public NoActivo(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class DeBaja : Cedeira.Ex.Sesion.Usuario.BaseApplicationException
			{
				static string TextoError = "Usuario dado de baja";
				public DeBaja() : base(TextoError) {}
				public DeBaja(Exception inner) : base(TextoError, inner) {}
				public DeBaja(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
	}
	namespace Tablero 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EstadoSectorInvalido : Cedeira.Ex.Tablero.BaseApplicationException
		{
			static string TextoError = "Combinación Estado-Sector inválida en armado de tablero";
			public EstadoSectorInvalido() : base(TextoError) {}
			public EstadoSectorInvalido(Exception inner) : base(TextoError, inner) {}
			public EstadoSectorInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}

	namespace Replicador 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ReplicadandoDatos : Cedeira.Ex.Replicador.BaseApplicationException
		{
			static string TextoError = "Problema replicando datos";
			public ReplicadandoDatos() : base(TextoError) {}
			public ReplicadandoDatos(string msg) : base(TextoError + ": " + msg){}
			public ReplicadandoDatos(Exception inner) : base(TextoError, inner) {}
			public ReplicadandoDatos(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}

	namespace Archivo 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ProcesarArchivo : Cedeira.Ex.Archivo.BaseApplicationException
		{
			static string TextoError = "Problema procesando archivo";
			public ProcesarArchivo() : base(TextoError) {}
			public ProcesarArchivo(string msg) : base(TextoError + ": " + msg){}
			public ProcesarArchivo(Exception inner) : base(TextoError, inner) {}
			public ProcesarArchivo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ArchivoInconsistente : Cedeira.Ex.Archivo.BaseApplicationException 
		{
			static string TextoError = "Archivo inconsistente";
			public ArchivoInconsistente() : base(TextoError) {}
			public ArchivoInconsistente(string msg) : base(TextoError + ": " + msg){}
			public ArchivoInconsistente(Exception inner) : base(TextoError, inner) {}
			public ArchivoInconsistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ArchivoInexistente : Cedeira.Ex.Archivo.BaseApplicationException 
		{
			static string TextoError = "Archivo inexistente";
			public ArchivoInexistente() : base(TextoError) {}
			public ArchivoInexistente(string NombreArchivo) : base(TextoError + ": " + NombreArchivo){}
			public ArchivoInexistente(Exception inner) : base(TextoError, inner) {}
			public ArchivoInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace XML 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Transformacion : Cedeira.Ex.XML.BaseApplicationException
		{
			static string TextoError = "Transformación fallida";
			public Transformacion() : base(TextoError) {}
			public Transformacion(Exception inner) : base(TextoError, inner) {}
			public Transformacion(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Colocaciones 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CapitalNoInfo : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Capital no informado";
			public CapitalNoInfo() : base(TextoError) {}
			public CapitalNoInfo(Exception inner) : base(TextoError, inner) {}
			public CapitalNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class TasaNoInfo : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Tasa no informada";
			public TasaNoInfo() : base(TextoError) {}
			public TasaNoInfo(Exception inner) : base(TextoError, inner) {}
			public TasaNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PlazoNoInfo : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Plazo no informado";
			public PlazoNoInfo() : base(TextoError) {}
			public PlazoNoInfo(Exception inner) : base(TextoError, inner) {}
			public PlazoNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class VtoNoHabil : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Vencimiento en día no habil";
			public VtoNoHabil() : base(TextoError) {}
			public VtoNoHabil(Exception inner) : base(TextoError, inner) {}
			public VtoNoHabil(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ColocRenovada : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Hay una colocación que ya ha sido renovada";
			public ColocRenovada() : base(TextoError) {}
			public ColocRenovada(Exception inner) : base(TextoError, inner) {}
			public ColocRenovada(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ColocCancelada : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Hay una colocación que ya ha sido cancelada";
			public ColocCancelada() : base(TextoError) {}
			public ColocCancelada(Exception inner) : base(TextoError, inner) {}
			public ColocCancelada(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ColocRenovIncorrecta : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "No se puede renovar colocaciones no vencidas";
			public ColocRenovIncorrecta() : base(TextoError) {}
			public ColocRenovIncorrecta(Exception inner) : base(TextoError, inner) {}
			public ColocRenovIncorrecta(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PFRenovado : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Hay un plazo fijo que ya ha sido renovado";
			public PFRenovado() : base(TextoError) {}
			public PFRenovado(Exception inner) : base(TextoError, inner) {}
			public PFRenovado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PFCancelado : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Hay un plazo fijo que ya ha sido cancelado";
			public PFCancelado() : base(TextoError) {}
			public PFCancelado(Exception inner) : base(TextoError, inner) {}
			public PFCancelado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PFNoVencido : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Hay un plazo fijo que no está vencido";
			public PFNoVencido() : base(TextoError) {}
			public PFNoVencido(Exception inner) : base(TextoError, inner) {}
			public PFNoVencido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PFRenovIncorrecta : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "No se puede renovar plazos fijos vigentes";
			public PFRenovIncorrecta() : base(TextoError) {}
			public PFRenovIncorrecta(Exception inner) : base(TextoError, inner) {}
			public PFRenovIncorrecta(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ErrorPrecalculo : Cedeira.Ex.Colocaciones.BaseApplicationException 
		{
			static string TextoError = "Error en precalculo de plazo fijo: ";
			public ErrorPrecalculo(string precalcErr) : base(TextoError+precalcErr) {}
			public ErrorPrecalculo(Exception inner) : base(TextoError, inner) {}
			public ErrorPrecalculo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Host {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CantDiasInvalida : Cedeira.Ex.Host.BaseApplicationException
		{
			static string TextoError = "(HOST) Cantidad de días inválida";
			public CantDiasInvalida() : base(TextoError) {}
			public CantDiasInvalida(Exception inner) : base(TextoError, inner) {}
			public CantDiasInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class InversorSinPersRel : Cedeira.Ex.Host.BaseApplicationException 
		{
			static string TextoError = "(HOST) Inversor SIN personas relacionadas.";
			public InversorSinPersRel() : base(TextoError) {}
			public InversorSinPersRel(Exception inner) : base(TextoError, inner) {}
			public InversorSinPersRel(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class InversorMasdeCuatro : Cedeira.Ex.Host.BaseApplicationException 
		{
			static string TextoError = "(HOST) El inversor posee mas de 4 titulares";
			public InversorMasdeCuatro() : base(TextoError) {}
			public InversorMasdeCuatro(Exception inner) : base(TextoError, inner) {}
			public InversorMasdeCuatro(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PersonaInex : Cedeira.Ex.Host.BaseApplicationException 
		{
			static string TextoError = "(HOST) ";
			public PersonaInex(string descr) : base(TextoError + descr) {}
			public PersonaInex(Exception inner) : base(TextoError, inner) {}
			public PersonaInex(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Titularidad : Cedeira.Ex.Host.BaseApplicationException 
		{
			static string TextoError = "(HOST) ";
			public Titularidad(string descr) : base(TextoError + descr) {}
			public Titularidad(Exception inner) : base(TextoError, inner) {}
			public Titularidad(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CU : Cedeira.Ex.Host.BaseApplicationException 
		{
			static string TextoError = "(HOST) ";
			public CU(string descr) : base(TextoError + descr) {}
			public CU(Exception inner) : base(TextoError, inner) {}
			public CU(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		namespace MCS
		{
			[Serializable]
			public class BaseApplicationException : Cedeira.Ex.Host.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError) {}
				public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class MCS : Cedeira.Ex.Host.MCS.BaseApplicationException 
			{
				static string TextoError = "(MCS) ";
				public MCS(string descr) : base(TextoError + descr) {}
				public MCS(Exception inner) : base(TextoError, inner) {}
				public MCS(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
			[Serializable]
			public class SyR : Cedeira.Ex.Host.MCS.BaseApplicationException
			{
				static string TextoError = "(MCS) No se pueden capturar suscripciones y rescates con fecha valor mayor a un día.";
				public SyR() : base(TextoError) {}
				public SyR(Exception inner) : base(TextoError, inner) {}
				public SyR(SerializationInfo info, StreamingContext context) : base(info, context) {}
			}
		}
	}
	namespace Login {
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class AutenticacionInvalida : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "Tipo de autenticacion invalida.  Corrija el archivo de configuracion.";
			public AutenticacionInvalida() : base(TextoError) {}
			public AutenticacionInvalida(Exception inner) : base(TextoError, inner) {}
			public AutenticacionInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class IdUsuarioNoInfo : Cedeira.Ex.Login.BaseApplicationException 
		{
			static string TextoError = "Nombre del usuario no informado";
			public IdUsuarioNoInfo() : base(TextoError) {}
			public IdUsuarioNoInfo(Exception inner) : base(TextoError, inner) {}
			public IdUsuarioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PasswordNoInfo : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "Contraseña no informada";
			public PasswordNoInfo() : base(TextoError) {}
			public PasswordNoInfo(Exception inner) : base(TextoError, inner) {}
			public PasswordNoInfo(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class PasswordNoMatch : Cedeira.Ex.Login.BaseApplicationException 
		{
			static string TextoError = "Contraseña incorrecta";
			public PasswordNoMatch() : base(TextoError) {}
			public PasswordNoMatch(Exception inner) : base(TextoError, inner) {}
			public PasswordNoMatch(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class UsuarioRevocado : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha sido revocado";
			public UsuarioRevocado() : base(TextoError) {}
			public UsuarioRevocado(Exception inner) : base(TextoError, inner) {}
			public UsuarioRevocado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class Indefinido : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "Problema indefinido en el login: ";
			public Indefinido(string error) : base(TextoError + error) { }
			public Indefinido(Exception inner) : base(TextoError, inner) { }
			public Indefinido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class UsuarioInvalido : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "El código de usuario es inválido";
			public UsuarioInvalido() : base(TextoError) {}
			public UsuarioInvalido(Exception inner) : base(TextoError, inner) {}
			public UsuarioInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class UsuarioExpirado : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha expirado";
			public UsuarioExpirado() : base(TextoError) {}
			public UsuarioExpirado(Exception inner) : base(TextoError, inner) {}
			public UsuarioExpirado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class DestinoInvalido : Cedeira.Ex.Login.BaseApplicationException
		{
			static string TextoError = "El destino es inválido";
			public DestinoInvalido() : base(TextoError) {}
			public DestinoInvalido(Exception inner) : base(TextoError, inner) {}
			public DestinoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace DDF
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class DDFInexistente : Cedeira.Ex.DDF.BaseApplicationException
		{
			static string TextoError = "Definición de Dato Básico/Fórmula/Template inexistente";
			public DDFInexistente() : base(TextoError) {}
			public DDFInexistente(Exception inner) : base(TextoError, inner) {}
			public DDFInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoInvalido : Cedeira.Ex.DDF.BaseApplicationException 
		{
			static string TextoError = "Evento inválido";
			public EventoInvalido() : base(TextoError) {}
			public EventoInvalido(Exception inner) : base(TextoError, inner) {}
			public EventoInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class EventoIncorrecto : Cedeira.Ex.DDF.BaseApplicationException 
		{
			static string TextoError = "Evento incorrecto en el estado actual";
			public EventoIncorrecto() : base(TextoError) {}
			public EventoIncorrecto(Exception inner) : base(TextoError, inner) {}
			public EventoIncorrecto(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class SectoresPtesDataEntry : Cedeira.Ex.DDF.BaseApplicationException 
		{
			static string TextoError = "No se puede iniciar el proceso porque hay sectores con carga de datos pendiente\r\n";
			public SectoresPtesDataEntry(string listaSectores) : base(TextoError+listaSectores) {}
			public SectoresPtesDataEntry(Exception inner) : base(TextoError, inner) {}
			public SectoresPtesDataEntry(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Formula
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class DelimVarIncorrecto : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "Posición de delimitador de variable incorrecta";
			public DelimVarIncorrecto(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public DelimVarIncorrecto(Exception inner) : base(TextoError, inner) {}
			public DelimVarIncorrecto(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ParentesisNoBalancean : Cedeira.Ex.Formula.BaseApplicationException 
		{
			static string TextoError = "No balancean los parentesis";
			public ParentesisNoBalancean() : base(TextoError) {}
			public ParentesisNoBalancean(Exception inner) : base(TextoError, inner) {}
			public ParentesisNoBalancean(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class VarInesperada : Cedeira.Ex.Formula.BaseApplicationException 
		{
			static string TextoError = "No se esperaba una variable";
			public VarInesperada(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public VarInesperada(Exception inner) : base(TextoError, inner) {}
			public VarInesperada(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OperInesperado : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "No se esperaba un operador";
			public OperInesperado(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public OperInesperado(Exception inner) : base(TextoError, inner) {}
			public OperInesperado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ApertParIncorrecta : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "Apertura de parentesis incorrecta";
			public ApertParIncorrecta(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public ApertParIncorrecta(Exception inner) : base(TextoError, inner) {}
			public ApertParIncorrecta(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CierreParIncorrecta : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "Cierre de parentesis incorrecto";
			public CierreParIncorrecta(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public CierreParIncorrecta(Exception inner) : base(TextoError, inner) {}
			public CierreParIncorrecta(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class DDFInexistente : Cedeira.Ex.Formula.BaseApplicationException 
		{
			static string TextoError = "Dato Básico, o Fórmula, inexistente: ";
			public DDFInexistente(string IdDDF) : base(TextoError+" ["+IdDDF+"]") {}
			public DDFInexistente(Exception inner) : base(TextoError, inner) {}
			public DDFInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class CaracterInvalido : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "Caracter inválido";
			public CaracterInvalido(int posicion) : base(TextoError+" (Pos "+posicion+")") {}
			public CaracterInvalido(Exception inner) : base(TextoError, inner) {}
			public CaracterInvalido(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class FaltanOperandos : Cedeira.Ex.Formula.BaseApplicationException
		{
			static string TextoError = "Faltan operandos";
			public FaltanOperandos() : base(TextoError) {}
			public FaltanOperandos(Exception inner) : base(TextoError, inner) {}
			public FaltanOperandos(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Aplicacion 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class AssemblyVersionInvalida : Cedeira.Ex.Aplicacion.BaseApplicationException
		{
			static string TextoError = "Versión desactualizada";
			public AssemblyVersionInvalida(string VersionNoActualizada, string VersionVigente) : base("La versión que se esta ejecutando ("+VersionNoActualizada+") no está actualizada.\r\nSolicite la instalación de la versión "+VersionVigente) {}
			public AssemblyVersionInvalida(Exception inner) : base(TextoError, inner) {}
			public AssemblyVersionInvalida(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace CapturaCedPM 
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ElementoInexistente : Cedeira.Ex.CapturaCedPM.BaseApplicationException
		{
			static string TextoError = " inexistente ";
			public ElementoInexistente(string Elemento, string IdUN) : base(Elemento+TextoError+"para IdFCI:"+IdUN) {}
			public ElementoInexistente(string Elemento) : base(Elemento+TextoError) {}
			public ElementoInexistente(Exception inner) : base(TextoError, inner) {}
			public ElementoInexistente(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class OperacionIncorporada : Cedeira.Ex.CapturaCedPM.BaseApplicationException
		{
			static string TextoError = "ya ha sido incorporada";
			public OperacionIncorporada() : base(TextoError) {}
			public OperacionIncorporada(Exception inner) : base(TextoError, inner) {}
			public OperacionIncorporada(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class IdTMovNoEncontrado : Cedeira.Ex.CapturaCedPM.BaseApplicationException
		{
			static string TextoError = "IdTMov (CedPM) no encontrado";
			public IdTMovNoEncontrado() : base(TextoError) {}
			public IdTMovNoEncontrado(Exception inner) : base(TextoError, inner) {}
			public IdTMovNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace Feriado
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class IdFeriadoInvalidoParaDarDeBaja : Cedeira.Ex.Feriado.BaseApplicationException 
		{
			static string TextoError = "El IdFeriado es menor o igual que la fecha de proceso. No se puede dar de baja";
			public IdFeriadoInvalidoParaDarDeBaja() : base(TextoError) {}
			public IdFeriadoInvalidoParaDarDeBaja(Exception inner) : base(TextoError, inner) {}
			public IdFeriadoInvalidoParaDarDeBaja(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class IdFeriadoInvalidoParaAnularLaBaja : Cedeira.Ex.Feriado.BaseApplicationException
		{
			static string TextoError = "El IdFeriado es menor o igual que la fecha de proceso. No se puede anular la baja";
			public IdFeriadoInvalidoParaAnularLaBaja() : base(TextoError) {}
			public IdFeriadoInvalidoParaAnularLaBaja(Exception inner) : base(TextoError, inner) {}
			public IdFeriadoInvalidoParaAnularLaBaja(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
	namespace ColdView
	{
		[Serializable]
		public class BaseApplicationException : Cedeira.Ex.BaseApplicationException 
		{
			public BaseApplicationException(string TextoError) : base(TextoError) {}
			public BaseApplicationException(string TextoError,Exception inner) : base(TextoError, inner) {}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
		[Serializable]
		public class ColdViewRangoGenerado : Cedeira.Ex.ColdView.BaseApplicationException
		{
			static string TextoError = "ColdView para ese rango de fechas ya fue generado";
			public ColdViewRangoGenerado() : base(TextoError) {}
			public ColdViewRangoGenerado(Exception inner) : base(TextoError, inner) {}
			public ColdViewRangoGenerado(SerializationInfo info, StreamingContext context) : base(info, context) {}
		}
	}
}