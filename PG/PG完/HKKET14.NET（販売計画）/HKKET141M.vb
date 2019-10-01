Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D
'2019/04/02 ADD START
Imports Oracle.DataAccess.Client
'2019/04/02 ADD E N D
Module HKKET141M
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    HKKET14M.BAS
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    Rise
	'//*��������
	'//*    �̔��v����� ���W���[��
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|Rise)          |�V�K
	'//*          |        |Rise)          |����
	'//*          |20070727|Rise)          |��ʐ����A��݌ɕi���o�ΏۊO
	'//*          |20070730|Rise)          |���i�Q���o�ł̃G���[����
	'//*          |20071218|Rise)          |�A�h�o�C�X�v�Z���@�ύX
	'//*          |20071220|Rise)          |�k�s������񓚔[��or�����P���������P���Œ�
	'//*          |20081117|Rise)          |���s�L�[�ϊ��{�o�e�L�[�ŃJ�[�\���ړ��ǉ�
	'//* 2.01     |20081118|Rise)          |Alt+PF4�Ή�
	'//* 2.02     |20081203|Rise)          |�������E���̕\�����@�̕ύX
	'//* 2.31     |20090106|Rise)          |���̎Z�o���@�̕ύX
	'//*****************************************************************************************
	'//*****************************************************************************************
	'// �v���O�������
	'//*****************************************************************************************
	'//�W���u�h�c�E�W���u����
	Public Const gvcstJOB_ID As String = "HKKET14"
	Public Const gvcstJOB_Titl As String = "�̔��v�����"
	
	'//*****************************************************************************************
	'// �C���X�^���X��`
	'//*****************************************************************************************
	'UPGRADE_ISSUE: ClsComn �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public D0 As ClsComn '//System �֐�
	'UPGRADE_ISSUE: ClsFocusCtrl �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public ClsFocus As ClsFocusCtrl '//Set Enter
	'UPGRADE_ISSUE: ClsMessage �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public ClsMessage As ClsMessage '//Message
	'UPGRADE_ISSUE: ClsOraDB �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    Public clsOra As ClsOraDB

	'//*****************************************************************************************
	'// �ϐ���`
	'//*****************************************************************************************
	'UPGRADE_ISSUE: gvtypIniFile �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Public gvINIInformation As gvtypIniFile '//�h�m�h�t�@�C���\����
	
	'//*****************************************************************************************
	'// �萔�@�@��`
	'//*****************************************************************************************
	Public Const gvcstPRCCL As Integer = 10
	
	'//*****************************************************************************************
	'// �o�f�ʕϐ���`
	'//*****************************************************************************************
	'// 2007/02/17 �� ADD STR
	Public gvintPGHaita As Short '//�v���O�����N���r���t���O
	'// 2007/02/17 �� ADD STR
	
	Public gvintInputCls As Short '//���݂̓��̓��[�h
	Public gvblnInputFlg As Boolean '//
	Public gvintInputRow As Short '//���݂̓��͍s
	Public gvstrUNYDT As String '//���t�Ǘ�TBL.�^�p���t
	Public gvstrTERMNO As String '//���t�Ǘ�TBL.��
	Public gvstrACCYY As String '//���t�Ǘ�TBL.��v�N�x
    '2019/04/19 CHG START
    'Public gvobjdyn As Object
    Public gvobjdyn As DataTable = Nothing
    '2019/04/19 CHG E N D
    Public gvstrDspItemNM As String '//�\�������ږ�
	Public gvstrDspItemAD As String '//�\�������ږ�(A:�����CD:�~��)
	Public gvstrDisplayID As String '//���݂̉��ID
	Public gvstrFilePath1 As String '//�t�@�C���p�X
	Public gvstrFileName1 As String '//�t�@�C����
	Public gvstrFilePath2 As String '//�t�@�C���p�X
	Public gvstrFileName2 As String '//�t�@�C����
	Public gvstrFilePath3 As String '//�t�@�C���p�X
	Public gvstrFileName3 As String '//�t�@�C����
	Public gvstrFilePath4 As String '//�t�@�C���p�X
	Public gvstrFileName4 As String '//�t�@�C����
	Public gvstrFilePath5 As String '//�t�@�C���p�X
	Public gvstrFileName5 As String '//�t�@�C����
	Public gvstrFilePath6 As String '//�t�@�C���p�X
	Public gvstrFileName6 As String '//�t�@�C����
	'// V2.30�� ADD
	Public gvstrFilePath7 As String '//�t�@�C���p�X(���̓��O�e�L�X�g�t�@�C��)
	Public gvstrFileName7 As String '//�t�@�C����  (���̓��O�e�L�X�g�t�@�C��)
	'// V2.30�� ADD
	
	Public Structure mtypHKKZTR '//�ޔ����
		Dim strHINCD() As String '//���i����
	End Structure
	'UPGRADE_WARNING: �\���� musrHKKZTR �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public musrHKKZTR As mtypHKKZTR
	'// 2007/02/24 �� ADD STR
	Public gvvntLeft As Object '//��ʍ��ʒu
	Public gvvntTop As Object '//��ʏ�ʒu
    '// 2007/02/24 �� ADD STR

    '2019/04/16 ADD START
    'SortOrder
    Private LvSortOrder As SortOrder
    '2019/04/16 ADD E N D

    '2019/04/24 ADD START
    Private InitSortColumn As Integer
    '2019/04/24 ADD E N D

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Main
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�                  I/O           ���e
    '//*
    '//* <��  ��>
    '//*    �V�X�e���N�����̎��s�v���V�W���[
    '//*****************************************************************************************
    'UPGRADE_WARNING: Sub Main() �����������Ƃ��ɃA�v���P�[�V�����͏I�����܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"' ���N���b�N���Ă��������B
    Public Sub Main()
        '2019/04/11 DEL START
        'Dim ChkHTATRA As Object
        'Dim Get_Authority As Object
        'Dim gs_pgid As Object
        'Dim gs_userid As Object
        'Dim gvstrOPEID As Object 
        'Dim SSSWIN_LOGWRT As Object
        'Dim GetIniFile As Object
        'Dim Get_CommandLine As Object
        '2019/04/11 DEL E N D

        On Error GoTo ONERR_STEP

        '//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
        If Not Ctr_Object(True) Then
            GoTo EXIT_STEP
        End If

        '//�v���O�����Q�d�N���`�F�b�N
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.ChkDuplicateInstance �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Not D0.ChkDuplicateInstance(gvcstJOB_Titl) Then
            MsgBox("�y" & Trim(gvcstJOB_Titl) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, gvcstJOB_Titl)
            AppActivate(gvcstJOB_Titl)
            GoTo EXIT_STEP
        End If

        '//�p�����[�^�̎擾
        If Not Get_CommandLine() Then
            GoTo EXIT_STEP
        End If

        '//�h�m�h�t�@�C���̎擾(����)
        If Not GetIniFile(gvINIInformation) Then
            GoTo EXIT_STEP
        End If
        '// ����������������������������������������
        '// 2008/01/24 START
        Call SSSWIN_LOGWRT("�v���O�����N��")
        '// 2008/01/24 END
        '// ����������������������������������������
        '//�h�m�h�t�@�C���̎擾(��)
        If Not Get_IndividualIniFile() Then
            GoTo EXIT_STEP
        End If

        '//�f�[�^�x�[�X�ڑ�(ORACLE���ް)
        '2019/04/12 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLPWD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLUID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g gvINIInformation.strSQLDATABASE �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraConnect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If Not clsOra.OraConnect(gvINIInformation.strSQLDATABASE, gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD) Then
        '    GoTo EXIT_STEP
        'End If
        CON = DB_START_FOR_HKK(gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD, gvINIInformation.strSQLDATABASE)
        '2019/04/12 CHG E N D

        '//���b�Z�[�W�N���X��OraDatabase�v���p�e�B���Z�b�g����
        '2019/04/12 DEL START
        ''UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'ClsMessage.OraDatabase = clsOra.OraDatabase
        '2019/04/12 DEL E N D

        '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
        '//���t�Ǘ��擾
        Call Get_HidukeKanri(gvstrUNYDT)

        '�����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g gvstrOPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gs_userid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gs_userid = gvstrOPEID
        'UPGRADE_WARNING: �I�u�W�F�N�g gs_pgid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gs_pgid = gvcstJOB_ID
        'UPGRADE_WARNING: �I�u�W�F�N�g Get_Authority(gvstrUNYDT) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Get_Authority(gvstrUNYDT) = "9" Then
            '�N�������Ȃ��̏ꍇ�A�����I��
            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & "RUNAUTH")
            '//�I������
            Call Ctr_END()
        End If
        '''' ADD 2009/11/26  FKS) T.Yamamoto    End

        '//�N���۔���

        '// 2007/02/17 �� UPD STR
        '    '//V1.10 2006/09/20  CHG START  RISE)
        '    'If ChkHTATRA(gvstrOPEID, "1", "HKKET141", "HKKET01") = 9 Then
        '    If ChkHTATRA(gvstrOPEID, "1", gvcstJOB_ID, gvcstJOB_ID, "HKKET01") = 9 Then
        '    '//V1.10 2006/09/20  CHG E N D  RISE)
        '        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & "HKKET01_005"
        '        '//�I������
        '        Call Ctr_END
        '    End If

        'UPGRADE_WARNING: �I�u�W�F�N�g ChkHTATRA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvintPGHaita = ChkHTATRA(gvstrOPEID, "1", gvcstJOB_ID, gvcstJOB_ID, "HKKET01")
        '// 2007/02/17 �� UPD STR

        If Not Get_UNYMTA() Then
            '//�I������
            Call Ctr_END()
        End If

        '//��ʕ\��
        '2019/04/12 CHG START
        'HKKET141F.Show()
        HKKET141F.ShowDialog()
        '2019/04/12 CHG E N D

        Exit Sub
        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//���ʃI�u�W�F�N�g�̉��
        Call Ctr_Object(False)

        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        MsgBox("<Sub_Main> " & vbCrLf & "���s���G���[�ł��B�����𒆎~���܂��B" & vbCrLf & Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Ctr_Object
    '//*
    '//* <�߂�l>     �^          ����
    '//*              Boolean     True    :�ݒ�ł���
    '//*                          False   :�ݒ�ł��Ȃ�����
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pmf_Set          Boolean          I             True:�쐬 False:���
    '//* <��  ��>
    '//*    �I�u�W�F�N�g�C���X�^���X�̍쐬�^���
    '//*****************************************************************************************
    Function Ctr_Object(ByRef pmf_Set As Boolean) As Boolean

        Const PROCEDURE As String = "Ctr_Object"

        On Error GoTo ONERR_STEP

        Ctr_Object = False

        If pmf_Set Then
            '//���ʃI�u�W�F�N�g�̃C���X�^���X�쐬
            D0 = New ClsComn '//���ʸ׽
            '2019/04/11 DEL START
            'clsOra = New ClsOraDB '//Oracle
            '2019/04/11 DEL E N D
            ClsMessage = New ClsMessage '//Message
            ClsFocus = New ClsFocusCtrl '//Set Enter
        Else
            '//���ʃI�u�W�F�N�g�̃C���X�^���X���clsAKNITRA
            If Not (ClsFocus Is Nothing) Then '//Set Enter
                'UPGRADE_NOTE: �I�u�W�F�N�g ClsFocus ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                ClsFocus = Nothing
            End If
            If Not (ClsMessage Is Nothing) Then '//Message
                'UPGRADE_NOTE: �I�u�W�F�N�g ClsMessage ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                ClsMessage = Nothing
            End If
            '2019/04/19 DEL START
            'If Not (clsOra Is Nothing) Then '//Oracle
            '    'UPGRADE_NOTE: �I�u�W�F�N�g clsOra ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            '    clsOra = Nothing
            'End If
            '2019/04/19 DEL E N D
            If Not (D0 Is Nothing) Then '//���ʸ׽
                'UPGRADE_NOTE: �I�u�W�F�N�g D0 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                D0 = Nothing
            End If
        End If

        Ctr_Object = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_UNYMTA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �^�p�Ǘ����擾����
    '//*****************************************************************************************
    Public Function Get_UNYMTA() As Boolean

        Const PROCEDURE As String = "Get_UNYMTA"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset
        Dim i As Short

        Get_UNYMTA = False

        On Error GoTo ONERR_STEP

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   UNYMTA " & vbCrLf

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'gvstrUNYDT = D0.Chk_Null(objRec("UNYDT"))
            gvstrUNYDT = D0.Chk_Null(dt.Rows(0)("UNYDT"))
            '2019/04/12 CHG E N D
            '// V2.31�� UPD
            '        gvstrTERMNO = D0.Chk_Null(objRec("TERMNO"))
            If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
                gvstrTERMNO = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1975)
            Else
                gvstrTERMNO = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1974)
            End If
            '// V2.31�� UPD
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'gvstrACCYY = D0.Chk_Null(objRec("ACCYY"))
            gvstrACCYY = D0.Chk_Null(dt.Rows(0)("ACCYY"))
            '2019/04/12 CHG E N D
            '2008/06/14 ADD START
            If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
                gvstrACCYY = CStr(CDbl(Mid(gvstrUNYDT, 1, 4)) - 1)
            Else
                gvstrACCYY = Mid(gvstrUNYDT, 1, 4)
            End If
            '2008/06/14 ADD E N D
        End If


        Get_UNYMTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_Initialize
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�                  I/O           ���e
    '//*
    '//* <��  ��>
    '//*    ��������
    '//*****************************************************************************************
    Function Set_Initialize() As Boolean
        '2019/04/11 DEL START
        'Dim SetLvFormat As Object
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_Initialize"
        Set_Initialize = False

        On Error GoTo ONERR_STEP

        '// �e�n�q�l�L���v�V�����Z�b�g
        'HKKET141F.Caption = gvcstJOB_Titl

        '//�e�n�q�l�����Z�b�g
        Call SetFormInitOrg(HKKET141F, 1)

        '// ��ʃN���A�[
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.ModeAll �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call HKKET141M.Clr_Display(gvcstInputCls.ModeAll)

        '// �������̓��[�h
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Header1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvintInputCls = gvcstInputCls.Header1

        '//���ړ��͐���ݒ�
        Call HKKET141M.Set_InputControl(gvintInputCls)

        '//�\�����Ǘ��擾
        '2019/04/16 CHG START
        'Call SetLvFormat("E01", HKKET141F.lvwMEISAI)
        Call SetLvFormat("E01", HKKET141F.lvwMEISAI, LvSortOrder, InitSortColumn)
        '2019/04/16 CHG E N D

        '//�S���Ҍ����ɂ���ʐ���
        Call Set_TantoControl(HKKET141F)

        '//�S���Ҍ����ɂ���ʐ���
        Call SetDspFormat()

        Set_Initialize = True

        '--------------------------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '--------------------------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    SetDspFormat
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    ��ʕ\��������ʕ\������
    '//*****************************************************************************************
    Public Function SetDspFormat() As Boolean
        '2019/04/11 DEL START
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "SetDspFormat"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/12 DEL START
        'Dim objRec As OraDynaset
        '2019/04/12 DEL E N D
        Dim i As Short

        SetDspFormat = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_ON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_ON()

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT *               " & vbCrLf
        strSQL = strSQL & "FROM   HKKDTRA          " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  PRCCL  = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "AND    TANCD  = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'ں��޾�Ċl��
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        ''If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            '2019/04/12 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optCARRIES_ON.Checked = IIf(objRec("SELWRG").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optCARRIES_OFF.Checked = IIf(objRec("SELWRG").Value = "0", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optSAFTY_STOCK.Checked = IIf(objRec("SELAZK").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtSAFTY_STOCK.Text = D0.Chk_NullN(objRec("AZKMNT").Value)
            'If HKKET141F.optSAFTY_STOCK.Checked Then
            '    HKKET141F.txtSAFTY_STOCK.Enabled = True
            'Else
            '    HKKET141F.txtSAFTY_STOCK.Enabled = False
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optSTOCK.Checked = IIf(objRec("SELZK").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtSTOCK.Text = D0.Chk_NullN(objRec("ZKMNT").Value)
            'If HKKET141F.optSTOCK.Checked Then
            '    HKKET141F.txtSTOCK.Enabled = True
            'Else
            '    HKKET141F.txtSTOCK.Enabled = False
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optSTOCK_MONTH.Checked = IIf(objRec("SELZMNT").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtSTOCK_MONTH.Text = D0.Chk_NullN(objRec("ZMNT").Value)
            'If HKKET141F.optSTOCK_MONTH.Checked Then
            '    HKKET141F.txtSTOCK_MONTH.Enabled = True
            'Else
            '    HKKET141F.txtSTOCK_MONTH.Enabled = False
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optORDER_OMISSION.Checked = IIf(objRec("SELORD").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtORDER_OMISSION.Text = D0.Chk_NullN(objRec("ORDDT").Value)

            'If HKKET141F.optORDER_OMISSION.Checked Then
            '    HKKET141F.txtORDER_OMISSION.Enabled = True
            'Else
            '    HKKET141F.txtORDER_OMISSION.Enabled = False
            'End If

            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINCD.Text = D0.Chk_Null(objRec("HINCD").Value)

            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(0).Text = D0.Chk_Null(objRec("HINGRP1").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(1).Text = D0.Chk_Null(objRec("HINGRP2").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(2).Text = D0.Chk_Null(objRec("HINGRP3").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(3).Text = D0.Chk_Null(objRec("HINGRP4").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(4).Text = D0.Chk_Null(objRec("HINGRP5").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINGRP(5).Text = D0.Chk_Null(objRec("HINGRP6").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtHINNMA.Text = D0.Chk_Null(objRec("HINKTA").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(0).Text = D0.Chk_Null(objRec("ZAIRNK1").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(1).Text = D0.Chk_Null(objRec("ZAIRNK2").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(2).Text = D0.Chk_Null(objRec("ZAIRNK3").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(3).Text = D0.Chk_Null(objRec("ZAIRNK4").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(4).Text = D0.Chk_Null(objRec("ZAIRNK5").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(5).Text = D0.Chk_Null(objRec("ZAIRNK6").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(6).Text = D0.Chk_Null(objRec("ZAIRNK7").Value)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtZAIRNK(7).Text = D0.Chk_Null(objRec("ZAIRNK8").Value)
            ''//V1.10 2006/10/15  ADD START  RISE)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.txtMNFDD.Text = D0.Chk_Null(objRec("MNFDD").Value)
            ''//V1.10 2006/10/15  ADD E N D  RISE)

            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optORDER_ON.Checked = IIf(objRec("SELJYM").Value = "1", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optORDER_OFF.Checked = IIf(objRec("SELJYM").Value = "0", True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'HKKET141F.optONLY.Checked = IIf(objRec("SELGRP").Value = 1, True, False)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

            HKKET141F.optCARRIES_ON.Checked = IIf(dt.Rows(0)("SELWRG") = "1", True, False)
            HKKET141F.optCARRIES_OFF.Checked = IIf(dt.Rows(0)("SELWRG") = "0", True, False)
            HKKET141F.optSAFTY_STOCK.Checked = IIf(dt.Rows(0)("SELAZK") = "1", True, False)
            HKKET141F.txtSAFTY_STOCK.Text = D0.Chk_NullN(dt.Rows(0)("AZKMNT"))
            If HKKET141F.optSAFTY_STOCK.Checked Then
                HKKET141F.txtSAFTY_STOCK.Enabled = True
            Else
                HKKET141F.txtSAFTY_STOCK.Enabled = False
            End If
            HKKET141F.optSTOCK.Checked = IIf(dt.Rows(0)("SELZK") = "1", True, False)
            HKKET141F.txtSTOCK.Text = D0.Chk_NullN(dt.Rows(0)("ZKMNT"))
            If HKKET141F.optSTOCK.Checked Then
                HKKET141F.txtSTOCK.Enabled = True
            Else
                HKKET141F.txtSTOCK.Enabled = False
            End If
            HKKET141F.optSTOCK_MONTH.Checked = IIf(dt.Rows(0)("SELZMNT") = "1", True, False)
            HKKET141F.txtSTOCK_MONTH.Text = D0.Chk_NullN(dt.Rows(0)("ZMNT"))
            If HKKET141F.optSTOCK_MONTH.Checked Then
                HKKET141F.txtSTOCK_MONTH.Enabled = True
            Else
                HKKET141F.txtSTOCK_MONTH.Enabled = False
            End If
            HKKET141F.optORDER_OMISSION.Checked = IIf(dt.Rows(0)("SELORD") = "1", True, False)
            HKKET141F.txtORDER_OMISSION.Text = D0.Chk_NullN(dt.Rows(0)("ORDDT"))

            If HKKET141F.optORDER_OMISSION.Checked Then
                HKKET141F.txtORDER_OMISSION.Enabled = True
            Else
                HKKET141F.txtORDER_OMISSION.Enabled = False
            End If
            HKKET141F.txtHINCD.Text = D0.Chk_Null(dt.Rows(0)("HINCD"))
            HKKET141F.txtHINGRP(0).Text = D0.Chk_Null(dt.Rows(0)("HINGRP1"))
            HKKET141F.txtHINGRP(1).Text = D0.Chk_Null(dt.Rows(0)("HINGRP2"))
            HKKET141F.txtHINGRP(2).Text = D0.Chk_Null(dt.Rows(0)("HINGRP3"))
            HKKET141F.txtHINGRP(3).Text = D0.Chk_Null(dt.Rows(0)("HINGRP4"))
            HKKET141F.txtHINGRP(4).Text = D0.Chk_Null(dt.Rows(0)("HINGRP5"))
            HKKET141F.txtHINGRP(5).Text = D0.Chk_Null(dt.Rows(0)("HINGRP6"))
            HKKET141F.txtHINNMA.Text = D0.Chk_Null(dt.Rows(0)("HINKTA"))
            HKKET141F.txtZAIRNK(0).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK1"))
            HKKET141F.txtZAIRNK(1).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK2"))
            HKKET141F.txtZAIRNK(2).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK3"))
            HKKET141F.txtZAIRNK(3).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK4"))
            HKKET141F.txtZAIRNK(4).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK5"))
            HKKET141F.txtZAIRNK(5).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK6"))
            HKKET141F.txtZAIRNK(6).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK7"))
            HKKET141F.txtZAIRNK(7).Text = D0.Chk_Null(dt.Rows(0)("ZAIRNK8"))
            HKKET141F.txtMNFDD.Text = D0.Chk_Null(dt.Rows(0)("MNFDD"))
            HKKET141F.optORDER_ON.Checked = IIf(dt.Rows(0)("SELJYM") = "1", True, False)
            HKKET141F.optORDER_OFF.Checked = IIf(dt.Rows(0)("SELJYM") = "0", True, False)
            HKKET141F.optONLY.Checked = IIf(dt.Rows(0)("SELGRP") = 1, True, False)
            HKKET141F.optVERSION.Checked = IIf(dt.Rows(0)("SELVER") = 1, True, False)
            '2019/04/12 CHG E N D
        End If

        SetDspFormat = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_OFF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/19 CHG START
        'clsOra.OraRollback()
        Call DB_Rollback()
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    SavDspFormat
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    ��ʕ\�������X�V����
    '//*****************************************************************************************
    Public Function SavDspFormat() As Boolean
        '2019/04/11 DEL START
        'Dim gvstrCLTID As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "SavDspFormat"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset
        Dim i As Short

        SavDspFormat = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_ON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_ON()

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT *               " & vbCrLf
        strSQL = strSQL & "FROM   HKKDTRA          " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  PRCCL  = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "AND    TANCD  = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'ں��޾�Ċl��
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        '//��ݻ޸��ݐ���J�n
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            strSQL = ""
            strSQL = strSQL & "UPDATE HKKDTRA                       " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "SET    SELWRG    = " & D0.Edt_SQL("N", IIf(HKKET141F.optCARRIES_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELAZK    = " & D0.Edt_SQL("N", IIf(HKKET141F.optSAFTY_STOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      AZKMNT    = " & D0.Edt_SQL("N", IIf(CBool(Trim(CStr(HKKET141F.txtSAFTY_STOCK.Text = ""))), 0, HKKET141F.txtSAFTY_STOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELZK     = " & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZKMNT     = " & D0.Edt_SQL("N", IIf(CBool(Trim(CStr(HKKET141F.txtSTOCK.Text = ""))), 0, HKKET141F.txtSTOCK.Text)) & vbCrLf

            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELZMNT   = " & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK_MONTH.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZMNT      = " & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK_MONTH.Text) = "", 0, HKKET141F.txtSTOCK_MONTH.Text)) & vbCrLf

            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELORD    = " & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_OMISSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ORDDT     = " & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtORDER_OMISSION.Text) = "", 0, HKKET141F.txtORDER_OMISSION.Text)) & vbCrLf

            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINCD     = " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP1   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(0).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP2   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(1).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP3   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(2).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP4   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(3).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP5   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(4).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINGRP6   = " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(5).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      HINKTA    = " & D0.Edt_SQL("S", HKKET141F.txtHINNMA.Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK1   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(0).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK2   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(1).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK3   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(2).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK4   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(3).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK5   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(4).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK6   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(5).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK7   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(6).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      ZAIRNK8   = " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(7).Text) & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      MNFDD     = " & D0.Edt_SQL("S", HKKET141F.txtMNFDD.Text) & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELJYM    = " & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELGRP    = " & D0.Edt_SQL("N", IIf(HKKET141F.optONLY.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      SELVER    = " & D0.Edt_SQL("N", IIf(HKKET141F.optVERSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      OPEID     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & ",      CLTID     = " & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTTM     = " & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & ",      WRTTM     = " & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTDT     = " & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & ",      WRTDT     = " & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTFSTTM  = " & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & ",      WRTFSTTM  = " & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & ",      WRTFSTDT  = " & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & ",      WRTFSTDT  = " & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "WHERE  PRCCL     = " & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "AND    TANCD     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        Else
            strSQL = ""
            strSQL = "insert into HKKDTRA  " & vbCrLf
            strSQL = strSQL & "(PRCCL      " & vbCrLf
            strSQL = strSQL & " , TANCD    " & vbCrLf
            strSQL = strSQL & " , SELWRG   " & vbCrLf
            strSQL = strSQL & " , SELAZK   " & vbCrLf
            strSQL = strSQL & " , AZKMNT   " & vbCrLf
            strSQL = strSQL & " , SELZK    " & vbCrLf
            strSQL = strSQL & " , ZKMNT    " & vbCrLf
            strSQL = strSQL & " , SELZMNT  " & vbCrLf
            strSQL = strSQL & " , ZMNT     " & vbCrLf
            strSQL = strSQL & " , SELORD   " & vbCrLf
            strSQL = strSQL & " , ORDDT    " & vbCrLf
            strSQL = strSQL & " , HINCD    " & vbCrLf
            strSQL = strSQL & " , HINGRP1  " & vbCrLf
            strSQL = strSQL & " , HINGRP2  " & vbCrLf
            strSQL = strSQL & " , HINGRP3  " & vbCrLf
            strSQL = strSQL & " , HINGRP4  " & vbCrLf
            strSQL = strSQL & " , HINGRP5  " & vbCrLf
            strSQL = strSQL & " , HINGRP6  " & vbCrLf
            strSQL = strSQL & " , HINKTA   " & vbCrLf
            strSQL = strSQL & " , ZAIRNK1  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK2  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK3  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK4  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK5  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK6  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK7  " & vbCrLf
            strSQL = strSQL & " , ZAIRNK8  " & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            strSQL = strSQL & " , MNFDD    " & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)

            strSQL = strSQL & " , SELJYM   " & vbCrLf
            strSQL = strSQL & " , SELGRP   " & vbCrLf
            strSQL = strSQL & " , SELVER   " & vbCrLf
            strSQL = strSQL & " , OPEID    " & vbCrLf
            strSQL = strSQL & " , CLTID    " & vbCrLf
            strSQL = strSQL & " , WRTTM    " & vbCrLf
            strSQL = strSQL & " , WRTDT    " & vbCrLf
            strSQL = strSQL & " , WRTFSTTM " & vbCrLf
            strSQL = strSQL & " , WRTFSTDT " & vbCrLf
            strSQL = strSQL & ")           " & vbCrLf
            strSQL = strSQL & "VALUES      " & vbCrLf
            strSQL = strSQL & "(            " & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & D0.Edt_SQL("S", gvcstPRCCL) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optCARRIES_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSAFTY_STOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSAFTY_STOCK.Text) = "", 0, HKKET141F.txtSAFTY_STOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK.Text) = "", 0, HKKET141F.txtSTOCK.Text)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optSTOCK_MONTH.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(Trim(HKKET141F.txtSTOCK_MONTH.Text) = "", 0, HKKET141F.txtSTOCK_MONTH.Text)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_OMISSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", HKKET141F.txtORDER_OMISSION.Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(0).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(1).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(2).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(3).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(4).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINGRP(5).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtHINNMA.Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(0).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(1).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(2).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(3).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(4).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(5).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(6).Text) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(7).Text) & vbCrLf
            '//V1.10 2006/10/15  ADD START  RISE)
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", HKKET141F.txtMNFDD.Text) & vbCrLf
            '//V1.10 2006/10/15  ADD E N D  RISE)
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optORDER_ON.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optONLY.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("N", IIf(HKKET141F.optVERSION.Checked, 1, 0)) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "," & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowTm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowTm) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowTm) & vbCrLf
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraGetNowDt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'strSQL = strSQL & "," & D0.Edt_SQL("S", clsOra.OraGetNowDt) & vbCrLf
            strSQL = strSQL & "," & D0.Edt_SQL("S", OraGetNowDt) & vbCrLf
            '2019/04/12 CHG E N D
            strSQL = strSQL & ")           " & vbCrLf
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraExecute(strSQL)
        Call DB_Execute(strSQL)
        '2019/04/12 CHG E N D

        '//��ݻ޸��ݐ���J�n
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/12 CHG E N D

        SavDspFormat = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_OFF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/19 CHG START
        'clsOra.OraRollback()
        Call DB_Rollback()
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_ObjectGotFocus
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*
    '//* <��  ��>
    '//*    GotFocus���ɋ��ʂŎg�p����֐��i�J�[�\�����]��)
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Sub Set_ObjectGotFocus(ByVal pmoObject As Object, Optional ByVal pmvIndex As Object = Nothing)
    Public Sub Set_ObjectGotFocus(ByVal pmoObject As Control, Optional ByVal pmvIndex As Object = Nothing)
        '2019/04/15 CHG E N D

        If TypeOf pmoObject Is System.Windows.Forms.TextBox Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pmoObject.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15 CHG START
            'If Not pmoObject.Locked Then
            If Not (pmoObject.Enabled = False) Then
                '2019/04/15 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g ClsFocus.SetSelCursor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ClsFocus.SetSelCursor(pmoObject)
            End If
        End If
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_TantoControl
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            pmForm              Form             I
    '//*
    '//* <��  ��>
    '//*    �S���҂̌����Ŏg�p�ł���{�^������ݒ肷��
    '//*****************************************************************************************
    Public Function Set_TantoControl(ByRef pmForm As Object) As Boolean
        '2019/04/11 DEL START
        'Dim gs_UPDAUTH As Object
        'Dim gs_SAPMAUTH As Object
        'Dim gs_FILEAUTH As Object
        'Dim Get_Authority As Object
        'Dim gs_pgid As Object
        'Dim gs_userid As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_TantoControl"

        Dim strSAPMODKB As String
        Dim strSAPCSVKB As String
        Dim i As Short

        Set_TantoControl = False

        On Error GoTo ONERR_STEP

        '/�v���O�����̎��s�������擾
        'UPGRADE_WARNING: �I�u�W�F�N�g gvstrOPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gs_userid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gs_userid = gvstrOPEID
        'UPGRADE_WARNING: �I�u�W�F�N�g gs_pgid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gs_pgid = gvcstJOB_ID
        'UPGRADE_WARNING: �I�u�W�F�N�g Get_Authority(gvstrUNYDT) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Get_Authority(gvstrUNYDT) = "9" Then
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case pmForm.Name
            Case "HKKET141F"
                '//CSV�o�̓{�^������
                'UPGRADE_WARNING: �I�u�W�F�N�g gs_FILEAUTH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gs_FILEAUTH = "1" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdCSVOUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdCSVOUT.Enabled = True
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdCSVOUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdCSVOUT.Enabled = False
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g gs_SAPMAUTH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gs_SAPMAUTH = "1" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdINPUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdINPUT.Enabled = True
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdOUTPUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdOUTPUT.Enabled = True
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdINPUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdINPUT.Enabled = False
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdOUTPUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdOUTPUT.Enabled = False
                End If

                '// 2007/02/17 �� ADD STR
                If gvintPGHaita = 9 Then
                    HKKET141F.cmdOUTPUT.Enabled = False
                    HKKET141F.cmdCSVOUT.Enabled = False
                    HKKET141F.cmdINPUT.Enabled = False
                End If
                '// 2007/02/17 �� ADD STR

            Case "HKKET142F"
                '//CSV�o�̓{�^������
                'UPGRADE_WARNING: �I�u�W�F�N�g gs_FILEAUTH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gs_FILEAUTH = "1" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdCSVOUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdCSVOUT.Enabled = True
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdCSVOUT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdCSVOUT.Enabled = False
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g gs_SAPMAUTH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gs_SAPMAUTH <> "1" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.txtLMAHKS �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    For i = 0 To pmForm.txtLMAHKS.UBound
                        'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.txtLMAHKS �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        pmForm.txtLMAHKS(i).Enabled = False
                        'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.txtLMAHMS �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        pmForm.txtLMAHMS(i).Enabled = False
                    Next i
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g gs_UPDAUTH �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If gs_UPDAUTH = "1" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdUPD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdUPD.Enabled = True
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g pmForm.cmdUPD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pmForm.cmdUPD.Enabled = False
                End If

                '// 2007/02/17 �� ADD STR
                If gvintPGHaita = 9 Then
                    HKKET142F.cmdCSVOUT.Enabled = False
                    HKKET142F.cmdUPD.Enabled = False
                End If
                '// 2007/02/17 �� ADD STR

            Case "HKKET143F"
        End Select
        '// 2007/01/09 �� UPD END

        Set_TantoControl = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function


    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Clr_Display
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            pm_lng_ProcCLS      Long             I      0:��ʑS��, 1:�w�b�_��, 2:���ו�
    '//*
    '//* <��  ��>
    '//*    ��ʃN���A����
    '//*****************************************************************************************
    Sub Clr_Display(Optional ByVal pm_lng_ProcCLS As Integer = 0)
        '2019/04/11 DEL START
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Clr_Display"

        Dim i As Short

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Detail1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Header1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.ModeAll �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case pm_lng_ProcCLS

            '//�S���
            Case gvcstInputCls.ModeAll
                With HKKET141F
                    .optCARRIES_ON.Checked = True
                    .optSAFTY_STOCK.Checked = True
                    .txtSAFTY_STOCK.Text = CStr(0)
                    .txtSTOCK.Text = CStr(0)
                    .txtSTOCK_MONTH.Text = CStr(0)
                    .txtORDER_OMISSION.Text = CStr(0)
                    .txtHINCD.Text = vbNullString
                    .txtHINGRP(0).Text = vbNullString
                    .txtHINGRP(1).Text = vbNullString
                    .txtHINGRP(2).Text = vbNullString
                    .txtHINGRP(3).Text = vbNullString
                    .txtHINGRP(4).Text = vbNullString
                    .txtHINGRP(5).Text = vbNullString
                    .txtHINNMA.Text = vbNullString
                    .txtZAIRNK(0).Text = vbNullString
                    .txtZAIRNK(1).Text = vbNullString
                    .txtZAIRNK(2).Text = vbNullString
                    .txtZAIRNK(3).Text = vbNullString
                    .txtZAIRNK(4).Text = vbNullString
                    .txtZAIRNK(5).Text = vbNullString
                    .txtZAIRNK(6).Text = vbNullString
                    .txtZAIRNK(7).Text = vbNullString
                    '//V1.10 2006/10/02  ADD START  RISE)
                    .txtMNFDD.Text = vbNullString
                    '//V1.10 2006/10/02  ADD E N D  RISE)
                    .optORDER_ON.Checked = True
                    .optONLY.Checked = True
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    '.lvwMEISAI.ListItems.Clear()
                    .lvwMEISAI.Items.Clear()
                    '2019/04/11 CHG E N D
                End With

                '//�w�b�_��
            Case gvcstInputCls.Header1
                With HKKET141F
                    .optCARRIES_ON.Checked = True
                    .optSAFTY_STOCK.Checked = True
                    .txtSAFTY_STOCK.Text = CStr(0)
                    .txtSTOCK.Text = CStr(0)
                    .txtSTOCK_MONTH.Text = CStr(0)
                    .txtORDER_OMISSION.Text = CStr(0)
                    .txtHINCD.Text = vbNullString
                    .txtHINGRP(0).Text = vbNullString
                    .txtHINGRP(1).Text = vbNullString
                    .txtHINGRP(2).Text = vbNullString
                    .txtHINGRP(3).Text = vbNullString
                    .txtHINGRP(4).Text = vbNullString
                    .txtHINGRP(5).Text = vbNullString
                    .txtHINNMA.Text = vbNullString
                    .txtZAIRNK(0).Text = vbNullString
                    .txtZAIRNK(1).Text = vbNullString
                    .txtZAIRNK(2).Text = vbNullString
                    .txtZAIRNK(3).Text = vbNullString
                    .txtZAIRNK(4).Text = vbNullString
                    .txtZAIRNK(5).Text = vbNullString
                    '//V1.10 2006/10/02  ADD START  RISE)
                    .txtMNFDD.Text = vbNullString
                    '//V1.10 2006/10/02  ADD E N D  RISE)
                    .optORDER_ON.Checked = True
                    .optONLY.Checked = True
                End With

                '//�{�f�B��
            Case gvcstInputCls.Detail1
                With HKKET141F
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/11 CHG START
                    '.lvwMEISAI.ListItems.Clear()
                    .lvwMEISAI.Items.Clear()
                    '2019/04/11 CHG E N D
                End With
        End Select

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_InputControl
    '//*
    '//* <�߂�l>
    '//*
    '//*
    '//* <��  ��>   ���ږ�                     I/O     ���e
    '//*            pm_lng_ProcCLS              I      0:��ʑS��, 1:�w�b�_��, 2:���ו�
    '//*
    '//* <��  ��>
    '//*    ����,�t�@���N�V�����L�[�g�p�C�g�p�s�ݒ菈��
    '//*****************************************************************************************
    Sub Set_InputControl(Optional ByVal pm_lng_ProcCLS As Integer = 0)
        '2019/04/11 DEL START
        'Dim gvcstInputCls As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Set_InputControl"

        Dim i As Short

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Detail1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Header1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.ModeAll �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case pm_lng_ProcCLS

            '//�S���
            Case gvcstInputCls.ModeAll
                With HKKET141F
                    .fraWARNING.Enabled = False
                    .frmDISPLAY.Enabled = False
                    .frmGROUP.Enabled = False
                    .fraORDER.Enabled = False
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .lvwMEISAI.Enabled = False
                    .cmdSERCH.Enabled = False
                    .cmdALL_SELECT.Enabled = False
                    .cmdALL_RELEASE.Enabled = False
                    .cmdCSVOUT.Enabled = False
                    .cmdDISPLAY.Enabled = False
                    .cmdEND.Enabled = False
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .lvwMEISAI.Enabled = False
                End With

                '//�w�b�_��
            Case gvcstInputCls.Header1
                With HKKET141F
                    .fraWARNING.Enabled = True
                    .frmDISPLAY.Enabled = True
                    .frmGROUP.Enabled = True
                    .fraORDER.Enabled = True
                    .cmdSERCH.Enabled = True
                    .cmdEND.Enabled = True
                    '.cmdINPUT.Enabled = True

                    .cmdALL_SELECT.Enabled = False
                    .cmdALL_RELEASE.Enabled = False
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .lvwMEISAI.Enabled = False
                    .cmdCSVOUT.Enabled = False
                    .cmdOUTPUT.Enabled = False
                    .cmdDISPLAY.Enabled = False
                End With

                '//�{�f�B��
            Case gvcstInputCls.Detail1
                With HKKET141F
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .lvwMEISAI.Enabled = True
                    .cmdDISPLAY.Enabled = True

                    .cmdALL_SELECT.Enabled = True
                    .cmdALL_RELEASE.Enabled = True
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.Enabled �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .lvwMEISAI.Enabled = True
                    .cmdDISPLAY.Enabled = True

                    '// 2007/02/24 �� ADD STR
                    ''''                .lvwMEISAI.SetFocus
                    '// 2007/02/24 �� ADD STR
                    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.FullRowSelect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    HKKET141F.lvwMEISAI.FullRowSelect = True


                End With
        End Select

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_DisplayData
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*
    '//*****************************************************************************************
    Public Function Get_DisplayData() As Boolean

        Const PROCEDURE As String = "Get_DisplayData"

        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        '2019/04/11 DEL E N D

        Get_DisplayData = False

        'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Clear()
        HKKET141F.lvwMEISAI.Items.Clear()
        '2019/04/11 CHG E N D

        '2019/04/16 ADD START
        HKKET141F.LvSorter141F.Order = SortOrder.None
        '2019/04/16 ADD E N D

        '//�̔��v��O���e�擾
        If Not Get_HKKZTRA() Then
            GoTo EXIT_STEP
        End If

        On Error GoTo ONERR_STEP

        Get_DisplayData = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_HKKZTRA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �̔��v��O���e���擾����
    '//*****************************************************************************************
    Public Function Get_HKKZTRA() As Boolean

        Const PROCEDURE As String = "Get_HKKZTRA"

        '// 2007/02/02 �� UPD STR
        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset
        Dim i As Short
        Dim j As Short
        Dim strZAI As String
        Dim strHIN As String
        Dim strSafty As String
        Dim strColumn As String
        Dim intMonth As Short
        Dim blnMonth As Boolean
        Dim strLMALDTA As String
        Dim aryMonthStr() As Object
        Dim intKeikaMonth As Short

        Get_HKKZTRA = False

        On Error GoTo ONERR_STEP

        intMonth = CShort(Mid(gvstrUNYDT, 5, 2))

        ' �e�[�u�����ڕϊ��e�[�u��
        'UPGRADE_WARNING: Array �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        aryMonthStr = New Object() {"", "", "", "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}

        blnMonth = True
        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   HKKZTRA A" & vbCrLf
        strSQL = strSQL & ",      HKKZTRB B" & vbCrLf
        strSQL = strSQL & ",      ODINTRA C" & vbCrLf
        ''  strSQL = strSQL & ",      HINMTA  D" & vbCrLf   ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL

        '''''// 2007/02/13 �� ADD STR
        ''''    If HKKET141F.optVERSION.Value = True Then
        ''''        strZAI = vbNullString
        ''''        For i = 0 To HKKET141F.txtZAIRNK.UBound
        ''''            If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
        ''''                strZAI = strZAI & "     OR      INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf
        ''''            End If
        ''''        Next i
        ''''        If strZAI <> vbNullString Then
        ''''            strSQL = strSQL & ",   (SELECT SUBSTR(HINCD,1,6) HINCD FROM HINMTA " & vbCrLf
        ''''            strSQL = strSQL & "     WHERE (" & Mid(strZAI, 8) & ")" & vbCrLf
        ''''            strSQL = strSQL & "     AND   HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''            strSQL = strSQL & "     GROUP BY HINCD) D " & vbCrLf
        ''''        End If
        ''''    End If
        '''''// 2007/02/13 �� ADD END

        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  A.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  A.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  A.HINKTA LIKE " & D0.Edt_SQL("S", "%" & HKKET141F.txtHINNMA.Text & "%") & vbCrLf
        strSQL = strSQL & "  AND  A.HINCD = B.HINCD " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  B.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  B.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        strSQL = strSQL & "  AND  B.HINCD = C.HINCD " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  C.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  C.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        ''  strSQL = strSQL & "  AND  C.HINCD = D.HINCD " & vbCrLf                                                       ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL
        ''  strSQL = strSQL & "  AND  D.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf           ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL
        ''  strSQL = strSQL & "  AND  D.ZAIKB = " & D0.Edt_SQL("S", "1") & vbCrLf                                        ' 2007/07/27 ADD 2007/08/09 DEL 2007/08/17 ADD 2007/09/10 DEL

        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "  AND  A.ZAIKB = " & D0.Edt_SQL("S", "1") & vbCrLf '                2007/08/09 ADD 2007/08/17 DEL 2007/09/10 ADD
        If Trim(HKKET141F.txtMNFDD.Text) <> "" Then
            '' ����L/T = ���BL/T + ����L/T
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.PRCDD,0)) + TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        End If

        '''''// 2007/02/13 �� ADD STR
        ''''    If HKKET141F.optVERSION.Value = True Then
        ''''        If strZAI <> vbNullString Then
        ''''            strSQL = strSQL & "  AND  D.HINCD = A.HINCD " & vbCrLf
        ''''        End If
        ''''    End If
        '''''// 2007/02/13 �� ADD END

        '''''// 2007/02/13 �� ADD STR
        ''''    If HKKET141F.optONLY.Value = True Then
        '''''// 2007/02/13 �� ADD END
        strZAI = vbNullString
        For i = 0 To HKKET141F.txtZAIRNK.UBound
            If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
                ''              strZAI = strZAI & "   OR   INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf ' 2007/07/31 UPD
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strZAI = strZAI & "   OR   INSTR(A.ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 " & vbCrLf
            End If
        Next i
        '''''// 2007/02/13 �� ADD STR
        ''''    End If
        '''''// 2007/02/13 �� ADD END

        strHIN = vbNullString
        'Debug.Print(HKKET141F.txtHINGRP.UBound)
        For i = 0 To HKKET141F.txtHINGRP.UBound
            Debug.Print(Trim(HKKET141F.txtHINGRP(i).Text))
            If Trim(HKKET141F.txtHINGRP(i).Text) <> "" Then
                '''''       strHIN = strHIN & "   OR   INSTR(HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strHIN = strHIN & "   OR   INSTR(A.HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 " & vbCrLf ' 2007/07/30 UPD
            End If
        Next i

        '''''// 2007/02/13 �� ADD STR
        ''''    If HKKET141F.optONLY.Value = True Then
        '''''// 2007/02/13 �� ADD END

        If strZAI <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strZAI, 8) & ")" & vbCrLf
        End If
        '''''// 2007/02/13 �� ADD STR
        ''''    End If
        '''''// 2007/02/13 �� ADD END

        If strHIN <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strHIN, 8) & ")" & vbCrLf
        End If
        With HKKET141F
            strSafty = vbNullString

            If intMonth <= 3 Then
                intMonth = intMonth + 12
            End If

            If .optCARRIES_ON.Checked Then

                strLMALDTA = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
                intKeikaMonth = 0

                For i = intMonth To UBound(aryMonthStr)

                    If i <= 15 Then
                        blnMonth = True ' ����
                    Else
                        blnMonth = False ' ����
                    End If

                    intKeikaMonth = intKeikaMonth + 1

                    Select Case True
                        '���S�݌ɐ؂�
                        Case .optSAFTY_STOCK.Checked
                            If CShort(.txtSAFTY_STOCK.Text) >= intKeikaMonth Then
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMAMAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMAAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMBMAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMBAZM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                End If
                            End If
                            '�݌ɐ؂�
                        Case .optSTOCK.Checked
                            If CShort(.txtSTOCK.Text) >= intKeikaMonth Then
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMAMZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMAZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMBMZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        strSafty = strSafty & "  OR  LMBZKM" & aryMonthStr(i) & " = '1'" & vbCrLf
                                    End If
                                End If
                            End If
                            '�݌Ɍ���
                        Case .optSTOCK_MONTH.Checked
                            If blnMonth Then
                                If HKKET141F.optORDER_ON.Checked Then
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    strSafty = strSafty & "  OR  LMAMZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                Else
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    strSafty = strSafty & "  OR  LMAZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                End If
                            Else
                                If HKKET141F.optORDER_ON.Checked Then
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    strSafty = strSafty & "  OR  LMBMZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                Else
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    strSafty = strSafty & "  OR  LMBZKT" & aryMonthStr(i) & " >= " & .txtSTOCK_MONTH.Text & vbCrLf
                                End If
                            End If
                            '�����R��
                        Case .optORDER_OMISSION.Checked
                            If blnMonth Then
                                ''''                            strSafty = strSafty & "  OR  (TRIM(LMAHDT" & aryMonthStr(i) & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  OR  (TRIM(LMALDT" & aryMonthStr(i) & ") <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMAIPK" & aryMonthStr(i) & "),'0'))  >  0  " & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMANOS" & aryMonthStr(i) & "),'0'))  <= 0  " & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMANOSS" & aryMonthStr(i) & "),'0')) <= 0 )" & vbCrLf
                            Else
                                ''''                            strSafty = strSafty & "  OR  (TRIM(LMBHDT" & aryMonthStr(i) & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  OR  (TRIM(LMBLDT" & aryMonthStr(i) & ") <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBIPK" & aryMonthStr(i) & "),'0'))  >  0  " & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBNOS" & aryMonthStr(i) & "),'0'))  <= 0  " & vbCrLf
                                'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                strSafty = strSafty & "  AND  TO_NUMBER(NVL(TRIM(LMBNOSS" & aryMonthStr(i) & "),'0')) <= 0 )" & vbCrLf
                            End If

                    End Select
                Next i
            End If
        End With

        ' ��rSQL��t������
        If strSafty <> vbNullString Then
            strSQL = strSQL & "  AND  (" & Mid(strSafty, 7) & ")"
        End If

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn("SELECT COUNT(*)" & Mid(strSQL, 9), objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        Dim dt As DataTable = DB_GetTable("SELECT COUNT(*)" & Mid(strSQL, 9))
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'HKKET141F.txtCount.Text = VB6.Format(D0.Chk_NullN(objRec(0).Value), "#,##0")
            HKKET141F.txtCount.Text = VB6.Format(D0.Chk_NullN(dt.Rows(0)("COUNT(*)")), "#,##0")
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'If D0.Chk_NullN(objRec(0).Value) > 100 Then
            If D0.Chk_NullN(dt.Rows(0)("COUNT(*)")) > 100 Then
                '2019/04/12 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g objRec().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/12 CHG START
                'If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "���o�����F��" & D0.Chk_NullN(objRec(0).Value) & "��") = MsgBoxResult.Cancel Then
                If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "���o�����F��" & D0.Chk_NullN(dt.Rows(0)("COUNT(*)")) & "��") = MsgBoxResult.Cancel Then
                    '2019/04/12 CHG E N D
                    HKKET141F.cmdALL_SELECT.Enabled = False
                    HKKET141F.cmdALL_RELEASE.Enabled = False
                    HKKET141F.cmdDISPLAY.Enabled = False
                    GoTo EXIT_STEP
                End If
            End If
        End If

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        dt = Nothing
        dt = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            '//�̔��v��O���e����ʂɕ\������
            '2019/04/15 CHG START
            'If Not Set_HKKZTRA(objRec) Then
            If Not Set_HKKZTRA(dt) Then
                '2019/04/15 CHG E N D
                GoTo EXIT_STEP
            End If
        Else
            HKKET141F.txtCount.Text = CStr(0)
            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "105")
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/15 DEL E N D

        Get_HKKZTRA = True

        ''''    Dim strSQL          As String
        ''''    Dim objRec          As OraDynaset
        ''''    Dim i               As Integer
        ''''    Dim j               As Integer
        ''''    Dim strZAI          As String
        ''''    Dim strHIN          As String
        ''''    Dim strSafty        As String
        ''''    Dim strColumn       As String
        ''''    Dim intMonth        As Integer
        ''''    Dim blnMonth        As Boolean
        ''''    Dim strLMALDTA      As String
        ''''
        ''''    Get_HKKZTRA = False
        ''''
        ''''    On Error GoTo ONERR_STEP
        ''''
        ''''    intMonth = CInt(Mid(gvstrUNYDT, 5, 2))
        ''''
        ''''    blnMonth = True
        ''''    ' SQL���̍쐬
        ''''    strSQL = ""
        ''''    strSQL = strSQL & "SELECT * " & vbCrLf
        ''''    strSQL = strSQL & "FROM   HKKZTRA A" & vbCrLf
        ''''    strSQL = strSQL & ",      HKKZTRB B" & vbCrLf
        ''''    strSQL = strSQL & ",      ODINTRA C" & vbCrLf
        ''''    strSQL = strSQL & "WHERE  A.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  A.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''    strSQL = strSQL & "  AND  A.HINKTA LIKE " & D0.Edt_SQL("S", "%" & HKKET141F.txtHINNMA.Text & "%") & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  A.HINCD = B.HINCD " & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  B.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  B.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  B.HINCD = C.HINCD " & vbCrLf
        ''''
        ''''    strSQL = strSQL & "  AND  C.HINCD LIKE " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text & "%") & vbCrLf
        ''''    strSQL = strSQL & "  AND  C.VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Value, 0, 1)) & vbCrLf
        ''''    '//V1.10 2006/10/02  ADD START  RISE)
        ''''    If Trim(HKKET141F.txtMNFDD.Text) <> "" Then
        '''''''     strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        '''''' ����L/T = ���BL/T + ����L/T
        ''''        strSQL = strSQL & "  AND  TO_NUMBER(NVL(A.PRCDD,0)) + TO_NUMBER(NVL(A.MNFDD,0)) >= " & D0.Edt_SQL("N", HKKET141F.txtMNFDD.Text) & vbCrLf
        ''''    End If
        ''''    '//V1.10 2006/10/02  ADD E N D  RISE)
        ''''
        ''''
        ''''    strZAI = vbNullString
        ''''    For i = 0 To HKKET141F.txtZAIRNK.UBound
        ''''        If Trim(HKKET141F.txtZAIRNK(i).Text) <> "" Then
        ''''            strZAI = strZAI & "   OR   INSTR(ZAIRNK , " & D0.Edt_SQL("S", HKKET141F.txtZAIRNK(i).Text) & ",1) != 0 "
        ''''        End If
        ''''    Next i
        ''''    strHIN = vbNullString
        ''''    For i = 0 To HKKET141F.txtHINGRP.UBound
        ''''        If Trim(HKKET141F.txtHINGRP(i).Text) <> "" Then
        ''''            strHIN = strHIN & "   OR   INSTR(HINGRP , " & D0.Edt_SQL("S", HKKET141F.txtHINGRP(i).Text) & ",1) != 0 "
        ''''        End If
        ''''    Next i
        ''''    If strZAI <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strZAI, 8) & ")"
        ''''    End If
        ''''
        ''''    If strHIN <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strHIN, 8) & ")"
        ''''    End If
        ''''
        ''''    With HKKET141F
        ''''        strSafty = vbNullString
        ''''        If .optCARRIES_ON.Value Then
        ''''            j = 1
        ''''            Do
        ''''                If intMonth > 3 Then
        ''''                    strColumn = Chr(61 + intMonth)
        ''''                Else
        ''''                    strColumn = Chr(73 + intMonth)
        ''''                End If
        ''''                Select Case True
        ''''                    Case .optSAFTY_STOCK.Value
        ''''                        If blnMonth Then
        ''''                            strSafty = strSafty & "  OR  LMAAZM" & strColumn & " = '1'" & vbCrLf
        ''''                        Else
        ''''                            strSafty = strSafty & "  OR  LMBAZM" & strColumn & " = '1'" & vbCrLf
        ''''                        End If
        ''''
        ''''                        If j = CInt(.txtSAFTY_STOCK.Text) Then
        ''''                            Exit Do
        ''''                        End If
        ''''                    Case .optSTOCK.Value
        ''''                            If blnMonth Then
        ''''                                strSafty = strSafty & "  OR  LMAZKM" & strColumn & " = '1'" & vbCrLf
        ''''                            Else
        ''''                                strSafty = strSafty & "  OR  LMBZKM" & strColumn & " = '1'" & vbCrLf
        ''''                            End If
        ''''
        ''''                            If j = CInt(.txtSTOCK.Text) Then
        ''''                                Exit Do
        ''''                            End If
        ''''                    Case .optSTOCK_MONTH.Value
        ''''                            If blnMonth Then
        ''''                                strSafty = strSafty & "  OR  TRIM(LMAZKT" & strColumn & ") >= " & .txtSTOCK_MONTH.Text & vbCrLf
        ''''                            Else
        ''''                                strSafty = strSafty & "  OR  TRIM(LMBZKT" & strColumn & ") >= " & .txtSTOCK_MONTH.Text & vbCrLf
        ''''                                If strColumn = "L" Then
        ''''                                    Exit Do
        ''''                                End If
        ''''                            End If
        ''''                    Case .optORDER_OMISSION.Value
        ''''                        strLMALDTA = Format(gvstrUNYDT, "@@@@/@@/@@")
        ''''                        If blnMonth Then
        ''''                            strSafty = strSafty & "  OR  TRIM(LMAHDT" & strColumn & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
        ''''                        Else
        ''''                            strSafty = strSafty & "  OR  TRIM(LMBHDT" & strColumn & ") <= '" & Format(DateAdd("d", CDbl(.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") & "'" & vbCrLf
        ''''                            If strColumn = "L" Then
        ''''                                Exit Do
        ''''                            End If
        ''''                        End If
        ''''                End Select
        ''''                intMonth = intMonth + 1
        ''''                If intMonth = 4 Then
        ''''                    intMonth = 1
        ''''                    blnMonth = False
        ''''                End If
        ''''                If intMonth = 16 Then
        ''''                    intMonth = 4
        ''''                    blnMonth = False
        ''''                End If
        ''''                j = j + 1
        ''''            Loop
        ''''        End If
        ''''    End With
        ''''    If strSafty <> vbNullString Then
        ''''        strSQL = strSQL & "  AND  (" & Mid(strSafty, 7) & ")"
        ''''    End If
        ''''
        ''''    ' �f�[�^�擾
        ''''    If Not clsOra.OraCreateDyn("SELECT COUNT(*)" & Mid(strSQL, 9), objRec, , PROCEDURE) Then
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    If Not clsOra.OraEOF(objRec) Then
        ''''        HKKET141F.txtCount.Text = Format(D0.Chk_NullN(objRec(0).Value), "#,##0")
        ''''        If D0.Chk_NullN(objRec(0).Value) > 100 Then
        ''''            If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "223", "���o�����F��" & D0.Chk_NullN(objRec(0).Value) & "��") = vbCancel Then
        ''''                HKKET141F.cmdALL_SELECT.Enabled = False
        ''''                HKKET141F.cmdALL_RELEASE.Enabled = False
        ''''                HKKET141F.cmdDISPLAY.Enabled = False
        ''''                GoTo EXIT_STEP
        ''''            End If
        ''''        End If
        ''''    End If
        ''''
        ''''    ' �f�[�^�擾
        ''''    If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    If Not clsOra.OraEOF(objRec) Then
        ''''        '//�̔��v��O���e����ʂɕ\������
        ''''        If Not Set_HKKZTRA(objRec) Then
        ''''            GoTo EXIT_STEP
        ''''        End If
        ''''    Else
        ''''        HKKET141F.txtCount.Text = 0
        ''''        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "105"
        ''''        GoTo EXIT_STEP
        ''''    End If
        ''''
        ''''    clsOra.OraCloseDyn objRec
        ''''
        ''''    Get_HKKZTRA = True
        '// 2007/02/02 �� UPD STR

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_HKKTRA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            pmStrHincd          String           I
    '//*            pmObjRec            OraDynaset       O
    '//*
    '//* <��  ��>
    '//*    �̔��v��e���擾����
    '//*****************************************************************************************
    Public Function Get_HKKTRA(ByRef pmStrHincd As String) As Boolean
        '2019/04/11 DEL START
        'Dim ORADYN_READONLY As Object
        'Dim gvstrOPEID As Object
        '2019/04/11 DEL E N D

        Const PROCEDURE As String = "Get_HKKTRA"

        Dim strSQL As String

        Get_HKKTRA = False

        On Error GoTo ONERR_STEP

        strSQL = ""
        strSQL = strSQL & "SELECT * " & vbCrLf
        strSQL = strSQL & "FROM   HKKWTA " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", HKKET141F.txtHINCD.Text) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "AND    OPEID = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "AND    VERFL = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf
        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/19 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, gvobjdyn, ORADYN_READONLY, PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        gvobjdyn = DB_GetTable(strSQL)
        '2019/04/19 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/19 CHG START
        'If Not clsOra.OraEOF(gvobjdyn) Then
        '    gvblnInputFlg = True
        'Else
        '    gvblnInputFlg = False
        'End If
        If gvobjdyn IsNot Nothing AndAlso gvobjdyn.Rows.Count > 0 Then
            gvblnInputFlg = True
        Else
            gvblnInputFlg = False
        End If
        '2019/04/19 CHG E N D

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT " & vbCrLf
        ''�O�N�v�搔��
        strSQL = strSQL & "  LMZHKSA, LMZHKSB, LMZHKSC, LMZHKSD, LMZHKSE, LMZHKSF, LMZHKSG, LMZHKSH, LMZHKSI, LMZHKSJ, LMZHKSK, LMZHKSL" & vbCrLf ' 1-12
        ''���N�v�搔��
        strSQL = strSQL & ", LMAHKSA, LMAHKSB, LMAHKSC, LMAHKSD, LMAHKSE, LMAHKSF, LMAHKSG, LMAHKSH, LMAHKSI, LMAHKSJ, LMAHKSK, LMAHKSL" & vbCrLf '13-24
        ''���N�v�搔��
        strSQL = strSQL & ", LMBHKSA, LMBHKSB, LMBHKSC, LMBHKSD, LMBHKSE, LMBHKSF, LMBHKSG, LMBHKSH, LMBHKSI, LMBHKSJ, LMBHKSK, LMBHKSL" & vbCrLf '25-36
        '//�O�N��������
        strSQL = strSQL & ", LMZHMSA, LMZHMSB, LMZHMSC, LMZHMSD, LMZHMSE, LMZHMSF, LMZHMSG, LMZHMSH, LMZHMSI, LMZHMSJ, LMZHMSK, LMZHMSL" & vbCrLf '37-48
        '//���N��������
        strSQL = strSQL & ", LMAHMSA, LMAHMSB, LMAHMSC, LMAHMSD, LMAHMSE, LMAHMSF, LMAHMSG, LMAHMSH, LMAHMSI, LMAHMSJ, LMAHMSK, LMAHMSL" & vbCrLf '49-60
        '//���N��������
        strSQL = strSQL & ", LMBHMSA, LMBHMSB, LMBHMSC, LMBHMSD, LMBHMSE, LMBHMSF, LMBHMSG, LMBHMSH, LMBHMSI, LMBHMSJ, LMBHMSK, LMBHMSL" & vbCrLf '61-72

        strSQL = strSQL & ", ZNKURITK ,ZNKSRETK" & vbCrLf
        ''//�N���v��CSV�捞�ݎ��̓��[�N�t�@�C������
        If gvblnInputFlg Then
            strSQL = strSQL & "FROM   HKKWTA HKKTRA�@" & vbCrLf
        Else
            strSQL = strSQL & "FROM   HKKTRA " & vbCrLf
        End If
        strSQL = strSQL & "       ,HINMTA "
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  HKKTRA.HINCD  = " & D0.Edt_SQL("S", pmStrHincd) & vbCrLf
        strSQL = strSQL & "AND    HKKTRA.VHINCD = HINMTA.HINCD " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "AND    HKKTRA.VERFL  = " & D0.Edt_SQL("S", IIf(HKKET141F.optONLY.Checked, 0, 1)) & vbCrLf


        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/19 CHG START
        'If Not clsOra.OraCreateDyn(strSQL, gvobjdyn, , PROCEDURE) Then
        '    GoTo EXIT_STEP
        'End If
        gvobjdyn = DB_GetTable(strSQL)
        '2019/04/19 CHG E N D

        Get_HKKTRA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Set_HKKZTRA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            objRec              OraDynaset       I
    '//*
    '//* <��  ��>
    '//*    �̔��v��O���\��
    '//*****************************************************************************************
    '2019/04/15 CHG START
    'Public Function Set_HKKZTRA(ByRef objRec As OraDynaset) As Boolean
    Public Function Set_HKKZTRA(ByRef pDT As DataTable) As Boolean
        '2019/04/15 CHG E N D

        Const PROCEDURE As String = "Set_HKKZTRA"

        '2019/04/15 ADD START
        Try
            '2019/04/15 ADD E N D

            '// 2007/02/02 �� UPD STR
            'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
            '2019/04/11 CHG START
            'Dim objLitem As ListItem
            '2019/04/11 CHG E N D
            Dim strSQL As String
            'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
            '2019/04/15 DEL START
            'Dim objRecB As OraDynaset
            '2019/04/15 DEL E N D
            'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
            '2019/04/15 DEL START
            'Dim objRecC As OraDynaset
            '2019/04/15 DEL E N D
            'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
            '2019/04/15 DEL START
            'Dim objRecD As OraDynaset
            '2019/04/15 DEL E N D
            Dim intMonth As Short
            Dim i As Short
            Dim j As Short
            Dim blnMonth As Boolean
            Dim strDate As String
            Dim strLMALDTA As String
            Dim SUMFRDSU As Double
            Dim aryMonthStr() As Object
            Dim intKeikaMonth As Short
            Dim intFindIndex As Short

            Set_HKKZTRA = False

            '2019/04/15 DEL START
            'On Error GoTo ONERR_STEP
            '2019/04/15 DEL E N D

            ' �e�[�u�����ڕϊ��e�[�u��
            'UPGRADE_WARNING: Array �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            aryMonthStr = New Object() {"", "", "", "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}

            '2019/04/15 ADD START
            Dim itemCnt As Integer = 0
            '2019/04/15 ADD E N D

            'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/15 CHG START
            'Do Until clsOra.OraEOF(objRec)
            For Each row As DataRow In pDT.Rows
                '2019/04/15 CHG E N D

                strLMALDTA = VB6.Format(gvstrUNYDT, "@@@@/@@/@@")
                intMonth = CShort(Mid(gvstrUNYDT, 5, 2))
                blnMonth = True

                intKeikaMonth = 0
                intFindIndex = 0

                If intMonth <= 3 Then
                    intMonth = intMonth + 12
                End If

                If HKKET141F.optCARRIES_ON.Checked Then

                    For i = intMonth To UBound(aryMonthStr)

                        If i <= 15 Then
                            blnMonth = True ' ����
                        Else
                            blnMonth = False ' ����
                        End If

                        Select Case True
                            '���S�݌ɐ؂�
                            Case HKKET141F.optSAFTY_STOCK.Checked
                                If blnMonth Then 'LMAMAZM
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBAZM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBAZM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '�݌ɐ؂�
                            Case HKKET141F.optSTOCK.Checked
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAMZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAMZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMAZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMAZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBMZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBMZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBZKM" & aryMonthStr(i))) = "1" Then
                                        If D0.Chk_Null(row("LMBZKM" & aryMonthStr(i))) = "1" Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '�݌Ɍ���
                            Case HKKET141F.optSTOCK_MONTH.Checked
                                If blnMonth Then
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMAMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMAMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMAZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMAZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If HKKET141F.optORDER_ON.Checked Then
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMBMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMBMZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    Else
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If Val(D0.Chk_Null(objRec("LMBZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                        If Val(D0.Chk_Null(row("LMBZKT" & aryMonthStr(i)))) >= Val(HKKET141F.txtSTOCK_MONTH.Text) Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '�����R��
                            Case HKKET141F.optORDER_OMISSION.Checked
                                '//V2.02 �� UPD
                                '                        If blnMonth Then
                                '''''                            If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(i))) <> "" Then
                                '''''                                If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                            If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <> "" Then
                                '                                If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                                    intFindIndex = i
                                '                                    Exit For
                                '                                End If
                                '                            End If
                                '                        Else
                                '''''                            If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(i))) <> "" Then
                                '''''                                If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                            If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <> "" Then
                                '                                If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <= Format(DateAdd("d", CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") Then
                                '                                    intFindIndex = i
                                '                                    Exit For
                                '                                End If
                                '                            End If
                                '                        End If
                                If blnMonth Then
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/15 CHG START
                                    'If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <> "" Then
                                    If D0.Chk_Null(row("LMALDT" & aryMonthStr(i))) <> "" Then
                                        '2019/04/15 CHG E N D
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMALDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") And Val(D0.Chk_Null(objRec("LMAIPK" & aryMonthStr(i)))) <> 0 And Val(D0.Chk_Null(objRec("LMANOS" & aryMonthStr(i)))) = 0 Then
                                        If D0.Chk_Null(row("LMALDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") _
                                         And Val(D0.Chk_Null(row("LMAIPK" & aryMonthStr(i)))) <> 0 _
                                         And Val(D0.Chk_Null(row("LMANOS" & aryMonthStr(i)))) = 0 Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                Else
                                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    '2019/04/15 CHG START
                                    'If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <> "" Then
                                    If D0.Chk_Null(row("LMBLDT" & aryMonthStr(i))) <> "" Then
                                        '2019/04/15 CHG E N D
                                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        '2019/04/15 CHG START
                                        'If D0.Chk_Null(objRec("LMBLDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") And Val(D0.Chk_Null(objRec("LMBIPK" & aryMonthStr(i)))) <> 0 And Val(D0.Chk_Null(objRec("LMBNOS" & aryMonthStr(i)))) = 0 Then
                                        If D0.Chk_Null(row("LMBLDT" & aryMonthStr(i))) <= VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, CDbl(HKKET141F.txtORDER_OMISSION.Text), CDate(strLMALDTA)), "yyyymmdd") _
                                         And Val(D0.Chk_Null(row("LMBIPK" & aryMonthStr(i)))) <> 0 _
                                         And Val(D0.Chk_Null(row("LMBNOS" & aryMonthStr(i)))) = 0 Then
                                            '2019/04/15 CHG E N D
                                            intFindIndex = i
                                            Exit For
                                        End If
                                    End If
                                End If
                                '//V2.02 �� UPD
                        End Select
                    Next i
                End If

                ' �x���\���̏ꍇ�A�Y�����Ɣ����\�萔��ݒ� �x���ȊO�́A�����̔����\�萔��\��
                If HKKET141F.optCARRIES_ON.Checked Then
                    If intFindIndex <> 0 Then
                        If blnMonth Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/15 CHG START
                            'strDate = D0.Chk_Null(objRec("LMAYM" & aryMonthStr(intFindIndex)))
                            strDate = D0.Chk_Null(row("LMAYM" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/15 CHG START
                            'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                            SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                        Else
                            'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/15 CHG START
                            'strDate = D0.Chk_Null(objRec("LMBYM" & aryMonthStr(intFindIndex)))
                            strDate = D0.Chk_Null(row("LMBYM" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                            'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '2019/04/15 CHG START
                            'SUMFRDSU = D0.Chk_NullN(objRec("LMBIPK" & aryMonthStr(intFindIndex)))
                            SUMFRDSU = D0.Chk_NullN(row("LMBIPK" & aryMonthStr(intFindIndex)))
                            '2019/04/15 CHG E N D
                        End If
                    Else
                        intFindIndex = intMonth
                        strDate = ""
                        'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/04/15 CHG START
                        'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                        SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                        '2019/04/15 CHG E N D
                    End If
                Else
                    intFindIndex = intMonth
                    strDate = ""
                    'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/04/15 CHG START
                    'SUMFRDSU = D0.Chk_NullN(objRec("LMAIPK" & aryMonthStr(intFindIndex)))
                    SUMFRDSU = D0.Chk_NullN(row("LMAIPK" & aryMonthStr(intFindIndex)))
                    '2019/04/15 CHG E N D
                End If

                ' SQL���̍쐬
                strSQL = ""
                strSQL = strSQL & "SELECT * " & vbCrLf
                strSQL = strSQL & "FROM   HKKZTRB " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(objRec("HINCD"))) & vbCrLf
                strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(row("HINCD"))) & vbCrLf
                '2019/04/15 CHG E N D
                'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRecB, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dtHKKZTRB As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

                ' SQL���̍쐬
                strSQL = ""
                strSQL = strSQL & "SELECT        " & vbCrLf
                strSQL = strSQL & "  MDLCL       " & vbCrLf
                strSQL = strSQL & "FROM   HINMTA " & vbCrLf
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(objRec("HINCD"))) & vbCrLf
                strSQL = strSQL & "WHERE  HINCD = " & D0.Edt_SQL("S", D0.Chk_Null(row("HINCD"))) & vbCrLf
                '2019/04/15 CHG E N D

                ' �f�[�^�擾
                'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/04/15 CHG START
                'If Not clsOra.OraCreateDyn(strSQL, objRecD, , PROCEDURE) Then
                '    GoTo EXIT_STEP
                'End If
                Dim dtHINMTA As DataTable = DB_GetTable(strSQL)
                '2019/04/15 CHG E N D

                '2019/04/11 CHG START
                ''UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem = HKKET141F.lvwMEISAI.ListItems.Add
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(1) = VB6.Format(strDate, "@@@@/@@") '//�x���N��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(2) = D0.Chk_Null(objRec("HINCD")) '//���i����
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(3) = D0.Chk_Null(objRec("HINKTA")) '//�^��
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(4) = D0.Chk_Null(objRecD("MDLCL")) '//���Ƌ敪
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(5) = D0.Chk_Null(objRec("ZAIRNK")) '//�݌��ݸ
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(6) = IIf(D0.Chk_Null(objRec("PRDENDKB")) = "1", "��", "�~") '//���Y���~
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(7) = IIf(D0.Chk_Null(objRec("SLENDKB")) = "1", "��", "�~") '//�̔���~
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(8) = D0.Chk_NullN(objRec("TOUZAISU")) '//���݌ɐ�
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(9) = D0.Chk_NullN(objRec("JYCYUSU")) '//���󒍐�
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(10) = D0.Chk_NullN(objRec("MKMZAISU")) '//�������݌ɐ�
                ''//�����Č��� + �������ϐ�
                ''// 2007/02/09 �� UPD STR
                'If blnMonth Then
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMAMAS" & aryMonthStr(intFindIndex)))
                'Else
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMBMAS" & aryMonthStr(intFindIndex)))
                'End If
                ''        objLitem.SubItems(11) = D0.Chk_NullN(objRec("MKMMITSU")) + D0.Chk_NullN(objRecB("LMAMAS" & aryMonthStr(intFindIndex)))
                ''// 2007/02/09 �� UPD STR

                ''//�����܂ގ�
                'If HKKET141F.optORDER_ON.Checked Then
                '	'//(���������݌ɐ�-���S�݌ɐ�)/���Ϗo�ɐ�
                '	'// 2007/02/09 �� UPD STR
                '	If blnMonth Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMAMZKT" & aryMonthStr(intFindIndex)))
                '	Else
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMBMZKT" & aryMonthStr(intFindIndex)))
                '	End If
                '	'            If D0.Chk_NullN(objRecB("LMAAVTS")) = "0" Then
                '	'                objLitem.SubItems(12) = 0                        '//�݌Ɍ���
                '	'            Else
                '	'                If blnMonth Then
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMAMYGZ" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                Else
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMBMYGZ" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                End If
                '	'            End If
                '	'// 2007/02/09 �� UPD STR
                'Else
                '	'//(�����݌ɐ�-���S�݌ɐ�)/���Ϗo�ɐ�
                '	'// 2007/02/09 �� UPD STR
                '	If blnMonth Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMAZKT" & aryMonthStr(intFindIndex)))
                '	Else
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(12) = D0.Chk_NullN(objRec("LMBZKT" & aryMonthStr(intFindIndex)))
                '	End If
                '	'            If D0.Chk_NullN(objRecB("LMAAVTS")) = "0" Then
                '	'                objLitem.SubItems(12) = 0
                '	'            Else
                '	'                If blnMonth Then
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMAYGZS" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                Else
                '	'                    objLitem.SubItems(12) = D0.Chg_NumericRound((D0.Chk_NullN(objRec("LMBYGZS" & aryMonthStr(intFindIndex)) _
                '	''                                                               - D0.Chk_NullN(objRec("ANZZAISU")))) _
                '	''                                                               / D0.Chk_NullN(objRecB("LMAAVTS")), 3, 3)
                '	'                End If
                '	'            End If
                '	'// 2007/02/09 �� UPD STR
                'End If
                ''//�x�����o���Ȃ���
                'If HKKET141F.optCARRIES_OFF.Checked Then
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(13) = D0.Chk_NullN(objRec("LMAAVTS")) '//���Ϗo�ɐ�
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(14) = D0.Chk_NullN(objRec("TOUZAISU")) '//�݌ɐ�
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(15) = D0.Chk_NullN(objRec("TOUZAISU")) - D0.Chk_NullN(objRec("ANZZAISU")) '//���S�݌ɐ؂�
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(16) = D0.Chk_NullN(objRec("TOUZAISU")) - D0.Chk_NullN(objRec("LMAAVTS")) '//�݌ɐ؂�
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(17) = SUMFRDSU
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(18) = " " '//���ؗ]����
                'Else
                '	If blnMonth Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(13) = D0.Chg_NumericRound(D0.Chk_NullN(objRecB("LMAAVZS" & aryMonthStr(intFindIndex))), 1, 3) '//���Ϗo�ɐ�
                '	Else
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chg_NumericRound �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(13) = D0.Chg_NumericRound(D0.Chk_NullN(objRecB("LMBAVZS" & aryMonthStr(intFindIndex))), 1, 3) '//���Ϗo�ɐ�
                '	End If
                '	'//�����܂ގ�
                '	If HKKET141F.optORDER_ON.Checked Then
                '		If blnMonth Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMAMKZS" & aryMonthStr(intFindIndex))) '//�݌ɐ�
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMBMKZS" & aryMonthStr(intFindIndex))) '//�݌ɐ�
                '		End If
                '	Else
                '		If blnMonth Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMAZAIS" & aryMonthStr(intFindIndex))) '//�݌ɐ�
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(14) = D0.Chk_NullN(objRec("LMBZAIS" & aryMonthStr(intFindIndex))) '//�݌ɐ�
                '		End If
                '	End If
                '	'// 2007/02/09 �� UPD STR
                '	'            If objLitem.SubItems(14) - D0.Chk_NullN(objRec("ANZZAISU")) < 0 Then
                '	'                objLitem.SubItems(15) = objLitem.SubItems(14) - D0.Chk_NullN(objRec("ANZZAISU"))    '//���S�݌ɐ؂�
                '	'            Else
                '	'                objLitem.SubItems(15) = 0    '//���S�݌ɐ؂�
                '	'            End If
                '	'            If objLitem.SubItems(14) - D0.Chk_NullN(objRec("LMAAVTS")) < 0 Then
                '	'                objLitem.SubItems(16) = objLitem.SubItems(14) - D0.Chk_NullN(objRec("LMAAVTS"))    '//�݌ɐ؂�
                '	'            Else
                '	'                objLitem.SubItems(16) = 0    '//�݌ɐ؂�
                '	'            End If
                '	'//���S�݌ɐ؂�
                '	If HKKET141F.optORDER_ON.Checked Then
                '		'//(�����܂ގ�)
                '		If blnMonth Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMAAZS" & aryMonthStr(intFindIndex)))
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMBAZS" & aryMonthStr(intFindIndex)))
                '		End If
                '	Else
                '		'//(�����܂ނ܂Ȃ�)
                '		If blnMonth Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMAMAZS" & aryMonthStr(intFindIndex)))
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(15) = D0.Chk_NullN(objRec("LMBMAZS" & aryMonthStr(intFindIndex)))
                '		End If
                '	End If
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	If objLitem.SubItems(15) > 0 Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(15) = 0
                '	End If
                '	'//�݌ɐ؂�
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(16) = objLitem.SubItems(15) - D0.Chk_NullN(objRec("LMAAVTS"))
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	If objLitem.SubItems(16) > 0 Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		objLitem.SubItems(16) = 0
                '	End If
                '	'// 2007/02/09 �� UPD STR
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(17) = SUMFRDSU
                '	'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	objLitem.SubItems(18) = 0 '//���ؗ]����
                '	If blnMonth Then
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		If D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(intFindIndex))) = "" Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(18) = 0
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: DateDiff ���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(18) = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(objRec("LMAHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                '		End If
                '	Else
                '		'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '		If D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(intFindIndex))) = "" Then
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(18) = 0
                '		Else
                '			'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g aryMonthStr() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '			'UPGRADE_WARNING: DateDiff ���삪�قȂ�\��������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"' ���N���b�N���Ă��������B
                '			objLitem.SubItems(18) = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(objRec("LMBHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                '		End If
                '	End If
                'End If
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_NullN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(19) = D0.Chk_NullN(objRec("PRCDD")) + D0.Chk_NullN(objRec("MNFDD")) '//���BLT + ����LT
                ''UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ''UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'objLitem.SubItems(20) = D0.Chk_Null(objRec("HINGRP")) '//���i����
                With HKKET141F.lvwMEISAI
                    '0�`20(�S21��)
                    '//0:�I
                    .Items.Add("", itemCnt)
                    '//1:�x���N��
                    .Items(itemCnt).SubItems.Add(VB6.Format(strDate, "@@@@/@@"))
                    '//2:���i����
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINCD")))
                    '//3:�^��
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINKTA")))
                    '//4:���Ƌ敪
                    If dtHINMTA IsNot Nothing AndAlso dtHINMTA.Rows.Count > 0 Then
                        .Items(itemCnt).SubItems.Add(D0.Chk_Null(dtHINMTA.Rows(0)("MDLCL")))
                    Else
                        .Items(itemCnt).SubItems.Add("")
                    End If
                    '//5:�݌��ݸ
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("ZAIRNK")))
                    '//6:���Y���~
                    .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("PRDENDKB")) = "1", "��", "�~"))
                    '//7:�̔���~
                    .Items(itemCnt).SubItems.Add(IIf(D0.Chk_Null(row("SLENDKB")) = "1", "��", "�~"))
                    '//8:���݌ɐ�
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")))
                    '//9:���󒍐�
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("JYCYUSU")))
                    '//10:�������݌ɐ�
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMZAISU")))
                    '//11:
                    '//�����Č��� + �������ϐ�
                    If blnMonth Then
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMMITSU")) + D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMAMAS" & aryMonthStr(intFindIndex))))
                    Else
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("MKMMITSU")) + D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMBMAS" & aryMonthStr(intFindIndex))))
                    End If
                    '//12:
                    '//�����܂ގ�
                    If HKKET141F.optORDER_ON.Checked Then
                        '//(���������݌ɐ�-���S�݌ɐ�)/���Ϗo�ɐ�
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAMZKT" & aryMonthStr(intFindIndex))))
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBMZKT" & aryMonthStr(intFindIndex))))
                        End If
                    Else
                        '//(�����݌ɐ�-���S�݌ɐ�)/���Ϗo�ɐ�
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAZKT" & aryMonthStr(intFindIndex))))
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBZKT" & aryMonthStr(intFindIndex))))
                        End If
                    End If
                    '//�x�����o���Ȃ���
                    If HKKET141F.optCARRIES_OFF.Checked Then
                        '//13:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAAVTS"))) '//���Ϗo�ɐ�
                        '//14:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU"))) '//�݌ɐ�
                        '//15:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")) - D0.Chk_NullN(row("ANZZAISU"))) '//���S�݌ɐ؂�
                        '//16:
                        .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("TOUZAISU")) - D0.Chk_NullN(row("LMAAVTS"))) '//�݌ɐ؂�
                        '//17:
                        .Items(itemCnt).SubItems.Add(SUMFRDSU)
                        '//18:
                        .Items(itemCnt).SubItems.Add(" ") '//���ؗ]����
                    Else
                        '//13:
                        If blnMonth Then
                            .Items(itemCnt).SubItems.Add(D0.Chg_NumericRound(D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMAAVZS" & aryMonthStr(intFindIndex))), 1, 3)) '//���Ϗo�ɐ�
                        Else
                            .Items(itemCnt).SubItems.Add(D0.Chg_NumericRound(D0.Chk_NullN(dtHKKZTRB.Rows(0)("LMBAVZS" & aryMonthStr(intFindIndex))), 1, 3)) '//���Ϗo�ɐ�
                        End If
                        '//14:
                        '//�����܂ގ�
                        If HKKET141F.optORDER_ON.Checked Then
                            If blnMonth Then
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAMKZS" & aryMonthStr(intFindIndex)))) '//�݌ɐ�
                            Else
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBMKZS" & aryMonthStr(intFindIndex)))) '//�݌ɐ�
                            End If
                        Else
                            If blnMonth Then
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMAZAIS" & aryMonthStr(intFindIndex)))) '//�݌ɐ�
                            Else
                                .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("LMBZAIS" & aryMonthStr(intFindIndex)))) '//�݌ɐ�
                            End If
                        End If
                        '//15:
                        '//���S�݌ɐ؂�
                        Dim items14 As Decimal = 0
                        If HKKET141F.optORDER_ON.Checked Then
                            '//(�����܂ގ�)
                            If blnMonth Then
                                items14 = D0.Chk_NullN(row("LMAAZS" & aryMonthStr(intFindIndex)))
                            Else
                                items14 = D0.Chk_NullN(row("LMBAZS" & aryMonthStr(intFindIndex)))
                            End If
                        Else
                            '//(�����܂ނ܂Ȃ�)
                            If blnMonth Then
                                items14 = D0.Chk_NullN(row("LMAMAZS" & aryMonthStr(intFindIndex)))
                            Else
                                items14 = D0.Chk_NullN(row("LMBMAZS" & aryMonthStr(intFindIndex)))
                            End If
                        End If
                        If items14 > 0 Then
                            items14 = 0
                        End If
                        .Items(itemCnt).SubItems.Add(items14.ToString)
                        '//16:
                        '//�݌ɐ؂�
                        Dim items15 As Decimal = 0
                        items15 = items14 - D0.Chk_NullN(row("LMAAVTS"))
                        If items15 > 0 Then
                            items15 = 0
                        End If
                        .Items(itemCnt).SubItems.Add(items15)
                        '//17:
                        .Items(itemCnt).SubItems.Add(SUMFRDSU)
                        '//18:
                        '//���ؗ]����
                        Dim items17 As Long = 0
                        If blnMonth Then
                            If D0.Chk_Null(row("LMAHDT" & aryMonthStr(intFindIndex))) = "" Then
                                items17 = 0
                            Else
                                items17 = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(row("LMAHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                            End If
                        Else
                            If D0.Chk_Null(row("LMBHDT" & aryMonthStr(intFindIndex))) = "" Then
                                items17 = 0
                            Else
                                items17 = DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(gvstrUNYDT, "@@@@/@@/@@")), CDate(VB6.Format(D0.Chk_Null(row("LMBHDT" & aryMonthStr(intFindIndex))), "@@@@/@@/@@")))
                            End If
                        End If
                        .Items(itemCnt).SubItems.Add(items17) '//���ؗ]����
                    End If
                    '//19:
                    .Items(itemCnt).SubItems.Add(D0.Chk_NullN(row("PRCDD")) + D0.Chk_NullN(row("MNFDD"))) '//���BLT + ����LT
                    '//20:
                    .Items(itemCnt).SubItems.Add(D0.Chk_Null(row("HINGRP"))) '//���i����
                End With
                '2019/04/11 CHG E N D

                '2019/04/15 DEL START
                ''//��ں��ތ���
                ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraMoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'clsOra.OraMoveNext(objRec)
                '2019/04/15 DEL E N D

                '2019/04/15 ADD START
                itemCnt += 1
                '2019/04/15 ADD E N D

                '2019/04/15 CHG START
                'Loop
            Next
            '2019/04/15 CHG E N D

            '2019/04/16 ADD START
            HKKET141F.lvwMEISAI.CheckBoxes = True
            '2019/04/16 ADD E N D

            '2019/04/16 ADD START
            HKKET141F.LvSorter141F.Order = LvSortOrder  'ItemAdd��ɐݒ肷��
            Call SortLv(HKKET141F.lvwMEISAI, InitSortColumn, HKKET141F.LvSorter141F, True)
            '2019/04/16 ADD E N D

            '2019/04/15 ADD START
            Set_HKKZTRA = True
            '2019/04/15 ADD E N D

            '----------------------------------------------------------------------------------------
            '2019/04/15 DEL START
            'EXIT_STEP:
            '            On Error GoTo 0
            '            Exit Function
            '2019/04/15 DEL E N D
            '----------------------------------------------------------------------------------------
            '2019/04/15 DEL START
            'ONERR_STEP:
            '            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '            ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
            '            Resume EXIT_STEP
            '2019/04/15 DEL E N D


            '2019/04/15 ADD START
        Catch ex As Exception
            ClsMessage.RuntimeErrorMsg(Err.Description & "(" & ex.Message & ")", PROCEDURE)
        End Try
        '2019/04/15 ADD E N D

    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Chk_InputDetail
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:�ύX�L�� , False:�ύX����
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    ��ʂɕ\�����ꂽ���e�����������m�F����
    '//*****************************************************************************************
    Public Function Chk_InputDetail() As Boolean

        Const PROCEDURE As String = "Chk_InputDetail"

        Dim i As Short
        Dim objCheckObject As Object
        Dim vntArray As Object

        Chk_InputDetail = False

        On Error GoTo ONERR_STEP

        With HKKET141F
            If .optCARRIES_ON.Checked Then
                'If Trim(.txtSAFTY_STOCK.Text) = vbNullString Or
                '                    Trim(.txtSTOCK.Text) = vbNullString Or
                '                    Trim(.txtSTOCK_MONTH.Text) = vbNullString Or
                '                    Trim(.txtORDER_OMISSION.Text) = vbNullString Then
                '    ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "101")
                '    GoTo EXIT_STEP
                'End If
                Select Case True
                    Case .optSAFTY_STOCK.Checked
                        'change start 20190927 kuwa ÷���ޯ���������͂̎��ɃL���X�g�G���[���N����̂ŁA��������ɕ�����B�@ADD����̂�Y��Ȃ��B
                        '��L�̃R�����g�A�E�g����Ă��関���͎��̏������͂����R�[�h�iL2983~2989�j�̓t�H�[�J�X�����b�Z�[�W�{�b�N�X�\����ɓ�����Ȃ����ߎg��Ȃ��H�^�U�s��
                        'If Trim(.txtSAFTY_STOCK.Text) = vbNullString Or CDbl(Trim(.txtSAFTY_STOCK.Text)) = 0 Then
                        If Trim(.txtSAFTY_STOCK.Text) = vbNullString Then
                            .txtSAFTY_STOCK.Text = " " '���t�H�[�J�X�𓖂Ă邽�߂ɔ��p�X�y�[�X��ǉ�
                            'change end 20190927 ADD����K�v����B
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSAFTY_STOCK.Focus()
                            GoTo EXIT_STEP

                            'add start 20190927 ��������ɕ������̂ŁA��ڂ̏�����ǉ��B
                        ElseIf CDbl(Trim(.txtSAFTY_STOCK.Text)) = 0 Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSAFTY_STOCK.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optSTOCK.Checked
                        'change start 20190927 kuwa ��������ɕ�����
                        'If Trim(.txtSTOCK.Text) = vbNullString Or CDbl(Trim(.txtSTOCK.Text)) = 0 Then
                        If Trim(.txtSTOCK.Text) = vbNullString Then
                            .txtSTOCK.Text = " " '�t�H�[�J�X�p
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa ���ڂ̏����ǉ�
                        ElseIf CDbl(Trim(.txtSTOCK.Text)) = 0 Then
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optSTOCK_MONTH.Checked
                        'change start 20190927 kuwa�@��������ɕ�����
                        'If Trim(.txtSTOCK_MONTH.Text) = vbNullString Or CDbl(Trim(.txtSTOCK_MONTH.Text)) = 0 Then
                        If Trim(.txtSTOCK_MONTH.Text) = vbNullString Then
                            .txtSTOCK_MONTH.Text = " " '�t�H�[�J�X�p
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK_MONTH.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa ���ڂ̏����ǉ�
                        ElseIf CDbl(Trim(.txtSTOCK_MONTH.Text)) = 0 Then
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "102")
                            .txtSTOCK_MONTH.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                    Case .optORDER_OMISSION.Checked
                        'change start 20190927 kuwa ��������ɕ�����
                        'If Trim(.txtORDER_OMISSION.Text) = vbNullString Or CDbl(Trim(.txtORDER_OMISSION.Text)) = 0 Then
                        If Trim(.txtORDER_OMISSION.Text) = vbNullString Then
                            .txtORDER_OMISSION.Text = " " '�t�H�[�J�X�p
                            'change end 20190927 kuwa
                            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "103")
                            .txtORDER_OMISSION.Focus()
                            GoTo EXIT_STEP
                            'add start 20190927 kuwa ���ڂ̏����ǉ�
                        ElseIf CDbl(Trim(.txtORDER_OMISSION.Text)) = 0 Then
                            ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "103")
                            .txtORDER_OMISSION.Focus()
                            GoTo EXIT_STEP
                            'add end 20190927 kuwa
                        End If
                End Select
            End If

            'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "104") = MsgBoxResult.Yes Then
                'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_ON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call D0.Mouse_ON()
                '//��ʕ\���ɕK�v�ȃf�[�^���擾���\������
                If Not HKKET141M.Get_DisplayData Then
                    GoTo EXIT_STEP
                End If
            Else
                GoTo EXIT_STEP
            End If

        End With

        Chk_InputDetail = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_OFF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_IndividualIniFile
    '//*
    '//* <�߂�l>
    '//*              True    :�Ǎ��݂n�j
    '//*              False   :�Ǎ��݂d�q�q
    '//*
    '//* <��  ��>     ���ږ�             I/O      ���e
    '//*
    '//* <��  ��>
    '//*    �A�v���P�[�V�����ŗL�����ݒ�t�@�C��(INI̧��)�̓Ǎ��ݏ���
    '//*****************************************************************************************
    Public Function Get_IndividualIniFile() As Boolean
        '2019/04/12 DEL START
        'Dim gvcst_IniFilePath As Object
        '2019/04/12 DEL E N D

        Const PROCEDURE As String = "Get_IndividualIniFile"

        Dim wk_String As String
        Dim str_Key As String
        Dim str_Path As String

        On Error GoTo ONERR_STEP

        Get_IndividualIniFile = False

        wk_String = ""

        '��PATH�擾
        '// 2015/05/29 UPD STT
        '    str_Path = GetFullPath(gvcst_IniFilePath)
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcst_IniFilePath �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'str_Path = gvcst_IniFilePath
        str_Path = Application.StartupPath & "\SSSWIN.INI"
        '2019/04/12 CHG E N D
        '// 2015/05/29 UPD END

        '//-------------------------------------------------------------

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH1"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath1 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME1"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName1 = wk_String

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH2"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath2 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME2"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName2 = wk_String

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH3"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath3 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME3"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName3 = wk_String

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH4"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath4 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME4"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName4 = wk_String

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH5"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath5 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME5"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName5 = wk_String

        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH6"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath6 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME6"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName6 = wk_String

        '// V2.30�� ADD
        '//�t�@�C���p�X �擾
        str_Key = "FILEPATH7"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFilePath7 = wk_String

        '//�t�@�C����   �擾
        str_Key = "FILENAME7"
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.GetIniString �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        wk_String = D0.GetIniString(gvcstJOB_ID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If

        gvstrFileName7 = wk_String
        '// V2.30�� ADD

        '//-------------------------------------------------------------

        Get_IndividualIniFile = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ERROR_STEP:
        MsgBox("�y" & Trim(gvcstJOB_Titl) & "�z�͂h�m�h�t�@�C���̎擾�Ɏ��s���܂����B�����𒆎~���܂��B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, My.Application.Info.Title)
        GoTo EXIT_STEP
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function


    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Upd_IMPORT
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*            str_Dialog          STRING          i       CSV�G���[�������ɕ\������t�@�C����
    '//*
    '//* <��  ��>
    '//*
    '//*****************************************************************************************
    Public Function Upd_IMPORT(ByVal str_Dialog As String) As Boolean
        'delete start 20190930 kuwa Upd_IMPORT(CSV�捞�̃p�����[�^�[�ϊ��J�n)�Ȃɂ�����΂������猩�����B
        'Dim gvcstInputCls As Object
        'Dim ORATYPE_NUMBER As Object
        'Dim ORAPARM_OUTPUT As Object
        'Dim gvstrCLTID As Object
        'Dim ORATYPE_CHAR As Object
        'Dim ORAPARM_INPUT As Object
        'Dim gvstrOPEID As Object
        'delete end 20190930 kuwa

        Const PROCEDURE As String = "Upd_IMPORT"

        'UPGRADE_ISSUE: ListItem �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/11 DEL START
        'Dim objLitem As ListItem
        '2019/04/11 DEL E N D
        Dim intRtnCd As Short
        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset


        Upd_IMPORT = False

        On Error GoTo ONERR_STEP
        'add start 20190930 kwua 
        Dim cmd As New OracleCommand
        cmd.Connection = CON
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "HKKPL15.HKKPL15B"
        '//PL/SQL���Ăԁi�O�����j
        '//���Ұ��̸ر
        'change start 20190930 kuwa Parameters.Remove�̏�������
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("RTNCD")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("PARA_PATH")
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Remove("PARA_FILE_ID")
        cmd.Parameters.Clear()
        'change end 20190930 kuwa

        '//���O�C�����[�U�[�h�c
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("PARA_OPEID", gvstrOPEID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR
        Dim inP_OPEID As OracleParameter = New OracleParameter("P_OPEID", OracleDbType.Char, ParameterDirection.Input)
        inP_OPEID.Value = gvstrOPEID
        cmd.Parameters.Add(inP_OPEID)
        'change end 20190930 kuwa

        '//�[���ԍ�
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("PARA_CLTID", gvstrCLTID, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
        Dim inP_CLTID As OracleParameter = New OracleParameter("P_CLTID", OracleDbType.Char, ParameterDirection.Input)
        inP_CLTID.Value = gvstrCLTID
        cmd.Parameters.Add(inP_CLTID)
        'change end 20190930 kuwa

        '//�t�@�C���p�X
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("PARA_PATH", gvstrFilePath1, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("PARA_PATH").serverType = ORATYPE_CHAR
        Dim inP_PATH As OracleParameter = New OracleParameter("P_PATH", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_PATH.Value = gvstrFilePath1
        cmd.Parameters.Add(inP_PATH)
        'change end 20190930 kuwa

        '//�t�@�C���h�c
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("PARA_FILE_ID", gvstrFileName1, ORAPARM_INPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_CHAR �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("PARA_FILE_ID").serverType = ORATYPE_CHAR
        Dim inP_FILE_ID As OracleParameter = New OracleParameter("P_FILE_ID", OracleDbType.Varchar2, ParameterDirection.Input)
        inP_FILE_ID.Value = gvstrFileName1
        cmd.Parameters.Add(inP_FILE_ID)
        'change end 20190930 kuwa

        '//�߂�l
        intRtnCd = 0
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g ORATYPE_NUMBER �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER
        Dim RTNCD As OracleParameter = New OracleParameter("RTNCD", OracleDbType.Decimal, ParameterDirection.ReturnValue)
        RTNCD.Value = 0
        cmd.Parameters.Add(RTNCD)
        'change end 20190930 kuwa

        '//PL/SQL���ĂԁiMAIN�j
        'change start 20190930 kuwa
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'clsOra.OraExecute("BEGIN :RTNCD := HKKPL15.HKKPL15B(" & ":PARA_OPEID,:PARA_CLTID,:PARA_PATH,:PARA_FILE_ID); " & "END;", , PROCEDURE)
        cmd.ExecuteNonQuery()

        '//�߂�l�ُ�
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change start 20190930 kuwa
        'Select Case clsOra.OraDatabase.Parameters("RTNCD").Value
        Select Case RTNCD.Value
            'change end 20190930 kuwa
            Case 0
            Case 1
                '            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "117", "�G���[�i�[�t�@�C�����F" & gvstrFilePath1 & "\" & gvstrFileName1 & "_ERR.csv"
                'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "117", "�G���[�i�[�t�@�C�����F" & str_Dialog)
            Case 9
                'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.MsgLibrary �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "123")
                GoTo EXIT_STEP
        End Select

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & " SELECT            " & vbCrLf
        strSQL = strSQL & "   HKKTRA.*        " & vbCrLf
        strSQL = strSQL & ",  HINMTA.HINNMA   " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZAIRNK   " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZNKURITK " & vbCrLf
        strSQL = strSQL & ",  HINMTA.ZNKSRETK " & vbCrLf
        strSQL = strSQL & ",  HINMTA.MDLCL    " & vbCrLf
        strSQL = strSQL & "FROM   HKKWTA HKKTRA" & vbCrLf
        strSQL = strSQL & "        ,HINMTA    " & vbCrLf
        strSQL = strSQL & " WHERE  HKKTRA.HINCD    = HINMTA.HINCD " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & " AND    HKKTRA.OPEID    = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & " AND    HKKTRA.CLTID    = " & D0.Edt_SQL("S", gvstrCLTID) & vbCrLf

        strSQL = strSQL & " AND    HKKTRA.WRTFSTDT = TO_CHAR(SYSDATE,'YYYYMMDD')   " & vbCrLf

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Not clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE) Then
            GoTo EXIT_STEP
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Clear()
        HKKET141F.lvwMEISAI.Items.Clear()
        '2019/04/11 CHG E N D

        '2019/04/11 CHG START
        ''UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Do Until clsOra.OraEOF(objRec)
        '    'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem = HKKET141F.lvwMEISAI.ListItems.Add
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(1) = "" '//�x���N��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(2) = D0.Chk_Null(objRec("HINCD")) '//���i����
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(3) = D0.Chk_Null(objRec("HINNMA")) '//�^��
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(4) = D0.Chk_Null(objRec("MDLCL")) '//���Ƌ敪
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(5) = D0.Chk_Null(objRec("ZAIRNK")) '//�݌��ݸ
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(6) = " " '//���Y���~
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(7) = " " '//�̔���~
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(8) = " " '//���݌ɐ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(9) = " " '//���󒍐�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(10) = " " '//�������݌ɐ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(11) = " " '//�����󒍐�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(12) = " " '//�݌Ɍ���
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(13) = " " '//���Ϗo�ɐ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(14) = " " '//�݌ɐ�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(15) = " " '//���S�݌ɐ؂�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(16) = " " '//�݌ɐ؂�
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(17) = " " '//�����\�萔
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(18) = " " '//���ؗ]����
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(19) = " " '//����LT
        '    'UPGRADE_WARNING: �I�u�W�F�N�g objLitem.SubItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    objLitem.SubItems(20) = " " '//���i�Q
        '    '//��ں��ތ���
        '    'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraMoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    clsOra.OraMoveNext(objRec)
        'Loop
        With HKKET141F.lvwMEISAI
            Do Until clsOra.OraEOF(objRec)
                .Items.Add("")
                .Items(0).SubItems.Add("") '//�x���N��
                .Items(1).SubItems.Add(D0.Chk_Null(objRec("HINCD"))) '//���i����
                .Items(2).SubItems.Add(D0.Chk_Null(objRec("HINNMA"))) '//�^��
                .Items(3).SubItems.Add(D0.Chk_Null(objRec("MDLCL"))) '//���Ƌ敪
                .Items(4).SubItems.Add(D0.Chk_Null(objRec("ZAIRNK"))) '//�݌��ݸ
                .Items(5).SubItems.Add(" ") '//���Y���~
                .Items(6).SubItems.Add(" ") '//�̔���~
                .Items(7).SubItems.Add(" ") '//���݌ɐ�
                .Items(8).SubItems.Add(" ") '//���󒍐�
                .Items(9).SubItems.Add(" ") '//�������݌ɐ�
                .Items(10).SubItems.Add(" ") '//�����󒍐�
                .Items(11).SubItems.Add(" ") '//�݌Ɍ���
                .Items(12).SubItems.Add(" ") '//���Ϗo�ɐ�
                .Items(13).SubItems.Add(" ") '//�݌ɐ�
                .Items(14).SubItems.Add(" ") '//���S�݌ɐ؂�
                .Items(15).SubItems.Add(" ") '//�݌ɐ؂�
                .Items(16).SubItems.Add(" ") '//�����\�萔
                .Items(17).SubItems.Add(" ") '//���ؗ]����
                .Items(18).SubItems.Add(" ") '//����LT
                .Items(19).SubItems.Add(" ") '//���i�Q
            Loop

        End With
        '2019/04/11 CHG E N D

        '// �������̓��[�h
        'UPGRADE_WARNING: �I�u�W�F�N�g gvcstInputCls.Detail1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        gvintInputCls = gvcstInputCls.Detail1
        '//���ړ��͐���ݒ�
        Call HKKET141M.Set_InputControl(gvintInputCls)

        '// 2007/02/24 �� DEL
        ''''    HKKET141F.SetFocus
        '// 2007/02/24 �� DEL
        'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.FullRowSelect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        HKKET141F.lvwMEISAI.FullRowSelect = True
        'UPGRADE_WARNING: �I�u�W�F�N�g HKKET141F.lvwMEISAI.ListItems �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/11 CHG START
        'HKKET141F.lvwMEISAI.ListItems.Item(1).Selected = True
        HKKET141F.lvwMEISAI.Items(0).Selected = True
        '2019/04/11 CHG E N D

        Upd_IMPORT = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        '//���Ұ��̸ر
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraDatabase.Parameters.Remove("RTNCD")
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraDatabase.Parameters.Remove("PARA_OPEID")
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraDatabase.Parameters.Remove("PARA_CLTID")
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraDatabase.Parameters.Remove("PARA_PATH")
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraDatabase.Parameters.Remove("PARA_FILE_ID")

        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    DelHKKWTA
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �̔��v��v���폜����
    '//*****************************************************************************************
    Public Function DelHKKWTA() As Boolean
        '2019/04/16 DEL START
        'Dim gvstrOPEID As Object
        '2019/04/16 DEL E N D

        Const PROCEDURE As String = "DelHKKWTA"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset
        Dim i As Short

        DelHKKWTA = False

        On Error GoTo ONERR_STEP

        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_ON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_ON()

        '//��ݻ޸��ݐ���J�n
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraBeginTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        ''clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/12 CHG E N D

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "DELETE HKKWTA                       " & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strSQL = strSQL & "WHERE  OPEID     = " & D0.Edt_SQL("S", gvstrOPEID) & vbCrLf
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraExecute �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraExecute(strSQL)
        Call DB_Execute(strSQL)
        '2019/04/12 CHG E N D

        '//��ݻ޸��ݐ���J�n
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCommitTrans �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/12 CHG E N D

        DelHKKWTA = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g D0.Mouse_OFF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call D0.Mouse_OFF()
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraRollback()
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Ctr_END
    '//*
    '//* <�߂�l>     �^          ����
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*
    '//* <��  ��>
    '//*    �v���O�����̏I������
    '//*****************************************************************************************
    Public Sub Ctr_END()
        '2019/04/11 DEL START
        'Dim gvstrOPEID As Object
        'Dim ChkHTATRA As Object
        'Dim SSSWIN_LOGWRT As Object
        '2019/04/11 DEL E N D
        '// ����������������������������������������
        '// 2008/01/24 START
        Call SSSWIN_LOGWRT("�v���O�����I��")
        '// 2008/01/24 END
        '// ����������������������������������������

        '//�f�[�^�x�[�X�ڑ�����(ORACLE���ް)
        Call ChkHTATRA(gvstrOPEID, "9", gvcstJOB_ID)
        '//�f�[�^�x�[�X�ڑ�����(ORACLE���ް)
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraDisConnect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/15 CHG START
        'Call clsOra.OraDisConnect()
        Call DB_CLOSE(CON)
        '2019/04/15 CHG E N D
        '//���ʃI�u�W�F�N�g�̉��
        Call Ctr_Object(False)
        '//�v���O�����I��
        End

    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Run_DialogBox
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �_�C�A���O�{�b�N�X���N�����t�@�C�������擾����
    '//*****************************************************************************************
    Public Function Run_DialogBox(ByRef pobjCommonDiaLog As Object, ByRef pstr_FilePath As String, ByRef pstr_FileName As String, Optional ByVal pintMode As Short = 1) As Boolean
        Dim cdlCancel As Object
        Dim cdlOFNFileMustExist As Object
        Dim cdlOFNOverwritePrompt As Object

        Const PROCEDURE As String = "Run_DialogBox"

        Dim i As Short
        Dim strWorkTemp As String

        Run_DialogBox = False

        On Error GoTo ONERR_STEP

        '//�_�C�A���O�{�b�N�X�̋N��
        If pintMode = 1 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.Filter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.Filter = "�b�r�u �t�@�C�� (*.csv)|*.csv"
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.DefaultExt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.DefaultExt = ".csv"
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.Flags �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g cdlOFNOverwritePrompt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190926 kuwa VB6��CommonDialog��.Flags�v���p�e�B��.NET�ɂ͑��݂��Ȃ����߁B
            'pobjCommonDiaLog.Flags = cdlOFNOverwritePrompt
            pobjCommonDiaLog.CheckFileExists = True�@'.CheckFileExists�̋K��l��True�ł��邽��
            'change end 20190926 kuwa
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.FileName = pstr_FileName
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.CancelError �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'delete start 20190926 kuwa CommonDialog�̑�ւƂȂ���̂�.NET�ɂ͑��݂��Ȃ����ߍ폜
            'pobjCommonDiaLog.CancelError = True
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.ShowSave �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'pobjCommonDiaLog.ShowSave()
            'delete end 20190926 kuwa
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.Filter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.Filter = "�b�r�u �t�@�C�� (*.csv)|*.csv"
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.DefaultExt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.DefaultExt = ".csv"
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.Flags �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g cdlOFNFileMustExist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190926 kuwa VB6��CommonDialog��.Flags�v���p�e�B��.NET�ɂ͑��݂��Ȃ����߁B
            'pobjCommonDiaLog.Flags = cdlOFNFileMustExist
            pobjCommonDiaLog.CheckFileExists = True�@'.CheckFileExists�̋K��l��True�ł��邽��
            'change end 20190926 kuwa
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pobjCommonDiaLog.FileName = pstr_FileName
            'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.CancelError �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'delete start 20190926 kuwa CommonDialog�̑�ւƂȂ���̂�.NET�ɂ͑��݂��Ȃ����ߍ폜
            'pobjCommonDiaLog.CancelError = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.ShowOpen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'pobjCommonDiaLog.ShowOpen()
            'delete end 20190926 kuwa
        End If

        '//�_�C�A���O�{�b�N�X�̓��͓��e�m�F
        'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If pobjCommonDiaLog.FileName = "" Then
            GoTo EXIT_STEP
        End If

        '//�l��Ԃ�
        'UPGRADE_WARNING: �I�u�W�F�N�g pobjCommonDiaLog.FileName �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        strWorkTemp = pobjCommonDiaLog.FileName
        For i = Len(strWorkTemp) To 1 Step -1
            If Mid(strWorkTemp, i, 1) = "\" Then
                pstr_FilePath = Mid(strWorkTemp, 1, i)
                pstr_FileName = Mid(strWorkTemp, i + 1)
                Exit For
            End If
        Next i

        Run_DialogBox = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g cdlCancel �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Err.Number = cdlCancel Then
            Resume EXIT_STEP
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function

    '// 2007/02/24 �� ADD STR
    '//****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    SetFormInitOrg
    '//*
    '//* <�߂�l>
    '//*
    '//* <��  ��>     ���ږ�              I/O      ���e
    '//*              pm_Form             I       �t�H�[��
    '//*              pm_Kbn              I       �t�H�[���\�����@�敪
    '//*                                          0:�t�H�[�����f�t�H���g�T�C�Y�ɐݒ�
    '//*                                                              1:�t�H�[���T�C�Y��ݒ肵�Ȃ�
    '//* <��  ��>
    '//*    ��ʂ̏����ݒ�
    '//*****************************************************************************************
    Public Sub SetFormInitOrg(ByVal pm_Form As System.Windows.Forms.Form, Optional ByVal pm_Kbn As Short = 0)

        Const PROCEDURE As String = "SetFormInitOrg"

        Dim i As Short

        On Error GoTo ONERR_STEP

        With pm_Form
            If pm_Kbn = 0 Then
                .Height = VB6.TwipsToPixelsY(11520) '//����
                .Width = VB6.TwipsToPixelsX(15360) '//��
            End If

            '//��ʕ\�����
            .WindowState = System.Windows.Forms.FormWindowState.Normal

            '//�t�H�[���̃L�[�{�[�h�C�x���g���Ɏ��s
            .KeyPreview = True

            'UPGRADE_WARNING: IsEmpty �́AIsNothing �ɃA�b�v�O���[�h����A�V�������삪�w�肳��܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
            If IsNothing(gvvntTop) Then
                '//��ʒ����ɕ\���i�Z���^�����O�j
                .Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
                .Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
            Else
                '//��ʕۑ��ʒu�̒l�ŕ\��
                'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .Top = VB6.TwipsToPixelsY(gvvntTop)
                'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .Left = VB6.TwipsToPixelsX(gvvntLeft)
            End If

            'UPGRADE_WARNING: �I�u�W�F�N�g gvvntLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            gvvntLeft = VB6.PixelsToTwipsX(.Left)
            'UPGRADE_WARNING: �I�u�W�F�N�g gvvntTop �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            gvvntTop = VB6.PixelsToTwipsY(.Top)

        End With

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraRollback �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        clsOra.OraRollback()
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub

    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Ctr_Setfocus
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:�ύX�L�� , False:�ύX����
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    �w�肳�ꂽ�I�u�W�F�N�g�ɃZ�b�g�t�H�[�J�X����
    '//*****************************************************************************************
    Public Sub Ctr_Setfocus(ByVal pmoSetFocusObject As Object)

        Const PROCEDURE As String = "Ctr_Setfocus"

        On Error Resume Next

        'UPGRADE_WARNING: �I�u�W�F�N�g pmoSetFocusObject.SetFocus �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pmoSetFocusObject.SetFocus()

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Sub
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Sub
    '// 2007/02/24 �� ADD STR

    '''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
    '//*****************************************************************************************
    '//*
    '//* <��  ��>
    '//*    Get_HidukeKanri
    '//*
    '//* <�߂�l>   �^                  ����
    '//*            Boolean             True:OK , False:Error
    '//*
    '//* <��  ��>   ���ږ�              �^              I/O     ���e
    '//*
    '//* <��  ��>
    '//*    ���t�Ǘ�TBL�̉^�p���t���擾����
    '//*****************************************************************************************
    Public Function Get_HidukeKanri(ByRef pstrUNYDT As String) As Boolean

        Const PROCEDURE As String = "Get_HidukeKanri"

        Dim strSQL As String
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim objRec As OraDynaset

        Get_HidukeKanri = False

        On Error GoTo ONERR_STEP

        ' SQL���̍쐬
        strSQL = ""
        strSQL = strSQL & "SELECT UNYDT " & vbCrLf
        strSQL = strSQL & "FROM   UNYMTA " & vbCrLf

        ' �f�[�^�擾
        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCreateDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'clsOra.OraCreateDyn(strSQL, objRec, , PROCEDURE)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 CHG E N D

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraEOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 CHG START
        'If Not clsOra.OraEOF(objRec) Then
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '2019/04/12 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g D0.Chk_Null �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/04/12 CHG START
            'pstrUNYDT = D0.Chk_Null(objRec("UNYDT"))
            pstrUNYDT = D0.Chk_Null(dt.Rows(0)("UNYDT"))
            '2019/04/12 CHG E N D
        Else
            pstrUNYDT = ""
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g clsOra.OraCloseDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/04/12 DEL START
        'clsOra.OraCloseDyn(objRec)
        '2019/04/12 DEL E N D

        Get_HidukeKanri = True

        '----------------------------------------------------------------------------------------
EXIT_STEP:
        On Error GoTo 0
        Exit Function
        '----------------------------------------------------------------------------------------
ONERR_STEP:
        'UPGRADE_WARNING: �I�u�W�F�N�g ClsMessage.RuntimeErrorMsg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ClsMessage.RuntimeErrorMsg(Err.Description, PROCEDURE)
        Resume EXIT_STEP
    End Function
    '''' ADD 2009/11/26  FKS) T.Yamamoto    End
End Module