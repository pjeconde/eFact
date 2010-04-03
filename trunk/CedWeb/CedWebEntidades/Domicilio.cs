using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public abstract class Domicilio
    {
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

        public Domicilio()
        {
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
    }
}
