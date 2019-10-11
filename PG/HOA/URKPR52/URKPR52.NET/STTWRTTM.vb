Option Strict Off
Option Explicit On
Module STTWRTTM_F51
	'
	' スロット名        : 開始・入力日付・画面項目スロット
	' ユニット名        : STTWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : IDOPR53
	'
	
	Function STTWRTTM_CheckC(ByVal STTWRTTM As Object) As Object
		Dim Rtn As Short
		Dim strWRTTM As String
		
		'
		'UPGRADE_WARNING: オブジェクト STTWRTTM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strWRTTM = DeCNV_TIME(CStr(STTWRTTM))
		
		'UPGRADE_WARNING: オブジェクト STTWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTWRTTM_CheckC = 0
		If strWRTTM < "000000" Or strWRTTM > "235959" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト STTWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTWRTTM_CheckC = -1
		Else
			If Mid(strWRTTM, 1, 2) < "00" Or Mid(strWRTTM, 1, 2) > "23" Or Mid(strWRTTM, 3, 2) < "00" Or Mid(strWRTTM, 3, 2) > "59" Or Mid(strWRTTM, 5, 2) < "00" Or Mid(strWRTTM, 5, 2) > "59" Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
				'UPGRADE_WARNING: オブジェクト STTWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STTWRTTM_CheckC = -1
			End If
		End If
		
	End Function
	
	Function STTWRTTM_InitVal(ByVal STTWRTTM As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTWRTTM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTWRTTM_InitVal = "00:00:00"
	End Function
End Module