VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "取引先マスタ一括抽出"
   ClientHeight    =   6525
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
   Icon            =   "THSFP61.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   6525
   ScaleWidth      =   8625
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   -45
      TabIndex        =   10
      Top             =   5880
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
            Text            =   "THSFP61.frx":000C
            Top             =   120
            Width           =   5235
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "THSFP61.frx":0043
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Left            =   5940
      MaxLength       =   24
      TabIndex        =   16
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   720
      Width           =   2265
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   5250
      MaxLength       =   10
      TabIndex        =   15
      Text            =   "XXXXX6"
      Top             =   720
      Width           =   705
   End
   Begin VB.Frame Frame3D1 
      Caption         =   "条件指定"
      ForeColor       =   &H00000000&
      Height          =   2985
      Left            =   360
      TabIndex        =   5
      Top             =   1560
      Width           =   7845
      Begin VB.TextBox HD_FRNKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   270
         IMEMode         =   2  'ｵﾌ
         Left            =   1920
         MaxLength       =   5
         TabIndex        =   24
         Text            =   "9"
         Top             =   1200
         Width           =   255
      End
      Begin VB.TextBox HD_THSCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   1920
         MaxLength       =   5
         TabIndex        =   21
         Text            =   "9"
         Top             =   518
         Width           =   255
      End
      Begin VB.TextBox HD_ENDTOKNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   2880
         MaxLength       =   44
         TabIndex        =   19
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   2400
         Width           =   4335
      End
      Begin VB.TextBox HD_STTTOKNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   2880
         MaxLength       =   44
         TabIndex        =   18
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   1920
         Width           =   4335
      End
      Begin VB.TextBox HD_ENDTOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFFFFF&
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   1920
         MaxLength       =   9
         TabIndex        =   7
         Text            =   "XXXXXXX8"
         Top             =   2400
         Width           =   1020
      End
      Begin VB.TextBox HD_STTTOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFFFFF&
         Height          =   285
         IMEMode         =   2  'ｵﾌ
         Left            =   1920
         MaxLength       =   9
         TabIndex        =   6
         Text            =   "XXXXXXX8"
         Top             =   1920
         Width           =   1020
      End
      Begin VB.Label Label7 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "0:国内 1:海外 9:全て"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   2280
         TabIndex        =   25
         Top             =   1238
         Width           =   2100
      End
      Begin VB.Label Label6 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "海外取引区分"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   600
         TabIndex        =   23
         Top             =   1238
         Width           =   1260
      End
      Begin VB.Label Label5 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "1:得意先 2:仕入先 3:共通 0:代表会社 9:全て"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   2280
         TabIndex        =   22
         Top             =   563
         Width           =   4410
      End
      Begin VB.Label Label4 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "取引先分類"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   810
         TabIndex        =   20
         Top             =   563
         Width           =   1050
      End
      Begin VB.Label Label2 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "取引先ｺｰﾄﾞ"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   735
         TabIndex        =   9
         Top             =   1980
         Width           =   1050
      End
      Begin VB.Label Label1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Caption         =   "～"
         ForeColor       =   &H80000008&
         Height          =   195
         Left            =   1575
         TabIndex        =   8
         Top             =   2400
         Width           =   210
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1410
      Left            =   270
      TabIndex        =   3
      Top             =   7320
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
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5190
         Picture         =   "THSFP61.frx":01CD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   4800
         Picture         =   "THSFP61.frx":0357
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1845
         Picture         =   "THSFP61.frx":09C9
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   990
         Picture         =   "THSFP61.frx":0B53
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "THSFP61.frx":0CDD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "THSFP61.frx":0E67
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1395
         Picture         =   "THSFP61.frx":0FF1
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2160
         Picture         =   "THSFP61.frx":117B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2520
         Picture         =   "THSFP61.frx":1305
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2880
         Picture         =   "THSFP61.frx":148F
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3240
         Picture         =   "THSFP61.frx":1619
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3600
         Picture         =   "THSFP61.frx":17A3
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3960
         Picture         =   "THSFP61.frx":192D
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4320
         Picture         =   "THSFP61.frx":1AB7
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2025
         Picture         =   "THSFP61.frx":1C41
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   2430
         Picture         =   "THSFP61.frx":1DCB
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
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   950
         Picture         =   "THSFP61.frx":1F55
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   580
         Picture         =   "THSFP61.frx":20DF
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   225
         Picture         =   "THSFP61.frx":2269
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
   Begin Threed5.SSPanel5 GAUGE 
      Height          =   420
      Left            =   1410
      TabIndex        =   13
      Top             =   4710
      Width           =   5685
      _ExtentX        =   10028
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
      Top             =   5340
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
      TabIndex        =   17
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
      Begin VB.Menu MN_EXECUTE 
         Caption         =   "実行(&R)..."
         Shortcut        =   ^R
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
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "補助(&3)"
      Begin VB.Menu MN_Slist 
         Caption         =   "ウインドウ表示(&L)"
         Shortcut        =   {F5}
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
' === 20110217 === INSERT S TOM)Morimoto
Private Const gv_strOUT_TYPE As String = ".TXT"
' === 20110217 === INSERT E


Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "メニューに戻ります。"
End Sub
' === 20110216 === INSERT S TOM)Morimoto ファイル書き込み実行を追加
Private Sub CM_Execute_Click()
    AE_Execute CP_SSSMAIN(HD_THSCD.TabIndex).CuVal, CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal)
