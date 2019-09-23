Option Strict Off
Option Explicit On
Module UDNDT_F56
	'
	' スロット名        : 売上日付・画面項目スロット
	' ユニット名        : UDNDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/24
	' 使用プログラム名  : URIET53
	'
	'
	Dim NotFirst As Short
	
	Function UDNDT_Check(ByVal UDNDT As Object) As Object
		Dim Rtn As Short
		Dim wkTOKCD As String
		'
		''''UDNDT_Check = 0
		''''rtn = CHECK_DATE(UDNDT)
		''''If rtn Then
		''''    If UDNDT <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then
		''''        rtn = DSP_MsgBox(SSS_ERROR, "DATE", 1) '月次更新済みです。この日付では入力できません。
		''''        UDNDT_Check = -1
		''''    End If
		''''Else
		''''    rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
		''''    UDNDT_Check = -1
		''''End If
		'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDT_Check = 0
		Rtn = CHECK_DATE(UDNDT)
		If Rtn Then
			'月次仮締日チェック
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If UDNDT <= CNV_DATE(DB_SYSTBA.UKSMEDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '月次仮締日を過ぎています。
				'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNDT_Check = -1
				Exit Function
			End If
			'請求締日チェック
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
			Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If UDNDT <= CNV_DATE(DB_TOKMTA.TOKSMEDT) Then
					Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '登録された得意先の請求締日を過ぎています。
					'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					UDNDT_Check = -1
					Exit Function
				End If
			End If
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CNV_DATE(DB_UNYMTA.UNYDT) < UDNDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 3) '運用日以降は入力できません。
				'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNDT_Check = -1
				Exit Function
			Else
				'2013/07/24 START CHG FWEST)Koroyasu-連絡票№:HAN20130705-01
				'            Call FIXMTA_RClear
				'            Call DB_GetEq(DBN_FIXMTA, 1, "104", BtrNormal)
				'2008/09/11 START CHG FKS)HAYASHI-連絡票№:609
				'''            If Trim$(DB_FIXMTA.FIXVAL) = "9" Then
				'[返品登録]の場合のみチェック
				'            If Trim$(DB_FIXMTA.FIXVAL) = "9" And SSS_PrgId = "URIET54" Then
				If SSS_PrgId = "URIET54" Then
					'2008/09/11 E.N.D CHG FKS)HAYASHI-連絡票№:609
					'2013/07/24 E.N.D CHG FWEST)Koroyasu-連絡票№:HAN20130705-01
					'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If UDNDT < Get_STTTouAcedt(CShort(Left(DB_UNYMTA.UNYDT, 4)), CShort(Mid(DB_UNYMTA.UNYDT, 5, 2))) Then
						Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 4) '前月度の日付は入力できません。
						'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						UDNDT_Check = -1
						Exit Function
					End If
				End If
			End If
			'2007/11/01 FKS)minamoto ADD START
			'2007/11/26 FKS)minamoto CHG START
			'If UDNDT < CNV_DATE(DB_JDNTHA.JDNDT) Then
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If UDNDT < CNV_DATE(DB_JDNTHA.REGDT) Then
				'2007/11/26 FKS)minamoto CHG END
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 6) '受注日より前の日の為、入力できません。
				'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNDT_Check = -1
				Exit Function
			End If
			'2007/11/01 FKS)minamoto ADD END
			'ADD START FKS)INABA 2010/06/03 **************************************************************
			'連絡票№799
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Left(UDNDT, 7) < Left(CNV_DATE(DB_JDNTHA.JDNDT), 7) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 8) '売上月が受注月以前の為入力できません
				'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNDT_Check = -1
				Exit Function
			End If
			'ADD  END  FKS)INABA 2010/06/03 **************************************************************
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDT_Check = -1
			Exit Function
		End If
		
	End Function
	
	Function UDNDT_InitVal(ByVal UDNDT As Object) As Object
		'
		If NotFirst = False Or Not IsDate(UDNDT) Then
			NotFirst = True
			'UPGRADE_WARNING: オブジェクト UDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDT_InitVal = DB_UNYMTA.UNYDT '本日の日付。
			'２行追加 1998/05/23 月次更新済みチェック
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf UDNDT <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then 
			'UPGRADE_WARNING: オブジェクト UDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDT_InitVal = DB_UNYMTA.UNYDT
		Else
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDT_InitVal = UDNDT '前の伝票の日付。
		End If
	End Function
	
	Function UDNDT_Skip(ByRef CT_UDNDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: オブジェクト CT_UDNDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/09/19 CHG START
        'CT_UDNDT.SelStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        DirectCast(CT_UDNDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        '2019/09/19 CHG E N D
        'UPGRADE_WARNING: オブジェクト UDNDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        UDNDT_Skip = False
	End Function
	
	Function UDNDT_Slist(ByVal UDNDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = UDNDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト UDNDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDT_Slist = Set_date.Value
	End Function
End Module