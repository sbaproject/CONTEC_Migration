Option Strict Off
Option Explicit On
Friend Class FR_SSSSUB03
	Inherits System.Windows.Forms.Form
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
	'=== ����ʂ̑S�����i�[ =================
	'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Main_Inf As Cls_All
    '=== ����ʂ̑S�����i�[ =================
    Private Const FM_PANEL3D1_CNT As Short = 28 '�p�l���R���g���[����
    '20190703 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '20190703 ADD END

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
		
		'��ʊ�b���ݒ�
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REFERENCE '��ʕ���
			.Item_Cnt = 202 '��ʍ��ڐ�
			.Dsp_Body_Cnt = 15 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
			.Max_Body_Cnt = 99 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
			.Body_Col_Cnt = 10 '���ׂ̗񍀖ڐ�
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
		TX_CursorRest.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// ���j���[���ҏW
		'///////////////////
		Index_Wk = Index_Wk + 1
		'�����P
		MN_Ctrl.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�I��
		MN_EndCm.Tag = CStr(Index_Wk)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
        '�I���C���[�W
        '20190703 CHG START
        'CM_EndCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190703 CHG END
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== �Ұ�ސݒ� ======================
		Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
		Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
		'=== �Ұ�ސݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'�w�b�_�C���[�W
		Image1.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�������t
		'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SYSDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		'///////////////////
		'// �w�b�_���ҏW
		'///////////////////
		Index_Wk = Index_Wk + 1
		'���i�R�[�h
		HD_HINCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		'''' UPD 2009/02/19  FKS) S.Nakajima    Start
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		'''' UPD 2009/02/19  FKS) S.Nakajima    End
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�^��
		HD_HINNMA.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 30
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���i��
		HD_HINNMB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���͒S����(����)
		HD_IN_TANCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���͒S����(����)
		HD_IN_TANNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���o�ɓ�
		HD_STKDLVDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_STKDLVDT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�o��
		HD_DLVSU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DLVSU
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_HIKSU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HIKSU
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���
		HD_JOTAI.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JOTAI
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		' === 20150928 === UPDATE S -
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		' === 20150928 === UPDATE E -
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		' === 20150928 === UPDATE S -
		'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		' === 20150928 === UPDATE E -
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_STKSU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_STKSU
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_SZAISU.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SZAISU
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�o�^��
		HD_DENDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DENDT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'����
		HD_SBNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���Ӑ�
		HD_TOKRN.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�q��
		HD_SOUNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUNM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�q�撍���ԍ�
		HD_TOKJDNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKJDNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 23
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 23
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'=== ���׏c�X�N���[���o�[�ݒ� ======================
		Main_Inf.Bd_Vs_Scrl = VS_Scrl
		'=== ���׏c�X�N���[���o�[�ݒ� ======================
		
		Index_Wk = Index_Wk + 1
		'���
		BD_TRAKB(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRAKB(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
		'����
		BD_TRANO(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRANO(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���o�ɓ�
		BD_TRADT(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRADT(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�o�ɐ�
		BD_SYUSU(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SYUSU(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'������
		BD_HIKSU(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���^��
		BD_ATMNKB(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ATMNKB(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���ɐ�
		BD_NYUSU(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUSU(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���Ӑ�
		BD_TOKRN(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�c�ƕ���
		BD_BUMNM(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BUMNM(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�q��
		BD_SOUNM(1).Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			BD_TRAKB.Load(BD_Cnt) '���
			BD_TRANO.Load(BD_Cnt) '����
			BD_TRADT.Load(BD_Cnt) '���o�ɓ�
			BD_SYUSU.Load(BD_Cnt) '�o��
			BD_HIKSU.Load(BD_Cnt) '����
			BD_ATMNKB.Load(BD_Cnt) '���^��
			BD_NYUSU.Load(BD_Cnt) '����
			BD_TOKRN.Load(BD_Cnt) '���Ӑ�
			BD_BUMNM.Load(BD_Cnt) '�c�ƕ���
			BD_SOUNM.Load(BD_Cnt) '�q��
			
			Index_Wk = Index_Wk + 1
			'���
			BD_TRAKB(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRAKB(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'����
			BD_TRANO(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRANO(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���o�ɓ�
			BD_TRADT(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRADT(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�o��
			BD_SYUSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SYUSU(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'����
			BD_HIKSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���^��
			BD_ATMNKB(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ATMNKB(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'����
			BD_NYUSU(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUSU(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'���Ӑ�
			BD_TOKRN(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�c�ƕ���
			BD_BUMNM(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BUMNM(BD_Cnt)
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
			'���ו��̂P�s��̏���ݒ�
			Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
			
			Index_Wk = Index_Wk + 1
			'�q��
			BD_SOUNM(BD_Cnt).Tag = Index_Wk
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		'��ʊ�b���ݒ�
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��
		
		Index_Wk = Index_Wk + 1
		'TX_Mode
		TX_Mode.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
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
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
			Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		Next 
		
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
		Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
		If Rtn_Chk = CHK_OK Then
			'�`�F�b�N�n�j��
			'�擾���e�\��
			Dsp_Mode = DSP_SET
		Else
			'�`�F�b�N�m�f��
			'�擾���e�N���A
			Dsp_Mode = DSP_CLR
			' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
			'�L�[�t���O�����ɖ߂�
			gv_bolKeyFlg = False
			' === 20060905 === INSERT E -
		End If
		'�擾���e�\��/�N���A
		Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			Call SSSMAIN0005.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			' === 20060804 === UPDATE S - ACE)Nagasawa
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			' === 20060804 === UPDATE E -
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
		Call SSSMAIN0005.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYRIGHT����(̫����ړ��Ȃ�)
				Call SSSMAIN0005.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'������ړ�����
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		
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
		Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			'KEYDOWN����
			Call SSSMAIN0005.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			If Move_Flg = True Then
				'���̍��ڂֈړ������ꍇ
				'������ړ�����
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		Call SSSMAIN0005.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT����(̫����ړ�����)
				Call SSSMAIN0005.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'������ړ�����
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		
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
		Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			'KEYUP����
			Call SSSMAIN0005.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
			
			If Move_Flg = True Then
				'���̍��ڂֈړ������ꍇ
				'������ړ�����
				Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		
		' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
		'Enter���̂݃t���O��ON
		If pm_KeyCode = System.Windows.Forms.Keys.Return Then
			If gv_bolKeyFlg = True Then
				Exit Function
			End If
			
			gv_bolKeyFlg = True
		End If
		' === 20060802 === INSERT E -
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case True
			''        '��������
			''        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
			''            pm_KeyCode = 0
			''            '����������
			''            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        '����
			''        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
			''            pm_KeyCode = 0
			''            '������
			''            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        '����
			''        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
			''            pm_KeyCode = 0
			''            '������
			''            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        '����
			''        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
			''            pm_KeyCode = 0
			''            '������
			''            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        '����
			''        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
			''            '������
			''            pm_KeyCode = 0
			''            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        'DELETE��
			''        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
			''            pm_KeyCode = 0
			''            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
			''
			''        'INSERT��
			''        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
			''            pm_KeyCode = 0
			''            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
			''
			''        'TAB��
			''        Case pm_KeyCode = vbKeyF16
			''            pm_KeyCode = 0
			''            '����������
			''            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
			''
			''        'Shift+TAB��
			''        Case pm_KeyCode = vbKeyF15
			''            pm_KeyCode = 0
			''            '�O̫����ʒu�ֈړ�
			''            Call SSSMAIN0005.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
			
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
		
		' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
		'�L�[�t���O�����ɖ߂�
		gv_bolKeyFlg = False
		' === 20060802 === INSERT E -
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_LostFocus
	'   �T�v�F  �e���ڂ�LOSTFOCUS����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20060920 === UPDATE S - ACE)Sejima
	'DPrivate Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer
	' === 20060920 === UPDATE ��
	Private Function Ctl_Item_LostFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Boolean
		' === 20060920 === UPDATE E
		
		Dim Trg_Index As Short
		Dim Act_Index As Short
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
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
		Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call SSSMAIN0005.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'������ړ�����
			Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			
			'@'        '����̫������۰ق̑I�������Đݒ�
			'@'        '�I����Ԃ̐ݒ�
			'@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
			'@'        '���ڐF�ݒ�
			'@'        Call CF_Set_Item_Color(Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS)
			
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		End If
		
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
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'�r���������������������������������������������������������r
			'ͯ�ޕ�����
			Rtn_Chk = SSSMAIN0005.F_Ctl_Head_Chk(Main_Inf)
			'�d���������������������������������������������������������d
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If
		
		'�r���������������������������������������������������������r
		'����̫����擾����
		Call SSSMAIN0005.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
		Call SSSMAIN0005.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call SSSMAIN0005.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				
				'����̫����ʒu����E�ֈړ�
				Call SSSMAIN0005.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
        '20190703 ADD START
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '20190703 ADD END
        Dim Trg_Index As Short
		
		If Main_Inf.Dsp_Base.Change_Flg = True Then
			Main_Inf.Dsp_Base.Change_Flg = False
			Exit Function
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'����KEYCHANG����
		Call SSSMAIN0005.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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

                '20190703 CHG START
                'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '20190703 CHG ENE
                '�p�l���̏ꍇ
                Call SSSMAIN0005.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'�C���[�W�̏ꍇ
				Select Case Trg_Index
					Case CShort(CM_EndCm.Tag)
						'�I���Ұ��
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
						
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
                '20190703 CHG START	
                'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190703 CHG END
                '�I���Ұ��
                ' === 20060926 === UPDATE S - ACE)Nagasawa �K�C�h���b�Z�[�W�̕ύX
                '            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)
                Call CF_Set_Prompt(IMG_ENDCM_SUB_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)
				' === 20060926 === UPDATE E -
				
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)

        Select Case Trg_Index
            '20190703 CHG START
            'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190703 CHG END
                '�I���Ұ��
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        End Select

        '����MOUSEDOWN����
        Call SSSMAIN0005.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'��è�޺��۰ي������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'�r���������������������������������������������������������r
		'�e������ʌďo
		Select Case Trg_Index
			Case CShort(MN_Ctrl.Tag)
				'�����P
				Call Ctl_MN_Ctrl_Click()
				
			Case CShort(MN_EndCm.Tag)
				'�I��
				Call Ctl_MN_EndCm_Click()

                '�����j���[�C���[�W
                '20190703 CHG START
                'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '20190703 CHG END
                '�I��
                Me.Close()
				
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Ant_Index = CShort(Me.ActiveControl.Tag)
		
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
	Private Function Ctl_MN_Execute_Click() As Short
		
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
			wk_Cursor = SSSMAIN0005.AE_Hardcopy_SSSMAIN()
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
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_UnDoItem_Click
	'   �T�v�F  ���ڕ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_UnDoItem_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Cut_Click
	'   �T�v�F  �؂���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Cut_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Copy_Click
	'   �T�v�F  �R�s�[
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Copy_Click() As Short
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_MN_Paste_Click
	'   �T�v�F  �\��t��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_MN_Paste_Click() As Short
		
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
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'�������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
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
		
		If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
			Main_Inf.Dsp_Base.VS_Scr_Flg = False
			Exit Function
		End If
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		' === 20061116 === INSERT E -
		
		'��è�޺��۰ي������ޯ���擾
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = CShort(Me.ActiveControl.Tag)
		
		'����VS_SCRL_CHANGE����
		Call SSSMAIN0005.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
		
	End Function
	
	Private Sub FR_SSSSUB03_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		Main_Inf.Dsp_Base.IsUnload = True

        '���ʏI�������H
        'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSSUB03 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '20190703 DELL START
        'Me = Nothing
        '20190703 DELL END

        'ADD 20151007
        If SSS_PrgId <> "HIKDL51" Then
			'ADD 20151007
			FR_SSSMAIN.Show()
			'ADD 20151007
		End If
		'ADD 20151007
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
		'��x����̂��ߎg�p�s��
		Main_Inf.TM_StartUp_Ctl.Enabled = False
		'��ʈ���N������TRUE�Ƃ���
		PP_SSSMAIN.Operable = True
		'����̫����ʒu�ݒ�
		Call SSSMAIN0005.F_Init_Cursor_Set(Main_Inf)
	End Sub
	
	Private Sub FR_SSSSUB03_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'��ʏ��ݒ�
		Call Init_Def_Dsp()
		
		'��ʓ��e������
		Call SSSMAIN0005.F_Init_Clr_Dsp(-1, Main_Inf)
		
		'��ʖ��׏��ݒ�
		Call Init_Def_Body_Inf()
		
		'��ʖ��ו�������
		Call SSSMAIN0005.F_Init_Clr_Dsp_Body(-1, Main_Inf)
		
		'���׃��P�[�V����
		Call Set_Body_Location()
		
		'�����\���ҏW
		Call Edi_Dsp_Def()
		
		'��ʕ\���ʒu�ݒ�
		Call CF_Set_Frm_Location(Me)
		
		'���͒S���ҕҏW
		Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
		
		'�{�f�B���ҏW_�T�u�Ɖ��ʗp
		Call SSSMAIN0005.F_DSP_BD_Inf_SUB(0, Main_Inf)
		
		'��ʖ��ו\��
		Call CF_Body_Dsp(Main_Inf)
		
		'��ʐF�ݒ�
		Call SSSMAIN0005.CF_Set_BD_Color(Main_Inf)
		
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
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
				
				'�������p���
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
				
				'�������
				'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		Dim BD_TRAKB_Top As Short
		Dim BD_TRAKB_Height As Short
		
		Dim Bd_Index As Short
		
		'�P�s�ڂ�No��Top��Height����Ƃ���
		BD_TRAKB_Top = VB6.PixelsToTwipsY(BD_TRAKB(1).Top)
		BD_TRAKB_Height = VB6.PixelsToTwipsY(BD_TRAKB(1).Height) + Hosei_Value
		
		'�\���ŏI�s�܂ŏ���
		For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
			If Bd_Index >= 2 Then
				'�Q�s�ڈȍ~����
				'�z�u
				BD_TRAKB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_TRANO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_TRADT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_SYUSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_HIKSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_ATMNKB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_NYUSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_TOKRN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_BUMNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
				BD_SOUNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1))
			End If
			
			'�\��
			BD_TRAKB(Bd_Index).Visible = True
			BD_TRANO(Bd_Index).Visible = True
			BD_TRADT(Bd_Index).Visible = True
			BD_SYUSU(Bd_Index).Visible = True
			BD_HIKSU(Bd_Index).Visible = True
			BD_ATMNKB(Bd_Index).Visible = True
			BD_NYUSU(Bd_Index).Visible = True
			BD_TOKRN(Bd_Index).Visible = True
			BD_BUMNM(Bd_Index).Visible = True
			BD_SOUNM(Bd_Index).Visible = True
			
		Next 
		
		'�X�N���[���o�[�̐ݒ�
		Main_Inf.Bd_Vs_Scrl.Top = VB6.TwipsToPixelsY(BD_TRAKB_Top)
		Main_Inf.Bd_Vs_Scrl.Height = VB6.TwipsToPixelsY(BD_TRAKB_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt)
		
		'�d���������������������������������������������������������d
		
	End Function
	
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Debug.Print("CM_EndCm_Click")
		Call Ctl_Item_Click(CM_EndCm)
	End Sub
	
	Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
		Debug.Print("Image1_Click")
		Call Ctl_Item_Click(Image1)
	End Sub
	
	Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
		Debug.Print("MN_Ctrl_Click")
		Call Ctl_Item_Click(MN_Ctrl)
	End Sub
	
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Debug.Print("MN_EndCm_Click")
		Call Ctl_Item_Click(MN_EndCm)
	End Sub
	
	Private Sub BD_TRKBN_MouseDown(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("BD_TRAKB_MouseDown")
		Call Ctl_Item_MouseDown(BD_TRAKB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TRANO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TRANO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_MouseDown")
		Call Ctl_Item_MouseDown(BD_TRANO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TRADT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TRADT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_MouseDown")
		Call Ctl_Item_MouseDown(BD_TRADT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SYUSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SYUSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_SYUSU(Index), Button, Shift, X, Y)
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
	
	Private Sub BD_ATMNKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ATMNKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_MouseDown")
		Call Ctl_Item_MouseDown(BD_ATMNKB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_NYUSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_MouseDown")
		Call Ctl_Item_MouseDown(BD_NYUSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_MouseDown")
		Call Ctl_Item_MouseDown(BD_TOKRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_BUMNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BUMNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_MouseDown")
		Call Ctl_Item_MouseDown(BD_BUMNM(Index), Button, Shift, X, Y)
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
	
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseDown")
		Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
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
	
	Private Sub HD_STKDLVDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STKDLVDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_STKDLVDT_MouseDown")
		Call Ctl_Item_MouseDown(HD_STKDLVDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DLVSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DLVSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DLVSU_MouseDown")
		Call Ctl_Item_MouseDown(HD_DLVSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HIKSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HIKSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HIKSU_MouseDown")
		Call Ctl_Item_MouseDown(HD_HIKSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JOTAI_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JOTAI.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_JOTAI_MouseDown")
		Call Ctl_Item_MouseDown(HD_JOTAI, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_STKSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STKSU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_STKSU_MouseDown")
		Call Ctl_Item_MouseDown(HD_STKSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SZAISU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SZAISU.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SZAISU_MouseDown")
		Call Ctl_Item_MouseDown(HD_SZAISU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DENDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENDT.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DENDT_MouseDown")
		Call Ctl_Item_MouseDown(HD_DENDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseDown")
		Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKRN_MouseDown")
		Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SOUNM_MouseDown")
		Call Ctl_Item_MouseDown(HD_SOUNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKJDNNO_MouseDown")
		Call Ctl_Item_MouseDown(HD_TOKJDNNO, Button, Shift, X, Y)
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
	
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("Image1_MouseMove")
		Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TRAKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TRAKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_MouseUp")
		Call Ctl_Item_MouseUp(BD_TRAKB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TRANO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TRANO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_MouseUp")
		Call Ctl_Item_MouseUp(BD_TRANO(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TRADT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TRADT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_MouseUp")
		Call Ctl_Item_MouseUp(BD_TRADT(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_SYUSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SYUSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_SYUSU(Index), Button, Shift, X, Y)
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
	
	Private Sub BD_ATMNKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ATMNKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_MouseUp")
		Call Ctl_Item_MouseUp(BD_ATMNKB(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_NYUSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_MouseUp")
		Call Ctl_Item_MouseUp(BD_NYUSU(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_MouseUp")
		Call Ctl_Item_MouseUp(BD_TOKRN(Index), Button, Shift, X, Y)
	End Sub
	
	Private Sub BD_BUMNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BUMNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_MouseUp")
		Call Ctl_Item_MouseUp(BD_BUMNM(Index), Button, Shift, X, Y)
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
	
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("CM_EndCm_MouseUp")
		Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
	End Sub
	
	Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		Debug.Print("FM_Panel3D1_MouseUp")
		'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
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
	
	Private Sub HD_STKDLVDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STKDLVDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_STKDLVDT_MouseUp")
		Call Ctl_Item_MouseUp(HD_STKDLVDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DLVSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DLVSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DLVSU_MouseUp")
		Call Ctl_Item_MouseUp(HD_DLVSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_HIKSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_HIKSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_HIKSU_MouseUp")
		Call Ctl_Item_MouseUp(HD_HIKSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JOTAI_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JOTAI.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_JOTAI_MouseUp")
		Call Ctl_Item_MouseUp(HD_JOTAI, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_STKSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_STKSU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_STKSU_MouseUp")
		Call Ctl_Item_MouseUp(HD_STKSU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SZAISU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SZAISU.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SZAISU_MouseUp")
		Call Ctl_Item_MouseUp(HD_SZAISU, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_DENDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DENDT.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_DENDT_MouseUp")
		Call Ctl_Item_MouseUp(HD_DENDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SBNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SBNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SBNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKRN_MouseUp")
		Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_SOUNM_MouseUp")
		Call Ctl_Item_MouseUp(HD_SOUNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		Debug.Print("HD_TOKJDNNO_MouseUp")
		Call Ctl_Item_MouseUp(HD_TOKJDNNO, Button, Shift, X, Y)
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
	
	Private Sub BD_TRAKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRAKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_KeyDown")
		Call Ctl_Item_KeyDown(BD_TRAKB(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_TRANO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRANO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_KeyDown")
		Call Ctl_Item_KeyDown(BD_TRANO(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_TRADT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRADT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_KeyDown")
		Call Ctl_Item_KeyDown(BD_TRADT(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SYUSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SYUSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_SYUSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_HIKSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HIKSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_HIKSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_ATMNKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ATMNKB.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_KeyDown")
		Call Ctl_Item_KeyDown(BD_ATMNKB(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_NYUSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_KeyDown")
		Call Ctl_Item_KeyDown(BD_NYUSU(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyDown")
		Call Ctl_Item_KeyDown(BD_TOKRN(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_BUMNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BUMNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_KeyDown")
		Call Ctl_Item_KeyDown(BD_BUMNM(Index), KEYCODE, Shift)
	End Sub
	
	Private Sub BD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyDown")
		Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
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
	
	Private Sub HD_STKDLVDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STKDLVDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_STKDLVDT_KeyDown")
		Call Ctl_Item_KeyDown(HD_STKDLVDT, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_DLVSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DLVSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DLVSU_KeyDown")
		Call Ctl_Item_KeyDown(HD_DLVSU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_HIKSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HIKSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HIKSU_KeyDown")
		Call Ctl_Item_KeyDown(HD_HIKSU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_JOTAI_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JOTAI.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_JOTAI_KeyDown")
		Call Ctl_Item_KeyDown(HD_JOTAI, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_STKSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STKSU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_STKSU_KeyDown")
		Call Ctl_Item_KeyDown(HD_STKSU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_SZAISU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SZAISU.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SZAISU_KeyDown")
		Call Ctl_Item_KeyDown(HD_SZAISU, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_DENDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DENDT.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DENDT_KeyDown")
		Call Ctl_Item_KeyDown(HD_DENDT, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_SBNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKRN_KeyDown")
		Call Ctl_Item_KeyDown(HD_TOKRN, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUNM.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SOUNM_KeyDown")
		Call Ctl_Item_KeyDown(HD_SOUNM, KEYCODE, Shift)
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKJDNNO_KeyDown")
		Call Ctl_Item_KeyDown(HD_TOKJDNNO, KEYCODE, Shift)
	End Sub
	
	Private Sub TX_Message_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_Message.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_Message_KeyDown")
		Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
	End Sub
	
	Private Sub BD_TRAKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TRAKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_KeyPress")
		Call Ctl_Item_KeyPress(BD_TRAKB(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TRANO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TRANO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_KeyPress")
		Call Ctl_Item_KeyPress(BD_TRANO(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TRADT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TRADT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_KeyPress")
		Call Ctl_Item_KeyPress(BD_TRADT(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_SYUSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SYUSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_SYUSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
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
	
	Private Sub BD_ATMNKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_ATMNKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_KeyPress")
		Call Ctl_Item_KeyPress(BD_ATMNKB(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_NYUSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_NYUSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_KeyPress")
		Call Ctl_Item_KeyPress(BD_NYUSU(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_TOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TOKRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyPress")
		Call Ctl_Item_KeyPress(BD_TOKRN(Index), KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub BD_BUMNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BUMNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_KeyPress")
		Call Ctl_Item_KeyPress(BD_BUMNM(Index), KeyAscii)
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
	
	Private Sub HD_STKDLVDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STKDLVDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_STKDLVDT_KeyPress")
		Call Ctl_Item_KeyPress(HD_STKDLVDT, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_DLVSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DLVSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_DLVSU_KeyPress")
		Call Ctl_Item_KeyPress(HD_DLVSU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_HIKSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_HIKSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_HIKSU_KeyPress")
		Call Ctl_Item_KeyPress(HD_HIKSU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JOTAI_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JOTAI.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_JOTAI_KeyPress")
		Call Ctl_Item_KeyPress(HD_JOTAI, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_STKSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_STKSU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_STKSU_KeyPress")
		Call Ctl_Item_KeyPress(HD_STKSU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SZAISU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SZAISU.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_SZAISU_KeyPress")
		Call Ctl_Item_KeyPress(HD_SZAISU, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_DENDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DENDT.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_DENDT_KeyPress")
		Call Ctl_Item_KeyPress(HD_DENDT, KeyAscii)
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
	
	Private Sub HD_TOKRN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKRN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TOKRN_KeyPress")
		Call Ctl_Item_KeyPress(HD_TOKRN, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_SOUNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SOUNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_SOUNM_KeyPress")
		Call Ctl_Item_KeyPress(HD_SOUNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKJDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Debug.Print("HD_TOKJDNNO_KeyPress")
		Call Ctl_Item_KeyPress(HD_TOKJDNNO, KeyAscii)
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
	
	Private Sub BD_TRAKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRAKB.Enter
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_GotFocus")
		Call Ctl_Item_GotFocus(BD_TRAKB(Index))
	End Sub
	
	Private Sub BD_TRANO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRANO.Enter
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_GotFocus")
		Call Ctl_Item_GotFocus(BD_TRANO(Index))
	End Sub
	
	Private Sub BD_TRADT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRADT.Enter
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_GotFocus")
		Call Ctl_Item_GotFocus(BD_TRADT(Index))
	End Sub
	
	Private Sub BD_SYUSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SYUSU.Enter
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_SYUSU(Index))
	End Sub
	
	Private Sub BD_HIKSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.Enter
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_ATMNKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ATMNKB.Enter
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_GotFocus")
		Call Ctl_Item_GotFocus(BD_ATMNKB(Index))
	End Sub
	
	Private Sub BD_NYUSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUSU.Enter
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_GotFocus")
		Call Ctl_Item_GotFocus(BD_NYUSU(Index))
	End Sub
	
	Private Sub BD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.Enter
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_GotFocus")
		Call Ctl_Item_GotFocus(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_BUMNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BUMNM.Enter
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_GotFocus")
		Call Ctl_Item_GotFocus(BD_BUMNM(Index))
	End Sub
	
	Private Sub BD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Enter
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_GotFocus")
		Call Ctl_Item_GotFocus(BD_SOUNM(Index))
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
	
	Private Sub HD_STKDLVDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKDLVDT.Enter
		Debug.Print("HD_STKDLVDT_GotFocus")
		Call Ctl_Item_GotFocus(HD_STKDLVDT)
	End Sub
	
	Private Sub HD_DLVSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DLVSU.Enter
		Debug.Print("HD_DLVSU_GotFocus")
		Call Ctl_Item_GotFocus(HD_DLVSU)
	End Sub
	
	Private Sub HD_HIKSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HIKSU.Enter
		Debug.Print("HD_HIKSU_GotFocus")
		Call Ctl_Item_GotFocus(HD_HIKSU)
	End Sub
	
	Private Sub HD_JOTAI_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JOTAI.Enter
		Debug.Print("HD_JOTAI_GotFocus")
		Call Ctl_Item_GotFocus(HD_JOTAI)
	End Sub
	
	Private Sub HD_STKSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKSU.Enter
		Debug.Print("HD_STKSU_GotFocus")
		Call Ctl_Item_GotFocus(HD_STKSU)
	End Sub
	
	Private Sub HD_SZAISU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SZAISU.Enter
		Debug.Print("HD_SZAISU_GotFocus")
		Call Ctl_Item_GotFocus(HD_SZAISU)
	End Sub
	
	Private Sub HD_DENDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.Enter
		Debug.Print("HD_DENDT_GotFocus")
		Call Ctl_Item_GotFocus(HD_DENDT)
	End Sub
	
	Private Sub HD_SBNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Enter
		Debug.Print("HD_SBNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter
		Debug.Print("HD_TOKRN_GotFocus")
		Call Ctl_Item_GotFocus(HD_TOKRN)
	End Sub
	
	Private Sub HD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Enter
		Debug.Print("HD_SOUNM_GotFocus")
		Call Ctl_Item_GotFocus(HD_SOUNM)
	End Sub
	
	Private Sub HD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Enter
		Debug.Print("HD_TOKJDNNO_GotFocus")
		Call Ctl_Item_GotFocus(HD_TOKJDNNO)
	End Sub
	
	Private Sub TX_Message_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Enter
		Debug.Print("TX_Message_GotFocus")
		Call Ctl_Item_GotFocus(TX_Message)
	End Sub
	
	Private Sub BD_TRAKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRAKB.Leave
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_LostFocus")
		Call Ctl_Item_LostFocus(BD_TRAKB(Index))
	End Sub
	
	Private Sub BD_TRANO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRANO.Leave
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_LostFocus")
		Call Ctl_Item_LostFocus(BD_TRANO(Index))
	End Sub
	
	Private Sub BD_TRADT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRADT.Leave
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_LostFocus")
		Call Ctl_Item_LostFocus(BD_TRADT(Index))
	End Sub
	
	Private Sub BD_SYUSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SYUSU.Leave
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_SYUSU(Index))
	End Sub
	
	Private Sub BD_HIKSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.Leave
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_ATMNKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ATMNKB.Leave
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_LostFocus")
		Call Ctl_Item_LostFocus(BD_ATMNKB(Index))
	End Sub
	
	Private Sub BD_NYUSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUSU.Leave
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_LostFocus")
		Call Ctl_Item_LostFocus(BD_NYUSU(Index))
	End Sub
	
	Private Sub BD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.Leave
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_LostFocus")
		Call Ctl_Item_LostFocus(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_BUMNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BUMNM.Leave
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_LostFocus")
		Call Ctl_Item_LostFocus(BD_BUMNM(Index))
	End Sub
	
	Private Sub BD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.Leave
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_LostFocus")
		Call Ctl_Item_LostFocus(BD_SOUNM(Index))
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
	
	Private Sub HD_STKDLVDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKDLVDT.Leave
		Debug.Print("HD_STKDLVDT_LostFocus")
		Call Ctl_Item_LostFocus(HD_STKDLVDT)
	End Sub
	
	Private Sub HD_DLVSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DLVSU.Leave
		Debug.Print("HD_DLVSU_LostFocus")
		Call Ctl_Item_LostFocus(HD_DLVSU)
	End Sub
	
	Private Sub HD_HIKSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HIKSU.Leave
		Debug.Print("HD_HIKSU_LostFocus")
		Call Ctl_Item_LostFocus(HD_HIKSU)
	End Sub
	
	Private Sub HD_JOTAI_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JOTAI.Leave
		Debug.Print("HD_JOTAI_LostFocus")
		Call Ctl_Item_LostFocus(HD_JOTAI)
	End Sub
	
	Private Sub HD_STKSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKSU.Leave
		Debug.Print("HD_STKSU_LostFocus")
		Call Ctl_Item_LostFocus(HD_STKSU)
	End Sub
	
	Private Sub HD_SZAISU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SZAISU.Leave
		Debug.Print("HD_SZAISU_LostFocus")
		Call Ctl_Item_LostFocus(HD_SZAISU)
	End Sub
	
	Private Sub HD_DENDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.Leave
		Debug.Print("HD_DENDT_LostFocus")
		Call Ctl_Item_LostFocus(HD_DENDT)
	End Sub
	
	Private Sub HD_SBNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.Leave
		Debug.Print("HD_SBNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_SBNNO)
	End Sub
	
	Private Sub HD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Leave
		Debug.Print("HD_TOKRN_LostFocus")
		Call Ctl_Item_LostFocus(HD_TOKRN)
	End Sub
	
	Private Sub HD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Leave
		Debug.Print("HD_SOUNM_LostFocus")
		Call Ctl_Item_LostFocus(HD_SOUNM)
	End Sub
	
	Private Sub HD_TOKJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Leave
		Debug.Print("HD_TOKJDNNO_LostFocus")
		Call Ctl_Item_LostFocus(HD_TOKJDNNO)
	End Sub
	
	Private Sub TX_Message_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TX_Message.Leave
		Debug.Print("TX_Message_LostFocus")
		Call Ctl_Item_LostFocus(TX_Message)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_TRAKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_TRAKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRAKB.TextChanged
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_Change")
		Call Ctl_Item_Change(BD_TRAKB(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_TRANO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_TRANO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRANO.TextChanged
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_Change")
		Call Ctl_Item_Change(BD_TRANO(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_TRADT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_TRADT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TRADT.TextChanged
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_Change")
		Call Ctl_Item_Change(BD_TRADT(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_SYUSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_SYUSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SYUSU.TextChanged
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_Change")
		Call Ctl_Item_Change(BD_SYUSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_HIKSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_HIKSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HIKSU.TextChanged
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_Change")
		Call Ctl_Item_Change(BD_HIKSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_ATMNKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_ATMNKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ATMNKB.TextChanged
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_Change")
		Call Ctl_Item_Change(BD_ATMNKB(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_NYUSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_NYUSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUSU.TextChanged
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_Change")
		Call Ctl_Item_Change(BD_NYUSU(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_TOKRN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKRN.TextChanged
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_Change")
		Call Ctl_Item_Change(BD_TOKRN(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_BUMNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_BUMNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BUMNM.TextChanged
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_Change")
		Call Ctl_Item_Change(BD_BUMNM(Index))
	End Sub
	
	'UPGRADE_WARNING: �C�x���g BD_SOUNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub BD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SOUNM.TextChanged
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_Change")
		Call Ctl_Item_Change(BD_SOUNM(Index))
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
	
	'UPGRADE_WARNING: �C�x���g HD_STKDLVDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_STKDLVDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKDLVDT.TextChanged
		Debug.Print("HD_STKDLVDT_Change")
		Call Ctl_Item_Change(HD_STKDLVDT)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_DLVSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_DLVSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DLVSU.TextChanged
		Debug.Print("HD_DLVSU_Change")
		Call Ctl_Item_Change(HD_DLVSU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_HIKSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_HIKSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_HIKSU.TextChanged
		Debug.Print("HD_HIKSU_Change")
		Call Ctl_Item_Change(HD_HIKSU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_JOTAI.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_JOTAI_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JOTAI.TextChanged
		Debug.Print("HD_JOTAI_Change")
		Call Ctl_Item_Change(HD_JOTAI)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_STKSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_STKSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_STKSU.TextChanged
		Debug.Print("HD_STKSU_Change")
		Call Ctl_Item_Change(HD_STKSU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_SZAISU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_SZAISU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SZAISU.TextChanged
		Debug.Print("HD_SZAISU_Change")
		Call Ctl_Item_Change(HD_SZAISU)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_DENDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_DENDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DENDT.TextChanged
		Debug.Print("HD_DENDT_Change")
		Call Ctl_Item_Change(HD_DENDT)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_SBNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_SBNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SBNNO.TextChanged
		Debug.Print("HD_SBNNO_Change")
		Call Ctl_Item_Change(HD_SBNNO)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_TOKRN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.TextChanged
		Debug.Print("HD_TOKRN_Change")
		Call Ctl_Item_Change(HD_TOKRN)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_SOUNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.TextChanged
		Debug.Print("HD_SOUNM_Change")
		Call Ctl_Item_Change(HD_SOUNM)
	End Sub
	
	'UPGRADE_WARNING: �C�x���g HD_TOKJDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
	Private Sub HD_TOKJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.TextChanged
		Debug.Print("HD_TOKJDNNO_Change")
		Call Ctl_Item_Change(HD_TOKJDNNO)
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
	
	Private Sub BD_TRAKB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRAKB.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRAKB.GetIndex(eventSender)
		Debug.Print("BD_TRAKB_KeyUp")
		Call Ctl_Item_KeyUp(BD_TRAKB(Index))
	End Sub
	
	Private Sub BD_TRANO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRANO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRANO.GetIndex(eventSender)
		Debug.Print("BD_TRANO_KeyUp")
		Call Ctl_Item_KeyUp(BD_TRANO(Index))
	End Sub
	
	Private Sub BD_TRADT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TRADT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TRADT.GetIndex(eventSender)
		Debug.Print("BD_TRADT_KeyUp")
		Call Ctl_Item_KeyUp(BD_TRADT(Index))
	End Sub
	
	Private Sub BD_SYUSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SYUSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SYUSU.GetIndex(eventSender)
		Debug.Print("BD_SYUSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_SYUSU(Index))
	End Sub
	
	Private Sub BD_HIKSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HIKSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_HIKSU.GetIndex(eventSender)
		Debug.Print("BD_HIKSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_HIKSU(Index))
	End Sub
	
	Private Sub BD_ATMNKB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ATMNKB.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_ATMNKB.GetIndex(eventSender)
		Debug.Print("BD_ATMNKB_KeyUp")
		Call Ctl_Item_KeyUp(BD_ATMNKB(Index))
	End Sub
	
	Private Sub BD_NYUSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_NYUSU.GetIndex(eventSender)
		Debug.Print("BD_NYUSU_KeyUp")
		Call Ctl_Item_KeyUp(BD_NYUSU(Index))
	End Sub
	
	Private Sub BD_TOKRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKRN.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_TOKRN.GetIndex(eventSender)
		Debug.Print("BD_TOKRN_KeyUp")
		Call Ctl_Item_KeyUp(BD_TOKRN(Index))
	End Sub
	
	Private Sub BD_BUMNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BUMNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_BUMNM.GetIndex(eventSender)
		Debug.Print("BD_BUMNM_KeyUp")
		Call Ctl_Item_KeyUp(BD_BUMNM(Index))
	End Sub
	
	Private Sub BD_SOUNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SOUNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = BD_SOUNM.GetIndex(eventSender)
		Debug.Print("BD_SOUNM_KeyUp")
		Call Ctl_Item_KeyUp(BD_SOUNM(Index))
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
	
	Private Sub HD_STKDLVDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STKDLVDT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_STKDLVDT_KeyUp")
		Call Ctl_Item_KeyUp(HD_STKDLVDT)
	End Sub
	
	Private Sub HD_DLVSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DLVSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DLVSU_KeyUp")
		Call Ctl_Item_KeyUp(HD_DLVSU)
	End Sub
	
	Private Sub HD_HIKSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_HIKSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_HIKSU_KeyUp")
		Call Ctl_Item_KeyUp(HD_HIKSU)
	End Sub
	
	Private Sub HD_JOTAI_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JOTAI.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_JOTAI_KeyUp")
		Call Ctl_Item_KeyUp(HD_JOTAI)
	End Sub
	
	Private Sub HD_STKSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_STKSU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_STKSU_KeyUp")
		Call Ctl_Item_KeyUp(HD_STKSU)
	End Sub
	
	Private Sub HD_SZAISU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SZAISU.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SZAISU_KeyUp")
		Call Ctl_Item_KeyUp(HD_SZAISU)
	End Sub
	
	Private Sub HD_DENDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DENDT.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_DENDT_KeyUp")
		Call Ctl_Item_KeyUp(HD_DENDT)
	End Sub
	
	Private Sub HD_SBNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SBNNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SBNNO_KeyUp")
		Call Ctl_Item_KeyUp(HD_SBNNO)
	End Sub
	
	Private Sub HD_TOKRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKRN_KeyUp")
		Call Ctl_Item_KeyUp(HD_TOKRN)
	End Sub
	
	Private Sub HD_SOUNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUNM.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_SOUNM_KeyUp")
		Call Ctl_Item_KeyUp(HD_SOUNM)
	End Sub
	
	Private Sub HD_TOKJDNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyUp
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("HD_TOKJDNNO_KeyUp")
		Call Ctl_Item_KeyUp(HD_TOKJDNNO)
	End Sub
	' === 20060802 === INSERT E -
	
	' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�Ή�
	Private Sub TX_CursorRest_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TX_CursorRest.KeyDown
		Dim KEYCODE As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Debug.Print("TX_CursorRest_KeyDown")
		If KEYCODE >= System.Windows.Forms.Keys.F1 And KEYCODE <= System.Windows.Forms.Keys.F12 Then
			Call Ctl_Item_KeyDown(TX_CursorRest, KEYCODE, Shift)
		End If
	End Sub
    ' === 20060930 === INSERT E -
    Private Sub VS_Scrl_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VS_Scrl.Scroll
        Select Case eventArgs.type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                VS_Scrl_Change(eventArgs.newValue)
        End Select
    End Sub
    '20190703 ADD START
    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub
    '20190703 ADD END
End Class