End Sub

Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
   If PP_SSSMAIN.Operable Then CM_Execute.Picture = IM_Execute(1).Picture
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "実行します。"
End Sub

Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
   If PP_SSSMAIN.Operable Then CM_Execute.Picture = IM_Execute(0).Picture
End Sub
' === 20110216 === INSERT E

Private Sub CM_FSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ファイルに出力します。"
End Sub
' === 20110216 === DELETE S TOM)Morimoto
'Private Sub CM_LCONFIG_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
'    TX_Message.Text = "プリンターを選択します。"
'End Sub
'
'Private Sub CM_LSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
'    TX_Message.Text = "印刷を開始します。"
'End Sub
'
Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ウィンドウを表示します。"
End Sub
'
'Private Sub CM_VSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
'    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
'    TX_Message.Text = "印刷イメージを表示します。"
'End Sub
' === 20110216 === DELETE E

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
   If PP_SSSMAIN.Operable Then CM_EndCm.Picture = IM_EndCm(1).Picture
End Sub

Private Sub CM_ENDCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_EndCm.Picture = IM_EndCm(0).Picture
End Sub
' === 20110217 === DELETE S TOM)Morimoto
'Private Sub CM_FSTART_Click() 'Generated.
'   PP_SSSMAIN.ButtonClick = True
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   PP_SSSMAIN.NeglectLostFocusCheck = True
'   If FSTART_GetEvent() Then
'   End If
'   PP_SSSMAIN.NeglectLostFocusCheck = False
'   Call AE_CursorCurrent_SSSMAIN
'End Sub
'
'Private Sub CM_FSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(1).Picture
'End Sub
'
'Private Sub CM_FSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_FSTART.Picture = IM_FSTART(0).Picture
'End Sub
' === 20110217 === DELETE E

Private Sub CM_LCANCEL_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
' === 20110217 === DELETE S TOM)Morimoto
'   If LCANCEL_GetEvent() Then
'   End If
' === 20110217 === DELETE E
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LCANCEL_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CM_LCANCEL_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CM_LCANCEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub


' === 20110216 === DELETE S TOM)Morimoto
'Private Sub CM_LCONFIG_Click() 'Generated.
'   PP_SSSMAIN.ButtonClick = True
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   PP_SSSMAIN.NeglectLostFocusCheck = True
'   If LCONFIG_GetEvent() Then
'   End If
'   PP_SSSMAIN.NeglectLostFocusCheck = False
'   Call AE_CursorCurrent_SSSMAIN
'End Sub
'
'Private Sub CM_LCONFIG_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(1).Picture
'End Sub
'
'Private Sub CM_LCONFIG_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(0).Picture
'End Sub
'
'Private Sub CM_LSTART_Click() 'Generated.
'   PP_SSSMAIN.ButtonClick = True
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   PP_SSSMAIN.NeglectLostFocusCheck = True
'   If LSTART_GetEvent() Then
'   End If
'   PP_SSSMAIN.NeglectLostFocusCheck = False
'   Call AE_CursorCurrent_SSSMAIN
'End Sub
'
'Private Sub CM_LSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(1).Picture
'End Sub
'
'Private Sub CM_LSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_LSTART.Picture = IM_LSTART(0).Picture
'End Sub

Private Sub CM_Slist_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.NeglectLostFocusCheck = False
   If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_Slist(1).Picture
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_Slist(0).Picture
End Sub

'Private Sub CM_VSTART_Click() 'Generated.
'   PP_SSSMAIN.ButtonClick = True
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   PP_SSSMAIN.NeglectLostFocusCheck = True
'   If VSTART_GetEvent() Then
'   End If
'   PP_SSSMAIN.NeglectLostFocusCheck = False
'   Call AE_CursorCurrent_SSSMAIN
'End Sub
'
'Private Sub CM_VSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(1).Picture
'End Sub
'
'Private Sub CM_VSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
'   If PP_SSSMAIN.Operable Then CM_VSTART.Picture = IM_VSTART(0).Picture
'End Sub
' === 20110216 === DELETE E

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

' === 20110216 === INSERT S TOM)Morimoto
    Dim Wk_Index As Integer
    show_GAGE False
