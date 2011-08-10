using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    public class Novedades
    {
        private string cuitVendedor;
        private int idLote;
        private int numeroEnvio;
        private string puntoVenta;
        private int idLog;
        private int idOp;
        private string numeroLote;
        private string idEstado;
        private string comentario;
        private DateTime fechaAlta;
        private int cantidadRegistros;
        public Novedades()
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
        public int NumeroEnvio
        {
            set
            {
                numeroEnvio = value;
            }
            get
            {
                return numeroEnvio;
            }
        }
        public string PuntoVenta
        {
            set
            {
                puntoVenta = value;
            }
            get
            {
                return puntoVenta;
            }
        }
         public int IdLog
        {
            set
            {
                idLog = value;
            }
            get
            {
                return idLog;
            }
        }
        public int IdOp
        {
            set
            {
                idOp = value;
            }
            get
            {
                return idOp;
            }
        }
        public string NumeroLote
        {
            set
            {
                numeroLote = value;
            }
            get
            {
                return numeroLote;
            }
        }
        public string IdEstado
        {
            set
            {
                idEstado = value;
            }
            get
            {
                return idEstado;
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
        public int CantidadRegistros
        {
            set
            {
                cantidadRegistros = value;
            }
            get
            {
                return cantidadRegistros;
            }
        }
    }
}
