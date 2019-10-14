Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(10 + 0 + 0 + 1) As clsCP
	Public CL_SSSMAIN(10) As Short
	Public CQ_SSSMAIN(10) As String
	
	Function AE_AppendC_SSSMAIN(ByVal pm_ExMode As Short, Optional ByVal pm_Current As Object = Nothing) As Short 'Generated.
		If PP_SSSMAIN.Mode = Cn_Mode4 And PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "AppendC") Then AE_AppendC_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		PP_SSSMAIN.ChOprtMode = Cn_Mode1
		Call AE_ModeChange_SSSMAIN(Cn_Mode1)
		Call AE_InitValAll_SSSMAIN()
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_AppendC_SSSMAIN = Cn_CuInit
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Sub AE_Check_SSSMAIN_ENDOUTDT(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(9)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(9), CC_NewVal)
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト ENDOUTDT_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDOUTDT_Check(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
			Else
				'UPGRADE_WARNING: オブジェクト ENDOUTDT_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDOUTDT_Check(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(9), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 9, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(9))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(9))
				Call AE_CheckSub2_SSSMAIN(9, 9, True)
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
	
	Sub AE_Check_SSSMAIN_ENDWRTDT(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(5)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(5), CC_NewVal)
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト ENDWRTDT_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDWRTDT_Check(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
			Else
				'UPGRADE_WARNING: オブジェクト ENDWRTDT_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDWRTDT_Check(AE_NullCnv2_SSSMAIN(CC_NewVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(5), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 5, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(5))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(5))
				Call AE_CheckSub2_SSSMAIN(5, 5, True)
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
	
	Sub AE_Check_SSSMAIN_ENDWRTTM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(7)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(7), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(7).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
				If Not PP_SSSMAIN.RecalcMode Then
					wk_SaveMask = PP_SSSMAIN.MaskMode
					PP_SSSMAIN.MaskMode = True
					.TpStr = AE_Format(CP_SSSMAIN(7), .CuVal, 0, True)
					Call AE_CtSet(PP_SSSMAIN, 7, .TpStr, .TypeA, False)
					PP_SSSMAIN.MaskMode = wk_SaveMask
					If .StatusC = Cn_Status1 Then .StatusC = .StatusF
					If .StatusC >= Cn_Status6 Then
						If pm_MoveCursor Then
							If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
						End If
					Else
						Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7))
						Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), AE_Controls(PP_SSSMAIN.CtB + 7))
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト ENDWRTTM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDWRTTM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: オブジェクト ENDWRTTM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = ENDWRTTM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(7), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 7, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(7))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(7))
				Call AE_CheckSub2_SSSMAIN(7, 7, True)
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
	
	Sub AE_Check_SSSMAIN_INPTANCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
			If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: オブジェクト INPTANCD_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = INPTANCD_Check(CC_NewVal, PP_SSSMAIN.De2)
			Else
				'UPGRADE_WARNING: オブジェクト INPTANCD_Check() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = INPTANCD_Check(CC_NewVal, PP_SSSMAIN.De2)
			End If
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
	
	Sub AE_Check_SSSMAIN_INPTANNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D
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
	
	Sub AE_Check_SSSMAIN_OPEID(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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
	
	Sub AE_Check_SSSMAIN_OPENM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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
	
	Sub AE_Check_SSSMAIN_STTOUTDT(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(8)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(8), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(8).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
				If Not PP_SSSMAIN.RecalcMode Then
					wk_SaveMask = PP_SSSMAIN.MaskMode
					PP_SSSMAIN.MaskMode = True
					.TpStr = AE_Format(CP_SSSMAIN(8), .CuVal, 0, True)
					Call AE_CtSet(PP_SSSMAIN, 8, .TpStr, .TypeA, False)
					PP_SSSMAIN.MaskMode = wk_SaveMask
					If .StatusC = Cn_Status1 Then .StatusC = .StatusF
					If .StatusC >= Cn_Status6 Then
						If pm_MoveCursor Then
							If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
						End If
					Else
						Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8))
						Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), AE_Controls(PP_SSSMAIN.CtB + 8))
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D

            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト STTOUTDT_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTOUTDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: オブジェクト STTOUTDT_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTOUTDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(8), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 8, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(8))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(8))
				Call AE_CheckSub2_SSSMAIN(8, 8, True)
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
	
	Sub AE_Check_SSSMAIN_STTWRTDT(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(4)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(4), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(4).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
				If Not PP_SSSMAIN.RecalcMode Then
					wk_SaveMask = PP_SSSMAIN.MaskMode
					PP_SSSMAIN.MaskMode = True
					.TpStr = AE_Format(CP_SSSMAIN(4), .CuVal, 0, True)
					Call AE_CtSet(PP_SSSMAIN, 4, .TpStr, .TypeA, False)
					PP_SSSMAIN.MaskMode = wk_SaveMask
					If .StatusC = Cn_Status1 Then .StatusC = .StatusF
					If .StatusC >= Cn_Status6 Then
						If pm_MoveCursor Then
							If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
						End If
					Else
						Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
						Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), AE_Controls(PP_SSSMAIN.CtB + 4))
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D
            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト STTWRTDT_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTWRTDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: オブジェクト STTWRTDT_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTWRTDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(4), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 4, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
				Call AE_CheckSub2_SSSMAIN(4, 4, True)
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
	
	Sub AE_Check_SSSMAIN_STTWRTTM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(6)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(6), CC_NewVal)
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(6).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
				If Not PP_SSSMAIN.RecalcMode Then
					wk_SaveMask = PP_SSSMAIN.MaskMode
					PP_SSSMAIN.MaskMode = True
					.TpStr = AE_Format(CP_SSSMAIN(6), .CuVal, 0, True)
					Call AE_CtSet(PP_SSSMAIN, 6, .TpStr, .TypeA, False)
					PP_SSSMAIN.MaskMode = wk_SaveMask
					If .StatusC = Cn_Status1 Then .StatusC = .StatusF
					If .StatusC >= Cn_Status6 Then
						If pm_MoveCursor Then
							If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
						End If
					Else
						Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
						Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), AE_Controls(PP_SSSMAIN.CtB + 6))
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

                '2019/10/09 CHG START
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/09 CHG E N D
            End If
            If PP_SSSMAIN.RecalcMode Then
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = .CheckRtnCode
			ElseIf (.CheckRtnCode <> 0) Then 
				'UPGRADE_WARNING: オブジェクト STTWRTTM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTWRTTM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: オブジェクト STTWRTTM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Ck_Error = STTWRTTM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(6), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 6, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
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
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
				Call AE_CheckSub2_SSSMAIN(6, 6, True)
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
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = 0
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx))
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart = 0
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).Text)
                    '2019/10/09 CHG E N D

                Else
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'wk_SS = AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart
                    wk_SS = DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart
                    '2019/10/09 CHG START

                    Do While wk_SS > 0
                        wk_SS = wk_SS - 1

                        '2019/10/09 CHG START
                        'If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                        If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).Text, wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = wk_SS
                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart = wk_SS
                            'UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

                            Exit Sub
                        End If
                    Loop
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                    '2019/10/09 CHG E N D

                End If
			End If
		End If
	End Sub
	
	Sub AE_ClearDe_SSSMAIN() 'Generated.
		Dim wk_SaveDe As Short
		Dim wk_SaveDe2 As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep() : Call AE_CursorCurrent_SSSMAIN() : Exit Sub
		If PP_SSSMAIN.RecalcMode Then Exit Sub
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_ClearInitValStatus_SSSMAIN() 'Generated.
		PP_SSSMAIN.InitValStatus = PP_SSSMAIN.Mode
		Dim wk_Px As Short
		wk_Px = 0
		Do While wk_Px < 10
			CP_SSSMAIN(wk_Px).Modified = PP_SSSMAIN.Mode
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_ClearItm_SSSMAIN(ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_ClearedVal As Object
		Dim wk_De As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Sub
		If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= 10 Then Exit Sub
		PP_SSSMAIN.MaskMode = True
		If PP_SSSMAIN.Tx < 10 Then
			Call AE_InitValHd_SSSMAIN(PP_SSSMAIN.Tx, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF)
		ElseIf PP_SSSMAIN.Tx < 10 Then 
		ElseIf PP_SSSMAIN.Tx < 10 Then 
		ElseIf PP_SSSMAIN.Tx < 10 Then 
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

        '2019/10/09 CHG START
        'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
        'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'AE_StatusBar(PP_SSSMAIN.ScX) = ""
        AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
        AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
        '2019/10/09 CHG E N D

        If PP_SSSMAIN.InitValStatus >= Cn_Mode4 Then Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px))
		Call AE_SetCheck_SSSMAIN(wk_ClearedVal, Cn_Status8, pm_HandIn)
	End Sub
	
	Function AE_CompleteCheck_SSSMAIN(ByVal pm_HeadCheck As Boolean) As Short 'Generated.
		Static wk_De As Short
		Static wk_Px As Short
		Static wk_IncompletionC As Short
		Static wk_IncompletionC2 As Short
		wk_IncompletionC = 0
		wk_IncompletionC2 = 0
		PP_SSSMAIN.InCompletePx = -1
		Call AE_CompleteCheckSub_SSSMAIN(0, PP_SSSMAIN.BodyPx, wk_IncompletionC, wk_IncompletionC2) '0: HeadPx
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
		If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 10 Then
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
		wk_Tx = pm_Tx
		Do While wk_Tx < 10
			wk_Tx = wk_Tx + 1
			If wk_Tx < 10 Then
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
	
	Sub AE_CursorMove_SSSMAIN(ByVal pm_Tx As Short) 'Generated.
		Dim wk_Tx As Short
		wk_Tx = pm_Tx
		If wk_Tx = -2 Then Exit Sub
		If wk_Tx < 0 Or wk_Tx >= 10 Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
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
		wk_Tx = pm_Tx
		Do While wk_Tx < 10
			wk_Tx = wk_Tx + 1
			If wk_Tx < 10 Then
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
		Do While wk_Tx < 9
			wk_Tx = wk_Tx + 1
			If wk_Tx < 10 Then
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
		wk_Tx = pm_Tx
		Do While wk_Tx >= 0
			wk_Tx = wk_Tx - 1
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
				If Not AE_CursorPrev_SSSMAIN(10) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
			Case Cn_Dest4
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest5
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorPrev_SSSMAIN(10) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest6
				If Not AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorPrev_SSSMAIN(10) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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
						If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(10)
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
		Do While wk_Tx < 10
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
		wk_Tx = pm_Tx
		Do While wk_Tx >= 0
			wk_Tx = wk_Tx - 1
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
				Call AE_RecalcAll_SSSMAIN()
			End If
		Else
			Call AE_RecalcAll_SSSMAIN()
		End If
		Call AE_ClearInitValStatus_SSSMAIN()
		AE_Current_SSSMAIN = Cn_CuInit
	End Function
	
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
			wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
			Call AE_WindowProcReset(PP_SSSMAIN)
			ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
			If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
