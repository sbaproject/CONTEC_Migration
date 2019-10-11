VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.2#0"; "Threed5.ocx"
Begin VB.Form ICN_ICON 
   Appearance      =   0  'Ì×¯Ä
   AutoRedraw      =   -1  'True
   BackColor       =   &H80000005&
   BorderStyle     =   3  'ŒÅ’èÀÞ²±Û¸Þ
   ClientHeight    =   915
   ClientLeft      =   8235
   ClientTop       =   7755
   ClientWidth     =   3795
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "‚l‚r ƒSƒVƒbƒN"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "ICONSSS.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z µ°ÀÞ°
   ScaleHeight     =   915
   ScaleWidth      =   3795
   ShowInTaskbar   =   0   'False
   Begin Threed5.SSPanel5 SSPanel1 
      Height          =   915
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   3795
      _ExtentX        =   6694
      _ExtentY        =   1614
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderWidth     =   2
      MousePointer    =   11
      BevelInner      =   1
      BevelWidth      =   2
      Caption         =   "‚µ‚Î‚ç‚­‚¨‘Ò‚¿‚­‚¾‚³‚¢"
   End
End
Attribute VB_Name = "ICN_ICON"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Top = (Screen.Height - Height) / 2
    Left = (Screen.Width - Width) / 2
    Show
    DoEvents
End Sub
