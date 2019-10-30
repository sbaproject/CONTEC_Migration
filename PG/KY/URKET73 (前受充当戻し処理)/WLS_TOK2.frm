VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_TOK2 
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "得意先検索"
   ClientHeight    =   5220
   ClientLeft      =   2280
   ClientTop       =   4530
   ClientWidth     =   13050
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5220
   ScaleWidth      =   13050
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   6570
      TabIndex        =   2
      Top             =   4740
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   5355
      TabIndex        =   1
      Top             =   4740
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      ItemData        =   "WLS_TOK2.frx":0000
      Left            =   45
      List            =   "WLS_TOK2.frx":0007
      TabIndex        =   0
      Top             =   960
      Width           =   12915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   555
      Left            =   0
      TabIndex        =   5
      Top             =   0
      Width           =   14310
      _ExtentX        =   25241
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
         Left            =   11760
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   8
         Top             =   75
         Width           =   1185
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1200
         MaxLength       =   5
         TabIndex        =   3
         Text            =   "XXXXX"
         Top             =   75
         Width           =   885
      End
      Begin VB.TextBox HD_RN 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   3975
         MaxLength       =   40
         TabIndex        =   4
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   80
         Width           =   5100
      End
      Begin Threed5.SSPanel5 SSPanel51 
         Height          =   375
         Left            =   2355
         TabIndex        =   6
         Top             =   80
         Width           =   1635
         _ExtentX        =   2884
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
         Left            =   10530
         TabIndex        =   9
         Top             =   75
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
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Left            =   105
         TabIndex        =   10
         Top             =   75
         Width           =   1110
         _ExtentX        =   1958
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
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   60
      TabIndex        =   7
      Top             =   600
      Width           =   12915
      _ExtentX        =   22781
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
      Caption         =   " ｺｰﾄﾞ     得意先名                                 締  日      回収条件      税区    電話番号      請求先"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   8100
      Picture         =   "WLS_TOK2.frx":0010
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   9000
      Picture         =   "WLS_TOK2.frx":0662
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   8595
      Picture         =   "WLS_TOK2.frx":0CB4
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   7695
      Picture         =   "WLS_TOK2.frx":1306
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   7800
      Picture         =   "WLS_TOK2.frx":1958
      Top             =   4740
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4860
      Picture         =   "WLS_TOK2.frx":1FAA
      Top             =   4740
      Width           =   360
   End
End
Attribute VB_Name = "WLS_TOK2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'*************************************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　検索ウィンドウ
'*  プログラム名　　：　勘定口座検索 → 請求先検索に改造 2007/03/05 Saito
'*  プログラムＩＤ　：  WLS_MEI
'*  作成者　　　　　：　SYSTEM CREATE Co.,Ltd.
'*  作成日　　　　　：  2006.10.21
'*------------------------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'*************************************************************************************************
    
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
    Private WM_WLS_NAMELEN      As Integer          '得意先略称入力文字数

    'ウィンド内部使用変数
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_CODE         As String           '入金種別コード検索用
    Private WM_WLS_MEIRN        As String           '入金種別略称検索用
    Private WM_WLS_TOKNK_S      As String           '入金種別検索用(開始)
    Private WM_WLS_TOKNK_E      As String           '入金種別検索用(終了)
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    
    Private DB_TOKMTA_W         As TYPE_DB_TOKMTA   '検索結果退避
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
    
        '=== 表示開始コード桁数設定 ===
        WM_WLS_CODELEN = 10
        WM_WLS_MAX = 15                 '画面表示件数
        '変数初期化
        WLSTOK_RTNCODE = ""
        Call WLS_Clear
        
        '条件項目クリア
        HD_TEXT.Text = ""
        HD_RN.Text = ""
        'コンボボックスセット
        WLS_Kana_Init
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
        Select Case SSSVal(DB_TOKMTA_W.TOKZEIKB)
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
        Select Case SSSVal(DB_TOKMTA_W.TOKSMEKB)
            Case 1
                WK_SMENM = DB_TOKMTA_W.TOKSMEDD & "日締    "
                Select Case SSSVal(DB_TOKMTA_W.TOKKESCC)
                    Case 0
                        WK_KESNM = "  当月"
                    Case 1
                        WK_KESNM = "  翌月"
                    Case 2
                        WK_KESNM = "翌々月"
                    Case Else
                        WK_KESNM = "その他"
                End Select
                WK_KESNM = WK_KESNM & DB_TOKMTA_W.TOKKESDD & "日回収"
            Case 2
                WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKSDWKB)) & "締      " & SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKKDWKB)) & "回収"
            Case Else
                WK_SMENM = Space(8)
        End Select
        '
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TOKMTA_W.TOKCD, 5) & Space(5) & _
                                    LeftWid$(DB_TOKMTA_W.TOKRN, 40) & Space(1) & _
                                    WK_SMENM & WK_KESNM & Space(2) & _
                                    WK_ZEINM & Space(2) & _
                                    LeftWid$(DB_TOKMTA_W.TOKTL, 13) & Space(1) & _
                                    LeftWid$(DB_TOKMTA_W.TOKSEICD, 5)
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_TextSQL
    '   概要：  検索sql作成
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Sub WLS_TextSQL()

        Dim strSql          As String
        Dim intData         As Integer

        strSql = _
            "SELECT * FROM tokmta " _
           & "WHERE datkb = '1' AND frnkb = '0' AND dspkb = '1' "
                 '★国内請求先、検索対象区分＝１のみ表示
                    
        '開始ｺｰﾄﾞが入力されている時
        If Trim(HD_TEXT.Text) <> "" Then
            strSql = strSql & "AND tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
        End If
        
        '得意先略称名が入力されている時(あいまい検索とする)
        If Trim(HD_RN.Text) <> "" Then
            strSql = strSql & "AND tokrn LIKE '%" & RTrim(HD_RN.Text) & "%' "
        End If
        
        '得意先カナ検索
        If Trim(WM_WLS_TOKNK_S) <> "" Then
            strSql = strSql & "AND TOKNK >= '" & WM_WLS_TOKNK_S & "' And TOKNK < '" & WM_WLS_TOKNK_E & "' "
        
        End If
        
        '整列条件
        If Trim(WM_WLS_TOKNK_S) <> "" Then
            strSql = strSql & "ORDER BY toknk, tokcd"
        Else
            strSql = strSql & "ORDER BY tokcd"
        End If
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
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
            DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")               '得意先コード
            DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")               '得意先略称
            DB_TOKMTA_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")         '消費税区分
            DB_TOKMTA_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")         '締区分
            DB_TOKMTA_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")         '締初期日付（売上）
            DB_TOKMTA_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")         '回収サイクル締初期日付（売上）
            DB_TOKMTA_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")         '回収日付
            DB_TOKMTA_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")         '回収曜日
            DB_TOKMTA_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")         '締め曜日
            DB_TOKMTA_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")               '得意先電話番号
            DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")         '請求先コード
            
                
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
    '   名称：  Sub WLS_Clear
    '   概要：  変数初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_Clear()
        'Sub WLS_Clear

        '検索条件
        WM_WLS_CODE = ""
        WM_WLS_MEIRN = ""
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


        WM_WLS_Dspflg = False

        '項目初期化
        'Call WLS_Kana_Init
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        'WLSKANA.ListIndex = 0
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '初期状態全件表示
        Call WLS_TextSQL
        Call WLS_DspNew
        
        DblClickFl = False
        
        Me.Refresh
        'HD_CODE.SetFocus
    End Sub

