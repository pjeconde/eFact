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
        'Impre2
    End Sub

    Private Sub AceptarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AceptarButton.Click
        SerialPuerto = SerialPuertoTextBox.Text
        SerialBaudRate = SerialBaudRateTextBox.Text
        SerialParity = SerialParityTextBox.Text
        SerialDataBits = SerialDataBitsTextBox.Text
        SerialStopBits = SerialStopBitsTextBox.Text

        TCPIP = TCPIPTextBox.Text
        TCPPuerto = TCPPuertoTextBox.Text
        TCPCantBytesBuffer = TCPCantBytesBufferTextBox.Text

        Arch1 = ArchivoDatos1TextBox.Text
        Arch2 = ArchivoDatos2TextBox.Text

        ArchTempSec = ArchivoTempSecuenciasTextBox.Text

        DirContingencia = DirectorioContingencia1TextBox.Text
        DirContingencia2 = DirectorioContingencia2TextBox.Text
        DirectorioArchivos = DirectorioArchivosHisTextBox.Text

        'Impre1
        'Impre2

        GrabarConfiguracion()
    End Sub
End Class