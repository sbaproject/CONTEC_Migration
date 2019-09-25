Option Strict Off
Option Explicit On
Module NHSADA_F51
	'
	' スロット名        : 得意先名称・画面項目スロット
	' ユニット名        : TOKNMA.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/26
	' 使用プログラム名  : THSMR51
	'
	
	Function NHSADA_Check(ByVal NHSADA As Object, ByVal NHSCD As Object) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト NHSADA_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSADA_Check = 0
		'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト NHSADA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(NHSADA) = "" Then
				'UPGRADE_WARNING: オブジェクト NHSADA_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSADA_Check = -1
			End If
		End If
		
	End Function
End Module