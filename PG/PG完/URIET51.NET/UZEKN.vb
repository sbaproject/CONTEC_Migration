Option Strict Off
Option Explicit On
Module UZEKN_F52
	'
	' スロット名        : 売上消費税(税抜)・画面項目スロット
	' ユニット名        : UZEKN.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/11/07
	' 使用プログラム名  : URIET51
	'
	
	Function UZEKN_Derived(ByVal De_index As Object, ByVal URIKN As Object, ByVal UZEKN As Object, ByVal TOKCD As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal UDNDT As Object, ByRef CP_UZEKN As clsCP) As Object
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_UZEKN, WL_ZEIRT As Decimal
		
		'UPGRADE_WARNING: オブジェクト UZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UZEKN_Derived = 0
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URIKN) = "" Or URIKN = 0 Then Exit Function
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZCLKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZCLKB = RD_SSSMAIN_TOKZCLKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKRPSKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKRPSKB = RD_SSSMAIN_TOKRPSKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZRNKB = RD_SSSMAIN_TOKZRNKB(0)
		'UPGRADE_WARNING: オブジェクト De_index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_HINZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_HINZEIKB = RD_SSSMAIN_HINZEIKB(De_index)
		'UPGRADE_WARNING: オブジェクト De_index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De_index)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/01 ADD START
        ReDim Preserve SSS_WRKDT(0)
        '2019/04/01 ADD E N D
        SSS_WRKDT(0) = RD_SSSMAIN_UDNDT(0)
		
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZEIKB) = 9 Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZCLKB) <> 1 Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_HINZEIKB) <> 0 And SSSVal(WL_HINZEIKB) <> 1 Then Exit Function
		'    If SSSVal(WL_TOKZEIKB) = 0 And SSSVal(WL_HINZEIKB) <> 1 Then Exit Function  '1996/11/13 Delete
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_HINZEIKB) = 0 And SSSVal(WL_TOKZEIKB) <> 1 Then Exit Function '1996/11/13 Insert
		
		'   売上計上では, 消費税の手入力は原則として認めない
		'   もし手入力が必要な場合は､ UZEKN.F01のように次行を有効にする
		'    if &UKBCD[CWK]=10 RETURN
		WL_UZEKN = 0
		
		'2014/01/09 START UPD RS)Ishida 消費税法改正対応
		'売上・返品系画面では、受注の税率を使用するため税率の再取得は必要なし
		
		'Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB & SSS_WRKDT(0), BtrNormal)
		'If (DBSTAT <> 0) Or (DB_SYSTBB.ZEIRNKKB <> WL_ZEIRNKKB) Then Exit Function
		
		'WL_ZEIRT = DB_SYSTBB.ZEIRT
		'UPGRADE_WARNING: オブジェクト De_index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_ZEIRT = RD_SSSMAIN_ZEIRT(De_index)
		'2014/01/09 E.N.D UPD RS)Ishida 消費税法改正対応
		
		'======================================================================
		'   得意先の税区分と、商品の税区分の組み合わせにより、税抜・税込の
		'   判定を行う。
		'======================================================================
		
		'【通販】及び【システムで諸口商品】時、算出処理回避
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: オブジェクト UZEKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UZEKN_Derived = UZEKN
			Exit Function
		End If
		
		On Error GoTo OverFlow
		'''' UPD 2011/08/25  FKS) T.Yamamoto    Start    連絡票№FC11082501
		'    If SSSVal(WL_HINZEIKB) = 1 Then                               '商品・税抜き
		'        WL_UZEKN = URIKN * WL_ZEIRT / 100
		'    Else
		'        If SSSVal(WL_TOKZEIKB) = 1 Then                           '得意先・税抜き
		'            WL_UZEKN = URIKN * WL_ZEIRT / 100
		'        End If
		'    End If
		'    WL_UZEKN = DCMFRC(WL_UZEKN, SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
		Dim WL_ZURIKN As Decimal
		Dim WL_ZUZEKN As Decimal
		Dim strSQL As String
		
		'売上済分の売上金額、消費税額を取得
		strSQL = ""
		strSQL = strSQL & "SELECT SUM(URIKN)" & vbCrLf
		strSQL = strSQL & "     , SUM(UZEKN)" & vbCrLf
		strSQL = strSQL & "  FROM UDNTRA" & vbCrLf
		strSQL = strSQL & " WHERE DATKB = '1'" & vbCrLf
		strSQL = strSQL & "   AND (JDNNO,JDNLINNO) = " & vbCrLf
		strSQL = strSQL & "       (SELECT JDNNO,JDNLINNO" & vbCrLf
		strSQL = strSQL & "          FROM UDNTRA" & vbCrLf
		strSQL = strSQL & "         WHERE DATNO = '" & Left(SSS_LASTKEY.Value, 10) & "'" & vbCrLf
		strSQL = strSQL & "           AND LINNO = '" & Mid(SSS_LASTKEY.Value, 11, 3) & "')" & vbCrLf

        '2019/04/01 CHG START
        'Call DB_GetSQL2(DBN_UDNTRA, strSQL)
        Dim dtUDNTRA As DataTable = DB_GetTable(strSQL)
        If dtUDNTRA IsNot Nothing AndAlso dtUDNTRA.Rows.Count > 0 Then
            DB_UDNTRA.URIKN = DB_NullReplace(dtUDNTRA.Rows(0)("SUM(URIKN)"), 0)
            DB_UDNTRA.UZEKN = DB_NullReplace(dtUDNTRA.Rows(0)("SUM(UZEKN)"), 0)
        End If
        '2019/04/01 CHG E N D
        '返品後の残り売上金額を算出
        'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change 20190806 START hou
        ' WL_ZURIKN = DB_ExtNum.ExtNum(0) - URIKN
        WL_ZURIKN = 0 - URIKN
        'change 20190806 END hou

        '返品後の残り売上金額に対する消費税額を算出
        'UPGRADE_WARNING: オブジェクト SSSVal(WL_HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If SSSVal(WL_HINZEIKB) = 1 Then '商品・税抜き
            WL_ZUZEKN = WL_ZURIKN * WL_ZEIRT / 100
        Else
            'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If SSSVal(WL_TOKZEIKB) = 1 Then '得意先・税抜き
                WL_ZUZEKN = WL_ZURIKN * WL_ZEIRT / 100
            End If
        End If
        'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKRPSKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WL_ZUZEKN = DCMFRC(WL_ZUZEKN, SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
        'change 20190806 START hou
        ' WL_UZEKN = DB_ExtNum.ExtNum(1) - WL_ZUZEKN
        WL_UZEKN = 0 - WL_ZUZEKN
        'change 20190806 END hou

        '''' UPD 2011/08/25  FKS) T.Yamamoto    End
        'UPGRADE_WARNING: オブジェクト UZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        UZEKN_Derived = WL_UZEKN
        Exit Function
OverFlow:
        CP_UZEKN.StatusC = Cn_StatusError
        'UPGRADE_WARNING: オブジェクト UZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        UZEKN_Derived = "??????????????????"
	End Function
End Module