#If ActiveXcompile = 0 Then
			End
#End If
			'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf wk_Var = 1 Then 
			wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
			Call AE_WindowProcReset(PP_SSSMAIN)
			ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
			If PP_SSSMAIN.hIMC <> 0 Then
				Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
			End If
			FR_SSSMAIN.Hide()
		End If
		PP_SSSMAIN.CloseCode = -1
	End Sub
	
	Function AE_Execute_SSSMAIN() As Short 'Generated.
		Dim wk_ReturnCd As Short
		Dim wk_De As Short
		With PP_SSSMAIN
			If CP_SSSMAIN(.Px).StatusC = Cn_Status1 Then
				Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(.Px)), Cn_Status6, True)
			End If
			If .Mode = Cn_Mode3 Then
				Exit Function
			End If
			If AE_CompleteCheck_SSSMAIN(False) > 0 Then AE_Execute_SSSMAIN = Cn_CuInCompletePx : Exit Function
			If .Mode = Cn_Mode1 Then
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
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode1, .ServerCheck)
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
				AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode2, False)
				Exit Function
			ElseIf .Mode = Cn_Mode4 Then 
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
					Call AE_ClearInitValStatus_SSSMAIN()
					AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode4, .ServerCheck)
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
			wk_Cursor = AE_Execute_SSSMAIN()
			AE_ExecuteX_SSSMAIN = wk_Cursor
			PP_SSSMAIN.Executing = False
		End If
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
	
	Function AE_Indicate_SSSMAIN(ByVal pm_ExMode As Short, ByVal pm_NextRec As Short) As Short 'Generated.
		If PP_SSSMAIN.Mode <> Cn_Mode2 And PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode And pm_NextRec <> 1000 Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "Indicate") Then AE_Indicate_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		PP_SSSMAIN.ChOprtMode = Cn_Mode3
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
		PP_SSSMAIN.ChOprtMode = 0
	End Function
	
	Sub AE_InitValAll_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_De As Short
		Dim wk_InOutMode As Integer
		wk_Px = 0
		Do While wk_Px < 10
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValHd_SSSMAIN(-2, False, Cn_Status0)
		PP_SSSMAIN.MaskMode = False
		Call AE_ClearInitValStatus_SSSMAIN()
		Call AE_StatusClear(PP_SSSMAIN, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClErrorStatus))
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Init() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト wk_Var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wk_Var = SSSMAIN_Init()
		wk_Px = 0
		Do While wk_Px < 10
			CP_SSSMAIN(wk_Px).IniStr = CP_SSSMAIN(wk_Px).TpStr
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_InitValBd_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_InOutMode As Integer
		Dim wk_De As Short
		wk_Px = 10
		Do While wk_Px < 10
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.UnDoDeOp = 0
		PP_SSSMAIN.ActiveDe = -1
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_InitValEd_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_InOutMode As Integer
		Dim wk_De As Short
		wk_Px = 10
		Do While wk_Px < 10
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.UnDoEDeOp = 0
		PP_SSSMAIN.ActiveEDe = -1
		PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
	End Sub
	
	Sub AE_InitValHd_SSSMAIN(ByVal pm_Px As Short, ByVal pm_SetInOut As Short, ByVal pm_Status As Short) 'Generated.
		Dim wk_Tx As Short
		Dim RC_ErrorC As Short
		Dim wk_ww As Short
		If pm_Px = -2 Then
			Call AE_TabStop_SSSMAIN(0, 9, pm_SetInOut)
		ElseIf pm_Px >= 0 Then 
			wk_Tx = AE_Tx(PP_SSSMAIN, pm_Px)
			If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, pm_SetInOut)
		End If
		If pm_Px = -2 Or pm_Px = 0 Then 'OPEID
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(0), OPEID_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN, CP_SSSMAIN(0)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 1 Then 'OPENM
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(1), OPENM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal), PP_SSSMAIN, CP_SSSMAIN(1)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 2 Then 'INPTANCD
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(2), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 3 Then 'INPTANNM
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(3), System.DBNull.Value, pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 4 Then 'STTWRTDT
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(4), STTWRTDT_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 5 Then 'ENDWRTDT
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(5), ENDWRTDT_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 6 Then 'STTWRTTM
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(6), STTWRTTM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 7 Then 'ENDWRTTM
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(7), ENDWRTTM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(7).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 8 Then 'STTOUTDT
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(8), STTOUTDT_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal)), pm_Status)
		End If
		If pm_Px = -2 Or pm_Px = 9 Then 'ENDOUTDT
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(9), ENDOUTDT_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal)), pm_Status)
		End If
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
		Do While wk_Qx < 10 And UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA
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
		If wk_Qx < 10 Then
			wk_Px1 = wk_Qx
			wk_Px2 = wk_Px1 + 1
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
		Do While wk_Qx < 10 And Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> wk_UCaseObjA
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
			If pm_De < 0 Or pm_De > -1 Then
				Call AE_SystemError("AE_InOutModeN のパラメタ pm_De に", 554)
				Exit Sub
			End If
		End If
		If wk_Qx < 10 Then
			wk_Px = wk_Qx
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

            '2019/10/09 CHG START
            'Ct.Locked = False
            Ct.Enabled = True
            '2019/10/09 CHG E N D

        End If

        '2019/10/09 CHG START
        'wk_Txt = Ct.ToString()
        wk_Txt = Ct.Text
        '2019/10/09 CHG E N D

        wk_Tx = PP_SSSMAIN.Tx
		wk_Px = PP_SSSMAIN.Px
		PP_SSSMAIN.EditText = False
		PP_SSSMAIN.UnderFurigana = False
		PP_SSSMAIN.UnderFurigana22 = False
		Select Case CP_SSSMAIN(wk_Px).TypeA
			Case Cn_InputOnly, Cn_ListBox, Cn_OutputOnly
			Case Else
                'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/10/09 CHG START
                'wk_SS = Ct.SelStart
                wk_SS = DirectCast(Ct, TextBox).SelectionStart
                '2019/10/09 CHG E N D

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

            '2019/10/09 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 _
             And DirectCast(Ct, TextBox).SelectionLength = 1) _
             And PP_SSSMAIN.SelValid _
             And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) _
             And Len(wk_Txt) > 0 Then
                '2019/10/09 CHG E N D

                If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '左詰め
                    wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            GoTo AE_KeyDownRightEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS - 1
                    Loop
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '2019/10/09 CHG E N D

                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '2019/10/09 CHG E N D

                End If
