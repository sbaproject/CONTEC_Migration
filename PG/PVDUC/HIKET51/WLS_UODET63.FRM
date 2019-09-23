VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_UODET63 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "受注伝票検索"
   ClientHeight    =   5775
   ClientLeft      =   165
   ClientTop       =   2355
   ClientWidth     =   13695
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   5775
   ScaleWidth      =   13695
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   330
      Left            =   45
      TabIndex        =   16
      Top             =   1185
      Width           =   13590
      _ExtentX        =   23971
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
      Caption         =   "受注番号  受注取区  受注日付   得意先                                   件名"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Height          =   3660
      ItemData        =   "WLS_UODET63.frx":0000
      Left            =   45
      List            =   "WLS_UODET63.frx":0043
      TabIndex        =   17
      Top             =   1485
      Width           =   13575
   End
   Begin VB.ListBox KEYBAK 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   5070
      Left            =   14700
      TabIndex        =   19
      Top             =   720
      Visible         =   0   'False
      Width           =   300
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   5820
      TabIndex        =   18
      Top             =   5310
      Width           =   1095
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   6900
      TabIndex        =   20
      Top             =   5310
      Width           =   1095
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1020
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   13710
      _ExtentX        =   24183
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
      Begin VB.TextBox HD_JDNTRKBNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   375
         Left            =   9750
         TabIndex        =   8
         Text            =   "MMMMMMMMM1"
         Top             =   60
         Width           =   1335
      End
      Begin VB.TextBox HD_TANNM 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   375
         Left            =   2415
         TabIndex        =   3
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   60
         Width           =   2490
      End
      Begin VB.TextBox HD_JDNTRKB 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   3  'ｵﾌ固定
         Left            =   9405
         TabIndex        =   7
         Text            =   "99"
         Top             =   60
         Width           =   360
      End
      Begin VB.TextBox HD_JDNDT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   3  'ｵﾌ固定
         Left            =   1605
         TabIndex        =   10
         Text            =   "9999/99/99"
         Top             =   540
         Width           =   1305
      End
      Begin VB.TextBox HD_KENNMA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   9405
         TabIndex        =   15
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM4"
         Top             =   540
         Width           =   4185
      End
      Begin VB.TextBox HD_TOKCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   6840
         TabIndex        =   13
         Text            =   "XXXX5"
         Top             =   540
         Width           =   705
      End
      Begin VB.TextBox HD_TANCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   3  'ｵﾌ固定
         Left            =   1605
         TabIndex        =   2
         Text            =   "XXXXX6"
         Top             =   60
         Width           =   825
      End
      Begin VB.TextBox HD_JDNNO 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   3  'ｵﾌ固定
         Left            =   6840
         TabIndex        =   5
         Text            =   "XXXXXXX8"
         Top             =   60
         Width           =   1050
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   0
         Left            =   5265
         TabIndex        =   4
         Top             =   60
         Width           =   1590
         _ExtentX        =   2805
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
         Caption         =   "開始受注番号"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   1
         Left            =   8265
         TabIndex        =   14
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
         Caption         =   "件名　　"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_TANCD 
         Height          =   375
         Left            =   135
         TabIndex        =   1
         TabStop         =   0   'False
         Top             =   60
         Width           =   1485
         _ExtentX        =   2619
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
      Begin Threed5.SSCommand5 CS_JDNDT 
         Height          =   375
         Left            =   135
         TabIndex        =   9
         TabStop         =   0   'False
         Top             =   540
         Width           =   1485
         _ExtentX        =   2619
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
         Caption         =   "受注日付   "
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_TOKCD 
         Height          =   375
         Left            =   5265
         TabIndex        =   12
         TabStop         =   0   'False
         Top             =   540
         Width           =   1590
         _ExtentX        =   2805
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
         Caption         =   "得意先       "
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_JDNTRKB 
         Height          =   375
         Left            =   8250
         TabIndex        =   6
         TabStop         =   0   'False
         Top             =   60
         Width           =   1170
         _ExtentX        =   2064
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
      Begin VB.Label Label2 
         Caption         =   "以降"
         Height          =   300
         Left            =   2970
         TabIndex        =   11
         Top             =   600
         Width           =   645
      End
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   5910
      Picture         =   "WLS_UODET63.frx":011F
      Top             =   7500
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   6810
      Picture         =   "WLS_UODET63.frx":0771
      Top             =   7500
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   7215
      Picture         =   "WLS_UODET63.frx":0DC3
      Top             =   7500
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   6315
      Picture         =   "WLS_UODET63.frx":1415
      Top             =   7500
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image CM_PrevCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   5280
      Picture         =   "WLS_UODET63.frx":1A67
      Top             =   5310
      Width           =   360
   End
   Begin VB.Image CM_NextCm 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   8160
      Picture         =   "WLS_UODET63.frx":20B9
      Top             =   5310
      Width           =   360
   End
