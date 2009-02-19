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
	public partial class extensionesExtensiones_camara_facturas
	{

		private string clave_de_vinculacionField;

		private string id_templateField;

		/// <comentarios/>
		public string clave_de_vinculacion
		{
			get
			{
				return this.clave_de_vinculacionField;
			}
			set
			{
				this.clave_de_vinculacionField = value;
			}
		}

		/// <comentarios/>
		public string id_template
		{
			get
			{
				return this.id_templateField;
			}
			set
			{
				this.id_templateField = value;
			}
		}
	}
}
