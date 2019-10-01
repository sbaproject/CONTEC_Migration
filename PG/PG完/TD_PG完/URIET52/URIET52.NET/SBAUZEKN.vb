Option Strict Off
Option Explicit On
Module SBAUZEKN_F51
	'
	' スロット名        : 伝票合計消費税金額(税抜)項目・画面項目スロット
	' ユニット名        : SBAURIKN.F01
	' 記述者            : Standard Library
	' 作成日付          : 1997/06/11
	' 使用プログラム名  : URIET01
	
	Dim WM_ZNKUZEKN(2) As Decimal
	Dim WM_ZKMUZEKN(2) As Decimal
	Dim WM_ZEIRT(2) As Decimal
	Dim WM_ZNKURIKN(2) As Decimal
	Dim WM_ZKMURIKN(2) As Decimal
	
	Function SBAUZEKN_Derived(ByVal UDNDT As Object, ByVal UZEKN As Object, ByVal ZNKURIKN As Object, ByRef PP As clsPP) As Object
		Dim NullSw, I As Short
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_SBAUZEKN As Decimal
		
		'UPGRADE_WARNING: オブジェクト SBAUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SBAUZEKN_Derived = 0
		
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZCLKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZCLKB = RD_SSSMAIN_TOKZCLKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TOKZEIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(WL_TOKZCLKB) = 0) Or (SSSVal(WL_TOKZCLKB) = 9) Or (SSSVal(WL_TOKZCLKB) = 3) Then Exit Function
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZEIKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(WL_TOKZEIKB) = 9 Then Exit Function
		
		For I = 0 To 2
			WM_ZNKUZEKN(I) = 0
			WM_ZNKURIKN(I) = 0
		Next I
		WL_SBAUZEKN = 0
		
		I = 0
		Do While I < PP.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(RD_SSSMAIN_HINID(I)) = "06") Then '【通販】及び【システムで諸口商品】時、算出処理回避
				If IsNumeric(RD_SSSMAIN_UZEKN(I)) Then
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WL_SBAUZEKN = WL_SBAUZEKN + RD_SSSMAIN_UZEKN(I)
				End If
				'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf SSSVal(WL_TOKZCLKB) = 2 Then 
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(I)
				'            If Not IsNull(WL_ZEIRNKKB) And IsNumeric(WL_ZEIRNKKB) Then
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(WL_ZEIRNKKB) <> "" And IsNumeric(WL_ZEIRNKKB) Then
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(WL_ZEIRNKKB) > 3 Or SSSVal(WL_ZEIRNKKB) < 1 Then WL_ZEIRNKKB = "1"
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_ZNKURIKN(I)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WM_ZNKURIKN(SSSVal(WL_ZEIRNKKB) - 1) = WM_ZNKURIKN(SSSVal(WL_ZEIRNKKB) - 1) + SSSVal(RD_SSSMAIN_ZNKURIKN(I))
				End If
			End If
			I = I + 1
		Loop 
		
		'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZCLKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Then '【通販】ポイント値引対応
			'UPGRADE_WARNING: オブジェクト SBAUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAUZEKN_Derived = WL_SBAUZEKN
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
				WM_ZNKUZEKN(I) = 0
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				WL_ZEIRNKKB = VB6.Format(I + 1, "0")
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB + SSS_WRKDT(0), BtrNormal)
				'UPGRADE_WARNING: オブジェクト WL_ZEIRNKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If (DBSTAT = 0) And (DB_SYSTBB.ZEIRNKKB = WL_ZEIRNKKB) Then
					If WM_ZNKURIKN(I) <> 0 Then WM_ZNKUZEKN(I) = WM_ZNKURIKN(I) * DB_SYSTBB.ZEIRT / 100
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKRPSKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(WL_TOKZRNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WM_ZNKUZEKN(I) = DCMFRC(WM_ZNKUZEKN(I), SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
					WL_SBAUZEKN = WL_SBAUZEKN + WM_ZNKUZEKN(I)
				End If
			Next I
			'UPGRADE_WARNING: オブジェクト SBAUZEKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAUZEKN_Derived = WL_SBAUZEKN
		End If
	End Function
End Module