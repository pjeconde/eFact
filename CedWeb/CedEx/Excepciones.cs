using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Microsoft.ApplicationBlocks.ExceptionManagement
{
	/// <summary>
	/// Descripción breve de Excepciones.
	/// </summary>
	namespace Usuario
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError)
				: base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner)
				: base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
		[Serializable]
		public class Inexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
		{
			static string TextoError = "Usuario inexistente";
			public Inexistente() : base(TextoError)
			{
			}
			public Inexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public Inexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Impersonalizado : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
		{
			static string TextoError = "No se pudo impersonalizar a ";
			public Impersonalizado(string Usuario)
				: base(TextoError + Usuario)
			{
			}
			public Impersonalizado(Exception inner)
				: base(TextoError, inner)
			{
			}
			public Impersonalizado(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
	}
    namespace Cuenta
    {
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordYConfirmacionNoCoincidente : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "La Contraseña no coincide con su Confirmación";
            public PasswordYConfirmacionNoCoincidente()
                : base(TextoError)
            {
            }
            public PasswordYConfirmacionNoCoincidente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordYConfirmacionNoCoincidente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class IdUsuarioNoDisponible : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El IdUsuario, que ingresó, ya ha sido usado por otra persona.  Modifiquelo hasta encontrar un valor único.";
            public IdUsuarioNoDisponible()
                : base(TextoError)
            {
            }
            public IdUsuarioNoDisponible(Exception inner)
                : base(TextoError, inner)
            {
            }
            public IdUsuarioNoDisponible(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class CuentaConfFormatoMsgErroneo : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El mensaje de confirmación (de creación de la cuenta eFact) tiene un formato erróneo.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public CuentaConfFormatoMsgErroneo()
                : base(TextoError)
            {
            }
            public CuentaConfFormatoMsgErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public CuentaConfFormatoMsgErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class CuentaConfUpdateErroneo : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El evento de confirmación (de creación de la cuenta eFact) no puede ejecutarse.  Es probable que la confirmación ya haya sido registrada.  Verifique si puede identificarse.  En paso contrario, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public CuentaConfUpdateErroneo()
                : base(TextoError)
            {
            }
            public CuentaConfUpdateErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public CuentaConfUpdateErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXEstadoCuenta : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "Login inválido (la cuenta está pendiente de confirmación o dada de baja)";
            public LoginRechazadoXEstadoCuenta()
                : base(TextoError)
            {
            }
            public LoginRechazadoXEstadoCuenta(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXEstadoCuenta(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXPasswordInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "Contraseña inválida";
            public LoginRechazadoXPasswordInvalida()
                : base(TextoError)
            {
            }
            public LoginRechazadoXPasswordInvalida(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXPasswordInvalida(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace WF
	{
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
		public class OpInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Operacion inexistente (WF)";
			public OpInexistente() : base(TextoError)
			{
			}
			public OpInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public OpInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class EventoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "Evento invalido (WF)";
            public EventoInvalido()
                : base(TextoError)
            {
            }
            public EventoInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EventoInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EstadoHstInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "Seleccion inválida de EstadoHst (WF)";
            public EstadoHstInvalido()
                : base(TextoError)
            {
            }
            public EstadoHstInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EstadoHstInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EstadoHstNoDefinido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "EstadoHst no definido (WF)";
            public EstadoHstNoDefinido()
                : base(TextoError)
            {
            }
            public EstadoHstNoDefinido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EstadoHstNoDefinido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class FlowInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Flow invalido (WF)";
			public FlowInvalido() : base(TextoError)
			{
			}
			public FlowInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public FlowInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class CircuitoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Circuito invalido (WF)";
			public CircuitoInvalido() : base(TextoError)
			{
			}
			public CircuitoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public CircuitoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class NivSegInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Nivel de seguridad invalido (WF)";
			public NivSegInvalido() : base(TextoError)
			{
			}
			public NivSegInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public NivSegInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EventoSinSeg : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Evento sin esquema de seguridad asociado (WF)";
			public EventoSinSeg() : base(TextoError)
			{
			}
			public EventoSinSeg(Exception inner) : base(TextoError, inner)
			{
			}
			public EventoSinSeg(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class UsuarioNoCumpleSeg : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de seguridad del evento (WF)";
			public UsuarioNoCumpleSeg() : base(TextoError)
			{
			}
			public UsuarioNoCumpleSeg(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioNoCumpleSeg(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EventoIniMalConfigurado : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "El esquema de seguridad del evento inicial esta configurado de manera incorrecta.  Los eventos iniciales no deben requerir mas de una intervencion (WF)";
			public EventoIniMalConfigurado() : base(TextoError)
			{
			}
			public EventoIniMalConfigurado(Exception inner) : base(TextoError, inner)
			{
			}
			public EventoIniMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EstadoVirtualMalConfigurado : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "No es posible encontrar el valor del estado (virtual) de destino, definido en el evento (WF)";
			public EstadoVirtualMalConfigurado() : base(TextoError)
			{
			}
			public EstadoVirtualMalConfigurado(Exception inner) : base(TextoError, inner)
			{
			}
			public EstadoVirtualMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class CXO : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de control por oposicion (WF)";
			public CXO() : base(TextoError)
			{
			}
			public CXO(Exception inner) : base(TextoError, inner)
			{
			}
			public CXO(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class FechaProcesoNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "La fecha de proceso no coincide con la fecha de la base de datos";
			public FechaProcesoNoMatch() : base(TextoError)
			{
			}
			public FechaProcesoNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public FechaProcesoNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class FechaNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "La fecha no coincide con la fecha de proceso";
			public FechaNoMatch() : base(TextoError)
			{
			}
			public FechaNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public FechaNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace db
	{
		[Serializable]
		public class Conexion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema de conexión a base de datos";
			public Conexion() : base(TextoError)
			{
			}
			public Conexion(Exception inner) : base(TextoError, inner)
			{
			}
			public Conexion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Ejecucion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL";
			public Ejecucion() : base(TextoError)
			{
			}
			public Ejecucion(Exception inner) : base(TextoError, inner)
			{
			}
			public Ejecucion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class EjecucionConRollback : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL ( Se deshizo la operacion )";
			public EjecucionConRollback() : base(TextoError)
			{
			}
			public EjecucionConRollback(Exception inner) : base(TextoError, inner)
			{
			}
			public EjecucionConRollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Rollback : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema al tratar de deshacer la ejecución de un script de SQL";
			public Rollback() : base(TextoError)
			{
			}
			public Rollback(Exception inner) : base(TextoError, inner)
			{
			}
			public Rollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class FlowEventoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Combinación Flow-Evento invalida";
			public FlowEventoInvalido() : base(TextoError)
			{
			}
			public FlowEventoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public FlowEventoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TipoOpMepInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Operatoria inexistente";
			public TipoOpMepInexistente() : base(TextoError)
			{
			}
			public TipoOpMepInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public TipoOpMepInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class MepTransaccionalInsError : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "No se pudo impactar la transferencia en el Sistema MepTransaccional.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  La operacion debera ingresarse al Sistema Mep Transaccional mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepTransaccionalInsError(int IdMep) : base(TextoError + IdMep + ".")
			{
			}
			public MepTransaccionalInsError(int IdMep, Exception inner) : base(TextoError + IdMep + ".", inner)
			{
			}
			public MepTransaccionalInsError(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class MepUpdPk_nro_movimientoError : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "No se pudo registrar el N° de Movimiento de MepTransaccional en esta Aplicacion.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  El dato mencionado debera registrarse mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepUpdPk_nro_movimientoError(int IdMep) : base(TextoError + IdMep + ".")
			{
			}
			public MepUpdPk_nro_movimientoError(int IdMep, Exception inner) : base(TextoError + IdMep + ".", inner)
			{
			}
			public MepUpdPk_nro_movimientoError(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class MepUpdPk_nro_movimientoError2 : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "No se pudo registrar el N° de Movimiento de Mep Transaccional en esta Aplicacion porque el contenido de la transferencia ha sido modificado por otro usuario.  Reporte el problema al personal responsable del mantenimiento de la aplicacion inmediatamente.  El dato mencionado debera registrarse mediante el procedimiento de contingencia.  MepEnv N° ";
			public MepUpdPk_nro_movimientoError2(int IdMep) : base(TextoError + IdMep)
			{
			}
			public MepUpdPk_nro_movimientoError2(Exception inner) : base(TextoError, inner)
			{
			}
			public MepUpdPk_nro_movimientoError2(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Validaciones
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError) : base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class CierreCambioNoEncontrado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Cierre de Cambio no encontrado";
			public CierreCambioNoEncontrado(string IdMoneda, DateTime Fecha) : base(TextoError + ".  Moneda: '" + IdMoneda + "', Dia: " + Fecha.ToString("dd/MM/yyyy"))
			{
			}
			public CierreCambioNoEncontrado(Exception inner) : base(TextoError, inner)
			{
			}
			public CierreCambioNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class AjusteEnPrecancNoHabilitado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Ajuste de tasa y/o plazo no habilitado en pfs precancelables";
			public AjusteEnPrecancNoHabilitado() : base(TextoError)
			{
			}
			public AjusteEnPrecancNoHabilitado(Exception inner) : base(TextoError, inner)
			{
			}
			public AjusteEnPrecancNoHabilitado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TramoPrecancFueraDeRango : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "La duración de algún tramo se superpone con el tramo siguiente";
			public TramoPrecancFueraDeRango() : base(TextoError)
			{
			}
			public TramoPrecancFueraDeRango(Exception inner) : base(TextoError, inner)
			{
			}
			public TramoPrecancFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TramoPrecancTasaFueraDeRango : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Las tasas deben ser mayores a 0 e iguales o mayores a la del tramo anterior";
			public TramoPrecancTasaFueraDeRango() : base(TextoError)
			{
			}
			public TramoPrecancTasaFueraDeRango(Exception inner) : base(TextoError, inner)
			{
			}
			public TramoPrecancTasaFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TramoPrecancNoEncontrado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Definición de tramo no encontrada";
			public TramoPrecancNoEncontrado() : base(TextoError)
			{
			}
			public TramoPrecancNoEncontrado(Exception inner) : base(TextoError, inner)
			{
			}
			public TramoPrecancNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PrecioNoEncontrado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Precio no encontrado";
			public PrecioNoEncontrado(string DescrEspecie, DateTime Fecha) : base(TextoError + ".  Especie: '" + DescrEspecie + "', Dia: " + Fecha.ToString("dd/MM/yyyy"))
			{
			}
			public PrecioNoEncontrado(Exception inner) : base(TextoError, inner)
			{
			}
			public PrecioNoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PrecioNoEncontradoEnExcel : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
		{
			static string TextoError = "Precio no encontrado en planilla Excel: ";
			public PrecioNoEncontradoEnExcel(string DescrEspecie) : base(TextoError + DescrEspecie)
			{
			}
			public PrecioNoEncontradoEnExcel(Exception inner) : base(TextoError, inner)
			{
			}
			public PrecioNoEncontradoEnExcel(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ConexionInactiva : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "Conexión inactiva con ";
			public ConexionInactiva(string Sistema) : base(TextoError + Sistema)
			{
			}
			public ConexionInactiva(Exception inner) : base(TextoError, inner)
			{
			}
			public ConexionInactiva(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ElementoInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "inexistente";
			public ElementoInexistente(IDescrClase Elemento) : base(Elemento._Descripcion + " " + TextoError)
			{
			}
			public ElementoInexistente(IDescrClase Elemento, string Valor) : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
			{
			}
			public ElementoInexistente(string Descripcion) : base(Descripcion + " " + TextoError)
			{
			}
			public ElementoInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ElementoInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class AjustePrecision : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "No se puede ajustar ";
			public AjustePrecision(double Numero, int LongitudIncluyendoSeparador) : base(TextoError + Numero + " a " + LongitudIncluyendoSeparador + " posiciones")
			{
			}
			public AjustePrecision(Exception inner) : base(TextoError, inner)
			{
			}
			public AjustePrecision(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "valor inválido";
			public ValorInvalido(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "sin informar";
			public ValorNoInfo(string descrProp) : base(descrProp + " " + TextoError)
			{
			}
			public ValorNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ReadOnly : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "modificación inhabilitada";
			public ReadOnly(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ReadOnly(Exception inner) : base(TextoError, inner)
			{
			}
			public ReadOnly(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "no coincide, debe ser";
			public ValorNoMatch(string descrProp, string descrPropMatch) : base(descrProp + " " + TextoError + " " + descrPropMatch)
			{
			}
			public ValorNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNegativo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser mayor a cero";
			public ValorNegativo(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNegativo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNegativo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoNumerico : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser numerico";
			public ValorNoNumerico(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNoNumerico(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoNumerico(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoCombo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "opción inválida";
			public ValorNoCombo(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNoCombo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoCombo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class OpcionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "Opción inválida";
			public OpcionInvalida() : base(TextoError)
			{
			}
			public OpcionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public OpcionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class LenInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "longitud inválida";
			public LenInvalida(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public LenInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public LenInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TipoNoCoincidente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "el tipo de la base de datos no coincide con la propiedad";
			public TipoNoCoincidente(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public TipoNoCoincidente(Exception inner) : base(TextoError, inner)
			{
			}
			public TipoNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class NoEsMultiploDe24 : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser multiplo de 24";
			public NoEsMultiploDe24(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public NoEsMultiploDe24(Exception inner) : base(TextoError, inner)
			{
			}
			public NoEsMultiploDe24(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class ListaDeExcepciones : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            static string TextoError = "Lista de errores: ";
            private List<System.Exception> listaE;
            public ListaDeExcepciones(List<System.Exception> l) : base(TextoError)
            {
                listaE = l;
            }
            public List<System.Exception> ListaE
            {
                get
                {
                    return listaE;
                }
            }
        }

		namespace CashFlow
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CtasMonConceptos : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.CashFlow.BaseApplicationException
			{
				static string TextoError = "Se modificaron los conceptos de ingresos y/o egresos de cuentas monetarias. Actualize parámetros del sistema";
				public CtasMonConceptos() : base(TextoError)
				{
				}
				public CtasMonConceptos(Exception inner) : base(TextoError, inner)
				{
				}
				public CtasMonConceptos(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
		namespace Fechas
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaNoHabil : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Según host la fecha no es un día hábil.";
				public FechaNoHabil(string DescrProp) : base(DescrProp + ":" + TextoError)
				{
				}
				public FechaNoHabil(Exception inner) : base(TextoError, inner)
				{
				}
				public FechaNoHabil(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaDsdCashFlow : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "La fecha desde debe ser siempre la del día hábil anterior.";
				public FechaDsdCashFlow(string DescrProp) : base(DescrProp + ":" + TextoError)
				{
				}
				public FechaDsdCashFlow(Exception inner) : base(TextoError, inner)
				{
				}
				public FechaDsdCashFlow(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaFormatoNoValido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Formato incorrecto en: ";
				public FechaFormatoNoValido(string Nombre)
					: base(TextoError + Nombre)
				{
				}
				public FechaFormatoNoValido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaFormatoNoValido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaAñoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Año incorrecto en";
				public FechaAñoInvalido(string Nombre)
					: base(TextoError+Nombre)
				{
				}
				public FechaAñoInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaAñoInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}

			[Serializable]
			public class FechaMesInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Mes incorrecto en ";
				public FechaMesInvalido(string Nombre)
					: base(TextoError+ Nombre)
				{
				}
				public FechaMesInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaMesInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaDiaInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Dia Incorrecto en ";
				public FechaDiaInvalido(string Nombre)
					: base(TextoError + Nombre)
				{
				}
				public FechaDiaInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaDiaInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
		}
		namespace FCIs
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class SociedadesIguales : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "La sociedad gerente y la depositaria no pueden ser la misma.";
				public SociedadesIguales() : base(TextoError)
				{
				}
				public SociedadesIguales(Exception inner) : base(TextoError, inner)
				{
				}
				public SociedadesIguales(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class Confirmacion : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se pudo confirmar porque falta calcular el valorCP de al menos un fondo";
				public Confirmacion() : base(TextoError)
				{
				}
				public Confirmacion(Exception inner) : base(TextoError, inner)
				{
				}
				public Confirmacion(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EtapaCalculoConFCIsAsoc : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja una Etapa de Calculo que tenga FCIs vinculados.  Desvincule los FCIs y vuelva a intentar la baja.";
				public EtapaCalculoConFCIsAsoc() : base(TextoError)
				{
				}
				public EtapaCalculoConFCIsAsoc(Exception inner) : base(TextoError, inner)
				{
				}
				public EtapaCalculoConFCIsAsoc(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class RevalyCalcCPsinSyRsPermitido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No está permitido ejecutar el proceso de Revaluo de Cartera y calculo Valor CP sin informacion de Suscripciones y Rescates.";
				public RevalyCalcCPsinSyRsPermitido() : base(TextoError)
				{
				}
				public RevalyCalcCPsinSyRsPermitido(Exception inner) : base(TextoError, inner)
				{
				}
				public RevalyCalcCPsinSyRsPermitido(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EtapaCapturaConSubTipoEspeciesAsoc : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja una Etapa de Captura que tenga Subtipos de especies vinculadas.  Desvincule los Subtipos de especies y vuelva a intentar la baja.";
				public EtapaCapturaConSubTipoEspeciesAsoc() : base(TextoError)
				{
				}
				public EtapaCapturaConSubTipoEspeciesAsoc(Exception inner) : base(TextoError, inner)
				{
				}
				public EtapaCapturaConSubTipoEspeciesAsoc(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCIxlsRegistro : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "CedFCIxls.dll no está correctamente registrada.";
				public CedFCIxlsRegistro() : base(TextoError)
				{
				}
				public CedFCIxlsRegistro(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCIxlsRegistro(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCIxlsProceso : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar planilla excel:";
				public CedFCIxlsProceso(string Errores) : base(TextoError + Errores)
				{
				}
				public CedFCIxlsProceso(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCIxlsProceso(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCIItfMensualNoFile : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar interfaz mensual:";
				public CedFCIItfMensualNoFile(string Errores) : base(TextoError + Errores + ". Archivo inexistente.")
				{
				}
				public CedFCIItfMensualNoFile(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCIItfMensualNoFile(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCIItfSemanalCtaSinTag : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Error al procesar interfaz semanal. La cuenta no está asociada a un tag:";
				public CedFCIItfSemanalCtaSinTag(string Errores) : base(TextoError + Errores + ".")
				{
				}
				public CedFCIItfSemanalCtaSinTag(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCIItfSemanalCtaSinTag(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCINoSePuedeInformar : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede informar FCI Cartera en fondos que no sean de Clase";
				public CedFCINoSePuedeInformar(string Errores) : base(TextoError + Errores)
				{
				}
				public CedFCINoSePuedeInformar(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCINoSePuedeInformar(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCISinInformar : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "FCI Cartera sin informar";
				public CedFCISinInformar(string Errores) : base(TextoError + Errores)
				{
				}
				public CedFCISinInformar(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCISinInformar(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CedFCICtasAsocAFondosDeClase : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se admite que los fondos de Clase tengan cuentas asociadas. Primero elimine o reclasifique las cuentas y luego reintente la retipificación del fondo";
				public CedFCICtasAsocAFondosDeClase(string Errores) : base(TextoError + Errores)
				{
				}
				public CedFCICtasAsocAFondosDeClase(Exception inner) : base(TextoError, inner)
				{
				}
				public CedFCICtasAsocAFondosDeClase(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class UNTipoCarteraConDependencias : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "No se puede dar de baja un Fondo de Cartera sin antes dar de baja sus Fondos de Clase";
				public UNTipoCarteraConDependencias() : base(TextoError)
				{
				}
				public UNTipoCarteraConDependencias(Exception inner) : base(TextoError, inner)
				{
				}
				public UNTipoCarteraConDependencias(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class NoInformado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "El FCI no ha sido informado";
				public NoInformado() : base(TextoError)
				{
				}
				public NoInformado(Exception inner) : base(TextoError, inner)
				{
				}
				public NoInformado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class ValorCPCalculado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Existe un valor de cuotaparte calculado";
				public ValorCPCalculado() : base(TextoError)
				{
				}
				public ValorCPCalculado(Exception inner) : base(TextoError, inner)
				{
				}
				public ValorCPCalculado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class MonedaExtranjeraParaDiaSiguiente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Los fondos que publican precio para el día siguiente sólo pueden ser de moneda local.";
				public MonedaExtranjeraParaDiaSiguiente() : base(TextoError)
				{
				}
				public MonedaExtranjeraParaDiaSiguiente(Exception inner) : base(TextoError, inner)
				{
				}
				public MonedaExtranjeraParaDiaSiguiente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class ValorCPdiferente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
			{
				static string TextoError = "Diferencia en valor de cuota calculado para el día de proceso con respecto al calculado el día anterior. El precio correcto es ";
				public ValorCPdiferente(string IdUN, decimal PrecioCorrecto, decimal PrecioIncorrecto) : base("FCI " + IdUN + ":" + TextoError + PrecioCorrecto + " y es distinto a " + PrecioIncorrecto)
				{
				}
				public ValorCPdiferente(Exception inner) : base(TextoError, inner)
				{
				}
				public ValorCPdiferente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			namespace Proceso
			{
				[Serializable]
				public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.BaseApplicationException
				{
					public BaseApplicationException(string TextoError) : base(TextoError)
					{
					}
					public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
					{
					}
					public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class CapturaSyrDefinitivas : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.FCIs.Proceso.BaseApplicationException
				{
					static string TextoError = "No se pueden capturar suscripciones ni rescates cuando la fecha actual difiere en más de un día hábil con la de proceso.";
					public CapturaSyrDefinitivas() : base(TextoError)
					{
					}
					public CapturaSyrDefinitivas(Exception inner) : base(TextoError, inner)
					{
					}
					public CapturaSyrDefinitivas(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
			}
		}
		namespace Operaciones
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class NoBalancea : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "La operación no balancea.  Verifique la Diferencia.";
				public NoBalancea() : base(TextoError)
				{
				}
				public NoBalancea(Exception inner) : base(TextoError, inner)
				{
				}
				public NoBalancea(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class DetalleNoIngresado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "La operación debe contener, al menos, dos minutas";
				public DetalleNoIngresado() : base(TextoError)
				{
				}
				public DetalleNoIngresado(Exception inner) : base(TextoError, inner)
				{
				}
				public DetalleNoIngresado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class MinutaAutomatica : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Opcion invalida en minuta automatica";
				public MinutaAutomatica() : base(TextoError)
				{
				}
				public MinutaAutomatica(Exception inner) : base(TextoError, inner)
				{
				}
				public MinutaAutomatica(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CierreCambioNoIngresado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Cierre de Cambio no ingresado";
				public CierreCambioNoIngresado() : base(TextoError)
				{
				}
				public CierreCambioNoIngresado(Exception inner) : base(TextoError, inner)
				{
				}
				public CierreCambioNoIngresado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class UNincongruente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Hay, al menos, una minuta que referencia a una cuenta de otra unidad de negocio";
				public UNincongruente() : base(TextoError)
				{
				}
				public UNincongruente(Exception inner) : base(TextoError, inner)
				{
				}
				public UNincongruente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class Fechaincongruente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Hay, al menos, una minuta con un vencimiento establecido. Para modificar la fecha de la operación, dé de baja la minuta y depure.";
				public Fechaincongruente() : base(TextoError)
				{
				}
				public Fechaincongruente(Exception inner) : base(TextoError, inner)
				{
				}
				public Fechaincongruente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class NoEnEstadoFinal : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos una operación que no se encuentra en estado final.";
				public NoEnEstadoFinal() : base(TextoError)
				{
				}
				public NoEnEstadoFinal(Exception inner) : base(TextoError, inner)
				{
				}
				public NoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class PreciosNoEnEstadoFinal : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos un precio que no se encuentra en estado final.";
				public PreciosNoEnEstadoFinal() : base(TextoError)
				{
				}
				public PreciosNoEnEstadoFinal(Exception inner) : base(TextoError, inner)
				{
				}
				public PreciosNoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class TasaCAyCCENoEnEstadoFinal : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos una tasa que no se encuentra en estado final.";
				public TasaCAyCCENoEnEstadoFinal() : base(TextoError)
				{
				}
				public TasaCAyCCENoEnEstadoFinal(Exception inner) : base(TextoError, inner)
				{
				}
				public TasaCAyCCENoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CierreDeCambioNoEnEstadoFinal : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
			{
				static string TextoError = "Existe al menos un cierre de cambio que no se encuentra en estado final.";
				public CierreDeCambioNoEnEstadoFinal() : base(TextoError)
				{
				}
				public CierreDeCambioNoEnEstadoFinal(Exception inner) : base(TextoError, inner)
				{
				}
				public CierreDeCambioNoEnEstadoFinal(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			namespace Minutas
			{
				[Serializable]
				public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.BaseApplicationException
				{
					public BaseApplicationException(string TextoError) : base(TextoError)
					{
					}
					public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
					{
					}
					public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class UNincongruente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Unidad de Negocio incongruente.  No se incorporará la minuta.";
					public UNincongruente() : base(TextoError)
					{
					}
					public UNincongruente(Exception inner) : base(TextoError, inner)
					{
					}
					public UNincongruente(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class IndiceFueraDeRango : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Unidad de Negocio incongruente.  No se incorporará la minuta.";
					public IndiceFueraDeRango() : base(TextoError)
					{
					}
					public IndiceFueraDeRango(Exception inner) : base(TextoError, inner)
					{
					}
					public IndiceFueraDeRango(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class ConvinacionTipoMovProductoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Tipo de movimiento, en Producto, inválido";
					public ConvinacionTipoMovProductoInvalido() : base(TextoError)
					{
					}
					public ConvinacionTipoMovProductoInvalido(Exception inner) : base(TextoError, inner)
					{
					}
					public ConvinacionTipoMovProductoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class CantidadCPResc : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "No se pueden rescatar mas cuotapartes de las suscriptas";
					public CantidadCPResc() : base(TextoError)
					{
					}
					public CantidadCPResc(Exception inner) : base(TextoError, inner)
					{
					}
					public CantidadCPResc(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class ImporteAPagarNegativo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Las deducciones deben ser menor al capital más los intereses";
					public ImporteAPagarNegativo() : base(TextoError)
					{
					}
					public ImporteAPagarNegativo(Exception inner) : base(TextoError, inner)
					{
					}
					public ImporteAPagarNegativo(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class VentaTitulos : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "La cantidad(VN) disponible no es suficiente: ";
					public VentaTitulos(decimal Cantidad) : base(TextoError + Cantidad)
					{
					}
					public VentaTitulos(Exception inner) : base(TextoError, inner)
					{
					}
					public VentaTitulos(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class DifCamEnCtaPesos : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Los movimientos de diferencia de cambio no se pueden aplicar a rubros en pesos";
					public DifCamEnCtaPesos() : base(TextoError)
					{
					}
					public DifCamEnCtaPesos(Exception inner) : base(TextoError, inner)
					{
					}
					public DifCamEnCtaPesos(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
				[Serializable]
				public class DifCamTipoMovInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Operaciones.Minutas.BaseApplicationException
				{
					static string TextoError = "Tipo de movimiento invalido en operacion de Diferencia de Cambio";
					public DifCamTipoMovInvalido() : base(TextoError)
					{
					}
					public DifCamTipoMovInvalido(Exception inner) : base(TextoError, inner)
					{
					}
					public DifCamTipoMovInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
					{
					}
				}
			}
		}
		namespace Cuentas
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class Duplicada : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "No se pudo dar de alta esa cuenta porque ya está cargada.";
				public Duplicada() : base(TextoError)
				{
				}
				public Duplicada(Exception inner) : base(TextoError, inner)
				{
				}
				public Duplicada(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			public class IdCuentaDuplicado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "El nuevo Id. de cuenta generaría valores duplicados";
				public IdCuentaDuplicado() : base(TextoError)
				{
				}
				public IdCuentaDuplicado(Exception inner) : base(TextoError, inner)
				{
				}
				public IdCuentaDuplicado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class TasaDuplicada : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "Esa tasa ya existe en el sistema.";
				public TasaDuplicada() : base(TextoError)
				{
				}
				public TasaDuplicada(Exception inner) : base(TextoError, inner)
				{
				}
				public TasaDuplicada(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
		namespace Especies
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CodigoCV : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El código de CV debe tener cinco dígitos";
				public CodigoCV() : base(TextoError)
				{
				}
				public CodigoCV(Exception inner) : base(TextoError, inner)
				{
				}
				public CodigoCV(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class CodBCRA : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El código de moneda de BCRA no está cargado en el sistema:";
				public CodBCRA(string CodBCRA) : base(TextoError + CodBCRA)
				{
				}
				public CodBCRA(Exception inner) : base(TextoError, inner)
				{
				}
				public CodBCRA(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieSinCotizacionFCI : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay precio ingresado/capturado para la especie de CódigoCV:";
				public EspecieSinCotizacionFCI(string CodigoCV) : base(TextoError + CodigoCV)
				{
				}
				public EspecieSinCotizacionFCI(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieSinCotizacionFCI(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieSinCotizacion : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay último precio negociado en catálogo para la especie de CódigoCV:";
				public EspecieSinCotizacion(string CodigoCV) : base(TextoError + CodigoCV)
				{
				}
				public EspecieSinCotizacion(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieSinCotizacion(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class TasaBadlarSinCotizacion : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No existe la tasa badlar para esa fecha en CU";
				public TasaBadlarSinCotizacion() : base(TextoError)
				{
				}
				public TasaBadlarSinCotizacion(Exception inner) : base(TextoError, inner)
				{
				}
				public TasaBadlarSinCotizacion(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieSinCroFecha : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se puede consultar a CedPM con fecha mayor a la de proceso";
				public EspecieSinCroFecha() : base(TextoError)
				{
				}
				public EspecieSinCroFecha(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieSinCroFecha(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieFechaConsultaPrecio : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se puede consultar a CU un precio de especie con fecha distinta a la del día";
				public EspecieFechaConsultaPrecio() : base(TextoError)
				{
				}
				public EspecieFechaConsultaPrecio(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieFechaConsultaPrecio(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class MonedaSinCotizacionBNA : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No hay cotización para la moneda ";
				public MonedaSinCotizacionBNA(string IdMoneda) : base(TextoError + IdMoneda)
				{
				}
				public MonedaSinCotizacionBNA(Exception inner) : base(TextoError, inner)
				{
				}
				public MonedaSinCotizacionBNA(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class MonedaNoContemplada : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "El sistema no puede consultar precios de la moneda ";
				public MonedaNoContemplada(string IdMoneda) : base(TextoError + IdMoneda)
				{
				}
				public MonedaNoContemplada(Exception inner) : base(TextoError, inner)
				{
				}
				public MonedaNoContemplada(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class MercadoNoContemplado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No existe el mercado en el sistema: ";
				public MercadoNoContemplado(string IdMercado) : base(TextoError + IdMercado)
				{
				}
				public MercadoNoContemplado(Exception inner) : base(TextoError, inner)
				{
				}
				public MercadoNoContemplado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieEnCartera : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Especie actualmente en cartera de al menos un fondo";
				public EspecieEnCartera() : base(TextoError)
				{
				}
				public EspecieEnCartera(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieEnCartera(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieEnCarteraFondoDelDiaSiguiente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Especie con precio en moneda extranjera no admitida en un fondo que publica valor de cuotaparte del día siguiente";
				public EspecieEnCarteraFondoDelDiaSiguiente() : base(TextoError)
				{
				}
				public EspecieEnCarteraFondoDelDiaSiguiente(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieEnCarteraFondoDelDiaSiguiente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieYaExistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "Esa especie ya existe en el sistema.";
				public EspecieYaExistente() : base(TextoError)
				{
				}
				public EspecieYaExistente(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieYaExistente(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class EspecieYaExistenteCAFCI : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Especies.BaseApplicationException
			{
				static string TextoError = "No se pudo dar de alta porque existe una especie con igual código CAFCI y tipo de código CAFCI.";
				public EspecieYaExistenteCAFCI() : base(TextoError)
				{
				}
				public EspecieYaExistenteCAFCI(Exception inner) : base(TextoError, inner)
				{
				}
				public EspecieYaExistenteCAFCI(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
	}
	namespace Sesion
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError) : base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Crear : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "No se puede crear una sesion de trabajo";
			public Crear() : base(TextoError)
			{
			}
			public Crear(Exception inner) : base(TextoError, inner)
			{
			}
			public Crear(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class AplicInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Codigo de aplicación inválido";
			public AplicInvalida() : base(TextoError)
			{
			}
			public AplicInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AplicInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ParametroInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Parámetro AppConfig inexistente: ";
			public ParametroInexistente(string NombreParametro) : base(TextoError + NombreParametro)
			{
			}
			public ParametroInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ParametroInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		namespace Usuario
		{
			[Serializable]
			public class NoHabilitado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario no habilitado";
				public NoHabilitado() : base(TextoError)
				{
				}
				public NoHabilitado(Exception inner) : base(TextoError, inner)
				{
				}
				public NoHabilitado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class NoActivo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario no activo";
				public NoActivo() : base(TextoError)
				{
				}
				public NoActivo(Exception inner) : base(TextoError, inner)
				{
				}
				public NoActivo(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class DeBaja : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario dado de baja";
				public DeBaja() : base(TextoError)
				{
				}
				public DeBaja(Exception inner) : base(TextoError, inner)
				{
				}
				public DeBaja(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
	}
	namespace Archivo
	{
		[Serializable]
		public class ProcesarArchivo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema procesando archivo";
			public ProcesarArchivo() : base(TextoError)
			{
			}
			public ProcesarArchivo(string msg) : base(TextoError + ": " + msg)
			{
			}
			public ProcesarArchivo(Exception inner) : base(TextoError, inner)
			{
			}
			public ProcesarArchivo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ArchivoInconsistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Archivo inconsistente";
			public ArchivoInconsistente() : base(TextoError)
			{
			}
			public ArchivoInconsistente(string msg) : base(TextoError + ": " + msg)
			{
			}
			public ArchivoInconsistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ArchivoInconsistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ArchivoInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Archivo inexistente";
			public ArchivoInexistente() : base(TextoError)
			{
			}
			public ArchivoInexistente(string NombreArchivo) : base(TextoError + ": " + NombreArchivo)
			{
			}
			public ArchivoInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ArchivoInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace XML
	{
		[Serializable]
		public class Transformacion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Transformación fallida";
			public Transformacion() : base(TextoError)
			{
			}
			public Transformacion(Exception inner) : base(TextoError, inner)
			{
			}
			public Transformacion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Login
	{
		[Serializable]
		public class AutenticacionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Tipo de autenticacion invalida.  Corrija el archivo de configuración.";
			public AutenticacionInvalida() : base(TextoError)
			{
			}
			public AutenticacionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AutenticacionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class IdUsuarioNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Nombre del usuario no informado";
			public IdUsuarioNoInfo() : base(TextoError)
			{
			}
			public IdUsuarioNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public IdUsuarioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PasswordNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Contraseña no informada";
			public PasswordNoInfo() : base(TextoError)
			{
			}
			public PasswordNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public PasswordNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PasswordNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Contraseña incorrecta";
			public PasswordNoMatch() : base(TextoError)
			{
			}
			public PasswordNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public PasswordNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioRevocado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha sido revocado";
			public UsuarioRevocado() : base(TextoError)
			{
			}
			public UsuarioRevocado(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioRevocado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Indefinido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en el login";
			public Indefinido()
				: base(TextoError)
			{
			}
			public Indefinido(int CodError)
				: base(TextoError + ":" + CodError)
			{
			}
			public Indefinido(Exception inner)
				: base(TextoError, inner)
			{
			}
			public Indefinido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class NoInformado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Usuario no informado";
			public NoInformado()
				: base(TextoError)
			{
			}
			public NoInformado(Exception inner)
				: base(TextoError, inner)
			{
			}
			public NoInformado(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario es inválido";
			public UsuarioInvalido() : base(TextoError)
			{
			}
			public UsuarioInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioExpirado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha expirado";
			public UsuarioExpirado() : base(TextoError)
			{
			}
			public UsuarioExpirado(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioExpirado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class DestinoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El destino es inválido";
			public DestinoInvalido() : base(TextoError)
			{
			}
			public DestinoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public DestinoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Aplicacion
	{
		[Serializable]
		public class AssemblyVersionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException
		{
			static string TextoError = "Versión desactualizada";
			public AssemblyVersionInvalida(string VersionNoActualizada, string VersionVigente)
				: base("La versión que se esta ejecutando (" + VersionNoActualizada + ") no está actualizada.\r\nSolicite la instalación del release más actualizado de la  versión " + VersionVigente + " en el servidor " + System.Net.Dns.GetHostName())
			{
			}
			public AssemblyVersionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AssemblyVersionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace WS
	{
		[Serializable]
		public class MensajeErrorWSCP : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Error en WS: ";
			public MensajeErrorWSCP()
				: base(TextoError)
			{
			}
			public MensajeErrorWSCP(string Elemento): base(TextoError + Elemento)
			{
			}
			public MensajeErrorWSCP(Exception inner)
				: base(TextoError, inner)
			{
			}
			public MensajeErrorWSCP(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
	}
}
