Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_TOK2
	Inherits System.Windows.Forms.Form
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
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]

    '************************************************************************************
    '   Private変数
    '************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    '20190619 chg start
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '開始ｺｰﾄﾞ入力文字数
	Private WM_WLS_NAMELEN As Short '得意先略称入力文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_CODE As String '入金種別コード検索用
	Private WM_WLS_MEIRN As String '入金種別略称検索用
	Private WM_WLS_TOKNK_S As String '入金種別検索用(開始)
	Private WM_WLS_TOKNK_E As String '入金種別検索用(終了)
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean

    'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '2019/04/23 CHG START
    'Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private Usr_Ody As DataTable 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    '2019/04/23 CHG E N D
    Private DB_TOKMTA_W As TYPE_DB_TOKMTA '検索結果退避
	
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
		WM_WLS_MAX = 15 '画面表示件数
		'変数初期化
		WLSTOK_RTNCODE = ""
		Call WLS_Clear()
		
		'条件項目クリア
		HD_TEXT.Text = ""
		HD_RN.Text = ""
		'コンボボックスセット
		WLS_Kana_Init()
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_SetArray
	'   概要：  リスト編集
	'   引数：　ArrayCnt : リスト編集対象INDEX
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		'====================================
		'   WINDOW 明細設定
		'====================================
		
		Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
		Dim WK_TK As New VB6.FixedLengthString(13)
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
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKSDWKB)) & "締      " & SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKKDWKB)) & "回収"
			Case Else
				WK_SMENM = Space(8)
		End Select
		'
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMTA_W.TOKCD, 5) & Space(5) & LeftWid(DB_TOKMTA_W.TOKRN, 40) & Space(1) & WK_SMENM & WK_KESNM & Space(2) & WK_ZEINM & Space(2) & LeftWid(DB_TOKMTA_W.TOKTL, 13) & Space(1) & LeftWid(DB_TOKMTA_W.TOKSEICD, 5)
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Sub WLS_TextSQL()
		
		Dim strSql As String
		Dim intData As Short
		
		strSql = "SELECT * FROM tokmta " & "WHERE datkb = '1' AND frnkb = '0' AND dspkb = '1' "
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
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        Usr_Ody = DB_GetTable(strSql)
        '2019/04/23 CHG E N D

    End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer
		Dim Wk_Pagecnt As Short
		
		Cnt = 0
        Wk_Pagecnt = -1
        '2019/04/23 CHG START
        '     Do Until CF_Ora_EOF(Usr_Ody) = True

        ''取得内容退避
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "") '消費税区分
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "") '締区分
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "") '締初期日付（売上）
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "") '回収サイクル締初期日付（売上）
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "") '回収日付
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "") '回収曜日
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "") '締め曜日
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "") '得意先電話番号
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '請求先コード
        For i As Integer = 0 To Usr_Ody.Rows.Count - 1

            '取得内容退避
            DB_TOKMTA_W.TOKCD = DB_NullReplace(Usr_Ody.Rows(i)("TOKCD"), "") '得意先コード
            DB_TOKMTA_W.TOKRN = DB_NullReplace(Usr_Ody.Rows(i)("TOKRN"), "") '得意先略称
            DB_TOKMTA_W.TOKZEIKB = DB_NullReplace(Usr_Ody.Rows(i)("TOKZEIKB"), "") '消費税区分
            DB_TOKMTA_W.TOKSMEKB = DB_NullReplace(Usr_Ody.Rows(i)("TOKSMEKB"), "") '締区分
            DB_TOKMTA_W.TOKSMEDD = DB_NullReplace(Usr_Ody.Rows(i)("TOKSMEDD"), "") '締初期日付（売上）
            DB_TOKMTA_W.TOKKESCC = DB_NullReplace(Usr_Ody.Rows(i)("TOKKESCC"), "") '回収サイクル締初期日付（売上）
            DB_TOKMTA_W.TOKKESDD = DB_NullReplace(Usr_Ody.Rows(i)("TOKKESDD"), "") '回収日付
            DB_TOKMTA_W.TOKSDWKB = DB_NullReplace(Usr_Ody.Rows(i)("TOKSDWKB"), "") '回収曜日
            DB_TOKMTA_W.TOKKDWKB = DB_NullReplace(Usr_Ody.Rows(i)("TOKKDWKB"), "") '締め曜日
            DB_TOKMTA_W.TOKTL = DB_NullReplace(Usr_Ody.Rows(i)("TOKTL"), "") '得意先電話番号
            DB_TOKMTA_W.TOKSEICD = DB_NullReplace(Usr_Ody.Rows(i)("TOKSEICD"), "") '請求先コード
            '2019/04/23 CHG E N D

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

            '2019/04/23 CHG START
            '     Call CF_Ora_MoveNext(Usr_Ody)
            'Loop 
        Next
        '2019/04/23 CHG E N D

        '取得データ有無に関わらず最終データ到達
        WM_WLS_LastFL = True
		
		If Cnt > 0 Then
			'１ページを表示
			WM_WLS_Pagecnt = 0
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
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
		Dim WL_Mode As Short
		Dim intCnt As Short
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		LST.Items.Clear()
		intCnt = 0
		Do While intCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
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
	'UPGRADE_WARNING: Form イベント WLS_TOK2.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_TOK2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		'Call WLS_Kana_Init
		'HD_CODE.Text = ""
		'HD_NAME.Text = ""
		'WLSKANA.ListIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'初期状態全件表示
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		'HD_CODE.SetFocus
	End Sub
	
	Private Sub WLS_TOK2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	'得意先略称項目でキーを押した時
	Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
		'全選択状態にする
		HD_RN.SelectionStart = 0
		HD_RN.SelectionLength = 40
	End Sub
	
	'得意先略称項目でキーを押した時
	Private Sub HD_RN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_RN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter押下時に再検索を実行
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WLSKANA.SelectedIndex = -1
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'得意先ｺｰﾄﾞ項目にフォーカスが移動した時
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'全選択状態にする
		HD_TEXT.SelectionStart = 0
		HD_TEXT.SelectionLength = 5
	End Sub
	
	'得意先ｺｰﾄﾞ項目でキーを押した時
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Enter押下時に再検索を実行
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WLSKANA.SelectedIndex = -1
			Call WLS_Clear()
			Call WLS_TextSQL()
			Call WLS_DspNew()
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
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '2019/05/31 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '2019/05/31 CHG E N D
    End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
            'Enterキー押下
            Case System.Windows.Forms.Keys.Return
                '2019/05/31 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '2019/05/31 CHG E N D
                'Escapeキー押下
            Case System.Windows.Forms.Keys.Escape
                '2019/05/31 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '2019/05/31 CHG E N D
                '←キー押下
            Case System.Windows.Forms.Keys.Left
                '2019/05/31 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '2019/05/31 CHG E N D
                '→キー押下
            Case System.Windows.Forms.Keys.Right
                '2019/05/31 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '2019/05/31 CHG E N D
                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '2019/05/31 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '	If LST.Items.Count <= 0 Then Exit Sub

    '	If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '		If Not WM_WLS_LastFL Then Call WLS_DspPage()
    '	Else
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '		Call WLS_DspPage()
    '	End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSATO.Image = IM_ATO(1).Image
    'End Sub

    '   Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       WLSATO.Image = IM_ATO(0).Image
    '   End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspPage()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '2019/05/31 CHG E N D

    'UPGRADE_WARNING: イベント WLSKANA.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
    Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
        Dim W_BUF As New VB6.FixedLengthString(2)

        Call WLS_Clear()

        '検索用変数セット
        If WLSKANA.SelectedIndex > 0 Then
            W_BUF.Value = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
            WM_WLS_TOKNK_S = VB.Left(W_BUF.Value, 1)
            WM_WLS_TOKNK_E = Chr(Asc(VB.Right(W_BUF.Value, 1)) + 1)
            '他検索条件クリア
            HD_TEXT.Text = ""
            HD_RN.Text = ""

            Call WLS_TextSQL()
            Call WLS_DspNew()
        Else
            '            W_BUF = ""
            '            WM_WLS_TOKNK_S = ""
            '            WM_WLS_TOKNK_E = ""
            '他検索条件クリア
            HD_TEXT.Text = ""
            HD_RN.Text = ""

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    '2019/05/31 CHG START
    '   Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '	If WM_WLS_Pagecnt > 0 Then
    '		WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '		Call WLS_DspPage()
    '	End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	WLSMAE.Image = IM_MAE(0).Image
    'End Sub
    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '2019/05/31 CHG E N D

    '2019/05/31 CHG START
    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '	WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '	Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	Hide()
    'End Sub
    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click

        DblClickFl = True
