Option Strict Off
Option Explicit On
Module NHSNMMKB_FM1
	'
	' スロット名        : 名称マニュアル区分・画面項目スロット
	' ユニット名        : NHSNMMKB.FM1
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : NHSMR01
	'
	' 備考              : 1:手入力あり
	'                     9:手入力なし
	'
	
	Function NHSNMMKB_CheckC(ByRef NHSNMMKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト NHSNMMKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSNMMKB) = "" Then
			'UPGRADE_WARNING: オブジェクト NHSNMMKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NHSNMMKB = "9"
		End If
		Select Case NHSNMMKB
			Case "1", "9"
			Case Else
				'UPGRADE_WARNING: オブジェクト NHSNMMKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSNMMKB = "9"
		End Select
		'UPGRADE_WARNING: オブジェクト NHSNMMKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSNMMKB_CheckC = 0
	End Function
	
	Function NHSNMMKB_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト NHSNMMKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSNMMKB_InitVal = "9"
	End Function
End Module