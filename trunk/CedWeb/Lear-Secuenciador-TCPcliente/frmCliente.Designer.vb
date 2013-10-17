<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCliente))
        Me.EnviarMensajeButton = New System.Windows.Forms.Button
        Me.SalirButton = New System.Windows.Forms.Button
        Me.MensajeTextBox = New System.Windows.Forms.TextBox
        Me.IPTextBox = New System.Windows.Forms.TextBox
        Me.PuertoTextBox = New System.Windows.Forms.TextBox
        Me.ConectarButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DetenerButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.FechaProcDTP = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'EnviarMensajeButton
        '
        Me.EnviarMensajeButton.Enabled = False
        Me.EnviarMensajeButton.Location = New System.Drawing.Point(12, 347)
        Me.EnviarMensajeButton.Name = "EnviarMensajeButton"
        Me.EnviarMensajeButton.Size = New System.Drawing.Size(481, 27)
        Me.EnviarMensajeButton.TabIndex = 0
        Me.EnviarMensajeButton.Text = "Enviar Mensaje"
        Me.EnviarMensajeButton.UseVisualStyleBackColor = True
        '
        'SalirButton
        '
        Me.SalirButton.Location = New System.Drawing.Point(499, 347)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(106, 27)
        Me.SalirButton.TabIndex = 1
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'MensajeTextBox
        '
        Me.MensajeTextBox.Location = New System.Drawing.Point(13, 42)
        Me.MensajeTextBox.Multiline = True
        Me.MensajeTextBox.Name = "MensajeTextBox"
        Me.MensajeTextBox.Size = New System.Drawing.Size(592, 289)
        Me.MensajeTextBox.TabIndex = 2
        '
        'IPTextBox
        '
        Me.IPTextBox.Location = New System.Drawing.Point(41, 14)
        Me.IPTextBox.Name = "IPTextBox"
        Me.IPTextBox.Size = New System.Drawing.Size(88, 20)
        Me.IPTextBox.TabIndex = 3
        Me.IPTextBox.Text = "127.0.0.1"
        '
        'PuertoTextBox
        '
        Me.PuertoTextBox.AcceptsReturn = True
        Me.PuertoTextBox.Location = New System.Drawing.Point(192, 14)
        Me.PuertoTextBox.Name = "PuertoTextBox"
        Me.PuertoTextBox.Size = New System.Drawing.Size(46, 20)
        Me.PuertoTextBox.TabIndex = 4
        Me.PuertoTextBox.Text = "8080"
        '
        'ConectarButton
        '
        Me.ConectarButton.Location = New System.Drawing.Point(461, 11)
        Me.ConectarButton.Name = "ConectarButton"
        Me.ConectarButton.Size = New System.Drawing.Size(68, 23)
        Me.ConectarButton.TabIndex = 5
        Me.ConectarButton.Text = "Conectar"
        Me.ConectarButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "IP:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Puerto:"
        '
        'DetenerButton
        '
        Me.DetenerButton.Location = New System.Drawing.Point(535, 11)
        Me.DetenerButton.Name = "DetenerButton"
        Me.DetenerButton.Size = New System.Drawing.Size(70, 23)
        Me.DetenerButton.TabIndex = 8
        Me.DetenerButton.Text = "Detener"
        Me.DetenerButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(256, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha.Proc:"
        '
        'FechaProcDTP
        '
        Me.FechaProcDTP.Cursor = System.Windows.Forms.Cursors.Default
        Me.FechaProcDTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaProcDTP.Location = New System.Drawing.Point(328, 14)
        Me.FechaProcDTP.Name = "FechaProcDTP"
        Me.FechaProcDTP.Size = New System.Drawing.Size(89, 20)
        Me.FechaProcDTP.TabIndex = 10
        '
        'frmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 386)
        Me.Controls.Add(Me.FechaProcDTP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DetenerButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConectarButton)
        Me.Controls.Add(Me.PuertoTextBox)
        Me.Controls.Add(Me.IPTextBox)
        Me.Controls.Add(Me.MensajeTextBox)
        Me.Controls.Add(Me.SalirButton)
        Me.Controls.Add(Me.EnviarMensajeButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCliente"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Secuenciador TCP cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EnviarMensajeButton As System.Windows.Forms.Button
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents MensajeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PuertoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ConectarButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DetenerButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FechaProcDTP As System.Windows.Forms.DateTimePicker

End Class
