VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSHIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "製品検索"
   ClientHeight    =   6030
   ClientLeft      =   1920
   ClientTop       =   2370
   ClientWidth     =   11310
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
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   6030
   ScaleWidth      =   11310
   Begin VB.TextBox HD_HINKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   1695
      MaxLength       =   1
      TabIndex        =   2
      Text            =   "9"
      Top             =   105
      Width           =   270
   End
   Begin VB.TextBox HD_CODE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   1680
      MaxLength       =   10
      TabIndex        =   9
      Text            =   "XXXXXXXX10"
      Top             =   540
      Width           =   1335
   End
   Begin VB.TextBox HD_KATA 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   4920
      MaxLength       =   30
      TabIndex        =   5
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   105
      Width           =   3690
   End
   Begin VB.ComboBox WLSKANA 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   360
      Left            =   10050
      Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
      TabIndex        =   7
      Top             =   105
      Width           =   1230
   End
   Begin VB.TextBox HD_HINKBNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   1950
      MaxLength       =   16
      TabIndex        =   3
      TabStop         =   0   'False
      Text            =   "MMMMMMMM1MMMM16"
      Top             =   105
      Width           =   1920
   End
   Begin Threed5.SSPanel5 Panel3D4 
      Height          =   375
      Left            =   105
      TabIndex        =   8
      Top             =   540
      Width           =   1590
      _ExtentX        =   2805
      _ExtentY        =   661
      BackColor       =   12632256
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
      Caption         =   "開始製品ｺｰﾄﾞ"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 SSPanel51 
      Height          =   375
      Left            =   4110
      TabIndex        =   4
      Top             =   105
      Width           =   825
      _ExtentX        =   1455
      _ExtentY        =   661
      BackColor       =   12632256
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
      Caption         =   "型式"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 PNL_USENM 
      Height          =   375
      Index           =   3
      Left            =   8820
      TabIndex        =   6
      Top             =   105
      Width           =   1230
      _ExtentX        =   2170
      _ExtentY        =   661
      BackColor       =   12632256
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
      Caption         =   "カナ検索"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_HINKB 
      Height          =   375
      Left            =   105
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   105
      Width           =   1590
      _ExtentX        =   2805
      _ExtentY        =   661
      BackColor       =   12632256
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
      Caption         =   "商品区分   "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   10
      Top             =   1440
      Width           =   11220
      _ExtentX        =   19791
      _ExtentY        =   661
      BackColor       =   12632256
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
      Caption         =   "製品ｺｰﾄﾞ    型    式                        品    名"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      ItemData        =   "WLS_HIN2_HIN10.frx":0000
      Left            =   45
      List            =   "WLS_HIN2_HIN10.frx":0007
      TabIndex        =   11
      Top             =   1800
      Width           =   11220
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   4726
      TabIndex        =   12
      Top             =   5535
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   5656
      TabIndex        =   13
      Top             =   5535
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1005
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   11505
      _ExtentX        =   20294
      _ExtentY        =   1773
      BackColor       =   12632256
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
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4455
      Picture         =   "WLS_HIN2_HIN10.frx":0069
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   5355
      Picture         =   "WLS_HIN2_HIN10.frx":06BB
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5760
      Picture         =   "WLS_HIN2_HIN10.frx":0D0D
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4860
      Picture         =   "WLS_HIN2_HIN10.frx":135F
      Top             =   6300
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4238
      Picture         =   "WLS_HIN2_HIN10.frx":19B1
      Top             =   5535
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   6713
      Picture         =   "WLS_HIN2_HIN10.frx":2003
      Top             =   5535
      Width           =   360
   End
End
Attribute VB_Name = "WLSHIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　製品検索
    '*  プログラムＩＤ　：  WLSSHIN
    '*  作成者　　　　　：　ACE)長澤
    '*  作成日　　　　　：  2006.05.12
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************
    
'************************************************************************************
'   Private定数
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]

