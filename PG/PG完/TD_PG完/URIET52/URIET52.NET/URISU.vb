Option Strict Off
Option Explicit On
Module URISU_F53
	'
	' スロット名        : 売上数量・画面項目スロット
	' ユニット名        : URISU.F53
	' 記述者            :
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	'
	
	Function URISU_CHECK(ByVal BKTHKKB As Object, ByVal URISU As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal MNZHIKSU As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		Dim Rtn As Short
		Dim strSQL As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		Dim intDe As Short
		Dim strJdnLinno As String
		Dim strJdnDatno As String
		Dim strJdnNo As String
		Dim strLinno As String
		Dim strDatNo As String
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		'
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_SBNSU(DE_INDEX, URISU)
		
		'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URISU_CHECK = 0
		
		'2008/2/5 FKS)ichihara ADD START
		'入力前数量と入力後の数量が異なる場合で出荷基準のとき、数量変更を不可とする
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If MNZHIKSU <> URISU Then
			'入力した数量が入力前と異なる場合
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If RD_SSSMAIN_URIKJN(-1) = "01" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 6) '出荷基準のため、数量は変更できません。
				'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'2008/2/5 FKS)ichihara ADD END
		
		' 分割不可区分（1：入力可、9：不可）が不可　かつ
		' 受注数量と異なる入力売上数量を入力した場合エラー
		'2008/2/5 FKS)ichihara CHG START
		'検収基準、工事完了基準の時は分割区分に関係なく数量訂正が可能とする
		'    If Trim$(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
		'        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 3)  '分割不可のため、分割売上はできません。
		'        URISU_CHECK = -1
		'        Exit Function
		'    End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_URIKJN(-1) <> "02" And RD_SSSMAIN_URIKJN(-1) <> "04" Then
			'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト BKTHKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 3) '分割不可のため、分割売上はできません。
				'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'2008/2/5 FKS)ichihara CHG END
		
		'通販時、分割売上不可
		If Trim(WG_JDNINKB) = "2" Then
			'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 3) '通販データの為、分割売上はできません。
				'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06" Then
			'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (UODSU - ATZHIKSU + MNZHIKSU) <> URISU Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 4) 'システム受注の諸口商品の為、分割売上はできません。
				'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECK = -1
				Exit Function
			End If
		End If
		
		' 受注数、又は受注残数を超える数量入力不可
		' ATZHIKSU⇒売上済み数
		' MNZHIKSU⇒訂正前売上数
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UODSU - ATZHIKSU + MNZHIKSU - URISU < 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 4) '受注数、又は受注残数を超える数量は入力できません。
			'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECK = -1
			Exit Function
		End If
		
		' 数量０は入力不可
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If URISU = 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 5) '数量ゼロは入力できません。
			'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECK = -1
			Exit Function
		End If
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    Start
		
		'出荷数不一致エラー
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intDe = CShort(DE_INDEX)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJdnLinno = Trim(CStr(RD_SSSMAIN_JDNLINNO(intDe)))
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJdnNo = Trim(CStr(RD_SSSMAIN_JDNNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
		strSQL = strSQL & " WHERE JDNNO = '" & strJdnNo & "'"
		Call DB_GetSQL2(DBN_JDNTHA, strSQL)
		strJdnDatno = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
		
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & strJdnDatno & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strJdnLinno & "'"
		Call DB_GetSQL2(DBN_JDNTRA, strSQL)
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strDatNo = Trim(CStr(RD_SSSMAIN_DATNO(-1)))
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strLinno = "0" & Trim(CStr(RD_SSSMAIN_LINNO(intDe)))
		strSQL = ""
		strSQL = strSQL & "SELECT * FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & strDatNo & "'"
		strSQL = strSQL & "   AND LINNO = " & "'" & strLinno & "'"
		Call DB_GetSQL2(DBN_UDNTRA, strSQL)
		
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If DB_JDNTRA.OTPSU - DB_JDNTRA.URISU + DB_UDNTRA.URISU < CDec(URISU) And DB_JDNTRA.ZAIKB = "1" Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 7) '出荷数不一致のため、売上登録出来ません。
			'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_CHECK = -1
			Exit Function
		End If
		
		
		'''' ADD 2008/11/28  FKS) S.Nakajima    End
		
		'
		'UPGRADE_WARNING: オブジェクト SERIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SERIKB = "1" Then
			strSQL = ""
			strSQL = strSQL & "SELECT COUNT(*) FROM SRAET53"
			strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
			strSQL = strSQL & "   AND PRGID    = " & "'" & SSS_PrgId & "'"
			'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
			'2008/1/22 FKS)ichihara CHG START
			'FJCL修正分の反映（377案件分）
			''''''''strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
			'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'" '2008/01/17 復活
			'2008/1/22 FKS)ichihara CHG START
			
			strSQL = strSQL & "   AND CHKFLG   = '1'"
			Call DB_GetSQL2(DBN_SRAET53, strSQL)
			
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If URISU < DB_ExtNum.ExtNum(0) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 4) '返品数以上のｼﾘｱﾙが登録
				'UPGRADE_WARNING: オブジェクト URISU_CHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_CHECK = -1
			End If
		End If
		
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal SBNSU As Object, ByVal UDNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal BKTHKKB As Object, ByVal UODSU As Object, ByVal ATZHIKSU As Object, ByVal MNZHIKSU As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		'
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_URISU(DE_INDEX, RD_SSSMAIN_SBNSU(DE_INDEX))
		
		'2008/2/5 FKS)ichihara CHG START
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_URIKJN(-1) = "02" Or RD_SSSMAIN_URIKJN(-1) = "04" Then
			'検収基準、工事完了基準の時はシリアル№登録画面は表示しない
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'2008/2/5 FKS)ichihara CHG END
		
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SERIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0) Or (SERIKB = "9") Or Trim(HINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		' 分割不可区分（1：入力可、9：不可）が不可　かつ
		' 受注数量と異なる入力売上数量を入力した場合エラー
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト BKTHKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BKTHKKB) = "9" And (UODSU - ATZHIKSU + MNZHIKSU) <> RD_SSSMAIN_URISU(DE_INDEX) Then
			Exit Function
		End If
		
		' 受注数、又は受注残数を超える数量入力不可
		' ATZHIKSU⇒売上済み数
		' MNZHIKSU⇒訂正前売上数
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト MNZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ATZHIKSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UODSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UODSU - ATZHIKSU + MNZHIKSU - RD_SSSMAIN_URISU(DE_INDEX) < 0 Then
			Exit Function
		End If
		
		'    Link_Index = Index
		'    mm_OPT2 = True
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 11
		'    Call Link_Shell("BMNMT51")
		'    Shell (AE_AppPath$ & "\SRAET51.EXE /RPTCLTID:" & SSS_CLTID _
		''                & " /JDNNO:" & Trim(JDNNO) & " /JDNLINNO:" & JDNLINNO & " /HINCD:" & Trim(HINCD) & " /URISU:" & URISU)
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		EXEPATH = AE_AppPath & "SRAET53.EXE /RPTCLTID:" & SSS_CLTID.Value & " /PRGID:" & SSS_PrgId & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 2
		'    mm_OPT2 = False
		'
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM SRAET53"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		strSQL = strSQL & "   AND PRGID    = " & "'" & SSS_PrgId & "'"
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
		
		'2008/1/22 FKS)ichihara CHG START
		'FJCL修正分の反映（377案件分）
		''''strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'" '2008/01/17 復活
		'2008/1/22 FKS)ichihara CHG END
		
		Call DB_GetSQL2(DBN_SRAET53, strSQL)
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_SBNSU(DE_INDEX, DB_ExtNum.ExtNum(0))
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
		
	End Function
End Module