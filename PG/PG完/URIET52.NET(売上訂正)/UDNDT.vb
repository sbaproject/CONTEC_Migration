Option Strict Off
Option Explicit On
Module UDNDT_F53
	'
	' スロット名        : 売上日付・画面項目スロット
	' ユニット名        : UDNDT.F53
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	'
	'
	Dim NotFirst As Boolean
	
	Function UDNDT_Check(ByVal UDNDT As Object) As Object
		Dim Rtn As Short
		Dim wkTOKCD As String
		'
		'    If SetFirst = True Then
		'        SetFirst = False
		'        Exit Function
		'    End If
		
		'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDT_Check = 0
		Rtn = CHECK_DATE(UDNDT)
		If Rtn Then
			'UPGRADE_WARNING: オブジェクト UDNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If UDNDT <= CNV_DATE(DB_SYSTBA.UKSMEDT) Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '月次仮締日を過ぎています。
				'UPGRADE_WARNING: オブジェクト UDNDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNDT_Check = -1
				Exit Function
			End If
            '
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/06/14 CHG START
            'wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
            'Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
            wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_NullReplace(DB_TOKMTA.TOKCD, Space(10))) - Len(RD_SSSMAIN_TOKCD(-1)))
            '20190726 CHG START
            'Call TOKMTA_GetFirstRecByTOKCD(wkTOKCD)
            Dim sqlWhereStr As String = ""
            sqlWhereStr = " WHERE TOKCD = '" & wkTOKCD & "'"
            Call GetRowsCommon("TOKMTA", sqlWhereStr)
            '20190726 CHG END
            '2019/06/14 CHG END

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
			End If
			'2007/11/15 FKS)minamoto ADD START
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
			'2007/11/15 FKS)minamoto ADD END
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
		End If
	End Function
	
	Function UDNDT_InitVal(ByVal UDNDT As Object) As Object
		'
		If NotFirst = False Or Not IsDate(UDNDT) Then
			NotFirst = True
			'UPGRADE_WARNING: オブジェクト UDNDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDT_InitVal = DB_UNYMTA.UNYDT '運用マスタの運用日付。
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
        '2019/06/04 CHG START
        'CT_UDNDT.SelStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        DirectCast(CT_UDNDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        '2019/06/04 CHG END
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