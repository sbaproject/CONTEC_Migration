Option Strict Off
Option Explicit On
Module STTBNKCD_F52
    '
    'スロット名      :倉庫コード・画面項目スロット
    'ユニット名      :SOUCD.F55
    '記述者          :Standard Library
    '作成日付        :2006/08/11
    '使用プログラム  :nykpr52
    '
    '
    '2019/10/03 CHG START
    'Function STTBNKCD_Check(ByVal STTBNKCD As Object) As Object
    Function STTBNKCD_Check(ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
        '2019/10/03 CHG END

        Dim rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト STTBNKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTBNKCD_Check = 0
        '2019/09/20 DEL START
        'Call BNKMTA_RClear()
        '2019/09/20 DEL START
        'UPGRADE_WARNING: オブジェクト STTBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(STTBNKCD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(STTBNKCD) = 0 Or Trim(STTBNKCD) = "" Then
        Else
            '2019/10/03 CHG START
            'Call DB_GetEq(DBN_BNKMTA, 1, STTBNKCD, BtrNormal)
            GetRowsCommon(DBN_BNKMTA, "Where BNKCD = '" & STTBNKCD & "'")

            If DBSTAT = 0 Then
                Call SCR_FromMfilENDBNKCD(De_Index)
            End If
            '2019/10/03 CHG END
            ''''''''If DBSTAT = 0 Then
            ''''''''    If DB_BNKMTA.DATKB = "9" Then
            ''''''''        Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
            ''''''''        STTBNKCD_Check = 1
            ''''''''    End If
            ''''''''Else
            ''''''''    rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
            ''''''''    STTBNKCD_Check = -1
            ''''''''End If
        End If
        'Call SCR_FromBNKMTA(De_Index)
    End Function

    Function STTBNKCD_Slist(ByRef PP As clsPP, ByVal STTBNKCD As Object) As Object
        '

        '2019/09/27 DEL START
        'DB_PARA(DBN_BNKMTA).KeyNo = 1
        ''UPGRADE_WARNING: オブジェクト STTBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_BNKMTA).KeyBuf = STTBNKCD
        '2019/09/27 DEL END
        WLSBNK.ShowDialog()
        WLSBNK.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト STTBNKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTBNKCD_Slist = PP.SlistCom
    End Function
    Function STTBNKCD_InitVal(ByVal STTBNKCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト STTBNKCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTBNKCD_InitVal = " "
		
	End Function
End Module