Option Strict Off
Option Explicit On
Module SSSMAIN0001
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    '
    '�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
    Public PP_SSSMAIN As clsPP
    Public CP_SSSMAIN(16 + 0 + 0 + 1) As clsCP
    Public CL_SSSMAIN(16) As Short
    Public CQ_SSSMAIN(16) As String

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

    Sub AE_Check_SSSMAIN_BMNCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(6)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(6), CC_NewVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(6).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019.04.11 chg start
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn _
                And ((AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal)) Or
                IIf(IsDBNull(CC_NewVal), " ", CC_NewVal) = IIf(IsDBNull(.CuVal), " ", .CuVal)) Then
                '2019.04.11 chg end
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del SATAR
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = BMNCD_CheckC(CC_NewVal, PP_SSSMAIN.De2)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019.04.19 chg start
                'Ck_Error = BMNCD_CheckC(CC_NewVal, PP_SSSMAIN.De2)
                'delte start 20190809 kuwahara
                'If PP_SSSMAIN.De2 > 0 Then
                'delete end 20190809 kuwahara
                Ck_Error = BMNCD_CheckC(CC_NewVal, PP_SSSMAIN.De2)
                'delete start 20190809�@
                'End If
                'delete end 20190809 kuwahara
                '2019.04.19 chg end
            End If
                .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(6), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 6, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(6))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_BMNNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(7)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(7), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Ck_Error = 0
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(7), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 7, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(7))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_DENDT(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(8)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(8), CC_NewVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(8).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04..11 del START
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = DENDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = DENDT_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(8), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 8, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(8))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_HAKKOU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(2)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(2), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 DEL STAART
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 DEL END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
                'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = HAKKOU_Check(CC_NewVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g HAKKOU_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = HAKKOU_Check(CC_NewVal)
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

    Sub AE_Check_SSSMAIN_JDNNO(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(9)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(9), CC_NewVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(9).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019.04.11 chg start
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn _
                And ((AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal)) Or
                IIf(IsDBNull(CC_NewVal), " ", CC_NewVal) = IIf(IsDBNull(.CuVal), " ", .CuVal)) Then
                '2019.04.11 chg end
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(9), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, 9, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(9), AE_Controls(PP_SSSMAIN.CtB + 9))
                    End If
                End If
                Exit Sub
            End If
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = JDNNO_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = JDNNO_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(9), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 9, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(9))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_JDNTRKB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(12)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(12), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            If (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
                'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_CHeck() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = JDNTRKB_CHeck(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_CHeck() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = JDNTRKB_CHeck(AE_NullCnv2_SSSMAIN(CC_NewVal))
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(12), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 12, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(12))
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
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12))
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
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(12))
                Call AE_CheckSub2_SSSMAIN(12, 12, True)
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

    Sub AE_Check_SSSMAIN_JDNTRNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(13)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(13), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Ck_Error = 0
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(13), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 13, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(13))
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
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13))
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
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(13))
                Call AE_CheckSub2_SSSMAIN(13, 13, True)
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

    Sub AE_Check_SSSMAIN_KINKYU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(3)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(3), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
                'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = KINKYU_Check(CC_NewVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g KINKYU_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = KINKYU_Check(CC_NewVal)
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(3), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 3, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(3))
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
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(0), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
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
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(1), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
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

    Sub AE_Check_SSSMAIN_PRTKB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(14)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(14), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
                'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = PRTKB_Check(CC_NewVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g PRTKB_Check() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = PRTKB_Check(CC_NewVal)
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(14), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 14, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(14))
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
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14))
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
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(14))
                Call AE_CheckSub2_SSSMAIN(14, 14, True)
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

    Sub AE_Check_SSSMAIN_TANCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(4)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(4), CC_NewVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(4).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019.04.11 chg start
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn _
                And ((AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal)) Or
                IIf(IsDBNull(CC_NewVal), " ", CC_NewVal) = IIf(IsDBNull(.CuVal), " ", .CuVal)) Then
                '2019.04.11 chg end
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = TANCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = TANCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(4), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 4, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(4))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_TANNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(5)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(5), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Ck_Error = 0
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(5), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 5, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(5))
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
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_ErrorMsg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = SSSMAIN_ErrorMsg(Ck_Error)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    wk_Bool = AE_MsgLibrary(PP_SSSMAIN, "PreCheck" & CStr(-Ck_Error))
                End If
            End If
        End With
    End Sub

    Sub AE_Check_SSSMAIN_TOKCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(10)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(10), CC_NewVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(10).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019.04.11 chg start
            'If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
            If (.CheckRtnCode = 0) And pm_HandIn _
                And ((AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal)) Or
                IIf(IsDBNull(CC_NewVal), " ", CC_NewVal) = IIf(IsDBNull(.CuVal), " ", .CuVal)) Then
                '2019.04.11 chg end
                If Not PP_SSSMAIN.RecalcMode Then
                    wk_SaveMask = PP_SSSMAIN.MaskMode
                    PP_SSSMAIN.MaskMode = True
                    .TpStr = AE_Format(CP_SSSMAIN(10), .CuVal, 0, True)
                    Call AE_CtSet(PP_SSSMAIN, 10, .TpStr, .TypeA, False)
                    PP_SSSMAIN.MaskMode = wk_SaveMask
                    If .StatusC = Cn_Status1 Then .StatusC = .StatusF
                    If .StatusC >= Cn_Status6 Then
                        If pm_MoveCursor Then
                            If AE_CursorSkip_SSSMAIN() = False And PP_SSSMAIN.CursorDirection = Cn_Direction1 Then Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
                        End If
                    Else
                        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10))
                        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(10), AE_Controls(PP_SSSMAIN.CtB + 10))
                    End If
                End If
                Exit Sub
            End If
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del STAAT
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = TOKCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD_CheckC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Ck_Error = TOKCD_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            End If
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(10), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 10, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(10))
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
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10))
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
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(10))
                Call AE_CheckSub2_SSSMAIN(10, 10, True)
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

    Sub AE_Check_SSSMAIN_TOKRN(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(11)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(11), CC_NewVal)
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
            If IsDBNull(CC_NewVal) Then
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
                '2019.04.11 del START
                'AE_StatusBar(PP_SSSMAIN.ScX) = ""
                ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusCodeBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
                '2019.04.11 del END
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Ck_Error = 0
            .CheckRtnCode = AE_ErrorToInteger(Ck_Error)
            wk_SaveMask = PP_SSSMAIN.MaskMode
            PP_SSSMAIN.MaskMode = True
            'UPGRADE_WARNING: �I�u�W�F�N�g CC_NewVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CuVal = CC_NewVal
            .TpStr = AE_Format(CP_SSSMAIN(11), .CuVal, 0, True)
            Call AE_CtSet(PP_SSSMAIN, 11, .TpStr, .TypeA, False)
            PP_SSSMAIN.MaskMode = wk_SaveMask
            If AE_ErrorToInteger(Ck_Error) = 0 Or (pm_Status >= Cn_Status7 And PP_SSSMAIN.CheckErrNglct) Then
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(CC_NewVal) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv2_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv2_SSSMAIN(CC_NewVal) Then
                    wk_Equal = True
                Else
                    wk_Equal = False
                    Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(11))
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
                    Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11))
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
                Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(11))
                Call AE_CheckSub2_SSSMAIN(11, 11, True)
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
                '2019.04.08 CHG start
                'If PP_SSSMAIN.SelValid And CP_SSSMAIN(pm_Px).FixedFormat <> 1 Then
                '    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = 0
                '    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx))
                'Else
                '    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    wk_SS = AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart
                '    Do While wk_SS > 0
                '        wk_SS = wk_SS - 1
                '        If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                '            'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = wk_SS
                '            'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                '            Exit Sub
                '        End If
                '    Loop
                '    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls().SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                'End If
                If PP_SSSMAIN.SelValid And CP_SSSMAIN(pm_Px).FixedFormat <> 1 Then
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(0, Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx)))
                Else
                    wk_SS = DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart
                    Do While wk_SS > 0
                        wk_SS = wk_SS - 1
                        If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            Exit Sub
                        End If
                    Loop
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                End If
                '2019.04.08 CHG end
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
        Do While wk_Px < 16
            CP_SSSMAIN(wk_Px).Modified = PP_SSSMAIN.Mode
            wk_Px = wk_Px + 1
        Loop
    End Sub

    Sub AE_ClearItm_SSSMAIN(ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_ClearedVal As Object
        Dim wk_De As Short
        If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Sub
        If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= 15 Then Exit Sub
        PP_SSSMAIN.MaskMode = True
        If PP_SSSMAIN.Tx < 15 Then
            Call AE_InitValHd_SSSMAIN(PP_SSSMAIN.Tx, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF)
        ElseIf PP_SSSMAIN.Tx < 15 Then
        ElseIf PP_SSSMAIN.Tx < 15 Then
        ElseIf PP_SSSMAIN.Tx < 15 Then
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
        '2019.04.08 CHG START
        'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
        ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'AE_StatusBar(PP_SSSMAIN.ScX) = ""
        '2019.04.08 CHG END
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
                    If (Not fl_NullZero And IsDBNull(CP_SSSMAIN(wk_Px).CuVal)) Or (fl_NullZero And AE_IsNull_SSSMAIN(CP_SSSMAIN(wk_Px).CuVal)) Then
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
        If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 15 Then
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
        Do While wk_Tx < 15
            wk_Tx = wk_Tx + 1
            If wk_Tx < 15 Then
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
        If wk_Tx < 0 Or wk_Tx >= 15 Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
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
        Do While wk_Tx < 15
            wk_Tx = wk_Tx + 1
            If wk_Tx < 15 Then
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
        Do While wk_Tx < 14
            wk_Tx = wk_Tx + 1
            If wk_Tx < 15 Then
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
                If Not AE_CursorPrev_SSSMAIN(15) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
            Case Cn_Dest4
                PP_SSSMAIN.UpDownFlag = True
                If Not AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
                End If
                PP_SSSMAIN.UpDownFlag = False
            Case Cn_Dest5
                PP_SSSMAIN.UpDownFlag = True
                If Not AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorPrev_SSSMAIN(15) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
                End If
                PP_SSSMAIN.UpDownFlag = False
            Case Cn_Dest6
                If Not AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorPrev_SSSMAIN(15) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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
                        If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(15)
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
        Do While wk_Tx < 15
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
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Current() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_Var = SSSMAIN_Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If wk_Var = -1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '2019.04.09 del end
            If PP_SSSMAIN.hIMC <> 0 Then
                Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
            End If
#If ActiveXcompile = 0 Then
            End
#End If
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ElseIf wk_Var = 1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '2019.04.09 del end
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
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Append() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                '2019.04.19 del start
                '.ExMessage = (AE_StatusBar(.ScX)).ToString()
                '2019.04.19 del end
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
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Update() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
        Do While wk_Px < 16
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
            CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
            wk_Px = wk_Px + 1
        Loop
        PP_SSSMAIN.MaskMode = True
        Call AE_InitValHd_SSSMAIN(-2, False, Cn_Status0)
        PP_SSSMAIN.MaskMode = False
        Call AE_ClearInitValStatus_SSSMAIN()
        '2019.03.29 DEL START
        'Call AE_StatusClear(PP_SSSMAIN, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClErrorStatus))
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Init() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'wk_Var = SSSMAIN_Init()
        '2019.03.29 DEL end
        wk_Px = 0
        Do While wk_Px < 16
            CP_SSSMAIN(wk_Px).IniStr = CP_SSSMAIN(wk_Px).TpStr
            wk_Px = wk_Px + 1
        Loop
    End Sub

    Sub AE_InitValBd_SSSMAIN() 'Generated.
        Dim wk_Px As Short
        Dim wk_InOutMode As Integer
        Dim wk_De As Short
        wk_Px = 16
        Do While wk_Px < 16
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
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
        wk_Px = 16
        Do While wk_Px < 16
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
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
            Call AE_TabStop_SSSMAIN(0, 14, pm_SetInOut)
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
        If pm_Px = -2 Or pm_Px = 2 Then 'HAKKOU
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(2), HAKKOU_InitVal(), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 3 Then 'KINKYU
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(3), KINKYU_InitVal(), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 4 Then 'TANCD
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(4), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 5 Then 'TANNM
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(5), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 6 Then 'BMNCD
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(6), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 7 Then 'BMNNM
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(7), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 8 Then 'DENDT
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(8), DENDT_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal)), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 9 Then 'JDNNO
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(9), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 10 Then 'TOKCD
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(10), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 11 Then 'TOKRN
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(11), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 12 Then 'JDNTRKB
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(12), JDNTRKB_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(12).CuVal)), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 13 Then 'JDNTRNM
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(13), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 14 Then 'PRTKB
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(14), PRTKB_InitVal(), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 15 Then 'FDNNO
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(15), System.DBNull.Value, pm_Status)
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
        Do While wk_Qx < 16 And UCase(Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx)) <> wk_UCaseObjA
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
        If wk_Qx < 16 Then
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
        Do While wk_Qx < 16 And Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> wk_UCaseObjA
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
        If wk_Qx < 16 Then
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
        If IsDBNull(Valu) Then
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
        'Static wk_Tx As Short
        'Static wk_Px As Short
        'Static wk_Txt As String
        'Static wk_SS As Integer
        'Static wk_SS2 As Integer
        'Static wk_Moji As String
        'Static wk_Ln As Short
        'Static wk_Ln2 As Integer
        'Static wk_DeC As Short
        'Static wk_FractionC As Short
        'change start 20190809 kuwahara
        Dim wk_Tx As Short
        Dim wk_Px As Short
        Dim wk_Txt As String
        Dim wk_SS As Integer
        Dim wk_SS2 As Integer
        Dim wk_Moji As String
        Dim wk_Ln As Short
        Dim wk_Ln2 As Integer
        Dim wk_DeC As Short
        Dim wk_FractionC As Short
        'change end 20190809 kuwahara
        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        If TypeOf Ct Is System.Windows.Forms.TextBox Then
            'UPGRADE_WARNING: �I�u�W�F�N�g Ct.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019.04.08 CHG START
            'Ct.Locked = False
            Ct.Enabled = True
            '2019.04.08 CHG END
        End If
        'change start 20190809 kuwahara
        'wk_Txt = Ct.ToString()
        wk_Txt = Ct.Text
        'change end 20190809 kuwahara
        wk_Tx = PP_SSSMAIN.Tx
        wk_Px = PP_SSSMAIN.Px
        PP_SSSMAIN.EditText = False
        PP_SSSMAIN.UnderFurigana = False
        PP_SSSMAIN.UnderFurigana22 = False
        Select Case CP_SSSMAIN(wk_Px).TypeA
            Case Cn_InputOnly, Cn_ListBox, Cn_OutputOnly
            Case Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019.04.08 CHG start
                'wk_SS = Ct.SelStart
                wk_SS = DirectCast(Ct, TextBox).SelectionStart
                '2019.04.08 CHG end
        End Select
        AE_KeyDown_SSSMAIN = False
        PP_SSSMAIN.CursorDest = Cn_Dest0
        '2019.04.08 chg start
        '		If Not PP_SSSMAIN.Operable Then
        '			pm_KeyCode = 0
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 0 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
        '			pm_KeyCode = 0
        '			PP_SSSMAIN.CursorDest = Cn_Dest4
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 2 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
        '			PP_SSSMAIN.CursorDest = Cn_Dest2
        '			pm_KeyCode = 0
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 0 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
        '			pm_KeyCode = 0
        '			PP_SSSMAIN.CursorDest = Cn_Dest5
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 2 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
        '			PP_SSSMAIN.CursorDest = Cn_Dest3
        '			pm_KeyCode = 0
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 0 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
        '			pm_KeyCode = 0
        '			Select Case CP_SSSMAIN(wk_Px).TypeA
        '				Case Cn_InputOnly, Cn_ListBox
        '					PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        '			End Select
        '			If PP_SSSMAIN.Mode = Cn_Mode3 Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
        '				If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '���l��
        '					wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
        '					Do While wk_SS > 0
        '						wk_Moji = Mid(wk_Txt, wk_SS, 1)
        '						If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							GoTo AE_KeyDownRightEnd1_SSSMAIN
        '						End If
        '						wk_SS = wk_SS - 1
        '					Loop 
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelStart = 0
        '				Else
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelStart = Len(wk_Txt) - PP_SSSMAIN.Override
        '				End If
        'AE_KeyDownRightEnd1_SSSMAIN: 
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				Ct.SelLength = PP_SSSMAIN.Override
        '			Else
        '				wk_Ln = Len(wk_Txt)
        '				If wk_SS = wk_Ln Then
        '					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        '				ElseIf wk_SS <= wk_Ln - 2 Or wk_Ln <= 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0 Then 
        '					Do While wk_SS <= wk_Ln - 2
        '						wk_SS = wk_SS + 1
        '						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
        '						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelLength = PP_SSSMAIN.Override
        '							GoTo AE_KeyDownRightEnd2_SSSMAIN
        '						ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then 
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelLength = PP_SSSMAIN.Override
        '							GoTo AE_KeyDownRightEnd2_SSSMAIN
        '						ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelLength = PP_SSSMAIN.Override
        '							GoTo AE_KeyDownRightEnd2_SSSMAIN
        '						ElseIf Mid(wk_Txt, wk_SS, 1) = Space(1) And Not AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then 
        '							Exit Do
        '						End If
        '					Loop 
        '					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        'AE_KeyDownRightEnd2_SSSMAIN: 
        '				Else
        '					If (CP_SSSMAIN(wk_Px).Alignment <> 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0) Or PP_SSSMAIN.Mode = Cn_Mode3 Then '���l��
        '						If PP_SSSMAIN.Override And PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        '						If AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS + 1, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS + 1
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelLength = PP_SSSMAIN.Override
        '							GoTo AE_KeyDownRightEnd2_SSSMAIN
        '						End If
        '					Else
        '						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						Ct.SelStart = wk_Ln
        '						'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						Ct.SelLength = PP_SSSMAIN.Override
        '					End If
        '				End If
        '			End If
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 2 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
        '			pm_KeyCode = 0
        '			PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 0 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
        '			pm_KeyCode = 0
        '			Select Case CP_SSSMAIN(wk_Px).TypeA
        '				Case Cn_InputOnly, Cn_ListBox
        '					PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
        '			End Select
        '			If PP_SSSMAIN.Mode = Cn_Mode3 Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
        '				If CP_SSSMAIN(wk_Px).Alignment = 1 Then '�E�l��
        '					wk_SS = 0
        '					wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
        '					Do While wk_SS < wk_Ln
        '						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
        '						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							GoTo AE_KeyDownLeftEnd1_SSSMAIN
        '						End If
        '						wk_SS = wk_SS + 1
        '					Loop 
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelStart = wk_Ln
        '				Else
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelStart = 0
        '				End If
        'AE_KeyDownLeftEnd1_SSSMAIN: 
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				Ct.SelLength = PP_SSSMAIN.Override
        '			Else
        '				If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
        '					PP_SSSMAIN.Override = 1
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelStart = wk_SS - 1
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Ct.SelLength = PP_SSSMAIN.Override
        '				ElseIf wk_SS = 0 Then 
        '					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
        '				Else
        '					Do While wk_SS > 0
        '						wk_Moji = Mid(wk_Txt, wk_SS, 1)
        '						wk_SS = wk_SS - 1
        '						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelStart = wk_SS
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Ct.SelLength = PP_SSSMAIN.Override
        '							GoTo AE_KeyDownLeftEnd2_SSSMAIN
        '						End If
        '					Loop 
        '					If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
        '				End If
        'AE_KeyDownLeftEnd2_SSSMAIN: 
        '			End If
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 2 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
        '			pm_KeyCode = 0
        '			PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = 126 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
        '			pm_KeyCode = 0
        '			PP_SSSMAIN.CursorDest = Cn_Dest7
        '			GoTo CheckOrSkip
        '		ElseIf (pm_KeyCode = System.Windows.Forms.Keys.Execute Or pm_KeyCode = System.Windows.Forms.Keys.Return) And pm_Shift = 0 Or pm_KeyCode = 127 Then 
        'KeyExecute: 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
        '			pm_KeyCode = 0
        '			AE_KeyDown_SSSMAIN = True
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.End And (pm_Shift And 1) <> 1 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
        '			PP_SSSMAIN.CursorDest = Cn_Dest3
        '			pm_KeyCode = 0
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Home And (pm_Shift And 1) <> 1 Then 
        '			PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
        '			PP_SSSMAIN.CursorDest = Cn_Dest2
        '			pm_KeyCode = 0
        '			GoTo CheckOrSkip
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.PageDown And pm_Shift = 0 Then 
        '			pm_KeyCode = 0
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.PageUp And pm_Shift = 0 Then 
        '			pm_KeyCode = 0
        '		ElseIf pm_KeyCode = 229 Then 
        '			PP_SSSMAIN.EditText = True
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Delete And pm_Shift <= 2 Then 
        '			pm_KeyCode = 0
        '			If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Function
        '			wk_Ln = Len(Ct)
        '			If CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("-") Then
        '				Exit Function
        '			ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then 
        '				Exit Function
        '			ElseIf Not AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Or Not AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then 
        '				Exit Function
        '			ElseIf CP_SSSMAIN(wk_Px).FixedFormat = 1 Then 
        '				If AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
        '					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					wk_Txt = Left(wk_Txt, wk_SS) & Space(LenWid(Mid(wk_Txt, wk_SS + 1, 1))) & Mid(wk_Txt, wk_SS + 2)
        '					wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
        '					wk_SS = wk_SS + 1
        '					Do While wk_SS < wk_Ln
        '						wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
        '						If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then Exit Do
        '						wk_SS = wk_SS + 1
        '					Loop 
        '				Else
        '					Exit Function
        '				End If
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			ElseIf Ct.SelLength = wk_Ln And wk_Ln > 1 Then 
        '				wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
        '				If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
        '			ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then 
        '				wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
        '			ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then 
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + Ct.SelLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, Ct.SelLength))) 'V6.52
        '				ElseIf Len(wk_Txt) >= wk_SS + 1 Then 
        '					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
        '				End If
        '				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
        '					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        '					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
        '						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
        '						wk_Txt = ""
        '					End If
        '				End If
        '			Else
        '				wk_SS2 = wk_SS
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If Ct.SelLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
        '				If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
        '					wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
        '					If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
        '						Beep()
        '						Exit Function
        '					End If
        '				End If
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, Ct.SelLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + Ct.SelLength + 1) 'V6.52
        '				ElseIf Len(wk_Txt) >= wk_SS + 1 Then 
        '					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, 1))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2)
        '				End If
        '				If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
        '					'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        '					If IsDbNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
        '						wk_SS = wk_Ln
        '						'UPGRADE_WARNING: �I�u�W�F�N�g AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then 
        '						wk_Txt = ""
        '						wk_SS = wk_Ln
        '					End If
        '				End If
        '			End If
        '			pm_TA = AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC), CP_SSSMAIN(wk_Px).FractionC, False)
        '			PP_SSSMAIN.MaskMode = True
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Ct = pm_TA
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Ct.SelStart = wk_SS
        '			Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(wk_Px), Ct, (PP_SSSMAIN.SelValid And Not CP_SSSMAIN(wk_Px).FixedFormat))
        '			PP_SSSMAIN.MaskMode = False
        '			Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(wk_Px))
        '			CP_SSSMAIN(wk_Px).StatusC = Cn_Status1
        '			Ct.ForeColor = System.Drawing.ColorTranslator.FromOle(AE_Color(Cn_Status1))
        '			Select Case CP_SSSMAIN(wk_Px).TypeA
        '				Case Cn_NormalOrV, Cn_InputOnly
        '					Ct.BackColor = System.Drawing.ColorTranslator.FromOle(PP_SSSMAIN.BrightOnOff)
        '			End Select
        '		ElseIf pm_KeyCode = System.Windows.Forms.Keys.Insert Then 
        '			If CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Or CP_SSSMAIN(wk_Px).TypeA = Cn_ListBox Or CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("1") Then Exit Function
        '			wk_Ln = Len(wk_Txt)
        '			PP_SSSMAIN.Override = PP_SSSMAIN.Override Xor 1
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then Ct.SelStart = wk_Ln - 1
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Ct.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Ct.SelLength = PP_SSSMAIN.Override
        '		ElseIf pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12 Then 
        '			wk_Int = AE_FuncKey_SSSMAIN(pm_KeyCode, pm_Shift)
        '			If pm_KeyCode <> System.Windows.Forms.Keys.F4 Or (pm_Shift And 6) <> 4 Then pm_KeyCode = 0
        '		ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then 
        '			pm_KeyCode = 0
        '		End If
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
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '���l��
                    wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            GoTo AE_KeyDownRightEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS - 1
                    Loop
                    DirectCast(Ct, TextBox).SelectionStart = 0
                Else
                    DirectCast(Ct, TextBox).SelectionStart = Len(wk_Txt) - PP_SSSMAIN.Override
                End If
