Option Strict Off
Option Explicit On
Module MEIMTA_DBM
	'==========================================================================
	'   MEIMTA.DBM   ���̃}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_MEIMTA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '�`�[�폜�敪          0
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public KEYCD() As Char '�L�[                  000
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEIKMKNM() As Char '���ږ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEICDA() As Char '�R�[�h�P
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public MEICDB() As Char '�R�[�h�Q
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public MEINMA() As Char '���̂P
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEINMB() As Char '���̂Q
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public MEINMC() As Char '���̂R
		Dim MEISUA As Decimal '���l���ڂP            ###,###,##0.0000;;#
		Dim MEISUB As Decimal '���l���ڂQ            ###,##0.0000;;#
		Dim MEISUC As Decimal '���l���ڂR            ###,##0.0000;;#
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBA() As Char '�敪�P
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBB() As Char '�敪�Q
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MEIKBC() As Char '�敪�R
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public DSPORD() As Char '�\������
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public RELFL() As Char '�A�g�t���O            X
		' === 20061227 === UPDATE S - ACE)Nagasawa
		'    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
		'    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
		'    WRTTM          As String * 6     '��ѽ����(����)        9(06)
		'    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
		'    WRTFSTTM       As String * 6     '��ѽ����(�o�^����)    9(06)
		'    WRTFSTDT       As String * 8     '��ѽ����(�o�^��)      YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '����o�^�S����ID
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '����o�^�N���C�A���gID
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char '��ѽ����(����o�^����)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char '��ѽ����(����o�^���t)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�X�V�S���҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�X�V�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(�X�V����)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(�X�V���t)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '�o�b�`�X�V�S���҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�o�b�`�X�V�N���C�A���gID
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(�o�b�`�X�V����)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(�o�b�`�X�V���t)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(7),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=7)> Public PGID() As Char '��۸���ID
		' === 20061227 === UPDATE E -
	End Structure
	Public DB_MEIMTA As TYPE_DB_MEIMTA
	Public DBN_MEIMTA As Short
	
	'���̃}�X�^������ʃp�����[�^
	Public WLSMEI_KEYCD As String '�L�[
	
	'���̃}�X�^�����߂�l
	Public WLSMEI_RTNMEICDA As String '�R�[�h�P
	Public WLSMEI_RTNMEINMA As String '���̂P
	'20130701 ADD START �V�ʔ̘A�g�Ή�
	Public WLSMEI_RTNMEINMB As String '���̂Q
	'20130701 ADD END
	
	'ADD START FKS)INABA 2009/07/17 ****************************************************************************
	'�A���[��FC09071701
	Public WK_MEICDA As String
	'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub DB_MEIMTA_Clear
	'   �T�v�F  ���̃}�X�^�\���̃N���A
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub DB_MEIMTA_Clear(ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
		Dim Clr_DB_MEIMTA As TYPE_DB_MEIMTA
		'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_MEIMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_DB_MEIMTA = Clr_DB_MEIMTA
	End Sub
	
	' === 20060920 === INSERT S - ACE)Sejima �����Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub DB_MEIMTA_SetData
	'   �T�v�F  ���̃}�X�^�\���̃f�[�^�ޔ�
	'   �����F�@�Ȃ�
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
		
		'�f�[�^�ޔ�
		With pot_DB_MEIMTA
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '�`�[�폜�敪
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.KEYCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEYCD", "") '�L�[
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEIKMKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKMKNM", "") '���ږ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEICDA = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDA", "") '�R�[�h�P
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEICDB = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDB", "") '�R�[�h�Q
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEINMA = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMA", "") '���̂P
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEINMB = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMB", "") '���̂Q
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEINMC = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMC", "") '���̂R
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEISUA = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUA", 0) '���l���ڂP
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEISUB = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUB", 0) '���l���ڂQ
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEISUC = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUC", 0) '���l���ڂR
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEIKBA = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBA", "") '�敪�P
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEIKBB = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBB", "") '�敪�Q
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.MEIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBC", "") '�敪�R
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.DSPORD = CF_Ora_GetDyn(pin_Usr_Ody, "DSPORD", "") '�\������
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '�A�g�t���O
			' === 20061227 === UPDATE S - ACE)Nagasawa
			'            .OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
			'            .CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "")               '�N���C�A���g�h�c
			'            .WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
			'            .WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "")               '�^�C���X�^���v�i���t�j
			'            .WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
			'            .WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '����o�^�S����ID
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '����o�^�N���C�A���gID
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") '��ѽ����(����o�^����)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") '��ѽ����(����o�^���t)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '�X�V�S���҃R�[�h
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '�X�V�N���C�A���g�h�c
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") '��ѽ����(�X�V����)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") '��ѽ����(�X�V���t)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") '�o�b�`�X�V�S���҃R�[�h
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") '�o�b�`�X�V�N���C�A���gID
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") '��ѽ����(�o�b�`�X�V����)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") '��ѽ����(�o�b�`�X�V���t)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") '��۸���ID
			' === 20061227 === UPDATE E -
		End With
		
	End Sub
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEIM_SEARCH
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEICDA : �R�[�h�P
	'           pot_DB_MEIMTA : ��������
	'           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEICDB As Object = Nothing) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIM_SEARCH
		
		DSPMEIM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pin_strMEICDB) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
		End If
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			DSPMEIM_SEARCH = 1
			GoTo END_DSPMEIM_SEARCH
		End If
		
		'�擾�f�[�^�ޔ�
		' === 20060920 === UPDATE S - ACE)Sejima
		'D        With pot_DB_MEIMTA
		'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
		'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
		'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
		'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
		'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
		'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
		'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
		'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
		'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
		'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
		'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
		'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
		'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
		'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
		'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
		'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
		'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
		'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
		'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
		'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
		'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
		'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
		'D        End With
		' === 20060920 === UPDATE ��
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		' === 20060920 === UPDATE E
		
		DSPMEIM_SEARCH = 0
		