'************************************************************************************
'   Private変数
'************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MFIL         As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_CODELEN      As Integer          '開始製品ｺｰﾄﾞ入力文字数
    Private WM_WLS_HINNMALEN    As Integer          '型式入力文字数
    Private WM_WLS_HINNMBLEN    As Integer          '品名表示文字数
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
    Private WM_WLS_HINKBLEN     As Integer          '商品区分文字数
    Private WM_WLS_HINKBNMLEN   As Integer          '商品区分名文字数
' === 20061205 === INSERT E -

    'ウィンド内部使用変数
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_CODE         As String           '製品コード検索用
    Private WM_WLS_HINNMA       As String           '型式検索用
    Private WM_WLS_HINNK_S      As String           '商品名カナ検索用(開始)
    Private WM_WLS_HINNK_E      As String           '商品名カナ検索用(終了)
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
    Private WM_WLS_HINKB        As String           '商品区分
' === 20061205 === INSERT E -
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_HINMTA_W         As TYPE_DB_HINMTA
    Private Dyn_Open            As Boolean          'ダイナセット状態（True:Open False:Close)
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
    Private bolInitWindow       As Boolean          '画面初期化フラグ(True:初期化)
' === 20061205 === INSERT E -
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
        '=== 表示開始コード桁数設定 ===
'''' UPD 2009/02/19  FKS) S.Nakajima    Start
'        WM_WLS_CODELEN = 8
        WM_WLS_CODELEN = 10
'''' UPD 2009/02/19  FKS) S.Nakajima    End
        WM_WLS_HINNMALEN = 30
' === 20060902 === UPDATE S - ACE)Nagasawa
'        WM_WLS_HINNMBLEN = 30
        WM_WLS_HINNMBLEN = 50
' === 20060902 === UPDATE E -
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
        WM_WLS_HINKBLEN = 1
        WM_WLS_HINKBNMLEN = 6
' === 20061205 === INSERT E -
        WM_WLS_MAX = 15                 '画面表示件数
        
        '変数初期化
        WLSHIN_RTNCODE = ""
        Call WLS_Clear
        Dyn_Open = False

    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)

        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_HINMTA_W.HINCD, WM_WLS_CODELEN) & Space(2) & _
                                    LeftWid$(DB_HINMTA_W.HINNMA, WM_WLS_HINNMALEN) & Space(2) & _
                                    LeftWid$(DB_HINMTA_W.HINNMB, WM_WLS_HINNMBLEN)
                                    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_TextSQL
    '   概要：  検索sql作成
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_TextSQL()

        Dim strSQL          As String
        Dim intData         As Integer

        strSQL = ""
' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
'D        strSQL = strSQL & " Select HINCD "          '製品コード
        strSQL = strSQL & " Select "

        'ヒント句の編集
        Select Case True
            '入力検索条件がない場合、主キー検索
            Case Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNMA) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
                If Trim(WLSHIN_SKHINGRP) <> "" Then
                    strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA07) */ "
                Else
                    strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
                End If
            'カナが指定されている場合、キー０２で検索
            Case Trim(WM_WLS_HINNK_S) <> ""
                strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA02) */ "

            '開始製品コードが指定されている場合、主キーで検索
            Case Trim(WM_WLS_CODE) <> ""
                strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "

            '型式が１文字のみでの場合は主キーで検索
            Case Len(Trim(WM_WLS_HINNMA)) = 1 _
             And Trim(WM_WLS_CODE) & Trim(WM_WLS_HINNK_S) & Trim(WM_WLS_HINKB) = ""
                strSQL = strSQL & "        /*+ INDEX (HINMTA X_HINMTA01) */ "
            
            '上記以外の場合は編集なし（キー０６が使用される？？）
            Case Else

        End Select

        strSQL = strSQL & "        HINCD "          '製品コード
' === 20081205 === UPDATE E - ACE)Nagasawa
        strSQL = strSQL & "      , HINNMA "         '型式
        strSQL = strSQL & "      , HINNMB "         '商品名
' === 20060726 === INSERT S - ACE)Nagasawa
        strSQL = strSQL & "      , HINNK "          '商品名カナ
' === 20060726 === INSERT E -
        strSQL = strSQL & "   from HINMTA "
        strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
'        strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
'        strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
'        strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "

        '製品コード検索
        If Trim(WM_WLS_CODE) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
            strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
