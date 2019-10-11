Option Strict Off
Option Explicit On
Module ENDHINNM_F51
	'
	' スロット名        : 倉庫名称・画面項目スロット
	' ユニット名        : ENDHINNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function ENDHINNM_Derived(ByVal ENDHINNM As Object, ByVal ENDHINCD As Object, ByVal De_Index As Object) As Object
		
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, ENDHINCD, BtrNormal)
		
		'    If Trim(ENDHINCD) = "" Then
		'       DB_HINMTA.HINNMA = " "
		'    End If
		'UPGRADE_WARNING: オブジェクト ENDHINNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDHINNM_Derived = DB_HINMTA.HINNMA
		
	End Function
	Function ENDHINNM_InitVal(ByVal ENDHINNM As Object, ByVal ENDHINCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_HINMTA.ENDHINCD) = "" Then
		'UPGRADE_WARNING: オブジェクト ENDHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDHINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDHINNM_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINNMA))
		Else
			'UPGRADE_WARNING: オブジェクト ENDHINNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDHINNM_InitVal = DB_HINMTA.HINNMA
		End If
	End Function
End Module