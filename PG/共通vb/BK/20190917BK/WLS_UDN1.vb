Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSUDN1
    Inherits System.Windows.Forms.Form
    '�ȉ��̂S�s�̐ݒ���s������
    Const WM_WLS_MSTKB As String = "1" '�}�X�^�敪(1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i)
    Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]

    '�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
    Const WM_WLS_TextKey As Short = 2 '�J�n�R�[�h�̃\�[�g�L�[No
    Const WM_WLS_CDKey As Short = 5 '�J�i�����̃\�[�g�L�[No+���L�[

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 CHG START
    'Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Dim WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 CHG SEND
    Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����

    '�E�B���h�����g�p�ϐ�
    Dim WM_WLS_MAX As Short '�P��ʂ̕\������
    Dim WM_WLS_STTKEY As Object '�J�n�L�[
    Dim WM_WLS_ENDKEY As Object '�I���L�[
    Dim WM_WLS_KeyCode As Short '�����ޯ���\���p
    Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
    Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
    Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
    Dim WM_WLS_INIT As Short '�E�B���h�����\���׸�(True or False)

    Private DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07

    '20190620 ADD START
    Public UDN1_PARA1 As String
    '20190620 ADD END

    Private Sub COM_TOKCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles COM_TOKCD.Click
        '20190620 DEL START
        'DB_PARA(DBN_TOKMTA).KeyBuf = WLSCD.Text
        '20190620 DEL END

        '2019/03/25 CHG START
        'WLSTOK.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        'WLSTOK.Close()
        WLSTOK3.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
        WLSTOK3.Close()
        '2019/03/25 CHG E N D
        System.Windows.Forms.Application.DoEvents()
        WM_WLS_Dspflg = False
        KEYBAK.Items.Clear()
        LST.Items.Clear()
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(PP_SSSMAIN.SlistCom) Then
            ''98/09/25 �폜
            ''DB_TOKMTA.TOKCD = ""
            ''98/09/25 �ǉ�
            HD_TEXT.Text = ""
            WLSCD.Text = ""
            WLSRN.Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = "1"
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = System.DBNull.Value
            WM_WLS_KeyCode = 0
            If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
            WM_WLS_Dspflg = True
            WM_WLS_KeyNo = WM_WLS_TextKey
            WM_WLS_Pagecnt = -1
            Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
            'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If WLSSSS_SET_KEYBAK() = True Then
                Call WLSSSS_DSP()
            End If
            ''
        Else
            Call DB_GetEq(DBN_TOKMTA, 1, PP_SSSMAIN.SlistCom, BtrNormal)
            If DBSTAT = 0 Then
                HD_TEXT.Text = ""
                WLSCD.Text = DB_TOKMTA.TOKCD
                WLSRN.Text = DB_TOKMTA.TOKRN
                ''98/09/25 �폜
                ''WM_WLS_KeyCode = -1
                ''WLSCOMBO.ListIndex = 1
                ''98/09/25 �ǉ�
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_STTKEY = "1" & WLSCD.Text
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_ENDKEY = "1" & WLSCD.Text
                WM_WLS_KeyCode = 0
                If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
                WM_WLS_Dspflg = True
                WM_WLS_KeyNo = WM_WLS_CDKey
                WM_WLS_Pagecnt = -1
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP()
                End If
            End If
            ''
        End If
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g PP_SSSMAIN.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        PP_SSSMAIN.SlistCom = System.DBNull.Value

    End Sub

    'UPGRADE_WARNING: Form �C�x���g WLSUDN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub WLSUDN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190627 DEL START
        'Call WLSSSS_FORM_ACTIVATE()
        ''DblClick�C�x���g��Q�Ή�  97/04/07
        'DblClickFl = False
        '20190627 DEL END

    End Sub

    Private Sub WLSUDN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call WLS_FORM_LOAD()
        Call WLSSSS_FORM_INIT()

        '20190627 ADD START
        Call WLSSSS_FORM_ACTIVATE()
        'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = False
        '20190627 ADD END

    End Sub

    '20190627 ADD START
    Private Sub WLSUDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub
    '20190627 ADD END

    'UPGRADE_WARNING: �C�x���g HD_TEXT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
        Dim s As Integer
        s = HD_TEXT.SelectionStart
        HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.Uppercase)
        HD_TEXT.SelectionStart = s
    End Sub

    Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_TEXT.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(HD_TEXT.Text) > 0 Then
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
        Else
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_TEXT.Text = Space(HD_TEXT.Maxlength)
        End If
        HD_TEXT.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.SelectionLength = HD_TEXT.Maxlength
    End Sub

    Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim I As Object
        Dim STAT As Short

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
                HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
                HD_TEXT.SelectionStart = 0
                'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
                HD_TEXT.SelectionLength = HD_TEXT.Maxlength
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_STTKEY = "11" & HD_TEXT.Text
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_ENDKEY = System.DBNull.Value
                WM_WLS_KeyCode = 0
                If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
                WM_WLS_Dspflg = True
                WM_WLS_KeyNo = WM_WLS_TextKey
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                WM_WLS_Pagecnt = -1
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If WLSSSS_SET_KEYBAK() = True Then
                    Call WLSSSS_DSP()
                End If
                '        Case 40  '���L�[
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%2")
        End Select
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
        'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = True

        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KEYCODE
            Case 13
                Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
                'DblClick�C�x���g��Q�Ή�  97/04/07
                'Call WLSCANCEL_CLICK
                '20190627 CHG START
                'If DblClickFl = False Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                If DblClickFl = False Then Call btnF12_Click(btnF12, New System.EventArgs())
                '20190627 CHG END

            Case 27
                '20190627 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190627 CHG END

            Case 37 '���L�[
                '20190627 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190627 CHG END

                '       Case 38  '���L�[
                '           If LST.ListIndex = 0 Then
                '               LST.ListIndex = -1
                '               HD_TEXT.SetFocus
                '           End If
            Case 39 '���L�[
                '20190627 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190627 CHG END

                If LST.Items.Count > 0 Then
                    LST.SelectedIndex = -1
                End If
            Case 112 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%2")
        End Select
    End Sub

    Private Sub WLS_DISPLAY()
        '====================================
        '   WINDOW ���ו\��
        '====================================
        Dim WK_TK As New VB6.FixedLengthString(13)
        Dim WK_DENDT As New VB6.FixedLengthString(10)
        Dim WK_NOKDT As New VB6.FixedLengthString(10)
        WK_DENDT.Value = VB.Left(DB_UDNTHA.UDNDT, 4) & "/" & Mid(DB_UDNTHA.UDNDT, 5, 2) & "/" & VB.Right(DB_UDNTHA.UDNDT, 2)
        LST.Items.Add(DB_UDNTHA.UDNNO & " " & WK_DENDT.Value & " " & DB_UDNTHA.TOKCD & " " & DB_UDNTHA.TOKRN)
    End Sub

    Private Function WLS_DSP_CHECK() As Object
        '====================================
        '   WINDOW �\���\�`�F�b�N
        '       WLS_DSP_CHECK = True  :�\����
        '       WLS_DSP_CHECK = FALSE :�\���s��
        '====================================
        'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLS_DSP_CHECK = SSS_OK
        If DB_UDNTHA.DATKB <> "1" Then
            '        WLS_DSP_CHECK = SSS_NEXT               'Removed on 1997/07/16
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WLS_DSP_CHECK = SSS_END 'Added on 1997/07/16
            Exit Function 'Added on 1997/07/16
        End If
        '2006/10/12 [DEL-START] ZKTJB = "2"�i�����j�̃`�F�b�N�����ɂ���i�[�i���͏o�͂���ׁj
        ''''If DB_UDNTHA.ZKTKB = "2" Then
        ''''    WLS_DSP_CHECK = SSS_NEXT
        ''''End If
        '2006/10/12 [DEL-E N D] ZKTJB = "2"�i�����j�̃`�F�b�N�����ɂ���i�[�i���͏o�͂���ׁj
        If WM_WLS_KeyNo = WM_WLS_TextKey Then
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If DB_UDNTHA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_END
        ElseIf WM_WLS_KeyNo = WM_WLS_CDKey Then
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If DB_UDNTHA.DENKB <> "1" Then WLS_DSP_CHECK = SSS_NEXT '1998/11/30  Update
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WLSCD.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If (SSSVal((WLSCD.Text)) <> 0) And (DB_UDNTHA.TOKCD <> WLSCD.Text) Then WLS_DSP_CHECK = SSS_NEXT
    End Function

    Private Sub WLS_FORM_LOAD()

        '=== WINDOW �ʒu�ݒ� ===
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)

        '=== ����TEXT ===
        'WLSCD.Height = 330
        'WLSRN.Height = 330
        WLSCD.Text = ""
        WLSRN.Text = ""

        '=== WINDOW �\���t�@�C���ݒ� ===
        WM_WLS_MFIL = DBN_UDNTHA

        '=== �\���J�n�R�[�h�����ݒ� ===
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_LEN = LenWid(DB_UDNTHA.UDNNO)

        '=== �k�`�a�d�k�ݒ� ===
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/25 CHG START
        'WLSLABEL = "����No.  ������t   ���Ӑ溰�ށ^ ��  ��         "
        WLSLABEL.Text = "����No.  ������t   ���Ӑ溰�ށ^ ��  ��         "
        '2019/03/25 CHG E N D

        '=== �R���{�a�n�w�ݒ� ===
        WLSCOMBO.Items.Add("�`�[No.��")
        WLSCOMBO.Items.Add("���Ӑ揇")
        WLSCOMBO.SelectedIndex = 0
        WM_WLS_INIT = 0
    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        '20190627 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190627 CHG END

    End Sub

    '20190627 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
    '    Dim WL_Key As String

    '    If LST.Items.Count > 0 Then
    '        If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
    '            Exit Sub
    '        Else
    '            If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
    '                'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
    '                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                If WLSSSS_SET_KEYBAK() = False Then Exit Sub
    '            Else
    '                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '                WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '            End If
    '            Call WLSSSS_DSP()
    '        End If
    '    End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(1).Image
    'End Sub

    'Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(0).Image
    'End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        Dim WL_Key As String

        If LST.Items.Count > 0 Then
            If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) = HighValue(1)) Then
                Exit Sub
            Else
                If (WM_WLS_Pagecnt + 1) > (KEYBAK.Items.Count - 1) Then
                    'Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = False Then Exit Sub
                Else
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                End If
                Call WLSSSS_DSP()
            End If
        End If
    End Sub
    '20190627 CHG END

    '20190627 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.WLSCD.Focused Then
                Call WLSCD_KeyDown(WLSCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try

            Me.HD_TEXT.Text = ""
            Me.WLSCD.Text = ""
            Me.WLSRN.Text = ""

            LST.Items.Clear()
            Me.HD_TEXT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190627 ADD END

    '20190627 CHG START
    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    'UnLoad�C�x���g��Q�Ή�  97/04/07
    '    'Unload Me
    '    Hide()
    'End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        'Unload Me
        Hide()
    End Sub
    '20190627 CHG END

    Private Sub WLSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCD.Enter
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WLSCD.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(WLSCD.Text) > 0 Then
            WLSCD.Text = SSS_EDTITM_WLS(WLSCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WLSCD.Text = Space(LenWid(DB_TOKMTA.TOKCD))
        End If
        WLSCD.SelectionStart = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLSCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)

    End Sub

    Private Sub WLSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim I As Object
        Dim STAT As Short

        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                KEYBAK.Items.Clear()
                LST.Items.Clear()
                WLSCD.Text = SSS_EDTITM_WLS(WLSCD.Text, LenWid(DB_TOKMTA.TOKCD), "0")
                WLSCD.SelectionStart = 0
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WLSCD.SelectionLength = LenWid(DB_TOKMTA.TOKCD)
                If Trim(WLSCD.Text) = "" Then
                    WLSRN.Text = "" '1997/12/01 �ǉ��@ZHANG
                    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    WM_WLS_STTKEY = "1"
                    'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    WM_WLS_ENDKEY = System.DBNull.Value
                    HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
                    WM_WLS_KeyCode = 0
                    If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
                    WM_WLS_Dspflg = True
                    WM_WLS_KeyNo = WM_WLS_TextKey
                    WM_WLS_Pagecnt = -1
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If WLSSSS_SET_KEYBAK() = True Then
                        Call WLSSSS_DSP()
                    End If
                Else
                    Call DB_GetEq(DBN_TOKMTA, 1, WLSCD.Text, BtrNormal)
                    If DBSTAT = 0 Then
                        WLSRN.Text = DB_TOKMTA.TOKRN
                        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        WM_WLS_STTKEY = "1" & WLSCD.Text
                        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        WM_WLS_ENDKEY = "1" & WLSCD.Text
                        WM_WLS_KeyCode = 0
                        If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
                        WM_WLS_Dspflg = True
                        WM_WLS_KeyNo = WM_WLS_CDKey
                        WM_WLS_Pagecnt = -1
                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If WLSSSS_SET_KEYBAK() = True Then
                            Call WLSSSS_DSP()
                        End If
                    End If
                End If
                '        Case 40  '���L�[
                '            LST.ListIndex = 0
                '            LST.SetFocus
            Case 112 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%2")
        End Select

    End Sub

    'UPGRADE_WARNING: �C�x���g WLSCOMBO.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub WLSCOMBO_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCOMBO.SelectedIndexChanged
        If WM_WLS_KeyCode < 0 Then Call WLSCOMBO_KeyDown(WLSCOMBO, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
        WM_WLS_KeyCode = -1
    End Sub

    Private Sub WLSCOMBO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCOMBO.Enter
        WM_WLS_KeyCode = -1
    End Sub

    Private Sub WLSCOMBO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSCOMBO.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Rtn As Short
        WM_WLS_KeyCode = KEYCODE
        Select Case KEYCODE
            Case 13
                WM_WLS_Dspflg = False
                WM_WLS_KeyCode = 0
                Call WLSSSS_COMBO_CHECK()
                HD_TEXT.Text = ""
                WM_WLS_Dspflg = True
                If LST.Items.Count > 0 Then LST.Focus()
                KEYBAK.Items.Clear()
                WM_WLS_Pagecnt = -1
                Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WM_WLS_STTKEY, BtrNormal)
                KEYBAK.Items.Clear()
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Rtn = WLSSSS_SET_KEYBAK()
                Call WLSSSS_DSP()
            Case 112 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%1")
            Case 113 'F��P�L�[
                System.Windows.Forms.SendKeys.Send("%2")
        End Select
    End Sub

    '20190627 CHG START
    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '    Dim WL_Key As String

    '    If WM_WLS_Pagecnt > 0 Then
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '    Else
    '        Exit Sub
    '    End If
    '    WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
    '    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
    '    Call WLSSSS_DSP()
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(0).Image
    'End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        Dim WL_Key As String

        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Else
            Exit Sub
        End If
        WL_Key = VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt)
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
        Call WLSSSS_DSP()
    End Sub
    '20190627 CHG END

    '20190627 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call LST_KeyDown(LST, New System.Windows.Forms.KeyEventArgs(13 Or 0 * &H10000))
    End Sub
    '20190627 CHG END


    Private Sub WLSSSS_COMBO_CHECK()
        If (WLSCOMBO.SelectedIndex > 0) Then
            WM_WLS_KeyNo = WM_WLS_CDKey
            HD_TEXT.Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = "1" & WLSCD.Text
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Trim(WM_WLS_STTKEY) = "1" Then
                'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_ENDKEY = System.DBNull.Value
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_ENDKEY = WM_WLS_STTKEY
            End If
        Else
            WM_WLS_KeyNo = WM_WLS_TextKey
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_TEXT.Text
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = System.DBNull.Value
        End If
    End Sub

    Private Sub WLSSSS_DSP()
        Dim WL_Mode As Short
        Dim WL_Key As String

        If WM_WLS_Dspflg = False Then Exit Sub

        LST.Items.Clear()
        If DBSTAT = 0 Then
            Do While (DBSTAT = 0) And (LST.Items.Count < WM_WLS_MAX) And (WL_Mode <> SSS_END)
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WL_Mode = WLSSSS_DSP_CHECK()
                If WL_Mode = SSS_OK Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    WL_Mode = WLS_DSP_CHECK()
                    If WL_Mode = SSS_OK Then
                        Call WLS_DISPLAY()
                    End If
                End If
                If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
                    Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                ElseIf WL_Mode = SSS_RPSN Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    WL_Key = WLSSSS_RPSN()
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If LenWid(WL_Key) = 0 Then
                        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    Else
                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    End If
                ElseIf WL_Mode = SSS_NPSN Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    WL_Key = WLSSSS_NPSN()
                    'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If LenWid(WL_Key) = 0 Then
                        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                    Else
                        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                    End If
                End If
            Loop
            If LST.Items.Count > 0 Then
                LST.SelectedIndex = 0
            End If
        End If
        If (DBSTAT <> 0) Or (WL_Mode = SSS_END) Then
            If (LeftWid(VB6.GetItemString(KEYBAK, WM_WLS_Pagecnt + 1), 1) <> HighValue(1)) Then
                KEYBAK.Items.Add(HighValue(1))
            End If
        End If
    End Sub

    Private Function WLSSSS_DSP_CHECK() As Object
        Dim CHKDAT As Object

        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLSSSS_DSP_CHECK = SSS_OK

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If Not IsDBNull(WM_WLS_ENDKEY) Then
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WM_WLS_ENDKEY) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190620 CHG START
            'If LeftWid(DB_PARA(WM_WLS_MFIL).KeyBuf, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    WLSSSS_DSP_CHECK = SSS_END
            '    Exit Function
            'End If
            If LeftWid(UDN1_PARA1, LenWid(WM_WLS_ENDKEY)) > WM_WLS_ENDKEY Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WLSSSS_DSP_CHECK = SSS_END
                Exit Function
            End If
            '20190620 CHG END

        End If

    End Function

    Private Sub WLSSSS_FORM_ACTIVATE()
        Dim I As Short
        Dim W_Key As String

        WM_WLS_Dspflg = False
        WM_WLS_KeyCode = 0
        If WLSCOMBO.Items.Count > 0 Then WLSCOMBO.SelectedIndex = 0
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        ''98/09/25 �폜
        ''WM_WLS_KeyNo = WM_WLS_TextKey
        '20190620 CHG START
        'W_Key = DB_PARA(WM_WLS_MFIL).KeyBuf
        W_Key = UDN1_PARA1
        '20190620 CHG END
        Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, W_Key, BtrNormal)
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WLSSSS_SET_KEYBAK() = True And WM_WLS_INIT = 0 Then
            WM_WLS_INIT = 1
            Call WLSSSS_DSP()
        End If
    End Sub

    Private Sub WLSSSS_FORM_INIT()
        Dim I As Short

        WM_WLS_KeyCode = False
        WM_WLS_MAX = VB6.PixelsToTwipsY(LST.Height) \ 240
        'HD_TEXT.Height = 285
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.Maxlength = WM_WLS_LEN
        HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 100)
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_STTKEY = "1"
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_ENDKEY = System.DBNull.Value
        HD_TEXT.Text = "" 'DB_PARA(WM_WLS_MFIL).KeyBuf
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(DB_PARA(WM_WLS_MFIL).KeyBuf)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        '20190620 CHG START
        'If LenWid(Trim(DB_PARA(WM_WLS_MFIL).KeyBuf)) = 0 Then
        '    HD_TEXT.Text = ""
        'End If
        If LenWid(Trim(UDN1_PARA1)) = 0 Then
            HD_TEXT.Text = ""
        End If
        '20190620 CHG END

        ''98/09/25 �ǉ�
        WM_WLS_KeyNo = WM_WLS_TextKey

    End Sub

    Private Function WLSSSS_NPSN() As Object
        Dim WL_Key As String
        WL_Key = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLSSSS_NPSN = WL_Key
    End Function

    Private Function WLSSSS_RPSN() As Object
        Dim WL_Key As String
        WL_Key = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLSSSS_RPSN = WL_Key
    End Function

    Private Function WLSSSS_SET_KEYBAK() As Object
        Dim WL_Mode As Short
        Dim WL_Key As String

        'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WLSSSS_SET_KEYBAK = True

        Do While DBSTAT = 0
            'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WL_Mode = WLSSSS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WL_Mode = WLS_DSP_CHECK()
                If WL_Mode = SSS_OK Then
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    '20190620 CHG START
                    'KEYBAK.Items.Add(DB_PARA(WM_WLS_MFIL).KeyBuf)
                    KEYBAK.Items.Add(UDN1_PARA1)
                    '20190620 CHG START

                End If
            End If
            If WL_Mode = SSS_NEXT Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
            ElseIf WL_Mode = SSS_RPSN Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_RPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WL_Key = WLSSSS_RPSN()
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If LenWid(WL_Key) = 0 Then
                    Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                Else
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                End If
            ElseIf WL_Mode = SSS_NPSN Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_NPSN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WL_Key = WLSSSS_NPSN()
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(WL_Key) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If LenWid(WL_Key) = 0 Then
                    Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
                Else
                    Call DB_GetGrEq(WM_WLS_MFIL, WM_WLS_KeyNo, WL_Key, BtrNormal)
                End If
            Else
                Exit Do
            End If
        Loop
        If DBSTAT <> 0 Or WL_Mode = SSS_END Then
            'UPGRADE_WARNING: �I�u�W�F�N�g WLSSSS_SET_KEYBAK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WLSSSS_SET_KEYBAK = False
        End If
    End Function
End Class