<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Me.BotonesPanel = New System.Windows.Forms.Panel
        Me.AceptarButton = New System.Windows.Forms.Button
        Me.SalirButton = New System.Windows.Forms.Button
        Me.ParametrosPanel = New System.Windows.Forms.Panel
        Me.TCPRadioButton = New System.Windows.Forms.RadioButton
        Me.SerialRadioButton = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TCPIPTextBox = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TCPPuertoTextBox = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.SerialStopBitsTextBox = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.SerialDataBitsTextBox = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.SerialParityTextBox = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.SerialPuertoTextBox = New System.Windows.Forms.TextBox
        Me.SerialBaudRateTextBox = New System.Windows.Forms.TextBox
        Me.ArchivoTempSecuenciasTextBox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DirectorioArchivosHisTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ArchivoDatos2TextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ArchivoDatos1TextBox = New System.Windows.Forms.TextBox
        Me.DirectorioContingencia2TextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DirectorioContingencia1TextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Header22TextBox = New System.Windows.Forms.TextBox
        Me.Header21TextBox = New System.Windows.Forms.TextBox
        Me.Header20TextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Header12TextBox = New System.Windows.Forms.TextBox
        Me.Header11TextBox = New System.Windows.Forms.TextBox
        Me.Header10TextBox = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TCPCantBytesBufferTextBox = New System.Windows.Forms.TextBox
        Me.BotonesPanel.SuspendLayout()
        Me.ParametrosPanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BotonesPanel
        '
        Me.BotonesPanel.Controls.Add(Me.AceptarButton)
        Me.BotonesPanel.Controls.Add(Me.SalirButton)
        Me.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BotonesPanel.Location = New System.Drawing.Point(0, 377)
        Me.BotonesPanel.Name = "BotonesPanel"
        Me.BotonesPanel.Size = New System.Drawing.Size(784, 47)
        Me.BotonesPanel.TabIndex = 44
        '
        'AceptarButton
        '
        Me.AceptarButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.AceptarButton.Location = New System.Drawing.Point(0, 0)
        Me.AceptarButton.Name = "AceptarButton"
        Me.AceptarButton.Size = New System.Drawing.Size(128, 47)
        Me.AceptarButton.TabIndex = 30
        Me.AceptarButton.Text = "Aceptar"
        Me.AceptarButton.UseVisualStyleBackColor = True
        '
        'SalirButton
        '
        Me.SalirButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.SalirButton.Location = New System.Drawing.Point(656, 0)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(128, 47)
        Me.SalirButton.TabIndex = 29
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'ParametrosPanel
        '
        Me.ParametrosPanel.Controls.Add(Me.TCPRadioButton)
        Me.ParametrosPanel.Controls.Add(Me.SerialRadioButton)
        Me.ParametrosPanel.Controls.Add(Me.GroupBox2)
        Me.ParametrosPanel.Controls.Add(Me.GroupBox1)
        Me.ParametrosPanel.Controls.Add(Me.ArchivoTempSecuenciasTextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label8)
        Me.ParametrosPanel.Controls.Add(Me.Label7)
        Me.ParametrosPanel.Controls.Add(Me.DirectorioArchivosHisTextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label6)
        Me.ParametrosPanel.Controls.Add(Me.ArchivoDatos2TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label5)
        Me.ParametrosPanel.Controls.Add(Me.ArchivoDatos1TextBox)
        Me.ParametrosPanel.Controls.Add(Me.DirectorioContingencia2TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label4)
        Me.ParametrosPanel.Controls.Add(Me.DirectorioContingencia1TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label3)
        Me.ParametrosPanel.Controls.Add(Me.Header22TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Header21TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Header20TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Label2)
        Me.ParametrosPanel.Controls.Add(Me.Label1)
        Me.ParametrosPanel.Controls.Add(Me.Header12TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Header11TextBox)
        Me.ParametrosPanel.Controls.Add(Me.Header10TextBox)
        Me.ParametrosPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParametrosPanel.Location = New System.Drawing.Point(0, 0)
        Me.ParametrosPanel.Name = "ParametrosPanel"
        Me.ParametrosPanel.Size = New System.Drawing.Size(784, 377)
        Me.ParametrosPanel.TabIndex = 45
        '
        'TCPRadioButton
        '
        Me.TCPRadioButton.AutoSize = True
        Me.TCPRadioButton.Location = New System.Drawing.Point(458, 12)
        Me.TCPRadioButton.Name = "TCPRadioButton"
        Me.TCPRadioButton.Size = New System.Drawing.Size(172, 17)
        Me.TCPRadioButton.TabIndex = 71
        Me.TCPRadioButton.Text = "Habilitar Comunicación TCP/IP"
        Me.TCPRadioButton.UseVisualStyleBackColor = True
        '
        'SerialRadioButton
        '
        Me.SerialRadioButton.AutoSize = True
        Me.SerialRadioButton.Checked = True
        Me.SerialRadioButton.Location = New System.Drawing.Point(12, 15)
        Me.SerialRadioButton.Name = "SerialRadioButton"
        Me.SerialRadioButton.Size = New System.Drawing.Size(162, 17)
        Me.SerialRadioButton.TabIndex = 70
        Me.SerialRadioButton.TabStop = True
        Me.SerialRadioButton.Text = "Habilitar Comunicación Serial"
        Me.SerialRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TCPCantBytesBufferTextBox)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TCPIPTextBox)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TCPPuertoTextBox)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(443, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(329, 79)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametros de Comunicación TCP/IP"
        '
        'TCPIPTextBox
        '
        Me.TCPIPTextBox.Location = New System.Drawing.Point(75, 46)
        Me.TCPIPTextBox.Name = "TCPIPTextBox"
        Me.TCPIPTextBox.Size = New System.Drawing.Size(150, 20)
        Me.TCPIPTextBox.TabIndex = 77
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 76
        Me.Label15.Text = "Host o IP:"
        '
        'TCPPuertoTextBox
        '
        Me.TCPPuertoTextBox.Location = New System.Drawing.Point(75, 18)
        Me.TCPPuertoTextBox.Name = "TCPPuertoTextBox"
        Me.TCPPuertoTextBox.Size = New System.Drawing.Size(60, 20)
        Me.TCPPuertoTextBox.TabIndex = 75
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(28, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = "Puerto:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.SerialStopBitsTextBox)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.SerialDataBitsTextBox)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.SerialParityTextBox)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.SerialPuertoTextBox)
        Me.GroupBox1.Controls.Add(Me.SerialBaudRateTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 80)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros de Comunicación Serial"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(166, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "StopBits:"
        '
        'SerialStopBitsTextBox
        '
        Me.SerialStopBitsTextBox.Location = New System.Drawing.Point(221, 50)
        Me.SerialStopBitsTextBox.Name = "SerialStopBitsTextBox"
        Me.SerialStopBitsTextBox.Size = New System.Drawing.Size(60, 20)
        Me.SerialStopBitsTextBox.TabIndex = 76
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "DataBits:"
        '
        'SerialDataBitsTextBox
        '
        Me.SerialDataBitsTextBox.Location = New System.Drawing.Point(71, 50)
        Me.SerialDataBitsTextBox.Name = "SerialDataBitsTextBox"
        Me.SerialDataBitsTextBox.Size = New System.Drawing.Size(60, 20)
        Me.SerialDataBitsTextBox.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(305, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Parity:"
        '
        'SerialParityTextBox
        '
        Me.SerialParityTextBox.Location = New System.Drawing.Point(347, 19)
        Me.SerialParityTextBox.Name = "SerialParityTextBox"
        Me.SerialParityTextBox.Size = New System.Drawing.Size(60, 20)
        Me.SerialParityTextBox.TabIndex = 72
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Puerto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(154, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Baud Rate:"
        '
        'SerialPuertoTextBox
        '
        Me.SerialPuertoTextBox.Location = New System.Drawing.Point(71, 20)
        Me.SerialPuertoTextBox.Name = "SerialPuertoTextBox"
        Me.SerialPuertoTextBox.Size = New System.Drawing.Size(60, 20)
        Me.SerialPuertoTextBox.TabIndex = 69
        '
        'SerialBaudRateTextBox
        '
        Me.SerialBaudRateTextBox.Location = New System.Drawing.Point(221, 20)
        Me.SerialBaudRateTextBox.Name = "SerialBaudRateTextBox"
        Me.SerialBaudRateTextBox.Size = New System.Drawing.Size(60, 20)
        Me.SerialBaudRateTextBox.TabIndex = 68
        '
        'ArchivoTempSecuenciasTextBox
        '
        Me.ArchivoTempSecuenciasTextBox.Location = New System.Drawing.Point(312, 335)
        Me.ArchivoTempSecuenciasTextBox.Name = "ArchivoTempSecuenciasTextBox"
        Me.ArchivoTempSecuenciasTextBox.Size = New System.Drawing.Size(460, 20)
        Me.ArchivoTempSecuenciasTextBox.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(130, 338)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Archivo Temporario de Secuencias:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(143, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Directorio de Archivos Históricos:"
        '
        'DirectorioArchivosHisTextBox
        '
        Me.DirectorioArchivosHisTextBox.Location = New System.Drawing.Point(312, 309)
        Me.DirectorioArchivosHisTextBox.Name = "DirectorioArchivosHisTextBox"
        Me.DirectorioArchivosHisTextBox.Size = New System.Drawing.Size(460, 20)
        Me.DirectorioArchivosHisTextBox.TabIndex = 60
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(205, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Archivo de Datos 2:"
        '
        'ArchivoDatos2TextBox
        '
        Me.ArchivoDatos2TextBox.Location = New System.Drawing.Point(312, 221)
        Me.ArchivoDatos2TextBox.Name = "ArchivoDatos2TextBox"
        Me.ArchivoDatos2TextBox.Size = New System.Drawing.Size(460, 20)
        Me.ArchivoDatos2TextBox.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(205, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Archivo de Datos 1:"
        '
        'ArchivoDatos1TextBox
        '
        Me.ArchivoDatos1TextBox.Location = New System.Drawing.Point(312, 134)
        Me.ArchivoDatos1TextBox.Name = "ArchivoDatos1TextBox"
        Me.ArchivoDatos1TextBox.Size = New System.Drawing.Size(460, 20)
        Me.ArchivoDatos1TextBox.TabIndex = 56
        '
        'DirectorioContingencia2TextBox
        '
        Me.DirectorioContingencia2TextBox.Location = New System.Drawing.Point(312, 272)
        Me.DirectorioContingencia2TextBox.Name = "DirectorioContingencia2TextBox"
        Me.DirectorioContingencia2TextBox.Size = New System.Drawing.Size(460, 20)
        Me.DirectorioContingencia2TextBox.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(121, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Directorio de Archivo Contingencia 2:"
        '
        'DirectorioContingencia1TextBox
        '
        Me.DirectorioContingencia1TextBox.Location = New System.Drawing.Point(312, 186)
        Me.DirectorioContingencia1TextBox.Name = "DirectorioContingencia1TextBox"
        Me.DirectorioContingencia1TextBox.Size = New System.Drawing.Size(460, 20)
        Me.DirectorioContingencia1TextBox.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(123, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Directorio de Archivo Contingencia 1:"
        '
        'Header22TextBox
        '
        Me.Header22TextBox.Location = New System.Drawing.Point(622, 246)
        Me.Header22TextBox.Name = "Header22TextBox"
        Me.Header22TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header22TextBox.TabIndex = 51
        '
        'Header21TextBox
        '
        Me.Header21TextBox.Location = New System.Drawing.Point(468, 246)
        Me.Header21TextBox.Name = "Header21TextBox"
        Me.Header21TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header21TextBox.TabIndex = 50
        '
        'Header20TextBox
        '
        Me.Header20TextBox.Location = New System.Drawing.Point(312, 247)
        Me.Header20TextBox.Name = "Header20TextBox"
        Me.Header20TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header20TextBox.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Encabezados Archivo 2:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Encabezados Archivo 1:"
        '
        'Header12TextBox
        '
        Me.Header12TextBox.Location = New System.Drawing.Point(622, 160)
        Me.Header12TextBox.Name = "Header12TextBox"
        Me.Header12TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header12TextBox.TabIndex = 46
        '
        'Header11TextBox
        '
        Me.Header11TextBox.Location = New System.Drawing.Point(468, 160)
        Me.Header11TextBox.Name = "Header11TextBox"
        Me.Header11TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header11TextBox.TabIndex = 45
        '
        'Header10TextBox
        '
        Me.Header10TextBox.Location = New System.Drawing.Point(312, 160)
        Me.Header10TextBox.Name = "Header10TextBox"
        Me.Header10TextBox.Size = New System.Drawing.Size(150, 20)
        Me.Header10TextBox.TabIndex = 44
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(153, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Cant. Bytes Buffer:"
        '
        'TCPCantBytesBufferTextBox
        '
        Me.TCPCantBytesBufferTextBox.Location = New System.Drawing.Point(253, 19)
        Me.TCPCantBytesBufferTextBox.Name = "TCPCantBytesBufferTextBox"
        Me.TCPCantBytesBufferTextBox.Size = New System.Drawing.Size(60, 20)
        Me.TCPCantBytesBufferTextBox.TabIndex = 79
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 424)
        Me.Controls.Add(Me.ParametrosPanel)
        Me.Controls.Add(Me.BotonesPanel)
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuración"
        Me.BotonesPanel.ResumeLayout(False)
        Me.ParametrosPanel.ResumeLayout(False)
        Me.ParametrosPanel.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BotonesPanel As System.Windows.Forms.Panel
    Friend WithEvents AceptarButton As System.Windows.Forms.Button
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents ParametrosPanel As System.Windows.Forms.Panel
    Friend WithEvents ArchivoTempSecuenciasTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DirectorioArchivosHisTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ArchivoDatos2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ArchivoDatos1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents DirectorioContingencia2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DirectorioContingencia1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Header22TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Header21TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Header20TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Header12TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Header11TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Header10TextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SerialPuertoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SerialBaudRateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SerialStopBitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SerialDataBitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SerialParityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TCPIPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TCPPuertoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SerialRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TCPRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TCPCantBytesBufferTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
