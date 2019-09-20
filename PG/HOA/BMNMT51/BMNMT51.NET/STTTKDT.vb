Option Strict Off
Option Explicit On
Module STTTKDT_F51
	'
	' スロット名        : 適用開始日・画面項目スロット
	' ユニット名        : STTTKDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/30
	' 使用プログラム名  : BMNMT51
	'
	
	Function STTTKDT_CheckC(ByVal STTTKDT As Object, ByVal BMNCD As Object, ByVal ENDTKDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    連絡票№:283
		Dim wk_PxBase As Short
		'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		'
		
		'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTKDT_CheckC = 0
		rtn = CHECK_DATE(STTTKDT)
		If rtn Then
			'適用日にデータが入ったら、当該データを検索
			Call BMNMTA_RClear()
			'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_BMNMTA, 1, BMNCD & VB6.Format(STTTKDT, "YYYYMMDD"), BtrNormal)
			If DBSTAT = 0 Then
				If DB_BMNMTA.DATKB = "9" Then
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "削除")
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "更新")
				End If
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call SCR_FromMfil(De_Index)
				Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCDUP & "        ", BtrNormal)
				'''' UPD 2009/08/25  FKS) T.Yamamoto    Start    連絡票№:FC09082501
				'            If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(De_Index)) Then
				'                Call DP_SSSMAIN_BMNNMUP(De_Index, DB_BMNMTA.BMNNM)
				'            Else
				'                Call DP_SSSMAIN_BMNNMUP(De_Index, "")
				'            End If
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_BMNNMUP(De_Index, "")
				Do While (DBSTAT = 0)
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT(De_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT(De_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCDUP(De_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(De_Index)) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(De_Index)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(De_Index)) Then
						'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call DP_SSSMAIN_BMNNMUP(De_Index, DB_BMNMTA.BMNNM)
						Exit Do
					End If
					Call DB_GetNext(DBN_BMNMTA, BtrNormal)
				Loop 
				'''' UPD 2009/08/25  FKS) T.Yamamoto    End
			Else
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_UPDKB(De_Index, "追加")
				Call BMNMTA_RClear()
				'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetGrEq(DBN_BMNMTA, 3, BMNCD & VB6.Format(STTTKDT, "YYYYMMDD"), BtrNormal)
				'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = BMNCD) Then
					rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 0) '既に新しい日付で登録済の為エラー
					'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTKDT_CheckC = -1
				End If
				'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(VB6.Format(ENDTKDT, "YYYYMMDD")) <> "" Then
					'UPGRADE_WARNING: オブジェクト ENDTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If STTTKDT > ENDTKDT Then
						rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
					End If
				End If
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    Start    連絡票№:283
			'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If STTTKDT_CheckC = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk_PxBase = 42 * De_Index
				'発注担当が入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(11 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_HTANCD(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'営業所コードが入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(13 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_EIGYOCD(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'地区区分が入力されている場合、項目チェックを行う
				'UPGRADE_WARNING: オブジェクト AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_Val2(CP_SSSMAIN(14 + wk_PxBase)) <> "" Then
					Call AE_Check_SSSMAIN_TIKKB(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Ck_Error <> 0 Then
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
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
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
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
						'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						STTTKDT_CheckC = -1
						Exit Function
					End If
				End If
				'''' ADD 2011/09/22  FKS) T.Yamamoto    End
			End If
			'''' ADD 2009/07/22  FKS) T.Yamamoto    End
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト STTTKDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTTKDT_CheckC = -1
		End If
		
	End Function
	
	Function STTTKDT_Skip(ByRef CT_STTTKDT As System.Windows.Forms.Control, ByVal STTTKDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTTKDT) <> "" Then
			'UPGRADE_WARNING: オブジェクト CT_STTTKDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CT_STTTKDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
		End If
		'UPGRADE_WARNING: オブジェクト STTTKDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTKDT_Skip = False
	End Function
	
	Function STTTKDT_Slist(ByRef PP As clsPP, ByVal STTTKDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = STTTKDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト STTTKDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTKDT_Slist = Set_date.Value
	End Function
End Module