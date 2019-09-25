Option Strict Off
Option Explicit On
Module NHSFX_F71
	'
	' スロット名        : 電話番号・画面項目スロット
	' ユニット名        : NHSFX.F81
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : NHSMR51
	'
	' 更新日付          :2006/11/09
	' 更新内容          :エラーチェック追加
	
	Function NHSFX_CheckC(ByVal NHSFX As Object, ByVal FRNKB As Object) As Object
		
		Dim Rtn As Short
		Dim CntHP As Short
		Dim LenAll As Short
		Dim lngI As Integer
		Dim lngPOS As Integer
		
		'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSFX_CheckC = 0
		
		'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		LenAll = Len(Trim(NHSFX))
		
		If LenAll = 0 Then
			Exit Function
		End If
		
		'電話番号ハイフン先頭エラー
		'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Left(NHSFX, 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 0) 'ハイフンが先頭にあります。
			'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NHSFX_CheckC = -1
			Exit Function
		End If
		
		'電話番号ハイフン末尾エラー
		'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Right(Trim(NHSFX), 1) = "-" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 1) 'ハイフンが末尾にあります。
			'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			NHSFX_CheckC = -1
			Exit Function
		End If
		
		'電話番号ハイフン連続入力エラー
		'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		For lngI = 1 To Len(Trim(NHSFX))
			'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Mid(Trim(NHSFX), lngI, 1) = "-" Then
				'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Mid(Trim(NHSFX), lngI + 1, 1) = "-" Then
					Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 2) 'ハイフンを複数連続して入力しています。
					'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					NHSFX_CheckC = -1
					Exit Function
				End If
			End If
		Next 
		
		'国内の場合のみチェック
		'UPGRADE_WARNING: オブジェクト FRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If FRNKB = "0" Then
			
			'総桁数チェック
			If LenAll > Len506 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 3) '桁数オーバーです。
				'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSFX_CheckC = -1
				Exit Function
			End If
			
			'ハイフン個数チェック
			lngPOS = 0
			CntHP = 0
			For lngI = 1 To LenAll
				'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Mid(NHSFX, lngI, 1) = "-" Then
					CntHP = CntHP + 1
					If CntHP = Len507 Then
						lngPOS = lngI '2個目の位置を退避
					End If
				End If
			Next 
			If CntHP <> Len507 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 4) 'ハイフン個数の誤りです。
				'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSFX_CheckC = -1
				Exit Function
			End If
			
			'電話番号下桁チェック
			'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(Mid(Trim(NHSFX), lngPOS + 1, Len(Trim(NHSFX)) - lngPOS)) <> Len511 Then
				Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '入力が不正です。
				'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSFX_CheckC = -1
				Exit Function
			Else
				'UPGRADE_WARNING: オブジェクト NHSFX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If IsNumeric(Mid(Trim(NHSFX), lngPOS + 1, Len(Trim(NHSFX)) - lngPOS)) = False Then
					Rtn = DSP_MsgBox(SSS_ERROR, "TEL_FAX_NO", 5) '入力が不正です。
					'UPGRADE_WARNING: オブジェクト NHSFX_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					NHSFX_CheckC = -1
					Exit Function
				End If
			End If
			
		End If
		
	End Function
End Module