Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSTOK3
    Inherits System.Windows.Forms.Form
    '�ȉ��� �R�s�̐ݒ���s������
    Const WM_WLS_MSTKB As String = "1" '�}�X�^�敪�i1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i "":���ނȂ��j
    Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
    Const WM_WLS_KanaINPUT As Boolean = False '�J�i���ړ��͎g�p�iTrue:���ړ��� False:�J�i�R���{�j

    '�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
    Const WM_WLS_TextKey As Short = 1 '�J�n�R�[�h�̃\�[�g�L�[No
    Const WM_WLS_KanaKey As Short = 2 '�J�i�����̃\�[�g�L�[No+���L�[
    Const WM_WLS_RNKey As Short = 3 '���Ӑ旪�̌����̃\�[�g�L�[No+���L�[

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190617 chg start
    'Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Dim WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190617 chg end
    Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
    Dim WM_WLS_KANALEN As Short '�J�i���͕�����
    Dim WM_WLS_RNLEN As Short '���Ӑ旪�̓��͕�����

    '�E�B���h�����g�p�ϐ�
    Dim WM_WLS_MAX As Short '�P��ʂ̕\������
    Dim WM_WLS_STTKEY As Object '�J�n�L�[
    Dim WM_WLS_ENDKEY As Object '�I���L�[
    Dim WM_WLS_KeyNo As Short 'Ҳ�̧�ٓǂݍ��݃L�[No
    Dim WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
    Dim WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
    Dim WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
    Dim WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
    Dim WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)

    Dim WlsSelList As String
    Dim WlsHint As String
    Dim WlsOrderBy As String
    Dim WlsFromWhere As String

    Dim DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07

    Private Sub WLS_FORM_INIT()
        '20190603 add start
        Dim Space1 As Object
        Dim Space2 As Object
        Dim Space3 As Object
        Dim Space4 As Object
        '20190602 add end

        '20190621 del start
        ''=== WINDOW �\���t�@�C���ݒ� ===
        'WM_WLS_MFIL = DBN_TOKMTA
        '20190621 del end

        '20190603 del start
        '=== �\���J�n�R�[�h�����ݒ� ===
        WM_WLS_LEN = Len(DB_TOKMTA.TOKCD) 'LenWid �̓_��
        WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK) 'LenWid �̓_��
        WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN) 'LenWid �̓_��
        WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"
        '20190603 del end

        '=== �k�`�a�d�k�ݒ� ===
        'WLSLABEL = "����  ���Ӑ於                 �@�@�@��  ��   �@�������      �ŋ�  �@�d�b�ԍ�     ������"
        '12345 123456789012345678901234567890 1234567890 1234567890123 123456  1234567890123 12345

        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/25 CHG START
        'WLSLABEL = " ����" & Space(Len(DB_TOKMTA.TOKCD) - Len(" ����") + 1) & "���Ӑ於" & Space(Len(DB_TOKMTA.TOKRN) - Len("���Ӑ於") - 1) & "��  ��" & Space(7 - Len("��  ��")) & "�������" & Space(10 - Len("�������")) & "�ŋ�" & Space(3 - Len("�ŋ�") + 1) & "�d�b�ԍ�" & Space(Len(DB_TOKMTA.TOKTL) - Len("�d�b�ԍ�") - 9) & "������" & Space(Len(DB_TOKMTA.TOKSEICD) - Len("������") + 1)
        Space1 = WM_WLS_LEN - Len(" ����") + 1
        Space1 = Space(IIf(Space1 > 0, Space1, 0))
        Space2 = WM_WLS_RNLEN - Len("���Ӑ於") - 1
        Space2 = Space(IIf(Space2 > 0, Space2, 0))
        Space3 = Len(IIf(IsDBNull(DB_TOKMTA.TOKTL), "", DB_TOKMTA.TOKTL)) - Len("�d�b�ԍ�") - 9
        Space3 = Space(IIf(Space3 > 0, Space3, 0))
        Space4 = Len(IIf(IsDBNull(DB_TOKMTA.TOKSEICD), "", DB_TOKMTA.TOKSEICD)) - Len("������") + 1
        Space4 = Space(IIf(Space4 > 0, Space4, 0))
        WLSLABEL.Text = " ����" & Space1 & "���Ӑ於" & Space2 & "��  ��" & Space(7 - Len("��  ��")) & "�������" & Space(10 - Len("�������")) & "�ŋ�" & Space(3 - Len("�ŋ�") + 1) & "�d�b�ԍ�" & Space3 & "������" & Space4
        '2019/03/25 CHG E N D
        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
        'HD_TEXT.Height = 330
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.MaxLength = WM_WLS_LEN
        HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)

    End Sub

    Private Function WLS_DSP_CHECK() As Object
        If DB_TOKMTA.DATKB = "9" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WLS_DSP_CHECK = SSS_NEXT
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WLS_DSP_CHECK = SSS_OK
        End If
    End Function

    Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
        '====================================
        '   WINDOW ���אݒ�
        '====================================

        Dim WK_ZEINM, WK_KESNM, WK_SMENM As String
        Dim WK_TK As New VB6.FixedLengthString(13)
        Dim WK_KESDD As String
        '
        Select Case SSSVal(DB_TOKMTA.TOKZEIKB)
            Case 1
                WK_ZEINM = " �Ŕ� "
            Case 2
                WK_ZEINM = " �ō� "
            Case 9
                WK_ZEINM = "��ې�"
        End Select
        '
        Select Case SSSVal(DB_TOKMTA.TOKSMEKB)
            Case 1
                WK_SMENM = "  " & DB_TOKMTA.TOKSMEDD & "���� "
                Select Case SSSVal(DB_TOKMTA.TOKKESCC)
                    Case 0
                        WK_KESNM = "  ����"
                    Case 1
                        WK_KESNM = "  ����"
                    Case 2
                        WK_KESNM = "���X��"
                    Case Else
                        WK_KESNM = "���̑�"
                End Select
                WK_KESNM = WK_KESNM & DB_TOKMTA.TOKKESDD & "�����"
            Case 2
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKSDWKB)) & "��     " & SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKKDWKB)) & "���"
        End Select
        '
        WM_WLS_DSPArray(ArrayCnt) = DB_TOKMTA.TOKCD & " " & LeftWid(DB_TOKMTA.TOKRN, Len(DB_TOKMTA.TOKRN)) & " " & WK_SMENM & WK_KESNM & " " & WK_ZEINM & " " & LeftWid(DB_TOKMTA.TOKTL, 13) & "  " & VB6.Format(Trim(DB_TOKMTA.TOKSEICD), "!@@@@@")
    End Sub

    Sub WLS_TextSQL()
        WM_WLS_KeyNo = WM_WLS_TextKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        '    WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Sub WLS_KanaSQL()
        WM_WLS_KeyNo = WM_WLS_KanaKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TOKMTA Where TOKNK >= '" & WM_WLS_STTKEY & "' And TOKNK < '" & WM_WLS_ENDKEY & "'"
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKNK, TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Sub WLS_RnSQL()
        WM_WLS_KeyNo = WM_WLS_RNKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        'WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        '    WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%' Or TOKNK Like " & " '%" & WM_WLS_STTKEY & "%'"
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%' Or TOKNK Like " & " '%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        If SSS_PrgId = "SSZET62" Or SSS_PrgId = "SSZET63" Then
            WlsFromWhere = WlsFromWhere & "          AND FRNKB = '1'"
        End If
        WlsOrderBy = "Order By TOKRN,TOKNK, TOKCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)

    End Sub

    Private Sub WLS_DspNew()
        Dim WL_Mode As Short
        Dim cnt As Short

        WL_Mode = 0
        cnt = 0

        Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
            'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WL_Mode = WLS_DSP_CHECK()
            If WL_Mode = SSS_OK Then
                If cnt = 0 Then
                    WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                    WM_WLS_LastPage = WM_WLS_Pagecnt
                    ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                End If
                Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
                cnt = cnt + 1
            End If
            If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
                Call DB_GetNext(WM_WLS_MFIL, BtrNormal)

            End If
        Loop
        If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
        If cnt > 0 Then
            Call WLS_DspPage()
        Else
            LST.Items.Clear()
        End If
    End Sub

    Private Sub WLS_DspPage()
        Dim WL_Mode As Short
        Dim cnt As Short

        LST.Items.Clear()
        cnt = 0
        Do While cnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
                LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt))
            End If
            cnt = cnt + 1
        Loop
        If LST.Items.Count > 0 Then
            LST.SelectedIndex = 0
            LST.Focus()
        End If
    End Sub

    Sub WLS_Kana_Init()

        '�J�i���� Combo ������
        '���̈�s�����s���Ȃ���, WLSKANA.ListIndex = 0 �ŃG���[�ɂȂ�
        WLSKANA.Items.Add("�R�[�h")

        If WM_WLS_KanaKey < 1 Then
            '�J�i���������Ȃ�
            'UPGRADE_WARNING: �I�u�W�F�N�g PNL_USENM().Visible �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            PNL_USENM(3).Visible = False
            WLSKANA.Visible = False
            HD_Kana.Visible = False
        ElseIf WM_WLS_KanaINPUT Then
            '�J�i����͍��ڂ̗L����
            WLSKANA.Visible = False
            HD_Kana.Visible = True
            HD_Kana.Width = WLSKANA.Width
            HD_Kana.Left = WLSKANA.Left
        Else
            WLSKANA.Items.Add("�A�@      ��")
            WLSKANA.Items.Add("�J�@      ��")
            WLSKANA.Items.Add("�T�@      ��")
            WLSKANA.Items.Add("�^�@      ��")
            WLSKANA.Items.Add("�i�@      ��")
            WLSKANA.Items.Add("�n�@      ��")
            WLSKANA.Items.Add("�}�@      ��")
            WLSKANA.Items.Add("���@      ��")
            WLSKANA.Items.Add("���@      ��")
            WLSKANA.Items.Add("���@      ��")
        End If
    End Sub

    '
    '�ȉ��͉�ʃC�x���g����
    '
    'UPGRADE_WARNING: Form �C�x���g WLSTOK.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    '20190603 del start
    'Private Sub WLSTOK_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

    '    '=== WINDOW �ʒu�ݒ� ===
    '    Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
    '    Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

    '    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    WM_WLS_STTKEY = ""
    '    'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
    '    'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    WM_WLS_ENDKEY = System.DBNull.Value
    '    HD_TEXT.Text = ""
    '    WM_WLS_Dspflg = False
    '    WLSKANA.SelectedIndex = 0
    '    HD_Kana.Text = ""
    '    'WLSRN.ListIndex = 0
    '    HD_RN.Text = ""
    '    WM_WLS_Dspflg = True
    '    WM_WLS_Pagecnt = -1
    '    WM_WLS_LastPage = -1
    '    WM_WLS_LastFL = False
    '    ReDim WM_WLS_DSPArray(0)

    '    Call WLS_TextSQL()
    '    Call WLS_DspNew()

    '    'DblClick�C�x���g��Q�Ή�  97/04/07
    '    DblClickFl = False
    'End Sub
    '20190603 del end

    Private Sub WLSTOK_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '20190603 add start
        '=== WINDOW �\���t�@�C���ݒ� ===
        WM_WLS_MFIL = DBN_TOKMTA

        '=== WINDOW �ʒu�ݒ� ===
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_STTKEY = ""
        WM_WLS_ENDKEY = System.DBNull.Value
        HD_TEXT.Text = ""
        WM_WLS_Dspflg = False
        HD_Kana.Text = ""
        HD_RN.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        '=== �\���J�n�R�[�h�����ݒ� ===
        WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"

        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False
        WM_WLS_LEN = Len(DB_TOKMTA.TOKCD)
        WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK)
        WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN)
        '20190603 add end

        'Window�����ݒ�
        Call WLS_FORM_INIT()
        Call WLS_Kana_Init()

        '20190603 add start
        WLSKANA.SelectedIndex = 0
        '20190603 add end
    End Sub

    Private Sub HD_RN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_RN.Enter
        '''    If LenWid(HD_RN.Text) > 0 Then
        '''        HD_RN.Text = SSS_EDTITM_WLS(HD_RN.Text, HD_RN.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_RN.Text = Space$(HD_RN.MaxLength)
        '''    End If
        HD_RN.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_RN.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_RN.SelectionLength = HD_RN.MaxLength
    End Sub

    Private Sub HD_Rn_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_RN.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            HD_TEXT.Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_RN.Text
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = HD_RN.Text
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_RnSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub HD_Kana_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_Kana.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            HD_TEXT.Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_Kana.Text
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = Chr(Asc("�") + 1)
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_KanaSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub HD_Kana_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_Kana.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii < Asc(" ") Then GoTo EventExitSub
        ''2000/04/18 �J�i���͕����͈͂̌����C��
        ''If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
        If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then GoTo EventExitSub
        If KeyAscii < Asc("�") Or KeyAscii > Asc("�") Then
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
        '''    If LenWid(HD_TEXT.Text) > 0 Then
        '''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
        '''    End If
        HD_TEXT.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.SelectionLength = HD_TEXT.MaxLength
    End Sub

    Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_TEXT.Text
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = System.DBNull.Value
            WLSKANA.SelectedIndex = 0
            HD_Kana.Text = ""
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
        'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = True
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        '20190606 chg start
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190606 chg end
    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KEYCODE
            Case System.Windows.Forms.Keys.Return
                '20190606 chg start
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Escape
                '20190606 chg start
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Left '���L�[
                '20190606 chg start
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190606 chg end
            Case System.Windows.Forms.Keys.Right '���L�[
                '20190606 chg start
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190606 chg end
                If LST.Items.Count > 0 Then
                    LST.SelectedIndex = -1
                End If
        End Select
    End Sub

    'UPGRADE_WARNING: �C�x���g WLSKANA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
        Dim W_BUF As Object
        If WM_WLS_Dspflg = False Then Exit Sub
        WM_WLS_Dspflg = False
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        If WLSKANA.SelectedIndex > 0 Then
            HD_TEXT.Text = ""
            HD_RN.Text = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = VB.Left(W_BUF, 1)
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
            Call WLS_KanaSQL()
        Else
            If HD_RN.Text <> "" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_STTKEY = VB6.Format(HD_RN.Text)
                Call WLS_RnSQL()
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
                Call WLS_TextSQL()
            End If
        End If
        Call WLS_DspNew()
    End Sub

    Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = True
            Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
        Else
            WM_WLS_Dspflg = False
        End If
    End Sub

    '20190606 del start
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '    If LST.Items.Count <= 0 Then Exit Sub

    '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '        If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '    Else
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '        Call WLS_DspPage()
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

    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '    If WM_WLS_Pagecnt > 0 Then
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '        Call WLS_DspPage()
    '    End If
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

    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    'UnLoad�C�x���g��Q�Ή�  97/04/07
    '    'Unload Me
    '    Hide()
    'End Sub
    '20190606 del end

    '20190606 add start
    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
        Call btnF12_Click(WLSCANCEL, New System.EventArgs())
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_RN.Focused Then
                Call HD_Rn_KeyDown(HD_RN, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_TEXT_KeyDown(HD_TEXT, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            'Window�����ݒ�
            Call WLS_FORM_INIT()
            Call WLS_Kana_Init()

            Me.HD_TEXT.Text = ""
            Me.HD_RN.Text = ""
            LST.Items.Clear()
            Me.HD_TEXT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Hide()
    End Sub

    Private Sub WLS_TOK3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    '20190606 add end

End Class