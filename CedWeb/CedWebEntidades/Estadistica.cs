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
        private double porcentaje;
        private string uRL;
		private int certificado;
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
        public double Porcentaje
        {
            get
            {
                return porcentaje;
            }
            set
            {
                porcentaje = value;
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
		public int Certificado
		{
			get
			{
				return certificado;
			}
			set
			{
				certificado = value;
			}
		}
	}
}