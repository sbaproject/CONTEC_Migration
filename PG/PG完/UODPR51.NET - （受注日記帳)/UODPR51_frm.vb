Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
    '*** End Of Generated Declaration Section ****

    '2019/03/27 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/03/27 ADD END

    '2019.03.22 DEL START
    'Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "���j���[�ɖ߂�܂��B"
    '   End Sub
    '2019.03.22 DEL END

    Private Sub CM_FSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        '2019.04.10 del start
        'IM_Denkyu(0).Image = IM_Denkyu(2).Image
        '2019.04.10 del end
        '2019.03.29 DEL START
        'TX_Message.Text = "�t�@�C���ɏo�͂��܂��B"
        '2019.03.29 DEL END
    End Sub

    '2019.03.22 DEL START
    'Private Sub CM_LCONFIG_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "�v�����^�[��I�����܂��B"
    'End Sub
    '2019.03.22 DEL END
    Private Sub CM_LSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        '2019.04.10 del start
        'IM_Denkyu(0).Image = IM_Denkyu(2).Image
        '2019.04.10 del end
        '2019.03.29 DEL START
        'TX_Message.Text = "������J�n���܂��B"
        '2019.03.29 DEL END
    End Sub
    '2019.03.22 DEL START
    'Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
    '	IM_Denkyu(0).Image = IM_Denkyu(2).Image
    '	TX_Message.Text = "�E�B���h�E��\�����܂��B"
    'End Sub
    '2019.03.22 DEL END
    Private Sub CM_VSTART_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        '2019.04.10 del start
        'IM_Denkyu(0).Image = IM_Denkyu(2).Image
        '2019.04.10 del end
        '2019.03.29 DEL START
        'TX_Message.Text = "����C���[�W��\�����܂��B"
        '2019.03.29 DEL END
    End Sub

    '2019.03.22 DEL START
    'Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.NeglectLostFocusCheck = True
    '	PP_SSSMAIN.CloseCode = 1
    '	Call AE_EndCm_SSSMAIN()
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_ENDCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_ENDCM.Image = IM_ENDCM(1).Image
    'End Sub

    'Private Sub CM_ENDCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_ENDCM.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_ENDCM.Image = IM_ENDCM(0).Image
    'End Sub


    'Private Sub CM_FSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.NeglectLostFocusCheck = True
    '    If FSTART_GetEvent() Then
    '    End If
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_FSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_FSTART.Image = IM_FSTART(1).Image
    'End Sub

    'Private Sub CM_FSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_FSTART.Image = IM_FSTART(0).Image
    'End Sub
    '2019.03.22 DEL END
    Private Sub CM_LCANCEL_Click() 'Generated.
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        PP_SSSMAIN.NeglectLostFocusCheck = True
        'UPGRADE_WARNING: �I�u�W�F�N�g LCANCEL_GetEvent() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LCANCEL_GetEvent() Then
        End If
        PP_SSSMAIN.NeglectLostFocusCheck = False
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub CM_LCANCEL_GotFocus() 'Generated.
        PP_SSSMAIN.ButtonClick = False
    End Sub

    Private Sub CM_LCANCEL_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short) 'Generated.
        If PP_SSSMAIN.ButtonClick = False Then
            If KeyCode = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
        End If
    End Sub

    Private Sub CM_LCANCEL_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub
    '2019.03.22 DEL START
    'Private Sub CM_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_LCONFIG.Click 'Generated.
    '	PP_SSSMAIN.ButtonClick = True
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.NeglectLostFocusCheck = True
    '	If LCONFIG_GetEvent() Then
    '	End If
    '	PP_SSSMAIN.NeglectLostFocusCheck = False
    '	Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_LCONFIG_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(1).Image
    'End Sub

    'Private Sub CM_LCONFIG_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_LCONFIG.Image = IM_LCONFIG(0).Image
    'End Sub

    'Private Sub CM_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.NeglectLostFocusCheck = True
    '    If LSTART_GetEvent() Then
    '    End If
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_LSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_LSTART.Image = IM_LSTART(1).Image
    'End Sub

    'Private Sub CM_LSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_LSTART.Image = IM_LSTART(0).Image
    'End Sub

    'Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click 'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
    '    Call AE_Slist_SSSMAIN()
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
    'End Sub
    'Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Slist.Image = IM_SLIST(1).Image
    'End Sub

    'Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '	If PP_SSSMAIN.Operable Then CM_Slist.Image = IM_SLIST(0).Image
    'End Sub

    'Private Sub CM_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
    '    PP_SSSMAIN.ButtonClick = True
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.NeglectLostFocusCheck = True
    '    If VSTART_GetEvent() Then
    '    End If
    '    PP_SSSMAIN.NeglectLostFocusCheck = False
    '    Call AE_CursorCurrent_SSSMAIN()
    'End Sub

    'Private Sub CM_VSTART_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_VSTART.Image = IM_VSTART(1).Image
    'End Sub

    'Private Sub CM_VSTART_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
    '    If PP_SSSMAIN.Operable Then CM_VSTART.Image = IM_VSTART(0).Image
    'End Sub
    '2019.03.22 DEL END	
    Private Sub CS_STTTOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        Dim wk_Slisted As Object
        Dim wk_SaveTx As Short
        PP_SSSMAIN.ButtonClick = True
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(10).TypeA, 10) Then
            PP_SSSMAIN.SlistCall = True
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            Call AE_CursorMove_SSSMAIN(10)
        Else
            Beep()
            Call AE_CursorCurrent_SSSMAIN()
        End If
        PP_SSSMAIN.CursorDirection = 0
    End Sub

    Private Sub CS_STTTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        PP_SSSMAIN.ButtonClick = False
    End Sub

    Private Sub CS_STTTOKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If PP_SSSMAIN.ButtonClick = False Then
            If KeyCode = System.Windows.Forms.Keys.Select Then Call AE_CursorCurrent_SSSMAIN()
        End If
    End Sub

    Private Sub FM_PANEL3D1_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub FM_PANEL3D14_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub FM_PANEL3D15_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub FM_PANEL3D2_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) 'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    'UPGRADE_WARNING: Form �C�x���g FR_SSSMAIN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub FR_SSSMAIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated 'Generated.
        Dim wk_ww As Short
        Dim wk_De As Short
        Dim wk_xx As Short
        If PP_SSSMAIN.Activated = 0 Then
            PP_SSSMAIN.Activated = 1
        End If
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load 'Generated.
        Dim wk_De As Short
        Dim wk_ww As Short
        Dim wk_Tx As Short
        Dim wk_TxBase As Short
        Dim wk_HeadN As Short
        Dim wk_BodyN As Short
        Dim wk_EBodyN As Short
        Dim wk_TailN As Short
        Dim wk_Top As Single
        Dim wk_Height As Single
        Dim wk_Px As Short
        Dim wk_PxBase As Short
        Dim wk_SmrBuf As String
        Dim PY_TTop As Single
        '2019.04.02 ADD START
        Dim Index_Wk As Short = 0
        '2019.04.02 ADD END 

        AE_Title = "�󒍓��L��                         "
        '����ʕ\���̐��\�`���[�j���O�p ----------
        'Dim StartTime
        '   AE_MsgBox "Start Point", vbInformation, AE_Title$
        '   StartTime = Timer
        '-----------------------------------------
        With PP_SSSMAIN
            .FormWidth = 9375
            .FormHeight = 6195
            .MaxDe = -1
            .MaxDsp = -1
            .HeadN = 13
            .BodyN = 0
            .BodyV = 0
            .MaxEDe = -1
            .MaxEDsp = -1
            .EBodyN = 0
            .EBodyV = 0
            .TailN = 0
            .BodyPx = 13
            .EBodyPx = 13
            .TailPx = 13
            .PrpC = 13
            .Operable = False
            .BrightOnOff = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON)
            .SuppressVSScroll = 0
            .UniScrl = False
            .SetCursorRR = True
            .SetCursorLF = False
            .VisibleForItem = False
            .AllowNullDes = False
            .No2Scroll = False
            .SpecSubID = "sss"
            .UnDoDeOp = 0
            .ActiveBlockNo = -1
            .MaxBlockNo = 1
            If .MainForm = "" Then
                .ScX = AE_ScX
                AE_ScX = AE_ScX + 1
                ReDim Preserve AE_Timer(.ScX)
                ReDim Preserve AE_CursorRest(.ScX)
                ReDim Preserve AE_ModeBar(.ScX)
                ReDim Preserve AE_StatusBar(.ScX)
                ReDim Preserve AE_StatusCodeBar(.ScX)
                .CtB = AE_CtB
                AE_CtB = AE_CtB + 13
                ReDim Preserve AE_Controls(.CtB + 12)
                .MainFormFile = "UODPR51.FRM"
                .MainFormObj = "FR_SSSMAIN"
                .SelValid = False
                .ArrowLimit = False
                .NullZero = True
                .ErrorByBackColor = False
                AE_SSSWin = True
                .AL = False
            End If
            If AE_FormInit(PP_SSSMAIN, Me, AE_Title, Cn_ClIncomplete, System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClCheckError), System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClRelCheck), System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClChecked)) <> "V6.60" Then