End
Attribute VB_Name = "WLS_UODET63"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　検索ウィンドウ
'*  プログラム名　　：　受注情報検索
'*  プログラムＩＤ　：  WLS_UODET63
'*  作成者　　　　　：　ACE)古川
'*  作成日　　　　　：  2006.07.28
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************

'************************************************************************************
'   構造体
'************************************************************************************
    Private Type Type_DB_JDNTHA_W
        JDNNO       As String       '受注番号
        JDNTRKB     As String       '受注取引区分
        JDNTRKBNM   As String       '受注取引区分名
        JDNDT       As String       '受注伝票日付
        DENDT       As String       '受注日付
        TOKRN       As String       '得意先略称
        KENNMA      As String       '件名１
        KENNMB      As String       '件名２
    End Type
'************************************************************************************
'   Private定数
'************************************************************************************
    Private Const FM_PANEL3D1_CNT       As Integer = 2      'パネルコントロール数
    Private Const pc_intCntListRow      As Integer = 15     '明細行数

'************************************************************************************
'   Private変数
'************************************************************************************
'=== 当画面の全情報を格納 =================
    Private Main_Inf    As Cls_All
'=== 当画面の全情報を格納 =================

    Private pv_DB_JDNTHA_W          As Type_DB_JDNTHA_W
    
    Private Usr_Ody                 As U_Ody        'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private Dyn_Open                As Boolean      'ダイナセット状態（True:Open False:Close)
    Private pv_strInit_JDNTRKB      As String       '受注取引区分
    Private WM_WLS_MAX              As Integer      'リスト行数
    Private WM_WLS_Pagecnt          As Integer      'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage         As Integer      'ウィンド最終ページ
    Private WM_WLS_LastFL           As Boolean      'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()       As String       'ウィンド表示データ
    Private WM_WLS_Dspflg           As Integer      'ウィンド表示ﾌﾗｸﾞ(True or False)

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
'D        .Item_Cnt = 18                              '画面項目数
' === 20060921 === UPDATE ↓
        .Item_Cnt = 20                              '画面項目数
' === 20060921 === UPDATE E
        .Dsp_Body_Cnt = 0                           '画面表示明細数（０：明細なし、１～：表示時明細数）
        .Max_Body_Cnt = 0                           '最大表示明細数（０：明細なし、１～：最大明細数）
        .Body_Col_Cnt = 0                           '明細の列項目数
        .Dsp_Body_Move_Qty = 0                      '画面移動量
' === 20060920 === INSERT S - ACE)Hashiri  MsgBoxのDoEvents対応
        Set .FormCtl = WLS_UODET63
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
    '受注番号
    HD_JDNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20061127 === UPDATE S - ACE)Nagasawa コードの大文字変換処理追加
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20061127 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(6)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
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
    '受注取引区分
    HD_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
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
    '受注日ボタン
    CS_JDNDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNDT
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
    '受注日
    HD_JDNDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNDT
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
    '得意先(ｺｰﾄﾞ)ボタン
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
    '件名１
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

' === 20060922 === INSERT S - ACE)Sejima
    Index_Wk = Index_Wk + 1
    'ヘッダパネル
    Panel3D1.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Panel3D1
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
' === 20060922 === INSERT E
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
    WM_WLS_MAX = pc_intCntListRow
    
    '返り値の設定
    WLSJDN_RTNJDNNO = ""
    
    '受注取引区分の初期値設定
    pv_strInit_JDNTRKB = Trim(WLSJDN_JDNTRKB)

