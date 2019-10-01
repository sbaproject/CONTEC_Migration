Option Strict Off
Option Explicit On
Module NXTKB_F52
	'
	' スロット名        : 帳端区分・画面項目スロット
	' ユニット名        : NXTKB.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	
	'帳端区分が入力された場合に、そのチェックを行う。
	Function NXTKB_CheckC(ByRef NXTKB As Object) As Object
		'UPGRADE_WARNING: オブジェクト NXTKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NXTKB_CheckC = 0 '正常終了。
		'UPGRADE_WARNING: オブジェクト NXTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NXTKB) = "" Then
			'UPGRADE_WARNING: オブジェクト NXTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NXTKB = "0"
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(NXTKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト NXTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(NXTKB) > 2 Then NXTKB = "0"
		End If
	End Function
	
	Function NXTKB_InitVal() As Object
		'UPGRADE_WARNING: オブジェクト NXTKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NXTKB_InitVal = "0"
	End Function
	
	Function NXTKB_Slist(ByRef PP As clsPP, ByVal TOKSMEKB As Object, ByVal TOKSMEDD As Object, ByVal TOKSMECC As Object, ByVal UDNDT As Object) As Object
		Dim wkSSADT0 As String
		Dim wkSSADT1 As String
		Dim wkSSADT2 As String
		
		'   === 請求締め日付取得 ===
		'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTA.TOKSMEKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(DB_TOKMTA.TOKSMEKB) = 1 Then
			'       --- 月X回締め ---
			'UPGRADE_WARNING: オブジェクト SSSVal(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTA.TOKSMECC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT0 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("0"))
			'UPGRADE_WARNING: オブジェクト SSSVal(1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTA.TOKSMECC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT1 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("1"))
			'UPGRADE_WARNING: オブジェクト SSSVal(2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTA.TOKSMECC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT2 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("2"))
		Else
			'       --- 週締め ---
			'UPGRADE_WARNING: オブジェクト SSSVal(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT0 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("0"))
			'UPGRADE_WARNING: オブジェクト SSSVal(1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT1 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("1"))
			'UPGRADE_WARNING: オブジェクト SSSVal(2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSSADT2 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("2"))
		End If
		
		WLS_LIST.Text = "帳端区分"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		'''''    WLS_LIST!LST.AddItem "0 今回請求"
		'''''    WLS_LIST!LST.AddItem "1 次回請求"
		'''''    WLS_LIST!LST.AddItem "2 次々回請求"
		
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("0 " & Mid(wkSSADT0, 6, 5) & "請求")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("1 " & Mid(wkSSADT1, 6, 5) & "請求")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("2 " & Mid(wkSSADT2, 6, 5) & "請求")
		SSS_WLSLIST_KETA = 1
		WLS_LIST.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NXTKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NXTKB_Slist = PP.SlistCom
	End Function
End Module