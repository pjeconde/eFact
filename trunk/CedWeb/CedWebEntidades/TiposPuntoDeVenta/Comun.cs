using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades.TiposPuntoDeVenta
{
    [Serializable]
    public class Comun : TipoPuntoDeVenta
    {
        public Comun()
        {
            Id = "Comun";
            Descr = "Comun";
        }
    }
}