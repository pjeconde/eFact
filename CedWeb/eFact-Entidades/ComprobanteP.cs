using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    [Serializable]
    public class ComprobanteP
    {
        private short idTipoComprobante;
        private string numeroComprobante;
        private short tipoDocComprador;
        private string nroDocComprador;
        private string nombreComprador;
        private DateTime fecha;
        private DateTime fechaVto;
        private string idMoneda;
        private decimal importe;
        private decimal importeMonedaOrigen;
        private decimal tipoCambio;
        private string numeroCAE;
        private DateTime fechaCAE;
        private DateTime fechaVtoCAE;
        private string estadoIFoAFIP;
        private string comentarioIFoAFIP;
        private string loteXmlIF;
        public ComprobanteP()
        {
        }
        public short IdTipoComprobante
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
        public short TipoDocComprador
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
        public DateTime FechaVto
        {
            set
            {
                fechaVto = value;
            }
            get
            {
                return fechaVto;
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
        public decimal ImporteMonedaOrigen
        {
            set
            {
                importeMonedaOrigen = value;
            }
            get
            {
                return importeMonedaOrigen;
            }
        }
        public decimal TipoCambio
        {
            set
            {
                tipoCambio = value;
            }
            get
            {
                return tipoCambio;
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
        public string EstadoIFoAFIP
        {
            set
            {
                estadoIFoAFIP = value;
            }
            get
            {
                return estadoIFoAFIP;
            }
        }
        public string ComentarioIFoAFIP
        {
            set
            {
                comentarioIFoAFIP = value;
            }
            get
            {
                return comentarioIFoAFIP;
            }
        }
        public string LoteXmlIF
        {
            set
            {
                loteXmlIF = value;
            }
            get
            {
                return loteXmlIF;
            }
        }
    }
}
