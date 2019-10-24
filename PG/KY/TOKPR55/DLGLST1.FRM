VERSION 5.00
Begin VB.Form DLGLST1 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "確認ボックス"
   ClientHeight    =   1245
   ClientLeft      =   4305
   ClientTop       =   5790
   ClientWidth     =   4185
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
   ScaleWidth      =   4185
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "戻　る"
      Height          =   330
      Index           =   3
      Left            =   2775
      TabIndex        =   4
      Top             =   765
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ﾌｧｲﾙ出力"
      Enabled         =   0   'False
      Height          =   330
      Index           =   2
      Left            =   5505
      TabIndex        =   3
      Top             =   780
      Visible         =   0   'False
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "画面表示"
      Height          =   330
      Index           =   1
      Left            =   1530
      TabIndex        =   2
      Top             =   765
      Width           =   1170
   End
   Begin VB.CommandButton CMD_SELECT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "印　刷"
      Height          =   330
      Index           =   0
      Left            =   270
      TabIndex        =   1
      Top             =   765
      Width           =   1170
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
      Width           =   3645
   End
End
Attribute VB_Name = "DLGLST1"
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
    Top = FR_SSSMAIN.Top + FR_SSSMAIN.Height - Height
    Left = FR_SSSMAIN.Left + FR_SSSMAIN.Width - Width
    
'CHG START FKS)INABA 2006/11/15******************************************************************
'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
    '実行権限の取得
    Call Get_Authority(DB_UNYMTA.UNYDT)
    
    '先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
    If gs_PRTAUTH = "1" Then '印刷権限有り
        CMD_SELECT(0).Enabled = True
        CMD_SELECT(1).Enabled = True
    Else
        CMD_SELECT(0).Enabled = False
        CMD_SELECT(1).Enabled = True
    End If
    If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(2).Enabled = True
    Else
        CMD_SELECT(1).Enabled = True
        CMD_SELECT(2).Enabled = False
    End If
'CHG  END  FKS)INABA 2006/11/15******************************************************************


End Sub