Private Sub Form_Load()
    'WINDOW 位置設定
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    
    'Window初期設定
    Call WLS_FORM_INIT
End Sub

'得意先略称項目でキーを押した時
Private Sub HD_RN_GotFocus()
    '全選択状態にする
    HD_RN.SelStart = 0
    HD_RN.SelLength = 40
End Sub

'得意先略称項目でキーを押した時
Private Sub HD_RN_KeyDown(KEYCODE As Integer, Shift As Integer)
    'Enter押下時に再検索を実行
    If KEYCODE = vbKeyReturn Then
        WLSKANA.ListIndex = -1
        Call WLS_Clear
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

'得意先ｺｰﾄﾞ項目にフォーカスが移動した時
Private Sub HD_TEXT_GotFocus()
    '全選択状態にする
    HD_TEXT.SelStart = 0
    HD_TEXT.SelLength = 5
End Sub

'得意先ｺｰﾄﾞ項目でキーを押した時
Private Sub HD_TEXT_KeyDown(KEYCODE As Integer, Shift As Integer)
    'Enter押下時に再検索を実行
    If KEYCODE = vbKeyReturn Then
        WLSKANA.ListIndex = -1
        Call WLS_Clear
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

'''Private Sub HD_CODE_GotFocus()
'''    If LenWid(HD_CODE.Text) > 0 Then
'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_CODE.Text = Space$(HD_CODE.MaxLength)
'''    End If
'''    HD_CODE.SelStart = 0
'''    HD_CODE.SelLength = HD_CODE.MaxLength
'''End Sub
'''
'''Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
'''    If KeyCode = vbKeyReturn Then
'''        WM_WLS_Dspflg = False
'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'''
'''        '検索用変数セット
'''        Call WLS_Clear
'''        WM_WLS_CODE = HD_CODE.Text
'''
'''        '他検索条件クリア
'''        WM_WLS_Dspflg = True
'''
'''        Call WLS_TextSQL
'''        Call WLS_DspNew
'''    End If
'''End Sub

Private Sub LST_DblClick()

    DblClickFl = True
    WLSTOK_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
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


Private Sub WLSKANA_Click()
    Dim W_BUF As String * 2
    
    Call WLS_Clear

    '検索用変数セット
    If WLSKANA.ListIndex > 0 Then
        W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
        WM_WLS_TOKNK_S = Left$(W_BUF, 1)
        WM_WLS_TOKNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
        '他検索条件クリア
        HD_TEXT.Text = ""
        HD_RN.Text = ""
    
        Call WLS_TextSQL
        Call WLS_DspNew
    Else
'            W_BUF = ""
'            WM_WLS_TOKNK_S = ""
'            WM_WLS_TOKNK_E = ""
        '他検索条件クリア
        HD_TEXT.Text = ""
        HD_RN.Text = ""
    
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
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


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Kana_Init
    '   概要：  カナコンボボックス初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Kana_Init()

        'カナ検索 Combo 初期化
        WLSKANA.Clear
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
