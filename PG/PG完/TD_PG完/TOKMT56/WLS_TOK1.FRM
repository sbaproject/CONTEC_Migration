VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSTOK 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "得意先一覧ウィンドウ"
   ClientHeight    =   5490
   ClientLeft      =   2760
   ClientTop       =   2370
   ClientWidth     =   11340
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
   ScaleHeight     =   5490
   ScaleWidth      =   11340
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   30
      TabIndex        =   6
      Top             =   870
      Width           =   11265
      _ExtentX        =   19870
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
      Caption         =   "ｺｰﾄﾞ  得意先名                       締日      回収条件        税区    電話番号      請求先"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      Left            =   30
      TabIndex        =   1
      Top             =   1230
      Width           =   11265
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   4748
      TabIndex        =   2
      Top             =   5010
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   5693
      TabIndex        =   3
      Top             =   5010
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   555
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   11640
      _ExtentX        =   20532
      _ExtentY        =   979
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
      Begin VB.ComboBox WLSKANA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   360
         Left            =   9915
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   10
         Top             =   90
         Width           =   1185
      End
      Begin VB.TextBox HD_NAME 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   3360
         MaxLength       =   40
         TabIndex        =   7
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   90
         Width           =   5235
      End
      Begin VB.TextBox HD_CODE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1170
         MaxLength       =   6
         TabIndex        =   4
         Text            =   "XXXXX6"
         Top             =   90
         Width           =   780
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   90
         TabIndex        =   5
         Top             =   90
         Width           =   1095
         _ExtentX        =   1931
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
         Caption         =   "開始ｺｰﾄﾞ"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel51 
         Height          =   375
         Left            =   2025
         TabIndex        =   8
         Top             =   90
         Width           =   1350
         _ExtentX        =   2381
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
         Caption         =   "得意先略称"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 PNL_USENM 
         Height          =   375
         Index           =   3
         Left            =   8685
         TabIndex        =   9
         Top             =   90
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
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3825
      Picture         =   "WLS_TOK1.frx":0000
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4725
      Picture         =   "WLS_TOK1.frx":0652
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5130
      Picture         =   "WLS_TOK1.frx":0CA4
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4230
      Picture         =   "WLS_TOK1.frx":12F6
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4253
      Picture         =   "WLS_TOK1.frx":1948
      Top             =   5010
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   6728
      Picture         =   "WLS_TOK1.frx":1F9A
      Top             =   5010
      Width           =   360
   End
End
Attribute VB_Name = "WLSTOK"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　得意先検索
    '*  プログラムＩＤ　：  WLSTOK
    '*  作成者　　　　　：　ACE)長澤
    '*  作成日　　　　　：  2006.05.11
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************
    
'************************************************************************************
'   Public変数
'************************************************************************************
    '戻り値
    
'************************************************************************************
'   Private定数
'************************************************************************************
    
' === 20060730 === UPDATE S - ACE)Nagasawa
'    Private Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]
    Private Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]
' === 20060730 === UPDATE E -

