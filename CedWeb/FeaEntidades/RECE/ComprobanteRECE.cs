using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;
using FileHelpers.RunTime; 

namespace FeaEntidades.RECE
{
    [FixedLengthRecord()] 
	public class ComprobanteRECE 
    {
        [FieldFixedLength(1)] 
	    public string TipoRegistro; 
	 
	    [FieldFixedLength(8)] 
	    public string FechaComprobante; 
	 
	    [FieldFixedLength(2)] 
	    public string TipoComprobante; 

        [FieldFixedLength(1)] 
	    public string ControladorFiscal; 

        [FieldFixedLength(4)] 
	    public string PuntoVenta; 

        [FieldFixedLength(8)] 
	    public string NroComprobanteDsd;
 
        [FieldFixedLength(8)] 
	    public string NroComprobanteHst; 

        [FieldFixedLength(3)] 
	    public string CantidadHojas; 
        
        [FieldFixedLength(2)] 
	    public string CodDocComprador; 

        [FieldFixedLength(11)] 
	    public string NroDocComprador; 
        
        [FieldFixedLength(30)] 
	    public string ApellidoNombreComprador; 
        
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

        [FieldFixedLength(8)] 
	    public string FechaServicioDsd;

        [FieldFixedLength(8)] 
	    public string FechaServicioHst;

        [FieldFixedLength(8)] 
	    public string FechaVtoPago;

        [FieldFixedLength(6)] 
	    public string Relleno;

        [FieldFixedLength(1)] 
	    public string CantidadAlicIVA;

        [FieldFixedLength(1)] 
	    public string CodOpe;

        [FieldFixedLength(14)] 
	    public string CAE;

        [FieldFixedLength(8)] 
	    public string FechaVtoCAE;

        [FieldFixedLength(8)] 
	    public string FechaAnulComprobante;
	}
}
