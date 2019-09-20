Option Strict Off
Option Explicit On
Friend Class WLSFBD2
	Inherits System.Windows.Forms.Form
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　検索ウィンドウ
	'*  プログラム名　　：　ＦＢデータ検索
	'*  プログラムＩＤ　：  WLSFBD2
	'*  作成者　　　　　：　RISE)宮島
	'*  作成日　　　　　：  2008.08.26
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
    '20190619 chg start
    'Private WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_MFIL As Object 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    '20190619 chg end
    Private WM_WLS_FBCLTCDLEN As Short 'ﾊﾞｰﾁｬﾙｺｰﾄﾞ入力文字数
	Private WM_WLS_FBCLTNMLEN As Short '得意先名称入力文字数
	Private WM_WLS_FBBNKNKLEN As Short '銀行ｶﾅ名称入力文字数
	Private WM_WLS_FBSTNNKLEN As Short '支店ｶﾅ名称入力文字数
	Private WM_WLS_FBRFNOLEN As Short '照会番号文字数
	
	'ウィンド内部使用変数
	Private WM_WLS_MAX As Short '１画面の表示件数
	Private WM_WLS_FBCLTCD As String 'ﾊﾞｰﾁｬﾙｺｰﾄﾞ検索用
	Private WM_WLS_FBCLTNM As String '得意先名称検索用
	Private WM_WLS_FBBNKNK As String '銀行ｶﾅ名称検索用
	Private WM_WLS_FBSTNNK As String '支店ｶﾅ名称検索用
	
	Private WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Private WM_WLS_LastPage As Short 'ウィンド最終ページ
	Private WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Private WM_WLS_DSPArray() As String 'ウィンド表示データ
	Private WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	
	Private DblClickFl As Boolean
	
	'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private Usr_Ody As U_Ody 'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
	Private DB_FBTRA_W As TYPE_DB_FBTRA '検索結果退避
	Private Dyn_Open As Boolean 'ダイナセット状態（True:Open False:Close)
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_FORM_INIT
	'   概要：  画面初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_FBCLTCDLEN = 10
		WM_WLS_FBCLTNMLEN = 48
		WM_WLS_FBBNKNKLEN = 15
		WM_WLS_FBSTNNKLEN = 15
		WM_WLS_FBRFNOLEN = 6
		WM_WLS_MAX = 19 '画面表示件数
		'変数初期化
		WLSFBTRA2_RTNCODE = ""
		Call WLS_Clear()
		Dyn_Open = False
		
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
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_FBTRA_W.FBCLTCD, WM_WLS_FBCLTCDLEN) & Space(1) & LeftWid(DB_FBTRA_W.FBCLTNM, WM_WLS_FBCLTNMLEN) & Space(1) & LeftWid(DB_FBTRA_W.FBBNKNK, WM_WLS_FBBNKNKLEN) & Space(1) & LeftWid(DB_FBTRA_W.FBSTNNK, WM_WLS_FBSTNNKLEN) & Space(1) & DB_FBTRA_W.FBRFNO
		
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
		strSQL = strSQL & " Select FBCLTCD " 'ﾊﾞｰﾁｬﾙｺｰﾄﾞ
		strSQL = strSQL & "      , FBCLTNM " '得意先名称
		strSQL = strSQL & "      , FBBNKNK " '銀行ｶﾅ名称
		strSQL = strSQL & "      , FBSTNNK " '支店ｶﾅ名称
		strSQL = strSQL & "      , FBRFNO " '照会番号
		strSQL = strSQL & "   from FBTRA "
		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
		
		'ﾊﾞｰﾁｬﾙｺｰﾄﾞ検索
		If Trim(WM_WLS_FBCLTCD) <> "" Then
			strSQL = strSQL & "    and FBCLTCD >=   '" & WM_WLS_FBCLTCD & "'"
		End If
		
		'得意先名称検索(あいまい検索)
		If Trim(WM_WLS_FBCLTNM) <> "" Then
			strSQL = strSQL & "    and FBCLTNM LIKE '%" & WM_WLS_FBCLTNM & "%'"
		End If
		
		'銀行ｶﾅ名称検索(あいまい検索)
		If Trim(WM_WLS_FBBNKNK) <> "" Then
			strSQL = strSQL & "    and FBCLTNM LIKE '%" & WM_WLS_FBBNKNK & "%'"
		End If
		
		'支店ｶﾅ名称検索(あいまい検索)
		If Trim(WM_WLS_FBSTNNK) <> "" Then
			strSQL = strSQL & "    and FBCLTNM LIKE '%" & WM_WLS_FBSTNNK & "%'"
		End If
		
		'ソート条件
		strSQL = strSQL & "   order by "
		strSQL = strSQL & "   FBCLTCD "
		strSQL = strSQL & "  ,FBRFNO "
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
        'DBアクセス
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/02 CHG E N D
		Dyn_Open = True
		LST.Items.Clear()
		
	End Sub
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub WLS_DspNew
	'   概要：  リスト編集処理(初期情報)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim cnt As Integer
		
        cnt = 0

        '2019/04/05 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'取得内容退避
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_FBTRA_W.FBCLTCD = CF_Ora_GetDyn(Usr_Ody, "FBCLTCD", "") 'ﾊﾞｰﾁｬﾙｺｰﾄﾞ
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_FBTRA_W.FBCLTNM = CF_Ora_GetDyn(Usr_Ody, "FBCLTNM", "") '得意先名称
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_FBTRA_W.FBBNKNK = CF_Ora_GetDyn(Usr_Ody, "FBBNKNK", "") '銀行ｶﾅ名称
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_FBTRA_W.FBSTNNK = CF_Ora_GetDyn(Usr_Ody, "FBSTNNK", "") '支店ｶﾅ名称
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_FBTRA_W.FBRFNO = CF_Ora_GetDyn(Usr_Ody, "FBRFNO", "") '照会番号

        '	'表示改ページ
        '	If cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		cnt = 0
        '		'最終ページ退避
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'表示メモリ展開
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

        '	cnt = cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '取得内容退避
            DB_FBTRA_W.FBCLTCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("FBCLTCD"), "") 'ﾊﾞｰﾁｬﾙｺｰﾄﾞ
            DB_FBTRA_W.FBCLTNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("FBCLTNM"), "") '得意先名称
            DB_FBTRA_W.FBBNKNK = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("FBBNKNK"), "") '銀行ｶﾅ名称
            DB_FBTRA_W.FBSTNNK = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("FBSTNNK"), "") '支店ｶﾅ名称
            DB_FBTRA_W.FBRFNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("FBRFNO"), "") '照会番号

            '表示改ページ
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
                '最終ページ退避
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1

            'If cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next
        '2019/04/05 CHG E N D

        '最終データ到達
        '20190409 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    WM_WLS_LastFL = True
        'End If
        WM_WLS_LastFL = True
        '20190409 CHG END

        If cnt > 0 Then
            'ページを表示
            WM_WLS_Pagecnt = 0

            Call WLS_DspPage()
            '20190409 ADD START
        Else
            LST.Items.Clear()
            '20190409 ADD END
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
			On Error Resume Next
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
	Sub WLS_Clear()
		
		'検索条件
		WM_WLS_FBCLTCD = ""
		WM_WLS_FBCLTNM = ""
		WM_WLS_FBBNKNK = ""
		WM_WLS_FBSTNNK = ""
		
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
	'UPGRADE_WARNING: Form イベント WLSFBD2.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSFBD2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'項目初期化
		HD_TEXT.Text = ""
		WLSCD.Text = ""
		WLSNM1.Text = ""
		WLSNM2.Text = ""
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		'初期状態全件表示
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		On Error Resume Next
		LST.Focus()
	End Sub
	
	Private Sub WLSFBD2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'UPGRADE_WARNING: オブジェクト LenWid(HD_TEXT.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(HD_TEXT.Text) > 0 Then
			'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
		End If
		HD_TEXT.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_TEXT.SelectionLength = HD_TEXT.Maxlength
	End Sub
	
	Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_FBCLTCD = HD_TEXT.Text
			
			'他検索条件クリア
			WLSCD.Text = ""
			WLSNM1.Text = ""
			WLSNM2.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_TEXT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TEXT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		KeyAscii = Asc(UCase(Chr(KeyAscii)))
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub WLSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCD.Enter
		WLSCD.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ WLSCD.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		WLSCD.SelectionLength = WLSCD.Maxlength
	End Sub
	
	Private Sub WLSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_FBCLTNM = WLSCD.Text
			
			'他検索条件クリア
			HD_TEXT.Text = ""
			WLSNM1.Text = ""
			WLSNM2.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub WLSNM1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNM1.Enter
		WLSNM1.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ WLSNM1.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		WLSNM1.SelectionLength = WLSNM1.Maxlength
	End Sub
	
	Private Sub WLSNM1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNM1.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_FBCLTNM = WLSNM1.Text
			
			'他検索条件クリア
			HD_TEXT.Text = ""
			WLSCD.Text = ""
			WLSNM2.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub WLSNM2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSNM2.Enter
		WLSNM2.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ WLSNM2.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		WLSNM2.SelectionLength = WLSNM2.Maxlength
	End Sub
	
	Private Sub WLSNM2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSNM2.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'検索用変数セット
			Call WLS_Clear()
			WM_WLS_FBCLTNM = WLSNM2.Text
			
			'他検索条件クリア
			HD_TEXT.Text = ""
			WLSCD.Text = ""
			WLSNM1.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		WLSFBTRA2_RTNCODE = RightWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_FBRFNOLEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KEYCODE
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
		WLSFBTRA2_RTNCODE = RightWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_FBRFNOLEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		
		If Dyn_Open = True Then
			'クローズ
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		
		Hide()
	End Sub
End Class