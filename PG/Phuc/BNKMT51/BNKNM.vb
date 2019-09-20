Option Strict Off
Option Explicit On
Module BNKNM_F51
	'
	'スロット名      :銀行名称・画面項目スロット
	'ユニット名      :BNKNM.FM1
	'記述者          :Standard Library
	'作成日付        :2006/08/25
	'使用プログラム  :BNKMT51
	'
	
	Function BNKNM_CheckC(ByRef BNKNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト BNKNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BNKNM_CheckC = 0
		'UPGRADE_WARNING: オブジェクト BNKNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BNKNM) = "" Then
			'UPGRADE_WARNING: オブジェクト BNKNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BNKNM_CheckC = -1
		End If
	End Function
End Module