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

        public Cuenta()
        {
            tipoCuenta = new TipoCuenta();
            estadoCuenta = new EstadoCuenta();
            vendedor = new Vendedor();
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
    }
}