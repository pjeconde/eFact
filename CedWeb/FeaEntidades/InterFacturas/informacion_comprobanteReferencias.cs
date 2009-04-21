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
	public partial class informacion_comprobanteReferencias
	{

		private int codigo_de_referenciaField;

		private long dato_de_referenciaField;

		/// <comentarios/>
		public int codigo_de_referencia
		{
			get
			{
				return this.codigo_de_referenciaField;
			}
			set
			{
				this.codigo_de_referenciaField = value;
			}
		}

		/// <comentarios/>
		public long dato_de_referencia
		{
			get
			{
				return this.dato_de_referenciaField;
			}
			set
			{
				this.dato_de_referenciaField = value;
			}
		}
	}

}
