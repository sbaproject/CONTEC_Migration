Option Strict Off
Option Explicit On
Module NHSCD_F83
	'
	'スロット名      :納品先コード・画面項目スロット
	'ユニット名      :NHSCD.F83
	'記述者          :Standard Library
	'作成日付        :1996/07/03
	'使用プログラム  :NHSMR52
	'
	
	Function NHSCD_CheckC(ByVal NHSCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト NHSCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCD_CheckC = 0
		Call NHSMTA_RClear()
		'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSCD) = "" Then
			'必須チェック止める
			'        NHSCD_CheckC = -1
		Else
			'入力コードと同様の場合チェックしない
			'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(FR_SSSMAIN.HD_NHSCD.Text) <> Trim(NHSCD) Then
				Call DB_GetEq(DBN_NHSMTA, 1, NHSCD, BtrNormal)
				If DBSTAT <> 0 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: オブジェクト NHSCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					NHSCD_CheckC = -1
				Else
					If DB_NHSMTA.DATKB = "9" Then
						Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
						'UPGRADE_WARNING: オブジェクト NHSCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						NHSCD_CheckC = 1
					End If
				End If
			End If
		End If
		
	End Function
End Module