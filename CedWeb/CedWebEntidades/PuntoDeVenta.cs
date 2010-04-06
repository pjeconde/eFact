using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class PuntoDeVenta
    {
        private int id;
        private TiposPuntoDeVenta.TipoPuntoDeVenta tipo;
        private Domicilio domicilio;

        public PuntoDeVenta()
        {
            tipo = new TiposPuntoDeVenta.TipoPuntoDeVenta();
            domicilio = new Domicilio();
        }
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public TiposPuntoDeVenta.TipoPuntoDeVenta Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }
        public string IdTipo
        {
            set
            {
                tipo.Id = value;
            }
            get
            {
                return tipo.Id;
            }
        }
        public string DescrTipo
        {
            set
            {
                tipo.Descr = value;
            }
            get
            {
                return tipo.Descr;
            }
        }
        public Domicilio Domicilio
        {
            set
            {
                domicilio = value;
            }
            get
            {
                return domicilio;
            }
        }
    }
}