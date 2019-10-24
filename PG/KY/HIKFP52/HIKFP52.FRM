VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "在庫引当一括解除処理"
   ClientHeight    =   3885
   ClientLeft      =   1275
   ClientTop       =   3465
   ClientWidth     =   8415
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
   Icon            =   "HIKFP52.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   Picture         =   "HIKFP52.frx":030A
   ScaleHeight     =   3885
   ScaleWidth      =   8415
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Left            =   5865
      MaxLength       =   24
      TabIndex        =   14
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   645
      Width           =   2205
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   5085
      MaxLength       =   10
      TabIndex        =   13
      Text            =   "XXXXX6"
      Top             =   645
      Width           =   795
   End
   Begin VB.TextBox HD_HINNMB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   315
      IMEMode         =   2  'ｵﾌ
      Left            =   3615
      MaxLength       =   30
      TabIndex        =   12
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMM3"
      Top             =   2055
      Width           =   3285
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   0
      Left            =   -45
      TabIndex        =   9
      Top             =   0
      Width           =   8490
      _ExtentX        =   14975
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
         Height          =   330
         Left            =   6420
         TabIndex        =   10
         Top             =   90
         Width           =   1680
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
      Begin VB.Image CM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1020
         Picture         =   "HIKFP52.frx":097C
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   300
         Picture         =   "HIKFP52.frx":0B06
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   660
         Picture         =   "HIKFP52.frx":0C90
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   570
         Left            =   0
         Top             =   0
         Width           =   8490
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   765
      Index           =   2
      Left            =   -15
      TabIndex        =   6
      Top             =   3165
      Width           =   8490
      _ExtentX        =   14975
      _ExtentY        =   1349
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
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   465
         Index           =   3
         Left            =   675
         TabIndex        =   7
         Top             =   135
         Width           =   7520
         _ExtentX        =   13256
         _ExtentY        =   820
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
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   8
            Text            =   "HIKFP52.frx":0E1A
            Top             =   120
            Width           =   7260
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKFP52.frx":0E51
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.Frame Frm_Main 
      Caption         =   "条件指定"
      ForeColor       =   &H00000000&
      Height          =   1635
      Left            =   1140
      TabIndex        =   3
      Top             =   1200
      Width           =   6135
      Begin VB.TextBox HD_HINNMA 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   315
         IMEMode         =   2  'ｵﾌ
         Left            =   2475
         MaxLength       =   30
         TabIndex        =   11
         Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXX3"
         Top             =   510
         Width           =   3285
      End
      Begin VB.TextBox HD_HINCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFFFFF&
         Height          =   315
         IMEMode         =   2  'ｵﾌ
         Left            =   1485
         MaxLength       =   17
         TabIndex        =   4
         Text            =   "XXXXXXX8"
         Top             =   510
         Width           =   1005
      End
      Begin VB.Label CS_HINCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H80000005&
         BackStyle       =   0  '透明
         Caption         =   "*製品ｺｰﾄﾞ"
         ForeColor       =   &H80000008&
         Height          =   330
         Left            =   375
         TabIndex        =   5
         Top             =   540
         Width           =   1410
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   1410
      Index           =   0
      Left            =   0
      TabIndex        =   1
      Top             =   7800
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
         TabIndex        =   2
         Text            =   "ﾓｰﾄﾞ"
         Top             =   630
         Width           =   735
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2430
         Picture         =   "HIKFP52.frx":0FDB
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   2025
         Picture         =   "HIKFP52.frx":1165
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4320
         Picture         =   "HIKFP52.frx":12EF
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3960
         Picture         =   "HIKFP52.frx":1479
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3600
         Picture         =   "HIKFP52.frx":1603
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3240
         Picture         =   "HIKFP52.frx":178D
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2880
         Picture         =   "HIKFP52.frx":1917
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2520
         Picture         =   "HIKFP52.frx":1AA1
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2160
         Picture         =   "HIKFP52.frx":1C2B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1395
         Picture         =   "HIKFP52.frx":1DB5
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKFP52.frx":1F3F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "HIKFP52.frx":20C9
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   990
         Picture         =   "HIKFP52.frx":2253
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1845
         Picture         =   "HIKFP52.frx":23DD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
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
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   3840
      TabIndex        =   15
      Top             =   645
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   609
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
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " 入力担当者"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox TX_Dummy 
      Height          =   285
      Left            =   3690
      TabIndex        =   16
      Top             =   3360
      Width           =   210
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   0
      Picture         =   "HIKFP52.frx":2567
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   0
      Picture         =   "HIKFP52.frx":26F1
      Top             =   30
      Width           =   360
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "処理(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "実行(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_DeleteCM 
         Caption         =   "削除(&D)"
         Shortcut        =   ^D
         Visible         =   0   'False
      End
      Begin VB.Menu MN_HARDCOPY 
         Caption         =   "画面印刷"
         Visible         =   0   'False
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
         Visible         =   0   'False
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "項目初期化"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "項目復元"
      End
      Begin VB.Menu MN_ClearDE 
         Caption         =   "明細行初期化"
         Visible         =   0   'False
      End
      Begin VB.Menu MN_DeleteDE 
         Caption         =   "明細行削除(&T)"
         Shortcut        =   ^T
         Visible         =   0   'False
      End
      Begin VB.Menu MN_InsertDE 
         Caption         =   "明細行挿入(&I)"
         Shortcut        =   ^I
         Visible         =   0   'False
      End
      Begin VB.Menu MN_UnDoDe 
         Caption         =   "明細行復元"
         Visible         =   0   'False
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
         Caption         =   "候補の一覧(&L&ﾆ)..."
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
'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
Private Const FM_PANEL3D1_CNT       As Integer = 4 'パネルコントロール数
'*** End Of Generated Declaration Section ****

'=== 当画面の全情報を格納 =================
Private Main_Inf    As Cls_All
'=== 当画面の全情報を格納 =================
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Def_Dsp
    '   概要：  各画面の項目情報を設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Dsp() As Integer
    
    Dim Index_Wk        As Integer
    Dim BD_Cnt          As Integer
    Dim Wk_Cnt          As Integer
    
    '画面基礎共通情報設定
    Call CF_Init_Def_Dsp(Me, Main_Inf)
    
    '/////////////////////
    '// メッセージ共通設定
    '/////////////////////
    Set Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message
    
    
    '画面基礎情報設定
    With Main_Inf.Dsp_Base
        .Item_Cnt = 38         '画面項目数
        .Dsp_Body_Cnt = -1     '画面表示明細数（-1：明細なし、０：制限なし、１～：表示時明細数）
        .Max_Body_Cnt = -1     '最大表示明細数（-1：明細なし、０：制限なし、１～：最大明細数）
        .Body_Col_Cnt = 0      '明細の列項目数
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
        Set .FormCtl = FR_SSSMAIN
' === 20060920 === INSERT E
    End With
    
    '画面項目情報
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
    
    '/////////////////////
    '// 全画面用制御用ｺﾝﾄﾛｰﾙ
    '/////////////////////
    '初期設定用タイマー
    Set Main_Inf.TM_StartUp_Ctl = TM_StartUp
    Main_Inf.TM_StartUp_Ctl.Interval = 1
    Main_Inf.TM_StartUp_Ctl.Enabled = True
    
    Index_Wk = 0
    'カーソル制御用テキスト
    TX_CursorRest.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    '///////////////////
    '// メニュー部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    '処理１
    MN_Ctrl.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '登録
    MN_Execute.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '削除
    MN_DeleteCM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteCM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '画面印刷
    MN_HARDCOPY.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '終了
    MN_EndCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '処理２
    MN_EditMn.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '画面初期化
    MN_APPENDC.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '項目初期化
    MN_ClearItm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '項目復元
    MN_UnDoItem.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '明細行初期化
    MN_ClearDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearDE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '明細行削除
    MN_DeleteDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteDE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '明細行挿入
    MN_InsertDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_InsertDE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '明細行復元
    MN_UnDoDe.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoDe
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '切り取り
    MN_Cut.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    'コピー
    MN_Copy.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '貼り付け
    MN_Paste.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '操作３
    MN_Oprt.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '項目の一覧
    MN_Slist.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '項目内容にコピー
    SM_AllCopy.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '取り消し
    SM_Esc.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '項目に貼り付け
    SM_FullPast.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '終了イメージ
    CM_EndCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
    Set Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
    '=== ｲﾒｰｼﾞ設定 ======================
    
    Index_Wk = Index_Wk + 1
    '登録イメージ
    CM_Execute.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
    Set Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
    '=== ｲﾒｰｼﾞ設定 ======================
    
    Index_Wk = Index_Wk + 1
    '検索画面表示イメージ
    CM_Slist.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Slist
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
    Set Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
    '=== ｲﾒｰｼﾞ設定 ======================
    
    Index_Wk = Index_Wk + 1
    'ヘッダイメージ
    Image1.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '処理日付
    SYSDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    '///////////////////
    '// ヘッダ部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    '入力担当者(ｺｰﾄﾞ)
    HD_IN_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '入力担当者(名称)
    HD_IN_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
' === 20060925 === UPDATE S - ACE)Nagasawa
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
' === 20060925 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

'    Index_Wk = Index_Wk + 1
'    '製品コード
'    CS_HINCD.Tag = Index_Wk
'    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '製品コード
    HD_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20061127 === UPDATE S - ACE)Nagasawa コードの大文字変換処理追加
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20061127 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '型式
    HD_HINNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '品名
    HD_HINNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
    
    '///////////////
    '// ボディ部編集
    '///////////////
    
    '画面基礎情報設定
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ
    

    '///////////////
    '// フッタ部編集
    '///////////////
   
    Index_Wk = Index_Wk + 1
    'ダミーテキスト
    TX_Dummy.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Dummy
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    '画面基礎情報設定
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

    '///////////////////
    '// メッセージ部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    'メッセージ
    TX_Message.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Message
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    'TX_Mode
    TX_Mode.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    '///////////////////
    '// その他編集
    '///////////////////
    For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        Index_Wk = Index_Wk + 1

        FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    Next
    
