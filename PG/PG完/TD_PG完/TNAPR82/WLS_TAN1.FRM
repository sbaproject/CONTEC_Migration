VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSTAN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "担当者検索"
   ClientHeight    =   5790
   ClientLeft      =   1665
   ClientTop       =   3300
   ClientWidth     =   10680
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
   ScaleHeight     =   5790
   ScaleWidth      =   10680
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   6
      Top             =   1215
      Width           =   10590
      _ExtentX        =   18680
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
      Caption         =   "担当者ｺｰﾄﾞ        担当者名                    所属部門"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      ItemData        =   "WLS_TAN1.frx":0000
      Left            =   45
      List            =   "WLS_TAN1.frx":0007
      TabIndex        =   1
      Top             =   1575
      Width           =   10590
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   4418
      TabIndex        =   2
      Top             =   5350
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   5363
      TabIndex        =   3
      Top             =   5350
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1015
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10875
      _ExtentX        =   19182
      _ExtentY        =   1799
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
      Begin VB.TextBox HD_BMNCD 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   4815
         MaxLength       =   6
         TabIndex        =   11
         Text            =   "XXXXX6"
         Top             =   540
         Width           =   1000
      End
      Begin VB.ComboBox WLSKANA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   360
         Left            =   9210
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   10
         Top             =   105
         Width           =   1365
      End
      Begin VB.TextBox HD_NAME 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   4815
         MaxLength       =   10
         TabIndex        =   7
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   90
         Width           =   2560
      End
      Begin VB.TextBox HD_CODE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1590
         MaxLength       =   6
         TabIndex        =   4
         Text            =   "XXXXX6"
         Top             =   90
         Width           =   900
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   90
         TabIndex        =   5
         Top             =   90
         Width           =   1515
         _ExtentX        =   2672
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
         Left            =   3120
         TabIndex        =   8
         Top             =   90
         Width           =   1710
         _ExtentX        =   3016
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
         Caption         =   "担当者名"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 PNL_USENM 
         Height          =   375
         Index           =   3
         Left            =   8040
         TabIndex        =   9
         Top             =   105
         Width           =   1185
         _ExtentX        =   2090
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
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Left            =   3120
         TabIndex        =   12
         Top             =   540
         Width           =   1710
         _ExtentX        =   3016
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
         Caption         =   "所属部門ｺｰﾄﾞ"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3825
      Picture         =   "WLS_TAN1.frx":0063
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4725
      Picture         =   "WLS_TAN1.frx":06B5
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5130
      Picture         =   "WLS_TAN1.frx":0D07
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4230
      Picture         =   "WLS_TAN1.frx":1359
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   3885
      Picture         =   "WLS_TAN1.frx":19AB
      Top             =   5350
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   6450
      Picture         =   "WLS_TAN1.frx":1FFD
      Top             =   5350
      Width           =   360
   End
End
Attribute VB_Name = "WLSTAN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　検索ウィンドウ
'*  プログラム名　　：　担当者検索
'*  プログラムＩＤ　：  WLSTAN
'*  作成者　　　　　：　ACE)長澤
'*  作成日　　　　　：  2006.05.12
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************
    
'************************************************************************************
'   構造体
'************************************************************************************
    Private Type TYPE_DB_TANMTA_W
        WK_DB_TANMTA        As TYPE_DB_TANMTA
        TANBMNNM            As String               '部門名
        OLDBMNNM            As String               '部門名
    End Type
'************************************************************************************
'   Private定数
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]

