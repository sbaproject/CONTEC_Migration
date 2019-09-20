Option Strict Off
Option Explicit On
Module ENDTKDT_F51
	'
	' スロット名        : 適用開始日・画面項目スロット
	' ユニット名        : ENDTKDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/30
	' 使用プログラム名  : BMNMT51
	'
	
	Function ENDTKDT_CheckC(ByVal ENDTKDT As Object, ByVal BMNCD As Object, ByVal STTTKDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    連絡票№:283
		Dim wk_PxBase As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		'
		'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTKDT_CheckC = 0
		rtn = CHECK_DATE(ENDTKDT)
		If rtn Then
			'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetGrEq(DBN_BMNMTA, 3, BMNCD & VB6.Format(ENDTKDT, "YYYYMMDD"), BtrNormal)
			'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = BMNCD) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 0) '既に新しい日付で登録済の為エラー
				'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDTKDT_CheckC = -1
			End If
			'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(VB6.Format(STTTKDT, "YYYYMMDD")) <> "" Then
					'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If STTTKDT > ENDTKDT Then
						rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
					End If
				End If
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    連絡票№:283
			'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk_PxBase = 42 * De_Index
				'発注担当が入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_HTANCD(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'営業所コードが入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_EIGYOCD(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'地区区分が入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_TIKKB(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2009/08/25  FKS) T.Yamamoto    Start    連絡票№:FC09082501
				'上位部門コードが入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(22 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(22 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_BMNCDUP(AE_Val2(CP_SSSMAIN(22 + wk_PxBase)), CP_SSSMAIN(22 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2009/08/25  FKS) T.Yamamoto    End
				'''' ADD 2011/09/22  FKS) T.Yamamoto    Start    連絡票№FC11092201
				'会計部門が入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(10 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(10 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_ZMBMNCD(AE_Val2(CP_SSSMAIN(10 + wk_PxBase)), CP_SSSMAIN(10 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						ENDTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2011/09/22  FKS) T.Yamamoto    End
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ENDTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDTKDT_CheckC = -1
		End If
	End Function
	
	Function ENDTKDT_Skip(ByRef CT_ENDTKDT As System.Windows.Forms.Control, ByVal ENDTKDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDTKDT) <> "" Then
			'UPGRADE_WARNING: オブジェクト CT_ENDTKDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CT_ENDTKDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
		End If
		'UPGRADE_WARNING: オブジェクト ENDTKDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTKDT_Skip = False
	End Function
	
	Function ENDTKDT_Slist(ByRef PP As clsPP, ByVal ENDTKDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = ENDTKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト ENDTKDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTKDT_Slist = Set_date.Value
	End Function
End Module