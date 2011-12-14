VERSION 4.00
Begin VB.Form frmConfiguracion 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Configuracion"
   ClientHeight    =   7530
   ClientLeft      =   1320
   ClientTop       =   825
   ClientWidth     =   7305
   Height          =   8040
   Left            =   1260
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7530
   ScaleWidth      =   7305
   ShowInTaskbar   =   0   'False
   Top             =   375
   Width           =   7425
   Begin VB.TextBox DT1H 
      Height          =   285
      Index           =   2
      Left            =   5760
      MaxLength       =   9
      TabIndex        =   15
      Text            =   " "
      Top             =   2400
      Width           =   1215
   End
   Begin VB.TextBox DT1H 
      Height          =   285
      Index           =   1
      Left            =   4440
      MaxLength       =   9
      TabIndex        =   14
      Text            =   " "
      Top             =   2400
      Width           =   1215
   End
   Begin VB.CommandButton BAceptaConfig 
      Caption         =   "&Aceptar"
      Height          =   495
      Left            =   4200
      TabIndex        =   6
      Top             =   6600
      Width           =   1335
   End
   Begin VB.CommandButton BCancelaConfig 
      Caption         =   "&Cancelar"
      Height          =   495
      Left            =   5760
      TabIndex        =   5
      Top             =   6600
      Width           =   1335
   End
   Begin VB.Frame Frame1 
      Caption         =   "Configuracion "
      Height          =   6255
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   6975
      Begin VB.TextBox TContingencia2 
         Height          =   285
         Left            =   3000
         TabIndex        =   31
         Text            =   " "
         Top             =   3720
         Width           =   3855
      End
      Begin VB.TextBox TContingencia 
         Height          =   285
         Left            =   3000
         TabIndex        =   30
         Text            =   " "
         Top             =   2520
         Width           =   3855
      End
      Begin VB.TextBox TTempSec 
         Height          =   285
         Left            =   3000
         TabIndex        =   28
         Text            =   " "
         Top             =   5760
         Width           =   3855
      End
      Begin VB.ComboBox Impresora2 
         Height          =   315
         Left            =   3000
         Style           =   2  'Dropdown List
         TabIndex        =   26
         Top             =   5400
         Width           =   3855
      End
      Begin VB.ComboBox Impresora1 
         Height          =   315
         Left            =   3000
         Style           =   2  'Dropdown List
         TabIndex        =   25
         Top             =   4680
         Width           =   3855
      End
      Begin VB.TextBox ImpError2 
         Height          =   285
         Left            =   3000
         TabIndex        =   24
         Top             =   5040
         Width           =   3855
      End
      Begin VB.TextBox ImpError1 
         Height          =   285
         Left            =   3000
         TabIndex        =   23
         Top             =   4320
         Width           =   3855
      End
      Begin VB.TextBox DT2H 
         Height          =   285
         Index           =   2
         Left            =   5640
         TabIndex        =   18
         Top             =   3360
         Width           =   1215
      End
      Begin VB.TextBox DT2H 
         Height          =   285
         Index           =   1
         Left            =   4320
         TabIndex        =   17
         Top             =   3360
         Width           =   1215
      End
      Begin VB.TextBox DT2H 
         Height          =   285
         Index           =   0
         Left            =   3000
         TabIndex        =   16
         Top             =   3360
         Width           =   1215
      End
      Begin VB.TextBox DT1H 
         Height          =   285
         Index           =   0
         Left            =   3000
         MaxLength       =   9
         TabIndex        =   13
         Text            =   " "
         Top             =   2160
         Width           =   1215
      End
      Begin VB.TextBox TArch2 
         Height          =   285
         Left            =   3000
         TabIndex        =   11
         Text            =   " "
         Top             =   3000
         Width           =   3855
      End
      Begin VB.TextBox TArch1 
         Height          =   285
         Left            =   3000
         TabIndex        =   9
         Text            =   " "
         Top             =   1800
         Width           =   3855
      End
      Begin VB.TextBox TPuertoSerie 
         Height          =   285
         Left            =   3000
         TabIndex        =   7
         Text            =   " "
         Top             =   1200
         Width           =   3855
      End
      Begin VB.TextBox TSerial 
         Height          =   285
         Left            =   3000
         TabIndex        =   4
         Text            =   " "
         Top             =   840
         Width           =   3855
      End
      Begin VB.TextBox TDirectorio 
         Height          =   285
         Left            =   3000
         TabIndex        =   3
         Text            =   " "
         Top             =   480
         Width           =   3855
      End
      Begin VB.Label Label12 
         Alignment       =   1  'Right Justify
         Caption         =   "Directorio de Contingencia 2:"
         Height          =   255
         Left            =   120
         TabIndex        =   32
         Top             =   3720
         Width           =   2775
      End
      Begin VB.Label Label11 
         Alignment       =   1  'Right Justify
         Caption         =   "Directorio de Contingencia 1:"
         Height          =   255
         Left            =   120
         TabIndex        =   29
         Top             =   2520
         Width           =   2775
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         Caption         =   "Archivo Temporario de Secuencias:"
         Height          =   255
         Left            =   120
         TabIndex        =   27
         Top             =   5760
         Width           =   2775
      End
      Begin VB.Label Label9 
         Alignment       =   1  'Right Justify
         Caption         =   "Impresora de Error 2:"
         Height          =   255
         Left            =   1200
         TabIndex        =   22
         Top             =   5040
         Width           =   1695
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         Caption         =   "Impresora de Error 1:"
         Height          =   255
         Left            =   1200
         TabIndex        =   21
         Top             =   4320
         Width           =   1695
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         Caption         =   "Encabezados Archivo 2:"
         Height          =   255
         Left            =   600
         TabIndex        =   20
         Top             =   3360
         Width           =   2295
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "Encabezados Archivo 1:"
         Height          =   255
         Left            =   360
         TabIndex        =   19
         Top             =   2160
         Width           =   2535
      End
      Begin VB.Label Label8 
         Alignment       =   1  'Right Justify
         Caption         =   "Archivo de Datos 2:"
         Height          =   255
         Left            =   240
         TabIndex        =   12
         Top             =   3000
         Width           =   2655
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         Caption         =   "Archivo de Datos 1:"
         Height          =   255
         Left            =   240
         TabIndex        =   10
         Top             =   1800
         Width           =   2655
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         Caption         =   "Puerto Serie:"
         Height          =   255
         Left            =   240
         TabIndex        =   8
         Top             =   1200
         Width           =   2655
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         Caption         =   "Parámetros de Comunicacion Serie:"
         Height          =   255
         Left            =   240
         TabIndex        =   2
         Top             =   840
         Width           =   2655
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "Directorio de Archivos Históricos:"
         Height          =   255
         Left            =   240
         TabIndex        =   1
         Top             =   480
         Width           =   2655
      End
   End
