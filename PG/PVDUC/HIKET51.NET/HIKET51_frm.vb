Option Strict Off
Option Explicit On
Friend Class FR_SSSMAIN
    Inherits System.Windows.Forms.Form
    'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.

    '���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
    '=== ����ʂ̑S�����i�[ =================
    'UPGRADE_WARNING: �\���� Main_Inf �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    Private Main_Inf As Cls_All
    '=== ����ʂ̑S�����i�[ =================
    Private Const FM_PANEL3D1_CNT As Short = 35 '�p�l���R���g���[����
    '2019/09/20 ADD START
    Private FORM_LOAD_FLG As Boolean = False
    '2019/09/20 ADD END
    '2019/09/20 ADD START
    Private FORM_CLOSE_FLG As Boolean = False
    '2019/09/20 ADD END

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
        Main_Inf.On_IM_Denkyu = IM_Denkyu(1)
        Main_Inf.Off_IM_Denkyu = IM_Denkyu(2)
        Main_Inf.Dsp_TX_Message = TX_Message


        '��ʊ�b���ݒ�
        With Main_Inf.Dsp_Base
            .Dsp_Ctg = DSP_CTG_REFERENCE '��ʕ���
            '2019/09/20 CHG START
            '.Item_Cnt = 200 '��ʍ��ڐ�
            .Item_Cnt = 165 '��ʍ��ڐ�
            '2019/09/20 CHG END
            .Dsp_Body_Cnt = 6 '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
            .Max_Body_Cnt = 0 '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
            .Body_Col_Cnt = 17 '���ׂ̗񍀖ڐ�
            .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1 '��ʈړ���
            ' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
            .FormCtl = Me
            ' === 20060920 === INSERT E
        End With

        '    '���׏��p�z�񏉊���
        '    Erase HIKET51_DSP_BD_DATA_Inf
        '    ReDim HIKET51_DSP_BD_DATA_Inf(Main_Inf.Dsp_Base.Dsp_Body_Cnt)

        '�I�𖾍׃I�v�V�����{�^���摜�ݒ��
        HIKET51_Bd_Sel_Img.Click_Off_Img = IM_Opt(0)
        HIKET51_Bd_Sel_Img.Click_On_Img = IM_Opt(1)

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
        '���s
        '2019/09/26 CHG START
        'MN_Execute.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
        btnF2.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF2
        '2019/09/26 CHG END
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
        '2019/09/26 CHG START
        'MN_EndCm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
        btnF12.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF12
        '2019/09/26 CHG END
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
        '2019/09/26 CHG START
        'MN_ClearItm.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm        
        btnF9.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF9
        '2019/09/26 CHG END
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
        '�O�y�[�W
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
        '���y�[�W
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
        '���̈ꗗ
        '2019/09/26 CHG START
        'MN_Slist.Tag = CStr(Index_Wk)
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
        btnF5.Tag = CStr(Index_Wk)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF5
        '2019/09/26 CHG END
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
        '������ʕ\���C���[�W
        CM_SLIST.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
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
        Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
        Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
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
        '�����C���[�W        
        CM_SELECTCM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SELECTCM
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
        Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SELECTCM(0)
        Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SELECTCM(1)
        '=== �Ұ�ސݒ� ======================

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
        '�Ώی��ϔԍ��{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_MITNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_MITNO
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
        '�Ώی��ϔԍ�
        HD_MITNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNO
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        ' === 20060802 === UPDATE S - ACE)Nagasawa ���ϔԍ��͐��l���͂Ƃ���
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        ' === 20180412 === UPDATE S - FJ)koroyasu ���ϔԍ��͉p����(���p�啶��)���͂Ƃ���
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        ' === 20180412 === UPDATE E -
        ' === 20060802 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        ' === 20060802 === UPDATE S - ACE)Nagasawa ���ϔԍ��͐��l���͂Ƃ���
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        ' === 20180412 === UPDATE S - FJ)koroyasu ���ϔԍ��͉p����(���p�啶��)���͂Ƃ���
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(8)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        ' === 20180412 === UPDATE E -
        ' === 20060802 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '�Ő�
        HD_MITNOV.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNOV
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

        Index_Wk = Index_Wk + 1
        '�Ώێ󒍔ԍ��{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        CS_JDNNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNNO
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
        '�Ώێ󒍔ԍ�
        HD_JDNNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNNO
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        ' === 20061127 === UPDATE S - ACE)Nagasawa �R�[�h�̑啶���ϊ������ǉ�
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
        ' === 20061127 === UPDATE E -

        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
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

        '��ʊ�b���ݒ�
        Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

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
        '�󒍎���敪
        HD_JDNTRKB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�󒍎���敪(����)
        HD_JDNTRNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRNM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
        '�`�[���t
        HD_JDNDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNDT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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

        Index_Wk = Index_Wk + 1
        '�q�撍���ԍ�
        HD_TOKJDNNO.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKJDNNO
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 23
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 23
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 23
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
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
        '�q��[��
        HD_DEFNOKDT.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DEFNOKDT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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

        Index_Wk = Index_Wk + 1
        '�����s��
        HD_BUN_FUKA.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUN_FUKA
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
        '���Ӑ�(����)
        HD_TOKCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
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
        '���Ӑ�(����)
        HD_TOKRN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
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
        '�����P
        HD_KENNMA.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMA
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
        '�����Q
        HD_KENNMB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMB
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
        '�[����(����)
        HD_NHSCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSCD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 9
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
        '�[����(���̂P)
        HD_NHSNMA.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSNMA
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
        '�[����(���̂Q)
        HD_NHSNMB.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSNMB
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
        '�`�[���͒S����(����)
        HD_OPEID.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_OPEID
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
        '�`�[���͒S����(����)
        HD_OPENM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_OPENM
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
        '�c�ƒS����(����)
        HD_TANCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANCD
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
        '�c�ƒS����(����)
        HD_TANNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANNM
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
        '�c�ƕ���(����)
        HD_BUMCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUMCD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        ' === 20060802 === UPDATE S - ACE)Nagasawa  ����R�[�h�𕶎���ɕύX
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        ' === 20060802 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        ' === 20060802 === UPDATE S - ACE)Nagasawa  ����R�[�h�𕶎���ɕύX
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        ' === 20060802 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�c�ƕ���(����)
        HD_BUMNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUMNM
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
        '�o�בq��(����)
        HD_SOUCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUCD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 3
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�o�בq��(����)
        HD_SOUNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUNM
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
        '����(����)
        HD_URIKJN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_URIKJN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '����(����)
        HD_URIKJNNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_URIKJNNM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
        '�֖�(����)
        HD_BINCD.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BINCD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�֖�(����)
        HD_BINNM.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BINNM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
        '�I�𖾍׃I�v�V�����{�^��(�߸���)
        BD_SELECTB(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(1)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        '��ʊ�b���ݒ�
        Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

        Index_Wk = Index_Wk + 1
        'No
        BD_LINNO(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '���i�R�[�h
        BD_HINCD(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�q�撍���ԍ�
        BD_TOKJDNNO(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKJDNNO(1)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
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

        Index_Wk = Index_Wk + 1
        '�^��
        BD_HINNMA(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�i��
        BD_HINNMB(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMB(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '��������
        BD_GNKCD(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_GNKCD(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
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

        Index_Wk = Index_Wk + 1
        '����
        BD_UODSU(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU(1)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�P��
        BD_UNTNM(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UNTNM(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 4
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 4
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

        Index_Wk = Index_Wk + 1
        '�P��
        BD_UODTK(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODTK(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 11
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
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
        '�c�Ǝd��
        BD_SIKTK(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKTK(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 11
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
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
        '���z
        BD_UODKN(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
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
        '�艿
        BD_TEIKATK(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEIKATK(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
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
        '�d�ؗ�
        BD_SIKRT(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKRT(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        ' === 20070201 === UPDATE S - ACE)Yano
        '   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
        '   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
        '   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 3
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 4
        ' === 20070201 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Fra_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Sign_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Fil_Point �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
        '    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_RT_1
        ' === 20070201 === UPDATE S - ACE)Yano
        '   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = "#,##0.0��"
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = "0.0��"
        ' === 20070201 === UPDATE E -
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '�o�ח\���
        BD_ODNYTDT(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ODNYTDT(1)
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_Fmt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '���l�P
        BD_LINCMA(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        Index_Wk = Index_Wk + 1
        '���l�Q
        BD_LINCMB(1).Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(1)
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Focus_Ctl �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Locked �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

        For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
            BD_SELECTB.Load(BD_Cnt) '�I�𖾍׃I�v�V�����{�^��(�߸���(BD_Cnt)
            '        Load BD_SELECT(BD_Cnt)        '�I�𖾍׃I�v�V�����{�^��
            BD_LINNO.Load(BD_Cnt) 'No
            BD_HINCD.Load(BD_Cnt) '���i�R�[�h
            BD_TOKJDNNO.Load(BD_Cnt) '�q�撍���ԍ�
            BD_HINNMA.Load(BD_Cnt) '�^��
            BD_HINNMB.Load(BD_Cnt) '�i��
            BD_GNKCD.Load(BD_Cnt) '��������
            BD_UODSU.Load(BD_Cnt) '����
            BD_UNTNM.Load(BD_Cnt) '�P��
            BD_UODTK.Load(BD_Cnt) '�P��
            BD_SIKTK.Load(BD_Cnt) '�c�Ǝd��
            BD_UODKN.Load(BD_Cnt) '���z
            BD_TEIKATK.Load(BD_Cnt) '�艿
            BD_SIKRT.Load(BD_Cnt) '�d�ؗ�
            BD_ODNYTDT.Load(BD_Cnt) '�o�ח\���
            BD_LINCMA.Load(BD_Cnt) '���l�P
            BD_LINCMB.Load(BD_Cnt) '���l�Q

            Index_Wk = Index_Wk + 1
            '�I�𖾍׃I�v�V�����{�^��(�߸���)
            BD_SELECTB(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            'No
            BD_LINNO(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���i�R�[�h
            BD_HINCD(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�q�撍���ԍ�
            BD_TOKJDNNO(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKJDNNO(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�^��
            BD_HINNMA(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�i��
            BD_HINNMB(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMB(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '��������
            BD_GNKCD(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_GNKCD(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '����
            BD_UODSU(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�P��
            BD_UNTNM(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UNTNM(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�P��
            BD_UODTK(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODTK(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�c�Ǝd��
            BD_SIKTK(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKTK(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���z
            BD_UODKN(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�艿
            BD_TEIKATK(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEIKATK(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�d�ؗ�
            BD_SIKRT(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKRT(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '�o�ח\���
            BD_ODNYTDT(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ODNYTDT(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���l�P
            BD_LINCMA(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

            Index_Wk = Index_Wk + 1
            '���l�Q
            BD_LINCMB(BD_Cnt).Tag = Index_Wk
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(BD_Cnt)
            'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Body_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
            '���ו��̂P�s��̏���ݒ�
            Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Next

        '///////////////
        '// �t�b�^���ҏW
        '///////////////
        Index_Wk = Index_Wk + 1
        '�����^�����{�^��
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/26 CHG START
        'CS_HIK.Tag = Index_Wk
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HIK
        btnF6.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = btnF6
        '2019/09/26 CHG END
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
        '�{�̍��v���z
        TL_SBAUODKN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUODKN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
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
        '����Ŋz
        TL_SBAUZEKN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUZEKN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
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
        '�`�[���v���z
        TL_SBAUZKKN.Tag = Index_Wk
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUZKKN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.In_Str_Typ �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Dsp_MaxLengthB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf().Detail.Num_Int_Fig �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
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
        '2019/09/20 DELL START
        'For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        '    Index_Wk = Index_Wk + 1
        '    'FM_Panel3D1
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
        '2019/09/20 DELL END

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
        gv_bolHIKET51_LF_Enable = True

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
            ' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
            '�L�[�t���O�����ɖ߂�
            gv_bolKeyFlg = False
            ' === 20060905 === INSERT E -
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
            ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
            '        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            ' === 20061129 === UPDATE E -
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
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            Else
                '������ړ��Ȃ�
                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
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
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

                '���ڐF�ݒ�
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            End If
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
            '        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            ' === 20061129 === UPDATE E -
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
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            Else
                '������ړ��Ȃ�
                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
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
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

                '���ڐF�ݒ�
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            End If

        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
            '        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            ' === 20061129 === UPDATE E -
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

                ' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�����Ή�
                '�t�@���N�V�����L�[������
            Case pm_KeyCode >= System.Windows.Forms.Keys.F1 And pm_KeyCode <= System.Windows.Forms.Keys.F12
                '�t�@���N�V�����L�[���ʏ���
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
                ' === 20060930 === INSERT E -

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

        If gv_bolHIKET51_LF_Enable = False Then
            Exit Function
        End If

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
            ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
            '        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            ' === 20061129 === UPDATE E -

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
        Dim Wk_Index As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        '��ʒP�ʂ̏���(�����Ȃ�)
        '�@���ו���̫������󂯎�����ꍇ�̃w�b�_���̓��������Ȃ�
        '���ו��ł��ړ��O�����ו��łȂ��ꍇ
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
            '�r���������������������������������������������������������r
            'ͯ�ޕ�����
            Rtn_Chk = SSSMAIN0001.F_Ctl_Head_Chk(Main_Inf)
            '�d���������������������������������������������������������d
            If Rtn_Chk <> CHK_OK Then
                Exit Function
            End If
        End If

        ' === 20060802 === INSERT S - ACE)Nagasawa ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK.NAME �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        '2019/10/01 CHG START
        'If TypeOf pm_Ctl Is Button And pm_Ctl.Name <> CS_HIK.Name Then
        If TypeOf pm_Ctl Is Button And pm_Ctl.Name <> btnF6.Name Then
            '2019/10/01 CHG END
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
        ' === 20060802 === INSERT E

        '�A���ו����ł̎��s�ֈړ������ꍇ�������Ȃ�

        '����̫����擾����
        Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        ' === 20060907 === UPDATE S - ACE)Sejima �{�^���C���[�W������Ή�
        'D    '���j���[�g�p�ې���
        'D    Call F_Ctl_MN_Enabled(Main_Inf)
        ' === 20060907 === UPDATE ��
        '�����P
        Call Ctl_MN_Ctrl_Click()
        '�����Q
        Call Ctl_MN_EditMn_Click()
        '����R
        Call Ctl_MN_Oprt_Click()
        ' === 20060907 === UPDATE E

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
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
                Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
                ' === 20061129 === UPDATE E -
            End If

        Else
            '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
            ' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
            '        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
            ' === 20061129 === UPDATE E -
        End If

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANG����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_Item_Change(ByRef pm_Ctl As System.Windows.Forms.Control) As Short
        '2019/09/20 ADD START
        If FORM_LOAD_FLG = False Then
            Return 0
        End If
        '2019/09/20 ADD END

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

        ' === 20061205 === INSERT S - ACE)Nagasawa VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061205 === INSERT E -

        'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
        Select Case True
            Case TypeOf pm_Ctl Is System.Windows.Forms.TextBox
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
                '            '���ڐF�ݒ�
                '            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

            Case TypeOf pm_Ctl Is Label
                '�p�l���̏ꍇ
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

                ' === 20060802 === INSERT S - ACE)Nagasawa�@����W�{�^���Ή�
            Case TypeOf pm_Ctl Is Button
                '�{�^���̏ꍇ
                'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
                If TypeOf Main_Inf.Dsp_Sub_Inf(CShort(Me.ActiveControl.Tag)).Ctl Is Button Then
                    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                End If
                ' === 20060802 === INSERT E -

            Case TypeOf pm_Ctl Is System.Windows.Forms.PictureBox
                '�C���[�W�̏ꍇ
                Select Case Trg_Index
                    Case CShort(CM_EndCm.Tag)
                        '�I���Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                    Case CShort(CM_Execute.Tag)
                        '���s�Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)

                    Case CShort(CM_SLIST.Tag)
                        '������ʕ\���Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)

                    Case CShort(CM_SELECTCM.Tag)
                        '�����Ұ��
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)
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
                Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_Execute.Tag)
                '���s�Ұ��
                Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_SLIST.Tag)
                '������ʲҰ��
                Call CF_Set_Prompt(IMG_SLIST_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

            Case CShort(CM_SELECTCM.Tag)
                '�����H�Ұ��
                Call CF_Set_Prompt(IMG_SELECTCM_MSG_INF, System.Drawing.ColorTranslator.ToOle(ACE_CMN.COLOR_BLACK), Main_Inf)

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
            Case CShort(CM_EndCm.Tag)
                '�I���Ұ��
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

            Case CShort(CM_Execute.Tag)
                '���s�Ұ��
                Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

            Case CShort(CM_SLIST.Tag)
                '������ʕ\���Ұ��
                ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
                '�u�I���v����
                Select Case Act_Index
                    Case CShort(Me.HD_MITNO.Tag), CShort(Me.HD_MITNOV.Tag), CShort(Me.HD_JDNNO.Tag)

                        ' === 20060907 === INSERT E
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
                        ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�

                    Case Else

                End Select
                ' === 20060907 === INSERT E

            Case CShort(CM_SELECTCM.Tag)
                '�����Ұ��
                ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
                '�u�I���v����
                Select Case Act_Index
                    Case CShort(Me.HD_MITNO.Tag), CShort(Me.HD_MITNOV.Tag), CShort(Me.HD_JDNNO.Tag)

                    Case Else
                        ' === 20060907 === INSERT E
                        Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)
                        ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�

                End Select
                ' === 20060907 === INSERT E

        End Select

        ' === 20060922 === INSERT S - ACE)Sejima �I�v�V�����{�^���ɕύX��
        Select Case pm_Ctl.Name
            Case BD_SELECTB(1).Name
                '�I�𖾍׃I�v�V�����{�^���C���[�W
                Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
                Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case Else

        End Select
        ' === 20060922 === INSERT E

        '����MOUSEDOWN����
        Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

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
        Dim Wk_Index As Short

        '�������ޯ���擾
        Trg_Index = CShort(pm_Ctl.Tag)

        ' === 20070102 === INSERT S - ACE)Nagasawa �w�i�F�ύX
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case Trg_Index
            Case CShort(CM_SLIST.Tag), CShort(CS_MITNO.Tag), CShort(CS_JDNNO.Tag)

                If Main_Inf.Dsp_Base.Head_Ok_Flg = True Then
                    Exit Function
                End If
            Case Else
        End Select
        ' === 20070102 === INSERT E -

        '�e������ʌďo
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Select Case Trg_Index
            '�����j���[
            Case CShort(MN_Ctrl.Tag)
                '�����P
                Call Ctl_MN_Ctrl_Click()

                '2019/09/26 CHG START
            'Case CShort(MN_Execute.Tag)
            Case CShort(btnF2.Tag)
                '2019/09/26 CHG END
                '���s
                Call Ctl_MN_Execute_Click()

                '        Case CInt(MN_DeleteCM.Tag)
                '            '�폜
                '            Call Ctl_MN_DeleteCM_Click

            Case CShort(MN_HARDCOPY.Tag)
                '��ʈ��
                Call Ctl_MN_HARDCOPY_Click()

                 '2019/09/26 CHG START
            'Case CShort(MN_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '2019/09/26 CHG END
                '�I��
                Call Ctl_MN_EndCm_Click()
                Exit Function


            Case CShort(MN_EditMn.Tag)
                '�����Q
                Call Ctl_MN_EditMn_Click()

                '        Case CInt(MN_APPENDC.Tag)
                '            '��ʏ�����
                'Call Ctl_MN_APPENDC_Click()
            Case CShort(MN_ClearItm.Tag)
                '���ڏ�����
                Call Ctl_MN_ClearItm_Click()

            Case CShort(MN_UnDoItem.Tag)
                '���ڕ���
                Call Ctl_MN_UnDoItem_Click()

                '        Case CInt(MN_ClearDE.Tag)
                '            '���׍s������
                '            Call Ctl_MN_ClearDE_Click
                '
                '        Case CInt(MN_DeleteCM.Tag)
                '            '���׍s�폜
                '            Call Ctl_MN_DeleteDE_Click
                '
                '        Case CInt(MN_InsertDE.Tag)
                '            '���׍s�}��
                '            Call Ctl_MN_InsertDE_Click
                '
                '        Case CInt(MN_UnDoDe.Tag)
                '            '���׍s����
                '            Call Ctl_MN_UnDoDe_Click

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
                '2019/09/26 CHG START
            'Case CShort(MN_SELECTCM.Tag)
            Case CShort(btnF9.Tag)
                '2019/09/26 CHG END
                '�I���i���ו��N���A�j
                '2019/09/26 DEL START
                'Call Ctl_MN_SELECTCM_Click()
                '2019/09/26 DEL END

                '2019/09/26 ADD START
                If _BD_LINNO_1.Text.Trim.Length > 0 Then

                    '��ʃ{�f�B��������
                    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

                    '��ʖ��ו\��
                    Call CF_Body_Dsp(Main_Inf)

                    Main_Inf.Dsp_Base.Head_Ok_Flg = False

                    For Index_Wk As Integer = 1 To Main_Inf.Dsp_Base.Item_Cnt
                        If Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name.StartsWith("HD_") _
                            And Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> HD_IN_TANNM.Name _
                            And Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> HD_IN_TANCD.Name _
                            And Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> HD_MITNO.Name _
                            And Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> HD_MITNOV.Name _
                            And Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Name <> HD_JDNNO.Name Then

                            Call SSSMAIN0001.F_Init_Clr_Dsp(Index_Wk, Main_Inf)
                        End If
                    Next

                    Call SSSMAIN0001.F_Init_Clr_Dsp(TL_SBAUODKN.Tag, Main_Inf)
                    Call SSSMAIN0001.F_Init_Clr_Dsp(TL_SBAUZEKN.Tag, Main_Inf)
                    Call SSSMAIN0001.F_Init_Clr_Dsp(TL_SBAUZKKN.Tag, Main_Inf)

                Else
                    '��ʓ��e������
                    Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

                    '�����\���ҏW
                    Call Edi_Dsp_Def()

                    '���͒S���ҕҏW
                    Call CF_Set_Frm_IN_TANCD_HIKET51(Me, Main_Inf)
                End If

                '�w�b�_�����͐���
                Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
                HD_MITNOV.BackColor = COLOR_WHITE
                HD_JDNNO.BackColor = COLOR_WHITE
                HD_MITNO.Select()
                HD_MITNO.BackColor = COLOR_YELLOW

                '2019/09/26 ADD START

                '        Case CInt(MN_PREV.Tag)
                '            '�O�y�[�W
                '            Call Ctl_MN_PREV_Click
                '
                '        Case CInt(MN_NEXTCM.Tag)
                '            '���y�[�W
                '            Call Ctl_MN_NEXTCM_Click

            '2019/09/26 CHG START
            'Case CShort(MN_Slist.Tag)
            Case CShort(btnF5.Tag)
                '2019/09/26 CHG END
                '���̈ꗗ
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
            '2019/09/26 CHG START
            'Case CShort(CM_EndCm.Tag)
            Case CShort(btnF12.Tag)
                '2019/09/26 CHG END
                '�I��
                Call Ctl_MN_EndCm_Click()
                Exit Function

            '2019/09/26 CHG START
            'Case CShort(CM_Execute.Tag)
            Case CShort(btnF2.Tag)
                '2019/09/26 CHG END
                '���s
                Call Ctl_MN_Execute_Click()

                ' === 20060802 === INSERT S - ACE)Nagasawa
            '2019/09/26 CHG START
            'Case CShort(CM_Slist.Tag)
            Case CShort(btnF5.Tag)
                '2019/09/26 CHG END
                '����W�\��
                Call Ctl_MN_Slist_Click()
                ' === 20060802 === INSERT E -

            Case CShort(CM_SELECTCM.Tag)
                '�I���i���ו��N���A�j
                Call Ctl_MN_SELECTCM_Click()

                '���ق�
                '2019/09/26 CHG START
            'Case CShort(CS_HIK.Tag)
            Case CShort(btnF6.Tag)
                '2019/09/26 CHG END
                '�����^�����{�^��
                Call Ctl_CS_HIK_Click()

            Case CShort(CS_MITNO.Tag)
                '���Ϗ�񌟍���ʌďo
                Call SSSMAIN0001.F_Ctl_CS_MITNO(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

            Case CShort(CS_JDNNO.Tag)
                '�󒍏�񌟍���ʌďo
                Call SSSMAIN0001.F_Ctl_CS_JDNNO(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        End Select

        '���ו��̏ꍇ
        ' === 20060922 === DELETE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
        'D    Select Case pm_Ctl.NAME
        'D        Case BD_SELECTB(1).NAME
        'D            '�I�𖾍׃I�v�V�����{�^���C���[�W
        'D            Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
        'D            Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Img)
        'D
        'D        Case Else
        'D
        'D    End Select
        ' === 20060922 === DELETE E

        '�X�e�[�^�X�o�[������
        Call CF_Clr_Prompt(Main_Inf)

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

        '�e������ʌďo
        Select Case Act_Index
            Case CShort(HD_MITNO.Tag)
                '�Ώی��ϔԍ���÷�Ă�̫����ړ�

            Case CShort(HD_MITNOV.Tag)
                '�Ő���÷�Ă�̫����ړ�

            Case CShort(HD_JDNNO.Tag)
                '�Ώێ󒍔ԍ���÷�Ă�̫����ړ�

        End Select

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
        Call SSSMAIN0001.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '�s�I��
        '    Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
        Trg_Index = CShort(BD_SELECTB(1).Tag)
        ' === 20060922 === UPDATE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
        'D    Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Img)
        ' === 20060922 === UPDATE ��
        Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        ' === 20060922 === UPDATE E

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

        '�r���������������������������������������������������������r
        'Head_Ok_Flg = False (�w�b�_�Ƀt�H�[�J�X������ꍇ)
        If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
            '����s��g�p�\
            MN_Execute.Enabled = True
        Else
            '����s��g�p�s��
            MN_Execute.Enabled = False
        End If
        '���ʈ�������
        MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��I�������
        MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
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
        '����ڏ����������
        MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '����ڕ��������
        MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��؂��裔���
        MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��R�s�[�����
        MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '��\��t�������
        MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
        '�d���������������������������������������������������������d

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Oprt_Click
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
        ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
        '�u�I���v����
        Select Case Ant_Index
            Case CShort(Me.HD_MITNO.Tag), CShort(Me.HD_MITNOV.Tag), CShort(Me.HD_JDNNO.Tag)

                MN_SELECTCM.Enabled = False

            Case Else
                MN_SELECTCM.Enabled = True

        End Select
        ' === 20060907 === INSERT E
        '���j���[�g�p��/�s����
        '���j���[���e�ɍ��킹�ĕύX����
        '����̈ꗗ�������
        MN_Slist.Enabled = False

        '�g�p����
        '��è�ނȍ��ڂ̌����@�\������ꍇ�A�g�p��
        'UPGRADE_ISSUE: Control NAME �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Select Case Me.ActiveControl.Name
            Case HD_MITNO.Name, HD_MITNOV.Name, HD_JDNNO.Name
                '�����@�\�̂�����͍��ڂ̏ꍇ

                MN_Slist.Enabled = True
        End Select
        '�d���������������������������������������������������������d

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  ���j���[����i���s�j
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_Execute_Click() As Short

        Dim Wk_Index As Short

        ' === 20060908 === INSERT S - ACE)Sejima ���s�{�^���C���[�W�Ή�
        If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
            ' === 20060908 === INSERT E
            '�i�w�b�_�����͌�A�m�肷�铮���Ɠ����j
            Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx
            Call SSSMAIN0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, True, Main_Inf)
            ' === 20060908 === INSERT S - ACE)Sejima ���s�{�^���C���[�W�Ή�
        End If
        ' === 20060908 === INSERT E


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_APPENDC_Click
    '   �T�v�F  ��ʏ���������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_APPENDC_Click() As Short

        '��ʓ��e������
        Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

        '2019/09/26 ADD START
        '���͒S���ҕҏW
        Call CF_Set_Frm_IN_TANCD_HIKET51(Me, Main_Inf)
        '2019/09/26 ADD END

        '�w�b�_�����͐���
        Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)

        '��ʃ{�f�B��������
        Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        ' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
        '��ʐF�ݒ�
        Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
        ' === 20061127 === INSERT E -

        '�����t�H�[�J�X�ʒu�ݒ�
        Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearDE_Click
    '   �T�v�F  ���׍s������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_ClearDE_Click() As Short

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

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '�������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        ''��ʓ��e������
        Call SSSMAIN0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)

        '�r���������������������������������������������������������r
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

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

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

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

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
    '   ���́F  Function Ctl_MN_DeleteCM_Click
    '   �T�v�F  �폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_DeleteCM_Click() As Short

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteDE_Click
    '   �T�v�F  ���׍s�폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_DeleteDE_Click() As Short

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
    '   ���́F  Function Ctl_MN_SELECTCM_Click
    '   �T�v�F  �I���i���ו��N���A�j
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_SELECTCM_Click() As Short

        Dim Wk_Index As Short

        ' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
        Dim Act_Index As Short

        '    Act_Index = CInt(CF_Get_CCurString(FR_SSSMAIN.ActiveControl.Tag))
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)
        If Act_Index <= Main_Inf.Dsp_Base.Head_Lst_Idx Then
            '�w�b�_���i���������j�ɂ���Ƃ��͏������s��Ȃ�
            Exit Function
        End If
        ' === 20060907 === INSERT E

        '��ʓ��e�������i���͍��ڂ������j
        Wk_Index = CShort(BD_SELECTB(1).Tag)
        ' === 20060922 === UPDATE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
        'D    Call F_Clr_Dsp_Out(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf, HIKET51_Bd_Sel_Img)
        ' === 20060922 === UPDATE ��
        Call F_Clr_Dsp_Out(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf)
        ' === 20060922 === UPDATE E

        '�w�b�_�����͐���
        Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)

        '��ʃ{�f�B��������
        Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        ' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
        '��ʐF�ݒ�
        Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
        ' === 20061127 === INSERT E -

        ' === 20060802 === INSERT S - ACE)Nagasawa
        '���͒S���ҕҏW
        '2019/09/20 CHG START
        'Call CF_Set_Frm_IN_TANCD(Me, Main_Inf)
        Call CF_Set_Frm_IN_TANCD_HIKET51(Me, Main_Inf)
        '2019/09/20 CHG END
        ' === 20060802 === INSERT E -

        '�����t�H�[�J�X�ʒu�ݒ�
        Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)

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

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_InsertDE_Click
    '   �T�v�F  ���׍s�}��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_MN_InsertDE_Click() As Short

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

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

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
    Private Function Ctl_MN_Slist_Click() As Short

        Dim Act_Index As Short

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

        '��è�޺��۰ي������ޯ���擾
        'UPGRADE_ISSUE: Control Tag �́A�ėp���O��� ActiveControl ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
        Act_Index = CShort(Me.ActiveControl.Tag)

        '�r���������������������������������������������������������r

        Select Case Act_Index
            '�Q�ƌ��ϔԍ�
            Case CShort(Me.HD_MITNO.Tag)
                Call CS_MITNO_Click()

                '�Q�ƌ��ϔԍ��Ő�
            Case CShort(Me.HD_MITNOV.Tag)
                Call CS_MITNO_Click()

                ' === 20060802 === INSERT S - ACE)Nagasawa  �󒍓`�[����W�Ή�
                '�󒍔ԍ�
            Case CShort(Me.HD_JDNNO.Tag)
                Call CS_JDNNO_Click()
                ' === 20060802 === INSERT E -

            Case Else
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

        ' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
        If Me.ActiveControl Is Nothing Then
            Exit Function
        End If
        ' === 20061116 === INSERT E -

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

        '�r���������������������������������������������������������r
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

        '�Y�����ڂ̓\��t��
        '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
        Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CS_HIK_Click
    '   �T�v�F  �����^�����{�^��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function Ctl_CS_HIK_Click() As Short

        Dim Trg_Index As Short
        ' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
        Dim strMsg As String
        ' === 20061105 === INSERT E -
        '2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
        Dim intRet As Short
        '2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01

        '�������ޯ���擾
        'UPGRADE_WARNING: �I�u�W�F�N�g FR_SSSMAIN.CS_HIK.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/26 CHG START
        'Trg_Index = CShort(Me.CS_HIK.Tag)
        Trg_Index = CShort(Me.btnF6.Tag)
        '2019/09/26 CHG END

        If CF_Set_Focus_Ctl(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf) = True Then

            ' === 20060908 === INSERT S - ACE)Sejima ���Ɏ󒍂ƂȂ��Ă��錩��
            If Trim(HIKET51_DSP_DATA_Inf.MIT_JDNNO) = "" Then
                ' === 20060908 === INSERT E

                ' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
                '�X�V�������Ȃ��ꍇ�͔r������͍s��Ȃ�
                If Inp_Inf.InpJDNUPDKB = gc_strJDNUPDKB_OK Then
                    ' === 20061129 === INSERT E -

                    ' === 20061105 === INSERT S - ACE)Nagasawa
                    '�r���`�F�b�N���s��
                    Select Case CF_Chk_Lock_EXCTBZ(strMsg)
                        '����
                        Case 0

                            '�r��������
                        Case 1
                            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_018, Main_Inf, "", strMsg)
                            Exit Function

                            '�ُ�I��
                        Case 9
                            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, Main_Inf)
                            Exit Function

                    End Select
                    ' === 20061105 === INSERT E -
                    ' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
                End If
                ' === 20061129 === INSERT E -

                '2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
                intRet = F_CHK_SOU(Main_Inf)
                If intRet <> CHK_OK Then
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_022, Main_Inf)
                    Exit Function
                End If
                '2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01

                '�C���^�[�t�F�[�X�i�[
                Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET51_Bd_Sel_Index), HIKET51_DSP_DATA_Inf, HIKET51_Interface)

                ' === 20060921 === INSERT S - ACE)Hashiri �T�u��ʕ\�����Ɍ���ʂ��\��
                Me.Hide()
                ' === 20060921 === INSERT E

                ' === 20060921 === UPDATE S - ACE)Nagasawa ���[�_���\���͍s��Ȃ�
                '            '�݌Ɉ����^�ʉ����\��
                '            FR_SSSSUB01.Show vbModal
                '' === 20060908 === INSERT S - ACE)Sejima ���Ɏ󒍂ƂȂ��Ă��錩��
                '' === 20060921 === INSERT S - ACE)Hashiri ����ʂ̍ĕ\��
                '            FR_SSSMAIN.Show
                '' === 20060921 === INSERT E

                '�݌Ɉ����^�ʉ����\��
                FR_SSSSUB01.Show()
                ' === 20060921 === UPDATE E -

            Else
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_016, Main_Inf)
            End If
            ' === 20060908 === INSERT E
        End If


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
        Dim strSYSDT As String

        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT.Tag �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Index_Wk = CShort(SYSDT.Tag)
        '��ʓ��t
        '   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
        strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)

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

        Dim BD_LINNO_Top As Short
        Dim BD_LINNO_Height As Short

        Dim BD_TOKJDNNO_Top As Short
        Dim BD_HINNMB_Top As Short
        Dim BD_SIKTK_Top As Short
        Dim BD_TEIKATK_Top As Short
        Dim BD_SIKRT_Top As Short
        Dim BD_LINCMB_Top As Short
        Dim BD_KHIKKB_Top As Short

        Dim Bd_Index As Short


        '2019/09/30 CHG START

        ''�P�s�ڂ�No��Top��Height����Ƃ���
        'BD_LINNO_Top = VB6.FromPixelsUserY(BD_LINNO(1).Top, 0, 10944.1, 653)
        'BD_LINNO_Height = VB6.FromPixelsUserHeight(BD_LINNO(1).Height, 10944.1, 653) + Hosei_Value

        ''�P�s�ڢNo����碋q�撍���ԍ���܂ł̑��Έʒu���擾
        'BD_TOKJDNNO_Top = VB6.FromPixelsUserY(BD_TOKJDNNO(1).Top, 0, 10944.1, 653) - BD_LINNO_Top
        ''�P�s�ڢNo����碕i����܂ł̑��Έʒu���擾
        'BD_HINNMB_Top = VB6.FromPixelsUserY(BD_HINNMB(1).Top, 0, 10944.1, 653) - BD_LINNO_Top
        ''�P�s�ڢNo����碉c�Ǝd�أ�܂ł̑��Έʒu���擾
        'BD_SIKTK_Top = VB6.FromPixelsUserY(BD_SIKTK(1).Top, 0, 10944.1, 653) - BD_LINNO_Top
        ''�P�s�ڢNo����碒艿��܂ł̑��Έʒu���擾
        'BD_TEIKATK_Top = VB6.FromPixelsUserY(BD_TEIKATK(1).Top, 0, 10944.1, 653) - BD_LINNO_Top
        ''�P�s�ڢNo����碎d�ؗ���܂ł̑��Έʒu���擾
        'BD_SIKRT_Top = VB6.FromPixelsUserY(BD_SIKRT(1).Top, 0, 10944.1, 653) - BD_LINNO_Top
        ''�P�s�ڢNo����碔��l�Q��܂ł̑��Έʒu���擾
        'BD_LINCMB_Top = VB6.FromPixelsUserY(BD_LINCMB(1).Top, 0, 10944.1, 653) - BD_LINNO_Top

        ''�\���ŏI�s�܂ŏ���
        'For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        '    '�z�u
        '    BD_SELECTB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    '        BD_SELECT(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        '    BD_LINNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_HINCD(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_TOKJDNNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TOKJDNNO_Top)
        '    BD_HINNMA(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_HINNMB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_HINNMB_Top)
        '    BD_GNKCD(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_UODSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_UNTNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_UODTK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_SIKTK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_SIKTK_Top)
        '    BD_UODKN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_TEIKATK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TEIKATK_Top)
        '    BD_SIKRT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_ODNYTDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_LINCMA(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
        '    BD_LINCMB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_LINCMB_Top)
        BD_LINNO_Top = VB6.PixelsToTwipsY(BD_LINNO(1).Top)
        BD_LINNO_Height = VB6.PixelsToTwipsY(BD_LINNO(1).Height) + Hosei_Value

        '�P�s�ڢNo����碋q�撍���ԍ���܂ł̑��Έʒu���擾
        BD_TOKJDNNO_Top = VB6.PixelsToTwipsY(BD_TOKJDNNO(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碕i����܂ł̑��Έʒu���擾
        BD_HINNMB_Top = VB6.PixelsToTwipsY(BD_HINNMB(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碉c�Ǝd�أ�܂ł̑��Έʒu���擾
        BD_SIKTK_Top = VB6.PixelsToTwipsY(BD_SIKTK(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碒艿��܂ł̑��Έʒu���擾
        BD_TEIKATK_Top = VB6.PixelsToTwipsY(BD_TEIKATK(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碎d�ؗ���܂ł̑��Έʒu���擾
        BD_SIKRT_Top = VB6.PixelsToTwipsY(BD_SIKRT(1).Top) - BD_LINNO_Top
        '�P�s�ڢNo����碔��l�Q��܂ł̑��Έʒu���擾
        BD_LINCMB_Top = VB6.PixelsToTwipsY(BD_LINCMB(1).Top) - BD_LINNO_Top

        '�\���ŏI�s�܂ŏ���
        For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
            '�z�u
            BD_SELECTB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            '        BD_SELECT(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
            BD_LINNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_HINCD(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_TOKJDNNO(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TOKJDNNO_Top)
            BD_HINNMA(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_HINNMB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_HINNMB_Top)
            BD_GNKCD(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_UODSU(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_UNTNM(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_UODTK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_SIKTK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_SIKTK_Top)
            BD_UODKN(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_TEIKATK(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TEIKATK_Top)
            BD_SIKRT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_ODNYTDT(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_LINCMA(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1))
            BD_LINCMB(Bd_Index).Top = VB6.TwipsToPixelsY(BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_LINCMB_Top)

            '2019/09/30 CHG END

            '�\��
            BD_SELECTB(Bd_Index).Visible = True
            '        BD_SELECT(Bd_Index).Visible = True
            BD_LINNO(Bd_Index).Visible = True
            BD_HINCD(Bd_Index).Visible = True
            BD_TOKJDNNO(Bd_Index).Visible = True
            BD_HINNMA(Bd_Index).Visible = True
            BD_HINNMB(Bd_Index).Visible = True
            BD_GNKCD(Bd_Index).Visible = True
            BD_UODSU(Bd_Index).Visible = True
            BD_UNTNM(Bd_Index).Visible = True
            BD_UODTK(Bd_Index).Visible = True
            BD_SIKTK(Bd_Index).Visible = True
            BD_UODKN(Bd_Index).Visible = True
            BD_TEIKATK(Bd_Index).Visible = True
            BD_SIKRT(Bd_Index).Visible = True
            BD_ODNYTDT(Bd_Index).Visible = True
            BD_LINCMA(Bd_Index).Visible = True
            BD_LINCMB(Bd_Index).Visible = True

        Next

        '�X�N���[���o�[�̐ݒ�
        '2019/09/30 CHG START
        'VS_Scrl.Top = VB6.ToPixelsUserY(BD_LINNO_Top, 0, 10944.1, 653)
        'VS_Scrl.Height = VB6.ToPixelsUserHeight(BD_LINNO_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt, 10944.1, 653)
        VS_Scrl.Top = VB6.TwipsToPixelsY(BD_LINNO_Top)
        VS_Scrl.Height = VB6.TwipsToPixelsY(BD_LINNO_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt)
        '2019/09/30 CHG END

    End Function

    Private Sub TM_StartUp_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TM_StartUp.Tick
        '��x����̂��ߎg�p�s��
        Main_Inf.TM_StartUp_Ctl.Enabled = False
        '��ʈ���N������TRUE�Ƃ���
        PP_SSSMAIN.Operable = True
        '����̫����ʒu�ݒ�s
        Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
    End Sub

    Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'DB�ڑ�
        Call CF_Ora_USR1_Open()

        '���ʏ���������
        Call CF_Init()

        '��ʏ��ݒ�
        Call Init_Def_Dsp()

        '��ʓ��e������
        Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

        '��ʖ��׏��ݒ�
        Call Init_Def_Body_Inf()

        '��ʖ��ו�������
        Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

        '���׃��P�[�V����
        Call Set_Body_Location()

        '�����\���ҏW
        Call Edi_Dsp_Def()

        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)

        ' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
        '��ʐF�ݒ�
        Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
        ' === 20061127 === INSERT E -

        '��ʕ\���ʒu�ݒ�
        Call CF_Set_Frm_Location(Me)

        '���͒S���ҕҏW
        Call CF_Set_Frm_IN_TANCD_HIKET51(Me, Main_Inf)

        '�V�X�e�����ʏ���
        Call CF_System_Process(Me)

        '2019/09/26 ADD START
        SetBar(Me)
        '2019/09/26 ADD END

    End Sub

    'UPGRADE_NOTE: VS_Scrl.Change �̓C�x���g����v���V�[�W���ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"' ���N���b�N���Ă��������B
    'UPGRADE_WARNING: VScrollBar �C�x���g VS_Scrl.Change �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub VS_Scrl_Change(ByVal newScrollValue As Integer)
        Debug.Print("VS_Scrl_Change")
        Call Ctl_VS_Scrl_Change(VS_Scrl)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_SELECTB.CheckedChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_SELECTB_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SELECTB.CheckedChanged
        If eventSender.Checked Then
            Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
            Debug.Print("BD_SELECTB_Click")
            '2019/09/30 CHG START
            'Call Ctl_Item_Click(BD_SELECTB(Index))
            If _BD_LINNO_1.Text.Trim.Length = 0 Then
                DirectCast(BD_SELECTB(Index), RadioButton).Checked = False
            Else
                Call Ctl_Item_Click(BD_SELECTB(Index))
            End If
            '2019/09/30 CHG END
        End If
    End Sub

    'Private Sub BD_SELECT_Click(Index As Integer)
    '    Debug.Print "BD_SELECT_Click"
    '    Call Ctl_Item_Click(BD_SELECT(Index))
    'End Sub

    Private Sub CS_HIK_Click()
        Debug.Print("CS_HIK_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_HIK)
    End Sub

    Private Sub CS_MITNO_Click()
        Debug.Print("CS_MITNO_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_MITNO)
    End Sub

    Private Sub CS_JDNNO_Click()
        Debug.Print("CS_JDNNO_Click")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_Click(CS_JDNNO)
    End Sub

    Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
        Debug.Print("CM_Execute_Click")
        Call Ctl_Item_Click(CM_Execute)
    End Sub

    Private Sub CM_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SELECTCM.Click
        Debug.Print("CM_SELECTCM_Click")
        Call Ctl_Item_Click(CM_SELECTCM)
    End Sub

    Private Sub CM_SLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_SLIST.Click
        Debug.Print("CM_SLIST_Click")
        Call Ctl_Item_Click(CM_SLIST)
    End Sub

    Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
        Debug.Print("CM_EndCm_Click")
        Call Ctl_Item_Click(CM_EndCm)
    End Sub

    Public Sub MN_Ctrl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Ctrl.Click
        Debug.Print("MN_Ctrl_Click")
        Call Ctl_Item_Click(MN_Ctrl)
    End Sub

    Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
        Debug.Print("MN_Execute_Click")
        Call Ctl_Item_Click(MN_Execute)
    End Sub

    'Private Sub MN_DeleteCM_Click()
    '    Debug.Print "MN_DeleteCM_Click"
    '    Call Ctl_Item_Click(MN_DeleteCM)
    'End Sub

    Public Sub MN_HARDCOPY_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_HARDCOPY.Click
        Debug.Print("MN_HARDCOPY_Click")
        Call Ctl_Item_Click(MN_HARDCOPY)
    End Sub

    Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
        Debug.Print("MN_EndCm_Click")
        Call Ctl_Item_Click(MN_EndCm)
    End Sub

    Public Sub MN_EditMn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EditMn.Click
        Debug.Print("MN_EditMn_Click")
        Call Ctl_Item_Click(MN_EditMn)
    End Sub

    'Private Sub MN_APPENDC_Click()
    '    Debug.Print "MN_APPENDC_Click"
    '    Call Ctl_Item_Click(MN_APPENDC)
    'End Sub

    Public Sub MN_ClearItm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_ClearItm.Click
        Debug.Print("MN_ClearItm_Click")
        Call Ctl_Item_Click(MN_ClearItm)
    End Sub

    Public Sub MN_UnDoItem_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_UnDoItem.Click
        Debug.Print("MN_UnDoItem_Click")
        Call Ctl_Item_Click(MN_UnDoItem)
    End Sub

    'Private Sub MN_ClearDE_Click()
    '    Debug.Print "MN_ClearDE_Click"
    '    Call Ctl_Item_Click(MN_ClearDE)
    'End Sub
    '
    'Private Sub MN_DeleteDE_Click()
    '    Debug.Print "MN_DeleteDE_Click"
    '    Call Ctl_Item_Click(MN_DeleteDE)
    'End Sub
    '
    'Private Sub MN_InsertDE_Click()
    '    Debug.Print "MN_InsertDE_Click"
    '    Call Ctl_Item_Click(MN_InsertDE)
    'End Sub
    '
    'Private Sub MN_UnDoDe_Click()
    '    Debug.Print "MN_UnDoDe_Click"
    '    Call Ctl_Item_Click(MN_UnDoDe)
    'End Sub

    Public Sub MN_Cut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Cut.Click
        Debug.Print("MN_Cut_Click")
        Call Ctl_Item_Click(MN_Cut)
    End Sub

    Public Sub MN_Copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Copy.Click
        Debug.Print("MN_Copy_Click")
        Call Ctl_Item_Click(MN_Copy)
    End Sub

    Public Sub MN_Paste_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Paste.Click
        Debug.Print("MN_Paste_Click")
        Call Ctl_Item_Click(MN_Paste)
    End Sub

    Public Sub MN_Oprt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Oprt.Click
        Debug.Print("MN_Oprt_Click")
        Call Ctl_Item_Click(MN_Oprt)
    End Sub

    Public Sub MN_Slist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Slist.Click
        Debug.Print("MN_Slist_Click")
        Call Ctl_Item_Click(MN_Slist)
    End Sub

    ' === 20060802 === DELETE S - ACE)Nagasawa
    'Private Sub SM_ShortCut_Click()
    '    Debug.Print "SM_ShortCut_Click"
    '    Call Ctl_Item_Click(SM_ShortCut)
    'End Sub
    ' === 20060802 === DELETE E -

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

    Private Sub BD_SELECTB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SELECTB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_MouseDown")
        Call Ctl_Item_MouseDown(BD_SELECTB(Index), Button, Shift, X, Y)
    End Sub

    'Private Sub BD_SELECT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "BD_SELECT_MouseDown"
    '    Call Ctl_Item_MouseDown(BD_SELECT(Index), Button, Shift, X, Y)
    'End Sub

    Private Sub HD_MITNOV_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MITNOV.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_MITNOV_MouseDown")
        Call Ctl_Item_MouseDown(HD_MITNOV, Button, Shift, X, Y)
    End Sub

    Private Sub HD_MITNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MITNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_MITNO_MouseDown")
        Call Ctl_Item_MouseDown(HD_MITNO, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNNO_MouseDown")
        Call Ctl_Item_MouseDown(HD_JDNNO, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUZEKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZEKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUZEKN_MouseDown")
        Call Ctl_Item_MouseDown(TL_SBAUZEKN, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUODKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUODKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUODKN_MouseDown")
        Call Ctl_Item_MouseDown(TL_SBAUODKN, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUZKKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZKKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUZKKN_MouseDown")
        Call Ctl_Item_MouseDown(TL_SBAUZKKN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSNMB_MouseDown")
        Call Ctl_Item_MouseDown(HD_NHSNMB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSNMA_MouseDown")
        Call Ctl_Item_MouseDown(HD_NHSNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_NHSCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KENNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KENNMB_MouseDown")
        Call Ctl_Item_MouseDown(HD_KENNMB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KENNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KENNMA_MouseDown")
        Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_OPEID_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_OPEID_MouseDown")
        Call Ctl_Item_MouseDown(HD_OPEID, Button, Shift, X, Y)
    End Sub

    Private Sub HD_OPENM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_OPENM_MouseDown")
        Call Ctl_Item_MouseDown(HD_OPENM, Button, Shift, X, Y)
    End Sub

    Private Sub BD_GNKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_GNKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_MouseDown")
        Call Ctl_Item_MouseDown(BD_GNKCD(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_URIKJN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_URIKJN_MouseDown")
        Call Ctl_Item_MouseDown(HD_URIKJN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BINCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_BINCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKJDNNO_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKJDNNO, Button, Shift, X, Y)
    End Sub

    Private Sub BD_TOKJDNNO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKJDNNO.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_MouseDown")
        Call Ctl_Item_MouseDown(BD_TOKJDNNO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_URIKJNNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJNNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_URIKJNNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_URIKJNNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNTRNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNTRNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_JDNTRNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNTRKB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNTRKB_MouseDown")
        Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
    End Sub

    Private Sub BD_ODNYTDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ODNYTDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_MouseDown")
        Call Ctl_Item_MouseDown(BD_ODNYTDT(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKRT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKRT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_MouseDown")
        Call Ctl_Item_MouseDown(BD_SIKRT(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODKN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_MouseDown")
        Call Ctl_Item_MouseDown(BD_UODKN(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_TEIKATK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEIKATK.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_MouseDown")
        Call Ctl_Item_MouseDown(BD_TEIKATK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODTK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODTK.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_MouseDown")
        Call Ctl_Item_MouseDown(BD_UODTK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODSU_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_MouseDown")
        Call Ctl_Item_MouseDown(BD_UODSU(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKRN_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKRN_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BUMNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BUMNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_BUMNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TANNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BINNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BINNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_BINNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BUMCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BUMCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_BUMCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TANCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_SOUCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_SOUCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_SOUNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_SOUNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANNM_MouseDown")
        Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANCD_MouseDown")
        Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
    End Sub

    ' === 20070127 === DELETE S - ACE)Nagasawa
    'Private Sub SYSDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "SYSDT_MouseDown"
    '    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
    'End Sub
    ' === 20070127 === DELETE E -

    Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_Execute_MouseDown")
        Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SELECTCM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SELECTCM_MouseDown")
        Call Ctl_Item_MouseDown(CM_SELECTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseDown")
        Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseDown")
        Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
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

    Private Sub BD_HINNMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_MouseDown")
        Call Ctl_Item_MouseDown(BD_HINNMA(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_HINNMB_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMB.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_MouseDown")
        Call Ctl_Item_MouseDown(BD_HINNMB(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKTK_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKTK.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_MouseDown")
        Call Ctl_Item_MouseDown(BD_SIKTK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UNTNM_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UNTNM.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_MouseDown")
        Call Ctl_Item_MouseDown(BD_UNTNM(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_HINCD_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINCD.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_MouseDown")
        Call Ctl_Item_MouseDown(BD_HINCD(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNDT_MouseDown")
        Call Ctl_Item_MouseDown(HD_JDNDT, Button, Shift, X, Y)
    End Sub

    Private Sub HD_DEFNOKDT_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DEFNOKDT.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_DEFNOKDT_MouseDown")
        Call Ctl_Item_MouseDown(HD_DEFNOKDT, Button, Shift, X, Y)
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

    Private Sub BD_LINCMA_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseDown
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_MouseDown")
        Call Ctl_Item_MouseDown(BD_LINCMA(Index), Button, Shift, X, Y)
    End Sub

    ' === 20060804 === DELETE S - ACE)Nagasawa
    'Private Sub FM_Panel3D1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "FM_Panel3D1_MouseDown"
    '    Call Ctl_Item_MouseDown(FM_Panel3D1(Index), Button, Shift, X, Y)
    'End Sub
    ' === 20060804 === DELETE E -

    Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_Execute_MouseMove")
        Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SELECTCM_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SELECTCM_MouseMove")
        Call Ctl_Item_MouseMove(CM_SELECTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseMove")
        Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseMove")
        Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
    End Sub

    Private Sub BD_SELECTB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SELECTB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_MouseUp")
        Call Ctl_Item_MouseUp(BD_SELECTB(Index), Button, Shift, X, Y)
    End Sub

    'Private Sub BD_SELECT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "BD_SELECT_MouseUp"
    '    Call Ctl_Item_MouseUp(BD_SELECT(Index), Button, Shift, X, Y)
    'End Sub

    Private Sub CS_HIK_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_HIK_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_HIK, Button, Shift, X, Y)
    End Sub

    Private Sub HD_MITNOV_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MITNOV.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_MITNOV_MouseUp")
        Call Ctl_Item_MouseUp(HD_MITNOV, Button, Shift, X, Y)
    End Sub

    Private Sub HD_MITNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_MITNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_MITNO_MouseUp")
        Call Ctl_Item_MouseUp(HD_MITNO, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNNO_MouseUp")
        Call Ctl_Item_MouseUp(HD_JDNNO, Button, Shift, X, Y)
    End Sub

    Private Sub CS_MITNO_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_MITNO_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_MITNO, Button, Shift, X, Y)
    End Sub

    Private Sub CS_JDNNO_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("CS_JDNNO_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(CS_JDNNO, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUZEKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZEKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUZEKN_MouseUp")
        Call Ctl_Item_MouseUp(TL_SBAUZEKN, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUODKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUODKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUODKN_MouseUp")
        Call Ctl_Item_MouseUp(TL_SBAUODKN, Button, Shift, X, Y)
    End Sub

    Private Sub TL_SBAUZKKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TL_SBAUZKKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TL_SBAUZKKN_MouseUp")
        Call Ctl_Item_MouseUp(TL_SBAUZKKN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSNMB_MouseUp")
        Call Ctl_Item_MouseUp(HD_NHSNMB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSNMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSNMA_MouseUp")
        Call Ctl_Item_MouseUp(HD_NHSNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_NHSCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_NHSCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_NHSCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_NHSCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KENNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KENNMB_MouseUp")
        Call Ctl_Item_MouseUp(HD_KENNMB, Button, Shift, X, Y)
    End Sub

    Private Sub HD_KENNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_KENNMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_KENNMA_MouseUp")
        Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
    End Sub

    Private Sub HD_OPEID_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPEID.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_OPEID_MouseUp")
        Call Ctl_Item_MouseUp(HD_OPEID, Button, Shift, X, Y)
    End Sub

    Private Sub HD_OPENM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_OPENM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_OPENM_MouseUp")
        Call Ctl_Item_MouseUp(HD_OPENM, Button, Shift, X, Y)
    End Sub

    Private Sub BD_GNKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_GNKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_MouseUp")
        Call Ctl_Item_MouseUp(BD_GNKCD(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_URIKJN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_URIKJN_MouseUp")
        Call Ctl_Item_MouseUp(HD_URIKJN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BINCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_BINCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKJDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKJDNNO_MouseUp")
        Call Ctl_Item_MouseUp(HD_TOKJDNNO, Button, Shift, X, Y)
    End Sub

    Private Sub BD_TOKJDNNO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TOKJDNNO.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_MouseUp")
        Call Ctl_Item_MouseUp(BD_TOKJDNNO(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_URIKJNNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_URIKJNNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_URIKJNNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_URIKJNNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNTRNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNTRNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_JDNTRNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNTRKB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNTRKB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNTRKB_MouseUp")
        Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
    End Sub

    Private Sub BD_ODNYTDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_ODNYTDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_MouseUp")
        Call Ctl_Item_MouseUp(BD_ODNYTDT(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKRT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKRT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_MouseUp")
        Call Ctl_Item_MouseUp(BD_SIKRT(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODKN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODKN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_MouseUp")
        Call Ctl_Item_MouseUp(BD_UODKN(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_TEIKATK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_TEIKATK.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_MouseUp")
        Call Ctl_Item_MouseUp(BD_TEIKATK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODTK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODTK.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_MouseUp")
        Call Ctl_Item_MouseUp(BD_UODTK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UODSU_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UODSU.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_MouseUp")
        Call Ctl_Item_MouseUp(BD_UODSU(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKRN_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKRN.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKRN_MouseUp")
        Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TOKCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TOKCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TOKCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BUMNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BUMNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_BUMNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TANNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BINNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BINNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BINNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_BINNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_BUMCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUMCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BUMCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_BUMCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_TANCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_TANCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_SOUCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_SOUCD, Button, Shift, X, Y)
    End Sub

    Private Sub HD_SOUNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_SOUNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_SOUNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_SOUNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANNM_MouseUp")
        Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
    End Sub

    Private Sub HD_IN_TANCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_IN_TANCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_IN_TANCD_MouseUp")
        Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
    End Sub

    Private Sub SYSDT_MouseUp(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("SYSDT_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g SYSDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
    End Sub

    Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_Execute_MouseUp")
        Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SELECTCM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SELECTCM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SELECTCM_MouseUp")
        Call Ctl_Item_MouseUp(CM_SELECTCM, Button, Shift, X, Y)
    End Sub

    Private Sub CM_SLIST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_SLIST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_SLIST_MouseUp")
        Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
    End Sub

    Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("CM_EndCm_MouseUp")
        Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
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

    Private Sub TX_CursorRest_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles TX_CursorRest.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("TX_CursorRest_MouseUp")
        Call Ctl_Item_MouseUp(TX_CursorRest, Button, Shift, X, Y)
    End Sub

    Private Sub BD_HINNMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_MouseUp")
        Call Ctl_Item_MouseUp(BD_HINNMA(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_HINNMB_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINNMB.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_MouseUp")
        Call Ctl_Item_MouseUp(BD_HINNMB(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SIKTK_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_SIKTK.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_MouseUp")
        Call Ctl_Item_MouseUp(BD_SIKTK(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_UNTNM_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_UNTNM.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_MouseUp")
        Call Ctl_Item_MouseUp(BD_UNTNM(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_HINCD_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_HINCD.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_MouseUp")
        Call Ctl_Item_MouseUp(BD_HINCD(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_JDNDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_JDNDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_JDNDT_MouseUp")
        Call Ctl_Item_MouseUp(HD_JDNDT, Button, Shift, X, Y)
    End Sub

    Private Sub HD_DEFNOKDT_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_DEFNOKDT.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_DEFNOKDT_MouseUp")
        Call Ctl_Item_MouseUp(HD_DEFNOKDT, Button, Shift, X, Y)
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

    Private Sub BD_LINCMA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles BD_LINCMA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_MouseUp")
        Call Ctl_Item_MouseUp(BD_LINCMA(Index), Button, Shift, X, Y)
    End Sub

    Private Sub HD_BUN_FUKA_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles HD_BUN_FUKA.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
        Debug.Print("HD_BUN_FUKA_MouseUp")
        Call Ctl_Item_MouseUp(HD_BUN_FUKA, Button, Shift, X, Y)
    End Sub

    Private Sub FM_Panel3D1_MouseUp(ByRef Index As Short, ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
        Debug.Print("FM_Panel3D1_MouseUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g FM_Panel3D1() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
    End Sub

    Private Sub BD_SELECTB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SELECTB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_KeyDown")
        Call Ctl_Item_KeyDown(BD_SELECTB(Index), KeyCode, Shift)
    End Sub

    'Private Sub BD_SELECT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    '    Debug.Print "BD_SELECT_KeyDown"
    '    Call Ctl_Item_KeyDown(BD_SELECT(Index), KEYCODE, Shift)
    'End Sub

    Private Sub HD_MITNOV_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MITNOV.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_MITNOV_KeyDown")
        Call Ctl_Item_KeyDown(HD_MITNOV, KeyCode, Shift)
    End Sub

    Private Sub HD_MITNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MITNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_MITNO_KeyDown")
        Call Ctl_Item_KeyDown(HD_MITNO, KeyCode, Shift)
    End Sub

    Private Sub HD_JDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNNO_KeyDown")
        '2019/10/09 ADD START
        Dim isKeyDown As Boolean
        isKeyDown = KeyCode = System.Windows.Forms.Keys.Down And Shift = 0
        '2019/10/09 ADD START

        Call Ctl_Item_KeyDown(HD_JDNNO, KeyCode, Shift)

        '2019/10/09 ADD START
        If isKeyDown Then
            If Trim(HD_MITNO.Text).Length = 0 Or Trim(HD_MITNOV.Text).Length = 0 Or _BD_LINNO_1.Text.Trim.Length = 0 Then
                HD_JDNNO.BackColor = COLOR_WHITE
            End If
        End If
        '2019/10/09 ADD START
    End Sub

    Private Sub TL_SBAUZEKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUZEKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUZEKN_KeyDown")
        Call Ctl_Item_KeyDown(TL_SBAUZEKN, KeyCode, Shift)
    End Sub

    Private Sub TL_SBAUODKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUODKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUODKN_KeyDown")
        Call Ctl_Item_KeyDown(TL_SBAUODKN, KeyCode, Shift)
    End Sub

    Private Sub TL_SBAUZKKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUZKKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUZKKN_KeyDown")
        Call Ctl_Item_KeyDown(TL_SBAUZKKN, KeyCode, Shift)
    End Sub

    Private Sub HD_NHSNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSNMB_KeyDown")
        Call Ctl_Item_KeyDown(HD_NHSNMB, KeyCode, Shift)
    End Sub

    Private Sub HD_NHSNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSNMA_KeyDown")
        Call Ctl_Item_KeyDown(HD_NHSNMA, KeyCode, Shift)
    End Sub

    Private Sub HD_NHSCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_NHSCD, KeyCode, Shift)
    End Sub

    Private Sub HD_KENNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KENNMB_KeyDown")
        Call Ctl_Item_KeyDown(HD_KENNMB, KeyCode, Shift)
    End Sub

    Private Sub HD_KENNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KENNMA_KeyDown")
        Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
    End Sub

    Private Sub HD_OPEID_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_OPEID_KeyDown")
        Call Ctl_Item_KeyDown(HD_OPEID, KeyCode, Shift)
    End Sub

    Private Sub HD_OPENM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_OPENM_KeyDown")
        Call Ctl_Item_KeyDown(HD_OPENM, KeyCode, Shift)
    End Sub

    Private Sub BD_GNKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_GNKCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_KeyDown")
        Call Ctl_Item_KeyDown(BD_GNKCD(Index), KeyCode, Shift)
    End Sub

    Private Sub HD_URIKJN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_URIKJN_KeyDown")
        Call Ctl_Item_KeyDown(HD_URIKJN, KeyCode, Shift)
    End Sub

    Private Sub HD_BINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BINCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_BINCD, KeyCode, Shift)
    End Sub

    Private Sub HD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKJDNNO_KeyDown")
        Call Ctl_Item_KeyDown(HD_TOKJDNNO, KeyCode, Shift)
    End Sub

    Private Sub BD_TOKJDNNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKJDNNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_KeyDown")
        Call Ctl_Item_KeyDown(BD_TOKJDNNO(Index), KeyCode, Shift)
    End Sub

    Private Sub HD_URIKJNNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJNNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_URIKJNNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_URIKJNNM, KeyCode, Shift)
    End Sub

    Private Sub HD_JDNTRNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNTRNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_JDNTRNM, KeyCode, Shift)
    End Sub

    Private Sub HD_JDNTRKB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNTRKB_KeyDown")
        Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
    End Sub

    Private Sub BD_ODNYTDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ODNYTDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_KeyDown")
        Call Ctl_Item_KeyDown(BD_ODNYTDT(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_SIKRT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKRT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_KeyDown")
        Call Ctl_Item_KeyDown(BD_SIKRT(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_UODKN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_KeyDown")
        Call Ctl_Item_KeyDown(BD_UODKN(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_TEIKATK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEIKATK.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_KeyDown")
        Call Ctl_Item_KeyDown(BD_TEIKATK(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_UODTK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODTK.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_KeyDown")
        Call Ctl_Item_KeyDown(BD_UODTK(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_UODSU_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_KeyDown")
        Call Ctl_Item_KeyDown(BD_UODSU(Index), KeyCode, Shift)
    End Sub

    Private Sub HD_TOKRN_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKRN_KeyDown")
        Call Ctl_Item_KeyDown(HD_TOKRN, KeyCode, Shift)
    End Sub

    Private Sub HD_TOKCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
    End Sub

    Private Sub HD_BUMNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUMNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUMNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_BUMNM, KeyCode, Shift)
    End Sub

    Private Sub HD_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TANNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
    End Sub

    Private Sub HD_BINNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BINNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_BINNM, KeyCode, Shift)
    End Sub

    Private Sub HD_BUMCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUMCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUMCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_BUMCD, KeyCode, Shift)
    End Sub

    Private Sub HD_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TANCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
    End Sub

    Private Sub HD_SOUCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_SOUCD, KeyCode, Shift)
    End Sub

    Private Sub HD_SOUNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_SOUNM, KeyCode, Shift)
    End Sub

    Private Sub HD_IN_TANNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANNM_KeyDown")
        Call Ctl_Item_KeyDown(HD_IN_TANNM, KeyCode, Shift)
    End Sub

    Private Sub HD_IN_TANCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyDown")
        Call Ctl_Item_KeyDown(HD_IN_TANCD, KeyCode, Shift)
    End Sub

    Private Sub BD_LINNO_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINNO.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINNO(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_HINNMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_KeyDown")
        Call Ctl_Item_KeyDown(BD_HINNMA(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_HINNMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_KeyDown")
        Call Ctl_Item_KeyDown(BD_HINNMB(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_SIKTK_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKTK.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_KeyDown")
        Call Ctl_Item_KeyDown(BD_SIKTK(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_UNTNM_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UNTNM.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_KeyDown")
        Call Ctl_Item_KeyDown(BD_UNTNM(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_HINCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_KeyDown")
        Call Ctl_Item_KeyDown(BD_HINCD(Index), KeyCode, Shift)
    End Sub

    Private Sub HD_JDNDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNDT_KeyDown")
        Call Ctl_Item_KeyDown(HD_JDNDT, KeyCode, Shift)
    End Sub

    Private Sub HD_DEFNOKDT_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DEFNOKDT.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_DEFNOKDT_KeyDown")
        Call Ctl_Item_KeyDown(HD_DEFNOKDT, KeyCode, Shift)
    End Sub

    Private Sub BD_LINCMB_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMB.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINCMB(Index), KeyCode, Shift)
    End Sub

    Private Sub BD_LINCMA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_KeyDown")
        Call Ctl_Item_KeyDown(BD_LINCMA(Index), KeyCode, Shift)
    End Sub

    Private Sub HD_BUN_FUKA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUN_FUKA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUN_FUKA_KeyDown")
        Call Ctl_Item_KeyDown(HD_BUN_FUKA, KeyCode, Shift)
    End Sub

    Private Sub BD_SELECTB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SELECTB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_KeyPress")
        Call Ctl_Item_KeyPress(BD_SELECTB(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    'Private Sub BD_SELECT_KeyPress(Index As Integer, KeyAscii As Integer)
    '    Debug.Print "BD_SELECT_KeyPress"
    '    Call Ctl_Item_KeyPress(BD_SELECT(Index), KeyAscii)
    'End Sub

    Private Sub HD_MITNOV_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_MITNOV.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_MITNOV_KeyPress")
        Call Ctl_Item_KeyPress(HD_MITNOV, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_MITNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_MITNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_MITNO_KeyPress")
        Call Ctl_Item_KeyPress(HD_MITNO, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_JDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_JDNNO_KeyPress")
        Call Ctl_Item_KeyPress(HD_JDNNO, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        '2019/10/09 ADD START
        If _BD_LINNO_1.Text.Trim.Length > 0 Then
            HD_JDNNO.BackColor = COLOR_WHITE
        End If
        '2019/10/09 ADD END
    End Sub

    Private Sub TL_SBAUZEKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBAUZEKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("TL_SBAUZEKN_KeyPress")
        Call Ctl_Item_KeyPress(TL_SBAUZEKN, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TL_SBAUODKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBAUODKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("TL_SBAUODKN_KeyPress")
        Call Ctl_Item_KeyPress(TL_SBAUODKN, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TL_SBAUZKKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TL_SBAUZKKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("TL_SBAUZKKN_KeyPress")
        Call Ctl_Item_KeyPress(TL_SBAUZKKN, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_NHSNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_NHSNMB_KeyPress")
        Call Ctl_Item_KeyPress(HD_NHSNMB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_NHSNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_NHSNMA_KeyPress")
        Call Ctl_Item_KeyPress(HD_NHSNMA, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_NHSCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_NHSCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_NHSCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_NHSCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KENNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KENNMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KENNMB_KeyPress")
        Call Ctl_Item_KeyPress(HD_KENNMB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_KENNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_KENNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_KENNMA_KeyPress")
        Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_OPEID_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPEID.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_OPEID_KeyPress")
        Call Ctl_Item_KeyPress(HD_OPEID, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_OPENM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_OPENM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_OPENM_KeyPress")
        Call Ctl_Item_KeyPress(HD_OPENM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_GNKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_GNKCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_KeyPress")
        Call Ctl_Item_KeyPress(BD_GNKCD(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_URIKJN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_URIKJN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_URIKJN_KeyPress")
        Call Ctl_Item_KeyPress(HD_URIKJN, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_BINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BINCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BINCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_BINCD, KeyAscii)
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

    Private Sub BD_TOKJDNNO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TOKJDNNO.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_KeyPress")
        Call Ctl_Item_KeyPress(BD_TOKJDNNO(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_URIKJNNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_URIKJNNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_URIKJNNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_URIKJNNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_JDNTRNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_JDNTRNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_JDNTRNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_JDNTRKB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNTRKB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_JDNTRKB_KeyPress")
        Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_ODNYTDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_ODNYTDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_KeyPress")
        Call Ctl_Item_KeyPress(BD_ODNYTDT(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SIKRT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIKRT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_KeyPress")
        Call Ctl_Item_KeyPress(BD_SIKRT(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UODKN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODKN.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_KeyPress")
        Call Ctl_Item_KeyPress(BD_UODKN(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_TEIKATK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_TEIKATK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_KeyPress")
        Call Ctl_Item_KeyPress(BD_TEIKATK(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UODTK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODTK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_KeyPress")
        Call Ctl_Item_KeyPress(BD_UODTK(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UODSU_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UODSU.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_KeyPress")
        Call Ctl_Item_KeyPress(BD_UODSU(Index), KeyAscii)
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

    Private Sub HD_TOKCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TOKCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TOKCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_BUMNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BUMNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BUMNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_BUMNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TANNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_BINNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BINNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BINNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_BINNM, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_BUMCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BUMCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BUMCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_BUMCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_TANCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_TANCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_TANCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_SOUCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_SOUCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_SOUCD_KeyPress")
        Call Ctl_Item_KeyPress(HD_SOUCD, KeyAscii)
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

    Private Sub HD_IN_TANNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_IN_TANNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_IN_TANNM_KeyPress")
        Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
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

    Private Sub BD_HINNMA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINNMA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_KeyPress")
        Call Ctl_Item_KeyPress(BD_HINNMA(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_HINNMB_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINNMB.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_KeyPress")
        Call Ctl_Item_KeyPress(BD_HINNMB(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_SIKTK_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_SIKTK.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_KeyPress")
        Call Ctl_Item_KeyPress(BD_SIKTK(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_UNTNM_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_UNTNM.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_KeyPress")
        Call Ctl_Item_KeyPress(BD_UNTNM(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub BD_HINCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BD_HINCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_KeyPress")
        Call Ctl_Item_KeyPress(BD_HINCD(Index), KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_JDNDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_JDNDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_JDNDT_KeyPress")
        Call Ctl_Item_KeyPress(HD_JDNDT, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub HD_DEFNOKDT_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_DEFNOKDT.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_DEFNOKDT_KeyPress")
        Call Ctl_Item_KeyPress(HD_DEFNOKDT, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
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

    Private Sub HD_BUN_FUKA_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BUN_FUKA.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Debug.Print("HD_BUN_FUKA_KeyPress")
        Call Ctl_Item_KeyPress(HD_BUN_FUKA, KeyAscii)
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub CS_MITNO_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
        Debug.Print("CS_MITNO_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(CS_MITNO)
    End Sub

    Private Sub CS_JDNNO_KeyUp(ByRef KeyCode As Short, ByRef Shift As Short)
        Debug.Print("CS_JDNNO_KeyUp")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_KeyUp(CS_JDNNO)
    End Sub

    'Private Sub BD_SELECTB_GotFocus(Index As Integer)
    '    Debug.Print "BD_SELECTB_GotFocus"
    '    Call Ctl_Item_GotFocus(BD_SELECTB(Index))
    'End Sub

    'Private Sub BD_SELECT_GotFocus(Index As Integer)
    '    Debug.Print "BD_SELECT_GotFocus"
    '    Call Ctl_Item_GotFocus(BD_SELECT(Index))
    'End Sub

    Private Sub CS_HIK_GotFocus()
        Debug.Print("CS_HIK_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/01 CHG START
        'Call Ctl_Item_GotFocus(CS_HIK)
        Call Ctl_Item_GotFocus(btnF6)
        '2019/10/01 CHG END
    End Sub

    Private Sub HD_MITNOV_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNOV.Enter
        Debug.Print("HD_MITNOV_GotFocus")
        Call Ctl_Item_GotFocus(HD_MITNOV)
    End Sub

    Private Sub HD_MITNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNO.Enter
        Debug.Print("HD_MITNO_GotFocus")
        Call Ctl_Item_GotFocus(HD_MITNO)
    End Sub

    Private Sub HD_JDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Enter
        Debug.Print("HD_JDNNO_GotFocus")
        Call Ctl_Item_GotFocus(HD_JDNNO)
    End Sub

    Private Sub CS_MITNO_GotFocus()
        Debug.Print("CS_MITNO_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_MITNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_MITNO)
    End Sub

    Private Sub CS_JDNNO_GotFocus()
        Debug.Print("CS_JDNNO_GotFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_JDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call Ctl_Item_GotFocus(CS_JDNNO)
    End Sub

    Private Sub TL_SBAUZEKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.Enter
        Debug.Print("TL_SBAUZEKN_GotFocus")
        Call Ctl_Item_GotFocus(TL_SBAUZEKN)
    End Sub

    Private Sub TL_SBAUODKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUODKN.Enter
        Debug.Print("TL_SBAUODKN_GotFocus")
        Call Ctl_Item_GotFocus(TL_SBAUODKN)
    End Sub

    Private Sub TL_SBAUZKKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZKKN.Enter
        Debug.Print("TL_SBAUZKKN_GotFocus")
        Call Ctl_Item_GotFocus(TL_SBAUZKKN)
    End Sub

    Private Sub HD_NHSNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.Enter
        Debug.Print("HD_NHSNMB_GotFocus")
        Call Ctl_Item_GotFocus(HD_NHSNMB)
    End Sub

    Private Sub HD_NHSNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.Enter
        Debug.Print("HD_NHSNMA_GotFocus")
        Call Ctl_Item_GotFocus(HD_NHSNMA)
    End Sub

    Private Sub HD_NHSCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Enter
        Debug.Print("HD_NHSCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_NHSCD)
    End Sub

    Private Sub HD_KENNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMB.Enter
        Debug.Print("HD_KENNMB_GotFocus")
        Call Ctl_Item_GotFocus(HD_KENNMB)
    End Sub

    Private Sub HD_KENNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Enter
        Debug.Print("HD_KENNMA_GotFocus")
        Call Ctl_Item_GotFocus(HD_KENNMA)
    End Sub

    Private Sub HD_OPEID_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Enter
        Debug.Print("HD_OPEID_GotFocus")
        Call Ctl_Item_GotFocus(HD_OPEID)
    End Sub

    Private Sub HD_OPENM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Enter
        Debug.Print("HD_OPENM_GotFocus")
        Call Ctl_Item_GotFocus(HD_OPENM)
    End Sub

    Private Sub BD_GNKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_GNKCD.Enter
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_GotFocus")
        Call Ctl_Item_GotFocus(BD_GNKCD(Index))
    End Sub

    Private Sub HD_URIKJN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.Enter
        Debug.Print("HD_URIKJN_GotFocus")
        Call Ctl_Item_GotFocus(HD_URIKJN)
    End Sub

    Private Sub HD_BINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.Enter
        Debug.Print("HD_BINCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_BINCD)
    End Sub

    Private Sub HD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Enter
        Debug.Print("HD_TOKJDNNO_GotFocus")
        Call Ctl_Item_GotFocus(HD_TOKJDNNO)
    End Sub

    Private Sub BD_TOKJDNNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.Enter
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_GotFocus")
        Call Ctl_Item_GotFocus(BD_TOKJDNNO(Index))
    End Sub

    Private Sub HD_URIKJNNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.Enter
        Debug.Print("HD_URIKJNNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_URIKJNNM)
    End Sub

    Private Sub HD_JDNTRNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.Enter
        Debug.Print("HD_JDNTRNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_JDNTRNM)
    End Sub

    Private Sub HD_JDNTRKB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Enter
        Debug.Print("HD_JDNTRKB_GotFocus")
        Call Ctl_Item_GotFocus(HD_JDNTRKB)
    End Sub

    Private Sub BD_ODNYTDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ODNYTDT.Enter
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_GotFocus")
        Call Ctl_Item_GotFocus(BD_ODNYTDT(Index))
    End Sub

    Private Sub BD_SIKRT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKRT.Enter
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_GotFocus")
        Call Ctl_Item_GotFocus(BD_SIKRT(Index))
    End Sub

    Private Sub BD_UODKN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN.Enter
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_GotFocus")
        Call Ctl_Item_GotFocus(BD_UODKN(Index))
    End Sub

    Private Sub BD_TEIKATK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.Enter
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_GotFocus")
        Call Ctl_Item_GotFocus(BD_TEIKATK(Index))
    End Sub

    Private Sub BD_UODTK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODTK.Enter
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_GotFocus")
        Call Ctl_Item_GotFocus(BD_UODTK(Index))
    End Sub

    Private Sub BD_UODSU_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU.Enter
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_GotFocus")
        Call Ctl_Item_GotFocus(BD_UODSU(Index))
    End Sub

    Private Sub HD_TOKRN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Enter
        Debug.Print("HD_TOKRN_GotFocus")
        Call Ctl_Item_GotFocus(HD_TOKRN)
    End Sub

    Private Sub HD_TOKCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Enter
        Debug.Print("HD_TOKCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_TOKCD)
    End Sub

    Private Sub HD_BUMNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMNM.Enter
        Debug.Print("HD_BUMNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_BUMNM)
    End Sub

    Private Sub HD_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Enter
        Debug.Print("HD_TANNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_TANNM)
    End Sub

    Private Sub HD_BINNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINNM.Enter
        Debug.Print("HD_BINNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_BINNM)
    End Sub

    Private Sub HD_BUMCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.Enter
        Debug.Print("HD_BUMCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_BUMCD)
    End Sub

    Private Sub HD_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Enter
        Debug.Print("HD_TANCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_TANCD)
    End Sub

    Private Sub HD_SOUCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Enter
        Debug.Print("HD_SOUCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_SOUCD)
    End Sub

    Private Sub HD_SOUNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Enter
        Debug.Print("HD_SOUNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_SOUNM)
    End Sub

    Private Sub HD_IN_TANNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Enter
        Debug.Print("HD_IN_TANNM_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Enter
        Debug.Print("HD_IN_TANCD_GotFocus")
        Call Ctl_Item_GotFocus(HD_IN_TANCD)
    End Sub

    Private Sub BD_LINNO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Enter
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINNO(Index))
    End Sub

    Private Sub BD_HINNMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.Enter
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_GotFocus")
        Call Ctl_Item_GotFocus(BD_HINNMA(Index))
    End Sub

    Private Sub BD_HINNMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.Enter
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_GotFocus")
        Call Ctl_Item_GotFocus(BD_HINNMB(Index))
    End Sub

    Private Sub BD_SIKTK_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.Enter
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_GotFocus")
        Call Ctl_Item_GotFocus(BD_SIKTK(Index))
    End Sub

    Private Sub BD_UNTNM_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.Enter
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_GotFocus")
        Call Ctl_Item_GotFocus(BD_UNTNM(Index))
    End Sub

    Private Sub BD_HINCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.Enter
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_GotFocus")
        Call Ctl_Item_GotFocus(BD_HINCD(Index))
    End Sub

    Private Sub HD_JDNDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.Enter
        Debug.Print("HD_JDNDT_GotFocus")
        Call Ctl_Item_GotFocus(HD_JDNDT)
    End Sub

    Private Sub HD_DEFNOKDT_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEFNOKDT.Enter
        Debug.Print("HD_DEFNOKDT_GotFocus")
        Call Ctl_Item_GotFocus(HD_DEFNOKDT)
    End Sub

    Private Sub BD_SELECTB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SELECTB.Enter
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_GotFocus")
        Call Ctl_Item_GotFocus(BD_SELECTB(Index))
    End Sub

    Private Sub BD_LINCMB_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Enter
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Enter
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_GotFocus")
        Call Ctl_Item_GotFocus(BD_LINCMA(Index))
    End Sub

    Private Sub HD_BUN_FUKA_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUN_FUKA.Enter
        Debug.Print("HD_BUN_FUKA_GotFocus")
        Call Ctl_Item_GotFocus(HD_BUN_FUKA)
    End Sub

    Private Sub CS_HIK_LostFocus()
        Debug.Print("CS_HIK_LostFocus")
        'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/01 CHG START
        'Call Ctl_Item_LostFocus(CS_HIK)
        Call Ctl_Item_LostFocus(btnF6)
        '2019/10/01 CHG END
    End Sub

    Private Sub HD_MITNOV_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNOV.Leave
        Debug.Print("HD_MITNOV_LostFocus")
        Call Ctl_Item_LostFocus(HD_MITNOV)
    End Sub

    Private Sub HD_MITNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNO.Leave
        Debug.Print("HD_MITNO_LostFocus")
        Call Ctl_Item_LostFocus(HD_MITNO)
    End Sub

    Private Sub HD_JDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.Leave
        Debug.Print("HD_JDNNO_LostFocus")
        Call Ctl_Item_LostFocus(HD_JDNNO)
    End Sub

    Private Sub TL_SBAUZEKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.Leave
        Debug.Print("TL_SBAUZEKN_LostFocus")
        Call Ctl_Item_LostFocus(TL_SBAUZEKN)
    End Sub

    Private Sub TL_SBAUODKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUODKN.Leave
        Debug.Print("TL_SBAUODKN_LostFocus")
        Call Ctl_Item_LostFocus(TL_SBAUODKN)
    End Sub

    Private Sub TL_SBAUZKKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZKKN.Leave
        Debug.Print("TL_SBAUZKKN_LostFocus")
        Call Ctl_Item_LostFocus(TL_SBAUZKKN)
    End Sub

    Private Sub HD_NHSNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.Leave
        Debug.Print("HD_NHSNMB_LostFocus")
        Call Ctl_Item_LostFocus(HD_NHSNMB)
    End Sub

    Private Sub HD_NHSNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.Leave
        Debug.Print("HD_NHSNMA_LostFocus")
        Call Ctl_Item_LostFocus(HD_NHSNMA)
    End Sub

    Private Sub HD_NHSCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.Leave
        Debug.Print("HD_NHSCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_NHSCD)
    End Sub

    Private Sub HD_KENNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMB.Leave
        Debug.Print("HD_KENNMB_LostFocus")
        Call Ctl_Item_LostFocus(HD_KENNMB)
    End Sub

    Private Sub HD_KENNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.Leave
        Debug.Print("HD_KENNMA_LostFocus")
        Call Ctl_Item_LostFocus(HD_KENNMA)
    End Sub

    Private Sub HD_OPEID_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.Leave
        Debug.Print("HD_OPEID_LostFocus")
        Call Ctl_Item_LostFocus(HD_OPEID)
    End Sub

    Private Sub HD_OPENM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.Leave
        Debug.Print("HD_OPENM_LostFocus")
        Call Ctl_Item_LostFocus(HD_OPENM)
    End Sub

    Private Sub BD_GNKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_GNKCD.Leave
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_LostFocus")
        Call Ctl_Item_LostFocus(BD_GNKCD(Index))
    End Sub

    Private Sub HD_URIKJN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.Leave
        Debug.Print("HD_URIKJN_LostFocus")
        Call Ctl_Item_LostFocus(HD_URIKJN)
    End Sub

    Private Sub HD_BINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.Leave
        Debug.Print("HD_BINCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_BINCD)
    End Sub

    Private Sub HD_TOKJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.Leave
        Debug.Print("HD_TOKJDNNO_LostFocus")
        Call Ctl_Item_LostFocus(HD_TOKJDNNO)
    End Sub

    Private Sub BD_TOKJDNNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.Leave
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_LostFocus")
        Call Ctl_Item_LostFocus(BD_TOKJDNNO(Index))
    End Sub

    Private Sub HD_URIKJNNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.Leave
        Debug.Print("HD_URIKJNNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_URIKJNNM)
    End Sub

    Private Sub HD_JDNTRNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.Leave
        Debug.Print("HD_JDNTRNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_JDNTRNM)
    End Sub

    Private Sub HD_JDNTRKB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.Leave
        Debug.Print("HD_JDNTRKB_LostFocus")
        Call Ctl_Item_LostFocus(HD_JDNTRKB)
    End Sub

    Private Sub BD_ODNYTDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ODNYTDT.Leave
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_LostFocus")
        Call Ctl_Item_LostFocus(BD_ODNYTDT(Index))
    End Sub

    Private Sub BD_SIKRT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKRT.Leave
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_LostFocus")
        Call Ctl_Item_LostFocus(BD_SIKRT(Index))
    End Sub

    Private Sub BD_UODKN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN.Leave
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_LostFocus")
        Call Ctl_Item_LostFocus(BD_UODKN(Index))
    End Sub

    Private Sub BD_TEIKATK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.Leave
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_LostFocus")
        Call Ctl_Item_LostFocus(BD_TEIKATK(Index))
    End Sub

    Private Sub BD_UODTK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODTK.Leave
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_LostFocus")
        Call Ctl_Item_LostFocus(BD_UODTK(Index))
    End Sub

    Private Sub BD_UODSU_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU.Leave
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_LostFocus")
        Call Ctl_Item_LostFocus(BD_UODSU(Index))
    End Sub

    Private Sub HD_TOKRN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.Leave
        Debug.Print("HD_TOKRN_LostFocus")
        Call Ctl_Item_LostFocus(HD_TOKRN)
    End Sub

    Private Sub HD_TOKCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.Leave
        Debug.Print("HD_TOKCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_TOKCD)
    End Sub

    Private Sub HD_BUMNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMNM.Leave
        Debug.Print("HD_BUMNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_BUMNM)
    End Sub

    Private Sub HD_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.Leave
        Debug.Print("HD_TANNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_TANNM)
    End Sub

    Private Sub HD_BINNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINNM.Leave
        Debug.Print("HD_BINNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_BINNM)
    End Sub

    Private Sub HD_BUMCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.Leave
        Debug.Print("HD_BUMCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_BUMCD)
    End Sub

    Private Sub HD_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.Leave
        Debug.Print("HD_TANCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_TANCD)
    End Sub

    Private Sub HD_SOUCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.Leave
        Debug.Print("HD_SOUCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_SOUCD)
    End Sub

    Private Sub HD_SOUNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.Leave
        Debug.Print("HD_SOUNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_SOUNM)
    End Sub

    Private Sub HD_IN_TANNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.Leave
        Debug.Print("HD_IN_TANNM_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANNM)
    End Sub

    Private Sub HD_IN_TANCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.Leave
        Debug.Print("HD_IN_TANCD_LostFocus")
        Call Ctl_Item_LostFocus(HD_IN_TANCD)
    End Sub

    Private Sub BD_LINNO_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.Leave
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINNO(Index))
    End Sub

    Private Sub BD_HINNMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.Leave
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_LostFocus")
        Call Ctl_Item_LostFocus(BD_HINNMA(Index))
    End Sub

    Private Sub BD_HINNMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.Leave
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_LostFocus")
        Call Ctl_Item_LostFocus(BD_HINNMB(Index))
    End Sub

    Private Sub BD_SIKTK_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.Leave
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_LostFocus")
        Call Ctl_Item_LostFocus(BD_SIKTK(Index))
    End Sub

    Private Sub BD_UNTNM_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.Leave
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_LostFocus")
        Call Ctl_Item_LostFocus(BD_UNTNM(Index))
    End Sub

    Private Sub BD_HINCD_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.Leave
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_LostFocus")
        Call Ctl_Item_LostFocus(BD_HINCD(Index))
    End Sub

    Private Sub HD_JDNDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.Leave
        Debug.Print("HD_JDNDT_LostFocus")
        Call Ctl_Item_LostFocus(HD_JDNDT)
    End Sub

    Private Sub HD_DEFNOKDT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEFNOKDT.Leave
        Debug.Print("HD_DEFNOKDT_LostFocus")
        Call Ctl_Item_LostFocus(HD_DEFNOKDT)
    End Sub

    Private Sub BD_LINCMB_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.Leave
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINCMA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.Leave
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_LostFocus")
        Call Ctl_Item_LostFocus(BD_LINCMA(Index))
    End Sub

    Private Sub HD_BUN_FUKA_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUN_FUKA.Leave
        Debug.Print("HD_BUN_FUKA_LostFocus")
        Call Ctl_Item_LostFocus(HD_BUN_FUKA)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_MITNOV.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_MITNOV_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNOV.TextChanged
        Debug.Print("HD_MITNOV_Change")
        Call Ctl_Item_Change(HD_MITNOV)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_MITNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_MITNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_MITNO.TextChanged
        Debug.Print("HD_MITNO_Change")
        Call Ctl_Item_Change(HD_MITNO)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_JDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_JDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNNO.TextChanged
        Debug.Print("HD_JDNNO_Change")
        Call Ctl_Item_Change(HD_JDNNO)
    End Sub

    'UPGRADE_WARNING: �C�x���g TL_SBAUZEKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub TL_SBAUZEKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZEKN.TextChanged
        Debug.Print("TL_SBAUZEKN_Change")
        Call Ctl_Item_Change(TL_SBAUZEKN)
    End Sub

    'UPGRADE_WARNING: �C�x���g TL_SBAUODKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub TL_SBAUODKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUODKN.TextChanged
        Debug.Print("TL_SBAUODKN_Change")
        Call Ctl_Item_Change(TL_SBAUODKN)
    End Sub

    'UPGRADE_WARNING: �C�x���g TL_SBAUZKKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub TL_SBAUZKKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TL_SBAUZKKN.TextChanged
        Debug.Print("TL_SBAUZKKN_Change")
        Call Ctl_Item_Change(TL_SBAUZKKN)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_NHSNMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_NHSNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMB.TextChanged
        Debug.Print("HD_NHSNMB_Change")
        Call Ctl_Item_Change(HD_NHSNMB)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_NHSNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_NHSNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSNMA.TextChanged
        Debug.Print("HD_NHSNMA_Change")
        Call Ctl_Item_Change(HD_NHSNMA)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_NHSCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_NHSCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NHSCD.TextChanged
        Debug.Print("HD_NHSCD_Change")
        Call Ctl_Item_Change(HD_NHSCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_KENNMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_KENNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMB.TextChanged
        Debug.Print("HD_KENNMB_Change")
        Call Ctl_Item_Change(HD_KENNMB)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_KENNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_KENNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_KENNMA.TextChanged
        Debug.Print("HD_KENNMA_Change")
        Call Ctl_Item_Change(HD_KENNMA)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_OPEID.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_OPEID_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPEID.TextChanged
        Debug.Print("HD_OPEID_Change")
        Call Ctl_Item_Change(HD_OPEID)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_OPENM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_OPENM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_OPENM.TextChanged
        Debug.Print("HD_OPENM_Change")
        Call Ctl_Item_Change(HD_OPENM)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_GNKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_GNKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_GNKCD.TextChanged
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_Change")
        Call Ctl_Item_Change(BD_GNKCD(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_URIKJN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_URIKJN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJN.TextChanged
        Debug.Print("HD_URIKJN_Change")
        Call Ctl_Item_Change(HD_URIKJN)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_BINCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINCD.TextChanged
        Debug.Print("HD_BINCD_Change")
        Call Ctl_Item_Change(HD_BINCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TOKJDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TOKJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKJDNNO.TextChanged
        Debug.Print("HD_TOKJDNNO_Change")
        Call Ctl_Item_Change(HD_TOKJDNNO)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_TOKJDNNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_TOKJDNNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TOKJDNNO.TextChanged
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_Change")
        Call Ctl_Item_Change(BD_TOKJDNNO(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_URIKJNNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_URIKJNNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_URIKJNNM.TextChanged
        Debug.Print("HD_URIKJNNM_Change")
        Call Ctl_Item_Change(HD_URIKJNNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_JDNTRNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_JDNTRNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRNM.TextChanged
        Debug.Print("HD_JDNTRNM_Change")
        Call Ctl_Item_Change(HD_JDNTRNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_JDNTRKB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_JDNTRKB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNTRKB.TextChanged
        Debug.Print("HD_JDNTRKB_Change")
        Call Ctl_Item_Change(HD_JDNTRKB)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_ODNYTDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_ODNYTDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_ODNYTDT.TextChanged
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_Change")
        Call Ctl_Item_Change(BD_ODNYTDT(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_SIKRT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_SIKRT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKRT.TextChanged
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_Change")
        Call Ctl_Item_Change(BD_SIKRT(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UODKN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UODKN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODKN.TextChanged
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_Change")
        Call Ctl_Item_Change(BD_UODKN(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_TEIKATK.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_TEIKATK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_TEIKATK.TextChanged
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_Change")
        Call Ctl_Item_Change(BD_TEIKATK(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UODTK.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UODTK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODTK.TextChanged
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_Change")
        Call Ctl_Item_Change(BD_UODTK(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UODSU.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UODSU_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UODSU.TextChanged
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_Change")
        Call Ctl_Item_Change(BD_UODSU(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TOKRN.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TOKRN_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKRN.TextChanged
        Debug.Print("HD_TOKRN_Change")
        Call Ctl_Item_Change(HD_TOKRN)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TOKCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TOKCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TOKCD.TextChanged
        Debug.Print("HD_TOKCD_Change")
        Call Ctl_Item_Change(HD_TOKCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_BUMNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BUMNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMNM.TextChanged
        Debug.Print("HD_BUMNM_Change")
        Call Ctl_Item_Change(HD_BUMNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANNM.TextChanged
        Debug.Print("HD_TANNM_Change")
        Call Ctl_Item_Change(HD_TANNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_BINNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BINNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BINNM.TextChanged
        Debug.Print("HD_BINNM_Change")
        Call Ctl_Item_Change(HD_BINNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_BUMCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_BUMCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BUMCD.TextChanged
        Debug.Print("HD_BUMCD_Change")
        Call Ctl_Item_Change(HD_BUMCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_TANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_TANCD.TextChanged
        Debug.Print("HD_TANCD_Change")
        Call Ctl_Item_Change(HD_TANCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_SOUCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_SOUCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUCD.TextChanged
        Debug.Print("HD_SOUCD_Change")
        Call Ctl_Item_Change(HD_SOUCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_SOUNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_SOUNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_SOUNM.TextChanged
        Debug.Print("HD_SOUNM_Change")
        Call Ctl_Item_Change(HD_SOUNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_IN_TANNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_IN_TANNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANNM.TextChanged
        Debug.Print("HD_IN_TANNM_Change")
        Call Ctl_Item_Change(HD_IN_TANNM)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_IN_TANCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_IN_TANCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_IN_TANCD.TextChanged
        Debug.Print("HD_IN_TANCD_Change")
        Call Ctl_Item_Change(HD_IN_TANCD)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_LINNO.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINNO_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINNO.TextChanged
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_Change")
        Call Ctl_Item_Change(BD_LINNO(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_HINNMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_HINNMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMA.TextChanged
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_Change")
        Call Ctl_Item_Change(BD_HINNMA(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_HINNMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_HINNMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINNMB.TextChanged
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_Change")
        Call Ctl_Item_Change(BD_HINNMB(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_SIKTK.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_SIKTK_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_SIKTK.TextChanged
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_Change")
        Call Ctl_Item_Change(BD_SIKTK(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_UNTNM.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_UNTNM_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_UNTNM.TextChanged
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_Change")
        Call Ctl_Item_Change(BD_UNTNM(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_HINCD.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_HINCD_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_HINCD.TextChanged
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_Change")
        Call Ctl_Item_Change(BD_HINCD(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_JDNDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_JDNDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_JDNDT.TextChanged
        Debug.Print("HD_JDNDT_Change")
        Call Ctl_Item_Change(HD_JDNDT)
    End Sub

    'UPGRADE_WARNING: �C�x���g HD_DEFNOKDT.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub HD_DEFNOKDT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_DEFNOKDT.TextChanged
        Debug.Print("HD_DEFNOKDT_Change")
        Call Ctl_Item_Change(HD_DEFNOKDT)
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_LINCMB.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINCMB_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMB.TextChanged
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_Change")
        Call Ctl_Item_Change(BD_LINCMB(Index))
    End Sub

    'UPGRADE_WARNING: �C�x���g BD_LINCMA.TextChanged �́A�t�H�[�������������ꂽ�Ƃ��ɔ������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' ���N���b�N���Ă��������B
    Private Sub BD_LINCMA_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BD_LINCMA.TextChanged
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_Change")
        Call Ctl_Item_Change(BD_LINCMA(Index))
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
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TX_Message_KeyDown")
        Call Ctl_Item_KeyDown(TX_Message, KeyCode, Shift)
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

    ' === 20060804 === DELETE S - ACE)Nagasawa
    'Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '    Debug.Print "Image1_MouseDown"
    '    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
    'End Sub
    ' === 20060804 === DELETE E -

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

    Public Sub MN_NEXTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_NEXTCM.Click
        Debug.Print("MN_NEXTCM_Click")
        Call Ctl_Item_Click(MN_NEXTCM)
    End Sub

    Public Sub MN_PREV_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_PREV.Click
        Debug.Print("MN_PREV_Click")
        Call Ctl_Item_Click(MN_PREV)
    End Sub

    Public Sub MN_SELECTCM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_SELECTCM.Click
        Debug.Print("MN_SELECTCM_Click")
        Call Ctl_Item_Click(MN_SELECTCM)
    End Sub

    Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason

        '���b�Z�[�W�o��
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_A_001, Main_Inf) <> MsgBoxResult.Yes Then
            Cancel = True
            '2019/09/26 ADD START
            eventArgs.Cancel = Cancel
            '2019/09/26 ADD END
            Exit Sub
        End If
        ' === 20060907 === INSERT S - ACE)Sejima
        Main_Inf.Dsp_Base.IsUnload = True
        ' === 20060907 === INSERT E

        ' === 20060802 === INSERT S - ACE)Nagasawa
        'DB�ڑ�����
        '2019/09/20 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        ' === 20060802 === INSERT E -
        DB_CLOSE(CON)
        DB_CLOSE(CON_USR9)
        '2019/09/20 CHG END

        ' === 20061102 === INSERT S - ACE)Yano ۸�̧�ُ����݁i�v���O�����I���j
        Call SSSWIN_LOGWRT("�v���O�����I��")
        ' === 20061102 === INSERT E

        '���ʏI�������H
        'UPGRADE_NOTE: �I�u�W�F�N�g FR_SSSMAIN ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '2019/09/20 DEL START
        'Me = Nothing
        '2019/09/20 DEL END

        eventArgs.Cancel = Cancel
    End Sub


    ' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
    Private Sub BD_GNKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_GNKCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_GNKCD.GetIndex(eventSender)
        Debug.Print("BD_GNKCD_KeyUp")
        Call Ctl_Item_KeyUp(BD_GNKCD(Index))
    End Sub

    Private Sub BD_HINCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINCD.GetIndex(eventSender)
        Debug.Print("BD_HINCD_KeyUp")
        Call Ctl_Item_KeyUp(BD_HINCD(Index))
    End Sub

    Private Sub BD_HINNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINNMA.GetIndex(eventSender)
        Debug.Print("BD_HINNMA_KeyUp")
        Call Ctl_Item_KeyUp(BD_HINNMA(Index))
    End Sub

    Private Sub BD_HINNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_HINNMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_HINNMB.GetIndex(eventSender)
        Debug.Print("BD_HINNMB_KeyUp")
        Call Ctl_Item_KeyUp(BD_HINNMB(Index))
    End Sub

    Private Sub BD_LINCMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMA.GetIndex(eventSender)
        Debug.Print("BD_LINCMA_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINCMA(Index))
    End Sub

    Private Sub BD_LINCMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINCMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINCMB.GetIndex(eventSender)
        Debug.Print("BD_LINCMB_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINCMB(Index))
    End Sub

    Private Sub BD_LINNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_LINNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_LINNO.GetIndex(eventSender)
        Debug.Print("BD_LINNO_KeyUp")
        Call Ctl_Item_KeyUp(BD_LINNO(Index))
    End Sub

    Private Sub BD_ODNYTDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_ODNYTDT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_ODNYTDT.GetIndex(eventSender)
        Debug.Print("BD_ODNYTDT_KeyUp")
        Call Ctl_Item_KeyUp(BD_ODNYTDT(Index))
    End Sub

    Private Sub BD_SELECTB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SELECTB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SELECTB.GetIndex(eventSender)
        Debug.Print("BD_SELECTB_KeyUp")
        Call Ctl_Item_KeyUp(BD_SELECTB(Index))
    End Sub

    Private Sub BD_SIKRT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKRT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKRT.GetIndex(eventSender)
        Debug.Print("BD_SIKRT_KeyUp")
        Call Ctl_Item_KeyUp(BD_SIKRT(Index))
    End Sub

    Private Sub BD_SIKTK_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_SIKTK.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_SIKTK.GetIndex(eventSender)
        Debug.Print("BD_SIKTK_KeyUp")
        Call Ctl_Item_KeyUp(BD_SIKTK(Index))
    End Sub

    Private Sub BD_TEIKATK_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TEIKATK.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TEIKATK.GetIndex(eventSender)
        Debug.Print("BD_TEIKATK_KeyUp")
        Call Ctl_Item_KeyUp(BD_TEIKATK(Index))
    End Sub

    Private Sub BD_TOKJDNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_TOKJDNNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_TOKJDNNO.GetIndex(eventSender)
        Debug.Print("BD_TOKJDNNO_KeyUp")
        Call Ctl_Item_KeyUp(BD_TOKJDNNO(Index))
    End Sub

    Private Sub BD_UNTNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UNTNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UNTNM.GetIndex(eventSender)
        Debug.Print("BD_UNTNM_KeyUp")
        Call Ctl_Item_KeyUp(BD_UNTNM(Index))
    End Sub

    Private Sub BD_UODKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODKN.GetIndex(eventSender)
        Debug.Print("BD_UODKN_KeyUp")
        Call Ctl_Item_KeyUp(BD_UODKN(Index))
    End Sub

    Private Sub BD_UODSU_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODSU.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODSU.GetIndex(eventSender)
        Debug.Print("BD_UODSU_KeyUp")
        Call Ctl_Item_KeyUp(BD_UODSU(Index))
    End Sub

    Private Sub BD_UODTK_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles BD_UODTK.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = BD_UODTK.GetIndex(eventSender)
        Debug.Print("BD_UODTK_KeyUp")
        Call Ctl_Item_KeyUp(BD_UODTK(Index))
    End Sub

    Private Sub HD_BINCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BINCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_BINCD)
    End Sub

    Private Sub HD_BINNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BINNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BINNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_BINNM)
    End Sub

    Private Sub HD_BUMCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUMCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUMCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_BUMCD)
    End Sub

    Private Sub HD_BUMNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUMNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUMNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_BUMNM)
    End Sub

    Private Sub HD_BUN_FUKA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BUN_FUKA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_BUN_FUKA_KeyUp")
        Call Ctl_Item_KeyUp(HD_BUN_FUKA)
    End Sub

    Private Sub HD_DEFNOKDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_DEFNOKDT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_DEFNOKDT_KeyUp")
        Call Ctl_Item_KeyUp(HD_DEFNOKDT)
    End Sub

    Private Sub HD_IN_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANCD)
    End Sub

    Private Sub HD_IN_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_IN_TANNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_IN_TANNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_IN_TANNM)
    End Sub

    Private Sub HD_JDNDT_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNDT.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNDT_KeyUp")
        Call Ctl_Item_KeyUp(HD_JDNDT)
    End Sub

    Private Sub HD_JDNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNNO_KeyUp")
        Call Ctl_Item_KeyUp(HD_JDNNO)
        '2019/10/09 ADD START
        HD_MITNOV.BackColor = COLOR_WHITE
        '2019/10/09 ADD END
    End Sub

    Private Sub HD_JDNTRKB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRKB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNTRKB_KeyUp")
        Call Ctl_Item_KeyUp(HD_JDNTRKB)
    End Sub

    Private Sub HD_JDNTRNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_JDNTRNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_JDNTRNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_JDNTRNM)
    End Sub

    Private Sub HD_KENNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KENNMA_KeyUp")
        Call Ctl_Item_KeyUp(HD_KENNMA)
    End Sub

    Private Sub HD_KENNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_KENNMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_KENNMB_KeyUp")
        Call Ctl_Item_KeyUp(HD_KENNMB)
    End Sub

    Private Sub HD_MITNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MITNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_MITNO_KeyUp")
        Call Ctl_Item_KeyUp(HD_MITNO)
    End Sub

    Private Sub HD_MITNOV_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_MITNOV.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_MITNOV_KeyUp")
        Call Ctl_Item_KeyUp(HD_MITNOV)
        '2019/10/09 ADD START
        HD_MITNO.BackColor = COLOR_WHITE
        '2019/10/09 ADD END
    End Sub

    Private Sub HD_NHSCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_NHSCD)
    End Sub

    Private Sub HD_NHSNMA_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMA.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSNMA_KeyUp")
        Call Ctl_Item_KeyUp(HD_NHSNMA)
    End Sub

    Private Sub HD_NHSNMB_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NHSNMB.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_NHSNMB_KeyUp")
        Call Ctl_Item_KeyUp(HD_NHSNMB)
    End Sub

    Private Sub HD_OPEID_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPEID.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_OPEID_KeyUp")
        Call Ctl_Item_KeyUp(HD_OPEID)
    End Sub

    Private Sub HD_OPENM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_OPENM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_OPENM_KeyUp")
        Call Ctl_Item_KeyUp(HD_OPENM)
    End Sub

    Private Sub HD_SOUCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_SOUCD)
    End Sub

    Private Sub HD_SOUNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_SOUNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_SOUNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_SOUNM)
    End Sub

    Private Sub HD_TANCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TANCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_TANCD)
    End Sub

    Private Sub HD_TANNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TANNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TANNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_TANNM)
    End Sub

    Private Sub HD_TOKCD_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKCD.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKCD_KeyUp")
        Call Ctl_Item_KeyUp(HD_TOKCD)
    End Sub

    Private Sub HD_TOKJDNNO_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKJDNNO.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKJDNNO_KeyUp")
        Call Ctl_Item_KeyUp(HD_TOKJDNNO)
    End Sub

    Private Sub HD_TOKRN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_TOKRN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_TOKRN_KeyUp")
        Call Ctl_Item_KeyUp(HD_TOKRN)
    End Sub

    Private Sub HD_URIKJN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_URIKJN_KeyUp")
        Call Ctl_Item_KeyUp(HD_URIKJN)
    End Sub

    Private Sub HD_URIKJNNM_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_URIKJNNM.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("HD_URIKJNNM_KeyUp")
        Call Ctl_Item_KeyUp(HD_URIKJNNM)
    End Sub

    Private Sub TL_SBAUODKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUODKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUODKN_KeyUp")
        Call Ctl_Item_KeyUp(TL_SBAUODKN)
    End Sub

    Private Sub TL_SBAUZEKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUZEKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUZEKN_KeyUp")
        Call Ctl_Item_KeyUp(TL_SBAUZEKN)
    End Sub

    Private Sub TL_SBAUZKKN_KeyUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TL_SBAUZKKN.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Debug.Print("TL_SBAUZKKN_KeyUp")
        Call Ctl_Item_KeyUp(TL_SBAUZKKN)
    End Sub

    ' === 20060802 === INSERT E -

    ' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�Ή�
    Private Sub CS_HIK_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
        Debug.Print("CS_HIK_KeyDown")
        If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g CS_HIK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call Ctl_Item_KeyDown(CS_HIK, KeyCode, Shift)
        End If
    End Sub
    ' === 20060930 === INSERT E -
    Private Sub VS_Scrl_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VS_Scrl.Scroll
        Select Case eventArgs.type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                VS_Scrl_Change(eventArgs.newValue)
        End Select
    End Sub

    '2019/09/20 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Set_Frm_IN_TANCD_HIKET51
    '   �T�v�F  ���͒S���ҕҏW
    '   �����F�@pm_Form        :�t�H�[��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD_HIKET51(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

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

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click

    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        Call Ctl_Item_Click(btnF2)
    End Sub

    Private Sub btnF3_Click(sender As Object, e As EventArgs) Handles btnF3.Click

    End Sub

    Private Sub btnF4_Click(sender As Object, e As EventArgs) Handles btnF4.Click

    End Sub

    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        Ctl_Item_Click(btnF5)
    End Sub

    Private Sub btnF6_Click(sender As Object, e As EventArgs) Handles btnF6.Click
        Call Ctl_Item_Click(btnF6)
    End Sub

    Private Sub btnF7_Click(sender As Object, e As EventArgs) Handles btnF7.Click

    End Sub

    Private Sub btnF8_Click(sender As Object, e As EventArgs) Handles btnF8.Click

    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call Ctl_Item_Click(btnF9)
    End Sub

    Private Sub btnF10_Click(sender As Object, e As EventArgs) Handles btnF10.Click

    End Sub

    Private Sub btnF11_Click(sender As Object, e As EventArgs) Handles btnF11.Click

    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Call Ctl_Item_Click(btnF12)
    End Sub

    Private Sub CS_MITNO_Click(sender As Object, e As EventArgs) Handles CS_MITNO.Click
        Call Ctl_Item_Click(CS_MITNO)
    End Sub

    Private Sub CS_JDNNO_Click(sender As Object, e As EventArgs) Handles CS_JDNNO.Click
        Call Ctl_Item_Click(CS_JDNNO)
    End Sub

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

    Private Sub FR_SSSMAIN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F2
                    '����
                    Me.btnF2.PerformClick()

                Case Keys.F5
                    '�Q��
                    Me.btnF5.PerformClick()

                Case Keys.F6
                    '�����^����
                    Me.btnF6.PerformClick()

                Case Keys.F9
                    '�N���A
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '�I��
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    Private Sub CS_HIK_Click(sender As Object, e As EventArgs) Handles CS_HIK.Click
        Call Ctl_Item_Click(CS_HIK)
    End Sub

    '2019/09/20 ADD END

End Class
