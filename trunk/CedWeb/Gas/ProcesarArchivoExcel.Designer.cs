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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesarArchivoExcel));
            this.ProcesarButton = new System.Windows.Forms.Button();
            this.BuscarArchivoButton = new System.Windows.Forms.Button();
            this.SeleccionarDirectorioButton = new System.Windows.Forms.Button();
            this.DirectorioXMLTextBox = new System.Windows.Forms.TextBox();
            this.DirectorioXMLLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectorioEXCELTextBox = new System.Windows.Forms.TextBox();
            this.PlanillaCONFRadioButton = new System.Windows.Forms.RadioButton();
            this.PlanillaASIGRadioButton = new System.Windows.Forms.RadioButton();
            this.PlanillaLIQRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreHojaCONFTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.NombreHojaLIQTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NombreHojaASIGTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcesarButton
            // 
            this.ProcesarButton.Enabled = false;
            this.ProcesarButton.Location = new System.Drawing.Point(12, 231);
            this.ProcesarButton.Name = "ProcesarButton";
            this.ProcesarButton.Size = new System.Drawing.Size(698, 26);
            this.ProcesarButton.TabIndex = 0;
            this.ProcesarButton.Text = "Procesar";
            this.ProcesarButton.UseVisualStyleBackColor = true;
            this.ProcesarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // BuscarArchivoButton
            // 
            this.BuscarArchivoButton.Location = new System.Drawing.Point(12, 113);
            this.BuscarArchivoButton.Name = "BuscarArchivoButton";
            this.BuscarArchivoButton.Size = new System.Drawing.Size(698, 26);
            this.BuscarArchivoButton.TabIndex = 1;
            this.BuscarArchivoButton.Text = "Buscar Archivo EXCEL";
            this.BuscarArchivoButton.UseVisualStyleBackColor = true;
            this.BuscarArchivoButton.Click += new System.EventHandler(this.BuscarArchivoButton_Click);
            // 
            // SeleccionarDirectorioButton
            // 
            this.SeleccionarDirectorioButton.Location = new System.Drawing.Point(12, 173);
            this.SeleccionarDirectorioButton.Name = "SeleccionarDirectorioButton";
            this.SeleccionarDirectorioButton.Size = new System.Drawing.Size(698, 26);
            this.SeleccionarDirectorioButton.TabIndex = 6;
            this.SeleccionarDirectorioButton.Text = "Seleccionar directorio para XML";
            this.SeleccionarDirectorioButton.UseVisualStyleBackColor = true;
            this.SeleccionarDirectorioButton.Click += new System.EventHandler(this.SeleccionarDirectorioButton_Click);
            // 
            // DirectorioXMLTextBox
            // 
            this.DirectorioXMLTextBox.BackColor = System.Drawing.Color.White;
            this.DirectorioXMLTextBox.Location = new System.Drawing.Point(115, 205);
            this.DirectorioXMLTextBox.Name = "DirectorioXMLTextBox";
            this.DirectorioXMLTextBox.ReadOnly = true;
            this.DirectorioXMLTextBox.Size = new System.Drawing.Size(595, 20);
            this.DirectorioXMLTextBox.TabIndex = 7;
            // 
            // DirectorioXMLLabel
            // 
            this.DirectorioXMLLabel.AutoSize = true;
            this.DirectorioXMLLabel.Location = new System.Drawing.Point(29, 208);
            this.DirectorioXMLLabel.Name = "DirectorioXMLLabel";
            this.DirectorioXMLLabel.Size = new System.Drawing.Size(80, 13);
            this.DirectorioXMLLabel.TabIndex = 8;
            this.DirectorioXMLLabel.Text = "Directorio XML:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Directorio EXCEL:";
            // 
            // DirectorioEXCELTextBox
            // 
            this.DirectorioEXCELTextBox.AcceptsTab = true;
            this.DirectorioEXCELTextBox.BackColor = System.Drawing.Color.White;
            this.DirectorioEXCELTextBox.Location = new System.Drawing.Point(115, 147);
            this.DirectorioEXCELTextBox.Name = "DirectorioEXCELTextBox";
            this.DirectorioEXCELTextBox.ReadOnly = true;
            this.DirectorioEXCELTextBox.Size = new System.Drawing.Size(595, 20);
            this.DirectorioEXCELTextBox.TabIndex = 9;
            // 
            // PlanillaCONFRadioButton
            // 
            this.PlanillaCONFRadioButton.AutoSize = true;
            this.PlanillaCONFRadioButton.Checked = true;
            this.PlanillaCONFRadioButton.Location = new System.Drawing.Point(12, 12);
            this.PlanillaCONFRadioButton.Name = "PlanillaCONFRadioButton";
            this.PlanillaCONFRadioButton.Size = new System.Drawing.Size(54, 17);
            this.PlanillaCONFRadioButton.TabIndex = 11;
            this.PlanillaCONFRadioButton.TabStop = true;
            this.PlanillaCONFRadioButton.Text = "CONF";
            this.PlanillaCONFRadioButton.UseVisualStyleBackColor = true;
            // 
            // PlanillaASIGRadioButton
            // 
            this.PlanillaASIGRadioButton.AutoSize = true;
            this.PlanillaASIGRadioButton.Location = new System.Drawing.Point(250, 12);
            this.PlanillaASIGRadioButton.Name = "PlanillaASIGRadioButton";
            this.PlanillaASIGRadioButton.Size = new System.Drawing.Size(50, 17);
            this.PlanillaASIGRadioButton.TabIndex = 12;
            this.PlanillaASIGRadioButton.Text = "ASIG";
            this.PlanillaASIGRadioButton.UseVisualStyleBackColor = true;
            // 
            // PlanillaLIQRadioButton
            // 
            this.PlanillaLIQRadioButton.AutoSize = true;
            this.PlanillaLIQRadioButton.Location = new System.Drawing.Point(489, 12);
            this.PlanillaLIQRadioButton.Name = "PlanillaLIQRadioButton";
            this.PlanillaLIQRadioButton.Size = new System.Drawing.Size(42, 17);
            this.PlanillaLIQRadioButton.TabIndex = 18;
            this.PlanillaLIQRadioButton.Text = "LIQ";
            this.PlanillaLIQRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NombreHojaCONFTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 61);
            this.panel1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre:";
            // 
            // NombreHojaCONFTextBox
            // 
            this.NombreHojaCONFTextBox.Location = new System.Drawing.Point(61, 33);
            this.NombreHojaCONFTextBox.Name = "NombreHojaCONFTextBox";
            this.NombreHojaCONFTextBox.Size = new System.Drawing.Size(146, 20);
            this.NombreHojaCONFTextBox.TabIndex = 17;
            this.NombreHojaCONFTextBox.Text = "CONF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hoja de la Planilla";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.NombreHojaASIGTextBox);
            this.panel2.Location = new System.Drawing.Point(250, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 60);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.NombreHojaLIQTextBox);
            this.panel3.Location = new System.Drawing.Point(489, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 60);
            this.panel3.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nombre:";
            // 
            // NombreHojaLIQTextBox
            // 
            this.NombreHojaLIQTextBox.Location = new System.Drawing.Point(61, 34);
            this.NombreHojaLIQTextBox.Name = "NombreHojaLIQTextBox";
            this.NombreHojaLIQTextBox.Size = new System.Drawing.Size(146, 20);
            this.NombreHojaLIQTextBox.TabIndex = 22;
            this.NombreHojaLIQTextBox.Text = "LIQ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nombre:";
            // 
            // NombreHojaASIGTextBox
            // 
            this.NombreHojaASIGTextBox.Location = new System.Drawing.Point(61, 33);
            this.NombreHojaASIGTextBox.Name = "NombreHojaASIGTextBox";
            this.NombreHojaASIGTextBox.Size = new System.Drawing.Size(146, 20);
            this.NombreHojaASIGTextBox.TabIndex = 18;
            this.NombreHojaASIGTextBox.Text = "ASIG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hoja de la Planilla";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Hoja de la Planilla";
            // 
            // ProcesarArchivoExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 270);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PlanillaLIQRadioButton);
            this.Controls.Add(this.PlanillaASIGRadioButton);
            this.Controls.Add(this.PlanillaCONFRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DirectorioEXCELTextBox);
            this.Controls.Add(this.DirectorioXMLLabel);
            this.Controls.Add(this.DirectorioXMLTextBox);
            this.Controls.Add(this.SeleccionarDirectorioButton);
            this.Controls.Add(this.BuscarArchivoButton);
            this.Controls.Add(this.ProcesarButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProcesarArchivoExcel";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Procesamiento de planilla Excel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ProcesarButton;
        private System.Windows.Forms.Button BuscarArchivoButton;
        private System.Windows.Forms.Button SeleccionarDirectorioButton;
        private System.Windows.Forms.TextBox DirectorioXMLTextBox;
        private System.Windows.Forms.Label DirectorioXMLLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DirectorioEXCELTextBox;
        private System.Windows.Forms.RadioButton PlanillaCONFRadioButton;
        private System.Windows.Forms.RadioButton PlanillaASIGRadioButton;
        private System.Windows.Forms.RadioButton PlanillaLIQRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreHojaCONFTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NombreHojaASIGTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NombreHojaLIQTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

