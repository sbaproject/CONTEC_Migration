Option Strict Off
Option Explicit On
Module ENDNHSCD_F51
	'
	'スロット名      :納入先コード・画面項目スロット
	'ユニット名      :NHSCD.F55
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function ENDNHSCD_Check(ByVal ENDNHSCD As Object, ByVal STTNHSCD As Object) As Object
		Dim rtn As Short
		Dim wkNHSCD As String
		'
		'UPGRADE_WARNING: オブジェクト ENDNHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDNHSCD_Check = 0
		'UPGRADE_WARNING: オブジェクト STTNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ENDNHSCD < STTNHSCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: オブジェクト ENDNHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDNHSCD_Check = -1
			Exit Function
		End If


        '2019/10/14 DEL START
        'Call NHSMTA_RClear()
        '2019/10/14 DEL E N D

        'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(ENDNHSCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(ENDNHSCD) = 0 Or Trim(ENDNHSCD) = "" Or ENDNHSCD = "ﾝﾝﾝﾝﾝﾝﾝﾝﾝ" Then
		Else
			'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkNHSCD = ENDNHSCD & Space(Len(DB_NHSMTA.NHSCD) - Len(ENDNHSCD))
			Call DB_GetEq(DBN_NHSMTA, 1, wkNHSCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_NHSMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        ENDNHSCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDNHSCD_Check = -1
			''''''''End If
			
		End If
		'Call SCR_FromNHSMTA(De_Index)
	End Function
	
	Function ENDNHSCD_Slist(ByRef PP As clsPP, ByVal ENDNHSCD As Object) As Object
		'
		DB_PARA(DBN_NHSMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト ENDNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_NHSMTA).KeyBuf = ENDNHSCD
        '2019/10/14 CHG START
        'WLSNHS.ShowDialog()
        'WLSNHS.Close()
        WLSNHS2.ShowDialog()
        WLSNHS2.Close()
        '2019/10/14 CHG E N D
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ENDNHSCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ENDNHSCD_Slist = PP.SlistCom
	End Function
	Function ENDNHSCD_InitVal(ByVal ENDNHSCD As Object) As Object
		''''ENDNHSCD_InitVal = " "
		''''ENDNHSCD_InitVal = "ZZZZZZZZZ"
		'UPGRADE_WARNING: オブジェクト ENDNHSCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDNHSCD_InitVal = "ﾝﾝﾝﾝﾝﾝﾝﾝﾝ"
	End Function
End Module