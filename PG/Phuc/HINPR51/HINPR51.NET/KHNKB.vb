Option Strict Off
Option Explicit On
Module KHNKB_F51
	'
	' スロット名        : 仮本区分・画面項目スロット
	' ユニット名        : KHNKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/22
	' 使用プログラム名  : URIPR52
	'
	
	Function KHNKB_Check(ByRef KHNKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト KHNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(KHNKB) = "" Then
			'UPGRADE_WARNING: オブジェクト KHNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			KHNKB = "1"
		End If
		'UPGRADE_WARNING: オブジェクト KHNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If KHNKB = "1" Or KHNKB = "9" Then
		Else
			'UPGRADE_WARNING: オブジェクト KHNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			KHNKB = "1"
		End If
		
		'UPGRADE_WARNING: オブジェクト KHNKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		KHNKB_Check = 0
		
	End Function
	
	Function KHNKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト KHNKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		KHNKB_InitVal = "1"
	End Function
End Module