END_DSPMEIM_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIM_SEARCH: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEINMA_SEARCH_A1
	'   �T�v�F  ���̃}�X�^����(���̂P�̂����܂������j
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEINMA : ���̂P
	'           pot_DB_MEIMTA : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMA_SEARCH_A1(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, Optional ByRef pin_strMEICDA As Object = Nothing) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMA_SEARCH_A1
		
		DSPMEINMA_SEARCH_A1 = 9
		
		strSQL = ""
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
		'ADD START FKS)INABA 2009/07/17 ****************************************************************************
		'�A���[��FC09071701
		'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pin_strMEICDA) = True Or Trim(pin_strMEICDA) = "" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
		End If
		strSQL = strSQL & "   ORDER BY MEICDA "
		'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
		
		'�����擾
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		If intData = 0 Then
			'�擾�f�[�^�Ȃ�
			DSPMEINMA_SEARCH_A1 = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			DSPMEINMA_SEARCH_A1 = 1
			GoTo END_DSPMEINMA_SEARCH_A1
		End If
		
		'�擾�f�[�^�ޔ�
		ReDim pot_DB_MEIMTA(intData)
		intIdx = 1
		Do Until CF_Ora_EOF(Usr_Ody_LC) = True
			' === 20060920 === UPDATE S - ACE)Sejima
			'D            With pot_DB_MEIMTA(intIdx)
			'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
			'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
			'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
			'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
			'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
			'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
			'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
			'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
			'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
			'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
			'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
			'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
			'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
			'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
			'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
			'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
			'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
			'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
			'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
			'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
			'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
			'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
			'D            End With
			' === 20060920 === UPDATE ��
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intIdx))
			' === 20060920 === UPDATE E
			intIdx = intIdx + 1
			Call CF_Ora_MoveNext(Usr_Ody_LC)
		Loop 
		
		DSPMEINMA_SEARCH_A1 = 0
		
