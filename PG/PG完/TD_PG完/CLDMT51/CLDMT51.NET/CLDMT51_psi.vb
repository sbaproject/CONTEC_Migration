Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'�v���O�����������v���V�W��
	'���������������� �v���O�����P�ʂ̋��ʏ��� Start ��������������������������������
	''================================================================================
	'���@��ʃ{�f�B���̍s�P�ʂ̋Ɩ����@�@�@�@�@��
	'���@�@Cls_Dsp_Body_Row_Inf�Ƃ̌݊������@�@�@��
	'���@�@���ʂ̑S�Ă̂o�f�Ő錾����@�@�@�@�@�@��
	'���@�@���̂��߈ȉ��̢Dummy��͕K�{�I�I �@�@�@��
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String '�_�~�[
		Dim Selected As String '�I��/��I��
		Dim DATKB As String '�`�[�폜�敪
		Dim CLDDT As String '���t
		Dim CLDWKKB As String '�j��
		Dim CLDHLKB As String '�j��
		Dim SLSMDD As String '�c�ƒʎZ����
		Dim PRDKDDD As String '���Y�ғ�����
		Dim DTBKDDD As String '�����ғ�����
		Dim CLDSMDD As String '����ʎZ����
		Dim SLDKB As String '�c�Ɠ��敪
		Dim BNKKDKB As String '��s�ғ��敪
		Dim PRDKDKB As String '���Y�ғ��敪
		Dim DTBKDKB As String '�����ғ��敪
		'2007/12/27 add-str T.KAWAMUKAI 2007/12/17 del M.SUEZAWA
		'''    WRTTM           As String       '�X�V����
		'''    WRTDT           As String       '�X�V���t
		'''    UWRTTM          As String       '�o�b�`����
		'''    UWRTDT          As String       '�o�b�`���t
		'2007/12/27 add-end T.KAWAMUKAI
		' === 20081001 === INSERT S - RISE)Izumi
		'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�N���C�A���g�h�c�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		' === 20081001 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'�Œ�l�o�^
	Public Const gc_strMsgCLDMT51_E_001 As String = "2CLDMT51_001" '���͋敪���Ⴂ�܂��B
	Public Const gc_strMsgCLDMT51_E_002 As String = "2CLDMT51_002" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgCLDMT51_A_003 As String = "1CLDMT51_003" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgCLDMT51_A_004 As String = "1CLDMT51_004" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgCLDMT51_E_005 As String = "2CLDMT51_005" '�������I�����܂����
	Public Const gc_strMsgCLDMT51_E_006 As String = "2CLDMT51_006" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgCLDMT51_E_007 As String = "2CLDMT51_007" '�V�X�e���G���[
	Public Const gc_strMsgCLDMT51_E_008 As String = "2CLDMT51_008" '���׍s�ɓo�^����f�[�^������܂���B
	Public Const gc_strMsgCLDMT51_A_009 As String = "1CLDMT51_009" '���o�^�̃f�[�^�����݂��܂��B�X�V���s���܂��B
	Public Const gc_strMsgCLDMT51_E_010 As String = "2CLDMT51_010" '�o�^�N�����ύX����Ă��邽�ߍX�V�ł��܂���B
	Public Const gc_strMsgCLDMT51_A_011 As String = "1CLDMT51_011" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgCLDMT51_E_012 As String = "2CLDMT51_012" '�X�V����������܂���B
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module