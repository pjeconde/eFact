using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;
using FileHelpers.RunTime; 

namespace FeaEntidades.RECE
{
    [FixedLengthRecord()] 
	public class ComprobanteRECEctrl
    {
        [FieldFixedLength(1)] 
	    public string TipoRegistro; 
	 
	    [FieldFixedLength(6)] 
	    public string Periodo; 
	 
	    [FieldFixedLength(13)] 
	    public string Relleno; 

        [FieldFixedLength(8)] 
	    public string CantidadRegTipo1; 

        [FieldFixedLength(17)] 
	    public string Relleno2; 

        [FieldFixedLength(11)] 
	    public string CuitInformante;
 
        [FieldFixedLength(22)] 
	    public string Relleno3; 

        [FieldFixedLength(15)] 
	    public string ImporteTotalOpe;

        [FieldFixedLength(15)] 
	    public string ImporteNoGravado;

        [FieldFixedLength(15)] 
	    public string ImporteNetoGravado;

        [FieldFixedLength(15)] 
	    public string ImporteLiq;

        [FieldFixedLength(15)] 
	    public string ImporteLiqRNI;

        [FieldFixedLength(15)] 
	    public string ImporteOpeExentas;

        [FieldFixedLength(15)] 
	    public string ImportePercepOImpNacionales;

        [FieldFixedLength(15)] 
	    public string ImportePercepIB;

        [FieldFixedLength(15)] 
	    public string ImportePercepImpMunicipales;

        [FieldFixedLength(15)] 
	    public string ImporteImpInternos;

        [FieldFixedLength(62)] 
	    public string Relleno4;
	}
}
