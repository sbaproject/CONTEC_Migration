Option Strict Off
Option Explicit On
Module RATMT51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : RATMT51.E01
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/02
	' 使用プログラム名  : RATMT51
	'
	Public WG_UNYDT As String '運用日
	
	Function DSPMST() As Short
		Dim I As Short
		Dim wkTUKKB As String
		Dim strSQL As String
        '
        I = 0
        '20190807 dell start
        'Call TUKMTA_RClear()
        ' Dim m = New TYPE_DB_TUKMTA
        '20190807 dell end

        SSS_FASTKEY.Value = SSS_LASTKEY.Value


        'Call DB_GetGrEq(DBN_TUKMTA, 1, SSS_LASTKEY, BtrNormal)
        strSQL = ""
        strSQL = strSQL & "SELECT *"
        strSQL = strSQL & "  FROM   ("
        strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
        strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
        strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
        strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
        strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
        strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
        strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
        strSQL = strSQL & "                  , TUK.PGID "
        strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
        strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
        strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
        strSQL = strSQL & "             ) TBL"
        strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
        strSQL = strSQL & " ORDER BY TBL.WRTFSTTM,TBL.WRTFSTDT"

        'Call DB_GetSQL2(DBN_TUKMTA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)

        '20081002 CHG START RISE)Tanimura '排他処理
        ''2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
        '    ReDim M_MOTO_A_inf(14)
        ''2007/12/18 add-end T.KAWAMUKAI

        ReDim M_RATMT_A_inf(14)
		
		Call RATMT51_MF_All_Clear_UWRTDTTM()
        '20081002 CHG END   RISE)Tanimura
        '20190808 chg start
        'If DBSTAT = 0 Then
        '    Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))

        '        Call SCR_FromMfil(I)
        '        Call DP_SSSMAIN_V_DATKB(I, DB_TUKMTA.DATKB) '2006.11.07
        '        Call DP_SSSMAIN_V_RATERT(I, DB_TUKMTA.RATERT) '2006.11.07
        '        '20190806 DELL START
        '        'Call MEIMTA_RClear()
        '        Dim a = New TYPE_DB_MEIMTA
        '        '20190806 DELL END
        '        'wkTUKKB = DB_TUKMTA.TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_TUKMTA.TUKKB))
        '        If Len(DB_MEIMTA.MEICDA) >= Len(DB_TUKMTA.TUKKB) Then
        '            wkTUKKB = DB_TUKMTA.TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_TUKMTA.TUKKB))
        '        Else
        '            wkTUKKB = DB_TUKMTA.TUKKB
        '        End If
        '        Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkTUKKB, BtrNormal)
        '        If DBSTAT = 0 Then '名称ﾏｽﾀに当該項目が在る時
        '            Call SCR_FromMEIMTA(I)
        '        End If

        '        If DB_TUKMTA.DATKB = "9" Then
        '            Call DP_SSSMAIN_UPDKB(I, "削除")
        '        Else
        '            Call DP_SSSMAIN_UPDKB(I, "更新")
        '        End If

        '        I = I + 1
        '        Call DB_GetNext(DBN_TUKMTA, BtrNormal)
        '    Loop
        'End If


        Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
            If I < dt.Rows.Count Then
                DB_TUKMTA.OPEID = dt.Rows(I)("OPEID") ' 最終作業者コード
                DB_TUKMTA.CLTID = dt.Rows(I)("CLTID") ' クライアントＩＤ
                DB_TUKMTA.WRTTM = dt.Rows(I)("WRTTM") ' タイムスタンプ（時間）
                DB_TUKMTA.WRTDT = dt.Rows(I)("WRTDT") ' タイムスタンプ（日付）
                DB_TUKMTA.UCLTID = dt.Rows(I)("UCLTID") ' クライアントID（バッチ）
                DB_TUKMTA.UWRTDT = dt.Rows(I)("UWRTDT") '
                DB_TUKMTA.UOPEID = dt.Rows(I)("UOPEID") ' ユーザID（バッチ）
                DB_TUKMTA.UWRTTM = dt.Rows(I)("UWRTTM") ' タイムスタンプ（バッチ時間）
                DB_TUKMTA.RATERT = dt.Rows(I)("RATERT")
                DB_TUKMTA.TEKIDT = dt.Rows(I)("TEKIDT")
                DB_TUKMTA.TUKKB = dt.Rows(I)("TUKKB")
                DB_TUKMTA.TUKNM = dt.Rows(I)("TUKNM")
                DB_TUKMTA.DATKB = dt.Rows(I)("DATKB")
                Call SCR_FromMfil(I)
                Call DP_SSSMAIN_V_DATKB(I, DB_TUKMTA.DATKB) '2006.11.07
                Call DP_SSSMAIN_V_RATERT(I, DB_TUKMTA.RATERT) '2006.11.07

                'wkTUKKB = DB_TUKMTA.TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_TUKMTA.TUKKB))
                If Len(DB_MEIMTA.MEICDA) >= Len(DB_TUKMTA.TUKKB) Then
                    wkTUKKB = DB_TUKMTA.TUKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_TUKMTA.TUKKB))
                Else
                    wkTUKKB = DB_TUKMTA.TUKKB
                End If
                Dim strSQL1 As String = ""
                strSQL1 = strSQL1 & "  Where KEYCD  = '001' AND MEICDA = '" & wkTUKKB & "'"
                strSQL1 = strSQL1 & "  Order By MEICDA "

                Call GetRowsCommon("MEIMTA", strSQL1)
                If DBSTAT = 0 Then '名称ﾏｽﾀに当該項目が在る時
                    Call SCR_FromMEIMTA(I)
                End If

                If DB_TUKMTA.DATKB = "9" Then
                    Call DP_SSSMAIN_UPDKB(I, "削除")
                Else
                    Call DP_SSSMAIN_UPDKB(I, "更新")
                End If
                I = I + 1
                If DBSTAT = 0 Then
                    SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
                Else
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    SSS_LASTKEY.Value = HighValue(LenWid(DB_TUKMTA.WRTFSTTM)) & HighValue(LenWid(DB_TUKMTA.WRTFSTDT))
                End If
            Else
                Exit Do
            End If
        Loop

        DSPMST = I

    End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(2 + (lngI * 5)) = 1              '2006.11.07
			''''    CL_SSSMAIN(4 + (lngI * 5)) = 1              '2006.11.07
			CL_SSSMAIN(2 + (lngI * 7)) = 1
			CL_SSSMAIN(4 + (lngI * 7)) = 1
		Next

        '運用日取得
        '20190808 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190808 CHG END
        If DBSTAT = 0 Then
			WG_UNYDT = DB_UNYMTA.UNYDT
		Else
			WG_UNYDT = ""
		End If
		
		'実行権限チェック
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		gs_userid = Left(SSS_OPEID.Value, 6) 'ユーザID
		gs_pgid = SSS_PrgId 'プログラムID
		
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("実行権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
	End Sub

    Function MST_NEXT() As Short
        Dim Rtn As Short
        Dim strSQL As String
        '20190814 ADD START
        Dim I As Short
        I = SET_GAMEN_KEY()
        I = 0
        SSS_LASTKEY.Value = SSS_FASTKEY.Value
        '20190814 ADD END
        ''''Call DB_GetGrEq(DBN_TUKMTA, 1, SSS_LASTKEY, BtrNormal)
        strSQL = ""
        strSQL = strSQL & "SELECT *"
        strSQL = strSQL & "  FROM   ("
        strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
        strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
        strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
        strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
        strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
        strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
        strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
        strSQL = strSQL & "                  , TUK.PGID "
        strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
        strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
        strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
        strSQL = strSQL & "             ) TBL"
        strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
        strSQL = strSQL & " ORDER BY TBL.WRTFSTTM,TBL.WRTFSTDT"

        '20190809 CHG START
        ' Call DB_GetSQL2(DBN_TUKMTA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)

        '2019089 CHG END
        'If DBSTAT = 0 Then
        '    MST_NEXT = DSPMST()
        'Else
        '    SSS_LASTKEY.Value = SSS_FASTKEY.Value
        '    MST_NEXT = DSPMST()
        'End If
        Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
            If I < dt.Rows.Count - 1 Then
                I = I + 1
                DB_TUKMTA.WRTFSTTM = dt.Rows(I)("WRTFSTTM")
                DB_TUKMTA.WRTFSTDT = dt.Rows(I)("WRTFSTDT")
                DB_TUKMTA.WRTFSTTM = dt.Rows(I)("WRTFSTTM")
                DB_TUKMTA.WRTFSTDT = dt.Rows(I)("WRTFSTDT")
                ' DB_PARA(DBN_TUKMTA).nDirection = 2
                ' Call DB_GetPre(DBN_TUKMTA, BtrNormal)
                If DBSTAT <> 0 And I = 0 Then
                    SSS_LASTKEY.Value = Space(Len(DB_TUKMTA.WRTFSTTM)) & VB6.Format(DB_TUKMTA.WRTFSTDT, "0")
                    ''''''''Call DB_GetFirst(DBN_TUKMTA, 2, BtrNormal)
                Else
                    SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
                End If

            Else
                SSS_LASTKEY.Value = SSS_FASTKEY.Value
                Exit Do
            End If
        Loop
        I = DSPMST()
        MST_NEXT = I
        '20190809 CHG END
    End Function

    Function MST_PREV() As Short
		Dim I As Short
		Dim strSQL As String
		'
		I = SET_GAMEN_KEY()
		I = 0
		''''Call DB_GetLs(DBN_TUKMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT TUK.DATKB, TUK.TUKKB, TUK.TUKNM, TUK.TEKIDT"
		strSQL = strSQL & "                  , TUK.RATERT, TUK.RELFL"
		strSQL = strSQL & "                  , TUK.FOPEID,TUK.FCLTID"
		strSQL = strSQL & "                  , MEI.DSPORD || TUK.TUKKB  as WRTFSTTM"
		strSQL = strSQL & "                  ,(99999999 - TO_NUMBER(TUK.TEKIDT)) as WRTFSTDT"
		strSQL = strSQL & "                  , TUK.OPEID,TUK.CLTID, TUK.WRTTM,TUK.WRTDT"
		strSQL = strSQL & "                  , TUK.UOPEID,TUK.UCLTID, TUK.UWRTTM,TUK.UWRTDT"
		strSQL = strSQL & "                  , TUK.PGID "
		strSQL = strSQL & "             FROM TUKMTA TUK LEFT JOIN MEIMTA MEI ON MEI.KEYCD = '001' "
		strSQL = strSQL & "                                                 AND MEI.MEICDA = TUK.TUKKB "
		strSQL = strSQL & "                                                 AND MEI.MEICDB = ' '"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE    TBL.WRTFSTTM || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.WRTFSTTM desc,TBL.WRTFSTDT desc"
        '20190809 CHG START
        ' Call DB_GetSQL2(DBN_TUKMTA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190809 CHG END
        '20190809 DELL START
        '      Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
        '	I = I + 1
        '	DB_PARA(DBN_TUKMTA).nDirection = 2
        '	Call DB_GetPre(DBN_TUKMTA, BtrNormal)
        'Loop 
        '20190809 DELL END
        '20190809 CHG START
        'If DBSTAT <> 0 And I = 0 Then
        '    SSS_LASTKEY.Value = Space(Len(DB_TUKMTA.WRTFSTTM)) & VB6.Format(DB_TUKMTA.WRTFSTDT, "0")
        '    ''''''''Call DB_GetFirst(DBN_TUKMTA, 2, BtrNormal)
        'Else
        '    SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
        'End If
        Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
            If I < dt.Rows.Count - 1 Then
                I = I + 1
                DB_TUKMTA.WRTFSTTM = dt.Rows(I)("WRTFSTTM")
                DB_TUKMTA.WRTFSTDT = dt.Rows(I)("WRTFSTDT")
                DB_TUKMTA.WRTFSTTM = dt.Rows(I)("WRTFSTTM")
                DB_TUKMTA.WRTFSTDT = dt.Rows(I)("WRTFSTDT")

                ' DB_PARA(DBN_TUKMTA).nDirection = 2
                ' Call DB_GetPre(DBN_TUKMTA, BtrNormal)

                If DBSTAT <> 0 And I = 0 Then
                    SSS_LASTKEY.Value = Space(Len(DB_TUKMTA.WRTFSTTM)) & VB6.Format(DB_TUKMTA.WRTFSTDT, "0")
                    ''''''''Call DB_GetFirst(DBN_TUKMTA, 2, BtrNormal)
                Else
                    SSS_LASTKEY.Value = DB_TUKMTA.WRTFSTTM & DB_TUKMTA.WRTFSTDT
                End If
            Else
                Exit Do
            End If

        Loop
        '20190809 CHG END

        I = DSPMST()
		MST_PREV = I
		
	End Function
	
	Function SET_GAMEN_KEY() As Short
		Dim wkDSPORD As String
		'
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(RD_SSSMAIN_TEKIDT(0)) = "" Then
			DB_TUKMTA.TEKIDT = "00000000"
		Else
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TUKMTA.TEKIDT = VB6.Format(99999999 - Val(RD_SSSMAIN_TEKIDT(0)), "00000000")
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(0)
		If Trim(DB_TUKMTA.TUKKB) = "" Then
			DB_MEIMTA.DSPORD = "   "
		Else
            wkDSPORD = Trim(DB_TUKMTA.TUKKB) & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(DB_TUKMTA.TUKKB)))
            '20190807 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "001" & wkDSPORD, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '001' AND MEICDA = '" & wkDSPORD & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)

            '20190807 CHG END
            If DBSTAT <> 0 Then
				DB_MEIMTA.DSPORD = "   "
			End If
		End If
		
		SSS_LASTKEY.Value = DB_MEIMTA.DSPORD & DB_TUKMTA.TUKKB & DB_TUKMTA.TEKIDT
		
		SET_GAMEN_KEY = 4
		
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			Rtn = DSP_MsgBox(CStr(0), "NO_ENTRY", 0) 'データを入力して下さい
			'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module