'E★★★★★★★★★★★★★★★★★★★★★★★★★★★★E

    '上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
    Call CF_Init_Item_Property(Main_Inf)
    '画面項目情報を再設定
    Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

    '///////////////////
    '// 特別項目の再設定
    '///////////////////
    'カーソル制御用テキスト
    TX_CursorRest.TabStop = False
    TX_Message.TabStop = False

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyReturn
    '   概要：  各項目のVBKEYRETURN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyReturn(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
' === 20060915 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正2
        'キーフラグを元に戻す
        gv_bolKeyFlg = False
' === 20060915 === INSERT E -
    End If
    '取得内容表示/クリア
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
'        'ﾁｪｯｸ後移動あり
'        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
        '更新前チェック⇒ＤＢ更新⇒初期化
        Call F_Ctl_Upd_Process(Main_Inf)
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function
    
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyRight
    '   概要：  各項目のVBKEYRIGHT制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyRight(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYRIGHT制御
    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyDown
    '   概要：  各項目のVBKEYDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyDown(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = False

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    'ﾁｪｯｸ後移動あり
        'KEYDOWN制御
        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '次の項目へ移動した場合
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '項目色設定
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyLeft
    '   概要：  各項目のVBKEYLEFT制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyLeft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYLEFT制御
    Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyUp
    '   概要：  各項目のVBKEYUP制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyUp(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    'ﾁｪｯｸ後移動あり
        'KEYUP制御
        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '次の項目へ移動した場合
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '項目色設定
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If

    Else
    'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyDown
    '   概要：  各項目のKEYDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

