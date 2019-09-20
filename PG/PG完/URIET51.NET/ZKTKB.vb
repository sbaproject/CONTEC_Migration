Option Strict Off
Option Explicit On
Module ZKTKB_F01
	'
	' スロット名        : 取引区分・画面項目スロット
	' ユニット名        : ZKTKB.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	'
	
	Function ZKTKB_CheckC(ByRef ZKTKB As Object) As Object
		If Not IsNumeric(ZKTKB) Then
			'UPGRADE_WARNING: オブジェクト ZKTKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZKTKB_CheckC = 1
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(ZKTKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(ZKTKB) < 1 Or SSSVal(ZKTKB) > 2 Then
				'UPGRADE_WARNING: オブジェクト ZKTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTKB = "1"
			Else
				'UPGRADE_WARNING: オブジェクト ZKTKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTKB_CheckC = 0
			End If
		End If
	End Function
	
	Function ZKTKB_InitVal() As Object
		'UPGRADE_WARNING: オブジェクト ZKTKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZKTKB_InitVal = "1"
	End Function
	
	Function ZKTKB_Slist(ByRef PP As clsPP) As Object
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("1 通常")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("2 直送")
		SSS_WLSLIST_KETA = 1
		WLS_LIST.Text = "取引形態"
		WLS_LIST.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SLISTCOM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ZKTKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZKTKB_Slist = PP.SLISTCOM
	End Function
End Module