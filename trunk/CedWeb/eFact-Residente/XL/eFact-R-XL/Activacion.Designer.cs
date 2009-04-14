namespace eFact_R_XL
{
    partial class Activacion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClaveSolicitudTextBox = new System.Windows.Forms.TextBox();
            this.ClaveActivacionTextBox = new System.Windows.Forms.TextBox();
            this.RegistrarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave de solicitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave de activación";
            // 
            // ClaveSolicitudTextBox
            // 
            this.ClaveSolicitudTextBox.Location = new System.Drawing.Point(119, 16);
            this.ClaveSolicitudTextBox.Name = "ClaveSolicitudTextBox";
            this.ClaveSolicitudTextBox.Size = new System.Drawing.Size(335, 20);
            this.ClaveSolicitudTextBox.TabIndex = 2;
            // 
            // ClaveActivacionTextBox
            // 
            this.ClaveActivacionTextBox.Location = new System.Drawing.Point(119, 46);
            this.ClaveActivacionTextBox.Name = "ClaveActivacionTextBox";
            this.ClaveActivacionTextBox.Size = new System.Drawing.Size(335, 20);
            this.ClaveActivacionTextBox.TabIndex = 3;
            // 
            // RegistrarButton
            // 
            this.RegistrarButton.Location = new System.Drawing.Point(119, 81);
            this.RegistrarButton.Name = "RegistrarButton";
            this.RegistrarButton.Size = new System.Drawing.Size(121, 23);
            this.RegistrarButton.TabIndex = 4;
            this.RegistrarButton.Text = "Registrar activación";
            this.RegistrarButton.UseVisualStyleBackColor = true;
            // 
            // Activacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 136);
            this.Controls.Add(this.RegistrarButton);
            this.Controls.Add(this.ClaveActivacionTextBox);
            this.Controls.Add(this.ClaveSolicitudTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Activacion";
            this.Text = "Activación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClaveSolicitudTextBox;
        private System.Windows.Forms.TextBox ClaveActivacionTextBox;
        private System.Windows.Forms.Button RegistrarButton;
    }
}