AE_KeyDownRightEnd1_SSSMAIN:
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            Else
                wk_Ln = Len(wk_Txt)
                If wk_SS = wk_Ln Then
                    If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest6 : GoTo CheckOrSkip
                ElseIf wk_SS <= wk_Ln - 2 Or wk_Ln <= 1 And CP_SSSMAIN(wk_Px).MaxLength <> 0 Then
                    Do While wk_SS <= wk_Ln - 2
                        wk_SS = wk_SS + 1
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
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
                            DirectCast(Ct, TextBox).Select(wk_SS + 1, PP_SSSMAIN.Override)
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        End If
                    Else
                        DirectCast(Ct, TextBox).Select(wk_Ln, PP_SSSMAIN.Override)
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
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                If CP_SSSMAIN(wk_Px).Alignment = 1 Then '�E�l��
                    wk_SS = 0
                    wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS < wk_Ln
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            GoTo AE_KeyDownLeftEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS + 1
                    Loop
                    DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                Else
                    DirectCast(Ct, TextBox).SelectionStart = 0
                End If
AE_KeyDownLeftEnd1_SSSMAIN:
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            Else
                If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
                    PP_SSSMAIN.Override = 1
                    DirectCast(Ct, TextBox).Select(wk_SS - 1, PP_SSSMAIN.Override)
                ElseIf wk_SS = 0 Then
                    If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
                Else
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        wk_SS = wk_SS - 1
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
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
            'change start 20190809 kuwahara
            'wk_Ln = Len(Ct)
            wk_Ln = Len(Ct.Text)
            'change end 20190809 kuwahara
            If CP_SSSMAIN(wk_Px).KeyInOkClass = Asc("-") Then
                Exit Function
            ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then
                Exit Function
            ElseIf Not AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(wk_Px)) Or Not AE_IsEnable(CP_SSSMAIN(wk_Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
                Exit Function
            ElseIf CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                If AE_KeyInOkChar(PP_SSSMAIN, Space(1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
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
            ElseIf DirectCast(Ct, TextBox).SelectionLength = wk_Ln And wk_Ln > 1 Then
                wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
                If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
            ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then
                wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
            ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + DirectCast(Ct, TextBox).SelectionLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, DirectCast(Ct, TextBox).SelectionLength))) 'V6.52
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'change start 20190809 kuwahara
                    'wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
                    'change end 20190809 kuwahara
                End If
                If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    If IsDBNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
                    ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then
                        wk_Txt = ""
                    End If
                End If
            Else
                wk_SS2 = wk_SS
                If DirectCast(Ct, TextBox).SelectionLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
                    If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
                        Beep()
                        Exit Function
                    End If
                End If
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, DirectCast(Ct, TextBox).SelectionLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + DirectCast(Ct, TextBox).SelectionLength + 1) 'V6.52
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, 1))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2)
                End If
                If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    If IsDBNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
                        wk_SS = wk_Ln
                    ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then
                        wk_Txt = ""
                        wk_SS = wk_Ln
                    End If
                End If
            End If
            pm_TA = AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC), CP_SSSMAIN(wk_Px).FractionC, False)
            PP_SSSMAIN.MaskMode = True
            Ct.Text = pm_TA
            DirectCast(Ct, TextBox).SelectionStart = wk_SS
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
            If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then DirectCast(Ct, TextBox).SelectionStart = wk_Ln - 1
            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
        ElseIf pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12 Then
            wk_Int = AE_FuncKey_SSSMAIN(pm_KeyCode, pm_Shift)
            If pm_KeyCode <> System.Windows.Forms.Keys.F4 Or (pm_Shift And 6) <> 4 Then pm_KeyCode = 0
        ElseIf CP_SSSMAIN(wk_Px).TypeA = Cn_InputOnly Then
            pm_KeyCode = 0
        End If
        '2019.04.08 chg end
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
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Last() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
                    PP_SSSMAIN.Mode = Cn_Mode1 '2019.04.09 del : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�ǉ�"
                    Call AE_TabStop_SSSMAIN(0, 14, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
                End If
            Case Cn_Mode2
                If PP_SSSMAIN.Mode <> Cn_Mode2 Then
                    PP_SSSMAIN.Mode = Cn_Mode2 '2019.04.09 del : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�I��"
                    Call AE_TabStop_SSSMAIN(0, 14, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
                End If
            Case Cn_Mode3
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    PP_SSSMAIN.Mode = Cn_Mode3 '2019.04.09 del : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�\��"
                    Call AE_TabStop_SSSMAIN(0, 14, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
                End If
            Case Cn_Mode4
                If PP_SSSMAIN.Mode <> Cn_Mode4 Then
                    PP_SSSMAIN.Mode = Cn_Mode4 '2019.04.09 del : AE_ModeBar(PP_SSSMAIN.ScX).Text = "�X�V"
                    Call AE_TabStop_SSSMAIN(0, 14, False)
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
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Next() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
        'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        If IsNothing(Valu) Then
            'UPGRADE_WARNING: �I�u�W�F�N�g AE_NullCnv1_SSSMAIN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            AE_NullCnv1_SSSMAIN = 0@
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf IsDBNull(Valu) Then
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
        ElseIf IsDBNull(Valu) Then
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
        PP_SSSMAIN.RecalcMode = True
        If AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(0).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPEID(AE_Val2(CP_SSSMAIN(0)), CP_SSSMAIN(0).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(1).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPENM(AE_Val2(CP_SSSMAIN(1)), CP_SSSMAIN(1).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(2).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_HAKKOU(AE_Val2(CP_SSSMAIN(2)), CP_SSSMAIN(2).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(3).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_KINKYU(AE_Val2(CP_SSSMAIN(3)), CP_SSSMAIN(3).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(4).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_TANCD(AE_Val2(CP_SSSMAIN(4)), CP_SSSMAIN(4).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(5).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_TANNM(AE_Val2(CP_SSSMAIN(5)), CP_SSSMAIN(5).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(6).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_BMNCD(AE_Val2(CP_SSSMAIN(6)), CP_SSSMAIN(6).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(7).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_BMNNM(AE_Val2(CP_SSSMAIN(7)), CP_SSSMAIN(7).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(8).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(8).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(8).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_DENDT(AE_Val2(CP_SSSMAIN(8)), CP_SSSMAIN(8).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(9).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(9).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(9).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_JDNNO(AE_Val2(CP_SSSMAIN(9)), CP_SSSMAIN(9).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(10).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(10).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(10).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_TOKCD(AE_Val2(CP_SSSMAIN(10)), CP_SSSMAIN(10).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(11).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(11).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(11).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_TOKRN(AE_Val2(CP_SSSMAIN(11)), CP_SSSMAIN(11).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(12).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(12).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(12).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val2(CP_SSSMAIN(12)), CP_SSSMAIN(12).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(13).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(13).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(13).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val2(CP_SSSMAIN(13)), CP_SSSMAIN(13).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(14).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(14).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(14).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_PRTKB(AE_Val2(CP_SSSMAIN(14)), CP_SSSMAIN(14).StatusF, False, False)
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
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Select() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
        ElseIf PP_SSSMAIN.Tx < 15 Then
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
                    Call AE_Check_SSSMAIN_HAKKOU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 3
                    Call AE_Check_SSSMAIN_KINKYU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 4
                    Call AE_Check_SSSMAIN_TANCD(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 5
                    Call AE_Check_SSSMAIN_TANNM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 6
                    Call AE_Check_SSSMAIN_BMNCD(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 7
                    Call AE_Check_SSSMAIN_BMNNM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 8
                    Call AE_Check_SSSMAIN_DENDT(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 9
                    Call AE_Check_SSSMAIN_JDNNO(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 10
                    Call AE_Check_SSSMAIN_TOKCD(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 11
                    Call AE_Check_SSSMAIN_TOKRN(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 12
                    Call AE_Check_SSSMAIN_JDNTRKB(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 13
                    Call AE_Check_SSSMAIN_JDNTRNM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 14
                    Call AE_Check_SSSMAIN_PRTKB(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
            End Select
        End If
    End Sub

    Sub AE_Slist_SSSMAIN() 'Generated.
        Dim wk_Slisted As Object
        If False Then
        ElseIf PP_SSSMAIN.Tx = 4 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = TANCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(4).TpStr = wk_Slisted
                    CP_SSSMAIN(4).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 4) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190809 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 4) = wk_Slisted
                    'Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(4), AE_Controls(PP_SSSMAIN.CtB + 4).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 4), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(4), AE_Controls(PP_SSSMAIN.CtB + 4).Text), Cn_Status6, True, True)
                    'change end 20190809 kuwahara
                End If
            Else
                PP_SSSMAIN.CursorDest = Cn_Dest0
                PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
            End If
        ElseIf PP_SSSMAIN.Tx = 6 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = BMNCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(6).TpStr = wk_Slisted
                    CP_SSSMAIN(6).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 6) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190816 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 6) = wk_Slisted
                    'Call AE_Check_SSSMAIN_BMNCD(AE_Val3(CP_SSSMAIN(6), AE_Controls(PP_SSSMAIN.CtB + 6).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 6), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_BMNCD(AE_Val3(CP_SSSMAIN(6), AE_Controls(PP_SSSMAIN.CtB + 6).Text), Cn_Status6, True, True)
                    'change end 20190816 kuwahara
                End If
            Else
                PP_SSSMAIN.CursorDest = Cn_Dest0
                PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
            End If
        ElseIf PP_SSSMAIN.Tx = 8 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = DENDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(8).TpStr = wk_Slisted
                    CP_SSSMAIN(8).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 8) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190816 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 8) = wk_Slisted
                    'Call AE_Check_SSSMAIN_DENDT(AE_Val3(CP_SSSMAIN(8), AE_Controls(PP_SSSMAIN.CtB + 8).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 8), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_DENDT(AE_Val3(CP_SSSMAIN(8), AE_Controls(PP_SSSMAIN.CtB + 8).Text), Cn_Status6, True, True)
                    'change end 20190816 kuwahara
                End If
            Else
                PP_SSSMAIN.CursorDest = Cn_Dest0
                PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
            End If
        ElseIf PP_SSSMAIN.Tx = 9 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNNO_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = JDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(9).TpStr = wk_Slisted
                    CP_SSSMAIN(9).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 9) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

                    'add start 20190819 kuwahara
                    'JDNNO��6���ł��邪�A�󔒂��܂�10�����擾���邽�߁A�g���~���O������
                    wk_Slisted = Mid(wk_Slisted, 1, 6)
                    'add end 20190819 kuwahara

                    'change start 20190816 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 9) = wk_Slisted
                    'Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(9), AE_Controls(PP_SSSMAIN.CtB + 9).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 9), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(9), AE_Controls(PP_SSSMAIN.CtB + 9).Text), Cn_Status6, True, True)
                End If
            Else
                PP_SSSMAIN.CursorDest = Cn_Dest0
                PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
            End If
        ElseIf PP_SSSMAIN.Tx = 10 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = TOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(10).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(10).TpStr = wk_Slisted
                    CP_SSSMAIN(10).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 10) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

                    'add start 20190819 kuwahara
                    'TOKCD��5���ł��邪�A�󔒂��܂�7�����擾���邽�߁A�g���~���O������
                    wk_Slisted = Mid(wk_Slisted, 1, 5)
                    'add end 20190819 kuwahara

                    'change start 20190816 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 10) = wk_Slisted
                    'Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(10), AE_Controls(PP_SSSMAIN.CtB + 10).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 10), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(10), AE_Controls(PP_SSSMAIN.CtB + 10).Text), Cn_Status6, True, True)
                    'change end 20190816 kuwahara
                End If
            Else
                PP_SSSMAIN.CursorDest = Cn_Dest0
                PP_SSSMAIN.NextTx = PP_SSSMAIN.Tx
            End If
        ElseIf PP_SSSMAIN.Tx = 12 Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = JDNTRKB_Slist(PP_SSSMAIN)
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CP_SSSMAIN(12).TpStr = wk_Slisted
                    CP_SSSMAIN(12).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + 12) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'change start 20190816 kuwahara
                    'AE_Controls(PP_SSSMAIN.CtB + 12) = wk_Slisted
                    'Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(12), AE_Controls(PP_SSSMAIN.CtB + 12).ToString()), Cn_Status6, True, True)
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 12), TextBox).Text = wk_Slisted
                    Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(12), AE_Controls(PP_SSSMAIN.CtB + 12).Text), Cn_Status6, True, True)
                    'change end 20190816 kuwahara
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
            If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < 15 Then
            Else
                wk_Px = AE_Px(PP_SSSMAIN, wk_Tx)
                wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
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
            '2019.04.08 CHG START
            'AE_StatusCodeBar(PP_SSSMAIN.ScX) = ""
            ''UPGRADE_WARNING: �I�u�W�F�N�g AE_StatusBar(PP_SSSMAIN.ScX) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'AE_StatusBar(PP_SSSMAIN.ScX) = ""
            AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
            '2019.04.08 CHG END
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
        Const WM_CONTEXTMENU As Short = &H7BS
        If uMsg = WM_CONTEXTMENU Then
            AE_WindowProc_SSSMAIN = 1
        Else
            AE_WindowProc_SSSMAIN = CallWindowProc(PP_SSSMAIN.lpPrevWndProc, hw, uMsg, wParam, lParam)
        End If
    End Function

    Sub AE_WindowProcSet_SSSMAIN() 'Generated.
        If Cn_DebugMode Then Exit Sub
        Dim wk_Tx As Short
        '2019.04.08 DEL START
        'For wk_Tx = 0 To PP_SSSMAIN.ControlsC - 1
        '          'UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
        '          PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '      Next wk_Tx
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_StatusBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN �� delegate ��ǉ����� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' ���N���b�N���Ă��������B
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_ModeBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '2019.04.08 DEL END
    End Sub

    Sub DP_SSSMAIN_BMNCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(6), AE_Val3(CP_SSSMAIN(6), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(6).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If CP_SSSMAIN(6).CuVal <> V Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(6).StatusC = Cn_Status6 : CP_SSSMAIN(6).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(6).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(6).StatusC = Cn_Status6 : CP_SSSMAIN(6).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(6).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(6).CuVal = V
        CP_SSSMAIN(6).TpStr = AE_Format(CP_SSSMAIN(6), CP_SSSMAIN(6).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 6, CP_SSSMAIN(6).TpStr, CP_SSSMAIN(6).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_BMNNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(7), AE_Val3(CP_SSSMAIN(7), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(7).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(7).CuVal <> V Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(7).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(7).CuVal <> V Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(7).StatusC = Cn_Status6 : CP_SSSMAIN(7).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(7).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(7).StatusC = Cn_Status6 : CP_SSSMAIN(7).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(7).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(7).CuVal = V
        CP_SSSMAIN(7).TpStr = AE_Format(CP_SSSMAIN(7), CP_SSSMAIN(7).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 7, CP_SSSMAIN(7).TpStr, CP_SSSMAIN(7).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_DENDT(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(8), AE_Val3(CP_SSSMAIN(8), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(8).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(8).CuVal <> V Or CP_SSSMAIN(8).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(8).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(8).CuVal <> V Or CP_SSSMAIN(8).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(8).StatusC = Cn_Status6 : CP_SSSMAIN(8).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(8).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(8).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(8).StatusC = Cn_Status6 : CP_SSSMAIN(8).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(8).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(8).CuVal = V
        CP_SSSMAIN(8).TpStr = AE_Format(CP_SSSMAIN(8), CP_SSSMAIN(8).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 8, CP_SSSMAIN(8).TpStr, CP_SSSMAIN(8).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_HAKKOU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(2).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(2).CuVal <> V Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(2).StatusC = Cn_Status6 : CP_SSSMAIN(2).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(2).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(2).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_JDNNO(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(9), AE_Val3(CP_SSSMAIN(9), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(9).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara 
        'If CP_SSSMAIN(9).CuVal <> V Or CP_SSSMAIN(9).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(9).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(9).CuVal <> V Or CP_SSSMAIN(9).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(9).StatusC = Cn_Status6 : CP_SSSMAIN(9).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(9).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(9).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(9).StatusC = Cn_Status6 : CP_SSSMAIN(9).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(9).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(9).CuVal = V
        CP_SSSMAIN(9).TpStr = AE_Format(CP_SSSMAIN(9), CP_SSSMAIN(9).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 9, CP_SSSMAIN(9).TpStr, CP_SSSMAIN(9).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_JDNTRKB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(12), AE_Val3(CP_SSSMAIN(12), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(12).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(12).CuVal <> V Or CP_SSSMAIN(12).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(12).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(12).CuVal <> V Or CP_SSSMAIN(12).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(12).StatusC = Cn_Status6 : CP_SSSMAIN(12).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(12).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(12).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(12).StatusC = Cn_Status6 : CP_SSSMAIN(12).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(12).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(12).CuVal = V
        CP_SSSMAIN(12).TpStr = AE_Format(CP_SSSMAIN(12), CP_SSSMAIN(12).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 12, CP_SSSMAIN(12).TpStr, CP_SSSMAIN(12).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_JDNTRNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(13), AE_Val3(CP_SSSMAIN(13), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(13).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(13).CuVal <> V Or CP_SSSMAIN(13).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(13).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(13).CuVal <> V Or CP_SSSMAIN(13).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(13).StatusC = Cn_Status6 : CP_SSSMAIN(13).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(13).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(13).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(13).StatusC = Cn_Status6 : CP_SSSMAIN(13).StatusF = Cn_Status6
        End If
        ''''''''''2019.04.11 chg start '�悭�킩��Ȃ��C���������Ă����̂ňړ��B���̏ꏊ��4235�`4244�s���`�F���W���Ă����B
        '''''''''''''''''If (IsDBNull(CP_SSSMAIN(13).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(13).StatusC <> Cn_Status8 Then
        '''''''''''''''''    CP_SSSMAIN(13).StatusC = Cn_Status6 : CP_SSSMAIN(13).StatusF = Cn_Status6
        '''''''''''''''''ElseIf IIf(IsDBNull(CP_SSSMAIN(13).CuVal), " ", CP_SSSMAIN(13).CuVal) <> IIf(IsDBNull(V), " ", V) Or CP_SSSMAIN(13).StatusC <> Cn_Status8 Then
        '''''''''''''''''    CP_SSSMAIN(13).StatusC = Cn_Status6 : CP_SSSMAIN(13).StatusF = Cn_Status6
        '''''''''''''''''End If
        ''''''''''2019.04.11 chg end
        CP_SSSMAIN(13).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(13).CuVal = V
        CP_SSSMAIN(13).TpStr = AE_Format(CP_SSSMAIN(13), CP_SSSMAIN(13).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 13, CP_SSSMAIN(13).TpStr, CP_SSSMAIN(13).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_KINKYU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(3), AE_Val3(CP_SSSMAIN(3), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(3).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(3).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(3).StatusC = Cn_Status6 : CP_SSSMAIN(3).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(3).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(3).StatusC = Cn_Status6 : CP_SSSMAIN(3).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(3).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(0), AE_Val3(CP_SSSMAIN(0), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(0).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(0).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(0).CuVal <> V Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(0).StatusC = Cn_Status6 : CP_SSSMAIN(0).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(0).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
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
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(1).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(1).CuVal <> V Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(1).StatusC = Cn_Status6 : CP_SSSMAIN(1).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(1).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(1).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_PRTKB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(14), AE_Val3(CP_SSSMAIN(14), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(14).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(14).CuVal <> V Or CP_SSSMAIN(14).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(14).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(14).CuVal <> V Or CP_SSSMAIN(14).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(14).StatusC = Cn_Status6 : CP_SSSMAIN(14).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(14).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(14).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(14).StatusC = Cn_Status6 : CP_SSSMAIN(14).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(14).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(14).CuVal = V
        CP_SSSMAIN(14).TpStr = AE_Format(CP_SSSMAIN(14), CP_SSSMAIN(14).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 14, CP_SSSMAIN(14).TpStr, CP_SSSMAIN(14).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_TANCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(4), AE_Val3(CP_SSSMAIN(4), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(4).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(4).CuVal <> V Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(4).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(4).CuVal <> V Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(4).StatusC = Cn_Status6 : CP_SSSMAIN(4).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(4).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(4).StatusC = Cn_Status6 : CP_SSSMAIN(4).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(4).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(4).CuVal = V
        CP_SSSMAIN(4).TpStr = AE_Format(CP_SSSMAIN(4), CP_SSSMAIN(4).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 4, CP_SSSMAIN(4).TpStr, CP_SSSMAIN(4).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_TANNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(5), AE_Val3(CP_SSSMAIN(5), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(5).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(5).CuVal <> V Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(5).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(5).CuVal <> V Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(5).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
        End If
        '''''''''''2019.04.19 chg start �@�@�@'20190809 ����
        '''''''''''If (IsDBNull(CP_SSSMAIN(5).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
        '''''''''''    'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        '''''''''''ElseIf IIf(IsDBNull(CP_SSSMAIN(5).CuVal), " ", CP_SSSMAIN(5).CuVal) <> IIf(IsDBNull(V), " ", V) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
        '''''''''''End If
        ''''''''''''2019.04.18 chg end
        CP_SSSMAIN(5).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(5).CuVal = V
        CP_SSSMAIN(5).TpStr = AE_Format(CP_SSSMAIN(5), CP_SSSMAIN(5).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 5, CP_SSSMAIN(5).TpStr, CP_SSSMAIN(5).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_TOKCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(10), AE_Val3(CP_SSSMAIN(10), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(10).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(10).CuVal <> V Or CP_SSSMAIN(10).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(10).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(10).CuVal <> V Or CP_SSSMAIN(10).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(10).StatusC = Cn_Status6 : CP_SSSMAIN(10).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(10).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(10).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(10).StatusC = Cn_Status6 : CP_SSSMAIN(10).StatusF = Cn_Status6
        End If
        '''''''''''2019.04.11 chg start
        '''''''''''If (IsDBNull(CP_SSSMAIN(10).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(10).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(10).StatusC = Cn_Status6 : CP_SSSMAIN(10).StatusF = Cn_Status6
        '''''''''''ElseIf IIf(IsDBNull(CP_SSSMAIN(10).CuVal), " ", CP_SSSMAIN(10).CuVal) <> IIf(IsDBNull(V), " ", V) Or CP_SSSMAIN(10).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(10).StatusC = Cn_Status6 : CP_SSSMAIN(10).StatusF = Cn_Status6
        '''''''''''End If
        ''''''''''''2019.04.11 chg end
        CP_SSSMAIN(10).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(10).CuVal = V
        CP_SSSMAIN(10).TpStr = AE_Format(CP_SSSMAIN(10), CP_SSSMAIN(10).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 10, CP_SSSMAIN(10).TpStr, CP_SSSMAIN(10).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_TOKRN(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(11), AE_Val3(CP_SSSMAIN(11), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(11).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(11).CuVal <> V Or CP_SSSMAIN(11).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(11).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(11).CuVal <> V Or CP_SSSMAIN(11).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(11).StatusC = Cn_Status6 : CP_SSSMAIN(11).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(11).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(11).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(11).StatusC = Cn_Status6 : CP_SSSMAIN(11).StatusF = Cn_Status6
        End If
        '''''''''''2019.04.11 chg start '20190809 
        '''''''''''If (IsDBNull(CP_SSSMAIN(11).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(11).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(11).StatusC = Cn_Status6 : CP_SSSMAIN(11).StatusF = Cn_Status6
        '''''''''''ElseIf IIf(IsDBNull(CP_SSSMAIN(11).CuVal), " ", CP_SSSMAIN(11).CuVal) <> IIf(IsDBNull(V), " ", V) Or CP_SSSMAIN(11).StatusC <> Cn_Status8 Then
        '''''''''''    CP_SSSMAIN(11).StatusC = Cn_Status6 : CP_SSSMAIN(11).StatusF = Cn_Status6
        '''''''''''End If
        ''''''''''''2019.04.11 chg END
        CP_SSSMAIN(11).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(11).CuVal = V
        CP_SSSMAIN(11).TpStr = AE_Format(CP_SSSMAIN(11), CP_SSSMAIN(11).CuVal, 0, True)
        Call AE_CtSet(PP_SSSMAIN, 11, CP_SSSMAIN(11).TpStr, CP_SSSMAIN(11).TypeA, False)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Sub DP_SSSMAIN_FDNNO(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        'UPGRADE_WARNING: �I�u�W�F�N�g DBItem �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g AE_NormData() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        V = AE_NormData(CP_SSSMAIN(15), AE_Val3(CP_SSSMAIN(15), CStr(DBItem)))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(15).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190809 kuwahara
        'If CP_SSSMAIN(15).CuVal <> V Or CP_SSSMAIN(15).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(15).CuVal) = False _
         AndAlso IsDBNull(V) = False _
         AndAlso CP_SSSMAIN(15).CuVal <> V Or CP_SSSMAIN(15).StatusC <> Cn_Status8 Then
            'change end 20190809 kuwahara
            CP_SSSMAIN(15).StatusC = Cn_Status6 : CP_SSSMAIN(15).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ElseIf (IsDBNull(CP_SSSMAIN(15).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(15).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(15).StatusC = Cn_Status6 : CP_SSSMAIN(15).StatusF = Cn_Status6
        End If
        CP_SSSMAIN(15).CheckRtnCode = 0
        Call AE_ColorSub(PP_SSSMAIN, CP_SSSMAIN(15), CL_SSSMAIN(15))
        'UPGRADE_WARNING: �I�u�W�F�N�g V �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CP_SSSMAIN(15).CuVal = V
        CP_SSSMAIN(15).TpStr = AE_Format(CP_SSSMAIN(15), CP_SSSMAIN(15).CuVal, 0, True)
        PP_SSSMAIN.MaskMode = wk_SaveMask
    End Sub

    Function RD_SSSMAIN_BMNCD(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(6).CuVal) Then
            RD_SSSMAIN_BMNCD = Space(6)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(6).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 6 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_BMNCD = CStr(CP_SSSMAIN(6).CuVal) & Space(6 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_BMNCD = CStr(CP_SSSMAIN(6).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_BMNNM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(7).CuVal) Then
            RD_SSSMAIN_BMNNM = Space(40)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(7).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 40 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_BMNNM = CStr(CP_SSSMAIN(7).CuVal) & Space(40 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_BMNNM = CStr(CP_SSSMAIN(7).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_DENDT(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(8).CuVal) Then
            RD_SSSMAIN_DENDT = Space(8)
        ElseIf Not IsDate(CP_SSSMAIN(8).CuVal) Then
            RD_SSSMAIN_DENDT = Space(8)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            RD_SSSMAIN_DENDT = VB6.Format(CP_SSSMAIN(8).CuVal, "YYYYMMDD")
        End If
    End Function

    Function RD_SSSMAIN_HAKKOU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(2).CuVal) Then
            RD_SSSMAIN_HAKKOU = Space(1)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(2).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 1 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_HAKKOU = Space(1 - LenWid(st_Work)) & CStr(CP_SSSMAIN(2).CuVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HAKKOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_HAKKOU = CStr(CP_SSSMAIN(2).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_JDNNO(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(9).CuVal) Then
            RD_SSSMAIN_JDNNO = Space(6)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(9).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 6 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNNO = CStr(CP_SSSMAIN(9).CuVal) & Space(6 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNNO = CStr(CP_SSSMAIN(9).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_JDNTRKB(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(12).CuVal) Then
            RD_SSSMAIN_JDNTRKB = Space(2)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(12).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 2 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNTRKB = CStr(CP_SSSMAIN(12).CuVal) & Space(2 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNTRKB = CStr(CP_SSSMAIN(12).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_JDNTRNM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(13).CuVal) Then
            RD_SSSMAIN_JDNTRNM = Space(10)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(13).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 10 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNTRNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNTRNM = CStr(CP_SSSMAIN(13).CuVal) & Space(10 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_JDNTRNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_JDNTRNM = CStr(CP_SSSMAIN(13).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_KINKYU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(3).CuVal) Then
            RD_SSSMAIN_KINKYU = Space(1)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(3).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 1 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_KINKYU = Space(1 - LenWid(st_Work)) & CStr(CP_SSSMAIN(3).CuVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_KINKYU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_KINKYU = CStr(CP_SSSMAIN(3).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_OPEID(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(0).CuVal) Then
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
        If IsDBNull(CP_SSSMAIN(1).CuVal) Then
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

    Function RD_SSSMAIN_PRTKB(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(14).CuVal) Then
            RD_SSSMAIN_PRTKB = Space(1)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(14).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 1 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_PRTKB = Space(1 - LenWid(st_Work)) & CStr(CP_SSSMAIN(14).CuVal)
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_PRTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_PRTKB = CStr(CP_SSSMAIN(14).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_TANCD(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(4).CuVal) Then
            RD_SSSMAIN_TANCD = Space(6)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(4).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 6 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TANCD = CStr(CP_SSSMAIN(4).CuVal) & Space(6 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TANCD = CStr(CP_SSSMAIN(4).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_TANNM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(5).CuVal) Then
            RD_SSSMAIN_TANNM = Space(20)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(5).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 20 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TANNM = CStr(CP_SSSMAIN(5).CuVal) & Space(20 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TANNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TANNM = CStr(CP_SSSMAIN(5).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_TOKCD(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(10).CuVal) Then
            RD_SSSMAIN_TOKCD = Space(5)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(10).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 5 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TOKCD = CStr(CP_SSSMAIN(10).CuVal) & Space(5 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TOKCD = CStr(CP_SSSMAIN(10).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_TOKRN(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(11).CuVal) Then
            RD_SSSMAIN_TOKRN = Space(40)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(11).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 40 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKRN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TOKRN = CStr(CP_SSSMAIN(11).CuVal) & Space(40 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKRN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_TOKRN = CStr(CP_SSSMAIN(11).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_FDNNO(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(CP_SSSMAIN(15).CuVal) Then
            RD_SSSMAIN_FDNNO = Space(8)
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            st_Work = CStr(CP_SSSMAIN(15).CuVal)
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(st_Work$) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If LenWid(st_Work) < 8 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_FDNNO = CStr(CP_SSSMAIN(15).CuVal) & Space(8 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN().CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                RD_SSSMAIN_FDNNO = CStr(CP_SSSMAIN(15).CuVal)
            End If
        End If
    End Function
End Module