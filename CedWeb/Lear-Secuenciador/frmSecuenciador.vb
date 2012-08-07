Imports Microsoft.VisualBasic
Imports System.IO.Ports.SerialPort
Imports System.IO
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Sockets
Imports System.Globalization
Imports System.Threading

Public Class frmSecuenciador
    Dim ArchivoHST As String
    Dim ArchSemaforo As String
    Dim ArchDatos As String

    Dim CadenaSerial As String
    Dim CadenaContingencia As String

    Dim CadenaParaImprimir As String
    Dim CadenaGlobal As String
    Dim NombreCola1 As String
    Dim NombreCola2 As String
    Dim ForzarTemporal As Boolean

    Dim NuevaFila As Integer
    Dim FechaFila As Date

    Dim DatosDeConfiguracion As String
    Dim ssThread As System.Threading.Thread
    Dim ss As SocketSecuenciador

    Private Sub frmSecuenciador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        'CheckForIllegalCrossThreadCalls = False
        CadenaSerial = ""

        LeerConfiguración()
        DatosBarra()
        BarraTextBox.Text = DatosDeConfiguracion

        NuevaFila = 1
        Grilla.CurrentCell = Grilla(0, 0)
        FechaFila = Date.Now

        Me.Show()
        ForzarTemporal = False
        Err.Clear()
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
    End Sub

    Private Sub frmSecuenciador_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        EscribirLog("[frmSecuenciador_Shown]", DatosDeConfiguracion)
        Recibir()
    End Sub

    Public Sub AbreArchivo()
        'Open CStr(DirectorioArchivos & ArchivoHST) For Append Access Write As #1
        FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Append, OpenAccess.Write)
    End Sub

    Public Sub AbreArchivoDatos()
        On Error Resume Next
        Err.Clear()
        'Open CStr(DirectorioArchivos & ArchSemaforo) For Input Access Read Shared As #1
        FileOpen(1, CStr(DirectorioArchivos & ArchSemaforo), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
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
        ArchivoHST = Now.ToString("yyyyMMdd") & ".HST"
    End Sub

    Public Sub GrabaContingencia()
        Dim CadenaContingenciaBPCS As String
        Dim ArchivoCNG As String
        ArchivoCNG = Now.ToString("yyyyMMdd") & ".CNG"
        CadenaContingenciaBPCS = Mid(CadenaContingencia, 1, 9) & Now.ToString("yyyyMMdd") & Now.ToString("HHmmss") & _
                          Mid(CadenaContingencia, 28, 14) & Mid(CadenaContingencia, 43, 4) & Mid(CadenaContingencia, 48, 4) & _
                          Mid(CadenaContingencia, 52, 3) & Mid(CadenaContingencia, 55, 4) & Mid(CadenaContingencia, 59, 7) & vbNewLine

        Select Case Mid(CadenaContingencia, 1, 9)
            Case Header1(0), Header1(1), Header1(2)
                'Open CStr(DirContingencia & ArchivoCNG) For Append Access Write Lock Read Write As #4
                FileOpen(4, CStr(DirContingencia & ArchivoCNG), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
            Case Header2(0), Header2(1), Header2(2)
                'Open CStr(DirContingencia2 & ArchivoCNG) For Append Access Write Lock Read Write As #4
                FileOpen(4, CStr(DirContingencia2 & ArchivoCNG), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        End Select
        Print(4, CadenaContingenciaBPCS)    'Print #4, CadenaContingenciaBPCS
        FileClose(4)                        'Close #4
    End Sub

    Public Sub GrabaTemp()
        'Open CStr(ArchTempSec) For Append Access Write Lock Read Write As #3
        FileOpen(3, CStr(ArchTempSec), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
        Print(3, CadenaGlobal & vbNewLine)          'Print #3, CadenaGlobal
        FileClose(3)                                'Close #3
    End Sub

    Private Sub Enviar()
        Try
            Dim linea As String = ""
            Dim CadenaSerialPrueba As String
            CadenaSerialPrueba = ""
            FileOpen(12, DirectorioArchivos & "SerialPrueba.txt", OpenMode.Input)
            Do While EOF(12) = False
                Input(12, linea)
                CadenaSerialPrueba = CadenaSerialPrueba & linea & vbNewLine
            Loop
            FileClose(12)
            Puerto.Write(CadenaSerialPrueba)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Secuenciador")
        End Try
    End Sub

    Private Sub AbrirPuertos()
        Try
            If (TCPHabilitado) Then
                ss = New SocketSecuenciador()
                ssThread = New Thread(AddressOf ss.DoWork)
                ssThread.Start()
                HabilitarBotones(True)
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
                    HabilitarBotones(True)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Secuenciador")
            HabilitarBotones(False)
        End Try
    End Sub

    Private Sub Configurar()
        Try
            If TCPHabilitado Then
                frmConfiguracion.ShowDialog()
            Else
                If Puerto.IsOpen Then
                    MsgBox("Para configurar la aplicación, debe detener la recepción.", vbOKOnly + vbInformation)
                    Exit Sub
                Else
                    'Leer nuevamente los parametros por si cambiaron e inicializar las variables.
                    frmConfiguracion.ShowDialog()
                End If
            End If
            DatosBarra()
            EscribirLog("[Configurar]", DatosDeConfiguracion)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Secuenciador")
        End Try
    End Sub

    Private Sub RecibirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibirButton.Click
        EscribirLog("[RecibirButton_Click]", "")
        Recibir()
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
                    Me.MensajeTextBox.Text = "Esperando liberacion de archivo de Log. " & Now.ToString("HH:mm:ss")
                    Me.MensajeTextBox.Refresh()
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

    Private Sub ProcesarSerial()
        On Error Resume Next
        Dim N As Integer
        Dim C As String = ""

        Dim Tiempo As String = ""

        Dim CadenaFin As String
        Dim CadenaBpcs As String
        Dim CadenaBackup As String

        Dim CuentaCaracter As Integer
        Dim ErrorCabecera As Boolean
        Dim ErrorDigitos As Boolean

        Dim ErrorRed As Boolean
        Dim HayDatos As Boolean
        Dim Forzar2 As Boolean

        N = 0

        ErrorRed = False        'Comienza sin errores de red
        HayDatos = False        'Comienza sin datos en el temporal
        Forzar2 = False

        N = Puerto.BytesToRead()
        While N <> 0 Or ForzarTemporal = True
Inicio:
            If N Or ForzarTemporal = True Then
                Forzar2 = ForzarTemporal
                If Forzar2 = False Then
                    Dim caux As Char
                    caux = Convert.ToChar(Puerto.ReadChar())
                    C = Convert.ToString(caux)
                    C = Chr(CByte(Asc(C)) And CByte(127)) 'le saco el MSB
                    If (C <> Chr(10) And C <> Chr(13) And C <> "*") And (CadenaSerial <> "" Or C <> " ") Then
                        CadenaSerial = CadenaSerial & C
                    End If
                    Me.MensajeTextBox.Text = "Datos recibidos: " & Date.Now.ToString("dd/MM/yyyy HH:mm:ss") & " " & CadenaSerial
                End If

                If ((C = "*" Or C = Chr(13)) And (Trim(CadenaSerial) <> "")) Or Forzar2 = True Then
                    EscribirLog("[ProcesarSerial]", "Cadena: " & CadenaSerial)

                    If Forzar2 = False Then
                        If NuevaFila > 1800 Or FechaFila.ToString("yyyyMMdd") <> Date.Now.ToString("yyyyMMdd") Then
                            FechaFila = Date.Now
                            NuevaFila = 0
                            Grilla.RowCount = 0
                        End If

                        'MUESTRO EN LA GRILLA
                        Grilla.Rows.Add(Mid(CadenaSerial, 1, 9), _
                                      Mid(CadenaSerial, 11, 9), _
                                      Mid(CadenaSerial, 22, 5), _
                                      Mid(CadenaSerial, 28, 14), _
                                      Mid(CadenaSerial, 43, 4), _
                                      Mid(CadenaSerial, 48, 4), _
                                      Mid(CadenaSerial, 52, 3), _
                                      Mid(CadenaSerial, 55, 4), _
                                      Mid(CadenaSerial, 59, 7))

                        Grilla.ClearSelection()
                        Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells(0)
                        Grilla.Rows(Grilla.RowCount - 1).Selected = True

                        FechaFila = Mid(CadenaSerial, 11, 9)

                        NuevaFila = NuevaFila + 1
                        Me.Grilla.Refresh()
                    End If

                    If Forzar2 = True Then
                        ForzarTemporal = False
                        Forzar2 = False
                        BBTemp.Visible = False
                        BBTemp.Enabled = False
                    End If
                    Err.Clear()

                    'Procedimiento que graba la informacion en el formato que BPCS precisa, 
                    'pero en el disco local.
                    CadenaContingencia = CadenaSerial
                    If CadenaContingencia <> "" Then
                        Call GrabaContingencia()
                    End If

                    'Validacion para ver si el archivo temporario tiene datos
                    Err.Clear()
                    CadenaBackup = CadenaSerial
                    'Open ArchTempSec For Input As #3
                    FileOpen(3, ArchTempSec, OpenMode.Input)
                    If Err.Number <> 0 Then
                        'el archivo temporario no tiene datos
                        FileClose(3)
                        'Err.Clear()
                        HayDatos = False
                        BBTemp.Visible = False
                        BBTemp.Enabled = False
                    Else
                        HayDatos = True
                        BBTemp.Visible = True
                        BBTemp.Enabled = True
                    End If
                    Err.Clear()

                    Call CreaNombreArchivo()
                    'Open CStr(DirectorioArchivos & ArchivoHST) For Append Access Write Lock Read Write As #1
                    FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                    If Err.Number <> 0 Then
                        'El enlace todavía no está restablecido
                        FileClose(1)
                        Err.Clear()
                        CadenaGlobal = CadenaSerial
                        ErrorRed = True
                        FileClose(3)
                        If CadenaSerial <> "" Then
                            MensajeTextBox.Text = "Guardando informacion temporal en " & ArchTempSec
                            Me.MensajeTextBox.Refresh()
                            Call GrabaTemp()
                        End If
                        CadenaSerial = ""
                        MensajeTextBox.Text = ""
                        Me.MensajeTextBox.Refresh()
                        BBTemp.Visible = True
                        BBTemp.Enabled = True
                    Else
                        FileClose(1)
                        ErrorRed = False
                    End If
                    Err.Clear()

                    Do While ErrorRed = False           'LOOP creado para incluir el grabado de las secuencias en el archivo
                        If HayDatos = True Then
                            If EOF(3) = False Then
                                Input(3, CadenaSerial)
                            Else
                                HayDatos = False
                                FileClose(3)
                                Kill(ArchTempSec)
                                ErrorRed = True
                                CadenaSerial = CadenaBackup
                                BBTemp.Visible = False
                                BBTemp.Enabled = False
                                If CadenaSerial = "" Then GoTo Inicio
                            End If
                        Else
                            CadenaSerial = CadenaBackup
                            FileClose(3)
                            Kill(ArchTempSec)           'Borrar Archivo temporal
                            ErrorRed = True             'para que salga del loop despues de procesar la variable CadenaSerial
                            BBTemp.Visible = False
                            BBTemp.Enabled = False
                        End If
                        Err.Clear()

                        CadenaBpcs = Mid(CadenaSerial, 1, 9) & Format(Now, "yyyyMMdd") & Format(Now, "HHmmss") & _
                                     Mid(CadenaSerial, 28, 14) & Mid(CadenaSerial, 43, 4) & Mid(CadenaSerial, 48, 4) & _
                                     Mid(CadenaSerial, 52, 3) & Mid(CadenaSerial, 55, 4) & Mid(CadenaSerial, 59, 7) & vbNewLine

                        'GUARDO EN HISTORICO
                        Call CreaNombreArchivo()
                        MensajeTextBox.Text = "Guardando informacion historica en " & DirectorioArchivos & ArchivoHST
                        Me.MensajeTextBox.Refresh()

                        Do While True
                            'Open CStr(DirectorioArchivos & ArchivoHST) For Append Access Write Lock Read Write As #1
                            FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                            If Err.Number <> 0 Then
                                FileClose(1)
                                Err.Clear()
                                If Tiempo <> CStr(TimeValue(Now)) Then
                                    MensajeTextBox.Text = "Esperando liberacion de archivo " & DirectorioArchivos & ArchivoHST & ". " & Now.ToString("HH:mm:ss")
                                    Tiempo = CStr(TimeValue(Now))
                                End If
                            Else
                                Print(1, CadenaSerial & vbNewLine)
                                FileClose(1)
                                Exit Do
                            End If
                            Me.MensajeTextBox.Refresh()
                        Loop

                        ' FIN REEMPLAZO POR SER ARCHIVO DE RED
                        MensajeTextBox.Text = ""
                        Me.MensajeTextBox.Refresh()

                        'Rutina de verificacion e impresion de cabecera y numero de secuencia
                        ErrorCabecera = True
                        For CuentaCaracter = 0 To 2
                            If Mid(CadenaSerial, 1, 9) = Header1(CuentaCaracter) Then ErrorCabecera = False
                        Next CuentaCaracter

                        For CuentaCaracter = 0 To 2
                            If Mid(CadenaSerial, 1, 9) = Header2(CuentaCaracter) Then ErrorCabecera = False
                        Next CuentaCaracter

                        ErrorDigitos = False
                        For CuentaCaracter = 0 To 3
                            If Mid(CadenaSerial, 43 + CuentaCaracter, 1) < "0" Or Mid(CadenaSerial, 43 + CuentaCaracter, 1) > "9" Then ErrorDigitos = True
                        Next

                        If ErrorCabecera = True Or ErrorDigitos = True Then
                            EscribirLog("[ProcesarSerial] ", "Error en cabecera o digito de control. Cadena: " & CadenaSerial)
                            CadenaParaImprimir = CadenaSerial
                            For Each X As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                                If X = Impre1 Or X = Impre2 Then
                                    Dim pd As New System.Drawing.Printing.PrintDocument
                                    pd.PrinterSettings.PrinterName = X
                                    AddHandler pd.PrintPage, AddressOf print_PrintPage
                                    pd.Print()
                                End If
                            Next
                        End If

                        'Grabo segun cabecera
                        On Error Resume Next
                        Select Case Mid(CadenaSerial, 1, 9)
                            Case Header1(0), Header1(1), Header1(2)
                                MensajeTextBox.Text = "Guardando informacion en archivo de datos " & Arch1 & ". " & Now.ToString("HH:mm:ss")
                                Do While True
                                    'Open CStr(Arch1) For Append Access Write Lock Read Write As #2
                                    FileOpen(2, CStr(Arch1), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(2)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("HH:mm:ss") Then
                                            MensajeTextBox.Text = "Esperando liberacion de archivo " & Arch1 & ". " & Now.ToString("HH:mm:ss")
                                            Tiempo = Now.ToString("HH:mm:ss")
                                        End If
                                    Else
                                        Print(2, CadenaBpcs)
                                        FileClose(2)
                                        MensajeTextBox.Text = ""
                                        Exit Do
                                    End If
                                    Me.MensajeTextBox.Refresh()
                                Loop
                            Case Header2(0), Header2(1), Header2(2)
                                MensajeTextBox.Text = "Guardando informacion en archivo de datos " & Arch2 & ". " & Now.ToString("HH:mm:ss")
                                Do While True
                                    'Open CStr(Arch2) For Append Access Write Lock Read Write As #5
                                    FileOpen(5, CStr(Arch2), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(5)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("HH:mm:ss") Then
                                            MensajeTextBox.Text = "Esperando liberacion de archivo " & Arch2 & ". " & Now.ToString("HH:mm:ss")
                                        End If
                                    Else
                                        Print(5, CadenaBpcs)
                                        FileClose(5)
                                        MensajeTextBox.Text = ""
                                        Exit Do
                                    End If
                                    Me.MensajeTextBox.Refresh()
                                Loop
                        End Select
                        CadenaSerial = ""
                    Loop                'Do While ErrorRed = True And HayDatos = True
                End If                  'If (C = "*" Or C = Chr$(13)) And (Trim(CadenaSerial) <> "") Then
            End If                      'If N then...
            Me.MensajeTextBox.Refresh()
            N = Puerto.BytesToRead()
        End While
    End Sub

    Private Sub ProcesarTCP()
        On Error Resume Next
        Dim N As Integer
        Dim C As String = ""
        Dim Tiempo As String = ""

        Dim Cadena As String = ""
        Dim CadenaFin As String
        Dim CadenaBpcs As String
        Dim CadenaBackup As String

        Dim CuentaCaracter As Integer
        Dim ErrorCabecera As Boolean
        Dim ErrorDigitos As Boolean

        Dim ErrorRed As Boolean
        Dim HayDatos As Boolean
        Dim Forzar2 As Boolean

        Dim BufferCaracteres As String
        Dim Message As String

        Cadena = ""
        N = 0

        Dim ports As String()

        ErrorRed = False        'Comienza sin errores de red
        HayDatos = False        'Comienza sin datos en el temporal
        Forzar2 = False

        'Buscar el primer archivo SinProcesar por orden de llegada
        Dim directorio As System.IO.Directory
        Dim archivosLista As String()
        archivosLista = directorio.GetFiles(DirectorioArchivos & "RecibidosSinProcesar")
        If archivosLista.Length <> 0 Then
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(archivosLista(0))
            BufferCaracteres = sr.ReadToEnd()
            Message = BufferCaracteres
            sr.Close()
            Dim file As FileInfo = New FileInfo(archivosLista(0))
            file.MoveTo(DirectorioArchivos & "RecibidosProcesados\" & file.Name)
        End If

        'Dim hg As String
        'hg = DateTime.Now.AddSeconds(10).ToString("hhmmss")
        'Do Until Convert.ToInt32(DateTime.Now.ToString("hhmmss")) > Convert.ToInt32(hg)
        'Loop

        Dim BufferPosicion As Integer = 0
        N = BufferCaracteres.Length
        While N <> 0 Or ForzarTemporal = True
Inicio:
            If N Or ForzarTemporal = True Then
                Forzar2 = ForzarTemporal
                If Forzar2 = False Then
                    C = Message.Substring(BufferPosicion, 1)
                    BufferPosicion = BufferPosicion + 1
                    C = Chr(CByte(Asc(C)) And CByte(127))       'le saco el MSB
                    If (Asc(C) = 0) Then
                        Exit While
                    End If
                    If (C <> Chr(10) And C <> Chr(13) And C <> "*") And (Cadena <> "" Or C <> " ") Then
                        If (Asc(C) <> 0) Then
                            Cadena = Cadena & C
                        End If
                    End If
                    MensajeTextBox.Text = "Datos recibidos: " & Date.Now.ToString("dd/MM/yyyy HH:mm:ss") & " (" & BufferPosicion & ") " & Cadena
                    Me.MensajeTextBox.Refresh()
                End If

                If ((C = "*" Or C = Chr(13)) And (Trim(Cadena) <> "")) Or Forzar2 = True Then
                    EscribirLog("[ProcesarTCP]", "Forzar = " & Forzar2 & " Cadena: " & Cadena)

                    If Forzar2 = False Then
                        If NuevaFila > 1800 Or FechaFila.ToString("yyyyMMdd") <> Date.Now.ToString("yyyyMMdd") Then
                            FechaFila = Date.Now
                            NuevaFila = 0
                            Grilla.RowCount = 0
                        End If

                        'MUESTRO EN LA GRILLA
                        Grilla.Rows.Add(Mid(Cadena, 1, 9), _
                                      Mid(Cadena, 11, 9), _
                                      Mid(Cadena, 22, 5), _
                                      Mid(Cadena, 28, 14), _
                                      Mid(Cadena, 43, 4), _
                                      Mid(Cadena, 48, 4), _
                                      Mid(Cadena, 52, 3), _
                                      Mid(Cadena, 55, 4), _
                                      Mid(Cadena, 59, 7))

                        Grilla.ClearSelection()
                        Grilla.CurrentCell = Grilla.Rows(Grilla.RowCount - 1).Cells(0)
                        Grilla.Rows(Grilla.RowCount - 1).Selected = True

                        FechaFila = Mid(Cadena, 11, 9)

                        NuevaFila = NuevaFila + 1
                        Me.Grilla.Refresh()
                    End If

                    Call CreaNombreArchivo()
                    'Detectar Cadena Duplicada.
                    If Not System.IO.File.Exists(DirectorioArchivos & ArchivoHST) Then
                        Dim fs As System.IO.FileStream
                        fs = System.IO.File.Create(DirectorioArchivos & ArchivoHST)
                        If Err.Number <> 0 Then
                            MsgBox("Error: No se puede crear el archivo histórico." & vbCrLf & Err.Description, vbOKOnly + vbCritical)
                            Err.Clear()
                        Else
                            fs.Close()
                        End If
                    End If
                    Do While True
                        FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Input)
                        If Err.Number <> 0 Then
                            FileClose(1)
                            Err.Clear()
                            If Tiempo <> CStr(TimeValue(Now)) Then
                                MensajeTextBox.Text = "Esperando liberacion de archivo " & DirectorioArchivos & ArchivoHST & ". (VD) " & Now.ToString("HH:mm:ss")
                                Tiempo = CStr(TimeValue(Now))
                            End If
                        Else
                            'Input trae de a un registro
                            Dim CadenaAux As String
                            Do While EOF(1) = False
                                CadenaAux = LineInput(1)
                                If (Cadena.Length >= 65 And CadenaAux.Length >= 65) Then
                                    Dim c1 As String : Dim c2 As String
                                    c1 = Cadena.Substring(0, 65)
                                    c2 = CadenaAux.Substring(0, 65)
                                    If (c1 = c2) Then
                                        MensajeTextBox.Text = "Cadena existente: " & Cadena & Now.ToString("HH:mm:ss")
                                        EscribirLog("[ProcesarTCP]", "Cadena existente: " & Cadena)
                                        FileClose(1)
                                        Exit Sub
                                    End If
                                End If
                            Loop
                            FileClose(1)
                            Exit Do
                        End If
                    Loop

                    If Forzar2 = True Then
                        ForzarTemporal = False
                        Forzar2 = False
                        BBTemp.Visible = False
                        BBTemp.Enabled = False
                    End If
                    Err.Clear()

                    'Procedimiento que graba la informacion en el formato que BPCS precisa, 
                    'pero en el disco local.
                    CadenaContingencia = Cadena
                    If CadenaContingencia <> "" Then
                        Call GrabaContingencia()
                    End If

                    'Validacion para ver si el archivo temporario tiene datos
                    Err.Clear()
                    CadenaBackup = Cadena
                    'Open ArchTempSec For Input As #3
                    FileOpen(3, ArchTempSec, OpenMode.Input)
                    If Err.Number <> 0 Then
                        'el archivo temporario no tiene datos
                        FileClose(3)
                        'Err.Clear()
                        HayDatos = False
                        BBTemp.Visible = False
                        BBTemp.Enabled = False
                    Else
                        HayDatos = True
                        BBTemp.Visible = True
                        BBTemp.Enabled = True
                    End If
                    Err.Clear()

                    'Open CStr(DirectorioArchivos & ArchivoHST) For Append Access Write Lock Read Write As #1
                    FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                    If Err.Number <> 0 Then
                        'El enlace todavía no está restablecido
                        FileClose(1)
                        Err.Clear()
                        CadenaGlobal = Cadena
                        ErrorRed = True
                        FileClose(3)
                        If Cadena <> "" Then
                            MensajeTextBox.Text = "Guardando informacion temporal en " & ArchTempSec
                            Me.MensajeTextBox.Refresh()
                            Call GrabaTemp()
                        End If
                        Cadena = ""
                        MensajeTextBox.Text = ""
                        Me.MensajeTextBox.Refresh()
                        BBTemp.Visible = True
                        BBTemp.Enabled = True
                    Else
                        FileClose(1)
                        ErrorRed = False
                    End If
                    Err.Clear()

                    Do While ErrorRed = False           'LOOP creado para incluir el grabado de las secuencias en el archivo
                        If HayDatos = True Then
                            If EOF(3) = False Then
                                Input(3, Cadena)
                            Else
                                HayDatos = False
                                FileClose(3)
                                Kill(ArchTempSec)
                                ErrorRed = True
                                Cadena = CadenaBackup
                                BBTemp.Visible = False
                                BBTemp.Enabled = False
                                If Cadena = "" Then GoTo Inicio
                            End If
                        Else
                            Cadena = CadenaBackup
                            FileClose(3)
                            Kill(ArchTempSec)           'Borrar Archivo temporal
                            ErrorRed = True             'para que salga del loop despues de procesar la variable Cadena
                            BBTemp.Visible = False
                            BBTemp.Enabled = False
                        End If
                        Err.Clear()

                        CadenaBpcs = Mid(Cadena, 1, 9) & Format(Now, "yyyyMMdd") & Format(Now, "HHmmss") & _
                                     Mid(Cadena, 28, 14) & Mid(Cadena, 43, 4) & Mid(Cadena, 48, 4) & _
                                     Mid(Cadena, 52, 3) & Mid(Cadena, 55, 4) & Mid(Cadena, 59, 7) & vbNewLine

                        'GUARDO EN HISTORICO
                        Call CreaNombreArchivo()
                        MensajeTextBox.Text = "Guardando informacion historica en " & DirectorioArchivos & ArchivoHST
                        Me.MensajeTextBox.Refresh()

                        Do While True
                            'Open CStr(DirectorioArchivos & ArchivoHST) For Append Access Write Lock Read Write As #1
                            FileOpen(1, CStr(DirectorioArchivos & ArchivoHST), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                            If Err.Number <> 0 Then
                                FileClose(1)
                                Err.Clear()
                                If Tiempo <> CStr(TimeValue(Now)) Then
                                    MensajeTextBox.Text = "Esperando liberacion de archivo " & DirectorioArchivos & ArchivoHST & ". " & Now.ToString("HH:mm:ss")
                                    Tiempo = CStr(TimeValue(Now))
                                End If
                            Else
                                Print(1, Cadena & vbNewLine)
                                FileClose(1)
                                Exit Do
                            End If
                            Me.MensajeTextBox.Refresh()
                        Loop

                        ' FIN REEMPLAZO POR SER ARCHIVO DE RED
                        MensajeTextBox.Text = ""
                        Me.MensajeTextBox.Refresh()

                        'Rutina de verificacion e impresion de cabecera y numero de secuencia
                        ErrorCabecera = True
                        For CuentaCaracter = 0 To 2
                            If Mid(Cadena, 1, 9) = Header1(CuentaCaracter) Then ErrorCabecera = False
                        Next CuentaCaracter

                        For CuentaCaracter = 0 To 2
                            If Mid(Cadena, 1, 9) = Header2(CuentaCaracter) Then ErrorCabecera = False
                        Next CuentaCaracter

                        ErrorDigitos = False
                        For CuentaCaracter = 0 To 3
                            If Mid(Cadena, 43 + CuentaCaracter, 1) < "0" Or Mid(Cadena, 43 + CuentaCaracter, 1) > "9" Then ErrorDigitos = True
                        Next

                        If ErrorCabecera = True Or ErrorDigitos = True Then
                            EscribirLog("[ProcesarTCP] ", "Error en cabecera o digito de control. Cadena: " & Cadena)
                            CadenaParaImprimir = Cadena
                            'Dim i As Int32
                            'For i = 0 To Grilla.ColumnCount - 1
                            '    Grilla.Rows(Grilla.RowCount - 1).Cells(i).Style.ForeColor = Color.Red
                            'Next i
                            'Grilla.Rows(Grilla.RowCount - 1).Selected = False
                            For Each X As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                                If X = Impre1 Or X = Impre2 Then
                                    Dim pd As New System.Drawing.Printing.PrintDocument
                                    pd.PrinterSettings.PrinterName = X
                                    AddHandler pd.PrintPage, AddressOf print_PrintPage
                                    'Pruebas
                                    'pd.PrinterSettings.PrintFileName = DirectorioArchivos & "Error" & Date.Now.ToString("yyyyMMdd-HHmmss") & ".PDF"
                                    'pd.PrinterSettings.PrintToFile = True
                                    pd.Print()
                                End If
                            Next
                        End If

                        'Grabo segun cabecera
                        On Error Resume Next
                        Select Case Mid(Cadena, 1, 9)
                            Case Header1(0), Header1(1), Header1(2)
                                MensajeTextBox.Text = "Guardando informacion en archivo de datos " & Arch1 & ". " & Now.ToString("HH:mm:ss")
                                Do While True
                                    'Open CStr(Arch1) For Append Access Write Lock Read Write As #2
                                    FileOpen(2, CStr(Arch1), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(2)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("HH:mm:ss") Then
                                            MensajeTextBox.Text = "Esperando liberacion de archivo " & Arch1 & ". " & Now.ToString("HH:mm:ss")
                                            Tiempo = Now.ToString("HH:mm:ss")
                                        End If
                                    Else
                                        Print(2, CadenaBpcs)
                                        FileClose(2)
                                        MensajeTextBox.Text = ""
                                        Exit Do
                                    End If
                                    Me.MensajeTextBox.Refresh()
                                Loop
                            Case Header2(0), Header2(1), Header2(2)
                                MensajeTextBox.Text = "Guardando informacion en archivo de datos " & Arch2 & ". " & Now.ToString("HH:mm:ss")
                                Do While True
                                    'Open CStr(Arch2) For Append Access Write Lock Read Write As #5
                                    FileOpen(5, CStr(Arch2), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(5)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("HH:mm:ss") Then
                                            MensajeTextBox.Text = "Esperando liberacion de archivo " & Arch2 & ". " & Now.ToString("HH:mm:ss")
                                        End If
                                    Else
                                        Print(5, CadenaBpcs)
                                        FileClose(5)
                                        MensajeTextBox.Text = ""
                                        Exit Do
                                    End If
                                    Me.MensajeTextBox.Refresh()
                                Loop
                        End Select
                        Cadena = ""
                    Loop                'Do While ErrorRed = True And HayDatos = True
                End If                  'If (C = "*" Or C = Chr$(13)) And (Trim(Cadena) <> "") Then
            End If                      'If N then...
            Me.MensajeTextBox.Refresh()
            N = Message.Length - BufferPosicion
        End While
    End Sub

    Private Sub Recibir()
        If VerificarConfiguracion(TCPHabilitado) Then
            If TCPHabilitado Then
                AbrirPuertos()
            Else
                If Puerto.IsOpen Then
                    MsgBox("El puerto está abierto.", vbOKOnly + vbCritical)
                    Exit Sub
                End If
                AbrirPuertos()
                ProcesarSerial()
            End If
        End If
    End Sub

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub DetenerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetenerButton.Click
        EscribirLog("[DetenerButton_Click]", "")
        Detener()
    End Sub

    
    Private Sub HabilitarBotones(ByVal EstaEscuchando As Boolean)
        If (EstaEscuchando) Then
            RecibirButton.Enabled = False
            DetenerButton.Enabled = True
            ConfigurarButton.Enabled = False
            EnviarButton.Enabled = True
        Else
            RecibirButton.Enabled = True
            DetenerButton.Enabled = False
            ConfigurarButton.Enabled = True
            EnviarButton.Enabled = False
        End If
    End Sub

    Private Sub BBTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBTemp.Click
        ForzarTemporal = True
        EscribirLog("[BBTemp_Click]", "")
        If (TCPHabilitado) Then
            ProcesarTCP()
        Else
            ProcesarSerial()
        End If
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        EscribirLog("[SalirButton_Click]", "")
        Dim resp As Boolean
        resp = Detener()
        If (resp) Then
            End
        End If
    End Sub

    Private Function Detener() As Boolean
        Detener = False
        If (TCPHabilitado) Then
            If (ss.DetencionPermitida = True) Then
                ss.DetenerSocket()
                HabilitarBotones(False)
                Detener = True
            Else
                EscribirLog("[Detener]", "No es posible detener el secuenciador. Intente más tarde.")
                MsgBox("No es posible detener el secuenciador. Intente más tarde.", vbOKOnly + vbCritical)
            End If
        Else
            If Puerto.IsOpen Then
                Puerto.Close()
                Detener = True
            End If
        End If
    End Function

    Private Sub ConfigurarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurarButton.Click
        EscribirLog("[ConfigurarButton_Click]", "")
        Configurar()
    End Sub

    Private Sub EnviarSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarButton.Click
        EscribirLog("[EnviarSerial_Click]", "")
        Enviar()
    End Sub

#Region "Eventos Serial - COMn"
    Private Sub Puerto_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Puerto.DataReceived
        'MsgBox("Hay datos para recibir")
        ProcesarSerial()
    End Sub

    Private Sub Puerto_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Puerto.Disposed
        HabilitarBotones(False)
        'MsgBox("Cerrando Puerto")
    End Sub

    Private Sub Puerto_ErrorReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles Puerto.ErrorReceived
        'MsgBox("Recibiendo Error")
    End Sub
#End Region

#Region "Imprimir"
    Private Sub ImprimirPruebaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirPruebaButton.Click
        CadenaParaImprimir = "Prueba de cadena para imprimir"
        For Each X As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If X = Impre1 Or X = Impre2 Then
                Dim pd As New System.Drawing.Printing.PrintDocument
                pd.PrinterSettings.PrinterName = X
                AddHandler pd.PrintPage, AddressOf print_PrintPage
                pd.Print()
            End If
        Next
    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim prFont As New Font("Courier New", 24, FontStyle.Bold)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim lineHeight As Single = prFont.GetHeight(e.Graphics)
        ' imprimimos la cadena
        e.Graphics.DrawString("____________________________", prFont, Brushes.Black, xPos, yPos)
        yPos += lineHeight
        e.Graphics.DrawString("---ERROR DE COMUNICACION---", prFont, Brushes.Black, xPos, yPos)
        yPos += lineHeight
        e.Graphics.DrawString("____________________________", prFont, Brushes.Black, xPos, yPos)
        Dim prFont2 As New Font("Courier New", 16, FontStyle.Bold)
        yPos += lineHeight
        Dim s As String = "Fecha: " + Format(Date.Now, "dd/mm/yyyy") + "  Hora: " + Format(Date.Now, "HH:mm:ss")
        e.Graphics.DrawString(s, prFont2, Brushes.Black, xPos, yPos)
        yPos += lineHeight
        e.Graphics.DrawString("---INFORMACION RECIBIDA---", prFont, Brushes.Black, xPos, yPos)
        yPos += lineHeight
        Dim prFont3 As New Font("Courier New", 16, FontStyle.Bold)
        e.Graphics.DrawString(CadenaParaImprimir, prFont3, Brushes.Black, xPos, yPos)
        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False
    End Sub
#End Region

    Private Sub DatosBarra()
        If (Produccion) Then
            DatosDeConfiguracion = "PROD"
            ImprimirPruebaButton.Visible = False
            EnviarButton.Visible = False
        Else
            DatosDeConfiguracion = "DESA"
        End If
        If (TCPHabilitado) Then
            'bytes = New Byte(CInt(TCPCantBytesBuffer)) {}
            DatosDeConfiguracion += " Configuración TCP IP: Puerto " & TCPPuerto & "  Cant.Bytes Buffer: " & TCPCantBytesBuffer
            EnviarButton.Visible = False
            Timer1.Enabled = True
        Else
            DatosDeConfiguracion += " Configuración Serial: COM" & SerialPuerto & " " & SerialBaudRate & "," & SerialParity & "," & SerialDataBits & "," & SerialStopBits
            If Not Produccion Then
                EnviarButton.Visible = True
            End If
        End If
        BarraTextBox.Text = DatosDeConfiguracion
    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        Try
            Timer1.Enabled = False
            ProcesarTCP()
            Dim FecAux As DateTime
            FecAux = ss.ContadorDiarioFecha.AddHours(3)
            If (ss.DetencionPermitida = True) Then
                If (Convert.ToInt64(Date.Now.ToString("yyyyMMddhhmmss")) > Convert.ToInt64(FecAux.ToString("yyyyMMddhhmmss"))) Then
                    ss.DetenerSocket()
                    ss = New SocketSecuenciador()
                    ssThread = New Thread(AddressOf ss.DoWork)
                    ssThread.Start()
                End If
            End If
        Catch ex As Exception
            EscribirLog("[Timer1_Elapsed]", ex.Message)
        Finally
            Timer1.Enabled = True
        End Try
    End Sub
End Class
