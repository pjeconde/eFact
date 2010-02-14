using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_R.Entidades
{
    [Serializable]
    public class Archivo
    {
        private int idArchivo;
        private string nombre;
        private string tipo;
        private string path;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        private long tamaño;
        private string tamañoUMedida;
        private string comentario;
        private DateTime fechaAlta;
        private DateTime fechaProceso;
        private string nombreProcesado;
        private string idUsuario;
        private int idLote;
        public Archivo()
        {
        }
        public int IdArchivo
        {
            set
            {
                idArchivo = value;
            }
            get
            {
                return idArchivo;
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
        public string Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }
        public string Path
        {
            set
            {
                path = value;
            }
            get
            {
                return path;
            }
        }
        public DateTime FechaCreacion
        {
            set
            {
                fechaCreacion = value;
            }
            get
            {
                return fechaCreacion;
            }
        }
        public DateTime FechaModificacion
        {
            set
            {
                fechaModificacion = value;
            }
            get
            {
                return fechaModificacion;
            }
        }
        public long Tamaño
        {
            set
            {
                tamaño = value;
            }
            get
            {
                return tamaño;
            }
        }
        public string TamañoUMedida
        {
            set
            {
                tamañoUMedida = value;
            }
            get
            {
                return tamañoUMedida;
            }
        }
        public string Comentario
        {
            set
            {
                comentario = value;
            }
            get
            {
                return comentario;
            }
        }
        public string NombreProcesado
        {
            set
            {
                nombreProcesado = value;
            }
            get
            {
                return nombreProcesado;
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
        public DateTime FechaProceso
        {
            set
            {
                fechaProceso = value;
            }
            get
            {
                return fechaProceso;
            }
        }
        public string IdUsuario
        {
            set
            {
                idUsuario = value;
            }
            get
            {
                return idUsuario;
            }
        }
        public int IdLote
        {
            set
            {
                idLote = value;
            }
            get
            {
                return idLote;
            }
        }
    }
}

