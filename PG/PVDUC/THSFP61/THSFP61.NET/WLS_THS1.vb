Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_THS1
	Inherits System.Windows.Forms.Form
	'以下の ３行の設定を行うこと
	Const WM_WLS_MSTKB As String = "1" 'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
	Const WM_WLSKEY_ZOKUSEI As String = "X" '開始コード入力属性 [0,X]
	Const WM_WLS_KanaINPUT As Boolean = False 'カナ直接入力使用（True:直接入力 False:カナコンボ）
	
	'検索キーNo（使用しない場合は-1を設定）
	Const WM_WLS_TextKey As Short = 1 '開始コードのソートキーNo
	Const WM_WLS_KanaKey As Short = 2 'カナ検索のソートキーNo+第一キー
	Const WM_WLS_RNKey As Short = 3 '得意先略称検索のソートキーNo+第一キー
	
	'ウィンドﾕｰｻﾞｰ設定変数
	Dim WM_WLS_MFIL As Short 'ウィンド表示ﾒｲﾝﾌｧｲﾙ
	Dim WM_WLS_LEN As Short '開始ｺｰﾄﾞ入力文字数
	Dim WM_WLS_KANALEN As Short 'カナ入力文字数
	Dim WM_WLS_RNLEN As Short '得意先略称入力文字数
	
	Dim WM_WLS_MM1 As Short 'ウィンド表示ﾌｧｲﾙ1
	Dim WM_WLS_MM2 As Short 'ウィンド表示ﾌｧｲﾙ2
	
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
	
	Dim WlsSelList As String
	
	Dim WlsSelList1 As String
	Dim WlsSelList2 As String
	Dim WlsHint As String
	Dim WlsOrderBy As String
	Dim WlsFromWhere As String
	
	
	
	Dim DblClickFl As Boolean 'DblClickイベント障害対応  97/04/07
	
	Private Sub WLS_FORM_INIT()
		'=== WINDOW 表示ファイル設定 ===
		WM_WLS_MFIL = DBN_TOKMTA
		
		WM_WLS_MM1 = DBN_TOKMTA
		WM_WLS_MM2 = DBN_SIRMTA
		
		HD_BUNRUI.Text = "1"
		
		
		'=== 表示開始コード桁数設定 ===
		WM_WLS_LEN = Len(DB_TOKMTA.TOKCD) 'LenWid はダメ
		WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK) 'LenWid はダメ
		WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN) 'LenWid はダメ
		WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"
		
		WlsSelList1 = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"
		WlsSelList2 = "SIRNMA, SIRNMB, DATKB, SIRZEIKB, SIRSMEKB, SIRSMEDD, SIRKESCC, SIRKESDD, SIRNK, SIRSDWKB, SIRCD, SIRRN, SIRTL, SIRSHACD"
		
		
		'=== ＬＡＢＥＬ設定 ===
		'    WLSLABEL = "ｺｰﾄﾞ  得意先名                 　　　  締  日  　回収条件     税区  　電話番号      請求先"
		'12345 123456789012345678901234567890 1234567890 1234567890123 123456  1234567890123 12345
		'UPGRADE_WARNING: オブジェクト WLSLABEL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WLSLABEL = "ｺｰﾄﾞ  取引先名                 　　　  締  日   　税区  　電話番号     "
		'=== WINDOW 画面サイズ設定 ===
		'Me.Width = LenWid(WLSLABEL) + 200?
		Me.Width = VB6.TwipsToPixelsX(11490)
		WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
		'HD_TEXT.Height = 330
		'UPGRADE_WARNING: TextBox プロパティ HD_TEXT.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_TEXT.Maxlength = WM_WLS_LEN
		HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)
		
	End Sub
	
	Private Function WLS_DSP_CHECK() As Object
		If DB_TOKMTA.DATKB = "9" Then
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLS_DSP_CHECK = SSS_NEXT
		Else
			'UPGRADE_WARNING: オブジェクト WLS_DSP_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WLS_DSP_CHECK = SSS_OK
		End If
	End Function
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		'====================================
		'   WINDOW 明細設定
		'====================================
		
		Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
		Dim WK_TK As New VB6.FixedLengthString(13)
		Dim WK_KESDD As String
		
		If HD_BUNRUI.Text <> "2" Then
			'
			Select Case SSSVal(DB_TOKMTA.TOKZEIKB)
				Case 1
					WK_ZEINM = " 税抜 "
				Case 2
					WK_ZEINM = " 税込 "
				Case 9
					WK_ZEINM = "非課税"
			End Select
			'
			Select Case SSSVal(DB_TOKMTA.TOKSMEKB)
				Case 1
					WK_SMENM = "  " & DB_TOKMTA.TOKSMEDD & "日締 "
					Select Case SSSVal(DB_TOKMTA.TOKKESCC)
						Case 0
							WK_KESNM = "  当月"
						Case 1
							WK_KESNM = "  翌月"
						Case 2
							WK_KESNM = "翌々月"
						Case Else
							WK_KESNM = "その他"
					End Select
					WK_KESNM = WK_KESNM & DB_TOKMTA.TOKKESDD & "日回収"
				Case 2
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKSDWKB)) & "締     " & SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKKDWKB)) & "回収"
			End Select
			'
			'   WM_WLS_DSPArray(ArrayCnt) = LeftWid$(Right(Trim$(DB_TOKMTA.TOKCD), 5), 5) & " " & LeftWid$(DB_TOKMTA.TOKRN, 30) & " " & LeftWid$((WK_SMENM), 10) & " " & LeftWid$((WK_KESNM), 12) & "  " & LeftWid$((WK_ZEINM), 6) & " " & LeftWid$((DB_TOKMTA.TOKTL), 13) & "   " & RightWid$((DB_TOKMTA.TOKSEICD), 5)
			WM_WLS_DSPArray(ArrayCnt) = LeftWid(VB.Left(Trim(DB_TOKMTA.TOKCD) & "     ", 5), 5) & " " & LeftWid(DB_TOKMTA.TOKRN, 30) & " " & LeftWid(WK_SMENM, 10) & " " & "  " & LeftWid(WK_ZEINM, 6) & " " & LeftWid(DB_TOKMTA.TOKTL, 13)
		End If
		
		If HD_BUNRUI.Text = "2" Then
			'
			Select Case SSSVal(DB_SIRMTA.SIRZEIKB)
				Case 1
					WK_ZEINM = " 税抜 "
				Case 2
					WK_ZEINM = " 税込 "
				Case 9
					WK_ZEINM = "非課税"
			End Select
			'
			Select Case SSSVal(DB_SIRMTA.SIRSMEKB)
				Case 1
					WK_SMENM = "  " & DB_SIRMTA.SIRSMEDD & "日締 "
					Select Case SSSVal(DB_SIRMTA.SIRKESCC)
						Case 0
							WK_KESNM = "  当月"
						Case 1
							WK_KESNM = "  翌月"
						Case 2
							WK_KESNM = "翌々月"
						Case Else
							WK_KESNM = "その他"
					End Select
					WK_KESNM = WK_KESNM & DB_SIRMTA.SIRKESDD & "日回収"
				Case 2
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WK_SMENM = SSS_WEEKNM(SSSVal(DB_SIRMTA.SIRSDWKB)) & "締     " & SSS_WEEKNM(SSSVal(DB_SIRMTA.SIRSDWKB)) & "回収"
			End Select
			'
			WM_WLS_DSPArray(ArrayCnt) = LeftWid(VB.Left(Trim(DB_SIRMTA.SIRCD) & "     ", 5), 5) & " " & LeftWid(DB_SIRMTA.SIRRN, 30) & " " & LeftWid(WK_SMENM, 10) & " " & "  " & LeftWid(WK_ZEINM, 6) & " " & LeftWid(DB_SIRMTA.SIRTL, 13)
		End If
		
	End Sub
	
	Sub WLS_TextSQL()
		Dim wkaa As String
		
		WM_WLS_KeyNo = WM_WLS_TextKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		
		If HD_BUNRUI.Text = "1" Then
			WM_WLS_MFIL = WM_WLS_MM1
			WlsSelList = WlsSelList1
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票��661「'」対応修正
			'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
			WlsOrderBy = "Order By TOKCD"
		End If
		
		If HD_BUNRUI.Text = "2" Then
			WM_WLS_MFIL = WM_WLS_MM2
			WlsSelList = WlsSelList2
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票��661「'」対応修正
			'        WlsFromWhere = "From SIRMTA Where SIRCD >= '" & WM_WLS_STTKEY & "'"
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From SIRMTA Where SIRCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
			WlsOrderBy = "Order By SIRCD"
		End If
		
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		
		'''' DEL 2014/12/03  RS) Y.Ishida  Start  C2プロジェクト
		'    If HD_BUNRUI = "3" Then
		'        WM_WLS_MFIL = WM_WLS_MM1
		'        WlsSelList = WlsSelList1
		''''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票��661「'」対応修正
		'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
		'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
		''''' UPD 2009/12/03  FKS) T.Yamamoto    End
		'        WlsOrderBy = "Order By TOKCD"
		'
		'        wkaa = "Select " & WlsSelList & " " & WlsFromWhere & " and exists "
		'
		'        DB_SQLBUFF = wkaa & "( Select * from sirmta where tokcd = sircd )"
		'
		'    End If
		'''' DEL 2014/12/03  RS) Y.Ishida  End
		
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
		
	End Sub
	
	Sub WLS_KanaSQL()
		WM_WLS_KeyNo = WM_WLS_KanaKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		
		If HD_BUNRUI.Text <> "2" Then
			WM_WLS_MFIL = WM_WLS_MM1
			WlsSelList = WlsSelList1
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From TOKMTA Where TOKNK >= '" & WM_WLS_STTKEY & "' And TOKNK < '" & WM_WLS_ENDKEY & "'"
			WlsOrderBy = "Order By TOKNK, TOKCD"
		End If
		If HD_BUNRUI.Text = "2" Then
			WM_WLS_MFIL = WM_WLS_MM2
			WlsSelList = WlsSelList2
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From SIRMTA Where SIRNK >= '" & WM_WLS_STTKEY & "' And SIRNK < '" & WM_WLS_ENDKEY & "'"
			WlsOrderBy = "Order By SIRNK, SIRCD"
		End If
		
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
		Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
	End Sub
	
	Sub WLS_RnSQL()
		WM_WLS_KeyNo = WM_WLS_RNKey
		''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
		
		If HD_BUNRUI.Text <> "2" Then
			WM_WLS_MFIL = WM_WLS_MM1
			WlsSelList = WlsSelList1
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票��661「'」対応修正
			'       WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%'"
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
			WlsOrderBy = "Order By TOKRN, TOKCD"
		End If
		If HD_BUNRUI.Text = "2" Then
			WM_WLS_MFIL = WM_WLS_MM2
			WlsSelList = WlsSelList2
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票��661「'」対応修正
			'       WlsFromWhere = "From SIRMTA Where SIRRN Like " & "'%" & WM_WLS_STTKEY & "%'"
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WlsFromWhere = "From SIRMTA Where SIRRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
			WlsOrderBy = "Order By SIRRN, SIRCD"
		End If
		
		DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
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
			WLSKANA.Items.Add("ア　      ｱｵ")
			WLSKANA.Items.Add("カ　      ｶｺ")
			WLSKANA.Items.Add("サ　      ｻｿ")
			WLSKANA.Items.Add("タ　      ﾀﾄ")
			WLSKANA.Items.Add("ナ　      ﾅﾉ")
			WLSKANA.Items.Add("ハ　      ﾊﾎ")
			WLSKANA.Items.Add("マ　      ﾏﾓ")
			WLSKANA.Items.Add("ヤ　      ﾔﾖ")
			WLSKANA.Items.Add("ラ　      ﾗﾛ")
			WLSKANA.Items.Add("ワ　      ﾜﾝ")
		End If
	End Sub
	
	'
	'以下は画面イベント処理
	'
	'UPGRADE_WARNING: Form イベント WLS_THS1.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub WLS_THS1_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		WLSMAE.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Me.Width) - (VB6.PixelsToTwipsX(WLSMAE.Width) + VB6.PixelsToTwipsX(WLSOK.Width) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + VB6.PixelsToTwipsX(WLSATO.Width) + 60)) / 2)
		WLSOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSMAE.Left) + VB6.PixelsToTwipsX(WLSMAE.Width) + 60)
		WLSCANCEL.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSOK.Left) + VB6.PixelsToTwipsX(WLSOK.Width) + 60)
		WLSATO.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(WLSCANCEL.Left) + VB6.PixelsToTwipsX(WLSCANCEL.Width) + 60)
		
		'=== WINDOW 位置設定 ===
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_STTKEY = ""
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WM_WLS_ENDKEY = System.DBNull.Value
		HD_TEXT.Text = ""
		WM_WLS_Dspflg = False
		WLSKANA.SelectedIndex = 0
		HD_Kana.Text = ""
		'WLSRN.ListIndex = 0
		HD_RN.Text = ""
		WM_WLS_Dspflg = True
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'  WGDENKB = "1"
		Me.HD_BUNRUI.Text = WGDENKB
		
		
		ReDim WM_WLS_DSPArray(0)
		
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		'DblClickイベント障害対応  97/04/07
		DblClickFl = False
	End Sub
	
	Private Sub WLS_THS1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window初期設定
		Call WLS_FORM_INIT()
		Call WLS_Kana_Init()
	End Sub
	
	Private Sub HD_BUNRUI_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUNRUI.Enter
		HD_BUNRUI.SelectionStart = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HD_BUNRUI.SelectionLength = LenWid(HD_BUNRUI.Text)
	End Sub
	
	Private Sub HD_BUNRUI_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUNRUI.KeyDown
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
			HD_Kana.Text = ""
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			WGDENKB = HD_BUNRUI.Text
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_BUNRUI_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUNRUI.Leave
		'''' UPD 2014/12/03  RS) Y.Ishida  Start  C2プロジェクト
		'   If HD_BUNRUI <> "1" And HD_BUNRUI <> "2" And HD_BUNRUI <> "3" Then HD_BUNRUI = "1"
		If HD_BUNRUI.Text <> "1" And HD_BUNRUI.Text <> "2" Then HD_BUNRUI.Text = "1"
		'''' UPD 2014/12/03  RS) Y.Ishida  End
	End Sub
	
	Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
		'''    If LenWid(HD_RN.Text) > 0 Then
		'''        HD_RN.Text = SSS_EDTITM_WLS(HD_RN.Text, HD_RN.MaxLength, WM_WLSKEY_ZOKUSEI)
		'''    Else
		'''        HD_RN.Text = Space$(HD_RN.MaxLength)
		'''    End If
		HD_RN.SelectionStart = 0
		'UPGRADE_WARNING: TextBox プロパティ HD_RN.MaxLength には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		HD_RN.SelectionLength = HD_RN.Maxlength
	End Sub
	
	Private Sub HD_Rn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Rn.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KEYCODE = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			HD_TEXT.Text = ""
			'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_STTKEY = HD_RN.Text
			'UPGRADE_WARNING: オブジェクト WM_WLS_ENDKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WM_WLS_ENDKEY = HD_RN.Text
			WM_WLS_Dspflg = True
			WM_WLS_Pagecnt = -1
			WM_WLS_LastPage = -1
			WM_WLS_LastFL = False
			ReDim WM_WLS_DSPArray(0)
			
			Call WLS_RnSQL()
			Call WLS_DspNew()
		End If
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
			HD_Kana.Text = ""
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
		WGDENKB = HD_BUNRUI.Text
		
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
			HD_RN.Text = ""
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
			If HD_RN.Text <> "" Then
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_STTKEY = VB6.Format(HD_RN.Text)
				Call WLS_RnSQL()
			Else
				'UPGRADE_WARNING: オブジェクト WM_WLS_STTKEY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
				Call WLS_TextSQL()
			End If
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
End Class