'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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

' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    'KEYRIGHT制御
    Call WLSJDN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSJDN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call WLSJDN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '変数クリア
                    Call WLS_Clear
                    'リスト編集
                    Call F_Get_JDNTHA
                    Call WLS_DspNew
                Case Else
            End Select
            'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
            Call WLSJDN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
    Call WLSJDN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSJDN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call WLSJDN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
            Call WLSJDN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
            Call WLSJDN0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

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
    If gv_bolWLSJDN_LF_Enable = False Then
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
    Rtn_Chk = WLSJDN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call WLSJDN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
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
            Call WLSJDN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End Select
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
    '各検索画面呼出
'    Select Case Trg_Index
'        Case CInt(HD_AKNID.Tag)
'            '案件IDのﾃｷｽﾄへﾌｫｰｶｽ移動

'    End Select
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
    
' === 20061116 === INSERT S - ACE)Yano VBエラー発生対応
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '共通KEYPRESS制御
    Call WLSJDN0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = WLSJDN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
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
        Call WLSJDN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '変数クリア
                    Call WLS_Clear
                    'リスト編集
                    Call F_Get_JDNTHA
                    Call WLS_DspNew
                Case Else
            End Select
            
            '現在ﾌｫｰｶｽ位置から右へ移動
            Call WLSJDN0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
    Call WLSJDN0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
            Call WLSJDN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060801 === INSERT S - ACE)Nagasawa　検索Wボタン対応
        Case TypeOf pm_Ctl Is SSCommand5
            'ボタンの場合
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(WLS_UODET63.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call WLSJDN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060801 === INSERT E

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
    Call WLSJDN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
            Call WLSJDN0001.F_Ctl_CS_TANCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_JDNTRKB.Tag)
            '受注取引区分検索画面呼出
            Call WLSJDN0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CS_JDNDT.Tag)
            '日付検索画面呼出
            Call WLSJDN0001.F_Ctl_CS_JDNDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CS_TOKCD.Tag)
            '得意先検索画面呼出
            Call WLSJDN0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
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

Private Sub Form_Load()
    
    '画面情報設定
    Call Init_Def_Dsp
    
    '画面内容初期化
    Call WLSJDN0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def
    
    '画面表示位置設定
    Call CF_Set_Frm_Location(WLS_UODET63)
    
End Sub

Private Sub HD_TANCD_Change()
    Debug.Print Me.NAME & ".HD_TANCD_Change"
    Call Ctl_Item_Change(HD_TANCD)
End Sub

Private Sub HD_TANCD_GotFocus()
    Debug.Print Me.NAME & ".HD_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANCD)
End Sub

Private Sub HD_TANCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
End Sub

Private Sub HD_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
End Sub

Private Sub HD_TANCD_LostFocus()
    Debug.Print Me.NAME & ".HD_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANCD)
End Sub

Private Sub HD_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_Change()
    Debug.Print Me.NAME & ".HD_TANNM_Change"
    Call Ctl_Item_Change(HD_TANNM)
End Sub

Private Sub HD_TANNM_GotFocus()
    Debug.Print Me.NAME & ".HD_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANNM)
End Sub

Private Sub HD_TANNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
End Sub

Private Sub HD_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
End Sub

Private Sub HD_TANNM_LostFocus()
    Debug.Print Me.NAME & ".HD_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANNM)
End Sub

Private Sub HD_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNNO_Change()
    Debug.Print Me.NAME & ".HD_JDNNO_Change"
    Call Ctl_Item_Change(HD_JDNNO)
End Sub

Private Sub HD_JDNNO_GotFocus()
    Debug.Print Me.NAME & ".HD_JDNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNNO)
End Sub

Private Sub HD_JDNNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_JDNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNNO, KeyCode, Shift)
End Sub

Private Sub HD_JDNNO_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_JDNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNNO, KeyAscii)
End Sub

Private Sub HD_JDNNO_LostFocus()
    Debug.Print Me.NAME & ".HD_JDNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNNO)
