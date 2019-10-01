Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(134 + 26 + 0 + 1) As clsCP
	Public CL_SSSMAIN(134) As Short
    Public CQ_SSSMAIN(30) As String

    '20190826 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf

    End Structure
    '20190826 ADD END

    Function AE_AppendC_SSSMAIN(ByVal pm_ExMode As Short, Optional ByVal pm_Current As Object = Nothing) As Short 'Generated.
		If PP_SSSMAIN.Mode = Cn_Mode4 And PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "AppendC") Then AE_AppendC_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		PP_SSSMAIN.ChOprtMode = Cn_Mode1
		'UPGRADE_WARNING: オブジェクト SSSMAIN_AppendC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSMAIN_AppendC() Then
			Call AE_ModeChange_SSSMAIN(Cn_Mode1)
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If IsNothing(pm_Current) Then
				Call AE_InitValAll_SSSMAIN()
			Else
				wk_Int = AE_Current_SSSMAIN()
			End If
			Call AE_ClearInitValStatus_SSSMAIN()
			AE_AppendC_SSSMAIN = Cn_CuInit
		Else
			Call AE_ModeChange_SSSMAIN(pm_ExMode)
			AE_AppendC_SSSMAIN = Cn_CuCurrent
		End If
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Sub AE_Check_SSSMAIN_DSPORD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 7 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEICDA(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 5 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190828 CHG START
            'If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = String.Format(CC_NewVal, CP_SSSMAIN(wk_Px).FormatChr)
            '20190828 CHG END
            If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                If IsDBNull(CC_NewVal) Then
                    If pm_MoveCursor Then
                        If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                    End If
                    Exit Sub
                    'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then
                    If pm_MoveCursor Then
                        If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                    End If
                    Exit Sub
                End If
            End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190827 CHG START
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn And (IsDBNull(CC_NewVal) = False AndAlso IsDBNull(.CuVal) = False AndAlso CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
                '20190827 CHG END
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(wk_Px), AE_Controls(PP_SSSMAIN.CtB + wk_Tx))
                    End If
                End If
                Exit Sub
            End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SaveXV = .ExVal
            PP_SSSMAIN.SaveExStatus = .ExStatus
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ExVal = .CuVal
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SaveCV = .CuVal
            .ExStatus = .StatusF
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            If IsDBNull(CC_NewVal) Then
                'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CC_NewVal = Space(.MaxLength)
                'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then
                'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
            End If
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: オブジェクト MEICDA_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = MEICDA_CheckC(CC_NewVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
            Else
                'UPGRADE_WARNING: オブジェクト MEICDA_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = MEICDA_CheckC(CC_NewVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
                End If
                If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
                    'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ExVal = PP_SSSMAIN.SaveXV
                    .ExStatus = PP_SSSMAIN.SaveExStatus
                    Call AE_Later_SSSMAIN()
                    If pm_MoveCursor Then
                        If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                    End If
                Else
                    If pm_Status <> 0 Then .StatusC = pm_Status
                    If pm_Status <> 0 Then .StatusF = pm_Status
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                    If Not PP_SSSMAIN.RecalcMode Then
                        PP_SSSMAIN.DerivedOrigin = "BD_MEICDA"
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).ExVal = CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).CuVal 'MEICDB
                        CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).ExStatus = CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).StatusC
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).ExVal = CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).CuVal 'MEINMA
                        CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).ExStatus = CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).StatusC
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).ExVal = CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).CuVal 'MEINMB
                        CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).ExStatus = CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).StatusC
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).ExVal = CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).CuVal 'MEINMC
                        CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).ExStatus = CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).StatusC
                        If Not wk_Equal Or ex_CheckRtnCode <> 0 Then Call AE_Derived_SSSMAIN_bd_MEICDB(PP_SSSMAIN.De2)
                        Call AE_Derived_SSSMAIN_bd_MEINMA(PP_SSSMAIN.De2)
                        Call AE_Derived_SSSMAIN_bd_MEINMB(PP_SSSMAIN.De2)
                        Call AE_Derived_SSSMAIN_bd_MEINMC(PP_SSSMAIN.De2)
                        'UPGRADE_WARNING: オブジェクト AE_RelCheck_SSSMAIN_MFIL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        wk_Var = AE_RelCheck_SSSMAIN_MFIL(RC_ErrorC)
                        If .StatusC >= Cn_Status3 And .StatusC <= Cn_Status5 Then
                            Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, False)
                        Else
                            If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
                                Call AE_Later_SSSMAIN()
                                If pm_MoveCursor Then
                                    If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                                End If
                            Else
                                If pm_MoveCursor Then
                                    If AE_CursorToError_SSSMAIN() = False Then
                                        Call AE_Later_SSSMAIN()
                                        If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
                Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
                If AE_ErrorToInteger(Ck_Error) >= 0 Then
                    PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
                    'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub


    '20190826 ADD START
    Function MEICDA_CheckC(ByRef MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short
        Dim wkMEICDA As String
        Dim strSql As String
        Dim lngCount As Integer
        '
        'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEICDA_CheckC = 0
        ' 未入力の場合には, エラーをかけずに名称等をクリアする
        'Call MEIMTA_RClear
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            MEICDA_CheckC = -1
        Else
            'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190827 CHG START
            'wkMEICDA = MEICDA & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(MEICDA)))
            If DB_MEIMTA.MEICDA Is Nothing Then
                wkMEICDA = MEICDA & Space(20 - Len(Trim(MEICDA)))
            Else
                wkMEICDA = MEICDA & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(MEICDA)))
            End If
            '20190827 CHG END

            'コード１で件数ﾁｪｯｸ
            strSql = ""
            '20190827 CHG START
            'strSql = strSql & "Select Count(*) From MEIMTA"
            strSql = strSql & "Select Count(*) cnt From MEIMTA"
            '20190827 CHG END
            strSql = strSql & " Where DATKB = '1'"
            'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "   And KEYCD  = " & "'" & FRKEYCD & "'"
            strSql = strSql & "   And MEICDA = " & "'" & wkMEICDA & "'"

            '20190827 CHG START
            'Call DB_GetSQL2(DBN_MEIMTA, strSql)
            'lngCount = DB_ExtNum.ExtNum(0)
            Dim dt As DataTable = DB_GetTable(strSql)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                lngCount = 0
            Else
                lngCount = DB_NullReplace(dt.Rows(0)("cnt"), 0)
            End If

            '20190827 CHG END
            If lngCount >= 2 Then '件数が２件以上の時は何もしない
                Exit Function
            End If

            '件数が１件の時
            'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '20190828 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & wkMEICDA & "     ", BtrNormal)
            Dim pWhere As String = ""
            pWhere = "WHERE KEYCD = '" & FRKEYCD & "'"
            pWhere = pWhere & "AND MEICDA = '" & wkMEICDA & "'"
            pWhere = pWhere & "AND MEICDB = '     '"
            GetRowsCommon(DBN_MEIMTA, pWhere)
            '20190828 CHG START

            If DBSTAT = 0 Then
                If DB_MEIMTA.DATKB = "9" Then
                    'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(DE_INDEX, "削除")

                    '20190218
                    'Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。

                    'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    MEICDA_CheckC = 1
                Else
                    '更新データ
                    'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(DE_INDEX, "更新")
                End If
                'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromMfil(DE_INDEX)
            Else
                ''''''''''''Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 新規レコードです。
                ''''''''''''MEICDA_CheckC = -1
                ''''''''''''Call MEIMTA_RClear
                'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call DP_SSSMAIN_UPDKB(DE_INDEX, "追加")
            End If
        End If

    End Function


    Function MEICDB_CheckC(ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
        ''''2006.07.24不要
        Dim Rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト MEICDB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEICDB_CheckC = 0

        'UPGRADE_WARNING: オブジェクト MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDB) = "" Then
            '        MEICDB_CheckC = -1
        Else
            'UPGRADE_WARNING: オブジェクト MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
            If DBSTAT = 0 Then
                If DB_MEIMTA.DATKB = "9" Then
                    'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(DE_INDEX, "削除")

                    '20190218
                    'Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。

                    'UPGRADE_WARNING: オブジェクト MEICDB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    MEICDB_CheckC = 1
                Else
                    '更新
                    'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(DE_INDEX, "更新")
                End If
                'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromMfil(DE_INDEX)
            Else
                '新規
                'Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
                'MEICDB_CheckC = -1
            End If
        End If

    End Function
    '20190826 ADD END

    Sub AE_Check_SSSMAIN_MEICDB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 6 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190827 CHG START
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn And (IsDBNull(CC_NewVal) = False AndAlso IsDBNull(.CuVal) = False AndAlso CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
                '20190827 CHG END
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(wk_Px), AE_Controls(PP_SSSMAIN.CtB + wk_Tx))
                    End If
                End If
                Exit Sub
            End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
			If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト MEICDB_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEICDB_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
			Else
				'UPGRADE_WARNING: オブジェクト MEICDB_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEICDB_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						'UPGRADE_WARNING: オブジェクト AE_RelCheck_SSSMAIN_MFIL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						wk_Var = AE_RelCheck_SSSMAIN_MFIL(RC_ErrorC)
						If .StatusC >= Cn_Status3 And .StatusC <= Cn_Status5 Then
							Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, False)
						Else
							If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
								Call AE_Later_SSSMAIN()
								If pm_MoveCursor Then
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							Else
								If pm_MoveCursor Then
									If AE_CursorToError_SSSMAIN() = False Then
										Call AE_Later_SSSMAIN()
										If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
									End If
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEIKBA(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 14 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then

                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
			'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEIKBB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 15 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEIKBC(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 16 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEINMA(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 8 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト MEINMA_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMA_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), "", PP_SSSMAIN.De2)
			Else
				'UPGRADE_WARNING: オブジェクト MEINMA_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMA_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).ExVal), PP_SSSMAIN.De2)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEINMB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 9 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト MEINMB_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMB_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), "", PP_SSSMAIN.De2)
			Else
				'UPGRADE_WARNING: オブジェクト MEINMB_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMB_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).ExVal), PP_SSSMAIN.De2)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEINMC(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 10 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト MEINMC_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMC_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), "", PP_SSSMAIN.De2)
			Else
				'UPGRADE_WARNING: オブジェクト MEINMC_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = MEINMC_Check(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).ExVal), PP_SSSMAIN.De2)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEISUA(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 11 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv1_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEISUB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 12 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv1_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_MEISUC(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 13 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv1_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_UPDKB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim wk_Tx As Short
		Dim wk_Px As Short
		wk_Px = 4 + 26 * PP_SSSMAIN.De
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(wk_Px)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
			If PP_SSSMAIN.De = PP_SSSMAIN.LastDe And AE_GetInOutMode(.InOutMode, PP_SSSMAIN.Mode) = Cn_InOutMode3 And PP_SSSMAIN.ActiveDe < 0 And Not PP_SSSMAIN.CheckErrNglct And Not PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				If IsDbNull(CC_NewVal) Then
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
					'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ElseIf RTrim(CC_NewVal) = RTrim(.IniStr) Then 
					If pm_MoveCursor Then
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) = False Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
					Exit Sub
				End If
			End If
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(wk_Px), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				Call AE_CheckSub2_SSSMAIN(wk_Tx, wk_Px, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_FRKEYCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(0)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(0), CC_NewVal)
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(0).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190827 CHG START
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn And (IsDBNull(CC_NewVal) = False AndAlso IsDBNull(.CuVal) = False AndAlso CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
                '20190827 CHG END
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(0), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, 0, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), AE_Controls(PP_SSSMAIN.CtB + 0))
                    End If
                End If
                Exit Sub
            End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = FRKEYCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal), "")
			Else
				'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = FRKEYCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).ExVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(0), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 0, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(0))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
					If Not PP_SSSMAIN.RecalcMode Then
						PP_SSSMAIN.DerivedOrigin = "HD_FRKEYCD"
						'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						CP_SSSMAIN(1).ExVal = CP_SSSMAIN(1).CuVal 'FRMEINM
						CP_SSSMAIN(1).ExStatus = CP_SSSMAIN(1).StatusC
						If Not wk_Equal Or ex_CheckRtnCode <> 0 Then Call AE_Derived_SSSMAIN_hd_FRMEINM()
                        'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190827 CHG START
                        'If CC_NewVal = PP_SSSMAIN.SaveCV Then
                        If IsDBNull(CC_NewVal) = False _
                            AndAlso IsDBNull(PP_SSSMAIN.SaveCV) = False _
                            AndAlso CC_NewVal = PP_SSSMAIN.SaveCV Then
                            '20190827 CHG END
                            PP_SSSMAIN.DerivedOrigin = "HD_FRKEYCD"
                            Call AE_RecalcBd_SSSMAIN() : wk_RecalcSw = True
                        ElseIf AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) Then
                        Else
                            PP_SSSMAIN.DerivedOrigin = "HD_FRKEYCD"
							Call AE_RecalcBd_SSSMAIN() : wk_RecalcSw = True
						End If
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(0))
				Call AE_CheckSub2_SSSMAIN(0, 0, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_FRMEINM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(1)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(1), CC_NewVal)
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(1).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190827 CHG START
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn And (IsDBNull(CC_NewVal) = False AndAlso IsDBNull(.CuVal) = False AndAlso CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
                '20190827 CHG END
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(1), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, 1, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), AE_Controls(PP_SSSMAIN.CtB + 1))
                    End If
                End If
                Exit Sub
            End If
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト FRMEINM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = FRMEINM_CheckC(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: オブジェクト FRMEINM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = FRMEINM_CheckC(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(1), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 1, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(1))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(1))
				Call AE_CheckSub2_SSSMAIN(1, 1, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_OPEID(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(2)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(2), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END

            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(2), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 2, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(2))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(2))
				Call AE_CheckSub2_SSSMAIN(2, 2, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_OPENM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(3)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(3), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ExVal = .CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
            If Not PP_SSSMAIN.RecalcMode Then
                '20190826 CHG START
                ''UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                '            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '20190826 CHG END
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(3), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 3, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(3))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3))
					If Not PP_SSSMAIN.RecalcMode Then
						If PP_SSSMAIN.ErrorC = 0 Or wk_RecalcSw = False Then
							Call AE_Later_SSSMAIN()
							If pm_MoveCursor Then
								If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
							End If
						Else
							If pm_MoveCursor Then
								If AE_CursorToError_SSSMAIN() = False Then
									Call AE_Later_SSSMAIN()
									If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
								End If
							End If
						End If
					End If
				End If
			Else
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(3))
				Call AE_CheckSub2_SSSMAIN(3, 3, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_CheckSub2_SSSMAIN(ByVal pm_Tx As Short, ByVal pm_Px As Short, ByVal pm_Sw As Boolean) 'Generated.
		Dim wk_SS As Integer
		If pm_Sw Then
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveCV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(pm_Px).CuVal = PP_SSSMAIN.SaveCV
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SaveXV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(pm_Px).ExVal = PP_SSSMAIN.SaveXV
			CP_SSSMAIN(pm_Px).ExStatus = PP_SSSMAIN.SaveExStatus
			CP_SSSMAIN(pm_Px).StatusC = Cn_Status2
			If CP_SSSMAIN(pm_Px).TypeA = Cn_NormalOrV Or CP_SSSMAIN(pm_Px).TypeA = Cn_InputOnly Then Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(pm_Px), CL_SSSMAIN(pm_Px))
		End If
		If pm_Tx >= 0 Then
			If CP_SSSMAIN(pm_Px).TypeA = Cn_NormalOrV Then
				If PP_SSSMAIN.SelValid And CP_SSSMAIN(pm_Px).FixedFormat <> 1 Then
                    '20190826 CHG START
                    ''UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = 0
                    ''UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx))
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(0, Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx)))
                    '20190826 CHG END

                Else
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'wk_SS = AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart
                    wk_SS = DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart
                    '20190826 CHG END

                    Do While wk_SS > 0
						wk_SS = wk_SS - 1
						If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                            '20190826 CHG START
                            ''UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190826 CHG END
                            Exit Sub
                        End If
					Loop
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                    '20190826 CHG END
                End If
            End If
		End If
	End Sub
	
	Sub AE_ClearDe_SSSMAIN() 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.RecalcMode Then Exit Sub
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValBdDe_SSSMAIN(-2, False, Cn_Status0) ', PP_SSSMAIN.De
		PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_ClearDe2_SSSMAIN() 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.RecalcMode Then Exit Sub
		If PP_SSSMAIN.ActiveDe >= 0 Then
			wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "ClearDe")
			Exit Sub
		End If
		If AE_ClearedDe_SSSMAIN(-1) <> PP_SSSMAIN.ActiveDe Then
			PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
		End If
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		If PP_SSSMAIN.ActiveDe >= 0 Then
			Call AE_DeUp_SSSMAIN(PP_SSSMAIN.ActiveDe)
			If PP_SSSMAIN.ActiveDe < PP_SSSMAIN.De Then
				PP_SSSMAIN.De = PP_SSSMAIN.De - 1
				PP_SSSMAIN.De2 = PP_SSSMAIN.De
			End If
		End If
		PP_SSSMAIN.UnDoDeOp = 1
		PP_SSSMAIN.UnDoDeNo = PP_SSSMAIN.De
		Call AE_DeSave_SSSMAIN(PP_SSSMAIN.De)
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValBdDe_SSSMAIN(-2, True, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF) ', PP_SSSMAIN.De
		PP_SSSMAIN.MaskMode = False
		If PP_SSSMAIN.De + 1 = PP_SSSMAIN.LastDe Then
			PP_SSSMAIN.ActiveDe = -1
			If PP_SSSMAIN.LastDe > PP_SSSMAIN.LastReadDe Then PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe - 1
			PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
			wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx)
		ElseIf PP_SSSMAIN.De < PP_SSSMAIN.LastReadDe Then 
			PP_SSSMAIN.ActiveDe = -1
		Else
			PP_SSSMAIN.ActiveDe = PP_SSSMAIN.De
		End If
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
		Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Function AE_ClearedDe_SSSMAIN(ByVal pm_ExceptionDe As Short) As Short 'Generated.
		Dim Wk_De As Short
		Wk_De = PP_SSSMAIN.LastReadDe
		Do While Wk_De < PP_SSSMAIN.LastDe
			If AE_IsClearedDe_SSSMAIN(Wk_De) And Wk_De <> pm_ExceptionDe Then
				AE_ClearedDe_SSSMAIN = Wk_De
				Exit Function
			End If
			Wk_De = Wk_De + 1
		Loop 
		AE_ClearedDe_SSSMAIN = -1
	End Function
	
	Sub AE_ClearInitValStatus_SSSMAIN() 'Generated.
		PP_SSSMAIN.InitValStatus = PP_SSSMAIN.Mode
		Dim wk_Px As Short
		wk_Px = 0
		Do While wk_Px < 134
			CP_SSSMAIN(wk_Px).Modified = PP_SSSMAIN.Mode
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_ClearItm_SSSMAIN(ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_ClearedVal As Object
		Dim Wk_De As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Sub
		If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= 69 Then Exit Sub
		PP_SSSMAIN.MaskMode = True
		If PP_SSSMAIN.Tx < 4 Then
			Call AE_InitValHd_SSSMAIN(PP_SSSMAIN.Tx, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF)
		ElseIf PP_SSSMAIN.Tx < 69 Then 
			Call AE_InitValBdDe_SSSMAIN(PP_SSSMAIN.Px, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF) ', PP_SSSMAIN.De
		ElseIf PP_SSSMAIN.Tx < 69 Then 
		ElseIf PP_SSSMAIN.Tx < 69 Then 
		End If
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_ClearedVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_ClearedVal = CP_SSSMAIN(PP_SSSMAIN.Px).CuVal
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(PP_SSSMAIN.Px).CuVal = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
		CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
		CP_SSSMAIN(PP_SSSMAIN.Px).StatusF = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
        PP_SSSMAIN.MaskMode = False
        '20190826 CHG START
        ''UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
        '      'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      AE_StatusBar(PP_SSSMAIN.ScX) = ""
        AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
        AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
        '20190826 CHG END

        If PP_SSSMAIN.InitValStatus >= Cn_Mode4 Then Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px))
		If PP_SSSMAIN.Tx >= 4 And PP_SSSMAIN.Tx < 69 Then
			If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
				PP_SSSMAIN.UnDoDeOp = 0
				If PP_SSSMAIN.De + 1 = PP_SSSMAIN.LastDe Then
					PP_SSSMAIN.ActiveDe = -1
					If PP_SSSMAIN.LastDe > PP_SSSMAIN.LastReadDe Then PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe - 1
				ElseIf PP_SSSMAIN.De = PP_SSSMAIN.LastDe Then 
					PP_SSSMAIN.ActiveDe = -1
				ElseIf PP_SSSMAIN.De < PP_SSSMAIN.LastReadDe Then 
					PP_SSSMAIN.ActiveDe = -1
				Else
					PP_SSSMAIN.ActiveDe = PP_SSSMAIN.De
				End If
				Wk_De = AE_ClearedDe_SSSMAIN(PP_SSSMAIN.De)
				If Wk_De >= 0 Then
					Call AE_DeUp_SSSMAIN(Wk_De)
					If Wk_De < PP_SSSMAIN.De Then
						PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
						wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx)
						If PP_SSSMAIN.ActiveDe > Wk_De Then PP_SSSMAIN.ActiveDe = PP_SSSMAIN.ActiveDe - 1
						Call AE_ScrlMax(PP_SSSMAIN)
						Exit Sub
					End If
				End If
				Call AE_ScrlMax(PP_SSSMAIN)
			End If
		End If
		Call AE_SetCheck_SSSMAIN(wk_ClearedVal, Cn_Status8, pm_HandIn)
	End Sub
	
	Function AE_CompleteCheck_SSSMAIN(ByVal pm_HeadCheck As Boolean) As Short 'Generated.
		Static Wk_De As Short
		Static wk_Px As Short
		Static wk_IncompletionC As Short
		Static wk_IncompletionC2 As Short
		wk_IncompletionC = 0
		wk_IncompletionC2 = 0
		PP_SSSMAIN.InCompletePx = -1
		Call AE_CompleteCheckSub_SSSMAIN(0, PP_SSSMAIN.BodyPx, wk_IncompletionC, wk_IncompletionC2) '0: HeadPx
		If pm_HeadCheck Then
			If wk_IncompletionC2 > 0 Then
				wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "HeadCompleteC")
			End If
			AE_CompleteCheck_SSSMAIN = wk_IncompletionC2
			Exit Function
		End If
		Wk_De = 0
		Do While Wk_De < PP_SSSMAIN.LastDe And PP_SSSMAIN.InCompletePx = -1
			wk_Px = 4 + 26 * Wk_De
			Call AE_CompleteCheckSub_SSSMAIN(wk_Px, wk_Px + 26, wk_IncompletionC, wk_IncompletionC2)
			Wk_De = Wk_De + 1
		Loop 
		If wk_IncompletionC > 0 Then
			wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "CompleteC")
		End If
		AE_CompleteCheck_SSSMAIN = wk_IncompletionC
	End Function
	
	Private Sub AE_CompleteCheckSub_SSSMAIN(ByVal pm_Px1 As Short, ByVal pm_Px2 As Short, ByRef pm_IncompletionC As Short, ByRef pm_IncompletionC2 As Short) 'Generated.
		Dim wk_Px As Short
		wk_Px = pm_Px1
		Dim fl_NullZero As Boolean
		Do While wk_Px < pm_Px2
			If CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_Px).TypeA = Cn_CheckBox Then
			ElseIf CP_SSSMAIN(wk_Px).StatusC <= Cn_Status5 Then 
				pm_IncompletionC = pm_IncompletionC + 1
				If wk_Px <> PP_SSSMAIN.Px Then pm_IncompletionC2 = pm_IncompletionC2 + 1
				If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
			Else
				fl_NullZero = AE_IsNullZero(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
				If AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) Mod 2 = 1 Then
					'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
					If (Not fl_NullZero And IsDbNull(CP_SSSMAIN(wk_Px).CuVal)) Or (fl_NullZero And AE_IsNull_SSSMAIN(CP_SSSMAIN(wk_Px).CuVal)) Then
						pm_IncompletionC = pm_IncompletionC + 1
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then pm_IncompletionC2 = pm_IncompletionC2 + 1 : PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
						'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ElseIf Left(CP_SSSMAIN(wk_Px).CuVal, 1) = Space(1) And CP_SSSMAIN(wk_Px).Alignment <> 1 And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
						pm_IncompletionC = pm_IncompletionC + 1
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then pm_IncompletionC2 = pm_IncompletionC2 + 1 : PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
						'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ElseIf Right(CP_SSSMAIN(wk_Px).CuVal, 1) = Space(1) And CP_SSSMAIN(wk_Px).Alignment = 1 And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
						pm_IncompletionC = pm_IncompletionC + 1
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then pm_IncompletionC2 = pm_IncompletionC2 + 1 : PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
					End If
				End If
			End If
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_CopyCp_SSSMAIN(ByVal pm_Px As Object, ByVal pm_PxBase As Object) 'Generated.
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).InOutMode = CP_SSSMAIN(pm_PxBase).InOutMode
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).MaxLength = CP_SSSMAIN(pm_PxBase).MaxLength
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).FormatChr = CP_SSSMAIN(pm_PxBase).FormatChr
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).AutoEnter = CP_SSSMAIN(pm_PxBase).AutoEnter
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).Alignment = CP_SSSMAIN(pm_PxBase).Alignment
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).KeyInOkClass = CP_SSSMAIN(pm_PxBase).KeyInOkClass
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).FixedFormat = CP_SSSMAIN(pm_PxBase).FixedFormat
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).BlockNo = CP_SSSMAIN(pm_PxBase).BlockNo
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).FormatClass = CP_SSSMAIN(pm_PxBase).FormatClass
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).CIn = CP_SSSMAIN(pm_PxBase).CIn
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).TabTab = CP_SSSMAIN(pm_PxBase).TabTab
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_PxBase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).TypeA = CP_SSSMAIN(pm_PxBase).TypeA
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).CpPx = pm_Px
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).StatusC = Cn_Status0
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).StatusF = Cn_Status0
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).ExStatus = Cn_Status0
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).ExVal = System.DBNull.Value
		'UPGRADE_WARNING: オブジェクト pm_Px の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(pm_Px).CheckRtnCode = 0
	End Sub
	
	Function AE_CursorCheck_SSSMAIN(ByVal pm_TypeA As Short, ByVal pm_Tx As Short) As Boolean 'Generated.
		If pm_Tx = -2 Then
			AE_CursorCheck_SSSMAIN = True
		ElseIf pm_TypeA = Cn_OutputOnly Or pm_TypeA = Cn_CheckBox Or pm_TypeA = Cn_OptionButtonH Or pm_TypeA = Cn_OptionButtonC Then 
			AE_CursorCheck_SSSMAIN = False
		ElseIf AE_Controls(PP_SSSMAIN.CtB + pm_Tx).TabStop And AE_Controls(PP_SSSMAIN.CtB + pm_Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + pm_Tx).Visible Then 
			AE_CursorCheck_SSSMAIN = True
		Else
			AE_CursorCheck_SSSMAIN = False
		End If
	End Function
	
	Sub AE_CursorCurrent_SSSMAIN() 'Generated.
		If PP_SSSMAIN.CursorSet = True Then Exit Sub
		If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 69 Then
			If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Then
				Call AE_CursorRestSub_SSSMAIN(PP_SSSMAIN.Tx)
				Exit Sub
			End If
		End If
		Call AE_CursorInit_SSSMAIN()
	End Sub
	
	Function AE_CursorDown_SSSMAIN(ByVal pm_Tx As Short, Optional ByVal pm_Int As Object = Nothing) As Boolean 'Generated.
		Dim wk_Tx As Short
		Dim wk_ExTopDe As Short
		Dim wk_DeC As Short
		wk_DeC = 0 : If PP_SSSMAIN.ActiveDe >= 0 Or Not AE_GetDeApendable(PP_SSSMAIN) Then wk_DeC = 1
		wk_Tx = pm_Tx
		Do While wk_Tx < 69
			If wk_Tx < 3 Or wk_Tx >= 69 Then
				wk_Tx = wk_Tx + 1
			ElseIf wk_Tx = 3 Then 
				If AE_CursorInOutCheck_SSSMAIN(wk_Tx, 1) >= 0 Then
					Do 
						wk_Tx = wk_Tx + 1
						If ((wk_Tx - 4) \ 13) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then Exit Do
						If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
							Call AE_CursorMove_SSSMAIN(wk_Tx)
							AE_CursorDown_SSSMAIN = True
							Exit Function
						End If
						If wk_Tx = PP_SSSMAIN.NrBodyTx - 1 Then
							If PP_SSSMAIN.TopDe < 4 - PP_SSSMAIN.MaxDspC Then
								wk_ExTopDe = PP_SSSMAIN.TopDe
								Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
								If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then wk_Tx = wk_Tx - 13
							End If
						End If
					Loop Until wk_Tx >= PP_SSSMAIN.NrBodyTx - 1
				End If
				wk_Tx = 69
			ElseIf wk_Tx + 13 < PP_SSSMAIN.NrBodyTx Then 
				wk_Tx = wk_Tx + 13
				If ((wk_Tx - 4) \ 13) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then wk_Tx = 69
				'     以降は (wk_Tx + 13 >= PP_SSSMAIN.NrBodyTx) の場合
			ElseIf PP_SSSMAIN.TopDe < 4 - PP_SSSMAIN.MaxDspC Then 
				If AE_CursorInOutCheck_SSSMAIN(wk_Tx, 26) >= 0 Then
					wk_Tx = wk_Tx + 13
					If ((wk_Tx - 4) \ 13) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then
						wk_Tx = 69
					Else
						wk_ExTopDe = PP_SSSMAIN.TopDe
						Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
						If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then
							wk_Tx = wk_Tx - 13
						Else
							wk_Tx = 69
						End If
					End If
				Else
					wk_Tx = 69
				End If
			Else
				wk_Tx = 69
			End If
			If wk_Tx < 69 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorDown_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		AE_CursorDown_SSSMAIN = False
	End Function
	
	Sub AE_CursorInit_SSSMAIN() 'Generated.
		PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
		If PP_SSSMAIN.Tx < 0 Then
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				Call AE_CursorRestSub_SSSMAIN(Cn_CursorToHome)
				'UPGRADE_ISSUE: Control TabIndex は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			ElseIf FR_SSSMAIN.ActiveControl.TabIndex <> AE_CursorRest(PP_SSSMAIN.ScX).TabIndex Then 
				Call AE_CursorRestSub_SSSMAIN(Cn_CursorToHome)
			Else
				wk_Int = AE_CursorNext_SSSMAIN(-1)
			End If
		Else
			If Not AE_CursorToError_SSSMAIN() Then
				Call AE_CursorRestSub_SSSMAIN(Cn_CursorToHome)
			End If
		End If
	End Sub
	
	Function AE_CursorInOutCheck_SSSMAIN(ByVal pm_Tx As Short, ByVal pm_Dsp As Short) As Short 'Generated.
		Dim wk_Px As Short
		If pm_Tx = -1 Then
			wk_Px = 0
		Else
			wk_Px = AE_Px(PP_SSSMAIN, pm_Tx) + pm_Dsp
		End If
		Do While wk_Px < 134
			If AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(wk_Px).TypeA <> Cn_CheckBox Then
					AE_CursorInOutCheck_SSSMAIN = wk_Px
					Exit Function
				End If
			End If
			wk_Px = wk_Px + pm_Dsp
		Loop 
		If pm_Tx < 69 Then
			wk_Px = 134
		Else
			wk_Px = AE_Px(PP_SSSMAIN, pm_Tx) + 1
		End If
		Do While wk_Px < 134
			If AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(wk_Px).TypeA <> Cn_CheckBox Then
					AE_CursorInOutCheck_SSSMAIN = wk_Px
					Exit Function
				End If
			End If
			wk_Px = wk_Px + 1
		Loop 
		AE_CursorInOutCheck_SSSMAIN = -1
	End Function
	
	Sub AE_CursorMove_SSSMAIN(ByVal pm_Tx As Short) 'Generated.
		Dim wk_Tx As Short
		wk_Tx = pm_Tx
		If wk_Tx = -2 Then Exit Sub
		If wk_Tx < 0 Or wk_Tx >= 69 Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		If AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop And AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Visible Then
			If wk_Tx = PP_SSSMAIN.Tx Then
				Call AE_CursorRestSub_SSSMAIN(wk_Tx)
			Else 'If wk_Tx <> PP_SSSMAIN.Tx Then
				AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				If Not PP_SSSMAIN.CursorSet Then
					PP_SSSMAIN.NextTx = wk_Tx
					On Error Resume Next
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Focus()
				End If
			End If
		Else
			Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
		End If
	End Sub
	
	Function AE_CursorNext_SSSMAIN(ByVal pm_Tx As Short) As Boolean 'Generated.
		Dim wk_Tx As Short
		Dim wk_ExTopDe As Short
		Dim wk_DeC As Short
		wk_DeC = 0 : If PP_SSSMAIN.ActiveDe >= 0 Or Not AE_GetDeApendable(PP_SSSMAIN) Then wk_DeC = 1
		wk_Tx = pm_Tx
		Select Case AE_CursorInOutCheck_SSSMAIN(wk_Tx, 1)
			Case -1
				If PP_SSSMAIN.KeyDownMode = Cn_Mode3 And PP_SSSMAIN.Tx >= 0 Then
					PP_SSSMAIN.TimerWorkId = 9 : AE_Timer(PP_SSSMAIN.ScX).Interval = 10 : AE_Timer(PP_SSSMAIN.ScX).Enabled = True
				End If
				AE_CursorNext_SSSMAIN = False : Exit Function
		End Select
		Do While wk_Tx < 69
			wk_Tx = wk_Tx + 1
			If wk_Tx = PP_SSSMAIN.NrBodyTx Then
				If PP_SSSMAIN.TopDe < 4 - PP_SSSMAIN.MaxDspC Then
					If ((wk_Tx - 4) \ 13) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then
						wk_Tx = 69
					Else
						wk_ExTopDe = PP_SSSMAIN.TopDe
						Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
						If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then
							wk_Tx = wk_Tx - 13
						Else
							wk_Tx = 69
						End If
					End If
				End If
			End If
			If wk_Tx >= 4 And wk_Tx < 69 Then 'AE_BodyN > 0
				If ((wk_Tx - 4) \ 13) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then wk_Tx = 69
			End If
			If wk_Tx < 69 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorNext_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		If PP_SSSMAIN.KeyDownMode = Cn_Mode3 And PP_SSSMAIN.Tx >= 0 Then
			PP_SSSMAIN.TimerWorkId = 9 : AE_Timer(PP_SSSMAIN.ScX).Interval = 10 : AE_Timer(PP_SSSMAIN.ScX).Enabled = True
		End If
		AE_CursorNext_SSSMAIN = False
	End Function
	
	Function AE_CursorNextDsp_SSSMAIN(ByVal pm_Tx As Short) As Boolean 'Generated.
		Dim wk_Tx As Short
		wk_Tx = pm_Tx
		Do While wk_Tx < 68
			wk_Tx = wk_Tx + 1
			If wk_Tx = PP_SSSMAIN.NrBodyTx Then wk_Tx = 69
			If wk_Tx < 69 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorNextDsp_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		AE_CursorNextDsp_SSSMAIN = False
	End Function
	
	Function AE_CursorPrev_SSSMAIN(ByVal pm_Tx As Short) As Boolean 'Generated.
		Dim wk_Tx As Short
		Dim wk_LastTx As Short
		Dim wk_DeC As Short
		wk_DeC = 0 : If PP_SSSMAIN.ActiveDe >= 0 Or Not AE_GetDeApendable(PP_SSSMAIN) Then wk_DeC = 1
		wk_Tx = pm_Tx
		Do While wk_Tx >= 0
			If wk_Tx = 69 Then
				wk_Tx = PP_SSSMAIN.NrBodyTx - 13
				wk_LastTx = 4 + (PP_SSSMAIN.LastDe - wk_DeC - PP_SSSMAIN.TopDe) * 13
				If wk_LastTx < wk_Tx Then wk_Tx = wk_LastTx
				If wk_Tx >= 4 Then
					Do 
						If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
							Call AE_CursorMove_SSSMAIN(wk_Tx)
							AE_CursorPrev_SSSMAIN = True
							Exit Function
						End If
						wk_Tx = wk_Tx + 1
						If (wk_Tx - 4) Mod 13 = 0 Then wk_Tx = wk_Tx - 13 - 13
						If wk_Tx < 4 Then
							If PP_SSSMAIN.TopDe > 0 Then
								Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
								wk_Tx = wk_Tx + 13
							End If
						End If
					Loop Until wk_Tx < 4
				End If
				wk_Tx = 3
			Else
				wk_Tx = wk_Tx - 1
			End If
			If wk_Tx = 3 And PP_SSSMAIN.TopDe > 0 Then
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
				wk_Tx = wk_Tx + 13
			End If
			If wk_Tx >= 0 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorPrev_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		AE_CursorPrev_SSSMAIN = False
	End Function
	
	Function AE_CursorPrevDsp_SSSMAIN(ByVal pm_Tx As Short) As Boolean 'Generated.
		Dim wk_Tx As Short
		wk_Tx = pm_Tx
		Do While wk_Tx >= 0
			If wk_Tx = 69 Then wk_Tx = PP_SSSMAIN.NrBodyTx
			wk_Tx = wk_Tx - 1
			If wk_Tx >= 0 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorPrevDsp_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		AE_CursorPrevDsp_SSSMAIN = False
	End Function
	
	Sub AE_CursorRestSub_SSSMAIN(ByVal pm_CurSorTo As Short) 'Generated.
		If PP_SSSMAIN.CursorSet = False And AE_CursorRest(PP_SSSMAIN.ScX).Visible And AE_CursorRest(PP_SSSMAIN.ScX).Enabled Then
			If FR_SSSMAIN.ActiveControl Is Nothing Then
				'UPGRADE_ISSUE: Control TabIndex は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			ElseIf FR_SSSMAIN.ActiveControl.TabIndex <> AE_CursorRest(PP_SSSMAIN.ScX).TabIndex Then 
			Else
				Exit Sub
			End If
			AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
			PP_SSSMAIN.CursorToWhere = pm_CurSorTo
			PP_SSSMAIN.NextTx = Cn_NextTxCleared
			On Error Resume Next
			AE_CursorRest(PP_SSSMAIN.ScX).Focus()
		End If
	End Sub
	
	Sub AE_CursorRivise_SSSMAIN() 'Generated.
		If Not PP_SSSMAIN.LostFocusCheck Then
		ElseIf PP_SSSMAIN.MouseDownTx <> -1 Then 
			If PP_SSSMAIN.ModalFlag Or (CP_SSSMAIN(PP_SSSMAIN.MouseDownTx).TypeA = Cn_NormalOrV And Not PP_SSSMAIN.ChangeAtGotFocus) Then Call AE_CursorRestSub_SSSMAIN(PP_SSSMAIN.MouseDownTx)
		ElseIf PP_SSSMAIN.ModalFlag Then 
			Call AE_CursorRestSub_SSSMAIN(PP_SSSMAIN.Tx)
		End If
		PP_SSSMAIN.LostFocusCheck = False
		PP_SSSMAIN.MouseDownTx = -1
		PP_SSSMAIN.ModalFlag = False
	End Sub
	
	Function AE_CursorSkip_SSSMAIN() As Boolean 'Generated.
		Dim wk_Bool As Boolean
		Dim wk_CursorDirection As Short
		wk_Bool = True
		Select Case PP_SSSMAIN.CursorDest
			Case Cn_Dest2
				If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			Case Cn_Dest3
				If Not AE_CursorPrev_SSSMAIN(69) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			Case Cn_Dest4
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest5
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorPrev_SSSMAIN(69) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest6
				If Not AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorPrev_SSSMAIN(69) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
			Case Cn_Dest7
				If Not AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
			Case Cn_DestBySkip
				Select Case PP_SSSMAIN.CursorDirection
					Case Cn_Direction0, Cn_Direction1
						If AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
							PP_SSSMAIN.CursorDirection = Cn_Direction1
							AE_CursorSkip_SSSMAIN = True
							Exit Function
						Else
							PP_SSSMAIN.CursorDirection = Cn_Direction2
							If AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) Then
								PP_SSSMAIN.CursorDirection = Cn_Direction2
								AE_CursorSkip_SSSMAIN = True
								Exit Function
							Else
								PP_SSSMAIN.CursorDirection = Cn_Direction1
								AE_CursorSkip_SSSMAIN = False
								Exit Function
							End If
						End If
					Case Cn_Direction2
						If AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) Then
							PP_SSSMAIN.CursorDirection = Cn_Direction2
							AE_CursorSkip_SSSMAIN = True
							Exit Function
						Else
							PP_SSSMAIN.CursorDirection = Cn_Direction1
							If AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
								PP_SSSMAIN.CursorDirection = Cn_Direction1
								AE_CursorSkip_SSSMAIN = True
								Exit Function
							Else
								PP_SSSMAIN.CursorDirection = Cn_Direction2
								AE_CursorSkip_SSSMAIN = False
								Exit Function
							End If
						End If
					Case Cn_Direction3
						If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
							PP_SSSMAIN.CursorDirection = Cn_Direction3
							AE_CursorSkip_SSSMAIN = True
							Exit Function
						Else
							PP_SSSMAIN.CursorDirection = Cn_Direction4
							If AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
								PP_SSSMAIN.CursorDirection = Cn_Direction4
								AE_CursorSkip_SSSMAIN = True
								Exit Function
							Else
								PP_SSSMAIN.CursorDirection = Cn_Direction3
								AE_CursorSkip_SSSMAIN = False
								Exit Function
							End If
						End If
					Case Cn_Direction4
						If AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
							PP_SSSMAIN.CursorDirection = Cn_Direction4
							AE_CursorSkip_SSSMAIN = True
							Exit Function
						Else
							PP_SSSMAIN.CursorDirection = Cn_Direction3
							If AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
								PP_SSSMAIN.CursorDirection = Cn_Direction3
								AE_CursorSkip_SSSMAIN = True
								Exit Function
							Else
								PP_SSSMAIN.CursorDirection = Cn_Direction4
								AE_CursorSkip_SSSMAIN = False
								Exit Function
							End If
						End If
				End Select
			Case Else
				Select Case PP_SSSMAIN.CursorDirection
					Case Is <= Cn_Direction1
						wk_CursorDirection = PP_SSSMAIN.CursorDirection
						wk_Bool = AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx)
						If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorNext_SSSMAIN(-1)
						PP_SSSMAIN.CursorDirection = wk_CursorDirection
					Case Cn_Direction2
						wk_CursorDirection = PP_SSSMAIN.CursorDirection
						wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx)
						If PP_SSSMAIN.CursorDest = Cn_Dest0 And wk_Bool = False Then wk_Bool = AE_CursorNext_SSSMAIN(-1)
						If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(69)
						PP_SSSMAIN.CursorDirection = wk_CursorDirection
					Case Cn_Direction3
						wk_Bool = AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx)
					Case Cn_Direction4
						wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx)
					Case Else
						wk_Bool = False
				End Select
		End Select
		AE_CursorSkip_SSSMAIN = wk_Bool
		If wk_Bool Or PP_SSSMAIN.Tx < 0 Or (Cn_ai21 And PP_SSSMAIN.CursorDest = 0) Then
		ElseIf Not AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Or Not AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled Or Not AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible Then 
			Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			AE_CursorSkip_SSSMAIN = True
		End If
	End Function
	
	Sub AE_CursorSub_SSSMAIN(ByVal pm_CurSor As Short) 'Generated.
		Dim wk_Tx As Short
		If pm_CurSor = Cn_CuInCompletePx Then
			If PP_SSSMAIN.InCompletePx = -1 Then Call AE_CursorCurrent_SSSMAIN() : Exit Sub
			If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA = Cn_CheckBox Then PP_SSSMAIN.CursorDirection = Cn_Direction2 : wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			wk_Tx = AE_Tx(PP_SSSMAIN, PP_SSSMAIN.InCompletePx)
			If wk_Tx >= 0 Then
				Call AE_CursorMove_SSSMAIN(wk_Tx)
			ElseIf PP_SSSMAIN.InCompletePx < 134 Then 
				Call AE_Scrl_SSSMAIN((PP_SSSMAIN.InCompletePx - 4) \ PP_SSSMAIN.BodyV, False)
				Call AE_CursorMove_SSSMAIN(AE_Tx(PP_SSSMAIN, PP_SSSMAIN.InCompletePx))
			Else
				Call AE_CursorCurrent_SSSMAIN()
			End If
		ElseIf pm_CurSor = Cn_CuCurrent Then 
			If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_CheckBox Then PP_SSSMAIN.CursorDirection = Cn_Direction2 : wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx) : Exit Sub
			Call AE_CursorCurrent_SSSMAIN()
		ElseIf pm_CurSor = Cn_CuInit Then 
			Call AE_CursorInit_SSSMAIN()
		ElseIf pm_CurSor = Cn_CuCursorRest Then 
			Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
		ElseIf pm_CurSor = Cn_CuExTx Then 
			Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.ExTx)
		End If
	End Sub
	
	Function AE_CursorToError_SSSMAIN() As Boolean 'Generated.
		Dim wk_Tx As Short
		Dim wk_TxRel As Short
		Dim wk_Px As Short
		wk_TxRel = -1
		wk_Tx = 0
		Do While wk_Tx < 69
			wk_Px = AE_Px(PP_SSSMAIN, wk_Tx)
			If CP_SSSMAIN(wk_Px).StatusC >= Cn_Status2 And CP_SSSMAIN(wk_Px).StatusC <= Cn_Status5 Then
				Select Case CP_SSSMAIN(wk_Px).TypeA
					Case Cn_NormalOrV, Cn_InputOnly
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) And AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
							If CP_SSSMAIN(wk_Px).StatusC = Cn_Status2 Then
								Call AE_CursorMove_SSSMAIN(wk_Tx)
								AE_CursorToError_SSSMAIN = True
								Exit Function
							ElseIf wk_TxRel = -1 Then 
								wk_TxRel = wk_Tx
							End If
						End If
				End Select
			End If
			wk_Tx = wk_Tx + 1
		Loop 
		If wk_TxRel >= 0 Then
			Call AE_CursorMove_SSSMAIN(wk_TxRel)
			AE_CursorToError_SSSMAIN = True
		Else
			AE_CursorToError_SSSMAIN = False
		End If
	End Function
	
	Function AE_CursorUp_SSSMAIN(ByVal pm_Tx As Short) As Boolean 'Generated.
		Dim wk_Tx As Short
		Dim wk_LastTx As Short
		Dim wk_DeC As Short
		wk_DeC = 0 : If PP_SSSMAIN.ActiveDe >= 0 Or Not AE_GetDeApendable(PP_SSSMAIN) Then wk_DeC = 1
		wk_Tx = pm_Tx
		Do While wk_Tx >= 0
			If wk_Tx < 4 Or wk_Tx > 69 Then
				wk_Tx = wk_Tx - 1
			ElseIf wk_Tx = 69 Then 
				wk_Tx = PP_SSSMAIN.NrBodyTx - 13
				wk_LastTx = 4 + (PP_SSSMAIN.LastDe - wk_DeC - PP_SSSMAIN.TopDe) * 13
				If wk_LastTx < wk_Tx Then wk_Tx = wk_LastTx
				Do While wk_Tx >= 4
					If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
						Call AE_CursorMove_SSSMAIN(wk_Tx)
						AE_CursorUp_SSSMAIN = True
						Exit Function
					End If
					wk_Tx = wk_Tx + 1
					If (wk_Tx - 4) Mod 13 = 0 Then wk_Tx = wk_Tx - 13 - 13
					If wk_Tx < 4 Then
						If PP_SSSMAIN.TopDe > 0 Then
							Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
							wk_Tx = wk_Tx + 13
						End If
					End If
				Loop 
				wk_Tx = 3
			ElseIf wk_Tx - 13 >= 4 Then 
				wk_Tx = wk_Tx - 13
			Else 'wk_Tx - 13 < 4 Then
				If PP_SSSMAIN.TopDe > 0 Then
					Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
				Else
					wk_Tx = 3
				End If
			End If
			If wk_Tx >= 0 Then
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
					Call AE_CursorMove_SSSMAIN(wk_Tx)
					AE_CursorUp_SSSMAIN = True
					Exit Function
				End If
			End If
		Loop 
		AE_CursorUp_SSSMAIN = False
	End Function
	
	Function AE_Current_SSSMAIN() As Short 'Generated.
		Call AE_InitValAll_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.LastDe = SSSMAIN_Current()
		If PP_SSSMAIN.LastDe = 0 Then
			If Not AE_MsgLibrary(PP_SSSMAIN, "Current") Then
				Call AE_InitValAll_SSSMAIN()
			Else
				Call AE_ScrlMax(PP_SSSMAIN)
				Call AE_RecalcAll_SSSMAIN()
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
			End If
		Else
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
			Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_Current_SSSMAIN = Cn_CuInit
	End Function
	
	Sub AE_DeDown_SSSMAIN(ByVal pm_De As Short) 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		If PP_SSSMAIN.LastDe > 4 Then
			Call AE_SystemError("AE_DeDown に", 750)
			Exit Sub
		End If
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.De = PP_SSSMAIN.LastDe : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		PP_SSSMAIN.MaskMode = True
		PP_SSSMAIN.SuppressMultiTlDerived = True
		Do While PP_SSSMAIN.De > pm_De
			Call AE_DeSub_SSSMAIN(-1) ', PP_SSSMAIN.De
			PP_SSSMAIN.De = PP_SSSMAIN.De - 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.De = pm_De : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_InitValBdDe_SSSMAIN(-3, True, Cn_Status0)
		PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe + 1
		Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
	End Sub
	
	Sub AE_DeleteDe_SSSMAIN() 'Generated.
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.ActiveDe <> -1 And PP_SSSMAIN.ActiveDe < PP_SSSMAIN.De Then
			wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "ClearDe")
			Exit Sub
		End If
		PP_SSSMAIN.UnDoDeOp = 2
		PP_SSSMAIN.UnDoDeNo = PP_SSSMAIN.De
		Call AE_DeSave_SSSMAIN(PP_SSSMAIN.De)
		If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then PP_SSSMAIN.ActiveDe = -1
		Call AE_DeUp_SSSMAIN(PP_SSSMAIN.De)
		PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
		If PP_SSSMAIN.LastDe = 0 Then
			PP_SSSMAIN.DerivedOrigin = ""
			Call AE_RecalcBdDe_SSSMAIN() '(PP_SSSMAIN.De)
			Call AE_CursorCurrent_SSSMAIN()
		Else
			PP_SSSMAIN.DerivedOrigin = ""
			Call AE_RecalcBd_SSSMAIN()
			If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.LastDe - 1) Then
				PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe - 1
				If PP_SSSMAIN.De < PP_SSSMAIN.LastReadDe Then PP_SSSMAIN.LastReadDe = PP_SSSMAIN.LastReadDe - 1
				PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
				wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx)
			Else
				Call AE_CursorCurrent_SSSMAIN()
			End If
		End If
		Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_DeRestore_SSSMAIN(ByVal pm_De As Short) 'Generated.
		Dim wk_ww As Short
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		Dim wk_PxBaseTarget As Short
		Dim wk_Tx As Short
		'20080925 ADD START RISE)Tanimura '排他処理
		Dim bolRet As Boolean
		'20080925 ADD END   RISE)Tanimura
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.MaskMode = True
		wk_PxBaseTarget = 4 + 26 * pm_De
		wk_ww = 0
		PP_SSSMAIN.SuppressMultiTlDerived = True
		'20080925 ADD START RISE)Tanimura '排他処理
		bolRet = MEIMT52_MF_SaveRestore_UWRTDTTM(pm_De, 1) ' 復元
		'20080925 ADD END   RISE)Tanimura
		Do While wk_ww < 26
			If wk_ww + 1 = 26 Then PP_SSSMAIN.SuppressMultiTlDerived = False
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If CP_SSSMAIN(135 + wk_ww).StatusC <> Cn_Status8 Or IsDbNull(CP_SSSMAIN(135 + wk_ww).CuVal) Then
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).TpStr = CP_SSSMAIN(135 + wk_ww).TpStr
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).CuVal = CP_SSSMAIN(135 + wk_ww).CuVal
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).ExVal = CP_SSSMAIN(135 + wk_ww).ExVal
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).FractionC = CP_SSSMAIN(135 + wk_ww).FractionC
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).StatusC = CP_SSSMAIN(135 + wk_ww).StatusC
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).StatusF = CP_SSSMAIN(135 + wk_ww).StatusF
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).ExStatus = CP_SSSMAIN(135 + wk_ww).ExStatus
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).InOutMode = CP_SSSMAIN(135 + wk_ww).InOutMode
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).CheckRtnCode = CP_SSSMAIN(135 + wk_ww).CheckRtnCode
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).Modified = CP_SSSMAIN(135 + wk_ww).Modified
				wk_Tx = AE_Tx(PP_SSSMAIN, wk_PxBaseTarget + wk_ww)
                'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_Tx) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190806 CHG START
                'If wk_Tx >= 0 Then AE_Controls(PP_SSSMAIN.CtB + wk_Tx) = AE_Tpstr(CP_SSSMAIN(135 + wk_ww).TpStr, CP_SSSMAIN(135 + wk_ww).TypeA)
                If wk_Tx >= 0 Then AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Text = AE_Tpstr(CP_SSSMAIN(135 + wk_ww).TpStr, CP_SSSMAIN(135 + wk_ww).TypeA)
                '20190806 CHG END
                If CP_SSSMAIN(wk_PxBaseTarget + wk_ww).StatusC <= Cn_Status5 And CP_SSSMAIN(135 + wk_ww).StatusC <= Cn_Status5 Then
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_PxBaseTarget + wk_ww), CL_SSSMAIN(wk_PxBaseTarget + wk_ww))
                End If
                If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, False)
			Else
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).InOutMode = CP_SSSMAIN(135 + wk_ww).InOutMode
				Call AE_InitValBdDe_SSSMAIN(wk_PxBaseTarget + wk_ww, False, CP_SSSMAIN(135 + wk_ww).StatusF) ', PP_SSSMAIN.De
			End If
			wk_ww = wk_ww + 1
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
	End Sub

    Sub AE_Derived_SSSMAIN_bd_MEICDB(ByVal DE_INDEX As Object) 'Generated.
        Dim CC_NewVal As Object
        Dim wk_SaveMask As Boolean
        Dim wk_Px As Short
        wk_Px = 6 + 26 * PP_SSSMAIN.De
        If PP_SSSMAIN.DerivedOrigin <> "" Then
            'UPGRADE_WARNING: オブジェクト MEICDB_DerivedC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CC_NewVal = MEICDB_DerivedC(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If IsNothing(CC_NewVal) Then Exit Sub
            CP_SSSMAIN(wk_Px).CheckRtnCode = 0
            'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CC_NewVal = AE_NormData(CP_SSSMAIN(wk_Px), CC_NewVal)
            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If IsNothing(CP_SSSMAIN(wk_Px).CuVal) Then CP_SSSMAIN(wk_Px).CuVal = System.DBNull.Value
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If CC_NewVal = CP_SSSMAIN(wk_Px).CuVal And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then
                Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            ElseIf IsDbNull(CC_NewVal) And IsDbNull(CP_SSSMAIN(wk_Px).CuVal) And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then
            Else
                wk_SaveMask = PP_SSSMAIN.MaskMode
                PP_SSSMAIN.MaskMode = True
                'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                CP_SSSMAIN(wk_Px).CuVal = CC_NewVal
                CP_SSSMAIN(wk_Px).TpStr = AE_Format(CP_SSSMAIN(wk_Px), CP_SSSMAIN(wk_Px).CuVal, 0, True)
                Call AE_CtSet(PP_SSSMAIN, wk_Px, CP_SSSMAIN(wk_Px).TpStr, CP_SSSMAIN(wk_Px).TypeA, False)
                PP_SSSMAIN.MaskMode = wk_SaveMask
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
                If CP_SSSMAIN(wk_Px).StatusC = Cn_StatusError Then
                    CP_SSSMAIN(wk_Px).StatusC = Cn_Status2
                    CP_SSSMAIN(wk_Px).StatusF = Cn_Status2
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                ElseIf CP_SSSMAIN(wk_Px).StatusC <> Cn_Status6 Then
                    CP_SSSMAIN(wk_Px).StatusC = Cn_Status7
                    CP_SSSMAIN(wk_Px).StatusF = Cn_Status7
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                Else
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
                End If
            End If
        End If
    End Sub

    '20190826 ADD START
    Function MEICDB_DerivedC(ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object

        '    MEICDB_DerivedC = MEICDB
        '    Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
        '    If DBSTAT = 0 Then
        '       ' Call Scr_FromMEIMTA(De_Index)
        '    End If
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEICDB = ""
        End If
    End Function
    '20190826 ADD END


    Sub AE_Derived_SSSMAIN_bd_MEINMA(ByVal DE_INDEX As Object) 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		Dim wk_Px As Short
		wk_Px = 8 + 26 * PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト MEINMA_Derived() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = MEINMA_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8 + 26 * PP_SSSMAIN.De).CuVal), PP_SSSMAIN.De2)
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CC_NewVal) Then Exit Sub
		CP_SSSMAIN(wk_Px).CheckRtnCode = 0
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = AE_NormData(CP_SSSMAIN(wk_Px), CC_NewVal)
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CC_NewVal = CP_SSSMAIN(wk_Px).CuVal And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then
			Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CC_NewVal) And IsDbNull(CP_SSSMAIN(wk_Px).CuVal) And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then 
		Else
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(wk_Px).CuVal = CC_NewVal
			CP_SSSMAIN(wk_Px).TpStr = AE_Format(CP_SSSMAIN(wk_Px), CP_SSSMAIN(wk_Px).CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, CP_SSSMAIN(wk_Px).TpStr, CP_SSSMAIN(wk_Px).TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
			If CP_SSSMAIN(wk_Px).StatusC = Cn_StatusError Then
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status2
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status2
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			ElseIf CP_SSSMAIN(wk_Px).StatusC <> Cn_Status6 Then 
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status7
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status7
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			Else
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			End If
		End If
	End Sub
	
	Sub AE_Derived_SSSMAIN_bd_MEINMB(ByVal DE_INDEX As Object) 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		Dim wk_Px As Short
		wk_Px = 9 + 26 * PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト MEINMB_Derived() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = MEINMB_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9 + 26 * PP_SSSMAIN.De).CuVal), PP_SSSMAIN.De2)
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CC_NewVal) Then Exit Sub
		CP_SSSMAIN(wk_Px).CheckRtnCode = 0
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = AE_NormData(CP_SSSMAIN(wk_Px), CC_NewVal)
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CC_NewVal = CP_SSSMAIN(wk_Px).CuVal And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then
			Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CC_NewVal) And IsDbNull(CP_SSSMAIN(wk_Px).CuVal) And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then 
		Else
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(wk_Px).CuVal = CC_NewVal
			CP_SSSMAIN(wk_Px).TpStr = AE_Format(CP_SSSMAIN(wk_Px), CP_SSSMAIN(wk_Px).CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, CP_SSSMAIN(wk_Px).TpStr, CP_SSSMAIN(wk_Px).TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
			If CP_SSSMAIN(wk_Px).StatusC = Cn_StatusError Then
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status2
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status2
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			ElseIf CP_SSSMAIN(wk_Px).StatusC <> Cn_Status6 Then 
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status7
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status7
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			Else
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			End If
		End If
	End Sub
	
	Sub AE_Derived_SSSMAIN_bd_MEINMC(ByVal DE_INDEX As Object) 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		Dim wk_Px As Short
		wk_Px = 10 + 26 * PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト MEINMC_Derived() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = MEINMC_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(10 + 26 * PP_SSSMAIN.De).CuVal), PP_SSSMAIN.De2)
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CC_NewVal) Then Exit Sub
		CP_SSSMAIN(wk_Px).CheckRtnCode = 0
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = AE_NormData(CP_SSSMAIN(wk_Px), CC_NewVal)
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(wk_Px).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CC_NewVal = CP_SSSMAIN(wk_Px).CuVal And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then
			Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CC_NewVal) And IsDbNull(CP_SSSMAIN(wk_Px).CuVal) And CP_SSSMAIN(wk_Px).StatusC >= Cn_Status6 Then 
		Else
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(wk_Px).CuVal = CC_NewVal
			CP_SSSMAIN(wk_Px).TpStr = AE_Format(CP_SSSMAIN(wk_Px), CP_SSSMAIN(wk_Px).CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Px, CP_SSSMAIN(wk_Px).TpStr, CP_SSSMAIN(wk_Px).TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
			If CP_SSSMAIN(wk_Px).StatusC = Cn_StatusError Then
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status2
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status2
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			ElseIf CP_SSSMAIN(wk_Px).StatusC <> Cn_Status6 Then 
				CP_SSSMAIN(wk_Px).StatusC = Cn_Status7
				CP_SSSMAIN(wk_Px).StatusF = Cn_Status7
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			Else
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Px), CL_SSSMAIN(wk_Px))
			End If
		End If
	End Sub
	
	Sub AE_Derived_SSSMAIN_hd_FRMEINM() 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		If PP_SSSMAIN.DerivedOrigin <> "" Then
			'UPGRADE_WARNING: オブジェクト FRMEINM_DerivedC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CC_NewVal = FRMEINM_DerivedC(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
			'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			If IsNothing(CC_NewVal) Then Exit Sub
			CP_SSSMAIN(1).CheckRtnCode = 0
			'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CC_NewVal = AE_NormData(CP_SSSMAIN(1), CC_NewVal)
			'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If IsNothing(CP_SSSMAIN(1).CuVal) Then CP_SSSMAIN(1).CuVal = System.DBNull.Value
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(1).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CC_NewVal = CP_SSSMAIN(1).CuVal And CP_SSSMAIN(1).StatusC >= Cn_Status6 Then
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			ElseIf IsDbNull(CC_NewVal) And IsDbNull(CP_SSSMAIN(1).CuVal) And CP_SSSMAIN(1).StatusC >= Cn_Status6 Then 
			Else
				wk_SaveMask = PP_SSSMAIN.MaskMode
				PP_SSSMAIN.MaskMode = True
				'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(1).CuVal = CC_NewVal
				CP_SSSMAIN(1).TpStr = AE_Format(CP_SSSMAIN(1), CP_SSSMAIN(1).CuVal, 0, True)
				Call AE_CtSet(PP_SSSMAIN, 1, CP_SSSMAIN(1).TpStr, CP_SSSMAIN(1).TypeA, False)
				PP_SSSMAIN.MaskMode = wk_SaveMask
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(1))
				If CP_SSSMAIN(1).StatusC = Cn_StatusError Then
					CP_SSSMAIN(1).StatusC = Cn_Status2
					CP_SSSMAIN(1).StatusF = Cn_Status2
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
				ElseIf CP_SSSMAIN(1).StatusC <> Cn_Status6 Then 
					CP_SSSMAIN(1).StatusC = Cn_Status7
					CP_SSSMAIN(1).StatusF = Cn_Status7
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
				Else
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
				End If
			End If
		End If
	End Sub
	
	Sub AE_DeSave_SSSMAIN(ByVal pm_De As Short) 'Generated.
		Dim wk_ww As Short
		Dim wk_PxBaseSource As Short
		'20080925 ADD START RISE)Tanimura '排他処理
		Dim bolRet As Boolean
		'20080925 ADD END   RISE)Tanimura
		wk_PxBaseSource = 4 + 26 * pm_De
		wk_ww = 0
		'20080925 ADD START RISE)Tanimura '排他処理
		bolRet = MEIMT52_MF_SaveRestore_UWRTDTTM(pm_De, 0) ' 退避
		'20080925 ADD END   RISE)Tanimura
		Do While wk_ww < 26
			CP_SSSMAIN(135 + wk_ww).TpStr = CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr
			CP_SSSMAIN(135 + wk_ww).CheckRtnCode = CP_SSSMAIN(wk_PxBaseSource + wk_ww).CheckRtnCode
			CP_SSSMAIN(135 + wk_ww).Modified = CP_SSSMAIN(wk_PxBaseSource + wk_ww).Modified
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(135 + wk_ww).CuVal = CP_SSSMAIN(wk_PxBaseSource + wk_ww).CuVal
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CP_SSSMAIN(135 + wk_ww).ExVal = CP_SSSMAIN(wk_PxBaseSource + wk_ww).ExVal
			CP_SSSMAIN(135 + wk_ww).FractionC = CP_SSSMAIN(wk_PxBaseSource + wk_ww).FractionC
			CP_SSSMAIN(135 + wk_ww).StatusC = CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusC
			CP_SSSMAIN(135 + wk_ww).StatusF = CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusF
			CP_SSSMAIN(135 + wk_ww).ExStatus = CP_SSSMAIN(wk_PxBaseSource + wk_ww).ExStatus
			CP_SSSMAIN(135 + wk_ww).InOutMode = CP_SSSMAIN(wk_PxBaseSource + wk_ww).InOutMode
			CP_SSSMAIN(135 + wk_ww).TypeA = CP_SSSMAIN(wk_PxBaseSource + wk_ww).TypeA
			wk_ww = wk_ww + 1
		Loop 
	End Sub
	
	Sub AE_DeSub_SSSMAIN(ByVal pm_UD As Short) 'Generated.
		Dim wk_ww As Short
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		Dim wk_PxBaseTarget As Short
		Dim wk_PxBaseSource As Short
		Dim wk_Tx As Short
		'20080925 ADD START RISE)Tanimura '排他処理
		Dim bolRet As Boolean
		'20080925 ADD END   RISE)Tanimura
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		wk_PxBaseTarget = 4 + 26 * PP_SSSMAIN.De
		wk_PxBaseSource = wk_PxBaseTarget + pm_UD * 26
		wk_ww = 0
		'20080925 ADD START RISE)Tanimura '排他処理
		bolRet = MEIMT52_MF_UpDown_UWRTDTTM(PP_SSSMAIN.De, pm_UD) ' 明細　削除・挿入
		'20080925 ADD END   RISE)Tanimura
		Do While wk_ww < 26
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusC <> Cn_Status8 Or IsDbNull(CP_SSSMAIN(wk_PxBaseSource + wk_ww).CuVal) Then
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).CuVal = CP_SSSMAIN(wk_PxBaseSource + wk_ww).CuVal
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).ExVal = CP_SSSMAIN(wk_PxBaseSource + wk_ww).ExVal
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).FractionC = CP_SSSMAIN(wk_PxBaseSource + wk_ww).FractionC
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).StatusC = CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusC
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).StatusF = CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusF
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).InOutMode = CP_SSSMAIN(wk_PxBaseSource + wk_ww).InOutMode
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).TpStr = CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).CheckRtnCode = CP_SSSMAIN(wk_PxBaseSource + wk_ww).CheckRtnCode
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).Modified = CP_SSSMAIN(wk_PxBaseSource + wk_ww).Modified
				wk_Tx = AE_Tx(PP_SSSMAIN, wk_PxBaseTarget + wk_ww)
                'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_Tx) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'If wk_Tx >= 0 Then AE_Controls(PP_SSSMAIN.CtB + wk_Tx) = AE_Tpstr(CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr, CP_SSSMAIN(wk_PxBaseSource + wk_ww).TypeA)
                If wk_Tx >= 0 Then AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Text = AE_Tpstr(CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr, CP_SSSMAIN(wk_PxBaseSource + wk_ww).TypeA)
                '20190826 CHG END
                Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_PxBaseTarget + wk_ww), CL_SSSMAIN(wk_PxBaseTarget + wk_ww))
				If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, False)
			Else
				CP_SSSMAIN(wk_PxBaseTarget + wk_ww).InOutMode = CP_SSSMAIN(wk_PxBaseSource + wk_ww).InOutMode
				Call AE_InitValBdDe_SSSMAIN(wk_PxBaseTarget + wk_ww, False, CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusF) ', PP_SSSMAIN.De
			End If
			wk_ww = wk_ww + 1
		Loop 
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
	End Sub
	
	Sub AE_DeUp_SSSMAIN(ByVal pm_De As Short) 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.De = pm_De : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		PP_SSSMAIN.MaskMode = True
		PP_SSSMAIN.SuppressMultiTlDerived = True
		Do While PP_SSSMAIN.De <= PP_SSSMAIN.LastDe And PP_SSSMAIN.De <= 4
			If PP_SSSMAIN.De = 4 Then
				Call AE_InitValBdDe_SSSMAIN(-2, True, Cn_Status0)
			Else
				Call AE_DeSub_SSSMAIN(1) ', PP_SSSMAIN.De
			End If
			PP_SSSMAIN.De = PP_SSSMAIN.De + 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.De = pm_De : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Call AE_InitValBdDe_SSSMAIN(-3, True, Cn_Status0)
		If PP_SSSMAIN.LastDe > 0 Then PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe - 1 : Call AE_ScrlMax(PP_SSSMAIN)
		If PP_SSSMAIN.De < PP_SSSMAIN.LastReadDe Then PP_SSSMAIN.LastReadDe = PP_SSSMAIN.LastReadDe - 1
		PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
	End Sub
	
	Sub AE_EndCm_SSSMAIN() 'Generated.
		If PP_SSSMAIN.CloseCode = 29 Or (PP_SSSMAIN.CloseCode = 2 And PP_SSSMAIN.UnloadMode = 3) Then
		ElseIf PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then 
			If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then Exit Sub
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then Exit Sub
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_Var = SSSMAIN_Close()
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If wk_Var = -1 Then
            '20190827 DEL START
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            '20190827 DEL END
            Call AE_WindowProcReset(PP_SSSMAIN)
            '20190827 DEL START
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '20190827 DEL END
            If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
#If ActiveXcompile = 0 Then
			End
#End If
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 1 Then
            '20190827 DEL START
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            '20190827 DEL END
            Call AE_WindowProcReset(PP_SSSMAIN)
            '20190827 DEL START
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '20190827 DEL END
            If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
			FR_SSSMAIN.Hide()
		End If
		PP_SSSMAIN.CloseCode = -1
	End Sub
	
	Function AE_Execute_SSSMAIN() As Short 'Generated.
		Dim wk_ReturnCd As Short
		Dim Wk_De As Short
		With PP_SSSMAIN
			If CP_SSSMAIN(.Px).StatusC = Cn_Status1 Then
				Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(.Px)), Cn_Status6, True)
			End If
			If .Mode = Cn_Mode3 Then
				Exit Function
			End If
			If AE_CompleteCheck_SSSMAIN(False) > 0 Then AE_Execute_SSSMAIN = Cn_CuInCompletePx : Exit Function
			If .Mode = Cn_Mode1 Then
				Wk_De = AE_ClearedDe_SSSMAIN(-1)
				If Wk_De >= 0 Then Call AE_DeUp_SSSMAIN(Wk_De) : .ActiveDe = -1
				If AE_MsgLibrary(PP_SSSMAIN, "Append") Then AE_Execute_SSSMAIN = Cn_CuCurrent : Exit Function
				'UPGRADE_WARNING: オブジェクト SSSMAIN_Append() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk_ReturnCd = SSSMAIN_Append()
				.ServerCheck = 1000
				If wk_ReturnCd >= .ServerCheck And wk_ReturnCd <= .ServerCheck + 5 Then
					wk_ReturnCd = wk_ReturnCd - .ServerCheck
				Else
					.ServerCheck = False
				End If
				AE_Execute_SSSMAIN = Cn_CuInit
				If wk_ReturnCd = 0 Then Exit Function
				Call AE_Term_SSSMAIN()
				If wk_ReturnCd = 1 Then
					AE_Execute_SSSMAIN = AE_SelectCm_SSSMAIN(Cn_Mode1, True)
				ElseIf wk_ReturnCd = 2 Then 
					AE_Execute_SSSMAIN = AE_UpdateC_SSSMAIN(Cn_Mode1, .ServerCheck)
				ElseIf wk_ReturnCd = 3 Then 
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode1, .ServerCheck)
				ElseIf wk_ReturnCd = 4 Then 
					AE_Execute_SSSMAIN = AE_UpdateC_SSSMAIN(Cn_Mode1, .ServerCheck)
				Else
					Call AE_ClearInitValStatus_SSSMAIN()
					Call AE_InitValAll_SSSMAIN()
					AE_Execute_SSSMAIN = Cn_CuInit
				End If
				.ExMessage = (AE_StatusBar(.ScX)).ToString()
			ElseIf .Mode = Cn_Mode2 Then 
				If AE_MsgLibrary(PP_SSSMAIN, "SelectE") Then AE_Execute_SSSMAIN = Cn_CuCurrent : Exit Function
				AE_Execute_SSSMAIN = AE_UpdateC_SSSMAIN(Cn_Mode2, False)
				Exit Function
			ElseIf .Mode = Cn_Mode4 Then 
				Wk_De = AE_ClearedDe_SSSMAIN(-1)
				If Wk_De >= 0 Then Call AE_DeUp_SSSMAIN(Wk_De) : .ActiveDe = -1
				If .InitValStatus <> .Mode Then
					If AE_MsgLibrary(PP_SSSMAIN, "Update") Then AE_Execute_SSSMAIN = Cn_CuCurrent : Exit Function
				Else
					If AE_MsgLibrary(PP_SSSMAIN, "Update2") Then AE_Execute_SSSMAIN = Cn_CuCurrent : Exit Function
				End If
				'UPGRADE_WARNING: オブジェクト SSSMAIN_Update() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk_ReturnCd = SSSMAIN_Update()
				.ServerCheck = 1000
				If wk_ReturnCd >= .ServerCheck And wk_ReturnCd <= .ServerCheck + 5 Then
					wk_ReturnCd = wk_ReturnCd - .ServerCheck
				Else
					.ServerCheck = False
				End If
				AE_Execute_SSSMAIN = Cn_CuInit
				If wk_ReturnCd = 0 Then Exit Function
				Call AE_Term_SSSMAIN()
				If wk_ReturnCd = 1 Then
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_SelectCm_SSSMAIN(Cn_Mode4, True)
				ElseIf wk_ReturnCd = 2 Then 
					If .ServerCheck = False Then AE_Execute_SSSMAIN = AE_NextCm_SSSMAIN(True)
				ElseIf wk_ReturnCd = 3 Then 
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode4, .ServerCheck)
				ElseIf wk_ReturnCd = 4 Then 
					If .ServerCheck = False Then AE_Execute_SSSMAIN = AE_NextCm_SSSMAIN(True)
				ElseIf wk_ReturnCd = 104 Then 
					If .ServerCheck = False Then AE_Execute_SSSMAIN = AE_Current_SSSMAIN()
				Else
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_AppendC_SSSMAIN(Cn_Mode4)
				End If
				.ExMessage = (AE_StatusBar(.ScX)).ToString()
			End If
		End With
	End Function
	
	Function AE_ExecuteX_SSSMAIN() As Short 'Generated.
		Dim wk_Cursor As Short
		AE_ExecuteX_SSSMAIN = Cn_CuCurrent
		If PP_SSSMAIN.Executing = False Then
			PP_SSSMAIN.Executing = True
			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
				Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
			End If
			If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
				Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
				PP_SSSMAIN.CursorSet = True
			Else
				'UPGRADE_WARNING: オブジェクト Execute_GetEvent() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Execute_GetEvent() Then
					wk_Cursor = AE_Execute_SSSMAIN()
				End If
			End If
			AE_ExecuteX_SSSMAIN = wk_Cursor
			PP_SSSMAIN.Executing = False
		End If
	End Function
	
	Function AE_First_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
		If pm_Check Then
			If AE_MsgLibrary(PP_SSSMAIN, "FirstC") Then AE_First_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		Call AE_InitValAll_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_First() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.LastDe = SSSMAIN_First()
		If PP_SSSMAIN.LastDe = 0 Then
			If Not AE_MsgLibrary(PP_SSSMAIN, "FirstCm") Then
				Call AE_InitValAll_SSSMAIN()
			Else
				Call AE_ScrlMax(PP_SSSMAIN)
				Call AE_RecalcAll_SSSMAIN()
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
			End If
		Else
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
			Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_First_SSSMAIN = Cn_CuInit
	End Function
	
	Function AE_FuncKey_SSSMAIN(ByVal pm_KeyCode As Short, ByVal pm_Shift As Short) As Short 'Generated.
		Static wk_Cursor As Short
		AE_FuncKey_SSSMAIN = True
		If Not PP_SSSMAIN.Operable Then Exit Function
		wk_Cursor = Cn_CuCurrent
		If False Then
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.F1 And pm_Shift = 0 Then 
			System.Windows.Forms.SendKeys.Send("%1")
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.F2 And pm_Shift = 0 Then 
			System.Windows.Forms.SendKeys.Send("%2")
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.F3 And pm_Shift = 0 Then 
			System.Windows.Forms.SendKeys.Send("%3")
		End If
	End Function
	
	Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
        '20190826 DEL START
        '      If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        '      On Error Resume Next
        'System.Windows.Forms.Application.DoEvents()
        'FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ''UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        'FR_SSSMAIN.PrintForm()
        'FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
        'If Err.Number <> 0 Then
        '	If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        'End If
        'On Error GoTo 0
        '      AE_Hardcopy_SSSMAIN = Cn_CuCurrent
        '20190826 DEL END
    End Function
	
	Function AE_Indicate_SSSMAIN(ByVal pm_ExMode As Short, ByVal pm_NextRec As Short) As Short 'Generated.
		If PP_SSSMAIN.Mode <> Cn_Mode2 And PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And pm_NextRec <> 1000 Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "Indicate") Then AE_Indicate_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		PP_SSSMAIN.ChOprtMode = Cn_Mode3
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Indicate() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSMAIN_Indicate() Then
			Call AE_ModeChange_SSSMAIN(PP_SSSMAIN.ChOprtMode)
			If PP_SSSMAIN.Mode = PP_SSSMAIN.ChOprtMode Then
				If pm_NextRec = 1000 Then
					Call AE_RecalcAll_SSSMAIN()
				ElseIf pm_NextRec = -1 Then 
					wk_Int = AE_NextCm_SSSMAIN(False)
				ElseIf pm_NextRec = 0 Then 
					wk_Int = AE_Current_SSSMAIN()
				End If
				Call AE_ClearInitValStatus_SSSMAIN()
				AE_Indicate_SSSMAIN = Cn_CuInit
			Else
				Call AE_ModeChange_SSSMAIN(pm_ExMode)
				AE_Indicate_SSSMAIN = Cn_CuCurrent
			End If
		Else
			Call AE_ModeChange_SSSMAIN(pm_ExMode)
			AE_Indicate_SSSMAIN = Cn_CuCurrent
		End If
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Sub AE_InitValAll_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim Wk_De As Short
		Dim wk_InOutMode As Integer
		wk_Px = 0
		Do While wk_Px < 134
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValHd_SSSMAIN(-2, False, Cn_Status0)
		PP_SSSMAIN.MaskMode = False
		Call AE_Scrl_SSSMAIN(0, False)
		PP_SSSMAIN.MaskMode = True
		PP_SSSMAIN.SuppressMultiTlDerived = True
		PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = 0
		Do While PP_SSSMAIN.De <= 4
			If PP_SSSMAIN.De = 4 Then PP_SSSMAIN.SuppressMultiTlDerived = False
			Call AE_InitValBdDe_SSSMAIN(-2, False, Cn_Status0) ', PP_SSSMAIN.De
			PP_SSSMAIN.De = PP_SSSMAIN.De + 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.AlreadyCDe = True
		PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.LastDe = 0 : Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.LastReadDe = 0
		PP_SSSMAIN.TopDe = 0
        'UPGRADE_WARNING: オブジェクト AE_ScrlBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190826 CHG START
        'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
        AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
        '20190826 CHG END
        PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.UnDoDeOp = 0
		PP_SSSMAIN.ActiveDe = -1
		Call AE_ClearInitValStatus_SSSMAIN()
		Call AE_StatusClear(PP_SSSMAIN, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClErrorStatus))
		wk_Px = 0
		Do While wk_Px < 134
			CP_SSSMAIN(wk_Px).IniStr = CP_SSSMAIN(wk_Px).TpStr
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_InitValBd_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_InOutMode As Integer
		Dim Wk_De As Short
		wk_Px = 4
		Do While wk_Px < 134
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		Call AE_Scrl_SSSMAIN(0, False)
		PP_SSSMAIN.MaskMode = True
		PP_SSSMAIN.SuppressMultiTlDerived = True
		PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = 0
		Do While PP_SSSMAIN.De <= 4
			If PP_SSSMAIN.De = 4 Then PP_SSSMAIN.SuppressMultiTlDerived = False
			Call AE_InitValBdDe_SSSMAIN(-2, False, Cn_Status0) ', PP_SSSMAIN.De
			PP_SSSMAIN.De = PP_SSSMAIN.De + 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.AlreadyCDe = True
		PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = -1
		PP_SSSMAIN.LastDe = 0 : Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.TopDe = 0
        'UPGRADE_WARNING: オブジェクト AE_ScrlBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190826 CHG START
        'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
        AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
        '20190826 CHG END
        PP_SSSMAIN.MaskMode = False
		PP_SSSMAIN.UnDoDeOp = 0
		PP_SSSMAIN.ActiveDe = -1
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_InitValEd_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_InOutMode As Integer
		Dim Wk_De As Short
		wk_Px = 134
		Do While wk_Px < 134
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.UnDoEDeOp = 0
		PP_SSSMAIN.ActiveEDe = -1
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_InitValBdDe_SSSMAIN(ByVal pm_Px As Short, ByVal pm_SetInOut As Short, ByVal pm_Status As Short) 'Generated.
		Dim wk_Tx As Short
		Dim wk_PxBase As Short
		Dim RC_ErrorC As Short
		Dim wk_ww As Short
		wk_PxBase = 26 * PP_SSSMAIN.De
		If pm_Px = -2 Then
			wk_Tx = AE_Tx(PP_SSSMAIN, 4 + wk_PxBase)
			If wk_Tx >= 0 Then
				Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx + 12, pm_SetInOut)
			End If
		ElseIf pm_Px >= 0 Then 
			wk_Tx = AE_Tx(PP_SSSMAIN, pm_Px)
			If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, pm_SetInOut)
		End If
		If pm_Px = -2 Or pm_Px = 4 + wk_PxBase Then 'UPDKB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(4 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 5 + wk_PxBase Then 'MEICDA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(5 + wk_PxBase), System.DBNull.Value, pm_Status)
			Call AE_InitValBdDe_SSSMAIN_MEICDA(pm_Px, wk_PxBase)
		End If
		If pm_Px = -2 Or pm_Px = 6 + wk_PxBase Then 'MEICDB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(6 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 7 + wk_PxBase Then 'DSPORD
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(7 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 8 + wk_PxBase Then 'MEINMA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(8 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 9 + wk_PxBase Then 'MEINMB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(9 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 10 + wk_PxBase Then 'MEINMC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(10 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 11 + wk_PxBase Then 'MEISUA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(11 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 12 + wk_PxBase Then 'MEISUB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(12 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 13 + wk_PxBase Then 'MEISUC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(13 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 14 + wk_PxBase Then 'MEIKBA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(14 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 15 + wk_PxBase Then 'MEIKBB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(15 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 16 + wk_PxBase Then 'MEIKBC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(16 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 17 + wk_PxBase Then 'KEYCD
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(17 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 18 + wk_PxBase Then 'MEIKMKNM
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(18 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 19 + wk_PxBase Then 'V_DATKB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(19 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 20 + wk_PxBase Then 'V_MEIKBA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(20 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 21 + wk_PxBase Then 'V_MEIKBB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(21 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 22 + wk_PxBase Then 'V_MEIKBC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(22 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 23 + wk_PxBase Then 'V_MEINMA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(23 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 24 + wk_PxBase Then 'V_MEINMB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(24 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 25 + wk_PxBase Then 'V_MEINMC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(25 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 26 + wk_PxBase Then 'V_MEISUA
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(26 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 27 + wk_PxBase Then 'V_MEISUB
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(27 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 28 + wk_PxBase Then 'V_MEISUC
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(28 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 29 + wk_PxBase Then 'V_DSPORD
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(29 + wk_PxBase), System.DBNull.Value, pm_Status)
		End If
		If pm_Px <= -2 Then
			PP_SSSMAIN.DerivedOrigin = ""
			Call AE_RecalcBdDeSub_SSSMAIN()
		End If
	End Sub
	
	Sub AE_InitValBdDe_SSSMAIN_MEICDA(ByVal pm_Px As Short, ByVal wk_PxBase As Short) 'Generated.
		Dim CC_NewVal As Object
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = CP_SSSMAIN(29 + wk_PxBase).CuVal
		PP_SSSMAIN.DerivedOrigin = "BD_MEICDA"
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_bd_MEICDB(PP_SSSMAIN.De2)
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_bd_MEINMA(PP_SSSMAIN.De2)
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_bd_MEINMB(PP_SSSMAIN.De2)
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_bd_MEINMC(PP_SSSMAIN.De2)
	End Sub
	
	Sub AE_InitValHd_SSSMAIN(ByVal pm_Px As Short, ByVal pm_SetInOut As Short, ByVal pm_Status As Short) 'Generated.
		Dim wk_Tx As Short
		Dim RC_ErrorC As Short
		Dim wk_ww As Short
		If pm_Px = -2 Then
			Call AE_TabStop_SSSMAIN(0, 3, pm_SetInOut)
		ElseIf pm_Px >= 0 Then 
			wk_Tx = AE_Tx(PP_SSSMAIN, pm_Px)
			If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, pm_SetInOut)
		End If
		If pm_Px = -2 Or pm_Px = 0 Then 'FRKEYCD
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(0), FRKEYCD_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN, CP_SSSMAIN(0)), pm_Status)
			Call AE_InitValHd_SSSMAIN_FRKEYCD(pm_Px)
		End If
		If pm_Px = -2 Or pm_Px = 1 Then 'FRMEINM
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(1), FRMEINM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 2 Then 'OPEID
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(2), OPEID_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal), PP_SSSMAIN, CP_SSSMAIN(2)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 3 Then 'OPENM
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(3), OPENM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal), PP_SSSMAIN, CP_SSSMAIN(3)), pm_Status)
		End If
		If pm_Px = -2 Then
			PP_SSSMAIN.DerivedFrom = "(InitVal)"
			PP_SSSMAIN.DerivedOrigin = ""
			Call AE_RecalcHdSub_SSSMAIN()
		End If
	End Sub
	
	Sub AE_InitValHd_SSSMAIN_FRKEYCD(ByVal pm_Px As Short) 'Generated.
		Dim CC_NewVal As Object
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CC_NewVal = CP_SSSMAIN(3).CuVal
		PP_SSSMAIN.DerivedOrigin = "HD_FRKEYCD"
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_hd_FRMEINM()
	End Sub
	
	Sub AE_InitVal_SSSMAIN(ByRef CP As clsCP, ByVal pm_Value As Object, ByVal pm_Status As Short) 'Generated.
		Dim wk_Tx As Short
		Call AE_InitValSubNorm(CP, pm_Value, pm_Status)
		wk_Tx = AE_Tx(PP_SSSMAIN, CP.CpPx)
		If wk_Tx >= 0 Then
			Call AE_CtSet(PP_SSSMAIN, CP.CpPx, CP.TpStr, CP.TypeA, False)
			Call AE_ColorSub2(PP_SSSMAIN, CP, CL_SSSMAIN(CP.CpPx), wk_Tx)
		End If
	End Sub
	
	Sub AE_InOutModeM_SSSMAIN(ByVal pm_ItemName As String, ByVal pm_Mode As String) 'Generated.
		Static wk_Qx As Short
		Static wk_Tx As Short
		Static wk_BodyV As Short
		Static wk_Px1 As Short
		Static wk_Px2 As Short
		Static wk_UCaseObjA As String
		wk_UCaseObjA = UCase(pm_ItemName)
		wk_Qx = 0
		Do While wk_Qx < 30 And UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA
			wk_Qx = wk_Qx + 1
		Loop 
		If UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA Then
			Call AE_SystemError("AE_InOutModeM のパラメタ pm_ItemName$ に", 550)
			Exit Sub
		End If
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutModeM のパラメタ pm_Mode$ に", 551)
			Exit Sub
		End If
		wk_BodyV = 1
		If wk_Qx < 4 Then
			wk_Px1 = wk_Qx
			wk_Px2 = wk_Px1 + 1
		ElseIf wk_Qx < 30 Then 
			wk_Px1 = wk_Qx
			wk_Px2 = 134
			wk_BodyV = 26
		End If
		Do While wk_Px1 < wk_Px2
			CP_SSSMAIN(wk_Px1).InOutMode = (CP_SSSMAIN(wk_Px1).InOutMode \ 256) * 256 + CInt(Mid(pm_Mode, 1, 1)) * 64 + CInt(Mid(pm_Mode, 2, 1)) * 16 + CInt(Mid(pm_Mode, 3, 1)) * 4 + CInt(Mid(pm_Mode, 4, 1))
			wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px1)
			If wk_Tx >= 0 Then
				If CP_SSSMAIN(wk_Px1).TypeA = Cn_OutputOnly Then
				ElseIf CP_SSSMAIN(wk_Px1).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(wk_Px1).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_Px1).TypeA = Cn_CheckBox Then 
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP_SSSMAIN(wk_Px1).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2)
				Else
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP_SSSMAIN(wk_Px1).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2) And (AE_IsEnable(CP_SSSMAIN(wk_Px1).BlockNo, PP_SSSMAIN.ActiveBlockNo))
				End If
			End If
			wk_Px1 = wk_Px1 + wk_BodyV
		Loop 
	End Sub
	
	Sub AE_InOutModeN_SSSMAIN(ByVal pm_ItemName As String, ByVal pm_Mode As String, Optional ByVal pm_De As Object = Nothing) 'Generated.
		Static wk_Qx As Short
		Static wk_Tx As Short
		Static wk_Px As Short
		Static wk_UCaseObjA As String
		wk_UCaseObjA = UCase(pm_ItemName)
		wk_Qx = 0
		Do While wk_Qx < 30 And Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> wk_UCaseObjA
			wk_Qx = wk_Qx + 1
		Loop 
		If UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA Then
			Call AE_SystemError("AE_InOutModeN のパラメタ pm_ItemName$ に", 552)
			Exit Sub
		End If
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutModeN のパラメタ pm_Mode$ に", 553)
			Exit Sub
		End If
		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
		If Not IsNothing(pm_De) Then
			'UPGRADE_WARNING: オブジェクト pm_De の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_De < 0 Or pm_De > 4 Then
				Call AE_SystemError("AE_InOutModeN のパラメタ pm_De に", 554)
				Exit Sub
			End If
		End If
		If wk_Qx < 4 Then
			wk_Px = wk_Qx
		ElseIf wk_Qx < 30 Then 
			'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
			If IsNothing(pm_De) Then
				If PP_SSSMAIN.De2 < 0 Or (Not PP_SSSMAIN.RecalcMode And PP_SSSMAIN.Tx >= 69) Then Exit Sub
				wk_Px = wk_Qx + 26 * PP_SSSMAIN.De
			Else
				'UPGRADE_WARNING: オブジェクト pm_De の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wk_Px = wk_Qx + 26 * pm_De
			End If
		End If
		CP_SSSMAIN(wk_Px).InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) * 256 + CInt(Mid(pm_Mode, 1, 1)) * 64 + CInt(Mid(pm_Mode, 2, 1)) * 16 + CInt(Mid(pm_Mode, 3, 1)) * 4 + CInt(Mid(pm_Mode, 4, 1))
		wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
		If wk_Tx >= 0 Then
			If CP_SSSMAIN(wk_Px).TypeA = Cn_OutputOnly Then
			ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_Px).TypeA = Cn_CheckBox Then 
				AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2)
			Else
				AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2) And (AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo))
			End If
		End If
	End Sub
	
	Function AE_InsertDe_SSSMAIN() As Short 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		AE_InsertDe_SSSMAIN = Cn_CuCurrent
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Function
		If AE_ClearedDe_SSSMAIN(-1) <> PP_SSSMAIN.ActiveDe Then
			PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
		End If
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		If PP_SSSMAIN.ActiveDe >= 0 Then
			Call AE_DeUp_SSSMAIN(PP_SSSMAIN.ActiveDe)
			If PP_SSSMAIN.ActiveDe < PP_SSSMAIN.De Then
				PP_SSSMAIN.De = PP_SSSMAIN.De - 1
				PP_SSSMAIN.De2 = PP_SSSMAIN.De
				PP_SSSMAIN.InCompletePx = PP_SSSMAIN.Px - PP_SSSMAIN.BodyV
				AE_InsertDe_SSSMAIN = Cn_CuInCompletePx
			End If
		ElseIf PP_SSSMAIN.LastDe > 4 Then 
			wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "InsertDe")
			Exit Function
		End If
		PP_SSSMAIN.UnDoDeOp = 0
		Call AE_DeDown_SSSMAIN(PP_SSSMAIN.De)
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValBdDe_SSSMAIN(-2, True, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF) ', PP_SSSMAIN.De
		PP_SSSMAIN.MaskMode = False
		If PP_SSSMAIN.De >= PP_SSSMAIN.LastReadDe Then PP_SSSMAIN.ActiveDe = PP_SSSMAIN.De
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
		Call AE_ScrlMax(PP_SSSMAIN)
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Function
	
	Function AE_IsClearedDe_SSSMAIN(ByVal pm_De As Short) As Boolean 'Generated.
		Dim wk_ww As Short
		Dim wk_PxBase As Short
		If pm_De < PP_SSSMAIN.LastReadDe Or pm_De > 4 Then
			AE_IsClearedDe_SSSMAIN = False : Exit Function
		End If
		wk_PxBase = 4 + 26 * pm_De
		wk_ww = 0
		Do While wk_ww < 26
			If RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).TpStr) <> RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).IniStr) And CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status6 Then
				AE_IsClearedDe_SSSMAIN = False : Exit Function
			ElseIf CP_SSSMAIN(wk_ww + wk_PxBase).StatusC = Cn_Status1 Then 
				If RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).TpStr) <> "" Then
					AE_IsClearedDe_SSSMAIN = False : Exit Function
				End If
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			ElseIf Not AE_IsNullZero(PP_SSSMAIN, CP_SSSMAIN(wk_ww + wk_PxBase)) And (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status5 Or (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status6 And Not IsDbNull(CP_SSSMAIN(wk_ww + wk_PxBase).CuVal))) Then 
				AE_IsClearedDe_SSSMAIN = False : Exit Function
			ElseIf AE_IsNullZero(PP_SSSMAIN, CP_SSSMAIN(wk_ww + wk_PxBase)) And (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status5 Or (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status6 And Not AE_IsNull_SSSMAIN(CP_SSSMAIN(wk_ww + wk_PxBase).CuVal))) Then 
				AE_IsClearedDe_SSSMAIN = False : Exit Function
			End If
			wk_ww = wk_ww + 1
		Loop 
		AE_IsClearedDe_SSSMAIN = True
	End Function
	
	Function AE_IsNull_SSSMAIN(ByVal Valu As Object) As Boolean 'Generated.
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(Valu) Then
			AE_IsNull_SSSMAIN = True
			'UPGRADE_WARNING: オブジェクト Valu の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf Trim(Valu) = "" Then 
			AE_IsNull_SSSMAIN = True
		Else
			AE_IsNull_SSSMAIN = False
		End If
	End Function
	
	Function AE_KeyDown_SSSMAIN(ByRef Ct As System.Windows.Forms.Control, ByRef pm_KeyCode As Short, ByVal pm_Shift As Short, ByRef pm_TA As String) As Short 'Generated.
		Static wk_TopDe As Short
		PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
		Static wk_Tx As Short
		Static wk_Px As Short
		Static wk_Txt As String
		Static wk_SS As Integer
		Static wk_SS2 As Integer
		Static wk_Moji As String
		Static wk_Ln As Short
		Static wk_Ln2 As Integer
		Static wk_DeC As Short
		Static wk_FractionC As Short
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf Ct Is System.Windows.Forms.TextBox Then
            'UPGRADE_WARNING: オブジェクト Ct.Locked の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'Ct.Locked = False
            Ct.Enabled = True
            '20190826 CHG END
        End If
		wk_Txt = Ct.ToString()
		wk_Tx = PP_SSSMAIN.Tx
		wk_Px = PP_SSSMAIN.Px
		PP_SSSMAIN.EditText = False
		PP_SSSMAIN.UnderFurigana = False
		PP_SSSMAIN.UnderFurigana22 = False
		Select Case CP_SSSMAIN(wk_Px).TypeA
			Case Cn_InputOnly, Cn_ListBox, Cn_OutputOnly
			Case Else
                'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'wk_SS = Ct.SelStart
                wk_SS = DirectCast(Ct, TextBox).SelectionStart
                '20190826 CHG END
        End Select
		AE_KeyDown_SSSMAIN = False
		PP_SSSMAIN.CursorDest = Cn_Dest0
		If Not PP_SSSMAIN.Operable Then
			pm_KeyCode = 0
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
			pm_KeyCode = 0
			PP_SSSMAIN.CursorDest = Cn_Dest4
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 2 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			PP_SSSMAIN.CursorDest = Cn_Dest2
			pm_KeyCode = 0
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
			pm_KeyCode = 0
			PP_SSSMAIN.CursorDest = Cn_Dest5
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 2 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			PP_SSSMAIN.CursorDest = Cn_Dest3
			pm_KeyCode = 0
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			pm_KeyCode = 0
			Select Case CP_SSSMAIN(wk_Px).TypeA
				Case Cn_InputOnly, Cn_ListBox
					PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
			End Select
			If PP_SSSMAIN.Mode = Cn_Mode3 Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '20190826 CHG END
                If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '左詰め
                    wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190826 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '20190826 CHG END
                            GoTo AE_KeyDownRightEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS - 1
                    Loop
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '20190806 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190806 CHG START
                    'Ct.SelStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).SelectionStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    '20190806 CHG END
                End If
AE_KeyDownRightEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '20190826 CHG END
            Else
				wk_Ln = Len(wk_Txt)
				If wk_SS = wk_Ln Then
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
				ElseIf wk_SS <= wk_Ln - 2 Or wk_Ln <= 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0 Then 
					Do While wk_SS <= wk_Ln - 2
						wk_SS = wk_SS + 1
						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190826 CHG START
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190826 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            '20190826 CHG START
                            ''UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190806 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                            '20190826 CHG START
                            ''UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190806 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf Mid(wk_Txt, wk_SS, 1) = Space(1) And Not AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then 
							Exit Do
						End If
					Loop 
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
AE_KeyDownRightEnd2_SSSMAIN: 
				Else
					If (CP_SSSMAIN(wk_Px).Alignment <> 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0) Or PP_SSSMAIN.Mode = Cn_Mode3 Then '左詰め
						If PP_SSSMAIN.Override And PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
						If AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS + 1, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            '20190826 CHG START
                            ''UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelStart = wk_SS + 1
                            '                     'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS + 1, PP_SSSMAIN.Override)
                            '20190826 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						End If
					Else
                        '20190826 CHG START
                        ''UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'Ct.SelStart = wk_Ln
                        ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'Ct.SelLength = PP_SSSMAIN.Override
                        DirectCast(Ct, TextBox).Select(wk_Ln, PP_SSSMAIN.Override)
                        '20190826 CHG END
                    End If
				End If
			End If
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 2 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			pm_KeyCode = 0
			PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 0 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			pm_KeyCode = 0
			Select Case CP_SSSMAIN(wk_Px).TypeA
				Case Cn_InputOnly, Cn_ListBox
					PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
			End Select
			If PP_SSSMAIN.Mode = Cn_Mode3 Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '20190826 CHG END

                If CP_SSSMAIN(wk_Px).Alignment = 1 Then '右詰め
                    wk_SS = 0
                    wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS < wk_Ln
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190826 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '20190826 CHG END
                            GoTo AE_KeyDownLeftEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS + 1
                    Loop
                    '20190826 CHG START
                    'Ct.SelStart = wk_Ln
                    DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                    '20190826 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '20190826 CHG END
                End If
AE_KeyDownLeftEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '20190826 CHG END
            Else
				If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
					PP_SSSMAIN.Override = 1
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'Ct.SelStart = wk_SS - 1
                    ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'Ct.SelLength = PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).Select(wk_SS - 1, PP_SSSMAIN.Override)
                    '20190826 CHG END
                ElseIf wk_SS = 0 Then
                    If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
                Else
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        wk_SS = wk_SS - 1
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190826 CHG START
                            'Ct.SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190826 CHG END
                            GoTo AE_KeyDownLeftEnd2_SSSMAIN
						End If
					Loop 
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
				End If
AE_KeyDownLeftEnd2_SSSMAIN: 
			End If
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 2 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			pm_KeyCode = 0
			PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
		ElseIf pm_KeyCode = 126 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			pm_KeyCode = 0
			PP_SSSMAIN.CursorDest = Cn_Dest7
			GoTo CheckOrSkip
		ElseIf (pm_KeyCode = System.Windows.Forms.Keys.Execute Or pm_KeyCode = System.Windows.Forms.Keys.Return) And pm_Shift = 0 Or pm_KeyCode = 127 Then 
KeyExecute: 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			pm_KeyCode = 0
			If wk_Tx >= 4 And wk_Tx < 69 Then
				wk_DeC = 0 : If PP_SSSMAIN.ActiveDe >= 0 Or Not AE_GetDeApendable(PP_SSSMAIN) Then wk_DeC = 1
				If PP_SSSMAIN.De > PP_SSSMAIN.LastDe - wk_DeC Then
					PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
					wk_Bool = AE_CursorUp_SSSMAIN(wk_Tx)
				Else
					AE_KeyDown_SSSMAIN = True
					If PP_SSSMAIN.ActiveDe = PP_SSSMAIN.De Then
						If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
							PP_SSSMAIN.ActiveDe = -1 : Call AE_ScrlMax(PP_SSSMAIN)
						End If
					End If
				End If
			Else
				AE_KeyDown_SSSMAIN = True
			End If
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.End And (pm_Shift And 1) <> 1 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
			PP_SSSMAIN.CursorDest = Cn_Dest3
			pm_KeyCode = 0
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Home And (pm_Shift And 1) <> 1 Then 
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			PP_SSSMAIN.CursorDest = Cn_Dest2
			pm_KeyCode = 0
			GoTo CheckOrSkip
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.PageDown And pm_Shift = 0 Then 
			pm_KeyCode = 0
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then
				If PP_SSSMAIN.MaxDspC > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + PP_SSSMAIN.ScrlMaxL, True)
			End If
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.PageUp And pm_Shift = 0 Then 
			pm_KeyCode = 0
			If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - PP_SSSMAIN.ScrlMaxL, True)
		ElseIf pm_KeyCode = 229 Then 
			PP_SSSMAIN.EditText = True
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Delete And pm_Shift <= 2 Then 
			pm_KeyCode = 0
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Function
            '20190828 CHG START
            'wk_Ln = Len(Ct)
            wk_Ln = Len(Ct.Text)
            '20190828 CHG END
            If CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("-") Then
				Exit Function
			ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then 
				Exit Function
			ElseIf Not AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Or Not AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then 
				Exit Function
			ElseIf CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
				If AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wk_Txt = Left(wk_Txt, wk_SS) & Space(LenWid(Mid(wk_Txt, wk_SS + 1, 1))) & Mid(wk_Txt, wk_SS + 2)
					wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
					wk_SS = wk_SS + 1
					Do While wk_SS < wk_Ln
						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then Exit Do
						wk_SS = wk_SS + 1
					Loop 
				Else
					Exit Function
				End If
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'ElseIf Ct.SelLength = wk_Ln And wk_Ln > 1 Then 
            ElseIf DirectCast(Ct, TextBox).SelectionLength = wk_Ln And wk_Ln > 1 Then
                '20190826 CHG END
                wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
                If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
            ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then
                wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
            ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                    '20190826 CHG END
                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + Ct.SelLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, Ct.SelLength))) 'V6.52
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + DirectCast(Ct, TextBox).SelectionLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, DirectCast(Ct, TextBox).SelectionLength))) 'V6.52
                    '20190826 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
				End If
				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
						'UPGRADE_WARNING: オブジェクト AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
						wk_Txt = ""
					End If
				End If
			Else
				wk_SS2 = wk_SS
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'If Ct.SelLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                If DirectCast(Ct, TextBox).SelectionLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                '20190826 CHG END
                If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
                    If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
                        Beep()
                        Exit Function
                    End If
                End If
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190826 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                    '20190826 CHG END
                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, Ct.SelLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + Ct.SelLength + 1) 'V6.52
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, DirectCast(Ct, TextBox).SelectionLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + DirectCast(Ct, TextBox).SelectionLength + 1) 'V6.52
                    '20190826 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, 1))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2)
				End If
				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
						wk_SS = wk_Ln
						'UPGRADE_WARNING: オブジェクト AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
						wk_Txt = ""
						wk_SS = wk_Ln
					End If
				End If
			End If
			pm_TA = AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC), CP_SSSMAIN(wk_Px).FractionC, False)
			PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: オブジェクト Ct の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'Ct = pm_TA
            DirectCast(Ct, TextBox).Text = pm_TA
            '20190826 CHG END
            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'Ct.SelStart = wk_SS
            DirectCast(Ct, TextBox).SelectionStart = wk_SS
            '20190826 CHG END
            Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(wk_Px), Ct, (PP_SSSMAIN.SelValid And Not CP_SSSMAIN(wk_Px).FixedFormat))
			PP_SSSMAIN.MaskMode = False
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
			CP_SSSMAIN(wk_Px).StatusC = Cn_Status1
			Ct.ForeColor = System.Drawing.ColorTranslator.FromOle(AE_Color(Cn_Status1))
			Select Case CP_SSSMAIN(wk_Px).TypeA
				Case Cn_NormalOrV, Cn_InputOnly
					Ct.BackColor = System.Drawing.ColorTranslator.FromOle(PP_SSSMAIN.BrightOnOff)
			End Select
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Insert Then 
			If CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Or CP_SSSMAIN(wk_Px).TypeA = Cn_ListBox Or CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("1") Then Exit Function
			wk_Ln = Len(wk_Txt)
			PP_SSSMAIN.Override = PP_SSSMAIN.Override Xor 1
            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then Ct.SelStart = wk_Ln - 1
            If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then DirectCast(Ct, TextBox).SelectionStart = wk_Ln - 1
            '20190826 CHG END
            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'Ct.SelLength = PP_SSSMAIN.Override
            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            '20190826 CHG END
        ElseIf pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12 Then 
			wk_Int = AE_FuncKey_SSSMAIN(pm_KeyCode, pm_Shift)
			If pm_KeyCode <> System.Windows.Forms.Keys.F4 Or (pm_Shift And 6) <> 4 Then pm_KeyCode = 0
		ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then 
			pm_KeyCode = 0
		End If
		Exit Function
CheckOrSkip: 
		If CP_SSSMAIN(wk_Px).StatusC = Cn_Status1 Then
			AE_KeyDown_SSSMAIN = True
		Else
			wk_Bool = AE_CursorSkip_SSSMAIN()
		End If
	End Function
	
	Function AE_Last_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
		If pm_Check Then
			If AE_MsgLibrary(PP_SSSMAIN, "LastC") Then AE_Last_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		Call AE_InitValAll_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Last() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.LastDe = SSSMAIN_Last()
		If PP_SSSMAIN.LastDe = 0 Then
			If Not AE_MsgLibrary(PP_SSSMAIN, "LastCm") Then
				Call AE_InitValAll_SSSMAIN()
			Else
				Call AE_ScrlMax(PP_SSSMAIN)
				Call AE_RecalcAll_SSSMAIN()
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
			End If
		Else
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
			Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_Last_SSSMAIN = Cn_CuInit
	End Function
	
	Sub AE_Later_SSSMAIN() 'Generated.
		Select Case PP_SSSMAIN.ChOprtMode
			Case Cn_Mode1
				If PP_SSSMAIN.Mode <> Cn_Mode1 Then wk_Int = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
			Case Cn_Mode15
				wk_Int = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode, True)
			Case Cn_Mode16
				Call AE_InitValAll_SSSMAIN()
			Case Cn_Mode2
				wk_Int = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, False)
			Case Cn_Mode25
				wk_Int = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, True)
			Case Cn_Mode3
				wk_Int = AE_Indicate_SSSMAIN(PP_SSSMAIN.Mode, False)
			Case Cn_Mode4
				wk_Int = AE_UpdateC_SSSMAIN(PP_SSSMAIN.Mode, False)
		End Select
		PP_SSSMAIN.ChOprtMode = 0
	End Sub
	
	Sub AE_LockBd_SSSMAIN(ByVal pm_De As Short, ByVal pm_SetReset As Boolean) 'Generated.
		Dim wk_Px As Short
		Dim wk_Px2 As Short
		Dim wk_Tx As Short
		Dim wk_InOutMode As Integer
		wk_Px = 26 * pm_De + 4
		wk_Px2 = wk_Px + 26
		Do While wk_Px < wk_Px2
			If pm_SetReset Then
				CP_SSSMAIN(wk_Px).InOutMode = CP_SSSMAIN(wk_Px).InOutMode And &HFF5Ds
			Else
				wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
				CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			End If
			wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
			If wk_Tx >= 0 Then
				If CP_SSSMAIN(wk_Px).TypeA = Cn_OutputOnly Then
				ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_Px).TypeA = Cn_CheckBox Then 
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2)
				Else
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2) And (AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo))
				End If
			End If
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_ModeChange_SSSMAIN(ByVal pm_NewMode As Short) 'Generated.
		Select Case pm_NewMode
			Case Cn_Mode1
				If PP_SSSMAIN.Mode <> Cn_Mode1 Then
					PP_SSSMAIN.Mode = Cn_Mode1 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "追加"
					Call AE_TabStop_SSSMAIN(0, 68, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode2
				If PP_SSSMAIN.Mode <> Cn_Mode2 Then
					PP_SSSMAIN.Mode = Cn_Mode2 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "選択"
					Call AE_TabStop_SSSMAIN(0, 68, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode3
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					PP_SSSMAIN.Mode = Cn_Mode3 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "表示"
					Call AE_TabStop_SSSMAIN(0, 68, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
				End If
			Case Cn_Mode4
				If PP_SSSMAIN.Mode <> Cn_Mode4 Then
					PP_SSSMAIN.Mode = Cn_Mode4 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "更新"
					Call AE_TabStop_SSSMAIN(0, 68, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Else
				Call AE_SystemError("AE_ModeChange のパラメタに", 562)
		End Select
	End Sub
	
	Function AE_NextCm_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
		If pm_Check Then
			If AE_MsgLibrary(PP_SSSMAIN, "NextC") Then AE_NextCm_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		Call AE_InitValAll_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Next() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.LastDe = SSSMAIN_Next()
		If PP_SSSMAIN.LastDe = 0 Then
			If Not AE_MsgLibrary(PP_SSSMAIN, "NextCm") Then
				If AE_Last_SSSMAIN(False) = Cn_CuInit Then AE_NextCm_SSSMAIN = Cn_CuInit : Exit Function
			Else
				Call AE_ScrlMax(PP_SSSMAIN)
				Call AE_RecalcAll_SSSMAIN()
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
			End If
		Else
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
			Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_NextCm_SSSMAIN = Cn_CuInit
	End Function
	
	Function AE_NullCnv1_SSSMAIN(ByVal Valu As Object) As Object 'Generated.
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(Valu) Then
			'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv1_SSSMAIN = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(Valu) Then 
			'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv1_SSSMAIN = 0@
		Else
			'UPGRADE_WARNING: オブジェクト Valu の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv1_SSSMAIN = Valu
		End If
	End Function
	
	Function AE_NullCnv2_SSSMAIN(ByVal Valu As Object) As Object 'Generated.
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(Valu) Then
			'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv2_SSSMAIN = ""
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(Valu) Then 
			'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv2_SSSMAIN = ""
		Else
			'UPGRADE_WARNING: オブジェクト Valu の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			AE_NullCnv2_SSSMAIN = Valu
		End If
	End Function
	
	Function AE_Prev_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
		If pm_Check Then
			If AE_MsgLibrary(PP_SSSMAIN, "PrevC") Then AE_Prev_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		Call AE_InitValAll_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Prev() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.LastDe = SSSMAIN_Prev()
		If PP_SSSMAIN.LastDe = 0 Then
			If Not AE_MsgLibrary(PP_SSSMAIN, "PrevCm") Then
				If AE_First_SSSMAIN(False) = Cn_CuInit Then AE_Prev_SSSMAIN = Cn_CuInit : Exit Function
			Else
				Call AE_ScrlMax(PP_SSSMAIN)
				Call AE_RecalcAll_SSSMAIN()
				Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
			End If
		Else
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
			Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_Prev_SSSMAIN = Cn_CuInit
	End Function
	
	Sub AE_RecalcAll_SSSMAIN() 'Generated.
		PP_SSSMAIN.DerivedOrigin = ""
		Call AE_RecalcHd_SSSMAIN()
		Call AE_RecalcBd_SSSMAIN()
	End Sub
	
	Sub AE_RecalcBd_SSSMAIN() 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		PP_SSSMAIN.ErrorC = 0
		PP_SSSMAIN.SuppressMultiTlDerived = True
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = 0
		Do While PP_SSSMAIN.De < PP_SSSMAIN.LastDe And PP_SSSMAIN.De <= 4
			If PP_SSSMAIN.De + 1 = PP_SSSMAIN.LastDe Or PP_SSSMAIN.De = 4 Then PP_SSSMAIN.SuppressMultiTlDerived = False
			Call AE_RecalcBdDe_SSSMAIN() '(PP_SSSMAIN.De)
			PP_SSSMAIN.De = PP_SSSMAIN.De + 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		Loop 
		PP_SSSMAIN.SuppressMultiTlDerived = False
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
		PP_SSSMAIN.MaskMode = wk_SaveMask
		If PP_SSSMAIN.ErrorC <> 0 Then
			wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "Recalc")
		End If
	End Sub
	
	Sub AE_RecalcBdDe_SSSMAIN() 'Generated.
		Dim wk_PxBase As Short
		wk_PxBase = 26 * PP_SSSMAIN.De
		PP_SSSMAIN.RecalcMode = True
		If PP_SSSMAIN.LastDe > 0 Then
			If AE_GetInOutMode(CP_SSSMAIN(4 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(4 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(4 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_UPDKB(AE_Val2(CP_SSSMAIN(4 + wk_PxBase)), CP_SSSMAIN(4 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(5 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(5 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(5 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEICDA(AE_Val2(CP_SSSMAIN(5 + wk_PxBase)), CP_SSSMAIN(5 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(6 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(6 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(6 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEICDB(AE_Val2(CP_SSSMAIN(6 + wk_PxBase)), CP_SSSMAIN(6 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(7 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(7 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(7 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_DSPORD(AE_Val2(CP_SSSMAIN(7 + wk_PxBase)), CP_SSSMAIN(7 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(8 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(8 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(8 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEINMA(AE_Val2(CP_SSSMAIN(8 + wk_PxBase)), CP_SSSMAIN(8 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(9 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(9 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(9 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEINMB(AE_Val2(CP_SSSMAIN(9 + wk_PxBase)), CP_SSSMAIN(9 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(10 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(10 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(10 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEINMC(AE_Val2(CP_SSSMAIN(10 + wk_PxBase)), CP_SSSMAIN(10 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(11 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(11 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(11 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEISUA(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(12 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(12 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(12 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEISUB(AE_Val2(CP_SSSMAIN(12 + wk_PxBase)), CP_SSSMAIN(12 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(13 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(13 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(13 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEISUC(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(14 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(14 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(14 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEIKBA(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(15 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(15 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(15 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEIKBB(AE_Val2(CP_SSSMAIN(15 + wk_PxBase)), CP_SSSMAIN(15 + wk_PxBase).StatusF, False, False)
			End If
			If AE_GetInOutMode(CP_SSSMAIN(16 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(16 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
				If CP_SSSMAIN(16 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_MEIKBC(AE_Val2(CP_SSSMAIN(16 + wk_PxBase)), CP_SSSMAIN(16 + wk_PxBase).StatusF, False, False)
			End If
		End If
		If Left(PP_SSSMAIN.DerivedOrigin, 1) <> "H" Then
			PP_SSSMAIN.DerivedOrigin = ""
		End If
		Call AE_RecalcBdDeSub_SSSMAIN()
		PP_SSSMAIN.RecalcMode = False
	End Sub
	
	Sub AE_RecalcBdDeSub_SSSMAIN() 'Generated.
		Call AE_Derived_SSSMAIN_bd_MEICDB(PP_SSSMAIN.De2)
		Call AE_Derived_SSSMAIN_bd_MEINMA(PP_SSSMAIN.De2)
		Call AE_Derived_SSSMAIN_bd_MEINMB(PP_SSSMAIN.De2)
		Call AE_Derived_SSSMAIN_bd_MEINMC(PP_SSSMAIN.De2)
	End Sub
	
	Sub AE_RecalcHd_SSSMAIN() 'Generated.
		PP_SSSMAIN.RecalcMode = True
		If AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(0).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_FRKEYCD(AE_Val2(CP_SSSMAIN(0)), CP_SSSMAIN(0).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(1).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_FRMEINM(AE_Val2(CP_SSSMAIN(1)), CP_SSSMAIN(1).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(2).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPEID(AE_Val2(CP_SSSMAIN(2)), CP_SSSMAIN(2).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(3).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPENM(AE_Val2(CP_SSSMAIN(3)), CP_SSSMAIN(3).StatusF, False, False)
		End If
		PP_SSSMAIN.DerivedFrom = "(Recalc)"
		If Left(PP_SSSMAIN.DerivedOrigin, 1) <> "H" Then
			PP_SSSMAIN.DerivedOrigin = ""
		End If
		Call AE_RecalcHdSub_SSSMAIN()
		PP_SSSMAIN.RecalcMode = False
	End Sub
	
	Sub AE_RecalcHdSub_SSSMAIN() 'Generated.
		Call AE_Derived_SSSMAIN_hd_FRMEINM()
	End Sub
	
	Function AE_RelCheck_SSSMAIN_MFIL(ByRef pm_ErrorC As Short) As Object 'Generated.
		Dim wk_PxBase As Short
		Dim wk_PxBaseE As Short
		Dim wk_Count As Short
		Dim wk_Pos1 As Short
		'UPGRADE_WARNING: オブジェクト AE_RelCheck_SSSMAIN_MFIL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_RelCheck_SSSMAIN_MFIL = 0
		If Not PP_SSSMAIN.Operable Then Exit Function
		wk_PxBase = 26 * PP_SSSMAIN.De
		wk_PxBaseE = 0 * PP_SSSMAIN.De
		'UPGRADE_WARNING: オブジェクト MFIL_RelCheck() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Ck_Error = MFIL_RelCheck(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).CuVal), PP_SSSMAIN.De2)
		'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_RelCheck_SSSMAIN_MFIL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_RelCheck_SSSMAIN_MFIL = Ck_Error
		If AE_ErrorToInteger(Ck_Error) = 0 Then
			wk_Pos1 = InStr(CP_SSSMAIN(0).RelCheckStatus, Chr(1))
			If wk_Pos1 > 0 Then CP_SSSMAIN(0).RelCheckStatus = Left(CP_SSSMAIN(0).RelCheckStatus, wk_Pos1 - 1) & Mid(CP_SSSMAIN(0).RelCheckStatus, wk_Pos1 + 1)
			If CP_SSSMAIN(0).StatusC >= Cn_Status3 And CP_SSSMAIN(0).StatusC <= Cn_Status5 And CP_SSSMAIN(0).RelCheckStatus = "" Then
				CP_SSSMAIN(0).StatusC = CP_SSSMAIN(0).StatusC + 3
				CP_SSSMAIN(0).StatusF = CP_SSSMAIN(0).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
			ElseIf CP_SSSMAIN(0).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			wk_Pos1 = InStr(CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus, Chr(1))
			If wk_Pos1 > 0 Then CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus = Left(CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus, wk_Pos1 - 1) & Mid(CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus, wk_Pos1 + 1)
			If CP_SSSMAIN(5 + wk_PxBase).StatusC >= Cn_Status3 And CP_SSSMAIN(5 + wk_PxBase).StatusC <= Cn_Status5 And CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus = "" Then
				CP_SSSMAIN(5 + wk_PxBase).StatusC = CP_SSSMAIN(5 + wk_PxBase).StatusC + 3
				CP_SSSMAIN(5 + wk_PxBase).StatusF = CP_SSSMAIN(5 + wk_PxBase).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5 + wk_PxBase), CL_SSSMAIN(5 + wk_PxBase))
			ElseIf CP_SSSMAIN(5 + wk_PxBase).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			wk_Pos1 = InStr(CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus, Chr(1))
			If wk_Pos1 > 0 Then CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus = Left(CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus, wk_Pos1 - 1) & Mid(CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus, wk_Pos1 + 1)
			If CP_SSSMAIN(6 + wk_PxBase).StatusC >= Cn_Status3 And CP_SSSMAIN(6 + wk_PxBase).StatusC <= Cn_Status5 And CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus = "" Then
				CP_SSSMAIN(6 + wk_PxBase).StatusC = CP_SSSMAIN(6 + wk_PxBase).StatusC + 3
				CP_SSSMAIN(6 + wk_PxBase).StatusF = CP_SSSMAIN(6 + wk_PxBase).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6 + wk_PxBase), CL_SSSMAIN(6 + wk_PxBase))
			ElseIf CP_SSSMAIN(6 + wk_PxBase).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			If wk_Count > 0 Then
				wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "RelCheck")
				wk_Bool = AE_CursorToError_SSSMAIN()
			End If
		Else
			If InStr(CP_SSSMAIN(0).RelCheckStatus, Chr(1)) = 0 Then CP_SSSMAIN(0).RelCheckStatus = CP_SSSMAIN(0).RelCheckStatus & Chr(1)
			If CP_SSSMAIN(0).StatusC >= Cn_Status6 Then
				CP_SSSMAIN(0).StatusC = CP_SSSMAIN(0).StatusC - 3
				CP_SSSMAIN(0).StatusF = CP_SSSMAIN(0).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
			ElseIf CP_SSSMAIN(0).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			If InStr(CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus, Chr(1)) = 0 Then CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus = CP_SSSMAIN(5 + wk_PxBase).RelCheckStatus & Chr(1)
			If CP_SSSMAIN(5 + wk_PxBase).StatusC >= Cn_Status6 Then
				CP_SSSMAIN(5 + wk_PxBase).StatusC = CP_SSSMAIN(5 + wk_PxBase).StatusC - 3
				CP_SSSMAIN(5 + wk_PxBase).StatusF = CP_SSSMAIN(5 + wk_PxBase).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5 + wk_PxBase), CL_SSSMAIN(5 + wk_PxBase))
			ElseIf CP_SSSMAIN(5 + wk_PxBase).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			If InStr(CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus, Chr(1)) = 0 Then CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus = CP_SSSMAIN(6 + wk_PxBase).RelCheckStatus & Chr(1)
			If CP_SSSMAIN(6 + wk_PxBase).StatusC >= Cn_Status6 Then
				CP_SSSMAIN(6 + wk_PxBase).StatusC = CP_SSSMAIN(6 + wk_PxBase).StatusC - 3
				CP_SSSMAIN(6 + wk_PxBase).StatusF = CP_SSSMAIN(6 + wk_PxBase).StatusC
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6 + wk_PxBase), CL_SSSMAIN(6 + wk_PxBase))
			ElseIf CP_SSSMAIN(6 + wk_PxBase).StatusC <= Cn_Status2 Then 
				wk_Count = wk_Count + 1
			End If
			pm_ErrorC = pm_ErrorC + 1
			'UPGRADE_WARNING: オブジェクト SSSMAIN_ErrorMsg() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
			If wk_Count > 0 Then
				wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "RelCheck")
				wk_Bool = AE_CursorToError_SSSMAIN()
			End If
		End If
	End Function
	
	Sub AE_Scrl_SSSMAIN(ByVal pm_DeNo As Short, ByVal pm_SetFocusOk As Short) 'Generated.
		Dim wk_Displacement As Short
		Dim wk_ExTopDe As Short
		Dim wk_ExTx As Short
		Dim wk_NewTx As Short
		Dim wk_NewTx2 As Short
		Dim wk_ww As Short
		Dim Wk_De As Short
		Dim wk_LastDe As Short
		Dim it_InOutMode As Short
		Dim wk_SaveMask As Boolean
		Dim wk_NewPxBase As Short
		Dim wk_ExPxBase As Short
		Dim wk_TxBase As Short
		Dim wk_OutOfDe As Boolean
		If pm_DeNo = PP_SSSMAIN.TopDe Then Exit Sub
		wk_ExTopDe = PP_SSSMAIN.TopDe
		wk_ExTx = PP_SSSMAIN.Tx
		wk_Displacement = AE_ScrlDisp(PP_SSSMAIN, pm_DeNo)
		PP_SSSMAIN.TopDe = PP_SSSMAIN.TopDe + wk_Displacement
		If PP_SSSMAIN.TopDe = wk_ExTopDe Then
			Exit Sub
		Else
            'UPGRADE_WARNING: オブジェクト AE_ScrlBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190826 CHG START
            'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
            AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
            '20190826 CHG END
        End If
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		Wk_De = 0
		Do While Wk_De <= PP_SSSMAIN.MaxDspC
			wk_NewPxBase = 4 + 26 * (Wk_De + PP_SSSMAIN.TopDe) : wk_OutOfDe = False
			If wk_NewPxBase >= PP_SSSMAIN.EBodyPx Then wk_NewPxBase = 4 + 26 * (PP_SSSMAIN.MaxDe) : wk_OutOfDe = True
			wk_ExPxBase = 4 + 26 * (Wk_De + wk_ExTopDe)
			If wk_ExPxBase >= PP_SSSMAIN.EBodyPx Then wk_ExPxBase = 4 + 26 * (PP_SSSMAIN.MaxDe)
			wk_TxBase = 4 + 13 * Wk_De
			wk_ww = 0
			Do While wk_ww < 13
				PP_SSSMAIN.MaskFurigana = True
				If CP_SSSMAIN(wk_NewPxBase + wk_ww).TypeA = Cn_CheckBox Then
					If Trim(CP_SSSMAIN(wk_NewPxBase + wk_ww).TpStr) <> "1" Or wk_OutOfDe Then
                        'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190826 CHG START
                        'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = "0"
                        DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = False
                        '20190826 CHG END
                    Else
                        'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190826 CHG START
                        'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = "1"
                        DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = True
                        '20190826 CHG END
                    End If
                ElseIf wk_OutOfDe Then
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = AE_Format(CP_SSSMAIN(wk_NewPxBase + wk_ww), System.DBNull.Value, 0, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = False
                    '20190826 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190826 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = CP_SSSMAIN(wk_NewPxBase + wk_ww).TpStr
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = True
                    '20190826 CHG END
                End If
                PP_SSSMAIN.MaskFurigana = False
				Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(wk_NewPxBase + wk_ww), CL_SSSMAIN(wk_NewPxBase + wk_ww), wk_TxBase + wk_ww)
				it_InOutMode = AE_GetInOutMode(CP_SSSMAIN(wk_NewPxBase + wk_ww).InOutMode, PP_SSSMAIN.Mode)
				If it_InOutMode <> AE_GetInOutMode(CP_SSSMAIN(wk_ExPxBase + wk_ww).InOutMode, PP_SSSMAIN.Mode) Or (CP_SSSMAIN(wk_NewPxBase + wk_ww).BlockNo) <> (CP_SSSMAIN(wk_ExPxBase + wk_ww).BlockNo) Then
					If CP_SSSMAIN(wk_ExPxBase + wk_ww).TypeA = Cn_OutputOnly Then
					ElseIf CP_SSSMAIN(wk_ExPxBase + wk_ww).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(wk_ExPxBase + wk_ww).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_ExPxBase + wk_ww).TypeA = Cn_CheckBox Then 
						AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww).Enabled = (it_InOutMode >= Cn_InOutMode2)
					Else
						AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww).TabStop = (it_InOutMode >= Cn_InOutMode2) And (AE_IsEnable(CP_SSSMAIN(wk_NewPxBase + wk_ww).BlockNo, PP_SSSMAIN.ActiveBlockNo))
					End If
				End If
				wk_ww = wk_ww + 1
			Loop 
			Wk_De = Wk_De + 1
		Loop 
		PP_SSSMAIN.MaskMode = wk_SaveMask
		wk_LastDe = PP_SSSMAIN.LastDe
		If PP_SSSMAIN.LastDe > wk_LastDe And PP_SSSMAIN.Mode <> 1 Then
			Call AE_ScrlMax(PP_SSSMAIN)
			Call AE_RecalcAll_SSSMAIN()
		End If
		If wk_ExTx >= 0 And wk_ExTx < 4 Then Exit Sub
		If wk_ExTx >= PP_SSSMAIN.NrBodyTx Then Exit Sub
		If Not PP_SSSMAIN.UpDownFlag Then PP_SSSMAIN.ScrlFlag = True
		wk_NewTx = wk_ExTx - 13 * (PP_SSSMAIN.TopDe - wk_ExTopDe)
		If wk_ExTx < 0 Then
		ElseIf wk_NewTx < 4 Then 
			wk_NewTx = 4 + (wk_ExTx - 4) Mod 13
		ElseIf wk_NewTx >= PP_SSSMAIN.NrBodyTx Then 
			wk_NewTx = 4 + 13 * PP_SSSMAIN.MaxDspC + (wk_ExTx - 4) Mod 13
		End If
		Call AE_ScrlMax(PP_SSSMAIN)
		If wk_Displacement > 0 Then
			If PP_SSSMAIN.TopDe < 0 And PP_SSSMAIN.TopDe >= PP_SSSMAIN.MaxDe Then
			ElseIf wk_ExTx >= 0 Then 
				wk_NewTx2 = wk_NewTx
				PP_SSSMAIN.CursorDirection = Cn_Direction3
				Do While wk_NewTx2 < PP_SSSMAIN.NrBodyTx
					If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx2)).TypeA, wk_NewTx2) Then
						If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx2)
						Exit Sub
					End If
					wk_NewTx2 = wk_NewTx2 + 13
				Loop 
				PP_SSSMAIN.CursorDirection = Cn_Direction1
				Do While wk_NewTx < 69
					If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx)).TypeA, wk_NewTx) Then
						If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx)
						Exit Sub
					End If
					wk_NewTx = wk_NewTx + 1
				Loop 
			End If
			wk_NewTx = 4
			PP_SSSMAIN.CursorDirection = Cn_Direction1
			Do While wk_NewTx < 69 And PP_SSSMAIN.TopDe >= 0 And PP_SSSMAIN.TopDe < PP_SSSMAIN.MaxDe
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx)).TypeA, wk_NewTx) Then
					If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx)
					Exit Sub
				End If
				wk_NewTx = wk_NewTx + 1
			Loop 
			If pm_SetFocusOk Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
		ElseIf wk_Displacement < 0 Then 
			If PP_SSSMAIN.TopDe < 0 And PP_SSSMAIN.TopDe >= PP_SSSMAIN.MaxDe Then
			ElseIf wk_ExTx >= 0 Then 
				wk_NewTx2 = wk_NewTx
				Do While wk_NewTx2 >= 13
					If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx2)).TypeA, wk_NewTx2) Then
						If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx2)
						Exit Sub
					End If
					wk_NewTx2 = wk_NewTx2 - 13
				Loop 
				PP_SSSMAIN.CursorDirection = Cn_Direction2
				Do While wk_NewTx >= 0
					If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx)).TypeA, wk_NewTx) Then
						If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx)
						Exit Sub
					End If
					wk_NewTx = wk_NewTx - 1
				Loop 
			End If
			wk_NewTx = PP_SSSMAIN.NrBodyTx - 1
			PP_SSSMAIN.CursorDirection = Cn_Direction2
			Do While wk_NewTx >= 0 And PP_SSSMAIN.TopDe >= 0 And PP_SSSMAIN.TopDe < PP_SSSMAIN.MaxDe
				If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx)).TypeA, wk_NewTx) Then
					If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx)
					Exit Sub
				End If
				wk_NewTx = wk_NewTx - 1
			Loop 
			If pm_SetFocusOk Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
		End If
	End Sub
	
	Function AE_SelectCm_SSSMAIN(ByVal pm_ExMode As Short, ByVal pm_Init As Boolean) As Short 'Generated.
		Dim wk_ReturnCd As Short
		If PP_SSSMAIN.Mode = Cn_Mode2 Then AE_SelectCm_SSSMAIN = Cn_CuCurrent : Exit Function
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "SelectCm") Then AE_SelectCm_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Select() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_ReturnCd = SSSMAIN_Select()
		If wk_ReturnCd = 0 Then
			PP_SSSMAIN.NeglectLostFocusCheck = True
			AE_SelectCm_SSSMAIN = Cn_CuCurrent
			PP_SSSMAIN.NeglectLostFocusCheck = False
		ElseIf wk_ReturnCd = 1 Then 
			PP_SSSMAIN.ChOprtMode = Cn_Mode2
			Call AE_ModeChange_SSSMAIN(Cn_Mode2)
			Call AE_InitValAll_SSSMAIN()
			AE_SelectCm_SSSMAIN = Cn_CuInit
		ElseIf wk_ReturnCd = 2 Then 
			AE_SelectCm_SSSMAIN = AE_UpdateC_SSSMAIN(pm_ExMode, False)
		ElseIf wk_ReturnCd = 3 Then 
			AE_SelectCm_SSSMAIN = AE_Indicate_SSSMAIN(pm_ExMode, False)
		ElseIf wk_ReturnCd = 4 Then 
			AE_SelectCm_SSSMAIN = AE_UpdateC_SSSMAIN(pm_ExMode, False)
		ElseIf wk_ReturnCd = 15 Then 
			AE_SelectCm_SSSMAIN = AE_AppendC_SSSMAIN(pm_ExMode, True)
		Else
			AE_SelectCm_SSSMAIN = AE_AppendC_SSSMAIN(pm_ExMode)
		End If
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Sub AE_SetCheck_SSSMAIN(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_PxBase As Short
		If PP_SSSMAIN.Tx < 0 Then
		ElseIf PP_SSSMAIN.Tx < 4 Then 
			Select Case PP_SSSMAIN.Px
				Case 0
					Call AE_Check_SSSMAIN_FRKEYCD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
						PP_SSSMAIN.DerivedOrigin = "HD_FRKEYCD"
						Call AE_Derived_SSSMAIN_hd_FRMEINM()
					End If
				Case 1
					Call AE_Check_SSSMAIN_FRMEINM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 2
					Call AE_Check_SSSMAIN_OPEID(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 3
					Call AE_Check_SSSMAIN_OPENM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
			End Select
		ElseIf PP_SSSMAIN.Tx < 69 Then 
			wk_PxBase = 26 * PP_SSSMAIN.De
			Select Case PP_SSSMAIN.Px
				Case 4 + wk_PxBase
					Call AE_Check_SSSMAIN_UPDKB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 5 + wk_PxBase
					Call AE_Check_SSSMAIN_MEICDA(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
						PP_SSSMAIN.DerivedOrigin = "BD_MEICDA"
						Call AE_Derived_SSSMAIN_bd_MEICDB(PP_SSSMAIN.De2)
						Call AE_Derived_SSSMAIN_bd_MEINMA(PP_SSSMAIN.De2)
						Call AE_Derived_SSSMAIN_bd_MEINMB(PP_SSSMAIN.De2)
						Call AE_Derived_SSSMAIN_bd_MEINMC(PP_SSSMAIN.De2)
					End If
				Case 6 + wk_PxBase
					Call AE_Check_SSSMAIN_MEICDB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 7 + wk_PxBase
					Call AE_Check_SSSMAIN_DSPORD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 8 + wk_PxBase
					Call AE_Check_SSSMAIN_MEINMA(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 9 + wk_PxBase
					Call AE_Check_SSSMAIN_MEINMB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 10 + wk_PxBase
					Call AE_Check_SSSMAIN_MEINMC(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 11 + wk_PxBase
					Call AE_Check_SSSMAIN_MEISUA(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 12 + wk_PxBase
					Call AE_Check_SSSMAIN_MEISUB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 13 + wk_PxBase
					Call AE_Check_SSSMAIN_MEISUC(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 14 + wk_PxBase
					Call AE_Check_SSSMAIN_MEIKBA(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 15 + wk_PxBase
					Call AE_Check_SSSMAIN_MEIKBB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 16 + wk_PxBase
					Call AE_Check_SSSMAIN_MEIKBC(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
			End Select
		End If
	End Sub
	
	Sub AE_Slist_SSSMAIN() 'Generated.
		Dim wk_Slisted As Object
		Dim wk_PxBase As Short
		Dim wk_TxBase As Short
		wk_PxBase = 26 * PP_SSSMAIN.De
		wk_TxBase = 13 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
		If False Then
		ElseIf PP_SSSMAIN.Tx = 0 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト FRKEYCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = FRKEYCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal))
			PP_SSSMAIN.NeglectLostFocusCheck = False
			'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(wk_Slisted) Then
				PP_SSSMAIN.CursorDest = Cn_Dest9
				PP_SSSMAIN.SlistPx = -1
				PP_SSSMAIN.JustAfterSList = True
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				PP_SSSMAIN.SlistCom = System.DBNull.Value
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CP_SSSMAIN(0).TpStr = wk_Slisted
					CP_SSSMAIN(0).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190828 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + 0) = wk_Slisted
                    AE_Controls(PP_SSSMAIN.CtB + 0).Text = wk_Slisted
                    '20190828 CHG END
                    '20190828 CHG START
                    'Call AE_Check_SSSMAIN_FRKEYCD(AE_Val3(CP_SSSMAIN(0), AE_Controls(PP_SSSMAIN.CtB + 0).ToString()), Cn_Status6, True, True)
                    Call AE_Check_SSSMAIN_FRKEYCD(AE_Val3(CP_SSSMAIN(0), AE_Controls(PP_SSSMAIN.CtB + 0).Text), Cn_Status6, True, True)
                    '20190828 CHG END
                End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf ((PP_SSSMAIN.Tx - 4) Mod 13 = 1) And PP_SSSMAIN.Tx >= 4 And PP_SSSMAIN.Tx < 69 Then 
			If ((PP_SSSMAIN.Tx - 4) \ 13) <> (PP_SSSMAIN.De - PP_SSSMAIN.TopDe) Then
				Call AE_SystemError("AE_Slist に", 600)
			End If
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト MEICDA_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = MEICDA_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
			PP_SSSMAIN.NeglectLostFocusCheck = False
			'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(wk_Slisted) Then
				PP_SSSMAIN.CursorDest = Cn_Dest9
				PP_SSSMAIN.SlistPx = -1
				PP_SSSMAIN.JustAfterSList = True
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				PP_SSSMAIN.SlistCom = System.DBNull.Value
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CP_SSSMAIN(5 + wk_PxBase).TpStr = wk_Slisted
					CP_SSSMAIN(5 + wk_PxBase).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 5 + wk_TxBase) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190828 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + 5 + wk_TxBase) = wk_Slisted
                    AE_Controls(PP_SSSMAIN.CtB + 5 + wk_TxBase).Text = wk_Slisted
                    '20190828 CHG END
                    '20190828 CHG START
                    'Call AE_Check_SSSMAIN_MEICDA(AE_Val3(CP_SSSMAIN(5 + wk_PxBase), AE_Controls(PP_SSSMAIN.CtB + 5 + wk_TxBase).ToString()), Cn_Status6, True, True)
                    Call AE_Check_SSSMAIN_MEICDA(AE_Val3(CP_SSSMAIN(5 + wk_PxBase), AE_Controls(PP_SSSMAIN.CtB + 5 + wk_TxBase).Text), Cn_Status6, True, True)
                    '20190828 CHG END
                End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf ((PP_SSSMAIN.Tx - 4) Mod 13 = 2) And PP_SSSMAIN.Tx >= 4 And PP_SSSMAIN.Tx < 69 Then 
			If ((PP_SSSMAIN.Tx - 4) \ 13) <> (PP_SSSMAIN.De - PP_SSSMAIN.TopDe) Then
				Call AE_SystemError("AE_Slist に", 600)
			End If
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト MEICDB_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = MEICDB_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 26 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN.De2)
			PP_SSSMAIN.NeglectLostFocusCheck = False
			'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If Not IsDbNull(wk_Slisted) Then
				PP_SSSMAIN.CursorDest = Cn_Dest9
				PP_SSSMAIN.SlistPx = -1
				PP_SSSMAIN.JustAfterSList = True
				'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				PP_SSSMAIN.SlistCom = System.DBNull.Value
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CP_SSSMAIN(6 + wk_PxBase).TpStr = wk_Slisted
					CP_SSSMAIN(6 + wk_PxBase).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 6 + wk_TxBase) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190828 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + 6 + wk_TxBase) = wk_Slisted
                    AE_Controls(PP_SSSMAIN.CtB + 6 + wk_TxBase).Text = wk_Slisted
                    '20190828 CHG END
                    '20190828 CHG START
                    'Call AE_Check_SSSMAIN_MEICDB(AE_Val3(CP_SSSMAIN(6 + wk_PxBase), AE_Controls(PP_SSSMAIN.CtB + 6 + wk_TxBase).ToString()), Cn_Status6, True, True)
                    Call AE_Check_SSSMAIN_MEICDB(AE_Val3(CP_SSSMAIN(6 + wk_PxBase), AE_Controls(PP_SSSMAIN.CtB + 6 + wk_TxBase).Text), Cn_Status6, True, True)
                    '20190828 CHG END
                End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		Else
			Beep()
		End If
	End Sub

    '20190826 ADD START
    Function MEICDA_Slist(ByRef PP As clsPP, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
        WLS_MEI1.Text = "名称ｺｰﾄﾞ一覧"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        SSS_MFILCNT = 0

        '20190226
        'Call DB_GetFirst(DBN_MEIMTA, 3, BtrNormal)
        ''* 原則として WLS_MEI1 は最初からデータを表示する.
        ''Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
        'Call DB_GetGrEq(DBN_MEIMTA, 3, FRKEYCD, BtrNormal)
        ''UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Do While (DBSTAT = 0) And (DB_MEIMTA.KEYCD = FRKEYCD)
        '	If DB_MEIMTA.DATKB = "1" Then
        '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDA & " " & DB_MEIMTA.MEINMA)
        '		SSS_MFILCNT = SSS_MFILCNT + 1
        '	End If
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 

        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)

        PP.SlistCom = System.DBNull.Value
        'Call MEIMTA_GetFirst(FRKEYCD, "", "     ")
        Dim pWhere As String = ""
        pWhere = " WHERE KEYCD = '" & FRKEYCD & "'"
        pWhere = pWhere & " ORDER BY MEICDA"
        Call GetRowsCommon("MEIMTA", pWhere)

        SSS_WLSLIST_KETA = DB_MEIMTA.MEICDA.Length

        WLS_MEI1.ShowDialog()
        WLS_MEI1.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト MEICDA_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEICDA_Slist = PP.SlistCom
    End Function

    Function MEICDB_Slist(ByRef PP As clsPP, ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
        '

        WLS_MEI1.Text = "名称コード2一覧"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        Call DB_GetFirst(DBN_MEIMTA, 1, BtrNormal)
        '* 原則として WLS_MEI1 は最初からデータを表示する.
        'Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Select Case Trim(MEICDA)
            Case ""
                Do While DBSTAT = 0
                    'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = FRKEYCD Then CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
                    Call DB_GetNext(DBN_MEIMTA, BtrNormal)
                Loop
            Case Else

                Do While DBSTAT = 0
                    'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = Trim(FRKEYCD) And Trim(DB_MEIMTA.MEICDA) = Trim(MEICDA) Then
                        CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
                    End If
                    Call DB_GetNext(DBN_MEIMTA, BtrNormal)
                Loop

        End Select
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDB)
        '    SSS_WLSLIST_KETA = 3
        WLS_MEI1.ShowDialog()
        WLS_MEI1.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト MEICDB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEICDB_Slist = PP.SlistCom

    End Function
    '20190826 ADD END


    Sub AE_TabStop_SSSMAIN(ByVal pm_FromTx As Short, ByVal pm_ToTx As Short, ByVal pm_SetInOut As Boolean) 'Generated.
		Static wk_Tx As Short
		Static wk_Px As Short
		Static wk_InOutMode As Integer
		If pm_FromTx < 0 Or pm_ToTx < 0 Then Exit Sub
		wk_Tx = pm_FromTx
		Do While wk_Tx <= pm_ToTx
			If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < 69 Then
			Else
				wk_Px = AE_Px(PP_SSSMAIN, wk_Tx)
				wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
				If pm_SetInOut Then CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
				If CP_SSSMAIN(wk_Px).TypeA = Cn_OutputOnly Then
				ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(wk_Px).TypeA = Cn_OptionButtonC Or CP_SSSMAIN(wk_Px).TypeA = Cn_CheckBox Then 
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop = False
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2)
				Else
					AE_Controls(PP_SSSMAIN.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2) And (AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo))
				End If
			End If
			wk_Tx = wk_Tx + 1
		Loop 
	End Sub
	
	Sub AE_Term_SSSMAIN() 'Generated.
	End Sub
	
	Sub AE_UnDoDe_SSSMAIN() 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		Dim wk_SaveLastDe As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If AE_ClearedDe_SSSMAIN(-1) <> PP_SSSMAIN.ActiveDe Then
			PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
		End If
		wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
		PP_SSSMAIN.De = PP_SSSMAIN.UnDoDeNo : PP_SSSMAIN.De2 = PP_SSSMAIN.De
		If PP_SSSMAIN.UnDoDeOp = 1 Then
			If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) And PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then
				wk_SaveLastDe = PP_SSSMAIN.LastDe
				If PP_SSSMAIN.De = PP_SSSMAIN.LastDe Then PP_SSSMAIN.LastDe = PP_SSSMAIN.LastDe + 1
				Call AE_DeRestore_SSSMAIN(PP_SSSMAIN.UnDoDeNo)
				If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) Then
					PP_SSSMAIN.LastDe = wk_SaveLastDe
				Else
					PP_SSSMAIN.DerivedOrigin = ""
					Call AE_RecalcBdDe_SSSMAIN() '(PP_SSSMAIN.De)
				End If
				PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
			Else
				Beep()
			End If
		ElseIf PP_SSSMAIN.UnDoDeOp = 2 Then 
			If PP_SSSMAIN.ActiveDe >= 0 Then
				If PP_SSSMAIN.UnDoDeNo >= PP_SSSMAIN.LastDe Then Beep() : Exit Sub
				Call AE_DeUp_SSSMAIN(PP_SSSMAIN.ActiveDe)
				If PP_SSSMAIN.ActiveDe < PP_SSSMAIN.De Then
					PP_SSSMAIN.De = PP_SSSMAIN.De - 1
					PP_SSSMAIN.De2 = PP_SSSMAIN.De
				End If
			ElseIf PP_SSSMAIN.LastDe > 4 Then 
				wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "InsertDe")
				Exit Sub
			Else
				If PP_SSSMAIN.UnDoDeNo > PP_SSSMAIN.LastDe Then Beep() : Exit Sub
			End If
			Call AE_DeDown_SSSMAIN(PP_SSSMAIN.UnDoDeNo)
			PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
			Call AE_DeRestore_SSSMAIN(PP_SSSMAIN.UnDoDeNo)
			If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) Then
				PP_SSSMAIN.ActiveDe = PP_SSSMAIN.UnDoDeNo
			Else
				PP_SSSMAIN.DerivedOrigin = ""
				Call AE_RecalcBdDe_SSSMAIN() '(PP_SSSMAIN.De)
			End If
			PP_SSSMAIN.ActiveDe = AE_ClearedDe_SSSMAIN(-1)
		Else
			Beep()
		End If
		PP_SSSMAIN.UnDoDeOp = 0
		PP_SSSMAIN.De = wk_SaveDe : PP_SSSMAIN.De2 = wk_SaveDe2
		Call AE_ScrlMax(PP_SSSMAIN)
	End Sub
	
	Sub AE_UnDoItem_SSSMAIN() 'Generated.
		Dim wk_ExVal As Object
		Dim wk_ExStatus As Short
		Dim wk_SaveValue As Object
		Dim wk_SaveStatus As Short
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_ExVal = CP_SSSMAIN(PP_SSSMAIN.Px).CuVal
			wk_ExStatus = CP_SSSMAIN(PP_SSSMAIN.Px).StatusF
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_SaveValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_SaveValue = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
			wk_SaveStatus = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_ExVal = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
			wk_ExStatus = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
			If wk_ExStatus = 0 Then Exit Sub
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_SaveValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_SaveValue = CP_SSSMAIN(PP_SSSMAIN.Px).CuVal
			wk_SaveStatus = CP_SSSMAIN(PP_SSSMAIN.Px).StatusF
		End If
		If wk_ExStatus = Cn_Status8 Then
			Call AE_ClearItm_SSSMAIN(False)
		Else
			PP_SSSMAIN.MaskMode = True
			CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = AE_Format(CP_SSSMAIN(PP_SSSMAIN.Px), wk_ExVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, PP_SSSMAIN.Px, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr, CP_SSSMAIN(PP_SSSMAIN.Px).TypeA, True)
			Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px))
            PP_SSSMAIN.MaskMode = False
            '20190826 CHG START
            ''UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
            '         'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         AE_StatusBar(PP_SSSMAIN.ScX) = ""
            AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
            AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            '20190826 CHG END

            Call AE_SetCheck_SSSMAIN(wk_ExVal, wk_ExStatus, False)
		End If
		Call AE_CursorCurrent_SSSMAIN()
		'UPGRADE_WARNING: オブジェクト wk_SaveValue の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().ExVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(PP_SSSMAIN.Px).ExVal = wk_SaveValue
		CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus = wk_SaveStatus
	End Sub
	
	Function AE_UpdateC_SSSMAIN(ByVal pm_ExMode As Short, ByVal pm_NextRec As Short) As Short 'Generated.
		If PP_SSSMAIN.Mode <> Cn_Mode2 And PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And pm_NextRec <> 1000 Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "UpdateC") Then AE_UpdateC_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		PP_SSSMAIN.ChOprtMode = Cn_Mode4
		'UPGRADE_WARNING: オブジェクト SSSMAIN_UpdateC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSMAIN_UpdateC() Then
			Call AE_ModeChange_SSSMAIN(PP_SSSMAIN.ChOprtMode)
			If PP_SSSMAIN.Mode = PP_SSSMAIN.ChOprtMode Then
				If pm_NextRec = 1000 Then
					Call AE_RecalcAll_SSSMAIN()
				ElseIf pm_NextRec = True Then 
					wk_Int = AE_NextCm_SSSMAIN(False)
				ElseIf pm_NextRec = False Then 
					wk_Int = AE_Current_SSSMAIN()
				End If
				Call AE_ClearInitValStatus_SSSMAIN()
				AE_UpdateC_SSSMAIN = Cn_CuInit
			Else
				Call AE_ModeChange_SSSMAIN(pm_ExMode)
				AE_UpdateC_SSSMAIN = Cn_CuCurrent
			End If
		Else
			Call AE_ModeChange_SSSMAIN(pm_ExMode)
			AE_UpdateC_SSSMAIN = Cn_CuCurrent
		End If
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Function AE_WindowProc_SSSMAIN(ByVal hw As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer 'Generated.
		Const WM_CONTEXTMENU As Short = &H7Bs
		If uMsg = WM_CONTEXTMENU Then
			AE_WindowProc_SSSMAIN = 1
		Else
			AE_WindowProc_SSSMAIN = CallWindowProc(PP_SSSMAIN.lpPrevWndProc, hw, uMsg, wParam, lParam)
		End If
	End Function
	
	Sub AE_WindowProcSet_SSSMAIN() 'Generated.
		If Cn_DebugMode Then Exit Sub
		Dim wk_Tx As Short
        For wk_Tx = 0 To PP_SSSMAIN.ControlsC - 1
            'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
            '20190826 DEL START
            'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
            '20190826 DEL END
        Next wk_Tx
        '20190826 DEL START
        '      'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        '      PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_StatusBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_ModeBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '20190826 DEL END
    End Sub

    Sub DP_SSSMAIN_DSPORD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(7 + wk_PxBase), AE_Val3(CP_SSSMAIN(7 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(7 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(7 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(7 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(7 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(7 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(7 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(7 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(7 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(7 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(7 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(7 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(7 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(7 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7 + wk_PxBase), CL_SSSMAIN(7 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(7 + wk_PxBase).CuVal = V
		CP_SSSMAIN(7 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(7 + wk_PxBase), CP_SSSMAIN(7 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 7 + wk_PxBase, CP_SSSMAIN(7 + wk_PxBase).TpStr, CP_SSSMAIN(7 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEICDA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(5 + wk_PxBase), AE_Val3(CP_SSSMAIN(5 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(5 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(5 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(5 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(5 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(5 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(5 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END

            CP_SSSMAIN(5 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(5 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(5 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(5 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(5 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(5 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(5 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5 + wk_PxBase), CL_SSSMAIN(5 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(5 + wk_PxBase).CuVal = V
		CP_SSSMAIN(5 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(5 + wk_PxBase), CP_SSSMAIN(5 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 5 + wk_PxBase, CP_SSSMAIN(5 + wk_PxBase).TpStr, CP_SSSMAIN(5 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEICDB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(6 + wk_PxBase), AE_Val3(CP_SSSMAIN(6 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(6 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(6 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(6 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(6 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(6 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(6 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END

            CP_SSSMAIN(6 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(6 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(6 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(6 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(6 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(6 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(6 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6 + wk_PxBase), CL_SSSMAIN(6 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(6 + wk_PxBase).CuVal = V
		CP_SSSMAIN(6 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(6 + wk_PxBase), CP_SSSMAIN(6 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 6 + wk_PxBase, CP_SSSMAIN(6 + wk_PxBase).TpStr, CP_SSSMAIN(6 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEIKBA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(14 + wk_PxBase), AE_Val3(CP_SSSMAIN(14 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(14 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(14 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(14 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END

            CP_SSSMAIN(14 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(14 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(14 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(14 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(14 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(14 + wk_PxBase), CL_SSSMAIN(14 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(14 + wk_PxBase).CuVal = V
		CP_SSSMAIN(14 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(14 + wk_PxBase), CP_SSSMAIN(14 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 14 + wk_PxBase, CP_SSSMAIN(14 + wk_PxBase).TpStr, CP_SSSMAIN(14 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEIKBB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(15 + wk_PxBase), AE_Val3(CP_SSSMAIN(15 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(15 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(15 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(15 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END

            CP_SSSMAIN(15 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(15 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(15 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(15 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(15 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(15 + wk_PxBase), CL_SSSMAIN(15 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(15 + wk_PxBase).CuVal = V
		CP_SSSMAIN(15 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(15 + wk_PxBase), CP_SSSMAIN(15 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 15 + wk_PxBase, CP_SSSMAIN(15 + wk_PxBase).TpStr, CP_SSSMAIN(15 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEIKBC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(16 + wk_PxBase), AE_Val3(CP_SSSMAIN(16 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(16 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(16 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(16 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(16 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(16 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(16 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(16 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(16 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(16 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(16 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(16 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(16 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(16 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(16 + wk_PxBase), CL_SSSMAIN(16 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(16 + wk_PxBase).CuVal = V
		CP_SSSMAIN(16 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(16 + wk_PxBase), CP_SSSMAIN(16 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 16 + wk_PxBase, CP_SSSMAIN(16 + wk_PxBase).TpStr, CP_SSSMAIN(16 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEINMA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(8 + wk_PxBase), AE_Val3(CP_SSSMAIN(8 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(8 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(8 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(8 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(8 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(8 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(8 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(8 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(8 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8 + wk_PxBase), CL_SSSMAIN(8 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(8 + wk_PxBase).CuVal = V
		CP_SSSMAIN(8 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(8 + wk_PxBase), CP_SSSMAIN(8 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 8 + wk_PxBase, CP_SSSMAIN(8 + wk_PxBase).TpStr, CP_SSSMAIN(8 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEINMB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(9 + wk_PxBase), AE_Val3(CP_SSSMAIN(9 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(9 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(9 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(9 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(9 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(9 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(9 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(9 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(9 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9 + wk_PxBase), CL_SSSMAIN(9 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(9 + wk_PxBase).CuVal = V
		CP_SSSMAIN(9 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(9 + wk_PxBase), CP_SSSMAIN(9 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 9 + wk_PxBase, CP_SSSMAIN(9 + wk_PxBase).TpStr, CP_SSSMAIN(9 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEINMC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(10 + wk_PxBase), AE_Val3(CP_SSSMAIN(10 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(10 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(10 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(10 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(10 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(10 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(10 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(10 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(10 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(10 + wk_PxBase), CL_SSSMAIN(10 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(10 + wk_PxBase).CuVal = V
		CP_SSSMAIN(10 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(10 + wk_PxBase), CP_SSSMAIN(10 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 10 + wk_PxBase, CP_SSSMAIN(10 + wk_PxBase).TpStr, CP_SSSMAIN(10 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEISUA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(11 + wk_PxBase), AE_Val3(CP_SSSMAIN(11 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(11 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(11 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(11 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(11 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(11 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(11 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(11 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(11 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(11 + wk_PxBase), CL_SSSMAIN(11 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(11 + wk_PxBase).CuVal = V
		CP_SSSMAIN(11 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(11 + wk_PxBase), CP_SSSMAIN(11 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 11 + wk_PxBase, CP_SSSMAIN(11 + wk_PxBase).TpStr, CP_SSSMAIN(11 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEISUB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(12 + wk_PxBase), AE_Val3(CP_SSSMAIN(12 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(12 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(12 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(12 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(12 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(12 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(12 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(12 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(12 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(12 + wk_PxBase), CL_SSSMAIN(12 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(12 + wk_PxBase).CuVal = V
		CP_SSSMAIN(12 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(12 + wk_PxBase), CP_SSSMAIN(12 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 12 + wk_PxBase, CP_SSSMAIN(12 + wk_PxBase).TpStr, CP_SSSMAIN(12 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEISUC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(13 + wk_PxBase), AE_Val3(CP_SSSMAIN(13 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(13 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(13 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(13 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(13 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(13 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(13 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(13 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(13 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(13 + wk_PxBase), CL_SSSMAIN(13 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(13 + wk_PxBase).CuVal = V
		CP_SSSMAIN(13 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(13 + wk_PxBase), CP_SSSMAIN(13 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 13 + wk_PxBase, CP_SSSMAIN(13 + wk_PxBase).TpStr, CP_SSSMAIN(13 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_UPDKB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(4 + wk_PxBase), AE_Val3(CP_SSSMAIN(4 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(4 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(4 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(4 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(4 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(4 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(4 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(4 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(4 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(4 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(4 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(4 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(4 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(4 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4 + wk_PxBase), CL_SSSMAIN(4 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(4 + wk_PxBase).CuVal = V
		CP_SSSMAIN(4 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(4 + wk_PxBase), CP_SSSMAIN(4 + wk_PxBase).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 4 + wk_PxBase, CP_SSSMAIN(4 + wk_PxBase).TpStr, CP_SSSMAIN(4 + wk_PxBase).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_KEYCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(17 + wk_PxBase), AE_Val3(CP_SSSMAIN(17 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(17 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(17 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(17 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(17 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(17 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(17 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(17 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(17 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(17 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(17 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(17 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(17 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(17 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(17 + wk_PxBase), CL_SSSMAIN(17 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(17 + wk_PxBase).CuVal = V
		CP_SSSMAIN(17 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(17 + wk_PxBase), CP_SSSMAIN(17 + wk_PxBase).CuVal, 0, True)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_MEIKMKNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(18 + wk_PxBase), AE_Val3(CP_SSSMAIN(18 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(18 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(18 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(18 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(18 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(18 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(18 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(18 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(18 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(18 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(18 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(18 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(18 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(18 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(18 + wk_PxBase), CL_SSSMAIN(18 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(18 + wk_PxBase).CuVal = V
		CP_SSSMAIN(18 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(18 + wk_PxBase), CP_SSSMAIN(18 + wk_PxBase).CuVal, 0, True)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_V_DATKB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim wk_PxBase As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		wk_PxBase = 26 * pm_De
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(19 + wk_PxBase), AE_Val3(CP_SSSMAIN(19 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(19 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(19 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(19 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(19 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(19 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(19 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(19 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(19 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(19 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(19 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(19 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(19 + wk_PxBase).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(19 + wk_PxBase).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(19 + wk_PxBase), CL_SSSMAIN(19 + wk_PxBase))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(19 + wk_PxBase).CuVal = V
		CP_SSSMAIN(19 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(19 + wk_PxBase), CP_SSSMAIN(19 + wk_PxBase).CuVal, 0, True)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub

    '20190902 CHG START
    'Sub DP_SSSMAIN_V_DSPORD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '    Dim V As Object
    '    Dim wk_SaveMask As Boolean
    '    Dim wk_PxBase As Short
    '    wk_SaveMask = PP_SSSMAIN.MaskMode
    '    PP_SSSMAIN.MaskMode = True
    '    wk_PxBase = 26 * pm_De
    '    'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    V = AE_NormData(CP_SSSMAIN(29 + wk_PxBase), AE_Val3(CP_SSSMAIN(29 + wk_PxBase), CStr(DBItem)))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(29 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '20190827 CHG START
    '    'If CP_SSSMAIN(29 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(29 + wk_PxBase).StatusC <> Cn_Status8 Then
    '    If IsDBNull(CP_SSSMAIN(29 + wk_PxBase).CuVal) = False _
    '        AndAlso IsDBNull(V) = False _
    '        AndAlso CP_SSSMAIN(29 + wk_PxBase).CuVal <> V _
    '        Or CP_SSSMAIN(29 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        '20190827 CHG END
    '        CP_SSSMAIN(29 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(29 + wk_PxBase).StatusF = Cn_Status6
    '        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    ElseIf (IsDBNull(CP_SSSMAIN(29 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(29 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        CP_SSSMAIN(29 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(29 + wk_PxBase).StatusF = Cn_Status6
    '    End If
    '    CP_SSSMAIN(29 + wk_PxBase).CheckRtnCode = 0
    '    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(29 + wk_PxBase), CL_SSSMAIN(29 + wk_PxBase))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    CP_SSSMAIN(29 + wk_PxBase).CuVal = V
    '    CP_SSSMAIN(29 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(29 + wk_PxBase), CP_SSSMAIN(29 + wk_PxBase).CuVal, 0, True)
    '    PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_DSPORD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(7 + wk_PxBase), AE_Val3(CP_SSSMAIN(7 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(29 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(29 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(29 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(7 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(7 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(7 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(7 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(7 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(7 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(7 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(7 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(7 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(7 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7 + wk_PxBase), CL_SSSMAIN(7 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(7 + wk_PxBase).CuVal = V
        CP_SSSMAIN(7 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(7 + wk_PxBase), CP_SSSMAIN(7 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190902 CHG START
    'Sub DP_SSSMAIN_V_MEIKBA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '    Dim V As Object
    '    Dim wk_SaveMask As Boolean
    '    Dim wk_PxBase As Short
    '    wk_SaveMask = PP_SSSMAIN.MaskMode
    '    PP_SSSMAIN.MaskMode = True
    '    wk_PxBase = 26 * pm_De
    '    'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    V = AE_NormData(CP_SSSMAIN(20 + wk_PxBase), AE_Val3(CP_SSSMAIN(20 + wk_PxBase), CStr(DBItem)))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(20 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '20190827 CHG START
    '    'If CP_SSSMAIN(20 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(20 + wk_PxBase).StatusC <> Cn_Status8 Then
    '    If IsDBNull(CP_SSSMAIN(20 + wk_PxBase).CuVal) = False _
    '        AndAlso IsDBNull(V) = False _
    '        AndAlso CP_SSSMAIN(20 + wk_PxBase).CuVal <> V _
    '        Or CP_SSSMAIN(20 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        '20190827 CHG END
    '        CP_SSSMAIN(20 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(20 + wk_PxBase).StatusF = Cn_Status6
    '        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    ElseIf (IsDBNull(CP_SSSMAIN(20 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(20 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        CP_SSSMAIN(20 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(20 + wk_PxBase).StatusF = Cn_Status6
    '    End If
    '    CP_SSSMAIN(20 + wk_PxBase).CheckRtnCode = 0
    '    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(20 + wk_PxBase), CL_SSSMAIN(20 + wk_PxBase))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    CP_SSSMAIN(20 + wk_PxBase).CuVal = V
    '    CP_SSSMAIN(20 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(20 + wk_PxBase), CP_SSSMAIN(20 + wk_PxBase).CuVal, 0, True)
    '    PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEIKBA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(14 + wk_PxBase), AE_Val3(CP_SSSMAIN(14 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(20 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(20 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(20 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(14 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(14 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(14 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(14 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(14 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(14 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(14 + wk_PxBase), CL_SSSMAIN(14 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(14 + wk_PxBase).CuVal = V
        CP_SSSMAIN(14 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(14 + wk_PxBase), CP_SSSMAIN(14 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190902 CHG START
    '   Sub DP_SSSMAIN_V_MEIKBB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '	Dim V As Object
    '	Dim wk_SaveMask As Boolean
    '	Dim wk_PxBase As Short
    '	wk_SaveMask = PP_SSSMAIN.MaskMode
    '	PP_SSSMAIN.MaskMode = True
    '	wk_PxBase = 26 * pm_De
    '	'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	V = AE_NormData(CP_SSSMAIN(21 + wk_PxBase), AE_Val3(CP_SSSMAIN(21 + wk_PxBase), CStr(DBItem)))
    '       'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(21 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '20190827 CHG START
    '       'If CP_SSSMAIN(21 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(21 + wk_PxBase).StatusC <> Cn_Status8 Then
    '       If IsDBNull(CP_SSSMAIN(21 + wk_PxBase).CuVal) = False _
    '           AndAlso IsDBNull(V) = False _
    '           AndAlso CP_SSSMAIN(21 + wk_PxBase).CuVal <> V _
    '           Or CP_SSSMAIN(21 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           '20190827 CHG END
    '           CP_SSSMAIN(21 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(21 + wk_PxBase).StatusF = Cn_Status6
    '           'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '       ElseIf (IsDBNull(CP_SSSMAIN(21 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(21 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           CP_SSSMAIN(21 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(21 + wk_PxBase).StatusF = Cn_Status6
    '	End If
    '	CP_SSSMAIN(21 + wk_PxBase).CheckRtnCode = 0
    '	Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(21 + wk_PxBase), CL_SSSMAIN(21 + wk_PxBase))
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	CP_SSSMAIN(21 + wk_PxBase).CuVal = V
    '	CP_SSSMAIN(21 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(21 + wk_PxBase), CP_SSSMAIN(21 + wk_PxBase).CuVal, 0, True)
    '	PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEIKBB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(15 + wk_PxBase), AE_Val3(CP_SSSMAIN(15 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(21 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(21 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(21 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(15 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(15 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(15 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(15 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(15 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(15 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(15 + wk_PxBase), CL_SSSMAIN(15 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(15 + wk_PxBase).CuVal = V
        CP_SSSMAIN(15 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(15 + wk_PxBase), CP_SSSMAIN(15 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190902 CHG START
    'Sub DP_SSSMAIN_V_MEIKBC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '    Dim V As Object
    '    Dim wk_SaveMask As Boolean
    '    Dim wk_PxBase As Short
    '    wk_SaveMask = PP_SSSMAIN.MaskMode
    '    PP_SSSMAIN.MaskMode = True
    '    wk_PxBase = 26 * pm_De
    '    'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    V = AE_NormData(CP_SSSMAIN(22 + wk_PxBase), AE_Val3(CP_SSSMAIN(22 + wk_PxBase), CStr(DBItem)))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(22 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '20190827 CHG START
    '    'If CP_SSSMAIN(22 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(22 + wk_PxBase).StatusC <> Cn_Status8 Then
    '    If IsDBNull(CP_SSSMAIN(22 + wk_PxBase).CuVal) = False _
    '        AndAlso IsDBNull(V) = False _
    '        AndAlso CP_SSSMAIN(22 + wk_PxBase).CuVal <> V _
    '        Or CP_SSSMAIN(22 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        '20190827 CHG END
    '        CP_SSSMAIN(22 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(22 + wk_PxBase).StatusF = Cn_Status6
    '        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    ElseIf (IsDBNull(CP_SSSMAIN(22 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(22 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        CP_SSSMAIN(22 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(22 + wk_PxBase).StatusF = Cn_Status6
    '    End If
    '    CP_SSSMAIN(22 + wk_PxBase).CheckRtnCode = 0
    '    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(22 + wk_PxBase), CL_SSSMAIN(22 + wk_PxBase))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    CP_SSSMAIN(22 + wk_PxBase).CuVal = V
    '    CP_SSSMAIN(22 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(22 + wk_PxBase), CP_SSSMAIN(22 + wk_PxBase).CuVal, 0, True)
    '    PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEIKBC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(16 + wk_PxBase), AE_Val3(CP_SSSMAIN(16 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(22 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(22 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(22 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(16 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(16 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(16 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(16 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(16 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(16 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(16 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(16 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(16 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(16 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(16 + wk_PxBase), CL_SSSMAIN(16 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(16 + wk_PxBase).CuVal = V
        CP_SSSMAIN(16 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(16 + wk_PxBase), CP_SSSMAIN(16 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190830 CHG START
    'Sub DP_SSSMAIN_V_MEINMA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '	Dim V As Object
    '	Dim wk_SaveMask As Boolean
    '	Dim wk_PxBase As Short
    '	wk_SaveMask = PP_SSSMAIN.MaskMode
    '	PP_SSSMAIN.MaskMode = True
    '	wk_PxBase = 26 * pm_De
    '	'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	V = AE_NormData(CP_SSSMAIN(23 + wk_PxBase), AE_Val3(CP_SSSMAIN(23 + wk_PxBase), CStr(DBItem)))
    '       'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(23 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '20190827 CHG START
    '       'If CP_SSSMAIN(23 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(23 + wk_PxBase).StatusC <> Cn_Status8 Then
    '       If IsDBNull(CP_SSSMAIN(23 + wk_PxBase).CuVal) = False _
    '           AndAlso IsDBNull(V) = False _
    '           AndAlso CP_SSSMAIN(23 + wk_PxBase).CuVal <> V _
    '           Or CP_SSSMAIN(23 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           '20190827 CHG END
    '           CP_SSSMAIN(23 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(23 + wk_PxBase).StatusF = Cn_Status6
    '           'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '       ElseIf (IsDBNull(CP_SSSMAIN(23 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(23 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           CP_SSSMAIN(23 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(23 + wk_PxBase).StatusF = Cn_Status6
    '	End If
    '	CP_SSSMAIN(23 + wk_PxBase).CheckRtnCode = 0
    '	Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(23 + wk_PxBase), CL_SSSMAIN(23 + wk_PxBase))
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	CP_SSSMAIN(23 + wk_PxBase).CuVal = V
    '	CP_SSSMAIN(23 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(23 + wk_PxBase), CP_SSSMAIN(23 + wk_PxBase).CuVal, 0, True)
    '	PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEINMA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(8 + wk_PxBase), AE_Val3(CP_SSSMAIN(8 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(23 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(23 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(23 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(8 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(8 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(8 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(8 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(8 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(8 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8 + wk_PxBase), CL_SSSMAIN(8 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(8 + wk_PxBase).CuVal = V
        CP_SSSMAIN(8 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(8 + wk_PxBase), CP_SSSMAIN(8 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190830 CHG END

    '20190830 CHG START
    '   Sub DP_SSSMAIN_V_MEINMB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '	Dim V As Object
    '	Dim wk_SaveMask As Boolean
    '	Dim wk_PxBase As Short
    '	wk_SaveMask = PP_SSSMAIN.MaskMode
    '	PP_SSSMAIN.MaskMode = True
    '	wk_PxBase = 26 * pm_De
    '	'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	V = AE_NormData(CP_SSSMAIN(24 + wk_PxBase), AE_Val3(CP_SSSMAIN(24 + wk_PxBase), CStr(DBItem)))
    '       'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(24 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '20190827 CHG START
    '       'If CP_SSSMAIN(24 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(24 + wk_PxBase).StatusC <> Cn_Status8 Then
    '       If IsDBNull(CP_SSSMAIN(24 + wk_PxBase).CuVal) = False _
    '           AndAlso IsDBNull(V) = False _
    '           AndAlso CP_SSSMAIN(24 + wk_PxBase).CuVal <> V _
    '           Or CP_SSSMAIN(24 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           '20190827 CHG END
    '           CP_SSSMAIN(24 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(24 + wk_PxBase).StatusF = Cn_Status6
    '           'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '       ElseIf (IsDBNull(CP_SSSMAIN(24 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(24 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           CP_SSSMAIN(24 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(24 + wk_PxBase).StatusF = Cn_Status6
    '	End If
    '	CP_SSSMAIN(24 + wk_PxBase).CheckRtnCode = 0
    '	Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(24 + wk_PxBase), CL_SSSMAIN(24 + wk_PxBase))
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	CP_SSSMAIN(24 + wk_PxBase).CuVal = V
    '	CP_SSSMAIN(24 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(24 + wk_PxBase), CP_SSSMAIN(24 + wk_PxBase).CuVal, 0, True)
    '	PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEINMB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(9 + wk_PxBase), AE_Val3(CP_SSSMAIN(9 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(24 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(24 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(24 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(9 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(9 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(9 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(9 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(9 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(9 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9 + wk_PxBase), CL_SSSMAIN(9 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(9 + wk_PxBase).CuVal = V
        CP_SSSMAIN(9 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(9 + wk_PxBase), CP_SSSMAIN(9 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190830 CHG END

    '20190830 CHG START
    'Sub DP_SSSMAIN_V_MEINMC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '    Dim V As Object
    '    Dim wk_SaveMask As Boolean
    '    Dim wk_PxBase As Short
    '    wk_SaveMask = PP_SSSMAIN.MaskMode
    '    PP_SSSMAIN.MaskMode = True
    '    wk_PxBase = 26 * pm_De
    '    'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    V = AE_NormData(CP_SSSMAIN(25 + wk_PxBase), AE_Val3(CP_SSSMAIN(25 + wk_PxBase), CStr(DBItem)))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(25 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '20190827 CHG START
    '    'If CP_SSSMAIN(25 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(25 + wk_PxBase).StatusC <> Cn_Status8 Then
    '    If IsDBNull(CP_SSSMAIN(25 + wk_PxBase).CuVal) = False _
    '        AndAlso IsDBNull(V) = False _
    '        AndAlso CP_SSSMAIN(25 + wk_PxBase).CuVal <> V _
    '        Or CP_SSSMAIN(25 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        '20190827 CHG END
    '        CP_SSSMAIN(25 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(25 + wk_PxBase).StatusF = Cn_Status6
    '        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    ElseIf (IsDBNull(CP_SSSMAIN(25 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(25 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        CP_SSSMAIN(25 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(25 + wk_PxBase).StatusF = Cn_Status6
    '    End If
    '    CP_SSSMAIN(25 + wk_PxBase).CheckRtnCode = 0
    '    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(25 + wk_PxBase), CL_SSSMAIN(25 + wk_PxBase))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    CP_SSSMAIN(25 + wk_PxBase).CuVal = V
    '    CP_SSSMAIN(25 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(25 + wk_PxBase), CP_SSSMAIN(25 + wk_PxBase).CuVal, 0, True)
    '    PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEINMC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(10 + wk_PxBase), AE_Val3(CP_SSSMAIN(10 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(25 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(25 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(25 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(10 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(10 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(10 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(10 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(10 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(10 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(10 + wk_PxBase), CL_SSSMAIN(10 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(10 + wk_PxBase).CuVal = V
        CP_SSSMAIN(10 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(10 + wk_PxBase), CP_SSSMAIN(10 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190830 CHG END

    '20190902 CHG START
    'Sub DP_SSSMAIN_V_MEISUA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '    Dim V As Object
    '    Dim wk_SaveMask As Boolean
    '    Dim wk_PxBase As Short
    '    wk_SaveMask = PP_SSSMAIN.MaskMode
    '    PP_SSSMAIN.MaskMode = True
    '    wk_PxBase = 26 * pm_De
    '    'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    V = AE_NormData(CP_SSSMAIN(26 + wk_PxBase), AE_Val3(CP_SSSMAIN(26 + wk_PxBase), CStr(DBItem)))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(26 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '20190827 CHG START
    '    'If CP_SSSMAIN(26 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(26 + wk_PxBase).StatusC <> Cn_Status8 Then
    '    If IsDBNull(CP_SSSMAIN(26 + wk_PxBase).CuVal) = False _
    '        AndAlso IsDBNull(V) = False _
    '        AndAlso CP_SSSMAIN(26 + wk_PxBase).CuVal <> V _
    '        Or CP_SSSMAIN(26 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        '20190827 CHG END
    '        CP_SSSMAIN(26 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(26 + wk_PxBase).StatusF = Cn_Status6
    '        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '    ElseIf (IsDBNull(CP_SSSMAIN(26 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(26 + wk_PxBase).StatusC <> Cn_Status8 Then
    '        CP_SSSMAIN(26 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(26 + wk_PxBase).StatusF = Cn_Status6
    '    End If
    '    CP_SSSMAIN(26 + wk_PxBase).CheckRtnCode = 0
    '    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(26 + wk_PxBase), CL_SSSMAIN(26 + wk_PxBase))
    '    'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    CP_SSSMAIN(26 + wk_PxBase).CuVal = V
    '    CP_SSSMAIN(26 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(26 + wk_PxBase), CP_SSSMAIN(26 + wk_PxBase).CuVal, 0, True)
    '    PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEISUA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(11 + wk_PxBase), AE_Val3(CP_SSSMAIN(11 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(26 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(26 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(26 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(11 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(11 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(11 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(11 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(11 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(11 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(11 + wk_PxBase), CL_SSSMAIN(11 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(11 + wk_PxBase).CuVal = V
        CP_SSSMAIN(11 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(11 + wk_PxBase), CP_SSSMAIN(11 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190902 CHG START
    '   Sub DP_SSSMAIN_V_MEISUB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '	Dim V As Object
    '	Dim wk_SaveMask As Boolean
    '	Dim wk_PxBase As Short
    '	wk_SaveMask = PP_SSSMAIN.MaskMode
    '	PP_SSSMAIN.MaskMode = True
    '	wk_PxBase = 26 * pm_De
    '	'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	V = AE_NormData(CP_SSSMAIN(27 + wk_PxBase), AE_Val3(CP_SSSMAIN(27 + wk_PxBase), CStr(DBItem)))
    '       'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(27 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '20190827 CHG START
    '       'If CP_SSSMAIN(27 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(27 + wk_PxBase).StatusC <> Cn_Status8 Then
    '       If IsDBNull(CP_SSSMAIN(27 + wk_PxBase).CuVal) = False _
    '           AndAlso IsDBNull(V) = False _
    '           AndAlso CP_SSSMAIN(27 + wk_PxBase).CuVal <> V _
    '           Or CP_SSSMAIN(27 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           '20190827 CHG END
    '           CP_SSSMAIN(27 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(27 + wk_PxBase).StatusF = Cn_Status6
    '           'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '       ElseIf (IsDBNull(CP_SSSMAIN(27 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(27 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           CP_SSSMAIN(27 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(27 + wk_PxBase).StatusF = Cn_Status6
    '	End If
    '	CP_SSSMAIN(27 + wk_PxBase).CheckRtnCode = 0
    '	Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(27 + wk_PxBase), CL_SSSMAIN(27 + wk_PxBase))
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	CP_SSSMAIN(27 + wk_PxBase).CuVal = V
    '	CP_SSSMAIN(27 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(27 + wk_PxBase), CP_SSSMAIN(27 + wk_PxBase).CuVal, 0, True)
    '	PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEISUB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(12 + wk_PxBase), AE_Val3(CP_SSSMAIN(12 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(27 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(27 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(27 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(12 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(12 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(12 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(12 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(12 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(12 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(12 + wk_PxBase), CL_SSSMAIN(12 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(12 + wk_PxBase).CuVal = V
        CP_SSSMAIN(12 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(12 + wk_PxBase), CP_SSSMAIN(12 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    '20190902 CHG START
    '   Sub DP_SSSMAIN_V_MEISUC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
    '	Dim V As Object
    '	Dim wk_SaveMask As Boolean
    '	Dim wk_PxBase As Short
    '	wk_SaveMask = PP_SSSMAIN.MaskMode
    '	PP_SSSMAIN.MaskMode = True
    '	wk_PxBase = 26 * pm_De
    '	'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	V = AE_NormData(CP_SSSMAIN(28 + wk_PxBase), AE_Val3(CP_SSSMAIN(28 + wk_PxBase), CStr(DBItem)))
    '       'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(28 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       '20190827 CHG START
    '       'If CP_SSSMAIN(28 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(28 + wk_PxBase).StatusC <> Cn_Status8 Then
    '       If IsDBNull(CP_SSSMAIN(28 + wk_PxBase).CuVal) = False _
    '           AndAlso IsDBNull(V) = False _
    '           AndAlso CP_SSSMAIN(28 + wk_PxBase).CuVal <> V _
    '           Or CP_SSSMAIN(28 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           '20190827 CHG END
    '           CP_SSSMAIN(28 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(28 + wk_PxBase).StatusF = Cn_Status6
    '           'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
    '       ElseIf (IsDBNull(CP_SSSMAIN(28 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(28 + wk_PxBase).StatusC <> Cn_Status8 Then
    '           CP_SSSMAIN(28 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(28 + wk_PxBase).StatusF = Cn_Status6
    '	End If
    '	CP_SSSMAIN(28 + wk_PxBase).CheckRtnCode = 0
    '	Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(28 + wk_PxBase), CL_SSSMAIN(28 + wk_PxBase))
    '	'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	CP_SSSMAIN(28 + wk_PxBase).CuVal = V
    '	CP_SSSMAIN(28 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(28 + wk_PxBase), CP_SSSMAIN(28 + wk_PxBase).CuVal, 0, True)
    '	PP_SSSMAIN.MaskMode = wk_SaveMask
    'End Sub
    Sub DP_SSSMAIN_V_MEISUC(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 26 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(13 + wk_PxBase), AE_Val3(CP_SSSMAIN(13 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(28 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(28 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(28 + wk_PxBase).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) = False _
            AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(13 + wk_PxBase).CuVal <> V _
            Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(13 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(13 + wk_PxBase).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(13 + wk_PxBase).StatusC = Cn_Status6 : CP_SSSMAIN(13 + wk_PxBase).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(13 + wk_PxBase).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(13 + wk_PxBase), CL_SSSMAIN(13 + wk_PxBase))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        CP_SSSMAIN(13 + wk_PxBase).CuVal = V
        CP_SSSMAIN(13 + wk_PxBase).TpStr = AE_Format(CP_SSSMAIN(13 + wk_PxBase), CP_SSSMAIN(13 + wk_PxBase).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub
    '20190902 CHG END

    Sub DP_SSSMAIN_FRKEYCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(0), AE_Val3(CP_SSSMAIN(0), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(0).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(0).CuVal) = False AndAlso IsDBNull(V) = False AndAlso CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(0).StatusC = Cn_Status6 : CP_SSSMAIN(0).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(0).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(0).StatusC = Cn_Status6 : CP_SSSMAIN(0).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(0).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(0).CuVal = V
		CP_SSSMAIN(0).TpStr = AE_Format(CP_SSSMAIN(0), CP_SSSMAIN(0).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 0, CP_SSSMAIN(0).TpStr, CP_SSSMAIN(0).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_FRMEINM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(1), AE_Val3(CP_SSSMAIN(1), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(1).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(1).CuVal) = False AndAlso IsDBNull(V) = False AndAlso CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(1).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(1).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(1).CuVal = V
		CP_SSSMAIN(1).TpStr = AE_Format(CP_SSSMAIN(1), CP_SSSMAIN(1).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 1, CP_SSSMAIN(1).TpStr, CP_SSSMAIN(1).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_OPEID(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(2), AE_Val3(CP_SSSMAIN(2), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(2).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(2).CuVal) = False AndAlso IsDBNull(V) = False AndAlso CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(2).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(2).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(2).CuVal = V
		CP_SSSMAIN(2).TpStr = AE_Format(CP_SSSMAIN(2), CP_SSSMAIN(2).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 2, CP_SSSMAIN(2).TpStr, CP_SSSMAIN(2).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_OPENM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(3), AE_Val3(CP_SSSMAIN(3), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(3).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190827 CHG START
        'If CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(3).CuVal) = False AndAlso IsDBNull(V) = False AndAlso CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
            '20190827 CHG END
            CP_SSSMAIN(3).StatusC = Cn_Status6 : CP_SSSMAIN(3).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(3).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(3).StatusC = Cn_Status6 : CP_SSSMAIN(3).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(3).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(3).CuVal = V
		CP_SSSMAIN(3).TpStr = AE_Format(CP_SSSMAIN(3), CP_SSSMAIN(3).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 3, CP_SSSMAIN(3).TpStr, CP_SSSMAIN(3).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Function RD_SSSMAIN_DSPORD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(7 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_DSPORD = Space(3)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(7 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 3 Then
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DSPORD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_DSPORD = Space(3 - LenWid(st_Work)) & CStr(CP_SSSMAIN(7 + wk_PxBase).CuVal)
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DSPORD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_DSPORD = CStr(CP_SSSMAIN(7 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEICDA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(5 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEICDA = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(5 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEICDA = CStr(CP_SSSMAIN(5 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEICDA = CStr(CP_SSSMAIN(5 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEICDB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(6 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEICDB = Space(5)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(6 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 5 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEICDB = CStr(CP_SSSMAIN(6 + wk_PxBase).CuVal) & Space(5 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEICDB = CStr(CP_SSSMAIN(6 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEIKBA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEIKBA = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(14 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBA = CStr(CP_SSSMAIN(14 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBA = CStr(CP_SSSMAIN(14 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEIKBB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEIKBB = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(15 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBB = CStr(CP_SSSMAIN(15 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBB = CStr(CP_SSSMAIN(15 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEIKBC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(16 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEIKBC = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(16 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBC = CStr(CP_SSSMAIN(16 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKBC = CStr(CP_SSSMAIN(16 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEINMA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEINMA = Space(40)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 40 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMA = CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal) & Space(40 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMA = CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEINMB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEINMB = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMB = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMB = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEINMC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEINMC = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(10 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMC = CStr(CP_SSSMAIN(10 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEINMC = CStr(CP_SSSMAIN(10 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEISUA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(11 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUA = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUA = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUA = CP_SSSMAIN(11 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_MEISUB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(12 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUB = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUB = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUB = CP_SSSMAIN(12 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_MEISUC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(13 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUC = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUC = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_MEISUC = CP_SSSMAIN(13 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_UPDKB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(4 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_UPDKB = Space(4)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(4 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 4 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_UPDKB = CStr(CP_SSSMAIN(4 + wk_PxBase).CuVal) & Space(4 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_UPDKB = CStr(CP_SSSMAIN(4 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_KEYCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(17 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_KEYCD = Space(3)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(17 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 3 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_KEYCD = CStr(CP_SSSMAIN(17 + wk_PxBase).CuVal) & Space(3 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_KEYCD = CStr(CP_SSSMAIN(17 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_MEIKMKNM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(18 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_MEIKMKNM = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(18 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKMKNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKMKNM = CStr(CP_SSSMAIN(18 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKMKNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_MEIKMKNM = CStr(CP_SSSMAIN(18 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_DATKB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(19 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_DATKB = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(19 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_DATKB = CStr(CP_SSSMAIN(19 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_DATKB = CStr(CP_SSSMAIN(19 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_DSPORD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(29 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_DSPORD = Space(3)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(29 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 3 Then
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DSPORD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_DSPORD = Space(3 - LenWid(st_Work)) & CStr(CP_SSSMAIN(29 + wk_PxBase).CuVal)
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DSPORD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_DSPORD = CStr(CP_SSSMAIN(29 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEIKBA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(20 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEIKBA = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(20 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBA = CStr(CP_SSSMAIN(20 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBA = CStr(CP_SSSMAIN(20 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEIKBB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(21 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEIKBB = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(21 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBB = CStr(CP_SSSMAIN(21 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBB = CStr(CP_SSSMAIN(21 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEIKBC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(22 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEIKBC = Space(1)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(22 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBC = CStr(CP_SSSMAIN(22 + wk_PxBase).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEIKBC = CStr(CP_SSSMAIN(22 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEINMA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(23 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEINMA = Space(40)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(23 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 40 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMA = CStr(CP_SSSMAIN(23 + wk_PxBase).CuVal) & Space(40 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMA = CStr(CP_SSSMAIN(23 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEINMB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(24 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEINMB = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(24 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMB = CStr(CP_SSSMAIN(24 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMB = CStr(CP_SSSMAIN(24 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEINMC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(25 + wk_PxBase).CuVal) Then
			RD_SSSMAIN_V_MEINMC = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(25 + wk_PxBase).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMC = CStr(CP_SSSMAIN(25 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_V_MEINMC = CStr(CP_SSSMAIN(25 + wk_PxBase).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEISUA(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(26 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUA = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(26 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUA = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUA = CP_SSSMAIN(26 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEISUB(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(27 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUB = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(27 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUB = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUB = CP_SSSMAIN(27 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_V_MEISUC(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim wk_PxBase As Short
		wk_PxBase = 26 * De
		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If IsNothing(CP_SSSMAIN(28 + wk_PxBase).CuVal) Then
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUC = 0@
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf IsDbNull(CP_SSSMAIN(28 + wk_PxBase).CuVal) Then 
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUC = 0@
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_V_MEISUC = CP_SSSMAIN(28 + wk_PxBase).CuVal
		End If
	End Function
	
	Function RD_SSSMAIN_FRKEYCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(0).CuVal) Then
			RD_SSSMAIN_FRKEYCD = Space(3)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(0).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 3 Then
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_FRKEYCD = Space(3 - LenWid(st_Work)) & CStr(CP_SSSMAIN(0).CuVal)
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_FRKEYCD = CStr(CP_SSSMAIN(0).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_FRMEINM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(1).CuVal) Then
			RD_SSSMAIN_FRMEINM = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(1).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRMEINM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_FRMEINM = CStr(CP_SSSMAIN(1).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRMEINM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_FRMEINM = CStr(CP_SSSMAIN(1).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_OPEID(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(2).CuVal) Then
			RD_SSSMAIN_OPEID = Space(6)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(2).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 6 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(2).CuVal) & Space(6 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(2).CuVal)
			End If
		End If
	End Function

    Function RD_SSSMAIN_OPENM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDbNull(CP_SSSMAIN(3).CuVal) Then
            RD_SSSMAIN_OPENM = Space(20)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(3).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 20 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(3).CuVal) & Space(20 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(3).CuVal)
            End If
        End If
    End Function

    '20190826 ADD START
    Public Function PrevInstance() As Boolean
        If Diagnostics.Process.GetProcessesByName(
            Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    '20190826 ADD END

End Module