'************************************************************************************
'   Private変数
'************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MFIL         As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_CODELEN      As Integer          '開始ｺｰﾄﾞ入力文字数
    Private WM_WLS_NAMELEN      As Integer          '得意先略称入力文字数

    'ウィンド内部使用変数
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_CODE         As String           '得意先コード検索用
    Private WM_WLS_TOKRN        As String           '得意先略称検索用
    Private WM_WLS_TOKNK_S      As String           '得意先カナ検索用(開始)
    Private WM_WLS_TOKNK_E      As String           '得意先カナ検索用(終了)
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_TOKMAT_W         As TYPE_DB_TOKMTA  '検索結果退避
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
    
        '=== 表示開始コード桁数設定 ===
        WM_WLS_CODELEN = 5
        WM_WLS_MAX = 15                 '画面表示件数
        '変数初期化
        WLSTOK_RTNCODE = ""
        Call WLS_Clear
        
    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
        '====================================
        '   WINDOW 明細設定
        '====================================

        Dim WK_KESNM As String, WK_ZEINM As String, WK_TK As String * 13, WK_SMENM As String
        Dim WK_KESDD As String
        '
        Select Case SSSVal(DB_TOKMAT_W.TOKZEIKB)
            Case 1
                WK_ZEINM = "税抜  "
            Case 2
                WK_ZEINM = "税込  "
            Case 9
                WK_ZEINM = "対象外"
            Case Else
                WK_ZEINM = "      "
        End Select
        '
        Select Case SSSVal(DB_TOKMAT_W.TOKSMEKB)
            Case 1
                WK_SMENM = DB_TOKMAT_W.TOKSMEDD & "日締    "
                Select Case SSSVal(DB_TOKMAT_W.TOKKESCC)
                    Case 0
                        WK_KESNM = "  当月"
                    Case 1
                        WK_KESNM = "  翌月"
                    Case 2
                        WK_KESNM = "翌々月"
                    Case Else
                        WK_KESNM = "その他"
                End Select
                WK_KESNM = WK_KESNM & DB_TOKMAT_W.TOKKESDD & "日回収"
            Case 2
                WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMAT_W.TOKSDWKB)) & "締      " & SSS_WEEKNM(SSSVal(DB_TOKMAT_W.TOKKDWKB)) & "回収"
            Case Else
                WK_SMENM = Space(8)
        End Select
        '
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TOKMAT_W.TOKCD, 5) & Space(1) & _
                                    LeftWid$(DB_TOKMAT_W.TOKRN, 30) & Space(1) & _
                                    WK_SMENM & WK_KESNM & Space(2) & _
                                    WK_ZEINM & Space(2) & _
                                    LeftWid$(DB_TOKMAT_W.TOKTL, 13) & Space(1) & _
                                    DB_TOKMAT_W.TOKSEICD
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
        strSQL = strSQL & " Select TOKCD "          '得意先コード
        strSQL = strSQL & "      , TOKRN "          '得意先略称
        strSQL = strSQL & "      , TOKZEIKB "       '消費税区分
        strSQL = strSQL & "      , TOKSMEKB "       '締区分
        strSQL = strSQL & "      , TOKSMEDD "       '締初期日付（売上）
        strSQL = strSQL & "      , TOKKESCC "       '回収サイクル
        strSQL = strSQL & "      , TOKKESDD "       '回収日付
        strSQL = strSQL & "      , TOKSDWKB "       '締め曜日
        strSQL = strSQL & "      , TOKKDWKB "       '回収曜日
        strSQL = strSQL & "      , TOKTL "          '得意先電話番号
        strSQL = strSQL & "      , TOKSEICD "       '請求先コード
        strSQL = strSQL & "   from TOKMTA "
' === 20060814 === UPDATE S - ACE)Nagasawa
'        strSQL = strSQL & "  Where DATKB = '1' "
'' === 20060728 === INSERT S - ACE)Furukawa
'        strSQL = strSQL & "  And   DSPKB = '1' "    '検索表示区分
'' === 20060728 === INSERT E
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "  And   DSPKB = '" & gc_strDSPKB_OK & "' "     '検索表示区分
' === 20060926 === INSERT S - ACE)Nagasawa
        strSQL = strSQL & "  And   THSCD <> '" & gc_strTHSCD_SIR & "' "   '取引先分類
' === 20060926 === INSERT E -
' === 20060814 === UPDATE E -
' === 20060824 === INSERT S - ACE)Sejima 諸口対応
        If Trim(WLSTOK_SKCHKB) <> "" Then
            strSQL = strSQL & "    and SKCHKB = '" & WLSTOK_SKCHKB & "' "
        End If
' === 20060824 === INSERT E
' === 20060926 === INSERT S - ACE)Nagasawa 海外区分対応
        If Trim(WLSTOK_FRNKB) <> "" Then
            strSQL = strSQL & "    and FRNKB  = '" & WLSTOK_FRNKB & "' "
        End If
