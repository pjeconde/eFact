using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.Entidades
{
    [Serializable]
    public class ComprobanteBjLinea
    {
        private int clave;
        private int renglon;
        private string descripcion;
        private decimal cantidad; 
        private decimal precio_unitario; 
        private decimal alicuota_iva;
        private decimal importe_iva;
        private string indicacion_exento_gravado;
        private decimal importe_total_descuentos;
        private decimal importe_total_impuestos;
        private decimal importe_total_articulo; 
        public int Clave
        {
            set
            {
                clave = value;
            }
            get
            {
                return clave;
            }
        }
        public int Renglon
        {
            set
            {
                renglon = value;
            }
            get
            {
                return renglon;
            }
        }
        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get
            {
                return descripcion;
            }
        }
        public decimal Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }
        public decimal Precio_unitario
        {
            set
            {
                precio_unitario = value;
            }
            get
            {
                return precio_unitario;
            }
        }
        public decimal Alicuota_iva
        {
            set
            {
                alicuota_iva = value;
            }
            get
            {
                return alicuota_iva;
            }
        }
        public decimal Importe_iva
        {
            set
            {
                importe_iva = value;
            }
            get
            {
                return importe_iva;
            }
        }
        public string Indicacion_exento_gravado
        {
            set
            {
                indicacion_exento_gravado = value;
            }
            get
            {
                return indicacion_exento_gravado;
            }
        }
        public decimal Importe_total_descuentos
        {
            set
            {
                importe_total_descuentos = value;
            }
            get
            {
                return importe_total_descuentos;
            }
        }
        public decimal Importe_total_impuestos
        {
            set
            {
                importe_total_impuestos = value;
            }
            get
            {
                return importe_total_impuestos;
            }
        }
        public decimal Importe_total_articulo
        {
            set
            {
                importe_total_articulo = value;
            }
            get
            {
                return importe_total_articulo;
            }
        }
    }
}