END_DSPMEINMA_SEARCH_A1: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMA_SEARCH_A1: 
		
	End Function
	
	'ADD START FKS)INABA 2009/07/17 ****************************************************************************
	'�A���[��FC09071701
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEINMA_SEARCH_A2
	'   �T�v�F  ���̃}�X�^����(���̂P�ł̂����܂�����(���݃`�F�b�N�̂�)�j
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEINMA : ���̂P
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMA_SEARCH_A2(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMA_SEARCH_A2
		
		DSPMEINMA_SEARCH_A2 = 9
		
		strSQL = ""
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
		strSQL = strSQL & "   ORDER BY MEICDA "
		
		'�����擾
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		If intData = 0 Then
			'�擾�f�[�^�Ȃ�
			DSPMEINMA_SEARCH_A2 = 1
			Exit Function
		End If
		
		DSPMEINMA_SEARCH_A2 = 0
		
END_DSPMEINMA_SEARCH_A2: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMA_SEARCH_A2: 
		
	End Function
	'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEINMB_SEARCH
	'   �T�v�F  ���̃}�X�^����(���̂Q�̌����j
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEINMB : ���̂Q
	'           pot_DB_MEIMTA : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEINMB_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEINMB As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
		
		On Error GoTo ERR_DSPMEINMB_SEARCH
		
		DSPMEINMB_SEARCH = 9
		
		strSQL = ""
		strSQL = " Select * " & strSQL
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEINMB =    '" & CF_Ora_String(pin_strMEINMB, 20) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			DSPMEINMB_SEARCH = 1
			GoTo END_DSPMEINMB_SEARCH
		End If
		
		'�擾�f�[�^�ޔ�
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			' === 20060920 === UPDATE S - ACE)Sejima �����Ή�
			'D            With pot_DB_MEIMTA
			'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
			'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
			'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
			'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
			'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
			'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
			'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
			'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
			'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
			'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
			'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
			'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
			'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
			'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
			'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
			'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
			'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
			'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
			'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
			'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
			'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
			'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
			'D            End With
			' === 20060920 === UPDATE ��
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
			' === 20060920 === UPDATE E
		End If
		
		DSPMEINMB_SEARCH = 0
		
END_DSPMEINMB_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEINMB_SEARCH: 
		
	End Function
	
	' === 20060920 === INSERT S - ACE)Sejima �����Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEIKBA_SEARCH
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEIKBA : �敪�P
	'           pot_DB_MEIMTA : ��������
	'           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIKBA_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEIKBA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIKBA_SEARCH
		
		DSPMEIKBA_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			DSPMEIKBA_SEARCH = 1
			GoTo END_DSPMEIKBA_SEARCH
		End If
		
		'�擾�f�[�^�ޔ�
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		
		DSPMEIKBA_SEARCH = 0
		
END_DSPMEIKBA_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIKBA_SEARCH: 
		
	End Function
	' === 20060920 === INSERT E
	
	' === 20060822 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_KNNOUGYO
	'   �T�v�F  ����[���|�[���Ǝҁi�[�����o�^�p�j�擾
	'   �����F  pm_All           : ��ʏ��
	'           pot_intMaxLinNo  : �擾�s��
	'   �ߒl�F  0 : ����@1 : �Y���f�[�^�Ȃ��@9 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_KNNOUGYO(ByVal pin_strBINCD As String, ByRef pot_strKNNOUGYO As String) As Short
		
		Dim strKNNOUGYO As String
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim Ret_Value As Short
		
		On Error GoTo CF_Get_KNNOUGYO_Err
		
		'��������u�ُ�v
		Ret_Value = 9
		'��������u�Ȃ��v
		strKNNOUGYO = gc_strKNNOUGYO_NO
		
		If Trim(pin_strBINCD) <> "" Then
			
			'�֖��R�[�h�̓��͂�����ꍇ�A���R�[�h���L�[�Ƃ��Ė��̃}�X�^������
			Call DB_MEIMTA_Clear(Mst_Inf)
			intRet = DSPMEIM_SEARCH(gc_strKEYCD_BINCD, pin_strBINCD, Mst_Inf)
			
			If intRet = 0 Then
				If Trim(Mst_Inf.MEINMB) <> "" Then
					'�f�[�^���擾�ł��A�����̂Q�ɒl�������Ă���
					'�@�˂��̒l��Ԃ��i���[���Ǝҁj
					strKNNOUGYO = Trim(Mst_Inf.MEINMB)
					
				End If
			End If
			
		End If
		
		'�u����v
		Ret_Value = 0
		
CF_Get_KNNOUGYO_End: 
		'�擾�����R�[�h��Ԃ�
		pot_strKNNOUGYO = strKNNOUGYO
		
		CF_Get_KNNOUGYO = Ret_Value
		Exit Function
		
CF_Get_KNNOUGYO_Err: 
		GoTo CF_Get_KNNOUGYO_End
		
	End Function
	' === 20060822 === INSERT E
	
	' === 20060921 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_CRM_RsnCnKb
	'   �T�v�F  �󒍁i��ݾفj���R�擾�iCRM�p�j
	'   �����F�@pin_strKEYCD   : �L�[
	'           pin_strMEICDA  : �R�[�h�P
	'           pot_strRsnCnKb : ���R���ށi���̂R�j
	'           pot_strRsnCnNm : ���R���́i���̂Q�j
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CRM_RsnCnKb(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strRsnCnKb As String, ByRef pot_strRsnCnNm As String) As Short
		
		Dim Ret_Value As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		On Error GoTo CF_Get_CRM_RsnCnKb_End
		
		CF_Get_CRM_RsnCnKb = 9
		
		'��������G���[����
		Ret_Value = 9
		
		'�߂��ϐ���������
		pot_strRsnCnKb = ""
		pot_strRsnCnNm = ""
		
		If DSPMEIM_SEARCH(pin_strKEYCD, pin_strMEICDA, Mst_Inf) = 0 Then
			'�_���폜�`�F�b�N
			If Mst_Inf.DATKB = "9" Then
			Else
				'�擾�l���i�[
				pot_strRsnCnKb = Trim(Mst_Inf.MEINMC)
				pot_strRsnCnNm = Trim(Mst_Inf.MEINMB)
			End If
		End If
		
		'CRM�ҏW�p�ɉ��H
		pot_strRsnCnKb = CF_ZeroLenFormat(pot_strRsnCnKb, 6, True)
		pot_strRsnCnNm = CF_Ctr_AnsiLeftB(pot_strRsnCnNm & Space(40), 40)
		
		'���툵��
		Ret_Value = 0
		
CF_Get_CRM_RsnCnKb_End: 
		'�߂�l��Ԃ�
		CF_Get_CRM_RsnCnKb = Ret_Value
		
	End Function
	' === 20060921 === INSERT E
	
	' === 20061110 === INSERT S - ACE)Nagasawa �Z�b�g�A�b�v�d�ύX�Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEIM_SEARCH_ALL
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pot_DB_MEIMTA : �������ʁi�z��j
	'   �ߒl�F�@0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIM_SEARCH_ALL(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Short
		
		Dim strSQL As String
		Dim strSQL_Where As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIM_SEARCH_ALL
		
		DSPMEIM_SEARCH_ALL = 9
		
		'�߂�l�̃N���A
		Erase pot_DB_MEIMTA
		
		strSQL = ""
		strSQL = strSQL & " Select Count(*) As CNTDATA"
		
		strSQL_Where = ""
		strSQL_Where = strSQL_Where & "   from MEIMTA "
		strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		strSQL = strSQL & strSQL_Where
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		'�����擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		'����
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & strSQL_Where
		
		ReDim pot_DB_MEIMTA(intData)
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		'�擾�f�[�^�ޔ�
		intData = 1
		Do Until CF_Ora_EOF(Usr_Ody_LC) = True
			
			Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))
			
			Call CF_Ora_MoveNext(Usr_Ody_LC)
			intData = intData + 1
		Loop 
		
		DSPMEIM_SEARCH_ALL = 0
		
