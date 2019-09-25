Option Strict Off
Option Explicit On
Module NHSZP_F71
	'
	'スロット名      :郵便番号・画面項目スロット
	'ユニット名      :NHSZP.F51
	'記述者          :Standard Library
	'作成日付        :2006/09/22
	'使用プログラム  :NHSMR51
	'
	
	Function NHSZP_CheckC(ByVal NHSZP As Object, ByVal FRNKB As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト NHSZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSZP_CheckC = 0
		
		'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If FRNKB = "0" Then
			'UPGRADE_WARNING: オブジェクト NHSZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト LenWid(Trim$(NHSZP)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(Trim(NHSZP)) = 0 Then
			Else
				'UPGRADE_WARNING: オブジェクト NHSZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Len(Trim(NHSZP)) <> Len508 Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "NHSMR52", 0) '郵便番号桁数エラー
					'UPGRADE_WARNING: オブジェクト NHSZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					NHSZP_CheckC = -1
					Exit Function
				End If
				
				'UPGRADE_WARNING: オブジェクト NHSZP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Mid(NHSZP, Len509, 1) <> "-" Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "NHSMR52", 1) '郵便番号ハイフン位置エラー
					'UPGRADE_WARNING: オブジェクト NHSZP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					NHSZP_CheckC = -1
					Exit Function
				End If
			End If
		End If
		
	End Function
End Module