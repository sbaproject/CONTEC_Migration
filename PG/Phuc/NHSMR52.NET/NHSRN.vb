Option Strict Off
Option Explicit On
Module NHSRN_FM1
	'
	' スロット名        : 納品先略称・画面項目スロット
	' ユニット名        : NHSRN.FM1
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : NHSMR01
	'
	
	Function NHSRN_DerivedC(ByVal NHSNMA As Object, ByVal NHSRN As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト NHSRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NHSRN_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSRN_DerivedC = NHSRN
		'UPGRADE_WARNING: オブジェクト NHSRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSRN) = "" Then
			'UPGRADE_WARNING: オブジェクト NHSNMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト NHSRN_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NHSRN_DerivedC = NHSNMA
		End If
	End Function
End Module