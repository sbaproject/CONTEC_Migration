Option Strict Off
Option Explicit On
Module URIET52_E01
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : URIET52.E01
	' 記述者            :
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	'
	
	Public Const WG_DKBSB As String = "040"
	
	Public WG_DSPKB As Short '1:売上伝票 2:受注伝票
	Public SetFirst As Boolean
	Public WG_BILFL As Short
	Public WG_JDNINKB As String '受注取込種別(1:入力 2:通販 3:VAN 4:WEB)
	Public WG_SYSTEM As String 'M:MEIKBA(受注取引区分用）システム
	'2007/12/06 FKS)minamoto ADD START
	Structure TYPE_HAITA_UPDDT
		Dim DATNO As String '伝票管理NO.
		Dim LINNO As String '行番号
		Dim WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		Dim UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
	End Structure
	Private HAITA_JDNTRA() As TYPE_HAITA_UPDDT
	Private HAITA_UDNTRA() As TYPE_HAITA_UPDDT
	'2007/12/06 FKS)minamoto ADD END
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim J As Short
		Dim wkJDNTRKB As String
		Dim wkURIKJN As String
		Dim wkTNKKB As String
		Dim wkSZTNM As String
		Dim WL_DATNO As String
		Dim WL_CASSU As Decimal
		Dim WL_URISU As Decimal
		Dim Rtn As Short
		Dim rResult As Short ' 処理チェック関数戻り値
		
		Dim strSQL As String
		Dim wkDATNO As String
		
		
		'シリアル№登録ワークの削除
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
			Call DB_Delete(DBN_SRAET53)
			Call DB_GetNext(DBN_SRAET53, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		I = 0
        WL_DATNO = Trim(SSS_LASTKEY.Value)
        'change start 20190830 kuwa 　
        'Call DB_GetEq(DBN_UDNTHA, 1, WL_DATNO, BtrNormal)
        GetRowsCommon(DBN_UDNTHA, "where DATNO = '" & WL_DATNO & "'")
        'change end 20190830 kuwa

        If DBSTAT = 0 Then
			'売上基準が出荷基準は売上日変更不可
			If DB_UDNTHA.URIKJN = "01" Then
				Call AE_InOutModeN_SSSMAIN("UDNDT", "0000")
			Else
				Call AE_InOutModeN_SSSMAIN("UDNDT", "3303")
			End If
			Call SCR_FromUDNTHA(I)
			'緊急出荷ﾁｪｯｸﾎﾞｯｸｽ
			If DB_UDNTHA.EMGODNKB = "1" Then
				Call DP_SSSMAIN_EMGODNKB(I, "1")
			Else
				Call DP_SSSMAIN_EMGODNKB(I, "0")
			End If

            '受注取引区分名
            '20190726 DELL START
            'Call MEIMTA_RClear()
            '20190726 DELL END
            wkJDNTRKB = DB_UDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_UDNTHA.JDNTRKB))
            'change start 20190830 kuwa
            'Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
            GetRowsCommon(DBN_MEIMTA, "where KeyCD = '006' and MEICDA = '" & wkJDNTRKB & "'")
            'change end 20190830 kuwa
            Call DP_SSSMAIN_JDNTRNM(I, DB_MEIMTA.MEINMA)
			WG_SYSTEM = DB_MEIMTA.MEIKBA

            '売上基準名
            '20190726 DELL START
            'Call MEIMTA_RClear()
            '20190726 DELL END
            wkURIKJN = DB_UDNTHA.URIKJN & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_UDNTHA.URIKJN))
            'change start 20190830 kuwa
            'Call DB_GetEq(DBN_MEIMTA, 2, "005" & wkURIKJN, BtrNormal)
            GetRowsCommon("MEIMTA", "where KeyCD = '005' and MEICDA = '" & wkURIKJN & "'")
            'change end 20190830 kuwa
            Call DP_SSSMAIN_URIKJNNM(I, DB_MEIMTA.MEINMA)

            '出荷指示見出しトラン
            If DB_UDNTHA.EMGODNKB = "1" Then
                'change start 20190830 kuwa
                'Call DB_GetEq(DBN_FDNTHA, 1, DB_UDNTHA.DATNO, BtrNormal)
                GetRowsCommon(DBN_FDNTHA, "where DATNO = '" & DB_UDNTHA.DATNO & "'")
                'change end 20190830 kuwa
                If DBSTAT = 0 Then
                    Call SCR_FromFDNTHA(I)
                End If
            End If

            '売上トラン
            'change start 20190829 kuwa
            'Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
            Dim sqlWhereStr As String = ""
            sqlWhereStr = " WHERE DATNO = '" & SSS_LASTKEY.Value & "'"
            Call GetRowsCommon(DBN_UDNTRA, sqlWhereStr)
            'change end 20190829 kuwa
            If (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) Then
				Call DB_BeginTransaction(CStr(BTR_Exclude))
				'UPGRADE_WARNING: オブジェクト SSSVal(DB_UDNTRA.LINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Do While (DBSTAT = 0) And (WL_DATNO = DB_UDNTRA.DATNO) And (SSSVal(DB_UDNTRA.LINNO) < 990)
                    '20190627 DELL START
                    'Call HINMTA_RClear()
                    '20190726 DELL END
                    'change start 20190830 kuwa
                    'Call DB_GetEq(DBN_HINMTA, 1, DB_UDNTRA.HINCD, BtrNormal)
                    GetRowsCommon(DBN_HINMTA, "where HINCD = '" & DB_UDNTRA.HINCD & "'")
                    Call DP_SSSMAIN_SERIKB(I, DB_HINMTA.SERIKB)
					Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)
					Call SCR_FromMfil(I)
					'2007/12/06 FKS)minamoto ADD START
					'売上トラン：排他更新日時取得
					
					Call Haita_fromUDN(I)
                    '2007/12/06 FKS)minamoto ADD END
                    Call DP_SSSMAIN_SBNSU(I, DB_UDNTRA.URISU)
                    '20190726 DELL START
                    'Call MEIMTA_RClear()
                    '20190726 DELL END
                    wkTNKKB = DB_UDNTRA.TNKID & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_UDNTRA.TNKID))
                    'change start 20190830 kuwa
                    'Call DB_GetEq(DBN_MEIMTA, 2, "008" & wkTNKKB, BtrNormal)
                    GetRowsCommon(DBN_MEIMTA, "where KeyCD = '008' and MEICDA = '" & wkTNKKB & "'")
                    'change end 20190830 kuwa
                    Call DP_SSSMAIN_TNKKB(I, DB_MEIMTA.MEINMA)
					
					'出荷計上済みは、数量変更不可＆単品売上情報は数量変更不可
					If Trim(DB_UDNTRA.ODNNO) = "" And DB_UDNTHA.JDNTRKB <> "01" Then
						Call AE_InOutModeN_SSSMAIN("URISU", "3303")
					Else
						Call AE_InOutModeN_SSSMAIN("URISU", "0000")
					End If

                    '出荷指示トラン
                    If DB_UDNTHA.EMGODNKB = "1" Then
                        'change start 20190830 kuwa
                        'Call DB_GetEq(DBN_FDNTRA, 1, DB_UDNTRA.DATNO & DB_UDNTRA.LINNO, BtrNormal)
                        GetRowsCommon(DBN_FDNTRA, "where DATNO = '" & DB_UDNTRA.DATNO & "' and LINNO = '" & DB_UDNTRA.LINNO & "'")
                        'change end 20190830 kuwa
                        If DBSTAT = 0 Then
                            Call SCR_FromFDNTRA(I)
                        End If
                    End If

                    strSQL = ""
					strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
                    strSQL = strSQL & " WHERE JDNNO = '" & DB_UDNTRA.JDNNO & "'"
                    'change start 20190829 kuwa
                    'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
                    'wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
                    Dim dt As DataTable = DB_GetTable(strSQL)
                    wkDATNO = VB6.Format(dt.Rows(0)("MAX(DATNO)"), "0000000000")
                    'change end 20190829 kuwa
                    'change start 20190830 kuwa
                    'Call DB_GetEq(DBN_JDNTHA, 1, wkDATNO, BtrNormal)
                    GetRowsCommon(DBN_JDNTHA, "where DATNO = '" & wkDATNO & "'")
                    'change end 20190830 kuwa
                    If (DBSTAT = 0) And (DB_JDNTHA.DATKB = "1") And (DB_JDNTHA.AKAKROKB = "1") And (DB_JDNTHA.DENKB = "1") Then
						Call DP_SSSMAIN_BKTHKKB(I, DB_JDNTHA.BKTHKKB) '分割不可区分
						WG_JDNINKB = DB_JDNTHA.JDNINKB '受注取込種別  '2006.11.08
					End If

                    '受注トラン
                    'change start 20190830 kuwa 
                    'Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_UDNTRA.JDNLINNO, BtrNormal)
                    GetRowsCommon(DBN_JDNTRA, "where DATNO = '" & wkDATNO & "' and LINNO = '" & DB_UDNTRA.JDNLINNO & "'")
                    'change end 20190830 kuwa
                    If DBSTAT = 0 Then
						Call DP_SSSMAIN_UODSU(I, DB_JDNTRA.UODSU)
						'画面の自動引当数に売上済み数をセット
						Call DP_SSSMAIN_ATZHIKSU(I, DB_JDNTRA.URISU)
					End If
					'2007/12/06 FKS)minamoto ADD START
					'受注トラン：排他更新日時取得
					
					Call Haita_fromJDN(I)
					'2007/12/06 FKS)minamoto ADD END
					
					'画面の手動引当数に訂正前の売上数をセット
					Call DP_SSSMAIN_MNZHIKSU(I, DB_UDNTRA.URISU)
					
					'シリアルワークのセット
					If Trim(DB_UDNTHA.NHSCD) = "" Then
						wkSZTNM = Left(DB_UDNTHA.TOKCD, 9)
					Else
						wkSZTNM = Left(DB_UDNTHA.NHSCD, 9)
					End If
					Call DB_GetGrEq(DBN_SRACNTTB, 3, DB_UDNTHA.UDNDT & wkSZTNM & DB_UDNTRA.HINCD & DB_UDNTRA.SBNNO, BtrNormal)
					J = 0
					Do While DBSTAT = 0 And DB_SRACNTTB.RSTDT = DB_UDNTHA.UDNDT And DB_SRACNTTB.SZTNM = wkSZTNM And DB_SRACNTTB.HINCD = DB_UDNTRA.HINCD And DB_SRACNTTB.SBNNO = DB_UDNTRA.SBNNO
						Call SRAET53_RClear()
						DB_SRAET53.RPTCLTID = SSS_CLTID.Value
						DB_SRAET53.PRGID = SSS_PrgId
						DB_SRAET53.HINCD = DB_SRACNTTB.HINCD
						DB_SRAET53.SBNNO = DB_SRACNTTB.SBNNO
						DB_SRAET53.SRANO = DB_SRACNTTB.SRANO
						J = J + 1
						DB_SRAET53.SRALINNO = VB6.Format(J, "000000")
						DB_SRAET53.LOCKBN = "1"
						DB_SRAET53.CHKFLG = "1"
						DB_SRAET53.ZAISYOBN = DB_SRACNTTB.ZAISYOBN
						Call DB_Insert(DBN_SRAET53, 1)
						Call DB_GetNext(DBN_SRACNTTB, BtrNormal)
					Loop
                    'delete test 20190829 kuwa
                    'Call DB_GetNext(DBN_UDNTRA, BtrNormal)
                    I = I + 1
                Loop 
				Call DB_EndTransaction()
			End If
		End If
		'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DSPTRN = I
		
	End Function
	
	Sub INITDSP()
		Dim Px As Short
		Dim I As Short
		
		' 入力担当者・営業部門は未考慮。★
		AE_BackColor(1) = &H8000000F
		AE_BackColor(2) = &HFFFFFF
		
		' ヘッダ
		CL_SSSMAIN(2) = 1
		CL_SSSMAIN(3) = 1
		CL_SSSMAIN(4) = 1
		CL_SSSMAIN(5) = 1
		CL_SSSMAIN(7) = 1
		CL_SSSMAIN(8) = 1
		CL_SSSMAIN(9) = 1
		CL_SSSMAIN(10) = 1
		CL_SSSMAIN(11) = 1
		CL_SSSMAIN(12) = 1
		CL_SSSMAIN(13) = 1
		CL_SSSMAIN(14) = 1
		CL_SSSMAIN(15) = 1
		CL_SSSMAIN(16) = 1
		CL_SSSMAIN(18) = 1
		CL_SSSMAIN(19) = 1
		CL_SSSMAIN(20) = 1
		' ボディ
		For I = 0 To PP_SSSMAIN.MaxDe
			CL_SSSMAIN(58 + I * 88) = 1
			CL_SSSMAIN(59 + I * 88) = 1
			CL_SSSMAIN(60 + I * 88) = 1
			CL_SSSMAIN(61 + I * 88) = 1
			CL_SSSMAIN(62 + I * 88) = 1
			CL_SSSMAIN(63 + I * 88) = 1
			CL_SSSMAIN(65 + I * 88) = 1
			CL_SSSMAIN(66 + I * 88) = 1
			CL_SSSMAIN(67 + I * 88) = 1
			CL_SSSMAIN(68 + I * 88) = 1
			CL_SSSMAIN(69 + I * 88) = 1
			CL_SSSMAIN(70 + I * 88) = 1
		Next 
		' テイル
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 2) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 3) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 4) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 5) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 6) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 7) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 8) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 9) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 11) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 13) = 1
		CL_SSSMAIN(58 + (88 * (PP_SSSMAIN.MaxDe + 1)) + 14) = 1

        '運用日の取得等

        '2019/06/07 CHG START
        'Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal)
        If SYSTBA_SEARCH(DB_SYSTBA) <> 0 Then
            Exit Sub
        End If
        '2019/06/07
        '2019/06/07 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        '20190726 CHG START START
        'Call UNYMTA_GetFirst()
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190726 CHG END
        '2019/06/07 CHG E N D

        '実行権限の取得
        Call Get_Authority(DB_UNYMTA.UNYDT)
		
	End Sub
	
	Function INQ_CheckC() As Short
		Dim Rtn As Short
		Dim I As Short
		Dim wkTOKCD As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		Dim strJdnDatno As String
		Dim strJdnNo As String
		Dim strLinno As String
		Dim strDatNo As String
		Dim strSQL As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		INQ_CheckC = SSS_BILFL
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_UDNDT(0) <= DB_SYSTBA.UKSMEDT Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '月次仮締日を過ぎています。
			INQ_CheckC = 4
			Exit Function
		End If
        '
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        wkTOKCD = RD_SSSMAIN_TOKCD(0) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(0)))
        'change start 20190830 kuwa
        'Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
        GetRowsCommon(DBN_TOKMTA, "where TOKCD = '" & wkTOKCD & "'")
        'change end 20190830 kuwa
        If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If RD_SSSMAIN_UDNDT(0) <= DB_TOKMTA.TOKSMEDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '登録された得意先の請求締日を過ぎています。
				INQ_CheckC = 4
				Exit Function
			End If
		End If
		
		' システム上の税抜き金額と、手入力税抜き金額が一致する場合、税金・税込金額を表示。
		' それ以外はエラーメッセージを表示
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAURIKN(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (RD_SSSMAIN_SBAURIKN(0) + RD_SSSMAIN_SBAUZEKN(0)) <> RD_SSSMAIN_SBADENKN(0) Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 6) '明細合計値と入力値が異なります。
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/12/06 FKS)minamoto ADD START
		'排他更新日時チェック
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		
		'出荷数不一致エラー
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJdnNo = Trim(CStr(RD_SSSMAIN_JDNNO(-1)))
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strDatNo = Trim(CStr(RD_SSSMAIN_DATNO(-1)))
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
        strSQL = strSQL & " WHERE JDNNO = '" & strJdnNo & "'"
        'change start 20190830 kuwa
        'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190830 kuwa
        'change start 20190830 kuwa
        'strJdnDatno = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
        strJdnDatno = VB6.Format(dt.Rows(0)("MAX(DATNO)"), "0000000000")
        'change end 20190830 kuwa
        For intDe = 0 To PP_SSSMAIN.MaxDe Step 1
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
			If strJdnLinno = "" Then Exit For
			
			strSQL = ""
			strSQL = strSQL & "SELECT * FROM JDNTRA "
			strSQL = strSQL & " WHERE DATNO = '" & strJdnDatno & "'"
			strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
			Call DB_GetSQL2(DBN_JDNTRA, strSQL)
			
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strLinno = "0" & Trim(CStr(RD_SSSMAIN_LINNO(intDe)))
			
			strSQL = ""
			strSQL = strSQL & "SELECT * FROM UDNTRA "
			strSQL = strSQL & " WHERE DATNO = '" & strDatNo & "'"
			strSQL = strSQL & "   AND LINNO = " & "'" & strLinno & "'"
			Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU + DB_UDNTRA.URISU < CDec(RD_SSSMAIN_URISU(intDe)) And DB_JDNTRA.ZAIKB = "1" Then
				MsgBox(CStr(intDe + 1) & " 行目が未出荷ありのため、売上登録出来ません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
				INQ_CheckC = -1
				Exit Function
			End If
			
		Next intDe
		
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Rtn = CHK_HAITA_UPD
		If Rtn = 0 Then
			'エラー
			'2008/2/27 FKS)ichihara ADD START
			'タイムスタンプチェックでエラーの場合ロック解除
			Call DB_Execute(DBN_JDNTRA, "ROLLBACK")
			Call DB_Execute(DBN_UDNTRA, "ROLLBACK")
			'2008/2/27 FKS)ichihara ADD END
			Rtn = DSP_MsgBox(SSS_ERROR, "URIET52_001", 0) '他のプログラムで更新されたため、訂正できません。
			INQ_CheckC = 4
			Exit Function
		End If
		'2007/12/06 FKS)minamoto ADD END
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
		'権限チェック
		If gs_UPDAUTH = "9" Then
			Rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '更新権限なし
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			INQ_UPDATE = 0
			Exit Function
		End If
		
		WG_BILFL = INQ_CheckC()
        '    Select Case SSS_BILFL
        Select Case WG_BILFL


            Case 1 ' 伝票発行有り
                ' 伝票発行の場合はメッセージ確認をしないのでここでウィンドウを表示する
                DLGLST3.ShowDialog()
                Select Case SSSVal(SSS_RTNWIN)
                    Case 0 ' 計上＋発行
                        Rtn = DELTRN()
                        Rtn = WRTTRN()
                        '1999/12/01 更新エラーの場合には伝票発行しない
                        '            If Rtn = True Then Call PRNBIL
                        'Call PRNBIL
                    Case 1 ' 計上のみ
                        Rtn = DELTRN()
                        Rtn = WRTTRN()
                    Case 2 ' 発行のみ
                        '            Call PRNBIL
                    Case Else ' 戻る
                        'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        INQ_UPDATE = 0
                End Select
            Case 9 ' 計上のみ
                Rtn = DELTRN()
                Rtn = WRTTRN()
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
        Dim wk_Cursor As Integer

        ' 画面初期化
        Call MN_AppendC_Click()
        Call must_Put_EMGODNKB

    End Sub

    ' 画面初期化
    'change start 20190730 kuwahara 
    'Private Sub MN_AppendC_Click() 'Generated.
    'change end 20190730 kuwahara
    Sub MN_AppendC_Click() 'Generated.
        Dim wk_Cursor As Short
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
        If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
    End Sub

    ' 送り状No.項目必須、任意切り替え
    Private Sub must_Put_EMGODNKB()
        ' チェックなし
        If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
            Call AE_InOutModeN_SSSMAIN("OKRJONO", "0000")

            ' チェックあり
        ElseIf FR_SSSMAIN.HD_EMGODNKB.CheckState = 1 Then
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
		
		'''Dim HIKSU_flg As Integer     ' 0:手動引当数ゼロ　1:手動引当数あり
		'''Dim WL_DATNO As String
		'''    WL_DATNO = Trim$(pDATNO)
		'''
		'''    HIKSU_flg = 0
		'''
		'''    Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
		'''    If DBSTAT = 0 Then
		'''        Call SCR_FromJDNTHA(-1)
		'''        Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
		'''        Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
		'''            If DB_JDNTRA.MNZHIKSU <> 0 Then
		'''                HIKSU_flg = 1
		'''                Exit Do
		'''            End If
		'''            Call DB_GetNext(DBN_JDNTRA, BtrNormal)
		'''        Loop
		'''
		'''        If HIKSU_flg = 1 Then
		'''            check_HIKSU = 1
		'''
		'''        Else
		'''            check_HIKSU = 0
		'''        End If
		'''    Else
		'''        check_HIKSU = -1
		'''    End If
	End Function
	
	' 出荷指示取消未処理チェック
	Function check_FRDSU(ByRef pDATNO As String) As Short
		'pDATNOの全伝票明細の出荷指示数＞０かどうかをチェックする
		'引数    ：putDATNO as String （DATNO）
		'戻り値　：1・更新可能
		'　　　　　0・更新不可
		'          -1・エラー
		
		'''Dim FRDSU_flg As Integer     ' 0:出荷指示数＞０　1:出荷指示数＝０
		'''Dim WL_DATNO As String
		'''    WL_DATNO = Trim$(pDATNO)
		'''
		'''    FRDSU_flg = 0
		'''
		'''    Call DB_GetEq(DBN_JDNTHA, 1, pDATNO, BtrNormal)
		'''    If DBSTAT = 0 Then
		'''        Call SCR_FromJDNTHA(-1)
		'''        Call DB_GetGrEq(DBN_JDNTRA, 1, pDATNO, BtrNormal)
		'''        Do While (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (WL_DATNO = DB_JDNTRA.DATNO) And (SSSVal(DB_JDNTRA.LINNO) < 990)
		'''            If DB_JDNTRA.FRDSU = 0 Then
		'''                FRDSU_flg = 1
		'''                Exit Do
		'''            End If
		'''            Call DB_GetNext(DBN_JDNTRA, BtrNormal)
		'''        Loop
		'''
		'''        If FRDSU_flg = 1 Then
		'''            check_FRDSU = 1
		'''
		'''        Else
		'''            check_FRDSU = 0
		'''        End If
		'''    Else
		'''        check_FRDSU = -1
		'''    End If
	End Function
	'2007/12/06 FKS)minamoto ADD START
	Private Sub Haita_fromUDN(ByRef pIndex As Short)
		
		ReDim Preserve HAITA_UDNTRA(pIndex)
		
		HAITA_UDNTRA(pIndex).DATNO = DB_UDNTRA.DATNO
		HAITA_UDNTRA(pIndex).LINNO = DB_UDNTRA.LINNO
		HAITA_UDNTRA(pIndex).WRTDT = DB_UDNTRA.WRTDT
		HAITA_UDNTRA(pIndex).WRTTM = DB_UDNTRA.WRTTM
		HAITA_UDNTRA(pIndex).UWRTDT = DB_UDNTRA.UWRTDT
		HAITA_UDNTRA(pIndex).UWRTTM = DB_UDNTRA.UWRTTM
	End Sub
	Private Sub Haita_fromJDN(ByRef pIndex As Short)
		
		ReDim Preserve HAITA_JDNTRA(pIndex)
		
		HAITA_JDNTRA(pIndex).DATNO = DB_JDNTRA.DATNO
		HAITA_JDNTRA(pIndex).LINNO = DB_JDNTRA.LINNO
		HAITA_JDNTRA(pIndex).WRTDT = DB_JDNTRA.WRTDT
		HAITA_JDNTRA(pIndex).WRTTM = DB_JDNTRA.WRTTM
		HAITA_JDNTRA(pIndex).UWRTDT = DB_JDNTRA.UWRTDT
		HAITA_JDNTRA(pIndex).UWRTTM = DB_JDNTRA.UWRTTM
	End Sub
	Function CHK_HAITA_UPD() As Object
		Dim I As Short
		Dim strSQL As String
		
		'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHK_HAITA_UPD = 1
		'受注伝票
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'売上トラン
			
			strSQL = ""
			'2008/2/27 FKS)ichihara ADD START
			'        strSQL = "SELECT MAX(WRTDT),MAX(WRTTM),MAX(UWRTDT),MAX(UWRTTM) FROM UDNTRA"
			strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM UDNTRA"
			'2008/2/27 FKS)ichihara ADD END
			strSQL = strSQL & " WHERE DATNO = '" & HAITA_UDNTRA(I).DATNO & "'"
			strSQL = strSQL & "  AND LINNO = '" & HAITA_UDNTRA(I).LINNO & "'"
			'2008/2/27 FKS)ichihara ADD START
			'ロックする
			strSQL = strSQL & "          FOR UPDATE"
			'2008/2/27 FKS)ichihara ADD END
			Call DB_GetSQL2(DBN_UDNTRA, strSQL)
			'2008/2/27 FKS)ichihara ADD START
			'        If Val(HAITA_UDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_UDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
			''            Val(HAITA_UDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_UDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
			If Val(HAITA_UDNTRA(I).WRTDT) <> Val(CStr(DB_UDNTRA.WRTDT)) Or Val(HAITA_UDNTRA(I).WRTTM) <> Val(CStr(DB_UDNTRA.WRTTM)) Or Val(HAITA_UDNTRA(I).UWRTDT) <> Val(CStr(DB_UDNTRA.UWRTDT)) Or Val(HAITA_UDNTRA(I).UWRTTM) <> Val(CStr(DB_UDNTRA.UWRTTM)) Then
				'2008/2/27 FKS)ichihara ADD END
				'エラー
				'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CHK_HAITA_UPD = 0
				Exit Function
			End If
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
			Call DB_GetSQL2(DBN_JDNTRA, strSQL)
			'2008/2/27 FKS)ichihara ADD START
			'        If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
			''            Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
			If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_JDNTRA.WRTDT)) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_JDNTRA.WRTTM)) Or Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_JDNTRA.UWRTDT)) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_JDNTRA.UWRTTM)) Then
				'2008/2/27 FKS)ichihara ADD END
				'エラー
				'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CHK_HAITA_UPD = 0
				Exit Function
			End If
			
			I = I + 1
		Loop 
		
	End Function
	'2007/12/06 FKS)minamoto ADD END
End Module