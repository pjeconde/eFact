VERSION 4.00
Begin VB.Form AcercaDe 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Acerca de"
   ClientHeight    =   3345
   ClientLeft      =   1140
   ClientTop       =   1740
   ClientWidth     =   5280
   Height          =   3855
   Left            =   1080
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3345
   ScaleWidth      =   5280
   ShowInTaskbar   =   0   'False
   Top             =   1290
   Width           =   5400
   Begin VB.CommandButton Command1 
      Caption         =   "&Aceptar"
      Height          =   495
      Left            =   3720
      TabIndex        =   2
      Top             =   2640
      Width           =   1335
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      Height          =   1695
      Left            =   240
      Picture         =   "frmAcercaDe.frx":0000
      ScaleHeight     =   1635
      ScaleWidth      =   4695
      TabIndex        =   0
      Top             =   120
      Width           =   4755
   End
   Begin VB.Label Label1 
      Caption         =   "Departamento de Sistemas de LEAR Corporation América de Sur"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   2040
      Width           =   4815
   End
End
Attribute VB_Name = "AcercaDe"
Attribute VB_Creatable = False
Attribute VB_Exposed = False


Option Explicit

Private Sub Command1_Click()
  Unload Me
End Sub


