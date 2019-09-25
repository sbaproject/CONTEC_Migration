Option Strict Off
Option Explicit On
Module CHIIKI_F71
	'
	'スロット名      :商品コード・画面項目スロット
	'ユニット名      :CHIIKI.F71
	'記述者          :Standard Library
	'作成日付        :1996/07/03
	'使用プログラム  :NHSMR52
	'
	
	Function CHIIKI_Check(ByVal CHIIKI As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim MEINMA As String ' 2006.7.17 AZU Add
		Dim wkCHIIKI As String ' 2006.7.18 AZU Add
		
		'
		'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHIIKI_Check = 0
		' 2006.7.17 AZU Del Start
		'    If Trim$(CHIIKI) = "" Then CHIIKI = ""
		'    Call MEIMTA_RClear
		'    If Trim$(CHIIKI) = "" Then
		'  CHIIKI_Check = -1
		' 2006.7.17 AZU Del End
		' 2006.7.17 AZU Add Start
		Call MEIMTA_RClear()
		'UPGRADE_WARNING: オブジェクト CHIIKI の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CHIIKI) = "" Then
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_CHIIKI(De_Index, "")
			'        Call UnLock_Fields
			' GYOSHU_Check = -1
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_CHIIKIRN(De_Index, "")
			' 2006.7.17 AZU Add End
			'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHIIKI_Check = -1 '2006.12.26
		Else
			'UPGRADE_WARNING: オブジェクト CHIIKI の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkCHIIKI = CHIIKI & Space(Len(DB_MEIMTA.MEICDA) - Len(CHIIKI)) & Space(Len(DB_MEIMTA.MEICDB)) ' 2006.7.18 AZU Add
			'Call DB_GetEq(DBN_MEIMTA, 1, CHIIKI, BtrNormal)
			'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "004" & CHIIKI, BtrNormal)    ' 2006.7.17 AZU Add
			Call DB_GetGrEq(DBN_MEIMTA, 1, "004" & wkCHIIKI, BtrNormal) ' 2006.7.18 AZU Add
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CHIIKI_Check = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CHIIKI_Check = -1
			End If
			' 2006.7.17 AZU Add Start
			'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CHIIKI_Check = 0 Then
				'UPGRADE_WARNING: オブジェクト CHIIKI の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(CHIIKI) = Trim(DB_MEIMTA.MEICDA) Then
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_CHIIKI(De_Index, Trim(DB_MEIMTA.MEICDA))
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_CHIIKIRN(De_Index, Trim(DB_MEIMTA.MEINMA))
				Else
					rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: オブジェクト CHIIKI_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CHIIKI_Check = -1
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_CHIIKIRN(De_Index, " ")
				End If
			End If
			' 2006.7.17 AZU Add End
		End If
		'Call SCR_FromMEIMTA(De_Index)
	End Function
	
	Function CHIIKI_Slist(ByRef PP As clsPP, ByVal CHIIKI As Object) As Object
		'
		'WLS_LIST.Caption = "地域一覧"
		WLS_MEI1.Text = "地域一覧"
		'WLS_LIST!LST.Clear
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 1, "004", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "004"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		' 2006.7.17 AZU Mod Start
		'    SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
		SSS_WLSLIST_KETA = 5
		' 2006.7.17 AZU Mod End
		'DB_PARA(DBN_MEIMTA).KeyNo = 1
		'DB_PARA(DBN_MEIMTA).KeyBuf = CHIIKI
		'WLS_LIST.Show 1
		WLS_MEI1.ShowDialog()
		'Unload WLS_LIST
		WLS_MEI1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CHIIKI_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHIIKI_Slist = PP.SlistCom
	End Function
End Module