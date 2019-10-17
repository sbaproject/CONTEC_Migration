Option Strict Off
Option Explicit On
Module ENDTOKCD_F61
	'
	'スロット名      :得意先コード・画面項目スロット
	'ユニット名      :ENDTOKCD.F61
	'記述者          :Standard Library
	'作成日付        :2011/02/21
	'使用プログラム  :THSFP61
	'
	'
	
	Function ENDTOKCD_Check(ByVal ENDTOKCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDTOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKCD_Check = 0
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(ENDTOKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(ENDTOKCD) = 0 Or Trim(ENDTOKCD) = "" Then
		Else
			Call DB_GetLsEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
			Else
				Call DB_GetLsEq(DBN_SIRMTA, 1, ENDTOKCD, BtrNormal)
				If DBSTAT = 0 Then
					If DB_TOKMTA.DATKB = "9" Then
						Call TOKMTA_RClear()
					End If
				Else
					Call TOKMTA_RClear()
				End If
			End If
		End If
	End Function
	Function ENDTOKCD_Slist(ByRef PP As clsPP, ByVal ENDTOKCD As Object) As Object
		
		WGDENKB = FR_SSSMAIN.HD_THSCD.Text
		WGDENKB = IIf(WGDENKB = "9" Or WGDENKB = "0", "1", WGDENKB)
		WLS_THS1.ShowDialog()
		WLS_THS1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDTOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKCD_Slist = PP.SlistCom
	End Function
	Function ENDTOKCD_InitVal(ByVal ENDTOKCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト ENDTOKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKCD_InitVal = "ﾝﾝﾝﾝﾝ"
	End Function
End Module