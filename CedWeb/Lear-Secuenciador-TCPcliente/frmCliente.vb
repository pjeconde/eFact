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
    Public Renglon As Int32

    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        SocketDesconectar = False
        botonConectar = True
    End Sub

    Private Sub ConectarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarButton.Click
        Conectar()
    End Sub

    Private Sub Conectar()
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
            'MessageBox.Show(ex.Message, "TCP Cliente")
            botonConectar = True
        Finally
            'Timer.Enabled = True
        End Try
    End Sub

    Private Sub EnviarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarMensajeButton.Click
        Enviar()
    End Sub

    Private Sub Enviar()
        Try
            Timer.Enabled = False
            Renglon = Renglon + 1
            Dim bytes As Byte() = ASCII.GetBytes("PINRANGER 03-Ene-12  " & Date.Now.ToString("HH:mm") & " MEXICO         " & Renglon.ToString("0000") & " 20122BCHDC2C012388 " + vbNewLine)
            'client.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), client)
            client.Send(bytes, 0, bytes.Length, SocketFlags.None)
            Debug.WriteLine("OK - Renglon: " & Renglon)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "TCP Cliente")
            Debug.WriteLine("ER - Renglon: " & Renglon & " " & ex.Message)
            Renglon = Renglon - 1
            Timer.Enabled = True
        Finally
            SocketDesconectar = True
            client.Close()
        End Try
    End Sub

    Private Sub OnConnect(ByVal ar As IAsyncResult)
        Try
            client.EndConnect(ar)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "TCP Cliente")
            botonConectar = True
        End Try
    End Sub

    Private Sub OnSend(ByVal ar As IAsyncResult)
        Try
            client.EndSend(ar)
        Catch ex As Exception
            Debug.WriteLine("ER - Renglon: OnSend: " & Renglon)
            Renglon = Renglon - 1
        Finally
            Timer.Enabled = True
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
        Conectar()
        If (client.Connected) Then
            Enviar()
            client.Close()
        End If
        If (SocketDesconectar = True) Then
            If (client IsNot Nothing) Then
                client.Close()
            End If
            SocketDesconectar = False
            botonConectar = True
        End If
        Controles(botonConectar)
        Timer.Enabled = True
    End Sub
End Class
