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
        Me.EnviarMensajeButton = New System.Windows.Forms.Button
        Me.SalirButton = New System.Windows.Forms.Button
        Me.MensajeTextBox = New System.Windows.Forms.TextBox
        Me.IPTextBox = New System.Windows.Forms.TextBox
        Me.PuertoTextBox = New System.Windows.Forms.TextBox
        Me.ConectarButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'EnviarMensajeButton
        '
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
        Me.IPTextBox.Size = New System.Drawing.Size(150, 20)
        Me.IPTextBox.TabIndex = 3
        Me.IPTextBox.Text = "127.0.0.1"
        '
        'PuertoTextBox
        '
        Me.PuertoTextBox.AcceptsReturn = True
        Me.PuertoTextBox.Location = New System.Drawing.Point(274, 15)
        Me.PuertoTextBox.Name = "PuertoTextBox"
        Me.PuertoTextBox.Size = New System.Drawing.Size(73, 20)
        Me.PuertoTextBox.TabIndex = 4
        Me.PuertoTextBox.Text = "8080"
        '
        'ConectarButton
        '
        Me.ConectarButton.Location = New System.Drawing.Point(399, 12)
        Me.ConectarButton.Name = "ConectarButton"
        Me.ConectarButton.Size = New System.Drawing.Size(206, 23)
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
        Me.Label2.Location = New System.Drawing.Point(227, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Puerto:"
        '
        'frmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 386)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConectarButton)
        Me.Controls.Add(Me.PuertoTextBox)
        Me.Controls.Add(Me.IPTextBox)
        Me.Controls.Add(Me.MensajeTextBox)
        Me.Controls.Add(Me.SalirButton)
        Me.Controls.Add(Me.EnviarMensajeButton)
        Me.Name = "frmCliente"
        Me.Text = "TCP cliente"
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

End Class
