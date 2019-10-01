Option Strict Off
Option Explicit On
Module PRTKB_F51
	'
	' スロット名        : 出力フラグ・画面項目スロット
	' ユニット名        : PRTKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/22
	' 使用プログラム名  : URIPR52
	'
	
	Function PRTKB_Check(ByRef PRTKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト PRTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(PRTKB) = "" Then
			'UPGRADE_WARNING: オブジェクト PRTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PRTKB = "0"
		End If
		'UPGRADE_WARNING: オブジェクト PRTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If PRTKB = "0" Or PRTKB = "1" Or PRTKB = "9" Then
		Else
			'UPGRADE_WARNING: オブジェクト PRTKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PRTKB = "0"
		End If
		
		'UPGRADE_WARNING: オブジェクト PRTKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PRTKB_Check = 0
		
	End Function
	
	Function PRTKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト PRTKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PRTKB_InitVal = 0
	End Function
End Module