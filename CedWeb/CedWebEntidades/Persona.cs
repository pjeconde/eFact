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
            domicilio = new Domicilio();
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
        #region Detalle Domicilio
        public string Calle
        {
            set
            {
                domicilio.Calle = value;
            }
            get
            {
                return domicilio.Calle;
            }
        }
        public string Nro
        {
            set
            {
                domicilio.Nro = value;
            }
            get
            {
                return domicilio.Nro;
            }
        }
        public string Piso
        {
            set
            {
                domicilio.Piso = value;
            }
            get
            {
                return domicilio.Piso;
            }
        }
        public string Depto
        {
            set
            {
                domicilio.Depto = value;
            }
            get
            {
                return domicilio.Depto;
            }
        }
        public string Sector
        {
            set
            {
                domicilio.Sector = value;
            }
            get
            {
                return domicilio.Sector;
            }
        }
        public string Torre
        {
            set
            {
                domicilio.Torre = value;
            }
            get
            {
                return domicilio.Torre;
            }
        }
        public string Manzana
        {
            set
            {
                domicilio.Manzana = value;
            }
            get
            {
                return domicilio.Manzana;
            }
        }
        public string Localidad
        {
            set
            {
                domicilio.Localidad = value;
            }
            get
            {
                return domicilio.Localidad;
            }
        }
        public string IdProvincia
        {
            set
            {
                domicilio.IdProvincia = value;
            }
            get
            {
                return domicilio.IdProvincia;
            }
        }
        public string DescrProvincia
        {
            set
            {
                domicilio.DescrProvincia = value;
            }
            get
            {
                return domicilio.DescrProvincia;
            }
        }
        public string CodPost
        {
            set
            {
                domicilio.CodPost = value;
            }
            get
            {
                return domicilio.CodPost;
            }
        }
        #endregion
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
