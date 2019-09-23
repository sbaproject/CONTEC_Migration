Option Strict Off
Option Explicit On
Module HENSTTCD_F51
	'
	' スロット名        : 状態・画面項目スロット
	' ユニット名        : HENSTTCD.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/09
	' 使用プログラム名  : URIET54/URIET55
	'
	
	Function HENSTTCD_CheckC(ByVal HENSTTCD As Object, ByVal DE_INDEX As Object) As Object
		Dim rtn As Short
		Dim keyVal As String
		Dim wkHENSTTCD As String
		'
		'UPGRADE_WARNING: オブジェクト HENSTTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HENSTTCD_CheckC = 0
        'UPGRADE_WARNING: オブジェクト HENSTTCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(HENSTTCD) = "" Then
            '2019/09/19 DEL START
            'Call MEIMTA_RClear()
            '2019/09/19 DEL E N D
            'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call HENSTTCD_Move(DE_INDEX)
            'UPGRADE_WARNING: オブジェクト HENSTTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            HENSTTCD_CheckC = -1
        Else
            'UPGRADE_WARNING: オブジェクト HENSTTCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkHENSTTCD = HENSTTCD & Space(Len(DB_MEIMTA.MEICDA) - Len(HENSTTCD))
			Call DB_GetEq(DBN_MEIMTA, 2, "010" & wkHENSTTCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除レコードです。
					'UPGRADE_WARNING: オブジェクト HENSTTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					HENSTTCD_CheckC = -1
				Else
					'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call HENSTTCD_Move(DE_INDEX)
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
				'UPGRADE_WARNING: オブジェクト HENSTTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HENSTTCD_CheckC = -1
			End If
		End If
		
	End Function
	
	Sub HENSTTCD_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_HENSTTCD(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_HENSTTNM(De, DB_MEIMTA.MEINMA)
		
	End Sub '
	
	Function HENSTTCD_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "返品状態一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "010", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "010"
			CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 2
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト HENSTTCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HENSTTCD_Slist = PP.SlistCom
		
	End Function
End Module