End
Attribute VB_Name = "frmConfiguracion"
Attribute VB_Creatable = False
Attribute VB_Exposed = False


Option Explicit

Private Sub BAceptaConfig_Click()
  Dim Contador As Integer
    
  If Right(TDirectorio.Text, 1) <> "\" Then
    TDirectorio.Text = TDirectorio.Text & "\"
  End If
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "DIRECTORIOARCHIVOS", TDirectorio.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "PARAMETROSSERIE", TSerial.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "PUERTOSERIE", TPuertoSerie.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "ARCH1", TArch1.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "ARCH2", TArch2.Text
  
  'Graba en .INI
  Call ProfileSaveItem("MAIN", "DIRECTORIOARCHIVOS", TDirectorio.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "PARAMETROSSERIE", TSerial.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "PUERTOSERIE", TPuertoSerie.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "ARCH1", TArch1.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "ARCH2", TArch2.Text, sIniFile)
  'Fin Graba en .INI
  
  For Contador = 0 To 2
    'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "ARCH1HDR" & CStr(Contador), DT1H(Contador).Text
    'Graba en .INI
    Call ProfileSaveItem("MAIN", "ARCH1HDR" & CStr(Contador), DT1H(Contador), sIniFile)
    'Fin Graba en .INI
    Header1(Contador) = DT1H(Contador).Text
  Next
  For Contador = 0 To 2
    'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "ARCH2HDR" & CStr(Contador), DT2H(Contador).Text
    'Graba en .INI
    Call ProfileSaveItem("MAIN", "ARCH2HDR" & CStr(Contador), DT2H(Contador), sIniFile)
    'Fin Graba en .INI
    Header2(Contador) = DT2H(Contador).Text
  Next
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "IMPERROR1", ImpError1.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "IMPERROR2", ImpError2.Text
  'SaveSetting "LEAR-Secuenciado-BPCS", "MAIN", "TEMPORARIOSECUENCIAS", TTempSec.Text
  
  'Graba en .INI
  Call ProfileSaveItem("MAIN", "IMPERROR1", ImpError1.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "IMPERROR2", ImpError2.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "TEMPORARIOSECUENCIAS", TTempSec.Text, sIniFile)
  'Nuevo Archivo de Contingencia
  If Right(TContingencia.Text, 1) <> "\" Then
    TContingencia.Text = TContingencia.Text & "\"
  End If
  If Right(TContingencia2.Text, 1) <> "\" Then
    TContingencia2.Text = TContingencia2.Text & "\"
  End If
  
  Call ProfileSaveItem("MAIN", "DIRECTORIOCONTINGENCIA", TContingencia.Text, sIniFile)
  Call ProfileSaveItem("MAIN", "DIRECTORIOCONTINGENCIA2", TContingencia2.Text, sIniFile)

  'Fin Graba en .INI
   
  
  DirInstall = TDirectorio.Text
  ParametroSerie = TSerial.Text
  PuertoSerie = CInt(TPuertoSerie.Text)
  Arch1 = TArch1.Text
  Arch2 = TArch2.Text
  Impre1 = ImpError1.Text
  Impre2 = ImpError2.Text
  DirContingencia = TContingencia.Text
  DirContingencia2 = TContingencia2.Text
  
  Unload Me

