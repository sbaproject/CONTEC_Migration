Option Strict Off
Option Explicit On
Module TOKCD_F56
	'
	'スロット名      :得意先コード・画面項目スロット
	'ユニット名      :TOKCD.F56
	'記述者          :Standard Library
	'作成日付        :2006/08/25
	'使用プログラム  :URIPR52
	'
	
	Function TOKCD_CheckC(ByVal TOKCD As Object) As Object
		Dim Rtn As Short
		Dim wkTOKCD As String
		'
		DB_TOKMTA.TOKRN = ""
		'UPGRADE_WARNING: オブジェクト TOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TOKCD_CheckC = 0
        '2019.04.08 DEL START
        'Call TOKMTA_RClear()
        '2019.04.08 DEL END
        'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(TOKCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(TOKCD)) = 0 Then
			Call TOKCD_Move(TOKCD)
		Else
            'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019.04.11 del start
            'wkTOKCD = TOKCD & Space(Len(DB_TOKMTA.TOKCD) - Len(TOKCD)) & Space(Len(DB_TOKMTA.TOKCD))
            '2019.04.11 del end
            '2019.03.29 CHG START
            'Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
            'change start 20190808 kuwahara
            'Call TOKMTA_GetFirst(Trim(TOKCD))
            GetRowsCommon("TOKMTA", "where TOKCD = '" & TOKCD & "'")
            'change end 20190808 kuwahara
            '2019.03.29 CHG END
            If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト TOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					TOKCD_CheckC = 1
				End If
				Call TOKCD_Move(TOKCD)
			Else
                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。32
                'UPGRADE_WARNING: オブジェクト TOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                TOKCD_CheckC = -1
			End If
		End If
        'Call SCR_FromTOKMTA(De_Index)
    End Function

    Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object

        'delete start 20190819 kuwahara
        'DB_PARA(DBN_TOKMTA).KeyNo = 1
        'DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
        'delete end 20190819 kuwahara
        '2019.04.08 CHG START
        'WLSTOK.ShowDialog()
        'WLSTOK.Close()
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        '2019.04.08 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        TOKCD_Slist = PP.SlistCom
    End Function
    Sub TOKCD_Move(ByVal TOKCD As Object)
		Dim De As Short
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TOKCD) = "" Then
			Call DP_SSSMAIN_TOKCD(De, "")
			Call DP_SSSMAIN_TOKRN(De, "")
			
		Else
			Call DP_SSSMAIN_TOKCD(De, DB_TOKMTA.TOKCD)
			Call DP_SSSMAIN_TOKRN(De, DB_TOKMTA.TOKRN)
		End If
	End Sub
End Module