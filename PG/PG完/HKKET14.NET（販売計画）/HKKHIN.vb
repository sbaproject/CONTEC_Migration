Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

Friend Class HKKHIN
	Inherits System.Windows.Forms.Form
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    WLSSHIN.FRM
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    Rise
	'//*��������
	'//*    �����E�B���h�E�i���i�����j
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060718|Rise)          |�V�K
	'//*****************************************************************************************
	
	'==========================================================================
	'   HINMTA.DBM   ���i�}�X�^                       UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Private Structure TYPE_DB_HINMTA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '�폜�敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINMSTKB() As Char '�}�X�^�敪�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public HINCD() As Char '���i�R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public HINNMA() As Char '�^��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public HINNMB() As Char '���i���P
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public HINNMC() As Char '���i���Q
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public HINNK() As Char '���i���J�i
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public UNTCD() As Char '�P�ʃR�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(4),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=4)> Public UNTNM() As Char '�P�ʖ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINKB() As Char '���i�敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public HINID() As Char '���i���
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINCLAKB() As Char '���ދ敪�P�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINCLBKB() As Char '���ދ敪�Q�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINCLCKB() As Char '���ދ敪�R�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public HINCLAID() As Char '���ރR�[�h�P�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public HINCLBID() As Char '���ރR�[�h�Q�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public HINCLCID() As Char '���ރR�[�h�R�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCLANM() As Char '���ޖ��̂P�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCLBNM() As Char '���ޖ��̂Q�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCLCNM() As Char '���ޖ��̂R�i���i�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DSPKB() As Char '�����\���敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public ZAIKB() As Char '�݌ɊǗ��敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINZEIKB() As Char '���i����ŋ敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public ZEIRNKKB() As Char '����Ń����N
		Dim ZEIRT As Decimal '����ŗ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINJUNKB() As Char '���ʕ\�o�͋敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public MAKCD() As Char '���[�J�[�R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCMA() As Char '���i���l�`
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCMB() As Char '���i���lB
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCMC() As Char '���i���lC
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCMD() As Char '���i���lD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINCME() As Char '���i���l�d
		Dim TEIKATK As Decimal '�艿
		Dim ZNKURITK As Decimal '�Ŕ��̔��P��
		Dim ZKMURITK As Decimal '�ō��̔��P��
		Dim ZNKSRETK As Decimal '�Ŕ��d���P��
		Dim ZKMSRETK As Decimal '�ō��d���P��
		Dim GNKTK As Decimal '�����P��
		Dim PLANTK As Decimal '�v��P��
		Dim SODUNTSU As Decimal '�����P�ʐ�
		Dim TEKZAISU As Decimal '�K���݌ɐ�
		Dim ANZZAISU As Decimal '���S�݌ɐ��i�̔��v��p�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public HRTDD() As Char '�������[�h�^�C��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public ORTDD() As Char '�o�׃��[�h�^�C��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public PRCDD() As Char '���B���[�h�^�C��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public MNFDD() As Char '�������[�h�^�C��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public HINSIRCD() As Char '���i�d����R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public HINSIRRN() As Char '���i�d���於��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TNACM() As Char '�I�ԍ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public HINNMMKB() As Char '�����ƭ�ٓ��͋敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(13),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=13)> Public JANCD() As Char '�i�`�m�R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public HINFRNNM() As Char '���i���C�O�\�L
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public ZAIRNK() As Char '�݌Ƀ����N
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public GNKCD() As Char '�����Ǘ��R�[�h
		Dim MINSODSU As Decimal '�ŏ�������
		Dim SODADDSU As Decimal '����������
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public JODHIKKB() As Char '�󒍈����敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public ORTSTPKB() As Char '�o�ג�~
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public ORTSTYDT() As Char '�o�׊J�n�\���
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public CTLGKB() As Char '�J�^���O�i�Ώ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MLOKB() As Char '�ʔ̑Ώ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public MLOHINID() As Char '�ʔ̐��i�h�c
		Dim MLOIDORT As Decimal '�ʔ̈ړ��䗦
		Dim MLOLMTSU As Decimal '�ʔ̈ړ����x��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public PRDENDKB() As Char '���Y�I��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public PRDENDDT() As Char '���Y�I�����t
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SLENDKB() As Char '�̔�����
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public SLENDDT() As Char '�̔��������t
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public JODSTPKB() As Char '�󒍒�~
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public JODSTPDT() As Char '�󒍒�~���t
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MNTENDKB() As Char '�ێ�I��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public MNTENDDT() As Char '�ێ�I�����t
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public ORTKB() As Char '�o�׋敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SERIKB() As Char '�V���A���Ǘ��敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public MAKNM() As Char '���[�J�[��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(40),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=40)> Public NXTMDL() As Char '��p�@��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public JODSTDT() As Char '�󒍊J�n��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public ORTSTDT() As Char '�o�׊J�n��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public KOUZA() As Char '����
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(15),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=15)> Public MDLCL() As Char '�@�핪��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(15),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=15)> Public OLDMDLCL() As Char '���@�핪��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(4),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=4)> Public HINGRP() As Char '���i�Q
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public OEMKB() As Char '�n�d�l
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public OEMTOKRN() As Char '�n�d�l���Ӑ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public OPENKB() As Char '�I�[�v�����i�敪
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public RELFL() As Char '�A�g�t���O
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '�^�C���X�^���v�i���ԁj
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '�^�C���X�^���v�i���t�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char '�^�C���X�^���v�i�o�^���ԁj
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char '�^�C���X�^���v�i�o�^���j
	End Structure
	Private DB_HINMTA As TYPE_DB_HINMTA
	Private DBN_HINMTA As Short
	
	'************************************************************************************
	'���i�}�X�^�����߂�l
	'************************************************************************************
	
	Private WLSHIN_RTNCODE As String '���i�R�[�h
	Private WLSHIN_RTNKATA As String '�^��
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	
	Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
	
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	'�E�B���hհ�ް�ݒ�ϐ�
	Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
	Private WM_WLS_CODELEN As Short '�J�n���i���ޓ��͕�����
	Private WM_WLS_HINNMALEN As Short '�^�����͕�����
	Private WM_WLS_HINNMBLEN As Short '�i���\��������
	
	'�E�B���h�����g�p�ϐ�
	Private WM_WLS_MAX As Short '�P��ʂ̕\������
	Private WM_WLS_CODE As String '���i�R�[�h�����p
	Private WM_WLS_HINNMA As String '�^�������p
	Private WM_WLS_HINNK_S As String '���i���J�i�����p(�J�n)
	Private WM_WLS_HINNK_E As String '���i���J�i�����p(�I��)
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
	Private DblClickFl As Boolean
	
	Private DB_HINMTA_W As TYPE_DB_HINMTA '�f�[�^�擾���ʊi�[�\����
	
	'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
	Private OraDyn As OraDynaset '�_�C�i�Z�b�g
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Property pWLSHIN_RTNCODE
	'   �T�v�F  ���i�R�[�h
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Property pWLSHIN_RTNCODE
	'   �T�v�F  ���i�R�[�h
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Property pWLSHIN_RTNCODE() As String
		Get
			pWLSHIN_RTNCODE = WLSHIN_RTNCODE
		End Get
		Set(ByVal Value As String)
			WLSHIN_RTNCODE = Value
		End Set
	End Property
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Property pWLSHIN_RTNKATA
	'   �T�v�F  �^��
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Property pWLSHIN_RTNKATA
	'   �T�v�F  �^��
	'   �����F
	'   �ߒl�F
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Property pWLSHIN_RTNKATA() As String
		Get
			pWLSHIN_RTNKATA = WLSHIN_RTNKATA
		End Get
		Set(ByVal Value As String)
			WLSHIN_RTNKATA = Value
		End Set
	End Property
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_FORM_INIT
	'   �T�v�F  ��ʏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_FORM_INIT()
		'=== �\���J�n�R�[�h�����ݒ� ===
		WM_WLS_CODELEN = 8
		WM_WLS_HINNMALEN = 30
		WM_WLS_HINNMBLEN = 50
		WM_WLS_MAX = 15 '��ʕ\������
		
		'�ϐ�������
		Call WLS_Clear()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		
		WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_HINMTA_W.HINCD, WM_WLS_CODELEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMA, WM_WLS_HINNMALEN) & Space(2) & LeftWid(DB_HINMTA_W.HINNMB, WM_WLS_HINNMBLEN)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_TextSQL
	'   �T�v�F  ����sql�쐬
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_TextSQL()
		
		Dim strSQL As String
		Dim intData As Short
		
		strSQL = ""
		strSQL = strSQL & " Select HINCD " '���i�R�[�h
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i��
		strSQL = strSQL & "   from HINMTA "
		strSQL = strSQL & "  Where DATKB = '1' "
		strSQL = strSQL & "    and DSPKB = '1' "
		
		'���i�R�[�h����
		If Trim(WM_WLS_CODE) <> "" Then
			''''            strSQL = strSQL & "    and HINCD >=   '" & WM_WLS_CODE & "'"
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            strSQL = strSQL & "    and HINCD LIKE '" & Trim(WM_WLS_CODE) & "%'"
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "    and HINCD LIKE " & D0.Edt_SQL("S", Trim(WM_WLS_CODE) & "%")
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		'�^������(�����܂�����)
		If Trim(WM_WLS_HINNMA) <> "" Then
			'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    �A���[��661�u'�v�Ή��C��
			'            strSQL = strSQL & "    and HINNMA LIKE '%" & Trim(WM_WLS_HINNMA) & "%'"
			'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSQL = strSQL & "    and HINNMA LIKE " & D0.Edt_SQL("S", "%" & Trim(WM_WLS_HINNMA) & "%")
			'''' UPD 2009/12/03  FKS) T.Yamamoto    End
		End If
		
		'���i���J�i����
		If Trim(WM_WLS_HINNK_S) <> "" Then
			strSQL = strSQL & "    and HINNK >= '" & Trim(WM_WLS_HINNK_S) & "' And HINNK < '" & Trim(WM_WLS_HINNK_E) & "'"
		End If
		
		'�\�[�g����
		strSQL = strSQL & "   order by "
		If Trim(WM_WLS_HINNK_S) <> "" Then
			'���i���J�i�����̏ꍇ
			strSQL = strSQL & "   HINNK "
			strSQL = strSQL & "  ,HINCD "
		Else
			'���i�R�[�h����,�^������
			strSQL = strSQL & "   HINCD "
		End If
		
		D0.Mouse_ON()
		
		'DB�A�N�Z�X
		'UPGRADE_WARNING: WLS_TextSQL �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		
		D0.Mouse_OFF()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspNew
	'   �T�v�F  ���X�g�ҏW����(�������)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspNew()
		Dim Cnt As Integer
		
		'���X�g�r���[�̃N���A
		LST.Items.Clear()
		
		Cnt = 0
		'UPGRADE_WARNING: WLS_DspNew �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		
		'�ŏI�f�[�^���B
		'UPGRADE_WARNING: WLS_DspNew �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		
		If Cnt > 0 Then
			'�y�[�W��\��
			Call WLS_DspPage()
		End If
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_DspPage
	'   �T�v�F  ���X�g�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_DspPage()
		Dim WL_Mode As Short
		Dim IntCnt As Short
		
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		LST.Items.Clear()
		IntCnt = 0
		Do While IntCnt < WM_WLS_MAX
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + IntCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + IntCnt))
			End If
			IntCnt = IntCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Kana_Init
	'   �T�v�F  �J�i�R���{�{�b�N�X������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Kana_Init()
		
		'�J�i���� Combo ������
		WLSKANA.Items.Add("�R�[�h")
		WLSKANA.Items.Add("�A�s      ��")
		WLSKANA.Items.Add("�J�s      ��")
		WLSKANA.Items.Add("�T�s      ��")
		WLSKANA.Items.Add("�^�s      ��")
		WLSKANA.Items.Add("�i�s      ��")
		WLSKANA.Items.Add("�n�s      ��")
		WLSKANA.Items.Add("�}�s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		WLSKANA.Items.Add("���s      ��")
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Clear
	'   �T�v�F  �ϐ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		
		'��������
		WM_WLS_CODE = ""
		WM_WLS_HINNMA = ""
		WM_WLS_HINNK_S = ""
		WM_WLS_HINNK_E = ""
		
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_GetInputData
	'   �T�v�F  ���͓��e�̎擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_GetInputData()
		Dim W_BUF As Object
		
		'��������
		WM_WLS_CODE = HD_CODE.Text
		WM_WLS_HINNMA = HD_KATA.Text
		If WLSKANA.SelectedIndex > 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			W_BUF = VB.Right(VB6.GetItemString(WLSKANA, WLSKANA.SelectedIndex), 2)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_HINNK_S = VB.Left(W_BUF, 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WM_WLS_HINNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
		Else
			WM_WLS_HINNK_S = ""
			WM_WLS_HINNK_E = ""
		End If
		
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
	End Sub
	'
	'�ȉ��͉�ʃC�x���g����
	'
	'UPGRADE_WARNING: Form �C�x���g HKKHIN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub HKKHIN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		
		'WINDOW �ʒu�ݒ�
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		WM_WLS_Dspflg = False
		
		'���ڏ�����
		Call WLS_Kana_Init()
		HD_CODE.Text = pWLSHIN_RTNCODE
		HD_KATA.Text = pWLSHIN_RTNKATA
		WLSKANA.SelectedIndex = 0
		LST.Items.Clear()
		WM_WLS_Dspflg = True
		
		ReDim WM_WLS_DSPArray(0)
		
		WM_WLS_CODE = pWLSHIN_RTNCODE
		WM_WLS_HINNMA = pWLSHIN_RTNKATA
		
		pWLSHIN_RTNCODE = ""
		pWLSHIN_RTNKATA = ""
		
		'������ԑS���\��
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
		DblClickFl = False
		
		Me.Refresh()
		''''        HD_KATA.SetFocus
		LST.Focus()
	End Sub
	
	Private Sub HKKHIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Window�����ݒ�
		Call WLS_FORM_INIT()
	End Sub
	
	Private Sub HD_CODE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_CODE.Enter
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(HD_CODE.Text) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(HD_CODE.Text) > 0 Then
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			''''    Else
			''''        HD_CODE.Text = Space$(HD_CODE.MaxLength)
		End If
		HD_CODE.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_CODE.SelectionLength = HD_CODE.Maxlength
	End Sub
	
	Private Sub HD_CODE_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_CODE.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
			HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)
			
			'���������啶���E�󔒃J�b�g
			Call HD_CODE_Validating(HD_CODE, New System.ComponentModel.CancelEventArgs(False))
			
			'�����p�ϐ��Z�b�g
			Call WLS_GetInputData()
			
			'�����p�ϐ��Z�b�g
			''''        Call WLS_Clear
			''''        WM_WLS_CODE = HD_CODE.Text
			
			'�����������N���A
			''''        WLSKANA.ListIndex = 0
			''''        HD_KATA.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_CODE_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_CODE.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		HD_CODE.Text = UCase(Trim(HD_CODE.Text))
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub HD_KATA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KATA.Enter
		
		''''    If LenWid(HD_KATA.Text) <= 0 Then
		''''        HD_KATA.Text = Space$(HD_KATA.MaxLength)
		''''    End If
		HD_KATA.SelectionStart = 0
		'UPGRADE_WARNING: TextBox �v���p�e�B HD_KATA.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		HD_KATA.SelectionLength = HD_KATA.Maxlength
	End Sub
	
	Private Sub HD_KATA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KATA.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = False
			
			'�󔒃J�b�g
			Call HD_KATA_Validating(HD_KATA, New System.ComponentModel.CancelEventArgs(False))
			
			'�����p�ϐ��Z�b�g
			Call WLS_GetInputData()
			
			'�����p�ϐ��Z�b�g
			''''        Call WLS_Clear
			''''        WM_WLS_HINNMA = HD_KATA.Text
			
			'�����������N���A
			''''        WLSKANA.ListIndex = 0
			''''        HD_CODE.Text = ""
			WM_WLS_Dspflg = True
			
			Call WLS_TextSQL()
			Call WLS_DspNew()
		End If
	End Sub
	
	Private Sub HD_KATA_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles HD_KATA.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		HD_KATA.Text = Trim(HD_KATA.Text)
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		
		DblClickFl = True
		pWLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		pWLSHIN_RTNKATA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), 11, WM_WLS_HINNMALEN)
		
	End Sub
	
	Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		
		If DblClickFl Then
			Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
		End If
		
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
				Call WLSOK_Click(WLSOK, New System.EventArgs())
				
				'Escape�L�[����
			Case System.Windows.Forms.Keys.Escape
				Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Left
				Call WLSMAE_Click(WLSMAE, New System.EventArgs())
				
				'���L�[����
			Case System.Windows.Forms.Keys.Right
				Call WLSATO_Click(WLSATO, New System.EventArgs())
				If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub
	
	'UPGRADE_WARNING: �C�x���g WLSKANA.SelectedIndexChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub WLSKANA_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSKANA.SelectedIndexChanged
		Dim W_BUF As Object
		If WM_WLS_Dspflg = False Then Exit Sub
		WM_WLS_Dspflg = False
		WM_WLS_Dspflg = True
		
		'�����p�ϐ��Z�b�g
		Call WLS_GetInputData()
		
		''''        Call WLS_Clear
		
		''''        '�����p�ϐ��Z�b�g
		''''        If WLSKANA.ListIndex > 0 Then
		''''            W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
		''''            WM_WLS_HINNK_S = Left$(W_BUF, 1)
		''''            WM_WLS_HINNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
		''''        Else
		''''            WM_WLS_HINNK_S = ""
		''''            WM_WLS_HINNK_E = ""
		''''        End If
		
		'�����������N���A
		''''        HD_CODE.Text = ""
		''''        HD_KATA.Text = ""
		WM_WLS_Dspflg = True
		
		Call WLS_TextSQL()
		Call WLS_DspNew()
		
	End Sub
	
	Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then
			WM_WLS_Dspflg = True
			Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
		Else
			WM_WLS_Dspflg = False
		End If
	End Sub
	
	Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click
		
		If LST.Items.Count <= 0 Then Exit Sub
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(1).Image
	End Sub
	
	Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSATO.Image = IM_ATO(0).Image
	End Sub
	
	Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
	End Sub
	
	Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(1).Image
	End Sub
	
	Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		WLSMAE.Image = IM_MAE(0).Image
	End Sub
	
	Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
		
		pWLSHIN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
		pWLSHIN_RTNKATA = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), 11, WM_WLS_HINNMALEN)
		
		'�N���[�Y
		'UPGRADE_WARNING: WLSOK_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		'��ʂ��B��
		Hide()
		
	End Sub
	
	Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
		
		'�N���[�Y
		'UPGRADE_WARNING: WLSCANCEL_CLICK �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		'��ʂ��B��
		Hide()
		
	End Sub
	
	'
	'�ȉ��͋��ʊ֐��i���p�j
	'
    '2019/04/10 CHG START
    'Private Function LeftWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    Public Function LeftWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
        '2019/04/10 CHG E N D
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LeftB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/10 CHG START
        'LeftWid = StrConv(LeftB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
        LeftWid = LeftB(pm_Characters, pm_Wid)
        '2019/04/10 CHG E N D
    End Function
    '2019/04/10 CHG START
    'Private Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
    Public Function RightWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
        '2019/04/10 CHG E N D
        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: RightB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/10 CHG START
        'RightWid = StrConv(RightB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
        RightWid = RightB(pm_Characters, pm_Wid)
        '2019/04/10 CHG E N D
    End Function
	Public Function MidWid(ByVal pm_Characters As String, ByVal pm_Wid As Integer, Optional ByVal pm_LnWid As Object = Nothing) As String
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(pm_LnWid) Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/04/10 CHG START
            'MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid), vbUnicode)
            MidWid = MidB(pm_Characters, pm_Wid)
            '2019/04/10 CHG E N D
        Else
            'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
            'UPGRADE_ISSUE: MidB$ �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
            '2019/04/10 CHG START
            'MidWid = StrConv(MidB$(StrConv(pm_Characters, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
            MidWid = MidB(pm_Characters, pm_Wid, pm_LnWid)
            '2019/04/10 CHG E N D
        End If
	End Function
    '2019/04/10 CHG START
    'Private Function LenWid(ByVal pm_Characters As Object) As Object
    Public Function LenWid(ByVal pm_Characters As Object) As Object
        '2019/04/10 CHG E N D
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(pm_Characters) Then
            'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g LenWid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            LenWid = System.DBNull.Value
            Exit Function
        End If
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g pm_Characters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        '2019/04/10 CHG START
        'LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
        LenWid = LenB(pm_Characters)
        '2019/04/10 CHG E N D
    End Function
	Private Function SSS_EDTITM_WLS(ByVal Item As Object, ByVal KETA As Object, ByVal HENSYU As Object) As String
		Select Case HENSYU
			Case "0"
				'UPGRADE_WARNING: �I�u�W�F�N�g KETA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SSS_EDTITM_WLS = RightWid(FormatAndRound(Item, "00000000000000000000"), KETA)
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g Item �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SSS_EDTITM_WLS = Item
		End Select
	End Function
	Private Function FormatAndRound(ByVal pm_Value As Object, ByVal pm_FormatChr As String) As String 'V6.59
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(pm_Value) Then
			FormatAndRound = ""
			Exit Function '----------
		End If
		Dim sg_Value As String
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		sg_Value = CStr(pm_Value)
		'
		Dim M As Integer
		Dim Ln As Integer
		Dim n As Integer
		Dim i As Integer
		Dim OneChr As String '�����_��艺�̌� '�擪�̃t�H�[�}�b�g�������ڂ̕�����
		Do 
			M = InStr(sg_Value, ".")
			If M > 0 Then M = Len(sg_Value) - M
			'
			Ln = InStr(pm_FormatChr, ";") - 1
			If Ln < 0 Then Ln = Len(pm_FormatChr)
			'
			n = InStr(pm_FormatChr, ".")
			If n > 0 Then n = Ln - n
			'
			If n >= 0 And n + 1 = M And VB.Right(sg_Value, 1) = "5" Then
				For i = 1 To Ln
					OneChr = Mid(pm_FormatChr, i, 1)
					Select Case OneChr
						Case "#", ",", ".", "\", "+", "-"
						Case Else
							If OneChr >= "0" And OneChr <= "9" Then
							Else
								Exit Do '-----
							End If
					End Select
				Next i
				FormatAndRound = VB6.Format(sg_Value & "1", pm_FormatChr) 'V6.59
				Exit Function '----------
			Else
				Exit Do '-----
			End If
		Loop 
		'
		FormatAndRound = VB6.Format(sg_Value, pm_FormatChr) 'V6.59
    End Function 'V6.59

End Class