' === 20080929 === UPDATE E -
        End If

        '型式検索(あいまい検索)
        If Trim(WM_WLS_HINNMA) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
            strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
' === 20080929 === UPDATE E -
        End If

        '商品名カナ検索
        If Trim(WM_WLS_HINNK_S) <> "" Then
            strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
        End If

' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
        '商品区分検索
        If Trim(WM_WLS_HINKB) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
            strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
' === 20080929 === UPDATE E -
        End If
' === 20061205 === INSERT E -

' === 20061026 === INSERT S - FKS)KUMEDA
        If Trim(WLSHIN_SKHINGRP) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and SKHINGRP = '" & WLSHIN_SKHINGRP & "' "
            strSQL = strSQL & "    and SKHINGRP = '" & CF_Ora_String(WLSHIN_SKHINGRP, CF_Ctr_AnsiLenB(WLSHIN_SKHINGRP)) & "' "
' === 20080929 === UPDATE E -
        End If
' === 20061026 === INSERT E

' === 20060828 === INSERT S - ACE)Sejima 仮本区分対応
' === 20060829 === UPDATE S - ACE)Nagasawa
'        '仮本区分検索（※画面入力項目でない）
'        If Trim(WLSHIN_KHNKB) <> "" Then
'            strSQL = strSQL & "    and KHNKB = '" & WLSHIN_KHNKB & "'"
'        End If
        
        '本製品のみ検索（※画面入力項目でない）
        If Trim(WLSHIN_KHNSEARCH) <> "1" Then
            strSQL = strSQL & "    and KHNKB = '" & gc_strKHNKB_HON & "'"
        End If
        
' === 20060829 === UPDATE E -
' === 20060828 === INSERT E
        
        'セットアップ受注登録、訂正は部品商品マスタも合わせて検索
        If Trim(WLSHIN_BHNSEARCH) = "1" Then
            strSQL = strSQL & " union "          '製品コード
            strSQL = strSQL & " Select HINCD "          '製品コード
            strSQL = strSQL & "      , HINNMA "         '型式
            strSQL = strSQL & "      , HINNMB "         '商品名
' === 20060726 === INSERT S - ACE)Nagasawa
            strSQL = strSQL & "      , HINNK "          '商品名カナ
' === 20060726 === INSERT E -
            strSQL = strSQL & "   from BHNMTA "
            strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and DSPKB    = '" & gc_strDSPKB_OK & "' "
            strSQL = strSQL & "    and MNTENDKB = '" & gc_strMNTENDKB_NML & "' "
            strSQL = strSQL & "    and SLENDKB  = '" & gc_strSLENDKB_NML & "' "
            strSQL = strSQL & "    and JODSTPKB = '" & gc_strJODSTPKB_NML & "' "
    
            '製品コード検索
            If Trim(WM_WLS_CODE) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'                strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
                strSQL = strSQL & "    and HINCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
' === 20080929 === UPDATE E -
            End If
    
            '型式検索(あいまい検索)
            If Trim(WM_WLS_HINNMA) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'                strSQL = strSQL & "    and HINNMA LIKE '%" & WM_WLS_HINNMA & "%'"
                strSQL = strSQL & "    and HINNMA LIKE '%" & CF_Ora_String(WM_WLS_HINNMA, CF_Ctr_AnsiLenB(WM_WLS_HINNMA)) & "%'"
' === 20080929 === UPDATE E -
            End If
    
            '商品名カナ検索
            If Trim(WM_WLS_HINNK_S) <> "" Then
                strSQL = strSQL & "    and HINNK >= '" & WM_WLS_HINNK_S & "' And HINNK < '" & WM_WLS_HINNK_E & "'"
            End If
            
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
            '商品区分検索
            If Trim(WM_WLS_HINKB) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'                strSQL = strSQL & "    and HINKB  = '" & WM_WLS_HINKB & "' "
                strSQL = strSQL & "    and HINKB  = '" & CF_Ora_String(WM_WLS_HINKB, CF_Ctr_AnsiLenB(WM_WLS_HINKB)) & "' "
