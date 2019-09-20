Option Strict Off
Option Explicit On
Module GNKTK_F02
	'
	' スロット名        : 原価単価・画面項目スロット
	' ユニット名        : GNKTK.F02
	' 記述者            : Standard Library
	' 作成日付          : 1998/08/23
	' 使用プログラム名  : URIET01
	'
	
	Function GNKTK_Derived(ByVal GNKTK As Object, ByRef PP As clsPP, ByVal ENTDT As Object, ByVal HINCD As Object) As Object
		Dim pHINCD As String
		'UPGRADE_WARNING: オブジェクト GNKTK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト GNKTK_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		GNKTK_Derived = GNKTK
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENTDT) = "" Or Trim(HINCD) = "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pHINCD = CStr(HINCD)
		
		If PP.RecalcMode = True And WG_DSPKB = 1 Then Exit Function
		
		If DB_SYSTBA.GNKHYKKB = "1" Then
			GNKTK_Derived = CALC_GNKTK(pHINCD)
		Else
			If DB_SYSTBA.ZAIHYKKB = "2" Then
				GNKTK_Derived = CALC_GNKTK2(pHINCD, SSS_SMADT.Value)
			ElseIf DB_SYSTBA.ZAIHYKKB = "3" Then 
				GNKTK_Derived = CALC_GNKTK3(pHINCD, SSS_SMADT.Value)
			Else
				GNKTK_Derived = CALC_GNKTK(pHINCD)
			End If
		End If
		
	End Function
End Module