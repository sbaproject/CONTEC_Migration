Option Strict Off
Option Explicit On
Module GET_DATA

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMSGCM_SEARCH
    '   �T�v�F  �V�X�e�����b�Z�[�W����
    '   �����F  pin_strMSGKB    : ���b�Z�[�W���
    '           pin_strMSGNM    : ���b�Z�[�W�A�C�e��
    '           pin_strMSGSQ�@�@: ���b�Z�[�W�A��
    '           pot_DB_SYSTBH   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/09/24 start
    '    Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short

    '        Dim strSQL As String
    '        Dim intData As Short
    '        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody_LC As U_Ody

    '        On Error GoTo ERR_DSPMSGCM_SEARCH

    '        DSPMSGCM_SEARCH = 9

    '        strSQL = ""
    '        strSQL = strSQL & "Select * From SYSTBH"
    '        strSQL = strSQL & " Where MSGKB = " & "'" & CF_Ora_Sgl(pin_strMSGKB) & "'"
    '        strSQL = strSQL & "   And MSGNM = " & "'" & CF_Ora_Sgl(pin_strMSGNM) & "'"
    '        strSQL = strSQL & "   And MSGSQ = " & "'" & CF_Ora_Sgl(pin_strMSGSQ) & "'"

    '        'DB�A�N�Z�X
    '        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    '        If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '            '�擾�f�[�^�Ȃ�
    '            DSPMSGCM_SEARCH = 1
    '            GoTo END_DSPMSGCM_SEARCH
    '        End If

    '        If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '            With pot_DB_SYSTBH
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.MSGKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .MSGKB = CF_Ora_GetDyn(Usr_Ody_LC, "MSGKB", "") '���b�Z�[�W���
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.MSGNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .MSGNM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGNM", "") '���b�Z�[�W�A�C�e��
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.MSGSQ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .MSGSQ = CF_Ora_GetDyn(Usr_Ody_LC, "MSGSQ", "") '���b�Z�[�W�A��
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.BTNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .BTNKB = CF_Ora_GetDyn(Usr_Ody_LC, "BTNKB", 0) '�{�^�����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.BTNON �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .BTNON = CF_Ora_GetDyn(Usr_Ody_LC, "BTNON", 0) '�{�^�������l
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.ICNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ICNKB = CF_Ora_GetDyn(Usr_Ody_LC, "ICNKB", 0) '�A�C�R�����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .MSGCM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGCM", "") '���b�Z�[�W
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.COLSQ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .COLSQ = CF_Ora_GetDyn(Usr_Ody_LC, "COLSQ", "") '�F�V�[�P���X
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.OPEID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "") '�ŏI��Ǝ҃R�[�h
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.CLTID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "") '�N���C�A���g�h�c
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.WRTTM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "") '��ѽ����(����)
    '                'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_SYSTBH.WRTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "") '��ѽ����(���t)
    '            End With
    '        End If

    '        DSPMSGCM_SEARCH = 0

    'END_DSPMSGCM_SEARCH:

    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '        Exit Function

    'ERR_DSPMSGCM_SEARCH:
    '        GoTo END_DSPMSGCM_SEARCH

    '    End Function
    '2019/09/24 end

End Module