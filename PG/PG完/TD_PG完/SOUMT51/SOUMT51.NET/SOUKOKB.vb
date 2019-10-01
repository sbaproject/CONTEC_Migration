Option Strict Off
Option Explicit On
Module SOUKOKB_F51
	'
	'スロット名      :倉庫区分・画面項目スロット
	'ユニット名      :SOUKOKB.F51
	'記述者          :Standard Library
	'作成日付        :2006/08/28
	'使用プログラム  :SOUMT51
	'                :
	'                :
	
	Function SOUKOKB_Check(ByVal SOUKOKB As Object, ByVal De_Index As Object, ByVal Ex_SOUKOKB As Object) As Object
		Dim Rtn As Short
		Dim wkSOUKOKB As String
		'
		'UPGRADE_WARNING: オブジェクト SOUKOKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUKOKB_Check = 0
        '20190819 DELL START
        'Call MEIMTA_RClear()
        '20190819 DELL END
        'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(SOUKOKB) = "" Then
            '20190891 DELL START
            'Call MEIMTA_RClear()
            '20190819 DELL END
            'UPGRADE_WARNING: オブジェクト SOUKOKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            SOUKOKB_Check = -1
        Else
            'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkSOUKOKB = SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(SOUKOKB))
			Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト SOUKOKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SOUKOKB_Check = -1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト SOUKOKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUKOKB_Check = -1
			End If
			
		End If
		'UPGRADE_WARNING: オブジェクト SOUKOKB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SOUKOKB_Check = 0 Then
			'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SOUKOKB = "03" Then '特定顧客倉庫
				Call AE_InOutModeN_SSSMAIN("SOUTRICD", "3303")
			Else
				Call AE_InOutModeN_SSSMAIN("SOUTRICD", "2202")
			End If
			'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SOUKOKB = "10" Then '貸出倉庫
				Call AE_InOutModeN_SSSMAIN("SRSCNKB", "0000")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SRSCNKB(De_Index, "9")
			Else
				Call AE_InOutModeN_SSSMAIN("SRSCNKB", "3303")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SRSCNKB(De_Index, "1")
			End If
		End If
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call SOUKOKB_Move(De_Index)
		
	End Function
	
	Function SOUKOKB_Slist(ByRef PP As clsPP, ByVal SOUKOKB As Object) As Object
		'
		WLS_MEI1.Text = "倉庫区分一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "026", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "026"
			If DB_MEIMTA.DATKB <> "9" Then
				CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
			End If
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
		WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SOUKOKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUKOKB_Slist = PP.SlistCom
	End Function
	
	Sub SOUKOKB_Move(ByVal De As Short)
		If Trim(DB_MEIMTA.MEICDA) <> "" Then
			Call DP_SSSMAIN_SOUKOKB(De, Trim(DB_MEIMTA.MEICDA))
			Call DP_SSSMAIN_SOUKONM(De, Trim(DB_MEIMTA.MEINMA))
		Else
			Call DP_SSSMAIN_SOUKOKB(De, "")
			DB_MEIMTA.MEIKMKNM = ""
			Call DP_SSSMAIN_SOUKONM(De, "")
		End If
		
	End Sub
	
	Function SOUKOKB_DerivedC(ByVal SOUKOKB As Object, ByVal SOUCD As Object, ByVal De_Index As Object) As Object
		Dim wkSOUKOKB As String
		
		'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SOUKOKB_DerivedC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUKOKB_DerivedC = SOUKOKB
        'UPGRADE_WARNING: オブジェクト SOUKOKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Len(DB_MEIMTA.MEICDA) > Len(SOUKOKB) Then
            wkSOUKOKB = SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(SOUKOKB))

        Else
            wkSOUKOKB = SOUKOKB

        End If
        Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
        If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call SOUKOKB_Move(De_Index)
		End If
	End Function
End Module