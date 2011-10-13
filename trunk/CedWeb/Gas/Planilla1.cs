using System;
using System.Collections.Generic;
using System.Text;

namespace Gas
{
    [FileHelpers.DelimitedRecord("|")] 
    public class Planilla1
    {
        public DateTime Fecha; 

        public string megid_contrato_gas;

        public string megid_tipo_balance;

        public string megid_punto_medicion; 
	 
        public string volumen; 
    }
}
