using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Vendedor
    {
        private string idCuenta;
        private string nombreCuenta;
        private string razonSocial;
        private string calle;
        private string nro;
        private string piso;
        private string depto;
        private string sector;
        private string torre;
        private string manzana;
        private string localidad;
        private string idProvincia;
        private string descrProvincia;
        private string codPost;
        private string nombreContacto;
        private string emailContacto;
        private string telefonoContacto;
        private long cUIT;
        private int idCondIVA;
        private string descrCondIVA;
        private string nroIngBrutos;
        private int idCondIngBrutos;
        private string descrCondIngBrutos;
        private long gLN;
        private string codigoInterno;
        private DateTime fechaInicioActividades;

        public Vendedor()
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
        public string Calle
        {
            set
            {
                calle = value;
            }
            get
            {
                return calle;
            }
        }
        public string Nro
        {
            set
            {
                nro = value;
            }
            get
            {
                return nro;
            }
        }
        public string Piso
        {
            set
            {
                piso = value;
            }
            get
            {
                return piso;
            }
        }
        public string Depto
        {
            set
            {
                depto = value;
            }
            get
            {
                return depto;
            }
        }
        public string Sector
        {
            set
            {
                sector = value;
            }
            get
            {
                return sector;
            }
        }
        public string Torre
        {
            set
            {
                torre = value;
            }
            get
            {
                return torre;
            }
        }
        public string Manzana
        {
            set
            {
                manzana = value;
            }
            get
            {
                return manzana;
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
        public string IdProvincia
        {
            set
            {
                idProvincia = value;
            }
            get
            {
                return idProvincia;
            }
        }
        public string DescrProvincia
        {
            set
            {
                descrProvincia = value;
            }
            get
            {
                return descrProvincia;
            }
        }
        public string CodPost
        {
            set
            {
                codPost = value;
            }
            get
            {
                return codPost;
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
        public long CUIT
        {
            set
            {
                cUIT = value;
            }
            get
            {
                return cUIT;
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