' === 20060802 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
    'Enter時のみフラグをON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If
            
        gv_bolKeyFlg = True
    End If
' === 20060802 === INSERT E -

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        'ｴﾝﾀｰｷｰ押
        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
            pm_KeyCode = 0
            'ｴﾝﾀｰｷｰ制御
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '→押
        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
            pm_KeyCode = 0
            '→制御
            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '↓押
        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
            pm_KeyCode = 0
            '↓制御
            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '←押
        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
            pm_KeyCode = 0
            '←制御
            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '↑押
        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
            '↑制御
            pm_KeyCode = 0
            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'DELETE押
        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'INSERT押
        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'TAB押
        Case pm_KeyCode = vbKeyF16
            pm_KeyCode = 0
            'ｴﾝﾀｰｷｰ制御
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'Shift+TAB押
        Case pm_KeyCode = vbKeyF15
            pm_KeyCode = 0
            '前ﾌｫｰｶｽ位置へ移動
            Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

' === 20060930 === INSERT S - ACE)Nagasawa ファンクションキー処理対応
        'ファンクションキー押下時
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
' === 20060930 === INSERT E -

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_LostFocus
    '   概要：  各項目のLOSTFOCUS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean

    If gv_bolHIKFP52_LF_Enable = False Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
    Act_Index = CInt(Me.ActiveControl.Tag)
    
    'ﾛｽﾄﾌｫｰｶｽ実行判定
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
    
    Move_Flg = False
    Chk_Move_Flg = True
    
    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
    
    If Chk_Move_Flg = True Then
        'ﾁｪｯｸ後移動あり
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        
        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
        '選択状態の設定
        Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), 0)
        '項目色設定
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
        
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_GotFocus
    '   概要：  各項目のGOTFOCUS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_GotFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Rtn_Chk     As Integer
    Dim Move_Flg    As Boolean
    Dim Wk_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    '画面単位の処理(ﾁｪｯｸなど)
    '明細部でかつ移動前が明細部でない場合
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'ﾍｯﾀﾞ部ﾁｪｯｸ
        Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Select Case Trg_Index
        Case CInt(TX_Dummy.Tag)
            'ダミーコントロールにフォーカス移動した場合、製品コードのチェック
