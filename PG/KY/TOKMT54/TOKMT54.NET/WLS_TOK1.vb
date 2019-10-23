Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSTOK
	Inherits System.Windows.Forms.Form
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
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	' === 20060730 === UPDATE E -
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	'ウィンドﾕｰｻﾞｰ設定変数
	Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Private WM_WLS_CODELEN As Short '開始ｺｰﾄﾞ入力文字数
	Private WM_WLS_NAMELEN As Short '得意先略称入力文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_CODE As String '得意先コード検索用
	Private WM_WLS_TOKRN As String '得意先略称検索用
	Private WM_WLS_TOKNK_S As String '得意先カナ検索用(開始)
	Private WM_WLS_TOKNK_E As String '得意先カナ検索用(終了)
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_TOKMAT_W As TYPE_DB_TOKMTA '検索結果退避
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
		WM_WLS_MAX = 15 '画面表示件数
		'変数初期化
		WLSTOK_RTNCODE = ""
		Call WLS_Clear()
		
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
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMAT_W.TOKSDWKB)) & "締      " & SSS_WEEKNM(SSSVal(DB_TOKMAT_W.TOKKDWKB)) & "回収"
			Case Else
				WK_SMENM = Space(8)
		End Select
		'
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TOKMAT_W.TOKCD, 5) & Space(1) & LeftWid(DB_TOKMAT_W.TOKRN, 30) & Space(1) & WK_SMENM & WK_KESNM & Space(2) & WK_ZEINM & Space(2) & LeftWid(DB_TOKMAT_W.TOKTL, 13) & Space(1) & DB_TOKMAT_W.TOKSEICD
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_TextSQL
	'   概要：  検索sql作成
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Dim strSQL As String
		Dim intData As Short
		
		strSQL = ""
		strSQL = strSQL & " Select TOKCD " '得意先コード
		strSQL = strSQL & "      , TOKRN " '得意先略称
		strSQL = strSQL & "      , TOKZEIKB " '消費税区分
		strSQL = strSQL & "      , TOKSMEKB " '締区分
		strSQL = strSQL & "      , TOKSMEDD " '締初期日付（売上）
		strSQL = strSQL & "      , TOKKESCC " '回収サイクル
		strSQL = strSQL & "      , TOKKESDD " '回収日付
		strSQL = strSQL & "      , TOKSDWKB " '締め曜日
		strSQL = strSQL & "      , TOKKDWKB " '回収曜日
		strSQL = strSQL & "      , TOKTL " '得意先電話番号
		strSQL = strSQL & "      , TOKSEICD " '請求先コード
		strSQL = strSQL & "   from TOKMTA "
		' === 20060814 === UPDATE S - ACE)Nagasawa
		'        strSQL = strSQL & "  Where DATKB = '1' "
		'' === 20060728 === INSERT S - ACE)Furukawa
		'        strSQL = strSQL & "  And   DSPKB = '1' "    '検索表示区分
		'' === 20060728 === INSERT E
		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "  And   DSPKB = '" & gc_strDSPKB_OK & "' " '検索表示区分
		' === 20060926 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "  And   THSCD <> '" & gc_strTHSCD_SIR & "' " '取引先分類
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
		Dim Cnt As Integer
		Dim Wk_Pagecnt As Short
		
		Cnt = 0
		Wk_Pagecnt = -1
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'取得内容退避
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "") '消費税区分
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "") '締区分
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "") '締初期日付（売上）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "") '回収サイクル締初期日付（売上）
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "") '回収日付
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "") '回収曜日
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "") '締め曜日
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "") '得意先電話番号
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMAT_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '請求先コード
			
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
	'   名称：  Sub WLS_Kana_Init
	'   概要：  カナコンボボックス初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Kana_Init()
		
		'カナ検索 Combo 初期化
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
	'UPGRADE_WARNING: Form イベント WLSTOK.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSTOK_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		Call WLS_Kana_Init()
		HD_CODE.Text = ""
		HD_NAME.Text = ""
		WLSKANA.SelectedIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'初期状態全件表示
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		' === 20060821 === UPDATE S - ACE)Nagasawa
		'        HD_CODE.SetFocus
		' === 20061228 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20061228 === INSERT E -
		LST.Focus()
		' === 20060821 === UPDATE E -
	End Sub
	
	Private Sub WLSTOK_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: オブジェクト LenWid(HD_CODE.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			'---------- 20061019 ACE MENTE START ----------
			'   Else
			'       HD_CODE.Text = Space$(HD_CODE.MaxLength)
			'---------- 20061019 ACE MENTE E N D ----------
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox プロパティ HD_CODE.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_CODE = HD_CODE.Text
			
			'他検索条件クリア
			WLSKANA.SelectedIndex = 0
			HD_NAME.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock入力対応
	Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	' === 20070206 === UPDATE E -
	
	Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
		'---------- 20061019 ACE MENTE START ----------
		'   If LenWid(HD_NAME.Text) <= 0 Then
		'       HD_NAME.Text = Space$(HD_NAME.MaxLength)
		'   End If
		'---------- 20061019 ACE MENTE E N D ----------
		HD_NAME.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_NAME.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_NAME.SelectionLength = HD_NAME.Maxlength
	End Sub
	
	Private Sub HD_NAME_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NAME.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_TOKRN = HD_NAME.Text
			
			'他検索条件クリア
			WLSKANA.SelectedIndex = 0
			HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enterキー押下
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escapeキー押下
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				
				'←キー押下
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'→キー押下
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: イベント WLSKANA.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		
		Call WLS_Clear()
		
		'検索用変数セット
		If WLSKANA.SelectedIndex > 0 Then
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_TOKNK_S = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_TOKNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
			'他検索条件クリア
			HD_CODE.Text = ""
			HD_NAME.Text = ""
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
		
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspPage()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		WLSTOK_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		Hide()
	End Sub
End Class