End Sub

Private Sub HD_JDNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNNO, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNNO, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_Change()
    Debug.Print Me.NAME & ".HD_JDNTRKB_Change"
    Call Ctl_Item_Change(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKB_GotFocus()
    Debug.Print Me.NAME & ".HD_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_JDNTRKB_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKB_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_JDNTRKB_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
End Sub

Private Sub HD_JDNTRKB_LostFocus()
    Debug.Print Me.NAME & ".HD_JDNTRKB_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNTRKB_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_Change()
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_Change"
    Call Ctl_Item_Change(HD_JDNTRKBNM)
End Sub

Private Sub HD_JDNTRKBNM_GotFocus()
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_JDNTRKBNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKBNM, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKBNM_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKBNM, KeyAscii)
End Sub

Private Sub HD_JDNTRKBNM_LostFocus()
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_JDNTRKBNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNDT_Change()
    Debug.Print Me.NAME & ".HD_JDNDT_Change"
    Call Ctl_Item_Change(HD_JDNDT)
End Sub

Private Sub HD_JDNDT_GotFocus()
    Debug.Print Me.NAME & ".HD_JDNDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNDT)
End Sub

Private Sub HD_JDNDT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_JDNDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNDT, KeyCode, Shift)
End Sub

Private Sub HD_JDNDT_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_JDNDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNDT, KeyAscii)
End Sub

Private Sub HD_JDNDT_LostFocus()
    Debug.Print Me.NAME & ".HD_JDNDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNDT)
End Sub

Private Sub HD_JDNDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNDT, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_JDNDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNDT, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_Change()
    Debug.Print Me.NAME & ".HD_TOKCD_Change"
    Call Ctl_Item_Change(HD_TOKCD)
End Sub

Private Sub HD_TOKCD_GotFocus()
    Debug.Print Me.NAME & ".HD_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKCD)
End Sub

Private Sub HD_TOKCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_TOKCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_TOKCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_TOKCD_LostFocus()
    Debug.Print Me.NAME & ".HD_TOKCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKCD)
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TOKCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_Change()
    Debug.Print Me.NAME & ".HD_KENNMA_Change"
    Call Ctl_Item_Change(HD_KENNMA)
End Sub

Private Sub HD_KENNMA_GotFocus()
    Debug.Print Me.NAME & ".HD_KENNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_KENNMA)
End Sub

Private Sub HD_KENNMA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".HD_KENNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
End Sub

Private Sub HD_KENNMA_KeyPress(KeyAscii As Integer)
    Debug.Print Me.NAME & ".HD_KENNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
End Sub

Private Sub HD_KENNMA_LostFocus()
    Debug.Print Me.NAME & ".HD_KENNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_KENNMA)
End Sub

Private Sub HD_KENNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_KENNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".HD_KENNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
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

Private Sub CS_TANCD_Click()
    Debug.Print Me.NAME & ".CS_TANCD_Click"
    Call Ctl_Item_Click(CS_TANCD)
End Sub

Private Sub CS_TANCD_GotFocus()
    Debug.Print Me.NAME & ".CS_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TANCD)
End Sub

Private Sub CS_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".CS_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TANCD)
End Sub

Private Sub CS_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".CS_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TANCD, Button, Shift, X, Y)
End Sub

Private Sub CS_JDNTRKB_Click()
    Debug.Print Me.NAME & ".CS_JDNTRKB_Click"
    Call Ctl_Item_Click(CS_JDNTRKB)
End Sub

Private Sub CS_JDNTRKB_GotFocus()
    Debug.Print Me.NAME & ".CS_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(CS_JDNTRKB)
End Sub

Private Sub CS_JDNTRKB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".CS_JDNTRKB_KeyUp"
    Call Ctl_Item_KeyUp(CS_JDNTRKB)
End Sub

Private Sub CS_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".CS_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub CS_JDNDT_Click()
    Debug.Print Me.NAME & ".CS_JDNDT_Click"
    Call Ctl_Item_Click(CS_JDNDT)
End Sub

Private Sub CS_JDNDT_GotFocus()
    Debug.Print Me.NAME & ".CS_JDNDT_GotFocus"
    Call Ctl_Item_GotFocus(CS_JDNDT)
