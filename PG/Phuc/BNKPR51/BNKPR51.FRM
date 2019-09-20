VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "銀行一覧マスタリスト"
   ClientHeight    =   5535
   ClientLeft      =   1935
   ClientTop       =   3960
   ClientWidth     =   8625
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
   Icon            =   "BNKPR51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   5535
   ScaleWidth      =   8625
   Begin VB.TextBox HD_OPENM 
      Alignment       =   0  '左揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      FontName        =   "ＭＳ ゴシック"
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Left            =   5940
      MaxLength       =   24
      TabIndex        =   17
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   720
      Width           =   2265
   End
   Begin VB.TextBox HD_OPEID 
      Alignment       =   0  '左揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      FontName        =   "ＭＳ ゴシック"
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   5250
      MaxLength       =   10
      TabIndex        =   16
      Text            =   "XXXXX6"
      Top             =   720
      Width           =   705
   End
   Begin VB.Frame Frame3D1 
      Caption         =   "条件指定"
      ForeColor       =   &H00000000&
      Height          =   1785
      Left            =   360
      TabIndex        =   5
      Top             =   1560
      Width           =   7845
      Begin VB.TextBox HD_ENDBNKNM 
         Alignment       =   0  '左揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         FontName        =   "ＭＳ ゴシック"
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   2090
         MaxLength       =   54
         TabIndex        =   20
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
         Top             =   960
         Width           =   5415
      End
      Begin VB.TextBox HD_STTBNKNM 
         Alignment       =   0  '左揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         FontName        =   "ＭＳ ゴシック"
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   2090
         MaxLength       =   54
         TabIndex        =   19
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
         Top             =   480
         Width           =   5415
      End
      Begin VB.TextBox HD_ENDBNKCD 
         Alignment       =   0  '左揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFFFFF&
         FontName        =   "ＭＳ ゴシック"
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   1200
         MaxLength       =   11
         TabIndex        =   7
         Text            =   "XXXXXX7"
         Top             =   960
         Width           =   900
      End
      Begin VB.TextBox HD_STTBNKCD 
         Alignment       =   0  '左揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFFFFF&
         FontName        =   "ＭＳ ゴシック"
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   1200
         MaxLength       =   11
         TabIndex        =   6
         Text            =   "XXXXXX7"
         Top             =   480
         Width           =   900
      End
      Begin VB.Label Label2 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "銀行"
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   495
         TabIndex        =   9
         Top             =   540
         Width           =   660
      End
      Begin VB.Label Label1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Caption         =   "～"
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   840
         TabIndex        =   8
         Top             =   960
         Width           =   375
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1410
      Left            =   270
      TabIndex        =   3
      Top             =   5760
      Width           =   8295
      _ExtentX        =   11933
      _ExtentY        =   2011
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFC0FF&
         Height          =   330
         Left            =   1575
         TabIndex        =   4
         Text            =   "ﾓｰﾄﾞ"
         Top             =   630
         Width           =   735
      End
      Begin MSComDlg.CommonDialog CMDialogL 
         Left            =   45
         Top             =   630
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1845
         Picture         =   "BNKPR51.frx":000C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   990
         Picture         =   "BNKPR51.frx":0196
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "BNKPR51.frx":0320
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "BNKPR51.frx":04AA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1395
         Picture         =   "BNKPR51.frx":0634
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2160
         Picture         =   "BNKPR51.frx":07BE
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2520
         Picture         =   "BNKPR51.frx":0948
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2880
         Picture         =   "BNKPR51.frx":0AD2
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3240
         Picture         =   "BNKPR51.frx":0C5C
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3600
         Picture         =   "BNKPR51.frx":0DE6
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3960
         Picture         =   "BNKPR51.frx":0F70
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4320
         Picture         =   "BNKPR51.frx":10FA
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2025
         Picture         =   "BNKPR51.frx":1284
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   2430
         Picture         =   "BNKPR51.frx":140E
         Top             =   495
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D14 
      Height          =   555
      Left            =   -45
      TabIndex        =   1
      Top             =   0
      Width           =   8700
      _ExtentX        =   15346
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 SYSDT 
         Height          =   285
         Left            =   6570
         TabIndex        =   2
         Top             =   135
         Width           =   1410
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "YYYY/MM/DD"
      End
      Begin VB.Label Label3 
         Caption         =   "　"
         Height          =   495
         Left            =   4680
         TabIndex        =   15
         Top             =   0
         Width           =   855
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1680
         Picture         =   "BNKPR51.frx":1598
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   225
         Picture         =   "BNKPR51.frx":1722
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   585
         Picture         =   "BNKPR51.frx":18AC
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1320
         Picture         =   "BNKPR51.frx":1A36
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   945
         Picture         =   "BNKPR51.frx":1BC0
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   4920
         Picture         =   "BNKPR51.frx":1D4A
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   4515
      End
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   36855
      Top             =   36855
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  'ﾌﾗｯﾄ
      BorderStyle     =   0  'なし
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   36855
      TabIndex        =   0
      Top             =   36855
      Width           =   285
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   -45
      TabIndex        =   10
      Top             =   4950
      Width           =   8700
      _ExtentX        =   15346
      _ExtentY        =   1138
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   375
         Index           =   2
         Left            =   585
         TabIndex        =   11
         Top             =   135
         Width           =   7890
         _ExtentX        =   13917
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'なし
            ForeColor       =   &H00000000&
            Height          =   195
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   12
            Text            =   "BNKPR51.frx":1ED4
            Top             =   90
            Width           =   5235
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "BNKPR51.frx":1F0B
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 GAUGE 
      Height          =   420
      Left            =   450
      TabIndex        =   13
      Top             =   3510
      Width           =   7605
      _ExtentX        =   13414
      _ExtentY        =   741
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "Panel3D2"
      FloodType       =   1
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CM_LCANCEL 
      Height          =   285
      Left            =   3690
      TabIndex        =   14
      TabStop         =   0   'False
      Top             =   4140
      Width           =   1140
      _ExtentX        =   2328
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "中 止"
      OutLine         =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   330
      Index           =   4
      Left            =   4080
      TabIndex        =   18
      Top             =   720
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "入力担当者"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "処理(&1)"
      Begin VB.Menu MN_LSTART 
         Caption         =   "印刷(&P)"
         Shortcut        =   ^P
      End
      Begin VB.Menu MN_VSTART 
         Caption         =   "画面表示"
      End
      Begin VB.Menu MN_FSTART 
         Caption         =   "ファイル出力"
      End
      Begin VB.Menu MN_LCONFIG 
         Caption         =   "印刷設定(&I)..."
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "終了(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "編集(&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "画面初期化(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "項目初期化"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "項目復元"
      End
      Begin VB.Menu Bar21 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Cut 
         Caption         =   "切り取り(&X)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "コピー(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "貼り付け(&V)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "補助(&3)"
      Begin VB.Menu MN_Slist 
         Caption         =   "ウインドウ表示(&L)"
         Shortcut        =   {F5}
      End
   End
   Begin VB.Menu SM_ShortCut
      Caption         =   "ShortCut"
      Visible         =   0   'False
      Begin VB.Menu SM_AllCopy
         Caption         =   "項目内容コピー(&C)"
      End
      Begin VB.Menu SM_FullPast
         Caption         =   "項目に貼り付け(&P)"
      End
      Begin VB.Menu SM_Esc
         Caption         =   "取消し(Esc)"
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
'*** End Of Generated Declaration Section ****


Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "メニューに戻ります。"
End Sub

Private Sub CM_FSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ファイルに出力します。"
End Sub

Private Sub CM_LCONFIG_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "プリンターを選択します。"
End Sub

Private Sub CM_LSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "印刷を開始します。"
End Sub

Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ウィンドウを表示します。"
End Sub

Private Sub CM_VSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "印刷イメージを表示します。"
End Sub

Private Sub CM_EndCm_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   PP_SSSMAIN.CloseCode = 1
   Call AE_EndCm_SSSMAIN
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_ENDCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_ENDCM.Picture = IM_ENDCM(1).Picture
End Sub

Private Sub CM_ENDCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_ENDCM.Picture = IM_ENDCM(0).Picture
End Sub

Private Sub CM_FSTART_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If FSTART_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_FSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(1).Picture
End Sub

Private Sub CM_FSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(0).Picture
End Sub

Private Sub CM_LCANCEL_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If LCANCEL_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LCANCEL_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CM_LCANCEL_KeyUp(KeyCode As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KeyCode = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CM_LCANCEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LCONFIG_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If LCONFIG_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LCONFIG_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(1).Picture
End Sub

Private Sub CM_LCONFIG_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(0).Picture
End Sub

Private Sub CM_LSTART_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If LSTART_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(1).Picture
End Sub

Private Sub CM_LSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(0).Picture
End Sub

Private Sub CM_Slist_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.NeglectLostFocusCheck = False
   If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_SLIST(1).Picture
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_SLIST(0).Picture
End Sub

Private Sub CM_VSTART_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If VSTART_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_VSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(1).Picture
End Sub

Private Sub CM_VSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(0).Picture
End Sub

Private Sub FM_PANEL3D1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D14_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D15_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D2_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D4_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub Form_Activate() 'Generated.
Dim wk_ww As Integer
Dim wk_De As Integer
Dim wk_xx As Integer
   If PP_SSSMAIN.Activated = 0 Then
      PP_SSSMAIN.Activated = 1
   End If
End Sub

Private Sub Form_Load() 'Generated.
Dim wk_De As Integer
Dim wk_ww As Integer
Dim wk_Tx As Integer
Dim wk_TxBase As Integer
Dim wk_HeadN As Integer
Dim wk_BodyN As Integer
Dim wk_EBodyN As Integer
Dim wk_TailN As Integer
Dim wk_Top As Single
Dim wk_Height As Single
Dim wk_Px As Integer
Dim wk_PxBase As Integer
Dim wk_SmrBuf$
Dim PY_TTop As Single
   AE_Title$ = "銀行一覧マスタリスト                    "
'初画面表示の性能チューニング用 ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 8625
   .FormHeight = 5535
   .MaxDe = -1
   .MaxDsp = -1
   .HeadN = 6
   .BodyN = 0
   .BodyV = 0
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 0
   .BodyPx = 6
   .EBodyPx = 6
   .TailPx = 6
   .PrpC = 6
   .Operable = False
   .BrightOnOff = Cn_ClBrightON
   .SuppressVSScroll = 0
   .UniScrl = False
   .SetCursorRR = True
   .SetCursorLF = False
   .VisibleForItem = False
   .AllowNullDes = False
   .No2Scroll = False
   .SpecSubID = "sss"
   .UnDoDeOp = 0
   .ActiveBlockNo = -1
   .MaxBlockNo = 1
   If .MainForm = "" Then
      .ScX = AE_ScX
      AE_ScX = AE_ScX + 1
      ReDim Preserve AE_Timer(.ScX)
      ReDim Preserve AE_CursorRest(.ScX)
      ReDim Preserve AE_ModeBar(.ScX)
      ReDim Preserve AE_StatusBar(.ScX)
      ReDim Preserve AE_StatusCodeBar(.ScX)
      .CtB = AE_CtB
      AE_CtB = AE_CtB + 6
      ReDim Preserve AE_Controls(.CtB + 5)
      .MainFormFile = "BNKPR51.FRM"
      .MainFormObj = "FR_SSSMAIN"
      .SelValid = False
      .ArrowLimit = False
      .NullZero = True
      .ErrorByBackColor = False
      AE_SSSWin = True
      .AL = False
   End If
   If AE_FormInit$(PP_SSSMAIN, Me, AE_Title$, Cn_ClIncomplete, Cn_ClCheckError, Cn_ClRelCheck, Cn_ClChecked) <> "V6.60" Then
#If ActiveXcompile = 0 Then
      AE_MsgBox "再生成が必要です。", vbCritical, "ｅｅｅ": End
#Else
      AE_MsgBox "再生成が必要です。", vbCritical, "ｅｅｅ"
#End If
   End If
   If .MainForm = "" Then
      .MainForm = "SSSMAIN"
      Call AE_PSIR_SSSMAIN
      wk_ww = 0
      wk_De = 1
      wk_HeadN = 0: wk_BodyN = 0: wk_EBodyN = 0: wk_TailN = 0
      Do While wk_ww < AE_PSIC
         wk_SmrBuf$ = Trim$(AE_PSI$(wk_ww)) & Space$(1)
         wk_ww = wk_ww + 1
         Select Case UCase$(Left$(wk_SmrBuf$, Cn_PrfxLen))
            Case "HD_", "HV_"
               Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf$, CQ_SSSMAIN(wk_HeadN))
               wk_HeadN = wk_HeadN + 1
         End Select
      Loop
   End If
   HD_OPEID = ""
   HD_OPENM = ""
   HD_STTBNKCD = ""
   HD_STTBNKNM = ""
   HD_ENDBNKCD = ""
   HD_ENDBNKNM = ""
   HD_OPEID.TabIndex = 0
   Set AE_Controls(.CtB + 0) = HD_OPEID
   HD_OPENM.TabIndex = 1
   Set AE_Controls(.CtB + 1) = HD_OPENM
   HD_STTBNKCD.TabIndex = 2
   Set AE_Controls(.CtB + 2) = HD_STTBNKCD
   HD_STTBNKNM.TabIndex = 3
   Set AE_Controls(.CtB + 3) = HD_STTBNKNM
   HD_ENDBNKCD.TabIndex = 4
   Set AE_Controls(.CtB + 4) = HD_ENDBNKCD
   HD_ENDBNKNM.TabIndex = 5
   Set AE_Controls(.CtB + 5) = HD_ENDBNKNM
   TX_CursorRest.TabIndex = 6
   Set AE_Timer(.ScX) = TM_StartUp
   Set AE_CursorRest(.ScX) = TX_CursorRest
   Set AE_ModeBar(.ScX) = TX_Mode
   Set AE_StatusBar(.ScX) = TX_Message
   Set AE_StatusCodeBar(.ScX) = TX_Message
   .Mode = Cn_Mode1: TX_Mode = "追加"
   Call AE_ClearInitValStatus_SSSMAIN
   .PY_BTop = FR_SSSMAIN.Height
   .PY_EBTop = FR_SSSMAIN.Height
   PY_TTop = FR_SSSMAIN.Height
   .MaxDspC = 0
   .NrBodyTx = 6
   .ScrlMaxL = 1
   .MaxEDspC = 0
   .NrEBodyTx = 6
   .EScrlMaxL = 1
   Call AE_TabStop_SSSMAIN(0, 5, True)
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hWnd)
   Call AE_WindowProcSet_SSSMAIN
   ReleaseTabCapture 0
   SetTabCapture FR_SSSMAIN.hWnd
   wk_Var = SSSMAIN_BeginPrg()
   .FormWidth = FR_SSSMAIN.Width
   .FormHeight = FR_SSSMAIN.Height
'初画面表示の性能チューニング用 ----------
'   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
'-----------------------------------------
   .TimerStartUp = True
   End With
   TM_StartUp = True
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer) 'Generated.
   PP_SSSMAIN.UnloadMode = UnloadMode
   Select Case UnloadMode
      Case 0, 3
         PP_SSSMAIN.CloseCode = 2
         Cancel = True
         Call AE_EndCm_SSSMAIN
      Case 2
         PP_SSSMAIN.Caption = FR_SSSMAIN.Caption
         If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then Cancel = True
   End Select
