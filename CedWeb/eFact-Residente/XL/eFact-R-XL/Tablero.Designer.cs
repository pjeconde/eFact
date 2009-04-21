namespace eFact_R_XL
{
    partial class Tablero
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tablero));
			this.SalirButton = new System.Windows.Forms.Button();
			this.ExcelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SalirButton
			// 
			this.SalirButton.Location = new System.Drawing.Point(12, 45);
			this.SalirButton.Name = "SalirButton";
			this.SalirButton.Size = new System.Drawing.Size(250, 23);
			this.SalirButton.TabIndex = 1;
			this.SalirButton.Text = "Salir";
			this.SalirButton.UseVisualStyleBackColor = true;
			this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
			// 
			// ExcelButton
			// 
			this.ExcelButton.Location = new System.Drawing.Point(12, 12);
			this.ExcelButton.Name = "ExcelButton";
			this.ExcelButton.Size = new System.Drawing.Size(250, 23);
			this.ExcelButton.TabIndex = 0;
			this.ExcelButton.Text = "Seleccionar archivo y generar XML";
			this.ExcelButton.UseVisualStyleBackColor = true;
			this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
			// 
			// Tablero
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(274, 72);
			this.ControlBox = false;
			this.Controls.Add(this.ExcelButton);
			this.Controls.Add(this.SalirButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Tablero";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eFact-Residente-XL";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SalirButton;
		private System.Windows.Forms.Button ExcelButton;
    }
}

