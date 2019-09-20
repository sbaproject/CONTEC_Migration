Option Strict Off
Option Explicit On
Module ZKMUZEKN_F51
	'
	' スロット名        : 売上消費税(税込)・画面項目スロット
	' ユニット名        : ZKMUZEKN.F01
	' 記述者            : Standard Library
	' 作成日付          : 1997/06/11
	' 使用プログラム名  : URIET01
	'
	
	Function ZKMUZEKN_Derived(ByVal DE_INDEX As Object, ByVal URIKN As Object, ByVal UZEKN As Object, ByVal TOKCD As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal UDNDT As Object) As Object
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_ZKMUZEKN, WL_ZEIRT As Decimal
		
		'UPGRADE_WARNING: オブジェクト ZKMUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZKMUZEKN_Derived = 0
		'UPGRADE_WARNING: オブジェクト SSSVal(URIKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URIKN) = "" Or SSSVal(URIKN) = 0 Then Exit Function
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
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_HINZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_HINZEIKB = RD_SSSMAIN_HINZEIKB(DE_INDEX)
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(DE_INDEX)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WRKDT(0) = RD_SSSMAIN_UDNDT(0)
		
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZEIKB) = 9 Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZCLKB) <> 1 Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(WL_HINZEIKB) = 1) Or (SSSVal(WL_HINZEIKB) = 9) Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_HINZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZEIKB) <> 2 And SSSVal(WL_HINZEIKB) <> 2 Then Exit Function
		
		'   売上計上では, 消費税の手入力は原則として認めない
		'   もし手入力が必要な場合は､ SZEKN.F01のように次行を有効にする
		'    if &UKBCD[CWK]=10 RETURN
		WL_ZKMUZEKN = 0
		'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB & SSS_WRKDT(0), BtrNormal)
		'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (DBSTAT <> 0) Or (DB_SYSTBB.ZEIRNKKB <> WL_ZEIRNKKB) Then Exit Function
		
		WL_ZEIRT = DB_SYSTBB.ZEIRT
		
		'【通販】及び【システムで諸口商品】時、算出処理回避
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'UPGRADE_WARNING: オブジェクト UZEKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ZKMUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZKMUZEKN_Derived = UZEKN
			Exit Function
		End If
		
		'======================================================================
		'   得意先の税区分と、商品の税区分の組み合わせにより、税抜・税込の
		'   判定を行う。
		'======================================================================
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_ZKMUZEKN = URIKN * WL_ZEIRT / (100 + WL_ZEIRT)
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKRPSKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_ZKMUZEKN = DCMFRC(WL_ZKMUZEKN, SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
		'UPGRADE_WARNING: オブジェクト ZKMUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZKMUZEKN_Derived = WL_ZKMUZEKN
	End Function
End Module