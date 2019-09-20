Option Strict Off
Option Explicit On
Module STNNM_F51
	'
	'スロット名      :支店名称・画面項目スロット
	'ユニット名      :STNNM.FM1
	'記述者          :Standard Library
	'作成日付        :2006/08/25
	'使用プログラム  :BNKMT51
	'
	
	Function STNNM_CheckC(ByRef STNNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STNNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STNNM_CheckC = 0
		'UPGRADE_WARNING: オブジェクト STNNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STNNM) = "" Then
			'UPGRADE_WARNING: オブジェクト STNNM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STNNM_CheckC = -1
		End If
	End Function
End Module