END_DSPMEIM_SEARCH_ALL: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIM_SEARCH_ALL: 
		
	End Function
	' === 20061110 === INSERT E -
	
	' === 20070213 === INSERT S - ACE)Nagasawa �V�X�e���󒍂ŋ@��󒍂���͉Ƃ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMEIKB_SEARCH
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pot_DB_MEIMTA : ��������
	'           pin_strMEIKBA : �敪�P�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
	'           pin_strMEIKBB : �敪�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
	'           pin_strMEIKBC : �敪�R�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F  �敪�ł̌���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIKB_SEARCH(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEIKBA As String = "", Optional ByVal pin_strMEIKBB As String = "", Optional ByVal pin_strMEIKBC As String = "") As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_DSPMEIKB_SEARCH
		
		DSPMEIKB_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		'�敪�P
		If Trim(pin_strMEIKBA) <> "" Then
			strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
		End If
		
		'�敪�Q
		If Trim(pin_strMEIKBB) <> "" Then
			strSQL = strSQL & "   and  MEIKBB = '" & pin_strMEIKBB & "' "
		End If
		
		'�敪�R
		If Trim(pin_strMEIKBC) <> "" Then
			strSQL = strSQL & "   and  MEIKBC = '" & pin_strMEIKBC & "' "
		End If
		
		'���я�
		strSQL = strSQL & "  Order By KEYCD, MEICDA "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			DSPMEIKB_SEARCH = 1
			GoTo END_DSPMEIKB_SEARCH
		End If
		
		'�擾�f�[�^�ޔ�
		Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
		
		DSPMEIKB_SEARCH = 0
		
