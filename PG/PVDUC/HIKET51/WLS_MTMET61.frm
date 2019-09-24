VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_MTMET61 
   Caption         =   "見積書検索"
   ClientHeight    =   5865
   ClientLeft      =   465
   ClientTop       =   1230
   ClientWidth     =   14325
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   5865
   ScaleWidth      =   14325
   Begin Threed5.SSCommand5 CS_JDNTRKB 
      Height          =   375
      Left            =   7800
      TabIndex        =   20
      TabStop         =   0   'False
      Top             =   75
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "受注取区"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_TOKCD 
      Height          =   375
      Left            =   4785
      TabIndex        =   23
      TabStop         =   0   'False
      Top             =   555
      Width           =   1605
      _ExtentX        =   2831
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "得意先　　　　 "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_MITDT 
      Height          =   375
      Left            =   75
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   555
      Width           =   1380
      _ExtentX        =   2434
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "見積日付 　"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_TANCD 
      Height          =   375
      Left            =   75
      TabIndex        =   21
      TabStop         =   0   'False
      Top             =   75
      Width           =   1380
      _ExtentX        =   2434
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "営業担当者"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   330
      Left            =   7125
      TabIndex        =   19
      Top             =   5340
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   330
      Left            =   6045
      TabIndex        =   18
      Top             =   5340
      Width           =   1095
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   330
      Left            =   45
      TabIndex        =   7
      Top             =   1185
      Width           =   14235
      _ExtentX        =   25109
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   "見積№　    受注取区   見積日付   得意先                         見積件名                                 確定区分"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1020
      Index           =   0
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   14430
      _ExtentX        =   25453
      _ExtentY        =   1799
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox HD_KENNMA 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   8925
         TabIndex        =   16
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   540
         Width           =   4890
      End
      Begin VB.TextBox HD_KKTFL 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   11835
         TabIndex        =   5
         Text            =   "9"
         Top             =   60
         Width           =   315
      End
      Begin VB.TextBox HD_TOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   6360
         TabIndex        =   15
         Text            =   "XXXX5"
         Top             =   540
         Width           =   705
      End
      Begin VB.TextBox HD_MITDT 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1425
         TabIndex        =   14
         Text            =   "9999/99/99"
         Top             =   540
         Width           =   1305
      End
      Begin VB.TextBox HD_MITNOV 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   7395
         TabIndex        =   4
         Text            =   "12"
         Top             =   60
         Width           =   315
      End
      Begin VB.TextBox HD_MITNO 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   6360
         TabIndex        =   3
         Text            =   "XXXXXXX8"
         Top             =   60
         Width           =   1050
      End
      Begin VB.TextBox HD_TANCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1425
         TabIndex        =   1
         Text            =   "XXXXX6"
         Top             =   60
         Width           =   825
      End
      Begin VB.TextBox HD_JDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   8925
         TabIndex        =   12
         Text            =   "99"
         Top             =   60
         Width           =   360
      End
      Begin VB.TextBox HD_TANNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2235
         TabIndex        =   2
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   60
         Width           =   2475
      End
      Begin VB.TextBox HD_JDNTRKBNM 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         BeginProperty Font 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   9270
         TabIndex        =   13
         Text            =   "MMMMMMMMM1"
         Top             =   60
         Width           =   1305
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   1
         Left            =   4770
         TabIndex        =   8
         Top             =   60
         Width           =   1605
         _ExtentX        =   2831
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "開始見積番号"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   4
         Left            =   7785
         TabIndex        =   9
         Top             =   540
         Width           =   1155
         _ExtentX        =   2037
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "見積件名"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   3
         Left            =   12135
         TabIndex        =   6
         Top             =   60
         Width           =   2115
         _ExtentX        =   3731
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "0:全件 1:確定 9:未確定"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   2
         Left            =   10635
         TabIndex        =   11
         Top             =   60
         Width           =   1215
         _ExtentX        =   2143
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "*確定区分"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin VB.Label Label2 
         Caption         =   "以降"
         BeginProperty Font 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   2790
         TabIndex        =   10
         Top             =   600
         Width           =   645
      End
   End
   Begin VB.ListBox LST 
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3660
      ItemData        =   "WLS_MTMET61.frx":0000
      Left            =   30
      List            =   "WLS_MTMET61.frx":0007
      TabIndex        =   17
      Top             =   1485
      Width           =   14235
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   6585
      Picture         =   "WLS_MTMET61.frx":007D
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   7485
      Picture         =   "WLS_MTMET61.frx":06CF
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   7080
      Picture         =   "WLS_MTMET61.frx":0D21
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   6180
      Picture         =   "WLS_MTMET61.frx":1373
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image CM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   8385
      Picture         =   "WLS_MTMET61.frx":19C5
      Top             =   5340
      Width           =   360
   End
   Begin VB.Image CM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5505
      Picture         =   "WLS_MTMET61.frx":2017
      Top             =   5340
      Width           =   360
   End