#If ActiveXcompile = 0 Then
                AE_MsgBox("�Đ������K�v�ł��B", MsgBoxStyle.Critical, "������") : End
#Else
				'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
                AE_MsgBox("�Đ������K�v�ł��B", vbCritical, "������")
#End If
            End If
            If .MainForm = "" Then
                .MainForm = "SSSMAIN"
                Call AE_PSIR_SSSMAIN()
                wk_ww = 0
                wk_De = 1
                wk_HeadN = 0 : wk_BodyN = 0 : wk_EBodyN = 0 : wk_TailN = 0
                Do While wk_ww < AE_PSIC
                    wk_SmrBuf = Trim(AE_PSI(wk_ww)) & Space(1)
                    wk_ww = wk_ww + 1
                    Select Case UCase(VB.Left(wk_SmrBuf, Cn_PrfxLen))
                        Case "HD_", "HV_"
                            Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf, CQ_SSSMAIN(wk_HeadN))
                            wk_HeadN = wk_HeadN + 1
                    End Select
                Loop
            End If
            HD_OPEID.Text = ""
            HD_OPENM.Text = ""
            HD_INPTANCD.Text = ""
            HD_INPTANNM.Text = ""
            HD_STTWRTDT.Text = ""
            HD_ENDWRTDT.Text = ""
            HD_STTWRTTM.Text = ""
            HD_ENDWRTTM.Text = ""
            HD_STTJDNNO.Text = ""
            HD_ENDJDNNO.Text = ""
            HD_STTTOKCD.Text = ""
            HD_STTTOKRN.Text = ""
            HD_SJDNINKB.Text = ""
            HD_OPEID.TabIndex = 0
            AE_Controls(.CtB + 0) = HD_OPEID
            HD_OPENM.TabIndex = 1
            AE_Controls(.CtB + 1) = HD_OPENM
            HD_INPTANCD.TabIndex = 2
            AE_Controls(.CtB + 2) = HD_INPTANCD
            HD_INPTANNM.TabIndex = 3
            AE_Controls(.CtB + 3) = HD_INPTANNM
            HD_STTWRTDT.TabIndex = 4
            AE_Controls(.CtB + 4) = HD_STTWRTDT
            HD_ENDWRTDT.TabIndex = 5
            AE_Controls(.CtB + 5) = HD_ENDWRTDT
            HD_STTWRTTM.TabIndex = 6
            AE_Controls(.CtB + 6) = HD_STTWRTTM
            HD_ENDWRTTM.TabIndex = 7
            AE_Controls(.CtB + 7) = HD_ENDWRTTM
            HD_STTJDNNO.TabIndex = 8
            AE_Controls(.CtB + 8) = HD_STTJDNNO
            HD_ENDJDNNO.TabIndex = 9
            AE_Controls(.CtB + 9) = HD_ENDJDNNO
            HD_STTTOKCD.TabIndex = 10
            AE_Controls(.CtB + 10) = HD_STTTOKCD
            HD_STTTOKRN.TabIndex = 11
            AE_Controls(.CtB + 11) = HD_STTTOKRN
            HD_SJDNINKB.TabIndex = 12
            AE_Controls(.CtB + 12) = HD_SJDNINKB
            TX_CursorRest.TabIndex = 13
            AE_Timer(.ScX) = TM_StartUp
            AE_CursorRest(.ScX) = TX_CursorRest
            '2019.03.29 DEL START
            'AE_ModeBar(.ScX) = TX_Mode
            'AE_StatusBar(.ScX) = TX_Message
            'AE_StatusCodeBar(.ScX) = TX_Message
            '.Mode = Cn_Mode1 : TX_Mode.Text = "�ǉ�"
            '2019.03.29 DEL END
            Call AE_ClearInitValStatus_SSSMAIN()
            .PY_BTop = VB6.PixelsToTwipsY(Me.Height)
            .PY_EBTop = VB6.PixelsToTwipsY(Me.Height)
            PY_TTop = VB6.PixelsToTwipsY(Me.Height)
            .MaxDspC = 0
            .NrBodyTx = 13
            .ScrlMaxL = 1
            .MaxEDspC = 0
            .NrEBodyTx = 13
            .EScrlMaxL = 1
            '2019.04.09 add start
            PP_SSSMAIN.Mode = 1
            '2019.04.09 add end
            Call AE_TabStop_SSSMAIN(0, 12, True)
            TX_CursorRest.TabStop = False
            '2019.03.29 DEL START
            'TX_Mode.TabStop = False
            'TX_Message.TabStop = False
            'TX_Message.Text = ""
            '2019.03.29 DEL END
            '2019.03.27 DEL START
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            'wk_Int = CspAddAltKeyCode(Me.Handle.ToInt32, CS_STTTOKCD.Handle.ToInt32, 2)
            '2019.03.27 DEL END
            Call AE_WindowProcSet_SSSMAIN()
            '2019.03.27 DEL START
            'ReleaseTabCapture(0)
            'SetTabCapture(Me.Handle.ToInt32)
            '2019.03.27 DEL END
            'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_BeginPrg() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Var = SSSMAIN_BeginPrg()
            .FormWidth = VB6.PixelsToTwipsX(Me.Width)
            .FormHeight = VB6.PixelsToTwipsY(Me.Height)
            '����ʕ\���̐��\�`���[�j���O�p ----------
            '   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
            '-----------------------------------------
            .TimerStartUp = True

            '2019.04.02 ADD START
            '�g�p���Ȃ��t�@���N�V�����L�[�͔񊈐��ɂ���
            btnF1.Enabled = False
            btnF2.Enabled = False
            btnF3.Enabled = False
            btnF6.Enabled = False
            btnF7.Enabled = False
            btnF8.Enabled = False
            btnF10.Enabled = False
            btnF11.Enabled = False

            '�t�@���N�V�����L�[�̃C���f�b�N�X�̐ݒ�
            btnF4.Tag = Index_Wk
            Index_Wk += 1
            btnF5.Tag = Index_Wk
            Index_Wk += 1
            btnF9.Tag = Index_Wk
            Index_Wk += 1
            btnF12.Tag = Index_Wk
            '2019.04.02 ADD END

        End With
        TM_StartUp.Enabled = True
        '2019.04.02 ADD START
        SetBar(Me)
        '2019.04.02 ADD END
    End Sub

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason 'Generated.
        PP_SSSMAIN.UnloadMode = UnloadMode
        Select Case UnloadMode
            Case 0, 3
                PP_SSSMAIN.CloseCode = 2
                Cancel = True
                Call AE_EndCm_SSSMAIN()
            Case 2
                PP_SSSMAIN.Caption = Me.Text
                If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then Cancel = True
        End Select
        eventArgs.Cancel = Cancel
    End Sub

    'UPGRADE_WARNING: �C�x���g FR_SSSMAIN.Resize �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub FR_SSSMAIN_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize 'Generated.
        Static FirstTime As Object
        'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        If IsNothing(FirstTime) Then
            'UPGRADE_WARNING: �I�u�W�F�N�g FirstTime �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            FirstTime = False
        ElseIf Not PP_SSSMAIN.Operable Then
        Else
            If Me.WindowState = 0 Then
                If VB6.PixelsToTwipsY(Me.Height) > PP_SSSMAIN.FormHeight Then Me.Height = VB6.TwipsToPixelsY(PP_SSSMAIN.FormHeight)
                If VB6.PixelsToTwipsX(Me.Width) > PP_SSSMAIN.FormWidth Then Me.Width = VB6.TwipsToPixelsX(PP_SSSMAIN.FormWidth)
            End If
        End If
        '   Call AE_Resize(PP_SSSMAIN)
    End Sub

    Private Sub FR_SSSMAIN_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed 'Generated.
        Dim ReturnCode As Short
        PP_SSSMAIN.CloseCode = 11
        If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
            If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then
                'UPGRADE_ISSUE: Event �p�����[�^ Cancel �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' ���N���b�N���Ă��������B
                '2019.03.26 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True : Exit Sub
                '2019.03.26 CHG END
            End If
        Else
            If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then
                'UPGRADE_ISSUE: Event �p�����[�^ Cancel �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' ���N���b�N���Ă��������B
                '2019.03.26 CHG START
                'Cancel = True : Exit Sub
                eventSender.Cancel = True : Exit Sub
                '2019.03.26 CHG END
            End If
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSMAIN_Close() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_Var = SSSMAIN_Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If wk_Var <> 0 Then
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If wk_Var = -1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(Me.Handle.ToInt32)
            '2019.04.09 del end
            If PP_SSSMAIN.hIMC <> 0 Then
                Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
            End If
