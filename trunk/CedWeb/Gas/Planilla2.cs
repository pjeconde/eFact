using System;
using System.Collections.Generic;
using System.Text;

namespace Gas
{
    [FileHelpers.DelimitedRecord("|")] 
    public class Planilla2
    {
        public DateTime fecha_desde;

        public DateTime fecha_hasta;

        public string megid_contrato_gas;

        public string megid_moneda;

        public string concepto_facturacion; 
	 
        public string volumen;

        public string monto;
    }
}