' === 20080929 === UPDATE E -
            End If
' === 20061205 === INSERT E -

        End If
        'ソート条件
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_HINNK_S) <> "" Then
        '商品名カナ検索の場合
            strSQL = strSQL & "   HINNK "
            strSQL = strSQL & "  ,HINCD "
        Else
        '製品コード検索,型式検索
            strSQL = strSQL & "   HINCD "
        End If

        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dyn_Open = True
' === 20060726 === INSERT S - ACE)Nagasawa
        LST.Clear
' === 20060726 === INSERT E -

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
    
    Cnt = 0
    Do Until CF_Ora_EOF(Usr_Ody) = True
        
        '取得内容退避
        DB_HINMTA_W.HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")              '製品コード
        DB_HINMTA_W.HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")             '型式
        DB_HINMTA_W.HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")             '商品名
        
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
    '   名称：  Sub WLS_DspPage
    '   概要：  リスト編集処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspPage()
        Dim WL_Mode As Integer
        Dim intCnt     As Integer

        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If

        LST.Clear
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
    '   名称：  Sub WLS_Kana_Init
    '   概要：  カナコンボボックス初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Kana_Init()

        'カナ検索 Combo 初期化
        WLSKANA.AddItem "コード"
        WLSKANA.AddItem "ア行      ｱｵ"
        WLSKANA.AddItem "カ行      ｶｺ"
        WLSKANA.AddItem "サ行      ｻｿ"
        WLSKANA.AddItem "タ行      ﾀﾄ"
        WLSKANA.AddItem "ナ行      ﾅﾉ"
        WLSKANA.AddItem "ハ行      ﾊﾎ"
        WLSKANA.AddItem "マ行      ﾏﾓ"
        WLSKANA.AddItem "ヤ行      ﾔﾖ"
        WLSKANA.AddItem "ラ行      ﾗﾛ"
        WLSKANA.AddItem "ワ行      ﾜﾝ"

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Clear
    '   概要：  変数初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()

        '検索条件
        WM_WLS_CODE = ""
        WM_WLS_HINNMA = ""
        WM_WLS_HINNK_S = ""
        WM_WLS_HINNK_E = ""
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
        WM_WLS_HINKB = ""
' === 20061205 === INSERT E -

        '画面表示ページ
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '検索結果保持配列
        ReDim WM_WLS_DSPArray(0)

    End Sub

'
'以下は画面イベント処理
'
    Private Sub Form_Activate()


' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
        If bolInitWindow = False Then
            Exit Sub
        Else
            bolInitWindow = False
        End If
' === 20061205 === INSERT E -

        'WINDOW 位置設定
        Left = (Screen.Width - Width) / 2
        Top = (Screen.Height - Height) / 2

        WM_WLS_Dspflg = False

        '項目初期化
        Call WLS_Kana_Init
        HD_CODE.Text = ""
        HD_KATA.Text = ""
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
        HD_HINKB.Text = ""
        HD_HINKBNM.Text = ""
' === 20061205 === INSERT E -
        WLSKANA.ListIndex = 0
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
'画面表示時に検索しない
'        '初期状態全件表示
'        Call WLS_TextSQL
'        Call WLS_DspNew
'デフォルトで製品を設定
        HD_HINKB.Text = "1"
        WM_WLS_HINKB = HD_HINKB.Text
        '商品区分名編集
        Call F_Dsp_HD_HINKBNM
'''' UPD 2011/02/07  FKS) T.Yamamoto    End
        
        DblClickFl = False
        
        Me.Refresh
'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
'' === 20060821 === UPDATE S - ACE)Nagasawa
''        HD_KATA.SetFocus
'' === 20061228 === INSERT S - ACE)Nagasawa
'                On Error Resume Next
'' === 20061228 === INSERT E -
'        LST.SetFocus
'' === 20060821 === UPDATE E -
    On Error Resume Next
        HD_KATA.SetFocus
'''' UPD 2011/02/07  FKS) T.Yamamoto    End
    End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
    bolInitWindow = True
' === 20061205 === INSERT E -
End Sub

