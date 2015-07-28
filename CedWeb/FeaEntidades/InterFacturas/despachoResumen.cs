using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
	/// <comentarios/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
	[FileHelpers.DelimitedRecord("|")]
	public partial class despachoResumen
	{
        private string nombre_claseField = "<despachoResumen>";
		
        private double importeTotalField;
        
        private double importeNetoNoGravadoField;

		private double importeExentoField;

		private double importePercepOPagoCtaIVAField;

		private double importePercepOPagoCtaOtrosImpNacField;

		private double importePercepIBField;

        private double importePercepImpMunicipalesField;

        private double importePercepImpInternosField;

        private double importeOtrosImpuestosField;

        private string monedaField;

        private double tipoCambioField;

        private int cantAlicIVAField;

        private string codigoOperacionField;

		private double creditoFiscalComputableField;


        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string nombre_clase
        {
            get
            {
                return nombre_claseField;
            }
        }

		/// <comentarios/>
        public double ImporteTotal
		{
			get
			{
                return this.importeTotalField;
			}
			set
			{
                this.importeTotalField = value;
			}
		}

		/// <comentarios/>
        public double ImporteNetoNoGravado
		{
			get
			{
                return this.importeNetoNoGravadoField;
			}
			set
			{
                this.importeNetoNoGravadoField = value;
			}
		}

		/// <comentarios/>
        public double ImporteExento
		{
			get
			{
                return this.importeExentoField;
			}
			set
			{
                this.importeExentoField = value;
			}
		}

		/// <comentarios/>
        public double ImportePercepOPagoCtaIVA
		{
			get
			{
                return this.importePercepOPagoCtaIVAField;
			}
			set
			{
                this.importePercepOPagoCtaIVAField = value;
			}
		}

		/// <comentarios/>
        public double ImportePercepOPagoCtaOtrosImpNac
		{
			get
			{
                return this.importePercepOPagoCtaOtrosImpNacField;
			}
			set
			{
                this.importePercepOPagoCtaOtrosImpNacField = value;
			}
		}

		/// <comentarios/>
        public double ImportePercepIB
		{
			get
			{
                return this.importePercepIBField;
			}
			set
			{
                this.importePercepIBField = value;
			}
		}

		/// <comentarios/>
        public double ImportePercepImpMunicipales
		{
			get
			{
                return this.importePercepImpMunicipalesField;
			}
			set
			{
                this.importePercepImpMunicipalesField = value;
			}
		}

		/// <comentarios/>
        public double ImportePercepImpInternos
		{
			get
			{
                return this.importePercepImpInternosField;
			}
			set
			{
                this.importePercepImpInternosField = value;
			}
		}

		/// <comentarios/>
        public double ImporteOtrosImpuestos
		{
			get
			{
                return this.importeOtrosImpuestosField;
			}
			set
			{
                this.importeOtrosImpuestosField = value;
			}
		}

		/// <comentarios/>
        public string Moneda
		{
			get
			{
                return this.monedaField;
			}
			set
			{
                this.monedaField = value;
			}
		}

		/// <comentarios/>
        public double TipoCambio
		{
			get
			{
                return this.tipoCambioField;
			}
			set
			{
                this.tipoCambioField = value;
			}
		}

		/// <comentarios/>
        public int CantAlicIVA
		{
			get
			{
                return this.cantAlicIVAField;
			}
			set
			{
                this.cantAlicIVAField = value;
			}
		}

		/// <comentarios/>
        public string CodigoOperacion
		{
			get
			{
                return this.codigoOperacionField;
			}
			set
			{
                this.codigoOperacionField = value;
			}
		}

        /// <comentarios/>
        public double CreditoFiscalComputable
        {
            get
            {
                return this.creditoFiscalComputableField;
            }
            set
            {
                this.creditoFiscalComputableField = value;
            }
        }
	}
}
