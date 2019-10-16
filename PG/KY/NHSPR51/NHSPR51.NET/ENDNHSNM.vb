Option Strict Off
Option Explicit On
Module ENDNHSNM_F51
	'
	' スロット名        : 納入先名称・画面項目スロット
	' ユニット名        : NHSNM.F51
	' 記述者            : SNHSdard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function ENDNHSNM_Derived(ByVal ENDNHSNM As Object, ByVal ENDNHSCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDNHSCD) = "" Or ENDNHSCD = "ﾝﾝﾝﾝﾝﾝﾝﾝﾝ" Then
			DB_NHSMTA.NHSRN = " "
		Else
			Call DB_GetEq(DBN_NHSMTA, 1, ENDNHSCD, BtrNormal)
		End If
		'UPGRADE_WARNING: オブジェクト ENDNHSNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDNHSNM_Derived = DB_NHSMTA.NHSRN
		
	End Function
	Function ENDNHSNM_InitVal(ByVal ENDNHSNM As Object, ByVal ENDNHSCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_NHSMTA.NHSCD) = "" Then
		'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDNHSCD) = "" Or ENDNHSCD = "ﾝﾝﾝﾝﾝﾝﾝﾝﾝ" Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDNHSNM_InitVal = FillVal(" ", LenWid(DB_NHSMTA.NHSRN))
		Else
			'UPGRADE_WARNING: オブジェクト ENDNHSNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDNHSNM_InitVal = DB_NHSMTA.NHSRN
		End If
	End Function
End Module