Private Sub HD_CODE_GotFocus()
    If LenWid(HD_CODE.Text) > 0 Then
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'---------- 20061019 ACE MENTE START ----------
'   Else
'       HD_CODE.Text = Space$(HD_CODE.MaxLength)
'---------- 20061019 ACE MENTE E N D ----------
    End If
    HD_CODE.SelStart = 0
    HD_CODE.SelLength = HD_CODE.MaxLength
End Sub

Private Sub HD_CODE_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_CODE = HD_CODE.Text
' === 20061211 === INSERT S - ACE)Nagasawa
        WM_WLS_HINKB = HD_HINKB.Text
' === 20061211 === INSERT E -

        '他検索条件クリア
        WLSKANA.ListIndex = 0
        HD_KATA.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_CODE_KeyPress(KeyAscii As Integer)

    KeyAscii = Asc(UCase(Chr$(KeyAscii)))

End Sub

'2008/08/13 START ADD FKS)HAYASHI-連絡票№：FC08081301
Private Sub HD_KATA_Change()

    Dim lngCnt As Long
    
    lngCnt = HD_KATA.SelStart
    HD_KATA.Text = StrConv(HD_KATA.Text, vbUpperCase)
    HD_KATA.SelStart = lngCnt

End Sub
'2008/08/13 E.N.D ADD FKS)HAYASHI-連絡票№：FC08081301

Private Sub HD_KATA_GotFocus()
'---------- 20061019 ACE MENTE START ----------
'   If LenWid(HD_KATA.Text) <= 0 Then
'       HD_KATA.Text = Space$(HD_KATA.MaxLength)
'   End If
'---------- 20061019 ACE MENTE E N D ----------
    HD_KATA.SelStart = 0
    HD_KATA.SelLength = HD_KATA.MaxLength
End Sub

Private Sub HD_KATA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_HINNMA = HD_KATA.Text
' === 20061211 === INSERT S - ACE)Nagasawa
        WM_WLS_HINKB = HD_HINKB.Text
' === 20061211 === INSERT E -

        '他検索条件クリア
        WLSKANA.ListIndex = 0
        HD_CODE.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub LST_DblClick()
    
    DblClickFl = True
    WLSHIN_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    
    If DblClickFl Then Call WLSCANCEL_Click
    
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    
    Select Case KEYCODE
        'Enterキー押下
        Case vbKeyReturn
            Call WLSOK_Click
            
        'Escapeキー押下
        Case vbKeyEscape
            Call WLSCANCEL_Click
        
        '←キー押下
        Case vbKeyLeft
            Call WLSMAE_Click
            
        '→キー押下
        Case vbKeyRight
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
    
End Sub

    Private Sub WLSKANA_Click()
    Dim W_BUF
        If WM_WLS_Dspflg = False Then Exit Sub
        WM_WLS_Dspflg = False
        WM_WLS_Dspflg = True

        Call WLS_Clear

        '検索用変数セット
        If WLSKANA.ListIndex > 0 Then
            W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
            WM_WLS_HINNK_S = Left$(W_BUF, 1)
            WM_WLS_HINNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
' === 20061211 === INSERT S - ACE)Nagasawa
            WM_WLS_HINKB = HD_HINKB.Text
' === 20061211 === INSERT E -

            '他検索条件クリア
            HD_CODE.Text = ""
            HD_KATA.Text = ""
            WM_WLS_Dspflg = True
    
            Call WLS_TextSQL
            Call WLS_DspNew
' === 20061211 === INSERT S - ACE)Nagasawa
        Else
            If WLSKANA.ListIndex = 0 Then
                WM_WLS_HINNK_S = ""
                WM_WLS_HINNK_E = ""
                WM_WLS_HINKB = HD_HINKB.Text
    
                '他検索条件クリア
                HD_CODE.Text = ""
                HD_KATA.Text = ""
                WM_WLS_Dspflg = True
        
                Call WLS_TextSQL
                Call WLS_DspNew
            End If
' === 20061211 === INSERT E -
        End If

    End Sub

Private Sub WLSKANA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = True
        Call WLSKANA_Click
    Else
        WM_WLS_Dspflg = False
    End If
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

