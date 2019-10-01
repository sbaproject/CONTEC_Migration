Option Strict Off
Option Explicit On
'2019/05/21 ADD START 
Imports VB = Microsoft.VisualBasic
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System
Imports System.Reflection
'2019/05/21 ADD E N D

Module mod_Ora

    Public gv_Oss As Object '//ORACLE�Z�b�V����
    Public gv_Odb As Object '//ORACLE�f�[�^�x�[�X

    '2019/05/13 CHG START
    ''UPGRADE_ISSUE: OraSessionClass �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    'Public OSession As OraSessionClass
    ''UPGRADE_ISSUE: OraDatabase �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    'Public ODatabase As OraDatabase
    ''UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    'Public Odynaset As OraDynaset
    Public ODatabase As Object
    Public Odynaset As Object
    '2019/05/13 CHG E N D

    '// ORACLE�ް��ް��ϐ�---------------------------
    '// �_�C�i�Z�b�g���\����
    Public Structure U_Ody
        Dim Obj_Ody As Object '//OraDynaset��޼ު��
        Dim Obj_Flds() As Object '//̨���޵�޼ު��
        Dim Lng_FldCnt As Integer '//̨���ސ�
        Dim Str_FldNm As String '//�t�B�[���h�ԍ���̨���ޖ�
    End Structure

    'OpenDatabase Method Options
    Public Const ORADB_DEFAULT As Integer = &H0
    Public Const ORADB_ORAMODE As Integer = &H1
    Public Const ORADB_NOWAIT As Integer = &H2
    Public Const ORADB_DBDEFAULT As Integer = &H4
    Public Const ORADB_DEFERRED As Integer = &H8
    Public Const ORADB_ENLIST_IN_MTS As Integer = &H10

    'CreateDynaset Method Options
    Public Const ORADYN_DEFAULT As Integer = &H0
    Public Const ORADYN_NO_AUTOBIND As Integer = &H1
    Public Const ORADYN_NO_BLANKSTRIP As Integer = &H2
    Public Const ORADYN_READONLY As Integer = &H4
    Public Const ORADYN_NOCACHE As Integer = &H8
    Public Const ORADYN_ORAMODE As Integer = &H10
    Public Const ORADYN_NO_REFETCH As Integer = &H20
    Public Const ORADYN_NO_MOVEFIRST As Integer = &H40
    Public Const ORADYN_DIRTY_WRITE As Integer = &H80

    '// ����
    Public gv_Int_OraErr As Short '//ORACLE�G���[�ԍ�
    Public gv_Str_OraErrText As String '//ORACLE�G���[�e�L�X�g



    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    F_Ora_Connect
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Boolean     True ...�ڑ�����
    '//*                         False...�ڑ����s
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*             pm_Oss              Object           O            ORACLE�Z�b�V����
    '//*             pm_Odb              Object           O            ORACLE�f�[�^�x�[�X
    '//*             pm_Host             String           I            �ڑ�������
    '//*             pm_UserID           String           I            ���[�U�[ID
    '//*             pm_Password         String           I            �p�X���[�h
    '//*             pm_Option           Long             I            �ڑ��I�v�V����
    '//* <��  ��>
    '//*    �����̏���ORACLE�ް��ް��ɐڑ����܂��B
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)           |�V�K�쐬
    '//**************************************************************************************
    Public Function F_Ora_Connect(ByRef pm_Oss As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean

        Dim Lng_Option As Integer '//���Ұ�

        On Error GoTo ERR_HANDLE

        F_Ora_Connect = False

        '// ���Ұ��̐ݒ�
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(pm_Option) = False Then
            Lng_Option = CInt(pm_Option)
        Else
            '//�f�t�H���g
            Lng_Option = ORADB_DEFAULT
        End If

        '// ���ɵ���ݍςȂ�ΐ�������
        If (pm_Oss Is Nothing) = False And (pm_Odb Is Nothing) = False Then
            F_Ora_Connect = True
            GoTo EXIT_HANDLE
        End If

        '// ORACLE�ް��ް��ɐڑ�
        pm_Oss = CreateObject("OracleInProcServer.XOraSession")
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Oss.dbopendatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pm_Odb = pm_Oss.dbopendatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)

        '//����I��
        F_Ora_Connect = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:

        '//ORACLE�G���[�ԍ��擾
        '    With pm_Odb
        ''        gv_Int_OraErr = .LastServerErr
        '        gv_Str_OraErrText = .LastServerErrText
        '        .LastServerErrReset
        '    End With
        '    GoTo EXIT_HANDLE

    End Function

    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    F_Ora_Connect2
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Boolean     True ...�ڑ�����
    '//*                         False...�ڑ����s
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*             pm_Oss              Object           O            ORACLE�Z�b�V����
    '//*             pm_Odb              Object           O            ORACLE�f�[�^�x�[�X
    '//*             pm_Host             String           I            �ڑ�������
    '//*             pm_UserID           String           I            ���[�U�[ID
    '//*             pm_Password         String           I            �p�X���[�h
    '//*             pm_Option           Long             I            �ڑ��I�v�V����
    '//* <��  ��>
    '//*    �����̏���ORACLE�ް��ް��ɐڑ����܂��B
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20091127|ECHO)           |�V�K�쐬
    '//**************************************************************************************
    '2019/05/13 CHG START
    'Public Function F_Ora_Connect2(ByRef pm_Osc As OraSessionClass, ByRef pm_Odb As OraDatabase, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
    Public Function F_Ora_Connect2(ByRef pm_Osc As Object, ByRef pm_Odb As Object, ByVal pm_Host As String, ByVal pm_UserID As String, ByVal pm_Password As String, Optional ByVal pm_Option As Integer = 0) As Boolean
        '2019/05/13 CHG E N D
        Dim Lng_Option As Integer '//���Ұ�

        On Error GoTo ERR_HANDLE

        F_Ora_Connect2 = False

        '// ���Ұ��̐ݒ�
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(pm_Option) = False Then
            Lng_Option = CInt(pm_Option)
        Else
            '//�f�t�H���g
            Lng_Option = ORADB_DEFAULT
        End If

        '// ���ɵ���ݍςȂ�ΐ�������
        If (pm_Osc Is Nothing) = False And (pm_Odb Is Nothing) = False Then
            F_Ora_Connect2 = True
            GoTo EXIT_HANDLE
        End If

        '// ORACLE�ް��ް��ɐڑ�
        pm_Osc = CreateObject("OracleInProcServer.XOraSession")
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Osc.OpenDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pm_Odb = pm_Osc.OpenDatabase(pm_Host, pm_UserID & "/" & pm_Password, Lng_Option)

        '//����I��
        F_Ora_Connect2 = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:

        '//ORACLE�G���[�ԍ��擾
        '    With pm_Odb
        ''        gv_Int_OraErr = .LastServerErr
        '        gv_Str_OraErrText = .LastServerErrText
        '        .LastServerErrReset
        '    End With
        '    GoTo EXIT_HANDLE

    End Function

    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    CF_Ora_CreateDyn
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Boolean     True ...����I��
    '//*                         False...�ُ�I��
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Odb             Object           O            ORACLE�f�[�^�x�[�X
    '//*              pm_Ody             U_Ody            O            �ް��ް����ð��فiհ�ް��`�j
    '//*              pm_SQL             String           I            SQL�ð����
    '//*              pm_Option          Variant          I            ��߼��[�ȗ���=&0]
    '//*
    '//* <��  ��>
    '//*    �Q�ƌn(SELECT)��SQL�ð���Ă����s���܂��B
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    Public Function CF_Ora_CreateDyn(ByRef pm_Odb As Object, ByRef pm_Ody As U_Ody, ByVal pm_SQL As String, Optional ByVal pm_Option As Object = Nothing) As Boolean

        Dim Int_Cnt As Integer '//�t�B�[���h�J�E���^
        Dim Lng_Option As Integer '//���Ұ��iORADYN_READONLY Or ORADYN_NOCACHE�Ȃǁj

        On Error GoTo ERR_HANDLE

        '// ���Ұ��̐ݒ�
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(pm_Option) = False Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Option �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Lng_Option = CInt(pm_Option)
        Else
            Lng_Option = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
        End If

        '// SQL�ð���Ă̎��s
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.CreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pm_Ody.Obj_Ody = pm_Odb.CreateDynaset(pm_SQL, Lng_Option)

        '//�\���̃f�t�H���g�l�ݒ�
        Erase pm_Ody.Obj_Flds
        pm_Ody.Lng_FldCnt = 0
        pm_Ody.Str_FldNm = ""

        If CF_Ora_EOF(pm_Ody) = False Then

            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pm_Ody.Lng_FldCnt = pm_Ody.Obj_Ody.Fields.Count

            ReDim pm_Ody.Obj_Flds(pm_Ody.Lng_FldCnt - 1)

            For Int_Cnt = 0 To pm_Ody.Lng_FldCnt - 1
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                pm_Ody.Obj_Flds(Int_Cnt) = pm_Ody.Obj_Ody.Fields(Int_Cnt)
                'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Flds().Name �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                pm_Ody.Str_FldNm = pm_Ody.Str_FldNm & VB6.Format(Int_Cnt, "0000") & ":" & UCase(pm_Ody.Obj_Flds(Int_Cnt).Name) & ":"
            Next

        End If

        '//����I��
        CF_Ora_CreateDyn = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:

        '//ORACLE�G���[�ԍ��擾
        With pm_Odb
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            gv_Int_OraErr = .LastServerErr
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            gv_Str_OraErrText = .LastServerErrText
            'UPGRADE_WARNING: �I�u�W�F�N�g pm_Odb.LastServerErrReset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .LastServerErrReset()
        End With
        GoTo EXIT_HANDLE

    End Function


    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    CF_Ora_GetDyn
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Variant      �擾�ް��̒l
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
    '//*              pm_Fld             String           I            �擾�Ώۃt�B�[���h��
    '//*              pm_Default         Variant          I            �f�t�H���g�l
    '//*              pm_Format          String           I            �t�H�[�}�b�g�`��
    '//* <��  ��>
    '//*    pm_Ody�̎w��t�B�[���h�̒l���擾���܂��B
    '//*    pm_Fld�ɂ̓t�B�[���h���ƃt�B�[���h�ԍ��̂ǂ���ł��w��ł��܂��B
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    Public Function CF_Ora_GetDyn(ByRef pm_Ody As U_Ody, ByVal pm_Fld As String, Optional ByVal pm_Default As Object = "", Optional ByVal pm_Format As String = "") As Object

        Dim Str_Format As String '// ̫�ϯČ`���w��
        Dim Int_FldType As Short '// ̨��������
        Dim Var_Value As Object '// �ް�
        Dim Str_FldNm As String '// ̨���ޖ�
        Dim Var_Default As Object '// �ް���NULL�̎��̏����l

        On Error GoTo ERR_HANDLE

        '// �ް���NULL�̎��̏����l�̐ݒ�
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Var_Default = pm_Default

        '// ̫�ϯČ`���w����Ҕ�
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If Not IsNothing(pm_Format) Then
            Str_Format = pm_Format
        Else
            Str_Format = ""
        End If
        '// �����upm_Format�v�̏����l���֐���`�Ŏw��

        '// ̨���ޖ��̎擾
        Str_FldNm = pm_Fld

        '�t�B�[���h�ԍ��݂̂Ŏ擾���邽�ߍ폜
        '    Str_FldNm = Mid$(pm_Ody.Str_FldNm, InStr(pm_Ody.Str_FldNm, ":" & UCase$(Str_FldNm) & ":") - 4, 4)

        '// ̨�������߂��ް����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Flds(CInt(Str_FldNm)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Var_Value = pm_Ody.Obj_Flds(CShort(Str_FldNm))

        '// ���t�^�Ȃ��̫�ϯČ`����YYYY/MM/DD�ɐݒ�

        '// �ް��̎擾
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(Var_Value) Then

            '*D*CF_Ora_GetDyn = Var_Default
            Select Case SSS_PrtID
                '���㌴���Ώƕ\(�o������),���㌴���Ώƕ\(�S��),���㌴���Ώƕ\(���ƕ���),
                '���㌴���Ώƕ\(�����),�������z���͕\
                Case ps_rptid_GNKPR01, ps_rptid_GNKPR02, ps_rptid_GNKPR03, ps_rptid_GNKPR04, ps_rptid_GNKPR13
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CF_Ora_GetDyn = ""
                    '��L�ȊO
                Case Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CF_Ora_GetDyn = Var_Default
            End Select

        Else
            If Str_Format = "" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CF_Ora_GetDyn = Var_Value
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CF_Ora_GetDyn = VB6.Format(Var_Value, Str_Format)
            End If
        End If

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:
        GoTo EXIT_HANDLE

    End Function

    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    CF_Ora_GetDyn
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Variant      �擾�ް��̒l
    '//*
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
    '//*              pm_Fld             String           I            �擾�Ώۃt�B�[���h��
    '//*              pm_Default         Variant          I            �f�t�H���g�l
    '//*              pm_Format          String           I            �t�H�[�}�b�g�`��
    '//* <��  ��>
    '//*    pm_Ody�̎w��t�B�[���h�̒l���擾���܂��B
    '//*    pm_Fld�ɂ̓t�B�[���h���ƃt�B�[���h�ԍ��̂ǂ���ł��w��ł��܂��B
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    Public Function CF_Ora_GetDyn2(ByVal pm_Fld As String, Optional ByVal pm_Default As Object = "", Optional ByVal pm_Format As String = "") As Object

        Dim Str_Format As String '// ̫�ϯČ`���w��
        Dim Int_FldType As Short '// ̨��������
        Dim Var_Value As Object '// �ް�
        Dim Str_FldNm As String '// ̨���ޖ�
        Dim Var_Default As Object '// �ް���NULL�̎��̏����l

        On Error GoTo ERR_HANDLE

        '// �ް���NULL�̎��̏����l�̐ݒ�
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Var_Default = pm_Default

        '// ̫�ϯČ`���w����Ҕ�
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If Not IsNothing(pm_Format) Then
            Str_Format = pm_Format
        Else
            Str_Format = ""
        End If
        '// �����upm_Format�v�̏����l���֐���`�Ŏw��

        '// ̨�������߂��ް����擾
        'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Var_Value = pm_Fld

        '// ���t�^�Ȃ��̫�ϯČ`����YYYY/MM/DD�ɐݒ�

        '// �ް��̎擾
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(Var_Value) Then

            '*D*CF_Ora_GetDyn = Var_Default
            Select Case SSS_PrtID
                '���㌴���Ώƕ\(�o������),���㌴���Ώƕ\(�S��),���㌴���Ώƕ\(���ƕ���),
                '���㌴���Ώƕ\(�����),�������z���͕\
                Case ps_rptid_GNKPR01, ps_rptid_GNKPR02, ps_rptid_GNKPR03, ps_rptid_GNKPR04, ps_rptid_GNKPR13
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CF_Ora_GetDyn2 = ""
                    '��L�ȊO
                Case Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g Var_Default �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    CF_Ora_GetDyn2 = Var_Default
            End Select

        Else
            If Str_Format = "" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CF_Ora_GetDyn2 = Var_Value
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Var_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                CF_Ora_GetDyn2 = VB6.Format(Var_Value, Str_Format)
            End If
        End If

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:
        GoTo EXIT_HANDLE

    End Function


    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    CF_Ora_EOF
    '//*
    '//* <�߂�l>     �^          ����
    '//*             Boolean     True ...EOF
    '//*                         False...EOF�ł͂Ȃ�
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
    '//* <��  ��>
    '//*    EOF�`�F�b�N���s���܂��B
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    Public Function CF_Ora_EOF(ByRef pm_Ody As U_Ody) As Boolean

        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CF_Ora_EOF = pm_Ody.Obj_Ody.EOF

    End Function

    '//**************************************************************************************
    '//*
    '//* <��  ��>
    '//*    GetChar
    '//*
    '//* <�߂�l>     �^          ����
    '//*             String       True ...EOF
    '//*                          False...EOF�ł͂Ȃ�
    '//* <��  ��>     ���ږ�             �^              I/O           ���e
    '//*              pm_Ody             U_Ody            I            �ް��ް����ð��فiհ�ް��`�j
    '//* <��  ��>
    '//*    po_Value��Null���̏ꍇ��""�ɕϊ��A�����łȂ��ꍇ�͂��̂܂܂̒l���Ԃ�
    '//*
    '//**************************************************************************************
    '//*�ύX����
    '//* �ް�ޮ�  |  ���t  | �X�V��        |���e
    '//* ---------|--------|---------------|------------------------------------------------*
    '//* 1.00     |20020715|FKS)           |�V�K�쐬
    '//**************************************************************************************
    'UPGRADE_NOTE: GetChar �� GetChar_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
    Public Function GetChar_Renamed(ByRef po_Value As String) As String

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(po_Value) Then
            GetChar_Renamed = ""
        Else
            GetChar_Renamed = po_Value
        End If

    End Function

    'add start 20190820 kuwa
    Public Function CF_Ora_CloseDyn(ByRef pm_Ody As U_Ody) As Boolean

        On Error GoTo ERR_HANDLE

        CF_Ora_CloseDyn = False

        If (pm_Ody.Obj_Ody Is Nothing) = False Then
            Erase pm_Ody.Obj_Flds
            'UPGRADE_NOTE: �I�u�W�F�N�g pm_Ody.Obj_Ody ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            pm_Ody.Obj_Ody = Nothing
        End If

        CF_Ora_CloseDyn = True

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:
        GoTo EXIT_HANDLE

    End Function

    Public Function CF_Ora_RecordCount(ByRef pm_Ody As U_Ody) As Double

        Dim Lng_Cnt As Integer '//�s��

        On Error GoTo ERR_HANDLE

        Lng_Cnt = -1

        '//�s���̎擾
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Ody.Obj_Ody.RecordCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Lng_Cnt = pm_Ody.Obj_Ody.RecordCount

        CF_Ora_RecordCount = Lng_Cnt

EXIT_HANDLE:
        On Error GoTo 0
        Exit Function

ERR_HANDLE:
        GoTo EXIT_HANDLE

    End Function

    Public gv_Odb_USR1 As Object '//ORACLE�f�[�^�x�[�X

    'add end 20190820 kuwa

End Module