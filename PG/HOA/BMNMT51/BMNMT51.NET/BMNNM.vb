Option Strict Off
Option Explicit On
Module BMNNM_F51
	'
	'スロット名      :部門名称・画面項目スロット
	'ユニット名      :BMNNM.F51
	'記述者          :Standard Library
	'作成日付        :2006/08/30
	'使用プログラム  :BNKMT51
	'
	
	Function BMNNM_CheckC(ByRef BMNNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト BMNNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BMNNM_CheckC = 0
		'UPGRADE_WARNING: オブジェクト BMNNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BMNNM) = "" Then
			'UPGRADE_WARNING: オブジェクト BMNNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BMNNM_CheckC = -1
		End If
	End Function
End Module