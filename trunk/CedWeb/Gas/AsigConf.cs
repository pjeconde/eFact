using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AsigConf
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class dias_operativos
    {

        private dias_operativosDia_operativo[] itemsField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("dia_operativo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public dias_operativosDia_operativo[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class dias_operativosDia_operativo
    {

        private string fechaField;

        private dias_operativosDia_operativoVolumen_gas[] volumenes_gasField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fecha
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
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("volumen_gas", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public dias_operativosDia_operativoVolumen_gas[] volumenes_gas
        {
            get
            {
                return this.volumenes_gasField;
            }
            set
            {
                this.volumenes_gasField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class dias_operativosDia_operativoVolumen_gas
    {

        private string megid_contrato_gasField;

        private string megid_tipo_balanceField;

        private dias_operativosDia_operativoVolumen_gasPUNTO[] pUNTOSField;

        private string movField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string megid_contrato_gas
        {
            get
            {
                return this.megid_contrato_gasField;
            }
            set
            {
                this.megid_contrato_gasField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string megid_tipo_balance
        {
            get
            {
                return this.megid_tipo_balanceField;
            }
            set
            {
                this.megid_tipo_balanceField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PUNTO", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public dias_operativosDia_operativoVolumen_gasPUNTO[] PUNTOS
        {
            get
            {
                return this.pUNTOSField;
            }
            set
            {
                this.pUNTOSField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mov
        {
            get
            {
                return this.movField;
            }
            set
            {
                this.movField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class dias_operativosDia_operativoVolumen_gasPUNTO
    {

        private string megid_punto_medicionField;

        private string volumenField;

        private string megid_motivoField;

        private string observaciones_motivoField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string megid_punto_medicion
        {
            get
            {
                return this.megid_punto_medicionField;
            }
            set
            {
                this.megid_punto_medicionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string volumen
        {
            get
            {
                return this.volumenField;
            }
            set
            {
                this.volumenField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string megid_motivo
        {
            get
            {
                return this.megid_motivoField;
            }
            set
            {
                this.megid_motivoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string observaciones_motivo
        {
            get
            {
                return this.observaciones_motivoField;
            }
            set
            {
                this.observaciones_motivoField = value;
            }
        }
    }
}
