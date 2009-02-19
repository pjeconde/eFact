using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Contacto
    {
        private string motivo;
        private string nombre;
        private string telefono;
        private string email;
        private string mensaje;
        public Contacto()
        {
        }
        public string Motivo
        {
            set
            {
                motivo = value;
            }
            get
            {
                return motivo;
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
        public string Mensaje
        {
            set
            {
                mensaje = value;
            }
            get
            {
                return mensaje;
            }
        }
    }
}
