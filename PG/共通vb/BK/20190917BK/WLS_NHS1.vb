Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSNHS1
    Inherits System.Windows.Forms.Form
    '********************************************************************************
    '*  �V�X�e�����@�@�@�F  �V�������V�X�e��
    '*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
    '*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
    '*  �v���O�������@�@�F�@�[���挟��
    '*  �v���O�����h�c�@�F  WLSNHS
    '*  �쐬�ҁ@�@�@�@�@�F�@ACE)����
    '*  �쐬���@�@�@�@�@�F  2006.05.15
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD�@�F�@�C�����
    '*     �C����
    '********************************************************************************

    '************************************************************************************
    '   Public�ϐ�
    '************************************************************************************
    '�߂�l

    '************************************************************************************
    '   Private�萔
    '************************************************************************************

    ' === 20060730 === UPDATE S - ACE)Nagasawa
    '    Private Const WM_WLSKEY_ZOKUSEI = "0"       '�J�n�R�[�h���͑��� [0,X]
    Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
    ' === 20060730 === UPDATE E -

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '�J�n���ޓ��͕�����
    Private WM_WLS_NAMELEN As Short '�[���於�����͕�����

    '�E�B���h�����g�p�ϐ�
    Private WM_WLS_MAX As Short '�P��ʂ̕\������
    Private WM_WLS_CODE As String '�[����R�[�h�����p
    Private WM_WLS_NHSNK As String '�[���於���̌����p
    Private WM_WLS_NHSNK_S As String '�[���於�̃J�i�����p(�J�n)
    Private WM_WLS_NHSNK_E As String '�[���於�̃J�i�����p(�I��)
    Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
    Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
    Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
    Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
    Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)

    Private DblClickFl As Boolean

    'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    'Private Usr_Ody As U_Ody '�ް��ް����ð���
    Private DB_NHSMTAT_W As TYPE_DB_NHSMTA '�������ʑޔ�
    Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_FORM_INIT
    '   �T�v�F  ��ʏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()

        '=== �\���J�n�R�[�h�����ݒ� ===
        WM_WLS_CODELEN = 9
        WM_WLS_NAMELEN = 40
        WM_WLS_MAX = 15 '��ʕ\������
        '�ϐ�������
        WLSNHSMTA_RTNCODE = ""
        Call WLS_Clear()
        Dyn_Open = False

    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_SetArray
    '   �T�v�F  ���X�g�ҏW
    '   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
        '====================================
        '   WINDOW ���אݒ�
        '====================================
        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_NHSMTAT_W.NHSCD, WM_WLS_CODELEN) & Space(6) & LeftWid(DB_NHSMTAT_W.NHSRN, WM_WLS_NAMELEN) & Space(2) & DB_NHSMTAT_W.NHSTL

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_TextSQL
    '   �T�v�F  ����sql�쐬
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_TextSQL()

        Dim strSQL As String
        Dim intData As Short

        strSQL = ""
        strSQL = strSQL & " Select NHSCD " '�[����R�[�h
        strSQL = strSQL & "      , NHSRN " '�[���旪��
        strSQL = strSQL & "      , NHSTL " '�[����X�֔ԍ�
        strSQL = strSQL & "   from NHSMTA "
        ' === 20060814 === UPDATE S - ACE)Nagasawa
        '        strSQL = strSQL & "  Where DATKB = '1' "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "
        ' === 20060814 === UPDATE E -

        '�[����R�[�h����
        If Trim(WM_WLS_CODE) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
            '            strSQL = strSQL & "    and NHSCD >=   '" & WM_WLS_CODE & "'"
            strSQL = strSQL & "    and NHSCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
            ' === 20080929 === UPDATE E -
        End If

        '�[���旪�̌���(�����܂�����)
        If Trim(WM_WLS_NHSNK) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
            '            strSQL = strSQL & "    and NHSRN LIKE '%" & WM_WLS_NHSNK & "%'"
            strSQL = strSQL & "    and NHSRN LIKE '%" & CF_Ora_String(WM_WLS_NHSNK, CF_Ctr_AnsiLenB(WM_WLS_NHSNK)) & "%'"
            ' === 20080929 === UPDATE E -
        End If

        '�[���於�̃J�i����
        If Trim(WM_WLS_NHSNK_S) <> "" Then
            strSQL = strSQL & "    and NHSNK >= '" & WM_WLS_NHSNK_S & "' And NHSNK < '" & WM_WLS_NHSNK_E & "'"
        End If

        '�\�[�g����
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_NHSNK_S) <> "" Then
            '�[���於�̃J�i�����̏ꍇ
            strSQL = strSQL & "   NHSRN "
            strSQL = strSQL & "  ,NHSCD "
        Else
            '�[����R�[�h����,�[���旪�̌���
            strSQL = strSQL & "   NHSCD "
        End If

        If Dyn_Open = True Then
            '�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        '20190319 CHG START
        ''DB�A�N�Z�X
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'dsList.Tables("tableName").Clear()
        DB_GetTable(strSQL)
        '20190319 CHG END

        Dyn_Open = True
        ' === 20060728 === INSERT S - ACE)Furukawa
        LST.Items.Clear()
        ' === 20060728 === INSERT E

    End Sub
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspNew
    '   �T�v�F  ���X�g�ҏW����(�������)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspNew()
        Dim Cnt As Integer

        Cnt = 0

        '20190319 CHG START 
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'�擾���e�ޔ�
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_NHSMTAT_W.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '�[����R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_NHSMTAT_W.NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '�[���旪��
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_NHSMTAT_W.NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '�[����X�֔ԍ�

        '	'�\�����y�[�W
        '	If Cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		Cnt = 0
        '		'�ŏI�y�[�W�ޔ�
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'�\���������W�J
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '	Cnt = Cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If Cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        ''�ŏI�f�[�^���B
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        '      End If
        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '�擾���e�ޔ�
            DB_NHSMTAT_W.NHSCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSCD"), "") '�[����R�[�h
            DB_NHSMTAT_W.NHSRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSRN"), "") '�[���旪��
            DB_NHSMTAT_W.NHSTL = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSTL"), "") '�[����X�֔ԍ�

            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '�\���������W�J
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

            Cnt = Cnt + 1

            'If Cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next
        '20190319 CHG END 

        If Cnt > 0 Then
            '�y�[�W��\��
            WM_WLS_Pagecnt = 0
            Call WLS_DspPage()
        End If

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspPage
    '   �T�v�F  ���X�g�ҏW����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspPage()
        Dim WL_Mode As Short
        Dim intCnt As Short

        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If

        LST.Items.Clear()
        intCnt = 0
        Do While intCnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
                LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
            End If
            intCnt = intCnt + 1
        Loop
        If LST.Items.Count > 0 Then
            LST.SelectedIndex = 0
            ' === 20061228 === INSERT S - ACE)Nagasawa
            On Error Resume Next
            ' === 20061228 === INSERT E -
            LST.Focus()
        End If
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_Kana_Init
    '   �T�v�F  �J�i�R���{�{�b�N�X������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Kana_Init()

        '�J�i���� Combo ������
        WLSKANA.Items.Add("�R�[�h")
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

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_Clear
    '   �T�v�F  �ϐ�������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()

        '��������
        WM_WLS_CODE = ""
        WM_WLS_NHSNK = ""
        WM_WLS_NHSNK_S = ""
        WM_WLS_NHSNK_E = ""

        '��ʕ\���y�[�W
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '�������ʕێ��z��
        ReDim WM_WLS_DSPArray(0)

    End Sub
    '
    '�ȉ��͉�ʃC�x���g����
    '
    'UPGRADE_WARNING: Form �C�x���g WLSNHS.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub WLSNHS_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190517 DEL START
        ''WINDOW �ʒu�ݒ�
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''���ڏ�����
        'Call WLS_Kana_Init()
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        'WLSKANA.SelectedIndex = 0
        'LST.Items.Clear()
        'WM_WLS_Dspflg = True

        'ReDim WM_WLS_DSPArray(0)

        ''������ԑS���\��
        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        'DblClickFl = False

        'Me.Refresh()
        '' === 20060821 === UPDATE S - ACE)Nagasawa
        ''        HD_CODE.SetFocus
        '' === 20061228 === INSERT S - ACE)Nagasawa
        'On Error Resume Next
        '' === 20061228 === INSERT E -
        'LST.Focus()
        '' === 20060821 === UPDATE E -
        '20190517 DEL END

    End Sub

    Private Sub WLSNHS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()

        '20190517 ADD START
        'WINDOW �ʒu�ݒ�
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '���ڏ�����
        Call WLS_Kana_Init()
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        WLSKANA.SelectedIndex = 0
        LST.Items.Clear()
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '������ԑS���\��
        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False

        Me.Refresh()
        ' === 20060821 === UPDATE S - ACE)Nagasawa
        '        HD_CODE.SetFocus
        ' === 20061228 === INSERT S - ACE)Nagasawa
        On Error Resume Next
        ' === 20061228 === INSERT E -
        LST.Focus()
        ' === 20060821 === UPDATE E -
        '20190517 ADD END

    End Sub

    '20190529 ADD START
    Private Sub WLSNHS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    '20190529 ADD END

    Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_CODE.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(HD_CODE.Text) > 0 Then
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
            '---------- 20061019 ACE MENTE START ----------
            '   Else
            '       HD_CODE.Text = Space$(HD_CODE.MaxLength)
            '---------- 20061019 ACE MENTE E N D ----------
        End If
        HD_CODE.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_CODE.SelectionLength = HD_CODE.Maxlength
    End Sub

    Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)

            '�����p�ϐ��Z�b�g
            Call WLS_Clear()
            WM_WLS_CODE = HD_CODE.Text

            '�����������N���A
            WLSKANA.SelectedIndex = 0
            HD_NAME.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    ' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
    Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    ' === 20070206 === UPDATE E -

    Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
        '---------- 20061019 ACE MENTE START ----------
        '   If LenWid(HD_NAME.Text) <= 0 Then
        '       HD_NAME.Text = Space$(HD_NAME.MaxLength)
        '   End If
        '---------- 20061019 ACE MENTE E N D ----------
        HD_NAME.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_NAME.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_NAME.SelectionLength = HD_NAME.Maxlength
    End Sub

    Private Sub HD_NAME_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NAME.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False

            '�����p�ϐ��Z�b�g
            Call WLS_Clear()
            WM_WLS_NHSNK = HD_NAME.Text

            '�����������N���A
            WLSKANA.SelectedIndex = 0
            HD_CODE.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick

        DblClickFl = True
        WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)

    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190529 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190529 CHG END

    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            'Enter�L�[����
            Case System.Windows.Forms.Keys.Return
                '20190529 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190529 CHG END

                'Escape�L�[����
            Case System.Windows.Forms.Keys.Escape
                '20190529 CHG START
                'WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190529 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190529 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190529 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190529 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190529 CHG END

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

        Call WLS_Clear()

        '�����p�ϐ��Z�b�g
        If WLSKANA.SelectedIndex > 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_NHSNK_S = VB.Left(W_BUF, 1)
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_NHSNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
            '�����������N���A
            HD_CODE.Text = ""
            HD_NAME.Text = ""

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If

    End Sub

    Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = True
            Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
        Else
            WM_WLS_Dspflg = False
        End If
    End Sub

    '20190529 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '    If LST.Items.Count <= 0 Then Exit Sub

    '    ' === 20060728 === DELETE S - ACE)Furukawa
    '    '    Call WLS_DspNew
    '    ' === 20060728 === DELETE E

    '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '        ' === 20060728 === UPDATE S - ACE)Furukawa
    '        'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
    '        ' === 20060728 === UPDATE ��
    '        If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '        ' === 20060728 === UPDATE E
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

        ' === 20060728 === DELETE S - ACE)Furukawa
        '    Call WLS_DspNew
        ' === 20060728 === DELETE E

        If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
            ' === 20060728 === UPDATE S - ACE)Furukawa
            'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
            ' === 20060728 === UPDATE ��
            If Not WM_WLS_LastFL Then Call WLS_DspNew()
            ' === 20060728 === UPDATE E
        Else
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190529 CHG END

    '20190521 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_NAME.Focused Then
                Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_CODE.Text = ""
            Me.HD_NAME.Text = ""
            LST.Items.Clear()
            Me.HD_CODE.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190521 ADD END

    '20190529 CHG START
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
    '20190529 CHG END

    '20190529 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '    WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '    If Dyn_Open = True Then
    '        '�N���[�Y
    '        'Call CF_Ora_CloseDyn(Usr_Ody)
    '        Dyn_Open = False
    '    End If

    '    Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        WLSNHSMTA_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click

        If Dyn_Open = True Then
            '�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub
    '20190529 CHG END

End Class