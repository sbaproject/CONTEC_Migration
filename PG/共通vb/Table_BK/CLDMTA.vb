Option Strict Off
Option Explicit On
Module CLDMTA_DBM
    '==========================================================================
    '   CLDMTA.DBM   �J�����_�}�X�^                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    'Public Const DATE_KBN_SLDKB As Short = 1 '�c�Ɠ��敪
    'Public Const DATE_KBN_BNKKDKB As Short = 2 '��s�ғ��敪
    'Public Const DATE_KBN_DTBKDKB As Short = 3 '�����ғ��敪
    'Public Const DATE_KBN_ETCKBA As Short = 4 '���̑��敪�P
    'Public Const DATE_KBN_ETCKBB As Short = 5 '���̑��敪�Q
    'Public Const DATE_KBN_ETCKBC As Short = 6 '���̑��敪�R
    'Public Const DATE_KBN_ETCKBD As Short = 7 '���̑��敪�S
    'Public Const DATE_KBN_ETCKBE As Short = 8 '���̑��敪�T
    'Public Const DATE_KBN_ETCKBF As Short = 9 '���̑��敪�U
    'Public Const DATE_KBN_ETCKBG As Short = 10 '���̑��敪�V
    'Public Const DATE_KBN_ETCKBH As Short = 11 '���̑��敪�W
    'Public Const DATE_KBN_ETCKBI As Short = 12 '���̑��敪�X
    '   Public Const DATE_KBN_ETCKBJ As Short = 13 '���̑��敪�P�O

    '20190610 del start

    '   Structure TYPE_DB_CLDMTA
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '�`�[�폜�敪
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public CLDDT As String '���t
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public CLDWKKB As String '�j��
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public CLDHLKB As String '�j��
    '	Dim SLSMDD As Decimal '�c�ƒʎZ����
    '	Dim PRDKDDD As Decimal '���Y�ғ�����
    '	Dim DTBKDDD As Decimal '�����ғ�����
    '	Dim CLDSMDD As Decimal '����ʎZ����
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SLDKB As String '�c�Ɠ��敪
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public BNKKDKB As String '��s�ғ��敪
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PRDKDKB As String '���Y�ғ��敪
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DTBKDKB As String '�����ғ��敪
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBA As String '���̑��敪�P
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBB As String '���̑��敪�Q
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBC As String '���̑��敪�R
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBD As String '���̑��敪�S
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBE As String '���̑��敪�T
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBF As String '���̑��敪�U
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBG As String '���̑��敪�V
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBH As String '���̑��敪�W
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBI As String '���̑��敪�X
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBJ As String '���̑��敪�P�O
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
    'Public DB_CLDMTA As TYPE_DB_CLDMTA
    'Public DBN_TCLDMTA As Short
    '20190610 del end


    '�J�����_�}�X�^������ʃp�����[�^
    '�c�Ɠ��敪,��s�ғ��敪,�����ғ��敪,���̑��敪�P,���̑��敪�Q
    '���̑��敪�R,���̑��敪�S,���̑��敪�T,���̑��敪�U,���̑��敪�V
    '���̑��敪�W,���̑��敪�X,���̑��敪�P�O
    '   Public WLSDATE_KBN As Short

    ''�J�����_�����߂�l
    'Public WLSDATE_RTNCODE As String '���t�iyyyy/mm/dd�j

    '' === 20070309 === UPDATE S - ACE)Nagasawa
    ''Private Const KDKB_Holiday As String = "9"
    ''Private Const KDKB_WORK    As String = "1"
    'Public Const KDKB_Holiday As String = "9"
    'Public Const KDKB_WORK As String = "1"
    '   ' === 20070309 === UPDATE E -


    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Sub DB_CLDMTA_Clear
    '	'   �T�v�F  �J�����_�}�X�^�\���̃N���A
    '	'   �����F�@�Ȃ�
    '	'   �ߒl�F
    '	'   ���l�F
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Sub DB_CLDMTA_Clear(ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA)

    '		Dim Clr_DB_CLDMTA As TYPE_DB_CLDMTA

    '		'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_CLDMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		pot_DB_CLDMTA = Clr_DB_CLDMTA

    '	End Sub

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function DSPCLDDT_SEARCH
    '	'   �T�v�F  �J�����_�}�X�^����
    '	'   �����F  pin_strCLDDT  : �����Ώۓ��t
    '	'           pot_DB_CLDMTA : ��������
    '	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '	'   ���l�F
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH(ByVal pin_strCLDDT As String, ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA) As Short

    '        Dim li_MsgRtn As Integer

    '        Try


    '            Dim strSQL As String
    '            'Dim intData As Short
    '            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '            'Dim Usr_Ody As U_Ody

    '            'On Error GoTo ERR_DSPCLDDT_SEARCH

    '            DSPCLDDT_SEARCH = 9

    '            strSQL = ""
    '            strSQL = strSQL & " Select * "
    '            strSQL = strSQL & "   from CLDMTA "
    '            strSQL = strSQL & "  Where CLDDT = '" & pin_strCLDDT & "' "

    '            'DB�A�N�Z�X
    '            '20190322 CHG START
    '            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '            Dim dt As DataTable = DB_GetTable(strSQL)
    '            '20190322 CHG END

    '            '20190322 CHG START
    '            ' CF_Ora_EOF(Usr_Ody) = True Then
    '            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '                '20190322 CHG 
    '                '�擾�f�[�^�Ȃ�
    '                DSPCLDDT_SEARCH = 1
    '                Exit Function
    '            End If

    '            '20190322 CHG START
    '            'If CF_Ora_EOF(Usr_Ody) = False Then
    '            '    With pot_DB_CLDMTA
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '���t
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '�j��
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '�j��
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", 0) '�c�ƒʎZ����
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", 0) '���Y�ғ�����
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", 0) '�����ғ�����
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", 0) '����ʎZ����
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '�c�Ɠ��敪
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '��s�ғ��敪
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '���Y�ғ��敪
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '�����ғ��敪
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody, "ETCKBA", "") '���̑��敪�P
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody, "ETCKBB", "") '���̑��敪�Q
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody, "ETCKBC", "") '���̑��敪�R
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody, "ETCKBD", "") '���̑��敪�S
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody, "ETCKBE", "") '���̑��敪�T
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody, "ETCKBF", "") '���̑��敪�U
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody, "ETCKBG", "") '���̑��敪�V
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody, "ETCKBH", "") '���̑��敪�W
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody, "ETCKBI", "") '���̑��敪�X
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody, "ETCKBJ", "") '���̑��敪�P�O
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
    '            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
    '            '    End With
    '            'End If

    '            ''�N���[�Y
    '            'Call CF_Ora_CloseDyn(Usr_Ody)

    '            With pot_DB_CLDMTA
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLDDT = DB_NullReplace(dt.Rows(0)("CLDDT"), "") '���t
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLDWKKB = DB_NullReplace(dt.Rows(0)("CLDWKKB"), "") '�j��
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLDHLKB = DB_NullReplace(dt.Rows(0)("CLDHLKB"), "") '�j��
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .SLSMDD = DB_NullReplace(dt.Rows(0)("SLSMDD"), 0) '�c�ƒʎZ����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .PRDKDDD = DB_NullReplace(dt.Rows(0)("PRDKDDD"), 0) '���Y�ғ�����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .DTBKDDD = DB_NullReplace(dt.Rows(0)("DTBKDDD"), 0) '�����ғ�����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLDSMDD = DB_NullReplace(dt.Rows(0)("CLDSMDD"), 0) '����ʎZ����
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .SLDKB = DB_NullReplace(dt.Rows(0)("SLDKB"), "") '�c�Ɠ��敪
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .BNKKDKB = DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") '��s�ғ��敪
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .PRDKDKB = DB_NullReplace(dt.Rows(0)("PRDKDKB"), "") '���Y�ғ��敪
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .DTBKDKB = DB_NullReplace(dt.Rows(0)("DTBKDKB"), "") '�����ғ��敪
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBA = DB_NullReplace(dt.Rows(0)("ETCKBA"), "") '���̑��敪�P
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBB = DB_NullReplace(dt.Rows(0)("ETCKBB"), "") '���̑��敪�Q
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBC = DB_NullReplace(dt.Rows(0)("ETCKBC"), "") '���̑��敪�R
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBD = DB_NullReplace(dt.Rows(0)("ETCKBD"), "") '���̑��敪�S
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBE = DB_NullReplace(dt.Rows(0)("ETCKBE"), "") '���̑��敪�T
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBF = DB_NullReplace(dt.Rows(0)("ETCKBF"), "") '���̑��敪�U
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBG = DB_NullReplace(dt.Rows(0)("ETCKBG"), "") '���̑��敪�V
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBH = DB_NullReplace(dt.Rows(0)("ETCKBH"), "") '���̑��敪�W
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBI = DB_NullReplace(dt.Rows(0)("ETCKBI"), "") '���̑��敪�X
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .ETCKBJ = DB_NullReplace(dt.Rows(0)("ETCKBJ"), "") '���̑��敪�P�O
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
    '                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
    '            End With
    '            '20190322 CHG END

    '            DSPCLDDT_SEARCH = 0

    '            '            Exit Function

    '            'ERR_DSPCLDDT_SEARCH:
    '        Catch ex As Exception
    '            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '        End Try

    '    End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function CHK_CLDDT
    '	'   �T�v�F  �x���`�F�b�N
    '	'   �����F  pin_strCLDDT  : �`�F�b�N�Ώۓ��t
    '	'           pin_strChkKbn : �`�F�b�N�敪(1:�c�Ɠ��`�F�b�N�@2:��s�ғ��`�F�b�N�@3:�����ғ��`�F�b�N�j
    '	'   �ߒl�F�@0:�ʏ�� 1:�x�� 9:�ُ�I��
    '	'   ���l�F
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function CHK_CLDDT(ByVal pin_strCLDDT As String, ByVal pin_strChkKbn As String, ByRef pm_All As Cls_All) As Short

    '		Dim Mst_Inf As TYPE_DB_CLDMTA
    '		Dim intRet As Short

    '		'������
    '		Call DB_CLDMTA_Clear(Mst_Inf)
    '		CHK_CLDDT = 0

    '		'�J�����_�}�X�^����
    '		intRet = DSPCLDDT_SEARCH(pin_strCLDDT, Mst_Inf)
    '		Select Case intRet
    '			Case 0
    '				If Mst_Inf.DATKB = gc_strDATKB_USE Then
    '					'���t�`�F�b�N
    '					Select Case pin_strChkKbn
    '						'�c�Ɠ��`�F�b�N
    '						Case "1"
    '							If Mst_Inf.SLDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '							'��s�ғ��`�F�b�N
    '						Case "2"
    '							If Mst_Inf.BNKKDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '							'�����ғ��`�F�b�N
    '						Case "3"
    '							If Mst_Inf.DTBKDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '						Case Else
    '					End Select
    '				Else
    '					CHK_CLDDT = 9
    '				End If

    '			Case 1
    '				CHK_CLDDT = 9

    '			Case Else
    '				CHK_CLDDT = 9
    '		End Select

    '	End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function DSPCLDDT_SEARCH_KDKB
    '	'   �T�v�F  �J�����_�}�X�^����(�ғ����̂ݎ擾)
    '	'   �����F  pin_strCLDDT  : �����Ώۓ��t
    '	'           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ���)
    '	'           �@�@�@�@�@�@�@�@�@�@�@�@�@�@ "12":�c�Ɠ��E��s�ғ���)
    '	'           pin_strKEISAN : �v�Z�敪("1":���Z "2":���Z)
    '	'           pot_strCLDDT  : ��������
    '	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '	'   ���l�F
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH_KDKB(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPCLDDT_SEARCH_KDKB

    '		DSPCLDDT_SEARCH_KDKB = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		Else
    '			strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
    '		End If

    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB >= '" & gc_strDATKB_USE & "' "

    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
    '		Else
    '			strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
    '		End If

    '		Select Case pin_strKDKB
    '			'�c�Ɠ�
    '			Case "1"
    '				strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "

    '				'��s�ғ���
    '			Case "2"
    '				strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "

    '				'�����ғ���
    '			Case "3"
    '				strSQL = strSQL & "    and DTBKDKB = '" & KDKB_WORK & "' "

    '				' === 20070309 === INSERT S - ACE)Nagasawa
    '				'�c�Ɠ��E��s�ғ���
    '			Case "12"
    '				strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
    '				strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
    '				' === 20070309 === INSERT E -

    '		End Select

    '        'DB�A�N�Z�X
    '        '2019/03/18 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/18 CHG E N D

    '        '2019/03/18 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/18 CHG E N D
    '            '�擾�f�[�^�Ȃ�
    '            DSPCLDDT_SEARCH_KDKB = 1
    '            Exit Function
    '        Else
    '            '2019/03/18 CHG START
    '            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            'pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            pot_strCLDDT = DB_NullReplace(dt.Rows(0)("GETDATE"), "")
    '            '2019/03/18 CHG E N D
    '        End If


    '        '�N���[�Y
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        DSPCLDDT_SEARCH_KDKB = 0

    '        Exit Function

    'ERR_DSPCLDDT_SEARCH_KDKB:


    '    End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function DSPKDDT_SEARCH
    '	'   �T�v�F  �J�����_�}�X�^����(�c�ƒʎZ������茟��)
    '	'   �����F  pin_strCLDDT  : �����ΏےʎZ���t
    '	'           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ��� "4":���Y�ғ���)
    '	'           pot_strCLDDT  : ��������
    '	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '	'   ���l�F
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPKDDT_SEARCH(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPKDDT_SEARCH

    '		DSPKDDT_SEARCH = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "

    '		Select Case pin_strKDKB
    '			'�c�Ɠ�
    '			Case "1", "2"
    '				strSQL = strSQL & "    and SLSMDD = " & CF_Ora_Number(pin_strCLDDT)

    '				'�����ғ���
    '			Case "3"
    '				strSQL = strSQL & "    and DTBKDDD = " & CF_Ora_Number(pin_strCLDDT)

    '				'���Y�ғ���
    '			Case "4"
    '				strSQL = strSQL & "    and PRDKDDD = " & CF_Ora_Number(pin_strCLDDT)
    '		End Select

    '		'DB�A�N�Z�X
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'�擾�f�[�^�Ȃ�
    '			DSPKDDT_SEARCH = 1
    '			Exit Function
    '		Else
    '			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '		End If


    '		'�N���[�Y
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '		DSPKDDT_SEARCH = 0

    '		Exit Function

    'ERR_DSPKDDT_SEARCH: 


    '	End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function AE_CalcDate_Add
    '	'   �T�v�F  ���t�v�Z����
    '	'   �����F�@Pio_strDate     :�v�Z�Ώۓ�(�����W���A�܂���yyyy/mm/dd�̌`���j
    '	'           Pin_intAddDate  :���Z�Ώۓ����i�}�C�i�X�l�͌��Z�j
    '	'           Pin_strKind     :�c�Ɠ����("1":�c�Ɠ� "2":��s�ғ����@"3":�����ғ��� "4":���Y�ғ���)
    '	'                            �ȗ����͉c�Ɠ��ɂ��l������
    '	'   �ߒl�F  0 : ���� 9 : �ُ�
    '	'   ���l�F�@�o�ח\��������߂�ꍇ�̏C����A���[No.516�ōs����
    '	'   �@�@�@�@���̓��t�����߂鎞�ɓ��֐����g�p����ꍇ�́A�����C�����K�v�ƂȂ�
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function AE_CalcDate_Add(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short

    '		Dim strDate As String
    '		Dim strDate_W As String
    '		Dim Mst_Inf_NOW As TYPE_DB_CLDMTA
    '		Dim curCALCDATE As Decimal
    '		Dim curKDDATE As Decimal

    '		AE_CalcDate_Add = 9

    '		strDate = ""

    '		'���Z���l�`�F�b�N
    '		If IsNumeric(Pin_intAddDate) = False Then
    '			Exit Function
    '		End If

    '		'���t�������`�F�b�N
    '		If IsDate(Pio_strDate) = True Then
    '#Disable Warning BC40000 ' Type or member is obsolete
    '			strDate = VB6.Format(Pio_strDate, "yyyymmdd")
    '#Enable Warning BC40000 ' Type or member is obsolete
    '		End If

    '		'���t�l���ɕϊ�
    '#Disable Warning BC40000 ' Type or member is obsolete
    '		If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
    '#Enable Warning BC40000 ' Type or member is obsolete
    '			strDate = Pio_strDate
    '		End If

    '		If Trim(strDate) = "" Then
    '			Exit Function
    '		End If

    '		'�\���̃N���A
    '		Call DB_CLDMTA_Clear(Mst_Inf_NOW)

    '		curKDDATE = 0
    '		Select Case Pin_strKind
    '			'�c�Ɠ��ɂ��l������
    '			Case "0"
    '#Disable Warning BC40000 ' Type or member is obsolete
    '				strDate = VB6.Format(strDate, "@@@@/@@/@@")
    '#Enable Warning BC40000 ' Type or member is obsolete
    '				strDate_W = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
    '				Pio_strDate = strDate_W
    '				AE_CalcDate_Add = 0

    '				'�c�Ɠ��A��s�ғ����l��
    '			Case "1", "2"
    '				'�J�����_�}�X�^����
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.SLSMDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.SLSMDD)
    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '				'���t���Z
    '				curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

    '				'�����ғ����l��
    '			Case "3"
    '				'�J�����_�}�X�^����
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.DTBKDDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.DTBKDDD)

    '							'20081111 ADD START RISE)Tanimura  �A���[No.516
    '							' ���Z�Ώۓ������}�C�i�X�̏ꍇ
    '							If Pin_intAddDate < 0 Then
    '								' �����ғ��敪 �� �x�� �̏ꍇ
    '								If Mst_Inf_NOW.DTBKDKB = KDKB_Holiday Then
    '									' �Œ�l�l����擾�����l + 1
    '									Pin_intAddDate = Pin_intAddDate + 1
    '								End If
    '							End If
    '							'20081111 ADD END   RISE)Tanimura

    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '				'���Y�ғ����l��
    '			Case "4"
    '				'�J�����_�}�X�^����
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.PRDKDDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.PRDKDDD)
    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '		End Select

    '		'���t���Z
    '		curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

    '		If DSPKDDT_SEARCH(CStr(curCALCDATE), Pin_strKind, strDate_W) <> 0 Then
    '			Exit Function
    '		End If

    '		Pio_strDate = strDate_W

    '		AE_CalcDate_Add = 0

    '	End Function


    '	' === 20070309 === INSERT S - ACE)Nagasawa �����̓��͉ې���̕ύX
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   ���́F  Function DSPCLDDT_SEARCH_WK
    '	'   �T�v�F  �J�����_�}�X�^����(�j���v�Z)
    '	'   �����F  pin_strCLDDT   : �����Ώۓ��t
    '	'           pin_strCLDWKKB : �j���敪
    '	'           pin_strKEISAN  : �v�Z�敪("1":���Z "2":���Z)
    '	'           pot_strCLDDT   : ��������
    '	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '	'   ���l�F  �����Ώۓ��t���O�A�܂��͌�̗j���敪�Ŏw�肳�ꂽ�j���ɓ�������t������
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH_WK(ByVal pin_strCLDDT As String, ByVal pin_strCLDWKKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPCLDDT_SEARCH_WK

    '		DSPCLDDT_SEARCH_WK = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		Else
    '			strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
    '		End If

    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
    '		strSQL = strSQL & "    And CLDWKKB = '" & CF_Ora_String(pin_strCLDWKKB, 1) & "' "

    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
    '		Else
    '			strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
    '		End If

    '		'DB�A�N�Z�X
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'�擾�f�[�^�Ȃ�
    '			DSPCLDDT_SEARCH_WK = 1
    '			Exit Function
    '		Else
    '			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '		End If

    '		DSPCLDDT_SEARCH_WK = 0

    'ERR_DSPCLDDT_SEARCH_WK: 

    '		'�N���[�Y
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '	End Function
    '	' === 20070309 === INSERT E -
End Module