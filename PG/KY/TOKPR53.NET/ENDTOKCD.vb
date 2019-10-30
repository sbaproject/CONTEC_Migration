Option Strict Off
Option Explicit On
Module ENDTOKCD_F51
	'
	'スロット名      :得意先コード・画面項目スロット
	'ユニット名      :TOKCD.F56
	'記述者          :Standard Library
	'作成日付        :2006/08/11
	'使用プログラム  :nykpr52
	'
	'
	
	Function ENDTOKCD_Check(ByVal ENDTOKCD As Object, ByVal STTTOKCD As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDTOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKCD_Check = 0
		
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If ENDTOKCD < STTTOKCD Then
			rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
			'UPGRADE_WARNING: オブジェクト ENDTOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDTOKCD_Check = -1
			Exit Function
		End If

        'Call TOKMTA_RClear()
        'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(ENDTOKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(ENDTOKCD) = 0 Or Trim(ENDTOKCD) = "" Then
		Else
			Call DB_GetLsEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
                    'Call TOKMTA_RClear()
                End If
			Else
                'Call TOKMTA_RClear()
            End If
		End If
		'Call SCR_FromTOKMTA(De_Index)
	End Function
	
	Function ENDTOKCD_Slist(ByRef PP As clsPP, ByVal ENDTOKCD As Object) As Object
		'
		DB_PARA(DBN_TOKMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト ENDTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = ENDTOKCD
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト ENDTOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ENDTOKCD_Slist = PP.SlistCom
	End Function
	Function ENDTOKCD_InitVal(ByVal ENDTOKCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト ENDTOKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDTOKCD_InitVal = "ﾝﾝﾝﾝﾝ"
		
	End Function
End Module