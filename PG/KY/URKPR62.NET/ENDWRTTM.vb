Option Strict Off
Option Explicit On
Module ENDWRTTM_F51
	'
	' スロット名        : 終了・入力日付・画面項目スロット
	' ユニット名        : ENDWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : IDOPR53
	'
	
	Function ENDWRTTM_CheckC(ByVal ENDWRTTM As Object) As Object
		Dim Rtn As Short
		Dim strWRTTM As String
		'
		'UPGRADE_WARNING: オブジェクト ENDWRTTM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strWRTTM = DeCNV_TIME(CStr(ENDWRTTM))
		
		'UPGRADE_WARNING: オブジェクト ENDWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDWRTTM_CheckC = 0
		If strWRTTM < "000000" Or strWRTTM > "235959" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ENDWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDWRTTM_CheckC = -1
		Else
			If Mid(strWRTTM, 1, 2) < "00" Or Mid(strWRTTM, 1, 2) > "23" Or Mid(strWRTTM, 3, 2) < "00" Or Mid(strWRTTM, 3, 2) > "59" Or Mid(strWRTTM, 5, 2) < "00" Or Mid(strWRTTM, 5, 2) > "59" Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
				'UPGRADE_WARNING: オブジェクト ENDWRTTM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDWRTTM_CheckC = -1
			End If
		End If
		
	End Function
	
	Function ENDWRTTM_InitVal(ByVal ENDWRTTM As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDWRTTM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDWRTTM_InitVal = "23:59:59"
	End Function
End Module