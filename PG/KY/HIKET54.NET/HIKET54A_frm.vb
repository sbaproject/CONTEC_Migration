Option Strict Off
Option Explicit On
Friend Class FR_SSSSUB01
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
	'=== ����ʂ̑S�����i�[ =================
	'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Main_Inf As Cls_All
	'=== ����ʂ̑S�����i�[ =================
	Private Const FM_PANEL3D1_CNT As Short = 20 '�p�l���R���g���[����
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Init_Def_Dsp
	'   �T�v�F  �e��ʂ̍��ڏ���ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Init_Def_Dsp() As Short
		
		Dim Index_Wk As Short
		Dim BD_Cnt As Short
		Dim Wk_Cnt As Short
		
		'��ʊ�b���ʏ��ݒ�
		Call CF_Init_Def_Dsp(Me, Main_Inf)
		
		'/////////////////////
		'// ���b�Z�[�W���ʐݒ�
		'/////////////////////
		Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
		Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
		Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
		Main_Inf.Dsp_TX_Message = TX_Message
		
		'�r���������������������������������������������������������r
		'��ʊ�b���ݒ�
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REVISION '��ʕ���
			.Item_Cnt = 183 '��ʍ��ڐ�
			.Dsp_Body_Cnt = 15 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
			.Max_Body_Cnt = 99 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
			.Body_Col_Cnt = 8 '���ׂ̗񍀖ڐ�
			.Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1 '��ʈړ���
			.FormCtl = Me
		End With
		'�d���������������������������������������������������������d
		
		'��ʍ��ڏ��
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'�r���������������������������������������������������������r
		'/////////////////////
		'// �S��ʗp����p���۰�
		'/////////////////////
		'�����ݒ�p�^�C�}�[
		Main_Inf.TM_StartUp_Ctl = TM_StartUp
		Main_Inf.TM_StartUp_Ctl.Interval = 1
		Main_Inf.TM_StartUp_Ctl.Enabled = True
		
		Index_Wk = 0
		'�J�[�\������p�e�L�X�g
		TX_CursorRest.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// ���j���[���ҏW
		'///////////////////
		Index_Wk = Index_Wk + 1
		'�����P
		MN_Ctrl.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�o�^
		MN_Execute.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'��ʈ��
		MN_HARDCOPY.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�I��
		MN_EndCm.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�����Q
		MN_EditMn.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ڏ�����
		MN_ClearItm.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ڕ���
		MN_UnDoItem.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�؂���
		MN_Cut.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�R�s�[
		MN_Copy.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�\��t��
		MN_Paste.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����R
		MN_Oprt.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�I��
		MN_SELECTCM.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_SELECTCM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�O��
		MN_PREV.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_PREV
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		MN_NEXTCM.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_NEXTCM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ڂ̈ꗗ
		MN_Slist.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ړ��e�ɃR�s�[
		SM_AllCopy.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'������
		SM_Esc.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ڂɓ\��t��
		SM_FullPast.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�I���C���[�W
		CM_EndCm.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== �Ұ�ސݒ� ======================
		Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
		Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
		'=== �Ұ�ސݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'���s�C���[�W
		CM_Execute.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== �Ұ�ސݒ� ======================
		Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
		Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
		'=== �Ұ�ސݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'�w�b�_�C���[�W
		Image1.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�������t
		'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SYSDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// �w�b�_���ҏW
		'///////////////////
		Index_Wk = Index_Wk + 1
		'���͒S����(����)
		HD_IN_TANCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���͒S����(����)
		HD_IN_TANNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�`�[���
		HD_DEN_SBT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DEN_SBT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_SBNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPD 20160216 START C2-20160129-01
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
		'UPD 20160216 END C2-20160129-01
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���i�R�[�h
		HD_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'''' UPD 2009/02/20  FKS) S.Nakajima    Start
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'''' UPD 2009/02/20  FKS) S.Nakajima    End
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�^��
		HD_HINNMA.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�i��
		HD_HINNMB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_UODSU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_UODSU
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�蓮�ϐ�
		HD_MNSU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MNSU
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�����ϐ�
		HD_ZUMISU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_ZUMISU
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
		
		'///////////////
		'// �{�f�B���ҏW
		'///////////////
		Index_Wk = Index_Wk + 1
		'�c�X�N���[��
		VS_Scrl.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = VS_Scrl
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ���׏c�X�N���[���o�[�ݒ� ======================
		Main_Inf.Bd_Vs_Scrl = VS_Scrl
		'=== ���׏c�X�N���[���o�[�ݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'�q��(����)
		BD_SOUNM(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
		'���b�g�ԍ�
		BD_LOTNO(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LOTNO(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ח\���
		BD_NYUYTDT(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUYTDT(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���݌ɐ�
		BD_RELZAISU(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_RELZAISU(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�����ϐ�
		BD_ZUMISU(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ZUMISU(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�����\��
		BD_HIKSU(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�蓮������
		BD_MNSU(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MNSU(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'������
		BD_INP_HIKSU(0).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_INP_HIKSU(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			BD_SOUNM.Load(BD_Cnt) '�q�ɖ�
			BD_LOTNO.Load(BD_Cnt) '���b�g�ԍ�
			BD_NYUYTDT.Load(BD_Cnt) '���ɗ\���
			BD_RELZAISU.Load(BD_Cnt) '���݌ɐ�
			BD_ZUMISU.Load(BD_Cnt) '�����ϐ�
			BD_HIKSU.Load(BD_Cnt) '�����\��
			BD_MNSU.Load(BD_Cnt) '�蓮������
			BD_INP_HIKSU.Load(BD_Cnt) '������
			
			Index_Wk = Index_Wk + 1
			'�q�ɖ�
			BD_SOUNM(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���b�g�ԍ�
			BD_LOTNO(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LOTNO(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���ɗ\���
			BD_NYUYTDT(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUYTDT(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���݌ɐ�
			BD_RELZAISU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_RELZAISU(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�����ϐ�
			BD_ZUMISU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ZUMISU(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�����\��
			BD_HIKSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�蓮������
			BD_MNSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MNSU(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'������
			BD_INP_HIKSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_INP_HIKSU(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
		Next 
		
		'///////////////
		'// �t�b�^���ҏW
		'///////////////
		
		'///////////////////
		'// ���b�Z�[�W���ҏW
		'///////////////////
		Index_Wk = Index_Wk + 1
		'���b�Z�[�W
		TX_Message.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Message
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
		'TX_Mode
		TX_Mode.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// ���̑��ҏW
		'///////////////////
		For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
			Index_Wk = Index_Wk + 1
			'FM_Panel3D1
			'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		Next 
		
		'���ו��̉B���s���\��/�g�p�s�ɐݒ�
		BD_SOUNM(0).Visible = False : BD_SOUNM(0).Enabled = False
		BD_LOTNO(0).Visible = False : BD_LOTNO(0).Enabled = False
		BD_NYUYTDT(0).Visible = False : BD_NYUYTDT(0).Enabled = False
		BD_RELZAISU(0).Visible = False : BD_RELZAISU(0).Enabled = False
		BD_ZUMISU(0).Visible = False : BD_ZUMISU(0).Enabled = False
		BD_HIKSU(0).Visible = False : BD_HIKSU(0).Enabled = False
		BD_MNSU(0).Visible = False : BD_MNSU(0).Enabled = False
		BD_INP_HIKSU(0).Visible = False : BD_INP_HIKSU(0).Enabled = False
		
		'�d���������������������������������������������������������d
		
		'��L�ݒ���e�����ۂ̺��۰قɐݒ肷��
		Call CF_Init_Item_Property(Main_Inf)
		'��ʍ��ڏ����Đݒ�
		Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)
		
		'///////////////////
		'// ���ʍ��ڂ̍Đݒ�
		'///////////////////
		'�J�[�\������p�e�L�X�g
		TX_CursorRest.TabStop = False
		TX_Message.TabStop = False
		
		'��ʕҏW�t���O������
		gv_bolHIKET54_INIT = False
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_VbKeyReturn
	'   �T�v�F  �e���ڂ�VBKEYRETURN����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyReturn(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
			'�L�[�t���O�����ɖ߂�
			gv_bolKeyFlg = False
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			Call SSSMAIN0003.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_VbKeyRight
	'   �T�v�F  �e���ڂ�VBKEYRIGHT����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyRight(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYRIGHT����
		Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'�`�F�b�N�n�j��
				'�擾���e�\��
				Dsp_Mode = DSP_SET
			Else
				'�`�F�b�N�m�f��
				'�擾���e�N���A
				Dsp_Mode = DSP_CLR
			End If
			'�擾���e�\��/�N���A
			Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYRIGHT����(̫����ړ��Ȃ�)
				Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'������ړ�����
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_VbKeyDown
	'   �T�v�F  �e���ڂ�VBKEYDOWN����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyDown(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = False
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			'KEYDOWN����
			Call SSSMAIN0003.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			If Move_Flg = True Then
				'���̍��ڂֈړ������ꍇ
				'������ړ�����
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				
				'���ڐF�ݒ�
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
			End If
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_VbKeyLeft
	'   �T�v�F  �e���ڂ�VBKEYLEFT����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyLeft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYLEFT����
		Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'�`�F�b�N�n�j��
				'�擾���e�\��
				Dsp_Mode = DSP_SET
			Else
				'�`�F�b�N�m�f��
				'�擾���e�N���A
				Dsp_Mode = DSP_CLR
			End If
			'�擾���e�\��/�N���A
			Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT����(̫����ړ�����)
				Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'������ړ�����
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_VbKeyUp
	'   �T�v�F  �e���ڂ�VBKEYUP����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_VbKeyUp(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			'KEYUP����
			Call SSSMAIN0003.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			
			If Move_Flg = True Then
				'���̍��ڂֈړ������ꍇ
				'������ړ�����
				Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				
				'���ڐF�ݒ�
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
			End If
			
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyDown
	'   �T�v�F  �e���ڂ�KEYDOWN����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef pm_KeyCode As Short, ByRef pm_Shift As Short) As Short
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		
		'Enter���̂݃t���O��ON
		If pm_KeyCode = System.Windows.Forms.Keys.Return Then
			If gv_bolKeyFlg = True Then
				Exit Function
			End If
			
			gv_bolKeyFlg = True
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case True
			'��������
			Case pm_KeyCode = System.Windows.Forms.Keys.Return And pm_Shift = 0
				pm_KeyCode = 0
				'����������
				Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'����
			Case pm_KeyCode = System.Windows.Forms.Keys.Right And pm_Shift = 0
				pm_KeyCode = 0
				'������
				Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'����
			Case pm_KeyCode = System.Windows.Forms.Keys.Down And pm_Shift = 0
				pm_KeyCode = 0
				'������
				Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'����
			Case pm_KeyCode = System.Windows.Forms.Keys.Left And pm_Shift = 0
				pm_KeyCode = 0
				'������
				Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'����
			Case pm_KeyCode = System.Windows.Forms.Keys.Up And pm_Shift = 0
				'������
				pm_KeyCode = 0
				Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'DELETE��
			Case pm_KeyCode = System.Windows.Forms.Keys.Delete And pm_Shift = 0
				pm_KeyCode = 0
				Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
				'INSERT��
			Case pm_KeyCode = System.Windows.Forms.Keys.Insert And pm_Shift = 0
				pm_KeyCode = 0
				Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
				'TAB��
			Case pm_KeyCode = System.Windows.Forms.Keys.F16
				pm_KeyCode = 0
				'����������
				Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
				
				'Shift+TAB��
			Case pm_KeyCode = System.Windows.Forms.Keys.F15
				pm_KeyCode = 0
				'�O̫����ʒu�ֈړ�
				Call SSSMAIN0003.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
				'�t�@���N�V�����L�[������
			Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
				'�t�@���N�V�����L�[���ʏ���
				Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyUp
	'   �T�v�F  �e���ڂ�CLICK����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Act_Index As Short
		
		'�������ޯ���擾
		Act_Index = CShort(pm_Ctl.Tag)
		
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_LostFocus
	'   �T�v�F  �e���ڂ�LOSTFOCUS����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_LostFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Boolean
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		Ctl_Item_LostFocus = True
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'����̫������۰َ擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'۽�̫������s����
		If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
			Main_Inf.Dsp_Base.LostFocus_Flg = False
			Exit Function
		End If
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		End If
		
		Ctl_Item_LostFocus = Chk_Move_Flg
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_GotFocus
	'   �T�v�F  �e���ڂ�GOTFOCUS����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_GotFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'��ʒP�ʂ̏���(�����Ȃ�)
		'���ו��ł��ړ��O�����ו��łȂ��ꍇ
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'�r���������������������������������������������������������r
			'ͯ�ޕ�����
			Rtn_Chk = SSSMAIN0003.F_Ctl_Head_Chk(Main_Inf)
			'�d���������������������������������������������������������d
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If
		
		'�r���������������������������������������������������������r
		'����̫����擾����
		Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyPress
	'   �T�v�F  �e���ڂ�KEYPRESS����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyPress(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef pm_KeyAscii As Short) As Short
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'����KEYPRESS����
		Call SSSMAIN0003.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
			If Rtn_Chk = CHK_OK Then
				'�`�F�b�N�n�j��
				'�擾���e�\��
				Dsp_Mode = DSP_SET
			Else
				'�`�F�b�N�m�f��
				'�擾���e�N���A
				Dsp_Mode = DSP_CLR
			End If
			'�擾���e�\��/�N���A
			Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				
				'����̫����ʒu����E�ֈړ�
				Call SSSMAIN0003.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
				'������ړ�����
				Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				
				'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			End If
			
		Else
			'���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
			Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_Change
	'   �T�v�F  �e���ڂ�CHANGE����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		
		If Main_Inf.Dsp_Base.Change_Flg = True Then
			Main_Inf.Dsp_Base.Change_Flg = False
			Exit Function
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'����KEYCHANG����
		Call SSSMAIN0003.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
		'��ʒP�ʂ̏���(�����Ȃ�)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_MouseUp
	'   �T�v�F  �e���ڂ�MOUSEUP����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseUp(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
				
			Case TypeOf pm_Ctl Is SSPanel5
				'�p�l���̏ꍇ
				Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'�C���[�W�̏ꍇ
				Select Case Trg_Index
					Case CShort(CM_EndCm.Tag)
						'�I���Ұ��
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
						
					Case CShort(CM_Execute.Tag)
						'���s�Ұ��
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
				End Select
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_MouseMove
	'   �T�v�F  �e���ڂ�MOUSEMOVE����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseMove(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(Image1.Tag)
				'�Ұ�ނP������
				Call CF_Clr_Prompt(Main_Inf)
				
			Case CShort(CM_EndCm.Tag)
				'�I���Ұ��
				Call CF_Set_Prompt(IMG_ENDCM_SUB_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
			Case CShort(CM_Execute.Tag)
				'���s�Ұ��
				Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_MouseDown
	'   �T�v�F  �e���ڂ�MOUSEDOWN����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_MouseDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(CM_EndCm.Tag)
				'�I���Ұ��
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)
				
			Case CShort(CM_Execute.Tag)
				'���s�Ұ��
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)
				
		End Select
		
		'����MOUSEDOWN����
		Call SSSMAIN0003.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_Click
	'   �T�v�F  �e���ڂ�CLICK����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'��è�޺��۰ي������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�r���������������������������������������������������������r
		'�e������ʌďo
		Select Case Trg_Index
			Case CShort(MN_Ctrl.Tag)
				'�����P
				Call Ctl_MN_Ctrl_Click()
				
			Case CShort(MN_Execute.Tag)
				'���s
				Call Ctl_MN_Execute_Click()
				
			Case CShort(MN_HARDCOPY.Tag)
				'��ʈ��
				Call Ctl_MN_HARDCOPY_Click()
				
			Case CShort(MN_EndCm.Tag)
				'�I��
				Call Ctl_MN_EndCm_Click()
				
			Case CShort(MN_EditMn.Tag)
				'�����Q
				Call Ctl_MN_EditMn_Click()
				
			Case CShort(MN_ClearItm.Tag)
				'���ڏ�����
				Call Ctl_MN_ClearItm_Click()
				
			Case CShort(MN_UnDoItem.Tag)
				'���ڕ���
				Call Ctl_MN_UnDoItem_Click()
				
			Case CShort(MN_Cut.Tag)
				'�؂���
				Call Ctl_MN_Cut_Click()
				
			Case CShort(MN_Copy.Tag)
				'�R�s�[
				Call Ctl_MN_Copy_Click()
				
			Case CShort(MN_Paste.Tag)
				'�\��t��
				Call Ctl_MN_Paste_Click()
				
			Case CShort(MN_Oprt.Tag)
				'����R
				Call Ctl_MN_Oprt_Click()
				
			Case CShort(MN_SELECTCM.Tag)
				'�I��
				Call Ctl_MN_SELECTCM_Click()
				
			Case CShort(MN_PREV.Tag)
				'�O��
				Call Ctl_MN_PREV_Click()
				
			Case CShort(MN_NEXTCM.Tag)
				'����
				Call Ctl_MN_NEXTCM_Click()
				
			Case CShort(MN_Slist.Tag)
				'���ڂ̈ꗗ
				Call Ctl_MN_Slist_Click()
				
			Case CShort(SM_AllCopy.Tag)
				'���ړ��e�ɃR�s�[
				Call Ctl_SM_AllCopy_Click()
				
			Case CShort(SM_Esc.Tag)
				'������
				Call Ctl_SM_Esc_Click()
				
			Case CShort(SM_FullPast.Tag)
				'���ڂɓ\��t��
				Call Ctl_SM_FullPast_Click()
				
				'�����j���[�C���[�W
			Case CShort(CM_EndCm.Tag)
				'�I��
				Me.Close()
				
			Case CShort(CM_Execute.Tag)
				'���s
				Call Ctl_MN_Execute_Click()
				
		End Select
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Ctrl_Click
	'   �T�v�F  ���j���[�����P�̎g�p�s�𐧌�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Ctrl_Click() As Short
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'����s�����
		MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'���ʈ�������
		MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'��I�������
		MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_EditMn_Click
	'   �T�v�F  ���j���[�����Q�̎g�p�s�𐧌�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_EditMn_Click() As Short
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'����ڏ����������
		MN_ClearItm.Enabled = False
		'����ڕ��������
		MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'��؂��裔���
		MN_Cut.Enabled = False
		'��R�s�[�����
		MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'��\��t�������
		MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_EditMn_Click
	'   �T�v�F  ���j���[����R�̎g�p�s�𐧌�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Oprt_Click() As Short
		
		Dim Ant_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
		'��I�𣏉����
		MN_SELECTCM.Enabled = False
		'��O�ţ������
		MN_PREV.Enabled = False
		'����ţ������
		MN_NEXTCM.Enabled = False
		'����̈ꗗ�������
		MN_Slist.Enabled = False
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Execute_Click
	'   �T�v�F  ���s
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function Ctl_MN_Execute_Click() As Short
		
		Dim intRet As Short
		
		intRet = SSSMAIN0003.F_Ctl_Upd_Process(Main_Inf)
		
		'�X�V������̏ꍇ�͏��������Ɠ����������s��
		If intRet = 0 Then
			'��ʓ��e������
			Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)
			
			'��ʖ��׏��ݒ�
			Call Init_Def_Body_Inf()
			
			'��ʖ��ו�������
			Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)
			
			'���׃��P�[�V����
			Call Set_Body_Location()
			
			'�����\���ҏW
			Call Edi_Dsp_Def()
			
			'��ʕ\���ʒu�ݒ�
			Call CF_Set_Frm_Location(Me)
			
			'���͒S���ҕҏW
			Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
			
			'�{�f�B���ҏW_�T�u�Ɖ��ʗp
			Call SSSMAIN0003.F_DSP_BD_Inf_SUB(0, Main_Inf)
			
			'��ʖ��ו\��
			Call CF_Body_Dsp(Main_Inf)
			
			'���׃J���[�t��
			Call SSSMAIN0003.CF_Set_BD_Color(Main_Inf)
			
			'�V�X�e�����ʏ���
			Call CF_System_Process(Me)
			
			'��ʕҏW�t���O������
			gv_bolHIKET54_INIT = False
			
			'����̫����ʒu�ݒ�
			Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_HARDCOPY_Click
	'   �T�v�F  ��ʈ��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_HARDCOPY_Click() As Short
		
		Dim wk_Cursor As Short
		
		'Operable=TRUE�̎��̂�ok
		If PP_SSSMAIN.Operable = False Then
			Exit Function
		End If
		'�n�[�h�R�s�[�C�x���g���s
		If SSSMAIN_Hardcopy_Getevent() Then
			wk_Cursor = SSSMAIN0003.AE_Hardcopy_SSSMAIN()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_EndCm_Click
	'   �T�v�F  �I��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_EndCm_Click() As Short
		'�r���������������������������������������������������������r
		Me.Close()
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_ClearItm_Click
	'   �T�v�F  ���ڏ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_ClearItm_Click() As Short
		Dim Act_Index As Short
		Dim Trg_Index As Short
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�I�����ڂ̏�����
		'��ʓ��e������
		Call SSSMAIN0003.F_Init_Clr_Dsp(Act_Index, Main_Inf)
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
		'����̫����擾����
		Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_UnDoItem_Click
	'   �T�v�F  ���ڕ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_UnDoItem_Click() As Short
		
		Dim Act_Index As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�Y�����ڂ̕�������
		Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
		
		'�I����Ԃ̐ݒ�i�����I���j
		Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
		
		'���ڐF�ݒ�
		Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Cut_Click
	'   �T�v�F  �؂���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Cut_Click() As Short
		
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�Y�����ڂ̐؂���
		Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'���ڏ�����
		Call Ctl_MN_ClearItm_Click()
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Copy_Click
	'   �T�v�F  �R�s�[
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Copy_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�Y�����ڂ̃R�s�[
		Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Paste_Click
	'   �T�v�F  �\��t��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Paste_Click() As Short
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�Y�����ڂ̓\��t��
		Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_SELECTCM_Click
	'   �T�v�F  �I��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_SELECTCM_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_PREV_Click
	'   �T�v�F  �O��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_PREV_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_NEXTCM_Click
	'   �T�v�F  ����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_NEXTCM_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Slist_Click
	'   �T�v�F  ���̈ꗗ
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Slist_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_SM_AllCopy_Click
	'   �T�v�F  ���ړ��e�ɃR�s�[
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_AllCopy_Click() As Short
		
		'���ړ��e�ɃR�s�[
		Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_SM_Esc_Click
	'   �T�v�F  ������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_Esc_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_SM_FullPast_Click
	'   �T�v�F  ���ڂɓ\��t��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_SM_FullPast_Click() As Short
		
		Dim Act_Index As Short
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�Y�����ڂ̓\��t��
		'���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
		Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_VS_Scrl_Change
	'   �T�v�F  �c�X�N���[����CHANGE����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_VS_Scrl_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		Dim Rtn_LF As Boolean
		Dim Err_Row As Short
		
		If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
			Main_Inf.Dsp_Base.VS_Scr_Flg = False
			Exit Function
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'��è�޺��۰ي������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		If Act_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx And Act_Index < Main_Inf.Dsp_Base.Foot_Fst_Idx Then
			Rtn_LF = Ctl_Item_LostFocus(Me.ActiveControl)
		Else
			Rtn_LF = True
		End If
		
		If Rtn_LF = True Then
			'����VS_SCRL_CHANGE����
			Call SSSMAIN0003.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		Else
			'�c�X�N���[���o�[��ݒ�
			Call CF_Set_Item_Direct(Main_Inf.Dsp_Body_Inf.Cur_Top_Index, Main_Inf.Dsp_Sub_Inf(CShort(Main_Inf.Bd_Vs_Scrl.Tag)), Main_Inf)
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	Private Sub FR_SSSSUB01_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		Dim strMsg As String
		
		'�I�����b�Z�[�W�̏o��
		If gv_bolHIKET54_INIT = False Then
			'�I�����܂����H
			If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_001, Main_Inf) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		Else
			'���o�^�̂܂܏I�����܂����H
			If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_013, Main_Inf) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		End If
		
		'�r������
		Call CF_Unlock_EXCTBZ(strMsg)
		
		' add 20170616 start
		'�r������
		Call CF_Unlock_EXCTBZ2(strMsg)
		' add 20170616 end
		
		Main_Inf.Dsp_Base.IsUnload = True
		'���ʏI�������H
		'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSSUB01 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		Me = Nothing
		
		FR_SSSMAIN.Show()
		
		eventArgs.Cancel = Cancel
	End Sub
	
	' add 20170616 start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Unlock_EXCTBZ2
	'   �T�v�F�@�r�������������
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ����  9 : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ2(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ2 = 9
		pot_strMsg = ""
		bolTrn = False
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		intRet = AE_Execute_PLSQL_EXCTBZ_2("D", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			pot_strMsg = strMsg
			CF_Unlock_EXCTBZ2 = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ2 = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	' add 20170616 end
	
	Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
		'��x����̂��ߎg�p�s��
		Main_Inf.TM_StartUp_Ctl.Enabled = False
		'��ʈ���N������TRUE�Ƃ���
		PP_SSSMAIN.Operable = True
		'����̫����ʒu�ݒ�
		Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
	End Sub
	
	Private Sub FR_SSSSUB01_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'��ʏ��ݒ�
		Call Init_Def_Dsp()
		
		'��ʓ��e������
		Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'��ʖ��׏��ݒ�
		Call Init_Def_Body_Inf()
		
		'��ʖ��ו�������
		Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'���׃��P�[�V����
		Call Set_Body_Location()
		
		'�����\���ҏW
		Call Edi_Dsp_Def()
		
		'��ʕ\���ʒu�ݒ�
		Call CF_Set_Frm_Location(Me)
		
		'���͒S���ҕҏW
		Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
		
		'�{�f�B���ҏW_�T�u�Ɖ��ʗp
		Call SSSMAIN0003.F_DSP_BD_Inf_SUB(0, Main_Inf)
		
		'��ʖ��ו\��
		Call CF_Body_Dsp(Main_Inf)
		
		'���׃J���[�t��
		Call SSSMAIN0003.CF_Set_BD_Color(Main_Inf)
		
		'�V�X�e�����ʏ���
		Call CF_System_Process(Me)
		
		'��ʕҏW�t���O������
		gv_bolHIKET54_INIT = False
		
	End Sub
	
	'���������������� �S��ʃ��[�J�����ʏ��� End ��������������������������������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Edi_Dsp_Def
	'   �T�v�F  �������̉�ʕҏW
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Edi_Dsp_Def() As Short
		Dim Index_Wk As Short
		Dim strTANCD As String
		Dim strSYSDT As String
		
		'�r���������������������������������������������������������r
		'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Index_Wk = CShort(SYSDT.Tag)
		'��ʓ��t
		'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
		Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Init_Def_Body_Inf
	'   �T�v�F  ��ʃ{�f�B���ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Init_Def_Body_Inf() As Short
		
		Dim Bd_Col_Index As Short
		Dim Index_Wk As Short
		
		'������ʃ{�f�B���ݒ�
		Call CF_Init_Set_Body_Inf(Main_Inf)
		
		If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'���׍s�����݂���ꍇ
			
			'��ʃ{�f�B�̗񕪂̔z���`
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'�������
			Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT
			
			'�������p�ݒ�
			'��ʃ{�f�B�̗񕪂̔z���`
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'�������
			Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'�������ݒ�
			'�񕪂̕����s�̔z���`
			ReDim Preserve Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
			'�������
			Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'��ʃ{�f�B���̔z��O�Ԗڂɗ�����`����
			For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
				'��ʃ{�f�B���
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
				
				'�������p���
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
				
				'�������
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
			Next 
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Set_Body_Location
	'   �T�v�F  ���ׂ̔z�u
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Set_Body_Location() As Short
		
		Const Hosei_Value As Short = -20
		
		Dim BD_SOUNM_Top As Short
		Dim BD_SOUNM_Height As Short
		
		Dim Bd_Index As Short
		
		'�r���������������������������������������������������������r
		'�P�s�ڂ�No��Top��Height����Ƃ���
		BD_SOUNM_Top = VB6.PixelsToTwipsY(BD_SOUNM(1).Top)
		BD_SOUNM_Height = VB6.PixelsToTwipsY(BD_SOUNM(1).Height) + Hosei_Value
		
		'�\���ŏI�s�܂ŏ���
		For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			If Bd_Index >= 2 Then
				'�Q�s�ڈȍ~����
				'�z�u
				BD_SOUNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_LOTNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_NYUYTDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_RELZAISU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_ZUMISU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_HIKSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_MNSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
				BD_INP_HIKSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1))
			End If
			
			'�\��
			BD_SOUNM(Bd_Index).Visible = True
			BD_LOTNO(Bd_Index).Visible = True
			BD_NYUYTDT(Bd_Index).Visible = True
			BD_RELZAISU(Bd_Index).Visible = True
			BD_ZUMISU(Bd_Index).Visible = True
			BD_HIKSU(Bd_Index).Visible = True
			BD_MNSU(Bd_Index).Visible = True
			BD_INP_HIKSU(Bd_Index).Visible = True
			
		Next 
		
		'�X�N���[���o�[�̐ݒ�
		Main_Inf.Bd_Vs_Scrl.Top = VB6.TwipsToPixelsY(BD_SOUNM_Top)
		Main_Inf.Bd_Vs_Scrl.Height = VB6.TwipsToPixelsY(BD_SOUNM_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Debug.Print("CM_EndCm_Click")
		Call Ctl_Item_Click(CM_EndCm)
	End Sub
	
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		Debug.Print("CM_Execute_Click")
		Call Ctl_Item_Click(CM_Execute)
	End Sub
	
	Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
		Debug.Print("Image1_Click")
		Call Ctl_Item_Click(Image1)
	End Sub
	
	Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
		Debug.Print("MN_ClearItm_Click")
		Call Ctl_Item_Click(MN_ClearItm)
	End Sub
	
	Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
		Debug.Print("MN_Copy_Click")
		Call Ctl_Item_Click(MN_Copy)
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
		Debug.Print("MN_Ctrl_Click")
		Call Ctl_Item_Click(MN_Ctrl)
	End Sub
	
	Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
		Debug.Print("MN_Cut_Click")
		Call Ctl_Item_Click(MN_Cut)
	End Sub
	
	Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
		Debug.Print("MN_EditMn_Click")
		Call Ctl_Item_Click(MN_EditMn)
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Debug.Print("MN_EndCm_Click")
		Call Ctl_Item_Click(MN_EndCm)
	End Sub
	
	Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
		Debug.Print("MN_Execute_Click")
		Call Ctl_Item_Click(MN_Execute)
	End Sub
	
	Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
		Debug.Print("MN_HARDCOPY_Click")
		Call Ctl_Item_Click(MN_HARDCOPY)
	End Sub
	
	Public Sub MN_NEXTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NEXTCM.Click
		Debug.Print("MN_NEXTCM_Click")
		Call Ctl_Item_Click(MN_NEXTCM)
	End Sub
	
	Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
		Debug.Print("MN_Oprt_Click")
		Call Ctl_Item_Click(MN_Oprt)
	End Sub
	
	Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
		Debug.Print("MN_Paste_Click")
		Call Ctl_Item_Click(MN_Paste)
	End Sub
	
	Public Sub MN_PREV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_PREV.Click
		Debug.Print("MN_PREV_Click")
		Call Ctl_Item_Click(MN_PREV)
	End Sub
	
	Public Sub MN_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SELECTCM.Click
		Debug.Print("MN_SELECTCM_Click")
		Call Ctl_Item_Click(MN_SELECTCM)
	End Sub
	
	Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
		Debug.Print("MN_Slist_Click")
		Call Ctl_Item_Click(MN_Slist)
	End Sub
	
	Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
		Debug.Print("MN_UnDoItem_Click")
		Call Ctl_Item_Click(MN_UnDoItem)
	End Sub
	
	Private Sub BD_HIKSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HIKSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_HIKSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_MNSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MNSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_MNSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_INP_HIKSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_INP_HIKSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_INP_HIKSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_LOTNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LOTNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_MouseDown")
		Call Ctl_Item_MouseDown(BD_LOTNO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_NYUYTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUYTDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_MouseDown")
		Call Ctl_Item_MouseDown(BD_NYUYTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_RELZAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_RELZAISU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_MouseDown")
		Call Ctl_Item_MouseDown(BD_RELZAISU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_MouseDown")
		Call Ctl_Item_MouseDown(BD_SOUNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_ZUMISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ZUMISU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_MouseDown")
		Call Ctl_Item_MouseDown(BD_ZUMISU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseDown")
		Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseDown")
		Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DEN_SBT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DEN_SBT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DEN_SBT_MouseDown")
		Call Ctl_Item_MouseDown(HD_DEN_SBT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMA_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMB_MouseDown")
		Call Ctl_Item_MouseDown(HD_HINNMB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANCD_MouseDown")
		Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANNM_MouseDown")
		Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseDown")
		Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	
	Private Sub HD_UODSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UODSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_UODSU_MouseDown")
		Call Ctl_Item_MouseDown(HD_UODSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_MNSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MNSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_MNSU_MouseDown")
		Call Ctl_Item_MouseDown(HD_MNSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_ZUMISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ZUMISU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_ZUMISU_MouseDown")
		Call Ctl_Item_MouseDown(HD_ZUMISU, Button, Shift, X, Y)
	End Sub
	
	Private Sub Image1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseDown")
		Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseDown")
		Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseMove")
		Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseMove")
		Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseMove")
		Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_HIKSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HIKSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_HIKSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_MNSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MNSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_MNSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_INP_HIKSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_INP_HIKSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_INP_HIKSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_LOTNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LOTNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_MouseUp")
		Call Ctl_Item_MouseUp(BD_LOTNO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_NYUYTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUYTDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_MouseUp")
		Call Ctl_Item_MouseUp(BD_NYUYTDT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_RELZAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_RELZAISU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_MouseUp")
		Call Ctl_Item_MouseUp(BD_RELZAISU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SOUNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_MouseUp")
		Call Ctl_Item_MouseUp(BD_SOUNM(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_ZUMISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ZUMISU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_MouseUp")
		Call Ctl_Item_MouseUp(BD_ZUMISU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseUp")
		Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_Execute_MouseUp")
		Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
	End Sub
	
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DEN_SBT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DEN_SBT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DEN_SBT_MouseUp")
		Call Ctl_Item_MouseUp(HD_DEN_SBT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMA_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HINNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HINNMB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HINNMB_MouseUp")
		Call Ctl_Item_MouseUp(HD_HINNMB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANCD_MouseUp")
		Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_IN_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_IN_TANNM_MouseUp")
		Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_UODSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_UODSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_UODSU_MouseUp")
		Call Ctl_Item_MouseUp(HD_UODSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_MNSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MNSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_MNSU_MouseUp")
		Call Ctl_Item_MouseUp(HD_MNSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_ZUMISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_ZUMISU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_ZUMISU_MouseUp")
		Call Ctl_Item_MouseUp(HD_ZUMISU, Button, Shift, X, Y)
	End Sub
	
	Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseUp")
		Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("SYSDT_MouseUp")
		'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("TX_Message_MouseUp")
		Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_HIKSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HIKSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_HIKSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_MNSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MNSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_MNSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_INP_HIKSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_INP_HIKSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_INP_HIKSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_LOTNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LOTNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_KeyDown")
		Call Ctl_Item_KeyDown(BD_LOTNO(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_NYUYTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUYTDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_KeyDown")
		Call Ctl_Item_KeyDown(BD_NYUYTDT(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_RELZAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_RELZAISU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_KeyDown")
		Call Ctl_Item_KeyDown(BD_RELZAISU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyDown")
		Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_ZUMISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ZUMISU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_KeyDown")
		Call Ctl_Item_KeyDown(BD_ZUMISU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub HD_DEN_SBT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DEN_SBT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DEN_SBT_KeyDown")
		Call Ctl_Item_KeyDown(HD_DEN_SBT, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINCD, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMA.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMA_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINNMA, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HINNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMB_KeyDown")
		Call Ctl_Item_KeyDown(HD_HINNMB, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_IN_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANCD_KeyDown")
		Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_IN_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_IN_TANNM_KeyDown")
		Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_SBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_UODSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_UODSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_UODSU_KeyDown")
		Call Ctl_Item_KeyDown(HD_UODSU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_MNSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MNSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_MNSU_KeyDown")
		Call Ctl_Item_KeyDown(HD_MNSU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_ZUMISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ZUMISU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_ZUMISU_KeyDown")
		Call Ctl_Item_KeyDown(HD_ZUMISU, KEYCODE, Shift)
	End Sub
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_Message_KeyDown")
		Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
	End Sub
	
	Private Sub BD_HIKSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HIKSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_HIKSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_MNSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_MNSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_MNSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_INP_HIKSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_INP_HIKSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_INP_HIKSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_LOTNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LOTNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_KeyPress")
		Call Ctl_Item_KeyPress(BD_LOTNO(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_NYUYTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_NYUYTDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_KeyPress")
		Call Ctl_Item_KeyPress(BD_NYUYTDT(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_RELZAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_RELZAISU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_KeyPress")
		Call Ctl_Item_KeyPress(BD_RELZAISU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SOUNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SOUNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyPress")
		Call Ctl_Item_KeyPress(BD_SOUNM(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_ZUMISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_ZUMISU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_KeyPress")
		Call Ctl_Item_KeyPress(BD_ZUMISU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_DEN_SBT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DEN_SBT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_DEN_SBT_KeyPress")
		Call Ctl_Item_KeyPress(HD_DEN_SBT, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINNMA_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINNMA, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HINNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HINNMB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HINNMB_KeyPress")
		Call Ctl_Item_KeyPress(HD_HINNMB, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_IN_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_IN_TANCD_KeyPress")
		Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_IN_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_IN_TANNM_KeyPress")
		Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SBNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SBNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_SBNNO_KeyPress")
		Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_UODSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_UODSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_UODSU_KeyPress")
		Call Ctl_Item_KeyPress(HD_UODSU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_MNSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_MNSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_MNSU_KeyPress")
		Call Ctl_Item_KeyPress(HD_MNSU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_ZUMISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_ZUMISU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_ZUMISU_KeyPress")
		Call Ctl_Item_KeyPress(HD_ZUMISU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Message.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("TX_Message_KeyPress")
		Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_HIKSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.Enter
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_MNSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MNSU.Enter
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_MNSU(Index))
	End Sub
	
	Private Sub BD_INP_HIKSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_INP_HIKSU.Enter
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_INP_HIKSU(Index))
	End Sub
	
	Private Sub BD_LOTNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LOTNO.Enter
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_GotFocus")
		Call Ctl_Item_GotFocus(BD_LOTNO(Index))
	End Sub
	
	Private Sub BD_NYUYTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUYTDT.Enter
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_GotFocus")
		Call Ctl_Item_GotFocus(BD_NYUYTDT(Index))
	End Sub
	
	Private Sub BD_RELZAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.Enter
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_GotFocus")
		Call Ctl_Item_GotFocus(BD_RELZAISU(Index))
	End Sub
	
	Private Sub BD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Enter
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_GotFocus")
		Call Ctl_Item_GotFocus(BD_SOUNM(Index))
	End Sub
	
	Private Sub BD_ZUMISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZUMISU.Enter
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_GotFocus")
		Call Ctl_Item_GotFocus(BD_ZUMISU(Index))
	End Sub
	
	Private Sub HD_DEN_SBT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEN_SBT.Enter
		Debug.Print("HD_DEN_SBT_GotFocus")
		Call Ctl_Item_GotFocus(HD_DEN_SBT)
	End Sub
	
	Private Sub HD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Enter
		Debug.Print("HD_HINCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Enter
		Debug.Print("HD_HINNMA_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Enter
		Debug.Print("HD_HINNMB_GotFocus")
		Call Ctl_Item_GotFocus(HD_HINNMB)
	End Sub
	
	Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
		Debug.Print("HD_IN_TANCD_GotFocus")
		Call Ctl_Item_GotFocus(HD_IN_TANCD)
	End Sub
	
	Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
		Debug.Print("HD_IN_TANNM_GotFocus")
		Call Ctl_Item_GotFocus(HD_IN_TANNM)
	End Sub
	
	Private Sub HD_SBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Enter
		Debug.Print("HD_SBNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_UODSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UODSU.Enter
		Debug.Print("HD_UODSU_GotFocus")
		Call Ctl_Item_GotFocus(HD_UODSU)
	End Sub
	
	Private Sub HD_MNSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MNSU.Enter
		Debug.Print("HD_MNSU_GotFocus")
		Call Ctl_Item_GotFocus(HD_MNSU)
	End Sub
	
	Private Sub HD_ZUMISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ZUMISU.Enter
		Debug.Print("HD_ZUMISU_GotFocus")
		Call Ctl_Item_GotFocus(HD_ZUMISU)
	End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		Debug.Print("TX_Message_GotFocus")
		Call Ctl_Item_GotFocus(TX_Message)
	End Sub
	
	Private Sub BD_HIKSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.Leave
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_MNSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MNSU.Leave
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_MNSU(Index))
	End Sub
	
	Private Sub BD_INP_HIKSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_INP_HIKSU.Leave
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_INP_HIKSU(Index))
	End Sub
	
	Private Sub BD_LOTNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LOTNO.Leave
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_LostFocus")
		Call Ctl_Item_LostFocus(BD_LOTNO(Index))
	End Sub
	
	Private Sub BD_NYUYTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUYTDT.Leave
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_LostFocus")
		Call Ctl_Item_LostFocus(BD_NYUYTDT(Index))
	End Sub
	
	Private Sub BD_RELZAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.Leave
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_LostFocus")
		Call Ctl_Item_LostFocus(BD_RELZAISU(Index))
	End Sub
	
	Private Sub BD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Leave
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_LostFocus")
		Call Ctl_Item_LostFocus(BD_SOUNM(Index))
	End Sub
	
	Private Sub BD_ZUMISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZUMISU.Leave
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_LostFocus")
		Call Ctl_Item_LostFocus(BD_ZUMISU(Index))
	End Sub
	
	Private Sub HD_DEN_SBT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEN_SBT.Leave
		Debug.Print("HD_DEN_SBT_LostFocus")
		Call Ctl_Item_LostFocus(HD_DEN_SBT)
	End Sub
	
	Private Sub HD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.Leave
		Debug.Print("HD_HINCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.Leave
		Debug.Print("HD_HINNMA_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.Leave
		Debug.Print("HD_HINNMB_LostFocus")
		Call Ctl_Item_LostFocus(HD_HINNMB)
	End Sub
	
	Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
		Debug.Print("HD_IN_TANCD_LostFocus")
		Call Ctl_Item_LostFocus(HD_IN_TANCD)
	End Sub
	
	Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
		Debug.Print("HD_IN_TANNM_LostFocus")
		Call Ctl_Item_LostFocus(HD_IN_TANNM)
	End Sub
	
	Private Sub HD_SBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Leave
		Debug.Print("HD_SBNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_UODSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UODSU.Leave
		Debug.Print("HD_UODSU_LostFocus")
		Call Ctl_Item_LostFocus(HD_UODSU)
	End Sub
	
	Private Sub HD_MNSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MNSU.Leave
		Debug.Print("HD_MNSU_LostFocus")
		Call Ctl_Item_LostFocus(HD_MNSU)
	End Sub
	
	Private Sub HD_ZUMISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ZUMISU.Leave
		Debug.Print("HD_ZUMISU_LostFocus")
		Call Ctl_Item_LostFocus(HD_ZUMISU)
	End Sub
	
	Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
		Debug.Print("TX_Message_LostFocus")
		Call Ctl_Item_LostFocus(TX_Message)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_HIKSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_HIKSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.TextChanged
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_Change")
		Call Ctl_Item_Change(BD_HIKSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_MNSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_MNSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MNSU.TextChanged
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_Change")
		Call Ctl_Item_Change(BD_MNSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_INP_HIKSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_INP_HIKSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_INP_HIKSU.TextChanged
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_Change")
		Call Ctl_Item_Change(BD_INP_HIKSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_LOTNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_LOTNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LOTNO.TextChanged
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_Change")
		Call Ctl_Item_Change(BD_LOTNO(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_NYUYTDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_NYUYTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUYTDT.TextChanged
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_Change")
		Call Ctl_Item_Change(BD_NYUYTDT(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_RELZAISU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_RELZAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_RELZAISU.TextChanged
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_Change")
		Call Ctl_Item_Change(BD_RELZAISU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_SOUNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.TextChanged
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_Change")
		Call Ctl_Item_Change(BD_SOUNM(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_ZUMISU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_ZUMISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ZUMISU.TextChanged
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_Change")
		Call Ctl_Item_Change(BD_ZUMISU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_DEN_SBT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_DEN_SBT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEN_SBT.TextChanged
		Debug.Print("HD_DEN_SBT_Change")
		Call Ctl_Item_Change(HD_DEN_SBT)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_HINCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINCD.TextChanged
		Debug.Print("HD_HINCD_Change")
		Call Ctl_Item_Change(HD_HINCD)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_HINNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_HINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMA.TextChanged
		Debug.Print("HD_HINNMA_Change")
		Call Ctl_Item_Change(HD_HINNMA)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_HINNMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_HINNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HINNMB.TextChanged
		Debug.Print("HD_HINNMB_Change")
		Call Ctl_Item_Change(HD_HINNMB)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_IN_TANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_IN_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.TextChanged
		Debug.Print("HD_IN_TANCD_Change")
		Call Ctl_Item_Change(HD_IN_TANCD)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_IN_TANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_IN_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.TextChanged
		Debug.Print("HD_IN_TANNM_Change")
		Call Ctl_Item_Change(HD_IN_TANNM)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_SBNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_SBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.TextChanged
		Debug.Print("HD_SBNNO_Change")
		Call Ctl_Item_Change(HD_SBNNO)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_UODSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_UODSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_UODSU.TextChanged
		Debug.Print("HD_UODSU_Change")
		Call Ctl_Item_Change(HD_UODSU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_MNSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_MNSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MNSU.TextChanged
		Debug.Print("HD_MNSU_Change")
		Call Ctl_Item_Change(HD_MNSU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_ZUMISU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_ZUMISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_ZUMISU.TextChanged
		Debug.Print("HD_ZUMISU_Change")
		Call Ctl_Item_Change(HD_ZUMISU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g TX_Message.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
		Debug.Print("TX_Message_Change")
		Call Ctl_Item_Change(TX_Message)
	End Sub
	
	'UPGRADE_NOTE: VS_Scrl.Change �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
	'UPGRADE_WARNING: VScrollBar �C�x���g VS_Scrl.Change �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
	Private Sub VS_Scrl_Change(ByVal newScrollValue As Integer)
		Debug.Print("VS_Scrl_Change")
		Call Ctl_VS_Scrl_Change(VS_Scrl)
	End Sub
	
	Private Sub BD_HIKSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HIKSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_MNSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MNSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_MNSU.GetIndex(eventSender)
		Debug.Print("BD_MNSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_MNSU(Index))
	End Sub
	
	Private Sub BD_INP_HIKSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_INP_HIKSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_INP_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_INP_HIKSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_INP_HIKSU(Index))
	End Sub
	
	Private Sub BD_LOTNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LOTNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_LOTNO.GetIndex(eventSender)
		Debug.Print("BD_LOTNO_KeyUp")
		Call Ctl_Item_KeyUp(BD_LOTNO(Index))
	End Sub
	
	Private Sub BD_NYUYTDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUYTDT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_NYUYTDT.GetIndex(eventSender)
		Debug.Print("BD_NYUYTDT_KeyUp")
		Call Ctl_Item_KeyUp(BD_NYUYTDT(Index))
	End Sub
	
	Private Sub BD_RELZAISU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_RELZAISU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_RELZAISU.GetIndex(eventSender)
		Debug.Print("BD_RELZAISU_KeyUp")
		Call Ctl_Item_KeyUp(BD_RELZAISU(Index))
	End Sub
	
	Private Sub BD_SOUNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyUp")
		Call Ctl_Item_KeyUp(BD_SOUNM(Index))
	End Sub
	
	Private Sub BD_ZUMISU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ZUMISU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ZUMISU.GetIndex(eventSender)
		Debug.Print("BD_ZUMISU_KeyUp")
		Call Ctl_Item_KeyUp(BD_ZUMISU(Index))
	End Sub
	
	Private Sub HD_DEN_SBT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DEN_SBT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DEN_SBT_KeyUp")
		Call Ctl_Item_KeyUp(HD_DEN_SBT)
	End Sub
	
	Private Sub HD_HINCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINCD.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINCD_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINCD)
	End Sub
	
	Private Sub HD_HINNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMA.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMA_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINNMA)
	End Sub
	
	Private Sub HD_HINNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HINNMB.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HINNMB_KeyUp")
		Call Ctl_Item_KeyUp(HD_HINNMB)
	End Sub
	
	Private Sub HD_SBNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyUp")
		Call Ctl_Item_KeyUp(HD_SBNNO)
	End Sub
	
	Private Sub HD_UODSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_UODSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_UODSU_KeyUp")
		Call Ctl_Item_KeyUp(HD_UODSU)
	End Sub
	
	Private Sub HD_MNSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MNSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_MNSU_KeyUp")
		Call Ctl_Item_KeyUp(HD_MNSU)
	End Sub
	
	Private Sub HD_ZUMISU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_ZUMISU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_ZUMISU_KeyUp")
		Call Ctl_Item_KeyUp(HD_ZUMISU)
	End Sub
	
	Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
		Debug.Print("SM_AllCopy_Click")
		Call Ctl_Item_Click(SM_AllCopy)
	End Sub
	
	Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
		Debug.Print("SM_FullPast_Click")
		Call Ctl_Item_Click(SM_FullPast)
	End Sub
	
	Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
		Debug.Print("SM_Esc_Click")
		Call Ctl_Item_Click(SM_Esc)
	End Sub
	
	Private Sub TX_CursorRest_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_CursorRest.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_CursorRest_KeyDown")
		If KEYCODE >= System.Windows.Forms.Keys.F1 And KEYCODE <= System.Windows.Forms.Keys.F12 Then
			Call Ctl_Item_KeyDown(TX_CursorRest, KEYCODE, Shift)
		End If
	End Sub
	Private Sub VS_Scrl_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VS_Scrl.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VS_Scrl_Change(eventArgs.newValue)
		End Select
	End Sub
End Class