Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.ASCIIEncoding

Public Class frmCliente

    'Inherits System.Windows.Forms.Form
    'Dim WithEvents WinSockCliente As New TCPCliente

    Dim client As Socket
    Dim host As String
    Dim port As Integer
    Public SocketDesconectar As Boolean
    Public botonConectar As Boolean

    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        SocketDesconectar = False
        botonConectar = True
    End Sub

    Private Sub ConectarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarButton.Click
        Try
            Timer.Enabled = False
            host = IPTextBox.Text
            port = PuertoTextBox.Text
            If (botonConectar) Then
                client = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Dim IP As IPAddress = IPAddress.Parse(host)
                Dim xIpEndPoint As IPEndPoint = New IPEndPoint(IP, port)
                client.BeginConnect(xIpEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)
                botonConectar = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "TCP Cliente")
            botonConectar = True
        Finally
            Timer.Enabled = True
        End Try

    End Sub

    Private Sub EnviarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarMensajeButton.Click
        Try
            Timer.Enabled = False
            Dim bytes As Byte() = ASCII.GetBytes(MensajeTextBox.Text)
            client.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), client)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "TCP Cliente")
        Finally
            SocketDesconectar = True
            Timer.Enabled = True
        End Try
    End Sub

    Private Sub OnConnect(ByVal ar As IAsyncResult)
        Try
            client.EndConnect(ar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "TCP Cliente")
            botonConectar = True
        End Try
    End Sub

    Private Sub OnSend(ByVal ar As IAsyncResult)
        Try
            client.EndSend(ar)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        End
    End Sub

    Private Sub Controles(ByVal Conectar As Boolean)
        If (Conectar) Then
            ConectarButton.Enabled = True
        Else
            ConectarButton.Enabled = False
        End If
    End Sub

    Private Sub Timer_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer.Elapsed
        Timer.Enabled = False
        If (SocketDesconectar = True) Then
            client.Close()
            SocketDesconectar = False
            botonConectar = True
        End If
        Controles(botonConectar)
        Timer.Enabled = True
    End Sub

    'Private Sub WinSockCliente_DatosRecibidos(ByVal datos As String) Handles WinSockCliente.DatosRecibidos
    '    MsgBox("El servidor envio el siguiente mensaje: " & datos)
    'End Sub

    'Private Sub WinSockCliente_ConexionTerminada() Handles WinSockCliente.ConexionTerminada
    '    MsgBox("Finalizo la conexion")
    '    'Habilito la posibilidad de una reconexion

    '    IPTextBox.Enabled = True
    '    PuertoTextBox.Enabled = True
    '    ConectarButton.Enabled = True

    '    'Deshabilito la posibilidad de enviar mensajes
    '    EnviarMensajeButton.Enabled = False
    '    MensajeTextBox.Enabled = False

    'End Sub

    'Private Sub EnviarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarMensajeButton.Click
    '    'Envio lo que esta escrito en la caja de texto del mensaje
    '    WinSockCliente.EnviarDatos(MensajeTextBox.Text)
    'End Sub

    'Private Sub ConectarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarButton.Click
    '    'With WinSockCliente
    '    '    'Determino a donde se quiere conectar el usuario
    '    '    .IPDelHost = IPTextBox.Text
    '    '    .PuertoDelHost = PuertoTextBox.Text
    '    '    'Me conecto
    '    '    .Conectar()
    '    'End With

    '    ''Deshabilito la posibilidad de conexion
    '    'IPTextBox.Enabled = False
    '    'PuertoTextBox.Enabled = False
    '    'ConectarButton.Enabled = False
    '    'DetenerButton.Enabled = True

    '    ''Habilito la posibilidad de enviar mensajes
    '    'EnviarMensajeButton.Enabled = True
    '    'MensajeTextBox.Enabled = True

    'End Sub

    'Private Sub DetenerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetenerButton.Click
    '    'With WinSockCliente
    '    '    .Detener()
    '    'End With

    '    IPTextBox.Enabled = True
    '    PuertoTextBox.Enabled = True
    '    ConectarButton.Enabled = True
    '    DetenerButton.Enabled = False

    '    'Deshabilito la posibilidad de enviar mensajes
    '    EnviarMensajeButton.Enabled = False
    '    MensajeTextBox.Enabled = False

    'End Sub

End Class
