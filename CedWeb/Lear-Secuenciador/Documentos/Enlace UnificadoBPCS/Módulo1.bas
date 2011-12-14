Attribute VB_Name = "Módulo1"
Option Explicit

Public CuentaEnter As Integer
Public ArchivoTexto As String
Public ArchivoBat As String
Public DirInstall As String
Public NombreCola1 As String
Public NombreCola2 As String
Public ParametroSerie As String
Public PuertoSerie As Integer

Public NuevaFila As Integer
Public Arch1 As String
Public Arch2 As String
Public Header1(0 To 2) As String
Public Header2(0 To 2) As String

Public Impre1 As String
Public Impre2 As String

Public ArchBkp As String
Public ArchTempSec As String
Public CadenaGlobal As String
Public ForzarTemporal As Boolean

Public sIniFile  As String
Public DirContingencia As String
Public DirContingencia2 As String
Public NombreArchivoContingencia As String
Public CadenaContingencia As String


Public Declare Function GetPrivateProfileString _
   Lib "kernel32" Alias "GetPrivateProfileStringA" _
  (ByVal lpSectionName As String, _
   ByVal lpKeyName As Any, _
   ByVal lpDefault As String, _
   ByVal lpbuffurnedString As String, _
   ByVal nBuffSize As Long, _
   ByVal lpFileName As String) As Long
   
Public Declare Function WritePrivateProfileString _
   Lib "kernel32" Alias "WritePrivateProfileStringA" _
  (ByVal lpSectionName As String, _
   ByVal lpKeyName As Any, _
   ByVal lpString As Any, _
   ByVal lpFileName As String) As Long


Public Function ProfileGetItem(sSection As String, _
                                sKeyName As String, _
                                sDefValue As String, _
                                sIniFile As String) As String

  'retrieves a value from an ini file
  'corresponding to the section and
  'key name passed.
        
   Dim dwSize As Long
   Dim nBuffSize As Long
   Dim buff As String
  
  'Call the API with the parameters passed.
  'nBuffSize is the length of the string
  'in buff, including the terminating null.
  'If a default value was passed, and the
  'section or key name are not in the file,
  'that value is returned. If no default
  'value was passed (""), then dwSize
  'will = 0 if not found.
  '
  'pad a string large enough to hold the data
   buff = Space$(2048)
   nBuffSize = Len(buff)
   dwSize = GetPrivateProfileString(sSection, _
                                    sKeyName, _
                                    sDefValue, _
                                    buff, _
                                    nBuffSize, _
                                    sIniFile)
   
   If dwSize > 0 Then
      ProfileGetItem = Left$(buff, dwSize)
   End If
   
End Function

Public Sub ProfileSaveItem(sSection As String, _
                            sKeyName As String, _
                            sValue As String, _
                            sIniFile As String)

  'This function saves the passed value to the file,
  'under the section and key name specified.
  '
  'If the ini file does not exist, it is created.
  'If the section does not exist, it is created within the file.
  'If the key name does not exist, it is created under the section.
  'If the key name exists, it's value is replaced.
   
   Call WritePrivateProfileString(sSection, sKeyName, sValue, sIniFile)

End Sub

