using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    [Serializable]
    public class Vendedor
    {
        private string cuitVendedor;
        private string nombre;
        private string numeroSerieCertificado;
        private byte[] logo;
        private string codigo;
        private int condicionIVA;
        private int condicionIB;
        private string nroIB;
        private DateTime inicioActividades;
        private string contacto;
        private string domicilioCalle;
        private string domicilioNumero;
        private string domicilioPiso;
        private string domicilioDepto;
        private string domicilioSector;
        private string domicilioTorre;
        private string domicilioManzana;
        private string localidad;
        private string provincia;
        private string cp;
        private string eMail;
        private string telefono;
        public Vendedor()
        {
        }
        public string CuitVendedor
        {
            set
            {
                cuitVendedor = value;
            }
            get
            {
                return cuitVendedor;
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
        public string NumeroSerieCertificado
        {
            set
            {
                numeroSerieCertificado = value;
            }
            get
            {
                return numeroSerieCertificado;
            }
        }
        public byte[] Logo
        {
            set
            {
                logo = value;
            }
            get
            {
                return logo;
            }
        }
        public string Codigo
        {
            set
            {
                codigo = value;
            }
            get
            {
                return codigo;
            }
        }
        public int CondicionIVA
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
        public string DomicilioSector
        {
            set
            {
                domicilioSector = value;
            }
            get
            {
                return domicilioSector;
            }
        }
        public string DomicilioTorre
        {
            set
            {
                domicilioTorre = value;
            }
            get
            {
                return domicilioTorre;
            }
        }
        public string DomicilioManzana
        {
            set
            {
                domicilioManzana = value;
            }
            get
            {
                return domicilioManzana;
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
        public string Provincia
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

