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
    Public Detenido As Boolean
    Public Renglon As Int32

    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Detenido = True
        ConectarButton.Enabled = True
        DetenerButton.Enabled = False
    End Sub

    Private Sub ConectarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConectarButton.Click
        Detenido = False
        Controles()
        Renglon = 1
        Conectar()
        Do While Detenido = False
            Enviar()
            System.Threading.Thread.Sleep(4000)
        Loop
    End Sub

    Private Sub Conectar()
        Try
            SoyEnvio = False
            host = IPTextBox.Text
            port = PuertoTextBox.Text
            client = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim IP As IPAddress = IPAddress.Parse(host)
            Dim xIpEndPoint As IPEndPoint = New IPEndPoint(IP, port)
            client.BeginConnect(xIpEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)
        Catch ex As Exception
            Debug.WriteLine("ER - Renglon: Conectar " & Renglon & " " & ex.Message)
        End Try
    End Sub

    Private Sub EnviarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarMensajeButton.Click
        Enviar()
    End Sub

    Dim bytes As Byte()
    Dim SoyEnvio As Boolean
    Private Sub Enviar()
        Try
            SoyEnvio = True
            Dim bytes As Byte() = ASCII.GetBytes("PINRANGER 02-May-12  " & Date.Now.ToString("HH:mm") & " MEXICO         " & Renglon.ToString("0000") & " 20122BCHDC2C012388 " + vbNewLine)
            client.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), client)
            'client.Send(bytes, 0, bytes.Length, SocketFlags.None)
            Debug.WriteLine("OK - Renglon: " & Renglon)
        Catch ex As Exception
            Conectar()
            Debug.WriteLine("ER - Renglon: " & Renglon & " " & ex.Message)
        End Try
    End Sub

    Private Sub OnConnect(ByVal ar As IAsyncResult)
        Try
            client.EndConnect(ar)
        Catch ex As Exception
            Debug.WriteLine("ER - Renglon: OnConectar " & Renglon & " " & ex.Message)
        End Try
    End Sub

    Private Sub OnSend(ByVal ar As IAsyncResult)
        Try
            client.EndSend(ar)
            If (SoyEnvio) Then
                Renglon = Renglon + 1
            End If
        Catch ex As Exception
            Debug.WriteLine("ER - Renglon: OnSend: " & Renglon)
        End Try
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        End
    End Sub

    Private Sub Controles()
        If (Detenido = True) Then
            ConectarButton.Enabled = True
            DetenerButton.Enabled = False
        Else
            ConectarButton.Enabled = False
            DetenerButton.Enabled = True
        End If
    End Sub

    Private Sub DetenerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetenerButton.Click
        client.Close()
        Detenido = True
    End Sub
End Class
