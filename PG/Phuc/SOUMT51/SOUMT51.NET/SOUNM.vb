Option Strict Off
Option Explicit On
Module SOUNM_F53
	'
	' スロット名        : 倉庫名称・画面項目スロット
	' ユニット名        : SOUNM.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/26
	' 使用プログラム名  : SOUMT51
	'
	
	Function SOUNM_CHECK(ByVal SOUNM As Object, ByVal SOUCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: オブジェクト SOUNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(SOUNM) = "" Then
				'UPGRADE_WARNING: オブジェクト SOUNM_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUNM_CHECK = -1
			End If
		End If
		
	End Function
End Module