' === 20110216 === INSERT E
' === 20110216 === UPDATE S TOM)Morimoto
'   AE_Title$ = "取引先一覧マスタリスト                   "
   AE_Title$ = "取引先マスタ一括抽出                     "
' === 20110216 === UPDATE E
'初画面表示の性能チューニング用 ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 8625
' === 20110216 === UPDATE S TOM)Morimoto
'   .FormHeight = 6015
   .FormHeight = 7305
' === 20110216 === UPDATE E
   .MaxDe = -1
   .MaxDsp = -1
' === 20110216 === UPDATE S TOM)Morimoto
'   .HeadN = 7
   .HeadN = 8
' === 20110216 === UPDATE E
   .BodyN = 0
   .BodyV = 0
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 0
' === 20110216 === UPDATE S TOM)Morimoto
'   .BodyPx = 7
'   .EBodyPx = 7
'   .TailPx = 7
'   .PrpC = 7
   .BodyPx = .HeadN
   .EBodyPx = .HeadN
   .TailPx = .HeadN
   .PrpC = .HeadN
' === 20110216 === UPDATE E
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
' === 20110216 === UPDATE S TOM)Morimoto
'      AE_CtB = AE_CtB + 7
'      ReDim Preserve AE_Controls(.CtB + 6)
'      .MainFormFile = "THSPR51.FRM"
      AE_CtB = AE_CtB + .HeadN
      ReDim Preserve AE_Controls(.CtB + .HeadN - 1)
      .MainFormFile = "THSFP61.FRM"
' === 20110216 === UPDATE E
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
   HD_THSCD = ""
' === 20110216 === INSERT S TOM)Morimoto
   HD_FRNKB = ""
' === 20110216 === INSERT E
   HD_STTTOKCD = ""
   HD_STTTOKNM = ""
   HD_ENDTOKCD = ""
   HD_ENDTOKNM = ""
' === 20110216 === UPDATE S TOM)Morimoto
'   HD_OPEID.TabIndex = 0
'   Set AE_Controls(.CtB + 0) = HD_OPEID
'   HD_OPENM.TabIndex = 1
'   Set AE_Controls(.CtB + 1) = HD_OPENM
'   HD_THSCD.TabIndex = 2
'   Set AE_Controls(.CtB + 2) = HD_THSCD
'   HD_STTTOKCD.TabIndex = 3
'   Set AE_Controls(.CtB + 3) = HD_STTTOKCD
'   HD_STTTOKNM.TabIndex = 4
'   Set AE_Controls(.CtB + 4) = HD_STTTOKNM
'   HD_ENDTOKCD.TabIndex = 5
'   Set AE_Controls(.CtB + 5) = HD_ENDTOKCD
'   HD_ENDTOKNM.TabIndex = 6
'   Set AE_Controls(.CtB + 6) = HD_ENDTOKNM
'   TX_CursorRest.TabIndex = 7
    Wk_Index = 0
   HD_OPEID.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_OPEID
    Wk_Index = Wk_Index + 1
   HD_OPENM.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_OPENM
    Wk_Index = Wk_Index + 1
   HD_THSCD.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_THSCD
    Wk_Index = Wk_Index + 1
   HD_FRNKB.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_FRNKB
    Wk_Index = Wk_Index + 1
   HD_STTTOKCD.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_STTTOKCD
    Wk_Index = Wk_Index + 1
   HD_STTTOKNM.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_STTTOKNM
    Wk_Index = Wk_Index + 1
   HD_ENDTOKCD.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_ENDTOKCD
    Wk_Index = Wk_Index + 1
   HD_ENDTOKNM.TabIndex = Wk_Index
   Set AE_Controls(.CtB + Wk_Index) = HD_ENDTOKNM
    Wk_Index = Wk_Index + 1
   TX_CursorRest.TabIndex = Wk_Index
' === 20110216 === UPDATE E
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
' === 20110216 === UPDATE S TOM)Morimoto
'   .NrBodyTx = 7
   .NrBodyTx = Wk_Index
' === 20110216 === UPDATE E
   .ScrlMaxL = 1
   .MaxEDspC = 0
' === 20110216 === UPDATE S TOM)Morimoto
'   .NrEBodyTx = 7
   .NrEBodyTx = Wk_Index
' === 20110216 === UPDATE E
   .EScrlMaxL = 1
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_TabStop_SSSMAIN(0, 6, True)
   Call AE_TabStop_SSSMAIN(0, Wk_Index - 1, True)
' === 20110216 === UPDATE E
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
   Call AE_WindowProcSet_SSSMAIN
   ReleaseTabCapture 0
   SetTabCapture FR_SSSMAIN.hwnd
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
' === 20110217 === DELETE S TOM)Morimoto
'    wk_Var = SSSMAIN_Close()
' === 20110217 === DELETE E
   If wk_Var <> 0 Then
   End If
   If wk_Var = -1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hwnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
