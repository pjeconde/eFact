using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Cuenta
    {
        private string id;
        private string nombre;
        private string telefono;
        private string email;
        private string password;
        private string confirmacionPassword;
        private string pregunta;
        private string respuesta;
        private TipoCuenta tipoCuenta;
        private EstadoCuenta estadoCuenta;
        private Vendedor vendedor;
        private long ultimoNroLote;
        private DateTime fechaAlta;
        private int cantidadEnviosMail;
        private DateTime fechaUltimoReenvioMail;
        private bool activCP;
        private string nroSerieDisco;
        private Medio medio;
        private string emailSMS;
        private bool recibeAvisoAltaCuenta;
        private int cantidadComprobantes;
        private DateTime fechaUltimoComprobante;
        private DateTime fechaVtoPremium;
        private PaginaDefault paginaDefault;
		private string nroSerieCertificado;

        public Cuenta()
        {
            tipoCuenta = new TipoCuenta();
            estadoCuenta = new EstadoCuenta();
            vendedor = new Vendedor();
            medio = new Medio();
            paginaDefault = new PaginaDefault();
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string Telefono
        {
            set
            {
                telefono = value;
            }
            get
            {
                return telefono;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string ConfirmacionPassword
        {
            set
            {
                confirmacionPassword = value;
            }
            get
            {
                return confirmacionPassword;
            }
        }
        public string Pregunta
        {
            set
            {
                pregunta = value;
            }
            get
            {
                return pregunta;
            }
        }
        public string Respuesta
        {
            set
            {
                respuesta = value;
            }
            get
            {
                return respuesta;
            }
        }
        public TipoCuenta TipoCuenta
        {
            set
            {
                tipoCuenta = value;
            }
            get
            {
                return tipoCuenta;
            }
        }
        public EstadoCuenta EstadoCuenta
        {
            set
            {
                estadoCuenta = value;
            }
            get
            {
                return estadoCuenta;
            }
        }
        public Vendedor Vendedor
        {
            set
            {
                vendedor = value;
            }
            get
            {
                return vendedor;
            }
        }
        public string IdTipoCuenta
        {
            get
            {
                return tipoCuenta.Id;
            }
        }
        public string DescrTipoCuenta
        {
            get
            {
                return tipoCuenta.Descr;
            }
        }
        public string IdEstadoCuenta
        {
            get
            {
                return EstadoCuenta.Id;
            }
        }
        public string DescrEstadoCuenta
        {
            get
            {
                return EstadoCuenta.Descr;
            }
        }
        public long UltimoNroLote
        {
            set
            {
                ultimoNroLote = value;
            }
            get
            {
                return ultimoNroLote;
            }
        }
        public DateTime FechaAlta
        {
            set
            {
                fechaAlta = value;
            }
            get
            {
                return fechaAlta;
            }
        }
        public int CantidadEnviosMail
        {
            set
            {
                cantidadEnviosMail = value;
            }
            get
            {
                return cantidadEnviosMail;
            }
        }
        public DateTime FechaUltimoReenvioMail
        {
            set
            {
                fechaUltimoReenvioMail = value;
            }
            get
            {
                return fechaUltimoReenvioMail;
            }
        }
        public bool ActivCP
        {
            set
            {
                activCP = value;
            }
            get
            {
                return activCP;
            }
        }
        public string NroSerieDisco
        {
            set
            {
                nroSerieDisco = value;
            }
            get
            {
                return nroSerieDisco;
            }
        }
        public Medio Medio
        {
            set
            {
                medio = value;
            }
            get
            {
                return medio;
            }
        }
        public string IdMedio
        {
            get
            {
                return medio.Id;
            }
        }
        public string DescrMedio
        {
            get
            {
                return medio.Descr;
            }
        }
        public string EmailSMS
        {
            set
            {
                emailSMS = value;
            }
            get
            {
                return emailSMS;
            }
        }
        public bool RecibeAvisoAltaCuenta
        {
            set
            {
                recibeAvisoAltaCuenta = value;
            }
            get
            {
                return recibeAvisoAltaCuenta;
            }
        }
        public int CantidadComprobantes
        {
            set
            {
                cantidadComprobantes = value;
            }
            get
            {
                return cantidadComprobantes;
            }
        }
        public DateTime FechaUltimoComprobante
        {
            set
            {
                fechaUltimoComprobante = value;
            }
            get
            {
                return fechaUltimoComprobante;
            }
        }
        public DateTime FechaVtoPremium
        {
            set
            {
                fechaVtoPremium = value;
            }
            get
            {
                return fechaVtoPremium;
            }
        }
        public PaginaDefault PaginaDefault
        {
            set
            {
                paginaDefault = value;
            }
            get
            {
                return paginaDefault;
            }
        }
		public string NroSerieCertificado
		{
			set
			{
				nroSerieCertificado = value;
			}
			get
			{
				return nroSerieCertificado;
			}
		}
	}
}