'            Call CF_Set_Chk_From_Process(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_Process, Main_Inf)
'            '製品コードのﾁｪｯｸ
'            Rtn_Chk = F_Chk_HD_HINCD(pm_Dsp_Sub_Inf _
'                                   , pm_Chk_Move_Flg _
'                                   , pm_All)

        Case Else
            '共通ﾌｫｰｶｽ取得処理
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

    End Select

    'メニュー使用可否制御
    Call F_Ctl_MN_Enabled(Main_Inf)
    
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyPress
    '   概要：  各項目のKEYPRESS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyPress(pm_Ctl As Control, ByRef pm_KeyAscii As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '共通KEYPRESS制御
    Call CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            
            '現在ﾌｫｰｶｽ位置から右へ移動
            Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
        '項目色設定(入力開始で色をﾌｫｰｶｽありの前景色＝黒に設定！！)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  各項目のCHANGE制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index    As Integer
    
    If Main_Inf.Dsp_Base.Change_Flg = True Then
        Main_Inf.Dsp_Base.Change_Flg = False
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)
    
    '共通KEYCHANG制御
    Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    '画面単位の処理(ﾁｪｯｸなど)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseUp
    '   概要：  各項目のMOUSEUP制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseUp(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
' === 20060802 === DELETE S - ACE)Nagasawa
'            '項目色設定
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
' === 20060802 === DELETE E -

        Case TypeOf pm_Ctl Is SSPanel5
            'パネルの場合
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is Image
            'イメージの場合
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '終了ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                
                Case CInt(CM_Execute.Tag)
                '実行ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
        
                Case CInt(CM_Slist.Tag)
                '検索画面表示ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
        
            End Select

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseMove
    '   概要：  各項目のMOUSEMOVE制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseMove(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(Image1.Tag)
            'ｲﾒｰｼﾞ１初期化
            Call CF_Clr_Prompt(Main_Inf)

        Case CInt(CM_EndCm.Tag)
            '終了ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_Execute.Tag)
            '登録ｲﾒｰｼﾞ
' === 20060802 === UPDATE S - ACE)Nagasawa
'            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)
            Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, COLOR_BLACK, Main_Inf)
' === 20060802 === UPDATE E -

        Case CInt(CM_Slist.Tag)
            '検索画面ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)

    End Select

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseDown
    '   概要：  各項目のMOUSEDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer
    Dim Act_Index    As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    Act_Index = CInt(Me.ActiveControl.Tag)

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '終了ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '実行ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        Case CInt(CM_Slist.Tag)
        '検索画面表示ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)

    End Select

    '共通MOUSEDOWN制御
    Call CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Click
    '   概要：  各項目のCLICK制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Act_Index   As Integer
    Dim Wk_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Select Case Trg_Index
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
        Case CInt(MN_Ctrl.Tag)
            '処理１
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_Execute.Tag), CInt(CM_Execute.Tag)
            '登録
            Call Ctl_MN_Execute_Click

        Case CInt(MN_DeleteCM.Tag)
            '削除
            Call Ctl_MN_DeleteCM_Click

        Case CInt(MN_HARDCOPY.Tag)
            '画面印刷
            Call Ctl_MN_HARDCOPY_Click

        Case CInt(MN_EndCm.Tag), CInt(CM_EndCm.Tag)
            '終了
            Call Ctl_MN_EndCm_Click
            Exit Function
            
        Case CInt(MN_EditMn.Tag)
            '処理２
            Call Ctl_MN_EditMn_Click

        Case CInt(MN_APPENDC.Tag)
            '画面初期化
            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '項目初期化
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '項目復元
            Call Ctl_MN_UnDoItem_Click

        Case CInt(MN_ClearDE.Tag)
            '明細行初期化
            Call Ctl_MN_ClearDE_Click

        Case CInt(MN_DeleteCM.Tag)
            '明細行削除
            Call Ctl_MN_DeleteDE_Click

        Case CInt(MN_InsertDE.Tag)
            '明細行挿入
            Call Ctl_MN_InsertDE_Click

        Case CInt(MN_UnDoDe.Tag)
            '明細行復元
            Call Ctl_MN_UnDoDe_Click

        Case CInt(MN_Cut.Tag)
            '切り取り
            Call Ctl_MN_Cut_Click

        Case CInt(MN_Copy.Tag)
            'コピー
            Call Ctl_MN_Copy_Click

        Case CInt(MN_Paste.Tag)
            '貼り付け
            Call Ctl_MN_Paste_Click

        Case CInt(MN_Oprt.Tag)
            '操作３
            Call Ctl_MN_Oprt_Click

        Case CInt(MN_Slist.Tag), CInt(CM_Slist.Tag)
            '項目の一覧
            Call Ctl_MN_Slist_Click

        Case CInt(SM_AllCopy.Tag)
            '項目内容にコピー
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '取り消し
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '項目に貼り付け
            Call Ctl_SM_FullPast_Click
            
    End Select

    'ステータスバー初期化
    Call CF_Clr_Prompt(Main_Inf)