#If ActiveXcompile = 0 Then
      End
#End If
   ElseIf wk_Var = 0 Then
      Cancel = True
   ElseIf wk_Var = 1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hwnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
   End If
   PP_SSSMAIN.CloseCode = -1
End Sub

Private Sub HD_ENDTOKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
' === 20110216 === UPDATE S TOM)Morimoto
'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD) Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD) Then
' === 20110216 === UPDATE E
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_ENDTOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_ENDTOKCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Tx = 5
   PP_SSSMAIN.Tx = HD_ENDTOKCD.TabIndex
' === 20110216 === UPDATE E
   PP_SSSMAIN.De2 = -1
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Px = 5
   PP_SSSMAIN.Px = HD_ENDTOKCD.TabIndex
' === 20110216 === UPDATE E
   If Not PP_SSSMAIN.Operable Then Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
' === 20110216 === UPDATE E
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
' === 20110216 === UPDATE E
   HD_ENDTOKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
      wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal))
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
' === 20110216 === UPDATE S TOM)Morimoto
'         CP_SSSMAIN(5).TpStr = wk_Slisted
'         CP_SSSMAIN(5).CIn = Cn_ChrInput
         CP_SSSMAIN(HD_ENDTOKCD.TabIndex).TpStr = wk_Slisted
         CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CIn = Cn_ChrInput
' === 20110216 === UPDATE E
         HD_ENDTOKCD = wk_Slisted
' === 20110216 === UPDATE S TOM)Morimoto
'         Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, True, True)
         Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), (HD_ENDTOKCD)), Cn_Status6, True, True)
' === 20110216 === UPDATE E
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_ENDTOKCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If AE_KeyDown_SSSMAIN(HD_ENDTOKCD, KeyCode, Shift, CP_SSSMAIN(5).TpStr) Then
'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, True, True)
'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (5)
   If AE_KeyDown_SSSMAIN(HD_ENDTOKCD, KEYCODE, Shift, CP_SSSMAIN(HD_ENDTOKCD.TabIndex).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), (HD_ENDTOKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (HD_ENDTOKCD.TabIndex)
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_ENDTOKCD_KeyPress(KeyAscii As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD, KeyAscii)
   If PP_SSSMAIN.Tx <> HD_ENDTOKCD.TabIndex Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD, KeyAscii)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_ENDTOKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (HD_ENDTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
   If CP_SSSMAIN(HD_ENDTOKCD.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(HD_ENDTOKCD.TabIndex), (HD_ENDTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
' === 20110216 === UPDATE E
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_ENDTOKCD.SetFocus
      End If
   End If
' === 20110216 === UPDATE S TOM)Morimoto
'   If HD_ENDTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
   If HD_ENDTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), CL_SSSMAIN(HD_ENDTOKCD.TabIndex), PP_SSSMAIN.Tx)
' === 20110216 === UPDATE E
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_ENDTOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDTOKCD)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_ENDTOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_ENDTOKCD.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
' === 20110216 === UPDATE S TOM)Morimoto
'      PP_SSSMAIN.MouseDownTx = 5
      PP_SSSMAIN.MouseDownTx = HD_ENDTOKCD.TabIndex
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_ENDTOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_ENDTOKCD.Locked = False
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDTOKCD)
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKCD)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_ENDTOKNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
' === 20110216 === UPDATE S TOM)Morimoto
'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM) Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKCD.TabIndex), HD_ENDTOKNM) Then
' === 20110216 === UPDATE E
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_ENDTOKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_ENDTOKNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Tx = 6
   PP_SSSMAIN.Tx = HD_ENDTOKNM.TabIndex
' === 20110216 === UPDATE E
   PP_SSSMAIN.De2 = -1
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Px = 6
   PP_SSSMAIN.Px = HD_ENDTOKNM.TabIndex
' === 20110216 === UPDATE E
   If Not PP_SSSMAIN.Operable Then Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
' === 20110216 === UPDATE E
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
' === 20110216 === UPDATE E
   HD_ENDTOKNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_ENDTOKNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If AE_KeyDown_SSSMAIN(HD_ENDTOKNM, KeyCode, Shift, CP_SSSMAIN(6).TpStr) Then