End
Attribute VB_Name = "WLS_MTMET61"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　検索ウィンドウ
'*  プログラム名　　：　見積情報検索
'*  プログラムＩＤ　：  WLS_MTMET61
'*  作成者　　　　　：　ACE)長澤
'*  作成日　　　　　：  2006.07.04
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************
'************************************************************************************
'   構造体
'************************************************************************************
    Private Type Type_DB_MITTHA_W
        MITNO       As String       '見積番号
        MITNOV      As String       '見積番号版数
        JDNTRKB     As String       '受注取引区分
        JDNTRKBNM   As String       '受注取引区分名
        MITDT       As String       '見積日
        TOKRN       As String       '得意先略称
        KENNMA      As String       '件名１
        KKTMTFL     As String       '確定見積区分
    End Type
'************************************************************************************
'   Private定数
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]
    
    Private Const FM_PANEL3D1_CNT       As Integer = 5 'パネルコントロール数

'************************************************************************************
'   Private変数
'************************************************************************************
'=== 当画面の全情報を格納 =================
    Private Main_Inf    As Cls_All
'=== 当画面の全情報を格納 =================

    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_MITTHA_W         As Type_DB_MITTHA_W
    Private Dyn_Open            As Boolean          'ダイナセット状態（True:Open False:Close)
    
    Private WM_WLS_MAX          As Integer
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)
    
    Private DblClickFl As Boolean


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

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '画面基礎情報設定
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                '画面分類
' === 20060921 === UPDATE S - ACE)Sejima
'D        .Item_Cnt = 23                              '画面項目数
' === 20060921 === UPDATE ↓
        .Item_Cnt = 24                              '画面項目数
' === 20060921 === UPDATE E
        .Dsp_Body_Cnt = 0                           '画面表示明細数（０：明細なし、１～：表示時明細数）
        .Max_Body_Cnt = 0                           '最大表示明細数（０：明細なし、１～：最大明細数）
        .Body_Col_Cnt = 0                           '明細の列項目数
        .Dsp_Body_Move_Qty = 0                      '画面移動量
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
        Set .FormCtl = WLS_MTMET61
' === 20060920 === INSERT E
    End With
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '画面項目情報
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '/////////////////////
    '// 全画面用制御用ｺﾝﾄﾛｰﾙ
    '/////////////////////

    Index_Wk = 0

    '///////////////////
    '// ヘッダ部編集
    '///////////////////
    '担当者ボタン
    CS_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TANCD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '担当者(ｺｰﾄﾞ)
    HD_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '担当者(名称)
    HD_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '見積番号
    HD_MITNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    '2018/04/12 UPD START CIS)山口
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
    '2018/04/12 UPD END CIS)山口
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '版数
    HD_MITNOV.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNOV
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '受注取引区分ボタン
    CS_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNTRKB
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '受注取引区分(ｺｰﾄﾞ)
    HD_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
' === 20070206 === UPDATE S - ACE)Nagasawa
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '受注取引区分(名称)
    HD_JDNTRKBNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKBNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '確定区分
    HD_KKTFL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KKTFL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '見積日ボタン
    CS_MITDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_MITDT
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '見積日
    HD_MITDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '得意先ボタン
    CS_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TOKCD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '得意先(ｺｰﾄﾞ)
    HD_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '件名
    HD_KENNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
' === 20060921 === INSERT S - ACE)Sejima
    Index_Wk = Index_Wk + 1
    'リスト見出し
    WLSLABEL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSLABEL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
