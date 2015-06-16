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
        private string nombre_claseField = "<despacho>";

        private string nrodespachoField;

        private int nrodocField;

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
        public string nrodespacho
		{
			get
			{
                return this.nrodespachoField;
			}
			set
			{
                this.nrodespachoField = value;
			}
		}

        /// <comentarios/>
        public int nrodoc
		{
			get
			{
                return this.nrodocField;
			}
			set
			{
                this.nrodocField = value;
			}
		}

    }
}
