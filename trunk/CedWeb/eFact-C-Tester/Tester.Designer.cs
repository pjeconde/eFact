namespace eFact_C_Tester
{
    partial class Tester
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
            this.NumeroLoteLabel = new System.Windows.Forms.Label();
            this.NumeroLoteTextBox = new System.Windows.Forms.TextBox();
            this.ConsultaButton = new System.Windows.Forms.Button();
            this.PuntoVentaTextBox = new System.Windows.Forms.TextBox();
            this.PuntoVentaLabel = new System.Windows.Forms.Label();
            this.CuitTextBox = new System.Windows.Forms.TextBox();
            this.CuitLabel = new System.Windows.Forms.Label();
            this.EnviarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumeroLoteLabel
            // 
            this.NumeroLoteLabel.AutoSize = true;
            this.NumeroLoteLabel.Location = new System.Drawing.Point(12, 63);
            this.NumeroLoteLabel.Name = "NumeroLoteLabel";
            this.NumeroLoteLabel.Size = new System.Drawing.Size(86, 13);
            this.NumeroLoteLabel.TabIndex = 0;
            this.NumeroLoteLabel.Text = "Número de Lote:";
            // 
            // NumeroLoteTextBox
            // 
            this.NumeroLoteTextBox.Location = new System.Drawing.Point(103, 60);
            this.NumeroLoteTextBox.Name = "NumeroLoteTextBox";
            this.NumeroLoteTextBox.Size = new System.Drawing.Size(126, 20);
            this.NumeroLoteTextBox.TabIndex = 1;
            // 
            // ConsultaButton
            // 
            this.ConsultaButton.Location = new System.Drawing.Point(15, 86);
            this.ConsultaButton.Name = "ConsultaButton";
            this.ConsultaButton.Size = new System.Drawing.Size(214, 22);
            this.ConsultaButton.TabIndex = 2;
            this.ConsultaButton.Text = "Consultar Lote";
            this.ConsultaButton.UseVisualStyleBackColor = true;
            this.ConsultaButton.Click += new System.EventHandler(this.ConsultaButton_Click);
            // 
            // PuntoVentaTextBox
            // 
            this.PuntoVentaTextBox.Location = new System.Drawing.Point(103, 34);
            this.PuntoVentaTextBox.Name = "PuntoVentaTextBox";
            this.PuntoVentaTextBox.Size = new System.Drawing.Size(126, 20);
            this.PuntoVentaTextBox.TabIndex = 4;
            // 
            // PuntoVentaLabel
            // 
            this.PuntoVentaLabel.AutoSize = true;
            this.PuntoVentaLabel.Location = new System.Drawing.Point(14, 37);
            this.PuntoVentaLabel.Name = "PuntoVentaLabel";
            this.PuntoVentaLabel.Size = new System.Drawing.Size(84, 13);
            this.PuntoVentaLabel.TabIndex = 3;
            this.PuntoVentaLabel.Text = "Punto de Venta:";
            // 
            // CuitTextBox
            // 
            this.CuitTextBox.Location = new System.Drawing.Point(103, 8);
            this.CuitTextBox.Name = "CuitTextBox";
            this.CuitTextBox.Size = new System.Drawing.Size(126, 20);
            this.CuitTextBox.TabIndex = 6;
            // 
            // CuitLabel
            // 
            this.CuitLabel.AutoSize = true;
            this.CuitLabel.Location = new System.Drawing.Point(69, 11);
            this.CuitLabel.Name = "CuitLabel";
            this.CuitLabel.Size = new System.Drawing.Size(28, 13);
            this.CuitLabel.TabIndex = 5;
            this.CuitLabel.Text = "Cuit:";
            // 
            // EnviarButton
            // 
            this.EnviarButton.Location = new System.Drawing.Point(15, 114);
            this.EnviarButton.Name = "EnviarButton";
            this.EnviarButton.Size = new System.Drawing.Size(214, 22);
            this.EnviarButton.TabIndex = 7;
            this.EnviarButton.Text = "Enviar Lote";
            this.EnviarButton.UseVisualStyleBackColor = true;
            this.EnviarButton.Click += new System.EventHandler(this.EnviarButton_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 151);
            this.Controls.Add(this.EnviarButton);
            this.Controls.Add(this.CuitTextBox);
            this.Controls.Add(this.CuitLabel);
            this.Controls.Add(this.PuntoVentaTextBox);
            this.Controls.Add(this.PuntoVentaLabel);
            this.Controls.Add(this.ConsultaButton);
            this.Controls.Add(this.NumeroLoteTextBox);
            this.Controls.Add(this.NumeroLoteLabel);
            this.Name = "Tester";
            this.Text = "Pruebas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumeroLoteLabel;
        private System.Windows.Forms.TextBox NumeroLoteTextBox;
        private System.Windows.Forms.Button ConsultaButton;
        private System.Windows.Forms.TextBox PuntoVentaTextBox;
        private System.Windows.Forms.Label PuntoVentaLabel;
        private System.Windows.Forms.TextBox CuitTextBox;
        private System.Windows.Forms.Label CuitLabel;
        private System.Windows.Forms.Button EnviarButton;
    }
}

