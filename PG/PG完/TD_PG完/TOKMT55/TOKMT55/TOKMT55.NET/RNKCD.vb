Option Strict Off
Option Explicit On
Module RNKCD_F51
	'
	' スロット名        : ランク・画面項目スロット
	' ユニット名        : RNKCD.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/14
	' 使用プログラム名  : HINMT51
	'
	
	Function RNKCD_CheckC(ByVal RNKCD As Object, ByVal SKHINGRP As Object, ByVal URISETDT As Object, ByVal De_INDEX As Object) As Object
		Dim rtn As Short
        Dim wkRNKCD As String
        Dim i As Short
        '
        'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(SKHINGRP) = "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト RNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		RNKCD_CheckC = 0
        'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(RNKCD) = "" Then
            'UPGRADE_WARNING: オブジェクト RNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RNKCD_CheckC = -1
        Else
            '20190718 DELL START
            'Call MEIMTA_RClear()
            '20190718 DELL END
            'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkRNKCD = RNKCD & Space(Len(DB_MEIMTA.MEICDA) - Len(RNKCD))
            '20190718 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "059" & wkRNKCD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '059' AND MEICDA = '" & wkRNKCD & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)
            '20190718 CHG END
            If DBSTAT = 0 Then
                If DB_MEIMTA.DATKB = "9" Then
                    Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
                    'UPGRADE_WARNING: オブジェクト RNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    RNKCD_CheckC = -1
                End If
            Else
                rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
                'UPGRADE_WARNING: オブジェクト RNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RNKCD_CheckC = -1
            End If
            'UPGRADE_WARNING: オブジェクト RNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If RNKCD_CheckC = 0 Then
                'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190718 CHG START
                'Call DB_GetEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
                Dim strSQL1 As String = ""
                strSQL1 = strSQL1 & "  Where SKHINGRP  = '" & SKHINGRP & "' AND RNKCD = '" & RNKCD & "'  AND URISETDT ='" & VB6.Format(URISETDT, "YYYYMMDD") & "'"

                Call GetRowsCommon("RNKMTA", strSQL1)
                '20190718 CHG END
                If DBSTAT = 0 Then
                    'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call SCR_FromMfil(De_INDEX)
                    '20190718 CHG START
                    'If DB_RNKMTA.DATKB = "9" Then
                    If DB_RNKMTA2.DATKB = "9" Then
                        '20190718 CHG END
                        'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call DP_SSSMAIN_UPDKB(De_INDEX, "削除")
                    Else
                        'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call DP_SSSMAIN_UPDKB(De_INDEX, "更新")
                    End If
                Else
                    'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(De_INDEX, "追加")
                End If
            End If
        End If
        '20190723 add start
        'For i = 0 To PP_SSSMAIN.MaxDspC
        '    '        Call SCR_FromMfil(I)
        '    Call DP_SSSMAIN_RNKCD(i, " ")
        '    Call DP_SSSMAIN_SIKRT(i, " ")
        '    Call DP_SSSMAIN_URISETDT(i, " ")
        '    'Call DP_SSSMAIN_UPDKB(i, " ")
        'Next i
        '20190723 add end
    End Function
	
	Function RNKCD_Slist(ByRef PP As clsPP, ByVal RNKCD As Object) As Object
		'
		WLS_MEI1.Text = "ランク一覧"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        '20190718 CHG START
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "059", BtrNormal)
        'Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "059"
        '	If DB_MEIMTA.DATKB <> "9" Then
        '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        '	End If
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '059' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
            If dt.Rows(i)("DATKB") <> "9" Then
                CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(dt.Rows(i)("MEICDA"), 5) & " " & LeftWid(dt.Rows(i)("MEINMA"), 40))
                SSS_WLSLIST_KETA = LenWid(dt.Rows(i)("MEICDA"))
            End If
        Next
        '20190718 CHG END
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'SSS_WLSLIST_KETA = 5
        WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RNKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		RNKCD_Slist = PP.SlistCom
	End Function
End Module