' === 20060921 === INSERT E
    
    Index_Wk = Index_Wk + 1
    'リスト
    LST.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = LST
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '前ページイメージ
    CM_PrevCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
    Set Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
    '=== ｲﾒｰｼﾞ設定 ======================
    
    Index_Wk = Index_Wk + 1
    'OKボタン
    WLSOK.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    'キャンセルボタン
    WLSCANCEL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '次ページイメージ
    CM_NextCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NextCm(0)
    Set Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NextCm(1)
    '=== ｲﾒｰｼﾞ設定 ======================
    
    '画面基礎情報設定
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

    '///////////////////
    '// その他編集
    '///////////////////
    For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        Index_Wk = Index_Wk + 1
        'FM_Panel3D1
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    Next
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
    Call CF_Init_Item_Property(Main_Inf)
    '画面項目情報を再設定
    Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

    '///////////////////
    '// 特別項目の再設定
    '///////////////////

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'リスト行数の設定
    WM_WLS_MAX = 15
    
    '返り値の設定
    WLSMIT_RTNMITNO = ""
    WLSMIT_RTNMITNOV = ""
    
    '確定フラグの初期値設定
    If Trim(WLSMIT_KKTFL) = "1" Or Trim(WLSMIT_KKTFL) = "9" Then
        pv_strInit_KKTFL = Trim(WLSMIT_KKTFL)
    Else
        pv_strInit_KKTFL = "0"
    End If

    '受注取引区分の初期値設定
    pv_strInit_JDNTRKB = Trim(WLSMIT_JDNTRKB)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
    Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        Select Case Me.ActiveControl.NAME
            Case HD_TANCD.NAME, HD_MITNO.NAME, HD_MITNOV.NAME, HD_JDNTRKB.NAME _
               , HD_KKTFL.NAME, HD_MITDT.NAME, HD_TOKCD.NAME, HD_KENNMA.NAME
                '変数クリア
                Call WLS_Clear
                'リスト編集
                Call Get_MITTHA
                Call WLS_DspNew
               
                'ﾌｫｰｶｽ移動
                Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(LST.Tag), Main_Inf)
                
            Case LST.NAME
                Call Ctl_WLSOK_Click
                
            Case Else
        End Select
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Clear
    '   概要：  変数初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()
        '画面表示ページ
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '検索結果保持配列
        ReDim WM_WLS_DSPArray(0)

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_MITTHA
    '   概要：  見積情報検索
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Get_MITTHA() As Integer

    Dim strSQL      As String
    
    '案件情報検索処理
    strSQL = ""
    strSQL = strSQL & " Select "
    strSQL = strSQL & "        MITTHA.MITNO       "     '見積番号
    strSQL = strSQL & "      , MITTHA.MITNOV      "     '版数
    strSQL = strSQL & "      , MITTHA.MITDT       "     '見積日
    strSQL = strSQL & "      , MITTHA.JDNTRKB     "     '受注取引区分
    strSQL = strSQL & "      , MEIMTA.MEINMA AS JDNTRKBNM   "     '受注取引区分名
    strSQL = strSQL & "      , MITTHA.TOKRN       "     '得意先名
    strSQL = strSQL & "      , MITTHA.KENNMA      "     '件名１
    strSQL = strSQL & "      , MITTHA.KKTMTFL     "     '確定見積フラグ
    strSQL = strSQL & "   From MITTHA "
    strSQL = strSQL & "      , MEIMTA "
    strSQL = strSQL & "  Where MITTHA.DATKB       = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "    and MEIMTA.DATKB (+)   = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "    and MEIMTA.KEYCD (+)   = '" & gc_strKEYCD_JDNTRKB & "' "
    strSQL = strSQL & "    and MITTHA.JDNTRKB     = MEIMTA.MEICDA (+) "
' === 20061006 === UPDATE S - ACE)Nagasawa 受注取込が行われた見積の表示は行わない
'    strSQL = strSQL & "    and MITTHA.JDNNO       = '" & Space(10) & "' "
' === 20061205 === UPDATE S - ACE)Nagasawa
'    If Trim(WLSMIT0001_JNDTRFLG) = "" Then
    If Trim(WLSMIT0001_JNDTRFLG) = "1" Then
' === 20061205 === UPDATE E -
        strSQL = strSQL & "    and MITTHA.JDNNO       = '" & Space(10) & "' "
    End If
' === 20061006 === UPDATE E -
    
    '担当者ID
    If Trim(HD_TANCD.Text) <> "" Then
        strSQL = strSQL & "    and TANCD  = '" & CF_Ora_String(Trim(HD_TANCD.Text), 6) & "' "
    End If

