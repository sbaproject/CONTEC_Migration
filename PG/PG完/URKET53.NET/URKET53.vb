Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    '//* All Right Reserved Copy Right (C)  ������Еx�m�ʊ֐��V�X�e���Y
    '//***************************************************************************************
    '//*
    '//*�����́�
    '//* URKET53 ��������
    '//*
    '//*���o�[�W������
    '//* 1.00
    '//*
    '//*���쐬�ҁ�
    '//* FKS)
    '//*
    '//*��������
    '//* ���������̓��͉��
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t    | �X�V��        |���e
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 1.00     |          |FKS)           |�V�K�쐬Template12
    '//*          |2008/07/25|FKS)���c       |���ׂ�2�s�ȏ゠��󒍂ɑ΂��A�ԕi�o�^���s������
    '//*          |          |               |�󒍒������s���Ɩ{���o�͑Ώۂɂ���Ȃ��f�[�^��
    '//*          |          |               |��ʏ�ɏo�Ă��Ă��܂��̂��C��
    '//*          |2008/08/05|FKS)���c       |���͂��ꂽ�������ȍ~�̔���f�[�^���o�͂��Ȃ��悤�C��
    '//*          |2008/08/13|FKS)���c       |���[���ꂽ����ɑ΂���ԍ��`�F�b�N�̏C���E�ǉ�
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 2.00     |2008/08/22|RISE)�{��      |�����֘A�̏����������ɂ�����C��
    '//* 2.01     |2008/09/22|RISE)�{��      |
    '//* 2.02     |2008/10/08|RISE)�{��      |
    '//* 2.03     |2008/10/14|RISE)�{��      |�ԕi�s��Ή�
    '//* 2.04     |2008/10/17|RISE)�{��      |����v���O�����̏�Q���f�i�A���[��:664�j
    '//* 2.05     |2008/10/23|RISE)�{��      |���Ӑ�̖��̂��������̂��\������Ă��邪�{���Ȃ痪�̂�\������
    '//* 2.06     |2008/11/04|RISE)�X�c      |�@�`�F�b�N�֘A������
    '//           |          |               |�A���t���폜�ł���悤�ɕύX
    '//* 2.07     |2008/11/05|RISE)�X�c      |�@���������g�����ւ̍X�V�ɂ��ĕύX
    '//           |          |               |�A�������ݏ����̕ύX
    '//           |          |               |�B�������ݕ��@�̕ύX
    '//* 2.09     |2008/12/04|RISE)�X�c      |���������ɑO�����������c�z���}�C�i�X�̏ꍇ�̏����ǉ�
    '//* 2.10     |2008/12/09|RISE)�X�c      |����SQL �ύX
    '//* 2.11     |2008/12/12|RISE)�{��      |����SQL �ύX�i�����������������������ɓ���Ă����̂őO���ȑO���\������Ȃ��j
    '//* 2.12     |2009/01/09|RISE)�X�c      |��\���񂪕\������Ă��܂��Ă���̂ŏC��
    '//* 2.13     |2009/01/21|RISE)�{��      |���ו����̐U�������̓��̓`�F�b�N���s��
    '//*          |          |               |���z���͉�ʂŊ���������u��������Ă��܂�
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 3.00     |2009/03/10|FKS)���c       |�ԕi�o�^���s�����󒍂ɑ΂��P���������s�����ꍇ�A���P���Ƃ��̎��̕ԕi���R�[�h���o�͂��Ȃ��悤�C��
    '//* 3.01     |2009/03/19|RISE)�{��      |���z�����o�^�̉�ʂɂāA���s���G���[���N����B
    '//* 3.02     |2009/03/19|RISE)�{��      |��ʃ��x�����ڂɃJ�[�\�����J�ڂł���B�i��ʂɃs�N�`���[�{�b�N�X��\��t���Đ�����s���j
    '//* 3.10     |2009/03/19|RISE)�{��      |�E�U�������ύX�����́A��������ˍď����̏����i�����s�d�l�j�Ƃ���B
    '//* 3.10     |2009/03/19|RISE)�{��      |�E������ʍ��ݎ��A�����݂̗D�揇�ʂ͈ȉ��̏��ԂƂ���B
    '//*          |          |               |  �@���E���A����Ł��B�萔�����C�������D�U�����E��`���F�U�������G�l�������H��
    '//* 3.10     |2009/03/19|RISE)�{��      |�E���������c�z���}�C�i�X�ɂȂ�ꍇ�A�����I�Ƀ[���Ƃ��Ȃ��B
    '//* 3.10     |2009/03/19|RISE)�{��      |�E������ʂɁu��`�v�u�U�������i�t�@�N�^�����O�j�v������ꍇ�A�U������
    '//*          |          |               |  �͓��͉\�Ƃ���B�������퍬�ݎ��́A���͕��ɂ��u��`�v�u����
    '//*          |          |               |�@�U���i�t�@�N�^�����O�j�v�s�̂ݗL���Ƃ���B
    '//* 3.20     |2009/03/24|RISE)�{��      |�E�{�����ɐU�ւ����A�����z�������ɕύX����K�v���ɂ��A��������
    '//*          |          |               |  �Ɛ����������Ă��邩�m�F���K�v�
    '//* 3.30     |2009/06/12|FKS)���c       |�E���z�����T�u��ʂ��N����A���׍s�ɂă`�F�b�N�������Ă�����̂�
    '//*          |          |�@�@�@�@�@�@�@ |�@�����\�z�ɂ����f������
    '//* 3.40     |2009/07/17|FKS)���c       |�E�ԕi���̍X�V�p�C���f�b�N�X�̎擾���W�b�N�̏C��
    '//* 3.50     |2009/08/07|FKS)���c       |�E�ԕi���̕s��C���@(RISE)�{���a�w����)
    '//* �@�@�@�@ |          |               |�E���������X�V�̏��������i�������z�z��߂��j
    '//* 3.60     |2009/08/26|FKS)���c       |�E�ԕi���̕s��C���@(RISE)�{���a�w����)
    '//* 3.70     |2009/09/03|RISE)�{��      |�E�ԕi�f�[�^�͊��Ԏw��Ɋ֌W�Ȃ��펞��ʕ\�������d�l�ɂȂ��Ă���
    '//*          |          |               |�E�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
    '//*          |          |               |�E���Ԕ���σf�[�^�̓�������������s�����ꍇ�A�G���[���\������邩�B
    '//*          |          |               |�E���������̃f�[�^��ʕ\���ɂ��āu�Ή��Ȃ��v�̉񓚂�����肠�肻���ł���B
    '//*          |          |               |�E�����o�^���A�S���҂��c�ƒS���ł��邱�Ƃ̃`�F�b�N���K�v
    '//*          |2009/09/08|RISE)�{��      |�E�ԕi�f�[�^�͊��Ԏw����Ƀy�A�ő��݂��Ȃ��ꍇ�͕\�����Ȃ��悤�ɂ���
    '//*          |          |               |�E�ԕi�f�[�^�̏����͋���P�ʂł͂Ȃ��P���R�[�h�ŏ�������
    '//*          |2009/09/10|RISE)�{��      |�E���X�|���X�Ή��Ɗ������Ă���ԍ��y�A�͕\�����Ȃ�
    '//*          |2009/09/15|RISE)�{��      |�E�ԕi���̏������ݕ��@�̕ύX
    '//*          |          |               |�E���������T�}���[�̖{�������ڂɑ΂��ĉ����X�V���Ȃ��悤�ɂ���
    '//*          |          |               |�E�O���������̓��������T�}���[�̖߂���ύX�i�����������j
    '//*          |          |               |�E����̐������������Ӑ�̐��������̎����z���ύX����Ă�����G���[
    '//*          |2009/09/18|RISE)�{��      |�E�萔���A����ł̎�舵���ύX�Ή�
    '//*          |2009/09/23|RISE)�{��      |�E��`�̏������݂̎��Ɏ�`�������ڂ��X�V����Ȃ�
    '//*          |2009/09/24|RISE)�{��      |�E���z��ʂ�蕜�A���c�z���������\������Ȃ�
    '//*          |2009/09/27|RISE)�{��      |�E�w�������ߌ��ȍ~�̖��ׂ�\�����Ȃ��x�͎~�߂�
    '//*          |          |               |�E�w����̐������������Ӑ�̐��������̎����z���ύX����Ă�����G���[�x�͎~�߂�
    '//*          |          |               |�E�U�������̃��b�N������s��
    '//*          |          |               |�E��ʕ\�����X�|���X�̉��P�i�U�������̓�����@�̕ύX�j
    '//*          |2009/09/29|RISE)�{��      |�E����9999�𒴂����ꍇ�ɃG���[���b�Z�[�W��\�����w�b�_�[�ɖ߂�
    '//*          |2009/10/01|RISE)�{��      |�E�`�F�b�N�����Ӑ�}�X�^�̎x������SHAKB[256]�̂ݐU���������\�������悤�ɂȂ��Ă�����
    '//*          |          |               |�@�w�b�_�[�̐U�����������͂���Ă���ꍇ�ɕ\������
    '//*          |2009/10/01|RISE)�{��      |�E�������(03��`)�̏ꍇ�A��������������������
    '//*          |2009/10/06|RISE)�{��      |�E�������ݎ��������݋��z�����z����Ə������݉�������邪���z���ꂽ���z�̃��R�[�h���쐬����Ȃ�
    '//*          |2009/10/22|RISE)�{��      |�E���z������ʂœ����z����͂��Ă������ɋ��z���������\������Ȃ�
    '//*          |2009/10/22|RISE)�{��      |�E�������A�c�z�ƕs��v�̏������݂����������ꍇ�G���[��\������
    '//*          |2009/11/02|RISE)�{��      |�E����������ʁi���z�����o�^�j�̐U�������̐ݒ���@�ύX
    '//*          |2009/11/02|RISE)�{��      |�E�ꕔ�������ŐU���������ݒ肳��Ă���ꍇ�̓��������g�����̐U�������̐ݒ���@�ύX
    '//* ---------|----------|---------------|-----------------------------------------------
    '//* 4.00     |2010/07/21|FKS)�R�{       |��ʂ̕\�����e��CSV�ɏo�͂���{�^����ǉ�
    '//* 4.01     |2010/09/28|FKS)�R�{       |�������̕ԕi����������ς݃f�[�^�ł����Ă��P����������Ă�����\�����Ȃ�
    '//* 4.02     |2010/10/19|FKS)�R�{       |�ԕi�̐ԍ��`�F�b�N�ƕԕi��A�󒍒��������̐ԍ��`�F�b�N�̃p�����[�^��TOKSEICD��ǉ�
    '//* 4.03     |2011/06/13|FKS)�R�{       |�ԕi��A�󒍒��������̐ԍ��`�F�b�N�̃p�����[�^��DATNO��ǉ�
    '//**************************************************************************************

    Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
    Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    �A���[��CF10042801
    Private Declare Function IsDBCSLeadByte Lib "kernel32" (ByVal TestChar As Byte) As Boolean
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    Dim intUrigoukei As Decimal '������z�̍��v���i�[�i���ו\�����ɃZ�b�g�j
    Dim intBfkesiknkei As Decimal '�����ϊz(�����O)�̍��v�z���i�[�i���ו\�����ɃZ�b�g�j

    '// V3.10�� UPD
    'Dim blnFriEnabled   As Boolean      '�U����������͂ł��邩�ǂ����̃t���O(����͐�����I����)
    Dim blnFriEnabled As Boolean '�U����������͂ł��邩�ǂ����̃t���O(����́u��`�v�u�U�������i�t�@�N�^�����O�j�v�����݂��鎞�j
    '// V3.10�� UPD

    Dim blnUsableSpread As Boolean '���گ�ނ̲���Ă����s���邩�ǂ������׸�
    Dim intMaxRow As Short '���گ�ނ̕\���ő�s�����i�[

    Dim blnUsableButton As Boolean '�萔���A����ō��z�A�S�����A�S�����A�ĕ\���A�U������(���ו�)�̲���Ă����s���邩�ǂ������׸�
    Dim intChkKb As Short '�`�F�b�N�敪(1:�`�F�b�N 2:�`�F�b�N(�O�񂩂�ύX���̂�)
    Dim blnUsableEvent As Boolean '����Ă����s���邩�ǂ������׸�(�ėp)
    Dim blnINIT_FLG As Boolean

    '// V2.00�� ADD
    Dim intInputMode As Short '���͏��(1:�w�b�_�[ 2:���� 9:��ʃN���A�[����)
    '// V2.00�� ADD


    '2008/07/30 DEL START FKS)NAKATA
    'XX '2007/12/05 FKS)minamoto ADD START
    'XX Private HAITA_UDNTRA()      As TYPE_HAITA_UPDDT
    'XX Private HAITA_JDNTRA()      As TYPE_HAITA_UPDDT
    '2007/12/05 FKS)minamoto ADD END
    '2008/07/30 DEL START FKS)NAKATA


    '2008/08/13 ADD START FKS)NAKATA
    ''�ԍ��`�F�b�N�p�\����
    Private Structure TYPE_AKAKRO_CHK
        Dim idx As Integer '�s�ԍ�
        Dim CHKMK As Short '�`�F�b�N�}�[�N
        Dim UDNDT As String '�����
        Dim JDNNO As String '�󒍇�
        Dim kesikn As Decimal '�������z
    End Structure

    Private AKAKRO_CHK() As TYPE_AKAKRO_CHK
    '2008/08/13 ADD START FKS)NAKATA

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    �A���[��CF10042801
    'INI�t�@�C���Ǎ��p�萔
    Private Const pc_strIni_OUTNAME As String = "OUT_NAME"
    Private Const pc_strIni_OUTTYPE As String = "OUT_TYPE"
    Private Const pc_strIni_TABCHAR As String = "TAB_CHAR"

    'INI�t�@�C���Ǎ����e�i�[�ϐ�
    Public gv_strOUT_NAME As String '�o�̓t�@�C����
    Public gv_strOUT_TYPE As String '�o�̓t�@�C���g���q
    Public gv_strTAB_CHAR As String '��؂蕶��
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End




    '�t�H�[�����[�h�C�x���g
    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'WINDOW �ʒu�ݒ�
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        '���[�J���ϐ�������
        intUrigoukei = 0
        intBfkesiknkei = 0
        intMaxRow = 0
        intChkKb = 2

        blnFriEnabled = False
        blnUsableSpread = False
        blnUsableButton = False
        blnUsableEvent = True

        '��DB�ւ̐ڑ�
        '2019/04/18 CHG START
        'If CF_Ora_USR1_Open() = False Then
        '    MsgBox("DB�̐ڑ��Ɏ��s���܂����B", MsgBoxStyle.Critical, "�ڑ��G���[")
        'End If
        CON = DB_START()
        '2019/04/18 CHG E N D

        'PG������
        '2019/04/26 CHG START
        Call CF_Init()
        'Call CF_Init_URKET53()
        '2019/04/26 CHG E N D

        '��ʏ�����
        initForm()
        initCondition()
        initHead()
        initBody()

        '// V2.00�� ADD
        intInputMode = 1

        '�V�X�e�����ʏ���
        Call CF_System_Process(Me)
        '// V2.00�� ADD

        '2019/04/26 ADD START
        'Call UNYMTA_GetFirst()
        Call GetRowsCommon("UNYMTA", "")
        SetBar(Me)
        '2019/04/26 ADD E N D

        '�����O�̏����o��
        Call SSSWIN_LOGWRT("�v���O�����N��")
    End Sub

    '�t�H�[���A�����[�h�C�x���g
    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        '���I���m�F��MSG
        '// V2.00�� UPD
        ''    If blnUsableButton = True Then
        ''        If showMsg("0", "_ENDCK", 0) = vbNo Then
        ''            Cancel = vbCancel
        ''            Exit Sub
        ''        End If
        ''    Else
        ''        If showMsg("0", "_ENDCM", 0) = vbNo Then
        ''            Cancel = vbCancel
        ''            Exit Sub
        ''        End If
        ''    End If
        If ChkInputChange() = True Then
            If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                'add 20190809 START hou
                eventArgs.Cancel = Cancel
                'add 201908090 END hou
                Exit Sub
            End If
        Else
            If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                'add 201908090 START hou
                eventArgs.Cancel = Cancel
                'add 201908090 END hou
                Exit Sub
            End If
        End If
        '// V2.00�� UPD

        '2007/12/11 FKS)minamoto ADD START
        '�r�������폜

        'NAKATA
        'XX    Call Execute_PLSQL_PRC_URKET53_03
        '2007/12/11 FKS)minamoto ADD END

        '20091227��DEL
        '    '�r���e�[�u���폜
        '    Call SSSEXC_EXCTBZ_CLOSE
        '20091227��DEL

        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
        Call SSSWIN_Unlock_EXCTBZ()
        '�r���e�[�u���폜
        Call SSSEXC_EXCTBZ_CLOSE()
        ' === 20130708 === INSERT E -

        'DB�̐ڑ���ؒf
        '2019/04/18 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        ''// V2.00�� ADD
        'Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)
        ''// V2.00�� ADD
        DB_CLOSE(CON)
        '2019/04/18 CHG E N D
        '�����O�̏����o��
        Call SSSWIN_LOGWRT("�v���O�����I��")

        End '��PG�I��
        eventArgs.Cancel = Cancel
    End Sub

    ' === 20130708 === DELETE S - FWEST)Koroyasu �r������̉���
    ''20091227��ADD
    'Private Sub Form_Unload(Cancel As Integer)
    '
    '    '�r���e�[�u���폜
    '    Call SSSEXC_EXCTBZ_CLOSE
    '
    'End Sub
    ''20091227��ADD
    ' === 20130708 === DELETE E -


    '�t�H�[���̏�����
    Private Sub initForm()
        Dim ssBevelNone As Object
        Dim i As Short
        '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
        Dim strRet As String
        '''' ADD 2009/11/26  FKS) T.Yamamoto    End

        '�t�H�[���L���v�V�����Z�b�g
        Me.Text = SSS_PrgNm

        '�^�p���̎擾
        gstrUnydt.Value = getUnydt()
        '�O��o�������s���̎擾
        Call getSYSTBA()
        '''' UPD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
        '    '�����̎擾
        '    Call Get_Authority(gstrUnydt)
        '�����̎擾
        strRet = Get_Authority(gstrUnydt.Value)
        If strRet = "9" Then
            '�N�������Ȃ��̏ꍇ�A�����I��
            Call showMsg("2", "RUNAUTH", CStr(0))
            End
        End If
        '''' UPD 2009/11/26  FKS) T.Yamamoto    End

        '��ʉE��̍��ڂɉ^�p�����Z�b�g
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_unydt.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_unydt.Text = CNV_DATE(gstrUnydt.Value)

        '���͒S���҂��Z�b�g
        txt_opeid.Text = SSS_OPEID.Value
        txt_openm.Text = getTannm(SSS_OPEID.Value)

        txt_message.Text = ""

        '�����Œ�p�p�l�����B��
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_condition1.Text = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'pnl_condition1.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_condition2.Text = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'pnl_condition2.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D
        '�\������e�L�X�g�{�b�N�X�ݒ�p�p�l�����B��
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_hihyoji.Text = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_hihyoji.BevelOuter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g ssBevelNone �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/17 DEL START
        'pnl_hihyoji.BevelOuter = ssBevelNone
        '2019/04/17 DEL E N D

        '���گ�މB�����ڂ��\���ɂ���

        '// V2.02�� UPD
        ''''    If SHOW_HIDE_COLUMN_FLAG = False Then
        ''''        With spd_body
        ''''            .Row = -1
        ''''            '�����O���������ڂ���AJDNDATNO�܂ł��\���Ƃ���B
        '''''// V2.03�� UPD
        ''''            For i = COL_BFKESIKN To COL_HENPI
        ''''''''// V2.00�� UPD
        '''''''''            For i = COL_BFKESIKN To COL_JDNDATNO
        '''''''''            For i = COL_BFKESIKN To COL_BFCHECK
        '''''''            For i = COL_BFKESIKN To COL_KESIKN_MAE
        ''''''''// V2.00�� UPD
        '''''// V2.03�� UPD
        ''''                .Col = i
        ''''                .ColHidden = True
        ''''            Next i
        ''''        End With
        ''''    End If
        '// V2.02�� UPD

        '// V2.12�� ADD
        '2019/04/22 DEL START
        '���گ�މB�����ڂ��\���ɂ���
        'If SHOW_HIDE_COLUMN_FLAG = False Then
        '    With spd_body
        '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .Row = -1
        '        '2009/09/15 UPD START RISE)MIYAJIMA
        '        '            For i = COL_BFKESIKN To COL_HENPI
        '        For i = COL_BFKESIKN To COL_SSADT
        '            '2009/09/15 UPD E.N.D RISE)MIYAJIMA
        '            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .Col = i
        '            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ColHidden �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            .ColHidden = True
        '        Next i
        '    End With
        'End If
        '2019/04/22 DEL E N D

        '// V2.12�� ADD

    End Sub

    '���͏����̏�����
    Private Sub initCondition()

        Call initVal() '��۰��ٕϐ��̏�����

        txt_kesidt.Text = CNV_DATE(gstrUnydt.Value) '�^�p�����Z�b�g
        txt_kesidt.ForeColor = System.Drawing.Color.Black
        txt_kesidt.BackColor = System.Drawing.Color.White

        txt_tokseicd.Text = Space(5) '5byte space
        txt_tokseicd.ForeColor = System.Drawing.Color.Black
        txt_tokseicd.BackColor = System.Drawing.Color.White

        txt_tokseinma.Text = ""

        '// V2.00�� UPD
        '    txt_kaidt.Text = CNV_DATE(gstrUnydt)    '�^�p�����Z�b�g
        '    txt_kaidt.ForeColor = vbBlack
        '    txt_kaidt.BackColor = vbWhite
        txt_kaidt_From.Text = Space(10) '10byte space
        txt_kaidt_From.ForeColor = System.Drawing.Color.Black
        txt_kaidt_From.BackColor = System.Drawing.Color.White

        txt_kaidt_To.Text = CNV_DATE(gstrUnydt.Value) '�^�p�����Z�b�g
        txt_kaidt_To.ForeColor = System.Drawing.Color.Black
        txt_kaidt_To.BackColor = System.Drawing.Color.White
        '// V2.00�� UPD

        txt_kesikb.Text = CStr(1)

        blnFriEnabled = False
        '// V2.00�� UPD
        '    txt_fridt.Text = Space(8)               '8byte space
        txt_fridt.Text = Space(10) '10byte space
        '// V2.00�� UPD
        txt_fridt.ForeColor = System.Drawing.Color.Black
        txt_fridt.BackColor = System.Drawing.Color.White
        txt_fridt.Enabled = blnFriEnabled

        blnUsableButton = False
        blnUsableEvent = True

        '�I�v�V�������ڂ̐���
        frm_opt1.Visible = OPTION_SHOW_FLAG
        opt_sort(0).Checked = True
        lbl_shakbnm(0).Visible = OPTION_SHOW_FLAG
        lbl_shakbnm(1).Visible = OPTION_SHOW_FLAG
        lbl_shakbnm(1).Text = ""
        lbl_hytokkesdd(0).Visible = OPTION_SHOW_FLAG
        lbl_hytokkesdd(1).Visible = OPTION_SHOW_FLAG
        lbl_hytokkesdd(1).Text = ""
        '2019/04/26 DEL START
        'bar21.Visible = OPTION_SHOW_FLAG
        'mnu_zenkesi.Visible = OPTION_SHOW_FLAG
        'mnu_zenkaijo.Visible = OPTION_SHOW_FLAG
        'mnu_zenkesi.Enabled = blnUsableButton
        'mnu_zenkaijo.Enabled = blnUsableButton
        '2019/04/26 DEL E N D
    End Sub

    '�w�b�_��(�������)�̏�����
    Private Sub initHead()
        txt_urigoukei.Text = CStr(0)
        txt_nyukin.Text = CStr(0)
        txt_tesuryo.Text = CStr(0)
        txt_syohi.Text = CStr(0)
        txt_nyugoukei.Text = CStr(0)
        txt_kesizan.Text = CStr(0)
        intUrigoukei = 0
        intBfkesiknkei = 0
    End Sub

    '���ו��̏�����
    Private Sub initBody()
        Dim ActionSelectBlock As Object
        Dim ActionClearText As Object
        '�������ͽ��گ�޲���Ă����s�����Ȃ�
        blnUsableSpread = False

        With spd_body
            '2019/04/22 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False

            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = -1
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = -1
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g ActionClearText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Action = ActionClearText

            ''�J�[�\���ʒu��擪�ɖ߂�
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g ActionSelectBlock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Action = ActionSelectBlock

            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MaxRows = 9999
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True

            '�`���~
            .SuspendLayout()

            '�J�[�\���ʒu��擪�ɖ߂�
            .Focus()
            .Template = Nothing
            '.RowCount = 0

            '�ĕ`��
            .ResumeLayout()
            '2019/04/22 CHG E N D
        End With

        intMaxRow = 0

        '���گ�޲���Ă̋���
        blnUsableSpread = True
    End Sub

    '���ו��̏���\��
    '2019/04/19 CHG START
    '    Private Sub showBody()
    '        Dim strSql As Object
    '        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody As U_Ody
    '        Dim tmp As Object
    '        '2007/12/10 FKS)minamoto ADD START
    '        Dim intRet As Short
    '        '2007/12/10 FKS)minamoto ADD END
    '        'ADD START FKS)INABA 2007/07/23 **************
    '        Dim lw_sort As Short
    '        'ADD  END  FKS)INABA 2007/07/23 **************
    '        '2008/1/10 FKS)ichihara ADD START
    '        Dim bleNextFlg As Boolean
    '        '2008/1/10 FKS)ichihara ADD END


    '        '2008/08/05 ADD START FKS)NAKATA
    '        Dim idxRow As Integer
    '        Dim strHYJDNNO As String
    '        '2008/08/05 ADD E.N.D FKS)NAKATA

    '        '// V2.00�� ADD
    '        Dim strTEGDT As String
    '        '// V2.00�� ADD

    '        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
    '        Dim rResult As Short ' �����`�F�b�N�֐��߂�l
    '        Dim strUDNDT As String
    '        ' === 20130708 === INSERT E

    '        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
    '        Call SSSWIN_Unlock_EXCTBZ()
    '        ' === 20130708 === INSERT E -

    '        '// V2.00�� ADD
    '        '�������ͽ��گ�޲���Ă����s�����Ȃ�
    '        blnUsableSpread = False

    '        ReDim ARY_UDNTRA_HAITA(0)
    '        ReDim ARY_JDNTRA_HAITA(0)
    '        '// V2.00�� ADD

    '        '�}�E�X�J�[�\���������v�ɂ���
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        '���׃f�[�^�擾�pSQL���쐬
    '        'CHG START FKS)INABA 2007/07/23 *******************************************************************************
    '        Select Case True
    '            Case opt_sort(0).Checked
    '                lw_sort = 0
    '            Case opt_sort(1).Checked
    '                lw_sort = 1
    '            Case opt_sort(2).Checked
    '                lw_sort = 2
    '        End Select
    '        '2009/09/10 UPD START RISE)MIYAJIMA
    '        ''// V2.00�� UPD
    '        ''    strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd, gstrKaidt, txt_kesikb.Text, lw_sort)
    '        '    strSql = getSQLforBody( _
    '        ''                            DB_SYSTBA.SMAUPDDT, _
    '        ''                            gstrTokseicd, _
    '        ''                            gstrKaidt_Fr, _
    '        ''                            gstrKaidt_To, _
    '        ''                            txt_kesikb.Text, _
    '        ''                            lw_sort)
    '        ''// V2.00�� UPD
    '        gstrTokseicd.Value = txt_tokseicd.Text
    '        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
    '        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
    '        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
    '        '2009/09/10 UPD E.N.D RISE)MIYAJIMA

    '        '    strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd, gstrKaidt, txt_kesikb.Text, opt_sort(0).Value)
    '        'CHG  END  FKS)INABA 2007/07/23 *******************************************************************************
    '        '�ް��擾
    '        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '2019/04/18 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '        Dim dt As DataTable = DB_GetTable(strSql)
    '        '2019/04/18 CHG E N D

    '        '�\�����ڏ�����
    '        initHead()
    '        initBody()

    '        '2008/07/30 DEL START FKS)NAKATA
    '        'XX    '2007/12/05 FKS)minamoto ADD START
    '        'XX    ' �r���X�V���t�N���A
    '        'XX
    '        'XX    ReDim HAITA_UDNTRA(0)
    '        'XX    ReDim HAITA_JDNTRA(0)
    '        'XX    '2007/12/11 FKS)minamoto ADD START
    '        'XX    '�r�������폜
    '        'XX
    '        'XX    Call Execute_PLSQL_PRC_URKET53_03
    '        'XX    '2007/12/11 FKS)minamoto ADD END
    '        'XX   '2007/12/05 FKS)minamoto ADD END
    '        '2008/07/30 DEL E.N.D FKS)NAKATA


    '        '// V2.00�� UPD
    '        '�������ͽ��گ�޲���Ă����s�����Ȃ�
    '        blnUsableSpread = False
    '        '// V2.00�� UPD

    '        With spd_body
    '            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '2019/04/19 DEL START
    '            '.ReDraw = False
    '            '2019/04/19 DEL E N D
    '            '2019/04/18 CHG START
    '            'Do While CF_Ora_EOF(Usr_Ody) = False
    '            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
    '                For cnt As Integer = 0 To dt.Rows.Count - 1
    '                    '2019/04/18 CHG E N D

    '                    '2008/1/10 FKS)ichihara ADD START
    '                    '�\��t����f�[�^���ԕi�f�[�^�̏ꍇ����f�[�^������
    '                    bleNextFlg = True

    '                    '2008/07/25 DEL START FKS)NAKATA
    '                    '            If CF_Ora_GetDyn(Usr_Ody, "AKAKROKB", "") = "9" Then
    '                    '                If getKuroTbl(Trim$(CF_Ora_GetDyn(Usr_Ody, "jdnno", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "HENSTTCD", "")), _
    '                    ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "udndt", ""))) = False Then
    '                    '
    '                    '                    '�f�[�^�̕\�����s��Ȃ�
    '                    '                    bleNextFlg = False
    '                    '                End If
    '                    '            End If
    '                    '2008/07/25 DEL E.N.D FKS)NAKATA


    '                    '2008/07/25 ADD START FKS)NAKATA
    '                    '''' UPD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
    '                    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    '                    ''�ԕi�̐ԍ��`�F�b�N�̃p�����[�^��RECNO,URITK,WRTFSTDT,WRTFSTTM��ǉ�
    '                    '
    '                    '            'XX �ԕi�̐ԍ��`�F�b�N
    '                    ''            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
    '                    '
    '                    '
    '                    '            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), _
    '                    ''                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
    '                    ''V3.00 2009/03/10 CHG E.N.D FKS)NAKATA
    '                    '�ԕi�̐ԍ��`�F�b�N�̃p�����[�^��TOKSEICD��ǉ�
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    '2019/04/18 CHG START
    '                    'If chkHenpin(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", ""))) = False Then
    '                    If chkHenpin(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("RECNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTTM"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URITK"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), ""))) = False Then
    '                        '2019/04/18 CHG E N D
    '                        '''' UPD 2010/10/19  FKS) T.Yamamoto    End

    '                        '�f�[�^�̕\�����s��Ȃ�
    '                        bleNextFlg = False
    '                    Else
    '                        bleNextFlg = True
    '                    End If
    '                    '2008/07/25 ADD E.N.D FKS)NAKATA

    '                    '2008/07/26 ADD START FKS)NAKATA
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    '2019/04/18 CHG START
    '                    'If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
    '                    If Trim(DB_NullReplace(dt.Rows(cnt)("HENRSNCD"), "")) = "" Then
    '                        '2019/04/18 CHG E N D
    '                        'XX �ԕi��A�󒍒��������̐ԍ��`�F�b�N
    '                        '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    �A���[��830
    '                        ''''' UPD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
    '                        ''                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
    '                        '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
    '                        '                '�p�����[�^��TOKSEICD��ǉ�
    '                        '                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
    '                        ''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", ""))) = False Then
    '                        ''''' UPD 2010/10/19  FKS) T.Yamamoto    End
    '                        '�p�����[�^��DATNO��ǉ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        'If chkHenpinTeisei(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))) = False Then
    '                        If chkHenpinTeisei(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("LINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))) = False Then
    '                            '2019/04/18 CHG E N D
    '                            '''' UPD 2011/06/13  FKS) T.Yamamoto    End

    '                            '�f�[�^�̕\�����s��Ȃ�
    '                            bleNextFlg = False
    '                        Else
    '                            bleNextFlg = True
    '                        End If
    '                    End If
    '                    '2008/07/26 ADD E.N.D FKS)NAKATA

    '                    '2008/08/05 ADD START FKS)NAKATA
    '                    ''���͂��ꂽ�������ȍ~�̔���f�[�^���o���Ȃ�

    '                    If bleNextFlg = False Then
    '                        bleNextFlg = False

    '                    Else
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        'If Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) > 0 Then
    '                        If Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) > 0 Then
    '                            '2019/04/18 CHG E N D

    '                            '���f�[�^�œ��͂��ꂽ����������̔���͕\�����Ȃ�
    '                            bleNextFlg = False

    '                            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            '2019/041/18 CHG START
    '                            'ElseIf Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) < 0 Then
    '                        ElseIf Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) < 0 Then
    '                            '2019/04/18 CHG E N D

    '                            '�ԕi�̏ꍇ�́A���ɉ�ʏ�ɓ����󒍔ԍ������݂��邩���m�F����B
    '                            With spd_body
    '                                For idxRow = intMaxRow To 1 Step -1
    '                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                                    '2019/04/19 CHG START
    '                                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
    '                                    tmp = .GetValue(idxRow, COL_HYJDNNO)
    '                                    '2019/04/19 CHG E N D

    '                                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                                    strHYJDNNO = CStr(tmp)

    '                                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                                    '2019/04/18 CHG START
    '                                    'If Trim(strHYJDNNO) = Trim(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
    '                                    If Trim(strHYJDNNO) = Trim(DB_NullReplace(dt.Rows(cnt)("HY_JDNNO"), "")) Then
    '                                        '2019/04/18 CHG E N D

    '                                        '��ʏ�ɍ�������Ώo��
    '                                        bleNextFlg = True
    '                                        Exit For
    '                                    Else
    '                                        bleNextFlg = False
    '                                    End If
    '                                Next idxRow
    '                            End With
    '                        Else
    '                            bleNextFlg = True

    '                        End If
    '                    End If
    '                    '2008/08/05 ADD E.N.D FKS)NAKATA

    '                    ''2009/09/10 DEL START RISE)MIYAJIMA
    '                    ''// V2.13�� ADD
    '                    '            '//�\�����f�`�F�b�N
    '                    ''2009/09/08 UPD START RISE)MIYAJIMA
    '                    '''2009/09/03 ADD START RISE)MIYAJIMA
    '                    ''            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And Trim$(CF_Ora_GetDyn(Usr_Ody, "AKAKROKB", "")) = "9" Then
    '                    '''2009/09/03 ADD E.N.D RISE)MIYAJIMA
    '                    ''                If chkHenpin2(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
    '                    ''                    bleNextFlg = False
    '                    ''                End If
    '                    '''2009/09/03 ADD START RISE)MIYAJIMA
    '                    ''            End If
    '                    '''2009/09/03 ADD E.N.D RISE)MIYAJIMA
    '                    ''            If chkDspData(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "KOMIKN", "")), _
    '                    '''                          Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKN", ""))) = False Then
    '                    ''                bleNextFlg = False
    '                    ''            End If
    '                    ''2009/09/08 UPD E.N.D RISE)MIYAJIMA
    '                    ''// V2.13�� ADD
    '                    '2009/09/10 DEL E.N.D RISE)MIYAJIMA

    '                    If bleNextFlg = True Then
    '                        '2008/1/10 FKS)ichihara ADD END

    '                        intMaxRow = intMaxRow + 1

    '                        '2009/09/29 ADD START RISE)MIYAJIMA
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        If intMaxRow > .MaxRows Then
    '                            Exit Do
    '                        End If
    '                        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '                        '�X�v���b�h�Ɏ擾�����f�[�^��\��
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

    '                        .Row = intMaxRow
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_NO 'No.
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = intMaxRow

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_NXTKB '���[
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_HYUDNDT '�����
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_udndt"), "")
    '                        '2019/04/18 CHG E N D
    '                        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        strUDNDT = .Text
    '                        ' === 20130708 === INSERT E -

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_HYJDNNO '�󒍔ԍ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), "")
    '                        '2019/04/18 CHG E N D
    '                        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        If .Text <> "" Then
    '                            '�r���`�F�b�N
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(.Text, 6))


    '                            Select Case rResult
    '                            '����
    '                                Case 0

    '                                '�r��������
    '                                Case 1
    '                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                                    MsgBox("���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & intMaxRow & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & .Text)
    '                                    Call SSSWIN_Unlock_EXCTBZ()
    '                                    initBody()
    '                                    GoTo STEP10_ShowBody

    '                                '�ُ�I��
    '                                Case 9
    '                                    Call showMsg("2", "URKET53_034 ", CStr(0)) '�X�V�ُ�
    '                                    Call SSSWIN_Unlock_EXCTBZ()
    '                                    initBody()
    '                                    GoTo STEP10_ShowBody
    '                            End Select
    '                        End If
    '                        ' === 20130708 === INSERT E -

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/19 CHG START
    '                        .Col = COL_HYKAIDT '����\���
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/40/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("hy_kaidt"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TOKJDNNO '�q�撍���ԍ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("tokjdnno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TANNM '�c�ƒS����
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("tannm"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_URIKN '�Ŕ�������z
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("urikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_UZEKN '����Ŋz
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("uzekn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_KOMIKN '�ō�������z
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("komikn"), "")
    '                        '2019/04/18 CHG E N D
    '                        '���v���z���v�Z
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        intUrigoukei = intUrigoukei + SSSVal(.Text)

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_KESIKN '�����ϊz
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("kesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_MINYUKN '�������z(��\��)
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
    '                        .Text = DB_NullReplace(dt.Rows(cnt)("kesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        '2009/09/27 UPD START RISE)MIYAJIMA
    '                        '2009/09/27 UPD START RISE)MIYAJIMA
    '                        '                '�U�������̎擾
    '                        '                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        'strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    '                        strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")
    '                        '2019/04/18 CHG E N D
    '                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_BFHYFRIDT '�U������(�ύX�O)
    '                        If Trim(strTEGDT) <> "" Then
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            .Text = CNV_DATE(strTEGDT)
    '                        End If

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_HYFRIDT '�U������
    '                        If Trim(strTEGDT) <> "" Then
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            .Text = CNV_DATE(strTEGDT)
    '                        Else
    '                            If txt_kesikb.Text <> "9" Then
    '                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                                .Text = CNV_DATE(gstrFridt.Value) 'ͯ�ނŎw�肵���U�������������\��
    '                            End If
    '                        End If


    '                        ''// V2.00�� UPD
    '                        '''                .Col = COL_HYFRIDT      '�U������
    '                        '''    'CHG START FKS)INABA 2007/07/26 ****************************************************
    '                        '''
    '                        '''                If txt_kesikb.Text = "9" Then
    '                        '''                    .Text = Format(CF_Ora_GetDyn(Usr_Ody, "TEGDT", ""), "YYYY/MM/DD") '�擾�����f�[�^��\��
    '                        '''                Else
    '                        '''                    .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
    '                        '''                End If
    '                        '''
    '                        '''    '            .Text = CNV_DATE(gstrFridt)       'ͯ�ނŎw�肵���U�������������\��
    '                        '''    'CHG  END  FKS)INABA 2007/07/26 ****************************************************
    '                        '
    '                        ''// V3.20�� UPD
    '                        '''''                .Col = COL_HYFRIDT      '�U������
    '                        '''''                If txt_kesikb.Text = "9" Then
    '                        '''''                    strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        '''''                    .Text = CNV_DATE(strTEGDT)
    '                        '''''                Else
    '                        '''''                    .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
    '                        '''''                End If
    '                        '                .Col = COL_HYFRIDT      '�U������
    '                        '                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        '                If Trim(strTEGDT) <> "" Then
    '                        '                    .Text = CNV_DATE(strTEGDT)
    '                        '                Else
    '                        '                    .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
    '                        '                End If
    '                        '
    '                        '                .Col = COL_BFHYFRIDT    '�U������(�ύX�O)
    '                        '                If Trim(strTEGDT) <> "" Then
    '                        '                    .Text = CNV_DATE(strTEGDT)
    '                        '                Else
    '                        '                    .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
    '                        '                End If
    '                        ''// V3.20�� UPD
    '                        ''                .Col = COL_BFHYFRIDT    '�U������(�ύX�O)
    '                        ''                If txt_kesikb.Text = "9" Then
    '                        ''                    .Text = CNV_DATE(strTEGDT)
    '                        ''                Else
    '                        ''                    .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
    '                        ''                End If
    '                        ''// V2.00�� UPD
    '                        ''// V2.13�� ADD
    '                        '                .Col = COL_HYFRIDT      '�U������
    '                        ''// V2.13�� ADD
    '                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA

    '                        '�w�b�_���Ɠ������A���ו��̓��͂�����
    '                        'CHG START FKS)INABA 2007/05/08 ****************************************************
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Lock = Not blnFriEnabled
    '                        '.Lock = Not blnFriEnabled
    '                        'CHG  END  FKS)INABA 2007/05/08 ****************************************************
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_BFKESIKN '�����ϊz(�����O)
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")
    '                        '2019/04/18 CHG E N D
    '                        '���v���z���v�Z
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)

    '                        '�������ϊz(KESIKN) - �����ϊz(�����O) > 0 �̂Ƃ������ޯ����������t����
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/19 CHG START
    '                        '.GetText(COL_KESIKN, .Row, tmp)
    '                        tmp = .GetValue(.Row, COL_KESIKN)
    '                        '2019/04/19 CHG E N D
    '                        '// V2.00�� UPD
    '                        ''''                    If SSSVal(tmp) - SSSVal(.Text) <> 0 Then
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(tmp) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        If SSSVal(tmp) <> 0 Then
    '                            '// V2.00�� UPD
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            '2019/04/19 CHG START
    '                            .Col = COL_CHK
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            .Value = 1
    '                            '// V2.00�� ADD
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            .Col = COL_BFCHECK
    '                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                            .Value = 1
    '                            '// V2.00�� ADD
    '                        End If

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_AFKESIKN '�����ϊz(������)
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("afkesikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_JDNNO '�󒍔ԍ�(6��)
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdnno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_JDNLINNO '�󒍍s�ԍ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdnlinno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_UDNDT '�����(�X���b�V���Ȃ�)
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_KESDT '����\���(�X���b�V���Ȃ��j
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TOKCD '���Ӑ溰��
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tokcd"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TOKSEICD '�����溰��
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tokseicd"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TANCD '�S���Һ���
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_JDNDT '�󒍓�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdndt"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_TUKKB '�ʉ݋敪
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("tukkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_INVNO '���޲��ԍ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("invno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_FURIKN '�C�O������z
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("furikn"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_FRNKB '�C�O����敪
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("frnkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_UDNDATNO '����DATNO
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("datno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_UDNLINNO '����s�ԍ�
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("linno"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_MAEUKKB '�O��敪
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("maeukkb"), "")
    '                        '2019/04/18 CHG E N D

    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_JDNDATNO '��DATNO
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")
    '                        .TEXT = DB_NullReplace(dt.Rows(cnt)("jdndatno"), "")
    '                        '2019/04/18 CHG E N D

    '                        '2009/09/15 ADD START RISE)MIYAJIMA
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_SSADT '��������
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Text = CF_Ora_GetDyn(Usr_Ody, "SSADT", "")
    '                        '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '                        '// V2.00�� ADD
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        .Col = COL_KESIKN_MAE '�������z�O
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, afkesikn, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        '2019/04/18 CHG START
    '                        '.Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))
    '                        .Text = SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")) + SSSVal(DB_NullReplace(dt.Rows(cnt)("afkesikn"), ""))
    '                        '2019/04/18 CHG E N D

    '                        '����g�����̔r�����擾
    '                        ReDim Preserve ARY_UDNTRA_HAITA(intMaxRow)
    '                        '2019/04/18 CHG START
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNOPEID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNCLTID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTDT", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTTM", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUOPEID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUCLTID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTDT", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTTM", ""))
    '                        ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("LINNO"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNOPEID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNCLTID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTDT"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTTM"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUOPEID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUCLTID"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTDT"), ""))

    '                        ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTTM"), ""))
    '                        '2019/04/18 CHG E N D

    '                        '�󒍃g�����̔r�����擾
    '                        ReDim Preserve ARY_JDNTRA_HAITA(intMaxRow)
    '                        '2019/04/18 CHG START
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNDATNO", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNOPEID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNCLTID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTDT", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTTM", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUOPEID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUCLTID", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTDT", ""))
    '                        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                        'ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTTM", ""))
    '                        ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNDATNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNOPEID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNCLTID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTDT"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTTM"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUOPEID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUCLTID"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTDT"), ""))

    '                        ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTTM"), ""))
    '                        '2019/04/18 CHG E N D
    '                        '// V2.00�� ADD

    '                        '2008/07/30 DEL START FKS)NAKATA
    '                        'XX                '2007/12/05 FKS)minamoto ADD START
    '                        'XX                '����g�����F�r�������擾
    '                        'XX
    '                        'XX                ReDim Preserve HAITA_UDNTRA(intMaxRow)
    '                        'XX                HAITA_UDNTRA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "datno", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "linno", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "udnwrtdt", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "udnwrttm", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "udnuwrtdt", ""))
    '                        'XX                HAITA_UDNTRA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "udnuwrttm", ""))
    '                        'XX                '�󒍃g�����F�r�������擾
    '                        'XX
    '                        'XX                ReDim Preserve HAITA_JDNTRA(intMaxRow)
    '                        'XX                HAITA_JDNTRA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "jdndatno", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnwrtdt", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnwrttm", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnuwrtdt", ""))
    '                        'XX                HAITA_JDNTRA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "jdnuwrttm", ""))
    '                        'XX                '���������g�����F�r�������擾
    '                        'XX
    '                        'XX
    '                        'XX            intRet = Execute_PLSQL_PRC_URKET53_01(HAITA_UDNTRA(intMaxRow).DATNO, HAITA_UDNTRA(intMaxRow).LINNO)
    '                        'XX            If intRet <> 0 Then
    '                        'XX               Exit Do
    '                        'XX            End If
    '                        '2008/07/30 DEL E.N.D FKS)NAKATA

    '                        '2008/1/10 FKS)ichihara ADD START
    '                    End If
    '                    '2008/1/10 FKS)ichihara ADD END

    '                    '2007/12/05 FKS)minamoto ADD END
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    '2019/04/18 CHG START
    '                    'Usr_Ody.Obj_Ody.MoveNext()
    '                    'Loop
    '                Next
    '            End If
    '            '2019/04/18 CHG E N D


    '            '// V2.00�� DEL
    '            '        .ReDraw = True
    '            '// V2.00�� ADD
    '        End With

    '        '2019/04/18 DEL START
    '        'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
    '        '2019/04/18 DEL E N D

    '        '�����Ώۂ��Ȃ���΃��b�Z�[�W��\��
    '        Dim i As Short
    '        Dim vntTmp As Object
    '        If intMaxRow = 0 Then
    '            Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
    '            txt_kesidt.Focus()

    '            '�Ώۂ����鎞
    '        Else

    '            '2009/09/29 ADD START RISE)MIYAJIMA
    '            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            If intMaxRow > spd_body.MaxRows Then
    '                initBody()
    '                Call showMsg("2", "URKET53_043", CStr(0)) '���\���\���𒴂��܂����B���t���i�蒼���ĉ������B
    '                txt_kesidt.Focus()
    '                GoTo STEP10_ShowBody
    '            End If
    '            '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '            '// V2.00�� ADD
    '            '���������g�����̔r�����擾
    '            Call Get_NKSTRA_HAITA_INF()
    '            '// V2.00�� ADD
    '            '�\���s����16�s�ȏ�̂Ƃ��A���گ�ލs����ݒ�
    '            If intMaxRow > 16 Then
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                spd_body.MaxRows = intMaxRow
    '            Else
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                spd_body.MaxRows = 16
    '            End If

    '            ''2009/09/27 ADD START RISE)MIYAJIMA

    '            With spd_body
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .BlockMode = True
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                For i = 1 To spd_body.MaxRows
    '                    '20091227��UPD
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    .Col = COL_HYFRIDT '�U������(�ύX�O)
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    .Col2 = COL_HYFRIDT '�U������(�ύX�O)
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    .Row = i
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    .Row2 = i
    '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                    .Lock = False
    '                    '                .GetText COL_BFHYFRIDT, i, vntTmp
    '                    '                If Trim(vntTmp) <> "" Then
    '                    '                    .Col = COL_HYFRIDT    '�U������(�ύX�O)
    '                    '                    .Col2 = COL_HYFRIDT    '�U������(�ύX�O)
    '                    '                    .Row = i
    '                    '                    .Row2 = i
    '                    '                    .Lock = True
    '                    '                Else
    '                    '                    .Col = COL_HYFRIDT    '�U������(�ύX�O)
    '                    '                    .Col2 = COL_HYFRIDT    '�U������(�ύX�O)
    '                    '                    .Row = i
    '                    '                    .Row2 = i
    '                    '                    .Lock = False
    '                    '                End If
    '                    '20091227��UPD
    '                Next i
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .Protect = True
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .Col = COL_CHK '�U������(�ύX�O)
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .Col2 = COL_CHK '�U������(�ύX�O)
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .Row = 1
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .Row2 = 1
    '                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .BlockMode = False
    '            End With
    '            ''2009/09/27 ADD E.N.D RISE)MIYAJIMA

    '            showHead() 'ͯ�ޕ��̕\��

    '            'spd_body.SetFocus
    '            blnUsableButton = True '�����ݎg�p�̋���
    '            mnu_zenkesi.Enabled = blnUsableButton
    '            mnu_zenkaijo.Enabled = blnUsableButton
    '            '�����p�l���̃��b�N
    '            'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            pnl_condition1.Enabled = False
    '            'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            pnl_condition2.Enabled = False
    '        End If

    '        '2009/09/29 ADD START RISE)MIYAJIMA
    'STEP10_ShowBody:
    '        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

    '        '// V2.00�� DEL
    '        ''    '2007/12/10 FKS)minamoto ADD START
    '        ''    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    '        ''
    '        ''    '2007/12/10 FKS)minamoto ADD END
    '        '// V2.00�� DEL

    '        '// V2.00�� DEL
    '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        spd_body.ReDraw = True
    '        '// V2.00�� ADD


    '        '���گ�޲���Ă̋���
    '        blnUsableSpread = True

    '        '�}�E�X�J�[�\����W���ɖ߂�
    '        'UPGRADE_ISSUE: vbNormal ���A�b�v�O���[�h����萔������ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: Form �v���p�e�B FR_SSSMAIN.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
    '        '2019/04/18 DEL START
    '        'Me.Cursor = vbNormal
    '        '2019/04/18 DEL E N D
    '    End Sub

    '�w�b�_��(�������)�̕\��
    Private Sub showBody()
        Dim strSql As Object
        Dim Usr_Ody As U_Ody
        Dim tmp As Object
        Dim intRet As Short
        Dim lw_sort As Short
        Dim bleNextFlg As Boolean
        Dim idxRow As Integer
        Dim strHYJDNNO As String
        Dim strTEGDT As String
        Dim rResult As Short ' �����`�F�b�N�֐��߂�l
        Dim strUDNDT As String
        Call SSSWIN_Unlock_EXCTBZ()

        '�������ͽ��گ�޲���Ă����s�����Ȃ�
        blnUsableSpread = False

        ReDim ARY_UDNTRA_HAITA(0)
        ReDim ARY_JDNTRA_HAITA(0)

        '�}�E�X�J�[�\���������v�ɂ���
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '���׃f�[�^�擾�pSQL���쐬
        Select Case True
            Case opt_sort(0).Checked
                lw_sort = 0
            Case opt_sort(1).Checked
                lw_sort = 1
            Case opt_sort(2).Checked
                lw_sort = 2
        End Select

        gstrTokseicd.Value = txt_tokseicd.Text
        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
        strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
        '2019/04/18 ADD START
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 ADD E N D

        '�\�����ڏ�����
        initHead()
        initBody()


        '�������ͽ��گ�޲���Ă����s�����Ȃ�
        blnUsableSpread = False

        Try

            With spd_body

                .Template = Me.Template11

                .SuspendLayout()

                If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                    '�X�v���b�h�Ɏ擾�����f�[�^��\��
                    .RowCount = dt.Rows.Count

                    For cnt As Integer = 0 To dt.Rows.Count - 1

                        '�\��t����f�[�^���ԕi�f�[�^�̏ꍇ����f�[�^������
                        bleNextFlg = True

                        If chkHenpin(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("RECNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNWRTFSTTM"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URITK"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), ""))) = False Then
                            '�f�[�^�̕\�����s��Ȃ�
                            bleNextFlg = False
                        Else
                            bleNextFlg = True
                        End If

                        If Trim(DB_NullReplace(dt.Rows(cnt)("HENRSNCD"), "")) = "" Then

                            If chkHenpinTeisei(Trim(DB_NullReplace(dt.Rows(cnt)("JDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("LINNO"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("TOKSEICD"), "")), Trim(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))) = False Then

                                '�f�[�^�̕\�����s��Ȃ�
                                bleNextFlg = False
                            Else
                                bleNextFlg = True
                            End If
                        End If

                        ''���͂��ꂽ�������ȍ~�̔���f�[�^���o���Ȃ�

                        If bleNextFlg = False Then
                            bleNextFlg = False
                        Else

                            If Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) > 0 Then

                                '���f�[�^�œ��͂��ꂽ����������̔���͕\�����Ȃ�
                                bleNextFlg = False

                            ElseIf Trim(DB_NullReplace(dt.Rows(cnt)("UDNDT"), "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(DB_NullReplace(dt.Rows(cnt)("URIKN"), ""))) < 0 Then

                                '�ԕi�̏ꍇ�́A���ɉ�ʏ�ɓ����󒍔ԍ������݂��邩���m�F����B
                                With spd_body
                                    For idxRow = intMaxRow To 1 Step -1

                                        tmp = .GetValue(idxRow, COL_HYJDNNO)

                                        strHYJDNNO = CStr(tmp)

                                        If Trim(strHYJDNNO) = Trim(DB_NullReplace(dt.Rows(cnt)("HY_JDNNO"), "")) Then

                                            '��ʏ�ɍ�������Ώo��
                                            bleNextFlg = True
                                            Exit For
                                        Else
                                            bleNextFlg = False
                                        End If
                                    Next idxRow
                                End With
                            Else
                                bleNextFlg = True

                            End If
                        End If

                        If bleNextFlg = True Then

                            intMaxRow = intMaxRow + 1

                            '2019/04/25 CHG START
                            'If intMaxRow > .RowCount - 1 Then
                            If intMaxRow > .RowCount Then
                                '2019/04/25 CHG E N D
                                Exit For
                            End If

                            '�`�F�b�N
                            .SetValue(cnt, COL_CHK, False)

                            'No.
                            .SetValue(cnt, COL_NO, cnt + 1)

                            '���[
                            .SetValue(cnt, COL_NXTKB, DB_NullReplace(dt.Rows(cnt)("nxtkb"), ""))

                            '�����
                            .SetValue(cnt, COL_HYUDNDT, IIf(DB_NullReplace(dt.Rows(cnt)("hy_udndt").ToString, "") = "", "", VB6.Format(dt.Rows(cnt)("hy_udndt"), "yyyy/mm/dd")))
                            strUDNDT = DB_NullReplace(dt.Rows(cnt)("hy_udndt"), "")

                            '�󒍔ԍ�
                            .SetValue(cnt, COL_HYJDNNO, DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), ""))

                            If DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), "") <> "" Then
                                '�r���`�F�b�N
                                rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(DB_NullReplace(dt.Rows(cnt)("hy_jdnno"), ""), 6))

                                Select Case rResult
                            '����
                                    Case 0

                                '�r��������
                                    Case 1
                                        MsgBox("���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & intMaxRow & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & .Text)
                                        Call SSSWIN_Unlock_EXCTBZ()
                                        initBody()
                                        GoTo STEP10_ShowBody

                                '�ُ�I��
                                    Case 9
                                        Call showMsg("2", "URKET53_034 ", CStr(0)) '�X�V�ُ�
                                        Call SSSWIN_Unlock_EXCTBZ()
                                        initBody()
                                        GoTo STEP10_ShowBody
                                End Select
                            End If

                            '����\���
                            .SetValue(cnt, COL_HYKAIDT, IIf(DB_NullReplace(dt.Rows(cnt)("hy_kaidt").ToString, "") = "", "", VB6.Format(dt.Rows(cnt)("hy_kaidt"), "yyyy/mm/dd")))

                            '�q�撍���ԍ�
                            .SetValue(cnt, COL_TOKJDNNO, DB_NullReplace(dt.Rows(cnt)("tokjdnno"), ""))

                            '�c�ƒS����
                            .SetValue(cnt, COL_TANNM, DB_NullReplace(dt.Rows(cnt)("tannm"), ""))

                            '�Ŕ�������z
                            .SetValue(cnt, COL_URIKN, DB_NullReplace(dt.Rows(cnt)("urikn"), ""))

                            '����Ŋz
                            .SetValue(cnt, COL_UZEKN, DB_NullReplace(dt.Rows(cnt)("uzekn"), ""))

                            '�ō�������z
                            .SetValue(cnt, COL_KOMIKN, DB_NullReplace(dt.Rows(cnt)("komikn"), ""))

                            '���v���z���v�Z
                            intUrigoukei = intUrigoukei + SSSVal(DB_NullReplace(dt.Rows(cnt)("komikn"), ""))

                            '�����ϊz
                            .SetValue(cnt, COL_KESIKN, DB_NullReplace(dt.Rows(cnt)("kesikn"), ""))

                            '�������z(��\��)
                            .SetValue(cnt, COL_MINYUKN, DB_NullReplace(dt.Rows(cnt)("kesikn"), ""))

                            '�U�������̎擾
                            strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")

                            '�U������(�ύX�O)
                            If Trim(strTEGDT) <> "" Then
                                .SetValue(cnt, COL_BFHYFRIDT, CNV_DATE(Trim(strTEGDT)))
                            End If

                            '�U������
                            If Trim(strTEGDT) <> "" Then
                                .SetValue(cnt, COL_HYFRIDT, CNV_DATE(strTEGDT))
                            Else
                                If txt_kesikb.Text <> "9" Then
                                    .SetValue(cnt, COL_HYFRIDT, CNV_DATE(Trim(gstrFridt.Value))) 'ͯ�ނŎw�肵���U�������������\��
                                End If
                            End If

                            '�w�b�_���Ɠ������A���ו��̓��͂�����
                            .Rows(cnt).Cells(COL_HYFRIDT).Enabled = Not blnFriEnabled

                            '�����ϊz(�����O)
                            .SetValue(cnt, COL_BFKESIKN, DB_NullReplace(dt.Rows(cnt)("bfkesikn"), ""))


                            '���v���z���v�Z
                            intBfkesiknkei = intBfkesiknkei + SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), ""))

                            '�������ϊz(KESIKN) - �����ϊz(�����O) > 0 �̂Ƃ������ޯ����������t����
                            tmp = .GetValue(cnt, COL_KESIKN)

                            If SSSVal(tmp) <> 0 Then
                                .SetValue(cnt, COL_CHK, True)
                                .SetValue(cnt, COL_BFCHECK, 1)
                            End If

                            '�����ϊz(������)
                            .SetValue(cnt, COL_AFKESIKN, DB_NullReplace(dt.Rows(cnt)("afkesikn"), ""))

                            '�󒍔ԍ�(6��)
                            .SetValue(cnt, COL_JDNNO, DB_NullReplace(dt.Rows(cnt)("jdnno"), ""))

                            '�󒍍s�ԍ�
                            .SetValue(cnt, COL_JDNLINNO, DB_NullReplace(dt.Rows(cnt)("jdnlinno"), ""))

                            '�����(�X���b�V���Ȃ�)
                            .SetValue(cnt, COL_UDNDT, DB_NullReplace(dt.Rows(cnt)("udndt"), ""))

                            '����\���(�X���b�V���Ȃ��j
                            .SetValue(cnt, COL_KESDT, DB_NullReplace(dt.Rows(cnt)("kesdt"), ""))

                            '���Ӑ溰��
                            .SetValue(cnt, COL_TOKCD, DB_NullReplace(dt.Rows(cnt)("tokcd"), ""))

                            '�����溰��
                            .SetValue(cnt, COL_TOKSEICD, DB_NullReplace(dt.Rows(cnt)("tokseicd"), ""))

                            '�S���Һ���
                            .SetValue(cnt, COL_TANCD, DB_NullReplace(dt.Rows(cnt)("tancd"), ""))

                            '�󒍓�
                            .SetValue(cnt, COL_JDNDT, DB_NullReplace(dt.Rows(cnt)("jdndt"), ""))

                            '�ʉ݋敪
                            .SetValue(cnt, COL_TUKKB, DB_NullReplace(dt.Rows(cnt)("tukkb"), ""))

                            '���޲��ԍ�
                            .SetValue(cnt, COL_INVNO, DB_NullReplace(dt.Rows(cnt)("invno"), ""))

                            '�C�O������z
                            .SetValue(cnt, COL_FURIKN, DB_NullReplace(dt.Rows(cnt)("furikn"), ""))

                            '�C�O����敪
                            .SetValue(cnt, COL_FRNKB, DB_NullReplace(dt.Rows(cnt)("frnkb"), ""))

                            '����DATNO
                            .SetValue(cnt, COL_UDNDATNO, DB_NullReplace(dt.Rows(cnt)("datno"), ""))

                            '����s�ԍ�
                            .SetValue(cnt, COL_UDNLINNO, DB_NullReplace(dt.Rows(cnt)("linno"), ""))

                            '�O��敪
                            .SetValue(cnt, COL_MAEUKKB, DB_NullReplace(dt.Rows(cnt)("maeukkb"), ""))

                            '��DATNO
                            .SetValue(cnt, COL_JDNDATNO, DB_NullReplace(dt.Rows(cnt)("jdndatno"), ""))

                            '��������
                            .SetValue(cnt, COL_SSADT, DB_NullReplace(dt.Rows(cnt)("SSADT"), ""))

                            '�������z�O
                            .SetValue(cnt, COL_KESIKN_MAE, SSSVal(DB_NullReplace(dt.Rows(cnt)("bfkesikn"), "")) + SSSVal(DB_NullReplace(dt.Rows(cnt)("afkesikn"), "")))


                            '����g�����̔r�����擾
                            ReDim Preserve ARY_UDNTRA_HAITA(cnt)

                            ARY_UDNTRA_HAITA(cnt).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("DATNO"), ""))

                            ARY_UDNTRA_HAITA(cnt).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("LINNO"), ""))

                            ARY_UDNTRA_HAITA(cnt).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNOPEID"), ""))

                            ARY_UDNTRA_HAITA(cnt).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNCLTID"), ""))

                            ARY_UDNTRA_HAITA(cnt).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTDT"), ""))

                            ARY_UDNTRA_HAITA(cnt).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNWRTTM"), ""))

                            ARY_UDNTRA_HAITA(cnt).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUOPEID"), ""))

                            ARY_UDNTRA_HAITA(cnt).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUCLTID"), ""))

                            ARY_UDNTRA_HAITA(cnt).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTDT"), ""))

                            ARY_UDNTRA_HAITA(cnt).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("UDNUWRTTM"), ""))


                            '�󒍃g�����̔r�����擾
                            ReDim Preserve ARY_JDNTRA_HAITA(cnt)

                            ARY_JDNTRA_HAITA(cnt).DATNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNDATNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).JDNNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).LINNO = CStr(DB_NullReplace(dt.Rows(cnt)("JDNLINNO"), ""))

                            ARY_JDNTRA_HAITA(cnt).OPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNOPEID"), ""))

                            ARY_JDNTRA_HAITA(cnt).CLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNCLTID"), ""))

                            ARY_JDNTRA_HAITA(cnt).WRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTDT"), ""))

                            ARY_JDNTRA_HAITA(cnt).WRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNWRTTM"), ""))

                            ARY_JDNTRA_HAITA(cnt).UOPEID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUOPEID"), ""))

                            ARY_JDNTRA_HAITA(cnt).UCLTID = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUCLTID"), ""))

                            ARY_JDNTRA_HAITA(cnt).UWRTDT = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTDT"), ""))

                            ARY_JDNTRA_HAITA(cnt).UWRTTM = CStr(DB_NullReplace(dt.Rows(cnt)("JDNUWRTTM"), ""))

                        End If

                    Next

                End If

            End With


            '�����Ώۂ��Ȃ���΃��b�Z�[�W��\��
            Dim i As Short
            Dim vntTmp As Object
            If intMaxRow = 0 Then
                Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
                txt_kesidt.Focus()

                '�Ώۂ����鎞
            Else

                If intMaxRow > 9999 Then
                    initBody()
                    Call showMsg("2", "URKET53_043", CStr(0)) '���\���\���𒴂��܂����B���t���i�蒼���ĉ������B
                    txt_kesidt.Focus()
                    GoTo STEP10_ShowBody
                End If

                '���������g�����̔r�����擾
                Call Get_NKSTRA_HAITA_INF()

                '�\���s����16�s�ȏ�̂Ƃ��A���گ�ލs����ݒ�
                '2019/04/25 DEL START
                'If intMaxRow > 16 Then
                '    spd_body.RowCount = intMaxRow
                'Else
                '    spd_body.RowCount = 16
                'End If
                '2019/04/25 DEL E N D

                With spd_body

                    For i = 0 To spd_body.RowCount - 1
                        .Rows(i).Cells(COL_HYFRIDT).Enabled = True
                        .Rows(i).Cells(COL_CHK).Enabled = True
                    Next i

                End With

                showHead() 'ͯ�ޕ��̕\��

                blnUsableButton = True '�����ݎg�p�̋���
                '2019/04/26 DEL START
                'mnu_zenkesi.Enabled = blnUsableButton
                'mnu_zenkaijo.Enabled = blnUsableButton
                '2019/04/26 DEL E N D
                '�����p�l���̃��b�N
                pnl_condition1.Enabled = False
                pnl_condition2.Enabled = False
            End If
        Catch ex As Exception

        End Try
