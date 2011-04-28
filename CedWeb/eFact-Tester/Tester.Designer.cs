namespace eFact_Tester
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ConsultarURLTabPage = new System.Windows.Forms.TabPage();
            this.GoogleButton = new System.Windows.Forms.Button();
            this.URLLabel = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.ConsultarURLButton = new System.Windows.Forms.Button();
            this.ProxyTabPage = new System.Windows.Forms.TabPage();
            this.ProxyAutoRadioButton = new System.Windows.Forms.RadioButton();
            this.ProxyManualRadioButton = new System.Windows.Forms.RadioButton();
            this.ProxyAutoPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.wpDefaultTextBox = new System.Windows.Forms.TextBox();
            this.LeerProxyButton = new System.Windows.Forms.Button();
            this.ProxyManualPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProxyDireccionLabel = new System.Windows.Forms.Label();
            this.ProxyDireccionTextBox = new System.Windows.Forms.TextBox();
            this.ProxyDominioLabel = new System.Windows.Forms.Label();
            this.ProxyDominioTextBox = new System.Windows.Forms.TextBox();
            this.ProxyClaveLabel = new System.Windows.Forms.Label();
            this.ProxyClaveTextBox = new System.Windows.Forms.TextBox();
            this.ProxyUsuarioLabel = new System.Windows.Forms.Label();
            this.ProxyUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.CertificadoTabPage = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CertificadoNroSerieTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ConsultarLoteTabPage = new System.Windows.Forms.TabPage();
            this.ValidarComunicacionButton = new System.Windows.Forms.Button();
            this.CuitCanalLabel = new System.Windows.Forms.Label();
            this.CuitCanalTextBox = new System.Windows.Forms.TextBox();
            this.CuitTextBox = new System.Windows.Forms.TextBox();
            this.CuitLabel = new System.Windows.Forms.Label();
            this.PuntoVentaTextBox = new System.Windows.Forms.TextBox();
            this.PuntoVentaLabel = new System.Windows.Forms.Label();
            this.NumeroLoteTextBox = new System.Windows.Forms.TextBox();
            this.NumeroLoteLabel = new System.Windows.Forms.Label();
            this.ConsultarLoteButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.ConsultarURLTabPage.SuspendLayout();
            this.ProxyTabPage.SuspendLayout();
            this.ProxyAutoPanel.SuspendLayout();
            this.ProxyManualPanel.SuspendLayout();
            this.CertificadoTabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ConsultarLoteTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SplitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 462);
            this.panel1.TabIndex = 0;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.WebBrowser);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.TabControl);
            this.SplitContainer.Size = new System.Drawing.Size(784, 462);
            this.SplitContainer.SplitterDistance = 250;
            this.SplitContainer.TabIndex = 1;
            // 
            // WebBrowser
            // 
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.Location = new System.Drawing.Point(0, 0);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(784, 250);
            this.WebBrowser.TabIndex = 1;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.ConsultarURLTabPage);
            this.TabControl.Controls.Add(this.ProxyTabPage);
            this.TabControl.Controls.Add(this.CertificadoTabPage);
            this.TabControl.Controls.Add(this.ConsultarLoteTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 208);
            this.TabControl.TabIndex = 21;
            // 
            // ConsultarURLTabPage
            // 
            this.ConsultarURLTabPage.Controls.Add(this.GoogleButton);
            this.ConsultarURLTabPage.Controls.Add(this.URLLabel);
            this.ConsultarURLTabPage.Controls.Add(this.URLTextBox);
            this.ConsultarURLTabPage.Controls.Add(this.ConsultarURLButton);
            this.ConsultarURLTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConsultarURLTabPage.Name = "ConsultarURLTabPage";
            this.ConsultarURLTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConsultarURLTabPage.Size = new System.Drawing.Size(776, 182);
            this.ConsultarURLTabPage.TabIndex = 0;
            this.ConsultarURLTabPage.Text = "Consultar URL";
            this.ConsultarURLTabPage.UseVisualStyleBackColor = true;
            // 
            // GoogleButton
            // 
            this.GoogleButton.Location = new System.Drawing.Point(608, 32);
            this.GoogleButton.Name = "GoogleButton";
            this.GoogleButton.Size = new System.Drawing.Size(146, 23);
            this.GoogleButton.TabIndex = 23;
            this.GoogleButton.Text = "Google URL";
            this.GoogleButton.UseVisualStyleBackColor = true;
            this.GoogleButton.Click += new System.EventHandler(this.GoogleButton_Click);
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(10, 12);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(32, 13);
            this.URLLabel.TabIndex = 22;
            this.URLLabel.Text = "URL:";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(48, 9);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(706, 20);
            this.URLTextBox.TabIndex = 21;
            // 
            // ConsultarURLButton
            // 
            this.ConsultarURLButton.Location = new System.Drawing.Point(10, 32);
            this.ConsultarURLButton.Name = "ConsultarURLButton";
            this.ConsultarURLButton.Size = new System.Drawing.Size(592, 23);
            this.ConsultarURLButton.TabIndex = 20;
            this.ConsultarURLButton.Text = "Consultar URL";
            this.ConsultarURLButton.UseVisualStyleBackColor = true;
            this.ConsultarURLButton.Click += new System.EventHandler(this.ConsultarURLButton_Click);
            // 
            // ProxyTabPage
            // 
            this.ProxyTabPage.Controls.Add(this.ProxyAutoRadioButton);
            this.ProxyTabPage.Controls.Add(this.ProxyManualRadioButton);
            this.ProxyTabPage.Controls.Add(this.ProxyAutoPanel);
            this.ProxyTabPage.Controls.Add(this.ProxyManualPanel);
            this.ProxyTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProxyTabPage.Name = "ProxyTabPage";
            this.ProxyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProxyTabPage.Size = new System.Drawing.Size(776, 182);
            this.ProxyTabPage.TabIndex = 1;
            this.ProxyTabPage.Text = "Proxy";
            this.ProxyTabPage.UseVisualStyleBackColor = true;
            // 
            // ProxyAutoRadioButton
            // 
            this.ProxyAutoRadioButton.AutoSize = true;
            this.ProxyAutoRadioButton.Location = new System.Drawing.Point(388, 91);
            this.ProxyAutoRadioButton.Name = "ProxyAutoRadioButton";
            this.ProxyAutoRadioButton.Size = new System.Drawing.Size(78, 17);
            this.ProxyAutoRadioButton.TabIndex = 22;
            this.ProxyAutoRadioButton.Text = "Automático";
            this.ProxyAutoRadioButton.UseVisualStyleBackColor = true;
            this.ProxyAutoRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ProxyManualRadioButton
            // 
            this.ProxyManualRadioButton.AutoSize = true;
            this.ProxyManualRadioButton.Checked = true;
            this.ProxyManualRadioButton.Location = new System.Drawing.Point(388, 65);
            this.ProxyManualRadioButton.Name = "ProxyManualRadioButton";
            this.ProxyManualRadioButton.Size = new System.Drawing.Size(60, 17);
            this.ProxyManualRadioButton.TabIndex = 21;
            this.ProxyManualRadioButton.TabStop = true;
            this.ProxyManualRadioButton.Text = "Manual";
            this.ProxyManualRadioButton.UseVisualStyleBackColor = true;
            this.ProxyManualRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ProxyAutoPanel
            // 
            this.ProxyAutoPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.ProxyAutoPanel.Controls.Add(this.label4);
            this.ProxyAutoPanel.Controls.Add(this.wpDefaultTextBox);
            this.ProxyAutoPanel.Controls.Add(this.LeerProxyButton);
            this.ProxyAutoPanel.Location = new System.Drawing.Point(494, 8);
            this.ProxyAutoPanel.Name = "ProxyAutoPanel";
            this.ProxyAutoPanel.Size = new System.Drawing.Size(274, 166);
            this.ProxyAutoPanel.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Proxy Automático";
            // 
            // wpDefaultTextBox
            // 
            this.wpDefaultTextBox.AcceptsReturn = true;
            this.wpDefaultTextBox.Location = new System.Drawing.Point(6, 32);
            this.wpDefaultTextBox.Multiline = true;
            this.wpDefaultTextBox.Name = "wpDefaultTextBox";
            this.wpDefaultTextBox.Size = new System.Drawing.Size(261, 94);
            this.wpDefaultTextBox.TabIndex = 12;
            // 
            // LeerProxyButton
            // 
            this.LeerProxyButton.Location = new System.Drawing.Point(6, 137);
            this.LeerProxyButton.Name = "LeerProxyButton";
            this.LeerProxyButton.Size = new System.Drawing.Size(261, 23);
            this.LeerProxyButton.TabIndex = 10;
            this.LeerProxyButton.Text = "Leer Proxy (Default)";
            this.LeerProxyButton.UseVisualStyleBackColor = true;
            this.LeerProxyButton.Click += new System.EventHandler(this.LeerProxyButton_Click);
            // 
            // ProxyManualPanel
            // 
            this.ProxyManualPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.ProxyManualPanel.Controls.Add(this.label1);
            this.ProxyManualPanel.Controls.Add(this.ProxyDireccionLabel);
            this.ProxyManualPanel.Controls.Add(this.ProxyDireccionTextBox);
            this.ProxyManualPanel.Controls.Add(this.ProxyDominioLabel);
            this.ProxyManualPanel.Controls.Add(this.ProxyDominioTextBox);
            this.ProxyManualPanel.Controls.Add(this.ProxyClaveLabel);
            this.ProxyManualPanel.Controls.Add(this.ProxyClaveTextBox);
            this.ProxyManualPanel.Controls.Add(this.ProxyUsuarioLabel);
            this.ProxyManualPanel.Controls.Add(this.ProxyUsuarioTextBox);
            this.ProxyManualPanel.Location = new System.Drawing.Point(7, 8);
            this.ProxyManualPanel.Name = "ProxyManualPanel";
            this.ProxyManualPanel.Size = new System.Drawing.Size(362, 166);
            this.ProxyManualPanel.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Proxy Manual";
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
            // CertificadoTabPage
            // 
            this.CertificadoTabPage.Controls.Add(this.panel3);
            this.CertificadoTabPage.Location = new System.Drawing.Point(4, 22);
            this.CertificadoTabPage.Name = "CertificadoTabPage";
            this.CertificadoTabPage.Size = new System.Drawing.Size(776, 182);
            this.CertificadoTabPage.TabIndex = 3;
            this.CertificadoTabPage.Text = "Certificado";
            this.CertificadoTabPage.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Cornsilk;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.CertificadoNroSerieTextBox);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(7, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 166);
            this.panel3.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Certificado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nro.Serie:";
            // 
            // CertificadoNroSerieTextBox
            // 
            this.CertificadoNroSerieTextBox.Location = new System.Drawing.Point(65, 32);
            this.CertificadoNroSerieTextBox.Name = "CertificadoNroSerieTextBox";
            this.CertificadoNroSerieTextBox.Size = new System.Drawing.Size(287, 20);
            this.CertificadoNroSerieTextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "( Se utiliza el cetificado del usuario actual. )";
            // 
            // ConsultarLoteTabPage
            // 
            this.ConsultarLoteTabPage.Controls.Add(this.ValidarComunicacionButton);
            this.ConsultarLoteTabPage.Controls.Add(this.CuitCanalLabel);
            this.ConsultarLoteTabPage.Controls.Add(this.CuitCanalTextBox);
            this.ConsultarLoteTabPage.Controls.Add(this.CuitTextBox);
            this.ConsultarLoteTabPage.Controls.Add(this.CuitLabel);
            this.ConsultarLoteTabPage.Controls.Add(this.PuntoVentaTextBox);
            this.ConsultarLoteTabPage.Controls.Add(this.PuntoVentaLabel);
            this.ConsultarLoteTabPage.Controls.Add(this.NumeroLoteTextBox);
            this.ConsultarLoteTabPage.Controls.Add(this.NumeroLoteLabel);
            this.ConsultarLoteTabPage.Controls.Add(this.ConsultarLoteButton);
            this.ConsultarLoteTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConsultarLoteTabPage.Name = "ConsultarLoteTabPage";
            this.ConsultarLoteTabPage.Size = new System.Drawing.Size(776, 182);
            this.ConsultarLoteTabPage.TabIndex = 2;
            this.ConsultarLoteTabPage.Text = "Consultar Lote";
            this.ConsultarLoteTabPage.UseVisualStyleBackColor = true;
            // 
            // ValidarComunicacionButton
            // 
            this.ValidarComunicacionButton.Location = new System.Drawing.Point(8, 7);
            this.ValidarComunicacionButton.Name = "ValidarComunicacionButton";
            this.ValidarComunicacionButton.Size = new System.Drawing.Size(215, 23);
            this.ValidarComunicacionButton.TabIndex = 27;
            this.ValidarComunicacionButton.Text = "1ro. Validar Comunicación";
            this.ValidarComunicacionButton.UseVisualStyleBackColor = true;
            this.ValidarComunicacionButton.Click += new System.EventHandler(this.ValidarComunicacionButton_Click);
            // 
            // CuitCanalLabel
            // 
            this.CuitCanalLabel.AutoSize = true;
            this.CuitCanalLabel.Location = new System.Drawing.Point(33, 51);
            this.CuitCanalLabel.Name = "CuitCanalLabel";
            this.CuitCanalLabel.Size = new System.Drawing.Size(58, 13);
            this.CuitCanalLabel.TabIndex = 26;
            this.CuitCanalLabel.Text = "Cuit Canal:";
            // 
            // CuitCanalTextBox
            // 
            this.CuitCanalTextBox.Enabled = false;
            this.CuitCanalTextBox.Location = new System.Drawing.Point(97, 48);
            this.CuitCanalTextBox.Name = "CuitCanalTextBox";
            this.CuitCanalTextBox.Size = new System.Drawing.Size(126, 20);
            this.CuitCanalTextBox.TabIndex = 25;
            // 
            // CuitTextBox
            // 
            this.CuitTextBox.Location = new System.Drawing.Point(97, 74);
            this.CuitTextBox.Name = "CuitTextBox";
            this.CuitTextBox.Size = new System.Drawing.Size(126, 20);
            this.CuitTextBox.TabIndex = 24;
            // 
            // CuitLabel
            // 
            this.CuitLabel.AutoSize = true;
            this.CuitLabel.Location = new System.Drawing.Point(63, 77);
            this.CuitLabel.Name = "CuitLabel";
            this.CuitLabel.Size = new System.Drawing.Size(28, 13);
            this.CuitLabel.TabIndex = 23;
            this.CuitLabel.Text = "Cuit:";
            // 
            // PuntoVentaTextBox
            // 
            this.PuntoVentaTextBox.Location = new System.Drawing.Point(97, 100);
            this.PuntoVentaTextBox.Name = "PuntoVentaTextBox";
            this.PuntoVentaTextBox.Size = new System.Drawing.Size(126, 20);
            this.PuntoVentaTextBox.TabIndex = 22;
            // 
            // PuntoVentaLabel
            // 
            this.PuntoVentaLabel.AutoSize = true;
            this.PuntoVentaLabel.Location = new System.Drawing.Point(7, 103);
            this.PuntoVentaLabel.Name = "PuntoVentaLabel";
            this.PuntoVentaLabel.Size = new System.Drawing.Size(84, 13);
            this.PuntoVentaLabel.TabIndex = 21;
            this.PuntoVentaLabel.Text = "Punto de Venta:";
            // 
            // NumeroLoteTextBox
            // 
            this.NumeroLoteTextBox.Location = new System.Drawing.Point(97, 126);
            this.NumeroLoteTextBox.Name = "NumeroLoteTextBox";
            this.NumeroLoteTextBox.Size = new System.Drawing.Size(126, 20);
            this.NumeroLoteTextBox.TabIndex = 20;
            // 
            // NumeroLoteLabel
            // 
            this.NumeroLoteLabel.AutoSize = true;
            this.NumeroLoteLabel.Location = new System.Drawing.Point(5, 126);
            this.NumeroLoteLabel.Name = "NumeroLoteLabel";
            this.NumeroLoteLabel.Size = new System.Drawing.Size(86, 13);
            this.NumeroLoteLabel.TabIndex = 19;
            this.NumeroLoteLabel.Text = "Número de Lote:";
            // 
            // ConsultarLoteButton
            // 
            this.ConsultarLoteButton.Location = new System.Drawing.Point(8, 152);
            this.ConsultarLoteButton.Name = "ConsultarLoteButton";
            this.ConsultarLoteButton.Size = new System.Drawing.Size(215, 23);
            this.ConsultarLoteButton.TabIndex = 18;
            this.ConsultarLoteButton.Text = "2do. Consultar Lote";
            this.ConsultarLoteButton.UseVisualStyleBackColor = true;
            this.ConsultarLoteButton.Click += new System.EventHandler(this.ConsultarLoteButton_Click);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tester";
            this.Text = "Tester";
            this.panel1.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.ConsultarURLTabPage.ResumeLayout(false);
            this.ConsultarURLTabPage.PerformLayout();
            this.ProxyTabPage.ResumeLayout(false);
            this.ProxyTabPage.PerformLayout();
            this.ProxyAutoPanel.ResumeLayout(false);
            this.ProxyAutoPanel.PerformLayout();
            this.ProxyManualPanel.ResumeLayout(false);
            this.ProxyManualPanel.PerformLayout();
            this.CertificadoTabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ConsultarLoteTabPage.ResumeLayout(false);
            this.ConsultarLoteTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage ConsultarURLTabPage;
        private System.Windows.Forms.TabPage ProxyTabPage;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button ConsultarURLButton;
        private System.Windows.Forms.Panel ProxyManualPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProxyDireccionLabel;
        private System.Windows.Forms.TextBox ProxyDireccionTextBox;
        private System.Windows.Forms.Label ProxyDominioLabel;
        private System.Windows.Forms.TextBox ProxyDominioTextBox;
        private System.Windows.Forms.Label ProxyClaveLabel;
        private System.Windows.Forms.TextBox ProxyClaveTextBox;
        private System.Windows.Forms.Label ProxyUsuarioLabel;
        private System.Windows.Forms.TextBox ProxyUsuarioTextBox;
        private System.Windows.Forms.TabPage ConsultarLoteTabPage;
        private System.Windows.Forms.TabPage CertificadoTabPage;
        private System.Windows.Forms.Label CuitCanalLabel;
        private System.Windows.Forms.TextBox CuitCanalTextBox;
        private System.Windows.Forms.TextBox CuitTextBox;
        private System.Windows.Forms.Label CuitLabel;
        private System.Windows.Forms.TextBox PuntoVentaTextBox;
        private System.Windows.Forms.Label PuntoVentaLabel;
        private System.Windows.Forms.TextBox NumeroLoteTextBox;
        private System.Windows.Forms.Label NumeroLoteLabel;
        private System.Windows.Forms.Button ConsultarLoteButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CertificadoNroSerieTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ValidarComunicacionButton;
        private System.Windows.Forms.Button GoogleButton;
        private System.Windows.Forms.Panel ProxyAutoPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox wpDefaultTextBox;
        private System.Windows.Forms.Button LeerProxyButton;
        private System.Windows.Forms.RadioButton ProxyAutoRadioButton;
        private System.Windows.Forms.RadioButton ProxyManualRadioButton;
    }
}

