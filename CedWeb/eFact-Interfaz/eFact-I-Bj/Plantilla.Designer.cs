namespace eFact_I_Bj
{
    partial class Plantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plantilla));
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ComentariosPanel = new System.Windows.Forms.Panel();
            this.DescrPlantillaTextBox = new System.Windows.Forms.TextBox();
            this.PlantillaLabel = new System.Windows.Forms.Label();
            this.DescrPlantillaComboBox = new System.Windows.Forms.ComboBox();
            this.PiePanel = new System.Windows.Forms.Panel();
            this.BotonesPanel = new System.Windows.Forms.Panel();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.EjecutarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.DatosPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.LeyendaBancoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LeyendaMonedaTextBox = new System.Windows.Forms.TextBox();
            this.Leyenda5TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Leyenda4TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Leyenda3TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Leyenda2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Leyenda1TextBox = new System.Windows.Forms.TextBox();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.ComentariosPanel.SuspendLayout();
            this.PiePanel.SuspendLayout();
            this.BotonesPanel.SuspendLayout();
            this.DatosPanel.SuspendLayout();
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
            this.SplitContainer.Size = new System.Drawing.Size(832, 452);
            this.SplitContainer.SplitterDistance = 409;
            this.SplitContainer.TabIndex = 1;
            // 
            // ComentariosPanel
            // 
            this.ComentariosPanel.Controls.Add(this.DatosPanel);
            this.ComentariosPanel.Controls.Add(this.DescrPlantillaComboBox);
            this.ComentariosPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComentariosPanel.Location = new System.Drawing.Point(0, 0);
            this.ComentariosPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ComentariosPanel.Name = "ComentariosPanel";
            this.ComentariosPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ComentariosPanel.Size = new System.Drawing.Size(832, 409);
            this.ComentariosPanel.TabIndex = 4;
            // 
            // DescrPlantillaTextBox
            // 
            this.DescrPlantillaTextBox.Location = new System.Drawing.Point(100, 3);
            this.DescrPlantillaTextBox.Name = "DescrPlantillaTextBox";
            this.DescrPlantillaTextBox.Size = new System.Drawing.Size(714, 20);
            this.DescrPlantillaTextBox.TabIndex = 17;
            // 
            // PlantillaLabel
            // 
            this.PlantillaLabel.AutoSize = true;
            this.PlantillaLabel.Location = new System.Drawing.Point(8, 6);
            this.PlantillaLabel.Name = "PlantillaLabel";
            this.PlantillaLabel.Size = new System.Drawing.Size(86, 13);
            this.PlantillaLabel.TabIndex = 16;
            this.PlantillaLabel.Text = "Nombre Plantilla:";
            // 
            // DescrPlantillaComboBox
            // 
            this.DescrPlantillaComboBox.FormattingEnabled = true;
            this.DescrPlantillaComboBox.Location = new System.Drawing.Point(17, 12);
            this.DescrPlantillaComboBox.Name = "DescrPlantillaComboBox";
            this.DescrPlantillaComboBox.Size = new System.Drawing.Size(803, 21);
            this.DescrPlantillaComboBox.TabIndex = 15;
            this.DescrPlantillaComboBox.SelectedValueChanged += new System.EventHandler(this.DescrPlantillaComboBox_SelectedValueChanged);
            // 
            // PiePanel
            // 
            this.PiePanel.Controls.Add(this.BotonesPanel);
            this.PiePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PiePanel.Location = new System.Drawing.Point(0, 0);
            this.PiePanel.Name = "PiePanel";
            this.PiePanel.Size = new System.Drawing.Size(832, 30);
            this.PiePanel.TabIndex = 5;
            // 
            // BotonesPanel
            // 
            this.BotonesPanel.Controls.Add(this.CancelarButton);
            this.BotonesPanel.Controls.Add(this.EjecutarButton);
            this.BotonesPanel.Controls.Add(this.SalirButton);
            this.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BotonesPanel.Location = new System.Drawing.Point(0, 0);
            this.BotonesPanel.Name = "BotonesPanel";
            this.BotonesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BotonesPanel.Size = new System.Drawing.Size(832, 30);
            this.BotonesPanel.TabIndex = 13;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CancelarButton.Location = new System.Drawing.Point(667, 3);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(102, 24);
            this.CancelarButton.TabIndex = 11;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // EjecutarButton
            // 
            this.EjecutarButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.EjecutarButton.Location = new System.Drawing.Point(3, 3);
            this.EjecutarButton.Name = "EjecutarButton";
            this.EjecutarButton.Size = new System.Drawing.Size(102, 24);
            this.EjecutarButton.TabIndex = 10;
            this.EjecutarButton.Text = "Ejecutar";
            this.EjecutarButton.UseVisualStyleBackColor = true;
            this.EjecutarButton.Click += new System.EventHandler(this.EjecutarButton_Click);
            // 
            // SalirButton
            // 
            this.SalirButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SalirButton.Location = new System.Drawing.Point(769, 3);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(60, 24);
            this.SalirButton.TabIndex = 9;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // DatosPanel
            // 
            this.DatosPanel.Controls.Add(this.label7);
            this.DatosPanel.Controls.Add(this.LeyendaBancoTextBox);
            this.DatosPanel.Controls.Add(this.label6);
            this.DatosPanel.Controls.Add(this.LeyendaMonedaTextBox);
            this.DatosPanel.Controls.Add(this.Leyenda5TextBox);
            this.DatosPanel.Controls.Add(this.label5);
            this.DatosPanel.Controls.Add(this.Leyenda4TextBox);
            this.DatosPanel.Controls.Add(this.label4);
            this.DatosPanel.Controls.Add(this.Leyenda3TextBox);
            this.DatosPanel.Controls.Add(this.label3);
            this.DatosPanel.Controls.Add(this.Leyenda2TextBox);
            this.DatosPanel.Controls.Add(this.label2);
            this.DatosPanel.Controls.Add(this.label1);
            this.DatosPanel.Controls.Add(this.Leyenda1TextBox);
            this.DatosPanel.Controls.Add(this.DescrPlantillaTextBox);
            this.DatosPanel.Controls.Add(this.PlantillaLabel);
            this.DatosPanel.Location = new System.Drawing.Point(6, 50);
            this.DatosPanel.Name = "DatosPanel";
            this.DatosPanel.Size = new System.Drawing.Size(823, 344);
            this.DatosPanel.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Leyenda Banco:";
            // 
            // LeyendaBancoTextBox
            // 
            this.LeyendaBancoTextBox.Location = new System.Drawing.Point(100, 298);
            this.LeyendaBancoTextBox.Multiline = true;
            this.LeyendaBancoTextBox.Name = "LeyendaBancoTextBox";
            this.LeyendaBancoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LeyendaBancoTextBox.Size = new System.Drawing.Size(714, 38);
            this.LeyendaBancoTextBox.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Leyenda Moneda:";
            // 
            // LeyendaMonedaTextBox
            // 
            this.LeyendaMonedaTextBox.Location = new System.Drawing.Point(100, 254);
            this.LeyendaMonedaTextBox.Multiline = true;
            this.LeyendaMonedaTextBox.Name = "LeyendaMonedaTextBox";
            this.LeyendaMonedaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LeyendaMonedaTextBox.Size = new System.Drawing.Size(714, 38);
            this.LeyendaMonedaTextBox.TabIndex = 28;
            // 
            // Leyenda5TextBox
            // 
            this.Leyenda5TextBox.Location = new System.Drawing.Point(100, 207);
            this.Leyenda5TextBox.Multiline = true;
            this.Leyenda5TextBox.Name = "Leyenda5TextBox";
            this.Leyenda5TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Leyenda5TextBox.Size = new System.Drawing.Size(714, 38);
            this.Leyenda5TextBox.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Leyenda 5:";
            // 
            // Leyenda4TextBox
            // 
            this.Leyenda4TextBox.Location = new System.Drawing.Point(100, 163);
            this.Leyenda4TextBox.Multiline = true;
            this.Leyenda4TextBox.Name = "Leyenda4TextBox";
            this.Leyenda4TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Leyenda4TextBox.Size = new System.Drawing.Size(714, 38);
            this.Leyenda4TextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Leyenda 4:";
            // 
            // Leyenda3TextBox
            // 
            this.Leyenda3TextBox.Location = new System.Drawing.Point(100, 117);
            this.Leyenda3TextBox.Multiline = true;
            this.Leyenda3TextBox.Name = "Leyenda3TextBox";
            this.Leyenda3TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Leyenda3TextBox.Size = new System.Drawing.Size(714, 38);
            this.Leyenda3TextBox.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Leyenda 3:";
            // 
            // Leyenda2TextBox
            // 
            this.Leyenda2TextBox.Location = new System.Drawing.Point(100, 73);
            this.Leyenda2TextBox.Multiline = true;
            this.Leyenda2TextBox.Name = "Leyenda2TextBox";
            this.Leyenda2TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Leyenda2TextBox.Size = new System.Drawing.Size(714, 38);
            this.Leyenda2TextBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Leyenda 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Leyenda 1:";
            // 
            // Leyenda1TextBox
            // 
            this.Leyenda1TextBox.Location = new System.Drawing.Point(100, 29);
            this.Leyenda1TextBox.Multiline = true;
            this.Leyenda1TextBox.Name = "Leyenda1TextBox";
            this.Leyenda1TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Leyenda1TextBox.Size = new System.Drawing.Size(714, 38);
            this.Leyenda1TextBox.TabIndex = 18;
            // 
            // Plantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 452);
            this.Controls.Add(this.SplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Plantilla";
            this.Text = "Plantilla";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.ResumeLayout(false);
            this.ComentariosPanel.ResumeLayout(false);
            this.PiePanel.ResumeLayout(false);
            this.BotonesPanel.ResumeLayout(false);
            this.DatosPanel.ResumeLayout(false);
            this.DatosPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel ComentariosPanel;
        private System.Windows.Forms.Panel PiePanel;
        private System.Windows.Forms.Panel BotonesPanel;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.ComboBox DescrPlantillaComboBox;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button EjecutarButton;
        private System.Windows.Forms.Label PlantillaLabel;
        private System.Windows.Forms.TextBox DescrPlantillaTextBox;
        private System.Windows.Forms.Panel DatosPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LeyendaBancoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LeyendaMonedaTextBox;
        private System.Windows.Forms.TextBox Leyenda5TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Leyenda4TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Leyenda3TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Leyenda2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Leyenda1TextBox;

    }
}