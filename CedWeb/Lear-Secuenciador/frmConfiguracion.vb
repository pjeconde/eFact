Public Class frmConfiguracion

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub frmConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LeerConfiguración()

        SerialPuertoTextBox.Text = SerialPuerto
        SerialBaudRateTextBox.Text = SerialBaudRate
        SerialParityTextBox.Text = SerialParity
        SerialDataBitsTextBox.Text = SerialDataBits
        SerialStopBitsTextBox.Text = SerialStopBits

        If (TCPHabilitado) Then
            TCPRadioButton.Checked = True
            SerialRadioButton.Checked = False
        Else
            SerialRadioButton.Checked = True
            TCPRadioButton.Checked = False
        End If

        TCPIPTextBox.Text = TCPIP
        TCPPuertoTextBox.Text = TCPPuerto
        TCPCantBytesBufferTextBox.Text = TCPCantBytesBuffer

        ArchivoDatos1TextBox.Text = Arch1
        ArchivoDatos2TextBox.Text = Arch2

        ArchivoTempSecuenciasTextBox.Text = ArchTempSec

        DirectorioContingencia1TextBox.Text = DirContingencia
        DirectorioContingencia2TextBox.Text = DirContingencia2
        DirectorioArchivosHisTextBox.Text = DirectorioArchivos

        Header10TextBox.Text = Header1(0)
        Header11TextBox.Text = Header1(1)
        Header12TextBox.Text = Header1(2)

        Header20TextBox.Text = Header2(0)
        Header21TextBox.Text = Header2(1)
        Header22TextBox.Text = Header2(2)

        'Impre1
        For Each impresora As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboBoxImpreError1.Items.Add(impresora)
        Next
        ComboBoxImpreError1.Text = Impre1

        'Impre2
        For Each impresora As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboBoxImpreError2.Items.Add(impresora)
        Next
        ComboBoxImpreError2.Text = Impre2

        ArchLogTextBox.Text = ArchLog
        PathArchINITextBox.Text = PathArchINI
    End Sub

    Private Sub AceptarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AceptarButton.Click

        SerialPuerto = SerialPuertoTextBox.Text
        SerialBaudRate = SerialBaudRateTextBox.Text
        SerialParity = SerialParityTextBox.Text
        SerialDataBits = SerialDataBitsTextBox.Text
        SerialStopBits = SerialStopBitsTextBox.Text

        If (TCPRadioButton.Checked = True) Then
            TCPHabilitado = True
        Else
            TCPHabilitado = False
        End If
        TCPIP = TCPIPTextBox.Text
        TCPPuerto = TCPPuertoTextBox.Text
        TCPCantBytesBuffer = TCPCantBytesBufferTextBox.Text

        Arch1 = ArchivoDatos1TextBox.Text
        Arch2 = ArchivoDatos2TextBox.Text

        ArchTempSec = ArchivoTempSecuenciasTextBox.Text

        DirContingencia = DirectorioContingencia1TextBox.Text
        DirContingencia2 = DirectorioContingencia2TextBox.Text
        DirectorioArchivos = DirectorioArchivosHisTextBox.Text

        Impre1 = ComboBoxImpreError1.Text
        Impre2 = ComboBoxImpreError2.Text

        ArchLog = ArchLogTextBox.Text

        GrabarConfiguracion()
        MsgBox("Información guardada satisfactoriamente.", MsgBoxStyle.Information, "Información")
    End Sub

    Private Sub TCPRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCPRadioButton.CheckedChanged
        TCPoSerialCheckedChange()
    End Sub

    Private Sub SerialRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialRadioButton.CheckedChanged
        TCPoSerialCheckedChange()
    End Sub

    Private Sub TCPoSerialCheckedChange()
        If (TCPRadioButton.Checked = True) Then
            TCPGroupBox.Enabled = True
            SerialGroupBox.Enabled = False
        Else
            SerialGroupBox.Enabled = True
            TCPGroupBox.Enabled = False
        End If
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        Me.Close()
    End Sub
End Class