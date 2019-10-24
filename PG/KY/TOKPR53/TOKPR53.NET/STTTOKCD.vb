Option Strict Off
Option Explicit On
Module STTTOKCD_F56
	'
	'スロット名      :得意先コード・画面項目スロット
	'ユニット名      :TOKCD.F56
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function STTTOKCD_Check(ByVal STTTOKCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTTOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_Check = 0
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(STTTOKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(STTTOKCD) = 0 Or Trim(STTTOKCD) = "" Then
		Else
			Call DB_GetLsEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
			Else
				Call TOKMTA_RClear()
			End If
		End If
		'Call SCR_FromTOKMTA(De_Index)
	End Function
	
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		'
		DB_PARA(DBN_TOKMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		WLSTOK.ShowDialog()
		WLSTOK.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTTOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_Slist = PP.SlistCom
	End Function
	Function STTTOKCD_InitVal(ByVal STTTOKCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト STTTOKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_InitVal = " "
		
	End Function
End Module