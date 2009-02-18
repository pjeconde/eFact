namespace FEA
{
	partial class PrincipalForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
			this.ticketButton = new System.Windows.Forms.Button();
			this.tokenTextBox = new System.Windows.Forms.TextBox();
			this.signTextBox = new System.Windows.Forms.TextBox();
			this.tokenLabel = new System.Windows.Forms.Label();
			this.signLabel = new System.Windows.Forms.Label();
			this.cuitTextBox = new System.Windows.Forms.TextBox();
			this.cuitLabel = new System.Windows.Forms.Label();
			this.ultNroButton = new System.Windows.Forms.Button();
			this.ultNroRqstTextBox = new System.Windows.Forms.TextBox();
			this.cantMaxDetButton = new System.Windows.Forms.Button();
			this.ultCompAutButton = new System.Windows.Forms.Button();
			this.cantMaxDetTextBox = new System.Windows.Forms.TextBox();
			this.ultCompAutTextBox = new System.Windows.Forms.TextBox();
			this.verificarCaeButton = new System.Windows.Forms.Button();
			this.verificarCaeTextBox = new System.Windows.Forms.TextBox();
			this.nuevoComprobanteButton = new System.Windows.Forms.Button();
			this.ComprobantesDataGridView = new System.Windows.Forms.DataGridView();
			this.fechaImpactoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idTransaccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.puntoVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.caeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descrCodigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipoDocDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descrTipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nrodocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prestaservDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.fechacbteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaservdesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaservhastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechavencpagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.impnetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.impopexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imptotconcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imptotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imptoliqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imptoliqrniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resultadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.motivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mensajeErrorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.comprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.PrincipalToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.xmlIBKButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ComprobantesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comprobanteBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ticketButton
			// 
			this.ticketButton.Location = new System.Drawing.Point(572, 133);
			this.ticketButton.Name = "ticketButton";
			this.ticketButton.Size = new System.Drawing.Size(145, 76);
			this.ticketButton.TabIndex = 0;
			this.ticketButton.Text = "Obtener Ticket";
			this.ticketButton.UseVisualStyleBackColor = true;
			this.ticketButton.Visible = false;
			this.ticketButton.Click += new System.EventHandler(this.ticketButton_Click);
			// 
			// tokenTextBox
			// 
			this.tokenTextBox.Enabled = false;
			this.tokenTextBox.Location = new System.Drawing.Point(767, 136);
			this.tokenTextBox.Multiline = true;
			this.tokenTextBox.Name = "tokenTextBox";
			this.tokenTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tokenTextBox.Size = new System.Drawing.Size(345, 20);
			this.tokenTextBox.TabIndex = 1;
			this.tokenTextBox.Visible = false;
			// 
			// signTextBox
			// 
			this.signTextBox.Enabled = false;
			this.signTextBox.Location = new System.Drawing.Point(767, 163);
			this.signTextBox.Multiline = true;
			this.signTextBox.Name = "signTextBox";
			this.signTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.signTextBox.Size = new System.Drawing.Size(345, 20);
			this.signTextBox.TabIndex = 2;
			this.signTextBox.Visible = false;
			// 
			// tokenLabel
			// 
			this.tokenLabel.AutoSize = true;
			this.tokenLabel.Location = new System.Drawing.Point(569, 255);
			this.tokenLabel.Name = "tokenLabel";
			this.tokenLabel.Size = new System.Drawing.Size(38, 13);
			this.tokenLabel.TabIndex = 3;
			this.tokenLabel.Text = "Token";
			this.tokenLabel.Visible = false;
			// 
			// signLabel
			// 
			this.signLabel.AutoSize = true;
			this.signLabel.Location = new System.Drawing.Point(633, 255);
			this.signLabel.Name = "signLabel";
			this.signLabel.Size = new System.Drawing.Size(28, 13);
			this.signLabel.TabIndex = 4;
			this.signLabel.Text = "Sign";
			this.signLabel.Visible = false;
			// 
			// cuitTextBox
			// 
			this.cuitTextBox.Enabled = false;
			this.cuitTextBox.Location = new System.Drawing.Point(767, 189);
			this.cuitTextBox.Name = "cuitTextBox";
			this.cuitTextBox.Size = new System.Drawing.Size(345, 20);
			this.cuitTextBox.TabIndex = 5;
			this.cuitTextBox.Visible = false;
			// 
			// cuitLabel
			// 
			this.cuitLabel.AutoSize = true;
			this.cuitLabel.Location = new System.Drawing.Point(685, 255);
			this.cuitLabel.Name = "cuitLabel";
			this.cuitLabel.Size = new System.Drawing.Size(32, 13);
			this.cuitLabel.TabIndex = 6;
			this.cuitLabel.Text = "CUIT";
			this.cuitLabel.Visible = false;
			// 
			// ultNroButton
			// 
			this.ultNroButton.Location = new System.Drawing.Point(572, 12);
			this.ultNroButton.Name = "ultNroButton";
			this.ultNroButton.Size = new System.Drawing.Size(189, 23);
			this.ultNroButton.TabIndex = 7;
			this.ultNroButton.Text = "Obtener último nro transacción";
			this.ultNroButton.UseVisualStyleBackColor = true;
			this.ultNroButton.Visible = false;
			this.ultNroButton.Click += new System.EventHandler(this.ultNroButton_Click);
			// 
			// ultNroRqstTextBox
			// 
			this.ultNroRqstTextBox.Location = new System.Drawing.Point(767, 15);
			this.ultNroRqstTextBox.Name = "ultNroRqstTextBox";
			this.ultNroRqstTextBox.Size = new System.Drawing.Size(345, 20);
			this.ultNroRqstTextBox.TabIndex = 8;
			this.ultNroRqstTextBox.Visible = false;
			// 
			// cantMaxDetButton
			// 
			this.cantMaxDetButton.Location = new System.Drawing.Point(571, 41);
			this.cantMaxDetButton.Name = "cantMaxDetButton";
			this.cantMaxDetButton.Size = new System.Drawing.Size(190, 43);
			this.cantMaxDetButton.TabIndex = 9;
			this.cantMaxDetButton.Text = "Obtener cantidad máxima de registros de detalle";
			this.cantMaxDetButton.UseVisualStyleBackColor = true;
			this.cantMaxDetButton.Visible = false;
			this.cantMaxDetButton.Click += new System.EventHandler(this.cantMaxDetButton_Click);
			// 
			// ultCompAutButton
			// 
			this.ultCompAutButton.Location = new System.Drawing.Point(571, 90);
			this.ultCompAutButton.Name = "ultCompAutButton";
			this.ultCompAutButton.Size = new System.Drawing.Size(189, 37);
			this.ultCompAutButton.TabIndex = 10;
			this.ultCompAutButton.Text = "Obtener último comprobante autorizado";
			this.ultCompAutButton.UseVisualStyleBackColor = true;
			this.ultCompAutButton.Visible = false;
			this.ultCompAutButton.Click += new System.EventHandler(this.ultCompAutButton_Click);
			// 
			// cantMaxDetTextBox
			// 
			this.cantMaxDetTextBox.Location = new System.Drawing.Point(767, 53);
			this.cantMaxDetTextBox.Name = "cantMaxDetTextBox";
			this.cantMaxDetTextBox.Size = new System.Drawing.Size(345, 20);
			this.cantMaxDetTextBox.TabIndex = 12;
			this.cantMaxDetTextBox.Visible = false;
			// 
			// ultCompAutTextBox
			// 
			this.ultCompAutTextBox.Location = new System.Drawing.Point(767, 99);
			this.ultCompAutTextBox.Name = "ultCompAutTextBox";
			this.ultCompAutTextBox.Size = new System.Drawing.Size(345, 20);
			this.ultCompAutTextBox.TabIndex = 13;
			this.ultCompAutTextBox.Visible = false;
			// 
			// verificarCaeButton
			// 
			this.verificarCaeButton.Location = new System.Drawing.Point(571, 215);
			this.verificarCaeButton.Name = "verificarCaeButton";
			this.verificarCaeButton.Size = new System.Drawing.Size(189, 37);
			this.verificarCaeButton.TabIndex = 19;
			this.verificarCaeButton.Text = "Verificar CAE";
			this.verificarCaeButton.UseVisualStyleBackColor = true;
			this.verificarCaeButton.Visible = false;
			this.verificarCaeButton.Click += new System.EventHandler(this.verificarCaeButton_Click);
			// 
			// verificarCaeTextBox
			// 
			this.verificarCaeTextBox.Location = new System.Drawing.Point(766, 224);
			this.verificarCaeTextBox.Name = "verificarCaeTextBox";
			this.verificarCaeTextBox.Size = new System.Drawing.Size(151, 20);
			this.verificarCaeTextBox.TabIndex = 20;
			this.verificarCaeTextBox.Visible = false;
			// 
			// nuevoComprobanteButton
			// 
			this.nuevoComprobanteButton.Location = new System.Drawing.Point(14, 12);
			this.nuevoComprobanteButton.Name = "nuevoComprobanteButton";
			this.nuevoComprobanteButton.Size = new System.Drawing.Size(359, 37);
			this.nuevoComprobanteButton.TabIndex = 21;
			this.nuevoComprobanteButton.Text = "Nuevo Comprobante vía AFIP";
			this.nuevoComprobanteButton.UseVisualStyleBackColor = true;
			this.nuevoComprobanteButton.Click += new System.EventHandler(this.nuevoComprobanteButton_Click);
			// 
			// ComprobantesDataGridView
			// 
			this.ComprobantesDataGridView.AllowUserToAddRows = false;
			this.ComprobantesDataGridView.AllowUserToDeleteRows = false;
			this.ComprobantesDataGridView.AllowUserToOrderColumns = true;
			this.ComprobantesDataGridView.AutoGenerateColumns = false;
			this.ComprobantesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.ComprobantesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.ComprobantesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ComprobantesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaImpactoDataGridViewTextBoxColumn,
            this.idTransaccionDataGridViewTextBoxColumn,
            this.idComprobanteDataGridViewTextBoxColumn,
            this.puntoVentaDataGridViewTextBoxColumn,
            this.caeDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.descrCodigoDataGridViewTextBoxColumn,
            this.tipoDocDataGridViewTextBoxColumn1,
            this.descrTipoDocDataGridViewTextBoxColumn,
            this.nrodocDataGridViewTextBoxColumn,
            this.prestaservDataGridViewCheckBoxColumn,
            this.fechacbteDataGridViewTextBoxColumn,
            this.fechaservdesdeDataGridViewTextBoxColumn,
            this.fechaservhastaDataGridViewTextBoxColumn,
            this.fechavencpagoDataGridViewTextBoxColumn,
            this.impnetoDataGridViewTextBoxColumn,
            this.impopexDataGridViewTextBoxColumn,
            this.imptotconcDataGridViewTextBoxColumn,
            this.imptotalDataGridViewTextBoxColumn,
            this.imptoliqDataGridViewTextBoxColumn,
            this.imptoliqrniDataGridViewTextBoxColumn,
            this.resultadoDataGridViewTextBoxColumn,
            this.motivoDataGridViewTextBoxColumn,
            this.mensajeErrorDataGridViewTextBoxColumn});
			this.ComprobantesDataGridView.DataSource = this.comprobanteBindingSource;
			this.ComprobantesDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ComprobantesDataGridView.Location = new System.Drawing.Point(0, 55);
			this.ComprobantesDataGridView.Name = "ComprobantesDataGridView";
			this.ComprobantesDataGridView.ReadOnly = true;
			this.ComprobantesDataGridView.Size = new System.Drawing.Size(732, 426);
			this.ComprobantesDataGridView.TabIndex = 22;
			// 
			// fechaImpactoDataGridViewTextBoxColumn
			// 
			this.fechaImpactoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.fechaImpactoDataGridViewTextBoxColumn.DataPropertyName = "FechaImpacto";
			dataGridViewCellStyle1.Format = "F";
			dataGridViewCellStyle1.NullValue = null;
			this.fechaImpactoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.fechaImpactoDataGridViewTextBoxColumn.HeaderText = "Fecha Impacto";
			this.fechaImpactoDataGridViewTextBoxColumn.Name = "fechaImpactoDataGridViewTextBoxColumn";
			this.fechaImpactoDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaImpactoDataGridViewTextBoxColumn.Width = 93;
			// 
			// idTransaccionDataGridViewTextBoxColumn
			// 
			this.idTransaccionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.idTransaccionDataGridViewTextBoxColumn.DataPropertyName = "IdTransaccion";
			this.idTransaccionDataGridViewTextBoxColumn.HeaderText = "N° Transaccion";
			this.idTransaccionDataGridViewTextBoxColumn.Name = "idTransaccionDataGridViewTextBoxColumn";
			this.idTransaccionDataGridViewTextBoxColumn.ReadOnly = true;
			this.idTransaccionDataGridViewTextBoxColumn.Width = 95;
			// 
			// idComprobanteDataGridViewTextBoxColumn
			// 
			this.idComprobanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.idComprobanteDataGridViewTextBoxColumn.DataPropertyName = "IdComprobante";
			this.idComprobanteDataGridViewTextBoxColumn.HeaderText = "N° Comprobante";
			this.idComprobanteDataGridViewTextBoxColumn.Name = "idComprobanteDataGridViewTextBoxColumn";
			this.idComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
			this.idComprobanteDataGridViewTextBoxColumn.Width = 99;
			// 
			// puntoVentaDataGridViewTextBoxColumn
			// 
			this.puntoVentaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.puntoVentaDataGridViewTextBoxColumn.DataPropertyName = "PuntoVenta";
			this.puntoVentaDataGridViewTextBoxColumn.HeaderText = "Punto Venta";
			this.puntoVentaDataGridViewTextBoxColumn.Name = "puntoVentaDataGridViewTextBoxColumn";
			this.puntoVentaDataGridViewTextBoxColumn.ReadOnly = true;
			this.puntoVentaDataGridViewTextBoxColumn.Width = 82;
			// 
			// caeDataGridViewTextBoxColumn
			// 
			this.caeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.caeDataGridViewTextBoxColumn.DataPropertyName = "Cae";
			this.caeDataGridViewTextBoxColumn.HeaderText = "CAE";
			this.caeDataGridViewTextBoxColumn.Name = "caeDataGridViewTextBoxColumn";
			this.caeDataGridViewTextBoxColumn.ReadOnly = true;
			this.caeDataGridViewTextBoxColumn.Width = 51;
			// 
			// codigoDataGridViewTextBoxColumn
			// 
			this.codigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
			this.codigoDataGridViewTextBoxColumn.HeaderText = "Código";
			this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
			this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
			this.codigoDataGridViewTextBoxColumn.Width = 63;
			// 
			// descrCodigoDataGridViewTextBoxColumn
			// 
			this.descrCodigoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.descrCodigoDataGridViewTextBoxColumn.DataPropertyName = "DescrCodigo";
			this.descrCodigoDataGridViewTextBoxColumn.HeaderText = "Descripción Código";
			this.descrCodigoDataGridViewTextBoxColumn.Name = "descrCodigoDataGridViewTextBoxColumn";
			this.descrCodigoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descrCodigoDataGridViewTextBoxColumn.Width = 112;
			// 
			// tipoDocDataGridViewTextBoxColumn1
			// 
			this.tipoDocDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.tipoDocDataGridViewTextBoxColumn1.DataPropertyName = "TipoDoc";
			this.tipoDocDataGridViewTextBoxColumn1.HeaderText = "Tipo Doc";
			this.tipoDocDataGridViewTextBoxColumn1.Name = "tipoDocDataGridViewTextBoxColumn1";
			this.tipoDocDataGridViewTextBoxColumn1.ReadOnly = true;
			this.tipoDocDataGridViewTextBoxColumn1.Width = 68;
			// 
			// descrTipoDocDataGridViewTextBoxColumn
			// 
			this.descrTipoDocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.descrTipoDocDataGridViewTextBoxColumn.DataPropertyName = "DescrTipoDoc";
			this.descrTipoDocDataGridViewTextBoxColumn.HeaderText = "Descripción Tipo Doc";
			this.descrTipoDocDataGridViewTextBoxColumn.Name = "descrTipoDocDataGridViewTextBoxColumn";
			this.descrTipoDocDataGridViewTextBoxColumn.ReadOnly = true;
			this.descrTipoDocDataGridViewTextBoxColumn.Width = 104;
			// 
			// nrodocDataGridViewTextBoxColumn
			// 
			this.nrodocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.nrodocDataGridViewTextBoxColumn.DataPropertyName = "Nro_doc";
			this.nrodocDataGridViewTextBoxColumn.HeaderText = "Nro id comprador";
			this.nrodocDataGridViewTextBoxColumn.Name = "nrodocDataGridViewTextBoxColumn";
			this.nrodocDataGridViewTextBoxColumn.ReadOnly = true;
			this.nrodocDataGridViewTextBoxColumn.ToolTipText = "Nro.  de identificación del comprador";
			this.nrodocDataGridViewTextBoxColumn.Width = 102;
			// 
			// prestaservDataGridViewCheckBoxColumn
			// 
			this.prestaservDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.prestaservDataGridViewCheckBoxColumn.DataPropertyName = "Presta_serv";
			this.prestaservDataGridViewCheckBoxColumn.HeaderText = "Presta servicio";
			this.prestaservDataGridViewCheckBoxColumn.Name = "prestaservDataGridViewCheckBoxColumn";
			this.prestaservDataGridViewCheckBoxColumn.ReadOnly = true;
			this.prestaservDataGridViewCheckBoxColumn.Width = 72;
			// 
			// fechacbteDataGridViewTextBoxColumn
			// 
			this.fechacbteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.fechacbteDataGridViewTextBoxColumn.DataPropertyName = "Fecha_cbte";
			this.fechacbteDataGridViewTextBoxColumn.HeaderText = "Fecha comprobante";
			this.fechacbteDataGridViewTextBoxColumn.Name = "fechacbteDataGridViewTextBoxColumn";
			this.fechacbteDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechacbteDataGridViewTextBoxColumn.Width = 114;
			// 
			// fechaservdesdeDataGridViewTextBoxColumn
			// 
			this.fechaservdesdeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.fechaservdesdeDataGridViewTextBoxColumn.DataPropertyName = "Fecha_serv_desde";
			this.fechaservdesdeDataGridViewTextBoxColumn.HeaderText = "Fecha servicio desde";
			this.fechaservdesdeDataGridViewTextBoxColumn.Name = "fechaservdesdeDataGridViewTextBoxColumn";
			this.fechaservdesdeDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaservdesdeDataGridViewTextBoxColumn.Width = 120;
			// 
			// fechaservhastaDataGridViewTextBoxColumn
			// 
			this.fechaservhastaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.fechaservhastaDataGridViewTextBoxColumn.DataPropertyName = "Fecha_serv_hasta";
			this.fechaservhastaDataGridViewTextBoxColumn.HeaderText = "Fecha servicio hasta";
			this.fechaservhastaDataGridViewTextBoxColumn.Name = "fechaservhastaDataGridViewTextBoxColumn";
			this.fechaservhastaDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaservhastaDataGridViewTextBoxColumn.Width = 117;
			// 
			// fechavencpagoDataGridViewTextBoxColumn
			// 
			this.fechavencpagoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.fechavencpagoDataGridViewTextBoxColumn.DataPropertyName = "Fecha_venc_pago";
			this.fechavencpagoDataGridViewTextBoxColumn.HeaderText = "Vencimiento";
			this.fechavencpagoDataGridViewTextBoxColumn.Name = "fechavencpagoDataGridViewTextBoxColumn";
			this.fechavencpagoDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechavencpagoDataGridViewTextBoxColumn.ToolTipText = "Fecha de vencimiento de la factura";
			this.fechavencpagoDataGridViewTextBoxColumn.Width = 88;
			// 
			// impnetoDataGridViewTextBoxColumn
			// 
			this.impnetoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.impnetoDataGridViewTextBoxColumn.DataPropertyName = "Imp_neto";
			this.impnetoDataGridViewTextBoxColumn.HeaderText = "Importe neto";
			this.impnetoDataGridViewTextBoxColumn.Name = "impnetoDataGridViewTextBoxColumn";
			this.impnetoDataGridViewTextBoxColumn.ReadOnly = true;
			this.impnetoDataGridViewTextBoxColumn.Width = 82;
			// 
			// impopexDataGridViewTextBoxColumn
			// 
			this.impopexDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.impopexDataGridViewTextBoxColumn.DataPropertyName = "Imp_op_ex";
			this.impopexDataGridViewTextBoxColumn.HeaderText = "Importe de operaciones exentas";
			this.impopexDataGridViewTextBoxColumn.Name = "impopexDataGridViewTextBoxColumn";
			this.impopexDataGridViewTextBoxColumn.ReadOnly = true;
			this.impopexDataGridViewTextBoxColumn.Width = 131;
			// 
			// imptotconcDataGridViewTextBoxColumn
			// 
			this.imptotconcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.imptotconcDataGridViewTextBoxColumn.DataPropertyName = "Imp_tot_conc";
			this.imptotconcDataGridViewTextBoxColumn.HeaderText = "Importe total conceptos";
			this.imptotconcDataGridViewTextBoxColumn.Name = "imptotconcDataGridViewTextBoxColumn";
			this.imptotconcDataGridViewTextBoxColumn.ReadOnly = true;
			this.imptotconcDataGridViewTextBoxColumn.ToolTipText = "Importe total de conceptos que no integran el precio neto gravado";
			this.imptotconcDataGridViewTextBoxColumn.Width = 129;
			// 
			// imptotalDataGridViewTextBoxColumn
			// 
			this.imptotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.imptotalDataGridViewTextBoxColumn.DataPropertyName = "Imp_total";
			this.imptotalDataGridViewTextBoxColumn.HeaderText = "Importe total";
			this.imptotalDataGridViewTextBoxColumn.Name = "imptotalDataGridViewTextBoxColumn";
			this.imptotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.imptotalDataGridViewTextBoxColumn.Width = 81;
			// 
			// imptoliqDataGridViewTextBoxColumn
			// 
			this.imptoliqDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.imptoliqDataGridViewTextBoxColumn.DataPropertyName = "Impto_liq";
			this.imptoliqDataGridViewTextBoxColumn.HeaderText = "Impuesto liquidado";
			this.imptoliqDataGridViewTextBoxColumn.Name = "imptoliqDataGridViewTextBoxColumn";
			this.imptoliqDataGridViewTextBoxColumn.ReadOnly = true;
			this.imptoliqDataGridViewTextBoxColumn.Width = 108;
			// 
			// imptoliqrniDataGridViewTextBoxColumn
			// 
			this.imptoliqrniDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.imptoliqrniDataGridViewTextBoxColumn.DataPropertyName = "Impto_liq_rni";
			this.imptoliqrniDataGridViewTextBoxColumn.HeaderText = "Impuesto liquidado rni";
			this.imptoliqrniDataGridViewTextBoxColumn.Name = "imptoliqrniDataGridViewTextBoxColumn";
			this.imptoliqrniDataGridViewTextBoxColumn.ReadOnly = true;
			this.imptoliqrniDataGridViewTextBoxColumn.ToolTipText = "Impuesto liquidado a RNI o percepción a no categorizados";
			this.imptoliqrniDataGridViewTextBoxColumn.Width = 111;
			// 
			// resultadoDataGridViewTextBoxColumn
			// 
			this.resultadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.resultadoDataGridViewTextBoxColumn.DataPropertyName = "Resultado";
			this.resultadoDataGridViewTextBoxColumn.HeaderText = "Resultado";
			this.resultadoDataGridViewTextBoxColumn.Name = "resultadoDataGridViewTextBoxColumn";
			this.resultadoDataGridViewTextBoxColumn.ReadOnly = true;
			this.resultadoDataGridViewTextBoxColumn.Width = 78;
			// 
			// motivoDataGridViewTextBoxColumn
			// 
			this.motivoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.motivoDataGridViewTextBoxColumn.DataPropertyName = "Motivo";
			this.motivoDataGridViewTextBoxColumn.HeaderText = "Motivo";
			this.motivoDataGridViewTextBoxColumn.Name = "motivoDataGridViewTextBoxColumn";
			this.motivoDataGridViewTextBoxColumn.ReadOnly = true;
			this.motivoDataGridViewTextBoxColumn.Width = 62;
			// 
			// mensajeErrorDataGridViewTextBoxColumn
			// 
			this.mensajeErrorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.mensajeErrorDataGridViewTextBoxColumn.DataPropertyName = "MensajeError";
			this.mensajeErrorDataGridViewTextBoxColumn.HeaderText = "Mensaje Error";
			this.mensajeErrorDataGridViewTextBoxColumn.Name = "mensajeErrorDataGridViewTextBoxColumn";
			this.mensajeErrorDataGridViewTextBoxColumn.ReadOnly = true;
			this.mensajeErrorDataGridViewTextBoxColumn.Width = 87;
			// 
			// comprobanteBindingSource
			// 
			this.comprobanteBindingSource.DataSource = typeof(FeaEntidades.Comprobante);
			// 
			// xmlIBKButton
			// 
			this.xmlIBKButton.Location = new System.Drawing.Point(373, 12);
			this.xmlIBKButton.Name = "xmlIBKButton";
			this.xmlIBKButton.Size = new System.Drawing.Size(359, 37);
			this.xmlIBKButton.TabIndex = 23;
			this.xmlIBKButton.Text = "Generar XML Interfacturas";
			this.xmlIBKButton.UseVisualStyleBackColor = true;
			this.xmlIBKButton.Click += new System.EventHandler(this.xmlIBKButton_Click);
			// 
			// PrincipalForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 481);
			this.Controls.Add(this.xmlIBKButton);
			this.Controls.Add(this.ComprobantesDataGridView);
			this.Controls.Add(this.nuevoComprobanteButton);
			this.Controls.Add(this.verificarCaeTextBox);
			this.Controls.Add(this.verificarCaeButton);
			this.Controls.Add(this.ultCompAutTextBox);
			this.Controls.Add(this.cantMaxDetTextBox);
			this.Controls.Add(this.ultCompAutButton);
			this.Controls.Add(this.cantMaxDetButton);
			this.Controls.Add(this.ultNroRqstTextBox);
			this.Controls.Add(this.ultNroButton);
			this.Controls.Add(this.cuitLabel);
			this.Controls.Add(this.cuitTextBox);
			this.Controls.Add(this.signLabel);
			this.Controls.Add(this.tokenLabel);
			this.Controls.Add(this.signTextBox);
			this.Controls.Add(this.tokenTextBox);
			this.Controls.Add(this.ticketButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PrincipalForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CedFEA";
			this.Load += new System.EventHandler(this.PrincipalForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ComprobantesDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comprobanteBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ticketButton;
		private System.Windows.Forms.TextBox tokenTextBox;
		private System.Windows.Forms.TextBox signTextBox;
		private System.Windows.Forms.Label tokenLabel;
		private System.Windows.Forms.Label signLabel;
		private System.Windows.Forms.TextBox cuitTextBox;
		private System.Windows.Forms.Label cuitLabel;
		private System.Windows.Forms.Button ultNroButton;
		private System.Windows.Forms.TextBox ultNroRqstTextBox;
		private System.Windows.Forms.Button cantMaxDetButton;
		private System.Windows.Forms.Button ultCompAutButton;
		private System.Windows.Forms.TextBox cantMaxDetTextBox;
		private System.Windows.Forms.TextBox ultCompAutTextBox;
		private System.Windows.Forms.Button verificarCaeButton;
		private System.Windows.Forms.TextBox verificarCaeTextBox;
		private System.Windows.Forms.Button nuevoComprobanteButton;
		private System.Windows.Forms.DataGridView ComprobantesDataGridView;
		private System.Windows.Forms.BindingSource comprobanteBindingSource;
		private System.Windows.Forms.ToolTip PrincipalToolTip;
		private System.Windows.Forms.DataGridViewTextBoxColumn fechaImpactoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn idTransaccionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn idComprobanteDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn puntoVentaDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn caeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn descrCodigoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn descrTipoDocDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nrodocDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn prestaservDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fechacbteDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fechaservdesdeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fechaservhastaDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn fechavencpagoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn impnetoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn impopexDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn imptotconcDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn imptotalDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn imptoliqDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn imptoliqrniDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn resultadoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn motivoDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn mensajeErrorDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button xmlIBKButton;
	}
}

