using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[FileHelpers.DelimitedRecord("|")]
	public partial class comprobanteDespacho
	{
        private despachoCabecera despachoCabeceraField;

        private despachoImpuesto[] despachoImpuestoField = new despachoImpuesto[50];

        private despachoResumen despachoResumenField;

        /// <comentarios/>
        public despachoCabecera DespachoCabecera
		{
			get
			{
                return this.despachoCabeceraField;
			}
			set
			{
                this.despachoCabeceraField = value;
			}
		}

        /// <comentarios/>
        public despachoImpuesto[] DespachoImpuesto
		{
			get
			{
                return this.despachoImpuestoField;
			}
			set
			{
                this.despachoImpuestoField = value;
			}
		}

        /// <comentarios/>
        public despachoResumen DespachoResumen
        {
            get
            {
                return this.despachoResumenField;
            }
            set
            {
                this.despachoResumenField = value;
            }
        }

    }
}
