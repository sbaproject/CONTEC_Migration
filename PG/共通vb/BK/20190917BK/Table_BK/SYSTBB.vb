Option Strict Off
Option Explicit On
Module SYSTBB_DBM
    '==========================================================================
    '   SYSTBB.DBM   ����Ńe�[�u��                   UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_SYSTBB
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public ZEIDT As String '������t              YYYY/MM/DD          
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ZEIRNKKB As String '����Ń����N          0                   
    '	Dim ZEIRT As Decimal '����ŗ�              ##0.00;;#           
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�ŏI��Ǝ҃R�[�h      !@@@@@@@@           
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�N���C�A���g�h�c      !@@@@@              
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(����)        9(06)               
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(���t)        YYYY/MM/DD          
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String '��ѽ����(�o�^����)    9(06)               
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String '��ѽ����(�o�^��)      YYYY/MM/DD          
    'End Structure
    'Public DB_SYSTBB As TYPE_DB_SYSTBB
    'Public DBN_SYSTBB As Short
    '20190611 del end
    
    ' Index1( ZEIDT + ZEIRNKKB )
    ' Index2( ZEIRNKKB + ZEIDT )

    Sub SYSTBB_RClear()
        Dim TmpStat As Object
        'UPGRADE_WARNING: �I�u�W�F�N�g G_LB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TmpStat �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/25�@��
        '      TmpStat = Dll_RClear(DBN_SYSTBB, G_LB)
        '      Call ResetBuf(DBN_SYSTBB)
        '2019/03/25�@��
    End Sub

    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Function DSPZEIRT_SEARCH
    '    '   �T�v�F  ����ŗ�����
    '    '   �����F  pin_strZEIDT    : ���
    '    '           pin_strZEIRNKKB : ����Ń����N
    '    '           pot_DB_SYSTBB   : ��������
    '    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Public Function DSPZEIRT_SEARCH(ByVal pin_strZEIDT As String, ByVal pin_strZEIRNKKB As String, ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB) As Short

    '        Dim strSQL As String
    '        Dim intData As Short
    '        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '        Dim Usr_Ody_LC As U_Ody

    '        On Error GoTo ERR_DSPZEIRT_SEARCH

    '        DSPZEIRT_SEARCH = 9

    '        ' === 20131203 === INSERT S - RS)Ishida ����Ŗ@�����Ή�
    '        '�p�����[�^�̎擾���t���A"/"����������B
    '        pin_strZEIDT = Replace(pin_strZEIDT, "/", "")
    '        ' === 20131203 === INSERT E -

    '        strSQL = ""
    '        strSQL = strSQL & " Select * "
    '        strSQL = strSQL & "   from SYSTBB "
    '        strSQL = strSQL & "  Where ZEIDT    <= '" & pin_strZEIDT & "' "
    '        strSQL = strSQL & "    and ZEIRNKKB  = '" & pin_strZEIRNKKB & "' "
    '        strSQL = strSQL & "  Order by ZEIDT DESC "

    '        'DB�A�N�Z�X
    '        '2019/04/09 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/04/09 CHG E N D

    '        '2019/04/09 CHG START     
    '        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/04/09 CHG E N D
    '            '�擾�f�[�^�Ȃ�
    '            DSPZEIRT_SEARCH = 1
    '            Exit Function
    '        End If

    '        '2019/04/09 CHG START
    '        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '        '    With pot_DB_SYSTBB
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .ZEIDT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIDT", "") '�`�[�폜�敪
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRNKKB", "") '�`�[�폜�敪
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .ZEIRT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRT", 0) '�`�[�폜�敪
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "") '�ŏI��Ǝ҃R�[�h
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "") '�N���C�A���g�h�c
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "") '�^�C���X�^���v�i���ԁj
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "") '�^�C���X�^���v�i���t�j
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
    '        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
    '        '    End With
    '        'End If
    '        With pot_DB_SYSTBB
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .ZEIDT = DB_NullReplace(dt.Rows(0)("ZEIDT"), "") '�`�[�폜�敪
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '�`�[�폜�敪
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '�`�[�폜�敪
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
    '        '2019/04/09 CHG E N D

    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody_LC)


    '        DSPZEIRT_SEARCH = 0

    '        Exit Function

    'ERR_DSPZEIRT_SEARCH:


    '    End Function
End Module