End Sub

Private Sub CS_JDNDT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".CS_JDNDT_KeyUp"
    Call Ctl_Item_KeyUp(CS_JDNDT)
End Sub

Private Sub CS_JDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".CS_JDNDT_MouseUp"
    Call Ctl_Item_MouseUp(CS_JDNDT, Button, Shift, X, Y)
End Sub

Private Sub CS_TOKCD_Click()
    Debug.Print Me.NAME & ".CS_TOKCD_Click"
    Call Ctl_Item_Click(CS_TOKCD)
End Sub

Private Sub CS_TOKCD_GotFocus()
    Debug.Print Me.NAME & ".CS_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TOKCD)
End Sub

Private Sub CS_TOKCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print Me.NAME & ".CS_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TOKCD)
End Sub

Private Sub CS_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print Me.NAME & ".CS_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub WLSCANCEL_Click()
    Debug.Print "WLSCANCEL_Click"
    Call Ctl_Item_Click(WLSCANCEL)
End Sub

Private Sub WLSOK_Click()
    Debug.Print "WLSOK_Click"
    Call Ctl_Item_Click(WLSOK)
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

' === 20060921 === INSERT S - ACE)Sejima
Private Sub WLSLABEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "WLSLABEL_MouseUp"
    Call Ctl_Item_MouseUp(WLSLABEL, Button, Shift, X, Y)
End Sub
' === 20060921 === INSERT E
    
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
        'すべての取得データを退避していない場合は退避処理実行
        If Not WM_WLS_LastFL Then Call WLS_DspNew
    Else
        '退避している場合はページ数アップ
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Edi_Dsp_Def
    '   概要：  初期時の画面編集
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Edi_Dsp_Def() As Integer
    Dim Index_Wk        As Integer
    Dim Mst_Inf         As TYPE_DB_MEIMTA

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'WLSJDN0001.F_Init_Clr_Dsp で初期化処理を実行済み
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_WLSOK_Click
    '   概要：  OKボタン押下時
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_WLSOK_Click() As Integer
        
    '戻り値を設定
    WLSJDN_RTNJDNNO = MidWid$(LST.List(LST.ListIndex), 1, 8)
        
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

    '画面を表示するときに戻り値変数は初期化されている
    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    Hide
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
    Rtn_Chk = WLSJDN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
    Call WLSJDN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then

        Select Case Me.ActiveControl.NAME
            Case HD_TANCD.NAME, HD_JDNNO.NAME, HD_JDNTRKB.NAME, _
                 HD_JDNDT.NAME, HD_TOKCD.NAME, HD_KENNMA.NAME
                '変数クリア
                Call WLS_Clear
                'リスト編集
                Call F_Get_JDNTHA
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
    '   名称：  Sub WLS_DspNew
    '   概要：  リスト編集処理(初期情報)
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_DspNew()

    Dim Cnt             As Long
    Dim strWORK         As String
    
    Cnt = 0
    
    Do Until CF_Ora_EOF(Usr_Ody) = True

        '取得内容退避
        With pv_DB_JDNTHA_W
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNNO", "")                '受注番号
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNTRKB", "")            '受注取引区分
            .JDNTRKBNM = CF_Ora_GetDyn(Usr_Ody, "MEIMTA_JDNTRKBNM", "")        '受注取引区分名
            
            strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNDT", "")               '受注伝票日付
            .JDNDT = Format(strWORK, "@@@@/@@/@@")
            
            strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_DENDT", "")               '受注日付
            .DENDT = Format(strWORK, "@@@@/@@/@@")
            
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMA", "")              '件名１
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMB", "")              '件名２
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKMTA_TOKRN", "")                '得意先略称
        End With
        
        '表示改ページ
        If Cnt Mod WM_WLS_MAX = 0 Then
            'ウィンド表示ページカウンタをカウントアップ
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            'ウィンド表示データ領域をリスト行数分作成
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

    '表示データ有無チェック
    If UBound(WM_WLS_DSPArray) <= 0 Then
        Exit Sub
    End If
    
    intCnt = 0
    '明細行数分ループ
    Do While intCnt < WM_WLS_MAX
        'WM_WLS_Pagecnt = ページ数 - 1 が設定されている
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
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)

    With pv_DB_JDNTHA_W
