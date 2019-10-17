Option Strict Off
Option Explicit On
Module THSCD_F61
	'
	' スロット名        : 取引先分類・画面項目スロット
	' ユニット名        : THSCD.F61
	' 記述者            : Standard Library
	' 作成日付          : 2011/02/21
	' 使用プログラム名  : THSFP61
	'
	
	Function THSCD_Check(ByRef THSCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト THSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(THSCD) = "" Then
			'UPGRADE_WARNING: オブジェクト THSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			THSCD = "0"
		End If
		'UPGRADE_WARNING: オブジェクト THSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If THSCD = "0" Or THSCD = "1" Or THSCD = "2" Or THSCD = "3" Or THSCD = "9" Then
		Else
			'UPGRADE_WARNING: オブジェクト THSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			THSCD = "9"
		End If
		
		'UPGRADE_WARNING: オブジェクト THSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		THSCD_Check = 0
		
	End Function
	
	Function THSCD_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト THSCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		THSCD_InitVal = "9"
	End Function
	
	Public Function FRNKB_Check(ByRef FRNKB As Object) As Short
		'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(FRNKB) = "" Then
			'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRNKB = "0"
		End If
		'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If FRNKB = "0" Or FRNKB = "1" Or FRNKB = "9" Then
		Else
			'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRNKB = "9"
		End If
		
		FRNKB_Check = 0
		
	End Function
	
	Function FRNKB_InitVal() As String
		'
		FRNKB_InitVal = "9"
	End Function
End Module