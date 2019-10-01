Option Strict Off
Option Explicit On
'20190705 ADD START
Imports PronesDbAccess
Imports Oracle.DataAccess.Client
'20190705 ADD END
Module SSSMAIN0001
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    '
    '単プロジェクトごとの共通ライブラリ
    Public PP_SSSMAIN As clsPP
    Public CP_SSSMAIN(128 + 8 + 0 + 1) As clsCP
    Public CL_SSSMAIN(128) As Short
    Public CQ_SSSMAIN(25) As String
    '20190705 ADD START
    Public CON As OracleConnection = Nothing
    '// ダイナセット情報構造体
    Public Structure U_Ody
        Dim Obj_Ody As Object '//OraDynasetｵﾌﾞｼﾞｪｸﾄ
        Dim Obj_Flds() As Object '//ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ
        Dim Lng_FldCnt As Integer '//ﾌｨｰﾙﾄﾞ数
        Dim Str_FldNm As String '//フィールド番号とﾌｨｰﾙﾄﾞ名
    End Structure
    '20190705 ADD END

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

    Sub AE_Check_SSSMAIN_RELZAISU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 15 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SMAINPSU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 11 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SMAOUTSU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 12 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SMAZAISU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 14 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SMZZAISU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 10 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SOUCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 8 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_SOUNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 9 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_ZAISAISU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim wk_Tx As Short
        Dim wk_Px As Short
        wk_Px = 13 + 8 * PP_SSSMAIN.De
        wk_Tx = AE_Tx(PP_SSSMAIN, wk_Px)
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(wk_Px)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(wk_Px), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_DSPYM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(0)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(0), CC_NewVal)
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(0).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: オブジェクト DSPYM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = DSPYM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
            Else
                'UPGRADE_WARNING: オブジェクト DSPYM_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = DSPYM_CheckC(AE_NullCnv2_SSSMAIN(CC_NewVal))
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

    Sub AE_Check_SSSMAIN_HINCD(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(1)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(1), CC_NewVal)
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(1).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If (.CheckRtnCode = 0) And pm_HandIn And (CC_NewVal = .CuVal Or (AE_IsNull_SSSMAIN(CC_NewVal) And AE_IsNull_SSSMAIN(.CuVal))) Then
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            'UPGRADE_WARNING: オブジェクト AE_NullCnv2_SSSMAIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CC_NewVal = AE_NullCnv2_SSSMAIN(CC_NewVal)
            If PP_SSSMAIN.RecalcMode Then
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = .CheckRtnCode
            ElseIf (.CheckRtnCode <> 0) Then
                'UPGRADE_WARNING: オブジェクト HINCD_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = HINCD_CheckC(PP_SSSMAIN, CP_SSSMAIN(1), PP_SSSMAIN.De2, CC_NewVal)
            Else
                'UPGRADE_WARNING: オブジェクト HINCD_CheckC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Ck_Error = HINCD_CheckC(PP_SSSMAIN, CP_SSSMAIN(1), PP_SSSMAIN.De2, CC_NewVal)
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

    Sub AE_Check_SSSMAIN_HINNMA(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(2)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(2), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_HINNMB(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(3)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(3), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
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

    Sub AE_Check_SSSMAIN_IRISU(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(4)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(4), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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
                'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(CC_NewVal) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If AE_IsNull_SSSMAIN(PP_SSSMAIN.SaveCV) And AE_IsNull_SSSMAIN(CC_NewVal) Or AE_NullCnv1_SSSMAIN(PP_SSSMAIN.SaveCV) = AE_NullCnv1_SSSMAIN(CC_NewVal) Then
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

    Sub AE_Check_SSSMAIN_OPEID(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(6)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(6), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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

    Sub AE_Check_SSSMAIN_OPENM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(7)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(7), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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

    Sub AE_Check_SSSMAIN_UNTNM(ByVal CC_NewVal As Object, ByVal pm_Status As Short, ByVal pm_MoveCursor As Boolean, ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_SaveMask As Boolean
        Dim RC_ErrorC As Short
        Dim wk_RecalcSw As Boolean
        Dim wk_Equal As Boolean
        Dim ex_CheckRtnCode As Short
        With CP_SSSMAIN(5)
            ex_CheckRtnCode = .CheckRtnCode
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CC_NewVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .FormatClass = Cn_Code And .FormatChr <> "" And Not IsDBNull(CC_NewVal) Then CC_NewVal = AE_FormatC(CP_SSSMAIN(5), CC_NewVal)
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
                'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
                'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            End If
            'UPGRADE_WARNING: オブジェクト Ck_Error の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Ck_Error = 0
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
                    '20190704 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = 0
                    ''UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx))
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(0, Len(AE_Controls(PP_SSSMAIN.CtB + pm_Tx)))
                    '20190704 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'wk_SS = AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart
                    wk_SS = DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionStart
                    '20190704 CHG END
                    Do While wk_SS > 0
                        wk_SS = wk_SS - 1
                        If AE_KeyInOkChar(PP_SSSMAIN, Mid(AE_Controls(PP_SSSMAIN.CtB + pm_Tx).ToString(), wk_SS + 1, 1), CP_SSSMAIN(pm_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト AE_Controls().SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190704 CHG START
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                            DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190704 CHG END
                            Exit Sub
                        End If
                    Loop
                    'UPGRADE_WARNING: オブジェクト AE_Controls().SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + pm_Tx).SelLength = PP_SSSMAIN.Override
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + pm_Tx), TextBox).SelectionLength = PP_SSSMAIN.Override
                    '20190704 CHG END
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

    Function AE_ClearedDe_SSSMAIN(ByVal pm_ExceptionDe As Short) As Short 'Generated.
        Dim wk_De As Short
        wk_De = PP_SSSMAIN.LastReadDe
        Do While wk_De < PP_SSSMAIN.LastDe
            If AE_IsClearedDe_SSSMAIN(wk_De) And wk_De <> pm_ExceptionDe Then
                AE_ClearedDe_SSSMAIN = wk_De
                Exit Function
            End If
            wk_De = wk_De + 1
        Loop
        AE_ClearedDe_SSSMAIN = -1
    End Function

    Sub AE_ClearInitValStatus_SSSMAIN() 'Generated.
        PP_SSSMAIN.InitValStatus = PP_SSSMAIN.Mode
        Dim wk_Px As Short
        wk_Px = 0
        Do While wk_Px < 128
            CP_SSSMAIN(wk_Px).Modified = PP_SSSMAIN.Mode
            wk_Px = wk_Px + 1
        Loop
    End Sub

    Sub AE_ClearItm_SSSMAIN(ByVal pm_HandIn As Boolean) 'Generated.
        Dim wk_ClearedVal As Object
        Dim wk_De As Short
        If PP_SSSMAIN.Mode = Cn_Mode3 Then Exit Sub
        If PP_SSSMAIN.Tx < 0 Or PP_SSSMAIN.Tx >= 128 Then Exit Sub
        PP_SSSMAIN.MaskMode = True
        If PP_SSSMAIN.Tx < 8 Then
            Call AE_InitValHd_SSSMAIN(PP_SSSMAIN.Tx, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF)
        ElseIf PP_SSSMAIN.Tx < 128 Then
            Call AE_InitValBdDe_SSSMAIN(PP_SSSMAIN.Px, False, CP_SSSMAIN(PP_SSSMAIN.Px).StatusF) ', PP_SSSMAIN.De
        ElseIf PP_SSSMAIN.Tx < 128 Then
        ElseIf PP_SSSMAIN.Tx < 128 Then
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
        'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
        'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
        If PP_SSSMAIN.InitValStatus >= Cn_Mode4 Then Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px))
        If PP_SSSMAIN.Tx >= 8 And PP_SSSMAIN.Tx < 128 Then
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
                wk_De = AE_ClearedDe_SSSMAIN(PP_SSSMAIN.De)
                If wk_De >= 0 Then
                    Call AE_DeUp_SSSMAIN(wk_De)
                    If wk_De < PP_SSSMAIN.De Then
                        PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
                        wk_Bool = AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx)
                        If PP_SSSMAIN.ActiveDe > wk_De Then PP_SSSMAIN.ActiveDe = PP_SSSMAIN.ActiveDe - 1
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
        Static wk_De As Short
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
        wk_De = 0
        Do While wk_De < PP_SSSMAIN.LastDe And PP_SSSMAIN.InCompletePx = -1
            wk_Px = 8 + 8 * wk_De
            Call AE_CompleteCheckSub_SSSMAIN(wk_Px, wk_Px + 8, wk_IncompletionC, wk_IncompletionC2)
            wk_De = wk_De + 1
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
                    If (Not fl_NullZero And IsDBNull(CP_SSSMAIN(wk_Px).CuVal)) Or (fl_NullZero And AE_IsNull_SSSMAIN(CP_SSSMAIN(wk_Px).CuVal)) Then
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
        If PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 128 Then
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
        Do While wk_Tx < 128
            If wk_Tx < 7 Or wk_Tx >= 128 Then
                wk_Tx = wk_Tx + 1
            ElseIf wk_Tx = 7 Then
                If AE_CursorInOutCheck_SSSMAIN(wk_Tx, 1) >= 0 Then
                    Do
                        wk_Tx = wk_Tx + 1
                        If ((wk_Tx - 8) \ 8) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then Exit Do
                        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
                            Call AE_CursorMove_SSSMAIN(wk_Tx)
                            AE_CursorDown_SSSMAIN = True
                            Exit Function
                        End If
                        If wk_Tx = PP_SSSMAIN.NrBodyTx - 1 Then
                            If PP_SSSMAIN.TopDe < 14 - PP_SSSMAIN.MaxDspC Then
                                wk_ExTopDe = PP_SSSMAIN.TopDe
                                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
                                If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then wk_Tx = wk_Tx - 8
                            End If
                        End If
                    Loop Until wk_Tx >= PP_SSSMAIN.NrBodyTx - 1
                End If
                wk_Tx = 128
            ElseIf wk_Tx + 8 < PP_SSSMAIN.NrBodyTx Then
                wk_Tx = wk_Tx + 8
                If ((wk_Tx - 8) \ 8) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then wk_Tx = 128
                '     以降は (wk_Tx + 8 >= PP_SSSMAIN.NrBodyTx) の場合
            ElseIf PP_SSSMAIN.TopDe < 14 - PP_SSSMAIN.MaxDspC Then
                If AE_CursorInOutCheck_SSSMAIN(wk_Tx, 8) >= 0 Then
                    wk_Tx = wk_Tx + 8
                    If ((wk_Tx - 8) \ 8) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then
                        wk_Tx = 128
                    Else
                        wk_ExTopDe = PP_SSSMAIN.TopDe
                        Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
                        If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then
                            wk_Tx = wk_Tx - 8
                        Else
                            wk_Tx = 128
                        End If
                    End If
                Else
                    wk_Tx = 128
                End If
            Else
                wk_Tx = 128
            End If
            If wk_Tx < 128 Then
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
        Do While wk_Px < 128
            If AE_GetInOutMode(CP_SSSMAIN(wk_Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(wk_Px).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(wk_Px).TypeA <> Cn_CheckBox Then
                    AE_CursorInOutCheck_SSSMAIN = wk_Px
                    Exit Function
                End If
            End If
            wk_Px = wk_Px + pm_Dsp
        Loop
        If pm_Tx < 128 Then
            wk_Px = 128
        Else
            wk_Px = AE_Px(PP_SSSMAIN, pm_Tx) + 1
        End If
        Do While wk_Px < 128
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
        If wk_Tx < 0 Or wk_Tx >= 128 Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
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
        Do While wk_Tx < 128
            wk_Tx = wk_Tx + 1
            If wk_Tx = PP_SSSMAIN.NrBodyTx Then
                If PP_SSSMAIN.TopDe < 14 - PP_SSSMAIN.MaxDspC Then
                    If ((wk_Tx - 8) \ 8) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then
                        wk_Tx = 128
                    Else
                        wk_ExTopDe = PP_SSSMAIN.TopDe
                        Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
                        If PP_SSSMAIN.TopDe = wk_ExTopDe + 1 Then
                            wk_Tx = wk_Tx - 8
                        Else
                            wk_Tx = 128
                        End If
                    End If
                End If
            End If
            If wk_Tx >= 8 And wk_Tx < 128 Then 'AE_BodyN > 0
                If ((wk_Tx - 8) \ 8) + PP_SSSMAIN.TopDe > PP_SSSMAIN.LastDe - wk_DeC Then wk_Tx = 128
            End If
            If wk_Tx < 128 Then
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
        Do While wk_Tx < 127
            wk_Tx = wk_Tx + 1
            If wk_Tx = PP_SSSMAIN.NrBodyTx Then wk_Tx = 128
            If wk_Tx < 128 Then
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
            If wk_Tx = 128 Then
                wk_Tx = PP_SSSMAIN.NrBodyTx - 8
                wk_LastTx = 8 + (PP_SSSMAIN.LastDe - wk_DeC - PP_SSSMAIN.TopDe) * 8
                If wk_LastTx < wk_Tx Then wk_Tx = wk_LastTx
                If wk_Tx >= 8 Then
                    Do
                        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
                            Call AE_CursorMove_SSSMAIN(wk_Tx)
                            AE_CursorPrev_SSSMAIN = True
                            Exit Function
                        End If
                        wk_Tx = wk_Tx + 1
                        If (wk_Tx - 8) Mod 8 = 0 Then wk_Tx = wk_Tx - 8 - 8
                        If wk_Tx < 8 Then
                            If PP_SSSMAIN.TopDe > 0 Then
                                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
                                wk_Tx = wk_Tx + 8
                            End If
                        End If
                    Loop Until wk_Tx < 8
                End If
                wk_Tx = 7
            Else
                wk_Tx = wk_Tx - 1
            End If
            If wk_Tx = 7 And PP_SSSMAIN.TopDe > 0 Then
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
                wk_Tx = wk_Tx + 8
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
            If wk_Tx = 128 Then wk_Tx = PP_SSSMAIN.NrBodyTx
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
                If Not AE_CursorPrev_SSSMAIN(128) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
            Case Cn_Dest4
                PP_SSSMAIN.UpDownFlag = True
                If Not AE_CursorUp_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorNext_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
                End If
                PP_SSSMAIN.UpDownFlag = False
            Case Cn_Dest5
                PP_SSSMAIN.UpDownFlag = True
                If Not AE_CursorDown_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorPrev_SSSMAIN(128) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
                End If
                PP_SSSMAIN.UpDownFlag = False
            Case Cn_Dest6
                If Not AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) Then
                    If Not AE_CursorPrev_SSSMAIN(128) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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
                        If PP_SSSMAIN.CursorDest = Cn_Dest1 And wk_Bool = False Then wk_Bool = AE_CursorPrev_SSSMAIN(128)
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
            ElseIf PP_SSSMAIN.InCompletePx < 128 Then
                Call AE_Scrl_SSSMAIN((PP_SSSMAIN.InCompletePx - 8) \ PP_SSSMAIN.BodyV, False)
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
        Do While wk_Tx < 128
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
            If wk_Tx < 8 Or wk_Tx > 128 Then
                wk_Tx = wk_Tx - 1
            ElseIf wk_Tx = 128 Then
                wk_Tx = PP_SSSMAIN.NrBodyTx - 8
                wk_LastTx = 8 + (PP_SSSMAIN.LastDe - wk_DeC - PP_SSSMAIN.TopDe) * 8
                If wk_LastTx < wk_Tx Then wk_Tx = wk_LastTx
                Do While wk_Tx >= 8
                    If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_Tx)).TypeA, wk_Tx) Then
                        Call AE_CursorMove_SSSMAIN(wk_Tx)
                        AE_CursorUp_SSSMAIN = True
                        Exit Function
                    End If
                    wk_Tx = wk_Tx + 1
                    If (wk_Tx - 8) Mod 8 = 0 Then wk_Tx = wk_Tx - 8 - 8
                    If wk_Tx < 8 Then
                        If PP_SSSMAIN.TopDe > 0 Then
                            Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
                            wk_Tx = wk_Tx + 8
                        End If
                    End If
                Loop
                wk_Tx = 7
            ElseIf wk_Tx - 8 >= 8 Then
                wk_Tx = wk_Tx - 8
            Else 'wk_Tx - 8 < 8 Then
                If PP_SSSMAIN.TopDe > 0 Then
                    Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
                Else
                    wk_Tx = 7
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
        Call AE_InitValAll_SSSMAIN(True)
        'UPGRADE_WARNING: オブジェクト SSSMAIN_Current() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.LastDe = SSSMAIN_Current()
        If PP_SSSMAIN.LastDe = 0 Then
            If Not AE_MsgLibrary(PP_SSSMAIN, "Current") Then
                Call AE_InitValAll_SSSMAIN(True)
            Else
                Call AE_ScrlMax(PP_SSSMAIN)
                Call AE_RecalcAll2_SSSMAIN()
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
            End If
        Else
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll2_SSSMAIN()
            Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
        End If
        Call AE_ClearInitValStatus_SSSMAIN()
        AE_Current_SSSMAIN = Cn_CuInit
    End Function

    Sub AE_DeSub_SSSMAIN(ByVal pm_UD As Short) 'Generated.
        Dim wk_ww As Short
        Dim wk_SaveDe As Short
        Dim wk_SaveDe2 As Short
        Dim wk_PxBaseTarget As Short
        Dim wk_PxBaseSource As Short
        Dim wk_Tx As Short
        wk_SaveDe = PP_SSSMAIN.De : wk_SaveDe2 = PP_SSSMAIN.De2
        wk_PxBaseTarget = 8 + 8 * PP_SSSMAIN.De
        wk_PxBaseSource = wk_PxBaseTarget + pm_UD * 8
        wk_ww = 0
        Do While wk_ww < 8
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            If CP_SSSMAIN(wk_PxBaseSource + wk_ww).StatusC <> Cn_Status8 Or IsDBNull(CP_SSSMAIN(wk_PxBaseSource + wk_ww).CuVal) Then
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
                '20190705 CHG START
                'If wk_Tx >= 0 Then AE_Controls(PP_SSSMAIN.CtB + wk_Tx) = AE_Tpstr(CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr, CP_SSSMAIN(wk_PxBaseSource + wk_ww).TypeA)
                If wk_Tx > 0 Then
                    AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Text = AE_Tpstr(CP_SSSMAIN(wk_PxBaseSource + wk_ww).TpStr, CP_SSSMAIN(wk_PxBaseSource + wk_ww).TypeA)
                End If
                '20190705 CHG END
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
        Do While PP_SSSMAIN.De <= PP_SSSMAIN.LastDe And PP_SSSMAIN.De <= 14
            If PP_SSSMAIN.De = 14 Then
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
            '20190708 DELL START
            'wk_Int = CspPurgeFilterReq(FR_SSSMAIN.Handle.ToInt32)
            '20190708 DELL END
            Call AE_WindowProcReset(PP_SSSMAIN)
            '20190708 DELL START
            'ReleaseTabCapture(FR_SSSMAIN.Handle.ToInt32)
            '20190708 DELL END
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
                wk_De = AE_ClearedDe_SSSMAIN(-1)
                If wk_De >= 0 Then Call AE_DeUp_SSSMAIN(wk_De) : .ActiveDe = -1
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
                wk_De = AE_ClearedDe_SSSMAIN(-1)
                If wk_De >= 0 Then Call AE_DeUp_SSSMAIN(wk_De) : .ActiveDe = -1
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

    Function AE_First_SSSMAIN(ByVal pm_Check As Short) As Short 'Generated.
        If pm_Check Then
            If AE_MsgLibrary(PP_SSSMAIN, "FirstC") Then AE_First_SSSMAIN = Cn_CuCurrent : Exit Function
        End If
        Call AE_InitValAll_SSSMAIN(True)
        'UPGRADE_WARNING: オブジェクト SSSMAIN_First() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.LastDe = SSSMAIN_First()
        If PP_SSSMAIN.LastDe = 0 Then
            If Not AE_MsgLibrary(PP_SSSMAIN, "FirstCm") Then
                Call AE_InitValAll_SSSMAIN(True)
            Else
                Call AE_ScrlMax(PP_SSSMAIN)
                Call AE_RecalcAll2_SSSMAIN()
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
            End If
        Else
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll2_SSSMAIN()
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
        If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        On Error Resume Next
        System.Windows.Forms.Application.DoEvents()
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '20190705 DELL START
        'FR_SSSMAIN.PrintForm()
        '20190705 DELL END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
        If Err.Number <> 0 Then
            If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        End If
        On Error GoTo 0
        AE_Hardcopy_SSSMAIN = Cn_CuCurrent
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

    Sub AE_InitValAll_SSSMAIN(Optional ByVal pm_SprsHdClr As Object = Nothing) 'Generated.
        Dim wk_Px As Short
        Dim wk_De As Short
        Dim wk_InOutMode As Integer
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pm_SprsHdClr) Then
            wk_Px = 0
        Else
            wk_Px = 8
        End If
        Do While wk_Px < 128
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
            CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
            wk_Px = wk_Px + 1
        Loop
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pm_SprsHdClr) Then
            PP_SSSMAIN.MaskMode = True
            Call AE_InitValHd_SSSMAIN(-2, False, Cn_Status0)
            PP_SSSMAIN.MaskMode = False
        End If
        Call AE_Scrl_SSSMAIN(0, False)
        PP_SSSMAIN.MaskMode = True
        PP_SSSMAIN.SuppressMultiTlDerived = True
        PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = 0
        Do While PP_SSSMAIN.De <= 14
            If PP_SSSMAIN.De = 14 Then PP_SSSMAIN.SuppressMultiTlDerived = False
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
        '20190705 CHG START
        'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
        AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
        '20190705 CHG END
        PP_SSSMAIN.MaskMode = False
        PP_SSSMAIN.UnDoDeOp = 0
        PP_SSSMAIN.ActiveDe = -1
        Call AE_ClearInitValStatus_SSSMAIN()
        Call AE_StatusClear(PP_SSSMAIN, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClErrorStatus))
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pm_SprsHdClr) Then
        End If
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pm_SprsHdClr) Then
            wk_Px = 0
        Else
            wk_Px = 8
        End If
        Do While wk_Px < 128
            CP_SSSMAIN(wk_Px).IniStr = CP_SSSMAIN(wk_Px).TpStr
            wk_Px = wk_Px + 1
        Loop
    End Sub

    Sub AE_InitValBd_SSSMAIN() 'Generated.
        Dim wk_Px As Short
        Dim wk_InOutMode As Integer
        Dim wk_De As Short
        wk_Px = 8
        Do While wk_Px < 128
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
            CP_SSSMAIN(wk_Px).InOutMode = wk_InOutMode * 256 + wk_InOutMode
            wk_Px = wk_Px + 1
        Loop
        Call AE_Scrl_SSSMAIN(0, False)
        PP_SSSMAIN.MaskMode = True
        PP_SSSMAIN.SuppressMultiTlDerived = True
        PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = 0
        Do While PP_SSSMAIN.De <= 14
            If PP_SSSMAIN.De = 14 Then PP_SSSMAIN.SuppressMultiTlDerived = False
            Call AE_InitValBdDe_SSSMAIN(-2, False, Cn_Status0) ', PP_SSSMAIN.De
            PP_SSSMAIN.De = PP_SSSMAIN.De + 1 : PP_SSSMAIN.De2 = PP_SSSMAIN.De
        Loop
        PP_SSSMAIN.SuppressMultiTlDerived = False
        PP_SSSMAIN.AlreadyCDe = True
        PP_SSSMAIN.De = 0 : PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.LastDe = 0 : Call AE_ScrlMax(PP_SSSMAIN)
        PP_SSSMAIN.TopDe = 0
        'UPGRADE_WARNING: オブジェクト AE_ScrlBar(PP_SSSMAIN.ScX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190705 CHG START
        'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
        AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
        '20190705 CHG END
        PP_SSSMAIN.MaskMode = False
        PP_SSSMAIN.UnDoDeOp = 0
        PP_SSSMAIN.ActiveDe = -1
        PP_SSSMAIN.InitValStatus = Cn_ModeDataChanged
    End Sub

    Sub AE_InitValEd_SSSMAIN() 'Generated.
        Dim wk_Px As Short
        Dim wk_InOutMode As Integer
        Dim wk_De As Short
        wk_Px = 128
        Do While wk_Px < 128
            wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
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
        wk_PxBase = 8 * PP_SSSMAIN.De
        If pm_Px = -2 Then
            wk_Tx = AE_Tx(PP_SSSMAIN, 8 + wk_PxBase)
            If wk_Tx >= 0 Then
                Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx + 7, pm_SetInOut)
            End If
        ElseIf pm_Px >= 0 Then
            wk_Tx = AE_Tx(PP_SSSMAIN, pm_Px)
            If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, pm_SetInOut)
        End If
        If pm_Px = -2 Or pm_Px = 8 + wk_PxBase Then 'SOUCD
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(8 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 9 + wk_PxBase Then 'SOUNM
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(9 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 10 + wk_PxBase Then 'SMZZAISU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(10 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 11 + wk_PxBase Then 'SMAINPSU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(11 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 12 + wk_PxBase Then 'SMAOUTSU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(12 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 13 + wk_PxBase Then 'ZAISAISU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(13 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 14 + wk_PxBase Then 'SMAZAISU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(14 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 15 + wk_PxBase Then 'RELZAISU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(15 + wk_PxBase), System.DBNull.Value, pm_Status)
        End If
    End Sub

    Sub AE_InitValHd_SSSMAIN(ByVal pm_Px As Short, ByVal pm_SetInOut As Short, ByVal pm_Status As Short) 'Generated.
        Dim wk_Tx As Short
        Dim RC_ErrorC As Short
        Dim wk_ww As Short
        If pm_Px = -2 Then
            Call AE_TabStop_SSSMAIN(0, 7, pm_SetInOut)
        ElseIf pm_Px >= 0 Then
            wk_Tx = AE_Tx(PP_SSSMAIN, pm_Px)
            If wk_Tx >= 0 Then Call AE_TabStop_SSSMAIN(wk_Tx, wk_Tx, pm_SetInOut)
        End If
        If pm_Px = -2 Or pm_Px = 0 Then 'DSPYM
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(0), DSPYM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), PP_SSSMAIN), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 1 Then 'HINCD
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(1), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 2 Then 'HINNMA
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(2), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 3 Then 'HINNMB
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(3), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 4 Then 'IRISU
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(4), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 5 Then 'UNTNM
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(5), System.DBNull.Value, pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 6 Then 'OPEID
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(6), OPEID_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal), PP_SSSMAIN, CP_SSSMAIN(6)), pm_Status)
        End If
        If pm_Px = -2 Or pm_Px = 7 Then 'OPENM
            Call AE_InitVal_SSSMAIN(CP_SSSMAIN(7), OPENM_InitVal(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(7).CuVal), PP_SSSMAIN, CP_SSSMAIN(7)), pm_Status)
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
            Call AE_SystemError("AE_InOutModeM のパラメタ pm_ItemName$ に", 550)
            Exit Sub
        End If
        If Len(pm_Mode) <> 4 Then
            Call AE_SystemError("AE_InOutModeM のパラメタ pm_Mode$ に", 551)
            Exit Sub
        End If
        wk_BodyV = 1
        If wk_Qx < 8 Then
            wk_Px1 = wk_Qx
            wk_Px2 = wk_Px1 + 1
        ElseIf wk_Qx < 16 Then
            wk_Px1 = wk_Qx
            wk_Px2 = 128
            wk_BodyV = 8
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
            If pm_De < 0 Or pm_De > 14 Then
                Call AE_SystemError("AE_InOutModeN のパラメタ pm_De に", 554)
                Exit Sub
            End If
        End If
        If wk_Qx < 8 Then
            wk_Px = wk_Qx
        ElseIf wk_Qx < 16 Then
            'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
            If IsNothing(pm_De) Then
                If PP_SSSMAIN.De2 < 0 Or (Not PP_SSSMAIN.RecalcMode And PP_SSSMAIN.Tx >= 128) Then Exit Sub
                wk_Px = wk_Qx + 8 * PP_SSSMAIN.De
            Else
                'UPGRADE_WARNING: オブジェクト pm_De の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                wk_Px = wk_Qx + 8 * pm_De
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

    Function AE_IsClearedDe_SSSMAIN(ByVal pm_De As Short) As Boolean 'Generated.
        Dim wk_ww As Short
        Dim wk_PxBase As Short
        If pm_De < PP_SSSMAIN.LastReadDe Or pm_De > 14 Then
            AE_IsClearedDe_SSSMAIN = False : Exit Function
        End If
        wk_PxBase = 8 + 8 * pm_De
        wk_ww = 0
        Do While wk_ww < 8
            If RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).TpStr) <> RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).IniStr) And CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status6 Then
                AE_IsClearedDe_SSSMAIN = False : Exit Function
            ElseIf CP_SSSMAIN(wk_ww + wk_PxBase).StatusC = Cn_Status1 Then
                If RTrim(CP_SSSMAIN(wk_ww + wk_PxBase).TpStr) <> "" Then
                    AE_IsClearedDe_SSSMAIN = False : Exit Function
                End If
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            ElseIf Not AE_IsNullZero(PP_SSSMAIN, CP_SSSMAIN(wk_ww + wk_PxBase)) And (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status5 Or (CP_SSSMAIN(wk_ww + wk_PxBase).StatusC <= Cn_Status6 And Not IsDBNull(CP_SSSMAIN(wk_ww + wk_PxBase).CuVal))) Then
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
        If IsDBNull(Valu) Then
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
            '20190705 CHG START
            'Ct.Locked = False
            Ct.Enabled = True
            '20190705 CHG END
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
                '20190704 CHG START
                'wk_SS = Ct.SelStart
                wk_SS = DirectCast(Ct, TextBox).SelectionStart
                '20190704 CHG END
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
            '20190704 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '20190704 CHG END
                If CP_SSSMAIN(wk_Px).Alignment <> 1 Then '左詰め
                    wk_SS = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        If wk_Moji <> Space(1) And AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '20190704 CHG END
                            GoTo AE_KeyDownRightEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS - 1
                    Loop
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '20190704 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190705 CHG START
                    'Ct.SelStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).SelectionStart = Len(wk_Txt) - PP_SSSMAIN.Override
                    '20190704 CHG END
                End If