' === 20070223 === UPDATE S - ACE)Nagasawa 受注日付関連修正
'        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(.JDNNO, 8) & Space(1) & _
'                                    LeftWid$(.JDNTRKBNM, 10) & Space(1) & _
'                                    LeftWid$(.JDNDT, 10) & Space(1) & _
'                                    LeftWid$(.TOKRN, 40) & Space(1) & _
'                                    LeftWid$(Trim(.KENNMA) & Trim(.KENNMB), 40)
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(.JDNNO, 8) & Space(1) & _
                                    LeftWid$(.JDNTRKBNM, 10) & Space(1) & _
                                    LeftWid$(.DENDT, 10) & Space(1) & _
                                    LeftWid$(.TOKRN, 40) & Space(1) & _
                                    LeftWid$(Trim(.KENNMA) & Trim(.KENNMB), 40)
' === 20070223 === UPDATE E -
    End With
                                
End Sub

Private Function F_Get_JDNTHA() As Integer

    Dim intRet          As Integer
    Dim strSQL          As String
    Dim strTANCD        As String
    Dim strJdnNo        As String
    Dim strJDNTRKB      As String
    Dim strJDNDT        As String
    Dim strTOKCD        As String
    Dim strKENNMA       As String

    On Error GoTo F_Get_JDNTHA_Err

    intRet = 99
    
    '営業担当者コードを画面から取得
    strTANCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_TANCD.Tag))
    
    '受注番号を画面から取得
    strJdnNo = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_JDNNO.Tag))
    
    '受注取引区分を画面から取得
    strJDNTRKB = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_JDNTRKB.Tag))
    
    '受注日付を画面から取得
    strJDNDT = CF_Ora_Date(CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_JDNDT.Tag)))
    
    '得意先コードを画面から取得
    strTOKCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_TOKCD.Tag))
    
    '件名を画面から取得
    strKENNMA = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(HD_KENNMA.Tag))
    
    strSQL = ""
    strSQL = strSQL & " SELECT "
    strSQL = strSQL & "  JDNTHA.JDNNO   AS JDNTHA_JDNNO"        '受注番号
    strSQL = strSQL & ", JDNTHA.JDNDT   AS JDNTHA_JDNDT"        '受注伝票日付
    strSQL = strSQL & ", JDNTHA.DENDT   AS JDNTHA_DENDT"        '受注日付
    strSQL = strSQL & ", JDNTHA.JDNTRKB AS JDNTHA_JDNTRKB"      '受注取引区分
    strSQL = strSQL & ", JDNTHA.KENNMA  AS JDNTHA_KENNMA"       '件名１
    strSQL = strSQL & ", JDNTHA.KENNMB  AS JDNTHA_KENNMB"       '件名２
    strSQL = strSQL & ", TOKMTA.TOKRN   AS TOKMTA_TOKRN"        '得意先略称
    strSQL = strSQL & ", MEIMTA.MEINMA  AS MEIMTA_JDNTRKBNM"    '受注取引区分名称
' === 20061109 === UPDATE S - ACE)Nagasawa レスポンス対応
'' === 20060906 === UPDATE S - ACE)Nagasawa 赤黒対応
''    strSQL = strSQL & " FROM JDNTHA"
'    strSQL = strSQL & " FROM JDNTHV JDNTHA"
'' === 20060906 === UPDATE E -
    strSQL = strSQL & " FROM JDNTHA "
    strSQL = strSQL & " ,    (SELECT MAX(DATNO) AS MAX_DATNO "
    strSQL = strSQL & "         FROM JDNTHA "
    strSQL = strSQL & "        WHERE DATKB = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "        GROUP BY JDNNO ) THA_SUB "
' === 20061109 === UPDATE E -
    strSQL = strSQL & ",     TOKMTA"
    strSQL = strSQL & ",     MEIMTA"
