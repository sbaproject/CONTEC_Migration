Option Strict Off
Option Explicit On
Module HENRSNCD_F51
	'
	' スロット名        : 返品理由・画面項目スロット
	' ユニット名        : HENRSNCD.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/09
	' 使用プログラム名  : URIET54/URIET55
	'
	
	Function HENRSNCD_CheckC(ByVal HENRSNCD As Object, ByVal DE_INDEX As Object) As Object
		Dim Rtn As Short
		Dim keyVal As String
		Dim wkHENRSNCD As String
		'
		'UPGRADE_WARNING: オブジェクト HENRSNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HENRSNCD_CheckC = 0
        'UPGRADE_WARNING: オブジェクト HENRSNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(HENRSNCD) = "" Then
            '2019/09/19 DEL START
            'Call MEIMTA_RClear()
            '2019/09/19 DEL E N D
            'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call HENRSNCD_Move(DE_INDEX)
            'UPGRADE_WARNING: オブジェクト HENRSNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            HENRSNCD_CheckC = -1
        Else
            'UPGRADE_WARNING: オブジェクト HENRSNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkHENRSNCD = HENRSNCD & Space(Len(DB_MEIMTA.MEICDA) - Len(HENRSNCD))
            Call DB_GetEq(DBN_MEIMTA, 2, "009" & wkHENRSNCD, BtrNormal)
            If DBSTAT = 0 Then
                If DB_MEIMTA.DATKB = "9" Then
                    Call Dsp_Prompt("RNOTFOUND", 1) ' 削除レコードです。
                    'UPGRADE_WARNING: オブジェクト HENRSNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    HENRSNCD_CheckC = -1
                Else
                    'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call HENRSNCD_Move(DE_INDEX)
                End If
            Else
                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
				'UPGRADE_WARNING: オブジェクト HENRSNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HENRSNCD_CheckC = -1
			End If
			''''''''2007/04/23 DEL-START
			''''''''If HENRSNCD_CheckC = 0 And DB_MEIMTA.MEIKBB = "1" Then
			''''''''    If (WG_JKESIKN = 0) And (WG_FKESIKN = 0) Then
			''''''''    Else
			''''''''        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '入金済みの為エラー
			''''''''        HENRSNCD_CheckC = -1
			''''''''    End If
			''''''''End If
			''''''''2007/04/23 DEL-END
			
		End If
		
	End Function
	
	Sub HENRSNCD_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_HENRSNCD(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_HENRSNNM(De, DB_MEIMTA.MEINMA)
		''''Call DP_SSSMAIN_SOUCD(De, Left(DB_MEIMTA.MEINMB, Len(DB_SOUMTA.SOUCD)))
		Call DP_SSSMAIN_MEIKBA(De, DB_MEIMTA.MEIKBA)
		Call DP_SSSMAIN_MEIKBB(De, DB_MEIMTA.MEIKBB)
		Call DP_SSSMAIN_MEIKBC(De, DB_MEIMTA.MEIKBC)
		
	End Sub '
	
	Function HENRSNCD_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "返品理由一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "009", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "009"
			CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 2
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト HENRSNCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HENRSNCD_Slist = PP.SlistCom
		
	End Function
End Module