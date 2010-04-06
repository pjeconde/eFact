using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades.TiposPuntoDeVenta
{
    [Serializable]
    public class Exportacion : TipoPuntoDeVenta
    {
        public Exportacion()
        {
            Id = "Export";
            Descr = "Exportacion";
        }
    }
}