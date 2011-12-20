Public Module Modulo

    Public Produccion As Boolean

    Public DirectorioArchivos As String         'Antes llamado DirInstall 
    Public PathArchINI As String

    Public SerialPuerto As String
    Public SerialBaudRate As String
    Public SerialParity As String
    Public SerialDataBits As String
    Public SerialStopBits As String

    Public TCPHabilitado As Boolean
    Public TCPPuerto As String
    Public TCPIP As String
    Public TCPCantBytesBuffer As String

    Public Arch1 As String
    Public Arch2 As String

    Public Header1(3) As String
    Public Header2(3) As String

    Public Impre1 As String
    Public Impre2 As String

    Public ArchTempSec As String

    Public DirContingencia As String
    Public DirContingencia2 As String

    Public ArchLog As String

    Public Function VerificarConfiguracion(ByVal TCPHabilitado As Boolean) As Boolean
        VerificarConfiguracion = False
        If TCPHabilitado Then
            If TCPPuerto = "" Then
                MsgBox("El parámetro de configuración Puerto TCP no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
            If TCPIP = "" Then
                MsgBox("El parámetro de configuración Host TCP/IP del puerto serie no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
        Else
            If SerialBaudRate = "" Then
                MsgBox("El parámetro de configuración BaudRate del puerto serie no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
            If SerialParity = "" Then
                MsgBox("El parámetro de configuración Parity del puerto serie no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
            If SerialDataBits = "" Then
                MsgBox("El parámetro de configuración DataBits del puerto serie no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
            If SerialStopBits = "" Then
                MsgBox("El parámetro de configuración StopBits del puerto serie no está cargado.", vbOKOnly + vbCritical)
                Exit Function
            End If
            If SerialPuerto < 1 Or SerialPuerto > 4 Then
                MsgBox("El Puerto Serie a utilizar no esta configurado.", vbOKOnly + vbCritical)
                Exit Function
            End If
        End If
        If DirectorioArchivos = "" Then
            MsgBox("El directorio de Archivos no está configurado.", vbOKOnly + vbCritical)
            Exit Function
        End If
        If Arch1 = "" Then
            MsgBox("El nombre del Archivo de Datos 1 no esta cargado.", vbOKOnly + vbCritical)
            Exit Function
        End If
        If Arch2 = "" Then
            MsgBox("El nombre del Archivo de Datos 2 no esta cargado.", vbOKOnly + vbCritical)
            Exit Function
        End If
        VerificarConfiguracion = True
    End Function

    Public Sub LeerConfiguración()
        PathArchINI = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) + "\SecuenciaUnificada.ini"
        Dim LectArchINI As New LecturaArchivoINI

        Produccion = LectArchINI.IniGet(PathArchINI, "MAIN", "Produccion")

        DirectorioArchivos = LectArchINI.IniGet(PathArchINI, "MAIN", "DirectorioArchivos")

        SerialPuerto = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialPuerto")
        SerialBaudRate = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialBaudRate")
        SerialParity = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialParity")
        SerialDataBits = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialDataBits")
        SerialStopBits = LectArchINI.IniGet(PathArchINI, "MAIN", "SerialStopBits")

        TCPHabilitado = LectArchINI.IniGet(PathArchINI, "MAIN", "TCPHabilitado")
        TCPPuerto = LectArchINI.IniGet(PathArchINI, "MAIN", "TCPPuerto")
        TCPIP = LectArchINI.IniGet(PathArchINI, "MAIN", "TCPIP")
        TCPCantBytesBuffer = LectArchINI.IniGet(PathArchINI, "MAIN", "TCPCantBytesBuffer")

        Arch1 = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH1")
        Arch2 = LectArchINI.IniGet(PathArchINI, "MAIN", "ARCH2")

        Dim Contador As Integer
        For Contador = 0 To 2
            Header1(Contador) = LectArchINI.IniGet(PathArchINI, "MAIN", "Arch1Hdr" & CStr(Contador))
        Next
        For Contador = 0 To 2
            Header2(Contador) = LectArchINI.IniGet(PathArchINI, "MAIN", "Arch2Hdr" & CStr(Contador))
        Next
        Impre1 = LectArchINI.IniGet(PathArchINI, "MAIN", "ImpError1")
        Impre2 = LectArchINI.IniGet(PathArchINI, "MAIN", "ImpError2")

        ArchTempSec = LectArchINI.IniGet(PathArchINI, "MAIN", "TEMPORARIOSECUENCIAS")

        DirContingencia = LectArchINI.IniGet(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA")
        DirContingencia2 = LectArchINI.IniGet(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA2")

        ArchLog = LectArchINI.IniGet(PathArchINI, "MAIN", "ArchLog")

    End Sub

    Public Sub GrabarConfiguracion()
        PathArchINI = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location.ToString()) + "\SecuenciaUnificada.ini"
        Dim LectArchINI As New LecturaArchivoINI

        LectArchINI.IniWrite(PathArchINI, "MAIN", "DIRECTORIOARCHIVOS", DirectorioArchivos)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "SerialPuerto", SerialPuerto)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "SerialBaudRate", SerialBaudRate)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "SerialParity", SerialParity)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "SerialDataBits", SerialDataBits)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "SerialStopBits", SerialStopBits)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "TCPHabilitado", TCPHabilitado)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "TCPIP", TCPIP)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "TCPPuerto", TCPPuerto)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "TCPCantBytesBuffer", TCPCantBytesBuffer)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "ARCH1", Arch1)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "ARCH2", Arch1)

        Dim Contador As Integer
        For Contador = 0 To 2
            LectArchINI.IniWrite(PathArchINI, "MAIN", "ARCH1HDR" & CStr(Contador), Header1(Contador))
        Next
        For Contador = 0 To 2
            LectArchINI.IniWrite(PathArchINI, "MAIN", "ARCH2HDR" & CStr(Contador), Header2(Contador))
        Next
        LectArchINI.IniWrite(PathArchINI, "MAIN", "IMPERROR1", Impre1)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "IMPERROR2", Impre2)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "TEMPORARIOSECUENCIAS", ArchTempSec)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA", DirContingencia)
        LectArchINI.IniWrite(PathArchINI, "MAIN", "DIRECTORIOCONTINGENCIA2", DirContingencia2)

        LectArchINI.IniWrite(PathArchINI, "MAIN", "ArchLog", ArchLog)
    End Sub

End Module
