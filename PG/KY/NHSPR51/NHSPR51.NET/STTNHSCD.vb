Option Strict Off
Option Explicit On
Module STTNHSCD_F53
	'
	'スロット名      :納入先コード・画面項目スロット
	'ユニット名      :NYUCD.F55
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function STTNHSCD_Check(ByVal STTNHSCD As Object) As Object
		Dim rtn As Short
		Dim wkNHSCD As String
		'
		'UPGRADE_WARNING: オブジェクト STTNHSCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTNHSCD_Check = 0
		Call NHSMTA_RClear()
		'UPGRADE_WARNING: オブジェクト STTNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(STTNHSCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(STTNHSCD) = 0 Or Trim(STTNHSCD) = "" Then
		Else
			'UPGRADE_WARNING: オブジェクト STTNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkNHSCD = STTNHSCD & Space(Len(DB_NHSMTA.NHSCD) - Len(STTNHSCD))
			Call DB_GetEq(DBN_NHSMTA, 1, wkNHSCD, BtrNormal)
			''''''''If DBSTAT = 0 Then
			''''''''    If DB_NHSMTA.DATKB = "9" Then
			''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
			''''''''        STTNHSCD_Check = 1
			''''''''    End If
			''''''''Else
			''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			''''''''    STTNHSCD_Check = -1
			''''''''End If
		End If
		'Call SCR_FromNHSMTA(De_Index)
	End Function
	
	Function STTNHSCD_Slist(ByRef PP As clsPP, ByVal STTNHSCD As Object) As Object
		'
		DB_PARA(DBN_NHSMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト STTNHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_NHSMTA).KeyBuf = STTNHSCD
		WLSNHS.ShowDialog()
		WLSNHS.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTNHSCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTNHSCD_Slist = PP.SlistCom
	End Function
	Function STTNHSCD_InitVal(ByVal STTNHSCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト STTNHSCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTNHSCD_InitVal = " "
		
	End Function
End Module