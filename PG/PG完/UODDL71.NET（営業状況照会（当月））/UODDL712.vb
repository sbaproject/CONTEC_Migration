Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN2
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
	' 2007/01/16  CHG START  KUMEDA
	'Private Const FM_PANEL3D1_CNT       As Integer = 11 '�p�l���R���g���[����
	Private Const FM_PANEL3D1_CNT As Short = 12 '�p�l���R���g���[����
	' 2007/01/16  CHG END
    '*** End Of Generated Declaration Section ****

    '2019/03/28 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/03/28 ADD E N D

    '=== ����ʂ̑S�����i�[ =================
    'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Main_Inf As Cls_All
	'=== ����ʂ̑S�����i�[ =================
	
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
		
		'���׃y�[�W���ݒ�
		MinPageNum = 1
		MaxPageNum = 1
		NowPageNum = 0
		
		'��ʊ�b���ݒ�
		With Main_Inf.Dsp_Base
            .Dsp_Ctg = DSP_CTG_REFERENCE '��ʕ���
            'change 20190403 START saiki
            '.Item_Cnt = 159 '��ʍ��ڐ�
            .Item_Cnt = 147 '��ʍ��ڐ�
            'change 20190403 END saiki
            .Dsp_Body_Cnt = 17 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
			.Max_Body_Cnt = 0 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
			.Body_Col_Cnt = 6 '���ׂ̗񍀖ڐ�
			.Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1 '��ʈړ���
			.FormCtl = Me
		End With
		
		'��ʍ��ڏ��
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'/////////////////////
		'// �S��ʗp����p���۰�
		'/////////////////////
		'�����ݒ�p�^�C�}�[
		Main_Inf.TM_StartUp_Ctl = TM_StartUp
		Main_Inf.TM_StartUp_Ctl.Interval = 1
		Main_Inf.TM_StartUp_Ctl.Enabled = True
		
		Index_Wk = 0
        '�J�[�\������p�e�L�X�g
        'change 20190403 START saiki
        'TX_CursorRest.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
        dummyCtl.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_Ctrl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
        btnF5.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF5
        'change 20190403 END saiki
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
        '���s
        'change 20190403 START saiki
        'MN_Execute.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_HARDCOPY.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
        btnF11.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF11
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_EndCm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
        'dummyCtl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        btnF12.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        'change 20190403 END saiki
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
        '�����Q(�ҏW)
        'change 20190403 START saiki
        'MN_EditMn.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
        btnF4.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF4
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_ClearItm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_UnDoItem.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki

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
        'change 20190403 START saiki
        'MN_Cut.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_Copy.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_Paste.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_Oprt.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_SELECTCM.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_SELECTCM
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki

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
        'change 20190403 START saiki
        'MN_PREV.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_PREV
        'dummyCtl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        btnF1.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        'change 20190403 END saiki
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
        'change 20190403 START saiki
        'MN_NEXTCM.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_NEXTCM
        'dummyCtl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        btnF2.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF2
        'change 20190403 END saiki
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
        '���̈ꗗ
        'change 20190403 START saiki
        'MN_Slist.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        ''���ڂɓ\��t��
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
        'change 20190403 START saiki
        'CM_EndCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
        dummyCtl.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'delete 20190403 START saiki
        '      '=== �Ұ�ސݒ� ======================
        '      Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
        'Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
        '      '=== �Ұ�ސݒ� ======================
        'delete 20190403 END saiki

        Index_Wk = Index_Wk + 1
        '���s�C���[�W
        'change 20190403 START saiki
        'CM_Execute.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
        dummyCtl.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'delete 20190403 START saiki
        '      '=== �Ұ�ސݒ� ======================
        '      Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
        'Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
        '      '=== �Ұ�ސݒ� ======================
        'delete 20190403 END saiki

        Index_Wk = Index_Wk + 1
        '�����C���[�W
        'change 20190403 START saiki
        'CM_SLIST.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
        dummyCtl.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'delete 20190403 START saiki
        '      '=== �Ұ�ސݒ� ======================
        '      Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
        'Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
        '      '=== �Ұ�ސݒ� ======================
        'delete 20190403 END saiki

        Index_Wk = Index_Wk + 1
        '���ו��N���A�C���[�W
        'change 20190403 START saiki
        'CM_SELECTCM.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SELECTCM
        dummyCtl.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        'change 20190403 END saiki
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
        'delete 20190403 START saiki
        '      '=== �Ұ�ސݒ� ======================
        '      Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SELECTCM(0)
        'Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SELECTCM(1)
        '      '=== �Ұ�ސݒ� ======================
        'delete 20190403 END saiki

        Index_Wk = Index_Wk + 1
		'�y�[�W�߂�
		CM_PREV.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PREV
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
		Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PREV(0)
		Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PREV(1)
		'=== �Ұ�ސݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'�y�[�W����
		CM_NEXTCM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NEXTCM
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
		Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NEXTCM(0)
		Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NEXTCM(1)
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
		'����{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_BMNCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_BMNCD
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
		
		Index_Wk = Index_Wk + 1
		'����(�R�[�h)
		HD_BMNCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BMNCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		' 2006/11/28  CHG START  KUMEDA
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		' 2006/11/28  CHG END
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'����(����)
		HD_BMNNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BMNNM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
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
		'�n��{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_TIKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TIKCD
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
		
		Index_Wk = Index_Wk + 1
		'�n��(�R�[�h)
		HD_TIKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TIKCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		' 2006/11/28  CHG START  KUMEDA
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		' 2006/11/28  CHG END
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'�n��(����)
		HD_TIKNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TIKNM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
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
		'�c�Ə��{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_EIGCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_EIGCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
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
		'�c�Ə�(����)
		HD_EIGCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_EIGCD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		' 2006/11/28  CHG START  KUMEDA
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		' 2006/11/28  CHG END
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'�c�Ə�(����)
		HD_EIGNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_EIGNM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
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
		Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
		
		'///////////////
		'// �{�f�B���ҏW
		'///////////////
		Index_Wk = Index_Wk + 1
		'����
		BD_MEISYO(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MEISYO(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
        '�󒍐�
        BD_UODSU_T(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU_T(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPD 20160127 START C2-20160107-01
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'UPD 20160127  END  C2-20160107-01
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�󒍋��z
		BD_UODKN_T(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN_T(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 15
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 11
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�d��
		BD_SIKKN_T(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKKN_T(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 15
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 11
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		BD_BAISA_T(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BAISA_T(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 15
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 11
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'������
		BD_BSART_T(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BSART_T(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 3
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_RT_1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			BD_MEISYO.Load(BD_Cnt) '����
			BD_UODSU_T.Load(BD_Cnt) '�󒍐�
			BD_UODKN_T.Load(BD_Cnt) '�󒍋��z
			BD_SIKKN_T.Load(BD_Cnt) '�d��
			BD_BAISA_T.Load(BD_Cnt) '����
			BD_BSART_T.Load(BD_Cnt) '������
			
			Index_Wk = Index_Wk + 1
			'����
			BD_MEISYO(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MEISYO(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�󒍐�
			BD_UODSU_T(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU_T(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�󒍋��z
			BD_UODKN_T(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN_T(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�d��
			BD_SIKKN_T(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKKN_T(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'����
			BD_BAISA_T(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BAISA_T(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'������
			BD_BSART_T(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BSART_T(BD_Cnt)
			'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
		Next 
		
		'///////////////
		'// �t�b�^���ҏW
		'///////////////
		
		Index_Wk = Index_Wk + 1
        '�󒍁^����{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190403 START saiki
        'CS_JUC_URI.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JUC_URI
        btnF6.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF6
        'change 20190403 END saiki
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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
		
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
        '�����^�����{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190403 START saiki
        'CS_GETU_KI.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_GETU_KI
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        'change 20190403 END saiki
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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
        '����ʑ����\�{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190403 START saiki
        'CS_BMNSOU.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_BMNSOU
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        'change 20190403 END saiki
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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
        '�@��ʑ����\�{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190403 START saiki
        'CS_SOUKATU.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_SOUKATU
        btnF10.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF10
        'change 20190403 END saiki
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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

        ' 2007/01/12  ADD START  KUMEDA
        Index_Wk = Index_Wk + 1
        '�ēǍ��{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'change 20190403 START saiki
        'CS_SAIYOMI.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_SAIYOMI
        btnF3.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF3
        'change 20190403 END saiki
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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
        ' 2007/01/12  ADD END

        Index_Wk = Index_Wk + 1
        '�_�~�[�e�L�X�g
        TX_Dummy.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Dummy
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

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
        'delete 20190403 START saiki
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1

        '    'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        '    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        'Next
        'delete 20190403 END saiki

        'E��������������������������������������������������������E

        '��L�ݒ���e�����ۂ̺��۰قɐݒ肷��
        Call CF_Init_Item_Property(Main_Inf)
        '��ʍ��ڏ����Đݒ�
        Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

        '///////////////////
        '// ���ʍ��ڂ̍Đݒ�
        '///////////////////
        '�J�[�\������p�e�L�X�g
        'delete 20190326 START saiki
        'TX_CursorRest.TabStop = False
        'delete 20190326 END saiki
        TX_Message.TabStop = False

        gv_bolUODDL71_LF_Enable = True

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyReturn
    '   �T�v�F  �e���ڂ�VBKEYRETURN����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyRight
    '   �T�v�F  �e���ڂ�VBKEYRIGHT����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
            Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYRIGHT����(̫����ړ��Ȃ�)
                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
                '������ړ�����
                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Else
                '������ړ��Ȃ�
                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            End If
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyDown
    '   �T�v�F  �e���ڂ�VBKEYDOWN����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            'KEYDOWN����
            Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyLeft
    '   �T�v�F  �e���ڂ�VBKEYLEFT����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
        Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
            Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYLEFT����(̫����ړ�����)
                Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
                '������ړ�����
                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Else
                '������ړ��Ȃ�
                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            End If
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyUp
    '   �T�v�F  �e���ڂ�VBKEYUP����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            'KEYUP����
            Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

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
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyDown
    '   �T�v�F  �e���ڂ�KEYDOWN����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '          pm_KeyCode   :�L�[�R�[�h
    '          pm_Shift     :shift�L�[�������
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_KeyDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef pm_KeyCode As Short, ByRef pm_Shift As Short) As Short

        Dim Trg_Index As Short
        Dim Move_Flg As Boolean

        ' === 20060801 === INSERT S �G���^�[�L�[�A�łɂ��s��C��
        'Enter���̂݃t���O��ON
        If pm_KeyCode = System.Windows.Forms.Keys.Return Then
            If gv_bolKeyFlg = True Then
                Exit Function
            End If

            gv_bolKeyFlg = True
        End If
        ' === 20060801 === INSERT E

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
                Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

                ' === 20060930 === INSERT S �t�@���N�V�����L�[�����Ή�
                '�t�@���N�V�����L�[������
            Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
                '�t�@���N�V�����L�[���ʏ���
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
                ' === 20060930 === INSERT E
        End Select

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_LostFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Trg_Index As Short
        Dim Act_Index As Short
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Dsp_Mode As Short

        If gv_bolUODDL71_LF_Enable = False Then
            Exit Function
        End If

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '����̫������۰َ擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '======================= �ύX���� 2006.07.02 Start =================================
        '۽�̫������s����
        If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
            Main_Inf.Dsp_Base.LostFocus_Flg = False
            Exit Function
        End If
        '======================= �ύX���� 2006.07.02 End =================================

        Move_Flg = False
        Chk_Move_Flg = True

        '�e���ڂ�����ٰ��
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            ' 2007/01/15  CHG START  KUMEDA
            '        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            ' 2007/01/15  CHG END

            '����̫������۰ق̑I�������Đݒ�
            '�I����Ԃ̐ݒ�
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), CStr(0))
            '���ڐF�ݒ�
            ' 2007/01/15  CHG START  KUMEDA
            '        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
            ' 2007/01/15  CHG END

        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_GotFocus
    '   �T�v�F  �e���ڂ�GOTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_GotFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Trg_Index As Short
        Dim Rtn_Chk As Short
        Dim Move_Flg As Boolean
        Dim Wk_Index As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '��ʒP�ʂ̏���(�����Ȃ�)
        '���ו��ł��ړ��O�����ו��łȂ��ꍇ
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
            '�r���������������������������������������������������������r
            'ͯ�ޕ�����
            Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)
            '�d���������������������������������������������������������d
            If Rtn_Chk <> CHK_OK Then
                Exit Function
            End If
        End If

        ' === 20060801 === INSERT S ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        'change 20190325 START saiki
        'If TypeOf pm_Ctl Is SSCommand5 Then
        If TypeOf pm_Ctl Is Button Then
            'change 20190325 END saiki
            '������ʌďo�̏ꍇ�͏I��
            Exit Function
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
            '���׍s�R���g���[��������
            If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
                '���׌����{�^���̖��׍s���ϐ��ɓ����s����ݒ�
                For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                        '�ݒ�ς݂̏ꍇ�͏I��
                        Exit For
                    End If
                    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
                Next
            End If
        Else
            '���׌����{�^���̖��׍s���ϐ���������
            For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                    '�ݒ�ς݂̏ꍇ�͏I��
                    Exit For
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
            Next
        End If
        ' === 20060801 === INSERT E

        '�r���������������������������������������������������������r
        '����̫����擾����
        Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        '�d���������������������������������������������������������d

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyPress
    '   �T�v�F  �e���ڂ�KEYPRESS����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           pm_KeyAscii     :�L�[��ASCII�R�[�h
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
        Call CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
            Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then

                '����̫����ʒu����E�ֈړ�
                Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
                '������ړ�����
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            End If

        Else
            With Main_Inf.Dsp_Sub_Inf(Trg_Index)
                'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Item_Nm �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change 20190325 START saiki
                'If ((.Detail.Item_Nm = "HD_BMNCD") And (.Ctl.SelStart = .Detail.MaxLengthB)) Or ((.Detail.Item_Nm = "HD_TIKCD") And (.Ctl.SelStart = .Detail.MaxLengthB)) Or ((.Detail.Item_Nm = "HD_EIGCD") And (.Ctl.SelStart = .Detail.MaxLengthB)) Then
                If ((.Detail.Item_Nm = "HD_BMNCD") And (DirectCast(.Ctl, TextBox).SelectionStart = .Detail.MaxLengthB)) Or ((.Detail.Item_Nm = "HD_TIKCD") And (DirectCast(.Ctl, TextBox).SelectionStart = .Detail.MaxLengthB)) Or ((.Detail.Item_Nm = "HD_EIGCD") And (DirectCast(.Ctl, TextBox).SelectionStart = .Detail.MaxLengthB)) Then
                    'change 20190325 END saiki
                    '�I����Ԃ̐ݒ�i�����I���j
                    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

                    '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

                Else
                    '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
                    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
                End If
            End With
        End If

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANGE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        '2019/03/28 ADD START
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '2019/03/28 ADD E N D

        Dim Trg_Index As Short

        If Main_Inf.Dsp_Base.Change_Flg = True Then
            Main_Inf.Dsp_Base.Change_Flg = False
            Exit Function
        End If

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '����KEYCHANG����
        Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        '��ʒP�ʂ̏���(�����Ȃ�)

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseUp
    '   �T�v�F  �e���ڂ�MOUSEUP����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
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
                '======================= �ύX���� 2006.07.02 Start =================================
                '            '���ڐF�ݒ�
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
                '======================= �ύX���� 2006.07.02 End =================================
                'change 20190325 START saiki
                'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                'change 20190325 END saiki
                '�p�l���̏ꍇ
                Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060801 === INSERT S ����W�{�^���Ή�
                'change 20190325 START saiki
                'Case TypeOf pm_Ctl Is SSCommand5
            Case TypeOf pm_Ctl Is Label
                'change 20190325 END saiki
                '�{�^���̏ꍇ
                ' 2006/11/28  ADD START  KUMEDA
                If Me.ActiveControl Is Nothing Then
                    Exit Function
                End If
                ' 2006/11/28  ADD END

                'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                'change 20190325 START saiki
                'If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    'change 20190325 END saiki
                    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060801 === INSERT E -

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                '�C���[�W�̏ꍇ
                Select Case Trg_Index
                    'delete 20190326 START saiki
                    'Case CShort(CM_EndCm.Tag)
                    '    '�I���Ұ��
                    '    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                    'Case CShort(CM_SLIST.Tag)
                    '    '�����Ұ��
                    '    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
                    'delete 20190326 END saiki
                    Case CShort(CM_PREV.Tag)
                        '�y�[�W�߲Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                    Case CShort(CM_NEXTCM.Tag)
                        '�y�[�W���Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)

                End Select
        End Select

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseMove
    '   �T�v�F  �e���ڂ�MOUSEMOVE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
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
                'delete 20190326 START saiki
                'Case CShort(CM_EndCm.Tag)
                '	'�I���Ұ��
                '	Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
                'Case CShort(CM_SLIST.Tag)
                '	'�����Ұ��
                '             Call CF_Set_Prompt(IMG_SLIST_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
                'delete 20190326 END saiki
            Case CShort(CM_PREV.Tag)
                '�y�[�W�߲Ұ��
                Call CF_Set_Prompt(IMG_PREV_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
            Case CShort(CM_NEXTCM.Tag)
                '�y�[�W���Ұ��
                Call CF_Set_Prompt(IMG_NEXTCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

        End Select

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseDown
    '   �T�v�F  �e���ڂ�MOUSEDOWN����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_MouseDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short

        Dim Trg_Index As Short
        Dim Act_Index As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '======================= �ύX���� 2006.07.02 Start =================================
        '��è�޺��۰ي������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)
        '======================= �ύX���� 2006.07.02 End =================================
        Select Case Trg_Index
            'delete 20190326 START saiki
            'Case CShort(CM_EndCm.Tag)
            '    '�I���Ұ��
            '    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

            'Case CShort(CM_SLIST.Tag)
            '    '������ʕ\���Ұ��
            '    Select Case Act_Index
            '        Case CShort(Me.HD_BMNCD.Tag), CShort(Me.HD_TIKCD.Tag), CShort(Me.HD_EIGCD.Tag)
            '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
            '    End Select
            'delete 20190326 END saiki
            Case CShort(CM_PREV.Tag)
                '�O�y�[�W�Ұ��
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)

            Case CShort(CM_NEXTCM.Tag)
                '���y�[�W�Ұ��
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)

        End Select

        '======================= �ύX���� 2006.07.02 Start =================================
        '����MOUSEDOWN����
        Call CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
        '======================= �ύX���� 2006.07.02 End =================================

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Click
    '   �T�v�F  �e���ڂ�CLICK����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_Click(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Trg_Index As Short
        Dim Wk_Index As Short
        Dim RetnCd As Short
        'ADD 20190405 START saiki
        Dim UODDL As Integer = 712
        'ADD 20190405 END saiki

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '�r���������������������������������������������������������r
        RetnCd = -1

        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case Trg_Index
            'change start 20190806 kuwahara
            'Case CShort(CM_SLIST.Tag), CShort(MN_Slist.Tag)
            '	'�e������ʌďo
            '	Call F_Ctl_CS(Main_Inf)
            Case CShort(btnF5.Tag)
                '�e������ʌďo
                Call F_Ctl_CS(Main_Inf, UODDL)
                'change end 20190806 kuwahara

             'change 20190403 START saiki
   '         Case CShort(CS_BMNCD.Tag)
            '	'���匟����ʌďo
            '	Call F_Ctl_CS_BMNCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CS_TIKCD.Tag)
            '	'�n�挟����ʌďo
            '	Call F_Ctl_CS_TIKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CS_EIGCD.Tag)
   '             '�c�Ə�������ʌďo
   '             Call F_Ctl_CS_EIGCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

   '         Case CShort(CS_JUC_URI.Tag)
            '	Call Ctl_MN_APPENDC_Click()
            '	'�󒍁^�����ʌďo
            '	Call F_Ctl_CS_JUC_URI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CS_GETU_KI.Tag)
            '	Call Ctl_MN_APPENDC_Click()
            '	'�����^������ʌďo
            '	Call F_Ctl_CS_GETU_KI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CS_BMNSOU.Tag)
            '	'����ʑ����\��ʌďo
            '	Call F_Ctl_CS_BMNSOU_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CS_SOUKATU.Tag)
            '	'�@��ʑ����\��ʌďo
            '	Call F_Ctl_CS_SOUKATU_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            '	' 2007/01/12  ADD START  KUMEDA
            'Case CShort(CS_SAIYOMI.Tag)
            '	Call Ctl_MN_APPENDC_Click()
            '	'�ēǍ�
            '	Call F_Ctl_CS_SAIYOMI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
   '             ' 2007/01/12  ADD END


            Case CShort(btnF1.Tag)
                Call Ctl_MN_APPENDC_Click()
                '�󒍁^�����ʌďo
                Call F_Ctl_CS_JUC_URI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF11.Tag)
                Call Ctl_MN_APPENDC_Click()
                '�����^������ʌďo
                Call F_Ctl_CS_GETU_KI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF6.Tag)
                '����ʑ����\��ʌďo
                Call F_Ctl_CS_BMNSOU_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF7.Tag)
                '�@��ʑ����\��ʌďo
                Call F_Ctl_CS_SOUKATU_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF2.Tag)
                Call Ctl_MN_APPENDC_Click()
                '�ēǍ�
                Call F_Ctl_CS_SAIYOMI_MEI(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                'change 20190403 END saiki

            'Case CShort(CM_PREV.Tag), CShort(MN_PREV.Tag)
            '    '�O�y�[�W��
            '    Call Ctl_CM_PREV_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            'Case CShort(CM_NEXTCM.Tag), CShort(MN_NEXTCM.Tag)
            '    '���̃y�[�W��
            '    Call Ctl_CM_NEXTCM_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                '�d���������������������������������������������������������d

                '20190424 ADD START
            Case CShort(btnF3.Tag)
                '�O�y�[�W��
                Call Ctl_CM_PREV_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF4.Tag)
                '���̃y�[�W��
                Call Ctl_CM_NEXTCM_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(btnF9.Tag)
                '�N���A
                Call Ctl_MN_APPENDC_Click()

            Case CShort(btnF12.Tag)
                '�I��
                Call Ctl_MN_EndCm_Click()
                Exit Function
                '20190424 ADD END

            Case CShort(MN_Ctrl.Tag)
                '�����P
                Call Ctl_MN_Ctrl_Click()

            Case CShort(MN_HARDCOPY.Tag)
                '��ʈ��
                Call Ctl_MN_HARDCOPY_Click()
                'delete 20190326 START saiki
                'Case CShort(CM_EndCm.Tag), CShort(MN_EndCm.Tag)
                '	'�I��
                '	Call Ctl_MN_EndCm_Click()
                '	Exit Function
                'delete 20190326 END saiki
            Case CShort(MN_EditMn.Tag)
                '�����Q
                Call Ctl_MN_EditMn_Click()

            Case CShort(MN_ClearItm.Tag)
                '���ڏ�����
                Call Ctl_MN_ClearItm_Click()


            Case CShort(CS_BMNCD.Tag)
                '���匟����ʌďo
                Call F_Ctl_CS_BMNCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, UODDL)

            Case CShort(CS_TIKCD.Tag)
                '�n�挟����ʌďo
                Call F_Ctl_CS_TIKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, UODDL)

            Case CShort(CS_EIGCD.Tag)
                '�c�Ə�������ʌďo

                Call F_Ctl_CS_EIGCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, UODDL)


                'delete 20190326 START saiki
                'Case CShort(MN_UnDoItem.Tag)
                '	'���ڕ���
                '	Call Ctl_MN_UnDoItem_Click()

                '         Case CShort(MN_Cut.Tag)
                '	'�؂���
                '	Call Ctl_MN_Cut_Click()

                'Case CShort(MN_Copy.Tag)
                '	'�R�s�[
                '	Call Ctl_MN_Copy_Click()

                'Case CShort(MN_Paste.Tag)
                '	'�\��t��
                '	Call Ctl_MN_Paste_Click()

                'Case CShort(MN_Oprt.Tag)
                '	'����R
                '	Call Ctl_MN_Oprt_Click()

                'Case CShort(SM_AllCopy.Tag)
                '	'���ړ��e�ɃR�s�[
                '	Call Ctl_SM_AllCopy_Click()


                '        Case CShort(SM_Esc.Tag)
                ''������
                'Call Ctl_SM_Esc_Click()

                'Case CShort(SM_FullPast.Tag)
                '	'���ڂɓ\��t��
                '	Call Ctl_SM_FullPast_Click()
                'delete 20190403 END saiki

        End Select

        '�X�e�[�^�X�o�[������
        Call CF_Clr_Prompt(Main_Inf)

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
        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Ant_Index = CShort(Me.ActiveControl.Tag)

        '    '����s�����
        '    MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '    '��폜�����
        '    MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '    '���ʈ�������
        '    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��I�������
        'delete 20190403 START saiki
        'MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        'delete 20190403 END saiki
        '�r���������������������������������������������������������r
        '���j���[�g�p��/�s����
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
        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Ant_Index = CShort(Me.ActiveControl.Tag)

        '    '���ʏ����������
        '    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����ڏ����������
        'delete 20190403 START saiki
        'MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        ''����ڕ��������
        '      MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        'delete 20190403 END saiki
        '    '����׍s�����������
        '    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '    '����׍s�폜�����
        '    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '    '����׍s�}�������
        '    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '    '����׍s���������
        '    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        'delete 20190403 START saiki
        '      '��؂��裔���
        '      MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        ''��R�s�[�����
        'MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        ''��\��t�������
        'MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        'delete 20190403 END saiki
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EditMn_Click
    '   �T�v�F  ���j���[����R�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Oprt_Click() As Short

        Dim Act_Index As Short
        'delete 20190403 END saiki
        '      ' 2006/11/28  ADD START  KUMEDA
        '      If Me.ActiveControl Is Nothing Then
        '	Exit Function
        'End If
        '      ' 2006/11/28  ADD END
        'delete 20190403 END saiki

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        'delete 20190403 START saiki
        ''�u�I���v������
        'MN_SELECTCM.Enabled = False

        ''����̈ꗗ�������
        'MN_Slist.Enabled = True
        'delete 20190403 END saiki

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  ���s(���o�f�[�^������)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Execute_Click() As Short
        '�r���������������������������������������������������������r
        Dim Wk_Index As Short

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        If Me.ActiveControl.Name = TX_Dummy.Name Then
            Exit Function
        End If

        '�i�w�b�_�����͌�A�m�肷�铮���Ɠ����j
        Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx '�w�b�_���̍Ō�̍���(����)�̃C���f�b�N�X����
        Call F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, True, Main_Inf)

        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_HARDCOPY_Click
    '   �T�v�F  ��ʈ��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_HARDCOPY_Click() As Short
        '�r���������������������������������������������������������r
        Dim wk_Cursor As Short

        'Operable=TRUE�̎��̂�ok
        If PP_SSSMAIN.Operable = False Then
            Exit Function
        End If
        '�n�[�h�R�s�[�C�x���g���s
        If SSSMAIN_Hardcopy_Getevent() Then
            wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN(Main_Inf)
        End If
        '�d���������������������������������������������������������d
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
        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '��ʓ��e������
        Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

        '����̫����擾����
        Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y�����ڂ̕�������
        Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        Move_Flg = False
        Chk_Move_Flg = True

        '�e���ڂ�����ٰ��
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)

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

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

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

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

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

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y�����ڂ̓\��t��
        Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  ���̈ꗗ
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Slist_Click() As Short
        '�r���������������������������������������������������������r
        'change start 20190806 kuwahara
        'Call F_Ctl_CS(Main_Inf)
        Dim UODDL As Integer = 712
        Call F_Ctl_CS(Main_Inf, UODDL)
        'change end 20190806 kuwahara
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SM_AllCopy_Click
    '   �T�v�F  ���ړ��e�ɃR�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_SM_AllCopy_Click() As Short
        '���ړ��e�ɃR�s�[
        Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_Esc_Click
    '   �T�v�F  ������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_SM_Esc_Click() As Short
        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
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

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y�����ڂ̓\��t��
        '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
        Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KEYUP
    '   �T�v�F  �e���ڂ�KEYUP����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short

        Dim Trg_Index As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '�r���������������������������������������������������������r
        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False
        '�d���������������������������������������������������������d

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_APPENDC_Click
    '   �T�v�F  ��ʏ���������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' 2007/03/04  CHG START  KUMEDA
    'Private Function Ctl_MN_APPENDC_Click() As Integer
    Public Function Ctl_MN_APPENDC_Click() As Short
        ' 2007/03/04  CHG END

        '    '��ʓ��e������
        '    Call F_Init_Clr_Dsp(-1, Main_Inf)

        '��ʃ{�f�B��������
        Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        '���͒S���ҕҏW
        Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)

        '�����t�H�[�J�X�ʒu�ݒ�
        Call F_Init_Cursor_Set(Main_Inf)

        gv_bolUODDL71_LF_Enable = True

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_SELECTCM_Click
    '   �T�v�F  ���׉�ʂ����������Č����������͂�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CM_SELECTCM_Click() As Short

        '���̓R���g���[���̎g�p�ې���
        Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)

        '��ʃ{�f�B��������
        Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        '�����t�H�[�J�X�ʒu�ݒ�
        Call F_Init_Cursor_Set(Main_Inf)

        '���ݕł�������
        NowPageNum = 0

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_PREV_Click
    '   �T�v�F  ���ׂ̑O�y�[�W��\��
    '   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CM_PREV_Click(ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Object

        Dim Index_Cnt As Short
        Dim Bd_Index As Short

        If NowPageNum > MinPageNum Then
            ''�\������Ă��閾�ׂ�2�y�[�W�ڈȍ~�Ȃ�O�y�[�W��\��
            NowPageNum = NowPageNum - 1
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)

            For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
                'Dsp_Body_Inf�̍s�m�n�擾
                Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)

                '�w�i�F����
                Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
                    Case "1"
                        '���i�Q���v
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
                    Case "2"
                        '���ނ`���v
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
                    Case "3"
                        '���ނa���v
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTYELLOW)
                    Case "99"
                        '�����v
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
                End Select

                If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART_T" Then
                    '�������̔w�i�F����
                    'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                        pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                        'delete 20190325 START saiki
                        'Else
                        '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '	pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                        'delete 20190325 END saiki
                    End If
                End If
            Next
        End If

        '    '����̫����ʒu�ݒ�
        '    Call F_Init_Cursor_Set(Main_Inf)

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_NEXTCM_Click
    '   �T�v�F  ���ׂ̎��y�[�W��\��
    '   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CM_NEXTCM_Click(ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Object

        Dim Index_Cnt As Short
        Dim Bd_Index As Short

        If NowPageNum > 0 Then
            If NowPageNum < MaxPageNum Then
                '�\������Ă��閾�ׂ��ő�y�[�W�ԍ��łȂ��Ȃ玟�y�[�W��\��
                NowPageNum = NowPageNum + 1
                Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)

                For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
                    'Dsp_Body_Inf�̍s�m�n�擾
                    Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Cnt), pm_All)

                    '�w�i�F����
                    Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DIVISION
                        Case "1"
                            '���i�Q���v
                            pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTGREEN)
                        Case "2"
                            '���ނ`���v
                            pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_BLUE)
                        Case "3"
                            '���ނa���v
                            pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_LIGHTYELLOW)
                        Case "99"
                            '�����v
                            pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(COLOR_DTL_GREEN)
                    End Select

                    If pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.Name = "BD_BSART_T" Then
                        '�������̔w�i�F����
                        'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf().Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Detail.Dsp_Value) <> "") And (Trim(pm_All.Dsp_Sub_Inf(Index_Cnt).Detail.Dsp_Value) = "") Then
                            pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = ACE_CMN.COLOR_RED
                            'delete 20190325 START saiki
                            'Else
                            '	'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            '	pm_All.Dsp_Sub_Inf(Index_Cnt).Ctl.BackColor = System.Drawing.ColorTranslator.FromOle(pm_All.Dsp_Sub_Inf(Index_Cnt - 1).Ctl.BackColor)
                            'delete 20190325 END saiki
                        End If
                    End If
                Next
            Else
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODDL71_E_007, Main_Inf)
            End If
        End If

        '    '����̫����ʒu�ݒ�
        '    Call F_Init_Cursor_Set(Main_Inf)

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearDE_Click
    '   �T�v�F  ���׍s������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_ClearDE_Click() As Short

        Dim Act_Index As Short

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̏���������
        Call CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteCM_Click
    '   �T�v�F  �폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_DeleteCM_Click() As Short
        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteDE_Click
    '   �T�v�F  ���׍s�폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_DeleteDE_Click() As Short
        Dim Act_Index As Short

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̍폜����
        Call CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_InsertDE_Click
    '   �T�v�F  ���׍s�}��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_InsertDE_Click() As Short
        Dim Act_Index As Short

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̑}������
        Call CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoDe_Click
    '   �T�v�F  ���׍s����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_UnDoDe_Click() As Short
        Dim Act_Index As Short

        ' 2006/11/28  ADD START  KUMEDA
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' 2006/11/28  ADD END

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̕�������
        Call CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function


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

        '�r���������������������������������������������������������r
        '�t�H�[���^�C�g��
        Me.Text = RTrim(SSS_PrgNm) & "�@�|�@�햾�ו\�|"

        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Index_Wk = CShort(SYSDT.Tag)
        '��ʓ��t
        ' === 20060727 === UPDATE S
        '    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
        ' === 20060727 === UPDATE E
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

        Dim BD_MEISYO_Top As Short '���̂�Top
        Dim BD_MEISYO_Height As Short '���̂�Height

        Dim Bd_Index As Short

        '�r���������������������������������������������������������r
        '�P�s�ڂ̖��̂�Top��Height����Ƃ���
        BD_MEISYO_Top = VB6.FromPixelsUserY(BD_MEISYO(1).Top, 0, 9360, 624)
        BD_MEISYO_Height = VB6.FromPixelsUserHeight(BD_MEISYO(1).Height, 9360, 624) + Hosei_Value

        '�\���ŏI�s�܂ŏ���
        For Bd_Index = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
            '�z�u
            '����
            BD_MEISYO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))
            '�󒍐�
            BD_UODSU_T(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))
            '�󒍋��z
            BD_UODKN_T(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))
            '�d��
            BD_SIKKN_T(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))
            '����
            BD_BAISA_T(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))
            '������
            BD_BSART_T(Bd_Index).Top = VB6.TwipsToPixelsY(BD_MEISYO_Top + BD_MEISYO_Height * (Bd_Index - 1))


            '�\��
            '����
            BD_MEISYO(Bd_Index).Visible = True
            '�󒍐�
            BD_UODSU_T(Bd_Index).Visible = True
            '�󒍋��z
            BD_UODKN_T(Bd_Index).Visible = True
            '�d��
            BD_SIKKN_T(Bd_Index).Visible = True
            '����
            BD_BAISA_T(Bd_Index).Visible = True
            '������
            BD_BSART_T(Bd_Index).Visible = True

        Next
        '�d���������������������������������������������������������d

    End Function
    'delete 20190326 START saiki
    'Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
    '	'��x����̂��ߎg�p�s��
    '	Main_Inf.TM_StartUp_Ctl.Enabled = False
    '	'��ʈ���N������TRUE�Ƃ���
    '	PP_SSSMAIN.Operable = True
    '	'����̫����ʒu�ݒ�s
    '	Call F_Init_Cursor_Set(Main_Inf)
    '   End Sub
    'delete 20190326 END saiki


    'UPGRADE_WARNING: Form �C�x���g FR_SSSMAIN2.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub FR_SSSMAIN2_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        Dim Trg_Index As Short
        Dim RtnCode As Short
        Dim Wk_GetuKi As String
        ' 2007/01/16  ADD START  KUMEDA
        Dim Wk_NENGETU As String
        ' 2007/01/16  ADD END

        If gv_bolUODDL71_Active = True Then
            '����or�n��or�c�Ə��������փZ�b�g
            If gv_UODDL71_BMNCD <> "" Then
                '����
                '����
                Trg_Index = CShort(HD_BMNCD.Tag)
                '��ʂɕҏW
                Call CF_Set_Item_Direct(gv_UODDL71_BMNCD, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Chk_HD_BMNCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), True, Main_Inf)
                '�擾���e�\��/�N���A
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_SET, Main_Inf)

                '�n��i�N���A�j
                Trg_Index = CShort(HD_TIKCD.Tag)
                Call CF_Set_Item_Direct(Space(2), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�c�Ə��i�N���A�j
                Trg_Index = CShort(HD_EIGCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

            ElseIf gv_UODDL71_TIKCD <> "" Then
                '�n��
                '����i�N���A�j
                Trg_Index = CShort(HD_BMNCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�n��
                Trg_Index = CShort(HD_TIKCD.Tag)
                '��ʂɕҏW
                Call CF_Set_Item_Direct(gv_UODDL71_TIKCD, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Chk_HD_TIKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), True, Main_Inf)
                '�擾���e�\��/�N���A
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_SET, Main_Inf)

                '�c�Ə��i�N���A�j
                Trg_Index = CShort(HD_EIGCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

            ElseIf gv_UODDL71_EIGCD <> "" Then
                '�c�Ə�
                '����i�N���A�j
                Trg_Index = CShort(HD_BMNCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�n��i�N���A�j
                Trg_Index = CShort(HD_TIKCD.Tag)
                Call CF_Set_Item_Direct(Space(2), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�c�Ə�
                Trg_Index = CShort(HD_EIGCD.Tag)
                '��ʂɕҏW
                Call CF_Set_Item_Direct(gv_UODDL71_EIGCD, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Chk_HD_EIGCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), True, Main_Inf)
                '�擾���e�\��/�N���A
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_SET, Main_Inf)

            Else
                '�S��
                '����i�N���A�j
                Trg_Index = CShort(HD_BMNCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�n��i�N���A�j
                Trg_Index = CShort(HD_TIKCD.Tag)
                Call CF_Set_Item_Direct(Space(2), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

                '�c�Ə��i�N���A�j
                Trg_Index = CShort(HD_EIGCD.Tag)
                Call CF_Set_Item_Direct(Space(1), Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_CLR, Main_Inf)

            End If

            ' 2007/01/17  ADD START  KUMEDA
            If Trim(gv_UODDL71_BMNCD) = "9" Then
                gv_UODDL71_BMNCD = " "
            End If
            If Trim(gv_UODDL71_TIKCD) = "99" Then
                gv_UODDL71_TIKCD = "  "
            End If
            If Trim(gv_UODDL71_EIGCD) = "9" Then
                gv_UODDL71_EIGCD = " "
            End If
            ' 2007/01/17  ADD END

            ' 2007/01/16  ADD START  KUMEDA
            Wk_NENGETU = F_GET_FIRSTDAY(gv_UODDL71_GETU_KI, GV_UNYDate)
            ' 2007/01/16  ADD END

            '�����^����
            If gv_UODDL71_GETU_KI = "1" Then
                '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change 20190325 START saiki
                'CS_GETU_KI.Caption = "�݁@�v"
                'delete start 20190806 kuwahara
                'btnF7.Text = "(F7)" & vbCrLf & "�݁@�v"
                'delete end 20190806 kuwahara
                'change 20190325 START saiki
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_GetuKi = VB.Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2)
                ' 2007/01/16  CHG END
            Else
                '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'change 20190325 START saiki
                'CS_GETU_KI.Caption = "���@��"
                'delete start 20190806 kuwahara
                'btnF7.Text = "(F7)" & vbCrLf & "���@��"
                'delete end 20190806 kuwahara
                'change 20190325 START saiki
                ' 2007/01/16  CHG START  KUMEDA
                '            Wk_GetuKi = "����"
                Wk_GetuKi = VB.Left(Wk_NENGETU, 4) & "/" & Mid(Wk_NENGETU, 5, 2) & "�@�`�@"
                Wk_GetuKi = Wk_GetuKi & VB.Left(GV_UNYDate, 4) & "/" & Mid(GV_UNYDate, 5, 2)
                ' 2007/01/16  CHG END
            End If

            '�󒍁^����
            If gv_UODDL71_JUC_URI = "1" Then
                'change 20190325 START saiki
                ''��
                '' 2007/01/16  CHG START  KUMEDA
                ''            FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(3).Caption = Wk_GetuKi
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(11).Caption = "��@�@��"
                '' 2007/01/16  CHG END
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(4).Caption = "�󒍐�"
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(5).Caption = "�󒍋��z"
                ''UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'CS_JUC_URI.Caption = "���@��"


                '��
                ' 2007/01/16  CHG START  KUMEDA
                '            FM_Panel3D1(3).Caption = Wk_GetuKi & "�@��"
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_11.Text = "��@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_4.Text = "�󒍐�"
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_5.Text = "�󒍋��z"
                'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'delete start 20190806 kuwahara
                'btnF6.Text = "(F6)" & vbCrLf & "���@��"
                'delete start 20190806 kuwahara
                'change 20190325 END saiki

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                lab_uri.Visible = False
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾
                'ADD 20190404 START saiki
                UODDL712 = Me
                'ADD 20190404 START saiki
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_JUC(gv_UODDL71_GETU_KI, Main_Inf)
            Else
                'change 20190325 START saiki
                ''����
                ''�L���v�V�����ύX
                '' 2007/01/16  CHG START  KUMEDA
                ''            FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(3).Caption = Wk_GetuKi
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(11).Caption = "���@�@��"
                '' 2007/01/16  CHG END
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(4).Caption = "���㐔"
                ''UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'FM_Panel3D1(5).Caption = "������z"
                ''UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'CS_JUC_URI.Caption = "��@��"


                '����
                '�L���v�V�����ύX
                ' 2007/01/16  CHG START  KUMEDA
                '            FM_Panel3D1(3).Caption = Wk_GetuKi & "�@����"
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_3.Text = Wk_GetuKi
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_11.Text = "���@�@��"
                ' 2007/01/16  CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_4.Text = "���㐔"
                'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1().Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                _FM_Panel3D1_5.Text = "������z"
                'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI.Caption �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'delete start 20190806 kuwahara
                'btnF6.Text = "(F6)" & vbCrLf & "��@��"
                'delete end 20190806 kuwahara
                'change 20190325 END saiki

                'ADD START FKS)INABA 2010/10/05 ****************************************
                '�A���[��CF10100501
                lab_uri.Visible = True
                'ADD  END  FKS)INABA 2010/10/05 ****************************************

                '�f�[�^�擾

                ''ADD 20190404 START saiki
                UODDL712 = Me
                'ADD 20190404 START saiki
                RtnCode = F_GET_BD_DATA_KIS_MEISAI_URI(gv_UODDL71_GETU_KI, Main_Inf)
            End If

            If RtnCode = 0 Then
                '�o�͂ł��閾�׃f�[�^������
                Exit Sub
            Else
                '���݂̃y�[�W��������
                NowPageNum = 1

                '�ŏ㖾�ײ��ޯ��������
                Main_Inf.Dsp_Body_Inf.Cur_Top_Index = 1

                '���ׂ���ʂɕҏW
                Trg_Index = CShort(TX_Dummy.Tag)
                Call F_DSP_BD_Inf(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_SET, Main_Inf)
            End If

            '����̫����ʒu�ݒ�
            Call F_Init_Cursor_Set(Main_Inf)

            'Form_Active���s����
            gv_bolUODDL71_Active = False
        End If
    End Sub

    Private Sub FR_SSSMAIN2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'DB�ڑ�
        'change 20190403 START saiki
        'Call CF_Ora_USR1_Open()
        CON = DB_START()
        'change 20190403 END saiki

        '���ʏ���������
        Call CF_Init()

        '��ʏ��ݒ�
        Call Init_Def_Dsp()

        '��ʓ��e������
        Call F_Init_Clr_Dsp(-1, Main_Inf)

        '��ʖ��׏��ݒ�
        Call Init_Def_Body_Inf()

        '��ʖ��ו�������
        Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '���׃��P�[�V����
        Call Set_Body_Location()

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        '��ʕ\���ʒu�ݒ�
        Call CF_Set_Frm_Location(Me)


        ''���͒S���ҕҏW
        Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)


        '�V�X�e�����ʏ���
        Call CF_System_Process(Me)

        'Form_Active���s����
        gv_bolUODDL71_Active = True

        SetBar(Me)

    End Sub

    Private Sub FR_SSSMAIN2_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        Dim intRet As Short

        If gv_bolUODDL71_EndFlg = False Then
            '�m�F���b�Z�[�W�\��
            intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODDL71_E_006, Main_Inf)

            If intRet <> MsgBoxResult.No Then
                '������ʃN���[�Y
                Call F_Ctl_WLS_Close()

                '�I���������s����
                gv_bolUODDL71_EndFlg = True

                '���ʏI�������H
                'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSMAIN2 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                'delete 20190326 START saiki
                'Me = Nothing
                'delete 20190326 END saiki
                FR_SSSMAIN.Close()
                'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSMAIN ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                FR_SSSMAIN = Nothing
                FR_SSSMAIN1.Close()
                'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSMAIN1 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
                FR_SSSMAIN1 = Nothing

            Else
                Cancel = True
                '�X�e�[�^�X�o�[������
                Call CF_Clr_Prompt(Main_Inf)
                '20190424 ADD START
                eventArgs.Cancel = Cancel
                '20190424 ADD END
                Exit Sub

            End If

            ' === 20060907 === INSERT S
            Main_Inf.Dsp_Base.IsUnload = True
            ' === 20060907 === INSERT E

            'change 20190403 START saiki
            ''DB�ڑ�����
            '         Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
            DB_CLOSE(CON)
            'change 20190403 END saiki
        End If

        ' 2006/11/15  ADD START  KUMEDA
        Call SSSWIN_LOGWRT("�v���O�����I��")
        ' 2006/11/15  ADD END

        eventArgs.Cancel = Cancel
    End Sub

    'change 20190403 START saiki
    'Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
    '    Debug.Print("MN_Ctrl_Click")
    '    Call Ctl_Item_Click(MN_Ctrl)
    'End Sub

    'Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
    '    Debug.Print("MN_EditMn_Click")
    '    Call Ctl_Item_Click(MN_EditMn)
    'End Sub

    'Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
    '    Debug.Print("MN_Oprt_Click")
    '    Call Ctl_Item_Click(MN_Oprt)
    'End Sub

    'Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
    '    Debug.Print("MN_Execute_Click")
    '    Call Ctl_Item_Click(MN_Execute)
    'End Sub

    'Public Sub MN_Hardcopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
    '    Debug.Print("MN_HARDCOPY_Click")
    '    Call Ctl_Item_Click(MN_HARDCOPY)
    'End Sub

    'Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
    '    Debug.Print("MN_EndCm_Click")
    '    Call Ctl_Item_Click(MN_EndCm)
    'End Sub

    'Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
    '    Debug.Print("MN_ClearItm_Click")
    '    Call Ctl_Item_Click(MN_ClearItm)
    'End Sub

    'Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
    '	Debug.Print("MN_UnDoItem_Click")
    '	Call Ctl_Item_Click(MN_UnDoItem)
    '   End Sub


    'Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
    '    Debug.Print("MN_Cut_Click")
    '    Call Ctl_Item_Click(MN_Cut)
    'End Sub

    'Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
    '    Debug.Print("MN_Copy_Click")
    '    Call Ctl_Item_Click(MN_Copy)
    'End Sub

    'Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
    '    Debug.Print("MN_Paste_Click")
    '    Call Ctl_Item_Click(MN_Paste)
    'End Sub

    'Public Sub MN_SelectCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SELECTCM.Click
    '    Debug.Print("MN_SELECTCM_Click")
    '    Call Ctl_Item_Click(MN_SELECTCM)
    'End Sub

    'Public Sub MN_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_PREV.Click
    '    Debug.Print("MN_PREV_Click")
    '    Call Ctl_Item_Click(MN_PREV)
    'End Sub

    'Public Sub MN_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NEXTCM.Click
    '    Debug.Print("MN_NEXTCM_Click")
    '    Call Ctl_Item_Click(MN_NEXTCM)
    'End Sub

    'Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
    '    Debug.Print("MN_Slist_Click")
    '    Call Ctl_Item_Click(MN_Slist)
    'End Sub

    'Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
    '	Debug.Print("CM_EndCm_Click")
    '	Call Ctl_Item_Click(CM_EndCm)
    'End Sub

    'Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
    '	Debug.Print("CM_Execute_Click")
    '	Call Ctl_Item_Click(CM_Execute)
    'End Sub

    'Private Sub CM_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Slist.Click
    '	Debug.Print("CM_SLIST_Click")
    '	Call Ctl_Item_Click(CM_SLIST)
    'End Sub


    'Private Sub CM_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SELECTCM.Click
    '    Debug.Print("CM_SELECTCM_Click")
    '    Call Ctl_Item_Click(CM_SELECTCM)
    'End Sub

    'Private Sub CM_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PREV.Click
    '    Debug.Print("CM_PREV_Click")
    '    Call Ctl_Item_Click(CM_PREV)
    'End Sub

    'Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NEXTCM.Click
    '    Debug.Print("CM_NEXTCM_Click")
    '    Call Ctl_Item_Click(CM_NEXTCM)
    'End Sub

    'Private Sub CM_EXECUTE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
    'End Sub


    'Private Sub CM_NEXTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_NEXTCM_MouseDown")
    '    Call Ctl_Item_MouseDown(CM_NEXTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_PREV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_PREV_MouseDown")
    '    Call Ctl_Item_MouseDown(CM_PREV, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SELECTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_SELECTCM_MouseDown")
    '    Call Ctl_Item_MouseDown(CM_SELECTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Slist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Slist.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_NextCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseMove
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_NEXTCM_MouseMove")
    '    Call Ctl_Item_MouseMove(CM_NEXTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Prev_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseMove
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_PREV_MouseMove")
    '    Call Ctl_Item_MouseMove(CM_PREV, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SelectCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SelectCm.MouseMove
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_SELECTCM_MouseMove")
    '    Call Ctl_Item_MouseMove(CM_SELECTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EXECUTE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EXECUTE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_NEXTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_NEXTCM_MouseUp")
    '    Call Ctl_Item_MouseUp(CM_NEXTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_PREV_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_PREV_MouseUp")
    '    Call Ctl_Item_MouseUp(CM_PREV, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SELECTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("CM_SELECTCM_MouseUp")
    '    Call Ctl_Item_MouseUp(CM_SELECTCM, Button, Shift, X, Y)
    'End Sub

    'Private Sub SYSDT_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    ' === 20060817 === DELETE S
    '    '    Debug.Print "SYSDT_MouseDown"
    '    '    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
    '    ' === 20060817 === DELETE E
    'End Sub

    'Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("SYSDT_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_BMNCD_Click()
    '    Debug.Print("CS_BMNCD_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_BMNCD)
    'End Sub

    'Private Sub CS_TIKCD_Click()
    '    Debug.Print("CS_TIKCD_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_TIKCD)
    'End Sub

    'Private Sub CS_EIGCD_Click()
    '    Debug.Print("CS_EIGCD_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_EIGCD)
    'End Sub

    'Private Sub CS_JUC_URI_Click()
    '    Debug.Print("CS_JUC_URI_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_JUC_URI)
    'End Sub

    'Private Sub CS_GETU_KI_Click()
    '    Debug.Print("CS_GETU_KI_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_GETU_KI)
    'End Sub

    'Private Sub CS_BMNSOU_Click()
    '    Debug.Print("CS_BMNSOU_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_BMNSOU)
    'End Sub

    'Private Sub CS_SOUKATU_Click()
    '    Debug.Print("CS_SOUKATU_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_SOUKATU)
    'End Sub

    'Private Sub CS_BMNCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_BMNCD_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_BMNCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_TIKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_TIKCD_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_TIKCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_EIGCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_EIGCD_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_EIGCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_JUC_URI_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_JUC_URI_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_JUC_URI, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_GETU_KI_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_GETU_KI_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_GETU_KI, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_BMNSOU_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_BMNSOU_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_BMNSOU, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_SOUKATU_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_SOUKATU_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_SOUKATU, Button, Shift, X, Y)
    'End Sub

    'Private Sub CS_BMNCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_BMNCD_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_BMNCD)
    'End Sub

    'Private Sub CS_TIKCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_TIKCD_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_TIKCD)
    'End Sub

    'Private Sub CS_EIGCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_EIGCD_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_EIGCD)
    'End Sub

    'Private Sub CS_JUC_URI_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_JUC_URI_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_JUC_URI)
    'End Sub

    'Private Sub CS_GETU_KI_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_GETU_KI_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_GETU_KI)
    'End Sub

    'Private Sub CS_BMNSOU_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_BMNSOU_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_BMNSOU)
    'End Sub

    'Private Sub CS_SOUKATU_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_SOUKATU_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_SOUKATU)
    'End Sub

    'Private Sub CS_BMNCD_GotFocus()
    '    Debug.Print("CS_BMNCD_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_BMNCD)
    'End Sub

    'Private Sub CS_TIKCD_GotFocus()
    '    Debug.Print("CS_TIKCD_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_TIKCD)
    'End Sub

    'Private Sub CS_EIGCD_GotFocus()
    '    Debug.Print("CS_EIGCD_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_EIGCD)
    'End Sub

    'Private Sub CS_JUC_URI_GotFocus()
    '    Debug.Print("CS_JUC_URI_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_JUC_URI)
    'End Sub

    'Private Sub CS_GETU_KI_GotFocus()
    '    Debug.Print("CS_GETU_KI_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_GETU_KI)
    'End Sub

    'Private Sub CS_BMNSOU_GotFocus()
    '    Debug.Print("CS_BMNSOU_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_BMNSOU)
    'End Sub

    'Private Sub CS_SOUKATU_GotFocus()
    '    Debug.Print("CS_SOUKATU_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_SOUKATU)
    'End Sub

    'Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("FM_Panel3D1_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_IN_TANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_IN_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.TextChanged
    '    Debug.Print("HD_IN_TANCD_Change")
    '    Call Ctl_Item_Change(HD_IN_TANCD)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_IN_TANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_IN_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.TextChanged
    '    Debug.Print("HD_IN_TANNM_Change")
    '    Call Ctl_Item_Change(HD_IN_TANNM)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_BMNCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_BMNCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.TextChanged
    '    Debug.Print("HD_BMNCD_Change")
    '    Call Ctl_Item_Change(HD_BMNCD)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_BMNNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_BMNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.TextChanged
    '    Debug.Print("HD_BMNNM_Change")
    '    Call Ctl_Item_Change(HD_BMNNM)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_TIKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_TIKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.TextChanged
    '    Debug.Print("HD_TIKCD_Change")
    '    Call Ctl_Item_Change(HD_TIKCD)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_TIKNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_TIKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.TextChanged
    '    Debug.Print("HD_TIKNM_Change")
    '    Call Ctl_Item_Change(HD_TIKNM)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_EIGCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_EIGCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.TextChanged
    '    Debug.Print("HD_EIGCD_Change")
    '    Call Ctl_Item_Change(HD_EIGCD)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g HD_EIGNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_EIGNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.TextChanged
    '    Debug.Print("HD_EIGNM_Change")
    '    Call Ctl_Item_Change(HD_EIGNM)
    'End Sub

    'Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
    '    Debug.Print("HD_IN_TANCD_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_IN_TANCD)
    'End Sub

    'Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
    '    Debug.Print("HD_IN_TANNM_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_IN_TANNM)
    'End Sub

    'Private Sub HD_BMNCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Enter
    '    Debug.Print("HD_BMNCD_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_BMNCD)
    'End Sub

    'Private Sub HD_BMNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Enter
    '    Debug.Print("HD_BMNNM_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_BMNNM)
    'End Sub

    'Private Sub HD_TIKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.Enter
    '    Debug.Print("HD_TIKCD_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_TIKCD)
    'End Sub

    'Private Sub HD_TIKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.Enter
    '    Debug.Print("HD_TIKNM_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_TIKNM)
    'End Sub

    'Private Sub HD_EIGCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.Enter
    '    Debug.Print("HD_EIGCD_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_EIGCD)
    'End Sub

    'Private Sub HD_EIGNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.Enter
    '    Debug.Print("HD_EIGNM_GotFocus")
    '    Call Ctl_Item_GotFocus(HD_EIGNM)
    'End Sub

    'Private Sub HD_IN_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_IN_TANCD_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_IN_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_IN_TANNM_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_BMNCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_BMNCD_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_BMNCD, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_BMNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNNM.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_BMNNM_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_BMNNM, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_TIKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKCD.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_TIKCD_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_TIKCD, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_TIKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKNM.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_TIKNM_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_TIKNM, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_EIGCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGCD.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_EIGCD_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_EIGCD, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_EIGNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGNM.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_EIGNM_KeyDown")
    '    Call Ctl_Item_KeyDown(HD_EIGNM, KEYCODE, Shift)
    'End Sub

    'Private Sub HD_IN_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANCD.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_IN_TANCD_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_IN_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANNM.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_IN_TANNM_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_BMNCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNCD.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_BMNCD_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_BMNCD, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_BMNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNNM.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_BMNNM_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_BMNNM, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_TIKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TIKCD.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_TIKCD_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_TIKCD, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_TIKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TIKNM.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_TIKNM_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_TIKNM, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_EIGCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_EIGCD.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_EIGCD_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_EIGCD, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_EIGNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_EIGNM.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("HD_EIGNM_KeyPress")
    '    Call Ctl_Item_KeyPress(HD_EIGNM, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_IN_TANCD_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_IN_TANCD)
    'End Sub

    'Private Sub HD_IN_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_IN_TANNM_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_IN_TANNM)
    'End Sub

    'Private Sub HD_BMNCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_BMNCD_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_BMNCD)
    'End Sub

    'Private Sub HD_BMNNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNNM.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_BMNNM_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_BMNNM)
    'End Sub

    'Private Sub HD_TIKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKCD.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_TIKCD_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_TIKCD)
    'End Sub

    'Private Sub HD_TIKNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKNM.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_TIKNM_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_TIKNM)
    'End Sub

    'Private Sub HD_EIGCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGCD.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_EIGCD_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_EIGCD)
    'End Sub

    'Private Sub HD_EIGNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGNM.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("HD_EIGNM_KeyUp")
    '    Call Ctl_Item_KeyUp(HD_EIGNM)
    'End Sub

    'Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
    '    Debug.Print("HD_IN_TANCD_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_IN_TANCD)
    'End Sub

    'Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
    '    Debug.Print("HD_IN_TANNM_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_IN_TANNM)
    'End Sub

    'Private Sub HD_BMNCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Leave
    '    Debug.Print("HD_BMNCD_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_BMNCD)
    'End Sub

    'Private Sub HD_BMNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Leave
    '    Debug.Print("HD_BMNNM_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_BMNNM)
    'End Sub

    'Private Sub HD_TIKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.Leave
    '    Debug.Print("HD_TIKCD_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_TIKCD)
    'End Sub

    'Private Sub HD_TIKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.Leave
    '    Debug.Print("HD_TIKNM_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_TIKNM)
    'End Sub

    'Private Sub HD_EIGCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.Leave
    '    Debug.Print("HD_EIGCD_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_EIGCD)
    'End Sub

    'Private Sub HD_EIGNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.Leave
    '    Debug.Print("HD_EIGNM_LostFocus")
    '    Call Ctl_Item_LostFocus(HD_EIGNM)
    'End Sub

    'Private Sub HD_IN_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_IN_TANCD_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_IN_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_IN_TANNM_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_BMNCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_BMNCD_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_BMNCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_BMNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_BMNNM_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_BMNNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_TIKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKCD.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_TIKCD_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_TIKCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_TIKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKNM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_TIKNM_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_TIKNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_EIGCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGCD.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_EIGCD_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_EIGCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_EIGNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGNM.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_EIGNM_MouseDown")
    '    Call Ctl_Item_MouseDown(HD_EIGNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_IN_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_IN_TANCD_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_IN_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_IN_TANNM_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_BMNCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_BMNCD_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_BMNCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_BMNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_BMNNM_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_BMNNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_TIKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKCD.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_TIKCD_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_TIKCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_TIKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKNM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_TIKNM_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_TIKNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_EIGCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGCD.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_EIGCD_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_EIGCD, Button, Shift, X, Y)
    'End Sub

    'Private Sub HD_EIGNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGNM.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("HD_EIGNM_MouseUp")
    '    Call Ctl_Item_MouseUp(HD_EIGNM, Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_MEISYO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MEISYO.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_MEISYO(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_UODSU_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU_T.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_UODSU_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_UODKN_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN_T.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_UODKN_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_SIKKN_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKKN_T.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_SIKKN_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_BAISA_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BAISA_T.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_BAISA_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_BSART_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BSART_T.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_MouseDown")
    '    Call Ctl_Item_MouseDown(BD_BSART_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_MEISYO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MEISYO.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_MEISYO(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_UODSU_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU_T.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_UODSU_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_UODKN_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN_T.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_UODKN_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_SIKKN_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKKN_T.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_SIKKN_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_BAISA_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BAISA_T.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_BAISA_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_BSART_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BSART_T.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_MouseUp")
    '    Call Ctl_Item_MouseUp(BD_BSART_T(Index), Button, Shift, X, Y)
    'End Sub

    'Private Sub BD_MEISYO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MEISYO.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_MEISYO(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_UODSU_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU_T.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_UODSU_T(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_UODKN_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN_T.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_UODKN_T(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_SIKKN_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKKN_T.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_SIKKN_T(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_BAISA_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BAISA_T.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_BAISA_T(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_BSART_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BSART_T.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_KeyDown")
    '    Call Ctl_Item_KeyDown(BD_BSART_T(Index), KEYCODE, Shift)
    'End Sub

    'Private Sub BD_MEISYO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_MEISYO.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_MEISYO(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_UODSU_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODSU_T.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_UODSU_T(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_UODKN_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODKN_T.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_UODKN_T(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_SIKKN_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIKKN_T.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_SIKKN_T(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_BAISA_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BAISA_T.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_BAISA_T(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_BSART_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BSART_T.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_KeyPress")
    '    Call Ctl_Item_KeyPress(BD_BSART_T(Index), KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub BD_MEISYO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MEISYO.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_MEISYO(Index))
    'End Sub

    'Private Sub BD_UODSU_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU_T.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_UODSU_T(Index))
    'End Sub

    'Private Sub BD_UODKN_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN_T.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_UODKN_T(Index))
    'End Sub

    'Private Sub BD_SIKKN_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKKN_T.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_SIKKN_T(Index))
    'End Sub

    'Private Sub BD_BAISA_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BAISA_T.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_BAISA_T(Index))
    'End Sub

    'Private Sub BD_BSART_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BSART_T.KeyUp
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_KeyUp")
    '    Call Ctl_Item_KeyUp(BD_BSART_T(Index))
    'End Sub

    'Private Sub BD_MEISYO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.Enter
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_MEISYO(Index))
    'End Sub

    'Private Sub BD_UODSU_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.Enter
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_UODSU_T(Index))
    'End Sub

    'Private Sub BD_UODKN_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.Enter
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_UODKN_T(Index))
    'End Sub

    'Private Sub BD_SIKKN_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.Enter
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_SIKKN_T(Index))
    'End Sub

    'Private Sub BD_BAISA_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.Enter
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_BAISA_T(Index))
    'End Sub

    'Private Sub BD_BSART_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.Enter
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_GotFocus")
    '    Call Ctl_Item_GotFocus(BD_BSART_T(Index))
    'End Sub

    'Private Sub BD_MEISYO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.Leave
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_MEISYO(Index))
    'End Sub

    'Private Sub BD_UODSU_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.Leave
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_UODSU_T(Index))
    'End Sub

    'Private Sub BD_UODKN_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.Leave
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_UODKN_T(Index))
    'End Sub

    'Private Sub BD_SIKKN_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.Leave
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_SIKKN_T(Index))
    'End Sub

    'Private Sub BD_BAISA_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.Leave
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_BAISA_T(Index))
    'End Sub

    'Private Sub BD_BSART_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.Leave
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_LostFocus")
    '    Call Ctl_Item_LostFocus(BD_BSART_T(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_MEISYO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_MEISYO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.TextChanged
    '    Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
    '    Debug.Print("BD_MEISYO_Change")
    '    Call Ctl_Item_Change(BD_MEISYO(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_UODSU_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_UODSU_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.TextChanged
    '    Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODSU_T_Change")
    '    Call Ctl_Item_Change(BD_UODSU_T(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_UODKN_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_UODKN_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.TextChanged
    '    Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_UODKN_T_Change")
    '    Call Ctl_Item_Change(BD_UODKN_T(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_SIKKN_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_SIKKN_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.TextChanged
    '    Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
    '    Debug.Print("BD_SIKKN_T_Change")
    '    Call Ctl_Item_Change(BD_SIKKN_T(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_BAISA_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_BAISA_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.TextChanged
    '    Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
    '    Debug.Print("BD_BAISA_T_Change")
    '    Call Ctl_Item_Change(BD_BAISA_T(Index))
    'End Sub

    ''UPGRADE_WARNING: �C�x���g BD_BSART_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub BD_BSART_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.TextChanged
    '    Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
    '    Debug.Print("BD_BSART_T_Change")
    '    Call Ctl_Item_Change(BD_BSART_T(Index))
    'End Sub

    'Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("TX_Message_MouseDown")
    '    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
    'End Sub

    'Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("TX_Message_MouseUp")
    '    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
    'End Sub

    'Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("TX_Message_KeyDown")
    '    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
    'End Sub

    'Private Sub TX_Message_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Message.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("TX_Message_KeyPress")
    '    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
    '    Debug.Print("TX_Message_GotFocus")
    '    Call Ctl_Item_GotFocus(TX_Message)
    'End Sub

    'Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
    '    Debug.Print("TX_Message_LostFocus")
    '    Call Ctl_Item_LostFocus(TX_Message)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g TX_Message.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
    '    Debug.Print("TX_Message_Change")
    '    Call Ctl_Item_Change(TX_Message)
    'End Sub

    'Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
    '    Debug.Print("Image1_Click")
    '    Call Ctl_Item_Click(Image1)
    'End Sub

    'Private Sub Image1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    ' === 20060817 === DELETE S
    '    '    Debug.Print "Image1_MouseDown"
    '    '    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
    '    ' === 20060817 === DELETE E
    'End Sub

    'Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("Image1_MouseMove")
    '    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
    'End Sub

    'Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("Image1_MouseUp")
    '    Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
    'End Sub

    'Private Sub TX_Dummy_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("TX_Dummy_MouseDown")
    '    Call Ctl_Item_MouseDown(TX_Dummy, Button, Shift, X, Y)
    'End Sub

    'Private Sub TX_Dummy_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    Debug.Print("TX_Dummy_MouseUp")
    '    Call Ctl_Item_MouseUp(TX_Dummy, Button, Shift, X, Y)
    'End Sub

    'Private Sub TX_Dummy_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Dummy.KeyDown
    '    Dim KEYCODE As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Debug.Print("TX_Dummy_KeyDown")
    '    Call Ctl_Item_KeyDown(TX_Dummy, KEYCODE, Shift)
    'End Sub

    'Private Sub TX_Dummy_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Dummy.KeyPress
    '    Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '    Debug.Print("TX_Dummy_KeyPress")
    '    Call Ctl_Item_KeyPress(TX_Dummy, KeyAscii)
    '    eventArgs.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        eventArgs.Handled = True
    '    End If
    'End Sub

    'Private Sub TX_Dummy_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Enter
    '    Debug.Print("TX_Dummy_GotFocus")
    '    Call Ctl_Item_GotFocus(TX_Dummy)
    'End Sub

    'Private Sub TX_Dummy_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Leave
    '    Debug.Print("TX_Dummy_LostFocus")
    '    Call Ctl_Item_LostFocus(TX_Dummy)
    'End Sub

    ''UPGRADE_WARNING: �C�x���g TX_Dummy.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub TX_Dummy_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.TextChanged
    '    Debug.Print("TX_Dummy_Change")
    '    Call Ctl_Item_Change(TX_Dummy)
    'End Sub

    'Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
    '	Debug.Print("SM_AllCopy_Click")
    '	Call Ctl_Item_Click(SM_AllCopy)
    '   End Sub


    'Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
    '    Debug.Print("SM_Esc_Click")
    '    Call Ctl_Item_Click(SM_Esc)
    'End Sub

    'Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
    '	Debug.Print("SM_FullPast_Click")
    '	Call Ctl_Item_Click(SM_FullPast)
    '   End Sub


    'Public Sub SM_ShortCut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_ShortCut.Click
    '    '    Debug.Print "SM_ShortCut_Click"
    '    '    Call Ctl_Item_Click(SM_ShortCut)
    'End Sub
    '' 2007/01/12  ADD START  KUMEDA
    'Private Sub CS_SAIYOMI_Click()
    '    Debug.Print("CS_SAIYOMI_Click")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_Click(CS_SAIYOMI)
    'End Sub
    'Private Sub CS_SAIYOMI_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
    '    Debug.Print("CS_SAIYOMI_MouseUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_MouseUp(CS_SAIYOMI, Button, Shift, X, Y)
    'End Sub
    'Private Sub CS_SAIYOMI_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
    '    Debug.Print("CS_SAIYOMI_KeyUp")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_KeyUp(CS_SAIYOMI)
    'End Sub
    'Private Sub CS_SAIYOMI_GotFocus()
    '    Debug.Print("CS_SAIYOMI_GotFocus")
    '    'UPGRADE_WARNING: �I�u�W�F�N�g CS_SAIYOMI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    Call Ctl_Item_GotFocus(CS_SAIYOMI)
    'End Sub
    '' 2007/01/12  ADD END



    Private Sub CM_Prev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PREV.Click
        Debug.Print("CM_PREV_Click")
        Call Ctl_Item_Click(CM_PREV)
    End Sub

    Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NEXTCM.Click
        Debug.Print("CM_NEXTCM_Click")
        Call Ctl_Item_Click(CM_NEXTCM)
    End Sub



    Private Sub CM_NEXTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NEXTCM_MouseDown")
        Call Ctl_Item_MouseDown(CM_NEXTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_PREV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PREV.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PREV_MouseDown")
        Call Ctl_Item_MouseDown(CM_PREV, Button, Shift, X, Y)
    End Sub


    Private Sub CM_NextCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NEXTCM.Click
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NEXTCM_MouseMove")
        Call Ctl_Item_MouseMove(CM_NEXTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_Prev_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PREV_MouseMove")
        Call Ctl_Item_MouseMove(CM_PREV, Button, Shift, X, Y)
    End Sub


    Private Sub CM_NEXTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_NEXTCM_MouseUp")
        Call Ctl_Item_MouseUp(CM_NEXTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_PREV_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_PREV_MouseUp")
        Call Ctl_Item_MouseUp(CM_PREV, Button, Shift, X, Y)
    End Sub


    Private Sub SYSDT_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        ' === 20060817 === DELETE S
        '    Debug.Print "SYSDT_MouseDown"
        '    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
        ' === 20060817 === DELETE E
    End Sub

    Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    End Sub
    'add start 20190805 kuwahara
    Private Sub CS_BMNCD_Click(sender As Object, e As EventArgs) Handles CS_BMNCD.Click
        Debug.Print("CS_BMNCD_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_BMNCD)
    End Sub
    'add end 20190805 kuwahara

    Private Sub CS_TIKCD_Click(sender As Object, e As EventArgs) Handles CS_TIKCD.Click
        Debug.Print("CS_TIKCD_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_TIKCD)
    End Sub

    Private Sub CS_EIGCD_Click(sender As Object, e As EventArgs) Handles CS_EIGCD.Click
        Debug.Print("CS_EIGCD_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_EIGCD)
    End Sub



    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Debug.Print("btnF1_Click")

        Call Ctl_Item_Click(btnF1)
        'add start 20190806
        If Judge1 = 0 Then
            Judge1 = 1
        Else
            Judge1 = 0
        End If
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        Debug.Print("btnF2_Click")

        Call Ctl_Item_Click(btnF2)
    End Sub
    Private Sub btnF3_Click(sender As Object, e As EventArgs) Handles btnF3.Click
        Debug.Print("btnF3_Click")

        Call Ctl_Item_Click(btnF3)
    End Sub
    Private Sub btnF4_Click(sender As Object, e As EventArgs) Handles btnF4.Click
        Call Ctl_Item_Click(btnF4)
    End Sub

    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        Call Ctl_Item_Click(btnF5)
    End Sub
    Private Sub btnF6_Click(sender As Object, e As EventArgs) Handles btnF6.Click
        Debug.Print("btnF6_Click")

        Call Ctl_Item_Click(btnF6)
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click
        Debug.Print("btnF7_Click")

        Call Ctl_Item_Click(btnF7)
    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click
        Debug.Print("btnF8_Click")

        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF10_Click(sender As Object, e As EventArgs) Handles btnF10.Click
        Debug.Print("btnF10_Click")
        Call Ctl_Item_Click(btnF10)
    End Sub

    Private Sub btnF11_Click(sender As Object, e As EventArgs) Handles btnF11.Click
        Call Ctl_Item_Click(btnF11)
        'add start 20190806
        If Judge2 = 0 Then
            Judge2 = 1
        Else
            Judge2 = 0
        End If
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub CS_BMNCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_BMNCD_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_BMNCD, Button, Shift, X, Y)
    End Sub

    Private Sub CS_TIKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_TIKCD_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_TIKCD, Button, Shift, X, Y)
    End Sub

    Private Sub CS_EIGCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_EIGCD_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_EIGCD, Button, Shift, X, Y)
    End Sub

    Private Sub btnF6_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("btnF6_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(btnF6, Button, Shift, X, Y)
    End Sub

    Private Sub btnF7_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("btnF7_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF7 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(btnF7, Button, Shift, X, Y)
    End Sub

    Private Sub btnF8_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("btnF8_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(btnF8, Button, Shift, X, Y)
    End Sub

    Private Sub btnF10_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("btnF10_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(btnF10, Button, Shift, X, Y)
    End Sub

    Private Sub CS_BMNCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CS_BMNCD_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(CS_BMNCD)
    End Sub

    Private Sub CS_TIKCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CS_TIKCD_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(CS_TIKCD)
    End Sub

    Private Sub CS_EIGCD_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CS_EIGCD_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(CS_EIGCD)
    End Sub

    Private Sub btnF6_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("btnF6_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JUC_URI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(btnF6)
    End Sub

    Private Sub btnF7_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("btnF7_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(btnF7)
    End Sub

    Private Sub btnF8_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("btnF8_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(btnF8)
    End Sub

    Private Sub CS_SOUKATU_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("CS_SOUKATU_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_SOUKATU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(btnF10)
    End Sub

    Private Sub CS_BMNCD_GotFocus()
        Debug.Print("CS_BMNCD_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_BMNCD)
    End Sub

    Private Sub CS_TIKCD_GotFocus()
        Debug.Print("CS_TIKCD_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TIKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_TIKCD)
    End Sub

    Private Sub CS_EIGCD_GotFocus()
        Debug.Print("CS_EIGCD_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_EIGCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_EIGCD)
    End Sub

    Private Sub btnF6_GotFocus()
        Debug.Print("btnF6_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF6 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(btnF6)
    End Sub

    Private Sub btnF7_GotFocus()
        Debug.Print("btnF7_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_GETU_KI �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(btnF7)
    End Sub

    Private Sub CS_BMNSOU_GotFocus()
        Debug.Print("CS_BMNSOU_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BMNSOU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(btnF8)
    End Sub

    Private Sub btnF10_GotFocus()
        Debug.Print("btnF10_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF10 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(btnF10)
    End Sub

    Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("FM_Panel3D1_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
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

    'UPGRADE_WARNING: �C�x���g HD_BMNCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BMNCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.TextChanged
        Debug.Print("HD_BMNCD_Change")
        Call Ctl_Item_Change(HD_BMNCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_BMNNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BMNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.TextChanged
        Debug.Print("HD_BMNNM_Change")
        Call Ctl_Item_Change(HD_BMNNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TIKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TIKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.TextChanged
        Debug.Print("HD_TIKCD_Change")
        Call Ctl_Item_Change(HD_TIKCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TIKNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TIKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.TextChanged
        Debug.Print("HD_TIKNM_Change")
        Call Ctl_Item_Change(HD_TIKNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_EIGCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_EIGCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.TextChanged
        Debug.Print("HD_EIGCD_Change")
        Call Ctl_Item_Change(HD_EIGCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_EIGNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_EIGNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.TextChanged
        Debug.Print("HD_EIGNM_Change")
        Call Ctl_Item_Change(HD_EIGNM)
    End Sub

    Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
        Debug.Print("HD_IN_TANCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
        Debug.Print("HD_IN_TANNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_BMNCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Enter
        Debug.Print("HD_BMNCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_BMNCD)
    End Sub

    Private Sub HD_BMNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Enter
        Debug.Print("HD_BMNNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_BMNNM)
    End Sub

    Private Sub HD_TIKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.Enter
        Debug.Print("HD_TIKCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_TIKCD)
    End Sub

    Private Sub HD_TIKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.Enter
        Debug.Print("HD_TIKNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_TIKNM)
    End Sub

    Private Sub HD_EIGCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.Enter
        Debug.Print("HD_EIGCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_EIGCD)
    End Sub

    Private Sub HD_EIGNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.Enter
        Debug.Print("HD_EIGNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_EIGNM)
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

    Private Sub HD_BMNCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BMNCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_BMNCD, KEYCODE, Shift)
    End Sub

    Private Sub HD_BMNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNNM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BMNNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_BMNNM, KEYCODE, Shift)
    End Sub

    Private Sub HD_TIKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TIKCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_TIKCD, KEYCODE, Shift)
    End Sub

    Private Sub HD_TIKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKNM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TIKNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_TIKNM, KEYCODE, Shift)
    End Sub

    Private Sub HD_EIGCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGCD.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_EIGCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_EIGCD, KEYCODE, Shift)
    End Sub

    Private Sub HD_EIGNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGNM.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_EIGNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_EIGNM, KEYCODE, Shift)
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

    Private Sub HD_BMNCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BMNCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_BMNCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_BMNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BMNNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_BMNNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TIKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TIKCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TIKCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_TIKCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TIKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TIKNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TIKNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_TIKNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_EIGCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_EIGCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_EIGCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_EIGCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_EIGNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_EIGNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_EIGNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_EIGNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANNM)
    End Sub

    Private Sub HD_BMNCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BMNCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_BMNCD)
    End Sub

    Private Sub HD_BMNNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNNM.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BMNNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_BMNNM)
    End Sub

    Private Sub HD_TIKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TIKCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_TIKCD)
    End Sub

    Private Sub HD_TIKNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TIKNM.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TIKNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_TIKNM)
    End Sub

    Private Sub HD_EIGCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGCD.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_EIGCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_EIGCD)
    End Sub

    Private Sub HD_EIGNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_EIGNM.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_EIGNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_EIGNM)
    End Sub

    Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
        Debug.Print("HD_IN_TANCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
        Debug.Print("HD_IN_TANNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_BMNCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Leave
        Debug.Print("HD_BMNCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_BMNCD)
    End Sub

    Private Sub HD_BMNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNNM.Leave
        Debug.Print("HD_BMNNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_BMNNM)
    End Sub

    Private Sub HD_TIKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKCD.Leave
        Debug.Print("HD_TIKCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_TIKCD)
    End Sub

    Private Sub HD_TIKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TIKNM.Leave
        Debug.Print("HD_TIKNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_TIKNM)
    End Sub

    Private Sub HD_EIGCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGCD.Leave
        Debug.Print("HD_EIGCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_EIGCD)
    End Sub

    Private Sub HD_EIGNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_EIGNM.Leave
        Debug.Print("HD_EIGNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_EIGNM)
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

    Private Sub HD_BMNCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BMNCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_BMNCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BMNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BMNNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_BMNNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TIKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TIKCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_TIKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TIKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TIKNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_TIKNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_EIGCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_EIGCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_EIGCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_EIGNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_EIGNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_EIGNM, Button, Shift, X, Y)
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

    Private Sub HD_BMNCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BMNCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_BMNCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BMNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BMNNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BMNNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_BMNNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TIKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TIKCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_TIKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TIKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TIKNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TIKNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_TIKNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_EIGCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_EIGCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_EIGCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_EIGNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_EIGNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_EIGNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_EIGNM, Button, Shift, X, Y)
    End Sub

    Private Sub BD_MEISYO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MEISYO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_MouseDown")
        Call Ctl_Item_MouseDown(BD_MEISYO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODSU_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU_T.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_MouseDown")
        Call Ctl_Item_MouseDown(BD_UODSU_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODKN_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN_T.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_MouseDown")
        Call Ctl_Item_MouseDown(BD_UODKN_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKKN_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKKN_T.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_MouseDown")
        Call Ctl_Item_MouseDown(BD_SIKKN_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BAISA_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BAISA_T.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_MouseDown")
        Call Ctl_Item_MouseDown(BD_BAISA_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BSART_T_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BSART_T.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_MouseDown")
        Call Ctl_Item_MouseDown(BD_BSART_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_MEISYO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_MEISYO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_MouseUp")
        Call Ctl_Item_MouseUp(BD_MEISYO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODSU_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU_T.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_MouseUp")
        Call Ctl_Item_MouseUp(BD_UODSU_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODKN_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN_T.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_MouseUp")
        Call Ctl_Item_MouseUp(BD_UODKN_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKKN_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKKN_T.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_MouseUp")
        Call Ctl_Item_MouseUp(BD_SIKKN_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BAISA_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BAISA_T.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_MouseUp")
        Call Ctl_Item_MouseUp(BD_BAISA_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BSART_T_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BSART_T.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_MouseUp")
        Call Ctl_Item_MouseUp(BD_BSART_T(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_MEISYO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MEISYO.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_KeyDown")
        Call Ctl_Item_KeyDown(BD_MEISYO(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_UODSU_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU_T.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_KeyDown")
        Call Ctl_Item_KeyDown(BD_UODSU_T(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_UODKN_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN_T.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_KeyDown")
        Call Ctl_Item_KeyDown(BD_UODKN_T(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_SIKKN_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKKN_T.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_KeyDown")
        Call Ctl_Item_KeyDown(BD_SIKKN_T(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_BAISA_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BAISA_T.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_KeyDown")
        Call Ctl_Item_KeyDown(BD_BAISA_T(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_BSART_T_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BSART_T.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_KeyDown")
        Call Ctl_Item_KeyDown(BD_BSART_T(Index), KEYCODE, Shift)
    End Sub

    Private Sub BD_MEISYO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_MEISYO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_KeyPress")
        Call Ctl_Item_KeyPress(BD_MEISYO(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UODSU_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODSU_T.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_KeyPress")
        Call Ctl_Item_KeyPress(BD_UODSU_T(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UODKN_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODKN_T.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_KeyPress")
        Call Ctl_Item_KeyPress(BD_UODKN_T(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SIKKN_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIKKN_T.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_KeyPress")
        Call Ctl_Item_KeyPress(BD_SIKKN_T(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_BAISA_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BAISA_T.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_KeyPress")
        Call Ctl_Item_KeyPress(BD_BAISA_T(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_BSART_T_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BSART_T.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_KeyPress")
        Call Ctl_Item_KeyPress(BD_BSART_T(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_MEISYO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_MEISYO.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_KeyUp")
        Call Ctl_Item_KeyUp(BD_MEISYO(Index))
    End Sub

    Private Sub BD_UODSU_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU_T.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_KeyUp")
        Call Ctl_Item_KeyUp(BD_UODSU_T(Index))
    End Sub

    Private Sub BD_UODKN_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN_T.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_KeyUp")
        Call Ctl_Item_KeyUp(BD_UODKN_T(Index))
    End Sub

    Private Sub BD_SIKKN_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKKN_T.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_KeyUp")
        Call Ctl_Item_KeyUp(BD_SIKKN_T(Index))
    End Sub

    Private Sub BD_BAISA_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BAISA_T.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_KeyUp")
        Call Ctl_Item_KeyUp(BD_BAISA_T(Index))
    End Sub

    Private Sub BD_BSART_T_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BSART_T.KeyUp
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_KeyUp")
        Call Ctl_Item_KeyUp(BD_BSART_T(Index))
    End Sub

    Private Sub BD_MEISYO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.Enter
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_GotFocus")
        Call Ctl_Item_GotFocus(BD_MEISYO(Index))
    End Sub

    Private Sub BD_UODSU_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.Enter
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_GotFocus")
        Call Ctl_Item_GotFocus(BD_UODSU_T(Index))
    End Sub

    Private Sub BD_UODKN_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.Enter
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_GotFocus")
        Call Ctl_Item_GotFocus(BD_UODKN_T(Index))
    End Sub

    Private Sub BD_SIKKN_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.Enter
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_GotFocus")
        Call Ctl_Item_GotFocus(BD_SIKKN_T(Index))
    End Sub

    Private Sub BD_BAISA_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.Enter
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_GotFocus")
        Call Ctl_Item_GotFocus(BD_BAISA_T(Index))
    End Sub

    Private Sub BD_BSART_T_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.Enter
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_GotFocus")
        Call Ctl_Item_GotFocus(BD_BSART_T(Index))
    End Sub

    Private Sub BD_MEISYO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.Leave
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_LostFocus")
        Call Ctl_Item_LostFocus(BD_MEISYO(Index))
    End Sub

    Private Sub BD_UODSU_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.Leave
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_LostFocus")
        Call Ctl_Item_LostFocus(BD_UODSU_T(Index))
    End Sub

    Private Sub BD_UODKN_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.Leave
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_LostFocus")
        Call Ctl_Item_LostFocus(BD_UODKN_T(Index))
    End Sub

    Private Sub BD_SIKKN_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.Leave
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_LostFocus")
        Call Ctl_Item_LostFocus(BD_SIKKN_T(Index))
    End Sub

    Private Sub BD_BAISA_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.Leave
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_LostFocus")
        Call Ctl_Item_LostFocus(BD_BAISA_T(Index))
    End Sub

    Private Sub BD_BSART_T_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.Leave
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_LostFocus")
        Call Ctl_Item_LostFocus(BD_BSART_T(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_MEISYO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_MEISYO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_MEISYO.TextChanged
        Dim Index As Short = BD_MEISYO.GetIndex(eventSender)
        Debug.Print("BD_MEISYO_Change")
        Call Ctl_Item_Change(BD_MEISYO(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UODSU_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UODSU_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU_T.TextChanged
        Dim Index As Short = BD_UODSU_T.GetIndex(eventSender)
        Debug.Print("BD_UODSU_T_Change")
        Call Ctl_Item_Change(BD_UODSU_T(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UODKN_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UODKN_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN_T.TextChanged
        Dim Index As Short = BD_UODKN_T.GetIndex(eventSender)
        Debug.Print("BD_UODKN_T_Change")
        Call Ctl_Item_Change(BD_UODKN_T(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_SIKKN_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_SIKKN_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKKN_T.TextChanged
        Dim Index As Short = BD_SIKKN_T.GetIndex(eventSender)
        Debug.Print("BD_SIKKN_T_Change")
        Call Ctl_Item_Change(BD_SIKKN_T(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_BAISA_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_BAISA_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BAISA_T.TextChanged
        Dim Index As Short = BD_BAISA_T.GetIndex(eventSender)
        Debug.Print("BD_BAISA_T_Change")
        Call Ctl_Item_Change(BD_BAISA_T(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_BSART_T.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_BSART_T_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BSART_T.TextChanged
        Dim Index As Short = BD_BSART_T.GetIndex(eventSender)
        Debug.Print("BD_BSART_T_Change")
        Call Ctl_Item_Change(BD_BSART_T(Index))
    End Sub

    Private Sub TX_Message_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Message_MouseDown")
        Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Message_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Message.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Message_MouseUp")
        Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TX_Message_KeyDown")
        Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
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

    Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
        Debug.Print("TX_Message_GotFocus")
        Call Ctl_Item_GotFocus(TX_Message)
    End Sub

    Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
        Debug.Print("TX_Message_LostFocus")
        Call Ctl_Item_LostFocus(TX_Message)
    End Sub

    'UPGRADE_WARNING: �C�x���g TX_Message.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub TX_Message_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.TextChanged
        Debug.Print("TX_Message_Change")
        Call Ctl_Item_Change(TX_Message)
    End Sub

    Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
        Debug.Print("Image1_Click")
        Call Ctl_Item_Click(Image1)
    End Sub

    Private Sub Image1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        ' === 20060817 === DELETE S
        '    Debug.Print "Image1_MouseDown"
        '    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
        ' === 20060817 === DELETE E
    End Sub

    Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("Image1_MouseMove")
        Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
    End Sub

    Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("Image1_MouseUp")
        Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Dummy_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Dummy_MouseDown")
        Call Ctl_Item_MouseDown(TX_Dummy, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Dummy_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_Dummy.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_Dummy_MouseUp")
        Call Ctl_Item_MouseUp(TX_Dummy, Button, Shift, X, Y)
    End Sub

    Private Sub TX_Dummy_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Dummy.KeyDown
        Dim KEYCODE As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TX_Dummy_KeyDown")
        Call Ctl_Item_KeyDown(TX_Dummy, KEYCODE, Shift)
    End Sub

    Private Sub TX_Dummy_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TX_Dummy.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("TX_Dummy_KeyPress")
        Call Ctl_Item_KeyPress(TX_Dummy, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TX_Dummy_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Enter
        Debug.Print("TX_Dummy_GotFocus")
        Call Ctl_Item_GotFocus(TX_Dummy)
    End Sub

    Private Sub TX_Dummy_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.Leave
        Debug.Print("TX_Dummy_LostFocus")
        Call Ctl_Item_LostFocus(TX_Dummy)
    End Sub

    'UPGRADE_WARNING: �C�x���g TX_Dummy.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub TX_Dummy_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Dummy.TextChanged
        Debug.Print("TX_Dummy_Change")
        Call Ctl_Item_Change(TX_Dummy)
    End Sub

    Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
        Debug.Print("SM_AllCopy_Click")
        Call Ctl_Item_Click(SM_AllCopy)
    End Sub


    Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
        Debug.Print("SM_Esc_Click")
        Call Ctl_Item_Click(SM_Esc)
    End Sub

    Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
        Debug.Print("SM_FullPast_Click")
        Call Ctl_Item_Click(SM_FullPast)
    End Sub


    Public Sub SM_ShortCut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_ShortCut.Click
        '    Debug.Print "SM_ShortCut_Click"
        '    Call Ctl_Item_Click(SM_ShortCut)
    End Sub


    Private Sub btnF3_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("btnF3_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(btnF3, Button, Shift, X, Y)
    End Sub
    Private Sub btnF3_KeyUp(ByRef KEYCODE As Short, ByRef Shift As Short)
        Debug.Print("btnF3_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(btnF3)
    End Sub
    Private Sub btnF3_GotFocus()
        Debug.Print("btnF3_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g btnF3 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(btnF3)
    End Sub

    'change 20190403 END saiki


    'ADD 20190402 START saiki
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '���͒S���҃R�[�h
            'UPGRADE_ISSUE: Control HD_IN_TANCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '���͒S���Җ�
            'UPGRADE_ISSUE: Control HD_IN_TANNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function

    Private Sub FR_SSSMAIN2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                '��/����
                Case Keys.F1
                    Me.btnF1.PerformClick()
                '�ēǍ�
                Case Keys.F2
                    Me.btnF2.PerformClick()
                '�O��
                Case Keys.F3
                    Me.btnF3.PerformClick()
                '����
                Case Keys.F4
                    Me.btnF4.PerformClick()
                '�Q��
                Case Keys.F5
                    Me.btnF5.PerformClick()
                '����ʑ����\
                Case Keys.F6
                    Me.btnF6.PerformClick()
                '�@��ʑ����\
                Case Keys.F7
                    Me.btnF7.PerformClick()
                ''�@�햾�ו\
                'Case Keys.F8
                '    Me.btnF8.PerformClick()
                '�N���A
                Case Keys.F9
                    Me.btnF9.PerformClick()
                '����/�O���ؑ�
                Case Keys.F10
                    Me.btnF10.PerformClick()
                '�P��/�݌v
                Case Keys.F11
                    Me.btnF11.PerformClick()
                '�I��
                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
End Class