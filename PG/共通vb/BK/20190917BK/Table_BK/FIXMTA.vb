Option Strict Off
Option Explicit On
Module FIXMTA_DBM
    '==========================================================================
    '   FIXMTA.DBM   �Œ�l�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_FIXMTA
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '�폜�敪
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public CTLCD As String '�Ǘ��R�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public CTLNM As String '�Ǘ�����
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public FIXVAL As String '�Œ�l
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(128), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=128)> Public REMARK As String '���l
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public RELFL As String '�A�g�t���O
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�ŏI��Ǝ҃R�[�h
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�N���C�A���g�h�c
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '�^�C���X�^���v�i���ԁj
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '�^�C���X�^���v�i���t�j
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String '�^�C���X�^���v�i�o�^���ԁj
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String '�^�C���X�^���v�i�o�^���j
    'End Structure
    '   Public DB_FIXMTA As TYPE_DB_FIXMTA
    'Public DBN_FIXMTA As Short
    '20190611 del end


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_FIXMTA_Clear
    '   �T�v�F  �Œ�l�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_FIXMTA_Clear(ByRef pDB_FIXMTA As TYPE_DB_FIXMTA)
    '    pDB_FIXMTA = Nothing
    'End Sub

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Function DSPCTLCD_SEARCH
    ''   �T�v�F  �Ǘ��R�[�h����
    ''   �����F  pin_strCTLCD  : �����ΏۊǗ��R�[�h
    ''           pot_DB_FIXMTA : ��������
    ''   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Short

    '    Dim li_MsgRtn As Integer

    '    Try
    '        Dim strSQL As String
    '        'Dim intData As Short
    '        ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        'Dim Usr_Ody As U_Ody

    '        'On Error GoTo ERR_DSPCTLCD_SEARCH

    '        DSPCTLCD_SEARCH = 9

    '        strSQL = ""
    '        strSQL = strSQL & " Select * "
    '        strSQL = strSQL & "   from FIXMTA "
    '        strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "

    '        'DB�A�N�Z�X
    '        '2019/03/14 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/14 CHG E N D

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/14 CHG E N D
    '            '�擾�f�[�^�Ȃ�
    '            DSPCTLCD_SEARCH = 1
    '            Exit Function
    '            'GoTo END_DSPCTLCD_SEARCH
    '        End If

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = False Then
    '        '    With pot_DB_FIXMTA
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .CTLCD = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "") '�Ǘ��R�[�h
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .CTLNM = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "") '�Ǘ�����
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "") '�Œ�l
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "") '���l
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
    '        '    End With
    '        'End If
    '        With pot_DB_FIXMTA
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�폜�敪
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .CTLCD = DB_NullReplace(dt.Rows(0)("CTLCD"), "") '�Ǘ��R�[�h
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .CTLNM = DB_NullReplace(dt.Rows(0)("CTLNM"), "") '�Ǘ�����
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .FIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "") '�Œ�l
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .REMARK = DB_NullReplace(dt.Rows(0)("REMARK"), "") '���l
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
    '        End With
    '        '2019/03/14 CHG E N D

    '        DSPCTLCD_SEARCH = 0

    '        'END_DSPCTLCD_SEARCH:
    '        '            '�N���[�Y
    '        '            Call CF_Ora_CloseDyn(Usr_Ody)

    '        '            Exit Function

    '        'ERR_DSPCTLCD_SEARCH:
    '        '            GoTo END_DSPCTLCD_SEARCH
    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("DSPCTLCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '    End Try

    'End Function
End Module