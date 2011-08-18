using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.Entidades
{
    [Serializable]
    public class ComprobanteBj
    {
        private int clave;
        private eFact_R.Entidades.Vendedor vendedor;
        private eFact_I_Bj.Entidades.Comprador comprador;
        private string idTipoComprobante;
        private int puntoVenta;
        private string numeroComprobante;
        private DateTime fecha;
        private DateTime fechaVto;
        private string idMoneda;
        private decimal importe;
        private decimal importeNetoGravado;
        private decimal importeNetoNoGravado;
        private decimal importeOpsExentas;
        private decimal impuestoLiq;
        private decimal impuestoRNI;
        private decimal impuestosNacionales;
        //private decimal importeTotIB;
        //private decimal impuestosMunicipales;
        //private decimal impuestosInternos;
        //private decimal tipoCambio;
        //private decimal observaciones;
        private int cantAlicuotasIVA;
        private string numeroCAE;
        private DateTime fechaCAE;
        private DateTime fechaVtoCAE;
        private List<eFact_I_Bj.Entidades.ComprobanteBjLinea> lineas;
        private string idEstado;
        private List<string> leyendas;
        private double tipoDeCambio;
        public ComprobanteBj()
        {
            vendedor = new eFact_R.Entidades.Vendedor();
            comprador = new eFact_I_Bj.Entidades.Comprador();
            lineas = new List<ComprobanteBjLinea>();
        }
        public int Clave
        {
            set
            {
                clave = value;
            }
            get
            {
                return clave;
            }
        }
        public string VendedorCuit
        {
            get
            {
                return vendedor.CuitVendedor;
            }
        }
        public short CompradorTipoDoc
        {
            get
            {
                return comprador.TipoDoc;
            }
        }
        public string CompradorNroDoc
        {
            get
            {
                return comprador.NroDoc;
            }
        }
        public string CompradorNombre
        {
            get
            {
                return comprador.Nombre;
            }
        }
        public string CompradorDomicilioCalle
        {
            get
            {
                return comprador.DomicilioCalle;
            }
        }
        public string CompradorLocalidad
        {
            get
            {
                return comprador.Localidad;
            }
        }
        public string CompradorCP
        {
            get
            {
                return comprador.CP;
            }
        }
        public string CompradorTelefono
        {
            get
            {
                return comprador.Telefono;
            }
        }
        public string CompradorEMail
        {
            get
            {
                return comprador.EMail;
            }
        }
        public string IdTipoComprobante
        {
			set
			{
                idTipoComprobante = value;
			}
            get
            {
                return idTipoComprobante;
            }
        }
        public int PuntoVenta
        {
            set
            {
                puntoVenta = value;
            }
            get
            {
                return puntoVenta;
            }
        }
        public string NumeroComprobante
        {
			set
			{
                numeroComprobante = value;
			}
            get
            {
                return numeroComprobante;
            }
        }
        public DateTime Fecha
        {
			set
			{
				fecha = value;
			}
            get
            {
                return fecha;
            }
        }
        public DateTime FechaVto
        {
            set
            {
                fechaVto = value;
            }
            get
            {
                return fechaVto;
            }
        }
        public string IdMoneda
        {
            set
            {
                idMoneda = value;
            }
            get
            {
                return idMoneda;
            }
        }
        public decimal Importe
        {
            set
            {
                importe = value;
            }
            get
            {
                return importe;
            }
        }
        public string NumeroCAE
        {
            set
            {
                numeroCAE = value;
            }
            get
            {
                return numeroCAE;
            }
        }
        public DateTime FechaCAE
        {
            set
            {
                fechaCAE = value;
            }
            get
            {
                return fechaCAE;
            }
        }
        public DateTime FechaVtoCAE
        {
            set
            {
                fechaVtoCAE = value;
            }
            get
            {
                return fechaVtoCAE;
            }
        }
        public string FechaVtoCAEsinHora
        {
            get
            {
                return fechaVtoCAE.ToString("dd/MM/yyyy");
            }
        }
        public decimal ImpuestoLiq
        {
            set
            {
                impuestoLiq = value;
            }
            get
            {
                return impuestoLiq;
            }
        }
        public decimal ImpuestoRNI
        {
            set
            {
                impuestoRNI = value;
            }
            get
            {
                return impuestoRNI;
            }
        }
        public decimal ImpuestosNacionales
        {
            set
            {
                impuestosNacionales = value;
            }
            get
            {
                return impuestosNacionales;
            }
        }
        public decimal ImporteNetoGravado
        {
            set
            {
                importeNetoGravado = value;
            }
            get
            {
                return importeNetoGravado;
            }
        }
        public decimal ImporteNetoNoGravado
        {
            set
            {
                importeNetoNoGravado = value;
            }
            get
            {
                return importeNetoNoGravado;
            }
        }
        public decimal ImporteOpsExentas
        {
            set
            {
                importeOpsExentas = value;
            }
            get
            {
                return importeOpsExentas;
            }
        }
        public int CantAlicuotasIVA
        {
            set
            {
                cantAlicuotasIVA = value;
            }
            get
            {
                return cantAlicuotasIVA;
            }
        }
        public List<eFact_I_Bj.Entidades.ComprobanteBjLinea> Lineas
        {
            set
            {
                lineas = value;
            }
            get
            {
                return lineas;
            }
        }
        public eFact_R.Entidades.Vendedor Vendedor
        {
            set
            {
                vendedor = value;
            }
            get
            {
                return vendedor;
            }
        }
        public eFact_I_Bj.Entidades.Comprador Comprador
        {
            set
            {
                comprador = value;
            }
            get
            {
                return comprador;
            }
        }
        public string IdEstado
        {
            set
            {
                idEstado = value;
            }
            get
            {
                return idEstado;
            }
        }
        public List<string> Leyendas
        {
            set
            {
                leyendas = value;
            }
            get
            {
                return leyendas;
            }
        }
        public double TipoDeCambio
        {
            set
            {
                tipoDeCambio = value;
            }
            get
            {
                return tipoDeCambio;
            }
        }
    }
}
