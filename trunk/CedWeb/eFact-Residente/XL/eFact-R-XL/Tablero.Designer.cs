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
			this.DirectorioButton = new System.Windows.Forms.Button();
			this.ExcelButton = new System.Windows.Forms.Button();
			this.XLTbutton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DirectorioButton
			// 
			this.DirectorioButton.Location = new System.Drawing.Point(12, 36);
			this.DirectorioButton.Name = "DirectorioButton";
			this.DirectorioButton.Size = new System.Drawing.Size(250, 23);
			this.DirectorioButton.TabIndex = 1;
			this.DirectorioButton.Text = "Seleccionar directorio para XML";
			this.DirectorioButton.UseVisualStyleBackColor = true;
			this.DirectorioButton.Click += new System.EventHandler(this.SalirButton_Click);
			// 
			// ExcelButton
			// 
			this.ExcelButton.Location = new System.Drawing.Point(12, 65);
			this.ExcelButton.Name = "ExcelButton";
			this.ExcelButton.Size = new System.Drawing.Size(250, 23);
			this.ExcelButton.TabIndex = 0;
			this.ExcelButton.Text = "Seleccionar archivo y generar XML";
			this.ExcelButton.UseVisualStyleBackColor = true;
			this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
			// 
			// XLTbutton
			// 
			this.XLTbutton.Location = new System.Drawing.Point(12, 7);
			this.XLTbutton.Name = "XLTbutton";
			this.XLTbutton.Size = new System.Drawing.Size(250, 23);
			this.XLTbutton.TabIndex = 2;
			this.XLTbutton.Text = "Abrir planilla modelo";
			this.XLTbutton.UseVisualStyleBackColor = true;
			this.XLTbutton.Click += new System.EventHandler(this.XLTbutton_Click);
			// 
			// Tablero
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(274, 100);
			this.Controls.Add(this.XLTbutton);
			this.Controls.Add(this.ExcelButton);
			this.Controls.Add(this.DirectorioButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Tablero";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eFact-Residente-XL";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DirectorioButton;
		private System.Windows.Forms.Button ExcelButton;
		private System.Windows.Forms.Button XLTbutton;
    }
}

