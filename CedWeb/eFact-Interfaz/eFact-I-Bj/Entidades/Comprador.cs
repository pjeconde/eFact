using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.Entidades
{
    [Serializable]
    public class Comprador
    {
        private short tipoDoc;
        private string nroDoc;
        private string nombre;
        private string condicionIVA;
        private int condicionIB;
        private string nroIB;
        private DateTime inicioActividades;
        private string contacto;
        private string domicilioCalle;
        private string domicilioNumero;
        private string domicilioPiso;
        private string domicilioDepto;
        private string localidad;
        private int provincia;
        private string cp;
        private string eMail;
        private string telefono;
        public Comprador()
        {
        }
        public short TipoDoc
        {
            set
            {
                tipoDoc = value;
            }
            get
            {
                return tipoDoc;
            }
        }
        public string NroDoc
        {
            set
            {
                nroDoc = value;
            }
            get
            {
                return nroDoc;
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
        public string CondicionIVA
        {
            set
            {
                condicionIVA = value;
            }
            get
            {
                return condicionIVA;
            }
        }
        public int CondicionIB
        {
            set
            {
                condicionIB = value;
            }
            get
            {
                return condicionIB;
            }
        }
        public string NroIB
        {
            set
            {
                nroIB = value;
            }
            get
            {
                return nroIB;
            }
        }
        public DateTime InicioActividades
        {
            set
            {
                inicioActividades = value;
            }
            get
            {
                return inicioActividades;
            }
        }
        public string Contacto
        {
            set
            {
                contacto = value;
            }
            get
            {
                return contacto;
            }
        }
        public string DomicilioCalle
        {
            set
            {
                domicilioCalle = value;
            }
            get
            {
                return domicilioCalle;
            }
        }
        public string DomicilioNumero
        {
            set
            {
                domicilioNumero = value;
            }
            get
            {
                return domicilioNumero;
            }
        }
        public string DomicilioPiso
        {
            set
            {
                domicilioPiso = value;
            }
            get
            {
                return domicilioPiso;
            }
        }
        public string DomicilioDepto
        {
            set
            {
                domicilioDepto = value;
            }
            get
            {
                return domicilioDepto;
            }
        }
        public string Localidad
        {
            set
            {
                localidad = value;
            }
            get
            {
                return localidad;
            }
        }
        public int Provincia
        {
            set
            {
                provincia = value;
            }
            get
            {
                return provincia;
            }
        }
        public string CP
        {
            set
            {
                cp = value;
            }
            get
            {
                return cp;
            }
        }
        public string EMail
        {
            set
            {
                eMail = value;
            }
            get
            {
                return eMail;
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
    }

}
