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
        Me.ImprimirPruebaButton = New System.Windows.Forms.Button
        Me.EnviarButton = New System.Windows.Forms.Button
        Me.BBTemp = New System.Windows.Forms.Button
        Me.SalirButton = New System.Windows.Forms.Button
        Me.ConfigurarButton = New System.Windows.Forms.Button
        Me.DetenerButton = New System.Windows.Forms.Button
        Me.RecibirButton = New System.Windows.Forms.Button
        Me.Puerto = New System.IO.Ports.SerialPort(Me.components)
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
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
        Me.BotonesPanel.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BotonesPanel.Location = New System.Drawing.Point(0, 424)
        Me.BotonesPanel.Name = "BotonesPanel"
        Me.BotonesPanel.Size = New System.Drawing.Size(752, 29)
        Me.BotonesPanel.TabIndex = 25
        '
        'ImprimirPruebaButton
        '
        Me.ImprimirPruebaButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.ImprimirPruebaButton.Location = New System.Drawing.Point(500, 0)
        Me.ImprimirPruebaButton.Name = "ImprimirPruebaButton"
        Me.ImprimirPruebaButton.Size = New System.Drawing.Size(100, 29)
        Me.ImprimirPruebaButton.TabIndex = 31
        Me.ImprimirPruebaButton.Text = "Imprimir Prueba"
        Me.ImprimirPruebaButton.UseVisualStyleBackColor = True
        '
        'EnviarButton
        '
        Me.EnviarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.EnviarButton.Location = New System.Drawing.Point(400, 0)
        Me.EnviarButton.Name = "EnviarButton"
        Me.EnviarButton.Size = New System.Drawing.Size(100, 29)
        Me.EnviarButton.TabIndex = 30
        Me.EnviarButton.Text = "Enviar"
        Me.EnviarButton.UseVisualStyleBackColor = True
        '
        'BBTemp
        '
        Me.BBTemp.Dock = System.Windows.Forms.DockStyle.Left
        Me.BBTemp.Location = New System.Drawing.Point(300, 0)
        Me.BBTemp.Name = "BBTemp"
        Me.BBTemp.Size = New System.Drawing.Size(100, 29)
        Me.BBTemp.TabIndex = 29
        Me.BBTemp.Text = "Bajar Temporal"
        Me.BBTemp.UseVisualStyleBackColor = True
        '
        'SalirButton
        '
        Me.SalirButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.SalirButton.Location = New System.Drawing.Point(652, 0)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(100, 29)
        Me.SalirButton.TabIndex = 28
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'ConfigurarButton
        '
        Me.ConfigurarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.ConfigurarButton.Location = New System.Drawing.Point(200, 0)
        Me.ConfigurarButton.Name = "ConfigurarButton"
        Me.ConfigurarButton.Size = New System.Drawing.Size(100, 29)
        Me.ConfigurarButton.TabIndex = 27
        Me.ConfigurarButton.Text = "Configurar"
        Me.ConfigurarButton.UseVisualStyleBackColor = True
        '
        'DetenerButton
        '
        Me.DetenerButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.DetenerButton.Location = New System.Drawing.Point(100, 0)
        Me.DetenerButton.Name = "DetenerButton"
        Me.DetenerButton.Size = New System.Drawing.Size(100, 29)
        Me.DetenerButton.TabIndex = 26
        Me.DetenerButton.Text = "Detener"
        Me.DetenerButton.UseVisualStyleBackColor = True
        '
        'RecibirButton
        '
        Me.RecibirButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.RecibirButton.Location = New System.Drawing.Point(0, 0)
        Me.RecibirButton.Name = "RecibirButton"
        Me.RecibirButton.Size = New System.Drawing.Size(100, 29)
        Me.RecibirButton.TabIndex = 25
        Me.RecibirButton.Text = "Recibir"
        Me.RecibirButton.UseVisualStyleBackColor = True
        '
        'Puerto
        '
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.Grilla)
        Me.SplitContainer.Panel1MinSize = 50
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.MensajeTextBox)
        Me.SplitContainer.Panel2MinSize = 40
        Me.SplitContainer.Size = New System.Drawing.Size(752, 424)
        Me.SplitContainer.SplitterDistance = 343
        Me.SplitContainer.TabIndex = 30
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
        Me.Grilla.Size = New System.Drawing.Size(752, 343)
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
        Me.MensajeTextBox.Size = New System.Drawing.Size(752, 77)
        Me.MensajeTextBox.TabIndex = 30
        '
        'frmSecuenciador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 453)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.BotonesPanel)
        Me.Name = "frmSecuenciador"
        Me.Text = "Secuenciador (TCP IP y COM)"
        Me.BotonesPanel.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.Panel2.PerformLayout()
        Me.SplitContainer.ResumeLayout(False)
        CType(Me.Grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BotonesPanel As System.Windows.Forms.Panel
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents ConfigurarButton As System.Windows.Forms.Button
    Friend WithEvents DetenerButton As System.Windows.Forms.Button
    Friend WithEvents RecibirButton As System.Windows.Forms.Button
    Friend WithEvents Puerto As System.IO.Ports.SerialPort
    Friend WithEvents BBTemp As System.Windows.Forms.Button
    Friend WithEvents EnviarButton As System.Windows.Forms.Button
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
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
    Friend WithEvents ImprimirPruebaButton As System.Windows.Forms.Button

End Class