' === 20060725 === UPDATE S - ACE)Nagasawa
'    '開始見積番号
'    If Trim(HD_MITNO.Text) <> "" Then
'        strSQL = strSQL & "    and MITNO  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) & "' "
'    End If
'
'    '開始見積版数
'    If Trim(HD_MITNOV.Text) <> "" Then
'        strSQL = strSQL & "    and MITNOV >= '" & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
'    End If
    
    Select Case True
        '見積番号、版数共に入力
        Case Trim(HD_MITNO.Text) <> "" And Trim(HD_MITNOV.Text) <> ""
            strSQL = strSQL & "    and MITNO　|| MITNOV  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) _
                                                               & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
        '見積番号のみ入力
        Case Trim(HD_MITNO.Text) <> "" And Trim(HD_MITNOV.Text) = ""
            strSQL = strSQL & "    and MITNO  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) & "' "
            
        '見積番号のみ入力
        Case Trim(HD_MITNO.Text) = "" And Trim(HD_MITNOV.Text) <> ""
            strSQL = strSQL & "    and MITNOV >= '" & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
    End Select
' === 20060725 === UPDATE E -
    
    '受注取引区分
    If Trim(HD_JDNTRKB.Text) <> "" Then
        strSQL = strSQL & "    and JDNTRKB = '" & CF_Ora_String(Trim(HD_JDNTRKB.Text), 2) & "' "
    End If
    
    '確定区分
    Select Case Trim(HD_KKTFL.Text)
        Case "0"
        
        Case "1", "9"
            strSQL = strSQL & "    and KKTMTFL   = '" & CF_Ora_String(Trim(HD_KKTFL.Text), 1) & "' "

    End Select
    
    '見積日付
    If Trim(HD_MITDT.Text) <> "" Then
        strSQL = strSQL & "    and MITDT  >= '" & CF_Ora_Date(Trim(HD_MITDT.Text)) & "' "
    End If
    
    '得意先コード
    If Trim(HD_TOKCD.Text) <> "" Then
        strSQL = strSQL & "    and TOKCD   = '" & CF_Ora_String(Trim(HD_TOKCD.Text), 10) & "' "
    End If
    
    '見積件名
    If Trim(HD_KENNMA.Text) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'        strSQL = strSQL & "    and KENNMA  LIKE '%" & Trim(HD_KENNMA.Text) & "%' "
        strSQL = strSQL & "    and KENNMA  LIKE '%" & CF_Ora_String(Trim(HD_KENNMA.Text), CF_Ctr_AnsiLenB(Trim(HD_KENNMA.Text))) & "%' "
' === 20080929 === UPDATE E -
    End If
    
    strSQL = strSQL & "  Order By "
    strSQL = strSQL & "           MITNO "
    strSQL = strSQL & "         , MITNOV "
    
    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    Dyn_Open = True
    
    If CF_Ora_EOF(Usr_Ody) = True Then
        LST.Clear
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_DspNew
    '   概要：  リスト編集処理(初期情報)
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_DspNew()

    Dim Cnt             As Long
    
    Cnt = 0
    
    Do Until CF_Ora_EOF(Usr_Ody) = True
            
        '取得内容退避
        With DB_MITTHA_W
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                '見積番号
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")              '版数
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")            '受注取引区分
            .JDNTRKBNM = CF_Ora_GetDyn(Usr_Ody, "JDNTRKBNM", "")        '受注取引区分名
            
            '見積日
            If IsDate(Format(CF_Ora_GetDyn(Usr_Ody, "MITDT", ""), "@@@@/@@/@@")) = True Then
                .MITDT = Format(CF_Ora_GetDyn(Usr_Ody, "MITDT", ""), "@@@@/@@/@@")
            Else
                .MITDT = Space(10)
            End If
            
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                '得意先略称
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")              '件名１
            If CF_Ora_GetDyn(Usr_Ody, "KKTMTFL", "") = "1" Then
                .KKTMTFL = "確定"                                           '確定見積区分
            Else
                .KKTMTFL = "未確定"                                         '確定見積区分
            End If
        End With
        
        '表示改ページ
        If Cnt Mod WM_WLS_MAX = 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            Cnt = 0
            '最終ページ退避
            WM_WLS_LastPage = WM_WLS_Pagecnt
        End If

        '表示メモリ展開
        Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
        
        Cnt = Cnt + 1
        
        Call CF_Ora_MoveNext(Usr_Ody)
        
        If Cnt >= WM_WLS_MAX Then
            Exit Do
        End If
        
    Loop

    '最終データ到達
    If CF_Ora_EOF(Usr_Ody) = True Then
        WM_WLS_LastFL = True
    End If
    
    If Cnt > 0 Then
        'ページを表示
        Call WLS_DspPage
    End If

