Option Strict Off
Option Explicit On
Module SOUCD_F51
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :SOUCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/06/14
	'使用プログラム  :SOUMT51
	'
	
	Function SOUCD_CheckC(ByRef PP As clsPP, ByRef CP_SOUCD As clsCP, ByRef SOUCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim wkSOUBSCD As String
		Dim wkSOUKOKB As String
		'
		'UPGRADE_WARNING: オブジェクト SOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUCD_CheckC = 0
        'Call SOUMTA_RClear()
        'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(SOUCD) = "" Then
            'Call SOUMTA_RClear()
            'Call DP_SSSMAIN_UPDKB(De_Index, "")
            'Call DP_SSSMAIN_SOUBSNM(De_Index, "")
            'Call SCR_FromMfil(De_Index)
            'UPGRADE_WARNING: オブジェクト SOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            SOUCD_CheckC = -1
		Else
            '20190820 CHG START
            'Call DB_GetEq(DBN_SOUMTA, 1, SOUCD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & " SELECT * FROM SOUMTA  Where  SOUCD = '" & SOUCD & "'"

            Dim dt As DataTable = DB_GetTable(strSQL)
            If dt.Rows.Count > 0 Then
                ' Dim pot_DB_SOUMTA2 As TYPE_DB_SOUMTA2

                With DB_SOUMTA2
                    .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "")
                    .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "")
                    .SOUNM = DB_NullReplace(dt.Rows(0)("SOUNM"), "")
                    .SOUZP = DB_NullReplace(dt.Rows(0)("SOUZP"), "")
                    .SOUADA = DB_NullReplace(dt.Rows(0)("SOUADA"), "")

                    .SOUADB = DB_NullReplace(dt.Rows(0)("SOUADB"), "")
                    .SOUADC = DB_NullReplace(dt.Rows(0)("SOUADC"), "")
                    .SOUTL = DB_NullReplace(dt.Rows(0)("SOUTL"), "")
                    .SOUFX = DB_NullReplace(dt.Rows(0)("SOUFX"), "")
                    .SOUBSCD = DB_NullReplace(dt.Rows(0)("SOUBSCD"), "")

                    .SOUKB = DB_NullReplace(dt.Rows(0)("SOUKB"), "")
                    .SRSCNKB = DB_NullReplace(dt.Rows(0)("SRSCNKB"), "")
                    .SISNKB = DB_NullReplace(dt.Rows(0)("SISNKB"), "")
                    .SOUTRICD = DB_NullReplace(dt.Rows(0)("SOUTRICD"), "")
                    .SOUKOKB = DB_NullReplace(dt.Rows(0)("SOUKOKB"), "")
                    .HIKKB = DB_NullReplace(dt.Rows(0)("HIKKB"), "")

                    .SALPALKB = DB_NullReplace(dt.Rows(0)("SALPALKB"), "")
                    .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "")
                    .FOPEID = DB_NullReplace(dt.Rows(0)("FOPEID"), "")
                    .FCLTID = DB_NullReplace(dt.Rows(0)("FCLTID"), "")
                    .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "")
                    .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "")

                    .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                    .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                    .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                    .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                    .UOPEID = DB_NullReplace(dt.Rows(0)("UOPEID"), "")
                    .UCLTID = DB_NullReplace(dt.Rows(0)("UCLTID"), "")
                    .UWRTTM = DB_NullReplace(dt.Rows(0)("UWRTTM"), "")
                    .UWRTDT = DB_NullReplace(dt.Rows(0)("UWRTDT"), "")
                    .PGID = DB_NullReplace(dt.Rows(0)("PGID"), "")
                End With

            End If

            '20190820 CHG END
            If DBSTAT = 0 Then
                '20190819 CHG START
                ''UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call SCR_FromMfil(De_Index)

                'If DB_SOUMTA.DATKB = "9" Then
                '    'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    Call DP_SSSMAIN_UPDKB(De_Index, "削除")
                'Else
                '    'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    Call DP_SSSMAIN_UPDKB(De_Index, "更新")
                'End If
                ''''''                Call DB_GetGrEq(DBN_MEIMTA, 1, "002", BtrNormal)
                ''''''                Call SOUBSCD_Move(De_Index)
                'wkSOUBSCD = DB_SOUMTA.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUBSCD))
                'Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
                ''UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call DP_SSSMAIN_SOUBSNM(De_Index, Trim(DB_MEIMTA.MEINMA))
                ''20910819 DELL START
                ''Call MEIMTA_RClear()
                ''20190819 DELL END
                'wkSOUKOKB = DB_SOUMTA.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUKOKB))
                'Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
                ''UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call DP_SSSMAIN_SOUKONM(De_Index, Trim(DB_MEIMTA.MEINMA))
                ''20190819 DELL START
                ''Call TOKMTA_RClear()
                ''20190819 DELL END
                'Call DB_GetEq(DBN_TOKMTA, 1, DB_SOUMTA.SOUTRICD, BtrNormal)
                ''UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call SCR_FromTOKMTA(De_Index)
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromMfil(De_Index)

                If DB_SOUMTA2.DATKB = "9" Then
                    'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(De_Index, "削除")
                Else
                    'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(De_Index, "更新")
                End If
                '''''                Call DB_GetGrEq(DBN_MEIMTA, 1, "002", BtrNormal)
                '''''                Call SOUBSCD_Move(De_Index)
                '''
                If Len(DB_MEIMTA.MEICDA) > Len(DB_SOUMTA2.SOUBSCD) Then
                    wkSOUBSCD = DB_SOUMTA2.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA2.SOUBSCD))
                Else
                    wkSOUBSCD = DB_SOUMTA2.SOUBSCD

                End If
                '20190820 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
                Dim strSQL1 As String = ""
                strSQL1 = strSQL1 & "  Where KEYCD  = '015' AND MEICDA = '" & wkSOUBSCD & "'"
                strSQL1 = strSQL1 & "  Order By MEICDA "

                Call GetRowsCommon("MEIMTA", strSQL1)
                '20190820 CHG END
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call DP_SSSMAIN_SOUBSNM(De_Index, Trim(DB_MEIMTA.MEINMA))
                '20910819 DELL START
                'Call MEIMTA_RClear()
                '20190819 DELL END
                wkSOUKOKB = DB_SOUMTA2.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA2.SOUKOKB))
                '20190820 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
                Dim strSQL2 As String = ""
                strSQL2 = strSQL2 & "  Where KEYCD  = '059' AND MEICDA = '" & wkSOUKOKB & "'"
                strSQL2 = strSQL2 & "  Order By MEICDA "

                Call GetRowsCommon("MEIMTA", strSQL2)
                '20190820 CHG END
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call DP_SSSMAIN_SOUKONM(De_Index, Trim(DB_MEIMTA.MEINMA))
                '20190819 DELL START
                'Call TOKMTA_RClear()
                '20190819 DELL END
                '20190820 CHG START
                'Call DB_GetEq(DBN_TOKMTA, 1, DB_SOUMTA2.SOUTRICD, BtrNormal)
                Dim strSQL3 As String = ""
                strSQL3 = strSQL3 & " SELECT * FROM TOKMTA  Where TOKCD = '" & DB_SOUMTA2.SOUTRICD & "'"
                Dim dt2 As DataTable = DB_GetTable(strSQL3)
                If dt2.Rows.Count > 0 Then
                    DB_TOKMTA.TOKCD = DB_NullReplace(dt2.Rows(0)("TOKCD"), "")
                    DB_TOKMTA.TOKRN = DB_NullReplace(dt2.Rows(0)("TOKRN"), "")
                End If

                '20190820 CHG END
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromTOKMTA(De_Index)
                '20190819 CHG END
            Else
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call DP_SSSMAIN_UPDKB(De_Index, "追加")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SOUBSNM(De_Index, "")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SOUKONM(De_Index, "")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SOUBSNM(De_Index, "")
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_SOUTRINM(De_Index, "")
                'Call SOUMTA_RClear()

            End If
		End If
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call SCR_FromMfil(De_Index)
	End Function
	
	Function SOUCD_Slist(ByRef PP As clsPP, ByVal SOUCD As Object) As Object
        '20190819 DELL START
        'DB_PARA(DBN_SOUMTA).KeyNo = 1
        ''UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_SOUMTA).KeyBuf = SOUCD
        '20190819 DELL END
        '20190819 CHG START
        '      WLSSOU.ShowDialog()
        'WLSSOU.Close()
        WLSSOU1.ShowDialog()
        WLSSOU1.Close()
        '20190819 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SOUCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SOUCD_Slist = PP.SlistCom
	End Function
End Module