Option Strict Off
Option Explicit On
Module SBAUZKKN_F51
	'
	' スロット名        : 伝票合計消費税金額(税込)項目・画面項目スロット
	' ユニット名        : SBAURIKN.F01
	' 記述者            : Standard Library
	' 作成日付          : 1997/06/11
	' 使用プログラム名  : URIET01
	
	Dim WM_ZNKUZEKN(2) As Decimal
	Dim WM_ZKMUZEKN(2) As Decimal
	Dim WM_ZEIRT(2) As Decimal
	Dim WM_ZNKURIKN(2) As Decimal
	Dim WM_ZKMURIKN(2) As Decimal
	
	Function SBAUZKKN_Derived(ByVal UDNDT As Object, ByVal ZKMUZEKN As Object, ByVal ZNKURIKN As Object, ByVal ZKMURIKN As Object, ByRef PP As clsPP) As Object
		Dim NullSw, I As Short
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_SBAUZKKN As Decimal
		
		'UPGRADE_WARNING: オブジェクト SBAUZKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SBAUZKKN_Derived = 0
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZCLKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZCLKB = RD_SSSMAIN_TOKZCLKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(WL_TOKZCLKB) = 0) Or (SSSVal(WL_TOKZCLKB) = 9) Or (SSSVal(WL_TOKZCLKB) = 3) Then Exit Function
		'UPGRADE_WARNING: オブジェクト WL_TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB = 9) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZEIKB = 9) Then Exit Function
		
		For I = 0 To 2
			WM_ZKMUZEKN(I) = 0
			WM_ZKMURIKN(I) = 0
		Next I
		WL_SBAUZKKN = 0
		
		I = 0
		Do While I < PP.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(RD_SSSMAIN_HINID(I)) = "06") Then '【通販】及び【システムで諸口商品】時、算出処理回避
				If IsNumeric(RD_SSSMAIN_UZEKN(I)) Then
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKMUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WL_SBAUZKKN = WL_SBAUZKKN + RD_SSSMAIN_ZKMUZEKN(I)
				End If
				'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf SSSVal(WL_TOKZCLKB) = 2 Then 
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(I)
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(WL_ZEIRNKKB) <> "" And IsNumeric(WL_ZEIRNKKB) Then
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(WL_ZEIRNKKB) > 3 Or SSSVal(WL_ZEIRNKKB) < 1 Then WL_ZEIRNKKB = "1"
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_ZKMURIKN(I)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WM_ZKMURIKN(SSSVal(WL_ZEIRNKKB) - 1) = WM_ZKMURIKN(SSSVal(WL_ZEIRNKKB) - 1) + SSSVal(RD_SSSMAIN_ZKMURIKN(I))
				End If
			End If
			I = I + 1
		Loop 
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Then '【通販】ポイント値引対応
			'UPGRADE_WARNING: オブジェクト SBAUZKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAUZKKN_Derived = WL_SBAUZKKN
			'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf SSSVal(WL_TOKZCLKB) = 2 Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WL_TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WL_TOKRPSKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TOKRPSKB = RD_SSSMAIN_TOKRPSKB(0)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WL_TOKZRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TOKZRNKB = RD_SSSMAIN_TOKZRNKB(0)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSS_WRKDT(0) = RD_SSSMAIN_UDNDT(0)
			
			For I = 0 To 2
				WM_ZKMUZEKN(I) = 0
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_ZEIRNKKB = VB6.Format(I + 1, "0")
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB & SSS_WRKDT(0), BtrNormal)
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If (DBSTAT = 0) And (DB_SYSTBB.ZEIRNKKB = WL_ZEIRNKKB) Then
					If WM_ZKMURIKN(I) <> 0 Then WM_ZKMUZEKN(I) = WM_ZKMURIKN(I) * DB_SYSTBB.ZEIRT / (100 + DB_SYSTBB.ZEIRT)
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKRPSKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZRNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WM_ZKMUZEKN(I) = DCMFRC(WM_ZKMUZEKN(I), SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
					WL_SBAUZKKN = WL_SBAUZKKN + WM_ZKMUZEKN(I)
				End If
			Next I
			'UPGRADE_WARNING: オブジェクト SBAUZKKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAUZKKN_Derived = WL_SBAUZKKN
		End If
	End Function
End Module