End Sub

Private Sub Form_Resize() 'Generated.
Static FirstTime
   If IsEmpty(FirstTime) Then
       FirstTime = False
   ElseIf Not PP_SSSMAIN.Operable Then
   Else
      If FR_SSSMAIN.WindowState = 0 Then
         If FR_SSSMAIN.Height > PP_SSSMAIN.FormHeight Then FR_SSSMAIN.Height = PP_SSSMAIN.FormHeight
         If FR_SSSMAIN.Width > PP_SSSMAIN.FormWidth Then FR_SSSMAIN.Width = PP_SSSMAIN.FormWidth
      End If
   End If
'   Call AE_Resize(PP_SSSMAIN)
End Sub

Private Sub Form_Unload(Cancel As Integer) 'Generated.
Dim ReturnCode As Integer
   PP_SSSMAIN.CloseCode = 11
   If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
      If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then Cancel = True: Exit Sub
   Else
      If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then Cancel = True: Exit Sub
   End If
   wk_Var = SSSMAIN_Close()
   If wk_Var <> 0 Then
   End If
   If wk_Var = -1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hWnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hWnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
#If ActiveXcompile = 0 Then
      End
#End If
   ElseIf wk_Var = 0 Then
      Cancel = True
   ElseIf wk_Var = 1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hWnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hWnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
   End If
   PP_SSSMAIN.CloseCode = -1
