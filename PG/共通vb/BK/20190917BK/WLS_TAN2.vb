Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSTAN2
    Inherits System.Windows.Forms.Form
    '�ȉ��� �R�s�̐ݒ���s������
    Const WM_WLS_MSTKB As String = "3" '�}�X�^�敪�i1:���Ӑ� 2:�[�i�� 3:�S���� 4:�d���� 5:���i "":���ނȂ��j
    Const WM_WLSKEY_ZOKUSEI As String = "0" '�J�n�R�[�h���͑��� [0,X]
    Const WM_WLSKEY_ZOKUSEI_BMN As String = "0" '����R�[�h���͑��� [0,X]
    Const WM_WLS_KanaINPUT As Boolean = False '�J�i���ړ��͎g�p�iTrue:���ړ��� False:�J�i�R���{�j
    Const WM_WLS_TanINPUT As Boolean = True
    '�����L�[No�i�g�p���Ȃ��ꍇ��-1��ݒ�j
    Const WM_WLS_TextKey As Short = 1 '�J�n�R�[�h�̃\�[�g�L�[No
    Const WM_WLS_KanaKey As Short = 2 '�J�i�����̃\�[�g�L�[No+���L�[
    Const WM_WLS_TanKey As Short = 3
    Const WM_WLS_BmnKey As Short = 4

    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 CHG START
    'Dim WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    'Dim WM_WLS_SFIL As Short
    Dim WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    Dim WM_WLS_SFIL As Object
    '20190619 CHG END

    Dim WM_WLS_LEN As Short '�J�n���ޓ��͕�����
    Dim WM_WLS_KANALEN As Short '�J�i���͕�����
    Dim WM_WLS_TANLEN As Short '�S���Җ����͕�����

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
    Dim SWlsSelList As String
    Dim WlsHint As String
    Dim WlsOrderBy As String
    Dim WlsFromWhere As String

    Dim DblClickFl As Boolean 'DblClick�C�x���g��Q�Ή�  97/04/07

    Private Sub WLS_FORM_INIT()
        '=== WINDOW �\���t�@�C���ݒ� ===
        WM_WLS_MFIL = DBN_TANMTA
        WM_WLS_SFIL = DBN_BMNMTA
        '=== �\���J�n�R�[�h�����ݒ� ===
        WM_WLS_LEN = Len(DB_TANMTA.TANCD) 'LenWid �̓_��

        '20190807 ADD START
        If WM_WLS_LEN = 0 Then
            WM_WLS_LEN = 6
        End If
        '20190807 ADD END

        WM_WLS_KANALEN = Len(DB_TANMTA.TANNK) 'LenWid �̓_��
        WM_WLS_TANLEN = Len(DB_TANMTA.TANNM)
        WlsSelList = "TANCD, TANNM, TANNK, TANBMNCD,DATKB,TANCLAKB,TANCLBKB"
        SWlsSelList = "*"
        '=== �k�`�a�d�k�ݒ� ===
        'UPGRADE_WARNING: �I�u�W�F�N�g WLSLABEL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190326 CHG START
        'WLSLABEL = "�R�[�h  �S���Җ�                        ��������"
        WLSLABEL.Text = "�R�[�h  �S���Җ�                        ��������"
        '20190326 CHG END
        'XXXXX6  MMMMMMMMM1MMMMMMMMM2MMMMMMMMMM3  MMMMMMMMM1MMMMMMMMM2

        WM_WLS_MAX = CShort((VB6.PixelsToTwipsY(LST.Height) - 15) / 240)
        'HD_TEXT.Height = 330
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.Maxlength = WM_WLS_LEN
        HD_TEXT.Width = VB6.TwipsToPixelsX((WM_WLS_LEN + 1) * 120)

    End Sub

    Private Function WLS_DSP_CHECK() As Object
        If DB_TANMTA.DATKB = "9" Then
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
        Call WLS_BMNSQL()
        'WM_WLS_DSPArray(ArrayCnt) = DB_TANMTA.TANCD & "  " & LeftWid(DB_TANMTA.TANNM, Len(DB_TANMTA.TANNM)) & "  " & LeftWid(DB_BMNMTA.BMNNM, Len(DB_BMNMTA.BMNNM))
        WM_WLS_DSPArray(ArrayCnt) = DB_TANMTA.TANCD & "  " & LeftWid(DB_TANMTA.TANNM, 30) & "  " & LeftWid(DB_BMNMTA.BMNNM, Len(DB_BMNMTA.BMNNM))

    End Sub

    Sub WLS_TextSQL()
        WM_WLS_KeyNo = WM_WLS_TextKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        '    WlsFromWhere = "From TANMTA Where TANCD >= '" & WM_WLS_STTKEY & "'"
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TANMTA Where TANCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
        WlsOrderBy = "Order By TANCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        '20190612 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
        DB_GetTable(DB_SQLBUFF)
        '20190612 CHG END
    End Sub
    Sub WLS_TANSQL()
        WM_WLS_KeyNo = WM_WLS_TanKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        '    WlsFromWhere = "From TANMTA Where TANNM Like '%" & WM_WLS_STTKEY & "%'"
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TANMTA Where TANNM Like '%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
        WlsOrderBy = "Order By TANCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        '20190612 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
        DB_GetTable(DB_SQLBUFF)
        '20190612 CHG END
    End Sub

    Sub WLS_KanaSQL()
        WM_WLS_KeyNo = WM_WLS_KanaKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TANMTA Where TANNK >= '" & WM_WLS_STTKEY & "' And TANNK < '" & WM_WLS_ENDKEY & "'"
        WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
        WlsOrderBy = "Order By TANCD"
        DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        '20190612 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
        DB_GetTable(DB_SQLBUFF)
        '20190612 CHG END
    End Sub
    Sub WLS_TANBMNSQL()
        WM_WLS_KeyNo = WM_WLS_TanKey
        ''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        '''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        '    WlsFromWhere = "From TANMTA Where TANBMNCD = '" & WM_WLS_STTKEY & "'"
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WlsFromWhere = "From TANMTA Where TANBMNCD = '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
        '''' UPD 2009/12/03  FKS) T.Yamamoto    End
        WlsFromWhere = WlsFromWhere & " And DATKB <> '9' "
        WlsOrderBy = "Order By TANCD"
        DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        '20190612 CHG START
        'Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
        DB_GetTable(DB_SQLBUFF)
        '20190612 CHG END
    End Sub

    Sub WLS_BMNSQL()

        '20190612 CHG START
        ''WM_WLS_KeyNo = WM_WLS_BmnKey
        '''Oracle��, �󕶎��� "" �� Null�Ɖ��߂��邽��, �� " " �ɒu��������
        'Call BMNMTA_RClear()
        ''UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
        ''''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
        ''    WlsFromWhere = "From BMNMTA Where BMNCD = '" & Trim$(DB_TANMTA.TANBMNCD) & "'"
        ''    WlsFromWhere = WlsFromWhere & "and STTTKDT <= '" & DB_UNYMTA.UNYDT & "'"
        ''    WlsFromWhere = WlsFromWhere & "and ENDTKDT >= '" & DB_UNYMTA.UNYDT & "'"
        'WlsFromWhere = "From BMNMTA Where BMNCD = '" & AE_EditSQLText(Trim(DB_TANMTA.TANBMNCD)) & "'"
        'WlsFromWhere = WlsFromWhere & "and STTTKDT <= '" & AE_EditSQLText(DB_UNYMTA.UNYDT) & "'"
        'WlsFromWhere = WlsFromWhere & "and ENDTKDT >= '" & AE_EditSQLText(DB_UNYMTA.UNYDT) & "'"
        ''''' UPD 2009/12/03  FKS) T.Yamamoto    End
        'WlsOrderBy = "Order By BMNCD"
        'DB_SQLBUFF = "Select " & SWlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
        'Call DB_GetSQL2(WM_WLS_SFIL, DB_SQLBUFF)

        WlsFromWhere = "Where BMNCD = '" & AE_EditSQLText(Trim(DB_TANMTA.TANBMNCD)) & "'"
        WlsFromWhere = WlsFromWhere & "and STTTKDT <= '" & AE_EditSQLText(DB_UNYMTA.UNYDT) & "'"
        WlsFromWhere = WlsFromWhere & "and ENDTKDT >= '" & AE_EditSQLText(DB_UNYMTA.UNYDT) & "'"

        Call GetRowsCommon("BMNMTA", WlsFromWhere)
        '20190612 CHG END
    End Sub

    Private Sub WLS_DspNew()
        Dim WL_Mode As Short
        Dim cnt As Short

        WL_Mode = 0
        cnt = 0

        '20190612 CHG START
        'Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        '    'UPGRADE_WARNING: �I�u�W�F�N�g WLS_DSP_CHECK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    WL_Mode = WLS_DSP_CHECK()
        '    If WL_Mode = SSS_OK Then
        '        If cnt = 0 Then
        '            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '            WM_WLS_LastPage = WM_WLS_Pagecnt
        '            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '        End If
        '        Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        '        cnt = cnt + 1
        '    End If
        '    If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
        '        Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        '    End If
        'Loop
        'If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True

        Dim dt As DataTable = dsList.Tables("tableName")

        For Each row As DataRow In dt.Rows
            DB_TANMTA.TANCD = DB_NullReplace(row("TANCD"), "")
            DB_TANMTA.TANNM = DB_NullReplace(row("TANNM"), "")
            DB_TANMTA.TANBMNCD = DB_NullReplace(row("TANBMNCD"), "")

            '�\�����y�[�W
            If cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                cnt = 0
            End If

            '�\���������W�J
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)

            cnt = cnt + 1
        Next

        WM_WLS_LastFL = True
        '20190612 CHG END

        If cnt > 0 Then
            '20190612 ADD START
            WM_WLS_Pagecnt = 0
            '20190612 ADD END

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
            WLSKANA.Items.Add("�A�s      ��")
            WLSKANA.Items.Add("�J�s      ��")
            WLSKANA.Items.Add("�T�s      ��")
            WLSKANA.Items.Add("�^�s      ��")
            WLSKANA.Items.Add("�i�s      ��")
            WLSKANA.Items.Add("�n�s      ��")
            WLSKANA.Items.Add("�}�s      ��")
            WLSKANA.Items.Add("���s      ��")
            WLSKANA.Items.Add("���s      ��")
            WLSKANA.Items.Add("���s      ��")
        End If
    End Sub
    '
    '�ȉ��͉�ʃC�x���g����
    '
    'UPGRADE_WARNING: Form �C�x���g WLSTAN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub WLSTAN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190612 DEL START
        ''=== WINDOW �ʒu�ݒ� ===
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        ''UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'WM_WLS_STTKEY = ""
        ''UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'WM_WLS_ENDKEY = System.DBNull.Value
        'HD_TEXT.Text = ""
        'WM_WLS_Dspflg = False
        'WLSKANA.SelectedIndex = 0
        'HD_Kana.Text = ""
        'HD_TAN.Text = ""
        'HD_TANBMNCD.Text = ""
        'WM_WLS_Dspflg = True
        'WM_WLS_Pagecnt = -1
        'WM_WLS_LastPage = -1
        'WM_WLS_LastFL = False
        'ReDim WM_WLS_DSPArray(0)

        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        ''DblClick�C�x���g��Q�Ή�  97/04/07
        'DblClickFl = False
        '20190612 DEL END

    End Sub

    Private Sub WLSTAN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()
        Call WLS_Kana_Init()

        '20190612 ADD START
        '=== WINDOW �ʒu�ݒ� ===
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_STTKEY = ""
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        WM_WLS_ENDKEY = System.DBNull.Value
        HD_TEXT.Text = ""
        WM_WLS_Dspflg = False
        WLSKANA.SelectedIndex = 0
        HD_Kana.Text = ""
        HD_TAN.Text = ""
        HD_TANBMNCD.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_TextSQL()
        Call WLS_DspNew()

        'DblClick�C�x���g��Q�Ή�  97/04/07
        DblClickFl = False
        '20190612 ADD END

    End Sub

    '20190612 ADD START
    Private Sub WLSTAN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190612 ADD END

    Private Sub HD_TAN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TAN.Enter
        '''    If LenWid(HD_TAN.Text) > 0 Then
        '''        HD_TAN.Text = SSS_EDTITM_WLS(HD_TAN.Text, HD_TAN.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_TAN.Text = Space$(HD_TAN.MaxLength)
        '''    End If
        HD_TAN.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TAN.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TAN.SelectionLength = HD_TAN.Maxlength
    End Sub

    Private Sub HD_TAN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TAN.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            HD_TEXT.Text = ""
            HD_TANBMNCD.Text = ""
            WLSKANA.SelectedIndex = 0
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_TAN.Text
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = HD_TAN.Text
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_TANSQL()
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

    'UPGRADE_WARNING: �C�x���g HD_TANBMNCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TANBMNCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANBMNCD.TextChanged
        Dim s As Integer
        s = HD_TANBMNCD.SelectionStart
        HD_TANBMNCD.Text = StrConv(HD_TANBMNCD.Text, VbStrConv.Uppercase)
        HD_TANBMNCD.SelectionStart = s
    End Sub

    Private Sub HD_TANBMNCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANBMNCD.Enter
        ''    If LenWid(HD_TANBMNCD.Text) > 0 Then
        ''        HD_TANBMNCD.Text = SSS_EDTITM_WLS(HD_TANBMNCD.Text, HD_TANBMNCD.MaxLength, WM_WLSKEY_ZOKUSEI_BMN)
        ''    Else
        ''        HD_TEXT.Text = Space$(HD_TANBMNCD.MaxLength)
        ''    End If
        HD_TANBMNCD.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TANBMNCD.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TANBMNCD.SelectionLength = HD_TANBMNCD.Maxlength
    End Sub

    Private Sub HD_TANBMNCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANBMNCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        ' === 20081010 === INSERT S - RISE)Izumi �A���[No.:FC08101001
        Dim strTANBMNCD As New VB6.FixedLengthString(6)
        ' === 20081010 === INSERT E - RISE)Izumi

        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            ' === 20081010 === UPDATE S - RISE)Izumi �A���[No.:FC08101001
            '        HD_TANBMNCD.Text = SSS_EDTITM_WLS(HD_TANBMNCD.Text, HD_TANBMNCD.MaxLength, WM_WLSKEY_ZOKUSEI_BMN)
            strTANBMNCD.Value = Trim(HD_TANBMNCD.Text)
            HD_TANBMNCD.Text = strTANBMNCD.Value
            ' === 20081010 === UPDATE E - RISE)Izumi
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_TANBMNCD.Text
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = System.DBNull.Value
            WLSKANA.SelectedIndex = 0
            HD_Kana.Text = ""
            HD_TAN.Text = ""
            HD_TEXT.Text = ""
            WM_WLS_Dspflg = True
            WM_WLS_Pagecnt = -1
            WM_WLS_LastPage = -1
            WM_WLS_LastFL = False
            ReDim WM_WLS_DSPArray(0)

            Call WLS_TANBMNSQL()
            Call WLS_DspNew()
        End If
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TEXT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TEXT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.TextChanged
        Dim s As Integer
        s = HD_TEXT.SelectionStart
        HD_TEXT.Text = StrConv(HD_TEXT.Text, VbStrConv.Uppercase)
        HD_TEXT.SelectionStart = s
    End Sub

    Private Sub HD_TEXT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TEXT.Enter
        '''    If LenWid(HD_TEXT.Text) > 0 Then
        '''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        '''    Else
        '''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
        '''    End If
        HD_TEXT.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_TEXT.SelectionLength = HD_TEXT.Maxlength
    End Sub

    Private Sub HD_TEXT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TEXT.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KEYCODE = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_TEXT.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.Maxlength, WM_WLSKEY_ZOKUSEI)
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = HD_TEXT.Text
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_ENDKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_ENDKEY = System.DBNull.Value
            WLSKANA.SelectedIndex = 0
            HD_Kana.Text = ""
            HD_TANBMNCD.Text = ""
            HD_TAN.Text = ""
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
        '20190612 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190612 CHG END

    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Select Case KEYCODE
            Case System.Windows.Forms.Keys.Return
                '20190612 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190612 CHG END

            Case System.Windows.Forms.Keys.Escape
                '20190612 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190612 CHG END

            Case System.Windows.Forms.Keys.Left '���L�[
                '20190612 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190612 CHG END

            Case System.Windows.Forms.Keys.Right '���L�[
                '20190612 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190612 CHG END

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
            HD_TAN.Text = ""
            HD_TANBMNCD.Text = ""
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
            'UPGRADE_WARNING: �I�u�W�F�N�g WM_WLS_STTKEY �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_STTKEY = VB6.Format(HD_TEXT.Text)
            Call WLS_TextSQL()
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

    '20190612 CHG START
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

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

        If LST.Items.Count <= 0 Then Exit Sub

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190612 CHG END

    '20190612 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_TAN.Focused Then
                Call HD_TAN_KeyDown(HD_TAN, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_TANBMNCD.Focused Then
                Call HD_TANBMNCD_KeyDown(HD_TANBMNCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
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
            Me.HD_TAN.Text = ""
            Me.HD_TANBMNCD.Text = ""
            Me.HD_Kana.Text = ""
            LST.Items.Clear()
            Me.HD_TEXT.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190612 ADD END

    '20190612 CHG START
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

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190612 CHG END

    '20190612 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '    'UnLoad�C�x���g��Q�Ή�  97/04/07
    '    'Unload Me
    '    Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Call WLS_SLIST_MOVE(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_LEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        'UnLoad�C�x���g��Q�Ή�  97/04/07
        'Unload Me
        Hide()
    End Sub
    '20190612 CHG END

End Class