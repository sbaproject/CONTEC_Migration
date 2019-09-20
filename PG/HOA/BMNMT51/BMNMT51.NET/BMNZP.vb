Option Strict Off
Option Explicit On
Module BMNZP_F51
	'
	'スロット名      :郵便番号・画面項目スロット
	'ユニット名      :BMNZP.F51
	'記述者          :Standard Library
	'作成日付        :2006/08/30
	'使用プログラム  :BMNMT51
	'
	
	Function BMNZP_CheckC(ByVal BMNZP As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト BMNZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BMNZP_CheckC = 0
		
		'UPGRADE_WARNING: オブジェクト BMNZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(BMNZP)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(BMNZP)) = 0 Then
		Else
			'UPGRADE_WARNING: オブジェクト BMNZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(Trim(BMNZP)) <> Len508 Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 1) '郵便番号桁数エラー
				'UPGRADE_WARNING: オブジェクト BMNZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				BMNZP_CheckC = -1
				Exit Function
			End If
			'UPGRADE_WARNING: オブジェクト BMNZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Mid(BMNZP, Len509, 1) <> "-" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 2) '郵便番号ハイフン位置エラー
				'UPGRADE_WARNING: オブジェクト BMNZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				BMNZP_CheckC = -1
				Exit Function
			End If
		End If
		
	End Function
End Module