'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(6), (HD_ENDTOKNM)), Cn_Status6, True, True)
'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (6)
   If AE_KeyDown_SSSMAIN(HD_ENDTOKNM, KEYCODE, Shift, CP_SSSMAIN(HD_ENDTOKNM.TabIndex).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(HD_ENDTOKNM.TabIndex), (HD_ENDTOKNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (HD_ENDTOKNM.TabIndex)
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_ENDTOKNM_KeyPress(KeyAscii As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If PP_SSSMAIN.Tx <> 6 Then Beep: KeyAscii = 0: Exit Sub
'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM, KeyAscii)
   If PP_SSSMAIN.Tx <> HD_ENDTOKNM.TabIndex Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM, KeyAscii)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_ENDTOKNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(6), (HD_ENDTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
   If CP_SSSMAIN(HD_ENDTOKNM.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val3(CP_SSSMAIN(HD_ENDTOKNM.TabIndex), (HD_ENDTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
' === 20110216 === UPDATE E
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_ENDTOKNM.SetFocus
      End If
   End If
' === 20110216 === UPDATE S TOM)Morimoto
'   If HD_ENDTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
   If HD_ENDTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), CL_SSSMAIN(HD_ENDTOKNM.TabIndex), PP_SSSMAIN.Tx)
' === 20110216 === UPDATE E
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_ENDTOKNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDTOKNM)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_ENDTOKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_ENDTOKNM.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
' === 20110216 === UPDATE S TOM)Morimoto
'      PP_SSSMAIN.MouseDownTx = 6
      PP_SSSMAIN.MouseDownTx = HD_ENDTOKNM.TabIndex
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_ENDTOKNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_ENDTOKNM.Locked = False
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_ENDTOKNM)
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_ENDTOKNM.TabIndex), HD_ENDTOKNM)
' === 20110216 === UPDATE E
End Sub
' === 20110216 === INSERT S TOM)Morimoto
Private Sub HD_FRNKB_Change()
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FRNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_FRNKB_GotFocus()
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = HD_FRNKB.TabIndex
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = HD_FRNKB.TabIndex
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
   HD_FRNKB.BackColor = Cn_ClBrightON
End Sub

Private Sub HD_FRNKB_KeyDown(KEYCODE As Integer, Shift As Integer)
   If AE_KeyDown_SSSMAIN(HD_FRNKB, KEYCODE, Shift, CP_SSSMAIN(HD_FRNKB.TabIndex).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (HD_FRNKB.TabIndex)
   End If
End Sub

Private Sub HD_FRNKB_KeyPress(KeyAscii As Integer)
   If PP_SSSMAIN.Tx <> HD_FRNKB.TabIndex Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB, KeyAscii)
End Sub

Private Sub HD_FRNKB_LostFocus()
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(HD_FRNKB.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(HD_FRNKB.TabIndex), (HD_FRNKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_FRNKB.SetFocus
      End If
   End If
   If HD_FRNKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), CL_SSSMAIN(HD_FRNKB.TabIndex), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_FRNKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
   If PP_SSSMAIN.Operable Then
      PP_SSSMAIN.MouseDownTx = HD_FRNKB.TabIndex
   End If
End Sub

Private Sub HD_FRNKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
   HD_FRNKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_FRNKB.TabIndex), HD_FRNKB)
End Sub
' === 20110216 === INSERT E

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
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (0)
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
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_OPEID.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
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
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (1)
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
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_OPENM.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
End Sub

Private Sub HD_STTTOKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
' === 20110216 === UPDATE S TOM)Morimoto
'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD) Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD) Then
' === 20110216 === UPDATE E
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_STTTOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_STTTOKCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Tx = 3
   PP_SSSMAIN.Tx = HD_STTTOKCD.TabIndex
' === 20110216 === UPDATE E
   PP_SSSMAIN.De2 = -1
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Px = 3
   PP_SSSMAIN.Px = HD_STTTOKCD.TabIndex
' === 20110216 === UPDATE E
   If Not PP_SSSMAIN.Operable Then Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
' === 20110216 === UPDATE E
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
' === 20110216 === UPDATE E
   HD_STTTOKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
' === 20110216 === UPDATE S TOM)Morimoto
'      wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal))
      wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal))
' === 20110216 === UPDATE E
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
' === 20110216 === UPDATE S TOM)Morimoto
'         CP_SSSMAIN(3).TpStr = wk_Slisted
'         CP_SSSMAIN(3).CIn = Cn_ChrInput
         CP_SSSMAIN(HD_STTTOKCD.TabIndex).TpStr = wk_Slisted
         CP_SSSMAIN(HD_STTTOKCD.TabIndex).CIn = Cn_ChrInput
' === 20110216 === UPDATE E
         HD_STTTOKCD = wk_Slisted
' === 20110216 === UPDATE S TOM)Morimoto
'         Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, True, True)
         Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), (HD_STTTOKCD)), Cn_Status6, True, True)