End Sub


Private Sub BCancelaConfig_Click()
  Unload Me
End Sub


Private Sub Form_Load()
  Dim Contador As Integer
  Dim X As Printer
  For Each X In Printers
    Impresora1.AddItem X.DeviceName
    Impresora2.AddItem X.DeviceName
  Next
  Impresora1.ListIndex = 0
  Impresora2.ListIndex = 0
  
  'TDirectorio.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "DIRECTORIOARCHIVOS", "")
  'TSerial.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "PARAMETROSSERIE", "")
  'TPuertoSerie.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "PUERTOSERIE", "1")
  'TArch1.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "ARCH1", "")
  'TArch2.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "ARCH2", "")
  'For Contador = 0 To 2
  '  DT1H(Contador).Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "ARCH1HDR" & CStr(Contador), "")
  'Next
  'For Contador = 0 To 2
  '  DT2H(Contador).Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "ARCH2HDR" & CStr(Contador), "")
  'Next
  'ImpError1.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "IMPERROR1", "")
  'ImpError2.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "IMPERROR2", "")
  'TTempSec.Text = GetSetting("LEAR-Secuenciado-BPCS", "MAIN", "TEMPORARIOSECUENCIAS", "")
  
  'Leo desde el .INI
  TDirectorio.Text = ProfileGetItem("MAIN", "DIRECTORIOARCHIVOS", "", sIniFile)
  TSerial.Text = ProfileGetItem("MAIN", "PARAMETROSSERIE", "", sIniFile)
  TPuertoSerie.Text = ProfileGetItem("MAIN", "PUERTOSERIE", "1", sIniFile)
  TArch1.Text = ProfileGetItem("MAIN", "ARCH1", "", sIniFile)
  TArch2.Text = ProfileGetItem("MAIN", "ARCH2", "", sIniFile)
  For Contador = 0 To 2
    DT1H(Contador).Text = ProfileGetItem("MAIN", "ARCH1HDR" & CStr(Contador), "", sIniFile)
  Next
  For Contador = 0 To 2
    DT2H(Contador).Text = ProfileGetItem("MAIN", "ARCH2HDR" & CStr(Contador), "", sIniFile)
  Next
  ImpError1.Text = ProfileGetItem("MAIN", "IMPERROR1", "", sIniFile)
  ImpError2.Text = ProfileGetItem("MAIN", "IMPERROR2", "", sIniFile)
  TTempSec.Text = ProfileGetItem("MAIN", "TEMPORARIOSECUENCIAS", "", sIniFile)
  'Nuevo Archivo de Contingencia
  TContingencia.Text = ProfileGetItem("MAIN", "DIRECTORIOCONTINGENCIA", "", sIniFile)
  TContingencia2.Text = ProfileGetItem("MAIN", "DIRECTORIOCONTINGENCIA2", "", sIniFile)
  'Fin leo desde el .INI
    
  
End Sub


Private Sub Impresora1_Change()
  ImpError1.Text = Impresora1.Text
End Sub


Private Sub Impresora1_Click()
ImpError1.Text = Impresora1.Text
End Sub


Private Sub Impresora2_Change()
  ImpError2.Text = Impresora2.Text
End Sub


Private Sub Impresora2_Click()
 ImpError2.Text = Impresora2.Text
End Sub


