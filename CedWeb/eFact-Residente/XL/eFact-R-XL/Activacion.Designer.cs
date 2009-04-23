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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Activacion));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ClaveSolicitudTextBox = new System.Windows.Forms.TextBox();
			this.ClaveActivacionTextBox = new System.Windows.Forms.TextBox();
			this.RegistrarButton = new System.Windows.Forms.Button();
			this.SalirButton = new System.Windows.Forms.Button();
			this.discoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.discoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
			this.ClaveSolicitudTextBox.ReadOnly = true;
			this.ClaveSolicitudTextBox.Size = new System.Drawing.Size(580, 20);
			this.ClaveSolicitudTextBox.TabIndex = 2;
			// 
			// ClaveActivacionTextBox
			// 
			this.ClaveActivacionTextBox.Location = new System.Drawing.Point(119, 46);
			this.ClaveActivacionTextBox.Name = "ClaveActivacionTextBox";
			this.ClaveActivacionTextBox.PasswordChar = '*';
			this.ClaveActivacionTextBox.Size = new System.Drawing.Size(580, 20);
			this.ClaveActivacionTextBox.TabIndex = 3;
			// 
			// RegistrarButton
			// 
			this.RegistrarButton.Location = new System.Drawing.Point(119, 73);
			this.RegistrarButton.Name = "RegistrarButton";
			this.RegistrarButton.Size = new System.Drawing.Size(121, 23);
			this.RegistrarButton.TabIndex = 4;
			this.RegistrarButton.Text = "Registrar activación";
			this.RegistrarButton.UseVisualStyleBackColor = true;
			this.RegistrarButton.Click += new System.EventHandler(this.RegistrarButton_Click);
			// 
			// SalirButton
			// 
			this.SalirButton.Location = new System.Drawing.Point(578, 73);
			this.SalirButton.Name = "SalirButton";
			this.SalirButton.Size = new System.Drawing.Size(121, 23);
			this.SalirButton.TabIndex = 5;
			this.SalirButton.Text = "Cancelar activación";
			this.SalirButton.UseVisualStyleBackColor = true;
			this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
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
			this.ClientSize = new System.Drawing.Size(711, 104);
			this.ControlBox = false;
			this.Controls.Add(this.SalirButton);
			this.Controls.Add(this.RegistrarButton);
			this.Controls.Add(this.ClaveActivacionTextBox);
			this.Controls.Add(this.ClaveSolicitudTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Activacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Activación eFact Residente versión Excel";
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
        private System.Windows.Forms.BindingSource discoBindingSource;
        private System.Windows.Forms.BindingSource discoBindingSource1;
        private System.Windows.Forms.Button SalirButton;
    }
}