End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)

        With DB_MITTHA_W
            WM_WLS_DSPArray(ArrayCnt) = LeftWid$(.MITNO, 8) & "-" & _
                                        LeftWid$(.MITNOV, 2) & Space(1) & _
                                        LeftWid$(.JDNTRKBNM, 10) & Space(1) & _
                                        LeftWid$(.MITDT, 10) & Space(1) & _
                                        LeftWid$(.TOKRN, 30) & Space(1) & _
                                        LeftWid$(.KENNMA, 40) & Space(1) & _
                                        LeftWid$(.KKTMTFL, 6)
        End With
                                    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_DspPage
    '   概要：  リスト編集処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspPage()
        Dim WL_Mode As Integer
        Dim intCnt     As Integer

        LST.Clear

        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If
        
        intCnt = 0
        Do While intCnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
                LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)
            End If
            intCnt = intCnt + 1
        Loop
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            LST.SetFocus
        End If
    End Sub
    
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

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    'KEYRIGHT制御
    Call WLSMIT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '変数クリア
                    Call WLS_Clear
                    'リスト編集
                    Call Get_MITTHA
                    Call WLS_DspNew
                Case Else
            End Select
            'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
            Call WLSMIT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'            'ﾁｪｯｸ後移動あり
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
'
'    Dim Move_Flg        As Boolean
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Mode        As Integer
'
'    Move_Flg = False
'    Chk_Move_Flg = False
'
'    '各項目のﾁｪｯｸﾙｰﾁﾝ
'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
'
'    If Rtn_Chk = CHK_OK Then
'    'チェックＯＫ時
'        '取得内容表示
'        Dsp_Mode = DSP_SET
'    Else
'    'チェックＮＧ時
'        '取得内容クリア
'        Dsp_Mode = DSP_CLR
'    End If
'    '取得内容表示/クリア
'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
'
'    If Chk_Move_Flg = True Then
'    'ﾁｪｯｸ後移動あり
'        'KEYDOWN制御
'        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
'        If Move_Flg = True Then
'        '次の項目へ移動した場合
'            'ﾁｪｯｸ後移動あり
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        Else
'            '選択状態の設定（初期選択）
'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'
'            '項目色設定
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
'        End If
'    Else
'        'ﾁｪｯｸ後移動なし
'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'    End If

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
    Call WLSMIT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
            Call WLSMIT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'            'ﾁｪｯｸ後移動あり
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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

'    Dim Move_Flg        As Boolean
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Mode        As Integer
'
'    Move_Flg = False
'    Chk_Move_Flg = True
'
'    '各項目のﾁｪｯｸﾙｰﾁﾝ
'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
'
'    If Rtn_Chk = CHK_OK Then
'    'チェックＯＫ時
'        '取得内容表示
'        Dsp_Mode = DSP_SET
'    Else
'    'チェックＮＧ時
'        '取得内容クリア
'        Dsp_Mode = DSP_CLR
'    End If
'    '取得内容表示/クリア
'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
'
'    If Chk_Move_Flg = True Then
'    'ﾁｪｯｸ後移動あり
'        'KEYUP制御
'        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
'
'        If Move_Flg = True Then
'        '次の項目へ移動した場合
'            'ﾁｪｯｸ後移動あり
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        Else
'            '選択状態の設定（初期選択）
'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'
'            '項目色設定
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
'        End If
'
'    Else
'    'ﾁｪｯｸ後移動なし
'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'    End If

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
            Call WLSMIT0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

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
    Dim Dsp_Mode        As Integer

' === 20060902 === INSERT S - ACE)Nagasawa
    If gv_bolWLSMIT_LF_Enable = False Then
        Exit Function
    End If
' === 20060902 === INSERT E -

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
'        'ﾁｪｯｸ後移動あり
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

'@'        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
'@'        '選択状態の設定
'@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_DATE_SEL_KBN_DAY)
'@'        '項目色設定
'@'        Call CF_Set_Item_Color(Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS)

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
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
' === 20060801 === INSERT S - ACE)Nagasawa 検索画面表示ボタンを押したことが見えるようにする対応
    If TypeOf pm_Ctl Is SSCommand5 Then
        '検索画面呼出の場合は終了
        Exit Function
    End If
    
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
        '明細行コントロールか判定
        If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
            '明細検索ボタンの明細行数変数に同じ行数を設定
            For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                    '設定済みの場合は終了
                    Exit For
                End If
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
            Next
        End If
    Else
        '明細検索ボタンの明細行数変数を初期化
        For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
            If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                '設定済みの場合は終了
                Exit For
            End If
            Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
        Next
    End If
