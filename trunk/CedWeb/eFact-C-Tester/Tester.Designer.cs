namespace eFact_C_Tester
{
    partial class Tester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tester));
            this.NumeroLoteLabel = new System.Windows.Forms.Label();
            this.NumeroLoteTextBox = new System.Windows.Forms.TextBox();
            this.ConsultaButton = new System.Windows.Forms.Button();
            this.PuntoVentaTextBox = new System.Windows.Forms.TextBox();
            this.PuntoVentaLabel = new System.Windows.Forms.Label();
            this.CuitTextBox = new System.Windows.Forms.TextBox();
            this.CuitLabel = new System.Windows.Forms.Label();
            this.EnviarButton = new System.Windows.Forms.Button();
            this.CuitCanalTextBox = new System.Windows.Forms.TextBox();
            this.CuitCanalLabel = new System.Windows.Forms.Label();
            this.GenerarNroLoteButton = new System.Windows.Forms.Button();
            this.NroComprobanteTextBox = new System.Windows.Forms.TextBox();
            this.NroComprobanteLabel = new System.Windows.Forms.Label();
            this.FechaEmisionLabel = new System.Windows.Forms.Label();
            this.FechaEmisionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FechaVtoLabel = new System.Windows.Forms.Label();
            this.FechaVtoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProxyDireccionLabel = new System.Windows.Forms.Label();
            this.ProxyDireccionTextBox = new System.Windows.Forms.TextBox();
            this.ProxyDominioLabel = new System.Windows.Forms.Label();
            this.ProxyDominioTextBox = new System.Windows.Forms.TextBox();
            this.ProxyClaveLabel = new System.Windows.Forms.Label();
            this.ProxyClaveTextBox = new System.Windows.Forms.TextBox();
            this.ProxyUsuarioLabel = new System.Windows.Forms.Label();
            this.ProxyUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ArmarLoteXMLButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumeroLoteLabel
            // 
            this.NumeroLoteLabel.AutoSize = true;
            this.NumeroLoteLabel.Location = new System.Drawing.Point(14, 98);
            this.NumeroLoteLabel.Name = "NumeroLoteLabel";
            this.NumeroLoteLabel.Size = new System.Drawing.Size(86, 13);
            this.NumeroLoteLabel.TabIndex = 0;
            this.NumeroLoteLabel.Text = "Número de Lote:";
            // 
            // NumeroLoteTextBox
            // 
            this.NumeroLoteTextBox.Location = new System.Drawing.Point(106, 98);
            this.NumeroLoteTextBox.Name = "NumeroLoteTextBox";
            this.NumeroLoteTextBox.Size = new System.Drawing.Size(126, 20);
            this.NumeroLoteTextBox.TabIndex = 1;
            // 
            // ConsultaButton
            // 
            this.ConsultaButton.Location = new System.Drawing.Point(12, 124);
            this.ConsultaButton.Name = "ConsultaButton";
            this.ConsultaButton.Size = new System.Drawing.Size(364, 22);
            this.ConsultaButton.TabIndex = 2;
            this.ConsultaButton.Text = "Consultar Lote";
            this.ConsultaButton.UseVisualStyleBackColor = true;
            this.ConsultaButton.Click += new System.EventHandler(this.ConsultaButton_Click);
            // 
            // PuntoVentaTextBox
            // 
            this.PuntoVentaTextBox.Location = new System.Drawing.Point(106, 72);
            this.PuntoVentaTextBox.Name = "PuntoVentaTextBox";
            this.PuntoVentaTextBox.Size = new System.Drawing.Size(126, 20);
            this.PuntoVentaTextBox.TabIndex = 4;
            // 
            // PuntoVentaLabel
            // 
            this.PuntoVentaLabel.AutoSize = true;
            this.PuntoVentaLabel.Location = new System.Drawing.Point(16, 75);
            this.PuntoVentaLabel.Name = "PuntoVentaLabel";
            this.PuntoVentaLabel.Size = new System.Drawing.Size(84, 13);
            this.PuntoVentaLabel.TabIndex = 3;
            this.PuntoVentaLabel.Text = "Punto de Venta:";
            // 
            // CuitTextBox
            // 
            this.CuitTextBox.Location = new System.Drawing.Point(106, 46);
            this.CuitTextBox.Name = "CuitTextBox";
            this.CuitTextBox.Size = new System.Drawing.Size(126, 20);
            this.CuitTextBox.TabIndex = 6;
            // 
            // CuitLabel
            // 
            this.CuitLabel.AutoSize = true;
            this.CuitLabel.Location = new System.Drawing.Point(72, 49);
            this.CuitLabel.Name = "CuitLabel";
            this.CuitLabel.Size = new System.Drawing.Size(28, 13);
            this.CuitLabel.TabIndex = 5;
            this.CuitLabel.Text = "Cuit:";
            // 
            // EnviarButton
            // 
            this.EnviarButton.Location = new System.Drawing.Point(12, 235);
            this.EnviarButton.Name = "EnviarButton";
            this.EnviarButton.Size = new System.Drawing.Size(364, 22);
            this.EnviarButton.TabIndex = 7;
            this.EnviarButton.Text = "Enviar Lote";
            this.EnviarButton.UseVisualStyleBackColor = true;
            this.EnviarButton.Click += new System.EventHandler(this.EnviarButton_Click);
            // 
            // CuitCanalTextBox
            // 
            this.CuitCanalTextBox.Enabled = false;
            this.CuitCanalTextBox.Location = new System.Drawing.Point(106, 20);
            this.CuitCanalTextBox.Name = "CuitCanalTextBox";
            this.CuitCanalTextBox.Size = new System.Drawing.Size(126, 20);
            this.CuitCanalTextBox.TabIndex = 8;
            // 
            // CuitCanalLabel
            // 
            this.CuitCanalLabel.AutoSize = true;
            this.CuitCanalLabel.Location = new System.Drawing.Point(42, 23);
            this.CuitCanalLabel.Name = "CuitCanalLabel";
            this.CuitCanalLabel.Size = new System.Drawing.Size(58, 13);
            this.CuitCanalLabel.TabIndex = 9;
            this.CuitCanalLabel.Text = "Cuit Canal:";
            // 
            // GenerarNroLoteButton
            // 
            this.GenerarNroLoteButton.Location = new System.Drawing.Point(238, 96);
            this.GenerarNroLoteButton.Name = "GenerarNroLoteButton";
            this.GenerarNroLoteButton.Size = new System.Drawing.Size(138, 22);
            this.GenerarNroLoteButton.TabIndex = 10;
            this.GenerarNroLoteButton.Text = "Generar nuevo Nro.Lote";
            this.GenerarNroLoteButton.UseVisualStyleBackColor = true;
            this.GenerarNroLoteButton.Click += new System.EventHandler(this.GenerarNroLoteButton_Click);
            // 
            // NroComprobanteTextBox
            // 
            this.NroComprobanteTextBox.Location = new System.Drawing.Point(106, 152);
            this.NroComprobanteTextBox.Name = "NroComprobanteTextBox";
            this.NroComprobanteTextBox.Size = new System.Drawing.Size(126, 20);
            this.NroComprobanteTextBox.TabIndex = 12;
            // 
            // NroComprobanteLabel
            // 
            this.NroComprobanteLabel.AutoSize = true;
            this.NroComprobanteLabel.Location = new System.Drawing.Point(7, 155);
            this.NroComprobanteLabel.Name = "NroComprobanteLabel";
            this.NroComprobanteLabel.Size = new System.Drawing.Size(93, 13);
            this.NroComprobanteLabel.TabIndex = 11;
            this.NroComprobanteLabel.Text = "Nro.Comprobante:";
            // 
            // FechaEmisionLabel
            // 
            this.FechaEmisionLabel.AutoSize = true;
            this.FechaEmisionLabel.Location = new System.Drawing.Point(21, 181);
            this.FechaEmisionLabel.Name = "FechaEmisionLabel";
            this.FechaEmisionLabel.Size = new System.Drawing.Size(79, 13);
            this.FechaEmisionLabel.TabIndex = 13;
            this.FechaEmisionLabel.Text = "Fecha Emisión:";
            // 
            // FechaEmisionDateTimePicker
            // 
            this.FechaEmisionDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaEmisionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaEmisionDateTimePicker.Location = new System.Drawing.Point(106, 178);
            this.FechaEmisionDateTimePicker.Name = "FechaEmisionDateTimePicker";
            this.FechaEmisionDateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.FechaEmisionDateTimePicker.TabIndex = 15;
            // 
            // FechaVtoLabel
            // 
            this.FechaVtoLabel.AutoSize = true;
            this.FechaVtoLabel.Location = new System.Drawing.Point(38, 207);
            this.FechaVtoLabel.Name = "FechaVtoLabel";
            this.FechaVtoLabel.Size = new System.Drawing.Size(62, 13);
            this.FechaVtoLabel.TabIndex = 16;
            this.FechaVtoLabel.Text = "Fecha Vto.:";
            // 
            // FechaVtoDateTimePicker
            // 
            this.FechaVtoDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechaVtoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaVtoDateTimePicker.Location = new System.Drawing.Point(106, 204);
            this.FechaVtoDateTimePicker.Name = "FechaVtoDateTimePicker";
            this.FechaVtoDateTimePicker.Size = new System.Drawing.Size(126, 20);
            this.FechaVtoDateTimePicker.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ProxyDireccionLabel);
            this.panel1.Controls.Add(this.ProxyDireccionTextBox);
            this.panel1.Controls.Add(this.ProxyDominioLabel);
            this.panel1.Controls.Add(this.ProxyDominioTextBox);
            this.panel1.Controls.Add(this.ProxyClaveLabel);
            this.panel1.Controls.Add(this.ProxyClaveTextBox);
            this.panel1.Controls.Add(this.ProxyUsuarioLabel);
            this.panel1.Controls.Add(this.ProxyUsuarioTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 143);
            this.panel1.TabIndex = 18;
            // 
            // ProxyDireccionLabel
            // 
            this.ProxyDireccionLabel.AutoSize = true;
            this.ProxyDireccionLabel.Location = new System.Drawing.Point(4, 35);
            this.ProxyDireccionLabel.Name = "ProxyDireccionLabel";
            this.ProxyDireccionLabel.Size = new System.Drawing.Size(55, 13);
            this.ProxyDireccionLabel.TabIndex = 7;
            this.ProxyDireccionLabel.Text = "Dirección:";
            // 
            // ProxyDireccionTextBox
            // 
            this.ProxyDireccionTextBox.Location = new System.Drawing.Point(65, 32);
            this.ProxyDireccionTextBox.Name = "ProxyDireccionTextBox";
            this.ProxyDireccionTextBox.Size = new System.Drawing.Size(287, 20);
            this.ProxyDireccionTextBox.TabIndex = 6;
            // 
            // ProxyDominioLabel
            // 
            this.ProxyDominioLabel.AutoSize = true;
            this.ProxyDominioLabel.Location = new System.Drawing.Point(11, 113);
            this.ProxyDominioLabel.Name = "ProxyDominioLabel";
            this.ProxyDominioLabel.Size = new System.Drawing.Size(48, 13);
            this.ProxyDominioLabel.TabIndex = 5;
            this.ProxyDominioLabel.Text = "Dominio:";
            // 
            // ProxyDominioTextBox
            // 
            this.ProxyDominioTextBox.Location = new System.Drawing.Point(65, 110);
            this.ProxyDominioTextBox.Name = "ProxyDominioTextBox";
            this.ProxyDominioTextBox.Size = new System.Drawing.Size(110, 20);
            this.ProxyDominioTextBox.TabIndex = 4;
            // 
            // ProxyClaveLabel
            // 
            this.ProxyClaveLabel.AutoSize = true;
            this.ProxyClaveLabel.Location = new System.Drawing.Point(22, 87);
            this.ProxyClaveLabel.Name = "ProxyClaveLabel";
            this.ProxyClaveLabel.Size = new System.Drawing.Size(37, 13);
            this.ProxyClaveLabel.TabIndex = 3;
            this.ProxyClaveLabel.Text = "Clave:";
            // 
            // ProxyClaveTextBox
            // 
            this.ProxyClaveTextBox.Location = new System.Drawing.Point(65, 84);
            this.ProxyClaveTextBox.Name = "ProxyClaveTextBox";
            this.ProxyClaveTextBox.Size = new System.Drawing.Size(110, 20);
            this.ProxyClaveTextBox.TabIndex = 2;
            // 
            // ProxyUsuarioLabel
            // 
            this.ProxyUsuarioLabel.AutoSize = true;
            this.ProxyUsuarioLabel.Location = new System.Drawing.Point(13, 61);
            this.ProxyUsuarioLabel.Name = "ProxyUsuarioLabel";
            this.ProxyUsuarioLabel.Size = new System.Drawing.Size(46, 13);
            this.ProxyUsuarioLabel.TabIndex = 1;
            this.ProxyUsuarioLabel.Text = "Usuario:";
            // 
            // ProxyUsuarioTextBox
            // 
            this.ProxyUsuarioTextBox.Location = new System.Drawing.Point(65, 58);
            this.ProxyUsuarioTextBox.Name = "ProxyUsuarioTextBox";
            this.ProxyUsuarioTextBox.Size = new System.Drawing.Size(110, 20);
            this.ProxyUsuarioTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Proxy";
            // 
            // ArmarLoteXMLButton
            // 
            this.ArmarLoteXMLButton.Location = new System.Drawing.Point(12, 263);
            this.ArmarLoteXMLButton.Name = "ArmarLoteXMLButton";
            this.ArmarLoteXMLButton.Size = new System.Drawing.Size(364, 22);
            this.ArmarLoteXMLButton.TabIndex = 19;
            this.ArmarLoteXMLButton.Text = "Armar Lote XML";
            this.ArmarLoteXMLButton.UseVisualStyleBackColor = true;
            this.ArmarLoteXMLButton.Click += new System.EventHandler(this.ArmarLoteXMLButton_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 300);
            this.Controls.Add(this.ArmarLoteXMLButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FechaVtoDateTimePicker);
            this.Controls.Add(this.FechaVtoLabel);
            this.Controls.Add(this.FechaEmisionDateTimePicker);
            this.Controls.Add(this.FechaEmisionLabel);
            this.Controls.Add(this.NroComprobanteTextBox);
            this.Controls.Add(this.NroComprobanteLabel);
            this.Controls.Add(this.GenerarNroLoteButton);
            this.Controls.Add(this.CuitCanalLabel);
            this.Controls.Add(this.CuitCanalTextBox);
            this.Controls.Add(this.EnviarButton);
            this.Controls.Add(this.CuitTextBox);
            this.Controls.Add(this.CuitLabel);
            this.Controls.Add(this.PuntoVentaTextBox);
            this.Controls.Add(this.PuntoVentaLabel);
            this.Controls.Add(this.ConsultaButton);
            this.Controls.Add(this.NumeroLoteTextBox);
            this.Controls.Add(this.NumeroLoteLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tester";
            this.Text = "Tester de eFact-C";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumeroLoteLabel;
        private System.Windows.Forms.TextBox NumeroLoteTextBox;
        private System.Windows.Forms.Button ConsultaButton;
        private System.Windows.Forms.TextBox PuntoVentaTextBox;
        private System.Windows.Forms.Label PuntoVentaLabel;
        private System.Windows.Forms.TextBox CuitTextBox;
        private System.Windows.Forms.Label CuitLabel;
        private System.Windows.Forms.Button EnviarButton;
        private System.Windows.Forms.TextBox CuitCanalTextBox;
        private System.Windows.Forms.Label CuitCanalLabel;
        private System.Windows.Forms.Button GenerarNroLoteButton;
        private System.Windows.Forms.TextBox NroComprobanteTextBox;
        private System.Windows.Forms.Label NroComprobanteLabel;
        private System.Windows.Forms.Label FechaEmisionLabel;
        private System.Windows.Forms.DateTimePicker FechaEmisionDateTimePicker;
        private System.Windows.Forms.Label FechaVtoLabel;
        private System.Windows.Forms.DateTimePicker FechaVtoDateTimePicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ProxyUsuarioLabel;
        private System.Windows.Forms.TextBox ProxyUsuarioTextBox;
        private System.Windows.Forms.Label ProxyClaveLabel;
        private System.Windows.Forms.TextBox ProxyClaveTextBox;
        private System.Windows.Forms.Label ProxyDireccionLabel;
        private System.Windows.Forms.TextBox ProxyDireccionTextBox;
        private System.Windows.Forms.Label ProxyDominioLabel;
        private System.Windows.Forms.TextBox ProxyDominioTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ArmarLoteXMLButton;
    }
}

