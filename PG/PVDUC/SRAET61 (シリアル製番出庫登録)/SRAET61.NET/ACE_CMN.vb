Option Strict Off
Option Explicit On
Module ACE_CMN
	'//* All Right Reserved Copy Right (C)  ������Еx�m�ʊ֐��V�X�e���Y
	'//***************************************************************************************
	'//*
	'//*�����́�
	'//*    ACE_CMN.bas
	'//*
	'//*���o�[�W������
	'//* 1.00
	'//*
	'//*���쐬�ҁ�
	'//* FKS)
	'//*
	'//*��������
	'//*    ���ʃ��W���[��
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|-------------------------------------------------
	'//* 1.00     |20021101|FKS)           |�V�K�쐬
	'//**************************************************************************************
	
	'//�F�ݒ�
	'UPGRADE_NOTE: COLOR_BLACK �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_BLACK As System.Drawing.Color = System.Drawing.Color.Black '���F = &H0&
	'UPGRADE_NOTE: COLOR_YELLOW �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_YELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '���F = &HFFFF&
	'UPGRADE_NOTE: COLOR_RED �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_RED As System.Drawing.Color = System.Drawing.Color.Red '�ԐF = &HFF&
	'UPGRADE_NOTE: COLOR_WHITE �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_WHITE As System.Drawing.Color = System.Drawing.Color.White '���F = &HFFFFFF
	'UPGRADE_NOTE: COLOR_GRAY �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_GRAY As System.Drawing.Color = System.Drawing.SystemColors.Control '�D�F = &H8000000F&
	
	'//��ʕ���
	Public Const DSP_CTG_REFERENCE As String = "REFERENCE" '�Ɖ�n
	Public Const DSP_CTG_ENTRY As String = "ENTRY" '�o�^�n(�V�K����)
	Public Const DSP_CTG_REVISION As String = "REVISION" '�C���n
	
	'//��ʓ��͈�
	Public Const IN_AREA_DSP_MN As String = "1" '���j���[
	Public Const IN_AREA_DSP_HD As String = "2" '�w�b�_
	Public Const IN_AREA_DSP_HD2 As String = "22" '�w�b�_�Q
	Public Const IN_AREA_DSP_HD3 As String = "23" '�w�b�_�R
	Public Const IN_AREA_DSP_BD As String = "3" '����
	Public Const IN_AREA_DSP_TL As String = "4" '�t�b�^
	Public Const IN_AREA_DSP_MS As String = "5" '���b�Z�[�W
	Public Const IN_AREA_ELSE As String = "99" '���̑�
	
	'//���̓^�C�v
	Public Const IN_TYP_NUM As Short = 1 '���l
	Public Const IN_TYP_DATE As Short = 2 '���t
	Public Const IN_TYP_CODE As Short = 3 '�R�[�h�n
	Public Const IN_TYP_STR As Short = 4 '����
	Public Const IN_TYP_YYYYMM As Short = 5 '�N��
	Public Const IN_TYP_HHMM As Short = 6 '����
	Public Const IN_TYP_HHMMSS As Short = 7 '�����b
	Public Const IN_TYP_ELSE As Short = 99 '�{�^���A�`�F�b�N�{�b�N�X�A�I�v�V�����Ȃ�
	
	'//���͕����^�C�v
	Public Const IN_STR_TYP_NUM As String = "NUM" '���l�݂̂O�`�X
	Public Const IN_STR_TYP_KIN As String = "KIN" '���ʁE���z�E�P���n
	Public Const IN_STR_TYP_X As String = "X" '���p
	Public Const IN_STR_TYP_N As String = "N" '�S�p
	Public Const IN_STR_TYP_NX As String = "NX" '����
	Public Const IN_STR_TYP_TEL As String = "TEL" '�d�b�EFAX�n
	Public Const IN_STR_TYP_ELSE As String = "ELSE" '���̑�
	
	'//���l�}�t���O
	Public Const IN_NUM_PLUS As Short = 1 '��׽
	Public Const IN_NUM_MINUS As Short = 2 'ϲŽ
	Public Const IN_NUM_PLUS_MINUS As Short = 3 '����
	Public Const IN_NUM_ELSE As Short = 99 '���̑�
	
	'//�\���`��
	Public Const DSP_FMT_DATE_SLASH As String = "0000/00/00" '���t����
	Public Const DSP_FMT_YYYYMM_SLASH As String = "0000/00" '�N������
	Public Const DSP_FMT_HHMM As String = "00:00" '����
	Public Const DSP_FMT_HHMMSS As String = "00:00:00" '�����b
	Public Const DSP_FMT_KIN_1 As String = "#,##0" '���z
	Public Const DSP_FMT_TAN_1 As String = "#,##0.00" '�P��
	Public Const DSP_FMT_RT_1 As String = "#,##0.0" '��
	
	'//���t���͌`��
	Public Const IN_FMT_DATE As String = "YYYYMMDD"
	Public Const IN_FMT_YYYMM As String = "YYYYMM"
	Public Const IN_FMT_HHMM As String = "HHMM"
	Public Const IN_FMT_HHMMSS As String = "HHMMSS"
	
	'//�l�����̑���
	Public Const FIL_POINT_LEFT As Short = 0 '����
	Public Const FIL_POINT_RIGHT As Short = 1 '�E��
	Public Const FIL_POINT_CENTER As Short = 2 '����
	Public Const FIL_POINT_ELSE As Short = 99 '���̑�
	
	'//����̫������
	Public Const ITEM_NORMAL_STATUS As String = "1" '�t�H�[�J�X�Ȃ�
	Public Const ITEM_SELECT_STATUS As String = "2" '�t�H�[�J�X����
	Public Const ITEM_INITIAL_STATUS As String = "3" '�������
	'//�O�i/�w�i�F�ݒ�(CF_Set_Item_Color)�̃��[�h
	Public Const ITEM_COLOR_DEF As Short = 0 '������
	Public Const ITEM_COLOR_NOMAL As Short = 1 '�ʏ�
	Public Const ITEM_COLOR_KEYPRESS As Short = 2 'KEYPRESS��̓��ʎd�l
	
	'//���ڴװ���
	Public Const ERR_DEF As String = "0" '�������
	Public Const ERR_NOT As String = "1" '�G���[�Ȃ�
	Public Const ERR_NOT_INPUT As String = "2" '�K�{���̖͂����̓G���[
	Public Const ERR_ELSE As String = "3" '���̑��G���[
	
	'//��ʍ���/�������e�̃t���O
	Public Const VALUE_FLG_DEF As Short = 0 '�����l
	Public Const VALUE_FLG_ELSE As Short = 1 '�����l�ȊO
	
	'//�����֐��ďo��
	Public Const CHK_FROM_LOSTFOCUS As String = "LOSTFOCUS" 'LOSTFOCUS
	Public Const CHK_FROM_KEYRETURN As String = "KEYRETURN" 'KEYRETURN
	Public Const CHK_FROM_KEYRIGHT As String = "KEYRIGHT" 'KEYRIGHT
	Public Const CHK_FROM_KEYDOWN As String = "KEYDOWN" 'KEYDOWN
	Public Const CHK_FROM_KEYLEFT As String = "KEYLEFT" 'KEYLEFT
	Public Const CHK_FROM_KEYUP As String = "KEYUP" 'KEYUP
	Public Const CHK_FROM_KEYPRESS As String = "KEYPRESS" 'KEYPRESS
	Public Const CHK_FROM_BACK_PROCESS As String = "BACK_PROCESS" '�������Ȃǂ̂o�f���哱�̏ꍇ
	Public Const CHK_FROM_ALL_CHK As String = "ALL_CHK" '�ꊇ�`�F�b�N�Ȃ�
	Public Const CHK_FROM_ALL_DEFAULT As String = "DEFAULT" '�������
	
	'//��ʃ{�f�B�s���
	Public Const BODY_ROW_STATE_DEFAULT As Short = 0 '�������
	Public Const BODY_ROW_STATE_INPUT_WAIT As Short = 1 '���͑ҏ��
	Public Const BODY_ROW_STATE_INPUT As Short = 2 '���͍Ϗ��
	Public Const BODY_ROW_STATE_LST_ROW As Short = 3 '�ŏI�����s(���͑ҏ��)
	
	'//�����t���O
	Public Const BODY_ROW_REST_FLG_NOT As Short = 0 '�������
	Public Const BODY_ROW_REST_FLG_CLR As Short = 1 '�������L(���׏������̕������)
	Public Const BODY_ROW_REST_FLG_DEL As Short = 2 '�������L(���׍폜�̕������)
	
	'**�����֐��֘A Start **
	'//�ߒl
	Public Const CHK_BASE_OK As Short = 0 '����
	Public Const CHK_BASE_ERR_CODE As Short = 1 '�����R�[�h�G���[
	Public Const CHK_BASE_ERR_OVER As Short = 2 '�����G���[
	Public Const CHK_BASE_ERR_TYP As Short = 3 '�����G���[
	'**�����֐��֘A End **
	
	'//���ڃN���A(CF_Init_Clr_Dsp)�̃��[�h
	Public Const ITM_ALL_CLR As Short = 0 '�S���ڃN���A
	Public Const ITM_ALL_ONLY As Short = 1 '�ʃN���A
	'//�s�N���A(CF_Init_Clr_Dsp_Body)�̃��[�h
	Public Const BODY_ALL_CLR As Short = 0 '�S���ڃN���A
	Public Const BODY_ALL_ONLY As Short = 1 '�ʃN���A
	
	'//���ʍ��ڑI��(CF_Set_Sel_Ini)�̃��[�h
	Public Const SEL_INI_MODE_1 As String = "1" '���t���ځ��N�^�N�����ځ��N�^�������ځ���
	Public Const SEL_INI_MODE_2 As String = "2" '���t���ځ����^�N�����ځ����^�������ځ���
	
	'//���ڕҏW���[�h(CF_Set_Item_Direct�ACF_Set_Bef_Rest_Value�ACF_Edi_Dsp_Body_Inf)
	Public Const SET_FLG_NOMAL As Short = 0 '�ʏ�ҏW
	Public Const SET_FLG_DEF As Short = 1 '�����l�ҏW
	Public Const SET_FLG_DB As Short = 2 '�c�a���e�ҏW
	Public Const SET_FLG_DB_ERR As Short = 3 '�c�a���e�ҏW(�G���[����)
	
	'-----------------------------------------------------------------------------------------------------------
	'��ʍ��ڏڍ׏��\����
	Private Structure Cls_Dsp_Sub_Detail_Inf
		Dim Item_Nm As String '��ʍ��ږ�(���۰ٖ�)
		Dim In_Area As String '��ʓ��͈�
		Dim In_Typ As Short '���̓^�C�v
		Dim In_Str_Typ As String '���͕����^�C�v
		Dim MaxLengthB As Short '�ő�o�C�g��
		Dim Dsp_MaxLengthB As Short '�\���ő�o�C�g��
		Dim Num_Int_Fig As Short '���l�̐�������
		Dim Num_Fra_Fig As Short '���l�̏���������
		Dim Num_Sign_Fig As Short '���l�}�t���O
		Dim Fil_Chr As String '�\�����̋l����
		Dim Fil_Point As Short '÷�ď�ŋl�߂镶���̈ʒu
		Dim Dsp_Fmt As String '�\������
		Dim Body_Index As Short '���ו��m�n�i�P�`�A�w�b�_/�t�b�^�̏ꍇ�́A�O�Œ�j
		'********�������ݒ肩��ύX����Ȃ��A����������ŕύX����***********************************************************
		Dim Dsp_Value As Object '��ʍ��ړ��e
		Dim Focus_Ctl As Boolean '�t�H�[�J�X����(T:̫����Ȃ��AF:̫�������)
		'�\��/���͂��؂�ւ��ꍇ�ɐݒ肷��
		Dim Focus_Ctl_Bk As Boolean '�ޔ��t�H�[�J�X����(�����������ɒ�`���ꂽFocus_Ctl�̐ݒ�ێ�����)
		Dim Bef_Value As Object '�O����e
		Dim Bef_Value_Flg As Short '�O����e�t���O
		Dim Rest_Value As Object '�������e
		Dim Rest_Value_Flg As Short '�������e�t���O
		Dim In_Value_Flg As Boolean '���̓t���O(T:հ�ް���͗L�AF:��ް���͖�)
		Dim Item_Init_Flg As Boolean '���ڏ������t���O(T:�������n�j�AF:�������m�f)
		Dim Item_Rest_Flg As Boolean '���ڕ����t���O(T:�����n�j�AF:�����m�f)
		Dim Bef_Chk_Value As Object '�O��`�F�b�N���e
		Dim Err_Status As String '���ڂ̃G���[���
		Dim Locked As Boolean '�ǎ��p�t���O
		Dim Not_Input_Chk_Fin_Flg As Boolean '�����͈ȊO�̃`�F�b�N�σt���O
		'T:�����͈ȊO�̃`�F�b�N�����s�����ꍇ
		'F:���̑��̏��
		Dim Chk_From_Process As String '�`�F�b�N�֐��ďo������
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'��ʃ{�f�B�s���\����
	''''Public Type Cls_Dsp_Body_Row_Inf
	''''    Status                  As Integer                      '�Ώۍs�̏��
	''''    Item_Detail()           As Cls_Dsp_Sub_Detail_Inf       '�P�s�Ɋi�[����鍀�ڏ��
	''''    Bus_Inf                 As Cls_Dsp_Body_Bus_Inf         '�P�s�P�ʂ̋Ɩ����'�i�e�v���O������SSSMAIN0001�ŕK���錾����j
	''''End Type
	
	'''''��ʃ{�f�B�����s���\����
	''''Public Type Cls_Dsp_Rest_Inf
	''''    Rest_Flg                As Integer                      '�������̗L/��
	''''    Rest_Row                As Integer                      '�����s
	''''    Rest_Row_Inf            As Cls_Dsp_Body_Row_Inf         '�����s���
	''''End Type
	''''
	'''''��ʃ{�f�B���\����
	''''Public Type Cls_Dsp_Body_Inf
	''''    Cur_Top_Index               As Integer                  '�ŏ㖾�ײ��ޯ��
	''''    Row_Inf()                   As Cls_Dsp_Body_Row_Inf     '�P�s�P�ʂ̏��
	''''    Init_Row_Inf                As Cls_Dsp_Body_Row_Inf     '�������p�̂P�s�P�ʂ̏��
	''''    Rest_Inf                    As Cls_Dsp_Rest_Inf         '�����s�̂P�s�P�ʂ̏��
	''''End Type
	
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'��ʍ��ڏ��\����
	Public Structure Cls_Dsp_Sub_Inf
		Dim Ctl As System.Windows.Forms.Control '��ʃR���g���[��
		Dim Detail As Cls_Dsp_Sub_Detail_Inf '��ʍ��ڏڍ׏��
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'-----------------------------------------------------------------------------------------------------------
	'��ʊ�b���\����
	Public Structure Cls_Dsp_Base
		Dim Dsp_Ctg As String '��ʕ���(�Ɖ�n�A�o�^�n�A�C���n�j
		Dim Item_Cnt As Short '��ʍ��ڐ�
		Dim Dsp_Body_Cnt As Short '��ʕ\�����א��i�|�P,�O�F���ׂȂ��A�P�`�F�\�������א��j
		Dim Max_Body_Cnt As Short '�ő���͖��א��i�|�P�F���ׂȂ��A�O�F���׏�����P�`�F�\�������א��j
		Dim Body_Col_Cnt As Short '���ׂ̗񍀖ڐ�
		Dim Head_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
		Dim Body_Fst_Idx As Short '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
		Dim Foot_Fst_Idx As Short '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��
		Dim Dsp_Body_Move_Qty As Short '��ʈړ��ʁi�ő彸۰ٗʁA�y�[�W�{�^���̈ړ��ʁj
		'�i�O�F���ׂȂ��A�P�`�F�ړ��ʁj
		Dim Cursor_Idx As Short '���݂�̫����̲��ޯ��
		Dim Bef_Cursor_Idx As Short '�P�O��̫����̲��ޯ��
		Dim Change_Flg As Boolean '��ݼ޲���Đ����׸�
		Dim VS_Scr_Flg As Boolean '��۰���ݼ޲���Đ����׸�
		Dim LostFocus_Flg As Boolean '۽�̫�������Đ����׸�
		Dim Head_Ok_Flg As Boolean '�w�b�_���`�F�b�N�n�j�t���O
		Dim PopupMenu_Idx As Short '�߯�߱����ƭ���̫����̲��ޯ��
		Dim Head2_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��(���ϓo�^���ł̂ݎg�p)
		Dim Head3_Lst_Idx As Short '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��(�V�X�e���󒍓o�^���ł̂ݎg�p)
	End Structure
	'-----------------------------------------------------------------------------------------------------------
	'//��ʂ̲Ұ�ޏ��
	Public Structure Cls_Img_Inf
		Dim Click_On_Img As System.Windows.Forms.PictureBox
		Dim Click_Off_Img As System.Windows.Forms.PictureBox
	End Structure
	
	'//�S�\����
	Public Structure Cls_All
		'��ʊ�b���
		Dim Dsp_Base As Cls_Dsp_Base
		'��ʍ��ڏ��
		Dim Dsp_Sub_Inf() As Cls_Dsp_Sub_Inf
		''''    '��ʃ{�f�B���
		''''    Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		'�����ݒ�p�^�C�}�[
		Dim TM_StartUp_Ctl As System.Windows.Forms.Timer
		'���b�Z�[�W�d��
		Dim Dsp_IM_Denkyu As System.Windows.Forms.Control '��ʕ\���p
		Dim On_IM_Denkyu As System.Windows.Forms.Control '�d��ON
		Dim Off_IM_Denkyu As System.Windows.Forms.Control '�d��Off
		'���b�Z�[�W
		Dim Dsp_TX_Message As System.Windows.Forms.Control '��ʃ��b�Z�[�W
		'���׏c�X�N���[���o�[
		Dim Bd_Vs_Scrl As System.Windows.Forms.VScrollBar
		'�I���C���[�W���
		Dim IM_EndCm_Inf As Cls_Img_Inf
		'���s�C���[�W���
		Dim IM_Execute_Inf As Cls_Img_Inf
		'���[�v�����^�o�̓C���[�W���
		Dim IM_LSTART_Inf As Cls_Img_Inf
		'���[��ʕ\���C���[�W���
		Dim IM_VSTART_Inf As Cls_Img_Inf
		'�v�����^�ݒ�C���[�W���
		Dim IM_LCONFIG_Inf As Cls_Img_Inf
		'���גǉ��C���[�W���
		Dim IM_INSERTDE_Inf As Cls_Img_Inf
		'���׍폜�C���[�W���
		Dim IM_DELETEDE_Inf As Cls_Img_Inf
		'�����C���[�W���
		Dim IM_Slist_Inf As Cls_Img_Inf
		'�O�y�[�W�C���[�W���
		Dim IM_PrevCm_Inf As Cls_Img_Inf
		'���y�[�W�C���[�W���
		Dim IM_NextCm_Inf As Cls_Img_Inf
		'���ו��N���A�{�^���C���[�W���i���{�f�B������w�b�_���ɐ����߂��{�^���j
		Dim IM_SelectCm_Inf As Cls_Img_Inf
	End Structure
	
	'���������������� ���ʕ��i Start ��������������������������������
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_Num_Int_Part
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �������̌���
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//* <��  ��>
	'//*    �w�肳�ꂽ������̐��������擾���܂�
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_Num_Int_Part(ByVal pm_Value As String) As String
		
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim Wk_Str As String
		
		Rtn_Value = ""
		
		For Wk_Cnt = 1 To Len(pm_Value)
			
			Wk_Str = Mid(pm_Value, Wk_Cnt, 1)
			
			If Wk_Str = "." Then
				Exit For
			End If
			
			If Wk_Str >= "0" And Wk_Str <= "9" Then
				Rtn_Value = Rtn_Value & Wk_Str
			End If
		Next 
		
		CF_Get_Num_Int_Part = Rtn_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_Num_Fra_Part
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �������̌���
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//* <��  ��>
	'//*    �w�肳�ꂽ������̏��������擾���܂�
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_Num_Fra_Part(ByVal pm_Value As String) As String
		
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim Wk_Str As String
		
		Rtn_Value = ""
		
		If InStr(pm_Value, ".") > 0 Then
			For Wk_Cnt = InStr(pm_Value, ".") To Len(pm_Value)
				
				Wk_Str = Mid(pm_Value, Wk_Cnt, 1)
				
				If Wk_Str >= "0" And Wk_Str <= "9" Then
					Rtn_Value = Rtn_Value & Wk_Str
				End If
			Next 
			
		End If
		
		CF_Get_Num_Fra_Part = Rtn_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiLeftB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��č�����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiRightB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��ĉE����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiMidB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              String      �ϊ���̕�����
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//*              pm_Start           Long             I            �؂���J�n�o�C�g��
	'//*              pm_Len             Long             I            ������̒���
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��Ďw�肵���ʒu����w��̒����̕�������擾���܂��B
	'//*    �w�肵���������A�S�p�������r���Ő؂��o�C�g���̏ꍇ�A�������擾�ł��܂���B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
		Else
			'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
			
			'//�S�p�������r���œr�؂��ꍇ�P�������߂ɃJ�b�g����B
			'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
			'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
			If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
				Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
			End If
		End If
		
		CF_Ctr_AnsiMidB = Str_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Ctr_AnsiLenB
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Long        �����o�C�g��
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_Value           String           I            �Ώە�����
	'//* <��  ��>
	'//*    ���p������1�o�C�g�A�S�p������2�o�C�g�Ƃ��đΏە�����̒����o�C�g�����擾���܂��B
	'//*
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub CF_SpaceLenFormat
	'   �T�v�F  ��������w�蒷�܂Ŕ��p�X�y�[�X�Ŗ��߂�
	'             ��j  "123", 5    => "123  "
	'                   "123456", 5 => "123456"
	'   �����F�@pin_strIn       : �Ώە�����
	'           pin_intLength   : �����񒷁i�o�C�g�j
	'           pin_bolCut      : �Ώە����񒷁������񒷂̏ꍇ�A������̃J�b�g�ƍs�����ǂ���
	'   �ߒl�F�@���o���e��ҏW�����\����
	'   ���l�F  �Ώە����񒷂��w�蒷�ȏ��pin_bolCut=True�̏ꍇ�͎w�蒷�܂ł̕������Ԃ��܂��B
	'           �i�Q�o�C�g�����l������j
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_SpaceLenFormat(ByRef pin_strIn As String, ByRef pin_intLength As Short, Optional ByRef pin_bolCut As Boolean = False) As String
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strRet As String
		Dim strEdt As String
		Dim intIdx As Short
		'execute -------+---------------+---------------+---------------+---------------
		
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pin_strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(pin_strIn) > pin_intLength Then
			If pin_bolCut Then
				strRet = ""
				intIdx = 1
				strEdt = Mid(pin_strIn, intIdx, 1)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strRet + strEdt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Do While LenWid(strRet & strEdt) <= pin_intLength
					strRet = strRet & strEdt
					intIdx = intIdx + 1
					strEdt = Mid(pin_strIn, intIdx, 1)
				Loop 
			Else
				strRet = pin_strIn
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pin_strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(pin_strIn) = pin_intLength Then 
			strRet = pin_strIn
		Else
			strRet = LeftWid(pin_strIn & Space(pin_intLength), pin_intLength)
		End If
		
		CF_SpaceLenFormat = strRet
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub CF_ZeroLenFormat
	'   �T�v�F  ��������w�蒷�܂Ń[���Ŗ��߂�i���p�����̂ݑΏہj
	'             ��j  "123", 5    => "00123"
	'                   "123456", 5 => "123456"
	'   �����F�@pin_strIn       : �Ώە�����
	'           pin_intLength   : �����񒷁i�o�C�g�j
	'           pin_bolCut      : �Ώە����񒷁������񒷂̏ꍇ�A������̃J�b�g�ƍs�����ǂ���
	'   �ߒl�F�@���o���e��ҏW�����\����
	'   ���l�F  �Ώە����񒷂��w�蒷�ȏ��pin_bolCut=True�̏ꍇ�͎w�蒷�܂ł̕������Ԃ��܂��B
	'           �Ώە����񂪔��p�����ȊO�̏ꍇ�A���̂܂܂̕������Ԃ��܂��B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_ZeroLenFormat(ByRef pin_strIn As String, ByRef pin_intLength As Short, Optional ByRef pin_bolCut As Boolean = False) As String
		
		'local variable +---------------+---------------+---------------+---------------
		Dim strIn As String
		Dim strRet As String
		Dim intIdx As Short
		Dim strEdt As String
		'execute -------+---------------+---------------+---------------+---------------
		
		strIn = pin_strIn
		
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(strIn) Then
			strIn = ""
		End If
		'���p�����`�F�b�N
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(pin_strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Not (IsNumeric(strIn) And Len(pin_strIn) = LenWid(pin_strIn)) Then
			CF_ZeroLenFormat = strIn
			Exit Function
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(strIn) > pin_intLength Then
			If pin_bolCut Then
				strRet = ""
				intIdx = Len(strIn)
				strEdt = Mid(strIn, intIdx, 1)
				'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strRet + strEdt) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Do While LenWid(strRet & strEdt) <= pin_intLength
					strRet = strEdt & strRet
					intIdx = intIdx - 1
					strEdt = Mid(strIn, intIdx, 1)
				Loop 
			Else
				strRet = strIn
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(strIn) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf LenWid(strIn) = pin_intLength Then 
			strRet = strIn
		Else
			strRet = RightWid(New String("0", pin_intLength) & strIn, pin_intLength)
		End If
		
		CF_ZeroLenFormat = strRet
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Chk_Date
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True:�`�F�b�N�n�j / False:�`�F�b�N�m�f�������ُ͈�
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*              pm_str_Date        String          I             �`�F�b�N�ΏۂƂȂ���t��
	'//*                                                               (YYYY,YYYYMM,YYYYMMDD�̂��Âꂩ�̌`���Ŏw��)
	'//*
	'//* <��  ��>
	'//*    �����œn���ꂽ���t���`�F�b�N���A�G���[���̓��b�Z�[�W��\������
	'//*    �`�F�b�N�Ώۂ̓��t���́AYYYY,YYYY/MM,YYYY/MM/DD�̂��Âꂩ�̌`���Ŏw�肷��K�v������
	'//*�@�@�@�@�N�̂ݎw�莞�F1000�N�ȍ~�����`�F�b�N(1000�N�ȍ~�Ȃ�`�F�b�N�n�j)
	'//*�@�@�@�@���܂Ŏw�莞�F1000�N�`�F�b�N + ���`�F�b�N(1�`12)
	'//*�@�@�@�@���܂Ŏw�莞�F1000�N�`�F�b�N + ���t���`�F�b�N(Isdate�֐�)
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Chk_Date(ByVal pm_str_Date As String) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		CF_Chk_Date = False
		
		'//�N�`�F�b�N(1000�ȍ~���Ȃ�n�j�A����ȑO�͂m�f)
		If CShort(Left(pm_str_Date, 4)) < 1000 Then
			GoTo EXIT_HANDLE
		End If
		
		'//���`�F�b�N(�P���`�P�Q����)
		If Len(pm_str_Date) > 4 Then
			If CShort(Mid(pm_str_Date, 6, 2)) < 1 Or CShort(Mid(pm_str_Date, 6, 2)) > 12 Then
				GoTo EXIT_HANDLE
			End If
		End If
		
		'//���t���`�F�b�N(Isdate�֐�)
		If Len(pm_str_Date) > 7 Then
			If IsDate(pm_str_Date) = False Then
				GoTo EXIT_HANDLE
			End If
		End If
		
		CF_Chk_Date = True
		
EXIT_HANDLE: 
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	
	'���������������� ���ʕ��i End ��������������������������������
	
	'���������������� �S��ʋ��ʏ��� Start ��������������������������������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_System_Process
	'   �T�v�F  �V�X�e�����ʏ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		
		'�p�b�P�[�W���̂c�k�k�ɂ�
		'��s�`�a�����s�`�a�{�r�g�h�e�s������ꂼ�ꢂe�P�U�����e�P�T��Ɋ���
		'   ReleaseTabCapture 0
		'   SetTabCapture pm_Form.hwnd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Clr_Prompt
	'   �T�v�F  ���b�Z�[�W�����N���A
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Clr_Prompt(ByRef pm_All As Cls_All) As String
		Dim Wk_Index As Short
		'�d��
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.Off_IM_Denkyu.Picture �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Control ���\�b�h Dsp_IM_Denkyu.Picture �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		pm_All.Dsp_IM_Denkyu.Image = pm_All.Off_IM_Denkyu.Picture
		'���b�Z�[�W
		Wk_Index = CShort(pm_All.Dsp_TX_Message.Tag)
		Call CF_Set_Item_Direct("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		pm_All.Dsp_TX_Message.ForeColor = COLOR_BLACK
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Prompt
	'   �T�v�F  ���b�Z�[�W����ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Prompt(ByRef pm_Msg_Inf As String, ByRef pm_ForeColor As Integer, ByRef pm_All As Cls_All) As String
		Dim Wk_Index As Short
		'�d��
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_All.On_IM_Denkyu.Picture �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Control ���\�b�h Dsp_IM_Denkyu.Picture �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' ���N���b�N���Ă��������B
		pm_All.Dsp_IM_Denkyu.Image = pm_All.On_IM_Denkyu.Picture
		'���b�Z�[�W
		Wk_Index = CShort(pm_All.Dsp_TX_Message.Tag)
		Call CF_Set_Item_Direct(pm_Msg_Inf, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
		pm_All.Dsp_TX_Message.ForeColor = System.Drawing.ColorTranslator.FromOle(pm_ForeColor)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_IM_EndCm_Img
	'   �T�v�F  �e���b�Z�[�W��ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Img(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_SetImp As Cls_Img_Inf, ByRef pm_OnOff As Boolean, ByRef pm_All As Cls_All) As String
		
		If pm_OnOff = False Then
			'Off
			Call CF_Set_Item_Direct(pm_SetImp.Click_Off_Img, pm_Dsp_Sub_Inf, pm_All)
		Else
			'On
			Call CF_Set_Item_Direct(pm_SetImp.Click_On_Img, pm_Dsp_Sub_Inf, pm_All)
		End If
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_Item_Property
	'   �T�v�F  ���ڂ�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Item_Property(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		For Index_Wk = 1 To pm_All.Dsp_Base.Item_Cnt
			'==================
			'MaxLength�ݒ�
			'==================
			'÷���ޯ��
			'        If TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is TextBox Then
			'            'MaxLengthB�ݒ�
			'            pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.MaxLength = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB
			'
			'        End If
			
			'=====================
			'TabIndex/TabStop�ݒ�
			'=====================
			'        If TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is TextBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is CheckBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is OptionButton _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is SSCommand5 _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is SSPanel5 _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is PictureBox _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is VScrollBar _
			''        Or TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is OLE Then
			'            'TabIndex=Tag��ݒ�
			'            pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.TabIndex = CInt(pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Tag)
			'
			'            'TabStop��ݒ�
			'            Call CF_Set_Item_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl, pm_All.Dsp_Sub_Inf(Index_Wk))
			'
			'        End If
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_Def_Dsp
	'   �T�v�F  ��ʊ�b���̋��ʐݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Def_Dsp(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
		'��ʊ�b���ݒ�
		'    With pm_All.Dsp_Base
		'        .Cursor_Idx = 0         '���݂�̫����̲��ޯ��
		'        .Bef_Cursor_Idx = 0     '�P�O��̫����̲��ޯ��
		'        .Change_Flg = False     '��ݼ޲���Đ����׸�
		'        .VS_Scr_Flg = False     '��۰���ݼ޲���Đ����׸�
		'        .LostFocus_Flg = False  '۽�̫�������Đ����׸�
		'        .Head_Ok_Flg = False    '�w�b�_���`�F�b�N�n�j�t���O
		'        .PopupMenu_Idx = 0      '�߯�߱����ƭ���̫����̲��ޯ��
		'    End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Copy_Def_Dsp_Body
	'   �T�v�F  ���ׂ̋��ʐݒ�𕔕����P�s�O����R�s�[����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Copy_Def_Dsp_Body(ByRef pm_Index_Wk As Short, ByRef pm_Body_Col_Cnt As Short, ByRef pm_All As Cls_All) As Short
		
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Area = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Area
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Typ = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Typ
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.In_Str_Typ = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.In_Str_Typ
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.MaxLengthB = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.MaxLengthB
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Dsp_MaxLengthB = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Dsp_MaxLengthB
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Int_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Int_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Fra_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Fra_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Num_Sign_Fig = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Num_Sign_Fig
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Fil_Chr = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Fil_Chr
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Fil_Point = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Fil_Point
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Dsp_Fmt = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Dsp_Fmt
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Focus_Ctl = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Focus_Ctl
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Err_Status = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Err_Status
		pm_All.Dsp_Sub_Inf(pm_Index_Wk).Detail.Locked = pm_All.Dsp_Sub_Inf(pm_Index_Wk - pm_Body_Col_Cnt).Detail.Locked
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_ReSet_Dsp_Sub_Inf
	'   �T�v�F  ��ʍ��ڏ����Đݒ肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_ReSet_Dsp_Sub_Inf(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		For Index_Wk = 1 To pm_All.Dsp_Base.Item_Cnt
			'==================
			'��ʍ��ږ�(���۰ٖ�)
			'==================
			'        pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm = pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
			'==================
			'�ޔ��t�H�[�J�X����
			'==================
			'�����������ɒ�`���ꂽFocus_Ctl�̐ݒ�ێ�����
			'        pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl_Bk = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_Set_Body_Inf
	'   �T�v�F  ������ʃ{�f�B���ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Set_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		''''    '�ŏ㖾�ײ��ޯ��
		''''    pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		''''    '�s������
		''''    ReDim pm_All.Dsp_Body_Inf.Row_Inf(0)
		''''    '�񏉊���
		''''    ReDim pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(0)
		''''
		''''    '�������p�̗񏉊���
		''''    ReDim pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(0)
		''''
		''''    '�������̖�
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
		''''    '�����s������
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
		''''    '�����s��񏉊���
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf = pm_All.Dsp_Body_Inf.Row_Inf(0)
		''''    '�����s��񏉊���
		''''    ReDim pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(0)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_Not_Change
	'   �T�v�F  ��ݼ޲���Ă��N�������ɕҏW����
	'   �@�@�@�@KEYPRESS�Ȃǂ̓��͒�(���m��)�̂Ƃ��Ɏg�p
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Not_Change(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'���݂̕\�����e��ޔ�
		'    pm_Dsp_Sub_Inf.Detail.Dsp_Value = pm_Value
		'
		'    Select Case True
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        '÷���ޯ��
		'            '��ݼ޲���ĕs��
		'            pm_All.Dsp_Base.Change_Flg = True
		'            pm_Dsp_Sub_Inf.Ctl.Text = pm_Value
		'            '��ݼ޲���ĉ�
		'            pm_All.Dsp_Base.Change_Flg = False
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'        '�����ޯ��
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'        '��߼������
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'        '������۰��ް
		'            '��ݼ޲���ĕs��
		'            pm_All.Dsp_Base.VS_Scr_Flg = True
		'            pm_Dsp_Sub_Inf.Ctl.Value = pm_Value
		'            pm_All.Dsp_Base.VS_Scr_Flg = False
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'        '����
		'            pm_Dsp_Sub_Inf.Ctl.Caption = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'        '�Ұ��
		'            On Error Resume Next
		'            pm_Dsp_Sub_Inf.Ctl.Picture = pm_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'        '�߸����ޯ��
		'            On Error Resume Next
		'            pm_Dsp_Sub_Inf.Ctl.Picture = pm_Value
		'
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		''@'        '����
		''@'            pm_Dsp_Sub_Inf.Ctl.Caption = pm_Value
		'
		'    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_VScrl_Max
	'   �T�v�F  ��۰���ݼ޲���Ă��N�������ɏc��۰ٍő�l��ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_Max(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'������۰��ް(�ő�l)
					'��ݼ޲���ĕs��
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.Max �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.Max = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_VScrl_Min
	'   �T�v�F  ��۰���ݼ޲���Ă��N�������ɏc��۰ٍŏ��l��ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_Min(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'������۰��ް(�ŏ��l)
					'��ݼ޲���ĕs��
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.Min �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.Min = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_VScrl_LargeChange
	'   �T�v�F  ��۰���ݼ޲���Ă��N�������ɍő彸۰ٗʂ�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_LargeChange(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'������۰��ް(�ő彸۰ٗ�)
					'��ݼ޲���ĕs��
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.LargeChange �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.LargeChange = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_VScrl_LargeChange
	'   �T�v�F  ��۰���ݼ޲���Ă��N�������ɍŏ���۰ٗʂ�ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_VScrl_SmallChange(ByRef pm_Value As Short, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		If pm_All.Bd_Vs_Scrl Is Nothing = False Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.VScrollBar
					'������۰��ް(�ŏ���۰ٗ�)
					'��ݼ޲���ĕs��
					pm_All.Dsp_Base.VS_Scr_Flg = True
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SmallChange �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Ctl.SmallChange = pm_Value
					pm_All.Dsp_Base.VS_Scr_Flg = False
					
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_Direct
	'   �T�v�F  ��ʃR���g���[���ҏW����ѕ������e/�O����e�̑ޔ����s��
	'   �@�@�@�@��ʂɒ��ڕҏW����ۂɎg�p(�m�莞)
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Direct(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		'��ݼ޲���Ă��N�������ɕҏW
		Call CF_Set_Item_Not_Change(pm_Value, pm_Dsp_Sub_Inf, pm_All)
		
		'�������e�A�O����e��ޔ�
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf, pm_Set_Flg)
		
		'���ڐF�̏����ݒ�
		Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_INITIAL_STATUS, pm_All, ITEM_COLOR_DEF)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Item_Value
	'   �T�v�F  �e�R���g���[���̒l���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Item_Value(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Object
		
		'    CF_Get_Item_Value = Null
		'
		'    Select Case True
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        '÷���ޯ��
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Text
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'        '�����ޯ��
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'        '��߼������
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'        '������۰��ް
		'            '��ݼ޲���ĕs��
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'        '����
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Caption
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'        '�Ұ��
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Picture
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'        '�߸���ޯ��
		'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Picture
		'
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		''@'        '����
		''@'            CF_Get_Item_Value = pm_Dsp_Sub_Inf.Ctl.Caption
		'
		'    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_Focus_Ctl
	'   �T�v�F  ̫��������ҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		pm_Dsp_Sub_Inf.Detail.Focus_Ctl = pm_Value
		
		'TabStop�ݒ�
		'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox _
		''    Or TypeOf pm_Dsp_Sub_Inf.Ctl Is OLE Then
		'
		'        'TabStop������
		'        pm_Dsp_Sub_Inf.Ctl.TabStop = False
		'
		'        If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		'            'TabStop�\
		'            pm_Dsp_Sub_Inf.Ctl.TabStop = True
		'        End If
		'    End If
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Input_Ok_Item
	'   �T�v�F  ���͉\�ȕ����������o��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Input_Ok_Item(ByRef pm_Value As String, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As String
		Dim Trg_Value As String
		Dim Rtn_Value As String
		Dim Wk_Cnt As Short
		Dim wk_Moji As String
		Dim Wk_Value As String
		
		Rtn_Value = ""
		Trg_Value = pm_Value
		
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Or TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				Case IN_TYP_NUM
					'���l�̏ꍇ
					'�E���̋󔒂�����
					Trg_Value = RTrim(Trg_Value)
			End Select
			
			'���͉\�����������o��
			For Wk_Cnt = 1 To Len(Trg_Value)
				
				wk_Moji = Mid(Trg_Value, Wk_Cnt, 1)
				
				If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
					
					Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
						Case IN_TYP_NUM
							'���l�̏ꍇ
							'���l�Ƃ��Č`��������
							If Trim(wk_Moji) <> "" Then
								Select Case wk_Moji
									'��{����͎�
									Case "+"
										If Rtn_Value = "" Then
											'�ŏ��ɓ��͂���Ă���ꍇ�A�[���ҏW
											Rtn_Value = Rtn_Value & "0"
										End If
										'��|����͎�
									Case "-"
										If Rtn_Value = "" Then
											'�ŏ��ɓ��͂���Ă���ꍇ�AOK
											Rtn_Value = Rtn_Value & wk_Moji
										End If
									Case "."
										'��D����͎�
										If InStr(Rtn_Value, ".") = 0 Then
											'��D����P���
											If Len(CF_Get_Num_Int_Part(Rtn_Value)) > 0 Then
												'������������ꍇ
												Rtn_Value = Rtn_Value & wk_Moji
											Else
												Rtn_Value = Rtn_Value & "0" & wk_Moji
											End If
										End If
										
									Case "0"
										'��O����͎�
										If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig = 0 Then
											'���������̏ꍇ
											If Len(Trg_Value) = Wk_Cnt Then
												'�Ō�̌��̏ꍇ
												Rtn_Value = Rtn_Value & wk_Moji
											Else
												If Rtn_Value <> "" And Rtn_Value <> "0" And Rtn_Value <> "-0" And Rtn_Value <> "+0" Then
													'�P�Ԃ͂��߂̕����ȊO�ł��¢�O����Ȃ��ꍇ
													Rtn_Value = Rtn_Value & wk_Moji
												End If
											End If
										Else
											'�������L�̏ꍇ
											If Rtn_Value <> "0" And Rtn_Value <> "-0" And Rtn_Value <> "+0" Then
												'��O����Ȃ��ꍇ
												Rtn_Value = Rtn_Value & wk_Moji
											End If
											
										End If
									Case Else
										'���̑��́ACF_Jge_Input_Str�Ő�������Ă���I�I
										If Rtn_Value = "-0" Then
											Rtn_Value = "-" & wk_Moji
										Else
											Rtn_Value = Rtn_Value & wk_Moji
										End If
										
								End Select
							End If
						Case Else
							'���l�̈ȊO�ꍇ
							Rtn_Value = Rtn_Value & wk_Moji
							
					End Select
				End If
			Next 
			
		End If
		
		CF_Get_Input_Ok_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Trim_Item
	'   �T�v�F  �s�K�v�ȋ󔒂��폜
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Trim_Item(ByRef pm_Value As String, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As String
		Dim Rtn_Value As String
		
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Or TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'�\���`���Ȃ�
			Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
				Case FIL_POINT_RIGHT
					'�l�������E�l�̏ꍇ�A�E�󔒂��폜
					Rtn_Value = RTrim(pm_Value)
				Case FIL_POINT_LEFT
					'�l���������l�̏ꍇ�A���󔒂��폜
					Rtn_Value = LTrim(pm_Value)
				Case FIL_POINT_CENTER
					'�l���������l�̏ꍇ�A���󔒂��폜
					Rtn_Value = Trim(pm_Value)
			End Select
		Else
			Rtn_Value = pm_Value
		End If
		
		CF_Trim_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cnv_Dsp_Item
	'   �T�v�F  �Ώۍ��ڂ̉�ʕ\���p�ɕϊ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cnv_Dsp_Item(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_InPut_Flg As Boolean) As Object
		Dim Rtn_Value As Object
		Dim Rtn_Str_Value As String
		Dim Wk_Cnt As Short
		Dim Fil_Chr As String
		Dim Fil_Space As String
		Dim Wk_Str As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Rtn_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Rtn_Value = pm_Value
		
		'    Select Case True
		''@'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is Label
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox
		'        '÷���ޯ��
		'            If pm_Dsp_Sub_Inf.Detail.In_Str_Typ = IN_STR_TYP_N Then
		'                '�S�p�̏ꍇ
		'                Fil_Space = "�@"
		'            Else
		'                '���p�̏ꍇ
		'                Fil_Space = Space(1)
		'            End If
		'
		'            If pm_InPut_Flg = True Then
		'            '���͒��̏ꍇ
		'                '�����I�ɋ󔒂��l�߂�ꍇ
		'                Fil_Chr = Fil_Space
		'            Else
		'            '���͊O�̏ꍇ
		'                '��ʍ��ڏ���Dsp_Sub_Inf.Detail.Fil_Chr���g�p����ꍇ
		'                Fil_Chr = pm_Dsp_Sub_Inf.Detail.Fil_Chr
		'            End If
		'
		'            '���͉\�����������o��
		'            Rtn_Str_Value = CF_Get_Input_Ok_Item(CStr(Rtn_Value), pm_Dsp_Sub_Inf)
		'
		'            Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
		'                Case IN_TYP_NUM
		'                    '���l�̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        '�l��������̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                        '�\���`���L
		'                            Wk_Str = Rtn_Str_Value
		'                            If pm_InPut_Flg = True Then
		'                            '���͒��̏ꍇ
		'                                '�܂��������̂ݕҏW�i�P���A���͋��z�Ɠ����j
		'                                If InStr(Rtn_Str_Value, "-") = 0 Then
		'                                    Wk_Str = Format(CF_Get_Num_Int_Part(Rtn_Str_Value), DSP_FMT_KIN_1)
		'                                Else
		'                                    Wk_Str = "-" & Format(Replace(CF_Get_Num_Int_Part(Rtn_Str_Value), "-", ""), DSP_FMT_KIN_1)
		'                                End If
		'                                If InStr(Rtn_Str_Value, ".") > 0 Then
		'                                '������������ꍇ
		'                                    Wk_Str = Wk_Str & "." & CF_Get_Num_Fra_Part(Rtn_Str_Value)
		'                                End If
		'                            Else
		'                                '���͊O�̏ꍇ
		'                                Wk_Str = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'
		'                            Rtn_Str_Value = Wk_Str
		'
		'                        End If
		'
		'                        '�l��������̏ꍇ
		'                        If Fil_Chr <> "" Then
		'                            Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                Case FIL_POINT_RIGHT
		'                                    '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                    Rtn_Str_Value = Rtn_Str_Value _
		''                                              & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                    '������o�C�g���������擾
		'                                    Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                Case FIL_POINT_LEFT
		'                                    '�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                    Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                              & Rtn_Str_Value
		'                                    '�E����o�C�g���������擾
		'                                    Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                            End Select
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_DATE
		'                    '���t�̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_DATE) Then
		'                        '���͌`�����قȂ�ꍇ
		'                            '�l��������̏ꍇ
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '������o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '�E����o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '�\���`���L
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'                Case IN_TYP_CODE, IN_TYP_STR
		'                    '�R�[�h�A�����̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        '�l��������̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                            '�\���`���L
		'                            Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                        Else
		'                            '�\���`���Ȃ�
		'                            Rtn_Str_Value = CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf)
		'                        End If
		'
		'                        '�l��������̏ꍇ
		'                        If Fil_Chr <> "" Then
		'                            Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                Case FIL_POINT_RIGHT
		'                                    '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                    Rtn_Str_Value = Rtn_Str_Value _
		''                                              & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                    '������o�C�g���������擾
		'                                    Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                Case FIL_POINT_LEFT
		'                                    '�l���������l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                    Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                              & Rtn_Str_Value
		'                                    '�E����o�C�g���������擾
		'                                    Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                            End Select
		'                        End If
		'
		'                    End If
		'                Case IN_TYP_YYYYMM
		'                    '�N���̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_YYYMM) Then
		'                        '���͌`�����قȂ�ꍇ
		'                            '�l��������̏ꍇ
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '������o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '�E����o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '�\���`���L
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_HHMM
		'                    '�N���̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_HHMM) Then
		'                        '���͌`�����قȂ�ꍇ
		'                            '�l��������̏ꍇ
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '������o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '�E����o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '�\���`���L
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_HHMMSS
		'                    '�����b�̏ꍇ
		'                    If CF_Trim_Item(Rtn_Str_Value, pm_Dsp_Sub_Inf) = "" Then
		'                    '�����͂̏ꍇ
		'                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Space)
		'                    Else
		'                    '���͂���̏ꍇ
		'                        If Len(Rtn_Str_Value) <> Len(IN_FMT_HHMMSS) Then
		'                        '���͌`�����قȂ�ꍇ
		'                            '�l��������̏ꍇ
		'                            If Fil_Chr <> "" Then
		'                                Select Case pm_Dsp_Sub_Inf.Detail.Fil_Point
		'                                    Case FIL_POINT_RIGHT
		'                                        '�l�������E�l�̏ꍇ�A�l�������o�C�g��(�����Ƃ��Ďg�p)���E���ɒǉ�
		'                                        Rtn_Str_Value = Rtn_Str_Value _
		''                                                  & String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr)
		'                                        '������o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiLeftB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                    Case FIL_POINT_LEFT
		'                                        '�l���������l�̏ꍇ�A�A�l�������o�C�g��(�����Ƃ��Ďg�p)�������ɒǉ�
		'                                        Rtn_Str_Value = String(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB, Fil_Chr) _
		''                                                  & Rtn_Str_Value
		'                                        '�E����o�C�g���������擾
		'                                        Rtn_Str_Value = CF_Ctr_AnsiRightB(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
		'                                End Select
		'                            End If
		'                        Else
		'                            If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
		'                                '�\���`���L
		'                                Rtn_Str_Value = Format(Rtn_Str_Value, pm_Dsp_Sub_Inf.Detail.Dsp_Fmt)
		'                            End If
		'                        End If
		'                    End If
		'
		'                Case IN_TYP_ELSE
		'                    '���̑�
		'            End Select
		'
		'            Rtn_Value = Rtn_Str_Value
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is CheckBox
		'            '�����ޯ��
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is OptionButton
		'            '��߼������
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is VScrollBar
		'            '������۰��ް
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is SSPanel5
		'            '����
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is Image
		'            '�Ұ��
		'
		'        Case TypeOf pm_Dsp_Sub_Inf.Ctl Is PictureBox
		'            '�߸���ޯ��
		'
		'    End Select
		'
		'    CF_Cnv_Dsp_Item = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_Color
	'   �T�v�F  �Ώۍ��ڂ̏��(̫����L���A�װ�L��)�ɂ��̑O�i/�w�i�F�ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Color(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Item_Status As String, ByRef pm_All As Cls_All, Optional ByRef pm_Color_Mode As Short = ITEM_COLOR_NOMAL) As Short
		Dim Set_Focus As Boolean
		
		'�t�H�[�J�X����
		If pm_Color_Mode = ITEM_COLOR_DEF Then
			'���������́A�����I�Ƀt�H�[�J�X�Ȃ��Ɣ��f
			Set_Focus = False
		Else
			'�������ȊO�̏ꍇ�́A���ۂ̃t�H�[�J�X�ړ��𔻒�
			Set_Focus = CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		'�F�ݒ��÷���ޯ���̂�
		'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is TextBox Then
		'        If Set_Focus = True Then
		'        '̫������n�j
		'            Select Case pm_Item_Status
		'                Case ITEM_NORMAL_STATUS
		'                '�t�H�[�J�X�Ȃ�
		'
		'                    Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
		'                        '�������A�G���[�Ȃ�
		'                        Case ERR_DEF, ERR_NOT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '�ǎ��p
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                            End If
		'
		'                        '�K�{���̖͂����̓G���[
		'                        Case ERR_NOT_INPUT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_RED
		'
		'                        '���̑��G���[
		'                        Case ERR_ELSE
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '�ǎ��p
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                            End If
		'
		'                    End Select
		'
		'                '�t�H�[�J�X����
		'                Case ITEM_SELECT_STATUS
		'
		'                    Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
		'                        '�������A�G���[�Ȃ�
		'                        Case ERR_DEF, ERR_NOT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '�ǎ��p
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                        '�K�{���̖͂����̓G���[
		'                        Case ERR_NOT_INPUT
		'                            pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '�ǎ��p
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                        '���̑��G���[
		'                        Case ERR_ELSE
		'                            Select Case pm_Color_Mode
		'                                Case ITEM_COLOR_NOMAL
		'                                    '�ʏ�
		'                                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
		'                                Case ITEM_COLOR_KEYPRESS
		'                                    'KEYPRESS
		'                                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'
		'                            End Select
		'
		'                            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                            '�ǎ��p
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                            Else
		'                                pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
		'                            End If
		'
		'                    End Select
		'
		'                Case ITEM_INITIAL_STATUS
		'                '�������
		'                    '�G���[�X�e�C�^�X�Ɋ֌W�Ȃ��ʏ�̕����F��ݒ�(�����ݒ���)
		'                    '���݂�CF_Set_Item_Direct��p
		'                    pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'                    If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'                    '�ǎ��p
		'                        pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'                    Else
		'                        pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'                    End If
		'
		'            End Select
		'        Else
		'        '̫������m�f
		'            If pm_Dsp_Sub_Inf.Detail.Locked = True Then
		'            '�ǎ��p
		'              pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'              pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
		'            Else
		'              pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
		'              pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
		'            End If
		'        End If
		'    End If
		
	End Function
	
	' === 20060804 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_Color_MEISAI
	'   �T�v�F  ���ׂ̑O�i/�w�i�F�ݒ�i�O�i/�w�i�F�߂������j
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F  ���ڂ̐F�ݒ肪�K��ƈقȂ��ʂɂ̂ݎg�p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_Color_MEISAI(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Item_Status As String, ByRef pm_All As Cls_All, Optional ByRef pm_Color_Mode As Short = ITEM_COLOR_NOMAL) As Short
		
		'�F�ݒ��÷���ޯ���̂�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
				Select Case pm_Item_Status
					'�t�H�[�J�X�Ȃ�
					Case ITEM_NORMAL_STATUS
						
						Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
							'�������A�G���[�Ȃ�
							Case ERR_DEF, ERR_NOT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'�ǎ��p
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
								End If
								
								'�K�{���̖͂����̓G���[
							Case ERR_NOT_INPUT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_RED
								
								'���̑��G���[
							Case ERR_ELSE
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'�ǎ��p
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
								End If
								
						End Select
						
						'�t�H�[�J�X����
					Case ITEM_SELECT_STATUS
						
						Select Case pm_Dsp_Sub_Inf.Detail.Err_Status
							'�������A�G���[�Ȃ�
							Case ERR_DEF, ERR_NOT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'�ǎ��p
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
								'�K�{���̖͂����̓G���[
							Case ERR_NOT_INPUT
								pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'�ǎ��p
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
								'���̑��G���[
							Case ERR_ELSE
								Select Case pm_Color_Mode
									Case ITEM_COLOR_NOMAL
										'�ʏ�
										pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_RED
									Case ITEM_COLOR_KEYPRESS
										'KEYPRESS
										pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
										
								End Select
								
								If pm_Dsp_Sub_Inf.Detail.Locked = True Then
									'�ǎ��p
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_GRAY
								Else
									pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_YELLOW
								End If
								
						End Select
						
				End Select
			Else
				'̫����Ȃ�
				If pm_Dsp_Sub_Inf.Detail.Locked = False Then
					'���͉\�ȍ��ڂ̂ݏ�����
					pm_Dsp_Sub_Inf.Ctl.ForeColor = COLOR_BLACK
					pm_Dsp_Sub_Inf.Ctl.BackColor = COLOR_WHITE
				End If
			End If
		End If
		
	End Function
	' === 20060804 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Sel_Ini
	'   �T�v�F  TextBox��S�đI����Ԃɂ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Sel_Ini(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Date_Sel_Kbn As String) As Short
		
		'TextBox�ꍇ�̂�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				'���t�̏ꍇ
				Case IN_TYP_DATE
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_DATE_SLASH
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Chk_Date(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'���t�Ƃ��Ĕ���\�ȏꍇ
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'�N�̂P�O�O�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'���̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'��`�O�͂Ȃ��I�I
								End Select
							Else
								'�����͂̏ꍇ
								'��ԍ���I��
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'��`�O�͂Ȃ��I�I
					End Select
					
					'�N���̏ꍇ
				Case IN_TYP_YYYYMM
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_YYYYMM_SLASH
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Chk_Date(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) & "/01") = True Then
								'�N���Ƃ��Ĕ���\�ȏꍇ
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'�N�̂P�O�O�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'���̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'��`�O�͂Ȃ��I�I
								End Select
							Else
								'�����͂̏ꍇ
								'��ԍ���I��
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'��`�O�͂Ȃ��I�I
					End Select
					
					'�����̏ꍇ
				Case IN_TYP_HHMM
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_HHMM
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If IsDate(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'�����Ƃ��Ĕ���\�ȏꍇ
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'���̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'���̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'��`�O�͂Ȃ��I�I
								End Select
							Else
								'�����͂̏ꍇ
								'��ԍ���I��
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'��`�O�͂Ȃ��I�I
					End Select
					
					'�����b�̏ꍇ
				Case IN_TYP_HHMMSS
					Select Case pm_Dsp_Sub_Inf.Detail.Dsp_Fmt
						Case DSP_FMT_HHMMSS
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If IsDate(CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)) = True Then
								'�����Ƃ��Ĕ���\�ȏꍇ
								Select Case pm_Date_Sel_Kbn
									Case SEL_INI_MODE_1
										'���̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = 0
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case SEL_INI_MODE_2
										'�b�̂P�O�̈ʂ�I��
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 2
										'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
										pm_Dsp_Sub_Inf.Ctl.SelLength = 1
									Case Else
										'��`�O�͂Ȃ��I�I
								End Select
							Else
								'�����͂̏ꍇ
								'��ԍ���I��
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelStart = 0
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
							End If
						Case Else
							'��`�O�͂Ȃ��I�I
					End Select
					
				Case Else
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'�S�I��
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = 0
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
					Else
						'�l���������l�ȊO�̏ꍇ
						'�P��
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = 0
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = 1
					End If
			End Select
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Item_SetFocus
	'   �T�v�F  ���ڃt�H�[�J�X�ړ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Item_SetFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		' === 20060804 === UPDATE S - ACE)Sejima
		'D    '�������ޯ���擾
		'D    Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag)
		'D
		'D'@'    '�O̫����̲��ޯ����ޔ�
		'D'@'    pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
		'D
		'D'@'    '�ړ���̲��ޯ����ޔ�
		'D'@'    pm_All.Dsp_Base.Cursor_Idx = Trg_Index
		'D
		'D    '�t�H�[�J�X�ړ�
		'D    pm_Dsp_Sub_Inf.Ctl.SetFocus
		'D'@'    '�I����Ԃ̐ݒ�i�����I���j
		'D'@'    Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
		'D
		'D'@'    '���ڐF�ݒ�
		'D'@'    Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS)
		'D
		'D'@'    '���݂̫����̲��ޯ����ݒ�
		'D'@'    pm_All.Dsp_Base.Cursor_Idx = Trg_Index
		' === 20060804 === UPDATE ��
		
		Trg_Index = -1
		
		'���ޯ�������蓖�Ă��Ă��邩�H
		' �i���蓖�Ă��Ă���΁A���̲��ޯ�����擾�j
		If IsNumeric(pm_Dsp_Sub_Inf.Ctl.Tag) = True Then
			Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		End If
		
		If Trg_Index >= 0 Then
			'���蓖�Ă��Ă���ꍇ
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.Button, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton, TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
					
					'�g�p�Ƃ��āA
					pm_Dsp_Sub_Inf.Ctl.Enabled = True
					'�t�H�[�J�X���Z�b�g
					pm_Dsp_Sub_Inf.Ctl.Focus()
					
				Case Else
					
			End Select
			
		Else
			'���蓖�Ă��Ă��Ȃ��ꍇ�͉������Ȃ�
			
		End If
		' === 20060804 === UPDATE E
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Input_Str
	'   �T�v�F  ���͕����𔻒肷��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Input_Str(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef Pm_Moji As String) As Short
		'�������i���͕s�j
		CF_Jge_Input_Str = 0
		
		'���ʐ���
		
		'���͕����^�C�v�Ő���
		Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
			Case IN_STR_TYP_NUM
				'���l�݂̂O�`�X
				If Pm_Moji >= "0" And Pm_Moji <= "9" Then
					CF_Jge_Input_Str = 1
				End If
				
			Case IN_STR_TYP_KIN
				'���ʁE���z�E�P���n
				'���l����
				If InStr("0123456789 ", Pm_Moji) > 0 Then
					CF_Jge_Input_Str = 1
				End If
				
				'����
				If CF_Jge_Input_Str = 0 Then
					Select Case pm_Dsp_Sub_Inf.Detail.Num_Sign_Fig
						Case IN_NUM_PLUS
							'��׽
							If InStr("+", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
						Case IN_NUM_MINUS
							'ϲŽ
							If InStr("-", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
						Case IN_NUM_PLUS_MINUS
							'����
							If InStr("+-", Pm_Moji) > 0 Then
								CF_Jge_Input_Str = 1
							End If
					End Select
				End If
				
				'�����_
				If CF_Jge_Input_Str = 0 Then
					If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And InStr(".", Pm_Moji) > 0 Then
						CF_Jge_Input_Str = 1
					End If
				End If
				
			Case IN_STR_TYP_X
				'���p
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) And CF_Ctr_AnsiLenB(Pm_Moji) = 1 Then
					CF_Jge_Input_Str = 1
					If Pm_Moji = "�@" Then
						Pm_Moji = Space(1)
					End If
				End If
				
			Case IN_STR_TYP_N
				'�S�p
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) And CF_Ctr_AnsiLenB(Pm_Moji) = 2 Then
					CF_Jge_Input_Str = 1
				End If
				
			Case IN_STR_TYP_NX
				'�S����
				If Pm_Moji <> Chr(System.Windows.Forms.Keys.Return) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Back) And Pm_Moji <> Chr(System.Windows.Forms.Keys.Escape) Then
					CF_Jge_Input_Str = 1
					If Pm_Moji = "�@" Then
						Pm_Moji = Space(1)
					End If
				End If
				
			Case IN_STR_TYP_TEL
				'�d�b�EFAX�n
				If InStr("0123456789- ", Pm_Moji) > 0 Then
					CF_Jge_Input_Str = 1
				End If
				
		End Select
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyDelete
	'   �T�v�F  �Ώۍ��ڂ�KEYDELETE�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyDelete(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_DelMoji As String
		Dim Wk_CurMoji As String
		
		
		'÷���ޯ���̂ݑΏ�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'���݂�÷�ď�̑I����Ԃ��擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'���݂̒l���擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'�S�I���̏ꍇ�i�I�𕶎����ő�o�C�g���ƈ�v�j
				All_Sel_Flg = True
			End If
			
			Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
				Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM, IN_TYP_HHMMSS
					'���t/�N��/����/�����b�̏ꍇ
					'�폜�s��
					Exit Function
			End Select
			
			If All_Sel_Flg = True Then
				'�S�I����
				'�S�ċ󔒂Ƃ��č폜
				Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
				
				'�폜��̕�����\���`���ɕϊ�
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
				
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'�l���������l�̏ꍇ
					'�J�n�ʒu����ԉE��
					Wk_SelStart = Len(Wk_DspMoji)
					Wk_SelLength = 0
				Else
					'�l���������l�ȊO�̏ꍇ
					'�J�n�ʒu����ԍ���
					Wk_SelStart = 0
					Wk_SelLength = 1
				End If
				
				'�폜��̕����u������
				'�����ݒ�
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'�폜���SelStart������
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
				'�폜���SelLength������
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
			Else
				
				If Act_SelStart >= Len(Wk_CurMoji) Then
					'�J�n�ʒu����ԉE�̏ꍇ
					'�폜�Ȃ�
					Exit Function
				End If
				
				If Act_SelLength = 0 Then
					'�I���Ȃ��̏ꍇ
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						
						If Act_SelStart = 0 Then
							'�J�n�ʒu����ԍ��̏ꍇ
							'�폜�Ώۂ̕����P�����擾
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
							
						Else
							'�J�n�ʒu����ԍ��ȊO�̏ꍇ
							'�폜�Ώۂ̕����P�����擾
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
						End If
						
						'�폜�����̔���
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'�폜���������͑Ώۂ̕����̏ꍇ
							If Act_SelStart = 0 Then
								'�J�n�ʒu����ԍ��̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Right(Wk_CurMoji, Len(Wk_CurMoji) - 1)
									
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'�����ҏW
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								
							End If
						Else
							'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
							'�폜�s��
							Exit Function
						End If
						
						'�폜��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'�ҏW���SelStart������
						Wk_SelStart = Act_SelStart
						'�ҏW���SelLength������
						Wk_SelLength = 0
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'�폜���SelStart������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�폜���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Else
						'�l���������l�ȊO�̏ꍇ
						'�폜�Ώۂ̕����P�����擾
						Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						'�폜�����̔���
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'�폜���������͑Ώۂ̕����̏ꍇ
							If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
								'�����ҏW
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Right(Wk_CurMoji, Len(Wk_CurMoji) - Act_SelStart - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							Else
								'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							End If
						Else
							'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
							'�폜�s��
							Exit Function
						End If
						
						'�폜��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'�ҏW���SelStart������
						Wk_SelStart = Act_SelStart
						'�ҏW���SelLength������
						Wk_SelLength = 0
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'�폜���SelStart������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�폜���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					End If
				Else
					'�ꕔ�I��
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'�l���������l�̏ꍇ
						'�폜�Ώۂ̕����P�����擾
						Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						'�폜�����̔���
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
							'�폜���������͑Ώۂ̕����̏ꍇ
							If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
								'�����ҏW
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + 1 + 1)
							Else
								'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
								Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							End If
						Else
							'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
							'�폜�s��
							Exit Function
						End If
						
						'�폜��̕�����\���`���ɕϊ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'�ҏW���SelStart������
						Wk_SelStart = Act_SelStart
						'�ҏW���SelLength������
						Wk_SelLength = 1
						
						'���l���ړ��ʏ���
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'���l���ڂŖ����͂̏ꍇ�́A��ԉE���J�n�ʒu�ɐݒ�
							If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
								Wk_SelStart = Len(Wk_DspMoji)
								'�ҏW���SelLength������
								Wk_SelLength = 0
							End If
						End If
						
						'�폜��̕����u������
						'�����ݒ�
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'�폜���SelStart������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'�폜���SelLength������
						'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Else
						'�l���������l�ȊO�̏ꍇ
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_STR Then
							'�������ڂ̏ꍇ
							'�����ҏW
							Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
							
							'�폜��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'�ҏW���SelStart������
							Wk_SelStart = Act_SelStart
							'�ҏW���SelLength������
							Wk_SelLength = 1
							
							'�폜��̕����u������
							'�����ݒ�
							Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
							
							'�폜���SelStart������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
							'�폜���SelLength������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
							
						Else
							'�������ڈȊO�̏ꍇ
							
							'�폜�Ώۂ̕����P�����擾
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
							
							'�폜�����̔���
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'�폜���������͑Ώۂ̕����̏ꍇ
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'�����ҏW
									Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Mid(Wk_CurMoji, Act_SelStart + 1 + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'�폜�Ώۂ��Ȃ��ׁA�󔒂�ҏW
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'�폜���������͑Ώۂ̕����̈ȊO�ꍇ
								'�폜�s��
								Exit Function
							End If
							
							'�폜��̕�����\���`���ɕϊ�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'�ҏW���SelStart������
							Wk_SelStart = Act_SelStart
							'�ҏW���SelLength������
							Wk_SelLength = 1
							
							'�폜��̕����u������
							'�����ݒ�
							Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
							
							'�폜���SelStart������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
							'�폜���SelLength������
							'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
							
						End If
					End If
				End If
				
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Ctl_Item_KeyDelete
	'   �T�v�F  �Ώۍ��ڂ�INSERT�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyInsert(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		
		'÷���ޯ���̂ݑΏ�
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'���݂�÷�ď�̑I����Ԃ��擾
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			
			If Act_SelLength = 0 Then
				'�I���Ȃ��̏ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Ctl.SelLength = 1
			Else
				'�ꕔ�I������ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Ctl.SelLength = 0
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_Clr_Dsp
	'   �T�v�F  �e��ʂ̍��ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_Clr_Dsp(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		If pm_Mode = ITM_ALL_CLR Then
			'��ʏ�����������щ�ʑS�̏������̏ꍇ
			
			'�O����e���N���A
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Dsp_Sub_Inf.Detail.Bef_Value = System.DBNull.Value
			'�O����e�t���O���N���A
			pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_DEF
			
			'�������e���N���A
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pm_Dsp_Sub_Inf.Detail.Rest_Value = System.DBNull.Value
			'�������e�t���O���N���A
			pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = VALUE_FLG_DEF
			
			'հ�ް���͖�
			pm_Dsp_Sub_Inf.Detail.In_Value_Flg = False
			
			'���ڕ����t���O�m�f
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
			
			'�t�H�[�J�X�����ޔ���e����擾
			Call CF_Set_Item_Focus_Ctl(pm_Dsp_Sub_Inf.Detail.Focus_Ctl_Bk, pm_Dsp_Sub_Inf)
			
			'�����͈ȊO�̃`�F�b�N�σt���O
			pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False
			
		End If
		
		'�`�F�b�N�֐��ďo��������������
		pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
		
		'���ڐF�̏����ݒ�
		Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All, ITEM_COLOR_DEF)
		
		'÷���ޯ��
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			Call CF_Set_Item_Direct(Space(pm_Dsp_Sub_Inf.Detail.MaxLengthB), pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'�����ޯ��
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox Then
			Call CF_Set_Item_Direct(False, pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'��߼������
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton Then
			Call CF_Set_Item_Direct(False, pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		End If
		
		'@'    '����
		'@'    If TypeOf pm_Dsp_Sub_Inf.Ctl Is Label Then
		'@'        Call CF_Set_Item_Direct(Space(pm_Dsp_Sub_Inf.Detail.MaxLengthB), pm_Dsp_Sub_Inf, pm_All, SET_FLG_DEF)
		'@'    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init_Clr_Dsp_Body
	'   �T�v�F  �e��ʂ̃{�f�B���ڂ�������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function CF_Init_Clr_Dsp_Body(pm_Bd_Index As Integer, pm_Mode As Integer, pm_All As Cls_All) As Integer
	''''
	''''    If pm_Mode = BODY_ALL_CLR Then
	''''        '�ŏ㖾�ײ��ޯ��
	''''        pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
	''''        '�������̖�
	''''        pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
	''''        '�����s������
	''''        pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
	''''    End If
	''''
	''''    '�������
	''''    pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Status = BODY_ROW_STATE_DEFAULT
	''''
	''''End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Copy_Dsp_Body_Row_Inf
	'   �T�v�F  Dsp_Body_Row_Inf�ŃR�s�[����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''Public Function CF_Copy_Dsp_Body_Row_Inf(pm_Moto_Body_Row As Cls_Dsp_Body_Row_Inf, pm_Saki_Body_Row As Cls_Dsp_Body_Row_Inf) As Integer
	''''
	''''    Dim Max_Col            As Integer
	''''    Dim Wk_Col             As Integer
	''''
	''''    '�P�s�P�ʂ̋Ɩ����
	''''    pm_Saki_Body_Row.Bus_Inf = pm_Moto_Body_Row.Bus_Inf
	''''    '�Ώۍs�̏��
	''''    pm_Saki_Body_Row.Status = pm_Moto_Body_Row.Status
	''''
	''''    Max_Col = UBound(pm_Moto_Body_Row.Item_Detail)
	''''    ReDim pm_Saki_Body_Row.Item_Detail(Max_Col)
	''''
	''''    '���ڒP�ʗ�
	''''    For Wk_Col = 1 To Max_Col
	''''        pm_Saki_Body_Row.Item_Detail(Wk_Col) = pm_Moto_Body_Row.Item_Detail(Wk_Col)
	''''    Next
	''''
	''''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_Item_Base
	'   �T�v�F  �����R�[�h�A�����A�����`�F�b�N
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Item_Base(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Input_Value As Object) As Short
		
		Dim Str_Value As String
		Dim Wk_Cnt As Short
		Dim wk_Moji As String
		Dim wk_Moji_Err As Short
		Dim Str_Input As String
		
		'������
		CF_Chk_Item_Base = CHK_BASE_OK
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Input_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Input_Value = pm_Value
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'÷���ޯ��
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Str_Value = CStr(pm_Value)
				
				'�G���[��������������
				wk_Moji_Err = 0
				
				'���͕���������
				Str_Input = ""
				
				'�����������J��Ԃ�
				For Wk_Cnt = 1 To Len(Str_Value)
					wk_Moji = Mid(Str_Value, Wk_Cnt, 1)
					
					If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
						'���͉\�����AOK
						Str_Input = Str_Input & wk_Moji
					Else
						'���͕s�\����
						If pm_Dsp_Sub_Inf.Detail.Dsp_Fmt <> "" Then
							'�\���`���ȊO�̕����̏ꍇ�A�G���[
							If InStr(pm_Dsp_Sub_Inf.Detail.Dsp_Fmt, wk_Moji) = 0 Then
								'���͒l�G���[
								wk_Moji_Err = wk_Moji_Err + 1
								Exit For
							End If
						Else
							'�\���`���Ȃ�
							'���͒l�G���[
							wk_Moji_Err = wk_Moji_Err + 1
							Exit For
						End If
					End If
				Next 
				
				If wk_Moji_Err > 0 Then
					'�R�[�h�G���[
					CF_Chk_Item_Base = CHK_BASE_ERR_CODE
				Else
					'�����`�F�b�N
					If CF_Ctr_AnsiLenB(CF_Trim_Item(Str_Input, pm_Dsp_Sub_Inf)) > pm_Dsp_Sub_Inf.Detail.MaxLengthB Then
						'�����G���[
						CF_Chk_Item_Base = CHK_BASE_ERR_OVER
					Else
						
						'���̓^�C�v
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_NUM
								'���l�̏ꍇ
								If IsNumeric(Str_Input) = False Then
									'�����G���[
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
							Case IN_TYP_DATE
								'���t�̏ꍇ
								If CF_Chk_Date(VB6.Format(Str_Input, "@@@@/@@/@@")) = False Then
									'�����G���[
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
							Case IN_TYP_CODE
								'�R�[�h�n�̏ꍇ
								'���ɂȂ�
								
							Case IN_TYP_STR
								'�����̏ꍇ
								'���ɂȂ�
								
							Case IN_TYP_YYYYMM
								'�N���̏ꍇ
								If CF_Chk_Date(VB6.Format(Str_Input & "/01", "@@@@/@@")) = False Then
									'�����G���[
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
							Case IN_TYP_HHMM
								'�����̏ꍇ
								If IsDate(VB6.Format(Str_Input, "@@:@@")) = False Then
									'�����G���[
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
							Case IN_TYP_HHMMSS
								'�����b�̏ꍇ
								If IsDate(VB6.Format(Str_Input, "@@:@@:@@")) = False Then
									'�����G���[
									CF_Chk_Item_Base = CHK_BASE_ERR_TYP
								End If
								
						End Select
					End If
					
				End If
				
				'���펞�A���͒l��߂�
				If CF_Chk_Item_Base = CHK_BASE_OK Then
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Input_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Input_Value = Str_Input
				End If
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				'�����ޯ��
				'���ɂȂ�
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				'��߼������
				'���ɂȂ�
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				'�߸���ޯ��
				'���ɂȂ�
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Chk_From_Process
	'   �T�v�F  �`�F�b�N�֐��ďo�������̐ݒ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Chk_From_Process(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_All As Cls_All) As Short
		
		Dim DspValue As Object
		
		'���݂̕\�����`��������
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DspValue �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DspValue = CF_Cnv_Dsp_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
		'�����ݒ�
		Call CF_Set_Item_Not_Change(DspValue, pm_Dsp_Sub_Inf, pm_All)
		
		Select Case pm_Process
			Case CHK_FROM_LOSTFOCUS
				'۽�̫�������̌ďo��
				If pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT Or pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_LOSTFOCUS Then
					'���݂̃`�F�b�N�֐��ďo��������������Ԃ�۽�̫����̏ꍇ
					'۽�̫����Ƃ���
					pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_LOSTFOCUS
					
				End If
				
			Case Else
				'���̑��̏ꍇ�́A���̂܂ܐݒ�
				pm_Dsp_Sub_Inf.Detail.Chk_From_Process = pm_Process
				
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Bef_Rest_Value
	'   �T�v�F  �������e�A�O����e��ޔ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Bef_Rest_Value(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		Dim Dsp_Value As Object
		'���ݓ��e
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Dsp_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		Select Case pm_Set_Flg
			Case SET_FLG_NOMAL
				'�ʏ�ҏW�̏ꍇ
				'�O����e/�������e��ޔ�����
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'�O����e�ƌ��ݓ��e���قȂ�ꍇ
					'�������e�ɑO����e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'�������e�t���O�ɑO����e�t���O
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'�O����e�Ɍ��ݓ��e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'�O����e�t���O�ɏ����l�ȊO
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
			Case SET_FLG_DEF
				'�����l�ҏW�̏ꍇ
				'�O��`�F�b�N���e/�O����e/�������e��ҏW
				
				'�������e�ɑO����e��ҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
				'�������e�t���O�ɑO����e�t���O
				pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
				If pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg <> VALUE_FLG_DEF Then
					'�������e�������l�ȊO�̏ꍇ
					'���ڕ����n�j
					pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
				Else
					'�������e�������l�̏ꍇ
					'���ڕ����m�f
					pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = False
				End If
				
				'�O����e�Ɍ��ݓ��e��ҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
				'�O����e�t���O�ɏ����l�ȊO
				pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_DEF
				
				'�O��`�F�b�N���e�ɏ����l��ҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'���ڂ̃G���[��Ԃɏ����l��ҏW
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
				
				'���ڏ������m�f
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = False
				
				'�`�F�b�N�֐��ďo��������������
				pm_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
				
				'�����͈ȊO�̃`�F�b�N�σt���O
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False
				
			Case SET_FLG_DB
				'�c�a�l�ҏW�̏ꍇ
				'����/�\�����ڂ̋�ʂȂ��A�O��`�F�b�N���e/�O����e/�������e
				'��ҏW
				
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'�O����e�ƌ��ݓ��e���قȂ�ꍇ
					'�������e�ɑO����e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'�������e�t���O�ɑO����e�t���O
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'�O����e�Ɍ��ݓ��e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'�O����e�t���O�ɏ����l�ȊO
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
				'�O��`�F�b�N���e�ɉ�ʕ\�����e��ҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'���ڂ̃G���[��ԂɃG���[�Ȃ���ҏW
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
				
				'���ڏ������n�j
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
				
				'�����͈ȊO�̃`�F�b�N�σt���O���`�F�b�N�ς݂ɕҏW
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
				
			Case SET_FLG_DB_ERR
				'�c�a�l�ҏW�̏ꍇ(�G���[����)
				'����/�\�����ڂ̋�ʂȂ��A�O��`�F�b�N���e/�O����e/�������e
				'��ҏW
				
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If pm_Dsp_Sub_Inf.Detail.Bef_Value <> Dsp_Value Then
					'�O����e�ƌ��ݓ��e���قȂ�ꍇ
					'�������e�ɑO����e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
					'�������e�t���O�ɑO����e�t���O
					pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
					
					'�O����e�Ɍ��ݓ��e��ҏW
					'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pm_Dsp_Sub_Inf.Detail.Bef_Value = Dsp_Value
					'�O����e�t���O�ɏ����l�ȊO
					pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = VALUE_FLG_ELSE
				End If
				
				'�O��`�F�b�N���e�ɉ�ʕ\�����e��ҏW
				'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = Dsp_Value
				'���ڂ̃G���[��Ԃɏ����l��ҏW
				pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
				
				'���ڏ������n�j
				pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
				
				'�����͈ȊO�̃`�F�b�N�σt���O���`�F�b�N�ς݂ɕҏW
				pm_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
				
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Bd_Idx_To_Idx
	'   �T�v�F  Dsp_Sub_Inf�̖��ׂm�n����pm_All.Dsp_Body_Inf�̍s�m�n�ɕϊ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Bd_Idx_To_Idx(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index = 0 Then
		''''        '�[��
		''''        CF_Bd_Idx_To_Idx = 0
		''''    Else
		''''        '(��ʂ̍ŏ�s��pm_All.Dsp_Body_Inf���ޯ��)�{(��ʏ��Dsp_Sub_Inf�̖��ׂm�n)�|�P
		''''        CF_Bd_Idx_To_Idx = pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_Dsp_Sub_Inf.Detail.Body_Index - 1
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Idx_To_Bd_Idx
	'   �T�v�F  pm_All.Dsp_Body_Inf�̍s�m�n����Dsp_Sub_Inf�̖��ׂn�ɕϊ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Idx_To_Bd_Idx(ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		''''    '(�Ώۍs)�|(��ʂ̍ŏ�s��pm_All.Dsp_Body_Inf���ޯ��)�{�|�P
		''''    CF_Idx_To_Bd_Idx = pm_Row - pm_All.Dsp_Body_Inf.Cur_Top_Index + 1
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Body_Focus_Ctl_Fst_Idx
	'   �T�v�F  �Ώۍs�̓��͉\�ȍŏ��̗�̃C���f�b�N�X���擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Body_Focus_Ctl_Fst_Idx(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Index_Wk As Short
		Dim Index_Wk As Short
		
		Rtn_Index_Wk = 0
		
		'�{�f�B�����ŏ���
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Bd_Index Then
				'�Ώۂ̖��ו��m�n�̏ꍇ
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					Rtn_Index_Wk = Index_Wk
					Exit For
				End If
			End If
		Next 
		
		CF_Get_Body_Focus_Ctl_Fst_Idx = Rtn_Index_Wk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Body_Focus_Ctl_Lst_Idx
	'   �T�v�F  �Ώۍs�̓��͉\�ȍŌ�̗�̃C���f�b�N�X���擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Body_Focus_Ctl_Lst_Idx(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Index_Wk As Short
		Dim Index_Wk As Short
		
		Rtn_Index_Wk = 0
		
		'�{�f�B�����ŏ���
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx - 1 To pm_All.Dsp_Base.Body_Fst_Idx Step -1
			
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Bd_Index Then
				'�Ώۂ̖��ו��m�n�̏ꍇ
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					Rtn_Index_Wk = Index_Wk
					Exit For
				End If
			End If
		Next 
		
		CF_Get_Body_Focus_Ctl_Lst_Idx = Rtn_Index_Wk
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Focus_Ctl
	'   �T�v�F  �t�H�[�J�X���󂯎����Ԃ����擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Focus_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index = 0 Then
		''''    '�R���g���[���z��ȊO�̏ꍇ
		''''        If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		''''            If pm_Dsp_Sub_Inf.Ctl.Enabled = True _
		'''''            And pm_Dsp_Sub_Inf.Ctl.Visible = True Then
		''''                Rtn_Value = True
		''''            End If
		''''        End If
		''''    Else
		''''    '�R���g���[���z��̏ꍇ
		''''        'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status <> BODY_ROW_STATE_DEFAULT Then
		''''        '������ԈȊO�̏ꍇ
		''''            If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		''''                If pm_Dsp_Sub_Inf.Ctl.Enabled = True _
		'''''                And pm_Dsp_Sub_Inf.Ctl.Visible = True Then
		''''                    Rtn_Value = True
		''''                End If
		''''            End If
		''''        End If
		''''    End If
		''''
		''''    CF_Set_Focus_Ctl = Rtn_Value
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Body_Row_Status
	'   �T�v�F  ���͌n�̖��׏��̍s��Ԃ��œK������
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Body_Row_Status(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Row              As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Fst_Def_Row         As Integer
		''''    Dim Iput_Wait_Next_Row  As Integer
		''''
		''''    '����͑ҏ�ԣ�̍s
		''''    '��ŏI�����s��̍s
		''''    '�ŏ��̏�����Ԃ̍s���擾
		''''    Iput_Wait_Row = 0
		''''    Lst_Row = 0
		''''    Fst_Def_Row = 0
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''        '����͑ҏ�ԣ
		''''            Iput_Wait_Row = Wk_Row
		''''        End If
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''        '��ŏI�����s�
		''''            Lst_Row = Wk_Row
		''''        End If
		''''
		''''        '�ŏ��̢������ԣ
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT _
		'''''        And Fst_Def_Row = 0 Then
		''''            Fst_Def_Row = Wk_Row
		''''        End If
		''''
		''''    Next
		''''
		''''    Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''        Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''        '��o�^�n��̏ꍇ
		''''
		''''            If Lst_Row = 0 Then
		''''            '��ŏI�����s����Ȃ��ꍇ
		''''                If Iput_Wait_Row = 0 Then
		''''                '����͑ҏ�ԣ���Ȃ��ꍇ
		''''                    '��ŏI�����s���ݒ�
		''''                    If Fst_Def_Row > 0 Then
		''''                    '�������ԣ������ꍇ
		''''' === 20060817 === UPDATE S - ACE)Sejima �ő喾�א��̍l��
		'''''D                        '�ŏ��̢������Ԃ̍s��ˢ�ŏI�����s�
		'''''D                        pm_All.Dsp_Body_Inf.Row_Inf(Fst_Def_Row).Status = BODY_ROW_STATE_LST_ROW
		''''' === 20060817 === UPDATE ��
		''''                        '�Ώۂ̍s���ő喾�א��𒴂��Ȃ��ꍇ
		''''                        If Fst_Def_Row <= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''                            '�ŏ��̢������Ԃ̍s��ˢ�ŏI�����s�
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Fst_Def_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''' === 20060817 === UPDATE E
		''''                    End If
		''''                Else
		''''                '����͑ҏ�ԣ������ꍇ
		''''                    '����͑ҏ�ԣ�̎��̍s������
		''''                    Iput_Wait_Next_Row = Iput_Wait_Row + 1
		''''
		''''                    If Iput_Wait_Next_Row > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''                    '����͑ҏ�ԣ�̎��̍s���z��𒴂����ꍇ
		''''                        '����͑ҏ�ԣ����ŏI�����s�
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                    Else
		''''                    '����͑ҏ�ԣ�̎��̍s���z����̏ꍇ
		''''                        If pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Next_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''                        '����͑ҏ�ԣ�̎��̍s���������ԣ�̏ꍇ
		''''                            '����͑ҏ�ԣ����ŏI�����s�
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''                    End If
		''''
		''''                End If
		''''            Else
		''''            '��ŏI�����s�������ꍇ
		''''                If Iput_Wait_Row > 0 Then
		''''                '����͑ҏ�ԣ������ꍇ
		''''                    '��ŏI�����s����������ԣ
		''''                    pm_All.Dsp_Body_Inf.Row_Inf(Lst_Row).Status = BODY_ROW_STATE_DEFAULT
		''''
		''''                    '����͑ҏ�ԣ�̎��̍s������
		''''                    Iput_Wait_Next_Row = Iput_Wait_Row + 1
		''''
		''''                    If Iput_Wait_Next_Row > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''                    '����͑ҏ�ԣ�̎��̍s���z��𒴂����ꍇ
		''''                        '����͑ҏ�ԣ����ŏI�����s�
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                    Else
		''''                    '����͑ҏ�ԣ�̎��̍s���z����̏ꍇ
		''''                        If pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Next_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''                        '����͑ҏ�ԣ�̎��̍s���������ԣ�̏ꍇ
		''''                            '����͑ҏ�ԣ����ŏI�����s�
		''''                            pm_All.Dsp_Body_Inf.Row_Inf(Iput_Wait_Row).Status = BODY_ROW_STATE_LST_ROW
		''''                        End If
		''''                    End If
		''''
		''''                End If
		''''            End If
		''''    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Dell_Refresh_Body_Inf
	'   �T�v�F  ��ʃ{�f�B������ʕ\����Ԃɍ��킹�čĐݒ肷��
	'   �@�@�F  �s�v�s���폜
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dell_Refresh_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		''''        '�ő�s�ޔ�
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '�������ԣ�̍s
		''''        '����͑ҏ�ԣ�̍s
		''''        '��ŏI�����s��̍s��
		''''        '���擾����
		''''        Def_Cnt = 0
		''''        Iput_Cnt = 0
		''''        Iput_Wait_Row = 0
		''''        Lst_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '�������ԣ
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''            '����͍Ϗ�ԣ
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            '����͑ҏ�ԣ
		''''                Iput_Wait_Row = Wk_Row
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            '��ŏI�����s�
		''''                Lst_Row = Wk_Row
		''''            End If
		''''
		''''        Next
		''''
		''''        '����͑ҏ�ԣ�Ƣ�ŏI�����s��̂ǂ��炩������ꍇ
		''''        If Iput_Wait_Row > 0 Or Lst_Row > 0 Then
		''''            If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		''''            '�ŏ㖾�ײ��ޯ�����P�̏ꍇ
		''''                If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		'''''                And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		''''                End If
		''''            Else
		''''                If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		'''''                And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                '�������ԣ�̍s����ʈړ��ʈȏ�ł���
		''''                '��ʕ\�����א����z�񂪑����ꍇ
		''''                    '�ő喾�׍s���P�s���炷
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		''''                End If
		''''            End If
		''''
		''''            '�X�N���[���o�[�̍ő�l���Đݒ�
		''''            Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''        End If
		''''
		''''        '���׏��̍s��Ԃ��Đݒ�
		''''        Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Add_Refresh_Body_Inf
	'   �T�v�F  ��ʃ{�f�B������ʕ\����Ԃɍ��킹�čĐݒ肷��
	'   �@�@�F  �K�v�s��ǉ�
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Add_Refresh_Body_Inf(ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		''''
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Max_Row_Up_Flg      As Boolean
		''''    Dim Max_Row_Up          As Integer
		''''
		''''    '�������A�t�]������I
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		''''        '�ő�s�ޔ�
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '�������ԣ�̍s
		''''        '����͑ҏ�ԣ�̍s
		''''        '��ŏI�����s��̍s��
		''''        '���擾����
		''''        Def_Cnt = 0
		''''        Iput_Cnt = 0
		''''        Iput_Wait_Row = 0
		''''        Lst_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '�������ԣ
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''            '����͍Ϗ�ԣ
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            '����͑ҏ�ԣ
		''''                Iput_Wait_Row = Wk_Row
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            '��ŏI�����s�
		''''                Lst_Row = Wk_Row
		''''            End If
		''''
		''''        Next
		''''
		''''        Max_Row_Up_Flg = False
		''''        If Max_Row < pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''        '�ő���͖��א��ɓ��B���Ă��Ȃ��ꍇ
		''''            '�ő喾�׍s��ǉ�����
		''''            Max_Row_Up_Flg = True
		''''        Else
		''''            If Iput_Wait_Row = 0 And Lst_Row = 0 Then
		''''            '����͑ҏ�ԣ�Ƣ�ŏI�����s��Ȃ��ꍇ
		''''                If Iput_Cnt >= pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''                '����͍Ϗ�ԣ����ʍő�\�������ȏ�
		''''                    '���͉\�s���쐬����
		''''                    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''                    '�ő���͖��א����ݒ肳�ꂢ��ꍇ
		''''                        If Max_Row < pm_All.Dsp_Base.Max_Body_Cnt Then
		''''                        '�ő���͖��א��ɓ��B���Ă��Ȃ��ꍇ
		''''                            '�ő喾�׍s��ǉ�����
		''''                            Max_Row_Up_Flg = True
		''''                        End If
		''''                    Else
		''''                        '�ő喾�׍s��ǉ�����
		''''                        Max_Row_Up_Flg = True
		''''                    End If
		''''                End If
		''''            End If
		''''        End If
		''''
		''''        If Max_Row_Up_Flg = True Then
		''''        '�ő喾�׍s��ǉ�����ꍇ
		''''            If pm_All.Dsp_Base.Dsp_Body_Cnt >= Max_Row Then
		''''            '���݂̍ő喾�׍s����ʂ̍ő�\���s�ȉ��̏ꍇ(�P�y�[�W�ȓ�)
		''''                '��ʍő�\���s�{��ʃy�[�W�ړ���
		''''                Max_Row_Up = pm_All.Dsp_Base.Dsp_Body_Cnt + pm_All.Dsp_Base.Dsp_Body_Move_Qty
		''''            Else
		''''            '���݂̍ő喾�׍s����ʂ̍ő�\���s�𒴂���̏ꍇ�i�Q�y�[�W�ȏ�j
		''''                Max_Row_Up = Max_Row + 1
		''''            End If
		''''
		''''            'pm_All.Dsp_Body_Inf�̍s��ǉ�
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row_Up)
		''''            '�ǉ��s������������
		''''            For Wk_Row = Max_Row + 1 To Max_Row_Up
		''''                '�z��O�̏�������Ώۍs�ɃR�s�[
		''''                Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''            Next
		''''
		''''            '�X�N���[���o�[�̍ő�l���Đݒ�
		''''            Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''            '���׍s�ǉ���̊J�n�ƏI����ݒ�
		''''            pm_Row_Inf_Max_S = Max_Row + 1
		''''            pm_Row_Inf_Max_E = Max_Row_Up
		''''
		''''        End If
		''''
		''''        '���׏��̍s��Ԃ��Đݒ�
		''''        Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    End If
		''''
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Re_Crt_Body_Inf
	'   �T�v�F  ��ʂō��ړ��͂��ꂽ�ꍇ�ɖ��׏����č쐬����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Re_Crt_Body_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		''''    Dim Bd_Index            As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Wait_Row       As Integer
		''''    Dim Lst_Row             As Integer
		''''    Dim Max_Row_Up_Flg      As Boolean
		''''    Dim Max_Row_Up          As Integer
		''''
		''''    '�������A�t�]������I
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''    '�R���g���[���z��̏ꍇ
		''''        If CF_Get_Item_Value(pm_Dsp_Sub_Inf) = pm_Dsp_Sub_Inf.Detail.Bef_Value Then
		''''            Exit Function
		''''        End If
		''''
		''''        'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''        Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''        '��ʃ{�f�B�s��Ԃ���͏�Ԃɐݒ�
		''''        pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
		''''
		''''        '��ʃ{�f�B�s�̔z����č쐬
		''''        Call CF_Add_Refresh_Body_Inf(pm_All, pm_Row_Inf_Max_S, pm_Row_Inf_Max_E)
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Bd_Vs_Scrl_Max
	'   �T�v�F  ���݂̖��׏�񂩂�c�X�N���[���o�[�̍ő�l��ݒ�
	'   �@�@�@�@��ʂ̓��e��pm_All.Dsp_Body_Inf�ɑޔ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Bd_Vs_Scrl_Max(ByRef pm_All As Cls_All) As Short
		
		''''    Dim Wk_Value    As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		''''        Wk_Value = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''        If Wk_Value < 0 Then
		''''            Wk_Value = 1
		''''        End If
		''''        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''            Call CF_Set_VScrl_Max(Wk_Value, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''        End If
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Body_Bkup
	'   �T�v�F  �ŏ㖾�ײ��ޯ��(pm_All.Dsp_Body_Inf.Cur_Top_Index)�����
	'   �@�@�@�@��ʂ̓��e��pm_All.Dsp_Body_Inf�ɑޔ�����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Bkup(ByRef pm_All As Cls_All) As Short
		
		''''    Dim WK_Dsp_Body_Inf    As Cls_Dsp_Body_Inf
		''''    Dim Max_Row            As Integer
		''''    Dim Wk_Row             As Integer
		''''    Dim Wk_Dsp_Row         As Integer
		''''    Dim Bd_Col_Index       As Integer
		''''    Dim Index_Wk            As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		''''        '���݂̍ő�s���擾
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '�ꎞ�ޔ�
		''''        ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''        For Wk_Row = 1 To Max_Row
		''''            '�Ώۍs�ɃR�s�[
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''        Next
		''''
		''''        Wk_Dsp_Row = 0
		''''        For Wk_Row = 1 To Max_Row
		''''
		''''            If Wk_Row >= pm_All.Dsp_Body_Inf.Cur_Top_Index _
		'''''            And Wk_Row <= pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 Then
		''''            '���ݕ\������Ă��閾��
		''''
		''''                '�P�s�P�ʂ̏����܂��ݒ�
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''                Wk_Dsp_Row = Wk_Dsp_Row + 1
		''''                Bd_Col_Index = 0
		''''                '�{�f�B�����ŏ���
		''''                For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''                    If Wk_Dsp_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index Then
		''''                    '�Ώۂ̖��׍s�̏ꍇ
		''''                        Bd_Col_Index = Bd_Col_Index + 1
		''''                        '��ʍ��ڏڍ׏���ݒ�
		''''                        '�����ɂ���ĕύX����鍀�ڂ̂�
		''''                        Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Bd_Col_Index) _
		'''''                                                          , pm_All.Dsp_Sub_Inf(Index_Wk).Detail)
		''''
		''''                        pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Bd_Col_Index).Dsp_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
		''''                    End If
		''''
		''''                    If Wk_Dsp_Row < pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index Then
		''''                    '�Ώۂ̖��׍s�𒴂����ꍇ�I��
		''''                        Exit For
		''''                    End If
		''''                Next
		''''
		''''            Else
		''''            '���ݕ\������Ă���ȊO�̖���
		''''                '�Ώۍs�ɃR�s�[
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''            End If
		''''        Next
		''''
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Body_Dsp
	'   �T�v�F  �ŏ㖾�ײ��ޯ��(pm_All.Dsp_Body_Inf.Cur_Top_Index)�����
	'   �@�@�@�@sp_Body_Inf����ʂɕҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Dsp(ByRef pm_All As Cls_All) As Short
		''''    Dim Index_Wk        As Integer
		''''    Dim Bd_Index        As Integer
		''''    Dim Bd_Index_Bk     As Integer
		''''    Dim Bd_Col_Index    As Integer
		''''    Dim Cur_Top_Index   As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		'''''============================================================================
		''''        '�ŏ㖾�ײ��ޯ���̍Đݒ�
		''''        If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 _
		'''''          > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''        '���݂̍ŏ㖾�ײ��ޯ�������ʕ\�������ꍇ��
		''''        '�z�񐔂�����Ȃ��ꍇ
		''''            '�ŏ㖾�ײ��ޯ����\���\�Ȉ�ԉ��̍s�ɐݒ�
		''''            Cur_Top_Index = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''            If Cur_Top_Index <= 0 Then
		''''                Cur_Top_Index = 1
		''''            End If
		''''            pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
		''''            If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''                '�c�X�N���[���o�[��ݒ�
		''''                Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''            End If
		''''        End If
		'''''============================================================================
		''''
		''''        '�{�f�B�����ŏ���
		''''        Bd_Index = 0
		''''        Bd_Index_Bk = 0
		''''
		''''        For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''            If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
		''''
		''''                'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''                Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		''''
		''''                If Bd_Index_Bk <> Bd_Index Then
		''''                '���׍s�u���C�N
		''''                    Bd_Col_Index = 1
		''''                    Bd_Index_Bk = Bd_Index
		''''                Else
		''''                    Bd_Col_Index = Bd_Col_Index + 1
		''''                End If
		''''
		''''                '��ʍ��ڏڍ׏���ݒ�
		''''                '�����ɂ���ĕύX����鍀�ڂ̂�
		''''                Call CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(pm_All.Dsp_Sub_Inf(Index_Wk).Detail, pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(Bd_Col_Index))
		''''
		''''                '���ڂ̏�񂪕ύX���������R���g���[���ɐݒ�
		''''                '��ݼ޲���Ă��N�������ɕҏW
		''''                Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		''''                '̫�������
		''''                Call CF_Set_Item_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl, pm_All.Dsp_Sub_Inf(Index_Wk))
		''''                '�R���g���[���̑O�i/�w�i�F
		''''                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_NORMAL_STATUS, pm_All)
		''''
		''''            End If
		''''
		''''        Next
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Dsp_Body_Inf_To_Dsp_Sub_Inf
	'   �T�v�F  ���ʃ{�f�B���ˢ��ʍ��ڏ��ɕҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(ByRef pm_Dsp_Sub_Inf_Detail As Cls_Dsp_Sub_Detail_Inf, ByRef pm_Dsp_Body_Row_Inf_Item_Detail As Cls_Dsp_Sub_Detail_Inf) As Short
		
		'��ʍ��ڏڍ׏���ݒ�
		'�����ɂ���ĕύX����鍀�ڂ̂�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf_Detail.Dsp_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value
		pm_Dsp_Sub_Inf_Detail.Focus_Ctl = pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl
		pm_Dsp_Sub_Inf_Detail.Focus_Ctl_Bk = pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl_Bk
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf_Detail.Bef_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value
		pm_Dsp_Sub_Inf_Detail.Bef_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value_Flg
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf_Detail.Rest_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value
		pm_Dsp_Sub_Inf_Detail.Rest_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value_Flg
		pm_Dsp_Sub_Inf_Detail.In_Value_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.In_Value_Flg
		pm_Dsp_Sub_Inf_Detail.Item_Init_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Item_Init_Flg
		pm_Dsp_Sub_Inf_Detail.Item_Rest_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Item_Rest_Flg
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value = pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value
		pm_Dsp_Sub_Inf_Detail.Err_Status = pm_Dsp_Body_Row_Inf_Item_Detail.Err_Status
		pm_Dsp_Sub_Inf_Detail.Locked = pm_Dsp_Body_Row_Inf_Item_Detail.Locked
		pm_Dsp_Sub_Inf_Detail.Not_Input_Chk_Fin_Flg = pm_Dsp_Body_Row_Inf_Item_Detail.Not_Input_Chk_Fin_Flg
		pm_Dsp_Sub_Inf_Detail.Chk_From_Process = pm_Dsp_Body_Row_Inf_Item_Detail.Chk_From_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Dsp_Sub_Inf_To_Dsp_Body_Inf
	'   �T�v�F  ���ʍ��ڏ��ˢ��ʃ{�f�B���ɕҏW����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(ByRef pm_Dsp_Body_Row_Inf_Item_Detail As Cls_Dsp_Sub_Detail_Inf, ByRef pm_Dsp_Sub_Inf_Detail As Cls_Dsp_Sub_Detail_Inf) As Short
		
		'��ʍ��ڏڍ׏���ݒ�
		'�����ɂ���ĕύX����鍀�ڂ̂�
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Body_Row_Inf_Item_Detail.Dsp_Value = pm_Dsp_Sub_Inf_Detail.Dsp_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl = pm_Dsp_Sub_Inf_Detail.Focus_Ctl
		pm_Dsp_Body_Row_Inf_Item_Detail.Focus_Ctl_Bk = pm_Dsp_Sub_Inf_Detail.Focus_Ctl_Bk
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value = pm_Dsp_Sub_Inf_Detail.Bef_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Value_Flg = pm_Dsp_Sub_Inf_Detail.Bef_Value_Flg
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value = pm_Dsp_Sub_Inf_Detail.Rest_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf_Detail.Rest_Value_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.In_Value_Flg = pm_Dsp_Sub_Inf_Detail.In_Value_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Item_Init_Flg = pm_Dsp_Sub_Inf_Detail.Item_Init_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Item_Rest_Flg = pm_Dsp_Sub_Inf_Detail.Item_Rest_Flg
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Body_Row_Inf_Item_Detail.Bef_Chk_Value = pm_Dsp_Sub_Inf_Detail.Bef_Chk_Value
		pm_Dsp_Body_Row_Inf_Item_Detail.Err_Status = pm_Dsp_Sub_Inf_Detail.Err_Status
		pm_Dsp_Body_Row_Inf_Item_Detail.Locked = pm_Dsp_Sub_Inf_Detail.Locked
		pm_Dsp_Body_Row_Inf_Item_Detail.Not_Input_Chk_Fin_Flg = pm_Dsp_Sub_Inf_Detail.Not_Input_Chk_Fin_Flg
		pm_Dsp_Body_Row_Inf_Item_Detail.Chk_From_Process = pm_Dsp_Sub_Inf_Detail.Chk_From_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Body_Dsp_Trg_Row
	'   �T�v�F  �Ώۍs����ʂɕ\��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Body_Dsp_Trg_Row(ByRef pm_All As Cls_All, ByRef pm_Row As Short) As Short
		
		''''    Dim Cur_Top_Index   As Integer
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''
		''''        '���ݕ\������Ă��閾�ׂɑΏۍs���\�����ꂢ�Ă��邩���f
		''''        If pm_All.Dsp_Body_Inf.Cur_Top_Index <= pm_Row _
		'''''        And pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 >= pm_Row _
		'''''        Then
		''''            '���ݕ\������Ă���ꍇ�́A�����Ȃ�
		''''        Else
		''''            '���ݕ\������Ă���ꍇ�́A�Ώۍs��\������ׂ�
		''''            '�ŏ㖾�ײ��ޯ�����v�Z
		''''
		''''            '��{�Ƃ��đΏۍs����ʂ̈�ԏ�ɐݒ�
		''''            pm_All.Dsp_Body_Inf.Cur_Top_Index = pm_Row
		''''
		''''            '�A���A��ʕ\������ꍇ�A
		''''            'Dsp_Body_Inf.Dsp_Body_Inf�̔z�񐔂Ɖ�ʂɕ\�����鐔�͈�v����K�v�����邽��
		''''            '�Ώۍs����ʂ̈�ԏ�ɐݒ肵���ꍇ�ɁA��׽�ő�\���s�|�P��
		''''            'Dsp_Body_Inf.Dsp_Body_Inf�̔z��ɕK�v
		''''            If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 _
		'''''             > UBound(pm_All.Dsp_Body_Inf.Row_Inf) _
		'''''            Then
		''''                '�z�񐔂�����Ȃ��ꍇ�́A�Ώۍs����ԉ��ɐݒ�
		''''                pm_All.Dsp_Body_Inf.Cur_Top_Index = pm_Row - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''                '�␳
		''''                If pm_All.Dsp_Body_Inf.Cur_Top_Index <= 0 Then
		''''                    pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
		''''                End If
		''''
		''''            End If
		''''
		''''        End If
		''''
		''''        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
		''''            '�c�X�N���[���o�[��ݒ�
		''''            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
		''''        End If
		''''
		''''        '��ʖ��ו\��
		''''        Call CF_Body_Dsp(pm_All)
		''''    End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jdg_Row_Down_Focus
	'   �T�v�F  �\������Ă��Ȃ����̖��ׂɃt�H�[�J�X���󂯎���
	'   �@�@�@�@�s�����邩�𔻒肵�A�\�ȍs�Ƃ��̍s��\������Ƃ�
	'   �@�@�@�@�ŏ㖾�׃C���f�b�N�X���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jdg_Row_Down_Focus(ByRef pm_Cur_Top_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Low_Top_Row         As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Ok_Row              As Integer
		''''
		''''    '�ړ��\�ȍs����
		''''    Rtn_Value = False
		''''    pm_Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        '��ʖ��ׂ�艺�̈�ԏ�̍s���擾
		''''        Low_Top_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt
		''''        '���݂̍ő�s���擾
		''''        Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        '���ׂ�艺�̍s����ő�s�܂Ō���
		''''        Ok_Row = 0
		''''        For Wk_Row = Low_Top_Row To Max_Row
		''''
		''''            Select Case pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
		''''                    '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s����擾
		''''                    Ok_Row = Wk_Row
		''''                    Exit For
		''''            End Select
		''''        Next
		''''
		''''        '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s�������ꍇ
		''''        If Ok_Row > 0 Then
		''''            Rtn_Value = True
		''''            '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s�����ԉ��ɕ\�������ꍇ��
		''''            '�ŏ㖾�׃C���f�b�N�X���Z�o
		''''            pm_Cur_Top_Index = Ok_Row - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
		''''            If pm_Cur_Top_Index <= 0 Then
		''''                pm_Cur_Top_Index = 1
		''''            End If
		''''        End If
		''''
		''''    End If
		''''
		''''    CF_Jdg_Row_Down_Focus = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jdg_Row_Up_Focus
	'   �T�v�F  �\������Ă��Ȃ���̖��ׂɃt�H�[�J�X���󂯎���
	'   �@�@�@�@�s�����邩�𔻒肵�A�\�ȍs�Ƃ��̍s��\������Ƃ�
	'   �@�@�@�@�ŏ㖾�׃C���f�b�N�X���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jdg_Row_Up_Focus(ByRef pm_Cur_Top_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Rtn_Value           As Boolean
		''''    Dim Top_Low_Row         As Integer
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Ok_Row              As Integer
		''''
		''''    '�ړ��\�ȍs����
		''''    Rtn_Value = False
		''''    pm_Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        '��ʖ��ׂ���̈�ԉ��̍s���擾
		''''        Top_Low_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index - 1
		''''
		''''        '���ׂ���̍s����P�s�ڂ܂Ō���
		''''        Ok_Row = 0
		''''        For Wk_Row = Top_Low_Row To 1 Step -1
		''''            Select Case pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
		''''                    '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s����擾
		''''                    Ok_Row = Wk_Row
		''''                    Exit For
		''''            End Select
		''''        Next
		''''
		''''        '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s�������ꍇ����
		''''        '���ݕ\������Ă���ꍇ�͏���
		''''        If Ok_Row > 0 And Ok_Row <> pm_All.Dsp_Body_Inf.Cur_Top_Index Then
		''''            Rtn_Value = True
		''''            '����͑ҏ�ԣ�A����͍Ϗ�ԣ�A��ŏI�����s�����ԏ�ɕ\�������ꍇ��
		''''            '�ŏ㖾�׃C���f�b�N�X���Z�o
		''''            pm_Cur_Top_Index = Ok_Row
		''''        End If
		''''
		''''    End If
		''''
		''''    CF_Jdg_Row_Up_Focus = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Idex_Same_Bd_Ctl
	'   �T�v�F  �w�肳�ꂽ����/�s�ɊY�����鍀�ڂ̃C���f�b�N�X���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Idex_Same_Bd_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Idex As Short
		Dim Index_Wk As Short
		
		'������
		Rtn_Idex = 0
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
			'���ח̈�
			
			'�{�f�B�����ŏ���
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = pm_Row Then
					'�Ώۂ̖��׍s�̏ꍇ
					If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
						'������۰ٖ�
						Rtn_Idex = Index_Wk
						Exit For
					End If
				End If
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > pm_Row Then
					'�Ώۂ̖��׍s�𒴂����ꍇ�I��
					Exit For
				End If
			Next 
			
		End If
		
		CF_Get_Idex_Same_Bd_Ctl = Rtn_Idex
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Col_Same_Bd_Ctl
	'   �T�v�F  �w�肳�ꂽ����/�s�ɊY�����鍀�ڂ̗���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Col_Same_Bd_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		''''    Dim Rtn_Col         As Integer
		''''    Dim Col_Wk          As Integer
		''''
		''''    '������
		''''    Rtn_Col = 0
		''''
		''''    If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
		''''    '���ח̈�
		''''
		''''        '�{�f�B�����ŏ���
		''''        For Col_Wk = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Item_Detail)
		''''            If pm_Dsp_Sub_Inf.Ctl.Name = pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Item_Detail(Col_Wk).Item_Nm Then
		''''            '������۰ٖ�
		''''                Rtn_Col = Col_Wk
		''''                Exit For
		''''            End If
		''''        Next
		''''
		''''    End If
		''''
		''''    CF_Get_Col_Same_Bd_Ctl = Rtn_Col
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Idex_Same_Bd_Ctl_Hide_Row
	'   �T�v�F  �w�肳�ꂽ���۰ٖ��ɊY������B���s�̍��ڂ̃C���f�b�N�X���擾����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Idex_Same_Bd_Ctl_Hide_Row(ByRef pm_Ctl_Name As String, ByRef pm_All As Cls_All) As Short
		
		''''    Dim Rtn_Idex            As Integer
		''''    Dim Index_Wk            As Integer
		''''
		''''    '������
		''''    Rtn_Idex = 0
		''''
		''''    '�{�f�B�����ŏ���
		''''    For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
		''''
		''''        If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0 Then
		''''        '�Ώۂ̖��׍s�̏ꍇ
		''''            If pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name = pm_Ctl_Name Then
		''''            '������۰ٖ�
		''''                Rtn_Idex = Index_Wk
		''''                Exit For
		''''            End If
		''''        End If
		''''
		''''        If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
		''''        '�Ώۂ̖��׍s�𒴂����ꍇ�I��
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    CF_Get_Idex_Same_Bd_Ctl_Hide_Row = Rtn_Idex
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Edi_Dsp_Body_Item
	'   �T�v�F  �w�肳�ꂽ��ʂ̍���/�s�ɕҏW���s��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edi_Dsp_Body_Item(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Value As Object
		
		'��ʖ��ׂ̓��s�̍��ڂ̲��ޯ�����擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'�ҏW�l���`��������
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Wk_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Wk_Value = CF_Cnv_Dsp_Item(pm_Value, pm_All.Dsp_Sub_Inf(Trg_Index), False)
		
		'��ʂɕҏW
		Call CF_Set_Item_Direct(Wk_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, pm_Set_Flg)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Clr_Dsp_Body_Item
	'   �T�v�F  �w�肳�ꂽ��ʂ̍���/�s���N���A����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Clr_Dsp_Body_Item(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'��ʖ��ׂ̓��s�̍��ڂ̲��ޯ�����擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'��ʃN���A
		Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Dsp_Body_Item_Focus_Ctl
	'   �T�v�F  �w�肳�ꂽ��ʂ̍��ڂ̕ҏW���s��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Dsp_Body_Item_Focus_Ctl(ByRef pm_Focus_Ct As Boolean, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'��ʖ��ׂ̓��s�̍��ڂ̲��ޯ�����擾
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		'�t�H�[�J�X�����ҏW
		Call CF_Set_Item_Focus_Ctl(pm_Focus_Ct, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Edi_Dsp_Body_Inf
	'   �T�v�F  �w�肳�ꂽDsp_Body_Inf�̍��ڂɕҏW���s��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edi_Dsp_Body_Inf(ByRef pm_Value As Object, ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, Optional ByRef pm_Set_Flg As Short = SET_FLG_NOMAL) As Short
		
		''''    Dim Trg_Index         As Integer
		''''    Dim Wk_Value          As Variant
		''''    Dim Wk_Col            As Integer
		''''
		''''    '�ҏW�l���`��������
		''''    Wk_Value = CF_Cnv_Dsp_Item(pm_Value _
		'''''                             , pm_Dsp_Sub_Inf _
		'''''                             , False)
		''''
		''''
		''''    '��ʍ��ڏ��(pm_All.Dsp_Sub_Inf)�̗̂�ԍ����擾
		''''    Wk_Col = CF_Get_Col_Same_Bd_Ctl(pm_Dsp_Sub_Inf _
		'''''                                  , pm_Bd_Index _
		'''''                                  , pm_All)
		''''
		''''    '��ʃ{�f�B���(pm_All.Dsp_Body_Inf)�ɕҏW
		''''    pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Dsp_Value = Wk_Value
		''''
		''''    Select Case pm_Set_Flg
		''''        Case SET_FLG_NOMAL
		''''        '�ʏ�ҏW�̏ꍇ
		''''        '�O����e/�������e��ޔ�����
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '�O����e�ƌ��ݓ��e���قȂ�ꍇ
		''''                '�������e�ɑO����e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '�������e�t���O�ɑO����e�t���O
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '�O����e�Ɍ��ݓ��e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '�O����e�t���O�ɏ����l�ȊO
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''        Case SET_FLG_DEF
		''''        '�����l�ҏW�̏ꍇ
		''''        '�O��`�F�b�N���e/�O����e/�������e��ҏW
		''''
		''''            '�������e�ɑO����e��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''            '�������e�t���O�ɑO����e�t���O
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg <> VALUE_FLG_DEF Then
		''''            '�������e�������l�ȊO�̏ꍇ
		''''                '���ڕ����n�j
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Rest_Flg = True
		''''            Else
		''''            '�������e�������l�̏ꍇ
		''''                '���ڕ����m�f
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Rest_Flg = False
		''''            End If
		''''
		''''            '�O����e�Ɍ��ݓ��e��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''            '�O����e�t���O�ɏ����l�ȊO
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_DEF
		''''
		''''            '�O��`�F�b�N���e�ɏ����l��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '���ڂ̃G���[��Ԃɏ����l��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_DEF
		''''
		''''            '���ڏ������m�f
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = False
		''''
		''''            '�`�F�b�N�֐��ďo��������������
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Chk_From_Process = CHK_FROM_ALL_DEFAULT
		''''
		''''            '�����͈ȊO�̃`�F�b�N�σt���O
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = False
		''''
		''''        Case SET_FLG_DB
		''''        '�c�a�l�ҏW�̏ꍇ
		''''        '����/�\�����ڂ̋�ʂȂ��A�O��`�F�b�N���e/�O����e/�������e
		''''        '��ҏW
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '�O����e�ƌ��ݓ��e���قȂ�ꍇ
		''''                '�������e�ɑO����e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '�������e�t���O�ɑO����e�t���O
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '�O����e�Ɍ��ݓ��e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '�O����e�t���O�ɏ����l�ȊO
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''            '�O��`�F�b�N���e�ɉ�ʕ\�����e��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '���ڂ̃G���[��ԂɃG���[�Ȃ���ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_NOT
		''''
		''''            '���ڏ������n�j
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = True
		''''
		''''            '�����͈ȊO�̃`�F�b�N�σt���O���`�F�b�N�ς݂ɕҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = True
		''''
		''''        Case SET_FLG_DB_ERR
		''''        '�c�a�l�ҏW�̏ꍇ(�G���[����)
		''''        '����/�\�����ڂ̋�ʂȂ��A�O��`�F�b�N���e/�O����e/�������e
		''''        '��ҏW
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value <> Wk_Value Then
		''''            '�O����e�ƌ��ݓ��e���قȂ�ꍇ
		''''                '�������e�ɑO����e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value
		''''                '�������e�t���O�ɑO����e�t���O
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Rest_Value_Flg = pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg
		''''
		''''                '�O����e�Ɍ��ݓ��e��ҏW
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value = Wk_Value
		''''                '�O����e�t���O�ɏ����l�ȊO
		''''                pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Value_Flg = VALUE_FLG_ELSE
		''''            End If
		''''
		''''            '�O��`�F�b�N���e�ɉ�ʕ\�����e��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Bef_Chk_Value = Wk_Value
		''''            '���ڂ̃G���[��Ԃɏ����l��ҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Err_Status = ERR_DEF
		''''
		''''            '���ڏ������n�j
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Item_Init_Flg = True
		''''
		''''            '�����͈ȊO�̃`�F�b�N�σt���O���`�F�b�N�ς݂ɕҏW
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Item_Detail(Wk_Col).Not_Input_Chk_Fin_Flg = True
		''''
		''''    End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_Input_Aft
	'   �T�v�F  ��ݼ޲���āA����ڽ����Ă̓��͌㏈��
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'���ڏ������t���O�n�j
		pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
		'���ڕ����t���O�n�j
		pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
		
		'�������e�ɑO����e��ҏW
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Rest_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
		'�������e�t���O�ɑO����e�t���O
		pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
		
		If pm_Dsp_Sub_Inf.Detail.In_Value_Flg = False Then
			'������͎�
		End If
		'���̓t���O
		pm_Dsp_Sub_Inf.Detail.In_Value_Flg = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Execute
	'   �T�v�F  ���j���[�̉�ʢ�o�^��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Execute(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		Select Case pm_All.Dsp_Base.Dsp_Ctg
			Case DSP_CTG_ENTRY, DSP_CTG_REVISION
				'��o�^�n��A��C���n��̏ꍇ
				Rtn_Value = True
		End Select
		
		
		CF_Jge_Enabled_MN_Execute = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_DeleteCM
	'   �T�v�F  ���j���[�̉�ʢ�폜��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_DeleteCM(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		CF_Jge_Enabled_MN_DeleteCM = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_HARDCOPY
	'   �T�v�F  ���j���[�̉�ʢ��ʈ����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_HARDCOPY(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'��ʈ���͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_HARDCOPY = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_EndCm
	'   �T�v�F  ���j���[�̉�ʢ�I����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_EndCm(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'�I���͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_EndCm = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_APPENDC
	'   �T�v�F  ���j���[�̉�ʢ�������@�\��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_APPENDC(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'��ʏ������͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_APPENDC = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_ClearItm
	'   �T�v�F  ���j���[�̉�ʢ���ڏ�������̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_ClearItm(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���ڏ������͓��͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					'���ڏ������t���O�Ő���
					If pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True Then
						Rtn_Value = True
					End If
			End Select
		End If
		
		CF_Jge_Enabled_MN_ClearItm = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_UnDoItem
	'   �T�v�F  ���j���[�̉�ʢ���ڕ�����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_UnDoItem(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���ڕ����͓��͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					'���ڕ����t���O�Ő���
					If pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True Then
						Rtn_Value = True
					End If
			End Select
		End If
		
		CF_Jge_Enabled_MN_UnDoItem = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_ClearDE
	'   �T�v�F  ���j���[�̉�ʢ���׍s��������̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D            Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		'''''D            '��o�^�n��A��C���n��̏ꍇ
		''''' === 20060804 === UPDATE ��
		''''            Case DSP_CTG_ENTRY
		''''            '��o�^�n��̏ꍇ
		''''' === 20060804 === UPDATE E
		''''
		''''                '�Ώۍ��ڂ��{�f�B���̏ꍇ
		''''                If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''                And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''                    'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '�Ώۍs������͍Ϗ�ԣ�̏ꍇ�̂ݏ������\
		''''                    If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT Then
		''''                        Rtn_Value = True
		''''                    End If
		''''                End If
		''''        End Select
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_ClearDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_DeleteDE
	'   �T�v�F  ���j���[�̉�ʢ���׍s�폜��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        '�Ώۍ��ڂ��{�f�B���̏ꍇ
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''                '��o�^�n��A��C���n��̏ꍇ
		''''
		''''                    'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '�Ώۍs������͑ҏ�ԣ,����͍Ϗ�ԣ�̏ꍇ�̂ݏ������\
		''''                    Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status
		''''                        Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
		''''                            Rtn_Value = True
		''''                    End Select
		''''
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_DeleteDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_InsertDE
	'   �T�v�F  ���j���[�̉�ʢ���׍s�ǉ���̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        '�Ώۍ��ڂ��{�f�B���̏ꍇ
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		'''''D                '��o�^�n��A��C���n��̏ꍇ
		''''' === 20060804 === UPDATE ��
		''''                Case DSP_CTG_ENTRY
		''''                '��o�^�n��̏ꍇ
		''''' === 20060804 === UPDATE E
		''''
		''''                    'pm_All.Dsp_Body_Inf�̍s�m�n���擾
		''''                    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		''''
		''''                    '�Ώۍs������͑ҏ�ԣ,����͍Ϗ�ԣ�̏ꍇ�̂ݏ������\
		''''                    Select Case pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status
		''''                        Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
		''''                            Rtn_Value = True
		''''                    End Select
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_InsertDE = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_UnDoDe
	'   �T�v�F  ���j���[�̉�ʢ���׍s������̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		''''    Dim Rtn_Value As Boolean
		''''    Dim Bd_Index            As Integer
		''''
		''''    Rtn_Value = False
		''''
		''''    If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
		''''    '���ו\���̉��
		''''        '�Ώۍ��ڂ��{�f�B���̏ꍇ
		''''        If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD _
		'''''        And pm_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
		''''
		''''            Select Case pm_All.Dsp_Base.Dsp_Ctg
		''''' === 20060804 === UPDATE S - ACE)Sejima
		'''''D                Case DSP_CTG_ENTRY
		'''''D                '��o�^�n��̏ꍇ
		''''' === 20060804 === UPDATE ��
		''''                Case DSP_CTG_ENTRY, DSP_CTG_REVISION
		''''                '��o�^�n��A��C���n��̏ꍇ
		''''' === 20060804 === UPDATE E
		''''                    '�������e�����݂���ꍇ
		''''                    Select Case pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg
		''''                        Case BODY_ROW_REST_FLG_CLR
		''''                        '���׏������̕������
		''''                            '�Ώۂ̕����s������͑ҏ�ԣ����ŏI�����s���
		''''                            '����Ε����\
		''''
		''''                            If pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row >= 1 _
		'''''                            And pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row <= UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''
		''''                                Select Case pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row).Status
		''''                                    Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_LST_ROW
		''''                                        Rtn_Value = True
		''''                                End Select
		''''                            End If
		''''
		''''                        Case BODY_ROW_REST_FLG_DEL
		''''                        '���׏������̕������,���׍폜�̕������
		''''                            Rtn_Value = True
		''''                    End Select
		''''
		''''            End Select
		''''        End If
		''''    End If
		''''
		''''    CF_Jge_Enabled_MN_UnDoDe = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Cut
	'   �T�v�F  ���j���[�̉�ʢ�؂��裂̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Cut(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					
					Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
						Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM, IN_TYP_HHMMSS
							'���t/�N��/����/�����b�̏ꍇ�A���͌`�������܂��Ă���ꍇ�́A��؂��裕s��
						Case Else
							'���̑�
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) <> "" Then
								'���͓��e������ꍇ
								'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								If pm_Dsp_Sub_Inf.Ctl.SelLength > 0 Then
									'�I����Ԃ̏ꍇ
									Rtn_Value = True
								End If
							End If
					End Select
					
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Cut = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Copy
	'   �T�v�F  ���j���[�̉�ʢ�R�s�[��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Copy(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If CF_Trim_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf) <> "" Then
						'���͓��e������ꍇ
						'�I����Ԃ̏ꍇ
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Copy = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Paste
	'   �T�v�F  ���j���[�̉�ʢ�\��t����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					'�د���ް�ނ̓��e���e�L�X�g�̏ꍇ
					If My.Computer.Clipboard.ContainsText() = True Then
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_Paste = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_SM_AllCopy
	'   �T�v�F  �|�b�v�A�b�v���j���[�̢���ړ��e�R�s�[��̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_SM_AllCopy(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'÷���ޯ��
				Rtn_Value = True
				' === 20060802 === INSERT S - ACE)Nagasawa
				'�ΏۃR���g���[���̃C���f�b�N�X��ޔ�
				pm_All.Dsp_Base.PopupMenu_Idx = CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag)
				' === 20060802 === INSERT E -
				'        Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is SSPanel5
				'        '����
				'            Rtn_Value = True
		End Select
		
		CF_Jge_Enabled_SM_AllCopy = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_SM_FullPast
	'   �T�v�F  �|�b�v�A�b�v���j���[�̢���ڂɓ\��t����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_SM_FullPast(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
			'�E�N���b�N�����R���g���[�����A�N�e�B�u�ȃR���g���[���ƈ�v
			
			'���͍��ڂ̏ꍇ
			If CF_Set_Focus_Ctl(pm_Trg_Dsp_Sub_Inf, pm_All) = True Then
				'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
				Select Case True
					Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
						'÷���ޯ��
						'�د���ް�ނ̓��e���e�L�X�g�̏ꍇ
						If My.Computer.Clipboard.ContainsText() = True Then
							Rtn_Value = True
							'�ΏۃR���g���[���̃C���f�b�N�X��ޔ�
							pm_All.Dsp_Base.PopupMenu_Idx = CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag)
						End If
				End Select
				
			End If
			
		End If
		
		CF_Jge_Enabled_SM_FullPast = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_PopupMenu
	'   �T�v�F  �|�b�v�A�b�v���j���[�̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_PopupMenu(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
		Select Case True
			Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'÷���ޯ��
				Rtn_Value = True
				'''        Case TypeOf pm_Trg_Dsp_Sub_Inf.Ctl Is SSPanel5
				'''        '����
				'''            Rtn_Value = True
		End Select
		
		CF_Jge_Enabled_PopupMenu = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_LStart
	'   �T�v�F  ���j���[�̉�ʢ�v�����^�o�ͣ�̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_LStart(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'�v�����^�o�͂͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_LStart = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Paste
	'   �T�v�F  ���j���[�̉�ʢ��ʕ\����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_VStart(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'��ʕ\���͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_VStart = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_Paste
	'   �T�v�F  ���j���[�̉�ʢ����ݒ裂̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_LConfig(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'����ݒ�͐�������
		Rtn_Value = True
		
		CF_Jge_Enabled_MN_LConfig = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Jge_Enabled_MN_SList
	'   �T�v�F  ���j���[�̉�ʢ�E�B���h�E�\����̎g�p��/�s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Jge_Enabled_MN_SList(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		Dim Rtn_Value As Boolean
		
		Rtn_Value = False
		
		'���͍��ڂ̏ꍇ
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
			'UPGRADE_WARNING: TypeOf �ɐV�������삪�w�肳��Ă��܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' ���N���b�N���Ă��������B
			Select Case True
				Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
					'÷���ޯ��
					'�د���ް�ނ̓��e���e�L�X�g�̏ꍇ
					If My.Computer.Clipboard.ContainsText() = True Then
						Rtn_Value = True
					End If
			End Select
			
		End If
		
		CF_Jge_Enabled_MN_SList = Rtn_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_UnDoItem
	'   �T�v�F  ���j���[�̍��ڕ����̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_UnDoItem(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Rest_Value As Object
		Dim Rest_Value_Flg As Short
		Dim Bef_Value As Object
		Dim Bef_Value_Flg As Short
		
		'�ޔ�����
		'�O����e
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Bef_Value = pm_Dsp_Sub_Inf.Detail.Bef_Value
		Bef_Value_Flg = pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg
		'�������e
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Rest_Value = pm_Dsp_Sub_Inf.Detail.Rest_Value
		Rest_Value_Flg = pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg
		
		'** ���ڏ������t���O���� **
		'��������e��������l�̏ꍇ
		If Rest_Value_Flg = VALUE_FLG_DEF Then
			'�����l����ʂɖ߂��̂ŁA���ڏ������m�f�Ƃ���
			pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = False
		Else
			'�����l�ȊO����ʂɖ߂��̂ŁA���ڏ������n�j�Ƃ���
			pm_Dsp_Sub_Inf.Detail.Item_Init_Flg = True
		End If
		
		'** ���ڕ����t���O���� **
		'��O����e��Ƣ�������e��������Ƃ������l�̏ꍇ
		If Rest_Value_Flg = VALUE_FLG_DEF And Bef_Value_Flg = VALUE_FLG_DEF Then
			'�O����e���������e�������l�ɂȂ�̂ŁA���ڕ����m�f�Ƃ���
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = False
		Else
			'�O����e���������e�̂ǂ��炩�������l�ȊO�Ȃ̂ŁA���ڕ����n�j�Ƃ���
			pm_Dsp_Sub_Inf.Detail.Item_Rest_Flg = True
		End If
		
		'���ݓ��e�ƕ������e����ꊷ����
		'�������e���O����e
		'UPGRADE_WARNING: �I�u�W�F�N�g Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Bef_Value = Rest_Value
		pm_Dsp_Sub_Inf.Detail.Bef_Value_Flg = Rest_Value_Flg
		'�O����e���������e
		'UPGRADE_WARNING: �I�u�W�F�N�g Bef_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Detail.Rest_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		pm_Dsp_Sub_Inf.Detail.Rest_Value = Bef_Value
		pm_Dsp_Sub_Inf.Detail.Rest_Value_Flg = Bef_Value_Flg
		
		'��������e���ʂɔ��f
		'��ݼ޲���Ă��N�������ɕҏW
		Call CF_Set_Item_Not_Change(Rest_Value, pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_ClearDE
	'   �T�v�F  ���j���[�̖��׏������̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_ClearDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim Wk_Row          As Integer
		''''    Dim Input_Wait_Cnt  As Integer
		''''    Dim Def_Row         As Integer
		''''
		''''    CF_Cmn_Ctl_MN_ClearDE = False
		''''
		''''    '�������\������
		''''    '����͑ҏ�ԣ�̌������擾
		''''    Input_Wait_Cnt = 0
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
		''''            Input_Wait_Cnt = Input_Wait_Cnt + 1
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    If Input_Wait_Cnt > 0 Then
		''''    '����͑ҏ�ԣ�����݂��Ă���ꍇ�A�������s�I�I
		''''        MsgBox "�󔒂̖��׍s���ɍ폜���Ă��������B"
		''''        CF_Cmn_Ctl_MN_ClearDE = False
		''''        Exit Function
		''''    End If
		''''
		''''    For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '�Ώۍs�̏ꍇ
		''''
		''''            '�������s�𕜌����ɑޔ�
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
		''''            '�����s
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
		''''            '�������̗L(���׏������̕������)
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_CLR
		''''
		''''            '�z��̏�������Ώۍs�ɃR�s�[
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''            '�������㢓��͑ҏ�ԣ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(pm_Bd_Index).Status = BODY_ROW_STATE_INPUT_WAIT
		''''
		''''        End If
		''''
		''''        '��ŏI�����s��𢏉����ԣ
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''            pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT
		''''            Exit For
		''''        End If
		''''    Next
		''''
		''''    '��ʃ{�f�B���̔z����Đݒ�
		''''    Call CF_Dell_Refresh_Body_Inf(pm_All)
		''''
		''''    CF_Cmn_Ctl_MN_ClearDE = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_DeleteDE
	'   �T�v�F  ���j���[�̖��׍폜�̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_DeleteDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Def_Cnt             As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    '�������A�t�]������I
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    '���݂̍ő�s���擾
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '�ꎞ�ޔ�
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    For Wk_Row = 1 To Max_Row
		''''        '�Ώۍs�ɃR�s�[
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''    Next
		''''
		''''    Wk_Row_New = 0
		''''    Def_Cnt = 1         '�K���P�s�͍폜�����ׁA�������ԣ�̊J�n���P����Ƃ���
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''
		''''        '�s������
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '�Ώۍs�̏ꍇ
		''''            '�폜�s�𕜌����ɑޔ�
		''''            Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
		''''            '�����s
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
		''''            '�������̗L(���׍폜�̕������)
		''''            pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_DEL
		''''
		''''        Else
		''''            Wk_Row_New = Wk_Row_New + 1
		''''            '�Ώۍs�ɃR�s�[
		''''            Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_DEFAULT Then
		''''            '�������ԣ
		''''                Def_Cnt = Def_Cnt + 1
		''''            End If
		''''
		''''            If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT Then
		''''            '����͍Ϗ�ԣ
		''''                Iput_Cnt = Iput_Cnt + 1
		''''            End If
		''''
		''''        End If
		''''    Next
		''''
		''''' === 20060818 === UPDATE S - ACE)Sejima
		'''''D    If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		'''''D    '�ŏ㖾�ײ��ޯ�����P�̏ꍇ
		'''''D        If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		''''''D        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		'''''D            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		'''''D        End If
		'''''D    Else
		'''''D        If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		''''''D        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		'''''D        '�������ԣ�̍s����ʈړ��ʈȏ�ł���
		'''''D        '��ʕ\�����א����z�񂪑����ꍇ
		'''''D            '�ő喾�׍s���P�s���炷
		'''''D            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		'''''D        End If
		'''''D    End If
		''''' === 20060818 === UPDATE ��
		''''    If Def_Cnt >= pm_All.Dsp_Base.Dsp_Body_Move_Qty _
		'''''    And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''    '�������ԣ�̍s����ʈړ��ʈȏ�ł���
		''''    '��ʕ\�����א����z�񂪑����ꍇ
		''''        '�ő喾�׍s���P�s���炷
		''''        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row - 1)
		''''    End If
		''''
		''''    If pm_All.Dsp_Body_Inf.Cur_Top_Index = 1 Then
		''''    '�ŏ㖾�ײ��ޯ�����P�̏ꍇ
		''''        If Iput_Cnt < pm_All.Dsp_Base.Dsp_Body_Cnt _
		'''''        And Max_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
		''''        End If
		''''    End If
		''''' === 20060818 === UPDATE E
		''''
		''''    '�X�N���[���o�[�̍ő�l��ݒ�
		''''    Call CF_Set_Bd_Vs_Scrl_Max(pm_All)
		''''
		''''    '���׏��̍s��Ԃ��Đݒ�
		''''    Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    '�z�񐔂��ύX���Ȃ��ꍇ�́A�ŏI�s�̏��������K�v
		''''    If Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
		''''        pm_Row_Inf_Max_S = Max_Row
		''''        pm_Row_Inf_Max_E = Max_Row
		''''    End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_InsertDE
	'   �T�v�F  ���j���[�̖��ב}���̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_InsertDE(ByRef pm_Bd_Index As Short, ByRef pm_Ins_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    CF_Cmn_Ctl_MN_InsertDE = False
		''''
		''''    '���݂̍ő�s���擾
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '�ꎞ�ޔ�
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''        '�Ώۍs�ɃR�s�[
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''        '����͍Ϗ�ԣ
		''''            Iput_Cnt = Iput_Cnt + 1
		''''        End If
		''''
		''''    Next
		''''
		''''    '�����`�F�b�N
		''''    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''    '�ő���͖��א����ݒ肳�ꂢ��ꍇ
		''''        If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''        '����͏�ԣ�̌������ő���͖��א��ɓ��B����ꍇ
		''''            MsgBox "���׍s�͂���ȏ�}���ł��܂���B"
		''''            CF_Cmn_Ctl_MN_InsertDE = False
		''''            Exit Function
		''''        End If
		''''    End If
		''''
		''''    Wk_Row_New = 0
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''
		''''        If Wk_Row = pm_Bd_Index Then
		''''        '�Ώۍs�̏ꍇ
		''''            Wk_Row_New = Wk_Row_New + 1
		''''            '����
		''''            ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''            '�z��̏�������Ώۍs�ɃR�s�[
		''''            Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''            '�������㢓��͑ҏ�ԣ
		''''            pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT_WAIT
		''''
		''''            '�ǉ��s���ďo���ɒʒm
		''''            pm_Ins_Bd_Index = Wk_Row_New
		''''
		''''        End If
		''''
		''''        Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''            Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
		''''                '�������ԣ�A����͍Ϗ�ԣ�����ޔ�
		''''                Wk_Row_New = Wk_Row_New + 1
		''''                '����
		''''                ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''
		''''                '�Ώۍs�ɃR�s�[
		''''                Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''        End Select
		''''
		''''    Next
		''''
		''''    '���׏��̍s��Ԃ��Đݒ�
		''''    Call CF_Set_Body_Row_Status(pm_All)
		''''
		''''    CF_Cmn_Ctl_MN_InsertDE = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_UnDoDe
	'   �T�v�F  ���j���[�̖��ו����̋��ʐ���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_UnDoDe(ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Boolean
		
		''''    Dim WK_Dsp_Body_Inf     As Cls_Dsp_Body_Inf
		''''    Dim Max_Row             As Integer
		''''    Dim Wk_Row              As Integer
		''''    Dim Wk_Row_New          As Integer
		''''    Dim Iput_Cnt            As Integer
		''''
		''''    CF_Cmn_Ctl_MN_UnDoDe = False
		''''
		''''    '�������A�t�]������I
		''''    pm_Row_Inf_Max_S = 0
		''''    pm_Row_Inf_Max_E = -1
		''''
		''''    '���݂̍ő�s���擾
		''''    Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		''''
		''''    '�ꎞ�ޔ�
		''''    ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		''''    Iput_Cnt = 0
		''''    For Wk_Row = 1 To Max_Row
		''''        '�Ώۍs�ɃR�s�[
		''''        Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''
		''''        If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
		''''        '����͍Ϗ�ԣ
		''''            Iput_Cnt = Iput_Cnt + 1
		''''        End If
		''''
		''''    Next
		''''
		''''    '�����`�F�b�N
		''''    If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
		''''    '�ő���͖��א����ݒ肳�ꂢ��ꍇ
		''''        If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
		''''        '����͏�ԣ�̌������ő���͖��א��ɓ��B����ꍇ
		''''            MsgBox "���׍s�͂���ȏ�}���ł��܂���B"
		''''            CF_Cmn_Ctl_MN_UnDoDe = False
		''''            Exit Function
		''''        End If
		''''    End If
		''''
		''''    '��������
		''''    Select Case pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg
		''''        Case BODY_ROW_REST_FLG_CLR
		''''        '���׏������̕������
		''''            For Wk_Row = 1 To Max_Row
		''''
		''''                If Wk_Row = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row Then
		''''                '�Ώۍs�̏ꍇ
		''''                    '�Ώۍs�ɕ��������R�s�[
		''''                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
		''''                End If
		''''
		''''                '��ŏI�����s��𢏉����ԣ
		''''                If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
		''''                    pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_DEFAULT
		''''                    Exit For
		''''                End If
		''''
		''''            Next
		''''
		''''        Case BODY_ROW_REST_FLG_DEL
		''''        '���׍폜�̕������
		''''
		''''            Wk_Row_New = 0
		''''            Iput_Cnt = 0
		''''            For Wk_Row = 1 To Max_Row
		''''
		''''                If Wk_Row = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row Then
		''''                '�Ώۍs�ɕ��������R�s�[
		''''                    Wk_Row_New = Wk_Row_New + 1
		''''                    '����
		''''                    ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''                    '�Ώۍs�ɕ��������R�s�[
		''''                    Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''                End If
		''''
		''''                Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
		''''                    Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
		''''                        '�������ԣ�A����͍Ϗ�ԣ�����ޔ�
		''''
		''''                        Wk_Row_New = Wk_Row_New + 1
		''''                        '����
		''''                        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
		''''
		''''                        '�Ώۍs�ɃR�s�[
		''''                        Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
		''''
		''''                End Select
		''''
		''''            Next
		''''
		''''    End Select
		''''
		''''    '��ʃ{�f�B�s�̔z����č쐬
		''''    Call CF_Add_Refresh_Body_Inf(pm_All, pm_Row_Inf_Max_S, pm_Row_Inf_Max_E)
		''''
		''''    '�������N���A
		''''    '�������̖�
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_NOT
		''''    '�����s������
		''''    pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = 0
		''''
		''''    CF_Cmn_Ctl_MN_UnDoDe = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_Cut
	'   �T�v�F  ���j���[�̐؂���̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_Cut(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'�Ώۓ��e��ޔ�
		On Error Resume Next
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_Dsp_Sub_Inf)))
		On Error GoTo 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_MN_Copy
	'   �T�v�F  ���j���[�̃R�s�[�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_MN_Copy(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'�N���A
		On Error Resume Next
		My.Computer.Clipboard.Clear()
		On Error GoTo 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelLength �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If pm_Dsp_Sub_Inf.Ctl.SelLength <= 1 Then
			'�Ώۓ��e��ޔ�
			On Error Resume Next
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_Dsp_Sub_Inf)))
			On Error GoTo 0
		Else
			'�Ώۓ��e(�I�𕔕��̂�)��ޔ�
			On Error Resume Next
			'UPGRADE_WARNING: �I�u�W�F�N�g pm_Dsp_Sub_Inf.Ctl.SelText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			My.Computer.Clipboard.SetText(pm_Dsp_Sub_Inf.Ctl.SelText)
			On Error GoTo 0
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Cmn_Ctl_SM_AllCopy
	'   �T�v�F  ���ړ��e�ɃR�s�[�̐���
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Cmn_Ctl_SM_AllCopy(ByRef pm_All As Cls_All) As Short
		
		'�N���A
		On Error Resume Next
		My.Computer.Clipboard.Clear()
		On Error GoTo 0
		
		'�Ώۓ��e��ޔ�
		On Error Resume Next
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Get_Item_Value() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		My.Computer.Clipboard.SetText(CStr(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.PopupMenu_Idx))))
		On Error GoTo 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_CCurString
	'   �T�v�F  CCur�֐��g����
	'   �����F�@pin_strNum    : �^�ϊ��Ώە�����
	'   �ߒl�F�@�^�ϊ���̒l
	'   ���l�F  ���l�Ƃ��Đ������Ȃ��ꍇ�A�[����Ԋ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CCurString(ByRef pin_strNum As String, Optional ByRef pin_curDefValue As Decimal = 0) As Decimal
		
		Dim Ret_Value As Decimal
		
		If IsNumeric(pin_strNum) = True Then
			'���l�Ƃ��Đ������ꍇ�͌^�ϊ�
			Ret_Value = CDec(pin_strNum)
		Else
			'�������Ȃ��ꍇ�͑�Q�����̒l
			'�i�n����Ȃ��ꍇ�̓[���j
			Ret_Value = pin_curDefValue
		End If
		
		CF_Get_CCurString = Ret_Value
		
	End Function
	
	'���������������� �S��ʋ��ʏ��� End ��������������������������������
End Module