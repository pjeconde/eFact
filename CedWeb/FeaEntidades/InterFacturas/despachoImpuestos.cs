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
    public partial class despachoImpuestos
    {
        private string nombre_claseField = "<despachoImpuestos>";

        [FileHelpers.FieldIgnored()]
        private despachoImpuesto[] despachoImpuestoField = new despachoImpuesto[100];

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
        [System.Xml.Serialization.XmlElementAttribute("despachoImpuesto")]
        public despachoImpuesto[] despachoImpuesto
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
    }
}

