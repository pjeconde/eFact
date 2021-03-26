namespace eFact_R
{
    partial class Comentarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comentarios));
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ComentariosPanel = new System.Windows.Forms.Panel();
            this.ComentariosTextBox = new System.Windows.Forms.TextBox();
            this.PiePanel = new System.Windows.Forms.Panel();
            this.BotonesPanel = new System.Windows.Forms.Panel();
            this.SalirButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.ComentariosPanel.SuspendLayout();
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
            this.SplitContainer.Panel1.Controls.Add(this.ComentariosPanel);
            this.SplitContainer.Panel1MinSize = 0;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PiePanel);
            this.SplitContainer.Panel2MinSize = 30;
            this.SplitContainer.Size = new System.Drawing.Size(820, 366);
            this.SplitContainer.SplitterDistance = 332;
            this.SplitContainer.TabIndex = 1;
            // 
            // ComentariosPanel
            // 
            this.ComentariosPanel.Controls.Add(this.ComentariosTextBox);
            this.ComentariosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComentariosPanel.Location = new System.Drawing.Point(0, 0);
            this.ComentariosPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ComentariosPanel.Name = "ComentariosPanel";
            this.ComentariosPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ComentariosPanel.Size = new System.Drawing.Size(820, 332);
            this.ComentariosPanel.TabIndex = 4;
            // 
            // ComentariosTextBox
            // 
            this.ComentariosTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComentariosTextBox.Location = new System.Drawing.Point(3, 3);
            this.ComentariosTextBox.Multiline = true;
            this.ComentariosTextBox.Name = "ComentariosTextBox";
            this.ComentariosTextBox.ReadOnly = true;
            this.ComentariosTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ComentariosTextBox.Size = new System.Drawing.Size(814, 326);
            this.ComentariosTextBox.TabIndex = 1;
            // 
            // PiePanel
            // 
            this.PiePanel.Controls.Add(this.BotonesPanel);
            this.PiePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PiePanel.Location = new System.Drawing.Point(0, 0);
            this.PiePanel.Name = "PiePanel";
            this.PiePanel.Size = new System.Drawing.Size(820, 30);
            this.PiePanel.TabIndex = 5;
            // 
            // BotonesPanel
            // 
            this.BotonesPanel.Controls.Add(this.SalirButton);
            this.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BotonesPanel.Location = new System.Drawing.Point(0, 0);
            this.BotonesPanel.Name = "BotonesPanel";
            this.BotonesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BotonesPanel.Size = new System.Drawing.Size(820, 30);
            this.BotonesPanel.TabIndex = 13;
            // 
            // SalirButton
            // 
            this.SalirButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SalirButton.Location = new System.Drawing.Point(757, 3);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(60, 24);
            this.SalirButton.TabIndex = 9;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // Comentarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 366);
            this.Controls.Add(this.SplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Comentarios";
            this.Text = "Comentarios";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ComentariosPanel.ResumeLayout(false);
            this.ComentariosPanel.PerformLayout();
            this.PiePanel.ResumeLayout(false);
            this.BotonesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel ComentariosPanel;
        private System.Windows.Forms.Panel PiePanel;
        private System.Windows.Forms.Panel BotonesPanel;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.TextBox ComentariosTextBox;

    }
}