' === 20060801 === INSERT E
    
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Select Case Trg_Index
        Case Else
            '共通ﾌｫｰｶｽ取得処理
            Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End Select
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

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '共通KEYPRESS制御
    Call WLSMIT0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
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
        Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '変数クリア
                    Call WLS_Clear
                    'リスト編集
                    Call Get_MITTHA
                    Call WLS_DspNew
                Case Else
            End Select
            
            '現在ﾌｫｰｶｽ位置から右へ移動
            Call WLSMIT0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
'            'ﾁｪｯｸ後移動あり
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

'            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
'        '項目色設定(入力開始で色をﾌｫｰｶｽありの前景色＝黒に設定！！)
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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
    Call WLSMIT0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

' === 20061205 === INSERT S - ACE)Nagasawa VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061205 === INSERT E -

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)
            
    Select Case True
        Case TypeOf pm_Ctl Is TextBox
' === 20061024 === INSERT S - ACE)Nagasawa 文字列入力項目の途中までの選択を可能とする
            If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Typ <> IN_TYP_STR Then
' === 20061024 === INSERT E -
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
'            '項目色設定
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
' === 20061024 === INSERT S - ACE)Nagasawa 文字列入力項目の途中までの選択を可能とする
            End If
' === 20061024 === INSERT E -

        Case TypeOf pm_Ctl Is SSPanel5
            'パネルの場合
            Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060801 === INSERT S - ACE)Nagasawa　検索Wボタン対応
        Case TypeOf pm_Ctl Is SSCommand5
            'ボタンの場合
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(WLS_MTMET61.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060801 === INSERT E -

        Case TypeOf pm_Ctl Is Image
            'イメージの場合
            Select Case Trg_Index
                Case CInt(CM_PrevCm.Tag)
                '前頁ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                Case CInt(CM_NextCm.Tag)
                '次頁ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
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

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_PrevCm.Tag)
        '前頁ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)
        Case CInt(CM_NextCm.Tag)
        '次頁ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)
    End Select

    '共通MOUSEDOWN制御
    Call WLSMIT0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '各検索画面呼出
    Select Case Trg_Index
        Case CInt(CS_TANCD.Tag)
            '担当者検索画面呼出
            Call WLSMIT0001.F_Ctl_CS_TANCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_JDNTRKB.Tag)
            '受注取引区分検索画面呼出
            Call WLSMIT0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_MITDT.Tag)
            '見積日検索画面呼出
            Call WLSMIT0001.F_Ctl_CS_MITDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CS_TOKCD.Tag)
            '得意先検索画面呼出
            Call WLSMIT0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CM_PrevCm.Tag)
            '前頁
            Call Ctl_CM_PrevCm_Click
            
        Case CInt(CM_NextCm.Tag)
            '次頁
            Call Ctl_CM_NextCm_Click
            
        Case CInt(WLSOK.Tag)
            'OK
            Call Ctl_WLSOK_Click
            
        Case CInt(WLSCANCEL.Tag)
            'キャンセル
            Call Ctl_WLSCANCEL_Click
            
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CM_PrevCm_Click
    '   概要：  前ページ
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_PrevCm_Click() As Integer
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Call WLS_DspPage
    End If
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CM_NextCm_Click
    '   概要：  次ページ
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_NextCm_Click() As Integer

    If LST.ListCount <= 0 Then Exit Function
   
    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspNew
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_WLSOK_Click
    '   概要：  OKボタン押下時
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_WLSOK_Click() As Integer
        
        
    WLSMIT_RTNMITNO = MidWid$(LST.List(LST.ListIndex), 1, 8)
    WLSMIT_RTNMITNOV = MidWid$(LST.List(LST.ListIndex), 10, 2)
        
        Call Ctl_WLSCANCEL_Click
        
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_WLSCANCEL_Click
    '   概要：  キャンセルボタン押下時
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_WLSCANCEL_Click() As Integer

    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    Hide
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Copy_Click
    '   概要：  コピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目のコピー
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
    Call WLSMIT0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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
    Call WLSMIT0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)

    Select Case Me.ActiveControl.NAME
        Case HD_TANCD.NAME
            Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
            
        Case HD_JDNTRKB.NAME
            Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
    End Select
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
    
    '共通ﾌｫｰｶｽ取得処理
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

Private Sub Form_Activate()

'    '初期フォーカス位置設定
'    Call WLSMIT0001.F_Init_Cursor_Set(Main_Inf)
    
End Sub

Private Sub Form_Load()
    
    '画面情報設定
    Call Init_Def_Dsp
    
    '画面内容初期化
    Call WLSMIT0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def
    
    '画面表示位置設定
    Call CF_Set_Frm_Location(WLS_MTMET61)
    
End Sub