' === 20110216 === UPDATE E
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_STTTOKCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If AE_KeyDown_SSSMAIN(HD_STTTOKCD, KeyCode, Shift, CP_SSSMAIN(3).TpStr) Then
'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, True, True)
'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (3)
   If AE_KeyDown_SSSMAIN(HD_STTTOKCD, KEYCODE, Shift, CP_SSSMAIN(HD_STTTOKCD.TabIndex).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), (HD_STTTOKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (HD_STTTOKCD.TabIndex)
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_STTTOKCD_KeyPress(KeyAscii As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD, KeyAscii)
   If PP_SSSMAIN.Tx <> HD_STTTOKCD.TabIndex Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD, KeyAscii)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_STTTOKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (HD_STTTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
   If CP_SSSMAIN(HD_STTTOKCD.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(HD_STTTOKCD.TabIndex), (HD_STTTOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
' === 20110216 === UPDATE E
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_STTTOKCD.SetFocus
      End If
   End If
' === 20110216 === UPDATE S TOM)Morimoto
'   If HD_STTTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
   If HD_STTTOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), CL_SSSMAIN(HD_STTTOKCD.TabIndex), PP_SSSMAIN.Tx)
' === 20110216 === UPDATE E
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_STTTOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKCD)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_STTTOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_STTTOKCD.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
' === 20110216 === UPDATE S TOM)Morimoto
'      PP_SSSMAIN.MouseDownTx = 3
      PP_SSSMAIN.MouseDownTx = HD_STTTOKCD.TabIndex
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_STTTOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_STTTOKCD.Locked = False
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(3), HD_STTTOKCD)
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKCD.TabIndex), HD_STTTOKCD)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_STTTOKNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
' === 20110216 === UPDATE S TOM)Morimoto
'      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM) Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM) Then
' === 20110216 === UPDATE E
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_STTTOKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_STTTOKNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Tx = 4
   PP_SSSMAIN.Tx = HD_STTTOKNM.TabIndex
' === 20110216 === UPDATE E
   PP_SSSMAIN.De2 = -1
' === 20110216 === UPDATE S TOM)Morimoto
'   PP_SSSMAIN.Px = 4
   PP_SSSMAIN.Px = HD_STTTOKNM.TabIndex
' === 20110216 === UPDATE E
   If Not PP_SSSMAIN.Operable Then Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
' === 20110216 === UPDATE E
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
' === 20110216 === UPDATE E
   HD_STTTOKNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_STTTOKNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If AE_KeyDown_SSSMAIN(HD_STTTOKNM, KeyCode, Shift, CP_SSSMAIN(4).TpStr) Then
'      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(4), (HD_STTTOKNM)), Cn_Status6, True, True)
'      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (4)
   If AE_KeyDown_SSSMAIN(HD_STTTOKNM, KEYCODE, Shift, CP_SSSMAIN(HD_STTTOKNM.TabIndex).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(HD_STTTOKNM.TabIndex), (HD_STTTOKNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (HD_STTTOKNM.TabIndex)
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_STTTOKNM_KeyPress(KeyAscii As Integer) 'Generated.
' === 20110216 === UPDATE S TOM)Morimoto
'   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
'   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM, KeyAscii)
   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM, KeyAscii)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_STTTOKNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
' === 20110216 === UPDATE S TOM)Morimoto
'   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
'      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(4), (HD_STTTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
   If CP_SSSMAIN(HD_STTTOKNM.TabIndex).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val3(CP_SSSMAIN(HD_STTTOKNM.TabIndex), (HD_STTTOKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
' === 20110216 === UPDATE E
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_STTTOKNM.SetFocus
      End If
   End If
' === 20110216 === UPDATE S TOM)Morimoto
'   If HD_STTTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
   If HD_STTTOKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), CL_SSSMAIN(HD_STTTOKNM.TabIndex), PP_SSSMAIN.Tx)
' === 20110216 === UPDATE E
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_STTTOKNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKNM)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_STTTOKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_STTTOKNM.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
' === 20110216 === UPDATE S TOM)Morimoto
'      PP_SSSMAIN.MouseDownTx = 4
      PP_SSSMAIN.MouseDownTx = HD_STTTOKNM.TabIndex
' === 20110216 === UPDATE E
   End If
End Sub

Private Sub HD_STTTOKNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_STTTOKNM.Locked = False
' === 20110216 === UPDATE S TOM)Morimoto
'   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTTOKNM)
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(HD_STTTOKNM.TabIndex), HD_STTTOKNM)
' === 20110216 === UPDATE E
End Sub

Private Sub HD_THSCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_THSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_THSCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 2
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 2
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
   HD_THSCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_THSCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_THSCD, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(2), (HD_THSCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (2)
   End If
End Sub

Private Sub HD_THSCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD, KeyAscii)
End Sub