End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Ctrl_Click
    '   概要：  メニュー処理１の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Ctrl_Click() As Integer

    Dim Ant_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '｢登録｣判定
    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢削除｣判定
    MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢画面印刷｣判定
    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     '｢終了｣判定
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'メニュー使用可/不可制御
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EditMn_Click
    '   概要：  メニュー処理２の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '｢画面初期化｣判定
    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢項目初期化｣判定
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢項目復元｣判定
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行初期化｣判定
    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行削除｣判定
    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行挿入｣判定
    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行復元｣判定
    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢切り取り｣判定
    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢コピー｣判定
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢貼り付け｣判定
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EditMn_Click
    '   概要：  メニュー操作３の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

End Function
    
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function Ctl_MN_Execute_Click
'   概要：  実行(抽出データを検索)
'   引数：　なし
'   戻値：　なし
'   備考：  全画面ローカル共通処理
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer
    
    Dim Wk_Index   As Integer

    '製品コードにおけるEnterキー押下処理をコール
    Call HD_HINCD_KeyDown(vbKeyReturn, 0)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_HARDCOPY_Click
    '   概要：  画面印刷
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EndCm_Click
    '   概要：  終了
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Unload FR_SSSMAIN
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearItm_Click
    '   概要：  項目初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearItm_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)
    
    '画面内容初期化
    Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

    '共通ﾌｫｰｶｽ取得処理
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UnDoItem_Click
    '   概要：  項目復元
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoItem_Click() As Integer
    Dim Act_Index   As Integer
    
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の復元処理
    Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    
    Move_Flg = False
    Chk_Move_Flg = True
    
    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
    
    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
    
    '選択状態の設定（初期選択）
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
    
    '項目色設定
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Cut_Click
    '   概要：  切り取り
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Cut_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の切り取り
    Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    '項目初期化
    Call Ctl_MN_ClearItm_Click
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Copy_Click
    '   概要：  コピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer

    '項目内容にコピー
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Paste_Click
    '   概要：  貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Paste_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Slist_Click
    '   概要：  候補の一覧
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Call F_Ctl_CS(Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SM_AllCopy_Click
    '   概要：  項目内容にコピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_AllCopy_Click() As Integer

    '項目内容にコピー
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_SM_Esc_Click
    '   概要：  取り消し
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_SM_FullPast_Click
    '   概要：  項目に貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_FullPast_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    '注）メニューの画面｢貼り付け｣と同一関数を使用！！
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_SELECTCM_Click
    '   概要：  選択（明細部クリア）
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SELECTCM_Click() As Integer
    
    'ヘッダ部入力制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '画面ボディ部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)
    
    '初期フォーカス位置設定
    Call F_Init_Cursor_Set(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KEYUP
    '   概要：  各項目のKEYUP制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
' === 20060731 === INSERT S - ACE)Nagasawa  エンターキー連打による不具合修正
    'キーフラグを元に戻す
    gv_bolKeyFlg = False
' === 20060731 === INSERT E -
'
'    '各検索画面呼出
'    Select Case Trg_Index
'        Case CInt(CS_HINCD.Tag)
'    End Select
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_APPENDC_Click
    '   概要：  画面初期化制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_APPENDC_Click() As Integer

    '画面内容初期化
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    'ヘッダ部入力制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '画面ボディ部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def

    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)
    
    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)
    
    '初期フォーカス位置設定
    Call F_Init_Cursor_Set(Main_Inf)

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearDE_Click
    '   概要：  明細行初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteCM_Click
    '   概要：  削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteCM_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteDE_Click
    '   概要：  明細行削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_InsertDE_Click
    '   概要：  明細行挿入
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UnDoDe_Click
    '   概要：  明細行復元
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoDe_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function
    
