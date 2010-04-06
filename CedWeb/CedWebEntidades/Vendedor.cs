using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Vendedor : Persona
    {
        private long cUIT;
        private List<PuntoDeVenta> puntosDeVenta;
        public Vendedor()
        {
            puntosDeVenta = new List<PuntoDeVenta>();
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
        public List<PuntoDeVenta> PuntosDeVenta
        {
            get
            {
                return puntosDeVenta;
            }
            set
            {
                puntosDeVenta = value;
            }
        }
        public List<int> PuntosDeVentaHabilitados(TiposPuntoDeVenta.TipoPuntoDeVenta TipoPuntoDeVenta)
        {
            List<int> bonofiscalPuntosDeVentaHabilitados = new List<int>();
            for (int i=0; i<puntosDeVenta.Count; i++)
            {
                if (puntosDeVenta[i].Tipo.Id==TipoPuntoDeVenta.Id)
                {
                    bonofiscalPuntosDeVentaHabilitados.Add(puntosDeVenta[i].Id);
                }
            }
            return bonofiscalPuntosDeVentaHabilitados;
        }
    }
}