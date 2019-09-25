Option Strict Off
Option Explicit On
Module BINCD_F71
	'
	'スロット名      :商品コード・画面項目スロット
	'ユニット名      :BINCD.F01
	'記述者          :Standard Library
	'作成日付        :2006/07/23
	'使用プログラム  :NHSFR52
	'
	
	Function BINCD_Check(ByVal BINCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim MEINMA As String
		Dim wkBINCD As String ' 2006.7.18 AZU Add
		
		'
		'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BINCD_Check = 0
		
		'UPGRADE_WARNING: オブジェクト BINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BINCD_Check = -1
			Exit Function
		End If
		
		Call MEIMTA_RClear()
		'UPGRADE_WARNING: オブジェクト BINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_BINCD(De_Index, "")
			'        Call UnLock_Fields
			' BINCD_Check = -1
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_BINRN(De_Index, " ")
			
		Else
			'UPGRADE_WARNING: オブジェクト BINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkBINCD = BINCD & Space(Len(DB_MEIMTA.MEICDA) - Len(BINCD)) & Space(Len(DB_MEIMTA.MEICDB)) ' 2006.7.18 AZU Add
			'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "002" & BINCD, BtrNormal)
			Call DB_GetGrEq(DBN_MEIMTA, 1, "002" & wkBINCD, BtrNormal) ' 2006.7.18 AZU Add
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					BINCD_Check = 1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				BINCD_Check = -1
			End If
			'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If BINCD_Check = 0 Then
				'UPGRADE_WARNING: オブジェクト BINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(BINCD) = Trim(DB_MEIMTA.MEICDA) Then
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_BINCD(De_Index, Trim(DB_MEIMTA.MEICDA))
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_BINRN(De_Index, Trim(DB_MEIMTA.MEINMA))
				Else
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
					'UPGRADE_WARNING: オブジェクト BINCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					BINCD_Check = -1
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_BINRN(De_Index, " ")
				End If
			End If
		End If
		
	End Function
	
	Function BINCD_Slist(ByRef PP As clsPP, ByVal BINCD As Object) As Object
		'
		'WLS_LIST.Caption = "便区分一覧"
		WLS_MEI1.Text = "便区分一覧"
		'WLS_LIST!LST.Clear
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		'Call DB_GetGrEq(DBN_MEIMTA, 2, "1" & "002" & "   ", BtrNormal)
		Call DB_GetGrEq(DBN_MEIMTA, 1, "002", BtrNormal)
		
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "002"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
		'WLS_LIST.Show 1
		WLS_MEI1.ShowDialog()
		'Unload WLS_LIST
		WLS_MEI1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト BINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BINCD_Slist = PP.SlistCom
		
	End Function
	Function BINCD_InitVal() As Object
		'    BINCD_InitVal = "00"
	End Function
End Module