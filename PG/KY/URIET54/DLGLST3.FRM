VERSION 5.00
Begin VB.Form DLGLST3 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "確認ボックス"
   ClientHeight    =   1245
   ClientLeft      =   5235
   ClientTop       =   6360
   ClientWidth     =   5400
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form1"
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   1245
   ScaleWidth      =   5400
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "戻　る"
      Height          =   330
      Index           =   3
      Left            =   4095
      TabIndex        =   4
      Top             =   765
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "発行のみ"
      Height          =   330
      Index           =   2
      Left            =   2835
      TabIndex        =   3
      Top             =   765
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "計上のみ"
      Height          =   330
      Index           =   1
      Left            =   1575
      TabIndex        =   2
      Top             =   765
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "計上し発行"
      Height          =   330
      Index           =   0
      Left            =   225
      TabIndex        =   1
      Top             =   765
      Width           =   1260
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Caption         =   "処理を選択してください。"
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   270
      TabIndex        =   0
      Top             =   180
      Width           =   4920
   End
End
Attribute VB_Name = "DLGLST3"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub CMD_SELECT_Click(Index As Integer)
    SSS_RTNWIN = Index
    Unload Me
End Sub

Private Sub Form_Load()
    Caption = FR_SSSMAIN.Caption
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
End Sub
