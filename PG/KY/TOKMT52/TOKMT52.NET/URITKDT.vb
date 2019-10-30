Option Strict Off
Option Explicit On
Module URITKDT_F51
	'
	' スロット名        : 単価設定日付・画面項目スロット
	' ユニット名        : URITKDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/21
	' 使用プログラム名  : TOKMT54
	'
	
	Function URITKDT_CheckC(ByVal HINCD As Object, ByVal TOKCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'Call HINMTA_RClear
		'Call TOKMTA_RClear
		'Call TOKMTC_RClear
		'Call SCR_FromMfil(De_Index)
		'UPGRADE_WARNING: オブジェクト URITKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URITKDT_CheckC = 0
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(URITKDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
			'UPGRADE_WARNING: オブジェクト URITKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URITKDT_CheckC = -1
		Else
			If Not IsDate(URITKDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
				'UPGRADE_WARNING: オブジェクト URITKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URITKDT_CheckC = -1
			Else
				'運用日付とのﾁｪｯｸ
				'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CInt(VB6.Format(URITKDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
					Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) '日付に誤りがあります。修正してください。
					'UPGRADE_WARNING: オブジェクト URITKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URITKDT_CheckC = -1
				End If
			End If
		End If
	End Function
	
	Function URITKDT_DerivedC(ByVal HINCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		'
		'If Trim$(HINCD) <> "" And Trim$(TOKCD) <> "" And Trim$(URITKDT) = "" Then
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then
			Call HINMTA_RClear()
			Call TOKMTA_RClear()
			Call TOKMTC_RClear()
			'URITKDT_DerivedC = Date           ' 本日の日付。
		Else
			'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case Trim(URITKDT)
				Case ""
					'URITKDT_DerivedC = Date           '本日の日付。
					'UPGRADE_WARNING: オブジェクト URITKDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URITKDT_DerivedC = DB_UNYMTA.UNYDT '運用日付
				Case Else
					'                If Trim$(URITKDT) <> "" Then
					'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト URITKDT_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URITKDT_DerivedC = URITKDT
					'                Else
					'URITKDT_DerivedC = Date
					'                  URITKDT_DerivedC = DB_UNYMTA.UNYDT '運用日付
					'                End If
			End Select
		End If
	End Function
	
	Function URITKDT_InitVal(ByVal HINCD As Object, ByVal URITKDT As Object, ByVal De_Index As Object) As Object
		'
		'If Trim$(TOKCD) = "" Then Exit Function
		'URITKDT_InitVal = URITKDT          '前の日付。
		
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト URITKDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URITKDT_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(URITKDT) = "" Then
				'URITKDT_InitVal = Date
				'UPGRADE_WARNING: オブジェクト URITKDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URITKDT_InitVal = DB_UNYMTA.UNYDT '運用日付
			End If
		End If
		
	End Function
	Sub URITKDT_Move(ByVal URITKDT As Object, ByVal De As Short)
		
		If Trim(DB_TOKMTC.URITKDT) = "" Then
			Call DP_SSSMAIN_URITKDT(De, "")
		Else
			Call DP_SSSMAIN_URITKDT(De, DB_TOKMTC.URITKDT)
		End If
		'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTC.URITK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CStr(DB_TOKMTC.URITK)) = "" Or SSSVal(DB_TOKMTC.URITK) = 0 Then
			Call DP_SSSMAIN_URITK(De, "")
		Else
			Call DP_SSSMAIN_URITK(De, DB_TOKMTC.URITK)
		End If
		
	End Sub
	
	Function URITKDT_Skip(ByRef CT_URITKDT As System.Windows.Forms.Control, ByVal URITKDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URITKDT) <> "" Then
			'UPGRADE_WARNING: オブジェクト CT_URITKDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CT_URITKDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
		End If
		'UPGRADE_WARNING: オブジェクト URITKDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URITKDT_Skip = False
	End Function
	
	Function URITKDT_Slist(ByVal URITKDT As Object, ByRef PP As clsPP, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = URITKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト URITKDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URITKDT_Slist = Set_date.Value
		
	End Function
End Module