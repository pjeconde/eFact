Public Class LecturaArchivoINI
    'Funci�n api que recupera un valor-dato de un archivo Ini  
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" ( _
        ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpReturnedString As String, _
        ByVal nSize As UInt32, _
        ByVal lpFileName As String) As UInt32

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" ( _
        ByVal lpApplicationName As String, _
        ByVal lpKeyName As String, _
        ByVal lpString As String, _
        ByVal lpFileName As String) As Boolean

    Public Function IniGet(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, Optional ByVal sDefault As String = "") As String
        '--------------------------------------------------------------------------
        ' Devuelve el valor de una clave de un fichero INI
        ' Los par�metros son:
        '   sFileName   El fichero INI
        '   sSection    La secci�n de la que se quiere leer
        '   sKeyName    Clave
        '   sDefault    Valor opcional que devolver� si no se encuentra la clave
        '--------------------------------------------------------------------------
        Dim ret As UInt32
        Dim sRetVal As String
        '
        sRetVal = New String(Chr(0), 255)
        '
        ret = GetPrivateProfileString(sSection, sKeyName, sDefault, sRetVal, Convert.ToUInt32(sRetVal.Length()), sFileName)
        If ret = 0 Then
            Return sDefault
        Else
            Return sRetVal.Substring(0, ret)
        End If
    End Function

    Public Sub IniWrite(ByVal sFileName As String, ByVal sSection As String, ByVal sKeyName As String, ByVal sValue As String)
        '--------------------------------------------------------------------------
        ' Guarda los datos de configuraci�n
        ' Los par�metros son los mismos que en LeerIni
        ' Siendo sValue el valor a guardar
        '
        Dim ret As Boolean
        ret = WritePrivateProfileString(sSection, sKeyName, sValue, sFileName)
    End Sub
End Class
