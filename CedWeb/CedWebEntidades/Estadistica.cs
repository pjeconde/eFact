using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Estadistica
    {
        private string concepto;
        private int cantidad;
        private string uRL;

        public Estadistica()
        {
        }
        public string Concepto
        {
            get
            {
                return concepto;
            }
            set
            {
                concepto = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public string URL
        {
            get
            {
                return uRL;
            }
            set
            {
                uRL = value;
            }
        }
    }
}