AE_KeyDownRightEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。


                '20190705 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '20190704 CHG EDN
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
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190704 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        ElseIf wk_Moji = Space(1) And AE_KeyInOkChar(PP_SSSMAIN, Mid(wk_Txt, wk_SS, 1), CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        ElseIf wk_Moji = Space(1) And Mid(wk_Txt, wk_SS, 1) <> Space(1) And CP_SSSMAIN(wk_Px).FixedFormat = 1 Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2190704 CHG START
                            'Ct.SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190704 CHG END
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
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS + 1
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS + 1, PP_SSSMAIN.Override)
                            '20190704 CHG END
                            GoTo AE_KeyDownRightEnd2_SSSMAIN
                        End If
                    Else
                        'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190704 CHG START
                        'Ct.SelStart = wk_Ln
                        ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'Ct.SelLength = PP_SSSMAIN.Override
                        DirectCast(Ct, TextBox).Select(wk_Ln, PP_SSSMAIN.Override)
                        '20190704 CHG END
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
            '20190704 CHG START
            'If Not (PP_SSSMAIN.Override = 1 And Ct.SelLength = 1) And PP_SSSMAIN.SelValid And Ct.SelLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
            If Not (PP_SSSMAIN.Override = 1 And DirectCast(Ct, TextBox).SelectionLength = 1) And PP_SSSMAIN.SelValid And DirectCast(Ct, TextBox).SelectionLength = Len(wk_Txt) And Len(wk_Txt) > 0 Then
                '20190704 CHG END
                If CP_SSSMAIN(wk_Px).Alignment = 1 Then '右詰め
                    wk_SS = 0
                    wk_Ln = Len(wk_Txt) - PP_SSSMAIN.Override
                    Do While wk_SS < wk_Ln
                        wk_Moji = Mid(wk_Txt, wk_SS + 1, 1)
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS
                            DirectCast(Ct, TextBox).SelectionStart = wk_SS
                            '20190704 CHG END
                            GoTo AE_KeyDownLeftEnd1_SSSMAIN
                        End If
                        wk_SS = wk_SS + 1
                    Loop
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'Ct.SelStart = wk_Ln
                    DirectCast(Ct, TextBox).SelectionStart = wk_Ln
                    '20190704 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'Ct.SelStart = 0
                    DirectCast(Ct, TextBox).SelectionStart = 0
                    '20190704 CHG END
                End If
