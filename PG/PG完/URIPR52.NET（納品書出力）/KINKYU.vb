Option Strict Off
Option Explicit On
Module KINKYU_F51
	'
	' スロット名        : 緊急出荷・画面項目スロット
	' ユニット名        : KINKYU.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/26
	' 使用プログラム名  : URIPR52
	'
	
	Function KINKYU_Check(ByRef KINKYU As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト KINKYU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(KINKYU) = "" Then
			'UPGRADE_WARNING: オブジェクト KINKYU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			KINKYU = "1"
		End If
		'UPGRADE_WARNING: オブジェクト KINKYU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If KINKYU = "1" Or KINKYU = "2" Then
		Else
			'UPGRADE_WARNING: オブジェクト KINKYU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			KINKYU = "1"
		End If
		
		'UPGRADE_WARNING: オブジェクト KINKYU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		KINKYU_Check = 0
		
	End Function
	
	Function KINKYU_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト KINKYU_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		KINKYU_InitVal = 1
	End Function
End Module