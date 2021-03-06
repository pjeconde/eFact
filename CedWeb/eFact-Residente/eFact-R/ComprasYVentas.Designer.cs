﻿namespace eFact_R
{
    partial class ComprasYVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasYVentas));
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultadosTextBox = new System.Windows.Forms.TextBox();
            this.PeriodoLabel = new System.Windows.Forms.Label();
            this.VentasRadioButton = new System.Windows.Forms.RadioButton();
            this.ComprasRadioButton = new System.Windows.Forms.RadioButton();
            this.FechaDsdDTP = new System.Windows.Forms.DateTimePicker();
            this.FechaHstDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.CUITLabel = new System.Windows.Forms.Label();
            this.CuitVendedorComboBox = new System.Windows.Forms.ComboBox();
            this.PiePanel = new System.Windows.Forms.Panel();
            this.BotonesPanel = new System.Windows.Forms.Panel();
            this.GenerarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.PrincipalPanel.SuspendLayout();
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
            this.SplitContainer.Panel1.Controls.Add(this.PrincipalPanel);
            this.SplitContainer.Panel1MinSize = 0;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PiePanel);
            this.SplitContainer.Panel2MinSize = 30;
            this.SplitContainer.Size = new System.Drawing.Size(678, 278);
            this.SplitContainer.SplitterDistance = 244;
            this.SplitContainer.TabIndex = 2;
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.label1);
            this.PrincipalPanel.Controls.Add(this.ResultadosTextBox);
            this.PrincipalPanel.Controls.Add(this.PeriodoLabel);
            this.PrincipalPanel.Controls.Add(this.VentasRadioButton);
            this.PrincipalPanel.Controls.Add(this.ComprasRadioButton);
            this.PrincipalPanel.Controls.Add(this.FechaDsdDTP);
            this.PrincipalPanel.Controls.Add(this.FechaHstDTP);
            this.PrincipalPanel.Controls.Add(this.label3);
            this.PrincipalPanel.Controls.Add(this.CUITLabel);
            this.PrincipalPanel.Controls.Add(this.CuitVendedorComboBox);
            this.PrincipalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrincipalPanel.Location = new System.Drawing.Point(0, 0);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(678, 244);
            this.PrincipalPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Resultados:";
            // 
            // ResultadosTextBox
            // 
            this.ResultadosTextBox.Location = new System.Drawing.Point(12, 71);
            this.ResultadosTextBox.Multiline = true;
            this.ResultadosTextBox.Name = "ResultadosTextBox";
            this.ResultadosTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultadosTextBox.Size = new System.Drawing.Size(657, 162);
            this.ResultadosTextBox.TabIndex = 78;
            // 
            // PeriodoLabel
            // 
            this.PeriodoLabel.AutoSize = true;
            this.PeriodoLabel.Location = new System.Drawing.Point(406, 15);
            this.PeriodoLabel.Name = "PeriodoLabel";
            this.PeriodoLabel.Size = new System.Drawing.Size(48, 13);
            this.PeriodoLabel.TabIndex = 77;
            this.PeriodoLabel.Text = "Período:";
            // 
            // VentasRadioButton
            // 
            this.VentasRadioButton.AutoSize = true;
            this.VentasRadioButton.Checked = true;
            this.VentasRadioButton.Location = new System.Drawing.Point(244, 13);
            this.VentasRadioButton.Name = "VentasRadioButton";
            this.VentasRadioButton.Size = new System.Drawing.Size(58, 17);
            this.VentasRadioButton.TabIndex = 76;
            this.VentasRadioButton.TabStop = true;
            this.VentasRadioButton.Text = "Ventas";
            this.VentasRadioButton.UseVisualStyleBackColor = true;
            // 
            // ComprasRadioButton
            // 
            this.ComprasRadioButton.AutoSize = true;
            this.ComprasRadioButton.Location = new System.Drawing.Point(308, 13);
            this.ComprasRadioButton.Name = "ComprasRadioButton";
            this.ComprasRadioButton.Size = new System.Drawing.Size(66, 17);
            this.ComprasRadioButton.TabIndex = 75;
            this.ComprasRadioButton.Text = "Compras";
            this.ComprasRadioButton.UseVisualStyleBackColor = true;
            // 
            // FechaDsdDTP
            // 
            this.FechaDsdDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaDsdDTP.Location = new System.Drawing.Point(458, 12);
            this.FechaDsdDTP.Name = "FechaDsdDTP";
            this.FechaDsdDTP.Size = new System.Drawing.Size(94, 20);
            this.FechaDsdDTP.TabIndex = 72;
            // 
            // FechaHstDTP
            // 
            this.FechaHstDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHstDTP.Location = new System.Drawing.Point(575, 12);
            this.FechaHstDTP.Name = "FechaHstDTP";
            this.FechaHstDTP.Size = new System.Drawing.Size(94, 20);
            this.FechaHstDTP.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "al";
            // 
            // CUITLabel
            // 
            this.CUITLabel.AutoSize = true;
            this.CUITLabel.Location = new System.Drawing.Point(12, 15);
            this.CUITLabel.Name = "CUITLabel";
            this.CUITLabel.Size = new System.Drawing.Size(28, 13);
            this.CUITLabel.TabIndex = 71;
            this.CUITLabel.Text = "Cuit:";
            // 
            // CuitVendedorComboBox
            // 
            this.CuitVendedorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CuitVendedorComboBox.FormattingEnabled = true;
            this.CuitVendedorComboBox.Location = new System.Drawing.Point(46, 11);
            this.CuitVendedorComboBox.Name = "CuitVendedorComboBox";
            this.CuitVendedorComboBox.Size = new System.Drawing.Size(158, 21);
            this.CuitVendedorComboBox.TabIndex = 70;
            this.CuitVendedorComboBox.SelectedIndexChanged += new System.EventHandler(this.CuitVendedorComboBox_SelectedIndexChanged);
            // 
            // PiePanel
            // 
            this.PiePanel.Controls.Add(this.BotonesPanel);
            this.PiePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PiePanel.Location = new System.Drawing.Point(0, 0);
            this.PiePanel.Name = "PiePanel";
            this.PiePanel.Size = new System.Drawing.Size(678, 30);
            this.PiePanel.TabIndex = 5;
            // 
            // BotonesPanel
            // 
            this.BotonesPanel.Controls.Add(this.GenerarButton);
            this.BotonesPanel.Controls.Add(this.SalirButton);
            this.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BotonesPanel.Location = new System.Drawing.Point(0, 3);
            this.BotonesPanel.Name = "BotonesPanel";
            this.BotonesPanel.Padding = new System.Windows.Forms.Padding(3);
            this.BotonesPanel.Size = new System.Drawing.Size(678, 27);
            this.BotonesPanel.TabIndex = 13;
            // 
            // GenerarButton
            // 
            this.GenerarButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GenerarButton.Location = new System.Drawing.Point(3, 3);
            this.GenerarButton.Name = "GenerarButton";
            this.GenerarButton.Size = new System.Drawing.Size(99, 21);
            this.GenerarButton.TabIndex = 23;
            this.GenerarButton.Text = "Generar";
            this.GenerarButton.UseVisualStyleBackColor = true;
            this.GenerarButton.Click += new System.EventHandler(this.GenerarButton_Click);
            // 
            // SalirButton
            // 
            this.SalirButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SalirButton.Location = new System.Drawing.Point(615, 3);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(60, 21);
            this.SalirButton.TabIndex = 9;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.SalirButton_Click);
            // 
            // ComprasYVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 278);
            this.Controls.Add(this.SplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComprasYVentas";
            this.Text = "Interfaz de Compras y Ventas";
            this.Load += new System.EventHandler(this.ConsultaVendedor_Load);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.PrincipalPanel.ResumeLayout(false);
            this.PrincipalPanel.PerformLayout();
            this.PiePanel.ResumeLayout(false);
            this.BotonesPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Panel PiePanel;
        private System.Windows.Forms.Panel BotonesPanel;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button GenerarButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label PeriodoLabel;
        private System.Windows.Forms.RadioButton VentasRadioButton;
        private System.Windows.Forms.RadioButton ComprasRadioButton;
        private System.Windows.Forms.DateTimePicker FechaDsdDTP;
        private System.Windows.Forms.DateTimePicker FechaHstDTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CUITLabel;
        private System.Windows.Forms.ComboBox CuitVendedorComboBox;
        private System.Windows.Forms.TextBox ResultadosTextBox;
        private System.Windows.Forms.Label label1;
    }
}