AE_KeyDownLeftEnd1_SSSMAIN:
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190704 CHG START
                'Ct.SelLength = PP_SSSMAIN.Override
                DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
                '20190704 CHG END
            Else
                If wk_SS > 0 And wk_SS = Len(wk_Txt) Then
                    PP_SSSMAIN.Override = 1
                    'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'Ct.SelStart = wk_SS - 1
                    ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'Ct.SelLength = PP_SSSMAIN.Override
                    DirectCast(Ct, TextBox).Select(wk_SS - 1, PP_SSSMAIN.Override)
                ElseIf wk_SS = 0 Then
                    If PP_SSSMAIN.ArrowLimit = False And PP_SSSMAIN.AL = False Then PP_SSSMAIN.CursorDest = Cn_Dest7 : GoTo CheckOrSkip
                Else
                    Do While wk_SS > 0
                        wk_Moji = Mid(wk_Txt, wk_SS, 1)
                        wk_SS = wk_SS - 1
                        If AE_KeyInOkChar(PP_SSSMAIN, wk_Moji, CP_SSSMAIN(wk_Px).KeyInOkClass) Then
                            'UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190704 CHG START
                            'Ct.SelStart = wk_SS
                            ''UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'Ct.SelLength = PP_SSSMAIN.Override
                            DirectCast(Ct, TextBox).Select(wk_SS, PP_SSSMAIN.Override)
                            '20190704 CHG END
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
            If wk_Tx >= 8 And wk_Tx < 128 Then
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
                '20190705 CHG START
                'ElseIf Ct.SelLength = wk_Ln And wk_Ln > 1 Then 
            ElseIf DirectCast(Ct, TextBox).SelectionLength = wk_Ln And wk_Ln > 1 Then
                '20190705 CHG EDN
                wk_Txt = Space(CP_SSSMAIN(wk_Px).MaxLength)
                If CP_SSSMAIN(wk_Px).Alignment = 1 And (PP_SSSMAIN.SelValid Or CP_SSSMAIN(wk_Px).FixedFormat = 1) Then wk_SS = CP_SSSMAIN(wk_Px).MaxLength
            ElseIf CP_SSSMAIN(wk_Px).MaxLength = 0 Then
                wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2)
            ElseIf CP_SSSMAIN(wk_Px).Alignment <> 1 Then
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190705 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then
                    '20190705 CHG END
                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190705 CHG START
                    'wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + Ct.SelLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, Ct.SelLength))) 'V6.52
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + DirectCast(Ct, TextBox).SelectionLength + 1) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, DirectCast(Ct, TextBox).SelectionLength))) 'V6.52
                    '20190705 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Txt = Left(wk_Txt, wk_SS) & Mid(wk_Txt, wk_SS + 2) & Space(LenWid(Mid(Ct.ToString(), wk_SS + 1, 1)))
                End If
                If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    If IsDBNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
                        'UPGRADE_WARNING: オブジェクト AE_Val(CP_SSSMAIN(wk_Px), wk_Txt$, CP_SSSMAIN(wk_Px).FractionC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    ElseIf AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC) = 0 Then
                        wk_Txt = ""
                    End If
                End If
            Else
                wk_SS2 = wk_SS
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190705 CHG END
                'If Ct.SelLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                If DirectCast(Ct, TextBox).SelectionLength = 0 And CP_SSSMAIN(wk_Px).Alignment = 1 And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) And wk_SS > 0 Then wk_SS2 = wk_SS - 1
                '20190705 CHG END
                If Mid(wk_Txt, wk_SS2 + 1, 1) = "." And AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    wk_Ln2 = Len(Trim(AE_Format(CP_SSSMAIN(wk_Px), AE_Val(CP_SSSMAIN(wk_Px), Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2), wk_FractionC), wk_FractionC, True)))
                    If wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength Or wk_Ln2 > CP_SSSMAIN(wk_Px).MaxLength - 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Snum Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Schn) And InStr(wk_Txt, "-") = 0 Then
                        Beep()
                        Exit Function
                    End If
                End If
                'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '20190705 CHG START
                'If Ct.SelLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                If DirectCast(Ct, TextBox).SelectionLength > 1 And (CP_SSSMAIN(wk_Px).FormatClass = Cn_Memo Or CP_SSSMAIN(wk_Px).FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
                    '20190705 CHG END
                    'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190704 CHG START
                    'wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, Ct.SelLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + Ct.SelLength + 1) 'V6.52
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, DirectCast(Ct, TextBox).SelectionLength))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + DirectCast(Ct, TextBox).SelectionLength + 1) 'V6.52
                    '20190705 CHG END
                ElseIf Len(wk_Txt) >= wk_SS + 1 Then
                    'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    wk_Txt = Space(LenWid(Mid(Ct.ToString(), wk_SS2 + 1, 1))) & Left(wk_Txt, wk_SS2) & Mid(wk_Txt, wk_SS2 + 2)
                End If
                If AE_Numerical(CP_SSSMAIN(wk_Px).FormatClass) Then
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    If IsDBNull(AE_Val(CP_SSSMAIN(wk_Px), wk_Txt, CP_SSSMAIN(wk_Px).FractionC)) Then
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
            '20190704 CHG START
            'Ct = pm_TA
            ''UPGRADE_WARNING: オブジェクト Ct.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Ct.SelStart = wk_SS
            DirectCast(Ct, TextBox).Select(pm_TA, wk_SS)
            '20190704 CHG END
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
            '20190704 chg start
            'If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then Ct.SelStart = wk_Ln - 1
            If CP_SSSMAIN(wk_Px).Alignment <> 1 And PP_SSSMAIN.Override = 1 And wk_SS > 0 And wk_SS = wk_Ln Then DirectCast(Ct, TextBox).SelectionStart = wk_Ln - 1
            '20190704 chg end
            'UPGRADE_WARNING: オブジェクト Ct.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190705 CHG START
            'Ct.SelLength = PP_SSSMAIN.Override
            DirectCast(Ct, TextBox).SelectionLength = PP_SSSMAIN.Override
            '20190704 CHG END
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
        Call AE_InitValAll_SSSMAIN(True)
        'UPGRADE_WARNING: オブジェクト SSSMAIN_Last() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.LastDe = SSSMAIN_Last()
        If PP_SSSMAIN.LastDe = 0 Then
            If Not AE_MsgLibrary(PP_SSSMAIN, "LastCm") Then
                Call AE_InitValAll_SSSMAIN(True)
            Else
                Call AE_ScrlMax(PP_SSSMAIN)
                Call AE_RecalcAll2_SSSMAIN()
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
            End If
        Else
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll2_SSSMAIN()
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
                Call AE_InitValAll_SSSMAIN(True)
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
        wk_Px = 8 * pm_De + 8
        wk_Px2 = wk_Px + 8
        Do While wk_Px < wk_Px2
            If pm_SetReset Then
                CP_SSSMAIN(wk_Px).InOutMode = CP_SSSMAIN(wk_Px).InOutMode And &HFF5DS
            Else
                wk_InOutMode = (CP_SSSMAIN(wk_Px).InOutMode \ 256) And &HFFS
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
                    Call AE_TabStop_SSSMAIN(0, 127, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
                End If
            Case Cn_Mode2
                If PP_SSSMAIN.Mode <> Cn_Mode2 Then
                    PP_SSSMAIN.Mode = Cn_Mode2 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "選択"
                    Call AE_TabStop_SSSMAIN(0, 127, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = False
                End If
            Case Cn_Mode3
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    PP_SSSMAIN.Mode = Cn_Mode3 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "表示"
                    Call AE_TabStop_SSSMAIN(0, 127, False)
                    AE_CursorRest(PP_SSSMAIN.ScX).TabStop = True
                End If
            Case Cn_Mode4
                If PP_SSSMAIN.Mode <> Cn_Mode4 Then
                    PP_SSSMAIN.Mode = Cn_Mode4 : AE_ModeBar(PP_SSSMAIN.ScX).Text = "更新"
                    Call AE_TabStop_SSSMAIN(0, 127, False)
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
        Call AE_InitValAll_SSSMAIN(True)
        'UPGRADE_WARNING: オブジェクト SSSMAIN_Next() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.LastDe = SSSMAIN_Next()
        If PP_SSSMAIN.LastDe = 0 Then
            If Not AE_MsgLibrary(PP_SSSMAIN, "NextCm") Then
                If AE_Last_SSSMAIN(False) = Cn_CuInit Then AE_NextCm_SSSMAIN = Cn_CuInit : Exit Function
            Else
                Call AE_ScrlMax(PP_SSSMAIN)
                Call AE_RecalcAll2_SSSMAIN()
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
            End If
        Else
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll2_SSSMAIN()
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
        ElseIf IsDBNull(Valu) Then
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
        ElseIf IsDBNull(Valu) Then
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
        Call AE_InitValAll_SSSMAIN(True)
        'UPGRADE_WARNING: オブジェクト SSSMAIN_Prev() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        PP_SSSMAIN.LastDe = SSSMAIN_Prev()
        If PP_SSSMAIN.LastDe = 0 Then
            If Not AE_MsgLibrary(PP_SSSMAIN, "PrevCm") Then
                If AE_First_SSSMAIN(False) = Cn_CuInit Then AE_Prev_SSSMAIN = Cn_CuInit : Exit Function
            Else
                Call AE_ScrlMax(PP_SSSMAIN)
                Call AE_RecalcAll2_SSSMAIN()
                Call AE_Scrl_SSSMAIN(PP_SSSMAIN.DspTopDe, True)
            End If
        Else
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll2_SSSMAIN()
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

    Sub AE_RecalcAll2_SSSMAIN() 'Generated.
        PP_SSSMAIN.DerivedOrigin = ""
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
        Do While PP_SSSMAIN.De < PP_SSSMAIN.LastDe And PP_SSSMAIN.De <= 14
            If PP_SSSMAIN.De + 1 = PP_SSSMAIN.LastDe Or PP_SSSMAIN.De = 14 Then PP_SSSMAIN.SuppressMultiTlDerived = False
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
        wk_PxBase = 8 * PP_SSSMAIN.De
        PP_SSSMAIN.RecalcMode = True
        If PP_SSSMAIN.LastDe > 0 Then
            If AE_GetInOutMode(CP_SSSMAIN(8 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(8 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(8 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val2(CP_SSSMAIN(8 + wk_PxBase)), CP_SSSMAIN(8 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(9 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(9 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(9 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val2(CP_SSSMAIN(9 + wk_PxBase)), CP_SSSMAIN(9 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(10 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(10 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(10 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SMZZAISU(AE_Val2(CP_SSSMAIN(10 + wk_PxBase)), CP_SSSMAIN(10 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(11 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(11 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(11 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SMAINPSU(AE_Val2(CP_SSSMAIN(11 + wk_PxBase)), CP_SSSMAIN(11 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(12 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(12 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(12 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SMAOUTSU(AE_Val2(CP_SSSMAIN(12 + wk_PxBase)), CP_SSSMAIN(12 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(13 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(13 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(13 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_ZAISAISU(AE_Val2(CP_SSSMAIN(13 + wk_PxBase)), CP_SSSMAIN(13 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(14 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(14 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(14 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_SMAZAISU(AE_Val2(CP_SSSMAIN(14 + wk_PxBase)), CP_SSSMAIN(14 + wk_PxBase).StatusF, False, False)
            End If
            If AE_GetInOutMode(CP_SSSMAIN(15 + wk_PxBase).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(15 + wk_PxBase).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
                If CP_SSSMAIN(15 + wk_PxBase).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_RELZAISU(AE_Val2(CP_SSSMAIN(15 + wk_PxBase)), CP_SSSMAIN(15 + wk_PxBase).StatusF, False, False)
            End If
        End If
        PP_SSSMAIN.RecalcMode = False
    End Sub

    Sub AE_RecalcHd_SSSMAIN() 'Generated.
        PP_SSSMAIN.RecalcMode = True
        If AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(0).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(0).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_DSPYM(AE_Val2(CP_SSSMAIN(0)), CP_SSSMAIN(0).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(1).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(1).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_HINCD(AE_Val2(CP_SSSMAIN(1)), CP_SSSMAIN(1).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(2).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(2).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_HINNMA(AE_Val2(CP_SSSMAIN(2)), CP_SSSMAIN(2).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(3).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(3).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_HINNMB(AE_Val2(CP_SSSMAIN(3)), CP_SSSMAIN(3).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(4).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(4).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_IRISU(AE_Val2(CP_SSSMAIN(4)), CP_SSSMAIN(4).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(5).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(5).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_UNTNM(AE_Val2(CP_SSSMAIN(5)), CP_SSSMAIN(5).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(6).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(6).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPEID(AE_Val2(CP_SSSMAIN(6)), CP_SSSMAIN(6).StatusF, False, False)
        End If
        If AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode1) >= Cn_InOutMode2 Or AE_GetInOutMode(CP_SSSMAIN(7).InOutMode, Cn_Mode4) >= Cn_InOutMode2 Then
            If CP_SSSMAIN(7).StatusC >= Cn_Status2 Then Call AE_Check_SSSMAIN_OPENM(AE_Val2(CP_SSSMAIN(7)), CP_SSSMAIN(7).StatusF, False, False)
        End If
        PP_SSSMAIN.RecalcMode = False
    End Sub

    Sub AE_Scrl_SSSMAIN(ByVal pm_DeNo As Short, ByVal pm_SetFocusOk As Short) 'Generated.
        Dim wk_Displacement As Short
        Dim wk_ExTopDe As Short
        Dim wk_ExTx As Short
        Dim wk_NewTx As Short
        Dim wk_NewTx2 As Short
        Dim wk_ww As Short
        Dim wk_De As Short
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
            '20190705 CHG START
            'AE_ScrlBar(PP_SSSMAIN.ScX) = PP_SSSMAIN.TopDe
            AE_ScrlBar(PP_SSSMAIN.ScX).Value = PP_SSSMAIN.TopDe
            '20190705 CHG END
        End If
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_De = 0
        Do While wk_De <= PP_SSSMAIN.MaxDspC
            wk_NewPxBase = 8 + 8 * (wk_De + PP_SSSMAIN.TopDe) : wk_OutOfDe = False
            If wk_NewPxBase >= PP_SSSMAIN.EBodyPx Then wk_NewPxBase = 8 + 8 * (PP_SSSMAIN.MaxDe) : wk_OutOfDe = True
            wk_ExPxBase = 8 + 8 * (wk_De + wk_ExTopDe)
            If wk_ExPxBase >= PP_SSSMAIN.EBodyPx Then wk_ExPxBase = 8 + 8 * (PP_SSSMAIN.MaxDe)
            wk_TxBase = 8 + 8 * wk_De
            wk_ww = 0
            Do While wk_ww < 8
                PP_SSSMAIN.MaskFurigana = True
                If CP_SSSMAIN(wk_NewPxBase + wk_ww).TypeA = Cn_CheckBox Then
                    If Trim(CP_SSSMAIN(wk_NewPxBase + wk_ww).TpStr) <> "1" Or wk_OutOfDe Then
                        'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190705 CHG START
                        'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = "0"
                        DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = False
                        '20190705 CHG END
                    Else
                        'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '20190705 CHG START
                        'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = "1"
                        DirectCast(AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww), CheckBox).Checked = True
                        '20190705 CHG END
                    End If
                ElseIf wk_OutOfDe Then
                    'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190705 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = AE_Format(CP_SSSMAIN(wk_NewPxBase + wk_ww), System.DBNull.Value, 0, True)
                    AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww).Text = AE_Format(CP_SSSMAIN(wk_NewPxBase + wk_ww), System.DBNull.Value, 0, True)
                    '20190705 CHG END
                Else
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190705 CHG START
                    'AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww) = CP_SSSMAIN(wk_NewPxBase + wk_ww).TpStr
                    AE_Controls(PP_SSSMAIN.CtB + wk_TxBase + wk_ww).Text = CP_SSSMAIN(wk_NewPxBase + wk_ww).TpStr
                    '20190705 CHG END
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
            wk_De = wk_De + 1
        Loop
        PP_SSSMAIN.MaskMode = wk_SaveMask
        wk_LastDe = PP_SSSMAIN.LastDe
        If PP_SSSMAIN.LastDe > wk_LastDe And PP_SSSMAIN.Mode <> 1 Then
            Call AE_ScrlMax(PP_SSSMAIN)
            Call AE_RecalcAll_SSSMAIN()
        End If
        If wk_ExTx >= 0 And wk_ExTx < 8 Then Exit Sub
        If wk_ExTx >= PP_SSSMAIN.NrBodyTx Then Exit Sub
        If Not PP_SSSMAIN.UpDownFlag Then PP_SSSMAIN.ScrlFlag = True
        wk_NewTx = wk_ExTx - 8 * (PP_SSSMAIN.TopDe - wk_ExTopDe)
        If wk_ExTx < 0 Then
        ElseIf wk_NewTx < 8 Then
            wk_NewTx = 8 + (wk_ExTx - 8) Mod 8
        ElseIf wk_NewTx >= PP_SSSMAIN.NrBodyTx Then
            wk_NewTx = 8 + 8 * PP_SSSMAIN.MaxDspC + (wk_ExTx - 8) Mod 8
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
                    wk_NewTx2 = wk_NewTx2 + 8
                Loop
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                Do While wk_NewTx < 128
                    If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx)).TypeA, wk_NewTx) Then
                        If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx)
                        Exit Sub
                    End If
                    wk_NewTx = wk_NewTx + 1
                Loop
            End If
            wk_NewTx = 8
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            Do While wk_NewTx < 128 And PP_SSSMAIN.TopDe >= 0 And PP_SSSMAIN.TopDe < PP_SSSMAIN.MaxDe
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
                Do While wk_NewTx2 >= 8
                    If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(AE_Px(PP_SSSMAIN, wk_NewTx2)).TypeA, wk_NewTx2) Then
                        If pm_SetFocusOk Then Call AE_CursorMove_SSSMAIN(wk_NewTx2)
                        Exit Sub
                    End If
                    wk_NewTx2 = wk_NewTx2 - 8
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
            If pm_Init Then Call AE_InitValAll_SSSMAIN()
            If Not pm_Init Then Call AE_InitValAll_SSSMAIN(True)
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
        ElseIf PP_SSSMAIN.Tx < 8 Then
            Select Case PP_SSSMAIN.Px
                Case 0
                    Call AE_Check_SSSMAIN_DSPYM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 1
                    Call AE_Check_SSSMAIN_HINCD(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 2
                    Call AE_Check_SSSMAIN_HINNMA(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 3
                    Call AE_Check_SSSMAIN_HINNMB(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 4
                    Call AE_Check_SSSMAIN_IRISU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 5
                    Call AE_Check_SSSMAIN_UNTNM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 6
                    Call AE_Check_SSSMAIN_OPEID(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 7
                    Call AE_Check_SSSMAIN_OPENM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
            End Select
        ElseIf PP_SSSMAIN.Tx < 128 Then
            wk_PxBase = 8 * PP_SSSMAIN.De
            Select Case PP_SSSMAIN.Px
                Case 8 + wk_PxBase
                    Call AE_Check_SSSMAIN_SOUCD(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 9 + wk_PxBase
                    Call AE_Check_SSSMAIN_SOUNM(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 10 + wk_PxBase
                    Call AE_Check_SSSMAIN_SMZZAISU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 11 + wk_PxBase
                    Call AE_Check_SSSMAIN_SMAINPSU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 12 + wk_PxBase
                    Call AE_Check_SSSMAIN_SMAOUTSU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 13 + wk_PxBase
                    Call AE_Check_SSSMAIN_ZAISAISU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 14 + wk_PxBase
                    Call AE_Check_SSSMAIN_SMAZAISU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
                Case 15 + wk_PxBase
                    Call AE_Check_SSSMAIN_RELZAISU(CC_NewVal, pm_Status, False, pm_HandIn)
                    If AE_ErrorToInteger(Ck_Error) = 0 Then
                    End If
            End Select
        End If
    End Sub

    Sub AE_Slist_SSSMAIN() 'Generated.
        Dim wk_Slisted As Object
        Dim wk_PxBase As Short
        Dim wk_TxBase As Short
        wk_PxBase = 8 * PP_SSSMAIN.De
        wk_TxBase = 8 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
        If False Then
        ElseIf PP_SSSMAIN.Tx = 1 Then
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.NeglectLostFocusCheck = True
            'UPGRADE_WARNING: オブジェクト HINCD_Slist() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            wk_Slisted = HINCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
            PP_SSSMAIN.NeglectLostFocusCheck = False
            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If IsNothing(wk_Slisted) Then wk_Slisted = System.DBNull.Value
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
            If Not IsDBNull(wk_Slisted) Then
                PP_SSSMAIN.CursorDest = Cn_Dest9
                PP_SSSMAIN.SlistPx = -1
                PP_SSSMAIN.JustAfterSList = True
                'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                PP_SSSMAIN.SlistCom = System.DBNull.Value
                If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                    'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    CP_SSSMAIN(1).TpStr = wk_Slisted
                    CP_SSSMAIN(1).CIn = Cn_ChrInput
                    'UPGRADE_WARNING: オブジェクト wk_Slisted の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト AE_Controls(PP_SSSMAIN.CtB + 1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    DirectCast(AE_Controls(PP_SSSMAIN.CtB + 1), TextBox).Text = wk_Slisted
                    '20190705 CHG START
                    'Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(1), AE_Controls(PP_SSSMAIN.CtB + 1).ToString()), Cn_Status6, True, True)
                    Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(1), AE_Controls(PP_SSSMAIN.CtB + 1).Text), Cn_Status6, True, True)
                    '20190705 CHG END
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
            If wk_Tx >= PP_SSSMAIN.NrBodyTx And wk_Tx < 128 Then
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
            'UPGRADE_WARNING: オブジェクト AE_StatusCodeBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            AE_StatusCodeBar(PP_SSSMAIN.ScX).Text = ""
            'UPGRADE_WARNING: オブジェクト AE_StatusBar(PP_SSSMAIN.ScX).Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            AE_StatusBar(PP_SSSMAIN.ScX).Text = ""
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
        For wk_Tx = 0 To PP_SSSMAIN.ControlsC - 1
            '20190705 DELL START
            ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
            'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_Controls(PP_SSSMAIN.CtB + wk_Tx).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
            '20190705 DELL END
        Next wk_Tx
        '20190705 DELL START
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_StatusBar(PP_SSSMAIN.ScX).Text.Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        ''UPGRADE_WARNING: AddressOf AE_WindowProc_SSSMAIN の delegate を追加する 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"' をクリックしてください。
        'PP_SSSMAIN.lpPrevWndProc = SetWindowLong(AE_ModeBar(PP_SSSMAIN.ScX).Handle.ToInt32, GWL_WNDPROC, AddressOf AE_WindowProc_SSSMAIN)
        '20190705 DELL END
    End Sub

    Sub DP_SSSMAIN_RELZAISU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(15 + wk_PxBase), AE_Val3(CP_SSSMAIN(15 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(15 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(15 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(15 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SMAINPSU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(11 + wk_PxBase), AE_Val3(CP_SSSMAIN(11 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(11 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(11 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(11 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SMAOUTSU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(12 + wk_PxBase), AE_Val3(CP_SSSMAIN(12 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(12 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(12 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(12 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SMAZAISU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(14 + wk_PxBase), AE_Val3(CP_SSSMAIN(14 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(14 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(14 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(14 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SMZZAISU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(10 + wk_PxBase), AE_Val3(CP_SSSMAIN(10 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(10 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(10 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(10 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SOUCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(8 + wk_PxBase), AE_Val3(CP_SSSMAIN(8 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(8 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(8 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(8 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_SOUNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(9 + wk_PxBase), AE_Val3(CP_SSSMAIN(9 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(9 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(9 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(9 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_ZAISAISU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
        Dim V As Object
        Dim wk_SaveMask As Boolean
        Dim wk_PxBase As Short
        wk_SaveMask = PP_SSSMAIN.MaskMode
        PP_SSSMAIN.MaskMode = True
        wk_PxBase = 8 * pm_De
        'UPGRADE_WARNING: オブジェクト DBItem の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AE_NormData() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        V = AE_NormData(CP_SSSMAIN(13 + wk_PxBase), AE_Val3(CP_SSSMAIN(13 + wk_PxBase), CStr(DBItem)))
        'UPGRADE_WARNING: オブジェクト V の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト CP_SSSMAIN(13 + wk_PxBase).CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CP_SSSMAIN(13 + wk_PxBase).CuVal <> V Or CP_SSSMAIN(13 + wk_PxBase).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_DSPYM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        ElseIf (IsDBNull(CP_SSSMAIN(0).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(0).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_HINCD(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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

    Sub DP_SSSMAIN_HINNMA(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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

    Sub DP_SSSMAIN_HINNMB(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        '20190709 CHG START
        'If  CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
        If IsDBNull(CP_SSSMAIN(3).CuVal) = False _
           AndAlso IsDBNull(V) = False _
           AndAlso CP_SSSMAIN(3).CuVal <> V Or CP_SSSMAIN(3).StatusC <> Cn_Status8 Then
            '20190709 CHG END
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

    Sub DP_SSSMAIN_IRISU(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        If IsDBNull(CP_SSSMAIN(4).CuVal) = False _
           AndAlso IsDBNull(V) = False _
           AndAlso CP_SSSMAIN(4).CuVal <> V Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(4).StatusC = Cn_Status6 : CP_SSSMAIN(4).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(4).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(4).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_OPEID(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        If IsDBNull(CP_SSSMAIN(6).CuVal) = False _
           AndAlso IsDBNull(V) = False _
           AndAlso CP_SSSMAIN(6).CuVal <> V Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(6).StatusC = Cn_Status6 : CP_SSSMAIN(6).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(6).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(6).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_OPENM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        If IsDBNull(CP_SSSMAIN(7).CuVal) = False _
           AndAlso IsDBNull(V) = False _
            AndAlso CP_SSSMAIN(7).CuVal <> V Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(7).StatusC = Cn_Status6 : CP_SSSMAIN(7).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(7).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(7).StatusC <> Cn_Status8 Then
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

    Sub DP_SSSMAIN_UNTNM(ByVal pm_De As Short, ByRef DBItem As Object) 'Generated.
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
        If IsDBNull(CP_SSSMAIN(5).CuVal) = False _
           AndAlso IsDBNull(V) = False _
           AndAlso CP_SSSMAIN(5).CuVal <> V Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
            CP_SSSMAIN(5).StatusC = Cn_Status6 : CP_SSSMAIN(5).StatusF = Cn_Status6
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf (IsDBNull(CP_SSSMAIN(5).CuVal) Xor IsDBNull(V)) Or CP_SSSMAIN(5).StatusC <> Cn_Status8 Then
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

    Function RD_SSSMAIN_RELZAISU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(15 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_RELZAISU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(15 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_RELZAISU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_RELZAISU = CP_SSSMAIN(15 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_SMAINPSU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(11 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAINPSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAINPSU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(11 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAINPSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAINPSU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAINPSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAINPSU = CP_SSSMAIN(11 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_SMAOUTSU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(12 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAOUTSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAOUTSU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(12 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAOUTSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAOUTSU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAOUTSU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAOUTSU = CP_SSSMAIN(12 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_SMAZAISU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(14 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAZAISU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(14 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAZAISU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMAZAISU = CP_SSSMAIN(14 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_SMZZAISU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(10 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMZZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMZZAISU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(10 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMZZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMZZAISU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMZZAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_SMZZAISU = CP_SSSMAIN(10 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_SOUCD(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(8 + wk_PxBase).CuVal) Then
            RD_SSSMAIN_SOUCD = Space(3)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 3 Then
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_SOUCD = Space(3 - LenWid(st_Work)) & CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal)
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_SOUCD = CStr(CP_SSSMAIN(8 + wk_PxBase).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_SOUNM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(9 + wk_PxBase).CuVal) Then
            RD_SSSMAIN_SOUNM = Space(20)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 20 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_SOUNM = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal) & Space(20 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_SOUNM = CStr(CP_SSSMAIN(9 + wk_PxBase).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_ZAISAISU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        Dim wk_PxBase As Short
        wk_PxBase = 8 * De
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(13 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAISAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_ZAISAISU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(13 + wk_PxBase).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAISAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_ZAISAISU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAISAISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_ZAISAISU = CP_SSSMAIN(13 + wk_PxBase).CuVal
        End If
    End Function

    Function RD_SSSMAIN_DSPYM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(0).CuVal) Then
            RD_SSSMAIN_DSPYM = Space(8)
        ElseIf Not IsDate(CP_SSSMAIN(0).CuVal) Then
            RD_SSSMAIN_DSPYM = Space(8)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_DSPYM = VB6.Format(CP_SSSMAIN(0).CuVal, "YYYYMMDD")
        End If
    End Function

    Function RD_SSSMAIN_HINCD(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(1).CuVal) Then
            RD_SSSMAIN_HINCD = Space(8)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(1).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 8 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINCD = CStr(CP_SSSMAIN(1).CuVal) & Space(8 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINCD = CStr(CP_SSSMAIN(1).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_HINNMA(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(2).CuVal) Then
            RD_SSSMAIN_HINNMA = Space(30)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(2).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 30 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINNMA = CStr(CP_SSSMAIN(2).CuVal) & Space(30 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINNMA = CStr(CP_SSSMAIN(2).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_HINNMB(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(3).CuVal) Then
            RD_SSSMAIN_HINNMB = Space(30)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(3).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 30 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINNMB = CStr(CP_SSSMAIN(3).CuVal) & Space(30 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_HINNMB = CStr(CP_SSSMAIN(3).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_IRISU(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        If IsNothing(CP_SSSMAIN(4).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_IRISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_IRISU = 0@
            'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        ElseIf IsDBNull(CP_SSSMAIN(4).CuVal) Then
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_IRISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_IRISU = 0@
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_IRISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            RD_SSSMAIN_IRISU = CP_SSSMAIN(4).CuVal
        End If
    End Function

    Function RD_SSSMAIN_OPEID(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(6).CuVal) Then
            RD_SSSMAIN_OPEID = Space(6)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(6).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 6 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(6).CuVal) & Space(6 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPEID = CStr(CP_SSSMAIN(6).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_OPENM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(7).CuVal) Then
            RD_SSSMAIN_OPENM = Space(20)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(7).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 20 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(7).CuVal) & Space(20 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_OPENM = CStr(CP_SSSMAIN(7).CuVal)
            End If
        End If
    End Function

    Function RD_SSSMAIN_UNTNM(ByVal De As Short) As Object 'Generated.
        Dim st_Work As String
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(CP_SSSMAIN(5).CuVal) Then
            RD_SSSMAIN_UNTNM = Space(9)
        Else
            'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            st_Work = CStr(CP_SSSMAIN(5).CuVal)
            'UPGRADE_WARNING: オブジェクト LenWid(st_Work$) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If LenWid(st_Work) < 9 Then
                'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_UNTNM = CStr(CP_SSSMAIN(5).CuVal) & Space(9 - LenWid(st_Work))
            Else
                'UPGRADE_WARNING: オブジェクト CP_SSSMAIN().CuVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                RD_SSSMAIN_UNTNM = CStr(CP_SSSMAIN(5).CuVal)
            End If
        End If
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SYSTBA_SEARCH
    '   概要：  ユーザー情報管理テーブル検索
    '   引数：  pot_DB_SYSTBA   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SYSTBA_SEARCH(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            SYSTBA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from SYSTBA "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                SYSTBA_SEARCH = 1
                Exit Function
            End If

            With pot_DB_SYSTBA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRID = DB_NullReplace(dt.Rows(0)("USRID"), "") 'ユーザーID
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNMA = DB_NullReplace(dt.Rows(0)("USRNMA"), "") 'ユーザー名1(漢字)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNMB = DB_NullReplace(dt.Rows(0)("USRNMB"), "") 'ユーザー名2(漢字)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRRN = DB_NullReplace(dt.Rows(0)("USRRN"), "") 'ユーザー略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNK = DB_NullReplace(dt.Rows(0)("USRNK"), "") 'ユーザー名称(カナ)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRZP = DB_NullReplace(dt.Rows(0)("USRZP"), "") 'ユーザー郵便番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADA = DB_NullReplace(dt.Rows(0)("USRADA"), "") 'ユーザー住所1
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADB = DB_NullReplace(dt.Rows(0)("USRADB"), "") 'ユーザー住所2
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADC = DB_NullReplace(dt.Rows(0)("USRADC"), "") 'ユーザー住所3
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRTL = DB_NullReplace(dt.Rows(0)("USRTL"), "") 'ユーザー電話番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRFX = DB_NullReplace(dt.Rows(0)("USRFX"), "") 'ユーザーFAX番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRBOSNM = DB_NullReplace(dt.Rows(0)("USRBOSNM"), "") 'ユーザー代表者名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRTANNM = DB_NullReplace(dt.Rows(0)("USRTANNM"), "") 'ユーザー担当者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAMM = DB_NullReplace(dt.Rows(0)("SMAMM"), "") '決算月
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMADD = DB_NullReplace(dt.Rows(0)("SMADD"), "") '決算日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAMONDD = DB_NullReplace(dt.Rows(0)("SMAMONDD"), "") '月次決算日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMEDD = DB_NullReplace(dt.Rows(0)("SMEDD"), "") '締め日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KESCC = DB_NullReplace(dt.Rows(0)("KESCC"), "") '回収支払月
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KESDD = DB_NullReplace(dt.Rows(0)("KESDD"), "") '回収支払日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "") '伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RECNO = DB_NullReplace(dt.Rows(0)("RECNO"), "") 'レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTDATNO = DB_NullReplace(dt.Rows(0)("STTDATNO"), "") '開始伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDDATNO = DB_NullReplace(dt.Rows(0)("ENDDATNO"), "") '終了伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTRECNO = DB_NullReplace(dt.Rows(0)("STTRECNO"), "") '開始レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDRECNO = DB_NullReplace(dt.Rows(0)("ENDRECNO"), "") '終了レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GYMSTTDT = DB_NullReplace(dt.Rows(0)("GYMSTTDT"), "") '業務開始日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSSAKB = DB_NullReplace(dt.Rows(0)("TOKSSAKB"), "") '得意先請求締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSMAKB = DB_NullReplace(dt.Rows(0)("TOKSMAKB"), "") '得意先経理締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIRSSAKB = DB_NullReplace(dt.Rows(0)("SIRSSAKB"), "") '仕入先支払締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIRSMAKB = DB_NullReplace(dt.Rows(0)("SIRSMAKB"), "") '仕入先経理締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAUPDDT = DB_NullReplace(dt.Rows(0)("SMAUPDDT"), "") '前回経理締実行日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UKSMEDT = DB_NullReplace(dt.Rows(0)("UKSMEDT"), "") '月次仮締日（売り）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SKSMEDT = DB_NullReplace(dt.Rows(0)("SKSMEDT"), "") '月次仮締日（仕入）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MINSPCCP = DB_NullReplace(dt.Rows(0)("MINSPCCP"), "") '最低空き容量(Ｍ)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MONUPDSC = DB_NullReplace(dt.Rows(0)("MONUPDSC"), "") 'トラン保存期間(月)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YERUPDSC = DB_NullReplace(dt.Rows(0)("YERUPDSC"), "") 'サマリ保存期間(月)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MONUPDDT = DB_NullReplace(dt.Rows(0)("MONUPDDT"), "") '前回月次更新実行日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YERUPDDT = DB_NullReplace(dt.Rows(0)("YERUPDDT"), "") '前回年次更新実行日
                '和暦採用区分
                'For intCnt = 0 To 1
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGKB(intCnt) = DB_NullReplace(dt.Rows(0)("NEGKB") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGKB00 = DB_NullReplace(dt.Rows(0)("NEGKB00"), "")
                .NEGKB01 = DB_NullReplace(dt.Rows(0)("NEGKB01"), "")

                '元年(西暦)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGDT(intCnt) = DB_NullReplace(dt.Rows(0)("NEGDT") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGDT00 = DB_NullReplace(dt.Rows(0)("NEGDT00"), "")
                .NEGDT01 = DB_NullReplace(dt.Rows(0)("NEGDT01"), "")
                .NEGDT02 = DB_NullReplace(dt.Rows(0)("NEGDT02"), "")
                .NEGDT03 = DB_NullReplace(dt.Rows(0)("NEGDT03"), "")
                .NEGDT04 = DB_NullReplace(dt.Rows(0)("NEGDT04"), "")

                '元号(年)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGYY(intCnt) = DB_NullReplace(dt.Rows(0)("NEGYY") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGYY00 = DB_NullReplace(dt.Rows(0)("NEGYY00"), "")
                .NEGYY01 = DB_NullReplace(dt.Rows(0)("NEGYY01"), "")
                .NEGYY02 = DB_NullReplace(dt.Rows(0)("NEGYY02"), "")
                .NEGYY03 = DB_NullReplace(dt.Rows(0)("NEGYY03"), "")
                .NEGYY04 = DB_NullReplace(dt.Rows(0)("NEGYY04"), "")

                '元号
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGNM(intCnt) = DB_NullReplace(dt.Rows(0)("NEGNM") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGNM00 = DB_NullReplace(dt.Rows(0)("NEGNM00"), "")
                .NEGNM01 = DB_NullReplace(dt.Rows(0)("NEGNM01"), "")
                .NEGNM02 = DB_NullReplace(dt.Rows(0)("NEGNM02"), "")
                .NEGNM03 = DB_NullReplace(dt.Rows(0)("NEGNM03"), "")
                .NEGNM04 = DB_NullReplace(dt.Rows(0)("NEGNM04"), "")

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .VERNO = DB_NullReplace(dt.Rows(0)("VERNO"), "") 'VERNO
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .LEVNO = DB_NullReplace(dt.Rows(0)("LEVNO"), "") 'LEBEL NO
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZAIHYKKB = DB_NullReplace(dt.Rows(0)("ZAIHYKKB"), "") '在庫評価方法
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GNKHYKKB = DB_NullReplace(dt.Rows(0)("GNKHYKKB"), "") '原価評価方法-粗利用
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HYKSTTDT = DB_NullReplace(dt.Rows(0)("HYKSTTDT"), "") '評価計算開始日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日付)
            End With

            SYSTBA_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    Sub Set_DB_MEIMTA(ByRef pDT As DataTable, ByRef pDB_MEIMTA As TYPE_DB_MEIMTA, ByVal DataCount As Integer)

        With pDB_MEIMTA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(pDT.Rows(DataCount)("DATKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .KEYCD = DB_NullReplace(pDT.Rows(DataCount)("KEYCD"), "") 'キー
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKMKNM = DB_NullReplace(pDT.Rows(DataCount)("MEIKMKNM"), "") '項目名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEICDA = DB_NullReplace(pDT.Rows(DataCount)("MEICDA"), "") 'コード１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEICDB = DB_NullReplace(pDT.Rows(DataCount)("MEICDB"), "") 'コード２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMA = DB_NullReplace(pDT.Rows(DataCount)("MEINMA"), "") '名称１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMB = DB_NullReplace(pDT.Rows(DataCount)("MEINMB"), "") '名称２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMC = DB_NullReplace(pDT.Rows(DataCount)("MEINMC"), "") '名称３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUA = DB_NullReplace(pDT.Rows(DataCount)("MEISUA"), 0) '数値項目１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUB = DB_NullReplace(pDT.Rows(DataCount)("MEISUB"), 0) '数値項目２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUC = DB_NullReplace(pDT.Rows(DataCount)("MEISUC"), 0) '数値項目３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBA = DB_NullReplace(pDT.Rows(DataCount)("MEIKBA"), "") '区分１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBB = DB_NullReplace(pDT.Rows(DataCount)("MEIKBB"), "") '区分２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBC = DB_NullReplace(pDT.Rows(DataCount)("MEIKBC"), "") '区分３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DSPORD = DB_NullReplace(pDT.Rows(DataCount)("DSPORD"), "") '表示順序
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(pDT.Rows(DataCount)("RELFL"), "") '連携フラグ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FOPEID = DB_NullReplace(pDT.Rows(DataCount)("FOPEID"), "") '初回登録担当者ID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FCLTID = DB_NullReplace(pDT.Rows(DataCount)("FCLTID"), "") '初回登録クライアントID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(pDT.Rows(DataCount)("OPEID"), "") '更新担当者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(pDT.Rows(DataCount)("CLTID"), "") '更新クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UOPEID = DB_NullReplace(pDT.Rows(DataCount)("UOPEID"), "") 'バッチ更新担当者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UCLTID = DB_NullReplace(pDT.Rows(DataCount)("UCLTID"), "") 'バッチ更新クライアントID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTTM = DB_NullReplace(pDT.Rows(DataCount)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTDT = DB_NullReplace(pDT.Rows(DataCount)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PGID = DB_NullReplace(pDT.Rows(DataCount)("PGID"), "") 'ﾌﾟﾛｸﾞﾗﾑID
            ' === 20061227 === UPDATE E -
        End With

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIM_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEICDA : コード１
    '           pot_DB_MEIMTA : 検索結果
    '           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEICDB As Object = Nothing) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPMEIM_SEARCH

        DSPMEIM_SEARCH = 9

        strSQL = ""
        '20190618 DEL START
        'strSQL = strSQL & " Select * "
        'strSQL = strSQL & "   from MEIMTA "
        '20190618 DEL START

        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pin_strMEICDB) = False Then
            'UPGRADE_WARNING: オブジェクト pin_strMEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If

        Call GetRowsCommon("MEIMTA", strSQL)

        ''DBアクセス
        ''2019/03/14 CHG START
        ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        'Dim dt As DataTable = DB_GetTable(strSQL)
        ''2019/03/14 CHG E N D

        ''2019/03/14 CHG START
        ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        '    '2019/03/14 CHG E N D
        '    '取得データなし
        '    DSPMEIM_SEARCH = 1
        '    GoTo END_DSPMEIM_SEARCH
        'End If

        '取得データ退避
        ' === 20060920 === UPDATE S - ACE)Sejima
        'D        With pot_DB_MEIMTA
        'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
        'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
        'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
        'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
        'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
        'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
        'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
        'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
        'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
        'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
        'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
        'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
        'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
        'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
        'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
        'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
        'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
        'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
        'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
        'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
        'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
        'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
        'D        End With
        ' === 20060920 === UPDATE ↓
        '2019/03/14 CHG START
        'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
        ''Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
        'Call SetDataCommon("MEIMTA", dt)
        '2019/03/14 CHG E N D
        ' === 20060920 === UPDATE E

        DSPMEIM_SEARCH = 0

END_DSPMEIM_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEIM_SEARCH:

    End Function

    '//**************************************************************************************
    '//*
    '//* <名  称>
    '//*    CF_Ora_CloseDyn
    '//*
    '//* <戻り値>     型          説明
    '//*             Boolean     True ...解放成功
    '//*                         False...解放失敗
    '//* <引  数>     項目名             型              I/O           内容
    '//*              pm_Ody             U_Ody           I/O           ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ（ﾕｰｻﾞｰ定義）
    '//* <説  明>
    '//*    引数の構造体をｸﾛｰｽﾞ及び解放します。
    '//*
    '//**************************************************************************************
    '//*変更履歴
    '//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |新規作成
    '//**************************************************************************************
    Public Function CF_Ora_CloseDyn(ByRef pm_Ody As U_Ody) As Boolean

        On Error GoTo ERR_HANDLE

        CF_Ora_CloseDyn = False

        If (pm_Ody.Obj_Ody Is Nothing) = False Then
            Erase pm_Ody.Obj_Flds
            'UPGRADE_NOTE: オブジェクト pm_Ody.Obj_Ody をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            pm_Ody.Obj_Ody = Nothing
        End If

        CF_Ora_CloseDyn = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:
        GoTo EXIT_HANDLE

    End Function
    '20190705 ADD START

End Module