Private Sub CM_NextCm_Click()
    Debug.Print "CM_NextCm_Click"
    Call Ctl_Item_Click(CM_NextCm)
End Sub

Private Sub CM_PrevCm_Click()
    Debug.Print "CM_PrevCm_Click"
    Call Ctl_Item_Click(CM_PrevCm)
End Sub

Private Sub CM_NextCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NextCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
End Sub

Private Sub CM_PrevCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PrevCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
End Sub

Private Sub CM_NextCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NextCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
End Sub

Private Sub CM_PrevCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PrevCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
End Sub

Private Sub CS_TANCD_Click()
    Debug.Print "CS_TANCD_Click"
    Call Ctl_Item_Click(CS_TANCD)
End Sub

Private Sub CS_JDNTRKB_Click()
    Debug.Print "CS_JDNTRKB_Click"
    Call Ctl_Item_Click(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_Click()
    Debug.Print "CS_MITDT_Click"
    Call Ctl_Item_Click(CS_MITDT)
End Sub

Private Sub CS_TOKCD_Click()
    Debug.Print "CS_TOKCD_Click"
    Call Ctl_Item_Click(CS_TOKCD)
End Sub
Private Sub CS_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub CS_MITDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_MITDT_MouseUp"
    Call Ctl_Item_MouseUp(CS_MITDT, Button, Shift, X, Y)
End Sub

Private Sub CS_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TANCD, Button, Shift, X, Y)
End Sub

Private Sub CS_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub CS_JDNTRKB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_JDNTRKB_KeyUp"
    Call Ctl_Item_KeyUp(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_MITDT_KeyUp"
    Call Ctl_Item_KeyUp(CS_MITDT)
End Sub

Private Sub CS_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TANCD)
End Sub

Private Sub CS_TOKCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TOKCD)
End Sub

Private Sub CS_JDNTRKB_GotFocus()
    Debug.Print "CS_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_GotFocus()
    Debug.Print "CS_MITDT_GotFocus"
    Call Ctl_Item_GotFocus(CS_MITDT)
End Sub

Private Sub CS_TANCD_GotFocus()
    Debug.Print "CS_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TANCD)
End Sub

Private Sub CS_TOKCD_GotFocus()
    Debug.Print "CS_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TOKCD)
End Sub

Private Sub LST_DblClick()
    Debug.Print "LST_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, vbKeyReturn, 0)
End Sub

Private Sub LST_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "LST_KeyDown"
    Select Case KeyCode
        'Enterキー押下
        Case vbKeyReturn
            Call Ctl_Item_KeyDown(LST, KeyCode, Shift)
            
        'Escapeキー押下
        Case vbKeyEscape
            Call WLSCANCEL_Click
        
        '←キー押下
        Case vbKeyLeft
            Call CM_PrevCm_Click
            
        '→キー押下
        Case vbKeyRight
            Call CM_NextCm_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
    
End Sub

Private Sub WLSCANCEL_Click()
    Debug.Print "WLSCANCEL_Click"
    Call Ctl_Item_Click(WLSCANCEL)
End Sub

Private Sub WLSOK_Click()
    Debug.Print "WLSOK_Click"
    Call Ctl_Item_Click(WLSOK)
End Sub

Private Sub HD_JDNTRKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKBNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_KKTFL_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KKTFL_MouseDown"
    Call Ctl_Item_MouseDown(HD_KKTFL, Button, Shift, X, Y)
End Sub

Private Sub HD_MITDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITDT, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNOV_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKBNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_KKTFL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KKTFL_MouseUp"
    Call Ctl_Item_MouseUp(HD_KKTFL, Button, Shift, X, Y)
End Sub

Private Sub HD_MITDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITDT, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNOV_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKB_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKBNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKBNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKBNM, KeyCode, Shift)
End Sub

Private Sub HD_KENNMA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
End Sub

Private Sub HD_KKTFL_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KKTFL_KeyDown"
    Call Ctl_Item_KeyDown(HD_KKTFL, KeyCode, Shift)
End Sub

Private Sub HD_MITDT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITDT, KeyCode, Shift)
End Sub

Private Sub HD_MITNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNO, KeyCode, Shift)
End Sub

Private Sub HD_MITNOV_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNOV_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNOV, KeyCode, Shift)
End Sub

Private Sub HD_TANCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
End Sub

Private Sub HD_TANNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
End Sub

Private Sub HD_TOKCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRKB_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
End Sub

Private Sub HD_JDNTRKBNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRKBNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKBNM, KeyAscii)
End Sub

