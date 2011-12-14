Imports Microsoft.VisualBasic
Imports System.IO.Ports.SerialPort

Public Class frmSecuenciador
    Dim DirInstall As String
    Dim PathArchINI As String

    Dim ArchivoTexto As String
    Dim ArchSemaforo As String
    Dim ArchDatos As String
    Dim CadenaContingencia As String
    Dim DirContingencia As String
    Dim DirContingencia2 As String
    Dim Impre1 As String
    Dim Impre2 As String
    Dim ArchTempSec As String
    Dim CadenaGlobal As String
    Dim NombreCola1 As String
    Dim NombreCola2 As String
    Dim Header1(3) As String
    Dim Header2(3) As String
    Dim ForzarTemporal As Boolean

    Dim Arch1 As String
    Dim Arch2 As String
    Dim SerialPuerto As String
    Dim SerialBaudRate As String
    Dim SerialParity As String
    Dim SerialDataBits As String
    Dim SerialStopBits As String

    Dim NuevaFila As Integer
    Dim Tiempo As String

    'Nueva modalidad (no utilizada)
    'Dim oFile As System.IO.File
    'Dim oWrite1 As System.IO.StreamWriter   '#1
    'Dim oRead1 As System.IO.StreamReader    '#1

    Public Sub AbreArchivo()
        'Open CStr(DirInstall & ArchivoTexto) For Append Access Write As #1
        FileOpen(1, CStr(DirInstall & ArchivoTexto), OpenMode.Append, OpenAccess.Write)
        'oWrite1 = oFile.CreateText(DirInstall & ArchivoTexto)
    End Sub

    Public Sub AbreArchivoDatos()
        On Error Resume Next
        Err.Clear()
        'Open CStr(DirInstall & ArchSemaforo) For Input Access Read Shared As #1
        FileOpen(1, CStr(DirInstall & ArchSemaforo), OpenMode.Input, OpenAccess.Read, OpenShare.Shared)
        'oRead1 = oFile.OpenText(DirInstall & ArchSemaforo)
        MsgBox(Err.Number)
        If Err.Number <> 0 Then
            'Me dio error, o sea que el archivo no existe, entonces yo lo creo
            'Open CStr(DirInstall & ArchSemaforo) For Output Access Write Lock Read Write As #1
            FileOpen(1, CStr(DirInstall & ArchSemaforo), OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
            Print(1, "SEMAFORO")
            FileClose(1)

            'Open CStr(DirInstall & ArchDatos) For Append Access Write As #1
            FileOpen(1, CStr(DirInstall & ArchDatos), OpenMode.Append, OpenAccess.Write)
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
        'Open CStr(DirInstall & ArchivoTexto & ".bat") For Output As #2
        FileOpen(2, CStr(DirInstall & ArchivoTexto & ".bat"), OpenMode.Output)

        If NombreCola1 <> "" Then
            Print(2, CStr("COPY " & DirInstall & ArchivoTexto & ".txt " & NombreCola1))
        End If
        If NombreCola2 <> "" Then
            Print(2, CStr("COPY " & DirInstall & ArchivoTexto & ".txt " & NombreCola2))
        End If
        FileClose(2)
        If NombreCola1 <> "" Or NombreCola2 <> "" Then
            Valor = Shell(CStr(DirInstall & ArchivoTexto & ".BAT"), 6)
        End If
    End Sub

    Private Sub BEnviar_Click()
        Dim L As Integer
        Dim I As Integer
        Dim C As String                   'Dim C As String * 1

        'Puerto.CommPort = 1
        Puerto.PortName = SerialPuerto
        'Puerto.Settings = "9600,n,8,1"
        Puerto.BaudRate = SerialBaudRate
        Puerto.Parity = SerialParity
        Puerto.DataBits = SerialDataBits
        Puerto.StopBits = SerialStopBits

        'No se utilizan mas los buffers
        ''Puerto.InBufferSize = 1024
        ''Puerto.OutBufferSize = 1024

        'Puerto.PortOpen = True
        'Me.Caption = "Enviando: Com" & Puerto.CommPort & ":" & Puerto.Settings
        'L = Len(TMensaje.Text)
        'For I = 1 To L
        '    C = Mid$(TMensaje.Text, I, 1)
        '    Puerto.Output = C
        'Next I
        'Puerto.PortOpen = False

        ' ''Puerto.Open()
        ' ''Me.Text = "Enviando: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        ' ''L = Len(TMensaje.Text)
        ' ''If (L > 0) Then
        ' ''    Puerto.WriteLine(TMensaje.Text)
        ' ''End If
        ' ''Puerto.Close()
    End Sub

    Private Sub BConfigurar_Click()
        If Puerto.IsOpen Then
            MsgBox("Para configurar los parámetros, debe detener la recepcion.", vbOKOnly + vbInformation)
            Exit Sub
        Else
            frmConfiguracion.Show()
            'Leer nuevamente los parametros por si cambiaron e inicializar las variables.
        End If
    End Sub

    Private Sub Puerto_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Puerto.DataReceived
        MsgBox("Evento recibir")
    End Sub

    Private Sub BRecibir_Click()
        On Error Resume Next
        Dim N As Integer
        Dim C As String
        Dim VR As Integer
        Dim Cadena As String
        Dim LargoLinea As Integer
        Dim Tiempo As String
        Dim LineaTexto As String
        Dim FechaFila As Date
        Dim CadenaFin As String
        Dim CadenaBpcs As String

        Dim CuentaCaracter As Integer
        Dim ErrorCabecera As Boolean
        Dim ErrorDigitos As Boolean
        Dim TotalCaracter As Integer

        ' ''Dim X As Printer
        Dim ErrorRed As Boolean
        Dim HayDatos As Boolean
        Dim CadenaBackup As String
        Dim RecuperaDatos As Boolean
        Dim Forzar2 As Boolean

        If Puerto.IsOpen Then
            MsgBox("El puerto está abierto.", vbOKOnly + vbCritical)
            Exit Sub
        End If

        FechaFila = Now.ToString("dd/MM/yyyy")
        'Validaciones de configuracion
        If DirInstall = "" Then
            MsgBox("El directorio de Archivos no está configurado.", vbOKOnly + vbCritical)
            Exit Sub
        End If

        'Ahora son cuartro (BuadRate, Parity, DataBits y StopBits)
        If SerialBaudRate = "" Then
            MsgBox("El parámetro de configuración BaudRate del puerto serie no está cargado.", vbOKOnly + vbCritical)
            Exit Sub
        End If
        If SerialParity = "" Then
            MsgBox("El parámetro de configuración Parity del puerto serie no está cargado.", vbOKOnly + vbCritical)
            Exit Sub
        End If
        If SerialDataBits = "" Then
            MsgBox("El parámetro de configuración DataBits del puerto serie no está cargado.", vbOKOnly + vbCritical)
            Exit Sub
        End If
        If SerialStopBits = "" Then
            MsgBox("El parámetro de configuración StopBits del puerto serie no está cargado.", vbOKOnly + vbCritical)
            Exit Sub
        End If
        If SerialPuerto < 1 Or SerialPuerto > 4 Then
            MsgBox("El Puerto Serie a utilizar no esta configurado.", vbOKOnly + vbCritical)
            Exit Sub
        End If
        If Arch1 = "" Then
            MsgBox("El nombre del Archivo de Datos 1 no esta cargado.", vbOKOnly + vbCritical)
            Exit Sub
        End If

        'If Arch2 = "" Then
        '  MsgBox "El nombre del archivo de Semaforo no esta cargado.", vbOKOnly + vbExclamation
        'End If

        Cadena = ""
        N = 0
        LargoLinea = 0
        Puerto.PortName = SerialPuerto
        Puerto.BaudRate = SerialBaudRate
        Puerto.Parity = SerialParity
        Puerto.DataBits = SerialDataBits
        Puerto.StopBits = SerialStopBits

        'Puerto.InBufferSize = 20480
        'Puerto.OutBufferSize = 20480
        'Puerto.InputLen = 1
        'Puerto.PortOpen = True
        Puerto.Open()

        'Me.Caption = "Recibiendo: Com" & Puerto.CommPort & ":" & Puerto.Settings & ". BUFFER:" & CStr(Puerto.InBufferCount) _
        '& " de " & CStr(Puerto.InBufferSize)
        'Me.Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits

        Barra.Items(0).Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
        ErrorRed = False 'Comienza sin errores de red
        HayDatos = False 'Comienza sin datos en el temporal
        Forzar2 = False
        While Puerto.IsOpen
Inicio:
            'N = Puerto.InBufferCount
            N = Puerto.ReadBufferSize
            If N Or ForzarTemporal = True Then
                Forzar2 = ForzarTemporal
                If Forzar2 = False Then
                    C = CStr(Puerto.ReadByte())
                    C = Chr(CByte(Asc(C)) And CByte(127)) 'le saco el MSB
                    If (C <> Chr(10) And C <> Chr(13) And C <> "*") And (Cadena <> "" Or C <> " ") Then
                        Cadena = Cadena & C
                    End If
                    Barra.Items(0).Text = "Recibiendo Datos: " & Cadena
                    Me.Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
                End If

                If ((C = "*" Or C = Chr(13)) And (Trim(Cadena) <> "")) Or Forzar2 = True Then
                    If Forzar2 = False Then
                        If NuevaFila > 1800 Or FechaFila <> Date.Now.ToString("yyyyMMdd") Then
                            FechaFila = Date.Now.ToString("yyyyMMdd")
                            NuevaFila = 1
                            ' ''Grilla.Rows = 1
                            ' ''Grilla.Row = 1
                            ' ''Grilla.SelStartRow = 2
                            ' ''Grilla.SelEndRow = 2
                        End If

                        'MUESTRO EN LA GRILLA
                        'Grilla.AddItem(CStr(NuevaFila) & Chr(9) & _
                        Grilla.Rows.Add(Mid(Cadena, 1, 9), _
                                      Mid(Cadena, 11, 9), _
                                      Mid(Cadena, 22, 5), _
                                      Mid(Cadena, 28, 14), _
                                      Mid(Cadena, 43, 4), _
                                      Mid(Cadena, 48, 4), _
                                      Mid(Cadena, 52, 3), _
                                      Mid(Cadena, 55, 4), _
                                      Mid(Cadena, 59, 7))
                        ' ''Grilla.Col = 1
                        ' ''Grilla.Row = NuevaFila
                        ' ''Grilla.SelStartCol = 1
                        ' ''Grilla.SelEndCol = 9
                        ' ''Grilla.SelStartRow = NuevaFila
                        ' ''Grilla.SelEndRow = NuevaFila
                        If NuevaFila > 22 Then
                            ' ''Grilla.TopRow = NuevaFila - 22
                        End If
                        NuevaFila = NuevaFila + 1
                    End If 'if forzar2 = false
                    If Forzar2 = True Then
                        ForzarTemporal = False
                        Forzar2 = False
                        BBTemp.Visible = False
                        BBTemp.Enabled = False
                    End If
                    Err.Clear()
                    'Procedimiento que graba la informacion en el formato que BPCS precisa, pero en el disco local
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
                        ''Err.Clear()
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
                    'Open CStr(DirInstall & ArchivoTexto) For Append Access Write Lock Read Write As #1
                    FileOpen(1, CStr(DirInstall & ArchivoTexto), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                    If Err.Number <> 0 Then
                        'El enlace todavía no está restablecido
                        FileClose(1)
                        Err.Clear()
                        CadenaGlobal = Cadena
                        ErrorRed = True
                        FileClose(3)
                        If Cadena <> "" Then
                            Barra.Items(0).Text = "Guardando informacion temporal en " & ArchTempSec
                            Call GrabaTemp()
                        End If
                        Cadena = ""
                        Barra.Items(0).Text = ""
                        BBTemp.Visible = True
                        BBTemp.Enabled = True
                    Else
                        FileClose(1)
                        ErrorRed = False
                    End If

                    Do While ErrorRed = False 'LOOP creado para incluir el grabado de las secuencias en el archivo
                        If HayDatos = True Then
                            If EOF(3) = False Then
                                FileGet(3, Cadena)        'Input #3, Cadena
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
                            Kill(ArchTempSec)       ' Borrar Archivo temporal
                            ErrorRed = True         'para que salga del loop despues de procesar la variable Cadena
                            BBTemp.Visible = False
                            BBTemp.Enabled = False
                        End If

                        CadenaBpcs = Mid(Cadena, 1, 9) & Format(Now, "yyyymmdd") & Format(Now, "hhnnss") & _
                                     Mid(Cadena, 28, 14) & Mid(Cadena, 43, 4) & Mid(Cadena, 48, 4) & _
                                     Mid(Cadena, 52, 3) & Mid(Cadena, 55, 4) & Mid(Cadena, 59, 7)

                        'GUARDO EN HISTORICO
                        Call CreaNombreArchivo()
                        Barra.Items(0).Text = "Guardando informacion historica en " & DirInstall & ArchivoTexto

                        Do While True
                            'Open CStr(DirInstall & ArchivoTexto) For Append Access Write Lock Read Write As #1
                            FileOpen(1, CStr(DirInstall & ArchivoTexto), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                            If Err.Number <> 0 Then
                                FileClose(1)
                                Err.Clear()
                                If Tiempo <> CStr(TimeValue(Now)) Then
                                    Barra.Items(0).Text = "Esperando liberacion de archivo " & DirInstall & ArchivoTexto & ". " & Now.ToString("hh:mm:ss")
                                    Tiempo = CStr(TimeValue(Now))
                                End If
                                Me.Refresh()
                                Me.Text = "Recibiendo: Com" & Puerto.PortName & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
                            Else
                                Print(1, Cadena)
                                FileClose(1)
                                Barra.Items(0).Text = ""
                                Exit Do
                            End If
                        Loop

                        ' FIN REEMPLAZO POR SER ARCHIVO DE RED
                        Barra.Items(0).Text = ""
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

                        ' ''If ErrorCabecera = True Or ErrorDigitos = True Then
                        ' ''    For Each X In Printers
                        ' ''        If X.DeviceName = Impre1 Or X.DeviceName = Impre2 Then
                        ' ''            Printer = X
                        ' ''            Printer.Font = "Arial"
                        ' ''            Printer.FontBold = True
                        ' ''            Printer.FontSize = 32
                        ' ''            Printer.Print("____________________________")
                        ' ''            Printer.Print("---ERROR DE COMUNICACION---")
                        ' ''            Printer.Print("____________________________")
                        ' ''            Printer.FontSize = 24
                        ' ''            Printer.Print("Fecha: " & Format(Date.Now, "dd/mm/yyyy") & "  Hora: " & Format(Date.Now, "hh:mm:ss AMPM"))
                        ' ''            Printer.Print()
                        ' ''            Printer.FontSize = 32
                        ' ''            Printer.Print("---INFORMACION RECIBIDA---")
                        ' ''            Printer.FontSize = 14
                        ' ''            Printer.Print()
                        ' ''            Printer.Print(Cadena)
                        ' ''            Printer.EndDoc()
                        ' ''        End If
                        ' ''    Next
                        ' ''End If

                        'Grabo segun cabecera
                        On Error Resume Next
                        'MsgBox Mid(Cadena, 1, 9)
                        Select Case Mid(Cadena, 1, 9)
                            Case Header1(0), Header1(1), Header1(2)
                                Barra.Items(0).Text = "Guardando informacion en archivo de datos " & Arch1 & ". " & Now.ToString("hh:mm:ss")
                                Do While True
                                    'Open CStr(Arch1) For Append Access Write Lock Read Write As #2
                                    FileOpen(2, CStr(Arch1), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(2)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("hh:mm:ss") Then
                                            Barra.Items(0).Text = "Esperando liberacion de archivo " & Arch1 & ". " & Now.ToString("hh:mm:ss")
                                            Tiempo = Now.ToString("hh:mm:ss")
                                        End If
                                        Me.Refresh()
                                        'Me.Text = "Recibiendo: Com" & Puerto.CommPort & ":" & Puerto.BaudRate & "," & Puerto.Parity & "," & Puerto.DataBits & "," & Puerto.StopBits
                                    Else
                                        Print(2, CadenaBpcs)
                                        FileClose(2)
                                        Barra.Items(0).Text = ""
                                        Exit Do
                                    End If
                                Loop
                            Case Header2(0), Header2(1), Header2(2)
                                Barra.Items(0).Text = "Guardando informacion en archivo de datos " & Arch2 & ". " & Now.ToString("hh:mm:ss")
                                Do While True
                                    'Open CStr(Arch2) For Append Access Write Lock Read Write As #5
                                    FileOpen(5, CStr(Arch2), OpenMode.Append, OpenAccess.Write, OpenShare.LockReadWrite)
                                    If Err.Number <> 0 Then
                                        FileClose(5)
                                        Err.Clear()
                                        If Tiempo <> Now.ToString("hh:mm:ss") Then
                                            Barra.Items(0).Text = "Esperando liberacion de archivo " & Arch2 & ". " & Now.ToString("hh:mm:ss")
                                        End If
                                        Me.Refresh()
                                        'Me.Caption = "Recibiendo: Com" & Puerto.CommPort & ":" & Puerto.Settings & ". BUFFER:" & CStr(Puerto.InBufferCount) _
                                        '& " de " & CStr(Puerto.InBufferSize)
                                    Else
                                        Print(5, CadenaBpcs)
                                        FileClose(5)
                                        Barra.Items(0).Text = ""
                                        Exit Do
                                    End If
                                Loop
                        End Select
                        Cadena = ""
                    Loop            ' do While ErrorRed = True And HayDatos = True
                End If              'If (C = "*" Or C = Chr$(13)) And (Trim(Cadena) <> "") Then
            End If                  'If N then...
            Me.Refresh()            'VR = DoEvents()
        End While                   'While puerto.portopen..
    End Sub

    Private Sub BStop_Click()
        If Puerto.IsOpen Then
            Puerto.Close()
        End If
    End Sub

    Private Sub BSalir_Click()
        BParar_Click()
        End
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
        Call BConfigurar_Click()
    End Sub

    Private Sub Salir_Click()
        Call BSalir_Click()
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

    End Sub

    Private Sub BParar_Click()

    End Sub

    Private Sub frmSecuenciador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        'Me.Caption = "Recepcion de Secuencia Detenida"
        'Archivo de Configuracion .INI
        PathArchINI = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) + "\SecuenciaUnificada.ini"
        Dim LectArchINI As New LecturaArchivoINI

        'Leo desde el .INI
        'DirInstall = ProfileGetItem("MAIN", "DIRECTORIOARCHIVOS", "", sIniFile)
        'ParametroSerie = ProfileGetItem("MAIN", "PARAMETROSSERIE", "", sIniFile)

        DirInstall = LectArchINI.IniGet(PathArchINI, "MAIN", "DIRECTORIOARCHIVOS")

        SerialPuerto = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialPuerto")
        SerialBaudRate = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialBaudRate")
        SerialParity = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialParity")
        SerialDataBits = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialDataBits")
        SerialStopBits = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialStopBits")

        Arch1 = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH1")
        Arch2 = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH2")

        Dim Contador As Integer
        For Contador = 0 To 2
            Header1(Contador) = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH1HDR" & CStr(Contador))
        Next
        For Contador = 0 To 2
            Header2(Contador) = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH2HDR" & CStr(Contador))
        Next
        Impre1 = LectArchINI.IniGet(PathArchINI, "MAIN", "IMPERROR1")
        Impre2 = LectArchINI.IniGet(PathArchINI, "MAIN", "IMPERROR2")

        ArchTempSec = LectArchINI.IniGet(PathArchINI, "MAIN", "TEMPORARIOSECUENCIAS")

        'Nuevo Archivo de Contingencia
        DirContingencia = LectArchINI.IniGet(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA")
        DirContingencia2 = LectArchINI.IniGet(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA2")

        'Fin leo desde el .INI

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

        Call BRecibir_Click() ' Para que comience a recibir apenas arranque el programa

    End Sub

    Private Sub BBTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBTemp.Click
        ForzarTemporal = True
    End Sub
End Class
