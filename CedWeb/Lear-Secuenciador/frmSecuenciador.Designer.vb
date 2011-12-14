<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecuenciador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BotonesPanel = New System.Windows.Forms.Panel
        Me.SalirButton = New System.Windows.Forms.Button
        Me.ConfigurarButton = New System.Windows.Forms.Button
        Me.DetenerButton = New System.Windows.Forms.Button
        Me.RecibirButton = New System.Windows.Forms.Button
        Me.GrillaPanel = New System.Windows.Forms.Panel
        Me.Grilla = New System.Windows.Forms.DataGridView
        Me.Origen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Secuencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Model = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TMA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sequi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Barra = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Puerto = New System.IO.Ports.SerialPort(Me.components)
        Me.BBTemp = New System.Windows.Forms.Button
        Me.BotonesPanel.SuspendLayout()
        Me.GrillaPanel.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Barra.SuspendLayout()
        Me.SuspendLayout()
        '
        'BotonesPanel
        '
        Me.BotonesPanel.Controls.Add(Me.BBTemp)
        Me.BotonesPanel.Controls.Add(Me.SalirButton)
        Me.BotonesPanel.Controls.Add(Me.ConfigurarButton)
        Me.BotonesPanel.Controls.Add(Me.DetenerButton)
        Me.BotonesPanel.Controls.Add(Me.RecibirButton)
        Me.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BotonesPanel.Location = New System.Drawing.Point(0, 421)
        Me.BotonesPanel.Name = "BotonesPanel"
        Me.BotonesPanel.Size = New System.Drawing.Size(784, 30)
        Me.BotonesPanel.TabIndex = 25
        '
        'SalirButton
        '
        Me.SalirButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.SalirButton.Location = New System.Drawing.Point(656, 0)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(128, 30)
        Me.SalirButton.TabIndex = 28
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'ConfigurarButton
        '
        Me.ConfigurarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.ConfigurarButton.Location = New System.Drawing.Point(256, 0)
        Me.ConfigurarButton.Name = "ConfigurarButton"
        Me.ConfigurarButton.Size = New System.Drawing.Size(128, 30)
        Me.ConfigurarButton.TabIndex = 27
        Me.ConfigurarButton.Text = "Configurar"
        Me.ConfigurarButton.UseVisualStyleBackColor = True
        '
        'DetenerButton
        '
        Me.DetenerButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.DetenerButton.Location = New System.Drawing.Point(128, 0)
        Me.DetenerButton.Name = "DetenerButton"
        Me.DetenerButton.Size = New System.Drawing.Size(128, 30)
        Me.DetenerButton.TabIndex = 26
        Me.DetenerButton.Text = "Detener"
        Me.DetenerButton.UseVisualStyleBackColor = True
        '
        'RecibirButton
        '
        Me.RecibirButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.RecibirButton.Location = New System.Drawing.Point(0, 0)
        Me.RecibirButton.Name = "RecibirButton"
        Me.RecibirButton.Size = New System.Drawing.Size(128, 30)
        Me.RecibirButton.TabIndex = 25
        Me.RecibirButton.Text = "Recibir"
        Me.RecibirButton.UseVisualStyleBackColor = True
        '
        'GrillaPanel
        '
        Me.GrillaPanel.Controls.Add(Me.Grilla)
        Me.GrillaPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaPanel.Location = New System.Drawing.Point(0, 0)
        Me.GrillaPanel.Name = "GrillaPanel"
        Me.GrillaPanel.Size = New System.Drawing.Size(784, 421)
        Me.GrillaPanel.TabIndex = 26
        '
        'Grilla
        '
        Me.Grilla.AllowUserToAddRows = False
        Me.Grilla.AllowUserToDeleteRows = False
        Me.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Origen, Me.Fecha, Me.Hora, Me.Destino, Me.Secuencia, Me.Model, Me.TMA, Me.Sequi, Me.Vin, Me.Fin})
        Me.Grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grilla.Location = New System.Drawing.Point(0, 0)
        Me.Grilla.Name = "Grilla"
        Me.Grilla.ReadOnly = True
        Me.Grilla.Size = New System.Drawing.Size(784, 421)
        Me.Grilla.TabIndex = 21
        '
        'Origen
        '
        Me.Origen.HeaderText = "Origen"
        Me.Origen.Name = "Origen"
        Me.Origen.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Hora
        '
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        '
        'Destino
        '
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        '
        'Secuencia
        '
        Me.Secuencia.HeaderText = "Secuencia"
        Me.Secuencia.Name = "Secuencia"
        Me.Secuencia.ReadOnly = True
        '
        'Model
        '
        Me.Model.HeaderText = "Model"
        Me.Model.Name = "Model"
        Me.Model.ReadOnly = True
        '
        'TMA
        '
        Me.TMA.HeaderText = "TMA"
        Me.TMA.Name = "TMA"
        Me.TMA.ReadOnly = True
        '
        'Sequi
        '
        Me.Sequi.HeaderText = "Sequi"
        Me.Sequi.Name = "Sequi"
        Me.Sequi.ReadOnly = True
        '
        'Vin
        '
        Me.Vin.HeaderText = "Vin"
        Me.Vin.Name = "Vin"
        Me.Vin.ReadOnly = True
        '
        'Fin
        '
        Me.Fin.HeaderText = "Fin"
        Me.Fin.Name = "Fin"
        Me.Fin.ReadOnly = True
        '
        'Barra
        '
        Me.Barra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.Barra.Location = New System.Drawing.Point(0, 399)
        Me.Barra.Name = "Barra"
        Me.Barra.Size = New System.Drawing.Size(784, 22)
        Me.Barra.TabIndex = 27
        Me.Barra.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel1.Text = "Satatus"
        '
        'Puerto
        '
        '
        'BBTemp
        '
        Me.BBTemp.Dock = System.Windows.Forms.DockStyle.Left
        Me.BBTemp.Location = New System.Drawing.Point(384, 0)
        Me.BBTemp.Name = "BBTemp"
        Me.BBTemp.Size = New System.Drawing.Size(128, 30)
        Me.BBTemp.TabIndex = 29
        Me.BBTemp.Text = "Procesar Temp"
        Me.BBTemp.UseVisualStyleBackColor = True
        '
        'frmSecuenciador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 451)
        Me.Controls.Add(Me.Barra)
        Me.Controls.Add(Me.GrillaPanel)
        Me.Controls.Add(Me.BotonesPanel)
        Me.Name = "frmSecuenciador"
        Me.Text = "Secuenciador (TCP IP y COM)"
        Me.BotonesPanel.ResumeLayout(False)
        Me.GrillaPanel.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Barra.ResumeLayout(False)
        Me.Barra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BotonesPanel As System.Windows.Forms.Panel
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents ConfigurarButton As System.Windows.Forms.Button
    Friend WithEvents DetenerButton As System.Windows.Forms.Button
    Friend WithEvents RecibirButton As System.Windows.Forms.Button
    Friend WithEvents GrillaPanel As System.Windows.Forms.Panel
    Friend WithEvents Grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Secuencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Model As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sequi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Barra As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Puerto As System.IO.Ports.SerialPort
    Friend WithEvents BBTemp As System.Windows.Forms.Button

End Class
