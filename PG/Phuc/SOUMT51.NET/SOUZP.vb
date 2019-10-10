Option Strict Off
Option Explicit On
Module SOUZP_F51
	'
	'スロット名      :郵便番号・画面項目スロット
	'ユニット名      :SOUZP.F51
	'記述者          :Standard Library
	'作成日付        :2006/06/05
	'使用プログラム  :SOUMT51
	'
	
	Function SOUZP_CheckC(ByVal SOUZP As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト SOUZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUZP_CheckC = 0
		
		'UPGRADE_WARNING: オブジェクト SOUZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(SOUZP)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(SOUZP)) = 0 Then
		Else
			'UPGRADE_WARNING: オブジェクト SOUZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(Trim(SOUZP)) <> Len508 Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "SOUMT51", 0) '郵便番号桁数エラー
				'UPGRADE_WARNING: オブジェクト SOUZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUZP_CheckC = -1
				Exit Function
			End If
			
			'UPGRADE_WARNING: オブジェクト SOUZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Mid(SOUZP, Len509, 1) <> "-" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "SOUMT51", 1) '郵便番号ハイフン位置エラー
				'UPGRADE_WARNING: オブジェクト SOUZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUZP_CheckC = -1
				Exit Function
			End If
		End If
		
	End Function
End Module