Option Strict Off
Option Explicit On
Module STTHINNM_F51
	'
	' スロット名        : 倉庫名称・画面項目スロット
	' ユニット名        : STTHINNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function STTHINNM_Derived(ByVal STTHINNM As Object, ByVal STTHINCD As Object, ByVal De_Index As Object) As Object
		
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, STTHINCD, BtrNormal)
		
		'    If Trim(STTHINCD) = "" Then
		'       DB_HINMTA.HINNMA = " "
		'    End If
		'UPGRADE_WARNING: オブジェクト STTHINNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTHINNM_Derived = DB_HINMTA.HINNMA
		
	End Function
	Function STTHINNM_InitVal(ByVal STTHINNM As Object, ByVal STTHINCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_HINMTA.STTHINCD) = "" Then
		'UPGRADE_WARNING: オブジェクト STTHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTHINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTHINNM_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINNMA))
		Else
			'UPGRADE_WARNING: オブジェクト STTHINNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTHINNM_InitVal = DB_HINMTA.HINNMA
		End If
	End Function
End Module