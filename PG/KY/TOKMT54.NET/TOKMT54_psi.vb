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
		Dim UPDKB As String '���[�h
		Dim DATKB As String '�`�[�폜�敪
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim SKHINGRP As String '�d�ؗp���i�Q
		Dim TRKRNK As String '�����N
		Dim STTKSTDT As String '�J�n�P���ݒ���t
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '�X�V�t���O
		' 2006/11/15  ADD END
		' === 20080926 === INSERT S - RISE)Izumi
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
		' === 20080926 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'���b�Z�[�W�R�[�h
	'���Ӑ�ʏ��i�����N�o�^
	Public Const gc_strMsgTOKMT54_E_001 As String = "2TOKMT54_001" '���͒l�����e�͈͊O�ł��B
	Public Const gc_strMsgTOKMT54_E_002 As String = "2TOKMT54_002" '�Y������f�[�^�����݂��܂���B
	Public Const gc_strMsgTOKMT54_E_003 As String = "2TOKMT54_003" '�폜�ς݃��R�[�h�ł��B
	Public Const gc_strMsgTOKMT54_E_004 As String = "2TOKMT54_004" '���̃R�[�h�͎g�p�ł��܂���B
	Public Const gc_strMsgTOKMT54_E_005 As String = "2TOKMT54_005" '���׍s�ɓo�^����f�[�^������܂���B
	Public Const gc_strMsgTOKMT54_A_006 As String = "1TOKMT54_006" '�I�����Ă�낵���ł����H
	Public Const gc_strMsgTOKMT54_E_007 As String = "2TOKMT54_007" '�d�ؗp���i�Q�͕K�{���͍��ڂł��B
	Public Const gc_strMsgTOKMT54_A_008 As String = "1TOKMT54_008" '�X�V���Ă�낵���ł����H
	Public Const gc_strMsgTOKMT54_E_009 As String = "2TOKMT54_009" '�������I�����܂����
	Public Const gc_strMsgTOKMT54_E_010 As String = "2TOKMT54_010" '���͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
	Public Const gc_strMsgTOKMT54_E_011 As String = "2TOKMT54_011" '�V�X�e���G���[
	Public Const gc_strMsgTOKMT54_E_012 As String = "2TOKMT54_012" '�K�p���͕K�{���͍��ڂł��B
	Public Const gc_strMsgTOKMT54_E_013 As String = "2TOKMT54_013" '�����N�͕K�{���͍��ڂł��B
	Public Const gc_strMsgTOKMT54_E_014 As String = "2TOKMT54_014" '������������͂��ĉ������B
	Public Const gc_strMsgTOKMT54_E_015 As String = "2TOKMT54_015" '���t�Ɍ�肪����܂��B�C�����Ă��������B
	Public Const gc_strMsgTOKMT54_E_016 As String = "2TOKMT54_016" '�Y������d�ؗp���i�Q�����݂��܂���B
	Public Const gc_strMsgTOKMT54_E_017 As String = "2TOKMT54_017" '�Y�����郉���N�����݂��܂���B
	Public Const gc_strMsgTOKMT54_A_018 As String = "1TOKMT54_018" '���o�^�̃f�[�^�����݂��܂��B�X�V���s���܂��B
	Public Const gc_strMsgTOKMT54_A_019 As String = "1TOKMT54_019" '���o�^�̂܂܏I�����Ă���낵���ł����H
	Public Const gc_strMsgTOKMT54_A_020 As String = "1TOKMT54_020" '���݂̕ҏW���e�͔j������܂��B��낵���ł����H
	Public Const gc_strMsgTOKMT54_E_021 As String = "2TOKMT54_021" '����ȍ~�̃f�[�^�͂���܂���B
	Public Const gc_strMsgTOKMT54_E_022 As String = "2TOKMT54_022" '���o���̓��͂��܂��̂��ߖ��׍s�̓��͂��ł��܂���B
	' 2006/11/15  ADD START  KUMEDA
	Public Const gc_strMsgTOKMT54_E_023 As String = "2TOKMT54_023" '��\��Ђł͂���܂���B
	' 2006/11/15  ADD END
	Public Const gc_strMsgTOKMT54_E_024 As String = "2TOKMT54_024" '�X�V����������܂���B
	'''' ADD 2008/06/05  FKS) S.Nakajima    Start
	Public Const gc_strMsgTOKMT54_E_025 As String = "2TOKMT54_025" '���꓾�Ӑ�ɑ΂��A�����̃����N�͓o�^�ł��܂���B
	'''' ADD 2008/06/05  FKS) S.Nakajima    End
	'''' ADD 2008/06/10  FKS) S.Nakajima    Start
	Public Const gc_strMsgTOKMT54_E_026 As String = "2TOKMT54_026" '�K�p�����s���ł��B�����ȍ~����͂��ĉ������B
	'''' ADD 2008/06/10  FKS) S.Nakajima    End
	' === 20080910 === INSERT S - RISE)Izumi
	Public Const gc_strMsgTOKMT54_E_901 As String = "2TOKMT54_901" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	Public Const gc_strMsgTOKMT54_E_902 As String = "2TOKMT54_902" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	' === 20080910 === INSERT E - RISE)Izumi
	
	'���������������� �v���O�����P�ʂ̋��ʏ��� End ��������������������������������
End Module