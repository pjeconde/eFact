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
	[FileHelpers.DelimitedRecord("|")]
	public partial class despachoImpuesto
	{
        private string nombre_claseField = "<despachoImpuesto>";

		private double importeNetoGravadoField;

		private double alicIVAField;

		private double importeImpuestoLiqField;

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
        public double ImporteNetoGravado
		{
			get
			{
                return this.importeNetoGravadoField;
			}
			set
			{
                this.importeNetoGravadoField = value;
			}
		}


		/// <comentarios/>
		public double AlicIVA
		{
			get
			{
				return this.alicIVAField;
			}
			set
			{
				this.alicIVAField = value;
			}
		}

		/// <comentarios/>
		public double ImporteImpuestoLiq
		{
			get
			{
				return this.importeImpuestoLiqField;
			}
			set
			{
				this.importeImpuestoLiqField = value;
			}
		}
	}
}
