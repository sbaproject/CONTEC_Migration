Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	' === 20110216 === UPDATE S TOM)Morimoto
	Public WGDENKB As String
	'Public CP_SSSMAIN(7 + 0 + 0 + 1) As clsCP
	'Public CL_SSSMAIN(7) As Integer
	'Public CQ_SSSMAIN(7) As String
	Public CP_SSSMAIN(8 + 0 + 0 + 1) As clsCP
	Public CL_SSSMAIN(8) As Short
	Public CQ_SSSMAIN(8) As String
	Structure Cls_Dsp_Body_Bus_Inf
		Dim dmy As String
	End Structure
	Private Const gv_strTAB_CHAR As String = vbTab
	' === 20110216 === UPDATE E
	
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
	
	Sub AE_Check_SSSMAIN_ENDTOKCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim Wk_Index As Short
		Dim wk_Index1 As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   With CP_SSSMAIN(5)
		Wk_Index = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(Wk_Index)
			' === 20110216 === UPDATE E
			ex_CheckRtnCode = .CheckRtnCode
			' === 20110216 === UPDATE S TOM)Morimoto
			'   If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsNull(CC_NewVal) Then CC_NewVal = AE_FormatC$(CP_SSSMAIN(5), CC_NewVal)
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(Wk_Index), CC_NewVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""

                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = ENDTOKCD_Check(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = ENDTOKCD_Check(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			' === 20110216 === UPDATE S TOM)Morimoto
			'      .TpStr = AE_Format$(CP_SSSMAIN(5), .CuVal, 0, True)
			'      Call AE_CtSet(PP_SSSMAIN, 5, .TpStr, .TypeA, False)
			.TpStr = AE_Format(CP_SSSMAIN(Wk_Index), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, .TpStr, .TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(5))
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5))
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
					If Not PP_SSSMAIN.RecalcMode Then
						PP_SSSMAIN.DerivedOrigin = "HD_ENDTOKCD"
						' === 20110216 === UPDATE S TOM)Morimoto
						'            CP_SSSMAIN(6).ExVal = CP_SSSMAIN(6).CuVal 'ENDTOKNM
						'            CP_SSSMAIN(6).ExStatus = CP_SSSMAIN(6).StatusC
						wk_Index1 = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						CP_SSSMAIN(wk_Index1).ExVal = CP_SSSMAIN(wk_Index1).CuVal 'ENDTOKNM
						CP_SSSMAIN(wk_Index1).ExStatus = CP_SSSMAIN(wk_Index1).StatusC
						' === 20110216 === UPDATE E
						Call AE_Derived_SSSMAIN_hd_ENDTOKNM(PP_SSSMAIN.De2)
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
				' === 20110216 === UPDATE S TOM)Morimoto
				'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(5))
				'      Call AE_CheckSub2_SSSMAIN(5, 5, True)
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				Call AE_CheckSub2_SSSMAIN(Wk_Index, Wk_Index, True)
				' === 20110216 === UPDATE E
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_ENDTOKNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim Wk_Index As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   With CP_SSSMAIN(6)
		Wk_Index = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(Wk_Index)
			' === 20110216 === UPDATE E
			ex_CheckRtnCode = .CheckRtnCode
			' === 20110216 === UPDATE S TOM)Morimoto
			'   If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsNull(CC_NewVal) Then CC_NewVal = AE_FormatC$(CP_SSSMAIN(6), CC_NewVal)
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(Wk_Index), CC_NewVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			' === 20110216 === UPDATE S TOM)Morimoto
			'      .TpStr = AE_Format$(CP_SSSMAIN(6), .CuVal, 0, True)
			'      Call AE_CtSet(PP_SSSMAIN, 6, .TpStr, .TypeA, False)
			.TpStr = AE_Format(CP_SSSMAIN(Wk_Index), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, .TpStr, .TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
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
				' === 20110216 === UPDATE S TOM)Morimoto
				'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
				'      Call AE_CheckSub2_SSSMAIN(6, 6, True)
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				Call AE_CheckSub2_SSSMAIN(Wk_Index, Wk_Index, True)
				' === 20110216 === UPDATE E
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(0), CC_NewVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(0), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 0, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(0))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(1), CC_NewVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(1), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 1, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(1))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_STTTOKCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim Wk_Index As Short
		Dim wk_Index1 As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   With CP_SSSMAIN(3)
		Wk_Index = Get_Index("HD_STTTOKCD", CQ_SSSMAIN)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(Wk_Index)
			' === 20110216 === UPDATE E
			ex_CheckRtnCode = .CheckRtnCode
			' === 20110216 === UPDATE S TOM)Morimoto
			'   If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsNull(CC_NewVal) Then CC_NewVal = AE_FormatC$(CP_SSSMAIN(3), CC_NewVal)
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(Wk_Index), CC_NewVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = STTTOKCD_Check(AE_NullCnv2_SSSMAIN(CC_NewVal))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = STTTOKCD_Check(AE_NullCnv2_SSSMAIN(CC_NewVal))
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			' === 20110216 === UPDATE S TOM)Morimoto
			'      .TpStr = AE_Format$(CP_SSSMAIN(3), .CuVal, 0, True)
			'      Call AE_CtSet(PP_SSSMAIN, 3, .TpStr, .TypeA, False)
			.TpStr = AE_Format(CP_SSSMAIN(Wk_Index), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, .TpStr, .TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(3))
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3))
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
					If Not PP_SSSMAIN.RecalcMode Then
						PP_SSSMAIN.DerivedOrigin = "HD_STTTOKCD"
						' === 20110216 === UPDATE S TOM)Morimoto
						'            CP_SSSMAIN(4).ExVal = CP_SSSMAIN(4).CuVal 'STTTOKNM
						'            CP_SSSMAIN(4).ExStatus = CP_SSSMAIN(4).StatusC
						wk_Index1 = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						CP_SSSMAIN(wk_Index1).ExVal = CP_SSSMAIN(wk_Index1).CuVal 'STTTOKNM
						CP_SSSMAIN(wk_Index1).ExStatus = CP_SSSMAIN(wk_Index1).StatusC
						' === 20110216 === UPDATE E
						Call AE_Derived_SSSMAIN_hd_STTTOKNM(PP_SSSMAIN.De2)
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
				' === 20110216 === UPDATE S TOM)Morimoto
				'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(3))
				'      Call AE_CheckSub2_SSSMAIN(3, 3, True)
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				Call AE_CheckSub2_SSSMAIN(Wk_Index, Wk_Index, True)
				' === 20110216 === UPDATE E
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_STTTOKNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim Wk_Index As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   With CP_SSSMAIN(4)
		Wk_Index = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(Wk_Index)
			' === 20110216 === UPDATE E
			ex_CheckRtnCode = .CheckRtnCode
			' === 20110216 === UPDATE S TOM)Morimoto
			'   If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsNull(CC_NewVal) Then CC_NewVal = AE_FormatC$(CP_SSSMAIN(4), CC_NewVal)
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(Wk_Index), CC_NewVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Ck_Error = 0
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			' === 20110216 === UPDATE S TOM)Morimoto
			'      .TpStr = AE_Format$(CP_SSSMAIN(4), .CuVal, 0, True)
			'      Call AE_CtSet(PP_SSSMAIN, 4, .TpStr, .TypeA, False)
			.TpStr = AE_Format(CP_SSSMAIN(Wk_Index), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, .TpStr, .TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
					' === 20110216 === UPDATE E
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
				' === 20110216 === UPDATE S TOM)Morimoto
				'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
				'      Call AE_CheckSub2_SSSMAIN(4, 4, True)
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				Call AE_CheckSub2_SSSMAIN(Wk_Index, Wk_Index, True)
				' === 20110216 === UPDATE E
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_Check_SSSMAIN_THSCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(2)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(2), CC_NewVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
			If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: �I�u�W�F�N�g THSCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = THSCD_Check(CC_NewVal)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g THSCD_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = THSCD_Check(CC_NewVal)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(2), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, 2, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(2))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Sub
	
	Sub AE_CheckSub2_SSSMAIN(ByVal pm_Tx As Short, ByVal pm_Px As Short, ByVal pm_Sw As Boolean) 'Generated.
		Dim wk_SS As Integer
		If pm_Sw Then
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP_SSSMAIN(pm_Px).CuVal = PP_SSSMAIN.SaveCV
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP_SSSMAIN(pm_Px).ExVal = PP_SSSMAIN.SaveXV
			CP_SSSMAIN(pm_Px).ExStatus = PP_SSSMAIN.SaveExStatus
			CP_SSSMAIN(pm_Px).StatusC = Cn_Status2
			If CP_SSSMAIN(pm_Px).TypeA = Cn_NormalOrV Or CP_SSSMAIN(pm_Px).TypeA = Cn_InputOnly Then Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(pm_Px), CL_SSSMAIN(pm_Px))
		End If
		If pm_Tx >= 0 Then
			If CP_SSSMAIN(pm_Px).TypeA = Cn_NormalOrV Then
				If PP_SSSMAIN.SelValid And CP_SSSMAIN(pm_Px).FixedFormat <> 1 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = 0
                    ''UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx))

                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(0, Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx)))
                    '2019/10/15 CHG END
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'wk_SS = AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart
                    wk_SS = DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart
                    '2019/10/15 CHG END
                    Do While wk_SS > 0
						wk_SS = wk_SS - 1
						If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = wk_SS
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override

                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
                            Exit Sub
						End If
					Loop
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                    '2019/10/15 CHG END
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Px < 7
		Do While wk_Px < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
			CP_SSSMAIN(wk_Px).Modified = PP_SSSMAIN.Mode
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_ClearItm_SSSMAIN(ByVal pm_HandIn As Boolean) 'Generated.
		Dim wk_ClearedVal As Object
		Dim wk_De As Short
		If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= 7 Then Exit Sub
		If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= PP_SSSMAIN.HeadN Then Exit Sub
		' === 20110216 === UPDATE E
		PP_SSSMAIN.MaskMode = True
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx < 7 Then
		If PP_SSSMAIN.Tx < PP_SSSMAIN.HeadN Then
			' === 20110216 === UPDATE E
			Call AE_InitValHd_SSSMAIN(PP_SSSMAIN.Tx, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF)
			' === 20110216 === DELETE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx < 7 Then
			'   ElseIf PP_SSSMAIN.Tx < 7 Then
			'   ElseIf PP_SSSMAIN.Tx < 7 Then
			' === 20110216 === DELETE E
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g wk_ClearedVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		wk_ClearedVal = CP_SSSMAIN(PP_SSSMAIN.Px).CuVal
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(PP_SSSMAIN.Px).CuVal = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
		CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
		CP_SSSMAIN(PP_SSSMAIN.Px).StatusF = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
		PP_SSSMAIN.MaskMode = False
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'AE_StatusBar(PP_SSSMAIN.ScX) = ""
        ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""

        AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
        AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
        '2019/10/15 CHG END
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
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					If (Not fl_NullZero And IsDbNull(CP_SSSMAIN(wk_Px).CuVal)) Or (fl_NullZero And AE_IsNull_SSSMAIN(CP_SSSMAIN(wk_Px).CuVal)) Then
						pm_IncompletionC = pm_IncompletionC + 1
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then pm_IncompletionC2 = pm_IncompletionC2 + 1 : PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ElseIf Left(CP_SSSMAIN(wk_Px).CuVal, 1) = Space(1) And CP_SSSMAIN(wk_Px).Alignment <> 1 And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
						pm_IncompletionC = pm_IncompletionC + 1
						If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Then pm_IncompletionC2 = pm_IncompletionC2 + 1 : PP_SSSMAIN.InCompletePx = wk_Px : Exit Do
						'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 7 Then
		If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < PP_SSSMAIN.HeadN Then
			' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Tx < 7
		Do While wk_Tx < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
			wk_Tx = wk_Tx + 1
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If wk_Tx < 7 Then
			If wk_Tx < PP_SSSMAIN.HeadN Then
				' === 20110216 === UPDATE E
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
				'UPGRADE_ISSUE: Control TabIndex �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If wk_Tx < 0 Or wk_Tx >= 7 Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
		If wk_Tx < 0 Or wk_Tx >= PP_SSSMAIN.HeadN Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
		' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Tx < 7
		Do While wk_Tx < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
			wk_Tx = wk_Tx + 1
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If wk_Tx < 7 Then
			If wk_Tx < PP_SSSMAIN.HeadN Then
				' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Tx < 6
		Do While wk_Tx < PP_SSSMAIN.HeadN - 1
			' === 20110216 === UPDATE E
			wk_Tx = wk_Tx + 1
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If wk_Tx < 7 Then
			If wk_Tx < PP_SSSMAIN.HeadN Then
				' === 20110216 === UPDATE E
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
				'UPGRADE_ISSUE: Control TabIndex �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
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
				' === 20110216 === UPDATE S TOM)Morimoto
				'         If Not AE_CursorPrev_SSSMAIN(7) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				If Not AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				' === 20110216 === UPDATE E
			Case Cn_Dest4
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
					If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest5
				PP_SSSMAIN.UpDownFlag = True
				If Not AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
					' === 20110216 === UPDATE S TOM)Morimoto
					'            If Not AE_CursorPrev_SSSMAIN(7) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
					If Not AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
					' === 20110216 === UPDATE E
				End If
				PP_SSSMAIN.UpDownFlag = False
			Case Cn_Dest6
				If Not AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
					' === 20110216 === UPDATE S TOM)Morimoto
					'            If Not AE_CursorPrev_SSSMAIN(7) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
					If Not AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
					' === 20110216 === UPDATE E
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
						' === 20110216 === UPDATE S TOM)Morimoto
						'               If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(7)
						If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.HeadN)
						' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Tx < 7
		Do While wk_Tx < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
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
		' === 20110217 === DELETE S TOM)Morimoto
		'   PP_SSSMAIN.LastDe = SSSMAIN_Current()
		' === 20110217 === DELETE E
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
	
	Sub AE_Derived_SSSMAIN_hd_ENDTOKNM(ByVal De_Index As Object) 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		Dim wk_Infdex As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CC_NewVal = ENDTOKNM_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal), PP_SSSMAIN.De2)
		wk_Infdex = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_Derived() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = ENDTOKNM_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(wk_Infdex).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(wk_Infdex - 1).CuVal), PP_SSSMAIN.De2)
		' === 20110216 === UPDATE E
		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If IsNothing(CC_NewVal) Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(6).CheckRtnCode = 0
		'   CC_NewVal = AE_NormData(CP_SSSMAIN(6), CC_NewVal)
		'   If CC_NewVal = CP_SSSMAIN(6).CuVal And CP_SSSMAIN(6).StatusC >= Cn_Status6 Then
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
		'   ElseIf IsNull(CC_NewVal) And IsNull(CP_SSSMAIN(6).CuVal) And CP_SSSMAIN(6).StatusC >= Cn_Status6 Then
		CP_SSSMAIN(wk_Infdex).CheckRtnCode = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = AE_NormData(CP_SSSMAIN(wk_Infdex), CC_NewVal)
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(wk_Infdex).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'If CC_NewVal = CP_SSSMAIN(wk_Infdex).CuVal And CP_SSSMAIN(wk_Infdex).StatusC >= Cn_Status6 Then
        If IsDBNull(CC_NewVal) = False _
         AndAlso IsDBNull(CP_SSSMAIN(wk_Infdex).CuVal) = False _
         AndAlso CC_NewVal = CP_SSSMAIN(wk_Infdex).CuVal And CP_SSSMAIN(wk_Infdex).StatusC >= Cn_Status6 Then
            '2019/10/15 CHG END
            Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Infdex), CL_SSSMAIN(wk_Infdex))
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf IsDBNull(CC_NewVal) And IsDBNull(CP_SSSMAIN(wk_Infdex).CuVal) And CP_SSSMAIN(wk_Infdex).StatusC >= Cn_Status6 Then
            ' === 20110216 === UPDATE E
        Else
            wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			' === 20110216 === UPDATE S TOM)Morimoto
			'         CP_SSSMAIN(6).CuVal = CC_NewVal
			'         CP_SSSMAIN(6).TpStr = AE_Format$(CP_SSSMAIN(6), CP_SSSMAIN(6).CuVal, 0, True)
			'         Call AE_CtSet(PP_SSSMAIN, 6, CP_SSSMAIN(6).TpStr, CP_SSSMAIN(6).TypeA, False)
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP_SSSMAIN(wk_Infdex).CuVal = CC_NewVal
			CP_SSSMAIN(wk_Infdex).TpStr = AE_Format(CP_SSSMAIN(wk_Infdex), CP_SSSMAIN(wk_Infdex).CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, wk_Infdex, CP_SSSMAIN(wk_Infdex).TpStr, CP_SSSMAIN(wk_Infdex).TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			' === 20110216 === UPDATE S TOM)Morimoto
			'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
			'      If CP_SSSMAIN(6).StatusC = Cn_StatusError Then
			'         CP_SSSMAIN(6).StatusC = Cn_Status2
			'         CP_SSSMAIN(6).StatusF = Cn_Status2
			'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
			'      ElseIf CP_SSSMAIN(6).StatusC <> Cn_Status6 Then
			'         CP_SSSMAIN(6).StatusC = Cn_Status7
			'         CP_SSSMAIN(6).StatusF = Cn_Status7
			'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Infdex))
			If CP_SSSMAIN(wk_Infdex).StatusC = Cn_StatusError Then
				CP_SSSMAIN(wk_Infdex).StatusC = Cn_Status2
				CP_SSSMAIN(wk_Infdex).StatusF = Cn_Status2
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Infdex), CL_SSSMAIN(wk_Infdex))
			ElseIf CP_SSSMAIN(wk_Infdex).StatusC <> Cn_Status6 Then 
				CP_SSSMAIN(wk_Infdex).StatusC = Cn_Status7
				CP_SSSMAIN(wk_Infdex).StatusF = Cn_Status7
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Infdex), CL_SSSMAIN(wk_Infdex))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(wk_Infdex), CL_SSSMAIN(wk_Infdex))
				' === 20110216 === UPDATE E
			End If
		End If
	End Sub
	
	Sub AE_Derived_SSSMAIN_hd_STTTOKNM(ByVal De_Index As Object) 'Generated.
		Dim CC_NewVal As Object
		Dim wk_SaveMask As Boolean
		Dim Wk_Index As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CC_NewVal = STTTOKNM_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal), PP_SSSMAIN.De2)
		Wk_Index = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_Derived() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = STTTOKNM_Derived(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index - 1).CuVal), PP_SSSMAIN.De2)
		' === 20110216 === UPDATE E
		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If IsNothing(CC_NewVal) Then Exit Sub
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(4).CheckRtnCode = 0
		'   CC_NewVal = AE_NormData(CP_SSSMAIN(4), CC_NewVal)
		'   If CC_NewVal = CP_SSSMAIN(4).CuVal And CP_SSSMAIN(4).StatusC >= Cn_Status6 Then
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
		'   ElseIf IsNull(CC_NewVal) And IsNull(CP_SSSMAIN(4).CuVal) And CP_SSSMAIN(4).StatusC >= Cn_Status6 Then
		CP_SSSMAIN(Wk_Index).CheckRtnCode = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = AE_NormData(CP_SSSMAIN(Wk_Index), CC_NewVal)
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Wk_Index).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'If CC_NewVal = CP_SSSMAIN(Wk_Index).CuVal And CP_SSSMAIN(Wk_Index).StatusC >= Cn_Status6 Then
        If IsDBNull(CC_NewVal) = False _
         AndAlso IsDBNull(CP_SSSMAIN(Wk_Index).CuVal) = False _
         AndAlso CC_NewVal = CP_SSSMAIN(Wk_Index).CuVal And CP_SSSMAIN(Wk_Index).StatusC >= Cn_Status6 Then
            '2019/10/15 CHG END
            Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf IsDBNull(CC_NewVal) And IsDBNull(CP_SSSMAIN(Wk_Index).CuVal) And CP_SSSMAIN(Wk_Index).StatusC >= Cn_Status6 Then
            ' === 20110216 === UPDATE E
        Else
            wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			' === 20110216 === UPDATE S TOM)Morimoto
			'         CP_SSSMAIN(4).CuVal = CC_NewVal
			'         CP_SSSMAIN(4).TpStr = AE_Format$(CP_SSSMAIN(4), CP_SSSMAIN(4).CuVal, 0, True)
			'         Call AE_CtSet(PP_SSSMAIN, 4, CP_SSSMAIN(4).TpStr, CP_SSSMAIN(4).TypeA, False)
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CP_SSSMAIN(Wk_Index).CuVal = CC_NewVal
			CP_SSSMAIN(Wk_Index).TpStr = AE_Format(CP_SSSMAIN(Wk_Index), CP_SSSMAIN(Wk_Index).CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, CP_SSSMAIN(Wk_Index).TpStr, CP_SSSMAIN(Wk_Index).TypeA, False)
			' === 20110216 === UPDATE E
			PP_SSSMAIN.MaskMode = wk_SaveMask
			' === 20110216 === UPDATE S TOM)Morimoto
			'      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
			'      If CP_SSSMAIN(4).StatusC = Cn_StatusError Then
			'         CP_SSSMAIN(4).StatusC = Cn_Status2
			'         CP_SSSMAIN(4).StatusF = Cn_Status2
			'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
			'      ElseIf CP_SSSMAIN(4).StatusC <> Cn_Status6 Then
			'         CP_SSSMAIN(4).StatusC = Cn_Status7
			'         CP_SSSMAIN(4).StatusF = Cn_Status7
			'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
			If CP_SSSMAIN(Wk_Index).StatusC = Cn_StatusError Then
				CP_SSSMAIN(Wk_Index).StatusC = Cn_Status2
				CP_SSSMAIN(Wk_Index).StatusF = Cn_Status2
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
			ElseIf CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status6 Then 
				CP_SSSMAIN(Wk_Index).StatusC = Cn_Status7
				CP_SSSMAIN(Wk_Index).StatusF = Cn_Status7
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
				Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
				' === 20110216 === UPDATE E
			End If
		End If
	End Sub
	
	Sub AE_EndCm_SSSMAIN() 'Generated.
		If PP_SSSMAIN.CloseCode = 29 Or (PP_SSSMAIN.CloseCode = 2 And PP_SSSMAIN.UnloadMode = 3) Then
		ElseIf PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then 
			If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then Exit Sub
		Else
			If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then Exit Sub
		End If
        ' === 20110217 === DELETE S TOM)Morimoto
        '   wk_Var = SSSMAIN_Close()
        ' === 20110217 === DELETE E
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If wk_Var = -1 Then
            '2019/10/15 DEL START
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            '2019/10/15 DEL END
            Call AE_WindowProcReset(PP_SSSMAIN)
            '2019/10/15 DEL START
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '2019/10/15 DEL END
            If PP_SSSMAIN.hIMC <> 0 Then
                Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
            End If
