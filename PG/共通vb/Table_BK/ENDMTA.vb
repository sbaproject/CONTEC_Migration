Option Strict Off
Option Explicit On
Module ENDMTA_DBM
    '==========================================================================
    '   MEIMTA.DBM   �G���h���[�U�}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_ENDMTA
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '�`�[�폜�敪          0
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public ENDUSRCD As String '�G���h���[�U�R�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(255), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=255)> Public ENDUSRNM As String '�G���h���[�U��
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FOPEID As String '����o�^�S����ID
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public FCLTID As String '����o�^�N���C�A���gID
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String '��ѽ����(����o�^����)
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String '��ѽ����(����o�^���t)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�X�V�S���҃R�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�X�V�N���C�A���g�h�c
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(�X�V����)
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(�X�V���t)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UOPEID As String '�o�b�`�X�V�S���҃R�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public UCLTID As String '�o�b�`�X�V�N���C�A���gID
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public UWRTTM As String '��ѽ����(�o�b�`�X�V����)
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UWRTDT As String '��ѽ����(�o�b�`�X�V���t)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public PGID As String '��۸���ID
    'End Structure
    'Public DB_ENDMTA As TYPE_DB_ENDMTA
    'Public DBN_ENDMTA As Short
    '20190611 del end


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_ENDMTA_Clear
    '   �T�v�F  �G���h���[�U�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_ENDMTA_Clear(ByRef pot_DB_ENDMTA As TYPE_DB_ENDMTA)
    '	Dim Clr_DB_ENDMTA As TYPE_DB_ENDMTA
    '	'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_ENDMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	pot_DB_ENDMTA = Clr_DB_ENDMTA
    '   End Sub

    '20190320 DEL START ��
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_ENDMTA_SetData
    '   �T�v�F  ���̃}�X�^�\���̃f�[�^�ޔ�
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_ENDMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_ENDMTA As TYPE_DB_ENDMTA)

    '	'�f�[�^�ޔ�
    '	With pot_DB_ENDMTA
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.ENDUSRCD = CF_Ora_GetDyn(pin_Usr_Ody, "ENDUSRCD", "") '�G���h���[�U�R�[�h
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.ENDUSRNM = CF_Ora_GetDyn(pin_Usr_Ody, "ENDUSRNM", "") '�G���h���[�U��
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '����o�^�S����ID
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '����o�^�N���C�A���gID
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '��ѽ����(����o�^����)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '��ѽ����(����o�^���t)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�X�V�S���҃R�[�h
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�X�V�N���C�A���g�h�c
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(�X�V����)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(�X�V���t)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") '�o�b�`�X�V�S���҃R�[�h
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") '�o�b�`�X�V�N���C�A���gID
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") '��ѽ����(�o�b�`�X�V����)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") '��ѽ����(�o�b�`�X�V���t)
    '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") '��۸���ID
    '	End With

    'End Sub
    '20190320 DEL END ��


    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   ���́F  Function ENDUSRNM_SEARCH3
    '   '   �T�v�F  �G���h���[�U�}�X�^��薼�̎擾
    '   '             ���݂��Ȃ��ꍇ�A���̃}�X�^�Q��
    '   '   �����Fpin_strMEICDA    : �R�[�h
    '   '           pin_LoadingFlg     : ����/�󒍏��Ǎ������ۂ����f����
    '   '           pot_strENDUSRNM  : ��������
    '   '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   '   ���l�F
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Public Function ENDUSRNM_SEARCH3(ByVal pin_strENDUSRCD As String, ByVal pin_LoadingFlg As Short, ByRef pot_strENDUSRNM As String) As Short


    '       'Dim intData As Short
    '       ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '       'Dim Usr_Ody_LC As U_Ody

    '       'On Error GoTo ERR_ENDUSRNM_SEARCH3
    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String

    '           ENDUSRNM_SEARCH3 = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select "
    '           strSQL = strSQL & "        Rtrim(ENDUSRNM) NAME "
    '           strSQL = strSQL & "   from ENDMTA "
    '           strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
    '           strSQL = strSQL & "   and  Trim(ENDUSRCD) = '" & Trim(pin_strENDUSRCD) & "' "

    '           'DB�A�N�Z�X
    '           '2019/03/18 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '2019/03/18 CHG E N D

    '           '2019/03/18 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               '2019/03/18 CHG E N D
    '               If pin_LoadingFlg = 1 Then
    '                   '����/�󒍏��Ǎ����ŃG���h���[�U�}�X�^�ɂȂ��ꍇ���̃}�X�^����擾
    '                   strSQL = ""
    '                   strSQL = strSQL & " Select "
    '                   strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
    '                   strSQL = strSQL & "   from MEIMTA "
    '                   strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
    '                   strSQL = strSQL & "   and  KEYCD  = '114' "
    '                   strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strENDUSRCD) & "' "

    '                   'DB�A�N�Z�X
    '                   '2019/03/18 CHG START
    '                   'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '                   dt = Nothing
    '                   dt = DB_GetTable(strSQL)
    '                   '2019/03/18 CHG E N D

    '                   '2019/03/18 CHG START
    '                   'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '                   If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '                       '2019/03/18 CHG E N D
    '                       '�擾�f�[�^�Ȃ�
    '                       pot_strENDUSRNM = ""
    '                       'ENDUSRNM_SEARCH3 = 1
    '                       'GoTo END_ENDUSRNM_SEARCH3
    '                       Exit Function
    '                   End If
    '               Else
    '                   '����/�󒍏��Ǎ����łȂ��ꍇ
    '                   '�擾�f�[�^�Ȃ�
    '                   pot_strENDUSRNM = ""
    '                   'ENDUSRNM_SEARCH3 = 1
    '                   'GoTo END_ENDUSRNM_SEARCH3
    '                   Exit Function
    '               End If
    '           End If

    '           '�擾�f�[�^�ޔ�
    '           'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '           'pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
    '           pot_strENDUSRNM = DB_NullReplace(dt.Rows(0)("NAME"), "")

    '           ENDUSRNM_SEARCH3 = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRNM_SEARCH3" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '       End Try



    '       'END_ENDUSRNM_SEARCH3:
    '       '            '�N���[�Y
    '       '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '       '            Exit Function

    '       'ERR_ENDUSRNM_SEARCH3:

    '   End Function
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Function ENDUSRCD_SEARCH
    ''   �T�v�F  ���ό��o���ރg�������G���h���[�U�R�[�h�擾
    ''   �����F�@pDATNO    : �`�[�ԍ�
    ''             pMITNO     : ���ϔԍ�
    ''             pMITNOV   : �Ő�
    ''             pin_strENDUSRCD : �G���h���[�U�R�[�h
    ''   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function ENDUSRCD_SEARCH(ByVal pDATNO As String, ByVal pMITNO As String, ByVal pMITNOV As String, ByRef pin_strENDUSRCD As String) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String

    '           ENDUSRCD_SEARCH = 9

    '           If pDATNO = "" Then
    '               strSQL = ""
    '               strSQL = strSQL & "   Select "
    '               strSQL = strSQL & "   Rtrim(ENDUSRCD) AS ENDUSRCD"
    '               strSQL = strSQL & "   from MITTHB "
    '               strSQL = strSQL & "   ,MITTHA"
    '               strSQL = strSQL & "   Where MITTHA.DATNO = MITTHB.DATNO"
    '               strSQL = strSQL & "   and MITTHB.DATNO = (SELECT DATNO from MITTHA"
    '               strSQL = strSQL & "   Where MITTHA.DATKB = 1"
    '               strSQL = strSQL & "   and  MITTHA.MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & "   and  MITTHA.MITNOV = '" & pMITNOV & "' )"
    '               strSQL = strSQL & "   and  MITTHB.MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & "   and  MITTHB.MITNOV = '" & pMITNOV & "' "
    '           Else
    '               strSQL = ""
    '               strSQL = strSQL & " Select "
    '               strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
    '               strSQL = strSQL & " from MITTHB "
    '               strSQL = strSQL & " Where DATNO  = '" & pDATNO & "' "
    '               strSQL = strSQL & " and  MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & " and  MITNOV = '" & pMITNOV & "' "
    '           End If

    '           'DB�A�N�Z�X
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               pin_strENDUSRCD = ""
    '               ENDUSRCD_SEARCH = 1
    '               Exit Function
    '           Else
    '               pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
    '           End If

    '           ENDUSRCD_SEARCH = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '       End Try


    '       'Dim intData As Short
    '       ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '       'Dim Usr_Ody_LC As U_Ody

    '       'On Error GoTo ERR_ENDUSRCD_SEARCH



    '       'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '       '	'�擾�f�[�^�Ȃ�
    '       '	pin_strENDUSRCD = ""
    '       '	ENDUSRCD_SEARCH = 1
    '       '	GoTo END_ENDUSRCD_SEARCH
    '       'End If

    '       ''�擾�f�[�^�ޔ�
    '       ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

    '       'END_ENDUSRCD_SEARCH: 
    '       '		'�N���[�Y
    '       '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '       '		Exit Function

    '       'ERR_ENDUSRCD_SEARCH: 

    'End Function
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Function ENDUSRCD_SEARCH2
    ''   �T�v�F  �G���h���[�U�R�t���e�[�u�����G���h���[�U�R�[�h�擾
    ''   �����F�@pJDNNO    : �󒍔ԍ�
    ''             pin_strENDUSRCD : �G���h���[�U�R�[�h
    ''   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function ENDUSRCD_SEARCH2(ByVal pJDNNO As String, ByRef pin_strENDUSRCD As String) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           'Dim intData As Short
    '           ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_ENDUSRCD_SEARCH2

    '           ENDUSRCD_SEARCH2 = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select "
    '           strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
    '           strSQL = strSQL & " from JDNTHE "
    '           strSQL = strSQL & " Where JDNNO  = '" & pJDNNO & "' "

    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               pin_strENDUSRCD = ""
    '               ENDUSRCD_SEARCH2 = 1
    '               Exit Function
    '           Else
    '               pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
    '           End If

    '           ''DB�A�N�Z�X
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '�擾�f�[�^�Ȃ�
    '           '    pin_strENDUSRCD = ""
    '           '    ENDUSRCD_SEARCH2 = 1
    '           '    GoTo END_ENDUSRCD_SEARCH2
    '           'End If

    '           ''�擾�f�[�^�ޔ�
    '           ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '           'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

    '           ENDUSRCD_SEARCH2 = 0

    '           'END_ENDUSRCD_SEARCH2:
    '           '            '�N���[�Y
    '           '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           '            Exit Function

    '           'ERR_ENDUSRCD_SEARCH2:
    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRCD_SEARCH2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '       End Try

    '   End Function
End Module