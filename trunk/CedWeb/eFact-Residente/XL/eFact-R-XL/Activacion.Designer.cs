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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ClaveSolicitudTextBox = new System.Windows.Forms.TextBox();
            this.ClaveActivacionTextBox = new System.Windows.Forms.TextBox();
            this.RegistrarButton = new System.Windows.Forms.Button();
            this.DiscosDataGridView = new System.Windows.Forms.DataGridView();
            this.modeloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claveActivacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.discoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DiscosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discoBindingSource)).BeginInit();
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
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave de activación";
            this.label2.Visible = false;
            // 
            // ClaveSolicitudTextBox
            // 
            this.ClaveSolicitudTextBox.Location = new System.Drawing.Point(119, 16);
            this.ClaveSolicitudTextBox.Name = "ClaveSolicitudTextBox";
            this.ClaveSolicitudTextBox.Size = new System.Drawing.Size(580, 20);
            this.ClaveSolicitudTextBox.TabIndex = 2;
            this.ClaveSolicitudTextBox.Visible = false;
            // 
            // ClaveActivacionTextBox
            // 
            this.ClaveActivacionTextBox.Location = new System.Drawing.Point(119, 46);
            this.ClaveActivacionTextBox.Name = "ClaveActivacionTextBox";
            this.ClaveActivacionTextBox.Size = new System.Drawing.Size(580, 20);
            this.ClaveActivacionTextBox.TabIndex = 3;
            this.ClaveActivacionTextBox.Visible = false;
            // 
            // RegistrarButton
            // 
            this.RegistrarButton.Location = new System.Drawing.Point(119, 81);
            this.RegistrarButton.Name = "RegistrarButton";
            this.RegistrarButton.Size = new System.Drawing.Size(121, 23);
            this.RegistrarButton.TabIndex = 4;
            this.RegistrarButton.Text = "Registrar activación";
            this.RegistrarButton.UseVisualStyleBackColor = true;
            this.RegistrarButton.Visible = false;
            // 
            // DiscosDataGridView
            // 
            this.DiscosDataGridView.AllowUserToAddRows = false;
            this.DiscosDataGridView.AllowUserToDeleteRows = false;
            this.DiscosDataGridView.AllowUserToResizeRows = false;
            this.DiscosDataGridView.AutoGenerateColumns = false;
            this.DiscosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiscosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modeloDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.nroSerieDataGridViewTextBoxColumn,
            this.claveActivacionDataGridViewTextBoxColumn});
            this.DiscosDataGridView.DataSource = this.discoBindingSource1;
            this.DiscosDataGridView.Location = new System.Drawing.Point(15, 121);
            this.DiscosDataGridView.MultiSelect = false;
            this.DiscosDataGridView.Name = "DiscosDataGridView";
            this.DiscosDataGridView.Size = new System.Drawing.Size(684, 198);
            this.DiscosDataGridView.TabIndex = 5;
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            this.modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            this.modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            this.modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            this.modeloDataGridViewTextBoxColumn.ReadOnly = true;
            this.modeloDataGridViewTextBoxColumn.Width = 300;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Width = 60;
            // 
            // nroSerieDataGridViewTextBoxColumn
            // 
            this.nroSerieDataGridViewTextBoxColumn.DataPropertyName = "NroSerie";
            this.nroSerieDataGridViewTextBoxColumn.HeaderText = "NroSerie";
            this.nroSerieDataGridViewTextBoxColumn.Name = "nroSerieDataGridViewTextBoxColumn";
            this.nroSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroSerieDataGridViewTextBoxColumn.Width = 280;
            // 
            // claveActivacionDataGridViewTextBoxColumn
            // 
            this.claveActivacionDataGridViewTextBoxColumn.DataPropertyName = "ClaveActivacion";
            this.claveActivacionDataGridViewTextBoxColumn.HeaderText = "ClaveActivacion";
            this.claveActivacionDataGridViewTextBoxColumn.Name = "claveActivacionDataGridViewTextBoxColumn";
            this.claveActivacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.claveActivacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // discoBindingSource1
            // 
            this.discoBindingSource1.DataSource = typeof(eFact_R_XL.Entidades.Disco);
            // 
            // discoBindingSource
            // 
            this.discoBindingSource.DataSource = typeof(eFact_R_XL.Entidades.Disco);
            // 
            // Activacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 331);
            this.Controls.Add(this.DiscosDataGridView);
            this.Controls.Add(this.RegistrarButton);
            this.Controls.Add(this.ClaveActivacionTextBox);
            this.Controls.Add(this.ClaveSolicitudTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Activacion";
            this.Text = "Activación";
            ((System.ComponentModel.ISupportInitialize)(this.DiscosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClaveSolicitudTextBox;
        private System.Windows.Forms.TextBox ClaveActivacionTextBox;
        private System.Windows.Forms.Button RegistrarButton;
        private System.Windows.Forms.DataGridView DiscosDataGridView;
        private System.Windows.Forms.BindingSource discoBindingSource;
        private System.Windows.Forms.BindingSource discoBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveActivacionDataGridViewTextBoxColumn;
    }
}