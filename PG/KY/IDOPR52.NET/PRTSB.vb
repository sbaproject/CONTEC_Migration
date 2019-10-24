Option Strict Off
Option Explicit On
Module PRTSB_F51
	'
	' スロット名        : 出力区分・画面項目スロット
	' ユニット名        : PRTSB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/22
	' 使用プログラム名  : URIPR52
	'
	
	Function PRTSB_Check(ByRef PRTSB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト PRTSB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(PRTSB) = "" Then
			'UPGRADE_WARNING: オブジェクト PRTSB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PRTSB = "1"
		End If
		'UPGRADE_WARNING: オブジェクト PRTSB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If PRTSB = "1" Or PRTSB = "2" Then
		Else
			'UPGRADE_WARNING: オブジェクト PRTSB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PRTSB = "1"
		End If
		
		'UPGRADE_WARNING: オブジェクト PRTSB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PRTSB_Check = 0
		
	End Function
	
	Function PRTSB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト PRTSB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PRTSB_InitVal = "1"
	End Function
End Module