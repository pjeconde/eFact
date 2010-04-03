using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public abstract class Persona
    {
        private string idCuenta;
        private string nombreCuenta;
        private string razonSocial;
        private Domicilio domicilio;
        private string nombreContacto;
        private string emailContacto;
        private string telefonoContacto;
        private int idCondIVA;
        private string descrCondIVA;
        private string nroIngBrutos;
        private int idCondIngBrutos;
        private string descrCondIngBrutos;
        private long gLN;
        private string codigoInterno;
        private DateTime fechaInicioActividades;

        public Persona()
        {
        }

        public string IdCuenta
        {
            set
            {
                idCuenta = value;
            }
            get
            {
                return idCuenta;
            }
        }
        public string NombreCuenta
        {
            set
            {
                nombreCuenta = value;
            }
            get
            {
                return nombreCuenta;
            }
        }
        public string RazonSocial
        {
            set
            {
                razonSocial = value;
            }
            get
            {
                return razonSocial;
            }
        }
        public Domicilio Domicilio
        {
            set
            {
                domicilio = value;
            }
            get
            {
                return domicilio;
            }
        }
        public string NombreContacto
        {
            set
            {
                nombreContacto = value;
            }
            get
            {
                return nombreContacto;
            }
        }
        public string EmailContacto
        {
            set
            {
                emailContacto = value;
            }
            get
            {
                return emailContacto;
            }
        }
        public string TelefonoContacto
        {
            set
            {
                telefonoContacto = value;
            }
            get
            {
                return telefonoContacto;
            }
        }
        public int IdCondIVA
        {
            set
            {
                idCondIVA = value;
            }
            get
            {
                return idCondIVA;
            }
        }
        public string DescrCondIVA
        {
            set
            {
                descrCondIVA = value;
            }
            get
            {
                return descrCondIVA;
            }
        }
        public string NroIngBrutos
        {
            set
            {
                nroIngBrutos = value;
            }
            get
            {
                return nroIngBrutos;
            }
        }
        public int IdCondIngBrutos
        {
            set
            {
                idCondIngBrutos = value;
            }
            get
            {
                return idCondIngBrutos;
            }
        }
        public string DescrCondIngBrutos
        {
            set
            {
                descrCondIngBrutos = value;
            }
            get
            {
                return descrCondIngBrutos;
            }
        }
        public long GLN
        {
            set
            {
                gLN = value;
            }
            get
            {
                return gLN;
            }
        }
        public string CodigoInterno
        {
            set
            {
                codigoInterno = value;
            }
            get
            {
                return codigoInterno;
            }
        }
        public DateTime FechaInicioActividades
        {
            set
            {
                fechaInicioActividades = value;
            }
            get
            {
                return fechaInicioActividades;
            }
        }
    }
}