AE_KeyDownRightEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/10/09 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionStart = Len(wk_Txt) - PP_SSSMAIN.Override
                '2019/10/09 CHG E N D

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

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

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
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS + 1
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS + 1
                            '2019/10/09 CHG E N D

                            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						End If
					Else
                        'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                        '2019/10/09 CHG START
                        'Ct.SelStart = wk_Ln
                        DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                        '2019/10/09 CHG E N D

                        'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                        '2019/10/09 CHG START
                        'Ct.SelLength = PP_SSSMAIN.Override
                        DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                        '2019/10/09 CHG E N D

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

            '2019/10/09 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) _
             And PP_SSSMAIN.SelValid _
             And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) _
             And Len(wk_Txt) > 0 Then
                '2019/10/09 CHG E N D

                If CP_SSSMAIN(wk_Px).Alignment = 1 Then '右詰め
                    wk_SS = 0
                    wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS < wk_Ln
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            GoTo AE_KeyDownLeftEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS + 1
                    Loop
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelStart = wk_Ln
                    DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                    '2019/10/09 CHG E N D

                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '2019/10/09 CHG E N D

                End If
AE_KeyDownLeftEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/10/09 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '2019/10/09 CHG E N D

            Else
                If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
                    PP_SSSMAIN.Override = 1
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelStart = wk_SS - 1
                    DirectCast(Ct, TextBox).SelectionStart = wk_SS - 1
                    '2019/10/09 CHG E N D

                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'Ct.SelLength = PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                    '2019/10/09 CHG E N D

                ElseIf wk_SS = 0 Then 
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
				Else
					Do While wk_SS > 0
						wk_Moji = Mid(wk_Txt, wk_SS, 1)
						wk_SS = wk_SS - 1
						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/09 CHG E N D

                            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                            '2019/10/09 CHG START
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                            '2019/10/09 CHG E N D

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
			AE_KeyDown_SSSMAIN = True
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
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.PageUp And pm_Shift = 0 Then 
			pm_KeyCode = 0
		ElseIf pm_KeyCode = 229 Then 
			PP_SSSMAIN.EditText = True
		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Delete And pm_Shift <= 2 Then 
			pm_KeyCode = 0
			If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Function
			wk_Ln = Len(Ct)
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

                '2019/10/09 CHG START
                'ElseIf Ct.SelLength = wk_Ln And wk_Ln > 1 Then
            ElseIf DirectCast(Ct, TextBox).SelectionLength = wk_Ln And wk_Ln > 1 Then
                '2019/10/09 CHG E N D

                wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
                If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
            ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then
                wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
            ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/10/09 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                If DirectCast(Ct, TextBox).SelectionLength > 1 _
                 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) _
                 And AE_SSSWin Then
                    '2019/10/09 CHG E N D

                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + Ct.SelLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, Ct.SelLength))) 'V6.52
                    wk_Txt = Left(wk_Txt, wk_SS) _
                           & Mid(wk_Txt, wk_SS + DirectCast(Ct, TextBox).SelectionLength + 1) _
                           & Space(LenWid(Mid(Ct.Text, wk_SS + 1, DirectCast(Ct, TextBox).SelectionLength))) 'V6.52
                    '2019/10/09 CHG E N D

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

                '2019/10/09 CHG START
                'If Ct.SelLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                If DirectCast(Ct, TextBox).SelectionLength = 0 _
                 And CP_SSSMAIN(wk_Px).Alignment = 1 _
                 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) _
                 And wk_SS > 0 Then
                    wk_SS2 = wk_SS - 1
                End If
                '2019/10/09 CHG E N D

                If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
					If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
						Beep()
						Exit Function
					End If
				End If
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                '2019/10/09 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                If DirectCast(Ct, TextBox).SelectionLength > 1 _
                 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) _
                 And AE_SSSWin Then 'V6.52
                    '2019/10/09 CHG E N D

                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

                    '2019/10/09 CHG START
                    'wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, Ct.SelLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + Ct.SelLength + 1) 'V6.52
                    wk_Txt = Space(LenWid(Mid(Ct.Text, wk_SS2 + 1, DirectCast(Ct, TextBox).SelectionLength))) _
                           & Left(wk_Txt, wk_SS2) _
                           & Mid(wk_Txt, wk_SS2 + DirectCast(Ct, TextBox).SelectionLength + 1) 'V6.52
                    '2019/10/09 CHG E N D

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

            '2019/10/09 CHG START
            'Ct = pm_TA
            Ct.Text = pm_TA
            '2019/10/09 CHG E N D

            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '2019/10/09 CHG START
            'Ct.SelStart = wk_SS
            DirectCast(Ct, TextBox).SelectionStart = wk_SS
            '2019/10/09 CHG E N D

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

            '2019/10/09 CHG START
            'If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then Ct.SelStart = wk_Ln - 1
            If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then
                DirectCast(Ct, TextBox).SelectionStart = wk_Ln - 1
            End If
            '2019/10/09 CHG E N D

            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '2019/10/09 CHG START
            'Ct.SelLength = PP_SSSMAIN.Override
            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            '2019/10/09 CHG E N D

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
				Call AE_RecalcAll_SSSMAIN()
			End If
		Else
			Call AE_RecalcAll_SSSMAIN()
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
	
	Sub AE_ModeChange_SSSMAIN(ByVal pm_NewMode As Short) 'Generated.
		Select Case pm_NewMode
			Case Cn_Mode1
				If PP_SSSMAIN.Mode <> Cn_Mode1 Then
					PP_SSSMAIN.Mode = Cn_Mode1 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "追加"
					Call AE_TabStop_SSSMAIN(0, 9, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode2
				If PP_SSSMAIN.Mode <> Cn_Mode2 Then
					PP_SSSMAIN.Mode = Cn_Mode2 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "選択"
					Call AE_TabStop_SSSMAIN(0, 9, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode3
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					PP_SSSMAIN.Mode = Cn_Mode3 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "表示"
					Call AE_TabStop_SSSMAIN(0, 9, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
				End If
			Case Cn_Mode4
				If PP_SSSMAIN.Mode <> Cn_Mode4 Then
					PP_SSSMAIN.Mode = Cn_Mode4 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "更新"
					Call AE_TabStop_SSSMAIN(0, 9, False)
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
				Call AE_RecalcAll_SSSMAIN()
			End If
		Else
			Call AE_RecalcAll_SSSMAIN()
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
	
	Sub AE_RecalcAll_SSSMAIN() 'Generated.
		PP_SSSMAIN.DerivedOrigin = ""
		Call AE_RecalcHd_SSSMAIN()
	End Sub
	
	Sub AE_RecalcHd_SSSMAIN() 'Generated.
		PP_SSSMAIN.RecalcMode = True
		If AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(0).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPEID(AE_Val2(CP_SSSMAIN(0)), CP_SSSMAIN(0).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(1).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPENM(AE_Val2(CP_SSSMAIN(1)), CP_SSSMAIN(1).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(2).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_INPTANCD(AE_Val2(CP_SSSMAIN(2)), CP_SSSMAIN(2).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(3).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_INPTANNM(AE_Val2(CP_SSSMAIN(3)), CP_SSSMAIN(3).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(4).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTWRTDT(AE_Val2(CP_SSSMAIN(4)), CP_SSSMAIN(4).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(5).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDWRTDT(AE_Val2(CP_SSSMAIN(5)), CP_SSSMAIN(5).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(6).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTWRTTM(AE_Val2(CP_SSSMAIN(6)), CP_SSSMAIN(6).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(7).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDWRTTM(AE_Val2(CP_SSSMAIN(7)), CP_SSSMAIN(7).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(8).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(8).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(8).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTOUTDT(AE_Val2(CP_SSSMAIN(8)), CP_SSSMAIN(8).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(9).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(9).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(9).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDOUTDT(AE_Val2(CP_SSSMAIN(9)), CP_SSSMAIN(9).StatusF, False, False)
		End If
		PP_SSSMAIN.RecalcMode = False
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
			AE_SelectCm_SSSMAIN = AE_Indicate_SSSMAIN(pm_ExMode, False)
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
		ElseIf PP_SSSMAIN.Tx < 10 Then 
			Select Case PP_SSSMAIN.Px
				Case 0
					Call AE_Check_SSSMAIN_OPEID(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 1
					Call AE_Check_SSSMAIN_OPENM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 2
					Call AE_Check_SSSMAIN_INPTANCD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 3
					Call AE_Check_SSSMAIN_INPTANNM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 4
					Call AE_Check_SSSMAIN_STTWRTDT(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 5
					Call AE_Check_SSSMAIN_ENDWRTDT(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 6
					Call AE_Check_SSSMAIN_STTWRTTM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 7
					Call AE_Check_SSSMAIN_ENDWRTTM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 8
					Call AE_Check_SSSMAIN_STTOUTDT(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
				Case 9
					Call AE_Check_SSSMAIN_ENDOUTDT(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
			End Select
		End If
	End Sub
	
	Sub AE_Slist_SSSMAIN() 'Generated.
		Dim wk_Slisted As Object
		If False Then
		ElseIf PP_SSSMAIN.Tx = 2 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト INPTANCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = INPTANCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal))
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
					CP_SSSMAIN(2).TpStr = wk_Slisted
					CP_SSSMAIN(2).CIn = Cn_ChrInput
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					AE_Controls(PP_SSSMAIN.CtB + 2) = wk_Slisted
					Call AE_Check_SSSMAIN_INPTANCD(AE_Val3(CP_SSSMAIN(2), AE_Controls(PP_SSSMAIN.CtB + 2).ToString()), Cn_Status6, True, True)
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf PP_SSSMAIN.Tx = 4 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト STTWRTDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = STTWRTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
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
					CP_SSSMAIN(4).TpStr = wk_Slisted
					CP_SSSMAIN(4).CIn = Cn_ChrInput
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 4) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					AE_Controls(PP_SSSMAIN.CtB + 4) = wk_Slisted
					Call AE_Check_SSSMAIN_STTWRTDT(AE_Val3(CP_SSSMAIN(4), AE_Controls(PP_SSSMAIN.CtB + 4).ToString()), Cn_Status6, True, True)
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf PP_SSSMAIN.Tx = 5 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト ENDWRTDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = ENDWRTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
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
					CP_SSSMAIN(5).TpStr = wk_Slisted
					CP_SSSMAIN(5).CIn = Cn_ChrInput
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 5) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					AE_Controls(PP_SSSMAIN.CtB + 5) = wk_Slisted
					Call AE_Check_SSSMAIN_ENDWRTDT(AE_Val3(CP_SSSMAIN(5), AE_Controls(PP_SSSMAIN.CtB + 5).ToString()), Cn_Status6, True, True)
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf PP_SSSMAIN.Tx = 8 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト STTOUTDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = STTOUTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
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
					CP_SSSMAIN(8).TpStr = wk_Slisted
					CP_SSSMAIN(8).CIn = Cn_ChrInput
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 8) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					AE_Controls(PP_SSSMAIN.CtB + 8) = wk_Slisted
					Call AE_Check_SSSMAIN_STTOUTDT(AE_Val3(CP_SSSMAIN(8), AE_Controls(PP_SSSMAIN.CtB + 8).ToString()), Cn_Status6, True, True)
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		ElseIf PP_SSSMAIN.Tx = 9 Then 
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			'UPGRADE_WARNING: オブジェクト ENDOUTDT_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wk_Slisted = ENDOUTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal))
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
					CP_SSSMAIN(9).TpStr = wk_Slisted
					CP_SSSMAIN(9).CIn = Cn_ChrInput
					'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 9) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					AE_Controls(PP_SSSMAIN.CtB + 9) = wk_Slisted
					Call AE_Check_SSSMAIN_ENDOUTDT(AE_Val3(CP_SSSMAIN(9), AE_Controls(PP_SSSMAIN.CtB + 9).ToString()), Cn_Status6, True, True)
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
		Else
			Beep()
		End If
	End Sub
	
	Sub AE_TabStop_SSSMAIN(ByVal pm_FromTx As Short, ByVal pm_ToTx As Short, ByVal pm_SetInOut As Boolean) 'Generated.
		Static wk_Tx As Short
		Static wk_Px As Short
		Static wk_InOutMode As Integer
		If pm_FromTx < 0 Or pm_ToTx < 0 Then Exit Sub
		wk_Tx = pm_FromTx
		Do While wk_Tx <= pm_ToTx
			If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < 10 Then
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

            '2019/10/09 CHG START
            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
            'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'AE_StatusBar(PP_SSSMAIN.ScX) = ""
            AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
            '2019/10/09 CHG E N D

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
        ''2019/10/09　仮
        'Dim wk_Tx As Short
        'For wk_Tx = 0 To PP_SSSMAIN.ControlsC - 1
        '            'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        '		PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        'Next wk_Tx
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_StatusBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_ModeBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '2019/10/09　仮
    End Sub
	
	Sub DP_SSSMAIN_ENDOUTDT(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(9), AE_Val3(CP_SSSMAIN(9), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(9).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(9).CuVal <> V Or CP_SSSMAIN(9).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(9).StatusC = Cn_Status6 : CP_SSSMAIN(9).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(9).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(9).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(9).StatusC = Cn_Status6 : CP_SSSMAIN(9).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(9).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(9).CuVal = V
		CP_SSSMAIN(9).TpStr = AE_Format(CP_SSSMAIN(9), CP_SSSMAIN(9).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 9, CP_SSSMAIN(9).TpStr, CP_SSSMAIN(9).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_ENDWRTDT(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(5), AE_Val3(CP_SSSMAIN(5), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(5).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(5).CuVal <> V Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(5).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(5).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(5).CuVal = V
		CP_SSSMAIN(5).TpStr = AE_Format(CP_SSSMAIN(5), CP_SSSMAIN(5).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 5, CP_SSSMAIN(5).TpStr, CP_SSSMAIN(5).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_ENDWRTTM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(7), AE_Val3(CP_SSSMAIN(7), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(7).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(7).CuVal <> V Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(7).StatusC = Cn_Status6 : CP_SSSMAIN(7).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(7).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(7).StatusC = Cn_Status6 : CP_SSSMAIN(7).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(7).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(7).CuVal = V
		CP_SSSMAIN(7).TpStr = AE_Format(CP_SSSMAIN(7), CP_SSSMAIN(7).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 7, CP_SSSMAIN(7).TpStr, CP_SSSMAIN(7).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_INPTANCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
		If CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(2).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then 
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
	
	Sub DP_SSSMAIN_INPTANNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
		If CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(3).StatusC = Cn_Status6 : CP_SSSMAIN(3).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(3).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then 
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
	
	Sub DP_SSSMAIN_OPEID(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
		If CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
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
	
	Sub DP_SSSMAIN_OPENM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
		If CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(1).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then 
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
	
	Sub DP_SSSMAIN_STTOUTDT(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(8), AE_Val3(CP_SSSMAIN(8), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(8).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(8).CuVal <> V Or CP_SSSMAIN(8).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(8).StatusC = Cn_Status6 : CP_SSSMAIN(8).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(8).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(8).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(8).StatusC = Cn_Status6 : CP_SSSMAIN(8).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(8).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(8).CuVal = V
		CP_SSSMAIN(8).TpStr = AE_Format(CP_SSSMAIN(8), CP_SSSMAIN(8).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 8, CP_SSSMAIN(8).TpStr, CP_SSSMAIN(8).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_STTWRTDT(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(4), AE_Val3(CP_SSSMAIN(4), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(4).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(4).CuVal <> V Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(4).StatusC = Cn_Status6 : CP_SSSMAIN(4).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(4).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(4).StatusC = Cn_Status6 : CP_SSSMAIN(4).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(4).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(4).CuVal = V
		CP_SSSMAIN(4).TpStr = AE_Format(CP_SSSMAIN(4), CP_SSSMAIN(4).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 4, CP_SSSMAIN(4).TpStr, CP_SSSMAIN(4).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_STTWRTTM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		V = AE_NormData(CP_SSSMAIN(6), AE_Val3(CP_SSSMAIN(6), CStr(DBItem)))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(6).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CP_SSSMAIN(6).CuVal <> V Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(6).StatusC = Cn_Status6 : CP_SSSMAIN(6).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		ElseIf (IsDbNull(CP_SSSMAIN(6).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(6).StatusC = Cn_Status6 : CP_SSSMAIN(6).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(6).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
		'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CP_SSSMAIN(6).CuVal = V
		CP_SSSMAIN(6).TpStr = AE_Format(CP_SSSMAIN(6), CP_SSSMAIN(6).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 6, CP_SSSMAIN(6).TpStr, CP_SSSMAIN(6).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Function RD_SSSMAIN_ENDOUTDT(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(9).CuVal) Then
			RD_SSSMAIN_ENDOUTDT = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(9).CuVal) Then 
			RD_SSSMAIN_ENDOUTDT = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_ENDOUTDT = VB6.Format(CP_SSSMAIN(9).CuVal, "YYYYMMDD")
		End If
	End Function
	
	Function RD_SSSMAIN_ENDWRTDT(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(5).CuVal) Then
			RD_SSSMAIN_ENDWRTDT = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(5).CuVal) Then 
			RD_SSSMAIN_ENDWRTDT = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_ENDWRTDT = VB6.Format(CP_SSSMAIN(5).CuVal, "YYYYMMDD")
		End If
	End Function
	
	Function RD_SSSMAIN_ENDWRTTM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(7).CuVal) Then
			RD_SSSMAIN_ENDWRTTM = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(7).CuVal) Then 
			RD_SSSMAIN_ENDWRTTM = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_ENDWRTTM = VB6.Format(CP_SSSMAIN(7).CuVal, "YYYYMMDD")
		End If
	End Function
	
	Function RD_SSSMAIN_INPTANCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(2).CuVal) Then
			RD_SSSMAIN_INPTANCD = Space(6)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(2).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 6 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_INPTANCD = CStr(CP_SSSMAIN(2).CuVal) & Space(6 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_INPTANCD = CStr(CP_SSSMAIN(2).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_INPTANNM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(3).CuVal) Then
			RD_SSSMAIN_INPTANNM = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(3).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_INPTANNM = CStr(CP_SSSMAIN(3).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_INPTANNM = CStr(CP_SSSMAIN(3).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_OPEID(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(0).CuVal) Then
			RD_SSSMAIN_OPEID = Space(6)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(0).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 6 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(0).CuVal) & Space(6 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(0).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_OPENM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(1).CuVal) Then
			RD_SSSMAIN_OPENM = Space(20)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			st_Work = CStr(CP_SSSMAIN(1).CuVal)
			'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(1).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(1).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_STTOUTDT(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(8).CuVal) Then
			RD_SSSMAIN_STTOUTDT = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(8).CuVal) Then 
			RD_SSSMAIN_STTOUTDT = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_STTOUTDT = VB6.Format(CP_SSSMAIN(8).CuVal, "YYYYMMDD")
		End If
	End Function
	
	Function RD_SSSMAIN_STTWRTDT(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(4).CuVal) Then
			RD_SSSMAIN_STTWRTDT = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(4).CuVal) Then 
			RD_SSSMAIN_STTWRTDT = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_STTWRTDT = VB6.Format(CP_SSSMAIN(4).CuVal, "YYYYMMDD")
		End If
	End Function
	
	Function RD_SSSMAIN_STTWRTTM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(CP_SSSMAIN(6).CuVal) Then
			RD_SSSMAIN_STTWRTTM = Space(8)
		ElseIf Not IsDate(CP_SSSMAIN(6).CuVal) Then 
			RD_SSSMAIN_STTWRTTM = Space(8)
		Else
			'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			RD_SSSMAIN_STTWRTTM = VB6.Format(CP_SSSMAIN(6).CuVal, "YYYYMMDD")
		End If
	End Function
End Module