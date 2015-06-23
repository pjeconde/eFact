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
	public partial class despachoCabecera
	{
        private string nombre_claseField = "<despachoCabecera>";

	    private string fechaField;
        
        private int tipoComprobanteField;
	    
        private string numeroDespachoField;

        [FileHelpers.FieldNullValue(typeof(System.Int32), "0")]
        private int tipoDocVendedorField;

        [FileHelpers.FieldNullValue(typeof(System.Int64), "0")]
        private long nroDocVendedorField;

	    private string nombreVendedorField;

        [FileHelpers.FieldNullValue(typeof(System.Int32), "0")]
        private int tipoDocCompradorField;  //(fijo)

        [FileHelpers.FieldNullValue(typeof(System.Int64), "0")]
        private long nroDocCompradorField;	//(fijo)

   	    

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string nombre_clase
        {
            get
            {
                return nombre_claseField;
            }
        }

		/// <comentarios/>
        public string Fecha
		{
			get
			{
                return this.fechaField;
			}
			set
			{
                this.fechaField = value;
			}
		}

        /// <comentarios/>
        public int TipoComprobante
        {
            get
            {
                return this.tipoComprobanteField;
            }
            set
            {
                this.tipoComprobanteField = value;
            }
        }

		/// <comentarios/>
        public string NumeroDespacho
		{
			get
			{
                return this.numeroDespachoField;
			}
			set
			{
                this.numeroDespachoField = value;
			}
		}

		/// <comentarios/>
        public int TipoDocVendedor
		{
			get
			{
                return this.tipoDocVendedorField;
			}
			set
			{
                this.tipoDocVendedorField = value;
			}
		}

		/// <comentarios/>
        public long NroDocVendedor
		{
			get
			{
                return this.nroDocVendedorField;
			}
			set
			{
                this.nroDocVendedorField = value;
			}
		}

		/// <comentarios/>
        public string NombreVendedor
		{
			get
			{
                return this.nombreVendedorField;
			}
			set
			{
                this.nombreVendedorField = value;
			}
		}

        /// <comentarios/>
        public int TipoDocComprador
        {
            get
            {
                return this.tipoDocCompradorField;
            }
            set
            {
                this.tipoDocCompradorField = value;
            }
        }

        /// <comentarios/>
        public long NroDocComprador
        {
            get
            {
                return this.nroDocCompradorField;
            }
            set
            {
                this.nroDocCompradorField = value;
            }
        }
	}
}
