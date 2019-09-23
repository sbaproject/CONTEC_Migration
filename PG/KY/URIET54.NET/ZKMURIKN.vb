Option Strict Off
Option Explicit On
Module ZKMURIKN_F01
	'
	' スロット名        : 売上金額(税込)・画面項目スロット
	' ユニット名        : ZKMURIKN.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	'
	
	'受注単価＊受注数量
	Function ZKMURIKN_Derived(ByVal URIKN As Object, ByVal HINZEIKB As Object, ByVal TOKZEIKB As Object) As Object
		'UPGRADE_WARNING: オブジェクト ZKMURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZKMURIKN_Derived = 0
		'    If Trim$(HINZEIKB) = "" Or Not IsNumeric(HINZEIKB) Then Exit Function
		'    If Trim$(TOKZEIKB) = "" Or Not IsNumeric(TOKZEIKB) Then Exit Function
		'UPGRADE_WARNING: オブジェクト HINZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINZEIKB) = "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TOKZEIKB) = "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If URIKN = 0 Then Exit Function
		'
		'UPGRADE_WARNING: オブジェクト SSSVal(TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(TOKZEIKB) = 9 Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(HINZEIKB) = 2 Then
			'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ZKMURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZKMURIKN_Derived = URIKN
			'UPGRADE_WARNING: オブジェクト SSSVal(TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf SSSVal(HINZEIKB) = 0 And SSSVal(TOKZEIKB) = 2 Then 
			'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ZKMURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZKMURIKN_Derived = URIKN
		End If
	End Function
End Module