'□□□□□□□□ 全画面ローカル共通処理 End □□□□□□□□□□□□□□□□
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Edi_Dsp_Def
    '   概要：  初期時の画面編集
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Edi_Dsp_Def() As Integer
    Dim Index_Wk        As Integer
    Dim strSYSDT        As String
    
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Index_Wk = CInt(SYSDT.Tag)
    '画面日付
'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Def_Body_Inf
    '   概要：  画面ボディ情報設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Body_Inf() As Integer

    Dim Bd_Col_Index    As Integer
    Dim Index_Wk        As Integer

    '初期画面ボディ情報設定
    Call CF_Init_Set_Body_Inf(Main_Inf)

    If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
    '明細行が存在する場合

        '画面ボディの列分の配列定義
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '初期状態
        Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT

        '画面ボディ情報の配列０番目に列情報を定義する
        For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
            Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
        Next

    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Set_Body_Location
    '   概要：  明細の配置
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Set_Body_Location() As Integer
    
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

Private Sub TM_StartUp_Timer()
    '一度きりのため使用不可
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '初期ﾌｫｰｶｽ位置設定s
    Call F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()

    'DB接続
    Call CF_Ora_USR1_Open

    '共通初期化処理
    Call CF_Init
    
    '画面情報設定
    Call Init_Def_Dsp
    
    '画面内容初期化
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    'ヘッダ部入力制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '画面明細情報設定
    Call Init_Def_Body_Inf

    '画面明細部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '明細ロケーション
    Call Set_Body_Location

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)

    '画面表示位置設定
    Call CF_Set_Frm_Location(FR_SSSMAIN)
    
    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)
    
    'システム共通処理
    Call CF_System_Process(Me)
    
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    'メッセージ出力
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKFP52_Q_EXIT03, Main_Inf) <> vbYes Then
        Cancel = True
    Else
        '検索画面クローズ
        Call F_Ctl_WLS_Close
        
' === 20060907 === INSERT S - ACE)Sejima
    Main_Inf.Dsp_Base.IsUnload = True
' === 20060907 === INSERT E
        '共通終了処理？
        Set FR_SSSMAIN = Nothing
        
' === 20060802 === INSERT S - ACE)Nagasawa
        'DB接続解除
        Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
' === 20060802 === INSERT E -
        
' === 20061102 === INSERT S - ACE)Yano ﾛｸﾞﾌｧｲﾙ書込み（プログラム終了）
    Call SSSWIN_LOGWRT("プログラム終了")
' === 20061102 === INSERT E
    
    End If

End Sub

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub CM_Execute_Click()
    Debug.Print "CM_Execute_Click"
    Call Ctl_Item_Click(CM_Execute)
End Sub

Private Sub CM_Slist_Click()
    Debug.Print "CM_Slist_Click"
    Call Ctl_Item_Click(CM_Slist)
End Sub

Private Sub Image1_Click()
    Debug.Print "Image1_Click"
    Call Ctl_Item_Click(Image1)
End Sub

Private Sub MN_APPENDC_Click()
    Debug.Print "MN_APPENDC_Click"
    Call Ctl_Item_Click(MN_APPENDC)
End Sub

Private Sub MN_ClearItm_Click()
    Debug.Print "MN_ClearItm_Click"
    Call Ctl_Item_Click(MN_ClearItm)
End Sub

Private Sub MN_Copy_Click()
    Debug.Print "MN_Copy_Click"
    Call Ctl_Item_Click(MN_Copy)
End Sub

Private Sub MN_Ctrl_Click()
    Debug.Print "MN_Ctrl_Click"
    Call Ctl_Item_Click(MN_Ctrl)
End Sub

Private Sub MN_Cut_Click()
    Debug.Print "MN_Cut_Click"
    Call Ctl_Item_Click(MN_Cut)
End Sub

Private Sub MN_EditMn_Click()
    Debug.Print "MN_EditMn_Click"
    Call Ctl_Item_Click(MN_EditMn)
End Sub

Private Sub MN_EndCm_Click()
    Debug.Print "MN_EndCm_Click"
    Call Ctl_Item_Click(MN_EndCm)
End Sub

Private Sub MN_Oprt_Click()
    Debug.Print "MN_Oprt_Click"
    Call Ctl_Item_Click(MN_Oprt)
End Sub

Private Sub MN_Paste_Click()
    Debug.Print "MN_Paste_Click"
    Call Ctl_Item_Click(MN_Paste)
End Sub

Private Sub MN_Slist_Click()
    Debug.Print "MN_Slist_Click"
    Call Ctl_Item_Click(MN_Slist)
End Sub

Private Sub MN_UnDoItem_Click()
    Debug.Print "MN_UnDoItem_Click"
    Call Ctl_Item_Click(MN_UnDoItem)