Private Sub HD_KENNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KENNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
End Sub

Private Sub HD_KKTFL_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KKTFL_KeyPress"
    Call Ctl_Item_KeyPress(HD_KKTFL, KeyAscii)
End Sub

Private Sub HD_MITDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITDT, KeyAscii)
End Sub

Private Sub HD_MITNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNO, KeyAscii)
End Sub

Private Sub HD_MITNOV_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNOV_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNOV, KeyAscii)
End Sub

Private Sub HD_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
End Sub

Private Sub HD_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_JDNTRKB_GotFocus()
    Debug.Print "HD_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_GotFocus()
    Debug.Print "HD_JDNTRKBNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_GotFocus()
    Debug.Print "HD_KENNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_GotFocus()
    Debug.Print "HD_KKTFL_GotFocus"
    Call Ctl_Item_GotFocus(HD_KKTFL)
End Sub

Private Sub HD_MITDT_GotFocus()
    Debug.Print "HD_MITDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITDT)
End Sub

Private Sub HD_MITNO_GotFocus()
    Debug.Print "HD_MITNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNO)
End Sub

Private Sub HD_MITNOV_GotFocus()
    Debug.Print "HD_MITNOV_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNOV)
End Sub

Private Sub HD_TANCD_GotFocus()
    Debug.Print "HD_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANCD)
End Sub

Private Sub HD_TANNM_GotFocus()
    Debug.Print "HD_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANNM)
End Sub

Private Sub HD_TOKCD_GotFocus()
    Debug.Print "HD_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKCD)
End Sub

Private Sub HD_JDNTRKB_LostFocus()
    Debug.Print "HD_JDNTRKB_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_LostFocus()
    Debug.Print "HD_JDNTRKBNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_LostFocus()
    Debug.Print "HD_KENNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_LostFocus()
    Debug.Print "HD_KKTFL_LostFocus"
    Call Ctl_Item_LostFocus(HD_KKTFL)
End Sub

Private Sub HD_MITDT_LostFocus()
    Debug.Print "HD_MITDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITDT)
End Sub

Private Sub HD_MITNO_LostFocus()
    Debug.Print "HD_MITNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNO)
End Sub

Private Sub HD_MITNOV_LostFocus()
    Debug.Print "HD_MITNOV_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNOV)
End Sub

Private Sub HD_TANCD_LostFocus()
    Debug.Print "HD_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANCD)
End Sub

Private Sub HD_TANNM_LostFocus()
    Debug.Print "HD_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANNM)
End Sub

Private Sub HD_TOKCD_LostFocus()
    Debug.Print "HD_TOKCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKCD)
End Sub

Private Sub HD_JDNTRKB_Change()
    Debug.Print "HD_JDNTRKB_Change"
    Call Ctl_Item_Change(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_Change()
    Debug.Print "HD_JDNTRKBNM_Change"
    Call Ctl_Item_Change(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_Change()
    Debug.Print "HD_KENNMA_Change"
    Call Ctl_Item_Change(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_Change()
    Debug.Print "HD_KKTFL_Change"
    Call Ctl_Item_Change(HD_KKTFL)
End Sub

Private Sub HD_MITDT_Change()
    Debug.Print "HD_MITDT_Change"
    Call Ctl_Item_Change(HD_MITDT)
End Sub

Private Sub HD_MITNO_Change()
    Debug.Print "HD_MITNO_Change"
    Call Ctl_Item_Change(HD_MITNO)
End Sub

Private Sub HD_MITNOV_Change()
    Debug.Print "HD_MITNOV_Change"
    Call Ctl_Item_Change(HD_MITNOV)
End Sub

Private Sub HD_TANCD_Change()
    Debug.Print "HD_TANCD_Change"
    Call Ctl_Item_Change(HD_TANCD)
End Sub

Private Sub HD_TANNM_Change()
    Debug.Print "HD_TANNM_Change"
    Call Ctl_Item_Change(HD_TANNM)
End Sub

Private Sub HD_TOKCD_Change()
    Debug.Print "HD_TOKCD_Change"
    Call Ctl_Item_Change(HD_TOKCD)
End Sub

' === 20060921 === INSERT S - ACE)Sejima
Private Sub WLSLABEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "WLSLABEL_MouseUp"
    Call Ctl_Item_MouseUp(WLSLABEL, Button, Shift, X, Y)
End Sub
' === 20060921 === INSERT E

' === 20060922 === INSERT S - ACE)Sejima
Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub
' === 20060922 === INSERT E

