Option Strict Off
Option Explicit On
Module TUKKB_F51
	'
	'スロット名      :通貨区分・画面項目スロット
	'ユニット名      :TUKKB.F51
	'記述者          :Standard Library
	'作成日付        :2006/05/31
	'使用プログラム  :RATMT51
	'
	
	Function TUKKB_CheckC(ByRef PP As clsPP, ByRef CP_TUKKB As clsCP, ByRef TUKKB As Object, ByVal TEKIDT As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim wkTUKKB As String
		'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TUKKB_CheckC = 0
        'Call TUKMTA_RClear()
        DB_TUKMTA = New TYPE_DB_TUKMTA
        '
        'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(TUKKB) = "" Then
			'rtn = DSP_MsgBox(SSS_ERROR, "ITM", 0)
			'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TUKKB_CheckC = -1
		Else
            '''''       Call SCR_FromMfil(De_INDEX)
            ''''
            '20190806 DELL START
            'Call MEIMTA_RClear()
            DB_TUKMTA = New TYPE_DB_TUKMTA
            '20190806 DELL END
            'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wkTUKKB = TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(TUKKB))
            '20190807 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkTUKKB, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '001' AND MEICDA = '" & wkTUKKB & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)
            '20190807 CHG END
            If DBSTAT = 0 Then '名称ﾏｽﾀに当該項目が在る時
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					TUKKB_CheckC = -1
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TUKKB_CheckC = -1
			End If

            'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If TUKKB_CheckC = 0 Then
                '20190807 DELL START
                'Call TUKMTA_RClear()
                DB_TUKMTA = New TYPE_DB_TUKMTA
                '20190807 DELL END
                'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Trim(TUKKB) = "" Then
                    'UPGRADE_WARNING: オブジェクト TUKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    TUKKB_CheckC = -1
                Else
                    'UPGRADE_WARNING: オブジェクト TEKIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190807 CHG START
                    'Call DB_GetEq(DBN_TUKMTA, 1, TUKKB & VB6.Format(TEKIDT, "YYYYMMDD"), BtrNormal)
                    Dim strSQL1 As String = ""
                    strSQL1 = strSQL1 & "  Where TUKKB  = '" & TUKKB & "' AND TEKIDT ='" & VB6.Format(TEKIDT, "YYYYMMDD") & "'"

                    Call GetRowsCommon("TUKMTA", strSQL1)
                    '20190807 CHG END
                    If DBSTAT = 0 Then
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call SCR_FromMfil(De_Index)
                        If DB_TUKMTA.DATKB = "9" Then
                            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Call DP_SSSMAIN_UPDKB(De_Index, "削除")
                        Else
                            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Call DP_SSSMAIN_UPDKB(De_Index, "更新")
                        End If
                        '20081002 ADD START RISE)Tanimura '排他処理
                        ' [引数De_Indexは画面上の行数(0〜)]
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).OPEID = DB_TUKMTA.OPEID ' 最終作業者コード
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).CLTID = DB_TUKMTA.CLTID ' クライアントＩＤ
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).WRTTM = DB_TUKMTA.WRTTM ' タイムスタンプ（時間）
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).WRTDT = DB_TUKMTA.WRTDT ' タイムスタンプ（日付）
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).UOPEID = DB_TUKMTA.UOPEID ' ユーザID（バッチ）
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).UCLTID = DB_TUKMTA.UCLTID ' クライアントID（バッチ）
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).UWRTTM = DB_TUKMTA.UWRTTM ' タイムスタンプ（バッチ時間）
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        M_RATMT_A_inf(De_Index).UWRTDT = DB_TUKMTA.UWRTDT ' タイムスタンプ（バッチ日）
                        '20081002 ADD END   RISE)Tanimura
                    Else
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call DP_SSSMAIN_UPDKB(De_Index, "追加")
                        '20081002 ADD START RISE)Tanimura '排他処理
                        'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Call RATMT51_MF_Clear_UWRTDTTM(De_Index)
                        '20081002 ADD END   RISE)Tanimura
                        '20190807 dell start
                        'Call TUKMTA_RClear()
                        '20190807 dell end
                    End If
                End If
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromMfil(De_Index)
            End If
            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call SCR_FromMEIMTA(De_Index)
			
		End If
		
	End Function
	
	Function TUKKB_Slist(ByRef PP As clsPP, ByVal TUKKB As Object) As Object
		WLS_MEI1.Text = "通貨区分名称一覧"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        '20190807 CHG START
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "001", BtrNormal)
        'Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "001"
        '	If DB_MEIMTA.DATKB <> "9" Then
        '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        '	End If
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        ''UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.KEYCD)
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '001' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
                If dt.Rows(i)("DATKB") <> "9" Then
                    CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(dt.Rows(i)("MEICDA"), 5) & " " & LeftWid(dt.Rows(i)("MEINMA"), 40))
                    SSS_WLSLIST_KETA = LenWid(dt.Rows(i)("MEICDA"))
                End If
            Next
        End If

        WLS_MEI1.ShowDialog()
		WLS_MEI1.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TUKKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TUKKB_Slist = PP.SlistCom
		
	End Function
End Module