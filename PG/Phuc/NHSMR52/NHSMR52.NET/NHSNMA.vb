Option Strict Off
Option Explicit On
Module NHSNMA_F71
	'
	' スロット名        : 納入先名称・画面項目スロット
	' ユニット名        : NHSNMA.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/26
	' 使用プログラム名  : NHSMR51
	'
	
	Function NHSNMA_Check(ByVal NHSNMA As Object, ByVal NHSCD As Object) As Object
		Dim rtn As Short
		
		'UPGRADE_WARNING: オブジェクト NHSNMA_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSNMA_Check = 0
		'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト NHSNMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(NHSNMA) = "" Then
				'UPGRADE_WARNING: オブジェクト NHSNMA_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSNMA_Check = -1
			End If
		End If
	End Function
End Module