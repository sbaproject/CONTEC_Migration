Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
'2019/04/05 ADD START
Imports Oracle.DataAccess.Client
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.

    '���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
    '=== ����ʂ̑S�����i�[ =================
    'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    Private Main_Inf As Cls_All
    '=== ����ʂ̑S�����i�[ =================
    Private Const FM_Panel3D1_CNT As Short = 18 '�p�l���R���g���[����
    '2019/05/27 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/05/27 ADD END
    '2019/04/05 ADD START
    Private FORM_CLOSE_FLG As Boolean = False
    '2019/04/05 ADD E N D

    '2019/06/04 ADD START
    Public D0 As ClsComn
    '2019/06/04 ADD END

    Private pv_ctlActiveCtrl As System.Windows.Forms.Control

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
        '2019/06/03 CHG START
        'Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
        'Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
        'Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
        Main_Inf.Dsp_IM_Denkyu = _IM_Denkyu_0
        Main_Inf.Off_IM_Denkyu = _IM_Denkyu_1
        Main_Inf.On_IM_Denkyu = _IM_Denkyu_2
        '2019/06/03 CHG END
        Main_Inf.Dsp_TX_Message = TX_Message

        '�r���������������������������������������������������������r
        '��ʊ�b���ݒ�
        With Main_Inf.Dsp_Base
            .Dsp_Ctg = DSP_CTG_REVISION '��ʕ���
            .Item_Cnt = 167 '��ʍ��ڐ�
            .Dsp_Body_Cnt = 6 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
            .Max_Body_Cnt = 6 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
            .Body_Col_Cnt = 14 '���ׂ̗񍀖ڐ�
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
        '2019/06/05 CHG START
        'MN_Ctrl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '�o�^
        '2019/06/05 CHG START
        'MN_Execute.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
        btnF1.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF1
        '2019/06/05 CHG END
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
        '�폜
        '2019/06/05 CHG START
        'MN_DeleteCM.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteCM
        btnF3.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF3
        '2019/06/05 CHG END
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
        '��ʈ��
        '2019/06/05 CHG START
        'MN_HARDCOPY.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
        btnF4.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF4
        '2019/06/05 CHG END
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
        '����ݒ�
        '2019/06/05 CHG START
        'MN_LCONFIG.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_LCONFIG
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '2019/06/05 CHG START
        'MN_EndCm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
        btnF12.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '2019/06/05 CHG END
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
        '�����Q
        '2019/06/05 CHG START
        'MN_EditMn.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '��ʏ�����
        '2019/06/05 CHG START
        'MN_APPENDC.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        '2019/06/05 CHG END
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
        '���ڏ�����
        '2019/06/05 CHG START
        'MN_ClearItm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END

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
        '���ڕ���
        '2019/06/05 CHG START
        'MN_UnDoItem.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
        btnF3.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF3
        '2019/06/05 CHG END
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
        '���׍s������
        '2019/06/05 CHG START
        'MN_ClearDE.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '���׍s�폜
        '2019/06/05 CHG START
        'MN_DeleteDE.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteDE
        btnF8.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF8
        '2019/06/05 CHG END
        'change start 20190827 kuwa
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'change end 20190827 kuwa
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
        '���׍s�}��
        '2019/06/05 CHG START
        'MN_InsertDE.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_InsertDE
        btnF7.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF7
        '2019/06/05 CHG END
        'change end 20190827 kuwa
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'change end 20190827 kuwa
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
        '���׍s����
        '2019/06/05 CHG START
        'MN_UnDoDe.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoDe
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '�؂���
        '2019/06/05 CHG START
        'MN_Cut.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
        'change 20190729 START hou
        'dummyCtl.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        ''2019/06/05 CHG END
        btnF5.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF5
        'change 20190729 END hou
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
        '�R�s�[
        '2019/06/05 CHG START
        'MN_Copy.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '�\��t��
        '2019/06/05 CHG START
        'MN_Paste.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '����R
        '2019/06/05 CHG START
        'MN_Oprt.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '���ڂ̈ꗗ
        '2019/06/05 CHG START
        'MN_Slist.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '���ړ��e�ɃR�s�[
        '2019/06/05 CHG START
        'SM_AllCopy.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '������
        '2019/06/05 CHG START
        'SM_Esc.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        '2019/06/05 CHG END
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
        '���ڂɓ\��t��
        '2019/06/05 CHG START
        'SM_FullPast.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '2019/06/05 CHG END
        'CM_EndCm.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '2019/06/05 DEL START
        ''=== �Ұ�ސݒ� ======================
        'Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
        'Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
        ''=== �Ұ�ސݒ� ======================
        '2019/06/05 DEL END

        Index_Wk = Index_Wk + 1
        '���s�C���[�W
        '2019/06/05 CHG START
        'CM_Execute.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '      '2019/06/04 DEL START
        '      '=== �Ұ�ސݒ� ======================
        '      Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
        'Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
        ''=== �Ұ�ސݒ� ======================
        '2019/06/04 DEL END

        Index_Wk = Index_Wk + 1
        '���גǉ��C���[�W
        '2019/06/05 CHG START
        'CM_INSERTDE.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_INSERTDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        ''=== �Ұ�ސݒ� ======================
        'Main_Inf.IM_INSERTDE_Inf.Click_Off_Img = IM_INSERTDE(0)
        'Main_Inf.IM_INSERTDE_Inf.Click_On_Img = IM_INSERTDE(1)
        ''=== �Ұ�ސݒ� ======================

        Index_Wk = Index_Wk + 1
        '���׍폜�C���[�W
        '2019/06/05 CHG START
        'CM_DELETEDE.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_DELETEDE
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        ''=== �Ұ�ސݒ� ======================
        'Main_Inf.IM_DELETEDE_Inf.Click_Off_Img = IM_DELETEDE(0)
        'Main_Inf.IM_DELETEDE_Inf.Click_On_Img = IM_DELETEDE(1)
        ''=== �Ұ�ސݒ� ======================

        Index_Wk = Index_Wk + 1
        '�����C���[�W
        '2019/06/05 CHG START
        'CM_SLIST.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        ''=== �Ұ�ސݒ� ======================
        'Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
        'Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
        ''=== �Ұ�ސݒ� ======================

        Index_Wk = Index_Wk + 1
        '����ݒ�C���[�W
        '2019/06/05 CHG START
        'CM_LCONFIG.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LCONFIG
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        ''=== �Ұ�ސݒ� ======================
        'Main_Inf.IM_LCONFIG_Inf.Click_Off_Img = IM_LCONFIG(0)
        'Main_Inf.IM_LCONFIG_Inf.Click_On_Img = IM_LCONFIG(1)
        '=== �Ұ�ސݒ� ======================

        Index_Wk = Index_Wk + 1
        '�w�b�_�C���[�W
        '2019/06/05 CHG START
        'Image1.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
        dummyCtl.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = dummyCtl
        '2019/06/05 CHG END
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
        '���������Ώ�(�f�[�^�ޔ�p)
        HD_DATNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DATNO
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '���������Ώۃ{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_DATNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_DATNO
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

        Index_Wk = Index_Wk + 1
        '�����敪
        HD_NYUKB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NYUKB
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
        '�������{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_NYUDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_NYUDT
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

        Index_Wk = Index_Wk + 1
        '������
        HD_NYUDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NYUDT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        '    Index_Wk = Index_Wk + 1
        '    '������(����)�{�^��
        '    CS_TOKCD.Tag = Index_Wk
        '    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TOKCD
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
        '
        Index_Wk = Index_Wk + 1
        '������(����)
        HD_TOKCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
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
        '������(����)
        HD_TOKRN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '    Index_Wk = Index_Wk + 1
        '    '�ʉ݋敪�{�^��
        '    CS_TUKKB.Tag = Index_Wk
        '    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TUKKB
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�ʉ݋敪
        HD_TUKKB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TUKKB
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
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
        '��������{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_KNJKOZ.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_KNJKOZ
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

        Index_Wk = Index_Wk + 1
        '�������
        HD_KNJKOZ.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KNJKOZ
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

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
        '������ʃ{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_DKBID.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_DKBID
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

        Index_Wk = Index_Wk + 1
        '��������{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_KANKOZ.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_KANKOZ
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

        Index_Wk = Index_Wk + 1
        '��s�R�[�h�{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_BNKCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_BNKCD
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

        Index_Wk = Index_Wk + 1
        '���ϓ��{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_TEGDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TEGDT
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

        Index_Wk = Index_Wk + 1
        'No
        BD_LINNO(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '��ʊ�b���ݒ�
        Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

        Index_Wk = Index_Wk + 1
        '�������(����)
        BD_DKBID(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DKBID(0)
        '_BD_DKBID_0.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = _BD_DKBID_0


        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '�������(����)
        BD_DKBNM(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DKBNM(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
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
        '�������
        BD_KANKOZ(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_KANKOZ(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '�����z(�~)
        BD_NYUKN(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUKN(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 11
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '�����z(�O��)
        BD_FNYUKN(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_FNYUKN(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 16
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 16
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 4
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = gc_DSP_FMT_KIN_GAI_1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '��s�R�[�h
        BD_BNKCD(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKCD(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
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
        '��s����
        BD_BNKNM(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKNM(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
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
        '�󒍔ԍ�
        BD_JDNNO(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_JDNNO(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
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
        '�x�X����
        BD_STNNM(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_STNNM(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
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
        '���ϓ�
        BD_TEGDT(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEGDT(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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

        Index_Wk = Index_Wk + 1
        '��`�ԍ�
        BD_TEGNO(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEGNO(0)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
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
        '���l�P
        BD_LINCMA(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(0)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '���l�Q
        BD_LINCMB(0).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(0)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
            BD_LINNO.Load(BD_Cnt) 'No
            BD_DKBID.Load(BD_Cnt) '�������(����)
            BD_DKBNM.Load(BD_Cnt) '�������(����)
            BD_KANKOZ.Load(BD_Cnt) '�������
            BD_NYUKN.Load(BD_Cnt) '�����z(�~)
            BD_FNYUKN.Load(BD_Cnt) '�����z(�O��)
            BD_BNKCD.Load(BD_Cnt) '��s�R�[�h
            BD_BNKNM.Load(BD_Cnt) '��s����
            BD_JDNNO.Load(BD_Cnt) '�󒍔ԍ�
            BD_STNNM.Load(BD_Cnt) '�x�X����
            BD_TEGDT.Load(BD_Cnt) '���ϓ�
            BD_TEGNO.Load(BD_Cnt) '��`�ԍ�
            BD_LINCMA.Load(BD_Cnt) '���l�P
            BD_LINCMB.Load(BD_Cnt) '���l�Q

            Index_Wk = Index_Wk + 1
            'No
            BD_LINNO(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�������(����)
            BD_DKBID(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DKBID(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�������(����)
            BD_DKBNM(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DKBNM(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�������
            BD_KANKOZ(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_KANKOZ(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�����z(�~)
            BD_NYUKN(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUKN(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�����z(�O��)
            BD_FNYUKN(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_FNYUKN(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '��s�R�[�h
            BD_BNKCD(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKCD(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '��s����
            BD_BNKNM(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKNM(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�󒍔ԍ�
            BD_JDNNO(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_JDNNO(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�x�X����
            BD_STNNM(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_STNNM(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���ϓ�
            BD_TEGDT(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEGDT(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '��`�ԍ�
            BD_TEGNO(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEGNO(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���l�P
            BD_LINCMA(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���l�Q
            BD_LINCMB(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(BD_Cnt)
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
        Next

        '///////////////
        '// �t�b�^���ҏW
        '///////////////
        '��ʊ�b���ݒ�
        Index_Wk = Index_Wk + 1
        '���v(�~)
        TL_SBANYUKN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBANYUKN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14 + 1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14 + 1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 11 + 1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

        Index_Wk = Index_Wk + 1
        '���v(�O��)
        TL_SBAFRNKN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAFRNKN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 16 + 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 16 + 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9 + 2
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 4
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = gc_DSP_FMT_KIN_GAI_1
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

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
        For Wk_Cnt = 0 To FM_Panel3D1_CNT - 1
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
        '���ו��̉B���s���\��/�g�p�s�ɐݒ�
        BD_LINNO(0).Visible = False : BD_LINNO(0).Enabled = False
        BD_DKBID(0).Visible = False : BD_DKBID(0).Enabled = False
        BD_DKBNM(0).Visible = False : BD_DKBNM(0).Enabled = False
        BD_KANKOZ(0).Visible = False : BD_KANKOZ(0).Enabled = False
        BD_NYUKN(0).Visible = False : BD_NYUKN(0).Enabled = False
        BD_FNYUKN(0).Visible = False : BD_FNYUKN(0).Enabled = False
        BD_BNKCD(0).Visible = False : BD_BNKCD(0).Enabled = False
        BD_BNKNM(0).Visible = False : BD_BNKNM(0).Enabled = False
        BD_JDNNO(0).Visible = False : BD_JDNNO(0).Enabled = False
        BD_STNNM(0).Visible = False : BD_STNNM(0).Enabled = False
        BD_TEGDT(0).Visible = False : BD_TEGDT(0).Enabled = False
        BD_TEGNO(0).Visible = False : BD_TEGNO(0).Enabled = False
        BD_LINCMA(0).Visible = False : BD_LINCMA(0).Enabled = False
        BD_LINCMB(0).Visible = False : BD_LINCMB(0).Enabled = False

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

        '�r���������������������������������������������������������r
        '��ʕύX�Ȃ��Ƃ���
        gv_bolURKET52_INIT = False
        gv_bolInit = False
        gv_bolURKET52_LF_Enable = True
        '�d���������������������������������������������������������d

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
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
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
        Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYRIGHT����(̫����ړ��Ȃ�)
                Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            'KEYDOWN����
            Call SSSMAIN0001.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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

        'KEYLEFT����(̫����ړ��Ȃ�)
        Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then
                'KEYLEFT����(̫����ړ�����)
                Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            'KEYUP����
            Call SSSMAIN0001.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

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
                Call SSSMAIN0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

                '�t�@���N�V�����L�[������
            Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
                '�t�@���N�V�����L�[���ʏ���
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
        End Select

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�t�H�[�J�X�ړ��\�̔��茋��(True:��  False:�s��)
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_LostFocus(ByRef pm_Ctl As System.Windows.Forms.Control) As Boolean

        Dim Trg_Index As Short
        Dim Act_Index As Short
        Dim Move_Flg As Boolean
        Dim Rtn_Chk As Short
        Dim Chk_Move_Flg As Boolean
        Dim Dsp_Mode As Short
        Dim Wk_Row As Short

        Ctl_Item_LostFocus = True

        If gv_bolURKET52_LF_Enable = False Then
            Exit Function
        End If

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

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
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            '������ړ�����
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

            '���הw�i�F�ݒ�
            Call F_Set_Body_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        End If

        Ctl_Item_LostFocus = Chk_Move_Flg

        Wk_Row = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
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
        Dim Wk_Row As Short

        '�t�H�[�J�X�̂���R���g���[���ޔ�
        pv_ctlActiveCtrl = pm_Ctl

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '��ʒP�ʂ̏���(�����Ȃ�)
        '���ו��ł��ړ��O�����ו��łȂ��ꍇ
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
            '�r���������������������������������������������������������r
            'ͯ�ޕ�����
            If gv_bolInit = False Then '��ʏ������̏ꍇ�͍s��Ȃ�
                Rtn_Chk = SSSMAIN0001.F_Ctl_Head_Chk(Main_Inf)
            Else
                Rtn_Chk = CHK_OK
            End If
            If Rtn_Chk <> CHK_OK Then
                Exit Function
            End If
            '�d���������������������������������������������������������d
        End If

        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '2019/05/21 CHG START
        'If TypeOf pm_Ctl Is SSCommand5 Then
        If TypeOf pm_Ctl Is Button Then
            '2019/05/21 CHG END
            '������ʌďo�̏ꍇ�͏I��
            Exit Function
        End If

        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
            '���׍s�R���g���[��������
            If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
                '���׌����{�^���̖��׍s���ϐ��ɓ����s����ݒ�
                For Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                    If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                        '�ݒ�ς݂̏ꍇ�͏I��
                        Exit For
                    End If
                    Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index

                    'add test 20190827 kuwa �s�폜����ۂɃN���b�N���Ɣ������Ȃ����� 12��btnF8��.Tag�̒l��12�ł��邽�߁B
                    Main_Inf.Dsp_Sub_Inf(12).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
                    'add test 20190827 kuwa


                    'add test 20190828 kuwa �s�ǉ�����ۂɃN���b�N���Ɣ������Ȃ����� 13��btnF7��.Tag�̒l��12�ł��邽�߁B
                    Main_Inf.Dsp_Sub_Inf(13).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
                    'add test 20190828 kuwa

                Next
            End If
        Else
            '���׌����{�^���̖��׍s���ϐ���������
            For Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                    '�ݒ�ς݂̏ꍇ�͏I��
                    Exit For
                End If
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
            Next
        End If

        '�r���������������������������������������������������������r
        Select Case Trg_Index
            Case Else
                '����̫����擾����
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        End Select
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
        Dim Wk_Row As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        Move_Flg = False
        Chk_Move_Flg = True

        '����KEYPRESS����
        Call SSSMAIN0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

        If Move_Flg = True Then
            '���̍��ڂֈړ������ꍇ
            '�e���ڂ�����ٰ��
            Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
            Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

            If Chk_Move_Flg = True Then

                '����̫����ʒu����E�ֈړ�
                Call SSSMAIN0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
                '������ړ�����
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            End If

        Else
            '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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

        '2019/05/27 ADD START
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '2019/05/27 ADD END
        Dim Trg_Index As Short
        If Main_Inf.Dsp_Base.Change_Flg = True Then
            Main_Inf.Dsp_Base.Change_Flg = False
            Exit Function
        End If

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '����KEYCHANG����
        Call SSSMAIN0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
                If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Typ <> IN_TYP_STR Then
                    '�I����Ԃ̐ݒ�i�����I���j
                    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                End If

                '2019/05/21 CHG START
                'Case TypeOf pm_Ctl Is SSPanel5
            Case TypeOf pm_Ctl Is Label
                '2019/05/21 CHG END

                '�p�l���̏ꍇ
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                '2019/05/21 CHG START	
                'Case TypeOf pm_Ctl Is SSCommand5
            Case TypeOf pm_Ctl Is Button
                '2019/05/21 CHG END

                '�{�^���̏ꍇ
                'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B

                '2019/05/21 CHG START
                'If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    '2019/05/21 CHG END

                    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                '2019/06/04 DEL START
                'Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                '    '�C���[�W�̏ꍇ
                '    Select Case Trg_Index
                '        Case CShort(CM_EndCm.Tag)
                '            '�I���Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)

                '        Case CShort(CM_Execute.Tag)
                '            '���s�Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)

                '        Case CShort(CM_INSERTDE.Tag)
                '            '�s�}���Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, False, Main_Inf)

                '        Case CShort(CM_DELETEDE.Tag)
                '            '�s�폜�Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, False, Main_Inf)

                '        Case CShort(CM_SLIST.Tag)
                '            '����W�Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)

                '        Case CShort(CM_LCONFIG.Tag)
                '            '����ݒ�Ұ��
                '            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, False, Main_Inf)
                '    End Select
                '2019/06/04 DEL END

        End Select

    End Function
    '2019/06/04 DEL START
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   ���́F  Function Ctl_Item_MouseMove
    '   '   �T�v�F  �e���ڂ�MOUSEMOVE����
    '   '   �����F�@�Ȃ�
    '   '   �ߒl�F�@�Ȃ�
    '   '   ���l�F  �S��ʃ��[�J�����ʏ���
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Private Function Ctl_Item_MouseMove(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short

    '	Dim Trg_Index As Short

    '	'�������ޯ���擾
    '	Trg_Index = CShort(pm_Ctl.Tag)

    '	Select Case Trg_Index
    '		Case CShort(Image1.Tag)
    '			'�Ұ�ނP(������)
    '			Call CF_Clr_Prompt(Main_Inf)

    '		Case CShort(CM_EndCm.Tag)
    '			'�I���Ұ��
    '			Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '		Case CShort(CM_Execute.Tag)
    '			'���s�Ұ��
    '			Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '		Case CShort(CM_INSERTDE.Tag)
    '			'�s�}���Ұ��
    '			Call CF_Set_Prompt(IMG_INSERTDE_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '		Case CShort(CM_DELETEDE.Tag)
    '			'�s�폜�Ұ��
    '			Call CF_Set_Prompt(IMG_DELETEDE_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '		Case CShort(CM_SLIST.Tag)
    '			'����W�Ұ��
    '			Call CF_Set_Prompt(IMG_SLIST_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '		Case CShort(CM_LCONFIG.Tag)
    '			'����ݒ�Ұ��
    '			Call CF_Set_Prompt(IMG_LCONFIG_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

    '	End Select

    'End Function
    '2019/06/04 DEL END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseDown
    '   �T�v�F  �e���ڂ�MOUSEDOWN����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_MouseDown(ByRef pm_Ctl As System.Windows.Forms.Control, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single) As Short
        '2019/06/04 DEL START
        'Dim Trg_Index As Short
        'Dim Act_Index As Short

        'If Me.ActiveControl Is Nothing Then
        '	Exit Function
        'End If

        ''�������ޯ���擾
        'Trg_Index = CShort(pm_Ctl.Tag)

        ''��è�޺��۰ي������ޯ���擾
        ''UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        'Act_Index = CShort(Me.ActiveControl.Tag)

        'Select Case Trg_Index
        '	Case CShort(CM_EndCm.Tag)
        '		'�I���Ұ��
        '		Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        '	Case CShort(CM_Execute.Tag)
        '		'���s�Ұ��
        '		Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        '	Case CShort(CM_INSERTDE.Tag)
        '		'�s�}���Ұ��
        '		'�s�ǉ��A�폜�{�^���̉�����
        '		If CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf) = True Then
        '			Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, True, Main_Inf)
        '		End If

        'Case CShort(MN_DeleteDE.Tag)
        '    '�s�폜�Ұ��
        '    '�s�ǉ��A�폜�{�^���̉�����
        '    If CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf) = True Then
        'Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, True, Main_Inf)
        'End If

        '	Case CShort(CM_SLIST.Tag)
        '		'����W�Ұ��
        '		Select Case Act_Index

        '			Case CShort(Me.HD_DATNO.Tag), CShort(Me.HD_NYUDT.Tag), CShort(Me.HD_KNJKOZ.Tag), CShort(Me.BD_DKBID(1).Tag), CShort(Me.BD_DKBID(2).Tag), CShort(Me.BD_DKBID(3).Tag), CShort(Me.BD_DKBID(4).Tag), CShort(Me.BD_DKBID(5).Tag), CShort(Me.BD_DKBID(6).Tag), CShort(Me.BD_KANKOZ(1).Tag), CShort(Me.BD_KANKOZ(2).Tag), CShort(Me.BD_KANKOZ(3).Tag), CShort(Me.BD_KANKOZ(4).Tag), CShort(Me.BD_KANKOZ(5).Tag), CShort(Me.BD_KANKOZ(6).Tag), CShort(Me.BD_BNKCD(1).Tag), CShort(Me.BD_BNKCD(2).Tag), CShort(Me.BD_BNKCD(3).Tag), CShort(Me.BD_BNKCD(4).Tag), CShort(Me.BD_BNKCD(5).Tag), CShort(Me.BD_BNKCD(6).Tag), CShort(Me.BD_TEGDT(1).Tag), CShort(Me.BD_TEGDT(2).Tag), CShort(Me.BD_TEGDT(3).Tag), CShort(Me.BD_TEGDT(4).Tag), CShort(Me.BD_TEGDT(5).Tag), CShort(Me.BD_TEGDT(6).Tag)

        '				Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)

        '		End Select

        '	Case CShort(CM_LCONFIG.Tag)
        '		'����ݒ�Ұ��
        '		Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, True, Main_Inf)

        'End Select

        ''����MOUSEDOWN����
        'Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
        '2019/06/04 DEL END
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

        If Main_Inf.Dsp_Base.Head_Ok_Flg = False And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_TL Then
            Exit Function
        End If

        '��è�޺��۰ي������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�r���������������������������������������������������������r
        '�e������ʌďo
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case Trg_Index
            Case CShort(CS_DATNO.Tag)
                '���������Ώۉ�ʌďo
                Call SSSMAIN0001.F_Ctl_CS_DATNO(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(CS_NYUDT.Tag)
                '������
                Call SSSMAIN0001.F_Ctl_CS_NYUDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(CS_KNJKOZ.Tag)
                '�������
                Call SSSMAIN0001.F_Ctl_CS_KNJKOZ(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(CS_DKBID.Tag)
                '���ׁF�������
                Call SSSMAIN0001.F_Ctl_CS_DKBID(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(CS_KANKOZ.Tag)
                '���ׁF�������
                Call SSSMAIN0001.F_Ctl_CS_KANKOZ(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(CS_BNKCD.Tag)
                '���ׁF��s�R�[�h
                Call SSSMAIN0001.F_Ctl_CS_BNKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(CS_TEGDT.Tag)
                '���ׁF���ϓ�
                Call SSSMAIN0001.F_Ctl_CS_TEGDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            '    '�d���������������������������������������������������������d

            'Case CShort(MN_Ctrl.Tag)
            '    '�����P
            '    Call Ctl_MN_Ctrl_Click()

            '2019/06/05 CHG START
            'Case CShort(MN_Execute.Tag), CShort(CM_Execute.Tag)
            Case CShort(btnF1.Tag)
                '2019/06/05 CHG END
                '    '�o�^
                Call Ctl_MN_Execute_Click()

                '2019/06/05 CHG START
                'Case CShort(MN_DeleteCM.Tag)
            Case CShort(btnF3.Tag)
                '    '�폜
                Call Ctl_MN_DeleteCM_Click()

            'Case CShort(MN_HARDCOPY.Tag)
            '    '��ʈ��
            '    Call Ctl_MN_HARDCOPY_Click()

                '2019/06/05 CHG START
                'Case CShort(MN_EndCm.Tag), CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '2019/06/05 CHG END
                '�I��
                Call Ctl_MN_EndCm_Click()
                Exit Function

                '2019/06/05 DEL START
                'Case CShort(MN_EditMn.Tag)
                '    '�����Q
                '    Call Ctl_MN_EditMn_Click()
                '2019/06/05 DEL END

                '2019/06/05 CHG START
                'Case CShort(MN_APPENDC.Tag)
            Case CShort(btnF9.Tag)
                '2019/06/05 CHG END
                'Case CShort(MN_APPENDC.Tag)
                '��ʏ�����
                Call Ctl_MN_APPENDC_Click()

            Case CShort(MN_ClearItm.Tag)
                '���ڏ�����
                Call Ctl_MN_ClearItm_Click()

                '2019/06/05 DEL START
                'Case CShort(MN_UnDoItem.Tag)
                '    '���ڕ���
                '    Call Ctl_MN_UnDoItem_Click()

                'Case CShort(MN_ClearDE.Tag)
                '    '���׍s������
                '    Call Ctl_MN_ClearDE_Click()
                '2019/06/05 DEL END

                '2019/06/05 CHG START
                'Case CShort(MN_DeleteDE.Tag), CShort(CM_DELETEDE.Tag)
            Case CShort(btnF8.Tag)
                '2019/06/05 CHG END
                '���׍s�폜
                Call Ctl_MN_DeleteDE_Click()

                '2019/06/05 CHG START
                'Case CShort(MN_InsertDE.Tag), CShort(CM_INSERTDE.Tag)
            Case CShort(btnF7.Tag)
                '2019/06/05 CHG END
                '���׍s�}��
                Call Ctl_MN_InsertDE_Click()

                '2019/06/05 DEL START
                'Case CShort(MN_UnDoDe.Tag)
                '    '���׍s����
                '    Call Ctl_MN_UnDoDe_Click()

                'Case CShort(MN_Cut.Tag)
                '    '�؂���
                '    Call Ctl_MN_Cut_Click()

                'Case CShort(MN_Copy.Tag)
                '    '�R�s�[
                '    Call Ctl_MN_Copy_Click()

                'Case CShort(MN_Paste.Tag)
                '    '�\��t��
                '    Call Ctl_MN_Paste_Click()

                'Case CShort(MN_Oprt.Tag)
                '    '����R
                '    Call Ctl_MN_Oprt_Click()

                'Case CShort(MN_Slist.Tag), CShort(CM_SLIST.Tag)
                '    '���ڂ̈ꗗ
                '    Call Ctl_MN_Slist_Click()

                'Case CShort(SM_AllCopy.Tag)
                '    '���ړ��e�ɃR�s�[
                '    Call Ctl_SM_AllCopy_Click()
                '2019/06/05 DEL END

                '2019/06/05 CHG START
                'Case CShort(SM_Esc.Tag)
            Case CShort(btnF9.Tag)
                '2019/06/05 CHG END
                '������
                Call Ctl_SM_Esc_Click()

                '2019/06/05 DEL START
                'Case CShort(SM_FullPast.Tag)
                '    '���ڂɓ\��t��
                '    Call Ctl_SM_FullPast_Click()

                'Case CShort(CM_LCONFIG.Tag), CShort(MN_LCONFIG.Tag)
                '    '����ݒ�
                '    Call Ctl_MN_LCONFIG_Click()
                '2019/06/05 DEL END

                'add 20190729 START hou
            Case CShort(btnF5.Tag)
                Call Ctl_MN_Slist_Click(Main_Inf)
                'add 20190729 END hou
        End Select

        '�X�e�[�^�X�o�[������
        Call CF_Clr_Prompt(Main_Inf)

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
        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False

        '�d���������������������������������������������������������d

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)
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
            Call CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        Else
            '�c�X�N���[���o�[��ݒ�
            Call CF_Set_Item_Direct(Main_Inf.Dsp_Body_Inf.Cur_Top_Index, Main_Inf.Dsp_Sub_Inf(CShort(Main_Inf.Bd_Vs_Scrl.Tag)), Main_Inf)
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

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

        '��o�^�����
        MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��폜�����
        MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '���ʈ�������
        MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��I�������
        MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Ant_Index = CShort(Me.ActiveControl.Tag)

        '���ʏ����������
        MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����ڏ����������
        MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����ڕ��������
        MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����׍s�����������
        MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����׍s�폜�����
        MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����׍s�}�������
        MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����׍s���������
        MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��؂��裔���
        MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��R�s�[�����
        MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��\��t�������
        MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

        '���������Ώۂ́A�؂���E�R�s�[�E�\��t���͂ł��Ȃ�
        If Me.ActiveControl Is Me.HD_DATNO Then
            MN_Cut.Enabled = False
            MN_Copy.Enabled = False
            MN_Paste.Enabled = False
        End If
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

        '����̈ꗗ�������
        MN_Slist.Enabled = False
        '����̈ꗗ�����

        '�r���������������������������������������������������������r
        '��è�ނȍ��ڂ̌����@�\������ꍇ�A�g�p��
        'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Select Case Me.ActiveControl.Name
            Case HD_DATNO.Name, HD_NYUDT.Name, HD_KNJKOZ.Name, BD_DKBID(0).Name, BD_KANKOZ(0).Name, BD_BNKCD(0).Name, BD_TEGDT(0).Name
                '�����@�\�̂�����͍��ڂ̏ꍇ

                MN_Slist.Enabled = True
        End Select
        '�d���������������������������������������������������������d

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_APPENDC_Click
    '   �T�v�F  ��ʏ���������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_APPENDC_Click() As Short

        '��ʏ����������Ăяo��
        Call F_Ctl_MN_APPENDC_Click(Main_Inf)

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̏���������
        Call CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '��ʓ��e������
        Call SSSMAIN0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)

        '�R�[�h�n�́A���̂��N���A
        'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Select Case Me.ActiveControl.Name
            Case BD_DKBID(0).Name
                Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
                '�{�f�B���̏ꍇ�A��ʏ���ޔ�
                '�i��Dsp_Body_Inf.Row_Inf �ɑޔ����邽�߁j
                Call CF_Body_Bkup(Main_Inf)

            Case BD_BNKCD(0).Name
                Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
                '�{�f�B���̏ꍇ�A��ʏ���ޔ�
                '�i��Dsp_Body_Inf.Row_Inf �ɑޔ����邽�߁j
                Call CF_Body_Bkup(Main_Inf)

        End Select

        '�d���������������������������������������������������������d

        '����̫����擾����
        Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  �o�^
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Execute_Click() As Short

        Dim intRet As Short

        intRet = SSSMAIN0001.F_Ctl_Upd_Process(Main_Inf)
        If intRet = 0 Then
            '��ʏ�����
            Call Ctl_MN_APPENDC_Click()
        End If
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteCM_Click
    '   �T�v�F  �폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_DeleteCM_Click() As Short

        Dim intRet As Short

        intRet = SSSMAIN0001.F_Ctl_UpdDel_Process(Main_Inf)
        If intRet = 0 Then
            '��ʏ�����
            Call Ctl_MN_APPENDC_Click()
        End If
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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)
        If CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf) = True Then
            '�Y���s�̍폜����
            Call CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        End If
        '�r���������������������������������������������������������r
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

        Me.Close()

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
            wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
        End If

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        If CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf) = False Then
            Exit Function
        End If

        '�Y���s�̑}������
        Call CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
        Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  ���ڂ̈ꗗ
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'change 20190730 START hou
    ' Private Function Ctl_MN_Slist_Click() As Short
    Private Function Ctl_MN_Slist_Click(ByRef pm_Ctl As Cls_All) As Short
        'change 20190730 END hou

        Dim Act_Index As Short

        'add 20190730 START hou
        Dim Trg_Index As Short
        'add 20190730 END hou 

        '��è�޺��۰ي������ޯ���擾
        Act_Index = CShort(pv_ctlActiveCtrl.Tag)

        ''�r���������������������������������������������������������r

        Select Case Act_Index
        'Select Case Cursor_Index
            '���o�F���������Ώ�
            Case CShort(Me.HD_DATNO.Tag)
                Call CS_DATNO_Click()

                        '���o�F������
            Case CShort(Me.HD_NYUDT.Tag)
                Call CS_NYUDT_Click()

                        '���o�F�������
            Case CShort(Me.HD_KNJKOZ.Tag)
                Call CS_KNJKOZ_Click()

                '        '���ׁF�������
                '    Case CShort(Me.BD_DKBID(1).Tag), CShort(Me.BD_DKBID(2).Tag), CShort(Me.BD_DKBID(3).Tag), CShort(Me.BD_DKBID(4).Tag), CShort(Me.BD_DKBID(5).Tag), CShort(Me.BD_DKBID(6).Tag)

                '        Call CS_DKBID_Click()

                '        '���ׁF�������
                '    Case CShort(Me.BD_KANKOZ(1).Tag), CShort(Me.BD_KANKOZ(2).Tag), CShort(Me.BD_KANKOZ(3).Tag), CShort(Me.BD_KANKOZ(4).Tag), CShort(Me.BD_KANKOZ(5).Tag), CShort(Me.BD_KANKOZ(6).Tag)

                '        Call CS_KANKOZ_Click()

                '        '���ׁF��s�R�[�h
                '    Case CShort(Me.BD_BNKCD(1).Tag), CShort(Me.BD_BNKCD(2).Tag), CShort(Me.BD_BNKCD(3).Tag), CShort(Me.BD_BNKCD(4).Tag), CShort(Me.BD_BNKCD(5).Tag), CShort(Me.BD_BNKCD(6).Tag)

                '        Call CS_BNKCD_Click()

                '        '���ׁF���ϓ�
                '    Case CShort(Me.BD_TEGDT(1).Tag), CShort(Me.BD_TEGDT(2).Tag), CShort(Me.BD_TEGDT(3).Tag), CShort(Me.BD_TEGDT(4).Tag), CShort(Me.BD_TEGDT(5).Tag), CShort(Me.BD_TEGDT(6).Tag)

                '        Call CS_TEGDT_Click()

                '    Case Else



                'add 20190730 START hou
            Case CShort(BD_KANKOZ(1).Tag), CShort(BD_KANKOZ(2).Tag), CShort(BD_KANKOZ(3).Tag), CShort(BD_KANKOZ(4).Tag), CShort(BD_KANKOZ(5).Tag), CShort(BD_KANKOZ(6).Tag)
                '���ׁF�������
                Call SSSMAIN0001.F_Ctl_CS_KANKOZ(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(BD_DKBID(1).Tag), CShort(BD_DKBID(2).Tag), CShort(BD_DKBID(3).Tag), CShort(BD_DKBID(4).Tag), CShort(BD_DKBID(5).Tag), CShort(BD_DKBID(6).Tag)
                '���ׁF�������
                Call SSSMAIN0001.F_Ctl_CS_DKBID(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(BD_BNKCD(1).Tag), CShort(BD_BNKCD(2).Tag), CShort(BD_BNKCD(3).Tag), CShort(BD_BNKCD(4).Tag), CShort(BD_BNKCD(5).Tag), CShort(BD_BNKCD(6).Tag)
                '���ׁF��s�R�[�h
                Call SSSMAIN0001.F_Ctl_CS_BNKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

            Case CShort(BD_TEGDT(1).Tag), CShort(BD_TEGDT(2).Tag), CShort(BD_TEGDT(3).Tag), CShort(BD_TEGDT(4).Tag), CShort(BD_TEGDT(5).Tag), CShort(BD_TEGDT(6).Tag)
                '���ׁF���ϓ�
                Call SSSMAIN0001.F_Ctl_CS_TEGDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

                'add 20190730 END hou
        End Select

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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y���s�̕�������
        Call CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

        '�r���������������������������������������������������������r
        '�d���������������������������������������������������������d
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoItem_Click
    '   �T�v�F  ���ڕ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_UnDoItem_Click() As Short
        '�r���������������������������������������������������������r
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
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)

        '�I����Ԃ̐ݒ�i�����I���j
        Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)

        '���ڐF�ݒ�
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)
        '�d���������������������������������������������������������d
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_LCONFIG_Click
    '   �T�v�F  ����ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_LCONFIG_Click() As Short
        ''�r���������������������������������������������������������r
        '    SSS_RPTID = "XXXXXXXXXX"
        '    WLS_PRN.Show 1
        ''�d���������������������������������������������������������d
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

        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�Y�����ڂ̓\��t��
        '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
        Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

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
        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Index_Wk = CShort(SYSDT.Tag)
        '��ʓ��t
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
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

        Dim BD_LINNO_Top As Short
        Dim BD_LINNO_Height As Short

        Dim BD_DKBNM_Top As Short
        Dim BD_FNYUKN_Top As Short
        Dim BD_BNKNM_Top As Short
        Dim BD_STNNM_Top As Short
        Dim BD_LINCMB_Top As Short

        Dim Bd_Index As Short

        '�r���������������������������������������������������������r
        '�P�s�ڂ�No��Top��Height����Ƃ���
        BD_LINNO_Top = VB6.PixelsToTwipsY(BD_LINNO(1).Top)
        BD_LINNO_Height = VB6.PixelsToTwipsY(BD_LINNO(1).Height) + Hosei_Value

        '�P�s�ڢNo����碓������(����)��܂ł̑��Έʒu���擾
        BD_DKBNM_Top = VB6.PixelsToTwipsY(BD_DKBNM(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碓����z(�O��)��܂ł̑��Έʒu���擾
        BD_FNYUKN_Top = VB6.PixelsToTwipsY(BD_FNYUKN(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碋�s���̣�܂ł̑��Έʒu���擾
        BD_BNKNM_Top = VB6.PixelsToTwipsY(BD_BNKNM(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碎x�X���̣�܂ł̑��Έʒu���擾
        BD_STNNM_Top = VB6.PixelsToTwipsY(BD_STNNM(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碔��l�Q��܂ł̑��Έʒu���擾
        BD_LINCMB_Top = VB6.PixelsToTwipsY(BD_LINCMB(1).Top) - BD_LINNO_Top

        '�\���ŏI�s�܂ŏ���
        For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
            If Bd_Index >= 2 Then
                '�Q�s�ڈȍ~����
                '�z�u
                BD_LINNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_DKBID(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_DKBNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_DKBNM_Top)
                BD_KANKOZ(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_NYUKN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_FNYUKN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_FNYUKN_Top)
                BD_BNKCD(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_BNKNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_BNKNM_Top)
                BD_JDNNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_STNNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_STNNM_Top)
                BD_TEGDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_TEGNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_LINCMA(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
                BD_LINCMB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_LINCMB_Top)
            End If

            '�\��
            BD_LINNO(Bd_Index).Visible = True
            BD_DKBID(Bd_Index).Visible = True
            BD_DKBNM(Bd_Index).Visible = True
            BD_KANKOZ(Bd_Index).Visible = True
            BD_NYUKN(Bd_Index).Visible = True
            BD_FNYUKN(Bd_Index).Visible = True
            BD_BNKCD(Bd_Index).Visible = True
            BD_BNKNM(Bd_Index).Visible = True
            BD_JDNNO(Bd_Index).Visible = True
            BD_STNNM(Bd_Index).Visible = True
            BD_TEGDT(Bd_Index).Visible = True
            BD_TEGNO(Bd_Index).Visible = True
            BD_LINCMA(Bd_Index).Visible = True
            BD_LINCMB(Bd_Index).Visible = True

        Next

        '�X�N���[���o�[�̐ݒ�
        Main_Inf.Bd_Vs_Scrl.Top = VB6.TwipsToPixelsY(BD_LINNO_Top)
        Main_Inf.Bd_Vs_Scrl.Height = VB6.TwipsToPixelsY(BD_LINNO_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt)

        '�d���������������������������������������������������������d

    End Function

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        '�I�����b�Z�[�W�̏o��
        If gv_bolURKET52_INIT = False Then
            '�I�����܂����H
            If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_001, Main_Inf) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                '2019/06/05 ADD START
                eventArgs.Cancel = Cancel
                '2019/06/05 ADD END
                Exit Sub
            End If
        Else
            '���o�^�̂܂܏I�����܂����H
            If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_002, Main_Inf) = MsgBoxResult.No Then
                Cancel = MsgBoxResult.Cancel
                '2019/06/05 ADD START
                eventArgs.Cancel = Cancel
                '2019/06/05 ADD END
                Exit Sub
            End If
        End If

        ' === 20130711 === INSERT S - FWEST)Koroyasu �r������̉���
        '�r������
        '2019/05/23 CHG START
        'Call CF_Del_EXCTBZ2()
        CF_Unlock_EXCTBZ2()
        '2019/05/23 CHG END
        ' === 20130711 === INSERT E -

        Main_Inf.Dsp_Base.IsUnload = True

        'DB�ڑ�����
        '2019/05/23 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        'Call CF_Ora_DisConnect(gv_Oss_USR9, gv_Odb_USR9)
        DB_CLOSE(CON)
        '2019/05/23 CHG END

        Call SSSWIN_LOGWRT("�v���O�����I��")

        eventArgs.Cancel = Cancel
    End Sub

    Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
        '��x����̂��ߎg�p�s��
        Main_Inf.TM_StartUp_Ctl.Enabled = False
        '��ʈ���N������TRUE�Ƃ���
        PP_SSSMAIN.Operable = True
        '����̫����ʒu�ݒ�
        Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load


        '2019/06/05 ADD START
        Dim Index_Wk As Short = 0
        '2019/06/05 ADD END

        'DB�ڑ�
        '2019/05/27 CHG START
        'Call CF_Ora_USR1_Open()
        CON = DB_START()
        '2019/05/27 CHG END

        '���ʏ���������
        Call CF_Init()

        '��ʏ��ݒ�
        Call Init_Def_Dsp()

        '��ʓ��e������
        Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

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

        '���͒S���ҕҏW
        '2019/05/23 CHG START
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
        Call CF_Set_Frm_IN_TANCD_KET52(Me, Main_Inf)
        '2019/05/23 CHG END

        '���[�U�[���Ǘ��e�[�u���Ǎ�
        Call F_GET_SYSTBA()

        '��ʕҏW�Ȃ��Ƃ���
        gv_bolURKET52_INIT = False
        gv_bolInit = False
        gv_bolURKET52_LF_Enable = True

        '�V�X�e�����ʏ���
        Call CF_System_Process(Me)

        '2019/06/05 ADD START
        With PP_SSSMAIN
            '�g�p���Ȃ��t�@���N�V�����L�[�͔񊈐��ɂ���
            'delete test 20190827 kuwa
            btnF2.Enabled = False
            'btnF3.Enabled = False
            btnF4.Enabled = False
            'delete test 20190827 kuwa
            btnF6.Enabled = False
            'delete test 20190827 kuwa
            'btnF7.Enabled = False
            'btnF8.Enabled = False
            btnF10.Enabled = False
            btnF11.Enabled = False

            '�t�@���N�V�����L�[�̃C���f�b�N�X�̐ݒ�
            btnF1.Tag = Index_Wk
            Index_Wk += 1
            btnF5.Tag = Index_Wk
            Index_Wk += 1
            btnF9.Tag = Index_Wk
            Index_Wk += 1
            btnF12.Tag = Index_Wk

        End With
        SetBar(Me)
        '2019/06/05 ADD END

    End Sub

    Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("FM_Panel3D1_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
    End Sub

    Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    End Sub
    '2019/06/04 DEL START
    '   Private Sub Image1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Image1.Click
    '	Debug.Print("Image1_Click")
    '	Call Ctl_Item_Click(Image1)
    'End Sub

    'Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("Image1_MouseMove")
    '	Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
    'End Sub

    'Private Sub Image1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("Image1_MouseUp")
    '	Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
    'End Sub

    ''**************************************************
    ''���j���[
    'Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
    '	Debug.Print("MN_Ctrl_Click")
    '	Call Ctl_Item_Click(MN_Ctrl)
    'End Sub

    'Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
    '	Debug.Print("MN_EditMn_Click")
    '	Call Ctl_Item_Click(MN_EditMn)
    'End Sub

    'Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
    '	Debug.Print("MN_Oprt_Click")
    '	Call Ctl_Item_Click(MN_Oprt)
    'End Sub

    'Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
    '	Debug.Print("MN_APPENDC_Click")
    '	Call Ctl_Item_Click(MN_APPENDC)
    'End Sub

    'Public Sub MN_ClearDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearDE.Click
    '	Debug.Print("MN_ClearDE_Click")
    '	Call Ctl_Item_Click(MN_ClearDE)
    'End Sub

    'Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
    '	Debug.Print("MN_ClearItm_Click")
    '	Call Ctl_Item_Click(MN_ClearItm)
    'End Sub

    'Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
    '	Debug.Print("MN_Copy_Click")
    '	Call Ctl_Item_Click(MN_Copy)
    'End Sub

    'Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
    '	Debug.Print("MN_Cut_Click")
    '	Call Ctl_Item_Click(MN_Cut)
    'End Sub

    'Public Sub MN_DeleteCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteCM.Click
    '	Debug.Print("MN_DeleteCM_Click")
    '	Call Ctl_Item_Click(MN_DeleteCM)
    'End Sub

    'Public Sub MN_DeleteDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_DeleteDE.Click
    '	Debug.Print("MN_DeleteDE_Click")
    '	Call Ctl_Item_Click(MN_DeleteDE)
    'End Sub

    'Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
    '	Debug.Print("MN_EndCm_Click")
    '	Call Ctl_Item_Click(MN_EndCm)
    'End Sub

    'Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
    '	Debug.Print("MN_Execute_Click")
    '	Call Ctl_Item_Click(MN_Execute)
    'End Sub

    'Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
    '	Debug.Print("MN_HARDCOPY_Click")
    '	Call Ctl_Item_Click(MN_HARDCOPY)
    'End Sub

    'Public Sub MN_InsertDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_InsertDE.Click
    '	Debug.Print("MN_InsertDE_Click")
    '	Call Ctl_Item_Click(MN_InsertDE)
    'End Sub

    'Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
    '	Debug.Print("MN_Paste_Click")
    '	Call Ctl_Item_Click(MN_Paste)
    'End Sub

    'Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
    '	Debug.Print("MN_Slist_Click")
    '	Call Ctl_Item_Click(MN_Slist)
    'End Sub

    'Public Sub MN_UnDoDe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoDe.Click
    '	Debug.Print("MN_UnDoDe_Click")
    '	Call Ctl_Item_Click(MN_UnDoDe)
    'End Sub

    'Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
    '	Debug.Print("MN_UnDoItem_Click")
    '	Call Ctl_Item_Click(MN_UnDoItem)
    'End Sub

    'Public Sub MN_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_LCONFIG.Click
    '	Debug.Print("MN_LCONFIG_Click")
    '	Call Ctl_Item_Click(MN_LCONFIG)
    'End Sub

    ''**************************************************
    ''
    'Public Sub SM_AllCopy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_AllCopy.Click
    '	Debug.Print("SM_AllCopy_Click")
    '	Call Ctl_Item_Click(SM_AllCopy)
    'End Sub

    'Public Sub SM_Esc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_Esc.Click
    '	Debug.Print("SM_Esc_Click")
    '	Call Ctl_Item_Click(SM_Esc)
    'End Sub

    'Public Sub SM_FullPast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SM_FullPast.Click
    '	Debug.Print("SM_FullPast_Click")
    '	Call Ctl_Item_Click(SM_FullPast)
    'End Sub

    ''**************************************************
    ''�A�C�R��
    'Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
    '	Debug.Print("CM_EndCm_Click")
    '	Call Ctl_Item_Click(CM_EndCm)
    'End Sub

    'Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_EndCm_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
    '	Debug.Print("CM_Execute_Click")
    '	Call Ctl_Item_Click(CM_Execute)
    'End Sub

    'Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_Execute_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_INSERTDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_INSERTDE.Click
    '	Debug.Print("CM_INSERTDE_Click")
    '	Call Ctl_Item_Click(CM_INSERTDE)
    'End Sub

    'Private Sub CM_INSERTDE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_INSERTDE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_INSERTDE_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_INSERTDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_INSERTDE_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_INSERTDE.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_INSERTDE_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_INSERTDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_INSERTDE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_INSERTDE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_INSERTDE_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_INSERTDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_DELETEDE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_DELETEDE.Click
    '	Debug.Print("CM_DELETEDE_Click")
    '	Call Ctl_Item_Click(CM_DELETEDE)
    'End Sub

    'Private Sub CM_DELETEDE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DELETEDE.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_DELETEDE_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_DELETEDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_DELETEDE_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DELETEDE.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_DELETEDE_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_DELETEDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_DELETEDE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_DELETEDE.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_DELETEDE_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_DELETEDE, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click
    '	Debug.Print("CM_SLIST_Click")
    '	Call Ctl_Item_Click(CM_SLIST)
    'End Sub

    'Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SLIST_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_SLIST_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_LCONFIG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_LCONFIG.Click
    '	Debug.Print("CM_LCONFIG_Click")
    '	Call Ctl_Item_Click(CM_LCONFIG)
    'End Sub

    'Private Sub CM_LCONFIG_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseDown
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_LCONFIG_MouseDown")
    '	Call Ctl_Item_MouseDown(CM_LCONFIG, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_LCONFIG_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseMove
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_LCONFIG_MouseMove")
    '	Call Ctl_Item_MouseMove(CM_LCONFIG, Button, Shift, X, Y)
    'End Sub

    'Private Sub CM_LCONFIG_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_LCONFIG.MouseUp
    '	Dim Button As Short = eventArgs.Button \ &H100000
    '	Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '	Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '	Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '	Debug.Print("CM_LCONFIG_MouseUp")
    '	Call Ctl_Item_MouseUp(CM_LCONFIG, Button, Shift, X, Y)
    'End Sub
    '2019/06/04 DEL END
    '**************************************************
    '���o�F���������Ώ�
    Private Sub CS_DATNO_Click()
        Debug.Print("CS_DATNO_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_DATNO)
    End Sub

    Private Sub CS_DATNO_GotFocus()
        Debug.Print("CS_DATNO_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_DATNO)
    End Sub

    Private Sub CS_DATNO_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_DATNO_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_DATNO, Button, Shift, X, Y)
    End Sub

    Private Sub CS_DATNO_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_DATNO_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DATNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_DATNO, Button, Shift, X, Y)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_DATNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_DATNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DATNO.TextChanged
        Debug.Print("HD_DATNO_Change")
        Call Ctl_Item_Change(HD_DATNO)
    End Sub

    Private Sub HD_DATNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DATNO.Enter
        Debug.Print("HD_DATNO_GotFocus")
        Call Ctl_Item_GotFocus(HD_DATNO)
    End Sub

    Private Sub HD_DATNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DATNO.Leave
        Debug.Print("HD_DATNO_LostFocus")
        Call Ctl_Item_LostFocus(HD_DATNO)
    End Sub

    Private Sub HD_DATNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DATNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_DATNO_KeyDown")

        '�� �� �� �Ȃ�G���^�[�L�[�̏������s��
        If (KeyCode = System.Windows.Forms.Keys.Right Or KeyCode = System.Windows.Forms.Keys.Down) And Shift = 0 Then
            KeyCode = System.Windows.Forms.Keys.Return
        End If

        '���͂�������L�[������
        Select Case True
            '�ʏ�ʂ�̏������s���L�[
            Case KeyCode = System.Windows.Forms.Keys.Return And Shift = 0 '��������
            Case KeyCode = System.Windows.Forms.Keys.Left And Shift = 0 '����
            Case KeyCode = System.Windows.Forms.Keys.Up And Shift = 0 '����
            Case KeyCode = System.Windows.Forms.Keys.F16 'TAB��
            Case KeyCode = System.Windows.Forms.Keys.F15 'Shift+TAB��
            Case KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 '�t�@���N�V�����L�[������

                '��̃p�^�[���ȊO�̓L�[���Ԃ�
            Case Else
                KeyCode = 0
                Shift = 0
                Exit Sub
        End Select

        Call Ctl_Item_KeyDown(HD_DATNO, KeyCode, Shift)
    End Sub

    Private Sub HD_DATNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DATNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_DATNO_KeyPress")

        '������ʂ�����͂���̂Ŏ���͂͂ł��Ȃ�����
        KeyAscii = 0

        'Call Ctl_Item_KeyPress(HD_DATNO, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_DATNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DATNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_DATNO_KeyUp")
        Call Ctl_Item_KeyUp(HD_DATNO)
    End Sub

    Private Sub HD_DATNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DATNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_DATNO_MouseDown")
        Call Ctl_Item_MouseDown(HD_DATNO, Button, Shift, X, Y)
    End Sub

    Private Sub HD_DATNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DATNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_DATNO_MouseUp")
        Call Ctl_Item_MouseUp(HD_DATNO, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F�����敪
    'UPGRADE_WARNING: �C�x���g HD_NYUKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_NYUKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUKB.TextChanged
        Debug.Print("HD_NYUKB_Change")
        Call Ctl_Item_Change(HD_NYUKB)
    End Sub

    Private Sub HD_NYUKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUKB.Enter
        Debug.Print("HD_NYUKB_GotFocus")
        Call Ctl_Item_GotFocus(HD_NYUKB)
    End Sub

    Private Sub HD_NYUKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUKB.Leave
        Debug.Print("HD_NYUKB_LostFocus")
        Call Ctl_Item_LostFocus(HD_NYUKB)
    End Sub

    Private Sub HD_NYUKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NYUKB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NYUKB_KeyDown")
        Call Ctl_Item_KeyDown(HD_NYUKB, KeyCode, Shift)
    End Sub

    Private Sub HD_NYUKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NYUKB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_NYUKB_KeyPress")
        Call Ctl_Item_KeyPress(HD_NYUKB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_NYUKB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NYUKB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NYUKB_KeyUp")
        Call Ctl_Item_KeyUp(HD_NYUKB)
    End Sub

    Private Sub HD_NYUKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NYUKB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NYUKB_MouseDown")
        Call Ctl_Item_MouseDown(HD_NYUKB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NYUKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NYUKB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NYUKB_MouseUp")
        Call Ctl_Item_MouseUp(HD_NYUKB, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F������
    Private Sub CS_NYUDT_Click()
        Debug.Print("CS_NYUDT_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_NYUDT)
    End Sub

    Private Sub CS_NYUDT_GotFocus()
        Debug.Print("CS_NYUDT_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_NYUDT)
    End Sub

    Private Sub CS_NYUDT_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_NYUDT_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_NYUDT, Button, Shift, X, Y)
    End Sub

    Private Sub CS_NYUDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_NYUDT_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_NYUDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_NYUDT, Button, Shift, X, Y)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_NYUDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_NYUDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUDT.TextChanged
        Debug.Print("HD_NYUDT_Change")
        Call Ctl_Item_Change(HD_NYUDT)
    End Sub

    Private Sub HD_NYUDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUDT.Enter
        Debug.Print("HD_NYUDT_GotFocus")
        Call Ctl_Item_GotFocus(HD_NYUDT)
    End Sub

    Private Sub HD_NYUDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NYUDT.Leave
        Debug.Print("HD_NYUDT_LostFocus")
        Call Ctl_Item_LostFocus(HD_NYUDT)
    End Sub

    Private Sub HD_NYUDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NYUDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NYUDT_KeyDown")
        Call Ctl_Item_KeyDown(HD_NYUDT, KeyCode, Shift)
    End Sub

    Private Sub HD_NYUDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NYUDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_NYUDT_KeyPress")
        Call Ctl_Item_KeyPress(HD_NYUDT, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_NYUDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NYUDT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NYUDT_KeyUp")
        Call Ctl_Item_KeyUp(HD_NYUDT)
    End Sub

    Private Sub HD_NYUDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NYUDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NYUDT_MouseDown")
        Call Ctl_Item_MouseDown(HD_NYUDT, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NYUDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NYUDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NYUDT_MouseUp")
        Call Ctl_Item_MouseUp(HD_NYUDT, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F������
    'UPGRADE_WARNING: �C�x���g HD_TOKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
        Debug.Print("HD_TOKCD_Change")
        Call Ctl_Item_Change(HD_TOKCD)
    End Sub

    Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
        Debug.Print("HD_TOKCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_TOKCD)
    End Sub

    Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
        Debug.Print("HD_TOKCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_TOKCD)
    End Sub

    Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
    End Sub

    Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TOKCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TOKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_TOKCD)
    End Sub

    Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TOKRN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.TextChanged
        Debug.Print("HD_TOKRN_Change")
        Call Ctl_Item_Change(HD_TOKRN)
    End Sub

    Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter
        Debug.Print("HD_TOKRN_GotFocus")
        Call Ctl_Item_GotFocus(HD_TOKRN)
    End Sub

    Private Sub HD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Leave
        Debug.Print("HD_TOKRN_LostFocus")
        Call Ctl_Item_LostFocus(HD_TOKRN)
    End Sub

    Private Sub HD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKRN_KeyDown")
        Call Ctl_Item_KeyDown(HD_TOKRN, KeyCode, Shift)
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

    Private Sub HD_TOKRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKRN_KeyUp")
        Call Ctl_Item_KeyUp(HD_TOKRN)
    End Sub

    Private Sub HD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKRN_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKRN_MouseUp")
        Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F�ʉ�
    'UPGRADE_WARNING: �C�x���g HD_TUKKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TUKKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TUKKB.TextChanged
        Debug.Print("HD_TUKKB_Change")
        Call Ctl_Item_Change(HD_TUKKB)
    End Sub

    Private Sub HD_TUKKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TUKKB.Enter
        Debug.Print("HD_TUKKB_GotFocus")
        Call Ctl_Item_GotFocus(HD_TUKKB)
    End Sub

    Private Sub HD_TUKKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TUKKB.Leave
        Debug.Print("HD_TUKKB_LostFocus")
        Call Ctl_Item_LostFocus(HD_TUKKB)
    End Sub

    Private Sub HD_TUKKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TUKKB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TUKKB_KeyDown")
        Call Ctl_Item_KeyDown(HD_TUKKB, KeyCode, Shift)
    End Sub

    Private Sub HD_TUKKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TUKKB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TUKKB_KeyPress")
        Call Ctl_Item_KeyPress(HD_TUKKB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TUKKB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TUKKB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TUKKB_KeyUp")
        Call Ctl_Item_KeyUp(HD_TUKKB)
    End Sub

    Private Sub HD_TUKKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TUKKB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TUKKB_MouseDown")
        Call Ctl_Item_MouseDown(HD_TUKKB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TUKKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TUKKB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TUKKB_MouseUp")
        Call Ctl_Item_MouseUp(HD_TUKKB, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F�������
    Private Sub CS_KNJKOZ_Click()
        Debug.Print("CS_KNJKOZ_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_KNJKOZ)
    End Sub

    Private Sub CS_KNJKOZ_GotFocus()
        Debug.Print("CS_KNJKOZ_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_KNJKOZ)
    End Sub

    Private Sub CS_KNJKOZ_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_KNJKOZ_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_KNJKOZ, Button, Shift, X, Y)
    End Sub

    Private Sub CS_KNJKOZ_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_KNJKOZ_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KNJKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_KNJKOZ, Button, Shift, X, Y)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_KNJKOZ.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_KNJKOZ_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KNJKOZ.TextChanged
        Debug.Print("HD_KNJKOZ_Change")
        Call Ctl_Item_Change(HD_KNJKOZ)
    End Sub

    Private Sub HD_KNJKOZ_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KNJKOZ.Enter
        Debug.Print("HD_KNJKOZ_GotFocus")
        Call Ctl_Item_GotFocus(HD_KNJKOZ)
    End Sub

    Private Sub HD_KNJKOZ_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KNJKOZ.Leave
        Debug.Print("HD_KNJKOZ_LostFocus")
        Call Ctl_Item_LostFocus(HD_KNJKOZ)
    End Sub

    Private Sub HD_KNJKOZ_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KNJKOZ.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KNJKOZ_KeyDown")
        Call Ctl_Item_KeyDown(HD_KNJKOZ, KeyCode, Shift)
    End Sub

    Private Sub HD_KNJKOZ_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KNJKOZ.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KNJKOZ_KeyPress")
        Call Ctl_Item_KeyPress(HD_KNJKOZ, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KNJKOZ_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KNJKOZ.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KNJKOZ_KeyUp")
        Call Ctl_Item_KeyUp(HD_KNJKOZ)
    End Sub

    Private Sub HD_KNJKOZ_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KNJKOZ.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KNJKOZ_MouseDown")
        Call Ctl_Item_MouseDown(HD_KNJKOZ, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KNJKOZ_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KNJKOZ.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KNJKOZ_MouseUp")
        Call Ctl_Item_MouseUp(HD_KNJKOZ, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���o�F���͒S����
    'UPGRADE_WARNING: �C�x���g HD_IN_TANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_IN_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.TextChanged
        Debug.Print("HD_IN_TANCD_Change")
        Call Ctl_Item_Change(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
        Debug.Print("HD_IN_TANCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
        Debug.Print("HD_IN_TANCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_IN_TANCD, KeyCode, Shift)
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

    Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_IN_TANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_IN_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.TextChanged
        Debug.Print("HD_IN_TANNM_Change")
        Call Ctl_Item_Change(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
        Debug.Print("HD_IN_TANNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
        Debug.Print("HD_IN_TANNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_IN_TANNM, KeyCode, Shift)
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

    Private Sub HD_IN_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '����(�J�����w�b�_)�F�������
    'change 20190729 START hou
    'Private Sub CS_DKBID_Click()
    Private Sub CS_DKBID_Click(sender As Object, e As EventArgs) Handles CS_DKBID.Click
        'change 20190729 END hou
        Debug.Print("CS_DKBID_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_DKBID)
    End Sub

    Private Sub CS_DKBID_GotFocus()
        Debug.Print("CS_DKBID_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_DKBID)
    End Sub

    Private Sub CS_DKBID_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_DKBID_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_DKBID, Button, Shift, X, Y)
    End Sub

    Private Sub CS_DKBID_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_DKBID_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_DKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_DKBID, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '����(�J�����w�b�_)�F�������
    'change 20190729 START hou
    ' Private Sub CS_KANKOZ_Click()
    Private Sub CS_KANKOZ_Click(sender As Object, e As EventArgs) Handles CS_KANKOZ.Click
        'change 20190729 END hou
        Debug.Print("CS_KANKOZ_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_KANKOZ)
    End Sub

    Private Sub CS_KANKOZ_GotFocus()
        Debug.Print("CS_KANKOZ_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_KANKOZ)
    End Sub

    Private Sub CS_KANKOZ_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_KANKOZ_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_KANKOZ, Button, Shift, X, Y)
    End Sub

    Private Sub CS_KANKOZ_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_KANKOZ_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_KANKOZ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_KANKOZ, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '����(�J�����w�b�_)�F��s�R�[�h
    'change 20190729 START hou
    ' Private Sub CS_BNKCD_Click()
    Private Sub CS_BNKCD_Click(sender As Object, e As EventArgs) Handles CS_BNKCD.Click
        'change 20190729 END hou
        Debug.Print("CS_BNKCD_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_BNKCD)
    End Sub

    Private Sub CS_BNKCD_GotFocus()
        Debug.Print("CS_BNKCD_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_BNKCD)
    End Sub

    Private Sub CS_BNKCD_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_BNKCD_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_BNKCD, Button, Shift, X, Y)
    End Sub

    Private Sub CS_BNKCD_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_BNKCD_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_BNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_BNKCD, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '����(�J�����w�b�_)�F���ϓ�
    'change 20190729 START hou
    'Private Sub CS_TEGDT_Click()
    Private Sub CS_TEGDT_Click(sender As Object, e As EventArgs) Handles CS_TEGDT.Click
        'change 20190729 END hou
        Debug.Print("CS_TEGDT_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_TEGDT)
    End Sub

    Private Sub CS_TEGDT_GotFocus()
        Debug.Print("CS_TEGDT_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_TEGDT)
    End Sub

    Private Sub CS_TEGDT_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_TEGDT_MouseDown")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseDown(CS_TEGDT, Button, Shift, X, Y)
    End Sub

    Private Sub CS_TEGDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_TEGDT_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_TEGDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_TEGDT, Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁFNo
    'UPGRADE_WARNING: �C�x���g BD_LINNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.TextChanged
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_Change")
        Call Ctl_Item_Change(BD_LINNO(Index))
    End Sub

    Private Sub BD_LINNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Enter
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINNO(Index))
    End Sub

    Private Sub BD_LINNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Leave
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINNO(Index))
    End Sub

    Private Sub BD_LINNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINNO(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_LINNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_KeyPress")
        Call Ctl_Item_KeyPress(BD_LINNO(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_LINNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINNO(Index))
    End Sub

    Private Sub BD_LINNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_MouseDown")
        Call Ctl_Item_MouseDown(BD_LINNO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_LINNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_MouseUp")
        Call Ctl_Item_MouseUp(BD_LINNO(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�������(�R�[�h)
    'UPGRADE_WARNING: �C�x���g BD_DKBID.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_DKBID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBID.TextChanged
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_Change")
        Call Ctl_Item_Change(BD_DKBID(Index))
    End Sub

    Private Sub BD_DKBID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBID.Enter
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_GotFocus")
        Call Ctl_Item_GotFocus(BD_DKBID(Index))
    End Sub

    Private Sub BD_DKBID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBID.Leave
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_LostFocus")
        Call Ctl_Item_LostFocus(BD_DKBID(Index))
    End Sub

    Private Sub BD_DKBID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_DKBID.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_KeyDown")
        Call Ctl_Item_KeyDown(BD_DKBID(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_DKBID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_DKBID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_KeyPress")
        Call Ctl_Item_KeyPress(BD_DKBID(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_DKBID_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_DKBID.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_KeyUp")
        Call Ctl_Item_KeyUp(BD_DKBID(Index))
    End Sub

    Private Sub BD_DKBID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_DKBID.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_MouseDown")
        Call Ctl_Item_MouseDown(BD_DKBID(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_DKBID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_DKBID.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_DKBID.GetIndex(eventSender)
        Debug.Print("BD_DKBID_MouseUp")
        Call Ctl_Item_MouseUp(BD_DKBID(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�������(����)
    'UPGRADE_WARNING: �C�x���g BD_DKBNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_DKBNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBNM.TextChanged
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_Change")
        Call Ctl_Item_Change(BD_DKBNM(Index))
    End Sub

    Private Sub BD_DKBNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBNM.Enter
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_GotFocus")
        Call Ctl_Item_GotFocus(BD_DKBNM(Index))
    End Sub

    Private Sub BD_DKBNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_DKBNM.Leave
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_LostFocus")
        Call Ctl_Item_LostFocus(BD_DKBNM(Index))
    End Sub

    Private Sub BD_DKBNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_DKBNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_KeyDown")
        Call Ctl_Item_KeyDown(BD_DKBNM(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_DKBNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_DKBNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_KeyPress")
        Call Ctl_Item_KeyPress(BD_DKBNM(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_DKBNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_DKBNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_KeyUp")
        Call Ctl_Item_KeyUp(BD_DKBNM(Index))
    End Sub

    Private Sub BD_DKBNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_DKBNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_MouseDown")
        Call Ctl_Item_MouseDown(BD_DKBNM(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_DKBNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_DKBNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_DKBNM.GetIndex(eventSender)
        Debug.Print("BD_DKBNM_MouseUp")
        Call Ctl_Item_MouseUp(BD_DKBNM(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�������
    'UPGRADE_WARNING: �C�x���g BD_KANKOZ.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_KANKOZ_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_KANKOZ.TextChanged
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_Change")
        Call Ctl_Item_Change(BD_KANKOZ(Index))
    End Sub

    Private Sub BD_KANKOZ_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_KANKOZ.Enter
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_GotFocus")
        Call Ctl_Item_GotFocus(BD_KANKOZ(Index))
    End Sub

    Private Sub BD_KANKOZ_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_KANKOZ.Leave
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_LostFocus")
        Call Ctl_Item_LostFocus(BD_KANKOZ(Index))
    End Sub

    Private Sub BD_KANKOZ_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_KANKOZ.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_KeyDown")
        Call Ctl_Item_KeyDown(BD_KANKOZ(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_KANKOZ_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_KANKOZ.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_KeyPress")
        Call Ctl_Item_KeyPress(BD_KANKOZ(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_KANKOZ_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_KANKOZ.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_KeyUp")
        Call Ctl_Item_KeyUp(BD_KANKOZ(Index))
    End Sub

    Private Sub BD_KANKOZ_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_KANKOZ.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_MouseDown")
        Call Ctl_Item_MouseDown(BD_KANKOZ(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_KANKOZ_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_KANKOZ.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_KANKOZ.GetIndex(eventSender)
        Debug.Print("BD_KANKOZ_MouseUp")
        Call Ctl_Item_MouseUp(BD_KANKOZ(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�����z(�~)
    'UPGRADE_WARNING: �C�x���g BD_NYUKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_NYUKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUKN.TextChanged
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_Change")
        Call Ctl_Item_Change(BD_NYUKN(Index))
    End Sub

    Private Sub BD_NYUKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUKN.Enter
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_GotFocus")
        Call Ctl_Item_GotFocus(BD_NYUKN(Index))
    End Sub

    Private Sub BD_NYUKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_NYUKN.Leave
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_LostFocus")
        Call Ctl_Item_LostFocus(BD_NYUKN(Index))
    End Sub

    Private Sub BD_NYUKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_KeyDown")
        Call Ctl_Item_KeyDown(BD_NYUKN(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_NYUKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_NYUKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_KeyPress")
        Call Ctl_Item_KeyPress(BD_NYUKN(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_NYUKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_NYUKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_KeyUp")
        Call Ctl_Item_KeyUp(BD_NYUKN(Index))
    End Sub

    Private Sub BD_NYUKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_MouseDown")
        Call Ctl_Item_MouseDown(BD_NYUKN(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_NYUKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_NYUKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_NYUKN.GetIndex(eventSender)
        Debug.Print("BD_NYUKN_MouseUp")
        Call Ctl_Item_MouseUp(BD_NYUKN(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�����z(�O��)
    'UPGRADE_WARNING: �C�x���g BD_FNYUKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_FNYUKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FNYUKN.TextChanged
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_Change")
        Call Ctl_Item_Change(BD_FNYUKN(Index))
    End Sub

    Private Sub BD_FNYUKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FNYUKN.Enter
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_GotFocus")
        Call Ctl_Item_GotFocus(BD_FNYUKN(Index))
    End Sub

    Private Sub BD_FNYUKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_FNYUKN.Leave
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_LostFocus")
        Call Ctl_Item_LostFocus(BD_FNYUKN(Index))
    End Sub

    Private Sub BD_FNYUKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_FNYUKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_KeyDown")
        Call Ctl_Item_KeyDown(BD_FNYUKN(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_FNYUKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_FNYUKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_KeyPress")
        Call Ctl_Item_KeyPress(BD_FNYUKN(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_FNYUKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_FNYUKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_KeyUp")
        Call Ctl_Item_KeyUp(BD_FNYUKN(Index))
    End Sub

    Private Sub BD_FNYUKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_FNYUKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_MouseDown")
        Call Ctl_Item_MouseDown(BD_FNYUKN(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_FNYUKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_FNYUKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_FNYUKN.GetIndex(eventSender)
        Debug.Print("BD_FNYUKN_MouseUp")
        Call Ctl_Item_MouseUp(BD_FNYUKN(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF��s�R�[�h
    'UPGRADE_WARNING: �C�x���g BD_BNKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_BNKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKCD.TextChanged
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_Change")
        Call Ctl_Item_Change(BD_BNKCD(Index))
    End Sub

    Private Sub BD_BNKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKCD.Enter
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_GotFocus")
        Call Ctl_Item_GotFocus(BD_BNKCD(Index))
    End Sub

    Private Sub BD_BNKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKCD.Leave
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_LostFocus")
        Call Ctl_Item_LostFocus(BD_BNKCD(Index))
    End Sub

    Private Sub BD_BNKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BNKCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_KeyDown")
        Call Ctl_Item_KeyDown(BD_BNKCD(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_BNKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BNKCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_KeyPress")
        Call Ctl_Item_KeyPress(BD_BNKCD(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_BNKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BNKCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_KeyUp")
        Call Ctl_Item_KeyUp(BD_BNKCD(Index))
    End Sub

    Private Sub BD_BNKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BNKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_MouseDown")
        Call Ctl_Item_MouseDown(BD_BNKCD(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BNKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BNKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BNKCD.GetIndex(eventSender)
        Debug.Print("BD_BNKCD_MouseUp")
        Call Ctl_Item_MouseUp(BD_BNKCD(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF��s����
    'UPGRADE_WARNING: �C�x���g BD_BNKNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_BNKNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKNM.TextChanged
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_Change")
        Call Ctl_Item_Change(BD_BNKNM(Index))
    End Sub

    Private Sub BD_BNKNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKNM.Enter
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_GotFocus")
        Call Ctl_Item_GotFocus(BD_BNKNM(Index))
    End Sub

    Private Sub BD_BNKNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_BNKNM.Leave
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_LostFocus")
        Call Ctl_Item_LostFocus(BD_BNKNM(Index))
    End Sub

    Private Sub BD_BNKNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BNKNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_KeyDown")
        Call Ctl_Item_KeyDown(BD_BNKNM(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_BNKNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_BNKNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_KeyPress")
        Call Ctl_Item_KeyPress(BD_BNKNM(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_BNKNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_BNKNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_KeyUp")
        Call Ctl_Item_KeyUp(BD_BNKNM(Index))
    End Sub

    Private Sub BD_BNKNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BNKNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_MouseDown")
        Call Ctl_Item_MouseDown(BD_BNKNM(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_BNKNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_BNKNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_BNKNM.GetIndex(eventSender)
        Debug.Print("BD_BNKNM_MouseUp")
        Call Ctl_Item_MouseUp(BD_BNKNM(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�󒍔ԍ�
    'UPGRADE_WARNING: �C�x���g BD_JDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_JDNNO.TextChanged
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_Change")
        Call Ctl_Item_Change(BD_JDNNO(Index))
    End Sub

    Private Sub BD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_JDNNO.Enter
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_GotFocus")
        Call Ctl_Item_GotFocus(BD_JDNNO(Index))
    End Sub

    Private Sub BD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_JDNNO.Leave
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_LostFocus")
        Call Ctl_Item_LostFocus(BD_JDNNO(Index))
    End Sub

    Private Sub BD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_JDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_KeyDown")
        Call Ctl_Item_KeyDown(BD_JDNNO(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_JDNNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_KeyPress")
        Call Ctl_Item_KeyPress(BD_JDNNO(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_JDNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_JDNNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_KeyUp")
        Call Ctl_Item_KeyUp(BD_JDNNO(Index))
    End Sub

    Private Sub BD_JDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_JDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_MouseDown")
        Call Ctl_Item_MouseDown(BD_JDNNO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_JDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_JDNNO.GetIndex(eventSender)
        Debug.Print("BD_JDNNO_MouseUp")
        Call Ctl_Item_MouseUp(BD_JDNNO(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF�x�X����
    'UPGRADE_WARNING: �C�x���g BD_STNNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_STNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_STNNM.TextChanged
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_Change")
        Call Ctl_Item_Change(BD_STNNM(Index))
    End Sub

    Private Sub BD_STNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_STNNM.Enter
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_GotFocus")
        Call Ctl_Item_GotFocus(BD_STNNM(Index))
    End Sub

    Private Sub BD_STNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_STNNM.Leave
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_LostFocus")
        Call Ctl_Item_LostFocus(BD_STNNM(Index))
    End Sub

    Private Sub BD_STNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_STNNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_KeyDown")
        Call Ctl_Item_KeyDown(BD_STNNM(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_STNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_STNNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_KeyPress")
        Call Ctl_Item_KeyPress(BD_STNNM(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_STNNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_STNNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_KeyUp")
        Call Ctl_Item_KeyUp(BD_STNNM(Index))
    End Sub

    Private Sub BD_STNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_STNNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_MouseDown")
        Call Ctl_Item_MouseDown(BD_STNNM(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_STNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_STNNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_STNNM.GetIndex(eventSender)
        Debug.Print("BD_STNNM_MouseUp")
        Call Ctl_Item_MouseUp(BD_STNNM(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF���ϓ�
    'UPGRADE_WARNING: �C�x���g BD_TEGDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_TEGDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGDT.TextChanged
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_Change")
        Call Ctl_Item_Change(BD_TEGDT(Index))
    End Sub

    Private Sub BD_TEGDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGDT.Enter
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_GotFocus")
        Call Ctl_Item_GotFocus(BD_TEGDT(Index))
    End Sub

    Private Sub BD_TEGDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGDT.Leave
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_LostFocus")
        Call Ctl_Item_LostFocus(BD_TEGDT(Index))
    End Sub

    Private Sub BD_TEGDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEGDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_KeyDown")
        Call Ctl_Item_KeyDown(BD_TEGDT(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_TEGDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TEGDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_KeyPress")
        Call Ctl_Item_KeyPress(BD_TEGDT(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_TEGDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEGDT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_KeyUp")
        Call Ctl_Item_KeyUp(BD_TEGDT(Index))
    End Sub

    Private Sub BD_TEGDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEGDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_MouseDown")
        Call Ctl_Item_MouseDown(BD_TEGDT(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_TEGDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEGDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEGDT.GetIndex(eventSender)
        Debug.Print("BD_TEGDT_MouseUp")
        Call Ctl_Item_MouseUp(BD_TEGDT(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF��`�ԍ�
    'UPGRADE_WARNING: �C�x���g BD_TEGNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_TEGNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGNO.TextChanged
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_Change")
        Call Ctl_Item_Change(BD_TEGNO(Index))
    End Sub

    Private Sub BD_TEGNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGNO.Enter
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_GotFocus")
        Call Ctl_Item_GotFocus(BD_TEGNO(Index))
    End Sub

    Private Sub BD_TEGNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEGNO.Leave
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_LostFocus")
        Call Ctl_Item_LostFocus(BD_TEGNO(Index))
    End Sub

    Private Sub BD_TEGNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEGNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_KeyDown")
        Call Ctl_Item_KeyDown(BD_TEGNO(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_TEGNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TEGNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_KeyPress")
        Call Ctl_Item_KeyPress(BD_TEGNO(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_TEGNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEGNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_KeyUp")
        Call Ctl_Item_KeyUp(BD_TEGNO(Index))
    End Sub

    Private Sub BD_TEGNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEGNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_MouseDown")
        Call Ctl_Item_MouseDown(BD_TEGNO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_TEGNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEGNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEGNO.GetIndex(eventSender)
        Debug.Print("BD_TEGNO_MouseUp")
        Call Ctl_Item_MouseUp(BD_TEGNO(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF���l�P
    'UPGRADE_WARNING: �C�x���g BD_LINCMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINCMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.TextChanged
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_Change")
        Call Ctl_Item_Change(BD_LINCMA(Index))
    End Sub

    Private Sub BD_LINCMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Enter
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINCMA(Index))
    End Sub

    Private Sub BD_LINCMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Leave
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINCMA(Index))
    End Sub

    Private Sub BD_LINCMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINCMA(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_LINCMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINCMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_KeyPress")
        Call Ctl_Item_KeyPress(BD_LINCMA(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_LINCMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINCMA(Index))
    End Sub

    Private Sub BD_LINCMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_MouseDown")
        Call Ctl_Item_MouseDown(BD_LINCMA(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_LINCMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_MouseUp")
        Call Ctl_Item_MouseUp(BD_LINCMA(Index), Button, Shift, X, Y)
    End Sub

    '**************************************************
    '���ׁF���l�Q
    'UPGRADE_WARNING: �C�x���g BD_LINCMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINCMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.TextChanged
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_Change")
        Call Ctl_Item_Change(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Enter
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Leave
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINCMB(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_LINCMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_LINCMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_KeyPress")
        Call Ctl_Item_KeyPress(BD_LINCMB(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_LINCMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_MouseDown")
        Call Ctl_Item_MouseDown(BD_LINCMB(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_LINCMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_MouseUp")
        Call Ctl_Item_MouseUp(BD_LINCMB(Index), Button, Shift, X, Y)
    End Sub
    '
    ''**************************************************
    ''�e�C���F���v(�~)
    'Private Sub TL_SBANYUKN_Change()
    '    Debug.Print "TL_SBANYUKN_Change"
    '    Call Ctl_Item_Change(TL_SBANYUKN)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_GotFocus()
    '    Debug.Print "TL_SBANYUKN_GotFocus"
    '    Call Ctl_Item_GotFocus(TL_SBANYUKN)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_LostFocus()
    '    Debug.Print "TL_SBANYUKN_LostFocus"
    '    Call Ctl_Item_LostFocus(TL_SBANYUKN)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_KeyDown(KEYCODE As Integer, Shift As Integer)
    '    Debug.Print "TL_SBANYUKN_KeyDown"
    '    Call Ctl_Item_KeyDown(TL_SBANYUKN, KEYCODE, Shift)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_KeyPress(KeyAscii As Integer)
    '    Debug.Print "TL_SBANYUKN_KeyPress"
    '    Call Ctl_Item_KeyPress(TL_SBANYUKN, KeyAscii)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_KeyUp(KEYCODE As Integer, Shift As Integer)
    '    Debug.Print "TL_SBANYUKN_KeyUp"
    '    Call Ctl_Item_KeyUp(TL_SBANYUKN)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "TL_SBANYUKN_MouseDown"
    '    Call Ctl_Item_MouseDown(TL_SBANYUKN, Button, Shift, X, Y)
    'End Sub
    '
    'Private Sub TL_SBANYUKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "TL_SBANYUKN_MouseUp"
    '    Call Ctl_Item_MouseUp(TL_SBANYUKN, Button, Shift, X, Y)
    'End Sub
    '
    ''**************************************************
    ''�e�C���F���v(�C�O)
    'Private Sub TL_SBAFRNKN_Change()
    '    Debug.Print "TL_SBAFRNKN_Change"
    '    Call Ctl_Item_Change(TL_SBAFRNKN)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_GotFocus()
    '    Debug.Print "TL_SBAFRNKN_GotFocus"
    '    Call Ctl_Item_GotFocus(TL_SBAFRNKN)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_LostFocus()
    '    Debug.Print "TL_SBAFRNKN_LostFocus"
    '    Call Ctl_Item_LostFocus(TL_SBAFRNKN)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_KeyDown(KEYCODE As Integer, Shift As Integer)
    '    Debug.Print "TL_SBAFRNKN_KeyDown"
    '    Call Ctl_Item_KeyDown(TL_SBAFRNKN, KEYCODE, Shift)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_KeyPress(KeyAscii As Integer)
    '    Debug.Print "TL_SBAFRNKN_KeyPress"
    '    Call Ctl_Item_KeyPress(TL_SBAFRNKN, KeyAscii)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_KeyUp(KEYCODE As Integer, Shift As Integer)
    '    Debug.Print "TL_SBAFRNKN_KeyUp"
    '    Call Ctl_Item_KeyUp(TL_SBAFRNKN)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "TL_SBAFRNKN_MouseDown"
    '    Call Ctl_Item_MouseDown(TL_SBAFRNKN, Button, Shift, X, Y)
    'End Sub
    '
    'Private Sub TL_SBAFRNKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "TL_SBAFRNKN_MouseUp"
    '    Call Ctl_Item_MouseUp(TL_SBAFRNKN, Button, Shift, X, Y)
    'End Sub

    '2019/05/23 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD_KET52(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '���͒S���҃R�[�h
            'UPGRADE_ISSUE: Control HD_IN_TANCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '���͒S���Җ�
            'UPGRADE_ISSUE: Control HD_IN_TANNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '2019/05/23 ADD END

    '2019/06/05 ADD START
    Private Sub CS_DATNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_DATNO.Click
        Call Ctl_Item_Click(CS_DATNO)
    End Sub

    Private Sub CS_NYUDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_NYUDT.Click
        Call Ctl_Item_Click(CS_NYUDT)
    End Sub

    'Private Sub CS_TOKCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_TOKCD.Click
    '    Call Ctl_Item_Click(CS_TOKCD)
    'End Sub

    'Private Sub CS_TUKKB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_TUKKB.Click
    '    Call Ctl_Item_Click(btnF12)
    'End Sub

    Private Sub CS_KNJKOZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CS_KNJKOZ.Click
        Call Ctl_Item_Click(CS_KNJKOZ)
    End Sub

    Private Sub BD_LINNO_MouseCaptureChanged(sender As Object, e As EventArgs) Handles BD_LINNO.MouseCaptureChanged

    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub btnF12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF12.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
        Call Ctl_Item_Click(btnF11)
    End Sub

    Private Sub btnF11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF11.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        Call Ctl_Item_Click(btnF10)
    End Sub

    Private Sub btnF10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF10.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF9.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Call Ctl_Item_Click(btnF8)
    End Sub

    Private Sub btnF8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF8.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
        Call Ctl_Item_Click(btnF7)
    End Sub

    Private Sub btnF7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF7.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
        Call Ctl_Item_Click(btnF6)
    End Sub

    Private Sub btnF6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF6.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
        Call Ctl_Item_Click(btnF5)
    End Sub

    Private Sub btnF5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF5.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Call Ctl_Item_Click(btnF4)
    End Sub

    Private Sub btnF4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF4.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Call Ctl_Item_Click(btnF3)
    End Sub

    Private Sub btnF3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF3.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Call Ctl_Item_Click(btnF2)
    End Sub

    Private Sub btnF2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF2.KeyDown
        FKeyDown(sender, e)
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Call Ctl_Item_Click(btnF1)
    End Sub

    Private Sub btnF1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnF1.KeyDown
        FKeyDown(sender, e)
    End Sub
    '2019/06/05 ADD END

    '2019/06/05 ADD START
    Public Function SetBar(ByRef po_Form As Form) As Boolean

        '--------------------------------------------------------------------------
        '�ϐ��̒�`
        '--------------------------------------------------------------------------
        Dim li_MsgRtn As Integer    'MsgBox�̖߂�l

        '--------------------------------------------------------------------------
        '�G���[�g���b�v�錾
        '--------------------------------------------------------------------------
        Try
            '--------------------------------------------------------------------------
            '�����J�n
            '--------------------------------------------------------------------------
            '---�߂�l�ݒ�---'
            SetBar = False

            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
            DirectCast(po_Form.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = SSS_PrgId

            '---�߂�l�ݒ�---'
            SetBar = True

            '--------------------------------------------------------------------------
            '�G���[�g���b�v���[�`��
            '--------------------------------------------------------------------------
        Catch ex As Exception
            li_MsgRtn = MsgBox("�����ް,�ð���ް�ݒ�֐��G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    Private Sub FKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F3
                    Me.btnF3.PerformClick()

                Case Keys.F4
                    Me.btnF4.PerformClick()

                Case Keys.F5
                    Me.btnF5.PerformClick()

                Case Keys.F6
                    Me.btnF6.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F10
                    Me.btnF10.PerformClick()

                Case Keys.F11
                    Me.btnF11.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub
    '2019/06/05 ADD END

    'add 20190730 START hou
    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        FKeyDown(sender, e)
    End Sub
    'add 20190
End Class