#If ActiveXcompile = 0 Then
            End
#End If
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ElseIf wk_Var = 0 Then
            'UPGRADE_ISSUE: Event �p�����[�^ Cancel �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"' ���N���b�N���Ă��������B
            '2019.03.26 CHG START
            'Cancel = True
            eventSender.Cancel = True
            '2019.03.26 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ElseIf wk_Var = 1 Then
            '2019.04.09 del start
            'wk_Int = CspPurgeFilterReq(Me.Handle.ToInt32)
            'Call AE_WindowProcReset(PP_SSSMAIN)
            'ReleaseTabCapture(Me.Handle.ToInt32)
            '2019.04.09 del end

            If PP_SSSMAIN.hIMC <> 0 Then
                Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
            End If
        End If
        PP_SSSMAIN.CloseCode = -1
    End Sub


    'UPGRADE_WARNING: �C�x���g HD_ENDJDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_ENDJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDJDNNO.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_ENDJDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_ENDJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDJDNNO.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 9
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 9
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO)
        HD_ENDJDNNO.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = ENDJDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(9).TpStr = wk_Slisted
                CP_SSSMAIN(9).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_ENDJDNNO.Text = wk_Slisted
                Call AE_Check_SSSMAIN_ENDJDNNO(AE_Val3(CP_SSSMAIN(9), HD_ENDJDNNO.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_Slist.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_ENDJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ENDJDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_ENDJDNNO, KeyCode, Shift, CP_SSSMAIN(9).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDJDNNO(AE_Val3(CP_SSSMAIN(9), HD_ENDJDNNO.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(9)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ENDJDNNO.KeyPress
        '2019.04.02 ADD START
        HD_ENDJDNNO.Text = Trim(HD_ENDJDNNO.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 9 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_ENDJDNNO.Text = Trim(HD_ENDJDNNO.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDJDNNO.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDJDNNO(AE_Val3(CP_SSSMAIN(9), HD_ENDJDNNO.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_ENDJDNNO.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_ENDJDNNO.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_ENDJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDJDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDJDNNO)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_ENDJDNNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_ENDJDNNO.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 9
        End If
    End Sub

    Private Sub HD_ENDJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDJDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_ENDJDNNO.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(9), HD_ENDJDNNO)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_ENDWRTDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_ENDWRTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTDT.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_ENDWRTDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub


    Private Sub HD_ENDWRTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTDT.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 5
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 5
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 5)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If ENDWRTDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 5)) Then
            PP_SSSMAIN.CursorDest = Cn_DestBySkip
            If AE_CursorSkip_SSSMAIN() Then
                PP_SSSMAIN.SlistCall = False
                Exit Sub
            End If
            wk_Int = AE_ExecuteX_SSSMAIN()
            If wk_Int <> Cn_CuCurrent And wk_Int <> Cn_CuInCompletePx Then
                Call AE_CursorSub_SSSMAIN(wk_Int)
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT)
        HD_ENDWRTDT.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = ENDWRTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(5).TpStr = wk_Slisted
                CP_SSSMAIN(5).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_ENDWRTDT.Text = wk_Slisted
                Call AE_Check_SSSMAIN_ENDWRTDT(AE_Val3(CP_SSSMAIN(5), HD_ENDWRTDT.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_ENDWRTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ENDWRTDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_ENDWRTDT, KeyCode, Shift, CP_SSSMAIN(5).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDWRTDT(AE_Val3(CP_SSSMAIN(5), HD_ENDWRTDT.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(5)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDWRTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ENDWRTDT.KeyPress
        '2019.04.02 ADD START
        HD_ENDWRTDT.Text = Trim(HD_ENDWRTDT.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 5 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT, KeyAscii)
        '2019.04.02  DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_ENDWRTDT.Text = Trim(HD_ENDWRTDT.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDWRTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTDT.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDWRTDT(AE_Val3(CP_SSSMAIN(5), HD_ENDWRTDT.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_ENDWRTDT.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_ENDWRTDT.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_ENDWRTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDWRTDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDWRTDT)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2018.03.26 DEL START
                'SM_ShortCut.DEL()
                '2019.03.26 CHG END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_ENDWRTDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_ENDWRTDT.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 5
        End If
    End Sub

    Private Sub HD_ENDWRTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDWRTDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_ENDWRTDT.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5), HD_ENDWRTDT)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_ENDWRTTM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_ENDWRTTM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTTM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_ENDWRTTM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_ENDWRTTM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTTM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 7
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 7
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM)
        HD_ENDWRTTM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_ENDWRTTM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ENDWRTTM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_ENDWRTTM, KeyCode, Shift, CP_SSSMAIN(7).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ENDWRTTM(AE_Val3(CP_SSSMAIN(7), HD_ENDWRTTM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(7)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDWRTTM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ENDWRTTM.KeyPress
        '2019.04.02 ADD START
        HD_ENDWRTTM.Text = Trim(HD_ENDWRTTM.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 7 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_ENDWRTTM.Text = Trim(HD_ENDWRTTM.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_ENDWRTTM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ENDWRTTM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ENDWRTTM(AE_Val3(CP_SSSMAIN(7), HD_ENDWRTTM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_ENDWRTTM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_ENDWRTTM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_ENDWRTTM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDWRTTM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_ENDWRTTM)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_ENDWRTTM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_ENDWRTTM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 7
        End If
    End Sub

    Private Sub HD_ENDWRTTM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ENDWRTTM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_ENDWRTTM.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), HD_ENDWRTTM)
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_INPTANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_INPTANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANCD.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_INPTANCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_INPTANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANCD.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 2
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 2
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD)
        HD_INPTANCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g INPTANCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = INPTANCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(2).TpStr = wk_Slisted
                CP_SSSMAIN(2).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_INPTANCD.Text = wk_Slisted
                Call AE_Check_SSSMAIN_INPTANCD(AE_Val3(CP_SSSMAIN(2), HD_INPTANCD.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_INPTANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_INPTANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_INPTANCD, KeyCode, Shift, CP_SSSMAIN(2).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_INPTANCD(AE_Val3(CP_SSSMAIN(2), HD_INPTANCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(2)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_INPTANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_INPTANCD.KeyPress
        '2019.04.01 ADD START
        HD_INPTANCD.Text = Trim(HD_INPTANCD.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.01 DEL START
        'If PP_SSSMAIN.Tx <> 2 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_INPTANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANCD.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_INPTANCD(AE_Val3(CP_SSSMAIN(2), HD_INPTANCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_INPTANCD.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_INPTANCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_INPTANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_INPTANCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_INPTANCD)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_INPTANCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_INPTANCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 2
        End If
    End Sub

    Private Sub HD_INPTANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_INPTANCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_INPTANCD.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_INPTANCD)
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_INPTANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_INPTANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANNM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_INPTANNM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_INPTANNM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_INPTANNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_INPTANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANNM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 3
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 3
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_INPTANNM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_INPTANNM)
        HD_INPTANNM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_INPTANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_INPTANNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_INPTANNM, KeyCode, Shift, CP_SSSMAIN(3).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_INPTANNM(AE_Val3(CP_SSSMAIN(3), HD_INPTANNM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(3)
        End If
    End Sub

    Private Sub HD_INPTANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_INPTANNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 3 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_INPTANNM, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_INPTANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_INPTANNM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_INPTANNM(AE_Val3(CP_SSSMAIN(3), HD_INPTANNM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_INPTANNM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_INPTANNM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_INPTANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_INPTANNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_INPTANNM)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_INPTANNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_INPTANNM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 3
        End If
    End Sub

    Private Sub HD_INPTANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_INPTANNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_INPTANNM.ReadOnly = False
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_OPEID.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_OPEID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub

    Private Sub HD_OPEID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 0
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 0
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
        HD_OPEID.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPEID, KeyCode, Shift, CP_SSSMAIN(0).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), HD_OPEID.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(0)
        End If
    End Sub

    Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 0 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_OPEID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), HD_OPEID.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_OPEID.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_OPEID.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_OPEID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPEID.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 0
        End If
    End Sub

    Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_OPEID.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_OPENM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_OPENM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_OPENM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 1
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 1
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
        HD_OPENM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_OPENM, KeyCode, Shift, CP_SSSMAIN(1).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), HD_OPENM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(1)
        End If
    End Sub

    Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 1 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_OPENM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), HD_OPENM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_OPENM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_OPENM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_OPENM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_OPENM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 1
        End If
    End Sub

    Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_OPENM.ReadOnly = False
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_SJDNINKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_SJDNINKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SJDNINKB.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_SJDNINKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_SJDNINKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SJDNINKB.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 12
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 12
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB)
        HD_SJDNINKB.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_SJDNINKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SJDNINKB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_SJDNINKB, KeyCode, Shift, CP_SSSMAIN(12).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SJDNINKB(AE_Val3(CP_SSSMAIN(12), HD_SJDNINKB.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(12)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs, True)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_SJDNINKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SJDNINKB.KeyPress
        '2019.04.02 ADD START
        HD_SJDNINKB.Text = Trim(HD_SJDNINKB.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 12 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
            '2019.04.02 ADD START
            Call Ctl_Item_Click(btnF4)
            '2019.04.02 ADD END
        End If
        '2019.04.02 ADD START
        HD_SJDNINKB.Text = Trim(HD_SJDNINKB.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_SJDNINKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SJDNINKB.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SJDNINKB(AE_Val3(CP_SSSMAIN(12), HD_SJDNINKB.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_SJDNINKB.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_SJDNINKB.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_SJDNINKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SJDNINKB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_SJDNINKB)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_SJDNINKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_SJDNINKB.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 12
        End If
    End Sub

    Private Sub HD_SJDNINKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SJDNINKB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_SJDNINKB.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(12), HD_SJDNINKB)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_STTJDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_STTJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTJDNNO.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_STTJDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_STTJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTJDNNO.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 8
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 8
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO)
        HD_STTJDNNO.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g STTJDNNO_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = STTJDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(8).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(8).TpStr = wk_Slisted
                CP_SSSMAIN(8).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_STTJDNNO.Text = wk_Slisted
                Call AE_Check_SSSMAIN_STTJDNNO(AE_Val3(CP_SSSMAIN(8), HD_STTJDNNO.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_STTJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTJDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_STTJDNNO, KeyCode, Shift, CP_SSSMAIN(8).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTJDNNO(AE_Val3(CP_SSSMAIN(8), HD_STTJDNNO.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(8)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTJDNNO.KeyPress
        '2019.04.02 ADD START
        HD_STTJDNNO.Text = Trim(HD_STTJDNNO.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 8 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_STTJDNNO.Text = Trim(HD_STTJDNNO.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTJDNNO.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTJDNNO(AE_Val3(CP_SSSMAIN(8), HD_STTJDNNO.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_STTJDNNO.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_STTJDNNO.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_STTJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTJDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTJDNNO)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_STTJDNNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_STTJDNNO.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 8
        End If
    End Sub

    Private Sub HD_STTJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTJDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_STTJDNNO.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), HD_STTJDNNO)
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_STTTOKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_STTTOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG END
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_STTTOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_STTTOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 10
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 10
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD)
        HD_STTTOKCD.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = STTTOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(10).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(10).TpStr = wk_Slisted
                CP_SSSMAIN(10).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_STTTOKCD.Text = wk_Slisted
                Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(10), HD_STTTOKCD.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_STTTOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTTOKCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_STTTOKCD, KeyCode, Shift, CP_SSSMAIN(10).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(10), HD_STTTOKCD.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(10)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTTOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTTOKCD.KeyPress
        '2019.04.02 ADD START
        HD_STTTOKCD.Text = Trim(HD_STTTOKCD.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 10 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_STTTOKCD.Text = Trim(HD_STTTOKCD.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTTOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKCD.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKCD(AE_Val3(CP_SSSMAIN(10), HD_STTTOKCD.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_STTTOKCD.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_STTTOKCD.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_STTTOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKCD)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START 
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_STTTOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_STTTOKCD.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 10
        End If
    End Sub

    Private Sub HD_STTTOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_STTTOKCD.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(10), HD_STTTOKCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_STTTOKRN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_STTTOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKRN.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_STTTOKRN) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_STTTOKRN, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_STTTOKRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_STTTOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKRN.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 11
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 11
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_STTTOKRN)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_STTTOKRN)
        HD_STTTOKRN.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_STTTOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTTOKRN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_STTTOKRN, KeyCode, Shift, CP_SSSMAIN(11).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTTOKRN(AE_Val3(CP_SSSMAIN(11), HD_STTTOKRN.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(11)
        End If
    End Sub

    Private Sub HD_STTTOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTTOKRN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Tx <> 11 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_STTTOKRN, KeyAscii)
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_STTTOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTTOKRN.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTTOKRN(AE_Val3(CP_SSSMAIN(11), HD_STTTOKRN.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_STTTOKRN.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_STTTOKRN.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_STTTOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKRN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTTOKRN)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_STTTOKRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_STTTOKRN.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 11
        End If
    End Sub

    Private Sub HD_STTTOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTTOKRN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_STTTOKRN.ReadOnly = False
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_STTWRTDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_STTWRTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTDT.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_STTWRTDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_STTWRTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTDT.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        Dim wk_Slisted As Object
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 4
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 4
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 4)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If STTWRTDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 4)) Then
            PP_SSSMAIN.CursorDest = Cn_DestBySkip
            If AE_CursorSkip_SSSMAIN() Then
                PP_SSSMAIN.SlistCall = False
                Exit Sub
            End If
            wk_Int = AE_ExecuteX_SSSMAIN()
            If wk_Int <> Cn_CuCurrent And wk_Int <> Cn_CuInCompletePx Then
                Call AE_CursorSub_SSSMAIN(wk_Int)
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx)
            End If
        End If
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT)
        HD_STTWRTDT.BackColor = SSSMSG_BAS.Cn_ClBrightON
        If PP_SSSMAIN.SlistCall Then
            PP_SSSMAIN.SlistCall = False
            PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
            PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
            'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_Slist() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = STTWRTDT_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(4).CuVal))
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            wk_Slisted = PP_SSSMAIN.SlistCom
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
            PP_SSSMAIN.SlistPx = -1
            PP_SSSMAIN.CursorDirection = Cn_Direction1
            PP_SSSMAIN.CursorDest = Cn_Dest9
            PP_SSSMAIN.JustAfterSList = True
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PP_SSSMAIN.SlistCom = System.DBNull.Value
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CP_SSSMAIN(4).TpStr = wk_Slisted
                CP_SSSMAIN(4).CIn = Cn_ChrInput
                'UPGRADE_WARNING: �I�u�W�F�N�g wk_Slisted �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                HD_STTWRTDT.Text = wk_Slisted
                Call AE_Check_SSSMAIN_STTWRTDT(AE_Val3(CP_SSSMAIN(4), HD_STTWRTDT.Text), Cn_Status6, True, True)
            End If
        End If
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = True
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_STTWRTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTWRTDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_STTWRTDT, KeyCode, Shift, CP_SSSMAIN(4).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTWRTDT(AE_Val3(CP_SSSMAIN(4), HD_STTWRTDT.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(4)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTWRTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTWRTDT.KeyPress
        '2019.04.01 ADD START
        HD_STTWRTDT.Text = Trim(HD_STTWRTDT.Text)
        '2019.04.01 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 4 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.01 ADD START
        HD_STTWRTDT.Text = Trim(HD_STTWRTDT.Text)
        '2019.04.01 ADD END
    End Sub

    Private Sub HD_STTWRTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTDT.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTWRTDT(AE_Val3(CP_SSSMAIN(4), HD_STTWRTDT.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_STTWRTDT.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_STTWRTDT.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_STTWRTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTWRTDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTWRTDT)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_STTWRTDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_STTWRTDT.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 4
        End If
    End Sub

    Private Sub HD_STTWRTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTWRTDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_STTWRTDT.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_STTWRTDT)
    End Sub
    'UPGRADE_WARNING: �C�x���g HD_STTWRTTM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_STTWRTTM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTTM.TextChanged 'Generated.
        If PP_SSSMAIN.MultiLineF > 0 Then
            PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
            If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
        End If
        If PP_SSSMAIN.MaskMode = False Then
            '2019.03.27 CHG START
            'If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM) Then
            If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM, FORM_LOAD_FLG) Then
                '2019.03.27 CHG END
                PP_SSSMAIN.CursorDirection = Cn_Direction1
                PP_SSSMAIN.CursorDest = Cn_Dest9
                Call AE_Check_SSSMAIN_STTWRTTM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
            End If
        End If
    End Sub
    Private Sub HD_STTWRTTM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTTM.Enter 'Generated.
        If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
        PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
        If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
        PP_SSSMAIN.Tx = 6
        PP_SSSMAIN.De2 = -1
        PP_SSSMAIN.Px = 6
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM)
        If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int) : Exit Sub
        Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM)
        HD_STTWRTTM.BackColor = SSSMSG_BAS.Cn_ClBrightON
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
    End Sub

    Private Sub HD_STTWRTTM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STTWRTTM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        If AE_KeyDown_SSSMAIN(HD_STTWRTTM, KeyCode, Shift, CP_SSSMAIN(6).TpStr) Then
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_STTWRTTM(AE_Val3(CP_SSSMAIN(6), HD_STTWRTTM.Text), Cn_Status6, True, True)
            If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN(6)
        End If
        '2019.04.02 ADD START
        FKeyDown(eventSender, eventArgs)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTWRTTM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STTWRTTM.KeyPress
        '2019.04.02 ADD START
        HD_STTWRTTM.Text = Trim(HD_STTWRTTM.Text)
        '2019.04.02 ADD END
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        '2019.04.02 DEL START
        'If PP_SSSMAIN.Tx <> 6 Then Beep() : KeyAscii = 0 : GoTo EventExitSub
        'Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM, KeyAscii)
        '2019.04.02 DEL END
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019.04.02 ADD START
        HD_STTWRTTM.Text = Trim(HD_STTWRTTM.Text)
        '2019.04.02 ADD END
    End Sub

    Private Sub HD_STTWRTTM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STTWRTTM.Leave 'Generated.
        PP_SSSMAIN.OnFocus = False
        If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0 : Exit Sub
        PP_SSSMAIN.SuppressGotLostFocus = 0
        If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest) : Exit Sub
        If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False : Exit Sub
        If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
            If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_STTWRTTM(AE_Val3(CP_SSSMAIN(6), HD_STTWRTTM.Text), Cn_Status6, False, True) : PP_SSSMAIN.LostFocusCheck = True
            'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
                On Error Resume Next
                HD_STTWRTTM.Focus()
            End If
        End If
        If System.Drawing.ColorTranslator.ToOle(HD_STTWRTTM.BackColor) = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_ClBrightON) Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
        Call AE_CursorRivise_SSSMAIN()
    End Sub

    Private Sub HD_STTWRTTM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTWRTTM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        Dim wk_Tx As Short
        If PP_SSSMAIN.Operable Then
            If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
                '2019.03.22 DEL START
                'SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_STTWRTTM)
                '2019.03.22 DEL END
                'UPGRADE_ISSUE: �萔 vbPopupMenuLeftButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
                '2019.03.26 DEL START
                'PopupMenu(SM_ShortCut, vbPopupMenuLeftButton)
                '2019.03.26 DEL END
                PP_SSSMAIN.NeglectPopupFocus = False
                wk_Tx = PP_SSSMAIN.Tx
                If PP_SSSMAIN.PopupTx = HD_STTWRTTM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
                System.Windows.Forms.Application.DoEvents()
                HD_STTWRTTM.Enabled = True
                Call AE_CursorMove_SSSMAIN(wk_Tx)
            End If
            PP_SSSMAIN.MouseDownTx = 6
        End If
    End Sub

    Private Sub HD_STTWRTTM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STTWRTTM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        HD_STTWRTTM.ReadOnly = False
        Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_STTWRTTM)
    End Sub

    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
        Call Init_Prompt()
    End Sub

    Public Sub MN_AppendC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click 'Generated.
        Dim wk_Cursor As Short
        If Not PP_SSSMAIN.Operable Then Exit Sub
        wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
        '2019.04.02 CHG START
        'If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN()
        If wk_Cursor = Cn_CuInit Then
            Call AE_CursorInit_SSSMAIN()
            HD_INPTANCD.Text = ""
            HD_STTJDNNO.Text = ""
            HD_ENDJDNNO.Text = ""
            HD_STTTOKCD.Text = ""
            HD_SJDNINKB.Text = ""
        End If
        '2019.04.02 CHG END
    End Sub

    Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        Call AE_ClearItm_SSSMAIN(False)
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
            My.Computer.Clipboard.Clear()
            'UPGRADE_ISSUE: Control SelLength �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            '2019.03.26 CHG START
            'If VB6.GetActiveControl().SelLength <= 1 Then
            If DirectCast(VB6.GetActiveControl(), TextBox).SelectionLength <= 1 Then
                '2019.03.26 CHG END
                On Error Resume Next
                'UPGRADE_ISSUE: Control Text �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
                On Error GoTo 0
            Else
                On Error Resume Next
                'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                '2019.03.26 CHG START
                'My.Computer.Clipboard.SetText(VB6.GetActiveControl().SelText)
                My.Computer.Clipboard.SetText(DirectCast(VB6.GetActiveControl(), TextBox).SelectedText)
                '2019.03.26 CHG END
                On Error GoTo 0
            End If
        End If
    End Sub

    Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
    End Sub

    Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click 'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
                On Error Resume Next
                'UPGRADE_ISSUE: Control Text �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                My.Computer.Clipboard.SetText(VB6.GetActiveControl().Text)
                Call AE_ClearItm_SSSMAIN(False)
                On Error GoTo 0
                Call AE_CursorCurrent_SSSMAIN()
            End If
        End If
    End Sub
    '2019.03.22 DEL START
    'Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click 'Generated.
    '	Const CF_TEXT As Short = 1
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	MN_AppendC.Enabled = True
    '	MN_ClearItm.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 13 Then
    '		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm.Enabled = True
    '	End If
    '	MN_Copy.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 13 Then
    '		If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
    '			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '			If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Copy.Enabled = True
    '		End If
    '	End If
    '	MN_Cut.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 13 Then
    '		If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
    '			'UPGRADE_WARNING: �I�u�W�F�N�g AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
    '				If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '					If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
    '						'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '						If Not IsDbNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).ToString())) Then MN_Cut.Enabled = True
    '					End If
    '				End If
    '			End If
    '		End If
    '	End If
    '	MN_Paste.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 13 Then
    '		If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
    '			'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetFormat �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
    '			If My.Computer.Clipboard.GetFormat(CF_TEXT) Then
    '				If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste.Enabled = True
    '			End If
    '		End If
    '	End If
    '	MN_UnDoItem.Enabled = False
    '	If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 13 Then
    '		If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '			If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
    '				MN_UnDoItem.Enabled = True
    '			ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then 
    '				'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '				If IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsDbNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
    '					MN_UnDoItem.Enabled = True
    '					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(PP_SSSMAIN.Px).ExVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '					'UPGRADE_WARNING: �I�u�W�F�N�g CP_SSSMAIN(PP_SSSMAIN.Px).CuVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then 
    '					MN_UnDoItem.Enabled = True
    '				End If
    '			End If
    '		End If
    '	End If
    'End Sub
    'Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	PP_SSSMAIN.CloseCode = 1
    '	Call AE_EndCm_SSSMAIN()
    'End Sub
    '2019.03.22 DEL END
    Public Sub MN_FSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If FSTART_GetEvent() Then
        End If
    End Sub

    Public Sub MN_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If LCONFIG_GetEvent() Then
        End If
    End Sub

    Public Sub MN_LSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If LSTART_GetEvent() Then
        End If
    End Sub
    '2019.03.22 DEL START
    'Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	MN_Slist.Enabled = False
    '	If False Then
    '	ElseIf PP_SSSMAIN.Tx = 2 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	ElseIf PP_SSSMAIN.Tx = 4 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	ElseIf PP_SSSMAIN.Tx = 5 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	ElseIf PP_SSSMAIN.Tx = 8 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	ElseIf PP_SSSMAIN.Tx = 9 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	ElseIf PP_SSSMAIN.Tx = 10 Then 
    '		If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist.Enabled = True
    '	End If
    '	If PP_SSSMAIN.Mode >= Cn_Mode3 Then
    '	Else
    '	End If
    'End Sub
    'Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click 'Generated.
    '    Dim MaxLB As Short
    '    Dim wk_LnSt As Short
    '    Dim Tx As Short
    '    Dim Px As Short
    '    Dim wk_Txt As String
    '    Dim st_Work As String
    '    Dim wk_Moji As String
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    If TypeOf VB6.GetActiveControl() Is System.Windows.Forms.TextBox Then
    '        If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '            'UPGRADE_ISSUE: Control TabIndex �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
    '            If VB6.GetActiveControl().TabIndex >= 13 Then
    '                'UPGRADE_ISSUE: Control SelText �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
    '                'UPGRADE_ISSUE: Clipboard ���\�b�h Clipboard.GetText �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
    '                VB6.GetActiveControl().SelText = My.Computer.Clipboard.GetText()
    '            Else
    '                Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), VB6.GetActiveControl())
    '            End If
    '        End If
    '    End If
    'End Sub
    'Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click 'Generated.
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    PP_SSSMAIN.SlistSw = True
    '    PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
    '    Call AE_Slist_SSSMAIN()
    '    PP_SSSMAIN.SlistSw = False
    'End Sub
    'Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click 'Generated.
    '    If Not PP_SSSMAIN.Operable Then Exit Sub
    '    Call AE_UnDoItem_SSSMAIN()
    'End Sub
    '2019.03.22 DEL END	
    Public Sub MN_VSTART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If VSTART_GetEvent() Then
        End If
    End Sub
    '2019.03.22 DEL START
    'Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click 'Generated.
    '	If Not PP_SSSMAIN.Operable Then Exit Sub
    '	If PP_SSSMAIN.ShortCutTx = -2 Then
    '		My.Computer.Clipboard.Clear()
    '		On Error Resume Next
    '		My.Computer.Clipboard.SetText(TX_Mode.Text)
    '		On Error GoTo 0
    '	ElseIf PP_SSSMAIN.ShortCutTx = -3 Then 
    '		My.Computer.Clipboard.Clear()
    '		On Error Resume Next
    '		My.Computer.Clipboard.SetText(TX_Message.Text)
    '		On Error GoTo 0
    '		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
    '	ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is System.Windows.Forms.TextBox Then 
    '		My.Computer.Clipboard.Clear()
    '		On Error Resume Next
    '		My.Computer.Clipboard.SetText(AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text)
    '		On Error GoTo 0
    '	End If
    'End Sub
    'Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click 'Generated.
    '    If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
    '        PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
    '        Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
    '        PP_SSSMAIN.Tx = -1
    '    End If
    'End Sub

    '2019.03.22 DEL END
    Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick 'Generated.
        Dim wk_ww As Short
        Dim De As Short
        Dim Tx As Short
        Dim wk_Cursor As Short
        TM_StartUp.Enabled = False
        If PP_SSSMAIN.TimerStartUp = True Then
            PP_SSSMAIN.TimerStartUp = False
            PP_SSSMAIN.MaskMode = False
            PP_SSSMAIN.Operable = True
            If AE_AppendC_SSSMAIN(Cn_Mode1) = Cn_CuCurrent Then
                PP_SSSMAIN.CloseCode = 0
                Call AE_EndCm_SSSMAIN()
            Else
                Call AE_CursorInit_SSSMAIN()
                '2019.04.02 ADD START
                HD_INPTANCD.Text = ""
                HD_STTJDNNO.Text = ""
                HD_ENDJDNNO.Text = ""
                HD_STTTOKCD.Text = ""
                HD_SJDNINKB.Text = ""
                '2019.04.02 ADD END
            End If
        End If
        If PP_SSSMAIN.TimerWorkId = 1 Then
            PP_SSSMAIN.TimerWorkId = 0
            Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
        ElseIf PP_SSSMAIN.TimerWorkId = 8 Then
            PP_SSSMAIN.TimerWorkId = 0
            On Error Resume Next
            AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorSave).Focus()
        ElseIf PP_SSSMAIN.TimerWorkId = 9 Then
            PP_SSSMAIN.TimerWorkId = 0
            Call AE_CursorSub_SSSMAIN(AE_NextCm_SSSMAIN(True))
        End If
    End Sub
    Private Sub TX_CursorRest_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_CursorRest.Enter 'Generated.
        '2019.03.22 DEL START
        'CM_SLIST.Enabled = False
        '2019.03.22 DEL END
        If PP_SSSMAIN.PrpC = 0 Then
            PP_SSSMAIN.De2 = -1
            TX_CursorRest.TabStop = False
        ElseIf PP_SSSMAIN.SSCommand5Ajst Then
            TX_CursorRest.TabStop = False
            PP_SSSMAIN.BrightOnOff = AE_BackColor(CL_SSSMAIN(PP_SSSMAIN.Px) Mod 10)
            PP_SSSMAIN.SSCommand5Ajst = False
        ElseIf PP_SSSMAIN.NextTx = Cn_NextTxCleared Then
            PP_SSSMAIN.De2 = -1
            PP_SSSMAIN.Tx = -1
            If PP_SSSMAIN.CursorToWhere >= 0 Then
                If PP_SSSMAIN.CursorToWhere = Cn_CursorToHome Then
                    PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
                    If AE_CursorNext_SSSMAIN(-1) Then TX_CursorRest.TabStop = False
                Else
                    If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OutputOnly Then
                    ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonC Then
                    Else
                        If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).TabStop Then
                            PP_SSSMAIN.NextTx = PP_SSSMAIN.CursorToWhere
                            On Error Resume Next
                            AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Focus()
                            TX_CursorRest.TabStop = False
                        End If
                    End If
                End If
                PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
            Else
                PP_SSSMAIN.ExMode = PP_SSSMAIN.Mode
            End If
        Else
            PP_SSSMAIN.De2 = -1
            If PP_SSSMAIN.Tx >= 0 Then
                If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OutputOnly Then
                ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonC Then
                Else
                    If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Then
                        On Error Resume Next
                        AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Focus()
                        TX_CursorRest.TabStop = False
                        Exit Sub
                    End If
                End If
            End If
            TX_CursorRest.TabStop = True
            PP_SSSMAIN.Tx = -1
            PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
        End If
    End Sub
    Private Sub TX_CursorRest_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_CursorRest.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        Dim wk_TopDe As Short
        PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
        If KeyCode = System.Windows.Forms.Keys.Up And Shift = 0 Then
            If PP_SSSMAIN.Mode = Cn_Mode3 Then
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
                wk_Bool = AE_CursorUp_SSSMAIN(13)
            End If
        ElseIf KeyCode = System.Windows.Forms.Keys.Down And Shift = 0 Then
            If PP_SSSMAIN.Mode = Cn_Mode3 Then
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
                wk_Bool = AE_CursorDown_SSSMAIN(-1)
            End If
        ElseIf KeyCode = System.Windows.Forms.Keys.Right And Shift = 0 Then
            If PP_SSSMAIN.Mode = Cn_Mode3 Then
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
                wk_Bool = AE_CursorNext_SSSMAIN(-1)
            End If
        ElseIf KeyCode = System.Windows.Forms.Keys.Left And Shift = 0 Then
            If PP_SSSMAIN.Mode = Cn_Mode3 Then
            Else
                PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
                wk_Bool = AE_CursorPrev_SSSMAIN(13)
            End If
        ElseIf (KeyCode = System.Windows.Forms.Keys.Execute Or KeyCode = System.Windows.Forms.Keys.Return) And Shift = 0 Then
        ElseIf KeyCode = System.Windows.Forms.Keys.End And Shift = 0 Then
            PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                If AE_CursorPrevDsp_SSSMAIN(13) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
            End If
        ElseIf KeyCode = System.Windows.Forms.Keys.Home And Shift = 0 Then
            PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
            If PP_SSSMAIN.Mode <> Cn_Mode3 Then
                If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
            End If
        ElseIf KeyCode = System.Windows.Forms.Keys.PageDown And Shift = 0 Then
        ElseIf KeyCode = System.Windows.Forms.Keys.PageUp And Shift = 0 Then
        ElseIf KeyCode = System.Windows.Forms.Keys.ShiftKey Then
        ElseIf KeyCode = System.Windows.Forms.Keys.ControlKey Then
        ElseIf KeyCode = System.Windows.Forms.Keys.Menu Then
        ElseIf KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            wk_Int = AE_FuncKey_SSSMAIN(KeyCode, Shift)
            If KeyCode = System.Windows.Forms.Keys.F10 And Shift = 0 Then Exit Sub
            If KeyCode = System.Windows.Forms.Keys.F4 And (Shift And 6) = 4 Then Exit Sub
        Else
            If Shift <> 4 Then Beep()
        End If
        KeyCode = 0
    End Sub
    Private Sub TX_CursorRest_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_CursorRest.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        If PP_SSSMAIN.Mode = Cn_Mode3 Then
            KeyAscii = 0
        Else
            KeyAscii = 0
            Call AE_CursorInit_SSSMAIN()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TX_Message_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        Call AE_CursorCurrent_SSSMAIN()
    End Sub

    Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyCode = 0
    End Sub

    Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
            '2019.03.29 DEL START
            'TX_Message.Enabled = False
            '2019.03.29 DEL END
            PP_SSSMAIN.ShortCutTx = -3
            '2019.03.22 DEL START
            'SM_FullPast.Enabled = False
            '2019.03.22 DEL END
            'UPGRADE_ISSUE: �萔 vbPopupMenuRightButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
            '2019.03.36 DEL START
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            '2019.03.26 DEL END
            '2019.03.29 DEL START
            'TX_Message.Enabled = True
            '2019.03.29 DEL END
        End If
    End Sub

    Private Sub TX_Mode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)  'Generated.
        Beep()
        Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
    End Sub

    Private Sub TX_Mode_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyCode = 0
    End Sub

    Private Sub TX_Mode_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar) 'Generated.
        Call AE_CursorInit_SSSMAIN()
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TX_Mode_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Generated.
        If (Button And VB6.MouseButtonConstants.RightButton) = VB6.MouseButtonConstants.RightButton Then
            '2019.03.22 DEL START
            'TX_Mode.Enabled = False
            '2019.03.26 DEL END
            PP_SSSMAIN.ShortCutTx = -2
            '2019.03.22 DEL START
            'SM_FullPast.Enabled = False
            'UPGRADE_ISSUE: �萔 vbPopupMenuRightButton �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: Form ���\�b�h FR_SSSMAIN.PopupMenu �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
            'PopupMenu(SM_ShortCut, vbPopupMenuRightButton)
            'TX_Mode.Enabled = True
            '2019.03.26 DEL END
        End If
    End Sub

    '2019.03.27 ADD START
    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Call Ctl_Item_Click(btnF4)
    End Sub

    Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
        Call Ctl_Item_Click(btnF5)
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Act_Index As Short

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '��è�޺��۰ي������ޯ���擾
        Act_Index = CShort(pm_Ctl.Tag)

        Select Case Act_Index

            Case CShort(btnF4.Tag)
                '���
                If Not PP_SSSMAIN.Operable Then Exit Function
                DLGLST1.ShowDialog()
                If SSS_RTNWIN <> 3 Then
                    Call EXE_PRINT(HD_STTWRTDT.Text,
                                   HD_ENDWRTDT.Text,
                                   HD_STTJDNNO.Text,
                                   HD_ENDJDNNO.Text,
                                   HD_STTTOKCD.Text,
                                   HD_STTTOKRN.Text,
                                   HD_INPTANCD.Text,
                                   HD_INPTANNM.Text,
                                   HD_SJDNINKB.Text,
                                   HD_STTWRTTM.Text,
                                   HD_ENDWRTTM.Text,
                                   SSS_RTNWIN)
                End If

            Case CShort(btnF5.Tag)
                'add start 20190808 kuwahara
                '�w���v
                PP_SSSMAIN.ButtonClick = True
                If Not PP_SSSMAIN.Operable Then Exit Function
                PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
                Call AE_Slist_SSSMAIN()
                PP_SSSMAIN.NeglectLostFocusCheck = False
                'UPGRADE_WARNING: �I�u�W�F�N�g Ck_Error �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN()
                'add end 20190808 kuwahara

            Case CShort(btnF9.Tag)
                '�N���A
                Call MN_APPENDC.PerformClick()

            Case CShort(btnF12.Tag)
                '�I��
                Me.Close()

        End Select

    End Function

    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBox�̖߂�l

        '--------------------------------------------------------------------------
        '�G���[�g���b�v�錾
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '�����J�n
            '--------------------------------------------------------------------------
            '---�߂�l�ݒ�---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---�߂�l�ݒ�---'
            SetBar = True

            '--------------------------------------------------------------------------
            '�G���[�g���b�v���[�`��
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("�����ް,�ð���ް�ݒ�֐��G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    Private Sub FKeyDown(sender As Object, e As KeyEventArgs, Optional ByVal lastflg As Boolean = False)

        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F4
                    Me.btnF4.PerformClick()

                Case Keys.F5
                    Me.btnF5.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

                Case Keys.Enter
                    If lastflg = True Then
                        Me.btnF4.PerformClick()
                    End If

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs, Optional ByVal lastflg As Boolean = False) Handles MyBase.KeyDown


    End Sub

    Private Sub btnF4_KeyDown(sender As Object, e As KeyEventArgs) Handles btnF4.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF5_KeyDown(sender As Object, e As KeyEventArgs) Handles btnF5.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF9_KeyDown(sender As Object, e As KeyEventArgs) Handles btnF9.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF12_KeyDown(sender As Object, e As KeyEventArgs) Handles btnF12.KeyDown
        FKeyDown(sender, e)
    End Sub
    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        If Not PP_SSSMAIN.Operable Then Exit Sub
        If LCANCEL_GetEvent() Then
        End If
    End Sub

    '2019.03.27 ADD END
End Class