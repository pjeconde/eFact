using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    [Serializable]
    public class ComprobanteC
    {
        private int idLote;
        private string loteXml;
        private string puntoVenta;
        private short idTipoComprobante;
        private string numeroComprobante;
        private short tipoDocVendedor;
        private string nroDocVendedor;
        private string nombreVendedor;
        private DateTime fecha;
        private string idMoneda;
        private decimal importe;
        private decimal importeMonedaOrigen;
        private decimal tipoCambio;
        public ComprobanteC()
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
        public string LoteXml
        {
            set
            {
                loteXml = value;
            }
            get
            {
                return loteXml;
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
        public short TipoDocVendedor
        {
            set
            {
                tipoDocVendedor = value;
            }
            get
            {
                return tipoDocVendedor;
            }
        }
        public string NroDocVendedor
        {
            set
            {
                nroDocVendedor = value;
            }
            get
            {
                return nroDocVendedor;
            }
        }
        public string NombreVendedor
        {
            set
            {
                nombreVendedor = value;
            }
            get
            {
                return nombreVendedor;
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
    }
}
