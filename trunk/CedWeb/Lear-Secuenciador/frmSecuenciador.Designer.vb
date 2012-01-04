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
        Me.Puerto = New System.IO.Ports.SerialPort(Me.components)
        Me.BarraPanel = New System.Windows.Forms.Panel
        Me.BarraSplitContainer = New System.Windows.Forms.SplitContainer
        Me.BotonesPanel = New System.Windows.Forms.Panel
        Me.ImprimirPruebaButton = New System.Windows.Forms.Button
        Me.EnviarButton = New System.Windows.Forms.Button
        Me.BBTemp = New System.Windows.Forms.Button
        Me.SalirButton = New System.Windows.Forms.Button
        Me.ConfigurarButton = New System.Windows.Forms.Button
        Me.DetenerButton = New System.Windows.Forms.Button
        Me.RecibirButton = New System.Windows.Forms.Button
        Me.BarraTextBox = New System.Windows.Forms.TextBox
        Me.GrillaPanel = New System.Windows.Forms.Panel
        Me.GrillaSplitContainer = New System.Windows.Forms.SplitContainer
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
        Me.MensajeTextBox = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Timers.Timer
        Me.BarraPanel.SuspendLayout()
        Me.BarraSplitContainer.Panel1.SuspendLayout()
        Me.BarraSplitContainer.Panel2.SuspendLayout()
        Me.BarraSplitContainer.SuspendLayout()
        Me.BotonesPanel.SuspendLayout()
        Me.GrillaPanel.SuspendLayout()
        Me.GrillaSplitContainer.Panel1.SuspendLayout()
        Me.GrillaSplitContainer.Panel2.SuspendLayout()
        Me.GrillaSplitContainer.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Puerto
        '
        '
        'BarraPanel
        '
        Me.BarraPanel.Controls.Add(Me.BarraSplitContainer)
        Me.BarraPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraPanel.Location = New System.Drawing.Point(0, 386)
        Me.BarraPanel.Name = "BarraPanel"
        Me.BarraPanel.Size = New System.Drawing.Size(768, 67)
        Me.BarraPanel.TabIndex = 32
        '
        'BarraSplitContainer
        '
        Me.BarraSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BarraSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.BarraSplitContainer.Name = "BarraSplitContainer"
        Me.BarraSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'BarraSplitContainer.Panel1
        '
        Me.BarraSplitContainer.Panel1.Controls.Add(Me.BotonesPanel)
        Me.BarraSplitContainer.Panel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.BarraSplitContainer.Panel1MinSize = 20
        '
        'BarraSplitContainer.Panel2
        '
        Me.BarraSplitContainer.Panel2.Controls.Add(Me.BarraTextBox)
        Me.BarraSplitContainer.Panel2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.BarraSplitContainer.Panel2MinSize = 20
        Me.BarraSplitContainer.Size = New System.Drawing.Size(768, 67)
        Me.BarraSplitContainer.SplitterDistance = 33
        Me.BarraSplitContainer.TabIndex = 35
        '
        'BotonesPanel
        '
        Me.BotonesPanel.Controls.Add(Me.ImprimirPruebaButton)
        Me.BotonesPanel.Controls.Add(Me.EnviarButton)
        Me.BotonesPanel.Controls.Add(Me.BBTemp)
        Me.BotonesPanel.Controls.Add(Me.SalirButton)
        Me.BotonesPanel.Controls.Add(Me.ConfigurarButton)
        Me.BotonesPanel.Controls.Add(Me.DetenerButton)
        Me.BotonesPanel.Controls.Add(Me.RecibirButton)
        Me.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BotonesPanel.Location = New System.Drawing.Point(3, 6)
        Me.BotonesPanel.Name = "BotonesPanel"
        Me.BotonesPanel.Size = New System.Drawing.Size(762, 27)
        Me.BotonesPanel.TabIndex = 27
        '
        'ImprimirPruebaButton
        '
        Me.ImprimirPruebaButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.ImprimirPruebaButton.Location = New System.Drawing.Point(500, 0)
        Me.ImprimirPruebaButton.Name = "ImprimirPruebaButton"
        Me.ImprimirPruebaButton.Size = New System.Drawing.Size(100, 27)
        Me.ImprimirPruebaButton.TabIndex = 31
        Me.ImprimirPruebaButton.Text = "Imprimir Prueba"
        Me.ImprimirPruebaButton.UseVisualStyleBackColor = True
        '
        'EnviarButton
        '
        Me.EnviarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.EnviarButton.Location = New System.Drawing.Point(400, 0)
        Me.EnviarButton.Name = "EnviarButton"
        Me.EnviarButton.Size = New System.Drawing.Size(100, 27)
        Me.EnviarButton.TabIndex = 30
        Me.EnviarButton.Text = "Enviar"
        Me.EnviarButton.UseVisualStyleBackColor = True
        '
        'BBTemp
        '
        Me.BBTemp.Dock = System.Windows.Forms.DockStyle.Left
        Me.BBTemp.Location = New System.Drawing.Point(300, 0)
        Me.BBTemp.Name = "BBTemp"
        Me.BBTemp.Size = New System.Drawing.Size(100, 27)
        Me.BBTemp.TabIndex = 29
        Me.BBTemp.Text = "Bajar Temporal"
        Me.BBTemp.UseVisualStyleBackColor = True
        '
        'SalirButton
        '
        Me.SalirButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.SalirButton.Location = New System.Drawing.Point(662, 0)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(100, 27)
        Me.SalirButton.TabIndex = 28
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'ConfigurarButton
        '
        Me.ConfigurarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.ConfigurarButton.Location = New System.Drawing.Point(200, 0)
        Me.ConfigurarButton.Name = "ConfigurarButton"
        Me.ConfigurarButton.Size = New System.Drawing.Size(100, 27)
        Me.ConfigurarButton.TabIndex = 27
        Me.ConfigurarButton.Text = "Configurar"
        Me.ConfigurarButton.UseVisualStyleBackColor = True
        '
        'DetenerButton
        '
        Me.DetenerButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.DetenerButton.Location = New System.Drawing.Point(100, 0)
        Me.DetenerButton.Name = "DetenerButton"
        Me.DetenerButton.Size = New System.Drawing.Size(100, 27)
        Me.DetenerButton.TabIndex = 26
        Me.DetenerButton.Text = "Detener"
        Me.DetenerButton.UseVisualStyleBackColor = True
        '
        'RecibirButton
        '
        Me.RecibirButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.RecibirButton.Location = New System.Drawing.Point(0, 0)
        Me.RecibirButton.Name = "RecibirButton"
        Me.RecibirButton.Size = New System.Drawing.Size(100, 27)
        Me.RecibirButton.TabIndex = 25
        Me.RecibirButton.Text = "Recibir"
        Me.RecibirButton.UseVisualStyleBackColor = True
        '
        'BarraTextBox
        '
        Me.BarraTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BarraTextBox.Location = New System.Drawing.Point(3, 6)
        Me.BarraTextBox.Name = "BarraTextBox"
        Me.BarraTextBox.ReadOnly = True
        Me.BarraTextBox.Size = New System.Drawing.Size(762, 20)
        Me.BarraTextBox.TabIndex = 2
        '
        'GrillaPanel
        '
        Me.GrillaPanel.Controls.Add(Me.GrillaSplitContainer)
        Me.GrillaPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaPanel.Location = New System.Drawing.Point(0, 0)
        Me.GrillaPanel.Name = "GrillaPanel"
        Me.GrillaPanel.Size = New System.Drawing.Size(768, 386)
        Me.GrillaPanel.TabIndex = 35
        '
        'GrillaSplitContainer
        '
        Me.GrillaSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrillaSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.GrillaSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.GrillaSplitContainer.Name = "GrillaSplitContainer"
        Me.GrillaSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'GrillaSplitContainer.Panel1
        '
        Me.GrillaSplitContainer.Panel1.Controls.Add(Me.Grilla)
        Me.GrillaSplitContainer.Panel1MinSize = 50
        '
        'GrillaSplitContainer.Panel2
        '
        Me.GrillaSplitContainer.Panel2.Controls.Add(Me.MensajeTextBox)
        Me.GrillaSplitContainer.Panel2MinSize = 40
        Me.GrillaSplitContainer.Size = New System.Drawing.Size(768, 386)
        Me.GrillaSplitContainer.SplitterDistance = 305
        Me.GrillaSplitContainer.TabIndex = 31
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
        Me.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grilla.Size = New System.Drawing.Size(768, 305)
        Me.Grilla.TabIndex = 22
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
        'MensajeTextBox
        '
        Me.MensajeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MensajeTextBox.Location = New System.Drawing.Point(0, 0)
        Me.MensajeTextBox.Multiline = True
        Me.MensajeTextBox.Name = "MensajeTextBox"
        Me.MensajeTextBox.ReadOnly = True
        Me.MensajeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MensajeTextBox.Size = New System.Drawing.Size(768, 77)
        Me.MensajeTextBox.TabIndex = 30
        '
        'Timer1
        '
        Me.Timer1.AutoReset = False
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        Me.Timer1.SynchronizingObject = Me
        '
        'frmSecuenciador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 453)
        Me.Controls.Add(Me.GrillaPanel)
        Me.Controls.Add(Me.BarraPanel)
        Me.Name = "frmSecuenciador"
        Me.Text = "Secuenciador (TCP IP y COM)"
        Me.BarraPanel.ResumeLayout(False)
        Me.BarraSplitContainer.Panel1.ResumeLayout(False)
        Me.BarraSplitContainer.Panel2.ResumeLayout(False)
        Me.BarraSplitContainer.Panel2.PerformLayout()
        Me.BarraSplitContainer.ResumeLayout(False)
        Me.BotonesPanel.ResumeLayout(False)
        Me.GrillaPanel.ResumeLayout(False)
        Me.GrillaSplitContainer.Panel1.ResumeLayout(False)
        Me.GrillaSplitContainer.Panel2.ResumeLayout(False)
        Me.GrillaSplitContainer.Panel2.PerformLayout()
        Me.GrillaSplitContainer.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Puerto As System.IO.Ports.SerialPort
    Friend WithEvents BarraPanel As System.Windows.Forms.Panel
    Friend WithEvents GrillaPanel As System.Windows.Forms.Panel
    Friend WithEvents GrillaSplitContainer As System.Windows.Forms.SplitContainer
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
    Friend WithEvents MensajeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BarraSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents BotonesPanel As System.Windows.Forms.Panel
    Friend WithEvents ImprimirPruebaButton As System.Windows.Forms.Button
    Friend WithEvents EnviarButton As System.Windows.Forms.Button
    Friend WithEvents BBTemp As System.Windows.Forms.Button
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents ConfigurarButton As System.Windows.Forms.Button
    Friend WithEvents DetenerButton As System.Windows.Forms.Button
    Friend WithEvents RecibirButton As System.Windows.Forms.Button
    Friend WithEvents BarraTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Timers.Timer

End Class
