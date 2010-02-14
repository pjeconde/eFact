using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_R.Entidades
{
    [Serializable]
    public class Comprobante
    {
        private int idLote;
        private string idTipoComprobante;
        private string numeroComprobante;
        private string tipoDocComprador;
        private string nroDocComprador;
        private string nombreComprador;
        private DateTime fecha;
        private string idMoneda;
        private decimal importe;
        private string numeroCAE;
        private DateTime fechaCAE;
        private DateTime fechaVtoCAE;
        public Comprobante()
        {
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
        public string IdTipoComprobante
        {
			set
			{
                idTipoComprobante = value;
			}
            get
            {
                return idTipoComprobante;
            }
        }
        public string NumeroComprobante
        {
			set
			{
                numeroComprobante = value;
			}
            get
            {
                return numeroComprobante;
            }
        }
        public DateTime Fecha
        {
			set
			{
				fecha = value;
			}
            get
            {
                return fecha;
            }
        }
        public string TipoDocComprador
        {
            set
            {
                tipoDocComprador = value;
            }
            get
            {
                return tipoDocComprador;
            }
        }
        public string NroDocComprador
        {
            set
            {
                nroDocComprador = value;
            }
            get
            {
                return nroDocComprador;
            }
        }
        public string NombreComprador
        {
            set
            {
                nombreComprador = value;
            }
            get
            {
                return nombreComprador;
            }
        }
        public string IdMoneda
        {
            set
            {
                idMoneda = value;
            }
            get
            {
                return idMoneda;
            }
        }
        public decimal Importe
        {
            set
            {
                importe = value;
            }
            get
            {
                return importe;
            }
        }
        public string NumeroCAE
        {
            set
            {
                numeroCAE = value;
            }
            get
            {
                return numeroCAE;
            }
        }
        public DateTime FechaCAE
        {
            set
            {
                fechaCAE = value;
            }
            get
            {
                return fechaCAE;
            }
        }
        public DateTime FechaVtoCAE
        {
            set
            {
                fechaVtoCAE = value;
            }
            get
            {
                return fechaVtoCAE;
            }
        }
    }
}
