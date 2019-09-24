Option Strict Off
Option Explicit On
Module ENDBNKCD_F52
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :SOUCD.F55
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function ENDBNKCD_Check(ByVal ENDBNKCD As Object, ByVal STTBNKCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDBNKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDBNKCD_Check = 0
		'UPGRADE_WARNING: オブジェクト STTBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ENDBNKCD < STTBNKCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: オブジェクト ENDBNKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDBNKCD_Check = -1
			Exit Function
		End If

        '2019/09/20 DEL START
        'Call BNKMTA_RClear()
        '2019/09/20 DEL START
        'UPGRADE_WARNING: オブジェクト ENDBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(ENDBNKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(ENDBNKCD) = 0 Or Trim(ENDBNKCD) = "" Then
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, ENDBNKCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_BNKMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        ENDBNKCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    ENDBNKCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromBNKMTA(De_Index)
	End Function
	
	Function ENDBNKCD_Slist(ByRef PP As clsPP, ByVal ENDBNKCD As Object) As Object
		'
		DB_PARA(DBN_BNKMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト ENDBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_BNKMTA).KeyBuf = ENDBNKCD
		WLSBNK.ShowDialog()
		WLSBNK.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDBNKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDBNKCD_Slist = PP.SlistCom
	End Function
	Function ENDBNKCD_InitVal(ByVal ENDBNKCD As Object) As Object
		''''ENDBNKCD_InitVal = " "
		'UPGRADE_WARNING: オブジェクト ENDBNKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDBNKCD_InitVal = "ZZZZZZZ"
	End Function
End Module