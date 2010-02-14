namespace eFact_R
{
    partial class ConsultaArchivo
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ArchivosPanel = new System.Windows.Forms.Panel();
            this.ArchivosDataGridView = new System.Windows.Forms.DataGridView();
            this.PiePanel = new System.Windows.Forms.Panel();
            this.BotonesPanel = new System.Windows.Forms.Panel();
            this.SalirButton = new System.Windows.Forms.Button();
            this.IdArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TamañoUMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProcesado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.ArchivosPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivosDataGridView)).BeginInit();
            this.PiePanel.SuspendLayout();
            this.BotonesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.ArchivosPanel);
            this.SplitContainer.Panel1MinSize = 0;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PiePanel);
            this.SplitContainer.Panel2MinSize = 30;
            this.SplitContainer.Size = new System.Drawing.Size(931, 359);
            this.SplitContainer.SplitterDistance = 325;
            this.SplitContainer.TabIndex = 1;
            // 
            // ArchivosPanel
            // 
            this.ArchivosPanel.Controls.Add(this.ArchivosDataGridView);
            this.ArchivosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivosPanel.Location = new System.Drawing.Point(0, 0);
            this.ArchivosPanel.Name = "ArchivosPanel";
            this.ArchivosPanel.Size = new System.Drawing.Size(931, 325);
            this.ArchivosPanel.TabIndex = 4;
            // 
            // ArchivosDataGridView
            // 
            this.ArchivosDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ArchivosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArchivosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdArchivo,
            this.IdLote,
            this.Nombre,
            this.FechaCreacion,
            this.FechaModificacion,
            this.Tamaño,
            this.TamañoUMedida,
            this.Comentario,
            this.NombreProcesado,
            this.FechaProceso});
            this.ArchivosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivosDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ArchivosDataGridView.Name = "ArchivosDataGridView";
            this.ArchivosDataGridView.RowHeadersVisible = false;
            this.ArchivosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ArchivosDataGridView.Size = new System.Drawing.Size(931, 325);
            this.ArchivosDataGridView.TabIndex = 8;
            this.ArchivosDataGridView.DoubleClick += new System.EventHandler(this.ArchivosDataGridView_DoubleClick);
            // 
            // PiePanel
            // 
            this.PiePanel.Controls.Add(this.BotonesPanel);
            this.PiePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PiePanel.Location = new System.Drawing.Point(0, 0);
            this.PiePanel.Name = "PiePanel";
            this.PiePanel.Size = new System.Drawing.Size(931, 30);
            this.PiePanel.TabIndex = 5;
            // 
            // BotonesPanel
            // 
            this.BotonesPanel.Controls.Add(this.SalirButton);
            this.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BotonesPanel.Location = new System.Drawing.Point(0, 0);
            this.BotonesPanel.Name = "BotonesPanel";
            this.BotonesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BotonesPanel.Size = new System.Drawing.Size(931, 29);
            this.BotonesPanel.TabIndex = 13;
            // 
            // SalirButton
            // 
            this.SalirButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SalirButton.Location = new System.Drawing.Point(868, 3);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(60, 23);
            this.SalirButton.TabIndex = 9;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // IdArchivo
            // 
            this.IdArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdArchivo.DataPropertyName = "IdArchivo";
            this.IdArchivo.HeaderText = "Id.Archivo";
            this.IdArchivo.Name = "IdArchivo";
            this.IdArchivo.Width = 80;
            // 
            // IdLote
            // 
            this.IdLote.DataPropertyName = "IdLote";
            this.IdLote.HeaderText = "Id.Lote";
            this.IdLote.Name = "IdLote";
            this.IdLote.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 180;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            this.FechaCreacion.HeaderText = "Fecha Creación";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.Width = 120;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "FechaModificacion";
            this.FechaModificacion.HeaderText = "Fecha Ult. Modificación";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.Width = 120;
            // 
            // Tamaño
            // 
            this.Tamaño.DataPropertyName = "Tamaño";
            this.Tamaño.HeaderText = "Tamaño";
            this.Tamaño.Name = "Tamaño";
            this.Tamaño.Width = 60;
            // 
            // TamañoUMedida
            // 
            this.TamañoUMedida.DataPropertyName = "TamañoUMedida";
            this.TamañoUMedida.HeaderText = "UM";
            this.TamañoUMedida.Name = "TamañoUMedida";
            this.TamañoUMedida.Width = 40;
            // 
            // Comentario
            // 
            this.Comentario.DataPropertyName = "Comentario";
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.Name = "Comentario";
            this.Comentario.Width = 300;
            // 
            // NombreProcesado
            // 
            this.NombreProcesado.DataPropertyName = "NombreProcesado";
            this.NombreProcesado.HeaderText = "Nombre Arch. Procesado";
            this.NombreProcesado.Name = "NombreProcesado";
            this.NombreProcesado.Width = 300;
            // 
            // FechaProceso
            // 
            this.FechaProceso.DataPropertyName = "FechaProceso";
            this.FechaProceso.HeaderText = "Fecha Arch. Procesado";
            this.FechaProceso.Name = "FechaProceso";
            // 
            // ConsultaArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 359);
            this.Controls.Add(this.SplitContainer);
            this.Name = "ConsultaArchivo";
            this.Text = "Consulta de Archivos";
            this.Load += new System.EventHandler(this.ConsultaArchivo_Load);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.ResumeLayout(false);
            this.ArchivosPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchivosDataGridView)).EndInit();
            this.PiePanel.ResumeLayout(false);
            this.BotonesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel ArchivosPanel;
        private System.Windows.Forms.Panel PiePanel;
        private System.Windows.Forms.Panel BotonesPanel;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.DataGridView ArchivosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn TamañoUMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProcesado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProceso;
    }
}