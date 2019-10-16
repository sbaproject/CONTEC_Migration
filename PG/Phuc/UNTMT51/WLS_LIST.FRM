VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_LIST 
   Appearance      =   0  'Ì×¯Ä
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  'ŒÅ’èÀÞ²±Û¸Þ
   Caption         =   "•ª—Þ"
   ClientHeight    =   4245
   ClientLeft      =   5250
   ClientTop       =   3585
   ClientWidth     =   4170
   ClipControls    =   0   'False
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
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z µ°ÀÞ°
   ScaleHeight     =   4245
   ScaleWidth      =   4170
   Begin Threed5.SSPanel5 PNL 
      Height          =   375
      Left            =   0
      TabIndex        =   3
      Top             =   4275
      Width           =   4155
      _ExtentX        =   5106
      _ExtentY        =   503
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'Ì×¯Ä
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   990
      TabIndex        =   2
      Top             =   3780
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'Ì×¯Ä
      BackColor       =   &H80000005&
      Caption         =   "·¬Ý¾Ù"
      Height          =   330
      Left            =   2160
      TabIndex        =   1
      Top             =   3780
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'Ì×¯Ä
      Height          =   3630
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   4155
   End
End
Attribute VB_Name = "WLS_LIST"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private DblClickFl As Boolean  'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07

Private Sub Form_Activate()
    WLSOK.Left = (WLS_LIST.Width - (WLSOK.Width + WLSCANCEL.Width + 60)) / 2
    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
    If (LST.ListCount > 0) And (LST.ListIndex < 0) Then LST.ListIndex = 0
    'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    WLS_LIST.Top = (Screen.Height - WLS_LIST.Height) / 2
    WLS_LIST.Left = (Screen.Width - WLS_LIST.Width) / 2
    Call Init_Prompt
End Sub

Private Sub LST_DblClick()
    'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07
    DblClickFl = True

    Call LST_KeyDown(13, 0)
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case 13
            Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), SSS_WLSLIST_KETA)
            'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07
            'Call WLSCANCEL_CLICK
            If DblClickFl = False Then Call WLSCANCEL_CLICK
        Case 27
            Call WLSCANCEL_CLICK
    End Select
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub WLSCANCEL_CLICK()
    'UnLoadƒCƒxƒ“ƒgáŠQ‘Î‰ž  97/04/07
    'Unload Me
    Hide
End Sub

Private Sub WLSOK_Click()
    Call LST_KeyDown(13, 0)
End Sub

