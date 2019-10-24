Option Strict Off
Option Explicit On
Module ENDTOKNM_F51
	'
	' スロット名        : 得意先名称・画面項目スロット
	' ユニット名        : TOKNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function ENDTOKNM_Derived(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDTOKCD) = "" Then
			DB_TOKMTA.TOKRN = " "
		Else
			Call TOKMTA_RClear()
			Call DB_GetEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
			Else
				Call TOKMTA_RClear()
			End If
		End If
		'UPGRADE_WARNING: オブジェクト ENDTOKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKNM_Derived = DB_TOKMTA.TOKRN
		
	End Function
	Function ENDTOKNM_InitVal(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_TOKMTA.TOKCD) = "" Then
		'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDTOKCD) = "" Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
		Else
			'UPGRADE_WARNING: オブジェクト ENDTOKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDTOKNM_InitVal = DB_TOKMTA.TOKRN
		End If
	End Function
End Module