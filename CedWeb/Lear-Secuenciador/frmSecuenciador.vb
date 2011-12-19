Imports Microsoft.VisualBasic
Imports System.IO.Ports.SerialPort
Imports System.IO

Public Class frmSecuenciador
    Inherits System.Windows.Forms.Form
    Dim WithEvents WinSockServer As New TCPServidor()
    'Solo para pruebas
    Dim WithEvents WinSockCliente As New TCPCliente()

    Dim ArchivoTexto As String
    Dim ArchSemaforo As String
    Dim ArchDatos As String
    Dim CadenaContingencia As String
    Dim CadenaGlobal As String
    Dim NombreCola1 As String
    Dim NombreCola2 As String
    Dim ForzarTemporal As Boolean

    Dim NuevaFila As Integer

    Dim DatosDeConfiguracion As String

    ''Nueva modalidad (no utilizada)
    'Dim oFile As System.IO.File
    'Dim oWrite1 As System.IO.StreamWriter   '#1
    'Dim oRead1 As System.IO.StreamReader    '#1

    Public Sub AbreArchivo()
        'Open CStr(DirectorioArchivos & ArchivoTexto) For Append Access Write As #1
        FileOpen(1, CStr(DirectorioArchivos & ArchivoTexto), OpenMode.Append, OpenAccess.Write)
        'oWrite1 = oFile.CreateText(DirectorioArchivos & ArchivoTexto)
    End Sub

    Public Sub AbreArchivoDatos()
        On Error Resume Next
        Err.Clear()
        'Open CStr(DirectorioArchivos & ArchSemaforo) For Input Access Read Shared As #1
        FileOpen(1, CStr(DirectorioArchivos & ArchSemaforo), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        'oRead1 = oFile.OpenText(DirectorioArchivos & ArchSemaforo)
        MsgBox(Err.Number)
        If Err.Number <> 0 Then
            'Me dio error, o sea que el archivo no existe, entonces yo lo creo
            'Open CStr(DirectorioArchivos & ArchSemaforo) For Output Access Write Lock Read Write As #1
            FileOpen(1, CStr(DirectorioArchivos & ArchSemaforo), OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
            Print(1, "SEMAFORO")
            FileClose(1)

            'Open CStr(DirectorioArchivos & ArchDatos) For Append Access Write As #1
            FileOpen(1, CStr(DirectorioArchivos & ArchDatos), OpenMode.Append, OpenAccess.Write)
        End If
    End Sub

    Public Sub CreaNombreArchivo()
        ArchivoTexto = Now.ToString("yyyyMMdd") & ".HST"
    End Sub

    Public Sub GrabaContingencia()
        Dim CadenaContingenciaBPCS As String
        Dim ArchivoTextoC As String
        ArchivoTextoC = Now.ToString("yyyyMMdd") & ".CNG"
        CadenaContingenciaBPCS = Mid(CadenaContingencia, 1, 9) & Now.ToString("yyyyMMdd") & Now.ToString("hhmmss") & _
                          Mid(CadenaContingencia, 28, 14) & Mid(CadenaContingencia, 43, 4) & Mid(CadenaContingencia, 48, 4) & _
                          Mid(CadenaContingencia, 52, 3) & Mid(CadenaContingencia, 55, 4) & Mid(CadenaContingencia, 59, 7)

        Select Case Mid(CadenaContingencia, 1, 9)
            Case Header1(0), Header1(1), Header1(2)
                'Open CStr(DirContingencia & ArchivoTextoC) For Append Access Write Lock Read Write As #4
                FileOpen(4, CStr(DirContingencia & ArchivoTextoC), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
            Case Header2(0), Header2(1), Header2(2)
                'Open CStr(DirContingencia2 & ArchivoTextoC) For Append Access Write Lock Read Write As #4
                FileOpen(4, CStr(DirContingencia2 & ArchivoTextoC), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        End Select
        Print(4, CadenaContingenciaBPCS)    'Print #4, CadenaContingenciaBPCS
        FileClose(4)                        'Close #4
    End Sub

    Public Sub GrabaTemp()
        'Open CStr(ArchTempSec) For Append Access Write Lock Read Write As #3
        FileOpen(3, CStr(ArchTempSec), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        Print(3, CadenaGlobal)       'Print #3, CadenaGlobal
        FileClose(3)                 'Close #3
    End Sub

    Public Sub ImprimeArchivo()
        Dim Valor As Object
        'Close #1
        FileClose(1)
        'Open CStr(DirectorioArchivos & ArchivoTexto & ".bat") For Output As #2
        FileOpen(2, CStr(DirectorioArchivos & ArchivoTexto & ".bat"), OpenMode.Output)

        If NombreCola1 <> "" Then
            Print(2, CStr("COPY " & DirectorioArchivos & ArchivoTexto & ".txt " & NombreCola1))
        End If
        If NombreCola2 <> "" Then
            Print(2, CStr("COPY " & DirectorioArchivos & ArchivoTexto & ".txt " & NombreCola2))
        End If
        FileClose(2)
        If NombreCola1 <> "" Or NombreCola2 <> "" Then
            Valor = Shell(CStr(DirectorioArchivos & ArchivoTexto & ".BAT"), 6)
        End If
    End Sub

    Private Sub BEnviar_Click()
        If (MensajeTextBox.Text = "") Then
            MsgBox("Debe Ingresar un mensaje para enviar.", vbOKOnly + vbInformation)
            Exit Sub
        End If

        If (TCPHabilitado) Then
            If (WinSockServer.Clientes.Count = 0) Then
                WinSockCliente.Conectar()
            End If
            WinSockCliente.EnviarDatos(MensajeTextBox.Text)
        Else
            If Not Puerto.IsOpen Then
                AbrirPuertos()
            End If
            If (MensajeTextBox.Text.Length > 0) Then
                Barra.Items(0).Text = "Enviando: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits.ToString() & "," & Puerto.StopBits.ToString()
                Puerto.WriteLine(MensajeTextBox.Text)
            End If
        End If
    End Sub

    Private Sub AbrirPuertos()
        If (TCPHabilitado) Then
            If (WinSockServer.PuertoDeEscucha = "") Then
                With WinSockServer
                    'Establezco el puerto donde escuchar
                    .PuertoDeEscucha = TCPPuerto
                    'Comienzo la escucha
                    .Escuchar()
                End With
            End If
            If (Not Produccion) Then
                With WinSockCliente
                    .IPDelHost = TCPIP
                    .PuertoDelHost = TCPPuerto
                End With
            End If
        Else
            If Not Puerto.IsOpen Then
                Puerto.PortName = "COM" & SerialPuerto
                Puerto.BaudRate = SerialBaudRate
                If (SerialParity.ToUpper() = "N") Then
                    Puerto.Parity = IO.Ports.Parity.None
                ElseIf (SerialParity.ToUpper() = "E") Then
                    Puerto.Parity = IO.Ports.Parity.Even
                ElseIf (SerialParity.ToUpper() = "M") Then
                    Puerto.Parity = IO.Ports.Parity.Mark
                ElseIf (SerialParity.ToUpper() = "O") Then
                    Puerto.Parity = IO.Ports.Parity.Odd
                ElseIf (SerialParity.ToUpper() = "S") Then
                    Puerto.Parity = IO.Ports.Parity.Space
                End If
                Puerto.DataBits = SerialDataBits
                Puerto.StopBits = SerialStopBits
                Puerto.Open()
            End If
        End If
    End Sub

    Private Sub CerrarPuertos()
        If (TCPHabilitado) Then
            WinSockServer.Cerrar()
        Else
            Puerto.Close()
        End If
    End Sub

    Private Sub BConfigurar_Click()
        If TCPHabilitado Then
            If WinSockServer.Clientes.Count > 0 Then
                MsgBox("Para configurar los parámetros, debe detener la recepcion.", vbOKOnly + vbInformation)
                Exit Sub
            Else
                'Leer nuevamente los parametros por si cambiaron e inicializar las variables.
                frmConfiguracion.Show()
            End If
        Else
            If Puerto.IsOpen Then
                MsgBox("Para configurar los parámetros, debe detener la recepcion.", vbOKOnly + vbInformation)
                Exit Sub
            Else
                'Leer nuevamente los parametros por si cambiaron e inicializar las variables.
                frmConfiguracion.Show()
            End If
        End If
    End Sub

    Private Sub RecibirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibirButton.Click
        If TCPHabilitado Then
            ProcesarTCP()
        Else
            ProcesarSerial()
        End If
    End Sub

    Private Sub ProcesarSerial()
        '        On Error Resume Next
        '        Dim N As Integer
        '        Dim C As String
        '        Dim VR As Integer
        '        Dim Cadena As String
        '        Dim LargoLinea As Integer
        '        Dim Tiempo As String = ""
        '        Dim LineaTexto As String
        '        Dim FechaFila As Date
        '        Dim CadenaFin As String
        '        Dim CadenaBpcs As String

        '        Dim CuentaCaracter As Integer
        '        Dim ErrorCabecera As Boolean
        '        Dim ErrorDigitos As Boolean
        '        Dim TotalCaracter As Integer

        '        ' ''Dim X As Printer
        '        Dim ErrorRed As Boolean
        '        Dim HayDatos As Boolean
        '        Dim CadenaBackup As String
        '        Dim RecuperaDatos As Boolean
        '        Dim Forzar2 As Boolean

        '        FechaFila = Now.ToString("dd/MM/yyyy")

        '        Cadena = ""
        '        N = 0
        '        LargoLinea = 0

        '        AbrirPuertos()

        '        Dim ports As String()

        '        Barra.Items(0).Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        '        ErrorRed = False 'Comienza sin errores de red
        '        HayDatos = False 'Comienza sin datos en el temporal
        '        Forzar2 = False

        '        N = Puerto.BytesToRead()
        '        While N <> 0 Or ForzarTemporal = True
        'Inicio:
        '            If N Or ForzarTemporal = True Then
        '                Forzar2 = ForzarTemporal
        '                If Forzar2 = False Then
        '                    Dim caux As Char
        '                    caux = Convert.ToChar(Puerto.ReadChar())
        '                    C = Convert.ToString(caux)
        '                    C = Chr(CByte(Asc(C)) And CByte(127)) 'le saco el MSB
        '                    If (C <> Chr(10) And C <> Chr(13) And C <> "*") And (Cadena <> "" Or C <> " ") Then
        '                        Cadena = Cadena & C
        '                    End If
        '                    Barra.Items(0).Text = "Recibiendo Datos: " & Cadena
        '                    Me.Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        '                End If

        '                If ((C = "*" Or C = Chr(13)) And (Trim(Cadena) <> "")) Or Forzar2 = True Then
        '                    If Forzar2 = False Then
        '                        If NuevaFila > 1800 Or FechaFila <> Date.Now.ToString("yyyyMMdd") Then
        '                            FechaFila = Date.Now.ToString("yyyyMMdd")
        '                            NuevaFila = 1
        '                            ' ''Grilla.Rows = 1
        '                            ' ''Grilla.Row = 1
        '                            ' ''Grilla.SelStartRow = 2
        '                            ' ''Grilla.SelEndRow = 2
        '                        End If

        '                        'MUESTRO EN LA GRILLA
        '                        'Grilla.AddItem(CStr(NuevaFila) & Chr(9) & _
        '                        Grilla.Rows.Add(Mid(Cadena, 1, 9), _
        '                                      Mid(Cadena, 11, 9), _
        '                                      Mid(Cadena, 22, 5), _
        '                                      Mid(Cadena, 28, 14), _
        '                                      Mid(Cadena, 43, 4), _
        '                                      Mid(Cadena, 48, 4), _
        '                                      Mid(Cadena, 52, 3), _
        '                                      Mid(Cadena, 55, 4), _
        '                                      Mid(Cadena, 59, 7))
        '                        ' ''Grilla.Col = 1
        '                        ' ''Grilla.Row = NuevaFila
        '                        ' ''Grilla.SelStartCol = 1
        '                        ' ''Grilla.SelEndCol = 9
        '                        ' ''Grilla.SelStartRow = NuevaFila
        '                        ' ''Grilla.SelEndRow = NuevaFila
        '                        If NuevaFila > 22 Then
        '                            ' ''Grilla.TopRow = NuevaFila - 22
        '                        End If
        '                        NuevaFila = NuevaFila + 1
        '                    End If 'if forzar2 = false
        '                    If Forzar2 = True Then
        '                        ForzarTemporal = False
        '                        Forzar2 = False
        '                        BBTemp.Visible = False
        '                        BBTemp.Enabled = False
        '                    End If
        '                    Err.Clear()
        '                    'Procedimiento que graba la informacion en el formato que BPCS precisa, pero en el disco local
        '                    CadenaContingencia = Cadena
        '                    If CadenaContingencia <> "" Then
        '                        Call GrabaContingencia()
        '                    End If
        '                    'Validacion para ver si el archivo temporario tiene datos
        '                    Err.Clear()
        '                    CadenaBackup = Cadena

        '                    'Open ArchTempSec For Input As #3
        '                    FileOpen(3, ArchTempSec, OpenMode.Input)
        '                    If Err.Number <> 0 Then
        '                        'el archivo temporario no tiene datos
        '                        FileClose(3)
        '                        ''Err.Clear()
        '                        HayDatos = False
        '                        BBTemp.Visible = False
        '                        BBTemp.Enabled = False
        '                    Else
        '                        HayDatos = True
        '                        BBTemp.Visible = True
        '                        BBTemp.Enabled = True
        '                    End If
        '                    Err.Clear()

        '                    Call CreaNombreArchivo()
        '                    'Open CStr(DirectorioArchivos & ArchivoTexto) For Append Access Write Lock Read Write As #1
        '                    FileOpen(1, CStr(DirectorioArchivos & ArchivoTexto), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        '                    If Err.Number <> 0 Then
        '                        'El enlace todavía no está restablecido
        '                        FileClose(1)
        '                        Err.Clear()
        '                        CadenaGlobal = Cadena
        '                        ErrorRed = True
        '                        FileClose(3)
        '                        If Cadena <> "" Then
        '                            Barra.Items(0).Text = "Guardando informacion temporal en " & ArchTempSec
        '                            Call GrabaTemp()
        '                        End If
        '                        Cadena = ""
        '                        Barra.Items(0).Text = ""
        '                        BBTemp.Visible = True
        '                        BBTemp.Enabled = True
        '                    Else
        '                        FileClose(1)
        '                        ErrorRed = False
        '                    End If

        '                    Do While ErrorRed = False 'LOOP creado para incluir el grabado de las secuencias en el archivo
        '                        If HayDatos = True Then
        '                            If EOF(3) = False Then
        '                                FileGet(3, Cadena)        'Input #3, Cadena
        '                            Else
        '                                HayDatos = False
        '                                FileClose(3)
        '                                Kill(ArchTempSec)
        '                                ErrorRed = True
        '                                Cadena = CadenaBackup
        '                                BBTemp.Visible = False
        '                                BBTemp.Enabled = False
        '                                If Cadena = "" Then GoTo Inicio
        '                            End If
        '                        Else
        '                            Cadena = CadenaBackup
        '                            FileClose(3)
        '                            Kill(ArchTempSec)       ' Borrar Archivo temporal
        '                            ErrorRed = True         'para que salga del loop despues de procesar la variable Cadena
        '                            BBTemp.Visible = False
        '                            BBTemp.Enabled = False
        '                        End If

        '                        CadenaBpcs = Mid(Cadena, 1, 9) & Format(Now, "yyyymmdd") & Format(Now, "hhnnss") & _
        '                                     Mid(Cadena, 28, 14) & Mid(Cadena, 43, 4) & Mid(Cadena, 48, 4) & _
        '                                     Mid(Cadena, 52, 3) & Mid(Cadena, 55, 4) & Mid(Cadena, 59, 7)

        '                        'GUARDO EN HISTORICO
        '                        Call CreaNombreArchivo()
        '                        Barra.Items(0).Text = "Guardando informacion historica en " & DirectorioArchivos & ArchivoTexto

        '                        Do While True
        '                            'Open CStr(DirectorioArchivos & ArchivoTexto) For Append Access Write Lock Read Write As #1
        '                            FileOpen(1, CStr(DirectorioArchivos & ArchivoTexto), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        '                            If Err.Number <> 0 Then
        '                                FileClose(1)
        '                                Err.Clear()
        '                                If Tiempo <> CStr(TimeValue(Now)) Then
        '                                    Barra.Items(0).Text = "Esperando liberacion de archivo " & DirectorioArchivos & ArchivoTexto & ". " & Now.ToString("hh:mm:ss")
        '                                    Tiempo = CStr(TimeValue(Now))
        '                                End If
        '                                Me.Refresh()
        '                                Me.Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        '                            Else
        '                                Print(1, Cadena)
        '                                FileClose(1)
        '                                Barra.Items(0).Text = ""
        '                                Exit Do
        '                            End If
        '                        Loop

        '                        ' FIN REEMPLAZO POR SER ARCHIVO DE RED
        '                        Barra.Items(0).Text = ""
        '                        'Rutina de verificacion e impresion de cabecera y numero de secuencia

        '                        ErrorCabecera = True
        '                        For CuentaCaracter = 0 To 2
        '                            If Mid(Cadena, 1, 9) = Header1(CuentaCaracter) Then ErrorCabecera = False
        '                        Next CuentaCaracter

        '                        For CuentaCaracter = 0 To 2
        '                            If Mid(Cadena, 1, 9) = Header2(CuentaCaracter) Then ErrorCabecera = False
        '                        Next CuentaCaracter


        '                        ErrorDigitos = False
        '                        For CuentaCaracter = 0 To 3
        '                            If Mid(Cadena, 43 + CuentaCaracter, 1) < "0" Or Mid(Cadena, 43 + CuentaCaracter, 1) > "9" Then ErrorDigitos = True
        '                        Next

        '                        ' ''If ErrorCabecera = True Or ErrorDigitos = True Then
        '                        ' ''    For Each X In Printers
        '                        ' ''        If X.DeviceName = Impre1 Or X.DeviceName = Impre2 Then
        '                        ' ''            Printer = X
        '                        ' ''            Printer.Font = "Arial"
        '                        ' ''            Printer.FontBold = True
        '                        ' ''            Printer.FontSize = 32
        '                        ' ''            Printer.Print("____________________________")
        '                        ' ''            Printer.Print("---ERROR DE COMUNICACION---")
        '                        ' ''            Printer.Print("____________________________")
        '                        ' ''            Printer.FontSize = 24
        '                        ' ''            Printer.Print("Fecha: " & Format(Date.Now, "dd/mm/yyyy") & "  Hora: " & Format(Date.Now, "hh:mm:ss AMPM"))
        '                        ' ''            Printer.Print()
        '                        ' ''            Printer.FontSize = 32
        '                        ' ''            Printer.Print("---INFORMACION RECIBIDA---")
        '                        ' ''            Printer.FontSize = 14
        '                        ' ''            Printer.Print()
        '                        ' ''            Printer.Print(Cadena)
        '                        ' ''            Printer.EndDoc()
        '                        ' ''        End If
        '                        ' ''    Next
        '                        ' ''End If

        '                        'Grabo segun cabecera
        '                        On Error Resume Next
        '                        'MsgBox Mid(Cadena, 1, 9)
        '                        Select Case Mid(Cadena, 1, 9)
        '                            Case Header1(0), Header1(1), Header1(2)
        '                                Barra.Items(0).Text = "Guardando informacion en archivo de datos " & Arch1 & ". " & Now.ToString("hh:mm:ss")
        '                                Do While True
        '                                    'Open CStr(Arch1) For Append Access Write Lock Read Write As #2
        '                                    FileOpen(2, CStr(Arch1), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        '                                    If Err.Number <> 0 Then
        '                                        FileClose(2)
        '                                        Err.Clear()
        '                                        If Tiempo <> Now.ToString("hh:mm:ss") Then
        '                                            Barra.Items(0).Text = "Esperando liberacion de archivo " & Arch1 & ". " & Now.ToString("hh:mm:ss")
        '                                            Tiempo = Now.ToString("hh:mm:ss")
        '                                        End If
        '                                        Me.Refresh()
        '                                        'Me.Text = "Recibiendo: Com" & Puerto.CommPort & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        '                                    Else
        '                                        Print(2, CadenaBpcs)
        '                                        FileClose(2)
        '                                        Barra.Items(0).Text = ""
        '                                        Exit Do
        '                                    End If
        '                                Loop
        '                            Case Header2(0), Header2(1), Header2(2)
        '                                Barra.Items(0).Text = "Guardando informacion en archivo de datos " & Arch2 & ". " & Now.ToString("hh:mm:ss")
        '                                Do While True
        '                                    'Open CStr(Arch2) For Append Access Write Lock Read Write As #5
        '                                    FileOpen(5, CStr(Arch2), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        '                                    If Err.Number <> 0 Then
        '                                        FileClose(5)
        '                                        Err.Clear()
        '                                        If Tiempo <> Now.ToString("hh:mm:ss") Then
        '                                            Barra.Items(0).Text = "Esperando liberacion de archivo " & Arch2 & ". " & Now.ToString("hh:mm:ss")
        '                                        End If
        '                                        Me.Refresh()
        '                                        'Me.Caption = "Recibiendo: Com" & Puerto.CommPort & ":" & Puerto.Settings & ". BUFFER:" & CStr(Puerto.InBufferCount) _
        '                                        '& " de " & CStr(Puerto.InBufferSize)
        '                                    Else
        '                                        Print(5, CadenaBpcs)
        '                                        FileClose(5)
        '                                        Barra.Items(0).Text = ""
        '                                        Exit Do
        '                                    End If
        '                                Loop
        '                        End Select
        '                        Cadena = ""
        '                    Loop            ' do While ErrorRed = True And HayDatos = True
        '                End If              'If (C = "*" Or C = Chr$(13)) And (Trim(Cadena) <> "") Then
        '            End If                  'If N then...
        '            Me.Refresh()            'VR = DoEvents()
        '            N = Puerto.BytesToRead()
        '        End While               'While puerto.portopen..
    End Sub

    Private Sub ProcesarTCP()
        AbrirPuertos()
    End Sub

    Private Sub BRecibir_Click()
        If VerificarConfiguracion(TCPHabilitado) Then
            If TCPHabilitado Then
                ProcesarTCP()
            Else
                If Puerto.IsOpen Then
                    MsgBox("El puerto está abierto.", vbOKOnly + vbCritical)
                    Exit Sub
                End If
                ProcesarSerial()
            End If
        End If
    End Sub

    Private Sub Command1_Click()
        ' ''Dim X As Printer
        ' ''For Each X In Printers
        ' ''    If X.DeviceName = Impre1 Then
        ' ''        Printer = X
        ' ''        Printer.Font = "Arial"
        ' ''        Printer.FontBold = True
        ' ''        Printer.FontSize = 32
        ' ''        Printer.Print("____________________________")
        ' ''        Printer.Print("---ERROR DE COMUNICACION---")
        ' ''        Printer.Print("____________________________")
        ' ''        Printer.FontSize = 24
        ' ''        Printer.Print "Fecha: " & Format(Date, "dd/mm/yyyy") & "  Hora: " & Format(Time, "hh:mm:ss AMPM")
        ' ''        Printer.Print()
        ' ''        Printer.FontSize = 32
        ' ''        Printer.Print("---INFORMACION RECIBIDA---")
        ' ''        Printer.FontSize = 24
        ' ''        Printer.Print()
        ' ''        Printer.Print("Cadena de informacion")
        ' ''        Printer.EndDoc()
        ' ''    End If
        ' ''Next
    End Sub

    Private Sub Configurar_Click()
        BConfigurar_Click()
    End Sub

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub DetenerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetenerButton.Click
        Detener()
    End Sub

    Private Sub Detener()
        If (TCPHabilitado) Then
            WinSockServer.Cerrar()
            WinSockServer.Detener()
        Else
            If Puerto.IsOpen Then
                Puerto.Close()
            End If
        End If
    End Sub

    Private Sub frmSecuenciador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        LeerConfiguración()

        If (Produccion) Then
            DatosDeConfiguracion = "PROD"
        Else
            DatosDeConfiguracion = "DESA"
        End If
        If (TCPHabilitado) Then
            DatosDeConfiguracion += " TCP IP: Puerto " & TCPPuerto
        Else
            DatosDeConfiguracion += " Serial: " & SerialPuerto & " " & SerialBaudRate & "," & SerialParity & "," & SerialDataBits & "," & SerialStopBits
        End If

        Dim oSW As New StreamWriter(ArchLog)
        Dim Linea As String = Date.Now.ToString("yyyy-MM-dd hh:mm:ss") & " [frmSecuenciador_Load] " & DatosDeConfiguracion & vbNewLine
        oSW.WriteLine(Linea)
        oSW.Flush()

        Barra.Items(0).Text = DatosDeConfiguracion

        'Setup de la Grilla
        ' ''Grilla.Col = 1
        ' ''Grilla.Row = 0
        ' ''Grilla.Text = "ORIGEN"
        ' ''Grilla.ColWidth(1) = 1100
        ' ''Grilla.Col = 2
        ' ''Grilla.Text = "FECHA"
        ' ''Grilla.ColWidth(2) = 1000
        ' ''Grilla.Col = 3
        ' ''Grilla.Text = "HORA"
        ' ''Grilla.ColWidth(3) = 1000
        ' ''Grilla.Col = 4
        ' ''Grilla.Text = "DESTINO"
        ' ''Grilla.ColWidth(4) = 1000
        ' ''Grilla.Col = 5
        ' ''Grilla.Text = "SECUENCIA"
        ' ''Grilla.ColWidth(5) = 1000
        ' ''Grilla.Col = 6
        ' ''Grilla.Text = "MODEL YEAR"
        ' ''Grilla.ColWidth(6) = 1000
        ' ''Grilla.Col = 7
        ' ''Grilla.Text = "TMA"
        ' ''Grilla.ColWidth(7) = 1000
        ' ''Grilla.Col = 8
        ' ''Grilla.Text = "SEQUI"
        ' ''Grilla.ColWidth(8) = 1000
        ' ''Grilla.Col = 9
        ' ''Grilla.Text = "VIN"
        ' ''Grilla.ColWidth(9) = 1000
        ' ''Grilla.Col = 10
        ' ''Grilla.Text = "FIN"
        ' ''Grilla.ColWidth(10) = 1000

        NuevaFila = 1
        ' ''Grilla.Col = 1
        Me.Show()
        ForzarTemporal = False
        Err.Clear()
        'Open ArchTempSec For Input As #3
        FileOpen(3, ArchTempSec, OpenMode.Input)
        If Err.Number <> 0 Then
            'el archivo temporario no tiene datos
            BBTemp.Visible = False
            BBTemp.Enabled = False
        Else
            BBTemp.Visible = True
            BBTemp.Enabled = True
        End If
        FileClose(3)

        If (Produccion) Then
            EnviarButton.Visible = False
        Else
            EnviarButton.Visible = True
        End If

        BRecibir_Click() ' Para que comience a recibir apenas arranque el programa
    End Sub

    Private Sub BBTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBTemp.Click
        ForzarTemporal = True
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        Detener()
        End
    End Sub

    Private Sub ConfigurarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurarButton.Click
        BConfigurar_Click()
    End Sub

    Private Sub EnviarSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarButton.Click
        BEnviar_Click()
    End Sub

#Region "Eventos TCP - Servidor"
    Private Sub WinSockServer_NuevaConexion(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.NuevaConexion
        'Muestro quien se conecto
        MsgBox("Se ha conectado un nuevo cliente desde la IP= " & IDTerminal.Address.ToString & ",Puerto = " & IDTerminal.Port)
    End Sub

    Private Sub WinSockServer_ConexionTerminada(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.ConexionTerminada
        'Muestro con quien se termino la conexion
        MsgBox("Se ha desconectado el cliente desde la IP= " & IDTerminal.Address.ToString & ",Puerto = " & IDTerminal.Port)
    End Sub

    Private Sub WinSockServer_DatosRecibidos(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.DatosRecibidos
        'Muestro quien envio el mensaje
        MsgBox("Nuevo mensaje desde el cliente de la IP= " & IDTerminal.Address.ToString & ",Puerto = " & IDTerminal.Port)
        'Muestro el mensaje recibido
        Call MsgBox(WinSockServer.ObtenerDatos(IDTerminal))
    End Sub
#End Region

#Region "Eventos Serial - COMn"
    Private Sub Puerto_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Puerto.DataReceived
        MsgBox("Hay datos para recibir")
        ProcesarSerial()
    End Sub

    Private Sub Puerto_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Puerto.Disposed
        MsgBox("Cerrando Puerto")
    End Sub

    Private Sub Puerto_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles Puerto.ErrorReceived
        MsgBox("Recibiendo Error")
    End Sub
#End Region

End Class