STEP10_ShowBody:

        '�ĕ`��
        spd_body.ResumeLayout()


        '���گ�޲���Ă̋���
        blnUsableSpread = True

        '�}�E�X�J�[�\����W���ɖ߂�
        '2019/04/18 DEL START
        'Me.Cursor = vbNormal
        Me.Cursor = Cursors.Default

        '2019/04/18 DEL E N D
    End Sub
    '2019/04/19 CHG E N D

    Public Sub showHead()
        '// V2.09�� DEL
        ''''    Dim strSql  As Variant
        ''''    Dim Usr_Ody As U_Ody
        '// V2.09�� DEL

        Dim intZankn As Decimal '���������x�܂ł̏����c�z�v
        Dim intKesikn As Decimal '�o�������ȍ~�̏����z
        Dim intTesuryo As Decimal '���������x�̎萔���z���i�[
        Dim intSyohi As Decimal '���������x�̏���Ŋz���i�[

        Dim tmp As Decimal

        '// V2.00�� ADD
        Dim i As Short
        '// V2.00�� ADD

        intZankn = 0
        intKesikn = 0
        intTesuryo = 0
        intSyohi = 0

        '// V2.09�� ADD
        Call getHaitaAndKnSum(DB_TOKMTA2.TOKSEICD, Get_Acedt(gstrKesidt.Value), DB_TOKMTA2.SHAKB)
        '// V2.09�� ADD

        '// V2.00�� UPD
        ''    '���������x�܂ł̏����c�z�v
        ''    strSql = "SELECT SUM(kskzankn) kskzankn FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt <= '" & DB_TOKMTA2.KESISMEDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        intZankn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "kskzankn", ""))
        ''    End If
        ''
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
        ''    '�o�������ȍ~�̏����z
        ''    strSql = "SELECT SUM(ksknykkn) ksknykkn FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt > '" & DB_SYSTBA.SMAUPDDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        'intKesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ksknykkn", ""))
        ''        intKesikn = getBodyKesikei(COL_AFKESIKN)        '�ύX�@2007/03/02 Saito
        ''    End If
        ''
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
        ''    '���������x�̎萔���E����Ŋz���i�[
        ''    strSql = "SELECT * FROM tokssa " _
        '''            & "WHERE tokcd = '" & DB_TOKMTA2.TOKSEICD & "' AND ssadt = '" & DB_TOKMTA2.KESISMEDT & "'"
        ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''        intTesuryo = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        ''        intSyohi = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & SyohiID, ""))
        ''    End If
        ''    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��

        '// V2.09�� DEL
        ''''    '���������x�̏�����Ԃ��擾
        ''''    strSql = ""
        ''''    strSql = strSql & "SELECT * "
        ''''    strSql = strSql & "FROM   NKSSMA "
        ''''    strSql = strSql & "WHERE  "
        ''''    strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(DB_TOKMTA2.TOKSEICD) & "' "
        ''''    strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(Get_Acedt(gstrKesidt))) & "' "
        ''''
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    '���������T�}���[�̔r�����擾
        ''''    ReDim ARY_NKSSMA_HAITA(1)
        ''''    ARY_NKSSMA_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
        ''''    ARY_NKSSMA_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
        ''''    ARY_NKSSMA_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
        ''''    ARY_NKSSMA_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
        ''''    ARY_NKSSMA_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
        ''''    ARY_NKSSMA_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
        ''''
        ''''    '���������T�}���̏����\���̔z��֎擾
        ''''    ReDim ARY_NKSSMA_KS(9)
        ''''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''''        For i = 0 To 9
        '// V2.09�� DEL

        '// V2.07�� UPD
        ''''            ARY_NKSSMA_KS(i).SEQ = i + 10
        ''''            ARY_NKSSMA_KS(i).UPDID = Format(i, "00")
        ''''            ARY_NKSSMA_KS(i).SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & Format(i, "00"), ""))
        ''''            ARY_NKSSMA_KS(i).ZAN_KIN = ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN + ARY_NKSSMA_KS(i).KSKZANKN
        ''''            '����敪�̐ݒ�
        ''''            Select Case i
        ''''                Case 0
        ''''                    ARY_NKSSMA_KS(i).DATKB = "01"
        ''''                Case 1
        ''''                    ARY_NKSSMA_KS(i).DATKB = "02"
        ''''                Case 2
        ''''                    ARY_NKSSMA_KS(i).DATKB = "03"
        ''''                Case 3
        ''''                    ARY_NKSSMA_KS(i).DATKB = "04"
        ''''                Case 4
        ''''                    ARY_NKSSMA_KS(i).DATKB = "05"
        ''''                Case 5
        ''''                    ARY_NKSSMA_KS(i).DATKB = "06"
        ''''                Case 6
        ''''                    ARY_NKSSMA_KS(i).DATKB = "07"
        ''''                Case 7
        ''''                    ARY_NKSSMA_KS(i).DATKB = "08"
        ''''                Case 8
        ''''                    ARY_NKSSMA_KS(i).DATKB = "09"
        ''''                Case 9
        ''''                    ARY_NKSSMA_KS(i).DATKB = "99"
        ''''            End Select

        '// V2.09�� DEL
        ''''            With ARY_NKSSMA_KS(i)
        ''''                .UPDID = Format(i, "00")
        ''''                If i <> 8 Then
        ''''                    .SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & Format(i, "00"), ""))
        ''''                    .KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & Format(i, "00"), ""))
        ''''                    .KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & Format(i, "00"), ""))
        ''''                    .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
        ''''                Else
        ''''                    '09�F�{���� �́A����ɂ��Ȃ�
        ''''                    .SSANYUKN = 0
        ''''                    .KSKNYKKN = 0
        ''''                    .KSKZANKN = 0
        ''''                    .ZAN_KIN = 0
        ''''                End If
        ''''
        ''''                '����敪�̐ݒ�
        ''''                Select Case i
        ''''                    Case 0: .DATKB = "01"       '01�F����
        ''''                    Case 1: .DATKB = "02"       '02�F�U��
        ''''                    Case 2: .DATKB = "03"       '03�F��`
        ''''                    Case 3: .DATKB = "04"       '04�F���E
        ''''                    Case 4: .DATKB = "05"       '05�F�l��
        ''''                    Case 5: .DATKB = "06"       '06�F�萔
        ''''                    Case 6: .DATKB = "07"       '07�F��
        ''''                    Case 7: .DATKB = "08"       '08�F�U����
        ''''                    Case 8: .DATKB = "09"       '09�F�{����
        ''''                    Case 9: .DATKB = "99"       '99�F����
        ''''                End Select
        ''''
        ''''                '���������̐ݒ�i-1 �͏����Ȃ��j
        ''''                Select Case SSSVal(DB_TOKMTA2.SHAKB)
        ''''                    Case 1                  '�x��������1�F�U��
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 2            '����敪��01�F����
        ''''                            Case 1: .SEQ = 1            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 5            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 3            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 4            '����敪��99�F����
        ''''                        End Select
        ''''                    Case 2                  '�x��������2�F��`
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 2            '����敪��01�F����
        ''''                            Case 1: .SEQ = 5            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 1            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 3            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 4            '����敪��99�F����
        ''''                        End Select
        ''''                    Case 3                  '�x��������3�F�U���܂��͎�`
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '����敪��01�F����
        ''''                            Case 1: .SEQ = 1            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 2            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 4            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 5            '����敪��99�F����
        ''''                        End Select
        ''''                    Case 4                  '�x��������4�F�U����`���p
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '����敪��01�F����
        ''''                            Case 1: .SEQ = 1            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 2            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 4            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 5            '����敪��99�F����
        ''''                        End Select
        ''''                    Case 5                  '�x��������5�F�����U��
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '����敪��01�F����
        ''''                            Case 1: .SEQ = 2            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 1            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 4            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 5            '����敪��99�F����
        ''''                        End Select
        ''''                    Case 6                  '�x��������6�F̧���ݸ�
        ''''                        Select Case i
        ''''                            Case 0: .SEQ = 3            '����敪��01�F����
        ''''                            Case 1: .SEQ = 2            '����敪��02�F�U��
        ''''                            Case 2: .SEQ = 1            '����敪��03�F��`
        ''''                            Case 3: .SEQ = 6            '����敪��04�F���E
        ''''                            Case 4: .SEQ = 7            '����敪��05�F�l��
        ''''                            Case 5: .SEQ = 4            '����敪��06�F�萔
        ''''                            Case 6: .SEQ = 8            '����敪��07�F��
        ''''                            Case 7: .SEQ = 9            '����敪��08�F�U����
        ''''                            Case 8: .SEQ = -1           '����敪��09�F�{����
        ''''                            Case 9: .SEQ = 5            '����敪��99�F����
        ''''                        End Select
        ''''                End Select
        ''''            End With
        '''''// V2.07�� UPD
        ''''        Next i
        ''''    End If
        '// V2.09�� DEL

        '// V2.07�� DEL
        ''''    '���������̐ݒ�
        ''''    Select Case SSSVal(DB_TOKMTA2.SHAKB)   '1�F�U���A2�F��`�A3�F�U���܂��͎�`�A4�F�U����`���p�A5�F�����U���A6�F̧���ݸ�
        ''''        Case 1
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''        Case 2
        ''''            ARY_NKSSMA_KS(2).SEQ = 1
        ''''        Case 3
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''            ARY_NKSSMA_KS(2).SEQ = 2
        ''''        Case 4
        ''''            ARY_NKSSMA_KS(1).SEQ = 1
        ''''            ARY_NKSSMA_KS(2).SEQ = 2
        ''''        Case 5
        ''''            ARY_NKSSMA_KS(2).SEQ = 1
        ''''        Case 6
        ''''    End Select
        '// V2.07�� DEL

        '���������x�܂ł̏����c�z�v
        For i = 0 To 9
            intZankn = intZankn + ARY_NKSSMA_KS(i).KSKZANKN
        Next i

        '�o�������ȍ~�̏����z
        For i = 0 To 9
            intKesikn = intKesikn + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN
        Next i

        '���������x�̎萔���E����Ŋz���i�[
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        i = SSSVal(TesuryoID)
        intTesuryo = ARY_NKSSMA_KS(i).KSKZANKN + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        i = SSSVal(SyohiID)
        intSyohi = ARY_NKSSMA_KS(i).KSKZANKN + ARY_NKSSMA_KS(i).SSANYUKN - ARY_NKSSMA_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
        '// V2.00�� UPD

        '���㍇�v���z�̕\��
        txt_urigoukei.Text = VB6.Format(intUrigoukei, "###,###,##0")

        '�����z�E�萔���z�E����Ŋz�̕\��
        tmp = intZankn + intKesikn
        If tmp - (intTesuryo + intSyohi) > 0 Then
            txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
            txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
            txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
            '�c���v���X�̂Ƃ�
        ElseIf tmp > 0 Then
            If intTesuryo > 0 Then
                If intSyohi > 0 Then
                    '�c�z���v���X�ŁA�萔�����A����ō��z���v���X�̎�
                    If tmp - intTesuryo > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(tmp, "#,###,##0")
                        txt_syohi.Text = VB6.Format(0, "#,###,##0")
                    End If

                ElseIf intSyohi <= 0 Then
                    '�c�z���v���X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
                    txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                    txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                End If

            ElseIf intTesuryo <= 0 Then
                If intSyohi > 0 Then
                    '�c�z���v���X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
                    txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                ElseIf intSyohi <= 0 Then
                    '�c�z���v���X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
                    'tmp - (intTesuryo + intSyohi) �͐�΂ɐ��Ȃ̂ŁA�����ɏ����͕s�v
                End If
            End If

            '�c�����̎�
        ElseIf tmp <= 0 Then
            If intTesuryo > 0 Then
                If intSyohi > 0 Then
                    '�c�z���}�C�i�X�ŁA�萔�����A����ō��z���v���X�̎�
                    txt_nyukin.Text = VB6.Format(tmp, "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
                    txt_syohi.Text = VB6.Format(0, "#,###,##0")
                ElseIf intSyohi <= 0 Then
                    '�c�z���}�C�i�X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
                    If tmp + intTesuryo + intSyohi > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                        txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
                        txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                    End If
                End If
            ElseIf intTesuryo <= 0 Then
                If intSyohi > 0 Then
                    '�c�z���}�C�i�X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
                    If tmp + intTesuryo + intSyohi > 0 Then
                        txt_nyukin.Text = VB6.Format(0, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                    Else
                        txt_nyukin.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
                        txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                        txt_syohi.Text = VB6.Format(0, "#,###,##0")
                    End If
                ElseIf intSyohi <= 0 Then
                    '�c�z���}�C�i�X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
                    txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
                    txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
                End If
            End If
        End If

        '�������v�z�̕\��
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_syohi.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(txt_tesuryo.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        tmp = SSSVal((txt_nyukin.Text)) + SSSVal((txt_tesuryo.Text)) + SSSVal((txt_syohi.Text))
        txt_nyugoukei.Text = VB6.Format(tmp, "###,###,##0")

        '�����c�z�̕\��
        '// V2.00�� UPD
        '    txt_kesizan.Text = Format(tmp - (getBodyKesikei(COL_KESIKN) - intBfkesiknkei), "###,###,##0")
        'txt_kesizan.Text = Format(intKesikn, "###,###,##0")
        'MMMM
        txt_kesizan.Text = VB6.Format(intZankn + intKesikn, "###,###,##0")

        '// V2.00�� UPD
    End Sub

    '���ו����v���z�̎擾
    Private Function getBodyKesikei(ByRef strColName As String) As Decimal
        Dim i As Short
        Dim intKesikei As Decimal
        Dim tmp As Object

        intKesikei = 0
        blnUsableSpread = False
        With spd_body
            '2019/04/25 CHG START
            'For i = 1 To intMaxRow
            For i = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/19 CHG START
                '.GetText(strColName, i, tmp)
                tmp = .GetValue(i, strColName)
                '2019/04/19 CHG E N D

                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKesikei = intKesikei + SSSVal(tmp)
            Next i
        End With
        blnUsableSpread = True

        getBodyKesikei = intKesikei
    End Function

    '// V2.09�� ADD
    '�r�����Ə������z�����擾�A�O���[�o���ϐ��Ɋi�[
    Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
        Dim strSql As Object
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim i As Short

        '���������x�̏�����Ԃ��擾
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & " SELECT * "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "   FROM NKSSMA "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 CHG E N D

        '���������T�}���[�̔r�����擾
        ReDim ARY_NKSSMA_HAITA(1)
        '2019/04/18 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ARY_NKSSMA_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))

        ARY_NKSSMA_HAITA(1).TOKCD = CStr(DB_NullReplace(dt.Rows(0)("TOKCD"), ""))

        ARY_NKSSMA_HAITA(1).SMADT = CStr(DB_NullReplace(dt.Rows(0)("SMADT"), ""))

        ARY_NKSSMA_HAITA(1).OPEID = CStr(DB_NullReplace(dt.Rows(0)("OPEID"), ""))

        ARY_NKSSMA_HAITA(1).CLTID = CStr(DB_NullReplace(dt.Rows(0)("CLTID"), ""))

        ARY_NKSSMA_HAITA(1).WRTDT = CStr(DB_NullReplace(dt.Rows(0)("WRTDT"), ""))

        ARY_NKSSMA_HAITA(1).WRTTM = CStr(DB_NullReplace(dt.Rows(0)("WRTTM"), ""))
        '2019/04/18 CHG E N D

        '���������T�}���̏����\���̔z��֎擾
        ReDim ARY_NKSSMA_KS(9)
        For i = 0 To 9
            With ARY_NKSSMA_KS(i)
                .UPDID = VB6.Format(i, "00")

                If i <> 8 Then
                    '2019/04/18 CHG START
                    'If CF_Ora_EOF(Usr_Ody) = False Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & .UPDID, ""))
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & .UPDID, ""))
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & .UPDID, ""))
                    'End If
                    If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                        .SSANYUKN = SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN" & .UPDID), ""))

                        .KSKNYKKN = SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN" & .UPDID), ""))

                        .KSKZANKN = SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN" & .UPDID), ""))
                    End If
                    '2019/04/18 CHG 
                Else
                    '09�F�{���� �́A����ɂ��Ȃ�
                    .SSANYUKN = 0
                    .KSKNYKKN = 0
                    .KSKZANKN = 0
                End If

                '����敪�̐ݒ�
                Select Case i
                    Case 0 : .DATKB = "01" '01�F����
                    Case 1 : .DATKB = "02" '02�F�U��
                    Case 2 : .DATKB = "03" '03�F��`
                    Case 3 : .DATKB = "04" '04�F���E
                    Case 4 : .DATKB = "05" '05�F�l��
                    Case 5 : .DATKB = "06" '06�F�萔
                    Case 6 : .DATKB = "07" '07�F��
                    Case 7 : .DATKB = "08" '08�F�U����
                    Case 8 : .DATKB = "09" '09�F�{����
                    Case 9 : .DATKB = "99" '99�F����
                End Select

                '// V3.10�� UPD
                '���������̐ݒ�i-1 �͏����Ȃ��j
                ' �@���E���A����Ł��B�萔�����C�������D�U�����E��`���F�U�������G�l�������H��
                Select Case i
                    Case 0 : .SEQ = 4 '����敪��01�F����
                    Case 1 : .SEQ = 5 '����敪��02�F�U��
                    Case 2 : .SEQ = 6 '����敪��03�F��`
                    Case 3 : .SEQ = 1 '����敪��04�F���E
                    Case 4 : .SEQ = 8 '����敪��05�F�l��
                    Case 5 : .SEQ = 3 '����敪��06�F�萔
                    Case 6 : .SEQ = 9 '����敪��07�F��
                    Case 7 : .SEQ = 7 '����敪��08�F�U����
                    Case 8 : .SEQ = -1 '����敪��09�F�{����
                    Case 9 : .SEQ = 2 '����敪��99�F����
                End Select
                '            '���������̐ݒ�i-1 �͏����Ȃ��j
                '            Select Case SSSVal(pin_strSHAKB)
                '                Case 1                  '�x��������1�F�U��
                '                    Select Case i
                '                        Case 0: .SEQ = 2            '����敪��01�F����
                '                        Case 1: .SEQ = 1            '����敪��02�F�U��
                '                        Case 2: .SEQ = 5            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 3            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 4            '����敪��99�F����
                '                    End Select
                '                Case 2                  '�x��������2�F��`
                '                    Select Case i
                '                        Case 0: .SEQ = 2            '����敪��01�F����
                '                        Case 1: .SEQ = 5            '����敪��02�F�U��
                '                        Case 2: .SEQ = 1            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 3            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 4            '����敪��99�F����
                '                    End Select
                '                Case 3                  '�x��������3�F�U���܂��͎�`
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '����敪��01�F����
                '                        Case 1: .SEQ = 1            '����敪��02�F�U��
                '                        Case 2: .SEQ = 2            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 4            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 5            '����敪��99�F����
                '                    End Select
                '                Case 4                  '�x��������4�F�U����`���p
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '����敪��01�F����
                '                        Case 1: .SEQ = 1            '����敪��02�F�U��
                '                        Case 2: .SEQ = 2            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 4            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 5            '����敪��99�F����
                '                    End Select
                '                Case 5                  '�x��������5�F�����U��
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '����敪��01�F����
                '                        Case 1: .SEQ = 2            '����敪��02�F�U��
                '                        Case 2: .SEQ = 1            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 4            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 5            '����敪��99�F����
                '                    End Select
                '                Case 6                  '�x��������6�F̧���ݸ�
                '                    Select Case i
                '                        Case 0: .SEQ = 3            '����敪��01�F����
                '                        Case 1: .SEQ = 2            '����敪��02�F�U��
                '                        Case 2: .SEQ = 1            '����敪��03�F��`
                '                        Case 3: .SEQ = 6            '����敪��04�F���E
                '                        Case 4: .SEQ = 7            '����敪��05�F�l��
                '                        Case 5: .SEQ = 4            '����敪��06�F�萔
                '                        Case 6: .SEQ = 8            '����敪��07�F��
                '                        Case 7: .SEQ = 9            '����敪��08�F�U����
                '                        Case 8: .SEQ = -1           '����敪��09�F�{����
                '                        Case 9: .SEQ = 5            '����敪��99�F����
                '                    End Select
                '            End Select
                '// V3.10�� UPD
            End With
        Next i

        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        '// V3.10�� DEL
        '    '�O�����������c�z�̃}�C�i�X�f�[�^����
        '    Call cutMinusKSKZANKN
        '// V3.10�� DEL

        For i = 0 To 9
            '�c�����v�Z����
            With ARY_NKSSMA_KS(i)
                .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
            End With
        Next i
    End Sub
    '// V2.09�� ADD

    '// V3.10�� DEL
    ''// V2.09�� ADD
    ''�O�����������c�z�̃}�C�i�X�f�[�^������Ə������������������Ȃ�̂ŁA
    ''�����Ń}�C�i�X�̑O�����������c�z���J�b�g����
    ''�������A�����������������̂��瑊�E����`�Ő؂�
    'Private Sub cutMinusKSKZANKN()
    '    Dim i           As Integer
    '    Dim intSEQ      As Integer
    '    Dim intUPDID    As Integer
    '    Dim curKSKZANKN As Currency
    '
    '    '�����������������̂��瑊�E����`�Ő؂�
    '    For i = 0 To 9
    '        For intSEQ = 1 To 20
    '            If ARY_NKSSMA_KS(i).SEQ = intSEQ Then
    '                curKSKZANKN = ARY_NKSSMA_KS(i).KSKZANKN
    '                For intUPDID = 0 To 9
    '                    With ARY_NKSSMA_KS(intUPDID)
    '                        '���������T�}��
    '                        If curKSKZANKN > 0 And .KSKZANKN < 0 Then
    '                            If (curKSKZANKN + .KSKZANKN) < 0 Then
    '                                .KSKZANKN = curKSKZANKN + .KSKZANKN
    '                                curKSKZANKN = 0
    '                            Else
    '                                curKSKZANKN = curKSKZANKN + .KSKZANKN
    '                                .KSKZANKN = 0
    '                            End If
    '                        End If
    '                    End With
    '                Next intUPDID
    '                ARY_NKSSMA_KS(i).KSKZANKN = curKSKZANKN
    '            End If
    '        Next intSEQ
    '    Next i
    '
    '    '���E���؂�Ȃ������}�C�i�X�͋����I�ɐ؂�
    '    For i = 0 To 9
    '        With ARY_NKSSMA_KS(i)
    '            If .KSKZANKN < 0 Then
    '                .KSKZANKN = 0
    '            End If
    '        End With
    '    Next i
    'End Sub
    ''// V2.09�� ADD
    '// V3.10�� DEL

    '// V2.00�� DEL
    '''�������t�̃`�F�b�N
    ''Private Function chkKesidt() As Boolean
    ''    chkKesidt = False
    ''    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    ''    If intChkKb = 1 Or txt_kesidt.Text <> CNV_DATE(gstrKesidt) Then
    '''        '�w�b�_�A���ׂ̃N���A
    '''        initHead
    '''        initBody
    ''
    ''        '���t�`���̃`�F�b�N
    ''        If IsDate(txt_kesidt.Text) = False Then
    ''            Call showMsg("2", "DATE", 0)            '�����t����MSG
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    ''
    ''        '�o�������ȑO�̓��t�̎��̓G���[
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '''        ElseIf DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.MONUPDDT Then
    ''            Call showMsg("1", "URKET53_010", 0)     '���o�����ߍς݂�MSG
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    ''        '�^�p��������t�̎��̓G���[
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) > gstrUnydt Then
    ''            Call showMsg("2", "DATE_1", 3)          '���^�p������t�G���[
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    '''ADD START FKS)INABA 2007/05/25 **************************************
    ''        ElseIf DeCNV_DATE(txt_kesidt.Text) > _
    '''            DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    ''            Call showMsg("1", "URKET53_038", 0)          '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
    ''            txt_kesidt.ForeColor = vbRed
    ''            txt_kesidt.SetFocus
    '''ADD  END  FKS)INABA 2007/05/25 **************************************
    ''        Else
    ''            txt_kesidt.ForeColor = vbBlack
    ''            chkKesidt = True
    ''        End If
    ''    End If
    ''    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    ''    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    ''
    ''End Function
    '// V2.00�� DEL

    '''�����溰�ނ̃`�F�b�N
    ''Private Function chkTokseicd() As Boolean
    ''    chkTokseicd = False
    ''
    ''    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    ''    If intChkKb = 1 Or txt_tokseicd.Text <> gstrTokseicd Then
    '''        '�w�b�_�A���ׂ̃N���A
    '''        initHead
    '''        initBody
    ''
    ''        '�ύX����Ă����獀�ڃN���A
    ''        If txt_tokseicd.Text <> gstrTokseicd Then
    ''            txt_tokseinma.Text = ""
    ''            txt_fridt.Text = "        " '8byte space
    ''            txt_fridt.Enabled = False
    ''
    ''            lbl_shakbnm(1).Caption = ""
    ''            lbl_hytokkesdd(1).Caption = ""
    ''            gstrFridt = Space(8)        'add 2007/03/29 Saito
    ''        End If
    ''
    ''        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
    ''        If Trim(txt_tokseicd.Text) = "" Then Exit Function
    ''
    ''        blnFriEnabled = False
    ''
    ''        '���Ӑ�Ͻ����琿���於�̂��擾
    ''        Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), txt_tokseicd.Text)
    ''            '����������̂Ƃ�
    ''            Case 0:
    ''                txt_tokseicd.ForeColor = vbBlack
    ''                txt_tokseinma.Text = DB_TOKMTA2.TOKNMA
    ''                lbl_shakbnm(1).Caption = DB_TOKMTA2.SHAKBNM
    ''                lbl_hytokkesdd(1).Caption = DB_TOKMTA2.HYTOKKESDD
    ''                '�x�������������U���A̧���ݸނ̎��͐U���������ڂ���͉Ƃ���
    ''                '���x�������̒l�ɉ����āA�����U�����͉\�t���O�����Ă�
    '''CHG START FKS) INABA 2007/05/08 *******************************************
    '''�x�������Ɏ�`�������Ă���ꍇ�͖��ׂ̐U����������͂ł���悤�ɂ���
    ''                Select Case DB_TOKMTA2.SHAKB
    ''                    Case "2", "3", "4", "5", "6"
    ''                        blnFriEnabled = True
    ''                End Select
    '''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '''                    blnFriEnabled = True
    '''                End If
    '''CHG  END  FKS) INABA 2007/05/08 *******************************************
    ''                txt_fridt.Enabled = blnFriEnabled
    ''                chkTokseicd = True
    ''
    ''            '�C�O������̂Ƃ�
    ''            Case 1:
    ''                Call showMsg("1", "URKET53_013", 0)     '�������̓��Ӑ�ł͂���܂���B     '2007.03.05
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''
    ''            '������łȂ����Ӑ�̂Ƃ�
    ''            Case 8:
    ''                Call showMsg("2", "DONTSELECT", "2")    '��������ł͂Ȃ�
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''
    ''            '�����悪���݂��Ȃ���
    ''            Case 9:
    ''                Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''        End Select
    ''    End If
    ''    gstrTokseicd = txt_tokseicd.Text
    ''    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    ''End Function

    '// V2.00�� UPD
    '''����\����t�̃`�F�b�N
    ''Private Function chkKaidt() As Boolean
    ''    chkKaidt = False
    ''
    ''    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    ''    If intChkKb = 1 Or txt_kaidt.Text <> CNV_DATE(gstrKaidt) Then
    '''        '�w�b�_�A���ׂ̃N���A
    '''        initHead
    '''        initBody
    ''
    ''        '���t�`���̃`�F�b�N
    ''        If IsDate(txt_kaidt.Text) = False Then
    ''            Call showMsg("2", "DATE", 0)            '�����t����MSG
    ''            txt_kaidt.ForeColor = vbRed
    ''            txt_kaidt.SetFocus
    '''ADD START FKS)INABA 2007/08/01 **************************************
    ''        ElseIf DeCNV_DATE(txt_kaidt.Text) > _
    '''            DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    ''            Call showMsg("1", "URKET53_038", 0)          '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
    ''            txt_kaidt.ForeColor = vbRed
    ''            txt_kaidt.SetFocus
    '''ADD  END  FKS)INABA 2007/08/01 **************************************
    ''        Else
    ''            txt_kaidt.ForeColor = vbBlack
    ''            chkKaidt = True
    ''        End If
    ''    End If
    ''    gstrKaidt = DeCNV_DATE(txt_kaidt.Text)
    ''    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    ''End Function
    '// V2.00�� UPD

    '// V2.06�� DEL
    ''�U�������̃`�F�b�N
    'Private Function chkFridt() As Boolean
    'On Error Resume Next
    '    chkFridt = False
    '
    '    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    '    If intChkKb = 1 Or txt_fridt.Text <> CNV_DATE(gstrFridt) Then
    '
    '        '�󔒎��̓`�F�b�N���Ȃ�(True��Ԃ�)
    '        If Trim(txt_fridt.Text) = "" Then
    '            txt_fridt.ForeColor = vbBlack
    '            chkFridt = True
    '
    '        '���t�`���̃`�F�b�N
    '        ElseIf IsDate(txt_fridt.Text) = False Then
    '            Call showMsg("2", "DATE", 0)            '�����t����MSG
    '            txt_fridt.ForeColor = vbRed
    '            txt_fridt.SetFocus
    ''ADD START FKS)INABA 2007/05/25 ******************************************
    '        '�o�������ȑO�̓��t�̎��̓G���[
    '        ElseIf DeCNV_DATE(txt_fridt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '            Call showMsg("1", "URKET53_010", 0)     '���o�����ߍς݂�MSG
    '            txt_fridt.ForeColor = vbRed
    '            txt_fridt.SetFocus
    ''ADD  END  FKS)INABA 2007/05/25 ******************************************
    '        Else
    '            txt_fridt.ForeColor = vbBlack
    '            chkFridt = True
    '
    '        End If
    '    Else
    '        chkFridt = True
    '    End If
    '    gstrFridt = DeCNV_DATE(txt_fridt.Text)
    '    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    'End Function
    '// V2.06�� DEL

    '// V2.00�� DEL
    '''�w�b�_���̓��̓`�F�b�N
    ''Private Function chkCondition() As Boolean
    ''    chkCondition = False
    ''
    ''    intChkKb = 1
    ''    If chkKesidt = True Then
    ''        intChkKb = 1
    ''        If chkTokseicd = True Then
    ''            intChkKb = 1
    ''            If chkKaidt = True Then
    ''                '�U�����������͂ł��鎞�͕K�{�Ƃ���
    ''                If blnFriEnabled = True Then
    ''                    '�����͎��̓G���[�Ƃ���
    ''                    If Trim(txt_fridt.Text) = "" Then
    ''                        Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
    ''                        txt_fridt.ForeColor = vbRed
    ''                        txt_fridt.SetFocus
    ''                        Exit Function
    ''                    End If
    ''
    ''                    intChkKb = 1
    ''                    If chkFridt = True Then
    ''                        chkCondition = True
    ''                    End If
    ''                Else
    ''                    chkCondition = True
    ''                End If
    ''            End If
    ''        '�����溰�ނ������͂̎��ʹװ�Ƃ���
    ''        Else
    ''            If Trim(txt_tokseicd.Text) = "" Then
    ''                Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
    ''                txt_tokseicd.ForeColor = vbRed
    ''                txt_tokseicd.SetFocus
    ''            End If
    ''        End If
    ''    End If
    ''End Function
    '// V2.00�� DEL




    '�S�������j���[�N���b�N��
    Public Sub mnu_zenkaijo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmd_zenkaijo_Click()
    End Sub

    '�S�I�����j���[�N���b�N��
    Public Sub mnu_zenkesi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        cmd_zenkesi_Click()
    End Sub

    Private Sub opt_sort_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles opt_sort.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = opt_sort.GetIndex(eventSender)

        '// V2.00�� ADD
        '�t�@���N�V�����L�[������
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00�� ADD

    End Sub

    '�w�b�_�p�l���}�E�X���[�u��
    Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        '�q���g�̕\��������������
        img_light.Image = img_bklight(0).Image
        txt_message.Text = ""
    End Sub

    '2019/04/26 DEL START
    ''�A�C�R��[�I��]�N���b�N��
    'Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.Close()
    'End Sub
    ''�A�C�R��[�I��]�}�E�X�_�E����
    'Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(1).Image
    'End Sub
    ''�A�C�R��[�I��]�}�E�X���[�u��
    'Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "���j���[�ɖ߂�܂��B"
    'End Sub
    ''�A�C�R��[�I��]�}�E�X�A�b�v��
    'Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_exit.Image = img_bkexit(0).Image
    'End Sub

    ''�A�C�R��[�o�^]�N���b�N��
    'Private Sub img_resist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_regist_Click(mnu_regist, New System.EventArgs())
    'End Sub

    ''�A�C�R��[�o�^]�}�E�X�_�E����
    'Private Sub img_resist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_resist.Image = img_bkresist(1).Image
    'End Sub
    ''�A�C�R��[�o�^]�}�E�X���[�u��
    'Private Sub img_resist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "�o�^���܂��B"
    'End Sub
    ''�A�C�R��[�o�^]�}�E�X�A�b�v��
    'Private Sub img_resist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_resist.Image = img_bkresist(0).Image
    'End Sub

    ''�A�C�R��[����]�N���b�N��
    'Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
    'End Sub

    ''�A�C�R��[����]�}�E�X�_�E����
    'Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(1).Image
    'End Sub
    ''�A�C�R��[����]�}�E�X���[�u��
    'Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "�E�B���h�E��\�����܂��B"
    'End Sub
    ''�A�C�R��[����]�}�E�X�A�b�v��
    'Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_showwnd.Image = img_bkshowwnd(0).Image
    'End Sub
    '2019/04/26 DEL E N D

    '�A�C�R��[����]�N���b�N��
    Private Sub img_unlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '// V2.00�� UPD
        ''    If blnUsableButton = True Then
        ''        pnl_condition1.Enabled = True
        ''        pnl_condition2.Enabled = True
        ''        txt_kesidt.SetFocus
        ''        initHead
        ''        initBody
        ''        blnUsableButton = False
        ''    End If
        If blnUsableButton = True Then
            blnUsableButton = False
            'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pnl_condition1.Enabled = True
            'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pnl_condition2.Enabled = True
            initHead()
            initBody()
            txt_kesidt.Focus()
            intInputMode = 1
            ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
            Call SSSWIN_Unlock_EXCTBZ()
            ' === 20130708 === INSERT E -
        End If
        '// V2.00�� UPD
    End Sub

    '2019/04/26 DEL START
    ''�A�C�R��[����]�}�E�X�_�E����
    'Private Sub img_unlock_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_unlock.Image = img_bkunlock(1).Image
    'End Sub
    ''�A�C�R��[����]�}�E�X���[�u��
    'Private Sub img_unlock_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_light.Image = img_bklight(1).Image
    '    txt_message.Text = "��ʂ��N���A���ăR�[�h�̓��͂�҂��܂��B"
    'End Sub
    ''�A�C�R��[����]�}�E�X�A�b�v��
    'Private Sub img_unlock_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    img_unlock.Image = img_bkunlock(0).Image
    'End Sub

    ''���j���[[����]�|[�I��]�I����
    'Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Me.Close()
    'End Sub
    '2019/04/26 DEL E N D

    '���j���[[����]�|[�o�^]�I����
    Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '2007/12/11 FKS)minamoto ADD START
        Dim intRtn As Short
        '2007/12/12 FKS)minamoto ADD END

        '�w�b�_���̓��̓`�F�b�N
        If chkCondition() = False Then Exit Sub
        '���ו��̓��̓`�F�b�N
        If blnUsableButton = False Then
            showMsg("0", "_UPDATE", "2") '�����ו������͂�MSG
            Exit Sub
        End If

        '2008/07/29 ADD START FKS)NAKATA
        'XX �ԕi�����̂Ȃ�������`�F�b�N

        If chkAkaKro() = False Then
            Exit Sub
        End If

        '// V2.13�� ADD
        If chkFurikomiDT() = False Then
            Exit Sub
        End If
        '// V2.13�� ADD

        '2008/07/29 ADD E.N.D FKS)NAKATA
        '2018/10/26 ADD START <C2-20181002-01> CIS)�R��
        Dim i As Short
        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
            With spd_body
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'For i = 1 To spd_body.MaxRows
                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .Row = i
                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .Col = 
                '�����ޯ��
                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    If .Value = 1 Then
                '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        .Col = COL_HYFRIDT '�U������
                '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        If Trim(.Text) <> "" Then
                '            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '            If F_GET_EIGYO_DAY(.Text) = 9 Then
                '                If showMsg("2", "URKET53_049", "0") = MsgBoxResult.No Then '���U���������c�Ɠ��ł͂���܂��񂪂�낵���ł����H
                '                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '                    .Action = 0
                '                    Exit Sub
                '                Else
                '                    Exit For
                '                End If
                '            End If
                '        End If
                '    End If
                'Next i
                For i = 0 To spd_body.RowCount - 1
                    '.Row = i
                    '.Col = COL_CHK '�����ޯ��

                    If .Rows(i).Cells(COL_CHK).Value Then '�����ς�
                        '�U���������󔒂łȂ��ꍇ
                        If Trim(.Rows(i).Cells(COL_HYFRIDT).Value) <> "" Then
                            If F_GET_EIGYO_DAY(.Text) = 9 Then
                                If showMsg("2", "URKET53_049", "0") = MsgBoxResult.No Then '���U���������c�Ɠ��ł͂���܂��񂪂�낵���ł����H
                                    .Rows(i).Cells(COL_HYFRIDT).ReadOnly = False
                                    Exit Sub
                                Else
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                Next i
                '2019/04/22 CHG E N D

            End With
        End If
        '2018/10/26 ADD END <C2-20181002-01> CIS)�R��

        '���o�^�m�F��MSG
        If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
            '�������̔��f
            If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
                showMsg("2", "UPDAUTH", "0")
                Exit Sub
            End If

            '�r���`�F�b�N
            If VB.Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
                MsgBox("�y" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
                '            Call HD_CLEAR
                '            Call P_vaData_Init
                Exit Sub
            Else
                Call SSSEXC_EXCTBZ_OPEN()
            End If

            '2008/07/30 DEL START FKS)NAKATA
            'XX        '2007/12/10 FKS)minamoto ADD START
            'XX        '�r���X�V�����`�F�b�N
            'XX
            'XX        intRtn = CHK_HAITA_UPD
            'XX        If intRtn = 0 Then
            'XX            '�G���[
            'XX            Call showMsg("2", "URKET53_039", 0) '���̃v���O�����ōX�V���ꂽ���߁A�o�^�ł��܂���B
            'XX            Exit Sub
            'XX        End If
            'XX        '2007/12/10 FKS)minamoto ADD END
            '2008/07/30 DEL E.N.D FKS)NAKATA

            '// V2.00�� UPD
            ''        Me.MousePointer = vbHourglass
            ''        If sRegistration(spd_body) = True Then
            ''            '�����O�̏����o��
            ''            Call SSSWIN_LOGWRT("�o�^����:" & Left(DB_TOKMTA2.TOKSEICD, 5) & ":" & DB_TOKMTA2.TOKRN)
            ''
            '''2008/07/30 DEL START FKS)NAKATA
            '''XX            '2007/12/11 FKS)minamoto ADD START
            '''XX            '�r�������폜
            '''XX            Call Execute_PLSQL_PRC_URKET53_03
            '''XX            '2007/12/11 FKS)minamoto ADD END
            '''2008/07/30 DEL E.N.D FKS)NAKATA
            ''
            ''            mnu_initdsp_Click   '��ʕ\���̏�����
            ''            txt_kesidt.SetFocus                     '2007.03.05
            ''        Else
            ''            '���X�V�������s��
            ''            MsgBox "�X�V�Ɏ��s���܂����B", vbCritical, "�X�V�G���["
            ''        End If
            '2009/10/22 ADD START RISE)MIYAJIMA
            intProcErrFlg = 0
            '2009/10/22 ADD E.N.D RISE)MIYAJIMA

            '2019/04/26 ADD START
            'Me.MousePointer = vbHourglass

            Select Case sRegistration(spd_body)
                Case 9
                    '���X�V�������s��
                    If intProcErrFlg = 1 Then
                        Call showMsg("2", "URKET53_044", 0) ' �c�z�ƈ�v���Ȃ��������������܂����B���~���܂��B
                    End If

                    MsgBox("�X�V�Ɏ��s���܂����B", vbCritical, "�X�V�G���[")

                Case 1

                Case 0
                    '�����O�̏����o��
                    Call SSSWIN_LOGWRT("�o�^����:" & LeftB(DB_TOKMTA2.TOKSEICD, 5) & ":" & DB_TOKMTA2.TOKRN)

                    '2019/05/07 CHG START
                    'mnu_initdsp_Click() '��ʏ�����
                    mnu_initdsp_Click(Button1, New System.EventArgs()) '��ʏ�����
                    '2019/05/07 CHG E N D
            End Select

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'UPGRADE_WARNING: mnu_regist_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

            '// V2.00�� UPD
            Me.Cursor = System.Windows.Forms.Cursors.Default


        End If

    End Sub

    '���j���[[�ҏW]�|[��ʏ�����]�I����
    Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '// V2.00�� UPD
        '    pnl_condition1.Enabled = True
        '    pnl_condition2.Enabled = True
        '    '��ʂ̏�����
        '    initCondition
        '    initHead
        '    initBody
        '    '�������Ƀt�H�[�J�X���ړ�
        '    txt_kesidt.SetFocus
        '    txt_kesidt.BackColor = vbYellow
        '    blnINIT_FLG = True

        intInputMode = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_condition1.Enabled = True
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pnl_condition2.Enabled = True
        '��ʂ̏�����
        initCondition()
        initHead()
        initBody()
        '�������Ƀt�H�[�J�X���ړ�
        txt_kesidt.Focus()
        txt_kesidt.BackColor = System.Drawing.Color.Yellow
        blnINIT_FLG = True
        '// V2.00�� UPD
        ' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
        Call SSSWIN_Unlock_EXCTBZ()
        ' === 20130708 === INSERT E -
    End Sub


    '���j���[[����]�|[���̈ꗗ]
    Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '�������Ƀt�H�[�J�X������Ƃ�
        'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        If Me.ActiveControl.Name = txt_kesidt.Name Then
            cmd_kesidt_Click()

            '�����溰�ނɃt�H�[�J�X������Ƃ�
            'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then
            cmd_tokseicd_Click()

            '// V2.00�� UPD
            ''    '����\����Ƀt�H�[�J�X������Ƃ�
            ''    ElseIf Me.ActiveControl.Name = txt_kaidt.Name Then
            ''        cmd_kaidt_Click

            '����\����Ƀt�H�[�J�X������Ƃ�
            'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then
            Call cmd_kaidt_From_Click()

            '����\����Ƀt�H�[�J�X������Ƃ�
            'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then
            Call cmd_kaidt_To_Click()
            '// V2.00�� UPD

            '�U�������Ƀt�H�[�J�X������Ƃ�
            'UPGRADE_ISSUE: Control Name �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        ElseIf Me.ActiveControl.Name = txt_fridt.Name Then
            cmd_fridt_Click()
        End If
    End Sub



    Private Sub spd_body_Change(ByVal Col As Integer, ByVal Row As Integer)
        Dim spd_fridt As String
        Dim spd_fridt_val As Object
        Dim ret As Boolean
        Dim lw_col As Integer
        Dim lw_row As Integer

        If Col = 14 Then '�����U�����̃`�F�b�N
            'ADD START FKS)INABA 2007/05/25 ******************************************
            lw_col = Col
            lw_row = Row
            '�o�������ȑO�̓��t�̎��̓G���[
            '2019/04/22 CHG START 
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'ret = spd_body.GetText(Col, Row, spd_fridt_val)
            'If ret = True Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_fridt_val �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")
            '    If Trim(spd_fridt) = "" Then
            '        blnUsableButton = True
            '    End If
            '    If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
            '        Call showMsg("1", "URKET53_010", CStr(0)) '���o�����ߍς݂�MSG
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Col = lw_col
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Row = lw_row
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Action = 0
            '        blnUsableButton = False
            '    Else
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Col = Col
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Row = Row
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Row = Row + 1
            '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        spd_body.Action = 0
            '        blnUsableButton = True
            '    End If
            'End If
            ''ADD  END  FKS)INABA 2007/05/25 ******************************************

            spd_fridt_val = spd_body.GetValue(Row, Col)
            If Trim(spd_fridt_val.ToString) <> "" Then

                spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")

                If Trim(spd_fridt) = "" Then
                    blnUsableButton = True
                End If
                If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
                    Call showMsg("1", "URKET53_010", CStr(0)) '���o�����ߍς݂�MSG
                    spd_body.Rows(lw_row).Cells(lw_col).Style.ForeColor = Color.Red
                    blnUsableButton = False
                Else
                    spd_body.Rows(Row).Cells(Col).Style.ForeColor = Color.Black
                    blnUsableButton = True
                End If
            End If
            '2019/04/22 CHG E N D
        End If
    End Sub

    Private Sub spd_body_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)

        '// V2.00�� ADD
        '�t�@���N�V�����L�[������
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00�� ADD

    End Sub

    Private Sub txt_fridt_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txt_fridt.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        'ADD START FKS)INABA 2007/05/25 ******************
        '���̓`�F�b�N
        chkFridt()

        '�w�i�F�𔒂ɖ߂�
        txt_fridt.BackColor = System.Drawing.Color.White
        'ADD  END  FKS)INABA 2007/05/25 ******************
        eventArgs.Cancel = Cancel
    End Sub

    '// V2.00�� DEL
    '''=======================================================������=======================================================
    ''
    ''
    '''���������ڂ�ύX������
    ''Private Sub txt_kesidt_Change()
    ''    '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''    If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''        txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''    ElseIf txt_kesidt.SelStart = 10 Then
    ''        intChkKb = 1                            '�����t�̓��̓`�F�b�N
    ''        txt_tokseicd.SetFocus                   '�����溰�ލ��ڂֈړ�
    ''    End If
    ''    txt_kesidt.SelLength = 1
    ''End Sub
    ''
    '''���������ڃN���b�N��
    ''Private Sub txt_kesidt_Click()
    ''    txt_kesidt.SelStart = 0
    ''    txt_kesidt.SelLength = 1
    ''End Sub
    ''
    '''���������ڂɃt�H�[�J�X���ڂ�����
    ''Private Sub txt_kesidt_GotFocus()
    ''    '���t�̏\�̈ʂ�I����Ԃɂ���
    ''    txt_kesidt.SelStart = 8
    ''    txt_kesidt.SelLength = 1
    ''    '�w�i�F�����F�ɂ���
    ''    txt_kesidt.BackColor = vbYellow
    ''    '�������������s�\�Ƃ���
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''���������ڂŃL�[����������
    ''Private Sub txt_kesidt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''    intChkKb = 0
    ''
    ''    '�E��� or Space������
    ''    If KEYCODE = vbKeyRight Or KEYCODE = vbKeySpace Then
    ''        If txt_kesidt.SelStart < 9 Then
    ''            txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''            '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''            If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''                txt_kesidt.SelStart = txt_kesidt.SelStart + 1
    ''            End If
    ''
    ''        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
    ''        Else
    ''            intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''            txt_tokseicd.SetFocus               '�����溰�ލ��ڂֈړ�
    ''        End If
    ''        txt_kesidt.SelLength = 1
    ''
    ''    'Backspace or ����󉟉���
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_kesidt.SelStart > 0 Then
    ''            txt_kesidt.SelStart = txt_kesidt.SelStart - 1
    ''            '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
    ''            If txt_kesidt.SelStart = 4 Or txt_kesidt.SelStart = 7 Then
    ''                txt_kesidt.SelStart = txt_kesidt.SelStart - 1
    ''            End If
    ''        End If
    ''        txt_kesidt.SelLength = 1
    ''
    ''    '���󉟉���
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        '�������Ȃ�
    ''
    ''    '����󉟉���
    ''    ElseIf KEYCODE = vbKeyDown Then
    ''        intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''        txt_tokseicd.SetFocus                   '�����溰�ލ��ڂֈړ�
    ''
    ''    'Enter������
    ''    ElseIf KEYCODE = vbKeyReturn Then
    ''        intChkKb = 1                            '�����t�̓��̓`�F�b�N
    ''        txt_tokseicd.SetFocus                   '�����溰�ލ��ڂֈړ�
    ''
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''���������ڂŃL�[����������
    ''Private Sub txt_kesidt_KeyPress(KeyAscii As Integer)
    ''    '���l�̂ݓ��͉Ƃ���
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''���������ڂ���t�H�[�J�X���ڂ�����
    ''Private Sub txt_kesidt_LostFocus()
    ''    '���̓`�F�b�N
    ''    chkKesidt
    ''    '�w�i�F�𔒂ɖ߂�
    ''    txt_kesidt.BackColor = vbWhite
    ''End Sub
    '// V2.00�� DEL


    '=======================================================�����溰��=======================================================


    '�����溰�ލ��ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_tokseicd.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_tokseicd_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.TextChanged
        Dim p As Short

        '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
        If blnUsableEvent = False Then Exit Sub

        blnUsableEvent = False
        p = txt_tokseicd.SelectionStart

        '�S�p���폜����
        txt_tokseicd.Text = delZenkaku((txt_tokseicd.Text))
        '���͒l��5byte�Ŗ������͋󔒖���
        txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))

        txt_tokseicd.SelectionStart = p
        blnUsableEvent = True

        '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
        If txt_tokseicd.SelectionStart = 5 Then
            intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
            '// V2.00�� UPD
            '���̓`�F�b�N
            If chkTokseicd() = True Then
                '������
                txt_kaidt_From.Focus()
            End If
            '// V2.00�� UPD
        End If
        txt_tokseicd.SelectionLength = 1

    End Sub

    '�����溰�ލ��ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_tokseicd_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Enter
        '�擪�ʒu��I����Ԃɂ���
        txt_tokseicd.SelectionStart = 0
        txt_tokseicd.SelectionLength = 1
        '�w�i�F�����F�ɂ���
        txt_tokseicd.BackColor = System.Drawing.Color.Yellow
        '�������������s�\�Ƃ���
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D
    End Sub

    '// V2.00�� UPD
    '�����溰�ލ��ڂŃL�[����������
    Private Sub txt_tokseicd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_tokseicd.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '�L�[���͐���
        Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
            Case 0
                '�������Ȃ�
            Case 1
                '���̓`�F�b�N
                If chkTokseicd() = True Then
                    '������
                    txt_kaidt_From.Focus()
                End If
            Case 2
                '���̓`�F�b�N
                If chkTokseicd() = True Then
                    '�O����
                    txt_kesidt.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub
    ''// V2.00�� UPD

    '�����溰�ލ��ڂŃL�[����������
    Private Sub txt_tokseicd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_tokseicd.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '�A���t�@�x�b�g��������啶���ɕϊ�����
        If Chr(KeyAscii) Like "[a-z]" Then
            KeyAscii = KeyAscii - 32
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '�����溰�ލ��ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_tokseicd_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Leave

        '�w�i�F�𔒂ɖ߂�
        txt_tokseicd.BackColor = System.Drawing.Color.White

    End Sub

    '// V2.00�� DEL
    ''=======================================================����\���=======================================================
    ''
    ''
    '''����\������ڂ�ύX������
    ''Private Sub txt_kaidt_Change()
    ''    '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''    If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''        txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''    ElseIf txt_kaidt.SelStart = 10 Then
    ''        intChkKb = 1                            '�����t�̓��̓`�F�b�N
    ''        txt_kesikb.SetFocus                     '����\������ڂֈړ�
    ''    End If
    ''    txt_kaidt.SelLength = 1
    ''End Sub
    ''
    '''����\������ڂɃt�H�[�J�X���ڂ�����
    ''Private Sub txt_kaidt_GotFocus()
    ''    '���t�̏\�̈ʂ�I����Ԃɂ���
    ''    txt_kaidt.SelStart = 8
    ''    txt_kaidt.SelLength = 1
    ''    '�w�i�F�����F�ɂ���
    ''    txt_kaidt.BackColor = vbYellow
    ''    '�������������s�\�Ƃ���
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''����\������ڂŃL�[����������
    ''Private Sub txt_kaidt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''
    ''    '�E��� or Space������
    ''    If KEYCODE = vbKeyRight Or KEYCODE = vbKeySpace Then
    ''        If txt_kaidt.SelStart < 9 Then
    ''            txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''            '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''            If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''                txt_kaidt.SelStart = txt_kaidt.SelStart + 1
    ''            End If
    ''
    ''        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
    ''        Else
    ''            intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''            txt_kesikb.SetFocus                 '�������ް��\�����ڂֈړ�
    ''        End If
    ''        txt_kaidt.SelLength = 1
    ''
    ''    'Backspace or ����󉟉���
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_kaidt.SelStart > 0 Then
    ''            txt_kaidt.SelStart = txt_kaidt.SelStart - 1
    ''            '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
    ''            If txt_kaidt.SelStart = 4 Or txt_kaidt.SelStart = 7 Then
    ''                txt_kaidt.SelStart = txt_kaidt.SelStart - 1
    ''            End If
    ''
    ''        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
    ''        Else
    ''            intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''            txt_tokseicd.SetFocus               '�����溰�ލ��ڂֈړ�
    ''        End If
    ''        txt_kaidt.SelLength = 1
    ''
    ''    '���󉟉���
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''        txt_tokseicd.SetFocus                   '�����溰�ލ��ڂֈړ�
    ''
    ''    '����󉟉���
    ''    ElseIf KEYCODE = vbKeyDown Then
    ''        intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''        txt_kesikb.SetFocus                     '�������ް��\�����ڂֈړ�
    ''
    ''    'Enter������
    ''    ElseIf KEYCODE = vbKeyReturn Then
    ''        intChkKb = 1                            '�����t�̓��̓`�F�b�N
    ''        txt_kesikb.SetFocus                     '�������ް��\�����ڂֈړ�
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''����\������ڂŃL�[����������
    ''Private Sub txt_kaidt_KeyPress(KeyAscii As Integer)
    ''    '���l�̂ݓ��͉Ƃ���
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''����\������ڂ���t�H�[�J�X���ڂ�����
    ''Private Sub txt_kaidt_LostFocus()
    ''    '���̓`�F�b�N
    ''    chkKaidt
    ''    '�w�i�F�𔒂ɖ߂�
    ''    txt_kaidt.BackColor = vbWhite
    ''End Sub
    '// V2.00�� DEL


    '=======================================================�����ς��ް��\��=======================================================


    '�����ς��ް��\�����ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_kesikb.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_kesikb_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.TextChanged
        If CDbl(txt_kesikb.Text) <> 9 Then
            txt_kesikb.Text = CStr(1)
        End If
        txt_kesikb.SelectionStart = 0
        txt_kesikb.SelectionLength = 1
        '// V2.00�� ADD
        If CDbl(txt_kesikb.Text) = 1 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g cmd_kaidt_From.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            cmd_kaidt_From.Text = " �����(�J�n)"
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g cmd_kaidt_From.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            cmd_kaidt_From.Text = " *�����(�J�n)"
        End If
        '// V2.00�� ADD
    End Sub

    '�����ς��ް��\�����ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_kesikb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Enter
        '�I����Ԃɂ���
        txt_kesikb.SelectionStart = 0
        txt_kesikb.SelectionLength = 1
        '�w�i�F�����F�ɂ���
        txt_kesikb.BackColor = System.Drawing.Color.Yellow

        '�������������s�s�Ƃ���
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = False
        Button5.Enabled = False
        '2019/04/26 CHG E N D
    End Sub

    '�����ς��ް��\�����ڂŃL�[����������
    Private Sub txt_kesikb_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesikb.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '// V2.00�� ADD
        '�t�@���N�V�����L�[������
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(KeyCode, Shift)
        End If
        '// V2.00�� ADD

        '���� or ����󉟉���
        If KeyCode = System.Windows.Forms.Keys.Up Or KeyCode = System.Windows.Forms.Keys.Left Then
            txt_kaidt_To.Focus()

            'Enter or ����� or �E��󉟉���
        ElseIf KeyCode = System.Windows.Forms.Keys.Return Or KeyCode = System.Windows.Forms.Keys.Down Or KeyCode = System.Windows.Forms.Keys.Right Then
            '������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
            '����ȊO�͏����Ώۂ�����
            If blnFriEnabled = True Then
                txt_fridt.Focus()
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'spd_body.SetFocus()
                spd_body.Focus()
                '2019/04/22 CHG E N D

            End If
            '// V2.00�� UPD
            'TAB��
        ElseIf KeyCode = System.Windows.Forms.Keys.F16 Then
            '������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
            '����ȊO�͏����Ώۂ�����
            If blnFriEnabled = True Then
                txt_fridt.Focus()
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'spd_body.SetFocus()
                spd_body.Focus()
                '2019/04/22 CHG E N D
            End If
            '// V2.00�� UPD

            '// V2.00�� UPD
            'TAB��
        ElseIf KeyCode = System.Windows.Forms.Keys.F15 Then
            txt_kaidt_To.Focus()
            '// V2.00�� UPD

        End If

        KeyCode = 0
    End Sub

    '�����ς��ް��\�����ڂŃL�[����������
    Private Sub txt_kesikb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesikb.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '���l�̂ݓ��͉Ƃ���
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '�����ς��ް��\�����ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_kesikb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Leave
        '�w�i�F�𔒂ɖ߂�
        txt_kesikb.BackColor = System.Drawing.Color.White
    End Sub

    '// V2.00�� DEL
    '''=======================================================�U������=======================================================
    ''
    ''
    '''�U���������ڂ�ύX������
    ''Private Sub txt_fridt_Change()
    ''    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    ''    If blnUsableEvent = False Then Exit Sub
    ''
    ''    '������8�����ɂȂ�����X���b�V���������쐬
    ''    If Len(Trim(txt_fridt.Text)) = 8 Then
    ''        blnUsableEvent = False
    ''
    ''        txt_fridt.Text = Left(txt_fridt.Text, 4) & "/" & Mid(txt_fridt.Text, 5, 2) & "/" & Right(txt_fridt.Text, 2)
    ''        intChkKb = 1                            '�����t�̓��̓`�F�b�N
    ''        spd_body.SetFocus
    ''
    ''        blnUsableEvent = True
    ''
    ''    ElseIf Len(txt_fridt.Text) = 10 Then
    ''        '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''        If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''        ElseIf txt_fridt.SelStart = 10 Then
    ''            intChkKb = 1                        '�����t�̓��̓`�F�b�N
    ''            spd_body.SetFocus
    ''        End If
    ''    End If
    ''    txt_fridt.SelLength = 1
    ''End Sub
    ''
    '''�U���������ڂɃt�H�[�J�X���ڂ�����
    ''Private Sub txt_fridt_GotFocus()
    '''// V2.00�� UPD
    '''    '���t�̏\�̈ʂ�I����Ԃɂ���
    '''    txt_fridt.SelStart = 0
    '''    txt_fridt.SelLength = 1
    ''    If Trim(txt_fridt) = "" Then
    ''        '�Ȃɂ������Ă��Ȃ��̂ōŏ��ֈʒu�Â�
    ''        txt_fridt.SelStart = 0
    ''        txt_fridt.SelLength = 1
    ''    Else
    ''        '�Ȃɂ������Ă�������t�̏\�̈ʂ�I����Ԃɂ���
    ''        txt_fridt.SelStart = 8
    ''        txt_fridt.SelLength = 1
    ''    End If
    '''// V2.00�� UPD
    ''    '�w�i�F�����F�ɂ���
    ''    txt_fridt.BackColor = vbYellow
    ''    '�������������s�\�Ƃ���
    ''    mnu_showwnd.Enabled = True
    ''End Sub
    ''
    '''�U���������ڂŃL�[����������
    ''Private Sub txt_fridt_KeyDown(KEYCODE As Integer, Shift As Integer)
    ''
    ''    '�E��󉟉���
    ''    If KEYCODE = vbKeyRight Then
    ''        If txt_fridt.SelStart < 9 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''            '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
    ''            If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''                txt_fridt.SelStart = txt_fridt.SelStart + 1
    ''            End If
    ''
    ''        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
    ''        Else
    ''            intChkKb = 1                    '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''            spd_body.SetFocus
    ''        End If
    ''        txt_fridt.SelLength = 1
    ''
    ''    'Backspace or ����󉟉���
    ''    ElseIf KEYCODE = vbKeyBack Or KEYCODE = vbKeyLeft Then
    ''        If txt_fridt.SelStart > 0 Then
    ''            txt_fridt.SelStart = txt_fridt.SelStart - 1
    ''            '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
    ''            If txt_fridt.SelStart = 4 Or txt_fridt.SelStart = 7 Then
    ''                txt_fridt.SelStart = txt_fridt.SelStart - 1
    ''            End If
    ''
    ''        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
    ''        Else
    ''            intChkKb = 2                    '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''            txt_kesikb.SetFocus
    ''        End If
    ''        txt_fridt.SelLength = 1
    ''
    ''    '���󉟉���
    ''    ElseIf KEYCODE = vbKeyUp Then
    ''        intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
    ''        txt_kesikb.SetFocus
    ''
    ''    'Enter or ����󉟉���
    ''    ElseIf KEYCODE = vbKeyReturn Or KEYCODE = vbKeyDown Then
    ''        intChkKb = 1                        '�����t�̓��̓`�F�b�N
    ''        spd_body.SetFocus
    ''    End If
    ''
    ''    KEYCODE = 0
    ''End Sub
    ''
    '''�U���������ڂŃL�[����������
    ''Private Sub txt_fridt_KeyPress(KeyAscii As Integer)
    ''    '���l�̂ݓ��͉Ƃ���
    ''    If Not Chr(KeyAscii) Like "[0-9]" Then
    ''        KeyAscii = 0
    ''    End If
    ''End Sub
    ''
    '''�U���������ڂ���t�H�[�J�X���ڂ�����
    ''Private Sub txt_fridt_LostFocus()
    '''DEL START FKS)INABA 2007/05/25 ******************
    '''    '���̓`�F�b�N
    '''    chkFridt
    '''
    '''    '�w�i�F�𔒂ɖ߂�
    '''    txt_fridt.BackColor = vbWhite
    '''DEL  END  FKS)INABA 2007/05/25 ******************
    ''End Sub
    '// V2.00�� DEL



    '=======================================================���ו�(�X�v���b�h)=======================================================

    '�t�H�[�J�X�擾��
    Private Sub spd_body_GotFocus()
        '// V2.00�� ADD
        If intInputMode <> 1 Then
            Exit Sub
        End If
        '// V2.00�� ADD
        '���݂��g�p�\(�����ް�����)�̎��͎��s���Ȃ�COL_MINYUKN
        If blnUsableButton = True Then Exit Sub

        '�w�b�_�����͂���Ă�����f�[�^�������E�\������
        If chkCondition() = True Then
            '// V2.00�� ADD
            intInputMode = 2
            '// V2.00�� ADD
            showBody() '���ް��\��
            '2007/11/26 FKS)minamoto ADD START
            '�ԕi���������A���b�N
            lockHenpin()
            '2007/11/26 FKS)minamoto ADD END
        End If
    End Sub

    '�������ݸد���
    Private Sub spd_body_ButtonClicked(ByVal Col As Integer, ByVal Row As Integer, ByVal ButtonDown As Short)

        Dim intKesizan As Decimal '�w�b�_�������c�z
        Dim intKomikn As Decimal '�ō�����z
        Dim intKesikn As Decimal '�����z
        Dim intBfKesikn As Decimal '�����z(�����O)
        Dim tmp As Object
        'ADD START FKS)INABA 2007/07/30 **********************************
        Dim LS_HYFRIDT As Object
        'ADD  END  FKS)INABA 2007/07/30 **********************************
        '2007/11/26 FKS)minamoto ADD START
        Dim sumHenpin As Decimal
        Dim intJDNNOKesikn As Decimal
        Dim intHenkn As Decimal
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short
        Dim idxRowJDNNO As Integer
        '2007/11/26 FKS)minamoto ADD END

        '2009/09/27 ADD START RISE)MIYAJIMA
        Dim vntTmp As Object
        '2009/09/27 ADD E.N.D RISE)MIYAJIMA

        '// V2.00�� ADD
        '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
        If blnUsableSpread = False Then
            Exit Sub
        End If
        '// V2.00�� ADD

        On Error Resume Next
        '// V2.00�� DEL
        ''''    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
        ''''    If blnUsableSpread = False Then Exit Sub
        '// V2.00�� DEL

        With spd_body
            '�����ޯ���د����A���ׂ̋��z�A�w�b�_�̎c���z�ɉ����ă`�F�b�N��ON�AOFF���s��
            '2019/05/09 CHG START
            'If Col = 1 Then
            If Col = COL_CHK Then
                '2019/05/09 CHG E N D

                '2019/04/22 DEL START
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Col = Col
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Row = Row

                '�\���s�ȏ�̍s���N���b�N�������̓`�F�b�N�͂��Ȃ�
                If Row > intMaxRow Then
                    '�����������Ȃ�
                    blnUsableSpread = False
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    '.Value = 0
                    .SetValue(Row, Col, False)
                    '2019/04/22 CHG E N D
                    blnUsableSpread = True
                    Exit Sub
                End If

                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKesizan = SSSVal((txt_kesizan.Text))

                '�ō�����z���擾
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KOMIKN, .Row, tmp)
                tmp = .GetValue(Row, COL_KOMIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKomikn = SSSVal(tmp)
                '// V2.00�� UPD
                ''''            '���ו������z - �����ȑO�����z
                ''''            Call .GetText(COL_KESIKN, .Row, tmp)
                ''''            intKesikn = SSSVal(tmp)
                ''''            '�����ȑO�����z
                ''''            Call .GetText(COL_BFKESIKN, .Row, tmp)
                ''''            intBfKesikn = SSSVal(tmp)
                '// V2.01�� UPD
                '            '�O�����z
                '            Call .GetText(COL_KESIKN_MAE, .Row, tmp)
                '            intKesikn = SSSVal(tmp)
                '���ו������z
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, .Row, tmp)
                tmp = .GetValue(Row, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKesikn = SSSVal(tmp)
                '// V2.01�� UPD
                '// V2.00�� UPD

                '�������t���Ă��āA����������
                If ButtonDown = 0 Then
                    '2008/07/31 DEL START FKS)NAKATA
                    'XX
                    'XX            '2007/11/26 FKS)minamoto CHG START
                    'XX            '    '�����z���v���X�ł���΁A�������Ƀw�b�_���ɉ��Z
                    'XX            '    If intKesikn - intBfKesikn > 0 Then
                    'XX            '        txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    'XX            '        .SetText COL_KESIKN, .Row, intBfKesikn
                    'XX'ADD START FKS)INABA 2007/07/30 **********************************
                    'XX            '        If DB_TOKMTA2.SHAKB Like "[256]" Then
                    'XX            '            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    'XX            '            If Trim$(LS_HYFRIDT) <> "" Then
                    'XX            '                .SetText COL_HYFRIDT, .Row, ""
                    'XX            '            End If
                    'XX            '        End If
                    'XX'ADD  END  FKS)INABA 2007/07/30 **********************************
                    'XX            '    ElseIf intKesizan >= intBfKesikn - intKesikn Then
                    'XX            '        txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    'XX            '        .SetText COL_KESIKN, .Row, intBfKesikn
                    'XX
                    'XX
                    'XX                '�ԕi�ł���΃`�F�b�N�������Ȃ�
                    'XX                If intKesikn < 0 Then
                    'XX                    blnUsableSpread = False
                    'XX                    .Value = 1
                    'XX                    blnUsableSpread = True
                    'XX                    '�󒍔ԍ��擾
                    'XX
                    'XX                    Exit Sub
                    'XX                End If
                    'XX
                    'XX
                    'XX                Call .GetText(COL_HYJDNNO, .Row, tmp)
                    'XX                strHYJDNNO = CStr(tmp)
                    'XX                '�ԕi�z�N���A
                    'XX
                    'XX                sumHenpin = 0
                    'XX                '����󒍔ԍ��̕ԕi������
                    'XX
                    'XX                For idxRowJDNNO = intMaxRow To 1 Step -1
                    'XX                    .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                    'XX                    str_theHYJDNNO = CStr(tmp)
                    'XX                    '�󒍔ԍ���v
                    'XX
                    'XX                    If strHYJDNNO <> str_theHYJDNNO Then
                    'XX                    Else
                    'XX                        '�������g�łȂ�
                    'XX                        If idxRowJDNNO = .Row Then
                    'XX                        Else
                    'XX                            '�����ϊz���擾
                    'XX
                    'XX                            Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                    'XX                            intJDNNOKesikn = SSSVal(tmp)
                    'XX                            '�ԕi�̏ꍇ
                    'XX
                    'XX
                    'XX                            If intJDNNOKesikn < 0 Then
                    'XX                                '�ԕi���z�����߂�
                    'XX                                sumHenpin = sumHenpin - intJDNNOKesikn
                    'XX                                '�ԕi�z���傫���ꍇ�͉������Ȃ�
                    'XX
                    'XX
                    'XX                                End If
                    'XX                       End If
                    'XX                    End If
                    'XX                Next idxRowJDNNO
                    'XX
                    'XX
                    'XX
                    'XX                If sumHenpin > intKesikn - intBfKesikn Then
                    'XX                    '�����������Ȃ�
                    'XX
                    'XX                    blnUsableSpread = False
                    'XX                    .Value = 1
                    'XX                    blnUsableSpread = True
                    'XX                    Exit Sub
                    'XX                End If
                    'XX
                    'XX
                    'XX                '�ԕi�z���c���č�������
                    'XX                intHenkn = intKesikn - intBfKesikn - sumHenpin
                    'XX                txt_kesizan.Text = Format(intKesizan + intHenkn, "###,###,##0")
                    'XX                .SetText COL_KESIKN, .Row, intKesikn - intHenkn
                    'XX
                    'XX
                    'XX
                    'XX                '�`�F�b�N����
                    'XX                blnUsableSpread = False
                    'XX                .Value = 0
                    'XX                blnUsableSpread = True
                    'XX            '2007/11/26 FKS)minamoto CHG END
                    'XX'ADD START FKS)INABA 2007/07/30 **********************************
                    'XX                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                    'XX                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    'XX                        If Trim$(LS_HYFRIDT) <> "" Then
                    'XX                            .SetText COL_HYFRIDT, .Row, ""
                    'XX                        End If
                    'XX                    End If
                    'XX'ADD  END  FKS)INABA 2007/07/30 **********************************
                    'XX            '2007/11/26 FKS)minamoto DEL START
                    'XX            '    Else
                    'XX            '        '�����������Ȃ�
                    'XX            '        blnUsableSpread = False
                    'XX            '        .Value = 1
                    'XX            '        blnUsableSpread = True
                    'XX            '    End If
                    'XX            '2007/11/26 FKS)minamoto DEL END
                    'XX
                    '2008/07/31 DEL E.N.D FKS)NAKATA

                    '2019/05/09 ADD START
                    .SetValue(Row, Col, False)
                    '2019/05/09 ADD E N D

                    '2008/07/31 ADD START FKS)NAKATA
                    '�����z���v���X�ł���΁A�������Ƀw�b�_���ɉ��Z
                    If intKesikn - intBfKesikn > 0 Then
                        txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intBfKesikn)
                        .SetValue(Row, COL_KESIKN, intBfKesikn)
                        '2019/04/22 CHG E N D
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                        LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(LS_HYFRIDT) <> "" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, "")
                            .SetValue(Row, COL_HYFRIDT, "")
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA

                    ElseIf intKesizan >= intBfKesikn - intKesikn Then
                        txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intBfKesikn)
                        .SetValue(Row, COL_KESIKN, intBfKesikn)
                        ''2019/04/22 CHG E N D

                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                        LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                        '2019/04/22 CHG E N D

                        'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(LS_HYFRIDT) <> "" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, "")
                            .SetValue(Row, COL_HYFRIDT, "")
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA

                    Else
                        '�����������Ȃ�
                        blnUsableSpread = False
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.Value = 1
                        .SetValue(Row, Col, True)
                        '2019/04/22 CHG E N D

                        blnUsableSpread = True
                    End If
                    '2008/07/31 ADD E.N.D FKS)NAKATA

                    '�������t���Ă��Ȃ��āA�`�F�b�N����ꂽ��
                ElseIf ButtonDown = 1 Then
                    '2007/11/26 FKS)minamoto CHG START
                    '�����z���}�C�i�X�ł���΁A�������Ƀw�b�_���ɉ��Z
                    'If intKomikn - intKesikn < 0 Then
                    '    txt_kesizan.Text = Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                    '    .SetText COL_KESIKN, .Row, intKomikn
                    'ADD START FKS)INABA 2007/07/30 **********************************
                    '    If DB_TOKMTA2.SHAKB Like "[256]" Then
                    '        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    '
                    '        If Trim$(LS_HYFRIDT) = "" Then
                    '            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                    '        End If
                    '    End If
                    'ADD  END  FKS)INABA 2007/07/30 **********************************
                    '�w�b�_�����c�����̎��̓`�F�b�N�����Ȃ�
                    'ElseIf intKesizan <= 0 Then

                    '2019/05/09 ADD START
                    .SetValue(Row, Col, True)
                    '2019/05/09 ADD E N D

                    '2008/07/31 ADD START FKS)NAKATA
                    '�����z���}�C�i�X�ł���Τ�������Ƀw�b�_���ɉ��Z
                    If intKomikn - intKesikn < 0 Then
                        txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKomikn)
                        .SetValue(Row, COL_KESIKN, intKomikn)
                        '2019/04/22 CHG E N D
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g vntTmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        '�w�b�_�����c�����̎��̓`�F�b�N�����Ȃ�
                    ElseIf intKesizan <= 0 Then

                        'XX                If intKesizan <= 0 Then
                        'XX                '2007/11/26 FKS)minamoto CHG END
                        '2008/07/31 ADD E.N.D FKS)NAKATA

                        blnUsableSpread = False
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.Value = 0
                        .SetValue(Row, Col, False)
                        '2019/04/22 CHG E N D
                        blnUsableSpread = True

                    ElseIf intKesizan >= intKomikn - intKesikn Then
                        txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKomikn)
                        .SetValue(Row, COL_KESIKN, intKomikn)
                        '2019/04/22 CHG E N D
                        'ADD START FKS)INABA 2007/07/30 **********************************
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g vntTmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        'M                    End If
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        'ADD  END  FKS)INABA 2007/07/30 **********************************

                    Else
                        txt_kesizan.Text = VB6.Format(0, "###,###,##0")
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.SetText(COL_KESIKN, .Row, intKesikn + intKesizan)
                        .SetValue(Row, COL_KESIKN, intKesikn + intKesizan)
                        '2019/04/22 CHG E N D
                        'ADD START FKS)INABA 2007/07/30 **********************************
                        '2009/09/27 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        '                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        '                        If Trim$(LS_HYFRIDT) = "" Then
                        '                            .SetText COL_HYFRIDT, .Row, txt_fridt.Text
                        '                        End If
                        '                    End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        '                    If DB_TOKMTA2.SHAKB Like "[256]" Then
                        'M                    If Trim(txt_fridt.Text) <> "" Then
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_BFHYFRIDT, .Row, vntTmp)
                        vntTmp = .GetValue(Row, COL_BFHYFRIDT)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g vntTmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(vntTmp) = "" Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
                            LS_HYFRIDT = .GetValue(Row, COL_HYFRIDT)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            If Trim(LS_HYFRIDT) = "" Then
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                '.SetText(COL_HYFRIDT, .Row, txt_fridt.Text)
                                .SetValue(Row, COL_HYFRIDT, txt_fridt.Text)
                                '2019/04/22 CHG E N D
                            End If
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.SetText(COL_HYFRIDT, .Row, vntTmp)
                            .SetValue(Row, COL_HYFRIDT, vntTmp)
                            '2019/04/22 CHG E N D
                        End If
                        '2009/10/01 UPD START RISE)MIYAJIMA
                        'M                    End If
                        '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                        '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                        'ADD  END  FKS)INABA 2007/07/30 **********************************
                    End If
                End If
            End If
        End With
    End Sub

    '�萔�����ݎ��s��
    Private Sub cmd_tesuryo_Click()

        '// V3.30�� ADD
        Dim tmp As Object
        Dim intchk As Integer
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer

        Dim kesizan As Decimal '�w�b�_�������c�z
        Dim kesikn As Decimal '���׍s�̓����ϊz
        '// V3.30�� ADD


        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '�����z������ʂ̕\��
        VB6.ShowForm(FR_SSSSUB, (VB6.FormShowConstants.Modal))

        '// V2.00�� ADD
        '�w�b�_���̍ĕ\��
        showHead()
        '// V2.00�� ADD

        '2009/10/22 ADD START RISE)MIYAJIMA
        Dim kesikn_ATO As Decimal '���׍s�̓����ϊz(��)
        Dim kesikn_MAE As Decimal '���׍s�̓����ϊz(��)
        With spd_body
            '�w�b�_�������c�z�̑ޔ�
            kesizan = CDec(txt_kesizan.Text)
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '�����z�̎擾
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                kesikn_ATO = kesikn_ATO + CDec(tmp)
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                kesikn_MAE = kesikn_MAE + CDec(tmp)
            Next idxRow
            kesizan = kesizan + kesikn_MAE - kesikn_ATO
            txt_kesizan.Text = VB6.Format(kesizan, "###,###,##0")
        End With
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

        '2009/09/24 DEL START RISE)MIYAJIMA
        ''// V3.30�� ADD
        '    '�w�b�_�������c�z�̑ޔ�
        '    kesizan = txt_kesizan.Text
        '
        '    With spd_body
        '        For idxRow = 1 To intMaxRow
        '            '�`�F�b�N�������Ă��邩���m�F
        '            .GetText COL_CHK, idxRow, tmp
        '            intchk = SSSVal(tmp)
        '
        '            '�`�F�b�N�������Ă���ꍇ
        '            If intchk = 1 Then
        '                '�����z�̎擾
        '                Call .GetText(COL_KESIKN, idxRow, tmp)
        '                kesikn = kesikn + CCur(tmp)
        '            End If
        '
        '       Next idxRow
        '    End With
        '
        '    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
        ''// V3.30�� ADD
        '2009/09/24 DEL E.N.D RISE)MIYAJIMA

    End Sub

    '����Ŋz���ݎ��s��
    Private Sub cmd_syohi_Click()

        '// V3.30�� ADD
        Dim tmp As Object
        Dim intchk As Integer
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer

        Dim kesizan As Decimal '�w�b�_�������c�z
        Dim kesikn As Decimal '���׍s�̓����ϊz
        '// V3.30�� ADD

        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '�����z������ʂ̕\��
        VB6.ShowForm(FR_SSSSUB, (VB6.FormShowConstants.Modal))

        '// V2.00�� ADD
        '�w�b�_���̍ĕ\��
        showHead()
        '// V2.00�� ADD

        '2009/10/22 ADD START RISE)MIYAJIMA
        Dim kesikn_ATO As Decimal '���׍s�̓����ϊz(��)
        Dim kesikn_MAE As Decimal '���׍s�̓����ϊz(��)
        With spd_body
            '�w�b�_�������c�z�̑ޔ�
            kesizan = CDec(txt_kesizan.Text)
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '�����z�̎擾
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                kesikn_ATO = kesikn_ATO + CDec(tmp)
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                kesikn_MAE = kesikn_MAE + CDec(tmp)
            Next idxRow
            kesizan = kesizan + kesikn_MAE - kesikn_ATO
            txt_kesizan.Text = VB6.Format(kesizan, "###,###,##0")
        End With
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

        '2009/09/24 DEL START RISE)MIYAJIMA
        ''// V3.30�� ADD
        '    '�w�b�_�������c�z�̑ޔ�
        '    kesizan = txt_kesizan.Text
        '
        '    With spd_body
        '        For idxRow = 1 To intMaxRow
        '            '�`�F�b�N�������Ă��邩���m�F
        '            .GetText COL_CHK, idxRow, tmp
        '            intchk = SSSVal(tmp)
        '
        '            '�`�F�b�N�������Ă���ꍇ
        '            If intchk = 1 Then
        '                '�����z�̎擾
        '                Call .GetText(COL_KESIKN, idxRow, tmp)
        '                kesikn = kesikn + CCur(tmp)
        '            End If
        '
        '       Next idxRow
        '    End With
        '
        '    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
        ''// V3.30�� ADD
        '2009/09/24 DEL E.N.D RISE)MIYAJIMA


    End Sub

    '�S�������ݎ��s��
    Private Sub cmd_zenkesi_Click()
        Dim i As Short
        Dim varKesikn As Object

        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '2008/07/25 ADD START FKS)NAKATA
        ''�S�����{�^�����������́A�����\�����Ɠ��������ΏۂɃ`�F�b�N������B
        lockHenpin()
        '2008/07/25 ADD E.N.D FKS)NAKATA

        '�S�s�ɑ΂��A�����ޯ��������
        '2019/04/25 CHG START
        'For i = 1 To intMaxRow
        For i = 0 To intMaxRow - 1
            '2019/04/25 CHG E N D
            With spd_body
                '2019/04/22 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Col = COL_CHK
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Row = i
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'If .Value = 0 Then
                '    '�S�������Ƀ`�F�b�N������Ȃ��s����C�� 2007/02/28 Saito
                '    spd_body_ButtonClicked(COL_CHK, i, 1)
                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .GetText(COL_KESIKN, i, varKesikn)
                '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(varKesikn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    If SSSVal(varKesikn) <> 0 Then
                '        blnUsableSpread = False
                '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        .Value = 1
                '        blnUsableSpread = True
                '    End If
                'End If
                If .Rows(i).Cells(COL_CHK).Value = False Then
                    '�S�������Ƀ`�F�b�N������Ȃ��s����C�� 
                    spd_body_ButtonClicked(COL_CHK, i, 1)
                    varKesikn = .GetValue(i, COL_KESIKN)
                    If SSSVal(varKesikn) <> 0 Then
                        blnUsableSpread = False
                        .SetValue(i, COL_CHK, True)
                        blnUsableSpread = True
                    End If
                End If
                '2019/04/22 CHG E N D
            End With
        Next i

    End Sub

    '�S�������ݎ��s��
    Private Sub cmd_zenkaijo_Click()
        Dim i As Short
        Dim varKesikn As Object
        Dim varBfKesikn As Object

        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '�S�s�ɑ΂��A�����ޯ���̉���
        '2019/04/25 CHG START
        'For i = 1 To intMaxRow
        For i = 0 To intMaxRow - 1
            '2019/04/25 CHG E N D
            With spd_body
                '2019/04/22 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Col = COL_CHK
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.Row = i
                ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'If .Value = 1 Then
                '    '�������Ƀ`�F�b�N���O��Ȃ��s����C�� 2007/02/28 Saito
                '    spd_body_ButtonClicked(COL_CHK, i, 0)

                '    '2008/07/31 CHG START FKS)NAKATA
                '    'XX �ԕi�����b�N���Ȃ��Ȃ������ߍ폜������

                '    '2007/11/26 FKS)minamoto DEL START
                '    '.GetText COL_KESIKN, i, varKesikn
                '    '.GetText COL_BFKESIKN, i, varBfKesikn
                '    'If SSSVal(varKesikn) - SSSVal(varBfKesikn) = 0 Then
                '    '    blnUsableSpread = False
                '    '    .Value = 0
                '    '    blnUsableSpread = True
                '    'End If
                '    '2007/11/26 FKS)minamoto DEL END

                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .GetText(COL_KESIKN, i, varKesikn)
                '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .GetText(COL_BFKESIKN, i, varBfKesikn)
                '    '// V2.02�� UPD
                '    ''''                If SSSVal(varKesikn) - SSSVal(varBfKesikn) = 0 Then
                '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(varKesikn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    If SSSVal(varKesikn) = 0 Then
                '        '// V2.02�� UPD
                '        blnUsableSpread = False
                '        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        .Value = 0
                '        blnUsableSpread = True
                '    End If
                '    '2008/07/31 CHG E.N.D FKS)NAKATA
                'End If

                If .Rows(i).Cells(COL_CHK).Value Then

                    spd_body_ButtonClicked(COL_CHK, i, 0)

                    varKesikn = .GetValue(i, COL_KESIKN)

                    varBfKesikn = .GetValue(i, COL_BFKESIKN)

                    If SSSVal(varKesikn) = 0 Then
                        blnUsableSpread = False

                        .SetValue(i, COL_CHK, False)
                        blnUsableSpread = True
                    End If
                End If
                '2019/04/22 CHG E N D
            End With
        Next i
    End Sub

    '�ĕ\�����ݎ��s��
    Private Sub cmd_saihyoji_Click()
        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '// V2.00�� ADD
        If ChkInputChange() = True Then
            If showMsg("1", "URKET53_040", CStr(0)) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        '// V2.00�� ADD

        '�w�b�_���̍ĕ\��
        '// V2.00�� DEL
        ''''    showHead
        '// V2.00�� DEL
        '// V2.00�� ADD
        '�w�b�_�����͂���Ă�����f�[�^�������E�\������
        If chkCondition() = True Then
            '// V2.00�� ADD
            intInputMode = 2
            '// V2.00�� ADD
            showBody() '���ް��\��
            '2007/11/26 FKS)minamoto ADD START
            '�ԕi���������A���b�N
            lockHenpin()
            '2007/11/26 FKS)minamoto ADD END
        End If
        '// V2.00�� ADD
    End Sub

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    �A���[��CF10042801
    Private Sub cmd_csvout_Click()
        Dim bolRet As Boolean
        Dim intRet As Short
        Dim strSavePath As String

        On Error GoTo Exit_Handler

        '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
        If blnUsableButton = False Then Exit Sub

        '���o�^�m�F��MSG
        If showMsg("1", "URKET53_045", "0") = MsgBoxResult.Yes Then
            '�������̔��f
            If gs_FILEAUTH = "9" And AUTHORITY_ENABLE = True Then
                Call showMsg("2", "FILEAUTH", "0")
                GoTo Exit_Handler
            End If

            '�v�����v�g�\���̈�Ƀ��b�Z�[�W�o��
            img_light.Image = img_bklight(1).Image
            txt_message.Text = "��ƒ��I ���΂炭���҂����������B"

            'INI�t�@�C���Ǎ�����
            bolRet = funcGetIni()
            If Not bolRet Then
                Call showMsg("2", "URKET53_046", "0") '��INI�t�@�C���Ǎ��G���[���������܂����B
                GoTo Exit_Handler
            End If

            '�ۑ��_�C�A���O���J��
            strSavePath = gv_strOUT_NAME
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Me.CommonDialog1.FileName = strSavePath '�t�@�C�������f�t�H���g�Z�b�g
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.DefaultExt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Me.CommonDialog1.DefaultExt = gv_strOUT_TYPE '�t�@�C���g���q�̊���l
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.Filter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Me.CommonDialog1.Filter = "*" & gv_strOUT_TYPE & "|*" & gv_strOUT_TYPE
            '�t�@�C���̎�ނ̃t�B���^
            'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.CancelError �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/18 DEL START
            'Me.CommonDialog1.CancelError = True '�L�����Z���{�^���������G���[����
            '2019/04/18 DEL E N D
            Do
                'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.ShowSave �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/40/18 CHG START
                'Me.CommonDialog1.ShowSave() '�_�C�A���O���J��
                Me.CommonDialog1.ShowDialog()
                '2019/4/18 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CommonDialog1.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSavePath = Me.CommonDialog1.FileName '�I�����ꂽ�t�@�C������ϐ��Ɋi�[

                '�_�C�A���O��ʂŃp�X���擾�ł��Ȃ������Ƃ�(�L�����Z����)�͏����I��
                If strSavePath = "" Then
                    GoTo Exit_Handler
                End If

                '�I�����ꂽ�t�@�C���������݂���ꍇ
                'UPGRADE_WARNING: Dir �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                If Dir(strSavePath) <> "" Then
                    intRet = MsgBox(strSavePath & " �͊��ɑ��݂��܂��B" & vbCrLf & "�㏑�����܂���?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, SSS_PrgNm)
                    If intRet = MsgBoxResult.Yes Then
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Loop

            'CSV�o�͏���
            bolRet = funcOutPutCSV(strSavePath)
            If Not bolRet Then
                Call showMsg("2", "URKET53_047", "0") '���b�r�u�o�͏����ŃG���[���������܂����B
                GoTo Exit_Handler
            Else
                Call showMsg("1", "URKET53_048", "0") '���������I�����܂����B
            End If
        End If

Exit_Handler:

        '�q���g�̕\��������������
        img_light.Image = img_bklight(0).Image
        txt_message.Text = ""

    End Sub
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    '���������ݸد���
    Private Sub cmd_kesidt_Click()
        If txt_kesidt.Enabled = False Then Exit Sub

        If Trim(txt_kesidt.Text) <> "" Then
            Set_date.Value = txt_kesidt.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        '�J�����_�[�E�B���h�E��\��
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kesidt.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kesidt.Text = WLSDATE_RTNCODE
            intChkKb = 1 '�����t�̓��̓`�F�b�N
            txt_tokseicd.Focus()
        End If
    End Sub

    '�����溰�����ݸد���
    Private Sub cmd_tokseicd_Click()
        If txt_tokseicd.Enabled = False Then Exit Sub
        '2019/04/18 CHG START
        'WLS_TOK1.ShowDialog()
        'WLS_TOK1.Close()
        WLSTOK1.ShowDialog()
        WLSTOK1.Close()
        '2019/04/18 CHG E N D

        txt_tokseicd.Focus()
        '2019/04/24 CHG START
        'If WLSTOKSUB_RTNCODE <> "" Then
        '    txt_tokseicd.Text = WLSTOKSUB_RTNCODE
        If WLSTOK_RTNCODE <> "" Then
            txt_tokseicd.Text = WLSTOK_RTNCODE
            '// V2.00�� UPD
            ''        txt_kaidt.SetFocus
            intChkKb = 1
            chkTokseicd()
            txt_kaidt_From.Focus()
            '// V2.00�� UPD
        End If
    End Sub

    '��������ݸد���
    Private Sub cmd_kaidt_From_Click()
        '// V2.00�� UPD
        ''    If txt_kaidt.Enabled = False Then Exit Sub
        ''
        ''    If Trim(txt_kaidt.Text) <> "" Then
        ''        Set_date = txt_kaidt.Text
        ''    Else
        ''        Set_date = CNV_DATE(gstrUnydt)
        ''    End If
        ''
        ''    WLSDATE_RTNCODE = ""
        ''
        ''    '�J�����_�[�E�B���h�E��\��
        ''    WLS_DATE.Show vbModal
        ''    Unload WLS_DATE
        ''
        ''    txt_kaidt.SetFocus
        ''    If WLSDATE_RTNCODE <> "" Then
        ''        txt_kaidt.Text = WLSDATE_RTNCODE
        ''        intChkKb = 1                   '�����t�̓��̓`�F�b�N
        ''        txt_kesikb.SetFocus
        ''    End If
        If txt_kaidt_From.Enabled = False Then Exit Sub

        If Trim(txt_kaidt_From.Text) <> "" Then
            Set_date.Value = txt_kaidt_From.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        '�J�����_�[�E�B���h�E��\��
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kaidt_From.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kaidt_From.Text = WLSDATE_RTNCODE
            intChkKb = 1 '�����t�̓��̓`�F�b�N
            txt_kaidt_To.Focus()
        End If
        '// V2.00�� UPD
    End Sub

    '// V2.00�� ADD
    '��������ݸد���
    Private Sub cmd_kaidt_To_Click()
        If txt_kaidt_To.Enabled = False Then Exit Sub

        If Trim(txt_kaidt_To.Text) <> "" Then
            Set_date.Value = txt_kaidt_To.Text
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        '�J�����_�[�E�B���h�E��\��
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_kaidt_To.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_kaidt_To.Text = WLSDATE_RTNCODE
            intChkKb = 1 '�����t�̓��̓`�F�b�N
            txt_kesikb.Focus()
        End If
    End Sub
    '// V2.00�� ADD

    '�U���������ݸد���
    Private Sub cmd_fridt_Click()
        '�U�����������͂ł��Ȃ����Ͳ���Ă͎��s���Ȃ�
        If blnFriEnabled = False Then Exit Sub
        If txt_fridt.Enabled = False Then Exit Sub

        If Trim(txt_fridt.Text) <> "" Then
            If IsDate(txt_fridt.Text) = True Then
                Set_date.Value = txt_fridt.Text
            Else
                Set_date.Value = CNV_DATE(gstrUnydt.Value)
                txt_fridt.Text = ""
            End If
        Else
            Set_date.Value = CNV_DATE(gstrUnydt.Value)
        End If

        WLSDATE_RTNCODE = ""

        '�J�����_�[�E�B���h�E��\��
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()

        txt_fridt.Focus()
        If WLSDATE_RTNCODE <> "" Then
            txt_fridt.Text = WLSDATE_RTNCODE
            intChkKb = 1 '�����t�̓��̓`�F�b�N
            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/22 CHG START
            'spd_body.SetFocus()
            spd_body.Focus()
            '2019/04/22 CHG E N D
        End If
    End Sub

    '2007/11/26 FKS)minamoto ADD START
    '�ԕi����
    Private Sub lockHenpin()
        Dim intKesizan As Decimal '�w�b�_�������c�z
        Dim intKomikn As Decimal '�ō�����z
        Dim intKesikn As Decimal '�����z
        Dim intBfKesikn As Decimal '�����z(�����O)
        Dim tmp As Object
        Dim LS_HYFRIDT As Object
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer
        Dim strFRIDT As String
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short

        On Error Resume Next
        '�U���������擾

        strFRIDT = txt_fridt.Text
        '�����c�z���擾

        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        intKesizan = SSSVal((txt_kesizan.Text))
        '�ԕi������

        With spd_body

            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D
                '�ō�����z���擾

                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KOMIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KOMIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKomikn = SSSVal(tmp)
                '�����ϊz���擾

                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intKesikn = SSSVal(tmp)
                '�����ȑO�����z

                '// V2.03�� UPD
                ''''            Call .GetText(COL_BFKESIKN, idxRow, tmp)
                ''''            intBfKesikn = SSSVal(tmp)
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                intBfKesikn = SSSVal(tmp)
                '// V2.03�� UPD

                '�����z���}�C�i�X�ł���Γ���󒍔ԍ��ő��E
                If intKomikn - intKesikn < 0 Then

                    '�����z�������c�z�֒ǉ�
                    intKesizan = intKesizan - (intKomikn - intKesikn)

                    '�����ϊz�ݒ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    '.SetText(COL_KESIKN, idxRow, intKomikn)
                    .SetValue(idxRow, COL_KESIKN, intKomikn)
                    '2019/04/22 CHG E N D

                    '�`�F�b�N�{�b�N�X�ݒ�
                    blnUsableSpread = False
                    '2019/04/22 CHG START
                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Row = idxRow
                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Col = COL_CHK
                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '.Value = 1
                    .SetValue(idxRow, COL_CHK, True)
                    '2019/04/22 CHG E N D
                    blnUsableSpread = True

                    '// V2.03�� ADD
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .SetText(COL_HENPI, idxRow, "1")
                    .SetValue(idxRow, COL_HENPI, "1")
                    '2019/04/22 CHG E N D
                    '// V2.03�� ADD

                    '�󒍔ԍ��擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYJDNNO)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strHYJDNNO = CStr(tmp)

                    '����󒍔ԍ�������
                    For idxRowJDNNO = intMaxRow To 1 Step -1
                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/22 CHG START
                        '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                        tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                        '2019/04/22 CHG E N D
                        'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        str_theHYJDNNO = CStr(tmp)

                        '�󒍔ԍ���v����Α��E
                        If strHYJDNNO <> str_theHYJDNNO Then
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/22 CHG START
                            '.GetText(COL_CHK, idxRowJDNNO, tmp)
                            tmp = .GetValue(idxRowJDNNO, COL_CHK)
                            '2019/04/22 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/25 CHG START
                            'intchk = SSSVal(tmp)
                            intchk = SSSVal(IIf(tmp = True, 1, 0))
                            '2019/04/25 CHG E N D

                            '�������g�łȂ��A�܂��̓`�F�b�N����Ă��Ȃ�
                            If idxRowJDNNO <> idxRow And intchk = 1 Then
                            Else

                                '�ō�����z���擾
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KOMIKN)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                intKomikn = SSSVal(tmp)

                                '�����ϊz���擾
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KESIKN)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                intKesikn = SSSVal(tmp)

                                '�����ȑO�����z
                                '// V2.03�� UPD
                                '2009/09/15 UPD START RISE)MIYAJIMA
                                '                            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                'Call .GetText(COL_KESIKN_MAE, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_KESIKN_MAE)
                                '2019/04/22 CHG E N D
                                '2009/09/15 UPD E.N.D RISE)MIYAJIMA
                                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                intBfKesikn = SSSVal(tmp)
                                ''''                            Call .GetText(COL_BFKESIKN, idxRowJDNNO, tmp)
                                ''''                            intBfKesikn = SSSVal(tmp)
                                '// V2.03�� UPD

                                '�ō�������z�S�z���E
                                If intKesizan >= intKomikn - intKesikn Then

                                    '�����ϊz�ݒ�
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    '.SetText(COL_KESIKN, idxRowJDNNO, intKomikn)
                                    .SetValue(idxRowJDNNO, COL_KESIKN, intKomikn)
                                    '2019/04/22 CHG E N D

                                    '�`�F�b�N�{�b�N�X�ݒ�
                                    blnUsableSpread = False
                                    '2019/04/22 CHG START
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '.Row = idxRowJDNNO
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '.Col = COL_CHK
                                    ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '.Value = 1
                                    .SetValue(idxRowJDNNO, COL_CHK, True)
                                    '2019/04/22 CHG E N D
                                    blnUsableSpread = True

                                    '// V2.03�� ADD
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    'Call .SetText(COL_HENPI, idxRowJDNNO, "1")
                                    .SetValue(idxRowJDNNO, COL_HENPI, "1")
                                    '2019/04/22 CHG E N D
                                    '// V2.03�� ADD

                                    '�����c�z�ݒ�
                                    intKesizan = intKesizan - (intKomikn - intKesikn)

                                    '�U�������ݒ�
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    '                                If DB_TOKMTA2.SHAKB Like "[256]" Then
                                    'M                                If Trim(txt_fridt.Text) <> "" Then
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    '.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
                                    LS_HYFRIDT = .GetValue(idxRowJDNNO, COL_HYFRIDT)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    If Trim(LS_HYFRIDT) = "" Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/22 CHG START
                                        '.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
                                        .SetValue(idxRowJDNNO, COL_HYFRIDT, strFRIDT)
                                        '2019/04/22 CHG E N D
                                    End If
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    'M                               End If
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    '�ō�������z�ꕔ���E
                                    '�����ϊz�ݒ�

                                Else

                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    '.SetText(COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan)
                                    .SetValue(idxRowJDNNO, COL_KESIKN, intKesikn + intKesizan)
                                    '2019/04/22 CHG E N D
                                    '�`�F�b�N�{�b�N�X�ݒ�

                                    '2008/08/13 ADD START FKS)NAKATA
                                    ''�����c�z���[���̏ꍇ�A�`�F�b�N�����Ȃ�
                                    If intKesizan > 0 Then
                                        '2008/08/13 ADD E.N.D FKS)NAKATA

                                        blnUsableSpread = False
                                        '2019/04/22 CHG START
                                        ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '.Row = idxRowJDNNO
                                        ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '.Col = COL_CHK
                                        ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '.Value = 1
                                        .SetValue(idxRowJDNNO, COL_CHK, True)
                                        '2019/04/22 CHG E N D
                                        blnUsableSpread = True

                                        '// V2.03�� ADD
                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/22 CHG START
                                        'Call .SetText(COL_HENPI, idxRowJDNNO, "1")
                                        .SetValue(idxRowJDNNO, COL_HENPI, "1")
                                        '2019/04/22 CHG E N D
                                        '// V2.03�� ADD

                                        '2008/08/13 ADD START FKS)NAKATA
                                    End If
                                    '2008/08/13 ADD E.N.D FKS)NAKATA


                                    '�����c�z�[��
                                    intKesizan = 0

                                    '�U�������ݒ�
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    '                                If DB_TOKMTA2.SHAKB Like "[256]" Then
                                    'M                                If Trim(txt_fridt.Text) <> "" Then
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    '.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
                                    LS_HYFRIDT = .GetValue(idxRowJDNNO, COL_HYFRIDT)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: �I�u�W�F�N�g LS_HYFRIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    If Trim(LS_HYFRIDT) = "" Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/22 CHG START
                                        '.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
                                        .SetValue(idxRowJDNNO, COL_HYFRIDT, strFRIDT)
                                        '2019/04/22 CHG E N D
                                        '�����c�z��ݒ�

                                    End If
                                    '2009/10/01 UPD START RISE)MIYAJIMA
                                    'M                                End If
                                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                                End If
                            End If
                        End If
                    Next idxRowJDNNO
                End If
            Next idxRow
        End With

        txt_kesizan.Text = VB6.Format(intKesizan, "###,###,##0")

    End Sub
    '2007/11/26 FKS)minamoto ADD END

    '2008/07/30 DEL START FKS)NAKATA
    '''2007/12/10 FKS)minamoto ADD START
    ''Function CHK_HAITA_UPD()
    ''    Dim idxRow    As Integer
    ''    Dim strSql  As String
    ''    Dim Usr_Ody As U_Ody
    ''
    ''    CHK_HAITA_UPD = 1
    ''    '�󒍓`�[
    ''
    ''    For idxRow = 1 To intMaxRow
    ''
    ''        '����g����
    ''
    ''        strSql = ""
    ''        strSql = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM UDNTRA"
    ''        strSql = strSql + " WHERE DATNO = '" + HAITA_UDNTRA(idxRow).DATNO + "'"
    ''        strSql = strSql + "  AND LINNO = '" + HAITA_UDNTRA(idxRow).LINNO + "'"
    ''        'DB�A�N�Z�X
    ''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''
    ''        If CF_Ora_EOF(Usr_Ody) = True Then
    ''            '�G���[
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Call CF_Ora_CloseDyn(Usr_Ody)
    ''            Exit Function
    ''        End If
    ''        If Val(HAITA_UDNTRA(idxRow).WRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).WRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).UWRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))) Or _
    '''            Val(HAITA_UDNTRA(idxRow).UWRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))) Then
    ''            '�G���[
    ''            CHK_HAITA_UPD = 0
    ''            Call CF_Ora_CloseDyn(Usr_Ody)
    ''            Exit Function
    ''        End If
    ''        Call CF_Ora_CloseDyn(Usr_Ody)
    ''
    ''        '�󒍃g����
    ''
    ''        strSql = ""
    ''        strSql = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM JDNTRA"
    ''        strSql = strSql + " WHERE DATNO = '" + HAITA_JDNTRA(idxRow).DATNO + "'"
    ''        strSql = strSql + "  AND LINNO = '" + HAITA_JDNTRA(idxRow).LINNO + "'"
    ''        'DB�A�N�Z�X
    ''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''        If CF_Ora_EOF(Usr_Ody) = True Then
    ''            '�G���[
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Exit Function
    ''        End If
    ''        If Val(HAITA_JDNTRA(idxRow).WRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).WRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).UWRTDT) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))) Or _
    '''            Val(HAITA_JDNTRA(idxRow).UWRTTM) <> Val(CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))) Then
    ''            '�G���[
    ''
    ''            CHK_HAITA_UPD = 0
    ''            Exit Function
    ''        End If
    ''        Call CF_Ora_CloseDyn(Usr_Ody)
    ''
    ''    Next idxRow
    ''
    ''End Function
    '''2007/12/10 FKS)minamoto ADD END
    '2008/07/30 DEL START FKS)NAKATA



    '2008/1/10 FKS)ichihara ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function getKuroTbl
    '   �T�v�F ������ȍ~�̖��������݂̍��f�[�^���擾
    '   �����F strJdnNo   : �ԕi�f�[�^�̎󒍓`�[�ԍ�
    '   �@�@�F strJdnlinNo: �ԕi�f�[�^�̎󒍓`�[�s�ԍ�
    '   �@�@�F strRecNo   : �ԕi�f�[�^�̃��R�[�h�Ǘ��ԍ�
    '   �@�@�F strAKesiKb : �ԕi�f�[�^�̏����敪
    '   �@�@�F strHenryu  : �ԕi�f�[�^�̕ԕi���R
    '   �@�@�F strHenj    : �ԕi�f�[�^�̕ԕi���
    '   �@�@�F strUriDate :�ԕi�f�[�^�̔���`�[���t
    '   �ߒl�F �`�F�b�N����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function getKuroTbl(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, ByVal strAKesiKb As String, ByVal strHenryu As String, ByVal strHenj As String, ByVal strUriDate As String) As Boolean

        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_getKuroTbl

        getKuroTbl = False

        strSql = " SELECT JDNNO,KESIKB,UDNDT"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
        strSql = strSql & " AND     RECNO    =  '" & strRECNO & "'"
        strSql = strSql & " AND     UDNDT    <= '" & strUriDate & "'" '�`�ԕi�������܂�
        strSql = strSql & " AND     HENRSNCD =  '" & strHenryu & "'" '�ԕi���R
        strSql = strSql & " AND     HENSTTCD =  '" & strHenj & "'" '�ԕi���
        strSql = strSql & " AND     AKAKROKB =  '1'" '��
        strSql = strSql & " ORDER BY UDNDT "

        '2019/04/18 CHG START
        ''DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''�f�[�^�����݂����ꍇ
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    If gstrKaidt_To.Value < CF_Ora_GetDyn(Usr_Ody, "UDNDT", "") Then
        '        '��ʂɕ\������Ȃ����f�[�^�̏ꍇ

        '        '�ԁi�ԕi�j�����i����j���������݂���Ă��Ȃ��ꍇ
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, KESIKB, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If (strAKesiKb <> "1" And CF_Ora_GetDyn(Usr_Ody, "KESIKB", "") <> "1") Then
        '            '�Ԃ�\�����Ȃ�
        '            getKuroTbl = False
        '            GoTo END_getKuroTbl
        '        End If

        '        '�ԁi�ԕi�j�����i����j���������݂���Ă���ꍇ
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, KESIKB, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If (strAKesiKb = "1" And CF_Ora_GetDyn(Usr_Ody, "KESIKB", "") = "1") Then
        '            '�Ԃ�\�����Ȃ�
        '            getKuroTbl = False
        '            GoTo END_getKuroTbl
        '        End If
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Usr_Ody.Obj_Ody.MoveNext()
        'Loop
        'DB�A�N�Z�X
        Dim dt As DataTable = DB_GetTable(strSql)

        '�f�[�^�����݂����ꍇ
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If gstrKaidt_To.Value < DB_NullReplace(dt.Rows(0)("UDNDT"), "") Then
                    '��ʂɕ\������Ȃ����f�[�^�̏ꍇ

                    '�ԁi�ԕi�j�����i����j���������݂���Ă��Ȃ��ꍇ
                    If (strAKesiKb <> "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") <> "1") Then

                        If (strAKesiKb <> "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") <> "1") Then
                            '�Ԃ�\�����Ȃ�
                            getKuroTbl = False
                            GoTo END_getKuroTbl
                        End If

                        '�ԁi�ԕi�j�����i����j���������݂���Ă���ꍇ
                        If (strAKesiKb = "1" And DB_NullReplace(dt.Rows(i)("KESIKB"), "") = "1") Then
                            '�Ԃ�\�����Ȃ�
                            getKuroTbl = False
                            GoTo END_getKuroTbl
                        End If

                    End If

                End If
            Next
        End If
        '2019/04/18 CHG E N D

        getKuroTbl = True

END_getKuroTbl:
        '�N���[�Y
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D

        Exit Function

ERR_getKuroTbl:
        GoTo END_getKuroTbl

    End Function
    '2008/1/10 FKS)ichihara ADD END

    '2008/07/25 FKS) NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function chk_HENPIN
    '   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
    '          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
    '   �����F strJdnNo   : �󒍓`�[�ԍ�
    '   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
    '   �@�@�F strRECNO   : ���R�[�h�Ǘ��ԍ�
    '       �F strWrtFstDt: �o�^��
    '       �F strWrtFstTm: �o�^����
    '       �F strUritk   : ����P��
    '       �F strUrikn   : ������z
    '   �@�@�F strTokseicd: ������R�[�h
    '   �ߒl�F �`�F�b�N����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    '''' UPD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    ''�p�����[�^��RECNO��ǉ�
    ''Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String) As Boolean
    'Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, _
    ''                                    ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String) As Boolean
    ''V3.00 2009/03/10 CHG START FKS)NAKATA
    '�p�����[�^��TOKSEICD��ǉ�
    Function chkHenpin(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strRECNO As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String, ByVal strTokseicd As String) As Boolean
        '''' UPD 2010/10/19  FKS) T.Yamamoto    End


        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: �\���� Usr_Ody2 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody2 As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkHENPIN

        chkHenpin = False

        strSql = " "
        strSql = " SELECT *"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & Trim(strJDNNO) & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & Trim(strJdnlinNo) & "'"
        strSql = strSql & " AND     DATKB =  '1'"
        strSql = strSql & " AND     AKAKROKB =  '9'"
        strSql = strSql & " AND     DKBID    =  '01'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
        strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    End

        '2019/04/18 CHG START
        'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''�f�[�^�����݂����ꍇ
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    '��������Ă��Ȃ��ꍇ�A�������s��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then

        '        '�ԕi���R�ɒl���i�[����Ă��锄���ΏۂƂ���
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, DKBID, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then

        '            '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
        '            'If (CLng(strUrikn) + CLng(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then
        '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            If CInt(strUrikn) = CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
        'DB�A�N�Z�X
        Dim dt As DataTable = DB_GetTable(strSql)

        '�f�[�^�����݂����ꍇ
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                '��������Ă��Ȃ��ꍇ�A�������s��
                If Trim(DB_NullReplace(dt.Rows(i)("KESIKB"), "")) <> "1" Then

                    '�ԕi���R�ɒl���i�[����Ă��锄���ΏۂƂ���
                    If Trim(DB_NullReplace(dt.Rows(i)("HENRSNCD"), "")) <> "" And DB_NullReplace(dt.Rows(i)("DKBID"), "") = "01" Then

                        '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
                        If CInt(strUrikn) = CInt(DB_NullReplace(dt.Rows(i)("URIKN"), "")) * (-1) Then
                            '2019/04/18 CHG E N D

                            chkHenpin = False
                            GoTo END_chkHENPIN
                        Else


                            'V3.00 2009/03/10 ADD START FKS)NAKATA
                            '
                            strSql = " "
                            strSql = " SELECT COUNT(*) AS CNT"
                            strSql = strSql & " FROM    UDNTRA"
                            strSql = strSql & " WHERE   JDNNO       =  '" & Trim(strJDNNO) & "'"
                            strSql = strSql & " AND     JDNLINNO    =  '" & Trim(strJdnlinNo) & "'"
                            strSql = strSql & " AND     DATKB       =  '1'"
                            strSql = strSql & " AND     AKAKROKB    =  '1'"
                            strSql = strSql & " AND     DKBID       =  '01'"
                            strSql = strSql & " AND     RECNO       =  '" & Trim(strRECNO) & "'"
                            strSql = strSql & " AND     URITK       !=   " & strUritk & " "
                            strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  >  '" & strWrtFstDt & strWrtFstTm & "'"
                            '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
                            strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
                            '''' ADD 2010/10/19  FKS) T.Yamamoto    End

                            '2019/04/18 CHG START
                            ''DB�A�N�Z�X
                            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)

                            ''�f�[�^�����݂����ꍇ
                            'Do While CF_Ora_EOF(Usr_Ody2) = False

                            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '    If CInt(CF_Ora_GetDyn(Usr_Ody2, "CNT", 0)) >= 1 Then
                            '        chkHenpin = False
                            '        Call CF_Ora_CloseDyn(Usr_Ody2)
                            '        GoTo END_chkHENPIN
                            '    Else
                            '        chkHenpin = True
                            '        Call CF_Ora_CloseDyn(Usr_Ody2)
                            '        GoTo END_chkHENPIN
                            '    End If
                            '    'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody2.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '    Usr_Ody2.Obj_Ody.MoveNext()
                            'Loop
                            'DB�A�N�Z�X
                            Dim dt2 As DataTable = DB_GetTable(strSql)

                            '�f�[�^�����݂����ꍇ
                            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                                For j As Integer = 0 To dt2.Rows.Count - 1
                                    If CInt(DB_NullReplace(dt.Rows(j)("CNT"), 0)) >= 1 Then
                                        chkHenpin = False
                                        GoTo END_chkHENPIN
                                    Else
                                        chkHenpin = True
                                        GoTo END_chkHENPIN
                                    End If
                                Next
                            End If
                            'V3.00 2009/03/10 ADD E.N.D FKS)NAKATA
                        End If
                    End If

                End If

                '2019/04/18 CHG START
                '        'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '        Usr_Ody.Obj_Ody.MoveNext()
                'Loop
            Next
        End If
        '2019/04/18 CHG E N D

        chkHenpin = True

END_chkHENPIN:
        '�N���[�Y
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_chkHENPIN:
        GoTo END_chkHENPIN

    End Function

    '2008/07/26 FKS) NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function chkHenpinTeisei
    '   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
    '          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
    '   �����F strJdnNo   : �󒍓`�[�ԍ�
    '   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
    '   �@�@�F strUrikn   : ������z
    '   �@�@�F strUdnno   : ����`�[�ԍ�
    '   �@�@�F strLinno   : �s�ԍ�
    '   �@�@�F strUriDt   : �����
    '   �@�@�F strTokseicd: ������R�[�h
    '   �ߒl�F �`�F�b�N����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    �A���[��830
    ''''' UPD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
    ''Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, _
    '''                                ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String) As Boolean
    ''�p�����[�^��TOKSEICD��ǉ�
    'Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, _
    ''                            ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, _
    ''                            ByVal strTokseicd As String) As Boolean
    ''''' UPD 2010/10/19  FKS) T.Yamamoto    End
    '�p�����[�^��DATNO��ǉ�
    Function chkHenpinTeisei(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUrikn As String, ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, ByVal strTokseicd As String, ByVal strDATNO As String) As Boolean
        '''' UPD 2011/06/13  FKS) T.Yamamoto    End

        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkHenpinTeisei

        chkHenpinTeisei = False

        strSql = " "
        strSql = " SELECT *"
        strSql = strSql & " FROM    UDNTRA"
        strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
        strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
        strSql = strSql & " AND     DATKB =  '1'"
        strSql = strSql & " AND     AKAKROKB =  '9'"
        '2008/08/30 ADD START FKS)NAKATA
        ''�S���ԕi�㔄��Ή�
        strSql = strSql & " AND     DKBID =  '01'"
        '2008/08/30 ADD E.N.D FKS)NAKATA
        strSql = strSql & " AND     UDNNO  <>  '" & strUDNNO & "'"
        strSql = strSql & " AND     LINNO  =  '" & strLINNO & "'"
        '''' UPD 2011/06/13  FKS) T.Yamamoto    Start    �A���[��830
        '�����O�̃f�[�^��\�����Ȃ�
        '    strSql = strSql & " AND     UDNDT <>  '" & strURIDT & "'"
        strSql = strSql & " AND     MOTDATNO =  '" & Trim(strDATNO) & "'"
        '''' UPD 2011/06/13  FKS) T.Yamamoto    End
        '''' ADD 2010/10/19  FKS) T.Yamamoto    Start    �A���[��FC10100601
        strSql = strSql & " AND     TOKSEICD =  '" & Trim(strTokseicd) & "'"
        '''' ADD 2010/10/19  FKS) T.Yamamoto    End


        'DB�A�N�Z�X
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''�f�[�^�����݂����ꍇ
        'Do While CF_Ora_EOF(Usr_Ody) = False

        '    '��������Ă��Ȃ��ꍇ�A�������s��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then

        '        '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If (CInt(strUrikn) + CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                '��������Ă��Ȃ��ꍇ�A�������s��
                If Trim(DB_NullReplace(dt.Rows(i)("KESIKB"), "")) <> "1" Then

                    '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
                    If (CInt(strUrikn) + CInt(DB_NullReplace(dt.Rows(i)("URIKN"), ""))) = 0 Then
                        '2019/04/18 CHG E N D

                        chkHenpinTeisei = False
                        GoTo END_chkHenpinTeisei
                    Else
                        chkHenpinTeisei = True
                        GoTo END_chkHenpinTeisei
                    End If

                End If

                '2019/04/18 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Usr_Ody.Obj_Ody.MoveNext()
                'Loop
            Next
        End If
        '2019/04/18 CHG E N D

        chkHenpinTeisei = True

END_chkHenpinTeisei:
        '�N���[�Y
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_chkHenpinTeisei:
        GoTo END_chkHenpinTeisei

    End Function
    '2008/07/26 ADD E.N.D FKS)NAKATA

    '2008/07/30 ADD START FKS)NAKATA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Sub chkAkaKro
    '   �T�v�F �ꕔ�ԕi�����݂��锄�����������ہA�Ԃƍ�������o��
    '�@�@�@�@  �Ԃ̂ݏ��������ꍇ�́A�G���[���b�Z�[�W���o���B
    '          ���̂ݏ��������ꍇ�́A�Ԃ̑��݂����邱�Ƃ����b�Z�[�W����B
    '
    '   ���l�F 2008/08/13 ���[���ꂽ����ɑ΂��Ă̐ԍ��`�F�b�N�̒ǉ��E�C��
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkAkaKro() As Object

        Dim intKesizan As Decimal '�w�b�_�������c�z
        Dim intKomikn As Decimal '�ō�����z
        Dim intKesikn As Decimal '�����z
        Dim intBfKesikn As Decimal '�����z(�����O)
        Dim intAfKesikn As Decimal
        '2008/08/13 ADD START FKS)NAKATA
        Dim intUrikn As Decimal '������z
        Dim wkKesikn As Decimal '�ԍ��`�F�b�N�p���������[�N�ϐ�
        Dim sumKesikn As Decimal '�ԍ��`�F�b�N�p�������ϐ�
        Dim Cnt As Short '�ԍ��`�F�b�N�p�J�E���g�ϐ�
        Dim i As Short '�ԍ��`�F�b�N�p
        Dim wkRow As Integer '�ԍ��`�F�b�N�p�s�ԍ�
        '2008/08/13 ADD E.N.D FKS)NAKATA
        Dim tmp As Object
        Dim LS_HYFRIDT As Object
        Dim idxRow As Integer
        Dim idxRowJDNNO As Integer
        Dim strFRIDT As String
        Dim strHYJDNNO As String
        Dim str_theHYJDNNO As String
        Dim intchk As Short
        Dim strUDNDT As String
        '2009/09/15 ADD START RISE)MIYAJIMA
        Dim strSSADT As String
        Dim curKESIKN As Decimal
        Dim curKESIKN_MAE As Decimal
        Dim strJDNNO As String
        '2009/09/15 ADD E.N.D RISE)MIYAJIMA


        'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        chkAkaKro = True

        '�ԕi������
        With spd_body
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG EN D
                '�`�F�b�N�������Ă��邩���m�F
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/22 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_CHK)
                '2019/04/22 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/25 CHG START
                'intchk = SSSVal(tmp)
                intchk = SSSVal(IIf(tmp = True, 1, 0))
                '2019/04/25 CHG E N D

                '�`�F�b�N�������Ă���ꍇ
                If intchk = 1 Then

                    '2008/08/13 ADD START FKS)NAKATA
                    ''�ԍ��`�F�b�N�z��̏�����
                    ReDim Preserve AKAKRO_CHK(0)
                    Cnt = 1
                    '2008/08/13 ADD E.N.D FKS)NAKATA


                    '2008/08/05 ADD START FKS)NAKATA
                    ''��ʓ��͒l�̏������ȍ~�̓��t����Ă���ꍇ�G���[�Ƃ���B
                    '������̎擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .GetText(COL_UDNDT, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_UDNDT)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strUDNDT = CStr(tmp)

                    If strUDNDT > DeCNV_DATE(Trim(txt_kesidt.Text)) Then
                        MsgBox("���͂��ꂽ�������ȍ~�̔��オ���݂��܂��B")
                        'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        chkAkaKro = False
                        Exit Function
                    End If
                    '2008/08/05 ADD E.N.D FKS)NAKATA

                    '2009/09/27 DEL START RISE)MIYAJIMA
                    ''2009/09/15 ADD START RISE)MIYAJIMA
                    '                '���������̎擾
                    '                Call .GetText(COL_SSADT, idxRow, tmp)
                    '                strSSADT = CStr(tmp)
                    '                '�������z�̎擾
                    '                Call .GetText(COL_KESIKN, idxRow, tmp)
                    '                curKESIKN = SSSVal(tmp)
                    '                '�������z�̎擾�i�O�j
                    '                Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                    '                curKESIKN_MAE = SSSVal(tmp)
                    '                '�󒍔ԍ��̎擾
                    '                Call .GetText(COL_JDNNO, idxRow, tmp)
                    '                strJDNNO = CStr(tmp)
                    '                If curKESIKN <> 0 And curKESIKN <> curKESIKN_MAE And strSSADT > DB_TOKMTA2.TOKSMEDT Then
                    '                    MsgBox ("�������z���ύX����Ă��܂��B�X�V�ł��܂���B" & vbCrLf & vbCrLf _
                    ''                                & "�sNo:" & vbTab & idxRow & vbCrLf _
                    ''                                & "�����: " & vbTab & strUDNDT & vbCrLf _
                    ''                                & "�󒍔ԍ�: " & vbTab & strJDNNO)
                    '                    chkAkaKro = False
                    '                    Exit Function
                    '                End If
                    ''2009/09/15 ADD E.N.D RISE)MIYAJIMA
                    '2009/09/27 DEL E.N.D RISE)MIYAJIMA

                    '�����ϊz(�����O)
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .GetText(COL_BFKESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_BFKESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    intBfKesikn = SSSVal(tmp)

                    '�����ϊz(������)
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .GetText(COL_AFKESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_AFKESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    intAfKesikn = SSSVal(tmp)


                    '�����ϊz���擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/22 CHG START
                    'Call .GetText(COL_KESIKN, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_KESIKN)
                    '2019/04/22 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    intKesikn = SSSVal(tmp)

                    '�ȑO�ɏ�������Ă�����̈ȊO
                    If intBfKesikn + intAfKesikn = 0 Then

                        '�����z���}�C�i�X�ł���Γ���󒍔ԍ��̍�������
                        If intKesikn < 0 Then

                            '�󒍔ԍ��擾
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/23 CHG START
                            'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_HYJDNNO)
                            '2019/04/23 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            strHYJDNNO = CStr(tmp)

                            '2008/08/13 ADD START FKS)NAKATA
                            ''�Ԃ̃f�[�^��z��Ɋi�[
                            AKAKRO_CHK(0).idx = idxRow
                            AKAKRO_CHK(0).CHKMK = intchk
                            AKAKRO_CHK(0).UDNDT = strUDNDT
                            AKAKRO_CHK(0).JDNNO = strHYJDNNO
                            AKAKRO_CHK(0).kesikn = intKesikn
                            '2008/08/13 ADD E.N.D FKS)NAKATA

                            '����󒍔ԍ�������
                            For idxRowJDNNO = intMaxRow To 1 Step -1
                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/22 CHG START
                                '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                                '2019/04/22 CHG E N D
                                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                str_theHYJDNNO = CStr(tmp)

                                '�󒍔ԍ���v����Α��E
                                If strHYJDNNO <> str_theHYJDNNO Then
                                Else
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/22 CHG START
                                    '.GetText(COL_CHK, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_CHK)
                                    '2019/04/22 CHG E N D
                                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/25 CHG START
                                    'intchk = SSSVal(tmp)
                                    intchk = SSSVal(IIf(tmp = True, 1, 0))
                                    '2019/04/25 CHG E N D

                                    '2008/08/13 ADD START FKS)NAKATA
                                    If idxRowJDNNO <> idxRow Then

                                        ''����󒍔ԍ��̍��̏������z���擾
                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/22 CHG START
                                        '.GetText(COL_KESIKN, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_KESIKN)
                                        '2019/04/22 CHG E N D
                                        'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        wkKesikn = SSSVal(tmp)


                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/22 CHG START
                                        '.GetText(COL_UDNDT, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_UDNDT)
                                        '2019/04/22 CHG E N D
                                        'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strUDNDT = CStr(tmp)

                                        ''����󒍔ԍ��̍���z��Ɋi�[
                                        ReDim Preserve AKAKRO_CHK(Cnt)

                                        AKAKRO_CHK(Cnt).idx = idxRowJDNNO
                                        AKAKRO_CHK(Cnt).CHKMK = intchk
                                        AKAKRO_CHK(Cnt).JDNNO = strHYJDNNO
                                        AKAKRO_CHK(Cnt).UDNDT = strUDNDT
                                        AKAKRO_CHK(Cnt).kesikn = wkKesikn

                                        Cnt = Cnt + 1
                                    End If
                                    '2008/08/13 ADD E.N.D FKS)NAKATA

                                    '2008/08/13 DEL START FKS)NAKATA
                                    ''                                '�������g�łȂ��A�܂��̓`�F�b�N����Ă��Ȃ�
                                    ''                                If idxRowJDNNO <> idxRow And intChk = 0 Then
                                    ''                                'If idxRowJDNNO <> idxRow And intChk = 0 And wkKesikn < 0 Then
                                    ''
                                    ''
                                    ''                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                    ''                                    strUDNDT = CStr(tmp)
                                    ''
                                    ''                                    MsgBox ("�������K�v�Ȕ��オ����܂��B" & vbCrLf & vbCrLf _
                                    '''                                                & "�sNo:" & vbTab & idxRowJDNNO & vbCrLf _
                                    '''                                                & "�����: " & vbTab & strUDNDT & vbCrLf _
                                    '''                                                & "�󒍔ԍ�: " & vbTab & strHYJDNNO)
                                    ''                                    chkAkaKro = False
                                    ''                                    Exit Function
                                    ''                                End If
                                    '2008/08/13 DEL E.N.D FKS)NAKATA

                                End If
                            Next idxRowJDNNO

                            '2008/08/13 ADD START FKS)NAKATA
                            ''�ԕi�̐ԍ��`�F�b�N

                            '�T�}���̏�����
                            sumKesikn = AKAKRO_CHK(0).kesikn

                            For i = 1 To Cnt - 1

                                '�`�F�b�N�������Ă��Ȃ��ꍇ
                                If AKAKRO_CHK(i).CHKMK = 0 Then

                                    wkRow = AKAKRO_CHK(i).idx
                                    strUDNDT = AKAKRO_CHK(i).UDNDT

                                    '�����Ă���ꍇ
                                Else
                                    '�Ԃ̃}�C�i�X�̏������ȏ�ɍ��̏���������Ă���
                                    If sumKesikn + AKAKRO_CHK(i).kesikn >= 0 Then
                                        sumKesikn = 0
                                        Exit For
                                    Else
                                        '
                                        wkRow = AKAKRO_CHK(i).idx
                                        sumKesikn = sumKesikn + AKAKRO_CHK(i).kesikn
                                    End If

                                End If
                            Next i

                            '�T�}�����}�C�i�X�ɂȂ��Ă���ꍇ�̓G���[���b�Z�[�W��\��
                            If Cnt - 1 >= 1 And sumKesikn < 0 Then
                                MsgBox("�������K�v�Ȕ��オ����܂��B" & vbCrLf & vbCrLf & "�sNo:" & vbTab & wkRow & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & strHYJDNNO)
                                'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                chkAkaKro = False
                                Exit Function
                            End If
                            '2008/08/13 ADD E.N.D FKS)NAKATA

                        Else
                            '���f�[�^����̌���

                            '�󒍔ԍ��擾
                            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/23 CHG START
                            'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_HYJDNNO)
                            '2019/04/23 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            strHYJDNNO = CStr(tmp)

                            '����󒍔ԍ�������
                            '2019/04/25 CHG START
                            'For idxRowJDNNO = intMaxRow To 1 Step -1
                            For idxRowJDNNO = intMaxRow - 1 To 0 Step -1
                                '2019/04/25 CHG E N D

                                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/04/23 CHG START
                                '.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
                                tmp = .GetValue(idxRowJDNNO, COL_HYJDNNO)
                                '2019/04/23 CHG E N D
                                'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                str_theHYJDNNO = CStr(tmp)

                                '�󒍔ԍ���v����Α��E
                                If strHYJDNNO <> str_theHYJDNNO Then
                                Else

                                    '�`�F�b�N
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/23 CHG START
                                    '.GetText(COL_CHK, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_CHK)
                                    '2019/04/23 CHG E N D
                                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/25 CHG START
                                    'intchk = SSSVal(tmp)
                                    intchk = SSSVal(IIf(tmp = True, 1, 0))
                                    '2019/04/25 CHG E N D

                                    '2008/08/13 ADD START FKS)NAKATA
                                    '������z
                                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/23 CHG START
                                    '.GetText(COL_URIKN, idxRowJDNNO, tmp)
                                    tmp = .GetValue(idxRowJDNNO, COL_URIKN)
                                    '2019/04/23 CHG E N D
                                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    intUrikn = SSSVal(tmp)
                                    '2008/08/13 ADD START FKS)NAKATA


                                    '2008/08/13 CHG START FKS)NAKATA
                                    ''���[����Ă��鍕�f�[�^�����o���Ȃ��悤�C��

                                    ''�������g�łȂ��A�܂��̓`�F�b�N����Ă��Ȃ�
                                    ''If idxRowJDNNO <> idxRow And intChk = 0 Then

                                    '�������g�łȂ��A���`�F�b�N����Ă��Ȃ��A�����f�[�^�łȂ�
                                    If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
                                        '2008/08/13 CHG START FKS)NAKATA

                                        'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/23 CHG START
                                        '.GetText(COL_UDNDT, idxRowJDNNO, tmp)
                                        tmp = .GetValue(idxRowJDNNO, COL_UDNDT)
                                        '2019/04/23 CHG E N D
                                        'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strUDNDT = CStr(tmp)

                                        If MsgBox("�������K�v�Ȕ��オ����܂��B" & vbCrLf & "�X�V���܂����H" & vbCrLf & vbCrLf & "�sNo:" & vbTab & idxRowJDNNO & vbCrLf & "�����: " & vbTab & strUDNDT & vbCrLf & "�󒍔ԍ�: " & vbTab & strHYJDNNO, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                                            'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                            chkAkaKro = True

                                        Else
                                            'UPGRADE_WARNING: �I�u�W�F�N�g chkAkaKro �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                            chkAkaKro = False
                                            Exit Function
                                        End If

                                    End If
                                End If
                            Next idxRowJDNNO

                        End If
                    End If
                End If
            Next idxRow
        End With

    End Function
    '2008/07/30 ADD E.N.D FKS)NAKATA

    '// V2.06�� DEL
    ''// V2.00�� ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Sub chkCondition
    '    '   �T�v�F  �w�b�_���̓��̓`�F�b�N
    '    '   �����F  ����
    '    '   �ߒl�F�@True:����  False:�ُ�
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkCondition() As Boolean
    '    chkCondition = False
    '
    '    intChkKb = 1
    '    If chkKesidt = True Then
    '        intChkKb = 1
    '        If chkTokseicd = True Then
    '            intChkKb = 1
    '            If chkKaidt_From = True Then
    '                intChkKb = 1
    '                If chkKaidt_To = True Then
    '                    '�U�����������͂ł��鎞�͕K�{�Ƃ���
    '                    If blnFriEnabled = True Then
    '                        '�����͎��̓G���[�Ƃ���
    '                        If Trim(txt_fridt.Text) = "" Then
    '                            Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
    '                            txt_fridt.ForeColor = vbRed
    '                            txt_fridt.SetFocus
    '                            Exit Function
    '                        End If
    '
    '                        intChkKb = 1
    '                        If chkFridt = True Then
    '                            chkCondition = True
    '                        End If
    '                    Else
    '                        chkCondition = True
    '                    End If
    '                End If
    '            End If
    '        '�����溰�ނ������͂̎��ʹװ�Ƃ���
    '        Else
    '            If Trim(txt_tokseicd.Text) = "" Then
    '                Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
    '                txt_tokseicd.ForeColor = vbRed
    '                txt_tokseicd.SetFocus
    '            End If
    '        End If
    '    End If
    'End Function
    ''// V2.00�� ADD
    '// V2.06�� DEL

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub ChkInputChange
    '   �T�v�F  ���ׂ̓��͓��e�̕ύX�m�F
    '   �����F  ����
    '   �ߒl�F�@True:�ύX�L��  False:�ύX����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function ChkInputChange() As Boolean

        Dim i As Short
        Dim vnt_AFCHK As Object
        Dim vnt_BFCHK As Object

        ChkInputChange = False

        With spd_body
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'For i = 1 To .MaxRows
            '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(COL_CHK, i, vnt_AFCHK)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(COL_BFCHECK, i, vnt_BFCHK)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(vnt_BFCHK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(vnt_AFCHK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
            '        ChkInputChange = True
            '        Exit For
            '    End If
            'Next i
            For i = 0 To .RowCount - 1
                vnt_AFCHK = IIf(.GetValue(i, COL_CHK), "1", "0")
                vnt_BFCHK = .GetValue(i, COL_BFCHECK)
                If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
                    ChkInputChange = True
                    Exit For
                End If
            Next
            '2019/04/23 CHG E N D
        End With

    End Function

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Get_NKSTRA_HAITA_INF
    '   �T�v�F  ���������g�����̔r�����擾
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Get_NKSTRA_HAITA_INF() As Boolean

        Dim strSql As Object
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: �\���� Usr_Ody_1 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_1 As U_Ody
        Dim i As Integer
        Dim Lng_Cnt As Integer
        '2019/04/18 ADD START
        Dim dt As DataTable
        '2019/04/18 CADD E N D
        Get_NKSTRA_HAITA_INF = False

        ReDim ARY_NKSTRA_HAITA(0)

        For i = 1 To UBound(ARY_UDNTRA_HAITA)
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = ""
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "SELECT " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "       KDNNO  " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,OPEID  " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,CLTID  " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,WRTDT  " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,WRTTM  " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,UOPEID " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,UCLTID " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,UWRTDT " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "      ,UWRTTM " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "FROM " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "       NKSTRA " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "WHERE " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "       UDNDATNO = '" & ARY_UDNTRA_HAITA(i).DATNO & "' " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "AND    UDNLINNO = '" & ARY_UDNTRA_HAITA(i).LINNO & "' " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSql = strSql & "AND    DATKB    = '1' " & vbCrLf

            'DB�A�N�Z�X
            'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            'Do While CF_Ora_EOF(Usr_Ody) = False
            dt = DB_GetTable(strSql)

            For cnt As Integer = 0 To dt.Rows.Count - 1
                '2019/04/18 CHG E N D

                '����f�[�^�����݂��邩�m�F���A���Ȃ��ꍇ�͎���������Ă��Ȃ��̂ŁA���������R�[�h���������{����
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = ""
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = strSql & "SELECT " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = strSql & "       KDNNO " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = strSql & "FROM " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = strSql & "       NKSTRA " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strSql = strSql & "WHERE " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/18 CHG START
                'strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf
                strSql = strSql & "       MOTKDNNO = '" & DB_NullReplace(dt.Rows(cnt)("KDNNO"), "") & "' " & vbCrLf
                '2019/04/18 CHG E N D

                'DB�A�N�Z�X
                'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/18 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)

                'If CF_Ora_EOF(Usr_Ody_1) Then

                Dim dt2 As DataTable = DB_GetTable(strSql)

                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    '2019/04/18 CHG E N D

                    Lng_Cnt = Lng_Cnt + 1
                    ReDim Preserve ARY_NKSTRA_HAITA(Lng_Cnt)
                    '2019/04/18 CHG START
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "KDNNO", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
                    ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
                    ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(DB_NullReplace(dt2.Rows(0)("KDNNO"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(DB_NullReplace(dt2.Rows(0)("OPEID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(DB_NullReplace(dt2.Rows(0)("CLTID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(DB_NullReplace(dt2.Rows(0)("WRTDT"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(DB_NullReplace(dt2.Rows(0)("WRTTM"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(DB_NullReplace(dt2.Rows(0)("UOPEID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(DB_NullReplace(dt2.Rows(0)("UCLTID"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(DB_NullReplace(dt2.Rows(0)("UWRTDT"), ""))

                    ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(DB_NullReplace(dt2.Rows(0)("UWRTTM"), ""))
                    '2019/04/18 CHG E N D
                End If
                '2019/04/18 CHG START
                '         Call CF_Ora_CloseDyn(Usr_Ody_1) '�ް���ĸ۰��
                '	'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	Usr_Ody.Obj_Ody.MoveNext()
                'Loop 
                'Call CF_Ora_CloseDyn(Usr_Ody) '�ް���ĸ۰��
            Next
            '2019/04/18 CHG E N D
        Next i

        Get_NKSTRA_HAITA_INF = True

    End Function
    '// V2.00�� ADD

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Get_NKSTRA_HAITA_INF
    '   �T�v�F  ���������g�����̊����U�����̎擾
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Get_NKSTRA_TEGDT(ByRef vnt_UDNDATNO As Object, ByRef vnt_UDNLINNO As Object) As String

        Dim strSql As String
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: �\���� Usr_Ody_1 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_1 As U_Ody
        Dim strTEGDT As String
        Dim blnExist As Boolean

        strTEGDT = ""

        blnExist = False

        '// V2.01�� UPD
        strSql = ""
        strSql = strSql & "SELECT " & vbCrLf
        strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
        strSql = strSql & "FROM " & vbCrLf
        strSql = strSql & "       NKSTRA " & vbCrLf
        strSql = strSql & "WHERE " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNDATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNLINNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
        strSql = strSql & "AND    KDNNO NOT IN ( " & vbCrLf
        strSql = strSql & "       SELECT " & vbCrLf
        strSql = strSql & "              MOTKDNNO " & vbCrLf
        strSql = strSql & "       FROM " & vbCrLf
        strSql = strSql & "              NKSTRA " & vbCrLf
        strSql = strSql & "       WHERE " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNDATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "              UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g vnt_UDNLINNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "       AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        strSql = strSql & "       AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
        strSql = strSql & "       ) " & vbCrLf

        'DB�A�N�Z�X
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If Not CF_Ora_EOF(Usr_Ody) Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strTEGDT = DB_NullReplace(dt.Rows(0)("TEGDT"), "")
        End If
        '2019/04/18 CHG E N D

        Get_NKSTRA_TEGDT = strTEGDT

        ''''    strSql = ""
        ''''    strSql = strSql & "SELECT " & vbCrLf
        ''''    strSql = strSql & "       kdnno " & vbCrLf
        ''''    strSql = strSql & "FROM " & vbCrLf
        ''''    strSql = strSql & "       NKSTRA " & vbCrLf
        ''''    strSql = strSql & "WHERE " & vbCrLf
        ''''    strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        ''''    strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        ''''    strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        ''''    strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
        ''''
        ''''    'DB�A�N�Z�X
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    Do While CF_Ora_EOF(Usr_Ody) = False
        ''''        '����f�[�^�����݂��邩�m�F���A���Ȃ��ꍇ�͎���������Ă��Ȃ�
        ''''        strSql = ""
        ''''        strSql = strSql & "SELECT " & vbCrLf
        ''''        strSql = strSql & "       * " & vbCrLf
        ''''        strSql = strSql & "FROM " & vbCrLf
        ''''        strSql = strSql & "       NKSTRA " & vbCrLf
        ''''        strSql = strSql & "WHERE " & vbCrLf
        ''''        strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
        ''''
        ''''        'DB�A�N�Z�X
        ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
        ''''
        ''''        If CF_Ora_EOF(Usr_Ody_1) = False Then
        ''''            Call CF_Ora_CloseDyn(Usr_Ody_1)   '�ް���ĸ۰��
        ''''            blnExist = True
        ''''            Exit Do
        ''''        End If
        ''''        Call CF_Ora_CloseDyn(Usr_Ody_1)   '�ް���ĸ۰��
        ''''        Usr_Ody.Obj_Ody.MoveNext
        ''''    Loop
        ''''
        ''''    Call CF_Ora_CloseDyn(Usr_Ody)     '�ް���ĸ۰��
        ''''
        ''''    If blnExist = False Then
        ''''        strSql = ""
        ''''        strSql = strSql & "SELECT " & vbCrLf
        ''''        strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
        ''''        strSql = strSql & "FROM " & vbCrLf
        ''''        strSql = strSql & "       NKSTRA " & vbCrLf
        ''''        strSql = strSql & "WHERE " & vbCrLf
        ''''        strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
        ''''        strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
        ''''        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
        ''''
        ''''        'DB�A�N�Z�X
        ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''        If Not CF_Ora_EOF(Usr_Ody) Then
        ''''            strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
        ''''        End If
        ''''    End If
        ''''
        ''''    Get_NKSTRA_TEGDT = strTEGDT
        '// V2.01�� UPD

    End Function
    '// V2.00�� ADD

    '// V2.06�� DEL
    ''// V2.00�� ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Sub chkKesidt
    '    '   �T�v�F  �������t�̃`�F�b�N
    '    '   �����F  ����
    '    '   �ߒl�F�@True:����  False:�ُ�
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''�������t�̃`�F�b�N
    'Private Function chkKesidt() As Boolean
    '
    '    chkKesidt = False
    '
    '    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    '
    '    If intChkKb = 1 Then
    '
    '        If txt_kesidt.Text <> CNV_DATE(gstrKesidt) Then
    '
    '            '���t�`���̃`�F�b�N
    '            If IsDate(txt_kesidt.Text) = False Then
    '                Call showMsg("2", "DATE", 0)            '�����t����MSG
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '�o�������ȑO�̓��t�̎��̓G���[
    '            If DeCNV_DATE(txt_kesidt.Text) <= DB_SYSTBA.SMAUPDDT Then
    '                Call showMsg("1", "URKET53_010", 0)     '���o�����ߍς݂�MSG
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '�^�p��������t�̎��̓G���[
    '            If DeCNV_DATE(txt_kesidt.Text) > gstrUnydt Then
    '                Call showMsg("2", "DATE_1", 3)          '���^�p������t�G���[
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kesidt.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)     '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
    '                txt_kesidt.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            txt_kesidt.ForeColor = vbBlack
    '            chkKesidt = True
    '        Else
    '            chkKesidt = True
    '        End If
    '    Else
    '        chkKesidt = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    '    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    '
    'End Function
    ''// V2.00�� ADD
    '// V2.06�� DEL

    '// V2.06�� DEL
    ''// V2.00�� ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Sub chkTokseicd
    '    '   �T�v�F  �����溰�ނ̃`�F�b�N
    '    '   �����F  ����
    '    '   �ߒl�F�@True:����  False:�ُ�
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkTokseicd() As Boolean
    '
    '    chkTokseicd = False
    '
    '    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    '    If intChkKb = 1 Then
    '
    '        If txt_tokseicd.Text <> gstrTokseicd Then
    '
    '            '�ύX����Ă����獀�ڃN���A
    '            If txt_tokseicd.Text <> gstrTokseicd Then
    '                txt_tokseinma.Text = ""
    '                txt_fridt.Text = "        " '8byte space
    '                txt_fridt.Enabled = False
    '
    '                lbl_shakbnm(1).Caption = ""
    '                lbl_hytokkesdd(1).Caption = ""
    '                gstrFridt = Space(8)        'add 2007/03/29 Saito
    '            End If
    '
    '            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
    '            If Trim(txt_tokseicd.Text) = "" Then
    '                chkTokseicd = True
    '                Exit Function
    '            End If
    '
    '            blnFriEnabled = False
    '
    '            '���Ӑ�Ͻ����琿���於�̂��擾
    '            Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), txt_tokseicd.Text)
    '                '����������̂Ƃ�
    '                Case 0:
    '                    txt_tokseicd.ForeColor = vbBlack
    ''// V2.05�� UPD
    ''                    txt_tokseinma.Text = DB_TOKMTA2.TOKNMA
    '                    txt_tokseinma.Text = DB_TOKMTA2.TOKRN
    ''// V2.05�� UPD
    '                    lbl_shakbnm(1).Caption = DB_TOKMTA2.SHAKBNM
    '                    lbl_hytokkesdd(1).Caption = DB_TOKMTA2.HYTOKKESDD
    '                    '�x�������������U���A̧���ݸނ̎��͐U���������ڂ���͉Ƃ���
    '                    '���x�������̒l�ɉ����āA�����U�����͉\�t���O�����Ă�
    ''CHG START FKS) INABA 2007/05/08 *******************************************
    ''�x�������Ɏ�`�������Ă���ꍇ�͖��ׂ̐U����������͂ł���悤�ɂ���
    '                    Select Case DB_TOKMTA2.SHAKB
    '                        Case "2", "3", "4", "5", "6"
    '                            blnFriEnabled = True
    '                    End Select
    ''CHG  END  FKS) INABA 2007/05/08 *******************************************
    '                    txt_fridt.Enabled = blnFriEnabled
    '                    chkTokseicd = True
    '
    '                '�C�O������̂Ƃ�
    '                Case 1:
    '                    Call showMsg("1", "URKET53_013", 0)     '�������̓��Ӑ�ł͂���܂���B     '2007.03.05
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '
    '                '������łȂ����Ӑ�̂Ƃ�
    '                Case 8:
    '                    Call showMsg("2", "DONTSELECT", "2")    '��������ł͂Ȃ�
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '
    '                '�����悪���݂��Ȃ���
    '                Case 9:
    '                    Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
    '                    txt_tokseicd.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '            End Select
    '
    '            txt_tokseicd.ForeColor = vbBlack
    '            chkTokseicd = True
    '        Else
    '            chkTokseicd = True
    '        End If
    '    Else
    '        chkTokseicd = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrTokseicd = txt_tokseicd.Text
    '    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    '
    'End Function
    ''// V2.00�� ADD
    '// V2.06�� DEL

    '// V2.06�� DEL
    ''// V2.00�� ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Sub chkKaidt_From
    '    '   �T�v�F  ����\����t�i�J�n�j�̃`�F�b�N
    '    '   �����F  ����
    '    '   �ߒl�F�@True:����  False:�ُ�
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkKaidt_From() As Boolean
    '
    '    chkKaidt_From = False
    '
    '    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    '    If intChkKb = 1 Then
    '
    '        '���t�`���̃`�F�b�N
    '        If Trim(txt_kaidt_From.Text) <> "" Or txt_kesikb = "9" Then
    '
    '            If IsDate(txt_kaidt_From.Text) = False Then
    '                Call showMsg("2", "DATE", 0)                '�����t����MSG
    '                txt_kaidt_From.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kaidt_From.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)         '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
    '                txt_kaidt_From.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '����������ʂŎ󒍓�(�����)�������������̓G���[
    '            If IsDate(txt_kaidt_From.Text) And IsDate(txt_kesidt.Text) Then
    '                If Format(txt_kaidt_From.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '�����t����MSG
    '                    txt_kaidt_From.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            txt_kaidt_From.ForeColor = vbBlack
    '            chkKaidt_From = True
    '        Else
    '            chkKaidt_From = True
    '        End If
    '    Else
    '        chkKaidt_From = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKaidt_Fr = DeCNV_DATE(txt_kaidt_From.Text)
    '    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    '
    'End Function
    ''// V2.00�� ADD
    '// V2.06�� DEL

    '// V2.06�� DEL
    ''// V2.00�� ADD
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Sub chkKaidt_To
    '    '   �T�v�F  ����\����t�i�I���j�̃`�F�b�N
    '    '   �����F  ����
    '    '   �ߒl�F�@True:����  False:�ُ�
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function chkKaidt_To() As Boolean
    '
    '    chkKaidt_To = False
    '
    '    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    '    If intChkKb = 1 Then
    '
    '        If txt_kaidt_To.Text <> CNV_DATE(gstrKaidt_To) Then
    '
    '            '���t�`���̃`�F�b�N
    '            If IsDate(txt_kaidt_To.Text) = False Then
    '                Call showMsg("2", "DATE", 0)                '�����t����MSG
    '                txt_kaidt_To.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            If DeCNV_DATE(txt_kaidt_To.Text) > _
    ''                DeCNV_DATE(DateAdd("d", -1, DateAdd("m", 2, Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")))) Then
    '                Call showMsg("1", "URKET53_038", 0)         '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
    '                txt_kaidt_To.ForeColor = vbRed
    '                GoTo ERR_STEP
    '            End If
    '
    '            '����������ʂŎ󒍓�(�����)�������������̓G���[
    '            If IsDate(txt_kaidt_To.Text) And IsDate(txt_kesidt.Text) Then
    '                If Format(txt_kaidt_To.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '�����t����MSG
    '                    txt_kaidt_To.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            '���t�̑召��r
    '            If IsDate(txt_kaidt_From.Text) And IsDate(txt_kaidt_To.Text) Then
    '                If Format(txt_kaidt_From.Text, "0000/00/00") > Format(txt_kaidt_To.Text, "0000/00/00") Then
    '                    Call showMsg("2", "DATE", 0)            '�����t����MSG
    '                    txt_kaidt_To.ForeColor = vbRed
    '                    GoTo ERR_STEP
    '                End If
    '            End If
    '
    '            txt_kaidt_To.ForeColor = vbBlack
    '            chkKaidt_To = True
    '        Else
    '            chkKaidt_To = True
    '        End If
    '    Else
    '        chkKaidt_To = True
    '    End If
    '
    'ERR_STEP:
    '
    '    gstrKaidt_To = DeCNV_DATE(txt_kaidt_To.Text)
    '    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
    '
    'End Function
    ''// V2.00�� ADD
    '// V2.06�� DEL

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkCondition
    '   �T�v�F  �w�b�_���̓��̓`�F�b�N
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkCondition() As Boolean
        chkCondition = False

        '�`�F�b�N�F������
        With txt_kesidt
            If Trim(.Text) = "" Then
                '�K�{���̓`�F�b�N
                Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                '�`�F�b�N����
                If chkKesidt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                    '�G���[
                    Call .Focus()
                    Exit Function
                End If
            End If
        End With

        '�`�F�b�N�F������R�[�h
        With txt_tokseicd
            If Trim(.Text) = "" Then
                '�K�{���̓`�F�b�N
                Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                '�`�F�b�N����
                If chkTokseicd(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                    '�G���[
                    Call .Focus()
                    Exit Function
                End If
            End If
        End With

        '�`�F�b�N�F�����(�J�n)
        With txt_kaidt_From
            If Trim(.Text) = "" Then
                If Trim(txt_kesikb.Text) = "9" Then
                    '�K�{���̓`�F�b�N
                    Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                    .ForeColor = System.Drawing.Color.Red
                    .Focus()
                    Exit Function
                End If
            Else
                intChkKb = 1
                If chkKaidt_From(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                    '�G���[
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        '�`�F�b�N�F�����(�I��)
        With txt_kaidt_To
            If Trim(.Text) = "" Then
                '�K�{���̓`�F�b�N
                Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                .ForeColor = System.Drawing.Color.Red
                .Focus()
                Exit Function
            Else
                intChkKb = 1
                '�`�F�b�N����
                If chkKaidt_To(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                    '�G���[
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        With txt_fridt
            If Trim(.Text) = "" Then
                If blnFriEnabled = True Then
                    '2009/09/18 ADD START RISE)MIYAJIMA
                    'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If pnl_condition1.Enabled = False Then
                        blnUsableButton = False
                        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition1.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        pnl_condition1.Enabled = True
                        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_condition2.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        pnl_condition2.Enabled = True
                        initBody()
                        intInputMode = 1
                        '�K�{���̓`�F�b�N
                        Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                        Exit Function
                    End If
                    '2009/09/18 ADD E.N.D RISE)MIYAJIMA
                    '�K�{���̓`�F�b�N
                    Call showMsg("0", "_HEADCOMPLETEC", "0") '�����o�����ʹװMSG
                    '// V3.10�� ADD
                    .Enabled = True
                    '// V3.10�� ADD
                    .ForeColor = System.Drawing.Color.Red

                    .Focus()
                    Exit Function
                End If
            Else
                intChkKb = 1
                '�`�F�b�N����
                If chkFridt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                    '�G���[
                    .Focus()
                    Exit Function
                End If
            End If
        End With

        chkCondition = True
    End Function
    '// V2.06�� ADD

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkKesidt
    '   �T�v�F  �������t�̃`�F�b�N
    '   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKesidt = False

        With txt_kesidt
            If pin_blnChk = False Then
                '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
                If intChkKb <> 1 Then
                    chkKesidt = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKesidt.Value) Then
                    chkKesidt = True
                    GoTo END_STEP
                End If
            End If

            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
            If Trim(.Text) = "" Then
                chkKesidt = True
                Exit Function
            End If

            '���t�`���̃`�F�b�N
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '2009/09/03 ADD START RISE)MIYAJIMA
            '�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
            If Trim(txt_tokseicd.Text) <> "" Then
                If DeCNV_DATE(.Text) <= DB_TOKMTA2.TOKSMEDT Then
                    Call showMsg("2", "URKET53_041", CStr(0)) '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If
            '2009/09/03 ADD E.N.D RISE)MIYAJIMA

            '�o�������ȑO�̓��t�̎��̓G���[
            If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
                'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
                Call showMsg("1", "URKET53_010", CStr(0)) '���o�����ߍς݂�MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '�^�p��������t�̎��̓G���[
            If DeCNV_DATE(.Text) > gstrUnydt.Value Then
                Call showMsg("2", "DATE_1", CStr(3)) '���^�p������t�G���[
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '���߂��ׂ��ł̓��t�̓G���[
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKesidt = True

END_STEP:

        gstrKesidt.Value = DeCNV_DATE((txt_kesidt.Text))
        intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
    End Function
    '// V2.06�� ADD

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkTokseicd
    '   �T�v�F  �����溰�ނ̃`�F�b�N
    '   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean

        '2009/09/03 ADD START RISE)MIYAJIMA
        Dim strTANCLAKB As String
        '2009/09/03 ADD E.N.D RISE)MIYAJIMA

        chkTokseicd = False

        With txt_tokseicd
            If pin_blnChk = False Then
                '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
                If intChkKb <> 1 Then
                    chkTokseicd = True
                    GoTo END_STEP
                End If
                If .Text = gstrTokseicd.Value Then
                    chkTokseicd = True
                    GoTo END_STEP
                End If
            End If

            '�ύX����Ă����獀�ڃN���A
            If .Text <> gstrTokseicd.Value Then
                txt_tokseinma.Text = ""
                txt_fridt.Text = Space(8)
                txt_fridt.Enabled = False

                lbl_shakbnm(1).Text = ""
                lbl_hytokkesdd(1).Text = ""
                gstrFridt.Value = Space(8)
            End If

            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
            If Trim(.Text) = "" Then
                chkTokseicd = True
                Exit Function
            End If

            blnFriEnabled = False

            '���Ӑ�Ͻ����琿���於�̂��擾
            Select Case getTokseinm(DeCNV_DATE((txt_kesidt.Text)), .Text)
                '����������̂Ƃ�
                Case 0
                    .ForeColor = System.Drawing.Color.Black
                    txt_tokseinma.Text = DB_TOKMTA2.TOKRN
                    lbl_shakbnm(1).Text = DB_TOKMTA2.SHAKBNM
                    lbl_hytokkesdd(1).Text = DB_TOKMTA2.HYTOKKESDD

                    '2009/09/03 ADD START RISE)MIYAJIMA
                    '�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
                    If DeCNV_DATE((txt_kesidt.Text)) <= DB_TOKMTA2.TOKSMEDT Then
                        Call showMsg("2", "URKET53_041", CStr(0)) '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
                        txt_kesidt.ForeColor = System.Drawing.Color.Red
                        txt_kesidt.Focus()
                        GoTo END_STEP
                    End If
                    '2009/09/03 ADD E.N.D RISE)MIYAJIMA
                    '2009/09/03 ADD START RISE)MIYAJIMA
                    Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA2.TANCD, strTANCLAKB)
                    If strTANCLAKB <> "1" Then
                        Call showMsg("2", "URKET53_042", CStr(0)) '��������S���҂��c�Ƃł���܂���B
                        .ForeColor = System.Drawing.Color.Red
                        GoTo END_STEP
                    End If
                    '2009/09/03 ADD E.N.D RISE)MIYAJIMA

                    '// V3.10�� UPD
                    Call getInputHYFRIDT(DB_TOKMTA2.TOKSEICD, Get_Acedt(DeCNV_DATE((txt_kesidt.Text))), DB_TOKMTA2.SHAKB)
                    '                '�x�������Ɏ�`�������Ă���ꍇ�͖��ׂ̐U����������͂ł���悤�ɂ���
                    '                Select Case DB_TOKMTA2.SHAKB
                    '                    Case "2", "3", "4", "5", "6"
                    '                        blnFriEnabled = True
                    '                End Select
                    '// V3.10�� UPD

                    txt_fridt.Enabled = blnFriEnabled
                    chkTokseicd = True

                    '�C�O������̂Ƃ�
                Case 1
                    Call showMsg("1", "URKET53_013", CStr(0)) '�������̓��Ӑ�ł͂���܂���B
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP

                    '������łȂ����Ӑ�̂Ƃ�
                Case 8
                    Call showMsg("2", "DONTSELECT", "2") '��������ł͂Ȃ�
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP

                    '�����悪���݂��Ȃ���
                Case 9
                    Call showMsg("2", "RNOTFOUND", "0") '���Y���f�[�^�Ȃ�
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
            End Select

            .ForeColor = System.Drawing.Color.Black
        End With

        chkTokseicd = True

END_STEP:

        gstrTokseicd.Value = txt_tokseicd.Text
        intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
    End Function
    '// V2.06�� ADD

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkKaidt_From
    '   �T�v�F  ����\����t�i�J�n�j�̃`�F�b�N
    '   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKaidt_From = False

        With txt_kaidt_From
            If pin_blnChk = False Then
                '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
                If intChkKb <> 1 Then
                    chkKaidt_From = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKaidt_Fr.Value) Then
                    chkKaidt_From = True
                    GoTo END_STEP
                End If
            End If

            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
            If Trim(.Text) = "" Then
                gstrKaidt_Fr.Value = ""
                chkKaidt_From = True
                Exit Function
            End If

            '���t�`���̃`�F�b�N
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '���߂��ׂ��ł̓��t�̓G���[
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '����������ʂŎ󒍓�(�����)�������������̓G���[
            If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
                If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKaidt_From = True

END_STEP:

        gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
        intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
    End Function
    '// V2.06�� ADD

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkKaidt_To
    '   �T�v�F  ����\����t�i�I���j�̃`�F�b�N
    '   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        Dim date1 As String
        Dim date2 As String
        Dim date3 As String

        chkKaidt_To = False

        With txt_kaidt_To
            If pin_blnChk = False Then
                '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
                If intChkKb <> 1 Then
                    chkKaidt_To = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrKaidt_To.Value) Then
                    chkKaidt_To = True
                    GoTo END_STEP
                End If
            End If

            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
            If Trim(.Text) = "" Then
                chkKaidt_To = True
                Exit Function
            End If

            '���t�`���̃`�F�b�N
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '���߂��ׂ��ł̓��t�̓G���[
            date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
            date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
            date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
            If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
                Call showMsg("1", "URKET53_038", CStr(0)) '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '����������ʂŎ󒍓�(�����)�������������̓G���[
            If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
                If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                    .ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                End If
            End If

            '���t�̑召��r
            If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
                If VB6.Format(txt_kaidt_From.Text, "0000/00/00") > VB6.Format(.Text, "0000/00/00") Then
                    Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                    .ForeColor = System.Drawing.Color.Red
                    txt_kaidt_From.ForeColor = System.Drawing.Color.Red
                    GoTo END_STEP
                Else
                    '�`�F�b�N�G���[�Ȃ�
                    txt_kaidt_From.ForeColor = System.Drawing.Color.Black
                End If
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkKaidt_To = True

END_STEP:

        gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
        intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
    End Function
    '// V2.06�� ADD

    '// V2.06�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function chkFridt
    '   �T�v�F  �U�������̃`�F�b�N
    '   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
        chkFridt = False

        With txt_fridt
            If pin_blnChk = False Then
                '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
                If intChkKb <> 1 Then
                    chkFridt = True
                    GoTo END_STEP
                End If
                If .Text = CNV_DATE(gstrFridt.Value) Then
                    chkFridt = True
                    GoTo END_STEP
                End If
            End If

            '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
            If Trim(.Text) = "" Then
                chkFridt = True
                Exit Function
            End If

            '���t�`���̃`�F�b�N
            If IsDate(.Text) = False Then
                Call showMsg("2", "DATE", CStr(0)) '�����t����MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            '�o�������ȑO�̓��t�̎��̓G���[
            If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
                'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
                Call showMsg("1", "URKET53_010", CStr(0)) '���o�����ߍς݂�MSG
                .ForeColor = System.Drawing.Color.Red
                GoTo END_STEP
            End If

            .ForeColor = System.Drawing.Color.Black
        End With

        chkFridt = True

END_STEP:

        gstrFridt.Value = DeCNV_DATE((txt_fridt.Text))
        intChkKb = 2 '����{�͕ύX���Ƀ`�F�b�N
    End Function
    '// V2.06�� ADD

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_Change
    '   �T�v�F  ���t���ړ��t�ϊ�
    '   �����F  pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub Ctl_DTItem_Change(ByRef pm_objDt As Object)
        '2019/04/17 CHG START
        'With pm_objDt
        '    '�X���b�V�������݂��Ă���Ƃ��́A�X���b�V�����΂��Ď��̍��ڂ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If Mid(.Text, .SelStart + 1, 1) = "/" Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SelStart = .SelStart + 1
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    .SelLength = 1

        '    '���͂��ꂽ�l���W���ɓ��B�����̂ŃX���b�V���ҏW����
        '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If Len(Trim(.Text)) = 8 Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .Text = VB6.Format(.Text, "0000/00/00")
        '        '���t�̓��̕�����I����Ԃɂ���
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SelStart = 8
        '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SelLength = 1
        '    End If
        'End With

        If TypeOf pm_objDt Is System.Windows.Forms.TextBox Then
            With DirectCast(pm_objDt, TextBox)
                '�X���b�V�������݂��Ă���Ƃ��́A�X���b�V�����΂��Ď��̍���
                If Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                    .SelectionStart = .SelectionStart + 1
                End If

                .SelectionLength = 1

                '���͂��ꂽ�l���W���ɓ��B�����̂ŃX���b�V���ҏW����
                If Len(Trim(.Text)) = 8 Then
                    .Text = VB6.Format(.Text, "0000/00/00")
                    '���t�̓��̕�����I����Ԃɂ���
                    .SelectionStart = 8
                    .SelectionLength = 1
                End If

            End With
        End If
        '2019/04/17 CHG EN D
    End Sub
    '// V2.00�� ADD

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_GotFocus
    '   �T�v�F  ���t���ڂ̃J�[�\���ʒu�t��
    '   �����F  pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub Ctl_DTItem_GotFocus(ByRef pm_objDt As Object)

        '2019/04/17 CHG START
        'With pm_objDt
        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.ForeColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	If Trim(.Text) = "" Or pm_objDt.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then
        '		'�Ȃɂ������Ă��Ȃ��܂��̓G���[�̎��ɐ擪�ֈʒu�Â�
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SelStart = 0
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SelLength = 1
        '	Else
        '		'�Ȃɂ������Ă�������t�̏\�̈ʂ�I����Ԃɂ���
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SelStart = 8
        '		'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		.SelLength = 1
        '	End If
        '	'�w�i�F�����F�ɂ���
        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        'End With
        If TypeOf pm_objDt Is System.Windows.Forms.TextBox Then
            With DirectCast(pm_objDt, TextBox)
                If Trim(.Text) = "" Or pm_objDt.ForeColor = Color.Red Then
                    '�Ȃɂ������Ă��Ȃ��܂��̓G���[�̎��ɐ擪�ֈʒu�Â�
                    .SelectionStart = 0
                    .SelectionLength = 1
                Else
                    '�Ȃɂ������Ă�������t�̏\�̈ʂ�I����Ԃɂ���
                    .SelectionStart = 8
                    .SelectionLength = 1
                End If
                '�w�i�F�����F�ɂ���
                pm_objDt.BackColor = Color.Yellow
            End With
        End If
        '2019/04/17 CHG EN D

    End Sub
    '// V2.00�� ADD

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_KeyDown
    '   �T�v�F  �����溰�ރL�[���͐���
    '   �����F  pm_KeyCode    : �L�[�R�[�h
    '           pm_Shift      : �V�t�g�������
    '           pm_objDt      : �����溰�޵�޼ު��
    '   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_tokseicd_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objCD As Object) As Short

        Ctl_tokseicd_KeyDown = 0

        With pm_objCD

            Select Case pm_KeyCode

                '�t�@���N�V�����L�[������
                Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
                    '�t�@���N�V�����L�[���ʏ���
                    Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)

                    '�E��󉟉���
                Case System.Windows.Forms.Keys.Right
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    'If .SelStart < 4 Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SelStart = .SelStart + 1
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SelLength = 1
                    If .SelectionStart < 4 Then
                        .SelectionStart = .SelectionStart + 1
                        .SelectionLength = 1
                        '2019/04/17 CHG E N D
                    Else
                        intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                        Ctl_tokseicd_KeyDown = 1
                    End If

                    'Backspace or ����󉟉���
                Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    'If .SelStart > 0 Then
                    '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '	.SelStart = .SelStart - 1
                    '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '	.SelLength = 1
                    If .SelectionStart > 0 Then
                        .SelectionStart = .SelectionStart - 1
                        .SelectionLength = 1
                        '2019/04/17 CHG E N D
                    Else
                        'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objCD.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(.Text) <> "" And pm_KeyCode = System.Windows.Forms.Keys.Back Then
                            Exit Function
                        End If
                        intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                        Ctl_tokseicd_KeyDown = 2
                    End If

                    '���󉟉���
                Case System.Windows.Forms.Keys.Up
                    intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                    Ctl_tokseicd_KeyDown = 2

                    '����󉟉���
                Case System.Windows.Forms.Keys.Down
                    intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                    Ctl_tokseicd_KeyDown = 1

                    'Enter������
                Case System.Windows.Forms.Keys.Return
                    intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
                    Ctl_tokseicd_KeyDown = 1

                    'Delete������
                Case System.Windows.Forms.Keys.Delete
                    Exit Function

                    'TAB��
                Case System.Windows.Forms.Keys.F16
                    intChkKb = 1 '�������溰�ނ̓��̓`�F�b�N
                    Ctl_tokseicd_KeyDown = 1

                    'SHIFT+TAB��
                Case System.Windows.Forms.Keys.F15
                    intChkKb = 2 '�������溰�ނ̓��̓`�F�b�N
                    Ctl_tokseicd_KeyDown = 2

                Case Else
                    Exit Function

            End Select

        End With

    End Function
    '// V2.00�� ADD

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_KeyDown
    '   �T�v�F  ���t���ڃL�[���͐���
    '   �����F  pm_KeyCode    : �L�[�R�[�h
    '           pm_Shift      : �V�t�g�������
    '           pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_DTItem_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objDt As Object) As Short

        Ctl_DTItem_KeyDown = 0

        'UPGRADE_NOTE: str �� str_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
        Dim str_Renamed As String
        With pm_objDt

            Select Case pm_KeyCode

                '�t�@���N�V�����L�[������
                Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
                    '�t�@���N�V�����L�[���ʏ���
                    Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)

                    '�E��� or Space������
                Case System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.Space

                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    'If .SelStart < 9 Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SelStart = .SelStart + 1
                    '    '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                    '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '        .SelStart = .SelStart + 1
                    '    End If
                    If .SelectionStart < 9 Then
                        .SelectionStart = .SelectionStart + 1
                        '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
                        If .SelectionStart = 4 And Mid(.Text, .SelectionStart + 1, 1) = "/" Or .SelectionStart = 7 And Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                            .SelectionStart = .SelectionStart + 1
                        End If
                        '2019/04/17 CHG E N D
                        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
                    Else
                        intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                        Ctl_DTItem_KeyDown = 1
                    End If
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    '.SelLength = 1
                    .SelectionLength = 1
                    '2019/04/17 CHG E N D

                    'Backspace or ����󉟉���
                Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left

                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    'If .SelStart > 0 Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SelStart = .SelStart - 1
                    '    '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                    '        'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '        .SelStart = .SelStart - 1
                    '    End If
                    If .SelectionStart > 0 Then
                        .SelectionStart = .SelectionStart - 1
                        '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
                        If .SelectionStart = 4 And Mid(.Text, .SelectionStart + 1, 1) = "/" Or .SelectionStart = 7 And Mid(.Text, .SelectionStart + 1, 1) = "/" Then
                            .SelectionStart = .SelectionStart - 1
                        End If
                        '2019/04/17 CHG E N D
                        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
                    Else
                        intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                        Ctl_DTItem_KeyDown = 2
                    End If
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    '.SelLength = 1
                    .SelectionLength = 1
                    '2019/04/17 CHG E N D

                    '���󉟉���
                Case System.Windows.Forms.Keys.Up
                    intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                    Ctl_DTItem_KeyDown = 2

                    '����󉟉���
                Case System.Windows.Forms.Keys.Down
                    intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                    Ctl_DTItem_KeyDown = 1

                    'Enter������
                Case System.Windows.Forms.Keys.Return
                    intChkKb = 1 '�����t�̓��̓`�F�b�N
                    Ctl_DTItem_KeyDown = 1

                    'TAB��
                Case System.Windows.Forms.Keys.F16
                    intChkKb = 1 '�����t�̓��̓`�F�b�N
                    Ctl_DTItem_KeyDown = 1

                    'Shift+TAB��
                Case System.Windows.Forms.Keys.F15
                    intChkKb = 2 '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                    Ctl_DTItem_KeyDown = 2
                    '// V2.06�� ADD
                    'Shift+DELETE��
                Case System.Windows.Forms.Keys.Delete And pm_Shift = 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    str_Renamed = .Text
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/17 CHG START
                    'If Len(str_Renamed) > 0 And .SelStart < Len(str_Renamed) Then
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    str_Renamed = Mid(str_Renamed, 1, .SelStart) & Mid(str_Renamed, .SelStart + 2)
                    '    str_Renamed = Replace(str_Renamed, "/", "")
                    '    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '    .SelStart = 0
                    If Len(str_Renamed) > 0 And .SelectionStart < Len(str_Renamed) Then
                        str_Renamed = Mid(str_Renamed, 1, .SelectionStart) & Mid(str_Renamed, .SelectionStart + 2)
                        str_Renamed = Replace(str_Renamed, "/", "")
                        .SelectionStart = 0
                        '2019/04/17 CHG E N D

                        If Len(str_Renamed) > 0 Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/17 CHG START
                            '.SelLength = 1
                            .SelectionLength = 1
                            '2019/04/17 CHG E N D
                        End If
                    End If
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_objDt.Text �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .Text = str_Renamed
                    '// V2.06�� ADD

            End Select

        End With

    End Function
    '// V2.00�� ADD

    '=======================================================����\���(�J�n)=======================================================

    '����\����N���b�N��
    Private Sub txt_kaidt_From_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Click

        txt_kaidt_From.SelectionStart = 0
        txt_kaidt_From.SelectionLength = 1

    End Sub

    '����\������ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_kaidt_From.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_kaidt_From_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.TextChanged

        '���t�ϊ�����
        Call Ctl_DTItem_Change(txt_kaidt_From)

    End Sub

    '����\������ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_kaidt_From_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Enter

        '�J�[�\���ʒu�t��
        Call Ctl_DTItem_GotFocus(txt_kaidt_From)

        '�������������s�\�Ƃ���
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '����\������ڂŃL�[����������
    Private Sub txt_kaidt_From_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_From.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '�L�[���͐���
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
            Case 0
                '�������Ȃ�
            Case 1
                '���̓`�F�b�N
                If chkKaidt_From() = True Then
                    '������
                    txt_kaidt_To.Focus()
                End If
            Case 2
                '���̓`�F�b�N
                If chkKaidt_From() = True Then
                    '�O����
                    txt_tokseicd.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '����\������ڂŃL�[����������
    Private Sub txt_kaidt_From_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_From.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '���l�̂ݓ��͉Ƃ���
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '����\������ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_kaidt_From_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Leave

        '�w�i�F�𔒂ɖ߂�
        txt_kaidt_From.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================����\���(�I��)=======================================================

    '����\����N���b�N��
    Private Sub txt_kaidt_To_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Click

        txt_kaidt_To.SelectionStart = 0
        txt_kaidt_To.SelectionLength = 1

    End Sub

    '����\������ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_kaidt_To.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_kaidt_To_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.TextChanged

        '���t�ϊ�����
        Call Ctl_DTItem_Change(txt_kaidt_To)

    End Sub

    '����\������ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_kaidt_To_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Enter

        '�J�[�\���ʒu�t��
        Call Ctl_DTItem_GotFocus(txt_kaidt_To)

        '�������������s�\�Ƃ���
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '����\������ڂŃL�[����������
    Private Sub txt_kaidt_To_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_To.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '�L�[���͐���
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
            Case 0
                '�������Ȃ�
            Case 1
                '���̓`�F�b�N
                If chkKaidt_To() = True Then
                    '������
                    txt_kesikb.Focus()
                End If
            Case 2
                '���̓`�F�b�N
                If chkKaidt_To() = True Then
                    '�O����
                    txt_kaidt_From.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '����\������ڂŃL�[����������
    Private Sub txt_kaidt_To_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_To.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '���l�̂ݓ��͉Ƃ���
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '����\������ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_kaidt_To_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Leave

        '�w�i�F�𔒂ɖ߂�
        txt_kaidt_To.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================������=======================================================

    '���������ڃN���b�N��
    Private Sub txt_kesidt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Click

        txt_kesidt.SelectionStart = 0
        txt_kesidt.SelectionLength = 1

    End Sub

    '���������ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_kesidt.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_kesidt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.TextChanged

        '���t�ϊ�����
        Call Ctl_DTItem_Change(txt_kesidt)

    End Sub

    '���������ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_kesidt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Enter

        intInputMode = 1

        '�J�[�\���ʒu�t��
        Call Ctl_DTItem_GotFocus(txt_kesidt)

        '2019/04/26 CHG START
        ''�������������s�\�Ƃ���
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D
    End Sub

    '���������ڂŃL�[����������
    Private Sub txt_kesidt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesidt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        intChkKb = 0

        '�L�[���͐���
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
            Case 0
                '�������Ȃ�
            Case 1
                '���̓`�F�b�N
                If chkKesidt() = True Then
                    '������
                    txt_tokseicd.Focus()
                End If
            Case 2
                '���̓`�F�b�N
                If chkKesidt() = True Then
                    '�O����
                    txt_kesidt.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '���������ڂŃL�[����������
    Private Sub txt_kesidt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesidt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '���l�̂ݓ��͉Ƃ���
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '���������ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_kesidt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Leave

        '�w�i�F�𔒂ɖ߂�
        txt_kesidt.BackColor = System.Drawing.Color.White

    End Sub

    '=======================================================�U������=======================================================

    '�U���������ڂ�ύX������
    'UPGRADE_WARNING: �C�x���g txt_fridt.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub txt_fridt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.TextChanged

        '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
        If blnUsableEvent = False Then
            Exit Sub
        End If

        '���t�ϊ�����
        Call Ctl_DTItem_Change(txt_fridt)

        blnUsableEvent = True

    End Sub

    '�U���������ڂɃt�H�[�J�X���ڂ�����
    Private Sub txt_fridt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Enter

        '�J�[�\���ʒu�t��
        Call Ctl_DTItem_GotFocus(txt_fridt)

        '�������������s�\�Ƃ���
        '2019/04/26 CHG START
        'mnu_showwnd.Enabled = True
        Button5.Enabled = True
        '2019/04/26 CHG E N D

    End Sub

    '�U���������ڂŃL�[����������
    Private Sub txt_fridt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_fridt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '�L�[���͐���
        Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
            Case 0
                '�������Ȃ�
            Case 1
                '���̓`�F�b�N
                If chkFridt() = True Then
                    '������
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/23 CHG START
                    'spd_body.SetFocus()
                    spd_body.Focus()
                    '2019/04/23 CHG E N D
                End If
            Case 2
                '���̓`�F�b�N
                If chkFridt() = True Then
                    '�O����
                    txt_kesikb.Focus()
                End If
        End Select

        KeyCode = 0

    End Sub

    '�U���������ڂŃL�[����������
    Private Sub txt_fridt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_fridt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        '���l�̂ݓ��͉Ƃ���
        If Not Chr(KeyAscii) Like "[0-9]" Then
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    '�U���������ڂ���t�H�[�J�X���ڂ�����
    Private Sub txt_fridt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Leave

        '�w�i�F�𔒂ɖ߂�
        txt_fridt.BackColor = System.Drawing.Color.White

    End Sub

    '// V2.00�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_FuncKey_Execute
    '   �T�v�F  �V�X�e�����ʏ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Short, ByVal pm_Shift As Short) As Short

        CF_FuncKey_Execute = 0

        Select Case True
            'F1�L�[����
            Case pm_KeyCode = System.Windows.Forms.Keys.F1 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%1")

                'F2�L�[����
            Case pm_KeyCode = System.Windows.Forms.Keys.F2 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%2")

                'F3�L�[����
            Case pm_KeyCode = System.Windows.Forms.Keys.F3 And pm_Shift = 0
                System.Windows.Forms.SendKeys.Send("%3")
        End Select

    End Function
    '// V2.00�� ADD

    '2019/04/24 DEL START
    ''// V2.00�� ADD
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Function CF_System_Process
    ''   �T�v�F  �V�X�e�����ʏ���
    ''   �����F�@�Ȃ�
    ''   �ߒl�F�@�Ȃ�
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short

    '    '�p�b�P�[�W���̂c�k�k�ɂ�
    '    '��s�`�a�����s�`�a�{�r�g�h�e�s������ꂼ�ꢂe�P�U�����e�P�T��Ɋ���
    '    ReleaseTabCapture(0)
    '    SetTabCapture(pm_Form.Handle.ToInt32)

    'End Function
    ''// V2.00�� ADD
    '2019/04/24 DEL E N D

    '// V2.13�� ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Sub chkFurikomiDT
    '   �T�v�F TOKMTA.SHAKB�i�x�������j�Ɏ�`�������Ă���ꍇ�͐U���������K�{
    '       �F ���グ�������������Ӑ�̐��������̎����z���ύX����Ă�����G���[
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function chkFurikomiDT() As Boolean

        Dim idxRow As Integer
        Dim tmp As Object
        Dim intchk As Short
        Dim strHYFRIDT As String
        '2009/10/01 ADD START RISE)MIYAJIMA COL_BFHYFRIDT
        Dim intchk_mae As Short
        Dim vntBFHYFRIDT As Object
        '2009/10/01 ADD E.N.D RISE)MIYAJIMA

        chkFurikomiDT = False

        If blnFriEnabled = False Then
            chkFurikomiDT = True
            Exit Function
        End If

        '�ԕi������
        With spd_body
            '2019/04/25 CHG START
            'For idxRow = 1 To intMaxRow
            For idxRow = 0 To intMaxRow - 1
                '2019/04/25 CHG E N D

                '�`�F�b�N�������Ă��邩���m�F
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = .GetValue(idxRow, COL_CHK)
                '2019/04/23 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/25 CHG START
                'intchk = SSSVal(tmp)
                intchk = SSSVal(IIf(tmp = True, 1, 0))
                '2019/04/25 CHG E N D

                '�`�F�b�N�������Ă���ꍇ
                If intchk = 1 Then
                    '������̎擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/23 CHG START
                    'Call .GetText(COL_HYFRIDT, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYFRIDT)
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strHYFRIDT = CStr(tmp)

                    '2009/09/27 UPD START RISE)MIYAJIMA
                    '                If Trim(strHYFRIDT) = "" Then
                    '                    Call showMsg("0", "_COMPLETEC", 0)     '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
                    '                    Exit Function
                    '                End If
                    '2009/10/01 UPD START RISE)MIYAJIMA
                    '                If Trim(gstrFridt) <> "" Then
                    '                    If Trim(strHYFRIDT) = "" Then
                    '                        Call showMsg("0", "_COMPLETEC", 0)     '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
                    '                        Exit Function
                    '                    End If
                    '                End If

                    '�`�F�b�N�������Ă��邩���m�F
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/23 CHG START
                    '.GetText(COL_BFCHECK, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_BFCHECK)
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    intchk_mae = SSSVal(tmp)
                    '������̎擾
                    'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/23 CHG START
                    'Call .GetText(COL_BFHYFRIDT, idxRow, vntBFHYFRIDT)
                    vntBFHYFRIDT = .GetValue(idxRow, COL_BFHYFRIDT)
                    '2019/04/23 CHG E N D

                    If intchk_mae <> 1 Then
                        If Trim(gstrFridt.Value) <> "" Then
                            If Trim(strHYFRIDT) = "" Then
                                Call showMsg("0", "_COMPLETEC", CStr(0)) '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
                                Exit Function
                            End If
                        End If
                    End If
                    '2009/10/01 UPD E.N.D RISE)MIYAJIMA
                    '2009/09/27 UPD E.N.D RISE)MIYAJIMA
                End If
            Next idxRow
        End With

        chkFurikomiDT = True

    End Function

    '2009/09/08 UPD START RISE)MIYAJIMA
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F Function chk_HENPIN
    ''   �T�v�F �����ɕԕi���������Ă��邩�`�F�b�N����
    ''   �����F strJdnNo   : �󒍓`�[�ԍ�
    ''   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
    ''       :  strUrikn   : ������z
    ''   �ߒl�F �`�F�b�N����
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Function chkHenpin2(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUDNDT As String) As Boolean
    '
    '    Dim Usr_Ody         As U_Ody
    '    Dim strSql          As String
    '
    '    On Error GoTo ERR_chkHENPIN2
    '
    '    '//�\�����܂�
    '    chkHenpin2 = True
    '
    '    If Trim$(gstrKaidt_Fr) = "" Then
    '        '//�\�����܂�
    '        GoTo END_chkHENPIN2
    '    End If
    '
    '    '//�����ɕԕi�f�[�^�����݂��Ă��邩�m�F����
    '    strSql = " "
    '    strSql = " SELECT *"
    '    strSql = strSql & " FROM    UDNTRA"
    '    strSql = strSql & " WHERE   JDNNO    =  '" & strJDNNO & "'"
    '    strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinNo & "'"
    '    strSql = strSql & " AND     DATKB =  '1'"
    ''2009/09/03 UPD START RISE)MIYAJIMA
    ''    strSql = strSql & " AND     AKAKROKB =  '9'"
    ''    strSql = strSql & " AND     DKBID    =  '02'"
    '    strSql = strSql & " AND     AKAKROKB =  '1'"
    '    strSql = strSql & " AND     DKBID    =  '01'"
    ''2009/09/03 UPD E.N.D RISE)MIYAJIMA
    ''2009/09/03 DEL START RISE)MIYAJIMA
    ''    strSql = strSql & " AND     UDNDT    >= '" & gstrKaidt_Fr & "'"
    ''2009/09/03 DEL E.N.D RISE)MIYAJIMA
    '    strSql = strSql & " AND     UDNDT    <= '" & gstrKaidt_To & "'"
    '
    '    'DB�A�N�Z�X
    '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '    '�f�[�^�����݂����ꍇ
    '    If CF_Ora_EOF(Usr_Ody) = False Then
    '
    '        Select Case txt_kesikb.Text
    '            Case 1
    '                '��������Ă��Ȃ��ꍇ�A�������s��
    '                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
    '                    '//�\�����܂�
    '                    GoTo END_chkHENPIN2
    '                Else
    '                    '//�\�����܂���
    '                    chkHenpin2 = False
    '                    GoTo END_chkHENPIN2
    '                End If
    '            Case 9
    ''2009/09/03 UPD START RISE)MIYAJIMA
    ''                '��������Ă��Ȃ��ꍇ�A�������s��
    ''                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
    '                '��������Ă��Ȃ��ꍇ�A�������s��
    '                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
    ''2009/09/03 UPD E.N.D RISE)MIYAJIMA
    '                    '//�\�����܂�
    '                    GoTo END_chkHENPIN2
    '                Else
    '                    '//�\�����܂���
    '                    chkHenpin2 = False
    '                    GoTo END_chkHENPIN2
    '                End If
    '        End Select
    '
    '        '//�\�����܂�
    '        GoTo END_chkHENPIN2
    '
    '    End If
    '
    '    '�f�[�^�����݂��Ȃ������ꍇ
    '    If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
    '        '//�\�����܂���
    '        chkHenpin2 = False
    '        GoTo END_chkHENPIN2
    '    End If
    '
    'END_chkHENPIN2:
    '    '�N���[�Y
    '    Call CF_Ora_CloseDyn(Usr_Ody)
    '
    '    Exit Function
    '
    'ERR_chkHENPIN2:
    '    GoTo END_chkHENPIN2
    '
    'End Function
    ''// V2.13�� ADD

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function chkDspData
    '   �T�v�F �f�[�^��\�����Ă������̔��f���s��
    '   �����F strJdnNo   : �󒍓`�[�ԍ�
    '   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
    '       :  strUDNDT   :
    '       :  strKOMIKN  :
    '       :  strKESIKN  :
    '   �ߒl�F �`�F�b�N����(False:�\���ΏۊO�f�[�^ true:�\���Ώ�)
    '   ���l�F ��ʂ͈͓̔��ɐԍ��f�[�^�����݂��Ă��邩�m�F���Ȃ���Ε\�����Ȃ�
    '   �@�@�F ��ʂ̏����f�[�^�\���敪�ɂ��������ĕ\�����邩���Ȃ��������肷��
    '   �@�@�F ��ʂ͈̔͂Ŏw�肳��Ă���f�[�^�݂̂�\�����邽�߂ɔ͈͂̊m�F������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Function chkDspData(ByVal strJDNNO As String, ByVal strJdnlinNo As String, ByVal strUDNDT As String, ByVal strKOMIKN As String, ByVal strKESIKN As String) As Boolean

        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_chkDspData

        '//�\�����܂�
        chkDspData = True

        '2009/09/10 DEL START RISE)MIYAJIMA
        '    '����ʂ͈͓̔��ɐԍ��f�[�^�����݂��Ă��邩�m�F���Ȃ���Ε\�����Ȃ�
        '
        '    '//�͈͊O�ɕЊ��ꂪ���邩�m�F����
        '    strSql = ""
        '    strSql = strSql & " SELECT COUNT(*) DATCNT FROM UDNTRA" & vbCrLf
        '    strSql = strSql & " WHERE " & vbCrLf
        '    strSql = strSql & "      JDNNO    = '" & strJDNNO & "'" & vbCrLf
        '    strSql = strSql & " AND  JDNLINNO = '" & strJdnlinNo & "'" & vbCrLf
        '    strSql = strSql & " AND ((DKBID   = '01' AND AKAKROKB = '1')" & vbCrLf
        '    strSql = strSql & "       OR" & vbCrLf
        '    strSql = strSql & "      (DKBID  <> '01' AND AKAKROKB = '9'))" & vbCrLf
        '    strSql = strSql & " AND  DATKB    = '1'" & vbCrLf
        '    strSql = strSql & " AND  DENKB    = '1'" & vbCrLf
        '    If Trim(gstrKaidt_Fr) <> "" Then
        '        strSql = strSql & " AND (UDNDT < '" & gstrKaidt_Fr & "'" & " OR  UDNDT > '" & gstrKaidt_To & "')" & vbCrLf
        '    Else
        '        strSql = strSql & " AND  UDNDT    > '" & gstrKaidt_To & "'" & vbCrLf
        '    End If
        '    strSql = strSql & " AND  SSADT    > '" & DB_TOKMTA2.TOKSMEDT & "'" & vbCrLf
        '
        '    'DB�A�N�Z�X
        '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        '
        '    '�f�[�^�����݂����ꍇ
        '    If CF_Ora_EOF(Usr_Ody) = False Then
        '        If CF_Ora_GetDyn(Usr_Ody, "DATCNT", "") <> 0 Then
        '            '//�\�����܂���i�͈͊O�ɂ���̂łЂ傤�����Ȃ��j
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '
        '    '����ʂ̏����f�[�^�\���敪�ɂ��������ĕ\�����邩���Ȃ��������肷��
        '    If txt_kesikb.Text = "1" Then
        '
        '        If strKOMIKN = strKESIKN Then
        '
        '            '//�����ɕԕi�f�[�^�����݂��Ă��邩�m�F����
        '            strSql = " "
        '            strSql = strSql & " SELECT COUNT(*) DATCNT" & vbCrLf
        '            strSql = strSql & " FROM   UDNTRA" & vbCrLf
        '            strSql = strSql & " WHERE  JDNNO    =  '" & strJDNNO & "'" & vbCrLf
        '            strSql = strSql & " AND    JDNLINNO =  '" & strJdnlinNo & "'" & vbCrLf
        '            strSql = strSql & " AND    DATKB    =  '1'" & vbCrLf
        '            strSql = strSql & " AND    AKAKROKB =  '9'" & vbCrLf
        '            strSql = strSql & " AND    DKBID    IN  ('02','06')" & vbCrLf
        '            If Trim(gstrKaidt_Fr) <> "" Then
        '                strSql = strSql & " AND    UDNDT    >= '" & gstrKaidt_Fr & "'" & vbCrLf
        '            End If
        '            strSql = strSql & " AND    UDNDT    <= '" & gstrKaidt_To & "'" & vbCrLf
        '            strSql = strSql & " AND    SSADT    <= '" & DB_TOKMTA2.TOKSMEDT & "'" & vbCrLf
        '
        '            'DB�A�N�Z�X
        '            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        '
        '            '�f�[�^�����݂����ꍇ
        '            If CF_Ora_EOF(Usr_Ody) = False Then
        '                If CF_Ora_GetDyn(Usr_Ody, "DATCNT", "") = 0 Then
        '                    '//�\�����܂���
        '                    chkDspData = False
        '                    GoTo END_chkDspData
        '                End If
        '            End If
        '
        '        End If
        '    End If
        '
        '    '����ʂ͈̔͂Ŏw�肳��Ă���f�[�^�݂̂�\�����邽�߂ɔ͈͂̊m�F������
        '    If Trim(gstrKaidt_Fr) <> "" Then
        '        If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
        '            '//�\�����܂���
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '    If Trim(gstrKaidt_To) <> "" Then
        '        If Trim$(strUDNDT) > Trim$(gstrKaidt_To) Then
        '            '//�\�����܂���
        '            chkDspData = False
        '            GoTo END_chkDspData
        '        End If
        '    End If
        '2009/09/10 DEL E.N.D RISE)MIYAJIMA

END_chkDspData:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_chkDspData:
        GoTo END_chkDspData

    End Function
    '2009/09/08 UPD E.N.D RISE)MIYAJIMA

    '// V3.10�� ADD
    '�U�������̓��͉\���f
    Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)

        Dim strSql As Object
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        Dim curNYUKIN1 As Short
        Dim curNYUKIN2 As Short

        '���������x�̏�����Ԃ��擾
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & " SELECT * "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "   FROM NKSSMA "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

        'UPGRADE_WARNING: �I�u�W�F�N�g strSql �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        Dim dt As DataTable = DB_GetTable(strSql)
        '2019/04/18 CHG E N D

        '�U����������͂ł��邩�ǂ����̃t���O��ݒ肷��
        blnFriEnabled = False

        '2019/04/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN02, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN02", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        '    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN07, )) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN07", "")) <> 0 Then
        '        blnFriEnabled = True
        '        GoTo END_getInputHYFRIDT
        '    End If
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN02"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKZANKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("SSANYUKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If

            If SSSVal(DB_NullReplace(dt.Rows(0)("KSKNYKKN07"), "")) <> 0 Then
                blnFriEnabled = True
                GoTo END_getInputHYFRIDT
            End If
        End If
        '2019/04/18 CHG E N D

        ''''    blnFriEnabled = False
        ''''
        ''''    '�U����������͂ł��邩�ǂ����̃t���O��ݒ肷��(��`�A�����U���f�[�^�����݂���ꍇ�͓��͉\�Ƃ���j
        ''''    strSql = " "
        ''''    strSql = " SELECT count(*) DATCNT "
        ''''    strSql = strSql & " FROM    UDNTRA"
        ''''    strSql = strSql & " WHERE   DATKB =  '1'"
        ''''    strSql = strSql & " AND     DENKB =  '8' "
        ''''    strSql = strSql & " AND     DKBID IN ('03','08') "
        ''''    strSql = strSql & " AND     UDNDT <= '" & gstrKaidt_To & "'"
        ''''
        ''''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        ''''
        ''''    If CF_Ora_EOF(Usr_Ody) = False Then
        ''''        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "DATCNT", "")) <> 0 Then
        ''''            blnFriEnabled = True
        ''''        End If
        ''''    End If

END_getInputHYFRIDT:

        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
    End Sub
    '// V3.10�� ADD

    '2009/09/03 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_Util_GET_TANMTA_TANCLAKB
    '   �T�v�F  �c�ƒS���t���O���擾
    '   �����F�@pot_strTANCD       : �S���҃R�[�h
    '       �F�@pot_strKEIBMNCD    : �c�ƒS���t���O
    '   �ߒl�F�@0:����I�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short

        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB

        F_Util_GET_TANMTA_TANCLAKB = 9

        pot_strTANCLAKB = ""

        '�S���҂l
        strSql = ""
        strSql = strSql & " SELECT TANCLAKB "
        strSql = strSql & " FROM TANMTA "
        strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DB�A�N�Z�X
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            pot_strTANCLAKB = DB_NullReplace(dt.Rows(0)("TANCLAKB"), "")
            '2019/04/18 CHG E N D
        Else
            GoTo END_F_Util_GET_TANMTA_TANCLAKB
        End If

        F_Util_GET_TANMTA_TANCLAKB = 0

END_F_Util_GET_TANMTA_TANCLAKB:
        '�N���[�Y
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_F_Util_GET_TANMTA_TANCLAKB:
        GoTo END_F_Util_GET_TANMTA_TANCLAKB

    End Function
    '2009/09/03 ADD E.N.D RISE)MIYAJIMA

    '''' ADD 2010/07/21  FKS) T.Yamamoto    Start    �A���[��CF10042801
    '//***************************************************************************************
    '//*
    '//* <��  ��>
    '//*    CF_Ctr_AnsiLeftB
    '//*
    '//* <�߂�l>     �^          ����
    '//*              String      �ϊ���̕�����
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Value           String           I            �Ώە�����
    '//*              pm_Len             Long             I            ������̒���
    '//* <��  ��>
    '//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��č�����w��̒����̕�������擾���܂��B
    '//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String

        ' --------------+---------------+---------------+---------------+---------------
        Dim lngIdx As Integer
        Dim lngStep As Integer
        Dim bytWrk() As Byte
        Dim lngLength As Integer
        ' --------------+---------------+---------------+---------------+---------------

        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_TODO: System.Text.UnicodeEncoding.Unicode.GetBytes() ���g�����߂ɃR�[�h���A�b�v�O���[�h����܂������A���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"' ���N���b�N���Ă��������B
        '2019/04/18 CHG START
        'bytWrk = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pm_Value, vbFromUnicode))
        bytWrk = System.Text.UnicodeEncoding.Unicode.GetBytes(pm_Value)
        '2019/04/18 CHG E N D

        lngLength = 0

        lngIdx = LBound(bytWrk)
        Do While lngIdx <= UBound(bytWrk)
            If IsDBCSLeadByte(bytWrk(lngIdx)) = False Then
                lngStep = 1
            Else
                lngStep = 2
            End If
            lngIdx = lngIdx + lngStep
            If (lngLength + lngStep) > pm_Len Then
                Exit Do
            End If
            lngLength = lngLength + lngStep
        Loop

        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/18 CHG START
        'pm_Value = StrConv(MidB$(bytWrk, lngLength + 1), vbUnicode)
        pm_Value = MidB(pm_Value, lngLength + 1)
        '2019/04/18 CHG E N D
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/18 CHG START
        'CF_Ctr_AnsiLeftB = StrConv(LeftB$(bytWrk, lngLength), vbUnicode)
        CF_Ctr_AnsiLeftB = LeftB(pm_Value, lngLength)
        '2019/04/18 CHG E N D
        Exit Function

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Get_IniInf
    '   �T�v�F  Ini�t�@�C���Ǎ��ݏ����i�v���O�����ŗL�j
    '   �����F  pin_strSection :
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short

        Dim Wk As New VB6.FixedLengthString(256)
        Dim lngRet As Integer

        CF_Get_IniInf = 9

        pot_strValue = ""

        'Ini�t�@�C���Ǎ���
        lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
        If lngRet > 0 Then
            '2019/05/24 CHG START
            'pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
            pot_strValue = Mid(Wk.Value, 1, InStr(Wk.Value, vbNullChar) - 1)
            '2019/05/24 CHG E N D
            pot_strValue = Trim(pot_strValue)
        Else
            Exit Function
        End If

        CF_Get_IniInf = 0

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function funcGetIni
    '   �T�v�F INI�t�@�C���Ǎ�����
    '   �����F �Ȃ�
    '   �ߒl�F TRUE : ���� FALSE : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcGetIni() As Boolean

        Dim intRet As Short

        On Error GoTo Err_Run

        funcGetIni = False

        'INI�t�@�C���Ǎ���
        '�o�̓t�@�C����
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_OUTNAME, gv_strOUT_NAME)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '�o�̓t�@�C���g���q
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_OUTTYPE, gv_strOUT_TYPE)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '��؂蕶��
        intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_TABCHAR, gv_strTAB_CHAR)
        If intRet <> 0 Then
            GoTo Err_Run
        End If
        '���l�`�F�b�N
        If Not IsNumeric(gv_strTAB_CHAR) Then
            GoTo Err_Run
        End If
        gv_strTAB_CHAR = Chr(CInt(gv_strTAB_CHAR))

        funcGetIni = True

Exit_Run:

        Exit Function

Err_Run:

        GoTo Exit_Run

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function funcOutput
    '   �T�v�F  �t�@�C���o�͏����i�㏑���j
    '   �����F  pin_strOUT_PATH    : �o�̓t�@�C���p�X
    '           pin_strOUT_TXT     : �o�̓e�L�X�g
    '   �ߒl�F  TRUE : ���� FALSE : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutput(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_TXT As Object) As Boolean

        Dim intFNo As Short
        Dim bolOpen As Boolean

        On Error GoTo Err_Run

        funcOutput = False
        bolOpen = False

        intFNo = FreeFile()

        '�t�@�C���I�[�v��
        FileOpen(intFNo, Trim(pin_strOUT_PATH), OpenMode.Output)
        bolOpen = True

        PrintLine(intFNo, pin_strOUT_TXT)

        funcOutput = True

Err_Run:

        If bolOpen = True Then
            '�N���[�Y
            FileClose(intFNo)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function funcOutput_Append
    '   �T�v�F  �t�@�C���o�͏����i�ǋL�j
    '   �����F  pin_strOUT_PATH    : �o�̓t�@�C���p�X
    '           pin_strOUT_TXT     : �o�̓e�L�X�g
    '   �ߒl�F  TRUE : ���� FALSE : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutput_Append(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_TXT As Object) As Boolean

        Dim intFNo As Short
        Dim bolOpen As Boolean

        On Error GoTo Err_Run

        funcOutput_Append = False
        bolOpen = False

        intFNo = FreeFile()

        '�t�@�C���I�[�v��
        FileOpen(intFNo, Trim(pin_strOUT_PATH), OpenMode.Append)
        bolOpen = True

        PrintLine(intFNo, pin_strOUT_TXT)

        funcOutput_Append = True

Err_Run:

        If bolOpen = True Then
            '�N���[�Y
            FileClose(intFNo)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F Function funcOutPutCSV
    '   �T�v�F CSV�o�͏���
    '   �����F pin_strOUT_PATH   : CSV�o�͐�
    '   �ߒl�F TRUE : ���� FALSE : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function funcOutPutCSV(ByVal pin_strOUT_PATH As String) As Boolean

        Dim i As Short
        Dim count As Short
        Dim bolRet As Boolean
        Dim strTXT As String
        Dim tmp As Object
        Dim rowNo As Short

        On Error GoTo Err_Run

        funcOutPutCSV = False
        strTXT = ""

        '�w�b�_
        'PGID
        strTXT = strTXT & """" & SSS_PrgId & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '��\��
        'UPGRADE_WARNING: �I�u�W�F�N�g pnl_unydt.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strTXT = strTXT & """" & pnl_unydt.Text & "�o��"""
        strTXT = strTXT & vbCrLf

        '��������
        '���ږ�
        strTXT = strTXT & """������""" & gv_strTAB_CHAR & """������""" & gv_strTAB_CHAR & """�����於""" & gv_strTAB_CHAR & """�����"""
        strTXT = strTXT & vbCrLf

        '������
        strTXT = strTXT & """" & txt_kesidt.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '������
        strTXT = strTXT & """" & txt_tokseicd.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�����於
        strTXT = strTXT & """" & txt_tokseinma.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�����
        strTXT = strTXT & """" & Trim(txt_kaidt_From.Text) & "�`" & txt_kaidt_To.Text & """"
        strTXT = strTXT & vbCrLf

        '�t�@�C���֏o��
        If Not funcOutput(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If
        strTXT = ""

        '�������
        '�����o��
        strTXT = strTXT & """���������"""
        strTXT = strTXT & vbCrLf
        '���ږ�
        strTXT = strTXT & """���㍇�v""" & gv_strTAB_CHAR & """�����z""" & gv_strTAB_CHAR & """�萔��"""
        strTXT = strTXT & gv_strTAB_CHAR & """����ō��z""" & gv_strTAB_CHAR & """�������v""" & gv_strTAB_CHAR & """�����c�z"""
        strTXT = strTXT & vbCrLf
        '���㍇�v
        strTXT = strTXT & """" & txt_urigoukei.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�����z
        strTXT = strTXT & """" & txt_nyukin.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�萔��
        strTXT = strTXT & """" & txt_tesuryo.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '����ō��z
        strTXT = strTXT & """" & txt_syohi.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�������v
        strTXT = strTXT & """" & txt_nyugoukei.Text & """"
        strTXT = strTXT & gv_strTAB_CHAR
        '�����c�z
        strTXT = strTXT & """" & txt_kesizan.Text & """"
        strTXT = strTXT & vbCrLf
        '�t�@�C���֏o��
        If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If
        strTXT = ""

        '����
        '���ږ�
        strTXT = strTXT & """����""" & gv_strTAB_CHAR & """��""" & gv_strTAB_CHAR & """���[""" & gv_strTAB_CHAR & """�����"""
        strTXT = strTXT & gv_strTAB_CHAR & """�󒍔ԍ�""" & gv_strTAB_CHAR & """����\���""" & gv_strTAB_CHAR & """�q�撍���ԍ�"""
        strTXT = strTXT & gv_strTAB_CHAR & """�c�ƒS����""" & gv_strTAB_CHAR & """�Ŕ�������z""" & gv_strTAB_CHAR & """����Ŋz"""
        strTXT = strTXT & gv_strTAB_CHAR & """�ō�������z""" & gv_strTAB_CHAR & """�����ϊz""" & gv_strTAB_CHAR & """�U������"""
        strTXT = strTXT & vbCrLf
        '100�s�𒴂�����t�@�C���o��
        count = 1
        With spd_body
            'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/23 CHG START
            'For i = 1 To .MaxRows
            For i = 0 To .RowCount - 1
                '2019/04/23 CHG E N D 
                '��
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_NO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_NO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    rowNo = SSSVal(tmp)
                Else
                    Exit For
                End If

                '����
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_CHK, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_CHK)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                Else
                    strTXT = strTXT & """0"""
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '��
                strTXT = strTXT & """" & rowNo & """"
                strTXT = strTXT & gv_strTAB_CHAR
                '���[
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_NXTKB, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_NO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�����
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYUDNDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYUDNDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�󒍔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYJDNNO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYJDNNO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '����\���
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYKAIDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYKAIDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�q�撍���ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_TOKJDNNO, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_TOKJDNNO)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�c�ƒS����
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_TANNM, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_TANNM)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�Ŕ�������z
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

                '2019/04/23 CHG START
                'bolRet = .GetText(COL_URIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_URIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '����Ŋz
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_UZEKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_UZEKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�ō�������z
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_KOMIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_KOMIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�����ϊz
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_KESIKN, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_KESIKN)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & VB6.Format(tmp, "###,###,##0") & """"
                End If
                strTXT = strTXT & gv_strTAB_CHAR
                '�U������
                'UPGRADE_WARNING: �I�u�W�F�N�g spd_body.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/23 CHG START
                'bolRet = .GetText(COL_HYFRIDT, i, tmp)
                'If bolRet = True Then
                tmp = .GetValue(i, COL_HYFRIDT)
                If Trim(tmp.ToString) <> "" Then
                    '2019/04/23 CHG E N D
                    'UPGRADE_WARNING: �I�u�W�F�N�g tmp �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strTXT = strTXT & """" & tmp & """"
                End If

                If count >= 100 Then
                    '�t�@�C���֏o��
                    If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
                        GoTo Err_Run
                    End If

                    strTXT = ""
                    count = 0
                Else
                    strTXT = strTXT & vbCrLf
                End If

                count = count + 1
            Next i
        End With

        '�t�@�C���֏o��
        If Not funcOutput_Append(pin_strOUT_PATH, strTXT) Then
            GoTo Err_Run
        End If

        funcOutPutCSV = True

Exit_Run:

        Exit Function

Err_Run:

        GoTo Exit_Run

    End Function
    '''' ADD 2010/07/21  FKS) T.Yamamoto    End

    '2018/10/26 ADD START <C2-20181002-01> CIS)�R��
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function F_GET_EIGYO_DAY
    '   �T�v�F  ��s�c�Ɠ����擾
    '   �����F�@strHYFRIDT       : ���ׁD�U������
    '   �ߒl�F�@1 : ���� 9 : �ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_GET_EIGYO_DAY(ByVal strHYFRIDT As String) As Short

        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo ERR_F_GET_EIGYO_DAY

        F_GET_EIGYO_DAY = 9

        '�J�����_�l
        strSql = ""
        strSql = strSql & " SELECT BNKKDKB "
        strSql = strSql & " FROM CLDMTA "
        strSql = strSql & " WHERE DATKB = '1' "
        strSql = strSql & " AND     CLDDT = '" & Replace(strHYFRIDT, "/", "") & "' "

        'DB�A�N�Z�X
        '2019/04/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody, BNKKDKB, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") = "1" Then

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            If DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") = "1" Then
                '2019/04/18 CHG E N D
                F_GET_EIGYO_DAY = 1
            End If
        Else
            F_GET_EIGYO_DAY = 8
        End If

END_F_GET_EIGYO_DAY:
        '�N���[�Y
        '2019/04/18 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/18 DEL E N D
        Exit Function

ERR_F_GET_EIGYO_DAY:
        GoTo END_F_GET_EIGYO_DAY

    End Function

    '2018/10/26 ADD END <C2-20181002-01> CIS)�R��

    '���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������

    '2019/04/25 ADD START
    '�X�V�{�^��
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mnu_regist_Click(Button1, New System.EventArgs())
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        mnu_showwnd_Click(Button5, New System.EventArgs())
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim li_MsgRtn As Integer

        Try
            'change 20190809 START hou
            'img_unlock_Click(Button9, New System.EventArgs())
            initForm()
            initCondition()
            initHead()
            initBody()
            intInputMode = 1
            'change 20190809 END hou
        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    '�I���{�^��
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim li_MsgRtn As Integer

        Try
            Me.Close()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʏI���G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    Private Sub cmd_kesidt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kesidt.Click
        cmd_kesidt_Click()
    End Sub

    Private Sub cmd_tokseicd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tokseicd.Click
        cmd_tokseicd_Click()
    End Sub

    Private Sub cmd_kaidt_From_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kaidt_From.Click
        cmd_kaidt_From_Click()
    End Sub

    Private Sub cmd_kaidt_To_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_kaidt_To.Click
        cmd_kaidt_To_Click()
    End Sub

    Private Sub cmd_fridt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_fridt.Click
        cmd_fridt_Click()
    End Sub

    Private Sub cmd_tesuryo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tesuryo.Click
        cmd_tesuryo_Click()
    End Sub

    Private Sub cmd_syohi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_syohi.Click
        cmd_syohi_Click()
    End Sub

    Private Sub cmd_zenkaijo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_zenkaijo.Click
        cmd_zenkaijo_Click()
    End Sub

    Private Sub cmd_zenkesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_zenkesi.Click
        cmd_zenkesi_Click()
    End Sub

    Private Sub cmd_saihyoji_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_saihyoji.Click
        cmd_saihyoji_Click()
    End Sub

    Private Sub cmd_csvout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_csvout.Click
        cmd_csvout_Click()
    End Sub

    Private Sub spd_body_Enter(sender As Object, e As EventArgs) Handles spd_body.Enter
        spd_body_GotFocus()
    End Sub

    Private Sub FR_SSSMAIN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub FKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.Button1.PerformClick()

                Case Keys.F5
                    Me.Button5.PerformClick()

                Case Keys.F9
                    Me.Button9.PerformClick()

                Case Keys.F12
                    Me.Button12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    Private Sub spd_body_CellClick(sender As Object, e As GrapeCity.Win.MultiRow.CellEventArgs) Handles spd_body.CellClick

        Select Case e.CellIndex
            Case COL_CHK
                If spd_body.GetValue(e.RowIndex, e.CellIndex) = False Then
                    spd_body_ButtonClicked(e.CellIndex, e.RowIndex, 1)
                Else
                    spd_body_ButtonClicked(e.CellIndex, e.RowIndex, 0)
                End If

        End Select
    End Sub

    Private Sub spd_body_CellValidated(sender As Object, e As GrapeCity.Win.MultiRow.CellEventArgs) Handles spd_body.CellValidated

        Dim InData As String = StrConv(Trim(spd_body.GetValue(e.RowIndex, e.CellIndex)), VbStrConv.Narrow).Replace(",", "")
        Select Case e.CellIndex
            Case COL_KESIKN
                If InData = "" OrElse IsNumeric(InData) = False Then
                    spd_body.SetValue(e.RowIndex, e.CellIndex, 0)
                Else
                    spd_body.SetValue(e.RowIndex, e.CellIndex, String.Format("{0:#,0}", Integer.Parse(InData)))
                End If
        End Select
    End Sub

    Private Sub spd_body_CellEndEdit(sender As Object, e As GrapeCity.Win.MultiRow.CellEndEditEventArgs) Handles spd_body.CellEndEdit

        With spd_body
            Select Case e.CellIndex
                Case COL_HYFRIDT
                    '���t�ϊ�����
                    Dim a As String = CNV_DATE(.GetValue(e.RowIndex, e.CellIndex))
                    .SetValue(e.RowIndex, e.CellIndex, a)
            End Select
        End With

    End Sub
    '2019/04/25 ADD E N D

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        '==========================================================================
        '   �֐�:CSV�o�̓{�^������������
        '   �T�v:���ד��eCSV�o�͏���
        '
        '   �쐬�E�X�V      �S����      �ύX���e
        '   2019/06/07      FJ)����     �V�K�쐬
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBox�̖߂�l
        Dim lb_Ret As Boolean       '�֐��̖߂�l

        '--------------------------------------------------------------------------
        '�G���[�g���b�v�錾
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '�����J�n
            '--------------------------------------------------------------------------
            '�m�F���b�Z�[�W�iCSV�o�͂��s���܂��B��낵���ł����H�j
            If showMsg("1", "URKET53_045", "0") = MsgBoxResult.Yes Then

                'CSV�o��
                lb_Ret = M0_OutCSV()
                If lb_Ret = False Then
                    '�t�H�[�J�X�̃Z�b�g
                    Me.spd_body.Focus()
                    Exit Sub
                End If

                '�t�H�[�J�X�̃Z�b�g
                Me.spd_body.Focus()

            End If

            '--------------------------------------------------------------------------
            '�G���[�g���b�v���[�`��
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV�o�͏����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    Private Function M0_OutCSV() As Boolean
        '==========================================================================
        '   �֐�:CSV�o�͏���
        '   �T�v:���ד��e��CSV�t�@�C���ɏo�͂���
        '
        '   IO  ����            �l          ���e
        '    �Ȃ�
        '
        '   �߂�l              �l          ���e
        '                       True        ����I��
        '                       False       �ُ�I��
        '
        '   �쐬�E�X�V      �S����      �ύX���e
        '   2019/06/07      FJ)����     �V�K�쐬
        '
        '==========================================================================
        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer        'MsgBox�̖߂�l
        Dim lb_Ret As Boolean           '�֐��̖߂�l
        Dim lt_CSVCell() As pst_CSVCell 'CSV�Ώ۾ٔz��
        Dim ls_HedNm As String          'ͯ�ޕ�����

        '--------------------------------------------------------------------------
        '�G���[�g���b�v�錾
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '�����J�n
            '--------------------------------------------------------------------------
            '�߂�l�̐ݒ�
            M0_OutCSV = False

            '�����v�ݒ�
            Me.Cursor = Cursors.WaitCursor

            'CSV�Ώ۾ٔz��쐬
            ReDim lt_CSVCell(11)
            ls_HedNm = ""
            ls_HedNm = ls_HedNm & "No."
            lt_CSVCell(0).pss_Key = "GcNumberCell1"
            lt_CSVCell(0).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""���["
            lt_CSVCell(1).pss_Key = "GcNumberCell2"
            lt_CSVCell(1).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�����"
            lt_CSVCell(2).pss_Key = "GcTextBoxCell4"
            lt_CSVCell(2).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�󒍔ԍ�"
            lt_CSVCell(3).pss_Key = "GcTextBoxCell1"
            lt_CSVCell(3).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""����\���"
            lt_CSVCell(4).pss_Key = "GcTextBoxCell5"
            lt_CSVCell(4).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�q�撍���ԍ�"
            lt_CSVCell(5).pss_Key = "GcTextBoxCell2"
            lt_CSVCell(5).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�c�ƒS����"
            lt_CSVCell(6).pss_Key = "GcTextBoxCell3"
            lt_CSVCell(6).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�Ŕ�������z"
            lt_CSVCell(7).pss_Key = "GcTextBoxCell26"
            lt_CSVCell(7).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""����Ŋz"
            lt_CSVCell(8).pss_Key = "GcTextBoxCell27"
            lt_CSVCell(8).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�ō�������z"
            lt_CSVCell(9).pss_Key = "GcTextBoxCell28"
            lt_CSVCell(9).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�����ϊz"
            lt_CSVCell(10).pss_Key = "GcTextBoxCell29"
            lt_CSVCell(10).pss_Type = CGS_TYPE_TEXT
            ls_HedNm = ls_HedNm & """,""�U������"
            lt_CSVCell(11).pss_Key = "GcTextBoxCell6"
            lt_CSVCell(11).pss_Type = CGS_TYPE_TEXT

            '------------------------------
            ' CSV�o�͊֐�
            '------------------------------
            lb_Ret = COM_CSV_OUTPUT_LIST(Me.Name, lt_CSVCell, "", True, "", Me.spd_body, ls_HedNm)
            If lb_Ret = False Then
                Exit Function
            End If

            '---�߂�l�̐ݒ�---'
            M0_OutCSV = True

            '--------------------------------------------------------------------------
            '�G���[�g���b�v���[�`��
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("CSV�o�͊֐��G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        Finally
            '�����v�ݒ�
            Me.Cursor = Cursors.Default
        End Try

    End Function

End Class