End Sub

Private Sub SM_AllCopy_Click()
    Debug.Print "SM_AllCopy_Click"
    Call Ctl_Item_Click(SM_AllCopy)
End Sub

Private Sub SM_Esc_Click()
    Debug.Print "SM_Esc_Click"
    Call Ctl_Item_Click(SM_Esc)
End Sub

Private Sub SM_FullPast_Click()
    Debug.Print "SM_FullPast_Click"
    Call Ctl_Item_Click(SM_FullPast)
End Sub

'Private Sub SM_ShortCut_Click()
'    Debug.Print "SM_ShortCut_Click"
'    Call Ctl_Item_Click(SM_ShortCut)
'End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseDown"
    Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_Slist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Slist_MouseDown"
    Call Ctl_Item_MouseDown(CM_Slist, Button, Shift, X, Y)
End Sub

'Private Sub FM_Panel3D1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "FM_Panel3D1_MouseDown"
'    Call Ctl_Item_MouseDown(FM_Panel3D1(Index), Button, Shift, X, Y)
'End Sub

Private Sub HD_HINCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMB_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

' === 20060810 === DELETE S - ACE)Nagasawa
'Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "Image1_MouseDown"
'    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
'End Sub
' === 20060810 === DELETE E -

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseMove"
    Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Slist_MouseMove"
    Call Ctl_Item_MouseMove(CM_Slist, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseUp"
    Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_Slist_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Slist_MouseUp"
    Call Ctl_Item_MouseUp(CM_Slist, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_HINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMB_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseUp"
    Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseUp"
    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub HD_HINCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINCD, KEYCODE, Shift)
End Sub

Private Sub HD_HINNMA_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINNMA, KEYCODE, Shift)
End Sub

Private Sub HD_HINNMB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMB_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINNMB, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
End Sub

Private Sub HD_HINCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINCD, KeyAscii)
End Sub

Private Sub HD_HINNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINNMA, KeyAscii)
End Sub

Private Sub HD_HINNMB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINNMB_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINNMB, KeyAscii)
End Sub

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Message_KeyPress"
    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
End Sub

Private Sub HD_HINCD_GotFocus()
    Debug.Print "HD_HINCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINCD)
End Sub

Private Sub HD_HINNMA_GotFocus()
    Debug.Print "HD_HINNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_GotFocus()
    Debug.Print "HD_HINNMB_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINNMB)
End Sub

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub HD_HINCD_LostFocus()
    Debug.Print "HD_HINCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINCD)
End Sub

Private Sub HD_HINNMA_LostFocus()
    Debug.Print "HD_HINNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_LostFocus()
    Debug.Print "HD_HINNMB_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINNMB)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub HD_HINCD_Change()
    Debug.Print "HD_HINCD_Change"
    Call Ctl_Item_Change(HD_HINCD)
End Sub

