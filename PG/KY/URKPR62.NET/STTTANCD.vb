Option Strict Off
Option Explicit On
Module STTTANCD_F81
	'
	' スロット名        : 開始・担当者コード・画面項目スロット
	' ユニット名        : STTTANCD.F81
	' 記述者            : DVP_NT40
	' 作成日付          : 2007/01/11
	' 使用プログラム名  : URKPR52 / URKPR62 / UODPR55
	'
	
	Function STTTANCD_InitVal() As Object
		''    '
		''    STTTANCD_InitVal = FillVal("0", LenWid(DB_TANMTA.TANCD))
	End Function
	
	Function STTTANCD_CheckC(ByVal STTTANCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTANCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト STTTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTTANCD) = "" Then
            'Call TANMTA_RClear()
            Call DP_SSSMAIN_STTTANNM(-1, DB_TANMTA.TANNM)
			Exit Function
		End If
        '
        'Call TANMTA_RClear()
        'UPGRADE_WARNING: オブジェクト STTTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Call DB_GetEq(DBN_TANMTA, 1, STTTANCD & Space(6 - Len(STTTANCD)), BtrNormal)
		If DBSTAT <> 0 Then
            'Call TANMTA_RClear()
            rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' レコードがありません。
			'UPGRADE_WARNING: オブジェクト STTTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTTANCD_CheckC = -1
			Exit Function
		Else
			If DB_TANMTA.DATKB = "9" Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' 削除済レコードです。
				'UPGRADE_WARNING: オブジェクト STTTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STTTANCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_STTTANNM(-1, DB_TANMTA.TANNM)
		
	End Function
	
	Function STTTANCD_Slist(ByRef PP As clsPP, ByVal STTTANCD As Object) As Object
		'
		'    If IsNull(STTTANCD) Then
		'        DB_PARA(DBN_TANMTA).KeyBuf = ""
		'     Else
		'        DB_PARA(DBN_TANMTA).KeyBuf = STTTANCD
		'    End If
		'UPGRADE_WARNING: オブジェクト STTTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TANMTA).KeyBuf = STTTANCD
		''''WLSTAN.Show 1                               '2007.01.11
		''''Unload WLSTAN                               '2007.01.11
		WLSTAN1.ShowDialog()
		WLSTAN1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTTANCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTANCD_Slist = PP.SlistCom
	End Function
End Module