' === 20061109 === UPDATE S - ACE)Nagasawa レスポンス対応
'    strSQL = strSQL & " WHERE JDNTHA.TOKCD     = TOKMTA.TOKCD (+)"
    strSQL = strSQL & " WHERE JDNTHA.DATNO     = THA_SUB.MAX_DATNO "
    strSQL = strSQL & " AND   JDNTHA.AKAKROKB  = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & " AND   JDNTHA.TOKCD     = TOKMTA.TOKCD (+)"
' === 20061109 === UPDATE E -
    strSQL = strSQL & " AND   JDNTHA.JDNTRKB   = MEIMTA.MEICDA (+)"
    strSQL = strSQL & " AND   JDNTHA.DATKB     = '" & gc_strDATKB_USE & "'"
    strSQL = strSQL & " AND   TOKMTA.DATKB (+) = '" & gc_strDATKB_USE & "'"
    strSQL = strSQL & " AND   MEIMTA.DATKB (+) = '" & gc_strDATKB_USE & "'"
    strSQL = strSQL & " AND   MEIMTA.KEYCD (+) = '" & gc_strKEYCD_JDNTRKB & "'"
    
' === 20060930 === INSERT S - ACE)Nagasawa 海外対応
    If Trim(WLSJDN_FRNB) <> "" Then
        strSQL = strSQL & " AND   JDNTHA.FRNKB   = '" & CF_Ora_String(WLSJDN_FRNB, 1) & "' "
    End If
' === 20060930 === INSERT E -
    
    '営業担当者コード
    If Trim(strTANCD) <> "" Then
        strSQL = strSQL & " AND JDNTHA.TANCD   = '" & CF_Ora_String(strTANCD, 6) & "'"
    End If
    
    '受注番号
    If Trim(strJdnNo) <> "" Then
        strSQL = strSQL & " AND JDNTHA.JDNNO  >= '" & CF_Ora_String(strJdnNo, 10) & "'"
    End If
    
    '受注取引区分
    If Trim(strJDNTRKB) <> "" Then
        strSQL = strSQL & " AND JDNTHA.JDNTRKB = '" & CF_Ora_String(strJDNTRKB, 2) & "'"
    End If
    
    '受注日付
    If Trim(strJDNDT) <> "" Then
' === 20070223 === UPDATE S - ACE)Nagasawa 受注日付関連修正
'        strSQL = strSQL & " AND JDNTHA.JDNDT  >= '" & CF_Ora_String(strJDNDT, 8) & "'"
        strSQL = strSQL & " AND JDNTHA.DENDT  >= '" & CF_Ora_String(strJDNDT, 8) & "'"
' === 20070223 === UPDATE E -
    End If
    
    '得意先コード
    If Trim(strTOKCD) <> "" Then
        strSQL = strSQL & " AND JDNTHA.TOKCD   = '" & CF_Ora_String(strTOKCD, 10) & "'"
    End If
    
    '件名
    If Trim(strKENNMA) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'        strSQL = strSQL & " AND JDNTHA.KENNMA || JDNTHA.KENNMB LIKE '%" & Trim(strKENNMA) & "%'"
        strSQL = strSQL & " AND JDNTHA.KENNMA || JDNTHA.KENNMB LIKE '%" & CF_Ora_String(Trim(strKENNMA), CF_Ctr_AnsiLenB(Trim(strKENNMA))) & "%'"
' === 20080929 === UPDATE E -
    End If

    strSQL = strSQL & " ORDER BY "
    strSQL = strSQL & "  JDNTHA_JDNNO"

    If Dyn_Open = True Then
        'オープンしていたらクローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    Dyn_Open = True
    
    If CF_Ora_EOF(Usr_Ody) = True Then
        LST.Clear
    End If

    intRet = 0

F_Get_JDNTHA_End:

    F_Get_JDNTHA = intRet
    Exit Function

F_Get_JDNTHA_Err:

    intRet = 99
    GoTo F_Get_JDNTHA_End

End Function

' === 20060922 === INSERT S - ACE)Sejima
Private Sub Panel3D1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(Panel3D1, Button, Shift, X, Y)
End Sub
' === 20060922 === INSERT E