' === 20060728 === DELETE S - ACE)Furukawa
'    Call WLS_DspNew
' === 20060728 === DELETE E

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
' === 20060728 === UPDATE S - ACE)Furukawa
'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
' === 20060728 === UPDATE ↓
        If Not WM_WLS_LastFL Then Call WLS_DspNew
' === 20060728 === UPDATE E
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub

Private Sub WLSMAE_Click()
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub WLSOK_Click()

    WLSHIN_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
    
End Sub

Private Sub WLSCANCEL_Click()
    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    Hide
End Sub

' === 20061205 === INSERT S - ACE)Nagasawa 検索条件に商品区分追加
Private Sub HD_HINKB_GotFocus()
    If LenWid(HD_HINKB.Text) > 0 Then
        HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.MaxLength, WM_WLSKEY_ZOKUSEI)
    End If
    HD_HINKB.SelStart = 0
    HD_HINKB.SelLength = HD_HINKB.MaxLength
End Sub

Private Sub HD_HINKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    
    If KEYCODE = vbKeyReturn Then
        
' === 20061222 === INSERT S - ACE)Nagasawa
        '画面表示ページ
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '検索結果保持配列
        ReDim WM_WLS_DSPArray(0)
' === 20061222 === INSERT E -
        
        WM_WLS_Dspflg = False
        HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.MaxLength, WM_WLSKEY_ZOKUSEI)

        '商品区分名編集
        Call F_Dsp_HD_HINKBNM
        
        WM_WLS_HINKB = HD_HINKB.Text

        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_HINKB_KeyPress(KeyAscii As Integer)

    KeyAscii = Asc(UCase(Chr$(KeyAscii)))

End Sub

Private Sub HD_HINKB_LostFocus()

    WM_WLS_Dspflg = False
    HD_HINKB.Text = SSS_EDTITM_WLS(HD_HINKB.Text, HD_HINKB.MaxLength, WM_WLSKEY_ZOKUSEI)

    '商品区分名編集
    Call F_Dsp_HD_HINKBNM
    
    '検索用変数セット
    WM_WLS_HINKB = HD_HINKB.Text

    WM_WLS_Dspflg = True
    
End Sub

Private Sub HD_HINKBNM_GotFocus()
    Call F_Ctl_HD_Focus
End Sub

Private Function F_Dsp_HD_HINKBNM() As Integer
    
    Dim Mst_Inf_MEI     As TYPE_DB_MEIMTA

    '商品区分名編集
    HD_HINKBNM.Text = ""
    If DSPMEIM_SEARCH(gc_strKEYCD_HINKB, HD_HINKB.Text, Mst_Inf_MEI) = 0 Then
        If Mst_Inf_MEI.DATKB = gc_strDATKB_USE Then
            HD_HINKBNM.Text = SSS_EDTITM_WLS(Mst_Inf_MEI.MEINMA, HD_HINKBNM.MaxLength, WM_WLSKEY_ZOKUSEI)
        End If
    End If
        
End Function

Private Function F_Ctl_HD_Focus() As Integer
    If LST.Enabled = True Then
' === 20061228 === INSERT S - ACE)Nagasawa
                On Error Resume Next
' === 20061228 === INSERT E -
        LST.SetFocus
    Else
        If WLSOK.Enabled = True Then
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            WLSOK.SetFocus
        End If
    End If
End Function

Private Sub CS_HINKB_Click()

' === 20061228 === INSERT S - ACE)Nagasawa
        On Error Resume Next
' === 20061228 === INSERT E -
    Me.HD_HINKB.SetFocus
    
    WLSMEI_KEYCD = gc_strKEYCD_HINKB
    
    DoEvents
    
    WLS_MEI.Show vbModal
    Unload WLS_MEI
        
    Set WLS_MEI = Nothing
    
    If Trim(WLSMEI_RTNMEICDA) <> "" Then
        '商品区分編集
        HD_HINKB.Text = Trim(WLSMEI_RTNMEICDA)

        Call HD_HINKB_KeyDown(vbKeyReturn, 0)

    End If
    
End Sub
' === 20061205 === INSERT E -
