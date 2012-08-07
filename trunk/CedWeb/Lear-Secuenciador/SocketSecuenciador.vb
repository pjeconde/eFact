Imports System.IO
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Sockets
Imports System.Globalization
Imports System
Imports System.Threading

Public Class SocketSecuenciador

    Dim server As Socket
    Dim client As Socket
    Dim bytes As Byte()

    Public DetencionPermitida As Boolean
    Public ContadorDiario As Integer
    Public ContadorDiarioFecha As DateTime

    Public Sub DoWork()
        DetencionPermitida = False
        ContadorDiarioFecha = DateTime.Now
        OnStart()
    End Sub

    Private Sub OnAccept(ByVal ar As IAsyncResult)
        Try
            client = server.EndAccept(ar)
            DetencionPermitida = False
            bytes = New Byte(CInt(TCPCantBytesBuffer)) {}
            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnReceive), client)
        Catch ex As Exception
            EscribirLog("[OnAccept]", "Mensaje: " & ex.Message)
        End Try
    End Sub

    Private Sub OnStart()
        Try
            server = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim xEndpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, TCPPuerto)
            server.Bind(xEndpoint)
            server.Listen(1)
            server.BeginAccept(New AsyncCallback(AddressOf OnAccept), vbNull)
        Catch ex As Exception
            EscribirLog("[OnStart]", "Mensaje: " & ex.Message)
        Finally
            DetencionPermitida = True
        End Try
    End Sub

    Private Sub OnReceive(ByVal ar As IAsyncResult)
        Try
            DetencionPermitida = False
            client = ar.AsyncState
            client.EndReceive(ar)
            client.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnReceive), client)
            Dim a As String
            a = System.Text.ASCIIEncoding.ASCII.GetString(bytes)
            Dim fs As System.IO.FileStream
            If Date.Now.ToString("yyyyMMdd") <> ContadorDiarioFecha.ToString("yyyyMMdd") Then
                ContadorDiario = 1
            Else
                ContadorDiario += 1
            End If
            ContadorDiarioFecha = DateTime.Now
            fs = System.IO.File.Create(DirectorioArchivos + "\RecibidosSinProcesar\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "-" + ContadorDiario.ToString("00000") + ".txt")
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()
            client.Send(System.Text.ASCIIEncoding.ASCII.GetBytes("ACK"))
            Array.Clear(bytes, 0, CInt(TCPCantBytesBuffer))
        Catch ex As Exception
            EscribirLog("[OnReceive]", "Mensaje: " + ex.Message)
        Finally
            DetencionPermitida = True
        End Try
    End Sub

    Public Sub DetenerSocket()
        Try
            If (client IsNot Nothing) Then
                client.Close()
            End If
            server.Close()
        Catch ex As Exception
            EscribirLog("[DetenerSocket]", "Mensaje: " + ex.Message)
        End Try
    End Sub

    Private Sub ReiniciarSocket()
        server.Close()
        OnStart()
    End Sub

    Private Sub EscribirLog(ByVal evento As String, ByVal texto As String)
        On Error Resume Next
        Dim t As String = ""
        Do While True
            FileOpen(11, CStr(ArchLog & Now.ToString("yyyyMMdd") & ".log"), OpenMode.Append, OpenAccess.Write)
            If Err.Number <> 0 Then
                FileClose(11)
                Err.Clear()
                If t <> CStr(TimeValue(Now)) Then
                    'Me.MensajeTextBox.Text = "Esperando liberacion de archivo de Log. " & Now.ToString("HH:mm:ss")
                    'Me.MensajeTextBox.Refresh()
                    t = CStr(TimeValue(Now))
                End If
            Else
                Dim Linea As String
                Linea = Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & evento & " " & texto & vbNewLine
                Print(11, Linea & vbNewLine)
                FileClose(11)
                Exit Do
            End If
        Loop
    End Sub

End Class
