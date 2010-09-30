using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_C.Entidades
{
    public class LoteConsulta
    {
        private long cuitCanal;
        private long cuitVendedor;
        private int puntoVenta;
        private long numero;
        /// <comentarios.../>
        public long CuitCanal
        {
            get
            {
                return cuitCanal;
            }
            set
            {
                cuitCanal = value;
            }
        }
        public long CuitVendedor
        {
            get
            {
                return cuitVendedor;
            }
            set
            {
                cuitVendedor = value;
            }
        }
        public int PuntoVenta
        {
            get
            {
                return puntoVenta;
            }
            set
            {
                puntoVenta = value;
            }
        }
        public long Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }
    }
}
