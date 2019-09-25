Option Strict Off
Option Explicit On
Module SOUBSCD_F51
	'
	'スロット名      :場所コード・画面項目スロット
	'ユニット名      :SOUBSCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/05/29
	'使用プログラム  :SOUMT51
	'                :
	'                :
	
	Function SOUBSCD_Check(ByVal SOUBSCD As Object, ByVal De_Index As Object, ByVal Ex_SOUBSCD As Object) As Object
		Dim Rtn As Short
		Dim wkSOUBSCD As String
		'
		'UPGRADE_WARNING: オブジェクト SOUBSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUBSCD_Check = 0
        '2019/09/25 DEL START
        'Call MEIMTA_RClear()
        '2019/09/25 DEL END
        'UPGRADE_WARNING: オブジェクト SOUBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(SOUBSCD) = "" Then
            '2019/09/25 DEL START
            'Call MEIMTA_RClear()
            '2019/09/25 DEL END
            'UPGRADE_WARNING: オブジェクト SOUBSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            SOUBSCD_Check = -1
		Else
            'UPGRADE_WARNING: オブジェクト SOUBSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            wkSOUBSCD = SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(SOUBSCD))
            Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト SOUBSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SOUBSCD_Check = -1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト SOUBSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUBSCD_Check = -1
			End If
			
		End If
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call SOUBSCD_Move(De_Index)
		
	End Function
	
	Function SOUBSCD_Slist(ByRef PP As clsPP, ByVal SOUBSCD As Object) As Object
		'
		WLS_MEI1.Text = "場所名称一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		' Call DB_GetFirst(DBN_MEIMTA, 1, BtrNormal)
		Call DB_GetGrEq(DBN_MEIMTA, 3, "015", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "015"
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
		'UPGRADE_WARNING: オブジェクト SOUBSCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUBSCD_Slist = PP.SlistCom
	End Function
	
	Sub SOUBSCD_Move(ByVal De As Short)
		If Trim(DB_MEIMTA.MEICDA) <> "" Then
			Call DP_SSSMAIN_SOUBSCD(De, Trim(DB_MEIMTA.MEICDA))
			Call DP_SSSMAIN_SOUBSNM(De, Trim(DB_MEIMTA.MEINMA))
		Else
			Call DP_SSSMAIN_SOUBSCD(De, "")
			DB_MEIMTA.MEIKMKNM = ""
			Call DP_SSSMAIN_SOUBSNM(De, "")
		End If
		
	End Sub
	'''''
	'''''Function SOUBSCD_DerivedC(ByVal SOUBSCD, ByVal SOUCD, ByVal De_Index)
	'''''Dim wkSOUBSCD As String
	'''''
	'''''    SOUBSCD_DerivedC = SOUBSCD
	'''''    wkSOUBSCD = SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(SOUBSCD))
	'''''    Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
	'''''    If DBSTAT = 0 Then
	'''''        Call SOUBSCD_Move(De_Index)
	'''''    End If
	'''''End Function
End Module