Option Strict Off
Option Explicit On
Module URIET51_E81
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : URIET51.E81
	' 記述者            : Muratani
	' 作成日付          : 2006/08/28
	' 使用プログラム名  : URIET51
	'
	Public Const WG_DKBSB As String = "040"
	
	Public WG_DSPKB As Short '1:売上伝票 2:受注伝票
	Public WG_BILFL As Short
	Public WG_JDNINKB As String '1:入力2:通販3:VAN4:WEB
	Public WG_SYSTEM As String 'M:MEIKBA(受注取引区分用）システム
	Public WG_JDNDATNO As String '受注最新情報のDATNO
	'2007/12/05 FKS)minamoto ADD START
	Structure TYPE_HAITA_UPDDT
		Dim DATNO As String '伝票管理NO.
		Dim LINNO As String '行番号
		Dim WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		Dim UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
	End Structure
	Private HAITA_JDNTRA() As TYPE_HAITA_UPDDT
	'2007/12/05 FKS)minamoto ADD END
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim WL_DATNO As String
		Dim WL_CASSU As Decimal
		Dim WL_URISU As Decimal
		Dim Rtn As Short
		Dim rResult As Short ' 処理チェック関数戻り値
		Dim wkTNKKB As String
		Dim wkJDNTRKB As String

        '2019/04/01 ADD START
        Dim sqlStr As String
        '2019/04/01 ADD E N D
        '2019/06/26 ADD START
        Dim sqlWhereStr As String = ""
        '2019/06/26 ADD E N D
        'シリアル№登録ワークの削除
        '2019/04/01 CHG START
        'Call DB_BeginTransaction(CStr(BTR_Exclude))
        Call DB_BeginTrans(CON)
        '2019/04/01 CHG E N D
        '2019/04/02 CHG START
        'Call DB_GetGrEq(DBN_USRET51, 3, SSS_CLTID.Value, BtrNormal)
        sqlStr = ""
        sqlStr &= " SELECT "
        sqlStr &= "  * "
        sqlStr &= " FROM CNT_USR9.USRET51 "
        sqlStr &= " WHERE RPTCLTID = '" & SSS_CLTID.Value & "'"

        Dim dtUSRET51 As DataTable = DB_GetTable(sqlStr)
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Do While (DBSTAT = 0) And (Trim(DB_USRET51.RPTCLTID) = Trim(SSS_CLTID.Value))
        '    Call DB_Delete(DBN_USRET51)
        '    Call DB_GetNext(DBN_USRET51, BtrNormal)
        'Loop
        For Each row As DataRow In dtUSRET51.Rows
            sqlStr = ""
            sqlStr &= " DELETE "
            sqlStr &= " FROM CNT_USR9.USRET51 "
            sqlStr &= " WHERE RPTCLTID = '" & row("RPTCLTID") & "'"

            Call DB_Execute(sqlStr)
        Next
        '2019/04/02 CHG E N D
        '2019/04/01 CHG START
        'Call DB_EndTransaction()
        Call DB_Commit()
        '2019/04/01 CHG E N D

        I = 0
        WL_DATNO = Trim(SSS_LASTKEY.Value)
        If WG_DSPKB = 1 Then '売上伝票
            '2019/04/01 CHG START
            'Call DB_GetEq(DBN_UDNTHA, 1, SSS_LASTKEY.Value, BtrNormal)
            'Call UDNTHA_GetFirstRecByDATNO(SSS_LASTKEY.Value)
            sqlWhereStr = ""
            sqlWhereStr = "WHERE DATNO = '" & SSS_LASTKEY.Value & "'"
            Call GetRowsCommon(DBN_UDNTHA, sqlWhereStr)
            '2019/04/01 CHG E N D
            If DBSTAT = 0 Then
                If DB_UDNTHA.UDNDT <= DB_SYSTBA.MONUPDDT Then
                    SSS_UPDATEFL = False
                End If
                Call SCR_FromUDNTHA(-1)
                Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
                If (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) Then
                    'UPGRADE_WARNING: オブジェクト SSSVal(DB_UDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Do While (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
                        Call SCR_FromMfil(I)
                        Call DB_GetNext(DBN_UDNTRA, BtrNormal)
                        I = I + 1
                    Loop
                End If
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト LenWid(Trim$(RD_SSSMAIN_JDNNO(-1))) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If LenWid(Trim(RD_SSSMAIN_JDNNO(-1))) <> 0 Then
                    Call AE_InOutModeN_SSSMAIN("TOKCD", "0000")
                    Call AE_InOutModeN_SSSMAIN("TOKRN", "0000")
                End If
            End If
        ElseIf WG_DSPKB = 2 Then  '受注伝票

            '2019/04/01 CHG START
            'Call DB_GetEq(DBN_JDNTHA, 1, SSS_LASTKEY.Value, BtrNormal)
            'Call JDNTHA_GetFirstRecByDATNO(SSS_LASTKEY.Value)
            sqlWhereStr = " WHERE DATNO = '" & SSS_LASTKEY.Value & "'"
            Call GetRowsCommon("JDNTHA", sqlWhereStr)
            If DB_JDNTHA.JDNINKB Is Nothing Then
                DBSTAT = 1
            Else
                DBSTAT = 0
            End If
            '2019/06/26 CHG E N D 
            '2019/04/01 CHG E N D
            If DBSTAT = 0 Then
                Call SCR_FromJDNTHA(-1)
                WG_JDNINKB = DB_JDNTHA.JDNINKB

                '20190709 DEL START
                'Call MEIMTA_RClear()
                '20190709 DEL END

                wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
                '2019/04/01 CHG START
                'Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
                'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("006", wkJDNTRKB)

                sqlWhereStr = "WHERE KEYCD = '006' AND MEICDA = '" & wkJDNTRKB & "'"
                Call GetRowsCommon("MEIMTA", sqlWhereStr)
                '2019/04/01 CHG E N D
                WG_SYSTEM = DB_MEIMTA.MEIKBA

                ' 得意先マスタより納品先住所１・２・３を転送
                '''            Call DB_GetEq(DBN_TOKMTA, 1, DB_JDNTHA.NHSCD, BtrNormal)
                '''            If DBSTAT = 0 Then
                '''                Call SCR_FromTOKMTA(-1)
                '''            End If
                '2019/04/01 CHG START
                'Call DB_GetEq(DBN_NHSMTA, 1, DB_JDNTHA.NHSCD, BtrNormal)
                'If DBSTAT = 0 Then
                '    Call SCR_FromNHSMTA(-1)
                'End If
                Call DSPNHSCD_SEARCH(DB_JDNTHA.NHSCD, DB_NHSMTA)
                Call SCR_FromNHSMTA(-1)
                '2019/04/01 CHG E N D

                '2019/04/01 CHG START
                'Call DB_GetGrEq(DBN_JDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
                sqlStr = ""
                sqlStr &= " SELECT * "
                sqlStr &= " FROM JDNTRA "
                sqlStr &= " WHERE DATNO = '" & CF_Ora_Sgl(SSS_LASTKEY.Value) & "' "

                Dim dtJDNTRA As DataTable = DB_GetTable(sqlStr)
                '2019/04/01 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal(DB_JDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/01 CHG START
                'Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
                '    WL_URISU = 0
                '    WL_URISU = DB_JDNTRA.UODSU - DB_JDNTRA.URISU

                '    ' 更新パターンのチェック・エラーチェックを行う
                '    rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, (FR_SSSMAIN.CHECK_EMGODNKB.CheckState), DB_JDNTRA.ZAIKB)
                '    If rResult = -1 Or rResult > 900 Then
                '        'エラー伝票呼び出し、または存在しない明細あり
                '        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '指定した伝票は呼び出しできません。
                '        MsgBox("指定した伝票は呼び出しできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                '        I = 0
                '        Exit Do
                '    End If

                '    '                If (WL_URISU > 0) And (DB_JDNTRA.MNZHIKSU <> 0) And (DB_JDNTRA.FRDSU = 0) Then
                '    If (WL_URISU > 0) Then

                '        ' 小数点以下第１桁丸め処理
                '        WL_URISU = DCMFRC(WL_URISU, 1, 0)

                '        Call SCR_FromJDNTRA(I)
                '        '2007/12/05 FKS)minamoto ADD START
                '        '受注トラン：排他更新日時取得

                '        Call Haita_fromJDN(I)
                '        '2007/12/05 FKS)minamoto ADD END
                '        Call MEIMTA_RClear()
                '        wkTNKKB = DB_JDNTRA.TNKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTRA.TNKKB))
                '        Call DB_GetEq(DBN_MEIMTA, 2, "008" & wkTNKKB, BtrNormal)
                '        Call DP_SSSMAIN_TNKNM(I, DB_MEIMTA.MEINMA)

                '        Call HINMTA_RClear()
                '        Call DB_GetEq(DBN_HINMTA, 1, DB_JDNTRA.HINCD, BtrNormal)
                '        Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)

                '        Call DP_SSSMAIN_URITK(I, DCMFRC(DB_JDNTRA.UODTK, 1, 0))
                '        Call DP_SSSMAIN_SIKTK(I, DCMFRC(DB_JDNTRA.SIKTK, 1, 0))
                '        Call DP_SSSMAIN_TEIKATK(I, DCMFRC(DB_JDNTRA.TEIKATK, 1, 0))

                '        Call DP_SSSMAIN_URISU(I, WL_URISU)
                '        '【通販】及び【システムで諸口商品】時、分納無し
                '        If Trim(WG_JDNINKB) = "2" Or (Trim(WG_SYSTEM) = "M" And DB_HINMTA.HINID = "06") Then
                '            Call AE_InOutModeN_SSSMAIN("URISU", "0000")
                '        End If
                '        I = I + 1
                '    End If
                '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
                'Loop
                For Each row As DataRow In dtJDNTRA.Rows
                    If Not ((row("DATKB") = "1") And (WL_DATNO = row("DATNO")) And (SSSVal(row("LINNO")) < 990)) Then
                        Exit For
                    End If

                    WL_URISU = 0
                    WL_URISU = DB_NullReplace(row("UODSU"), 0) - DB_NullReplace(row("URISU"), 0)

                    ' 更新パターンのチェック・エラーチェックを行う
                    rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, (FR_SSSMAIN.CHECK_EMGODNKB.CheckState), row("ZAIKB"))
                    If rResult = -1 Or rResult > 900 Then
                        'エラー伝票呼び出し、または存在しない明細あり
                        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '指定した伝票は呼び出しできません。
                        MsgBox("指定した伝票は呼び出しできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                        I = 0
                        Exit For
                    End If

                    If (WL_URISU > 0) Then

                        ' 小数点以下第１桁丸め処理
                        WL_URISU = DCMFRC(WL_URISU, 1, 0)

                        '2019/04/02 CHG START
                        Call SCR_FromJDNTRA(I, row)
                        '2019/04/02 CHG E N D

                        '受注トラン：排他更新日時取得

                        Call Haita_fromJDN(I, row)

                        '20190709 DEL START
                        'Call MEIMTA_RClear()
                        '20190709 DEL END

                        '2019/04/01 CHG START
                        'wkTNKKB = row("TNKKB") & Space(Len(DB_MEIMTA.MEICDA) - Len(row("TNKKB")))
                        wkTNKKB = row("TNKKB") & Space(Len(DB_NullReplace(DB_MEIMTA.MEICDA, " ")) - Len(row("TNKKB")))
                        '2019/04/01 CHG E N D
                        '2019/04/01 CHG START
                        'Call DB_GetEq(DBN_MEIMTA, 2, "008" & wkTNKKB, BtrNormal)
                        'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("008", wkTNKKB)

                        sqlWhereStr = "WHERE KEYCD = '008' AND MEICDA = '" & wkTNKKB & "'"
                        Call GetRowsCommon("MEIMTA", sqlWhereStr)

                        '2019/04/01 CHG E N D
                        Call DP_SSSMAIN_TNKNM(I, DB_MEIMTA.MEINMA)

                        '20190709 DEL START
                        'Call HINMTA_RClear()
                        '20190709 DEL END

                        '2019/04/01 CHG START
                        'Call DB_GetEq(DBN_HINMTA, 1, row("HINCD"), BtrNormal)
                        '2019/06/26 CHG START
                        'Call HINMTA_GetFirstRecByHINCD(row("HINCD"))

                        sqlWhereStr = "WHERE HINCD = '" & row("HINCD") & "'"
                        Call GetRowsCommon("HINMTA", sqlWhereStr)
                        If DB_HINMTA.HINCD Is Nothing Then
                            DBSTAT = 1
                        Else
                            DBSTAT = 0
                        End If
                        '2019/06/26 CHG E N D
                        '2019/04/01 CHG E N D
                        Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)

                        Call DP_SSSMAIN_URITK(I, DCMFRC(row("UODTK"), 1, 0))
                        Call DP_SSSMAIN_SIKTK(I, DCMFRC(row("SIKTK"), 1, 0))
                        Call DP_SSSMAIN_TEIKATK(I, DCMFRC(row("TEIKATK"), 1, 0))

                        Call DP_SSSMAIN_URISU(I, WL_URISU)
                        '【通販】及び【システムで諸口商品】時、分納無し
                        If Trim(WG_JDNINKB) = "2" Or (Trim(WG_SYSTEM) = "M" And DB_HINMTA.HINID = "06") Then
                            Call AE_InOutModeN_SSSMAIN("URISU", "0000")
                        End If
                        I = I + 1
                    End If
                Next
                '2019/04/01 CHG E N D
                ' 送り状No.項目必須、任意切り替え
                Call must_Put_EMGODNKB()
            End If
        End If
        'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        DSPTRN = I
	End Function
	
	Sub INITDSP()
		Dim Px As Short
		Dim I As Short

        '2019/03/27 CHG START
        'Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
        If SYSTBA_SEARCH(DB_SYSTBA) <> 0 Then
            Exit Sub
        End If
        '2019/03/27 CHG E N D

		' 入力担当者・営業部門は未考慮。★
		AE_BackColor(1) = &H8000000F
		AE_BackColor(2) = &HFFFFFF
		
		' ヘッダ
		CL_SSSMAIN(2) = 11
		CL_SSSMAIN(3) = 11
		CL_SSSMAIN(5) = 11
		CL_SSSMAIN(6) = 11
		CL_SSSMAIN(7) = 11
		CL_SSSMAIN(8) = 11
		CL_SSSMAIN(9) = 11
		CL_SSSMAIN(10) = 11
		CL_SSSMAIN(11) = 11
		CL_SSSMAIN(12) = 11
		CL_SSSMAIN(13) = 11
		CL_SSSMAIN(14) = 11
		CL_SSSMAIN(16) = 11
		CL_SSSMAIN(17) = 11
		CL_SSSMAIN(18) = 11
		'
		' ボディ
		For Px = PP_SSSMAIN.BodyPx To PP_SSSMAIN.EBodyPx - 1
			CL_SSSMAIN(Px) = 11
		Next Px
		
		For I = 0 To 98
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 6) = 12
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 13) = 12
			CL_SSSMAIN(PP_SSSMAIN.BodyPx + (I * PP_SSSMAIN.BodyV) + 14) = 12
		Next I
		
		' テイル
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 2) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 3) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 4) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 5) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 6) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 7) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 8) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 9) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 11) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 13) = 11
		CL_SSSMAIN(PP_SSSMAIN.TailPx + 14) = 11
		
	End Sub
	
	Function INQ_CheckC() As Short
		Dim Rtn As Short
		Dim I As Short
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		Dim strSQL As String
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		INQ_CheckC = SSS_BILFL
		
		' システム上の税抜き金額と、手入力税抜き金額が一致する場合、税金・税込金額を表示。
		' それ以外はエラーメッセージを表示
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAURIKN(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (RD_SSSMAIN_SBAURIKN(0) + RD_SSSMAIN_SBAUZEKN(0)) <> RD_SSSMAIN_SBADENKN(0) Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '明細合計値と入力値が異なります。
			MsgBox("明細合計値と入力値が異なります。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/11/01 FKS)minamoto ADD START
		'2007/11/26 FKS)minamoto CHG START
		'If RD_SSSMAIN_UDNDT(0) < CNV_DATE(DB_JDNTHA.JDNDT) Then
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_UDNDT(0) < CNV_DATE(DB_JDNTHA.REGDT) Then
			'2007/11/26 FKS)minamoto CHG END
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 6) '受注日より前の日の為、入力できません。
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/11/01 FKS)minamoto ADD END
		'2007/12/05 FKS)minamoto ADD START
		'排他更新日時チェック
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    Start
		
		For intDe = 0 To PP_SSSMAIN.MaxDe Step 1
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
			If strJdnLinno = "" Then Exit For
			strSQL = ""
			strSQL = strSQL & "SELECT * FROM JDNTRA "
			strSQL = strSQL & " WHERE DATNO = '" & WG_JDNDATNO & "'"
            strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
            '2019/04/02 CHG START
            'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/02 CHG E N D
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/02 CHG START
            'If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU < CDec(RD_SSSMAIN_URISU(intDe)) And DB_JDNTRA.ZAIKB = "1" Then
            If dtJDNTRA.Rows(0)("OTPSU") - dtJDNTRA.Rows(0)("URISU") < CDec(RD_SSSMAIN_URISU(intDe)) And dtJDNTRA.Rows(0)("ZAIKB") = "1" Then
                '2019/04/02 CHG E N D
                '''' UPD 2009/02/23  FKS) S.Nakajima    Start
                '            MsgBox CStr(intDe + 1) & " 行目が出荷数不一致のため、売上登録出来ません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                MsgBox(CStr(intDe + 1) & " 行目が未出荷ありのため、売上登録出来ません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                '''' UPD 2009/02/23  FKS) S.Nakajima    End
                INQ_CheckC = -1
                Exit Function
            End If
        Next intDe
		
		'''' ADD 2008/11/21  FKS) S.Nakajima    End
		
		'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Rtn = CHK_HAITA_UPD
		If Rtn = 0 Then
			'エラー
			'2008/2/27 FKS)ichihara ADD START
			'タイムスタンプチェックでエラーの場合ロック解除
			Call DB_Execute(DBN_JDNTRA, "ROLLBACK")
			'2008/2/27 FKS)ichihara ADD END
			Rtn = DSP_MsgBox(SSS_ERROR, "URIET51_001", 0) '他のプログラムで更新されたため、削除できません。
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/12/05 FKS)minamoto ADD END
		'ADD START FKS)INABA 2009/07/03 **************************
		'連絡票№739
		Dim lw_ret As Short
		'UPGRADE_WARNING: オブジェクト CHK_UNYDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lw_ret = CHK_UNYDT(DB_UNYMTA.UNYDT)
		If lw_ret <> 0 Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_2", 0) '運用日が変更されました。メニューに戻ってください。。
			INQ_CheckC = 4
			Exit Function
		End If
		'ADD  END  FKS)INABA 2009/07/03 **************************
		
		
	End Function
	
	Function INQ_UPDATE() As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		INQ_UPDATE = 5
		'
		WG_BILFL = INQ_CheckC()
		'    Select Case SSS_BILFL
		Select Case WG_BILFL
			
			Case 1 ' 伝票発行有り
				' 伝票発行の場合はメッセージ確認をしないのでここでウィンドウを表示する
				DLGLST3.ShowDialog()
				Select Case SSSVal(SSS_RTNWIN)
					Case 0 ' 計上＋発行
                        Rtn = DELTRN()
                        '20190731 CHG START
                        'Rtn = WRTTRN()
                        Rtn = WRTTRN2()
                        '20190731 CHG END

                        '1999/12/01 更新エラーの場合には伝票発行しない
                        '            If Rtn = True Then Call PRNBIL
                        'Call PRNBIL
                    Case 1 ' 計上のみ
						Rtn = DELTRN()
                        '20190731 CHG START
                        'Rtn = WRTTRN()
                        Rtn = WRTTRN2()
                        '20190731 CHG END

                    Case 2 ' 発行のみ
						'            Call PRNBIL
					Case Else ' 戻る
						'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						INQ_UPDATE = 0
				End Select
			Case 9 ' 計上のみ
				Rtn = DELTRN()
                '20190731 CHG START
                'Rtn = WRTTRN()
                Rtn = WRTTRN2()
                '20190731 CHG END

            Case Else
				'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				INQ_UPDATE = 0
		End Select
	End Function
	
	' プリンタ切り替え機能を有効にする場合は以下のコメントアウト部分を有効にする。
	' 次にＳＦＤまたはＰＤＢで画面の”CM_LCONFIG”イメージを非表示から表示へ変更する。
	Function LCONFIG_GetEvent() As Short
		'   ' プリンター設定
		'    LCONFIG_GetEvent = True
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        SSS_RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        SSS_RPTID = ""
		'    End If
		'    WLS_PRN.Show 1
	End Function
	
	' 緊急出荷チェックボックス変更時処理
	Sub change_Check_Emgodnkb()
		Dim wk_Cursor As Short
		
		' 画面初期化
		Call MN_AppendC_Click()
		Call must_Put_EMGODNKB()
		
	End Sub
	
	' 画面初期化
	Private Sub MN_AppendC_Click() 'Generated.
		Dim wk_Cursor As Short
		If Not PP_SSSMAIN.Operable Then Exit Sub
		wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
		If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
	End Sub
	
	' 送り状No.項目必須、任意切り替え
	Private Sub must_Put_EMGODNKB()
		' チェックなし
		If FR_SSSMAIN.CHECK_EMGODNKB.CheckState = 0 Then
			Call AE_InOutModeN_SSSMAIN("OKRJONO", "0000")
			
			' チェックあり
		ElseIf FR_SSSMAIN.CHECK_EMGODNKB.CheckState = 1 Then 
			Call AE_InOutModeN_SSSMAIN("OKRJONO", "3303")
		End If
		
	End Sub
	
	' 引当未処理チェック
	Function check_HIKSU(ByRef pDATNO As String) As Short
		'pDATNOの全伝票明細の手動引当数がゼロかどうかをチェックする
		'引数    ：putDATNO as String （DATNO）
		'戻り値　：1・更新可能
		'　　　　　0・更新不可
		'          -1・エラー
		
		Dim HIKSU_flg As Short ' 0:手動引当数ゼロ　1:手動引当数あり
		Dim WL_DATNO As String
		WL_DATNO = Trim(pDATNO)
		
		HIKSU_flg = 0
		
		Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
		If DBSTAT = 0 Then
			Call SCR_FromJDNTHA(-1)
			Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
			'UPGRADE_WARNING: オブジェクト SSSVal(DB_JDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
				If DB_JDNTRA.MNZHIKSU <> 0 Then
					HIKSU_flg = 1
					Exit Do
				End If
				Call DB_GetNext(DBN_JDNTRA, BtrNormal)
			Loop 
			
			If HIKSU_flg = 1 Then
				check_HIKSU = 1
				
			Else
				check_HIKSU = 0
			End If
		Else
			check_HIKSU = -1
		End If
	End Function
	
	' 出荷指示取消未処理チェック
	Function check_FRDSU(ByRef pDATNO As String) As Short
		'pDATNOの全伝票明細の出荷指示数＞０かどうかをチェックする
		'引数    ：putDATNO as String （DATNO）
		'戻り値　：1・更新可能
		'　　　　　0・更新不可
		'          -1・エラー

        '2019/04/01 ADD START
        Dim strSQL As String
        '2019/04/01 ADD E N D

		Dim FRDSU_flg As Short ' 0:出荷指示数＞０　1:出荷指示数＝０
		Dim WL_DATNO As String
		WL_DATNO = Trim(pDATNO)
		
		FRDSU_flg = 0

        '2019/03/29 CHG START
        'Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
        'Call JDNTHA_GetFirstRecByDATNO(pDATNO)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE DATNO = '" & pDATNO & "'"
        Call GetRowsCommon("JDNTHA", sqlWhereStr)
        '2019/03/29 CHG E N D
        If DBSTAT = 0 Then
            Call SCR_FromJDNTHA(-1)
            '2019/04/01 CHG START
            'Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
            strSQL = ""
            strSQL &= " SELECT * "
            strSQL &= " FROM JDNTRA "
            strSQL &= " WHERE DATNO = '" & CF_Ora_Sgl(DB_JDNTHA.DATNO) & "' "

            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/01 CHG E N D

			'UPGRADE_WARNING: オブジェクト SSSVal(DB_JDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/01 CHG START
            'Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
            '    If DB_JDNTRA.FRDSU = 0 Then
            '        FRDSU_flg = 1
            '        Exit Do
            '    End If
            '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
            'Loop
            For Each row As DataRow In dtJDNTRA.Rows
                If Not ((row("DATKB") = "1") And (WL_DATNO = row("DATNO")) And (SSSVal(row("LINNO")) < 990)) Then
                    Exit For
                End If
                If row("FRDSU") = 0 Then
                    FRDSU_flg = 1
                    Exit For
                End If
            Next
            '2019/04/01 CHG E N D
			
			If FRDSU_flg = 1 Then
				check_FRDSU = 1
				
			Else
				check_FRDSU = 0
			End If
		Else
			check_FRDSU = -1
		End If
	End Function
    '2007/12/05 FKS)minamoto ADD START
    '2019/04/01 CHG START
    'Private Sub Haita_fromJDN(ByRef pIndex As Short)
    Private Sub Haita_fromJDN(ByRef pIndex As Short, ByVal pRowJDNTRA As DataRow)
        '2019/04/01 CHG E N D

        ReDim Preserve HAITA_JDNTRA(pIndex)

        '2019/04/01 CHG STAR
        'HAITA_JDNTRA(pIndex).DATNO = DB_JDNTRA.DATNO
        'HAITA_JDNTRA(pIndex).LINNO = DB_JDNTRA.LINNO
        'HAITA_JDNTRA(pIndex).WRTDT = DB_JDNTRA.WRTDT
        'HAITA_JDNTRA(pIndex).WRTTM = DB_JDNTRA.WRTTM
        'HAITA_JDNTRA(pIndex).UWRTDT = DB_JDNTRA.UWRTDT
        'HAITA_JDNTRA(pIndex).UWRTTM = DB_JDNTRA.UWRTTM
        HAITA_JDNTRA(pIndex).DATNO = pRowJDNTRA("DATNO")
        HAITA_JDNTRA(pIndex).LINNO = pRowJDNTRA("LINNO")
        HAITA_JDNTRA(pIndex).WRTDT = pRowJDNTRA("WRTDT")
        HAITA_JDNTRA(pIndex).WRTTM = pRowJDNTRA("WRTTM")
        HAITA_JDNTRA(pIndex).UWRTDT = pRowJDNTRA("UWRTDT")
        HAITA_JDNTRA(pIndex).UWRTTM = pRowJDNTRA("UWRTTM")
        '2019/04/01 CHG E N D
    End Sub
	Function CHK_HAITA_UPD() As Object
		Dim I As Short
		Dim strSQL As String
		
		'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHK_HAITA_UPD = 1
		'受注伝票
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'受注トラン
			
			strSQL = ""
			'2008/2/27 FKS)ichihara ADD START
			'        strSQL = "SELECT MAX(WRTDT),MAX(WRTTM),MAX(UWRTDT),MAX(UWRTTM) FROM JDNTRA"
			strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM JDNTRA"
			'2008/2/27 FKS)ichihara ADD END
			strSQL = strSQL & " WHERE DATNO = '" & HAITA_JDNTRA(I).DATNO & "'"
			strSQL = strSQL & "  AND LINNO = '" & HAITA_JDNTRA(I).LINNO & "'"
			'2008/2/27 FKS)ichihara ADD START
			'ロックする
			strSQL = strSQL & "          FOR UPDATE"
            '2008/2/27 FKS)ichihara ADD END
            '2019/04/02 CHG START
            'Call DB_GetSQL2(DBN_JDNTRA, strSQL)
            Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
            '2019/04/02 CHG E N D
			'2008/2/27 FKS)ichihara ADD START
			'        If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
			''            Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
            '2019/04/02 CHG START
            'If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_JDNTRA.WRTDT)) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_JDNTRA.WRTTM)) Or Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_JDNTRA.UWRTDT)) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_JDNTRA.UWRTTM)) Then
            If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(dtJDNTRA.Rows(0)("WRTDT"))) _
             Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(dtJDNTRA.Rows(0)("WRTTM"))) _
             Or Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(dtJDNTRA.Rows(0)("UWRTDT"))) _
             Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(dtJDNTRA.Rows(0)("UWRTTM"))) Then
                '2019/04/02 CHG E N D
                '2008/2/27 FKS)ichihara ADD END
                'エラー

                'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CHK_HAITA_UPD = 0
                Exit Function
            End If

            I = I + 1
        Loop
		
	End Function
	'2007/12/05 FKS)minamoto ADD END
End Module