#If ActiveXcompile = 0 Then
            End
#End If
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
	
	' === 20110217 === DELETE S TOM)Morimoto
	'Function AE_Execute_SSSMAIN() As Integer 'Generated.
	'Dim wk_ReturnCd As Integer
	'Dim wk_De As Integer
	'   With PP_SSSMAIN
	'   If CP_SSSMAIN(.Px).StatusC = Cn_Status1 Then
	'      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(.Px)), Cn_Status6, True)
	'   End If
	'   If .Mode = Cn_Mode3 Then
	'      Exit Function
	'   End If
	'   If AE_CompleteCheck_SSSMAIN(False) > 0 Then AE_Execute_SSSMAIN = Cn_CuInCompletePx: Exit Function
	'   If .Mode = Cn_Mode1 Then
	'      If AE_MsgLibrary(PP_SSSMAIN, "Append") Then AE_Execute_SSSMAIN = Cn_CuCurrent: Exit Function
	'
	'      wk_ReturnCd = SSSMAIN_Append()
	'      .ServerCheck = 1000
	'      If wk_ReturnCd >= .ServerCheck And wk_ReturnCd <= .ServerCheck + 5 Then
	'         wk_ReturnCd = wk_ReturnCd - .ServerCheck
	'      Else
	'         .ServerCheck = False
	'      End If
	'      AE_Execute_SSSMAIN = Cn_CuInit
	'      If wk_ReturnCd = 0 Then Exit Function
	'      Call AE_Term_SSSMAIN
	'      If wk_ReturnCd = 1 Then
	'         AE_Execute_SSSMAIN = AE_SelectCm_SSSMAIN(Cn_Mode1, True)
	'      ElseIf wk_ReturnCd = 2 Then
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode1, .ServerCheck)
	'      ElseIf wk_ReturnCd = 3 Then
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode1, .ServerCheck)
	'      ElseIf wk_ReturnCd = 4 Then
	'         AE_Execute_SSSMAIN = AE_UpdateC_SSSMAIN(Cn_Mode1, .ServerCheck)
	'      Else
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         Call AE_InitValAll_SSSMAIN
	'         AE_Execute_SSSMAIN = Cn_CuInit
	'      End If
	'      .ExMessage = (AE_StatusBar(.ScX))
	'   ElseIf .Mode = Cn_Mode2 Then
	'      If AE_MsgLibrary(PP_SSSMAIN, "SelectE") Then AE_Execute_SSSMAIN = Cn_CuCurrent: Exit Function
	'      AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode2, False)
	'      Exit Function
	'   ElseIf .Mode = Cn_Mode4 Then
	'      If .InitValStatus <> .Mode Then
	'         If AE_MsgLibrary(PP_SSSMAIN, "Update") Then AE_Execute_SSSMAIN = Cn_CuCurrent: Exit Function
	'      Else
	'         If AE_MsgLibrary(PP_SSSMAIN, "Update2") Then AE_Execute_SSSMAIN = Cn_CuCurrent: Exit Function
	'      End If
	'      wk_ReturnCd = SSSMAIN_Update()
	'      .ServerCheck = 1000
	'      If wk_ReturnCd >= .ServerCheck And wk_ReturnCd <= .ServerCheck + 5 Then
	'         wk_ReturnCd = wk_ReturnCd - .ServerCheck
	'      Else
	'         .ServerCheck = False
	'      End If
	'      AE_Execute_SSSMAIN = Cn_CuInit
	'      If wk_ReturnCd = 0 Then Exit Function
	'      Call AE_Term_SSSMAIN
	'      If wk_ReturnCd = 1 Then
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_SelectCm_SSSMAIN(Cn_Mode4, True)
	'      ElseIf wk_ReturnCd = 2 Then
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode4, .ServerCheck)
	'      ElseIf wk_ReturnCd = 3 Then
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_Indicate_SSSMAIN(Cn_Mode4, .ServerCheck)
	'      ElseIf wk_ReturnCd = 4 Then
	'         If .ServerCheck = False Then AE_Execute_SSSMAIN = AE_NextCm_SSSMAIN(True)
	'      ElseIf wk_ReturnCd = 104 Then
	'         If .ServerCheck = False Then AE_Execute_SSSMAIN = AE_Current_SSSMAIN()
	'      Else
	'         Call AE_ClearInitValStatus_SSSMAIN
	'         AE_Execute_SSSMAIN = AE_AppendC_SSSMAIN(Cn_Mode4)
	'      End If
	'      .ExMessage = (AE_StatusBar(.ScX))
	'   End If
	'   End With
	'End Function
	' === 20110217 === DELETE E
	
	Function AE_ExecuteX_SSSMAIN() As Short 'Generated.
		Dim wk_Cursor As Short
		AE_ExecuteX_SSSMAIN = Cn_CuCurrent
		If PP_SSSMAIN.Executing = False Then
			PP_SSSMAIN.Executing = True
			' === 20110216 === UPDATE S TOM)Morimoto
			'      wk_Cursor = AE_Execute_SSSMAIN()
			'      AE_ExecuteX_SSSMAIN = wk_Cursor
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Get_Index(HD_ENDTOKCD, CQ_SSSMAIN)).CuVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Get_Index(HD_STTTOKCD, CQ_SSSMAIN)).CuVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Get_Index(HD_FRNKB, CQ_SSSMAIN)).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_Execute(CP_SSSMAIN(Get_Index("HD_THSCD", CQ_SSSMAIN)).CuVal, CP_SSSMAIN(Get_Index("HD_FRNKB", CQ_SSSMAIN)).CuVal, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Get_Index("HD_STTTOKCD", CQ_SSSMAIN)).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)).CuVal))
			' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Px < 7
		Do While wk_Px < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
			wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFs
			CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
			wk_Px = wk_Px + 1
		Loop 
		PP_SSSMAIN.MaskMode = True
		Call AE_InitValHd_SSSMAIN(-2, False, Cn_Status0)
		PP_SSSMAIN.MaskMode = False
		Call AE_ClearInitValStatus_SSSMAIN()
		Call AE_StatusClear(PP_SSSMAIN, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClErrorStatus))
		' === 20110217 === DELETE S TOM)Morimoto
		'   wk_Var = SSSMAIN_Init()
		' === 20110217 === DELETE E
		wk_Px = 0
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Px < 7
		Do While wk_Px < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
			CP_SSSMAIN(wk_Px).IniStr = CP_SSSMAIN(wk_Px).TpStr
			wk_Px = wk_Px + 1
		Loop 
	End Sub
	
	Sub AE_InitValBd_SSSMAIN() 'Generated.
		Dim wk_Px As Short
		Dim wk_InOutMode As Integer
		Dim wk_De As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Px = 7
		'   Do While wk_Px < 7
		wk_Px = PP_SSSMAIN.HeadN
		Do While wk_Px < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   wk_Px = 7
		'   Do While wk_Px < 7
		wk_Px = PP_SSSMAIN.HeadN
		Do While wk_Px < PP_SSSMAIN.HeadN
			' === 20110216 === UPDATE E
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
		Dim strName As String
		Dim Wk_Index As Short
		If pm_Px = -2 Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'      Call AE_TabStop_SSSMAIN(0, 6, pm_SetInOut)
			Call AE_TabStop_SSSMAIN(0, PP_SSSMAIN.HeadN - 1, pm_SetInOut)
			' === 20110216 === UPDATE E
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
		If pm_Px = -2 Or pm_Px = 2 Then 'THSCD
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(2), THSCD_InitVal(), pm_Status)
		End If
		' === 20110216 === INSERT S TOM)Morimoto
		If pm_Px >= 0 Then
			strName = CQ_SSSMAIN(pm_Px)
		End If
		If pm_Px = -2 Or strName = "HD_FRNKB" Then 'STTTOKCD
			Wk_Index = Get_Index("HD_FRNKB", CQ_SSSMAIN)
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(Wk_Index), FRNKB_InitVal(), pm_Status)
		End If
		' === 20110216 === INSERT E
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If pm_Px = -2 Or pm_Px = 3 Then 'STTTOKCD
		'      Call AE_InitVal_SSSMAIN(CP_SSSMAIN(3), STTTOKCD_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal)), pm_Status)
		If pm_Px = -2 Or strName = "HD_STTTOKCD" Then 'STTTOKCD
			Wk_Index = Get_Index("HD_STTTOKCD", CQ_SSSMAIN)
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(Wk_Index), STTTOKCD_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal)), pm_Status)
			' === 20110216 === UPDATE E
			Call AE_InitValHd_SSSMAIN_STTTOKCD(pm_Px)
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If pm_Px = -2 Or pm_Px = 4 Then 'STTTOKNM
		'      Call AE_InitVal_SSSMAIN(CP_SSSMAIN(4), STTTOKNM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal), PP_SSSMAIN.De2), pm_Status)
		If pm_Px = -2 Or strName = "HD_STTTOKNM" Then 'STTTOKNM
			Wk_Index = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(Wk_Index), STTTOKNM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal), PP_SSSMAIN.De2), pm_Status)
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If pm_Px = -2 Or pm_Px = 5 Then 'ENDTOKCD
		'      Call AE_InitVal_SSSMAIN(CP_SSSMAIN(5), ENDTOKCD_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal)), pm_Status)
		If pm_Px = -2 Or strName = "HD_ENDTOKCD" Then 'ENDTOKCD
			Wk_Index = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(Wk_Index), ENDTOKCD_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal)), pm_Status)
			' === 20110216 === UPDATE E
			Call AE_InitValHd_SSSMAIN_ENDTOKCD(pm_Px)
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If pm_Px = -2 Or pm_Px = 6 Then 'ENDTOKNM
		'      Call AE_InitVal_SSSMAIN(CP_SSSMAIN(6), ENDTOKNM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal), PP_SSSMAIN.De2), pm_Status)
		If pm_Px = -2 Or strName = "HD_ENDTOKNM" Then 'ENDTOKNM
			Wk_Index = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
			Call AE_InitVal_SSSMAIN(CP_SSSMAIN(Wk_Index), ENDTOKNM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal), PP_SSSMAIN.De2), pm_Status)
			' === 20110216 === UPDATE E
		End If
		If pm_Px = -2 Then
			PP_SSSMAIN.DerivedFrom = "(InitVal)"
			PP_SSSMAIN.DerivedOrigin = ""
			Call AE_RecalcHdSub_SSSMAIN()
		End If
	End Sub
	
	Sub AE_InitValHd_SSSMAIN_STTTOKCD(ByVal pm_Px As Short) 'Generated.
		Dim CC_NewVal As Object
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CC_NewVal = CP_SSSMAIN(6).CuVal
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = CP_SSSMAIN(Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)).CuVal
		' === 20110216 === UPDATE E
		PP_SSSMAIN.DerivedOrigin = "HD_STTTOKCD"
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_hd_STTTOKNM(PP_SSSMAIN.De2)
	End Sub
	
	Sub AE_InitValHd_SSSMAIN_ENDTOKCD(ByVal pm_Px As Short) 'Generated.
		Dim CC_NewVal As Object
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CC_NewVal = CP_SSSMAIN(6).CuVal
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CC_NewVal = CP_SSSMAIN(Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)).CuVal
		' === 20110216 === UPDATE E
		PP_SSSMAIN.DerivedOrigin = "HD_ENDTOKCD"
		If pm_Px >= 0 And Not PP_SSSMAIN.SuppressMultiTlDerived Then Call AE_Derived_SSSMAIN_hd_ENDTOKNM(PP_SSSMAIN.De2)
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Qx < 7 And UCase$(Mid$(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA$
		Do While wk_Qx < PP_SSSMAIN.HeadN And UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA
			' === 20110216 === UPDATE E
			wk_Qx = wk_Qx + 1
		Loop 
		If UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA Then
			Call AE_SystemError("AE_InOutModeM �̃p�����^ pm_ItemName$ ��", 550)
			Exit Sub
		End If
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutModeM �̃p�����^ pm_Mode$ ��", 551)
			Exit Sub
		End If
		wk_BodyV = 1
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If wk_Qx < 7 Then
		If wk_Qx < PP_SSSMAIN.HeadN Then
			' === 20110216 === UPDATE E
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
		' === 20110216 === UPDATE S TOM)Morimoto
		'   Do While wk_Qx < 7 And Mid$(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> wk_UCaseObjA$
		Do While wk_Qx < PP_SSSMAIN.HeadN And Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> wk_UCaseObjA
			' === 20110216 === UPDATE E
			wk_Qx = wk_Qx + 1
		Loop 
		If UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA Then
			Call AE_SystemError("AE_InOutModeN �̃p�����^ pm_ItemName$ ��", 552)
			Exit Sub
		End If
		If Len(pm_Mode) <> 4 Then
			Call AE_SystemError("AE_InOutModeN �̃p�����^ pm_Mode$ ��", 553)
			Exit Sub
		End If
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If Not IsNothing(pm_De) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_De �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If pm_De < 0 Or pm_De > -1 Then
				Call AE_SystemError("AE_InOutModeN �̃p�����^ pm_De ��", 554)
				Exit Sub
			End If
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If wk_Qx < 7 Then
		If wk_Qx < PP_SSSMAIN.HeadN Then
			' === 20110216 === UPDATE E
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
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(Valu) Then
			AE_IsNull_SSSMAIN = True
			'UPGRADE_WARNING: �I�u�W�F�N�g Valu �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf Ct Is System.Windows.Forms.TextBox Then
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'Ct.Locked = False
            Ct.Enabled = True
            '2019/10/15 CHG END
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
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'wk_SS = Ct.SelStart
                wk_SS = DirectCast(Ct, TextBox).SelectionStart
                '2019/10/15 CHG END
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
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '2019/10/15 CHG END
                If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '���l��
                    wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownRightEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS - 1
                    Loop
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '2019/10/15 CHG END
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'Ct.SelStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).SelectionStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    '2019/10/15 CHG END
                End If
AE_KeyDownRightEnd1_SSSMAIN:
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '2019/10/15 CHG END
            Else
                wk_Ln = Len(wk_Txt)
				If wk_SS = wk_Ln Then
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
				ElseIf wk_SS <= wk_Ln - 2 Or wk_Ln <= 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0 Then 
					Do While wk_SS <= wk_Ln - 2
						wk_SS = wk_SS + 1
						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						ElseIf Mid(wk_Txt, wk_SS, 1) = Space(1) And Not AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then 
							Exit Do
						End If
					Loop 
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
AE_KeyDownRightEnd2_SSSMAIN: 
				Else
					If (CP_SSSMAIN(wk_Px).Alignment <> 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0) Or PP_SSSMAIN.Mode = Cn_Mode3 Then '���l��
						If PP_SSSMAIN.Override And PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
						If AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS + 1, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS + 1
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS + 1, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
						End If
					Else
                        'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/10/15 CHG START
                        'Ct.SelStart = wk_Ln
                        '                  'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '                  Ct.SelLength = PP_SSSMAIN.Override
                        DirectCast(Ct, TextBox).Select(wk_Ln, PP_SSSMAIN.Override)
                        '2019/10/15 CHG END
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
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '2019/10/15 CHG END
                If CP_SSSMAIN(wk_Px).Alignment = 1 Then '�E�l��
                    wk_SS = 0
                    wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS < wk_Ln
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '2019/10/15 CHG END
                            GoTo AE_KeyDownLeftEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS + 1
                    Loop
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'Ct.SelStart = wk_Ln
                    DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                    '2019/10/15 CHG END
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '2019/10/15 CHG END
                End If
AE_KeyDownLeftEnd1_SSSMAIN:
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).Select(wk_SS - 1, PP_SSSMAIN.Override)
                '2019/10/15 CHG END
            Else
                If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
					PP_SSSMAIN.Override = 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'Ct.SelStart = wk_SS - 1
                    '               'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '               Ct.SelLength = PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).Select(wk_SS - 1, PP_SSSMAIN.Override)
                    '2019/10/15 CHG END
                ElseIf wk_SS = 0 Then 
					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
				Else
					Do While wk_SS > 0
						wk_Moji = Mid(wk_Txt, wk_SS, 1)
						wk_SS = wk_SS - 1
						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/10/15 CHG START
                            'Ct.SelStart = wk_SS
                            '                     'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '                     Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '2019/10/15 CHG END
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
            '2019/10/15 CHG START
            'wk_Ln = Len(Ct)
            wk_Ln = Len(Ct.Text)
            '2019/10/15 CHG START
            If CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("-") Then
                Exit Function
            ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then
                Exit Function
            ElseIf Not AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Or Not AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
                Exit Function
            ElseIf CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                If AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'ElseIf Ct.SelLength = wk_Ln And wk_Ln > 1 Then
            ElseIf DirectCast(Ct, TextBox).SelectionLength = wk_Ln And wk_Ln > 1 Then
                '2019/10/15 CHG START
                wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
                If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
            ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then
                wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
            ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                    '2019/10/15 CHG END
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + Ct.SelLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, Ct.SelLength))) 'V6.52
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + DirectCast(Ct, TextBox).SelectionLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, DirectCast(Ct, TextBox).SelectionLength))) 'V6.52
                    '2019/10/15 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
				End If
				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
						wk_Txt = ""
					End If
				End If
			Else
				wk_SS2 = wk_SS
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'If Ct.SelLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                If DirectCast(Ct, TextBox).SelectionLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                '2019/10/15 CHG END
                If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
					If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
						Beep()
						Exit Function
					End If
				End If
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                    '2019/10/15 CHG END
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/15 CHG START
                    'wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, Ct.SelLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + Ct.SelLength + 1) 'V6.52
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, DirectCast(Ct, TextBox).SelectionLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + DirectCast(Ct, TextBox).SelectionLength + 1) 'V6.52
                    '2019/10/15 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, 1))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2)
				End If
				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
						wk_SS = wk_Ln
						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
						wk_Txt = ""
						wk_SS = wk_Ln
					End If
				End If
			End If
			pm_TA = AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC), CP_SSSMAIN(wk_Px).FractionC, False)
			PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'Ct = pm_TA
            DirectCast(Ct, TextBox).Text = pm_TA
            '2019/10/15 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'Ct.SelStart = wk_SS
            DirectCast(Ct, TextBox).SelectionStart = wk_SS
            '2019/10/15 CHG END
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
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then Ct.SelStart = wk_Ln - 1
            If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then DirectCast(Ct, TextBox).SelectionStart = wk_Ln - 1
            '2019/10/15 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'Ct.SelLength = PP_SSSMAIN.Override
            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            '2019/10/15 CHG END
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
		' === 20110217 === DELETE S TOM)Morimoto
		'   PP_SSSMAIN.LastDe = SSSMAIN_Last()
		' === 20110217 === DELETE E
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
					PP_SSSMAIN.Mode = Cn_Mode1 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�ǉ�"
					Call AE_TabStop_SSSMAIN(0, 6, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode2
				If PP_SSSMAIN.Mode <> Cn_Mode2 Then
					PP_SSSMAIN.Mode = Cn_Mode2 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�I��"
					Call AE_TabStop_SSSMAIN(0, 6, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Cn_Mode3
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					PP_SSSMAIN.Mode = Cn_Mode3 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�\��"
					Call AE_TabStop_SSSMAIN(0, 6, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
				End If
			Case Cn_Mode4
				If PP_SSSMAIN.Mode <> Cn_Mode4 Then
					PP_SSSMAIN.Mode = Cn_Mode4 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�X�V"
					Call AE_TabStop_SSSMAIN(0, 6, False)
					AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
				End If
			Case Else
				Call AE_SystemError("AE_ModeChange �̃p�����^��", 562)
		End Select
	End Sub
	
	Function AE_NextCm_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
		If pm_Check Then
			If AE_MsgLibrary(PP_SSSMAIN, "NextC") Then AE_NextCm_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		Call AE_InitValAll_SSSMAIN()
		' === 20110217 === DELETE S TOM)Morimoto
		'   PP_SSSMAIN.LastDe = SSSMAIN_Next()
		' === 20110217 === DELETE E
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
		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If IsNothing(Valu) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv1_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv1_SSSMAIN = 0@
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf IsDbNull(Valu) Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv1_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv1_SSSMAIN = 0@
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g Valu �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv1_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv1_SSSMAIN = Valu
		End If
	End Function
	
	Function AE_NullCnv2_SSSMAIN(ByVal Valu As Object) As Object 'Generated.
		'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If IsNothing(Valu) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv2_SSSMAIN = ""
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf IsDbNull(Valu) Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv2_SSSMAIN = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g Valu �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			AE_NullCnv2_SSSMAIN = Valu
		End If
	End Function
	
	Sub AE_RecalcAll_SSSMAIN() 'Generated.
		PP_SSSMAIN.DerivedOrigin = ""
		Call AE_RecalcHd_SSSMAIN()
	End Sub
	
	Sub AE_RecalcHd_SSSMAIN() 'Generated.
		Dim wkIndex As Short
		PP_SSSMAIN.RecalcMode = True
		If AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(0).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPEID(AE_Val2(CP_SSSMAIN(0)), CP_SSSMAIN(0).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(1).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPENM(AE_Val2(CP_SSSMAIN(1)), CP_SSSMAIN(1).StatusF, False, False)
		End If
		If AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(2).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_THSCD(AE_Val2(CP_SSSMAIN(2)), CP_SSSMAIN(2).StatusF, False, False)
		End If
		' === 20110216 === INSERT S TOM)Morimoto
		wkIndex = Get_Index("HD_FRNKB", CQ_SSSMAIN)
		If AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(wkIndex).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_FRNKB(AE_Val2(CP_SSSMAIN(wkIndex)), CP_SSSMAIN(wkIndex).StatusF, False, False)
		End If
		' === 20110216 === INSERT E
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
		'      If CP_SSSMAIN(3).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val2(CP_SSSMAIN(3)), CP_SSSMAIN(3).StatusF, False, False)
		wkIndex = Get_Index("HD_STTTOKCD", CQ_SSSMAIN)
		If AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(wkIndex).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val2(CP_SSSMAIN(wkIndex)), CP_SSSMAIN(wkIndex).StatusF, False, False)
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
		'      If CP_SSSMAIN(4).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val2(CP_SSSMAIN(4)), CP_SSSMAIN(4).StatusF, False, False)
		wkIndex = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
		If AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(wkIndex).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_STTTOKNM(AE_Val2(CP_SSSMAIN(wkIndex)), CP_SSSMAIN(wkIndex).StatusF, False, False)
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
		'      If CP_SSSMAIN(5).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val2(CP_SSSMAIN(5)), CP_SSSMAIN(5).StatusF, False, False)
		wkIndex = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
		If AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(wkIndex).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val2(CP_SSSMAIN(wkIndex)), CP_SSSMAIN(wkIndex).StatusF, False, False)
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
		'      If CP_SSSMAIN(6).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val2(CP_SSSMAIN(6)), CP_SSSMAIN(6).StatusF, False, False)
		wkIndex = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
		If AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(wkIndex).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
			If CP_SSSMAIN(wkIndex).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ENDTOKNM(AE_Val2(CP_SSSMAIN(wkIndex)), CP_SSSMAIN(wkIndex).StatusF, False, False)
			' === 20110216 === UPDATE E
		End If
		PP_SSSMAIN.DerivedFrom = "(Recalc)"
		If Left(PP_SSSMAIN.DerivedOrigin, 1) <> "H" Then
			PP_SSSMAIN.DerivedOrigin = ""
		End If
		Call AE_RecalcHdSub_SSSMAIN()
		PP_SSSMAIN.RecalcMode = False
	End Sub
	
	Sub AE_RecalcHdSub_SSSMAIN() 'Generated.
		Call AE_Derived_SSSMAIN_hd_ENDTOKNM(PP_SSSMAIN.De2)
		Call AE_Derived_SSSMAIN_hd_STTTOKNM(PP_SSSMAIN.De2)
	End Sub
	
	Function AE_SelectCm_SSSMAIN(ByVal pm_ExMode As Short, ByVal pm_Init As Boolean) As Short 'Generated.
		Dim wk_ReturnCd As Short
		If PP_SSSMAIN.Mode = Cn_Mode2 Then AE_SelectCm_SSSMAIN = Cn_CuCurrent : Exit Function
		If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
			If PP_SSSMAIN.ChOprtMode = 0 Then
				If AE_MsgLibrary(PP_SSSMAIN, "SelectCm") Then AE_SelectCm_SSSMAIN = Cn_CuCurrent : Exit Function
			End If
		End If
		' === 20110217 === DELETE S TOM)Morimoto
		'   wk_ReturnCd = SSSMAIN_Select()
		' === 20110217 === DELETE E
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
			' === 20110216 === UPDATE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx < 7 Then
		ElseIf PP_SSSMAIN.Tx < PP_SSSMAIN.HeadN Then 
			' === 20110216 === UPDATE E
			' === 20110216 === UPDATE S TOM)Morimoto
			'      Select Case PP_SSSMAIN.Px
			'         Case 0
			Select Case CQ_SSSMAIN(PP_SSSMAIN.Px)
				Case "HD_OPEID"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_OPEID(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 1
				Case "HD_OPENM"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_OPENM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 2
				Case "HD_THSCD"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_THSCD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
					' === 20110216 === INSERT S TOM)Morimoto
				Case "HD_FRNKB"
					Call AE_Check_SSSMAIN_FRNKB(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
					' === 20110216 === INSERT E
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 3
				Case "HD_STTTOKCD"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_STTTOKCD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
						PP_SSSMAIN.DerivedOrigin = "HD_STTTOKCD"
						Call AE_Derived_SSSMAIN_hd_STTTOKNM(PP_SSSMAIN.De2)
					End If
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 4
				Case "HD_STTTOKNM"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_STTTOKNM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 5
				Case "HD_ENDTOKCD"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_ENDTOKCD(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
						PP_SSSMAIN.DerivedOrigin = "HD_ENDTOKCD"
						Call AE_Derived_SSSMAIN_hd_ENDTOKNM(PP_SSSMAIN.De2)
					End If
					' === 20110216 === UPDATE S TOM)Morimoto
					'         Case 6
				Case "HD_ENDTOKNM"
					' === 20110216 === UPDATE E
					Call AE_Check_SSSMAIN_ENDTOKNM(CC_NewVal, pm_Status, False, pm_HandIn)
					If AE_ErrorToInteger(Ck_Error) = 0 Then
					End If
			End Select
		End If
	End Sub
	
	Sub AE_Slist_SSSMAIN() 'Generated.
		Dim wk_Slisted As Object
		Dim Wk_Index As Short
		Dim wk_Index1 As Short
		Wk_Index = Get_Index("HD_STTTOKCD", CQ_SSSMAIN)
		wk_Index1 = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
		If False Then
			' === 20110216 === UPDATE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx = 3 Then
		ElseIf PP_SSSMAIN.Tx = Wk_Index Then 
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			' === 20110216 === DELETE S TOM)Morimoto
			'      wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal))
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(Wk_Index).CuVal))
			' === 20110216 === DELETE E
			PP_SSSMAIN.NeglectLostFocusCheck = False
			'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(wk_Slisted) Then
				PP_SSSMAIN.CursorDest = Cn_Dest9
				PP_SSSMAIN.SlistPx = -1
				PP_SSSMAIN.JustAfterSList = True
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				PP_SSSMAIN.SlistCom = System.DBNull.Value
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					' === 20110216 === UPDATE S TOM)Morimoto
					'            CP_SSSMAIN(3).TpStr = wk_Slisted
					'            CP_SSSMAIN(3).CIn = Cn_ChrInput
					'            AE_Controls(PP_SSSMAIN.CtB + 3) = wk_Slisted
					'            Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(3), (AE_Controls(PP_SSSMAIN.CtB + 3))), Cn_Status6, True, True)
					'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					CP_SSSMAIN(Wk_Index).TpStr = wk_Slisted
					CP_SSSMAIN(Wk_Index).CIn = Cn_ChrInput
					'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + Wk_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP_SSSMAIN.CtB + Wk_Index) = wk_Slisted
					Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(Wk_Index), AE_Controls(PP_SSSMAIN.CtB + Wk_Index).ToString()), Cn_Status6, True, True)
					' === 20110216 === UPDATE E
				End If
			Else
				PP_SSSMAIN.CursorDest = Cn_Dest0
				PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
			End If
			' === 20110216 === UPDATE S TOM)Morimoto
			'   ElseIf PP_SSSMAIN.Tx = 5 Then
		ElseIf PP_SSSMAIN.Tx = wk_Index1 Then 
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SlistCom = System.DBNull.Value
			PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
			PP_SSSMAIN.NeglectLostFocusCheck = True
			' === 20110216 === DELETE S TOM)Morimoto
			'      wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_Slisted = ENDTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(wk_Index1).CuVal))
			' === 20110216 === DELETE E
			PP_SSSMAIN.NeglectLostFocusCheck = False
			'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If Not IsDbNull(wk_Slisted) Then
				PP_SSSMAIN.CursorDest = Cn_Dest9
				PP_SSSMAIN.SlistPx = -1
				PP_SSSMAIN.JustAfterSList = True
				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				PP_SSSMAIN.SlistCom = System.DBNull.Value
				If PP_SSSMAIN.Mode <> Cn_Mode3 Then
					' === 20110216 === UPDATE S TOM)Morimoto
					'            CP_SSSMAIN(5).TpStr = wk_Slisted
					'            CP_SSSMAIN(5).CIn = Cn_ChrInput
					'            AE_Controls(PP_SSSMAIN.CtB + 5) = wk_Slisted
					'            Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(5), (AE_Controls(PP_SSSMAIN.CtB + 5))), Cn_Status6, True, True)
					'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					CP_SSSMAIN(wk_Index1).TpStr = wk_Slisted
					CP_SSSMAIN(wk_Index1).CIn = Cn_ChrInput
					'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + wk_Index1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					AE_Controls(PP_SSSMAIN.CtB + wk_Index1) = wk_Slisted
					Call AE_Check_SSSMAIN_ENDTOKCD(AE_Val3(CP_SSSMAIN(wk_Index1), AE_Controls(PP_SSSMAIN.CtB + wk_Index1).ToString()), Cn_Status6, True, True)
					' === 20110216 === UPDATE E
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
			' === 20110216 === UPDATE S TOM)Morimoto
			'      If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < 7 Then
			If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < PP_SSSMAIN.HeadN Then
				' === 20110216 === UPDATE E
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
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_ExVal = CP_SSSMAIN(PP_SSSMAIN.Px).CuVal
			wk_ExStatus = CP_SSSMAIN(PP_SSSMAIN.Px).StatusF
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_SaveValue �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_SaveValue = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
			wk_SaveStatus = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wk_ExVal = CP_SSSMAIN(PP_SSSMAIN.Px).ExVal
			wk_ExStatus = CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus
			If wk_ExStatus = 0 Then Exit Sub
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g wk_SaveValue �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
            ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'AE_StatusBar(PP_SSSMAIN.ScX) = ""

            AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
            '2019/10/15 CHG END
            Call AE_SetCheck_SSSMAIN(wk_ExVal, wk_ExStatus, False)
		End If
		Call AE_CursorCurrent_SSSMAIN()
		'UPGRADE_WARNING: �I�u�W�F�N�g wk_SaveValue �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		Dim wk_Tx As Short
		For wk_Tx = 0 To PP_SSSMAIN.ControlsC - 1
            'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
            '2019/10/15 DEL START
            'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
            '2019/10/15 DEL END
        Next wk_Tx
        'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
        '2019/10/15 DEL START
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_StatusBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_ModeBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '2019/10/15 DEL END
    End Sub
	
	Sub DP_SSSMAIN_ENDTOKCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim Wk_Index As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		' === 20110216 === UPDATE S TOM)Morimoto
		'   V = AE_NormData(CP_SSSMAIN(5), AE_Val3(CP_SSSMAIN(5), CStr(DBItem)))
		'   If CP_SSSMAIN(5).CuVal <> V Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(5).StatusC = Cn_Status6: CP_SSSMAIN(5).StatusF = Cn_Status6
		'   ElseIf (IsNull(CP_SSSMAIN(5).CuVal) Xor IsNull(V)) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(5).StatusC = Cn_Status6: CP_SSSMAIN(5).StatusF = Cn_Status6
		Wk_Index = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(Wk_Index), AE_Val3(CP_SSSMAIN(Wk_Index), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Wk_Index).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(Wk_Index).CuVal <> V Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(Wk_Index).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(5).CheckRtnCode = 0
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5))
		'   CP_SSSMAIN(5).CuVal = V
		'   CP_SSSMAIN(5).TpStr = AE_Format$(CP_SSSMAIN(5), CP_SSSMAIN(5).CuVal, 0, True)
		'   Call AE_CtSet(PP_SSSMAIN, 5, CP_SSSMAIN(5).TpStr, CP_SSSMAIN(5).TypeA, False)
		CP_SSSMAIN(Wk_Index).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(Wk_Index).CuVal = V
		CP_SSSMAIN(Wk_Index).TpStr = AE_Format(CP_SSSMAIN(Wk_Index), CP_SSSMAIN(Wk_Index).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, Wk_Index, CP_SSSMAIN(Wk_Index).TpStr, CP_SSSMAIN(Wk_Index).TypeA, False)
		' === 20110216 === UPDATE E
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_ENDTOKNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim Wk_Index As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		' === 20110216 === UPDATE S TOM)Morimoto
		'   V = AE_NormData(CP_SSSMAIN(6), AE_Val3(CP_SSSMAIN(6), CStr(DBItem)))
		'   If CP_SSSMAIN(6).CuVal <> V Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(6).StatusC = Cn_Status6: CP_SSSMAIN(6).StatusF = Cn_Status6
		'   ElseIf (IsNull(CP_SSSMAIN(6).CuVal) Xor IsNull(V)) Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(6).StatusC = Cn_Status6: CP_SSSMAIN(6).StatusF = Cn_Status6
		Wk_Index = Get_Index("HD_ENDTOKNM", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(Wk_Index), AE_Val3(CP_SSSMAIN(Wk_Index), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Wk_Index).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(Wk_Index).CuVal <> V Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(Wk_Index).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(6).CheckRtnCode = 0
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
		'   CP_SSSMAIN(6).CuVal = V
		'   CP_SSSMAIN(6).TpStr = AE_Format$(CP_SSSMAIN(6), CP_SSSMAIN(6).CuVal, 0, True)
		'   Call AE_CtSet(PP_SSSMAIN, 6, CP_SSSMAIN(6).TpStr, CP_SSSMAIN(6).TypeA, False)
		CP_SSSMAIN(Wk_Index).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(Wk_Index).CuVal = V
		CP_SSSMAIN(Wk_Index).TpStr = AE_Format(CP_SSSMAIN(Wk_Index), CP_SSSMAIN(Wk_Index).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, Wk_Index, CP_SSSMAIN(Wk_Index).TpStr, CP_SSSMAIN(Wk_Index).TypeA, False)
		' === 20110216 === UPDATE E
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_OPEID(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(0), AE_Val3(CP_SSSMAIN(0), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(0).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(0).StatusC = Cn_Status6 : CP_SSSMAIN(0).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(0).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(0).StatusC = Cn_Status6 : CP_SSSMAIN(0).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(0).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(1), AE_Val3(CP_SSSMAIN(1), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(1).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(1).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(1).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(1).CuVal = V
		CP_SSSMAIN(1).TpStr = AE_Format(CP_SSSMAIN(1), CP_SSSMAIN(1).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 1, CP_SSSMAIN(1).TpStr, CP_SSSMAIN(1).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_STTTOKCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim Wk_Index As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		' === 20110216 === UPDATE S TOM)Morimoto
		'   V = AE_NormData(CP_SSSMAIN(3), AE_Val3(CP_SSSMAIN(3), CStr(DBItem)))
		'   If CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(3).StatusC = Cn_Status6: CP_SSSMAIN(3).StatusF = Cn_Status6
		'   ElseIf (IsNull(CP_SSSMAIN(3).CuVal) Xor IsNull(V)) Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(3).StatusC = Cn_Status6: CP_SSSMAIN(3).StatusF = Cn_Status6
		Wk_Index = Get_Index("HD_STTTOKCD", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(Wk_Index), AE_Val3(CP_SSSMAIN(Wk_Index), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Wk_Index).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(Wk_Index).CuVal <> V Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(Wk_Index).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(3).CheckRtnCode = 0
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3))
		'   CP_SSSMAIN(3).CuVal = V
		'   CP_SSSMAIN(3).TpStr = AE_Format$(CP_SSSMAIN(3), CP_SSSMAIN(3).CuVal, 0, True)
		'   Call AE_CtSet(PP_SSSMAIN, 3, CP_SSSMAIN(3).TpStr, CP_SSSMAIN(3).TypeA, False)
		CP_SSSMAIN(Wk_Index).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(Wk_Index).CuVal = V
		CP_SSSMAIN(Wk_Index).TpStr = AE_Format(CP_SSSMAIN(Wk_Index), CP_SSSMAIN(Wk_Index).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, Wk_Index, CP_SSSMAIN(Wk_Index).TpStr, CP_SSSMAIN(Wk_Index).TypeA, False)
		' === 20110216 === UPDATE E
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_STTTOKNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		Dim Wk_Index As Short
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		' === 20110216 === UPDATE S TOM)Morimoto
		'   V = AE_NormData(CP_SSSMAIN(4), AE_Val3(CP_SSSMAIN(4), CStr(DBItem)))
		'   If CP_SSSMAIN(4).CuVal <> V Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(4).StatusC = Cn_Status6: CP_SSSMAIN(4).StatusF = Cn_Status6
		'   ElseIf (IsNull(CP_SSSMAIN(4).CuVal) Xor IsNull(V)) Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
		'      CP_SSSMAIN(4).StatusC = Cn_Status6: CP_SSSMAIN(4).StatusF = Cn_Status6
		Wk_Index = Get_Index("HD_STTTOKNM", CQ_SSSMAIN)
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(Wk_Index), AE_Val3(CP_SSSMAIN(Wk_Index), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(Wk_Index).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(Wk_Index).CuVal <> V Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(Wk_Index).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(Wk_Index).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(Wk_Index).StatusC = Cn_Status6 : CP_SSSMAIN(Wk_Index).StatusF = Cn_Status6
			' === 20110216 === UPDATE E
		End If
		' === 20110216 === UPDATE S TOM)Morimoto
		'   CP_SSSMAIN(4).CheckRtnCode = 0
		'   Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
		'   CP_SSSMAIN(4).CuVal = V
		'   CP_SSSMAIN(4).TpStr = AE_Format$(CP_SSSMAIN(4), CP_SSSMAIN(4).CuVal, 0, True)
		'   Call AE_CtSet(PP_SSSMAIN, 4, CP_SSSMAIN(4).TpStr, CP_SSSMAIN(4).TypeA, False)
		CP_SSSMAIN(Wk_Index).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(Wk_Index).CuVal = V
		CP_SSSMAIN(Wk_Index).TpStr = AE_Format(CP_SSSMAIN(Wk_Index), CP_SSSMAIN(Wk_Index).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, Wk_Index, CP_SSSMAIN(Wk_Index).TpStr, CP_SSSMAIN(Wk_Index).TypeA, False)
		' === 20110216 === UPDATE E
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Sub DP_SSSMAIN_THSCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
		Dim V As Object
		Dim wk_SaveMask As Boolean
		wk_SaveMask = PP_SSSMAIN.MaskMode
		PP_SSSMAIN.MaskMode = True
		'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		V = AE_NormData(CP_SSSMAIN(2), AE_Val3(CP_SSSMAIN(2), CStr(DBItem)))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(2).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
			CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		ElseIf (IsDbNull(CP_SSSMAIN(2).CuVal) Xor IsDbNull(V)) Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then 
			CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
		End If
		CP_SSSMAIN(2).CheckRtnCode = 0
		Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2))
		'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CP_SSSMAIN(2).CuVal = V
		CP_SSSMAIN(2).TpStr = AE_Format(CP_SSSMAIN(2), CP_SSSMAIN(2).CuVal, 0, True)
		Call AE_CtSet(PP_SSSMAIN, 2, CP_SSSMAIN(2).TpStr, CP_SSSMAIN(2).TypeA, False)
		PP_SSSMAIN.MaskMode = wk_SaveMask
	End Sub
	
	Function RD_SSSMAIN_ENDTOKCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		Dim Wk_Index As Short
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If IsNull(CP_SSSMAIN(5).CuVal) Then
		Wk_Index = Get_Index("HD_ENDTOKCD", CQ_SSSMAIN)
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(Wk_Index).CuVal) Then
			' === 20110216 === UPDATE E
			RD_SSSMAIN_ENDTOKCD = Space(5)
		Else
			' === 20110216 === UPDATE S TOM)Morimoto
			'      st_Work$ = CStr(CP_SSSMAIN(5).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(Wk_Index).CuVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 5 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_ENDTOKCD = CStr(CP_SSSMAIN(5).CuVal) & Space$(5 - LenWid(st_Work$))
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_ENDTOKCD = CStr(CP_SSSMAIN(Wk_Index).CuVal) & Space(5 - LenWid(st_Work))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_ENDTOKCD = CStr(CP_SSSMAIN(5).CuVal)
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_ENDTOKCD = CStr(CP_SSSMAIN(Wk_Index).CuVal)
				' === 20110216 === UPDATE E
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_ENDTOKNM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If IsNull(CP_SSSMAIN(6).CuVal) Then
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(6).CuVal) Then
			' === 20110216 === UPDATE E
			RD_SSSMAIN_ENDTOKNM = Space(40)
		Else
			' === 20110216 === UPDATE S TOM)Morimoto
			'      st_Work$ = CStr(CP_SSSMAIN(6).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(6).CuVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 40 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_ENDTOKNM = CStr(CP_SSSMAIN(6).CuVal) & Space$(40 - LenWid(st_Work$))
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTOKNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_ENDTOKNM = CStr(CP_SSSMAIN(6).CuVal) & Space(40 - LenWid(st_Work))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_ENDTOKNM = CStr(CP_SSSMAIN(6).CuVal)
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTOKNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_ENDTOKNM = CStr(CP_SSSMAIN(6).CuVal)
				' === 20110216 === UPDATE E
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_OPEID(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(0).CuVal) Then
			RD_SSSMAIN_OPEID = Space(6)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(0).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 6 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(0).CuVal) & Space(6 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(0).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_OPENM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(1).CuVal) Then
			RD_SSSMAIN_OPENM = Space(20)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(1).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 20 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPENM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(1).CuVal) & Space(20 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPENM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(1).CuVal)
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_STTTOKCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If IsNull(CP_SSSMAIN(3).CuVal) Then
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(3).CuVal) Then
			' === 20110216 === UPDATE E
			RD_SSSMAIN_STTTOKCD = Space(5)
		Else
			' === 20110216 === UPDATE S TOM)Morimoto
			'      st_Work$ = CStr(CP_SSSMAIN(3).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(3).CuVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 5 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_STTTOKCD = CStr(CP_SSSMAIN(3).CuVal) & Space$(5 - LenWid(st_Work$))
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_STTTOKCD = CStr(CP_SSSMAIN(3).CuVal) & Space(5 - LenWid(st_Work))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_STTTOKCD = CStr(CP_SSSMAIN(3).CuVal)
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_STTTOKCD = CStr(CP_SSSMAIN(3).CuVal)
				' === 20110216 === UPDATE E
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_STTTOKNM(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		' === 20110216 === UPDATE S TOM)Morimoto
		'   If IsNull(CP_SSSMAIN(4).CuVal) Then
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(4).CuVal) Then
			' === 20110216 === UPDATE E
			RD_SSSMAIN_STTTOKNM = Space(40)
		Else
			' === 20110216 === UPDATE S TOM)Morimoto
			'      st_Work$ = CStr(CP_SSSMAIN(4).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(4).CuVal)
			' === 20110216 === UPDATE E
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 40 Then
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_STTTOKNM = CStr(CP_SSSMAIN(4).CuVal) & Space$(40 - LenWid(st_Work$))
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTOKNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_STTTOKNM = CStr(CP_SSSMAIN(4).CuVal) & Space(40 - LenWid(st_Work))
				' === 20110216 === UPDATE E
			Else
				' === 20110216 === UPDATE S TOM)Morimoto
				'         RD_SSSMAIN_STTTOKNM = CStr(CP_SSSMAIN(4).CuVal)
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTOKNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_STTTOKNM = CStr(CP_SSSMAIN(4).CuVal)
				' === 20110216 === UPDATE E
			End If
		End If
	End Function
	
	Function RD_SSSMAIN_THSCD(ByVal De As Short) As Object 'Generated.
		Dim st_Work As String
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(CP_SSSMAIN(2).CuVal) Then
			RD_SSSMAIN_THSCD = Space(1)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			st_Work = CStr(CP_SSSMAIN(2).CuVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If LenWid(st_Work) < 1 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_THSCD = CStr(CP_SSSMAIN(2).CuVal) & Space(1 - LenWid(st_Work))
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_THSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				RD_SSSMAIN_THSCD = CStr(CP_SSSMAIN(2).CuVal)
			End If
		End If
	End Function
	
	' === 20110216 === INSERT S TOM)Morimoto
	Private Function Get_Index(ByVal strctrlname As String, ByRef strCQ() As String) As Short
		Dim I As Short
		Dim flg As Boolean
		For I = 0 To UBound(strCQ)
			If strCQ(I) = strctrlname Then
				flg = True
				Exit For
			End If
		Next 
		If flg Then
			Get_Index = I
		Else
			Get_Index = -1
		End If
	End Function
	Public Function AE_Check_SSSMAIN_FRNKB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) As Object
		Dim wk_SaveMask As Boolean
		Dim RC_ErrorC As Short
		Dim wk_RecalcSw As Boolean
		Dim wk_Equal As Boolean
		Dim Wk_Index As Short
		Wk_Index = Get_Index("HD_FRNKB", CQ_SSSMAIN)
		Dim ex_CheckRtnCode As Short
		With CP_SSSMAIN(Wk_Index)
			ex_CheckRtnCode = .CheckRtnCode
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDbNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(Wk_Index), CC_NewVal)
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveXV = .ExVal
			PP_SSSMAIN.SaveExStatus = .ExStatus
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.ExVal = .CuVal
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveCV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			PP_SSSMAIN.SaveCV = .CuVal
			.ExStatus = .StatusF
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			If IsDbNull(CC_NewVal) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf .Alignment = 1 And LenWid(CC_NewVal) < .MaxLength Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				CC_NewVal = Space(.MaxLength - LenWid(CC_NewVal)) & CC_NewVal
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			If Not PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
                '2019/10/15 CHG END
            End If
			'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
			If (.CheckRtnCode <> 0) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = .CheckRtnCode
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = FRNKB_Check(CC_NewVal)
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Ck_Error = FRNKB_Check(CC_NewVal)
			End If
			.CheckRtnCode = AE_ErrorToInteger(Ck_Error)
			wk_SaveMask = PP_SSSMAIN.MaskMode
			PP_SSSMAIN.MaskMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CuVal = CC_NewVal
			.TpStr = AE_Format(CP_SSSMAIN(Wk_Index), .CuVal, 0, True)
			Call AE_CtSet(PP_SSSMAIN, Wk_Index, .TpStr, .TypeA, False)
			PP_SSSMAIN.MaskMode = wk_SaveMask
			If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
					wk_Equal = True
				Else
					wk_Equal = False
					Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				End If
				If wk_Equal And ex_CheckRtnCode = 0 And pm_Status >= Cn_Status6 And pm_Status = .StatusC And Not PP_SSSMAIN.RecalcMode Then
					'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SaveXV �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.ExVal = PP_SSSMAIN.SaveXV
					.ExStatus = PP_SSSMAIN.SaveExStatus
					Call AE_Later_SSSMAIN()
					If pm_MoveCursor Then
						If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
					End If
				Else
					If pm_Status <> 0 Then .StatusC = pm_Status
					If pm_Status <> 0 Then .StatusF = pm_Status
					Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(Wk_Index), CL_SSSMAIN(Wk_Index))
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
				Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(Wk_Index))
				Call AE_CheckSub2_SSSMAIN(Wk_Index, Wk_Index, True)
				If AE_ErrorToInteger(Ck_Error) >= 0 Then
					PP_SSSMAIN.ErrorC = PP_SSSMAIN.ErrorC + 1
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
				End If
			End If
		End With
	End Function
	'�f�[�^���o
	Public Sub AE_Execute(ByVal strTHSCD As String, ByVal strFRNKB As String, ByVal strSTTTOKCD As String, ByVal strENDTOKCD As String)
        '2019/10/15 CHG START
        'Dim objrst As Object
        Dim objrst As DataTable
        '2019/10/15 CHG END
        Dim intret As Short
		Dim strFile As String
		Dim objfso As New Scripting.FileSystemObject
		Dim objstream As Scripting.TextStream
		Dim strSQL As String
		Dim I As Short
		Dim strdmy() As String
		Dim strSQL1 As String
		Dim lngcnt As Integer
		Dim J As Integer
		On Error GoTo err_AE_Execute
		'���s�₢���킹
		If DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_001, 2), 0) = MsgBoxResult.No Then
			DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_004, 2), 0) '���s�𒆒f���܂��B
			Exit Sub
		End If
		'�t�@�C���₢���킹
		If FR_SSSMAIN.selectFile(strFile) = False Then
			DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_004, 2), 0) '���s�𒆒f���܂��B
			Exit Sub
		Else
			If objfso.FileExists(strFile) Then
				If DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_005, 2), 0) = MsgBoxResult.No Then '�t�@�C�������݂��܂��B�㏑�����܂���?
					'�t�H���_������܂���B
					Exit Sub
				End If
			End If
		End If
		FR_SSSMAIN.formenabled(False)
		'DB�ڑ�
		Call CF_Ora_USR1_Open() 'USR1
		'SQL��
		strSQL = vbNullString
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & " (SELECT ZZ.TORMSTKB"
		strSQL = strSQL & "           ,CASE WHEN AA.THSCD = BB.THSCD THEN "
		strSQL = strSQL & "               AA.THSCD "
		strSQL = strSQL & "            ELSE  "
		strSQL = strSQL & "            CASE WHEN AA.THSCD IS NULL OR  BB.THSCD IS NULL THEN"
		strSQL = strSQL & "                   NVL(NVL(AA.THSCD,BB.THSCD),' ') "
		strSQL = strSQL & "            ELSE "
		strSQL = strSQL & "                   ' ' "
		strSQL = strSQL & "               END  "
		strSQL = strSQL & "            END THSCD"
		strSQL = strSQL & "           ,NVL(AA.FRNKB     , '0'                  ) FRNKB   "
		strSQL = strSQL & "           ,NVL(AA.TOKCD     , BB.SIRCD             ) TOKCD   "
		strSQL = strSQL & "           ,NVL(AA.TOKNMA    , BB.SIRNMA            ) TOKNMA  "
		strSQL = strSQL & "           ,NVL(AA.TOKNMB    , BB.SIRNMB            ) TOKNMB  "
		strSQL = strSQL & "           ,NVL(AA.TOKNMC    , BB.SIRNMC            ) TOKNMC  "
		strSQL = strSQL & "           ,NVL(AA.TOKNMD    , BB.SIRNMD            ) TOKNMD  "
		strSQL = strSQL & "           ,NVL(AA.TOKNK     , BB.SIRNK             ) TOKNK   "
		strSQL = strSQL & "           ,NVL(AA.TOKRN     , BB.SIRRN             ) TOKRN   "
		strSQL = strSQL & "           ,NVL(AA.TOKRNNK   , BB.SIRRNNK           ) TOKRNNK "
		strSQL = strSQL & "           ,NVL(AA.TOKZP     , BB.SIRZP             ) TOKZP   "
		strSQL = strSQL & "           ,NVL(AA.TOKADA    , BB.SIRADA            ) TOKADA  "
		strSQL = strSQL & "           ,NVL(AA.TOKADB    , BB.SIRADB            ) TOKADB  "
		strSQL = strSQL & "           ,NVL(AA.TOKADC    , BB.SIRADC            ) TOKADC  "
		strSQL = strSQL & "           ,NVL(AA.TOKTL     , BB.SIRTL             ) TOKTL   "
		strSQL = strSQL & "           ,NVL(AA.TOKFX     , BB.SIRFX             ) TOKFX   "
		strSQL = strSQL & "           ,NVL(AA.TOKBOSNM  , BB.SIRBOSNM          ) TOKBOSNM"
		strSQL = strSQL & "           ,NVL(AA.TOKSEICD  , ' '                  ) TOKSEICD"
		strSQL = strSQL & "           ,NVL(BB.SIRSHACD  , ' '                  ) SIRSHACD"
		strSQL = strSQL & "           ,NVL(AA.TOKTANNM  , ' '                  ) TOKTANNM"
		strSQL = strSQL & "           ,NVL(AA.TOKMLAD   , ' '                  ) TOKMLAD "
		strSQL = strSQL & "           ,NVL(AA.TANCD     , ' '                  ) ATANCD  "
		strSQL = strSQL & "           ,NVL(AA.TANNM     , ' '                  ) ATANNM  "
		strSQL = strSQL & "           ,NVL(BB.SIRCTANM  , ' '                  ) SIRCTANM"
		strSQL = strSQL & "           ,NVL(BB.SIRMLAD   , ' '                  ) SIRMLAD "
		strSQL = strSQL & "           ,NVL(BB.TANCD     , ' '                  ) BTANCD  "
		strSQL = strSQL & "           ,NVL(BB.TANNM     , ' '                  ) BTANNM  "
		strSQL = strSQL & "           ,NVL(AA.TUKKB     , ' '                  ) TUKKB   "
		strSQL = strSQL & "           ,NVL(AA.SIMUKE    , ' '                  ) SIMUKE  "
		strSQL = strSQL & "           ,NVL(AA.MAINHSCD  , ' '                  ) MAINHSCD"
		strSQL = strSQL & "           ,NVL(AA.GYOSHU    , BB.GYOSHU            ) GYOSHU  "
		strSQL = strSQL & "           ,NVL(AA.CHIIKI    , BB.CHIIKI            ) CHIIKI  "
		strSQL = strSQL & "           ,NVL(AA.BINCD     , ' '                  ) BINCD   "
		strSQL = strSQL & "           ,NVL(AA.TGRPCD    , BB.SGRPCD            ) TGRPCD  "
		strSQL = strSQL & "           ,NVL(AA.OLDTOKCD  , BB.OLDSIRCD          ) OLDTOKCD"
		strSQL = strSQL & "           ,NVL(AA.OLTGRPCD  , BB.OLSGRPCD          ) OLTGRPCD"
		strSQL = strSQL & "           ,NVL(AA.KIGYOCD   , ' '                  ) KIGYOCD "
		strSQL = strSQL & "           ,NVL(AA.KGYEDACD  , ' '                  ) KGYEDACD"
		strSQL = strSQL & "           ,DECODE(AA.LMTKN  , NULL, ' ', AA.LMTKN  ) LMTKN   "
		strSQL = strSQL & "           ,NVL(AA.TOKCLANM  , ' '                  ) TOKCLANM"
		strSQL = strSQL & "           ,NVL(AA.KAKZUKE   , ' '                  ) KAKZUKE "
		strSQL = strSQL & "           ,NVL(AA.TOKSMEKB  , ' '                  ) TOKSMEKB"
		strSQL = strSQL & "           ,NVL(AA.TOKSMEDT  , ' '                  ) TOKSMEDT"
		strSQL = strSQL & "           ,NVL(AA.TOKSMEDD  , ' '                  ) TOKSMEDD"
		strSQL = strSQL & "           ,NVL(AA.TOKKESCC  , ' '                  ) TOKKESCC"
		strSQL = strSQL & "           ,NVL(AA.TOKSDWKB  , ' '                  ) TOKSDWKB"
		strSQL = strSQL & "           ,NVL(AA.TOKKDWKB  , ' '                  ) TOKKDWKB"
		strSQL = strSQL & "           ,NVL(AA.TOKSMECC  , ' '                  ) TOKSMECC"
		strSQL = strSQL & "           ,NVL(AA.TOKKESDD  , ' '                  ) TOKKESDD"
		strSQL = strSQL & "           ,NVL(BB.SIRSMEKB  , ' '                  ) SIRSMEKB"
		strSQL = strSQL & "           ,NVL(BB.SIRSMEDT  , ' '                  ) SIRSMEDT"
		strSQL = strSQL & "           ,NVL(BB.SIRSMEDD  , ' '                  ) SIRSMEDD"
		strSQL = strSQL & "           ,NVL(BB.SIRKESCC  , ' '                  ) SIRKESCC"
		strSQL = strSQL & "           ,NVL(BB.SIRSDWKB  , ' '                  ) SIRSDWKB"
		strSQL = strSQL & "           ,NVL(BB.SIRKDEKB  , ' '                  ) SIRKDEKB"
		strSQL = strSQL & "           ,NVL(BB.SIRSMECC  , ' '                  ) SIRSMECC"
		strSQL = strSQL & "           ,NVL(BB.SIRKESDD  , ' '                  ) SIRKESDD"
		strSQL = strSQL & "           ,NVL(AA.BNKCD     , ' '                  ) ABNKCD  "
		strSQL = strSQL & "           ,NVL(AA.YKNKB     , ' '                  ) AYKNKB  "
		strSQL = strSQL & "           ,NVL(AA.KOZNO     , ' '                  ) AKOZNO  "
		strSQL = strSQL & "           ,NVL(AA.HMEIGI    , ' '                  ) AHMEIGI "
		strSQL = strSQL & "           ,NVL(AA.SHAKB     , ' '                  ) SHAKB   "
		strSQL = strSQL & "           ,DECODE(AA.TEGSHKN, NULL, ' ', AA.TEGSHKN) ATEGSHKN"
		strSQL = strSQL & "           ,DECODE(AA.TEGRT  , NULL, ' ', AA.TEGRT  ) TEGRT   "
		strSQL = strSQL & "           ,DECODE(AA.NYUDD  , NULL, ' ', AA.NYUDD  ) NYUDD   "
		strSQL = strSQL & "           ,NVL(AA.FCTCMCD   , ' '                  ) AFCTCMCD"
		strSQL = strSQL & "           ,NVL(AA.TEGSHBS   , ' '                  ) ATEGSHBS"
		strSQL = strSQL & "           ,NVL(AA.HTSUKB    , ' '                  ) AHTSUKB "
		strSQL = strSQL & "           ,NVL(BB.BNKCD     , ' '                  ) BBNKCD  "
		strSQL = strSQL & "           ,NVL(BB.YKNKB     , ' '                  ) BYKNKB  "
		strSQL = strSQL & "           ,NVL(BB.KOZNO     , ' '                  ) BKOZNO  "
		strSQL = strSQL & "           ,NVL(BB.HMEIGI    , ' '                  ) BHMEIGI "
		strSQL = strSQL & "           ,NVL(BB.SHJAKB    , ' '                  ) SHJAKB  "
		strSQL = strSQL & "           ,NVL(BB.SHJBKB    , ' '                  ) SHJBKB  "
		strSQL = strSQL & "           ,NVL(BB.SHJCKB    , ' '                  ) SHJCKB  "
		strSQL = strSQL & "           ,NVL(BB.TEGSHBS   , ' '                  ) BTEGSHBS"
		strSQL = strSQL & "           ,NVL(BB.HTSUKB    , ' '                  ) BHTSUKB "
		strSQL = strSQL & "           ,DECODE(BB.TEGSHKN, NULL, ' ', BB.TEGSHKN) BTEGSHKN"
		strSQL = strSQL & "           ,NVL(BB.FCTCMCD   , ' '                  ) BFCTCMCD"
		strSQL = strSQL & "           ,NVL(BB.SHATKMDT  , ' '                  ) SHATKMDT"
		strSQL = strSQL & "        FROM (SELECT * FROM TOKMTA WHERE DATKB = '1' "
		If strTHSCD = "0" Then
			strSQL = strSQL & "        AND TOKCD = TGRPCD"
		End If
		strSQL = strSQL & "             ) AA ,"
		strSQL = strSQL & "             (SELECT * FROM SIRMTA WHERE DATKB = '1' "
		If strTHSCD = "0" Then
			strSQL = strSQL & "        AND SIRCD = SGRPCD"
		End If
		strSQL = strSQL & "             ) BB ,"
		strSQL = strSQL & "     (SELECT TORCD"
		strSQL = strSQL & "               ,SUM(TORMSTKB) TORMSTKB"
		strSQL = strSQL & "           FROM (SELECT TOKCD TORCD"
		strSQL = strSQL & "                       ,'1'   TORMSTKB"
		strSQL = strSQL & "                   FROM TOKMTA"
		strSQL = strSQL & "                  WHERE DATKB = '1'"
		' === 20110219 === INSERT TOM)Morimoto ��\��БΉ�
		If strTHSCD = "0" Then
			strSQL = strSQL & "        AND TOKCD = TGRPCD"
		End If
		' === 20110219 === INSERT TOM)Morimoto E
		strSQL = strSQL & "                  UNION ALL"
		strSQL = strSQL & "                 SELECT SIRCD TORCD"
		strSQL = strSQL & "                       ,'2'   TORMSTKB"
		strSQL = strSQL & "                   FROM SIRMTA"
		strSQL = strSQL & "                  WHERE DATKB = '1'"
		' === 20110219 === INSERT TOM)Morimoto ��\��БΉ�
		If strTHSCD = "0" Then
			strSQL = strSQL & "        AND SIRCD = SGRPCD"
		End If
		' === 20110219 === INSERT TOM)Morimoto E
		strSQL = strSQL & "                )"
		strSQL = strSQL & "          GROUP BY TORCD"
		strSQL = strSQL & "        ) ZZ "
		strSQL = strSQL & "      WHERE ZZ.TORCD = AA.TOKCD (+)"
		strSQL = strSQL & "        AND ZZ.TORCD = BB.SIRCD (+)"
		'    If strTHSCD = "0" Then
		'        strSQL = strSQL & "        AND AA.TOKCD = AA.TGRPCD"
		'        strSQL = strSQL & "        AND BB.SIRCD = BB.SGRPCD"
		'    End If
		strSQL = strSQL & " )T1,"
		strSQL = strSQL & "       TOKMTA M1 ,"
		strSQL = strSQL & "       SIRMTA M2 ,"
		strSQL = strSQL & "      (SELECT MEICDA"
		strSQL = strSQL & "             ,MEINMA"
		strSQL = strSQL & "         FROM MEIMTA"
		strSQL = strSQL & "        WHERE KEYCD = '014'"
		strSQL = strSQL & "          AND DATKB = '1'"
		strSQL = strSQL & "      ) M3 ,"
		strSQL = strSQL & "       NHSMTA M4 ,"
		strSQL = strSQL & "      (SELECT MEICDA"
		strSQL = strSQL & "             ,MEINMA"
		strSQL = strSQL & "         FROM MEIMTA"
		strSQL = strSQL & "        WHERE KEYCD = '003'"
		strSQL = strSQL & "          AND DATKB = '1'"
		strSQL = strSQL & "      ) M5 ,"
		strSQL = strSQL & "      (SELECT MEICDA"
		strSQL = strSQL & "             ,MEINMA"
		strSQL = strSQL & "         FROM MEIMTA"
		strSQL = strSQL & "        WHERE KEYCD = '004'"
		strSQL = strSQL & "          AND DATKB = '1'"
		strSQL = strSQL & "      ) M6 ,"
		strSQL = strSQL & "      (SELECT MEICDA"
		strSQL = strSQL & "             ,MEINMA"
		strSQL = strSQL & "         FROM MEIMTA"
		strSQL = strSQL & "        WHERE KEYCD = '002'"
		strSQL = strSQL & "          AND DATKB = '1'"
		strSQL = strSQL & "      ) M7 ,"
		strSQL = strSQL & "        BNKMTA M8 ,"
		strSQL = strSQL & "        BNKMTA M9"
		strSQL = strSQL & " WHERE T1.TOKSEICD = M1.TOKCD (+)"
		strSQL = strSQL & "   AND T1.SIRSHACD = M2.SIRCD (+)"
		strSQL = strSQL & "   AND T1.SIMUKE   = M3.MEICDA(+)"
		strSQL = strSQL & "   AND T1.MAINHSCD = M4.NHSCD (+)"
		strSQL = strSQL & "   AND T1.GYOSHU   = M5.MEICDA(+)"
		strSQL = strSQL & "   AND T1.CHIIKI   = M6.MEICDA(+)"
		strSQL = strSQL & "   AND T1.BINCD    = M7.MEICDA(+)"
		strSQL = strSQL & "   AND T1.ABNKCD   = M8.BNKCD (+)"
		strSQL = strSQL & "   AND T1.BBNKCD   = M9.BNKCD (+)"
		Select Case strTHSCD
			Case "1", "2", "3"
				strSQL = strSQL & "   AND T1.THSCD    = '" & strTHSCD & "'"
			Case "0"
		End Select
		If strTHSCD <> "2" And strFRNKB <> "9" Then
			strSQL = strSQL & "   AND T1.FRNKB    = ':FRNKB'"
		End If
		If Len(Trim(strSTTTOKCD)) > 0 Then
			strSQL = strSQL & "   AND T1.TOKCD >= '" & strSTTTOKCD & "'"
		End If
		If Len(Trim(strENDTOKCD)) > 0 Then
			strSQL = strSQL & "   AND T1.TOKCD <= '" & strENDTOKCD & "�'"
		End If
		strSQL = strSQL & " ORDER BY T1.TOKCD"
		strSQL = Replace(strSQL, ":FRNKB", strFRNKB)
		'SQL�����s(�J�E���g���o)
		If get_select("select count(*) " & strSQL, objrst) Then
		Else
            DSP_MsgBox("2", Mid(gc_strMsgTHSFP61_E_010, 2), 9) 'DB�G���[
            '2019/10/15 DEL START
            'DB_ORA_Close()
            '2019/10/15 DEL END
            'UPGRADE_NOTE: �I�u�W�F�N�g objrst ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            objrst = Nothing
			'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			objfso = Nothing
			FR_SSSMAIN.formenabled(True)
			Exit Sub
		End If
        'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'If objrst.Fields(0).Value = 0 Then
        If CInt(objrst.Rows(0)(0)) = 0 Then
            '2019/10/15 CHG END
            DSP_MsgBox("2", Mid(gc_strMsgTHSFP61_E_009, 2), 0) '�f�[�^����
            FR_SSSMAIN.formenabled(True)
            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 DEL START
            'objrst.Close()            
            'DB_ORA_Close()
            '2019/10/15 DEL END
            'UPGRADE_NOTE: �I�u�W�F�N�g objrst ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            objrst = Nothing
            'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            objfso = Nothing
            Exit Sub
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 CHG START
        'lngcnt = objrst.Fields(0).Value
        lngcnt = CInt(objrst.Rows(0)(0))
        '2019/10/15 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/15 DEL START
        'objrst.Close()
        '2019/10/15 DEL END
        strSQL1 = vbNullString
		strSQL1 = strSQL1 & "SELECT "
		strSQL1 = strSQL1 & "       TORMSTKB"
		strSQL1 = strSQL1 & "      ,T1.THSCD                      ""����敪��"""
		strSQL1 = strSQL1 & "      ,T1.FRNKB                      ""�C�O����敪"""
		strSQL1 = strSQL1 & "      ,T1.TOKCD                      ""����溰��"""
		strSQL1 = strSQL1 & "      ,T1.TOKNMA                     ""���̂P"""
		strSQL1 = strSQL1 & "      ,T1.TOKNMB                     ""���̂Q"""
		strSQL1 = strSQL1 & "      ,T1.TOKNMC                     ""����(���p)�P"""
		strSQL1 = strSQL1 & "      ,T1.TOKNMD                     ""����(���p)�Q"""
		strSQL1 = strSQL1 & "      ,T1.TOKNK                      ""�J�i"""
		strSQL1 = strSQL1 & "      ,T1.TOKRN                      ""����"""
		strSQL1 = strSQL1 & "      ,T1.TOKRNNK                    ""���̃J�i"""
		strSQL1 = strSQL1 & "      ,T1.TOKZP                      ""*�X�֔ԍ�"""
		strSQL1 = strSQL1 & "      ,T1.TOKADA                     ""*�Z���P"""
		strSQL1 = strSQL1 & "      ,T1.TOKADB                     ""*�Z���Q"""
		strSQL1 = strSQL1 & "      ,T1.TOKADC                     ""*�Z���R"""
		strSQL1 = strSQL1 & "      ,T1.TOKTL                      ""*TEL(�d�b�ԍ��j"""
		strSQL1 = strSQL1 & "      ,T1.TOKFX                      ""*FAX(FAX�ԍ�)"""
		strSQL1 = strSQL1 & "      ,T1.TOKBOSNM                   ""*��\�Җ�"""
		strSQL1 = strSQL1 & "      ,T1.TOKSEICD                   ""������i�R�[�h�j"""
		strSQL1 = strSQL1 & "      ,NVL(M1.TOKNMA, ' ')           ""������i���́j"""
		strSQL1 = strSQL1 & "      ,T1.SIRSHACD                   ""�x����i�R�[�h�j"""
		strSQL1 = strSQL1 & "      ,NVL(M2.SIRNMA, ' ')           ""�x����i���́j"""
		strSQL1 = strSQL1 & "      ,T1.TOKTANNM                   ""*���Ӑ��S����"""
		strSQL1 = strSQL1 & "      ,T1.TOKMLAD                    ""*���Ӑ�Ұٱ��ڽ"""
		strSQL1 = strSQL1 & "      ,T1.ATANCD                     ""*�c�ƒS����(���Ӑ�)(�R�[�h)"""
		strSQL1 = strSQL1 & "      ,T1.ATANNM                     ""�c�ƒS����(���Ӑ�)(����)"""
		strSQL1 = strSQL1 & "      ,T1.SIRCTANM                   ""*�d�����S����"""
		strSQL1 = strSQL1 & "      ,T1.SIRMLAD                    ""*�d����Ұٱ��ڽ"""
		strSQL1 = strSQL1 & "      ,T1.BTANCD                     ""*�S����(�d����)(�R�[�h)"""
		strSQL1 = strSQL1 & "      ,T1.BTANNM                     ""�S����(�d����)(����)"""
		strSQL1 = strSQL1 & "      ,T1.TUKKB                      ""�ʉ݋敪(�R�[�h)"""
		strSQL1 = strSQL1 & "      ,NVL(M3.MEINMA, ' ')           ""�d���n�i���́j"""
		strSQL1 = strSQL1 & "      ,T1.MAINHSCD                   ""��\�[����i�R�[�h�j"""
		strSQL1 = strSQL1 & "      ,NVL(M4.NHSNMA, ' ')           ""��\�[����i���́j"""
		strSQL1 = strSQL1 & "      ,T1.GYOSHU                     ""*�Ǝ�i�R�[�h�j"""
		strSQL1 = strSQL1 & "      ,NVL(M5.MEINMA, ' ')           ""�Ǝ�i���́j"""
		strSQL1 = strSQL1 & "      ,T1.CHIIKI                     ""*�n��i�R�[�h�j"""
		strSQL1 = strSQL1 & "      ,NVL(M6.MEINMA, ' ')           ""�n��i���́j"""
		strSQL1 = strSQL1 & "      ,T1.BINCD                      ""*�֋敪(�R�[�h)"""
		strSQL1 = strSQL1 & "      ,NVL(M7.MEINMA, ' ')           ""�֋敪�i���́j"""
		strSQL1 = strSQL1 & "      ,T1.TGRPCD                     ""��\��к���"""
		strSQL1 = strSQL1 & "      ,T1.OLDTOKCD                   ""�������R�[�h"""
		strSQL1 = strSQL1 & "      ,T1.OLTGRPCD                   ""����\��к���"""
		strSQL1 = strSQL1 & "      ,T1.KIGYOCD                    ""�����ƃR�[�h(����)"""
		strSQL1 = strSQL1 & "      ,T1.KGYEDACD                   ""�����ƃR�[�h(�}��)"""
		strSQL1 = strSQL1 & "      ,T1.LMTKN                      ""�^�M���x�z"""
		strSQL1 = strSQL1 & "      ,T1.TOKCLANM                   ""���x�z�ݒ��"""
		strSQL1 = strSQL1 & "      ,T1.KAKZUKE                    ""�i�t"""
		strSQL1 = strSQL1 & "      ,T1.TOKSMEKB                   ""���Ӑ���敪"""
		strSQL1 = strSQL1 & "      ,T1.TOKSMEDT                   ""���Ӑ搿�������t"""
		strSQL1 = strSQL1 & "      ,T1.TOKSMEDD                   ""���Ӑ���ߏ������t"""
		strSQL1 = strSQL1 & "      ,T1.TOKKESCC                   ""���Ӑ�������"""
		strSQL1 = strSQL1 & "      ,T1.TOKSDWKB                   ""���Ӑ���ߗj��"""
		strSQL1 = strSQL1 & "      ,T1.TOKKDWKB                   ""���Ӑ����j��"""
		strSQL1 = strSQL1 & "      ,T1.TOKSMECC                   ""���Ӑ���߻���"""
		strSQL1 = strSQL1 & "      ,T1.TOKKESDD                   ""���Ӑ�����"""
		strSQL1 = strSQL1 & "      ,T1.SIRSMEKB                   ""�d������敪"""
		strSQL1 = strSQL1 & "      ,T1.SIRSMEDT                   ""�d����x�������t"""
		strSQL1 = strSQL1 & "      ,T1.SIRSMEDD                   ""�d������ߏ������t"""
		strSQL1 = strSQL1 & "      ,T1.SIRKESCC                   ""�d����x������"""
		strSQL1 = strSQL1 & "      ,T1.SIRSDWKB                   ""�d������ߗj��"""
		strSQL1 = strSQL1 & "      ,T1.SIRKDEKB                   ""�d����x���j��"""
		strSQL1 = strSQL1 & "      ,T1.SIRSMECC                   ""�d������߻���"""
		strSQL1 = strSQL1 & "      ,T1.SIRKESDD                   ""�d����x����"""
		strSQL1 = strSQL1 & "      ,T1.ABNKCD                     ""���Ӑ��s����"""
		strSQL1 = strSQL1 & "      ,NVL(M8.BNKNM , ' ')           ""���Ӑ��s(����)"""
		strSQL1 = strSQL1 & "      ,NVL(M8.STNNM , ' ')           ""���Ӑ��s(�x�X��)"""
		strSQL1 = strSQL1 & "      ,T1.AYKNKB                     ""���Ӑ�a�����"""
		strSQL1 = strSQL1 & "      ,T1.AKOZNO                     ""���Ӑ�����ԍ�"""
		strSQL1 = strSQL1 & "      ,T1.AHMEIGI                    ""���Ӑ�U�����`"""
		strSQL1 = strSQL1 & "      ,T1.SHAKB                      ""���Ӑ�x���敪"""
		strSQL1 = strSQL1 & "      ,T1.ATEGSHKN                   ""���Ӑ��`�x�����z"""
		strSQL1 = strSQL1 & "      ,T1.TEGRT                      ""���Ӑ��`�䗦"""
		strSQL1 = strSQL1 & "      ,T1.NYUDD                      ""���Ӑ�T�C�g"""
		strSQL1 = strSQL1 & "      ,T1.AFCTCMCD                   ""���Ӑ�̧���ݸމ�к���"""
		strSQL1 = strSQL1 & "      ,T1.ATEGSHBS                   ""���Ӑ��`�x���ꏊ"""
		strSQL1 = strSQL1 & "      ,T1.AHTSUKB                    ""���Ӑ�U���萔�����S�敪"""
		strSQL1 = strSQL1 & "      ,T1.BBNKCD                     ""�d�����s����"""
		strSQL1 = strSQL1 & "      ,NVL(M9.BNKNM , ' ')           ""�d�����s(����)"""
		strSQL1 = strSQL1 & "      ,NVL(M9.STNNM , ' ')           ""�d�����s(�x�X��)"""
		strSQL1 = strSQL1 & "      ,T1.BYKNKB                     ""�d����a�����"""
		strSQL1 = strSQL1 & "      ,T1.BKOZNO                     ""�d��������ԍ�"""
		strSQL1 = strSQL1 & "      ,T1.BHMEIGI                    ""�d����U�����`"""
		strSQL1 = strSQL1 & "      ,T1.SHJAKB                     ""�d����x�������P"""
		strSQL1 = strSQL1 & "      ,T1.SHJBKB                     ""�d����x�������Q"""
		strSQL1 = strSQL1 & "      ,T1.SHJCKB                     ""�d����x�������R"""
		strSQL1 = strSQL1 & "      ,T1.BTEGSHBS                   ""�d�����`�x���ꏊ"""
		strSQL1 = strSQL1 & "      ,T1.BHTSUKB                    ""�d����U���萔�����S�敪"""
		strSQL1 = strSQL1 & "      ,T1.BTEGSHKN                   ""�d�����`�x�����z"""
		strSQL1 = strSQL1 & "      ,T1.BFCTCMCD                   ""�d����t�@�N�^�����O��ЃR�[�h"""
		strSQL1 = strSQL1 & "      ,T1.SHATKMDT                   ""�d����x�����@�挈��"""
		If get_select(strSQL1 & strSQL, objrst) Then
			objstream = objfso.CreateTextFile(strFile)
            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'ReDim strdmy(objrst.Fields.count - 2)
            ReDim strdmy(objrst.Columns.Count - 2)
            '2019/10/15 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            'For I = 1 To objrst.Fields.count - 1
            For I = 1 To objrst.Columns.Count - 1
                '2019/10/15 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/15 CHG START
                'strdmy(I - 1) = objrst.Fields(I).NAME
                strdmy(I - 1) = objrst.Columns(I).ColumnName
                '2019/10/15 CHG END
            Next
            objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))
			'�f�[�^���o
			FR_SSSMAIN.show_GAGE(True)
			System.Windows.Forms.Application.DoEvents()
            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 CHG START
            '        While Not (objrst.EOF Or PP_SSSMAIN.ButtonClick)
            '            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '            If Str(objrst.Fields(0).Value) = Str(objrst.Fields(1).Value) Then
            '	'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	For I = 1 To objrst.Fields.count - 1
            '		'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            '		strdmy(I - 1) = IIf(IsDbNull(objrst.Fields(I).Value), " ", Trim(objrst.Fields(I).Value))
            '		strdmy(I - 1) = IIf(Len(strdmy(I - 1)) = 0, " ", strdmy(I - 1))
            '	Next 
            '	FR_SSSMAIN.count_GAGE(J, lngcnt)
            'Else
            '	'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	For I = 1 To objrst.Fields.count - 1
            '		strdmy(I - 1) = " "
            '	Next 
            '	strdmy(0) = "�G���["
            '	'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            '	strdmy(2) = IIf(IsDbNull(objrst.Fields(3).Value), " ", Trim(objrst.Fields(3).Value))
            '	'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            '	strdmy(3) = IIf(IsDbNull(objrst.Fields(4).Value), " ", Trim(objrst.Fields(4).Value))
            '	strdmy(4) = "�V�X�e���Ǘ��҂ɘA�����Ă�������"
            'End If
            'objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))
            'System.Windows.Forms.Application.DoEvents()
            ''UPGRADE_WARNING: �I�u�W�F�N�g objrst.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'objrst.MoveNext()
            'J = J + 1
            '        End While

            For cnt As Integer = 0 To objrst.Rows.Count - 1
                If Str(objrst.Rows(cnt)(0)) = Str(objrst.Rows(cnt)(1)) Then
                    For I = 1 To objrst.Columns.Count - 1
                        strdmy(I - 1) = IIf(IsDBNull(objrst.Rows(cnt)(I)), " ", Trim(objrst.Rows(cnt)(I).ToString()))
                        strdmy(I - 1) = IIf(Len(strdmy(I - 1)) = 0, " ", strdmy(I - 1))
                    Next
                    FR_SSSMAIN.count_GAGE(J, lngcnt)
                Else
                    For I = 1 To objrst.Columns.Count - 1
                        strdmy(I - 1) = " "
                    Next
                    strdmy(0) = "�G���["
                    strdmy(2) = IIf(IsDBNull(objrst.Rows(cnt)(3)), " ", Trim(objrst.Rows(cnt)(3).ToString()))
                    strdmy(3) = IIf(IsDBNull(objrst.Rows(cnt)(4)), " ", Trim(objrst.Rows(cnt)(4).ToString()))
                    strdmy(4) = "�V�X�e���Ǘ��҂ɘA�����Ă�������"
                End If
                objstream.WriteLine(Join(strdmy, gv_strTAB_CHAR))
                System.Windows.Forms.Application.DoEvents()
                J = J + 1
            Next

            '2019/10/15 CHG END

            FR_SSSMAIN.show_GAGE(False)
            'UPGRADE_WARNING: �I�u�W�F�N�g objrst.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/15 DEL START
            'objrst.Close()
            '2019/10/15 DEL END
            objstream.Close()
			If PP_SSSMAIN.ButtonClick Then
				PP_SSSMAIN.ButtonClick = False
				DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_004, 2), 0) '���s�𒆒f���܂��B
				objfso.DeleteFile(strFile)
			Else
				DSP_MsgBox("1", Mid(gc_strMsgTHSFP61_I_003, 2), 0) '�������I�����܂����B
			End If
		Else
			DSP_MsgBox("2", Mid(gc_strMsgTHSFP61_E_010, 2), 9) 'DB�G���[
		End If
        '2019/10/15 DEL START
        'DB_ORA_Close()
        '2019/10/15 DEL END
        'UPGRADE_NOTE: �I�u�W�F�N�g objrst ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        objrst = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objstream ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objstream = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		FR_SSSMAIN.formenabled(True)
		Exit Sub
err_AE_Execute: 
		DSP_MsgBox("2", Mid(gc_strMsgTHSFP61_E_011, 2), 0) '�t�@�C���G���[
        '2019/10/15 DEL START
        'DB_ORA_Close()
        '2019/10/15 DEL END
        'UPGRADE_NOTE: �I�u�W�F�N�g objstream ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        objstream = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objrst ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objrst = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		FR_SSSMAIN.formenabled(True)
	End Sub
	' === 20110216 === INSERT E
End Module