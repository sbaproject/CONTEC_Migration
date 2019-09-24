Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSHIN
	Inherits System.Windows.Forms.Form
	'以下の ３行の設定を行うこと
	Const WM_WLS_MSTKB As String = "5" 'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
	Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	Const WM_WLS_KanaINPUT As Boolean = False 'カナ直接入力使用（True:直接入力 False:カナコンボ）
	
	'検索キーNo（使用しない場合は-1を設定）
	Const WM_WLS_NmaKey As Short = 1 '型式コードのソートキーNo
	Const WM_WLS_TextKey As Short = 2 '開始コードのソートキーNo
	Const WM_WLS_KanaKey As Short = 3 'カナ検索のソートキーNo+第一キー
	
	'ウィンドﾕｰｻﾞｰ設定変数
	Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Dim WM_WLS_NMALEN As Short '型式入力文字数
	Dim WM_WLS_LEN As Short '開始ｺｰﾄﾞ入力文字数
	Dim WM_WLS_KANALEN As Short 'カナ入力文字数
	
	'ウィンド内部使用変数
	Dim WM_WLS_MAX As Short '１画面の表示件数
	Dim WM_WLS_STTKEY As Object '開始キー
	Dim WM_WLS_ENDKEY As Object '終了キー
	Dim WM_WLS_KeyNo As Short 'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
	Dim WM_WLS_Pagecnt As Short 'ウィンド表示ページカウンタ
	Dim WM_WLS_LastPage As Short 'ウィンド最終ページ
	Dim WM_WLS_LastFL As Boolean 'ウィンド最終データ到達フラグ
	Dim WM_WLS_DSPArray() As String 'ウィンド表示データ
	Dim WM_WLS_Dspflg As Short 'ウィンド表示ﾌﾗｸﾞ(True or False)
	Dim WM_WLS_INIT As Short 'ウィンド初期表示ﾌﾗｸﾞ(True or False)
	
	Dim WlsSelList As String
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	Dim DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	Private Sub WLS_FORM_INIT()
		'=== WINDOW 表示ファイル設定 ===
		WM_WLS_MFIL = DBN_HINMTA
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_NMALEN = Len(DB_HINMTA.HINNMA) 'LenWid はダメ
		'    WM_WLS_LEN = Len(DB_HINMTA.HINCD)     'LenWid はダメ
		WM_WLS_LEN = 8
		WM_WLS_KANALEN = Len(DB_HINMTA.HINNK) 'LenWid はダメ
		WlsSelList = "HINCD, HINNMA, HINNMB, DATKB, KHNKB,DSPKB"
		
		'=== ＬＡＢＥＬ設定 ===
		'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSLABEL = "製品ｺｰﾄﾞ 型　　式                       品　　名                                          "
		'XXXXXXX8 XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3 MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5
		
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
		'HD_TEXT.Height = 330
		'    HD_NMA.MaxLength = WM_WLS_NMALEN
		'    HD_NMA.Width = (WM_WLS_NMALEN + 1) * 120
		'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_TEXT.Maxlength = WM_WLS_LEN
		HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)
		WM_WLS_INIT = True
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		Dim wkHINCD As String
		wkHINCD = DB_HINMTA.HINCD
		If DB_HINMTA.DATKB = "9" Then
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLS_DSP_CHECK = SSS_NEXT
		Else
			If DB_HINMTA.KHNKB = "9" Then
				'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLS_DSP_CHECK = SSS_NEXT
			Else
				If DB_HINMTA.DSPKB = "1" Then
					'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_DSP_CHECK = SSS_OK
				Else
					'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WLS_DSP_CHECK = SSS_NEXT
				End If
			End If
		End If
	End Function
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		Dim LeftWid As Object
		'====================================
		'   WINDOW 明細設定
		'====================================
		'UPGRADE_WARNING: オブジェクト LeftWid$(DB_HINMTA.HINNMB, 50) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LeftWid$(DB_HINMTA.HINNMA, 30) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LeftWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA.HINCD, 8) & " " & LeftWid(DB_HINMTA.HINNMA, 30) & " " & LeftWid(DB_HINMTA.HINNMB, 50)
	End Sub
	
	Sub WLS_KbSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
		'    WlsFromWhere = "From HINMTA Where HINKB = '" & WM_WLS_STTKEY & "'"
		'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WlsFromWhere = "From HINMTA Where HINKB = '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		
		WlsOrderBy = "Order By HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
		'    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(WM_WLS_STTKEY) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " AND DSPKB = '1' " & " UNION ALL " & "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " AND DSPKB = '9' " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_NmaSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_NmaKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		
		' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D    WlsFromWhere = "From HINMTA Where HINNMA Like " & "'%" & WM_WLS_STTKEY & "%'"
		'D    If Trim(WLSHINKB.Text) <> "" Then
		'D        'DWlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
		'D    End If
		'D
		'D    WlsOrderBy = "Order By HINCD"
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		Dim strSQL As String
		
		strSQL = " SELECT "
		
		'ヒント句の設定
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case True
			'条件がない場合
			Case Trim(WM_WLS_STTKEY) = "" And Trim(WLSHINKB.Text) = ""
				strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA01) */ "
				
				'上記以外
			Case Else
				strSQL = strSQL & " /*+ INDEX(HINMTA X_HINMTA06) */ "
				
		End Select
		
		'取得項目編集
		strSQL = strSQL & WlsSelList
		
		'検索条件
		'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & " FROM HINMTA WHERE HINNMA Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'" '型式
		If Trim(WLSHINKB.Text) <> "" Then '商品区分
			'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & " AND HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
		End If
		
		'SQLの編集（ユニオンさせる）
		DB_SQLBUFF = strSQL
		DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '1' "
		DB_SQLBUFF = DB_SQLBUFF & " UNION ALL "
		DB_SQLBUFF = DB_SQLBUFF & strSQL
		DB_SQLBUFF = DB_SQLBUFF & " AND DSPKB = '9' "
		DB_SQLBUFF = DB_SQLBUFF & " ORDER BY HINCD "
		' === 20081205 === UPDATE E
		
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_TextSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
		'    WlsFromWhere = "From HINMTA Where HINCD >= '" & WM_WLS_STTKEY & "'"
		'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WlsFromWhere = "From HINMTA Where HINCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		If Trim(WLSHINKB.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
			'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		WlsOrderBy = "Order By HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		'商品区分が入力されている場合
		If Trim(WLSHINKB.Text) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " and DSPKB = '1' " & " UNION ALL " & " SELECT /*+ INDEX(HINMTA X_HINMTA06) */ " & WlsSelList & " " & WlsFromWhere & " and DSPKB = '9' " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA01) */ " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_KanaSQL()
		Dim AE_EditSQLText As Object
		WM_WLS_KeyNo = WM_WLS_KanaKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
		'    WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & WM_WLS_ENDKEY & "'"
		'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WlsFromWhere = "From HINMTA Where HINNK >= '" & WM_WLS_STTKEY & "' And HINNK < '" & AE_EditSQLText(WM_WLS_ENDKEY) & "'"
		'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		'WlsOrderBy = "Order By HINNK, HINCD"
		If Trim(WLSHINKB.Text) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
			'        WlsFromWhere = WlsFromWhere & " and HINKB = '" & WLSHINKB.Text & "'"
			'UPGRADE_WARNING: オブジェクト AE_EditSQLText() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = WlsFromWhere & " and HINKB = '" & AE_EditSQLText(WLSHINKB.Text) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		WlsOrderBy = "Order By  HINCD"
		' === 20081205 === UPDATE S - ACE)Nagasawa レスポンス対応
		'D    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(WM_WLS_STTKEY) <> "" Then
			DB_SQLBUFF = "Select /*+ INDEX(HINMTA X_HINMTA02) */ " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Else
			DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		End If
		' === 20081205 === UPDATE E
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Private Sub WLS_DspNew()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		WL_Mode = 0
		cnt = 0
		Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_Mode = WLS_DSP_CHECK()
			If WL_Mode = SSS_OK Then
				If cnt = 0 Then
					WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
					WM_WLS_LastPage = WM_WLS_Pagecnt
					ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
				End If
				Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
				cnt = cnt + 1
			End If
			If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
				Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
			End If
		Loop 
		If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
		If cnt > 0 Then
			Call WLS_DspPage()
		Else
			LST.Items.Clear()
		End If
	End Sub
	
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim cnt As Short
		
		LST.Items.Clear()
		cnt = 0
		Do While cnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
			End If
			cnt = cnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
		End If
	End Sub
	
	Sub WLS_Kana_Init()
		
		'カナ検索 Combo 初期化
		'この一行を実行しないと, WLSKANA.ListIndex = 0 でエラーになる
		WLSKANA.Items.Add("コード")
		
		If WM_WLS_KanaKey < 1 Then
			'カナ検索をしない
			'UPGRADE_WARNING: オブジェクト PNL_USENM().Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PNL_USENM(3).Visible = False
			WLSKANA.Visible = False
			HD_Kana.Visible = False
		ElseIf WM_WLS_KanaINPUT Then 
			'カナ手入力項目の有効化
			WLSKANA.Visible = False
			HD_Kana.Visible = True
			HD_Kana.Width = WLSKANA.Width
			HD_Kana.Left = WLSKANA.Left
		Else
			WLSKANA.Items.Add("ア        ｱｵ")
			WLSKANA.Items.Add("カ        ｶｺ")
			WLSKANA.Items.Add("サ        ｻｿ")
			WLSKANA.Items.Add("タ        ﾀﾄ")
			WLSKANA.Items.Add("ナ        ﾅﾉ")
			WLSKANA.Items.Add("ハ        ﾊﾎ")
			WLSKANA.Items.Add("マ        ﾏﾓ")
			WLSKANA.Items.Add("ヤ        ﾔﾖ")
			WLSKANA.Items.Add("ラ        ﾗﾛ")
			WLSKANA.Items.Add("ワ        ﾜﾝ")
		End If
	End Sub
	
	Private Sub COM_HINKB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_HINKB.Click
		Dim LenWid As Object
		Dim LeftWid As Object
		Dim wkHINKB As String
		Dim strSQL As String
		Dim W_BUF As Object
		
		WLS_MEI1.Text = "商品区分一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "077", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "077"
			If DB_MEIMTA.DATKB <> "9" Then
				'UPGRADE_WARNING: オブジェクト LeftWid(DB_MEIMTA.MEINMA, 40) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LeftWid(DB_MEIMTA.MEICDA, 5) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		PP_SSSMAIN.SlistCom = System.DBNull.Value
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		System.Windows.Forms.Application.DoEvents()
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(PP_SSSMAIN.SlistCom) Then
			WM_WLS_Dspflg = False
			System.Windows.Forms.Application.DoEvents()
			WM_WLS_Dspflg = True
			Exit Sub
		Else
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト LeftWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkHINKB = LeftWid(PP_SSSMAIN.SlistCom, 2) & Space(Len(DB_MEIMTA.MEICDA) - Len(LeftWid(PP_SSSMAIN.SlistCom, 2)))
			Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
			If DBSTAT = 0 Then
				WLSHINKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
				'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
				WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
				
				Select Case True
					
					Case Trim(HD_NMA.Text) <> ""
						WM_WLS_Dspflg = False
						HD_TEXT.Text = ""
						WLSKANA.SelectedIndex = 0
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_STTKEY = HD_NMA.Text
						'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_ENDKEY = HD_NMA.Text
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_NmaSQL()
						Call WLS_DspNew()
					Case Trim(HD_TEXT.Text) <> ""
						WM_WLS_Dspflg = False
						'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
						HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_STTKEY = HD_TEXT.Text
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_ENDKEY = System.DBNull.Value
						WLSKANA.SelectedIndex = 0
						HD_NMA.Text = ""
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_TextSQL()
						Call WLS_DspNew()
					Case WLSKANA.SelectedIndex > 0
						HD_TEXT.Text = ""
						HD_NMA.Text = ""
						'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
						'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_STTKEY = VB.Left(W_BUF, 1)
						'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
						ReDim WM_WLS_DSPArray(0)
						Call WLS_KanaSQL()
						Call WLS_DspNew()
						
					Case Else
						WM_WLS_Dspflg = False
						HD_TEXT.Text = ""
						WLSKANA.SelectedIndex = 0
						HD_NMA.Text = ""
						'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_STTKEY = WLSHINKB.Text
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						WM_WLS_ENDKEY = System.DBNull.Value
						WM_WLS_Dspflg = True
						WM_WLS_Pagecnt = -1
						WM_WLS_LastPage = -1
						WM_WLS_LastFL = False
						ReDim WM_WLS_DSPArray(0)
						
						Call WLS_KbSQL()
						Call WLS_DspNew()
				End Select
				'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				PP_SSSMAIN.SlistCom = System.DBNull.Value
			Else
				Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
				Call P_SetFocus(WLSHINKB)
				WLSHINKB.SelectionStart = 0
				WLSHINKB.SelectionLength = Len(WLSHINKB.Text)
			End If
		End If
		
	End Sub
	
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLSHIN.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLSHIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'=== WINDOW 位置設定 ===
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		If WM_WLS_INIT = True Then
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = ""
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = System.DBNull.Value
			HD_NMA.Text = ""
			HD_TEXT.Text = ""
			WM_WLS_Dspflg = False
			WLSKANA.SelectedIndex = 0
			HD_Kana.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			'''' UPD 2011/02/07  FKS) T.Yamamoto    Start    連絡票№FC11020701
			'画面表示時に検索しない
			'        Call WLS_TextSQL
			'        Call WLS_DspNew
			'デフォルトで製品を設定
			WLSHINKB.Text = "1"
			Call DB_GetEq(DBN_MEIMTA, 2, "077" & WLSHINKB.Text, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
				WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
			End If
			Call P_SetFocus(HD_NMA)
			'''' UPD 2011/02/07  FKS) T.Yamamoto    End
			WM_WLS_INIT = False
		End If
		
		'DblClickイベント障害対応  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLSHIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
		Call WLS_Kana_Init()
	End Sub
	
	Private Sub HD_Kana_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Kana.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = HD_Kana.Text
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = Chr(Asc("ﾝ") + 1)
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_KanaSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_Kana_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_Kana.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii < Asc(" ") Then GoTo EventExitSub
		''2000/04/18 カナ入力文字範囲の誤りを修正
		''If KeyAscii < Asc("ｱ") Or KeyAscii > Asc("ﾝ") Then
		If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then GoTo EventExitSub
		If KeyAscii < Asc("｡") Or KeyAscii > Asc("ﾟ") Then
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: イベント HD_NMA.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_NMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NMA.TextChanged
		Dim S As Integer
		S = HD_NMA.SelectionStart
		HD_NMA.Text = StrConv(HD_NMA.Text, VbStrConv.UpperCase)
		HD_NMA.SelectionStart = S
	End Sub
	
	Private Sub HD_NMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NMA.Enter
		''    If LenWid(HD_NMA.Text) > 0 Then
		''        HD_NMA.Text = SSS_EDTITM_WLS(HD_NMA.Text, HD_NMA.MaxLength, WM_WLSKEY_ZOKUSEI)
		''    Else
		''        HD_NMA.Text = Space$(HD_NMA.MaxLength)
		''    End If
		HD_NMA.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_NMA.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_NMA.SelectionLength = HD_NMA.Maxlength
	End Sub
	
	Private Sub HD_NMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			WLSKANA.SelectedIndex = 0
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = HD_NMA.Text
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = HD_NMA.Text
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_NmaSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	'UPGRADE_WARNING: イベント HD_TEXT.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
		Dim S As Integer
		S = HD_TEXT.SelectionStart
		HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.UpperCase)
		HD_TEXT.SelectionStart = S
	End Sub
	
	Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
		'''    If LenWid(HD_TEXT.Text) > 0 Then
		'''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
		'''    Else
		'''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
		'''    End If
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
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = HD_TEXT.Text
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = System.DBNull.Value
			WLSKANA.SelectedIndex = 0
			HD_NMA.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'DblClickイベント障害対応  97/04/07
		DblClickFl = True
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UnLoadイベント障害対応  97/04/07
		If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Select Case KEYCODE
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
			Case System.Windows.Forms.Keys.Left '←キー
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
			Case System.Windows.Forms.Keys.Right '→キー
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
	End Sub
	
	Private Sub WLSHINKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSHINKB.Enter
		Dim LenWid As Object
		WLSHINKB.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSHINKB.SelectionLength = LenWid(DB_HINMTA.HINKB)
	End Sub
	
	Private Sub WLSHINKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSHINKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim LenWid As Object
		Dim i As Object
		Dim STAT As Short
		Dim wkHINKB As String
		Dim strSQL As String
		Dim W_BUF As Object
		
		Select Case KEYCODE
			Case 13
				WM_WLS_Dspflg = False
				WLSHINKB.Text = SSS_EDTITM_WLS(WLSHINKB.Text, LenWid(DB_HINMTA.HINKB), "0")
				WLSHINKB.SelectionStart = 0
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WLSHINKB.SelectionLength = LenWid(DB_HINMTA.HINKB)
				If Trim(WLSHINKB.Text) = "" Then
					WM_WLS_Dspflg = False
					WLSHINKB.Text = ""
					WLSHINKBNM.Text = ""
					'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
					WLSKANA.SelectedIndex = 0
					HD_NMA.Text = ""
					WM_WLS_Dspflg = True
					WM_WLS_Pagecnt = -1
					WM_WLS_LastPage = -1
					WM_WLS_LastFL = False
					ReDim WM_WLS_DSPArray(0)
					
					Call WLS_TextSQL()
					Call WLS_DspNew()
				Else
					wkHINKB = WLSHINKB.Text & Space(Len(DB_MEIMTA.MEICDA) - Len(WLSHINKB.Text)) & Space(Len(DB_MEIMTA.MEICDB))
					Call DB_GetEq(DBN_MEIMTA, 2, "077" & wkHINKB, BtrNormal)
					If DBSTAT = 0 Then
						WLSHINKB.Text = VB.Left(DB_MEIMTA.MEICDA, 2)
						'UPGRADE_ISSUE: LeftB$ 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
						WLSHINKBNM.Text = LeftB$(DB_MEIMTA.MEINMA, 16)
						Select Case True
							
							Case Trim(HD_NMA.Text) <> ""
								WM_WLS_Dspflg = False
								HD_TEXT.Text = ""
								WLSKANA.SelectedIndex = 0
								'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_STTKEY = HD_NMA.Text
								'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_ENDKEY = HD_NMA.Text
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_NmaSQL()
								Call WLS_DspNew()
							Case Trim(HD_TEXT.Text) <> ""
								WM_WLS_Dspflg = False
								'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
								HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
								'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_STTKEY = HD_TEXT.Text
								'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_ENDKEY = System.DBNull.Value
								WLSKANA.SelectedIndex = 0
								HD_NMA.Text = ""
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_TextSQL()
								Call WLS_DspNew()
							Case WLSKANA.SelectedIndex > 0
								HD_TEXT.Text = ""
								HD_NMA.Text = ""
								'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
								'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_STTKEY = VB.Left(W_BUF, 1)
								'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
								ReDim WM_WLS_DSPArray(0)
								Call WLS_KanaSQL()
								Call WLS_DspNew()
								
							Case Else
								WM_WLS_Dspflg = False
								HD_TEXT.Text = ""
								WLSKANA.SelectedIndex = 0
								HD_NMA.Text = ""
								'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_STTKEY = WLSHINKB.Text
								'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								WM_WLS_ENDKEY = System.DBNull.Value
								WM_WLS_Dspflg = True
								WM_WLS_Pagecnt = -1
								WM_WLS_LastPage = -1
								WM_WLS_LastFL = False
								ReDim WM_WLS_DSPArray(0)
								
								Call WLS_KbSQL()
								Call WLS_DspNew()
						End Select
					Else
						Call DSP_MsgBox(SSS_ERROR, "INPKBN", 0) '入力区分が違います。
						Call P_SetFocus(WLSHINKB)
						WLSHINKB.SelectionStart = 0
						WLSHINKB.SelectionLength = Len(WLSHINKB.Text)
						
					End If
				End If
				'        Case 40  '↓キー
				'            LST.ListIndex = 0
				'            LST.SetFocus
			Case 112 'F･１キー
				System.Windows.Forms.SendKeys.Send("%1")
			Case 113 'F･１キー
				System.Windows.Forms.SendKeys.Send("%2")
		End Select
		
		
	End Sub
	
	'UPGRADE_WARNING: イベント WLSKANA.SelectedIndexChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		ReDim WM_WLS_DSPArray(0)
		
		If WLSKANA.SelectedIndex > 0 Then
			HD_TEXT.Text = ""
			HD_NMA.Text = ""
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: オブジェクト W_BUF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
			Call WLS_KanaSQL()
		Else
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
			Call WLS_TextSQL()
		End If
		Call WLS_DspNew()
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
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
		Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
		Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		'UnLoadイベント障害対応  97/04/07
		'Unload Me
		Hide()
	End Sub
	
	Private Sub P_SetFocus(ByRef objCtl As System.Windows.Forms.Control)
		
		On Error Resume Next
		objCtl.Focus()
		
	End Sub
End Class