Private Sub HD_THSCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_THSCD(AE_Val3(CP_SSSMAIN(2), (HD_THSCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_THSCD.SetFocus
      End If
   End If
   If HD_THSCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_THSCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
' === 20110216 === DELETE S TOM)Morimoto
'      If (Button And vbRightButton) = vbRightButton Then
'         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_THSCD)
'         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
'         PP_SSSMAIN.NeglectPopupFocus = False
'         Dim wk_Tx As Integer
'         wk_Tx = PP_SSSMAIN.Tx
'         If PP_SSSMAIN.PopupTx = HD_THSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
'         DoEvents
'         HD_THSCD.Enabled = True
'         Call AE_CursorMove_SSSMAIN(wk_Tx)
'      End If
' === 20110216 === DELETE E
      PP_SSSMAIN.MouseDownTx = 2
   End If
End Sub

Private Sub HD_THSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_THSCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_THSCD)
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
   MN_APPENDC = True
' === 20110216 === DELETE S TOM)Morimoto
'   MN_ClearItm = False
'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
'   End If
'   MN_Copy = False
'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
'      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
'         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
'      End If
'   End If
'   MN_Cut = False
'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
'      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
'         If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
'            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
'               If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
'                  If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Cut = True
'               End If
'            End If
'         End If
'      End If
'   End If
'   MN_Paste = False
'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
'      If TypeOf Screen.ActiveControl Is TextBox Then
'         If Clipboard.GetFormat(CF_TEXT) Then
'            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
'         End If
'      End If
'   End If
'   MN_UnDoItem = False
'   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
'         If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
'            MN_UnDoItem = True
'         ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then
'            If IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
'               MN_UnDoItem = True
'            ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then
'               MN_UnDoItem = True
'            End If
'         End If
'      End If
'   End If
' === 20110216 === DELETE E
End Sub

Private Sub MN_EndCm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.CloseCode = 1
   Call AE_EndCm_SSSMAIN
End Sub

' === 20110216 === INSERT S TOM)Morimoto
Private Sub MN_EXECUTE_Click()
    AE_Execute CP_SSSMAIN(HD_THSCD.TabIndex).CuVal, CP_SSSMAIN(HD_FRNKB.TabIndex).CuVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_STTTOKCD.TabIndex).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(HD_ENDTOKCD.TabIndex).CuVal)
End Sub
' === 20110216 === INSERT E

' === 20110216 === DELETE S TOM)Morimoto
'Private Sub MN_FSTART_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If FSTART_GetEvent() Then
'   End If
'End Sub
'
'Private Sub MN_LCONFIG_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If LCONFIG_GetEvent() Then
'   End If
'End Sub
'
'Private Sub MN_LSTART_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If LSTART_GetEvent() Then
'   End If
'End Sub
'
Private Sub MN_Oprt_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_Slist = False
   If False Then
' === 20110216 === UPDATE S TOM)Morimoto
'   ElseIf PP_SSSMAIN.Tx = 3 Then
   ElseIf PP_SSSMAIN.Tx = HD_STTTOKCD.TabIndex Then
' === 20110216 === UPDATE E
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
' === 20110216 === UPDATE S TOM)Morimoto
'   ElseIf PP_SSSMAIN.Tx = 5 Then
   ElseIf PP_SSSMAIN.Tx = HD_ENDTOKCD.TabIndex Then
' === 20110216 === UPDATE E
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   End If
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
   Else
   End If
End Sub
'
'Private Sub MN_Paste_Click() 'Generated.
'Dim MaxLB As Integer
'Dim wk_LnSt As Integer
'Dim Tx As Integer
'Dim Px As Integer
'Dim wk_Txt$
'Dim st_Work$
'Dim wk_Moji$
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If TypeOf Screen.ActiveControl Is TextBox Then
'      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
'' === 20110216 === UPDATE S TOM)Morimoto
''      If Screen.ActiveControl.TabIndex >= 7 Then
'      If Screen.ActiveControl.TabIndex >= PP_SSSMAIN.HeadN Then
'' === 20110216 === UPDATE E
'            Screen.ActiveControl.SelText = Clipboard.GetText()
'         Else
'            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), Screen.ActiveControl)
'         End If
'      End If
'   End If
'End Sub
'
Private Sub MN_Slist_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.SlistSw = True
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.SlistSw = False
End Sub

'Private Sub MN_UnDoItem_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   Call AE_UnDoItem_SSSMAIN
'End Sub
'
'Private Sub MN_VSTART_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If VSTART_GetEvent() Then
'   End If
'End Sub
'
'Private Sub SM_AllCopy_Click() 'Generated.
'   If Not PP_SSSMAIN.Operable Then Exit Sub
'   If PP_SSSMAIN.ShortCutTx = -2 Then
'      Clipboard.Clear
'      On Error Resume Next
'      Clipboard.SetText TX_Mode.Text
'      On Error GoTo 0
'   ElseIf PP_SSSMAIN.ShortCutTx = -3 Then
'      Clipboard.Clear
'      On Error Resume Next
'      Clipboard.SetText TX_Message.Text
'      On Error GoTo 0
'   ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is TextBox Then
'      Clipboard.Clear
'      On Error Resume Next
'      Clipboard.SetText AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text
'      On Error GoTo 0
'   End If
'End Sub
'
'Private Sub SM_FullPast_Click() 'Generated.
'   If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
'      PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
'      Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
'      PP_SSSMAIN.Tx = -1
'   End If
'End Sub
' === 20110216 === DELETE E

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
   CM_SLIST.Enabled = False
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