'************************************************************************************
'   Private変数
'************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MFIL         As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_CODELEN      As Integer          '開始ｺｰﾄﾞ入力文字数
    Private WM_WLS_NAMELEN      As Integer          '担当者名入力文字数
    Private WM_WLS_BMNLEN       As Integer          '部門ｺｰﾄﾞ入力文字数

    'ウィンド内部使用変数
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_CODE         As String           '担当者コード検索用
    Private WM_WLS_TANNM         As String          '担当者名検索用
    Private WM_WLS_TANNK_S      As String           '担当者名カナ検索用(開始)
    Private WM_WLS_TANNK_E      As String           '担当者名カナ検索用(終了)
    Private WM_WLS_BMNCD        As String           '部門ｺｰﾄﾞ検索用
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_TANMTA_W         As TYPE_DB_TANMTA_W
    Private Dyn_Open            As Boolean          'ダイナセット状態（True:Open False:Close)
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
        '=== 表示開始コード桁数設定 ===
        WM_WLS_CODELEN = 6
        WM_WLS_NAMELEN = 20
        WM_WLS_BMNLEN = 6
        WM_WLS_MAX = 15                 '画面表示件数
        '変数初期化
        WLSTAN_RTNCODE = ""
        Call WLS_Clear
        Dyn_Open = False
        '基準日（適用日）の再設定（渡されなかった場合、運用日付）
        If Trim(WLSTAN_TANTKDT) = "" Then
            WLSTAN_TANTKDT = GV_UNYDate
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
        Dim strBMNNM        As String
        
        strBMNNM = DB_TANMTA_W.TANBMNNM
        
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TANMTA_W.WK_DB_TANMTA.TANCD, WM_WLS_CODELEN) & Space(12) & _
                                    LeftWid$(DB_TANMTA_W.WK_DB_TANMTA.TANNM, WM_WLS_NAMELEN) & Space(8) & _
                                    strBMNNM
                                    
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
        strSQL = strSQL & " Select TANCD         AS TANCD"          '担当者コード
        strSQL = strSQL & "      , TANNM         AS TANNM"          '担当者名
        strSQL = strSQL & "      , TANBMNCD      AS TANBMNCD"       '所属部門コード
        strSQL = strSQL & "      , BMN1.BMNNM    AS TANBMNNM"       '所属部門名
        strSQL = strSQL & "      , OLDBMNCD      AS OLDBMNCD"       '所属部門コード
        strSQL = strSQL & "      , BMN2.BMNNM    AS OLDBMNNM"       '所属部門名
        strSQL = strSQL & "      , TANTKDT       AS TANTKDT"        '適用日
        strSQL = strSQL & "   from TANMTA, BMNMTA BMN1, BMNMTA BMN2"
        strSQL = strSQL & "  Where TANMTA.DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and BMN1.BMNCD (+) = (CASE WHEN TANMTA.TANTKDT <= '" _
                        & WLSTAN_TANTKDT _
                        & "' THEN TANMTA.TANBMNCD ELSE TANMTA.OLDBMNCD END )"
        
        strSQL = strSQL & "    and BMN1.DATKB (+) = '" & gc_strDATKB_USE & "' "
        If Trim(WLSTAN_TANTKDT) <> "" Then
            strSQL = strSQL & "  and BMN1.STTTKDT (+) <= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
            strSQL = strSQL & "  and BMN1.ENDTKDT (+) >= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
        Else
            strSQL = strSQL & "  and BMN1.STTTKDT (+) <= '" & CF_Ora_Date(GV_UNYDate) & "' "
            strSQL = strSQL & "  and BMN1.ENDTKDT (+) >= '" & CF_Ora_Date(GV_UNYDate) & "' "
        End If
        strSQL = strSQL & "    and OLDBMNCD         = BMN2.BMNCD (+) "
        strSQL = strSQL & "    and BMN2.DATKB (+) = '" & gc_strDATKB_USE & "' "
        'コメントはずす
        If Trim(WLSTAN_TANTKDT) <> "" Then
            strSQL = strSQL & "  and BMN2.STTTKDT (+) <= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
            strSQL = strSQL & "  and BMN2.ENDTKDT (+) >= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
        Else
            strSQL = strSQL & "  and BMN2.STTTKDT (+) <= '" & CF_Ora_Date(GV_UNYDate) & "' "
            strSQL = strSQL & "  and BMN2.ENDTKDT (+) >= '" & CF_Ora_Date(GV_UNYDate) & "' "
        End If

        '担当者コード検索
        If Trim(WM_WLS_CODE) <> "" Then
            strSQL = strSQL & "    and TANCD >=   '" & WM_WLS_CODE & "'"
        End If

        '担当者名検索(あいまい検索)
        If Trim(WM_WLS_TANNM) <> "" Then
            strSQL = strSQL & "    and TANNM LIKE '%" & WM_WLS_TANNM & "%'"
        End If

        '担当者名カナ検索
        If Trim(WM_WLS_TANNK_S) <> "" Then
            strSQL = strSQL & "    and TANNK >= '" & WM_WLS_TANNK_S & "' And TANNK < '" & WM_WLS_TANNK_E & "'"
        End If

        '所属部門ｺｰﾄﾞ検索
        If Trim(WM_WLS_BMNCD) <> "" Then
            strSQL = strSQL & "    and TANBMNCD = '" & WM_WLS_BMNCD & "'"
        End If
        
        'ソート条件
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_TANNK_S) <> "" Then
        ''担当者名カナの場合
            strSQL = strSQL & "  TANNK "
            strSQL = strSQL & "  ,TANCD "
        Else
        '担当者コード検索
            strSQL = strSQL & "  TANCD "
        End If
        
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dyn_Open = True
        LST.Clear
    
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
        DB_TANMTA_W.WK_DB_TANMTA.TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")        '担当者コード
        DB_TANMTA_W.WK_DB_TANMTA.TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")        '担当者名
        DB_TANMTA_W.WK_DB_TANMTA.TANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")    '適用日
        DB_TANMTA_W.WK_DB_TANMTA.TANBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")  '所属部門コード
        DB_TANMTA_W.WK_DB_TANMTA.OLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")  '旧所属部門コード
        DB_TANMTA_W.TANBMNNM = CF_Ora_GetDyn(Usr_Ody, "TANBMNNM", "")               '所属部門名
        DB_TANMTA_W.OLDBMNNM = CF_Ora_GetDyn(Usr_Ody, "OLDBMNNM", "")               '旧所属部門名
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
            On Error Resume Next
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
        WM_WLS_TANNM = ""
        WM_WLS_TANNK_S = ""
        WM_WLS_TANNK_E = ""
        WM_WLS_BMNCD = ""

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
        HD_BMNCD.Text = ""
        WLSKANA.ListIndex = 0
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)
        
        '初期状態全件表示
        Call WLS_TextSQL
        Call WLS_DspNew
        
        DblClickFl = False
        
        Me.Refresh
                On Error Resume Next
        LST.SetFocus
    End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
End Sub

' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
Private Sub HD_BMNCD_KeyPress(KeyAscii As Integer)

    KeyAscii = Asc(UCase(Chr$(KeyAscii)))

End Sub
' === 20070206 === UPDATE E -

Private Sub HD_CODE_GotFocus()
    If LenWid(HD_CODE.Text) > 0 Then
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
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
    HD_NAME.SelStart = 0
    HD_NAME.SelLength = HD_NAME.MaxLength
End Sub

Private Sub HD_NAME_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_TANNM = HD_NAME.Text

        '他検索条件クリア
        WLSKANA.ListIndex = 0
        HD_CODE.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_BMNCD_GotFocus()
    HD_BMNCD.SelStart = 0
    HD_BMNCD.SelLength = HD_BMNCD.MaxLength
End Sub

Private Sub HD_BMNCD_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_BMNCD = HD_BMNCD.Text

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
    WLSTAN_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
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
            WM_WLS_TANNK_S = Left$(W_BUF, 1)
            WM_WLS_TANNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
        End If

        '他検索条件クリア
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew

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
        If Not WM_WLS_LastFL Then Call WLS_DspNew
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

    WLSTAN_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
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