Private Sub HD_HINNMA_Change()
    Debug.Print "HD_HINNMA_Change"
    Call Ctl_Item_Change(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_Change()
    Debug.Print "HD_HINNMB_Change"
    Call Ctl_Item_Change(HD_HINNMB)
End Sub

Private Sub HD_IN_TANCD_Change()
    Debug.Print "HD_IN_TANCD_Change"
    Call Ctl_Item_Change(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_Change()
    Debug.Print "HD_IN_TANNM_Change"
    Call Ctl_Item_Change(HD_IN_TANNM)
End Sub

Private Sub TX_Message_Change()
    Debug.Print "TX_Message_Change"
    Call Ctl_Item_Change(TX_Message)
End Sub

' === 20070127 === DELETE S - ACE)Nagasawa
'Private Sub SYSDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "SYSDT_MouseDown"
'    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
'End Sub
' === 20070127 === DELETE E -

Private Sub SYSDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "SYSDT_MouseUp"
    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
End Sub

Private Sub TX_Dummy_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Dummy_MouseDown"
    Call Ctl_Item_MouseDown(TX_Dummy, Button, Shift, X, Y)
End Sub

Private Sub TX_Dummy_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Dummy_MouseUp"
    Call Ctl_Item_MouseUp(TX_Dummy, Button, Shift, X, Y)
End Sub

Private Sub TX_Dummy_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Dummy_KeyDown"
    Call Ctl_Item_KeyDown(TX_Dummy, KEYCODE, Shift)
End Sub

Private Sub TX_Dummy_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Dummy_KeyPress"
    Call Ctl_Item_KeyPress(TX_Dummy, KeyAscii)
End Sub

Private Sub TX_Dummy_GotFocus()
    Debug.Print "TX_Dummy_GotFocus"
    Call Ctl_Item_GotFocus(TX_Dummy)
End Sub

Private Sub TX_Dummy_LostFocus()
    Debug.Print "TX_Dummy_LostFocus"
    Call Ctl_Item_LostFocus(TX_Dummy)
End Sub

Private Sub TX_Dummy_Change()
    Debug.Print "TX_Dummy_Change"
    Call Ctl_Item_Change(TX_Dummy)
End Sub

'Private Sub MN_APPENDC_Click()
'    Debug.Print "MN_APPENDC_Click"
'    Call Ctl_Item_Click(MN_APPENDC)
'End Sub

Private Sub MN_ClearDE_Click()
    Debug.Print "MN_ClearDE_Click"
    Call Ctl_Item_Click(MN_ClearDE)
End Sub

'Private Sub MN_ClearItm_Click()
'    Debug.Print "MN_ClearItm_Click"
'    Call Ctl_Item_Click(MN_ClearItm)
'End Sub

'Private Sub MN_Copy_Click()
'    Debug.Print "MN_Copy_Click"
'    Call Ctl_Item_Click(MN_Copy)
'End Sub

'Private Sub MN_Ctrl_Click()
'    Debug.Print "MN_Ctrl_Click"
'    Call Ctl_Item_Click(MN_Ctrl)
'End Sub

'Private Sub MN_Cut_Click()
'    Debug.Print "MN_Cut_Click"
'    Call Ctl_Item_Click(MN_Cut)
'End Sub

Private Sub MN_DeleteCM_Click()
    Debug.Print "MN_DeleteCM_Click"
    Call Ctl_Item_Click(MN_DeleteCM)
End Sub

Private Sub MN_DeleteDE_Click()
    Debug.Print "MN_DeleteDE_Click"
    Call Ctl_Item_Click(MN_DeleteDE)
End Sub

'Private Sub MN_EditMn_Click()
'    Debug.Print "MN_EditMn_Click"
'    Call Ctl_Item_Click(MN_EditMn)
'End Sub

'Private Sub MN_EndCm_Click()
'    Debug.Print "MN_EndCm_Click"
'    Call Ctl_Item_Click(MN_EndCm)
'End Sub

Private Sub MN_Execute_Click()
    Debug.Print "MN_Execute_Click"
    Call Ctl_Item_Click(MN_Execute)
End Sub

Private Sub MN_HARDCOPY_Click()
    Debug.Print "MN_HARDCOPY_Click"
    Call Ctl_Item_Click(MN_HARDCOPY)
End Sub

Private Sub MN_InsertDE_Click()
    Debug.Print "MN_InsertDE_Click"
    Call Ctl_Item_Click(MN_InsertDE)
End Sub

'Private Sub MN_Oprt_Click()
'    Debug.Print "MN_Oprt_Click"
'    Call Ctl_Item_Click(MN_Oprt)
'End Sub

'Private Sub MN_Paste_Click()
'    Debug.Print "MN_Paste_Click"
'    Call Ctl_Item_Click(MN_Paste)
'End Sub

'Private Sub MN_Slist_Click()
'    Debug.Print "MN_Slist_Click"
'    Call Ctl_Item_Click(MN_Slist)
'End Sub

Private Sub MN_UnDoDe_Click()
    Debug.Print "MN_UnDoDe_Click"
    Call Ctl_Item_Click(MN_UnDoDe)
End Sub

'Private Sub MN_UnDoItem_Click()
'    Debug.Print "MN_UnDoItem_Click"
'    Call Ctl_Item_Click(MN_UnDoItem)
'End Sub

'Private Sub SM_AllCopy_Click()
'    Debug.Print "SM_AllCopy_Click"
'    Call Ctl_Item_Click(SM_AllCopy)
'End Sub

'Private Sub SM_Esc_Click()
'    Debug.Print "SM_Esc_Click"
'    Call Ctl_Item_Click(SM_Esc)
'End Sub
'
'Private Sub SM_FullPast_Click()
'    Debug.Print "SM_FullPast_Click"
'    Call Ctl_Item_Click(SM_FullPast)
'End Sub
'
'Private Sub SM_ShortCut_Click()
'    Debug.Print "SM_ShortCut_Click"
'    Call Ctl_Item_Click(SM_ShortCut)
'End Sub

' === 20060802 === INSERT S - ACE)Nagasawa
Private Sub HD_HINCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINCD_Click"
    Call Ctl_Item_KeyUp(HD_HINCD)
End Sub
' === 20060802 === INSERT E -

