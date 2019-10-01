Option Strict Off
Option Explicit On
Module STTTOKCD_F61
	'
	' スロット名        : 得意先コード・画面項目スロット
	' ユニット名        : STTTOKCD.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/27
	' 使用プログラム名  : UODPR51
	'
	
	Function STTTOKCD_CheckC(ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object '1996/08/12 UPDATE
		Dim Rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(STTTOKCD) = "" Then
            Call DP_SSSMAIN_STTTOKRN(0, "")
        Else
            '2019.03.29 CHG START
            'Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
            'Call TOKMTA_GetFirst(Trim(STTTOKCD))
            'change start 20190807 kuwahara
            GetRowsCommon("TOKMTA", "Where TOKCD = '" & STTTOKCD & "'")
            'change end 20190807 kuwahara
            '2019.03.29 CHG END

            If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Rtn = DSP_MsgBox(SSS_ERROR, "DONTSELECT", 1)
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call SCR_FromTOKMTA(De_Index)
					'UPGRADE_WARNING: オブジェクト STTTOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					STTTOKCD_CheckC = 0
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当するデータはありません。
				Call DP_SSSMAIN_STTTOKRN(0, "")
				'UPGRADE_WARNING: オブジェクト STTTOKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				STTTOKCD_CheckC = -1 'ADD GWE)Saito 2006/10/31
			End If
		End If
		'
	End Function
	
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTTOKCD) = "" Then
		Else
			'UPGRADE_WARNING: オブジェクト STTTOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
        End If
        '2019.03.26 CHG START
        'WLSTOK.ShowDialog()
        'WLSTOK.Close()
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        '2019.03.26 CHG END
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTTOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTTOKCD_Slist = PP.SlistCom
	End Function
End Module