END_DSPMEIKB_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPMEIKB_SEARCH: 
		
	End Function
	' === 20070213 === INSERT E -
	
	' === 20130719 === INSERT S - FWEST)Koroyasau �G���h���[�U�Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function ENDUSRNM_SEARCH
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD     : �L�[�P
	'           pin_strMEICDA    : �R�[�h
	'           pot_strENDUSRNM  : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function ENDUSRNM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strENDUSRNM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_ENDUSRNM_SEARCH
		
		ENDUSRNM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strMEICDA) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'�擾�f�[�^�Ȃ�
			ENDUSRNM_SEARCH = 1
			GoTo END_ENDUSRNM_SEARCH
		End If
		
		'�擾�f�[�^�ޔ�
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
		
		ENDUSRNM_SEARCH = 0
		
END_ENDUSRNM_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_ENDUSRNM_SEARCH: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function ENDUSRNM_SEARCH2
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strKEYCD  : �L�[�P
	'           pin_strMEINM  : ����
	'           pot_DB_MEIMTA : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function ENDUSRNM_SEARCH2(ByVal pin_strKEYCD As String, ByVal pin_strMEINM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_ENDUSRNM_SEARCH2
		
		ENDUSRNM_SEARCH2 = 9
		
		strSQL = ""
		strSQL = strSQL & " Select "
		strSQL = strSQL & "        Rtrim(MEINMA) "
		strSQL = strSQL & "        , Rtrim(MEINMB) "
		strSQL = strSQL & "        , Rtrim(MEINMC) "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
		strSQL = strSQL & "   and  Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC)  = '" & Trim(pin_strMEINM) & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
			'�擾�f�[�^�Ȃ�
			ENDUSRNM_SEARCH2 = 1
			GoTo END_ENDUSRNM_SEARCH2
		End If
		
		ENDUSRNM_SEARCH2 = 0
		
END_ENDUSRNM_SEARCH2: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_ENDUSRNM_SEARCH2: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RPTTKA_CHK_SEARCH
	'   �T�v�F  ���̃}�X�^����
	'   �����F  pin_strMEINM  : ����
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RPTTKA_CHK_SEARCH(ByVal pin_strMEINM As String) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_RPTTKA_CHK_SEARCH
		
		RPTTKA_CHK_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select MEINMA "
		strSQL = strSQL & "   from MEIMTA "
		strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "   and  KEYCD  = '" & gc_strKEYCD_YUKOKGN & "' "
		strSQL = strSQL & "   and  MEINMA  = '" & Trim(pin_strMEINM) & "' "
		strSQL = strSQL & "   and  MEIKBA  = '" & gc_strRPTTKA_ON & "' "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
			'�擾�f�[�^�Ȃ�
			RPTTKA_CHK_SEARCH = 1
			GoTo END_RPTTKA_CHK_SEARCH
		End If
		
		RPTTKA_CHK_SEARCH = 0
		
END_RPTTKA_CHK_SEARCH: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_RPTTKA_CHK_SEARCH: 
		
	End Function
	' === 20130719 === INSERT E -
End Module