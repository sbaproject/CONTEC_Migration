Option Strict Off
Option Explicit On
Module TANCD_F55
	'
	' スロット名        : 開始・担当者コード・画面項目スロット
	' ユニット名        : TANCD.F55
	' 記述者            : DVP_NT40
	' 作成日付          : 2007/01/11
	' 使用プログラム名  : URIPR52
	'
	
	Function STTTANCD_InitVal() As Object
		''    '
		''    STTTANCD_InitVal = FillVal("0", LenWid(DB_TANMTA.TANCD))
	End Function
	
	Function TANCD_CheckC(ByVal TANCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト TANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TANCD_CheckC = 0
        'UPGRADE_WARNING: オブジェクト TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(TANCD) = "" Then
            'delete start 20190808 kuwahara
            'Call TANMTA_RClear()
            'delete end 20190808 kuwahara
            '2019.04.18 add start
            DB_TANMTA = Nothing
            '2019.04.18 add end
            Call DP_SSSMAIN_TANNM(-1, DB_TANMTA.TANNM)
            Exit Function
        End If
        'delete start 20190808 kuwahara
        'Call TANMTA_RClear()
        'delete end 20190808 kuwahara
        'UPGRADE_WARNING: オブジェクト TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190809 kuwahara
        'Call DB_GetEq(DBN_TANMTA, 1, TANCD & Space(6 - Len(TANCD)), BtrNormal)
        GetRowsCommon("TANMTA", "where TANCD = '" & TANCD & "'")
        'change end 20190809 kuwahara
        If DBSTAT <> 0 Then
            'delete start 20190808 kuwahara
            'Call TANMTA_RClear()
            'delete end 20190808 kuwahara
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' レコードがありません。
            'UPGRADE_WARNING: オブジェクト TANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            TANCD_CheckC = -1
            Exit Function
        Else
            If DB_TANMTA.DATKB = "9" Then
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' 削除済レコードです。
				'UPGRADE_WARNING: オブジェクト TANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TANCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_TANNM(-1, DB_TANMTA.TANNM)
		
	End Function
	
	Function TANCD_Slist(ByRef PP As clsPP, ByVal TANCD As Object) As Object
        '
        'UPGRADE_WARNING: オブジェクト TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'delete start 20190809 kuwahara
        'DB_PARA(DBN_TANMTA).KeyBuf = TANCD
        'delete end 20190809 kuwahara
        WLSTAN1.ShowDialog()
		WLSTAN1.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TANCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190809 kuwahara
        'TANCD_Slist = PP.SlistCom
        TANCD_Slist = WLSTAN_RTNCODE
        'change end 20190809 kuwahara
    End Function
End Module