End Sub

Private Sub HD_ENDBNKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_ENDBNKCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_ENDBNKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_ENDBNKCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 4
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 4
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_ENDBNKCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_ENDBNKCD)
   HD_ENDBNKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = ENDBNKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(4).TpStr = wk_Slisted
         CP_SSSMAIN(4).CIn = Cn_ChrInput
         HD_ENDBNKCD = wk_Slisted
         Call AE_Check_SSSMAIN_ENDBNKCD(AE_Val3(CP_SSSMAIN(4), (HD_ENDBNKCD)), Cn_Status6, True, True)
      End If
   End If
   CM_Slist.Enabled = True
End Sub

Private Sub HD_ENDBNKCD_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_ENDBNKCD, KeyCode, Shift, CP_SSSMAIN(4).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDBNKCD(AE_Val3(CP_SSSMAIN(4), (HD_ENDBNKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
   End If
End Sub

Private Sub HD_ENDBNKCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_ENDBNKCD, KeyAscii)
End Sub

Private Sub HD_ENDBNKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDBNKCD(AE_Val3(CP_SSSMAIN(4), (HD_ENDBNKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_ENDBNKCD.SetFocus
      End If
   End If
   If HD_ENDBNKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_ENDBNKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDBNKCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_ENDBNKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_ENDBNKCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 4
   End If
End Sub

Private Sub HD_ENDBNKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_ENDBNKCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_ENDBNKCD)
End Sub

Private Sub HD_ENDBNKNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDBNKNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_ENDBNKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_ENDBNKNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 5
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 5
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDBNKNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDBNKNM)
   HD_ENDBNKNM.BackColor = Cn_ClBrightON
   CM_Slist.Enabled = False
End Sub

Private Sub HD_ENDBNKNM_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_ENDBNKNM, KeyCode, Shift, CP_SSSMAIN(5).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDBNKNM(AE_Val3(CP_SSSMAIN(5), (HD_ENDBNKNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
   End If
End Sub

Private Sub HD_ENDBNKNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDBNKNM, KeyAscii)
End Sub

Private Sub HD_ENDBNKNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDBNKNM(AE_Val3(CP_SSSMAIN(5), (HD_ENDBNKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_ENDBNKNM.SetFocus
      End If
   End If
   If HD_ENDBNKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_ENDBNKNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDBNKNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_ENDBNKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_ENDBNKNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 5
   End If
End Sub

Private Sub HD_ENDBNKNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_ENDBNKNM.Locked = False
End Sub

Private Sub HD_OPEID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OPEID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OPEID_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 0
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 0
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
   HD_OPEID.BackColor = Cn_ClBrightON
   CM_Slist.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KeyCode, Shift, CP_SSSMAIN(0).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
   End If
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 0 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPEID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), (HD_OPEID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPEID.SetFocus
      End If
   End If
   If HD_OPEID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OPEID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OPEID.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 0
   End If
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPEID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
End Sub

Private Sub HD_OPENM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OPENM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OPENM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 1
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
   HD_OPENM.BackColor = Cn_ClBrightON
   CM_Slist.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KeyCode, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
   End If
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 1 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, KeyAscii)
End Sub

Private Sub HD_OPENM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), (HD_OPENM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPENM.SetFocus
      End If
   End If
   If HD_OPENM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OPENM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OPENM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
End Sub

Private Sub HD_STTBNKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_STTBNKCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_STTBNKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_STTBNKCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 2
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 2
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_STTBNKCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_STTBNKCD)
   HD_STTBNKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = STTBNKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(2).TpStr = wk_Slisted
         CP_SSSMAIN(2).CIn = Cn_ChrInput
         HD_STTBNKCD = wk_Slisted
         Call AE_Check_SSSMAIN_STTBNKCD(AE_Val3(CP_SSSMAIN(2), (HD_STTBNKCD)), Cn_Status6, True, True)
      End If
   End If
   CM_Slist.Enabled = True
End Sub

Private Sub HD_STTBNKCD_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_STTBNKCD, KeyCode, Shift, CP_SSSMAIN(2).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTBNKCD(AE_Val3(CP_SSSMAIN(2), (HD_STTBNKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
   End If
End Sub

Private Sub HD_STTBNKCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_STTBNKCD, KeyAscii)
End Sub

Private Sub HD_STTBNKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTBNKCD(AE_Val3(CP_SSSMAIN(2), (HD_STTBNKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_STTBNKCD.SetFocus
      End If
   End If
   If HD_STTBNKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_STTBNKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTBNKCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_STTBNKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_STTBNKCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 2
   End If
End Sub

Private Sub HD_STTBNKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_STTBNKCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_STTBNKCD)
End Sub

Private Sub HD_STTBNKNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTBNKNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1 
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_STTBNKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_STTBNKNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 3
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 3
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTBNKNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTBNKNM)
   HD_STTBNKNM.BackColor = Cn_ClBrightON
   CM_Slist.Enabled = False
End Sub

Private Sub HD_STTBNKNM_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_STTBNKNM, KeyCode, Shift, CP_SSSMAIN(3).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTBNKNM(AE_Val3(CP_SSSMAIN(3), (HD_STTBNKNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
   End If
End Sub

Private Sub HD_STTBNKNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTBNKNM, KeyAscii)
End Sub

Private Sub HD_STTBNKNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTBNKNM(AE_Val3(CP_SSSMAIN(3), (HD_STTBNKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_STTBNKNM.SetFocus
      End If
   End If
   If HD_STTBNKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_STTBNKNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button and vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTBNKNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_STTBNKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_STTBNKNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 3
   End If
End Sub

Private Sub HD_STTBNKNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_STTBNKNM.Locked = False
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub

Private Sub MN_AppendC_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
   If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_ClearItm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   Call AE_ClearItm_SSSMAIN(False)
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub MN_Copy_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      Clipboard.Clear
      If Screen.ActiveControl.SelLength <= 1 Then
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.Text
         On Error GoTo 0
      Else
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.SelText
         On Error GoTo 0
      End If
   End If
End Sub

Private Sub MN_Ctrl_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
End Sub

Private Sub MN_Cut_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.Text
         Call AE_ClearItm_SSSMAIN(False)
         On Error GoTo 0
         Call AE_CursorCurrent_SSSMAIN
      End If
   End If
End Sub

Private Sub MN_EditMn_Click() 'Generated.
Const CF_TEXT As Integer = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_AppendC = True
   MN_ClearItm = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 6 Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
   End If
   MN_Copy = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 6 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
      End If
   End If
   MN_Cut = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 6 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
               If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
                  If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Cut = True
               End If
            End If
         End If
      End If
   End If
   MN_Paste = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 6 Then
      If TypeOf Screen.ActiveControl Is TextBox Then
         If Clipboard.GetFormat(CF_TEXT) Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
         End If
      End If
   End If
   MN_UnDoItem = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 6 Then
      If  AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
         If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
            MN_UnDoItem = True
         ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then
            If IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
               MN_UnDoItem = True
            ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then
               MN_UnDoItem = True
            End If
         End If
      End If
   End If
End Sub

Private Sub MN_EndCm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.CloseCode = 1
   Call AE_EndCm_SSSMAIN
End Sub

Private Sub MN_FSTART_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If FSTART_GetEvent() Then
   End If
End Sub

Private Sub MN_LCONFIG_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If LCONFIG_GetEvent() Then
   End If
End Sub

Private Sub MN_LSTART_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If LSTART_GetEvent() Then
   End If
End Sub

Private Sub MN_Oprt_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_Slist = False
   If False Then
   ElseIf PP_SSSMAIN.Tx = 2 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 4 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   End If
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
   Else
   End If
End Sub

Private Sub MN_Paste_Click() 'Generated.
Dim MaxLB As Integer
Dim wk_LnSt As Integer
Dim Tx As Integer
Dim Px As Integer
Dim wk_Txt$
Dim st_Work$
Dim wk_Moji$
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
      If Screen.ActiveControl.TabIndex >= 6 Then
            Screen.ActiveControl.SelText = Clipboard.GetText()
         Else
            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), Screen.ActiveControl)
         End If
      End If
   End If
End Sub

Private Sub MN_Slist_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.SlistSw = True
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.SlistSw = False
End Sub

Private Sub MN_UnDoItem_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   Call AE_UnDoItem_SSSMAIN
End Sub

Private Sub MN_VSTART_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If VSTART_GetEvent() Then
   End If
End Sub

Private Sub SM_AllCopy_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.ShortCutTx = -2 Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText TX_Mode.Text
      On Error GoTo 0
   ElseIf PP_SSSMAIN.ShortCutTx = -3 Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText TX_Message.Text
      On Error GoTo 0
   ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is TextBox Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text
      On Error GoTo 0
   End If
End Sub

Private Sub SM_FullPast_Click() 'Generated.
   If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
      PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
      Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
      PP_SSSMAIN.Tx = -1
   End If
End Sub

Private Sub TM_StartUp_Timer() 'Generated.
Dim wk_ww As Integer
Dim De As Integer
Dim Tx As Integer
Dim wk_Cursor As Integer
   TM_StartUp.Enabled = False
   If PP_SSSMAIN.TimerStartUp = True Then
      PP_SSSMAIN.TimerStartUp = False
      PP_SSSMAIN.MaskMode = False
      PP_SSSMAIN.Operable = True
      If AE_AppendC_SSSMAIN(Cn_Mode1) = Cn_CuCurrent Then
         PP_SSSMAIN.CloseCode = 0
         Call AE_EndCm_SSSMAIN
      Else
         Call AE_CursorInit_SSSMAIN
      End If
   End If
   If PP_SSSMAIN.TimerWorkId = 1 Then
      PP_SSSMAIN.TimerWorkId = 0
      Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
   ElseIf PP_SSSMAIN.TimerWorkId = 8 Then
      PP_SSSMAIN.TimerWorkId = 0
      On Error Resume Next
      AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorSave).SetFocus
   ElseIf PP_SSSMAIN.TimerWorkId = 9 Then
      PP_SSSMAIN.TimerWorkId = 0
      Call AE_CursorSub_SSSMAIN(AE_NextCm_SSSMAIN(True))
   End If
End Sub

Private Sub TX_CursorRest_GotFocus() 'Generated.
   CM_Slist.Enabled = False
   If PP_SSSMAIN.PrpC = 0 Then
      PP_SSSMAIN.De2 = -1
      TX_CursorRest.TabStop = False
   ElseIf PP_SSSMAIN.SSCommand5Ajst Then
      TX_CursorRest.TabStop = False
      PP_SSSMAIN.BrightOnOff = AE_BackColor(CL_SSSMAIN(PP_SSSMAIN.Px) Mod 10)
      PP_SSSMAIN.SSCommand5Ajst = False
   ElseIf PP_SSSMAIN.NextTx = Cn_NextTxCleared Then
      PP_SSSMAIN.De2 = -1
      PP_SSSMAIN.Tx = -1
      If PP_SSSMAIN.CursorToWhere >= 0 Then
            If PP_SSSMAIN.CursorToWhere = Cn_CursorToHome Then
               PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
               If AE_CursorNext_SSSMAIN(-1) Then TX_CursorRest.TabStop = False
            Else
               If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OutputOnly Then
               ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonC Then
               Else
                  If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).TabStop Then
                     PP_SSSMAIN.NextTx = PP_SSSMAIN.CursorToWhere
                     On Error Resume Next
                     AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).SetFocus
                     TX_CursorRest.TabStop = False
                  End If
               End If
            End If
         PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
      Else
         PP_SSSMAIN.ExMode = PP_SSSMAIN.Mode
      End If
   Else
      PP_SSSMAIN.De2 = -1
      If PP_SSSMAIN.Tx >= 0 Then
         If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OutputOnly Then
         ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonC Then
         Else
            If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Then
               On Error Resume Next
               AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SetFocus
               TX_CursorRest.TabStop = False
               Exit Sub
            End If
         End If
      End If
      TX_CursorRest.TabStop = True
      PP_SSSMAIN.Tx = -1
      PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
   End If
End Sub

Private Sub TX_CursorRest_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
Dim wk_TopDe As Integer
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   If KeyCode = vbKeyUp And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
         wk_Bool = AE_CursorUp_SSSMAIN(6)
      End If
   ElseIf KeyCode = vbKeyDown And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
         wk_Bool = AE_CursorDown_SSSMAIN(-1)
      End If
   ElseIf KeyCode = vbKeyRight And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
         wk_Bool = AE_CursorNext_SSSMAIN(-1)
      End If
   ElseIf KeyCode = vbKeyLeft And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(6)
      End If
   ElseIf (KeyCode = vbKeyExecute Or KeyCode = vbKeyReturn) And Shift = 0 Then
   ElseIf KeyCode = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorPrevDsp_SSSMAIN(6) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KeyCode = vbKeyHome And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KeyCode = vbKeyPageDown And Shift = 0 Then
   ElseIf KeyCode = vbKeyPageUp And Shift = 0 Then
   ElseIf KeyCode = vbKeyShift Then
   ElseIf KeyCode = vbKeyControl Then
   ElseIf KeyCode = vbKeyMenu Then
   ElseIf KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
      wk_Int = AE_FuncKey_SSSMAIN(KeyCode, Shift)
      If KeyCode = vbKeyF10 And Shift = 0 Then Exit Sub
      If KeyCode = vbKeyF4 And (Shift And 6) = 4 Then Exit Sub
   Else
      If Shift <> 4 Then Beep
   End If
   KeyCode = 0
End Sub

Private Sub TX_CursorRest_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Mode = Cn_Mode3 Then
      KeyAscii = 0
   Else
      KeyAscii = 0
      Call AE_CursorInit_SSSMAIN
   End If
End Sub

Private Sub TX_Message_Click() 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub TX_Message_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyCode = 0
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button and vbRightButton) = vbRightButton Then
      TX_Message.Enabled = False
      PP_SSSMAIN.ShortCutTx = -3
      SM_FullPast.Enabled = False
      PopupMenu SM_ShortCut, vbPopupMenuRightButton
      TX_Message.Enabled = True
   End If
End Sub

Private Sub TX_Mode_GotFocus() 'Generated.
   Beep
   Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
End Sub

Private Sub TX_Mode_KeyDown(KeyCode As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyCode = 0
End Sub

Private Sub TX_Mode_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Mode_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button and vbRightButton) = vbRightButton Then
      TX_Mode.Enabled = False
      PP_SSSMAIN.ShortCutTx = -2
      SM_FullPast.Enabled = False
      PopupMenu SM_ShortCut, vbPopupMenuRightButton
      TX_Mode.Enabled = True
   End If
End Sub