' === 20060926 === INSERT E -

        '得意先コード検索
        If Trim(WM_WLS_CODE) <> "" Then
            strSQL = strSQL & "    and TOKCD >=   '" & WM_WLS_CODE & "'"
        End If

        '得意先略称検索(あいまい検索)
        If Trim(WM_WLS_TOKRN) <> "" Then
            strSQL = strSQL & "    and TOKRN LIKE '%" & WM_WLS_TOKRN & "%'"
        End If

        '得意先カナ検索
        If Trim(WM_WLS_TOKNK_S) <> "" Then
            strSQL = strSQL & "    and TOKNK >= '" & WM_WLS_TOKNK_S & "' And TOKNK < '" & WM_WLS_TOKNK_E & "'"
        End If

        'ソート条件
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_TOKNK_S) <> "" Then
        '得意先カナ検索の場合
            strSQL = strSQL & "   TOKNK "
            strSQL = strSQL & "  ,TOKCD "
        Else
        '得意先コード検索,得意先略称検索
            strSQL = strSQL & "   TOKCD "
        End If
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        
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
    Dim Wk_Pagecnt      As Integer
    
    Cnt = 0
    Wk_Pagecnt = -1
    Do Until CF_Ora_EOF(Usr_Ody) = True
        
        '取得内容退避
        DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")               '得意先コード
        DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")               '得意先略称
        DB_TOKMAT_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")         '消費税区分
        DB_TOKMAT_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")         '締区分
        DB_TOKMAT_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")         '締初期日付（売上）
        DB_TOKMAT_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")         '回収サイクル締初期日付（売上）
        DB_TOKMAT_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")         '回収日付
        DB_TOKMAT_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")         '回収曜日
        DB_TOKMAT_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")         '締め曜日
        DB_TOKMAT_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")               '得意先電話番号
        DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")         '請求先コード
        
        '表示改ページ
        If Cnt Mod WM_WLS_MAX = 0 Then
            Wk_Pagecnt = Wk_Pagecnt + 1
            '最終ページ退避
            WM_WLS_LastPage = Wk_Pagecnt
            ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
            Cnt = 0
        End If
    
        '表示メモリ展開
        Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
        
        Cnt = Cnt + 1
        
        Call CF_Ora_MoveNext(Usr_Ody)
    Loop
    
    '取得データ有無に関わらず最終データ到達
    WM_WLS_LastFL = True
    
    If Cnt > 0 Then
        '１ページを表示
        WM_WLS_Pagecnt = 0
        Call WLS_DspPage
    Else
        LST.Clear
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
        WM_WLS_TOKRN = ""
        WM_WLS_TOKNK_S = ""
        WM_WLS_TOKNK_E = ""

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

        'WINDOW 位置設定
        Left = (Screen.Width - Width) / 2
        Top = (Screen.Height - Height) / 2

        WM_WLS_Dspflg = False

        '項目初期化
        Call WLS_Kana_Init
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        WLSKANA.ListIndex = 0
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '初期状態全件表示
        Call WLS_TextSQL
        Call WLS_DspNew
        
        DblClickFl = False
        
        Me.Refresh
' === 20060821 === UPDATE S - ACE)Nagasawa
'        HD_CODE.SetFocus
' === 20061228 === INSERT S - ACE)Nagasawa
                On Error Resume Next
' === 20061228 === INSERT E -
        LST.SetFocus
' === 20060821 === UPDATE E -
    End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
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

Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_CODE = HD_CODE.Text

        '他検索条件クリア
        WLSKANA.ListIndex = 0
        HD_NAME.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
Private Sub HD_CODE_KeyPress(KeyAscii As Integer)

    KeyAscii = Asc(UCase(Chr$(KeyAscii)))

End Sub
' === 20070206 === UPDATE E -

Private Sub HD_NAME_GotFocus()
'---------- 20061019 ACE MENTE START ----------
'   If LenWid(HD_NAME.Text) <= 0 Then
'       HD_NAME.Text = Space$(HD_NAME.MaxLength)
'   End If
'---------- 20061019 ACE MENTE E N D ----------
    HD_NAME.SelStart = 0
    HD_NAME.SelLength = HD_NAME.MaxLength
End Sub

Private Sub HD_NAME_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_TOKRN = HD_NAME.Text

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
    WLSTOK_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If DblClickFl Then Call WLSCANCEL_Click
    
End Sub

Private Sub LST_KeyDown(KeyCode As Integer, Shift As Integer)

    Select Case KeyCode
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
            WM_WLS_TOKNK_S = Left$(W_BUF, 1)
            WM_WLS_TOKNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
            '他検索条件クリア
            HD_CODE.Text = ""
            HD_NAME.Text = ""
        
            Call WLS_TextSQL
            Call WLS_DspNew
        End If
    
    End Sub

Private Sub WLSKANA_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = True
        Call WLSKANA_Click
    Else
        WM_WLS_Dspflg = False
    End If
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspPage
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
    WLSTOK_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()
    Hide
End Sub
