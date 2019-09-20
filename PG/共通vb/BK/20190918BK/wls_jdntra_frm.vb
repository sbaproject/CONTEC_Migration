Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLS_JDN2
	Inherits System.Windows.Forms.Form
	
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
	'*  �v���O�������@�@�F�@�󒍏�񌟍�
	'*  �v���O�����h�c�@�F  WLS_JDN2
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)�Ð�
	'*  �쐬���@�@�@�@�@�F  2006.07.28
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   �\����
	'************************************************************************************
	Private Structure Type_DB_JDNTRA_W
		Dim DATKB As String
		Dim JDNNO As String '�󒍔ԍ�
		Dim LINNO As String '�s�ԍ�
		Dim DENDT As String '�󒍓��t
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim TOKRN As String '���Ӑ旪��
		Dim NHSCD As String '�[����R�[�h
		Dim NHSRN As String '�[���旪��
		Dim HINNMA As String '�`��
		Dim HINNMB As String '�i��
		Dim UDOSU As Short '����
		Dim JDNTRKBNM As String '�󒍎���敪��
		Dim JDNTRKB As String '�󒍎���敪
		Dim JDNDT As String '�󒍓`�[���t
		Dim KENNMA As String '�����P
		Dim KENNMB As String '�����Q
	End Structure
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	Private Const FM_PANEL3D1_CNT As Short = 2 '�p�l���R���g���[����
	Private Const pc_intCntListRow As Short = 15 '���׍s��
	
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	'=== ����ʂ̑S�����i�[ =================
	'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Main_Inf As Cls_All
	'=== ����ʂ̑S�����i�[ =================
	
	Private pv_DB_JDNTHA_W As Type_DB_JDNTRA_W
	
	'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Private Usr_Ody As U_Ody '�ް��ް����ð���
	Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
	Private pv_strInit_JDNTRKB As String '�󒍎���敪
	Private WM_WLS_MAX As Short '���X�g�s��
	Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
	Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
	Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
	Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
	Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)
	
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
		
		'�r���������������������������������������������������������r
		'��ʊ�b���ݒ�
		With Main_Inf.Dsp_Base
			.Dsp_Ctg = DSP_CTG_REFERENCE '��ʕ���

            '20190603 CHG START
            '.Item_Cnt = 15 '��ʍ��ڐ�
            .Item_Cnt = 15 '��ʍ��ڐ�
            '20190603 CHG END
            .Dsp_Body_Cnt = 0 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
			.Max_Body_Cnt = 0 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
			.Body_Col_Cnt = 0 '���ׂ̗񍀖ڐ�
			.Dsp_Body_Move_Qty = 0 '��ʈړ���
		End With
		'�d���������������������������������������������������������d
		
		'��ʍ��ڏ��
		ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)
		
		'�r���������������������������������������������������������r
		'/////////////////////
		'// �S��ʗp����p���۰�
		'/////////////////////
		
		Index_Wk = 0
		
		'///////////////////
		'// �w�b�_���ҏW
		'///////////////////
		'�󒍎���敪�{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_JDNTRKB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNTRKB
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�󒍎���敪
		HD_JDNTRKB.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'�󒍎���敪(����)
		HD_JDNTRKBNM.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKBNM
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�q�撍���ԍ�
		HD_JDNNO.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNNO
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(6)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'���Ӑ�(����)�{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_TOKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TOKCD
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'���Ӑ�(����)
		HD_TOKCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'�[����{�^��
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CS_JDNDT.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNDT
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
		
		Index_Wk = Index_Wk + 1
		'�[����R�[�h
		HD_NHTCD.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHTCD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 9
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'�����P
		HD_KENNMA.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
		
		Index_Wk = Index_Wk + 1
		'���X�g
		LST.Tag = Index_Wk
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = LST
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False


        Index_Wk = Index_Wk + 1
        'OK�{�^��
        '20190603 CHG START
        'WLSOK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
        btnF1.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '20190603 CHG END
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '20190603 ADD START
        Index_Wk = Index_Wk + 1

        '�����C���[�W
        btnF2.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF2
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '=== �Ұ�ސݒ� ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== �Ұ�ސݒ� ======================
        '20190603 ADD END

        Index_Wk = Index_Wk + 1
        '�O�y�[�W�C���[�W
        '20190603 CHG START
        'CM_PrevCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
        btnF7.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '20190603 CHG END
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== �Ұ�ސݒ� ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== �Ұ�ސݒ� ======================

        Index_Wk = Index_Wk + 1
        '���y�[�W�C���[�W
        '20190603 CHG START
        'CM_NextCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
        btnF8.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '20190603 CHG END
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '=== �Ұ�ސݒ� ======================
        Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NextCm(0)
        Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NextCm(1)
        '=== �Ұ�ސݒ� ======================

        '20190603 ADD START
        Index_Wk = Index_Wk + 1

        '�N���A�C���[�W
        btnF9.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
        '=== �Ұ�ސݒ� ======================
        Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
        Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
        '=== �Ұ�ސݒ� ======================
        '20190603 ADD END


        Index_Wk = Index_Wk + 1
        '�L�����Z���{�^��
        '20190603 CHG START
        'WLSCANCEL.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
        btnF12.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '20190603 CHG END
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
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
		Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True


        '��ʊ�b���ݒ�
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
		Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

        '///////////////////
        '// ���̑��ҏW
        '///////////////////
        '20190603 DEL START
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1
        '    'FM_Panel3D1
        '    'UPGRADE_WARNING: �I�u�W�F�N�g WLS_JDN2.FM_Panel3D1().Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Me.FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Me.FM_Panel3D1(Wk_Cnt)
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        'Next
        '20190603 DEL END
        '�d���������������������������������������������������������d

        '��L�ݒ���e�����ۂ̺��۰قɐݒ肷��
        Call CF_Init_Item_Property(Main_Inf)
		'��ʍ��ڏ����Đݒ�
		Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)
		
		'///////////////////
		'// ���ʍ��ڂ̍Đݒ�
		'///////////////////
		
		'�r���������������������������������������������������������r
		'���X�g�s���̐ݒ�
		WM_WLS_MAX = pc_intCntListRow
		
		'�Ԃ�l�̐ݒ�
		WLSJDN_RTNJDNNO = ""
		
		'�󒍎���敪�̏����l�ݒ�
		pv_strInit_JDNTRKB = Trim(WLSJDN_JDNTRKB)
		
		'�d���������������������������������������������������������d
		
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
		
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'KEYRIGHT����
		Call WLS_JDN2_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Select Case Me.ActiveControl.Name
					Case HD_KENNMA.Name
						'�ϐ��N���A
						Call WLS_Clear()
						'���X�g�ҏW
						Call F_Get_JDNTHA()
						Call WLS_DspNew()
					Case Else
				End Select
				'KEYRIGHT����(̫����ړ��Ȃ�)
				Call WLS_JDN2_0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'            '������ړ�����
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		'
		'    Dim Move_Flg        As Boolean
		'    Dim Rtn_Chk         As Integer
		'    Dim Chk_Move_Flg    As Boolean
		'    Dim Dsp_Mode        As Integer
		'
		'    Move_Flg = False
		'    Chk_Move_Flg = False
		'
		'    '�e���ڂ�����ٰ��
		'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
		'
		'    If Rtn_Chk = CHK_OK Then
		'    '�`�F�b�N�n�j��
		'        '�擾���e�\��
		'        Dsp_Mode = DSP_SET
		'    Else
		'    '�`�F�b�N�m�f��
		'        '�擾���e�N���A
		'        Dsp_Mode = DSP_CLR
		'    End If
		'    '�擾���e�\��/�N���A
		'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		'
		'    If Chk_Move_Flg = True Then
		'    '������ړ�����
		'        'KEYDOWN����
		'        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		'        If Move_Flg = True Then
		'        '���̍��ڂֈړ������ꍇ
		'            '������ړ�����
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'        Else
		'            '�I����Ԃ̐ݒ�i�����I���j
		'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'
		'            '���ڐF�ݒ�
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
		'        End If
		'    Else
		'        '������ړ��Ȃ�
		'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
		'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
		'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'    End If
		
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
		Call WLS_JDN2_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'KEYLEFT����(̫����ړ�����)
				Call WLS_JDN2_0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
				'            '������ړ�����
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'������ړ��Ȃ�
				Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
				'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
		
		'    Dim Move_Flg        As Boolean
		'    Dim Rtn_Chk         As Integer
		'    Dim Chk_Move_Flg    As Boolean
		'    Dim Dsp_Mode        As Integer
		'
		'    Move_Flg = False
		'    Chk_Move_Flg = True
		'
		'    '�e���ڂ�����ٰ��
		'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
		'
		'    If Rtn_Chk = CHK_OK Then
		'    '�`�F�b�N�n�j��
		'        '�擾���e�\��
		'        Dsp_Mode = DSP_SET
		'    Else
		'    '�`�F�b�N�m�f��
		'        '�擾���e�N���A
		'        Dsp_Mode = DSP_CLR
		'    End If
		'    '�擾���e�\��/�N���A
		'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		'
		'    If Chk_Move_Flg = True Then
		'    '������ړ�����
		'        'KEYUP����
		'        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
		'
		'        If Move_Flg = True Then
		'        '���̍��ڂֈړ������ꍇ
		'            '������ړ�����
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'        Else
		'            '�I����Ԃ̐ݒ�i�����I���j
		'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'
		'            '���ڐF�ݒ�
		'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
		'        End If
		'
		'    Else
		'    '������ړ��Ȃ�
		'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
		'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
		'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		'    End If
		
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
				Call WLS_JDN2_0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_LostFocus
	'   �T�v�F  �e���ڂ�LOSTFOCUS����
	'   �����F�@�Ȃ�
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		' === 20060902 === INSERT S - ACE)Nagasawa
		If gv_bolWLSJDN_LF_Enable = False Then
			Exit Function
		End If
		' === 20060902 === INSERT E -
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'����̫������۰َ擾
		'CHG START FKS)INABA 2007/12/15 ******************
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = Val(Me.ActiveControl.Tag)
		'    Act_Index = CInt(Me.ActiveControl.Tag)
		'CHG  END  FKS)INABA 2007/12/15 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_JDN2_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			'        '������ړ�����
			'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			
			'@'        '����̫������۰ق̑I�������Đݒ�
			'@'        '�I����Ԃ̐ݒ�
			'@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_DATE_SEL_KBN_DAY)
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
		Dim Move_Flg As Boolean
		Dim Wk_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'��ʒP�ʂ̏���(�����Ȃ�)
		'���ו��ł��ړ��O�����ו��łȂ��ꍇ
		If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
			'�r���������������������������������������������������������r
			'ͯ�ޕ�����
			'�d���������������������������������������������������������d
			If Rtn_Chk <> CHK_OK Then
				Exit Function
			End If
		End If

        ' === 20060801 === INSERT S - ACE)Nagasawa ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        If TypeOf pm_Ctl Is Button Then
            '������ʌďo�̏ꍇ�͏I��
            Exit Function
        End If

        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
			'���׍s�R���g���[��������
			If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
				'���׌����{�^���̖��׍s���ϐ��ɓ����s����ݒ�
				For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
					If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
						'�ݒ�ς݂̏ꍇ�͏I��
						Exit For
					End If
					Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
				Next 
			End If
		Else
			'���׌����{�^���̖��׍s���ϐ���������
			For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
				If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
					'�ݒ�ς݂̏ꍇ�͏I��
					Exit For
				End If
				Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
			Next 
		End If
		' === 20060801 === INSERT E
		
		'�r���������������������������������������������������������r
		Select Case Trg_Index
			Case Else
				'����̫����擾����
				Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		End Select
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KEYUP
	'   �T�v�F  �e���ڂ�KEYUP����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  �S��ʃ��[�J�����ʏ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_Item_KeyUp(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
		
		Dim Trg_Index As Short
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'�r���������������������������������������������������������r
		'�e������ʌďo
		'    Select Case Trg_Index
		'        Case CInt(HD_AKNID.Tag)
		'            '�Č�ID��÷�Ă�̫����ړ�
		
		'    End Select
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'����KEYPRESS����
		Call WLS_JDN2_0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)
		
		If Move_Flg = True Then
			'���̍��ڂֈړ������ꍇ
			'�e���ڂ�����ٰ��
			Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
			
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
			Call WLS_JDN2_0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
			
			If Chk_Move_Flg = True Then
				'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
				Select Case Me.ActiveControl.Name
					Case HD_KENNMA.Name
						'�ϐ��N���A
						Call WLS_Clear()
						'���X�g�ҏW
						Call F_Get_JDNTHA()
						Call WLS_DspNew()
					Case Else
				End Select
				
				'����̫����ʒu����E�ֈړ�
				Call WLS_JDN2_0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
				'            '������ړ�����
				'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			Else
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				
				'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
				'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
			End If
			
		Else
			'        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
			'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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
		Call WLS_JDN2_0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
				'�I����Ԃ̐ݒ�i�����I���j
				Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                '            '���ڐF�ݒ�
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

            Case TypeOf pm_Ctl Is Label
                '�p�l���̏ꍇ
                Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060801 === INSERT S - ACE)Nagasawa�@����W�{�^���Ή�
            Case TypeOf pm_Ctl Is Button
                '�{�^���̏ꍇ
                'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    Call WLS_JDN2_0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060801 === INSERT E

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
				'�C���[�W�̏ꍇ
				Select Case Trg_Index
					Case CShort(CM_PrevCm.Tag)
						'�O�ŲҰ��
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
					Case CShort(CM_NextCm.Tag)
						'���ŲҰ��
						Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
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
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		Select Case Trg_Index
			Case CShort(CM_PrevCm.Tag)
				'�O�ŲҰ��
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)
			Case CShort(CM_NextCm.Tag)
				'���ŲҰ��
				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)
		End Select
		
		'����MOUSEDOWN����
		Call WLS_JDN2_0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
		
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		'�������ޯ���擾
		Trg_Index = CShort(pm_Ctl.Tag)
		
		'��è�޺��۰ي������ޯ���擾
		'CHG START FKS)INABA 2007/12/15 ******************
		'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
		Act_Index = Val(Me.ActiveControl.Tag)
		'    Act_Index = CInt(Me.ActiveControl.Tag)
		'CHG  END  FKS)INABA 2007/12/15 ******************
		
		'�e������ʌďo
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Select Case Trg_Index
			Case CShort(CS_JDNTRKB.Tag)
				'���n�挟����ʌďo
				Call WLS_JDN2_0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_JDNDT.Tag)
				Call WLS_JDN2_0001.F_Ctl_CS_NHSCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				'            '���t������ʌďo
				'            Call WLS_JDN2_0001.F_Ctl_CS_JDNDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
				
			Case CShort(CS_TOKCD.Tag)
				'���Ӑ挟����ʌďo
				Call WLS_JDN2_0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                '20190603 CHG START
   '         Case CShort(CM_PrevCm.Tag)
            '	'�O��
            '	Call Ctl_CM_PrevCm_Click()

            'Case CShort(CM_NextCm.Tag)
            '	'����
            '	Call Ctl_CM_NextCm_Click()

            'Case CShort(WLSOK.Tag)
            '	'OK
            '	Call Ctl_WLSOK_Click()

            'Case CShort(WLSCANCEL.Tag)
            '    '�L�����Z��
            '    Call Ctl_WLSCANCEL_Click()

            Case CShort(btnF7.Tag)
                '�O��
                Call Ctl_CM_PrevCm_Click()

            Case CShort(btnF8.Tag)
                '����
                Call Ctl_CM_NextCm_Click()

            Case CShort(btnF1.Tag)
                'OK
                Call Ctl_WLSOK_Click()

            Case CShort(btnF12.Tag)
                '�L�����Z��
                Call Ctl_WLSCANCEL_Click()
                '20190603 CHG END

        End Select
		
	End Function

    Private Sub WLS_JDN2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        '��ʏ��ݒ�
        Call Init_Def_Dsp()

        '��ʓ��e������
        Call WLS_JDN2_0001.F_Init_Clr_Dsp(-1, Main_Inf)

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʕ\���ʒu�ݒ�
        Call CF_Set_Frm_Location(Me)

    End Sub

    '20190603 ADD START
    Private Sub WLS_JDN2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub

    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_JDNTRKB.Focused Then
                Call HD_JDNTRKB_KeyDown(HD_JDNTRKB, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_JDNTRKBNM.Focused Then
                Call HD_JDNTRKBNM_KeyDown(HD_JDNTRKBNM, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_JDNNO.Focused Then
                Call HD_JDNNO_KeyDown(HD_JDNNO, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_TOKCD.Focused Then
                Call HD_TOKCD_KeyDown(HD_TOKCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_NHTCD.Focused Then
                Call HD_NHTCD_KeyDown(HD_NHTCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_KENNMA.Focused Then
                Call HD_KENNMA_KeyDown(HD_KENNMA, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_JDNTRKB_KeyDown(HD_TANCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            LST.Items.Clear()
            Me.HD_JDNTRKB.Text = ""
            Me.HD_JDNTRKBNM.Text = ""
            Me.HD_JDNNO.Text = ""
            Me.HD_TOKCD.Text = ""
            Me.HD_NHTCD.Text = ""
            Me.HD_KENNMA.Text = ""

            Me.HD_JDNTRKB.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190603 ADD END

    Private Sub WLS_JDN2_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Me.Close()
		
	End Sub

    '20190603 DEL START
    '   'UPGRADE_WARNING: �C�x���g HD_JDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    '   Private Sub HD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.TextChanged
    '	'Debug.Print Me.NAME & ".HD_JDNNO_Change"
    '	Call Ctl_Item_Change(HD_JDNNO)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Enter
		'Debug.Print Me.NAME & ".HD_JDNNO_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNNO)
	End Sub
	
	Private Sub HD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNNO_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNNO, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNNO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNNO_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNNO, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Leave
		'Debug.Print Me.NAME & ".HD_JDNNO_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNNO)
	End Sub
	
	Private Sub HD_JDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNNO_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNNO, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNNO_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNNO, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    ''UPGRADE_WARNING: �C�x���g HD_JDNTRKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged
    '    'Debug.Print Me.NAME & ".HD_JDNTRKB_Change"
    '    Call Ctl_Item_Change(HD_JDNTRKB)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter
		'Debug.Print Me.NAME & ".HD_JDNTRKB_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNTRKB_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave
		'Debug.Print Me.NAME & ".HD_JDNTRKB_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNTRKB)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKB_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    ''UPGRADE_WARNING: �C�x���g HD_JDNTRKBNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_JDNTRKBNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.TextChanged
    '    'Debug.Print Me.NAME & ".HD_JDNTRKBNM_Change"
    '    Call Ctl_Item_Change(HD_JDNTRKBNM)
    'End Sub
    '20190603 DEL END

    Private Sub HD_JDNTRKBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.Enter
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_GotFocus"
		Call Ctl_Item_GotFocus(HD_JDNTRKBNM)
	End Sub
	
	Private Sub HD_JDNTRKBNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKBNM.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyDown"
		Call Ctl_Item_KeyDown(HD_JDNTRKBNM, KeyCode, Shift)
	End Sub
	
	Private Sub HD_JDNTRKBNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKBNM.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_KeyPress"
		Call Ctl_Item_KeyPress(HD_JDNTRKBNM, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_JDNTRKBNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKBNM.Leave
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_LostFocus"
		Call Ctl_Item_LostFocus(HD_JDNTRKBNM)
	End Sub
	
	Private Sub HD_JDNTRKBNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKBNM.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseDown"
		Call Ctl_Item_MouseDown(HD_JDNTRKBNM, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_JDNTRKBNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKBNM.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_JDNTRKBNM_MouseUp"
		Call Ctl_Item_MouseUp(HD_JDNTRKBNM, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: �C�x���g HD_NHTCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_NHTCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.TextChanged
    '    'Debug.Print Me.NAME & ".HD_NHTCD_Change"
    '    Call Ctl_Item_Change(HD_NHTCD)
    'End Sub
    '20190603 DEL END

    Private Sub HD_NHTCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.Enter
		'Debug.Print Me.NAME & ".HD_NHTCD_GotFocus"
		Call Ctl_Item_GotFocus(HD_NHTCD)
	End Sub
	
	Private Sub HD_NHTCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHTCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_NHTCD_KeyDown"
		Call Ctl_Item_KeyDown(HD_NHTCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_NHTCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHTCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_NHTCD_KeyPress"
		Call Ctl_Item_KeyPress(HD_NHTCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_NHTCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHTCD.Leave
		'Debug.Print Me.NAME & ".HD_NHTCD_LostFocus"
		Call Ctl_Item_LostFocus(HD_NHTCD)
	End Sub
	
	Private Sub HD_NHTCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHTCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_NHTCD_MouseDown"
		Call Ctl_Item_MouseDown(HD_NHTCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_NHTCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHTCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_NHTCD_MouseUp"
		Call Ctl_Item_MouseUp(HD_NHTCD, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: �C�x���g HD_TOKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
    '    'Debug.Print Me.NAME & ".HD_TOKCD_Change"
    '    Call Ctl_Item_Change(HD_TOKCD)
    'End Sub
    '20190603 DEL END

    Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
		'Debug.Print Me.NAME & ".HD_TOKCD_GotFocus"
		Call Ctl_Item_GotFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_TOKCD_KeyDown"
		Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
	End Sub
	
	Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_TOKCD_KeyPress"
		Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
		'Debug.Print Me.NAME & ".HD_TOKCD_LostFocus"
		Call Ctl_Item_LostFocus(HD_TOKCD)
	End Sub
	
	Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_TOKCD_MouseDown"
		Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_TOKCD_MouseUp"
		Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
	End Sub

    '20190603 DEL START
    'UPGRADE_WARNING: �C�x���g HD_KENNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    'Private Sub HD_KENNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.TextChanged
    '    'Debug.Print Me.NAME & ".HD_KENNMA_Change"
    '    Call Ctl_Item_Change(HD_KENNMA)
    'End Sub
    '20190603 DEL START

    Private Sub HD_KENNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Enter
		'Debug.Print Me.NAME & ".HD_KENNMA_GotFocus"
		Call Ctl_Item_GotFocus(HD_KENNMA)
	End Sub
	
	Private Sub HD_KENNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMA.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print Me.NAME & ".HD_KENNMA_KeyDown"
		Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
	End Sub
	
	Private Sub HD_KENNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KENNMA.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'Debug.Print Me.NAME & ".HD_KENNMA_KeyPress"
		Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub HD_KENNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Leave
		'Debug.Print Me.NAME & ".HD_KENNMA_LostFocus"
		Call Ctl_Item_LostFocus(HD_KENNMA)
	End Sub
	
	Private Sub HD_KENNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_KENNMA_MouseDown"
		Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub HD_KENNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'Debug.Print Me.NAME & ".HD_KENNMA_MouseUp"
		Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
	End Sub
	
	Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick
		'Debug.Print "LST_KeyDown"
		Call Ctl_Item_KeyDown(LST, System.Windows.Forms.Keys.Return, 0)
	End Sub
	
	Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'Debug.Print "LST_KeyDown"
		Select Case KeyCode
			'Enter�L�[����
			Case System.Windows.Forms.Keys.Return
				Call Ctl_Item_KeyDown(LST, KeyCode, Shift)
				
				'Escape�L�[����
			Case System.Windows.Forms.Keys.Escape
                '20190603 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190603 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190603 CHG START
                'Call CM_PrevCm_Click(CM_PrevCm, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190603 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190603 CHG START
                'Call CM_NextCm_Click(CM_NextCm, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190603 CHG END

                If LST.Items.Count > 0 Then
					LST.SelectedIndex = -1
				End If
		End Select
		
	End Sub

    '20190604 ADD START
    Private Sub CS_JDNTRKB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNTRKB.Click
        Call Ctl_Item_Click(CS_JDNTRKB)
    End Sub

    Private Sub CS_TOKCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_TOKCD.Click
        Call Ctl_Item_Click(CS_TOKCD)
    End Sub

    Private Sub CS_JDNDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_JDNDT.Click
        Call Ctl_Item_Click(CS_JDNDT)
    End Sub
    '20190604 ADD END

    Private Sub CS_JDNTRKB_Click()
		'Debug.Print Me.NAME & ".CS_JDNTRKB_Click"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_Click(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_GotFocus()
		'Debug.Print Me.NAME & ".CS_JDNTRKB_GotFocus"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_GotFocus(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_JDNTRKB_KeyUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_KeyUp(CS_JDNTRKB)
	End Sub
	
	Private Sub CS_JDNTRKB_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_JDNTRKB_MouseUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_JDNDT_Click()
		'Debug.Print Me.NAME & ".CS_JDNDT_Click"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_Click(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_GotFocus()
		'Debug.Print Me.NAME & ".CS_JDNDT_GotFocus"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_GotFocus(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_JDNDT_KeyUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_KeyUp(CS_JDNDT)
	End Sub
	
	Private Sub CS_JDNDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_JDNDT_MouseUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(CS_JDNDT, Button, Shift, X, Y)
	End Sub
	
	Private Sub CS_TOKCD_Click()
		'Debug.Print Me.NAME & ".CS_TOKCD_Click"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_Click(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_GotFocus()
		'Debug.Print Me.NAME & ".CS_TOKCD_GotFocus"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_GotFocus(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
		'Debug.Print Me.NAME & ".CS_TOKCD_KeyUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_KeyUp(CS_TOKCD)
	End Sub
	
	Private Sub CS_TOKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'Debug.Print Me.NAME & ".CS_TOKCD_MouseUp"
		'UPGRADE_WARNING: �I�u�W�F�N�g CS_TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
	End Sub

    '20190603 CHG START
    '   Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click
    '	'Debug.Print "WLSCANCEL_Click"
    '	Call Ctl_Item_Click(WLSCANCEL)
    'End Sub

    '   Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click
    '       'Debug.Print "WLSOK_Click"
    '       Call Ctl_Item_Click(WLSOK)
    '   End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click
        Debug.Print("btnF12_Click")
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click
        Debug.Print("btnF1_Click")
        Call Ctl_Item_Click(btnF1)
    End Sub
    '20190603 CHG END

    '20190603 CHG START
    '   Private Sub CM_NextCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_NextCm.Click
    '	'Debug.Print "CM_NextCm_Click"
    '	Call Ctl_Item_Click(CM_NextCm)
    'End Sub

    '   Private Sub CM_PrevCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_PrevCm.Click
    '       'Debug.Print "CM_PrevCm_Click"
    '       Call Ctl_Item_Click(CM_PrevCm)
    '   End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click
        Debug.Print("btnF8_Click")
        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        Debug.Print("btnF7_Click")
        Call Ctl_Item_Click(btnF7)
    End Sub
    '20190603 CHG END

    '20190603 DEL START
    '   Private Sub CM_NextCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_NextCm_MouseDown"
    '	Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_PrevCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_PrevCm_MouseDown"
    '	Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_NextCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_NextCm.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	'Debug.Print "CM_NextCm_MouseUp"
    '	Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
    'End Sub

    '   Private Sub CM_PrevCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_PrevCm.MouseUp
    '       Dim Button As Short = eventArgs.Button \ &H100000
    '       Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '       Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '       Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '       'Debug.Print "CM_PrevCm_MouseUp"
    '       Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
    '   End Sub
    '20190603 DEL END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_PrevCm_Click
    '   �T�v�F  �O�y�[�W
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CM_PrevCm_Click() As Short
		If WM_WLS_Pagecnt > 0 Then
			WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
			Call WLS_DspPage()
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_CM_NextCm_Click
	'   �T�v�F  ���y�[�W
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_CM_NextCm_Click() As Short
		
		If LST.Items.Count <= 0 Then Exit Function
		
		If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
			'���ׂĂ̎擾�f�[�^��ޔ����Ă��Ȃ��ꍇ�͑ޔ��������s
			If Not WM_WLS_LastFL Then Call WLS_DspNew()
		Else
			'�ޔ����Ă���ꍇ�̓y�[�W���A�b�v
			WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
			Call WLS_DspPage()
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Edi_Dsp_Def
	'   �T�v�F  �������̉�ʕҏW
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Edi_Dsp_Def() As Short
		Dim Index_Wk As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'�r���������������������������������������������������������r
		'WLS_JDN2_0001.F_Init_Clr_Dsp �ŏ��������������s�ς�
		'�d���������������������������������������������������������d
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_WLSOK_Click
	'   �T�v�F  OK�{�^��������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_WLSOK_Click() As Short
		
		'�߂�l��ݒ�
		WLSJDN_RTNJDNNO = MidWid(VB6.GetItemString(LST, LST.SelectedIndex), 1, 8)
		
		Call Ctl_WLSCANCEL_Click()
		
		'�r���������������������������������������������������������r
		'�d���������������������������������������������������������d
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_WLSCANCEL_Click
	'   �T�v�F  �L�����Z���{�^��������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_WLSCANCEL_Click() As Short
		
		'��ʂ�\������Ƃ��ɖ߂�l�ϐ��͏���������Ă���
		If Dyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			Dyn_Open = False
		End If
		Hide()
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
		'ADD START FKS)INABA 2006/11/21 ******************
		If Me.ActiveControl Is Nothing Then
			Exit Function
		End If
		'ADD  END  FKS)INABA 2006/11/21 ******************
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'�e���ڂ�����ٰ��
		Rtn_Chk = WLS_JDN2_0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)
		
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
		Call WLS_JDN2_0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
		
		If Chk_Move_Flg = True Then
			
			'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Select Case Me.ActiveControl.Name
				Case HD_JDNNO.Name, HD_JDNTRKB.Name, HD_NHTCD.Name, HD_TOKCD.Name, HD_KENNMA.Name
					'�ϐ��N���A
					Call WLS_Clear()
					'���X�g�ҏW
					Call F_Get_JDNTHA()
					Call WLS_DspNew()
					
					'̫����ړ�
					Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)

                    '20190603 ADD START
                Case btnF2.Name
                    '�ϐ��N���A
                    Call WLS_Clear()
                    '���X�g�ҏW
                    Call F_Get_JDNTHA()
                    Call WLS_DspNew()

                    '̫����ړ�
                    Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(CInt(LST.Tag)), Main_Inf)
                    '20190603 ADD END

                Case LST.Name
					Call Ctl_WLSOK_Click()
					
				Case Else
			End Select
		Else
			'������ړ��Ȃ�
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
			'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
			'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_Clear
	'   �T�v�F  �ϐ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub WLS_Clear()
		'��ʕ\���y�[�W
		WM_WLS_Pagecnt = -1
		WM_WLS_LastPage = -1
		WM_WLS_LastFL = False
		
		'�������ʕێ��z��
		ReDim WM_WLS_DSPArray(0)
		
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
		Dim strWORK As String
		
		Cnt = 0
        Debug.Print(VB6.Format(Now, "hh:mi:ss"))

        '20190603 CHG START
        '        Do Until CF_Ora_EOF(Usr_Ody) = True

        '			'�擾���e�ޔ�
        '			With pv_DB_JDNTHA_W
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.DATKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_DATKB", " ") '
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_JDNNO", " ") '�󒍔ԍ�
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.LINNO = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_LINNO", " ") '�s�ԍ�
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_JDNDT", " ") '�󒍓`�[���t
        '				.JDNDT = VB6.Format(strWORK, "@@@@/@@/@@")
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKMTA_TOKCD", " ") '���Ӑ�R�[�h
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKMTA_TOKRN", " ") '���Ӑ旪��
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSMTA_NHSCD", " ") '�[����R�[�h
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSMTA_NHSRN", " ") '�[���旪��
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.HINNMA = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_HINNMA", " ") '�i��
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.HINNMB = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_HINNMB", " ") '�i��
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.UDOSU = CF_Ora_GetDyn(Usr_Ody, "JDNTRA_UODSU", 0) '����
        '				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				.JDNTRKBNM = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNTRKB", " ") '�󒍎���敪

        '				''            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_JDNTRKB", "")            '�󒍎���敪
        '				''            strWORK = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_DENDT", "")               '�󒍓��t
        '				''            .DENDT = Format(strWORK, "@@@@/@@/@@")
        '				''            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMA", "")              '�����P
        '				''            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "JDNTHA_KENNMB", "")              '�����Q
        '			End With

        '			If pv_DB_JDNTHA_W.DATKB <> "1" Then GoTo WLS_DspNew_skip

        '			'�\�����y�[�W
        '			If Cnt Mod WM_WLS_MAX = 0 Then
        '				'�E�B���h�\���y�[�W�J�E���^���J�E���g�A�b�v
        '				WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '				'�E�B���h�\���f�[�^�̈�����X�g�s�����쐬
        '				ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '				Cnt = 0
        '				'�ŏI�y�[�W�ޔ�
        '				WM_WLS_LastPage = WM_WLS_Pagecnt
        '			End If

        '			'�\���������W�J
        '			Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '			Cnt = Cnt + 1

        'WLS_DspNew_skip: 
        '			Call CF_Ora_MoveNext(Usr_Ody)

        '			If Cnt >= WM_WLS_MAX Then
        '				Exit Do
        '			End If

        '		Loop

        '        '�ŏI�f�[�^���B
        '        If CF_Ora_EOF(Usr_Ody) = True Then
        '            WM_WLS_LastFL = True
        '        End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1

            '�擾���e�ޔ�
            With pv_DB_JDNTHA_W
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_DATKB"), " ") '
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_JDNNO"), " ") '�󒍔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .LINNO = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_LINNO"), " ") '�s�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                strWORK = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_JDNDT"), " ") '�󒍓`�[���t
                .JDNDT = VB6.Format(strWORK, "@@@@/@@/@@")
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKMTA_TOKCD"), " ") '���Ӑ�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TOKMTA_TOKRN"), " ") '���Ӑ旪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSMTA_NHSCD"), " ") '�[����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSRN = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("NHSMTA_NHSRN"), " ") '�[���旪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMA = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_HINNMA"), " ") '�i��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMB = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_HINNMB"), " ") '�i��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UDOSU = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTRA_UODSU"), 0) '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNTRKBNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("JDNTHA_JDNTRKB"), " ") '�󒍎���敪

            End With

            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                '�E�B���h�\���y�[�W�J�E���^���J�E���g�A�b�v
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                '�E�B���h�\���f�[�^�̈�����X�g�s�����쐬
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = WM_WLS_Pagecnt
            End If

            '�\���������W�J
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

            Cnt = Cnt + 1

        Next

        '�ŏI�f�[�^���B
        WM_WLS_LastFL = True
        '20190603 CHG END

        If Cnt > 0 Then
            '�y�[�W��\��
            '20190603 ADD START
            WM_WLS_Pagecnt = 0
            '20190603 ADD END
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
		Dim intCnt As Short
		
		LST.Items.Clear()
		
		'�\���f�[�^�L���`�F�b�N
		If UBound(WM_WLS_DSPArray) <= 0 Then
			Exit Sub
		End If
		
		intCnt = 0
		'���׍s�������[�v
		Do While intCnt < WM_WLS_MAX
			'WM_WLS_Pagecnt = �y�[�W�� - 1 ���ݒ肳��Ă���
			If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
				LST.Items.Add(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt))
			End If
			intCnt = intCnt + 1
		Loop 
		If LST.Items.Count > 0 Then
			LST.SelectedIndex = 0
			'ADD START FKS)INABA 2007/01/11**********
			On Error Resume Next
			'ADD  END  FKS)INABA 2007/01/11**********
			LST.Focus()
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub WLS_SetArray
	'   �T�v�F  ���X�g�ҏW
	'   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub WLS_SetArray(ByVal ArrayCnt As Short)
		Const pad As String = "�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@"
		
		With pv_DB_JDNTHA_W
			'        WM_WLS_DSPArray(ArrayCnt) = LeftWid2$(Trim(.JDNNO) & RightWid$(.LINNO, 2), 8) & " " & _
			''                                    LeftWid2$(.JDNDT, 10) & " " & _
			''                                    LeftWid2$(.TOKCD, 5) & " " & _
			''                                    LeftWid2$(.TOKRN & Space(20), 20) & " " & _
			''                                    LeftWid2$(.NHSCD, 9) & " " & _
			''                                    LeftWid2$(.NHSRN & Space(20), 20) & " " & _
			''                                    LeftWid2$(.HINNMA & Space(20), 20) & " " & _
			''                                    LeftWid2$(.HINNMB & Space(20), 20) & " " & _
			''                                    String(7 - Len(Format$(.UDOSU, "###,##0")), " ") + Format$(.UDOSU, "###,##0") & " " & _
			''                                    LeftWid2$(.JDNTRKBNM, 2)
			
			WM_WLS_DSPArray(ArrayCnt) = LeftWid(Trim(.JDNNO) & RightWid(.LINNO, 2), 8) & " " & LeftWid(.JDNDT & Space(10), 10) & " " & LeftWid(.TOKCD & Space(5), 5) & " " & LeftWid(.TOKRN & pad, 20) & " " & LeftWid(.NHSCD & Space(9), 9) & " " & LeftWid(.NHSRN & Space(20), 20) & " " & LeftWid(.HINNMA & Space(20), 20) & " " & LeftWid(.HINNMB & Space(20), 20) & " " & New String(" ", 7 - Len(VB6.Format(.UDOSU, "###,##0"))) & VB6.Format(.UDOSU, "###,##0") & " " & LeftWid(.JDNTRKBNM, 2)
			
		End With
		
	End Sub
	
	Private Function F_Get_JDNTHA() As Short
		
		Dim intRet As Short
		Dim strSQL As String
		Dim strTANCD As String
		Dim strJdnNo As String
		Dim strJDNTRKB As String
		Dim strJDNDT As String
		Dim strTOKCD As String
		Dim strKENNMA As String
		
		On Error GoTo F_Get_JDNTHA_Err
		
		intRet = 99
		
		'�q�撍���ԍ�����ʂ���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJdnNo = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNNO.Tag)))
		
		'�󒍎���敪����ʂ���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJDNTRKB = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_JDNTRKB.Tag)))
		
		'�[����R�[�h����ʂ���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strJDNDT = CF_Ora_Date(CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_NHTCD.Tag))))
		
		'���Ӑ�R�[�h����ʂ���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strTOKCD = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_TOKCD.Tag)))
		
		'�J�n�󒍔ԍ�����ʂ���擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strKENNMA = CF_Get_Item_Value(Main_Inf.Dsp_Sub_Inf(CInt(HD_KENNMA.Tag)))
		
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "  JDNTRA.DATKB   AS JDNTRA_DATKB" '
		strSQL = strSQL & ", JDNTRA.JDNNO   AS JDNTRA_JDNNO" '�󒍔ԍ�
		strSQL = strSQL & ", JDNTRA.LINNO   AS JDNTRA_LINNO" '�s�ԍ�
		strSQL = strSQL & ", JDNTRA.JDNDT   AS JDNTRA_JDNDT" '�󒍓`�[���t
		strSQL = strSQL & ", JDNTRA.DENDT   AS JDNTRA_DENDT" '�󒍓��t
		strSQL = strSQL & ", JDNTHA.JDNTRKB AS JDNTHA_JDNTRKB" '�󒍎���敪
		strSQL = strSQL & ", JDNTRA.TOKCD   AS TOKMTA_TOKCD" '���Ӑ�R�[�h
		strSQL = strSQL & ", TOKMTA.TOKRN   AS TOKMTA_TOKRN" '���Ӑ旪��
		strSQL = strSQL & ", JDNTRA.NHSCD   AS NHSMTA_NHSCD" '�[����R�[�h
		'CHG START FKS)INABA 2006/11/16 ***********************************************
		strSQL = strSQL & ", NVL(NHSMTA.NHSRN,'                                        ')   AS NHSMTA_NHSRN" '�[���旪��
		'    strSQL = strSQL & ", NHSMTA.NHSRN   AS NHSMTA_NHSRN"        '�[���旪��
		'CHG  END  FKS)INABA 2006/11/16 ***********************************************
		strSQL = strSQL & ", JDNTRA.HINNMA  AS JDNTRA_HINNMA" '�^��
		strSQL = strSQL & ", JDNTRA.HINNMB  AS JDNTRA_HINNMB" '�i��
		strSQL = strSQL & ", JDNTRA.UODSU   AS JDNTRA_UODSU" '����
		strSQL = strSQL & ", JDNTHA.JDNTRKB AS JDNTHA_JDNTRKB" '�󒍎���敪
		strSQL = strSQL & ", MEIMTA.MEINMA  AS MEIMTA_JDNTRKBNM" '�󒍎���敪����
		strSQL = strSQL & " FROM JDNTHA"
		strSQL = strSQL & ",     JDNTRA"
		strSQL = strSQL & ",     TOKMTA"
		strSQL = strSQL & ",     MEIMTA"
		strSQL = strSQL & ",     NHSMTA"
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "       JDNTHA.DATKB     = '" & gc_strDATKB_USE & "'"
		'�󒍎���敪
		If Trim(strJDNTRKB) <> "" Then
			strSQL = strSQL & " AND JDNTHA.JDNTRKB = '" & CF_Ora_String(strJDNTRKB, 2) & "'"
		End If
		strSQL = strSQL & " AND   JDNTRA.JDNNO     = JDNTHA.JDNNO "
		strSQL = strSQL & " AND   JDNTRA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND  (JDNTRA.JDNKB = '1' or JDNTRA.JDNKB = '2')"
		strSQL = strSQL & " AND   MEIMTA.MEICDA    = JDNTHA.JDNTRKB "
		strSQL = strSQL & " AND   MEIMTA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND   MEIMTA.KEYCD     = '" & gc_strKEYCD_JDNTRKB & "'"
		strSQL = strSQL & " AND   TOKMTA.DATKB     = '" & gc_strDATKB_USE & "'"
		strSQL = strSQL & " AND   TOKMTA.TOKCD     = JDNTHA.TOKCD "
		'ADD START FKS)INABA 2008/08/18***************************************************************
		strSQL = strSQL & " AND   JDNTHA.DATNO IN (SELECT MAX(DATNO) FROM JDNTHA GROUP BY JDNNO ) "
		'ADD  END  FKS)INABA 2008/08/18***************************************************************
		strSQL = strSQL & " "
		'CHG START FKS)INABA 2006/11/16 **************************************************************
		strSQL = strSQL & " AND   NHSMTA.NHSCD(+)     = JDNTHA.NHSCD "
		'    strSQL = strSQL & " AND   NHSMTA.NHSCD     = JDNTHA.NHSCD "
		'CHG  END  FKS)INABA 2006/11/16 **************************************************************
		
		'�q�撍���ԍ�
		If Trim(strJdnNo) <> "" Then
			strSQL = strSQL & " AND JDNTRA.JDNNO  >= '" & CF_Ora_String(strJdnNo, 10) & "'"
		End If
		
		'�[����R�[�h
		If Trim(strJDNDT) <> "" Then
			strSQL = strSQL & " AND JDNTRA.JDNDT  >= '" & CF_Ora_String(strJDNDT, 8) & "'"
		End If
		
		'���Ӑ�R�[�h
		If Trim(strTOKCD) <> "" Then
			strSQL = strSQL & " AND JDNTRA.TOKCD   = '" & CF_Ora_String(strTOKCD, 10) & "'"
		End If
		
		'�J�n��No
		If Trim(strKENNMA) <> "" Then
			'CHG START FKS)INABA 2006/11/16 *******************************************************************
			strSQL = strSQL & " AND JDNTRA.JDNNO >= '" & Trim(strKENNMA) & "'"
			'        strSQL = strSQL & " AND JDNTRA.KENNMA || JDNTHA.KENNMB LIKE '%" & Trim(strKENNMA) & "%'"
			'CHG  END  FKS)INABA 2006/11/16 *******************************************************************
		End If
		
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "  JDNTRA_JDNNO"
		
		If Dyn_Open = True Then
            '�I�[�v�����Ă�����N���[�Y
            '20190603 DEL START
            'Call CF_Ora_CloseDyn(Usr_Ody)
            '20190603 DEL END
            Dyn_Open = False
		End If

        'DB�A�N�Z�X
        '20190603 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190603 CHG END
        Dyn_Open = True

        '20190603 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190603 CHG END
            LST.Items.Clear()
        End If

        intRet = 0
		
F_Get_JDNTHA_End: 
		
		F_Get_JDNTHA = intRet
		Exit Function
		
F_Get_JDNTHA_Err: 
		
		intRet = 99
		GoTo F_Get_JDNTHA_End
		
	End Function
	
	Private Function LeftWid2(ByVal pm_Characters As String, ByVal pm_Wid As Integer) As String
		
		Dim lngMoji As Integer
		Dim lngKeta As Integer
		
		lngMoji = 0
		lngKeta = 0
		LeftWid2 = ""
		
		If AnsiLenB(pm_Characters) <= pm_Wid Then
			LeftWid2 = pm_Characters & Space(pm_Wid - AnsiLenB(pm_Characters))
			Exit Function
		End If
		
		If AnsiLenB(pm_Characters) > pm_Wid Then
			
			Do Until lngKeta >= pm_Wid
				lngMoji = lngMoji + 1
                'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
                'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
                'lngKeta = lngKeta + LenB(StrConv(Mid(pm_Characters, lngMoji, 1), vbFromUnicode))
                lngKeta = lngKeta + LenB(Mid(pm_Characters, lngMoji, 1))
            Loop 
			
			If lngKeta > pm_Wid Then
				LeftWid2 = VB.Left(pm_Characters, lngMoji - 1) & Space(1)
			Else
				LeftWid2 = VB.Left(pm_Characters, lngMoji)
			End If
		End If
		
	End Function
	
	
	Private Function AnsiLenB(ByVal StrArg As String) As Integer
        '�T�v�F����������
        '�����FStrArg,Input,String,�Ώە�����
        '�����FAnsi���ނ��޲ĵ��ނŕ�������޲Đ���Ԃ�
#If Win32 Then
        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiLenB = LenB(StrArg)
#End If
    End Function
	
	' StrConv ���Ăяo���܂��B
	Private Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g flag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g StrArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = StrArg
#End If
		
	End Function
End Class