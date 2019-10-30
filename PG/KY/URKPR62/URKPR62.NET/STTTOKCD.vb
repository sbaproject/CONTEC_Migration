Option Strict Off
Option Explicit On
Module STTTOKCD_F81
	'
	' スロット名        : 開始得意先コード・画面項目スロット
	' ユニット名        : STTTOKCD.F81
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/31
	' 使用プログラム名  : URKPR52
	'
	
	Function STTTOKCD_InitVal() As Object
		''    '
		''    STTTOKCD_InitVal = FillVal("0", LenWid(DB_TOKMTA.TOKCD))
	End Function
	
	Function STTTOKCD_CheckC(ByVal STTTOKCD As Object) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: オブジェクト STTTOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTTOKCD) = "" Then
			Call TOKMTA_RClear()
			Call DP_SSSMAIN_STTTOKRN(-1, DB_TOKMTA.TOKRN)
			Exit Function
		End If
		'
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD & Space(10 - Len(STTTOKCD)), BtrNormal)
		If DBSTAT <> 0 Then
			Call TOKMTA_RClear()
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' レコードがありません。
			'UPGRADE_WARNING: オブジェクト STTTOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTTOKCD_CheckC = -1
			Exit Function
		Else
			If DB_TOKMTA.DATKB = "9" Then
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 4) ' 削除済レコードです。
				'UPGRADE_WARNING: オブジェクト STTTOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STTTOKCD_CheckC = -1
				Exit Function
			End If
		End If
		Call DP_SSSMAIN_STTTOKRN(-1, DB_TOKMTA.TOKRN)
	End Function
	
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		'
		'    If IsNull(STTTOKCD) Then
		'        DB_PARA(DBN_TOKMTA).KeyBuf = ""
		'     Else
		'        DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		'    End If
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		WLSTOK4.ShowDialog()
		WLSTOK4.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTTOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_Slist = PP.SlistCom
	End Function
End Module