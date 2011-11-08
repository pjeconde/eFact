namespace Gas
{
    partial class ProcesarArchivoExcel
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
			this.ProcesarButton = new System.Windows.Forms.Button();
			this.BuscarArchivoButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ProcesarButton
			// 
			this.ProcesarButton.Location = new System.Drawing.Point(12, 44);
			this.ProcesarButton.Name = "ProcesarButton";
			this.ProcesarButton.Size = new System.Drawing.Size(582, 26);
			this.ProcesarButton.TabIndex = 0;
			this.ProcesarButton.Text = "Procesar";
			this.ProcesarButton.UseVisualStyleBackColor = true;
			this.ProcesarButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// BuscarArchivoButton
			// 
			this.BuscarArchivoButton.Location = new System.Drawing.Point(12, 12);
			this.BuscarArchivoButton.Name = "BuscarArchivoButton";
			this.BuscarArchivoButton.Size = new System.Drawing.Size(582, 26);
			this.BuscarArchivoButton.TabIndex = 1;
			this.BuscarArchivoButton.Text = "Buscar Archivo";
			this.BuscarArchivoButton.UseVisualStyleBackColor = true;
			this.BuscarArchivoButton.Click += new System.EventHandler(this.BuscarArchivoButton_Click);
			// 
			// ProcesarArchivoExcel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(606, 83);
			this.Controls.Add(this.BuscarArchivoButton);
			this.Controls.Add(this.ProcesarButton);
			this.Name = "ProcesarArchivoExcel";
			this.Text = "Procesamiento de planilla Excel";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProcesarButton;
		private System.Windows.Forms.Button BuscarArchivoButton;
    }
}