Private Sub TX_CursorRest_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
Dim wk_TopDe As Integer
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   If KEYCODE = vbKeyUp And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
' === 20110216 === UPDATE S TOM)Morimoto
'         wk_Bool = AE_CursorUp_SSSMAIN(7)
         wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.HeadN)
' === 20110216 === UPDATE E
      End If
   ElseIf KEYCODE = vbKeyDown And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
         wk_Bool = AE_CursorDown_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyRight And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
         wk_Bool = AE_CursorNext_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyLeft And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
' === 20110216 === UPDATE S TOM)Morimoto
'         wk_Bool = AE_CursorPrev_SSSMAIN(7)
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN)
' === 20110216 === UPDATE E
      End If
   ElseIf (KEYCODE = vbKeyExecute Or KEYCODE = vbKeyReturn) And Shift = 0 Then
   ElseIf KEYCODE = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
' === 20110216 === UPDATE S TOM)Morimoto
'         If AE_CursorPrevDsp_SSSMAIN(7) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
         If AE_CursorPrevDsp_SSSMAIN(PP_SSSMAIN.HeadN) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
' === 20110216 === UPDATE E
      End If
   ElseIf KEYCODE = vbKeyHome And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KEYCODE = vbKeyPageDown And Shift = 0 Then
   ElseIf KEYCODE = vbKeyPageUp And Shift = 0 Then
   ElseIf KEYCODE = vbKeyShift Then
   ElseIf KEYCODE = vbKeyControl Then
   ElseIf KEYCODE = vbKeyMenu Then
   ElseIf KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
      wk_Int = AE_FuncKey_SSSMAIN(KEYCODE, Shift)
      If KEYCODE = vbKeyF10 And Shift = 0 Then Exit Sub
      If KEYCODE = vbKeyF4 And (Shift And 6) = 4 Then Exit Sub
   Else
      If Shift <> 4 Then Beep
   End If
   KEYCODE = 0
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

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KEYCODE = 0
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button And vbRightButton) = vbRightButton Then
      TX_Message.Enabled = False
      PP_SSSMAIN.ShortCutTx = -3
' === 20110216 === DELETE S TOM)Morimoto
'      SM_FullPast.Enabled = False
'      PopupMenu SM_ShortCut, vbPopupMenuRightButton
' === 20110216 === DELETE E
      TX_Message.Enabled = True
   End If
End Sub

Private Sub TX_Mode_GotFocus() 'Generated.
   Beep
   Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
End Sub

Private Sub TX_Mode_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KEYCODE = 0
End Sub

Private Sub TX_Mode_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Mode_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button And vbRightButton) = vbRightButton Then
      TX_Mode.Enabled = False
      PP_SSSMAIN.ShortCutTx = -2
' === 20110216 === DELETE S TOM)Morimoto
'      SM_FullPast.Enabled = False
'      PopupMenu SM_ShortCut, vbPopupMenuRightButton
' === 20110216 === DELETE E
      TX_Mode.Enabled = True
   End If
End Sub

' === 20110217 === INSERT S TOM)Morimoto
Public Function selectFile(ByRef strFile As String) As Boolean
    On Error GoTo err_selectFile
    With CMDialogL
        .DefaultExt = gv_strOUT_TYPE    'ファイル拡張子の既定値
        .Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE & "|*.*|*.*"
        .CancelError = True
        .ShowSave
    strFile = .fileName
    selectFile = True
    End With
    selectFile = True
    Exit Function
err_selectFile:
    If Err.Number = 32755 Then
        Exit Function
    End If
    On Error GoTo 0
End Function
Public Sub show_GAGE(ByVal flg As Boolean)
    GAUGE.FloodPercent = 0
    GAUGE.ForeColor = vbBlack
    GAUGE.Visible = flg
    CM_LCANCEL.Visible = flg
End Sub
Public Sub count_GAGE(ByVal cnt As Long, ByVal all_cnt As Long)
    If all_cnt > 0 Then
        GAUGE.FloodPercent = cnt / all_cnt * 100
        If GAUGE.FloodPercent > 50 Then
            GAUGE.ForeColor = vbWhite
        End If
    End If
End Sub
Public Sub formenabled(ByVal flg As Boolean)
    Dim I As Integer
    Dim objctrl As Control
    On Error Resume Next
    For Each objctrl In Me
        Select Case True
        Case TypeOf objctrl Is TextBox
            objctrl.Enabled = flg
        Case TypeOf objctrl Is Image
            objctrl.Enabled = flg
        Case TypeOf objctrl Is Menu
            objctrl.Enabled = flg
        End Select
    Next
    On Error GoTo 0
End Sub
' === 20110217 === INSERT E

