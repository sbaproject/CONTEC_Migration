Option Strict Off
Option Explicit On
Module YSNTRA_DBM
    '==========================================================================
    '   YSNTRA.DBM   �^�M���x�t�@�C��                UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_YSNTRA
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '�`�[�폜�敪
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TGRPCD() As Char '�O���[�v��ЃR�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public YSNUPDT() As Char '�o�^��
    '	Dim URKZANKN As Decimal '���|�c���z
    '	Dim YSNJDNKN As Decimal '�󒍎c���z
    '	Dim YSNTEGKN As Decimal '���c���z
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '�^�C���X�^���v�i���ԁj
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '�^�C���X�^���v�i���t�j
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char '�^�C���X�^���v�i�o�^���ԁj
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char '�^�C���X�^���v�i�o�^���j
    'End Structure
    '20190611 del end

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_YSNTRA_Clear
    '   �T�v�F  �^�M���x�t�@�C���\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Sub DB_YSNTRA_Clear(ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA)

    '	Dim Clr_DB_YSNTRA As TYPE_DB_YSNTRA

    '	'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_YSNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	pot_DB_YSNTRA = Clr_DB_YSNTRA

    'End Sub

    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   ���́F  Function DSPYSN_SEARCH
    '    '   �T�v�F  �^�M���x�t�@�C������
    '    '   �����F  pin_strTOKCD�@�@ : ���Ӑ�R�[�h
    '    '           pin_strTGRPCD�@�@: �O���[�v��ЃR�[�h
    '    '   �@�@�@�@pin_strYSNUPDT �@: �o�^��
    '    '   �@�@�@�@pot_DB_YSNTRA  �@: ��������
    '    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '    '   ���l�F
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Public Function DSPYSN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByVal pin_strYSNUPDT As String, ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA) As Short

    '		Dim strSQL As String
    '		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    '		Dim Usr_Ody As U_Ody
    '		Dim strTGRPCD As String

    '		On Error GoTo ERR_DSPYSN_SEARCH

    '		DSPYSN_SEARCH = 9

    '		Call DB_YSNTRA_Clear(pot_DB_YSNTRA)

    '		If Trim(pin_strTGRPCD) = "" Then
    '			strTGRPCD = pin_strTOKCD
    '		Else
    '			strTGRPCD = pin_strTGRPCD
    '		End If

    '		strSQL = ""
    '		strSQL = strSQL & " Select * "
    '		strSQL = strSQL & "   from YSNTRA "
    '		strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
    '		strSQL = strSQL & "    and TGRPCD  = '" & CF_Ora_Sgl(strTGRPCD) & "' "
    '		strSQL = strSQL & "    and YSNUPDT = '" & CF_Ora_Sgl(pin_strYSNUPDT) & "' "

    '		'DB�A�N�Z�X
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'�擾�f�[�^�Ȃ�
    '			DSPYSN_SEARCH = 1
    '			GoTo END_DSPYSN_SEARCH
    '		End If

    '		If CF_Ora_EOF(Usr_Ody) = False Then
    '			With pot_DB_YSNTRA
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "") '�O���[�v��ЃR�[�h
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.YSNUPDT = CF_Ora_GetDyn(Usr_Ody, "YSNUPDT", "") '�o�^��
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0) '���|�c���z
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.YSNJDNKN = CF_Ora_GetDyn(Usr_Ody, "YSNJDNKN", 0) '�󒍎c���z
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.YSNTEGKN = CF_Ora_GetDyn(Usr_Ody, "YSNTEGKN", 0) '���c���z
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
    '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
    '			End With
    '		End If

    '		DSPYSN_SEARCH = 0

    'END_DSPYSN_SEARCH: 
    '		'�N���[�Y
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '		Exit Function

    'ERR_DSPYSN_SEARCH: 
    '		GoTo END_DSPYSN_SEARCH

    '	End Function
End Module