#Disable Warning BC40000 ' Type or member is obsolete
        WLSTOK_RTNCODE = Trim(LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN))
        Call btnF12_Click(WLSCANCEL, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Hide()
    End Sub
    '2019/05/31 CHG E N D

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Kana_Init
    '   概要：  カナコンボボックス初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Kana_Init()
		
		'カナ検索 Combo 初期化
		WLSKANA.Items.Clear()
		WLSKANA.Items.Add("コード")
		WLSKANA.Items.Add("ア行      ｱｵ")
		WLSKANA.Items.Add("カ行      ｶｺ")
		WLSKANA.Items.Add("サ行      ｻｿ")
		WLSKANA.Items.Add("タ行      ﾀﾄ")
		WLSKANA.Items.Add("ナ行      ﾅﾉ")
		WLSKANA.Items.Add("ハ行      ﾊﾎ")
		WLSKANA.Items.Add("マ行      ﾏﾓ")
		WLSKANA.Items.Add("ヤ行      ﾔﾖ")
		WLSKANA.Items.Add("ラ行      ﾗﾛ")
		WLSKANA.Items.Add("ワ行      ﾜﾝ")
		
	End Sub

    '2019/05/31 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_RN.Focused Then
                Call HD_RN_KeyDown(HD_RN, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面検索エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_TEXT.Text = ""
            Me.HD_RN.Text = ""
            LST.Items.Clear()
            Me.HD_TEXT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("画面クリアエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub WLS_TOK2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Sub

    'DELETE 20190808 START
    'Private Sub InitializeComponent()
    '    Me.SuspendLayout()
    '    '
    '    'WLS_TOK2
    '    '
    '    Me.ClientSize = New System.Drawing.Size(284, 259)
    '    Me.Name = "WLS_TOK2"
    '    Me.ResumeLayout(False)
    'End Sub
    'DELETE 20190808 END 

    '2019/05/31 ADD E N D
End Class