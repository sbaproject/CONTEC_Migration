Option Strict Off
Option Explicit On
Module BMNCD_F51
	'
	'スロット名      :部門コード・画面項目スロット
	'ユニット名      :BMNCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/05/31
	'使用プログラム  :BMNMT51
	'
	
	Function BMNCD_CheckC(ByVal BMNCD As Object, ByVal STTTKDT As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト BMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BMNCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Dim rtn As Short
		If Trim(BMNCD) = "" Then
			'UPGRADE_WARNING: オブジェクト BMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BMNCD_CheckC = -1
		Else
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
				'''' ADD 2009/09/14  FKS) T.Yamamoto    Start    連絡票№335
				'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If STTTKDT <> "" Then
					Call BMNMTA_RClear()
					'UPGRADE_WARNING: オブジェクト STTTKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DB_GetGrEq(DBN_BMNMTA, 3, BMNCD & VB6.Format(STTTKDT, "YYYYMMDD"), BtrNormal)
					'UPGRADE_WARNING: オブジェクト BMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = BMNCD) Then
						rtn = DSP_MsgBox(SSS_CONFRM, "BMNMT51", 0) '既に新しい日付で登録済の為エラー
						'UPGRADE_WARNING: オブジェクト BMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						BMNCD_CheckC = -1
					End If
				End If
				'''' ADD 2009/09/14  FKS) T.Yamamoto    End
			End If
		End If
	End Function
	
	Function BMNCD_Slist(ByRef PP As clsPP, ByVal BMNCD As Object, ByVal De_Index As Object) As Object
		
		WLSBMN.Text = "部門一覧"
		DB_PARA(DBN_BMNMTA).KeyNo = 1
		''''DB_PARA(DBN_BMNMTA).KeyBuf = BMNCD
		DB_PARA(DBN_BMNMTA).KeyBuf = ""
		WLSBMN.ShowDialog()
		WLSBMN.Close()
		''''BMNCD_Slist = PP.SlistCom
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(PP.SlistCom) Then
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト BMNCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BMNCD_Slist = System.DBNull.Value
			'''''        Call DP_SSSMAIN_STTTKDT(De_Index, "")
		Else
			'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BMNCD_Slist = Left(PP.SlistCom, Len(DB_BMNMTA.BMNCD))
			'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_STTTKDT(De_Index, Mid(PP.SlistCom, 7, Len(DB_BMNMTA.STTTKDT)))
		End If
		
		
	End Function
End Module