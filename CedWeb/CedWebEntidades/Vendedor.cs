using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Vendedor : Persona
    {
        private long cUIT;
        private BonoFiscal bonoFiscal;
        public Vendedor()
        {
            bonoFiscal = new BonoFiscal();
        }
        public long CUIT
        {
            set
            {
                cUIT = value;
            }
            get
            {
                return cUIT;
            }
        }
        public BonoFiscal BonoFiscal
        {
            set
            {
                bonoFiscal = value;
            }
            get
            {
                return bonoFiscal;
            }
        }
    }
    [Serializable]
    public class BonoFiscal
    {
        private List<int> puntoDeVentaHabilitado;
        public BonoFiscal()
        {
            puntoDeVentaHabilitado = new List<int>();
        }
        public List<int> PuntoDeVentaHabilitado
        {
            set
            {
                puntoDeVentaHabilitado = value;
            }
            get
            {
                return puntoDeVentaHabilitado;
            }
        }
    }
}