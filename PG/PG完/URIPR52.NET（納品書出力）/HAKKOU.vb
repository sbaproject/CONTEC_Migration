Option Strict Off
Option Explicit On
Module HAKKOU_F51
	'
	' スロット名        : 発行区分・画面項目スロット
	' ユニット名        : HAKKOU.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/26
	' 使用プログラム名  : URIPR52
	'
	
	Function HAKKOU_Check(ByRef HAKKOU As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト HAKKOU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HAKKOU) = "" Then
			'UPGRADE_WARNING: オブジェクト HAKKOU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HAKKOU = "1"
		End If
		'UPGRADE_WARNING: オブジェクト HAKKOU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If HAKKOU = "0" Or HAKKOU = "1" Then
		Else
			'UPGRADE_WARNING: オブジェクト HAKKOU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HAKKOU = "1"
		End If
		
		'UPGRADE_WARNING: オブジェクト HAKKOU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HAKKOU_Check = 0
		
	End Function
	
	Function HAKKOU_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト HAKKOU_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HAKKOU_InitVal = "1"
	End Function
End Module